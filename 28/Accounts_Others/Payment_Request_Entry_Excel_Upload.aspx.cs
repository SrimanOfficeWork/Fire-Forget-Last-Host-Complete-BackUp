using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.OleDb;
using System.Collections;
using System.Data;

public partial class Accounts_Others_Payment_Request_Entry_Excel_Upload : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Payment_Request PR = new Payment_Request();
    Global_variables ObjUBO = new Global_variables();

    public int i;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;

    public string SELECT_BRANCH, COMPANY_ID;
    public string file_ext = "";

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public string errorFolder = "", logline = "", logFileName = "", BP_ID, bpRNoF, bpRM, bpRL, payCus, payToValue;
    public string folderName = "/Accounts_Submission";
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    DataSet ds_up = new DataSet();
    DataSet dsXML = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        COMPANY_ID = Session["COMPANY_ID"].ToString();
        if (!Page.IsPostBack)
        {
            BP_ID = Request.QueryString["BP_R_ID"];
            payCus = Request.QueryString["Pay_Cusname"];
             txt_BP_R_No_F.Text = Request.QueryString["BP_R_No_F"].ToString();
             txt_BP_R_M.Text = Request.QueryString["BP_R_M"].ToString();
             txt_BP_R_L.Text = Request.QueryString["BP_R_L"].ToString();
               payToValue = Request.QueryString["Pay_to"] ?? "";

             Dictionary<string, string> payToMap = new Dictionary<string, string>();
             payToMap.Add("V", "Vendor");
             payToMap.Add("E", "Employee");
             payToMap.Add("T", "Transporter");
             payToMap.Add("O", "Other Entity");

             string payToText = payToMap.ContainsKey(payToValue)
                 ? payToMap[payToValue]
                 : "Unknown";
             Lbl_Payto.Text = payToText;
             Lbl_PayCusName.Text = payCus;

              
        }
        SELECT_BRANCH = Connection.Get_Company_Type();
        errorFolder = Server.MapPath("~/Accounts_Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Account_Payment_Req_Excel_Format");
        gv_Details.DataSource = dt;
        gv_Details.DataBind();
    }

   

    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {

            if (File.Exists(errorFolder))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Get_ExcelFile();
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                dir.Create();
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Get_ExcelFile();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        try
        {
             DataTable dt_up = (DataTable)ViewState["Excel_Data"];
            string xmlData1 = ConvertDataTableToXML(dt_up);
            ObjUBO.A1 = txt_BP_R_No_F.Text;
            ObjUBO.A2 = txt_BP_R_M.Text;
            ObjUBO.A3 = txt_BP_R_L.Text;
            ObjUBO.A6 = Request.QueryString["Pay_to"].ToString();
            ObjUBO.A7 = Lbl_PayCusName.Text;
            ObjUBO.A20 = "S";
            gv_Details.DataSource = dt_up;
            gv_Details.DataBind();
            ds_up = PR.Payment_Request_Excel_Upload_Ins_Select(ObjUBO, xmlData1);
            if (ds_up.Tables[0].Rows.Count > 0)
            {
                if (ds_up.Tables[0].Rows[0]["Alert"].ToString() == "1")
                {
                    MP_U.Show();
                }
                else
                {

                    Alert_msg(ds_up.Tables[0].Rows[0]["Alert"].ToString());
                }
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

    }
     public void Get_ExcelFile()
    {
       
            DataSet ds = new DataSet();
            string connString = string.Empty;
            string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
            string path = errorFolder + "\\" + fileuploadExcel.FileName;
            ViewState["Excel_Data"] = "";
            if (fileuploadExcel.HasFile)
            {
                try
                {
                    string picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
                    string fileName2 = fileuploadExcel.FileName;
                    addtoGallery1(fileName2, errorFolder, "NORMAL");
                    if (strFileType.Trim() == ".xls")
                    {
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    else if (strFileType.Trim() == ".xlsx")
                    {
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }

                    OleDbConnection conn = new OleDbConnection(connString);
                    DataTable dtt = new DataTable();

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    String firstSheetName = dtSchema.Rows[0].Field<string>("TABLE_NAME");
                    string query = string.Format("SELECT * FROM [{0}]", firstSheetName);
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dtt);
                    da.Dispose();
                    conn.Close();
                    conn.Dispose();
                    DataTable filteredRows = dtt.Rows.Cast<DataRow>()
                        .Where(row => !row.ItemArray.All(field => field is DBNull))
                        .CopyToDataTable();
                    ds.Tables.Add(filteredRows);
                    Lbl_alert_msg.Text = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string xmlData1 = ConvertDataTableToXML(ds.Tables[0]);
                        ObjUBO.A20 = "Excel_Select";
                        dsXML = PR.Payment_Request_Excel_Upload_Ins_Select(ObjUBO, xmlData1);
                        if (dsXML.Tables[0].Rows.Count > 0)
                        {
                            ViewState["Excel_Data"] = dsXML.Tables[0];
                            gv_Details.DataSource = dsXML.Tables[0];
                            gv_Details.DataBind();
                        }
                      


                    }
                }
                catch (Exception ex)
                {
                    Alert_msg("Error during Excel file processing: " + ex.Message);
                }
            }

            else
            {
                Alert_msg("No file uploaded.");
            }
        
        
    }

    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (string.IsNullOrEmpty(e.Row.Cells[3].Text.Replace("&nbsp;", "")))
            {
                e.Row.Cells[3].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[3].Text = "Invalid jobno";
            }
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Font.Bold = true;
        }
    }


    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();
        foreach (DataRow dtRow in dTable.Rows)
        {
            if (hTable.Contains(dtRow[colName]))
                duplicateList.Add(dtRow);
            else
                hTable.Add(dtRow[colName], string.Empty);
        }
        foreach (DataRow dtRow in duplicateList)
            dTable.Rows.Remove(dtRow);
        return dTable;
    }

    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }

    public string fnGetPictureExtn(string pictureName)
    {
        try
        {
            if (pictureName.ToUpper().EndsWith(".JPG"))
                return ".JPG";
            else if (pictureName.ToUpper().EndsWith(".JPEG"))
                return ".JPEG";
            else if (pictureName.ToUpper().EndsWith(".GIF"))
                return ".GIF";
            else if (pictureName.ToUpper().EndsWith(".DOC"))
                return ".DOC";
            else if (pictureName.ToUpper().EndsWith(".XLS"))
                return ".XLS";
            else if (pictureName.ToUpper().EndsWith(".PDF"))
                return ".PDF";
            else if (pictureName.ToUpper().EndsWith(".PNG"))
                return ".PNG";
            else if (pictureName.ToUpper().EndsWith(".CDR"))
                return ".CDR";
            else if (pictureName.ToUpper().EndsWith(".PSD"))
                return ".PSD";
            else if (pictureName.ToUpper().EndsWith(".TXT"))
                return ".TXT";
            else if (pictureName.ToUpper().EndsWith(".XLSX"))
                return ".XLSX";
            else
            {
            }
        }
        catch
        {
        }
        finally
        {
        }
        return "";
    }
    public void addtoGallery1(string picName, string folderName, string Excel_Name)
    {
        string strFolderPath;
        string strImagePath;
        try
        {
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
            strImagePath = Path.Combine(strFolderPath, picName);


            fileuploadExcel.SaveAs(strImagePath);


        }
        catch
        {
        }
        finally
        {
        }
    }
     public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Excel', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Excel', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}