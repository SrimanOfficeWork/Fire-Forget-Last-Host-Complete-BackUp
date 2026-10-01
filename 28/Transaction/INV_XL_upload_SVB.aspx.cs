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


public partial class INV_XL_upload_SVB : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();
    Transaction Transact = new Transaction();
    DataTable dt = new DataTable();
    public int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, IMPORT_JOBNO;
    public string inv_no = "";
   
    double cal, cal1, invoicevalue;
   
    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();

    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    DataSet ds3 = new DataSet();
    DataSet ds4 = new DataSet();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_invoice = new DataSet();
    DataSet ds_scheme = new DataSet();
   

    public string errorFolder = "", logline = "", logFileName = "";
    public int licen_slno = 0;

    public string Invno;
    public string Invdt;
    public string INS_TERMS, FOB_TERMS, CHINA_INV_CURRENCY, ITEM_QTYCODE, ITEM_UNITCODE, INVSLNO, COUNTRYORIGIN, IsInvoiceno = "";
    public string Ins_amt;
    public decimal item_amt;
    public string scheme;
    public int INVCOUNT;
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Import_Excel");
        
    // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
        
  * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Import_Excel");

        if (Session["IMPORT_JOBNO"] != null)
        {

            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            //load_invno();
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Nippon Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Nippon Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
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

    protected void btnImportInvUpload_SVB_Click(object sender, EventArgs e)
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
        DataSet Inv_ds = new DataSet();
        //ds.Tables.Add("Invoice_dt");
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0, b = 0, c = 0;
        if (ds.Tables[0].Rows.Count > a)
        {
            #region create dataset column
            dsXML.Tables.Add("InvoiceDetails");
            dsXML.Tables[0].Columns.Add("INVOICE_ID");
            dsXML.Tables[0].Columns.Add("JOBNO");
            dsXML.Tables[0].Columns.Add("INVOICE_SLNO");

            dsXML.Tables[0].Columns.Add("INVOICE_NO");
            // dsXML.Tables[0].Columns.Add("INVOICE_DATE", typeof(DateTime));
            dsXML.Tables[0].Columns.Add("INVOICE_DATE");

            dsXML.Tables[0].Columns.Add("TERMS");
            dsXML.Tables[0].Columns.Add("INVOICE_CURRENCY");
            dsXML.Tables[0].Columns.Add("INVOICE_EXRATE");
            dsXML.Tables[0].Columns.Add("INVOICE_VALUE");
            dsXML.Tables[0].Columns.Add("SUPPLIER_NAME");
            dsXML.Tables[0].Columns.Add("SUPPLIER_ADDRESS");
            dsXML.Tables[0].Columns.Add("SUPPLIER_ADDRESS1");
            dsXML.Tables[0].Columns.Add("SUPPLIER_ADDRESS2");
            dsXML.Tables[0].Columns.Add("SUPPLIER_COUNTRY_NAME");
            dsXML.Tables[0].Columns.Add("SUPPLIER_COUNTRY_CODE");
            dsXML.Tables[0].Columns.Add("SUPPLIER_COUNTRY_PINCODE");
            dsXML.Tables[0].Columns.Add("SELLER_NAME");
            dsXML.Tables[0].Columns.Add("SELLER_ADDRESS");
            dsXML.Tables[0].Columns.Add("SELLER_ADDRESS1");
            dsXML.Tables[0].Columns.Add("SELLER_ADDRESS2");
            dsXML.Tables[0].Columns.Add("SELLER_COUNTRY_NAME");
            dsXML.Tables[0].Columns.Add("SELLER_COUNTRY_CODE");
            dsXML.Tables[0].Columns.Add("SELLERCOUNTRY_PINCODE");
            dsXML.Tables[0].Columns.Add("BROKER_NAME");
            dsXML.Tables[0].Columns.Add("BROKER_ADDRESS");
            dsXML.Tables[0].Columns.Add("BROKER_ADDRESS1");
            dsXML.Tables[0].Columns.Add("BROKER_ADDRESS2");
            dsXML.Tables[0].Columns.Add("BROKER_COUNTRY_NAME");
            dsXML.Tables[0].Columns.Add("BROKER_COUNTRY_CODE");
            dsXML.Tables[0].Columns.Add("BROKER_COUNTRY_PINCODE");
            dsXML.Tables[0].Columns.Add("MIS_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_RATE");
            dsXML.Tables[0].Columns.Add("MIS_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_AGENCY_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_AGENCY_RATE");
            dsXML.Tables[0].Columns.Add("MIS_AGENCY_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_AGENCY_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_RATE");
            dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_REASON");
            dsXML.Tables[0].Columns.Add("MIS_LOADING_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_LOADING_RATE");
            dsXML.Tables[0].Columns.Add("MIS_LOADING_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_LOADING_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_FREIGHT_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_FREIGHT_RATE");
            dsXML.Tables[0].Columns.Add("MIS_FREIGHT_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_FREIGHT_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_INSURANCE_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_INSURANCE_RATE");
            dsXML.Tables[0].Columns.Add("MIS_INSURANCE_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_INSURANCE_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_RATE");
            dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_SINGLE_OR_MULITIPLE");
            dsXML.Tables[0].Columns.Add("SVB_RELATION");
            dsXML.Tables[0].Columns.Add("SVB_REF_NO");
            dsXML.Tables[0].Columns.Add("SVB_REF_DATE");//, typeof(DateTime));
            dsXML.Tables[0].Columns.Add("SVB_CUSTOM_HOUSE");
            dsXML.Tables[0].Columns.Add("SVB_LOADING_ON");
            dsXML.Tables[0].Columns.Add("SVB_ASSESABLE_RATE");
            dsXML.Tables[0].Columns.Add("SVB_DUTY_RATE");
            dsXML.Tables[0].Columns.Add("SVB_ASSESABLE_STATUS");
            dsXML.Tables[0].Columns.Add("SVB_DUTY_STATUS");
            dsXML.Tables[0].Columns.Add("OTHER_PURCHASE_ORDER");
            dsXML.Tables[0].Columns.Add("OTHER_PURCHASE_ORDER_DATE");
            dsXML.Tables[0].Columns.Add("OTHER_CONTRACT_NO");
            dsXML.Tables[0].Columns.Add("OTHER_CONTRACT_DATE");//, typeof(DateTime));
            dsXML.Tables[0].Columns.Add("OTHER_LOC_NO");
            dsXML.Tables[0].Columns.Add("OTHER_LOC_DATE");//, typeof(DateTime));
            dsXML.Tables[0].Columns.Add("OTHER_NATURE_OF_TRANSACTION");
            dsXML.Tables[0].Columns.Add("OTHER_TERMS_OF_PAYMENT");
            dsXML.Tables[0].Columns.Add("OTHER_CONDITIONS");
            dsXML.Tables[0].Columns.Add("OTHER_VALUATION_METHOD");

            dsXML.Tables[0].Columns.Add("NON_STD_EFFECT_DT_IMP");
            dsXML.Tables[0].Columns.Add("NON_STD_BANKNAME");
            dsXML.Tables[0].Columns.Add("NON_STD_CERTIFICATE_NO");
            dsXML.Tables[0].Columns.Add("NON_STD_CERTIFICATE_DATE");

            //---------Sudharshan Cargo Fields-----------------//
            dsXML.Tables[0].Columns.Add("SAP_DELIEVERY_ID");
            dsXML.Tables[0].Columns.Add("SHIP_DATE");
            dsXML.Tables[0].Columns.Add("INVOICE_LEVEL");
            dsXML.Tables[0].Columns.Add("COUNTRY_OF_DEPARTURE");

            //--------End Sudharshan Cargo Fields--------------//

            dsXML.Tables[0].Columns.Add("USER_ID");
            dsXML.Tables[0].Columns.Add("DATE_TIME");
            dsXML.Tables[0].Columns.Add("STATUS");
            dsXML.Tables[0].Columns.Add("BRANCH_CODE");
            dsXML.Tables[0].Columns.Add("YEAR");
            dsXML.Tables[0].Columns.Add("WORKING_PERIOD");

            //--------------------Item Details--------------------------//
            dsXML.Tables.Add("ItemDetails");
            dsXML.Tables[1].Columns.Add("ITEM_ID");
            dsXML.Tables[1].Columns.Add("JOBNO");
            dsXML.Tables[1].Columns.Add("INVOICE_SLNO");
            dsXML.Tables[1].Columns.Add("INVOICE_NO");
            dsXML.Tables[1].Columns.Add("ITEM_SLNO");
            dsXML.Tables[1].Columns.Add("ITEM_DESCRIPTION");
            dsXML.Tables[1].Columns.Add("ITEM_QTY");
            dsXML.Tables[1].Columns.Add("ITEM_QTY_CODE");
            dsXML.Tables[1].Columns.Add("ITEM_UNIT_PRICE");
            dsXML.Tables[1].Columns.Add("ITEM_UNIT_CODE");
            dsXML.Tables[1].Columns.Add("ITEM_TOTAL_AMOUNT", typeof(double));
            dsXML.Tables[1].Columns.Add("ITEM_AMOUNT_CODE");
            dsXML.Tables[1].Columns.Add("CTH_NO");
            dsXML.Tables[1].Columns.Add("SCHEME_CODE");
            dsXML.Tables[1].Columns.Add("SCHEME_NOTN");
            dsXML.Tables[1].Columns.Add("SCHEME_NOTN_SLNO");
            dsXML.Tables[1].Columns.Add("CTH_QTY1");
            dsXML.Tables[1].Columns.Add("CTH_QTY1_CODE");
            dsXML.Tables[1].Columns.Add("CTH_QTY2");
            dsXML.Tables[1].Columns.Add("CTH_QTY2_CODE");
            dsXML.Tables[1].Columns.Add("GENEARL_DESCRIPTION");
            dsXML.Tables[1].Columns.Add("MANUFACTURER");
            dsXML.Tables[1].Columns.Add("BRAND");
            dsXML.Tables[1].Columns.Add("MODEL");
            dsXML.Tables[1].Columns.Add("END_USE_OF_ITEM");
            dsXML.Tables[1].Columns.Add("COUNTRY_OF_ORIGIN");
            dsXML.Tables[1].Columns.Add("ACCESSORIES");
            dsXML.Tables[1].Columns.Add("PREVIOUS_BE_NO");
            dsXML.Tables[1].Columns.Add("PREVIOUS_BE_DATE");//, typeof(DateTime));
            dsXML.Tables[1].Columns.Add("UNIT_PRICE");
            dsXML.Tables[1].Columns.Add("UNIT_CODE");
            dsXML.Tables[1].Columns.Add("CUSTOMS_HOUSE");
            dsXML.Tables[1].Columns.Add("PRODUCT_RITC");
            dsXML.Tables[1].Columns.Add("PRODUCT_CTH");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_SPL_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_NOTN_SL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_EDU_CESS_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_EDU_CESS_NOTN_SL");
            dsXML.Tables[1].Columns.Add("PRODUCT_EDU_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN_SL");
            dsXML.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_SPL_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_SL");
            dsXML.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SPL_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAPTA_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAPTA_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAPTA_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_QTY");
            dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_AMOUNT");
            dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_AMOUNT_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_CETH");
            dsXML.Tables[1].Columns.Add("PRODUCT_MRP_YN");
            dsXML.Tables[1].Columns.Add("PRODUCT_MRP_SL_NO");
            dsXML.Tables[1].Columns.Add("PRODUCT_MRP_AMOUNT");
            dsXML.Tables[1].Columns.Add("PRODUCT_MRP_ABT_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SPL_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_EDU_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_NOTN_SL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SPL_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_TYPE");
            dsXML.Tables[1].Columns.Add("ANTI_DUMPING_NOTN");
            dsXML.Tables[1].Columns.Add("ANTI_DUMPING_NOTN_SLNO");
            dsXML.Tables[1].Columns.Add("CTH_SLNO");
            dsXML.Tables[1].Columns.Add("CTH_SUPPLIER_SLNO");
            dsXML.Tables[1].Columns.Add("CTH_QTY");
            dsXML.Tables[1].Columns.Add("RSP_DUTY_STATUS");
            dsXML.Tables[1].Columns.Add("RSP_SL_NO");
            dsXML.Tables[1].Columns.Add("RSP_DESC");
            dsXML.Tables[1].Columns.Add("RSP_QTY");
            dsXML.Tables[1].Columns.Add("RSP_AMOUNT");
            dsXML.Tables[1].Columns.Add("RSP_NOTN_NO");
            dsXML.Tables[1].Columns.Add("RSP_NOTN_SL_NO");
            dsXML.Tables[1].Columns.Add("RSP_ABT_RATE");
            dsXML.Tables[1].Columns.Add("WAREHOUSE_JOBNO");
            dsXML.Tables[1].Columns.Add("WAREHOUSE_INVOICE_SLNO");
            dsXML.Tables[1].Columns.Add("WAREHOUSE_ITEM_SLNO");
            dsXML.Tables[1].Columns.Add("ASSESSABLE_VALUE");
            dsXML.Tables[1].Columns.Add("DUTY_VALUE");
            dsXML.Tables[1].Columns.Add("CIF_VALUE");
            dsXML.Tables[1].Columns.Add("CVD_VALUE");


            dsXML.Tables[1].Columns.Add("USER_ID");
            dsXML.Tables[1].Columns.Add("DATE_TIME");
            dsXML.Tables[1].Columns.Add("STATUS");
            dsXML.Tables[1].Columns.Add("BRANCH_CODE");
            dsXML.Tables[1].Columns.Add("YEAR");
            dsXML.Tables[1].Columns.Add("WORKING_PERIOD");

            //--------------------New Field added on 08Aug2014--------------------------//

            dsXML.Tables[1].Columns.Add("CETH_CVD_EDU_CESS_SL");

            dsXML.Tables[1].Columns.Add("BASIC_VALUE");
            dsXML.Tables[1].Columns.Add("CEC_VALUE");
            dsXML.Tables[1].Columns.Add("CHEC_VALUE");
            dsXML.Tables[1].Columns.Add("ADD_DUTY_VALUE");

            //---------------------------------------------------------------------------------//


            dsXML.Tables[1].Columns.Add("CETH_CVD_EDU_CESS_RATE");
            dsXML.Tables[1].Columns.Add("CETH_CVD_SEC_EDU_CESS_SL");
            dsXML.Tables[1].Columns.Add("CETH_CVD_SEC_EDU_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_OTHER_DUTY_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_OTHER_DUTY_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_OTHER_DUTY_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_OTHER_DUTY_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_OTHER_DUTY_TYPE");
            dsXML.Tables[1].Columns.Add("MODIFIEDBY");
            dsXML.Tables[1].Columns.Add("MODIFIEDON");
            //dsXML.Tables[1].Columns.Add("MODIFIEDON", typeof(DateTime));
            dsXML.Tables[1].Columns.Add("INDIVITUAL_FREIGHT_AMOUNT");
            dsXML.Tables[1].Columns.Add("INDIVITUAL_INSURANCE_AMOUNT");
            dsXML.Tables[1].Columns.Add("INDIVITUAL_MISC_AMOUNT");


            //------------------- SVB DETAILS ADDING IN ITEM DETAILS-----------------------------//
             dsXML.Tables[1].Columns.Add("SVB_RELATION");
            dsXML.Tables[1].Columns.Add("SVB_REF_NO");
            dsXML.Tables[1].Columns.Add("SVB_REF_DATE");
            //dsXML.Tables[1].Columns.Add("SVB_REF_DATE", typeof(DateTime));
            dsXML.Tables[1].Columns.Add("SVB_CUSTOM_HOUSE");
            dsXML.Tables[1].Columns.Add("SVB_LOADING_ON");
            dsXML.Tables[1].Columns.Add("SVB_ASSESABLE_RATE");
            dsXML.Tables[1].Columns.Add("SVB_DUTY_RATE");
            dsXML.Tables[1].Columns.Add("SVB_ASSESABLE_STATUS");
            dsXML.Tables[1].Columns.Add("SVB_DUTY_STATUS");
           
            //---------------------End--------------------------------------------------//

            //--------------------License Details--------------------------//
            dsXML.Tables.Add("LicenseDetails");
            dsXML.Tables[2].Columns.Add("LICENSE_ID");
            dsXML.Tables[2].Columns.Add("JOBNO");
            dsXML.Tables[2].Columns.Add("INVOICE_SLNO");
            dsXML.Tables[2].Columns.Add("ITEM_SLNO");
            dsXML.Tables[2].Columns.Add("SCHEME_CODE");
            dsXML.Tables[2].Columns.Add("LICENSE_SLNO");
            dsXML.Tables[2].Columns.Add("REGISTRATION_NO");
            //dsXML.Tables[2].Columns.Add("REGISTRATION_DATE", typeof(DateTime));
            dsXML.Tables[2].Columns.Add("REGISTRATION_DATE");

            dsXML.Tables[2].Columns.Add("EXCEMPTION");
            dsXML.Tables[2].Columns.Add("DEBIT_AMT");
            dsXML.Tables[2].Columns.Add("DEBIT_QTY");
            dsXML.Tables[2].Columns.Add("UNIT_QTY");
            dsXML.Tables[2].Columns.Add("LICENSE_ITEM_NO");
            dsXML.Tables[2].Columns.Add("PORT_OF_LICENSE");
            dsXML.Tables[2].Columns.Add("USER_ID");
            dsXML.Tables[2].Columns.Add("DATE_TIME");
            dsXML.Tables[2].Columns.Add("STATUS");
            dsXML.Tables[2].Columns.Add("BRANCH_CODE");
            dsXML.Tables[2].Columns.Add("YEAR");
            dsXML.Tables[2].Columns.Add("WORKING_PERIOD");
            #endregion
            //--------------------End License Details--------------------------//
            if (file_ext == ".xls" || file_ext == ".xlsx")
            {
                #region read Excel_Format
                while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                {
                    //while (ds.Tables[0].Rows.Count > a)
                    // {

                    //if (ds.Tables[0].Rows[a][0] != "")
                    //{
                    //dr = ds.Tables[0].NewRow();
                    DataRow dr = dsXML.Tables[0].NewRow();

                    dr["INVOICE_ID"] = "";
                    dr["JOBNO"] = IMPORT_JOBNO;
                    // dr["JOBDATE"] = EXPORT_JOBDATE;
                    //dr["JOBDATE"] = DateTime.Parse(EXPORT_JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    dr["INVOICE_SLNO"] = ds.Tables[0].Rows[a][0].ToString();

                    dr["INVOICE_NO"] = ds.Tables[0].Rows[a][1].ToString().TrimEnd();

                    string inv_date = Convert.ToDateTime(ds.Tables[0].Rows[a][2].ToString()).ToShortDateString();

                    string inv_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(inv_date));
                    dr["INVOICE_DATE"] = Convert.ToDateTime(inv_date).ToString(@"MM/dd/yyyy");

                    dr["TERMS"] = ds.Tables[0].Rows[a][3].ToString();
                    dr["INVOICE_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                    //dr["INVOICE_VALUE"] = "";

                    if (dr["INVOICE_CURRENCY"] != "")
                    {
                        adm.Invoice_Currency = dr["INVOICE_CURRENCY"].ToString(); ;

                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                        adm.EWorking_Period = Working_Period;

                        ds1 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            dr["INVOICE_EXRATE"] = ds1.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                        }
                    }
                    else
                    {
                        dr["INVOICE_EXRATE"] = "";
                    }

                    dr["INVOICE_VALUE"] = "";

                    dr["SUPPLIER_NAME"] = "";
                    dr["SUPPLIER_ADDRESS"] = "";
                    dr["SUPPLIER_ADDRESS1"] = "";
                    dr["SUPPLIER_ADDRESS2"] = "";
                    dr["SUPPLIER_COUNTRY_NAME"] = "";
                    dr["SUPPLIER_COUNTRY_CODE"] = "";
                    dr["SUPPLIER_COUNTRY_PINCODE"] = "";
                    dr["SELLER_NAME"] = "";
                    dr["SELLER_ADDRESS"] = "";
                    dr["SELLER_ADDRESS1"] = "";
                    dr["SELLER_ADDRESS2"] = "";
                    dr["SELLER_COUNTRY_NAME"] = "";
                    dr["SELLER_COUNTRY_CODE"] = "";
                    dr["SELLERCOUNTRY_PINCODE"] = "";
                    dr["BROKER_NAME"] = "";
                    dr["BROKER_ADDRESS"] = "";
                    dr["BROKER_ADDRESS1"] = "";
                    dr["BROKER_ADDRESS2"] = "";
                    dr["BROKER_COUNTRY_NAME"] = "";
                    dr["BROKER_COUNTRY_CODE"] = "";
                    dr["BROKER_COUNTRY_PINCODE"] = "";

                    dr["MIS_CHARGES"] = ds.Tables[0].Rows[a][14].ToString();
                    dr["MIS_RATE"] = "";
                    dr["MIS_CURRENCY"] = ds.Tables[0].Rows[a][15].ToString();

                    if (dr["INVOICE_CURRENCY"] == dr["MIS_CURRENCY"])
                    {
                        dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                    }
                    else
                    {

                        if (dr["MIS_CURRENCY"] != "")
                        {
                            adm.Invoice_Currency = dr["MIS_CURRENCY"].ToString(); ;

                            adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            adm.EWorking_Period = Working_Period;

                            ds2 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                dr["MIS_EXRATE"] = ds2.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                            }
                        }
                        else
                        {
                            dr["MIS_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                        }
                    }

                    dr["MIS_AGENCY_CHARGES"] = "";
                    dr["MIS_AGENCY_RATE"] = "";
                    dr["MIS_AGENCY_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                    dr["MIS_AGENCY_EXRATE"] = dr["INVOICE_EXRATE"];
                    dr["MIS_DISCOUNT_CHARGES"] = "";
                    dr["MIS_DISCOUNT_RATE"] = "";
                    dr["MIS_DISCOUNT_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                    dr["MIS_DISCOUNT_EXRATE"] = dr["INVOICE_EXRATE"];
                    dr["MIS_DISCOUNT_REASON"] = "";
                    dr["MIS_LOADING_CHARGES"] = "";
                    dr["MIS_LOADING_RATE"] = "";
                    dr["MIS_LOADING_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                    dr["MIS_LOADING_EXRATE"] = dr["INVOICE_EXRATE"];


                    //dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();
                    //dr["MIS_FREIGHT_RATE"] = "";                    
                    //dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                    //if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                    //{
                    //    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                    //}
                    //else
                    //{

                    //    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                    //    {
                    //        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                    //        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                    //        adm.EWorking_Period = Working_Period;

                    //        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency();

                    //        if (ds3.Tables[0].Rows.Count > 0)
                    //        {
                    //            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                    //        }

                    //    }
                    //    else
                    //    {
                    //        dr["MIS_FREIGHT_EXRATE"] = "";
                    //    }
                    //}


                    //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();
                    //dr["MIS_INSURANCE_RATE"] = "";
                    //dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                    //if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                    //{
                    //    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                    //}
                    //else
                    //{

                    //    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                    //    {
                    //        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                    //        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                    //        adm.EWorking_Period = Working_Period;                           

                    //        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency();

                    //        if (ds4.Tables[0].Rows.Count > 0)
                    //        {
                    //            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                    //        }

                    //    }
                    //    else
                    //    {
                    //        dr["MIS_INSURANCE_EXRATE"] = "";
                    //    }
                    //}

                    //dr["MIS_INSURANCE_EXRATE"] = "";

                    dr["MIS_HIGHSEASALE_CHARGES"] = "";
                    dr["MIS_HIGHSEASALE_RATE"] = "";
                    dr["MIS_HIGHSEASALE_CURRENCY"] = "INR";
                    dr["MIS_HIGHSEASALE_EXRATE"] = "1.00";
                    dr["MIS_SINGLE_OR_MULITIPLE"] = "S";
                    dr["SVB_RELATION"] = "";
                    dr["SVB_REF_NO"] = "";

                    string SVB_REF_DATE = "01/01/1900";
                    dr["SVB_REF_DATE"] = DateTime.Parse(SVB_REF_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                                        

                    dr["SVB_CUSTOM_HOUSE"] = "";
                    dr["SVB_LOADING_ON"] = "";
                    dr["SVB_ASSESABLE_RATE"] = "";
                    dr["SVB_DUTY_RATE"] = "";
                    dr["SVB_ASSESABLE_STATUS"] = "";
                    dr["SVB_DUTY_STATUS"] = "";
                    dr["OTHER_PURCHASE_ORDER"] = "";

                    string PURCHASE_ORDER_DATE = "01/01/1900";

                    dr["OTHER_PURCHASE_ORDER_DATE"] = DateTime.Parse(PURCHASE_ORDER_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                    dr["OTHER_CONTRACT_NO"] = "";

                    string CONTRACT_DATE = "01/01/1900";

                    dr["OTHER_CONTRACT_DATE"] = DateTime.Parse(CONTRACT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                    dr["OTHER_LOC_NO"] = "";
                    dr["OTHER_NATURE_OF_TRANSACTION"] = "";
                    dr["OTHER_TERMS_OF_PAYMENT"] = "";
                    dr["OTHER_CONDITIONS"] = "";
                    dr["OTHER_VALUATION_METHOD"] = "";

                    string ship = "01/01/1900";
                    dr["SAP_DELIEVERY_ID"] = "";
                    dr["SHIP_DATE"] = DateTime.Parse(ship, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    dr["INVOICE_LEVEL"] = "";
                    dr["COUNTRY_OF_DEPARTURE"] = "";

                    string DATE = "01/01/1900";

                    dr["NON_STD_EFFECT_DT_IMP"] = DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    dr["NON_STD_BANKNAME"] = "";
                    dr["NON_STD_CERTIFICATE_NO"] = "";
                    dr["NON_STD_CERTIFICATE_DATE"] = DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                    dr["USER_ID"] = currentuser;
                    dr["DATE_TIME"] = "";
                    dr["STATUS"] = "S";
                    dr["BRANCH_CODE"] = currentbranch;
                    dr["YEAR"] = "";
                    dr["WORKING_PERIOD"] = Working_Period;

                    //--------------------Item Details--------------------------//

                    while (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
                    {
                        //while (ds.Tables[0].Rows.Count > b)
                        //{
                        DataRow dr1 = dsXML.Tables[1].NewRow();

                        dr1["ITEM_ID"] = "";
                        dr1["JOBNO"] = IMPORT_JOBNO;
                        dr1["INVOICE_SLNO"] = ds.Tables[0].Rows[b][0].ToString();
                        dr1["INVOICE_NO"] = ds.Tables[0].Rows[b][1].ToString().TrimEnd();
                        dr1["ITEM_SLNO"] = ds.Tables[0].Rows[b][5].ToString();
                        dr1["ITEM_DESCRIPTION"] = ds.Tables[0].Rows[b][9].ToString();
                        dr1["ITEM_QTY"] = ds.Tables[0].Rows[b][6].ToString();
                        dr1["ITEM_QTY_CODE"] = ds.Tables[0].Rows[b][7].ToString();
                        dr1["ITEM_UNIT_PRICE"] = ds.Tables[0].Rows[b][8].ToString();
                        dr1["ITEM_UNIT_CODE"] = ds.Tables[0].Rows[b][4].ToString();

                        item_amt = Convert.ToDecimal(ds.Tables[0].Rows[b][6]) * Convert.ToDecimal(ds.Tables[0].Rows[b][8]);

                        // dr1["ITEM_AMOUNT"] = Convert.ToString(item_amt);
                        dr1["ITEM_TOTAL_AMOUNT"] = item_amt;
                        dr1["ITEM_AMOUNT_CODE"] = ds.Tables[0].Rows[b][4].ToString();
                        dr1["CTH_NO"] = ds.Tables[0].Rows[b][16].ToString();

                        scheme = ds.Tables[0].Rows[b][35].ToString();

                        if (scheme != "" && scheme != "00" && scheme != "0")
                        {
                            if (Convert.ToInt32(scheme) <= 9)
                            {
                                scheme = "0" + scheme;
                            }
                            scheme = Get_Scheme_Code(scheme);
                            dr1["SCHEME_CODE"] = scheme;
                            dr1["SCHEME_NOTN"] = ds.Tables[0].Rows[b][36].ToString();
                            dr1["SCHEME_NOTN_SLNO"] = ds.Tables[0].Rows[b][37].ToString();
                        }
                        else
                        {
                            dr1["SCHEME_CODE"] = "00 - DUTIABLE";
                            dr1["SCHEME_NOTN"] = "";
                            dr1["SCHEME_NOTN_SLNO"] = "";
                        }


                        dr1["CTH_QTY1"] = "";
                        dr1["CTH_QTY1_CODE"] = "";
                        dr1["CTH_QTY2"] = "";
                        dr1["CTH_QTY2_CODE"] = "";
                        dr1["GENEARL_DESCRIPTION"] = ds.Tables[0].Rows[b][29].ToString();
                        dr1["MANUFACTURER"] = ds.Tables[0].Rows[b][30].ToString();
                        dr1["BRAND"] = ds.Tables[0].Rows[b][31].ToString();
                        dr1["MODEL"] = ds.Tables[0].Rows[b][32].ToString();
                        dr1["END_USE_OF_ITEM"] = ds.Tables[0].Rows[b][33].ToString();
                        dr1["COUNTRY_OF_ORIGIN"] = ds.Tables[0].Rows[b][34].ToString();
                        dr1["ACCESSORIES"] = "";
                        dr1["PREVIOUS_BE_NO"] = "";

                        string BE_DATE = "01/01/1900";

                        dr1["PREVIOUS_BE_DATE"] = DateTime.Parse(BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                        dr1["UNIT_PRICE"] = "";
                        dr1["UNIT_CODE"] = "";
                        dr1["CUSTOMS_HOUSE"] = "";
                        dr1["PRODUCT_RITC"] = ds.Tables[0].Rows[b][17].ToString();

                        dr1["PRODUCT_CTH"] = ds.Tables[0].Rows[b][16].ToString();
                        dr1["PRODUCT_BCD_NOTN"] = ds.Tables[0].Rows[b][18].ToString();
                        dr1["PRODUCT_BCD_SLNO"] = ds.Tables[0].Rows[b][19].ToString();
                        dr1["PRODUCT_BCD_RATE"] = "";
                        dr1["PRODUCT_BCD_SPL"] = "";
                        dr1["PRODUCT_BCD_UNIT"] = "";
                        dr1["PRODUCT_BCD_SPL_TYPE"] = "";
                        //dr1["PRODUCT_ADDL_DUTY_NOTN"] = "";
                        //dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = "";
                        dr1["PRODUCT_ADDL_DUTY_RATE"] = "";
                        dr1["PRODUCT_EDU_CESS_NOTN"] = ds.Tables[0].Rows[b][20].ToString();
                        dr1["PRODUCT_EDU_CESS_NOTN_SL"] = ds.Tables[0].Rows[b][21].ToString();
                        dr1["PRODUCT_EDU_CESS_RATE"] = "";
                        dr1["PRODUCT_SEC_EDU_CESS_NOTN"] = "";
                        dr1["PRODUCT_SEC_EDU_CESS_NOTN_SL"] = "";
                        dr1["PRODUCT_SEC_EDU_CESS_RATE"] = "";
                        dr1["PRODUCT_NCD_NOTN"] = "";

                        dr1["PRODUCT_NCD_SLNO"] = "";
                        dr1["PRODUCT_NCD_RATE"] = "";
                        dr1["PRODUCT_NCD_SPL"] = "";
                        dr1["PRODUCT_NCD_UNIT"] = "";
                        dr1["PRODUCT_NCD_SPL_TYPE"] = "";
                        dr1["PRODUCT_AGGREGATE_DUTY_NOTN"] = "";
                        dr1["PRODUCT_AGGREGATE_DUTY_NOTN_SL"] = "";
                        dr1["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = "";
                        dr1["PRODUCT_SAFEGUARD_NOTN"] = "";
                        dr1["PRODUCT_SAFEGUARD_SLNO"] = "";
                        dr1["PRODUCT_SAFEGUARD_RATE"] = "";
                        dr1["PRODUCT_SAFEGUARD_SPL"] = "";
                        dr1["PRODUCT_SAFEGUARD_UNIT"] = "";
                        dr1["PRODUCT_SAFEGUARD_SPL_TYPE"] = "";
                        //dr1["PRODUCT_SAPTA_NOTN"] = "";
                        //dr1["PRODUCT_SAPTA_SLNO"] = "";
                        dr1["PRODUCT_SAPTA_RATE"] = "";

                        dr1["PRODUCT_TARIFF_NOTN"] = "";
                        dr1["PRODUCT_TARIFF_SLNO"] = "";
                        dr1["PRODUCT_TARIFF_QTY"] = "";
                        dr1["PRODUCT_TARIFF_AMOUNT"] = "";
                        dr1["PRODUCT_TARIFF_AMOUNT_UNIT"] = "";
                        dr1["PRODUCT_CETH"] = ds.Tables[0].Rows[b][22].ToString();

                        dr1["PRODUCT_MRP_SL_NO"] = ds.Tables[0].Rows[b][25].ToString();

                        if (dr1["PRODUCT_MRP_SL_NO"] != "")
                        {
                            dr1["PRODUCT_MRP_YN"] = "Y";
                            dr1["PRODUCT_MRP_AMOUNT"] = ds.Tables[0].Rows[b][26].ToString();
                            dr1["PRODUCT_MRP_ABT_RATE"] = "";

                            dr1["RSP_NOTN_NO"] = ds.Tables[0].Rows[b][27].ToString();
                            dr1["RSP_NOTN_SL_NO"] = ds.Tables[0].Rows[b][28].ToString();
                        }
                        else
                        {
                            dr1["PRODUCT_MRP_YN"] = "N";
                            dr1["PRODUCT_MRP_AMOUNT"] = "";
                            dr1["PRODUCT_MRP_ABT_RATE"] = "";

                            dr1["RSP_NOTN_NO"] = "";
                            dr1["RSP_NOTN_SL_NO"] = "";
                        }




                        dr1["PRODUCT_CVD_NOTN"] = ds.Tables[0].Rows[b][23].ToString();
                        dr1["PRODUCT_CVD_SLNO"] = ds.Tables[0].Rows[b][24].ToString();
                        dr1["PRODUCT_CVD_RATE"] = "";
                        dr1["PRODUCT_CVD_SPL"] = "";
                        dr1["PRODUCT_CVD_UNIT"] = "";
                        dr1["PRODUCT_CVD_SPL_TYPE"] = "";
                        //  dr1["PRODUCT_CVD_EDU_CESS_RATE"] = "";

                        dr1["PRODUCT_CVD_EDU_CESS_RATE"] = ds.Tables[0].Rows[b][43].ToString();
                        dr1["CETH_CVD_EDU_CESS_SL"] = ds.Tables[0].Rows[b][44].ToString();

                        dr1["PRODUCT_ADDL_DUTY_NOTN"] = ds.Tables[0].Rows[b][45].ToString();
                        dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = ds.Tables[0].Rows[b][46].ToString();
                        dr1["PRODUCT_SAPTA_NOTN"] = ds.Tables[0].Rows[b][47].ToString();
                        dr1["PRODUCT_SAPTA_SLNO"] = ds.Tables[0].Rows[b][48].ToString();
                        dr1["PRODUCT_ADDL_GSI_NOTN"] = ds.Tables[0].Rows[b][49].ToString();
                        dr1["PRODUCT_ADDL_TTA_NOTN"] = ds.Tables[0].Rows[b][50].ToString();


                        //dr1["PRODUCT_CVD_SEC_EDU_CESS_RATE"] = "";
                        dr1["PRODUCT_ADDL5_SIA_NOTN"] = "";
                        dr1["PRODUCT_ADDL5_SIA_NOTN_SL"] = "";
                        dr1["PRODUCT_ADDL5_SIA_RATE"] = "";
                        //dr1["PRODUCT_ADDL_GSI_NOTN"] = "";
                        dr1["PRODUCT_ADDL_GSI_SLNO"] = "";
                        dr1["PRODUCT_ADDL_GSI_RATE"] = "";
                        dr1["PRODUCT_ADDL_GSI_SPL"] = "";
                        dr1["PRODUCT_ADDL_GSI_UNIT"] = "";
                        dr1["PRODUCT_ADDL_GSI_SPL_TYPE"] = "";
                        dr1["PRODUCT_ADDL_SHEII_NOTN"] = "";
                        dr1["PRODUCT_ADDL_SHEII_SLNO"] = "";
                        dr1["PRODUCT_ADDL_SHEII_RATE"] = "";
                        dr1["PRODUCT_ADDL_SHEII_SPL"] = "";
                        dr1["PRODUCT_ADDL_SHEII_UNIT"] = "";
                        dr1["PRODUCT_ADDL_SHEII_TYPE"] = "";
                        //dr1["PRODUCT_ADDL_TTA_NOTN"] = "";

                        dr1["PRODUCT_ADDL_TTA_SLNO"] = "";
                        dr1["PRODUCT_ADDL_TTA_RATE"] = "";
                        dr1["PRODUCT_ADDL_TTA_SPL"] = "";
                        dr1["PRODUCT_ADDL_TTA_UNIT"] = "";
                        dr1["PRODUCT_ADDL_TTA_TYPE"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_NOTN"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_SLNO"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_RATE"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_SPL"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_UNIT"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_TYPE"] = "";
                        dr1["PRODUCT_CESS_NOTN"] = "";
                        dr1["PRODUCT_CESS_SLNO"] = "";

                        dr1["PRODUCT_CESS_RATE"] = "";
                        dr1["PRODUCT_CESS_SPL"] = "";
                        dr1["PRODUCT_CESS_UNIT"] = "";
                        dr1["PRODUCT_CESS_TYPE"] = "";

                        dr1["ANTI_DUMPING_NOTN"] = "";
                        dr1["ANTI_DUMPING_NOTN_SLNO"] = "";
                        dr1["CTH_SLNO"] = "";
                        dr1["CTH_SUPPLIER_SLNO"] = "";
                        dr1["CTH_QTY"] = "";
                        dr1["RSP_DUTY_STATUS"] = "";
                        dr1["RSP_SL_NO"] = "";
                        dr1["RSP_DESC"] = "";
                        dr1["RSP_QTY"] = "";
                        dr1["RSP_AMOUNT"] = "";
                        //dr1["RSP_NOTN_NO"] = "";
                        //dr1["RSP_NOTN_SL_NO"] = "";
                        dr1["RSP_ABT_RATE"] = "";
                        dr1["WAREHOUSE_JOBNO"] = "0";
                        dr1["WAREHOUSE_INVOICE_SLNO"] = "0";
                        dr1["WAREHOUSE_ITEM_SLNO"] = "0";
                        dr1["ASSESSABLE_VALUE"] = "";

                        dr1["DUTY_VALUE"] = "";
                        dr1["CIF_VALUE"] = "";
                        dr1["CVD_VALUE"] = "";

                        dr1["USER_ID"] = currentuser;
                        dr1["DATE_TIME"] = "";
                        dr1["STATUS"] = "N";
                        dr1["BRANCH_CODE"] = currentbranch;

                        dr1["YEAR"] = "";
                        dr1["WORKING_PERIOD"] = Working_Period;

                        dr1["BASIC_VALUE"] = "";
                        dr1["CEC_VALUE"] = "";
                        dr1["CHEC_VALUE"] = "";
                        dr1["ADD_DUTY_VALUE"] = "";

                        dr1["CETH_CVD_EDU_CESS_RATE"] = "";
                        dr1["CETH_CVD_SEC_EDU_CESS_SL"] = "";
                        dr1["CETH_CVD_SEC_EDU_CESS_RATE"] = "";
                        dr1["PRODUCT_OTHER_DUTY_NOTN"] = "";
                        dr1["PRODUCT_OTHER_DUTY_SLNO"] = "";
                        dr1["PRODUCT_OTHER_DUTY_RATE"] = "";
                        dr1["PRODUCT_OTHER_DUTY_SPL"] = "";
                        dr1["PRODUCT_OTHER_DUTY_TYPE"] = "";
                        dr1["MODIFIEDBY"] = "";

                        string MODIFIEDON = "01/01/1900";

                        dr1["MODIFIEDON"] = DateTime.Parse(MODIFIEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                        //dr1["MODIFIEDON"] = "01/02/2010";
                        dr1["INDIVITUAL_FREIGHT_AMOUNT"] = "";
                        dr1["INDIVITUAL_INSURANCE_AMOUNT"] = "";
                        dr1["INDIVITUAL_MISC_AMOUNT"] = "";
                       

                        //**************************** ADDING SVB DETAILS *******************************//
                        if (ds.Tables[0].Rows[b][51].ToString() != "")
                        {
                            dr1["SVB_RELATION"] = "true";
                        }
                        else
                        {
                            dr1["SVB_RELATION"] = "";
                        }
                        dr1["SVB_REF_NO"] = ds.Tables[0].Rows[b][51].ToString();

                        //string SVB_REF_DATE1 = ds.Tables[0].Rows[b][52].ToString();

                        //dr1["SVB_REF_DATE"] = DateTime.Parse(SVB_REF_DATE1, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                        string SVB_REF_DATE1 = Convert.ToDateTime(ds.Tables[0].Rows[b][52].ToString()).ToShortDateString();

                        string SVB_REF_DATE2 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(SVB_REF_DATE1));
                        dr1["SVB_REF_DATE"] = Convert.ToDateTime(SVB_REF_DATE1).ToString(@"MM/dd/yyyy");



                        //dr1["SVB_REF_DATE"] = "01/02/2010";
                        dr1["SVB_CUSTOM_HOUSE"] = ds.Tables[0].Rows[b][53].ToString();

                        if (ds.Tables[0].Rows[b][54].ToString() == "")
                        {
                            dr1["SVB_LOADING_ON"] = "";
                        }
                        else
                        {
                            string SVB_LOADING = ds.Tables[0].Rows[b][54].ToString();
                            if (SVB_LOADING == "A")
                            {
                                dr1["SVB_LOADING_ON"] = "Assessable";
                            }
                            else if (SVB_LOADING == "D")
                            {
                                dr1["SVB_LOADING_ON"] = "Duty";
                            }
                            else
                            {
                                dr1["SVB_LOADING_ON"] = "Both";
                            }
                        }
                      
                        dr1["SVB_ASSESABLE_RATE"] = ds.Tables[0].Rows[b][55].ToString();
                        dr1["SVB_DUTY_RATE"] = ds.Tables[0].Rows[b][56].ToString();

                        dr1["SVB_ASSESABLE_STATUS"] = ds.Tables[0].Rows[b][57].ToString();

                        dr1["SVB_DUTY_STATUS"] = ds.Tables[0].Rows[b][58].ToString();

                        //*******************************************************************************//

                        dsXML.Tables[1].Rows.Add(dr1);


                        //--------------------License Details--------------------------//

                        if (ds.Tables[0].Rows.Count > c)
                        {

                            string regno = ds.Tables[0].Rows[c][38].ToString();

                            if (regno != "")
                            {
                                DataRow dr2 = dsXML.Tables[2].NewRow();

                                dr2["LICENSE_ID"] = "";
                                dr2["JOBNO"] = IMPORT_JOBNO;
                                dr2["INVOICE_SLNO"] = ds.Tables[0].Rows[c][0].ToString();

                                dr2["ITEM_SLNO"] = ds.Tables[0].Rows[c][5].ToString();
                                //dr2["SCHEME_CODE"] = ds.Tables[0].Rows[b][35].ToString();
                                dr2["SCHEME_CODE"] = scheme;
                                licen_slno = licen_slno + 1;
                                dr2["LICENSE_SLNO"] = licen_slno;
                                dr2["REGISTRATION_NO"] = ds.Tables[0].Rows[c][38].ToString();

                                string REGISTRATION_DATE = ds.Tables[0].Rows[c][39].ToString();

                                if (REGISTRATION_DATE != "")
                                {
                                    string reg_date = Convert.ToDateTime(ds.Tables[0].Rows[c][39].ToString()).ToShortDateString();
                                    string reg_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(reg_date));

                                    //dr2["REGISTRATION_DATE"] = DateTime.Parse(reg_date1, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    dr2["REGISTRATION_DATE"] = Convert.ToDateTime(REGISTRATION_DATE).ToString(@"MM/dd/yyyy");

                                }
                                else
                                {
                                    REGISTRATION_DATE = "01/01/1900";
                                }

                                dr2["EXCEMPTION"] = ds.Tables[0].Rows[c][40].ToString();

                                dr2["DEBIT_AMT"] = "";
                                dr2["DEBIT_QTY"] = ds.Tables[0].Rows[c][6].ToString();
                                dr2["UNIT_QTY"] = ds.Tables[0].Rows[c][7].ToString();
                                dr2["LICENSE_ITEM_NO"] = ds.Tables[0].Rows[c][41].ToString();
                                dr2["PORT_OF_LICENSE"] = ds.Tables[0].Rows[c][42].ToString();


                                dr2["USER_ID"] = currentuser;
                                dr2["DATE_TIME"] = "";
                                dr2["STATUS"] = "S";
                                dr2["BRANCH_CODE"] = currentbranch;
                                dr2["YEAR"] = "";
                                dr2["WORKING_PERIOD"] = Working_Period;

                                dsXML.Tables[2].Rows.Add(dr2);

                                //for (int i = 0; i < dsXML.Tables[2].Rows.Count; i++)
                                //{
                                //    for (int j = 0; j < dsXML.Tables[2].Columns.Count; j++)
                                //    {
                                //        if (string.IsNullOrEmpty(dsXML.Tables[2].Rows[i].ToString()))
                                //        {
                                //            // Write your Custom Code
                                //            //dt.Rows[i][j] = "N/A";
                                //            dsXML.Tables[2].Rows[i].Delete();
                                //        }
                                //    }
                                //}

                            }
                            c++;
                        }


                        //--------------------End License Details--------------------------//


                        b++;
                    }


                    dt = dsXML.Tables["ItemDetails"];

                    //******************************************* LCD NEW ****************************

                    string dd = ds.Tables[0].Rows[a][1].ToString();
                    string Inv_new = "";
                    var Values = from row in dsXML.Tables["ItemDetails"].AsEnumerable()
                                 //group row by row.Field<string>("INVOICE_NO") into g
                                 //group row by dd into g
                                 group row by new { id = row.Field<string>("INVOICE_NO") } into g
                                 select new
                                 {
                                     name_1 = g.Key.id,
                                     name_2 = g.Sum(r => r.Field<double>("ITEM_TOTAL_AMOUNT"))

                                 };

                    foreach (var drval in Values)
                    {
                        if (drval.name_1 == dd)
                            Inv_new = Convert.ToString(drval.name_2);
                        if (Inv_new.Contains("."))
                        {
                            string[] Inv_new1 = Inv_new.Split('.');
                            string p1 = Inv_new1[0];
                            string p2 = Inv_new1[1];
                            if (p2.Length >= 2)
                            {
                                string Aft_digit = p2.Substring(0, 2);
                                dr["INVOICE_VALUE"] = p1 + "." + Aft_digit;
                            }
                            else
                            {
                                dr["INVOICE_VALUE"] = Inv_new;
                            }
                        }
                        else
                        {
                            dr["INVOICE_VALUE"] = drval.name_2;
                        }
                    }



                    //-----------------Invoice Terms Calculation----------------------------//

                    dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();
                    dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();

                    string valtest1 = ds.Tables[0].Rows[a][10].ToString();

                    if (dr["MIS_FREIGHT_CHARGES"] == "" || dr["MIS_INSURANCE_CHARGES"] == "")
                    {
                        if (Convert.ToString(dr["TERMS"]) == "FOB")
                        {
                            if (dr["MIS_FREIGHT_CHARGES"] == "")
                            {

                                dr["MIS_FREIGHT_RATE"] = "20.0000";

                                double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                cal = invoicevalue_Excel * 20 / 100;

                                //dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);

                                dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                                //string valtest2 = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                                dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                {
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                                else
                                {

                                    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds3.Tables[0].Rows.Count > 0)
                                        {
                                            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }

                                    }
                                    else
                                    {
                                        dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                }

                            }
                            else
                            {
                                //dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();

                                dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][10]), 2).ToString("0.00"));

                                dr["MIS_FREIGHT_RATE"] = "";
                                dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                {
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                                else
                                {
                                    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds3.Tables[0].Rows.Count > 0)
                                        {
                                            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }

                                    }
                                    else
                                    {
                                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                }
                            }

                            if (dr["MIS_INSURANCE_CHARGES"] == "")
                            {

                                dr["MIS_INSURANCE_RATE"] = "1.1250";

                                double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                cal1 = invoicevalue_Excel1 * 1.125 / 100;

                                //dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);

                                dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal1), 2).ToString("0.00"));

                                dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                {
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                                else
                                {
                                    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds4.Tables[0].Rows.Count > 0)
                                        {
                                            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }
                                    }
                                    else
                                    {
                                        dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                }
                            }
                            else
                            {

                                //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();

                                dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][12]), 2).ToString("0.00"));

                                dr["MIS_INSURANCE_RATE"] = "";
                                dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                {
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                                else
                                {

                                    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds4.Tables[0].Rows.Count > 0)
                                        {
                                            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }
                                    }
                                    else
                                    {
                                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                }
                            }
                        }


                        else if (Convert.ToString(dr["TERMS"]) == "CI")
                        {
                            if (dr["MIS_FREIGHT_CHARGES"] == "")
                            {
                                dr["MIS_FREIGHT_RATE"] = "20.0000";

                                double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                cal = invoicevalue_Excel * 20 / 100;

                                //dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);

                                dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                                dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                {
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                                else
                                {

                                    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds3.Tables[0].Rows.Count > 0)
                                        {
                                            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }

                                    }
                                    else
                                    {
                                        dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                }
                            }

                            else
                            {
                                //dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();

                                dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][10]), 2).ToString("0.00"));

                                dr["MIS_FREIGHT_RATE"] = "";
                                dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                {
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                                else
                                {
                                    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds3.Tables[0].Rows.Count > 0)
                                        {
                                            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }

                                    }
                                    else
                                    {
                                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                }
                            }

                        }
                        else if (Convert.ToString(dr["TERMS"]) == "CF")
                        {
                            if (dr["MIS_INSURANCE_CHARGES"] == "")
                            {
                                dr["MIS_INSURANCE_RATE"] = "1.1250";

                                double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                cal1 = invoicevalue_Excel1 * 1.125 / 100;

                                //dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);

                                dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal1), 2).ToString("0.00"));

                                dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                {
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                                else
                                {

                                    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds4.Tables[0].Rows.Count > 0)
                                        {
                                            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }
                                    }
                                    else
                                    {
                                        dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                }
                            }

                            else
                            {

                                //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();

                                dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][12]), 2).ToString("0.00"));

                                dr["MIS_INSURANCE_RATE"] = "";
                                dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                {
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                                else
                                {
                                    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds4.Tables[0].Rows.Count > 0)
                                        {
                                            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }
                                    }
                                    else
                                    {
                                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                }
                            }
                        }
                        else if (Convert.ToString(dr["TERMS"]) == "CIF")
                        {

                        }
                    }
                    else
                    {
                        dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();

                        string valtest2 = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][10].ToString()), 2).ToString("0.00"));

                        dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][10].ToString()), 2).ToString("0.00"));

                        dr["MIS_FREIGHT_RATE"] = "";
                        dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                        if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                        {
                            dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                        }
                        else
                        {

                            if (dr["MIS_FREIGHT_CURRENCY"] != "")
                            {
                                adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                adm.EWorking_Period = Working_Period;

                                ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                if (ds3.Tables[0].Rows.Count > 0)
                                {
                                    dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                                }

                            }
                            else
                            {
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                        }

                        //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();
                        dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][12].ToString()), 2).ToString("0.00"));
                        dr["MIS_INSURANCE_RATE"] = "";
                        dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                        if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                        {
                            dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                        }
                        else
                        {

                            if (dr["MIS_INSURANCE_CURRENCY"] != "")
                            {
                                adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                adm.EWorking_Period = Working_Period;

                                ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                if (ds4.Tables[0].Rows.Count > 0)
                                {
                                    dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                }
                            }
                            else
                            {
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                        }
                    }

                    //---------------------------End------------------------------------//

                    dsXML.Tables[0].Rows.Add(dr);
                    a++;
                    //}
                }
                #endregion
            }
            else if (file_ext == ".csv")
            {
                #region read HP_Format
                int inv_slno_item_slno = 0;
                string Edit_inv_currency = "", Edit_Country = "", Edit_Exrate = "";
                //while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                //{


                DataTable inv_tempTable = ds.Tables[0].Clone();
                DataTable table = new DataTable("users");




                table.Columns.Add(new DataColumn("invoice_number", typeof(string)));

                // Search for given id e.g here 1

                //DataRow[] result = RemoveDuplicateRows_1(Inv_ds.Tables[0], "invoice_number", ds.Tables[0]); //ds.Tables[0].Select("Inv_slno = 1"); // this will return one row for above data 
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    table.Rows.Add(row[3]);

                }

                table = RemoveDuplicateRows(table, "invoice_number");
                //while (table.Rows.Count > a)
                //{
                //    string inv_no = table.Rows[a][0].ToString();
                //    DataSet ds_ship = new DataSet();

                //    DataRow[] dt_shipRow = ds.Tables[0].Select("invoice_number = '" + inv_no + "'");// ds.Tables[0];

                //    DataTable Newdt = dt_shipRow.CopyToDataTable<DataRow>();
                //    ds_ship.Tables.Add(Newdt);
                //}



                while (table.Rows.Count > a)
                {
                    string inv_no1 = table.Rows[a][0].ToString();

                    DataSet dss1 = new DataSet();

                    DataRow[] dtRow = ds.Tables[0].Select("invoice_number = '" + inv_no1 + "'");// ds.Tables[0];

                    DataTable Newdt = dtRow.CopyToDataTable<DataRow>();
                    dss1.Tables.Add(Newdt);


                    //------------------------------------------------------------------     
                    /*DataTable data = new DataTable();
                    data.Columns.Add("Invoice Date", typeof(DateTime));
                    DataRow dr = data.NewRow();
                    dr[0] = DateTime.Now;*/
                    //------------------------------------------------------------------

                    DataRow dr = dsXML.Tables[0].NewRow();

                    dr["INVOICE_ID"] = "";
                    dr["JOBNO"] = IMPORT_JOBNO;
                    dr["INVOICE_SLNO"] = a + 1;
                    inv_slno_item_slno = a + 1;
                    dr["INVOICE_NO"] = inv_no = dss1.Tables[0].Rows[0][3].ToString();

                    string adt = dss1.Tables[0].Rows[0][4].ToString();
                    string y = adt.Substring(0, 4);
                    string m = adt.Remove(0, 4).Substring(0, 2);
                    string d = adt.Remove(0, 6).Substring(0, 2);

                    //string dd = d + "/" + m + "/" + y;
                    string dd = d + "/" + m + "/" + y;

                    /*string inv_date = Convert.ToDateTime((d + "/" + m + "/" + y).ToString()).ToShortDateString();
                    //dr["INVOICE_DATE"]= string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dd));
                    // dr["INVOICE_DATE"] = DateTime.Parse(d + "/" + m + "/" + y, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);*/


                    //dr["INVOICE_DATE"] = Convert.ToDateTime(dd).ToString(@"MM/dd/yyyy");
                    //dr["INVOICE_DATE"] = DateTime.ParseExact(dd, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);




                    dr["INVOICE_DATE"] = adt;

                    dr["TERMS"] = dss1.Tables[0].Rows[0][30].ToString();
                    dr["INVOICE_CURRENCY"] = dss1.Tables[0].Rows[0][24].ToString();

                    if (!string.IsNullOrEmpty(Edit_inv_currency))
                    {
                        dr["INVOICE_EXRATE"] = Edit_Exrate;
                        dr["INVOICE_CURRENCY"] = Edit_inv_currency;

                    }
                    else
                    {
                        if (dr["INVOICE_CURRENCY"] != "")
                        {
                            adm.Invoice_Currency = dr["INVOICE_CURRENCY"].ToString(); ;

                            adm.Ename = "IMPORT_INV_EX_RATE_CURRENCY_NAME";
                            adm.EWorking_Period = Working_Period;



                            ds1 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                dr["INVOICE_EXRATE"] = Edit_Exrate = ds1.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                                dr["INVOICE_CURRENCY"] = Edit_inv_currency = adm.Invoice_Currency = ds1.Tables[0].Rows[0]["EXCHANGE_CUR_CODE"].ToString();

                            }

                        }
                        else
                        {
                            dr["INVOICE_EXRATE"] = Edit_Exrate = "";
                        }
                    }
                    dr["INVOICE_VALUE"] = "";

                    dr["INVOICE_NO"] = inv_no = dss1.Tables[0].Rows[0][3].ToString();

                    string supp_code = inv_no.Substring(0, 4);
                    //string m = adt.Remove(0, 4).Substring(0, 2);
                    //string d = adt.Remove(0, 6).Substring(0, 2);

                    DataSet dtsupp = new DataSet();
                    erm.Esupid = supp_code;
                    erm.Esup_name = "0";
                    erm.Ename = "select_HP_Supp_Details";
                    erm.EWorking_Period = Working_Period;
                    dtsupp = erm.RetrieveAll_Supplier_MASTER();
                    if (dtsupp.Tables[0].Rows.Count > 0)
                    {
                        dr["SUPPLIER_NAME"] = dtsupp.Tables[0].Rows[0]["SUP_NAME"].ToString();
                        dr["SUPPLIER_ADDRESS"] = dtsupp.Tables[0].Rows[0]["SUP_ADD1"].ToString();
                        dr["SUPPLIER_ADDRESS1"] = dtsupp.Tables[0].Rows[0]["SUP_ADD2"].ToString();
                        dr["SUPPLIER_ADDRESS2"] = dtsupp.Tables[0].Rows[0]["SUP_ADD3"].ToString();
                        dr["SUPPLIER_COUNTRY_NAME"] = dtsupp.Tables[0].Rows[0]["SUP_COUNTRY_NAME"].ToString();
                        dr["SUPPLIER_COUNTRY_CODE"] = dtsupp.Tables[0].Rows[0]["SUP_COUNTRY_CODE"].ToString();
                        dr["SUPPLIER_COUNTRY_PINCODE"] = dtsupp.Tables[0].Rows[0]["SUP_PIN_CODE"].ToString();
                        string remarks = dtsupp.Tables[0].Rows[0]["SUP_REMARKS"].ToString();

                    }
                    else
                    {
                        dr["SUPPLIER_NAME"] = "";
                        dr["SUPPLIER_ADDRESS"] = "";
                        dr["SUPPLIER_ADDRESS1"] = "";
                        dr["SUPPLIER_ADDRESS2"] = "";
                        dr["SUPPLIER_COUNTRY_NAME"] = "";
                        dr["SUPPLIER_COUNTRY_CODE"] = "";
                        dr["SUPPLIER_COUNTRY_PINCODE"] = "";
                    }

                    //dr["SUPPLIER_NAME"] = "";
                    //dr["SUPPLIER_ADDRESS"] = "";
                    //dr["SUPPLIER_ADDRESS1"] = "";
                    //dr["SUPPLIER_ADDRESS2"] = "";
                    //dr["SUPPLIER_COUNTRY_NAME"] = "";
                    //dr["SUPPLIER_COUNTRY_CODE"] = "";
                    //dr["SUPPLIER_COUNTRY_PINCODE"] = "";


                    dr["SELLER_NAME"] = "";
                    dr["SELLER_ADDRESS"] = "";
                    dr["SELLER_ADDRESS1"] = "";
                    dr["SELLER_ADDRESS2"] = "";
                    dr["SELLER_COUNTRY_NAME"] = "";
                    dr["SELLER_COUNTRY_CODE"] = "";
                    dr["SELLERCOUNTRY_PINCODE"] = "";
                    dr["BROKER_NAME"] = "";
                    dr["BROKER_ADDRESS"] = "";
                    dr["BROKER_ADDRESS1"] = "";
                    dr["BROKER_ADDRESS2"] = "";
                    dr["BROKER_COUNTRY_NAME"] = "";
                    dr["BROKER_COUNTRY_CODE"] = "";
                    dr["BROKER_COUNTRY_PINCODE"] = "";

                    dr["MIS_CHARGES"] = "";
                    dr["MIS_RATE"] = "";
                    dr["MIS_CURRENCY"] = "";

                    if (dr["INVOICE_CURRENCY"] == dr["MIS_CURRENCY"])
                    {
                        dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                    }
                    else
                    {

                        if (dr["MIS_CURRENCY"] != "")
                        {
                            adm.Invoice_Currency = dr["MIS_CURRENCY"].ToString();

                            adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            adm.EWorking_Period = Working_Period;

                            ds2 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                dr["MIS_EXRATE"] = ds2.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                            }

                        }
                        else
                        {
                            dr["MIS_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                        }
                    }

                    dr["MIS_AGENCY_CHARGES"] = "";
                    dr["MIS_AGENCY_RATE"] = "";
                    dr["MIS_AGENCY_CURRENCY"] = dr["INVOICE_CURRENCY"];
                    dr["MIS_AGENCY_EXRATE"] = dr["INVOICE_EXRATE"];
                    dr["MIS_DISCOUNT_CHARGES"] = "";
                    dr["MIS_DISCOUNT_RATE"] = "";
                    dr["MIS_DISCOUNT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                    dr["MIS_DISCOUNT_EXRATE"] = dr["INVOICE_EXRATE"];
                    dr["MIS_DISCOUNT_REASON"] = "";
                    dr["MIS_LOADING_CHARGES"] = "";
                    dr["MIS_LOADING_RATE"] = "";
                    dr["MIS_LOADING_CURRENCY"] = dr["INVOICE_CURRENCY"];
                    dr["MIS_LOADING_EXRATE"] = dr["INVOICE_EXRATE"];




                    dr["MIS_HIGHSEASALE_CHARGES"] = "";
                    dr["MIS_HIGHSEASALE_RATE"] = "";
                    dr["MIS_HIGHSEASALE_CURRENCY"] = "INR";
                    dr["MIS_HIGHSEASALE_EXRATE"] = "1.00";
                    dr["MIS_SINGLE_OR_MULITIPLE"] = "S";
                    dr["SVB_RELATION"] = "";
                    dr["SVB_REF_NO"] = "";

                    string SVB_REF_DATE = "01/01/1900";
                    dr["SVB_REF_DATE"] = DateTime.Parse(SVB_REF_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                    dr["SVB_CUSTOM_HOUSE"] = "INMAA4";
                    dr["SVB_LOADING_ON"] = "";
                    dr["SVB_ASSESABLE_RATE"] = "";
                    dr["SVB_DUTY_RATE"] = "";
                    dr["SVB_ASSESABLE_STATUS"] = "";
                    dr["SVB_DUTY_STATUS"] = "";
                    //dr["OTHER_PURCHASE_ORDER"] = ds.Tables[0].Rows[a][7].ToString();
                    dr["OTHER_PURCHASE_ORDER"] = dss1.Tables[0].Rows[0][8].ToString();

                    dr["OTHER_PURCHASE_ORDER_DATE"] = dr["INVOICE_DATE"];

                    dr["OTHER_CONTRACT_NO"] = dss1.Tables[0].Rows[0][14].ToString();

                    dr["OTHER_CONTRACT_DATE"] = dr["INVOICE_DATE"];

                    dr["OTHER_LOC_NO"] = "";
                    dr["OTHER_NATURE_OF_TRANSACTION"] = "";
                    dr["OTHER_TERMS_OF_PAYMENT"] = "";
                    dr["OTHER_CONDITIONS"] = "";
                    dr["OTHER_VALUATION_METHOD"] = "";


                    dr["SAP_DELIEVERY_ID"] = dss1.Tables[0].Rows[0][11].ToString();

                    string ship = dss1.Tables[0].Rows[0][36].ToString();
                    if (ship != "")
                    {
                        string y1 = ship.Substring(0, 4);
                        string m1 = ship.Remove(0, 4).Substring(0, 2);
                        string d1 = ship.Remove(0, 6).Substring(0, 2);

                        dr["SHIP_DATE"] = dss1.Tables[0].Rows[0][36].ToString();

                        //dr["SHIP_DATE"] = DateTime.Parse(d1 + "/" + m1 + "/" + y1, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    }
                    else
                    {
                        string Ship_DATE = "01/01/1900";
                        dr["SHIP_DATE"] = DateTime.Parse(Ship_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    }

                    dr["INVOICE_LEVEL"] = dss1.Tables[0].Rows[0][39].ToString();
                    dr["COUNTRY_OF_DEPARTURE"] = dss1.Tables[0].Rows[0][40].ToString();


                    string DATE = "01/01/1900";

                    dr["NON_STD_EFFECT_DT_IMP"] = DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    dr["NON_STD_BANKNAME"] = "";
                    dr["NON_STD_CERTIFICATE_NO"] = "";
                    dr["NON_STD_CERTIFICATE_DATE"] = DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                    dr["USER_ID"] = currentuser;
                    dr["DATE_TIME"] = "";
                    dr["STATUS"] = "S";
                    dr["BRANCH_CODE"] = currentbranch;
                    dr["YEAR"] = "";
                    dr["WORKING_PERIOD"] = Working_Period;


                    //--------------------Item Details--------------------------//

                    //while (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
                    //{

                    //DataSet dss1 = new DataSet();

                    //DataRow[] dtRow1 = ds.Tables[0].Select("invoice_number = '" + inv_no + "'");// ds.Tables[0];

                    //DataTable Newdt1 = dtRow1.CopyToDataTable<DataRow>();
                    //dss1.Tables.Add(Newdt1);

                    b = 0;
                    while (dss1.Tables[0].Rows.Count > b)
                    {
                        DataRow dr1 = dsXML.Tables[1].NewRow();

                        dr1["ITEM_ID"] = "";
                        dr1["JOBNO"] = IMPORT_JOBNO;

                        dr1["INVOICE_NO"] = dss1.Tables[0].Rows[b][3].ToString();
                        dr1["INVOICE_SLNO"] = inv_slno_item_slno;
                        //if (is_sameinvno != dss1.Tables[0].Rows[b][3].ToString())
                        //{
                        //    dr1["INVOICE_SLNO"] = inv_slno_item_slno;
                        //}
                        //else
                        //{
                        //    dr1["INVOICE_SLNO"] = inv_slno_item_slno+1;

                        //}

                        dr1["ITEM_SLNO"] = b + 1;

                        dr1["ITEM_DESCRIPTION"] = dss1.Tables[0].Rows[b][19].ToString() + " " + dss1.Tables[0].Rows[b][20].ToString();
                        dr1["ITEM_QTY"] = dss1.Tables[0].Rows[b][21].ToString();
                        //dr1["ITEM_QTY_CODE"] = dss1.Tables[0].Rows[b][7].ToString();

                        dr1["ITEM_QTY_CODE"] = "PCS";

                        dr1["ITEM_UNIT_PRICE"] = dss1.Tables[0].Rows[b][22].ToString();
                        dr1["ITEM_UNIT_CODE"] = dr["INVOICE_CURRENCY"].ToString();

                        //item_amt = Convert.ToDecimal(dss1.Tables[0].Rows[b][21]) * Convert.ToDecimal(dss1.Tables[0].Rows[b][23]);
                        //dr1["ITEM_TOTAL_AMOUNT"] = item_amt;

                        dr1["ITEM_TOTAL_AMOUNT"] = dss1.Tables[0].Rows[b][23].ToString();

                        dr1["ITEM_AMOUNT_CODE"] = dr["INVOICE_CURRENCY"].ToString();
                        dr1["CTH_NO"] = dss1.Tables[0].Rows[b][28].ToString();

                        //scheme = dss1.Tables[0].Rows[b][35].ToString();
                        scheme = "";
                        if (scheme != "" && scheme != "00" && scheme != "0")
                        {
                            if (Convert.ToInt32(scheme) <= 9)
                            {
                                scheme = "0" + scheme;
                            }
                            scheme = Get_Scheme_Code(scheme);
                            dr1["SCHEME_CODE"] = scheme;
                            dr1["SCHEME_NOTN"] = dss1.Tables[0].Rows[b][36].ToString();
                            dr1["SCHEME_NOTN_SLNO"] = dss1.Tables[0].Rows[b][37].ToString();
                        }
                        else
                        {
                            dr1["SCHEME_CODE"] = "00 - DUTIABLE";
                            dr1["SCHEME_NOTN"] = "";
                            dr1["SCHEME_NOTN_SLNO"] = "";
                        }


                        dr1["CTH_QTY1"] = "";
                        dr1["CTH_QTY1_CODE"] = "";
                        dr1["CTH_QTY2"] = "";
                        dr1["CTH_QTY2_CODE"] = "";
                        dr1["GENEARL_DESCRIPTION"] = dss1.Tables[0].Rows[b][20].ToString();
                        dr1["MANUFACTURER"] = "N.A";
                        dr1["BRAND"] = "N.A";
                        dr1["MODEL"] = "N.A";
                        dr1["END_USE_OF_ITEM"] = "N.A";

                        //get country name from admin-ountry master
                        if (!string.IsNullOrEmpty(Edit_Country))
                        {
                            dr1["COUNTRY_OF_ORIGIN"] = Edit_Country;

                        }
                        else
                        {

                            adminmaster Admin_mas = new adminmaster();
                            Admin_mas.Ecountry_id = "0";

                            Admin_mas.Ecountry_name = dss1.Tables[0].Rows[b][37].ToString();
                            Admin_mas.Ename = "select_country_Name";
                            Admin_mas.startRowIndex = Convert.ToString("0");
                            Admin_mas.maximumRows = Convert.ToString("0");
                            DataSet ds_country = new DataSet();
                            ds_country = Admin_mas.RetrieveAll_Country_master();
                            if (ds_country.Tables.Count > 0)
                            {
                                if (ds_country.Tables[0].Rows.Count > 0)
                                {
                                    dr1["COUNTRY_OF_ORIGIN"] = Edit_Country = ds_country.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();

                                }
                            }

                        }
                        //get country name from admin-ountry master
                        dr1["ACCESSORIES"] = "";
                        dr1["PREVIOUS_BE_NO"] = "";

                        string BE_DATE = "01/01/1900";

                        dr1["PREVIOUS_BE_DATE"] = DateTime.Parse(BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                        dr1["UNIT_PRICE"] = "";
                        dr1["UNIT_CODE"] = "";
                        dr1["CUSTOMS_HOUSE"] = "";
                        dr1["PRODUCT_RITC"] = dss1.Tables[0].Rows[b][28].ToString();

                        dr1["PRODUCT_CTH"] = dss1.Tables[0].Rows[b][28].ToString();
                        dr1["PRODUCT_BCD_NOTN"] = "";
                        dr1["PRODUCT_BCD_SLNO"] = "";
                        dr1["PRODUCT_BCD_RATE"] = "";
                        dr1["PRODUCT_BCD_SPL"] = "";
                        dr1["PRODUCT_BCD_UNIT"] = "";
                        dr1["PRODUCT_BCD_SPL_TYPE"] = "";
                        dr1["PRODUCT_ADDL_DUTY_NOTN"] = "";
                        dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = "";
                        dr1["PRODUCT_ADDL_DUTY_RATE"] = "";
                        dr1["PRODUCT_EDU_CESS_NOTN"] = "";
                        dr1["PRODUCT_EDU_CESS_NOTN_SL"] = "";
                        dr1["PRODUCT_EDU_CESS_RATE"] = "";
                        dr1["PRODUCT_SEC_EDU_CESS_NOTN"] = "";
                        dr1["PRODUCT_SEC_EDU_CESS_NOTN_SL"] = "";
                        dr1["PRODUCT_SEC_EDU_CESS_RATE"] = "";
                        dr1["PRODUCT_NCD_NOTN"] = "";

                        dr1["PRODUCT_NCD_SLNO"] = "";
                        dr1["PRODUCT_NCD_RATE"] = "";
                        dr1["PRODUCT_NCD_SPL"] = "";
                        dr1["PRODUCT_NCD_UNIT"] = "";
                        dr1["PRODUCT_NCD_SPL_TYPE"] = "";
                        dr1["PRODUCT_AGGREGATE_DUTY_NOTN"] = "";
                        dr1["PRODUCT_AGGREGATE_DUTY_NOTN_SL"] = "";
                        dr1["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = "";
                        dr1["PRODUCT_SAFEGUARD_NOTN"] = "";
                        dr1["PRODUCT_SAFEGUARD_SLNO"] = "";
                        dr1["PRODUCT_SAFEGUARD_RATE"] = "";
                        dr1["PRODUCT_SAFEGUARD_SPL"] = "";
                        dr1["PRODUCT_SAFEGUARD_UNIT"] = "";
                        dr1["PRODUCT_SAFEGUARD_SPL_TYPE"] = "";
                        dr1["PRODUCT_SAPTA_NOTN"] = "";
                        dr1["PRODUCT_SAPTA_SLNO"] = "";
                        dr1["PRODUCT_SAPTA_RATE"] = "";

                        dr1["PRODUCT_TARIFF_NOTN"] = "";
                        dr1["PRODUCT_TARIFF_SLNO"] = "";
                        dr1["PRODUCT_TARIFF_QTY"] = "";
                        dr1["PRODUCT_TARIFF_AMOUNT"] = "";
                        dr1["PRODUCT_TARIFF_AMOUNT_UNIT"] = "";
                        dr1["PRODUCT_CETH"] = dss1.Tables[0].Rows[b][28].ToString();

                        dr1["PRODUCT_MRP_SL_NO"] = "";

                        if (dr1["PRODUCT_MRP_SL_NO"] != "")
                        {
                            dr1["PRODUCT_MRP_YN"] = "Y";
                            dr1["PRODUCT_MRP_AMOUNT"] = "";
                            dr1["PRODUCT_MRP_ABT_RATE"] = "";
                        }
                        else
                        {
                            dr1["PRODUCT_MRP_YN"] = "N";
                            dr1["PRODUCT_MRP_AMOUNT"] = "";
                            dr1["PRODUCT_MRP_ABT_RATE"] = "";
                        }


                        dr1["PRODUCT_CVD_NOTN"] = "";
                        dr1["PRODUCT_CVD_SLNO"] = "";
                        dr1["PRODUCT_CVD_RATE"] = "";
                        dr1["PRODUCT_CVD_SPL"] = "";
                        dr1["PRODUCT_CVD_UNIT"] = "";
                        dr1["PRODUCT_CVD_SPL_TYPE"] = "";
                        dr1["PRODUCT_CVD_EDU_CESS_RATE"] = "";

                        dr1["PRODUCT_CVD_SEC_EDU_CESS_RATE"] = "";
                        dr1["PRODUCT_ADDL5_SIA_NOTN"] = "";
                        dr1["PRODUCT_ADDL5_SIA_NOTN_SL"] = "";
                        dr1["PRODUCT_ADDL5_SIA_RATE"] = "";
                        dr1["PRODUCT_ADDL_GSI_NOTN"] = "";
                        dr1["PRODUCT_ADDL_GSI_SLNO"] = "";
                        dr1["PRODUCT_ADDL_GSI_RATE"] = "";
                        dr1["PRODUCT_ADDL_GSI_SPL"] = "";
                        dr1["PRODUCT_ADDL_GSI_UNIT"] = "";
                        dr1["PRODUCT_ADDL_GSI_SPL_TYPE"] = "";
                        dr1["PRODUCT_ADDL_SHEII_NOTN"] = "";
                        dr1["PRODUCT_ADDL_SHEII_SLNO"] = "";
                        dr1["PRODUCT_ADDL_SHEII_RATE"] = "";
                        dr1["PRODUCT_ADDL_SHEII_SPL"] = "";
                        dr1["PRODUCT_ADDL_SHEII_UNIT"] = "";
                        dr1["PRODUCT_ADDL_SHEII_TYPE"] = "";
                        dr1["PRODUCT_ADDL_TTA_NOTN"] = "";

                        dr1["PRODUCT_ADDL_TTA_SLNO"] = "";
                        dr1["PRODUCT_ADDL_TTA_RATE"] = "";
                        dr1["PRODUCT_ADDL_TTA_SPL"] = "";
                        dr1["PRODUCT_ADDL_TTA_UNIT"] = "";
                        dr1["PRODUCT_ADDL_TTA_TYPE"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_NOTN"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_SLNO"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_RATE"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_SPL"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_UNIT"] = "";
                        dr1["PRODUCT_ADDL_HEALTH_CESS_TYPE"] = "";
                        dr1["PRODUCT_CESS_NOTN"] = "";
                        dr1["PRODUCT_CESS_SLNO"] = "";

                        dr1["PRODUCT_CESS_RATE"] = "";
                        dr1["PRODUCT_CESS_SPL"] = "";
                        dr1["PRODUCT_CESS_UNIT"] = "";
                        dr1["PRODUCT_CESS_TYPE"] = "";

                        dr1["ANTI_DUMPING_NOTN"] = "";
                        dr1["ANTI_DUMPING_NOTN_SLNO"] = "";
                        dr1["CTH_SLNO"] = "";
                        dr1["CTH_SUPPLIER_SLNO"] = "";
                        dr1["CTH_QTY"] = "";
                        dr1["RSP_DUTY_STATUS"] = "";
                        dr1["RSP_SL_NO"] = "";
                        dr1["RSP_DESC"] = "";
                        dr1["RSP_QTY"] = "";
                        dr1["RSP_AMOUNT"] = "";
                        dr1["RSP_NOTN_NO"] = "";
                        dr1["RSP_NOTN_SL_NO"] = "";
                        dr1["RSP_ABT_RATE"] = "";
                        dr1["WAREHOUSE_JOBNO"] = "0";
                        dr1["WAREHOUSE_INVOICE_SLNO"] = "0";
                        dr1["WAREHOUSE_ITEM_SLNO"] = "0";
                        dr1["ASSESSABLE_VALUE"] = "";

                        dr1["DUTY_VALUE"] = "";
                        dr1["CIF_VALUE"] = "";
                        dr1["CVD_VALUE"] = "";

                        dr1["USER_ID"] = currentuser;
                        dr1["DATE_TIME"] = "";
                        dr1["STATUS"] = "N";
                        dr1["BRANCH_CODE"] = currentbranch;

                        dr1["YEAR"] = "";
                        dr1["WORKING_PERIOD"] = Working_Period;

                        dsXML.Tables[1].Rows.Add(dr1);

                        //--------------------License Details--------------------------//

                        //--------------------End License Details--------------------------//
                        b++;
                    }

                    dt = dsXML.Tables["ItemDetails"];

                    //string dd = ds.Tables[0].Rows[a][3].ToString();
                    //string ddnew = dsXML.Tables[1].Rows[a][3].ToString();
                    string ddnew = inv_no;

                    var Values = from row in dsXML.Tables["ItemDetails"].AsEnumerable()

                                 group row by new { id = row.Field<string>("INVOICE_NO") } into g
                                 select new
                                 {
                                     name_1 = g.Key.id,

                                     name_2 = g.Sum(r => r.Field<double>("ITEM_TOTAL_AMOUNT"))

                                 };
                    double mis_val = 0;
                    foreach (var drval in Values)
                    {
                        if (drval.name_1 == ddnew)
                            dr["INVOICE_VALUE"] = drval.name_2;
                        //string Total_inv_amt= dss1.Tables[0].Rows[0][39].ToString();
                        string inv_val = dr["INVOICE_VALUE"].ToString();
                        //mis_val = Convert.ToDouble(Total_inv_amt) - Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                    }


                    //-----------------Invoice Terms Calculation----------------------------//
                    string Total_inv_amt = dss1.Tables[0].Rows[0][15].ToString();
                    mis_val = Convert.ToDouble(Total_inv_amt) - Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                    dr["MIS_CHARGES"] = Convert.ToString(Math.Round(mis_val).ToString("0.00"));
                    dr["MIS_FREIGHT_CHARGES"] = "";
                    dr["MIS_INSURANCE_CHARGES"] = "";

                    if (dr["MIS_FREIGHT_CHARGES"] == "" || dr["MIS_INSURANCE_CHARGES"] == "")
                    {
                        if (Convert.ToString(dr["TERMS"]) == "FOB")
                        {

                            dr["MIS_FREIGHT_RATE"] = "20.0000";

                            double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                            cal = invoicevalue_Excel * 20 / 100;

                            dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);



                            dr["MIS_FREIGHT_CURRENCY"] = "";

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                            {
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {

                                if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds3.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }

                                }
                                else
                                {
                                    dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }



                            dr["MIS_INSURANCE_RATE"] = "1.1250";

                            double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                            cal1 = invoicevalue_Excel1 * 1.125 / 100;

                            dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);


                            dr["MIS_INSURANCE_CURRENCY"] = "";

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                            {
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {

                                if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds4.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }

                                }
                                else
                                {
                                    dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }


                        }


                        else if (Convert.ToString(dr["TERMS"]) == "CI")
                        {

                            dr["MIS_FREIGHT_RATE"] = "20.0000";

                            double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                            cal = invoicevalue_Excel * 20 / 100;

                            dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);


                            dr["MIS_FREIGHT_CURRENCY"] = "";

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                            {
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {

                                if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds3.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }
                                }
                                else
                                {
                                    dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }
                        }
                        else if (Convert.ToString(dr["TERMS"]) == "CF")
                        {

                            dr["MIS_INSURANCE_RATE"] = "1.1250";

                            double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                            cal1 = invoicevalue_Excel1 * 1.125 / 100;

                            dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);


                            dr["MIS_INSURANCE_CURRENCY"] = "";

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                            {
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {

                                if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds4.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }
                                }
                                else
                                {
                                    dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }
                        }
                        else if (Convert.ToString(dr["TERMS"]) == "CIF")
                        {

                        }
                    }
                    else
                    {
                        dr["MIS_FREIGHT_CHARGES"] = "";
                        dr["MIS_FREIGHT_RATE"] = "";
                        dr["MIS_FREIGHT_CURRENCY"] = "";

                        if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                        {
                            dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                        }
                        else
                        {

                            if (dr["MIS_FREIGHT_CURRENCY"] != "")
                            {
                                adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                adm.EWorking_Period = Working_Period;

                                ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                if (ds3.Tables[0].Rows.Count > 0)
                                {
                                    dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                }

                            }
                            else
                            {
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                        }


                        dr["MIS_INSURANCE_CHARGES"] = "";
                        dr["MIS_INSURANCE_RATE"] = "";
                        dr["MIS_INSURANCE_CURRENCY"] = "";

                        if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                        {
                            dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                        }
                        else
                        {

                            if (dr["MIS_INSURANCE_CURRENCY"] != "")
                            {
                                adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                adm.EWorking_Period = Working_Period;

                                ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                if (ds4.Tables[0].Rows.Count > 0)
                                {
                                    dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                }

                            }
                            else
                            {
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                        }
                    }

                    //---------------------------End------------------------------------//

                    dsXML.Tables[0].Rows.Add(dr);
                    a++;
                    //}

                }
                #endregion
            }

        }

        dt = dsXML.Tables["InvoiceDetails"];

        Transact.Bulk_Item_Excel_Upload(RemoveDuplicateRows(dt, "INVOICE_NO"), dsXML.Tables[1], dsXML.Tables[2], "BULK_ITEM_UPLOAD");

        if (Transact.result == 1)
        {   
            Response.Redirect(Request.RawUrl,false);
        }
        else
        {
            Alert_msg("Excel Upload occured some problem");
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

        //ViewState["inv_table"] = null;
        //ViewState["inv_table"] = dTable;

        return dTable;
    }

}
