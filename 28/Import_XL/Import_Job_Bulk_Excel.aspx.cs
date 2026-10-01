using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Data.OleDb;
using System.Text;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ClosedXML.Excel;
using System.Text.RegularExpressions;

public partial class Import_XL_CompleteJobDetails : System.Web.UI.Page
{

    #region Declaration

    AppSession aps = new AppSession();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();
    Transaction Transact = new Transaction();
    UserBO objUBO = new UserBO();
    AdminMasterDetails admin = new AdminMasterDetails();
    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();

    DataSet ds_IEC = new DataSet();
    DataSet ds_supplier = new DataSet();
    DataSet data = new DataSet();
    DataSet dsImp = new DataSet();

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
    DataTable dt_SW_CONST = new DataTable();
    DataTable dt_SW_PROD = new DataTable();

    public int i;
    public int MAX_ID = 0;

    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string SELECT_BRANCH;
    public string COMPANY_IDD, comp_ConnectionStr;
    public string errorFolder = "", logFileName = "";
    public string LoginDate, IMPORT_JOBNO;
    public string Current_JOBID;
    public int Result = 0;

    // General Details
    string JOBDATE = "", TRANSPORT_MODE = "", BE_TYPE = "", CUSTOMS_HOUSE = "", CUSTOMS_HOUSE_NAME = "", IMPORTER_NAME = "", ADDRESS1 = "", ADDRESS2 = "", ADDRESS3 = "", ADDRESS4 = "", ADDRESS5 = "",
                    IEC_NO = "", BRANCH_NO = "", COUNTRY_ORIGIN = "", PORT_ORIGIN = "", PORT_SHIPMENT = "", COUNTRY_SHIPMENT = "", FILING_STATUS = "", SECTION46 = "", SECTION46_DESC = "",
                    FIRSTCHECK = "", FIRSTCHECK_DESC = "", GREEN_CHANNEL = "", GREEN_CHANNEL_DESC = "", KACHHA_BE = "", KACHHA_BE_DESC = "", SECTION48 = "", SECTION48_DESC = "",
                    HIGH_SEA_SALE = "", HIGH_SEA_SALE_NAME = "", HIGH_SEA_IEC = "", HIGH_SEA_BRANCH_SL_NO = "", HSS_NAME = "", HSS_ADD1 = "", HSS_ADD2 = "", HSS_ADD3 = "", HSS_ADD4 = "", HSS_ADD5 = "",
                    WAREHOUSE_NAME = "", WAREHOUSE_CODE = "", IMP_EXP_TYPE = "", COMMERCIAL_TAX = "", COMMERCIAL_TAX_STATENAME = "", STATECODE = "", TYPE = "", REGISTRATION_NO = "",
                    EXBOND_INBOND_BE_NO = "", EXBOND_INBOND_BE_DATE = "", EXBOND_BOND_NO = "", EXBOND_BOND_DATE = "", EXBOND_WAREHOUSE_CUSTOMS = "", EXBOND_WAREHOUSE_CUSTOMS_CODE = "", EXBOND_NOOFPACKAGE = "",
                    EXBOND_NOOFPACKAGE_UNITCODE = "", EXBOND_GROSS_WEIGHT = "", EXBOND_GROSS_WEIGHT_UNITCODE = "", EXBOND_DIRECT_EXBONDING = "", REMARKS = "", USERID = "", LoginSTATUS = "",
                    BRANCHCODE = "", WORKINGPERIOD = "", FILE_REF_NO = "", CONTAINER_TYPE = "", JOB_STATUS = "", JOB_RELEASE = "", JOB_FILED_STATUS = "", MODIFIEDBY = "", MODIFIEDON = "",
                    JOB_PREFIX = "", JOB_SUFFIX = "", JOBNO_PS = "", COMPLETED_DATE = "", ADCODE = "", UCR_NO = "", UCR_TYPE = "", PAYMENT_METHOD_CODE = "", PRECEDING_LEVEL = "",
                    DOC_RECEIVED_DATE = "", AGENT_NAME = "", EXBOND_ADDL_LOAD_HSS = "", EXBOND_MISC_LOAD_RATE = "", COMMERCIAL_TAX_STATECODE = "", GSTN_TYPE = "", GSTN_ID = "",
                    ICE_ID = "", CHA_NO = "", ETA = "", PROVISIONAL_DESC = "", PROVISIONAL = "", HSS_ADCODE = "", PARTY_REF_NO="";
                    //COMMERCIAL_TAX_DETAILS="" ,STATE_CODE="",REGISTRATION_NO="",GSTN_TYPE="", 

    // IGM Details
    string IGM_SLNO = "", JOBNO = "", IGM_JOBDATE = "", IGM_AIRLINECODE = "", IGM_AIRLINENAME = "", IGM_FLIGHTNO_VESSELNO = "", IGM_FLIGHT_VESSELDATE = "", IGM_NO = "", IGM_DATE = "",
                    IGM_MAWB_MBL = "", IGM_MAWB_MBLDATE = "", IGM_HAWB_HBLNO = "", IGM_HAWB_HBLDATE = "", IGM_NOOFPACKAGE = "", IGM_PACKAGETYPE = "", IGM_GROSSWEIGHT = "", IGM_TYPEOFWEIGHT = "",
                    IGM_NETWEIGHT = "", IGM_NETWEIGHTTYPE = "", IGM_TRANSPORTMODE = "", IGM_MARKSNOS = "", IGM_GATEWAY_IGM_NO = "", IGM_GATEWAY_IGM_DATE = "", IGM_GATEWAY_PORT_CODE = "",
                    IGM_LINE_NUMBER = "", IGM_SHIPPING_LINE_NUMBER = "", IGM_VOYAGE = "", IGM_CHARGEABLE_WGT = "";

    // Container Details
    string CONTAINERID = "", CONTAINER_IGM_SLNO = "", CONTAINER_IGM_NO = "", CONTAINER_IGM_DATE = "", CONTAINER_NO = "", SEAL_NO = "", FCL_OR_LCL = "", TRUCK_NO = "";

    // Re-Import Details
    string RE_IMPORT_SLNO = "", INVOICE_SLNO = "", ITEM_SLNO = "", SB_NO = "", SB_DATE = "", PORT_EXPORT = "", SB_INVOICE_NO = "", SB_INVOICE__ITEM_NO = "", NOTN_NO = "", NOTN_SLNO = "",
           EXPORT_FREIGHT = "", EXPORT_INSURANCE = "", CUSTOMS_DUTY = "", EXCISE_DUTY = "";

    // SW Info Type
    string SW_INFO_TYPE_ID = "", INFO_TYPE = "", INFO_QUALIFIER = "", INFO_CODE = "", INFO_TEXT = "", INFO_MSR = "", INFO_UQC = "", DATE_TIME = "", DEPARTMENT = "", I_U_TYPE = "", REGN_DATE = "", REGN_VALIDITY = "";

    // SW Control
    string CONTROL_TYPE_CODE = "", CONTROL_LOCATION = "", CONTROL_START_DATE = "", CONTROL_END_DATE = "", CONTROL_RESULT_CODE = "", CONTROL_RESULT_TEXT = "", CONTROL_MSR = "", CONTROL_UQC = "", CONTROL_SLNO = "";

    // SW Stmt
    string SW_ID = "", STMT_DECLARATION_TYPE = "", STMT_DECLARATION_NUMBER = "", STMT_DECLARATION_DATE = "", STMT_TYPE = "", STMT_CODE = "", STMT_TEXT = "";

    // SW Production
    string PRODUCTION_BATCH_IDENTIFIER = "", PRODUCTION_BATCH_QUANTITY = "", UNIT_QTY_CODE = "", DATE_OF_MANUFACTURING = "", DATE_OF_EXPIRY = "", BEST_BEFORE = "";

    // SW Constituent
    string CONSTITUENT_SRNO = "", CONSTITUENT_ELEMENT_NAME = "", CONSTITUENT_ELEMENT_CODE = "", CONSTITUENT_PERCENTAGE = "", CONSTITUENT_YIELD_PERCENTAGE = "", ACTIVE_INGREDIENT = "";

    // Invoice Details
    string INVOICE_ID = "", INVOICE_NO = "", INVOICE_DATE = "", TERMS = "", INVOICE_CURRENCY = "", INVOICE_EXRATE = "", INVOICE_VALUE = "",
                        SUPPLIER_NAME = "", SUPPLIER_ADDRESS = "", SUPPLIER_ADDRESS1 = "", SUPPLIER_ADDRESS2 = "", SUPPLIER_COUNTRY_NAME = "", SUPPLIER_COUNTRY_CODE = "", SUPPLIER_COUNTRY_PINCODE = "",
                        SELLER_NAME = "", SELLER_ADDRESS = "", SELLER_ADDRESS1 = "", SELLER_ADDRESS2 = "", SELLER_COUNTRY_NAME = "", SELLER_COUNTRY_CODE = "", SELLERCOUNTRY_PINCODE = "",
                        BROKER_NAME = "", BROKER_ADDRESS = "", BROKER_ADDRESS1 = "", BROKER_ADDRESS2 = "", BROKER_COUNTRY_NAME = "", BROKER_COUNTRY_CODE = "", BROKER_COUNTRY_PINCODE = "",
                        MIS_CHARGES = "", MIS_RATE = "", MIS_CURRENCY = "", MIS_AGENCY_CHARGES = "", MIS_AGENCY_RATE = "", MIS_AGENCY_CURRENCY = "",
                        MIS_DISCOUNT_CHARGES = "", MIS_DISCOUNT_RATE = "", MIS_DISCOUNT_CURRENCY = "", MIS_DISCOUNT_REASON = "", MIS_LOADING_CHARGES = "", MIS_LOADING_RATE = "", MIS_LOADING_CURRENCY = "",
                        MIS_FREIGHT_CHARGES = "", MIS_FREIGHT_RATE = "", MIS_FREIGHT_CURRENCY = "", MIS_INSURANCE_CHARGES = "", MIS_INSURANCE_RATE = "", MIS_INSURANCE_CURRENCY = "",
                        MIS_HIGHSEASALE_CHARGES = "", MIS_HIGHSEASALE_RATE = "", MIS_HIGHSEASALE_CURRENCY = "", MIS_HIGHSEASALE_EXRATE = "", SVB_RELATION = "", SVB_REF_NO = "", SVB_REF_DATE = "", SVB_CUSTOM_HOUSE = "",
                        SVB_LOADING_ON = "", SVB_ASSESABLE_RATE = "", SVB_DUTY_RATE = "", SVB_ASSESABLE_STATUS = "", SVB_DUTY_STATUS = "", OTHER_PURCHASE_ORDER = "", OTHER_PURCHASE_ORDER_DATE = "", OTHER_CONTRACT_NO = "", OTHER_CONTRACT_DATE = "",
                        OTHER_LOC_NO = "", OTHER_LOC_DATE = "", OTHER_NATURE_OF_TRANSACTION = "", OTHER_TERMS_OF_PAYMENT = "", OTHER_CONDITIONS = "", OTHER_VALUATION_METHOD = "",
                        NON_STD_EFFECT_DT_IMP = "", NON_STD_BANKNAME = "", NON_STD_CERTIFICATE_NO = "", NON_STD_CERTIFICATE_DATE = "", SAP_DELIEVERY_ID = "", SHIP_DATE = "", COUNTRY_OF_DEPARTURE = "", REVENUEDEPOSIT_RATE = "",
                        REVENUEDEPOSIT_ON = "", TERMS_PLACE = "", THIRDPARTY_NAME = "", THIRDPARTY_ADD1 = "", THIRDPARTY_ADD2 = "", THIRDPARTY_CITY = "", T_PARTY_COUNTRY_SUB_DIV = "", T_PARTY_COUNTRY_CODE = "", T_PARTY_PIN = "",
                        AUTHORIZED_ECONOMIC_OPERATOR_CODE = "", A_E_O_COUNTRY = "", AUTHORIZED_ECONOMIC_OPERATOR = "", WHETHER_BUYER_SELLER_RELATED = "";
   string MIS_EXRATE = "", MIS_AGENCY_EXRATE = "", MIS_DISCOUNT_EXRATE = "", MIS_LOADING_EXRATE = "", MIS_FREIGHT_EXRATE = "", MIS_INSURANCE_EXRATE = "",
                        MIS_SINGLE_OR_MULITIPLE = "", INVOICE_LEVEL = "", MI_FREIGHT = "", MI_INSURANCE = "", MI_MISC = "", MI_HSS = "", INDEV_INV_TYPE = "", D_AMOUNT = "", M_AMOUNT = "",
                        N_AMOUNT = "", TOTAL_OTHER_AMOUNT = "", HANDLING_CHARGES = "", LOADING_CHARGES = "", UNLOADING_CHARGES = "";

    // Item Details
    string ITEM_DESCRIPTION = "", ITEM_QTY = "", ITEM_QTY_CODE = "", ITEM_UNIT_PRICE = "", ITEM_TOTAL_AMOUNT = "", ITEM_UNIT_CODE = "", CTH_NO = "", PRODUCT_CTH = "", PRODUCT_RITC = "", PRODUCT_CETH = "", SCHEME_CODE = "", SCHEME_NOTN = "", SCHEME_NOTN_SLNO = "",
                             CTH_QTY1 = "", CTH_QTY1_CODE = "", CTH_QTY2 = "", CTH_QTY2_CODE = "", GENEARL_DESCRIPTION = "", MANUFACTURER = "", BRAND = "", MODEL = "", END_USE_OF_ITEM = "",
                             COUNTRY_OF_ORIGIN = "", ACCESSORIES = "", PREVIOUS_BE_NO = "", PREVIOUS_BE_DATE = "", UNIT_PRICE = "", UNIT_CODE = "", PRODUCT_BCD_NOTN = "", PRODUCT_BCD_SLNO = "", PRODUCT_EDU_CESS_NOTN = "", PRODUCT_EDU_CESS_NOTN_SL = "",
                             PRODUCT_NCD_SLNO = "", PRODUCT_NCD_NOTN = "", PRODUCT_SEC_EDU_CESS_NOTN_SL = "", PRODUCT_AGGREGATE_DUTY_NOTN = "", PRODUCT_AGGREGATE_DUTY_NOTN_SL = "",
                             PRODUCT_SAFEGUARD_NOTN = "", PRODUCT_SAFEGUARD_SLNO = "", PRODUCT_SAPTA_SLNO = "", PRODUCT_SAPTA_NOTN = "", PRODUCT_TARIFF_NOTN = "", PRODUCT_TARIFF_SLNO = "", PRODUCT_TARIFF_QTY = "",
                             PRODUCT_TARIFF_AMOUNT = "", PRODUCT_TARIFF_AMOUNT_UNIT = "",/* PRODUCT_CETH = "" ,*/ PRODUCT_CVD_NOTN = "", PRODUCT_CVD_SLNO = "", PRODUCT_ADDL_SHEII_NOTN = "", PRODUCT_ADDL_SHEII_SLNO = "",
                             PRODUCT_ADDL_HEALTH_CESS_NOTN = "", PRODUCT_ADDL_HEALTH_CESS_SLNO = "", PRODUCT_CESS_NOTN = "", PRODUCT_CESS_SLNO = "", PRODUCT_OTHER_DUTY_NOTN = "", PRODUCT_OTHER_DUTY_SLNO = "",
                             CTH_SLNO = "", CTH_SUPPLIER_SLNO = "", CTH_QTY = "", CENTRAL_EXCISE_FLAG = "", M_P_GROWER_ADD1 = "", M_P_GROWER_ADD2 = "", M_P_GROWER_CITY = "", M_P_GROWER_COUNTRY_SUBDIV = "", M_P_GROWER_PIN = "", M_P_GROWER_COUNTRY = "",
                             SOURCE_COUNTRY = "", TRANSIT_COUNTRY = "", ACCESSORY_STATUS = "", IGST_LEVY_NOTN = "", IGST_LEVY_SLNO = "", IGST_LEVY_EXCEPTION_NOTN = "", IGST_LEVY_EXCEPTION_SLNO = "",
                             LEVY_EXCEMPTION_NOTN_TYPE = "", IGST_LEVY_COMPENSATION_CESS_NOTN = "", IGST_LEVY_COMPENSATION_CESS_SLNO = "", IGST_LEVY_EXCEPTION_CC_NOTN = "", IGST_LEVY_EXCEPTION_CC_SLNO = "", LEVY_EXCEPTION_CC_NOTN_TYPE = "",
                             SOCIAL_WELFARE_NOTN = "", SOCIAL_WELFARE_NOTN_SLNO = "", AIDC_NOTN = "", AIDC_NOTN_SLNO = "",
                             // added on 16-06-2026 by George Bush
                             PRODUCT_BCD_RATE = "", PRODUCT_BCD_SPL = "", PRODUCT_BCD_UNIT = "", PRODUCT_BCD_SPL_TYPE = "", PRODUCT_ADDL_DUTY_NOTN = "", 
                             PRODUCT_ADDL_DUTY_NOTN_SL = "", PRODUCT_ADDL_DUTY_RATE = "", PRODUCT_EDU_CESS_RATE = "", PRODUCT_SEC_EDU_CESS_RATE = "", PRODUCT_NCD_RATE = "", 
                             PRODUCT_NCD_SPL = "", PRODUCT_NCD_UNIT = "", PRODUCT_NCD_SPL_TYPE = "", PRODUCT_AGGREGATE_DUTY_NOTN_RATE = "", PRODUCT_SAFEGUARD_RATE = "", 
                             PRODUCT_SAFEGUARD_SPL = "", PRODUCT_SAFEGUARD_UNIT = "", PRODUCT_SAFEGUARD_SPL_TYPE = "", PRODUCT_SAPTA_RATE = "", PRODUCT_MRP_YN = "", 
                             PRODUCT_MRP_SL_NO = "", PRODUCT_MRP_AMOUNT = "", PRODUCT_MRP_ABT_RATE = "", PRODUCT_CVD_RATE = "", PRODUCT_CVD_SPL = "", PRODUCT_CVD_UNIT = "", 
                             PRODUCT_CVD_SPL_TYPE = "", PRODUCT_CVD_EDU_CESS_RATE = "", PRODUCT_CVD_SEC_EDU_CESS_RATE = "", PRODUCT_ADDL5_SIA_NOTN = "", 
                             PRODUCT_ADDL5_SIA_NOTN_SL = "", PRODUCT_ADDL5_SIA_RATE = "", PRODUCT_ADDL_GSI_NOTN = "", PRODUCT_ADDL_GSI_SLNO = "", PRODUCT_ADDL_GSI_RATE = "", 
                             PRODUCT_ADDL_GSI_SPL = "", PRODUCT_ADDL_GSI_UNIT = "", PRODUCT_ADDL_GSI_SPL_TYPE = "", PRODUCT_ADDL_SHEII_RATE = "", PRODUCT_ADDL_SHEII_SPL = "", 
                             PRODUCT_ADDL_SHEII_UNIT = "", PRODUCT_ADDL_SHEII_TYPE = "", PRODUCT_ADDL_TTA_NOTN = "", PRODUCT_ADDL_TTA_SLNO = "", PRODUCT_ADDL_TTA_RATE = "", 
                             PRODUCT_ADDL_TTA_SPL = "", PRODUCT_ADDL_TTA_UNIT = "", PRODUCT_ADDL_TTA_TYPE = "", PRODUCT_ADDL_HEALTH_CESS_RATE = "", 
                             PRODUCT_ADDL_HEALTH_CESS_SPL = "", PRODUCT_ADDL_HEALTH_CESS_UNIT = "", PRODUCT_ADDL_HEALTH_CESS_TYPE = "", PRODUCT_CESS_RATE = "", 
                             PRODUCT_CESS_SPL = "", PRODUCT_CESS_UNIT = "", PRODUCT_CESS_TYPE = "", WAREHOUSE_JOBNO = "", WAREHOUSE_INVOICE_SLNO = "", WAREHOUSE_ITEM_SLNO = "", 
                             ASSESSABLE_VALUE = "", DUTY_VALUE = "", CIF_VALUE = "", CVD_VALUE = "", BASIC_VALUE = "", CEC_VALUE = "", CHEC_VALUE = "", ADD_DUTY_VALUE = "", 
                             CETH_CVD_EDU_CESS_SL = "", CETH_CVD_EDU_CESS_RATE = "", CETH_CVD_SEC_EDU_CESS_SL = "", CETH_CVD_SEC_EDU_CESS_RATE = "", 
                             PRODUCT_OTHER_DUTY_RATE = "", PRODUCT_OTHER_DUTY_SPL = "", PRODUCT_OTHER_DUTY_UNIT = "", PRODUCT_OTHER_DUTY_TYPE = "", INDIVITUAL_FREIGHT_AMOUNT = "", 
                             INDIVITUAL_INSURANCE_AMOUNT = "", INDIVITUAL_MISC_AMOUNT = "", 
                             //SVB_RELATION = "", SVB_REF_NO = "", SVB_REF_DATE = "01/01/1900", SVB_CUSTOM_HOUSE = "", SVB_LOADING_ON = "", SVB_ASSESABLE_RATE = "", SVB_DUTY_RATE = "", SVB_ASSESABLE_STATUS = "", SVB_DUTY_STATUS = "",
                             ISVB_RELATION = "", ISVB_REF_NO = "", ISVB_REF_DATE = "", ISVB_CUSTOM_HOUSE = "", ISVB_LOADING_ON = "", ISVB_ASSESABLE_RATE = "", ISVB_DUTY_RATE = "", ISVB_ASSESABLE_STATUS = "", ISVB_DUTY_STATUS = "",
                             INDIVITUAL_EDU_CESS_AMT = "", INDIVITUAL_SEC_HIGHER_CESS_AMT = "", INDIVITUAL_LANDING_CHARGE = "", CHECKLIST_BCD_RATE = "", CHECKLIST_CVD_RATE = "", 
                             CHECKLIST_ADDL_DUTY_RATE = "", INDEV_RACK_TYPE = "", MERIT_DUTY_VALUE = "", RSP_APPLICABLE = "N", MANUFACTURER_PRODUCER = "", M_P_GROWER_CODE = "", 
                             INFRA_CESS_NOTN = "", INFRA_CESS_NOTN_SL = "", INFRA_CESS_NOTN_RATE = "", MERIT_BASIC_VALUE = "", MERIT_CVD_VALUE = "", MERIT_CEC_VALUE = "", 
                             MERIT_CHEC_VALUE = "", MERIT_ADD_DUTY_VALUE = "", MERIT_NOTN_BASIC_VALUE = "", MERIT_NOTN_CVD_VALUE = "", MERIT_NOTN_CEC_VALUE = "", 
                             MERIT_NOTN_CHEC_VALUE = "", MERIT_NOTN_ADD_DUTY_VALUE = "", MERIT_NOTN_CESS_VALUE = "", MERIT_NOTN_NCD_VALUE = "", INDIVITUAL_HSS_AMOUNT = "", 
                             IGST_LEVY_RATE = "", IGST_LEVY_SPL = "", IGST_LEVY_UNIT = "", IGST_LEVY_SPL_TYPE = "", IGST_LEVY_EXCEPTION_RATE = "", IGST_LEVY_COMPENSATION_CESS_RATE = "", 
                             IGST_LEVY_COMPENSATION_CESS_SPL = "", IGST_LEVY_COMPENSATION_CESS_UNIT = "", IGST_LEVY_COMPENSATION_CESS_SPL_TYPE = "", 
                             IGST_LEVY_EXCEPTION_CC_RATE = "",CHECKLIST_IGST_LEVY_AMOUNT = "", CHECKLIST_COMPENSATION_CC_AMOUNT = "",
                             PRODUCT_SEC_EDU_CESS_NOTN = "",RSP_NOTN_NO="",RSP_NOTN_SL_NO="",ANTI_DUMPING_NOTN="",ANTI_DUMPING_NOTN_SLNO="",ADD_EX_RATE="",
                             IINFO_MSR = "", IINFO_UQC = "";

    // Bond Details
    string BONDID = "", BOND_NO = "", BOND_TYPE = "", BOND_LOCATION = "";

    // Certificate Details
    string CERTIFICATEID = "", CERTIFICATE_NO = "", CERTIFICATE_DATE = "", CERTIFICATE_TYPE = "";

    // License Details
    string LICENSE_ID = "", LICENSE_SLNO = "", REGISTRATION_DATE = "", EXCEMPTION = "", DEBIT_AMT = "", DEBIT_QTY = "", UNIT_QTY = "", LICENSE_ITEM_NO = "",
                        PORT_OF_LICENSE = "", DEBIT_DUTY = "", LICENSE_NO = "", LICENSE_DATE = "", TOTAL_CIF_VALUE = "", TOTAL_DEBIT_DUTY = "", ENTRY_DEBIT_DUTY = "", LIC_DESC = "",
                        CURRENCY = "",EXRATE= "";

    // Supporting Documents
    string IMAGE_REF_NUMBER = "", DOC_TYPE_CODE = "", DOC_ISSUING_PARTY_CODE = "", DOC_ISSUING_PARTY_NAME = "", DOC_ISSUING_PARTY_NAME_ADD1 = "", DOC_ISSUING_PARTY_NAME_ADD2 = "",
                             DOC_ISSUING_PARTY_CITY = "", DOC_ISSUING_PARTY_PIN = "", DOC_REF_NUMBER = "", PLACE_OF_ISSUE = "", DOC_ISSUE_DATE = "", DOC_EXPIRY_DATE = "", BENEFICIARY_PARTY_CODE = "", BENEFICIARY_PARTY_NAME = "", BENEFICIARY_PARTY_ADDRESS1 = "",
                             BENEFICIARY_PARTY_ADDRESS2 = "", BENEFICIARY_PARTY_CITY = "", BENEFICIARY_PARTY_PIN = "", DOC_TYPE = "", ICEGATE_ID = "",FILE_TYPE="",ICEGATE_DOC_FILE_NAME="";

    // Shared audit fields
    public string USER_ID = "", STATUS = "", BRANCH_CODE = "", YEAR = "", WORKING_PERIOD = "";

    public string error = "";
    private SqlConnection con;



    public string jobBulkValue = "";
    private string flag;
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);


    string alert = "";
    string Mnufactre_alert = "", GeneralDesc_Alert = "";

    List<string> selectedNode = new List<string>();
    

    DataSet ds = new DataSet();
    //DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt_Avail = new DataTable();
    DataTable selected;
    DataTable VALID = new DataTable();
    Transaction RE_IMP = new Transaction();
    Re_Import_XL_Upload RE_IMP_OBJ = new Re_Import_XL_Upload();
    Import_XL_Upload Imp_XL = new Import_XL_Upload();

    UserBO ObjUBO = new UserBO();
    SW_Support_Docs Sup_Doc = new SW_Support_Docs();

    DataTable allErrors = new DataTable();

    private bool supDocHasErrors = false;
    //DataTable selectedSupDoc = new DataTable();
    DataTable textSupDoc = new DataTable();


    public string errorSheetandTableName;

    private string[] result;

    Global_variables ObjGV = new Global_variables();
    Client_Master_New_cs CM = new Client_Master_New_cs();

    DataSet ds_TP = new DataSet();
    DataSet dsBkp = new DataSet();

    private bool DisableFeature = false;


    List<ListItem> beTypeList = new List<ListItem>
    {
        new ListItem("Home"),new ListItem("Warehouse"),new ListItem("Ex-Bond"),new ListItem("SEZ FTA-Z"),new ListItem("SEZ DTA-T"),new ListItem("SEZ DTA-M"),
        new ListItem("Jobbing"),new ListItem("Repair & Return"),new ListItem("Exhibition"),new ListItem("Destruction"),new ListItem("Movement of Goods"),new ListItem("Stock Item")
    };
    List<ListItem> transModeList = new List<ListItem>
    {
        new ListItem("Air"),new ListItem("Sea"),new ListItem("Sea")
    };
    List<ListItem> conTypeList = new List<ListItem>
    {
        new ListItem("LCL"),new ListItem("FCL"),new ListItem("Bulk")
    };
    List<ListItem> filingStatusList = new List<ListItem>
    {
        new ListItem("Normal"),new ListItem("Prior"),new ListItem("Advanced")
    };
    List<ListItem> itemSVBList = new List<ListItem>
    {
        new ListItem("Assessable"),new ListItem("Duty"),new ListItem("ExBothBond")
    };


    private string generalTransportMode = string.Empty;

    //==============================================================================
    #endregion Declaration

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DisableFeature)
        {
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            COMPANY_IDD = Session["COMPANY_ID"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            LoginDate = Session["LoginDate"].ToString();
            hdfTransport_mode.Value = Session["Transport_Mode_Port"].ToString();

            if (Session["Jobno_Excel"] != null)
            {
                IMPORT_JOBNO = Session["Jobno_Excel"].ToString();
                lbl_JobNo.Text = "Job - " + IMPORT_JOBNO;
            }

            SELECT_BRANCH = Connection.Get_Company_Type();

            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Import_Excel");

            TreeView1.Nodes.Clear();
            populateTreeNode();
            TreeView1.Attributes.Add("onclick", "OnTreeClick(event)");


            if (!string.IsNullOrEmpty(Session["JobBulk"] as string))
            {
                jobBulkValue = Session["JobBulk"].ToString();
                if (jobBulkValue == "New")
                {
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    flag = "S";
                }
                else
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    flag = "U";
                }
            }

            gv_Item_Details.DataSource = null;
            gv_Item_Details.DataBind();

            ApplyGridTheme();
        }
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "closePopup", @"jAlert('Coming soon! We’re putting the finishing touches on this feature.',' Pardon our digital dust!🧹',function(){parent.location.reload();parent.dhtmlmodal.close();});", true);
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "closePopup", @"jAlert('Coming soon! We are putting the finishing touches on this feature.','Pardon our digital dust!', function(){parent.location.reload();parent.dhtmlmodal.close();} );",  true);
        }
    }

    protected void populateTreeNode()
    {
        TreeView1.Nodes.Clear();

        var data = new[]
        {
            new { id = 1,  Text="GENERAL DETAILS", Value = "GENERAL_DETAILS" },
            new { id = 2,  Text="IGM DETAILS", Value = "IGM_DETAILS" },
            new { id = 3,  Text="CONTAINER DETAILS", Value = "CONTAINER_DETAILS" },
            new { id = 4, Text="BOND", Value = "BOND_DETAILS" },
            new { id = 5, Text="CERTIFICATE", Value = "CERTIFICATE_DETAILS" },
            new { id = 6,  Text="INVOICE DETAILS", Value = "INVOICE_DETAILS" },
            new { id = 7,  Text="ITEM PRODUCT DETAILS", Value = "ITEM_PRODUCT_DETAILS" },
            new { id = 8,  Text="RE IMPORT", Value = "RE_IMPORT_DETAILS" },
            new { id = 9, Text="LICENSE DETAILS", Value = "LICENSE_DETAILS" },
            new { id = 10,  Text="SW INFO TYPE", Value = "BE_ITEM_SW_INFO_TYPE" },
            new { id = 11,  Text="SW CONST", Value = "BE_ITEM_SW_CONST" },
            new { id = 12,  Text="SW PROD", Value = "BE_ITEM_SW_PROD" },
            new { id = 13, Text="SW CONTROL", Value = "BE_ITEM_SW_CONTROL" },
            new { id = 14, Text="SW SUP DOCS", Value = "BE_ITEM_SW_SUP_DOC" }
        }; 

        #region OLD
        /* var data = new[]
        {
            new { id = 1,  Text="GENERAL DETAILS", Value = "GENERAL_DETAILS" },
            new { id = 2,  Text="IGM DETAILS", Value = "IGM_DETAILS" },
            new { id = 3,  Text="CONTAINER DETAILS", Value = "CONTAINER_DETAILS" },
            new { id = 4,  Text="INVOICE DETAILS", Value = "INVOICE_DETAILS" },
            new { id = 5,  Text="ITEM PRODUCT DETAILS", Value = "ITEM_PRODUCT_DETAILS" },
            new { id = 6,  Text="RE IMPORT", Value = "RE_IMPORT_DETAILS" },
            new { id = 7,  Text="SW INFO TYPE", Value = "BE_ITEM_SW_INFO_TYPE" },
            new { id = 8,  Text="SW CONST", Value = "BE_ITEM_SW_CONST" },
            new { id = 9,  Text="SW PROD", Value = "BE_ITEM_SW_PROD" },
            new { id = 10, Text="SW CONTROL", Value = "BE_ITEM_SW_CONTROL" },
            new { id = 11, Text="LICENSE DETAILS", Value = "LICENSE_DETAILS" },
            new { id = 12, Text="BOND", Value = "BOND_DETAILS" },
            new { id = 13, Text="CERTIFICATE", Value = "CERTIFICATE_DETAILS" },
            new { id = 14, Text="SW SUP DOCS", Value = "BE_ITEM_SW_SUP_DOC" }
        }; */
        #endregion

        // 🔹 Parent Node
        TreeNode root = new TreeNode("Select ALL", "0");

        foreach (var item in data)
        {
            TreeNode node = new TreeNode(item.Text, item.id.ToString());
            root.ChildNodes.Add(node);
        }

        TreeView1.Nodes.Add(root);
        TreeView1.ExpandAll();
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

    public void DownloadExel(DataSet dsExcelData)
    {
        #region multiple sheets excel download
        
            ThemeClass th = new ThemeClass();
            HttpResponse Response = HttpContext.Current.Response;
            BMW_Excel BMW = new BMW_Excel();
            //DataSet dss = Get_Job_Data(IMPORT_JOBNO, currentbranch, "Select Import Job Data");
            if (dsExcelData != null && dsExcelData.Tables.Count > 0 && dsExcelData.Tables[0].Rows.Count > 0)
            {
                string s = DateTime.Now.ToString("yyyyMMdd");
                string strrptNametime = "JobNo_" + IMPORT_JOBNO + "_" + s;

                byte[] excelBytes = null;
                using (XLWorkbook wb = new XLWorkbook())
                {
                    foreach (DataTable table in dsExcelData.Tables)
                    {
                        string sheetLabel = SheetName(table.TableName);
                        DataTable textTable = ConvertAllColumnsToText(table);
                        IXLWorksheet worksheet = wb.AddWorksheet(sheetLabel);

                        // 1. THE FIX: Loop through every column and force all 1 million+ rows to be Text format "@"
                        // Do this BEFORE inserting your data matrix
                        for (int colIndex = 1; colIndex <= textTable.Columns.Count; colIndex++)
                        {
                            // "@" is the explicit underlying Excel identifier for Text String Format
                            worksheet.Column(colIndex).Style.NumberFormat.SetFormat("@");
                        }

                        // ── InsertDataAsText handles all styling internally ───────────────────────
                        InsertDataAsText(worksheet, textTable);

                        // ── Remove borders on worksheet level ─────────────────────────────────────
                        worksheet.Style.Border.SetTopBorder(XLBorderStyleValues.None);
                        worksheet.Style.Border.SetLeftBorder(XLBorderStyleValues.None);
                        worksheet.Style.Border.SetRightBorder(XLBorderStyleValues.None);
                        worksheet.Style.Border.SetBottomBorder(XLBorderStyleValues.None);

                        // ── REMOVE these lines — now handled inside InsertDataAsText ─────────────
                        // worksheet.Row(1).Style.Font.Bold = true;          ← remove
                        // worksheet.Row(1).Style.Font.FontColor = ...;      ← remove
                        // worksheet.Columns().AdjustToContents();           ← remove
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        wb.SaveAs(ms);
                        excelBytes = ms.ToArray();
                    }
                }

                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.ContentType =
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition",
                    "attachment;filename=" + strrptNametime + ".xlsx");
                Response.AddHeader("content-length",
                    excelBytes.Length.ToString());
                Response.BinaryWrite(excelBytes);
                Response.Flush();
                HttpContext.Current.ApplicationInstance.Response.End();
            }
            else
            {
                Alert_msg("No data found.");
            }
            
        #endregion
    }
    protected void btn_Download_Click(object sender, EventArgs e)
    {
        try
        {
            btn_JobDownload.Enabled = false;
            DataSet dss = Get_Job_Data(IMPORT_JOBNO, currentbranch, "Select Import Job Data");
            DownloadExel(dss);

            #region  old - multiple sheets excel download Old before IRN - 1.234567E+15 issue

            /*
            ThemeClass th = new ThemeClass();
            HttpResponse Response = HttpContext.Current.Response;
            BMW_Excel BMW = new BMW_Excel();

            DataSet dss = Get_Job_Data(IMPORT_JOBNO, currentbranch, "Select Import Job Data");

            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                string s = DateTime.Now.ToString("yyyyMMdd");
                string strrptNametime = "JobNo_" + IMPORT_JOBNO + "_" + s;

                // ── Step 1: Build Excel entirely in memory FIRST ──────────
                byte[] excelBytes = null;

                using (XLWorkbook wb = new XLWorkbook())
                {
                    foreach (DataTable table in dss.Tables)
                    {
                        string sheetLabel = SheetName(table.TableName);

                        DataTable textTable = ConvertAllColumnsToText(table);

                        IXLWorksheet worksheet = wb.AddWorksheet(sheetLabel);
                        worksheet.Cell(1, 1).InsertTable(textTable);                        
                        // ── Force text format on entire used range ────────────────────────
                        IXLRange dataRange = worksheet.RangeUsed();
                        if (dataRange != null)
                        {
                            dataRange.Style.NumberFormat.Format = "@";
                        }

                        // Header row styling
                        worksheet.Row(1).Style.Font.Bold = true;
                        worksheet.Row(1).Style.Font.FontColor = XLColor.Black;

                        // Remove borders
                        worksheet.Style.Border.SetTopBorder(XLBorderStyleValues.None);
                        worksheet.Style.Border.SetLeftBorder(XLBorderStyleValues.None);
                        worksheet.Style.Border.SetRightBorder(XLBorderStyleValues.None);
                        worksheet.Style.Border.SetBottomBorder(XLBorderStyleValues.None);

                        // Auto-fit columns
                        worksheet.Columns().AdjustToContents();

                        // Hide autofilter
                        var tbl = worksheet.Tables.FirstOrDefault();
                        if (tbl != null)
                            tbl.ShowAutoFilter = false;
                    }                    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        wb.SaveAs(ms);
                        excelBytes = ms.ToArray(); 
                    }
                }

                // ── Step 3: Clear response — AFTER workbook is built ──────
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();

                // ── Step 4: Write clean binary response ───────────────────
                Response.ContentType =
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition",
                    "attachment;filename=" + strrptNametime + ".xlsx");
                Response.AddHeader("content-length",
                    excelBytes.Length.ToString());  // tells browser exact size

                Response.BinaryWrite(excelBytes);   // single clean write
                Response.Flush();

                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Alert_msg("No data found.");
            }
            */

            #endregion   

            #region multiple sheets excel download
            /*
            ThemeClass th = new ThemeClass();
            HttpResponse Response = HttpContext.Current.Response;
            BMW_Excel BMW = new BMW_Excel();
            DataSet dss = Get_Job_Data(IMPORT_JOBNO, currentbranch, "Select Import Job Data");
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                string s = DateTime.Now.ToString("yyyyMMdd");
                string strrptNametime = "JobNo_" + IMPORT_JOBNO + "_" + s;

                byte[] excelBytes = null;
                using (XLWorkbook wb = new XLWorkbook())
                {
                    foreach (DataTable table in dss.Tables)
                    {
                        string sheetLabel = SheetName(table.TableName);
                        DataTable textTable = ConvertAllColumnsToText(table);
                        IXLWorksheet worksheet = wb.AddWorksheet(sheetLabel);

                        // 1. THE FIX: Loop through every column and force all 1 million+ rows to be Text format "@"
                        // Do this BEFORE inserting your data matrix
                        for (int colIndex = 1; colIndex <= textTable.Columns.Count; colIndex++)
                        {
                            // "@" is the explicit underlying Excel identifier for Text String Format
                            worksheet.Column(colIndex).Style.NumberFormat.SetFormat("@");
                        }

                        // ── InsertDataAsText handles all styling internally ───────────────────────
                        InsertDataAsText(worksheet, textTable);

                        // ── Remove borders on worksheet level ─────────────────────────────────────
                        worksheet.Style.Border.SetTopBorder(XLBorderStyleValues.None);
                        worksheet.Style.Border.SetLeftBorder(XLBorderStyleValues.None);
                        worksheet.Style.Border.SetRightBorder(XLBorderStyleValues.None);
                        worksheet.Style.Border.SetBottomBorder(XLBorderStyleValues.None);

                        // ── REMOVE these lines — now handled inside InsertDataAsText ─────────────
                        // worksheet.Row(1).Style.Font.Bold = true;          ← remove
                        // worksheet.Row(1).Style.Font.FontColor = ...;      ← remove
                        // worksheet.Columns().AdjustToContents();           ← remove
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        wb.SaveAs(ms);
                        excelBytes = ms.ToArray();
                    }
                }

                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.ContentType =
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition",
                    "attachment;filename=" + strrptNametime + ".xlsx");
                Response.AddHeader("content-length",
                    excelBytes.Length.ToString());
                Response.BinaryWrite(excelBytes);
                Response.Flush();
                HttpContext.Current.ApplicationInstance.Response.End();
            }
            else
            {
                Alert_msg("No data found.");
            }
            */
            #endregion

            btn_JobDownload.Enabled = true;
            
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            Alert_msg("Download Failed");
            btn_JobDownload.Enabled = true;
        }
    }

    public DataSet Get_Job_Data(string jobNo, string branchCode, string operation)
    {
        DataSet ds = new DataSet();

        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@JOBNO", jobNo);
        param[1] = new SqlParameter("@BRANCHCODE", branchCode);
        param[2] = new SqlParameter("@Operation", operation);
        param[3] = new SqlParameter("@Table", "");
        param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[4].Direction = ParameterDirection.Output;
        param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[5].Direction = ParameterDirection.Output;

        ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_JOB_ALLDATA", param);
               
        return ds;
    }

    public string SheetName(string tableName)
    {
        #region DELETED
        /*Dictionary<string, string> sheetMap = new Dictionary<string, string>()
          {
              { "Table",   "GENERAL"            },
              { "Table1",  "IGM"        },
              { "Table2",  "CONTAINER"          },
              { "Table3",  "INVOICE"            },
              { "Table4",  "ITEMS"              },
              { "Table5",  "RE_IMPORT"          },
              { "Table6",  "SW_INFO_TYPE"       },
              { "Table7",  "SW_CONSTITUENT"     },
              { "Table8",  "SW_PRODUCTION"      },
              { "Table9",  "SW_CONTROL"         },
              { "Table10", "LICENSE"            },
              { "Table11", "BONDS"              },
              { "Table12", "CERTIFICATES"       },
              { "Table13", "SUPPORTING_DOCS"    },
          };*/
        #endregion

        Dictionary<string, string> sheetMap = new Dictionary<string, string>()
            {
                { "Table",   "GENERAL"            },
                { "Table1",  "IGM"                },
                { "Table2",  "CONTAINER"          },
                { "Table3",  "BONDS"              },
                { "Table4",  "CERTIFICATES"       },
                { "Table5",  "INVOICE"            },
                { "Table6",  "ITEMS"              },
                { "Table7",  "RE_IMPORT"          },
                { "Table8",  "LICENSE"            }, 
                { "Table9",  "SW_INFO_TYPE"       },
                { "Table10", "SW_CONSTITUENT"     },
                { "Table11", "SW_PRODUCTION"      },
                { "Table12", "SW_CONTROL"         },                
                { "Table13", "SUPPORTING_DOCS"    },
            };
        string sheetName;
        sheetMap.TryGetValue(tableName, out sheetName);
        return sheetName;        
    }    

    private DataTable ConvertAllColumnsToText(DataTable source)
    {
        DataTable textTable = new DataTable(source.TableName);
        
        foreach (DataColumn col in source.Columns)
            textTable.Columns.Add(col.ColumnName, typeof(string));
       
        foreach (DataRow sourceRow in source.Rows)
        {
            DataRow newRow = textTable.NewRow();
            foreach (DataColumn col in source.Columns)
            {
                newRow[col.ColumnName] = sourceRow[col] == DBNull.Value
                    ? string.Empty : sourceRow[col].ToString();
            }
            textTable.Rows.Add(newRow);
        }
        return textTable;
    }

    private void InsertDataAsText(IXLWorksheet worksheet, DataTable textTable)
    {
        int totalCols = textTable.Columns.Count;
        int totalRows = textTable.Rows.Count;

        // ── Pre-format entire range as text BEFORE writing values ────────────────
        IXLRange fullRange = worksheet.Range(1, 1, totalRows + 1, totalCols);
        fullRange.Style.NumberFormat.Format = "@";

        // ── Write header row ──────────────────────────────────────────────────────
        for (int col = 0; col < totalCols; col++)
        {
            var cell = worksheet.Cell(1, col + 1);
            cell.Value = textTable.Columns[col].ColumnName;

            // ── Blue header styling ───────────────────────────────────────────────
            cell.Style.Font.Bold = true;
            cell.Style.Font.FontColor = XLColor.White;
            cell.Style.Fill.BackgroundColor = XLColor.FromArgb(68, 114, 196); // Excel blue
            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.BottomBorderColor = XLColor.White;
        }

        // ── Write data rows ───────────────────────────────────────────────────────
        for (int row = 0; row < totalRows; row++)
        {
            for (int col = 0; col < totalCols; col++)
            {
                var cell = worksheet.Cell(row + 2, col + 1);
                cell.Value = textTable.Rows[row][col].ToString();

                //// ── Alternate row color for readability ───────────────────────────
                //if (row % 2 == 0)
                //{
                //    cell.Style.Fill.BackgroundColor = XLColor.FromArgb(221, 235, 247); // light blue
                //}
            }
        }

        // ── Auto-fit columns ──────────────────────────────────────────────────────
        worksheet.Columns().AdjustToContents();
    }

    protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        if (e.Node.Value != "0")
        {
            if (e.Node.Checked == true)
            {
                selectedNode.Add(e.Node.Text);                
            };
        }        
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gv_Item_Details.DataSource = null;
            gv_Item_Details.DataBind();

            PrepareErrorFolderAndRead();

            #region Deleted
            /*
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Read_from_Excel();
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                dir.Create();
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Read_from_Excel();
            } */
            

            //if (Result == 1)
            //{
            //    Result = 0; //Alert_msg("Excel Uploaded Successfully.");

            //    //ScriptManager.RegisterStartupScript(this,GetType(),"closePopup","jAlert('Excel Uploaded Successfully.','Success', function(){ RefreshParent(); });", true);
            //    ScriptManager.RegisterStartupScript(UpdatePanel1,UpdatePanel1.GetType(),"closePopup",@"jAlert('Excel Uploaded Successfully.','Success',function(){parent.location.reload();parent.dhtmlmodal.close();});",true);               
            //}

            #endregion
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            if (Session["JOBIDexcel"] != null)
            {
                Session.Remove("JOBIDexcel");
            }
            //RollBackSelectedNodes(result); 
            ManualRollBack();
            Alert_msg("Upload Failed");
        }

    }

    private void PrepareErrorFolderAndRead()
    {
        DirectoryInfo dir = new DirectoryInfo(errorFolder);
        if (!dir.Exists) dir.Create();                        // create if missing
        foreach (FileInfo fi in dir.GetFiles()) fi.Delete();  // clear old files
        Read_from_Excel();
    }

    public void Read_from_ExcelOld()
    {       

        #region Mapping selected node to excel sheet and reading into DataSet

        var map = new Dictionary<string, string>
                  {
                      { "GENERAL DETAILS", "GENERAL" },
                      { "IGM DETAILS", "IGM" },
                      { "CONTAINER DETAILS", "CONTAINER" },
                      { "INVOICE DETAILS", "INVOICE" },
                      { "ITEM PRODUCT DETAILS", "ITEMS" },
                      { "RE IMPORT", "RE_IMPORT" },
                      { "SW INFO TYPE", "SW_INFO_TYPE" },
                      { "SW CONST", "SW_CONSTITUENT" },
                      { "SW PROD", "SW_PRODUCTION" },
                      { "SW CONTROL", "SW_CONTROL" },
                      { "LICENSE DETAILS", "LICENSE" },
                      { "BOND", "BONDS" },
                      { "CERTIFICATE", "CERTIFICATES" },
                      { "SW SUP DOCS", "SUPPORTING_DOCS" }
                  };

        //string[] result = selectedNode.Select(x => map.ContainsKey(x) ? map[x] : x).ToArray();
        result = selectedNode.Select(x => map.ContainsKey(x) ? map[x] : x).ToArray();

        if (flag == "S" && !result.Contains("GENERAL"))
        {
            Alert_msg("To create a job you must upload General Details first");
            return;
        }

        #endregion Mapping selected node to excel sheet

        //DataSet ds = new DataSet();

        #region Read from excel and Verify Sheet has value

        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadExcel.FileName;

        //string strGID;
        string picExtension;
        string fileName2 = "";

        if (fileuploadExcel.HasFile)
        {
            picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
            fileName2 = fileuploadExcel.FileName;
            addtoGallery(fileName2, errorFolder, "NORMAL");
        }


        if (strFileType.Trim().ToLower() == ".xls")
        {
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                         "Data Source=" + path + ";" +
                         "Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        }
        else if (strFileType.Trim().ToLower() == ".xlsx")
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                         "Data Source=" + path + ";" +
                         "Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=1\"";
        }
        else
        {
            Alert_msg("Unsupported file type: " + strFileType +
                      ". Please upload .xls or .xlsx only.");
            return;
        }

        List<string> emptySheets = new List<string>();

        foreach (var sheetName in result)
        {
            using (OleDbConnection con = new OleDbConnection(connString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DataTable dataTable = new DataTable();
                dataTable.TableName = sheetName;
                new OleDbDataAdapter(string.Format("SELECT * FROM [{0}$]", sheetName), con).Fill(dataTable);

                // Remove empty rows
                for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
                {
                    bool isEmpty = true;
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        if (!string.IsNullOrWhiteSpace(dataTable.Rows[i][col].ToString()))
                        {
                            isEmpty = false;
                            break;
                        }
                    }
                    if (isEmpty) dataTable.Rows.RemoveAt(i);
                }
                dataTable.AcceptChanges();

                if (dataTable.Rows.Count == 0)
                    emptySheets.Add(sheetName);  // collect — don't return yet
                else
                    data.Tables.Add(dataTable);
            }
        }

        

        #endregion

        #region Change column names equal to db column name to validate

        if (data.Tables.Contains("GENERAL"))
        {
            DataTable dtG = data.Tables["GENERAL"];           
            
            dtG.Columns["CUSTOM_HOUSE_CODE"].ColumnName = "CUSTOMS_HOUSE";
            dtG.Columns["ICEGATEID"].ColumnName = "ICE_ID";
            dtG.Columns["BRANCH_SL_NO"].ColumnName = "BRANCH_NO";
            dtG.Columns["COUNTRY_OF_ORIGIN"].ColumnName = "COUNTRY_ORIGIN";
            dtG.Columns["COUNTRY_OF_SHIPMENT"].ColumnName = "COUNTRY_SHIPMENT";
            dtG.Columns["PORT_OF_ORIGIN"].ColumnName = "PORT_ORIGIN";
            dtG.Columns["PORT_OF_SHIPMENT"].ColumnName = "PORT_SHIPMENT";
            dtG.Columns["COMMERCIAL_TAX_DETAILS"].ColumnName = "COMMERCIAL_DETAILS_STATUS";
            dtG.Columns["STATE_NAME"].ColumnName = "COMMERCIAL_TAX_STATENAME";
            dtG.Columns["STATE_CODE"].ColumnName = "COMMERCIAL_TAX_STATECODE";
            dtG.Columns["REGISTRATION_NO"].ColumnName = "COMMERCIAL_TAX_REGISTRATION_NO";
            dtG.Columns["GSTN_TYPE"].ColumnName = "COMMERCIAL_TAX_TYPE";
            dtG.Columns["SELLER_NAME"].ColumnName = "HIGH_SEA_SALE_NAME";
            dtG.Columns["HSS_IEC_NO"].ColumnName = "HIGH_SEA_IEC";
            dtG.Columns["BR_SL_NO"].ColumnName = "HIGH_SEA_BRANCH_SL_NO";
            dtG.Columns["PAYMENT_METHOD"].ColumnName = "PAYMENT_METHOD_CODE";
        }

        if (data.Tables.Contains("IGM"))
        {
            DataTable dtG = data.Tables["IGM"];
            
            dtG.Columns["AIRLINENAME"].ColumnName = "IGM_AIRLINENAME";
            dtG.Columns["AIRLINECODE"].ColumnName = "IGM_AIRLINECODE";
            dtG.Columns["FLIGHT_INWARD_DATE"].ColumnName = "IGM_FLIGHT_VESSELDATE";
            dtG.Columns["MAWB_MBL_NO"].ColumnName = "IGM_MAWB_MBL";
            dtG.Columns["MAWB_MBL_DATE"].ColumnName = "IGM_MAWB_MBLDATE";
            dtG.Columns["HAWB_HBL_NO"].ColumnName = "IGM_HAWB_HBLNO";
            dtG.Columns["HAWB_HBL_DATE"].ColumnName = "IGM_HAWB_HBLDATE";
            dtG.Columns["LINE_NUMBER"].ColumnName = "IGM_LINE_NUMBER";
            dtG.Columns["SHIPPING_LINE"].ColumnName = "IGM_SHIPPING_LINE_NUMBER";            
            dtG.Columns["PACKAGES"].ColumnName = "IGM_NOOFPACKAGE";
            dtG.Columns["PACKAGE_TYPE"].ColumnName = "IGM_PACKAGETYPE";
            dtG.Columns["GROSS_WEIGHT"].ColumnName = "IGM_GROSSWEIGHT";
            dtG.Columns["GROSS_WEIGHT_TYPE"].ColumnName = "IGM_TYPEOFWEIGHT";
            dtG.Columns["MARKS_NOS"].ColumnName = "IGM_MARKSNOS";
            dtG.Columns["VOYAGE"].ColumnName = "IGM_VOYAGE";
            dtG.Columns["GATEWAY_IGM_NO"].ColumnName = "IGM_GATEWAY_IGM_NO";
            dtG.Columns["GATEWAY_IGM_DATE"].ColumnName = "IGM_GATEWAY_IGM_DATE";
            dtG.Columns["GATEWAY_PORT_CODE"].ColumnName = "IGM_GATEWAY_PORT_CODE";
            dtG.Columns["CHARGEABLE_WGT"].ColumnName = "IGM_CHARGEABLE_WGT";
        }

        if (data.Tables.Contains("CONTAINER"))
        {
            DataTable dtG = data.Tables["CONTAINER"];
            
            dtG.Columns["SLNO"].ColumnName = "CONTAINER_IGM_SLNO";            
        }

        if (data.Tables.Contains("INVOICE"))
        {
            DataTable dtG = data.Tables["INVOICE"];
            
            dtG.Columns["HANDLING_CHARGES"].ColumnName = "D_AMOUNT";
            dtG.Columns["LOADING_CHARGES"].ColumnName = "M_AMOUNT";
            dtG.Columns["UNLOADING_CHARGES"].ColumnName = "N_AMOUNT";            
            dtG.Columns["AEO_CODE"].ColumnName = "AUTHORIZED_ECONOMIC_OPERATOR_CODE";
            dtG.Columns["AUTH_ECO_OPERATOR"].ColumnName = "AUTHORIZED_ECONOMIC_OPERATOR";
            dtG.Columns["BUYER_SELLER_RELATED Y/N"].ColumnName = "WHETHER_BUYER_SELLER_RELATED";            
        }

        if (data.Tables.Contains("ITEMS"))
        {
            DataTable dtG = data.Tables["ITEMS"];
            
            dtG.Columns["RITC_NO"].ColumnName = "PRODUCT_RITC";
            dtG.Columns["CETH_NO"].ColumnName = "PRODUCT_CETH";
            dtG.Columns["BASIC_DUTY_NOTIFICATION"].ColumnName = "PRODUCT_BCD_NOTN";
            dtG.Columns["BASIC_DUTY_SLNO"].ColumnName = "PRODUCT_BCD_SLNO";
            dtG.Columns["ADD_DUTY_OF_EXCISE_SIA_NOTN"].ColumnName = "PRODUCT_ADDL_GSI_NOTN";
            dtG.Columns["ADD_DUTY_OF_EXCISE_SIA_SLNO"].ColumnName = "PRODUCT_ADDL_GSI_SLNO";
            dtG.Columns["SPL_EX_DUTY_SHED11_NOTN"].ColumnName = "PRODUCT_ADDL_SHEII_NOTN";
            dtG.Columns["SPL_EX_DUTY_SHED11_SLNO"].ColumnName = "PRODUCT_ADDL_SHEII_SLNO";
            dtG.Columns["ADD_DUTY_OF_EXCISE_TTA_NOTN"].ColumnName = "PRODUCT_ADDL_TTA_NOTN";
            dtG.Columns["ADD_DUTY_OF_EXCISE_TTA_SLNO"].ColumnName = "PRODUCT_ADDL_TTA_SLNO";
            dtG.Columns["HEALTH_CESS_NOTN"].ColumnName = "PRODUCT_ADDL_HEALTH_CESS_NOTN";
            dtG.Columns["HEALTH_CESS_SLNO"].ColumnName = "PRODUCT_ADDL_HEALTH_CESS_SLNO";
            dtG.Columns["EXCEPTION_NOTN"].ColumnName = "IGST_LEVY_EXCEPTION_NOTN";
            dtG.Columns["EXCEPTION_SLNO"].ColumnName = "IGST_LEVY_EXCEPTION_SLNO";
            dtG.Columns["EXCEMPTION_NOTN_TYPE"].ColumnName = "LEVY_EXCEMPTION_NOTN_TYPE";
            dtG.Columns["COMPENSATION_CESS_NOTN"].ColumnName = "IGST_LEVY_COMPENSATION_CESS_NOTN";
            dtG.Columns["COMPENSATION_CESS_SLNO"].ColumnName = "IGST_LEVY_COMPENSATION_CESS_SLNO";
            dtG.Columns["EXCEPTION_CC_NOTN"].ColumnName = "IGST_LEVY_EXCEPTION_CC_NOTN";
            dtG.Columns["EXCEPTION_CC_SLNO"].ColumnName = "IGST_LEVY_EXCEPTION_CC_SLNO";
            dtG.Columns["EXCEPTION_CC_NOTN_TYPE"].ColumnName = "LEVY_EXCEPTION_CC_NOTN_TYPE";
        }               

        #endregion

        

        #region Validation

        // After all sheets processed — throw one combined error
        if (emptySheets.Count > 0)
        {
            string sheetList = string.Join("\\n", emptySheets.ToArray());
            Alert_msg("Following sheets have no data:\\n" + sheetList);
            return;
        }

        Session["BulkJobUploadData"] = data;

        #region IMPORTER and SUPPLIER verification 

        string iecNo = data.Tables["GENERAL"].Rows.Count > 0 ? data.Tables["GENERAL"].Rows[0]["IEC_NO"].ToString() : "";
        string branchSLNo = data.Tables["GENERAL"].Rows.Count > 0 ? data.Tables["GENERAL"].Rows[0]["BRANCH_NO"].ToString() : "";      

        if (!string.IsNullOrWhiteSpace(iecNo) && !string.IsNullOrWhiteSpace(branchSLNo))
        {
            dsImp = Get_Importer_HSS_Details(iecNo, branchSLNo);
            if (dsImp == null || dsImp.Tables.Count == 0 || dsImp.Tables[0] == null || dsImp.Tables[0].Rows.Count == 0)
            {
                lblUser_Msg.Text = "Importer does not exist in the Master. Do you want to add it?";
                MP_U.Show(); 
                return;
            }
        }

        string hss_iec = data.Tables["GENERAL"].Rows.Count > 0 ? data.Tables["GENERAL"].Rows[0]["HIGH_SEA_IEC"].ToString() : "";
        string hss_branchSLNo = data.Tables["GENERAL"].Rows.Count > 0 ? data.Tables["GENERAL"].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString() : "";

        if (!string.IsNullOrWhiteSpace(hss_iec) && !string.IsNullOrWhiteSpace(hss_branchSLNo))
        {
            ds_IEC = Get_Importer_HSS_Details(hss_iec, hss_branchSLNo);
            if (ds_IEC == null || ds_IEC.Tables.Count == 0 || ds_IEC.Tables[0] == null || ds_IEC.Tables[0].Rows.Count == 0)
            {
                lblUser_Msg.Text = "Supplier does not exist in the Master. Do you want to add it?";
                MP_U.Show();
                return;
                //MP_U.Hide();
            }
        }
               

        #endregion

        // Checks Date format / Length / Mandatory / checks if empty / Special chars / Single quote
        int status = ValidateAll(data);

        #endregion Validation
        

            #region mapping Sheet name to method

            var tableActions = new Dictionary<string, Action<DataTable>>
                              {
                                  { "GENERAL", dt => Read_General_Details(dt) },
                                  { "IGM", dt => Read_IGM_Details(dt) },
                                  { "CONTAINER", dt => Read_Container_Details(dt) },
                                  { "INVOICE", dt => Read_Invoice_Details(dt) },
                                  { "ITEMS", dt => Read_Item_Details(dt) },
                                  { "RE_IMPORT", dt => Read_Reimport_Details(dt)},
                                  { "SW_INFO_TYPE", dt => Read_SW_Info(dt) },
                                  { "SW_CONSTITUENT", dt => Read_SW_Constituent(dt) },
                                  { "SW_PRODUCTION", dt => Read_SW_Production(dt) },
                                  { "SW_CONTROL", dt => Read_SW_Control(dt) },
                                  { "LICENSE", dt => Read_License_Details(dt) },
                                  { "BONDS", dt => Read_Bond_Details(dt) },
                                  { "CERTIFICATES", dt => Read_Certificate_Details(dt) },
                                  { "SUPPORTING_DOCS", dt => Read_Suporting_Documents_Details(dt) }
                              };

            DataSet excelDS = data.Copy();
            foreach (DataTable table in excelDS.Tables)
            {
                if (tableActions.ContainsKey(table.TableName))
                {
                    var rows = table.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field == DBNull.Value));
                    if (rows.Any())
                    {
                        DataTable dtFinal = rows.CopyToDataTable();
                        if (dtFinal.Rows.Count > 0)
                        {
                            tableActions[table.TableName](dtFinal);
                        }
                    }
                }
            }
            excelDS.Dispose();
            excelDS = null;

            #endregion

            if (allErrors.Rows.Count > 0)
            {
                gv_Item_Details.DataSource = allErrors;
                gv_Item_Details.DataBind();
                //if (flag == "S") { RollBackSelectedNodes(selectedNode);/*ManualRollBack();*/ }
                RollBackSelectedNodes(result);
                allErrors = new DataTable();
                Result = 0;
            }
            else
            {
                SqlBulkUpload_Job(data);
                allErrors = new DataTable();
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

    public void addtoGallery(string picName, string folderName, string Excel_Name)
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

    public void btnyes_ClickOld(object sender, EventArgs e)
    {
        DataSet dsa = Session["BulkJobUpload"] as DataSet;
        if (dsa != null)
        {
            Session.Remove("BulkJobUpload");

            string hss_iec = dsa.Tables["GENERAL"].Rows.Count > 0 ? dsa.Tables["GENERAL"].Rows[0]["HIGH_SEA_IEC"].ToString() : "";
            string hss_branchSLNo = dsa.Tables["GENERAL"].Rows.Count > 0 ? dsa.Tables["GENERAL"].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString() : "";

            if (!string.IsNullOrWhiteSpace(hss_iec) && !string.IsNullOrWhiteSpace(hss_branchSLNo))
            {
                ds_IEC = Get_Importer_HSS_Details(hss_iec, hss_branchSLNo);
                if (ds_IEC == null || ds_IEC.Tables.Count == 0 || ds_IEC.Tables[0] == null || ds_IEC.Tables[0].Rows.Count == 0)
                {
                    lblUser_Msg.Text = "Supplier does not exist in the Master. Do you want to add it?";
                    MP_U.Show();
                    return;
                    //MP_U.Hide();
                }
            }
        }

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

    // ── MAIN METHOD: validate all 14 tables, insert only if no errors 
    public int ValidateAllOld(DataSet ds)
    {
        //int result = 0;

        Dictionary<string, string> tableMap = GetTableValidationMap();
        Dictionary<string, ValidationRules> master = LoadAllMasterRules();
        Regex nonAscii = new Regex("[^ -~]");


        if (allErrors.Rows.Count > 0)
        {
            allErrors.Clear();
            gv_Item_Details.DataSource = allErrors;
            gv_Item_Details.DataBind();
        }
       
        if (allErrors.Columns.Count == 0)
        {
            allErrors.Columns.Add("TABLE_NAME", typeof(string));
            allErrors.Columns.Add("ERROR_DESCRIPTION", typeof(string));
            allErrors.Columns.Add("COLUMN_NAME", typeof(string));
            allErrors.Columns.Add("DATA", typeof(string));
        }

        
        
        // ── Loop all 14 DataTables ───────────────────────────────────────────────
        foreach (KeyValuePair<string, string> item in tableMap)
        {
            string dsTableName = item.Key;   // name in DataSet
            string dbTableName = item.Value; // name in DB

            // Skip if DataTable missing or empty
            if (!ds.Tables.Contains(dsTableName))
                continue;
            
            DataTable dt = ds.Tables[dsTableName];
            if (dt == null || dt.Rows.Count == 0)
                continue;

            if (dsTableName == "GENERAL")
            {
                #region 

                string beType = ds.Tables["GENERAL"].Rows[0]["BE_TYPE"].ToString();
                string werehouseCode = ds.Tables["GENERAL"].Rows[0]["WAREHOUSE_CODE"].ToString();
                // Warehouse Code is mandatory only when BE_TYPE = Warehouse
                if (string.IsNullOrEmpty(werehouseCode) && beType.Equals("Warehouse", StringComparison.OrdinalIgnoreCase))
                {
                    DataRow e = allErrors.NewRow();
                    e["TABLE_NAME"] = dsTableName;
                    e["ERROR_DESCRIPTION"] = "WAREHOUSE_CODE is mandatory when BE_TYPE is Warehouse";
                    e["COLUMN_NAME"] = "WAREHOUSE_CODE";
                    e["DATA"] = "";
                    allErrors.Rows.Add(e);
                }

                string registrationNo = ds.Tables["GENERAL"].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                if (!string.IsNullOrWhiteSpace(registrationNo))
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(registrationNo.Trim(),@"^[A-Za-z0-9]{15}$"))
                    {                        
                        DataRow e = allErrors.NewRow();
                        e["TABLE_NAME"] = dsTableName;
                        e["ERROR_DESCRIPTION"] = "REGISTRATION_NO must be exactly 15 characters";
                        e["COLUMN_NAME"] = "REGISTRATION_NO";
                        e["DATA"] = registrationNo;
                        allErrors.Rows.Add(e);
                    }
                }

                #endregion
            }
            if (dsTableName == "SUPPORTING_DOCS")
            {
                int status = Sup_Doc_Validation(dt);
            }
            else
            {
                #region Loop selected DataTables

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        string colName = col.ColumnName.Trim().ToUpper();
                        string cellValue = row[col] == null ? string.Empty : row[col].ToString();

                        string masterKey = dbTableName + "|" + colName;
                        if (!master.ContainsKey(masterKey))
                            continue;

                        ValidationRules rule = master[masterKey];

                        // CHECK 7: Date format DD/MM/YYYY
                        if (rule.DataType == "DATETIME")
                        {
                            if (!IsDateValidate(cellValue))
                            {
                                DataRow e = allErrors.NewRow();
                                e["TABLE_NAME"] = dsTableName;
                                e["ERROR_DESCRIPTION"] = "Invalid Date Format";
                                e["COLUMN_NAME"] = rule.ColumnName;
                                e["DATA"] = cellValue;
                                allErrors.Rows.Add(e);
                            }
                            continue;
                        }
                        else
                        {

                            // CHECK 1: Length
                            if (rule.MaxLen > 0 && cellValue.Length > rule.MaxLen)
                            {
                                DataRow e = allErrors.NewRow();
                                e["TABLE_NAME"] = dsTableName;
                                e["ERROR_DESCRIPTION"] = "Check filed Length should be " + rule.MaxLen.ToString();
                                e["COLUMN_NAME"] = rule.ColumnName;
                                e["DATA"] = cellValue;
                                allErrors.Rows.Add(e);
                            }

                            // CHECK 2: Mandatory
                            if (rule.Mandatory && string.IsNullOrEmpty(cellValue))
                            {
                                DataRow e = allErrors.NewRow();
                                e["TABLE_NAME"] = dsTableName;
                                e["ERROR_DESCRIPTION"] = "Mandatory field Missing";
                                e["COLUMN_NAME"] = rule.ColumnName;
                                e["DATA"] = cellValue;
                                allErrors.Rows.Add(e);
                            }

                            // Skip remaining checks if empty
                            if (string.IsNullOrEmpty(cellValue))
                                continue;

                            // CHECK 3 & 4: Numeric
                            if (rule.DataType == "BIGINT" && !string.IsNullOrEmpty(cellValue))
                            {
                                if (!IsNumericValidate(cellValue) && cellValue.Contains("_"))
                                {
                                    DataRow e = allErrors.NewRow();
                                    e["TABLE_NAME"] = dsTableName;
                                    e["ERROR_DESCRIPTION"] = "Not a Numeric";
                                    e["COLUMN_NAME"] = rule.ColumnName;
                                    e["DATA"] = cellValue;
                                    allErrors.Rows.Add(e);
                                }
                            }

                            // CHECK 5: Special chars
                            if (nonAscii.IsMatch(cellValue))
                            {
                                DataRow e = allErrors.NewRow();
                                e["TABLE_NAME"] = dsTableName;
                                e["ERROR_DESCRIPTION"] = "Check Special chars";
                                e["COLUMN_NAME"] = rule.ColumnName;
                                e["DATA"] = cellValue;
                                allErrors.Rows.Add(e);
                            }

                            // CHECK 6: Single quote
                            if (cellValue.Contains("'"))
                            {
                                DataRow e = allErrors.NewRow();
                                e["TABLE_NAME"] = dsTableName;
                                e["ERROR_DESCRIPTION"] = "Check Special chars";
                                e["COLUMN_NAME"] = rule.ColumnName;
                                e["DATA"] = cellValue;
                                allErrors.Rows.Add(e);
                            }
                        }
                    }
                }

                #endregion
            }
        }        

        //return 1;
        return allErrors.Rows.Count == 0 ? 1 : 0;
        
    }

    // ── MAIN METHOD: validate all 14 tables, insert only if no errors 
    public int ValidateAll(DataSet ds)
    {
        //int result = 0;

        Dictionary<string, string> tableMap = GetTableValidationMap();
        Dictionary<string, ValidationRules> master = LoadAllMasterRules();
        Regex nonAscii = new Regex("[^ -~]");


        if (allErrors.Rows.Count > 0)
        {
            allErrors.Clear();
            gv_Item_Details.DataSource = allErrors;
            gv_Item_Details.DataBind();
        }

        if (allErrors.Columns.Count == 0)
        {
            allErrors.Columns.Add("TABLE_NAME", typeof(string));
            allErrors.Columns.Add("ERROR_DESCRIPTION", typeof(string));
            allErrors.Columns.Add("COLUMN_NAME", typeof(string));
            allErrors.Columns.Add("DATA", typeof(string));
        }



        // ── Loop all 14 DataTables ───────────────────────────────────────────────
        foreach (KeyValuePair<string, string> item in tableMap)
        {
            string dsTableName = item.Key;   // name in DataSet
            string dbTableName = item.Value; // name in DB

            // Skip if DataTable missing or empty
            if (!ds.Tables.Contains(dsTableName))
                continue;

            DataTable dt = ds.Tables[dsTableName];
            if (dt == null || dt.Rows.Count == 0)
                continue;

            if (dsTableName == "GENERAL")
            {
                #region

                string beType = ds.Tables["GENERAL"].Rows[0]["BE_TYPE"].ToString();
                string werehouseCode = ds.Tables["GENERAL"].Rows[0]["WAREHOUSE_CODE"].ToString();
                // Warehouse Code is mandatory only when BE_TYPE = Warehouse
                if (string.IsNullOrEmpty(werehouseCode) && beType.Equals("Warehouse", StringComparison.OrdinalIgnoreCase))
                {
                    AddError(dsTableName, "WAREHOUSE_CODE is mandatory when BE_TYPE is Warehouse", "WAREHOUSE_CODE", "");
                }

                string registrationNo = ds.Tables["GENERAL"].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                if (!string.IsNullOrWhiteSpace(registrationNo))
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(registrationNo.Trim(), @"^[A-Za-z0-9]{15}$"))
                    {
                        AddError(dsTableName, "REGISTRATION_NO must be exactly 15 characters", "REGISTRATION_NO", registrationNo);
                    }
                }

                string adCode = ds.Tables["GENERAL"].Rows[0]["ADCODE"].ToString();
                if (string.IsNullOrEmpty(adCode))
                {
                    AddError(dsTableName, "ADCODE is mandatory ", "ADCODE", "");
                }

                #endregion
            }
            if (dsTableName == "SUPPORTING_DOCS")
            {
                int status = Sup_Doc_Validation(dt);
            }
            else
            {
                #region Loop selected DataTables

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        string colName = col.ColumnName.Trim().ToUpper();
                        string cellValue = row[col] == null ? string.Empty : row[col].ToString();

                        string masterKey = dbTableName + "|" + colName;
                        if (!master.ContainsKey(masterKey))
                            continue;

                        ValidationRules rule = master[masterKey];

                        // CHECK 7: Date format DD/MM/YYYY
                        if (rule.DataType == "DATETIME")
                        {
                            if (cellValue == "")
                            {
                                AddError(dsTableName, "Mandatory field Missing", rule.ColumnName, cellValue);
                                continue;
                            }
                            if (!IsDateValidate(cellValue))
                            {
                                AddError(dsTableName, "Invalid Date Format", rule.ColumnName, cellValue);
                            }
                            continue;
                        }
                        else
                        {
                            if (rule.ColumnName == "COMMERCIAL_TAX_STATECODE")
                            {                                
                                if (cellValue != "")
                                {
                                    if (cellValue.Contains('-'))
                                    {
                                        string[] p = cellValue.Split('-');
                                        string p1 = p[0];
                                        //string p2 = p[1];

                                        //COMMERCIAL_TAX_STATENAME = p2.Trim();
                                        cellValue = p1.Trim();                                        
                                    }
                                }
                                
                            }
                            if (rule.ColumnName == "COMMERCIAL_TAX_TYPE")
                            {
                                if (cellValue != "")
                                {
                                    if (cellValue.Contains('-'))
                                    {
                                        string[] p = cellValue.Split('-');
                                        string p1 = p[0];
                                        //string p2 = p[1];

                                        //COMMERCIAL_TAX_STATENAME = p2.Trim();
                                        cellValue = p1.Trim();
                                    }
                                }
                            }

                            // CHECK 1: Length
                            if (rule.MaxLen > 0 && cellValue.Length > rule.MaxLen)
                            {
                                AddError(dsTableName, "Check filed Length should be " + rule.MaxLen.ToString(), rule.ColumnName, cellValue);
                            }

                            // CHECK 2: Mandatory
                            if (rule.Mandatory && string.IsNullOrEmpty(cellValue))
                            {                                
                                AddError(dsTableName, "Mandatory field Missing", rule.ColumnName, cellValue);
                            }

                            // Skip remaining checks if empty
                            if (string.IsNullOrEmpty(cellValue))
                                continue;

                            // CHECK 3 & 4: Numeric
                            if (rule.DataType == "BIGINT" && !string.IsNullOrEmpty(cellValue))
                            {
                                if (!IsNumericValidate(cellValue) && cellValue.Contains("_"))
                                {                                   
                                    AddError(dsTableName, "Not a Numeric", rule.ColumnName, cellValue);
                                }
                            }

                            // CHECK 5: Special chars
                            if (nonAscii.IsMatch(cellValue))
                            {                               
                                AddError(dsTableName, "Check Special chars", rule.ColumnName, cellValue);
                            }

                            // CHECK 6: Single quote
                            if (cellValue.Contains("'"))
                            {                                
                                AddError(dsTableName, "Check Special chars", rule.ColumnName, cellValue);

                            }
                        }
                    }
                }

                #endregion

                if (dsTableName == "ITEMS")
                {
                    string country = ds.Tables["ITEMS"].Rows[0]["M_P_GROWER_COUNTRY"].ToString();
                    string sourceCountry = ds.Tables["ITEMS"].Rows[0]["SOURCE_COUNTRY"].ToString();
                    string transitCountry = ds.Tables["ITEMS"].Rows[0]["TRANSIT_COUNTRY"].ToString();

                    if (!string.IsNullOrEmpty(country) && country.Length != 2)
                        AddError(dsTableName, "M_P_GROWER_COUNTRY: Please enter a valid 2-letter Country Code.", "M_P_GROWER_COUNTRY", country);

                    if (!string.IsNullOrEmpty(sourceCountry) && sourceCountry.Length != 2)
                        AddError(dsTableName, "SOURCE_COUNTRY: Please enter a valid 2-letter Country Code.", "SOURCE_COUNTRY", sourceCountry);

                    if (!string.IsNullOrEmpty(transitCountry) && transitCountry.Length != 2)
                        AddError(dsTableName, "TRANSIT_COUNTRY: Please enter a valid 2-letter Country Code.", "TRANSIT_COUNTRY", transitCountry);
                }
            }
        }

        //return 1;
        return allErrors.Rows.Count == 0 ? 1 : 0;

    }

    private void AddError(string tableName, string errorDesc, string columnName, string data )
    {
        DataRow e = allErrors.NewRow();
        e["TABLE_NAME"] = tableName;
        e["ERROR_DESCRIPTION"] = errorDesc;
        e["COLUMN_NAME"] = columnName;
        e["DATA"] = data;
        allErrors.Rows.Add(e);
    }

    // Map: DataTable name → DB table name in TBL_COL_VALIDATE_MASTER_IMPORT
    private Dictionary<string, string> GetTableValidationMap()
    {
        var map = new Dictionary<string, string>();
        map.Add("GENERAL", "GENERAL_DETAILS");
        map.Add("IGM", "IGM_DETAILS");
        map.Add("CONTAINER", "CONTAINER_DETAILS");
        map.Add("INVOICE", "INVOICE_DETAILS");
        map.Add("ITEMS", "ITEM_PRODUCT_DETAILS");
        map.Add("RE_IMPORT", "RE_IMPORT_DETAILS");
        map.Add("SW_INFO_TYPE", "BE_ITEM_SW_INFO_TYPE");
        map.Add("SW_CONSTITUENT", "BE_ITEM_SW_CONST");
        map.Add("SW_PRODUCTION", "BE_ITEM_SW_PROD");
        map.Add("SW_CONTROL", "BE_ITEM_SW_CONTROL");
        map.Add("LICENSE", "LICENSE_DETAILS");
        map.Add("BONDS", "BOND_DETAILS");
        map.Add("CERTIFICATES", "CERTIFICATE_DETAILS");
        map.Add("SUPPORTING_DOCS", "BE_ITEM_SW_SUP_DOC");
        return map;

    }

    // ── Validation Master Rule
    private class ValidationRules
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int MaxLen { get; set; }
        public bool Mandatory { get; set; }
        public string DataType { get; set; }
    }

    // Load master once for all 14 tables
    // Key: "TABLE_NAME|COLUMN_NAME"
    private Dictionary<string, ValidationRules> LoadAllMasterRules()
    {
        var dict = new Dictionary<string, ValidationRules>();
        string sql = "SELECT TABLE_NAME, COLUMN_NAME, MAX_LEN, MANDATORY, DATATYPE FROM TBL_COL_VALIDATE_MASTER_IMPORT";

        using (SqlConnection con = new SqlConnection(comp_ConnectionStr))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        {
            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    var rule = new ValidationRules();
                    rule.ColumnName = rdr["COLUMN_NAME"].ToString().Trim();
                    rule.DataType = rdr["DATATYPE"].ToString().Trim().ToUpper();
                    rule.Mandatory = rdr["MANDATORY"].ToString().Trim().ToUpper() == "Y";

                    int maxLen = 0;
                    int.TryParse(rdr["MAX_LEN"].ToString(), out maxLen);
                    rule.MaxLen = maxLen;

                    string key = rdr["TABLE_NAME"].ToString().Trim() + "|" + rule.ColumnName;
                    if (!dict.ContainsKey(key))
                        dict[key] = rule;
                }
            }
        }
        return dict;
    }

    private bool IsDateValidate(string data)
    {
        if (string.IsNullOrEmpty(data))
            return true; // SP: AND ISNULL(data,'') <> '' — skip empty

        // Exact SP reorder logic:
        // SUBSTRING(DATA, 4, 2) = characters 4-5 = MM
        // LEFT(DATA, 2)         = characters 1-2 = DD
        // RIGHT(DATA, 4)        = last 4 chars   = YYYY
        if (data.Length < 10)
            return false; // cannot reorder — invalid

        string mm = data.Substring(3, 2); // SUBSTRING(DATA, 4, 2) — SQL is 1-based
        string dd = data.Substring(0, 2); // LEFT(DATA, 2)
        string yyyy = data.Substring(6, 4); // RIGHT(DATA, 4)

        string reordered = mm + "/" + dd + "/" + yyyy; // MM/DD/YYYY

        DateTime dummy;
        // ISDATE() in SQL checks MM/DD/YYYY — so we parse exactly that
        return DateTime.TryParseExact(
            reordered,
            "MM/dd/yyyy",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None,
            out dummy);
    }

    private int Sup_Doc_Validation(DataTable sourceTable)
    {
        //try
        //{

        // 1. Add the missing 3 columns to the incoming sourceTable if they don't exist
        if (!sourceTable.Columns.Contains("DECLARATION_TYPE"))
            sourceTable.Columns.Add("DECLARATION_TYPE", typeof(string));

        //if (!sourceTable.Columns.Contains("FILE_TYPE"))
        //    sourceTable.Columns.Add("FILE_TYPE", typeof(string));

        if (!sourceTable.Columns.Contains("ICEGATE_DOC_FILE_NAME"))
            sourceTable.Columns.Add("ICEGATE_DOC_FILE_NAME", typeof(string));

        foreach (DataRow row in sourceTable.Rows)
        {
            row["DECLARATION_TYPE"] = "E";
        }

 
            string[] swColumns = { "INVOICE_SLNO", "ITEM_SLNO", "DECLARATION_TYPE", "IMAGE_REF_NUMBER", "DOC_TYPE_CODE", "DOC_ISSUING_PARTY_CODE", "DOC_ISSUING_PARTY_NAME", "DOC_ISSUING_PARTY_NAME_ADD1", "DOC_ISSUING_PARTY_NAME_ADD2", "DOC_ISSUING_PARTY_CITY", "DOC_ISSUING_PARTY_PIN", "DOC_REF_NUMBER", "PLACE_OF_ISSUE", "DOC_ISSUE_DATE", "DOC_EXPIRY_DATE", "BENEFICIARY_PARTY_CODE", "BENEFICIARY_PARTY_NAME", "BENEFICIARY_PARTY_ADDRESS1", "BENEFICIARY_PARTY_ADDRESS2", "BENEFICIARY_PARTY_CITY", "BENEFICIARY_PARTY_PIN", /*"FILE_TYPE",*/ "SELECT_TYPE", "ICEGATE_ID", "ICEGATE_DOC_FILE_NAME" };
            
            DataTable selectedSupDoc = sourceTable.DefaultView.ToTable(true, swColumns); if (selectedSupDoc.Rows.Count == 0) { Alert_msg("No valid SW document rows found."); return 0; } 
                       

            foreach (DataColumn col in selectedSupDoc.Columns)
            {
                textSupDoc.Columns.Add(col.ColumnName, typeof(string));
            }

            foreach (DataRow row in selectedSupDoc.Rows)
            {
                DataRow newRow = textSupDoc.NewRow();

                foreach (DataColumn col in selectedSupDoc.Columns)
                {
                    string colName = col.ColumnName;

                    // Format DOC_ISSUE_DATE
                    if (colName == "DOC_ISSUE_DATE")
                    {
                        if (row[col] == DBNull.Value)
                        {
                            newRow[colName] = "";
                        }
                        else
                        {
                            DateTime dt;
                            if (DateTime.TryParse(row[col].ToString(), out dt))
                                newRow[colName] = dt.ToString("dd/MM/yyyy");
                            else
                                newRow[colName] = row[col].ToString();
                        }
                    }

                    // Format DOC_EXPIRY_DATE
                    else if (colName == "DOC_EXPIRY_DATE")
                    {
                        if (row[col] == DBNull.Value)
                        {
                            newRow[colName] = "";
                        }
                        else
                        {
                            DateTime dt;
                            if (DateTime.TryParse(row[col].ToString(), out dt))
                                newRow[colName] = dt.ToString("dd/MM/yyyy");
                            else
                                newRow[colName] = row[col].ToString();
                        }
                    }

                    // Normal columns
                    else
                    {
                        newRow[colName] = row[col] == DBNull.Value ? "" : row[col].ToString();
                    }
                }

                textSupDoc.Rows.Add(newRow);
            }
            
            
            //1. Read uploaded Excel temp table
            //2. Convert all columns into generic rows
            //3. Validate using master rules + custom rules
            //4. Collect ALL errors
            //5. Return:
            //Table[0] = Errors
            //Table[1] = Preview Data

            Delete_SW_Temp_Table();

            SqlBulk_Upload_Product("TBL_BE_ITEM_SW_SUP_DOC_EXCEL_FORMAT", textSupDoc, Connection.GetConnection());
           
            DataSet dsValidate = Imp_XL.Bulk_Excel_Validation("BE_ITEM_SW_SUP_DOC_Val");

            if (dsValidate == null || dsValidate.Tables.Count == 0)
            {
                Alert_msg(" Supporting Documents DB Validation Error.");
                return 0;
            }

            DataTable errorTable = dsValidate.Tables[0];    
            foreach (DataRow row in errorTable.Rows)
            {
                allErrors.Rows.Add("SUPPORTING_DOCS",row["ERROR_DESCRIPTION"],row["COLUMN_NAME"],row["DATA"]);
            }

            supDocHasErrors = errorTable.Rows.Count > 0;            

            return 1;
    }

    private void Delete_SW_Temp_Table()
    {
        
        SqlConnection con = new SqlConnection(Connection.GetConnection());
        
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM TBL_BE_ITEM_SW_SUP_DOC_EXCEL_FORMAT", con);
            cmd.CommandTimeout = 120;
            cmd.ExecuteNonQuery();

            if (con.State == ConnectionState.Open) { con.Close(); con.Dispose(); }
        
    }    

    public void SupDoc_DATA_CHECK(DataTable dsXML_Excel)
    {
        if (!dsXML_Excel.Columns.Contains("FILE_TYPE"))
            dsXML_Excel.Columns.Add("FILE_TYPE", typeof(string));

        DataSet dck = new DataSet();        

        ObjUBO.SW_STMT_ID = "";
        ObjUBO.flag = "Data_Check";
        ObjUBO.JOBNO = IMPORT_JOBNO;       
        ObjUBO.WORKING_PERIOD = Working_Period;

        dck = Sup_Doc.Imp_Sup_Doc_Xl_Upload(ObjUBO, dsXML_Excel);

        // Defensive checks
        if (dck == null || dck.Tables.Count < 2)
        {            
            return ;
        }

        DataTable resultTable = dck.Tables[1];        

        bool hasIRNColumn = resultTable.Columns.Count > 4;       

        // No rows
        if (resultTable.Rows.Count == 0)
        {            
            return ;
        }

        // Build VALID rows
        foreach (DataRow row in resultTable.Rows)
        {
            string errorMsg = row["ERRORS_MESSAGE"].ToString();

            if (errorMsg == "T")
                continue;

            string invSlNo = row["INVOICE_SLNO"].ToString();
            string itmSlNo = row["ITEM_SLNO"].ToString();
            string irnNo = string.Empty;
            string data = string.Empty;
            
            DataRow e = allErrors.NewRow();
            e["TABLE_NAME"] = "SUPPORTING_DOCS";
            e["ERROR_DESCRIPTION"] = errorMsg;
            if (hasIRNColumn)
            { 
                irnNo = row["IMAGE_REF_NUMBER"].ToString(); e["COLUMN_NAME"] = "INVOICE_SLNO - ITEM_SLNO - IMAGE_REF_NUMBER " + irnNo;
                data = invSlNo + "-" + itmSlNo + "-" + irnNo;
            }
            else { e["COLUMN_NAME"] = "INVOICE_SLNO - ITEM_SLNO  "; data = invSlNo + "-" + itmSlNo;}
            e["DATA"] = data;
            allErrors.Rows.Add(e);
        }     
    }

    private bool IsNumericValidate(string data)
    {
        if (string.IsNullOrEmpty(data))
            return true; // SP: AND ISNULL(data,'') <> '' — skip empty
        
        decimal dummy;
        return decimal.TryParse(
            data,
            System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture,
            out dummy);
    }



    public DataTable Read_General_Details(DataTable General_data)
    {
        #region FROM EXCEL

        DataRow dtRow = General_data.Rows[0];        

        JOBDATE = GetString(dtRow, "JOBDATE");
        TRANSPORT_MODE = GetString(dtRow, "TRANSPORT_MODE");
        ListItem matchedTrMode = GetMatchedItem(TRANSPORT_MODE, transModeList);
        TRANSPORT_MODE = matchedTrMode != null ? matchedTrMode.Text : TRANSPORT_MODE;
        BE_TYPE = GetString(dtRow, "BE_TYPE");
        ListItem matchedBeType = GetMatchedItem(BE_TYPE, beTypeList);
        BE_TYPE = matchedBeType != null ? matchedBeType.Text : BE_TYPE;
        CUSTOMS_HOUSE = GetString(dtRow, "CUSTOMS_HOUSE");//CUSTOM_HOUSE_CODE
        CUSTOMS_HOUSE = string.IsNullOrWhiteSpace(CUSTOMS_HOUSE) ? Session["CUSTOMHOUSE_CODE"].ToString() : CUSTOMS_HOUSE;
        CONTAINER_TYPE = GetString(dtRow, "CONTAINER_TYPE");
        ListItem matchedConType = GetMatchedItem(CONTAINER_TYPE, conTypeList);
        CONTAINER_TYPE = matchedConType != null ? matchedConType.Text : CONTAINER_TYPE;
        FILE_REF_NO = GetString(dtRow, "FILE_REF_NO");
        FILING_STATUS = GetString(dtRow, "FILING_STATUS");
        ListItem matchedfilingStatus = GetMatchedItem(FILING_STATUS, filingStatusList);
        FILING_STATUS = matchedfilingStatus != null ? matchedfilingStatus.Text : FILING_STATUS;
        ICE_ID = GetString(dtRow, "ICE_ID");//ICEGATEID
        CHA_NO = GetString(dtRow, "CHA_NO");
        IMPORTER_NAME = GetString(dtRow, "IMPORTER_NAME");
        IEC_NO = GetString(dtRow, "IEC_NO");
        BRANCH_NO = GetString(dtRow, "BRANCH_NO");//BRANCH_SL_NO
        ADCODE = GetString(dtRow, "ADCODE");
        ADDRESS1 = GetString(dtRow, "ADDRESS1");
        ADDRESS2 = GetString(dtRow, "ADDRESS2");
        ADDRESS3 = GetString(dtRow, "ADDRESS3");
        ADDRESS4 = GetString(dtRow, "ADDRESS4");
        ADDRESS5 = GetString(dtRow, "ADDRESS5");
        COUNTRY_ORIGIN = GetString(dtRow, "COUNTRY_ORIGIN");//COUNTRY_OF_ORIGIN
        COUNTRY_SHIPMENT = GetString(dtRow, "COUNTRY_SHIPMENT");//COUNTRY_OF_SHIPMENT
        COUNTRY_SHIPMENT = string.IsNullOrEmpty(COUNTRY_SHIPMENT) ? COUNTRY_ORIGIN : COUNTRY_SHIPMENT;
        PORT_ORIGIN = GetString(dtRow, "PORT_ORIGIN");//PORT_OF_ORIGIN
        PORT_SHIPMENT = GetString(dtRow, "PORT_SHIPMENT");//PORT_OF_SHIPMENT
        PORT_SHIPMENT = string.IsNullOrEmpty(PORT_SHIPMENT) ? PORT_ORIGIN : PORT_SHIPMENT;
        COMMERCIAL_TAX = GetString(dtRow, "COMMERCIAL_DETAILS_STATUS");//COMMERCIAL_TAX_DETAILS      
        COMMERCIAL_TAX_STATENAME = GetString(dtRow, "COMMERCIAL_TAX_STATENAME");//STATE_NAME
        COMMERCIAL_TAX_STATECODE = GetString(dtRow, "COMMERCIAL_TAX_STATECODE");//STATE_CODE
        REGISTRATION_NO = GetString(dtRow, "COMMERCIAL_TAX_REGISTRATION_NO");//REGISTRATION_NO
        TYPE = GetString(dtRow, "COMMERCIAL_TAX_TYPE");//GSTN_TYPE 
 
        #region
        
        if (COMMERCIAL_TAX_STATECODE != "")
        {
            if (COMMERCIAL_TAX_STATECODE.Contains('-'))
            {
                string[] p = COMMERCIAL_TAX_STATECODE.Split('-');
                string p1 = p[0];
                string p2 = p[1];

                COMMERCIAL_TAX_STATENAME = p2.Trim();
                COMMERCIAL_TAX_STATECODE = p1.Trim();
            }
        }
        if (TYPE != "")
        {
            if (TYPE.Contains('-'))
            {
                string[] p = TYPE.Split('-');
                string p1 = p[0];
                string p2 = p[1];

                TYPE = p1.Trim();
            }
        }
        #endregion

        WAREHOUSE_CODE = GetString(dtRow, "WAREHOUSE_CODE");        
        ETA = GetString(dtRow, "ETA");        
        SECTION46_DESC = GetString(dtRow, "SECTION46_DESC");
        SECTION46 = string.IsNullOrWhiteSpace(SECTION46_DESC) ? "N" : "Y";
        FIRSTCHECK_DESC = GetString(dtRow, "FIRSTCHECK_DESC");
        FIRSTCHECK = string.IsNullOrWhiteSpace(FIRSTCHECK_DESC) ? "N" : "Y";
        GREEN_CHANNEL_DESC = GetString(dtRow, "GREEN_CHANNEL_DESC");
        GREEN_CHANNEL = string.IsNullOrWhiteSpace(GREEN_CHANNEL_DESC) ? "N" : "Y";
        KACHHA_BE_DESC = GetString(dtRow, "KACHHA_BE_DESC");
        KACHHA_BE = string.IsNullOrWhiteSpace(KACHHA_BE_DESC) ? "N" : "Y";
        SECTION48_DESC = GetString(dtRow, "SECTION48_DESC");
        SECTION48 = string.IsNullOrWhiteSpace(SECTION48_DESC) ? "N" : "Y";
        PROVISIONAL_DESC = GetString(dtRow, "PROVISIONAL_DESC");
        PROVISIONAL = string.IsNullOrWhiteSpace(PROVISIONAL_DESC) ? "N" : "Y";
        HIGH_SEA_SALE_NAME = GetString(dtRow, "HIGH_SEA_SALE_NAME");//SELLER_NAME
        HIGH_SEA_SALE = string.IsNullOrWhiteSpace(HIGH_SEA_SALE_NAME) ? "N" : "Y";
        HIGH_SEA_IEC = GetString(dtRow, "HIGH_SEA_IEC");//HSS_IEC_NO
        HIGH_SEA_BRANCH_SL_NO = GetString(dtRow, "HIGH_SEA_BRANCH_SL_NO");//BR_SL_NO
        HSS_ADD1 = GetString(dtRow, "HSS_ADD1");
        HSS_ADD2 = GetString(dtRow, "HSS_ADD2");
        HSS_ADD3 = GetString(dtRow, "HSS_ADD3");
        HSS_ADD4 = GetString(dtRow, "HSS_ADD4");
        HSS_ADD5 = GetString(dtRow, "HSS_ADD5");
        HSS_ADCODE = GetString(dtRow, "HSS_ADCODE");
        PRECEDING_LEVEL = GetString(dtRow, "PRECEDING_LEVEL");
        PAYMENT_METHOD_CODE = GetString(dtRow, "PAYMENT_METHOD_CODE");//PAYMENT_METHOD
        PAYMENT_METHOD_CODE = string.IsNullOrEmpty(PAYMENT_METHOD_CODE) ? "T" : PAYMENT_METHOD_CODE;
        PARTY_REF_NO = GetString(dtRow, "PARTY_REF_NO"); 

        #endregion

        //GSTN_TYPE = GetString(dtRow, "GSTN_TYPE");
        //GSTN_ID = GetString(dtRow, "GSTN_ID");  
        WAREHOUSE_NAME = string.Equals(BE_TYPE, "Ex-Bond", StringComparison.OrdinalIgnoreCase) ? "Yes" : "No";
        if (COMMERCIAL_TAX != "Y"){COMMERCIAL_TAX = "Y";}     


        #region Check Importer/Seller Details

        //dsImp = Get_Importer_Seller_Details(IEC_NO, BRANCH_NO);
        dsImp = new DataSet();
        if (!string.IsNullOrEmpty(IEC_NO) && !string.IsNullOrEmpty(BRANCH_NO))
        {
            dsImp = Get_Importer_Seller_Details(IEC_NO, BRANCH_NO);
        }
        if (dsImp == null || dsImp.Tables.Count == 0 || dsImp.Tables[0].Rows.Count == 0)
        {
            AddError("GENERAL", "Importer Name Mismatch", "IMPORTER_NAME", IMPORTER_NAME);
        }
        else
        {
            if (dsImp.Tables[0].Rows.Count > 0)
            {
                DataRow rowImp = dsImp.Tables[0].Rows[0];

                IMPORTER_NAME = GetString(rowImp, "IMP_EXP_NAME");
                IEC_NO = GetString(rowImp, "IMP_EXP_IECNO");
                BRANCH_NO = GetString(rowImp, "IMP_EXP_BRSLNO");
                ADDRESS1 = GetString(rowImp, "IMP_EXP_ADD1");
                ADDRESS2 = GetString(rowImp, "IMP_EXP_ADD2");
                ADDRESS3 = GetString(rowImp, "IMP_EXP_ADD3");
                ADDRESS4 = GetString(rowImp, "IMP_EXP_ADD4");
                ADDRESS5 = GetString(rowImp, "IMP_EXP_PIN_CODE");

                COMMERCIAL_TAX = GetString(rowImp, "M_COMMERCIAL_DETAILS_STATUS");
                COMMERCIAL_TAX_STATENAME = GetString(rowImp, "M_COMMERCIAL_TAX_STATENAME");
                COMMERCIAL_TAX_STATECODE = GetString(rowImp, "M_COMMERCIAL_TAX_STATECODE");
                TYPE = GetString(rowImp, "M_COMMERCIAL_TAX_TYPE");
                REGISTRATION_NO = GetString(rowImp, "M_COMMERCIAL_TAX_REGISTRATION_NO");
                GSTN_TYPE = GetString(rowImp, "GSTN_TYPE");
                GSTN_ID = GetString(rowImp, "GSTN_ID");
                WAREHOUSE_CODE = GetString(rowImp, "WAREHOUSE_CODE");
                PAYMENT_METHOD_CODE = GetString(rowImp, "PAYMENT_METHOD_CODE");

                IMP_EXP_TYPE = GetString(rowImp, "IMP_EXP_TYPE");
            }
        }

        ds_IEC = new DataSet();
        //ds_IEC = Get_Importer_Seller_Details(HIGH_SEA_IEC, HIGH_SEA_BRANCH_SL_NO);
        if (!string.IsNullOrEmpty(HIGH_SEA_IEC) && !string.IsNullOrEmpty(HIGH_SEA_BRANCH_SL_NO))
        {
            ds_IEC = Get_Importer_Seller_Details(HIGH_SEA_IEC, HIGH_SEA_BRANCH_SL_NO);

            if (ds_IEC == null || ds_IEC.Tables.Count == 0 || ds_IEC.Tables[0].Rows.Count == 0)
            {
                AddError("GENERAL", "Seller Name Mismatch", "SELLER_NAME", HIGH_SEA_SALE_NAME);
            }
            else
            {
                if (ds_IEC.Tables[0].Rows.Count > 0)
                {
                    HIGH_SEA_SALE = "Y";
                    DataRow rowIEC = ds_IEC.Tables[0].Rows[0];
                    HIGH_SEA_SALE_NAME = GetString(rowIEC, "IMP_EXP_NAME");
                    HSS_ADD1 = GetString(rowIEC, "IMP_EXP_ADD1");
                    HSS_ADD2 = GetString(rowIEC, "IMP_EXP_ADD2");
                    HSS_ADD3 = GetString(rowIEC, "IMP_EXP_ADD3");
                    HSS_ADD4 = GetString(rowIEC, "IMP_EXP_ADD4");
                    HSS_ADD5 = GetString(rowIEC, "IMP_EXP_PIN_CODE");
                }
            }  
        }
              

        if (currentuser == "AURIONPRO")
        {
            ADDRESS1 = GetString(dtRow, "ADDRESS1");
            ADDRESS2 = GetString(dtRow, "ADDRESS2");
            ADDRESS3 = GetString(dtRow, "ADDRESS3");
            ADDRESS4 = GetString(dtRow, "ADDRESS4");
            ADDRESS5 = GetString(dtRow, "ADDRESS5");

            HIGH_SEA_SALE_NAME = GetString(dtRow, "SELLER_NAME");
            HSS_ADD1 = GetString(dtRow, "HSS_ADD1");
            HSS_ADD2 = GetString(dtRow, "HSS_ADD2");
            HSS_ADD3 = GetString(dtRow, "HSS_ADD3");
            HSS_ADD4 = GetString(dtRow, "HSS_ADD4");
            HSS_ADD5 = GetString(dtRow, "HSS_ADD5");
        }

        #endregion        

        if (BE_TYPE == "Warehouse" || BE_TYPE == "SEZ FTA-Z" || BE_TYPE == "SEZ DTA-M" || BE_TYPE == "Jobbing" || BE_TYPE == "Repair & Return" || BE_TYPE == "Exhibition" || BE_TYPE == "Destruction" || BE_TYPE == "Movement of Goods" || BE_TYPE == "Stock Item")
        {
            WAREHOUSE_CODE = WAREHOUSE_CODE.Contains('-') ? WAREHOUSE_CODE.Split('-')[0].TrimEnd() : WAREHOUSE_CODE;
        }
        else
        {
            WAREHOUSE_CODE = "";
        }

        EXBOND_INBOND_BE_DATE = LoginDate;
        EXBOND_BOND_DATE = LoginDate;
        COMPLETED_DATE = LoginDate;
        DOC_RECEIVED_DATE = LoginDate;

        LoginSTATUS = "N";
        MODIFIEDBY = currentuser;
        MODIFIEDON = LoginDate;
        USERID = currentuser;

        if (HIGH_SEA_BRANCH_SL_NO == "")
        {
            HIGH_SEA_BRANCH_SL_NO = "0";
        }

        JobNo_Prefix_Sufix();


        #region insert into general table

        if (allErrors == null || allErrors.Rows.Count == 0)
        {
            var param = new[]
                 {
                     // ===== EXCEL DATA =====
                     new SqlParameter("@JOBDATE",        DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)),
                     new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE),
                     new SqlParameter("@BE_TYPE",        BE_TYPE),
                     new SqlParameter("@CUSTOMS_HOUSE",  CUSTOMS_HOUSE),
                     new SqlParameter("@CONTAINER_TYPE", CONTAINER_TYPE),
                     new SqlParameter("@FILING_STATUS",  FILING_STATUS),
                     new SqlParameter("@FILE_REF_NO",    FILE_REF_NO),
                     new SqlParameter("@IEC_NO",         IEC_NO),
                     new SqlParameter("@BRANCH_NO",      BRANCH_NO),//
                     new SqlParameter("@IMPORTER_NAME",  IMPORTER_NAME),
                     new SqlParameter("@ADDRESS1",       ADDRESS1),
                     new SqlParameter("@ADDRESS2",       ADDRESS2),
                     new SqlParameter("@ADDRESS3",       ADDRESS3),
                     new SqlParameter("@ADDRESS4",       ADDRESS4),
                     new SqlParameter("@ADDRESS5",       ADDRESS5),
                     new SqlParameter("@ADCODE",         ADCODE),
                     new SqlParameter("@COUNTRY_ORIGIN", COUNTRY_ORIGIN),
                     new SqlParameter("@PORT_ORIGIN",    PORT_ORIGIN),
                     new SqlParameter("@COUNTRY_SHIPMENT",       COUNTRY_SHIPMENT),
                     new SqlParameter("@PORT_SHIPMENT",          PORT_SHIPMENT),
                     new SqlParameter("@SECTION46_DESC",         SECTION46_DESC),  
                     new SqlParameter("@FIRSTCHECK_DESC",        FIRSTCHECK_DESC),
                     new SqlParameter("@GREEN_CHANNEL_DESC",     GREEN_CHANNEL_DESC),
                     new SqlParameter("@KACHHA_BE",              KACHHA_BE),
                     new SqlParameter("@SECTION48_DESC",         SECTION48_DESC),
                     new SqlParameter("@HIGH_SEA_IEC",           HIGH_SEA_IEC),
                     new SqlParameter("@HIGH_SEA_BRANCH_SL_NO",  HIGH_SEA_BRANCH_SL_NO),//
                     new SqlParameter("@HIGH_SEA_SALE_NAME",     HIGH_SEA_SALE_NAME),
                     new SqlParameter("@HSS_ADD1",               HSS_ADD1),
                     new SqlParameter("@HSS_ADD2",               HSS_ADD2),
                     new SqlParameter("@HSS_ADD3",               HSS_ADD3),
                     new SqlParameter("@HSS_ADD4",               HSS_ADD4),
                     new SqlParameter("@HSS_ADD5",               HSS_ADD5),
                     new SqlParameter("@PRECEDING_LEVEL",        PRECEDING_LEVEL),
                     new SqlParameter("@WAREHOUSE_CODE",         WAREHOUSE_CODE),
                     new SqlParameter("@COMMERCIAL_TAX_STATECODE", COMMERCIAL_TAX_STATECODE),
                     new SqlParameter("@GSTN_TYPE",              GSTN_TYPE),
                     new SqlParameter("@GSTN_ID",                GSTN_ID),
                     new SqlParameter("@JOBNO",                  IMPORT_JOBNO),//
                     new SqlParameter("@CUSTOMS_HOUSE_NAME",     Connection.Get_Company_Type()),//CUSTOMS_HOUSE_NAME
                     new SqlParameter("@SECTION46",              SECTION46),
                     new SqlParameter("@FIRSTCHECK",             FIRSTCHECK),
                     new SqlParameter("@GREEN_CHANNEL",          GREEN_CHANNEL),
                     new SqlParameter("@KACHHA_BE_DESC",         KACHHA_BE_DESC),
                     new SqlParameter("@SECTION48",              SECTION48),
                     new SqlParameter("@HIGH_SEA_SALE",          HIGH_SEA_SALE),
                     new SqlParameter("@WAREHOUSE_NAME",         WAREHOUSE_NAME),
                     new SqlParameter("@IMP_EXP_TYPE",           IMP_EXP_TYPE),
                     new SqlParameter("@COMMERCIAL_DETAILS_STATUS",      COMMERCIAL_TAX),
                     new SqlParameter("@COMMERCIAL_TAX_STATENAME",       COMMERCIAL_TAX_STATENAME),
                     new SqlParameter("@COMMERCIAL_TAX_TYPE",            TYPE),
                     new SqlParameter("@COMMERCIAL_TAX_REGISTRATION_NO", REGISTRATION_NO),
                     new SqlParameter("@EXBOND_INBOND_BE_NO",            EXBOND_INBOND_BE_NO),
                     new SqlParameter("@EXBOND_INBOND_BE_DATE",          DateTime.Parse(EXBOND_INBOND_BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)),
                     new SqlParameter("@EXBOND_BOND_NO",                 EXBOND_BOND_NO),
                     new SqlParameter("@EXBOND_BOND_DATE",               DateTime.Parse(EXBOND_BOND_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)),
                     new SqlParameter("@EXBOND_WAREHOUSE_CUSTOMS",       EXBOND_WAREHOUSE_CUSTOMS),
                     new SqlParameter("@EXBOND_WAREHOUSE_CUSTOMS_CODE",  EXBOND_WAREHOUSE_CUSTOMS_CODE),
                     new SqlParameter("@EXBOND_NOOFPACKAGE",             EXBOND_NOOFPACKAGE),
                     new SqlParameter("@EXBOND_NOOFPACKAGE_UNITCODE",    EXBOND_NOOFPACKAGE_UNITCODE),
                     new SqlParameter("@EXBOND_GROSS_WEIGHT",            string.IsNullOrEmpty(EXBOND_GROSS_WEIGHT) ? "0" : EXBOND_GROSS_WEIGHT),//Convert.ToDecimal(EXBOND_GROSS_WEIGHT)
                     new SqlParameter("@EXBOND_GROSS_WEIGHT_UNITCODE",   EXBOND_GROSS_WEIGHT_UNITCODE),
                     new SqlParameter("@EXBOND_DIRECT_EXBONDING",        EXBOND_DIRECT_EXBONDING),
                     new SqlParameter("@EXBOND_ADDL_LOAD_HSS",           EXBOND_ADDL_LOAD_HSS), 
                     new SqlParameter("@EXBOND_MISC_LOAD_RATE",          EXBOND_MISC_LOAD_RATE),
                     new SqlParameter("@REMARKS",            REMARKS),
                     new SqlParameter("@USERID",             currentuser),   
                     new SqlParameter("@BRANCHCODE",         currentbranch),
                     new SqlParameter("@WORKINGPERIOD",      Working_Period),
                     new SqlParameter("@BRANCH_COMMON",      SELECT_BRANCH),
                     new SqlParameter("@JOBNO_PS",           JOBNO_PS), 
                     new SqlParameter("@JOB_PREFIX",         JOB_PREFIX),
                     new SqlParameter("@JOB_SUFFIX",         JOB_SUFFIX),    
                     new SqlParameter("@AMENDMENT_STATUS",  ""),
                     new SqlParameter("@GRP_ID",            HttpContext.Current.Session["GroupID"].ToString()),    
                     new SqlParameter("@Company_id",        "1"),
                     new SqlParameter("@Mflag",             flag),
                     new SqlParameter("@PROVISIONAL_DESC",         PROVISIONAL_DESC),
                     new SqlParameter("@PAYMENT_METHOD_CODE",         PAYMENT_METHOD_CODE),
                     new SqlParameter("@ETA",         ETA),
                     new SqlParameter("@PROVISIONAL",         PROVISIONAL), 
                     new SqlParameter("@HSS_ADCODE",         HSS_ADCODE), 
                     new SqlParameter("@PARTY_REF_NO",         PARTY_REF_NO), 
                     new SqlParameter("@ICE_ID",         ICE_ID), 
                     new SqlParameter("@CHA_NO",         CHA_NO), 
                     
                 
                     new SqlParameter("@MStatus",    SqlDbType.Int)    { Direction = ParameterDirection.Output },
                     new SqlParameter("@ErrorMsg",   SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output },
                     new SqlParameter("@Update_Id",  SqlDbType.BigInt) { Direction = ParameterDirection.Output },  
                 };

            if (flag == "U")
            {
                GetAndDeleteJobData("GENERAL_DETAILS");
                //DeleteJobDataByTable("GENERAL_DETAILS");
            }
            
            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_INSERT_UPDATE_BULK", param);

            int result = Convert.ToInt32(param.First(p => p.ParameterName == "@MStatus").Value);
            string errorMsg = param.First(p => p.ParameterName == "@ErrorMsg").Value.ToString();

            if (flag == "S")
            {
                IMPORT_JOBNO = param.First(p => p.ParameterName == "@Update_Id").Value.ToString();
                //flag = "U";
                lbl_JobNo.Text = "Job - "+IMPORT_JOBNO;
                //Session.Remove("JobBulk");
                //Session["JobBulk"] = "Update";
                //flag = "U";
            }

            Session["Jobno_Excel"] = IMPORT_JOBNO;
            Session["JOBIDexcel"] = Get_JOBID();
        }

        #endregion

        #region dt_gen        

        dt_gen.TableName = "GENERAL_DETAILS";
        data.Tables.Add(dt_gen);
        return dt_gen;

        #endregion
    }
    public DataTable Read_General_DetailsOld(DataTable General_data)
    {
        #region read from excel assign to variable

        DataRow dtRow = General_data.Rows[0];

        #region  FROM EXCEL

        JOBDATE = GetString(dtRow, "JOBDATE");
        TRANSPORT_MODE = GetString(dtRow, "TRANSPORT_MODE");
        BE_TYPE = GetString(dtRow, "BE_TYPE");
        CUSTOMS_HOUSE = GetString(dtRow, "CUSTOMS_HOUSE");
        CUSTOMS_HOUSE = string.IsNullOrWhiteSpace(CUSTOMS_HOUSE) ? Session["CUSTOMHOUSE_CODE"].ToString() : CUSTOMS_HOUSE;
        CONTAINER_TYPE = GetString(dtRow, "CONTAINER_TYPE");
        FILING_STATUS = GetString(dtRow, "FILING_STATUS");
        FILE_REF_NO = GetString(dtRow, "FILE_REF_NO");
        IEC_NO = GetString(dtRow, "IEC_NO");
        BRANCH_NO = GetString(dtRow, "BRANCH_NO");
        IMPORTER_NAME = GetString(dtRow, "IMPORTER_NAME");
        ADDRESS1 = GetString(dtRow, "ADDRESS1");
        ADDRESS2 = GetString(dtRow, "ADDRESS2");
        ADDRESS3 = GetString(dtRow, "ADDRESS3");
        ADDRESS4 = GetString(dtRow, "ADDRESS4");
        ADDRESS5 = GetString(dtRow, "ADDRESS5");
        ADCODE = GetString(dtRow, "ADCODE");
        COUNTRY_ORIGIN = GetString(dtRow, "COUNTRY_ORIGIN");
        PORT_ORIGIN = GetString(dtRow, "PORT_ORIGIN");
        COUNTRY_SHIPMENT = GetString(dtRow, "COUNTRY_SHIPMENT");
        COUNTRY_SHIPMENT = string.IsNullOrEmpty(COUNTRY_SHIPMENT) ? COUNTRY_ORIGIN : COUNTRY_SHIPMENT;
        PORT_SHIPMENT = GetString(dtRow, "PORT_SHIPMENT");
        PORT_SHIPMENT = string.IsNullOrEmpty(PORT_SHIPMENT) ? PORT_ORIGIN : PORT_SHIPMENT;
        SECTION46_DESC = GetString(dtRow, "SECTION46_DESC");
        FIRSTCHECK_DESC = GetString(dtRow, "FIRSTCHECK_DESC");
        GREEN_CHANNEL_DESC = GetString(dtRow, "GREEN_CHANNEL_DESC");
        KACHHA_BE_DESC = GetString(dtRow, "KACHHA_BE");
        KACHHA_BE = string.IsNullOrWhiteSpace(KACHHA_BE_DESC) ? "N" : "Y";
        SECTION48_DESC = GetString(dtRow, "SECTION48_DESC");
        HIGH_SEA_IEC = GetString(dtRow, "HIGH_SEA_IEC");
        HIGH_SEA_BRANCH_SL_NO = GetString(dtRow, "HIGH_SEA_BRANCH_SL_NO");
        HIGH_SEA_SALE_NAME = GetString(dtRow, "HIGH_SEA_SALE_NAME");
        HSS_ADD1 = GetString(dtRow, "HSS_ADD1");
        HSS_ADD2 = GetString(dtRow, "HSS_ADD2");
        HSS_ADD3 = GetString(dtRow, "HSS_ADD3");
        HSS_ADD4 = GetString(dtRow, "HSS_ADD4");
        HSS_ADD5 = GetString(dtRow, "HSS_ADD5");
        PRECEDING_LEVEL = GetString(dtRow, "PRECEDING_LEVEL");
        WAREHOUSE_CODE = GetString(dtRow, "WAREHOUSE_CODE");
        WAREHOUSE_CODE = WAREHOUSE_CODE.Contains('-') ? WAREHOUSE_CODE.Split('-')[0].TrimEnd() : WAREHOUSE_CODE;
        COMMERCIAL_TAX_STATECODE = GetString(dtRow, "COMMERCIAL_TAX_STATECODE");
        GSTN_TYPE = GetString(dtRow, "GSTN_TYPE");
        GSTN_ID = GetString(dtRow, "GSTN_ID");

        #endregion

        // End of Excel Data

        SECTION46 = string.IsNullOrWhiteSpace(SECTION46_DESC) ? "N" : "Y";
        FIRSTCHECK = string.IsNullOrWhiteSpace(FIRSTCHECK_DESC) ? "N" : "Y";
        GREEN_CHANNEL = string.IsNullOrWhiteSpace(GREEN_CHANNEL_DESC) ? "N" : "Y";
        SECTION48 = string.IsNullOrWhiteSpace(SECTION48_DESC) ? "N" : "Y";
        //WAREHOUSE_NAME = BE_TYPE == "Ex-Bond" ? "Yes" : "No";
        WAREHOUSE_NAME = string.Equals(BE_TYPE, "Ex-Bond", StringComparison.OrdinalIgnoreCase) ? "Yes" : "No";


        #endregion

        #region Check_Avail_IEC_Master

        int xx;
        xx = Check_Avail_IEC_Master(IEC_NO, BRANCH_NO);
        if (xx != 1)
        {
            IEC_INSERT_UPDATE(IEC_NO, BRANCH_NO, IMPORTER_NAME, ADDRESS1, ADDRESS2, ADDRESS3, ADDRESS4, ADDRESS5, "P", "", "","T");
        }
        else if (ADDRESS1 == "" && IEC_NO != "" && BRANCH_NO != "")
        {
            ds_IEC = Get_Importer_HSS_Details(IEC_NO, BRANCH_NO);
            if (ds_IEC.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds_IEC.Tables[0].Rows[0];
                IMPORTER_NAME = GetString(row, "IMP_EXP_NAME");
                ADDRESS1 = GetString(row, "IMP_EXP_ADD1");
                ADDRESS2 = GetString(row, "IMP_EXP_ADD2");
                ADDRESS3 = GetString(row, "IMP_EXP_ADD3");
                ADDRESS4 = GetString(row, "IMP_EXP_ADD4");
                ADDRESS5 = GetString(row, "IMP_EXP_PIN_CODE");
                COMMERCIAL_TAX = GetString(row, "M_COMMERCIAL_DETAILS_STATUS");
                COMMERCIAL_TAX_STATENAME = GetString(row, "M_COMMERCIAL_TAX_STATENAME");
                STATECODE = GetString(row, "M_COMMERCIAL_TAX_STATECODE");
                REGISTRATION_NO = GetString(row, "M_COMMERCIAL_TAX_REGISTRATION_NO");
                TYPE = GetString(row, "M_COMMERCIAL_TAX_TYPE");
            }
        }

        if (currentuser == "AURIONPRO")
        {
            ADDRESS1 = GetString(dtRow, "ADDRESS1");
            ADDRESS2 = GetString(dtRow, "ADDRESS2");
            ADDRESS3 = GetString(dtRow, "ADDRESS3");
            ADDRESS4 = GetString(dtRow, "ADDRESS4");
            ADDRESS5 = GetString(dtRow, "ADDRESS5");
        }

        #endregion

        #region COMMERCIAL_TAX != "Y"

        if (COMMERCIAL_TAX != "Y")
        {
            COMMERCIAL_TAX = "Y";
            STATECODE = COMMERCIAL_TAX_STATECODE;
            TYPE = GSTN_TYPE;
            REGISTRATION_NO = GSTN_ID;

            if (!string.IsNullOrWhiteSpace(STATECODE) && STATECODE.Contains('-'))
            {
                string[] stateCode = STATECODE.Split('-');
                if (stateCode.Length >= 2)
                {
                    STATECODE = stateCode[0].Trim();
                    COMMERCIAL_TAX_STATECODE = stateCode[0].Trim();
                    COMMERCIAL_TAX_STATENAME = stateCode[1].Trim();
                }
            }
            if (!string.IsNullOrWhiteSpace(TYPE) && TYPE.Contains('-'))
            {
                TYPE = TYPE.Split('-')[0].Trim();
            }
        }

        #endregion

        HIGH_SEA_SALE_NAME = GetString(dtRow, "HIGH_SEA_SALE_NAME"); 
        HSS_ADD1 = GetString(dtRow, "HSS_ADD1");
        //HSS_NAME = dtRow["HIGH_SEA_SALE_NAME"].ToString();
        //HSS_ADD1 = dtRow["HSS_ADD1"].ToString();

        #region Check_Avail_IEC_Master

        xx = Check_Avail_IEC_Master(HIGH_SEA_IEC, HIGH_SEA_BRANCH_SL_NO);

        if (xx != 1)
        {
            IEC_INSERT_UPDATE(HIGH_SEA_IEC, HIGH_SEA_BRANCH_SL_NO, HIGH_SEA_SALE_NAME, HSS_ADD1, HSS_ADD2, HSS_ADD3, HSS_ADD4, HSS_ADD5, "P", "", "","T");
        }

        if (xx == 1 && HSS_ADD1 == "" && HIGH_SEA_IEC != "" && HIGH_SEA_BRANCH_SL_NO != "")
        {
            ds_IEC = Get_Importer_HSS_Details(HIGH_SEA_IEC, HIGH_SEA_BRANCH_SL_NO);
            if (ds_IEC.Tables[0].Rows.Count > 0)
            {
                HIGH_SEA_SALE = "Y";
                DataRow rowIEC = ds_IEC.Tables[0].Rows[0];
                HIGH_SEA_SALE_NAME = GetString(rowIEC, "IMP_EXP_NAME");
                HSS_ADD1 = GetString(rowIEC, "IMP_EXP_ADD1");
                HSS_ADD2 = GetString(rowIEC, "IMP_EXP_ADD2");
                HSS_ADD3 = GetString(rowIEC, "IMP_EXP_ADD3");
                HSS_ADD4 = GetString(rowIEC, "IMP_EXP_ADD4");
                HSS_ADD5 = GetString(rowIEC, "IMP_EXP_PIN_CODE");
            }
        }
        else if (xx == 1 && HSS_ADD1 == "" && (HIGH_SEA_IEC == "" || HIGH_SEA_BRANCH_SL_NO == ""))
        {
            HIGH_SEA_SALE = "N";
            HIGH_SEA_BRANCH_SL_NO = "0";
        }


        #endregion

        if (currentuser == "AURIONPRO")
        {
            HIGH_SEA_SALE = "Y";
            HIGH_SEA_SALE_NAME = GetString(dtRow, "HIGH_SEA_SALE_NAME"); 
            HSS_ADD1 = GetString(dtRow, "HSS_ADD1");
            HSS_ADD2 = GetString(dtRow, "HSS_ADD2");
            HSS_ADD3 = GetString(dtRow, "HSS_ADD3");
            HSS_ADD4 = GetString(dtRow, "HSS_ADD4");
            HSS_ADD5 = GetString(dtRow, "HSS_ADD5");
        }

        PAYMENT_METHOD_CODE = "T";
        EXBOND_INBOND_BE_DATE = LoginDate;
        EXBOND_BOND_DATE = LoginDate;
        COMPLETED_DATE = LoginDate;
        DOC_RECEIVED_DATE = LoginDate;

        LoginSTATUS = "N";
        MODIFIEDBY = currentuser;
        MODIFIEDON = LoginDate;
        USERID = currentuser;

        if (HIGH_SEA_BRANCH_SL_NO == "")
        {
            HIGH_SEA_BRANCH_SL_NO = "0";
        }

        JobNo_Prefix_Sufix();


        #region insert into general table

        if (allErrors == null || allErrors.Rows.Count == 0)
        {
            var param = new[]
                 {
                     // ===== EXCEL DATA =====
                     new SqlParameter("@JOBDATE",        DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)),
                     new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE),
                     new SqlParameter("@BE_TYPE",        BE_TYPE),
                     new SqlParameter("@CUSTOMS_HOUSE",  CUSTOMS_HOUSE),
                     new SqlParameter("@CONTAINER_TYPE", CONTAINER_TYPE),
                     new SqlParameter("@FILING_STATUS",  FILING_STATUS),
                     new SqlParameter("@FILE_REF_NO",    FILE_REF_NO),
                     new SqlParameter("@IEC_NO",         IEC_NO),
                     new SqlParameter("@BRANCH_NO",      BRANCH_NO),//
                     new SqlParameter("@IMPORTER_NAME",  IMPORTER_NAME),
                     new SqlParameter("@ADDRESS1",       ADDRESS1),
                     new SqlParameter("@ADDRESS2",       ADDRESS2),
                     new SqlParameter("@ADDRESS3",       ADDRESS3),
                     new SqlParameter("@ADDRESS4",       ADDRESS4),
                     new SqlParameter("@ADDRESS5",       ADDRESS5),
                     new SqlParameter("@ADCODE",         ADCODE),
                     new SqlParameter("@COUNTRY_ORIGIN", COUNTRY_ORIGIN),
                     new SqlParameter("@PORT_ORIGIN",    PORT_ORIGIN),
                     new SqlParameter("@COUNTRY_SHIPMENT",       COUNTRY_SHIPMENT),
                     new SqlParameter("@PORT_SHIPMENT",          PORT_SHIPMENT),
                     new SqlParameter("@SECTION46_DESC",         SECTION46_DESC),  
                     new SqlParameter("@FIRSTCHECK_DESC",        FIRSTCHECK_DESC),
                     new SqlParameter("@GREEN_CHANNEL_DESC",     GREEN_CHANNEL_DESC),
                     new SqlParameter("@KACHHA_BE",              KACHHA_BE),
                     new SqlParameter("@SECTION48_DESC",         SECTION48_DESC),
                     new SqlParameter("@HIGH_SEA_IEC",           HIGH_SEA_IEC),
                     new SqlParameter("@HIGH_SEA_BRANCH_SL_NO",  HIGH_SEA_BRANCH_SL_NO),//
                     new SqlParameter("@HIGH_SEA_SALE_NAME",     HIGH_SEA_SALE_NAME),
                     new SqlParameter("@HSS_ADD1",               HSS_ADD1),
                     new SqlParameter("@HSS_ADD2",               HSS_ADD2),
                     new SqlParameter("@HSS_ADD3",               HSS_ADD3),
                     new SqlParameter("@HSS_ADD4",               HSS_ADD4),
                     new SqlParameter("@HSS_ADD5",               HSS_ADD5),
                     new SqlParameter("@PRECEDING_LEVEL",        PRECEDING_LEVEL),
                     new SqlParameter("@WAREHOUSE_CODE",         WAREHOUSE_CODE),
                     new SqlParameter("@COMMERCIAL_TAX_STATECODE", COMMERCIAL_TAX_STATECODE),
                     new SqlParameter("@GSTN_TYPE",              GSTN_TYPE),
                     new SqlParameter("@GSTN_ID",                GSTN_ID),
                     new SqlParameter("@JOBNO",                  IMPORT_JOBNO),//
                     new SqlParameter("@CUSTOMS_HOUSE_NAME",     Connection.Get_Company_Type()),//CUSTOMS_HOUSE_NAME
                     new SqlParameter("@SECTION46",              SECTION46),
                     new SqlParameter("@FIRSTCHECK",             FIRSTCHECK),
                     new SqlParameter("@GREEN_CHANNEL",          GREEN_CHANNEL),
                     new SqlParameter("@KACHHA_BE_DESC",         KACHHA_BE_DESC),
                     new SqlParameter("@SECTION48",              SECTION48),
                     new SqlParameter("@HIGH_SEA_SALE",          HIGH_SEA_SALE),
                     new SqlParameter("@WAREHOUSE_NAME",         WAREHOUSE_NAME),
                     new SqlParameter("@IMP_EXP_TYPE",           IMP_EXP_TYPE),
                     new SqlParameter("@COMMERCIAL_DETAILS_STATUS",      COMMERCIAL_TAX),
                     new SqlParameter("@COMMERCIAL_TAX_STATENAME",       COMMERCIAL_TAX_STATENAME),
                     new SqlParameter("@COMMERCIAL_TAX_TYPE",            TYPE),
                     new SqlParameter("@COMMERCIAL_TAX_REGISTRATION_NO", REGISTRATION_NO),
                     new SqlParameter("@EXBOND_INBOND_BE_NO",            EXBOND_INBOND_BE_NO),
                     new SqlParameter("@EXBOND_INBOND_BE_DATE",          DateTime.Parse(EXBOND_INBOND_BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)),
                     new SqlParameter("@EXBOND_BOND_NO",                 EXBOND_BOND_NO),
                     new SqlParameter("@EXBOND_BOND_DATE",               DateTime.Parse(EXBOND_BOND_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)),
                     new SqlParameter("@EXBOND_WAREHOUSE_CUSTOMS",       EXBOND_WAREHOUSE_CUSTOMS),
                     new SqlParameter("@EXBOND_WAREHOUSE_CUSTOMS_CODE",  EXBOND_WAREHOUSE_CUSTOMS_CODE),
                     new SqlParameter("@EXBOND_NOOFPACKAGE",             EXBOND_NOOFPACKAGE),
                     new SqlParameter("@EXBOND_NOOFPACKAGE_UNITCODE",    EXBOND_NOOFPACKAGE_UNITCODE),
                     new SqlParameter("@EXBOND_GROSS_WEIGHT",            string.IsNullOrEmpty(EXBOND_GROSS_WEIGHT) ? "0" : EXBOND_GROSS_WEIGHT),//Convert.ToDecimal(EXBOND_GROSS_WEIGHT)
                     new SqlParameter("@EXBOND_GROSS_WEIGHT_UNITCODE",   EXBOND_GROSS_WEIGHT_UNITCODE),
                     new SqlParameter("@EXBOND_DIRECT_EXBONDING",        EXBOND_DIRECT_EXBONDING),
                     new SqlParameter("@EXBOND_ADDL_LOAD_HSS",           EXBOND_ADDL_LOAD_HSS), 
                     new SqlParameter("@EXBOND_MISC_LOAD_RATE",          EXBOND_MISC_LOAD_RATE),
                     new SqlParameter("@REMARKS",            REMARKS),
                     new SqlParameter("@USERID",             currentuser),   
                     new SqlParameter("@BRANCHCODE",         currentbranch),
                     new SqlParameter("@WORKINGPERIOD",      Working_Period),
                     new SqlParameter("@BRANCH_COMMON",      SELECT_BRANCH),
                     new SqlParameter("@JOBNO_PS",           JOBNO_PS), 
                     new SqlParameter("@JOB_PREFIX",         JOB_PREFIX),
                     new SqlParameter("@JOB_SUFFIX",         JOB_SUFFIX),    
                     new SqlParameter("@AMENDMENT_STATUS",  ""),
                     new SqlParameter("@GRP_ID",            HttpContext.Current.Session["GroupID"].ToString()),    
                     new SqlParameter("@Company_id",        "1"),
                     new SqlParameter("@Mflag",             flag),
                 
                     new SqlParameter("@MStatus",    SqlDbType.Int)    { Direction = ParameterDirection.Output },
                     new SqlParameter("@ErrorMsg",   SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output },
                     new SqlParameter("@Update_Id",  SqlDbType.BigInt) { Direction = ParameterDirection.Output },  
                 };

            if (flag == "U")
            {
                DeleteJobDataByTable("GENERAL_DETAILS");
            }


            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_INSERT_UPDATE_BULK", param);

            int result = Convert.ToInt32(param.First(p => p.ParameterName == "@MStatus").Value);
            string errorMsg = param.First(p => p.ParameterName == "@ErrorMsg").Value.ToString();

            if (flag == "S")
            {
                IMPORT_JOBNO = param.First(p => p.ParameterName == "@Update_Id").Value.ToString();
                //flag = "U";
            }

            Session["Jobno_Excel"] = IMPORT_JOBNO;
            Session["JOBIDexcel"] = Get_JOBID();
        }

        #endregion


        #region dt_gen
        /*
        string[] genColumns = new string[] { "JOBID", "JOBNO", "JOBDATE", "TRANSPORT_MODE", "BE_TYPE", "CUSTOMS_HOUSE", "CUSTOMS_HOUSE_NAME", "IMPORTER_NAME", "ADDRESS1", "ADDRESS2", 
            "ADDRESS3", "ADDRESS4", "ADDRESS5", "IEC_NO", "BRANCH_NO", "COUNTRY_ORIGIN", "PORT_ORIGIN", "PORT_SHIPMENT", "COUNTRY_SHIPMENT", "FILING_STATUS", "SECTION46", 
            "SECTION46_DESC", "FIRSTCHECK", "FIRSTCHECK_DESC", "GREEN_CHANNEL", "GREEN_CHANNEL_DESC", "KACHHA_BE", "KACHHA_BE_DESC", "SECTION48", "SECTION48_DESC", "HIGH_SEA_SALE", 
            "HIGH_SEA_SALE_NAME", "HIGH_SEA_IEC", "HIGH_SEA_BRANCH_SL_NO", "HSS_ADD1", "HSS_ADD2", "HSS_ADD3", "HSS_ADD4", "HSS_ADD5", "WAREHOUSE_NAME", "WAREHOUSE_CODE", 
            "IMP_EXP_TYPE", "COMMERCIAL_DETAILS_STATUS", "COMMERCIAL_TAX_STATENAME", "COMMERCIAL_TAX_STATECODE", "COMMERCIAL_TAX_TYPE", "COMMERCIAL_TAX_REGISTRATION_NO", 
            "EXBOND_INBOND_BE_NO", "EXBOND_INBOND_BE_DATE", "EXBOND_BOND_NO", "EXBOND_BOND_DATE", "EXBOND_WAREHOUSE_CUSTOMS", "EXBOND_WAREHOUSE_CUSTOMS_CODE", "EXBOND_NOOFPACKAGE", 
            "EXBOND_NOOFPACKAGE_UNITCODE", "EXBOND_GROSS_WEIGHT", "EXBOND_GROSS_WEIGHT_UNITCODE", "EXBOND_DIRECT_EXBONDING", "REMARKS", "USERID", "LoginDate", "LoginSTATUS", 
            "BRANCHCODE", "WORKINGPERIOD", "FILE_REF_NO", "CONTAINER_TYPE", "JOB_STATUS", "JOB_RELEASE", "JOB_FILED_STATUS", "MODIFIEDBY", "MODIFIEDON", "JOB_PREFIX", "JOB_SUFFIX", 
            "JOBNO_PS", "COMPLETED_DATE", "ADCODE", "UCR_NO", "UCR_TYPE", "PAYMENT_METHOD_CODE", "PRECEDING_LEVEL", "DOC_RECEIVED_DATE", "AGENT_NAME", "EXBOND_ADDL_LOAD_HSS", 
            "EXBOND_MISC_LOAD_RATE", "GSTN_TYPE", "GSTN_ID" };

        foreach (string col in genColumns)
            dt_gen.Columns.Add(col);

                

        


        dt_gen.Rows.Add(MAX_ID, IMPORT_JOBNO, JOBDATE, TRANSPORT_MODE, BE_TYPE, CUSTOMS_HOUSE, CUSTOMS_HOUSE_NAME, IMPORTER_NAME, ADDRESS1, ADDRESS2, ADDRESS3, ADDRESS4, ADDRESS5,
                        IEC_NO, BRANCH_NO, COUNTRY_ORIGIN, PORT_ORIGIN, PORT_SHIPMENT, COUNTRY_SHIPMENT, FILING_STATUS, SECTION46, SECTION46_DESC, FIRSTCHECK, FIRSTCHECK_DESC,
                        GREEN_CHANNEL, GREEN_CHANNEL_DESC, KACHHA_BE, KACHHA_BE_DESC, SECTION48, SECTION48_DESC, HIGH_SEA_SALE, HIGH_SEA_SALE_NAME, HIGH_SEA_IEC, HIGH_SEA_BRANCH_SL_NO,
                        HSS_ADD1, HSS_ADD2, HSS_ADD3, HSS_ADD4, HSS_ADD5, WAREHOUSE_NAME, WAREHOUSE_CODE, IMP_EXP_TYPE, COMMERCIAL_TAX, COMMERCIAL_TAX_STATENAME, STATECODE,
                        TYPE, REGISTRATION_NO, EXBOND_INBOND_BE_NO, EXBOND_INBOND_BE_DATE, EXBOND_BOND_NO, EXBOND_BOND_DATE, EXBOND_WAREHOUSE_CUSTOMS, EXBOND_WAREHOUSE_CUSTOMS_CODE,
                        EXBOND_NOOFPACKAGE, EXBOND_NOOFPACKAGE_UNITCODE, EXBOND_GROSS_WEIGHT, EXBOND_GROSS_WEIGHT_UNITCODE, EXBOND_DIRECT_EXBONDING, REMARKS, currentuser, LoginDate,
                        "N", currentbranch, Working_Period, FILE_REF_NO, CONTAINER_TYPE, JOB_STATUS, JOB_RELEASE, JOB_FILED_STATUS, currentuser, LoginDate, JOB_PREFIX, JOB_SUFFIX, JOBNO_PS,
                        COMPLETED_DATE, ADCODE, UCR_NO, UCR_TYPE, PAYMENT_METHOD_CODE, PRECEDING_LEVEL, DOC_RECEIVED_DATE, AGENT_NAME, EXBOND_ADDL_LOAD_HSS, EXBOND_MISC_LOAD_RATE, GSTN_TYPE, GSTN_ID);
        */

        dt_gen.TableName = "GENERAL_DETAILS";
        data.Tables.Add(dt_gen);          
        return dt_gen;

        #endregion
    }

    public DataTable Read_IGM_DetailsOld(DataTable IGM_Data)
    {
        #region dt_IGM

        string[] igmColumns = new string[] { "IGM_ID", "IGM_SLNO", "JOBNO", "IGM_JOBDATE", "IGM_AIRLINECODE", "IGM_AIRLINENAME", "IGM_FLIGHTNO_VESSELNO", "IGM_FLIGHT_VESSELDATE", 
            "IGM_NO", "IGM_DATE", "IGM_MAWB_MBL", "IGM_MAWB_MBLDATE", "IGM_HAWB_HBLNO", "IGM_HAWB_HBLDATE", "IGM_NOOFPACKAGE", "IGM_PACKAGETYPE", "IGM_GROSSWEIGHT", 
            "IGM_TYPEOFWEIGHT", "IGM_NETWEIGHT", "IGM_NETWEIGHTTYPE", "IGM_TRANSPORTMODE", "IGM_MARKSNOS", "IGM_GATEWAY_IGM_NO", "IGM_GATEWAY_IGM_DATE", "IGM_GATEWAY_PORT_CODE", 
            "IGM_USER_ID", "IGM_DATE_TIME", "IGM_STATUS", "IGM_BRANCH_CODE", "IGM_YEAR", "IGM_WORKING_PERIOD", "MODIFIEDBY", "MODIFIEDON", "IGM_LINE_NUMBER", 
            "IGM_SHIPPING_LINE_NUMBER", "IGM_VOYAGE", "IGM_CHARGEABLE_WGT" };

        foreach (string col in igmColumns)
            dt_IGM.Columns.Add(col);

        #endregion

        for (int i = 0; i <= IGM_Data.Rows.Count - 1; i++)
        {
            DataRow row = IGM_Data.Rows[i];

            IGM_SLNO = Convert.ToString(i + 1);
            IGM_JOBDATE = JOBDATE;
            IGM_JOBDATE = string.IsNullOrEmpty(JOBDATE) ? "01/01/1900" : JOBDATE;


            #region FROM EXCEL

            IGM_AIRLINECODE = GetString(row, "IGM_AIRLINECODE");
            IGM_AIRLINENAME = GetString(row, "IGM_AIRLINENAME");
            IGM_FLIGHTNO_VESSELNO = GetString(row, "IGM_FLIGHTNO_VESSELNO");
            IGM_FLIGHT_VESSELDATE = GetString(row, "IGM_FLIGHT_VESSELDATE");
            IGM_FLIGHT_VESSELDATE = string.IsNullOrEmpty(IGM_FLIGHT_VESSELDATE) ? "01/01/1900" : IGM_FLIGHT_VESSELDATE;
            IGM_NO = GetString(row, "IGM_NO");
            IGM_DATE = GetString(row, "IGM_DATE");
            IGM_DATE = string.IsNullOrEmpty(IGM_DATE) ? "01/01/1900" : IGM_DATE;
            IGM_MAWB_MBL = GetString(row, "IGM_MAWB_MBL");
            IGM_MAWB_MBLDATE = GetString(row, "IGM_MAWB_MBLDATE");
            IGM_MAWB_MBLDATE = string.IsNullOrEmpty(IGM_MAWB_MBLDATE) ? "01/01/1900" : IGM_MAWB_MBLDATE;
            IGM_HAWB_HBLNO = GetString(row, "IGM_HAWB_HBLNO");
            IGM_HAWB_HBLDATE = GetString(row, "IGM_HAWB_HBLDATE");
            IGM_HAWB_HBLDATE = string.IsNullOrEmpty(IGM_HAWB_HBLDATE) ? "01/01/1900" : IGM_HAWB_HBLDATE;
            IGM_NOOFPACKAGE = GetString(row, "IGM_NOOFPACKAGE");
            IGM_PACKAGETYPE = GetString(row, "IGM_PACKAGETYPE");
            IGM_GROSSWEIGHT = GetString(row, "IGM_GROSSWEIGHT");
            IGM_TYPEOFWEIGHT = GetString(row, "IGM_TYPEOFWEIGHT");
            IGM_MARKSNOS = GetString(row, "IGM_MARKSNOS");
            IGM_GATEWAY_IGM_NO = GetString(row, "IGM_GATEWAY_IGM_NO");
            IGM_GATEWAY_IGM_DATE = GetString(row, "IGM_GATEWAY_IGM_DATE");
            IGM_GATEWAY_IGM_DATE = string.IsNullOrEmpty(IGM_GATEWAY_IGM_DATE) ? "01/01/1900" : IGM_GATEWAY_IGM_DATE;
            IGM_GATEWAY_PORT_CODE = GetString(row, "IGM_GATEWAY_PORT_CODE");
            IGM_LINE_NUMBER = GetString(row, "IGM_LINE_NUMBER");
            IGM_SHIPPING_LINE_NUMBER = GetString(row, "IGM_SHIPPING_LINE_NUMBER");
            IGM_VOYAGE = GetString(row, "IGM_VOYAGE");
            IGM_CHARGEABLE_WGT = GetString(row, "IGM_CHARGEABLE_WGT");            

            #endregion

            IGM_NETWEIGHT = "0.00";
            IGM_NETWEIGHTTYPE = "";            
            if (Session["TRANSPORT_MODE"] != null)
            {
                IGM_TRANSPORTMODE = Session["TRANSPORT_MODE"].ToString();
            }
            else if (Session["Transport_Mode_Port"].ToString() != null)
            {
                IGM_TRANSPORTMODE = Session["Transport_Mode_Port"].ToString();
            }

            MAX_ID = Get_general_MAXID("IGM_MAX_ID");
            //Get_IGM_NO_DATE(IGM_SLNO); // Hidden by George Bush on 30-06-2026


            IGM_NO = string.IsNullOrWhiteSpace(IGM_NO) ? "0" : IGM_NO.Trim();
            IGM_DATE = string.IsNullOrEmpty(IGM_DATE) ? "01/01/1900" : IGM_DATE;
            

            dt_IGM.Rows.Add(MAX_ID + i, IGM_SLNO, IMPORT_JOBNO, IGM_JOBDATE, IGM_AIRLINECODE, IGM_AIRLINENAME, IGM_FLIGHTNO_VESSELNO, IGM_FLIGHT_VESSELDATE, IGM_NO, IGM_DATE,
                             IGM_MAWB_MBL, IGM_MAWB_MBLDATE, IGM_HAWB_HBLNO, IGM_HAWB_HBLDATE, IGM_NOOFPACKAGE, IGM_PACKAGETYPE, IGM_GROSSWEIGHT, IGM_TYPEOFWEIGHT, IGM_NETWEIGHT, 
                             IGM_NETWEIGHTTYPE,IGM_TRANSPORTMODE, IGM_MARKSNOS, IGM_GATEWAY_IGM_NO, IGM_GATEWAY_IGM_DATE, IGM_GATEWAY_PORT_CODE, currentuser, LoginDate, "N", 
                             currentbranch, "", Working_Period, currentuser, LoginDate, IGM_LINE_NUMBER, IGM_SHIPPING_LINE_NUMBER, IGM_VOYAGE, IGM_CHARGEABLE_WGT);
        }

        dt_IGM.TableName = "IGM_DETAILS";
        data.Tables.Add(dt_IGM);
        return dt_IGM;

    }
    public DataTable Read_IGM_Details(DataTable IGM_Data)
    {
        #region dt_IGM

        string[] igmColumns = new string[] { "IGM_ID", "IGM_SLNO", "JOBNO", "IGM_JOBDATE", "IGM_AIRLINECODE", "IGM_AIRLINENAME", "IGM_FLIGHTNO_VESSELNO", "IGM_FLIGHT_VESSELDATE", 
            "IGM_NO", "IGM_DATE", "IGM_MAWB_MBL", "IGM_MAWB_MBLDATE", "IGM_HAWB_HBLNO", "IGM_HAWB_HBLDATE", "IGM_NOOFPACKAGE", "IGM_PACKAGETYPE", "IGM_GROSSWEIGHT", 
            "IGM_TYPEOFWEIGHT", "IGM_NETWEIGHT", "IGM_NETWEIGHTTYPE", "IGM_TRANSPORTMODE", "IGM_MARKSNOS", "IGM_GATEWAY_IGM_NO", "IGM_GATEWAY_IGM_DATE", "IGM_GATEWAY_PORT_CODE", 
            "IGM_USER_ID", "IGM_DATE_TIME", "IGM_STATUS", "IGM_BRANCH_CODE", "IGM_YEAR", "IGM_WORKING_PERIOD", "MODIFIEDBY", "MODIFIEDON", "IGM_LINE_NUMBER", 
            "IGM_SHIPPING_LINE_NUMBER", "IGM_VOYAGE", "IGM_CHARGEABLE_WGT" };

        foreach (string col in igmColumns)
            dt_IGM.Columns.Add(col);

        #endregion

        for (int i = 0; i <= IGM_Data.Rows.Count - 1; i++)
        {
            DataRow row = IGM_Data.Rows[i];

            IGM_SLNO = Convert.ToString(i + 1);
            IGM_JOBDATE = JOBDATE;
            IGM_JOBDATE = string.IsNullOrEmpty(JOBDATE) ? "01/01/1900" : JOBDATE;


            #region FROM EXCEL

            IGM_AIRLINECODE = GetString(row, "IGM_AIRLINECODE");//AIRLINECODE
            IGM_AIRLINENAME = GetString(row, "IGM_AIRLINENAME");//AIRLINENAME
            IGM_FLIGHTNO_VESSELNO = GetString(row, "IGM_FLIGHTNO_VESSELNO");
            IGM_FLIGHT_VESSELDATE = GetString(row, "IGM_FLIGHT_VESSELDATE");//FLIGHT_INWARD_DATE
            IGM_FLIGHT_VESSELDATE = string.IsNullOrEmpty(IGM_FLIGHT_VESSELDATE) ? "01/01/1900" : IGM_FLIGHT_VESSELDATE;
            IGM_NO = GetString(row, "IGM_NO");
            IGM_DATE = GetString(row, "IGM_DATE");
            IGM_DATE = string.IsNullOrEmpty(IGM_DATE) ? "01/01/1900" : IGM_DATE;
            IGM_MAWB_MBL = GetString(row, "IGM_MAWB_MBL");//MAWB_MBL_NO
            IGM_MAWB_MBLDATE = GetString(row, "IGM_MAWB_MBLDATE");//MAWB_MBL_DATE
            IGM_MAWB_MBLDATE = string.IsNullOrEmpty(IGM_MAWB_MBLDATE) ? "01/01/1900" : IGM_MAWB_MBLDATE;
            IGM_HAWB_HBLNO = GetString(row, "IGM_HAWB_HBLNO");//HAWB_HBL_NO
            IGM_HAWB_HBLDATE = GetString(row, "IGM_HAWB_HBLDATE");//HAWB_HBL_DATE
            IGM_HAWB_HBLDATE = string.IsNullOrEmpty(IGM_HAWB_HBLDATE) ? "01/01/1900" : IGM_HAWB_HBLDATE;
            IGM_NOOFPACKAGE = GetString(row, "IGM_NOOFPACKAGE");//PACKAGES
            IGM_PACKAGETYPE = GetString(row, "IGM_PACKAGETYPE");//PACKAGE_TYPE
            IGM_GROSSWEIGHT = GetString(row, "IGM_GROSSWEIGHT");//GROSS_WEIGHT
            IGM_TYPEOFWEIGHT = GetString(row, "IGM_TYPEOFWEIGHT");//GROSS_WEIGHT_TYPE
            IGM_MARKSNOS = GetString(row, "IGM_MARKSNOS");//MARKS_NOS
            IGM_GATEWAY_IGM_NO = GetString(row, "IGM_GATEWAY_IGM_NO");//GATEWAY_IGM_NO
            IGM_GATEWAY_IGM_DATE = GetString(row, "IGM_GATEWAY_IGM_DATE");//GATEWAY_IGM_DATE
            IGM_GATEWAY_IGM_DATE = string.IsNullOrEmpty(IGM_GATEWAY_IGM_DATE) ? "01/01/1900" : IGM_GATEWAY_IGM_DATE;
            IGM_GATEWAY_PORT_CODE = GetString(row, "IGM_GATEWAY_PORT_CODE");//GATEWAY_PORT_CODE
            IGM_LINE_NUMBER = GetString(row, "IGM_LINE_NUMBER");//LINE_NUMBER
            IGM_SHIPPING_LINE_NUMBER = GetString(row, "IGM_SHIPPING_LINE_NUMBER");//SHIPPING_LINE
            IGM_VOYAGE = GetString(row, "IGM_VOYAGE");//VOYAGE
            IGM_CHARGEABLE_WGT = GetString(row, "IGM_CHARGEABLE_WGT");//CHARGEABLE_WGT

            #endregion

            IGM_NETWEIGHT = "0.00";
            IGM_NETWEIGHTTYPE = "";
            //if (Session["TRANSPORT_MODE"] != null) // selected from dropdowm
            //{
            //    IGM_TRANSPORTMODE = Session["TRANSPORT_MODE"].ToString();
            //}
            //else if (Session["Transport_Mode_Port"].ToString() != null) // selected from db
            //{
            //    IGM_TRANSPORTMODE = Session["Transport_Mode_Port"].ToString();
            //}

            IGM_TRANSPORTMODE = generalTransportMode;

            MAX_ID = Get_general_MAXID("IGM_MAX_ID");
            //Get_IGM_NO_DATE(IGM_SLNO); // Hidden by George Bush on 30-06-2026


            IGM_NO = string.IsNullOrWhiteSpace(IGM_NO) ? "0" : IGM_NO.Trim();
            IGM_DATE = string.IsNullOrEmpty(IGM_DATE) ? "01/01/1900" : IGM_DATE;


            dt_IGM.Rows.Add(MAX_ID + i, IGM_SLNO, IMPORT_JOBNO, IGM_JOBDATE, IGM_AIRLINECODE, IGM_AIRLINENAME, IGM_FLIGHTNO_VESSELNO, IGM_FLIGHT_VESSELDATE, IGM_NO, IGM_DATE,
                             IGM_MAWB_MBL, IGM_MAWB_MBLDATE, IGM_HAWB_HBLNO, IGM_HAWB_HBLDATE, IGM_NOOFPACKAGE, IGM_PACKAGETYPE, IGM_GROSSWEIGHT, IGM_TYPEOFWEIGHT, IGM_NETWEIGHT,
                             IGM_NETWEIGHTTYPE, IGM_TRANSPORTMODE, IGM_MARKSNOS, IGM_GATEWAY_IGM_NO, IGM_GATEWAY_IGM_DATE, IGM_GATEWAY_PORT_CODE, currentuser, LoginDate, "N",
                             currentbranch, "", Working_Period, currentuser, LoginDate, IGM_LINE_NUMBER, IGM_SHIPPING_LINE_NUMBER, IGM_VOYAGE, IGM_CHARGEABLE_WGT);
        }

        dt_IGM.TableName = "IGM_DETAILS";
        data.Tables.Add(dt_IGM);
        return dt_IGM;

    }

    public DataTable Read_Container_Details(DataTable CONT_Data)
    {
        #region dt_CONT

        string[] contColumns = new string[] { "CONTAINERID", "CONTAINER_IGM_SLNO", "CONTAINER_IGM_NO", "CONTAINER_IGM_DATE", "JOBNO", "CONTAINER_NO", "SEAL_NO", "FCL_OR_LCL", 
            "USER_ID", "DATE_TIME", "STATUS", "BRANCH_CODE", "YEAR", "WORKING_PERIOD", "TYPE", "TRUCK_NO", "MODIFIEDBY", "MODIFIEDON" };

        foreach (string col in contColumns)
            dt_CONT.Columns.Add(col);

        #endregion

        //string igmNo = string.IsNullOrWhiteSpace(IGM_NO) ? "0" : IGM_NO;
        //string igmDate = string.IsNullOrWhiteSpace(IGM_DATE) ? "01/01/1900" : IGM_DATE;
        //CONTAINER_IGM_NO = igmNo;
        //CONTAINER_IGM_DATE = igmDate;

        for (int i = 0; i <= CONT_Data.Rows.Count - 1; i++)
        {
            DataRow row = CONT_Data.Rows[i];
            CONTAINER_IGM_NO = string.IsNullOrWhiteSpace(GetString(row, "CONTAINER_IGM_NO")) ? "0" : GetString(row, "CONTAINER_IGM_NO"); ;
            CONTAINER_IGM_DATE = string.IsNullOrWhiteSpace(GetString(row, "CONTAINER_IGM_DATE")) ? "01/01/1900" : GetString(row, "CONTAINER_IGM_DATE");
            CONTAINER_IGM_SLNO = GetString(row, "CONTAINER_IGM_SLNO");//SLNO
            CONTAINER_NO = GetString(row, "CONTAINER_NO");
            SEAL_NO = GetString(row, "SEAL_NO");
            FCL_OR_LCL = GetString(row, "FCL_OR_LCL");
            TYPE = GetString(row, "TYPE");
            TRUCK_NO = GetString(row, "TRUCK_NO");

            MAX_ID = Get_general_MAXID("CONTAINER_MAX_ID");

            dt_CONT.Rows.Add(MAX_ID + i, CONTAINER_IGM_SLNO, CONTAINER_IGM_NO, CONTAINER_IGM_DATE, IMPORT_JOBNO, CONTAINER_NO, SEAL_NO, FCL_OR_LCL, currentuser, LoginDate,
                               "N", currentbranch, "", Working_Period, TYPE, TRUCK_NO, currentuser, LoginDate);
           
        }

        dt_CONT.TableName = "CONTAINER_DETAILS";
        data.Tables.Add(dt_CONT);
        return dt_CONT;
    }

    public DataTable Read_Reimport_Details(DataTable REIMP_Data)
    { 
        #region 

        DataSet d = new DataSet();
        RE_IMP.JOBNO = IMPORT_JOBNO;
        RE_IMP.flag = "Excel_Avail";        
        RE_IMP.BRANCH_CODE = Connection.Current_Branch();

        d = RE_IMP_OBJ.Re_Import_XL(RE_IMP);

        if (flag == "S" && d.Tables[0].Rows.Count > 0)
        {            
            string jobs = string.Join(",", d.Tables[0].AsEnumerable().Select(r => r["JOBNO"].ToString()));           
            
            AddError("RE_IMPORT", "JOBNO already exists.", "", jobs);
            return d.Tables[0];
        }
        else
        {
            DataTable dtReImp = ReImp_Excel_Upload(REIMP_Data);
            dtReImp.TableName = "RE_IMPORT_DETAILS";
            data.Tables.Add(dtReImp);
            return dtReImp;
        }        

        #endregion
    }

    public DataTable Read_SW_Info(DataTable SW_Data)
    {

        #region dt_SW_INFO

        string[] swInfoColumns = new string[] { "SW_INFO_TYPE_ID", "JOBNO", "INVOICE_SLNO", "ITEM_SLNO", "INFO_TYPE", "INFO_QUALIFIER", "INFO_CODE", "INFO_TEXT", 
            "INFO_MSR", "INFO_UQC", "USER_ID", "DATE_TIME", "STATUS", "BRANCH_CODE", "YEAR", "WORKING_PERIOD", "MODIFIEDBY", "MODIFIEDON", "DEPARTMENT", "I_U_TYPE", 
            "REGN_DATE", "REGN_VALIDITY" };

        foreach (string col in swInfoColumns)
            dt_SW_INFO.Columns.Add(col);

        #endregion dt_SW_INFO

        for (int i = 0; i <= SW_Data.Rows.Count - 1; i++)
        {

            #region getting from excel

            DataRow row = SW_Data.Rows[i];           

            INVOICE_SLNO = GetString(row, "INVOICE_SLNO");
            ITEM_SLNO = GetString(row, "ITEM_SLNO");
            DEPARTMENT = GetString(row, "DEPARTMENT");
            string val4 = GetString(row, "INFO_TYPE");
            string val5 = GetString(row, "INFO_QUALIFIER");
            string val6 = GetString(row, "INFO_CODE");
            INFO_TYPE = val4.Length > 0 ? val4.Substring(0, Math.Min(3, val4.Length)) : "";
            INFO_QUALIFIER = val5; 
            INFO_CODE = val6; 
            INFO_TEXT = GetString(row, "INFO_TEXT");
            INFO_MSR = GetString(row, "INFO_MSR");
            INFO_UQC = GetString(row, "INFO_UQC");
            //REGN_DATE = GetString(row, "REGN_DATE");            
            //REGN_DATE = string.IsNullOrEmpty(REGN_DATE) ? "01/01/1900" : REGN_DATE;
            //REGN_VALIDITY = GetString(row, "REGN_VALIDITY");

            if (INFO_CODE == "SIUNAPL")
            {
                REGN_DATE = GetString(row, "REGN_DATE"); 
                REGN_DATE = string.IsNullOrEmpty(REGN_DATE) ? "01/01/1900" : REGN_DATE;
                REGN_VALIDITY = GetString(row, "REGN_VALIDITY");
            }
            else
            {
                REGN_DATE = "01/01/1900";
                REGN_VALIDITY = "";
            }

            I_U_TYPE = "N";

            #endregion            

            if (INFO_TYPE != "")
            {
                MAX_ID = Get_general_MAXID("SINGLEWINDOW_INFO_MAX_ID");

                dt_SW_INFO.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, INFO_TYPE, INFO_QUALIFIER, INFO_CODE, INFO_TEXT, INFO_MSR, INFO_UQC,
                                     currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate, DEPARTMENT, I_U_TYPE, REGN_DATE, REGN_VALIDITY);
            }
        }

        dt_SW_INFO.TableName = "BE_ITEM_SW_INFO_TYPE";
        data.Tables.Add(dt_SW_INFO);
        return dt_SW_INFO;
    }

    public DataTable Read_SW_Constituent(DataTable SW_Data)
    {

        #region dt_SW_CONSTITUENT

        string[] swConstColumns = new string[] {"SW_CONST_ID","JOBNO","INVOICE_SLNO","ITEM_SLNO","CONSTITUENT_SRNO","CONSTITUENT_ELEMENT_NAME","CONSTITUENT_ELEMENT_CODE",
            "CONSTITUENT_PERCENTAGE","CONSTITUENT_YIELD_PERCENTAGE","ACTIVE_INGREDIENT","USER_ID","DATE_TIME","STATUS","BRANCH_CODE","YEAR","WORKING_PERIOD","MODIFIEDBY",
            "MODIFIEDON" };

        foreach (string col in swConstColumns)
            dt_SW_CONST.Columns.Add(col);

        #endregion dt_SW_CONSTITUENT

        for (int i = 0; i <= SW_Data.Rows.Count - 1; i++)
        {
            DataRow row = SW_Data.Rows[i];

            INVOICE_SLNO = GetString(row, "INVOICE_SLNO");
            ITEM_SLNO = GetString(row, "ITEM_SLNO");
            CONSTITUENT_SRNO = GetString(row, "CONSTITUENT_SRNO");
            CONSTITUENT_ELEMENT_NAME = GetString(row, "CONSTITUENT_ELEMENT_NAME");
            CONSTITUENT_ELEMENT_CODE = GetString(row, "CONSTITUENT_ELEMENT_CODE");
            CONSTITUENT_PERCENTAGE = GetString(row, "CONSTITUENT_PERCENTAGE");
            CONSTITUENT_YIELD_PERCENTAGE = GetString(row, "CONSTITUENT_YIELD_PERCENTAGE");
            ACTIVE_INGREDIENT = GetString(row, "ACTIVE_INGREDIENT");

            MAX_ID = Get_general_MAXID("SINGLEWINDOW_CONSTITUENT_MAX_ID");

            dt_SW_CONST.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, CONSTITUENT_SRNO, CONSTITUENT_ELEMENT_NAME, CONSTITUENT_ELEMENT_CODE, CONSTITUENT_PERCENTAGE, CONSTITUENT_YIELD_PERCENTAGE, ACTIVE_INGREDIENT,
                             currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);
        }

        dt_SW_CONST.TableName = "BE_ITEM_SW_CONST";
        data.Tables.Add(dt_SW_CONST);
        return dt_SW_CONST;
    }

    public DataTable Read_SW_Production(DataTable SW_Data)
    {

        #region dt_SW_PRODUCTION

        string[] swProdColumns = new string[]
            {
                "SW_PROD_ID","JOBNO","INVOICE_SLNO","ITEM_SLNO","PRODUCTION_BATCH_IDENTIFIER","PRODUCTION_BATCH_QUANTITY","UNIT_QTY_CODE", "DATE_OF_MANUFACTURING", 
                "DATE_OF_EXPIRY", "BEST_BEFORE","USER_ID", "DATE_TIME", "STATUS", "BRANCH_CODE", "YEAR","WORKING_PERIOD", "MODIFIEDBY", "MODIFIEDON"
            };

        foreach (string col in swProdColumns)
            dt_SW_PROD.Columns.Add(col);

        #endregion

        for (int i = 0; i <= SW_Data.Rows.Count - 1; i++)
        {
            DataRow row = SW_Data.Rows[i];

            INVOICE_SLNO = GetString(row, "INVOICE_SLNO");
            ITEM_SLNO = GetString(row, "ITEM_SLNO");
            PRODUCTION_BATCH_IDENTIFIER = GetString(row, "PRODUCTION_BATCH_IDENTIFIER");
            PRODUCTION_BATCH_QUANTITY = GetString(row, "PRODUCTION_BATCH_QUANTITY");
            UNIT_QTY_CODE = GetString(row, "UNIT_QTY_CODE");
            DATE_OF_MANUFACTURING = GetString(row, "DATE_OF_MANUFACTURING");
            DATE_OF_MANUFACTURING = string.IsNullOrEmpty(DATE_OF_MANUFACTURING) ? "01/01/1900" : DATE_OF_MANUFACTURING;
            DATE_OF_EXPIRY = GetString(row, "DATE_OF_EXPIRY");
            DATE_OF_EXPIRY = string.IsNullOrEmpty(DATE_OF_EXPIRY) ? "01/01/1900" : DATE_OF_EXPIRY;
            BEST_BEFORE = GetString(row, "BEST_BEFORE");
            BEST_BEFORE = string.IsNullOrEmpty(BEST_BEFORE) ? "01/01/1900" : BEST_BEFORE;


            MAX_ID = Get_general_MAXID("SINGLEWINDOW_PRODUCTION_MAX_ID");

            dt_SW_PROD.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, PRODUCTION_BATCH_IDENTIFIER, PRODUCTION_BATCH_QUANTITY, UNIT_QTY_CODE, DATE_OF_MANUFACTURING, DATE_OF_EXPIRY, BEST_BEFORE,
                             currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);

        }
        dt_SW_PROD.TableName = "BE_ITEM_SW_PROD";
        data.Tables.Add(dt_SW_PROD);
        return dt_SW_PROD;
    }

    public DataTable Read_SW_Control(DataTable SW_Data)
    {

        #region  dt_SW_CTRL

        string[] swControlColumns = new string[]
                {
                    "SW_CONTROL_ID", "JOBNO","INVOICE_SLNO","ITEM_SLNO","CONTROL_TYPE_CODE","CONTROL_LOCATION","CONTROL_START_DATE", "CONTROL_END_DATE", "CONTROL_RESULT_CODE",
                    "CONTROL_RESULT_TEXT","USER_ID","DATE_TIME","STATUS","BRANCH_CODE","YEAR","WORKING_PERIOD","MODIFIEDBY","MODIFIEDON","CONTROL_MSR","CONTROL_UQC","CONTROL_SLNO"
                };

        foreach (string col in swControlColumns)
            dt_SW_CTRL.Columns.Add(col);

        #endregion

        DataRow row = SW_Data.Rows[0];

        INVOICE_SLNO = GetString(row, "INVOICE_SLNO");
        ITEM_SLNO = GetString(row, "ITEM_SLNO");
        CONTROL_TYPE_CODE = GetString(row, "CONTROL_TYPE_CODE");
        CONTROL_LOCATION = GetString(row, "CONTROL_LOCATION");
        CONTROL_START_DATE = GetString(row, "CONTROL_START_DATE");
        CONTROL_START_DATE = string.IsNullOrEmpty(CONTROL_START_DATE) ? "01/01/1900" : CONTROL_START_DATE;
        CONTROL_END_DATE = GetString(row, "CONTROL_END_DATE");
        CONTROL_END_DATE = string.IsNullOrEmpty(CONTROL_END_DATE) ? "01/01/1900" : CONTROL_END_DATE;
        CONTROL_RESULT_CODE = GetString(row, "CONTROL_RESULT_CODE");
        CONTROL_RESULT_TEXT = GetString(row, "CONTROL_RESULT_TEXT");
        CONTROL_MSR = GetString(row, "CONTROL_MSR");
        CONTROL_UQC = GetString(row, "CONTROL_UQC");
        CONTROL_SLNO = GetString(row, "CONTROL_SLNO");

        MAX_ID = Get_general_MAXID("SINGLEWINDOW_CTRL_MAX_ID");        

        dt_SW_CTRL.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, CONTROL_TYPE_CODE, CONTROL_LOCATION, CONTROL_START_DATE, CONTROL_END_DATE, CONTROL_RESULT_CODE, CONTROL_RESULT_TEXT,
                         currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate, CONTROL_MSR, CONTROL_UQC, CONTROL_SLNO);

        dt_SW_CTRL.TableName = "BE_ITEM_SW_CONTROL";
        data.Tables.Add(dt_SW_CTRL);
        return dt_SW_CTRL;
    }

    public DataTable Read_Invoice_Details_Old(DataTable INV_Data)
    {
        #region dt_INV

        string[] columns = new string[]
         {
             "INVOICE_ID","JOBNO","INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "TERMS","INVOICE_CURRENCY", "INVOICE_EXRATE", "INVOICE_VALUE",
         "MIS_FREIGHT_CHARGES", "MIS_FREIGHT_RATE", "MIS_FREIGHT_CURRENCY","MIS_INSURANCE_CHARGES", "MIS_INSURANCE_RATE", "MIS_INSURANCE_CURRENCY",
         "MIS_CHARGES", "MIS_RATE", "MIS_CURRENCY","MIS_AGENCY_CHARGES", "MIS_AGENCY_RATE", "MIS_AGENCY_CURRENCY","MIS_DISCOUNT_CHARGES", "MIS_DISCOUNT_RATE", 
         "MIS_DISCOUNT_CURRENCY","MIS_DISCOUNT_REASON","MIS_LOADING_CHARGES", "MIS_LOADING_RATE", "MIS_LOADING_CURRENCY","MIS_HIGHSEASALE_CHARGES", 
         "MIS_HIGHSEASALE_RATE", "MIS_HIGHSEASALE_CURRENCY","MIS_HIGHSEASALE_EXRATE","SUPPLIER_NAME", "SUPPLIER_ADDRESS", "SUPPLIER_ADDRESS1", "SUPPLIER_ADDRESS2",
         "SUPPLIER_COUNTRY_NAME", "SUPPLIER_COUNTRY_CODE", "SUPPLIER_COUNTRY_PINCODE","SVB_RELATION", "SVB_REF_NO", "SVB_REF_DATE", "SVB_CUSTOM_HOUSE",
         "SVB_LOADING_ON", "SVB_ASSESABLE_RATE", "SVB_DUTY_RATE","SVB_ASSESABLE_STATUS", "SVB_DUTY_STATUS","SELLER_NAME", "SELLER_ADDRESS", "SELLER_ADDRESS1", 
         "SELLER_ADDRESS2","SELLER_COUNTRY_NAME", "SELLER_COUNTRY_CODE", "SELLERCOUNTRY_PINCODE","BROKER_NAME", "BROKER_ADDRESS", "BROKER_ADDRESS1", "BROKER_ADDRESS2",
         "BROKER_COUNTRY_NAME", "BROKER_COUNTRY_CODE", "BROKER_COUNTRY_PINCODE","OTHER_PURCHASE_ORDER", "OTHER_PURCHASE_ORDER_DATE","OTHER_CONTRACT_NO", 
         "OTHER_CONTRACT_DATE","OTHER_LOC_NO", "OTHER_LOC_DATE","OTHER_NATURE_OF_TRANSACTION", "OTHER_TERMS_OF_PAYMENT","OTHER_CONDITIONS", "OTHER_VALUATION_METHOD",
         "NON_STD_EFFECT_DT_IMP", "NON_STD_BANKNAME","NON_STD_CERTIFICATE_NO", "NON_STD_CERTIFICATE_DATE","SAP_DELIEVERY_ID", "SHIP_DATE", "COUNTRY_OF_DEPARTURE",
         "REVENUEDEPOSIT_RATE", "REVENUEDEPOSIT_ON", "TERMS_PLACE","THIRDPARTY_NAME", "THIRDPARTY_ADD1", "THIRDPARTY_ADD2", "THIRDPARTY_CITY","T_PARTY_COUNTRY_SUB_DIV", 
         "T_PARTY_COUNTRY_CODE", "T_PARTY_PIN","AUTHORIZED_ECONOMIC_OPERATOR_CODE", "A_E_O_COUNTRY","AUTHORIZED_ECONOMIC_OPERATOR", "WHETHER_BUYER_SELLER_RELATED",
         "USER_ID","DATE_TIME","STATUS","BRANCH_CODE","YEAR","WORKING_PERIOD","MODIFIEDBY","MODIFIEDON"
         };

        foreach (string col in columns)
            dt_INV.Columns.Add(col);

        #endregion

        int xx = 0;
        for (int i = 0; i <= INV_Data.Rows.Count - 1; i++)
        {
            DataRow row = INV_Data.Rows[i];

            #region


            #region excel data

            INVOICE_SLNO = GetString(row, "INVOICE_SLNO");
            INVOICE_NO = GetString(row, "INVOICE_NO");
            INVOICE_DATE = GetString(row, "INVOICE_DATE");
            TERMS = GetString(row, "TERMS");
            INVOICE_CURRENCY = GetString(row, "INVOICE_CURRENCY");
            INVOICE_EXRATE = GetString(row, "INVOICE_EXRATE");
            INVOICE_VALUE = GetString(row, "INVOICE_VALUE");
            MIS_FREIGHT_CHARGES = GetString(row, "MIS_FREIGHT_CHARGES");
            string freightRateText = GetString(row, "MIS_FREIGHT_RATE");
            MIS_FREIGHT_RATE = string.IsNullOrEmpty(freightRateText) ? "0.00" : freightRateText;
            string freightCurrencyText = GetString(row, "MIS_FREIGHT_CURRENCY");
            MIS_FREIGHT_CURRENCY = string.IsNullOrEmpty(freightCurrencyText) ? INVOICE_CURRENCY : freightCurrencyText;
            MIS_INSURANCE_CHARGES = GetString(row, "MIS_INSURANCE_CHARGES");
            string insuranceRateText = GetString(row, "MIS_INSURANCE_RATE");
            MIS_INSURANCE_RATE = string.IsNullOrEmpty(insuranceRateText) ? "0.00" : insuranceRateText;
            if (insuranceRateText != "")
            {
                MIS_INSURANCE_CHARGES = Convert.ToString(Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100);
            }
            string insCurrencyText = GetString(row, "MIS_INSURANCE_CURRENCY");
            MIS_INSURANCE_CURRENCY = string.IsNullOrEmpty(insCurrencyText) ? INVOICE_CURRENCY : insCurrencyText;
            MIS_CHARGES = GetString(row, "MIS_CHARGES");
            MIS_RATE = GetString(row, "MIS_RATE");
            string misCurrencyText = GetString(row, "MIS_CURRENCY");
            MIS_CURRENCY = string.IsNullOrEmpty(misCurrencyText) ? INVOICE_CURRENCY : misCurrencyText;
            MIS_AGENCY_CHARGES = GetString(row, "MIS_AGENCY_CHARGES");
            string agencyRateText = GetString(row, "MIS_AGENCY_RATE");
            MIS_AGENCY_RATE = string.IsNullOrEmpty(agencyRateText) ? "0.00" : agencyRateText;
            string agencyCurrencyText = GetString(row, "MIS_AGENCY_CURRENCY");
            MIS_AGENCY_CURRENCY = string.IsNullOrEmpty(agencyCurrencyText) ? INVOICE_CURRENCY : agencyCurrencyText;
            MIS_DISCOUNT_CHARGES = GetString(row, "MIS_DISCOUNT_CHARGES");
            string discountRateText = GetString(row, "MIS_DISCOUNT_RATE");
            MIS_DISCOUNT_RATE = string.IsNullOrEmpty(discountRateText) ? "0.00" : discountRateText;
            string discountCurrencyText = GetString(row, "MIS_DISCOUNT_CURRENCY");
            MIS_DISCOUNT_CURRENCY = string.IsNullOrEmpty(discountCurrencyText) ? INVOICE_CURRENCY : discountCurrencyText;
            MIS_DISCOUNT_REASON = GetString(row, "MIS_DISCOUNT_REASON");
            MIS_LOADING_CHARGES = GetString(row, "MIS_LOADING_CHARGES");
            MIS_LOADING_RATE = GetString(row, "MIS_LOADING_RATE");
            string loadingCurrencyText = GetString(row, "MIS_LOADING_CURRENCY");
            MIS_LOADING_CURRENCY = string.IsNullOrEmpty(loadingCurrencyText) ? INVOICE_CURRENCY : loadingCurrencyText;
            MIS_HIGHSEASALE_CHARGES = GetString(row, "MIS_HIGHSEASALE_CHARGES");
            string hssRateText = GetString(row, "MIS_HIGHSEASALE_RATE");
            MIS_HIGHSEASALE_RATE = string.IsNullOrEmpty(hssRateText) ? "0.00" : hssRateText;
            string hssCurrencyText = GetString(row, "MIS_HIGHSEASALE_CURRENCY");
            MIS_HIGHSEASALE_CURRENCY = string.IsNullOrEmpty(hssCurrencyText) ? "INR" : hssCurrencyText;
            

            #endregion

            MIS_HIGHSEASALE_EXRATE = "";
            if (MIS_HIGHSEASALE_EXRATE == "")
            {
                MIS_HIGHSEASALE_CURRENCY = "INR";
            }

            #region SUPPLIER

            SUPPLIER_NAME = GetString(row, "SUPPLIER_NAME");
            ds_supplier.Clear();
            ds_supplier = Get_Importer_Supplier_Details(SUPPLIER_NAME);
            xx = xl.result;

            if (xx == 1 && currentuser != "AURIONPRO")
            {
                var sup = ds_supplier.Tables[0].Rows[0];

                SUPPLIER_NAME = GetString(sup, "SUP_NAME");
                SUPPLIER_ADDRESS = GetString(sup, "SUP_ADD1");
                SUPPLIER_ADDRESS1 = GetString(sup, "SUP_ADD2");
                SUPPLIER_ADDRESS2 = GetString(sup, "SUP_ADD3");
                SUPPLIER_COUNTRY_NAME = GetString(sup, "SUP_COUNTRY_NAME");
                SUPPLIER_COUNTRY_CODE = GetString(sup, "SUP_COUNTRY_CODE");
                SUPPLIER_COUNTRY_PINCODE = GetString(sup, "SUP_PIN_CODE");
            }
            else
            {
                SUPPLIER_NAME = GetString(row, "SUPPLIER_NAME");
                SUPPLIER_ADDRESS = GetString(row, "SUPPLIER_ADDRESS");
                SUPPLIER_ADDRESS1 = GetString(row, "SUPPLIER_ADDRESS1");
                SUPPLIER_ADDRESS2 = GetString(row, "SUPPLIER_ADDRESS2");
                SUPPLIER_COUNTRY_NAME = GetString(row, "SUPPLIER_COUNTRY_NAME");
                SUPPLIER_COUNTRY_CODE = GetString(row, "SUPPLIER_COUNTRY_CODE");
                SUPPLIER_COUNTRY_PINCODE = GetString(row, "SUPPLIER_COUNTRY_PINCODE");
            }

            #endregion SUPPLIER

            #region SVB/SELLER/BROKER/OTHER

            var rel = GetString(row, "SVB_RELATION");
            SVB_RELATION = rel == "" ? "N" : rel;
            SVB_REF_NO = GetString(row, "SVB_REF_NO");
            string svbRefDateText = GetString(row, "SVB_REF_DATE");
            SVB_REF_DATE = string.IsNullOrEmpty(svbRefDateText) ? "01/01/1900" : svbRefDateText;
            SVB_CUSTOM_HOUSE = GetString(row, "SVB_CUSTOM_HOUSE");
            string svbLoading = GetString(row, "SVB_LOADING_ON");
            SVB_LOADING_ON = svbLoading != "" ? svbLoading.Substring(0, 1) : "";
            SVB_ASSESABLE_RATE = GetString(row, "SVB_ASSESABLE_RATE");
            SVB_DUTY_RATE = GetString(row, "SVB_DUTY_RATE");
            string svbAssessStatus = GetString(row, "SVB_ASSESABLE_STATUS");
            SVB_ASSESABLE_STATUS = svbAssessStatus != "" ? svbAssessStatus.Substring(0, 1) : "";
            string svbDutyStatus = GetString(row, "SVB_DUTY_STATUS");
            SVB_DUTY_STATUS = svbDutyStatus != "" ? svbDutyStatus.Substring(0, 1) : "";
            SELLER_NAME = GetString(row, "SELLER_NAME");
            SELLER_ADDRESS = GetString(row, "SELLER_ADDRESS");
            SELLER_ADDRESS1 = GetString(row, "SELLER_ADDRESS1");
            SELLER_ADDRESS2 = GetString(row, "SELLER_ADDRESS2");
            SELLER_COUNTRY_NAME = GetString(row, "SELLER_COUNTRY_NAME");
            SELLER_COUNTRY_CODE = GetString(row, "SELLER_COUNTRY_CODE");
            SELLERCOUNTRY_PINCODE = GetString(row, "SELLERCOUNTRY_PINCODE");
            BROKER_NAME = GetString(row, "BROKER_NAME");
            BROKER_ADDRESS = GetString(row, "BROKER_ADDRESS");
            BROKER_ADDRESS1 = GetString(row, "BROKER_ADDRESS1");
            BROKER_ADDRESS2 = GetString(row, "BROKER_ADDRESS2");
            BROKER_COUNTRY_NAME = GetString(row, "BROKER_COUNTRY_NAME");
            BROKER_COUNTRY_CODE = GetString(row, "BROKER_COUNTRY_CODE");
            BROKER_COUNTRY_PINCODE = GetString(row, "BROKER_COUNTRY_PINCODE");
            OTHER_PURCHASE_ORDER = GetString(row, "OTHER_PURCHASE_ORDER");
            string poDateText = GetString(row, "OTHER_PURCHASE_ORDER_DATE");
            OTHER_PURCHASE_ORDER_DATE = string.IsNullOrEmpty(poDateText) ? "01/01/1900" : poDateText;
            OTHER_CONTRACT_NO = GetString(row, "OTHER_CONTRACT_NO");
            string contractDateText = GetString(row, "OTHER_CONTRACT_DATE");
            OTHER_CONTRACT_DATE = string.IsNullOrEmpty(contractDateText) ? "01/01/1900" : contractDateText;
            OTHER_LOC_NO = GetString(row, "OTHER_LOC_NO");
            string locDateText = GetString(row, "OTHER_LOC_DATE");
            OTHER_LOC_DATE = string.IsNullOrEmpty(locDateText) ? "01/01/1900" : locDateText;
            OTHER_NATURE_OF_TRANSACTION = GetString(row, "OTHER_NATURE_OF_TRANSACTION");
            OTHER_TERMS_OF_PAYMENT = GetString(row, "OTHER_TERMS_OF_PAYMENT");
            OTHER_CONDITIONS = GetString(row, "OTHER_CONDITIONS");
            OTHER_VALUATION_METHOD = GetString(row, "OTHER_VALUATION_METHOD");
            string nonStdEffectDtText = GetString(row, "NON_STD_EFFECT_DT_IMP");
            NON_STD_EFFECT_DT_IMP = string.IsNullOrEmpty(nonStdEffectDtText) ? "01/01/1900" : nonStdEffectDtText;
            NON_STD_BANKNAME = GetString(row, "NON_STD_BANKNAME");
            NON_STD_CERTIFICATE_NO = GetString(row, "NON_STD_CERTIFICATE_NO");
            string nonStdCertDateText = GetString(row, "NON_STD_CERTIFICATE_DATE");
            NON_STD_CERTIFICATE_DATE = string.IsNullOrEmpty(nonStdCertDateText) ? "01/01/1900" : nonStdCertDateText;
            SAP_DELIEVERY_ID = GetString(row, "SAP_DELIEVERY_ID");
            string shipDateText = GetString(row, "SHIP_DATE");
            SHIP_DATE = string.IsNullOrEmpty(shipDateText) ? "01/01/1900" : shipDateText;
            COUNTRY_OF_DEPARTURE = GetString(row, "COUNTRY_OF_DEPARTURE");
            REVENUEDEPOSIT_RATE = GetString(row, "REVENUEDEPOSIT_RATE");
            REVENUEDEPOSIT_ON = GetString(row, "REVENUEDEPOSIT_ON");
            TERMS_PLACE = GetString(row, "TERMS_PLACE");
            THIRDPARTY_NAME = GetString(row, "THIRDPARTY_NAME");
            THIRDPARTY_ADD1 = GetString(row, "THIRDPARTY_ADD1");
            THIRDPARTY_ADD2 = GetString(row, "THIRDPARTY_ADD2");
            THIRDPARTY_CITY = GetString(row, "THIRDPARTY_CITY");
            T_PARTY_COUNTRY_SUB_DIV = GetString(row, "T_PARTY_COUNTRY_SUB_DIV");
            T_PARTY_COUNTRY_CODE = GetString(row, "T_PARTY_COUNTRY_CODE");
            T_PARTY_PIN = GetString(row, "T_PARTY_PIN");
            AUTHORIZED_ECONOMIC_OPERATOR_CODE = GetString(row, "AUTHORIZED_ECONOMIC_OPERATOR_CODE");
            A_E_O_COUNTRY = GetString(row, "A_E_O_COUNTRY");
            AUTHORIZED_ECONOMIC_OPERATOR = GetString(row, "AUTHORIZED_ECONOMIC_OPERATOR");
            WHETHER_BUYER_SELLER_RELATED = GetString(row, "WHETHER_BUYER_SELLER_RELATED");

            #endregion

            #endregion

            USER_ID = currentuser;
            DATE_TIME = LoginDate;
            STATUS = "N";
            BRANCH_CODE = currentbranch;
            YEAR = "";
            WORKING_PERIOD = Working_Period;

            MAX_ID = Get_general_MAXID("INVOICE_MAX_ID");
            

            dt_INV.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, INVOICE_NO, INVOICE_DATE, TERMS, INVOICE_CURRENCY, INVOICE_EXRATE, INVOICE_VALUE, MIS_FREIGHT_CHARGES,
            MIS_FREIGHT_RATE, MIS_FREIGHT_CURRENCY, MIS_INSURANCE_CHARGES, MIS_INSURANCE_RATE, MIS_INSURANCE_CURRENCY, MIS_CHARGES, MIS_RATE, MIS_CURRENCY, MIS_AGENCY_CHARGES,
            MIS_AGENCY_RATE, MIS_AGENCY_CURRENCY, MIS_DISCOUNT_CHARGES, MIS_DISCOUNT_RATE, MIS_DISCOUNT_CURRENCY, MIS_DISCOUNT_REASON, MIS_LOADING_CHARGES, MIS_LOADING_RATE,
            MIS_LOADING_CURRENCY, MIS_HIGHSEASALE_CHARGES, MIS_HIGHSEASALE_RATE, MIS_HIGHSEASALE_CURRENCY, MIS_HIGHSEASALE_EXRATE, SUPPLIER_NAME, SUPPLIER_ADDRESS,
            SUPPLIER_ADDRESS1, SUPPLIER_ADDRESS2, SUPPLIER_COUNTRY_NAME, SUPPLIER_COUNTRY_CODE, SUPPLIER_COUNTRY_PINCODE, SVB_RELATION, SVB_REF_NO, SVB_REF_DATE,
            SVB_CUSTOM_HOUSE, SVB_LOADING_ON, SVB_ASSESABLE_RATE, SVB_DUTY_RATE, SVB_ASSESABLE_STATUS, SVB_DUTY_STATUS, SELLER_NAME, SELLER_ADDRESS, SELLER_ADDRESS1,
            SELLER_ADDRESS2, SELLER_COUNTRY_NAME, SELLER_COUNTRY_CODE, SELLERCOUNTRY_PINCODE, BROKER_NAME, BROKER_ADDRESS, BROKER_ADDRESS1, BROKER_ADDRESS2,
            BROKER_COUNTRY_NAME, BROKER_COUNTRY_CODE, BROKER_COUNTRY_PINCODE, OTHER_PURCHASE_ORDER, OTHER_PURCHASE_ORDER_DATE, OTHER_CONTRACT_NO, OTHER_CONTRACT_DATE,
            OTHER_LOC_NO, OTHER_LOC_DATE, OTHER_NATURE_OF_TRANSACTION, OTHER_TERMS_OF_PAYMENT, OTHER_CONDITIONS, OTHER_VALUATION_METHOD, NON_STD_EFFECT_DT_IMP,
            NON_STD_BANKNAME, NON_STD_CERTIFICATE_NO, NON_STD_CERTIFICATE_DATE, SAP_DELIEVERY_ID, SHIP_DATE, COUNTRY_OF_DEPARTURE, REVENUEDEPOSIT_RATE, REVENUEDEPOSIT_ON,
            TERMS_PLACE, THIRDPARTY_NAME, THIRDPARTY_ADD1, THIRDPARTY_ADD2, THIRDPARTY_CITY, T_PARTY_COUNTRY_SUB_DIV, T_PARTY_COUNTRY_CODE, T_PARTY_PIN,
            AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR, WHETHER_BUYER_SELLER_RELATED, USER_ID, DATE_TIME, STATUS, BRANCH_CODE, YEAR, WORKING_PERIOD, USER_ID, DATE_TIME);

        }
        
        if (dt_INV.Rows.Count > 0)
        {
            var result = DeleteJobDataByTable("INVOICE_DETAILS");

            //if (!result.Success)
            //{
                SqlBulk_Upload_Product("INVOICE_DETAILS", dt_INV, Session["currentcomp_db"].ToString());
            //}
            //else
            //{
            //    Alert_msg("No data found.");
            //}
                        
        }

        

        dt_INV.TableName = "INVOICE_DETAILS";
        data.Tables.Add(dt_INV);
        return dt_INV;
    }
    public DataTable Read_Invoice_Details(DataTable INV_Data)
    {
        #region dt_INV columns



            string[] columns = new string[] { "INVOICE_ID", "JOBNO", "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "TERMS", "INVOICE_CURRENCY", "INVOICE_EXRATE", "INVOICE_VALUE", 
            "SUPPLIER_NAME", "SUPPLIER_ADDRESS", "SUPPLIER_ADDRESS1", "SUPPLIER_ADDRESS2", "SUPPLIER_COUNTRY_NAME", "SUPPLIER_COUNTRY_CODE", "SUPPLIER_COUNTRY_PINCODE", 
            "SELLER_NAME", "SELLER_ADDRESS", "SELLER_ADDRESS1", "SELLER_ADDRESS2", "SELLER_COUNTRY_NAME", "SELLER_COUNTRY_CODE", "SELLERCOUNTRY_PINCODE", "BROKER_NAME", 
            "BROKER_ADDRESS", "BROKER_ADDRESS1", "BROKER_ADDRESS2", "BROKER_COUNTRY_NAME", "BROKER_COUNTRY_CODE", "BROKER_COUNTRY_PINCODE", "MIS_CHARGES", "MIS_RATE", 
            "MIS_CURRENCY", "MIS_EXRATE", "MIS_AGENCY_CHARGES", "MIS_AGENCY_RATE", "MIS_AGENCY_CURRENCY", "MIS_AGENCY_EXRATE", "MIS_DISCOUNT_CHARGES", "MIS_DISCOUNT_RATE", 
            "MIS_DISCOUNT_CURRENCY", "MIS_DISCOUNT_EXRATE", "MIS_DISCOUNT_REASON", "MIS_LOADING_CHARGES", "MIS_LOADING_RATE", "MIS_LOADING_CURRENCY", "MIS_LOADING_EXRATE", 
            "MIS_FREIGHT_CHARGES", "MIS_FREIGHT_RATE", "MIS_FREIGHT_CURRENCY", "MIS_FREIGHT_EXRATE", "MIS_INSURANCE_CHARGES", "MIS_INSURANCE_RATE", "MIS_INSURANCE_CURRENCY", 
            "MIS_INSURANCE_EXRATE", "MIS_HIGHSEASALE_CHARGES", "MIS_HIGHSEASALE_RATE", "MIS_HIGHSEASALE_CURRENCY", "MIS_HIGHSEASALE_EXRATE", "MIS_SINGLE_OR_MULITIPLE", 
            "SVB_RELATION", "SVB_REF_NO", "SVB_REF_DATE", "SVB_CUSTOM_HOUSE", "SVB_LOADING_ON", "SVB_ASSESABLE_RATE", "SVB_DUTY_RATE", "SVB_ASSESABLE_STATUS", "SVB_DUTY_STATUS", 
            "OTHER_PURCHASE_ORDER", "OTHER_PURCHASE_ORDER_DATE", "OTHER_CONTRACT_NO", "OTHER_CONTRACT_DATE", "OTHER_LOC_NO", "OTHER_LOC_DATE", "OTHER_NATURE_OF_TRANSACTION", 
            "OTHER_TERMS_OF_PAYMENT", "OTHER_CONDITIONS", "OTHER_VALUATION_METHOD", "USER_ID", "DATE_TIME", "STATUS", "BRANCH_CODE", "YEAR", "WORKING_PERIOD", 
            "NON_STD_EFFECT_DT_IMP", "NON_STD_BANKNAME", "NON_STD_CERTIFICATE_NO", "NON_STD_CERTIFICATE_DATE", "SAP_DELIEVERY_ID", "SHIP_DATE", "INVOICE_LEVEL", 
            "COUNTRY_OF_DEPARTURE", "REVENUEDEPOSIT_RATE", "REVENUEDEPOSIT_ON", "MI_FREIGHT", "MI_INSURANCE", "MI_MISC", "MI_HSS", "MODIFIEDBY", "MODIFIEDON", "INDEV_INV_TYPE", 
            "TERMS_PLACE", "THIRDPARTY_NAME", "THIRDPARTY_ADD1", "THIRDPARTY_ADD2", "THIRDPARTY_CITY", "T_PARTY_COUNTRY_SUB_DIV", "T_PARTY_COUNTRY_CODE", "T_PARTY_PIN", 
            "AUTHORIZED_ECONOMIC_OPERATOR_CODE", "A_E_O_COUNTRY", "AUTHORIZED_ECONOMIC_OPERATOR", "WHETHER_BUYER_SELLER_RELATED", "A_AMOUNT", "B_AMOUNT", "C_AMOUNT", "D_AMOUNT", 
            "E_AMOUNT", "F_AMOUNT", "G_AMOUNT", "H_AMOUNT", "I_AMOUNT", "J_AMOUNT", "K_AMOUNT", "L_AMOUNT", "M_AMOUNT", "N_AMOUNT", "TOTAL_OTHER_AMOUNT" };


        foreach (string col in columns)
            dt_INV.Columns.Add(col);
        #endregion

        int xx = 0;
        for (int i = 0; i <= INV_Data.Rows.Count - 1; i++)
        {
            DataRow row = INV_Data.Rows[i];

            #region from excel                                                       
            

            // ── 2. Invoice  ──────────────────────────────────────────
            INVOICE_SLNO = GetString(row, "INVOICE_SLNO");//
            INVOICE_NO = GetString(row, "INVOICE_NO");//
            INVOICE_DATE = GetString(row, "INVOICE_DATE");//
            TERMS = GetString(row, "TERMS");//
            INVOICE_CURRENCY = GetString(row, "INVOICE_CURRENCY");//
            INVOICE_EXRATE = GetString(row, "INVOICE_EXRATE");//
            INVOICE_VALUE = GetString(row, "INVOICE_VALUE");//

            // ── 3. MIS Charges ────────────────────────────────────────────────────
            MIS_CHARGES = GetString(row, "MIS_CHARGES");//
            MIS_RATE = GetString(row, "MIS_RATE");//
            string misCurrency = GetString(row, "MIS_CURRENCY");
            MIS_CURRENCY = string.IsNullOrEmpty(misCurrency) ? INVOICE_CURRENCY : misCurrency;//
            MIS_EXRATE = "";
            if (MIS_EXRATE == "" || MIS_CURRENCY == INVOICE_CURRENCY)
                MIS_EXRATE = INVOICE_EXRATE;

            // ── 4. Agency Charges ─────────────────────────────────────────────────
            MIS_AGENCY_CHARGES = GetString(row, "MIS_AGENCY_CHARGES");//
            string agencyRateText = GetString(row, "MIS_AGENCY_RATE");
            MIS_AGENCY_RATE = string.IsNullOrEmpty(agencyRateText) ? "0.00" : agencyRateText;//
            string agencyCurrencyText = GetString(row, "MIS_AGENCY_CURRENCY");
            MIS_AGENCY_CURRENCY = string.IsNullOrEmpty(agencyCurrencyText) ? INVOICE_CURRENCY : agencyCurrencyText;//
            MIS_AGENCY_EXRATE = "";
            if (MIS_AGENCY_EXRATE == "" || MIS_AGENCY_CURRENCY == INVOICE_CURRENCY)
                MIS_AGENCY_EXRATE = INVOICE_EXRATE;

            // ── 5. Discount Charges ───────────────────────────────────────────────
            MIS_DISCOUNT_CHARGES = GetString(row, "MIS_DISCOUNT_CHARGES");//
            string discountRateText = GetString(row, "MIS_DISCOUNT_RATE");
            MIS_DISCOUNT_RATE = string.IsNullOrEmpty(discountRateText) ? "0.00" : discountRateText;//
            string discountCurrencyText = GetString(row, "MIS_DISCOUNT_CURRENCY");
            MIS_DISCOUNT_CURRENCY = string.IsNullOrEmpty(discountCurrencyText) ? INVOICE_CURRENCY : discountCurrencyText;//
            MIS_DISCOUNT_EXRATE = "";
            if (MIS_DISCOUNT_EXRATE == "" || MIS_DISCOUNT_CURRENCY == INVOICE_CURRENCY)
                MIS_DISCOUNT_EXRATE = INVOICE_EXRATE;
            MIS_DISCOUNT_REASON = GetString(row, "MIS_DISCOUNT_REASON");//

            // ── 6. Loading Charges ────────────────────────────────────────────────
            MIS_LOADING_CHARGES = GetString(row, "MIS_LOADING_CHARGES");//
            MIS_LOADING_RATE = GetString(row, "MIS_LOADING_RATE");//
            string loadingCurrencyText = GetString(row, "MIS_LOADING_CURRENCY");
            MIS_LOADING_CURRENCY = string.IsNullOrEmpty(loadingCurrencyText) ? INVOICE_CURRENCY : loadingCurrencyText;//
            MIS_LOADING_EXRATE = "";
            if (MIS_LOADING_EXRATE == "" || MIS_LOADING_CURRENCY == INVOICE_CURRENCY)
                MIS_LOADING_EXRATE = INVOICE_EXRATE;

            // ── 7. Freight + Insurance — TERMS-based logic (mirrors live insert_update) ──
            string freightRateText = GetString(row, "MIS_FREIGHT_RATE");
            string freightCurrencyText = GetString(row, "MIS_FREIGHT_CURRENCY");
            string insuranceRateText = GetString(row, "MIS_INSURANCE_RATE");
            string insCurrencyText = GetString(row, "MIS_INSURANCE_CURRENCY");

            if (TERMS == "FOB")
            {
                // ── Freight ───────────────────────────────────────────────────────
                MIS_FREIGHT_CHARGES = GetString(row, "MIS_FREIGHT_CHARGES");//
                MIS_FREIGHT_RATE = string.IsNullOrEmpty(freightRateText) ? "0.00" : freightRateText;//
                MIS_FREIGHT_CURRENCY = string.IsNullOrEmpty(freightCurrencyText) ? INVOICE_CURRENCY : freightCurrencyText;//
                MIS_FREIGHT_EXRATE = "";
                if (MIS_FREIGHT_EXRATE == "" || MIS_FREIGHT_CURRENCY == INVOICE_CURRENCY)
                    MIS_FREIGHT_EXRATE = INVOICE_EXRATE;

                // ── Insurance ─────────────────────────────────────────────────────
                MIS_INSURANCE_RATE = string.IsNullOrEmpty(insuranceRateText) ? "0.00" : insuranceRateText;//
                if (!string.IsNullOrEmpty(insuranceRateText))
                    MIS_INSURANCE_CHARGES = Convert.ToString(Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100);//
                else
                    MIS_INSURANCE_CHARGES = GetString(row, "MIS_INSURANCE_CHARGES");//
                MIS_INSURANCE_CURRENCY = string.IsNullOrEmpty(insCurrencyText) ? INVOICE_CURRENCY : insCurrencyText;//
                MIS_INSURANCE_EXRATE = "";
                if (MIS_INSURANCE_EXRATE == "" || MIS_INSURANCE_CURRENCY == INVOICE_CURRENCY)
                    MIS_INSURANCE_EXRATE = INVOICE_EXRATE;
            }
            else if (TERMS == "CF")
            {
                // ── Freight = 0 ───────────────────────────────────────────────────
                MIS_FREIGHT_CHARGES = "0";//
                MIS_FREIGHT_RATE = "";//
                MIS_FREIGHT_CURRENCY = "";//
                MIS_FREIGHT_EXRATE = "";

                // ── Insurance ─────────────────────────────────────────────────────
                MIS_INSURANCE_RATE = string.IsNullOrEmpty(insuranceRateText) ? "0.00" : insuranceRateText;
                if (!string.IsNullOrEmpty(insuranceRateText))
                    MIS_INSURANCE_CHARGES = Convert.ToString(Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100);
                else
                    MIS_INSURANCE_CHARGES = GetString(row, "MIS_INSURANCE_CHARGES");//
                MIS_INSURANCE_CURRENCY = string.IsNullOrEmpty(insCurrencyText) ? INVOICE_CURRENCY : insCurrencyText;//
                MIS_INSURANCE_EXRATE = "";//
                if (MIS_INSURANCE_EXRATE == "" || MIS_INSURANCE_CURRENCY == INVOICE_CURRENCY)
                    MIS_INSURANCE_EXRATE = INVOICE_EXRATE;
            }
            else if (TERMS == "CI")
            {
                // ── Freight ───────────────────────────────────────────────────────
                MIS_FREIGHT_CHARGES = GetString(row, "MIS_FREIGHT_CHARGES");//
                MIS_FREIGHT_RATE = string.IsNullOrEmpty(freightRateText) ? "0.00" : freightRateText;//
                MIS_FREIGHT_CURRENCY = string.IsNullOrEmpty(freightCurrencyText) ? INVOICE_CURRENCY : freightCurrencyText;//
                MIS_FREIGHT_EXRATE = "";
                if (MIS_FREIGHT_EXRATE == "" || MIS_FREIGHT_CURRENCY == INVOICE_CURRENCY)
                    MIS_FREIGHT_EXRATE = INVOICE_EXRATE;

                // ── Insurance = 0 ─────────────────────────────────────────────────
                MIS_INSURANCE_CHARGES = "0";//
                MIS_INSURANCE_RATE = "";//
                MIS_INSURANCE_CURRENCY = "";//
                MIS_INSURANCE_EXRATE = "";
            }
            else // CIF or anything else
            {
                MIS_FREIGHT_CHARGES = "0";//
                MIS_FREIGHT_RATE = "";//
                MIS_FREIGHT_CURRENCY = "";//
                MIS_FREIGHT_EXRATE = "";
                MIS_INSURANCE_CHARGES = "0";//
                MIS_INSURANCE_RATE = "";//
                MIS_INSURANCE_CURRENCY = "";//
                MIS_INSURANCE_EXRATE = "";
            }

            // ── 8. High Sea Sale ──────────────────────────────────────────────────
            MIS_HIGHSEASALE_CHARGES = GetString(row, "MIS_HIGHSEASALE_CHARGES");//
            string hssRateText = GetString(row, "MIS_HIGHSEASALE_RATE");
            MIS_HIGHSEASALE_RATE = string.IsNullOrEmpty(hssRateText) ? "0.00" : hssRateText;//
            string hssExRateText = GetString(row, "MIS_HIGHSEASALE_EXRATE");
            MIS_HIGHSEASALE_EXRATE = string.IsNullOrEmpty(hssExRateText) ? "0.00" : hssExRateText;//
            string hsscurrency = GetString(row, "MIS_HIGHSEASALE_CURRENCY");
            MIS_HIGHSEASALE_CURRENCY = string.IsNullOrEmpty(hsscurrency) ? "INR" : hsscurrency;// 

            // ── 9. Single or Multiple ─────────────────────────────────────────────
            MIS_SINGLE_OR_MULITIPLE = INV_Data.Rows.Count == 1 ? "S" : "M";

            // ── 10. Supplier — 3-branch logic matching live insert_update ─────────
            SUPPLIER_NAME = GetString(row, "SUPPLIER_NAME");
            ds_supplier.Clear();
            ds_supplier = Get_Importer_Supplier_Details(SUPPLIER_NAME);
            xx = xl.result;

            if (xx == 1)
            {
                if (currentuser != "AURIONPRO")
                {
                    // ── Found in master — use master data ─────────────────────────
                    var sup = ds_supplier.Tables[0].Rows[0];
                    SUPPLIER_NAME = sup["SUP_NAME"].ToString();//                    
                    SUPPLIER_ADDRESS = sup["SUP_ADD1"].ToString();//
                    SUPPLIER_ADDRESS1 = sup["SUP_ADD2"].ToString();//
                    SUPPLIER_ADDRESS2 = sup["SUP_ADD3"].ToString();//
                    SUPPLIER_COUNTRY_NAME = sup["SUP_COUNTRY_NAME"].ToString();//
                    SUPPLIER_COUNTRY_CODE = sup["SUP_COUNTRY_CODE"].ToString();//
                    SUPPLIER_COUNTRY_PINCODE = sup["SUP_PIN_CODE"].ToString();//
                }
                else
                {
                    // ── AURIONPRO — always use Excel row data ─────────────────────
                    SUPPLIER_NAME = GetString(row, "SUPPLIER_NAME");//                    
                    SUPPLIER_ADDRESS = GetString(row, "SUPPLIER_ADDRESS");//
                    SUPPLIER_ADDRESS1 = GetString(row, "SUPPLIER_ADDRESS1");//
                    SUPPLIER_ADDRESS2 = GetString(row, "SUPPLIER_ADDRESS2");//
                    SUPPLIER_COUNTRY_NAME = GetString(row, "SUPPLIER_COUNTRY_NAME");//
                    SUPPLIER_COUNTRY_CODE = GetString(row, "SUPPLIER_COUNTRY_CODE");//
                    SUPPLIER_COUNTRY_PINCODE = GetString(row, "SUPPLIER_COUNTRY_PINCODE");//
                }
            }
            else
            {
                // ── Not found — auto insert into Supplier Master ──────────────────
                //erm.SUP_ID = a1;
                erm.SUP_NAME = GetString(row, "SUPPLIER_NAME");
                erm.SUP_ADD1 = GetString(row, "SUPPLIER_ADDRESS");
                erm.SUP_ADD2 = GetString(row, "SUPPLIER_ADDRESS1");
                erm.SUP_ADD3 = GetString(row, "SUPPLIER_ADDRESS2");
                erm.SUP_COUNTRY_CODE = GetString(row, "SUPPLIER_COUNTRY_CODE");
                erm.SUP_COUNTRY_NAME = GetString(row, "SUPPLIER_COUNTRY_NAME");
                erm.SUP_PIN_CODE = GetString(row, "SUPPLIER_COUNTRY_PINCODE");
                erm.SUP_REMARKS = "";
                erm.USER_ID = currentuser;
                erm.BRANCH_CODE = currentbranch;
                erm.flag = "S";
                erm.YEAR = "";//a3
                erm.EWorking_Period = Working_Period;
                erm.Supplier_Master_Insert_update();

                // ── After insert, still read from Excel ───────────────────────────
                SUPPLIER_NAME = GetString(row, "SUPPLIER_NAME");//
                SUPPLIER_ADDRESS = GetString(row, "SUPPLIER_ADDRESS");//
                SUPPLIER_ADDRESS1 = GetString(row, "SUPPLIER_ADDRESS1");//
                SUPPLIER_ADDRESS2 = GetString(row, "SUPPLIER_ADDRESS2");//
                SUPPLIER_COUNTRY_NAME = GetString(row, "SUPPLIER_COUNTRY_NAME");//
                SUPPLIER_COUNTRY_CODE = GetString(row, "SUPPLIER_COUNTRY_CODE");//
                SUPPLIER_COUNTRY_PINCODE = GetString(row, "SUPPLIER_COUNTRY_PINCODE");//
            }

            // ── 11. Seller ────────────────────────────────────────────────────────
            //SELLER_NAME = GetString(row, "SELLER_NAME");//
            string sellerName = GetString(row, "SELLER_NAME") ?? "";
            SELLER_NAME = sellerName.Length <= 35 ? sellerName : sellerName.Substring(0, 35);
            SELLER_ADDRESS = GetString(row, "SELLER_ADDRESS");//
            SELLER_ADDRESS1 = GetString(row, "SELLER_ADDRESS1");//
            SELLER_ADDRESS2 = GetString(row, "SELLER_ADDRESS2");//
            SELLER_COUNTRY_NAME = GetString(row, "SELLER_COUNTRY_NAME");//
            SELLER_COUNTRY_CODE = GetString(row, "SELLER_COUNTRY_CODE");//
            SELLERCOUNTRY_PINCODE = GetString(row, "SELLERCOUNTRY_PINCODE");//

            // ── 12. Broker ────────────────────────────────────────────────────────
            //BROKER_NAME = GetString(row, "BROKER_NAME");//
            string brokerName = GetString(row, "BROKER_NAME") ?? "";
            BROKER_NAME = brokerName.Length <= 35 ? brokerName : brokerName.Substring(0, 35);
            BROKER_ADDRESS = GetString(row, "BROKER_ADDRESS");//
            BROKER_ADDRESS1 = GetString(row, "BROKER_ADDRESS1");//
            BROKER_ADDRESS2 = GetString(row, "BROKER_ADDRESS2");//
            BROKER_COUNTRY_NAME = GetString(row, "BROKER_COUNTRY_NAME");//
            BROKER_COUNTRY_CODE = GetString(row, "BROKER_COUNTRY_CODE");//
            BROKER_COUNTRY_PINCODE = GetString(row, "BROKER_COUNTRY_PINCODE");//

            // ── 13. SVB ───────────────────────────────────────────────────────────
            string rel = GetString(row, "SVB_RELATION");
            SVB_RELATION = rel == "" ? "N" : rel;//
            SVB_REF_NO = GetString(row, "SVB_REF_NO");//
            string svbRefDateText = GetString(row, "SVB_REF_DATE");
            SVB_REF_DATE = string.IsNullOrEmpty(svbRefDateText) ? "01/01/1900" : svbRefDateText;//
            SVB_CUSTOM_HOUSE = GetString(row, "SVB_CUSTOM_HOUSE");//
            string svbLoading = GetString(row, "SVB_LOADING_ON");
            SVB_LOADING_ON = svbLoading != "" ? svbLoading.Substring(0, 1) : "";//
            SVB_ASSESABLE_RATE = GetString(row, "SVB_ASSESABLE_RATE");//
            SVB_DUTY_RATE = GetString(row, "SVB_DUTY_RATE");//
            string svbAssessStatus = GetString(row, "SVB_ASSESABLE_STATUS");
            SVB_ASSESABLE_STATUS = svbAssessStatus != "" ? svbAssessStatus.Substring(0, 1) : "";//
            string svbDutyStatus = GetString(row, "SVB_DUTY_STATUS");
            SVB_DUTY_STATUS = svbDutyStatus != "" ? svbDutyStatus.Substring(0, 1) : "";//

            // ── 14. Other details ─────────────────────────────────────────────────
            OTHER_PURCHASE_ORDER = GetString(row, "OTHER_PURCHASE_ORDER");//
            string poDateText = GetString(row, "OTHER_PURCHASE_ORDER_DATE");
            OTHER_PURCHASE_ORDER_DATE = string.IsNullOrEmpty(poDateText) ? "01/01/1900" : poDateText;//
            OTHER_CONTRACT_NO = GetString(row, "OTHER_CONTRACT_NO");//
            string contractDateText = GetString(row, "OTHER_CONTRACT_DATE");
            OTHER_CONTRACT_DATE = string.IsNullOrEmpty(contractDateText) ? "01/01/1900" : contractDateText;//
            OTHER_LOC_NO = GetString(row, "OTHER_LOC_NO");//
            string locDateText = GetString(row, "OTHER_LOC_DATE");
            OTHER_LOC_DATE = string.IsNullOrEmpty(locDateText) ? "01/01/1900" : locDateText;//
            OTHER_NATURE_OF_TRANSACTION = GetString(row, "OTHER_NATURE_OF_TRANSACTION");//
            OTHER_TERMS_OF_PAYMENT = GetString(row, "OTHER_TERMS_OF_PAYMENT");//
            OTHER_CONDITIONS = GetString(row, "OTHER_CONDITIONS");//
            OTHER_VALUATION_METHOD = GetString(row, "OTHER_VALUATION_METHOD");//

            // ── 15. Non-standard payment ──────────────────────────────────────────
            string nonStdEffectDtText = GetString(row, "NON_STD_EFFECT_DT_IMP");
            NON_STD_EFFECT_DT_IMP = string.IsNullOrEmpty(nonStdEffectDtText) ? "01/01/1900" : nonStdEffectDtText;//
            NON_STD_BANKNAME = GetString(row, "NON_STD_BANKNAME");//
            NON_STD_CERTIFICATE_NO = GetString(row, "NON_STD_CERTIFICATE_NO");//
            string nonStdCertDateText = GetString(row, "NON_STD_CERTIFICATE_DATE");
            NON_STD_CERTIFICATE_DATE = string.IsNullOrEmpty(nonStdCertDateText) ? "01/01/1900" : nonStdCertDateText;//

            // ── 16. SAP / Ship / Departure ────────────────────────────────────────
            SAP_DELIEVERY_ID = GetString(row, "SAP_DELIEVERY_ID");//
            string shipDateText = GetString(row, "SHIP_DATE");
            SHIP_DATE = string.IsNullOrEmpty(shipDateText) ? "01/01/1900" : shipDateText;//            
            COUNTRY_OF_DEPARTURE = GetString(row, "COUNTRY_OF_DEPARTURE");//
            INVOICE_LEVEL = GetString(row, "INVOICE_LEVEL");// always blank per live code
            REVENUEDEPOSIT_RATE = GetString(row, "REVENUEDEPOSIT_RATE");//
            REVENUEDEPOSIT_ON = GetString(row, "REVENUEDEPOSIT_ON");//

            // ── 17. MI fields — always blank in bulk upload ───────────────────────
            MI_FREIGHT = "";
            MI_INSURANCE = "";
            MI_MISC = "";
            MI_HSS = "";

            // ── 18. Audit fields ──────────────────────────────────────────────────
            MODIFIEDBY = currentuser;
            MODIFIEDON = LoginDate;
            INDEV_INV_TYPE = "";

            // ── 19. Third party ───────────────────────────────────────────────────
            TERMS_PLACE = GetString(row, "TERMS_PLACE");//
            THIRDPARTY_NAME = GetString(row, "THIRDPARTY_NAME");//
            THIRDPARTY_ADD1 = GetString(row, "THIRDPARTY_ADD1");//
            THIRDPARTY_ADD2 = GetString(row, "THIRDPARTY_ADD2");//
            THIRDPARTY_CITY = GetString(row, "THIRDPARTY_CITY");//
            T_PARTY_COUNTRY_SUB_DIV = GetString(row, "T_PARTY_COUNTRY_SUB_DIV");//
            T_PARTY_COUNTRY_CODE = GetString(row, "T_PARTY_COUNTRY_CODE");//
            T_PARTY_PIN = GetString(row, "T_PARTY_PIN");//

            // ── 20. AEO ───────────────────────────────────────────────────────────
            AUTHORIZED_ECONOMIC_OPERATOR_CODE = GetString(row, "AUTHORIZED_ECONOMIC_OPERATOR_CODE");//AEO_CODE
            A_E_O_COUNTRY = GetString(row, "AEO_COUNTRY");//
            AUTHORIZED_ECONOMIC_OPERATOR = GetString(row, "AUTHORIZED_ECONOMIC_OPERATOR");//AUTH_ECO_OPERATOR
            WHETHER_BUYER_SELLER_RELATED = GetString(row, "WHETHER_BUYER_SELLER_RELATED").ToUpper();// BUYER_SELLER_RELATED Y/N

            HANDLING_CHARGES = GetString(row, "D_AMOUNT");// HANDLING_CHARGES
            LOADING_CHARGES = GetString(row, "M_AMOUNT");// LOADING_CHARGES
            UNLOADING_CHARGES = GetString(row, "N_AMOUNT");// UNLOADING_CHARGES

            // ── 21. D/M/N amounts — only for FOB/CI per live code ─────────────────
            if (TERMS == "CI" || TERMS == "FOB")
            {
                double dAmt, mAmt, nAmt;

                double.TryParse(HANDLING_CHARGES, out dAmt);
                double.TryParse(LOADING_CHARGES, out mAmt);
                double.TryParse(UNLOADING_CHARGES, out nAmt);

                double tot = dAmt + mAmt + nAmt;
                TOTAL_OTHER_AMOUNT = tot.ToString();
                //TOTAL_OTHER_AMOUNT = tot != 0 ? tot.ToString() : "";
            }
            else
            {
                D_AMOUNT = "0"; M_AMOUNT = "0"; N_AMOUNT = "0";
                TOTAL_OTHER_AMOUNT = "0";
            }

            // ── 22. User / branch / period ────────────────────────────────────────
            USER_ID = currentuser;
            DATE_TIME = LoginDate;
            STATUS = "N";
            BRANCH_CODE = currentbranch;
            YEAR = "";
            WORKING_PERIOD = Working_Period;

            #endregion

            MAX_ID = Get_general_MAXID("INVOICE_MAX_ID");

            dt_INV.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, INVOICE_NO, INVOICE_DATE, TERMS, INVOICE_CURRENCY, INVOICE_EXRATE, INVOICE_VALUE, SUPPLIER_NAME, 
                SUPPLIER_ADDRESS, SUPPLIER_ADDRESS1, SUPPLIER_ADDRESS2, SUPPLIER_COUNTRY_NAME, SUPPLIER_COUNTRY_CODE, SUPPLIER_COUNTRY_PINCODE, SELLER_NAME, SELLER_ADDRESS, 
                SELLER_ADDRESS1, SELLER_ADDRESS2, SELLER_COUNTRY_NAME, SELLER_COUNTRY_CODE, SELLERCOUNTRY_PINCODE, BROKER_NAME, BROKER_ADDRESS, BROKER_ADDRESS1, BROKER_ADDRESS2, 
                BROKER_COUNTRY_NAME, BROKER_COUNTRY_CODE, BROKER_COUNTRY_PINCODE, MIS_CHARGES, MIS_RATE, MIS_CURRENCY, MIS_EXRATE, MIS_AGENCY_CHARGES, MIS_AGENCY_RATE, 
                MIS_AGENCY_CURRENCY, MIS_AGENCY_EXRATE, MIS_DISCOUNT_CHARGES, MIS_DISCOUNT_RATE, MIS_DISCOUNT_CURRENCY, MIS_DISCOUNT_EXRATE, MIS_DISCOUNT_REASON, 
                MIS_LOADING_CHARGES, MIS_LOADING_RATE, MIS_LOADING_CURRENCY, MIS_LOADING_EXRATE, MIS_FREIGHT_CHARGES, MIS_FREIGHT_RATE, MIS_FREIGHT_CURRENCY, MIS_FREIGHT_EXRATE, 
                MIS_INSURANCE_CHARGES, MIS_INSURANCE_RATE, MIS_INSURANCE_CURRENCY, MIS_INSURANCE_EXRATE, MIS_HIGHSEASALE_CHARGES, MIS_HIGHSEASALE_RATE, MIS_HIGHSEASALE_CURRENCY, 
                MIS_HIGHSEASALE_EXRATE, MIS_SINGLE_OR_MULITIPLE, SVB_RELATION, SVB_REF_NO, SVB_REF_DATE, SVB_CUSTOM_HOUSE, SVB_LOADING_ON, SVB_ASSESABLE_RATE, SVB_DUTY_RATE, 
                SVB_ASSESABLE_STATUS, SVB_DUTY_STATUS, OTHER_PURCHASE_ORDER, OTHER_PURCHASE_ORDER_DATE, OTHER_CONTRACT_NO, OTHER_CONTRACT_DATE, OTHER_LOC_NO, OTHER_LOC_DATE, 
                OTHER_NATURE_OF_TRANSACTION, OTHER_TERMS_OF_PAYMENT, OTHER_CONDITIONS, OTHER_VALUATION_METHOD, USER_ID, DATE_TIME, STATUS, BRANCH_CODE, YEAR, WORKING_PERIOD, 
                NON_STD_EFFECT_DT_IMP, NON_STD_BANKNAME, NON_STD_CERTIFICATE_NO, NON_STD_CERTIFICATE_DATE, SAP_DELIEVERY_ID, SHIP_DATE, INVOICE_LEVEL, COUNTRY_OF_DEPARTURE, 
                REVENUEDEPOSIT_RATE, REVENUEDEPOSIT_ON, MI_FREIGHT, MI_INSURANCE, MI_MISC, MI_HSS, MODIFIEDBY, MODIFIEDON, INDEV_INV_TYPE, TERMS_PLACE, THIRDPARTY_NAME, 
                THIRDPARTY_ADD1, THIRDPARTY_ADD2, THIRDPARTY_CITY, T_PARTY_COUNTRY_SUB_DIV, T_PARTY_COUNTRY_CODE, T_PARTY_PIN, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY,
                AUTHORIZED_ECONOMIC_OPERATOR, WHETHER_BUYER_SELLER_RELATED, "0", "0", "0", HANDLING_CHARGES, "0", "0", "0", "0", "0", "0", "0", "0", LOADING_CHARGES, UNLOADING_CHARGES, TOTAL_OTHER_AMOUNT);            

        }

        if (dt_INV.Rows.Count > 0)
        {
            if (flag == "U")
            {
                GetAndDeleteJobData("INVOICE_DETAILS");
                //var result = DeleteJobDataByTable("INVOICE_DETAILS");
            }
            //SqlBulk_Upload_ProductColid("INVOICE_DETAILS", dt_INV, Session["currentcomp_db"].ToString());
            SqlBulk_Upload_Product("INVOICE_DETAILS", dt_INV, Session["currentcomp_db"].ToString());
        }

        dt_INV.TableName = "INVOICE_DETAILS";
        data.Tables.Add(dt_INV);
        return dt_INV;
    }

    public DataTable Read_Item_DetailsOld(DataTable Item_Data)
    {

        #region Item_Data
        string[] columns = new string[]
        {
            "ITEM_ID", "JOBNO", "INVOICE_SLNO", "INVOICE_NO", "ITEM_SLNO","ITEM_DESCRIPTION", "ITEM_QTY", "ITEM_QTY_CODE", "ITEM_UNIT_PRICE","ITEM_TOTAL_AMOUNT",
            "ITEM_UNIT_CODE", "CTH_NO","PRODUCT_CTH","PRODUCT_RITC",/*"PRODUCT_CETH ",*/"SCHEME_CODE", "SCHEME_NOTN","SCHEME_NOTN_SLNO", "CTH_QTY1", "CTH_QTY1_CODE", "CTH_QTY2","CTH_QTY2_CODE", "GENEARL_DESCRIPTION", 
            "MANUFACTURER", "BRAND","MODEL", "END_USE_OF_ITEM", "COUNTRY_OF_ORIGIN", "ACCESSORIES","PREVIOUS_BE_NO", "PREVIOUS_BE_DATE", "UNIT_PRICE", "UNIT_CODE","CUSTOMS_HOUSE", 
            "PRODUCT_BCD_NOTN", "PRODUCT_BCD_SLNO","PRODUCT_EDU_CESS_NOTN", "PRODUCT_EDU_CESS_NOTN_SL", "PRODUCT_NCD_SLNO","PRODUCT_NCD_NOTN", "PRODUCT_SEC_EDU_CESS_NOTN_SL",
            "PRODUCT_AGGREGATE_DUTY_NOTN", "PRODUCT_AGGREGATE_DUTY_NOTN_SL","PRODUCT_SAFEGUARD_NOTN", "PRODUCT_SAFEGUARD_SLNO","PRODUCT_SAPTA_SLNO", "PRODUCT_SAPTA_NOTN",
            "PRODUCT_TARIFF_NOTN", "PRODUCT_TARIFF_SLNO", "PRODUCT_TARIFF_QTY","PRODUCT_TARIFF_AMOUNT", "PRODUCT_TARIFF_AMOUNT_UNIT", "PRODUCT_CETH","PRODUCT_CVD_NOTN", 
            "PRODUCT_CVD_SLNO","PRODUCT_ADDL_SHEII_NOTN", "PRODUCT_ADDL_SHEII_SLNO","PRODUCT_ADDL_HEALTH_CESS_NOTN", "PRODUCT_ADDL_HEALTH_CESS_SLNO","PRODUCT_CESS_NOTN", 
            "PRODUCT_CESS_SLNO","PRODUCT_OTHER_DUTY_NOTN", "PRODUCT_OTHER_DUTY_SLNO", "CTH_SLNO", "CTH_SUPPLIER_SLNO","CTH_QTY", "CENTRAL_EXCISE_FLAG",// "PRODUCT_OTHER_DUTY_RATE",
            "M_P_GROWER_ADD1", "M_P_GROWER_ADD2", "M_P_GROWER_CITY","M_P_GROWER_COUNTRY_SUBDIV", "M_P_GROWER_PIN", "M_P_GROWER_COUNTRY","SOURCE_COUNTRY", "TRANSIT_COUNTRY", 
            "ACCESSORY_STATUS","IGST_LEVY_NOTN", "IGST_LEVY_SLNO","IGST_LEVY_EXCEPTION_NOTN", "IGST_LEVY_EXCEPTION_SLNO","LEVY_EXCEMPTION_NOTN_TYPE",
            "IGST_LEVY_COMPENSATION_CESS_NOTN", "IGST_LEVY_COMPENSATION_CESS_SLNO","IGST_LEVY_EXCEPTION_CC_NOTN", "IGST_LEVY_EXCEPTION_CC_SLNO","LEVY_EXCEPTION_CC_NOTN_TYPE",
            "SOCIAL_WELFARE_NOTN", "SOCIAL_WELFARE_NOTN_SLNO","AIDC_NOTN", "AIDC_NOTN_SLNO",
            "USER_ID", "DATE_TIME", "STATUS", "BRANCH_CODE","YEAR", "WORKING_PERIOD", "MODIFIEDBY", "MODIFIEDON",
            //added on 16-06-2026 by George Bush
            "PRODUCT_BCD_RATE", "PRODUCT_BCD_SPL", "PRODUCT_BCD_UNIT", "PRODUCT_BCD_SPL_TYPE", "PRODUCT_ADDL_DUTY_NOTN", "PRODUCT_ADDL_DUTY_NOTN_SL", "PRODUCT_ADDL_DUTY_RATE", 
            "PRODUCT_EDU_CESS_RATE", "PRODUCT_SEC_EDU_CESS_RATE", "PRODUCT_NCD_RATE", "PRODUCT_NCD_SPL", "PRODUCT_NCD_UNIT", "PRODUCT_NCD_SPL_TYPE", 
            "PRODUCT_AGGREGATE_DUTY_NOTN_RATE", "PRODUCT_SAFEGUARD_RATE", "PRODUCT_SAFEGUARD_SPL", "PRODUCT_SAFEGUARD_UNIT", "PRODUCT_SAFEGUARD_SPL_TYPE", 
            "PRODUCT_SAPTA_RATE", "PRODUCT_MRP_YN", "PRODUCT_MRP_SL_NO", "PRODUCT_MRP_AMOUNT", "PRODUCT_MRP_ABT_RATE", "PRODUCT_CVD_RATE", "PRODUCT_CVD_SPL", "PRODUCT_CVD_UNIT", 
            "PRODUCT_CVD_SPL_TYPE", "PRODUCT_CVD_EDU_CESS_RATE", "PRODUCT_CVD_SEC_EDU_CESS_RATE", "PRODUCT_ADDL5_SIA_NOTN", "PRODUCT_ADDL5_SIA_NOTN_SL", "PRODUCT_ADDL5_SIA_RATE", 
            "PRODUCT_ADDL_GSI_NOTN", "PRODUCT_ADDL_GSI_SLNO", "PRODUCT_ADDL_GSI_RATE", "PRODUCT_ADDL_GSI_SPL", "PRODUCT_ADDL_GSI_UNIT", "PRODUCT_ADDL_GSI_SPL_TYPE", 
            "PRODUCT_ADDL_SHEII_RATE", "PRODUCT_ADDL_SHEII_SPL", "PRODUCT_ADDL_SHEII_UNIT", "PRODUCT_ADDL_SHEII_TYPE", "PRODUCT_ADDL_TTA_NOTN", "PRODUCT_ADDL_TTA_SLNO", 
            "PRODUCT_ADDL_TTA_RATE", "PRODUCT_ADDL_TTA_SPL", "PRODUCT_ADDL_TTA_UNIT", "PRODUCT_ADDL_TTA_TYPE", "PRODUCT_ADDL_HEALTH_CESS_RATE", "PRODUCT_ADDL_HEALTH_CESS_SPL", 
            "PRODUCT_ADDL_HEALTH_CESS_UNIT", "PRODUCT_ADDL_HEALTH_CESS_TYPE", "PRODUCT_CESS_RATE", "PRODUCT_CESS_SPL", "PRODUCT_CESS_UNIT", "PRODUCT_CESS_TYPE", "WAREHOUSE_JOBNO", 
            "WAREHOUSE_INVOICE_SLNO", "WAREHOUSE_ITEM_SLNO", "ASSESSABLE_VALUE", "DUTY_VALUE", "CIF_VALUE", "CVD_VALUE", "BASIC_VALUE", "CEC_VALUE", "CHEC_VALUE", 
            "ADD_DUTY_VALUE", "CETH_CVD_EDU_CESS_SL", "CETH_CVD_EDU_CESS_RATE", "CETH_CVD_SEC_EDU_CESS_SL", "CETH_CVD_SEC_EDU_CESS_RATE", "PRODUCT_OTHER_DUTY_RATE", 
            "PRODUCT_OTHER_DUTY_SPL", "PRODUCT_OTHER_DUTY_UNIT", "PRODUCT_OTHER_DUTY_TYPE", "INDIVITUAL_FREIGHT_AMOUNT", "INDIVITUAL_INSURANCE_AMOUNT", "INDIVITUAL_MISC_AMOUNT", 
            "SVB_RELATION", "SVB_REF_NO", "SVB_REF_DATE", "SVB_CUSTOM_HOUSE", "SVB_LOADING_ON", "SVB_ASSESABLE_RATE", "SVB_DUTY_RATE", "SVB_ASSESABLE_STATUS", "SVB_DUTY_STATUS", 
            "INDIVITUAL_EDU_CESS_AMT", "INDIVITUAL_SEC_HIGHER_CESS_AMT", "INDIVITUAL_LANDING_CHARGE", "CHECKLIST_BCD_RATE", "CHECKLIST_CVD_RATE", "CHECKLIST_ADDL_DUTY_RATE", 
            "INDEV_RACK_TYPE", "MERIT_DUTY_VALUE", "RSP_APPLICABLE", "MANUFACTURER_PRODUCER", "M_P_GROWER_CODE", "INFRA_CESS_NOTN", "INFRA_CESS_NOTN_SL", "INFRA_CESS_NOTN_RATE", 
            "MERIT_BASIC_VALUE", "MERIT_CVD_VALUE", "MERIT_CEC_VALUE", "MERIT_CHEC_VALUE", "MERIT_ADD_DUTY_VALUE", "MERIT_NOTN_BASIC_VALUE", "MERIT_NOTN_CVD_VALUE", 
            "MERIT_NOTN_CEC_VALUE", "MERIT_NOTN_CHEC_VALUE", "MERIT_NOTN_ADD_DUTY_VALUE", "MERIT_NOTN_CESS_VALUE", "MERIT_NOTN_NCD_VALUE", "INDIVITUAL_HSS_AMOUNT", 
            "IGST_LEVY_RATE", "IGST_LEVY_SPL", "IGST_LEVY_UNIT", "IGST_LEVY_SPL_TYPE", "IGST_LEVY_EXCEPTION_RATE", "IGST_LEVY_COMPENSATION_CESS_RATE", 
            "IGST_LEVY_COMPENSATION_CESS_SPL", "IGST_LEVY_COMPENSATION_CESS_UNIT", "IGST_LEVY_COMPENSATION_CESS_SPL_TYPE", "IGST_LEVY_EXCEPTION_CC_RATE", 
            "CHECKLIST_IGST_LEVY_AMOUNT", "CHECKLIST_COMPENSATION_CC_AMOUNT"
        };


        foreach (string col in columns)
            dt_ITEM.Columns.Add(col);

        #endregion

        for (int i = 0; i <= Item_Data.Rows.Count - 1; i++)
        {
            #region

            #region excel data

            DataRow dtRow = Item_Data.Rows[i];

            INVOICE_SLNO = GetString(dtRow, "INVOICE_SLNO");
            INVOICE_NO = GetString(dtRow, "INVOICE_NO");
            ITEM_SLNO = GetString(dtRow, "ITEM_SLNO");
            ITEM_DESCRIPTION = GetString(dtRow, "ITEM_DESCRIPTION");
            ITEM_QTY = GetString(dtRow, "ITEM_QTY");
            ITEM_QTY_CODE = GetString(dtRow, "ITEM_QTY_CODE");
            ITEM_UNIT_PRICE = GetString(dtRow, "ITEM_UNIT_PRICE");
            double TOTAL_AMOUNT = 0.00;
            if (ITEM_QTY != "" && ITEM_UNIT_PRICE != "")
            {
                TOTAL_AMOUNT = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE);
            }
            ITEM_TOTAL_AMOUNT = Convert.ToString(TOTAL_AMOUNT);
            ITEM_UNIT_CODE = GetString(dtRow, "ITEM_UNIT_CODE");
            CTH_NO = GetString(dtRow, "CTH_NO");
            PRODUCT_CTH = GetString(dtRow, "CTH_NO");
            PRODUCT_RITC = GetString(dtRow, "RITC_NO");
            PRODUCT_CETH = GetString(dtRow, "CETH_NO");
            SCHEME_CODE = GetString(dtRow, "SCHEME_CODE");
            SCHEME_NOTN = GetString(dtRow, "SCHEME_NOTN");
            SCHEME_NOTN_SLNO = GetString(dtRow, "SCHEME_NOTN_SLNO");
            CTH_QTY1 = GetString(dtRow, "CTH_QTY1");
            CTH_QTY1_CODE = GetString(dtRow, "CTH_QTY1_CODE");
            CTH_QTY2 = GetString(dtRow, "CTH_QTY2");
            CTH_QTY2_CODE = GetString(dtRow, "CTH_QTY2_CODE");
            GENEARL_DESCRIPTION = GetString(dtRow, "GENEARL_DESCRIPTION");
            MANUFACTURER = GetString(dtRow, "MANUFACTURER");
            BRAND = GetString(dtRow, "BRAND");
            MODEL = GetString(dtRow, "MODEL");
            END_USE_OF_ITEM = GetString(dtRow, "END_USE_OF_ITEM");
            COUNTRY_OF_ORIGIN = GetString(dtRow, "COUNTRY_OF_ORIGIN");
            ACCESSORIES = GetString(dtRow, "ACCESSORIES");
            PREVIOUS_BE_NO = GetString(dtRow, "PREVIOUS_BE_NO");
            string prevBeDateText = GetString(dtRow, "PREVIOUS_BE_DATE");
            PREVIOUS_BE_DATE = string.IsNullOrEmpty(prevBeDateText) ? "01/01/1900" : prevBeDateText;
            UNIT_PRICE = GetString(dtRow, "UNIT_PRICE");
            UNIT_CODE = GetString(dtRow, "UNIT_CODE");
            CUSTOMS_HOUSE = GetString(dtRow, "CUSTOMS_HOUSE");
            PRODUCT_BCD_NOTN = GetString(dtRow, "PRODUCT_BCD_NOTN");
            PRODUCT_BCD_SLNO = GetString(dtRow, "PRODUCT_BCD_SLNO");
            PRODUCT_EDU_CESS_NOTN = GetString(dtRow, "PRODUCT_EDU_CESS_NOTN");
            PRODUCT_EDU_CESS_NOTN_SL = GetString(dtRow, "PRODUCT_EDU_CESS_NOTN_SL");
            PRODUCT_NCD_SLNO = GetString(dtRow, "PRODUCT_NCD_SLNO");
            PRODUCT_NCD_NOTN = GetString(dtRow, "PRODUCT_NCD_NOTN");
            PRODUCT_SEC_EDU_CESS_NOTN_SL = GetString(dtRow, "PRODUCT_SEC_EDU_CESS_NOTN_SL");
            PRODUCT_AGGREGATE_DUTY_NOTN = GetString(dtRow, "PRODUCT_AGGREGATE_DUTY_NOTN");
            PRODUCT_AGGREGATE_DUTY_NOTN_SL = GetString(dtRow, "PRODUCT_AGGREGATE_DUTY_NOTN_SL");
            PRODUCT_SAFEGUARD_NOTN = GetString(dtRow, "PRODUCT_SAFEGUARD_NOTN");
            PRODUCT_SAFEGUARD_SLNO = GetString(dtRow, "PRODUCT_SAFEGUARD_SLNO");
            PRODUCT_SAPTA_SLNO = GetString(dtRow, "PRODUCT_SAPTA_SLNO");
            PRODUCT_SAPTA_NOTN = GetString(dtRow, "PRODUCT_SAPTA_NOTN");
            PRODUCT_TARIFF_NOTN = GetString(dtRow, "PRODUCT_TARIFF_NOTN");
            PRODUCT_TARIFF_SLNO = GetString(dtRow, "PRODUCT_TARIFF_SLNO");
            PRODUCT_TARIFF_QTY = GetString(dtRow, "PRODUCT_TARIFF_QTY");
            PRODUCT_TARIFF_AMOUNT = GetString(dtRow, "PRODUCT_TARIFF_AMOUNT");
            PRODUCT_TARIFF_AMOUNT_UNIT = GetString(dtRow, "PRODUCT_TARIFF_AMOUNT_UNIT");
            //PRODUCT_CETH = GetString(dtRow, "PRODUCT_CETH");
            PRODUCT_CVD_NOTN = GetString(dtRow, "PRODUCT_CVD_NOTN");
            PRODUCT_CVD_SLNO = GetString(dtRow, "PRODUCT_CVD_SLNO");
            PRODUCT_ADDL_SHEII_NOTN = GetString(dtRow, "PRODUCT_ADDL_SHEII_NOTN");
            PRODUCT_ADDL_SHEII_SLNO = GetString(dtRow, "PRODUCT_ADDL_SHEII_SLNO");
            PRODUCT_ADDL_HEALTH_CESS_NOTN = GetString(dtRow, "PRODUCT_ADDL_HEALTH_CESS_NOTN");
            PRODUCT_ADDL_HEALTH_CESS_SLNO = GetString(dtRow, "PRODUCT_ADDL_HEALTH_CESS_SLNO");
            PRODUCT_CESS_NOTN = GetString(dtRow, "PRODUCT_CESS_NOTN");
            PRODUCT_CESS_SLNO = GetString(dtRow, "PRODUCT_CESS_SLNO");
            PRODUCT_OTHER_DUTY_NOTN = GetString(dtRow, "PRODUCT_OTHER_DUTY_NOTN");
            PRODUCT_OTHER_DUTY_SLNO = GetString(dtRow, "PRODUCT_OTHER_DUTY_SLNO");
            CTH_SLNO = GetString(dtRow, "CTH_SLNO");
            CTH_SUPPLIER_SLNO = GetString(dtRow, "CTH_SUPPLIER_SLNO");
            CTH_QTY = GetString(dtRow, "CTH_QTY");
            CENTRAL_EXCISE_FLAG = GetString(dtRow, "CENTRAL_EXCISE_FLAG");
            M_P_GROWER_ADD1 = GetString(dtRow, "M_P_GROWER_ADD1");
            M_P_GROWER_ADD2 = GetString(dtRow, "M_P_GROWER_ADD2");
            M_P_GROWER_CITY = GetString(dtRow, "M_P_GROWER_CITY");
            M_P_GROWER_COUNTRY_SUBDIV = GetString(dtRow, "M_P_GROWER_COUNTRY_SUBDIV");
            M_P_GROWER_PIN = GetString(dtRow, "M_P_GROWER_PIN");
            M_P_GROWER_COUNTRY = GetString(dtRow, "M_P_GROWER_COUNTRY");
            SOURCE_COUNTRY = GetString(dtRow, "SOURCE_COUNTRY");
            TRANSIT_COUNTRY = GetString(dtRow, "TRANSIT_COUNTRY");
            ACCESSORY_STATUS = GetString(dtRow, "ACCESSORY_STATUS");
            IGST_LEVY_NOTN = GetString(dtRow, "IGST_LEVY_NOTN");
            IGST_LEVY_SLNO = GetString(dtRow, "IGST_LEVY_SLNO");
            IGST_LEVY_EXCEPTION_NOTN = GetString(dtRow, "IGST_LEVY_EXCEPTION_NOTN");
            IGST_LEVY_EXCEPTION_SLNO = GetString(dtRow, "IGST_LEVY_EXCEPTION_SLNO");
            LEVY_EXCEMPTION_NOTN_TYPE = GetString(dtRow, "LEVY_EXCEMPTION_NOTN_TYPE");
            IGST_LEVY_COMPENSATION_CESS_NOTN = GetString(dtRow, "IGST_LEVY_COMPENSATION_CESS_NOTN");
            IGST_LEVY_COMPENSATION_CESS_SLNO = GetString(dtRow, "IGST_LEVY_COMPENSATION_CESS_SLNO");
            IGST_LEVY_EXCEPTION_CC_NOTN = GetString(dtRow, "IGST_LEVY_EXCEPTION_CC_NOTN");
            IGST_LEVY_EXCEPTION_CC_SLNO = GetString(dtRow, "IGST_LEVY_EXCEPTION_CC_SLNO");
            LEVY_EXCEPTION_CC_NOTN_TYPE = GetString(dtRow, "LEVY_EXCEPTION_CC_NOTN_TYPE");
            SOCIAL_WELFARE_NOTN = GetString(dtRow, "SOCIAL_WELFARE_NOTN");
            SOCIAL_WELFARE_NOTN_SLNO = GetString(dtRow, "SOCIAL_WELFARE_NOTN_SLNO");
            AIDC_NOTN = GetString(dtRow, "AIDC_NOTN");
            AIDC_NOTN_SLNO = GetString(dtRow, "AIDC_NOTN_SLNO");

            SVB_REF_NO = GetString(dtRow, "SVB_REF_NO");
            SVB_RELATION = !string.IsNullOrEmpty(SVB_REF_NO) ? "True" : "False";
            string svbRefDateText = GetString(dtRow, "SVB_REF_DATE");
            SVB_REF_DATE = string.IsNullOrEmpty(svbRefDateText) ? "01/01/1900" : svbRefDateText;
            SVB_CUSTOM_HOUSE = GetString(dtRow, "SVB_CUSTOM_HOUSE");
            SVB_LOADING_ON = GetString(dtRow, "SVB_LOADING_ON");
            SVB_ASSESABLE_RATE = GetString(dtRow, "SVB_ASSESABLE_RATE");
            SVB_DUTY_RATE = GetString(dtRow, "SVB_DUTY_RATE");
            SVB_ASSESABLE_STATUS = GetString(dtRow, "SVB_ASSESABLE_STATUS");
            SVB_DUTY_STATUS = GetString(dtRow, "SVB_DUTY_STATUS");

            #region default value without getting from excel

            PRODUCT_BCD_RATE = ""; PRODUCT_BCD_SPL = ""; PRODUCT_BCD_UNIT = ""; PRODUCT_BCD_SPL_TYPE = ""; PRODUCT_ADDL_DUTY_NOTN = ""; PRODUCT_ADDL_DUTY_NOTN_SL = "";
            PRODUCT_ADDL_DUTY_RATE = ""; PRODUCT_EDU_CESS_RATE = ""; PRODUCT_SEC_EDU_CESS_RATE = ""; PRODUCT_NCD_RATE = ""; PRODUCT_NCD_SPL = ""; PRODUCT_NCD_UNIT = "";
            PRODUCT_NCD_SPL_TYPE = ""; PRODUCT_AGGREGATE_DUTY_NOTN_RATE = ""; PRODUCT_SAFEGUARD_RATE = ""; PRODUCT_SAFEGUARD_SPL = ""; PRODUCT_SAFEGUARD_UNIT = "";
            PRODUCT_SAFEGUARD_SPL_TYPE = ""; PRODUCT_SAPTA_RATE = ""; PRODUCT_MRP_YN = ""; PRODUCT_MRP_SL_NO = ""; PRODUCT_MRP_AMOUNT = ""; PRODUCT_MRP_ABT_RATE = "";
            PRODUCT_CVD_RATE = ""; PRODUCT_CVD_SPL = ""; PRODUCT_CVD_UNIT = ""; PRODUCT_CVD_SPL_TYPE = ""; PRODUCT_CVD_EDU_CESS_RATE = ""; PRODUCT_CVD_SEC_EDU_CESS_RATE = "";
            PRODUCT_ADDL5_SIA_NOTN = ""; PRODUCT_ADDL5_SIA_NOTN_SL = ""; PRODUCT_ADDL5_SIA_RATE = ""; PRODUCT_ADDL_GSI_NOTN = ""; PRODUCT_ADDL_GSI_SLNO = "";
            PRODUCT_ADDL_GSI_RATE = ""; PRODUCT_ADDL_GSI_SPL = ""; PRODUCT_ADDL_GSI_UNIT = ""; PRODUCT_ADDL_GSI_SPL_TYPE = ""; PRODUCT_ADDL_SHEII_RATE = "";
            PRODUCT_ADDL_SHEII_SPL = ""; PRODUCT_ADDL_SHEII_UNIT = ""; PRODUCT_ADDL_SHEII_TYPE = ""; PRODUCT_ADDL_TTA_NOTN = ""; PRODUCT_ADDL_TTA_SLNO = "";
            PRODUCT_ADDL_TTA_RATE = ""; PRODUCT_ADDL_TTA_SPL = ""; PRODUCT_ADDL_TTA_UNIT = ""; PRODUCT_ADDL_TTA_TYPE = ""; PRODUCT_ADDL_HEALTH_CESS_RATE = "";
            PRODUCT_ADDL_HEALTH_CESS_SPL = ""; PRODUCT_ADDL_HEALTH_CESS_UNIT = ""; PRODUCT_ADDL_HEALTH_CESS_TYPE = ""; PRODUCT_CESS_RATE = ""; PRODUCT_CESS_SPL = "";
            PRODUCT_CESS_UNIT = ""; PRODUCT_CESS_TYPE = ""; WAREHOUSE_JOBNO = "0"; WAREHOUSE_INVOICE_SLNO = "0"; WAREHOUSE_ITEM_SLNO = "0"; ASSESSABLE_VALUE = "";
            DUTY_VALUE = ""; CIF_VALUE = ""; CVD_VALUE = ""; BASIC_VALUE = ""; CEC_VALUE = ""; CHEC_VALUE = ""; ADD_DUTY_VALUE = ""; CETH_CVD_EDU_CESS_SL = "";
            CETH_CVD_EDU_CESS_RATE = "0.00"; CETH_CVD_SEC_EDU_CESS_SL = ""; CETH_CVD_SEC_EDU_CESS_RATE = ""; PRODUCT_OTHER_DUTY_RATE = ""; PRODUCT_OTHER_DUTY_SPL = "";
            PRODUCT_OTHER_DUTY_UNIT = ""; PRODUCT_OTHER_DUTY_TYPE = ""; INDIVITUAL_FREIGHT_AMOUNT = ""; INDIVITUAL_INSURANCE_AMOUNT = ""; INDIVITUAL_MISC_AMOUNT = ""; //SVB_RELATION = "";

            INDIVITUAL_EDU_CESS_AMT = ""; INDIVITUAL_SEC_HIGHER_CESS_AMT = ""; INDIVITUAL_LANDING_CHARGE = "";
            CHECKLIST_BCD_RATE = ""; CHECKLIST_CVD_RATE = ""; CHECKLIST_ADDL_DUTY_RATE = ""; INDEV_RACK_TYPE = ""; MERIT_DUTY_VALUE = ""; RSP_APPLICABLE = "N";
            MANUFACTURER_PRODUCER = ""; M_P_GROWER_CODE = ""; INFRA_CESS_NOTN = ""; INFRA_CESS_NOTN_SL = ""; INFRA_CESS_NOTN_RATE = ""; MERIT_BASIC_VALUE = "";
            MERIT_CVD_VALUE = ""; MERIT_CEC_VALUE = ""; MERIT_CHEC_VALUE = ""; MERIT_ADD_DUTY_VALUE = ""; MERIT_NOTN_BASIC_VALUE = ""; MERIT_NOTN_CVD_VALUE = "";
            MERIT_NOTN_CEC_VALUE = ""; MERIT_NOTN_CHEC_VALUE = ""; MERIT_NOTN_ADD_DUTY_VALUE = ""; MERIT_NOTN_CESS_VALUE = ""; MERIT_NOTN_NCD_VALUE = "";
            INDIVITUAL_HSS_AMOUNT = ""; IGST_LEVY_RATE = ""; IGST_LEVY_SPL = ""; IGST_LEVY_UNIT = ""; IGST_LEVY_SPL_TYPE = ""; IGST_LEVY_EXCEPTION_RATE = "";
            IGST_LEVY_COMPENSATION_CESS_RATE = ""; IGST_LEVY_COMPENSATION_CESS_SPL = ""; IGST_LEVY_COMPENSATION_CESS_UNIT = ""; IGST_LEVY_COMPENSATION_CESS_SPL_TYPE = "";
            IGST_LEVY_EXCEPTION_CC_RATE = ""; CHECKLIST_IGST_LEVY_AMOUNT = ""; CHECKLIST_COMPENSATION_CC_AMOUNT = "";

            #endregion

            #endregion

            MAX_ID = Get_general_MAXID("ITEM_MAX_ID");

            dt_ITEM.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, INVOICE_NO, ITEM_SLNO, ITEM_DESCRIPTION, ITEM_QTY, ITEM_QTY_CODE, ITEM_UNIT_PRICE, ITEM_TOTAL_AMOUNT, ITEM_UNIT_CODE, CTH_NO, PRODUCT_CTH, PRODUCT_RITC,
             SCHEME_CODE, SCHEME_NOTN, SCHEME_NOTN_SLNO, CTH_QTY1, CTH_QTY1_CODE, CTH_QTY2, CTH_QTY2_CODE, GENEARL_DESCRIPTION, MANUFACTURER, BRAND, MODEL, END_USE_OF_ITEM,
             COUNTRY_OF_ORIGIN, ACCESSORIES, PREVIOUS_BE_NO, PREVIOUS_BE_DATE, UNIT_PRICE, UNIT_CODE, CUSTOMS_HOUSE, PRODUCT_BCD_NOTN, PRODUCT_BCD_SLNO, PRODUCT_EDU_CESS_NOTN,
             PRODUCT_EDU_CESS_NOTN_SL, PRODUCT_NCD_SLNO, PRODUCT_NCD_NOTN, PRODUCT_SEC_EDU_CESS_NOTN_SL, PRODUCT_AGGREGATE_DUTY_NOTN, PRODUCT_AGGREGATE_DUTY_NOTN_SL,
             PRODUCT_SAFEGUARD_NOTN, PRODUCT_SAFEGUARD_SLNO, PRODUCT_SAPTA_SLNO, PRODUCT_SAPTA_NOTN, PRODUCT_TARIFF_NOTN, PRODUCT_TARIFF_SLNO, PRODUCT_TARIFF_QTY,
             PRODUCT_TARIFF_AMOUNT, PRODUCT_TARIFF_AMOUNT_UNIT, PRODUCT_CETH, PRODUCT_CVD_NOTN, PRODUCT_CVD_SLNO, PRODUCT_ADDL_SHEII_NOTN, PRODUCT_ADDL_SHEII_SLNO,
             PRODUCT_ADDL_HEALTH_CESS_NOTN, PRODUCT_ADDL_HEALTH_CESS_SLNO, PRODUCT_CESS_NOTN, PRODUCT_CESS_SLNO, PRODUCT_OTHER_DUTY_NOTN, PRODUCT_OTHER_DUTY_SLNO,//PRODUCT_OTHER_DUTY_RATE,
             CTH_SLNO, CTH_SUPPLIER_SLNO, CTH_QTY, CENTRAL_EXCISE_FLAG, M_P_GROWER_ADD1, M_P_GROWER_ADD2, M_P_GROWER_CITY, M_P_GROWER_COUNTRY_SUBDIV,
             M_P_GROWER_PIN, M_P_GROWER_COUNTRY, SOURCE_COUNTRY, TRANSIT_COUNTRY, ACCESSORY_STATUS, IGST_LEVY_NOTN, IGST_LEVY_SLNO, IGST_LEVY_EXCEPTION_NOTN,
             IGST_LEVY_EXCEPTION_SLNO, LEVY_EXCEMPTION_NOTN_TYPE, IGST_LEVY_COMPENSATION_CESS_NOTN, IGST_LEVY_COMPENSATION_CESS_SLNO, IGST_LEVY_EXCEPTION_CC_NOTN,
             IGST_LEVY_EXCEPTION_CC_SLNO, LEVY_EXCEPTION_CC_NOTN_TYPE, SOCIAL_WELFARE_NOTN, SOCIAL_WELFARE_NOTN_SLNO, AIDC_NOTN, AIDC_NOTN_SLNO,
             currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate,
                //Added on 16-06-2026
             PRODUCT_BCD_RATE, PRODUCT_BCD_SPL, PRODUCT_BCD_UNIT, PRODUCT_BCD_SPL_TYPE, PRODUCT_ADDL_DUTY_NOTN, PRODUCT_ADDL_DUTY_NOTN_SL, PRODUCT_ADDL_DUTY_RATE,
             PRODUCT_EDU_CESS_RATE, PRODUCT_SEC_EDU_CESS_RATE, PRODUCT_NCD_RATE, PRODUCT_NCD_SPL, PRODUCT_NCD_UNIT, PRODUCT_NCD_SPL_TYPE, PRODUCT_AGGREGATE_DUTY_NOTN_RATE,
             PRODUCT_SAFEGUARD_RATE, PRODUCT_SAFEGUARD_SPL, PRODUCT_SAFEGUARD_UNIT, PRODUCT_SAFEGUARD_SPL_TYPE, PRODUCT_SAPTA_RATE, PRODUCT_MRP_YN, PRODUCT_MRP_SL_NO,
             PRODUCT_MRP_AMOUNT, PRODUCT_MRP_ABT_RATE, PRODUCT_CVD_RATE, PRODUCT_CVD_SPL, PRODUCT_CVD_UNIT, PRODUCT_CVD_SPL_TYPE, PRODUCT_CVD_EDU_CESS_RATE,
             PRODUCT_CVD_SEC_EDU_CESS_RATE, PRODUCT_ADDL5_SIA_NOTN, PRODUCT_ADDL5_SIA_NOTN_SL, PRODUCT_ADDL5_SIA_RATE, PRODUCT_ADDL_GSI_NOTN, PRODUCT_ADDL_GSI_SLNO,
             PRODUCT_ADDL_GSI_RATE, PRODUCT_ADDL_GSI_SPL, PRODUCT_ADDL_GSI_UNIT, PRODUCT_ADDL_GSI_SPL_TYPE, PRODUCT_ADDL_SHEII_RATE, PRODUCT_ADDL_SHEII_SPL, PRODUCT_ADDL_SHEII_UNIT,
             PRODUCT_ADDL_SHEII_TYPE, PRODUCT_ADDL_TTA_NOTN, PRODUCT_ADDL_TTA_SLNO, PRODUCT_ADDL_TTA_RATE, PRODUCT_ADDL_TTA_SPL, PRODUCT_ADDL_TTA_UNIT, PRODUCT_ADDL_TTA_TYPE,
             PRODUCT_ADDL_HEALTH_CESS_RATE, PRODUCT_ADDL_HEALTH_CESS_SPL, PRODUCT_ADDL_HEALTH_CESS_UNIT, PRODUCT_ADDL_HEALTH_CESS_TYPE, PRODUCT_CESS_RATE, PRODUCT_CESS_SPL,
             PRODUCT_CESS_UNIT, PRODUCT_CESS_TYPE, WAREHOUSE_JOBNO, WAREHOUSE_INVOICE_SLNO, WAREHOUSE_ITEM_SLNO, ASSESSABLE_VALUE, DUTY_VALUE, CIF_VALUE, CVD_VALUE, BASIC_VALUE,
             CEC_VALUE, CHEC_VALUE, ADD_DUTY_VALUE, CETH_CVD_EDU_CESS_SL, CETH_CVD_EDU_CESS_RATE, CETH_CVD_SEC_EDU_CESS_SL, CETH_CVD_SEC_EDU_CESS_RATE, PRODUCT_OTHER_DUTY_RATE,
             PRODUCT_OTHER_DUTY_SPL, PRODUCT_OTHER_DUTY_UNIT, PRODUCT_OTHER_DUTY_TYPE, INDIVITUAL_FREIGHT_AMOUNT, INDIVITUAL_INSURANCE_AMOUNT, INDIVITUAL_MISC_AMOUNT,
             SVB_RELATION, SVB_REF_NO, SVB_REF_DATE, SVB_CUSTOM_HOUSE, SVB_LOADING_ON, SVB_ASSESABLE_RATE, SVB_DUTY_RATE, SVB_ASSESABLE_STATUS, SVB_DUTY_STATUS,
             INDIVITUAL_EDU_CESS_AMT, INDIVITUAL_SEC_HIGHER_CESS_AMT, INDIVITUAL_LANDING_CHARGE, CHECKLIST_BCD_RATE, CHECKLIST_CVD_RATE, CHECKLIST_ADDL_DUTY_RATE, INDEV_RACK_TYPE, MERIT_DUTY_VALUE,
             RSP_APPLICABLE, MANUFACTURER_PRODUCER, M_P_GROWER_CODE, INFRA_CESS_NOTN, INFRA_CESS_NOTN_SL, INFRA_CESS_NOTN_RATE, MERIT_BASIC_VALUE, MERIT_CVD_VALUE, MERIT_CEC_VALUE,
             MERIT_CHEC_VALUE, MERIT_ADD_DUTY_VALUE, MERIT_NOTN_BASIC_VALUE, MERIT_NOTN_CVD_VALUE, MERIT_NOTN_CEC_VALUE, MERIT_NOTN_CHEC_VALUE, MERIT_NOTN_ADD_DUTY_VALUE,
             MERIT_NOTN_CESS_VALUE, MERIT_NOTN_NCD_VALUE, INDIVITUAL_HSS_AMOUNT, IGST_LEVY_RATE, IGST_LEVY_SPL, IGST_LEVY_UNIT, IGST_LEVY_SPL_TYPE, IGST_LEVY_EXCEPTION_RATE,
             IGST_LEVY_COMPENSATION_CESS_RATE, IGST_LEVY_COMPENSATION_CESS_SPL, IGST_LEVY_COMPENSATION_CESS_UNIT, IGST_LEVY_COMPENSATION_CESS_SPL_TYPE, IGST_LEVY_EXCEPTION_CC_RATE,
             CHECKLIST_IGST_LEVY_AMOUNT, CHECKLIST_COMPENSATION_CC_AMOUNT);

            #endregion

        }

        if (dt_ITEM.Rows.Count > 0)
        {

            var result = DeleteJobDataByTable("ITEM_PRODUCT_DETAILS");

            //if (!result.Success)
            //{
            admin.SqlBulk_Upload_Product("ITEM_PRODUCT_DETAILS", dt_ITEM, Session["currentcomp_db"].ToString());
            //}
            //else
            //{
            //    Alert_msg("No data found.");
            //}

        }

        dt_ITEM.TableName = "ITEM_PRODUCT_DETAILS";
        data.Tables.Add(dt_ITEM);
        return dt_ITEM;
    }
    public DataTable Read_Item_Details(DataTable Item_Data)
    {

        #region Item_Data

        string[] columns = new string[]
        {
            "ITEM_ID", "JOBNO", 
            "INVOICE_SLNO", "INVOICE_NO", "ITEM_SLNO", "ITEM_DESCRIPTION", "ITEM_QTY", "ITEM_QTY_CODE", "ITEM_UNIT_PRICE", "ITEM_UNIT_CODE","ITEM_TOTAL_AMOUNT", "CTH_QTY1", "CTH_QTY1_CODE", "CTH_QTY2", "CTH_QTY2_CODE", 
            "GENEARL_DESCRIPTION", "MANUFACTURER", "BRAND", "MODEL", "END_USE_OF_ITEM", "COUNTRY_OF_ORIGIN", "ACCESSORIES", "PREVIOUS_BE_NO", "PREVIOUS_BE_DATE", "UNIT_PRICE", "UNIT_CODE", "CUSTOMS_HOUSE", 
            "SCHEME_CODE", "SCHEME_NOTN", "SCHEME_NOTN_SLNO", "CTH_NO","PRODUCT_CTH","PRODUCT_RITC","PRODUCT_CETH", "PRODUCT_BCD_NOTN", "PRODUCT_BCD_SLNO", "PRODUCT_EDU_CESS_NOTN", "PRODUCT_EDU_CESS_NOTN_SL", "PRODUCT_SEC_EDU_CESS_NOTN", 
            "PRODUCT_SEC_EDU_CESS_NOTN_SL", "SOCIAL_WELFARE_NOTN", "SOCIAL_WELFARE_NOTN_SLNO", "PRODUCT_NCD_SLNO", "PRODUCT_NCD_NOTN", "PRODUCT_AGGREGATE_DUTY_NOTN", "PRODUCT_AGGREGATE_DUTY_NOTN_SL", 
            "PRODUCT_SAFEGUARD_NOTN", "PRODUCT_SAFEGUARD_SLNO", "PRODUCT_SAPTA_SLNO", "PRODUCT_SAPTA_NOTN", "PRODUCT_TARIFF_NOTN", "PRODUCT_TARIFF_SLNO", "PRODUCT_TARIFF_QTY", "PRODUCT_TARIFF_AMOUNT", 
            "PRODUCT_TARIFF_AMOUNT_UNIT", "AIDC_NOTN", "AIDC_NOTN_SLNO", "PRODUCT_CVD_NOTN", "PRODUCT_CVD_SLNO", "PRODUCT_ADDL_GSI_NOTN", "PRODUCT_ADDL_GSI_SLNO", "PRODUCT_ADDL_SHEII_NOTN", "PRODUCT_ADDL_SHEII_SLNO",
            "PRODUCT_ADDL_TTA_NOTN", "PRODUCT_ADDL_TTA_SLNO", "PRODUCT_ADDL_HEALTH_CESS_NOTN", "PRODUCT_ADDL_HEALTH_CESS_SLNO", "PRODUCT_CESS_NOTN", "PRODUCT_CESS_SLNO", "PRODUCT_OTHER_DUTY_NOTN", 
            "PRODUCT_OTHER_DUTY_SLNO", "INFRA_CESS_NOTN", "INFRA_CESS_NOTN_SL", "PRODUCT_MRP_SL_NO", "RSP_NOTN_NO", "RSP_NOTN_SL_NO", "IGST_LEVY_NOTN", "IGST_LEVY_SLNO", "IGST_LEVY_EXCEPTION_NOTN", 
            "IGST_LEVY_EXCEPTION_SLNO", "LEVY_EXCEMPTION_NOTN_TYPE", "IGST_LEVY_COMPENSATION_CESS_NOTN", "IGST_LEVY_COMPENSATION_CESS_SLNO", "IGST_LEVY_EXCEPTION_CC_NOTN", "IGST_LEVY_EXCEPTION_CC_SLNO", 
            "LEVY_EXCEPTION_CC_NOTN_TYPE", "ANTI_DUMPING_NOTN", "ANTI_DUMPING_NOTN_SLNO", "CTH_SLNO", "CTH_SUPPLIER_SLNO", "CTH_QTY", "ADD_EX_RATE", "CENTRAL_EXCISE_FLAG", "MANUFACTURER_PRODUCER", "M_P_GROWER_CODE", 
            "M_P_GROWER_ADD1", "M_P_GROWER_ADD2", "M_P_GROWER_CITY", "M_P_GROWER_COUNTRY_SUBDIV", "M_P_GROWER_PIN", "M_P_GROWER_COUNTRY", "SOURCE_COUNTRY", "TRANSIT_COUNTRY", "ACCESSORY_STATUS", "SVB_REF_NO","SVB_RELATION", 
            "SVB_REF_DATE", "SVB_CUSTOM_HOUSE", "SVB_LOADING_ON", "SVB_ASSESABLE_RATE", "SVB_DUTY_RATE", "SVB_ASSESABLE_STATUS", "SVB_DUTY_STATUS",
            "USER_ID", "DATE_TIME", "STATUS", "BRANCH_CODE","YEAR", "WORKING_PERIOD", "MODIFIEDBY", "MODIFIEDON",
            //added on 16-06-2026 by George Bush
            "PRODUCT_BCD_RATE", "PRODUCT_BCD_SPL", "PRODUCT_BCD_UNIT", "PRODUCT_BCD_SPL_TYPE", "PRODUCT_ADDL_DUTY_NOTN", "PRODUCT_ADDL_DUTY_NOTN_SL", "PRODUCT_ADDL_DUTY_RATE", 
            "PRODUCT_EDU_CESS_RATE", "PRODUCT_SEC_EDU_CESS_RATE", "PRODUCT_NCD_RATE", "PRODUCT_NCD_SPL", "PRODUCT_NCD_UNIT", "PRODUCT_NCD_SPL_TYPE", 
            "PRODUCT_AGGREGATE_DUTY_NOTN_RATE", "PRODUCT_SAFEGUARD_RATE", "PRODUCT_SAFEGUARD_SPL", "PRODUCT_SAFEGUARD_UNIT", "PRODUCT_SAFEGUARD_SPL_TYPE", 
            "PRODUCT_SAPTA_RATE", "PRODUCT_MRP_YN", "PRODUCT_MRP_AMOUNT", "PRODUCT_MRP_ABT_RATE", "PRODUCT_CVD_RATE", "PRODUCT_CVD_SPL", "PRODUCT_CVD_UNIT", 
            "PRODUCT_CVD_SPL_TYPE", "PRODUCT_CVD_EDU_CESS_RATE", "PRODUCT_CVD_SEC_EDU_CESS_RATE", "PRODUCT_ADDL5_SIA_NOTN", "PRODUCT_ADDL5_SIA_NOTN_SL", "PRODUCT_ADDL5_SIA_RATE", 
             "PRODUCT_ADDL_GSI_RATE", "PRODUCT_ADDL_GSI_SPL", "PRODUCT_ADDL_GSI_UNIT", "PRODUCT_ADDL_GSI_SPL_TYPE", 
            "PRODUCT_ADDL_SHEII_RATE", "PRODUCT_ADDL_SHEII_SPL", "PRODUCT_ADDL_SHEII_UNIT", "PRODUCT_ADDL_SHEII_TYPE",   
            "PRODUCT_ADDL_TTA_RATE", "PRODUCT_ADDL_TTA_SPL", "PRODUCT_ADDL_TTA_UNIT", "PRODUCT_ADDL_TTA_TYPE", "PRODUCT_ADDL_HEALTH_CESS_RATE", "PRODUCT_ADDL_HEALTH_CESS_SPL", 
            "PRODUCT_ADDL_HEALTH_CESS_UNIT", "PRODUCT_ADDL_HEALTH_CESS_TYPE", "PRODUCT_CESS_RATE", "PRODUCT_CESS_SPL", "PRODUCT_CESS_UNIT", "PRODUCT_CESS_TYPE", "WAREHOUSE_JOBNO", 
            "WAREHOUSE_INVOICE_SLNO", "WAREHOUSE_ITEM_SLNO", "ASSESSABLE_VALUE", "DUTY_VALUE", "CIF_VALUE", "CVD_VALUE", "BASIC_VALUE", "CEC_VALUE", "CHEC_VALUE", 
            "ADD_DUTY_VALUE", "CETH_CVD_EDU_CESS_SL", "CETH_CVD_EDU_CESS_RATE", "CETH_CVD_SEC_EDU_CESS_SL", "CETH_CVD_SEC_EDU_CESS_RATE", "PRODUCT_OTHER_DUTY_RATE", 
            "PRODUCT_OTHER_DUTY_SPL", "PRODUCT_OTHER_DUTY_UNIT", "PRODUCT_OTHER_DUTY_TYPE", "INDIVITUAL_FREIGHT_AMOUNT", "INDIVITUAL_INSURANCE_AMOUNT", "INDIVITUAL_MISC_AMOUNT",             
            "INDIVITUAL_EDU_CESS_AMT", "INDIVITUAL_SEC_HIGHER_CESS_AMT", "INDIVITUAL_LANDING_CHARGE", "CHECKLIST_BCD_RATE", "CHECKLIST_CVD_RATE", "CHECKLIST_ADDL_DUTY_RATE", 
            "INDEV_RACK_TYPE", "MERIT_DUTY_VALUE", "RSP_APPLICABLE",   "INFRA_CESS_NOTN_RATE", 
            "MERIT_BASIC_VALUE", "MERIT_CVD_VALUE", "MERIT_CEC_VALUE", "MERIT_CHEC_VALUE", "MERIT_ADD_DUTY_VALUE", "MERIT_NOTN_BASIC_VALUE", "MERIT_NOTN_CVD_VALUE", 
            "MERIT_NOTN_CEC_VALUE", "MERIT_NOTN_CHEC_VALUE", "MERIT_NOTN_ADD_DUTY_VALUE", "MERIT_NOTN_CESS_VALUE", "MERIT_NOTN_NCD_VALUE", "INDIVITUAL_HSS_AMOUNT", 
            "IGST_LEVY_RATE", "IGST_LEVY_SPL", "IGST_LEVY_UNIT", "IGST_LEVY_SPL_TYPE", "IGST_LEVY_EXCEPTION_RATE", "IGST_LEVY_COMPENSATION_CESS_RATE", 
            "IGST_LEVY_COMPENSATION_CESS_SPL", "IGST_LEVY_COMPENSATION_CESS_UNIT", "IGST_LEVY_COMPENSATION_CESS_SPL_TYPE", "IGST_LEVY_EXCEPTION_CC_RATE", 
            "CHECKLIST_IGST_LEVY_AMOUNT", "CHECKLIST_COMPENSATION_CC_AMOUNT"
        };



        foreach (string col in columns)
            dt_ITEM.Columns.Add(col);
        
        #endregion


        DataTable dtInfoXml = new DataTable("swInfo");

        string[] InfoCol = new string[]
        {
            "JOBNO", "INVOICE_SLNO","ITEM_SLNO", "INFO_MSR", "INFO_UQC"
        };

        foreach (string col in InfoCol)
            dtInfoXml.Columns.Add(col);

        for (int i = 0; i <= Item_Data.Rows.Count - 1; i++)
        {
            #region            

            #region excel data

            DataRow dtRow = Item_Data.Rows[i];

            INVOICE_SLNO = GetString(dtRow, "INVOICE_SLNO");
            INVOICE_NO = GetString(dtRow, "INVOICE_NO");
            ITEM_SLNO = GetString(dtRow, "ITEM_SLNO");
            ITEM_DESCRIPTION = GetString(dtRow, "ITEM_DESCRIPTION");
            ITEM_QTY = GetString(dtRow, "ITEM_QTY");
            ITEM_QTY_CODE = GetString(dtRow, "ITEM_QTY_CODE");
            ITEM_UNIT_PRICE = GetString(dtRow, "ITEM_UNIT_PRICE");
            ITEM_UNIT_CODE = GetString(dtRow, "ITEM_UNIT_CODE");
            double TOTAL_AMOUNT = 0.00;
            if (ITEM_QTY != "" && ITEM_UNIT_PRICE != "")
            {
                TOTAL_AMOUNT = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE);
            }
            ITEM_TOTAL_AMOUNT = Convert.ToString(TOTAL_AMOUNT);

            CTH_QTY1 = GetString(dtRow, "CTH_QTY1"); 
            CTH_QTY1_CODE = GetString(dtRow, "CTH_QTY1_CODE");
            CTH_QTY2 = GetString(dtRow, "CTH_QTY2");
            CTH_QTY2_CODE = GetString(dtRow, "CTH_QTY2_CODE");
            GENEARL_DESCRIPTION = GetString(dtRow, "GENEARL_DESCRIPTION");
            MANUFACTURER = GetString(dtRow, "MANUFACTURER");
            BRAND = GetString(dtRow, "BRAND");
            MODEL = GetString(dtRow, "MODEL");
            END_USE_OF_ITEM = GetString(dtRow, "END_USE_OF_ITEM");
            COUNTRY_OF_ORIGIN = GetString(dtRow, "COUNTRY_OF_ORIGIN");
            ACCESSORIES = GetString(dtRow, "ACCESSORIES");
            PREVIOUS_BE_NO = GetString(dtRow, "PREVIOUS_BE_NO");
            string prevBeDateText = GetString(dtRow, "PREVIOUS_BE_DATE");
            PREVIOUS_BE_DATE = string.IsNullOrEmpty(prevBeDateText) ? "01/01/1900" : prevBeDateText;
            UNIT_PRICE = GetString(dtRow, "UNIT_PRICE");
            UNIT_CODE = GetString(dtRow, "UNIT_CODE");
            CUSTOMS_HOUSE = GetString(dtRow, "CUSTOMS_HOUSE");            
            SCHEME_CODE = GetString(dtRow, "SCHEME_CODE");
            SCHEME_NOTN = GetString(dtRow, "SCHEME_NOTN");
            SCHEME_NOTN_SLNO = GetString(dtRow, "SCHEME_NOTN_SLNO");
            CTH_NO = GetString(dtRow, "CTH_NO");
            PRODUCT_CTH = GetString(dtRow, "CTH_NO");
            PRODUCT_RITC = GetString(dtRow, "PRODUCT_RITC");//RITC_NO
            PRODUCT_CETH = GetString(dtRow, "PRODUCT_CETH");//CETH_NO
            PRODUCT_BCD_NOTN = GetString(dtRow, "PRODUCT_BCD_NOTN");//BASIC_DUTY_NOTIFICATION
            PRODUCT_BCD_SLNO = GetString(dtRow, "PRODUCT_BCD_SLNO");//BASIC_DUTY_SLNO
            PRODUCT_EDU_CESS_NOTN = GetString(dtRow, "PRODUCT_EDU_CESS_NOTN");
            PRODUCT_EDU_CESS_NOTN_SL = GetString(dtRow, "PRODUCT_EDU_CESS_NOTN_SL");
            PRODUCT_SEC_EDU_CESS_NOTN = GetString(dtRow, "PRODUCT_SEC_EDU_CESS_NOTN");//
            PRODUCT_SEC_EDU_CESS_NOTN_SL = GetString(dtRow, "PRODUCT_SEC_EDU_CESS_NOTN_SL");
            SOCIAL_WELFARE_NOTN = GetString(dtRow, "SOCIAL_WELFARE_NOTN");
            SOCIAL_WELFARE_NOTN_SLNO = GetString(dtRow, "SOCIAL_WELFARE_NOTN_SLNO");
            PRODUCT_NCD_SLNO = GetString(dtRow, "PRODUCT_NCD_SLNO");
            PRODUCT_NCD_NOTN = GetString(dtRow, "PRODUCT_NCD_NOTN");            
            PRODUCT_AGGREGATE_DUTY_NOTN = GetString(dtRow, "PRODUCT_AGGREGATE_DUTY_NOTN");
            PRODUCT_AGGREGATE_DUTY_NOTN_SL = GetString(dtRow, "PRODUCT_AGGREGATE_DUTY_NOTN_SL");
            PRODUCT_SAFEGUARD_NOTN = GetString(dtRow, "PRODUCT_SAFEGUARD_NOTN");
            PRODUCT_SAFEGUARD_SLNO = GetString(dtRow, "PRODUCT_SAFEGUARD_SLNO");
            PRODUCT_SAPTA_SLNO = GetString(dtRow, "PRODUCT_SAPTA_SLNO");
            PRODUCT_SAPTA_NOTN = GetString(dtRow, "PRODUCT_SAPTA_NOTN");
            PRODUCT_TARIFF_NOTN = GetString(dtRow, "PRODUCT_TARIFF_NOTN");
            PRODUCT_TARIFF_SLNO = GetString(dtRow, "PRODUCT_TARIFF_SLNO");
            PRODUCT_TARIFF_QTY = GetString(dtRow, "PRODUCT_TARIFF_QTY");
            PRODUCT_TARIFF_AMOUNT = GetString(dtRow, "PRODUCT_TARIFF_AMOUNT");
            PRODUCT_TARIFF_AMOUNT_UNIT = GetString(dtRow, "PRODUCT_TARIFF_AMOUNT_UNIT");
            //PRODUCT_CETH = GetString(dtRow, "PRODUCT_CETH");
            AIDC_NOTN = GetString(dtRow, "AIDC_NOTN");
            AIDC_NOTN_SLNO = GetString(dtRow, "AIDC_NOTN_SLNO");
            
            PRODUCT_CVD_NOTN = GetString(dtRow, "PRODUCT_CVD_NOTN");
            PRODUCT_CVD_SLNO = GetString(dtRow, "PRODUCT_CVD_SLNO");
            PRODUCT_ADDL_GSI_NOTN = GetString(dtRow, "PRODUCT_ADDL_GSI_NOTN");//ADD_DUTY_OF_EXCISE_SIA_NOTN
            PRODUCT_ADDL_GSI_SLNO = GetString(dtRow, "PRODUCT_ADDL_GSI_SLNO");//ADD_DUTY_OF_EXCISE_SIA_SLNO
            PRODUCT_ADDL_SHEII_NOTN = GetString(dtRow, "PRODUCT_ADDL_SHEII_NOTN");//SPL_EX_DUTY_SHED11_NOTN
            PRODUCT_ADDL_SHEII_SLNO = GetString(dtRow, "PRODUCT_ADDL_SHEII_SLNO");//SPL_EX_DUTY_SHED11_SLNO
            PRODUCT_ADDL_TTA_NOTN = GetString(dtRow, "PRODUCT_ADDL_TTA_NOTN");//ADD_DUTY_OF_EXCISE_TTA_NOTN
            PRODUCT_ADDL_TTA_SLNO = GetString(dtRow, "PRODUCT_ADDL_TTA_SLNO");//ADD_DUTY_OF_EXCISE_TTA_SLNO
            PRODUCT_ADDL_HEALTH_CESS_NOTN = GetString(dtRow, "PRODUCT_ADDL_HEALTH_CESS_NOTN");//HEALTH_CESS_NOTN
            PRODUCT_ADDL_HEALTH_CESS_SLNO = GetString(dtRow, "PRODUCT_ADDL_HEALTH_CESS_SLNO");//HEALTH_CESS_SLNO
            PRODUCT_CESS_NOTN = GetString(dtRow, "PRODUCT_CESS_NOTN");
            PRODUCT_CESS_SLNO = GetString(dtRow, "PRODUCT_CESS_SLNO");
            PRODUCT_OTHER_DUTY_NOTN = GetString(dtRow, "PRODUCT_OTHER_DUTY_NOTN");
            PRODUCT_OTHER_DUTY_SLNO = GetString(dtRow, "PRODUCT_OTHER_DUTY_SLNO");
            INFRA_CESS_NOTN = GetString(dtRow, "INFRA_CESS_NOTN");//
            INFRA_CESS_NOTN_SL = GetString(dtRow, "INFRA_CESS_NOTN_SL");//
            PRODUCT_MRP_SL_NO = GetString(dtRow, "PRODUCT_MRP_SL_NO");//
            RSP_NOTN_NO = GetString(dtRow, "RSP_NOTN_NO");//
            RSP_NOTN_SL_NO = GetString(dtRow, "RSP_NOTN_SL_NO");//

            IGST_LEVY_NOTN = GetString(dtRow, "IGST_LEVY_NOTN");
            IGST_LEVY_SLNO = GetString(dtRow, "IGST_LEVY_SLNO");
            IGST_LEVY_EXCEPTION_NOTN = GetString(dtRow, "IGST_LEVY_EXCEPTION_NOTN");//EXCEPTION_NOTN
            IGST_LEVY_EXCEPTION_SLNO = GetString(dtRow, "IGST_LEVY_EXCEPTION_SLNO");//EXCEPTION_SLNO
            LEVY_EXCEMPTION_NOTN_TYPE = GetString(dtRow, "LEVY_EXCEMPTION_NOTN_TYPE");//EXCEMPTION_NOTN_TYPE
            IGST_LEVY_COMPENSATION_CESS_NOTN = GetString(dtRow, "IGST_LEVY_COMPENSATION_CESS_NOTN");//COMPENSATION_CESS_NOTN
            IGST_LEVY_COMPENSATION_CESS_SLNO = GetString(dtRow, "IGST_LEVY_COMPENSATION_CESS_SLNO");//COMPENSATION_CESS_SLNO
            IGST_LEVY_EXCEPTION_CC_NOTN = GetString(dtRow, "IGST_LEVY_EXCEPTION_CC_NOTN");//EXCEPTION_CC_NOTN
            IGST_LEVY_EXCEPTION_CC_SLNO = GetString(dtRow, "IGST_LEVY_EXCEPTION_CC_SLNO");//EXCEPTION_CC_SLNO
            LEVY_EXCEPTION_CC_NOTN_TYPE = GetString(dtRow, "LEVY_EXCEPTION_CC_NOTN_TYPE");//EXCEPTION_CC_NOTN_TYPE

            ANTI_DUMPING_NOTN = GetString(dtRow, "ANTI_DUMPING_NOTN");//
            ANTI_DUMPING_NOTN_SLNO = GetString(dtRow, "ANTI_DUMPING_NOTN_SLNO");//
            CTH_SLNO = GetString(dtRow, "CTH_SLNO");
            CTH_SUPPLIER_SLNO = GetString(dtRow, "CTH_SUPPLIER_SLNO");
            CTH_QTY = GetString(dtRow, "CTH_QTY");
            ADD_EX_RATE = GetString(dtRow, "ADD_EX_RATE");//
            CENTRAL_EXCISE_FLAG = GetString(dtRow, "CENTRAL_EXCISE_FLAG");
            MANUFACTURER_PRODUCER = GetString(dtRow, "MANUFACTURER_PRODUCER");//
            M_P_GROWER_CODE = GetString(dtRow, "M_P_GROWER_CODE");//
            M_P_GROWER_ADD1 = GetString(dtRow, "M_P_GROWER_ADD1");
            M_P_GROWER_ADD2 = GetString(dtRow, "M_P_GROWER_ADD2");
            M_P_GROWER_CITY = GetString(dtRow, "M_P_GROWER_CITY");
            M_P_GROWER_COUNTRY_SUBDIV = GetString(dtRow, "M_P_GROWER_COUNTRY_SUBDIV");
            M_P_GROWER_PIN = GetString(dtRow, "M_P_GROWER_PIN");
            M_P_GROWER_COUNTRY = GetString(dtRow, "M_P_GROWER_COUNTRY");
            SOURCE_COUNTRY = GetString(dtRow, "SOURCE_COUNTRY");
            TRANSIT_COUNTRY = GetString(dtRow, "TRANSIT_COUNTRY");
            ACCESSORY_STATUS = GetString(dtRow, "ACCESSORY_STATUS");

            #region 

            if (TYPE != "")
            {
                if (TYPE.Contains('-'))
                {
                    string[] p = TYPE.Split('-');
                    string p1 = p[0];
                    string p2 = p[1];

                    TYPE = p1.Trim();
                }
            }

            #endregion

            ISVB_REF_NO = GetString(dtRow, "SVB_REF_NO");
            ISVB_RELATION = !string.IsNullOrEmpty(ISVB_REF_NO) ? "True" : "False";
            string svbRefDateText = GetString(dtRow, "SVB_REF_DATE");
            ISVB_REF_DATE = string.IsNullOrEmpty(svbRefDateText) ? "01/01/1900" : svbRefDateText;
            ISVB_CUSTOM_HOUSE = GetString(dtRow, "SVB_CUSTOM_HOUSE");
            ISVB_LOADING_ON = GetString(dtRow, "SVB_LOADING_ON");
            ListItem matchedLoadingOn = GetMatchedItem(ISVB_LOADING_ON, itemSVBList);
            ISVB_LOADING_ON = matchedLoadingOn != null ? matchedLoadingOn.Text : ISVB_LOADING_ON;
            ISVB_ASSESABLE_RATE = GetString(dtRow, "SVB_ASSESABLE_RATE");
            ISVB_DUTY_RATE = GetString(dtRow, "SVB_DUTY_RATE");
            ISVB_ASSESABLE_STATUS = GetString(dtRow, "SVB_ASSESABLE_STATUS");
            ISVB_DUTY_STATUS = GetString(dtRow, "SVB_DUTY_STATUS");
            IINFO_MSR = GetString(dtRow, "INFO_MSR");
            IINFO_UQC = GetString(dtRow, "INFO_UQC");
            #endregion

            #region default value without getting from excel

            PRODUCT_BCD_RATE = "0"; PRODUCT_BCD_SPL = ""; PRODUCT_BCD_UNIT = ""; PRODUCT_BCD_SPL_TYPE = ""; PRODUCT_ADDL_DUTY_NOTN = ""; PRODUCT_ADDL_DUTY_NOTN_SL = "";
            PRODUCT_ADDL_DUTY_RATE = "0"; PRODUCT_EDU_CESS_RATE = "0"; PRODUCT_SEC_EDU_CESS_RATE = "0"; PRODUCT_NCD_RATE = "0"; PRODUCT_NCD_SPL = ""; PRODUCT_NCD_UNIT = "";
            PRODUCT_NCD_SPL_TYPE = ""; PRODUCT_AGGREGATE_DUTY_NOTN_RATE = "0"; PRODUCT_SAFEGUARD_RATE = "0"; PRODUCT_SAFEGUARD_SPL = ""; PRODUCT_SAFEGUARD_UNIT = "";
            PRODUCT_SAFEGUARD_SPL_TYPE = ""; PRODUCT_SAPTA_RATE = "0"; PRODUCT_MRP_YN = "";  PRODUCT_MRP_AMOUNT = ""; PRODUCT_MRP_ABT_RATE = "";
            PRODUCT_CVD_RATE = "0"; PRODUCT_CVD_SPL = ""; PRODUCT_CVD_UNIT = ""; PRODUCT_CVD_SPL_TYPE = ""; PRODUCT_CVD_EDU_CESS_RATE = "0"; PRODUCT_CVD_SEC_EDU_CESS_RATE = "0";
            PRODUCT_ADDL5_SIA_NOTN = ""; PRODUCT_ADDL5_SIA_NOTN_SL = ""; PRODUCT_ADDL5_SIA_RATE = "0"; 
            PRODUCT_ADDL_GSI_RATE = "0"; PRODUCT_ADDL_GSI_SPL = ""; PRODUCT_ADDL_GSI_UNIT = ""; PRODUCT_ADDL_GSI_SPL_TYPE = ""; PRODUCT_ADDL_SHEII_RATE = "0";
            PRODUCT_ADDL_SHEII_SPL = ""; PRODUCT_ADDL_SHEII_UNIT = ""; PRODUCT_ADDL_SHEII_TYPE = ""; 
            PRODUCT_ADDL_TTA_RATE = "0"; PRODUCT_ADDL_TTA_SPL = ""; PRODUCT_ADDL_TTA_UNIT = ""; PRODUCT_ADDL_TTA_TYPE = ""; PRODUCT_ADDL_HEALTH_CESS_RATE = "0";
            PRODUCT_ADDL_HEALTH_CESS_SPL = ""; PRODUCT_ADDL_HEALTH_CESS_UNIT = ""; PRODUCT_ADDL_HEALTH_CESS_TYPE = ""; PRODUCT_CESS_RATE = "0"; PRODUCT_CESS_SPL = "";
            PRODUCT_CESS_UNIT = ""; PRODUCT_CESS_TYPE = ""; WAREHOUSE_JOBNO = "0"; WAREHOUSE_INVOICE_SLNO = "0"; WAREHOUSE_ITEM_SLNO = "0"; ASSESSABLE_VALUE = "";
            DUTY_VALUE = ""; CIF_VALUE = ""; CVD_VALUE = ""; BASIC_VALUE = ""; CEC_VALUE = ""; CHEC_VALUE = ""; ADD_DUTY_VALUE = ""; CETH_CVD_EDU_CESS_SL = "";
            CETH_CVD_EDU_CESS_RATE = "0.00"; CETH_CVD_SEC_EDU_CESS_SL = ""; CETH_CVD_SEC_EDU_CESS_RATE = "0"; PRODUCT_OTHER_DUTY_RATE = "0"; PRODUCT_OTHER_DUTY_SPL = "";
            PRODUCT_OTHER_DUTY_UNIT = ""; PRODUCT_OTHER_DUTY_TYPE = ""; INDIVITUAL_FREIGHT_AMOUNT = "0"; INDIVITUAL_INSURANCE_AMOUNT = "0"; INDIVITUAL_MISC_AMOUNT = "0"; //SVB_RELATION = "";
            INDIVITUAL_EDU_CESS_AMT = "0"; INDIVITUAL_SEC_HIGHER_CESS_AMT = "0"; INDIVITUAL_LANDING_CHARGE = "0";
            CHECKLIST_BCD_RATE = "0"; CHECKLIST_CVD_RATE = "0"; CHECKLIST_ADDL_DUTY_RATE = "0"; INDEV_RACK_TYPE = ""; MERIT_DUTY_VALUE = ""; RSP_APPLICABLE = "N";
             INFRA_CESS_NOTN_RATE = ""; MERIT_BASIC_VALUE = "";
            MERIT_CVD_VALUE = ""; MERIT_CEC_VALUE = ""; MERIT_CHEC_VALUE = ""; MERIT_ADD_DUTY_VALUE = ""; MERIT_NOTN_BASIC_VALUE = ""; MERIT_NOTN_CVD_VALUE = "";
            MERIT_NOTN_CEC_VALUE = ""; MERIT_NOTN_CHEC_VALUE = ""; MERIT_NOTN_ADD_DUTY_VALUE = ""; MERIT_NOTN_CESS_VALUE = ""; MERIT_NOTN_NCD_VALUE = "";
            INDIVITUAL_HSS_AMOUNT = "0"; IGST_LEVY_RATE = "0"; IGST_LEVY_SPL = ""; IGST_LEVY_UNIT = ""; IGST_LEVY_SPL_TYPE = ""; IGST_LEVY_EXCEPTION_RATE = "0";
            IGST_LEVY_COMPENSATION_CESS_RATE = "0"; IGST_LEVY_COMPENSATION_CESS_SPL = ""; IGST_LEVY_COMPENSATION_CESS_UNIT = ""; IGST_LEVY_COMPENSATION_CESS_SPL_TYPE = "";
            IGST_LEVY_EXCEPTION_CC_RATE = "0"; CHECKLIST_IGST_LEVY_AMOUNT = "0"; CHECKLIST_COMPENSATION_CC_AMOUNT = "0";
            /* PRODUCT_ADDL_GSI_NOTN = ""; PRODUCT_ADDL_GSI_SLNO = "";PRODUCT_ADDL_TTA_NOTN = ""; PRODUCT_ADDL_TTA_SLNO = "";INFRA_CESS_NOTN = ""; INFRA_CESS_NOTN_SL = ""; PRODUCT_MRP_SL_NO = "";MANUFACTURER_PRODUCER = ""; M_P_GROWER_CODE = "";*/

            #endregion            

            MAX_ID = Get_general_MAXID("ITEM_MAX_ID");            

            dt_ITEM.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, INVOICE_NO, ITEM_SLNO, ITEM_DESCRIPTION, ITEM_QTY, ITEM_QTY_CODE, ITEM_UNIT_PRICE, ITEM_UNIT_CODE, ITEM_TOTAL_AMOUNT, CTH_QTY1, CTH_QTY1_CODE, CTH_QTY2,
                            CTH_QTY2_CODE, GENEARL_DESCRIPTION, MANUFACTURER, BRAND, MODEL, END_USE_OF_ITEM, COUNTRY_OF_ORIGIN, ACCESSORIES, PREVIOUS_BE_NO, PREVIOUS_BE_DATE, UNIT_PRICE, UNIT_CODE, CUSTOMS_HOUSE,
                            SCHEME_CODE, SCHEME_NOTN, SCHEME_NOTN_SLNO, CTH_NO, PRODUCT_CTH, PRODUCT_RITC, PRODUCT_CETH, PRODUCT_BCD_NOTN, PRODUCT_BCD_SLNO, PRODUCT_EDU_CESS_NOTN, PRODUCT_EDU_CESS_NOTN_SL, PRODUCT_SEC_EDU_CESS_NOTN, PRODUCT_SEC_EDU_CESS_NOTN_SL,
                            SOCIAL_WELFARE_NOTN, SOCIAL_WELFARE_NOTN_SLNO, PRODUCT_NCD_SLNO, PRODUCT_NCD_NOTN, PRODUCT_AGGREGATE_DUTY_NOTN, PRODUCT_AGGREGATE_DUTY_NOTN_SL, PRODUCT_SAFEGUARD_NOTN, PRODUCT_SAFEGUARD_SLNO,
                            PRODUCT_SAPTA_SLNO, PRODUCT_SAPTA_NOTN, PRODUCT_TARIFF_NOTN, PRODUCT_TARIFF_SLNO, PRODUCT_TARIFF_QTY, PRODUCT_TARIFF_AMOUNT, PRODUCT_TARIFF_AMOUNT_UNIT, AIDC_NOTN, AIDC_NOTN_SLNO, PRODUCT_CVD_NOTN,
                            PRODUCT_CVD_SLNO, PRODUCT_ADDL_GSI_NOTN, PRODUCT_ADDL_GSI_SLNO, PRODUCT_ADDL_SHEII_NOTN, PRODUCT_ADDL_SHEII_SLNO, PRODUCT_ADDL_TTA_NOTN, PRODUCT_ADDL_TTA_SLNO, PRODUCT_ADDL_HEALTH_CESS_NOTN,
                            PRODUCT_ADDL_HEALTH_CESS_SLNO, PRODUCT_CESS_NOTN, PRODUCT_CESS_SLNO, PRODUCT_OTHER_DUTY_NOTN, PRODUCT_OTHER_DUTY_SLNO, INFRA_CESS_NOTN, INFRA_CESS_NOTN_SL, PRODUCT_MRP_SL_NO, RSP_NOTN_NO,
                            RSP_NOTN_SL_NO, IGST_LEVY_NOTN, IGST_LEVY_SLNO, IGST_LEVY_EXCEPTION_NOTN, IGST_LEVY_EXCEPTION_SLNO, LEVY_EXCEMPTION_NOTN_TYPE, IGST_LEVY_COMPENSATION_CESS_NOTN, IGST_LEVY_COMPENSATION_CESS_SLNO,
                            IGST_LEVY_EXCEPTION_CC_NOTN, IGST_LEVY_EXCEPTION_CC_SLNO, LEVY_EXCEPTION_CC_NOTN_TYPE, ANTI_DUMPING_NOTN, ANTI_DUMPING_NOTN_SLNO, CTH_SLNO, CTH_SUPPLIER_SLNO, CTH_QTY, ADD_EX_RATE, CENTRAL_EXCISE_FLAG,
                            MANUFACTURER_PRODUCER, M_P_GROWER_CODE, M_P_GROWER_ADD1, M_P_GROWER_ADD2, M_P_GROWER_CITY, M_P_GROWER_COUNTRY_SUBDIV, M_P_GROWER_PIN, M_P_GROWER_COUNTRY, SOURCE_COUNTRY, TRANSIT_COUNTRY, ACCESSORY_STATUS,
                            ISVB_REF_NO, ISVB_RELATION, ISVB_REF_DATE, ISVB_CUSTOM_HOUSE, ISVB_LOADING_ON, ISVB_ASSESABLE_RATE, ISVB_DUTY_RATE, ISVB_ASSESABLE_STATUS, ISVB_DUTY_STATUS,
                            currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate,
                                            //Added on 16-06-2026
                            PRODUCT_BCD_RATE, PRODUCT_BCD_SPL, PRODUCT_BCD_UNIT, PRODUCT_BCD_SPL_TYPE, PRODUCT_ADDL_DUTY_NOTN, PRODUCT_ADDL_DUTY_NOTN_SL, PRODUCT_ADDL_DUTY_RATE,
                            PRODUCT_EDU_CESS_RATE, PRODUCT_SEC_EDU_CESS_RATE, PRODUCT_NCD_RATE, PRODUCT_NCD_SPL, PRODUCT_NCD_UNIT, PRODUCT_NCD_SPL_TYPE, PRODUCT_AGGREGATE_DUTY_NOTN_RATE,
                            PRODUCT_SAFEGUARD_RATE, PRODUCT_SAFEGUARD_SPL, PRODUCT_SAFEGUARD_UNIT, PRODUCT_SAFEGUARD_SPL_TYPE, PRODUCT_SAPTA_RATE, PRODUCT_MRP_YN,
                            PRODUCT_MRP_AMOUNT, PRODUCT_MRP_ABT_RATE, PRODUCT_CVD_RATE, PRODUCT_CVD_SPL, PRODUCT_CVD_UNIT, PRODUCT_CVD_SPL_TYPE, PRODUCT_CVD_EDU_CESS_RATE,
                            PRODUCT_CVD_SEC_EDU_CESS_RATE, PRODUCT_ADDL5_SIA_NOTN, PRODUCT_ADDL5_SIA_NOTN_SL, PRODUCT_ADDL5_SIA_RATE,
                            PRODUCT_ADDL_GSI_RATE, PRODUCT_ADDL_GSI_SPL, PRODUCT_ADDL_GSI_UNIT, PRODUCT_ADDL_GSI_SPL_TYPE, PRODUCT_ADDL_SHEII_RATE, PRODUCT_ADDL_SHEII_SPL, PRODUCT_ADDL_SHEII_UNIT,
                            PRODUCT_ADDL_SHEII_TYPE, PRODUCT_ADDL_TTA_RATE, PRODUCT_ADDL_TTA_SPL, PRODUCT_ADDL_TTA_UNIT, PRODUCT_ADDL_TTA_TYPE,
                            PRODUCT_ADDL_HEALTH_CESS_RATE, PRODUCT_ADDL_HEALTH_CESS_SPL, PRODUCT_ADDL_HEALTH_CESS_UNIT, PRODUCT_ADDL_HEALTH_CESS_TYPE, PRODUCT_CESS_RATE, PRODUCT_CESS_SPL,
                            PRODUCT_CESS_UNIT, PRODUCT_CESS_TYPE, WAREHOUSE_JOBNO, WAREHOUSE_INVOICE_SLNO, WAREHOUSE_ITEM_SLNO, ASSESSABLE_VALUE, DUTY_VALUE, CIF_VALUE, CVD_VALUE, BASIC_VALUE,
                            CEC_VALUE, CHEC_VALUE, ADD_DUTY_VALUE, CETH_CVD_EDU_CESS_SL, CETH_CVD_EDU_CESS_RATE, CETH_CVD_SEC_EDU_CESS_SL, CETH_CVD_SEC_EDU_CESS_RATE, PRODUCT_OTHER_DUTY_RATE,
                            PRODUCT_OTHER_DUTY_SPL, PRODUCT_OTHER_DUTY_UNIT, PRODUCT_OTHER_DUTY_TYPE, INDIVITUAL_FREIGHT_AMOUNT, INDIVITUAL_INSURANCE_AMOUNT, INDIVITUAL_MISC_AMOUNT,
                            INDIVITUAL_EDU_CESS_AMT, INDIVITUAL_SEC_HIGHER_CESS_AMT, INDIVITUAL_LANDING_CHARGE, CHECKLIST_BCD_RATE, CHECKLIST_CVD_RATE, CHECKLIST_ADDL_DUTY_RATE, INDEV_RACK_TYPE, MERIT_DUTY_VALUE,
                            RSP_APPLICABLE, INFRA_CESS_NOTN_RATE, MERIT_BASIC_VALUE, MERIT_CVD_VALUE, MERIT_CEC_VALUE,
                            MERIT_CHEC_VALUE, MERIT_ADD_DUTY_VALUE, MERIT_NOTN_BASIC_VALUE, MERIT_NOTN_CVD_VALUE, MERIT_NOTN_CEC_VALUE, MERIT_NOTN_CHEC_VALUE, MERIT_NOTN_ADD_DUTY_VALUE,
                            MERIT_NOTN_CESS_VALUE, MERIT_NOTN_NCD_VALUE, INDIVITUAL_HSS_AMOUNT, IGST_LEVY_RATE, IGST_LEVY_SPL, IGST_LEVY_UNIT, IGST_LEVY_SPL_TYPE, IGST_LEVY_EXCEPTION_RATE,
                            IGST_LEVY_COMPENSATION_CESS_RATE, IGST_LEVY_COMPENSATION_CESS_SPL, IGST_LEVY_COMPENSATION_CESS_UNIT, IGST_LEVY_COMPENSATION_CESS_SPL_TYPE, IGST_LEVY_EXCEPTION_CC_RATE,
                            CHECKLIST_IGST_LEVY_AMOUNT, CHECKLIST_COMPENSATION_CC_AMOUNT);

            dtInfoXml.Rows.Add(IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, IINFO_MSR, IINFO_UQC);

            #endregion
        }

        if (dt_ITEM.Rows.Count > 0)
        {
            if (flag == "U")
            {
                GetAndDeleteJobData("ITEM_PRODUCT_DETAILS");
                //var result = DeleteJobDataByTable("ITEM_PRODUCT_DETAILS");
            }

            //if (!result.Success)
            //{
                SqlBulk_Upload_Product("ITEM_PRODUCT_DETAILS", dt_ITEM, Session["currentcomp_db"].ToString());

                
            #region Single Window

                var param = new[]
                 {   
                     new SqlParameter("@JOBNO", IMPORT_JOBNO),
                     new SqlParameter("@ITEM_XML", ConvertDataTableToXML(dtInfoXml)),
                     new SqlParameter("@USER_ID",  currentuser),
                     new SqlParameter("@BRANCHCODE", currentbranch),
                     new SqlParameter("@WORKING_PERIOD",  Working_Period),
                 
                     new SqlParameter("@MStatus",    SqlDbType.Int)    { Direction = ParameterDirection.Output },
                     new SqlParameter("@ErrorMsg",   SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output },             
                 };

                SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_POPULATE_SINGLE_WINDOW_AFTER_BULK", param);

                int result = Convert.ToInt32(param.First(p => p.ParameterName == "@MStatus").Value);
                string errorMsg = param.First(p => p.ParameterName == "@ErrorMsg").Value.ToString();

            #endregion

            //}
            //else
            //{
            //    Alert_msg("No data found.");
            //}
            
        }        

        dt_ITEM.TableName = "ITEM_PRODUCT_DETAILS";
        data.Tables.Add(dt_ITEM);
        return dt_ITEM;
    }

    public DataTable Read_Bond_Details(DataTable Bond_Data)
    {

        #region dt_BOND

        string[] bondColumns = new string[] { "BONDID","JOBNO","BOND_NO","BOND_TYPE","BOND_LOCATION", "USER_ID","DATE_TIME","STATUS","BRANCH_CODE","YEAR","WORKING_PERIOD",
            "MODIFIEDBY","MODIFIEDON"  };

        foreach (string col in bondColumns)
            dt_BOND.Columns.Add(col);

        #endregion

        for (int i = 0; i <= Bond_Data.Rows.Count - 1; i++)
        {
           
            DataRow bondRow = Bond_Data.Rows[i];
            BOND_NO = GetString(bondRow, "BOND_NO");
            BOND_TYPE = GetString(bondRow, "BOND_TYPE");
            BOND_LOCATION = GetString(bondRow, "BOND_LOCATION");

            MAX_ID = Get_general_MAXID("BOND_MAX_ID");            

            dt_BOND.Rows.Add(MAX_ID + i, IMPORT_JOBNO, BOND_NO, BOND_TYPE, BOND_LOCATION, currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);
        }

        dt_BOND.TableName = "BOND_DETAILS";
        data.Tables.Add(dt_BOND);
        return dt_BOND;
    }

    public DataTable Read_Certificate_Details(DataTable CERT_Data)
    {

        #region

        string[] certColumns = new string[] {"CERTIFICATEID","JOBNO","CERTIFICATE_NO","CERTIFICATE_DATE","CERTIFICATE_TYPE","USER_ID","DATE_TIME","STATUS","BRANCH_CODE",
                               "YEAR","WORKING_PERIOD","MODIFIEDBY","MODIFIEDON"  };


        foreach (string col in certColumns)
            dt_CERT.Columns.Add(col);

        #endregion

        for (int i = 0; i <= CERT_Data.Rows.Count - 1; i++)
        {
           
            DataRow certRow = CERT_Data.Rows[i];
            CERTIFICATE_NO = GetString(certRow, "CERTIFICATE_NO");
            CERTIFICATE_DATE = GetString(certRow, "CERTIFICATE_DATE");
            CERTIFICATE_DATE = string.IsNullOrEmpty(CERTIFICATE_DATE) ? "01/01/1900" : CERTIFICATE_DATE;
            CERTIFICATE_TYPE = GetString(certRow, "CERTIFICATE_TYPE");

            MAX_ID = Get_general_MAXID("CERTIFICATE_MAX_ID");
            Get_IGM_NO_DATE(IGM_SLNO);
            
            //IGM_DATE = string.IsNullOrEmpty(IGM_DATE) ? "01/01/1900" : IGM_DATE;

            dt_CERT.Rows.Add(MAX_ID + i, IMPORT_JOBNO, CERTIFICATE_NO, CERTIFICATE_DATE, CERTIFICATE_TYPE, currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);
        }

        dt_CERT.TableName = "CERTIFICATE_DETAILS";
        data.Tables.Add(dt_CERT);
        return dt_CERT;
    }

    public DataTable Read_License_Details(DataTable LIC_Data)
    {

        #region Validation

        DataSet Inv_ds = new DataSet();
        Inv_ds.Tables.Add(LIC_Data.Copy());
        ds = Inv_ds;
        
        DataView dv = Inv_ds.Tables[0].DefaultView;
        DataTable dat = dv.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO");

        Transact.xmlString = ConvertDataTableToXML(dat);
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.BRANCH_CODE = Connection.Current_Branch();
        Transact.Ename = "validate_invoice_item";

        DataSet dtxl = Transact.Import_Bulk_License_Select();        

        // SP returned mismatched Invoice/Item combinations
        if (dtxl != null && dtxl.Tables.Count > 0 && dtxl.Tables[0] != null && dtxl.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in dtxl.Tables[0].Rows)
            {
                AddError("LICENSE", "Invoice/Item combination does not exist for the selected Job.", "INVOICE_SLNO / ITEM_SLNO", "Invoice : " + dr["INVOICE_SLNO"] + ", Item : " + dr["ITEM_SLNO"]);
            }            
        }

        
        BuildValidationErrors(Inv_ds.Tables[0]);

        #endregion

        #region dt_LICNESE
        
        string[] licenseColumns = new string[] { "LICENSE_ID", "JOBNO", "INVOICE_SLNO", "ITEM_SLNO", "SCHEME_CODE", "LICENSE_SLNO", "REGISTRATION_NO", "REGISTRATION_DATE", "EXCEMPTION",
            "LIC_DESC","LICENSE_CURRENCY","EX_RATE","DEBIT_QTY", "UNIT_QTY", "LICENSE_ITEM_NO", "PORT_OF_LICENSE","LICENSE_NO", "LICENSE_DATE","DEBIT_AMT","DEBIT_DUTY","ENTRY_DEBIT_DUTY",
               "USER_ID", "DATE_TIME", "STATUS", "BRANCH_CODE", "YEAR", "WORKING_PERIOD","MODIFIEDBY", "MODIFIEDON"   };

        foreach (string col in licenseColumns)
            dt_LICNESE.Columns.Add(col);

        #endregion

        for (int i = 0; i <= LIC_Data.Rows.Count - 1; i++)
        {

            #region EXCEL

            DataRow dtRow = LIC_Data.Rows[i];

            INVOICE_SLNO = GetString(dtRow, "INVOICE_SLNO");
            ITEM_SLNO = GetString(dtRow, "ITEM_SLNO");
            EXCEMPTION = GetString(dtRow, "EXCEMPTION");
            LIC_DESC = GetString(dtRow, "LIC_DESC");
            CURRENCY = GetString(dtRow, "LICENSE_CURRENCY");
            EXRATE = GetString(dtRow, "EX_RATE");
            REGISTRATION_NO = GetString(dtRow, "REGISTRATION_NO");
            REGISTRATION_DATE = GetString(dtRow, "REGISTRATION_DATE");
            REGISTRATION_DATE = string.IsNullOrEmpty(REGISTRATION_DATE) ? "01/01/1900" : REGISTRATION_DATE;
            DEBIT_QTY = GetString(dtRow, "DEBIT_QTY");
            UNIT_QTY = GetString(dtRow, "UNIT_QTY");
            LICENSE_ITEM_NO = GetString(dtRow, "LICENSE_ITEM_NO");
            PORT_OF_LICENSE = GetString(dtRow, "PORT_OF_LICENSE");
            LICENSE_NO = GetString(dtRow, "LICENSE_NO");
            string licenseDate = GetString(dtRow, "LICENSE_DATE");
            LICENSE_DATE = string.IsNullOrEmpty(licenseDate) ? "01/01/1900" : licenseDate;
            DEBIT_AMT = GetString(dtRow, "DEBIT_AMT");
            DEBIT_DUTY = GetString(dtRow, "DEBIT_DUTY");

            ENTRY_DEBIT_DUTY = (string.IsNullOrWhiteSpace(DEBIT_DUTY) || DEBIT_DUTY == "0") ? "0.00" : DEBIT_DUTY;

            #endregion
            
            SCHEME_CODE = Session["SCHEME_CODE"] == null ? "" : Session["SCHEME_CODE"].ToString();
            LICENSE_SLNO = "0";
            TOTAL_DEBIT_DUTY = "";

            MAX_ID = Get_general_MAXID("LICENSE_MAX_ID");

            dt_LICNESE.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, SCHEME_CODE, LICENSE_SLNO, REGISTRATION_NO, REGISTRATION_DATE, EXCEMPTION,
                LIC_DESC, CURRENCY, EXRATE, DEBIT_QTY, UNIT_QTY, LICENSE_ITEM_NO, PORT_OF_LICENSE, LICENSE_NO, LICENSE_DATE, DEBIT_AMT, DEBIT_DUTY, ENTRY_DEBIT_DUTY,
                   currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);
        }

        #region Insert commented

        //if (allErrors == null || allErrors.Rows.Count == 0)
        //{
        //    if (dt_LICNESE.Rows.Count > 0)
        //    {
        //        Transact.JOBNO = IMPORT_JOBNO;
        //        Transact.INVOICE_SLNO = "";
        //        Transact.ITEM_SLNO = "";
        //        Transact.BRANCH_CODE = Connection.Current_Branch();
        //        Transact.Ename = "License_details_delete";

        //        ds = Transact.Import_Bulk_License_Select();

        //        //admin.SqlBulk_Upload_Product("LICENSE_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
        //        SqlBulk_Upload_Product("LICENSE_DETAILS", dt_LICNESE, Session["currentcomp_db"].ToString());
        //    }
        //}

        #endregion

        dt_LICNESE.TableName = "LICENSE_DETAILS";
        data.Tables.Add(dt_LICNESE);
        return dt_LICNESE;
    }

    public DataTable Read_Suporting_Documents_Details(DataTable SUP_DOC)
    {
        if (!supDocHasErrors) 
        {
            SupDoc_DATA_CHECK(textSupDoc);            
        }  

        #region dt_SUP_DOC

        string[] supDocColumns = new string[] { "SW_ID", "JOBNO", "INVOICE_SLNO", "ITEM_SLNO", "DECLARATION_TYPE", "IMAGE_REF_NUMBER", "DOC_TYPE_CODE", "DOC_ISSUING_PARTY_CODE", 
            "DOC_ISSUING_PARTY_NAME", "DOC_ISSUING_PARTY_NAME_ADD1", "DOC_ISSUING_PARTY_NAME_ADD2", "DOC_ISSUING_PARTY_CITY", "DOC_ISSUING_PARTY_PIN", "DOC_REF_NUMBER", 
            "PLACE_OF_ISSUE", "DOC_ISSUE_DATE", "DOC_EXPIRY_DATE", "BENEFICIARY_PARTY_CODE", "BENEFICIARY_PARTY_NAME", "BENEFICIARY_PARTY_ADDRESS1", "BENEFICIARY_PARTY_ADDRESS2", 
            "BENEFICIARY_PARTY_CITY", "BENEFICIARY_PARTY_PIN", "FILE_TYPE", "USER_ID", "DATE_TIME", "BRANCH_CODE", "WORKING_PERIOD", "CREATEDON", "CREATEDBY", "MODIFIEDBY", 
            "MODIFIEDON", "SELECT_TYPE", "ICEGATE_ID","ICEGATE_DOC_FILE_NAME" };

        foreach (string col in supDocColumns)
            dt_SUP_DOC.Columns.Add(col);

        #endregion

        for (int i = 0; i <= SUP_DOC.Rows.Count - 1; i++)
        {            

            #region Excel Data

            DataRow dtRow = SUP_DOC.Rows[i];

            INVOICE_SLNO = GetString(dtRow, "INVOICE_SLNO");
            ITEM_SLNO = GetString(dtRow, "ITEM_SLNO");
            DOC_TYPE = GetString(dtRow, "SELECT_TYPE");
            IMAGE_REF_NUMBER = GetString(dtRow, "IMAGE_REF_NUMBER");
            string cell = GetString(dtRow, "DOC_TYPE_CODE");
            DOC_TYPE_CODE = cell.Contains('-') ? cell.Split('-')[0] : cell;
            DOC_ISSUING_PARTY_CODE = GetString(dtRow, "DOC_ISSUING_PARTY_CODE");
            DOC_ISSUING_PARTY_NAME = GetString(dtRow, "DOC_ISSUING_PARTY_NAME");
            DOC_ISSUING_PARTY_NAME_ADD1 = GetString(dtRow, "DOC_ISSUING_PARTY_NAME_ADD1");
            DOC_ISSUING_PARTY_NAME_ADD2 = GetString(dtRow, "DOC_ISSUING_PARTY_NAME_ADD2");
            DOC_ISSUING_PARTY_CITY = GetString(dtRow, "DOC_ISSUING_PARTY_CITY");
            DOC_ISSUING_PARTY_PIN = GetString(dtRow, "DOC_ISSUING_PARTY_PIN");
            DOC_REF_NUMBER = GetString(dtRow, "DOC_REF_NUMBER");
            PLACE_OF_ISSUE = GetString(dtRow, "PLACE_OF_ISSUE");            
            string docIssueText = GetString(dtRow, "DOC_ISSUE_DATE");
            DOC_ISSUE_DATE = string.IsNullOrEmpty(docIssueText) ? "01/01/1900" : docIssueText;
            string docExpiryText = GetString(dtRow, "DOC_EXPIRY_DATE");
            DOC_EXPIRY_DATE = string.IsNullOrEmpty(docExpiryText) ? "01/01/1900" : docExpiryText;
            BENEFICIARY_PARTY_CODE = GetString(dtRow, "BENEFICIARY_PARTY_CODE");
            BENEFICIARY_PARTY_NAME = GetString(dtRow, "BENEFICIARY_PARTY_NAME");
            BENEFICIARY_PARTY_ADDRESS1 = GetString(dtRow, "BENEFICIARY_PARTY_ADDRESS1");
            BENEFICIARY_PARTY_ADDRESS2 = GetString(dtRow, "BENEFICIARY_PARTY_ADDRESS2");
            BENEFICIARY_PARTY_CITY = GetString(dtRow, "BENEFICIARY_PARTY_CITY");
            BENEFICIARY_PARTY_PIN = GetString(dtRow, "BENEFICIARY_PARTY_PIN");
            FILE_TYPE = GetString(dtRow, "FILE_TYPE");
            ICEGATE_ID = GetString(dtRow, "ICEGATE_ID");
            ICEGATE_DOC_FILE_NAME = GetString(dtRow, "ICEGATE_DOC_FILE_NAME");

            
            #endregion
            
            MAX_ID = Get_general_MAXID("SUPPORTING_DOC_MAX_ID");
            DOC_TYPE = DOC_TYPE == "Job Level" ? "JOB" : DOC_TYPE == "Invoice Level" ? "INVOICE" : "ITEM";            

            dt_SUP_DOC.Rows.Add(MAX_ID + i, IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, "E", IMAGE_REF_NUMBER, DOC_TYPE_CODE, DOC_ISSUING_PARTY_CODE, DOC_ISSUING_PARTY_NAME,
                DOC_ISSUING_PARTY_NAME_ADD1, DOC_ISSUING_PARTY_NAME_ADD2, DOC_ISSUING_PARTY_CITY, DOC_ISSUING_PARTY_PIN, DOC_REF_NUMBER, PLACE_OF_ISSUE, DOC_ISSUE_DATE,
                DOC_EXPIRY_DATE, BENEFICIARY_PARTY_CODE, BENEFICIARY_PARTY_NAME, BENEFICIARY_PARTY_ADDRESS1, BENEFICIARY_PARTY_ADDRESS2, BENEFICIARY_PARTY_CITY,
                BENEFICIARY_PARTY_PIN, FILE_TYPE, currentuser, LoginDate, currentbranch, Working_Period, LoginDate, currentuser, currentuser, LoginDate, DOC_TYPE, ICEGATE_ID,ICEGATE_DOC_FILE_NAME);     

        }

        dt_SUP_DOC.TableName = "BE_ITEM_SW_SUP_DOC";
        data.Tables.Add(dt_SUP_DOC);
        return dt_SUP_DOC;
    }



    //Not used
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

    public DataSet Get_Importer_Seller_Details(string IEC_No, string BranchSlNo)
    {
        objUBO.IEC_NO = IEC_No;
        objUBO.BRANCH_NO = BranchSlNo;
        objUBO.Ename = "Check_Avail_IEC_details";
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        ds_IEC = xl.Bind_Export_General_IEC_No(objUBO);       

        return ds_IEC;
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

    //Not Used
    public DataSet Check_Avail_Importer_Details(string impName)
    {
        #region
        ////Auto_Search Auto = new Auto_Search();
        ////DataSet ds = new DataSet();        
        ////Auto.Ename = "IMP_EXP_MASTER_IMPORTER_IECCODE_WISE";
        ////Auto.Enamesearch = impName;
        ////ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

        //string STD_Type = "";
        //if (HttpContext.Current.Session["STANDARD_TYPE"] != null)
        //{
        //    STD_Type = HttpContext.Current.Session["STANDARD_TYPE"].ToString();

        //    if (STD_Type == "Non_STD")
        //    {
        //        STD_Type = STD_Type;
        //    }
        //    else
        //    {
        //        STD_Type = "";
        //    }
        //}

        //Auto_Search Auto = new Auto_Search();
        //Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH";
        //Auto.Enamesearch = impName;
        //Auto.NSearch = "";
        //Auto.STANDARD_TYPE = STD_Type;

        //ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type(); 
        #endregion

        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "Check_Avail_IEC_details"; // IMP_EXP_MASTER_IMPORTER_SEARCH
        Auto.Enamesearch = impName;
        Auto.NSearch = "";

        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
        //    string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
        //    string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
        //    string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
        //    string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
        //    string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
        //    string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
        //    string IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
        //    impName = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + IMP_EXP_TYPE;
        //}
        return ds;        
    }    

    // Used in Old Methods
    public void IEC_INSERT_UPDATE(string IECNO, string BRNO, string IEC_NAME, string ADD1, string ADD2, string ADD3, string ADD4, string ADD5, string TYPE, string STATECODE, string MARKSNOS, string PAYMENT_METHOD_CODE )
    {
        
        ObjGV.A1 = "";                           // IMP_EXP_ID
        ObjGV.A2 = IEC_NAME;                         // IMP_EXP_NAME
        ObjGV.A3 = IECNO;                        // IMP_EXP_IECNO
        ObjGV.A4 = BRNO;                       // IMP_EXP_BRSLNO
        ObjGV.A5 = "P";                         // IMP_EXP_TYPE
        ObjGV.A6 = ADD1;                         // IMP_EXP_ADD1
        ObjGV.A7 = ADD2;                         // IMP_EXP_ADD2
        ObjGV.A8 = ADD3;                         // IMP_EXP_ADD3
        ObjGV.A9 = ADD4;                         // IMP_EXP_ADD4
        ObjGV.A10 = ADD5;                    // IMP_EXP_PIN_CODE
        ObjGV.A11 = "";              // IMP_EXP_CONTACT_PERSON
        ObjGV.A12 = "";                       // IMP_EXP_PHONE
        ObjGV.A13 = "";                       // IMP_EXP_EMAIL
        ObjGV.A14 = "";                       // IMP_EXP_BINNO
        ObjGV.A15 = "";                     // IMP_EXP_REMARKS
        ObjGV.A16 = "";              // IMP_EXP_DRAWBACK_AC_NO
        ObjGV.A17 = "";                      // IMP_EXP_PAN_NO
        //ObjGV.A18 = "";                       // STANDARD_TYPE
        ObjGV.A19 = "";                              // TIN_NO
        ObjGV.A20 = STATECODE;                          // STATE_CODE
        ObjGV.A21 = "";                         // IMP_EXP_FAX
        ObjGV.A22 = "";                          // EXP_STR_YN
        ObjGV.A23 = "";                    // TYPE_OF_EXPORTER
        ObjGV.A24 = MARKSNOS;                            // MARKS_NO
        ObjGV.A25 = "";           // COMMERCIAL_DETAILS_STATUS
        ObjGV.A26 = COMMERCIAL_TAX_STATENAME;            // COMMERCIAL_TAX_STATENAME
        ObjGV.A27 = COMMERCIAL_TAX_STATECODE;            // COMMERCIAL_TAX_STATECODE
        ObjGV.A28 = "";                 // COMMERCIAL_TAX_TYPE
        ObjGV.A29 = "";      // COMMERCIAL_TAX_REGISTRATION_NO
        ObjGV.A30 = GSTN_TYPE;                           // GSTN_TYPE
        ObjGV.A31 = GSTN_ID;                             // GSTN_ID
        ObjGV.A32 = "";                            // DISTRICT
        ObjGV.A33 = "";                    // EXP_DBK_DECL_CHK
        ObjGV.A34 = "";                      // SEZ_ICEGATE_ID
        ObjGV.A35 = "";                          // SEZ_PAN_NO
        ObjGV.A36 = "";                           // SEZ_AP_ID
        ObjGV.A37 = "";                         // SEZ_AP_NAME
        ObjGV.A38 = WAREHOUSE_CODE;                      // WAREHOUSE_CODE
        ObjGV.A39 = PAYMENT_METHOD_CODE;                 // PAYMENT_METHOD_CODE
        ObjGV.A40 = "";                        // ITEM_END_USE
        ObjGV.A41 = "";               // CLIENT_INSURANCE_RATE
        ObjGV.A42 = "";                          // TAN_NUMBER
        ObjGV.A43 = "";                            // TDS_CODE
        ObjGV.A44 = "";                            // TDS_RATE
        ObjGV.A45 = "";                     // NATURE_OF_TRANS
        ObjGV.A46 = "";                   // NATURE_OF_PAYMENT
        ObjGV.A47 = "";                    // VALUATION_METHOD

        /*
        // Customer
        ObjGV.A48 = A_C_CREDITLIMIT;
        ObjGV.A49 = A_C_CUR;
        CM.A_C_UNLIMITED = A_C_UNLIMITED;
        CM.A_C_COD = A_C_COD;
        CM.A_C_CHK_OVERDUE = A_C_CHK_OVERDUE;
        ObjGV.A50 = A_C_OVERDUE_RESTRICTION;
        CM.CHECK_CREDITONHOLD = A_C_CHK_CRD_HOLD;
        ObjGV.A51 = A_C_CREDITONHOLD;
        ObjGV.A52 = A_C_REC_CRE_PERIOD_DDL;
        ObjGV.A53 = A_C_REC_CRE_PERIOD_DAYS;
        ObjGV.A54 = A_C_CUSTOMER_GL;
        ObjGV.A55 = A_C_NOT_EMAIL;
        CM.Check_OptionalCriteria = A_C_CHK_OPT_CRITERIA;
        ObjGV.A56 = A_C_REC_DDL;
        ObjGV.A57 = A_C_REC_NO_DAYS;
        ObjGV.A58 = A_C_REC_TXTBOX;
        ObjGV.A59 = A_C_CUR2;

        // Vendor
        CM.CHK_Vendor_CLimit = A_V_UNLIMITED;
        ObjGV.A60 = A_V_CREDITLIMIT;
        ObjGV.A61 = A_V_CUR;
        ObjGV.A62 = A_V_PAY_CRE_PERIOD_DDL;
        ObjGV.A63 = A_V_PAY_CRE_PERIOD_TXT;
        ObjGV.A64 = A_V_DUEDATE_CAL;
        ObjGV.A65 = A_V_CUR2;
        ObjGV.A66 = A_V_VENDORGL;
        ObjGV.A67 = A_V_NOTIFIC_MAIL;
        CM.CHK_PaymentHold = A_V_PAYMENT_CHK;
        ObjGV.A68 = A_V_PAYMENTON_HOLD;

        // TDS
        ObjGV.A69 = A_T_FISCALYEAR;
        ObjGV.A70 = A_T_ORG_TYPE;
        CM.CHK_SpecifiedPerson = A_T_SPC_PERSON;
        ObjGV.A71 = A_T_TDS_RECEIVABLE;
        ObjGV.A72 = A_C_Code;
        ObjGV.A73 = A_V_Code; */

        // Flags
        ObjGV.A200 = "S"; 
        ObjGV.A201 = "";
        ds = CM.Imp_Exp_Master_Insert_update_STD(ObjGV);
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
                        JOB_SUFFIX = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        JOBNO_PS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + IMPORT_JOBNO.TrimEnd())).TrimStart();
                        JOB_PREFIX = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        JOB_SUFFIX = string.Empty;
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        JOBNO_PS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + IMPORT_JOBNO + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();

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

    public DataSet Get_Importer_Supplier_Details(string SupplierName)
    {
        objUBO.IEC_NO = SupplierName;
        objUBO.BRANCH_NO = "";
        objUBO.Ename = "Check_Avail_SUPPLIER_details";
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        ds_supplier = xl.Bind_Export_General_IEC_No(objUBO);

        return ds_supplier;
    }    

    public DataTable ReImp_Excel_Upload(DataTable dt)
    {
        //try
        //{
        int Re_Imp_id_Max = Get_general_MAXID("REIMPORT_MAX_ID");
        ds.Tables.Add(dt.Copy());



        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            // ── Build output table ────────────────────────────────────────────
            DataTable dtXML = new DataTable("RE_IMP_XL_UPLOAD");

            string[] cols = { "RE_IMPORT_ID", "RE_IMPORT_SLNO", "JOBNO", "INVOICE_SLNO", "INVOICE_NO", "ITEM_SLNO", "SB_NO", "SB_DATE", "PORT_EXPORT", "SB_INVOICE_NO", "SB_INVOICE__ITEM_NO", "NOTN_NO", "NOTN_SLNO", "EXPORT_FREIGHT", "EXPORT_INSURANCE", "CUSTOMS_DUTY", "EXCISE_DUTY", "USER_ID", "DATE_TIME", "STATUS", "BRANCH_CODE", "YEAR", "WORKING_PERIOD", "MODIFIEDBY", "MODIFIEDON" };
            //       "RE_IMPORT_ID", "RE_IMPORT_SLNO", "JOBNO", "INVOICE_SLNO", "ITEM_SLNO", "SB_NO", "SB_DATE", "SB_INVOICE_NO", "SB_INVOICE__ITEM_NO", "PORT_EXPORT", "NOTN_NO", "NOTN_SLNO", "EXPORT_FREIGHT", "EXPORT_INSURANCE", "CUSTOMS_DUTY", "EXCISE_DUTY", "USER_ID", "DATE_TIME", "STATUS", "BRANCH_CODE", "YEAR", "WORKING_PERIOD", "MODIFIEDBY", "MODIFIEDON" 
            foreach (string col in cols)
                dtXML.Columns.Add(col);


            if (dsXML.Tables.Contains("RE_IMP_XL_UPLOAD"))
            {
                dsXML.Tables.Remove("RE_IMP_XL_UPLOAD");
            }
            dsXML.Tables.Add(dtXML);

            int slno = 1;  // RE_IMPORT_SLNO counter

            // ── Process each Excel row ────────────────────────────────────────
            foreach (DataRow dtRow in ds.Tables[0].Rows)
            {
                string invoiceSlno = GetString(dtRow, "INVOICE_SLNO");
                string itemSlno = GetString(dtRow, "ITEM_SLNO");
                string sbNo = GetString(dtRow, "SB_NO");
                string sbDate = GetString(dtRow, "SB_DATE");
                string sbInvoiceNo = GetString(dtRow, "SB_INVOICE_NO");
                string sbInvoiceItemNo = GetString(dtRow, "SB_INVOICE__ITEM_NO");
                string portExport = GetString(dtRow, "PORT_EXPORT");
                string notnNo = GetString(dtRow, "NOTN_NO");
                string notnSlno = GetString(dtRow, "NOTN_SLNO");
                string exportFreight = GetString(dtRow, "EXPORT_FREIGHT");
                string exportInsurance = GetString(dtRow, "EXPORT_INSURANCE");
                string customsDuty = GetString(dtRow, "CUSTOMS_DUTY");
                string exciseDuty = GetString(dtRow, "EXCISE_DUTY");

                // Skip blank rows
                if (string.IsNullOrWhiteSpace(invoiceSlno))
                    continue;

                if (flag == "S")
                {
                    #region

                    int checkResult = Check_Avail_ReImport(sbNo);
                    DataSet dss = (DataSet)ViewState["dss"];

                    if (checkResult == 1)
                    {
                        // ── Lookup Invoice No from session DataSet ────────────────
                        string invoiceNo = string.Empty;
                        if (dss != null && dss.Tables.Count > 1 && dss.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow invRow in dss.Tables[1].Rows)
                            {
                                if (GetString(invRow, "INVOICE_SLNO") == invoiceSlno)
                                {
                                    invoiceNo = GetString(invRow, "INVOICE_NO");
                                    break;
                                }
                            }
                        }

                        // ── Format SB_DATE safely ─────────────────────────────────
                        string formattedDate = string.Empty;
                        DateTime parsedDate;
                        if (DateTime.TryParse(sbDate, out parsedDate))
                            formattedDate = parsedDate.ToString("dd/MM/yyyy");

                        // ── Build output row ──────────────────────────────────────
                        DataRow dr = dsXML.Tables[0].NewRow();

                        dr["RE_IMPORT_ID"] = ++Re_Imp_id_Max;
                        dr["RE_IMPORT_SLNO"] = slno++;
                        dr["JOBNO"] = IMPORT_JOBNO;
                        dr["INVOICE_SLNO"] = invoiceSlno;
                        dr["INVOICE_NO"] = invoiceNo;
                        dr["ITEM_SLNO"] = itemSlno;
                        dr["SB_NO"] = sbNo;
                        dr["SB_DATE"] = formattedDate;
                        dr["SB_INVOICE_NO"] = sbInvoiceNo;
                        dr["SB_INVOICE__ITEM_NO"] = sbInvoiceItemNo;
                        dr["PORT_EXPORT"] = portExport;
                        dr["NOTN_NO"] = notnNo;
                        dr["NOTN_SLNO"] = notnSlno;
                        dr["EXPORT_FREIGHT"] = exportFreight;
                        dr["EXPORT_INSURANCE"] = exportInsurance;
                        dr["CUSTOMS_DUTY"] = customsDuty;
                        dr["EXCISE_DUTY"] = exciseDuty;
                        dr["BRANCH_CODE"] = Connection.Current_Branch();
                        dr["WORKING_PERIOD"] = Working_Period;
                        dr["STATUS"] = "N";
                        dr["YEAR"] = string.Empty;
                        dr["USER_ID"] = currentuser;
                        dr["DATE_TIME"] = LoginDate;
                        dr["MODIFIEDBY"] = currentuser;
                        dr["MODIFIEDON"] = LoginDate;

                        dsXML.Tables[0].Rows.Add(dr);
                    }
                    else
                    {
                        DataRow e = allErrors.NewRow();
                        e["TABLE_NAME"] = "RE_IMPORT";
                        e["ERROR_DESCRIPTION"] = " SB_NO " + sbNo + " already exists.";
                        e["DATA"] = " Inv SL No : " + invoiceSlno + " Item SL No : " + itemSlno;
                        allErrors.Rows.Add(e);
                    }

                    #endregion
                }
            }

            ReImp_DATA_CHECK(dsXML.Tables[0]);

        }
        DataTable dtCopy = dsXML.Tables[0].Copy(); 
        return dtCopy;
    }

    public int Check_Avail_ReImport(string SB_NO)
    {
        DataSet dss = new DataSet();
        RE_IMP.JOBNO = IMPORT_JOBNO;
        RE_IMP.SB_NO = SB_NO;
        RE_IMP.flag = "Check_Avail";
        RE_IMP.WORKING_PERIOD = Working_Period;
        RE_IMP.BRANCH_CODE = Connection.Get_Company_Type();
        RE_IMP.BRANCH_COMMON = Connection.Get_Company_Type();

        //DataTable TEMP1 = ds.Tables[0];
        dss = RE_IMP_OBJ.Re_Import_XL(RE_IMP); //Result Set 1 → Availability Status // Result Set 2 → Invoice Details
        ViewState["dss"] = dss; // SELECT JOBNO,INVOICE_SLNO,INVOICE_NO FROM INVOICE_DETAILS WHERE JOBNO = @JOBNO AND  BRANCH_CODE = @Branch_Common ORDER BY INVOICE_SLNO 
        i = RE_IMP_OBJ.result; // 1-Not Exist,2 Exist

        return i;
    }    
    
    public void ReImp_DATA_CHECK(DataTable excelData)
    {      

        // Setup parameters
        RE_IMP.RE_IMPORT_ID = ConvertDataTableToXML(excelData); 
        RE_IMP.flag = "Data_Check";
        RE_IMP.WORKING_PERIOD = Working_Period;

        // Call stored procedure
        DataSet dck = RE_IMP_OBJ.Re_Import_XL(RE_IMP);

        // Validate dataset structure
        if (dck.Tables == null || dck.Tables.Count < 2)
        {
            new ErrorLogs().makeLog("SP must return at least 2 tables");
            return;
        }

        DataTable resultTable = dck.Tables[1];
        if (resultTable.Rows.Count == 0)
        {
            new ErrorLogs().makeLog("Data_Check - table have no rows");
            return;
        }

        bool hasSbNo = resultTable.Columns.Count > 3;        

        // Process errors efficiently
        foreach (DataRow row in resultTable.Rows)
        {           
            //string error = row.Field<string>("ERROR").Trim();
            string error = Convert.ToString(row["ERROR"]);
            
            if (string.IsNullOrEmpty(error) || error == "T")
                continue;

            //string invSlno = row.Field<string>("INVOICE_SLNO") ?? string.Empty;
            //string itmSlno = row.Field<string>("ITEM_SLNO") ?? string.Empty;
            string invSlno = Convert.ToString(row["INVOICE_SLNO"]);
            string itmSlno = Convert.ToString(row["ITEM_SLNO"]);
            
            DataRow e = allErrors.NewRow();
            e["TABLE_NAME"] = "RE_IMPORT";
            e["ERROR_DESCRIPTION"] = error;

            if (hasSbNo)
            {
                //string sbNo = row.Field<string>("SB_NO") ?? string.Empty;
                string sbNo = Convert.ToString(row["SB_NO"]);
                e["COLUMN_NAME"] = "INVOICE_SLNO - ITEM_SLNO - SB_NO " + sbNo;
                e["DATA"] = invSlno + "-" + itmSlno + "-" + sbNo;                
            }
            else 
            { 
                e["COLUMN_NAME"] = "INVOICE_SLNO - ITEM_SLNO  ";
                e["DATA"] = invSlno + "-" + itmSlno;  
            }            
            allErrors.Rows.Add(e);
        }
    }


    public int SqlBulkUpload_Job(DataSet ds)
    {
        var tableMap = new Dictionary<string, string>
            {
                //{ "GENERAL DETAILS", "GENERAL_DETAILS" },
                { "IGM DETAILS", "IGM_DETAILS" },
                { "CONTAINER DETAILS", "CONTAINER_DETAILS" },
                //{ "INVOICE DETAILS", "INVOICE_DETAILS" },
                //{ "ITEM PRODUCT DETAILS", "ITEM_PRODUCT_DETAILS" },
                { "RE IMPORT", "RE_IMPORT_DETAILS" },
                { "SW INFO TYPE", "BE_ITEM_SW_INFO_TYPE" },
                { "SW CONST", "BE_ITEM_SW_CONST" },
                { "SW PROD", "BE_ITEM_SW_PROD" },
                { "SW CONTROL", "BE_ITEM_SW_CONTROL" },
                { "LICENSE DETAILS", "LICENSE_DETAILS" },
                { "BOND", "BOND_DETAILS" },
                { "CERTIFICATE", "CERTIFICATE_DETAILS" },
                { "SW SUP DOCS", "BE_ITEM_SW_SUP_DOC" }
            };

        using (SqlConnection con = new SqlConnection(comp_ConnectionStr))
        {
            con.Open();

            using (SqlTransaction tran = con.BeginTransaction())
            {
                try
                {

                    foreach (var item in tableMap)
                    {
                        string sheetName = item.Key;
                        string tableName = item.Value;
                        DataTable dt = ds.Tables[tableName];

                        // Skip empty tables
                        if (dt == null || dt.Rows.Count == 0)
                            continue;

                        #region CHECK TRANSPORT MODE
                        if (sheetName == "CONTAINER DETAILS")
                        {
                            Transact.JOBID = "0";
                            Transact.JOBNO = IMPORT_JOBNO;
                            Transact.IMPORTER_NAME = "";
                            Transact.TRANSPORT_MODE = "";
                            Transact.CUSTOMS_HOUSE = "";
                            Transact.Ename = "select_Id";
                            Transact.WORKING_PERIOD = SELECT_BRANCH;
                            DataSet dtGeneral = Transact.RetrieveAll_General_Details();

                            string trMode = "";
                            if (dtGeneral != null && dtGeneral.Tables[1].Rows.Count > 0)
                            {
                                trMode = Convert.ToString(dtGeneral.Tables[1].Rows[0]["TRANSPORT_MODE"]);
                                if (trMode == "Air")
                                    continue;
                            }
                            
                        }

                        #endregion
                        

                        errorSheetandTableName = "Sheet Name : " + sheetName + " Table Name : " + tableName;

                        #region  DELETE EXISTING DATA USING SP

                        using (SqlCommand cmd = new SqlCommand("SP_JOB_ALLDATA", con, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@JOBNO", IMPORT_JOBNO);
                            cmd.Parameters.AddWithValue("@BRANCHCODE", Connection.Current_Branch());
                            cmd.Parameters.AddWithValue("@Operation", "Delete");
                            cmd.Parameters.AddWithValue("@Table", tableName);                            

                            // Output : ErrorMsg
                            SqlParameter errorParam = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1);
                            errorParam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(errorParam);

                            // Output : MStatus
                            SqlParameter statusParam = new SqlParameter("@MStatus", SqlDbType.Int);
                            statusParam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(statusParam);

                            cmd.ExecuteNonQuery();

                            string ErrorMsg = Convert.ToString(errorParam.Value);
                            //int MStatus = statusParam.Value != DBNull.Value ? Convert.ToInt32(statusParam.Value) : 0;
                        }
                        #endregion

                        using (SqlBulkCopy bulk = new SqlBulkCopy(con, SqlBulkCopyOptions.KeepIdentity, tran))
                        {
                            bulk.DestinationTableName = item.Value;
                            bulk.BatchSize = 3000;
                            bulk.BulkCopyTimeout = 12000;

                            // Optional: auto map columns (only if names match)
                            foreach (DataColumn col in dt.Columns)
                            {
                                bulk.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                            }
                            bulk.WriteToServer(dt);
                        }
                    }

                    tran.Commit();                    
                    Result = 1;
                    Session["JobBulk"] = "Update";
                    flag = "U";
                }
                catch (Exception ex)
                {                    
                    ErrorLogs er = new ErrorLogs();
                    er.makeLog(errorSheetandTableName + ex.Message);
                    tran.Rollback();
                    ManualRollBack();
                    //RollBackSelectedNodes(result); 
                    
                }
            }
        }

        if (Result == 1)
        {
            Result = 0; //Alert_msg("Excel Uploaded Successfully.");
            //ScriptManager.RegisterStartupScript(this,GetType(),"closePopup","jAlert('Excel Uploaded Successfully.','Success', function(){ RefreshParent(); });", true);
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "closePopup", @"jAlert('Excel Uploaded Successfully.','Success',function(){parent.location.reload();parent.dhtmlmodal.close();});", true);
        }
        return Result;
    }

    private void ManualRollBack()
    {
        #region old method
    /*    string[] tables =
    {
        "INVOICE_DETAILS",//"BE_ITEM_SW_SUP_DOC",
        "ITEM_PRODUCT_DETAILS",//"RE_IMPORT_DETAILS",
        "GENERAL_DETAILS"
    };

        using (SqlConnection con = new SqlConnection(comp_ConnectionStr))
        {
            con.Open();

            foreach (string table in tables)
            {
                using (SqlCommand cmd = new SqlCommand("SP_JOB_ALLDATA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@JOBNO", IMPORT_JOBNO);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", Connection.Current_Branch());
                    cmd.Parameters.AddWithValue("@Operation", "Delete");
                    cmd.Parameters.AddWithValue("@Table", table);

                    cmd.Parameters.Add("@ErrorMsg", SqlDbType.NVarChar, -1)
                       .Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@MStatus", SqlDbType.Int)
                       .Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                }
            }
        } */
        #endregion

        if (flag == "S")
        {
            var result = DeleteJobDataByTable("ITEM_PRODUCT_DETAILS");
            result = DeleteJobDataByTable("INVOICE_DETAILS");
            result = DeleteJobDataByTable("GENERAL_DETAILS");
        }
        else
        {
            try
            {
                if (dsBkp.Tables.Contains("ITEM_PRODUCT_DETAILS_Bak") && dsBkp.Tables["ITEM_PRODUCT_DETAILS_Bak"].Rows.Count > 0)
                {
                    SqlBulk_Upload_Product("ITEM_PRODUCT_DETAILS", dsBkp.Tables["ITEM_PRODUCT_DETAILS_Bak"], Session["currentcomp_db"].ToString());
                }

                if (dsBkp.Tables.Contains("INVOICE_DETAILS_Bak") && dsBkp.Tables["INVOICE_DETAILS_Bak"].Rows.Count > 0)
                {
                    SqlBulk_Upload_Product("INVOICE_DETAILS", dsBkp.Tables["INVOICE_DETAILS_Bak"], Session["currentcomp_db"].ToString());
                }

                if (dsBkp.Tables.Contains("GENERAL_DETAILS_Bak") && dsBkp.Tables["GENERAL_DETAILS_Bak"].Rows.Count > 0)
                {
                    SqlBulk_Upload_Product("GENERAL_DETAILS", dsBkp.Tables["GENERAL_DETAILS_Bak"], Session["currentcomp_db"].ToString());
                }
            }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();
                er.makeLog("ManualRollBack" + ex.Message);
                DownloadExel(dsBkp);
            }
        }
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

    public string GetString(DataRow row, string col)
    {
        return row[col] == DBNull.Value ? "" : row[col].ToString().Trim();
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
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

        int col_count = e.Row.Cells.Count;


        if (ViewState["err_Validate"] == "Y")
        {
            if (e.Row.Cells.Count >= 1)
            {
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
        }
    } 

    

    private bool IsBlankCell(object cellValue)
    {
        if (cellValue == null || cellValue == DBNull.Value)
            return true;
        string strVal = cellValue.ToString().Trim();
        return string.IsNullOrWhiteSpace(strVal) || strVal.Equals("nan", StringComparison.OrdinalIgnoreCase) || strVal.Equals("-", StringComparison.OrdinalIgnoreCase);
    }

    private string GetExcelOrMaster(DataRow excelRow, DataRow masterRow, string excelCol, string masterCol)
    {
        string excelVal = (excelRow[excelCol] == DBNull.Value)
                          ? ""
                          : excelRow[excelCol].ToString().Trim();

        string masterVal = (masterRow[masterCol] == DBNull.Value)
                           ? ""
                           : masterRow[masterCol].ToString().Trim();

        return !string.IsNullOrEmpty(excelVal) ? excelVal : masterVal;
    }

    public DataTable Filter_EmptyRows(DataTable dtn, int col)
    {
        int xxx = 0;
        int ij = 0;

        DataTable dttableNew = dtn.Clone();

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


    public class OperationResult
    {
        public bool Success { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }

    public OperationResult DeleteJobDataByTable(string tableName)
    {
        OperationResult result = new OperationResult();

        using (SqlConnection con = new SqlConnection(Connection.GetConnection()))
        {
            using (SqlCommand cmd = new SqlCommand("SP_JOB_ALLDATA", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JOBNO", IMPORT_JOBNO);
                cmd.Parameters.AddWithValue("@BRANCHCODE", Connection.Current_Branch());
                cmd.Parameters.AddWithValue("@Operation", "Delete");
                cmd.Parameters.AddWithValue("@Table", tableName);

                SqlParameter errorParam = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(errorParam);

                SqlParameter statusParam = new SqlParameter("@MStatus", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(statusParam);
                con.Open();
                cmd.ExecuteNonQuery();

                result.Message = Convert.ToString(errorParam.Value);
                result.Status = statusParam.Value == DBNull.Value ? 0 : Convert.ToInt32(statusParam.Value);
                result.Success = result.Status == 1;
            }
        }

        return result;
    }

    private void RollBackSelectedNodesold(string[] selectedNodes) // List<string> selectedNodes 
    {
        StringBuilder sb = new StringBuilder();

        foreach (string node in selectedNodes)
        {
            sb.AppendLine(@"EXEC SP_JOB_ALLDATA  @JOBNO=@JOBNO, @BRANCHCODE=@BRANCHCODE, @Operation='DeleteByNode', @Table='"+ node +"', @ErrorMsg=NULL OUTPUT,@MStatus=NULL OUTPUT;");
        }

        using (SqlConnection con = new SqlConnection(Connection.GetConnection()))
        {
            using (SqlCommand cmd = new SqlCommand(sb.ToString(), con))
            {
                cmd.Parameters.AddWithValue("@JOBNO", IMPORT_JOBNO);
                cmd.Parameters.AddWithValue("@BRANCHCODE", Connection.Current_Branch());
                //cmd.CommandTimeout = 0;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    private void RollBackSelectedNodes1(string[] selectedNodes)
    {
        using (SqlConnection con = new SqlConnection(Connection.GetConnection()))
        {
            con.Open();

            foreach (string node in selectedNodes)
            {
                using (SqlCommand cmd = new SqlCommand("SP_JOB_ALLDATA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;                    

                    cmd.Parameters.AddWithValue("@JOBNO", IMPORT_JOBNO);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", Connection.Current_Branch());
                    cmd.Parameters.AddWithValue("@Operation", "DeleteByNode");
                    cmd.Parameters.AddWithValue("@Table", node);

                    cmd.Parameters.Add("@ErrorMsg", SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MStatus", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //// Optional: check status/error
                    //int status = cmd.Parameters["@MStatus"].Value == DBNull.Value ? 0 : Convert.ToInt32(cmd.Parameters["@MStatus"].Value);
                    //string error = cmd.Parameters["@ErrorMsg"].Value == DBNull.Value ? "" : cmd.Parameters["@ErrorMsg"].Value.ToString();
                    //if (status == 0 && !string.IsNullOrEmpty(error))
                    //{
                    //    throw new Exception(error);
                    //}
                }
            }
        }
    }

    public OperationResult RollBackSelectedNodes(string[] selectedNodes)
    {
        OperationResult result = new OperationResult();

        if (selectedNodes == null && Session["BulkJob_SelectedNode"] != null)
        {
            selectedNodes = (string[])Session["BulkJob_SelectedNode"];
            Session.Remove("BulkJob_SelectedNode");
        }


        using (SqlConnection con = new SqlConnection(Connection.GetConnection()))
        {
            con.Open();
            foreach (string node in selectedNodes)
            {
                using (SqlCommand cmd = new SqlCommand("SP_JOB_ALLDATA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@JOBNO", IMPORT_JOBNO);
                    cmd.Parameters.AddWithValue("@BRANCHCODE", Connection.Current_Branch());
                    cmd.Parameters.AddWithValue("@Operation", "DeleteByNode");
                    cmd.Parameters.AddWithValue("@Table", node);

                    SqlParameter errorParam = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(errorParam);

                    SqlParameter statusParam = new SqlParameter("@MStatus", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(statusParam);                    
                    cmd.ExecuteNonQuery();

                    result.Message = Convert.ToString(errorParam.Value);
                    result.Status = statusParam.Value == DBNull.Value ? 0 : Convert.ToInt32(statusParam.Value);
                    result.Success = result.Status == 1;
                }
            }
        }

        return result;
    }

    public int SqlBulk_Upload_Product(string tbl_name, DataTable dss, string MASTER_CONN)
    {        
        string connew = MASTER_CONN;

        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connew, SqlBulkCopyOptions.KeepIdentity))
        {
            bulkCopy.DestinationTableName = tbl_name;
            bulkCopy.BatchSize = 3000;
            bulkCopy.BulkCopyTimeout = 12000;

            // Optional: auto map columns (only if names match) added by George Bush on 15-06-2026
            foreach (DataColumn col in dss.Columns)
            {
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            }
            
            bulkCopy.WriteToServer(dss);
            bulkCopy.Close();
            Result = 1;
        }
        return Result;
    }
    //use when "Received an invalid column length from the bcp client for colid 24" error occurs
    public int SqlBulk_Upload_ProductColid(string tbl_name, DataTable dss, string MASTER_CONN)
    {
        try
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(MASTER_CONN, SqlBulkCopyOptions.KeepIdentity))
            {
                bulkCopy.DestinationTableName = tbl_name;
                bulkCopy.BatchSize = 3000;
                bulkCopy.BulkCopyTimeout = 12000;

                foreach (DataColumn col in dss.Columns)
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);

                bulkCopy.WriteToServer(dss);
                bulkCopy.Close();
                Result = 1;
            }
        }
        catch (Exception ex)
        {
            // ── Check if it is the invalid column length error ───────────────────
            if (ex.Message.Contains("invalid column length from the bcp client"))
            {
                // ── Use reflection to extract the hidden colid from SqlBulkCopy ──
                // colid is 1-based in the error but 0-based in ColumnMappings
                System.Reflection.FieldInfo fi = typeof(SqlBulkCopy)
                    .GetField("_sortedColumnMappings",
                               System.Reflection.BindingFlags.NonPublic |
                               System.Reflection.BindingFlags.Instance);

                // ── Parse colid from error message ───────────────────────────────
                // Message: "Received an invalid column length from the bcp client for colid 24"
                string msg = ex.Message;
                int colid = 0;
                string marker = "colid ";
                int idx = msg.IndexOf(marker);
                if (idx >= 0)
                    int.TryParse(msg.Substring(idx + marker.Length).Trim().Split('.')[0], out colid);

                // colid in error message is 1-based — convert to 0-based
                int zeroBasedColId = colid - 1;

                // ── Get column name from DataTable ────────────────────────────────
                string offendingColumnName = "Unknown";
                string offendingColumnValue = "Unknown";

                if (zeroBasedColId >= 0 && zeroBasedColId < dss.Columns.Count)
                {
                    offendingColumnName = dss.Columns[zeroBasedColId].ColumnName;

                    // ── Find the row and value that caused the overflow ───────────
                    foreach (DataRow row in dss.Rows)
                    {
                        object cellVal = row[offendingColumnName];
                        string cellStr = cellVal == null || cellVal == DBNull.Value
                                         ? string.Empty
                                         : cellVal.ToString();

                        // Get the DB column max length from your master table or
                        // use a rough check — anything over 500 chars is suspicious
                        if (cellStr.Length > 500)
                        {
                            offendingColumnValue = cellStr.Substring(0, 200) + "...";
                            break;
                        }
                    }

                    // ── If no obvious overflow found, just show first row value ───
                    if (offendingColumnValue == "Unknown" && dss.Rows.Count > 0)
                    {
                        object firstVal = dss.Rows[0][offendingColumnName];
                        offendingColumnValue = firstVal == null || firstVal == DBNull.Value
                                              ? "(null)"
                                              : firstVal.ToString();
                    }
                }

                // ── Log everything ────────────────────────────────────────────────
                ErrorLogs er = new ErrorLogs();
                er.makeLog(string.Format(
                    "BulkCopy InvalidColumnLength | Table: {0} | ColID (1-based): {1} | " +
                    "Column Name: {2} | Sample Value: {3}",
                    tbl_name,
                    colid,
                    offendingColumnName,
                    offendingColumnValue));

                Alert_msg(string.Format(
                    "Upload failed. Column [{0}] has a value that exceeds the allowed length. " +
                    "Value: [{1}]",
                    offendingColumnName,
                    offendingColumnValue.Length > 100
                        ? offendingColumnValue.Substring(0, 100) + "..."
                        : offendingColumnValue));
            }
            else
            {
                ErrorLogs er = new ErrorLogs();
                er.makeLog("BulkCopy Error | Table: " + tbl_name + " | " + ex.Message);
            }

            Result = 0;
        }

        return Result;
    }


    public void Read_from_Excel()
    {
        // ── Step 1: Map + Read Excel into DataSet ────────────────────────────────
        if (!ReadExcelIntoDataSet())   // returns false if empty sheets / bad file
            return;

        // ── Step 2: Rename columns to match DB names ─────────────────────────────
        RenameColumnsToDbNames();

        #region Importer/Seller/ThirdParty

        if (result != null && result.Contains("GENERAL"))
        {
            // ── Step 3: Check Importer exists ────────────────────────────────────────
            string iecNo = GetValueFromExcel(data, "GENERAL", "IEC_NO");
            string branchNo = GetValueFromExcel(data, "GENERAL", "BRANCH_NO");

            if (!string.IsNullOrWhiteSpace(iecNo) && !string.IsNullOrWhiteSpace(branchNo))
            {
                dsImp = Get_Importer_HSS_Details(iecNo, branchNo);
                if (dsImp == null || dsImp.Tables.Count == 0 || dsImp.Tables[0].Rows.Count == 0)
                {
                    // Save renamed, validated-ready data into session
                    Session["BulkJobUploadData"] = data;
                    Session["BulkJob_STAGE"] = "CHECK_IMPORTER";
                    //Session["BulkJob_SelectedNode"] = result;

                    lblUser_Msg.Text = "Importer does not exist in the Master. Do you want to add it?";
                    MP_U.Show();
                    return; // ← STOP HERE until user confirms
                }
            }

            // ── Step 4: Check Seller exists ────────────────────────────────────────
            string hssIec = GetValueFromExcel(data, "GENERAL", "HIGH_SEA_IEC");
            string hssBranch = GetValueFromExcel(data, "GENERAL", "HIGH_SEA_BRANCH_SL_NO");

            if (!string.IsNullOrWhiteSpace(hssIec) && !string.IsNullOrWhiteSpace(hssBranch))
            {
                ds_IEC = Get_Importer_HSS_Details(hssIec, hssBranch);
                if (ds_IEC == null || ds_IEC.Tables.Count == 0 || ds_IEC.Tables[0].Rows.Count == 0)
                {
                    //Session["BulkJobUploadData"] = data;
                    //Session["BulkJob_STAGE"] = "CHECK_SELLER";
                    //Session["BulkJob_SelectedNode"] = result;

                    //lblUser_Msg.Text = "Seller does not exist in the Master. Do you want to add it?";
                    //MP_U.Show();

                    Alert_msg("Seller not available please add in master and retry");
                    return; // ← STOP HERE until user confirms
                }
            }
        }

        if (result != null && result.Contains("INVOICE"))
        {
            // ── Step 6: Check Third Party exists ────────────────────────────────────────
            string tName = GetValueFromExcel(data, "INVOICE", "THIRDPARTY_NAME");            

            if (!string.IsNullOrWhiteSpace(tName))
            {
                ds_TP = Get_ThirdParty_Details(tName);
                if (ds_TP == null || ds_TP.Tables.Count == 0 || ds_TP.Tables[0].Rows.Count == 0)
                {
                    Session["BulkJobUploadData"] = data;
                    Session["BulkJob_STAGE"] = "CHECK_THIRDPARTY";
                    //Session["BulkJob_SelectedNode"] = result;

                    lblUser_Msg.Text = "Third Party does not exist in the Master. Do you want to add it?";
                    MP_U.Show();
                    return; // ← STOP HERE until user confirms
                }
            }

            // ── Step 7: Check Supplier  exists ────────────────────────────────────────
            string suppName = GetValueFromExcel(data, "INVOICE", "SUPPLIER_NAME");

            if (!string.IsNullOrWhiteSpace(suppName))
            {
                ds_supplier = Get_Supplier_Details(suppName);
                if (ds_supplier == null || ds_supplier.Tables.Count == 0 || ds_supplier.Tables[0].Rows.Count == 0)
                {
                    Session["BulkJobUploadData"] = data;
                    Session["BulkJob_STAGE"] = "CHECK_SUPPLIER";
                    //Session["BulkJob_SelectedNode"] = result;

                    lblUser_Msg.Text = "Supplier does not exist in the Master. Do you want to add it?";
                    MP_U.Show();
                    return; // ← STOP HERE until user confirms
                }
            }
        }
        

        #endregion

        // ── Step 5: Validate + Insert ─────────────────────────────────────────────
        ValidateAndInsert(data);
    }

    private bool ReadExcelIntoDataSet()
    {
        #region Map selected nodes to Excel sheet names

        var map = new Dictionary<string, string>
    {
        { "GENERAL DETAILS",      "GENERAL"         },
        { "IGM DETAILS",          "IGM"             },
        { "CONTAINER DETAILS",    "CONTAINER"       },
        { "INVOICE DETAILS",      "INVOICE"         },
        { "ITEM PRODUCT DETAILS", "ITEMS"           },
        { "RE IMPORT",            "RE_IMPORT"       },
        { "SW INFO TYPE",         "SW_INFO_TYPE"    },
        { "SW CONST",             "SW_CONSTITUENT"  },
        { "SW PROD",              "SW_PRODUCTION"   },
        { "SW CONTROL",           "SW_CONTROL"      },
        { "LICENSE DETAILS",      "LICENSE"         },
        { "BOND",                 "BONDS"           },
        { "CERTIFICATE",          "CERTIFICATES"    },
        { "SW SUP DOCS",          "SUPPORTING_DOCS" }
    };

        result = selectedNode.Select(x => map.ContainsKey(x) ? map[x] : x).ToArray();

        // ── GENERAL sheet is mandatory for new job ────────────────────────────
        if (flag == "S" && !result.Contains("GENERAL"))
        {
            Alert_msg("To create a job you must upload General Details first.");
            return false;
        }

        #endregion

        #region Build OleDb connection string

        if (!fileuploadExcel.HasFile)
        {
            Alert_msg("Please select an Excel file to upload.");
            return false;
        }

        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadExcel.FileName;

        // Save uploaded file to error folder
        string picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
        addtoGallery(fileuploadExcel.FileName, errorFolder, "NORMAL");

        string connString = "";

        if (strFileType == ".xls")
        {
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                         "Data Source=" + path + ";" +
                         "Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        }
        else if (strFileType == ".xlsx")
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                         "Data Source=" + path + ";" +
                         "Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=1\"";
        }
        else
        {
            Alert_msg("Unsupported file type: " + strFileType +
                      ". Please upload .xls or .xlsx only.");
            return false;
        }

        #endregion

        #region Read each selected sheet into DataSet

        List<string> emptySheets = new List<string>();

        foreach (string sheetName in result)
        {
            using (OleDbConnection con = new OleDbConnection(connString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DataTable dataTable = new DataTable();
                dataTable.TableName = sheetName;

                new OleDbDataAdapter(
                    string.Format("SELECT * FROM [{0}$]", sheetName), con)
                    .Fill(dataTable);

                // ── Remove completely empty rows ──────────────────────────────
                for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
                {
                    bool isEmpty = true;
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        if (!string.IsNullOrWhiteSpace(dataTable.Rows[i][col].ToString()))
                        {
                            isEmpty = false;
                            break;
                        }
                    }
                    if (isEmpty) dataTable.Rows.RemoveAt(i);
                }
                dataTable.AcceptChanges();

                if (dataTable.Rows.Count == 0)
                    emptySheets.Add(sheetName); // collect — don't stop yet
                else
                    data.Tables.Add(dataTable);
            }
        }

        #endregion

        #region Report empty sheets — all at once

        if (emptySheets.Count > 0)
        {
            string sheetList = string.Join("\\n", emptySheets.ToArray());
            Alert_msg("Following sheets have no data:\\n" + sheetList);
            return false;
        }

        #endregion

        return true;
    }

    private void RenameColumnsToDbNames()
    {
        // ── GENERAL ──────────────────────────────────────────────────────────────
        if (data.Tables.Contains("GENERAL"))
        {
            DataTable dt = data.Tables["GENERAL"];
            RenameColumn(dt, "CUSTOM_HOUSE_CODE", "CUSTOMS_HOUSE");
            RenameColumn(dt, "ICEGATEID", "ICE_ID");
            RenameColumn(dt, "BRANCH_SL_NO", "BRANCH_NO");
            RenameColumn(dt, "COUNTRY_OF_ORIGIN", "COUNTRY_ORIGIN");
            RenameColumn(dt, "COUNTRY_OF_SHIPMENT", "COUNTRY_SHIPMENT");
            RenameColumn(dt, "PORT_OF_ORIGIN", "PORT_ORIGIN");
            RenameColumn(dt, "PORT_OF_SHIPMENT", "PORT_SHIPMENT");
            RenameColumn(dt, "COMMERCIAL_TAX_DETAILS", "COMMERCIAL_DETAILS_STATUS");
            RenameColumn(dt, "STATE_NAME", "COMMERCIAL_TAX_STATENAME");
            RenameColumn(dt, "STATE_CODE", "COMMERCIAL_TAX_STATECODE");
            RenameColumn(dt, "REGISTRATION_NO", "COMMERCIAL_TAX_REGISTRATION_NO");
            RenameColumn(dt, "GSTN_TYPE", "COMMERCIAL_TAX_TYPE");
            RenameColumn(dt, "SELLER_NAME", "HIGH_SEA_SALE_NAME");
            RenameColumn(dt, "HSS_IEC_NO", "HIGH_SEA_IEC");
            RenameColumn(dt, "BR_SL_NO", "HIGH_SEA_BRANCH_SL_NO");
            RenameColumn(dt, "PAYMENT_METHOD", "PAYMENT_METHOD_CODE");
        }

        // ── IGM ──────────────────────────────────────────────────────────────────
        if (data.Tables.Contains("IGM"))
        {
            DataTable dt = data.Tables["IGM"];
            RenameColumn(dt, "AIRLINENAME", "IGM_AIRLINENAME");
            RenameColumn(dt, "AIRLINECODE", "IGM_AIRLINECODE");
            RenameColumn(dt, "FLIGHT_INWARD_DATE", "IGM_FLIGHT_VESSELDATE");
            RenameColumn(dt, "MAWB_MBL_NO", "IGM_MAWB_MBL");
            RenameColumn(dt, "MAWB_MBL_DATE", "IGM_MAWB_MBLDATE");
            RenameColumn(dt, "HAWB_HBL_NO", "IGM_HAWB_HBLNO");
            RenameColumn(dt, "HAWB_HBL_DATE", "IGM_HAWB_HBLDATE");
            RenameColumn(dt, "LINE_NUMBER", "IGM_LINE_NUMBER");
            RenameColumn(dt, "SHIPPING_LINE", "IGM_SHIPPING_LINE_NUMBER");
            RenameColumn(dt, "PACKAGES", "IGM_NOOFPACKAGE");
            RenameColumn(dt, "PACKAGE_TYPE", "IGM_PACKAGETYPE");
            RenameColumn(dt, "GROSS_WEIGHT", "IGM_GROSSWEIGHT");
            RenameColumn(dt, "GROSS_WEIGHT_TYPE", "IGM_TYPEOFWEIGHT");
            RenameColumn(dt, "MARKS_NOS", "IGM_MARKSNOS");
            RenameColumn(dt, "VOYAGE", "IGM_VOYAGE");
            RenameColumn(dt, "GATEWAY_IGM_NO", "IGM_GATEWAY_IGM_NO");
            RenameColumn(dt, "GATEWAY_IGM_DATE", "IGM_GATEWAY_IGM_DATE");
            RenameColumn(dt, "GATEWAY_PORT_CODE", "IGM_GATEWAY_PORT_CODE");
            RenameColumn(dt, "CHARGEABLE_WGT", "IGM_CHARGEABLE_WGT");
        }

        // ── CONTAINER ─────────────────────────────────────────────────────────────
        if (data.Tables.Contains("CONTAINER"))
        {
            DataTable dt = data.Tables["CONTAINER"];
            RenameColumn(dt, "IGM_SLNO", "CONTAINER_IGM_SLNO");
            RenameColumn(dt, "IGM_NO", "CONTAINER_IGM_NO");
            RenameColumn(dt, "IGM_DATE", "CONTAINER_IGM_DATE");
        }

        // ── INVOICE ───────────────────────────────────────────────────────────────
        if (data.Tables.Contains("INVOICE"))
        {
            DataTable dt = data.Tables["INVOICE"];
            RenameColumn(dt, "HANDLING_CHARGES", "D_AMOUNT");
            RenameColumn(dt, "LOADING_CHARGES", "M_AMOUNT");
            RenameColumn(dt, "UNLOADING_CHARGES", "N_AMOUNT");
            RenameColumn(dt, "AEO_CODE", "AUTHORIZED_ECONOMIC_OPERATOR_CODE");
            RenameColumn(dt, "AUTH_ECO_OPERATOR", "AUTHORIZED_ECONOMIC_OPERATOR");
            RenameColumn(dt, "BUYER_SELLER_RELATED Y/N", "WHETHER_BUYER_SELLER_RELATED");
        }

        // ── ITEMS ─────────────────────────────────────────────────────────────────
        if (data.Tables.Contains("ITEMS"))
        {
            DataTable dt = data.Tables["ITEMS"];
            RenameColumn(dt, "RITC_NO", "PRODUCT_RITC");
            RenameColumn(dt, "CETH_NO", "PRODUCT_CETH");
            RenameColumn(dt, "BASIC_DUTY_NOTIFICATION", "PRODUCT_BCD_NOTN");
            RenameColumn(dt, "BASIC_DUTY_SLNO", "PRODUCT_BCD_SLNO");
            RenameColumn(dt, "ADD_DUTY_OF_EXCISE_SIA_NOTN", "PRODUCT_ADDL_GSI_NOTN");
            RenameColumn(dt, "ADD_DUTY_OF_EXCISE_SIA_SLNO", "PRODUCT_ADDL_GSI_SLNO");
            RenameColumn(dt, "SPL_EX_DUTY_SHED11_NOTN", "PRODUCT_ADDL_SHEII_NOTN");
            RenameColumn(dt, "SPL_EX_DUTY_SHED11_SLNO", "PRODUCT_ADDL_SHEII_SLNO");
            RenameColumn(dt, "ADD_DUTY_OF_EXCISE_TTA_NOTN", "PRODUCT_ADDL_TTA_NOTN");
            RenameColumn(dt, "ADD_DUTY_OF_EXCISE_TTA_SLNO", "PRODUCT_ADDL_TTA_SLNO");
            RenameColumn(dt, "HEALTH_CESS_NOTN", "PRODUCT_ADDL_HEALTH_CESS_NOTN");
            RenameColumn(dt, "HEALTH_CESS_SLNO", "PRODUCT_ADDL_HEALTH_CESS_SLNO");
            RenameColumn(dt, "EXCEMPTION_NOTN", "IGST_LEVY_EXCEPTION_NOTN");
            RenameColumn(dt, "EXCEMPTION_SLNO", "IGST_LEVY_EXCEPTION_SLNO");
            RenameColumn(dt, "EXCEMPTION_NOTN_TYPE", "LEVY_EXCEMPTION_NOTN_TYPE");
            RenameColumn(dt, "COMPENSATION_CESS_NOTN", "IGST_LEVY_COMPENSATION_CESS_NOTN");
            RenameColumn(dt, "COMPENSATION_CESS_SLNO", "IGST_LEVY_COMPENSATION_CESS_SLNO");
            RenameColumn(dt, "EXCEPTION_CC_NOTN", "IGST_LEVY_EXCEPTION_CC_NOTN");
            RenameColumn(dt, "EXCEPTION_CC_SLNO", "IGST_LEVY_EXCEPTION_CC_SLNO");
            RenameColumn(dt, "EXCEPTION_CC_NOTN_TYPE", "LEVY_EXCEPTION_CC_NOTN_TYPE");
        }
    }

    // ── Safe rename — skips silently if column does not exist ────────────────────
    // Prevents crash when a sheet is missing optional columns
    private void RenameColumn(DataTable dt, string oldName, string newName)
    {
        if (dt.Columns.Contains(oldName))
            dt.Columns[oldName].ColumnName = newName;
    } 

    // ── Extracted helpers ────────────────────────────────────────────────────────

    private string GetGeneralValueNotUsed(string columnName)
    {
        if (data.Tables.Contains("GENERAL") && data.Tables["GENERAL"].Rows.Count > 0)
        {
            object val = data.Tables["GENERAL"].Rows[0][columnName];
            return val == null ? string.Empty : val.ToString();
        }
        return string.Empty;
    }

    protected void btnyes_ClickOld1(object sender, EventArgs e)
    {
        try
        {

            MP_U.Hide();

            string stage = Session["BulkJob_STAGE"] as string;
            //string iec = Session["BulkJob_IEC"] as string;
            //string branch = Session["BulkJob_BRANCH"] as string;
            DataSet ds = Session["BulkJobUploadData"] as DataSet;

            if (ds == null || string.IsNullOrEmpty(stage))
            {
                Alert_msg("Session expired. Please re-upload the file.");
                return;
            }

            if (stage == "CHECK_IMPORTER")
            {
                // Insert importer into master
                string iec = GetValueFromExcel(ds, "GENERAL", "IEC_NO");
                string branch = GetValueFromExcel(ds, "GENERAL", "BRANCH_NO");
                string importerName = ds.Tables["GENERAL"].Rows[0]["IMPORTER_NAME"].ToString();
                string add1 = ds.Tables["GENERAL"].Rows[0]["ADDRESS1"].ToString();
                string add2 = ds.Tables["GENERAL"].Rows[0]["ADDRESS2"].ToString();
                string add3 = ds.Tables["GENERAL"].Rows[0]["ADDRESS3"].ToString();
                string add4 = ds.Tables["GENERAL"].Rows[0]["ADDRESS4"].ToString();
                string add5 = ds.Tables["GENERAL"].Rows[0]["ADDRESS5"].ToString();
                IEC_INSERT_UPDATE(iec, branch, importerName, add1, add2, add3, add4, add5, "PRIVATE", "", "", "T");

                // Now check supplier before proceeding
                string hssIec = ds.Tables["GENERAL"].Rows[0]["HIGH_SEA_IEC"].ToString();
                string hssBranch = ds.Tables["GENERAL"].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString();

                if (!string.IsNullOrWhiteSpace(hssIec) && !string.IsNullOrWhiteSpace(hssBranch))
                {
                    ds_IEC = Get_Importer_HSS_Details(hssIec, hssBranch);
                    if (ds_IEC == null || ds_IEC.Tables.Count == 0 || ds_IEC.Tables[0].Rows.Count == 0)
                    {
                        // Move to next stage — supplier check
                        Session["BulkJob_STAGE"] = "CHECK_SELLER";
                        Session["BulkJob_IEC"] = hssIec;
                        Session["BulkJob_BRANCH"] = hssBranch;

                        lblUser_Msg.Text = "Seller does not exist in the Master. Do you want to add it?";
                        MP_U.Show();
                        return; // wait for supplier confirmation
                    }
                }
            }
            else if (stage == "CHECK_SELLER")
            {
                // Insert supplier into master
                string iec = GetValueFromExcel(ds, "GENERAL", "HIGH_SEA_IEC");
                string branch = GetValueFromExcel(ds, "GENERAL", "HIGH_SEA_BRANCH_SL_NO");
                string hssName = ds.Tables["GENERAL"].Rows[0]["HIGH_SEA_SALE_NAME"].ToString();
                string add1 = ds.Tables["GENERAL"].Rows[0]["HSS_ADD1"].ToString();
                string add2 = ds.Tables["GENERAL"].Rows[0]["HSS_ADD2"].ToString();
                string add3 = ds.Tables["GENERAL"].Rows[0]["HSS_ADD3"].ToString();
                string add4 = ds.Tables["GENERAL"].Rows[0]["HSS_ADD4"].ToString();
                string add5 = ds.Tables["GENERAL"].Rows[0]["HSS_ADD5"].ToString();
                IEC_INSERT_UPDATE(iec, branch, hssName, add1, add2, add3, add4, add5, "PRIVATE", "", "", "T");
            }

            // ── Both checks passed / handled — clear session and proceed to insert ───
            Session.Remove("BulkJob_STAGE");
            Session.Remove("BulkJob_IEC");
            Session.Remove("BulkJob_BRANCH");
            Session.Remove("BulkJobUploadData");

            // use the DS from session — column names already renamed, ready to insert
            data = ds;
            ValidateAndInsert(data);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            if (Session["JOBIDexcel"] != null)
            {
                Session.Remove("JOBIDexcel");
            }
            RollBackSelectedNodes(result);
            Alert_msg("Upload Failed");
        }
    }

    protected void btnyes_Click(object sender, EventArgs e)
    {
        try
        {
            MP_U.Hide();

            string stage = Session["BulkJob_STAGE"] as string;            
            DataSet dsExcel = Session["BulkJobUploadData"] as DataSet;

            if (dsExcel == null || string.IsNullOrEmpty(stage))
            {
                Alert_msg("Session expired. Please re-upload the file.");
                return;
            }

            #region GENERAL

            if (stage == "CHECK_IMPORTER")
            {
                // Insert importer into master
                string importerName = GetValueFromExcel(dsExcel, "GENERAL", "IMPORTER_NAME");
                string iec = GetValueFromExcel(dsExcel, "GENERAL", "IEC_NO");
                string branch = GetValueFromExcel(dsExcel, "GENERAL", "BRANCH_NO");
                string add1 = GetValueFromExcel(dsExcel, "GENERAL", "ADDRESS1");
                string add2 = GetValueFromExcel(dsExcel, "GENERAL", "ADDRESS2");
                string add3 = GetValueFromExcel(dsExcel, "GENERAL", "ADDRESS3");
                string add4 = GetValueFromExcel(dsExcel, "GENERAL", "ADDRESS4");
                string add5 = GetValueFromExcel(dsExcel, "GENERAL", "ADDRESS5");

                string comDetStatus = GetValueFromExcel(dsExcel, "GENERAL", "COMMERCIAL_DETAILS_STATUS");
                string comTaxStatename = GetValueFromExcel(dsExcel, "GENERAL", "COMMERCIAL_TAX_STATENAME");
                string comTaxStatecode = GetValueFromExcel(dsExcel, "GENERAL", "COMMERCIAL_TAX_STATECODE");
                string comTaxType = GetValueFromExcel(dsExcel, "GENERAL", "COMMERCIAL_TAX_TYPE");
                string comTaxRegNo = GetValueFromExcel(dsExcel, "GENERAL", "COMMERCIAL_TAX_REGISTRATION_NO");
                //string gstnType = GetValueFromExcel(data, "GENERAL", "ADDRESS5");
                //string gstnId = GetValueFromExcel(data, "GENERAL", "ADDRESS5");
                string warehouseCode = GetValueFromExcel(dsExcel, "GENERAL", "WAREHOUSE_CODE");
                string paymentMethodCode = GetValueFromExcel(dsExcel, "GENERAL", "PAYMENT_METHOD_CODE");               


                List<string> errors = new List<string>();

                // 1. Check for missing data on single lines
                if (string.IsNullOrWhiteSpace(importerName)) errors.Add("[General] Name is required.");
                if (string.IsNullOrWhiteSpace(iec)) errors.Add("[General] IEC is required.");
                if (string.IsNullOrWhiteSpace(branch)) errors.Add("[General] Branch No required.");
                if (string.IsNullOrWhiteSpace(add1)) errors.Add("[General] Address 1 is required.");
                if (string.IsNullOrWhiteSpace(add3)) errors.Add("[General] Address 3 is required.");
                if (string.IsNullOrWhiteSpace(comTaxStatename)) errors.Add("[General] State Name is required.");


                if (comTaxStatecode != "")
                {
                    if (comTaxStatecode.Contains('-'))
                    {
                        string[] p = comTaxStatecode.Split('-');
                        string p1 = p[0];
                        string p2 = p[1];

                        comTaxStatename = p2.Trim();
                        comTaxStatecode = p1.Trim();
                    }
                }

                // 2. Check lengths only if the fields actually have data
                if (!string.IsNullOrWhiteSpace(comTaxStatecode) && comTaxStatecode.Length > 2) errors.Add("[General] Country Code must be 2 characters.");
                

                // 3. Process the final result
                if (errors.Count > 0)
                {
                    Alert_msg(string.Join(" ", errors));
                    return;
                }
                else
                {
                    ImporterInsert(iec, branch, importerName, add1, add2, add3, add4, add5, comDetStatus, comTaxStatename, comTaxStatecode, comTaxType, comTaxRegNo, warehouseCode);
                }


                // Now check supplier before proceeding
                string hssIec = GetValueFromExcel(dsExcel, "GENERAL", "HIGH_SEA_IEC");
                string hssBranch = GetValueFromExcel(dsExcel, "GENERAL", "HIGH_SEA_BRANCH_SL_NO"); 

                if (!string.IsNullOrWhiteSpace(hssIec) && !string.IsNullOrWhiteSpace(hssBranch))
                {
                    ds_IEC = new DataSet();
                    ds_IEC = Get_Importer_HSS_Details(hssIec, hssBranch);
                    if (ds_IEC == null || ds_IEC.Tables.Count == 0 || ds_IEC.Tables[0].Rows.Count == 0)
                    {
                        //// Move to next stage — supplier check
                        //Session["BulkJob_STAGE"] = "CHECK_SELLER";                       

                        //lblUser_Msg.Text = "Seller does not exist in the Master. Do you want to add it?";
                        //MP_U.Show();

                        Alert_msg("[General] Seller not available please add in master and retry");
                        return; // wait for supplier confirmation
                    }
                }
            }
            else if (stage == "CHECK_SELLER")
            {
                // Insert supplier into master
                string hssName = GetValueFromExcel(dsExcel, "GENERAL", "HIGH_SEA_SALE_NAME");
                string hssIec = GetValueFromExcel(dsExcel, "GENERAL", "HIGH_SEA_IEC");
                string hssBranch = GetValueFromExcel(dsExcel, "GENERAL", "HIGH_SEA_BRANCH_SL_NO");
                string add1 = GetValueFromExcel(dsExcel, "GENERAL", "HSS_ADD1");
                string add2 = GetValueFromExcel(dsExcel, "GENERAL", "HSS_ADD2");
                string add3 = GetValueFromExcel(dsExcel, "GENERAL", "HSS_ADD3");
                string add4 = GetValueFromExcel(dsExcel, "GENERAL", "HSS_ADD4");
                string add5 = GetValueFromExcel(dsExcel, "GENERAL", "HSS_ADD5");
                ImporterInsert(hssIec, hssBranch, hssName, add1, add2, add3, add4, add5, "", "", "","", "", "");

            }

            #endregion

            #region INVOICE 

            if (stage == "CHECK_THIRDPARTY")
            {
                // Insert supplier into master
                string tName = GetValueFromExcel(dsExcel, "INVOICE", "THIRDPARTY_NAME");
                string tAdd1 = GetValueFromExcel(dsExcel, "INVOICE", "THIRDPARTY_ADD1");
                string tAdd2 = GetValueFromExcel(dsExcel, "INVOICE", "THIRDPARTY_ADD2");
                string tCity = GetValueFromExcel(dsExcel, "INVOICE", "THIRDPARTY_CITY");
                string tSubDiv = GetValueFromExcel(dsExcel, "INVOICE", "T_PARTY_COUNTRY_SUB_DIV");
                string tCountryCode = GetValueFromExcel(dsExcel, "INVOICE", "T_PARTY_COUNTRY_CODE");
                string tPin = GetValueFromExcel(dsExcel, "INVOICE", "T_PARTY_PIN");
                string terms = GetValueFromExcel(dsExcel, "INVOICE", "TERMS_PLACE");
                string aeoCode = GetValueFromExcel(dsExcel, "INVOICE", "AUTHORIZED_ECONOMIC_OPERATOR_CODE");
                string aeoCountry = GetValueFromExcel(dsExcel, "INVOICE", "AEO_COUNTRY");
                string aeo = GetValueFromExcel(dsExcel, "INVOICE", "AUTHORIZED_ECONOMIC_OPERATOR");
                string bsRealated = GetValueFromExcel(dsExcel, "INVOICE", "WHETHER_BUYER_SELLER_RELATED");
                

                List<string> errors = new List<string>();

                // 1. Check for missing data on single lines
                if (string.IsNullOrWhiteSpace(tName)) errors.Add("[Invoice] Name is required.");
                if (string.IsNullOrWhiteSpace(tAdd1)) errors.Add("[Invoice] Address 1 is required.");
                //if (string.IsNullOrWhiteSpace(tAdd2)) errors.Add("Address 2 is required.");
                //if (string.IsNullOrWhiteSpace(tCity)) errors.Add("City is required.");
                //if (string.IsNullOrWhiteSpace(tSubDiv)) errors.Add("Sub Division is required.");
                //if (string.IsNullOrWhiteSpace(tCountryCode)) errors.Add("Country Code is required.");
                //if (string.IsNullOrWhiteSpace(aeoCountry)) errors.Add("AEO Country is required.");

                // 2. Check lengths only if the fields actually have data
                if (!string.IsNullOrWhiteSpace(tCountryCode) && tCountryCode.Length > 2) errors.Add("[Invoice] Country Code must be 2 characters.");
                //if (!string.IsNullOrWhiteSpace(aeoCountry) && aeoCountry.Length > 2) errors.Add("AEO Country must be 2 characters.");
                
               

                // 3. Process the final result
                if (errors.Count > 0)
                {
                    Alert_msg(string.Join(" ", errors));
                    return;
                }
                else
                {
                    ThirdPartyInsert(tName, tAdd1, tAdd2, tCity, tSubDiv, tCountryCode, tPin, terms, aeoCode, aeoCountry, aeo, bsRealated);
                }


                //var thirdPartyFields = new[] { tName, tAdd1, tAdd2, tCity, tSubDiv, tCountryCode };

                //if (thirdPartyFields.All(field => !string.IsNullOrWhiteSpace(field)) && tCountryCode.Length <= 2 && aeoCountry.Length <= 2)
                //{
                //    Alert_msg("Please enter valid Name,Ad1,Add2,City,Sub Div,Country Code.");
                //    return;
                //}
                //else
                //{
                //    ThirdPartyInsert();
                //}
                

            }
            else if (stage == "CHECK_SUPPLIER")
            {
                // Insert supplier into master
                string sName = GetValueFromExcel(dsExcel, "INVOICE", "SUPPLIER_NAME");
                string sAdd = GetValueFromExcel(dsExcel, "INVOICE", "SUPPLIER_ADDRESS");
                string sAdd1 = GetValueFromExcel(dsExcel, "INVOICE", "SUPPLIER_ADDRESS1");
                string sAdd2 = GetValueFromExcel(dsExcel, "INVOICE", "SUPPLIER_ADDRESS2");
                string sCountry = GetValueFromExcel(dsExcel, "INVOICE", "SUPPLIER_COUNTRY_NAME");
                string sCountryCode = GetValueFromExcel(dsExcel, "INVOICE", "SUPPLIER_COUNTRY_CODE");
                string sPin = GetValueFromExcel(dsExcel, "INVOICE", "SUPPLIER_COUNTRY_PINCODE");             


                List<string> errors = new List<string>();

                // 1. Check for missing data on single lines
                if (string.IsNullOrWhiteSpace(sName)) errors.Add("[Invoice] SUPPLIER_NAME is required.");
                if (string.IsNullOrWhiteSpace(sAdd)) errors.Add("[Invoice] SUPPLIER_ADDRESS  is required.");
                //if (string.IsNullOrWhiteSpace(sCountry)) errors.Add("SUPPLIER_COUNTRY_NAME is required."); 
                //// 2. Check lengths only if the fields actually have data
                //if (!string.IsNullOrWhiteSpace(sCountryCode) && sCountryCode.Length > 2) errors.Add("Country Code must be 2 characters.");                

                // 2. Core check: Verify if the country name is missing
                if (string.IsNullOrWhiteSpace(sCountry))
                {
                    errors.Add("[Invoice] SUPPLIER_COUNTRY_NAME is required.");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(sCountry) && (string.IsNullOrWhiteSpace(sCountryCode) || sCountryCode.Length > 2))
                    {
                        errors.Add("[Invoice] SUPPLIER_COUNTRY_CODE is required and must be 2 characters or less.");
                    }
                }


                // 3. Process the final result
                if (errors.Count > 0)
                {
                    Alert_msg(string.Join(" ", errors));
                    return;
                }
                else
                {
                    SupplierInsert(sName, sAdd, sAdd1, sAdd2, sCountry, sCountryCode, sPin);
                }

            }


            #endregion

            // ── Both checks passed / handled — clear session and proceed to insert ───
            Session.Remove("BulkJob_STAGE");            
            Session.Remove("BulkJobUploadData");

            // use the DS from session — column names already renamed, ready to insert
            data = dsExcel;
            ValidateAndInsert(data);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            if (Session["JOBIDexcel"] != null)
            {
                Session.Remove("JOBIDexcel");
            }
            //RollBackSelectedNodes(result); 
            ManualRollBack();
            Alert_msg("Upload Failed");
        }
    }

    private string GetValueFromExcel(DataSet dsExcel, string table, string columnName)
    {
        if (dsExcel != null && dsExcel.Tables.Contains(table) &&
            dsExcel.Tables[table].Rows.Count > 0 &&
            dsExcel.Tables[table].Columns.Contains(columnName))
        {
            return Convert.ToString(dsExcel.Tables[table].Rows[0][columnName]);
        }

        return "";
    }
        
    public void ImporterInsert(string IECNO_, string BRNO_, string IEC_NAME_, string ADD1_, string ADD2_, string ADD3_, string ADD4_, string ADD5_, string COM_DET_STATUS_, string COM_TAX_STATENAME_,string COM_TAX_STATECODE_, string COM_TAX_TYPE_, string COM_TAX_REG_NO_, string WAREHOUSE_CODE_)
    {

        ObjGV.A1 = "";                           // IMP_EXP_ID
        ObjGV.A2 = IEC_NAME_;                         // IMP_EXP_NAME
        ObjGV.A3 = IECNO_;                        // IMP_EXP_IECNO
        ObjGV.A4 = BRNO_;                       // IMP_EXP_BRSLNO
        ObjGV.A5 = "PRIVATE";                         // IMP_EXP_TYPE
        ObjGV.A6 = ADD1_;                         // IMP_EXP_ADD1
        ObjGV.A7 = ADD2_;                         // IMP_EXP_ADD2
        ObjGV.A8 = ADD3_;                         // IMP_EXP_ADD3
        ObjGV.A9 = ADD4_;                         // IMP_EXP_ADD4
        ObjGV.A10 = ADD5_;                    // IMP_EXP_PIN_CODE
        ObjGV.A11 = "";              // IMP_EXP_CONTACT_PERSON
        ObjGV.A12 = "";                       // IMP_EXP_PHONE
        ObjGV.A13 = "";                       // IMP_EXP_EMAIL
        ObjGV.A14 = "";                       // IMP_EXP_BINNO
        ObjGV.A15 = "";                     // IMP_EXP_REMARKS
        ObjGV.A16 = "";              // IMP_EXP_DRAWBACK_AC_NO
        ObjGV.A17 = "";                      // IMP_EXP_PAN_NO
        //ObjGV.A18 = "";                       // STANDARD_TYPE
        ObjGV.A19 = "";                              // TIN_NO
        ObjGV.A20 = COM_TAX_STATECODE_;                          // STATE_CODE
        ObjGV.A21 = "";                         // IMP_EXP_FAX
        ObjGV.A22 = "";                          // EXP_STR_YN
        ObjGV.A23 = "";                    // TYPE_OF_EXPORTER
        ObjGV.A24 = "";                            // MARKS_NO
        ObjGV.A25 = COM_DET_STATUS_;           // COMMERCIAL_DETAILS_STATUS
        ObjGV.A26 = COM_TAX_STATENAME_;            // COMMERCIAL_TAX_STATENAME
        ObjGV.A27 = COM_TAX_STATECODE_;            // COMMERCIAL_TAX_STATECODE
        ObjGV.A28 = COM_TAX_TYPE_;                 // COMMERCIAL_TAX_TYPE
        ObjGV.A29 = COM_TAX_REG_NO_;      // COMMERCIAL_TAX_REGISTRATION_NO
        ObjGV.A30 = GSTN_TYPE;                           // GSTN_TYPE
        ObjGV.A31 = GSTN_ID;                             // GSTN_ID
        ObjGV.A32 = "";                            // DISTRICT
        ObjGV.A33 = "";                    // EXP_DBK_DECL_CHK
        ObjGV.A34 = "";                      // SEZ_ICEGATE_ID
        ObjGV.A35 = "";                          // SEZ_PAN_NO
        ObjGV.A36 = "";                           // SEZ_AP_ID
        ObjGV.A37 = "";                         // SEZ_AP_NAME
        ObjGV.A38 = WAREHOUSE_CODE_;                      // WAREHOUSE_CODE
        ObjGV.A39 = "T";                 // PAYMENT_METHOD_CODE
        ObjGV.A40 = "";                        // ITEM_END_USE
        ObjGV.A41 = "";               // CLIENT_INSURANCE_RATE
        ObjGV.A42 = "";                          // TAN_NUMBER
        ObjGV.A43 = "";                            // TDS_CODE
        ObjGV.A44 = "";                            // TDS_RATE
        ObjGV.A45 = "";                     // NATURE_OF_TRANS
        ObjGV.A46 = "";                   // NATURE_OF_PAYMENT
        ObjGV.A47 = "";                    // VALUATION_METHOD

        /*
        // Customer
        ObjGV.A48 = A_C_CREDITLIMIT;
        ObjGV.A49 = A_C_CUR;
        CM.A_C_UNLIMITED = A_C_UNLIMITED;
        CM.A_C_COD = A_C_COD;
        CM.A_C_CHK_OVERDUE = A_C_CHK_OVERDUE;
        ObjGV.A50 = A_C_OVERDUE_RESTRICTION;
        CM.CHECK_CREDITONHOLD = A_C_CHK_CRD_HOLD;
        ObjGV.A51 = A_C_CREDITONHOLD;
        ObjGV.A52 = A_C_REC_CRE_PERIOD_DDL;
        ObjGV.A53 = A_C_REC_CRE_PERIOD_DAYS;
        ObjGV.A54 = A_C_CUSTOMER_GL;
        ObjGV.A55 = A_C_NOT_EMAIL;
        CM.Check_OptionalCriteria = A_C_CHK_OPT_CRITERIA;
        ObjGV.A56 = A_C_REC_DDL;
        ObjGV.A57 = A_C_REC_NO_DAYS;
        ObjGV.A58 = A_C_REC_TXTBOX;
        ObjGV.A59 = A_C_CUR2;

        // Vendor
        CM.CHK_Vendor_CLimit = A_V_UNLIMITED;
        ObjGV.A60 = A_V_CREDITLIMIT;
        ObjGV.A61 = A_V_CUR;
        ObjGV.A62 = A_V_PAY_CRE_PERIOD_DDL;
        ObjGV.A63 = A_V_PAY_CRE_PERIOD_TXT;
        ObjGV.A64 = A_V_DUEDATE_CAL;
        ObjGV.A65 = A_V_CUR2;
        ObjGV.A66 = A_V_VENDORGL;
        ObjGV.A67 = A_V_NOTIFIC_MAIL;
        CM.CHK_PaymentHold = A_V_PAYMENT_CHK;
        ObjGV.A68 = A_V_PAYMENTON_HOLD;

        // TDS
        ObjGV.A69 = A_T_FISCALYEAR;
        ObjGV.A70 = A_T_ORG_TYPE;
        CM.CHK_SpecifiedPerson = A_T_SPC_PERSON;
        ObjGV.A71 = A_T_TDS_RECEIVABLE;
        ObjGV.A72 = A_C_Code;
        ObjGV.A73 = A_V_Code; */

        // Flags
        ObjGV.A200 = "S";
        ObjGV.A201 = "";
        ds = CM.Imp_Exp_Master_Insert_update_STD(ObjGV);
    }

    public int ThirdPartyInsert(string tName, string tAdd1, string tAdd2, string tCity,string tSubDiv, string tCountryCode, string tPin, string terms, string aeoCode, string aeoCountry, string aeo, string bsRealated)
    {       
        
            erm.THIRDPARTY_ID = "";
            erm.THIRDPARTY_NAME = tName;
            erm.THIRDPARTY_ADD1 = tAdd1;
            erm.THIRDPARTY_ADD2 = tAdd2;
            erm.THIRDPARTY_CITY = tCity;
            erm.THIRDPARTY_COUNTRY_SUBDIVISION = tSubDiv;
            erm.THIRDPARTY_COUNTRY_CODE = tCountryCode;
            erm.TERMS_PLACE = terms;
            erm.THIRDPARTY_PIN = tPin;
            erm.AEO_CODE = aeoCode;
            erm.AEO_COUNTRY = aeoCountry;
            erm.AEO_ROLE = aeo;
            erm.BUYER_RELATED_Y_N = bsRealated;

            erm.USER_ID = currentuser;
            erm.BRANCH_CODE = currentbranch;
            erm.flag = "S";
            erm.EWorking_Period = Working_Period;

            i = erm.Import_ThirdParty_Master_Insert_update();
        

        return i;
    }

    private void ValidateAndInsert(DataSet ds)
    {
        //VALIDATION
        int status = ValidateAll(ds);

        //if (allErrors.Rows.Count > 0)
        //{
        //    gv_Item_Details.DataSource = allErrors;
        //    gv_Item_Details.DataBind();
        //    //Result = 0;
        //}
        //else
        //{

        #region Transport mode        

        // General sheet available?
        if (ds.Tables.Contains("GENERAL") &&  ds.Tables["GENERAL"] != null &&  ds.Tables["GENERAL"].Rows.Count > 0)
        {
            generalTransportMode = Convert.ToString(ds.Tables["GENERAL"].Rows[0]["TRANSPORT_MODE"]);
        }
        else
        {
            // Update scenario
            generalTransportMode = Convert.ToString(Session["Transport_Mode_Port"]);
        }

        #endregion


        // tableActions loop
            var tableActions = new Dictionary<string, Action<DataTable>>
         {
             { "GENERAL",        dt => Read_General_Details(dt) },
             { "IGM",            dt => Read_IGM_Details(dt) },
             { "CONTAINER",      dt => Read_Container_Details(dt) },
             { "INVOICE",        dt => Read_Invoice_Details(dt) },
             { "ITEMS",          dt => Read_Item_Details(dt) },
             { "RE_IMPORT",      dt => Read_Reimport_Details(dt) },
             { "SW_INFO_TYPE",   dt => Read_SW_Info(dt) },
             { "SW_CONSTITUENT", dt => Read_SW_Constituent(dt) },
             { "SW_PRODUCTION",  dt => Read_SW_Production(dt) },
             { "SW_CONTROL",     dt => Read_SW_Control(dt) },
             { "LICENSE",        dt => Read_License_Details(dt) },
             { "BONDS",          dt => Read_Bond_Details(dt) },
             { "CERTIFICATES",   dt => Read_Certificate_Details(dt) },
             { "SUPPORTING_DOCS",dt => Read_Suporting_Documents_Details(dt) }
         };

            DataSet excelDS = ds.Copy();
            foreach (DataTable table in excelDS.Tables)
            {
                if (tableActions.ContainsKey(table.TableName))
                {
                    var rows = table.Rows.Cast<DataRow>()
                                   .Where(row => !row.ItemArray.All(f => f == DBNull.Value));
                    if (rows.Any())
                    {
                        DataTable dtFinal = rows.CopyToDataTable();
                        if (dtFinal.Rows.Count > 0)
                            tableActions[table.TableName](dtFinal);
                    }
                }
            }
            excelDS.Dispose();
            excelDS = null;

            if (allErrors.Rows.Count > 0)
            {
                gv_Item_Details.DataSource = allErrors;
                gv_Item_Details.DataBind();
                //RollBackSelectedNodes(result);
                allErrors = new DataTable();
                Result = 0;
                ManualRollBack();
            }
            else
            {
                SqlBulkUpload_Job(ds);
                allErrors = new DataTable();
            }
        //}
    }

    public DataSet Get_ThirdParty_Details(string ThirdPartyName)
    {
        erm.Ebuyerid = "0";
        erm.Ebuyer_name = ThirdPartyName;
        erm.Ename = "Check_THIRDPARTY_NAME";
        erm.EWorking_Period = Working_Period;

        DataSet dsThirdParty = erm.RetrieveAll_Imp_ThirdParty_MASTER();
        //if (dtThirdParty.Tables[0].Rows.Count > 0)
        //{
        //}
        return dsThirdParty;
    }

    public DataSet Get_Supplier_Details(string SupplierName)
    {
        erm.Esupid = "0";
        erm.Esup_name = SupplierName;
        erm.Ename = "Get_Sup_Name_GMMCO";
        erm.EWorking_Period = Working_Period;
        ds_supplier = erm.RetrieveAll_Supplier_MASTER();
        //if (ds_supplier.Tables[0].Rows.Count > 0)
        //{   
        //}
        return ds_supplier;
    }
    public int SupplierInsert(string sName, string sAdd, string sAdd1, string sAdd2, string sCountry, string sCountryCode, string sPin)
    {
        erm.SUP_ID = "0";
        erm.SUP_NAME = sName;
        erm.SUP_BRANCH_SLNO = "0";
        erm.SUP_ADD1 = sAdd;
        erm.SUP_ADD2 = sAdd1;
        erm.SUP_ADD3 = sAdd2;
        erm.SUP_COUNTRY_CODE = sCountryCode;
        erm.SUP_COUNTRY_NAME = sCountry;
        erm.SUP_PIN_CODE = sPin;
        erm.SUP_REMARKS = "";

        erm.USER_ID = Connection.Current_User();
        erm.BRANCH_CODE = Connection.Current_Branch();
        erm.flag = "S";
        erm.YEAR = "";
        erm.EWorking_Period = Working_Period;

        i = erm.Supplier_Master_Insert_update();

        return i;
    }

    
    public void License_Excel_UploadOld(DataTable sourceTable)
    {
        // ── Step 1: Validate INVOICE_SLNO / ITEM_SLNO exist in DB ───────────────
        // Original: Get_LICENSE_IMP_EXP_MaxID() + ViewState read + validate_invoice_item SP
        int License_id_Max = Get_LICENSE_IMP_EXP_MaxID();

        // Original: Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"]
        // Now: caller passes the DataTable directly — wrap in DataSet to preserve
        // all downstream logic that reads Inv_ds.Tables[0]
        DataSet Inv_ds = new DataSet();
        Inv_ds.Tables.Add(sourceTable.Copy());
        ds = Inv_ds;

        // ── Step 2: Build XML of INVOICE_SLNO + ITEM_SLNO for SP validation ──────
        // Original: DataView → distinct table → ConvertDataTableToXML
        DataView dv = Inv_ds.Tables[0].DefaultView;
        DataTable dat = dv.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO");

        Transact.xmlString = ConvertDataTableToXML(dat);
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.BRANCH_CODE = Connection.Current_Branch();
        Transact.Ename = "validate_invoice_item";

        DataSet dtxl = Transact.Import_Bulk_License_Select();

        //// ── Step 3: SP returned mismatched rows → show mismatch grid and exit ────
        //// Original: if (dtxl.Tables[0].Rows.Count > 0) → show gv_Preview + return
        //if (dtxl.Tables[0].Rows.Count > 0)
        //{
        //    Main_Grid.Visible = true;
        //    gv_Preview.DataSource = dtxl;
        //    gv_Preview.DataBind();
        //    Label12.Text = "Import Bulk License Excel mismatched entries for Job No: "     + IMPORT_JOBNO;
        //    return;
        //}

        // SP returned mismatched Invoice/Item combinations
        if (dtxl != null && dtxl.Tables.Count > 0 && dtxl.Tables[0] != null && dtxl.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in dtxl.Tables[0].Rows)
            {
                AddError("LICENSE","Invoice/Item combination does not exist for the selected Job.","INVOICE_SLNO / ITEM_SLNO","Invoice : " + dr["INVOICE_SLNO"] + ", Item : " + dr["ITEM_SLNO"]);
            }                        
            //Label12.Text = "Import Bulk License Excel mismatched entries for Job No: " + IMPORT_JOBNO;
            //return;
        }

        // ── Step 4: SP returned no mismatches → run field-level validation ────────
        // Original: build error DataTable, loop Inv_ds.Tables[0].Rows, Regex checks
        //DataTable errorTable = BuildValidationErrors(Inv_ds.Tables[0]);
        BuildValidationErrors(Inv_ds.Tables[0]);

        //// ── Step 5: Validation errors found → show error grid and exit ────────────
        //// Original: if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "0") → show + return
        //if (errorTable.Rows.Count > 0 && errorTable.Rows[0][0].ToString() != "0")
        //{
        //    Main_Grid.Visible = true;
        //    gv_Preview.DataSource = errorTable;
        //    gv_Preview.DataBind();
        //    Label12.Text = "Import Bulk License Excel Invalid Errors";
        //    return;
        //}

        // ── Step 6: No errors → build dsXML and insert ───────────────────────────
        // Original: ds.Tables[0].Rows.Add() sentinel row + check Rows.Count > a (0)
        ds.Tables[0].Rows.Add(); // sentinel blank row — preserves original loop termination logic

        if (ds.Tables[0].Rows.Count <= 0)
            return; // original: if (ds.Tables[0].Rows.Count > a) where a=0

        // ── Step 6a: Read header values from first row ────────────────────────────
        // Original: code/notification/slno/item_slno/invoice_no from Rows[0]
        string code = ds.Tables[0].Rows[0][4].ToString();
        string notification = ds.Tables[0].Rows[0][5].ToString();
        string slno = ds.Tables[0].Rows[0][6].ToString();
        string item_slno = ds.Tables[0].Rows[0][0].ToString();
        string invoice_no = ds.Tables[0].Rows[0][1].ToString();

        // ── Step 6b: Build dsXML schema ──────────────────────────────────────────
        // Original: dsXML.Tables.Add + Columns.Add for LICENSE_DETAILS + ITEM_PRODUCT_DETAILS
        BuildDsXmlSchema();

        // ── Step 6c: File type check — original: if (file_ext == ".xls" || ".xlsx")
        // Since caller now passes a DataTable (already parsed from Excel), we always
        // enter the Excel branch. The else branch ("license sl number mismatch" alert)
        // is preserved below for safety but never reached via this path.
        bool isExcelSource = true; // always true — DataTable was read from Excel by caller

        if (isExcelSource)
        {
            // ── Step 6d: Populate LICENSE_DETAILS rows ────────────────────────────
            // Original: int a=0; while (ds.Tables[0].Rows[a][0] != DBNull.Value)
            int a = 0;
            while (a < ds.Tables[0].Rows.Count  && ds.Tables[0].Rows[a][0] != DBNull.Value)
            {
                DataRow srcRow = ds.Tables[0].Rows[a];
                DataRow licRow = dsXML.Tables[0].NewRow();

                licRow["LICENSE_ID"] = License_id_Max;
                licRow["JOBNO"] = IMPORT_JOBNO;
                licRow["INVOICE_SLNO"] = srcRow[0].ToString();
                licRow["ITEM_SLNO"] = srcRow[1].ToString().TrimEnd();
                licRow["EXCEMPTION"] = "Y";
                licRow["REGISTRATION_NO"] = srcRow[2].ToString().TrimEnd();
                licRow["REGISTRATION_DATE"] = srcRow[3].ToString().TrimEnd();
                licRow["SCHEME_CODE"] = srcRow[4].ToString().TrimEnd();
                licRow["LICENSE_ITEM_NO"] = srcRow[7].ToString();
                licRow["LICENSE_SLNO"] = a + 1;          // original: ii, incremented each loop
                licRow["DEBIT_QTY"] = srcRow[8].ToString();
                licRow["UNIT_QTY"] = srcRow[9].ToString();
                licRow["PORT_OF_LICENSE"] = srcRow[10].ToString();
                licRow["LIC_DESC"] = srcRow[11].ToString();
                licRow["LICENSE_NO"] = srcRow[12].ToString().TrimEnd();

                // Original: if licDate empty → "1900-01-01 00:00:00.000" else use value
                string licDate = srcRow[13].ToString().Trim();
                licRow["LICENSE_DATE"] = string.IsNullOrWhiteSpace(licDate) ? "1900-01-01 00:00:00.000": licDate;

                licRow["DEBIT_CIF_AMT"] = srcRow[14].ToString().TrimEnd();
                licRow["ENTRY_DEBIT_DUTY"] = srcRow[15].ToString().TrimEnd();
                licRow["USER_ID"] = currentuser;
                licRow["DATE_TIME"] = LoginDate;
                licRow["STATUS"] = "N";
                licRow["BRANCH_CODE"] = currentbranch;
                licRow["YEAR"] = "";
                licRow["WORKING_PERIOD"] = Working_Period;
                licRow["MODIFIEDBY"] = currentuser;
                licRow["MODIFIEDON"] = LoginDate;

                a++;
                License_id_Max++;
                dsXML.Tables[0].Rows.Add(licRow);
            }

            // ── Step 6e: Populate ITEM_PRODUCT_DETAILS rows ───────────────────────
            // Original: int b=0; while (ds.Tables[0].Rows[b][0] != DBNull.Value)
            int b = 0;
            while (b < ds.Tables[0].Rows.Count  && ds.Tables[0].Rows[b][0] != DBNull.Value)
            {
                DataRow srcRow = ds.Tables[0].Rows[b];
                DataRow itemRow = dsXML.Tables[1].NewRow();

                itemRow["JOBNO"] = IMPORT_JOBNO;
                //itemRow["ITEM_ID"] = ITEM_ID;
                itemRow["INVOICE_SLNO"] = srcRow[0].ToString();
                itemRow["ITEM_SLNO"] = srcRow[1].ToString().TrimEnd();
                itemRow["SCHEME_CODE"] = srcRow[4].ToString();
                itemRow["SCHEME_NOTN"] = srcRow[5].ToString();
                itemRow["SCHEME_NOTN_SLNO"] = srcRow[6].ToString();
                itemRow["USER_ID"] = currentuser;
                itemRow["DATE_TIME"] = LoginDate;
                itemRow["STATUS"] = "N";
                itemRow["BRANCH_CODE"] = currentbranch;
                itemRow["YEAR"] = "";
                itemRow["WORKING_PERIOD"] = Working_Period;
                itemRow["MODIFIEDBY"] = currentuser;
                itemRow["MODIFIEDON"] = LoginDate;

                b++;
                //ITEM_ID++;
                dsXML.Tables[1].Rows.Add(itemRow);
            }

            // ── Step 6f: Bulk insert LICENSE_DETAILS if rows exist ────────────────
            // Original: if (dsXML.Tables[0].Rows.Count > 0) → delete existing → bulk insert
            if (dsXML.Tables[0].Rows.Count > 0)
            {
                Transact.JOBNO = IMPORT_JOBNO;
                Transact.INVOICE_SLNO = invoice_no;
                Transact.ITEM_SLNO = item_slno;
                Transact.BRANCH_CODE = Connection.Current_Branch();
                Transact.Ename = "License_details_delete";
                ds = Transact.Import_Bulk_License_Select(); // delete existing records

                admin.SqlBulk_Upload_Product("LICENSE_DETAILS",dsXML.Tables[0],Session["currentcomp_db"].ToString());
            }

            // ── Step 6g: Update ITEM_PRODUCT_DETAILS if rows exist ────────────────
            // Original: if (dsXML.Tables[1].Rows.Count > 0) → set Transact fields → call SP
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
            }

            Alert_msg("Uploaded Successfully..");
        }
        else
        {
            // Original else: "license sl number mismatch"
            // Preserved — unreachable via DataTable path but kept for completeness
            Alert_msg("license sl number mismatch");
        }
    }
    public void License_Excel_UploadOld1(DataTable sourceTable)
    {
        // ── Step 1: Validate INVOICE_SLNO / ITEM_SLNO exist in DB ───────────────
        // Original: Get_LICENSE_IMP_EXP_MaxID() + ViewState read + validate_invoice_item SP
        //int License_id_Max = Get_LICENSE_IMP_EXP_MaxID();

        // Original: Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"]
        // Now: caller passes the DataTable directly — wrap in DataSet to preserve
        // all downstream logic that reads Inv_ds.Tables[0]
        DataSet Inv_ds = new DataSet();
        Inv_ds.Tables.Add(sourceTable.Copy());
        ds = Inv_ds;

        // ── Step 2: Build XML of INVOICE_SLNO + ITEM_SLNO for SP validation ──────
        // Original: DataView → distinct table → ConvertDataTableToXML
        DataView dv = Inv_ds.Tables[0].DefaultView;
        DataTable dat = dv.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO");

        Transact.xmlString = ConvertDataTableToXML(dat);
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.BRANCH_CODE = Connection.Current_Branch();
        Transact.Ename = "validate_invoice_item";

        DataSet dtxl = Transact.Import_Bulk_License_Select();

        //// ── Step 3: SP returned mismatched rows → show mismatch grid and exit ────
        //// Original: if (dtxl.Tables[0].Rows.Count > 0) → show gv_Preview + return
        //if (dtxl.Tables[0].Rows.Count > 0)
        //{
        //    Main_Grid.Visible = true;
        //    gv_Preview.DataSource = dtxl;
        //    gv_Preview.DataBind();
        //    Label12.Text = "Import Bulk License Excel mismatched entries for Job No: "     + IMPORT_JOBNO;
        //    return;
        //}

        // SP returned mismatched Invoice/Item combinations
        if (dtxl != null && dtxl.Tables.Count > 0 && dtxl.Tables[0] != null && dtxl.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in dtxl.Tables[0].Rows)
            {
                AddError("LICENSE", "Invoice/Item combination does not exist for the selected Job.", "INVOICE_SLNO / ITEM_SLNO", "Invoice : " + dr["INVOICE_SLNO"] + ", Item : " + dr["ITEM_SLNO"]);
            }
            //Label12.Text = "Import Bulk License Excel mismatched entries for Job No: " + IMPORT_JOBNO;
            //return;
        }

        // ── Step 4: SP returned no mismatches → run field-level validation ────────
        // Original: build error DataTable, loop Inv_ds.Tables[0].Rows, Regex checks
        //DataTable errorTable = BuildValidationErrors(Inv_ds.Tables[0]);
        BuildValidationErrors(Inv_ds.Tables[0]);

        //// ── Step 5: Validation errors found → show error grid and exit ────────────
        //// Original: if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "0") → show + return
        //if (errorTable.Rows.Count > 0 && errorTable.Rows[0][0].ToString() != "0")
        //{
        //    Main_Grid.Visible = true;
        //    gv_Preview.DataSource = errorTable;
        //    gv_Preview.DataBind();
        //    Label12.Text = "Import Bulk License Excel Invalid Errors";
        //    return;
        //}

        //──────────────────────────────────────────────────────────────────────────────
        // Step 6 : Build dsXML and Insert
        //──────────────────────────────────────────────────────────────────────────────

        //if (ds == null || ds.Tables.Count == 0 || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
        //{
        //    return;
        //}

        //// First row values (preserved from original logic)
        //DataRow firstRow = ds.Tables[0].Rows[0];

        //string code = firstRow[4].ToString();
        //string notification = firstRow[5].ToString();
        //string slno = firstRow[6].ToString();
        //string invoice_no = firstRow[0].ToString();
        //string item_slno = firstRow[1].ToString();

        // Build XML schema
        BuildDsXmlSchema();

        int licenseSlNo = 1;

        int License_id_Max = Get_LICENSE_IMP_EXP_MaxID();

        foreach (DataRow srcRow in ds.Tables[0].Rows)
        {
            //---------------------------------------
            // LICENSE_DETAILS
            //---------------------------------------

            DataRow licRow = dsXML.Tables[0].NewRow();

            licRow["LICENSE_ID"] = License_id_Max;
            licRow["JOBNO"] = IMPORT_JOBNO;
            licRow["INVOICE_SLNO"] = srcRow[0].ToString();
            licRow["ITEM_SLNO"] = srcRow[1].ToString().Trim();
            licRow["EXCEMPTION"] = "Y";
            licRow["REGISTRATION_NO"] = srcRow[2].ToString().Trim();
            licRow["REGISTRATION_DATE"] = srcRow[3].ToString().Trim();
            licRow["SCHEME_CODE"] = srcRow[4].ToString().Trim();
            licRow["LICENSE_ITEM_NO"] = srcRow[7].ToString();
            licRow["LICENSE_SLNO"] = licenseSlNo;
            licRow["DEBIT_QTY"] = srcRow[8].ToString();
            licRow["UNIT_QTY"] = srcRow[9].ToString();
            licRow["PORT_OF_LICENSE"] = srcRow[10].ToString();
            licRow["LIC_DESC"] = srcRow[11].ToString();
            licRow["LICENSE_NO"] = srcRow[12].ToString().Trim();

            string licDate = srcRow[13].ToString().Trim();

            licRow["LICENSE_DATE"] = string.IsNullOrWhiteSpace(licDate) ? "1900-01-01 00:00:00.000" : licDate;

            licRow["DEBIT_CIF_AMT"] = srcRow[14].ToString().Trim();
            licRow["ENTRY_DEBIT_DUTY"] = srcRow[15].ToString().Trim();
            licRow["USER_ID"] = currentuser;
            licRow["DATE_TIME"] = LoginDate;
            licRow["STATUS"] = "N";
            licRow["BRANCH_CODE"] = currentbranch;
            licRow["YEAR"] = "";
            licRow["WORKING_PERIOD"] = Working_Period;
            licRow["MODIFIEDBY"] = currentuser;
            licRow["MODIFIEDON"] = LoginDate;

            dsXML.Tables[0].Rows.Add(licRow);

            //---------------------------------------
            // ITEM_PRODUCT_DETAILS
            //---------------------------------------

            /*DataRow itemRow = dsXML.Tables[1].NewRow();

            itemRow["JOBNO"] = IMPORT_JOBNO;
            itemRow["ITEM_ID"] = "";//ITEM_ID
            itemRow["INVOICE_SLNO"] = srcRow[0].ToString();
            itemRow["ITEM_SLNO"] = srcRow[1].ToString().Trim();
            itemRow["SCHEME_CODE"] = srcRow[4].ToString();
            itemRow["SCHEME_NOTN"] = srcRow[5].ToString();
            itemRow["SCHEME_NOTN_SLNO"] = srcRow[6].ToString();
            itemRow["USER_ID"] = currentuser;
            itemRow["DATE_TIME"] = LoginDate;
            itemRow["STATUS"] = "N";
            itemRow["BRANCH_CODE"] = currentbranch;
            itemRow["YEAR"] = "";
            itemRow["WORKING_PERIOD"] = Working_Period;
            itemRow["MODIFIEDBY"] = currentuser;
            itemRow["MODIFIEDON"] = LoginDate;

            dsXML.Tables[1].Rows.Add(itemRow);*/

            //---------------------------------------
            // Increment counters
            //---------------------------------------

            License_id_Max++;
            //ITEM_ID++;
            licenseSlNo++;
        }

        //──────────────────────────────────────────────────────────────────────────────
        // Delete existing LICENSE_DETAILS
        //──────────────────────────────────────────────────────────────────────────────

        if (dsXML.Tables[0].Rows.Count > 0)
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = "";
            Transact.ITEM_SLNO = "";
            Transact.BRANCH_CODE = Connection.Current_Branch();
            Transact.Ename = "License_details_delete";

            ds = Transact.Import_Bulk_License_Select();

            //admin.SqlBulk_Upload_Product("LICENSE_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
            SqlBulk_Upload_Product("LICENSE_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
        }

        //──────────────────────────────────────────────────────────────────────────────
        // Update ITEM_PRODUCT_DETAILS
        //──────────────────────────────────────────────────────────────────────────────

        /*if (dsXML.Tables[1].Rows.Count > 0)
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
        }

        Alert_msg("Uploaded Successfully..");*/
    }
    public void License_Excel_Upload(DataTable sourceTable)
    {
        
        DataSet Inv_ds = new DataSet();
        Inv_ds.Tables.Add(sourceTable.Copy());
        ds = Inv_ds;

        
        DataView dv = Inv_ds.Tables[0].DefaultView;
        DataTable dat = dv.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO");

        Transact.xmlString = ConvertDataTableToXML(dat);
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.BRANCH_CODE = Connection.Current_Branch();
        Transact.Ename = "validate_invoice_item";

        DataSet dtxl = Transact.Import_Bulk_License_Select();

        
        if (dtxl != null && dtxl.Tables.Count > 0 && dtxl.Tables[0] != null && dtxl.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in dtxl.Tables[0].Rows)
            {
                AddError("LICENSE", "Invoice/Item combination does not exist for the selected Job.", "INVOICE_SLNO / ITEM_SLNO", "Invoice : " + dr["INVOICE_SLNO"] + ", Item : " + dr["ITEM_SLNO"]);
            }
            
        }

        
        BuildValidationErrors(Inv_ds.Tables[0]);        
        BuildDsXmlSchema();

        int licenseSlNo = 1;
        int License_id_Max = Get_LICENSE_IMP_EXP_MaxID();

        foreach (DataRow srcRow in ds.Tables[0].Rows)
        {
            //---------------------------------------
            // LICENSE_DETAILS
            //---------------------------------------

            DataRow licRow = dsXML.Tables[0].NewRow();

            licRow["LICENSE_ID"] = License_id_Max;
            licRow["JOBNO"] = IMPORT_JOBNO;
            licRow["INVOICE_SLNO"] = srcRow[0].ToString();
            licRow["ITEM_SLNO"] = srcRow[1].ToString().Trim();
            licRow["EXCEMPTION"] = "Y";
            licRow["REGISTRATION_NO"] = srcRow[2].ToString().Trim();
            licRow["REGISTRATION_DATE"] = srcRow[3].ToString().Trim();
            licRow["SCHEME_CODE"] = srcRow[4].ToString().Trim();
            licRow["LICENSE_ITEM_NO"] = srcRow[7].ToString();
            licRow["LICENSE_SLNO"] = licenseSlNo;
            licRow["DEBIT_QTY"] = srcRow[8].ToString();
            licRow["UNIT_QTY"] = srcRow[9].ToString();
            licRow["PORT_OF_LICENSE"] = srcRow[10].ToString();
            licRow["LIC_DESC"] = srcRow[11].ToString();
            licRow["LICENSE_NO"] = srcRow[12].ToString().Trim();
            string licDate = srcRow[13].ToString().Trim();
            licRow["LICENSE_DATE"] = string.IsNullOrWhiteSpace(licDate) ? "1900-01-01 00:00:00.000" : licDate;
            licRow["DEBIT_CIF_AMT"] = srcRow[14].ToString().Trim();
            licRow["ENTRY_DEBIT_DUTY"] = srcRow[15].ToString().Trim();
            licRow["USER_ID"] = currentuser;
            licRow["DATE_TIME"] = LoginDate;
            licRow["STATUS"] = "N";
            licRow["BRANCH_CODE"] = currentbranch;
            licRow["YEAR"] = "";
            licRow["WORKING_PERIOD"] = Working_Period;
            licRow["MODIFIEDBY"] = currentuser;
            licRow["MODIFIEDON"] = LoginDate;            

            dsXML.Tables[0].Rows.Add(licRow);            

            License_id_Max++;
            
            licenseSlNo++;
        }
                

        if (dsXML.Tables[0].Rows.Count > 0)
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = "";
            Transact.ITEM_SLNO = "";
            Transact.BRANCH_CODE = Connection.Current_Branch();
            Transact.Ename = "License_details_delete";

            ds = Transact.Import_Bulk_License_Select();

            //admin.SqlBulk_Upload_Product("LICENSE_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
            SqlBulk_Upload_Product("LICENSE_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
        }        
    }


    // ── Extracted: field-level validation — mirrors original Regex loop exactly ───
    private void BuildValidationErrors(DataTable source)
    {      

        foreach (DataRow dr in source.Rows)
        {
            string invoiceSlno = dr["INVOICE_SLNO"].ToString().Trim();
            string itemSlno = dr["ITEM_SLNO"].ToString().Trim();
            string regNo = dr["REGISTRATION_NO"].ToString().Trim();
            string regDate = dr["REGISTRATION_DATE"].ToString().Trim();
            string qty = dr["DEBIT_QTY"].ToString().Trim();
            string amt = dr["DEBIT_AMT"].ToString().Trim();
            //string debitAmt = dr["ENTRY_DEBIT_DUTY"].ToString().Trim();


            // Original CHECK 1: INVOICE_SLNO must be digits only
            if (!Regex.IsMatch(invoiceSlno, @"^\d+$"))
                AddError("LICENSE", "Invoice SLNO must contain numbers only. Empty not allowed.", "INVOICE_SLNO", invoiceSlno);

            // Original CHECK 2: ITEM_SLNO must be digits only
            if (!Regex.IsMatch(itemSlno, @"^\d+$"))
                AddError("LICENSE", "Item SLNO must contain numbers only. Empty not allowed.", "ITEM_SLNO", itemSlno);

            // Original CHECK 3: REGISTRATION NO must be exactly 10 digits
            if (!Regex.IsMatch(regNo, @"^\d{10}$"))
                AddError("LICENSE", "Registration No must be 10 digits.", "REGISTRATION NO", regNo);                

            // Original CHECK 4: REGISTRATION_DATE must be dd/MM/yyyy
            if (!Regex.IsMatch(regDate, @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$"))
                AddError("LICENSE", "Registration Date must be dd/MM/yyyy.", "REGISTRATION_DATE", regDate);                

            // Original CHECK 5: DEBIT_QTY must be numeric up to 2 decimal places
            if (!Regex.IsMatch(qty, @"^\d+(\.\d{1,2})?$"))
                AddError("LICENSE", "DEBIT_QTY must be a number with up to 2 decimal places.", "DEBIT_QTY", qty);                

            // Original CHECK 6: DEBIT_CIF_AMT — optional, validated only if filled
            if (!string.IsNullOrWhiteSpace(amt)  && !Regex.IsMatch(amt, @"^\d+(\.\d{1,2})?$"))
                AddError("LICENSE", "DEBIT_CIF_AMT must be a number with up to 2 decimal places.", "DEBIT_CIF_AMT", amt);
                
            //// Original CHECK 7: ENTRY_DEBIT_DUTY — optional, validated only if filled
            //if (!string.IsNullOrWhiteSpace(debitAmt)  && !Regex.IsMatch(debitAmt, @"^\d+(\.\d{1,2})?$"))
            //    AddError("LICENSE", "ENTRY_DEBIT_DUTY must be a number with up to 2 decimal places.", "ENTRY_DEBIT_DUTY", debitAmt);
                
        }

        //return errors;
    }

    // ── Extracted: dsXML schema — mirrors original Columns.Add blocks exactly ─────
    private void BuildDsXmlSchema()
    {
        dsXML = new DataSet();

        // ── LICENSE_DETAILS columns (original order preserved) ───────────────────
        DataTable licTable = new DataTable("LICENSE_DETAILS");
        foreach (string col in new[]
         {
           "LICENSE_ID","JOBNO","INVOICE_SLNO","ITEM_SLNO","SCHEME_CODE","LICENSE_SLNO","REGISTRATION_NO","REGISTRATION_DATE","EXCEMPTION","DEBIT_CIF_AMT","DEBIT_QTY","UNIT_QTY","LICENSE_ITEM_NO",
           "PORT_OF_LICENSE","USER_ID","DATE_TIME","STATUS","BRANCH_CODE","YEAR","WORKING_PERIOD","DEBIT_DUTY","LICENSE_NO","LICENSE_DATE","MODIFIEDBY","MODIFIEDON","TOTAL_CIF_VALUE","TOTAL_DEBIT_DUTY",
           "ENTRY_DEBIT_DUTY","LIC_DESC","LICENSE_CURRENCY","EX_RATE"
         })
            licTable.Columns.Add(col);

        dsXML.Tables.Add(licTable);

        //// ── ITEM_PRODUCT_DETAILS columns (original order preserved) ──────────────
        //DataTable itemTable = new DataTable("ITEM_PRODUCT_DETAILS");
        //foreach (string col in new[]
        //{
        //    "ITEM_ID","JOBNO","INVOICE_SLNO","ITEM_SLNO","SCHEME_CODE","SCHEME_NOTN","SCHEME_NOTN_SLNO","USER_ID","DATE_TIME","STATUS","BRANCH_CODE","YEAR","WORKING_PERIOD","MODIFIEDBY","MODIFIEDON"
        //})
        //    itemTable.Columns.Add(col);

        //dsXML.Tables.Add(itemTable);
    }

    public int Get_LICENSE_IMP_EXP_MaxID()
    {
        int License_id_Max = 0;
        Transact.LICENSE_ID = "";
        Transact.LICENSE_NO = "0";
        Transact.Ename = "GET_IMPORT_LICENSE_ID_MAX";
        ds = Transact.Import_Bulk_License_Select();

        License_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["LICENSE_ID"].ToString());
        return License_id_Max;
    }

    public DataSet GetAndDeleteJobData(string tableName)
    {
        using (SqlConnection con = new SqlConnection(Connection.GetConnection()))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SP_JOB_ALLDATA", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JOBNO", IMPORT_JOBNO);
                cmd.Parameters.AddWithValue("@BRANCHCODE", Connection.Current_Branch());
                cmd.Parameters.AddWithValue("@Operation", "Backup and Delete");
                cmd.Parameters.AddWithValue("@Table", tableName);

                cmd.Parameters.Add("@ErrorMsg", SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MStatus", SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                int existingTableCount = dsBkp.Tables.Count;
                da.Fill(dsBkp);
                if (dsBkp.Tables.Count > existingTableCount)
                {
                    dsBkp.Tables[existingTableCount].TableName = tableName+"_Bak";
                }
                return dsBkp;
            }
        }
    }

    private ListItem GetMatchedItem(string userValue, List<ListItem> existingList)
    {
        if (string.IsNullOrWhiteSpace(userValue))
            return null;

        return existingList.FirstOrDefault(x =>
            x.Text.Equals(userValue.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public static string Check_CountryName(string CountryName, string Filedname)
    {
        if (CountryName != "")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet dsCountryCode = new DataSet();

            Auto.Enamesearch = CountryName;
            if (Filedname == "COUNTRY_OF_ORIGIN")
            {
                Auto.Ename = "IMP_EXP_Country_of_orgin_Chk";
            }
            else
            {
                Auto.Ename = "Get_CountryName";
            }

            dsCountryCode = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (dsCountryCode.Tables[0].Rows.Count > 0)
            {
                CountryName = "Yes";
            }
            else
            {
                CountryName = "No";
            }
        }
        return CountryName;
    }

    private void ApplyGridTheme()
    {
        string gradTop, gradBot;
        GetThemeColors(out gradTop, out gradBot);

        string css = @"
         <style type='text/css'>
             #gv_QueryReply_wrap .grid-view-styled th,
             #gv_Item_Details_wrap .grid-view-styled th {
                 background: linear-gradient(" + gradTop + @", " + gradBot + @") !important;
             }
             #gv_QueryReply_wrap .pager-row a,
             #gv_Item_Details_wrap .pager-row a {
                 color: " + gradBot + @" !important;
                 font-weight: 600;
             }
             #gv_QueryReply_wrap .grid-view-styled tr:hover td,
             #gv_Item_Details_wrap .grid-view-styled tr:hover td {
                 background-color: " + gradTop + @"22 !important;
             }
             #lblQueryReplyHeading {
                 color: " + gradBot + @" !important;
             }
         </style>";

        litGridThemeCss.Text = css;
    }

    private void GetThemeColors(out string gradTop, out string gradBot)
    {
        string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "") ? Session["Theme"].ToString().ToLower() : "orange";
        switch (theme)
        {
            case "blue": gradTop = "#4a90e2"; gradBot = "#2b6cb0"; break;
            case "dblue": gradTop = "#2c3e60"; gradBot = "#16213a"; break;
            case "green": gradTop = "#43a047"; gradBot = "#2e7d32"; break;
            case "bluefancy": gradTop = "#5b86e5"; gradBot = "#36d1dc"; break;
            case "violetfancy": gradTop = "#8e2de2"; gradBot = "#4a00e0"; break;
            default: gradTop = "#f5a623"; gradBot = "#e08e0b"; break;
        }
    }
}
