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
using BussinessObject;
//using Excel;


public partial class Import_Bulk_product_Master_Upoad : ThemeClass
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

    public int Product_id_Max;


    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt_Avail = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_scheme = new DataSet();
    UserBO ObjUBO = new UserBO();
    Import_XL_Upload IXL = new Import_XL_Upload();


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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'License Master Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'License Master Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public int Get_Product_id_Max()
    {
        DataSet ds1 = new DataSet();
        //int Product_id_Max = 0;

        ObjUBO.Ename = "Auto_ID";
        ds1 = IXL.Import_Pdf_Reader_Product_Master_Bulk_Insert(ObjUBO, ds.Tables[0]);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            Product_id_Max = Convert.ToInt32(ds1.Tables[0].Rows[0]["PRODUCT_IMPORT_ID"].ToString());
        }
        return Product_id_Max;
    }

    public string Get_ExcelFile()
    {
        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        //string path = "C:\\Documents and Settings\\sathis\\Desktop\\" + fileuploadExcel.FileName;
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
            //Maildb.StoreMailContents(ds, email);
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }


    public void Excel_Upload_load(string file_ext)
    {
        DataTable dtnew = new DataTable();
        Get_Product_id_Max();
        DataSet Inv_ds = new DataSet();
        //ds.Tables.Add("Invoice_dt");
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0, b = 0, c = 1;
        ds.Tables[0].Rows.Add();
        if (ds.Tables[0].Rows.Count > a)
        {
            #region create dataset column
            dtnew.Columns.Add("PRODUCT_IMPORT_ID");
            dtnew.Columns.Add("PRODUCT_DESCRIPTION");
             dtnew.Columns.Add("PRODUCT_CODE"); 
             dtnew.Columns.Add("PRODUCT_RITC");
             dtnew.Columns.Add("PRODUCT_CTH");
             dtnew.Columns.Add("PRODUCT_BCD_NOTN");
             dtnew.Columns.Add("PRODUCT_BCD_SLNO");
             dtnew.Columns.Add("PRODUCT_BCD_RATE");
             dtnew.Columns.Add("PRODUCT_BCD_SPL");
             dtnew.Columns.Add("PRODUCT_BCD_UNIT");
             dtnew.Columns.Add("PRODUCT_BCD_SPL_TYPE");
             dtnew.Columns.Add("PRODUCT_ADDL_DUTY_NOTN");
             dtnew.Columns.Add("PRODUCT_ADDL_DUTY_NOTN_SL");
             dtnew.Columns.Add("PRODUCT_EDU_CESS_NOTN");
             dtnew.Columns.Add("PRODUCT_EDU_CESS_NOTN_SL");
             dtnew.Columns.Add("PRODUCT_EDU_CESS_RATE");
             dtnew.Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN");
             dtnew.Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN_SL");
             dtnew.Columns.Add("PRODUCT_SEC_EDU_CESS_RATE");
             dtnew.Columns.Add("PRODUCT_NCD_NOTN");
             dtnew.Columns.Add("PRODUCT_NCD_SLNO");
             dtnew.Columns.Add("PRODUCT_NCD_RATE");
             dtnew.Columns.Add("PRODUCT_NCD_SPL");
             dtnew.Columns.Add("PRODUCT_NCD_UNIT");
             dtnew.Columns.Add("PRODUCT_NCD_SPL_TYPE");
             dtnew.Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN");
             dtnew.Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_SL");
             dtnew.Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_RATE");
             dtnew.Columns.Add("PRODUCT_SAFEGUARD_NOTN");
             dtnew.Columns.Add("PRODUCT_SAFEGUARD_SLNO");
             dtnew.Columns.Add("PRODUCT_SAFEGUARD_RATE");
             dtnew.Columns.Add("PRODUCT_SAFEGUARD_SPL");
             dtnew.Columns.Add("PRODUCT_SAFEGUARD_UNIT");
             dtnew.Columns.Add("PRODUCT_SAFEGUARD_SPL_TYPE");
             dtnew.Columns.Add("PRODUCT_CETH");
             dtnew.Columns.Add("PRODUCT_MRP_YN");
             dtnew.Columns.Add("PRODUCT_MRP_SL_NO");
             dtnew.Columns.Add("PRODUCT_MRP_AMOUNT");
             dtnew.Columns.Add("PRODUCT_MRP_ABT_RATE");
             dtnew.Columns.Add("PRODUCT_CVD_NOTN");
             dtnew.Columns.Add("PRODUCT_CVD_SLNO");
             dtnew.Columns.Add("PRODUCT_CVD_RATE");
             dtnew.Columns.Add("PRODUCT_CVD_SPL");
             dtnew.Columns.Add("PRODUCT_CVD_UNIT");
             dtnew.Columns.Add("PRODUCT_CVD_SPL_TYPE");
             dtnew.Columns.Add("PRODUCT_CVD_EDU_CESS_RATE");
             dtnew.Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_RATE");
             dtnew.Columns.Add("PRODUCT_ADDL5_SIA_NOTN");
             dtnew.Columns.Add("PRODUCT_ADDL5_SIA_NOTN_SL");
             dtnew.Columns.Add("PRODUCT_ADDL5_SIA_RATE");
             dtnew.Columns.Add("PRODUCT_ADDL_GSI_NOTN");
             dtnew.Columns.Add("PRODUCT_ADDL_GSI_SLNO");
             dtnew.Columns.Add("PRODUCT_ADDL_GSI_RATE");
             dtnew.Columns.Add("PRODUCT_ADDL_GSI_SPL");
             dtnew.Columns.Add("PRODUCT_ADDL_GSI_UNIT");
             dtnew.Columns.Add("PRODUCT_ADDL_GSI_SPL_TYPE");
             dtnew.Columns.Add("PRODUCT_ADDL_SHEII_NOTN");
             dtnew.Columns.Add("PRODUCT_ADDL_SHEII_SLNO");
             dtnew.Columns.Add("PRODUCT_ADDL_SHEII_RATE");
             dtnew.Columns.Add("PRODUCT_ADDL_SHEII_SPL");
             dtnew.Columns.Add("PRODUCT_ADDL_SHEII_UNIT");
             dtnew.Columns.Add("PRODUCT_ADDL_SHEII_TYPE");
             dtnew.Columns.Add("PRODUCT_ADDL_TTA_NOTN");
             dtnew.Columns.Add("PRODUCT_ADDL_TTA_SLNO");
             dtnew.Columns.Add("PRODUCT_ADDL_TTA_RATE");
             dtnew.Columns.Add("PRODUCT_ADDL_TTA_SPL");
             dtnew.Columns.Add("PRODUCT_ADDL_TTA_UNIT");
             dtnew.Columns.Add("PRODUCT_ADDL_TTA_TYPE");
             dtnew.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_NOTN");
             dtnew.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SLNO");
             dtnew.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_RATE");
             dtnew.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SPL");
             dtnew.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_UNIT");
             dtnew.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_TYPE");
             dtnew.Columns.Add("PRODUCT_CESS_NOTN");
             dtnew.Columns.Add("PRODUCT_CESS_SLNO");
             dtnew.Columns.Add("PRODUCT_CESS_RATE");
             dtnew.Columns.Add("PRODUCT_CESS_SPL");
             dtnew.Columns.Add("PRODUCT_CESS_UNIT");
             dtnew.Columns.Add("PRODUCT_CESS_TYPE");
             dtnew.Columns.Add("PRODUCT_GENERAL_DESC");
             dtnew.Columns.Add("PRODUCT_MANUFACTURER");
             dtnew.Columns.Add("PRODUCT_BRAND");
             dtnew.Columns.Add("PRODUCT_MODEL");
             dtnew.Columns.Add("PRODUCT_END_USE");
             dtnew.Columns.Add("PRODUCT_COUNTRY_ORIGIN");
             dtnew.Columns.Add("PRODUCT_ACCESSORIES");
             dtnew.Columns.Add("PRODUCT_REMARKS");
             dtnew.Columns.Add("PRODUCT_USER_ID");
             dtnew.Columns.Add("PRODUCT_DATE_TIME");
             dtnew.Columns.Add("PRODUCT_STATUS");
             dtnew.Columns.Add("PRODUCT_BRANCH_CODE");
             dtnew.Columns.Add("PRODUCT_YEAR");
             dtnew.Columns.Add("PRODUCT_WORKING_PERIOD");
             dtnew.Columns.Add("PRODUCT_SAPTA_NOTN");
             dtnew.Columns.Add("PRODUCT_SAPTA_SLNO");
             dtnew.Columns.Add("PRODUCT_SAPTA_RATE");
             dtnew.Columns.Add("PRODUCT_TARIFF_NOTN");
             dtnew.Columns.Add("PRODUCT_TARIFF_SLNO");
             dtnew.Columns.Add("PRODUCT_TARIFF_QTY");
             dtnew.Columns.Add("PRODUCT_TARIFF_AMOUNT");
             dtnew.Columns.Add("PRODUCT_TARIFF_AMOUNT_UNIT");
             dtnew.Columns.Add("PRODUCT_RSP_NOTN_NO");
             dtnew.Columns.Add("PRODUCT_RSP_NOTN_SL_NO");
             dtnew.Columns.Add("PRODUCT_CVD_EDU_CESS_NOTN");
             dtnew.Columns.Add("PRODUCT_CVD_EDU_CESS_NOTN_SL");
             dtnew.Columns.Add("PRODUCT_CETH_EDU_CESS_RATE");
             dtnew.Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_NOTN");
             dtnew.Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL");
             dtnew.Columns.Add("PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE");
             dtnew.Columns.Add("PARTNO");
             dtnew.Columns.Add("PRODUCT_CTH_INFRA_CESS_NOTN");
             dtnew.Columns.Add("PRODUCT_CTH_INFRA_CESS_NOTN_SLNO");
             dtnew.Columns.Add("PRODUCT_CTH_INFRA_CESS_RATE");
             dtnew.Columns.Add("PRODUCT_ADDL_DUTY_RATE");
             dtnew.Columns.Add("CENTRAL_EXCISE_FLAG");
             dtnew.Columns.Add("MANUFACTURER_PRODUCER");
             dtnew.Columns.Add("M_P_GROWER_CODE");
             dtnew.Columns.Add("M_P_GROWER_ADD1");
             dtnew.Columns.Add("M_P_GROWER_ADD2");
             dtnew.Columns.Add("M_P_GROWER_CITY");
             dtnew.Columns.Add("M_P_GROWER_COUNTRY_SUBDIV");
             dtnew.Columns.Add("M_P_GROWER_PIN");
             dtnew.Columns.Add("M_P_GROWER_COUNTRY");
             dtnew.Columns.Add("SOURCE_COUNTRY");
             dtnew.Columns.Add("TRANSIT_COUNTRY");
             dtnew.Columns.Add("ACCESSORY_STATUS");
             dtnew.Columns.Add("IGST_LEVY_NOTN");
             dtnew.Columns.Add("IGST_LEVY_SLNO");
             dtnew.Columns.Add("IGST_LEVY_RATE");
             dtnew.Columns.Add("IGST_LEVY_SPL");
             dtnew.Columns.Add("IGST_LEVY_UNIT");
             dtnew.Columns.Add("IGST_LEVY_SPL_TYPE");
             dtnew.Columns.Add("IGST_LEVY_EXCEPTION_NOTN");
             dtnew.Columns.Add("IGST_LEVY_EXCEPTION_SLNO");
             dtnew.Columns.Add("IGST_LEVY_EXCEPTION_RATE");
             dtnew.Columns.Add("IGST_LEVY_COMPENSATION_CESS_NOTN");
             dtnew.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SLNO");
             dtnew.Columns.Add("IGST_LEVY_COMPENSATION_CESS_RATE");
             dtnew.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SPL");
             dtnew.Columns.Add("IGST_LEVY_COMPENSATION_CESS_UNIT");
             dtnew.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SPL_TYPE");
             dtnew.Columns.Add("IGST_LEVY_EXCEPTION_CC_NOTN");
             dtnew.Columns.Add("IGST_LEVY_EXCEPTION_CC_SLNO");
             dtnew.Columns.Add("IGST_LEVY_EXCEPTION_CC_RATE");
             dtnew.Columns.Add("LEVY_EXCEMPTION_NOTN_TYPE");
             dtnew.Columns.Add("LEVY_EXCEPTION_CC_NOTN_TYPE");
             dtnew.Columns.Add("SOCIAL_WELFARE_NOTN");
             dtnew.Columns.Add("SOCIAL_WELFARE_NOTN_SLNO");
             dtnew.Columns.Add("SOCIAL_WELFARE_RATE");
             dtnew.Columns.Add("AIDC_NOTN");
             dtnew.Columns.Add("AIDC_NOTN_SLNO");
             dtnew.Columns.Add("AIDC_RATE");
             dtnew.Columns.Add("ANTI_DUMPING_NOTN");
             dtnew.Columns.Add("ANTI_DUMPING_NOTN_SLNO");
             dtnew.Columns.Add("CTH_SLNO");
             dtnew.Columns.Add("CTH_SUPPLIER_SLNO");
             dtnew.Columns.Add("CTH_QTY");
             dtnew.Columns.Add("PRODUCT_IMP_EXP_NAME");
             dtnew.Columns.Add("PRODUCT_IMP_EXP_IECNO");
             dtnew.Columns.Add("PRODUCT_IMP_EXP_BRSLNO");
             dtnew.Columns.Add("PRODUCT_ITEM_QTY_CODE");
             dtnew.Columns.Add("PRODUCT_OTHER_DUTY_NOTN");
             dtnew.Columns.Add("PRODUCT_OTHER_DUTY_SLNO");
             dtnew.Columns.Add("PRODUCT_OTHER_DUTY_RATE");
             dtnew.Columns.Add("PRODUCT_OTHER_DUTY_SPL");
             dtnew.Columns.Add("PRODUCT_OTHER_DUTY_UNIT");
             dtnew.Columns.Add("PRODUCT_OTHER_DUTY_TYPE");
             dtnew.Columns.Add("PRODUCT_INFO_MSR");
             dtnew.Columns.Add("PRODUCT_INFO_UQC");

            #endregion
            //--------------------End pdf reader product details--------------------------//
            if (file_ext == ".xls" || file_ext == ".xlsx")
            {
                #region read Excel_Format

                while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                {

                   // DataRow dr =  dtnew..NewRow();
                    DataRow dr = dtnew.NewRow();

                                    dr["PRODUCT_IMPORT_ID"] = Product_id_Max;
                                    dr["PRODUCT_DESCRIPTION"] = ds.Tables[0].Rows[a][4].ToString();
                                    dr["PRODUCT_CODE"] = ds.Tables[0].Rows[a][5].ToString();
                                    dr["PRODUCT_RITC"] = ds.Tables[0].Rows[a][6].ToString();
                                    dr["PRODUCT_CTH"] = ds.Tables[0].Rows[a][7].ToString();
                                    dr["PRODUCT_BCD_NOTN"] = ds.Tables[0].Rows[a][9].ToString();
                                    dr["PRODUCT_BCD_SLNO"] = ds.Tables[0].Rows[a][10].ToString();
                                    dr["PRODUCT_BCD_RATE"] = "";
                                    dr["PRODUCT_BCD_SPL"] = "";
                                    dr["PRODUCT_BCD_UNIT"] = "";
                                    dr["PRODUCT_BCD_SPL_TYPE"] = "";
                                    dr["PRODUCT_ADDL_DUTY_NOTN"] = ds.Tables[0].Rows[a][11].ToString();
                                    dr["PRODUCT_ADDL_DUTY_NOTN_SL"] = ds.Tables[0].Rows[a][12].ToString();
                                    dr["PRODUCT_EDU_CESS_NOTN"] = ds.Tables[0].Rows[a][13].ToString();
                                    dr["PRODUCT_EDU_CESS_NOTN_SL"] = ds.Tables[0].Rows[a][14].ToString();
                                    dr["PRODUCT_EDU_CESS_RATE"] = "";
                                    dr["PRODUCT_SEC_EDU_CESS_NOTN"] = ds.Tables[0].Rows[a][15].ToString();
                                    dr["PRODUCT_SEC_EDU_CESS_NOTN_SL"] = ds.Tables[0].Rows[a][16].ToString();
                                    dr["PRODUCT_SEC_EDU_CESS_RATE"] = "";
                                    dr["PRODUCT_NCD_NOTN"] = ds.Tables[0].Rows[a][17].ToString();
                                    dr["PRODUCT_NCD_SLNO"] = ds.Tables[0].Rows[a][18].ToString();
                                    dr["PRODUCT_NCD_RATE"] = "";
                                    dr["PRODUCT_NCD_SPL"] = "";
                                    dr["PRODUCT_NCD_UNIT"] = "";
                                    dr["PRODUCT_NCD_SPL_TYPE"] = "";
                                    dr["PRODUCT_AGGREGATE_DUTY_NOTN"] = ds.Tables[0].Rows[a][19].ToString();
                                    dr["PRODUCT_AGGREGATE_DUTY_NOTN_SL"] = ds.Tables[0].Rows[a][20].ToString();
                                    dr["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = License_id_Max;
                                    dr["PRODUCT_SAFEGUARD_NOTN"] = ds.Tables[0].Rows[a][21].ToString();
                                    dr["PRODUCT_SAFEGUARD_SLNO"] = ds.Tables[0].Rows[a][22].ToString();
                                    dr["PRODUCT_SAFEGUARD_RATE"] = "";
                                    dr["PRODUCT_SAFEGUARD_SPL"] = "";
                                    dr["PRODUCT_SAFEGUARD_UNIT"] = "";
                                    dr["PRODUCT_SAFEGUARD_SPL_TYPE"] = "";
                                    dr["PRODUCT_CETH"] = ds.Tables[0].Rows[a][23].ToString();
                                    dr["PRODUCT_MRP_YN"] = "";
                                    dr["PRODUCT_MRP_SL_NO"] = "";
                                    dr["PRODUCT_MRP_AMOUNT"] = "";
                                    dr["PRODUCT_MRP_ABT_RATE"] = "";
                                    dr["PRODUCT_CVD_NOTN"] = ds.Tables[0].Rows[a][24].ToString();
                                    dr["PRODUCT_CVD_SLNO"] = ds.Tables[0].Rows[a][25].ToString();
                                    dr["PRODUCT_CVD_RATE"] = "";
                                    dr["PRODUCT_CVD_SPL"] = "";
                                    dr["PRODUCT_CVD_UNIT"] = "";
                                    dr["PRODUCT_CVD_SPL_TYPE"] = "";
                                    dr["PRODUCT_CVD_EDU_CESS_RATE"] = "";
                                    dr["PRODUCT_CVD_SEC_EDU_CESS_RATE"] = "";
                                    dr["PRODUCT_ADDL5_SIA_NOTN"] = ds.Tables[0].Rows[a][26].ToString();
                                    dr["PRODUCT_ADDL5_SIA_NOTN_SL"] = ds.Tables[0].Rows[a][27].ToString();
                                    dr["PRODUCT_ADDL5_SIA_RATE"] = "";
                                    dr["PRODUCT_ADDL_GSI_NOTN"] = ds.Tables[0].Rows[a][28].ToString();
                                    dr["PRODUCT_ADDL_GSI_SLNO"] = ds.Tables[0].Rows[a][29].ToString();
                                    dr["PRODUCT_ADDL_GSI_RATE"] = "";
                                    dr["PRODUCT_ADDL_GSI_SPL"] = "";
                                    dr["PRODUCT_ADDL_GSI_UNIT"] = "";
                                    dr["PRODUCT_ADDL_GSI_SPL_TYPE"] = "";
                                    dr["PRODUCT_ADDL_SHEII_NOTN"] = ds.Tables[0].Rows[a][30].ToString();
                                    dr["PRODUCT_ADDL_SHEII_SLNO"] = ds.Tables[0].Rows[a][31].ToString();
                                    dr["PRODUCT_ADDL_SHEII_RATE"] = "";
                                    dr["PRODUCT_ADDL_SHEII_SPL"] = "";
                                    dr["PRODUCT_ADDL_SHEII_UNIT"] = "";
                                    dr["PRODUCT_ADDL_SHEII_TYPE"] = "";
                                    dr["PRODUCT_ADDL_TTA_NOTN"] = ds.Tables[0].Rows[a][32].ToString();
                                    dr["PRODUCT_ADDL_TTA_SLNO"] = ds.Tables[0].Rows[a][33].ToString();
                                    dr["PRODUCT_ADDL_TTA_RATE"] = "";
                                    dr["PRODUCT_ADDL_TTA_SPL"] = "";
                                    dr["PRODUCT_ADDL_TTA_UNIT"] = "";
                                    dr["PRODUCT_ADDL_TTA_TYPE"] = "";
                                    dr["PRODUCT_ADDL_HEALTH_CESS_NOTN"] = ds.Tables[0].Rows[a][34].ToString();
                                    dr["PRODUCT_ADDL_HEALTH_CESS_SLNO"] = ds.Tables[0].Rows[a][35].ToString();
                                    dr["PRODUCT_ADDL_HEALTH_CESS_RATE"] = "";
                                    dr["PRODUCT_ADDL_HEALTH_CESS_SPL"] = "";
                                    dr["PRODUCT_ADDL_HEALTH_CESS_UNIT"] = "";
                                    dr["PRODUCT_ADDL_HEALTH_CESS_TYPE"] = "";
                                    dr["PRODUCT_CESS_NOTN"] = ds.Tables[0].Rows[a][36].ToString();
                                    dr["PRODUCT_CESS_SLNO"] = ds.Tables[0].Rows[a][37].ToString();
                                    dr["PRODUCT_CESS_RATE"] = "";
                                    dr["PRODUCT_CESS_SPL"] = "";
                                    dr["PRODUCT_CESS_UNIT"] = "";
                                    dr["PRODUCT_CESS_TYPE"] = "";
                                    dr["PRODUCT_GENERAL_DESC"] = ds.Tables[0].Rows[a][38].ToString();
                                    dr["PRODUCT_MANUFACTURER"] = ds.Tables[0].Rows[a][39].ToString();
                                    dr["PRODUCT_BRAND"] = ds.Tables[0].Rows[a][40].ToString();
                                    dr["PRODUCT_MODEL"] = ds.Tables[0].Rows[a][41].ToString();
                                    dr["PRODUCT_END_USE"] = ds.Tables[0].Rows[a][42].ToString();
                                    dr["PRODUCT_COUNTRY_ORIGIN"] = ds.Tables[0].Rows[a][43].ToString();
                                    dr["PRODUCT_ACCESSORIES"] = ds.Tables[0].Rows[a][44].ToString();
                                    dr["PRODUCT_REMARKS"] = ds.Tables[0].Rows[a][45].ToString();
                                    dr["PRODUCT_USER_ID"] = currentuser;
                                    dr["PRODUCT_DATE_TIME"] = LoginDate;
                                    dr["PRODUCT_STATUS"] = "N";
                                    dr["PRODUCT_BRANCH_CODE"] = currentbranch;
                                    dr["PRODUCT_YEAR"] = "";
                                    dr["PRODUCT_WORKING_PERIOD"] = Working_Period;
                                    dr["PRODUCT_SAPTA_NOTN"] = ds.Tables[0].Rows[a][46].ToString();
                                    dr["PRODUCT_SAPTA_SLNO"] = ds.Tables[0].Rows[a][47].ToString();
                                    dr["PRODUCT_SAPTA_RATE"] = "";
                                    dr["PRODUCT_TARIFF_NOTN"] = ds.Tables[0].Rows[a][48].ToString();
                                    dr["PRODUCT_TARIFF_SLNO"] = ds.Tables[0].Rows[a][49].ToString();
                                    dr["PRODUCT_TARIFF_QTY"] = ds.Tables[0].Rows[a][50].ToString();
                                    dr["PRODUCT_TARIFF_AMOUNT"] = ds.Tables[0].Rows[a][51].ToString();
                                    dr["PRODUCT_TARIFF_AMOUNT_UNIT"] = ds.Tables[0].Rows[a][52].ToString();
                                    dr["PRODUCT_RSP_NOTN_NO"] = "";
                                    dr["PRODUCT_RSP_NOTN_SL_NO"] = "";
                                    dr["PRODUCT_CVD_EDU_CESS_NOTN"] = "";
                                    dr["PRODUCT_CVD_EDU_CESS_NOTN_SL"] = "";
                                    dr["PRODUCT_CETH_EDU_CESS_RATE"] = "";
                                    dr["PRODUCT_CVD_SEC_EDU_CESS_NOTN"] = "";
                                    dr["PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL"] = "";
                                    dr["PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE"] = "";
                                    dr["PARTNO"] = ds.Tables[0].Rows[a][3].ToString();
                                    dr["PRODUCT_CTH_INFRA_CESS_NOTN"] = ds.Tables[0].Rows[a][53].ToString();
                                    dr["PRODUCT_CTH_INFRA_CESS_NOTN_SLNO"] = ds.Tables[0].Rows[a][54].ToString();
                                    dr["PRODUCT_CTH_INFRA_CESS_RATE"] = "";
                                    dr["PRODUCT_ADDL_DUTY_RATE"] = "";
                                    dr["CENTRAL_EXCISE_FLAG"] = ds.Tables[0].Rows[a][55].ToString();
                                    dr["MANUFACTURER_PRODUCER"] = "";
                                    dr["M_P_GROWER_CODE"] = "";
                                    dr["M_P_GROWER_ADD1"] = ds.Tables[0].Rows[a][56].ToString();
                                    dr["M_P_GROWER_ADD2"] = ds.Tables[0].Rows[a][57].ToString();
                                    dr["M_P_GROWER_CITY"] = ds.Tables[0].Rows[a][58].ToString();
                                    dr["M_P_GROWER_COUNTRY_SUBDIV"] = ds.Tables[0].Rows[a][59].ToString();
                                    dr["M_P_GROWER_PIN"] = ds.Tables[0].Rows[a][60].ToString();
                                    dr["M_P_GROWER_COUNTRY"] = ds.Tables[0].Rows[a][61].ToString();
                                    dr["SOURCE_COUNTRY"] = ds.Tables[0].Rows[a][62].ToString();
                                    dr["TRANSIT_COUNTRY"] = ds.Tables[0].Rows[a][63].ToString();
                                    dr["ACCESSORY_STATUS"] = ds.Tables[0].Rows[a][64].ToString();
                                    dr["IGST_LEVY_NOTN"] = ds.Tables[0].Rows[a][65].ToString();
                                    dr["IGST_LEVY_SLNO"] = ds.Tables[0].Rows[a][66].ToString();
                                    dr["IGST_LEVY_RATE"] = "";
                                    dr["IGST_LEVY_SPL"] = "";
                                    dr["IGST_LEVY_UNIT"] = "";
                                    dr["IGST_LEVY_SPL_TYPE"] = "";
                                    dr["IGST_LEVY_EXCEPTION_NOTN"] = ds.Tables[0].Rows[a][67].ToString();
                                    dr["IGST_LEVY_EXCEPTION_SLNO"] = ds.Tables[0].Rows[a][68].ToString();
                                    dr["IGST_LEVY_EXCEPTION_RATE"] = "";
                                    dr["IGST_LEVY_COMPENSATION_CESS_NOTN"] = ds.Tables[0].Rows[a][69].ToString();
                                    dr["IGST_LEVY_COMPENSATION_CESS_SLNO"] = ds.Tables[0].Rows[a][70].ToString();
                                    dr["IGST_LEVY_COMPENSATION_CESS_RATE"] = "";
                                    dr["IGST_LEVY_COMPENSATION_CESS_SPL"] = "";
                                    dr["IGST_LEVY_COMPENSATION_CESS_UNIT"] = "";
                                    dr["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"] = "";
                                    dr["IGST_LEVY_EXCEPTION_CC_NOTN"] = ds.Tables[0].Rows[a][71].ToString();
                                    dr["IGST_LEVY_EXCEPTION_CC_SLNO"] = ds.Tables[0].Rows[a][72].ToString();
                                    dr["IGST_LEVY_EXCEPTION_CC_RATE"] = "";
                                    dr["LEVY_EXCEMPTION_NOTN_TYPE"] = ds.Tables[0].Rows[a][73].ToString();
                                    dr["LEVY_EXCEPTION_CC_NOTN_TYPE"] = ds.Tables[0].Rows[a][74].ToString();
                                    dr["SOCIAL_WELFARE_NOTN"] = ds.Tables[0].Rows[a][75].ToString();
                                    dr["SOCIAL_WELFARE_NOTN_SLNO"] = ds.Tables[0].Rows[a][76].ToString();
                                    dr["SOCIAL_WELFARE_RATE"] = "";
                                    dr["AIDC_NOTN"] = ds.Tables[0].Rows[a][77].ToString();
                                    dr["AIDC_NOTN_SLNO"] = ds.Tables[0].Rows[a][78].ToString();
                                    dr["AIDC_RATE"] = "";
                                    dr["ANTI_DUMPING_NOTN"] = ds.Tables[0].Rows[a][79].ToString();
                                    dr["ANTI_DUMPING_NOTN_SLNO"] = ds.Tables[0].Rows[a][80].ToString();
                                    dr["CTH_SLNO"] = ds.Tables[0].Rows[a][81].ToString();
                                    dr["CTH_SUPPLIER_SLNO"] = ds.Tables[0].Rows[a][82].ToString();
                                    dr["CTH_QTY"] = ds.Tables[0].Rows[a][83].ToString();
                                    dr["PRODUCT_IMP_EXP_NAME"] = ds.Tables[0].Rows[a][0].ToString();
                                    dr["PRODUCT_IMP_EXP_IECNO"] = ds.Tables[0].Rows[a][1].ToString();
                                    dr["PRODUCT_IMP_EXP_BRSLNO"] = ds.Tables[0].Rows[a][2].ToString();
                                    dr["PRODUCT_ITEM_QTY_CODE"] = ds.Tables[0].Rows[a][8].ToString();
                                    dr["PRODUCT_OTHER_DUTY_NOTN"] = ds.Tables[0].Rows[a][84].ToString();
                                    dr["PRODUCT_OTHER_DUTY_SLNO"] = ds.Tables[0].Rows[a][85].ToString();
                                    dr["PRODUCT_OTHER_DUTY_RATE"] = ds.Tables[0].Rows[a][86].ToString();
                                    dr["PRODUCT_OTHER_DUTY_SPL"] = ds.Tables[0].Rows[a][87].ToString();
                                    dr["PRODUCT_OTHER_DUTY_UNIT"] = ds.Tables[0].Rows[a][88].ToString();
                                    dr["PRODUCT_OTHER_DUTY_TYPE"] = "";
                                    dr["PRODUCT_INFO_MSR"] = ds.Tables[0].Rows[a][89].ToString();
                                    dr["PRODUCT_INFO_UQC"] = ds.Tables[0].Rows[a][90].ToString();


                    // dtnew..Rows.Add(dr);
                                    dtnew.Rows.Add(dr);

                    a++;
                    Product_id_Max = Product_id_Max + 1;
                   
                }
                #endregion

               // dt = dsXML.Tables["IMPORT_MASTER_PDF_READER"];
               

                //if ( dtnew..Rows.Count > 0)
                if (dtnew.Rows.Count > 0)
                {
                    admin.SqlBulk_Upload_Product("PRODUCT_IMPORT_MASTER_PDF_READER", dtnew, Session["currentcomp_db"].ToString());
                }

               
                else
                {
                //    Alert_msg("Excel Upload occured some problem");
                }
            }
        }
    }
    //public void Excel_Upload_load(string file_ext)
    //{
        
    //    DataSet Inv_ds = new DataSet();
    //    DataSet dds = new DataSet();
        
    //    //ds.Tables.Add("Invoice_dt");
    //    Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
    //    int a = 0, b = 0, c = 1;
    //    ds.Tables[0].Rows.Add();
        
    //    if (ds.Tables[0].Rows.Count > a)
    //    {

            
    //        DataColumn workColumn = ds.Tables[0].Columns.Add("PRODUCT_IMPORT_ID", typeof(Int32));
    //        workColumn.SetOrdinal(0);
    //        int K = Get_Product_id_Max();

    //        //--------- delete the empty rows form DataTable
    //        DataTable dtt = ds.Tables[0].Rows
    //             .Cast<DataRow>()
    //             .Where(row => !row.ItemArray.All(f => f is DBNull))
    //             .CopyToDataTable();

    //        //------------ Assign the running id of PRODUCT_IMPORT_ID ----------
    //        dtt.Rows.Cast<DataRow>().ToList().ForEach((row) => { row["PRODUCT_IMPORT_ID"] = K; K++; });

    //        //------------to TrimEnd() for all datatable Rows  ******************
    //        dtt.AsEnumerable().ToList()
    //           .ForEach(row =>
    //           {
    //               var cellList = row.ItemArray.ToList();
    //               row.ItemArray = cellList.Select(x => x.ToString().Trim()).ToArray();
    //           });


    //        ObjUBO.Ename = "Check_Invalid_Length";
    //        DataSet ds_len = IXL.Import_Pdf_Reader_Product_Master_Bulk_Insert(ObjUBO, dtt);

    //        if (ds_len.Tables[0].Rows.Count > 0)
    //        {
    //            string msg = "Data Error - Check Excel" + Environment.NewLine + " ---------------------------------------------------------------" + Environment.NewLine;
    //            for (int j = 0; j <= ds_len.Tables[0].Rows.Count - 1; j++)
    //            {
    //                if (ds_len.Tables[0].Rows[j][0].ToString() != "")
    //                {
    //                    msg += ds_len.Tables[0].Rows[j][0].ToString() + "  " + Environment.NewLine;
    //                }
    //            }
    //            hdinvno.Value = msg;
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);
    //        }
    //        else if (ds_len.Tables[1].Rows.Count > 0)
    //        {
    //           string msg = Environment.NewLine + "Data Already Exists - Check Excel" + Environment.NewLine + " ---------------------------------------------------------------" + Environment.NewLine;

    //            for (int j = 0; j <= ds_len.Tables[1].Rows.Count - 1; j++)
    //            {
    //                msg += " RITC :  " + ds_len.Tables[1].Rows[j][2].ToString() + "  -  DESC : " + ds_len.Tables[1].Rows[j][0].ToString() + Environment.NewLine;
    //            }
    //            hdinvno.Value = msg;
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);
    //        }
    //        else if (ds_len.Tables[2].Rows.Count > 0)
    //        {
    //            string msg = Environment.NewLine + "Special Characters Exists - Check Excel" + Environment.NewLine + " ---------------------------------------------------------------" + Environment.NewLine;

    //            for (int j = 0; j <= ds_len.Tables[2].Rows.Count - 1; j++)
    //            {
    //                msg += " FieldName :  " + ds_len.Tables[2].Rows[j][1].ToString() + "  -  Error : " + ds_len.Tables[2].Rows[j][2].ToString() + Environment.NewLine;
    //            }
    //            hdinvno.Value = msg;
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);
    //        }
    //        else
    //        {
    //            ObjUBO.Ename = "Import_Bulk_Insert";
    //            ds = IXL.Import_Pdf_Reader_Product_Master_Bulk_Insert(ObjUBO, dtt);
    //            Alert_msg("Uploaded Successfully..");
    //        }

    //        /*
    //        if (ds_len.Tables[0].Rows.Count == 0)
    //        {
    //            ObjUBO.Ename = "Import_Bulk_Insert";
    //            ds = IXL.Import_Product_Master_Bulk_Insert(ObjUBO, ds.Tables[0]);
    //            Alert_msg("Uploaded Successfully..");
    //        }
    //        else
    //        {
    //            string msg = "Data Error - Check Excel" + Environment.NewLine + " ---------------------------------------------------------------"  + Environment.NewLine;
    //            for (int j = 0; j <= ds_len.Tables[0].Rows.Count - 1; j++)
    //            {
    //                if (ds_len.Tables[0].Rows[j][0].ToString() != "")
    //                {
    //                    msg += ds_len.Tables[0].Rows[j][0].ToString() + "  " + Environment.NewLine;
    //                }
    //            }

    //            if (ds_len.Tables[1].Rows.Count > 0)
    //            {
    //                msg += Environment.NewLine + "Data Already Exists - Check Excel" + Environment.NewLine + " ---------------------------------------------------------------" + Environment.NewLine;

    //                for (int j = 0; j <= ds_len.Tables[1].Rows.Count - 1; j++)
    //                {
    //                    msg += " RITC :  " + ds_len.Tables[1].Rows[j][2].ToString() + "  -  DESC : " + ds_len.Tables[1].Rows[j][0].ToString() + Environment.NewLine;
    //                }
    //            }
    //            if (ds_len.Tables[2].Rows.Count > 0)
    //            {
    //            }
    //            */

    //            //msg = " Inv no : " + dss.Tables[0].Rows[s][38].ToString() + "  -  Already Exists";
    //            //hdinvno.Value = msg;
    //            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);
    //        //}

            
    //    }
    //}

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
