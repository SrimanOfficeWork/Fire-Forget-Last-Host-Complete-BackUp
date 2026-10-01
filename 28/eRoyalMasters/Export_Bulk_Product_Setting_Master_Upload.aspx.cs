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
using BussinessObject;


public partial class Export_Bulk_Product_Setting_Master_Upload : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();
    DataTable dt = new DataTable();
    Export_Licence Export_license = new Export_Licence();
    AdminMasterDetails admin = new AdminMasterDetails();
    public int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, EXPORT_JOBNO;
    public int License_id_Max, License_id_IMP_EXP_Max;

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt_Avail = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_scheme = new DataSet();
    UserBO ObjUBO = new UserBO();
    Export_XL_Upload IXL = new Export_XL_Upload();


    public string errorFolder = "", logFileName="";
    
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Import_License_master_Excel");
        
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export PDF Setting Master Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export PDF Setting Master Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public int Get_Product_id_Max()
    {
        DataSet ds1 = new DataSet();
        int Product_id_Max = 0;

        ObjUBO.Ename = "Auto_ID";
        ds1 = IXL.Export_Product_Setting_Master_Bulk_Insert(ObjUBO, ds.Tables[0]);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            Product_id_Max = Convert.ToInt32(ds1.Tables[0].Rows[0]["ID"].ToString());
        }
        return Product_id_Max;
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

    protected void btn_Import_BulkUpload_Click(object sender, EventArgs e)
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Excel_Upload_load(string file_ext)
    {
        
        DataSet Inv_ds = new DataSet();
        DataSet dds = new DataSet();
        
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0, b = 0, c = 1;
        ds.Tables[0].Rows.Add();
        
        if (ds.Tables[0].Rows.Count > a)
        {
            //string POTYPE=ds.Tables[0].Rows[
            
            DataColumn workColumn = ds.Tables[0].Columns.Add("ID", typeof(Int32));
            workColumn.SetOrdinal(0);
            int K = Get_Product_id_Max();

            //--------- delete the empty rows form DataTable
            DataTable dtt = ds.Tables[0].Rows
                 .Cast<DataRow>()
                 .Where(row => !row.ItemArray.All(f => f is DBNull))
                 .CopyToDataTable();

            //------------ Assign the running id of ID ----------
            dtt.Rows.Cast<DataRow>().ToList().ForEach((row) => { row["ID"] = K; K++; });

            //------------to TrimEnd() for all datatable Rows  ******************
            dtt.AsEnumerable().ToList()
               .ForEach(row =>
               {
                   var cellList = row.ItemArray.ToList();
                   row.ItemArray = cellList.Select(x => x.ToString().Trim()).ToArray();
               });


            ObjUBO.Ename = "Check_Invalid_Length";
            DataSet ds_len = IXL.Export_Product_Setting_Master_Bulk_Insert(ObjUBO, dtt);

            if (ds_len.Tables[0].Rows.Count > 0)
            {
                string msg = "Data Error - Check Excel" + Environment.NewLine + " ---------------------------------------------------------------" + Environment.NewLine;
                for (int j = 0; j <= ds_len.Tables[0].Rows.Count - 1; j++)
                {
                    if (ds_len.Tables[0].Rows[j][0].ToString() != "")
                    {
                        msg += ds_len.Tables[0].Rows[j][0].ToString() + "  " + Environment.NewLine;
                    }
                }
                hdinvno.Value = msg;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);
            }
            else if (ds_len.Tables[1].Rows.Count > 0)
            {
                string msg = Environment.NewLine + "Data Already Exists - Check Excel" + Environment.NewLine + " ---------------------------------------------------------------" + Environment.NewLine;

                for (int j = 0; j <= ds_len.Tables[1].Rows.Count - 1; j++)
                {
                    msg += "   DESC : " + ds_len.Tables[1].Rows[j][0].ToString() + Environment.NewLine;
                }
                hdinvno.Value = msg;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);
            }
            //else if (ds_len.Tables[2].Rows.Count > 0)
            //{
            //    string msg = Environment.NewLine + "Special Characters Exists - Check Excel" + Environment.NewLine + " ---------------------------------------------------------------" + Environment.NewLine;

            //    for (int j = 0; j <= ds_len.Tables[2].Rows.Count - 1; j++)
            //    {
            //        msg += " FieldName :  " + ds_len.Tables[2].Rows[j][1].ToString() + "  -  Error : " + ds_len.Tables[2].Rows[j][2].ToString() + Environment.NewLine;
            //    }
            //    hdinvno.Value = msg;
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);
            //}
            else
            {
                ObjUBO.Ename = "Export_Bulk_Insert";
                ds = IXL.Export_Product_Setting_Master_Bulk_Insert(ObjUBO, dtt);
                Alert_msg("Uploaded Successfully..");
            }                     
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

    public string Get_Scheme_Code(string scheme)
    {
        //----------------------SCHEME IMPORT MASTER-------------------------------//

        adm.SCHEME_IMPORT_CODE = scheme;
        adm.SCHEME_NOTN = "0";
        adm.name = "SCHEME_IMPORT_CODE";

        //ddlSchemeCode.DataSource = 
        ds_scheme = adm.RetrieveAll_Scheme_Import();
        if (ds_scheme.Tables[2].Rows.Count > 0)
        {
            scheme = ds_scheme.Tables[2].Rows[0]["SCHEME_CODE"].ToString();
        }

        return scheme;
    }

    public int Check_Avail_License(string License_No, string ItemNo)
    {
        DataSet dss = new DataSet();
        erm.LICENSE_ID = ItemNo;
        erm.LICENSE_NO = License_No;
        erm.Ename = "Check_Avail";
        erm.EWorking_Period = Working_Period;

        dss = erm.RetrieveAll_IMPORT_LICENSE_MASTER();
       i = erm.result;
       
        return i;
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
}
