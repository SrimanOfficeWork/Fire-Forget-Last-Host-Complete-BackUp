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
using System.Data.SqlClient;

public partial class Export_Item_ReExport_Excel : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    public int i;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;

    public string SELECT_TYPE, SELECT_BRANCH, COMPANY_ID, xml_Data_ExpREItem;
    public string EXPORT_JOBNO, EXPORT_JOBDATE;

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public string errorFolder = "", logline = "", logFileName = "", error = "";
    public string folderName = "/Submission";

    public string scheme;
    string[] scheme_name = new string[2];

    int sl = 0;
    int sl_E = 0;

    int ii = 0;
    int D_E = 0;

    public int License_id_Max = 0;
    public int License_id_IMP_EXP_Max = 0;

    public string[] lic_no;
    public int licno_Count;
    public decimal item_amt;
    string selectSQL;

    DataSet ds_TPD = new DataSet();
    DataSet ds_draw = new DataSet();
    DataSet ds_license = new DataSet();

    Auto_Search Auto = new Auto_Search();
    Export_Licence License = new Export_Licence();
    Export_XL_Upload EXU = new Export_XL_Upload();

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt = new DataTable();
    SqlCommand cmd = new SqlCommand();
    AdminMasterDetails adm = new AdminMasterDetails();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            COMPANY_ID = Session["COMPANY_ID"].ToString();
            if (Session["EXPORT_JOBNO"] != null)
            {
                EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
                EXPORT_JOBDATE = Session["EXPORT_JOBDATE"].ToString();
            }
            if (!IsPostBack)
            {

            }

            SELECT_BRANCH = Connection.Get_Company_Type();
            errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + "Export_Excel");
            if (!Page.IsPostBack)
            {

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gv_Item_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
      
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //------------------------------------------EXCEL upload- by Antony --------------------------------------------------------------------------------------------------
            GridViewRow row = e.Row;
            // Intitialize TableCell list
            List<TableCell> columns = new List<TableCell>();

            foreach (DataControlField column in gv_Item_Details.Columns)
            {
                TableCell cell = row.Cells[0];
                row.Cells.Remove(cell);
                columns.Add(cell);
            }

            row.Cells.AddRange(columns.ToArray());
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";

            int aa = e.Row.Cells.Count;

            if (ViewState["err_Validate"] == "Y")
            {
                if (e.Row.Cells.Count >= 1)
                {

                    //row.Cells.AddRange(columns.ToArray());
                    //if (e.Row.RowType == DataControlRowType.Header)
                    //    e.Row.CssClass = "header";


                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;

                    if (ViewState["Admin_err"] == "Y")
                    {
                        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[3].Font.Size = 8;
                        e.Row.Cells[5].Visible = false;
                    }
                    else
                    {
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                        if (error != "")
                        {
                            e.Row.Cells[3].Visible = false;
                        }
                    }
                }

                //--------------------------------------------------------------------------------------------------------------------------------------------

                //if (e.Row.RowType == DataControlRowType.Header)
                //    e.Row.CssClass = "header";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    protected void btn_upload_Click(object sender, EventArgs e)
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
                Get_ExcelFile();
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

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

    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            if (gv_Item_Details.Rows.Count > 0)
            {
                DataSet d = new DataSet();
                EXU.JOBNO = Session["EXPORT_JOBNO"].ToString();
                EXU.USER_ID = currentuser;
                EXU.Branch_Code = currentbranch;
                EXU.WORKING_PERIOD = Working_Period;
                d = EXU.Bulk_Item_RE_Export_Excel_Upload_("", "", "Check_Job_exist");

                if (d.Tables[0].Rows.Count > 0)
                {
                    MP_U.Show();
                }
                else
                {
                    Excel_Upload_load();
                }
            }
            else
            {
                Alert_msg("Upload Ur Excel file.");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

    protected void btnyes_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet d = new DataSet();
            EXU.JOBNO = Session["EXPORT_JOBNO"].ToString();
            EXU.Ename = "Delete_Excel";
            EXU.Branch_Code = SELECT_BRANCH;
            d = EXU.Select_Exp_INV();

            if (d.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Not deleted ur Old Invoice");
            }
            else
            {
                //Alert_msg("deleted ur Old Invoice Successfully");
                MP_U.Hide();
                Excel_Upload_load();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    public void Get_ExcelFile()
    {
        try
        {
            DataSet ds = new DataSet();
            DataSet ds_validate = new DataSet();
            DataSet ds_Admin_err = new DataSet();

            string connString = "";
            string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
            string path = errorFolder + "\\" + fileuploadExcel.FileName;

            string strGID;
            string picExtension;
            string fileName2;

            if (fileuploadExcel.HasFile)
            {
                picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
                fileName2 = fileuploadExcel.FileName;
                addtoGallery1(fileName2, errorFolder, "NORMAL");
            }

            //Connection String to Excel Workbook
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsm")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }

            OleDbConnection conn = new OleDbConnection(connString);
            DataTable dtt = new DataTable();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            //to check correct sheetname avail - Sheet1$
            var query1 = from t in dtSchema.AsEnumerable()
                         where t.Field<string>("TABLE_NAME").Equals("Data$")
                         select t;

            int sheet_name = query1.Count();

            if (sheet_name > 0)
            {
                if (dtSchema.Rows.Count <= 3)
                {
                    String firstSheetName = dtSchema.Rows[0].Field<string>("TABLE_NAME");
                    string query = string.Format("SELECT * FROM [{0}]", firstSheetName);
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dtt);

                    da.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
                else
                {
                    string query = "SELECT * FROM [Sheet1$]";

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dtt);

                    da.Dispose();
                    conn.Close();
                    conn.Dispose();
                }

                DataTable filteredRows =
         dtt.Rows.Cast<DataRow>()
             .Where(row => row.ItemArray.Any(field =>
                 field != null &&
                 field != DBNull.Value &&
                 field.ToString().Trim() != ""
             ))
             .CopyToDataTable();

                DataSet dss = new DataSet();
                dss.Tables.Add(filteredRows);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ViewState["ds_Excel_upload"] = dss;
                }

                //-----------  Trim All rows and Columns in Datatable--------------------
                var updatedRows = filteredRows.AsEnumerable().Select(row =>
                {
                    // Create a new row with trimmed values
                    var updatedRow = filteredRows.NewRow();

                    // Trim each column in the row if it's a string
                    updatedRow.ItemArray = row.ItemArray.Select(item =>
                    {
                        // If the item is a string, trim it
                        return item is string ? ((string)item).Trim() : item;
                    }).ToArray();

                    return updatedRow;
                }).ToList();

                // Replace the old rows with the updated ones
                for (int i = 0; i < filteredRows.Rows.Count; i++)
                {
                    filteredRows.Rows[i].ItemArray = updatedRows[i].ItemArray;
                }
                //----------------------------------------------------------------------------


                //------Admin Master Validation-----------------------------------------------

                System.Data.DataView view = new System.Data.DataView(dss.Tables[0]);

                // Step 1: Create original table
                System.Data.DataTable original = view.ToTable("Selected", true,
                    "INVOICE_SLNO", "ITEM_SLNO", "SERIAL_NO", "BE_SITE", "BE_NO",
                    "BE_DATE", "BE_INVOICE_NO", "BE_ITEM");

                // Step 2: Clone structure
                System.Data.DataTable selected_Item_RE_Export = original.Clone();

                // Change BE_DATE type to string
                selected_Item_RE_Export.Columns["BE_DATE"].DataType = typeof(string);

                // Step 3: Import rows and convert date format
                foreach (DataRow row in original.Rows)
                {
                    DataRow newRow = selected_Item_RE_Export.NewRow();
                    newRow.ItemArray = row.ItemArray.Clone() as object[];

                    DateTime dt;
                    if (DateTime.TryParse(row["BE_DATE"] + "", out dt))
                        newRow["BE_DATE"] = dt.ToString("dd/MM/yyyy");
                    else
                        newRow["BE_DATE"] = "";

                    selected_Item_RE_Export.Rows.Add(newRow);
                }



                btnupload.Visible = true;

                gv_Item_Details.DataSource = selected_Item_RE_Export;
                gv_Item_Details.DataBind();



            }
            else
            {

                Alert_msg("Incorrect SheetName");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }




    public void Excel_Upload_load()
    {
        try
        {

            DataTable dt1 = new DataTable();

            ds = (DataSet)ViewState["ds_Excel_upload"];

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataView view = new DataView(ds.Tables[0]);
                System.Data.DataTable distinctValues = view.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "SERIAL_NO", "BE_SITE", "BE_NO", "BE_DATE", "BE_INVOICE_NO"
                , "BE_ITEM", "MANUAL_BE", "BE_QUANTITY_UTILISED", "BE_ITEM_DESC"
                , "BE_QTY", "BE_UQC", "BE_ASS_VAL_RS", "BE_DUTY_PAID", "DUTY_PAYMENT_DATE", "BE_OTH_IDENT_PAR", "BE_ASS_VALUE_CLAIM", "BE_ITEM_USED"
                , "COMMISIONER_PERM", "INPUT_CREDIT", "PERSONAL_USED", "MODVAT_AVAILED", "MODVAT_REPAIRED");


                System.Data.DataTable Item_RE_Export = distinctValues.Clone();
                // Change BE_DATE type to string
                Item_RE_Export.Columns["BE_DATE"].DataType = typeof(string);
                Item_RE_Export.Columns["DUTY_PAYMENT_DATE"].DataType = typeof(string);

                // Step 3: Import rows and convert date format
                foreach (DataRow row in distinctValues.Rows)
                {
                    DataRow newRow = Item_RE_Export.NewRow();
                    newRow.ItemArray = row.ItemArray.Clone() as object[];

                    DateTime dt;
                    if (DateTime.TryParse(row["BE_DATE"] + "", out dt))
                        newRow["BE_DATE"] = dt.ToString("dd/MM/yyyy");
                    else
                        newRow["BE_DATE"] = "";

                    DateTime dtt;
                    if (DateTime.TryParse(row["DUTY_PAYMENT_DATE"] + "", out dtt))
                        newRow["DUTY_PAYMENT_DATE"] = dtt.ToString("dd/MM/yyyy");
                    else
                        newRow["DUTY_PAYMENT_DATE"] = "";

                    Item_RE_Export.Rows.Add(newRow);
                }
                xml_Data_ExpREItem = Common_CS.ConvertDataTableToXML(Item_RE_Export);
            }





            EXU.JOBNO = EXPORT_JOBNO;
            EXU.USER_ID = currentuser;
            EXU.Branch_Code = currentbranch;
            EXU.WORKING_PERIOD = Working_Period;


            EXPORT_JOBDATE = Convert.ToDateTime(Convert.ToDateTime(EXPORT_JOBDATE).ToShortDateString()).ToString(@"MM/dd/yyyy");
            EXU.Bulk_Item_RE_Export_Excel_Upload_(xml_Data_ExpREItem, EXPORT_JOBDATE, "BULK_ITEM_UPLOAD");

            int i = EXU.result;

            if (EXU.result == 1)
            {
                Alert_msg("Excel Uploaded Successfully.");
            }
            else
            {
                Alert_msg("Excel Upload occured some problem");
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
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

            if (Excel_Name == "INDEV")
            {
                //fileuploadExcel1.SaveAs(strImagePath);
            }
            else
            {
                fileuploadExcel.SaveAs(strImagePath);
            }

        }
        catch
        {
        }
        finally
        {
        }
    }

    private void Delete_Temp_table()
    {
        try
        {
            selectSQL = "delete from TBL_EXPORT_EXCEL_FORMAT";
            SqlCommand cmd1 = new SqlCommand(selectSQL, adm.Sql_openConnection(Connection.GetConnection()));
            SqlDataReader reader = cmd1.ExecuteReader();
            reader.Close();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

}