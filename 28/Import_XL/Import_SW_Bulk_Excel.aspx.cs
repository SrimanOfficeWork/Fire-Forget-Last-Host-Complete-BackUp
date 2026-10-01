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



public partial class Import_SW_Bulk_Excel : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    string selectSQL;

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
   
    SqlCommand cmd = new SqlCommand();
    AdminMasterDetails adm1 = new AdminMasterDetails();
    Import_XL_Upload Imp_XL = new Import_XL_Upload();

    public string errorFolder = "", logFileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
      
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "IMP_SW_XL_UPLOAD");

        lblheader1.Visible = false;
        lblheader2.Visible = false;
        lblheader3.Visible = false;
        lblheader4.Visible = false;

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import SW XL Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import SW XL Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        try
        {
            if (fileuploadExcel.HasFile)
            {
                Excelfile();
                Session.Remove("fileUpload");
                Session["fileUpload"] = fileuploadExcel;
                fileuploadExcel = (FileUpload)Session["fileUpload"];

                Label1.Text = fileuploadExcel.FileName;
               
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Excelfile()
    {
        if (File.Exists(errorFolder + logFileName))
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
            Directory.CreateDirectory(errorFolder);
            DirectoryInfo dir = new DirectoryInfo(errorFolder);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            Get_ExcelFile();
        }
    }


    public void Get_ExcelFile()
    {
        string connString = "";

        string strFileType = "";
        string path = "";

        string picExtension;
        string fileName2;


        strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        //string path = "C:\\Documents and Settings\\sathis\\Desktop\\" + fileuploadExcel.FileName;
        path = errorFolder + "\\" + fileuploadExcel.FileName;

        picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
        fileName2 = fileuploadExcel.FileName;
        addtoGallery1(fileName2, errorFolder);


        //Connection String to Excel Workbook
        if (strFileType.Trim() == ".xls")
        {
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        }
        else if (strFileType.Trim() == ".xlsx")
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        }

        //string query = "SELECT * FROM [Sheet1$]";
        OleDbConnection conn = new OleDbConnection(connString);
        DataTable dtt = new DataTable();
        if (conn.State == ConnectionState.Closed)
            conn.Open();
        DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

        DataSet ds_output = new DataSet();
        DataSet ds_validate = new DataSet();

        string query = "", sheetname = "";

        //-- Order wise Sheet name insert to Dataset
        DataTable dt_sheetname = new DataTable();
        dt_sheetname.Columns.Add("SheetName");
        dt_sheetname.Rows.Add("SW_INFO_TYPE$");
        dt_sheetname.Rows.Add("SW_CONSTITUTE$");
        dt_sheetname.Rows.Add("SW_PRODUCTION$");
        dt_sheetname.Rows.Add("SW_CONTROL$");


        for (int k = 0; k <= dtSchema.Rows.Count - 1; k++)
        {
            sheetname = dt_sheetname.Rows[k]["SheetName"].ToString();

            var dtt2 = new DataTable();

            query = "SELECT * FROM [" + sheetname + "]";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtt2);
            ds_output.Tables.Add(dtt2);
            da.Dispose();

        }
        conn.Close();
        conn.Dispose();

        if (ds_output.Tables[0].Rows.Count > 0)
        {
            DataTable filteredRows1 = ds_output.Tables[0].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();

            System.Data.DataView view1 = new System.Data.DataView(filteredRows1);
            System.Data.DataTable selected1 = view1.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "DEPARTMENT", "INFO_TYPE", "INFO_QUALIFIER", "INFO_CODE", "INFO_TEXT", "INFO_MSR", "INFO_UQC", "REGN_DATE", "REGN_VALIDITY");

            Delete_Temp_table("SW_INFO");
            adm1.SqlBulk_Upload_Product("TBL_IMPORT_SW_INFO_EXCEL_FORMAT", selected1, Connection.GetConnection());
        }
        if (ds_output.Tables[1].Rows.Count > 0)
        {
            DataTable filteredRows2 = ds_output.Tables[1].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();

            System.Data.DataView view2 = new System.Data.DataView(filteredRows2);
            System.Data.DataTable selected2 = view2.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "CONST_SRNO", "CONST_ELEMENT_NAME", "CONST_ELEMENT_CODE", "CONST_PERCENTAGE", "CONST_YIELD_PERCENTAGE", "ACTIVE_INGREDIENT");

            Delete_Temp_table("SW_CONSTITUTE");
            adm1.SqlBulk_Upload_Product("TBL_IMPORT_SW_CONSTITUTE_EXCEL_FORMAT", selected2, Connection.GetConnection());
        }

        if (ds_output.Tables[2].Rows.Count > 0)
        {
            DataTable filteredRows3 = ds_output.Tables[2].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();

            System.Data.DataView view3 = new System.Data.DataView(filteredRows3);
            System.Data.DataTable selected3 = view3.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "BATCH_IDENTIFIER", "BATCH_QUANTITY", "UNIT_QTY_CODE", "DATE_OF_MANUFACTURING", "DATE_OF_EXPIRY", "BEST_BEFORE");

            Delete_Temp_table("SW_PRODUCTION");
            adm1.SqlBulk_Upload_Product("TBL_IMPORT_SW_PRODUCTION_EXCEL_FORMAT", selected3, Connection.GetConnection());
        }

        if (ds_output.Tables[3].Rows.Count > 0)
        {
            DataTable filteredRows4 = ds_output.Tables[3].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();

            System.Data.DataView view4 = new System.Data.DataView(filteredRows4);
            System.Data.DataTable selected4 = view4.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "CONTROL_TYPE_CODE", "CONTROL_LOCATION", "START_DATE", "END_DATE", "RESULT_CODE", "RESULT_TEXT", "CONTROL_MSR", "CONTROL_UQC", "CONTROL_SLNO");

            Delete_Temp_table("SW_CONTROL");
            adm1.SqlBulk_Upload_Product("TBL_IMPORT_SW_CONTROL_EXCEL_FORMAT", selected4, Connection.GetConnection());
        }

        ds_validate = Imp_XL.Bulk_Excel_Validation("Import_SW_Excel_Validation");

        if (ds_validate.Tables[0].Rows.Count > 0)
        {
            gv_Error.DataSource = ds_validate.Tables[0];
            gv_Error.DataBind();

            btn_SW_XL_Upload.Visible = false;
        }
        else
        {
            ds_validate.Clear();
            ds_validate = Imp_XL.Import_Bulk_SW_Excel_Upload("chk_Duplicate", "");

            if (ds_validate.Tables[0].Rows.Count == 0 && ds_validate.Tables[1].Rows.Count == 0 && ds_validate.Tables[2].Rows.Count == 0 && ds_validate.Tables[3].Rows.Count == 0)
            {

                mainmastop2container_rght_tag2_txt1.InnerText = "No Error Message Found... You can Upload Your Data's Now.";
                if (ds_output.Tables[0].Rows.Count > 0)
                {
                    gv_Error.Visible = true;
                    lblheader1.Visible = true;
                    //ds_output.Tables[0].Rows.Add("");
                    DataRow newRow = ds_output.Tables[0].NewRow();
                    ds_output.Tables[0].Rows.Add(newRow);
                    gv_Error.DataSource = ds_output.Tables[0];
                    gv_Error.DataBind();
                }
                else
                {
                    gv_Error.Visible = false;
                }

                if (ds_output.Tables[1].Rows.Count > 0)
                {
                    Grid_Const.Visible = true;
                    lblheader2.Visible = true;
                   // ds_output.Tables[1].Rows.Add("");
                    DataRow newRow = ds_output.Tables[1].NewRow();
                    ds_output.Tables[1].Rows.Add(newRow);
                    Grid_Const.DataSource = ds_output.Tables[1];
                    Grid_Const.DataBind();
                }
                else
                {
                    Grid_Const.Visible = false;
                }

                if (ds_output.Tables[2].Rows.Count > 0)
                {
                    Grid_Prod.Visible = true;
                    lblheader3.Visible = true;
                   // ds_output.Tables[2].Rows.Add("");
                    DataRow newRow = ds_output.Tables[2].NewRow();
                    ds_output.Tables[2].Rows.Add(newRow);
                    Grid_Prod.DataSource = ds_output.Tables[2];
                    Grid_Prod.DataBind();
                }
                else
                {
                    Grid_Prod.Visible = false;
                }

                if (ds_output.Tables[3].Rows.Count > 0)
                {
                    Grid_Control.Visible = true;
                    lblheader4.Visible = true;
                    //ds_output.Tables[3].Rows.Add("");
                    DataRow newRow = ds_output.Tables[3].NewRow();
                    ds_output.Tables[3].Rows.Add(newRow);
                    Grid_Control.DataSource = ds_output.Tables[3];
                    Grid_Control.DataBind();
                }
                else
                {
                    Grid_Control.Visible = false;
                }

                btn_SW_XL_Upload.Visible = true;
                ViewState["btn_SW_XL_Upload"] = "Upload";
            }
            else
            {
                string Avail_tbl = "";
                mainmastop2container_rght_tag2_txt1.InnerText = "Record Already Exists in Job.. kindly check..";
                if (ds_validate.Tables[0].Rows.Count > 0)
                {
                    gv_Error.Visible = true;
                    lblheader1.Visible = true;
                    gv_Error.DataSource = ds_validate.Tables[0];
                    gv_Error.DataBind();
                    Avail_tbl = "1";
                }
                else
                {
                    gv_Error.Visible = false;
                    lblheader1.Visible = false;
                }

                if (ds_validate.Tables[1].Rows.Count > 0)
                {
                    Grid_Const.Visible = true;
                    lblheader2.Visible = true;
                    Grid_Const.DataSource = ds_validate.Tables[1];
                    Grid_Const.DataBind();
                    Avail_tbl += "2";
                }
                else
                {
                    Grid_Const.Visible = false;
                    lblheader2.Visible = false;
                }

                if (ds_validate.Tables[2].Rows.Count > 0)
                {
                    Grid_Prod.Visible = true;
                    lblheader3.Visible = true;
                    Grid_Prod.DataSource = ds_validate.Tables[2];
                    Grid_Prod.DataBind();
                    Avail_tbl += "3";
                }
                else
                {
                    Grid_Prod.Visible = false;
                    lblheader3.Visible = false;
                }

                if (ds_validate.Tables[3].Rows.Count > 0)
                {
                    Grid_Control.Visible = true;
                    lblheader4.Visible = true;
                    Grid_Control.DataSource = ds_validate.Tables[3];
                    Grid_Control.DataBind();
                    Avail_tbl += "4";
                }
                else
                {
                    Grid_Control.Visible = false;
                    lblheader4.Visible = false;
                }

                btn_SW_XL_Upload.Visible = true;

                btn_SW_XL_Upload.Text = "Delete All";
                ViewState["btn_SW_XL_Upload"] = "Delete All";
                ViewState["Avail_tbl"] = Avail_tbl;
            }

        }
    }

  

    protected void btn_SW_XL_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["btn_SW_XL_Upload"].ToString() == "Delete All")
            {
                MP_U1.Show();
            }
            else
            {
                Imp_XL.Import_Bulk_SW_Excel_Upload("Import_SW_INFO_ExcelUpload", "");
                mainmastop2container_rght_tag2_txt1.InnerText = "Excel Uploaded Successfully..!";
                Alert_msg("Excel Uploaded Successfully..!");

                gv_Error.Visible = false;
                Grid_Const.Visible = false;
                Grid_Prod.Visible = false;
                Grid_Control.Visible = false;

                lblheader1.Visible = false;
                lblheader2.Visible = false;
                lblheader3.Visible = false;
                lblheader4.Visible = false;


                //Delete table - TBL_EXPORT_EXCEL_FORMAT
                Delete_Temp_table("SW_INFO");
                Delete_Temp_table("SW_CONSTITUTE");
                Delete_Temp_table("SW_PRODUCTION");
                Delete_Temp_table("SW_CONTROL");

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

        Imp_XL.Import_Bulk_SW_Excel_Upload("Delete_All", ViewState["Avail_tbl"].ToString());

        if (Imp_XL.result == 1)
        {
            gv_Error.Visible = false;
            Grid_Const.Visible = false;
            Grid_Prod.Visible = false;
            Grid_Control.Visible = false;

            Alert_msg("Deleted Successfully.");
            MP_U1.Hide();
          

            btn_SW_XL_Upload.Visible = true;
            mainmastop2container_rght_tag2_txt1.InnerText = "You can Upload Your Data's Now.";

            btn_SW_XL_Upload.Text = "Upload";
            MP_U1.Hide();
            ViewState["btn_SW_XL_Upload"] = "Upload";

        }
        else
            Alert_msg("Not Deleted.");

    }

  
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
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

   
    protected void gv_Error_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
 
    protected void gv_Error_RowCreated(object sender, GridViewRowEventArgs e)
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

  

    private void Delete_Temp_table(string TableName)
    {
        if (TableName == "SW_INFO")
        {
            selectSQL = "delete from TBL_IMPORT_SW_INFO_EXCEL_FORMAT";
        }
        else if (TableName == "SW_CONSTITUTE")
        {
            selectSQL = "delete from TBL_IMPORT_SW_CONSTITUTE_EXCEL_FORMAT";
        }
        else if (TableName == "SW_PRODUCTION")
        {
            selectSQL = "delete from TBL_IMPORT_SW_PRODUCTION_EXCEL_FORMAT";
        }
        else if (TableName == "SW_CONTROL")
        {
            selectSQL = "delete from TBL_IMPORT_SW_CONTROL_EXCEL_FORMAT";
        }
        else
        {
        }

        if (TableName != "")
        {
            SqlCommand cmd1 = new SqlCommand(selectSQL, adm1.Sql_openConnection(Connection.GetConnection()));
            SqlDataReader reader = cmd1.ExecuteReader();
            reader.Close();
        }
    }
    
}
