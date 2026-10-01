using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Text;
using System.Web.Services;
using System.Data.OleDb;
using System.Collections;
using System.Data;

using BussinessObject;

public partial class Import_CP_Excel : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    Import_XL_Upload IXU = new Import_XL_Upload();

    public string errorFolder_CT_PLR = "", logFileName = "";
    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if ( Connection.IMP_Jobno() == null)
        {
            Response.Write("<script>window.parent.document.getElementById('General').click();</script>");
        }

        errorFolder_CT_PLR = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "CT_PLR");

        if (!IsPostBack)
        {
            if (Directory.Exists(errorFolder_CT_PLR) == false)
            {
                Directory.CreateDirectory(errorFolder_CT_PLR);
            }
        }
        //MP_U.Show();
    }
    protected void btn_upload_Click(object sender, EventArgs e)
    {
          try
            {
                if (txt_SupplierName_Gen.Text != "")
                {
                    //-----------------------------------
                    if (File.Exists(errorFolder_CT_PLR + logFileName))
                    {
                        DirectoryInfo dir = new DirectoryInfo(errorFolder_CT_PLR);
                        foreach (FileInfo fi in dir.GetFiles())
                        {
                            fi.Delete();
                        }
                        Get_ExcelFile_CT_PLR();
                    }
                    else
                    {
                        DirectoryInfo dir = new DirectoryInfo(errorFolder_CT_PLR);

                        foreach (FileInfo fi in dir.GetFiles())
                        {
                            fi.Delete();
                        }

                        Get_ExcelFile_CT_PLR();
                    }
                    //------------------------------------------------
                }
                else
                {
                    Alert_msg("Select Supplier Name");
                }
        }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        DataSet dss=new DataSet();
        try
        {
            ObjUBO.Xml_D = "";
            ObjUBO.SHIPPER_NAME = txt_SupplierName_Gen.Text;
            ObjUBO.Xml_D = Session["XL"].ToString();
            ObjUBO.flag = "Excel_Upload";
            dss =IXU.IMP_CP_XL_DML(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Excel Uploaded Successfully.");
            }
            else
            {
                Alert_msg("Excel Not Uploaded");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    public void  Get_ExcelFile_CT_PLR()
    {
        lblmsg.Text = string.Empty;
        DataSet ds_XL=new DataSet();
        DataSet ds = new DataSet();

        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel_CP.FileName).ToLower();
        string path = errorFolder_CT_PLR + "\\" + fileuploadExcel_CP.FileName;

        string picExtension;
        string fileName2;

        if (fileuploadExcel_CP.HasFile)
        {
            picExtension = fnGetPictureExtn(fileuploadExcel_CP.FileName);
            fileName2 = fileuploadExcel_CP.FileName;
            fileuploadExcel_CP.SaveAs(path);


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

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;

                    DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    string sht_name = dtSheet.Rows[0]["TABLE_NAME"].ToString();
                    cmd.CommandText = "Select * from [" + sht_name + "]";

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(ds_XL);

                    da.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
                DirectoryInfo dir = new DirectoryInfo(errorFolder_CT_PLR);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    if (fileuploadExcel_CP.FileName == fi.Name)
                    {
                        fi.Delete();
                    }
                }
                if (ds_XL.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = ds_XL.Tables[0];
                    dt.Columns[0].ColumnName = "SLNO";
                    dt.Columns[1].ColumnName = "INVNO";
                    dt.Columns[2].ColumnName = "INVDATE";
                    dt.Columns[3].ColumnName = "TERMS";
                    dt.Columns[4].ColumnName = "INVCUR";
                    dt.Columns[5].ColumnName = "QTY";
                    dt.Columns[6].ColumnName = "UNIT";
                    dt.Columns[7].ColumnName = "RATE";
                    dt.Columns[8].ColumnName = "ITEM_DESC";
                    dt.Columns[9].ColumnName = "FREIGHT";
                    dt.Columns[10].ColumnName = "FREIGHT_CUR";
                    dt.Columns[11].ColumnName = "INS";
                    dt.Columns[12].ColumnName = "INS_CUR";
                    dt.Columns[13].ColumnName = "MISC";
                    dt.Columns[14].ColumnName = "MISC_CUR";
                    dt.Columns[15].ColumnName = "KGS";
                    dt.Columns[16].ColumnName = "IGST_LEVY_COMPENSATION_CESS_NOTN";
                    dt.Columns[17].ColumnName = "IGST_LEVY_COMPENSATION_CESS_SLNO";
                    dt.Columns[18].ColumnName = "COUNTRY_OF_ORIGIN";

                   /* dt.Columns[15].ColumnName = "PARTNO";
                    dt.Columns[16].ColumnName = "EX_Price";
                    dt.Columns[17].ColumnName = "FOB";*/
                    dt.AcceptChanges();

                    ObjUBO.Xml_D = ConvertDataTableToXML(dt);
                    ObjUBO.flag = "Excel_Select";
                    ds = IXU.IMP_CP_XL_Select(ObjUBO);
                    Session["XL"] = "";
                    Session["XL"] = ObjUBO.Xml_D;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnUpload.Visible = false;
                        gv_Item_Details.Visible = true;
                        lblmsg.Text = "Below PartNo not available in Master";
                      
                        gv_Item_Details.DataSource = ds.Tables[0];
                        gv_Item_Details.DataBind();
                    }
                    else
                    {
                        gv_Item_Details.Visible = false;
                        btnUpload.Visible = true;

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        btnUpload.Text = "Replce New Data";
                    }
                    else
                    {
                        btnUpload.Text = "Upload Data";
                    }
                }
            }
            else
            {
                Alert_msg("Not a Valid File");
            }
        }
        else
        {
            Alert_msg("File Should Not be Empty.");
        }
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
        
        return "";
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }

    [System.Web.Services.WebMethod]
    public static string Save_Product(string txtpart_no,string txt_Item_dec,string txt_HSN_Code,string txt_basic_Notn,string txt_basic_Notn_Slno,string txt_IGST_Notn,string txt_IGST_Notn_Slno,string Flag)
    {
        if (txtpart_no != string.Empty)
        {
            if (txt_Item_dec != string.Empty)
            {
                UserBO ObjUBO = new UserBO();
                Import_XL_Upload IXU = new Import_XL_Upload();
                DataSet ds = new DataSet();
                ObjUBO.CONSIGNEE_NAME = txtpart_no;
                ObjUBO.ITEM_DESCRIPTION = txt_Item_dec;
                ObjUBO.ADDRESS1 = txt_HSN_Code;
                ObjUBO.ADDRESS2 = txt_basic_Notn;
                ObjUBO.ADDRESS3 = txt_basic_Notn_Slno;
                ObjUBO.ADDRESS4 = txt_IGST_Notn;
                ObjUBO.ADDRESS5 = txt_IGST_Notn_Slno;
                ObjUBO.flag = Flag;
                ds = IXU.IMP_CP_Prouct_Master_DML(ObjUBO);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "Enter Ur Item Description";
            }
        }
        else
        {
            return "Enter Ur Part No.";
        } 
    }
}

