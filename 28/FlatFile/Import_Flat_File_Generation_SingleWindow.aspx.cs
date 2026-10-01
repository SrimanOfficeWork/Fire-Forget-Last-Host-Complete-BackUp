using System;
using System.Data; // This was added to make CommandType function
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
using Microsoft.ApplicationBlocks.Data;

using Microsoft.Reporting.WebForms;
using System.Net.Mail;

public partial class Transaction_Default2_SingleWindow : ThemeClass
{
    adminmaster erm = new adminmaster();
    Date_Time split = new Date_Time();
    DataSet dss = new DataSet();
    DataRow[] dr;
    string val = "", Is_val = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
    public string working_period;
    eroyalmaster Imp_Exp = new eroyalmaster();

    private string _Workingperiod;
    DataSet ds = new DataSet();

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }


    public int currentrow = 0, Selected_Row = 0, Cell_Row = 0, ColumnIndex = 0;
    public string ICEGATE_EMAIL_ID = "", ICEGATE_EMAIL_PWD = "";
    public string EMail_ID = "";

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, IS_Imgbtn, IMPORTER_CLASS, EXCHANGE_PER_UNIT;


    CheckList CHKLIST = new CheckList();
    FlatFile_Generation FlatFile = new FlatFile_Generation();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "";
    public string folderName = "/Submission";
    ErrorLogs er = new ErrorLogs();
    StreamWriter sw;
    public string createfilename = "";
    public char ch = Convert.ToChar(29);
    public string CHA_NO = "", ICEGATE_ID = "";
    public string LOADING_EXBOND_WARWHOUSE = "", MISC_LOAD_RATE = "", Warehouse_Customs_Site_ID = "";
    public string PREVIOUS_UNITPRICE = "", PREVIOUS_CURRENY = "", PREVIOUS_CUSTOMSITE = "";
    //public string BE_NO = "";
    //public string BE_DATE = "";

    public string SELECT_TYPE, SELECT_BRANCH;

    string[] Str_IGM_GATEWAY_PORT_CODE;
    string[] Str_Bond_Location;

    public string COMPANY_ID = "";

    #region GeneralDetails_Public_Attributes

    public string JOBID, Name_Search;
    public string Ename;

    public string JOBDATE;
    public string TRANSPORT_MODE;
    public string BE_TYPE;
    public string CUSTOMS_HOUSE;
    public string IMPORTER_NAME;
    public string ADDRESS1;
    public string ADDRESS2;
    public string ADDRESS3;
    public string ADDRESS4;
    public string ADDRESS5;
    public string IEC_NO;
    public string BRANCH_NO;
    public string COUNTRY_ORIGIN;
    public string PORT_ORIGIN;

    public string PORT_SHIPMENT;
    public string COUNTRY_SHIPMENT;
    public string FILING_STATUS;
    public string SECTION46;
    public string SECTION46_DESC;
    public string FIRSTCHECK;
    public string FIRSTCHECK_DESC;
    public string GREEN_CHANNEL;
    public string GREEN_CHANNEL_DESC;
    public string KACHHA_BE;
    public string KACHHA_BE_DESC;
    public string SECTION48;
    public string SECTION48_DESC;
    public string HIGH_SEA_SALE;
    public string HIGH_SEA_SALE_NAME;
    public string HIGH_SEA_IEC;
    public string HIGH_SEA_BRANCH_SL_NO;
    public string HSS_ADD1;
    public string HSS_ADD2;
    public string HSS_ADD3;
    public string HSS_ADD4;
    public string HSS_ADD3_4;
    public string HSS_ADD5;
    public string WAREHOUSE_NAME;
    public string WAREHOUSE_CODE;

    public string EXBOND_INBOND_BE_NO;
    public string EXBOND_INBOND_BE_DATE;
    public string EXBOND_BOND_NO;
    public string EXBOND_BOND_DATE;
    public string EXBOND_WAREHOUSE_CUSTOMS;
    public string EXBOND_WAREHOUSE_CUSTOMS_CODE;
    public string EXBOND_NOOFPACKAGE;
    public string EXBOND_NOOFPACKAGE_UNITCODE;
    public string EXBOND_GROSS_WEIGHT;
    public string EXBOND_GROSS_WEIGHT_UNITCODE;
    public string EXBOND_DIRECT_EXBONDING;
    public string JOB_STATUS;


    public string UCR_NO;
    public string UCR_TYPE;
    public string PAYMENT_METHOD_CODE;
    public string PRECEDING_LEVEL;

    public string IMP_EXP_TYPE;
    public string REMARKS;

    public string COMMERCIAL_DETAILS_STATUS;
    public string COMMERCIAL_TAX_STATECODE;
    public string COMMERCIAL_TAX_TYPE;
    public string COMMERCIAL_TAX_REGISTRATION_NO;

    public string Authorized_Dealer_Code = "";


    #endregion

    #region Invoice_Details_Public_Attributes

    public string INVOICE_ID;
    public string INVOICE_SLNO;

    public string INVOICE_NO;
    public string INVOICE_DATE;
    public string TERMS;
    public string INVOICE_CURRENCY;
    public string INVOICE_EXRATE;
    public string INVOICE_VALUE;
    public string SUPPLIER_NAME;
    public string SUPPLIER_ADDRESS;
    public string SUPPLIER_ADDRESS1;
    public string SUPPLIER_ADDRESS2;
    public string SUPPLIER_COUNTRY_NAME;
    public string SUPPLIER_COUNTRY_CODE;
    public string SUPPLIER_COUNTRY_PINCODE;
    public string SELLER_NAME;
    public string SELLER_ADDRESS;
    public string SELLER_ADDRESS1;
    public string SELLER_ADDRESS2;
    public string SELLER_COUNTRY_NAME;
    public string SELLER_COUNTRY_CODE;
    public string SELLERCOUNTRY_PINCODE;
    public string BROKER_NAME;
    public string BROKER_ADDRESS;
    public string BROKER_ADDRESS1;
    public string BROKER_ADDRESS2;
    public string BROKER_COUNTRY_NAME;
    public string BROKER_COUNTRY_CODE;
    public string BROKER_COUNTRY_PINCODE;
    public string MIS_CHARGES;
    public string MIS_RATE;
    public string MIS_CURRENCY;
    public string MIS_EXRATE;
    public string MIS_AGENCY_CHARGES;
    public string MIS_AGENCY_RATE;
    public string MIS_AGENCY_CURRENCY;
    public string MIS_AGENCY_EXRATE;
    public string MIS_DISCOUNT_CHARGES;
    public string MIS_DISCOUNT_RATE;
    public string MIS_DISCOUNT_CURRENCY;
    public string MIS_DISCOUNT_EXRATE;
    public string MIS_DISCOUNT_REASON;
    public string MIS_LOADING_CHARGES;
    public string MIS_LOADING_RATE;
    public string MIS_LOADING_CURRENCY;
    public string MIS_LOADING_EXRATE;
    public string MIS_FREIGHT_CHARGES;
    public string MIS_FREIGHT_RATE;
    public string MIS_FREIGHT_CURRENCY;
    public string MIS_FREIGHT_EXRATE;
    public string MIS_INSURANCE_CHARGES;
    public string MIS_INSURANCE_RATE;
    public string MIS_INSURANCE_CURRENCY;
    public string MIS_INSURANCE_EXRATE;
    public string MIS_HIGHSEASALE_CHARGES;
    public string MIS_HIGHSEASALE_RATE;
    public string MIS_HIGHSEASALE_CURRENCY;
    public string MIS_HIGHSEASALE_EXRATE;
    public string MIS_SINGLE_OR_MULITIPLE;
    public string SVB_RELATION;
    public string SVB_REF_NO;
    public string SVB_REF_DATE;
    public string SVB_CUSTOM_HOUSE;
    public string SVB_LOADING_ON;
    public string SVB_ASSESABLE_RATE;
    public string SVB_DUTY_RATE;
    public string SVB_ASSESABLE_STATUS;
    public string SVB_DUTY_STATUS;
    public string OTHER_PURCHASE_ORDER;
    public string OTHER_PURCHASE_ORDER_DATE;
    public string OTHER_CONTRACT_NO;
    public string OTHER_CONTRACT_DATE;
    public string OTHER_LOC_NO;
    public string OTHER_LOC_DATE;
    public string OTHER_NATURE_OF_TRANSACTION;
    public string OTHER_TERMS_OF_PAYMENT;
    public string OTHER_CONDITIONS;
    public string OTHER_VALUATION_METHOD;

    public string NON_STD_EFFECT_DT_IMP;
    public string NON_STD_BANKNAME;
    public string NON_STD_CERTIFICATE_NO;
    public string NON_STD_CERTIFICATE_DATE;

    public string UNIT;
    public string Custom_House_Code_which_has_imposed_load = "";
    public string Nature_of_Discount = "";
    public string Freight_Actual = "";
    public string Landing_Rate = "1";

    public string Conditions_Attached_Sale1 = "";
    public string Conditions_Attached_Sale2 = "";
    public string Conditions_Attached_Sale3 = "";
    public string Conditions_Attached_Sale4 = "";
    public string Conditions_Attached_Sale5 = "";
    public string Other_Relevant_Information = "";

    /*****Exchange Rate*********/

    public string Standard_Currency = "Y";
    public string Effective_Date = "";
    public string Bank_Name_Non_Std_Cur = "";
    public string Exch_Certificate_No = "";
    public string Exch_Certificate_Date = "";

    //----------//
    public string MI_FREIGHT;
    public string MI_INSURANCE;


    public string TERMS_PLACE;
    public string THIRDPARTY_NAME;
    public string THIRDPARTY_ADD1;
    public string THIRDPARTY_ADD2;
    public string THIRDPARTY_CITY;
    public string T_PARTY_COUNTRY_SUB_DIV;
    public string T_PARTY_COUNTRY_CODE;
    public string T_PARTY_PIN;
    public string AUTHORIZED_ECONOMIC_OPERATOR_CODE;
    public string A_E_O_COUNTRY;
    public string AUTHORIZED_ECONOMIC_OPERATOR;
    public string WHETHER_BUYER_SELLER_RELATED;

    #endregion

    #region Item_Details_Public_Attributes

    public string ITEM_ID;
    public string JOBNO;
    //public string INVOICE_SLNO;
    //public string INVOICE_NO;
    public string ITEM_SLNO;
    public string ITEM_DESCRIPTION;
    public string ITEM_DESCRIPTION1;
    public string ITEM_DESCRIPTION2;
    public string ITEM_QTY;
    public string ITEM_QTY_CODE;
    public string ITEM_UNIT_PRICE;
    public string ITEM_UNIT_CODE;
    public string ITEM_TOTAL_AMOUNT;
    public string ITEM_AMOUNT_CODE;
    public string CTH_NO;
    public string SCHEME_CODE;
    public string SCHEME_CODE_FULL;
    public string SCHEME_NOTN;
    public string SCHEME_NOTN_SLNO;
    public string CTH_QTY1;
    public string CTH_QTY1_CODE;
    public string CTH_QTY2;
    public string CTH_QTY2_CODE;
    public string GENEARL_DESCRIPTION;
    public string MANUFACTURER;
    public string BRAND;
    public string MODEL;
    public string END_USE_OF_ITEM;
    public string COUNTRY_OF_ORIGIN;
    public string ACCESSORIES;
    public string PREVIOUS_BE_NO;
    public string PREVIOUS_CUSTOMS_HOUSE;
    public string PREVIOUS_BE_DATE;
    public string UNIT_PRICE;
    public string UNIT_CODE;
    //public string CUSTOMS_HOUSE;
    public string PRODUCT_RITC;
    public string PRODUCT_CTH;
    public string PRODUCT_BCD_NOTN;
    public string PRODUCT_BCD_SLNO;
    public string PRODUCT_BCD_RATE;
    public string PRODUCT_BCD_SPL;
    public string PRODUCT_BCD_UNIT;
    public string PRODUCT_BCD_SPL_TYPE;
    public string PRODUCT_ADDL_DUTY_NOTN;
    public string PRODUCT_ADDL_DUTY_NOTN_SL;
    public string PRODUCT_ADDL_DUTY_RATE;
    public string PRODUCT_EDU_CESS_NOTN;
    public string PRODUCT_EDU_CESS_NOTN_SL;
    public string PRODUCT_EDU_CESS_RATE;
    public string PRODUCT_SEC_EDU_CESS_NOTN;
    public string PRODUCT_SEC_EDU_CESS_NOTN_SL;
    public string PRODUCT_SEC_EDU_CESS_RATE;
    public string PRODUCT_NCD_NOTN;
    public string PRODUCT_NCD_SLNO;
    public string PRODUCT_NCD_RATE;
    public string PRODUCT_NCD_SPL;
    public string PRODUCT_NCD_UNIT;
    public string PRODUCT_NCD_SPL_TYPE;
    public string PRODUCT_AGGREGATE_DUTY_NOTN;
    public string PRODUCT_AGGREGATE_DUTY_NOTN_SL;
    public string PRODUCT_AGGREGATE_DUTY_NOTN_RATE;
    public string PRODUCT_SAFEGUARD_NOTN;
    public string PRODUCT_SAFEGUARD_SLNO;
    public string PRODUCT_SAFEGUARD_RATE;
    public string PRODUCT_SAFEGUARD_SPL;
    public string PRODUCT_SAFEGUARD_UNIT;
    public string PRODUCT_SAFEGUARD_SPL_TYPE;

    public string PRODUCT_SAPTA_NOTN;
    public string PRODUCT_SAPTA_SLNO;
    public string PRODUCT_SAPTA_RATE;

    public string PRODUCT_TARIFF_NOTN;
    public string PRODUCT_TARIFF_SLNO;
    public string PRODUCT_TARIFF_QTY;
    public string PRODUCT_TARIFF_AMOUNT;
    public string PRODUCT_TARIFF_AMOUNT_UNIT;

    public string PRODUCT_CETH;
    public string PRODUCT_MRP_YN;
    public string PRODUCT_MRP_SL_NO;
    public string PRODUCT_MRP_AMOUNT;
    public string PRODUCT_MRP_ABT_RATE;
    public string PRODUCT_CVD_NOTN;
    public string PRODUCT_CVD_SLNO;
    public string PRODUCT_CVD_RATE;
    public string PRODUCT_CVD_SPL;
    public string PRODUCT_CVD_UNIT;
    public string PRODUCT_CVD_SPL_TYPE;
    public string PRODUCT_CVD_EDU_CESS_RATE;
    public string CETH_CVD_EDU_CESS_SL;
    public string PRODUCT_CVD_SEC_EDU_CESS_RATE;
    public string PRODUCT_ADDL5_SIA_NOTN;
    public string PRODUCT_ADDL5_SIA_NOTN_SL;
    public string PRODUCT_ADDL5_SIA_RATE;
    public string PRODUCT_ADDL_GSI_NOTN;
    public string PRODUCT_ADDL_GSI_SLNO;
    public string PRODUCT_ADDL_GSI_RATE;
    public string PRODUCT_ADDL_GSI_SPL;
    public string PRODUCT_ADDL_GSI_UNIT;
    public string PRODUCT_ADDL_GSI_SPL_TYPE;
    public string PRODUCT_ADDL_SHEII_NOTN;
    public string PRODUCT_ADDL_SHEII_SLNO;
    public string PRODUCT_ADDL_SHEII_RATE;
    public string PRODUCT_ADDL_SHEII_SPL;
    public string PRODUCT_ADDL_SHEII_UNIT;
    public string PRODUCT_ADDL_SHEII_TYPE;
    public string PRODUCT_ADDL_TTA_NOTN;
    public string PRODUCT_ADDL_TTA_SLNO;
    public string PRODUCT_ADDL_TTA_RATE;
    public string PRODUCT_ADDL_TTA_SPL;
    public string PRODUCT_ADDL_TTA_UNIT;
    public string PRODUCT_ADDL_TTA_TYPE;
    public string PRODUCT_ADDL_HEALTH_CESS_NOTN;
    public string PRODUCT_ADDL_HEALTH_CESS_SLNO;
    public string PRODUCT_ADDL_HEALTH_CESS_RATE;
    public string PRODUCT_ADDL_HEALTH_CESS_SPL;
    public string PRODUCT_ADDL_HEALTH_CESS_UNIT;
    public string PRODUCT_ADDL_HEALTH_CESS_TYPE;
    public string PRODUCT_CESS_NOTN;
    public string PRODUCT_CESS_SLNO;
    public string PRODUCT_CESS_RATE;
    public string PRODUCT_CESS_SPL;
    public string PRODUCT_CESS_UNIT;
    public string PRODUCT_CESS_TYPE;
    public string ANTI_DUMPING_NOTN;
    public string ANTI_DUMPING_NOTN_SLNO;
    public string CTH_SLNO;
    public string CTH_SUPPLIER_SLNO;
    public string CTH_QTY;
    public string RSP_DUTY_STATUS;
    public string RSP_SL_NO;
    public string RSP_DESC;
    public string RSP_QTY;
    public string RSP_AMOUNT;
    public string RSP_NOTN_NO = "";
    public string RSP_NOTN_SL_NO = "";
    public string RSP_ABT_RATE;

    public string PREFERENTIAL = "S";
    public string DISCOUNT_RATE = "";
    public string DISCOUNT_AMOUNT = "";

    //public string SVB_REFERENCE="";
    //public string SVB_REFERENCE_DATE="";
    //public string SVB_LOAD_ASSESSABLE="";
    //public string SVB_LOAD_ON_DUTY="";
    //public string SVB_FLAG="";
    //public string WHETHER_LOAD_FINAL_ON_ASS = "";
    //public string WHETHER_LOAD_FINAL_ON_DUTY="";
    //public string SVB_CUSTOM_HOUSE_CODE = "";

    public string ITEM_SVB_RELATION = "";
    public string ITEM_SVB_REF_NO = "";
    public string ITEM_SVB_REF_DATE = "";
    public string ITEM_SVB_CUSTOM_HOUSE = "";
    public string ITEM_SVB_LOADING_ON = "";
    public string ITEM_SVB_ASSESABLE_RATE = "";
    public string ITEM_SVB_DUTY_RATE = "";
    public string ITEM_SVB_ASSESABLE_STATUS = "";
    public string ITEM_SVB_DUTY_STATUS = "";
    
    public string POLICY_PARA_NO = "";
    public string POLICY_YEAR = "";
    public string WHETHER_RSP_DECLARED;
    public string WHETHER_REIMPORT;
    
    public string PRODUCT_OTHER_DUTY_NOTN;
    public string PRODUCT_OTHER_DUTY_SLNO;
    public string PRODUCT_OTHER_DUTY_RATE;
    public string PRODUCT_OTHER_DUTY_SPL;
    public string PRODUCT_OTHER_DUTY_UNIT;
    public string PRODUCT_OTHER_DUTY_TYPE;
        
    public string RSP_APPLICABLE;
    public string CENTRAL_EXCISE_FALG;
    public string MANUFACTURER_PRODUCER;
    public string M_P_GROWER_CODE;
    public string M_P_GROWER_ADD1;
    public string M_P_GROWER_ADD2;
    public string M_P_GROWER_CITY;
    public string M_P_GROWER_COUNTRY_SUBDIV;
    public string M_P_GROWER_PIN;
    public string M_P_GROWER_COUNTRY;
    public string SOURCE_COUNTRY;
    public string TRANSIT_COUNTRY;
    public string ACCESSORY_STATUS;

    #endregion

    #region License_Details_Public_Attributes

    public string LICENSE_ID;
    public string LICENSE_SLNO;
    public string REGISTRATION_NO;
    public string REGISTRATION_DATE;
    public string EXCEMPTION;
    public string DEBIT_AMT;
    public string DEBIT_QTY;
    public string UNIT_QTY;
    public string LICENSE_ITEM_NO;
    public string PORT_OF_LICENSE;

    #endregion

    #region Bond Details_Public_Attributes
    public string BONDID;

    public string BOND_NO;
    public string BOND_TYPE;
    public string BOND_LOCATION;
    #endregion

    #region Certificate Details_Public_Attributes
    public string CERTIFICATEID;

    public string CERTIFICATE_NO;
    public string CERTIFICATE_DATE;
    public string CERTIFICATE_TYPE;

    #endregion

    #region Re_import_Details_Public_Attributes

    public string RE_IMPORT_ID;
    public string RE_IMPORT_SLNO;
    //public string ITEM_SLNO;
    public string SCHEME_CODE_LICENSE;
    //public string INVOICE_SLNO;
    public string SB_NO;
    public string SB_DATE;
    public string PORT_EXPORT;
    public string SB_INVOICE_NO;
    public string SB_INVOICE__ITEM_NO;
    public string NOTN_NO;
    public string NOTN_SLNO;
    public string EXPORT_FREIGHT;
    public string EXPORT_INSURANCE;
    public string CUSTOMS_DUTY;
    public string EXCISE_DUTY;

    #endregion

    #region IGM Details_Public_Attributes

    public string IGM_ID;
    public string IGM_SLNO_UPDATE;
    public string IGM_JOBNO;
    public string IGM_JOBDATE;
    public string IGM_AIRLINECODE;
    public string IGM_AIRLINENAME;
    public string IGM_FLIGHTNO_VESSELNO;
    public string IGM_FLIGHT_VESSELDATE;
    public string IGM_NO;
    public string IGM_DATE;
    public string IGM_MAWB_MBL;
    public string IGM_MAWB_MBLDATE;
    public string IGM_HAWB_HBLNO;
    public string IGM_HAWB_HBLDATE;
    public string IGM_NOOFPACKAGE;
    public string IGM_PACKAGETYPE;
    public string IGM_GROSSWEIGHT;
    public string IGM_TYPEOFWEIGHT;
    public string IGM_NETWEIGHT;
    public string IGM_NETWEIGHTTYPE;
    public string IGM_MARKSNOS1;
    public string IGM_MARKSNOS2;
    public string IGM_MARKSNOS3;

    public string IGM_TRANSPORTMODE;
    public string IGM_GATEWAY_IGM_NO;
    public string IGM_GATEWAY_IGM_DATE;
    public string IGM_GATEWAY_PORT_CODE;

    #endregion

    #region Container Details_Public_Attributes

    public string CONTAINERID;
    public string CONTAINER_NO;
    public string CONTAINER_IGM_SLNO;
    public string CONTAINER_IGM_NO;
    public string CONTAINER_IGM_DATE;
    public string SEAL_NO;
    public string FCL_OR_LCL;
    private string TRUCK_NO;

    #endregion

    #region BE_ENTRY Details_Public_Attributes

    public string BE_JOBNO;
    public string BE_NO;
    public string BE_DATE;
    public string BE_NO_OF_PACKAGES;
    public string BE_PACKAGE_CODE;
    public string BE_WEIGHT;
    public string BE_UNIT_CODE;
    public string BE_INBOND_NO;
    public string BE_INBOND_DATE;
    public string BE_WAREHOUSE_CUSTOMS;
    public string BE_WAREHOUSE_CUSTOMS_CODE;
    public string GetDate_ddmmyy;
    public string JOB_LOCK, JOB_RELEASE, JOB_USER;
    #endregion

    #region Single_Window Public_Attributes

    //public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    //public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string INFO_TYPE;
    public string INFO_QUALIFIER;
    public string INFO_CODE;
    public string INFO_TEXT;
    public string INFO_MSR;
    public string INFO_UQC;
    public string CONSTITUENT_SRNO;
    public string CONSTITUENT_ELEMENT_NAME;

    public string CONSTITUENT_ELEMENT_CODE;
    public string CONSTITUENT_PERCENTAGE;
    public string CONSTITUENT_YIELD_PERCENTAGE;
    public string ACTIVE_INGREDIENT;
    public string PRODUCTION_BATCH_IDENTIFIER;
    public string PRODUCTION_BATCH_QUANTITY;
    public string UNIT_QTY_CODE;
    public string DATE_OF_MANUFACTURING;
    public string DATE_OF_EXPIRY;
    public string BEST_BEFORE;
    public string CONTROL_TYPE_CODE;
    public string CONTROL_LOCATION;



    public string CONTROL_START_DATE;
    public string CONTROL_END_DATE;
    public string CONTROL_RESULT_CODE;
    public string CONTROL_RESULT_TEXT;
    public string STMT_DECLARATION_TYPE;
    public string STMT_DECLARATION_NUMBER;
    public string STMT_DECLARATION_DATE;
    public string STMT_TYPE;
    public string STMT_CODE;
    public string STMT_TEXT;


    public string SUP_DECLARATION_NUMBER;
    public string SUP_DECLARATION_DATE;
    public string SUP_DECLARATION_TYPE;
    public string UNIQUE_DOC_NUMBER;
    public string DOC_TYPE_CODE;
    public string DOC_ISSUING_PARTY_CODE;
    public string DOC_ISSUING_PARTY_NAME_ADD1;
    public string DOC_ISSUING_PARTY_NAME_ADD2;
    public string DOC_ISSUING_PARTY_CITY;
    public string DOC_ISSUING_PARTY_PIN;


    public string DOC_REF_NUMBER;
    public string PLACE_OF_ISSUE;
    public string DOC_ISSUE_DATE;
    public string DOC_EXPIRY_DATE;
    public string BENEFICIARY_PARTY_CODE;

    public string BENEFICIARY_PARTY_ADDRESS1;
    public string BENEFICIARY_PARTY_ADDRESS2;
    public string BENEFICIARY_PARTY_CITY;
    public string BENEFICIARY_PARTY_PIN;
    public string FILE_TYPE;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            //comp_ConnectionStr = Session["currentcomp_db"].ToString();

            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
            ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");

            COMPANY_ID = Session["COMPANY_ID"].ToString();

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

            if (!IsPostBack)
            {
                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }

                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 7;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
                if (!string.IsNullOrEmpty(Request["jobno"]))
                {

                    if (!string.IsNullOrEmpty(Request["SUB"]))
                    {
                        FlatFile.JOBNo = "";
                        FlatFile.Ename = "select_jobno";
                        FlatFile.Workingperiod = SELECT_BRANCH;
                        ddlJobNo.DataSource = FlatFile.RetrieveAll_Details();
                        ddlJobNo.DataValueField = "JOBNO";
                        ddlJobNo.DataTextField = "JOBNO_PS";
                        ddlJobNo.DataBind();
                        ddlJobNo.Items.Remove("0");
                        ddlJobNo.Items.Insert(0, "Select");

                        ddlJobNo.SelectedValue = Request["jobno"].ToString();
                        btnSearch_Click(sender, e);


                    }
                    else
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                        currdiv.Style.Add("display", "none");

                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("innerbox_Main_Top_User");
                        currdiv1.Style.Add("display", "none");

                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("maincontent");
                        currdiv2.Style.Add("margin", "-16px 2px 0 0");
                        currdiv2.Style.Add("padding", "2px 0 0");

                        //ddlJobNo.Items.Clear();
                        //ddlJobNo.Items.Add(Request["jobno"].ToString());

                        ddlJobNo.Items.Clear();
                        ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                        ddlJobNo.SelectedIndex = 0;


                    }

                }
                else
                {
                    FlatFile.JOBNo = "";
                    FlatFile.Ename = "select_jobno";
                    FlatFile.Workingperiod = SELECT_BRANCH;
                    ddlJobNo.DataSource = FlatFile.RetrieveAll_Details();
                    ddlJobNo.DataValueField = "JOBNO";
                    ddlJobNo.DataTextField = "JOBNO_PS";
                    ddlJobNo.DataBind();
                    ddlJobNo.Items.Remove("0");
                    ddlJobNo.Items.Insert(0, "Select");
                }
                txtCustomHouse.Attributes.Add("readonly", "readonly");
                txtImporterName.Attributes.Add("readonly", "readonly");
                txtBE_Type.Attributes.Add("readonly", "readonly");
                txtSupplier.Attributes.Add("readonly", "readonly");
                txtNoofItems.Attributes.Add("readonly", "readonly");
                txtNoofInvoices.Attributes.Add("readonly", "readonly");





            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
        //Session.Remove("JOB_LOCK");
        //Session.Remove("JOB_RELEASE");
        //Session.Remove("JOB_USER");

        if (!IsPostBack)
        {
            if (ddlJobNo.SelectedItem.Text != "Select")
            {
                DataSet ds2 = new DataSet();
                Transaction Transact = new Transaction();
                Transact.JOBID = "";
                Transact.JOBNO = ddlJobNo.SelectedValue.ToString();
                Transact.IMPORTER_NAME = "";
                Transact.TRANSPORT_MODE = "";
                Transact.CUSTOMS_HOUSE = "";
                Transact.Ename = "select_Id_Submission";
                Transact.WORKING_PERIOD = SELECT_BRANCH;

                ds2 = Transact.RetrieveAll_General_Details();

                JOB_LOCK = ds2.Tables[0].Rows[0]["JOB_STATUS"].ToString();
                JOB_RELEASE = ds2.Tables[0].Rows[0]["JOB_RELEASE"].ToString();
                JOB_USER = ds2.Tables[0].Rows[0]["USERID"].ToString();

                Session.Remove("JOB_LOCK");
                Session.Remove("JOB_RELEASE");
                Session.Remove("JOB_USER");

                Session["JOB_LOCK"] = JOB_LOCK;
                Session["JOB_RELEASE"] = JOB_RELEASE;
                Session["JOB_USER"] = JOB_USER;

            }


            if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
            {
                JOB_LOCK = Session["JOB_LOCK"].ToString();

                if (Convert.ToInt32(JOB_LOCK) == 1)
                {
                    //btnSearch.Enabled = false;
                    btnSubmission.Enabled = false;
                    //btnSearch.ToolTip = "This Job is Locked by Admin";
                    Alert_msg("This Job is Locked by Admin");

                }
            }

            if (ddlJobNo.SelectedItem.Text != "Select")
            {
                if (Session["USER_JOB_LOCK"].ToString() == "Yes")
                {
                    if (Session["JOB_USER"] != null && Session["JOB_USER"] != "")
                    {
                        if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
                        {
                            if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                            {
                                JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                                if (JOB_RELEASE == "No")
                                {
                                    btnSubmission.Enabled = false;
                                    MP_U.Show();
                                    lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                    btnSubmission.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                }
                            }
                        }
                    }
                    else
                    {

                    }

                }
            }

        }

    }

    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSearch.Enabled = false;
            btnSubmission.Enabled = false;
            imgbtnFlatFile.Enabled = false;

            btnSearch.ToolTip = "You don't have permission to access";
            btnSubmission.ToolTip = "You don't have permission to access";
            imgbtnFlatFile.ToolTip = "You don't have permission to access";
        }
        else
        {
            btnSearch.Enabled = true;
            btnSubmission.Enabled = true;
            imgbtnFlatFile.Enabled = true;

        }
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CheckList chklist = new CheckList();
            chklist.JOBNo = ddlJobNo.SelectedValue.ToString();
            chklist.Ename = "select_jobno_CheckList";

            chklist.Workingperiod = SELECT_BRANCH;
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtImporterName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txtBE_Type.Text = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtSupplier.Text = ds.Tables[1].Rows[0]["SUPPLIER_NAME"].ToString();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtNoofInvoices.Text = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";

                    }
                    else
                    {
                        txtNoofInvoices.Text = "";
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txtNoofItems.Text = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";

                    }
                    else
                    {
                        txtNoofItems.Text = "";
                    }
                }
                else
                {
                    txtSupplier.Text = "";
                    txtNoofItems.Text = "";
                    txtNoofInvoices.Text = "";
                }

            }
            else
            {
                txtCustomHouse.Text = "";
                txtImporterName.Text = "";
                txtBE_Type.Text = "";
                txtSupplier.Text = "";
                txtNoofItems.Text = "";
                txtNoofInvoices.Text = "";

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

    public void Get_AllDetails(string flag)
    {
        FlatFile.JOBNo = ddlJobNo.SelectedValue.ToString();
        FlatFile.Ename = "FlatFile";
        FlatFile.Workingperiod = SELECT_BRANCH;
        ds = FlatFile.RetrieveAll_Details();

    }

    public void BE_Details()
    {
        FlatFile.JOBNo = ddlJobNo.SelectedValue.ToString();
        FlatFile.Ename = "FlatFile";
        FlatFile.Workingperiod = SELECT_BRANCH;
        ds = FlatFile.RetrieveAll_Details();

        Session["ds"] = ds;

        if (ds.Tables[0].Rows.Count > 0)
        {


            //JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();

            JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString();

            TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();



            BE_TYPE = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();

            if (BE_TYPE == "Home")
            {
                BE_TYPE = "H";
            }
            else if (BE_TYPE == "Warehouse")
            {
                BE_TYPE = "W";
            }
            else if (BE_TYPE == "Ex-Bond")
            {
                BE_TYPE = "X";
            }


            CUSTOMS_HOUSE = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();

            IMPORTER_NAME = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
            ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
            ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
            ADDRESS3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
            ADDRESS4 = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
            ADDRESS5 = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
            IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
            BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
            COUNTRY_ORIGIN = ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString();
            PORT_ORIGIN = ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
            PORT_SHIPMENT = ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
            COUNTRY_SHIPMENT = ds.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString();

            FILING_STATUS = ds.Tables[0].Rows[0]["FILING_STATUS"].ToString();

            SECTION46 = ds.Tables[0].Rows[0]["SECTION46"].ToString();

            //SECTION46_DESC = ds.Tables[0].Rows[0]["SECTION46_DESC"].ToString();

            FIRSTCHECK = ds.Tables[0].Rows[0]["FIRSTCHECK"].ToString();

            FIRSTCHECK_DESC = ds.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString();

            GREEN_CHANNEL = ds.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString();

            //GREEN_CHANNEL_DESC = ds.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString();

            KACHHA_BE = ds.Tables[0].Rows[0]["KACHHA_BE"].ToString();

            //KACHHA_BE_DESC = ds.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString();

            SECTION48 = ds.Tables[0].Rows[0]["SECTION48"].ToString();

            SECTION48_DESC = ds.Tables[0].Rows[0]["SECTION48_DESC"].ToString();

            HIGH_SEA_SALE = ds.Tables[0].Rows[0]["HIGH_SEA_SALE"].ToString();

            HIGH_SEA_SALE_NAME = ds.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString();
            HIGH_SEA_IEC = ds.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString();
            HIGH_SEA_BRANCH_SL_NO = ds.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString();
            HSS_ADD1 = ds.Tables[0].Rows[0]["HSS_ADD1"].ToString();
            HSS_ADD2 = ds.Tables[0].Rows[0]["HSS_ADD2"].ToString();
            HSS_ADD3 = ds.Tables[0].Rows[0]["HSS_ADD3"].ToString();
            HSS_ADD4 = ds.Tables[0].Rows[0]["HSS_ADD4"].ToString();
            HSS_ADD5 = ds.Tables[0].Rows[0]["HSS_ADD5"].ToString();
            //WAREHOUSE_NAME = ds.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString();
            WAREHOUSE_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();


            if (FILING_STATUS == "P")
            {
                FILING_STATUS = "Y";
            }


            IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
            //updated 22 may 2013

            if (IMP_EXP_TYPE == "OTHERS" || IMP_EXP_TYPE == "")
            {
                IMP_EXP_TYPE = "P";
            }
            else if (IMP_EXP_TYPE == "GOVERNMENT")
            {
                IMP_EXP_TYPE = "G";
            }


            //HSS_ADD3_4 = HSS_ADD3 + HSS_ADD4;

            HSS_ADD3_4 = HSS_ADD3;

            COMMERCIAL_DETAILS_STATUS = ds.Tables[0].Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString();
            COMMERCIAL_TAX_STATECODE = ds.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString();
            COMMERCIAL_TAX_TYPE = ds.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString();
            COMMERCIAL_TAX_REGISTRATION_NO = ds.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString();

            EXBOND_INBOND_BE_NO = ds.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString();
            EXBOND_INBOND_BE_DATE = ds.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString().Replace("19000101", "");
            EXBOND_BOND_NO = ds.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString();
            EXBOND_BOND_DATE = ds.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString().Replace("19000101", "");
            EXBOND_WAREHOUSE_CUSTOMS = ds.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString();
            EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString();
            EXBOND_NOOFPACKAGE = ds.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString();
            EXBOND_NOOFPACKAGE_UNITCODE = ds.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString();
            EXBOND_GROSS_WEIGHT = ds.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString();
            EXBOND_GROSS_WEIGHT_UNITCODE = ds.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString();
            EXBOND_DIRECT_EXBONDING = ds.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString();

            JOB_STATUS = ds.Tables[0].Rows[0]["JOB_STATUS"].ToString();

            Authorized_Dealer_Code = ds.Tables[0].Rows[0]["ADCODE"].ToString();

            UCR_NO = ds.Tables[0].Rows[0]["UCR_NO"].ToString();
            UCR_TYPE = ds.Tables[0].Rows[0]["UCR_TYPE"].ToString();
            PAYMENT_METHOD_CODE = ds.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString();
            PRECEDING_LEVEL = ds.Tables[0].Rows[0]["PRECEDING_LEVEL"].ToString();



            Session.Remove("JOB_LOCK");
            Session["JOB_LOCK"] = JOB_STATUS;

            Get_Admin_Master_Codes();
        }

        if (ds.Tables[9].Rows.Count > 0)
        {
            BE_NO = ds.Tables[9].Rows[0]["BE_NO"].ToString();
            BE_DATE = ds.Tables[9].Rows[0]["BE_DATE"].ToString().Replace("19000101", "");
            BE_NO_OF_PACKAGES = ds.Tables[9].Rows[0]["BE_NO_OF_PACKAGES"].ToString();
            BE_PACKAGE_CODE = ds.Tables[9].Rows[0]["BE_PACKAGE_CODE"].ToString();
            BE_WEIGHT = ds.Tables[9].Rows[0]["BE_WEIGHT"].ToString();
            BE_UNIT_CODE = ds.Tables[9].Rows[0]["BE_UNIT_CODE"].ToString();
            BE_INBOND_NO = ds.Tables[9].Rows[0]["BE_INBOND_NO"].ToString();
            BE_INBOND_DATE = ds.Tables[9].Rows[0]["BE_INBOND_DATE"].ToString().Replace("19000101", "");
            BE_WAREHOUSE_CUSTOMS = ds.Tables[9].Rows[0]["BE_WAREHOUSE_CUSTOMS"].ToString();
            BE_WAREHOUSE_CUSTOMS_CODE = ds.Tables[9].Rows[0]["BE_WAREHOUSE_CUSTOMS_CODE"].ToString();
        }
    }
    public void Get_Admin_Master_Codes()
    {


        //Imp_Exp.Eimp_exp_id = "";
        //Imp_Exp.Eimp_exp_name = IMPORTER_NAME;
        //Imp_Exp.Eimp_exp_iecno = IEC_NO;
        //Imp_Exp.Eimp_exp_brslno = BRANCH_NO;
        //Imp_Exp.Ename = "Export_FlatFile_select_Type";
        //Imp_Exp.EWorking_Period = "";

        //Imp_Exp.startRowIndex = "0";
        //Imp_Exp.maximumRows = "0";
        //DataSet dsImp_Exp = new DataSet();

        //dsImp_Exp = Imp_Exp.RetrieveAll_Imp_exp_master();
        //if (dsImp_Exp.Tables[0].Rows.Count > 0)
        //{
        //    IMPORTER_CLASS = dsImp_Exp.Tables[0].Rows[0]["TYPE"].ToString();

        //    if (IMPORTER_CLASS == "O")
        //    {
        //        IMPORTER_CLASS = "P";
        //    }
        //}

        //IMPORTER_CLASS = FILING_STATUS;
        IMPORTER_CLASS = "N";
        Export_FlatFile_Generation Imp_FlatFile = new Export_FlatFile_Generation();


        Imp_FlatFile.Ename = "IMPORT_SELECT";

        dss = Imp_FlatFile.Search_Admin_Master();
        DataView view1 = dss.Tables[0].DefaultView;
        //view1.RowFilter = "STATE_NAME = '" + split.Split("-", ADDRESS4) + "'";
        ////DataTable table1 = view1.ToTable();
        //DataSet dt_UserRights = new DataSet();
        //dt_UserRights.Tables.Add(view1.ToTable());
        //if (dt_UserRights.Tables[0].Rows.Count > 0)
        //{
        //    ADDRESS4 = dt_UserRights.Tables[0].Rows[0]["STATE_CODE"].ToString();
        //}


        view1 = dss.Tables[1].DefaultView;
        view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_ORIGIN) + "'";
        DataSet dt_1 = new DataSet();
        dt_1.Tables.Add(view1.ToTable());
        if (dt_1.Tables[0].Rows.Count > 0)
        {
            COUNTRY_ORIGIN = dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
        }
        view1 = dss.Tables[1].DefaultView;

        view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_SHIPMENT) + "'";

        DataSet ds1 = new DataSet();
        ds1.Tables.Add(view1.ToTable());
        if (ds1.Tables[0].Rows.Count > 0)
        {
            COUNTRY_SHIPMENT = ds1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
        }
        if (PORT_ORIGIN.Contains("-"))
        {
            PORT_ORIGIN = split.Split_main("-", PORT_ORIGIN);
        }
        if (PORT_SHIPMENT.Contains("-"))
        {

            PORT_SHIPMENT = split.Split_main("-", PORT_SHIPMENT);
        }
        //view1 = dss.Tables[2].DefaultView;
        //if (TRANSPORT_MODE == "Air" || TRANSPORT_MODE == "A")
        //{

        //    view1.RowFilter = "PORT_NAME = '" + split.Split("-", PORT_ORIGIN) + "' and len(PORT_CODE) = 3";
        //    DataSet ds2 = new DataSet();

        //    ds2.Tables.Add(view1.ToTable());
        //    if (ds2.Tables[0].Rows.Count > 0)
        //    {
        //        PORT_ORIGIN = ds2.Tables[0].Rows[0]["PORT_CODE"].ToString();
        //    }

        //    view1.RowFilter = "PORT_NAME = '" + split.Split("-", PORT_SHIPMENT) + "' and len(PORT_CODE) = 3";
        //    DataSet ds3 = new DataSet();

        //    ds3.Tables.Add(view1.ToTable());
        //    if (ds3.Tables[0].Rows.Count > 0)
        //    {
        //        PORT_SHIPMENT = ds3.Tables[0].Rows[0]["PORT_CODE"].ToString();
        //    }
        //}
        //else
        //{

        //    view1.RowFilter = "PORT_NAME = '" + split.Split("-", PORT_ORIGIN) + "' and len(PORT_CODE) = 5";
        //    DataSet ds4 = new DataSet();

        //    ds4.Tables.Add(view1.ToTable());

        //    if (ds4.Tables[0].Rows.Count > 0)
        //    {
        //        PORT_ORIGIN = ds4.Tables[0].Rows[0]["PORT_CODE"].ToString();
        //    }
        //    view1.RowFilter = "PORT_NAME = '" + split.Split("-", PORT_SHIPMENT) + "' and len(PORT_CODE) = 5";
        //    DataSet ds5 = new DataSet();

        //    ds5.Tables.Add(view1.ToTable());

        //    if (ds5.Tables[0].Rows.Count > 0)
        //    {
        //        PORT_SHIPMENT = ds5.Tables[0].Rows[0]["PORT_CODE"].ToString();
        //    }
        //}
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //FlatFile.Get_AllDetails(ddlJobNo.SelectedValue.ToString());

        BE_Details();

        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            DataSet ds2 = new DataSet();
            Transaction Transact = new Transaction();
            Transact.JOBID = "";
            Transact.JOBNO = ddlJobNo.SelectedValue.ToString();
            Transact.IMPORTER_NAME = "";
            Transact.TRANSPORT_MODE = "";
            Transact.CUSTOMS_HOUSE = "";
            Transact.Ename = "select_Id_Submission";
            Transact.WORKING_PERIOD = SELECT_BRANCH;

            ds2 = Transact.RetrieveAll_General_Details();

            JOB_LOCK = ds2.Tables[0].Rows[0]["JOB_STATUS"].ToString();
            JOB_RELEASE = ds2.Tables[0].Rows[0]["JOB_RELEASE"].ToString();
            JOB_USER = ds2.Tables[0].Rows[0]["USERID"].ToString();

            Session["JOB_LOCK"] = JOB_LOCK;
            Session["JOB_RELEASE"] = JOB_RELEASE;
            Session["JOB_USER"] = JOB_USER;

        }



        if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
        {
            JOB_LOCK = Session["JOB_LOCK"].ToString();

            if (Convert.ToInt32(JOB_LOCK) == 1)
            {
                btnSearch.Enabled = false;
                btnSubmission.Enabled = false;

                imgbtnFlatFile.Enabled = false;
                btnSubmission.Enabled = false;

                Alert_msg("This Job is Locked by Admin");
            }

            else
            {
                try
                {
                    //-----------------------------------------------------------------------------------------------------------------------------------------------
                    if (ddlJobNo.SelectedItem.Text != "Select")
                    {
                        if (Session["USER_JOB_LOCK"].ToString() == "Yes")
                        {

                            if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
                            {
                                if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                                {
                                    JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                                    if (JOB_RELEASE == "No")
                                    {
                                        btnSubmission.Enabled = false;

                                        imgbtnFlatFile.Enabled = false;

                                        MP_U.Show();
                                        lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                        btnSubmission.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                    }
                                }
                            }
                            else
                            {
                                imgbtnFlatFile.Enabled = true;
                                btnSubmission.Enabled = true;

                                //test start
                                IS_Imgbtn = "";

                                //BE_Details();
                                imgbtnFlatFile.Visible = false;
                                btnSubmission.Visible = false;

                                if (File.Exists(errorFolder + logFileName))
                                {
                                    DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                    foreach (FileInfo fi in dir.GetFiles())
                                    {
                                        fi.Delete();
                                    }

                                    Flat_File();

                                    imgbtnFlatFile.Visible = true;
                                    btnSubmission.Visible = true;

                                }

                                else
                                {

                                    DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                    foreach (FileInfo fi in dir.GetFiles())
                                    {
                                        fi.Delete();
                                    }

                                    Flat_File();

                                    imgbtnFlatFile.Visible = true;
                                    btnSubmission.Visible = true;

                                }

                            }
                            //test end
                        }
                    }


                    //---------------------------------------------------------------------------------------------------------------------------------------------------


                }

                catch (Exception ex)
                {

                    er.makeLog(ex.Message);
                }
            }
        }
        else
        {


            try
            {
                //------------------------------------------------------------------------------------------------------
                if (ddlJobNo.SelectedItem.Text != "Select")
                {
                    if (Session["USER_JOB_LOCK"].ToString() == "Yes")
                    {

                        if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
                        {
                            if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                            {
                                JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                                if (JOB_RELEASE == "No")
                                {

                                    btnSubmission.Enabled = false;
                                    imgbtnFlatFile.Enabled = false;

                                    MP_U.Show();
                                    lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                    btnSubmission.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";


                                }
                                else
                                {
                                    IS_Imgbtn = "";
                                    //BE_Details();
                                    imgbtnFlatFile.Visible = false;
                                    btnSubmission.Visible = false;

                                    imgbtnFlatFile.Enabled = true;
                                    btnSubmission.Enabled = true;

                                    if (File.Exists(errorFolder + logFileName))
                                    {
                                        DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                        foreach (FileInfo fi in dir.GetFiles())
                                        {
                                            fi.Delete();
                                        }

                                        Flat_File();

                                        imgbtnFlatFile.Visible = true;
                                        btnSubmission.Visible = true;

                                    }

                                    else
                                    {

                                        DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                        foreach (FileInfo fi in dir.GetFiles())
                                        {
                                            fi.Delete();
                                        }

                                        Flat_File();

                                        imgbtnFlatFile.Visible = true;
                                        btnSubmission.Visible = true;

                                    }





                                }
                            }



                        }
                        else
                        {
                            IS_Imgbtn = "";
                            //BE_Details();
                            imgbtnFlatFile.Visible = false;
                            btnSubmission.Visible = false;

                            imgbtnFlatFile.Enabled = true;
                            btnSubmission.Enabled = true;

                            if (File.Exists(errorFolder + logFileName))
                            {
                                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                foreach (FileInfo fi in dir.GetFiles())
                                {
                                    fi.Delete();
                                }

                                Flat_File();

                                imgbtnFlatFile.Visible = true;
                                btnSubmission.Visible = true;

                            }

                            else
                            {

                                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                foreach (FileInfo fi in dir.GetFiles())
                                {
                                    fi.Delete();
                                }

                                Flat_File();

                                imgbtnFlatFile.Visible = true;
                                btnSubmission.Visible = true;

                            }

                        }

                        //------------------------------------------------------------------------------------------------------

                    }

                    else
                    {
                        IS_Imgbtn = "";
                        //BE_Details();
                        imgbtnFlatFile.Visible = false;
                        btnSubmission.Visible = false;

                        imgbtnFlatFile.Enabled = true;
                        btnSubmission.Enabled = true;

                        if (File.Exists(errorFolder + logFileName))
                        {
                            DirectoryInfo dir = new DirectoryInfo(errorFolder);

                            foreach (FileInfo fi in dir.GetFiles())
                            {
                                fi.Delete();
                            }

                            Flat_File();

                            imgbtnFlatFile.Visible = true;
                            btnSubmission.Visible = true;

                        }

                        else
                        {
                            DirectoryInfo dir = new DirectoryInfo(errorFolder);
                            foreach (FileInfo fi in dir.GetFiles())
                            {
                                fi.Delete();
                            }

                            Flat_File();

                            imgbtnFlatFile.Visible = true;
                            btnSubmission.Visible = true;
                        }



                        //-------------------rrrr
                    }

                }

            }

            catch (Exception ex)
            {

                er.makeLog(ex.Message);
            }
        }
        btnSearch.Enabled = true;

        //-------------------------------------------------------------------------------------------------------




    }




    protected void imgbtnFlatFile_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            IS_Imgbtn = "1";
            BE_Details();
            imgbtnFlatFile.Visible = false;
            btnSubmission.Visible = false;

            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File();

                imgbtnFlatFile.Visible = true;
                btnSubmission.Visible = true;

            }

            else
            {


                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File();

                imgbtnFlatFile.Visible = true;
                btnSubmission.Visible = true;

            }

        }

        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void btnSubmission_Click(object sender, EventArgs e)
    {
        try
        {
            IS_Imgbtn = "";

            BE_Details();
            imgbtnFlatFile.Visible = false;

            btnSubmission.Visible = false;
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File();

                mail(errorFolder + logFileName);

                imgbtnFlatFile.Visible = true;
                btnSubmission.Visible = true;

            }

            else
            {

                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File();

                mail(errorFolder + logFileName);

                imgbtnFlatFile.Visible = true;
                btnSubmission.Visible = true;
            }

        }

        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }
    }

    public void Flat_File()
    {

        DateTime date = System.DateTime.Now;
        string datestringg = string.Format("{0:yyyyMMdd}", date);

        DateTime tt = System.DateTime.Now;

        string time = string.Format("{0:hhmm}", tt);

        GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
        string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();

        logFileName = ddlJobNo.SelectedValue.ToString() + yy + ".be";
        createfilename = logFileName;
        Session["createflename"] = logFileName;
        sw = new StreamWriter(errorFolder + logFileName, true);



        if (BE_TYPE == "X")
        {
            sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + BE_TYPE + ch + "CACHI01" + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + time);
        }
        else
        {
            sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + ch + "CACHI01" + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + time);
        }
        sw.WriteLine("<TABLE>BE");


        //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + BE_TYPE + ch + IEC_NO + ch + BRANCH_NO + ch + IMPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + IMPORTER_CLASS + ch + TRANSPORT_MODE + ch + IMP_EXP_TYPE + ch + KACHHA_BE + ch + HIGH_SEA_SALE + ch + PORT_ORIGIN + ch + "CHA CODE" + ch + COUNTRY_ORIGIN + ch + COUNTRY_SHIPMENT + ch + PORT_SHIPMENT + ch + GREEN_CHANNEL + ch + SECTION48 + ch + FILING_STATUS + Authorized_Dealer_Code + FIRSTCHECK + ch + WAREHOUSE_CODE + ch + "Warehouse Customs Site ID" + ch + "Ware house BE No" + ch + "Ware house BE Date" + ch + "No of packages released" + ch + "PACKAGE CODE" + ch + "GROSS WEIGHT" + ch + "UNIT OF MEASUREMENT" + ch + "Loading for X-Bond Over Ware-House BE" + ch + "Miscellaneous load Rate" + time);
        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + BE_TYPE + ch + IEC_NO + ch + BRANCH_NO + ch + IMPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + IMPORTER_CLASS + ch + TRANSPORT_MODE + ch + IMP_EXP_TYPE + ch + KACHHA_BE + ch + HIGH_SEA_SALE + ch + PORT_ORIGIN + ch + CHA_NO + ch + COUNTRY_ORIGIN + ch + COUNTRY_SHIPMENT + ch + PORT_SHIPMENT + ch + GREEN_CHANNEL + ch + SECTION48 + ch + FILING_STATUS + ch + Authorized_Dealer_Code + ch + FIRSTCHECK + ch + EXBOND_WAREHOUSE_CUSTOMS_CODE + ch + EXBOND_WAREHOUSE_CUSTOMS + ch + EXBOND_INBOND_BE_NO + ch + EXBOND_INBOND_BE_DATE + ch + EXBOND_NOOFPACKAGE + ch + EXBOND_NOOFPACKAGE_UNITCODE + ch + EXBOND_GROSS_WEIGHT + ch + EXBOND_GROSS_WEIGHT_UNITCODE + ch + LOADING_EXBOND_WARWHOUSE + ch + MISC_LOAD_RATE + ch + UCR_NO + ch + UCR_TYPE + ch + PAYMENT_METHOD_CODE);//+ time);

        if (BE_TYPE == "X")
        {
            //No need to display IGM when BE TYPE is EX-BOND

        }
        else
        {
            sw.WriteLine("<TABLE>EXCHANGE");

            if (ds.Tables[1].Rows.Count > 0)
            {
                INVOICE_CURRENCY = dt.Trim(ds.Tables[1].Rows[0]["INVOICE_CURRENCY"].ToString());
                INVOICE_EXRATE = dt.Trim(ds.Tables[1].Rows[0]["INVOICE_EXRATE"].ToString());
                MIS_FREIGHT_CURRENCY = dt.Trim(ds.Tables[1].Rows[0]["MIS_FREIGHT_CURRENCY"].ToString());
                MIS_FREIGHT_EXRATE = dt.Trim(ds.Tables[1].Rows[0]["MIS_FREIGHT_EXRATE"].ToString());
                MIS_INSURANCE_CURRENCY = dt.Trim(ds.Tables[1].Rows[0]["MIS_INSURANCE_CURRENCY"].ToString());
                MIS_INSURANCE_EXRATE = dt.Trim(ds.Tables[1].Rows[0]["MIS_INSURANCE_EXRATE"].ToString());
                MIS_CURRENCY = dt.Trim(ds.Tables[1].Rows[0]["MIS_CURRENCY"].ToString());
                MIS_EXRATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[0]["MIS_EXRATE"].ToString()));

                NON_STD_CERTIFICATE_NO = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString());


                //if (COMPANY_ID == "158")
                //{
                //    NON_STD_EFFECT_DT_IMP = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString().Replace("19000101", ""));
                //    NON_STD_BANKNAME = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_BANKNAME"].ToString());
                //    NON_STD_CERTIFICATE_NO = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString());
                //    NON_STD_CERTIFICATE_DATE = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString().Replace("19000101", ""));
                //}
                //else if (currentcomp_name == "Royal Tech Systems")
                //{
                //    NON_STD_EFFECT_DT_IMP = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString().Replace("19000101", ""));
                //    NON_STD_BANKNAME = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_BANKNAME"].ToString());
                //    NON_STD_CERTIFICATE_NO = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString());
                //    NON_STD_CERTIFICATE_DATE = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString().Replace("19000101", ""));
                //}

                //---------------For Non Standard Currency on 01Sep2015----------------//
                //Standard_Currency = "";
                //if (NON_STD_CERTIFICATE_NO != "")
                //{
                //    NON_STD_EFFECT_DT_IMP = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString().Replace("19000101", ""));
                //    NON_STD_BANKNAME = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_BANKNAME"].ToString());
                //    NON_STD_CERTIFICATE_NO = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString());
                //    NON_STD_CERTIFICATE_DATE = dt.Trim(ds.Tables[1].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString().Replace("19000101", ""));
                //    Standard_Currency = "N";

                //}
                //else
                //{
                //    NON_STD_EFFECT_DT_IMP = "";
                //    NON_STD_BANKNAME = "";
                //    NON_STD_CERTIFICATE_NO = "";
                //    NON_STD_CERTIFICATE_DATE = "";
                //    Standard_Currency = "Y";
                //}
                //---------------For Non Standard Currency on 01Sep2015----------------//

                int gg = 0;

                if (ds.Tables[10].Rows.Count > 0)
                {
                    while (ds.Tables[10].Rows.Count > gg)
                    {
                        INVOICE_CURRENCY = dt.Trim(ds.Tables[10].Rows[gg]["INVOICE_CURRENCY"].ToString());
                        //INVOICE_EXRATE = dt.Trim(ds.Tables[10].Rows[gg]["EX_RATE"].ToString());
                        string EXRATE = "";

                        //---------------For Non Standard Currency on 01Sep2015----------------//
                        Standard_Currency = "";
                        DataView view1 = dss.Tables[3].DefaultView;
                        view1.RowFilter = "EXCHANGE_CUR_CODE = '" + INVOICE_CURRENCY + "'";
                        DataSet dt_1 = new DataSet();
                        dt_1.Tables.Add(view1.ToTable());
                        if (dt_1.Tables[0].Rows.Count > 0)
                        {
                            INVOICE_EXRATE = dt_1.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                            Standard_Currency = "Y";
                            NON_STD_EFFECT_DT_IMP = "";
                            NON_STD_BANKNAME = "";
                            NON_STD_CERTIFICATE_NO = "";
                            NON_STD_CERTIFICATE_DATE = "";
                        }
                        else
                        {
                            DataView view2 = ds.Tables[1].DefaultView;

                            view2.RowFilter = "INVOICE_CURRENCY = '" + INVOICE_CURRENCY + "'";
                            DataSet dt_2 = new DataSet();
                            dt_2.Tables.Add(view2.ToTable());

                            if (dt_2.Tables[0].Rows.Count > 0)
                            {
                                NON_STD_EFFECT_DT_IMP = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString().Replace("19000101", ""));
                                NON_STD_BANKNAME = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString());
                                NON_STD_CERTIFICATE_NO = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString());
                                NON_STD_CERTIFICATE_DATE = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString().Replace("19000101", ""));
                                INVOICE_EXRATE = dt.Trim(dt_2.Tables[0].Rows[0]["INVOICE_EXRATE"].ToString());
                                Standard_Currency = "N";
                            }


                        }


                        //---------------For Non Standard Currency on 01Sep2015----------------//

                        if (INVOICE_CURRENCY != "")

                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + NON_STD_EFFECT_DT_IMP + ch + NON_STD_BANKNAME + ch + NON_STD_CERTIFICATE_NO + ch + NON_STD_CERTIFICATE_DATE);

                        //if (currentcomp_name == "Royal Tech Systems")
                        //{
                        //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXRATE + ch + NON_STD_EFFECT_DT_IMP + ch + NON_STD_BANKNAME + ch + NON_STD_CERTIFICATE_NO + ch + NON_STD_CERTIFICATE_DATE);
                        //}
                        //else
                        //{
                        //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                        //}


                        gg++;
                    }
                }


                //if (INVOICE_CURRENCY == MIS_FREIGHT_CURRENCY)
                //{
                //    if (INVOICE_CURRENCY == MIS_INSURANCE_CURRENCY)
                //    {
                //        if (INVOICE_CURRENCY == MIS_CURRENCY)
                //            //l1.Text = " A = B = C = D";

                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //        else
                //        {
                //            //l1.Text = " A = B = C ";
                //            //l2.Text = " D ";

                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_CURRENCY) + ch + MIS_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //        }
                //    }
                //    else
                //    {
                //        if (INVOICE_CURRENCY == MIS_CURRENCY)
                //        {
                //            //l1.Text = " A = B = D";
                //            //l2.Text = " C";

                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        }
                //        else
                //        {
                //            if (MIS_INSURANCE_CURRENCY == MIS_CURRENCY)
                //            {
                //                //l1.Text = " A = B ";
                //                //l2.Text = " C = D ";

                //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //            }
                //            else
                //            {
                //                //l1.Text = " A = B ";
                //                //l2.Text = " C";
                //                //l3.Text = " D";

                //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_CURRENCY) + ch + MIS_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            }
                //        }
                //    }

                //}
                //else if (INVOICE_CURRENCY == MIS_INSURANCE_CURRENCY)
                //{
                //    if (INVOICE_CURRENCY == MIS_CURRENCY)
                //    {
                //        //l1.Text = " A = C = D ";
                //        //l2.Text = " B ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //    }
                //    else
                //    {
                //        if (MIS_FREIGHT_CURRENCY == MIS_CURRENCY)
                //        {
                //            //l1.Text = " A = C ";
                //            //l2.Text = " B = D ";

                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //        }
                //        else
                //        {
                //            //l1.Text = " A = C ";
                //            //l2.Text = " B ";
                //            //l3.Text = " D ";

                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_CURRENCY) + ch + MIS_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //        }
                //    }
                //}

                //else if (INVOICE_CURRENCY == MIS_CURRENCY)
                //{
                //    if (MIS_FREIGHT_CURRENCY == MIS_INSURANCE_CURRENCY)
                //    {
                //        //l1.Text = " A = D ";
                //        //l2.Text = " B = C ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);


                //    }
                //    else
                //    {
                //        //l1.Text = " A = D ";
                //        //l2.Text = " B ";
                //        //l3.Text = " C ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //    }

                //}
                //else if (MIS_FREIGHT_CURRENCY == MIS_INSURANCE_CURRENCY)
                //{
                //    if (MIS_FREIGHT_CURRENCY == MIS_CURRENCY)
                //    {
                //        //l1.Text = " A ";
                //        //l2.Text = " B = C = D ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //    }
                //    else
                //    {
                //        //l1.Text = " A ";
                //        //l2.Text = " B = C ";
                //        //l3.Text = " D ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_CURRENCY) + ch + MIS_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    }
                //}
                //else if (MIS_FREIGHT_CURRENCY == MIS_CURRENCY)
                //{
                //    if (MIS_INSURANCE_CURRENCY == MIS_CURRENCY)
                //    {
                //        //l1.Text = " A ";
                //        //l2.Text = " B = C = D ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //    }
                //    else
                //    {
                //        //l1.Text = " A ";
                //        //l2.Text = " B = D ";
                //        //l3.Text = " C ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    }
                //}
                //else if (MIS_INSURANCE_CURRENCY == MIS_CURRENCY)
                //{
                //    //l1.Text = " A ";
                //    //l2.Text = " B ";
                //    //l3.Text = " C = D ";

                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //}
                //else
                //{
                //    //l1.Text = " A ";
                //    //l2.Text = " B ";
                //    //l3.Text = " C ";
                //    //l4.Text = " D ";

                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_CURRENCY) + ch + MIS_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //}




            }
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (SECTION48 == "Y" || FIRSTCHECK == "Y")
            {
                sw.WriteLine("<TABLE>PERMISSION");

                if (SECTION48 == "Y")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + "S48" + ch + SECTION48_DESC);
                }
                else if (FIRSTCHECK == "Y")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + "FCK" + ch + FIRSTCHECK_DESC);
                }

            }

        }


        int i = 0;

        if (ds.Tables[1].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>INVOICE");
            while (ds.Tables[1].Rows.Count > i)
            {
                INVOICE_SLNO = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_SLNO"].ToString());
                INVOICE_NO = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_NO"].ToString());
                INVOICE_DATE = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_DATE"].ToString().Replace("19000101", ""));
                OTHER_PURCHASE_ORDER = dt.Trim(ds.Tables[1].Rows[i]["OTHER_PURCHASE_ORDER"].ToString());
                OTHER_PURCHASE_ORDER_DATE = dt.Trim(ds.Tables[1].Rows[i]["OTHER_PURCHASE_ORDER_DATE"].ToString().Replace("19000101", ""));
                OTHER_CONTRACT_NO = dt.Trim(ds.Tables[1].Rows[i]["OTHER_CONTRACT_NO"].ToString());
                OTHER_CONTRACT_DATE = dt.Trim(ds.Tables[1].Rows[i]["OTHER_CONTRACT_DATE"].ToString().Replace("19000101", ""));
                OTHER_LOC_NO = dt.Trim(ds.Tables[1].Rows[i]["OTHER_LOC_NO"].ToString());
                OTHER_LOC_DATE = dt.Trim(ds.Tables[1].Rows[i]["OTHER_LOC_DATE"].ToString().Replace("19000101", ""));

                SVB_RELATION = dt.Trim(ds.Tables[1].Rows[i]["SVB_RELATION"].ToString());

                if (SVB_RELATION == "Y")
                {
                    SVB_REF_NO = dt.Trim(ds.Tables[1].Rows[i]["SVB_REF_NO"].ToString());
                    SVB_REF_DATE = dt.Trim(ds.Tables[1].Rows[i]["SVB_REF_DATE"].ToString().Replace("19000101", ""));
                    SVB_CUSTOM_HOUSE = dt.Trim(ds.Tables[1].Rows[i]["SVB_CUSTOM_HOUSE"].ToString());
                    SVB_LOADING_ON = dt.Trim(ds.Tables[1].Rows[i]["SVB_LOADING_ON"].ToString());
                    SVB_ASSESABLE_RATE = dt.Trim(ds.Tables[1].Rows[i]["SVB_ASSESABLE_RATE"].ToString());
                    SVB_DUTY_RATE = dt.Trim(ds.Tables[1].Rows[i]["SVB_DUTY_RATE"].ToString());

                    SVB_ASSESABLE_STATUS = dt.Trim(ds.Tables[1].Rows[i]["SVB_ASSESABLE_STATUS"].ToString());
                    SVB_DUTY_STATUS = dt.Trim(ds.Tables[1].Rows[i]["SVB_DUTY_STATUS"].ToString());
                }
                else
                {
                    SVB_REF_NO = "";
                    SVB_REF_DATE = "";
                    SVB_CUSTOM_HOUSE = "";
                    SVB_LOADING_ON = "";
                    SVB_ASSESABLE_RATE = "";
                    SVB_DUTY_RATE = "";

                    SVB_ASSESABLE_STATUS = "";
                    SVB_DUTY_STATUS = "";
                }


                INVOICE_VALUE = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_VALUE"].ToString());
                TERMS = dt.Trim(ds.Tables[1].Rows[i]["TERMS"].ToString());
                INVOICE_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_CURRENCY"].ToString());
                //Nature_of_Discount = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_CURRENCY"].ToString());
                MIS_DISCOUNT_RATE = dt.Get_Nullval(dt.Num_Trim(ds.Tables[1].Rows[i]["MIS_DISCOUNT_RATE"].ToString()));
                MIS_DISCOUNT_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_DISCOUNT_CHARGES"].ToString()));
                MIS_DISCOUNT_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["MIS_DISCOUNT_CURRENCY"].ToString());

                MIS_HIGHSEASALE_RATE = dt.Get_Nullval(dt.Num_Trim(ds.Tables[1].Rows[i]["MIS_HIGHSEASALE_RATE"].ToString()));
                MIS_HIGHSEASALE_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_HIGHSEASALE_CHARGES"].ToString()));
                MIS_HIGHSEASALE_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["MIS_HIGHSEASALE_CURRENCY"].ToString());

                MIS_FREIGHT_RATE = dt.Get_Nullval(dt.Num_Trim(ds.Tables[1].Rows[i]["MIS_FREIGHT_RATE"].ToString()));
                MIS_FREIGHT_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_FREIGHT_CHARGES"].ToString()));
                MIS_FREIGHT_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["MIS_FREIGHT_CURRENCY"].ToString());

                MIS_INSURANCE_RATE = dt.Get_Nullval_New(dt.Num_Trim(ds.Tables[1].Rows[i]["MIS_INSURANCE_RATE"].ToString()));
                MIS_INSURANCE_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_INSURANCE_CHARGES"].ToString()));
                MIS_INSURANCE_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["MIS_INSURANCE_CURRENCY"].ToString());

                MIS_RATE = dt.Get_Nullval(dt.Num_Trim(ds.Tables[1].Rows[i]["MIS_RATE"].ToString()));
                MIS_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_CHARGES"].ToString()));
                MIS_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["MIS_CURRENCY"].ToString());

                MIS_LOADING_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_LOADING_RATE"].ToString()));
                MIS_LOADING_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_LOADING_CHARGES"].ToString()));
                MIS_LOADING_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["MIS_LOADING_CURRENCY"].ToString());

                MIS_AGENCY_RATE = dt.Get_Nullval(dt.Num_Trim(ds.Tables[1].Rows[i]["MIS_AGENCY_RATE"].ToString()));
                MIS_AGENCY_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_AGENCY_CHARGES"].ToString()));
                MIS_AGENCY_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["MIS_AGENCY_CURRENCY"].ToString());
                //string sss=ds.Tables[1].Rows[i]["OTHER_TERMS_OF_PAYMENT"].ToString();

                OTHER_NATURE_OF_TRANSACTION = dt.Trim(ds.Tables[1].Rows[i]["OTHER_NATURE_OF_TRANSACTION"].ToString());
                //OTHER_TERMS_OF_PAYMENT = dt.Trim(dt.Split(" ",(ds.Tables[1].Rows[i]["OTHER_TERMS_OF_PAYMENT"].ToString());

                OTHER_TERMS_OF_PAYMENT = dt.Trim(ds.Tables[1].Rows[i]["OTHER_TERMS_OF_PAYMENT"].ToString());
                OTHER_VALUATION_METHOD = dt.Trim(ds.Tables[1].Rows[i]["OTHER_VALUATION_METHOD"].ToString());

                SUPPLIER_NAME = dt.Trim(ds.Tables[1].Rows[i]["SUPPLIER_NAME"].ToString());
                SUPPLIER_ADDRESS = dt.Trim(ds.Tables[1].Rows[i]["SUPPLIER_ADDRESS"].ToString());
                SUPPLIER_ADDRESS1 = dt.Trim(ds.Tables[1].Rows[i]["SUPPLIER_ADDRESS1"].ToString());
                SUPPLIER_ADDRESS2 = dt.Trim(ds.Tables[1].Rows[i]["SUPPLIER_ADDRESS2"].ToString());
                SUPPLIER_COUNTRY_NAME = dt.Trim(split.Split("-", ds.Tables[1].Rows[i]["SUPPLIER_COUNTRY_NAME_NEW"].ToString()));
                SUPPLIER_COUNTRY_CODE = dt.Trim(ds.Tables[1].Rows[i]["SUPPLIER_COUNTRY_CODE"].ToString());
                SUPPLIER_COUNTRY_PINCODE = dt.Trim(ds.Tables[1].Rows[i]["SUPPLIER_COUNTRY_PINCODE"].ToString());

                SELLER_NAME = dt.Trim(ds.Tables[1].Rows[i]["SELLER_NAME"].ToString());
                SELLER_ADDRESS = dt.Trim(ds.Tables[1].Rows[i]["SELLER_ADDRESS"].ToString());
                SELLER_ADDRESS1 = dt.Trim(ds.Tables[1].Rows[i]["SELLER_ADDRESS1"].ToString());
                SELLER_ADDRESS2 = dt.Trim(ds.Tables[1].Rows[i]["SELLER_ADDRESS2"].ToString());
                SELLER_COUNTRY_NAME = dt.Trim(split.Split("-", ds.Tables[1].Rows[i]["SELLER_COUNTRY_NAME"].ToString()));
                SELLER_COUNTRY_CODE = dt.Trim(ds.Tables[1].Rows[i]["SELLER_COUNTRY_CODE"].ToString());
                SELLERCOUNTRY_PINCODE = dt.Trim(ds.Tables[1].Rows[i]["SELLERCOUNTRY_PINCODE"].ToString());

                BROKER_NAME = dt.Trim(ds.Tables[1].Rows[i]["BROKER_NAME"].ToString());
                BROKER_ADDRESS = dt.Trim(ds.Tables[1].Rows[i]["BROKER_ADDRESS"].ToString());
                BROKER_ADDRESS1 = dt.Trim(ds.Tables[1].Rows[i]["BROKER_ADDRESS1"].ToString());
                BROKER_ADDRESS2 = dt.Trim(ds.Tables[1].Rows[i]["BROKER_ADDRESS2"].ToString());
                BROKER_COUNTRY_NAME = dt.Trim(split.Split("-", ds.Tables[1].Rows[i]["BROKER_COUNTRY_NAME"].ToString()));
                BROKER_COUNTRY_CODE = dt.Trim(ds.Tables[1].Rows[i]["BROKER_COUNTRY_CODE"].ToString());
                BROKER_COUNTRY_PINCODE = dt.Trim(ds.Tables[1].Rows[i]["BROKER_COUNTRY_PINCODE"].ToString());
                string MIS_SINGLE_OR_MULTIPLE = dt.Trim(ds.Tables[1].Rows[i]["MIS_SINGLE_OR_MULITIPLE"].ToString());

                MI_FREIGHT = dt.Trim(ds.Tables[1].Rows[i]["MI_FREIGHT"].ToString());
                MI_INSURANCE = dt.Trim(ds.Tables[1].Rows[i]["MI_INSURANCE"].ToString());
                                
                TERMS_PLACE = dt.Trim(ds.Tables[1].Rows[i]["TERMS_PLACE"].ToString());
                THIRDPARTY_NAME = dt.Trim(ds.Tables[1].Rows[i]["THIRDPARTY_NAME"].ToString());
                THIRDPARTY_ADD1 = dt.Trim(ds.Tables[1].Rows[i]["THIRDPARTY_ADD1"].ToString());
                THIRDPARTY_ADD2 = dt.Trim(ds.Tables[1].Rows[i]["THIRDPARTY_ADD2"].ToString());
                THIRDPARTY_CITY = dt.Trim(ds.Tables[1].Rows[i]["THIRDPARTY_CITY"].ToString());
                T_PARTY_COUNTRY_SUB_DIV = dt.Trim(ds.Tables[1].Rows[i]["T_PARTY_COUNTRY_SUB_DIV"].ToString());
                T_PARTY_COUNTRY_CODE = dt.Trim(ds.Tables[1].Rows[i]["T_PARTY_COUNTRY_CODE"].ToString());
                T_PARTY_PIN = dt.Trim(ds.Tables[1].Rows[i]["T_PARTY_PIN"].ToString());
                AUTHORIZED_ECONOMIC_OPERATOR_CODE = dt.Trim(ds.Tables[1].Rows[i]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString());
                A_E_O_COUNTRY = dt.Trim(ds.Tables[1].Rows[i]["A_E_O_COUNTRY"].ToString());
                AUTHORIZED_ECONOMIC_OPERATOR = dt.Trim(ds.Tables[1].Rows[i]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString());
                WHETHER_BUYER_SELLER_RELATED = dt.Trim(ds.Tables[1].Rows[i]["WHETHER_BUYER_SELLER_RELATED"].ToString());
                
                //IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                //BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                //COUNTRY_ORIGIN = ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString();
                //PORT_ORIGIN = ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
                //PORT_SHIPMENT = ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
                //COUNTRY_SHIPMENT = ds.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString();
                //FILING_STATUS = ds.Tables[0].Rows[0]["FILING_STATUS"].ToString();
                //SECTION46 = ds.Tables[0].Rows[0]["SECTION46"].ToString();

                if (MIS_SINGLE_OR_MULTIPLE == "M")
                {
                    if (MIS_CHARGES != "")
                    {
                        //MIS_CURRENCY = "";
                        //MIS_CHARGES = "";
                        MIS_RATE = "";
                    }
                    else if (MIS_CHARGES == "" || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
                    {
                        MIS_CURRENCY = "";
                        MIS_CHARGES = "";

                    }

                    if (MIS_AGENCY_CHARGES != "")
                    {
                        //MIS_AGENCY_CURRENCY = "";
                        //MIS_AGENCY_CHARGES = "";
                        MIS_AGENCY_RATE = "";
                    }
                    else if (MIS_AGENCY_CHARGES == "" || MIS_AGENCY_CHARGES == "0" || MIS_AGENCY_CHARGES == "0.00")
                    {
                        MIS_AGENCY_CURRENCY = "";
                        MIS_AGENCY_CHARGES = "";

                    }



                    if (MIS_DISCOUNT_CHARGES != "")
                    {
                        //MIS_DISCOUNT_CURRENCY = "";
                        //MIS_DISCOUNT_CHARGES = "";
                        MIS_DISCOUNT_RATE = "";
                    }



                    if (MIS_LOADING_CHARGES != "")
                    {
                        //MIS_LOADING_CURRENCY = "";
                        //MIS_LOADING_CHARGES = "";
                        MIS_LOADING_RATE = "";
                    }


                    if (MI_FREIGHT == "Amt" || MI_FREIGHT == "")
                    {

                        if (MIS_FREIGHT_CHARGES != "")
                        {
                            //MIS_FREIGHT_CURRENCY = "";
                            //MIS_FREIGHT_CHARGES = "";
                            MIS_FREIGHT_RATE = "";
                        }
                    }
                    else if (MI_FREIGHT == "Rate")
                    {
                        if (MIS_FREIGHT_RATE != "")
                        {
                            MIS_FREIGHT_CURRENCY = "";
                            MIS_FREIGHT_CHARGES = "";
                        }
                    }



                    if (MI_INSURANCE == "Amt" || MI_INSURANCE == "")
                    {

                        if (MIS_INSURANCE_CHARGES != "")
                        {
                            //MIS_INSURANCE_CURRENCY = "";
                            //MIS_INSURANCE_CHARGES = "";
                            MIS_INSURANCE_RATE = "";
                        }
                    }
                    else if (MI_INSURANCE == "Rate")
                    {
                        if (MIS_INSURANCE_RATE != "")
                        {
                            MIS_INSURANCE_CURRENCY = "";
                            MIS_INSURANCE_CHARGES = "";
                        }
                    }



                    if (MIS_HIGHSEASALE_CHARGES != "")
                    {
                        //MIS_HIGHSEASALE_CURRENCY = "";
                        //MIS_HIGHSEASALE_CHARGES = "";
                        MIS_HIGHSEASALE_RATE = "";
                    }

                }
                else
                {


                    if (MIS_RATE != "")
                    {
                        MIS_CURRENCY = "";
                        MIS_CHARGES = "";

                    }
                    else
                    {
                        if (MIS_CHARGES == "" || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
                        {
                            MIS_CURRENCY = "";
                            MIS_CHARGES = "";

                        }
                    }


                    if (MIS_AGENCY_RATE != "")
                    {
                        MIS_AGENCY_CURRENCY = "";
                        MIS_AGENCY_CHARGES = "";

                    }
                    else
                    {
                        if (MIS_AGENCY_CHARGES == "" || MIS_AGENCY_CHARGES == "0" || MIS_AGENCY_CHARGES == "0.00")
                        {
                            MIS_AGENCY_CURRENCY = "";
                            MIS_AGENCY_CHARGES = "";

                        }
                    }

                    if (MIS_DISCOUNT_RATE != "")
                    {
                        MIS_DISCOUNT_CURRENCY = "";
                        MIS_DISCOUNT_CHARGES = "";

                    }
                    else
                    {
                        if (MIS_DISCOUNT_CHARGES == "" || MIS_DISCOUNT_CHARGES == "0" || MIS_DISCOUNT_CHARGES == "0.00")
                        {
                            MIS_DISCOUNT_CURRENCY = "";
                            MIS_DISCOUNT_CHARGES = "";

                        }
                    }

                    if (MIS_LOADING_RATE != "")
                    {
                        MIS_LOADING_CURRENCY = "";
                        MIS_LOADING_CHARGES = "";
                    }
                    else
                    {
                        if (MIS_LOADING_CHARGES == "" || MIS_LOADING_CHARGES == "0" || MIS_LOADING_CHARGES == "0.00")
                        {
                            MIS_LOADING_CURRENCY = "";
                            MIS_LOADING_CHARGES = "";
                        }
                    }

                    if (MIS_FREIGHT_RATE != "")
                    {
                        MIS_FREIGHT_CURRENCY = "";
                        MIS_FREIGHT_CHARGES = "";
                    }
                    else
                    {
                        if (MIS_FREIGHT_CHARGES == "" || MIS_FREIGHT_CHARGES == "0" || MIS_FREIGHT_CHARGES == "0.00")
                        {
                            MIS_FREIGHT_CURRENCY = "";
                            MIS_FREIGHT_CHARGES = "";
                        }
                    }

                    if (MIS_INSURANCE_RATE != "")
                    {
                        MIS_INSURANCE_CURRENCY = "";
                        MIS_INSURANCE_CHARGES = "";
                    }
                    else
                    {
                        if (MIS_INSURANCE_CHARGES == "" || MIS_INSURANCE_CHARGES == "0" || MIS_INSURANCE_CHARGES == "0.00")
                        {
                            MIS_INSURANCE_CURRENCY = "";
                            MIS_INSURANCE_CHARGES = "";
                        }
                    }
                    if (MIS_HIGHSEASALE_RATE != "")
                    {
                        MIS_HIGHSEASALE_CURRENCY = "";
                        MIS_HIGHSEASALE_CHARGES = "";
                    }
                    else
                    {
                        if (MIS_HIGHSEASALE_CHARGES == "" || MIS_HIGHSEASALE_CHARGES == "0" || MIS_HIGHSEASALE_CHARGES == "0.00")
                        {
                            MIS_HIGHSEASALE_CURRENCY = "";
                            MIS_HIGHSEASALE_CHARGES = "";
                        }
                    }

                }
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + INVOICE_DATE + ch + OTHER_PURCHASE_ORDER + ch + OTHER_PURCHASE_ORDER_DATE + ch + OTHER_CONTRACT_NO + ch + OTHER_CONTRACT_DATE + ch + OTHER_LOC_NO + ch + OTHER_LOC_DATE + ch + SVB_REF_NO + ch + SVB_REF_DATE + ch + SVB_ASSESABLE_RATE + ch + SVB_DUTY_RATE + ch + SVB_LOADING_ON + ch + SVB_ASSESABLE_STATUS + ch + SVB_DUTY_STATUS + ch + SVB_CUSTOM_HOUSE + ch + SUPPLIER_NAME + ch + SUPPLIER_ADDRESS + ch + SUPPLIER_ADDRESS1 + ch + SUPPLIER_ADDRESS2 + ch + SUPPLIER_COUNTRY_NAME + ch + SUPPLIER_COUNTRY_PINCODE + ch + SELLER_NAME + ch + SELLER_ADDRESS + ch + SELLER_ADDRESS1 + ch + SELLER_ADDRESS2 + ch + SELLER_COUNTRY_NAME + ch + SELLERCOUNTRY_PINCODE + ch + BROKER_NAME + ch + BROKER_ADDRESS + ch + BROKER_ADDRESS1 + ch + BROKER_ADDRESS2 + ch + BROKER_COUNTRY_NAME + ch + BROKER_COUNTRY_PINCODE + ch + INVOICE_VALUE + ch + TERMS + ch + INVOICE_CURRENCY + ch + Nature_of_Discount + ch + MIS_DISCOUNT_RATE + ch + MIS_DISCOUNT_CHARGES + ch + MIS_HIGHSEASALE_RATE + ch + MIS_HIGHSEASALE_CHARGES + ch + MIS_FREIGHT_CHARGES + ch + MIS_FREIGHT_RATE + ch + Freight_Actual + ch + MIS_FREIGHT_CURRENCY + ch + MIS_INSURANCE_CHARGES + ch + MIS_INSURANCE_RATE + ch + MIS_INSURANCE_CURRENCY + ch + MIS_CHARGES + ch + MIS_CURRENCY + ch + MIS_RATE + ch + Landing_Rate + ch + MIS_LOADING_CHARGES + ch + MIS_LOADING_CURRENCY + ch + MIS_LOADING_RATE + ch + MIS_AGENCY_CHARGES + ch + MIS_AGENCY_CURRENCY + ch + MIS_AGENCY_RATE + ch + OTHER_NATURE_OF_TRANSACTION + ch + OTHER_TERMS_OF_PAYMENT + ch + Conditions_Attached_Sale1 + ch + Conditions_Attached_Sale2 + ch + Conditions_Attached_Sale3 + ch + Conditions_Attached_Sale4 + ch + Conditions_Attached_Sale5 + ch + OTHER_VALUATION_METHOD + ch + INVOICE_NO + ch + Other_Relevant_Information + ch + TERMS_PLACE + ch + THIRDPARTY_NAME + ch + THIRDPARTY_ADD1 + ch + THIRDPARTY_ADD2 + ch + THIRDPARTY_CITY + ch + T_PARTY_COUNTRY_SUB_DIV + ch + T_PARTY_COUNTRY_CODE + ch + T_PARTY_PIN + ch + AUTHORIZED_ECONOMIC_OPERATOR_CODE + ch + A_E_O_COUNTRY + ch + AUTHORIZED_ECONOMIC_OPERATOR + ch + WHETHER_BUYER_SELLER_RELATED);
                i++;
            }
        }

        int j = 0;
        if (ds.Tables[2].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>ITEMS");
            while (ds.Tables[2].Rows.Count > j)
            {
                INVOICE_SLNO = dt.Trim(ds.Tables[2].Rows[j]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds.Tables[2].Rows[j]["ITEM_SLNO"].ToString());
                ITEM_QTY = dt.Trim(ds.Tables[2].Rows[j]["ITEM_QTY"].ToString());
                ITEM_QTY_CODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_QTY_CODE"].ToString());
                CTH_NO = dt.Trim(ds.Tables[2].Rows[j]["CTH_NO"].ToString());
                PRODUCT_CTH = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_CTH"].ToString());

                ITEM_DESCRIPTION1 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION1"].ToString());
                ITEM_DESCRIPTION2 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION2"].ToString());
                SCHEME_CODE_FULL = dt.Trim(ds.Tables[2].Rows[j]["SCHEME_CODE"].ToString());
                SCHEME_CODE = dt.Split("-", SCHEME_CODE_FULL);
                if (dt.Trim(SCHEME_CODE) == "00")
                    SCHEME_CODE = "";
                GENEARL_DESCRIPTION = dt.Trim(ds.Tables[2].Rows[j]["GENEARL_DESCRIPTION"].ToString());
                ACCESSORIES = dt.Trim(ds.Tables[2].Rows[j]["ACCESSORIES"].ToString());
                MANUFACTURER = dt.Trim(ds.Tables[2].Rows[j]["MANUFACTURER"].ToString());
                BRAND = dt.Trim(ds.Tables[2].Rows[j]["BRAND"].ToString());
                MODEL = dt.Trim(ds.Tables[2].Rows[j]["MODEL"].ToString());
                END_USE_OF_ITEM = dt.Trim(ds.Tables[2].Rows[j]["END_USE_OF_ITEM"].ToString());

                if (MANUFACTURER == "")
                {
                    MANUFACTURER = "N.A";
                }
                if (BRAND == "")
                {
                    BRAND = "N.A";
                }
                if (MODEL == "")
                {
                    MODEL = "N.A";
                }
                if (END_USE_OF_ITEM == "")
                {
                    END_USE_OF_ITEM = "N.A";
                }


                COUNTRY_OF_ORIGIN = dt.Trim(split.Split("-", ds.Tables[2].Rows[j]["COUNTRY_OF_ORIGIN"].ToString()));
                //if (COUNTRY_OF_ORIGIN.Contains("-"))
                //{
                //    string[] s3 = new string[] { };
                //    s3 = COUNTRY_OF_ORIGIN.Split(new string[] { "-" }, StringSplitOptions.None);
                //    COUNTRY_OF_ORIGIN = s3[0].ToString();
                //}
                DataView view1 = dss.Tables[0].DefaultView;

                view1 = dss.Tables[1].DefaultView;
                view1.RowFilter = "COUNTRY_NAME = '" + COUNTRY_OF_ORIGIN + "'";
                DataSet dt_1 = new DataSet();
                dt_1.Tables.Add(view1.ToTable());
                if (dt_1.Tables[0].Rows.Count > 0)
                {
                    COUNTRY_OF_ORIGIN = dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
                }
                PRODUCT_CETH = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_CETH"].ToString());
                PRODUCT_BCD_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_BCD_NOTN"].ToString());
                PRODUCT_BCD_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_BCD_SLNO"].ToString());

                PRODUCT_EDU_CESS_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_EDU_CESS_NOTN"].ToString());
                PRODUCT_EDU_CESS_NOTN_SL = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_EDU_CESS_NOTN_SL"].ToString());

                PRODUCT_CVD_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_CVD_NOTN"].ToString());
                PRODUCT_CVD_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_CVD_SLNO"].ToString());

                PRODUCT_ADDL_GSI_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_ADDL_GSI_NOTN"].ToString());
                PRODUCT_ADDL_GSI_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_ADDL_GSI_SLNO"].ToString());
                PRODUCT_ADDL_SHEII_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_ADDL_SHEII_NOTN"].ToString());
                PRODUCT_ADDL_SHEII_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_ADDL_SHEII_SLNO"].ToString());
                PRODUCT_ADDL_TTA_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_ADDL_TTA_NOTN"].ToString());
                PRODUCT_ADDL_TTA_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_ADDL_TTA_SLNO"].ToString());
                PRODUCT_ADDL_DUTY_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_ADDL_DUTY_NOTN"].ToString());
                PRODUCT_ADDL_DUTY_NOTN_SL = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString());
                PRODUCT_NCD_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_NCD_NOTN"].ToString());
                PRODUCT_NCD_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_NCD_SLNO"].ToString());
                ANTI_DUMPING_NOTN = dt.Trim(ds.Tables[2].Rows[j]["ANTI_DUMPING_NOTN"].ToString());
                ANTI_DUMPING_NOTN_SLNO = dt.Trim(ds.Tables[2].Rows[j]["ANTI_DUMPING_NOTN_SLNO"].ToString());
                CTH_SLNO = dt.Trim(ds.Tables[2].Rows[j]["CTH_SLNO"].ToString());
                CTH_SUPPLIER_SLNO = dt.Trim(ds.Tables[2].Rows[j]["CTH_SUPPLIER_SLNO"].ToString());
                CTH_QTY = dt.Trim(ds.Tables[2].Rows[j]["CTH_QTY"].ToString());
                PRODUCT_TARIFF_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_TARIFF_NOTN"].ToString());

                PRODUCT_TARIFF_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_TARIFF_SLNO"].ToString());

                PRODUCT_TARIFF_QTY = "";
                //PRODUCT_TARIFF_QTY = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_TARIFF_QTY"].ToString());

                PRODUCT_SAPTA_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_SAPTA_NOTN"].ToString());
                PRODUCT_SAPTA_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_SAPTA_SLNO"].ToString());

                PRODUCT_ADDL_HEALTH_CESS_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString());
                PRODUCT_ADDL_HEALTH_CESS_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString());
                PRODUCT_CESS_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_CESS_NOTN"].ToString());
                PRODUCT_CESS_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_CESS_SLNO"].ToString());
                PRODUCT_AGGREGATE_DUTY_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString());
                PRODUCT_AGGREGATE_DUTY_NOTN_SL = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString());
                PRODUCT_SAFEGUARD_NOTN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_SAFEGUARD_NOTN"].ToString());
                PRODUCT_SAFEGUARD_SLNO = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_SAFEGUARD_SLNO"].ToString());
                ITEM_UNIT_PRICE = dt.amt_Trim(ds.Tables[2].Rows[j]["ITEM_UNIT_PRICE"].ToString());

                CTH_QTY1 = dt.Trim(ds.Tables[2].Rows[j]["CTH_QTY1"].ToString());
                CTH_QTY2 = dt.Trim(ds.Tables[2].Rows[j]["CTH_QTY2"].ToString());
                PREVIOUS_BE_NO = dt.Trim(ds.Tables[2].Rows[j]["PREVIOUS_BE_NO"].ToString());
                PREVIOUS_BE_DATE = dt.Trim(ds.Tables[2].Rows[j]["PREVIOUS_BE_DATE"].ToString().Replace("19000101", ""));
                UNIT_PRICE = dt.amt_Trim(ds.Tables[2].Rows[j]["UNIT_PRICE"].ToString());

                UNIT_CODE = dt.Trim(ds.Tables[2].Rows[j]["UNIT_CODE"].ToString());
                PREVIOUS_CUSTOMS_HOUSE = dt.Trim(ds.Tables[2].Rows[j]["CUSTOMS_HOUSE"].ToString());

                PRODUCT_MRP_YN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_MRP_YN"].ToString());


                PRODUCT_CVD_EDU_CESS_RATE = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_CVD_EDU_CESS_RATE"].ToString());
                CETH_CVD_EDU_CESS_SL = dt.Trim(ds.Tables[2].Rows[j]["CETH_CVD_EDU_CESS_SL"].ToString());


                PRODUCT_CVD_EDU_CESS_RATE = "";
                CETH_CVD_EDU_CESS_SL = "";

                //----------------ITEMWISE SVB FOR NIPPON EXPPRESS-----------------//                

                ITEM_SVB_RELATION = dt.Trim(ds.Tables[2].Rows[j]["SVB_RELATION"].ToString());

                if (ITEM_SVB_RELATION == "true")
                {
                    ITEM_SVB_REF_NO = dt.Trim(ds.Tables[2].Rows[j]["SVB_REF_NO"].ToString());
                    ITEM_SVB_REF_DATE = dt.Trim(ds.Tables[2].Rows[j]["SVB_REF_DATE"].ToString().Replace("19000101", ""));
                    ITEM_SVB_CUSTOM_HOUSE = dt.Trim(ds.Tables[2].Rows[j]["SVB_CUSTOM_HOUSE"].ToString());
                    ITEM_SVB_LOADING_ON = dt.Trim(ds.Tables[2].Rows[j]["SVB_LOADING_ON"].ToString());

                    if (ITEM_SVB_LOADING_ON == "Both")
                    {
                        ITEM_SVB_LOADING_ON = "B";
                    }
                    else if (ITEM_SVB_LOADING_ON == "Duty")
                    {
                        ITEM_SVB_LOADING_ON = "D";
                    }
                    else if (ITEM_SVB_LOADING_ON == "Assessable")
                    {
                        ITEM_SVB_LOADING_ON = "A";
                    }


                    ITEM_SVB_ASSESABLE_RATE = dt.Trim(ds.Tables[2].Rows[j]["SVB_ASSESABLE_RATE"].ToString());
                    ITEM_SVB_DUTY_RATE = dt.Trim(ds.Tables[2].Rows[j]["SVB_DUTY_RATE"].ToString());

                    ITEM_SVB_ASSESABLE_STATUS = dt.Trim(ds.Tables[2].Rows[j]["SVB_ASSESABLE_STATUS"].ToString());
                    ITEM_SVB_DUTY_STATUS = dt.Trim(ds.Tables[2].Rows[j]["SVB_DUTY_STATUS"].ToString());
                }
                else
                {
                    ITEM_SVB_REF_NO = "";
                    ITEM_SVB_REF_DATE = "";
                    ITEM_SVB_CUSTOM_HOUSE = "";
                    ITEM_SVB_LOADING_ON = "";
                    ITEM_SVB_ASSESABLE_RATE = "";
                    ITEM_SVB_DUTY_RATE = "";

                    ITEM_SVB_ASSESABLE_STATUS = "";
                    ITEM_SVB_DUTY_STATUS = "";
                }

                //----------------ITEMWISE SVB FOR NIPPON EXPPRESS-----------------//
                

                RSP_APPLICABLE = dt.Trim(ds.Tables[2].Rows[j]["RSP_APPLICABLE"].ToString());
                CENTRAL_EXCISE_FALG = dt.Trim(ds.Tables[2].Rows[j]["CENTRAL_EXCISE_FLAG"].ToString());
                MANUFACTURER_PRODUCER = dt.Trim(ds.Tables[2].Rows[j]["MANUFACTURER_PRODUCER"].ToString());
                M_P_GROWER_CODE = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_CODE"].ToString());
                M_P_GROWER_ADD1 = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_ADD1"].ToString());
                M_P_GROWER_ADD2 = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_ADD2"].ToString());
                M_P_GROWER_CITY = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_CITY"].ToString());
                M_P_GROWER_COUNTRY_SUBDIV = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_COUNTRY_SUBDIV"].ToString());
                M_P_GROWER_PIN = dt.amt_Trim(ds.Tables[2].Rows[j]["M_P_GROWER_PIN"].ToString());
                M_P_GROWER_COUNTRY = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_COUNTRY"].ToString());
                SOURCE_COUNTRY = dt.Trim(ds.Tables[2].Rows[j]["SOURCE_COUNTRY"].ToString());
                TRANSIT_COUNTRY = dt.Trim(ds.Tables[2].Rows[j]["TRANSIT_COUNTRY"].ToString());
                ACCESSORY_STATUS = dt.Trim(ds.Tables[2].Rows[j]["ACCESSORY_STATUS"].ToString());
                

                DataView view_reimport = ds.Tables[6].DefaultView;
                // view_lic.RowFilter = "ITEM_SLNO = " + ITEM_SLNO ;

                view_reimport.RowFilter = "INVOICE_SLNO = '" + INVOICE_SLNO + "' and " + "ITEM_SLNO = '" + ITEM_SLNO + "'";
                DataTable table_Re = view_reimport.ToTable();
                DataSet dss_re = new DataSet();
                dss_re.Tables.Add(table_Re);

                int ri = 0;

                if (dss_re.Tables[0].Rows.Count > ri)
                {
                    WHETHER_REIMPORT = "Y";

                }
                else
                {
                    WHETHER_REIMPORT = "N";
                }


                //if (ds.Tables[6].Rows.Count > 0)
                //{
                //    WHETHER_REIMPORT = "Y";

                //}
                //else
                //{
                //    WHETHER_REIMPORT = "N";
                //}
                if (PRODUCT_MRP_YN == "N")
                {
                    WHETHER_RSP_DECLARED = "N";
                }
                else
                {
                    WHETHER_RSP_DECLARED = "Y";
                }

                if (PRODUCT_ADDL_DUTY_NOTN == "019/2006")
                {
                    PRODUCT_ADDL_DUTY_NOTN = "";
                }
                {

                }
                

                // sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_QTY + ch + ITEM_QTY_CODE + ch + CTH_NO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + SCHEME_CODE + ch + GENEARL_DESCRIPTION + ch + ACCESSORIES + ch + MANUFACTURER + ch + BRAND + ch + MODEL + ch + END_USE_OF_ITEM + ch + COUNTRY_OF_ORIGIN + ch + CTH_NO + ch + PREFERENTIAL + ch + PRODUCT_CETH + ch + PRODUCT_BCD_NOTN + ch + PRODUCT_BCD_SLNO + ch + PRODUCT_CVD_NOTN + ch + PRODUCT_CVD_SLNO + ch + PRODUCT_ADDL_GSI_NOTN + ch + PRODUCT_ADDL_GSI_SLNO + ch + PRODUCT_ADDL_SHEII_NOTN + ch + PRODUCT_ADDL_SHEII_SLNO + ch + PRODUCT_ADDL_TTA_NOTN + ch + PRODUCT_ADDL_TTA_SLNO + ch + PRODUCT_ADDL_DUTY_NOTN + ch + PRODUCT_ADDL_DUTY_NOTN_SL  + ch + PRODUCT_NCD_NOTN + ch + PRODUCT_NCD_SLNO + ch + ANTI_DUMPING_NOTN + ch + ANTI_DUMPING_NOTN_SLNO + ch + CTH_SLNO + ch + CTH_SUPPLIER_SLNO + ch + CTH_QTY + ch + PRODUCT_TARIFF_NOTN + ch + PRODUCT_TARIFF_SLNO + ch + PRODUCT_TARIFF_QTY + ch + PRODUCT_SAPTA_NOTN + ch + PRODUCT_SAPTA_SLNO + ch + PRODUCT_ADDL_HEALTH_CESS_NOTN + ch + PRODUCT_ADDL_HEALTH_CESS_SLNO + ch + PRODUCT_CESS_NOTN + ch + PRODUCT_CESS_SLNO + ch + PRODUCT_AGGREGATE_DUTY_NOTN + ch + PRODUCT_AGGREGATE_DUTY_NOTN_SL + ch + PRODUCT_SAFEGUARD_NOTN + ch + PRODUCT_SAFEGUARD_SLNO + ch + ITEM_UNIT_PRICE + ch + DISCOUNT_RATE + ch + DISCOUNT_AMOUNT + ch + CTH_QTY1 + ch + CTH_QTY2 + ch + SVB_REFERENCE + ch + SVB_REFERENCE_DATE + ch + SVB_LOAD_ASSESSABLE + ch + SVB_LOAD_ON_DUTY + ch + SVB_FLAG + ch + WHETHER_LOAD_FINAL_ON_ASS + ch + WHETHER_LOAD_FINAL_ON_DUTY + ch + SVB_CUSTOM_HOUSE_CODE + ch + POLICY_PARA_NO + ch + POLICY_YEAR + ch + WHETHER_RSP_DECLARED + ch + WHETHER_REIMPORT + ch + PREVIOUS_BE_NO + ch + PREVIOUS_BE_DATE + ch + PREVIOUS_UNITPRICE + ch + PREVIOUS_CURRENY + ch + PREVIOUS_CUSTOMSITE);

                // sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_QTY + ch + ITEM_QTY_CODE + ch + CTH_NO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + SCHEME_CODE + ch + GENEARL_DESCRIPTION + ch + ACCESSORIES + ch + MANUFACTURER + ch + BRAND + ch + MODEL + ch + END_USE_OF_ITEM + ch + COUNTRY_OF_ORIGIN + ch + PRODUCT_CTH + ch + PREFERENTIAL + ch + PRODUCT_CETH + ch + PRODUCT_BCD_NOTN + ch + PRODUCT_BCD_SLNO + ch + PRODUCT_CVD_NOTN + ch + PRODUCT_CVD_SLNO + ch + PRODUCT_ADDL_GSI_NOTN + ch + PRODUCT_ADDL_GSI_SLNO + ch + PRODUCT_ADDL_SHEII_NOTN + ch + PRODUCT_ADDL_SHEII_SLNO + ch + PRODUCT_ADDL_TTA_NOTN + ch + PRODUCT_ADDL_TTA_SLNO + ch + PRODUCT_EDU_CESS_NOTN + ch + PRODUCT_EDU_CESS_NOTN_SL + ch + PRODUCT_NCD_NOTN + ch + PRODUCT_NCD_SLNO + ch + ANTI_DUMPING_NOTN + ch + ANTI_DUMPING_NOTN_SLNO + ch + CTH_SLNO + ch + CTH_SUPPLIER_SLNO + ch + CTH_QTY + ch + PRODUCT_TARIFF_NOTN + ch + PRODUCT_TARIFF_SLNO + ch + PRODUCT_TARIFF_QTY + ch + PRODUCT_SAPTA_NOTN + ch + PRODUCT_SAPTA_SLNO + ch + PRODUCT_ADDL_HEALTH_CESS_NOTN + ch + PRODUCT_ADDL_HEALTH_CESS_SLNO + ch + PRODUCT_ADDL_DUTY_NOTN + ch + PRODUCT_ADDL_DUTY_NOTN_SL + ch + PRODUCT_AGGREGATE_DUTY_NOTN + ch + PRODUCT_AGGREGATE_DUTY_NOTN_SL + ch + PRODUCT_SAFEGUARD_NOTN + ch + PRODUCT_SAFEGUARD_SLNO + ch + ITEM_UNIT_PRICE + ch + DISCOUNT_RATE + ch + DISCOUNT_AMOUNT + ch + CTH_QTY1 + ch + CTH_QTY2 + ch + SVB_REFERENCE + ch + SVB_REFERENCE_DATE + ch + SVB_LOAD_ASSESSABLE + ch + SVB_LOAD_ON_DUTY + ch + SVB_FLAG + ch + WHETHER_LOAD_FINAL_ON_ASS + ch + WHETHER_LOAD_FINAL_ON_DUTY + ch + SVB_CUSTOM_HOUSE_CODE + ch + POLICY_PARA_NO + ch + POLICY_YEAR + ch + WHETHER_RSP_DECLARED + ch + WHETHER_REIMPORT + ch + PREVIOUS_BE_NO + ch + PREVIOUS_BE_DATE + ch + PREVIOUS_UNITPRICE + ch + PREVIOUS_CURRENY + ch + PREVIOUS_CUSTOMS_HOUSE);

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_QTY + ch + ITEM_QTY_CODE + ch + CTH_NO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + SCHEME_CODE + ch + GENEARL_DESCRIPTION + ch + ACCESSORIES + ch + MANUFACTURER + ch + BRAND + ch + MODEL + ch + END_USE_OF_ITEM + ch + COUNTRY_OF_ORIGIN + ch + PRODUCT_CTH + ch + PREFERENTIAL + ch + PRODUCT_CETH + ch + PRODUCT_BCD_NOTN + ch + PRODUCT_BCD_SLNO + ch + PRODUCT_CVD_NOTN + ch + PRODUCT_CVD_SLNO + ch + PRODUCT_ADDL_GSI_NOTN + ch + PRODUCT_ADDL_GSI_SLNO + ch + PRODUCT_ADDL_SHEII_NOTN + ch + PRODUCT_ADDL_SHEII_SLNO + ch + PRODUCT_ADDL_TTA_NOTN + ch + PRODUCT_ADDL_TTA_SLNO + ch + PRODUCT_EDU_CESS_NOTN + ch + PRODUCT_EDU_CESS_NOTN_SL + ch + PRODUCT_CVD_EDU_CESS_RATE + ch + CETH_CVD_EDU_CESS_SL + ch + PRODUCT_NCD_NOTN + ch + PRODUCT_NCD_SLNO + ch + ANTI_DUMPING_NOTN + ch + ANTI_DUMPING_NOTN_SLNO + ch + CTH_SLNO + ch + CTH_SUPPLIER_SLNO + ch + CTH_QTY + ch + PRODUCT_TARIFF_NOTN + ch + PRODUCT_TARIFF_SLNO + ch + PRODUCT_TARIFF_QTY + ch + PRODUCT_SAPTA_NOTN + ch + PRODUCT_SAPTA_SLNO + ch + PRODUCT_ADDL_HEALTH_CESS_NOTN + ch + PRODUCT_ADDL_HEALTH_CESS_SLNO + ch + PRODUCT_ADDL_DUTY_NOTN + ch + PRODUCT_ADDL_DUTY_NOTN_SL + ch + PRODUCT_AGGREGATE_DUTY_NOTN + ch + PRODUCT_AGGREGATE_DUTY_NOTN_SL + ch + PRODUCT_SAFEGUARD_NOTN + ch + PRODUCT_SAFEGUARD_SLNO + ch + ITEM_UNIT_PRICE + ch + DISCOUNT_RATE + ch + DISCOUNT_AMOUNT + ch + CTH_QTY1 + ch + CTH_QTY2 + ch + ITEM_SVB_REF_NO + ch + ITEM_SVB_REF_DATE + ch + ITEM_SVB_ASSESABLE_RATE + ch + ITEM_SVB_DUTY_RATE + ch + ITEM_SVB_LOADING_ON + ch + ITEM_SVB_ASSESABLE_STATUS + ch + ITEM_SVB_DUTY_STATUS + ch + ITEM_SVB_CUSTOM_HOUSE + ch + POLICY_PARA_NO + ch + POLICY_YEAR + ch + RSP_APPLICABLE + ch + WHETHER_REIMPORT + ch + PREVIOUS_BE_NO + ch + PREVIOUS_BE_DATE + ch + PREVIOUS_UNITPRICE + ch + PREVIOUS_CURRENY + ch + PREVIOUS_CUSTOMS_HOUSE + ch + CENTRAL_EXCISE_FALG + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_COUNTRY + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS);


                j++;
            }
        }


        int k = 0;
        if (ds.Tables[3].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>LICENCE");
            while (ds.Tables[3].Rows.Count > k)
            {
                INVOICE_SLNO = dt.Trim(ds.Tables[3].Rows[k]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds.Tables[3].Rows[k]["ITEM_SLNO"].ToString());
                SCHEME_CODE = dt.Trim(ds.Tables[3].Rows[k]["SCHEME_CODE"].ToString());
                REGISTRATION_NO = dt.Trim(ds.Tables[3].Rows[k]["REGISTRATION_NO"].ToString());
                REGISTRATION_DATE = dt.Trim(ds.Tables[3].Rows[k]["REGISTRATION_DATE"].ToString().Replace("19000101", ""));
                // EXCEMPTION = dt.Trim(ds.Tables[3].Rows[k]["EXCEMPTION"].ToString());
                DEBIT_AMT = dt.Trim(ds.Tables[3].Rows[k]["DEBIT_AMT"].ToString());
                DEBIT_QTY = dt.Trim(ds.Tables[3].Rows[k]["DEBIT_QTY"].ToString());
                UNIT_QTY = dt.Trim(ds.Tables[3].Rows[k]["UNIT_QTY"].ToString());
                LICENSE_ITEM_NO = dt.Trim(ds.Tables[3].Rows[k]["LICENSE_ITEM_NO"].ToString());
                PORT_OF_LICENSE = dt.Trim(ds.Tables[3].Rows[k]["PORT_OF_LICENSE"].ToString());


                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + LICENSE_ITEM_NO + ch + DEBIT_AMT + ch + DEBIT_QTY + ch + UNIT_QTY + ch + REGISTRATION_NO + ch + REGISTRATION_DATE + ch + SCHEME_CODE + ch + PORT_OF_LICENSE);
                k++;
            }
        }

        int m = 0;
        if (ds.Tables[2].Rows.Count > 0)
        {

            val = "Y";
            dr = ds.Tables[2].Select("PRODUCT_MRP_YN like '%" + val + "%'");


            if (dr.Length > 0)
            {
                sw.WriteLine("<TABLE>RSP");
                while (dr.Length > m)
                {
                    Is_val = dt.Trim(dr[m]["PRODUCT_MRP_YN"].ToString());
                    if (Is_val == val)
                    {

                        INVOICE_SLNO = dt.Trim(dr[m]["INVOICE_SLNO"].ToString());
                        ITEM_SLNO = dt.Trim(dr[m]["ITEM_SLNO"].ToString());
                        ITEM_QTY = dt.Trim(dr[m]["ITEM_QTY"].ToString());
                        ITEM_DESCRIPTION = dt.Trim(dr[m]["ITEM_DESCRIPTION"].ToString());

                        PRODUCT_MRP_SL_NO = dt.Trim(dr[m]["PRODUCT_MRP_SL_NO"].ToString());
                        PRODUCT_MRP_AMOUNT = dt.Trim(dr[m]["PRODUCT_MRP_AMOUNT"].ToString());

                        RSP_NOTN_NO = dt.Trim(dr[m]["RSP_NOTN_NO"].ToString());
                        RSP_NOTN_SL_NO = dt.Trim(dr[m]["RSP_NOTN_SL_NO"].ToString());


                        //INVOICE_SLNO = dt.Trim(ds.Tables[2].Rows[m]["INVOICE_SLNO"].ToString());
                        //ITEM_SLNO = dt.Trim(ds.Tables[2].Rows[m]["ITEM_SLNO"].ToString());
                        //ITEM_QTY = dt.Trim(ds.Tables[2].Rows[m]["ITEM_QTY"].ToString());
                        //ITEM_DESCRIPTION = dt.Trim(ds.Tables[2].Rows[m]["ITEM_DESCRIPTION"].ToString());

                        //PRODUCT_MRP_SL_NO = dt.Trim(ds.Tables[2].Rows[m]["PRODUCT_MRP_SL_NO"].ToString());
                        //PRODUCT_MRP_AMOUNT = dt.Trim(ds.Tables[2].Rows[m]["PRODUCT_MRP_AMOUNT"].ToString());

                        //RSP_NOTN_NO = dt.Trim(ds.Tables[2].Rows[m]["RSP_NOTN_NO"].ToString());
                        //RSP_NOTN_SL_NO = dt.Trim(ds.Tables[2].Rows[m]["RSP_NOTN_SL_NO"].ToString());

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + PRODUCT_MRP_SL_NO + ch + PRODUCT_MRP_AMOUNT + ch + ITEM_QTY + ch + ITEM_DESCRIPTION + ch + RSP_NOTN_NO + ch + RSP_NOTN_SL_NO);

                        m++;
                    }
                }
            }

        }

        //int a = 0;
        //if (ds.Tables[2].Rows.Count > 0)
        //{
        //    //val = "06-DEPB";
        //    string val1 = "00-DUTIABLE";


        //   // dr = ds.Tables[2].Select("SCHEME_CODE1 like '%" + val1 + "%'");
        //    if (dr.Length > 0)
        //    {
        //        sw.WriteLine("<TABLE>DEPB");
        //        // while (ds.Tables[2].Rows.Count > a)
        //        while (dr.Length > a)
        //        {
        //            Is_val = dt.Trim(dr[a]["SCHEME_CODE1"].ToString());
        //            if (Is_val != val1)
        //            {

        //                INVOICE_SLNO = dt.Trim(ds.Tables[2].Rows[a]["INVOICE_SLNO"].ToString());
        //                ITEM_SLNO = dt.Trim(ds.Tables[2].Rows[a]["ITEM_SLNO"].ToString());
        //                SCHEME_NOTN = dt.Trim(ds.Tables[2].Rows[a]["SCHEME_NOTN"].ToString());
        //                SCHEME_NOTN_SLNO = dt.Trim(ds.Tables[2].Rows[a]["SCHEME_NOTN_SLNO"].ToString());

        //                string Whether_Exemption = "";

        //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + Whether_Exemption + ch + SCHEME_NOTN + ch + SCHEME_NOTN_SLNO);
        //                a++;
        //            }
        //        }
        //    }
        //}



        //int a = 0;
        //if (ds.Tables[2].Rows.Count > 0)
        //{
        //    SCHEME_CODE_FULL = dt.Trim(ds.Tables[2].Rows[j]["SCHEME_CODE"].ToString());
        //    if (SCHEME_CODE_FULL != "00 - DUTIABLE")
        //    {
        //        sw.WriteLine("<TABLE>DEPB");
        //        while (ds.Tables[2].Rows.Count > a)
        //        {
        //            INVOICE_SLNO = dt.Trim(ds.Tables[2].Rows[a]["INVOICE_SLNO"].ToString());
        //            ITEM_SLNO = dt.Trim(ds.Tables[2].Rows[a]["ITEM_SLNO"].ToString());
        //            SCHEME_NOTN = dt.Trim(ds.Tables[2].Rows[a]["SCHEME_NOTN"].ToString());
        //            SCHEME_NOTN_SLNO = dt.Trim(ds.Tables[2].Rows[a]["SCHEME_NOTN_SLNO"].ToString());

        //            string Whether_Exemption = "";

        //            if (SCHEME_CODE_FULL != "00 - DUTIABLE")
        //            {
        //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + Whether_Exemption + ch + SCHEME_NOTN + ch + SCHEME_NOTN_SLNO);
        //            }
        //            a++;
        //        }
        //    }
        //}


        int a = 0;
        if (ds.Tables[11].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>DEPB");
            while (ds.Tables[11].Rows.Count > a)
            {
                INVOICE_SLNO = dt.Trim(ds.Tables[11].Rows[a]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds.Tables[11].Rows[a]["ITEM_SLNO"].ToString());
                SCHEME_NOTN = dt.Trim(ds.Tables[11].Rows[a]["SCHEME_NOTN"].ToString());
                SCHEME_NOTN_SLNO = dt.Trim(ds.Tables[11].Rows[a]["SCHEME_NOTN_SLNO"].ToString());
                EXCEMPTION = dt.Trim(ds.Tables[11].Rows[a]["EXCEMPTION"].ToString());
                SCHEME_CODE = dt.Trim(ds.Tables[11].Rows[a]["SCHEME_CODE"].ToString());

                if (SCHEME_CODE == "21-EOU")
                {
                    EXCEMPTION = "";
                }
                else if (SCHEME_CODE == "20-JBG")
                {
                    EXCEMPTION = "";
                }

                //string Whether_Exemption = "";

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + EXCEMPTION + ch + SCHEME_NOTN + ch + SCHEME_NOTN_SLNO);

                a++;
            }
        }




        int b = 0;
        if (ds.Tables[4].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>BOND");
            while (ds.Tables[4].Rows.Count > b)
            {
                BOND_NO = dt.Trim(ds.Tables[4].Rows[b]["BOND_NO"].ToString());
                BOND_TYPE = dt.Trim(ds.Tables[4].Rows[b]["BOND_TYPE"].ToString());
                BOND_LOCATION = dt.Trim(ds.Tables[4].Rows[b]["BOND_LOCATION"].ToString());

                if (BOND_LOCATION.Contains('-'))
                {
                    Str_Bond_Location = BOND_LOCATION.Split('-');

                    BOND_LOCATION = Str_Bond_Location[1].Trim();
                }

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + BOND_NO + ch + BOND_TYPE + ch + BOND_LOCATION);
                b++;
            }
        }

        int c = 0;
        if (ds.Tables[5].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>CERT");
            while (ds.Tables[5].Rows.Count > c)
            {
                CERTIFICATE_NO = dt.Trim(ds.Tables[5].Rows[c]["CERTIFICATE_NO"].ToString());
                CERTIFICATE_DATE = dt.Trim(ds.Tables[5].Rows[c]["CERTIFICATE_DATE"].ToString().Replace("19000101", ""));
                CERTIFICATE_TYPE = dt.Trim(ds.Tables[5].Rows[c]["CERTIFICATE_TYPE"].ToString());

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + CERTIFICATE_NO + ch + CERTIFICATE_DATE + ch + CERTIFICATE_TYPE);
                c++;
            }
        }

        if (HIGH_SEA_SALE == "Y")
        {
            if (BE_TYPE != "X")
            {
                sw.WriteLine("<TABLE>HSS");
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + HIGH_SEA_IEC + ch + HIGH_SEA_BRANCH_SL_NO + ch + HIGH_SEA_SALE_NAME + ch + HSS_ADD1 + ch + HSS_ADD2 + ch + HSS_ADD3_4 + ch + HSS_ADD5 + ch + PRECEDING_LEVEL);
            }
        }
        int d = 0;
        if (ds.Tables[6].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>REIMPORT");
            while (ds.Tables[6].Rows.Count > d)
            {
                INVOICE_SLNO = dt.Trim(ds.Tables[6].Rows[d]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds.Tables[6].Rows[d]["ITEM_SLNO"].ToString());
                SB_NO = dt.Trim(ds.Tables[6].Rows[d]["SB_NO"].ToString());
                SB_DATE = dt.Trim(ds.Tables[6].Rows[d]["SB_DATE"].ToString().Replace("19000101", ""));
                PORT_EXPORT = dt.Trim(ds.Tables[6].Rows[d]["PORT_EXPORT"].ToString());
                SB_INVOICE_NO = dt.Trim(ds.Tables[6].Rows[d]["SB_INVOICE_NO"].ToString());
                SB_INVOICE__ITEM_NO = dt.Trim(ds.Tables[6].Rows[d]["SB_INVOICE__ITEM_NO"].ToString());
                NOTN_NO = dt.Trim(ds.Tables[6].Rows[d]["NOTN_NO"].ToString());
                NOTN_SLNO = dt.Trim(ds.Tables[6].Rows[d]["NOTN_SLNO"].ToString());
                EXPORT_FREIGHT = dt.Trim(ds.Tables[6].Rows[d]["EXPORT_FREIGHT"].ToString());
                EXPORT_INSURANCE = dt.Trim(ds.Tables[6].Rows[d]["EXPORT_INSURANCE"].ToString());

                CUSTOMS_DUTY = dt.Trim(ds.Tables[6].Rows[d]["CUSTOMS_DUTY"].ToString());
                EXCISE_DUTY = dt.Trim(ds.Tables[6].Rows[d]["EXCISE_DUTY"].ToString());

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SB_NO + ch + SB_DATE + ch + PORT_EXPORT + ch + SB_INVOICE_NO + ch + SB_INVOICE__ITEM_NO + ch + NOTN_NO + ch + NOTN_SLNO + ch + EXPORT_FREIGHT + ch + EXPORT_INSURANCE + ch + CUSTOMS_DUTY + ch + EXCISE_DUTY);
                d++;
            }
        }

        int od = 0;
        DataView OD_view = ds.Tables[2].DefaultView;
        OD_view.RowFilter = "NOT PRODUCT_OTHER_DUTY_NOTN = '' ";
        DataTable OD_table = OD_view.ToTable();

        if (OD_table.Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>SBEDUTY");
            while (OD_table.Rows.Count > od)
            {
                INVOICE_SLNO = dt.Trim(OD_table.Rows[od]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(OD_table.Rows[od]["ITEM_SLNO"].ToString());

                PRODUCT_OTHER_DUTY_NOTN = dt.Trim(OD_table.Rows[od]["PRODUCT_OTHER_DUTY_NOTN"].ToString());
                PRODUCT_OTHER_DUTY_SLNO = dt.Trim(OD_table.Rows[od]["PRODUCT_OTHER_DUTY_SLNO"].ToString());
                PRODUCT_OTHER_DUTY_RATE = dt.Trim(OD_table.Rows[od]["PRODUCT_OTHER_DUTY_RATE"].ToString());
                PRODUCT_OTHER_DUTY_SPL = dt.Trim(OD_table.Rows[od]["PRODUCT_OTHER_DUTY_SPL"].ToString());
                PRODUCT_OTHER_DUTY_UNIT = dt.Trim(OD_table.Rows[od]["PRODUCT_OTHER_DUTY_UNIT"].ToString());
                PRODUCT_OTHER_DUTY_TYPE = dt.Trim(OD_table.Rows[od]["PRODUCT_OTHER_DUTY_TYPE"].ToString());

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + PRODUCT_OTHER_DUTY_NOTN + ch + PRODUCT_OTHER_DUTY_SLNO + ch + "E" + ch + "X");

                od++;
            }
        }


        if (BE_TYPE == "X")
        {
            //No need to display IGM & Container when BE TYPE is EX-BOND
        }
        else
        {
            int f = 0;
            if (ds.Tables[7].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>IGMS");
                while (ds.Tables[7].Rows.Count > f)
                {
                    IGM_NO = dt.Trim(dt.Get_Nullval(ds.Tables[7].Rows[f]["IGM_NO"].ToString()));
                    IGM_DATE = dt.Trim(ds.Tables[7].Rows[f]["IGM_DATE"].ToString().Replace("19000101", ""));
                    IGM_FLIGHT_VESSELDATE = dt.Trim(ds.Tables[7].Rows[f]["IGM_FLIGHT_VESSELDATE"].ToString().Replace("19000101", ""));
                    if (TRANSPORT_MODE == "Land" || TRANSPORT_MODE == "L")
                    {
                        IGM_GATEWAY_IGM_NO = dt.Trim(ds.Tables[7].Rows[f]["IGM_GATEWAY_IGM_NO"].ToString());
                        IGM_GATEWAY_IGM_DATE = dt.Trim(ds.Tables[7].Rows[f]["IGM_GATEWAY_IGM_DATE"].ToString().Replace("19000101", ""));
                        IGM_GATEWAY_PORT_CODE = dt.Trim(ds.Tables[7].Rows[f]["IGM_GATEWAY_PORT_CODE"].ToString());


                        if (IGM_GATEWAY_PORT_CODE.Contains('-'))
                        {
                            Str_IGM_GATEWAY_PORT_CODE = IGM_GATEWAY_PORT_CODE.Split('-');

                            IGM_GATEWAY_PORT_CODE = Str_IGM_GATEWAY_PORT_CODE[1].Trim();
                        }
                    }
                    else
                    {

                        IGM_GATEWAY_IGM_NO = "";
                        IGM_GATEWAY_IGM_DATE = "";
                        IGM_GATEWAY_PORT_CODE = "";
                    }
                    if (TRANSPORT_MODE == "Sea" || TRANSPORT_MODE == "S")
                    {
                        IGM_GATEWAY_PORT_CODE = dt.Trim(ds.Tables[7].Rows[f]["IGM_GATEWAY_PORT_CODE"].ToString());


                        if (IGM_GATEWAY_PORT_CODE.Contains('-'))
                        {
                            Str_IGM_GATEWAY_PORT_CODE = IGM_GATEWAY_PORT_CODE.Split('-');

                            IGM_GATEWAY_PORT_CODE = Str_IGM_GATEWAY_PORT_CODE[1].Trim();
                        }
                    }
                    //else
                    //{
                    //    IGM_GATEWAY_PORT_CODE = "";
                    //}
                    IGM_MAWB_MBL = dt.Trim(ds.Tables[7].Rows[f]["IGM_MAWB_MBL"].ToString());
                    IGM_MAWB_MBLDATE = dt.Trim(ds.Tables[7].Rows[f]["IGM_MAWB_MBLDATE"].ToString().Replace("19000101", ""));
                    IGM_HAWB_HBLNO = dt.Trim(ds.Tables[7].Rows[f]["IGM_HAWB_HBLNO"].ToString());
                    IGM_HAWB_HBLDATE = dt.Trim(ds.Tables[7].Rows[f]["IGM_HAWB_HBLDATE"].ToString().Replace("19000101", ""));
                    IGM_NOOFPACKAGE = dt.Trim(ds.Tables[7].Rows[f]["IGM_NOOFPACKAGE"].ToString());

                    IGM_GROSSWEIGHT = dt.Trim(ds.Tables[7].Rows[f]["IGM_GROSSWEIGHT"].ToString());
                    IGM_TYPEOFWEIGHT = dt.Trim(ds.Tables[7].Rows[f]["IGM_TYPEOFWEIGHT"].ToString());
                    IGM_PACKAGETYPE = dt.Trim(ds.Tables[7].Rows[f]["IGM_PACKAGETYPE"].ToString());
                    IGM_MARKSNOS1 = dt.Trim(ds.Tables[7].Rows[f]["IGM_MARKSNOS1"].ToString());

                    IGM_MARKSNOS2 = dt.Trim(ds.Tables[7].Rows[f]["IGM_MARKSNOS2"].ToString());
                    IGM_MARKSNOS3 = dt.Trim(ds.Tables[7].Rows[f]["IGM_MARKSNOS3"].ToString());

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + IGM_NO + ch + IGM_DATE + ch + IGM_FLIGHT_VESSELDATE + ch + IGM_GATEWAY_IGM_NO + ch + IGM_GATEWAY_IGM_DATE + ch + IGM_GATEWAY_PORT_CODE + ch + IGM_MAWB_MBL + ch + IGM_MAWB_MBLDATE + ch + IGM_HAWB_HBLNO + ch + IGM_HAWB_HBLDATE + ch + IGM_NOOFPACKAGE + ch + IGM_GROSSWEIGHT + ch + IGM_TYPEOFWEIGHT + ch + IGM_PACKAGETYPE + ch + IGM_MARKSNOS1 + ch + IGM_MARKSNOS2 + ch + IGM_MARKSNOS3);
                    f++;
                }
            }

            int g = 0;

            if (ds.Tables[8].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>CONTAINER");
                while (ds.Tables[8].Rows.Count > g)
                {
                    CONTAINER_IGM_NO = dt.Trim(ds.Tables[8].Rows[g]["CONTAINER_IGM_NO"].ToString());
                    CONTAINER_IGM_DATE = dt.Trim(ds.Tables[8].Rows[g]["CONTAINER_IGM_DATE"].ToString().Replace("19000101", ""));
                    CONTAINER_NO = dt.Trim(ds.Tables[8].Rows[g]["CONTAINER_NO"].ToString());
                    SEAL_NO = dt.Trim(ds.Tables[8].Rows[g]["SEAL_NO"].ToString());
                    FCL_OR_LCL = dt.Trim(ds.Tables[8].Rows[g]["FCL_OR_LCL"].ToString());

                    TRUCK_NO = dt.Trim(ds.Tables[8].Rows[g]["TRUCK_NO"].ToString());

                    if (FILING_STATUS == "A")
                    {
                        if (TRANSPORT_MODE == "Sea" || TRANSPORT_MODE == "S")
                        {
                            CONTAINER_IGM_NO = "";
                        }
                    }
                    if (FILING_STATUS == "Y")
                    {
                        if (TRANSPORT_MODE == "Land" || TRANSPORT_MODE == "L")
                        {
                            CONTAINER_IGM_NO = "";
                        }
                    }

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + CONTAINER_IGM_NO + ch + CONTAINER_IGM_DATE + ch + FCL_OR_LCL + ch + CONTAINER_NO + ch + SEAL_NO + ch + TRUCK_NO);
                    g++;
                }
            }
        }
        //int g = 0;

        //if (ds.Tables[8].Rows.Count > 0)
        //{
        //    sw.WriteLine("<TABLE>CONTAINER");
        //    while (ds.Tables[8].Rows.Count > g)
        //    {
        //        CONTAINER_IGM_NO = dt.Trim(ds.Tables[8].Rows[g]["CONTAINER_IGM_NO"].ToString());
        //        CONTAINER_IGM_DATE = dt.Trim(ds.Tables[8].Rows[g]["CONTAINER_IGM_DATE"].ToString().Replace("19000101", ""));
        //        CONTAINER_NO = dt.Trim(ds.Tables[8].Rows[g]["CONTAINER_NO"].ToString());
        //        SEAL_NO = dt.Trim(ds.Tables[8].Rows[g]["SEAL_NO"].ToString());
        //        FCL_OR_LCL = dt.Trim(ds.Tables[8].Rows[g]["FCL_OR_LCL"].ToString());

        //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + CONTAINER_IGM_NO + ch + CONTAINER_IGM_DATE + ch + FCL_OR_LCL + ch + CONTAINER_NO + ch + SEAL_NO);
        //        g++;
        //    }
        //}

        if (COMMERCIAL_DETAILS_STATUS == "Y")
        {
            sw.WriteLine("<TABLE>CTX");

            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + COMMERCIAL_TAX_STATECODE + ch + COMMERCIAL_TAX_TYPE + ch + COMMERCIAL_TAX_REGISTRATION_NO);
        }

        //---------------Single Window Process Old--------------------//

        //int sws = 0;
        //if (ds.Tables[12].Rows.Count > 0)
        //{
        //    while (ds.Tables[12].Rows.Count > sws)
        //    {
        //        INVOICE_SLNO = dt.Trim(ds.Tables[12].Rows[sws]["INVOICE_SLNO"].ToString());
        //        ITEM_SLNO = dt.Trim(ds.Tables[12].Rows[sws]["ITEM_SLNO"].ToString());

        //        INFO_TYPE = dt.Trim(ds.Tables[12].Rows[sws]["INFO_TYPE"].ToString());
        //        INFO_QUALIFIER = dt.Trim(ds.Tables[12].Rows[sws]["INFO_QUALIFIER"].ToString());
        //        INFO_CODE = dt.Trim(ds.Tables[12].Rows[sws]["INFO_CODE"].ToString());
        //        INFO_TEXT = dt.Trim(ds.Tables[12].Rows[sws]["INFO_TEXT"].ToString());

        //        INFO_MSR = dt.Trim(ds.Tables[12].Rows[sws]["INFO_MSR"].ToString());
        //        INFO_UQC = dt.Trim(ds.Tables[12].Rows[sws]["INFO_UQC"].ToString());
        //        CONSTITUENT_SRNO = dt.Trim(ds.Tables[12].Rows[sws]["CONSTITUENT_SRNO"].ToString());
        //        CONSTITUENT_ELEMENT_NAME = dt.Trim(ds.Tables[12].Rows[sws]["CONSTITUENT_ELEMENT_NAME"].ToString());
        //        CONSTITUENT_ELEMENT_CODE = dt.Trim(ds.Tables[12].Rows[sws]["CONSTITUENT_ELEMENT_CODE"].ToString());

        //        CONSTITUENT_PERCENTAGE = dt.Trim(ds.Tables[12].Rows[sws]["CONSTITUENT_PERCENTAGE"].ToString());
        //        CONSTITUENT_YIELD_PERCENTAGE = dt.Trim(ds.Tables[12].Rows[sws]["CONSTITUENT_YIELD_PERCENTAGE"].ToString());
        //        ACTIVE_INGREDIENT = dt.Trim(ds.Tables[12].Rows[sws]["ACTIVE_INGREDIENT"].ToString());
        //        PRODUCTION_BATCH_IDENTIFIER = dt.Trim(ds.Tables[12].Rows[sws]["PRODUCTION_BATCH_IDENTIFIER"].ToString());

        //        PRODUCTION_BATCH_QUANTITY = dt.Trim(ds.Tables[12].Rows[sws]["PRODUCTION_BATCH_QUANTITY"].ToString());
        //        UNIT_QTY_CODE = dt.Trim(ds.Tables[12].Rows[sws]["UNIT_QTY_CODE"].ToString());
        //        DATE_OF_MANUFACTURING = dt.Trim(ds.Tables[12].Rows[sws]["DATE_OF_MANUFACTURING"].ToString().Replace("19000101", ""));
        //        DATE_OF_EXPIRY = dt.Trim(ds.Tables[12].Rows[sws]["DATE_OF_EXPIRY"].ToString().Replace("19000101", ""));
        //        BEST_BEFORE = dt.Trim(ds.Tables[12].Rows[sws]["BEST_BEFORE"].ToString().Replace("19000101", ""));

        //        CONTROL_TYPE_CODE = dt.Trim(ds.Tables[12].Rows[sws]["CONTROL_TYPE_CODE"].ToString());
        //        CONTROL_LOCATION = dt.Trim(ds.Tables[12].Rows[sws]["CONTROL_LOCATION"].ToString());
        //        CONTROL_START_DATE = dt.Trim(ds.Tables[12].Rows[sws]["CONTROL_START_DATE"].ToString().Replace("19000101", ""));
        //        CONTROL_END_DATE = dt.Trim(ds.Tables[12].Rows[sws]["CONTROL_END_DATE"].ToString().Replace("19000101", ""));

        //        CONTROL_RESULT_CODE = dt.Trim(ds.Tables[12].Rows[sws]["CONTROL_RESULT_CODE"].ToString());
        //        CONTROL_RESULT_TEXT = dt.Trim(ds.Tables[12].Rows[sws]["CONTROL_RESULT_TEXT"].ToString());
        //        STMT_DECLARATION_TYPE = dt.Trim(ds.Tables[12].Rows[sws]["STMT_DECLARATION_TYPE"].ToString());

        //        STMT_DECLARATION_NUMBER = dt.Trim(ds.Tables[12].Rows[sws]["STMT_DECLARATION_NUMBER"].ToString());
        //        STMT_DECLARATION_DATE = dt.Trim(ds.Tables[12].Rows[sws]["STMT_DECLARATION_DATE"].ToString().Replace("19000101", ""));
        //        STMT_TYPE = dt.Trim(ds.Tables[12].Rows[sws]["STMT_TYPE"].ToString());

        //        STMT_CODE = dt.Trim(ds.Tables[12].Rows[sws]["STMT_CODE"].ToString());
        //        STMT_TEXT = dt.Trim(ds.Tables[12].Rows[sws]["STMT_TEXT"].ToString());
        //        SUP_DECLARATION_NUMBER = dt.Trim(ds.Tables[12].Rows[sws]["SUP_DECLARATION_NUMBER"].ToString());
        //        SUP_DECLARATION_DATE = dt.Trim(ds.Tables[12].Rows[sws]["SUP_DECLARATION_DATE"].ToString().Replace("19000101", ""));
        //        SUP_DECLARATION_TYPE = dt.Trim(ds.Tables[12].Rows[sws]["SUP_DECLARATION_TYPE"].ToString());
        //        UNIQUE_DOC_NUMBER = dt.Trim(ds.Tables[12].Rows[k]["UNIQUE_DOC_NUMBER"].ToString());

        //        DOC_TYPE_CODE = dt.Trim(ds.Tables[12].Rows[sws]["DOC_TYPE_CODE"].ToString());
        //        DOC_ISSUING_PARTY_CODE = dt.Trim(ds.Tables[12].Rows[sws]["DOC_ISSUING_PARTY_CODE"].ToString());
        //        DOC_ISSUING_PARTY_NAME_ADD1 = dt.Trim(ds.Tables[12].Rows[sws]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString());
        //        DOC_ISSUING_PARTY_NAME_ADD2 = dt.Trim(ds.Tables[12].Rows[sws]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString());

        //        DOC_ISSUING_PARTY_CITY = dt.Trim(ds.Tables[12].Rows[sws]["DOC_ISSUING_PARTY_CITY"].ToString());
        //        DOC_ISSUING_PARTY_PIN = dt.Trim(ds.Tables[12].Rows[sws]["DOC_ISSUING_PARTY_PIN"].ToString());
        //        DOC_REF_NUMBER = dt.Trim(ds.Tables[12].Rows[sws]["DOC_REF_NUMBER"].ToString());
        //        PLACE_OF_ISSUE = dt.Trim(ds.Tables[12].Rows[sws]["PLACE_OF_ISSUE"].ToString());
        //        DOC_ISSUE_DATE = dt.Trim(ds.Tables[12].Rows[sws]["DOC_ISSUE_DATE"].ToString().Replace("19000101", ""));
        //        DOC_EXPIRY_DATE = dt.Trim(ds.Tables[12].Rows[sws]["DOC_EXPIRY_DATE"].ToString().Replace("19000101", ""));
        //        BENEFICIARY_PARTY_CODE = dt.Trim(ds.Tables[12].Rows[sws]["BENEFICIARY_PARTY_CODE"].ToString());

        //        BENEFICIARY_PARTY_ADDRESS1 = dt.Trim(ds.Tables[12].Rows[sws]["BENEFICIARY_PARTY_ADDRESS1"].ToString());
        //        BENEFICIARY_PARTY_ADDRESS2 = dt.Trim(ds.Tables[12].Rows[sws]["BENEFICIARY_PARTY_ADDRESS2"].ToString());
        //        BENEFICIARY_PARTY_CITY = dt.Trim(ds.Tables[12].Rows[sws]["BENEFICIARY_PARTY_CITY"].ToString());
        //        BENEFICIARY_PARTY_PIN = dt.Trim(ds.Tables[12].Rows[sws]["BENEFICIARY_PARTY_PIN"].ToString());
        //        FILE_TYPE = dt.Trim(ds.Tables[12].Rows[sws]["FILE_TYPE"].ToString());

                //if (INFO_TYPE != "")
                //{
                //    sw.WriteLine("<TABLE>BE_ITEM_SW_INFO_TYPE");
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                //}

                //if (CONSTITUENT_SRNO != "")
                //{
                //    sw.WriteLine("<TABLE>BE_ITEM_SW_CONST");
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONSTITUENT_SRNO + ch + CONSTITUENT_ELEMENT_NAME + ch + CONSTITUENT_ELEMENT_CODE + ch + CONSTITUENT_PERCENTAGE + ch + CONSTITUENT_YIELD_PERCENTAGE + ch + ACTIVE_INGREDIENT);
                //}

                //if (PRODUCTION_BATCH_IDENTIFIER != "")
                //{
                //    sw.WriteLine("<TABLE>BE_ITEM_SW_PROD");
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + PRODUCTION_BATCH_IDENTIFIER + ch + PRODUCTION_BATCH_QUANTITY + ch + UNIT_QTY_CODE + ch + DATE_OF_MANUFACTURING + ch + DATE_OF_EXPIRY + ch + BEST_BEFORE);
                //}

                //if (CONTROL_TYPE_CODE != "")
                //{
                //    sw.WriteLine("<TABLE>BE_ITEM_SW_CTRL");
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONTROL_TYPE_CODE + ch + CONTROL_LOCATION + ch + CONTROL_START_DATE + ch + CONTROL_END_DATE + ch + CONTROL_RESULT_CODE + ch + CONTROL_RESULT_TEXT);
                //}

                //if (STMT_TYPE != "")
                //{
                //    sw.WriteLine("<TABLE>STATEMENT");
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + STMT_DECLARATION_TYPE + ch + STMT_DECLARATION_NUMBER + ch + STMT_DECLARATION_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                //}

                //if (UNIQUE_DOC_NUMBER != "")
                //{
                //    sw.WriteLine("<TABLE>SUPPORTINGDOCS");
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SUP_DECLARATION_NUMBER + ch + SUP_DECLARATION_DATE + ch + SUP_DECLARATION_TYPE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CHA_NO + ch + IEC_NO + ch + ICEGATE_ID + ch + UNIQUE_DOC_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE);
                //}

        //        sws++;     
        //    }
        //}

        //---------------Single Window Process Old--------------------//

        //---------------Single Window Process Live--------------------//

        DataView sw_type = ds.Tables[12].DefaultView;

        sw_type = ds.Tables[12].DefaultView;
        //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
        sw_type.RowFilter = "Isnull(INFO_TYPE,'') <> ''";
        
        DataSet ds_type = new DataSet();
        ds_type.Tables.Add(sw_type.ToTable());

        if (ds_type.Tables[0].Rows.Count > 0)
        {
            int sws_type = 0;
            sw.WriteLine("<TABLE>BE_ITEM_SW_INFO_TYPE");
            while (ds_type.Tables[0].Rows.Count > sws_type)
            {
                INFO_TYPE = "";
                INVOICE_SLNO = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_type.Tables[0].Rows[sws_type]["ITEM_SLNO"].ToString());

                INFO_TYPE = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_TYPE"].ToString());
                INFO_QUALIFIER = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_QUALIFIER"].ToString());
                INFO_CODE = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_CODE"].ToString());
                INFO_TEXT = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_TEXT"].ToString());

                INFO_MSR = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_MSR"].ToString());
                INFO_UQC = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_UQC"].ToString());

                if (INFO_TYPE != "")
                {
                    
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                }
                sws_type++;
            }
        }


        DataView sw_const = ds.Tables[12].DefaultView;

        sw_const = ds.Tables[12].DefaultView;
        //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
        sw_const.RowFilter = "Isnull(CONSTITUENT_SRNO,'') <> ''";

        DataSet ds_const = new DataSet();
        ds_const.Tables.Add(sw_const.ToTable());

        if (ds_const.Tables[0].Rows.Count > 0)
        {
            int sws_const = 0;
            sw.WriteLine("<TABLE>BE_ITEM_SW_CONST");
            while (ds_const.Tables[0].Rows.Count > sws_const)
            {
                CONSTITUENT_SRNO = "";

                INVOICE_SLNO = dt.Trim(ds_const.Tables[0].Rows[sws_const]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_const.Tables[0].Rows[sws_const]["ITEM_SLNO"].ToString());

                CONSTITUENT_SRNO = dt.Trim(ds_const.Tables[0].Rows[sws_const]["CONSTITUENT_SRNO"].ToString());
                CONSTITUENT_ELEMENT_NAME = dt.Trim(ds_const.Tables[0].Rows[sws_const]["CONSTITUENT_ELEMENT_NAME"].ToString());
                CONSTITUENT_ELEMENT_CODE = dt.Trim(ds_const.Tables[0].Rows[sws_const]["CONSTITUENT_ELEMENT_CODE"].ToString());

                CONSTITUENT_PERCENTAGE = dt.Trim(ds_const.Tables[0].Rows[sws_const]["CONSTITUENT_PERCENTAGE"].ToString());
                CONSTITUENT_YIELD_PERCENTAGE = dt.Trim(ds_const.Tables[0].Rows[sws_const]["CONSTITUENT_YIELD_PERCENTAGE"].ToString());
                ACTIVE_INGREDIENT = dt.Trim(ds_const.Tables[0].Rows[sws_const]["ACTIVE_INGREDIENT"].ToString());

                if (CONSTITUENT_SRNO != "")
                {
                    
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONSTITUENT_SRNO + ch + CONSTITUENT_ELEMENT_NAME + ch + CONSTITUENT_ELEMENT_CODE + ch + CONSTITUENT_PERCENTAGE + ch + CONSTITUENT_YIELD_PERCENTAGE + ch + ACTIVE_INGREDIENT);
                }
                sws_const++;
            }
        }



        DataView sw_prod = ds.Tables[12].DefaultView;

        sw_prod = ds.Tables[12].DefaultView;
        //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
        sw_prod.RowFilter = "Isnull(PRODUCTION_BATCH_IDENTIFIER,'') <> ''";

        DataSet ds_prod = new DataSet();
        ds_prod.Tables.Add(sw_prod.ToTable());

        if (ds_prod.Tables[0].Rows.Count > 0)
        {
            int sws_prod = 0;
            sw.WriteLine("<TABLE>BE_ITEM_SW_PROD");
            while (ds_prod.Tables[0].Rows.Count > sws_prod)
            {
                PRODUCTION_BATCH_IDENTIFIER = "";
                INVOICE_SLNO = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["ITEM_SLNO"].ToString());
                PRODUCTION_BATCH_IDENTIFIER = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["PRODUCTION_BATCH_IDENTIFIER"].ToString());

                PRODUCTION_BATCH_QUANTITY = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["PRODUCTION_BATCH_QUANTITY"].ToString());
                UNIT_QTY_CODE = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["UNIT_QTY_CODE"].ToString());
                DATE_OF_MANUFACTURING = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["DATE_OF_MANUFACTURING"].ToString().Replace("19000101", ""));
                DATE_OF_EXPIRY = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["DATE_OF_EXPIRY"].ToString().Replace("19000101", ""));
                BEST_BEFORE = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["BEST_BEFORE"].ToString().Replace("19000101", ""));

                if (PRODUCTION_BATCH_IDENTIFIER != "")
                {
                    
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + PRODUCTION_BATCH_IDENTIFIER + ch + PRODUCTION_BATCH_QUANTITY + ch + UNIT_QTY_CODE + ch + DATE_OF_MANUFACTURING + ch + DATE_OF_EXPIRY + ch + BEST_BEFORE);
                }
                sws_prod++;
            }
        }


        DataView sw_ctrl = ds.Tables[12].DefaultView;

        sw_ctrl = ds.Tables[12].DefaultView;
        //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
        sw_ctrl.RowFilter = "Isnull(CONTROL_TYPE_CODE,'') <> ''";

        DataSet ds_ctrl = new DataSet();
        ds_ctrl.Tables.Add(sw_ctrl.ToTable());

        if (ds_ctrl.Tables[0].Rows.Count > 0)
        {
            int sws_ctrl = 0;
            sw.WriteLine("<TABLE>BE_ITEM_SW_CTRL");
            while (ds_ctrl.Tables[0].Rows.Count > sws_ctrl)
            {
                CONTROL_TYPE_CODE = "";
                INVOICE_SLNO = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["ITEM_SLNO"].ToString());

                CONTROL_TYPE_CODE = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_TYPE_CODE"].ToString());
                CONTROL_LOCATION = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_LOCATION"].ToString());
                CONTROL_START_DATE = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_START_DATE"].ToString().Replace("19000101", ""));
                CONTROL_END_DATE = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_END_DATE"].ToString().Replace("19000101", ""));

                CONTROL_RESULT_CODE = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_RESULT_CODE"].ToString());
                CONTROL_RESULT_TEXT = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_RESULT_TEXT"].ToString());

                if (CONTROL_TYPE_CODE != "")
                {
                    
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONTROL_TYPE_CODE + ch + CONTROL_LOCATION + ch + CONTROL_START_DATE + ch + CONTROL_END_DATE + ch + CONTROL_RESULT_CODE + ch + CONTROL_RESULT_TEXT);
                }

                sws_ctrl++;
            }
        }


        DataView sw_stmt = ds.Tables[12].DefaultView;

        sw_stmt = ds.Tables[12].DefaultView;
        //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
        sw_stmt.RowFilter = "Isnull(STMT_TYPE,'') <> ''";

        DataSet ds_stmt = new DataSet();
        ds_stmt.Tables.Add(sw_stmt.ToTable());

        if (ds_stmt.Tables[0].Rows.Count > 0)
        {
            int sws_stmt = 0;
            sw.WriteLine("<TABLE>STATEMENT");
            while (ds_stmt.Tables[0].Rows.Count > sws_stmt)
            {
                STMT_TYPE = "";
                INVOICE_SLNO = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["ITEM_SLNO"].ToString());

                STMT_DECLARATION_TYPE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_DECLARATION_TYPE"].ToString());

                STMT_DECLARATION_NUMBER = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_DECLARATION_NUMBER"].ToString());
                STMT_DECLARATION_DATE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_DECLARATION_DATE"].ToString().Replace("19000101", ""));
                STMT_TYPE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_TYPE"].ToString());

                STMT_CODE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_CODE"].ToString());
                STMT_TEXT = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_TEXT"].ToString());

                if (STMT_TYPE != "")
                {
                   
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + STMT_DECLARATION_TYPE + ch + STMT_DECLARATION_NUMBER + ch + STMT_DECLARATION_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                }

                sws_stmt++;
            }
        }


        DataView sw_supp = ds.Tables[12].DefaultView;

        sw_supp = ds.Tables[12].DefaultView;
        //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
        sw_supp.RowFilter = "Isnull(UNIQUE_DOC_NUMBER,'') <> ''";

        DataSet ds_supp = new DataSet();
        ds_supp.Tables.Add(sw_supp.ToTable());

        if (ds_supp.Tables[0].Rows.Count > 0)
        {
            int sws_supp = 0;
            sw.WriteLine("<TABLE>SUPPORTINGDOCS");
            while (ds_supp.Tables[0].Rows.Count > sws_supp)
            {
                UNIQUE_DOC_NUMBER = "";

                INVOICE_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ITEM_SLNO"].ToString());

                SUP_DECLARATION_NUMBER = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SUP_DECLARATION_NUMBER"].ToString());
                SUP_DECLARATION_DATE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SUP_DECLARATION_DATE"].ToString().Replace("19000101", ""));
                SUP_DECLARATION_TYPE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SUP_DECLARATION_TYPE"].ToString());
                UNIQUE_DOC_NUMBER = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["UNIQUE_DOC_NUMBER"].ToString());

                DOC_TYPE_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_TYPE_CODE"].ToString());
                DOC_ISSUING_PARTY_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_CODE"].ToString());
                DOC_ISSUING_PARTY_NAME_ADD1 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString());
                DOC_ISSUING_PARTY_NAME_ADD2 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString());

                DOC_ISSUING_PARTY_CITY = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_CITY"].ToString());
                DOC_ISSUING_PARTY_PIN = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_PIN"].ToString());
                DOC_REF_NUMBER = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_REF_NUMBER"].ToString());
                PLACE_OF_ISSUE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["PLACE_OF_ISSUE"].ToString());
                DOC_ISSUE_DATE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUE_DATE"].ToString().Replace("19000101", ""));
                DOC_EXPIRY_DATE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_EXPIRY_DATE"].ToString().Replace("19000101", ""));
                BENEFICIARY_PARTY_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_CODE"].ToString());

                BENEFICIARY_PARTY_ADDRESS1 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_ADDRESS1"].ToString());
                BENEFICIARY_PARTY_ADDRESS2 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_ADDRESS2"].ToString());
                BENEFICIARY_PARTY_CITY = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_CITY"].ToString());
                BENEFICIARY_PARTY_PIN = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_PIN"].ToString());
                FILE_TYPE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["FILE_TYPE"].ToString());


                if (UNIQUE_DOC_NUMBER != "")
                {
                   
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SUP_DECLARATION_NUMBER + ch + SUP_DECLARATION_DATE + ch + SUP_DECLARATION_TYPE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CHA_NO + ch + IEC_NO + ch + ICEGATE_ID + ch + UNIQUE_DOC_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE);
                }

                sws_supp++;
            }
        }


        //---------------Single Window Process--------------------//

        sw.WriteLine("<END-BE>");
        sw.WriteLine("TREC" + ch + ddlJobNo.SelectedValue.ToString());
        //sw.WriteLine();
        //sw.Write("/n");

        DateTime dat = System.DateTime.Now;
        string datestring = string.Format("{0:dd/MM/yyyy}", dat);

        sw.Close();
        sw.Dispose();
        if (IS_Imgbtn == "1")
        {
            Response.Write(sw.ToString());
            Response.Flush();
            // Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
    //not in use
    public string RemoveCode(string a)
    {
        if (a.Contains("-"))
        {
            string[] s3 = new string[] { };
            s3 = a.Split(new string[] { "-" }, StringSplitOptions.None);
            a = s3[0].ToString();
        }
        return a;
    }

    //not in use

    public void mail(string filenm)
    {
        //if (ICEGATE_EMAIL_ID != "" && ICEGATE_EMAIL_PWD != "")
        //{
        EMail_ID = CUSTOMS_HOUSE.Trim() + "@icegate.gov.in";


        //CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
        //ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
        //ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
        //ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

        SmtpClient client = new SmtpClient();

        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        //client.EnableSsl = true;

        //client.Host = "smtp.gmail.com";

        //client.Port = 587;


        //--------------Live Configuration-----------------//
        //client.EnableSsl = true;
        //client.Host = "smtp.mail.yahoo.com";
        //client.Port = 587;
        //--------------Live Configuration-----------------//

        //--------------Live Configuration-----------------//
        if (COMPANY_ID == "116")
        {
            client.Host = "smtp.gmail.com";//For Boxco Logistics Server
            client.Port = 25;
            client.EnableSsl = true;
        }
        else
        {
            client.Host = "smtp.mail.yahoo.com";//For ERoyal Server
            client.Port = 587;
            client.EnableSsl = true;
        }

        //--------------Live Configuration-----------------//


        //client.Host = "127.0.0.1";//For Royal Tech Server
        //client.Host = "11.0.0.3";//For Boxco Logistics Server

        //client.Port = 25;
        //client.EnableSsl = false;

        // setup Smtp authentication

        //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("sathishkumar8789@gmail.com", "skoushik");
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ICEGATE_EMAIL_ID, ICEGATE_EMAIL_PWD);
        //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("orientalmaa@gmail.com", "oriental123");

        client.UseDefaultCredentials = true;

        client.Credentials = credentials;

        MailMessage msg = new MailMessage();

        //msg.From = new MailAddress("sathishkumar8789@gmail.com");
        //msg.From = new MailAddress("orientalmaa@gmail.com");
        msg.From = new MailAddress(ICEGATE_EMAIL_ID);

        //msg.To.Add(new MailAddress("admin@royaltechsystems.co.in"));
        //msg.To.Add(new MailAddress("balaji71187@gmail.com"));
        msg.To.Add(new MailAddress(EMail_ID));

        msg.CC.Add(new MailAddress(ICEGATE_EMAIL_ID));

        //msg.Bcc.Add(new MailAddress("orientalmaa@gmail.com"));

        if (COMPANY_ID == "146")
        {
            msg.Bcc.Add(new MailAddress("edi@bwclogistics.com"));
        }
        else
        {

        }


        msg.Subject = ICEGATE_ID + "-" + ddlJobNo.SelectedValue.ToString() + "(" + "BE" + ")";

        msg.IsBodyHtml = true;

        //msg.Body = string.Format("<html><head></head><body><b>Flat File</b></body>");
        msg.Body = string.Format("<html><head></head><body><b></b></body>");

       msg.Attachments.Add(new System.Net.Mail.Attachment(filenm));

        try
        {

            client.Send(msg);

            if (msg.DeliveryNotificationOptions.ToString() == "Failure sending mail.")
            {
                Alert_msg("Failure sending mail!");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Failure sending mail!')</script>", false);
                msg.Dispose();

            }
            else
            {


                Alert_msg("Auto submitted");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Auto submitted')</script>", false);
                msg.Dispose();
            }
            //lblMsg.Text = "Your message has been successfully sent.";
        }

        catch (Exception ex)
        {
            //lblMsg.ForeColor = Color.Red;

            string messege = "Error occured while sending your message." + ex.Message;
            //lblMsg.Text = "Error occured while sending your message." + ex.Message;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('" + messege + "')</script>", false);
            Alert_msg(messege);

            msg.Dispose();

        }
        // }
        // else
        //Alert_msg("IceGate Email-Id & Password cannot be Empty");

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    [System.Web.Services.WebMethod]
    public static string Get_Import_Details(string custid)
    {
        string select_branch = "",   Working_Period = "", txtCustomHouse = "",
               txtImporterName = "",
               txtBE_Type = "",
               txtSupplier = "",
               txtNoofItems = "",
               txtNoofInvoices = "";


        try
        {
            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
                // commented for areawise implementation on 05-mar-2020
        /*
            select_branch = HttpContext.Current.Session["currentbranch"].ToString();
            select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            if (select_type_ == "Branchwise Job")
            {
                select_branch = select_branch;
            }
            else
            {
                select_branch = "";
            }

         *   * */
            select_branch = Connection.Get_Company_Type();


            CheckList chklist = new CheckList();
            chklist.JOBNo = custid;
            chklist.Ename = "select_jobno_CheckList";

            chklist.Workingperiod = select_branch;
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtImporterName = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txtBE_Type = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtSupplier = ds.Tables[1].Rows[0]["SUPPLIER_NAME"].ToString();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtNoofInvoices = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";

                    }
                    else
                    {
                        txtNoofInvoices = "";
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txtNoofItems = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";

                    }
                    else
                    {
                        txtNoofItems = "";
                    }
                }
                else
                {
                    txtSupplier = "";
                    txtNoofItems = "";
                    txtNoofInvoices = "";
                }
                General_Details Import_General = new General_Details();
                Import_General.Retrieve_GetGeneral(custid);

            }
            else
            {
                txtCustomHouse = "";
                txtImporterName = "";
                txtBE_Type = "";
                txtSupplier = "";
                txtNoofItems = "";
                txtNoofInvoices = "";

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
        custid = txtCustomHouse + "~~" + txtImporterName + "~~" + txtBE_Type + "~~" + txtSupplier + "~~" + txtNoofItems + "~~" + txtNoofInvoices;

        return custid;
    }
}