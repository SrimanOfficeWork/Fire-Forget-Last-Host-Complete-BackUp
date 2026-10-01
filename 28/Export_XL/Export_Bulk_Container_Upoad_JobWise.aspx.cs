using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

using System.Globalization;

public partial class Export_Bulk_Container_Upoad_JobWise : ThemeClass
{
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
 
    adminmaster adm = new adminmaster();
    Annexure_C_Sea_Container ANNEX_C_Sea_Con = new Annexure_C_Sea_Container();
    AdminMasterDetails admin = new AdminMasterDetails();
    public int i, Cont_id_Max;
    string grid_status = "";
    public string COMPANY_ID = string.Empty;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_scheme = new DataSet();


    public string errorFolder = "", logFileName = "";


    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Export_Bulk_License_Excel");
      
        SELECT_BRANCH = Connection.Get_Company_Type();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Export_Bulk_License_Excel");
        DataTable dt =new DataTable();
        dt.Columns.Add("SLNO");
        dt.Columns.Add("JobNo");
        dt.Columns.Add("Container_No");
        dt.Columns.Add("Size");
        dt.Columns.Add("Type");
        dt.Columns.Add("Excise Seal No");
        dt.Columns.Add("Seal Date");
        dt.Columns.Add("Seal Type Indicator");
        dt.Columns.Add("Seal Device ID");
        dt.Columns.Add("Movement Doc.Type");
        dt.Columns.Add("Movement Doc.Number");
        gv_Preview.DataSource = dt;
        gv_Preview.DataBind();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Container Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Container Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    public string Get_ExcelFile()
    {
        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadExcel.FileName;

        string picExtension;
        string fileName2;

        if (fileuploadExcel.HasFile)
        {
            picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
            fileName2 = fileuploadExcel.FileName;
            addtoGallery1(fileName2, errorFolder);
        }

        if (strFileType.Trim() == ".xls" || strFileType.Trim() == ".xlsx")
        {
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            //----------------------------
            string query = "SELECT * FROM [Sheet1$]";


            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            da.Fill(ds);
            da.Dispose();
            conn.Close();
            conn.Dispose();

        }
        ViewState["ds_Excel_upload"] = ds;
        return strFileType.Trim();
    }

    protected void btn_Export_BulkUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string file_ext = "";
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                file_ext = Get_ExcelFile();

                ViewState["File_Exten"] = file_ext;
            }
            else
            {

                Directory.CreateDirectory(errorFolder);
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                file_ext = Get_ExcelFile();
                ViewState["File_Exten"] = file_ext;
            }

            Excel_Upload_load(file_ext);

        }
        catch (Exception ex)
        {
            //Maildb.StoreMailContents(ds, email);
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Get_Annex_C_Container_MaxID()
    {
        ANNEX_C_Sea_Con.ANNEX_SEA_CON_ID = "";
        ANNEX_C_Sea_Con.ANNEX_SEA_CON_JOBNO = "";
        ANNEX_C_Sea_Con.WORKING_PERIOD = SELECT_BRANCH;
        ANNEX_C_Sea_Con.Ename = "Select_MAX_Container_ID";
        ds = ANNEX_C_Sea_Con.RetrieveAll_Annexure_C_Sea_Container_Details();

        if (ds.Tables[0].Rows.Count > 0)
        {
            Cont_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["ANNEX_SEA_CON_ID"].ToString());
        }
    }

    public void Excel_Upload_load(string file_ext)
    {
        Get_Annex_C_Container_MaxID();
        DataSet Inv_ds = new DataSet();
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0, b = 0, c = 1;
        ds.Tables[0].Rows.Add();
        if (ds.Tables[0].Rows.Count > a)
        {
            #region create dataset column
            dsXML.Tables.Add("Export_Annex_C_Container_Details");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_ID");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_JOBNO");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_CONTAINERNO");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_SIZE");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_TYPE");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_EXCISE_SEALNO");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_SEAL_DATE");
            dsXML.Tables[0].Columns.Add("USER_ID");
            dsXML.Tables[0].Columns.Add("DATE_TIME");
            dsXML.Tables[0].Columns.Add("STATUS");
            dsXML.Tables[0].Columns.Add("BRANCH_CODE");
            dsXML.Tables[0].Columns.Add("YEAR");
            dsXML.Tables[0].Columns.Add("WORKING_PERIOD");
            dsXML.Tables[0].Columns.Add("MODIFIEDBY");
            dsXML.Tables[0].Columns.Add("MODIFIEDON");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_SEALTYPE_INDICATOR");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_SEAL_DEVICEID");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_DOC_TYPE");
            dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_DOC_NUMBER");

            #endregion
            //--------------------End License Details--------------------------//
            if (file_ext == ".xls" || file_ext == ".xlsx")
            {
                #region read Excel_Format

                while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                {

                    DataRow dr = dsXML.Tables[0].NewRow();

                    dr["ANNEX_SEA_CON_ID"] = Cont_id_Max;
                    dr["ANNEX_SEA_CON_JOBNO"] = ds.Tables[0].Rows[a][0].ToString();
                    dr["ANNEX_SEA_CON_CONTAINERNO"] = ds.Tables[0].Rows[a][1].ToString().TrimEnd();
                    dr["ANNEX_SEA_CON_SIZE"] = ds.Tables[0].Rows[a][2].ToString().TrimEnd();
                    dr["ANNEX_SEA_CON_TYPE"] = ds.Tables[0].Rows[a][3].ToString().TrimEnd();
                    dr["ANNEX_SEA_CON_EXCISE_SEALNO"] = ds.Tables[0].Rows[a][4].ToString().TrimEnd();

                    //dr["ANNEX_SEA_CON_SEAL_DATE"] = ds.Tables[0].Rows[a][4].ToString();
                    //string SEAL_DATE = Convert.ToDateTime(ds.Tables[0].Rows[a][4].ToString()).ToShortDateString();
                    //string SEAL_DATE1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(SEAL_DATE));

                    //dr["ANNEX_SEA_CON_SEAL_DATE"] = Convert.ToDateTime(SEAL_DATE1).ToString(@"MM/dd/yyyy");
                    if (ds.Tables[0].Rows[a][5].ToString() != "")
                    {
                        dr["ANNEX_SEA_CON_SEAL_DATE"] = DateTime.Parse(ds.Tables[0].Rows[a][5].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    }
                    else
                    {
                        dr["ANNEX_SEA_CON_SEAL_DATE"] = "01/01/1900";
                    }

                    dr["USER_ID"] = currentuser;
                    dr["DATE_TIME"] = LoginDate;
                    dr["STATUS"] = "N";
                    dr["BRANCH_CODE"] = currentbranch;
                    dr["YEAR"] = "";
                    dr["WORKING_PERIOD"] = Working_Period;
                    dr["MODIFIEDBY"] = LoginDate;
                    dr["MODIFIEDON"] = LoginDate;

                    dr["ANNEX_SEA_CON_SEALTYPE_INDICATOR"] = ds.Tables[0].Rows[a][6].ToString();
                    dr["ANNEX_SEA_CON_SEAL_DEVICEID"] = ds.Tables[0].Rows[a][7].ToString();
                    dr["ANNEX_SEA_CON_DOC_TYPE"] = ds.Tables[0].Rows[a][8].ToString();
                    dr["ANNEX_SEA_CON_DOC_NUMBER"] = ds.Tables[0].Rows[a][9].ToString();

                    dsXML.Tables[0].Rows.Add(dr);
                    a++;
                    Cont_id_Max = Cont_id_Max + 1;
                }
                #endregion

                dt = dsXML.Tables["Export_Annex_C_Container_Details"];
                //diana added
                try
                {
                    if (dsXML.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsTbl = new DataSet();
                        ANNEX_C_Sea_Con.xmlData = DataTableToXml(dsXML);
                        dsTbl = ANNEX_C_Sea_Con.SqlBulk_Upload_Product();
                      
                        if (dsTbl.Tables[0].Rows[0][0].ToString() == "UPLOADED SUCCESSFULLY")
                        {
                            Alert_msg("Uploaded Successfully..");
                            DataTable dt_cont = ds.Tables[0];
                            DataView dv_Bind = new DataView(dt_cont);
                            dt_cont = dv_Bind.ToTable(true, "JobNo");
                            Update_Container_Count_Annexure_C_Sea(dt_cont, ds.Tables[0]);
                            gv_Preview_Header.Visible = false;
                            Label12.Text = ("Uploaded Successfully..");
                        }
                        else
                        {
                            Label12.Text = dsTbl.Tables[0].Rows[0][0].ToString();
                            gv_Preview_Header.DataSource = dsTbl.Tables[1].Clone();
                            gv_Preview_Header.DataBind();
                            gv_Preview.DataSource = dsTbl.Tables[1];
                            gv_Preview.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
    private string DataTableToXml(DataSet ds)
    {
        using (System.IO.StringWriter sw = new System.IO.StringWriter())
        {
            ds.Tables[0].WriteXml(sw, XmlWriteMode.WriteSchema);
            return sw.ToString();
        }
    }
    private void Update_Container_Count_Annexure_C_Sea(DataTable dt_cont, DataTable dt)
    {

        string Jobs = "";
        DataView view1 = dt.DefaultView;
        DataSet dtuser = new DataSet();
        
        for (int i = 0; i <= dt_cont.Rows.Count -1; i++)
        {
            if (dt_cont.Rows[i][0].ToString() != "")
            {
                view1.RowFilter = "JobNo = " + dt_cont.Rows[i][0].ToString() + "";
                DataTable table1 = view1.ToTable();
                int ccnt = table1.Rows.Count;

                Jobs += dt_cont.Rows[i][0].ToString() + "*" + table1.Rows.Count + "~";
            }
        }

        if (Jobs != "")
        {
            Annexure_C_Sea ANNEX_C_Sea = new Annexure_C_Sea();
            ANNEX_C_Sea.ANNEX_SEA_ID = "";
            ANNEX_C_Sea.ANNEX_SEA_JOBNO = Jobs;

            ANNEX_C_Sea.Ename = "Update_Container_Count";
            ANNEX_C_Sea.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = ANNEX_C_Sea.RetrieveAll_Annexure_C_Sea_Details();
        }
        
    }


    public void addtoGallery1(string picName, string folderName)
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

    public DataTable RemoveUnusedColumnsAndRows(DataTable dt)
    {
        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            if (dt.Rows[i][1] == DBNull.Value)
                dt.Rows[i].Delete();
        }
        dt.AcceptChanges();
        foreach (var column in dt.Columns.Cast<DataColumn>().ToArray())
        {
            if (dt.AsEnumerable().All(dr => dr.IsNull(column)))
                dt.Columns.Remove(column);
        }

        dt.AcceptChanges();
        return dt;
    }


    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ForeColor = System.Drawing.Color.Black;
            e.Row.BackColor = System.Drawing.Color.Gray;

        }

    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
}