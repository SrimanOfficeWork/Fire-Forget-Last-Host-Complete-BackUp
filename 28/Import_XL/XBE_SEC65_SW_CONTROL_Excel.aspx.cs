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
using System.Xml.Schema;


public partial class XBE_SEC65_SW_CONTROL_Excel : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataTable dt = new DataTable();
    Import_XL_Upload imp_XL = new Import_XL_Upload();
    DataTable selected;
    DataTable dtt = new DataTable();
    AdminMasterDetails adm = new AdminMasterDetails();

    public int i;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string LoginDate;
    public string IMPORT_JOBNO, INVOICE_SLNO, INVOICE_NO, ITEM_SLNO;

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt_Avail = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_scheme = new DataSet();

    string file_ext = "";
    public string errorFolder = "", logFileName = "", selectSQL = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "SEC65_EXBOND_BE_XL_UPLOAD");
        if (Session["IMPORT_JOBNO"] != null)
        {
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
        }

        //DataTable f = new DataTable();
        //gv_Details.DataSource = f;
        //gv_Details.DataBind();
    }

    public string Get_ExcelFile()
    {
        DataSet ds_validate = new DataSet();
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

        DataTable filteredRows = ds.Tables[0].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();
        DataSet dss = new DataSet();
        dss.Tables.Add(filteredRows);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ViewState["ds_Excel_upload"] = dss;
        }

        //-------------------- Bulk Insert for Validate ----------

        System.Data.DataView view = new System.Data.DataView(dss.Tables[0]);
        System.Data.DataTable selected = view.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "WAREHOUSE_CODE", "WAREHOUSE_DATE", "GST_INVOICE_NO", "GST_INVOICE_DATE");

        //Delete table - TBL_EXPORT_EXCEL_FORMAT
        Delete_Temp_table();

        //-------Insert Bulk Data to Table
        adm.SqlBulk_Upload_Product("TBL_IMPORT_XBE_SEC65_XL_FORMAT", selected, Connection.GetConnection());

        ds_validate = imp_XL.BulkXBE_SEC65_Excel_Upload("Check_Excel_Validate");

        if (ds_validate.Tables[0].Rows.Count > 0)
        {
            gv_Details.Visible = true;
            gv_Details.DataSource = ds_validate;
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");
        }
        else
        {
            if (ds_validate.Tables[1].Rows.Count > 0 && ds_validate.Tables[1].Rows[0][0].ToString() != "0")
            {
                MP_U.Show();
            }
            else
            {
                ds_validate = imp_XL.BulkXBE_SEC65_Excel_Upload("Insert_data");

                //Delete table - TBL_EXPORT_EXCEL_FORMAT
                Delete_Temp_table();

                Alert_msg("Uploaded Successfully..!");
            }
        }

        
     

        return strFileType.Trim();
    }

    protected void btn_XBE_Upload_Click(object sender, EventArgs e)
    {
        try
        {
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
            
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }


    protected void btnyes_Click(object sender, EventArgs e)
    {
        DataSet d = new DataSet();
     
        d = imp_XL.BulkXBE_SEC65_Excel_Upload("Delete");
        if (imp_XL.result1 == "1")
        {
            MP_U.Hide();
            d = imp_XL.BulkXBE_SEC65_Excel_Upload("Insert_data");

            //Delete table - TBL_EXPORT_EXCEL_FORMAT
            Delete_Temp_table();

            Alert_msg("Uploaded Successfully..!");
        }
        else
        {
            Alert_msg("Not Deleted");
        }
    }


    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
            {
                e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[i].Font.Bold = true;
                e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Left;
            }
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


    private void Delete_Temp_table()
    {
       
        selectSQL = "delete from TBL_IMPORT_XBE_SEC65_XL_FORMAT";
        SqlCommand cmd1 = new SqlCommand(selectSQL, adm.Sql_openConnection(Connection.GetConnection()));
        SqlDataReader reader = cmd1.ExecuteReader();
        reader.Close();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'XBE- SEC65 Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'XBE- SEC65 Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}
