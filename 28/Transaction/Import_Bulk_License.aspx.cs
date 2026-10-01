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
//using System.Web.UI.i
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

using System.Globalization;
//using Excel;


public partial class Import_Bulk_License : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    Transaction Transact = new Transaction();
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
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, IMPORT_JOBNO, code, notification, slno, item_slno, invoice_no;
    public int License_id_Max, License_id_IMP_EXP_Max,ITEM_ID;

    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt_Avail = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_scheme = new DataSet();


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

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "IMPORT_BULK_LICENSE");
     
   
        SELECT_BRANCH = Connection.Get_Company_Type();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "IMPORT_BULK_LICENSE");

        if (Session["IMPORT_JOBNO"] != null)
        {
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();           
        }
        if (!Page.IsPostBack)
        {
            if (Session["IMPORT_JOBNO"] != null)
            {
               
            }
        } 
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Bulk License Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Bulk License Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Get_LICENSE_IMP_EXP_MaxID()
    {
        License_id_Max = 0;
        Transact.LICENSE_ID = "";
        Transact.LICENSE_NO = "0";
        Transact.Ename = "GET_IMPORT_LICENSE_ID_MAX";
        ds = Transact.Import_Bulk_License_Select();
        
        License_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["LICENSE_ID"].ToString());
        
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
        DataSet dtxl = new DataSet();
        Get_LICENSE_IMP_EXP_MaxID();
        DataSet Inv_ds = new DataSet();
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];

        DataView dv = Inv_ds.Tables[0].DefaultView;
        DataTable dat = dv.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO");
        Transact.xmlString = ConvertDataTableToXML(dat);
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.BRANCH_CODE = Connection.Current_Branch();
        Transact.Ename = "validate_invoice_item";
        dtxl=Transact.Import_Bulk_License_Select();


        if (dtxl.Tables[0].Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("INVOICE_SLNO");
            dt.Columns.Add("ITEM_SLNO");
            dt.Columns.Add("ERROR_DESCRIPTION");

            int Count = 1;

            foreach (DataRow dr in Inv_ds.Tables[0].Rows)
            {

                string regNo = dr["REGISTRATION NO"].ToString().Trim();
                string regDate = dr["REGISTRATION_DATE"].ToString().Trim();
                string qty = dr["DEBIT_QTY"].ToString().Trim();
                string licNo = dr["LICENSE NO"].ToString().Trim();
                string licDate = dr["LICENSE DATE"].ToString().Trim();
                string amt = dr["DEBIT_CIF_AMT"].ToString().Trim();
                string debitAmt = dr["ENTRY_DEBIT_DUTY"].ToString().Trim();

                if (!Regex.IsMatch(regNo, @"^\d{10}$"))
                {
                    DataRow newdr = dt.NewRow();
                    newdr["ERROR_DESCRIPTION"] = "Registration No must be 10 digits.";
                    newdr["ITEM_SLNO"] = dr["ITEM_SLNO"].ToString();
                    newdr["INVOICE_SLNO"] = dr["INVOICE_SLNO"].ToString();
                    dt.Rows.Add(newdr);
                }

                if (!Regex.IsMatch(regDate, @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$"))
                {
                    DataRow newdr = dt.NewRow();
                    newdr["ERROR_DESCRIPTION"] = "Registration Date must be dd/MM/yyyy.";
                    newdr["ITEM_SLNO"] = dr["ITEM_SLNO"].ToString();
                    newdr["INVOICE_SLNO"] = dr["INVOICE_SLNO"].ToString();
                    dt.Rows.Add(newdr);
                }

                if (!Regex.IsMatch(qty, @"^\d+(\.\d+)?$"))
                {
                    DataRow newdr = dt.NewRow();
                    newdr["ERROR_DESCRIPTION"] = "DEBIT_QTY must contain numbers only.";
                    newdr["ITEM_SLNO"] = dr["ITEM_SLNO"].ToString();
                    newdr["INVOICE_SLNO"] = dr["INVOICE_SLNO"].ToString();
                    dt.Rows.Add(newdr);
                }

                if (!Regex.IsMatch(licNo, @"^\d{10}$"))
                {
                    DataRow newdr = dt.NewRow();
                    newdr["ERROR_DESCRIPTION"] = "License No must be 10 digits.";
                    newdr["ITEM_SLNO"] = dr["ITEM_SLNO"].ToString();
                    newdr["INVOICE_SLNO"] = dr["INVOICE_SLNO"].ToString();
                    dt.Rows.Add(newdr);
                }

                if (!Regex.IsMatch(licDate, @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$"))
                {
                    DataRow newdr = dt.NewRow();
                    newdr["ERROR_DESCRIPTION"] = "License Date must be dd/MM/yyyy.";
                    newdr["ITEM_SLNO"] = dr["ITEM_SLNO"].ToString();
                    newdr["INVOICE_SLNO"] = dr["INVOICE_SLNO"].ToString();
                    dt.Rows.Add(newdr);
                }

                if (!string.IsNullOrWhiteSpace(amt) && !Regex.IsMatch(amt, @"^\d+(\.\d+)?$"))
                {
                    DataRow newdr = dt.NewRow();
                    newdr["ERROR_DESCRIPTION"] = "DEBIT_CIF_AMT must contain numbers only.";
                    newdr["ITEM_SLNO"] = dr["ITEM_SLNO"].ToString();
                    newdr["INVOICE_SLNO"] = dr["INVOICE_SLNO"].ToString();
                    dt.Rows.Add(newdr);
                }

                if (!string.IsNullOrWhiteSpace(debitAmt) && !Regex.IsMatch(debitAmt, @"^\d+(\.\d+)?$"))
                {
                    DataRow newdr = dt.NewRow();
                    newdr["ERROR_DESCRIPTION"] = "ENTRY_DEBIT_DUTY must contain numbers only.";
                    newdr["ITEM_SLNO"] = dr["ITEM_SLNO"].ToString();
                    newdr["INVOICE_SLNO"] = dr["INVOICE_SLNO"].ToString();
                    dt.Rows.Add(newdr);
                }

                Count++;
            }

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "0")
                {
                    Main_Grid.Visible = true;
                    gv_Preview.DataSource = dt;
                    gv_Preview.DataBind();
                    Label12.Text = "Import Bulk License Excel Invalid Errors";
                    return;
                }
            }
            else
            {
                int a = 0, b = 0;// c = 1;
                ds.Tables[0].Rows.Add();
                if (ds.Tables[0].Rows.Count > a)
                {
                    #region create dataset column
                    dsXML.Tables.Add("LICENSE_DETAILS");
                    dsXML.Tables[0].Columns.Add("LICENSE_ID");
                    dsXML.Tables[0].Columns.Add("JOBNO");
                    dsXML.Tables[0].Columns.Add("INVOICE_SLNO");
                    dsXML.Tables[0].Columns.Add("ITEM_SLNO");
                    dsXML.Tables[0].Columns.Add("SCHEME_CODE");
                    dsXML.Tables[0].Columns.Add("LICENSE_SLNO");
                    dsXML.Tables[0].Columns.Add("REGISTRATION_NO");
                    dsXML.Tables[0].Columns.Add("REGISTRATION_DATE");
                    dsXML.Tables[0].Columns.Add("EXCEMPTION");
                    dsXML.Tables[0].Columns.Add("DEBIT_CIF_AMT");
                    dsXML.Tables[0].Columns.Add("DEBIT_QTY");
                    dsXML.Tables[0].Columns.Add("UNIT_QTY");
                    dsXML.Tables[0].Columns.Add("LICENSE_ITEM_NO");
                    dsXML.Tables[0].Columns.Add("PORT_OF_LICENSE");
                    dsXML.Tables[0].Columns.Add("USER_ID");
                    dsXML.Tables[0].Columns.Add("DATE_TIME");
                    dsXML.Tables[0].Columns.Add("STATUS");
                    dsXML.Tables[0].Columns.Add("BRANCH_CODE");
                    dsXML.Tables[0].Columns.Add("YEAR");
                    dsXML.Tables[0].Columns.Add("WORKING_PERIOD");
                    dsXML.Tables[0].Columns.Add("DEBIT_DUTY");
                    dsXML.Tables[0].Columns.Add("LICENSE_NO");
                    dsXML.Tables[0].Columns.Add("LICENSE_DATE");
                    dsXML.Tables[0].Columns.Add("MODIFIEDBY");
                    dsXML.Tables[0].Columns.Add("MODIFIEDON");
                    dsXML.Tables[0].Columns.Add("TOTAL_CIF_VALUE");
                    dsXML.Tables[0].Columns.Add("TOTAL_DEBIT_DUTY");
                    dsXML.Tables[0].Columns.Add("ENTRY_DEBIT_DUTY");
                    dsXML.Tables[0].Columns.Add("LIC_DESC");
                    dsXML.Tables[0].Columns.Add("LICENSE_CURRENCY");
                    dsXML.Tables[0].Columns.Add("EX_RATE");
                    //-------------------------ITEM PRODUCT DETAILS---------------------------------//


                    code = ds.Tables[0].Rows[0][4].ToString();
                    notification = ds.Tables[0].Rows[0][5].ToString();
                    slno = ds.Tables[0].Rows[0][6].ToString();
                    item_slno = ds.Tables[0].Rows[0][0].ToString();
                    invoice_no = ds.Tables[0].Rows[0][1].ToString();

                    dsXML.Tables.Add("ITEM_PRODUCT_DETAILS");
                    dsXML.Tables[1].Columns.Add("ITEM_ID");
                    dsXML.Tables[1].Columns.Add("JOBNO");
                    dsXML.Tables[1].Columns.Add("INVOICE_SLNO");
                    dsXML.Tables[1].Columns.Add("ITEM_SLNO");
                    dsXML.Tables[1].Columns.Add("SCHEME_CODE");
                    dsXML.Tables[1].Columns.Add("SCHEME_NOTN");
                    dsXML.Tables[1].Columns.Add("SCHEME_NOTN_SLNO");
                    dsXML.Tables[1].Columns.Add("USER_ID");
                    dsXML.Tables[1].Columns.Add("DATE_TIME");
                    dsXML.Tables[1].Columns.Add("STATUS");
                    dsXML.Tables[1].Columns.Add("BRANCH_CODE");
                    dsXML.Tables[1].Columns.Add("YEAR");
                    dsXML.Tables[1].Columns.Add("WORKING_PERIOD");
                    dsXML.Tables[1].Columns.Add("MODIFIEDBY");
                    dsXML.Tables[1].Columns.Add("MODIFIEDON");

                    #endregion
                    //--------------------End License Details--------------------------//
                    if (file_ext == ".xls" || file_ext == ".xlsx")
                    {
                        #region read Excel_Format


                        int ii = 1;
                        while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                        {


                            DataRow dr = dsXML.Tables[0].NewRow();

                            dr["LICENSE_ID"] = License_id_Max;
                            dr["JOBNO"] = IMPORT_JOBNO;
                            dr["INVOICE_SLNO"] = ds.Tables[0].Rows[a][0].ToString();
                            dr["ITEM_SLNO"] = ds.Tables[0].Rows[a][1].ToString().TrimEnd();
                            dr["EXCEMPTION"] = "Y";
                            dr["REGISTRATION_NO"] = ds.Tables[0].Rows[a][2].ToString().TrimEnd();
                            //dr["REGISTRATION_DATE"] = Convert.ToDateTime(ds.Tables[0].Rows[a][3].ToString().TrimEnd()); 
                            dr["REGISTRATION_DATE"] = ds.Tables[0].Rows[a][3].ToString().TrimEnd();
                            dr["SCHEME_CODE"] = ds.Tables[0].Rows[a][4].ToString().TrimEnd();
                            dr["LICENSE_ITEM_NO"] = ds.Tables[0].Rows[a][7].ToString();
                            dr["LICENSE_SLNO"] = ii;
                            dr["DEBIT_QTY"] = ds.Tables[0].Rows[a][8].ToString();
                            dr["UNIT_QTY"] = ds.Tables[0].Rows[a][9].ToString();
                            dr["PORT_OF_LICENSE"] = ds.Tables[0].Rows[a][10].ToString();
                            dr["LIC_DESC"] = ds.Tables[0].Rows[a][11].ToString();
                            dr["LICENSE_NO"] = ds.Tables[0].Rows[a][12].ToString().TrimEnd();
                            // dr["LICENSE_DATE"] =Convert.ToDateTime( ds.Tables[0].Rows[a][13].ToString().TrimEnd());
                            dr["LICENSE_DATE"] = ds.Tables[0].Rows[a][13].ToString().TrimEnd();

                            //dr["TOTAL_CIF_VALUE"] ="";
                            dr["DEBIT_CIF_AMT"] = ds.Tables[0].Rows[a][14].ToString().TrimEnd();
                            //dr["TOTAL_DEBIT_DUTY"] = "";
                            dr["ENTRY_DEBIT_DUTY"] = ds.Tables[0].Rows[a][15].ToString().TrimEnd();

                            dr["USER_ID"] = currentuser;
                            dr["DATE_TIME"] = LoginDate;
                            dr["STATUS"] = "N";
                            dr["BRANCH_CODE"] = currentbranch;
                            dr["YEAR"] = "";
                            dr["WORKING_PERIOD"] = Working_Period;
                            dr["MODIFIEDBY"] = currentuser;
                            dr["MODIFIEDON"] = LoginDate;

                            a++;
                            License_id_Max++;
                            dsXML.Tables[0].Rows.Add(dr);
                        }

                        while (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
                        {
                            //while (ds.Tables[0].Rows.Count > b)
                            //{
                            DataRow dr1 = dsXML.Tables[1].NewRow();
                            dr1["JOBNO"] = IMPORT_JOBNO;
                            dr1["ITEM_ID"] = ITEM_ID;
                            dr1["INVOICE_SLNO"] = ds.Tables[0].Rows[b][0].ToString();
                            dr1["ITEM_SLNO"] = ds.Tables[0].Rows[b][1].ToString().TrimEnd();
                            dr1["SCHEME_CODE"] = ds.Tables[0].Rows[b][4].ToString();
                            dr1["SCHEME_NOTN"] = ds.Tables[0].Rows[b][5].ToString();
                            dr1["SCHEME_NOTN_SLNO"] = ds.Tables[0].Rows[b][6].ToString();
                            dr1["USER_ID"] = currentuser;
                            dr1["DATE_TIME"] = LoginDate;
                            dr1["STATUS"] = "N";
                            dr1["BRANCH_CODE"] = currentbranch;
                            dr1["YEAR"] = "";
                            dr1["WORKING_PERIOD"] = Working_Period;
                            dr1["MODIFIEDBY"] = currentuser;
                            dr1["MODIFIEDON"] = LoginDate;

                            b++;
                            ITEM_ID++;
                            dsXML.Tables[1].Rows.Add(dr1);


                        }

                        #endregion


                        dt = dsXML.Tables["LICENSE_DETAILS"];
                        if (dsXML.Tables[0].Rows.Count > 0)
                        {

                            Transact.JOBNO = IMPORT_JOBNO;
                            Transact.INVOICE_SLNO = invoice_no;
                            Transact.ITEM_SLNO = item_slno;
                            Transact.BRANCH_CODE = Connection.Current_Branch();
                            Transact.Ename = "License_details_delete";


                            ds = Transact.Import_Bulk_License_Select();

                            admin.SqlBulk_Upload_Product("LICENSE_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());

                        }

                        if (dsXML.Tables[1].Rows.Count > 0)
                        {
                            Transact.JOBNO = IMPORT_JOBNO;
                            Transact.xmlString = ConvertDataTableToXML(dsXML.Tables[1]);
                            Transact.INVOICE_SLNO = invoice_no;

                            Transact.ITEM_SLNO = item_slno;
                            Transact.SCHEME_NOTN = notification;
                            Transact.SCHEME_CODE = code;
                            Transact.SCHEME_NOTN_SLNO = slno;
                            Transact.BRANCH_CODE = Connection.Current_Branch();
                            Transact.Ename = "Update_item_details";


                            dsXML = Transact.Import_Bulk_License_Select();

                            //  admin.SqlBulk_Upload_Product("ITEM_PRODUCT_DETAILS", dsXML.Tables[1], Session["currentcomp_db"].ToString());



                        }

                        Alert_msg("Uploaded Successfully..");

                    }
                    else
                    {
                        Alert_msg("license sl number mismatch");
                    }
                }
            }
        }
        else
        {
            if (dtxl.Tables[0].Rows.Count > 0)
            {
               
                    Main_Grid.Visible = true;
                    gv_Preview.DataSource = dtxl;
                    gv_Preview.DataBind();
                    Label12.Text = "Import Bulk License Excel mismatched entries for Job No: " + IMPORT_JOBNO;
                    return;
                
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

    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ForeColor = System.Drawing.Color.Black;
            e.Row.BackColor = System.Drawing.Color.White;

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
