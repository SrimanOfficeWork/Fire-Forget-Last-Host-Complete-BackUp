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

public partial class Import_JoBWise_Excel : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();
    Svb_Relation SVR = new Svb_Relation();
    Transaction Transact = new Transaction();
    DataSet dss_Rsp = new DataSet();
    UserBO objUBO = new UserBO();
    AdminMasterDetails admin = new AdminMasterDetails();
    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();

    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    DataSet ds3 = new DataSet();
    DataSet ds4 = new DataSet();
    DataSet ds_scheme = new DataSet();
    DataSet dss = new DataSet();
    DataSet ds_svb = new DataSet();
    DataSet ds_IEC = new DataSet();
    DataSet ds_supplier = new DataSet();
    DataSet ds_GENERAL = new DataSet();
    DataTable ds_IGM = new DataTable();
    DataSet ds_INVITEM = new DataSet();
    DataTable ds_CONTAINER = new DataTable();
    DataTable ds_LICENSE = new DataTable();
    DataTable ds_REIMPORT = new DataTable();
    DataTable ds_SW_INFO = new DataTable();
    DataTable ds_SW_CTRL = new DataTable();
    DataTable ds_SW_STMT = new DataTable();
    DataTable ds_INVOICE = new DataTable();
    DataTable ds_ITEM = new DataTable();
    DataTable ds_BOND = new DataTable();
    DataTable ds_CERT = new DataTable();
    DataTable ds_SUP_DOC = new DataTable();


    DataSet data = new DataSet();

    DataTable dt_gen = new DataTable();
    DataTable dt_IGM = new DataTable();
    DataTable dt_CONT = new DataTable();
    DataTable dt_REIMP = new DataTable();
    DataTable dt_SW_INFO = new DataTable();
    DataTable dt_SW_CTRL = new DataTable();
    DataTable dt_SW_STMT = new DataTable();
    DataTable dt_INV = new DataTable();
    DataTable dt_ITEM = new DataTable();
    DataTable dt_BOND = new DataTable();
    DataTable dt_CERT = new DataTable();
    DataTable dt_LICNESE = new DataTable();
    DataTable dt_SUP_DOC = new DataTable();


    public int i;
    public int MAX_ID = 0;

    public string currentuser;
    public string currentbranch;
    public string Working_Period;

    public string SELECT_TYPE, SELECT_BRANCH;
    public string EXPORT_JOBNO, EXPORT_JOBDATE;
    string alert = "";
    string Mnufactre_alert = "", GeneralDesc_Alert = "";

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public string errorFolder = "", logline = "", logFileName = "", ABTT_Rate = "";
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
    public string LoginDate, IMPORT_JOBNO, Total_Freight, Total_Insurance, _slno = "0";

    public int licen_slno = 0;
    public string file_ext = "";
    double cal, cal1, invoicevalue;
    public string a1 = "", a2 = "", a3 = "", a4 = "", a5 = "", a6 = "", INV_DATE = "", sno = "", PURCHASE_DATE = "", CONTRACT_DATE = "", LC_DATE = "", SVB_DATE = "";
    public string flag = "", inv_no = "", singlemultiple = "", inv_slno = "", CURRENCY_CODE = "", FREIGHT_EXRATE = "", INSURANCE_EXRATE = "", MISC_EXRATE = "",item_slno="";

    DataSet ds_TPD = new DataSet();
    DataSet ds_draw = new DataSet();
    DataSet ds_license = new DataSet();

    Auto_Search Auto = new Auto_Search();
    Export_Licence License = new Export_Licence();
    Export_Invoice Invoice = new Export_Invoice();

    Export_XL_Upload EXU = new Export_XL_Upload();

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt = new DataTable();
    public string COMPANY_IDD, comp_ConnectionStr;

    string JOBDATE = "", TRANSPORT_MODE = "", BE_TYPE = "", CUSTOMS_HOUSE = "", CUSTOMS_HOUSE_NAME = "", IMPORTER_NAME = "", ADDRESS1 = "", ADDRESS2 = "", ADDRESS3 = "", ADDRESS4 = "",
           ADDRESS5 = "", IEC_NO = "", BRANCH_NO = "", COUNTRY_ORIGIN = "", PORT_ORIGIN = "", PORT_SHIPMENT = "", COUNTRY_SHIPMENT = "", FILING_STATUS = "", SECTION46 = "", SECTION46_DESC = "",
           FIRSTCHECK = "", FIRSTCHECK_DESC = "", GREEN_CHANNEL = "", GREEN_CHANNEL_DESC = "", KACHHA_BE = "", KACHHA_BE_DESC = "", SECTION48 = "", SECTION48_DESC = "",
           HIGH_SEA_SALE = "", HIGH_SEA_SALE_NAME = "", HIGH_SEA_IEC = "", HIGH_SEA_BRANCH_SL_NO = "", HSS_NAME="", HSS_ADD1 = "", HSS_ADD2 = "", HSS_ADD3 = "", HSS_ADD4 = "", HSS_ADD5 = "",
           WAREHOUSE_NAME = "", WAREHOUSE_CODE = "", IMP_EXP_TYPE = "", COMMERCIAL_TAX = "", COMMERCIAL_TAX_STATENAME = "", STATECODE = "", TYPE = "", REGISTRATION_NO = "",
           EXBOND_INBOND_BE_NO = "", EXBOND_INBOND_BE_DATE = "", EXBOND_BOND_NO = "", EXBOND_BOND_DATE = "", EXBOND_WAREHOUSE_CUSTOMS = "", EXBOND_WAREHOUSE_CUSTOMS_CODE = "",
           EXBOND_NOOFPACKAGE = "", EXBOND_NOOFPACKAGE_UNITCODE = "", EXBOND_GROSS_WEIGHT = "", EXBOND_GROSS_WEIGHT_UNITCODE = "", EXBOND_DIRECT_EXBONDING = "", REMARKS = "",
           USERID = "", LoginSTATUS = "", BRANCHCODE = "", WORKINGPERIOD = "", FILE_REF_NO = "", CONTAINER_TYPE = "", JOB_STATUS = "", JOB_RELEASE = "", JOB_FILED_STATUS = "",
           MODIFIEDBY = "", MODIFIEDON = "", JOB_PREFIX = "", JOB_SUFFIX = "", JOBNO_PS = "", COMPLETED_DATE = "", ADCODE = "", UCR_NO = "", UCR_TYPE = "", PAYMENT_METHOD_CODE = "",
           PRECEDING_LEVEL = "", DOC_RECEIVED_DATE = "", AGENT_NAME = "", EXBOND_ADDL_LOAD_HSS = "", EXBOND_MISC_LOAD_RATE = "",Current_JOBID;

    string IGM_ID = "", IGM_SLNO = "", JOBNO = "", IGM_JOBDATE = "", IGM_AIRLINECODE = "", IGM_AIRLINENAME = "", IGM_FLIGHTNO_VESSELNO = "", IGM_FLIGHT_VESSELDATE = "", IGM_NO = "", IGM_DATE = "",
             IGM_MAWB_MBL = "", IGM_MAWB_MBLDATE = "", IGM_HAWB_HBLNO = "", IGM_HAWB_HBLDATE = "", IGM_NOOFPACKAGE = "", IGM_PACKAGETYPE = "", IGM_GROSSWEIGHT = "", IGM_TYPEOFWEIGHT = "",
             IGM_NETWEIGHT = "", IGM_NETWEIGHTTYPE = "", IGM_TRANSPORTMODE = "", IGM_MARKSNOS = "", IGM_GATEWAY_IGM_NO = "", IGM_GATEWAY_IGM_DATE = "", IGM_GATEWAY_PORT_CODE = "", IGM_USER_ID = "",
             IGM_DATE_TIME = "", IGM_STATUS = "", IGM_BRANCH_CODE = "", IGM_YEAR = "", IGM_WORKING_PERIOD = "", IGM_LINE_NUMBER = "", IGM_SHIPPING_LINE_NUMBER = "", IGM_VOYAGE = "", IGM_CHARGEABLE_WGT = "";

    string CONTAINERID = "", CONTAINER_IGM_SLNO = "", CONTAINER_IGM_NO = "", CONTAINER_IGM_DATE = "", CONTAINER_NO = "", SEAL_NO = "", FCL_OR_LCL = "", TRUCK_NO = "";

    string RE_IMPORT_ID = "", RE_IMPORT_SLNO = "", INVOICE_SLNO = "", ITEM_SLNO="",SB_NO = "", SB_DATE = "", PORT_EXPORT = "", SB_INVOICE_NO = "", SB_INVOICE__ITEM_NO = "", NOTN_NO = "", NOTN_SLNO = "",
           EXPORT_FREIGHT = "", EXPORT_INSURANCE = "", CUSTOMS_DUTY = "", EXCISE_DUTY = "";

    string SW_INFO_TYPE_ID = "", INFO_TYPE = "", INFO_QUALIFIER = "", INFO_CODE = "", INFO_TEXT = "", INFO_MSR = "", INFO_UQC = "", DATE_TIME = "", DEPARTMENT = "", I_U_TYPE = "";

    string SW_CONTROL_ID = "", CONTROL_TYPE_CODE = "", CONTROL_LOCATION = "", CONTROL_START_DATE = "", CONTROL_END_DATE = "", CONTROL_RESULT_CODE = "", CONTROL_RESULT_TEXT = "";

    string SW_ID = "", STMT_DECLARATION_TYPE = "", STMT_DECLARATION_NUMBER = "", STMT_DECLARATION_DATE = "", STMT_TYPE = "", STMT_CODE = "", STMT_TEXT = "";

    string INVOICE_ID = "",INVOICE_NO="", INVOICE_DATE = "", TERMS = "", INVOICE_CURRENCY = "", INVOICE_EXRATE = "", INVOICE_VALUE = "", SUPPLIER_NAME = "", SUPPLIER_ADDRESS = "", SUPPLIER_ADDRESS1 = "", SUPPLIER_ADDRESS2 = "",
            SUPPLIER_COUNTRY_NAME = "", SUPPLIER_COUNTRY_CODE = "", SUPPLIER_COUNTRY_PINCODE = "", SELLER_NAME = "", SELLER_ADDRESS = "", SELLER_ADDRESS1 = "", SELLER_ADDRESS2 = "", SELLER_COUNTRY_NAME = "",
            SELLER_COUNTRY_CODE = "", SELLERCOUNTRY_PINCODE = "", BROKER_NAME = "", BROKER_ADDRESS = "", BROKER_ADDRESS1 = "", BROKER_ADDRESS2 = "", BROKER_COUNTRY_NAME = "", BROKER_COUNTRY_CODE = "",
            BROKER_COUNTRY_PINCODE = "", MIS_CHARGES = "", MIS_RATE = "", MIS_CURRENCY = "", MIS_EXRATE = "", MIS_AGENCY_CHARGES = "", MIS_AGENCY_RATE = "", MIS_AGENCY_CURRENCY = "", MIS_AGENCY_EXRATE = "",
            MIS_DISCOUNT_CHARGES = "", MIS_DISCOUNT_RATE = "", MIS_DISCOUNT_CURRENCY = "", MIS_DISCOUNT_EXRATE = "", MIS_DISCOUNT_REASON = "", MIS_LOADING_CHARGES = "", MIS_LOADING_RATE = "", MIS_LOADING_CURRENCY = "",
            MIS_LOADING_EXRATE = "", MIS_FREIGHT_CHARGES = "", MIS_FREIGHT_RATE = "", MIS_FREIGHT_CURRENCY = "", MIS_FREIGHT_EXRATE = "", MIS_INSURANCE_CHARGES = "", MIS_INSURANCE_RATE = "",
            MIS_INSURANCE_CURRENCY = "", MIS_INSURANCE_EXRATE = "", MIS_HIGHSEASALE_CHARGES = "", MIS_HIGHSEASALE_RATE = "", MIS_HIGHSEASALE_CURRENCY = "", MIS_HIGHSEASALE_EXRATE = "", MIS_SINGLE_OR_MULITIPLE = "",
            SVB_RELATION = "", SVB_REF_NO = "", SVB_REF_DATE = "", SVB_CUSTOM_HOUSE = "", SVB_LOADING_ON = "", SVB_ASSESABLE_RATE = "", SVB_DUTY_RATE = "", SVB_ASSESABLE_STATUS = "", SVB_DUTY_STATUS = "",
            OTHER_PURCHASE_ORDER = "", OTHER_PURCHASE_ORDER_DATE = "", OTHER_CONTRACT_NO = "", OTHER_CONTRACT_DATE = "", OTHER_LOC_NO = "", OTHER_LOC_DATE = "", OTHER_NATURE_OF_TRANSACTION = "",
            OTHER_TERMS_OF_PAYMENT = "", OTHER_CONDITIONS = "", OTHER_VALUATION_METHOD = "", NON_STD_EFFECT_DT_IMP = "", NON_STD_BANKNAME = "", NON_STD_CERTIFICATE_NO = "", NON_STD_CERTIFICATE_DATE = "",
            SAP_DELIEVERY_ID = "", SHIP_DATE = "", INVOICE_LEVEL = "", COUNTRY_OF_DEPARTURE = "", REVENUEDEPOSIT_RATE = "", REVENUEDEPOSIT_ON = "", MI_FREIGHT = "", MI_INSURANCE = "", MI_MISC = "", MI_HSS = "",
            INDEV_INV_TYPE = "", TERMS_PLACE = "", THIRDPARTY_NAME = "", THIRDPARTY_ADD1 = "", THIRDPARTY_ADD2 = "", THIRDPARTY_CITY = "", T_PARTY_COUNTRY_SUB_DIV = "", T_PARTY_COUNTRY_CODE = "", T_PARTY_PIN = "",
            AUTHORIZED_ECONOMIC_OPERATOR_CODE = "", A_E_O_COUNTRY = "", AUTHORIZED_ECONOMIC_OPERATOR = "", WHETHER_BUYER_SELLER_RELATED = "",
            A_AMOUNT = "", B_AMOUNT = "", C_AMOUNT = "", D_AMOUNT = "", E_AMOUNT = "", F_AMOUNT = "", G_AMOUNT = "", H_AMOUNT = "", I_AMOUNT = "", J_AMOUNT = "", K_AMOUNT = "", L_AMOUNT = "", M_AMOUNT = "", N_AMOUNT = "", TOTAL_OTHER_AMOUNT = "";

    string ITEM_ID = "", ITEM_DESCRIPTION = "", ITEM_QTY = "", ITEM_QTY_CODE = "", ITEM_UNIT_PRICE = "", ITEM_UNIT_CODE = "", ITEM_TOTAL_AMOUNT = "", ITEM_AMOUNT_CODE = "", CTH_NO = "", SCHEME_CODE = "",
           SCHEME_NOTN = "", SCHEME_NOTN_SLNO = "", CTH_QTY1 = "", CTH_QTY1_CODE = "", CTH_QTY2 = "", CTH_QTY2_CODE = "", GENEARL_DESCRIPTION = "", MANUFACTURER = "", BRAND = "", MODEL = "", END_USE_OF_ITEM = "",
           COUNTRY_OF_ORIGIN = "", ACCESSORIES = "", PREVIOUS_BE_NO = "", PREVIOUS_BE_DATE = "", UNIT_PRICE = "", UNIT_CODE = "",  PRODUCT_RITC = "", PRODUCT_CTH = "",
           PRODUCT_BCD_NOTN = "", PRODUCT_BCD_SLNO = "", PRODUCT_BCD_RATE = "", PRODUCT_BCD_SPL = "", PRODUCT_BCD_UNIT = "", PRODUCT_BCD_SPL_TYPE = "",
           PRODUCT_ADDL_DUTY_NOTN = "", PRODUCT_ADDL_DUTY_NOTN_SL = "", PRODUCT_ADDL_DUTY_RATE = "", PRODUCT_EDU_CESS_NOTN = "", PRODUCT_EDU_CESS_NOTN_SL = "", PRODUCT_EDU_CESS_RATE = "",
           PRODUCT_SEC_EDU_CESS_NOTN = "", PRODUCT_SEC_EDU_CESS_NOTN_SL = "", PRODUCT_SEC_EDU_CESS_RATE = "", PRODUCT_NCD_NOTN = "", PRODUCT_NCD_SLNO = "", PRODUCT_NCD_RATE = "", PRODUCT_NCD_SPL = "",
           PRODUCT_NCD_UNIT = "", PRODUCT_NCD_SPL_TYPE = "", PRODUCT_AGGREGATE_DUTY_NOTN = "", PRODUCT_AGGREGATE_DUTY_NOTN_SL = "", PRODUCT_AGGREGATE_DUTY_NOTN_RATE = "",
           PRODUCT_SAFEGUARD_NOTN = "", PRODUCT_SAFEGUARD_SLNO = "", PRODUCT_SAFEGUARD_RATE = "", PRODUCT_SAFEGUARD_SPL = "", PRODUCT_SAFEGUARD_UNIT = "", PRODUCT_SAFEGUARD_SPL_TYPE = "",
           PRODUCT_SAPTA_NOTN = "", PRODUCT_SAPTA_SLNO = "", PRODUCT_SAPTA_RATE = "", PRODUCT_TARIFF_NOTN = "", PRODUCT_TARIFF_SLNO = "", PRODUCT_TARIFF_QTY = "", PRODUCT_TARIFF_AMOUNT = "",
           PRODUCT_TARIFF_AMOUNT_UNIT = "", PRODUCT_CETH = "", PRODUCT_MRP_YN = "", PRODUCT_MRP_SL_NO = "", PRODUCT_MRP_AMOUNT = "", PRODUCT_MRP_ABT_RATE = "", PRODUCT_CVD_NOTN = "",
           PRODUCT_CVD_SLNO = "", PRODUCT_CVD_RATE = "", PRODUCT_CVD_SPL = "", PRODUCT_CVD_UNIT = "", PRODUCT_CVD_SPL_TYPE = "", PRODUCT_CVD_EDU_CESS_RATE = "", PRODUCT_CVD_SEC_EDU_CESS_RATE = "",
           PRODUCT_ADDL5_SIA_NOTN = "", PRODUCT_ADDL5_SIA_NOTN_SL = "", PRODUCT_ADDL5_SIA_RATE = "", PRODUCT_ADDL_GSI_NOTN = "", PRODUCT_ADDL_GSI_SLNO = "", PRODUCT_ADDL_GSI_RATE = "",
           PRODUCT_ADDL_GSI_SPL = "", PRODUCT_ADDL_GSI_UNIT = "", PRODUCT_ADDL_GSI_SPL_TYPE = "", PRODUCT_ADDL_SHEII_NOTN = "", PRODUCT_ADDL_SHEII_SLNO = "", PRODUCT_ADDL_SHEII_RATE = "",
           PRODUCT_ADDL_SHEII_SPL = "", PRODUCT_ADDL_SHEII_UNIT = "", PRODUCT_ADDL_SHEII_TYPE = "", PRODUCT_ADDL_TTA_NOTN = "", PRODUCT_ADDL_TTA_SLNO = "", PRODUCT_ADDL_TTA_RATE = "",
           PRODUCT_ADDL_TTA_SPL = "", PRODUCT_ADDL_TTA_UNIT = "", PRODUCT_ADDL_TTA_TYPE = "", PRODUCT_ADDL_HEALTH_CESS_NOTN = "", PRODUCT_ADDL_HEALTH_CESS_SLNO = "", PRODUCT_ADDL_HEALTH_CESS_RATE = "",
           PRODUCT_ADDL_HEALTH_CESS_SPL = "", PRODUCT_ADDL_HEALTH_CESS_UNIT = "", PRODUCT_ADDL_HEALTH_CESS_TYPE = "", PRODUCT_CESS_NOTN = "", PRODUCT_CESS_SLNO = "", PRODUCT_CESS_RATE = "",
           PRODUCT_CESS_SPL = "", PRODUCT_CESS_UNIT = "", PRODUCT_CESS_TYPE = "", ANTI_DUMPING_NOTN = "", ANTI_DUMPING_NOTN_SLNO = "", CTH_SLNO = "", CTH_SUPPLIER_SLNO = "", CTH_QTY = "",
           RSP_DUTY_STATUS = "", RSP_SL_NO = "", RSP_DESC = "", RSP_QTY = "", RSP_AMOUNT = "", RSP_NOTN_NO = "", RSP_NOTN_SL_NO = "", RSP_ABT_RATE = "", WAREHOUSE_JOBNO = "", WAREHOUSE_INVOICE_SLNO = "",
           WAREHOUSE_ITEM_SLNO = "", ASSESSABLE_VALUE = "", DUTY_VALUE = "", CIF_VALUE = "", CVD_VALUE = "", BASIC_VALUE = "", CEC_VALUE = "", CHEC_VALUE = "", ADD_DUTY_VALUE = "",
           CETH_CVD_EDU_CESS_SL = "", CETH_CVD_EDU_CESS_RATE = "", CETH_CVD_SEC_EDU_CESS_SL = "", CETH_CVD_SEC_EDU_CESS_RATE = "", PRODUCT_OTHER_DUTY_NOTN = "", PRODUCT_OTHER_DUTY_SLNO = "",
           PRODUCT_OTHER_DUTY_RATE = "", PRODUCT_OTHER_DUTY_SPL = "", PRODUCT_OTHER_DUTY_UNIT = "", PRODUCT_OTHER_DUTY_TYPE = "", INDIVITUAL_FREIGHT_AMOUNT = "", INDIVITUAL_INSURANCE_AMOUNT = "",
           INDIVITUAL_MISC_AMOUNT = "",  INDIVITUAL_EDU_CESS_AMT = "", INDIVITUAL_SEC_HIGHER_CESS_AMT = "", INDIVITUAL_LANDING_CHARGE = "", CHECKLIST_BCD_RATE = "", CHECKLIST_CVD_RATE = "",
           CHECKLIST_ADDL_DUTY_RATE = "", INDEV_RACK_TYPE = "", MERIT_DUTY_VALUE = "", RSP_APPLICABLE = "", CENTRAL_EXCISE_FLAG = "", MANUFACTURER_PRODUCER = "",
           M_P_GROWER_CODE = "", M_P_GROWER_ADD1 = "", M_P_GROWER_ADD2 = "", M_P_GROWER_CITY = "", M_P_GROWER_COUNTRY_SUBDIV = "", M_P_GROWER_PIN = "", M_P_GROWER_COUNTRY = "",
           SOURCE_COUNTRY = "", TRANSIT_COUNTRY = "", ACCESSORY_STATUS = "", INFRA_CESS_NOTN = "", INFRA_CESS_NOTN_SL = "", INFRA_CESS_NOTN_RATE = "", MERIT_BASIC_VALUE = "",
           MERIT_CVD_VALUE = "", MERIT_CEC_VALUE = "", MERIT_CHEC_VALUE = "", MERIT_ADD_DUTY_VALUE = "", MERIT_NOTN_BASIC_VALUE = "", MERIT_NOTN_CVD_VALUE = "", MERIT_NOTN_CEC_VALUE = "",
           MERIT_NOTN_CHEC_VALUE = "", MERIT_NOTN_ADD_DUTY_VALUE = "", MERIT_NOTN_CESS_VALUE = "", MERIT_NOTN_NCD_VALUE = "", INDIVITUAL_HSS_AMOUNT = "";

    string IGST_LEVY_NOTN = "", IGST_LEVY_SLNO = "", IGST_LEVY_RATE = "", IGST_LEVY_SPL = "", IGST_LEVY_UNIT = "", IGST_LEVY_SPL_TYPE = "", IGST_LEVY_EXCEPTION_NOTN = "", IGST_LEVY_EXCEPTION_SLNO = "",
            IGST_LEVY_EXCEPTION_RATE = "", IGST_LEVY_COMPENSATION_CESS_NOTN = "", IGST_LEVY_COMPENSATION_CESS_SLNO = "", IGST_LEVY_COMPENSATION_CESS_RATE = "", IGST_LEVY_COMPENSATION_CESS_SPL = "",
            IGST_LEVY_COMPENSATION_CESS_UNIT = "", IGST_LEVY_COMPENSATION_CESS_SPL_TYPE = "", IGST_LEVY_EXCEPTION_CC_NOTN = "", IGST_LEVY_EXCEPTION_CC_SLNO = "", IGST_LEVY_EXCEPTION_CC_RATE = "",
            LEVY_EXCEMPTION_NOTN_TYPE = "", LEVY_EXCEPTION_CC_NOTN_TYPE = "", CHECKLIST_IGST_LEVY_AMOUNT = "", CHECKLIST_COMPENSATION_CC_AMOUNT = "";

    string BONDID = "", BOND_NO = "", BOND_TYPE = "", BOND_LOCATION = "";

    string CERTIFICATEID = "", CERTIFICATE_NO = "", CERTIFICATE_DATE = "", CERTIFICATE_TYPE = "";

    string LICENSE_ID = "", LICENSE_SLNO = "",  REGISTRATION_DATE = "", EXCEMPTION = "", DEBIT_AMT = "", DEBIT_QTY = "", UNIT_QTY = "", LICENSE_ITEM_NO = "",
           PORT_OF_LICENSE = "", DEBIT_DUTY = "", LICENSE_NO = "", LICENSE_DATE = "", TOTAL_CIF_VALUE = "", TOTAL_DEBIT_DUTY = "", ENTRY_DEBIT_DUTY = "", LIC_DESC="";

    string DECLARATION_TYPE = "", IMAGE_REF_NUMBER = "", DOC_TYPE_CODE = "", DOC_ISSUING_PARTY_CODE = "", DOC_ISSUING_PARTY_NAME = "", DOC_ISSUING_PARTY_NAME_ADD1 = "", DOC_ISSUING_PARTY_NAME_ADD2 = "", DOC_ISSUING_PARTY_CITY = "",
          DOC_ISSUING_PARTY_PIN = "", DOC_REF_NUMBER = "", PLACE_OF_ISSUE = "", DOC_ISSUE_DATE = "", DOC_EXPIRY_DATE = "", BENEFICIARY_PARTY_CODE = "", BENEFICIARY_PARTY_NAME = "", BENEFICIARY_PARTY_ADDRESS1 = "",
          BENEFICIARY_PARTY_ADDRESS2 = "", BENEFICIARY_PARTY_CITY = "", BENEFICIARY_PARTY_PIN = "", FILE_TYPE = "", DOC_TYPE = "";


    public string USER_ID = "",  STATUS = "", BRANCH_CODE = "", YEAR = "", WORKING_PERIOD = "";
                
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        txtCountryOrigin.Focus();
        hdfTransport_mode.Value = Session["Transport_Mode_Port"].ToString();

        if (Session["Jobno_Excel"] != null || Session["Jobno_Excel"] != null)
        {
            IMPORT_JOBNO = Session["Jobno_Excel"].ToString();
        }
        //else
        //{
        //    Response.Write("<script>window.parent.document.getElementById('General').click();</script>");
        //}
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
         *   * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Import_Excel");
        if (!Page.IsPostBack)
        {

        }
        
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gv_Item_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }


    protected void gv_Gen_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }

    protected void gv_Gen_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
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

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //if (fileuploadExcel.FileName != "")
        //{

        if (txt_SupplierName_Gen.Text != "")
        {
            if (txtCountryOrigin.Text != "")
            {
                if (txtPortShipment.Text != "")
                {
                    DataSet d = new DataSet();

                    objUBO.IEC_NO = IMPORT_JOBNO;
                    objUBO.BRANCH_NO = "";
                    objUBO.Ename = "IMPORT_Excel_Aval";
                    objUBO.WORKING_PERIOD = SELECT_BRANCH;
                    d = xl.Bind_Import_General_IEC_No(objUBO);
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
                    Alert_msg("Select Port Name");
                }
            }
            else
            {
                Alert_msg("Select Country Name");
            }
        }
        else
        {
            Alert_msg("Select Supplier Name");
            txt_SupplierName_Gen.Focus();
        }
        //}
    }

    public string Get_JOBID()
    {
        DataSet d = new DataSet();
        objUBO.IEC_NO = IMPORT_JOBNO;
        objUBO.BRANCH_NO = "";
        objUBO.Ename = "Get_JOBID";
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        d = xl.Bind_Import_General_IEC_No(objUBO);
        if (d.Tables[0].Rows.Count > 0)
        {
            Current_JOBID = d.Tables[0].Rows[0]["JOBID"].ToString();
        }
        return Current_JOBID;
    }

    public void JobNo_Prefix_Sufix()
    {
        Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
        DataSet dats = new DataSet();
        JPS.Branch = SELECT_BRANCH;
        JPS.Tr_mode = hdfTransport_mode.Value;
        JPS.Ename = "Imp_gen_select";
        dats = JPS.Job_prefix_Suffix_Select();

        if (Session["COMPANY_LICENSE"] != null)
        {
            if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247")
            {
                if (dats.Tables[0].Rows.Count > 0)
                {
                    if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        JOBNO_PS = IMPORT_JOBNO + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        JOB_PREFIX = string.Empty;
                        // hdsuffix.Value = "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        JOB_SUFFIX = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();

                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        JOBNO_PS = ((dats.Tables[0].Rows[0][0].ToString() + IMPORT_JOBNO).TrimEnd()).TrimStart();
                        JOB_PREFIX = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        JOB_SUFFIX = string.Empty;
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        JOBNO_PS = ((dats.Tables[0].Rows[0][0].ToString() + IMPORT_JOBNO + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        JOB_PREFIX = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        // hdsuffix.Value = "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        JOB_SUFFIX = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        JOBNO_PS = IMPORT_JOBNO;
                        JOB_PREFIX = string.Empty;
                        JOB_SUFFIX = string.Empty;
                    }
                }
                else
                {
                    JOBNO_PS = IMPORT_JOBNO;
                    JOB_PREFIX = string.Empty;
                    JOB_SUFFIX = string.Empty;
                }
            }
            else
            {
                if (dats.Tables[0].Rows.Count > 0)
                {
                    if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        JOBNO_PS = IMPORT_JOBNO + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        JOB_PREFIX = string.Empty;
                        // hdsuffix.Value = "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        JOB_SUFFIX = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        JOBNO_PS= ((dats.Tables[0].Rows[0][0].ToString() + "/" + IMPORT_JOBNO.TrimEnd())).TrimStart();
                        // hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString() + "/").TrimEnd()).TrimStart();
                        JOB_PREFIX = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        JOB_SUFFIX = string.Empty;
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        JOBNO_PS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + IMPORT_JOBNO + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        //  hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString() + "/").TrimEnd()).TrimStart();
                        // hdsuffix.Value = "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();

                        JOB_PREFIX = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        JOB_SUFFIX = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        JOBNO_PS = IMPORT_JOBNO;
                        JOB_PREFIX = string.Empty;
                        JOB_SUFFIX = string.Empty;
                    }
                }
                else
                {
                    JOBNO_PS = IMPORT_JOBNO;
                    JOB_PREFIX = string.Empty;
                    JOB_SUFFIX = string.Empty;
                }
            }
        }
    }

    public void btnyes_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        objUBO.IEC_NO = IMPORT_JOBNO;
        objUBO.BRANCH_NO = "";
        objUBO.Ename = "Delete_Excel";
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        ds = xl.Bind_Import_General_IEC_No(objUBO);
        i = xl.result;

        if (i == 1)
        {
            Alert_msg("Job Deleted Successfully");
            MP_U.Hide();
        }
        else
        {
            Alert_msg("Not Deleted ur Old Job");
        }
    }

    public void Get_SAPTA_Notification_RATE(DataTable Dt_Sapta)
    {
        adminmaster admin = new adminmaster();
        DataSet ds_Sapta = new DataSet();
        Dt_Sapta.Columns.Add("RATE");

        if (Dt_Sapta.Rows.Count > 0)
        {
            for (int i = 0; i <= Dt_Sapta.Rows.Count - 1; i++)
            {
                //ITEM_RITCNO += Dt_Sapta.Rows[i]["PRODUCT_CTH"].ToString() + ",";

                admin.ENotification_Customs_id = Dt_Sapta.Rows[i]["NOTN_Type"].ToString();
                admin.ENotification_Customs_code = Dt_Sapta.Rows[i]["NOTN_No"].ToString();
                admin.ENotification_Customs_name = Dt_Sapta.Rows[i]["NOTN_SLNo"].ToString();
                admin.Ename = "Get_SAPTA_NOTN_RATE";

                ds_Sapta = admin.RetrieveAll_Notification_Customs_master();

                if (ds_Sapta.Tables[0].Rows.Count > 0)
                {
                    Dt_Sapta.Rows[i][3] = ds_Sapta.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                }
                ViewState["get_SAPTA_RATE_ALL"] = Dt_Sapta;

            }
        }
    }

    public void Get_ITEM_DESC_SEARCH_SPECIAL_CHARACTERS(DataTable dt_itmdesc, string Field_Name, string Alert_Type)
    {
        for (int i = 0; i <= dt_itmdesc.Rows.Count - 1; i++)
        {
            objUBO.ITEM_DESCRIPTION = dt_itmdesc.Rows[i][Field_Name].ToString();
            objUBO.Ename = "ITEM_DESC_special_char_Search";
            ds = Transact.Bind_Import_ExcelUpload_SpecialChars(objUBO);
            int aa = Transact.result;

            if (aa == 1)
            {
                string invslno = dt_itmdesc.Rows[i]["INVOICE_SLNO"].ToString();
                string itemslno = dt_itmdesc.Rows[i]["ITEM_SLNO"].ToString();
                if (Alert_Type == "Desc_Alert")
                {
                    alert += "      Invoice :" + invslno + "                    " + "ItemSlNo : " + itemslno + "*";
                }
                if (Alert_Type == "GeneralDesc_Alert")
                {
                    GeneralDesc_Alert += "      Invoice :" + invslno + "                    " + "ItemSlNo : " + itemslno + "*";
                }
                if (Alert_Type == "Mnufactre_alert")
                {
                    Mnufactre_alert += "      Invoice :" + invslno + "                    " + "ItemSlNo : " + itemslno + "*";
                }
            }
        }
    }

    public void IEC_INSERT_UPDATE(string IECNO, string BRNO, string IEC_NAME, string ADD1, string ADD2, string ADD3, string ADD4, string ADD5, string TYPE, string STATECODE, string MARKSNOS)
    {
        erm.IMP_EXP_ID = "";
        erm.IMP_EXP_NAME = IEC_NAME;
        erm.IMP_EXP_IECNO = IECNO;
        erm.IMP_EXP_BRSLNO = BRNO;
        if (TYPE == "GOVERNMENT")
        {
            erm.IMP_EXP_TYPE = "G";
        }
        else
        {
            erm.IMP_EXP_TYPE = "P";
        }
        erm.IMP_EXP_ADD1 = ADD1;
        erm.IMP_EXP_ADD2 = ADD2;
        erm.IMP_EXP_ADD3 = ADD3;
        erm.IMP_EXP_ADD4 = ADD4;
        erm.IMP_EXP_PIN_CODE = ADD5;
        erm.IMP_EXP_CONTACT_PERSON = "";
        erm.IMP_EXP_PHONE = "";

        erm.IMP_EXP_FAX = "";
        erm.IMP_EXP_EMAIL = "";
        erm.IMP_EXP_BINNO = "";
        erm.IMP_EXP_REMARKS = "";
        erm.IMP_EXP_DRAWBACK_AC_NO = "";
        erm.IMP_EXP_PAN_NO = "";

        //STANDARD_TYPE = ViewState["STANDARD_TYPE"].ToString();

        //if (STANDARD_TYPE == "Non_STD")
        //{
        //    erm.STANDARD_TYPE = STANDARD_TYPE;
        //}
        //else
        //{
        erm.STANDARD_TYPE = null;
        //}

        erm.TIN_NO = "";
        erm.STATE_CODE = STATECODE;

        erm.USER_ID = currentuser;
        erm.BRANCH_CODE = currentbranch;
        erm.flag = "S";
        erm.YEAR = "";
        erm.EWorking_Period = Working_Period;
        erm.EXP_STR_YN = "";
        //string Type_Of_Exporter = "";

        //if (ddlType_Exp.SelectedItem.Text == "Manufacturer - ( F )")
        //{
        //Type_Of_Exporter = "F";
        //}
        //else
        //{
        //    Type_Of_Exporter = "R";
        //}
        erm.TYPE_OF_EXPORTER = "F";
        erm.MARKS_NO =MARKSNOS;

        erm.COMMERCIAL_DETAILS_STATUS = "N";
        erm.COMMERCIAL_TAX_STATENAME = "";
        erm.COMMERCIAL_TAX_STATECODE = "";
        erm.COMMERCIAL_TAX_TYPE = "";
        erm.COMMERCIAL_TAX_REGISTRATION_NO = "";

        i = erm.Imp_Exp_Master_Insert_update_STD();
    }

    public DataSet Bind_General_Details(DataTable General_data)
    {
        #region dt_gen
        dt_gen.Columns.Add("JOBID");
        dt_gen.Columns.Add("JOBNO");
        dt_gen.Columns.Add("JOBDATE");
        dt_gen.Columns.Add("TRANSPORT_MODE");
        dt_gen.Columns.Add("BE_TYPE");
        dt_gen.Columns.Add("CUSTOMS_HOUSE");
        dt_gen.Columns.Add("CUSTOMS_HOUSE_NAME");
        dt_gen.Columns.Add("IMPORTER_NAME");
        dt_gen.Columns.Add("ADDRESS1");
        dt_gen.Columns.Add("ADDRESS2");
        dt_gen.Columns.Add("ADDRESS3");
        dt_gen.Columns.Add("ADDRESS4");
        dt_gen.Columns.Add("ADDRESS5");
        dt_gen.Columns.Add("IEC_NO");
        dt_gen.Columns.Add("BRANCH_NO");
        dt_gen.Columns.Add("COUNTRY_ORIGIN");
        dt_gen.Columns.Add("PORT_ORIGIN");
        dt_gen.Columns.Add("PORT_SHIPMENT");
        dt_gen.Columns.Add("COUNTRY_SHIPMENT");
        dt_gen.Columns.Add("FILING_STATUS");
        dt_gen.Columns.Add("SECTION46");
        dt_gen.Columns.Add("SECTION46_DESC");
        dt_gen.Columns.Add("FIRSTCHECK");
        dt_gen.Columns.Add("FIRSTCHECK_DESC");
        dt_gen.Columns.Add("GREEN_CHANNEL");
        dt_gen.Columns.Add("GREEN_CHANNEL_DESC");
        dt_gen.Columns.Add("KACHHA_BE");
        dt_gen.Columns.Add("KACHHA_BE_DESC");
        dt_gen.Columns.Add("SECTION48");
        dt_gen.Columns.Add("SECTION48_DESC");
        dt_gen.Columns.Add("HIGH_SEA_SALE");
        dt_gen.Columns.Add("HIGH_SEA_SALE_NAME");
        dt_gen.Columns.Add("HIGH_SEA_IEC");
        dt_gen.Columns.Add("HIGH_SEA_BRANCH_SL_NO");
        dt_gen.Columns.Add("HSS_ADD1");
        dt_gen.Columns.Add("HSS_ADD2");
        dt_gen.Columns.Add("HSS_ADD3");
        dt_gen.Columns.Add("HSS_ADD4");
        dt_gen.Columns.Add("HSS_ADD5");
        dt_gen.Columns.Add("WAREHOUSE_NAME");
        dt_gen.Columns.Add("WAREHOUSE_CODE");
        dt_gen.Columns.Add("IMP_EXP_TYPE");
        dt_gen.Columns.Add("COMMERCIAL_DETAILS_STATUS");
        dt_gen.Columns.Add("COMMERCIAL_TAX_STATENAME");
        dt_gen.Columns.Add("COMMERCIAL_TAX_STATECODE");
        dt_gen.Columns.Add("COMMERCIAL_TAX_TYPE");
        dt_gen.Columns.Add("COMMERCIAL_TAX_REGISTRATION_NO");
        dt_gen.Columns.Add("EXBOND_INBOND_BE_NO");
        dt_gen.Columns.Add("EXBOND_INBOND_BE_DATE");
        dt_gen.Columns.Add("EXBOND_BOND_NO");
        dt_gen.Columns.Add("EXBOND_BOND_DATE");
        dt_gen.Columns.Add("EXBOND_WAREHOUSE_CUSTOMS");
        dt_gen.Columns.Add("EXBOND_WAREHOUSE_CUSTOMS_CODE");
        dt_gen.Columns.Add("EXBOND_NOOFPACKAGE");
        dt_gen.Columns.Add("EXBOND_NOOFPACKAGE_UNITCODE");
        dt_gen.Columns.Add("EXBOND_GROSS_WEIGHT");
        dt_gen.Columns.Add("EXBOND_GROSS_WEIGHT_UNITCODE");
        dt_gen.Columns.Add("EXBOND_DIRECT_EXBONDING");
        dt_gen.Columns.Add("REMARKS");
        dt_gen.Columns.Add("USERID");
        dt_gen.Columns.Add("LoginDate");
        dt_gen.Columns.Add("LoginSTATUS");
        dt_gen.Columns.Add("BRANCHCODE");
        dt_gen.Columns.Add("WORKINGPERIOD");
        dt_gen.Columns.Add("FILE_REF_NO");
        dt_gen.Columns.Add("CONTAINER_TYPE");
        dt_gen.Columns.Add("JOB_STATUS");
        dt_gen.Columns.Add("JOB_RELEASE");
        dt_gen.Columns.Add("JOB_FILED_STATUS");
        dt_gen.Columns.Add("MODIFIEDBY");
        dt_gen.Columns.Add("MODIFIEDON");
        dt_gen.Columns.Add("JOB_PREFIX");
        dt_gen.Columns.Add("JOB_SUFFIX");
        dt_gen.Columns.Add("JOBNO_PS");
        dt_gen.Columns.Add("COMPLETED_DATE");
        dt_gen.Columns.Add("ADCODE");
        dt_gen.Columns.Add("UCR_NO");
        dt_gen.Columns.Add("UCR_TYPE");
        dt_gen.Columns.Add("PAYMENT_METHOD_CODE");
        dt_gen.Columns.Add("PRECEDING_LEVEL");
        dt_gen.Columns.Add("DOC_RECEIVED_DATE");
        dt_gen.Columns.Add("AGENT_NAME");
        dt_gen.Columns.Add("EXBOND_ADDL_LOAD_HSS");
        dt_gen.Columns.Add("EXBOND_MISC_LOAD_RATE");
        //dt_gen.Columns.Add("GSTN_TYPE");
        //dt_gen.Columns.Add("GSTN_ID");
        //dt_gen.Columns.Add("PARTY_REF_NO");


        #endregion dt_gen

        int xx;

        JOBDATE = General_data.Rows[0][0].ToString();
        TRANSPORT_MODE = General_data.Rows[0][1].ToString();
        BE_TYPE = General_data.Rows[0][2].ToString();
        if (General_data.Rows[0][3].ToString() != "")
        {
            CUSTOMS_HOUSE = General_data.Rows[0][3].ToString();
        }
        else
        {
            CUSTOMS_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();
        }
        CONTAINER_TYPE = General_data.Rows[0][4].ToString();
        FILING_STATUS = General_data.Rows[0][5].ToString();
        FILE_REF_NO = General_data.Rows[0][6].ToString();
        IEC_NO = General_data.Rows[0][7].ToString();
        BRANCH_NO = General_data.Rows[0][8].ToString();
        IMPORTER_NAME = General_data.Rows[0][9].ToString();
        ADDRESS1 = General_data.Rows[0][10].ToString();

        COUNTRY_ORIGIN = General_data.Rows[0][16].ToString();
        PORT_ORIGIN = General_data.Rows[0][17].ToString();
        COUNTRY_SHIPMENT = General_data.Rows[0][18].ToString();
        PORT_SHIPMENT = General_data.Rows[0][19].ToString();

        if (COUNTRY_ORIGIN != "")
        {
            txtCountryOrigin.Text = COUNTRY_ORIGIN;
        }
        else
        {
            COUNTRY_ORIGIN = txtCountryOrigin.Text;
        }

        if (COUNTRY_SHIPMENT != "")
        {
           
        }
        else
        {
            COUNTRY_SHIPMENT = COUNTRY_ORIGIN;
        }

        if (PORT_ORIGIN != "")
        {
            txtPortShipment.Text = PORT_ORIGIN;
        }
        else
        {
            PORT_ORIGIN = txtPortShipment.Text;
        }

        if (PORT_SHIPMENT != "")
        {

        }
        else
        {
            PORT_SHIPMENT = PORT_ORIGIN;
        }

        SECTION46_DESC = General_data.Rows[0][20].ToString();
        FIRSTCHECK_DESC = General_data.Rows[0][21].ToString();
        GREEN_CHANNEL_DESC = General_data.Rows[0][22].ToString();
        KACHHA_BE_DESC = General_data.Rows[0][23].ToString();
        SECTION48_DESC = General_data.Rows[0][24].ToString();
        HIGH_SEA_IEC = General_data.Rows[0][25].ToString();
        HIGH_SEA_BRANCH_SL_NO = General_data.Rows[0][26].ToString();
        PRECEDING_LEVEL = General_data.Rows[0][33].ToString();

        

        //WAREHOUSE_CODE = General_data.Rows[0][33].ToString();
        if (General_data.Rows[0][34].ToString().Contains('-'))
        {
            string[] aa = General_data.Rows[0][34].ToString().Split('-');
            WAREHOUSE_CODE = aa[0].TrimEnd();
        }
        else
        {
            WAREHOUSE_CODE = General_data.Rows[0][34].ToString();
        }
        ADCODE = General_data.Rows[0][15].ToString();

        if (SECTION46_DESC != "")
        {
            SECTION46 = "Y";
        }
        else
        {
            SECTION46 = "N";
        }
        if (FIRSTCHECK_DESC != "")
        {
            FIRSTCHECK = "Y";
        }
        else
        {
            FIRSTCHECK = "N";
        }
        if (GREEN_CHANNEL_DESC != "")
        {
            GREEN_CHANNEL = "Y";
        }
        else
        {
            GREEN_CHANNEL = "N";
        }
        if (KACHHA_BE_DESC != "")
        {
            KACHHA_BE = "Y";
        }
        else
        {
            KACHHA_BE = "N";
        }
        if (SECTION48_DESC != "")
        {
            SECTION48 = "Y";
        }
        else
        {
            SECTION48 = "N";
        }

        if (BE_TYPE == "Ex-Bond")
        {
            WAREHOUSE_NAME = "Yes";
        }
        else
        {
            WAREHOUSE_NAME = "No";
        }
        ds_IEC.Clear();

         xx = Check_Avail_IEC_Master(IEC_NO, BRANCH_NO);

         if (xx == 1)
         {
             //if (currentuser != "AURIONPRO")
             //{
                 if (ADDRESS1 == "")
                 {
                     if (IEC_NO != "" && BRANCH_NO != "")
                     {
                         ds_IEC = Get_Importer_HSS_Details(IEC_NO, BRANCH_NO);

                         if (ds_IEC.Tables[0].Rows.Count > 0)
                         {
                             IMPORTER_NAME = ds_IEC.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                             ADDRESS1 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                             ADDRESS2 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                             ADDRESS3 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                             ADDRESS4 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                             ADDRESS5 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                             COMMERCIAL_TAX = ds_IEC.Tables[0].Rows[0]["M_COMMERCIAL_DETAILS_STATUS"].ToString();
                             COMMERCIAL_TAX_STATENAME = ds_IEC.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
                             STATECODE = ds_IEC.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATECODE"].ToString();
                             REGISTRATION_NO = ds_IEC.Tables[0].Rows[0]["M_COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                             TYPE = ds_IEC.Tables[0].Rows[0]["M_COMMERCIAL_TAX_TYPE"].ToString();
                         }
                     }
                 //}
             }
             else
             {
                 ADDRESS1 = General_data.Rows[0][10].ToString();
                 ADDRESS2 = General_data.Rows[0][11].ToString();
                 ADDRESS3 = General_data.Rows[0][12].ToString();
                 ADDRESS4 = General_data.Rows[0][13].ToString();
                 ADDRESS5 = General_data.Rows[0][14].ToString();
             }

         }
         else
         {
             IEC_INSERT_UPDATE(IEC_NO, BRANCH_NO, IMPORTER_NAME, ADDRESS1, ADDRESS2, ADDRESS3, ADDRESS4, ADDRESS5, "P", "", "");
             ADDRESS1 = General_data.Rows[0][10].ToString();
             ADDRESS2 = General_data.Rows[0][11].ToString();
             ADDRESS3 = General_data.Rows[0][12].ToString();
             ADDRESS4 = General_data.Rows[0][13].ToString();
             ADDRESS5 = General_data.Rows[0][14].ToString();
         }

         if (currentuser == "AURIONPRO")
         {
             ADDRESS1 = General_data.Rows[0][10].ToString();
             ADDRESS2 = General_data.Rows[0][11].ToString();
             ADDRESS3 = General_data.Rows[0][12].ToString();
             ADDRESS4 = General_data.Rows[0][13].ToString();
             ADDRESS5 = General_data.Rows[0][14].ToString();
         }

         if (COMMERCIAL_TAX != "Y")
         {
              COMMERCIAL_TAX = "Y";

             //COMMERCIAL_TAX = General_data.Rows[0]["COMMERCIAL_TAX"].ToString();
              STATECODE = General_data.Rows[0][35].ToString();
             if (STATECODE != "")
             {
                 if (STATECODE.Contains('-'))
                 {
                     string[] p = STATECODE.Split('-');
                     string p1 = p[0];
                     string p2 = p[1];

                     COMMERCIAL_TAX_STATENAME = p2.Trim();
                     STATECODE = p1.Trim();
                 }
             }

             TYPE = General_data.Rows[0][36].ToString();
             if (TYPE.Contains('-'))
             {
                 string[] p = TYPE.Split('-');
                 string p1 = p[0];
                 string p2 = p[1];

                 TYPE = p1.Trim();
             }

             REGISTRATION_NO = General_data.Rows[0][37].ToString();
            
         }
      
        ds_IEC.Clear();

        HSS_NAME = General_data.Rows[0][27].ToString();
        HSS_ADD1 = General_data.Rows[0][28].ToString();

        xx = Check_Avail_IEC_Master(HIGH_SEA_IEC, HIGH_SEA_BRANCH_SL_NO);

          if (xx == 1)
          {
              if (HSS_ADD1 == "")
              {
                  if (HIGH_SEA_IEC != "" && HIGH_SEA_BRANCH_SL_NO != "")
                  {
                      ds_IEC = Get_Importer_HSS_Details(HIGH_SEA_IEC, HIGH_SEA_BRANCH_SL_NO);
                      if (ds_IEC.Tables[0].Rows.Count > 0)
                      {
                          HIGH_SEA_SALE = "Y";
                          HIGH_SEA_SALE_NAME = ds_IEC.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                          HSS_ADD1 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                          HSS_ADD2 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                          HSS_ADD3 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                          HSS_ADD4 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                          HSS_ADD5 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                      }
                  }
                  else
                  {
                      HIGH_SEA_SALE = "N";
                      HIGH_SEA_BRANCH_SL_NO = "0";
                  }
              }
              else
              {
                  HIGH_SEA_SALE = "Y";
                  HIGH_SEA_SALE_NAME = General_data.Rows[0][27].ToString();
                  HSS_ADD1 = General_data.Rows[0][28].ToString();
                  HSS_ADD2 = General_data.Rows[0][29].ToString();
                  HSS_ADD3 = General_data.Rows[0][30].ToString();
                  HSS_ADD4 = General_data.Rows[0][31].ToString();
                  HSS_ADD5 = General_data.Rows[0][32].ToString();
              }
          }
          else
          {

              IEC_INSERT_UPDATE(HIGH_SEA_IEC, HIGH_SEA_BRANCH_SL_NO, HIGH_SEA_SALE_NAME, HSS_ADD1, HSS_ADD2, HSS_ADD3, HSS_ADD4, HSS_ADD5, "P", "", "");
              HIGH_SEA_SALE = "Y";
              HIGH_SEA_SALE_NAME = General_data.Rows[0][27].ToString();
              HSS_ADD1 = General_data.Rows[0][28].ToString();
              HSS_ADD2 = General_data.Rows[0][29].ToString();
              HSS_ADD3 = General_data.Rows[0][30].ToString();
              HSS_ADD4 = General_data.Rows[0][31].ToString();
              HSS_ADD5 = General_data.Rows[0][32].ToString();
          }
      
       
        if (currentuser == "AURIONPRO")
        {
            HIGH_SEA_SALE = "Y";
            HIGH_SEA_SALE_NAME = General_data.Rows[0][27].ToString();
            HSS_ADD1 = General_data.Rows[0][28].ToString();
            HSS_ADD2 = General_data.Rows[0][29].ToString();
            HSS_ADD3 = General_data.Rows[0][30].ToString();
            HSS_ADD4 = General_data.Rows[0][31].ToString();
            HSS_ADD5 = General_data.Rows[0][32].ToString();
        }

        PAYMENT_METHOD_CODE = "T";
        EXBOND_INBOND_BE_DATE = LoginDate;
        EXBOND_BOND_DATE = LoginDate;
        COMPLETED_DATE = LoginDate;
        DOC_RECEIVED_DATE = LoginDate;

        if (HIGH_SEA_BRANCH_SL_NO == "")
        {
            HIGH_SEA_BRANCH_SL_NO = "0";
        }

        JobNo_Prefix_Sufix();
        MAX_ID = Get_general_MAXID("Gen_MAX_ID");

        dt_gen.Rows.Add(MAX_ID, IMPORT_JOBNO, JOBDATE, TRANSPORT_MODE, BE_TYPE, CUSTOMS_HOUSE, CUSTOMS_HOUSE_NAME, IMPORTER_NAME, ADDRESS1, ADDRESS2, ADDRESS3, ADDRESS4, ADDRESS5,
                        IEC_NO, BRANCH_NO, COUNTRY_ORIGIN, PORT_ORIGIN, PORT_SHIPMENT, COUNTRY_SHIPMENT, FILING_STATUS, SECTION46, SECTION46_DESC, FIRSTCHECK, FIRSTCHECK_DESC,
                        GREEN_CHANNEL, GREEN_CHANNEL_DESC, KACHHA_BE, KACHHA_BE_DESC, SECTION48, SECTION48_DESC, HIGH_SEA_SALE, HIGH_SEA_SALE_NAME, HIGH_SEA_IEC, HIGH_SEA_BRANCH_SL_NO,
                        HSS_ADD1, HSS_ADD2, HSS_ADD3, HSS_ADD4, HSS_ADD5, WAREHOUSE_NAME, WAREHOUSE_CODE, IMP_EXP_TYPE, COMMERCIAL_TAX, COMMERCIAL_TAX_STATENAME, STATECODE,
                        TYPE, REGISTRATION_NO, EXBOND_INBOND_BE_NO, EXBOND_INBOND_BE_DATE, EXBOND_BOND_NO, EXBOND_BOND_DATE, EXBOND_WAREHOUSE_CUSTOMS, EXBOND_WAREHOUSE_CUSTOMS_CODE,
                        EXBOND_NOOFPACKAGE, EXBOND_NOOFPACKAGE_UNITCODE, EXBOND_GROSS_WEIGHT, EXBOND_GROSS_WEIGHT_UNITCODE, EXBOND_DIRECT_EXBONDING, REMARKS, currentuser, LoginDate,
                        "N", currentbranch, Working_Period, FILE_REF_NO, CONTAINER_TYPE, JOB_STATUS, JOB_RELEASE, JOB_FILED_STATUS, currentuser, LoginDate, JOB_PREFIX, JOB_SUFFIX, JOBNO_PS,
                        COMPLETED_DATE, ADCODE, UCR_NO, UCR_TYPE, PAYMENT_METHOD_CODE, PRECEDING_LEVEL, DOC_RECEIVED_DATE, AGENT_NAME, EXBOND_ADDL_LOAD_HSS, EXBOND_MISC_LOAD_RATE);
        ds_GENERAL.Tables.Add(dt_gen);
        ViewState["ds_GENERAL"] = ds_GENERAL;
        return ds_GENERAL;
    }

    public DataTable Bind_IGM_Details(DataTable IGM_Data)
    {
        #region dt_IGM
        dt_IGM.Columns.Add("IGM_ID");
        dt_IGM.Columns.Add("IGM_SLNO");
        dt_IGM.Columns.Add("JOBNO");
        dt_IGM.Columns.Add("IGM_JOBDATE");
        dt_IGM.Columns.Add("IGM_AIRLINECODE");
        dt_IGM.Columns.Add("IGM_AIRLINENAME");
        dt_IGM.Columns.Add("IGM_FLIGHTNO_VESSELNO");
        dt_IGM.Columns.Add("IGM_FLIGHT_VESSELDATE");
        dt_IGM.Columns.Add("IGM_NO");
        dt_IGM.Columns.Add("IGM_DATE");
        dt_IGM.Columns.Add("IGM_MAWB_MBL");
        dt_IGM.Columns.Add("IGM_MAWB_MBLDATE");
        dt_IGM.Columns.Add("IGM_HAWB_HBLNO");
        dt_IGM.Columns.Add("IGM_HAWB_HBLDATE");
        dt_IGM.Columns.Add("IGM_NOOFPACKAGE");
        dt_IGM.Columns.Add("IGM_PACKAGETYPE");
        dt_IGM.Columns.Add("IGM_GROSSWEIGHT");
        dt_IGM.Columns.Add("IGM_TYPEOFWEIGHT");
        dt_IGM.Columns.Add("IGM_NETWEIGHT");
        dt_IGM.Columns.Add("IGM_NETWEIGHTTYPE");
        dt_IGM.Columns.Add("IGM_TRANSPORTMODE");
        dt_IGM.Columns.Add("IGM_MARKSNOS");
        dt_IGM.Columns.Add("IGM_GATEWAY_IGM_NO");
        dt_IGM.Columns.Add("IGM_GATEWAY_IGM_DATE");
        dt_IGM.Columns.Add("IGM_GATEWAY_PORT_CODE");
        dt_IGM.Columns.Add("IGM_USER_ID");
        dt_IGM.Columns.Add("IGM_DATE_TIME");
        dt_IGM.Columns.Add("IGM_STATUS");
        dt_IGM.Columns.Add("IGM_BRANCH_CODE");
        dt_IGM.Columns.Add("IGM_YEAR");
        dt_IGM.Columns.Add("IGM_WORKING_PERIOD");
        dt_IGM.Columns.Add("MODIFIEDBY");
        dt_IGM.Columns.Add("MODIFIEDON");
        dt_IGM.Columns.Add("IGM_LINE_NUMBER");
        dt_IGM.Columns.Add("IGM_SHIPPING_LINE_NUMBER");
        dt_IGM.Columns.Add("IGM_VOYAGE");
        dt_IGM.Columns.Add("IGM_CHARGEABLE_WGT");
        #endregion dt_IGM
        //******************** Remove Empty Rows from Datatable  ********************************

        IGM_Data = IGM_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //*********************************************************************************************************

        for (int i = 0; i <= IGM_Data.Rows.Count - 1; i++)
        {

            IGM_SLNO = Convert.ToString(i + 1);
            IGM_JOBDATE = JOBDATE;
            IGM_AIRLINECODE = IGM_Data.Rows[i][0].ToString();
            IGM_AIRLINENAME = IGM_Data.Rows[i][1].ToString();
            IGM_FLIGHTNO_VESSELNO = IGM_Data.Rows[i][2].ToString();
            IGM_FLIGHT_VESSELDATE = IGM_Data.Rows[i][3].ToString() == string.Empty ? "01/01/1900" : IGM_Data.Rows[i][3].ToString();
            IGM_NO = IGM_Data.Rows[i][4].ToString();
            IGM_DATE = IGM_Data.Rows[i][5].ToString();
            IGM_MAWB_MBL = IGM_Data.Rows[i][6].ToString();
            IGM_MAWB_MBLDATE = IGM_Data.Rows[i][7].ToString();
            IGM_HAWB_HBLNO = IGM_Data.Rows[i][8].ToString();
            IGM_HAWB_HBLDATE = IGM_Data.Rows[i][9].ToString() == string.Empty ? "01/01/1900" : IGM_Data.Rows[i][9].ToString();
            IGM_NOOFPACKAGE = IGM_Data.Rows[i][10].ToString();
            IGM_PACKAGETYPE = IGM_Data.Rows[i][11].ToString();
            IGM_GROSSWEIGHT = IGM_Data.Rows[i][12].ToString();
            IGM_TYPEOFWEIGHT = IGM_Data.Rows[i][13].ToString();
            IGM_NETWEIGHT = "0.00";
            IGM_NETWEIGHTTYPE = "";
            IGM_TRANSPORTMODE = TRANSPORT_MODE;
            IGM_MARKSNOS = IGM_Data.Rows[i][14].ToString();
            IGM_GATEWAY_IGM_NO = IGM_Data.Rows[i][15].ToString();
            IGM_GATEWAY_IGM_DATE = IGM_Data.Rows[i][16].ToString() == string.Empty ? "01/01/1900" : IGM_Data.Rows[i][16].ToString();
            IGM_GATEWAY_PORT_CODE = IGM_Data.Rows[i][17].ToString();
            IGM_LINE_NUMBER = IGM_Data.Rows[i][18].ToString();
            IGM_SHIPPING_LINE_NUMBER = IGM_Data.Rows[i][19].ToString();
            IGM_VOYAGE = IGM_Data.Rows[i][20].ToString();
            IGM_CHARGEABLE_WGT = IGM_Data.Rows[i][21].ToString();

            MAX_ID = Get_general_MAXID("IGM_MAX_ID");
            Get_IGM_NO_DATE(IGM_SLNO);

            IGM_NO = IGM_NO == string.Empty ? "0" : IGM_NO;
            IGM_DATE = IGM_DATE == string.Empty ? "01/01/1900" : IGM_DATE;

            dt_IGM.Rows.Add(MAX_ID + i, IGM_SLNO, IMPORT_JOBNO, IGM_JOBDATE, IGM_AIRLINECODE, IGM_AIRLINENAME, IGM_FLIGHTNO_VESSELNO, IGM_FLIGHT_VESSELDATE, IGM_NO, IGM_DATE,
                             IGM_MAWB_MBL, IGM_MAWB_MBLDATE, IGM_HAWB_HBLNO, IGM_HAWB_HBLDATE, IGM_NOOFPACKAGE, IGM_PACKAGETYPE, IGM_GROSSWEIGHT, IGM_TYPEOFWEIGHT, IGM_NETWEIGHT, IGM_NETWEIGHTTYPE,
                             IGM_TRANSPORTMODE, IGM_MARKSNOS, IGM_GATEWAY_IGM_NO, IGM_GATEWAY_IGM_DATE, IGM_GATEWAY_PORT_CODE, currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate, IGM_LINE_NUMBER, IGM_SHIPPING_LINE_NUMBER, IGM_VOYAGE, IGM_CHARGEABLE_WGT);
        }
        ds_IGM=dt_IGM;
        ViewState["ds_IGM"] = ds_IGM;
        return ds_IGM;

    }

    public DataTable Bind_CONTAINER_Details(DataTable CONT_Data)
    {
        #region dt_CONT
        dt_CONT.Columns.Add("CONTAINERID");
        dt_CONT.Columns.Add("IGM_SLNO");
        dt_CONT.Columns.Add("CONTAINER_IGM_NO");
        dt_CONT.Columns.Add("CONTAINER_IGM_DATE");
        dt_CONT.Columns.Add("JOBNO");
        dt_CONT.Columns.Add("CONTAINER_NO");
        dt_CONT.Columns.Add("SEAL_NO");
        dt_CONT.Columns.Add("FCL_OR_LCL");
        dt_CONT.Columns.Add("USER_ID");
        dt_CONT.Columns.Add("DATE_TIME");
        dt_CONT.Columns.Add("STATUS");
        dt_CONT.Columns.Add("BRANCH_CODE");
        dt_CONT.Columns.Add("YEAR");
        dt_CONT.Columns.Add("WORKING_PERIOD");
        dt_CONT.Columns.Add("TYPE");
        dt_CONT.Columns.Add("TRUCK_NO");
        dt_CONT.Columns.Add("MODIFIEDBY");
        dt_CONT.Columns.Add("MODIFIEDON");
        #endregion dt_CONT

        CONTAINER_IGM_NO = IGM_NO == string.Empty ? "0" : IGM_NO;
        CONTAINER_IGM_DATE = IGM_DATE == string.Empty ? "01/01/1900" : IGM_DATE;

        //******************** Remove Empty Rows from Datatable  ********************************

        CONT_Data = CONT_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //*********************************************************************************************************

        for (int i = 0; i <= CONT_Data.Rows.Count - 1; i++)
        {
            CONTAINER_IGM_SLNO = CONT_Data.Rows[i][0].ToString();
            CONTAINER_NO = CONT_Data.Rows[i][1].ToString();
            SEAL_NO = CONT_Data.Rows[i][2].ToString();
            FCL_OR_LCL = CONT_Data.Rows[i][3].ToString();
            TYPE = CONT_Data.Rows[i][4].ToString();
            TRUCK_NO = CONT_Data.Rows[i][5].ToString();

            MAX_ID = Get_general_MAXID("CONTAINER_MAX_ID");

            dt_CONT.Rows.Add(MAX_ID + i, CONTAINER_IGM_SLNO, CONTAINER_IGM_NO, CONTAINER_IGM_DATE, IMPORT_JOBNO, CONTAINER_NO, SEAL_NO, FCL_OR_LCL, currentuser, LoginDate,
                               "N", currentbranch, "", Working_Period, TYPE, TRUCK_NO, currentuser, LoginDate);
        }


        ds_CONTAINER=dt_CONT;
        ViewState["ds_CONTAINER"] = ds_CONTAINER;
        return ds_CONTAINER;
    }

    public DataTable Bind_REIMPORT_Details(DataTable REIMP_Data,DataTable tbl_inv)
    {
        #region dt_REIMP
        dt_REIMP.Columns.Add("RE_IMPORT_ID");
        dt_REIMP.Columns.Add("RE_IMPORT_SLNO");
        dt_REIMP.Columns.Add("JOBNO");
        dt_REIMP.Columns.Add("INVOICE_SLNO");
        dt_REIMP.Columns.Add("INVOICE_NO");
        dt_REIMP.Columns.Add("ITEM_SLNO");
        dt_REIMP.Columns.Add("SB_NO");
        dt_REIMP.Columns.Add("SB_DATE");
        dt_REIMP.Columns.Add("PORT_EXPORT");
        dt_REIMP.Columns.Add("SB_INVOICE_NO");
        dt_REIMP.Columns.Add("SB_INVOICE__ITEM_NO");
        dt_REIMP.Columns.Add("NOTN_NO");
        dt_REIMP.Columns.Add("NOTN_SLNO");
        dt_REIMP.Columns.Add("EXPORT_FREIGHT");
        dt_REIMP.Columns.Add("EXPORT_INSURANCE");
        dt_REIMP.Columns.Add("CUSTOMS_DUTY");
        dt_REIMP.Columns.Add("EXCISE_DUTY");
        dt_REIMP.Columns.Add("USER_ID");
        dt_REIMP.Columns.Add("DATE_TIME");
        dt_REIMP.Columns.Add("STATUS");
        dt_REIMP.Columns.Add("BRANCH_CODE");
        dt_REIMP.Columns.Add("YEAR");
        dt_REIMP.Columns.Add("WORKING_PERIOD");
        dt_REIMP.Columns.Add("MODIFIEDBY");
        dt_REIMP.Columns.Add("MODIFIEDON");

        #endregion dt_REIMP
        //******************** Remove Empty Rows from Datatable  ********************************

        REIMP_Data = REIMP_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //****************************************************************************************

        for (int i = 0; i <= REIMP_Data.Rows.Count - 1; i++)
        {
            RE_IMPORT_SLNO = Convert.ToString(i);

            INVOICE_SLNO = REIMP_Data.Rows[i][0].ToString();
            ITEM_SLNO = REIMP_Data.Rows[i][1].ToString();
            SB_NO = REIMP_Data.Rows[i][2].ToString();
            SB_DATE = REIMP_Data.Rows[i][3].ToString();
            
            SB_INVOICE_NO = REIMP_Data.Rows[i][4].ToString();
            SB_INVOICE__ITEM_NO = REIMP_Data.Rows[i][5].ToString();
            PORT_EXPORT = REIMP_Data.Rows[i][6].ToString();
            NOTN_NO = REIMP_Data.Rows[i][7].ToString();
            NOTN_SLNO = REIMP_Data.Rows[i][8].ToString(); 
            EXPORT_FREIGHT = REIMP_Data.Rows[i][9].ToString();
            EXPORT_INSURANCE = REIMP_Data.Rows[i][10].ToString();
            CUSTOMS_DUTY = REIMP_Data.Rows[i][11].ToString();
            EXCISE_DUTY = REIMP_Data.Rows[i][12].ToString();

            MAX_ID = Get_general_MAXID("REIMPORT_MAX_ID");
            string InvoiceNo = "";

            var rowColl = tbl_inv.AsEnumerable();
            string name = (from r in rowColl
                           where r.Field<double>("Invoice_Slno") == Convert.ToDouble(REIMP_Data.Rows[i][0].ToString())
                           select r.Field<string>("Invoice_No")).First<string>();

            InvoiceNo = name;

            //var name = from r in tbl_inv.AsEnumerable()
            //           where r. == 0
            //           select r.Name;

            //var result = from d in tbl_inv.AsEnumerable()
            //             where d.Field<string>("INVOICE_SLNO") == REIMP_Data.Rows[i][0].ToString()
            //             select new
            //             {
            //                 InvoiceNo = d.Field<string>("INVOICE_NO")
                            
            //             };

            ////var a = result.FirstOrDefault();
            //InvoiceNo = InvoiceNo;
            //var inv_No = a.InvoiceNo;

            dt_REIMP.Rows.Add(MAX_ID + i, RE_IMPORT_SLNO, IMPORT_JOBNO, INVOICE_SLNO, InvoiceNo, ITEM_SLNO, SB_NO, SB_DATE, PORT_EXPORT, SB_INVOICE_NO, SB_INVOICE__ITEM_NO, NOTN_NO, NOTN_SLNO,
                                EXPORT_FREIGHT, EXPORT_INSURANCE, CUSTOMS_DUTY, EXCISE_DUTY, currentuser,LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);
        }

        ds_REIMPORT = dt_REIMP;
        ViewState["dt_REIMP"] = ds_REIMPORT;
        return ds_REIMPORT;
    }

    public void Bind_SINGLE_WINDOW_Details(DataTable SW_Data)
    {
        #region dt_SW_INFO
        dt_SW_INFO.Columns.Add("SW_INFO_TYPE_ID");
        dt_SW_INFO.Columns.Add("JOBNO");
        dt_SW_INFO.Columns.Add("INVOICE_SLNO");
        dt_SW_INFO.Columns.Add("ITEM_SLNO");
        dt_SW_INFO.Columns.Add("INFO_TYPE");
        dt_SW_INFO.Columns.Add("INFO_QUALIFIER");
        dt_SW_INFO.Columns.Add("INFO_CODE");
        dt_SW_INFO.Columns.Add("INFO_TEXT");
        dt_SW_INFO.Columns.Add("INFO_MSR");
        dt_SW_INFO.Columns.Add("INFO_UQC");
        dt_SW_INFO.Columns.Add("USER_ID");
        dt_SW_INFO.Columns.Add("DATE_TIME");
        dt_SW_INFO.Columns.Add("STATUS");
        dt_SW_INFO.Columns.Add("BRANCH_CODE");
        dt_SW_INFO.Columns.Add("YEAR");
        dt_SW_INFO.Columns.Add("WORKING_PERIOD");
        dt_SW_INFO.Columns.Add("MODIFIEDBY");
        dt_SW_INFO.Columns.Add("MODIFIEDON");
        dt_SW_INFO.Columns.Add("DEPARTMENT");
        dt_SW_INFO.Columns.Add("I_U_TYPE");
        #endregion dt_SW_INFO

        #region dt_SW_CTRL
        dt_SW_CTRL.Columns.Add("SW_CONTROL_ID");
        dt_SW_CTRL.Columns.Add("JOBNO");
        dt_SW_CTRL.Columns.Add("INVOICE_SLNO");
        dt_SW_CTRL.Columns.Add("ITEM_SLNO");
        dt_SW_CTRL.Columns.Add("CONTROL_TYPE_CODE");
        dt_SW_CTRL.Columns.Add("CONTROL_LOCATION");
        dt_SW_CTRL.Columns.Add("CONTROL_START_DATE");
        dt_SW_CTRL.Columns.Add("CONTROL_END_DATE");
        dt_SW_CTRL.Columns.Add("CONTROL_RESULT_CODE");
        dt_SW_CTRL.Columns.Add("CONTROL_RESULT_TEXT");
        dt_SW_CTRL.Columns.Add("USER_ID");
        dt_SW_CTRL.Columns.Add("DATE_TIME");
        dt_SW_CTRL.Columns.Add("STATUS");
        dt_SW_CTRL.Columns.Add("BRANCH_CODE");
        dt_SW_CTRL.Columns.Add("YEAR");
        dt_SW_CTRL.Columns.Add("WORKING_PERIOD");
        dt_SW_CTRL.Columns.Add("MODIFIEDBY");
        dt_SW_CTRL.Columns.Add("MODIFIEDON");
        #endregion dt_SW_CTRL

        #region dt_SW_STMT
        dt_SW_STMT.Columns.Add("SW_ID");
        dt_SW_STMT.Columns.Add("JOBNO");
        dt_SW_STMT.Columns.Add("INVOICE_SLNO");
        dt_SW_STMT.Columns.Add("ITEM_SLNO");
        dt_SW_STMT.Columns.Add("STMT_DECLARATION_TYPE");
        dt_SW_STMT.Columns.Add("STMT_DECLARATION_NUMBER");
        dt_SW_STMT.Columns.Add("STMT_DECLARATION_DATE");
        dt_SW_STMT.Columns.Add("STMT_TYPE");
        dt_SW_STMT.Columns.Add("STMT_CODE");
        dt_SW_STMT.Columns.Add("STMT_TEXT");
        dt_SW_STMT.Columns.Add("BRANCH_CODE");
        dt_SW_STMT.Columns.Add("WORKING_PERIOD");
        dt_SW_STMT.Columns.Add("CREATEDON");
        dt_SW_STMT.Columns.Add("CREATEDBY");
        dt_SW_STMT.Columns.Add("MODIFIEDBY");
        dt_SW_STMT.Columns.Add("MODIFIEDON");
        #endregion dt_SW_STMT

        //******************** Remove Empty Rows from Datatable  ********************************

        SW_Data = SW_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //****************************************************************************************

        for (int i = 0; i <= SW_Data.Rows.Count - 1; i++)
        {
            SW_INFO_TYPE_ID = Convert.ToString(i);

            INVOICE_SLNO = SW_Data.Rows[i][0].ToString();
            ITEM_SLNO = SW_Data.Rows[i][1].ToString();
            DEPARTMENT = SW_Data.Rows[i][3].ToString();
            if (SW_Data.Rows[i][4].ToString() != "")
            {
                INFO_TYPE = SW_Data.Rows[i][4].ToString().Substring(0, 3);
            }
            else
            {
                INFO_TYPE = "";
            }
            if (SW_Data.Rows[i][5].ToString() != "")
            {
                INFO_QUALIFIER = SW_Data.Rows[i][5].ToString().Substring(0, 3);
            }
            else
            {
                INFO_QUALIFIER = "";
            }

            if (SW_Data.Rows[i][6].ToString() != "")
            {
                INFO_CODE = SW_Data.Rows[i][6].ToString().Substring(0, 3);
            }
            else
            {
                INFO_CODE = "";
            }
            INFO_TEXT = SW_Data.Rows[i][7].ToString();
            INFO_MSR = SW_Data.Rows[i][8].ToString();
            INFO_UQC = SW_Data.Rows[i][9].ToString();
            
            I_U_TYPE = "N";

            if (INFO_TYPE != "")
            {
                MAX_ID = Get_general_MAXID("SINGLEWINDOW_INFO_MAX_ID");

                dt_SW_INFO.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, INFO_TYPE, INFO_QUALIFIER, INFO_CODE, INFO_TEXT, INFO_MSR, INFO_UQC,
                                     currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate, DEPARTMENT, I_U_TYPE);
            }

            if (i == 0)
            {
                MAX_ID = Get_general_MAXID("SINGLEWINDOW_CTRL_MAX_ID");

                if (SW_Data.Rows[i][10].ToString() != "")
                {
                    CONTROL_TYPE_CODE = SW_Data.Rows[i][10].ToString();
                    CONTROL_LOCATION = SW_Data.Rows[i][11].ToString();
                    CONTROL_START_DATE = SW_Data.Rows[i][12].ToString();
                    CONTROL_END_DATE = SW_Data.Rows[i][13].ToString();
                    CONTROL_RESULT_CODE = SW_Data.Rows[i][14].ToString();
                    CONTROL_RESULT_TEXT = SW_Data.Rows[i][15].ToString();

                    dt_SW_CTRL.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, CONTROL_TYPE_CODE, CONTROL_LOCATION, CONTROL_START_DATE, CONTROL_END_DATE, CONTROL_RESULT_CODE, CONTROL_RESULT_TEXT,
                                     currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);
                }
            }

            STMT_DECLARATION_TYPE = "";
            STMT_DECLARATION_NUMBER = "";
            STMT_DECLARATION_DATE = "01/01/1900";
            STMT_TYPE = SW_Data.Rows[i][16].ToString();
            STMT_CODE = SW_Data.Rows[i][17].ToString();
            

            if (STMT_TYPE != "" && STMT_CODE!="")
            {
                if (STMT_CODE.Contains('-'))
                {
                    string[] sp0 = STMT_CODE.Split('-');
                    STMT_CODE = sp0[0];
                    STMT_TEXT = sp0[1];
                }

                //STMT_TEXT = SW_Data.Rows[i][11].ToString();
                MAX_ID = Get_general_MAXID("SINGLEWINDOW_STMT_MAX_ID");
                dt_SW_STMT.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, STMT_DECLARATION_TYPE, STMT_DECLARATION_NUMBER, STMT_DECLARATION_DATE, STMT_TYPE, STMT_CODE, STMT_TEXT,
                                     currentbranch, Working_Period, LoginDate, currentuser, currentuser, LoginDate);
            }
        }

        if (dt_SW_INFO.Rows.Count > 0)
        {
            ViewState["dt_SW_INFO"] = dt_SW_INFO;
        }
        else
        {
            ViewState["dt_SW_INFO"] = dt_SW_INFO;
        }

        if (dt_SW_CTRL.Rows.Count > 0)
        {
            ViewState["dt_SW_CTRL"] = dt_SW_CTRL;
        }
        else
        {
            ViewState["dt_SW_CTRL"] = dt_SW_CTRL;
        }

        if (dt_SW_STMT.Rows.Count > 0)
        {
            ViewState["dt_SW_STMT"] = dt_SW_STMT;
        }
        else
        {
            ViewState["dt_SW_STMT"] = dt_SW_STMT;
        }

        //ds_SW_CTRL = SW_Data;
        //ViewState["dt_SW_CTRL"] = ds_SW_CTRL;
        //return ds_SW_CTRL;
    }

    public DataTable Bind_INVOICE_Details(DataTable INV_Data)
    {
        #region dt_INV
        dt_INV.Columns.Add("INVOICE_ID");
        dt_INV.Columns.Add("JOBNO");
        dt_INV.Columns.Add("INVOICE_SLNO");
        dt_INV.Columns.Add("INVOICE_NO");
        dt_INV.Columns.Add("INVOICE_DATE");
        dt_INV.Columns.Add("TERMS");
        dt_INV.Columns.Add("INVOICE_CURRENCY");
        dt_INV.Columns.Add("INVOICE_EXRATE");
        dt_INV.Columns.Add("INVOICE_VALUE");
        dt_INV.Columns.Add("SUPPLIER_NAME");
        dt_INV.Columns.Add("SUPPLIER_ADDRESS");
        dt_INV.Columns.Add("SUPPLIER_ADDRESS1");
        dt_INV.Columns.Add("SUPPLIER_ADDRESS2");
        dt_INV.Columns.Add("SUPPLIER_COUNTRY_NAME");
        dt_INV.Columns.Add("SUPPLIER_COUNTRY_CODE");
        dt_INV.Columns.Add("SUPPLIER_COUNTRY_PINCODE");
        dt_INV.Columns.Add("SELLER_NAME");
        dt_INV.Columns.Add("SELLER_ADDRESS");
        dt_INV.Columns.Add("SELLER_ADDRESS1");
        dt_INV.Columns.Add("SELLER_ADDRESS2");
        dt_INV.Columns.Add("SELLER_COUNTRY_NAME");
        dt_INV.Columns.Add("SELLER_COUNTRY_CODE");
        dt_INV.Columns.Add("SELLERCOUNTRY_PINCODE");
        dt_INV.Columns.Add("BROKER_NAME");
        dt_INV.Columns.Add("BROKER_ADDRESS");
        dt_INV.Columns.Add("BROKER_ADDRESS1");
        dt_INV.Columns.Add("BROKER_ADDRESS2");
        dt_INV.Columns.Add("BROKER_COUNTRY_NAME");
        dt_INV.Columns.Add("BROKER_COUNTRY_CODE");
        dt_INV.Columns.Add("BROKER_COUNTRY_PINCODE");
        dt_INV.Columns.Add("MIS_CHARGES");
        dt_INV.Columns.Add("MIS_RATE");
        dt_INV.Columns.Add("MIS_CURRENCY");
        dt_INV.Columns.Add("MIS_EXRATE");
        dt_INV.Columns.Add("MIS_AGENCY_CHARGES");
        dt_INV.Columns.Add("MIS_AGENCY_RATE");
        dt_INV.Columns.Add("MIS_AGENCY_CURRENCY");
        dt_INV.Columns.Add("MIS_AGENCY_EXRATE");
        dt_INV.Columns.Add("MIS_DISCOUNT_CHARGES");
        dt_INV.Columns.Add("MIS_DISCOUNT_RATE");
        dt_INV.Columns.Add("MIS_DISCOUNT_CURRENCY");
        dt_INV.Columns.Add("MIS_DISCOUNT_EXRATE");
        dt_INV.Columns.Add("MIS_DISCOUNT_REASON");
        dt_INV.Columns.Add("MIS_LOADING_CHARGES");
        dt_INV.Columns.Add("MIS_LOADING_RATE");
        dt_INV.Columns.Add("MIS_LOADING_CURRENCY");
        dt_INV.Columns.Add("MIS_LOADING_EXRATE");
        dt_INV.Columns.Add("MIS_FREIGHT_CHARGES");
        dt_INV.Columns.Add("MIS_FREIGHT_RATE");
        dt_INV.Columns.Add("MIS_FREIGHT_CURRENCY");
        dt_INV.Columns.Add("MIS_FREIGHT_EXRATE");
        dt_INV.Columns.Add("MIS_INSURANCE_CHARGES");
        dt_INV.Columns.Add("MIS_INSURANCE_RATE");
        dt_INV.Columns.Add("MIS_INSURANCE_CURRENCY");
        dt_INV.Columns.Add("MIS_INSURANCE_EXRATE");
        dt_INV.Columns.Add("MIS_HIGHSEASALE_CHARGES");
        dt_INV.Columns.Add("MIS_HIGHSEASALE_RATE");
        dt_INV.Columns.Add("MIS_HIGHSEASALE_CURRENCY");
        dt_INV.Columns.Add("MIS_HIGHSEASALE_EXRATE");
        dt_INV.Columns.Add("MIS_SINGLE_OR_MULITIPLE");
        dt_INV.Columns.Add("SVB_RELATION");
        dt_INV.Columns.Add("SVB_REF_NO");
        dt_INV.Columns.Add("SVB_REF_DATE");
        dt_INV.Columns.Add("SVB_CUSTOM_HOUSE");
        dt_INV.Columns.Add("SVB_LOADING_ON");
        dt_INV.Columns.Add("SVB_ASSESABLE_RATE");
        dt_INV.Columns.Add("SVB_DUTY_RATE");
        dt_INV.Columns.Add("SVB_ASSESABLE_STATUS");
        dt_INV.Columns.Add("SVB_DUTY_STATUS");
        dt_INV.Columns.Add("OTHER_PURCHASE_ORDER");
        dt_INV.Columns.Add("OTHER_PURCHASE_ORDER_DATE");
        dt_INV.Columns.Add("OTHER_CONTRACT_NO");
        dt_INV.Columns.Add("OTHER_CONTRACT_DATE");
        dt_INV.Columns.Add("OTHER_LOC_NO");
        dt_INV.Columns.Add("OTHER_LOC_DATE");
        dt_INV.Columns.Add("OTHER_NATURE_OF_TRANSACTION");
        dt_INV.Columns.Add("OTHER_TERMS_OF_PAYMENT");
        dt_INV.Columns.Add("OTHER_CONDITIONS");
        dt_INV.Columns.Add("OTHER_VALUATION_METHOD");
        dt_INV.Columns.Add("USER_ID");
        dt_INV.Columns.Add("DATE_TIME");
        dt_INV.Columns.Add("STATUS");
        dt_INV.Columns.Add("BRANCH_CODE");
        dt_INV.Columns.Add("YEAR");
        dt_INV.Columns.Add("WORKING_PERIOD");
        dt_INV.Columns.Add("NON_STD_EFFECT_DT_IMP");
        dt_INV.Columns.Add("NON_STD_BANKNAME");
        dt_INV.Columns.Add("NON_STD_CERTIFICATE_NO");
        dt_INV.Columns.Add("NON_STD_CERTIFICATE_DATE");
        dt_INV.Columns.Add("SAP_DELIEVERY_ID");
        dt_INV.Columns.Add("SHIP_DATE");
        dt_INV.Columns.Add("INVOICE_LEVEL");
        dt_INV.Columns.Add("COUNTRY_OF_DEPARTURE");
        dt_INV.Columns.Add("REVENUEDEPOSIT_RATE");
        dt_INV.Columns.Add("REVENUEDEPOSIT_ON");
        dt_INV.Columns.Add("MI_FREIGHT");
        dt_INV.Columns.Add("MI_INSURANCE");
        dt_INV.Columns.Add("MI_MISC");
        dt_INV.Columns.Add("MI_HSS");
        dt_INV.Columns.Add("MODIFIEDBY");
        dt_INV.Columns.Add("MODIFIEDON");
        dt_INV.Columns.Add("INDEV_INV_TYPE");
        dt_INV.Columns.Add("TERMS_PLACE");
        dt_INV.Columns.Add("THIRDPARTY_NAME");
        dt_INV.Columns.Add("THIRDPARTY_ADD1");
        dt_INV.Columns.Add("THIRDPARTY_ADD2");
        dt_INV.Columns.Add("THIRDPARTY_CITY");
        dt_INV.Columns.Add("T_PARTY_COUNTRY_SUB_DIV");
        dt_INV.Columns.Add("T_PARTY_COUNTRY_CODE");
        dt_INV.Columns.Add("T_PARTY_PIN");
        dt_INV.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR_CODE");
        dt_INV.Columns.Add("A_E_O_COUNTRY");
        dt_INV.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR");
        dt_INV.Columns.Add("WHETHER_BUYER_SELLER_RELATED");
        dt_INV.Columns.Add("A_AMOUNT");
        dt_INV.Columns.Add("B_AMOUNT");
        dt_INV.Columns.Add("C_AMOUNT");
        dt_INV.Columns.Add("D_AMOUNT");
        dt_INV.Columns.Add("E_AMOUNT");
        dt_INV.Columns.Add("F_AMOUNT");
        dt_INV.Columns.Add("G_AMOUNT");
        dt_INV.Columns.Add("H_AMOUNT");
        dt_INV.Columns.Add("I_AMOUNT");
        dt_INV.Columns.Add("J_AMOUNT");
        dt_INV.Columns.Add("K_AMOUNT");
        dt_INV.Columns.Add("L_AMOUNT");
        dt_INV.Columns.Add("M_AMOUNT");
        dt_INV.Columns.Add("N_AMOUNT");
        dt_INV.Columns.Add("TOTAL_OTHER_AMOUNT");

        #endregion dt_INV
        //******************** Remove Empty Rows from Datatable  ********************************

        INV_Data = INV_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //****************************************************************************************
        int xx = 0;
        for (int i = 0; i <= INV_Data.Rows.Count - 1; i++)
        {
            INVOICE_ID = Convert.ToString(i);

            JOBNO=IMPORT_JOBNO;
            INVOICE_SLNO = INV_Data.Rows[i][0].ToString();
            INVOICE_NO = INV_Data.Rows[i][1].ToString();
            INVOICE_DATE = INV_Data.Rows[i][2].ToString();
            TERMS = INV_Data.Rows[i][3].ToString();
            INVOICE_CURRENCY = INV_Data.Rows[i][4].ToString();
            INVOICE_EXRATE = INV_Data.Rows[i][5].ToString();
            INVOICE_VALUE = INV_Data.Rows[i][6].ToString();

            SUPPLIER_NAME = INV_Data.Rows[i][30].ToString();
            txt_SupplierName_Gen.Text = SUPPLIER_NAME;
            ds_supplier.Clear();
            ds_supplier = Get_Importer_Supplier_Details(SUPPLIER_NAME);
            xx = xl.result;

           
            if (xx == 1)
            {
                if (currentuser != "AURIONPRO")
                {
                    SUPPLIER_NAME = ds_supplier.Tables[0].Rows[0]["SUP_NAME"].ToString();
                    SUPPLIER_ADDRESS = ds_supplier.Tables[0].Rows[0]["SUP_ADD1"].ToString();
                    SUPPLIER_ADDRESS1 = ds_supplier.Tables[0].Rows[0]["SUP_ADD2"].ToString();
                    SUPPLIER_ADDRESS2 = ds_supplier.Tables[0].Rows[0]["SUP_ADD3"].ToString();
                    SUPPLIER_COUNTRY_NAME = ds_supplier.Tables[0].Rows[0]["SUP_COUNTRY_NAME"].ToString();
                    SUPPLIER_COUNTRY_CODE = ds_supplier.Tables[0].Rows[0]["SUP_COUNTRY_CODE"].ToString();
                    SUPPLIER_COUNTRY_PINCODE = ds_supplier.Tables[0].Rows[0]["SUP_PIN_CODE"].ToString();
                }
                else
                {
                    SUPPLIER_NAME = INV_Data.Rows[i][30].ToString();
                    SUPPLIER_ADDRESS = INV_Data.Rows[i][31].ToString();
                    SUPPLIER_ADDRESS1 = INV_Data.Rows[i][32].ToString();
                    SUPPLIER_ADDRESS2 = INV_Data.Rows[i][33].ToString();
                    SUPPLIER_COUNTRY_NAME = INV_Data.Rows[i][34].ToString();
                    SUPPLIER_COUNTRY_CODE = INV_Data.Rows[i][35].ToString();
                    SUPPLIER_COUNTRY_PINCODE = INV_Data.Rows[i][36].ToString();
                }
            }
            else
            {
                erm.SUP_ID = a1;
                erm.SUP_NAME = INV_Data.Rows[i][30].ToString();
                erm.SUP_ADD1 = INV_Data.Rows[i][31].ToString();
                erm.SUP_ADD2 = INV_Data.Rows[i][32].ToString();
                erm.SUP_ADD3 = INV_Data.Rows[i][33].ToString();
                erm.SUP_COUNTRY_CODE = INV_Data.Rows[i][35].ToString();
                erm.SUP_COUNTRY_NAME = INV_Data.Rows[i][34].ToString();
                erm.SUP_PIN_CODE = INV_Data.Rows[i][36].ToString();
                erm.SUP_REMARKS = "";

                erm.USER_ID = currentuser;
                erm.BRANCH_CODE = currentbranch;
                erm.flag = "S";
                erm.YEAR = a3;
                erm.EWorking_Period = Working_Period;

                ii = erm.Supplier_Master_Insert_update();

                SUPPLIER_NAME = INV_Data.Rows[i][30].ToString();
                SUPPLIER_ADDRESS = INV_Data.Rows[i][31].ToString();
                SUPPLIER_ADDRESS1 = INV_Data.Rows[i][32].ToString();
                SUPPLIER_ADDRESS2 = INV_Data.Rows[i][33].ToString();
                SUPPLIER_COUNTRY_NAME = INV_Data.Rows[i][34].ToString();
                SUPPLIER_COUNTRY_CODE = INV_Data.Rows[i][35].ToString();
                SUPPLIER_COUNTRY_PINCODE = INV_Data.Rows[i][36].ToString();
            }

            SELLER_NAME= INV_Data.Rows[i][46].ToString();
            SELLER_ADDRESS= INV_Data.Rows[i][47].ToString();
            SELLER_ADDRESS1= INV_Data.Rows[i][48].ToString();
            SELLER_ADDRESS2= INV_Data.Rows[i][49].ToString();
            SELLER_COUNTRY_NAME= INV_Data.Rows[i][50].ToString();
            SELLER_COUNTRY_CODE= INV_Data.Rows[i][51].ToString();
            SELLERCOUNTRY_PINCODE = INV_Data.Rows[i][52].ToString();

            BROKER_NAME = INV_Data.Rows[i][53].ToString();
            BROKER_ADDRESS = INV_Data.Rows[i][54].ToString();
            BROKER_ADDRESS1 = INV_Data.Rows[i][55].ToString();
            BROKER_ADDRESS2 = INV_Data.Rows[i][56].ToString();
            BROKER_COUNTRY_NAME = INV_Data.Rows[i][57].ToString();
            BROKER_COUNTRY_CODE = INV_Data.Rows[i][58].ToString();
            BROKER_COUNTRY_PINCODE = INV_Data.Rows[i][59].ToString();

            MIS_CHARGES= INV_Data.Rows[i][13].ToString();
            MIS_RATE= INV_Data.Rows[i][14].ToString();
            MIS_CURRENCY= INV_Data.Rows[i][15].ToString()== string.Empty ? INVOICE_CURRENCY : INV_Data.Rows[i][15].ToString();
            if (MIS_EXRATE == "" || MIS_CURRENCY == INVOICE_CURRENCY)
            {
                MIS_EXRATE = INVOICE_EXRATE;
            }
            

            MIS_AGENCY_CHARGES = INV_Data.Rows[i][16].ToString();
            MIS_AGENCY_RATE = INV_Data.Rows[i][17].ToString();
            MIS_AGENCY_CURRENCY = INV_Data.Rows[i][18].ToString() == string.Empty ? INVOICE_CURRENCY : INV_Data.Rows[i][18].ToString();
            //MIS_AGENCY_EXRATE = "";
            if (MIS_AGENCY_EXRATE == "" || MIS_AGENCY_CURRENCY == INVOICE_CURRENCY)
            {
                MIS_AGENCY_EXRATE = INVOICE_EXRATE;
            }
            if (MIS_AGENCY_RATE == "")
            {
                MIS_AGENCY_RATE = "0.00";
            }

            MIS_DISCOUNT_CHARGES = INV_Data.Rows[i][19].ToString();
            MIS_DISCOUNT_RATE = INV_Data.Rows[i][20].ToString();
            MIS_DISCOUNT_CURRENCY = INV_Data.Rows[i][21].ToString() == string.Empty ? INVOICE_CURRENCY : INV_Data.Rows[i][21].ToString();
            //MIS_DISCOUNT_EXRATE = "";
            if (MIS_DISCOUNT_EXRATE == "" || MIS_DISCOUNT_CURRENCY == INVOICE_CURRENCY)
            {
                MIS_DISCOUNT_EXRATE = INVOICE_EXRATE;
            }
            if (MIS_DISCOUNT_RATE == "")
            {
                MIS_DISCOUNT_RATE = "0.00";
            }

            MIS_DISCOUNT_REASON = INV_Data.Rows[i][22].ToString();
            MIS_LOADING_CHARGES = INV_Data.Rows[i][23].ToString();
            MIS_LOADING_RATE = INV_Data.Rows[i][24].ToString();
            MIS_LOADING_CURRENCY = INV_Data.Rows[i][25].ToString() == string.Empty ? INVOICE_CURRENCY : INV_Data.Rows[i][25].ToString();
            //MIS_LOADING_EXRATE = "";
            if (MIS_LOADING_EXRATE == "" || MIS_LOADING_CURRENCY == INVOICE_CURRENCY)
            {
                MIS_LOADING_EXRATE = INVOICE_EXRATE;
            }

            MIS_FREIGHT_CHARGES = INV_Data.Rows[i][7].ToString();
            MIS_FREIGHT_RATE = INV_Data.Rows[i][8].ToString();
            MIS_FREIGHT_CURRENCY = INV_Data.Rows[i][9].ToString() == string.Empty ? INVOICE_CURRENCY : INV_Data.Rows[i][9].ToString();
            //MIS_FREIGHT_EXRATE = "";
            if (MIS_FREIGHT_EXRATE == "" || MIS_FREIGHT_CURRENCY == INVOICE_CURRENCY)
            {
                MIS_FREIGHT_EXRATE = INVOICE_EXRATE;
            }
            if (MIS_FREIGHT_RATE == "")
            {
                MIS_FREIGHT_RATE = "0.00";
            }

            MIS_INSURANCE_CHARGES = INV_Data.Rows[i][10].ToString();
            MIS_INSURANCE_RATE = INV_Data.Rows[i][11].ToString();
            MIS_INSURANCE_CURRENCY = INV_Data.Rows[i][12].ToString() == string.Empty ? INVOICE_CURRENCY : INV_Data.Rows[i][12].ToString();
            //MIS_INSURANCE_EXRATE = "";
            if (MIS_INSURANCE_EXRATE == "" || MIS_INSURANCE_CURRENCY == INVOICE_CURRENCY)
            {
                MIS_INSURANCE_EXRATE = INVOICE_EXRATE;
            }
            if (MIS_INSURANCE_RATE != "")
            {
                double Ins_Rate = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                MIS_INSURANCE_CHARGES = Convert.ToString(Ins_Rate);
            }
            else
            {
                MIS_INSURANCE_RATE = "0.00";
            }


            MIS_HIGHSEASALE_CHARGES = INV_Data.Rows[i][26].ToString();
            MIS_HIGHSEASALE_RATE = INV_Data.Rows[i][27].ToString();
            MIS_HIGHSEASALE_CURRENCY = INV_Data.Rows[i][28].ToString() == string.Empty ? "INR" : INV_Data.Rows[i][15].ToString(); ;
            MIS_HIGHSEASALE_EXRATE = "";
            if (MIS_HIGHSEASALE_EXRATE == "")
            {
                MIS_HIGHSEASALE_CURRENCY = "INR";
            }
            if (MIS_HIGHSEASALE_RATE == "")
            {
                MIS_HIGHSEASALE_RATE = "0.00";
            }

            if (INV_Data.Rows.Count == 1)
            {
                MIS_SINGLE_OR_MULITIPLE = "S";
            }
            else
            {
                MIS_SINGLE_OR_MULITIPLE = "M";
            }


            SVB_RELATION = INV_Data.Rows[i][37].ToString() == string.Empty ? "N" : INV_Data.Rows[i][37].ToString();
            SVB_REF_NO = INV_Data.Rows[i][38].ToString();
            SVB_REF_DATE = INV_Data.Rows[i][39].ToString() == string.Empty ? "01/01/1900" : INV_Data.Rows[i][39].ToString();
            SVB_CUSTOM_HOUSE = INV_Data.Rows[i][40].ToString();
            if (INV_Data.Rows[i][41].ToString() != "")
            {
                SVB_LOADING_ON = INV_Data.Rows[i][41].ToString().Substring(0, 1);
            }
            else
            {
                SVB_LOADING_ON = "";
            }
            SVB_ASSESABLE_RATE = INV_Data.Rows[i][42].ToString();
            SVB_DUTY_RATE = INV_Data.Rows[i][43].ToString();
            //SVB_ASSESABLE_STATUS = INV_Data.Rows[i][44].ToString();
            if (INV_Data.Rows[i][44].ToString() != "")
            {
                SVB_ASSESABLE_STATUS = INV_Data.Rows[i][44].ToString().Substring(0, 1);
            }
            else
            {
                SVB_ASSESABLE_STATUS = "";
            }
            //SVB_DUTY_STATUS = INV_Data.Rows[i][45].ToString();
            if (INV_Data.Rows[i][45].ToString() != "")
            {
                SVB_DUTY_STATUS = INV_Data.Rows[i][45].ToString().Substring(0, 1);
            }
            else
            {
                SVB_DUTY_STATUS = "";
            }

            OTHER_PURCHASE_ORDER = INV_Data.Rows[i][60].ToString();
            OTHER_PURCHASE_ORDER_DATE = INV_Data.Rows[i][61].ToString() == string.Empty ? "01/01/1900" : INV_Data.Rows[i][61].ToString(); 
            OTHER_CONTRACT_NO = INV_Data.Rows[i][62].ToString();
            OTHER_CONTRACT_DATE = INV_Data.Rows[i][63].ToString() == string.Empty ? "01/01/1900" : INV_Data.Rows[i][63].ToString(); 
            OTHER_LOC_NO = INV_Data.Rows[i][64].ToString();
            OTHER_LOC_DATE = INV_Data.Rows[i][65].ToString() == string.Empty ? "01/01/1900" : INV_Data.Rows[i][65].ToString(); 
            OTHER_NATURE_OF_TRANSACTION = INV_Data.Rows[i][66].ToString();
            OTHER_TERMS_OF_PAYMENT = INV_Data.Rows[i][67].ToString();
            OTHER_CONDITIONS = INV_Data.Rows[i][68].ToString();
            OTHER_VALUATION_METHOD = INV_Data.Rows[i][69].ToString();
            USER_ID=currentuser;
            DATE_TIME=LoginDate;
            STATUS="N";
            BRANCH_CODE=currentbranch;
            YEAR = "";
            WORKING_PERIOD = Working_Period;

            NON_STD_EFFECT_DT_IMP = INV_Data.Rows[i][70].ToString() == string.Empty ? "01/01/1900" : INV_Data.Rows[i][70].ToString();
            NON_STD_BANKNAME = INV_Data.Rows[i][71].ToString();
            NON_STD_CERTIFICATE_NO = INV_Data.Rows[i][72].ToString();
            NON_STD_CERTIFICATE_DATE = INV_Data.Rows[i][73].ToString() == string.Empty ? "01/01/1900" : INV_Data.Rows[i][73].ToString();

            SAP_DELIEVERY_ID = INV_Data.Rows[i][74].ToString();
            SHIP_DATE = INV_Data.Rows[i][75].ToString() == string.Empty ? "01/01/1900" : INV_Data.Rows[i][75].ToString();
            INVOICE_LEVEL = "";
            COUNTRY_OF_DEPARTURE = INV_Data.Rows[i][76].ToString();
            REVENUEDEPOSIT_RATE = INV_Data.Rows[i][77].ToString();
            REVENUEDEPOSIT_ON = INV_Data.Rows[i][78].ToString();

            MI_FREIGHT =  "";
            MI_INSURANCE = "";
            MI_MISC = "";
            MI_HSS = "";
            MODIFIEDBY = currentuser;
            MODIFIEDON = LoginDate;
            INDEV_INV_TYPE = ""; 

            TERMS_PLACE = INV_Data.Rows[i][79].ToString();
            THIRDPARTY_NAME = INV_Data.Rows[i][80].ToString();
            THIRDPARTY_ADD1 = INV_Data.Rows[i][81].ToString();
            THIRDPARTY_ADD2 = INV_Data.Rows[i][82].ToString();
            THIRDPARTY_CITY = INV_Data.Rows[i][83].ToString();
            T_PARTY_COUNTRY_SUB_DIV = INV_Data.Rows[i][84].ToString();
            T_PARTY_COUNTRY_CODE = INV_Data.Rows[i][85].ToString();
            T_PARTY_PIN = INV_Data.Rows[i][86].ToString();
            AUTHORIZED_ECONOMIC_OPERATOR_CODE = INV_Data.Rows[i][87].ToString();
            A_E_O_COUNTRY = INV_Data.Rows[i][88].ToString();
            AUTHORIZED_ECONOMIC_OPERATOR = INV_Data.Rows[i][89].ToString();
            WHETHER_BUYER_SELLER_RELATED = INV_Data.Rows[i][90].ToString();
            D_AMOUNT = INV_Data.Rows[i][91].ToString();
            M_AMOUNT = INV_Data.Rows[i][92].ToString();
            N_AMOUNT = INV_Data.Rows[i][93].ToString();

            double tot_other_amt = Convert.ToDouble(INV_Data.Rows[i][91].ToString() == string.Empty ? "0" : INV_Data.Rows[i][91].ToString()) + Convert.ToDouble(INV_Data.Rows[i][92].ToString() == string.Empty ? "0" : INV_Data.Rows[i][92].ToString()) + Convert.ToDouble(INV_Data.Rows[i][93].ToString() == string.Empty ? "0" : INV_Data.Rows[i][93].ToString());
            if(tot_other_amt!=0)
            {
                TOTAL_OTHER_AMOUNT=Convert.ToString(tot_other_amt);
            }
            else
            { 
                TOTAL_OTHER_AMOUNT="";
            }

            MAX_ID = Get_general_MAXID("INVOICE_MAX_ID");

            dt_INV.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, INVOICE_NO, INVOICE_DATE, TERMS, INVOICE_CURRENCY, INVOICE_EXRATE, INVOICE_VALUE,
                            SUPPLIER_NAME,SUPPLIER_ADDRESS,SUPPLIER_ADDRESS1,SUPPLIER_ADDRESS2,SUPPLIER_COUNTRY_NAME,SUPPLIER_COUNTRY_CODE,SUPPLIER_COUNTRY_PINCODE,
                            SELLER_NAME,SELLER_ADDRESS,SELLER_ADDRESS1,SELLER_ADDRESS2,SELLER_COUNTRY_NAME,SELLER_COUNTRY_CODE,SELLERCOUNTRY_PINCODE,
                            BROKER_NAME,BROKER_ADDRESS,BROKER_ADDRESS1,BROKER_ADDRESS2,BROKER_COUNTRY_NAME,BROKER_COUNTRY_CODE,BROKER_COUNTRY_PINCODE,
                            MIS_CHARGES,MIS_RATE,MIS_CURRENCY,MIS_EXRATE,MIS_AGENCY_CHARGES,MIS_AGENCY_RATE,MIS_AGENCY_CURRENCY,MIS_AGENCY_EXRATE,
                            MIS_DISCOUNT_CHARGES,MIS_DISCOUNT_RATE,MIS_DISCOUNT_CURRENCY,MIS_DISCOUNT_EXRATE,MIS_DISCOUNT_REASON,MIS_LOADING_CHARGES,MIS_LOADING_RATE,
                            MIS_LOADING_CURRENCY,MIS_LOADING_EXRATE,MIS_FREIGHT_CHARGES,MIS_FREIGHT_RATE,MIS_FREIGHT_CURRENCY,MIS_FREIGHT_EXRATE,
                            MIS_INSURANCE_CHARGES,MIS_INSURANCE_RATE,MIS_INSURANCE_CURRENCY,MIS_INSURANCE_EXRATE,MIS_HIGHSEASALE_CHARGES,
                            MIS_HIGHSEASALE_RATE,MIS_INSURANCE_CURRENCY,MIS_INSURANCE_EXRATE,MIS_SINGLE_OR_MULITIPLE,SVB_RELATION,SVB_REF_NO,SVB_REF_DATE,
                            SVB_CUSTOM_HOUSE,SVB_LOADING_ON,SVB_ASSESABLE_RATE,SVB_DUTY_RATE,SVB_ASSESABLE_STATUS,SVB_DUTY_STATUS,OTHER_PURCHASE_ORDER,OTHER_PURCHASE_ORDER_DATE,
                            OTHER_CONTRACT_NO,OTHER_CONTRACT_DATE,OTHER_LOC_NO,OTHER_LOC_DATE,OTHER_NATURE_OF_TRANSACTION,OTHER_TERMS_OF_PAYMENT,OTHER_CONDITIONS,OTHER_VALUATION_METHOD,
                            USER_ID,DATE_TIME,STATUS,BRANCH_CODE,YEAR,WORKING_PERIOD,NON_STD_EFFECT_DT_IMP,NON_STD_BANKNAME,NON_STD_CERTIFICATE_NO,NON_STD_CERTIFICATE_DATE,
                            SAP_DELIEVERY_ID, SHIP_DATE, INVOICE_LEVEL, COUNTRY_OF_DEPARTURE, REVENUEDEPOSIT_RATE, REVENUEDEPOSIT_ON,MI_FREIGHT,MI_INSURANCE,MI_MISC,MI_HSS,
                            MODIFIEDBY,MODIFIEDON,INDEV_INV_TYPE,TERMS_PLACE,THIRDPARTY_NAME,THIRDPARTY_ADD1,THIRDPARTY_ADD2,THIRDPARTY_CITY,T_PARTY_COUNTRY_SUB_DIV,
                            T_PARTY_COUNTRY_CODE, T_PARTY_PIN, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR, WHETHER_BUYER_SELLER_RELATED,
                            "", "", "", D_AMOUNT, "", "", "", "", "", "", "", "", M_AMOUNT, N_AMOUNT, TOTAL_OTHER_AMOUNT);

        }

        ds_INVOICE = dt_INV;
        ViewState["dt_INV"] = ds_INVOICE;
        return ds_INVOICE;
    }

    public DataTable Bind_ITEM_Details(DataTable Item_Data)
    {
        #region dt_ITEM
        dt_ITEM.Columns.Add("ITEM_ID");
        dt_ITEM.Columns.Add("JOBNO");
        dt_ITEM.Columns.Add("INVOICE_SLNO");
        dt_ITEM.Columns.Add("INVOICE_NO");
        dt_ITEM.Columns.Add("ITEM_SLNO");
        dt_ITEM.Columns.Add("ITEM_DESCRIPTION");
        dt_ITEM.Columns.Add("ITEM_QTY");
        dt_ITEM.Columns.Add("ITEM_QTY_CODE");
        dt_ITEM.Columns.Add("ITEM_UNIT_PRICE");
        dt_ITEM.Columns.Add("ITEM_UNIT_CODE");
        dt_ITEM.Columns.Add("ITEM_TOTAL_AMOUNT");
        dt_ITEM.Columns.Add("ITEM_AMOUNT_CODE");
        dt_ITEM.Columns.Add("CTH_NO");
        dt_ITEM.Columns.Add("SCHEME_CODE");
        dt_ITEM.Columns.Add("SCHEME_NOTN");
        dt_ITEM.Columns.Add("SCHEME_NOTN_SLNO");
        dt_ITEM.Columns.Add("CTH_QTY1");
        dt_ITEM.Columns.Add("CTH_QTY1_CODE");
        dt_ITEM.Columns.Add("CTH_QTY2");
        dt_ITEM.Columns.Add("CTH_QTY2_CODE");
        dt_ITEM.Columns.Add("GENEARL_DESCRIPTION");
        dt_ITEM.Columns.Add("MANUFACTURER");
        dt_ITEM.Columns.Add("BRAND");
        dt_ITEM.Columns.Add("MODEL");
        dt_ITEM.Columns.Add("END_USE_OF_ITEM");
        dt_ITEM.Columns.Add("COUNTRY_OF_ORIGIN");
        dt_ITEM.Columns.Add("ACCESSORIES");
        dt_ITEM.Columns.Add("PREVIOUS_BE_NO");
        dt_ITEM.Columns.Add("PREVIOUS_BE_DATE");
        dt_ITEM.Columns.Add("UNIT_PRICE");
        dt_ITEM.Columns.Add("UNIT_CODE");
        dt_ITEM.Columns.Add("CUSTOMS_HOUSE");
        dt_ITEM.Columns.Add("PRODUCT_RITC");
        dt_ITEM.Columns.Add("PRODUCT_CTH");
        dt_ITEM.Columns.Add("PRODUCT_BCD_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_BCD_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_BCD_RATE");
        dt_ITEM.Columns.Add("PRODUCT_BCD_SPL");
        dt_ITEM.Columns.Add("PRODUCT_BCD_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_BCD_SPL_TYPE");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_DUTY_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_DUTY_NOTN_SL");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_DUTY_RATE");
        dt_ITEM.Columns.Add("PRODUCT_EDU_CESS_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_EDU_CESS_NOTN_SL");
        dt_ITEM.Columns.Add("PRODUCT_EDU_CESS_RATE");
        dt_ITEM.Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN_SL");
        dt_ITEM.Columns.Add("PRODUCT_SEC_EDU_CESS_RATE");
        dt_ITEM.Columns.Add("PRODUCT_NCD_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_NCD_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_NCD_RATE");
        dt_ITEM.Columns.Add("PRODUCT_NCD_SPL");
        dt_ITEM.Columns.Add("PRODUCT_NCD_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_NCD_SPL_TYPE");
        dt_ITEM.Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_SL");
        dt_ITEM.Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_RATE");
        dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_RATE");
        dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_SPL");
        dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_SPL_TYPE");
        dt_ITEM.Columns.Add("PRODUCT_SAPTA_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_SAPTA_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_SAPTA_RATE");
        dt_ITEM.Columns.Add("PRODUCT_TARIFF_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_TARIFF_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_TARIFF_QTY");
        dt_ITEM.Columns.Add("PRODUCT_TARIFF_AMOUNT");
        dt_ITEM.Columns.Add("PRODUCT_TARIFF_AMOUNT_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_CETH");
        dt_ITEM.Columns.Add("PRODUCT_MRP_YN");
        dt_ITEM.Columns.Add("PRODUCT_MRP_SL_NO");
        dt_ITEM.Columns.Add("PRODUCT_MRP_AMOUNT");
        dt_ITEM.Columns.Add("PRODUCT_MRP_ABT_RATE");
        dt_ITEM.Columns.Add("PRODUCT_CVD_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_CVD_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_CVD_RATE");
        dt_ITEM.Columns.Add("PRODUCT_CVD_SPL");
        dt_ITEM.Columns.Add("PRODUCT_CVD_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_CVD_SPL_TYPE");
        dt_ITEM.Columns.Add("PRODUCT_CVD_EDU_CESS_RATE");
        dt_ITEM.Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_RATE");
        dt_ITEM.Columns.Add("PRODUCT_ADDL5_SIA_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_ADDL5_SIA_NOTN_SL");
        dt_ITEM.Columns.Add("PRODUCT_ADDL5_SIA_RATE");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_RATE");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_SPL");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_SPL_TYPE");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_RATE");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_SPL");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_TYPE");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_RATE");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_SPL");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_TYPE");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_RATE");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SPL");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_TYPE");
        dt_ITEM.Columns.Add("PRODUCT_CESS_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_CESS_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_CESS_RATE");
        dt_ITEM.Columns.Add("PRODUCT_CESS_SPL");
        dt_ITEM.Columns.Add("PRODUCT_CESS_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_CESS_TYPE");
        dt_ITEM.Columns.Add("ANTI_DUMPING_NOTN");
        dt_ITEM.Columns.Add("ANTI_DUMPING_NOTN_SLNO");
        dt_ITEM.Columns.Add("CTH_SLNO");
        dt_ITEM.Columns.Add("CTH_SUPPLIER_SLNO");
        dt_ITEM.Columns.Add("CTH_QTY");
        dt_ITEM.Columns.Add("RSP_DUTY_STATUS");
        dt_ITEM.Columns.Add("RSP_SL_NO");
        dt_ITEM.Columns.Add("RSP_DESC");
        dt_ITEM.Columns.Add("RSP_QTY");
        dt_ITEM.Columns.Add("RSP_AMOUNT");
        dt_ITEM.Columns.Add("RSP_NOTN_NO");
        dt_ITEM.Columns.Add("RSP_NOTN_SL_NO");
        dt_ITEM.Columns.Add("RSP_ABT_RATE");
        dt_ITEM.Columns.Add("WAREHOUSE_JOBNO");
        dt_ITEM.Columns.Add("WAREHOUSE_INVOICE_SLNO");
        dt_ITEM.Columns.Add("WAREHOUSE_ITEM_SLNO");
        dt_ITEM.Columns.Add("ASSESSABLE_VALUE");
        dt_ITEM.Columns.Add("DUTY_VALUE");
        dt_ITEM.Columns.Add("CIF_VALUE");
        dt_ITEM.Columns.Add("CVD_VALUE");
        dt_ITEM.Columns.Add("USER_ID");
        dt_ITEM.Columns.Add("DATE_TIME");
        dt_ITEM.Columns.Add("STATUS");
        dt_ITEM.Columns.Add("BRANCH_CODE");
        dt_ITEM.Columns.Add("YEAR");
        dt_ITEM.Columns.Add("WORKING_PERIOD");
        dt_ITEM.Columns.Add("BASIC_VALUE");
        dt_ITEM.Columns.Add("CEC_VALUE");
        dt_ITEM.Columns.Add("CHEC_VALUE");
        dt_ITEM.Columns.Add("ADD_DUTY_VALUE");
        dt_ITEM.Columns.Add("CETH_CVD_EDU_CESS_SL");
        dt_ITEM.Columns.Add("CETH_CVD_EDU_CESS_RATE");
        dt_ITEM.Columns.Add("CETH_CVD_SEC_EDU_CESS_SL");
        dt_ITEM.Columns.Add("CETH_CVD_SEC_EDU_CESS_RATE");
        dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_NOTN");
        dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_SLNO");
        dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_RATE");
        dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_SPL");
        dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_UNIT");
        dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_TYPE");
        dt_ITEM.Columns.Add("MODIFIEDBY");
        dt_ITEM.Columns.Add("MODIFIEDON");
        dt_ITEM.Columns.Add("INDIVITUAL_FREIGHT_AMOUNT");
        dt_ITEM.Columns.Add("INDIVITUAL_INSURANCE_AMOUNT");
        dt_ITEM.Columns.Add("INDIVITUAL_MISC_AMOUNT");
        dt_ITEM.Columns.Add("SVB_RELATION");
        dt_ITEM.Columns.Add("SVB_REF_NO");
        dt_ITEM.Columns.Add("SVB_REF_DATE");
        dt_ITEM.Columns.Add("SVB_CUSTOM_HOUSE");
        dt_ITEM.Columns.Add("SVB_LOADING_ON");
        dt_ITEM.Columns.Add("SVB_ASSESABLE_RATE");
        dt_ITEM.Columns.Add("SVB_DUTY_RATE");
        dt_ITEM.Columns.Add("SVB_ASSESABLE_STATUS");
        dt_ITEM.Columns.Add("SVB_DUTY_STATUS");
        dt_ITEM.Columns.Add("INDIVITUAL_EDU_CESS_AMT");
        dt_ITEM.Columns.Add("INDIVITUAL_SEC_HIGHER_CESS_AMT");
        dt_ITEM.Columns.Add("INDIVITUAL_LANDING_CHARGE");
        dt_ITEM.Columns.Add("CHECKLIST_BCD_RATE");
        dt_ITEM.Columns.Add("CHECKLIST_CVD_RATE");
        dt_ITEM.Columns.Add("CHECKLIST_ADDL_DUTY_RATE");
        dt_ITEM.Columns.Add("INDEV_RACK_TYPE");
        dt_ITEM.Columns.Add("MERIT_DUTY_VALUE");
        dt_ITEM.Columns.Add("RSP_APPLICABLE");
        dt_ITEM.Columns.Add("CENTRAL_EXCISE_FLAG");
        dt_ITEM.Columns.Add("MANUFACTURER_PRODUCER");
        dt_ITEM.Columns.Add("M_P_GROWER_CODE");
        dt_ITEM.Columns.Add("M_P_GROWER_ADD1");
        dt_ITEM.Columns.Add("M_P_GROWER_ADD2");
        dt_ITEM.Columns.Add("M_P_GROWER_CITY");
        dt_ITEM.Columns.Add("M_P_GROWER_COUNTRY_SUBDIV");
        dt_ITEM.Columns.Add("M_P_GROWER_PIN");
        dt_ITEM.Columns.Add("M_P_GROWER_COUNTRY");
        dt_ITEM.Columns.Add("SOURCE_COUNTRY");
        dt_ITEM.Columns.Add("TRANSIT_COUNTRY");
        dt_ITEM.Columns.Add("ACCESSORY_STATUS");
        dt_ITEM.Columns.Add("INFRA_CESS_NOTN");
        dt_ITEM.Columns.Add("INFRA_CESS_NOTN_SL");
        dt_ITEM.Columns.Add("INFRA_CESS_NOTN_RATE");
        dt_ITEM.Columns.Add("MERIT_BASIC_VALUE");
        dt_ITEM.Columns.Add("MERIT_CVD_VALUE");
        dt_ITEM.Columns.Add("MERIT_CEC_VALUE");
        dt_ITEM.Columns.Add("MERIT_CHEC_VALUE");
        dt_ITEM.Columns.Add("MERIT_ADD_DUTY_VALUE");
        dt_ITEM.Columns.Add("MERIT_NOTN_BASIC_VALUE");
        dt_ITEM.Columns.Add("MERIT_NOTN_CVD_VALUE");
        dt_ITEM.Columns.Add("MERIT_NOTN_CEC_VALUE");
        dt_ITEM.Columns.Add("MERIT_NOTN_CHEC_VALUE");
        dt_ITEM.Columns.Add("MERIT_NOTN_ADD_DUTY_VALUE");
        dt_ITEM.Columns.Add("MERIT_NOTN_CESS_VALUE");
        dt_ITEM.Columns.Add("MERIT_NOTN_NCD_VALUE");
        dt_ITEM.Columns.Add("INDIVITUAL_HSS_AMOUNT");

        dt_ITEM.Columns.Add("IGST_LEVY_NOTN");
        dt_ITEM.Columns.Add("IGST_LEVY_SLNO");
        dt_ITEM.Columns.Add("IGST_LEVY_RATE");
        dt_ITEM.Columns.Add("IGST_LEVY_SPL");
        dt_ITEM.Columns.Add("IGST_LEVY_UNIT");
        dt_ITEM.Columns.Add("IGST_LEVY_SPL_TYPE");
        dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_NOTN");
        dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_SLNO");
        dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_RATE");
        dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_NOTN");
        dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SLNO");
        dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_RATE");
        dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SPL");
        dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_UNIT");
        dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SPL_TYPE");
        dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_CC_NOTN");
        dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_CC_SLNO");
        dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_CC_RATE");
        dt_ITEM.Columns.Add("LEVY_EXCEMPTION_NOTN_TYPE");
        dt_ITEM.Columns.Add("LEVY_EXCEPTION_CC_NOTN_TYPE");
        dt_ITEM.Columns.Add("CHECKLIST_IGST_LEVY_AMOUNT");
        dt_ITEM.Columns.Add("CHECKLIST_COMPENSATION_CC_AMOUNT");
        #endregion dt_ITEM

        //******************** Remove Empty Rows from Datatable  ********************************

        Item_Data = Item_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //****************************************************************************************

        for (int i = 0; i <= Item_Data.Rows.Count - 1; i++)
        {
            INVOICE_ID = Convert.ToString(i);

            JOBNO = IMPORT_JOBNO;
            INVOICE_SLNO = Item_Data.Rows[i][0].ToString();
            INVOICE_NO = Item_Data.Rows[i][1].ToString();
            ITEM_SLNO = Item_Data.Rows[i][2].ToString();
            ITEM_DESCRIPTION = Item_Data.Rows[i][3].ToString();
            ITEM_QTY = Item_Data.Rows[i][4].ToString();
            ITEM_QTY_CODE = Item_Data.Rows[i][5].ToString();
            ITEM_UNIT_PRICE = Item_Data.Rows[i][6].ToString();
            ITEM_UNIT_CODE = Item_Data.Rows[i][7].ToString();
            double TOTAL_AMOUNT = 0.00;

            if (ITEM_QTY != "" && ITEM_UNIT_PRICE != "")
            {
                 TOTAL_AMOUNT = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE);
            }
            ITEM_TOTAL_AMOUNT =Convert.ToString(TOTAL_AMOUNT);
            ITEM_AMOUNT_CODE = Item_Data.Rows[i][7].ToString();
            CTH_NO = Item_Data.Rows[i][9].ToString();
            SCHEME_CODE = Item_Data.Rows[i][10].ToString();
            SCHEME_NOTN = Item_Data.Rows[i][11].ToString();
            SCHEME_NOTN_SLNO = Item_Data.Rows[i][12].ToString();
            CTH_QTY1 = Item_Data.Rows[i][13].ToString();
            CTH_QTY1_CODE = Item_Data.Rows[i][14].ToString();
            CTH_QTY2 = Item_Data.Rows[i][15].ToString();
            CTH_QTY2_CODE = Item_Data.Rows[i][16].ToString();

            GENEARL_DESCRIPTION = Item_Data.Rows[i][17].ToString();
            MANUFACTURER = Item_Data.Rows[i][18].ToString();
            BRAND = Item_Data.Rows[i][19].ToString();
            MODEL = Item_Data.Rows[i][20].ToString();
            END_USE_OF_ITEM = Item_Data.Rows[i][21].ToString();
            COUNTRY_OF_ORIGIN = Item_Data.Rows[i][22].ToString();
            ACCESSORIES = Item_Data.Rows[i][23].ToString();
            PREVIOUS_BE_NO = Item_Data.Rows[i][24].ToString();
            PREVIOUS_BE_DATE = Item_Data.Rows[i][25].ToString() == string.Empty ? "01/01/1900" : Item_Data.Rows[i][25].ToString();
            UNIT_PRICE = Item_Data.Rows[i][26].ToString();
            UNIT_CODE = Item_Data.Rows[i][27].ToString();
            CUSTOMS_HOUSE = Item_Data.Rows[i][28].ToString();
            PRODUCT_RITC = Item_Data.Rows[i][8].ToString();
            PRODUCT_CTH = Item_Data.Rows[i][9].ToString();

            PRODUCT_BCD_NOTN = Item_Data.Rows[i][29].ToString();
            PRODUCT_BCD_SLNO = Item_Data.Rows[i][30].ToString();
            PRODUCT_BCD_RATE = "";//***********
            PRODUCT_BCD_SPL = "";//***********
            PRODUCT_BCD_UNIT = "";//***********
            PRODUCT_BCD_SPL_TYPE = "";//***********

            PRODUCT_ADDL_DUTY_NOTN = "";
            PRODUCT_ADDL_DUTY_NOTN_SL = "";
            PRODUCT_ADDL_DUTY_RATE = "";

            PRODUCT_EDU_CESS_NOTN = Item_Data.Rows[i][31].ToString();
            PRODUCT_EDU_CESS_NOTN_SL = Item_Data.Rows[i][32].ToString();
            PRODUCT_EDU_CESS_RATE = "";//***********

            PRODUCT_SEC_EDU_CESS_NOTN = Item_Data.Rows[i][33].ToString();
            PRODUCT_SEC_EDU_CESS_NOTN_SL = Item_Data.Rows[i][34].ToString();
            PRODUCT_SEC_EDU_CESS_RATE = "";//***********

            PRODUCT_NCD_NOTN = Item_Data.Rows[i][35].ToString();
            PRODUCT_NCD_SLNO = Item_Data.Rows[i][36].ToString();
            PRODUCT_NCD_RATE = "";
            PRODUCT_NCD_SPL = "";
            PRODUCT_NCD_UNIT = "";
            PRODUCT_NCD_SPL_TYPE = "";

            PRODUCT_AGGREGATE_DUTY_NOTN = Item_Data.Rows[i][37].ToString();
            PRODUCT_AGGREGATE_DUTY_NOTN_SL = Item_Data.Rows[i][38].ToString();
            PRODUCT_AGGREGATE_DUTY_NOTN_RATE = "";

            PRODUCT_SAFEGUARD_NOTN = Item_Data.Rows[i][39].ToString();
            PRODUCT_SAFEGUARD_SLNO = Item_Data.Rows[i][40].ToString();
            PRODUCT_SAFEGUARD_RATE = "";
            PRODUCT_SAFEGUARD_SPL = "";
            PRODUCT_SAFEGUARD_UNIT = "";
            PRODUCT_SAFEGUARD_SPL_TYPE = "";

            PRODUCT_SAPTA_NOTN = Item_Data.Rows[i][41].ToString();
            PRODUCT_SAPTA_SLNO = Item_Data.Rows[i][42].ToString();
            PRODUCT_SAPTA_RATE = "";

            PRODUCT_TARIFF_NOTN = Item_Data.Rows[i][43].ToString();
            PRODUCT_TARIFF_SLNO = Item_Data.Rows[i][44].ToString();
            PRODUCT_TARIFF_QTY = Item_Data.Rows[i][45].ToString();
            PRODUCT_TARIFF_AMOUNT = Item_Data.Rows[i][46].ToString();
            PRODUCT_TARIFF_AMOUNT_UNIT = Item_Data.Rows[i][47].ToString();

            PRODUCT_CETH = Item_Data.Rows[i][48].ToString();
            PRODUCT_MRP_YN = "";
            PRODUCT_MRP_SL_NO = "";
            PRODUCT_MRP_AMOUNT = "";
            PRODUCT_MRP_ABT_RATE = "";

            PRODUCT_CVD_NOTN = Item_Data.Rows[i][49].ToString();
            PRODUCT_CVD_SLNO = Item_Data.Rows[i][50].ToString();
            PRODUCT_CVD_RATE = "";
            PRODUCT_CVD_SPL = "";
            PRODUCT_CVD_UNIT = "";
            PRODUCT_CVD_SPL_TYPE = "";
            PRODUCT_CVD_EDU_CESS_RATE = "";
            PRODUCT_CVD_SEC_EDU_CESS_RATE = "";
            PRODUCT_ADDL5_SIA_NOTN = "";
            PRODUCT_ADDL5_SIA_NOTN_SL = "";
            PRODUCT_ADDL5_SIA_RATE = "";
            PRODUCT_ADDL_GSI_NOTN = "";
            PRODUCT_ADDL_GSI_SLNO = "";
            PRODUCT_ADDL_GSI_RATE = "";
            PRODUCT_ADDL_GSI_SPL = "";
            PRODUCT_ADDL_GSI_UNIT = "";
            PRODUCT_ADDL_GSI_SPL_TYPE = "";
            PRODUCT_ADDL_SHEII_NOTN = Item_Data.Rows[i][51].ToString();
            PRODUCT_ADDL_SHEII_SLNO = Item_Data.Rows[i][52].ToString();
            PRODUCT_ADDL_SHEII_RATE = "";
            PRODUCT_ADDL_SHEII_SPL = "";
            PRODUCT_ADDL_SHEII_UNIT = "";
            PRODUCT_ADDL_SHEII_TYPE = "";
            PRODUCT_ADDL_TTA_NOTN = "";
            PRODUCT_ADDL_TTA_SLNO = "";
            PRODUCT_ADDL_TTA_RATE = "";
            PRODUCT_ADDL_TTA_SPL = "";
            PRODUCT_ADDL_TTA_UNIT = "";
            PRODUCT_ADDL_TTA_TYPE = "";
            PRODUCT_ADDL_HEALTH_CESS_NOTN = Item_Data.Rows[i][53].ToString();
            PRODUCT_ADDL_HEALTH_CESS_SLNO = Item_Data.Rows[i][54].ToString();
            PRODUCT_ADDL_HEALTH_CESS_RATE = "";
            PRODUCT_ADDL_HEALTH_CESS_SPL = "";
            PRODUCT_ADDL_HEALTH_CESS_UNIT = "";
            PRODUCT_ADDL_HEALTH_CESS_TYPE = "";
            PRODUCT_CESS_NOTN = Item_Data.Rows[i][55].ToString();
            PRODUCT_CESS_SLNO = Item_Data.Rows[i][56].ToString();
            PRODUCT_CESS_RATE = "";
            PRODUCT_CESS_SPL = "";
            PRODUCT_CESS_UNIT = "";
            PRODUCT_CESS_TYPE = "";
            ANTI_DUMPING_NOTN = Item_Data.Rows[i][59].ToString();
            ANTI_DUMPING_NOTN_SLNO = Item_Data.Rows[i][60].ToString();
            CTH_SLNO = Item_Data.Rows[i][61].ToString();
            CTH_SUPPLIER_SLNO = Item_Data.Rows[i][62].ToString();
            CTH_QTY = Item_Data.Rows[i][63].ToString();
            //RSP_DUTY_STATUS
            //RSP_SL_NO
            //RSP_DESC
            //RSP_QTY
            //RSP_AMOUNT
            //RSP_NOTN_NO
            //RSP_NOTN_SL_NO
            //RSP_ABT_RATE

            WAREHOUSE_JOBNO = "0";
            WAREHOUSE_INVOICE_SLNO = "0";
            WAREHOUSE_ITEM_SLNO = "0";
            ASSESSABLE_VALUE = "";
            DUTY_VALUE = "";
            CIF_VALUE = "";
            CVD_VALUE = "";
            USER_ID = currentuser;
            DATE_TIME = LoginDate;
            STATUS = "S";
            BRANCH_CODE = currentbranch;
            YEAR = YEAR;
            WORKING_PERIOD = Working_Period;
            BASIC_VALUE = "";
            CEC_VALUE = "";
            CHEC_VALUE = "";
            ADD_DUTY_VALUE = "";
            CETH_CVD_EDU_CESS_SL = "";
            CETH_CVD_EDU_CESS_RATE = "0.00";
            CETH_CVD_SEC_EDU_CESS_SL = "";
            CETH_CVD_SEC_EDU_CESS_RATE = "";
            PRODUCT_OTHER_DUTY_NOTN = Item_Data.Rows[i][57].ToString();
            PRODUCT_OTHER_DUTY_SLNO = Item_Data.Rows[i][58].ToString();
            PRODUCT_OTHER_DUTY_RATE = "";
            PRODUCT_OTHER_DUTY_SPL = "";
            PRODUCT_OTHER_DUTY_UNIT = "";
            PRODUCT_OTHER_DUTY_TYPE = "";
            MODIFIEDBY = currentuser;
            MODIFIEDON = LoginDate;
            INDIVITUAL_FREIGHT_AMOUNT = "";
            INDIVITUAL_INSURANCE_AMOUNT = "";
            INDIVITUAL_MISC_AMOUNT = "";

            SVB_RELATION = "";
            SVB_REF_NO = "";
            SVB_REF_DATE = "01/01/1900";
            SVB_CUSTOM_HOUSE = "";
            SVB_LOADING_ON = "";
            SVB_ASSESABLE_RATE = "";
            SVB_DUTY_RATE = "";
            SVB_ASSESABLE_STATUS = "";
            SVB_DUTY_STATUS = "";

            INDIVITUAL_EDU_CESS_AMT = "";
            INDIVITUAL_SEC_HIGHER_CESS_AMT = "";
            INDIVITUAL_LANDING_CHARGE = "";
            CHECKLIST_BCD_RATE = "";
            CHECKLIST_CVD_RATE = "";
            CHECKLIST_ADDL_DUTY_RATE = "";
            INDEV_RACK_TYPE = "";
            MERIT_DUTY_VALUE = "";

            RSP_APPLICABLE = "N";

            CENTRAL_EXCISE_FLAG = Item_Data.Rows[i][64].ToString();
            MANUFACTURER_PRODUCER = "";
            M_P_GROWER_CODE = "";
            M_P_GROWER_ADD1 = Item_Data.Rows[i][65].ToString();
            M_P_GROWER_ADD2 = Item_Data.Rows[i][66].ToString();
            M_P_GROWER_CITY = Item_Data.Rows[i][67].ToString();
            M_P_GROWER_COUNTRY_SUBDIV = Item_Data.Rows[i][68].ToString();
            M_P_GROWER_PIN = Item_Data.Rows[i][69].ToString();
            M_P_GROWER_COUNTRY = Item_Data.Rows[i][70].ToString();
            SOURCE_COUNTRY = Item_Data.Rows[i][71].ToString();
            TRANSIT_COUNTRY = Item_Data.Rows[i][72].ToString();
            ACCESSORY_STATUS = Item_Data.Rows[i][73].ToString();

            INFRA_CESS_NOTN = "";
            INFRA_CESS_NOTN_SL = "";
            INFRA_CESS_NOTN_RATE = "";
            MERIT_BASIC_VALUE = "";
            MERIT_CVD_VALUE = "";
            MERIT_CEC_VALUE = "";
            MERIT_CHEC_VALUE = "";
            MERIT_ADD_DUTY_VALUE = "";
            MERIT_NOTN_BASIC_VALUE = "";
            MERIT_NOTN_CVD_VALUE = "";
            MERIT_NOTN_CEC_VALUE = "";
            MERIT_NOTN_CHEC_VALUE = "";
            MERIT_NOTN_ADD_DUTY_VALUE = "";
            MERIT_NOTN_CESS_VALUE = "";
            MERIT_NOTN_NCD_VALUE = "";
            INDIVITUAL_HSS_AMOUNT = "";

            IGST_LEVY_NOTN = Item_Data.Rows[i][74].ToString();
            IGST_LEVY_SLNO = Item_Data.Rows[i][75].ToString();
            IGST_LEVY_RATE = "";
            IGST_LEVY_SPL = "";
            IGST_LEVY_UNIT = "";
            IGST_LEVY_SPL_TYPE = "";
            IGST_LEVY_EXCEPTION_NOTN = Item_Data.Rows[i][76].ToString();
            IGST_LEVY_EXCEPTION_SLNO = Item_Data.Rows[i][77].ToString();
            IGST_LEVY_EXCEPTION_RATE = "";
            IGST_LEVY_COMPENSATION_CESS_NOTN = Item_Data.Rows[i][79].ToString();
            IGST_LEVY_COMPENSATION_CESS_SLNO = Item_Data.Rows[i][80].ToString();
            IGST_LEVY_COMPENSATION_CESS_RATE = "";
            IGST_LEVY_COMPENSATION_CESS_SPL = "";
            IGST_LEVY_COMPENSATION_CESS_UNIT = "";
            IGST_LEVY_COMPENSATION_CESS_SPL_TYPE = "";
            IGST_LEVY_EXCEPTION_CC_NOTN = Item_Data.Rows[i][81].ToString();
            IGST_LEVY_EXCEPTION_CC_SLNO = Item_Data.Rows[i][82].ToString();
            IGST_LEVY_EXCEPTION_CC_RATE = "";
            if (Item_Data.Rows[i][78].ToString() != "")
            {
                LEVY_EXCEMPTION_NOTN_TYPE = Item_Data.Rows[i][78].ToString().Substring(0, 1) == string.Empty ? "" : Item_Data.Rows[i][78].ToString().Substring(0, 1);
            }
            if (Item_Data.Rows[i][83].ToString() != "")
            {
                LEVY_EXCEPTION_CC_NOTN_TYPE = Item_Data.Rows[i][83].ToString() == string.Empty ? "" : Item_Data.Rows[i][83].ToString().Substring(0, 1);
            }
            CHECKLIST_IGST_LEVY_AMOUNT = "";
            CHECKLIST_COMPENSATION_CC_AMOUNT = "";

            MAX_ID = Get_general_MAXID("ITEM_MAX_ID");

            dt_ITEM.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, INVOICE_NO, ITEM_SLNO, ITEM_DESCRIPTION, ITEM_QTY, ITEM_QTY_CODE, ITEM_UNIT_PRICE, ITEM_UNIT_CODE, ITEM_TOTAL_AMOUNT,
                                ITEM_AMOUNT_CODE, CTH_NO, SCHEME_CODE, SCHEME_NOTN, SCHEME_NOTN_SLNO, CTH_QTY1, CTH_QTY1_CODE, CTH_QTY2, CTH_QTY2_CODE, GENEARL_DESCRIPTION, MANUFACTURER,
                                BRAND, MODEL, END_USE_OF_ITEM, COUNTRY_OF_ORIGIN, ACCESSORIES, PREVIOUS_BE_NO, PREVIOUS_BE_DATE, UNIT_PRICE, UNIT_CODE, CUSTOMS_HOUSE, PRODUCT_RITC, PRODUCT_CTH,
                                PRODUCT_BCD_NOTN, PRODUCT_BCD_SLNO, PRODUCT_BCD_RATE, PRODUCT_BCD_SPL, PRODUCT_BCD_UNIT, PRODUCT_BCD_SPL_TYPE, PRODUCT_ADDL_DUTY_NOTN, PRODUCT_ADDL_DUTY_NOTN_SL,
                                PRODUCT_ADDL_DUTY_RATE, PRODUCT_EDU_CESS_NOTN, PRODUCT_EDU_CESS_NOTN_SL, PRODUCT_EDU_CESS_RATE, PRODUCT_SEC_EDU_CESS_NOTN, PRODUCT_SEC_EDU_CESS_NOTN_SL,
                                PRODUCT_SEC_EDU_CESS_RATE, PRODUCT_NCD_NOTN, PRODUCT_NCD_SLNO, PRODUCT_NCD_RATE, PRODUCT_NCD_SPL, PRODUCT_NCD_UNIT, PRODUCT_NCD_SPL_TYPE, PRODUCT_AGGREGATE_DUTY_NOTN,
                                PRODUCT_AGGREGATE_DUTY_NOTN_SL, PRODUCT_AGGREGATE_DUTY_NOTN_RATE, PRODUCT_SAFEGUARD_NOTN, PRODUCT_SAFEGUARD_SLNO, PRODUCT_SAFEGUARD_RATE, PRODUCT_SAFEGUARD_SPL,
                                PRODUCT_SAFEGUARD_UNIT, PRODUCT_SAFEGUARD_SPL_TYPE, PRODUCT_SAPTA_NOTN, PRODUCT_SAPTA_SLNO, PRODUCT_SAPTA_RATE, PRODUCT_TARIFF_NOTN, PRODUCT_TARIFF_SLNO,
                                PRODUCT_TARIFF_QTY, PRODUCT_TARIFF_AMOUNT, PRODUCT_TARIFF_AMOUNT_UNIT, PRODUCT_CETH, PRODUCT_MRP_YN, PRODUCT_MRP_SL_NO, PRODUCT_MRP_AMOUNT, PRODUCT_MRP_ABT_RATE,
                                PRODUCT_CVD_NOTN, PRODUCT_CVD_SLNO, PRODUCT_CVD_RATE, PRODUCT_CVD_SPL, PRODUCT_CVD_UNIT, PRODUCT_CVD_SPL_TYPE, PRODUCT_CVD_EDU_CESS_RATE, PRODUCT_CVD_SEC_EDU_CESS_RATE,
                                PRODUCT_ADDL5_SIA_NOTN, PRODUCT_ADDL5_SIA_NOTN_SL, PRODUCT_ADDL5_SIA_RATE, PRODUCT_ADDL_GSI_NOTN, PRODUCT_ADDL_GSI_SLNO, PRODUCT_ADDL_GSI_RATE, PRODUCT_ADDL_GSI_SPL,
                                PRODUCT_ADDL_GSI_UNIT, PRODUCT_ADDL_GSI_SPL_TYPE, PRODUCT_ADDL_SHEII_NOTN, PRODUCT_ADDL_SHEII_SLNO, PRODUCT_ADDL_SHEII_RATE, PRODUCT_ADDL_SHEII_SPL, PRODUCT_ADDL_SHEII_UNIT,
                                PRODUCT_ADDL_SHEII_TYPE, PRODUCT_ADDL_TTA_NOTN, PRODUCT_ADDL_TTA_SLNO, PRODUCT_ADDL_TTA_RATE, PRODUCT_ADDL_TTA_SPL, PRODUCT_ADDL_TTA_UNIT, PRODUCT_ADDL_TTA_TYPE,
                                PRODUCT_ADDL_HEALTH_CESS_NOTN, PRODUCT_ADDL_HEALTH_CESS_SLNO, PRODUCT_ADDL_HEALTH_CESS_RATE, PRODUCT_ADDL_HEALTH_CESS_SPL, PRODUCT_ADDL_HEALTH_CESS_UNIT,
                                PRODUCT_ADDL_HEALTH_CESS_TYPE, PRODUCT_CESS_NOTN, PRODUCT_CESS_SLNO, PRODUCT_CESS_RATE, PRODUCT_CESS_SPL, PRODUCT_CESS_UNIT, PRODUCT_CESS_TYPE, ANTI_DUMPING_NOTN,
                                ANTI_DUMPING_NOTN_SLNO, CTH_SLNO, CTH_SUPPLIER_SLNO, CTH_QTY, RSP_DUTY_STATUS, RSP_SL_NO, RSP_DESC, RSP_QTY, RSP_AMOUNT, RSP_NOTN_NO, RSP_NOTN_SL_NO, RSP_ABT_RATE,
                                WAREHOUSE_JOBNO, WAREHOUSE_INVOICE_SLNO, WAREHOUSE_ITEM_SLNO, ASSESSABLE_VALUE, DUTY_VALUE, CIF_VALUE, CVD_VALUE, currentuser, LoginDate, "N", currentbranch, "", Working_Period,
                                BASIC_VALUE, CEC_VALUE, CHEC_VALUE, ADD_DUTY_VALUE, CETH_CVD_EDU_CESS_SL, CETH_CVD_EDU_CESS_RATE, CETH_CVD_SEC_EDU_CESS_SL, CETH_CVD_SEC_EDU_CESS_RATE, PRODUCT_OTHER_DUTY_NOTN,
                                PRODUCT_OTHER_DUTY_SLNO, PRODUCT_OTHER_DUTY_RATE, PRODUCT_OTHER_DUTY_SPL, PRODUCT_OTHER_DUTY_UNIT, PRODUCT_OTHER_DUTY_TYPE, currentuser, LoginDate,
                                INDIVITUAL_FREIGHT_AMOUNT, INDIVITUAL_INSURANCE_AMOUNT, INDIVITUAL_MISC_AMOUNT, SVB_RELATION, SVB_REF_NO, SVB_REF_DATE, SVB_CUSTOM_HOUSE, SVB_LOADING_ON,
                                SVB_ASSESABLE_RATE, SVB_DUTY_RATE, SVB_ASSESABLE_STATUS, SVB_DUTY_STATUS, INDIVITUAL_EDU_CESS_AMT, INDIVITUAL_SEC_HIGHER_CESS_AMT, INDIVITUAL_LANDING_CHARGE,
                                CHECKLIST_BCD_RATE, CHECKLIST_CVD_RATE, CHECKLIST_ADDL_DUTY_RATE, INDEV_RACK_TYPE, MERIT_DUTY_VALUE, RSP_APPLICABLE, CENTRAL_EXCISE_FLAG, MANUFACTURER_PRODUCER,
                                M_P_GROWER_CODE, M_P_GROWER_ADD1, M_P_GROWER_ADD2, M_P_GROWER_CITY, M_P_GROWER_COUNTRY_SUBDIV, M_P_GROWER_PIN, M_P_GROWER_COUNTRY, SOURCE_COUNTRY, TRANSIT_COUNTRY,
                                ACCESSORY_STATUS, INFRA_CESS_NOTN, INFRA_CESS_NOTN_SL, INFRA_CESS_NOTN_RATE, MERIT_BASIC_VALUE, MERIT_CVD_VALUE, MERIT_CEC_VALUE, MERIT_CHEC_VALUE, MERIT_ADD_DUTY_VALUE,
                                MERIT_NOTN_BASIC_VALUE, MERIT_NOTN_CVD_VALUE, MERIT_NOTN_CEC_VALUE, MERIT_NOTN_CHEC_VALUE, MERIT_NOTN_ADD_DUTY_VALUE, MERIT_NOTN_CESS_VALUE, MERIT_NOTN_NCD_VALUE,
                                INDIVITUAL_HSS_AMOUNT, IGST_LEVY_NOTN, IGST_LEVY_SLNO, IGST_LEVY_RATE, IGST_LEVY_SPL, IGST_LEVY_UNIT, IGST_LEVY_SPL_TYPE, IGST_LEVY_EXCEPTION_NOTN, IGST_LEVY_EXCEPTION_SLNO,
                                IGST_LEVY_EXCEPTION_RATE, IGST_LEVY_COMPENSATION_CESS_NOTN, IGST_LEVY_COMPENSATION_CESS_SLNO, IGST_LEVY_COMPENSATION_CESS_RATE, IGST_LEVY_COMPENSATION_CESS_SPL,
                                IGST_LEVY_COMPENSATION_CESS_UNIT, IGST_LEVY_COMPENSATION_CESS_SPL_TYPE, IGST_LEVY_EXCEPTION_CC_NOTN, IGST_LEVY_EXCEPTION_CC_SLNO, IGST_LEVY_EXCEPTION_CC_RATE,
                                LEVY_EXCEMPTION_NOTN_TYPE, LEVY_EXCEPTION_CC_NOTN_TYPE, CHECKLIST_IGST_LEVY_AMOUNT, CHECKLIST_COMPENSATION_CC_AMOUNT);

        }

        ds_ITEM = dt_ITEM;
        ViewState["dt_ITEM"] = ds_ITEM;
        return ds_ITEM;
    }

    public DataTable Bind_BOND_DETAILS(DataTable Bond_Data)
    {
        #region dt_BOND
        dt_BOND.Columns.Add("BONDID");
        dt_BOND.Columns.Add("JOBNO");
        dt_BOND.Columns.Add("BOND_NO");
        dt_BOND.Columns.Add("BOND_TYPE");
        dt_BOND.Columns.Add("BOND_LOCATION");
        dt_BOND.Columns.Add("USER_ID");
        dt_BOND.Columns.Add("DATE_TIME");
        dt_BOND.Columns.Add("STATUS");
        dt_BOND.Columns.Add("BRANCH_CODE");
        dt_BOND.Columns.Add("YEAR");
        dt_BOND.Columns.Add("WORKING_PERIOD");
        dt_BOND.Columns.Add("MODIFIEDBY");
        dt_BOND.Columns.Add("MODIFIEDON");

        #endregion dt_BOND

         //******************** Remove Empty Rows from Datatable  ********************************

        Bond_Data = Bond_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //****************************************************************************************

        for (int i = 0; i <= Bond_Data.Rows.Count - 1; i++)
        {
            BONDID = Convert.ToString(i);

            JOBNO = IMPORT_JOBNO;
            BOND_NO = Bond_Data.Rows[i][0].ToString();
            BOND_TYPE = Bond_Data.Rows[i][1].ToString();
            BOND_LOCATION = Bond_Data.Rows[i][2].ToString();

            MAX_ID = Get_general_MAXID("BOND_MAX_ID");

            dt_BOND.Rows.Add(MAX_ID + i, IMPORT_JOBNO, BOND_NO, BOND_TYPE, BOND_LOCATION,  currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);
        }
        ds_BOND = dt_BOND;
        ViewState["dt_BOND"] = dt_BOND;
        return dt_BOND;
    }

    public DataTable Bind_CERTIFICATE_DETAILS(DataTable CERT_Data)
    {
        #region dt_CERT
        dt_CERT.Columns.Add("CERTIFICATEID");
        dt_CERT.Columns.Add("JOBNO");
        dt_CERT.Columns.Add("CERTIFICATE_NO");
        dt_CERT.Columns.Add("CERTIFICATE_DATE");
        dt_CERT.Columns.Add("CERTIFICATE_TYPE");
        dt_CERT.Columns.Add("USER_ID");
        dt_CERT.Columns.Add("DATE_TIME");
        dt_CERT.Columns.Add("STATUS");
        dt_CERT.Columns.Add("BRANCH_CODE");
        dt_CERT.Columns.Add("YEAR");
        dt_CERT.Columns.Add("WORKING_PERIOD");
        dt_CERT.Columns.Add("MODIFIEDBY");
        dt_CERT.Columns.Add("MODIFIEDON");

        #endregion dt_CERT

        //******************** Remove Empty Rows from Datatable  ********************************

        CERT_Data = CERT_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //****************************************************************************************

        for (int i = 0; i <= CERT_Data.Rows.Count - 1; i++)
        {
            CERTIFICATEID = Convert.ToString(i);

            JOBNO = IMPORT_JOBNO;
            CERTIFICATE_NO = CERT_Data.Rows[i][0].ToString();
            CERTIFICATE_DATE = CERT_Data.Rows[i][1].ToString();
            CERTIFICATE_TYPE = CERT_Data.Rows[i][2].ToString();
           
            MAX_ID = Get_general_MAXID("CERTIFICATE_MAX_ID");
            Get_IGM_NO_DATE(IGM_SLNO);

            IGM_DATE = IGM_DATE == string.Empty ? "01/01/1900" : IGM_DATE;

            dt_CERT.Rows.Add(MAX_ID + i, IMPORT_JOBNO, CERTIFICATE_NO, CERTIFICATE_DATE, CERTIFICATE_TYPE,currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);
        }
        ds_CERT = dt_CERT;
        ViewState["dt_CERT"] = ds_CERT;

        return dt_CERT;
    }

    public DataTable Bind_LICENSE_DETAILS(DataTable LIC_Data)
    {
        #region dt_LICNESE
        dt_LICNESE.Columns.Add("LICENSE_ID");
        dt_LICNESE.Columns.Add("JOBNO");
        dt_LICNESE.Columns.Add("INVOICE_SLNO");
        dt_LICNESE.Columns.Add("ITEM_SLNO");
        dt_LICNESE.Columns.Add("SCHEME_CODE");
        dt_LICNESE.Columns.Add("LICENSE_SLNO");
        dt_LICNESE.Columns.Add("REGISTRATION_NO");
        dt_LICNESE.Columns.Add("REGISTRATION_DATE");
        dt_LICNESE.Columns.Add("EXCEMPTION");
        dt_LICNESE.Columns.Add("DEBIT_AMT");
        dt_LICNESE.Columns.Add("DEBIT_QTY");
        dt_LICNESE.Columns.Add("UNIT_QTY");
        dt_LICNESE.Columns.Add("LICENSE_ITEM_NO");
        dt_LICNESE.Columns.Add("PORT_OF_LICENSE");
        dt_LICNESE.Columns.Add("USER_ID");
        dt_LICNESE.Columns.Add("DATE_TIME");
        dt_LICNESE.Columns.Add("STATUS");
        dt_LICNESE.Columns.Add("BRANCH_CODE");
        dt_LICNESE.Columns.Add("YEAR");
        dt_LICNESE.Columns.Add("WORKING_PERIOD");
        dt_LICNESE.Columns.Add("DEBIT_DUTY");
        dt_LICNESE.Columns.Add("LICENSE_NO");
        dt_LICNESE.Columns.Add("LICENSE_DATE");
        dt_LICNESE.Columns.Add("MODIFIEDBY");
        dt_LICNESE.Columns.Add("MODIFIEDON");
        dt_LICNESE.Columns.Add("TOTAL_CIF_VALUE");
        dt_LICNESE.Columns.Add("TOTAL_DEBIT_DUTY");
        dt_LICNESE.Columns.Add("ENTRY_DEBIT_DUTY");
        dt_LICNESE.Columns.Add("LIC_DESC");

        #endregion dt_LICNESE

        //******************** Remove Empty Rows from Datatable  ********************************

        LIC_Data = LIC_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //****************************************************************************************

        for (int i = 0; i <= LIC_Data.Rows.Count - 1; i++)
        {
            LICENSE_ID = Convert.ToString(i);

            JOBNO = IMPORT_JOBNO;
            INVOICE_SLNO = LIC_Data.Rows[i][0].ToString();
            ITEM_SLNO = LIC_Data.Rows[i][1].ToString();
            SCHEME_CODE = LIC_Data.Rows[i][2].ToString();
            LICENSE_SLNO = LIC_Data.Rows[i][0].ToString();
            REGISTRATION_NO = LIC_Data.Rows[i][3].ToString();
            REGISTRATION_DATE = LIC_Data.Rows[i][4].ToString();
            EXCEMPTION = LIC_Data.Rows[i][2].ToString();
            DEBIT_AMT = LIC_Data.Rows[i][9].ToString();
            DEBIT_QTY = LIC_Data.Rows[i][5].ToString();
            UNIT_QTY = LIC_Data.Rows[i][6].ToString();
            LICENSE_ITEM_NO = LIC_Data.Rows[i][7].ToString();
            PORT_OF_LICENSE = LIC_Data.Rows[i][8].ToString();
            DEBIT_DUTY = LIC_Data.Rows[i][10].ToString();
            LICENSE_NO = LIC_Data.Rows[i][11].ToString();
            LICENSE_DATE = LIC_Data.Rows[i][12].ToString() == string.Empty ? "01/01/1900" : LIC_Data.Rows[i][12].ToString();
            TOTAL_CIF_VALUE = "";
            TOTAL_DEBIT_DUTY = "";
            ENTRY_DEBIT_DUTY = "";
            LIC_DESC = LIC_Data.Rows[i][13].ToString();

            MAX_ID = Get_general_MAXID("LICENSE_MAX_ID");
           
            dt_LICNESE.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO,ITEM_SLNO,SCHEME_CODE,LICENSE_SLNO,REGISTRATION_NO,REGISTRATION_DATE,EXCEMPTION,DEBIT_AMT,DEBIT_QTY,
                                UNIT_QTY, LICENSE_ITEM_NO, PORT_OF_LICENSE, currentuser, LoginDate, "N", currentbranch, "", Working_Period,DEBIT_DUTY,LICENSE_NO,LICENSE_DATE,
                                currentuser, LoginDate, TOTAL_CIF_VALUE, TOTAL_DEBIT_DUTY, ENTRY_DEBIT_DUTY, LIC_DESC);
        }
        ds_LICENSE = dt_LICNESE;
        ViewState["dt_LICENSE"] = ds_LICENSE;

        return dt_LICNESE;
    }

    public DataTable Bind_SUPPORTING_DOCUMENTS_DETAILS(DataTable SUP_DOC)
    {
        #region dt_SUP_DOC
        dt_SUP_DOC.Columns.Add("SW_ID");
        dt_SUP_DOC.Columns.Add("JOBNO");
        dt_SUP_DOC.Columns.Add("INVOICE_SLNO");
        dt_SUP_DOC.Columns.Add("ITEM_SLNO");
        dt_SUP_DOC.Columns.Add("DECLARATION_TYPE");
        dt_SUP_DOC.Columns.Add("IMAGE_REF_NUMBER");
        dt_SUP_DOC.Columns.Add("DOC_TYPE_CODE");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_CODE");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_NAME");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_NAME_ADD1");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_NAME_ADD2");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_CITY");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_PIN");
        dt_SUP_DOC.Columns.Add("DOC_REF_NUMBER");
        dt_SUP_DOC.Columns.Add("PLACE_OF_ISSUE");
        dt_SUP_DOC.Columns.Add("DOC_ISSUE_DATE");
        dt_SUP_DOC.Columns.Add("DOC_EXPIRY_DATE");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_CODE");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_NAME");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_ADDRESS1");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_ADDRESS2");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_CITY");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_PIN");
        dt_SUP_DOC.Columns.Add("FILE_TYPE");
        dt_SUP_DOC.Columns.Add("USER_ID");
        dt_SUP_DOC.Columns.Add("DATE_TIME");
        dt_SUP_DOC.Columns.Add("BRANCH_CODE");
        dt_SUP_DOC.Columns.Add("WORKING_PERIOD");
        dt_SUP_DOC.Columns.Add("CREATEDON");
        dt_SUP_DOC.Columns.Add("CREATEDBY");
        dt_SUP_DOC.Columns.Add("MODIFIEDBY");
        dt_SUP_DOC.Columns.Add("MODIFIEDON");
        dt_SUP_DOC.Columns.Add("SELECT_TYPE");


        #endregion dt_SUP_DOC
        //******************** Remove Empty Rows from Datatable  ********************************

        SUP_DOC = SUP_DOC.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //****************************************************************************************

        for (int i = 0; i <= SUP_DOC.Rows.Count - 1; i++)
        {
            SW_ID = Convert.ToString(i);

            JOBNO = IMPORT_JOBNO;
            INVOICE_SLNO = SUP_DOC.Rows[i][0].ToString();
            ITEM_SLNO = SUP_DOC.Rows[i][1].ToString();
            DOC_TYPE = SUP_DOC.Rows[i][2].ToString();
            IMAGE_REF_NUMBER = SUP_DOC.Rows[i][3].ToString();

            if (SUP_DOC.Rows[i][4].ToString().Contains('-'))
            {
                string[] spl = SUP_DOC.Rows[i][4].ToString().Split('-');
                DOC_TYPE_CODE = spl[0];
            }
            else
            {
                DOC_TYPE_CODE = SUP_DOC.Rows[i][4].ToString();
            }

            DOC_ISSUING_PARTY_CODE = SUP_DOC.Rows[i][5].ToString();
            DOC_ISSUING_PARTY_NAME = SUP_DOC.Rows[i][6].ToString();
            DOC_ISSUING_PARTY_NAME_ADD1 = SUP_DOC.Rows[i][7].ToString();
            DOC_ISSUING_PARTY_NAME_ADD2 = SUP_DOC.Rows[i][8].ToString();
            DOC_ISSUING_PARTY_CITY = SUP_DOC.Rows[i][9].ToString();
            DOC_ISSUING_PARTY_PIN = SUP_DOC.Rows[i][10].ToString();
            DOC_REF_NUMBER = SUP_DOC.Rows[i][11].ToString();
            PLACE_OF_ISSUE = SUP_DOC.Rows[i][12].ToString();
            DOC_ISSUE_DATE = SUP_DOC.Rows[i][13].ToString();
            DOC_EXPIRY_DATE = SUP_DOC.Rows[i][14].ToString() == string.Empty ? "01/01/1900" : SUP_DOC.Rows[i][14].ToString();

            BENEFICIARY_PARTY_CODE = SUP_DOC.Rows[i][15].ToString();
            BENEFICIARY_PARTY_NAME = SUP_DOC.Rows[i][16].ToString();
            BENEFICIARY_PARTY_ADDRESS1 = SUP_DOC.Rows[i][17].ToString();
            BENEFICIARY_PARTY_ADDRESS2 = SUP_DOC.Rows[i][18].ToString();
            BENEFICIARY_PARTY_CITY = SUP_DOC.Rows[i][19].ToString();
            BENEFICIARY_PARTY_PIN = SUP_DOC.Rows[i][20].ToString();

            MAX_ID = Get_general_MAXID("SUPPORTING_DOC_MAX_ID");

            if (DOC_TYPE == "Job Level")
            {
                DOC_TYPE = "JOB";
            }
            else if (DOC_TYPE == "Invoice Level")
            {
                DOC_TYPE = "INVOICE";
            }
            else
            {
                DOC_TYPE = "ITEM";
            }

            dt_SUP_DOC.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, "E", IMAGE_REF_NUMBER, DOC_TYPE_CODE, DOC_ISSUING_PARTY_CODE, DOC_ISSUING_PARTY_NAME, DOC_ISSUING_PARTY_NAME_ADD1,
                                DOC_ISSUING_PARTY_NAME_ADD2, DOC_ISSUING_PARTY_CITY, DOC_ISSUING_PARTY_PIN, DOC_REF_NUMBER, PLACE_OF_ISSUE, DOC_ISSUE_DATE, DOC_EXPIRY_DATE, BENEFICIARY_PARTY_CODE,
                                BENEFICIARY_PARTY_NAME, BENEFICIARY_PARTY_ADDRESS1, BENEFICIARY_PARTY_ADDRESS2, BENEFICIARY_PARTY_CITY, BENEFICIARY_PARTY_PIN, "PDF", currentuser, LoginDate,
                                currentbranch, Working_Period, LoginDate, currentuser, currentuser, LoginDate, DOC_TYPE);
               
        }
        ds_SUP_DOC = dt_SUP_DOC;
        ViewState["dt_SUP_DOC"] = ds_SUP_DOC;

        return dt_SUP_DOC;
    }

    public DataSet Get_Importer_HSS_Details(string IEC_No, string BranchSlNo)
    {     
        objUBO.IEC_NO = IEC_No;
        objUBO.BRANCH_NO = BranchSlNo;
        objUBO.Ename = "Select_IEC_details";
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        ds_IEC = xl.Bind_Import_General_IEC_No(objUBO);

        return ds_IEC;
    }

    public DataSet Get_Importer_Supplier_Details(string SupplierName)
    {
        objUBO.IEC_NO = SupplierName;
        objUBO.BRANCH_NO = "";
        objUBO.Ename = "Check_Avail_SUPPLIER_details";
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        ds_supplier = xl.Bind_Export_General_IEC_No(objUBO);

        return ds_supplier;
    }

    public int Get_general_MAXID(string Flag)
    {      
        objUBO.IEC_NO = "";
        objUBO.BRANCH_NO = "";
        objUBO.Ename = Flag;
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        ds_IEC = xl.Bind_Import_General_IEC_No(objUBO);
        if (ds_IEC.Tables[0].Rows.Count > 0)
        {
            MAX_ID = Convert.ToInt32(ds_IEC.Tables[0].Rows[0]["MAXID"].ToString());
        }

        return MAX_ID;
    }

    public int Check_Avail_IEC_Master(string IEC_No, string BranchSlNo)
    {
        objUBO.IEC_NO = IEC_No;
        objUBO.BRANCH_NO = BranchSlNo;
        objUBO.Ename = "Check_Avail_IEC_details";
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        ds_IEC = xl.Bind_Export_General_IEC_No(objUBO);
        int xx = xl.result;

        return xx;
    }

    public void Get_IGM_NO_DATE(string IGM_SLNO)
    {
        objUBO.IEC_NO = IMPORT_JOBNO;
        objUBO.BRANCH_NO = IGM_SLNO;
        objUBO.Ename = "Get_IGMNO_DATE";
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        ds_IEC = xl.Bind_Import_General_IEC_No(objUBO);

        if (ds_IEC.Tables[0].Rows.Count > 0)
        {
            IGM_NO = ds_IEC.Tables[0].Rows[0]["IGM_NO"].ToString();
            IGM_DATE = ds_IEC.Tables[0].Rows[0]["IGM_DATE"].ToString();
        }
    }

    static string[] GetExcelSheetNames(string connectionString)
    {
        OleDbConnection con = null;
        DataTable dt = null;
        con = new OleDbConnection(connectionString);
        con.Open();

        /* its for all excel sheets names will be shown
        //dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //if (dt == null)
        //{
        //    return null;
        //}

        //String[] excelSheetNames = new String[dt.Rows.Count];
        //int i = 0;

        //foreach (DataRow row in dt.Rows)
        //{
        //    excelSheetNames[i] = row["TABLE_NAME"].ToString();
        //    i++;
        //}
        */

        DataTable dt_sheetNames = new DataTable();
        dt_sheetNames.Columns.Add("SHEETNAMES");
        dt_sheetNames.Rows.Add("GENERAL");
        dt_sheetNames.Rows.Add("IGM");
        dt_sheetNames.Rows.Add("CONTAINER");
        dt_sheetNames.Rows.Add("INVOICE");
        dt_sheetNames.Rows.Add("ITEM");
        //dt_sheetNames.Rows.Add("INVOICE_ITEM");
        dt_sheetNames.Rows.Add("Re_Import");
        dt_sheetNames.Rows.Add("Bulk_SINGLE_WINDOW");
        dt_sheetNames.Rows.Add("BULK_LICENSE");
        dt_sheetNames.Rows.Add("Bond");
        dt_sheetNames.Rows.Add("Certificate");
        dt_sheetNames.Rows.Add("Supporting_DOC");

        
        String[] excelSheetNames = new String[dt_sheetNames.Rows.Count];
        int ki = 0;

        foreach (DataRow row in dt_sheetNames.Rows)
        {
            excelSheetNames[ki] = row["SHEETNAMES"].ToString();
            ki++;
        }

        return excelSheetNames;
    }

    public DataTable Filter_EmptyRows(DataTable dtn,int col)
    {
        int xxx = 0;
        int ij = 0;
       
      DataTable  dttableNew  = dtn.Clone();
     
      foreach (DataRow drtableOld in dtn.Rows)
      {
          if (dtn.Rows[0][col].ToString() != "")
          {
              dttableNew.ImportRow(drtableOld);
              ij = ij + 1;
          }
      }

      xxx = dttableNew.Rows.Count;
      return dttableNew;
    }

    public void Get_ExcelFile()
    {
        DataSet ds = new DataSet();

        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadExcel.FileName;

        string strGID;
        string picExtension;
        string fileName2 = "";

        if (fileuploadExcel.HasFile)
        {
            picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
            fileName2 = fileuploadExcel.FileName;
            ViewState["fileName2"] = fileName2;
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

        foreach (var sheetName in GetExcelSheetNames(connString))
        {
            using (OleDbConnection con = new OleDbConnection(connString))
            {
                var dataTable = new DataTable();
                string query = string.Format("SELECT * FROM [{0}]", sheetName + "$");
                if (con.State == ConnectionState.Closed)
                    con.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                adapter.Fill(dataTable);
                data.Tables.Add(dataTable);
                //adapter.Dispose();
                //con.Close();
                //con.Dispose();
            }
        }
        DataSet ds_maingrid = new DataSet();
        int xxx = 0;
        DataTable dt_final = new DataTable();

        //************************* GENERAL DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[0],0);
        xxx = dt_final.Rows.Count;

        if (xxx > 0)
        {
            if (data.Tables[0].Rows.Count > 0)
            {
                Bind_General_Details(dt_final);
                ds_maingrid = (DataSet)ViewState["ds_GENERAL"];
            }
        }
        else
        {
            ViewState["ds_GENERAL"] = dt_gen;
        }

        //************************* IGM DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[1],6);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            if (data.Tables[1].Rows.Count > 0)
            {
                Bind_IGM_Details(dt_final);
            }
        }
        else
        {
            ViewState["ds_IGM"] = dt_IGM;
        }

        //************************* CONTAINER DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[2],1);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            if (data.Tables[2].Rows.Count > 0)
            {
                Bind_CONTAINER_Details(dt_final);
            }
        }
        else
        {
            ViewState["ds_CONTAINER"] = dt_CONT;
        }

        //************************* INVOICE DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[3], 0);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            if (data.Tables[3].Rows.Count > 0)
            {
                Bind_INVOICE_Details(dt_final);
            }
        }
        else
        {
            ViewState["dt_INV"] = dt_INV;
        }

        //************************* INVOICE DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[4], 0);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            if (data.Tables[4].Rows.Count > 0)
            {
                Bind_ITEM_Details(dt_final);
            }
        }
        else
        {
            ViewState["dt_ITEM"] = dt_ITEM;
        }

        //************************* Re-IMPORT DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[5], 0);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            if (data.Tables[5].Rows.Count > 0)
            {
                Bind_REIMPORT_Details(dt_final, data.Tables[3]);
            }
        }
        else
        {
            ViewState["dt_REIMP"] = dt_REIMP;
        }

        //************************* SINGLE WINDOW DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[6], 0);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            if (data.Tables[6].Rows.Count > 0)
            {
                Bind_SINGLE_WINDOW_Details(dt_final);
            }
        }
        else
        {
            ViewState["dt_SW_INFO"] = dt_SW_INFO;
            ViewState["dt_SW_CTRL"] = dt_SW_CTRL;
            ViewState["dt_SW_STMT"] = dt_SW_STMT;

        }

        //************************* LICENSE DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[7], 0);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            if (data.Tables[7].Rows.Count > 0)
            {
                Bind_LICENSE_DETAILS(dt_final);
            }
        }
        else
        {
            ViewState["dt_LICENSE"] = dt_LICNESE;
        }

        //************************* BOND DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[8], 0);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            if (data.Tables[8].Rows.Count > 0)
            {
                Bind_BOND_DETAILS(dt_final);
            }
        }
        else
        {
            ViewState["dt_BOND"] = dt_BOND;
        }

        //************************* CERTIFICATE DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[9], 0);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            if (data.Tables[9].Rows.Count > 0)
            {
                Bind_CERTIFICATE_DETAILS(dt_final);
            }
        }
        else
        {
            ViewState["dt_CERT"] = dt_CERT;
        }
        //************************* SUPPORTING DOCUMENTS DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[10], 0);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            if (data.Tables[10].Rows.Count > 0)
            {
                Bind_SUPPORTING_DOCUMENTS_DETAILS(dt_final);
            }
        }
        else
        {
            ViewState["dt_SUP_DOC"] = dt_SUP_DOC;
        }
       

        //if (data.Tables[0].Rows.Count > 0)
        //{
        //    Bind_General_Details(data.Tables[0]);
        //    ds_maingrid = (DataSet)ViewState["ds_GENERAL"];
        //    //admin.SqlBulk_Upload_Product("GENERAL_DETAILS", ds_GENERAL.Tables[0], comp_ConnectionStr);
        //}
        //if (data.Tables[1].Rows.Count > 0)
        //{
        //    Bind_IGM_Details(data.Tables[1]);
        //    //admin.SqlBulk_Upload_Product("IGM_DETAILS", ds_IGM.Tables[0], comp_ConnectionStr);
        //}
        //if (data.Tables[2].Rows.Count > 0)
        //{
        //    Bind_CONTAINER_Details(data.Tables[2]);
        //    //admin.SqlBulk_Upload_Product("CONTAINER_DETAILS", ds_CONTAINER.Tables[0], comp_ConnectionStr);
        //}

        DataTable dt_main = new DataTable();
        DataRow dr1;
        dt_main.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
        dt_main.Columns.Add(new System.Data.DataColumn("FILE_REF_NO", typeof(String)));
        dt_main.Columns.Add(new System.Data.DataColumn("TRANSPORT_MODE", typeof(String)));
        dt_main.Columns.Add(new System.Data.DataColumn("IMPORTER_NAME", typeof(String)));
        dt_main.Columns.Add(new System.Data.DataColumn("COUNTRY_ORIGIN", typeof(String)));
        dt_main.Columns.Add(new System.Data.DataColumn("PORT_ORIGIN", typeof(String)));
        dt_main.Columns.Add(new System.Data.DataColumn("COUNTRY_SHIPMENT", typeof(String)));
        dt_main.Columns.Add(new System.Data.DataColumn("PORT_SHIPMENT", typeof(String)));

        dr1 = dt_main.NewRow();

        dr1[0] = IMPORT_JOBNO;
        dr1[1] = ds_maingrid.Tables[0].Rows[0][63].ToString();
        dr1[2] = ds_maingrid.Tables[0].Rows[0][3].ToString();
        dr1[3] = ds_maingrid.Tables[0].Rows[0][7].ToString();
        dr1[4] = ds_maingrid.Tables[0].Rows[0][15].ToString();
        dr1[5] = ds_maingrid.Tables[0].Rows[0][16].ToString();
        dr1[6] = ds_maingrid.Tables[0].Rows[0][18].ToString();
        dr1[7] = ds_maingrid.Tables[0].Rows[0][17].ToString();

        dt_main.Rows.Add(dr1);

        DataSet dsData1 = new DataSet();
        DataSet ds_grid1 = new DataSet();
        dsData1.Tables.Add(dt_main);

        if (dsData1.Tables[0].Rows.Count > 0)
        {
            gv_Gen_Details.DataSource = dsData1.Tables[0];
            gv_Gen_Details.DataBind();
        }

        //*************************  DETAILS ***********************************
        dt_final = Filter_EmptyRows(data.Tables[4],0);
        xxx = dt_final.Rows.Count;
        if (xxx > 0)
        {
            ViewState["NoRecords"] = "";
            if (dt_final.Rows.Count > 0)
            {

                DataTable dtt = new DataTable();

                dtt = dt_final;
                dtt.Rows.Add();
                DataTable Customs_Table = new DataTable();
                Customs_Table.Columns.Add("NOTN_No");
                Customs_Table.Columns.Add("NOTN_SLNo");
                Customs_Table.Columns.Add("NOTN_Type");

                //*******************************DISTICT SAPTA NOTIFICATION FROM DATATABLE **************
                DataTable distinct_SAPTA = dtt.DefaultView.ToTable(true, "SAPTA Notn", "SAPTA NotnSlno");
                int h = 0;
                if (distinct_SAPTA.Rows.Count > 1)
                {
                    for (int j = 0; j <= distinct_SAPTA.Rows.Count - 1; j++)
                    {
                        if (distinct_SAPTA.Rows[h]["SAPTA Notn"].ToString() != "")
                        {
                            Customs_Table.Rows.Add();
                            Customs_Table.Rows[h]["NOTN_No"] = distinct_SAPTA.Rows[j]["SAPTA Notn"].ToString();
                            Customs_Table.Rows[h]["NOTN_SLNo"] = distinct_SAPTA.Rows[j]["SAPTA NotnSlno"].ToString();
                            Customs_Table.Rows[h]["NOTN_Type"] = "C";
                            h++;
                        }
                    }
                }

                DataTable distinct_AGGR = dtt.DefaultView.ToTable(true, "Aggregate Notn", "Aggregate Slno");
                if (distinct_AGGR.Rows.Count > 1)
                {
                    for (int j = 0; j <= distinct_AGGR.Rows.Count - 1; j++)
                    {
                        if (distinct_AGGR.Rows[j]["Aggregate Notn"].ToString() != "")
                        {
                            Customs_Table.Rows.Add();
                            Customs_Table.Rows[h]["NOTN_No"] = distinct_AGGR.Rows[j]["Aggregate Notn"].ToString();
                            Customs_Table.Rows[h]["NOTN_SLNo"] = distinct_AGGR.Rows[j]["Aggregate Slno"].ToString();
                            Customs_Table.Rows[h]["NOTN_Type"] = "A";

                            h++;
                        }
                    }
                }

                DataTable distinct_SAFEGUARD = dtt.DefaultView.ToTable(true, "Safeguard Notn", "Safeguard Slno");
                if (distinct_SAFEGUARD.Rows.Count > 1)
                {
                    for (int j = 0; j <= distinct_SAFEGUARD.Rows.Count - 1; j++)
                    {
                        if (distinct_SAFEGUARD.Rows[j]["Safeguard Notn"].ToString() != "")
                        {
                            Customs_Table.Rows.Add();
                            Customs_Table.Rows[h]["NOTN_No"] = distinct_SAFEGUARD.Rows[j]["Safeguard Notn"].ToString();
                            Customs_Table.Rows[h]["NOTN_SLNo"] = distinct_SAFEGUARD.Rows[j]["Safeguard Slno"].ToString();
                            Customs_Table.Rows[h]["NOTN_Type"] = "S";

                            h++;
                        }
                    }
                }

                if (Customs_Table.Rows.Count > 0)
                {
                    //if (distinct_SAPTA.Rows[0]["SAPTA_NOTN"].ToString() != "" && distinct_SAPTA.Rows[0]["SAPTA_NOTN_SLNO"].ToString() != "")
                    //{
                    Customs_Table = Customs_Table.Rows.Cast<DataRow>()
                                     .Where(row => !row.ItemArray.All(field => field is System.DBNull))
                                     .CopyToDataTable();

                    Get_SAPTA_Notification_RATE(Customs_Table);
                    //}
                }

                //******************** Remove Empty Rows from Datatable  ********************************

                dtt = dtt.Rows.Cast<DataRow>()
                     .Where(row => !row.ItemArray.All(field => field is System.DBNull))
                     .CopyToDataTable();

                //*********************************************************************************************************

                //****************************** ITEM DESCRIPTION SEARCH FOR FIND SPECIAL CHARACTERS***********************
                if (dtt.Rows.Count > 0)
                {

                    //for (int i = 0; i <= dtt.Rows.Count - 1; i++)
                    //{
                    //    objUBO.ITEM_DESCRIPTION = dtt.Rows[i]["ITEM_DESCRIPTION"].ToString();
                    //    objUBO.Ename = "ITEM_DESC_special_char_Search_TEST";
                    //    ds = Transact.Bind_Import_ExcelUpload_SpecialChars(objUBO);
                    //    int aa = Transact.result;

                    //    if (aa == 1)
                    //    {
                    //        string invslno = dtt.Rows[i]["INVOICE_SLNO"].ToString();
                    //        string itemslno = dtt.Rows[i]["ITEM_SLNO"].ToString();
                    //        alert += "      Invoice :" + invslno + "                    "+"ItemSlNo : " + itemslno + "*";
                    //    }
                    //}

                    alert = "";
                    Get_ITEM_DESC_SEARCH_SPECIAL_CHARACTERS(dtt, "Item Description", "Desc_Alert");
                    if (alert.Length > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Spcl_Chars", "Spcl_Chars('" + alert + "','" + "alert" + "');", true);
                    }
                    ViewState["alert"] = alert;

                    GeneralDesc_Alert = "";
                    Get_ITEM_DESC_SEARCH_SPECIAL_CHARACTERS(dtt, "Generic Description", "GeneralDesc_Alert");
                    if (GeneralDesc_Alert.Length > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Spcl_Chars", "Spcl_Chars('" + GeneralDesc_Alert + "','" + "GeneralDesc_Alert" + "');", true);
                    }
                    ViewState["Genric_alert"] = GeneralDesc_Alert;

                    Mnufactre_alert = "";
                    Get_ITEM_DESC_SEARCH_SPECIAL_CHARACTERS(dtt, "Manufacturer", "Mnufactre_alert");
                    if (Mnufactre_alert.Length > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Spcl_Chars", "Spcl_Chars('" + Mnufactre_alert + "','" + "Mnufactre_alert" + "');", true);
                    }
                    ViewState["Mnufactre_alert"] = Mnufactre_alert;
                }

                DataTable d_dtt = new DataTable();
                d_dtt.Columns.Add("INVOICE_SLNO", typeof(string));
                d_dtt.Columns.Add("ITEM_SLNO", typeof(string));

                string dup_val = "";
                for (int i = 0; i <= dtt.Rows.Count - 1; i++)
                {
                    //var query1 = d_dtt.AsEnumerable().Where(r => r.Field<string>("ITEM_SLNO") == dtt.Rows[i][5]);

                    d_dtt.Rows.Add(dtt.Rows[i][0], dtt.Rows[i][2]);

                    string inv = dtt.Rows[i][0].ToString();
                    string item = dtt.Rows[i][2].ToString();

                    var FullName1 = from DataRow drr in d_dtt.AsEnumerable()
                                    where drr.Field<string>("ITEM_SLNO") == item && drr.Field<string>("INVOICE_SLNO") == inv
                                    select drr;

                    DataView dvv = FullName1.AsDataView();

                    int xx = dvv.Count;

                    if (xx == 2)
                    {
                        string dp = "Invoice :" + dtt.Rows[i][0].ToString() + "    Item No: " + dtt.Rows[i][5].ToString();
                        dup_val += dp + "*";
                    }
                }

                if (dup_val != "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "updateProgress", "updateProgress('" + dup_val + "');", true);
                }
                else
                {
                    DataTable filteredRows = dtt.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();
                    DataSet dss = new DataSet();
                    dss.Tables.Add(filteredRows);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        ViewState["ds_Excel_upload"] = dss;
                    }

                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt_gen = new DataTable();
                        DataRow dr;
                        dt_gen.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
                        dt_gen.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
                        dt_gen.Columns.Add(new System.Data.DataColumn("INVOICE_NO", typeof(String)));
                        dt_gen.Columns.Add(new System.Data.DataColumn("ITEM_AMOUNT", typeof(double)));
                        dt_gen.Columns.Add(new System.Data.DataColumn("INVOICE_CURRENCY", typeof(String)));
                        dt_gen.Columns.Add(new System.Data.DataColumn("EXCHANGE_RATE", typeof(String)));

                        for (int s = 0; s < dss.Tables[0].Rows.Count; s++)
                        {
                            dr = dt_gen.NewRow();
                            dr[0] = IMPORT_JOBNO;
                            dr[1] = dss.Tables[0].Rows[s][0].ToString();
                            dr[2] = dss.Tables[0].Rows[s][1].ToString();

                            if (dss.Tables[0].Rows[s][4] != System.DBNull.Value && dss.Tables[0].Rows[s][6] != System.DBNull.Value)
                            {
                                dr[3] = Convert.ToString(Convert.ToDecimal(dss.Tables[0].Rows[s][4]) * Convert.ToDecimal(dss.Tables[0].Rows[s][6]));
                            }
                            else
                            {
                                dr[3] = 0;
                            }

                            dr[4] = dss.Tables[0].Rows[s][7].ToString();
                            dr[5] = dss.Tables[0].Rows[s][4].ToString();

                            dt_gen.Rows.Add(dr);
                        }

                        DataSet dsData = new DataSet();
                        DataSet ds_grid = new DataSet();
                        dsData.Tables.Add(dt_gen);
                        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

                        //EXU.JOBNO = IMPORT_JOBNO;
                        //EXU.Ename = "Excel_Select";
                        //EXU.Xml_D = xmlData;
                        //ds_grid = EXU.Select_Exp_INV();

                        objUBO.JOBNO = IMPORT_JOBNO;
                        objUBO.Ename = "Excel_Select";
                        objUBO.Xml_D = xmlData;
                        ds_grid = xl.Select_Exp_INV(objUBO);
                        if (ds_grid.Tables[0].Rows.Count > 0)
                        {
                            gv_Item_Details.DataSource = ds_grid.Tables[0];
                            gv_Item_Details.DataBind();
                        }
                        else
                        {
                            DataTable ddt = new DataTable();
                            gv_Item_Details.DataSource = ddt;
                            gv_Item_Details.DataBind();
                        }
                    }
                }
            }
        }
        else
        {
            ViewState["NoRecords"] = "No Records";       
        }
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

    //public void Excel_Upload_load(string file_ext)
    public void Excel_Upload_load()
    {
        if (ViewState["fileName2"] != null)
        {
            if (ViewState["NoRecords"].ToString().Length == 0)
            {
                if (ViewState["alert"].ToString().Length == 0)
                {
                    if (ViewState["Genric_alert"].ToString().Length == 0)
                    {
                        if (ViewState["Mnufactre_alert"].ToString().Length == 0)
                        {
                            #region INVOICE_ITEM hide by Chithra
                            /*

                            DataSet Inv_ds = new DataSet();
                            //ds.Tables.Add("Invoice_dt");
                            Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
                            int a = 0, b = 0, c = 0;

                            //***************************** SUPPLIER DETAILS CALL *************************
                            #region SUPPLIER DETAILS CALL
                            string G_SUPPLIER_ADDRESS, G_SUPPLIER_ADDRESS1, G_SUPPLIER_ADDRESS2, G_SUPPLIER_COUNTRY_NAME, G_SUPPLIER_COUNTRY_CODE, G_SUPPLIER_COUNTRY_PINCODE;
                            DataSet ds_gen = new DataSet();
                            erm.Esupid = "0";
                            //erm.Esup_name = txt_SupplierName_Gen.Text;
                            erm.Esup_name = txt_SupplierName_Gen.Text;
                            erm.Ename = "Get_Sup_Name_GMMCO";
                            erm.EWorking_Period = Working_Period;
                            ds_gen = erm.RetrieveAll_Supplier_MASTER();


                            if (ds_gen.Tables[0].Rows.Count > 0)
                            {
                                G_SUPPLIER_ADDRESS = ds_gen.Tables[0].Rows[0]["SUP_ADD1"].ToString();
                                G_SUPPLIER_ADDRESS1 = ds_gen.Tables[0].Rows[0]["SUP_ADD2"].ToString();
                                G_SUPPLIER_ADDRESS2 = ds_gen.Tables[0].Rows[0]["SUP_ADD3"].ToString();
                                G_SUPPLIER_COUNTRY_NAME = ds_gen.Tables[0].Rows[0]["SUP_COUNTRY_NAME"].ToString();
                                G_SUPPLIER_COUNTRY_CODE = ds_gen.Tables[0].Rows[0]["SUP_COUNTRY_CODE"].ToString();
                                G_SUPPLIER_COUNTRY_PINCODE = ds_gen.Tables[0].Rows[0]["SUP_PIN_CODE"].ToString();
                            }
                            else
                            {
                                G_SUPPLIER_ADDRESS = string.Empty;
                                G_SUPPLIER_ADDRESS1 = string.Empty;
                                G_SUPPLIER_ADDRESS2 = string.Empty;
                                G_SUPPLIER_COUNTRY_NAME = string.Empty;
                                G_SUPPLIER_COUNTRY_CODE = string.Empty;
                                G_SUPPLIER_COUNTRY_PINCODE = string.Empty;
                            }
                            #endregion SUPPLIER DETAILS CALL
                            //*************************************************************************

                            //***************************** SVB RELATION CALL *************************
                            #region SVB RELATION CALL
                            string SVB_RELATION = "", SVB_REF_NO = "", SVB_REF_DATE = "", SVB_CUSTOM_HOUSE = "", SVB_LOADING_ON = "", SVB_ASSESABLE_RATE = "", SVB_DUTY_RATE = "", SVB_ASSESABLE_STATUS = "", SVB_DUTY_STATUS = "";
                            erm.SVB_ID = "0";
                            erm.IMP_NAME = IMPORTER_NAME;
                            erm.SUPPLIER_NAME = txt_SupplierName_Gen.Text;
                            erm.Ename = "Select_SVB_ExcelUpload";
                            erm.EWorking_Period = Session["WorkingPeriod"].ToString();
                            ds_svb = erm.RetrieveAll_SVB_MASTER();

                            if (ds_svb.Tables[0].Rows.Count > 0)
                            {
                                SVB_RELATION = ds_svb.Tables[0].Rows[0]["SVB_RELATION"].ToString();
                                SVB_REF_NO = ds_svb.Tables[0].Rows[0]["SVB_REF_NO"].ToString();
                                SVB_REF_DATE = ds_svb.Tables[0].Rows[0]["SVB_REF_DATE"].ToString();
                                SVB_CUSTOM_HOUSE = ds_svb.Tables[0].Rows[0]["SVB_CUSTOM_HOUSE"].ToString();
                                SVB_LOADING_ON = ds_svb.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString();
                                SVB_ASSESABLE_RATE = ds_svb.Tables[0].Rows[0]["SVB_ASSESABLE_RATE"].ToString();
                                SVB_DUTY_RATE = ds_svb.Tables[0].Rows[0]["SVB_DUTY_RATE"].ToString();
                                SVB_ASSESABLE_STATUS = ds_svb.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString();
                                SVB_DUTY_STATUS = ds_svb.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString();
                            }
                            #endregion SVB RELATION CALL
                            //***************************************************************************

                            #region create dataset column

                            if (ds.Tables[0].Rows.Count > a)
                            {
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
                                dsXML.Tables[1].Columns.Add("RSP_NOTN_NO");    //--------------------------1
                                dsXML.Tables[1].Columns.Add("RSP_NOTN_SL_NO"); //--------------------------2
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
                                dsXML.Tables[1].Columns.Add("RSP_APPLICABLE");

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
                                dsXML.Tables[2].Columns.Add("DEBIT_DUTY");
                                dsXML.Tables[2].Columns.Add("LICENSE_NO");
                                dsXML.Tables[2].Columns.Add("LICENSE_DATE");

                            #endregion Datatable_header

                                file_ext = ".xls";

                                //--------------------End License Details--------------------------//
                                if (file_ext == ".xls" || file_ext == ".xlsx")
                                {
                                    ds.Tables[0].Rows.Add();//----------This Line added on 16Aug2016 by Chithra--------//
                                    #region read Excel_Format
                                    while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                                    {

                                        DataRow dr = dsXML.Tables[0].NewRow();

                                        dr["INVOICE_ID"] = "";
                                        dr["JOBNO"] = IMPORT_JOBNO;
                                        // dr["JOBDATE"] = EXPORT_JOBDATE;
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

                                        dr["SUPPLIER_NAME"] = txt_SupplierName_Gen.Text;
                                        dr["SUPPLIER_ADDRESS"] = G_SUPPLIER_ADDRESS;
                                        dr["SUPPLIER_ADDRESS1"] = G_SUPPLIER_ADDRESS1;
                                        dr["SUPPLIER_ADDRESS2"] = G_SUPPLIER_ADDRESS2;
                                        dr["SUPPLIER_COUNTRY_NAME"] = G_SUPPLIER_COUNTRY_NAME;
                                        dr["SUPPLIER_COUNTRY_CODE"] = G_SUPPLIER_COUNTRY_CODE;
                                        dr["SUPPLIER_COUNTRY_PINCODE"] = G_SUPPLIER_COUNTRY_PINCODE;
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
                                        dr["MIS_AGENCY_RATE"] = "0.00";
                                        dr["MIS_AGENCY_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                                        dr["MIS_AGENCY_EXRATE"] = dr["INVOICE_EXRATE"];
                                        dr["MIS_DISCOUNT_CHARGES"] = "";
                                        dr["MIS_DISCOUNT_RATE"] = "0.00";
                                        dr["MIS_DISCOUNT_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                                        dr["MIS_DISCOUNT_EXRATE"] = dr["INVOICE_EXRATE"];
                                        dr["MIS_DISCOUNT_REASON"] = "";
                                        dr["MIS_LOADING_CHARGES"] = "";
                                        dr["MIS_LOADING_RATE"] = "";

                                        //dr["MIS_LOADING_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                                        //dr["MIS_LOADING_EXRATE"] = dr["INVOICE_EXRATE"];
                                        dr["MIS_LOADING_CURRENCY"] = "";
                                        dr["MIS_LOADING_EXRATE"] = "";


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
                                        dr["MIS_HIGHSEASALE_RATE"] = "0.00";
                                        dr["MIS_HIGHSEASALE_CURRENCY"] = "INR";
                                        dr["MIS_HIGHSEASALE_EXRATE"] = "1.00";
                                        dr["MIS_SINGLE_OR_MULITIPLE"] = "S";

                                        if (SVB_RELATION == "Y")
                                        {
                                            dr["SVB_RELATION"] = "Y";
                                            dr["SVB_REF_NO"] = SVB_REF_NO;

                                            //dr["SVB_REF_DATE"] = DateTime.Parse(SVB_REF_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                            dr["SVB_REF_DATE"] = SVB_REF_DATE;

                                            dr["SVB_CUSTOM_HOUSE"] = SVB_CUSTOM_HOUSE;
                                            dr["SVB_LOADING_ON"] = SVB_LOADING_ON;
                                            dr["SVB_ASSESABLE_RATE"] = SVB_ASSESABLE_RATE;
                                            dr["SVB_DUTY_RATE"] = SVB_DUTY_RATE;
                                            dr["SVB_ASSESABLE_STATUS"] = SVB_ASSESABLE_STATUS;
                                            dr["SVB_DUTY_STATUS"] = SVB_DUTY_STATUS;
                                        }
                                        else
                                        {
                                            //dr["SVB_RELATION"] = "N";
                                            //dr["SVB_REF_NO"] = "";

                                            string SVB_REF_DT = "01/01/1900";
                                            dr["SVB_REF_DATE"] = DateTime.Parse(SVB_REF_DT, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                                            //dr["SVB_CUSTOM_HOUSE"] = "";
                                            //dr["SVB_LOADING_ON"] = "";
                                            //dr["SVB_ASSESABLE_RATE"] = "";
                                            //dr["SVB_DUTY_RATE"] = "";
                                            //dr["SVB_ASSESABLE_STATUS"] = "";
                                            //dr["SVB_DUTY_STATUS"] = "";
                                        }


                                        dr["OTHER_PURCHASE_ORDER"] = "";

                                        string PURCHASE_ORDER_DATE = "01/01/1900";

                                        dr["OTHER_PURCHASE_ORDER_DATE"] = DateTime.Parse(PURCHASE_ORDER_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                                        dr["OTHER_CONTRACT_NO"] = "";

                                        string CONTRACT_DATE = "01/01/1900";

                                        dr["OTHER_CONTRACT_DATE"] = DateTime.Parse(CONTRACT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                                        dr["OTHER_LOC_NO"] = "";
                                        dr["OTHER_NATURE_OF_TRANSACTION"] = "S  Sale";
                                        dr["OTHER_TERMS_OF_PAYMENT"] = "OTH  Others";
                                        dr["OTHER_CONDITIONS"] = "";
                                        dr["OTHER_VALUATION_METHOD"] = "Rule 4 - Transaction Value";

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
                                            DataRow dr1 = dsXML.Tables[1].NewRow();
                                            dr1["ITEM_ID"] = "";
                                            dr1["JOBNO"] = IMPORT_JOBNO;
                                            dr1["INVOICE_SLNO"] = ds.Tables[0].Rows[b][0].ToString();
                                            dr1["INVOICE_NO"] = ds.Tables[0].Rows[b][1].ToString().TrimEnd();
                                            dr1["ITEM_SLNO"] = ds.Tables[0].Rows[b][5].ToString();
                                            
                                            //-------------Start Item Description Double Space Remove-----------//
                                            //Your sample string
                                            string strvalue = ds.Tables[0].Rows[b][9].ToString();

                                            //Split the words based on white sapce
                                            var list = strvalue.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s));

                                            //Join the values back and add a single space in between
                                            strvalue = string.Join(" ", list);

                                            dr1["ITEM_DESCRIPTION"] = strvalue;

                                            //-------------End Item Description Double Space Remove-----------//

                                            string QTY = ds.Tables[0].Rows[b][6].ToString();
                                            string UNITPRICE = ds.Tables[0].Rows[b][8].ToString();

                                            dr1["ITEM_QTY"] = ds.Tables[0].Rows[b][6].ToString();
                                            dr1["ITEM_QTY_CODE"] = ds.Tables[0].Rows[b][7].ToString();
                                            dr1["ITEM_UNIT_PRICE"] = ds.Tables[0].Rows[b][8].ToString();
                                            dr1["ITEM_UNIT_CODE"] = ds.Tables[0].Rows[b][4].ToString();

                                            item_amt = Convert.ToDecimal(ds.Tables[0].Rows[b][6]) * Convert.ToDecimal(ds.Tables[0].Rows[b][8]);

                                            // dr1["ITEM_AMOUNT"] = Convert.ToString(item_amt);
                                            dr1["ITEM_TOTAL_AMOUNT"] = item_amt;
                                            dr1["ITEM_AMOUNT_CODE"] = ds.Tables[0].Rows[b][4].ToString();
                                            dr1["CTH_NO"] = ds.Tables[0].Rows[b][16].ToString();

                                            scheme = ds.Tables[0].Rows[b][31].ToString();

                                            if (scheme.Contains('-'))
                                            {
                                                string[] sp = scheme.Split('-');
                                                scheme = sp[0];
                                            }


                                            if (scheme != "" && scheme != "00" && scheme != "0")
                                            {
                                                //if (Convert.ToInt32(scheme) <= 9)
                                                //{
                                                //    scheme = "0" + scheme;
                                                //}
                                                scheme = Get_Scheme_Code(scheme);
                                                dr1["SCHEME_CODE"] = scheme;
                                                dr1["SCHEME_NOTN"] = ds.Tables[0].Rows[b][32].ToString();
                                                dr1["SCHEME_NOTN_SLNO"] = ds.Tables[0].Rows[b][33].ToString();
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
                                            dr1["GENEARL_DESCRIPTION"] = ds.Tables[0].Rows[b][25].ToString();
                                            dr1["MANUFACTURER"] = ds.Tables[0].Rows[b][26].ToString();
                                            dr1["BRAND"] = ds.Tables[0].Rows[b][27].ToString();
                                            dr1["MODEL"] = ds.Tables[0].Rows[b][28].ToString();
                                            dr1["END_USE_OF_ITEM"] = ds.Tables[0].Rows[b][29].ToString();
                                            dr1["COUNTRY_OF_ORIGIN"] = ds.Tables[0].Rows[b][30].ToString();
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

                                            //****************************** AGGREGATE_DUTY RATE UPDATE *******************************************

                                            dr1["PRODUCT_AGGREGATE_DUTY_NOTN"] = ds.Tables[0].Rows[b][51].ToString();
                                            dr1["PRODUCT_AGGREGATE_DUTY_NOTN_SL"] = ds.Tables[0].Rows[b][52].ToString();
                                            //dr1["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = "";

                                            if (ds.Tables[0].Rows[b][51].ToString() != "" && ds.Tables[0].Rows[b][52].ToString() != "")
                                            {
                                                DataTable x = new DataTable();
                                                DataTable x_Rate = new DataTable();

                                                x = (DataTable)ViewState["get_SAPTA_RATE_ALL"];

                                                var FullName1 = from DataRow drr in x.AsEnumerable()
                                                                where drr.Field<string>("NOTN_No") == ds.Tables[0].Rows[b][51].ToString() && drr.Field<string>("NOTN_SLNo") == ds.Tables[0].Rows[b][52].ToString()
                                                                select drr;
                                                x_Rate = FullName1.CopyToDataTable();
                                                if (x_Rate.Rows.Count > 0)
                                                {
                                                    dr1["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = x_Rate.Rows[0]["RATE"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                dr1["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = "";
                                            }

                                            //****************************** SAFEGUARD RATE UPDATE *******************************************
                                            dr1["PRODUCT_SAFEGUARD_NOTN"] = ds.Tables[0].Rows[b][53].ToString();
                                            dr1["PRODUCT_SAFEGUARD_SLNO"] = ds.Tables[0].Rows[b][54].ToString();
                                            //dr1["PRODUCT_SAFEGUARD_RATE"] = "";
                                            if (ds.Tables[0].Rows[b][53].ToString() != "" && ds.Tables[0].Rows[b][54].ToString() != "")
                                            {
                                                DataTable x = new DataTable();
                                                DataTable x_Rate = new DataTable();

                                                x = (DataTable)ViewState["get_SAPTA_RATE_ALL"];

                                                var FullName1 = from DataRow drr in x.AsEnumerable()
                                                                where drr.Field<string>("NOTN_No") == ds.Tables[0].Rows[b][53].ToString() && drr.Field<string>("NOTN_SLNo") == ds.Tables[0].Rows[b][54].ToString()
                                                                select drr;
                                                x_Rate = FullName1.CopyToDataTable();
                                                if (x_Rate.Rows.Count > 0)
                                                {
                                                    dr1["PRODUCT_SAFEGUARD_RATE"] = x_Rate.Rows[0]["RATE"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                dr1["PRODUCT_SAFEGUARD_RATE"] = "";
                                            }
                                            //****************************** SAFEGUARD RATE UPDATE END*******************************************

                                            dr1["PRODUCT_SAFEGUARD_SPL"] = "";
                                            dr1["PRODUCT_SAFEGUARD_UNIT"] = "";
                                            dr1["PRODUCT_SAFEGUARD_SPL_TYPE"] = "";

                                            //****************************** SAPTA NOTN RATE UPDATE *******************************************

                                            dr1["PRODUCT_SAPTA_NOTN"] = ds.Tables[0].Rows[b][41].ToString();
                                            dr1["PRODUCT_SAPTA_SLNO"] = ds.Tables[0].Rows[b][42].ToString();

                                            if (ds.Tables[0].Rows[b][41].ToString() != "" && ds.Tables[0].Rows[b][41].ToString() != "")
                                            {
                                                DataTable x = new DataTable();
                                                DataTable x_Rate = new DataTable();

                                                x = (DataTable)ViewState["get_SAPTA_RATE_ALL"];

                                                var FullName1 = from DataRow drr in x.AsEnumerable()
                                                                where drr.Field<string>("NOTN_No") == ds.Tables[0].Rows[b][41].ToString() && drr.Field<string>("NOTN_SLNo") == ds.Tables[0].Rows[b][42].ToString()
                                                                select drr;
                                                x_Rate = FullName1.CopyToDataTable();
                                                if (x_Rate.Rows.Count > 0)
                                                {
                                                    dr1["PRODUCT_SAPTA_RATE"] = x_Rate.Rows[0]["RATE"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                dr1["PRODUCT_SAPTA_RATE"] = "";
                                            }
                                            //******************************  SAPTA NOTN RATE UPDATE end*******************************************

                                            dr1["PRODUCT_TARIFF_NOTN"] = "";
                                            dr1["PRODUCT_TARIFF_SLNO"] = "";
                                            dr1["PRODUCT_TARIFF_QTY"] = "";
                                            dr1["PRODUCT_TARIFF_AMOUNT"] = "";
                                            dr1["PRODUCT_TARIFF_AMOUNT_UNIT"] = "";
                                            dr1["PRODUCT_CETH"] = ds.Tables[0].Rows[b][22].ToString();

                                            dr1["PRODUCT_MRP_SL_NO"] = ds.Tables[0].Rows[b][46].ToString();

                                            if (dr1["PRODUCT_MRP_SL_NO"] != "")
                                            {
                                                get_ABT_RATE_RSP(ds.Tables[0].Rows[b][22].ToString(), ds.Tables[0].Rows[b][48].ToString(), ds.Tables[0].Rows[b][49].ToString());

                                                dr1["PRODUCT_MRP_YN"] = "Y";
                                                dr1["PRODUCT_MRP_AMOUNT"] = ds.Tables[0].Rows[b][47].ToString();
                                                dr1["PRODUCT_MRP_ABT_RATE"] = ABTT_Rate;

                                                //dr1["RSP_NOTN_NO"] = ds.Tables[0].Rows[b][27].ToString();   Product_Education_cess_notification1
                                                //dr1["RSP_NOTN_SL_NO"] = ds.Tables[0].Rows[b][28].ToString();Product_Education_cess_notification1_Slno1

                                                dr1["RSP_NOTN_NO"] = ds.Tables[0].Rows[b][48].ToString();
                                                dr1["RSP_NOTN_SL_NO"] = ds.Tables[0].Rows[b][49].ToString();
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

                                            //This field removed from excel..
                                            //dr1["PRODUCT_CVD_EDU_CESS_RATE"] = ds.Tables[0].Rows[b][39].ToString();
                                            //dr1["CETH_CVD_EDU_CESS_SL"] = ds.Tables[0].Rows[b][40].ToString();

                                            dr1["PRODUCT_CVD_EDU_CESS_RATE"] = "";
                                            dr1["CETH_CVD_EDU_CESS_SL"] = "";


                                            dr1["PRODUCT_ADDL_DUTY_NOTN"] = ds.Tables[0].Rows[b][39].ToString();
                                            dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = ds.Tables[0].Rows[b][40].ToString();

                                            dr1["PRODUCT_ADDL_GSI_NOTN"] = ds.Tables[0].Rows[b][43].ToString();
                                            dr1["PRODUCT_ADDL_TTA_NOTN"] = ds.Tables[0].Rows[b][44].ToString();


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
                                            dr1["PRODUCT_ADDL_SHEII_NOTN"] = ds.Tables[0].Rows[b][50].ToString(); ;
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
                                            dr1["RSP_APPLICABLE"] = ds.Tables[0].Rows[b][45].ToString() == "" ? "N" : ds.Tables[0].Rows[b][45].ToString();

                                            dsXML.Tables[1].Rows.Add(dr1);


                                            //--------------------License Details--------------------------//

                                            if (ds.Tables[0].Rows.Count > c)
                                            {

                                                string regno = ds.Tables[0].Rows[c][34].ToString();

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
                                                    dr2["REGISTRATION_NO"] = ds.Tables[0].Rows[c][34].ToString();

                                                    string REGISTRATION_DATE = ds.Tables[0].Rows[c][35].ToString();

                                                    if (REGISTRATION_DATE != "")
                                                    {
                                                        string reg_date = Convert.ToDateTime(ds.Tables[0].Rows[c][35].ToString()).ToShortDateString();
                                                        string reg_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(reg_date));


                                                        //dr2["REGISTRATION_DATE"] = DateTime.Parse(reg_date1, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                                        dr2["REGISTRATION_DATE"] = Convert.ToDateTime(REGISTRATION_DATE).ToString(@"MM/dd/yyyy");


                                                    }
                                                    else
                                                    {
                                                        REGISTRATION_DATE = "01/01/1900";
                                                    }

                                                    dr2["EXCEMPTION"] = ds.Tables[0].Rows[c][36].ToString();

                                                    dr2["DEBIT_AMT"] = "";
                                                    dr2["DEBIT_QTY"] = ds.Tables[0].Rows[c][6].ToString();
                                                    dr2["UNIT_QTY"] = ds.Tables[0].Rows[c][7].ToString();
                                                    dr2["LICENSE_ITEM_NO"] = ds.Tables[0].Rows[c][37].ToString();
                                                    dr2["PORT_OF_LICENSE"] = ds.Tables[0].Rows[c][38].ToString();

                                                    dr2["USER_ID"] = currentuser;
                                                    dr2["DATE_TIME"] = "";
                                                    dr2["STATUS"] = "S";
                                                    dr2["BRANCH_CODE"] = currentbranch;
                                                    dr2["YEAR"] = "";
                                                    dr2["WORKING_PERIOD"] = Working_Period;

                                                    dr2["DEBIT_DUTY"] = "";
                                                    dr2["LICENSE_NO"] = ds.Tables[0].Rows[c][34].ToString();
                                                    dr2["LICENSE_DATE"] = dr2["REGISTRATION_DATE"];

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


                                        //--------------------------

                                        //int sum = 0;
                                        //foreach (DataRow dritem in dt.Rows)
                                        //{
                                        //    sum += Convert.ToInt32(dritem["ITEM_TOTAL_AMOUNT"]);
                                        //}
                                        //dr["INVOICE_VALUE"] = sum.ToString();

                                        //------------------------------

                                        //******************************************* OLD **************************
                                        //string dd = ds.Tables[0].Rows[a][1].ToString();
                                        //var Values = from row in dsXML.Tables["ItemDetails"].AsEnumerable()
                                        //             //group row by row.Field<string>("INVOICE_NO") into g
                                        //             //group row by dd into g
                                        //             group row by new { id = row.Field<string>("INVOICE_NO") } into g
                                        //             select new
                                        //             {
                                        //                 name_1 = g.Key.id,

                                        //                 name_2 = g.Sum(r => r.Field<double>("ITEM_TOTAL_AMOUNT"))



                                        //             };

                                        //foreach (var drval in Values)
                                        //{
                                        //    if (drval.name_1 == dd)
                                        //        dr["INVOICE_VALUE"] = drval.name_2;
                                        //}

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

                                        //foreach (var drval in Values)
                                        //{
                                        //    if (drval.name_1 == dd)                          
                                        //        Inv_new = Convert.ToString(drval.name_2);
                                        //    if (Inv_new.Contains("."))
                                        //    {
                                        //        string[] Inv_new1 = Inv_new.Split('.');
                                        //        string p1 = Inv_new1[0];
                                        //        string p2 = Inv_new1[1];
                                        //        if (p2.Length >= 2)
                                        //        {
                                        //            string Aft_digit = p2.Substring(0, 2);
                                        //            dr["INVOICE_VALUE"] = p1 + "." + Aft_digit;
                                        //        }
                                        //        else
                                        //        {
                                        //            dr["INVOICE_VALUE"] = Inv_new;
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        dr["INVOICE_VALUE"] = drval.name_2;
                                        //    }
                                        //}

                                        foreach (var drval in Values)
                                        {
                                            if (drval.name_1 == dd)
                                                dr["INVOICE_VALUE"] = drval.name_2;
                                        }
                                        string INV_VAL = dr["INVOICE_VALUE"].ToString();
                                        if (COMPANY_IDD == "247")
                                        {
                                            dr["INVOICE_VALUE"] = Convert.ToString(Math.Round(Convert.ToDouble(INV_VAL), 2).ToString("0.00"));
                                        }
                                        else
                                        {

                                            //string INV_VAL = dr["INVOICE_VALUE"].ToString();
                                            string INV_VAL_NEW;
                                            if (INV_VAL.Contains("."))
                                            {
                                                string[] INV_VAL_DEC = INV_VAL.Split('.');
                                                string p1 = INV_VAL_DEC[0];
                                                string p2 = INV_VAL_DEC[1];
                                                if (p2.Length > 2)
                                                {
                                                    string Aft_digit = p2.Substring(0, 2);
                                                    INV_VAL_NEW = p1 + "." + Aft_digit;
                                                    dr["INVOICE_VALUE"] = INV_VAL_NEW;
                                                }
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

                            */
                                        //------------------------------------------------------------------     
                                        /*DataTable data = new DataTable();
                                        data.Columns.Add("Invoice Date", typeof(DateTime));
                                        DataRow dr = data.NewRow();
                                        dr[0] = DateTime.Now;*/
                                        //------------------------------------------------------------------
                         
                            ////            DataRow dr = dsXML.Tables[0].NewRow();

                            ////            dr["INVOICE_ID"] = "";
                            ////            dr["JOBNO"] = IMPORT_JOBNO;
                            ////            dr["INVOICE_SLNO"] = a + 1;
                            ////            inv_slno_item_slno = a + 1;
                            ////            dr["INVOICE_NO"] = inv_no = dss1.Tables[0].Rows[0][3].ToString();

                            ////            string adt = dss1.Tables[0].Rows[0][4].ToString();
                            ////            string y = adt.Substring(0, 4);
                            ////            string m = adt.Remove(0, 4).Substring(0, 2);
                            ////            string d = adt.Remove(0, 6).Substring(0, 2);

                            ////            //string dd = d + "/" + m + "/" + y;
                            ////            string dd = d + "/" + m + "/" + y;

                            ////            /*string inv_date = Convert.ToDateTime((d + "/" + m + "/" + y).ToString()).ToShortDateString();
                            ////            //dr["INVOICE_DATE"]= string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dd));
                            ////            // dr["INVOICE_DATE"] = DateTime.Parse(d + "/" + m + "/" + y, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);*/


                            ////            //dr["INVOICE_DATE"] = Convert.ToDateTime(dd).ToString(@"MM/dd/yyyy");
                            ////            //dr["INVOICE_DATE"] = DateTime.ParseExact(dd, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);




                            ////            dr["INVOICE_DATE"] = adt;

                            ////            dr["TERMS"] = dss1.Tables[0].Rows[0][30].ToString();
                            ////            dr["INVOICE_CURRENCY"] = dss1.Tables[0].Rows[0][24].ToString();

                            ////            if (!string.IsNullOrEmpty(Edit_inv_currency))
                            ////            {
                            ////                dr["INVOICE_EXRATE"] = Edit_Exrate;
                            ////                dr["INVOICE_CURRENCY"] = Edit_inv_currency;

                            ////            }
                            ////            else
                            ////            {
                            ////                if (dr["INVOICE_CURRENCY"] != "")
                            ////                {
                            ////                    adm.Invoice_Currency = dr["INVOICE_CURRENCY"].ToString(); ;

                            ////                    adm.Ename = "IMPORT_INV_EX_RATE_CURRENCY_NAME";
                            ////                    adm.EWorking_Period = Working_Period;



                            ////                    ds1 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            ////                    if (ds1.Tables[0].Rows.Count > 0)
                            ////                    {
                            ////                        dr["INVOICE_EXRATE"] = Edit_Exrate = ds1.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                            ////                        dr["INVOICE_CURRENCY"] = Edit_inv_currency = adm.Invoice_Currency = ds1.Tables[0].Rows[0]["EXCHANGE_CUR_CODE"].ToString();

                            ////                    }

                            ////                }
                            ////                else
                            ////                {
                            ////                    dr["INVOICE_EXRATE"] = Edit_Exrate = "";
                            ////                }
                            ////            }
                            ////            dr["INVOICE_VALUE"] = "";

                            ////            dr["INVOICE_NO"] = inv_no = dss1.Tables[0].Rows[0][3].ToString();

                            ////            string supp_code = inv_no.Substring(0, 4);
                            ////            //string m = adt.Remove(0, 4).Substring(0, 2);
                            ////            //string d = adt.Remove(0, 6).Substring(0, 2);

                            ////            DataSet dtsupp = new DataSet();
                            ////            erm.Esupid = supp_code;
                            ////            erm.Esup_name = "0";
                            ////            erm.Ename = "select_HP_Supp_Details";
                            ////            erm.EWorking_Period = Working_Period;
                            ////            dtsupp = erm.RetrieveAll_Supplier_MASTER();
                            ////            if (dtsupp.Tables[0].Rows.Count > 0)
                            ////            {
                            ////                dr["SUPPLIER_NAME"] = dtsupp.Tables[0].Rows[0]["SUP_NAME"].ToString();
                            ////                dr["SUPPLIER_ADDRESS"] = dtsupp.Tables[0].Rows[0]["SUP_ADD1"].ToString();
                            ////                dr["SUPPLIER_ADDRESS1"] = dtsupp.Tables[0].Rows[0]["SUP_ADD2"].ToString();
                            ////                dr["SUPPLIER_ADDRESS2"] = dtsupp.Tables[0].Rows[0]["SUP_ADD3"].ToString();
                            ////                dr["SUPPLIER_COUNTRY_NAME"] = dtsupp.Tables[0].Rows[0]["SUP_COUNTRY_NAME"].ToString();
                            ////                dr["SUPPLIER_COUNTRY_CODE"] = dtsupp.Tables[0].Rows[0]["SUP_COUNTRY_CODE"].ToString();
                            ////                dr["SUPPLIER_COUNTRY_PINCODE"] = dtsupp.Tables[0].Rows[0]["SUP_PIN_CODE"].ToString();
                            ////                string remarks = dtsupp.Tables[0].Rows[0]["SUP_REMARKS"].ToString();

                            ////            }
                            ////            else
                            ////            {
                            ////                dr["SUPPLIER_NAME"] = "";
                            ////                dr["SUPPLIER_ADDRESS"] = "";
                            ////                dr["SUPPLIER_ADDRESS1"] = "";
                            ////                dr["SUPPLIER_ADDRESS2"] = "";
                            ////                dr["SUPPLIER_COUNTRY_NAME"] = "";
                            ////                dr["SUPPLIER_COUNTRY_CODE"] = "";
                            ////                dr["SUPPLIER_COUNTRY_PINCODE"] = "";
                            ////            }

                            ////            //dr["SUPPLIER_NAME"] = "";
                            ////            //dr["SUPPLIER_ADDRESS"] = "";
                            ////            //dr["SUPPLIER_ADDRESS1"] = "";
                            ////            //dr["SUPPLIER_ADDRESS2"] = "";
                            ////            //dr["SUPPLIER_COUNTRY_NAME"] = "";
                            ////            //dr["SUPPLIER_COUNTRY_CODE"] = "";
                            ////            //dr["SUPPLIER_COUNTRY_PINCODE"] = "";


                            ////            dr["SELLER_NAME"] = "";
                            ////            dr["SELLER_ADDRESS"] = "";
                            ////            dr["SELLER_ADDRESS1"] = "";
                            ////            dr["SELLER_ADDRESS2"] = "";
                            ////            dr["SELLER_COUNTRY_NAME"] = "";
                            ////            dr["SELLER_COUNTRY_CODE"] = "";
                            ////            dr["SELLERCOUNTRY_PINCODE"] = "";
                            ////            dr["BROKER_NAME"] = "";
                            ////            dr["BROKER_ADDRESS"] = "";
                            ////            dr["BROKER_ADDRESS1"] = "";
                            ////            dr["BROKER_ADDRESS2"] = "";
                            ////            dr["BROKER_COUNTRY_NAME"] = "";
                            ////            dr["BROKER_COUNTRY_CODE"] = "";
                            ////            dr["BROKER_COUNTRY_PINCODE"] = "";

                            ////            dr["MIS_CHARGES"] = "";
                            ////            dr["MIS_RATE"] = "";
                            ////            dr["MIS_CURRENCY"] = "";

                            ////            if (dr["INVOICE_CURRENCY"] == dr["MIS_CURRENCY"])
                            ////            {
                            ////                dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////            }
                            ////            else
                            ////            {

                            ////                if (dr["MIS_CURRENCY"] != "")
                            ////                {
                            ////                    adm.Invoice_Currency = dr["MIS_CURRENCY"].ToString();

                            ////                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            ////                    adm.EWorking_Period = Working_Period;

                            ////                    ds2 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            ////                    if (ds2.Tables[0].Rows.Count > 0)
                            ////                    {
                            ////                        dr["MIS_EXRATE"] = ds2.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                            ////                    }

                            ////                }
                            ////                else
                            ////                {
                            ////                    dr["MIS_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            ////                    dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                }
                            ////            }

                            ////            dr["MIS_AGENCY_CHARGES"] = "";
                            ////            dr["MIS_AGENCY_RATE"] = "";
                            ////            dr["MIS_AGENCY_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            ////            dr["MIS_AGENCY_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////            dr["MIS_DISCOUNT_CHARGES"] = "";
                            ////            dr["MIS_DISCOUNT_RATE"] = "";
                            ////            dr["MIS_DISCOUNT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            ////            dr["MIS_DISCOUNT_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////            dr["MIS_DISCOUNT_REASON"] = "";
                            ////            dr["MIS_LOADING_CHARGES"] = "";
                            ////            dr["MIS_LOADING_RATE"] = "";
                            ////            dr["MIS_LOADING_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            ////            dr["MIS_LOADING_EXRATE"] = dr["INVOICE_EXRATE"];




                            ////            dr["MIS_HIGHSEASALE_CHARGES"] = "";
                            ////            dr["MIS_HIGHSEASALE_RATE"] = "";
                            ////            dr["MIS_HIGHSEASALE_CURRENCY"] = "INR";
                            ////            dr["MIS_HIGHSEASALE_EXRATE"] = "1.00";
                            ////            dr["MIS_SINGLE_OR_MULITIPLE"] = "S";
                            ////            dr["SVB_RELATION"] = "";
                            ////            dr["SVB_REF_NO"] = "";

                            ////            string SVB_REF_DT = "01/01/1900";
                            ////            dr["SVB_REF_DATE"] = DateTime.Parse(SVB_REF_DT, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                            ////            dr["SVB_CUSTOM_HOUSE"] = "";
                            ////            dr["SVB_LOADING_ON"] = "";
                            ////            dr["SVB_ASSESABLE_RATE"] = "";
                            ////            dr["SVB_DUTY_RATE"] = "";
                            ////            dr["SVB_ASSESABLE_STATUS"] = "";
                            ////            dr["SVB_DUTY_STATUS"] = "";
                            ////            //dr["OTHER_PURCHASE_ORDER"] = ds.Tables[0].Rows[a][7].ToString();
                            ////            dr["OTHER_PURCHASE_ORDER"] = dss1.Tables[0].Rows[0][8].ToString();

                            ////            dr["OTHER_PURCHASE_ORDER_DATE"] = dr["INVOICE_DATE"];

                            ////            dr["OTHER_CONTRACT_NO"] = dss1.Tables[0].Rows[0][14].ToString();

                            ////            dr["OTHER_CONTRACT_DATE"] = dr["INVOICE_DATE"];

                            ////            dr["OTHER_LOC_NO"] = "";
                            ////            dr["OTHER_NATURE_OF_TRANSACTION"] = "";
                            ////            dr["OTHER_TERMS_OF_PAYMENT"] = "";
                            ////            dr["OTHER_CONDITIONS"] = "";
                            ////            dr["OTHER_VALUATION_METHOD"] = "";


                            ////            dr["SAP_DELIEVERY_ID"] = dss1.Tables[0].Rows[0][11].ToString();

                            ////            string ship = dss1.Tables[0].Rows[0][36].ToString();
                            ////            if (ship != "")
                            ////            {
                            ////                string y1 = ship.Substring(0, 4);
                            ////                string m1 = ship.Remove(0, 4).Substring(0, 2);
                            ////                string d1 = ship.Remove(0, 6).Substring(0, 2);

                            ////                dr["SHIP_DATE"] = dss1.Tables[0].Rows[0][36].ToString();

                            ////                //dr["SHIP_DATE"] = DateTime.Parse(d1 + "/" + m1 + "/" + y1, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                            ////            }
                            ////            else
                            ////            {
                            ////                string Ship_DATE = "01/01/1900";
                            ////                dr["SHIP_DATE"] = DateTime.Parse(Ship_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                            ////            }

                            ////            dr["INVOICE_LEVEL"] = dss1.Tables[0].Rows[0][39].ToString();
                            ////            dr["COUNTRY_OF_DEPARTURE"] = dss1.Tables[0].Rows[0][40].ToString();


                            ////            string DATE = "01/01/1900";

                            ////            dr["NON_STD_EFFECT_DT_IMP"] = DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                            ////            dr["NON_STD_BANKNAME"] = "";
                            ////            dr["NON_STD_CERTIFICATE_NO"] = "";
                            ////            dr["NON_STD_CERTIFICATE_DATE"] = DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                            ////            dr["USER_ID"] = currentuser;
                            ////            dr["DATE_TIME"] = "";
                            ////            dr["STATUS"] = "S";
                            ////            dr["BRANCH_CODE"] = currentbranch;
                            ////            dr["YEAR"] = "";
                            ////            dr["WORKING_PERIOD"] = Working_Period;


                            ////            //--------------------Item Details--------------------------//

                            ////            //while (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
                            ////            //{

                            ////            //DataSet dss1 = new DataSet();

                            ////            //DataRow[] dtRow1 = ds.Tables[0].Select("invoice_number = '" + inv_no + "'");// ds.Tables[0];

                            ////            //DataTable Newdt1 = dtRow1.CopyToDataTable<DataRow>();
                            ////            //dss1.Tables.Add(Newdt1);

                            ////            b = 0;
                            ////            while (dss1.Tables[0].Rows.Count > b)
                            ////            {
                            ////                DataRow dr1 = dsXML.Tables[1].NewRow();

                            ////                dr1["ITEM_ID"] = "";
                            ////                dr1["JOBNO"] = IMPORT_JOBNO;

                            ////                dr1["INVOICE_NO"] = dss1.Tables[0].Rows[b][3].ToString();
                            ////                dr1["INVOICE_SLNO"] = inv_slno_item_slno;
                            ////                //if (is_sameinvno != dss1.Tables[0].Rows[b][3].ToString())
                            ////                //{
                            ////                //    dr1["INVOICE_SLNO"] = inv_slno_item_slno;
                            ////                //}
                            ////                //else
                            ////                //{
                            ////                //    dr1["INVOICE_SLNO"] = inv_slno_item_slno+1;

                            ////                //}

                            ////                dr1["ITEM_SLNO"] = b + 1;

                            ////                dr1["ITEM_DESCRIPTION"] = dss1.Tables[0].Rows[b][19].ToString() + " " + dss1.Tables[0].Rows[b][20].ToString();
                            ////                dr1["ITEM_QTY"] = dss1.Tables[0].Rows[b][21].ToString();
                            ////                //dr1["ITEM_QTY_CODE"] = dss1.Tables[0].Rows[b][7].ToString();

                            ////                dr1["ITEM_QTY_CODE"] = "PCS";

                            ////                dr1["ITEM_UNIT_PRICE"] = dss1.Tables[0].Rows[b][22].ToString();
                            ////                dr1["ITEM_UNIT_CODE"] = dr["INVOICE_CURRENCY"].ToString();

                            ////                //item_amt = Convert.ToDecimal(dss1.Tables[0].Rows[b][21]) * Convert.ToDecimal(dss1.Tables[0].Rows[b][23]);
                            ////                //dr1["ITEM_TOTAL_AMOUNT"] = item_amt;

                            ////                dr1["ITEM_TOTAL_AMOUNT"] = dss1.Tables[0].Rows[b][23].ToString();

                            ////                dr1["ITEM_AMOUNT_CODE"] = dr["INVOICE_CURRENCY"].ToString();
                            ////                dr1["CTH_NO"] = dss1.Tables[0].Rows[b][28].ToString();

                            ////                //scheme = dss1.Tables[0].Rows[b][35].ToString();
                            ////                scheme = "";
                            ////                if (scheme != "" && scheme != "00" && scheme != "0")
                            ////                {
                            ////                    if (Convert.ToInt32(scheme) <= 9)
                            ////                    {
                            ////                        scheme = "0" + scheme;
                            ////                    }
                            ////                    scheme = Get_Scheme_Code(scheme);
                            ////                    dr1["SCHEME_CODE"] = scheme;
                            ////                    dr1["SCHEME_NOTN"] = dss1.Tables[0].Rows[b][34].ToString();
                            ////                    dr1["SCHEME_NOTN_SLNO"] = dss1.Tables[0].Rows[b][35].ToString();
                            ////                }
                            ////                else
                            ////                {
                            ////                    dr1["SCHEME_CODE"] = "00 - DUTIABLE";
                            ////                    dr1["SCHEME_NOTN"] = "";
                            ////                    dr1["SCHEME_NOTN_SLNO"] = "";
                            ////                }


                            ////                dr1["CTH_QTY1"] = "";
                            ////                dr1["CTH_QTY1_CODE"] = "";
                            ////                dr1["CTH_QTY2"] = "";
                            ////                dr1["CTH_QTY2_CODE"] = "";
                            ////                dr1["GENEARL_DESCRIPTION"] = dss1.Tables[0].Rows[b][20].ToString();
                            ////                dr1["MANUFACTURER"] = "N.A";
                            ////                dr1["BRAND"] = "N.A";
                            ////                dr1["MODEL"] = "N.A";
                            ////                dr1["END_USE_OF_ITEM"] = "N.A";

                            ////                //get country name from admin-ountry master
                            ////                if (!string.IsNullOrEmpty(Edit_Country))
                            ////                {
                            ////                    dr1["COUNTRY_OF_ORIGIN"] = Edit_Country;

                            ////                }
                            ////                else
                            ////                {

                            ////                    adminmaster Admin_mas = new adminmaster();
                            ////                    Admin_mas.Ecountry_id = "0";

                            ////                    Admin_mas.Ecountry_name = dss1.Tables[0].Rows[b][37].ToString();
                            ////                    Admin_mas.Ename = "select_country_Name";
                            ////                    Admin_mas.startRowIndex = Convert.ToString("0");
                            ////                    Admin_mas.maximumRows = Convert.ToString("0");
                            ////                    DataSet ds_country = new DataSet();
                            ////                    ds_country = Admin_mas.RetrieveAll_Country_master();
                            ////                    if (ds_country.Tables.Count > 0)
                            ////                    {
                            ////                        if (ds_country.Tables[0].Rows.Count > 0)
                            ////                        {
                            ////                            dr1["COUNTRY_OF_ORIGIN"] = Edit_Country = ds_country.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();

                            ////                        }
                            ////                    }

                            ////                }
                            ////                //get country name from admin-ountry master
                            ////                dr1["ACCESSORIES"] = "";
                            ////                dr1["PREVIOUS_BE_NO"] = "";

                            ////                string BE_DATE = "01/01/1900";

                            ////                dr1["PREVIOUS_BE_DATE"] = DateTime.Parse(BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                            ////                dr1["UNIT_PRICE"] = "";
                            ////                dr1["UNIT_CODE"] = "";
                            ////                dr1["CUSTOMS_HOUSE"] = "";
                            ////                dr1["PRODUCT_RITC"] = dss1.Tables[0].Rows[b][28].ToString();

                            ////                dr1["PRODUCT_CTH"] = dss1.Tables[0].Rows[b][28].ToString();
                            ////                dr1["PRODUCT_BCD_NOTN"] = "";
                            ////                dr1["PRODUCT_BCD_SLNO"] = "";
                            ////                dr1["PRODUCT_BCD_RATE"] = "";
                            ////                dr1["PRODUCT_BCD_SPL"] = "";
                            ////                dr1["PRODUCT_BCD_UNIT"] = "";
                            ////                dr1["PRODUCT_BCD_SPL_TYPE"] = "";
                            ////                dr1["PRODUCT_ADDL_DUTY_NOTN"] = "";
                            ////                dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = "";
                            ////                dr1["PRODUCT_ADDL_DUTY_RATE"] = "";
                            ////                dr1["PRODUCT_EDU_CESS_NOTN"] = "";
                            ////                dr1["PRODUCT_EDU_CESS_NOTN_SL"] = "";
                            ////                dr1["PRODUCT_EDU_CESS_RATE"] = "";
                            ////                dr1["PRODUCT_SEC_EDU_CESS_NOTN"] = "";
                            ////                dr1["PRODUCT_SEC_EDU_CESS_NOTN_SL"] = "";
                            ////                dr1["PRODUCT_SEC_EDU_CESS_RATE"] = "";
                            ////                dr1["PRODUCT_NCD_NOTN"] = "";

                            ////                dr1["PRODUCT_NCD_SLNO"] = "";
                            ////                dr1["PRODUCT_NCD_RATE"] = "";
                            ////                dr1["PRODUCT_NCD_SPL"] = "";
                            ////                dr1["PRODUCT_NCD_UNIT"] = "";
                            ////                dr1["PRODUCT_NCD_SPL_TYPE"] = "";
                            ////                dr1["PRODUCT_AGGREGATE_DUTY_NOTN"] = "";
                            ////                dr1["PRODUCT_AGGREGATE_DUTY_NOTN_SL"] = "";
                            ////                dr1["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = "";
                            ////                dr1["PRODUCT_SAFEGUARD_NOTN"] = "";
                            ////                dr1["PRODUCT_SAFEGUARD_SLNO"] = "";
                            ////                dr1["PRODUCT_SAFEGUARD_RATE"] = "";
                            ////                dr1["PRODUCT_SAFEGUARD_SPL"] = "";
                            ////                dr1["PRODUCT_SAFEGUARD_UNIT"] = "";
                            ////                dr1["PRODUCT_SAFEGUARD_SPL_TYPE"] = "";
                            ////                dr1["PRODUCT_SAPTA_NOTN"] = "";
                            ////                dr1["PRODUCT_SAPTA_SLNO"] = "";
                            ////                dr1["PRODUCT_SAPTA_RATE"] = "";

                            ////                dr1["PRODUCT_TARIFF_NOTN"] = "";
                            ////                dr1["PRODUCT_TARIFF_SLNO"] = "";
                            ////                dr1["PRODUCT_TARIFF_QTY"] = "";
                            ////                dr1["PRODUCT_TARIFF_AMOUNT"] = "";
                            ////                dr1["PRODUCT_TARIFF_AMOUNT_UNIT"] = "";
                            ////                dr1["PRODUCT_CETH"] = dss1.Tables[0].Rows[b][28].ToString();

                            ////                dr1["PRODUCT_MRP_SL_NO"] = "";

                            ////                if (dr1["PRODUCT_MRP_SL_NO"] != "")
                            ////                {
                            ////                    dr1["PRODUCT_MRP_YN"] = "Y";
                            ////                    dr1["PRODUCT_MRP_AMOUNT"] = "";
                            ////                    dr1["PRODUCT_MRP_ABT_RATE"] = "";
                            ////                }
                            ////                else
                            ////                {
                            ////                    dr1["PRODUCT_MRP_YN"] = "N";
                            ////                    dr1["PRODUCT_MRP_AMOUNT"] = "";
                            ////                    dr1["PRODUCT_MRP_ABT_RATE"] = "";
                            ////                }


                            ////                dr1["PRODUCT_CVD_NOTN"] = "";
                            ////                dr1["PRODUCT_CVD_SLNO"] = "";
                            ////                dr1["PRODUCT_CVD_RATE"] = "";
                            ////                dr1["PRODUCT_CVD_SPL"] = "";
                            ////                dr1["PRODUCT_CVD_UNIT"] = "";
                            ////                dr1["PRODUCT_CVD_SPL_TYPE"] = "";
                            ////                dr1["PRODUCT_CVD_EDU_CESS_RATE"] = "";

                            ////                dr1["PRODUCT_CVD_SEC_EDU_CESS_RATE"] = "";
                            ////                dr1["PRODUCT_ADDL5_SIA_NOTN"] = "";
                            ////                dr1["PRODUCT_ADDL5_SIA_NOTN_SL"] = "";
                            ////                dr1["PRODUCT_ADDL5_SIA_RATE"] = "";
                            ////                dr1["PRODUCT_ADDL_GSI_NOTN"] = "";
                            ////                dr1["PRODUCT_ADDL_GSI_SLNO"] = "";
                            ////                dr1["PRODUCT_ADDL_GSI_RATE"] = "";
                            ////                dr1["PRODUCT_ADDL_GSI_SPL"] = "";
                            ////                dr1["PRODUCT_ADDL_GSI_UNIT"] = "";
                            ////                dr1["PRODUCT_ADDL_GSI_SPL_TYPE"] = "";
                            ////                dr1["PRODUCT_ADDL_SHEII_NOTN"] = "";
                            ////                dr1["PRODUCT_ADDL_SHEII_SLNO"] = "";
                            ////                dr1["PRODUCT_ADDL_SHEII_RATE"] = "";
                            ////                dr1["PRODUCT_ADDL_SHEII_SPL"] = "";
                            ////                dr1["PRODUCT_ADDL_SHEII_UNIT"] = "";
                            ////                dr1["PRODUCT_ADDL_SHEII_TYPE"] = "";
                            ////                dr1["PRODUCT_ADDL_TTA_NOTN"] = "";

                            ////                dr1["PRODUCT_ADDL_TTA_SLNO"] = "";
                            ////                dr1["PRODUCT_ADDL_TTA_RATE"] = "";
                            ////                dr1["PRODUCT_ADDL_TTA_SPL"] = "";
                            ////                dr1["PRODUCT_ADDL_TTA_UNIT"] = "";
                            ////                dr1["PRODUCT_ADDL_TTA_TYPE"] = "";
                            ////                dr1["PRODUCT_ADDL_HEALTH_CESS_NOTN"] = "";
                            ////                dr1["PRODUCT_ADDL_HEALTH_CESS_SLNO"] = "";
                            ////                dr1["PRODUCT_ADDL_HEALTH_CESS_RATE"] = "";
                            ////                dr1["PRODUCT_ADDL_HEALTH_CESS_SPL"] = "";
                            ////                dr1["PRODUCT_ADDL_HEALTH_CESS_UNIT"] = "";
                            ////                dr1["PRODUCT_ADDL_HEALTH_CESS_TYPE"] = "";
                            ////                dr1["PRODUCT_CESS_NOTN"] = "";
                            ////                dr1["PRODUCT_CESS_SLNO"] = "";

                            ////                dr1["PRODUCT_CESS_RATE"] = "";
                            ////                dr1["PRODUCT_CESS_SPL"] = "";
                            ////                dr1["PRODUCT_CESS_UNIT"] = "";
                            ////                dr1["PRODUCT_CESS_TYPE"] = "";

                            ////                dr1["ANTI_DUMPING_NOTN"] = "";
                            ////                dr1["ANTI_DUMPING_NOTN_SLNO"] = "";
                            ////                dr1["CTH_SLNO"] = "";
                            ////                dr1["CTH_SUPPLIER_SLNO"] = "";
                            ////                dr1["CTH_QTY"] = "";
                            ////                dr1["RSP_DUTY_STATUS"] = "";
                            ////                dr1["RSP_SL_NO"] = "";
                            ////                dr1["RSP_DESC"] = "";
                            ////                dr1["RSP_QTY"] = "";
                            ////                dr1["RSP_AMOUNT"] = "";
                            ////                dr1["RSP_NOTN_NO"] = "";
                            ////                dr1["RSP_NOTN_SL_NO"] = "";
                            ////                dr1["RSP_ABT_RATE"] = "";
                            ////                dr1["WAREHOUSE_JOBNO"] = "0";
                            ////                dr1["WAREHOUSE_INVOICE_SLNO"] = "0";
                            ////                dr1["WAREHOUSE_ITEM_SLNO"] = "0";
                            ////                dr1["ASSESSABLE_VALUE"] = "";

                            ////                dr1["DUTY_VALUE"] = "";
                            ////                dr1["CIF_VALUE"] = "";
                            ////                dr1["CVD_VALUE"] = "";

                            ////                dr1["USER_ID"] = currentuser;
                            ////                dr1["DATE_TIME"] = "";
                            ////                dr1["STATUS"] = "N";
                            ////                dr1["BRANCH_CODE"] = currentbranch;

                            ////                dr1["YEAR"] = "";
                            ////                dr1["WORKING_PERIOD"] = Working_Period;

                            ////                dsXML.Tables[1].Rows.Add(dr1);

                            ////                //--------------------License Details--------------------------//

                            ////                //--------------------End License Details--------------------------//
                            ////                b++;
                            ////            }

                            ////            dt = dsXML.Tables["ItemDetails"];

                            ////            //string dd = ds.Tables[0].Rows[a][3].ToString();
                            ////            //string ddnew = dsXML.Tables[1].Rows[a][3].ToString();
                            ////            string ddnew = inv_no;

                            ////            var Values = from row in dsXML.Tables["ItemDetails"].AsEnumerable()

                            ////                         group row by new { id = row.Field<string>("INVOICE_NO") } into g
                            ////                         select new
                            ////                         {
                            ////                             name_1 = g.Key.id,

                            ////                             name_2 = g.Sum(r => r.Field<double>("ITEM_TOTAL_AMOUNT"))

                            ////                         };
                            ////            double mis_val = 0;
                            ////            foreach (var drval in Values)
                            ////            {
                            ////                if (drval.name_1 == ddnew)
                            ////                    dr["INVOICE_VALUE"] = drval.name_2;
                            ////                //string Total_inv_amt= dss1.Tables[0].Rows[0][39].ToString();
                            ////                string inv_val = dr["INVOICE_VALUE"].ToString();
                            ////                //mis_val = Convert.ToDouble(Total_inv_amt) - Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                            ////            }


                            ////            //-----------------Invoice Terms Calculation----------------------------//
                            ////            string Total_inv_amt = dss1.Tables[0].Rows[0][15].ToString();
                            ////            mis_val = Convert.ToDouble(Total_inv_amt) - Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                            ////            dr["MIS_CHARGES"] = Convert.ToString(Math.Round(mis_val).ToString("0.00"));
                            ////            dr["MIS_FREIGHT_CHARGES"] = "";
                            ////            dr["MIS_INSURANCE_CHARGES"] = "";

                            ////            if (dr["MIS_FREIGHT_CHARGES"] == "" || dr["MIS_INSURANCE_CHARGES"] == "")
                            ////            {
                            ////                if (Convert.ToString(dr["TERMS"]) == "FOB")
                            ////                {

                            ////                    dr["MIS_FREIGHT_RATE"] = "20.0000";

                            ////                    double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                            ////                    cal = invoicevalue_Excel * 20 / 100;

                            ////                    dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);



                            ////                    dr["MIS_FREIGHT_CURRENCY"] = "";

                            ////                    if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                            ////                    {
                            ////                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                    }
                            ////                    else
                            ////                    {

                            ////                        if (dr["MIS_FREIGHT_CURRENCY"] != "")
                            ////                        {
                            ////                            adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                            ////                            adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            ////                            adm.EWorking_Period = Working_Period;

                            ////                            ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            ////                            if (ds3.Tables[0].Rows.Count > 0)
                            ////                            {
                            ////                                dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                            ////                            }

                            ////                        }
                            ////                        else
                            ////                        {
                            ////                            dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            ////                            dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                        }
                            ////                    }



                            ////                    dr["MIS_INSURANCE_RATE"] = "1.1250";

                            ////                    double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                            ////                    cal1 = invoicevalue_Excel1 * 1.125 / 100;

                            ////                    dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);


                            ////                    dr["MIS_INSURANCE_CURRENCY"] = "";

                            ////                    if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                            ////                    {
                            ////                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                    }
                            ////                    else
                            ////                    {

                            ////                        if (dr["MIS_INSURANCE_CURRENCY"] != "")
                            ////                        {
                            ////                            adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                            ////                            adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            ////                            adm.EWorking_Period = Working_Period;

                            ////                            ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            ////                            if (ds4.Tables[0].Rows.Count > 0)
                            ////                            {
                            ////                                dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                            ////                            }

                            ////                        }
                            ////                        else
                            ////                        {
                            ////                            dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            ////                            dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                        }
                            ////                    }


                            ////                }


                            ////                else if (Convert.ToString(dr["TERMS"]) == "CI")
                            ////                {

                            ////                    dr["MIS_FREIGHT_RATE"] = "20.0000";

                            ////                    double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                            ////                    cal = invoicevalue_Excel * 20 / 100;

                            ////                    dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);


                            ////                    dr["MIS_FREIGHT_CURRENCY"] = "";

                            ////                    if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                            ////                    {
                            ////                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                    }
                            ////                    else
                            ////                    {

                            ////                        if (dr["MIS_FREIGHT_CURRENCY"] != "")
                            ////                        {
                            ////                            adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                            ////                            adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            ////                            adm.EWorking_Period = Working_Period;

                            ////                            ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            ////                            if (ds3.Tables[0].Rows.Count > 0)
                            ////                            {
                            ////                                dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                            ////                            }

                            ////                        }
                            ////                        else
                            ////                        {
                            ////                            dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            ////                            dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                        }
                            ////                    }


                            ////                }
                            ////                else if (Convert.ToString(dr["TERMS"]) == "CF")
                            ////                {

                            ////                    dr["MIS_INSURANCE_RATE"] = "1.1250";

                            ////                    double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"].ToString());
                            ////                    cal1 = invoicevalue_Excel1 * 1.125 / 100;

                            ////                    dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);


                            ////                    dr["MIS_INSURANCE_CURRENCY"] = "";

                            ////                    if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                            ////                    {
                            ////                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                    }
                            ////                    else
                            ////                    {

                            ////                        if (dr["MIS_INSURANCE_CURRENCY"] != "")
                            ////                        {
                            ////                            adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                            ////                            adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            ////                            adm.EWorking_Period = Working_Period;

                            ////                            ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            ////                            if (ds4.Tables[0].Rows.Count > 0)
                            ////                            {
                            ////                                dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                            ////                            }

                            ////                        }
                            ////                        else
                            ////                        {
                            ////                            dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            ////                            dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                        }
                            ////                    }


                            ////                }
                            ////                else if (Convert.ToString(dr["TERMS"]) == "CIF")
                            ////                {

                            ////                }
                            ////            }
                            ////            else
                            ////            {


                            ////                dr["MIS_FREIGHT_CHARGES"] = "";
                            ////                dr["MIS_FREIGHT_RATE"] = "";
                            ////                dr["MIS_FREIGHT_CURRENCY"] = "";

                            ////                if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                            ////                {
                            ////                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                }
                            ////                else
                            ////                {

                            ////                    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                            ////                    {
                            ////                        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                            ////                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            ////                        adm.EWorking_Period = Working_Period;

                            ////                        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            ////                        if (ds3.Tables[0].Rows.Count > 0)
                            ////                        {
                            ////                            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                            ////                        }

                            ////                    }
                            ////                    else
                            ////                    {
                            ////                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                    }
                            ////                }


                            ////                dr["MIS_INSURANCE_CHARGES"] = "";
                            ////                dr["MIS_INSURANCE_RATE"] = "";
                            ////                dr["MIS_INSURANCE_CURRENCY"] = "";

                            ////                if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                            ////                {
                            ////                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                }
                            ////                else
                            ////                {

                            ////                    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                            ////                    {
                            ////                        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                            ////                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            ////                        adm.EWorking_Period = Working_Period;

                            ////                        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            ////                        if (ds4.Tables[0].Rows.Count > 0)
                            ////                        {
                            ////                            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                            ////                        }

                            ////                    }
                            ////                    else
                            ////                    {
                            ////                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            ////                    }
                            ////                }
                            ////            }

                            ////            //---------------------------End------------------------------------//

                            ////            dsXML.Tables[0].Rows.Add(dr);
                            ////            a++;
                            ////            //}

                            ////        }
                            ////        #endregion
                            ////    }
                            ////}

                            ////dt = dsXML.Tables["InvoiceDetails"];

                            #endregion INVOICE_ITEM hide by Chithra

                            ds_GENERAL = (DataSet)ViewState["ds_GENERAL"];
                            ds_IGM = (DataTable)ViewState["ds_IGM"];
                            ds_CONTAINER = (DataTable)ViewState["ds_CONTAINER"];
                            ds_REIMPORT = (DataTable)ViewState["dt_REIMP"];
                            ds_SW_INFO=(DataTable)ViewState["dt_SW_INFO"];
                            ds_SW_CTRL=(DataTable)ViewState["dt_SW_CTRL"];
                            ds_SW_STMT = (DataTable)ViewState["dt_SW_STMT"];
                            ds_INVOICE = (DataTable)ViewState["dt_INV"];
                            ds_ITEM = (DataTable)ViewState["dt_ITEM"];
                            ds_BOND = (DataTable)ViewState["dt_BOND"];
                            ds_CERT = (DataTable)ViewState["dt_CERT"];
                            ds_LICENSE = (DataTable)ViewState["dt_LICENSE"];
                            ds_SUP_DOC = (DataTable)ViewState["dt_SUP_DOC"];


                            if (ds_GENERAL.Tables[0].Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("GENERAL_DETAILS", ds_GENERAL.Tables[0], comp_ConnectionStr);
                            }
                            if (ds_IGM.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("IGM_DETAILS", ds_IGM, comp_ConnectionStr);
                            }
                            if (ds_CONTAINER.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("CONTAINER_DETAILS", ds_CONTAINER, comp_ConnectionStr);
                            }
                            if (ds_INVOICE.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("INVOICE_DETAILS", ds_INVOICE, comp_ConnectionStr);
                            }
                            if (ds_ITEM.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("ITEM_PRODUCT_DETAILS", ds_ITEM, comp_ConnectionStr);
                            }
                            if (ds_REIMPORT.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("RE_IMPORT_DETAILS", ds_REIMPORT, comp_ConnectionStr);
                            }
                            if (ds_SW_INFO.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("BE_ITEM_SW_INFO_TYPE", ds_SW_INFO, comp_ConnectionStr);
                            }
                            if (ds_SW_CTRL.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("BE_ITEM_SW_CONTROL", ds_SW_CTRL, comp_ConnectionStr);
                            }
                            if (ds_SW_STMT.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("IMP_SINGLE_WINDOW_STMT", ds_SW_STMT, comp_ConnectionStr);
                            }
                            if (ds_BOND.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("BOND_DETAILS", ds_BOND, comp_ConnectionStr);
                            }
                            if (ds_CERT.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("CERTIFICATE_DETAILS", ds_CERT, comp_ConnectionStr);
                            }
                            if (ds_LICENSE.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("LICENSE_DETAILS", ds_LICENSE, comp_ConnectionStr);
                            }
                            if (ds_SUP_DOC.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("BE_ITEM_SW_SUP_DOC", ds_SUP_DOC, comp_ConnectionStr);
                            }
                            //Transact.Bulk_Item_Excel_Upload(RemoveDuplicateRows(dt, "INVOICE_NO"), dsXML.Tables[1], dsXML.Tables[2], "BULK_ITEM_UPLOAD");
                            //Session["JOBIDexcel"] = Get_JOBID();

                            //if (Transact.result == 1)
                            //{
                                // Response.Redirect(Request.RawUrl);
                                //Response.Redirect("General.aspx");
                                Alert_msg("Excel Uploaded Successfully.");

                                Session["JOBIDexcel"] = Get_JOBID();
                            //}
                            //else
                            //{
                            //    Alert_msg("Excel Upload occured some problem");
                            //}
                        }
                        else
                        {
                            Alert_msg("MANUFACRURER-Special Characters Found !!..Correct the File then Upload");
                        }
                    }
                    else
                    {
                        Alert_msg("GENRAL DESCRIPTION-Special Characters Found !!..Correct the File then Upload");
                    }
                }
                else
                {
                    Alert_msg("ITEM DESCRIPTION-Special Characters Found!!..Correct the File then Upload");
                }
            }
            else
            {
                Alert_msg("No Records in INVOICE-ITEM Sheet");
            }
        }
        else
        {
            Alert_msg("Choose Excel File");
        }
    }

    public void get_ABT_RATE_RSP(string CTH, string NotnNo, string SlNo)
    {
        adm.ERSP_id = "";
        adm.ERSP_cthno = CTH;
        adm.ERSP_Notn = NotnNo == "" ? "0" : NotnNo;
        adm.ERSP_Notn_SlNo = SlNo == "" ? "0" : SlNo;

        adm.ERSP_description = "";
        adm.Ename = "Get_RSP_ABTT_RATE_PRODUCT";

        dss_Rsp = adm.RetrieveAll_RSP_master_PRODUCT_MASTER();
        if (dss_Rsp.Tables[0].Rows.Count > 0)
        {
            ABTT_Rate = dss_Rsp.Tables[0].Rows[0]["RSP_RATE"].ToString();
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

    public void Open_Schemecode()
    {
        if (scheme == "00")
        {
            scheme = "00-FREE SHIPPING BILL";
        }
        else if (scheme == "")
        {
            scheme = "00-FREE SHIPPING BILL";

        }
        else if (scheme == "01")
        {
            scheme = "01-ADVANCE LICENSE ACT. USER COND";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "02")
        {
            scheme = "02-ADVANCE LICENSE INTERM SUPPLIES";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "03")
        {
            scheme = "03-ADVANCE LICENSE";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "04")
        {
            scheme = "04-ADVANCE RELEASE ORDER";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "05")
        {
            scheme = "05-ADVANCE RELEASE DEEMED EXPORT";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "08")
        {
            scheme = "08-REPLENISHMENT LICENSE";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "09")
        {
            scheme = "09-DIAMOND IMPREST LICENSE";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "11")
        {
            scheme = "11-CONCESSIONAL DUTY EPCG";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "12")
        {
            scheme = "12-ZERO DUTY EPCG SCHEME";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "17")
        {
            scheme = "17-ADVANCE LICENSE  ANNUAL REQ.";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "19")
        {
            scheme = "19-DRAWBACK (DBK)";
        }
        else if (scheme == "20")
        {
            scheme = "20-JOBBING (JBG)";
        }
        else if (scheme == "21")
        {
            scheme = "21-EOU/EPZ/SEZ/EHTP/STP";
        }

        else if (scheme == "24-VKUY")
        {
            scheme = "24-VKUY";
        }
        else if (scheme == "25-DFIA")
        {
            scheme = "25-DFIA";
        }
        else if (scheme == "26")
        {
            scheme = "26-DFIA";
        }
        else if (scheme == "27")
        {
            scheme = "27-FMS";
        }
        else if (scheme == "28")
        {
            scheme = "28-FPS";
        }
        else if (scheme == "41")
        {
            scheme = "41-DRAWBACK AND ADVANCE LICENSE";
            scheme_name[0] = "DEEC";
        }

        else if (scheme == "43")
        {
            scheme = "43-DRAWBACK AND ZERO DUTY EPCG";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "44")
        {
            scheme = "44-DRAWBACK AND CONCESS. EPCG";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "47")
        {
            scheme = "47-DRAWBACK AND JOBBING";
        }
        else if (scheme == "48")
        {
            scheme = "48-DRAWBACK AND DIAMOND IMP LICENSE";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "49")
        {
            scheme = "49-DRAWBACK AND EOU/EPZ/SEZ";
        }
        else if (scheme == "50")
        {
            scheme = "50-EPCG AND ADVANCE LICENSE";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DEEC";
        }
        else if (scheme == "52")
        {
            scheme = "52-EPCG AND JOBBING";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "53")
        {
            scheme = "53-EPCG AND DIAMOND IMPREST LICENSE";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DEEC";
        }
        else if (scheme == "54")
        {
            scheme = "54-EPCG AND REPLENISHMENT LICENSE";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DEEC";
        }
        else if (scheme == "55")
        {
            scheme = "55-EPCG AND POST EXPORT DEPB";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "59")
        {
            scheme = "59-EPCG, DFIA";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "71")
        {
            scheme = "71-EPCG, DRAWBACK AND DEEC";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DEEC";
        }
        else if (scheme == "73")
        {
            scheme = "73-EPCG, DRAWBACK AND JOBBING";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "74")
        {
            scheme = "74-EPCG, DRAWBACK AND DIMOND IMPREST";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DEEC";
        }
        else if (scheme == "79")
        {
            scheme = "79-EPCG, DRAWBACK AND DFIA";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DFIA";
        }
        else if (scheme == "99")
        {
            scheme = "99-NFEI";
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
}