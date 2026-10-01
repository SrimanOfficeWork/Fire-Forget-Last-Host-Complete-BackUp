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

public partial class Import_Amendment : ThemeClass
{
    adminmaster erm = new adminmaster();
    Date_Time split = new Date_Time();
    DataSet dss = new DataSet();
    DataSet dss_adm = new DataSet();

    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
   
    Imp_Amendment Amnd = new Imp_Amendment();
    DataSet ds = new DataSet();

    public string ICEGATE_EMAIL_ID = "", ICEGATE_EMAIL_PWD = "";
    public string EMail_ID = "";

    public string IS_Imgbtn, IMPORTER_CLASS;
    public string GetDate_ddmmyy;
  
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "", targetPath = "";
    public string folderName = "/Submission";
    ErrorLogs er = new ErrorLogs();
    StreamWriter sw;
    public string createfilename = "";
    public char ch = Convert.ToChar(29);
    public string CHA_NO = "", ICEGATE_ID = "";
    public string PREVIOUS_UNITPRICE = "", PREVIOUS_CURRENY = "", PREVIOUS_CUSTOMSITE = "";
    public string SELECT_TYPE,SELECT_BRANCH;    
    public string COMPANY_ID = "";

    string Qry_amd_type = "";
    string Qry_amd_page = "";
    string Qry_amd_Jobno = "";
    string Qry_amd_Invslno = "";


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

    public string EXBOND_ADDL_LOAD_HSS;
    public string EXBOND_MISC_LOAD_RATE;

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
    //public string Landing_Rate = "1"; //Disabled on 28Sep2017
    public string Landing_Rate = "";//Implemented on 28Sep2017

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

    public string A_AMOUNT, B_AMOUNT, C_AMOUNT, D_AMOUNT, E_AMOUNT, F_AMOUNT, G_AMOUNT, H_AMOUNT, I_AMOUNT, J_AMOUNT, K_AMOUNT, L_AMOUNT, M_AMOUNT, N_AMOUNT, TOTAL_OTHER_AMOUNT;
    public string INV_MISC_T_F, INV_MISC_CURRENCY, INV_MISC_EXRATE, INV_MISC_CHARGES, INV_MISC_TOTAL_CHARGES;
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

    public string IGST_LEVY_NOTN;
    public string IGST_LEVY_SLNO;
    public string IGST_LEVY_RATE;
    public string IGST_LEVY_SPL;
    public string IGST_LEVY_UNIT;
    public string IGST_LEVY_SPL_TYPE;
    public string IGST_LEVY_EXCEPTION_NOTN;
    public string IGST_LEVY_EXCEPTION_SLNO;
    public string IGST_LEVY_EXCEPTION_RATE;
    public string IGST_LEVY_COMPENSATION_CESS_NOTN;
    public string IGST_LEVY_COMPENSATION_CESS_SLNO;
    public string IGST_LEVY_COMPENSATION_CESS_RATE;
    public string IGST_LEVY_COMPENSATION_CESS_SPL;
    public string IGST_LEVY_COMPENSATION_CESS_UNIT;
    public string IGST_LEVY_COMPENSATION_CESS_SPL_TYPE;
    public string IGST_LEVY_EXCEPTION_CC_NOTN;
    public string IGST_LEVY_EXCEPTION_CC_SLNO;
    public string IGST_LEVY_EXCEPTION_CC_RATE;

    public string LEVY_EXCEMPTION_NOTN_TYPE;
    public string LEVY_EXCEPTION_CC_NOTN_TYPE;


    #endregion

    #region Supporting Docs Public_Attributes

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
    
    public string DECLARATION_TYPE;
    public string IMAGE_REF_NUMBER;
    public string DOC_ISSUING_PARTY_NAME;
    public string BENEFICIARY_PARTY_NAME;
    public string SUP_DOC_ICEGATE_ID;


    #endregion Supporting Docs Public_Attributes

    #region Statement_Public_Attributes

    public string STMT_DECLARATION_TYPE;
    public string STMT_DECLARATION_NUMBER;
    public string STMT_DECLARATION_DATE;
    public string STMT_TYPE;
    public string STMT_CODE;
    public string STMT_TEXT;

    #endregion Statement_Public_Attributes

    #region SingleWindow_All_Tables

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
    public string CONTROL_MSR;
    public string CONTROL_UQC;
    public string CONTROL_SLNO;

    #endregion SingleWindow_All_Tables

    public string AMEND_TYPE_FF;

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
    public string JOB_LOCK, JOB_RELEASE, JOB_USER;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
           

            CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
            //ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            ICEGATE_ID = Connection.Get_IMP_ICEGATE_ID_New();
            ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            hdn_ICEGATE_ID_List.Value = Connection.Get_User_ICEGATE_ID_DropdownList("Load_IMP_ICEGATE_ID_dropdown");

            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Query_Reply/");
           
            if (Connection.COMPANYID() == "11" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "5" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
            {

                if (SELECT_TYPE == "Branchwise Job")
                {
                    targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "IMP_Job_history/");
                }
                else if (SELECT_TYPE == "Areawise Job")
                {
                    targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["GroupName"].ToString() + "/" + "IMP_Job_history/");
                }

                else
                {
                    targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "IMP_Job_history/");
                }

            }

            COMPANY_ID = Session["COMPANY_ID"].ToString();
              
            SELECT_BRANCH = Connection.Get_Company_Type();
            
            HDBranch.Value = SELECT_BRANCH;
            imgbtnFlatFile.Visible = false;

            if (!IsPostBack)
            {
                //txt_icegate_Id.Text = Connection.Get_Icegate_Id();
                txt_icegate_Id.Text = Connection.Get_IMP_ICEGATE_ID_New();


                if (!string.IsNullOrEmpty(Request["amd_type"]))
                {
                    Qry_amd_type = Request["amd_type"].ToString();
                }

                if (!string.IsNullOrEmpty(Request["amd_page"]))
                {
                    Qry_amd_page = Request["amd_page"].ToString();
                }
                
                if (!string.IsNullOrEmpty(Request["amd_Jobno"]))
                {
                    Qry_amd_Jobno = Request["amd_Jobno"].ToString();
                }

                if (!string.IsNullOrEmpty(Request["amd_Invslno"]))
                {
                    Qry_amd_Invslno = Request["amd_Invslno"].ToString();
                }

                Load_Amendment_Page();
                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }

                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 7;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                //ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
               // txt_jobno_search.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txt_jobno_search.ClientID + "', '" + txtCustomHouse.ClientID + "')");

            

                
                if (!string.IsNullOrEmpty(Request["jobno"]))
                {

                    if (!string.IsNullOrEmpty(Request["SUB"]))
                    {
                        //ddlJobNo.SelectedValue = Request["jobno"].ToString();
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

                    }
                }
                else
                {

                }
            }

            if (COMPANY_ID == "10" || COMPANY_ID == "2145" || COMPANY_ID == "2478")
            {
                txt_AmendmentJobno.Enabled = true;
            }
            else
            {
                txt_AmendmentJobno.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog
                (ex.Message);
        }
    }

    private void GENERAL()
    {
        setdata();
        if (dss.Tables[0].Rows.Count > 0)
        {
            //JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();

            JOBDATE = dss.Tables[0].Rows[0]["JOBDATE"].ToString();
            TRANSPORT_MODE = dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();

            BE_TYPE = dss.Tables[0].Rows[0]["BE_TYPE"].ToString();

            if (BE_TYPE == "Home")
            {
                BE_TYPE = "H";
            }
            else if (BE_TYPE == "Warehouse")
            {
                BE_TYPE = "W";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Ex-Bond")
            {
                BE_TYPE = "X";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString();
            }
            else if (BE_TYPE == "SEZ FTA-Z")
            {
                BE_TYPE = "Z";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "SEZ DTA-T")
            {
                BE_TYPE = "T";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString();
            }
            else if (BE_TYPE == "SEZ DTA-M")
            {
                BE_TYPE = "M";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Jobbing")
            {
                BE_TYPE = "J";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Repair & Return")
            {
                BE_TYPE = "R";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Exhibition")
            {
                BE_TYPE = "E";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Destruction")
            {
                BE_TYPE = "D";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Movement of Goods")
            {
                BE_TYPE = "V";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }

            CUSTOMS_HOUSE = dt.Trim(dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString().ToUpper());

            IMPORTER_NAME = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString().TrimEnd();
            ADDRESS1 = dss.Tables[0].Rows[0]["ADDRESS1"].ToString().TrimEnd();
            ADDRESS2 = dss.Tables[0].Rows[0]["ADDRESS2"].ToString().TrimEnd();
            ADDRESS3 = dss.Tables[0].Rows[0]["ADDRESS3"].ToString().TrimEnd();
            ADDRESS4 = dss.Tables[0].Rows[0]["ADDRESS4"].ToString().TrimEnd();
            ADDRESS5 = dss.Tables[0].Rows[0]["ADDRESS5"].ToString().TrimEnd();
            IEC_NO = dss.Tables[0].Rows[0]["IEC_NO"].ToString();
            BRANCH_NO = dss.Tables[0].Rows[0]["BRANCH_NO"].ToString();

            COUNTRY_ORIGIN = dss.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString();
            COUNTRY_ORIGIN = Get_Admin_Master_Codes("COUNTRY_OF_ORIGIN");

            PORT_ORIGIN = dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
            PORT_ORIGIN = Get_Admin_Master_Codes("PORT_ORIGIN");

            PORT_SHIPMENT = dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
            PORT_SHIPMENT = Get_Admin_Master_Codes("PORT_SHIPMENT");

            COUNTRY_SHIPMENT = dss.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString();
            COUNTRY_SHIPMENT = Get_Admin_Master_Codes("COUNTRY_SHIPMENT");


            FILING_STATUS = dss.Tables[0].Rows[0]["FILING_STATUS"].ToString();

            SECTION46 = dss.Tables[0].Rows[0]["SECTION46"].ToString();

            //SECTION46_DESC = dss.Tables[0].Rows[0]["SECTION46_DESC"].ToString();

            FIRSTCHECK = dss.Tables[0].Rows[0]["FIRSTCHECK"].ToString();

            FIRSTCHECK_DESC = dss.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString();

            GREEN_CHANNEL = dss.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString();

            //GREEN_CHANNEL_DESC = dss.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString();

            KACHHA_BE = dss.Tables[0].Rows[0]["KACHHA_BE"].ToString();

            //KACHHA_BE_DESC = dss.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString();

            SECTION48 = dss.Tables[0].Rows[0]["SECTION48"].ToString();

            SECTION48_DESC = dss.Tables[0].Rows[0]["SECTION48_DESC"].ToString();

            HIGH_SEA_SALE = dss.Tables[0].Rows[0]["HIGH_SEA_SALE"].ToString();

            HIGH_SEA_SALE_NAME = dss.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString();
            HIGH_SEA_IEC = dss.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString();
            HIGH_SEA_BRANCH_SL_NO = dss.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString();
            HSS_ADD1 = dss.Tables[0].Rows[0]["HSS_ADD1"].ToString();
            HSS_ADD2 = dss.Tables[0].Rows[0]["HSS_ADD2"].ToString();
            HSS_ADD3 = dss.Tables[0].Rows[0]["HSS_ADD3"].ToString();
            HSS_ADD4 = dss.Tables[0].Rows[0]["HSS_ADD4"].ToString();
            HSS_ADD5 = dss.Tables[0].Rows[0]["HSS_ADD5"].ToString();
            //WAREHOUSE_NAME = dss.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString();
            //WAREHOUSE_CODE = dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();


            if (FILING_STATUS == "P")
            {
                FILING_STATUS = "Y";
            }


            IMP_EXP_TYPE = dss.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
            //updated 22 may 2013

            //if (IMP_EXP_TYPE == "OTHERS" || IMP_EXP_TYPE == "")
            //{
            //    IMP_EXP_TYPE = "P";
            //}
            //else if (IMP_EXP_TYPE == "GOVERNMENT")
            //{
            //    IMP_EXP_TYPE = "G";
            //}
            if (IMP_EXP_TYPE == "GOVERNMENT" || IMP_EXP_TYPE == "GOVERNMENT DEPARTMENTS")
            {
                IMP_EXP_TYPE = "G";
            }
            else if (IMP_EXP_TYPE == "GOVERNMENT UNDERTAKINGS")
            {
                IMP_EXP_TYPE = "U";
            }
            else if (IMP_EXP_TYPE == "OTHERS")
            {
                IMP_EXP_TYPE = "O";
            }
            else if (IMP_EXP_TYPE == "PRIVATE")
            {
                IMP_EXP_TYPE = "P";
            }
            else if (IMP_EXP_TYPE == "JOBBING")
            {
                IMP_EXP_TYPE = "J";
            }
            else if (IMP_EXP_TYPE == "REPAIR & RETURN")
            {
                IMP_EXP_TYPE = "R";
            }
            else if (IMP_EXP_TYPE == "EXHIBITION")
            {
                IMP_EXP_TYPE = "E";
            }
            else if (IMP_EXP_TYPE == "DESTRUCTION")
            {
                IMP_EXP_TYPE = "D";
            }
            else if (IMP_EXP_TYPE == "MOVEMENT OF GOODS" || IMP_EXP_TYPE == "VESSELS")
            {
                IMP_EXP_TYPE = "V";
            }
            else if (IMP_EXP_TYPE == "SAMPLE TESTING" || IMP_EXP_TYPE == "TRADING")
            {
                IMP_EXP_TYPE = "T";
            }
            else if (IMP_EXP_TYPE == "SHIP STORES")
            {
                IMP_EXP_TYPE = "S";
            }
            else if (IMP_EXP_TYPE == "NEW AIRCRAFT")
            {
                IMP_EXP_TYPE = "A";
            }
            else if (IMP_EXP_TYPE == "HAND CARRIAGE")
            {
                IMP_EXP_TYPE = "H";
            }
            else if (IMP_EXP_TYPE == "MANUFATURED GOODS")
            {
                IMP_EXP_TYPE = "M";
            }
            else if (IMP_EXP_TYPE == "CBW")
            {
                IMP_EXP_TYPE = "W";
            }
            else
            {
                IMP_EXP_TYPE = "P";
            }

            //HSS_ADD3_4 = HSS_ADD3 + HSS_ADD4;

            HSS_ADD3_4 = HSS_ADD3;

            COMMERCIAL_DETAILS_STATUS = dss.Tables[0].Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString();
            COMMERCIAL_TAX_STATECODE = dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString();
            COMMERCIAL_TAX_TYPE = dss.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString();
            COMMERCIAL_TAX_REGISTRATION_NO = dss.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString();

            EXBOND_INBOND_BE_NO = dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString();
            EXBOND_INBOND_BE_DATE = dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString().Replace("19000101", "");
            EXBOND_BOND_NO = dss.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString();
            EXBOND_BOND_DATE = dss.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString().Replace("19000101", "");
            EXBOND_WAREHOUSE_CUSTOMS = dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString();
            //EXBOND_WAREHOUSE_CUSTOMS_CODE = dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString();
            EXBOND_NOOFPACKAGE = dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString();
            EXBOND_NOOFPACKAGE_UNITCODE = dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString();
            EXBOND_GROSS_WEIGHT = dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString();
            EXBOND_GROSS_WEIGHT_UNITCODE = dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString();
            EXBOND_DIRECT_EXBONDING = dss.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString();

            EXBOND_ADDL_LOAD_HSS = dss.Tables[0].Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString();
            EXBOND_MISC_LOAD_RATE = dss.Tables[0].Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString();

            JOB_STATUS = dss.Tables[0].Rows[0]["JOB_STATUS"].ToString();

            Authorized_Dealer_Code = dss.Tables[0].Rows[0]["ADCODE"].ToString();

            if (Authorized_Dealer_Code != "")
            {
                if (BE_TYPE == "Z" || BE_TYPE == "T" || BE_TYPE == "M" || BE_TYPE == "J" || BE_TYPE == "R" || BE_TYPE == "E" || BE_TYPE == "D" || BE_TYPE == "V")
                {
                }
                else
                {
                    Authorized_Dealer_Code = Authorized_Dealer_Code.Substring(0, 7);
                }
            }


            UCR_NO = dss.Tables[0].Rows[0]["UCR_NO"].ToString();
            UCR_TYPE = dss.Tables[0].Rows[0]["UCR_TYPE"].ToString();
            PAYMENT_METHOD_CODE = dss.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString().ToUpper();
            PRECEDING_LEVEL = dss.Tables[0].Rows[0]["PRECEDING_LEVEL"].ToString();


            Session.Remove("JOB_LOCK");
            Session["JOB_LOCK"] = JOB_STATUS;

        }

        if (dss.Tables[1].Rows.Count > 0)
        {
            BE_NO = dss.Tables[1].Rows[0]["BE_NO"].ToString();
            BE_DATE = dss.Tables[1].Rows[0]["BE_DATE"].ToString().Replace("19000101", "");
            BE_NO_OF_PACKAGES = dss.Tables[1].Rows[0]["BE_NO_OF_PACKAGES"].ToString();
            BE_PACKAGE_CODE = dss.Tables[1].Rows[0]["BE_PACKAGE_CODE"].ToString();
            BE_WEIGHT = dss.Tables[1].Rows[0]["BE_WEIGHT"].ToString();
            BE_UNIT_CODE = dss.Tables[1].Rows[0]["BE_UNIT_CODE"].ToString();
            BE_INBOND_NO = dss.Tables[1].Rows[0]["BE_INBOND_NO"].ToString();
            BE_INBOND_DATE = dss.Tables[1].Rows[0]["BE_INBOND_DATE"].ToString().Replace("19000101", "");
            BE_WAREHOUSE_CUSTOMS = dss.Tables[1].Rows[0]["BE_WAREHOUSE_CUSTOMS"].ToString();
            BE_WAREHOUSE_CUSTOMS_CODE = dss.Tables[1].Rows[0]["BE_WAREHOUSE_CUSTOMS_CODE"].ToString();
        }

        CHA_NO = ""; // CHA NO- Should not move in Amendment Flatfile
        JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
        string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

        sw.WriteLine("<TABLE>BE");
        //sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + BE_TYPE + ch + IEC_NO + ch + BRANCH_NO + ch + IMPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + IMPORTER_CLASS + ch + TRANSPORT_MODE + ch + IMP_EXP_TYPE + ch + KACHHA_BE + ch + HIGH_SEA_SALE + ch + PORT_ORIGIN + ch + CHA_NO + ch + COUNTRY_ORIGIN + ch + COUNTRY_SHIPMENT + ch + PORT_SHIPMENT + ch + GREEN_CHANNEL + ch + SECTION48 + ch + FILING_STATUS + ch + Authorized_Dealer_Code + ch + FIRSTCHECK + ch + EXBOND_WAREHOUSE_CUSTOMS_CODE + ch + EXBOND_WAREHOUSE_CUSTOMS + ch + EXBOND_INBOND_BE_NO + ch + EXBOND_INBOND_BE_DATE + ch + EXBOND_NOOFPACKAGE + ch + EXBOND_NOOFPACKAGE_UNITCODE + ch + EXBOND_GROSS_WEIGHT + ch + EXBOND_GROSS_WEIGHT_UNITCODE + ch + EXBOND_ADDL_LOAD_HSS + ch + EXBOND_MISC_LOAD_RATE + ch + UCR_NO + ch + UCR_TYPE + ch + PAYMENT_METHOD_CODE);//+ time);
        //sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + BE_TYPE + ch + IEC_NO + ch + BRANCH_NO + ch + IMPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + IMPORTER_CLASS + ch + TRANSPORT_MODE + ch + IMP_EXP_TYPE + ch + KACHHA_BE + ch + HIGH_SEA_SALE + ch + PORT_ORIGIN + ch + CHA_NO + ch + COUNTRY_ORIGIN + ch + COUNTRY_SHIPMENT + ch + PORT_SHIPMENT + ch + GREEN_CHANNEL + ch + SECTION48 + ch + FILING_STATUS + ch + Authorized_Dealer_Code + ch + FIRSTCHECK + ch + EXBOND_WAREHOUSE_CUSTOMS_CODE + ch + EXBOND_WAREHOUSE_CUSTOMS + ch + EXBOND_INBOND_BE_NO + ch + EXBOND_INBOND_BE_DATE + ch + EXBOND_NOOFPACKAGE + ch + EXBOND_NOOFPACKAGE_UNITCODE + ch + EXBOND_GROSS_WEIGHT + ch + EXBOND_GROSS_WEIGHT_UNITCODE + ch + EXBOND_ADDL_LOAD_HSS + ch + EXBOND_MISC_LOAD_RATE + ch + UCR_NO + ch + UCR_TYPE + ch + PAYMENT_METHOD_CODE);//+ time);//18-04-2022
        sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + BE_TYPE + ch + IEC_NO + ch + BRANCH_NO + ch + IMPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + IMPORTER_CLASS + ch + TRANSPORT_MODE + ch + IMP_EXP_TYPE + ch + KACHHA_BE + ch + HIGH_SEA_SALE + ch + PORT_ORIGIN + ch + CHA_NO + ch + COUNTRY_ORIGIN + ch + COUNTRY_SHIPMENT + ch + PORT_SHIPMENT + ch + GREEN_CHANNEL + ch + SECTION48 + ch + FILING_STATUS + ch + Authorized_Dealer_Code + ch + FIRSTCHECK + ch + EXBOND_WAREHOUSE_CUSTOMS_CODE + ch + EXBOND_WAREHOUSE_CUSTOMS + ch + EXBOND_INBOND_BE_NO + ch + EXBOND_INBOND_BE_DATE + ch + EXBOND_NOOFPACKAGE + ch + EXBOND_NOOFPACKAGE_UNITCODE + ch + EXBOND_GROSS_WEIGHT + ch + EXBOND_GROSS_WEIGHT_UNITCODE + ch + EXBOND_ADDL_LOAD_HSS + ch + EXBOND_MISC_LOAD_RATE + ch + UCR_NO + ch + UCR_TYPE + ch + PAYMENT_METHOD_CODE);//+ time);

    }

    private void IGM()
    {

        string[] Str_IGM_GATEWAY_PORT_CODE;
        if (BE_TYPE == "X")
        {
            //No need to display IGM & Container when BE TYPE is EX-BOND
        }
        else
        {
            int f = 0;
            setdata();
            if (dss.Tables[0].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>IGMS");

                while (dss.Tables[0].Rows.Count - 1 >= f)
                {
                    
                    IGM_NO = dt.Trim(dt.Get_Nullval(dss.Tables[0].Rows[f]["IGM_NO"].ToString()));
                    IGM_DATE = dt.Trim(dss.Tables[0].Rows[f]["IGM_DATE"].ToString().Replace("19000101", ""));
                    IGM_FLIGHT_VESSELDATE = dt.Trim(dss.Tables[0].Rows[f]["IGM_FLIGHT_VESSELDATE"].ToString().Replace("19000101", ""));
                    IGM_TRANSPORTMODE = dt.Trim(dt.Get_Nullval(dss.Tables[0].Rows[f]["IGM_TRANSPORTMODE"].ToString()));

                    if (COMPANY_ID == "247" || COMPANY_ID == "4")
                    {
                        //if (TRANSPORT_MODE == "Air" || TRANSPORT_MODE == "A")--hide on 08-04-2021
                        if (IGM_TRANSPORTMODE == "Air" || IGM_TRANSPORTMODE == "A")
                        {
                            if (FILING_STATUS == "P" || FILING_STATUS == "A")
                            {
                                IGM_FLIGHT_VESSELDATE = "";
                            }
                        }
                    }

                    //if (TRANSPORT_MODE == "Land" || TRANSPORT_MODE == "L")--hide on 08-04-2021
                    if (IGM_TRANSPORTMODE == "Land" || IGM_TRANSPORTMODE == "L")
                    {
                        IGM_GATEWAY_IGM_NO = dt.Trim(dss.Tables[0].Rows[f]["IGM_GATEWAY_IGM_NO"].ToString());
                        IGM_GATEWAY_IGM_DATE = dt.Trim(dss.Tables[0].Rows[f]["IGM_GATEWAY_IGM_DATE"].ToString().Replace("19000101", ""));
                        IGM_GATEWAY_PORT_CODE = dt.Trim(dss.Tables[0].Rows[f]["IGM_GATEWAY_PORT_CODE"].ToString()).ToUpper();


                        if (IGM_GATEWAY_PORT_CODE.Contains('-'))
                        {
                            Str_IGM_GATEWAY_PORT_CODE = IGM_GATEWAY_PORT_CODE.Split('-');

                            IGM_GATEWAY_PORT_CODE = Str_IGM_GATEWAY_PORT_CODE[1].Trim().ToUpper();
                        }
                    }
                    else
                    {

                        IGM_GATEWAY_IGM_NO = "";
                        IGM_GATEWAY_IGM_DATE = "";
                        IGM_GATEWAY_PORT_CODE = "";
                    }
                    if (IGM_TRANSPORTMODE == "Sea" || IGM_TRANSPORTMODE == "S")
                    {
                        IGM_GATEWAY_PORT_CODE = dt.Trim(dss.Tables[0].Rows[f]["IGM_GATEWAY_PORT_CODE"].ToString()).ToUpper();


                        if (IGM_GATEWAY_PORT_CODE.Contains('-'))
                        {
                            Str_IGM_GATEWAY_PORT_CODE = IGM_GATEWAY_PORT_CODE.Split('-');

                            IGM_GATEWAY_PORT_CODE = Str_IGM_GATEWAY_PORT_CODE[1].Trim().ToUpper();
                        }
                    }
                    //else
                    //{
                    //    IGM_GATEWAY_PORT_CODE = "";
                    //}
                    IGM_MAWB_MBL = dt.Trim(dss.Tables[0].Rows[f]["IGM_MAWB_MBL"].ToString());
                    IGM_MAWB_MBLDATE = dt.Trim(dss.Tables[0].Rows[f]["IGM_MAWB_MBLDATE"].ToString().Replace("19000101", ""));
                    IGM_HAWB_HBLNO = dt.Trim(dss.Tables[0].Rows[f]["IGM_HAWB_HBLNO"].ToString());
                    IGM_HAWB_HBLDATE = dt.Trim(dss.Tables[0].Rows[f]["IGM_HAWB_HBLDATE"].ToString().Replace("19000101", ""));
                    IGM_NOOFPACKAGE = dt.Trim(dss.Tables[0].Rows[f]["IGM_NOOFPACKAGE"].ToString());

                    IGM_GROSSWEIGHT = dt.Trim(dss.Tables[0].Rows[f]["IGM_GROSSWEIGHT"].ToString());
                    IGM_TYPEOFWEIGHT = dt.Trim(dss.Tables[0].Rows[f]["IGM_TYPEOFWEIGHT"].ToString());
                    IGM_PACKAGETYPE = dt.Trim(dss.Tables[0].Rows[f]["IGM_PACKAGETYPE"].ToString());

                    IGM_MARKSNOS1 = dt.Trim(dss.Tables[0].Rows[f]["IGM_MARKSNOS1"].ToString().Replace("\r\n", ""));
                    IGM_MARKSNOS2 = dt.Trim(dss.Tables[0].Rows[f]["IGM_MARKSNOS2"].ToString().Replace("\r\n", ""));
                    IGM_MARKSNOS3 = dt.Trim(dss.Tables[0].Rows[f]["IGM_MARKSNOS3"].ToString().Replace("\r\n", ""));


                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + IGM_NO + ch + IGM_DATE + ch + IGM_FLIGHT_VESSELDATE + ch + IGM_GATEWAY_IGM_NO + ch + IGM_GATEWAY_IGM_DATE + ch + IGM_GATEWAY_PORT_CODE + ch + IGM_MAWB_MBL + ch + IGM_MAWB_MBLDATE + ch + IGM_HAWB_HBLNO + ch + IGM_HAWB_HBLDATE + ch + IGM_NOOFPACKAGE + ch + IGM_GROSSWEIGHT + ch + IGM_TYPEOFWEIGHT + ch + IGM_PACKAGETYPE + ch + IGM_MARKSNOS1 + ch + IGM_MARKSNOS2 + ch + IGM_MARKSNOS3);

                    JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                    string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

                    if (ddl_AmendType.SelectedValue == "S")
                    {
                        sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + IGM_NO + ch + IGM_DATE + ch + IGM_FLIGHT_VESSELDATE + ch + IGM_GATEWAY_IGM_NO + ch + IGM_GATEWAY_IGM_DATE + ch + IGM_GATEWAY_PORT_CODE + ch + IGM_MAWB_MBL + ch + IGM_MAWB_MBLDATE + ch + IGM_HAWB_HBLNO + ch + IGM_HAWB_HBLDATE + ch + IGM_NOOFPACKAGE + ch + IGM_GROSSWEIGHT + ch + IGM_TYPEOFWEIGHT + ch + IGM_PACKAGETYPE + ch + IGM_MARKSNOS1 + ch + IGM_MARKSNOS2 + ch + IGM_MARKSNOS3);
                    }
                    else if (ddl_AmendType.SelectedValue == "A")
                    {
                        sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + IGM_NO + ch + IGM_DATE + ch + IGM_FLIGHT_VESSELDATE + ch + IGM_GATEWAY_IGM_NO + ch + IGM_GATEWAY_IGM_DATE + ch + IGM_GATEWAY_PORT_CODE + ch + IGM_MAWB_MBL + ch + IGM_MAWB_MBLDATE + ch + IGM_HAWB_HBLNO + ch + IGM_HAWB_HBLDATE + ch + IGM_NOOFPACKAGE + ch + IGM_GROSSWEIGHT + ch + IGM_TYPEOFWEIGHT + ch + IGM_PACKAGETYPE + ch + IGM_MARKSNOS1 + ch + IGM_MARKSNOS2 + ch + IGM_MARKSNOS3);
                    }
                    else if (ddl_AmendType.SelectedValue == "D")
                    {
                        sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + IGM_NO + ch + IGM_DATE + ch + IGM_FLIGHT_VESSELDATE + ch + IGM_GATEWAY_IGM_NO + ch + IGM_GATEWAY_IGM_DATE + ch + IGM_GATEWAY_PORT_CODE + ch + IGM_MAWB_MBL + ch + IGM_MAWB_MBLDATE + ch + IGM_HAWB_HBLNO + ch + IGM_HAWB_HBLDATE + ch + IGM_NOOFPACKAGE + ch + IGM_GROSSWEIGHT + ch + IGM_TYPEOFWEIGHT + ch + IGM_PACKAGETYPE + ch + IGM_MARKSNOS1 + ch + IGM_MARKSNOS2 + ch + IGM_MARKSNOS3);
                    }
                    else
                    {
                    }

                    f++;
                }
            }
        }
    }

    private void CONTAINER()
    {
        setdata();
        if (dss.Tables[0].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>CONTAINER");

            CONTAINER_IGM_NO = dt.Trim(dss.Tables[0].Rows[0]["CONTAINER_IGM_NO"].ToString());
            CONTAINER_IGM_DATE = dt.Trim(dss.Tables[0].Rows[0]["CONTAINER_IGM_DATE"].ToString().Replace("19000101", ""));
            CONTAINER_NO = dt.Trim(dss.Tables[0].Rows[0]["CONTAINER_NO"].ToString());
            SEAL_NO = dt.Trim(dss.Tables[0].Rows[0]["SEAL_NO"].ToString());
            FCL_OR_LCL = dt.Trim(dss.Tables[0].Rows[0]["FCL_OR_LCL"].ToString());

            TRUCK_NO = dt.Trim(dss.Tables[0].Rows[0]["TRUCK_NO"].ToString());

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

            JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
            string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

            if (ddl_AmendType.SelectedValue == "S")
            {
               // sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + CONTAINER_IGM_NO + ch + CONTAINER_IGM_DATE + ch + FCL_OR_LCL + ch + CONTAINER_NO + ch + SEAL_NO + ch + TRUCK_NO);
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + CONTAINER_IGM_NO + ch + CONTAINER_IGM_DATE + ch + FCL_OR_LCL + ch + CONTAINER_NO + ch + SEAL_NO + ch + TRUCK_NO);

            }
            else if (ddl_AmendType.SelectedValue == "D")
            {
                FCL_OR_LCL = ""; SEAL_NO = ""; TRUCK_NO = "";
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + CONTAINER_IGM_NO + ch + CONTAINER_IGM_DATE + ch + FCL_OR_LCL + ch + CONTAINER_NO + ch + SEAL_NO + ch + TRUCK_NO);
            }
            else
            {
            }
            
        }
    }


    private void SupportingDocs()
    {
        DataSet ds_supp = new DataSet();
        setdata();

        ds_supp = dss;

        if (ds_supp.Tables[0].Rows.Count > 0)
        {
            int sws_supp = 0;
            sw.WriteLine("<TABLE>SUPPORTINGDOCS");

            while (ds_supp.Tables[0].Rows.Count-1 >= sws_supp)
            {
                INVOICE_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ITEM_SLNO"].ToString());

                if (dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SELECT_TYPE"].ToString()) == "JOB")
                {
                    INVOICE_SLNO = "0";
                    ITEM_SLNO = "0";
                }
                else if (dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SELECT_TYPE"].ToString()) == "INVOICE")
                {
                    INVOICE_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = "0";
                }
                else if (dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SELECT_TYPE"].ToString()) == "ITEM")
                {
                    INVOICE_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ITEM_SLNO"].ToString());
                }
                else
                {
                    INVOICE_SLNO = "0";
                    ITEM_SLNO = "0";
                }


                DECLARATION_TYPE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DECLARATION_TYPE"].ToString());
                IMAGE_REF_NUMBER = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["IMAGE_REF_NUMBER"].ToString());
                DOC_TYPE_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_TYPE_CODE"].ToString());
                DOC_ISSUING_PARTY_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_CODE"].ToString());
                DOC_ISSUING_PARTY_NAME = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME"].ToString());
                DOC_ISSUING_PARTY_NAME_ADD1 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString());
                DOC_ISSUING_PARTY_NAME_ADD2 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString());
                DOC_ISSUING_PARTY_CITY = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_CITY"].ToString());
                DOC_ISSUING_PARTY_PIN = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_PIN"].ToString());

                DOC_REF_NUMBER = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_REF_NUMBER"].ToString());
                PLACE_OF_ISSUE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["PLACE_OF_ISSUE"].ToString());
                DOC_ISSUE_DATE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUE_DATE"].ToString().Replace("19000101", ""));
                DOC_EXPIRY_DATE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_EXPIRY_DATE"].ToString().Replace("19000101", ""));
                BENEFICIARY_PARTY_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_CODE"].ToString());
                BENEFICIARY_PARTY_NAME = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_NAME"].ToString());

                BENEFICIARY_PARTY_ADDRESS1 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_ADDRESS1"].ToString());
                BENEFICIARY_PARTY_ADDRESS2 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_ADDRESS2"].ToString());
                BENEFICIARY_PARTY_CITY = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_CITY"].ToString());
                BENEFICIARY_PARTY_PIN = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_PIN"].ToString());
                FILE_TYPE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["FILE_TYPE"].ToString());
                SUP_DOC_ICEGATE_ID = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ICEGATE_ID"].ToString());

                DECLARATION_TYPE = "E";
                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();

                if (SUP_DOC_ICEGATE_ID == "")
                {
                    SUP_DOC_ICEGATE_ID = ICEGATE_ID;
                }

                //--------- hide on 16-10-2020 by Chithra sugg.by Subbu sir
                //if (ds_supp.Tables[1].Rows.Count > 0)
                //{
                //    IEC_NO = ds_supp.Tables[1].Rows[0]["IEC_NO"].ToString();
                //}

                IEC_NO = "";
                CHA_NO = "";
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

                if (DECLARATION_TYPE != "")
                {
                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + DECLARATION_TYPE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CHA_NO + ch + IEC_NO + ch + ICEGATE_ID + ch + IMAGE_REF_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_NAME + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE);
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + DECLARATION_TYPE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CHA_NO + ch + IEC_NO + ch + SUP_DOC_ICEGATE_ID + ch + IMAGE_REF_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_NAME + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE);
                }

                sws_supp++;
            }

        }
    }

    private void Statement()
    {
        DataSet ds_stmt = new DataSet();
        setdata();

        ds_stmt = dss;

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

                if (STMT_TYPE != "REM")
                {
                    STMT_TEXT = "";
                }

                STMT_DECLARATION_TYPE = "B";
                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                STMT_DECLARATION_DATE = JOBDATE;
                STMT_DECLARATION_NUMBER = Convert.ToString(sws_stmt + 1);
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();
                
                if (STMT_TYPE != "")
                {
                    if (ddl_AmendType.SelectedValue == "A")
                    {
                        sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + "" + ch + "" + ch + STMT_DECLARATION_TYPE + ch + STMT_DECLARATION_NUMBER + ch + STMT_DECLARATION_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                    }
                    else
                    {
                        //sw.WriteLine("S" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + STMT_DECLARATION_TYPE + ch + STMT_DECLARATION_NUMBER + ch + STMT_DECLARATION_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                        sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + STMT_DECLARATION_TYPE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                    }
                }

                sws_stmt++;
            }
        }
    }

    private void INVOICE()
    {
        setdata();

        if (dss.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
            {
                sw.WriteLine("<TABLE>INVOICE");

                INVOICE_SLNO = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_SLNO"].ToString());
                INVOICE_NO = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_NO"].ToString());
                INVOICE_DATE = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_DATE"].ToString().Replace("19000101", ""));
                OTHER_PURCHASE_ORDER = dt.Trim(dss.Tables[0].Rows[i]["OTHER_PURCHASE_ORDER"].ToString());
                OTHER_PURCHASE_ORDER_DATE = dt.Trim(dss.Tables[0].Rows[i]["OTHER_PURCHASE_ORDER_DATE"].ToString().Replace("19000101", ""));
                OTHER_CONTRACT_NO = dt.Trim(dss.Tables[0].Rows[i]["OTHER_CONTRACT_NO"].ToString());
                OTHER_CONTRACT_DATE = dt.Trim(dss.Tables[0].Rows[i]["OTHER_CONTRACT_DATE"].ToString().Replace("19000101", ""));
                OTHER_LOC_NO = dt.Trim(dss.Tables[0].Rows[i]["OTHER_LOC_NO"].ToString());
                OTHER_LOC_DATE = dt.Trim(dss.Tables[0].Rows[i]["OTHER_LOC_DATE"].ToString().Replace("19000101", ""));
                INVOICE_EXRATE = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_EXRATE"].ToString().Replace("19000101", ""));

                SVB_RELATION = dt.Trim(dss.Tables[0].Rows[i]["SVB_RELATION"].ToString());

                if (SVB_RELATION == "Y")
                {
                    SVB_REF_NO = dt.Trim(dss.Tables[0].Rows[i]["SVB_REF_NO"].ToString());
                    SVB_REF_DATE = dt.Trim(dss.Tables[0].Rows[i]["SVB_REF_DATE"].ToString().Replace("19000101", ""));
                    SVB_CUSTOM_HOUSE = dt.Trim(dss.Tables[0].Rows[i]["SVB_CUSTOM_HOUSE"].ToString()).ToUpper();
                    SVB_LOADING_ON = dt.Trim(dss.Tables[0].Rows[i]["SVB_LOADING_ON"].ToString());
                    SVB_ASSESABLE_RATE = dt.Trim(dss.Tables[0].Rows[i]["SVB_ASSESABLE_RATE"].ToString());
                    SVB_DUTY_RATE = dt.Trim(dss.Tables[0].Rows[i]["SVB_DUTY_RATE"].ToString());

                    SVB_ASSESABLE_STATUS = dt.Trim(dss.Tables[0].Rows[i]["SVB_ASSESABLE_STATUS"].ToString());
                    SVB_DUTY_STATUS = dt.Trim(dss.Tables[0].Rows[i]["SVB_DUTY_STATUS"].ToString());
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


                INVOICE_VALUE = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_VALUE"].ToString());
                TERMS = dt.Trim(dss.Tables[0].Rows[i]["TERMS"].ToString());
                INVOICE_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_CURRENCY"].ToString());
                //Nature_of_Discount = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_CURRENCY"].ToString());
                MIS_DISCOUNT_RATE = dt.Get_Nullval(dt.Num_Trim(dss.Tables[0].Rows[i]["MIS_DISCOUNT_RATE"].ToString()));
                MIS_DISCOUNT_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_DISCOUNT_CHARGES"].ToString()));
                MIS_DISCOUNT_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["MIS_DISCOUNT_CURRENCY"].ToString());

                MIS_HIGHSEASALE_RATE = dt.Get_Nullval(dt.Num_Trim(dss.Tables[0].Rows[i]["MIS_HIGHSEASALE_RATE"].ToString()));
                MIS_HIGHSEASALE_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_HIGHSEASALE_CHARGES"].ToString()));
                MIS_HIGHSEASALE_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["MIS_HIGHSEASALE_CURRENCY"].ToString());

                MIS_FREIGHT_RATE = dt.Get_Nullval(dt.Num_Trim(dss.Tables[0].Rows[i]["MIS_FREIGHT_RATE"].ToString()));
                MIS_FREIGHT_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_FREIGHT_CHARGES"].ToString()));
                MIS_FREIGHT_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["MIS_FREIGHT_CURRENCY"].ToString());

                MIS_INSURANCE_RATE = dt.Get_Nullval_New(dt.Num_Trim(dss.Tables[0].Rows[i]["MIS_INSURANCE_RATE"].ToString()));
                MIS_INSURANCE_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_INSURANCE_CHARGES"].ToString()));
                MIS_INSURANCE_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["MIS_INSURANCE_CURRENCY"].ToString());

                D_AMOUNT = dt.Trim(dss.Tables[0].Rows[i]["D_AMOUNT"].ToString());
                M_AMOUNT = dt.Trim(dss.Tables[0].Rows[i]["M_AMOUNT"].ToString());
                N_AMOUNT = dt.Trim(dss.Tables[0].Rows[i]["N_AMOUNT"].ToString());

                MIS_RATE = dt.Get_Nullval(dt.Num_Trim(dss.Tables[0].Rows[i]["MIS_RATE"].ToString()));

                //if (TERMS == "CI")
                //{
                //    if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
                //    {
                //        MIS_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_CHARGES"].ToString() + D_AMOUNT + M_AMOUNT + N_AMOUNT));
                //        MIS_CURRENCY = dt.Trim(INVOICE_CURRENCY);
                //    }
                //    else
                //    {
                //        MIS_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_CHARGES"].ToString()));
                //        MIS_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["MIS_CURRENCY"].ToString());
                //    }
                //}
                //else
                //{
                //    MIS_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_CHARGES"].ToString()));
                //    MIS_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["MIS_CURRENCY"].ToString());
                //}

                MIS_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_CHARGES"].ToString()));
                MIS_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["MIS_CURRENCY"].ToString());



                MIS_LOADING_RATE = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_LOADING_RATE"].ToString()));
                MIS_LOADING_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_LOADING_CHARGES"].ToString()));
                MIS_LOADING_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["MIS_LOADING_CURRENCY"].ToString());

                MIS_AGENCY_RATE = dt.Get_Nullval(dt.Num_Trim(dss.Tables[0].Rows[i]["MIS_AGENCY_RATE"].ToString()));
                MIS_AGENCY_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["MIS_AGENCY_CHARGES"].ToString()));
                MIS_AGENCY_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["MIS_AGENCY_CURRENCY"].ToString());
                //string sss=ds.Tables[1].Rows[i]["OTHER_TERMS_OF_PAYMENT"].ToString();

                OTHER_NATURE_OF_TRANSACTION = dt.Trim(dss.Tables[0].Rows[i]["OTHER_NATURE_OF_TRANSACTION"].ToString());
                //OTHER_TERMS_OF_PAYMENT = dt.Trim(dt.Split(" ",(ds.Tables[1].Rows[i]["OTHER_TERMS_OF_PAYMENT"].ToString());

                OTHER_TERMS_OF_PAYMENT = dt.Trim(dss.Tables[0].Rows[i]["OTHER_TERMS_OF_PAYMENT"].ToString());
                OTHER_VALUATION_METHOD = dt.Trim(dss.Tables[0].Rows[i]["OTHER_VALUATION_METHOD"].ToString());

                SUPPLIER_NAME = dt.Trim(dss.Tables[0].Rows[i]["SUPPLIER_NAME"].ToString());
                SUPPLIER_ADDRESS = dt.Trim(dss.Tables[0].Rows[i]["SUPPLIER_ADDRESS"].ToString());
                SUPPLIER_ADDRESS1 = dt.Trim(dss.Tables[0].Rows[i]["SUPPLIER_ADDRESS1"].ToString());
                SUPPLIER_ADDRESS2 = dt.Trim(dss.Tables[0].Rows[i]["SUPPLIER_ADDRESS2"].ToString());
                SUPPLIER_COUNTRY_NAME = dt.Trim(split.Split("-", dss.Tables[0].Rows[i]["SUPPLIER_COUNTRY_NAME_NEW"].ToString()));
                SUPPLIER_COUNTRY_CODE = dt.Trim(dss.Tables[0].Rows[i]["SUPPLIER_COUNTRY_CODE"].ToString());
                SUPPLIER_COUNTRY_PINCODE = dt.Trim(dss.Tables[0].Rows[i]["SUPPLIER_COUNTRY_PINCODE"].ToString());

                SELLER_NAME = dt.Trim(dss.Tables[0].Rows[i]["SELLER_NAME"].ToString());
                SELLER_ADDRESS = dt.Trim(dss.Tables[0].Rows[i]["SELLER_ADDRESS"].ToString());
                SELLER_ADDRESS1 = dt.Trim(dss.Tables[0].Rows[i]["SELLER_ADDRESS1"].ToString());
                SELLER_ADDRESS2 = dt.Trim(dss.Tables[0].Rows[i]["SELLER_ADDRESS2"].ToString());
                SELLER_COUNTRY_NAME = dt.Trim(split.Split("-", dss.Tables[0].Rows[i]["SELLER_COUNTRY_NAME"].ToString()));
                SELLER_COUNTRY_CODE = dt.Trim(dss.Tables[0].Rows[i]["SELLER_COUNTRY_CODE"].ToString());
                SELLERCOUNTRY_PINCODE = dt.Trim(dss.Tables[0].Rows[i]["SELLERCOUNTRY_PINCODE"].ToString());

                BROKER_NAME = dt.Trim(dss.Tables[0].Rows[i]["BROKER_NAME"].ToString());
                BROKER_ADDRESS = dt.Trim(dss.Tables[0].Rows[i]["BROKER_ADDRESS"].ToString());
                BROKER_ADDRESS1 = dt.Trim(dss.Tables[0].Rows[i]["BROKER_ADDRESS1"].ToString());
                BROKER_ADDRESS2 = dt.Trim(dss.Tables[0].Rows[i]["BROKER_ADDRESS2"].ToString());
                BROKER_COUNTRY_NAME = dt.Trim(split.Split("-", dss.Tables[0].Rows[i]["BROKER_COUNTRY_NAME"].ToString()));
                BROKER_COUNTRY_CODE = dt.Trim(dss.Tables[0].Rows[i]["BROKER_COUNTRY_CODE"].ToString());
                BROKER_COUNTRY_PINCODE = dt.Trim(dss.Tables[0].Rows[i]["BROKER_COUNTRY_PINCODE"].ToString());
                string MIS_SINGLE_OR_MULTIPLE = dt.Trim(dss.Tables[0].Rows[i]["MIS_SINGLE_OR_MULITIPLE"].ToString());

                MI_FREIGHT = dt.Trim(dss.Tables[0].Rows[i]["MI_FREIGHT"].ToString());
                MI_INSURANCE = dt.Trim(dss.Tables[0].Rows[i]["MI_INSURANCE"].ToString());

                TERMS_PLACE = dt.Trim(dss.Tables[0].Rows[i]["TERMS_PLACE"].ToString());
                THIRDPARTY_NAME = dt.Trim(dss.Tables[0].Rows[i]["THIRDPARTY_NAME"].ToString());
                THIRDPARTY_ADD1 = dt.Trim(dss.Tables[0].Rows[i]["THIRDPARTY_ADD1"].ToString());
                THIRDPARTY_ADD2 = dt.Trim(dss.Tables[0].Rows[i]["THIRDPARTY_ADD2"].ToString());
                THIRDPARTY_CITY = dt.Trim(dss.Tables[0].Rows[i]["THIRDPARTY_CITY"].ToString());
                T_PARTY_COUNTRY_SUB_DIV = dt.Trim(dss.Tables[0].Rows[i]["T_PARTY_COUNTRY_SUB_DIV"].ToString());
                T_PARTY_COUNTRY_CODE = dt.Trim(dss.Tables[0].Rows[i]["T_PARTY_COUNTRY_CODE"].ToString());
                T_PARTY_PIN = dt.Trim(dss.Tables[0].Rows[i]["T_PARTY_PIN"].ToString());
                AUTHORIZED_ECONOMIC_OPERATOR_CODE = dt.Trim(dss.Tables[0].Rows[i]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString());
                A_E_O_COUNTRY = dt.Trim(dss.Tables[0].Rows[i]["A_E_O_COUNTRY"].ToString());
                AUTHORIZED_ECONOMIC_OPERATOR = dt.Trim(dss.Tables[0].Rows[i]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString());
                WHETHER_BUYER_SELLER_RELATED = dt.Trim(dss.Tables[0].Rows[i]["WHETHER_BUYER_SELLER_RELATED"].ToString());

                //IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                //BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                //COUNTRY_ORIGIN = ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString();
                //PORT_ORIGIN = ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
                //PORT_SHIPMENT = ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
                //COUNTRY_SHIPMENT = ds.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString();
                //FILING_STATUS = ds.Tables[0].Rows[0]["FILING_STATUS"].ToString();
                //SECTION46 = ds.Tables[0].Rows[0]["SECTION46"].ToString();


                //---------------- INVOICE MISC Charges -NEW
                INV_MISC_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["INV_MISC_CHARGES"].ToString()));
                INV_MISC_TOTAL_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["INV_MISC_TOTAL_CHARGES"].ToString()));
                INV_MISC_T_F = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["INV_MISC_T_F"].ToString()));

                if (MIS_SINGLE_OR_MULTIPLE == "M")
                {
                    if (TERMS == "CI")
                    {
                        if (MIS_CHARGES != "")
                        {
                            //MIS_CURRENCY = "";
                            //MIS_CHARGES = "";
                            MIS_RATE = "";
                        }
                        if (MIS_CHARGES == "" || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
                        {
                            if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
                            {
                                MIS_CURRENCY = INVOICE_CURRENCY;
                                MIS_CHARGES = Convert.ToString(Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
                            }
                            else
                            {
                                MIS_CURRENCY = "";
                                MIS_CHARGES = "";
                            }
                        }
                        else
                        {
                            if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
                            {
                                if (MIS_CURRENCY == INVOICE_CURRENCY)
                                {
                                    MIS_CURRENCY = INVOICE_CURRENCY;
                                    MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
                                }
                                else
                                {
                                    double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
                                    MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
                                    MIS_CURRENCY = INVOICE_CURRENCY;
                                    MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
                                }
                            }
                            else
                            {
                                MIS_CURRENCY = MIS_CURRENCY;
                                MIS_CHARGES = MIS_CHARGES;
                            }
                        }
                    }
                    else
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
                    if (TERMS == "CI")
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
                                if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
                                {
                                    MIS_CURRENCY = INVOICE_CURRENCY;
                                    MIS_CHARGES = Convert.ToString(Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
                                }
                                else
                                {
                                    MIS_CURRENCY = "";
                                    MIS_CHARGES = "";
                                }
                            }
                            else
                            {
                                if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
                                {
                                    if (MIS_CURRENCY == INVOICE_CURRENCY)
                                    {
                                        MIS_CURRENCY = INVOICE_CURRENCY;
                                        MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
                                    }
                                    else
                                    {
                                        double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
                                        MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
                                        MIS_CURRENCY = INVOICE_CURRENCY;
                                        MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
                                    }
                                }
                                else
                                {
                                    MIS_CURRENCY = MIS_CURRENCY;
                                    MIS_CHARGES = MIS_CHARGES;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (INV_MISC_T_F == "T")
                        {
                            double INV_MISC_TOTAL_CHARGES1 = Convert.ToDouble(INV_MISC_TOTAL_CHARGES == string.Empty ? "0.00" : INV_MISC_TOTAL_CHARGES);
                            if (INV_MISC_TOTAL_CHARGES1 > 0)
                            {
                                MIS_CHARGES = INV_MISC_TOTAL_CHARGES;
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
                if (TERMS == "CIF")
                {
                    MIS_FREIGHT_CURRENCY = "";
                    MIS_FREIGHT_CHARGES = "";
                    MIS_FREIGHT_RATE = "";

                    MIS_INSURANCE_CURRENCY = "";
                    MIS_INSURANCE_CHARGES = "";
                    MIS_INSURANCE_RATE = "";

                }

                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

                if (ddl_AmendType.SelectedValue == "S")
                {
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + INVOICE_DATE + ch + OTHER_PURCHASE_ORDER + ch + OTHER_PURCHASE_ORDER_DATE + ch + OTHER_CONTRACT_NO + ch + OTHER_CONTRACT_DATE + ch + OTHER_LOC_NO + ch + OTHER_LOC_DATE + ch + SVB_REF_NO + ch + SVB_REF_DATE + ch + SVB_ASSESABLE_RATE + ch + SVB_DUTY_RATE + ch + SVB_LOADING_ON + ch + SVB_ASSESABLE_STATUS + ch + SVB_DUTY_STATUS + ch + SVB_CUSTOM_HOUSE + ch + SUPPLIER_NAME + ch + SUPPLIER_ADDRESS + ch + SUPPLIER_ADDRESS1 + ch + SUPPLIER_ADDRESS2 + ch + SUPPLIER_COUNTRY_NAME + ch + SUPPLIER_COUNTRY_PINCODE + ch + SELLER_NAME + ch + SELLER_ADDRESS + ch + SELLER_ADDRESS1 + ch + SELLER_ADDRESS2 + ch + SELLER_COUNTRY_NAME + ch + SELLERCOUNTRY_PINCODE + ch + BROKER_NAME + ch + BROKER_ADDRESS + ch + BROKER_ADDRESS1 + ch + BROKER_ADDRESS2 + ch + BROKER_COUNTRY_NAME + ch + BROKER_COUNTRY_PINCODE + ch + INVOICE_VALUE + ch + TERMS + ch + INVOICE_CURRENCY + ch + Nature_of_Discount + ch + MIS_DISCOUNT_RATE + ch + MIS_DISCOUNT_CHARGES + ch + MIS_HIGHSEASALE_RATE + ch + MIS_HIGHSEASALE_CHARGES + ch + MIS_FREIGHT_CHARGES + ch + MIS_FREIGHT_RATE + ch + Freight_Actual + ch + MIS_FREIGHT_CURRENCY + ch + MIS_INSURANCE_CHARGES + ch + MIS_INSURANCE_RATE + ch + MIS_INSURANCE_CURRENCY + ch + MIS_CHARGES + ch + MIS_CURRENCY + ch + MIS_RATE + ch + Landing_Rate + ch + MIS_LOADING_CHARGES + ch + MIS_LOADING_CURRENCY + ch + MIS_LOADING_RATE + ch + MIS_AGENCY_CHARGES + ch + MIS_AGENCY_CURRENCY + ch + MIS_AGENCY_RATE + ch + OTHER_NATURE_OF_TRANSACTION + ch + OTHER_TERMS_OF_PAYMENT + ch + Conditions_Attached_Sale1 + ch + Conditions_Attached_Sale2 + ch + Conditions_Attached_Sale3 + ch + Conditions_Attached_Sale4 + ch + Conditions_Attached_Sale5 + ch + OTHER_VALUATION_METHOD + ch + INVOICE_NO + ch + Other_Relevant_Information + ch + TERMS_PLACE + ch + THIRDPARTY_NAME + ch + THIRDPARTY_ADD1 + ch + THIRDPARTY_ADD2 + ch + THIRDPARTY_CITY + ch + T_PARTY_COUNTRY_SUB_DIV + ch + T_PARTY_COUNTRY_CODE + ch + T_PARTY_PIN + ch + AUTHORIZED_ECONOMIC_OPERATOR_CODE + ch + A_E_O_COUNTRY + ch + AUTHORIZED_ECONOMIC_OPERATOR + ch + WHETHER_BUYER_SELLER_RELATED);
                }
                else if (ddl_AmendType.SelectedValue == "A")
                {
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + INVOICE_DATE + ch + OTHER_PURCHASE_ORDER + ch + OTHER_PURCHASE_ORDER_DATE + ch + OTHER_CONTRACT_NO + ch + OTHER_CONTRACT_DATE + ch + OTHER_LOC_NO + ch + OTHER_LOC_DATE + ch + SVB_REF_NO + ch + SVB_REF_DATE + ch + SVB_ASSESABLE_RATE + ch + SVB_DUTY_RATE + ch + SVB_LOADING_ON + ch + SVB_ASSESABLE_STATUS + ch + SVB_DUTY_STATUS + ch + SVB_CUSTOM_HOUSE + ch + SUPPLIER_NAME + ch + SUPPLIER_ADDRESS + ch + SUPPLIER_ADDRESS1 + ch + SUPPLIER_ADDRESS2 + ch + SUPPLIER_COUNTRY_NAME + ch + SUPPLIER_COUNTRY_PINCODE + ch + SELLER_NAME + ch + SELLER_ADDRESS + ch + SELLER_ADDRESS1 + ch + SELLER_ADDRESS2 + ch + SELLER_COUNTRY_NAME + ch + SELLERCOUNTRY_PINCODE + ch + BROKER_NAME + ch + BROKER_ADDRESS + ch + BROKER_ADDRESS1 + ch + BROKER_ADDRESS2 + ch + BROKER_COUNTRY_NAME + ch + BROKER_COUNTRY_PINCODE + ch + INVOICE_VALUE + ch + TERMS + ch + INVOICE_CURRENCY + ch + Nature_of_Discount + ch + MIS_DISCOUNT_RATE + ch + MIS_DISCOUNT_CHARGES + ch + MIS_HIGHSEASALE_RATE + ch + MIS_HIGHSEASALE_CHARGES + ch + MIS_FREIGHT_CHARGES + ch + MIS_FREIGHT_RATE + ch + Freight_Actual + ch + MIS_FREIGHT_CURRENCY + ch + MIS_INSURANCE_CHARGES + ch + MIS_INSURANCE_RATE + ch + MIS_INSURANCE_CURRENCY + ch + MIS_CHARGES + ch + MIS_CURRENCY + ch + MIS_RATE + ch + Landing_Rate + ch + MIS_LOADING_CHARGES + ch + MIS_LOADING_CURRENCY + ch + MIS_LOADING_RATE + ch + MIS_AGENCY_CHARGES + ch + MIS_AGENCY_CURRENCY + ch + MIS_AGENCY_RATE + ch + OTHER_NATURE_OF_TRANSACTION + ch + OTHER_TERMS_OF_PAYMENT + ch + Conditions_Attached_Sale1 + ch + Conditions_Attached_Sale2 + ch + Conditions_Attached_Sale3 + ch + Conditions_Attached_Sale4 + ch + Conditions_Attached_Sale5 + ch + OTHER_VALUATION_METHOD + ch + INVOICE_NO + ch + Other_Relevant_Information + ch + TERMS_PLACE + ch + THIRDPARTY_NAME + ch + THIRDPARTY_ADD1 + ch + THIRDPARTY_ADD2 + ch + THIRDPARTY_CITY + ch + T_PARTY_COUNTRY_SUB_DIV + ch + T_PARTY_COUNTRY_CODE + ch + T_PARTY_PIN + ch + AUTHORIZED_ECONOMIC_OPERATOR_CODE + ch + A_E_O_COUNTRY + ch + AUTHORIZED_ECONOMIC_OPERATOR + ch + WHETHER_BUYER_SELLER_RELATED);
                }
                else if (ddl_AmendType.SelectedValue == "D")
                {
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "");
                }
                else
                {
                }

            }
        }
    }

    private void ITEM()
    {
        int j = 0;
        setdata();
        if (dss.Tables[0].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>ITEMS");
            
            while (dss.Tables[0].Rows.Count - 1 >= j)
            {

                INVOICE_SLNO = dt.Trim(dss.Tables[0].Rows[j]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(dss.Tables[0].Rows[j]["ITEM_SLNO"].ToString());
                ITEM_QTY = dt.Trim(dss.Tables[0].Rows[j]["ITEM_QTY"].ToString());
                ITEM_QTY_CODE = dt.Trim(dss.Tables[0].Rows[j]["ITEM_QTY_CODE"].ToString());
                CTH_NO = dt.Trim(dss.Tables[0].Rows[j]["CTH_NO"].ToString());
                PRODUCT_CTH = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_CTH"].ToString());

                ITEM_DESCRIPTION1 = dt.Trim(dss.Tables[0].Rows[j]["ITEM_DESCRIPTION1"].ToString());
                ITEM_DESCRIPTION2 = dt.Trim(dss.Tables[0].Rows[j]["ITEM_DESCRIPTION2"].ToString());
                SCHEME_CODE_FULL = dt.Trim(dss.Tables[0].Rows[j]["SCHEME_CODE"].ToString());
                SCHEME_CODE = dt.Split("-", SCHEME_CODE_FULL);
                if (dt.Trim(SCHEME_CODE) == "00")
                    SCHEME_CODE = "";
                GENEARL_DESCRIPTION = dt.Trim(dss.Tables[0].Rows[j]["GENEARL_DESCRIPTION"].ToString());
                ACCESSORIES = dt.Trim(dss.Tables[0].Rows[j]["ACCESSORIES"].ToString());
                MANUFACTURER = dt.Trim(dss.Tables[0].Rows[j]["MANUFACTURER"].ToString());
                BRAND = dt.Trim(dss.Tables[0].Rows[j]["BRAND"].ToString());
                MODEL = dt.Trim(dss.Tables[0].Rows[j]["MODEL"].ToString());
                END_USE_OF_ITEM = dt.Trim(dss.Tables[0].Rows[j]["END_USE_OF_ITEM"].ToString()).ToUpper();

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


                COUNTRY_OF_ORIGIN = dt.Trim(split.Split("-", dss.Tables[0].Rows[j]["COUNTRY_OF_ORIGIN"].ToString()));
                COUNTRY_ORIGIN = COUNTRY_OF_ORIGIN;
                //if (COUNTRY_OF_ORIGIN.Contains("-"))
                //{
                //    string[] s3 = new string[] { };
                //    s3 = COUNTRY_OF_ORIGIN.Split(new string[] { "-" }, StringSplitOptions.None);
                //    COUNTRY_OF_ORIGIN = s3[0].ToString();
                //}

                COUNTRY_OF_ORIGIN = Get_Admin_Master_Codes("COUNTRY_OF_ORIGIN");


                //DataView view1 = dss_adm.Tables[0].DefaultView;

                //view1 = dss_adm.Tables[1].DefaultView;
                //view1.RowFilter = "COUNTRY_NAME = '" + COUNTRY_OF_ORIGIN + "'";
                //DataSet dt_1 = new DataSet();
                //dt_1.Tables.Add(view1.ToTable());
                //if (dt_1.Tables[0].Rows.Count > 0)
                //{
                //    COUNTRY_OF_ORIGIN = dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
                //}


                PRODUCT_CETH = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_CETH"].ToString());
                PRODUCT_BCD_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_BCD_NOTN"].ToString());
                PRODUCT_BCD_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_BCD_SLNO"].ToString());

                PRODUCT_EDU_CESS_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_EDU_CESS_NOTN"].ToString());
                PRODUCT_EDU_CESS_NOTN_SL = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_EDU_CESS_NOTN_SL"].ToString());

                PRODUCT_CVD_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_CVD_NOTN"].ToString());
                PRODUCT_CVD_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_CVD_SLNO"].ToString());

                PRODUCT_ADDL_GSI_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_ADDL_GSI_NOTN"].ToString());
                PRODUCT_ADDL_GSI_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_ADDL_GSI_SLNO"].ToString());
                PRODUCT_ADDL_SHEII_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_ADDL_SHEII_NOTN"].ToString());
                PRODUCT_ADDL_SHEII_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_ADDL_SHEII_SLNO"].ToString());
                PRODUCT_ADDL_TTA_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_ADDL_TTA_NOTN"].ToString());
                PRODUCT_ADDL_TTA_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_ADDL_TTA_SLNO"].ToString());
                PRODUCT_ADDL_DUTY_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_ADDL_DUTY_NOTN"].ToString());
                PRODUCT_ADDL_DUTY_NOTN_SL = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString());
                PRODUCT_NCD_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_NCD_NOTN"].ToString());
                PRODUCT_NCD_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_NCD_SLNO"].ToString());
                ANTI_DUMPING_NOTN = dt.Trim(dss.Tables[0].Rows[j]["ANTI_DUMPING_NOTN"].ToString());
                ANTI_DUMPING_NOTN_SLNO = dt.Trim(dss.Tables[0].Rows[j]["ANTI_DUMPING_NOTN_SLNO"].ToString());
                CTH_SLNO = dt.Trim(dss.Tables[0].Rows[j]["CTH_SLNO"].ToString());
                CTH_SUPPLIER_SLNO = dt.Trim(dss.Tables[0].Rows[j]["CTH_SUPPLIER_SLNO"].ToString());
                CTH_QTY = dt.Trim(dss.Tables[0].Rows[j]["CTH_QTY"].ToString());
                PRODUCT_TARIFF_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_TARIFF_NOTN"].ToString());

                PRODUCT_TARIFF_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_TARIFF_SLNO"].ToString());

                if (PRODUCT_TARIFF_NOTN.Trim() == "36/2001" && PRODUCT_TARIFF_SLNO.Trim() == "2(1)A")
                {
                    PRODUCT_TARIFF_QTY = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_TARIFF_QTY"].ToString());
                }
                else
                {
                    PRODUCT_TARIFF_QTY = "";
                }

                PRODUCT_SAPTA_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_SAPTA_NOTN"].ToString());
                PRODUCT_SAPTA_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_SAPTA_SLNO"].ToString());

                PRODUCT_ADDL_HEALTH_CESS_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString());
                PRODUCT_ADDL_HEALTH_CESS_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString());
                PRODUCT_CESS_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_CESS_NOTN"].ToString());
                PRODUCT_CESS_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_CESS_SLNO"].ToString());
                PRODUCT_AGGREGATE_DUTY_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString());
                PRODUCT_AGGREGATE_DUTY_NOTN_SL = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString());
                PRODUCT_SAFEGUARD_NOTN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_SAFEGUARD_NOTN"].ToString());
                PRODUCT_SAFEGUARD_SLNO = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_SAFEGUARD_SLNO"].ToString());
                ITEM_UNIT_PRICE = dt.amt_Trim(dss.Tables[0].Rows[j]["ITEM_UNIT_PRICE"].ToString());

                CTH_QTY1 = dt.Trim(dss.Tables[0].Rows[j]["CTH_QTY1"].ToString());
                CTH_QTY2 = dt.Trim(dss.Tables[0].Rows[j]["CTH_QTY2"].ToString());

                CTH_QTY1 = "";
                CTH_QTY2 = "";

                PREVIOUS_BE_NO = dt.Trim(dss.Tables[0].Rows[j]["PREVIOUS_BE_NO"].ToString());
                PREVIOUS_BE_DATE = dt.Trim(dss.Tables[0].Rows[j]["PREVIOUS_BE_DATE"].ToString().Replace("19000101", ""));
                UNIT_PRICE = dt.amt_Trim(dss.Tables[0].Rows[j]["UNIT_PRICE"].ToString());

                UNIT_CODE = dt.Trim(dss.Tables[0].Rows[j]["UNIT_CODE"].ToString());
                PREVIOUS_CUSTOMS_HOUSE = dt.Trim(dss.Tables[0].Rows[j]["CUSTOMS_HOUSE"].ToString()).ToUpper();

                PRODUCT_MRP_YN = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_MRP_YN"].ToString());


                PRODUCT_CVD_EDU_CESS_RATE = dt.Trim(dss.Tables[0].Rows[j]["PRODUCT_CVD_EDU_CESS_RATE"].ToString());
                CETH_CVD_EDU_CESS_SL = dt.Trim(dss.Tables[0].Rows[j]["CETH_CVD_EDU_CESS_SL"].ToString());


                PRODUCT_CVD_EDU_CESS_RATE = dt.Trim(dss.Tables[0].Rows[j]["SOCIAL_WELFARE_NOTN"].ToString());
                CETH_CVD_EDU_CESS_SL = dt.Trim(dss.Tables[0].Rows[j]["SOCIAL_WELFARE_NOTN_SLNO"].ToString());

                //----------------ITEMWISE SVB FOR NIPPON EXPPRESS-----------------//                

                ITEM_SVB_RELATION = dt.Trim(dss.Tables[0].Rows[j]["SVB_RELATION"].ToString());

                if (ITEM_SVB_RELATION == "true")
                {
                    ITEM_SVB_REF_NO = dt.Trim(dss.Tables[0].Rows[j]["SVB_REF_NO"].ToString());
                    ITEM_SVB_REF_DATE = dt.Trim(dss.Tables[0].Rows[j]["SVB_REF_DATE"].ToString().Replace("19000101", ""));
                    ITEM_SVB_CUSTOM_HOUSE = dt.Trim(dss.Tables[0].Rows[j]["SVB_CUSTOM_HOUSE"].ToString()).ToUpper();
                    ITEM_SVB_LOADING_ON = dt.Trim(dss.Tables[0].Rows[j]["SVB_LOADING_ON"].ToString());

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


                    ITEM_SVB_ASSESABLE_RATE = dt.Trim(dss.Tables[0].Rows[j]["SVB_ASSESABLE_RATE"].ToString());
                    ITEM_SVB_DUTY_RATE = dt.Trim(dss.Tables[0].Rows[j]["SVB_DUTY_RATE"].ToString());

                    ITEM_SVB_ASSESABLE_STATUS = dt.Trim(dss.Tables[0].Rows[j]["SVB_ASSESABLE_STATUS"].ToString());
                    ITEM_SVB_DUTY_STATUS = dt.Trim(dss.Tables[0].Rows[j]["SVB_DUTY_STATUS"].ToString());
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


                RSP_APPLICABLE = dt.Trim(dss.Tables[0].Rows[j]["RSP_APPLICABLE"].ToString());
                CENTRAL_EXCISE_FALG = dt.Trim(dss.Tables[0].Rows[j]["CENTRAL_EXCISE_FLAG"].ToString());
                MANUFACTURER_PRODUCER = dt.Trim(dss.Tables[0].Rows[j]["MANUFACTURER_PRODUCER"].ToString());
                M_P_GROWER_CODE = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_CODE"].ToString());
                M_P_GROWER_ADD1 = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_ADD1"].ToString());
                M_P_GROWER_ADD2 = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_ADD2"].ToString());
                M_P_GROWER_CITY = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_CITY"].ToString());
                M_P_GROWER_COUNTRY_SUBDIV = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_COUNTRY_SUBDIV"].ToString());
                M_P_GROWER_PIN = dt.amt_Trim(dss.Tables[0].Rows[j]["M_P_GROWER_PIN"].ToString());
                M_P_GROWER_COUNTRY = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_COUNTRY"].ToString()).ToUpper();
                SOURCE_COUNTRY = dt.Trim(dss.Tables[0].Rows[j]["SOURCE_COUNTRY"].ToString()).ToUpper();
                TRANSIT_COUNTRY = dt.Trim(dss.Tables[0].Rows[j]["TRANSIT_COUNTRY"].ToString()).ToUpper();
                ACCESSORY_STATUS = dt.Trim(dss.Tables[0].Rows[j]["ACCESSORY_STATUS"].ToString());


                //--------------- REIMPORT Y / N ---------------------
                if (dss.Tables[1].Rows.Count > 0)
                {
                    WHETHER_REIMPORT = dss.Tables[1].Rows[0]["RE_IMPORT_Y_N"].ToString();
                }
                else
                {
                    WHETHER_REIMPORT = "N";
                }

                if (PRODUCT_MRP_YN == "N")
                {
                    WHETHER_RSP_DECLARED = "N";
                    if (RSP_APPLICABLE == "")
                    {
                        RSP_APPLICABLE = "N";
                    }
                }
                else
                {
                    WHETHER_RSP_DECLARED = "Y";
                }

                if (PRODUCT_ADDL_DUTY_NOTN == "019/2006")
                {
                    PRODUCT_ADDL_DUTY_NOTN = "";
                    PRODUCT_ADDL_DUTY_NOTN_SL = "";
                }

                if (ANTI_DUMPING_NOTN == "")
                {
                    ANTI_DUMPING_NOTN_SLNO = "";
                }


                //if (PRODUCT_CETH.Substring(0, 2) != "24" && PRODUCT_CETH.Substring(0, 2) != "27")
                //{
                //    PRODUCT_CETH = "NOEXCISE";
                //    PRODUCT_CVD_NOTN = "";
                //    PRODUCT_CVD_SLNO = "";
                //}

                //if (PRODUCT_CETH.Substring(0, 2) != "24")
                //{
                //    PRODUCT_CETH = "NOEXCISE";
                //    PRODUCT_CVD_NOTN = "";
                //    PRODUCT_CVD_SLNO = "";
                //}

                //************************************ GST CHANGES 18-07-2017 -- by CHITHRA - START*******************************************

                if (PRODUCT_CETH != "24022090" && PRODUCT_CETH != "27090000" && PRODUCT_CETH != "27011100")
                {
                    PRODUCT_CETH = "NOEXCISE";
                    PRODUCT_CVD_NOTN = "";
                    PRODUCT_CVD_SLNO = "";
                }

                /* HIDE BY CHITHRA SUGGEST BY BALA SIR FOR FAIRMACS ON 02-06-2018
                PRODUCT_CETH = "NOEXCISE";
                PRODUCT_CVD_NOTN = "";
                PRODUCT_CVD_SLNO = "";
                */

                PRODUCT_NCD_NOTN = "";
                PRODUCT_NCD_SLNO = "";
                //PRODUCT_ADDL_DUTY_NOTN = "";
                //PRODUCT_ADDL_DUTY_NOTN_SL = "";

                PRODUCT_ADDL_HEALTH_CESS_NOTN = "";
                PRODUCT_ADDL_HEALTH_CESS_SLNO = "";

                //************************************ GST CHANGES 18-07-2017 -- by CHITHRA  - END*******************************************


                //PRODUCT_CETH

                //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_QTY + ch + ITEM_QTY_CODE + ch + CTH_NO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + SCHEME_CODE + ch + GENEARL_DESCRIPTION + ch + ACCESSORIES + ch + MANUFACTURER + ch + BRAND + ch + MODEL + ch + END_USE_OF_ITEM + ch + COUNTRY_OF_ORIGIN + ch + PRODUCT_CTH + ch + PREFERENTIAL + ch + PRODUCT_CETH + ch + PRODUCT_BCD_NOTN + ch + PRODUCT_BCD_SLNO + ch + PRODUCT_CVD_NOTN + ch + PRODUCT_CVD_SLNO + ch + PRODUCT_ADDL_GSI_NOTN + ch + PRODUCT_ADDL_GSI_SLNO + ch + PRODUCT_ADDL_SHEII_NOTN + ch + PRODUCT_ADDL_SHEII_SLNO + ch + PRODUCT_ADDL_TTA_NOTN + ch + PRODUCT_ADDL_TTA_SLNO + ch + PRODUCT_EDU_CESS_NOTN + ch + PRODUCT_EDU_CESS_NOTN_SL + ch + PRODUCT_CVD_EDU_CESS_RATE + ch + CETH_CVD_EDU_CESS_SL + ch + PRODUCT_NCD_NOTN + ch + PRODUCT_NCD_SLNO + ch + ANTI_DUMPING_NOTN + ch + ANTI_DUMPING_NOTN_SLNO + ch + CTH_SLNO + ch + CTH_SUPPLIER_SLNO + ch + CTH_QTY + ch + PRODUCT_TARIFF_NOTN + ch + PRODUCT_TARIFF_SLNO + ch + PRODUCT_TARIFF_QTY + ch + PRODUCT_SAPTA_NOTN + ch + PRODUCT_SAPTA_SLNO + ch + PRODUCT_ADDL_HEALTH_CESS_NOTN + ch + PRODUCT_ADDL_HEALTH_CESS_SLNO + ch + PRODUCT_ADDL_DUTY_NOTN + ch + PRODUCT_ADDL_DUTY_NOTN_SL + ch + PRODUCT_AGGREGATE_DUTY_NOTN + ch + PRODUCT_AGGREGATE_DUTY_NOTN_SL + ch + PRODUCT_SAFEGUARD_NOTN + ch + PRODUCT_SAFEGUARD_SLNO + ch + ITEM_UNIT_PRICE + ch + DISCOUNT_RATE + ch + DISCOUNT_AMOUNT + ch + CTH_QTY1 + ch + CTH_QTY2 + ch + ITEM_SVB_REF_NO + ch + ITEM_SVB_REF_DATE + ch + ITEM_SVB_ASSESABLE_RATE + ch + ITEM_SVB_DUTY_RATE + ch + ITEM_SVB_LOADING_ON + ch + ITEM_SVB_ASSESABLE_STATUS + ch + ITEM_SVB_DUTY_STATUS + ch + ITEM_SVB_CUSTOM_HOUSE + ch + POLICY_PARA_NO + ch + POLICY_YEAR + ch + RSP_APPLICABLE + ch + WHETHER_REIMPORT + ch + PREVIOUS_BE_NO + ch + PREVIOUS_BE_DATE + ch + PREVIOUS_UNITPRICE + ch + PREVIOUS_CURRENY + ch + PREVIOUS_CUSTOMS_HOUSE + ch + CENTRAL_EXCISE_FALG + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_COUNTRY + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS);



                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

                if (ddl_AmendType.SelectedValue == "S")
                {
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_QTY + ch + ITEM_QTY_CODE + ch + CTH_NO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + SCHEME_CODE + ch + GENEARL_DESCRIPTION + ch + ACCESSORIES + ch + MANUFACTURER + ch + BRAND + ch + MODEL + ch + END_USE_OF_ITEM + ch + COUNTRY_OF_ORIGIN + ch + PRODUCT_CTH + ch + PREFERENTIAL + ch + PRODUCT_CETH + ch + PRODUCT_BCD_NOTN + ch + PRODUCT_BCD_SLNO + ch + PRODUCT_CVD_NOTN + ch + PRODUCT_CVD_SLNO + ch + PRODUCT_ADDL_GSI_NOTN + ch + PRODUCT_ADDL_GSI_SLNO + ch + PRODUCT_ADDL_SHEII_NOTN + ch + PRODUCT_ADDL_SHEII_SLNO + ch + PRODUCT_ADDL_TTA_NOTN + ch + PRODUCT_ADDL_TTA_SLNO + ch + PRODUCT_EDU_CESS_NOTN + ch + PRODUCT_EDU_CESS_NOTN_SL + ch + PRODUCT_CVD_EDU_CESS_RATE + ch + CETH_CVD_EDU_CESS_SL + ch + PRODUCT_NCD_NOTN + ch + PRODUCT_NCD_SLNO + ch + ANTI_DUMPING_NOTN + ch + ANTI_DUMPING_NOTN_SLNO + ch + CTH_SLNO + ch + CTH_SUPPLIER_SLNO + ch + CTH_QTY + ch + PRODUCT_TARIFF_NOTN + ch + PRODUCT_TARIFF_SLNO + ch + PRODUCT_TARIFF_QTY + ch + PRODUCT_SAPTA_NOTN + ch + PRODUCT_SAPTA_SLNO + ch + PRODUCT_ADDL_HEALTH_CESS_NOTN + ch + PRODUCT_ADDL_HEALTH_CESS_SLNO + ch + PRODUCT_ADDL_DUTY_NOTN + ch + PRODUCT_ADDL_DUTY_NOTN_SL + ch + PRODUCT_AGGREGATE_DUTY_NOTN + ch + PRODUCT_AGGREGATE_DUTY_NOTN_SL + ch + PRODUCT_SAFEGUARD_NOTN + ch + PRODUCT_SAFEGUARD_SLNO + ch + ITEM_UNIT_PRICE + ch + DISCOUNT_RATE + ch + DISCOUNT_AMOUNT + ch + CTH_QTY1 + ch + CTH_QTY2 + ch + ITEM_SVB_REF_NO + ch + ITEM_SVB_REF_DATE + ch + ITEM_SVB_ASSESABLE_RATE + ch + ITEM_SVB_DUTY_RATE + ch + ITEM_SVB_LOADING_ON + ch + ITEM_SVB_ASSESABLE_STATUS + ch + ITEM_SVB_DUTY_STATUS + ch + ITEM_SVB_CUSTOM_HOUSE + ch + POLICY_PARA_NO + ch + POLICY_YEAR + ch + RSP_APPLICABLE + ch + WHETHER_REIMPORT + ch + PREVIOUS_BE_NO + ch + PREVIOUS_BE_DATE + ch + PREVIOUS_UNITPRICE + ch + PREVIOUS_CURRENY + ch + PREVIOUS_CUSTOMS_HOUSE + ch + CENTRAL_EXCISE_FALG + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_COUNTRY + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS);
                }
                else if (ddl_AmendType.SelectedValue == "A")
                {
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_QTY + ch + ITEM_QTY_CODE + ch + CTH_NO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + SCHEME_CODE + ch + GENEARL_DESCRIPTION + ch + ACCESSORIES + ch + MANUFACTURER + ch + BRAND + ch + MODEL + ch + END_USE_OF_ITEM + ch + COUNTRY_OF_ORIGIN + ch + PRODUCT_CTH + ch + PREFERENTIAL + ch + PRODUCT_CETH + ch + PRODUCT_BCD_NOTN + ch + PRODUCT_BCD_SLNO + ch + PRODUCT_CVD_NOTN + ch + PRODUCT_CVD_SLNO + ch + PRODUCT_ADDL_GSI_NOTN + ch + PRODUCT_ADDL_GSI_SLNO + ch + PRODUCT_ADDL_SHEII_NOTN + ch + PRODUCT_ADDL_SHEII_SLNO + ch + PRODUCT_ADDL_TTA_NOTN + ch + PRODUCT_ADDL_TTA_SLNO + ch + PRODUCT_EDU_CESS_NOTN + ch + PRODUCT_EDU_CESS_NOTN_SL + ch + PRODUCT_CVD_EDU_CESS_RATE + ch + CETH_CVD_EDU_CESS_SL + ch + PRODUCT_NCD_NOTN + ch + PRODUCT_NCD_SLNO + ch + ANTI_DUMPING_NOTN + ch + ANTI_DUMPING_NOTN_SLNO + ch + CTH_SLNO + ch + CTH_SUPPLIER_SLNO + ch + CTH_QTY + ch + PRODUCT_TARIFF_NOTN + ch + PRODUCT_TARIFF_SLNO + ch + PRODUCT_TARIFF_QTY + ch + PRODUCT_SAPTA_NOTN + ch + PRODUCT_SAPTA_SLNO + ch + PRODUCT_ADDL_HEALTH_CESS_NOTN + ch + PRODUCT_ADDL_HEALTH_CESS_SLNO + ch + PRODUCT_ADDL_DUTY_NOTN + ch + PRODUCT_ADDL_DUTY_NOTN_SL + ch + PRODUCT_AGGREGATE_DUTY_NOTN + ch + PRODUCT_AGGREGATE_DUTY_NOTN_SL + ch + PRODUCT_SAFEGUARD_NOTN + ch + PRODUCT_SAFEGUARD_SLNO + ch + ITEM_UNIT_PRICE + ch + DISCOUNT_RATE + ch + DISCOUNT_AMOUNT + ch + CTH_QTY1 + ch + CTH_QTY2 + ch + ITEM_SVB_REF_NO + ch + ITEM_SVB_REF_DATE + ch + ITEM_SVB_ASSESABLE_RATE + ch + ITEM_SVB_DUTY_RATE + ch + ITEM_SVB_LOADING_ON + ch + ITEM_SVB_ASSESABLE_STATUS + ch + ITEM_SVB_DUTY_STATUS + ch + ITEM_SVB_CUSTOM_HOUSE + ch + POLICY_PARA_NO + ch + POLICY_YEAR + ch + RSP_APPLICABLE + ch + WHETHER_REIMPORT + ch + PREVIOUS_BE_NO + ch + PREVIOUS_BE_DATE + ch + PREVIOUS_UNITPRICE + ch + PREVIOUS_CURRENY + ch + PREVIOUS_CUSTOMS_HOUSE + ch + CENTRAL_EXCISE_FALG + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_COUNTRY + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS);
                }
                else if (ddl_AmendType.SelectedValue == "D")
                {
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "");
                }
                else
                {
                }
                j++;
            }
        }
    }

    private void SW_INFO_Type()
    {
        DataSet ds_type = new DataSet();
        setdata();

        ds_type = dss;

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

                INFO_TEXT = INFO_TEXT.Length == 1 ? INFO_TEXT : INFO_TEXT.TrimEnd('.');

                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

                if (INFO_TYPE != "")
                {
                    if (ddl_AmendType.SelectedValue == "S" || ddl_AmendType.SelectedValue == "A")
                    {
                        if (Connection.Get_User_Imp_Settings_Job_Edit("FF_FTA_EXBOND") == "E")
                        {
                            sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                        }
                        else
                        {
                            if (BE_TYPE == "X")
                            {
                                if (dt.Trim(ds_type.Tables[0].Rows[sws_type]["DEPARTMENT"].ToString()) == "FTA")
                                {
                                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                                }
                                else if (INFO_TYPE == "CHR" && INFO_QUALIFIER == "SQC")
                                {
                                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                                }
                            }
                            else
                            {
                                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                            }
                        }
                    }
                    else //"D"
                    {
                        sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "");
                    }
                }
                sws_type++;
            }
        }
    }

    private void SW_INFO_CONSTITUTE()
    {
        DataSet ds_const = new DataSet();
        setdata();

        ds_const = dss;

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

                CONSTITUENT_ELEMENT_NAME = CONSTITUENT_ELEMENT_NAME.Length == 1 ? CONSTITUENT_ELEMENT_NAME : CONSTITUENT_ELEMENT_NAME.TrimEnd('.');

                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

                if (CONSTITUENT_SRNO != "")
                {
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONSTITUENT_SRNO + ch + CONSTITUENT_ELEMENT_NAME + ch + CONSTITUENT_ELEMENT_CODE + ch + CONSTITUENT_PERCENTAGE + ch + CONSTITUENT_YIELD_PERCENTAGE + ch + ACTIVE_INGREDIENT);
                }
                sws_const++;
            }
        }
    }



    private void SW_INFO_PRODUCTION()
    {
        DataSet ds_prod = new DataSet();
        setdata();

        ds_prod = dss;

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

                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

                if (PRODUCTION_BATCH_IDENTIFIER != "")
                {
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + PRODUCTION_BATCH_IDENTIFIER + ch + PRODUCTION_BATCH_QUANTITY + ch + UNIT_QTY_CODE + ch + DATE_OF_MANUFACTURING + ch + DATE_OF_EXPIRY + ch + BEST_BEFORE);
                }
                sws_prod++;
            }
        }
    }

    private void SW_INFO_CONTROL()
    {
        DataSet ds_ctrl = new DataSet();
        setdata();

        ds_ctrl = dss;

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

                CONTROL_MSR = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_MSR"].ToString());
                CONTROL_UQC = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_UQC"].ToString());
                CONTROL_SLNO = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_SLNO"].ToString());

                CONTROL_RESULT_TEXT = CONTROL_RESULT_TEXT.Length == 1 ? CONTROL_RESULT_TEXT : CONTROL_RESULT_TEXT.TrimEnd('.');

                //if (CONTROL_TYPE_CODE != "SEC65" && BE_TYPE != "T")//01-10-2024
                if (CONTROL_TYPE_CODE != "SEC65" && CONTROL_TYPE_CODE != "SEZ")
                {
                    INVOICE_SLNO = "0";
                    ITEM_SLNO = "0";
                }

                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

                if (CONTROL_TYPE_CODE != "" || CONTROL_RESULT_CODE != "")
                {
                    //THIS line hide on 17-09-2020 for Icegate New Impelmntn 3 fileds added - by Chithra
                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONTROL_TYPE_CODE + ch + CONTROL_LOCATION + ch + CONTROL_START_DATE + ch + CONTROL_END_DATE + ch + CONTROL_RESULT_CODE + ch + CONTROL_RESULT_TEXT);
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONTROL_TYPE_CODE + ch + CONTROL_LOCATION + ch + CONTROL_START_DATE + ch + CONTROL_END_DATE + ch + CONTROL_RESULT_CODE + ch + CONTROL_RESULT_TEXT + ch + CONTROL_MSR + ch + CONTROL_UQC + ch + CONTROL_SLNO);
                }

                sws_ctrl++;
            }
        }
    }




    private void setdata()
    {
        Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
        
        
        
        
        //Amnd.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
        if (ListBox_Invoice_SlNo.SelectedItem != null)
        {
            Amnd.INVOICE_SLNO = ListBox_Invoice_SlNo.SelectedItem.Text;
        }
        else
        {
            Amnd.INVOICE_SLNO = string.Empty;
        }

        Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();

        if (ddl_AmendPage.SelectedItem.Text == "GENERAL")
        {
            Amnd.ITEM_SLNO = "";
            Amnd.SELECT_ITEM = "";
            Amnd.Ename = "select_GENERAL_Details_Flatfile";

            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "A_MAIN";
        }

        else if (ddl_AmendPage.SelectedItem.Text == "IGM" || ddl_AmendPage.SelectedItem.Text == "NOMBL_IGM")
        {
            Amnd.ITEM_SLNO = "";


            string IGM_Selected_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    IGM_Selected_ListBox += item.Value + "~";
                }
            }

            Amnd.SELECT_ITEM = IGM_Selected_ListBox;
            Amnd.Ename = "select_IGM_Details_Flatfile";

            
            /*
            if (ddl_AmendType.SelectedValue == "A" && ddl_AmendPage.SelectedItem.Text == "NOMBL_IGM")
                //AMEND_TYPE_FF = "A_IGM";//29-03-2021 for New Implementation 
                AMEND_TYPE_FF = "A_PBEIGM";
            if (ddl_AmendType.SelectedValue == "A" && ddl_AmendPage.SelectedItem.Text == "IGM")
                AMEND_TYPE_FF = "A_IGM";
             * */
            if (ddl_AmendType.SelectedValue == "A")
            {
                if (rdl_IGM.SelectedValue == "IGM")
                {
                    AMEND_TYPE_FF = "A_IGM";
                }
                else
                {
                    AMEND_TYPE_FF = "A_PBEIGM";
                }
            }

            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "S_IGMS";
            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "D_IGMS";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "CONTAINER")
        {
            Amnd.ITEM_SLNO = "";
            Amnd.SELECT_ITEM = "";
            Amnd.Ename = "select_CONTAINER_Details_Flatfile";

            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "S_CONT";
            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "D_CONT";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS")
        {
            //Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text == null ? "" : ddl_ItemSlno.SelectedItem.Text;//08-09-2021
            //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text == null ? "" : ListBox_ItemSlno.SelectedItem.Text;

            

            


            string Sup_Doc_Item_slno_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    Sup_Doc_Item_slno_ListBox += item.Value + "~";
                }
            }



            string[] sup_doc_splt = Sup_Doc_Item_slno_ListBox.Split('~');
            string invoice_list = "", item_list = "",sup_doc="";
            for (int i = 0; i < sup_doc_splt.Length; i++)
            {
                string[] item_inv_spltv2 = sup_doc_splt[i].Split('-');
                if (item_inv_spltv2[0] != "")
                {
                    invoice_list += item_inv_spltv2[0].ToString() + "~";
                    item_list += item_inv_spltv2[1].ToString() + "~";
                    sup_doc += item_inv_spltv2[2].ToString() + "~";
                }

            }

            Amnd.INVOICE_SLNO = invoice_list;
            Amnd.ITEM_SLNO = item_list;
            //Amnd.SELECT_ITEM = ListBox1.SelectedItem.Text == null ? "" : ListBox1.SelectedItem.Text;
            Amnd.SELECT_ITEM = sup_doc;
            Amnd.Ename = "select_SupDocs_Flatfile";
          
            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "S_DOCS";
            
            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "D_DOCS";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "INVOICE")
        {
            string Invoice_Selected_ListBox = "";
            foreach (ListItem invoice in ListBox_Invoice_SlNo.Items)
            {
                if (invoice.Selected)
                {
                    Invoice_Selected_ListBox += invoice.Value + "~";
                }
            }
            Amnd.INVOICE_SLNO = Invoice_Selected_ListBox;
            Amnd.ITEM_SLNO = "";
            Amnd.SELECT_ITEM = "";
            Amnd.Ename = "select_Invoice_Details_Flatfile";

            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "S_INV";
            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "A_INV";
            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "D_INV";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "ITEM")
        {
            //Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text == null ? "" : ddl_ItemSlno.SelectedItem.Text;//08-09-2021
            Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text == null ? "" : ListBox_ItemSlno.SelectedItem.Text;


            string Item_slno_ListBox = "";
            //foreach (ListItem item in ListBox1.Items)
            foreach (ListItem item in ListBox_ItemSlno.Items)
            {
                if (item.Selected)
                {
                    Item_slno_ListBox += item.Value + "~";
                }
            }
            string[] sup_doc_splt = Item_slno_ListBox.Split('~');
            string invoice_list = "", item_list = "";
            for (int i = 0; i < sup_doc_splt.Length; i++)
            {
                string[] item_inv_spltv2 = sup_doc_splt[i].Split('-');
                if (item_inv_spltv2[0] != "")
                {
                    invoice_list += item_inv_spltv2[0].ToString() + "~";
                    item_list += item_inv_spltv2[1].ToString() + "~";
                    
                }

            }
            Amnd.INVOICE_SLNO = invoice_list;
            Amnd.SELECT_ITEM = item_list;
            Amnd.Ename = "select_Item_Details_Flatfile";

            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "S_ITEM";
            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "A_ITEM";
            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "D_ITEM";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "STATEMENT")
        {
            //Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text == null ? "" : ddl_ItemSlno.SelectedItem.Text;//08-09-2021
           // Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text == null ? "" : ListBox_ItemSlno.SelectedItem.Text;

            string Sup_Doc_Item_slno_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    Sup_Doc_Item_slno_ListBox += item.Value + "~";
                }
            }


            string[] sup_doc_splt = Sup_Doc_Item_slno_ListBox.Split('~');
            string invoice_list = "", item_list = "", sup_doc = "";
            for (int i = 0; i < sup_doc_splt.Length; i++)
            {
                string[] item_inv_spltv2 = sup_doc_splt[i].Split('-');
                if (item_inv_spltv2[0] != "")
                {
                    invoice_list += item_inv_spltv2[0].ToString() + "~";
                    item_list += item_inv_spltv2[1].ToString() + "~";
                    sup_doc += item_inv_spltv2[2].ToString() + "~";
                }

            }

            Amnd.INVOICE_SLNO = invoice_list;
            Amnd.ITEM_SLNO = item_list;

            //Amnd.SELECT_ITEM = ListBox1.SelectedItem.Text == null ? "" : ListBox1.SelectedItem.Text;
            Amnd.SELECT_ITEM = sup_doc;
            Amnd.Ename = "select_SW_STATEMENT_Flatfile";

            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "A_STMT";
            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "S_STMT";
            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "D_STMT";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_INFO_TYPE")
        {
          
          

            string SW_InfoType_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    SW_InfoType_ListBox += item.Value + "~";
                }
            }

            string[] sup_doc_splt = SW_InfoType_ListBox.Split('~');
            string invoice_list = "", item_list = "", sup_doc = "";
            for (int i = 0; i < sup_doc_splt.Length; i++)
            {
                string[] item_inv_spltv2 = sup_doc_splt[i].Split('-');
                if (item_inv_spltv2[0] != "")
                {
                    invoice_list += item_inv_spltv2[0].ToString() + "~";
                    item_list += item_inv_spltv2[1].ToString() + "~";
                    sup_doc += item_inv_spltv2[2].ToString() + "~";
                }

            }

            Amnd.INVOICE_SLNO = invoice_list;
            Amnd.ITEM_SLNO = item_list;
            //Amnd.SELECT_ITEM = ListBox1.SelectedItem.Text == null ? "" : ListBox1.SelectedItem.Text;
            Amnd.SELECT_ITEM = sup_doc;
            Amnd.Ename = "select_SW_INFO_TYPE_Flatfile";

            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "A_BE_ITEM_SW_INFO_TYPE";

            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "S_BE_ITEM_SW_INFO_TYPE";

            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "D_BE_ITEM_SW_INFO_TYPE";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CONST")
        {

           
           

            string SW_InfoType_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    SW_InfoType_ListBox += item.Value + "~";
                }
            }

            string[] sup_doc_splt = SW_InfoType_ListBox.Split('~');
            string invoice_list = "", item_list = "", sup_doc = "";
            for (int i = 0; i < sup_doc_splt.Length; i++)
            {
                string[] item_inv_spltv2 = sup_doc_splt[i].Split('-');
                if (item_inv_spltv2[0] != "")
                {
                    invoice_list += item_inv_spltv2[0].ToString() + "~";
                    item_list += item_inv_spltv2[1].ToString() + "~";
                    sup_doc += item_inv_spltv2[2].ToString() + "~";
                }

            }

            Amnd.INVOICE_SLNO = invoice_list;
            Amnd.ITEM_SLNO = item_list;


            //Amnd.SELECT_ITEM = ListBox1.SelectedItem.Text == null ? "" : ListBox1.SelectedItem.Text;
            Amnd.SELECT_ITEM = sup_doc;
            Amnd.Ename = "select_SW_CONSTITUENT_Flatfile";

            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "A_BE_ITEM_SW_CONST";

            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "S_BE_ITEM_SW_CONST";

            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "D_BE_ITEM_SW_CONST";
        }

        else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_PROD")
        {

           
            

           

            string SW_InfoType_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    SW_InfoType_ListBox += item.Value + "~";
                }
            }
            string[] sup_doc_splt = SW_InfoType_ListBox.Split('~');
            string invoice_list = "", item_list = "", sup_doc = "";
            for (int i = 0; i < sup_doc_splt.Length; i++)
            {
                string[] item_inv_spltv2 = sup_doc_splt[i].Split('-');
                if (item_inv_spltv2[0] != "")
                {
                    invoice_list += item_inv_spltv2[0].ToString() + "~";
                    item_list += item_inv_spltv2[1].ToString() + "~";
                    sup_doc += item_inv_spltv2[2].ToString() + "~";
                }

            }

            Amnd.INVOICE_SLNO = invoice_list;
            Amnd.ITEM_SLNO = item_list;

            Amnd.SELECT_ITEM = sup_doc;
            Amnd.Ename = "select_SW_PRODUCTION_Flatfile";

            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "A_BE_ITEM_SW_PROD";

            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "S_BE_ITEM_SW_PROD";

            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "D_BE_ITEM_SW_PROD";
        }

        else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CTRL")
        {

           



          

            string SW_InfoType_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    SW_InfoType_ListBox += item.Value + "~";
                }
            }



            string[] sup_doc_splt = SW_InfoType_ListBox.Split('~');
            string invoice_list = "", item_list = "", sup_doc = "";
            for (int i = 0; i < sup_doc_splt.Length; i++)
            {
                string[] item_inv_spltv2 = sup_doc_splt[i].Split('-');
                if (item_inv_spltv2[0] != "")
                {
                    invoice_list += item_inv_spltv2[0].ToString() + "~";
                    item_list += item_inv_spltv2[1].ToString() + "~";
                    sup_doc += item_inv_spltv2[2].ToString() + "~";
                }

            }

            Amnd.INVOICE_SLNO = invoice_list;
            Amnd.ITEM_SLNO = item_list;



            //Amnd.SELECT_ITEM = ListBox1.SelectedItem.Text == null ? "" : ListBox1.SelectedItem.Text;
            Amnd.SELECT_ITEM = sup_doc;
            Amnd.Ename = "select_SW_CONTROL_Flatfile";

            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "A_BE_ITEM_SW_CTRL";

            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "S_BE_ITEM_SW_CTRL";

            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "D_BE_ITEM_SW_CTRL";
        }



        ViewState["AMEND_TYPE_FF"] = AMEND_TYPE_FF;
        dss = Amnd.RetrieveAll_Amend_Details();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtAmendmentReason.Text != "")
        {
            if (txtBENo.Text != "" && txtBEDate.Text != "")
            {
                if (txtQueryNo.Text != "" && txtQueryDate.Text != "")
                {
                    try
                    {
                        setdata();

                        if (dss.Tables[0].Rows.Count > 0)
                        {

                            IS_Imgbtn = "";

                            //BE_Details();
                            imgbtnFlatFile.Visible = false;
                            btnSendQueue.Visible = false;
                            //btnSubmission.Visible = false;

                            if (File.Exists(errorFolder + logFileName))
                            {
                                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                                foreach (FileInfo fi in dir.GetFiles())
                                {
                                    fi.Delete();
                                }

                                Flat_File("GenerateButton");
                                Insert_Jobno_MAX_ID();

                                imgbtnFlatFile.Visible = true;
                                //btnSubmission.Visible = true;
                                btnSendQueue.Visible = true;
                            }
                            else
                            {
                                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                                foreach (FileInfo fi in dir.GetFiles())
                                {
                                    fi.Delete();
                                }

                                Flat_File("GenerateButton");
                                Insert_Jobno_MAX_ID();

                                imgbtnFlatFile.Visible = true;
                                //btnSubmission.Visible = true;
                                btnSendQueue.Visible = true;
                            }
                        }
                        else
                        {
                            Alert_msg("Not Valid Record..!!");
                        }
                    }
                    catch (Exception ex)
                    {
                        er.makeLog(ex.Message);
                    }
                }
                else
                {
                    Alert_msg("Query No & Date - Mandatory");
                }
            }
            else
            {
                //Alert_msg("BE Number & Date - Mandatory");


                //string script = string.Format("alert('{0}');", "BE Number & Date - Mandatory");
                //if (Page != null && !Page.ClientScript.IsClientScriptBlockRegistered("alert"))
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", script, true /* addScriptTags */);
                //}

            }
        }
        else
        {
            Alert_msg("Amendment Reason - Mandatory");
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
            //btnSubmission.Enabled = false;
            imgbtnFlatFile.Enabled = false;

            btnSearch.ToolTip = "You don't have permission to access";
            //btnSubmission.ToolTip = "You don't have permission to access";
            imgbtnFlatFile.ToolTip = "You don't have permission to access";
        }
        else
        {
            btnSearch.Enabled = true;
            //btnSubmission.Enabled = true;
            imgbtnFlatFile.Enabled = true;

        }
    }


    protected void btnSubmission_Click(object sender, EventArgs e)
    {
        try
        {
            IS_Imgbtn = "";

            //BE_Details();
            imgbtnFlatFile.Visible = false;
            btnSubmission.Visible = false;
            btnSendQueue.Visible = false;

            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File("SubmissionButton");

               // mail(errorFolder + logFileName);

                imgbtnFlatFile.Visible = true;
                btnSubmission.Visible = true;
                btnSendQueue.Visible = true;
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void AUTO_JOBNO()
    {
        DataSet ds_jobno = new DataSet();
        Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
        Amnd.INVOICE_SLNO = "";
        Amnd.ITEM_SLNO = "";
        Amnd.SELECT_ITEM = "";
        Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
        Amnd.Ename = "select_MAX_ID";

        ds_jobno = Amnd.RetrieveAll_Amend_Details();

        if (ds_jobno.Tables[0].Rows.Count > 0)
        {
            txt_AmendmentJobno.Text = Fn_JOBNO(ddlJobNo.SelectedItem.Text, ds_jobno.Tables[0].Rows[0][0].ToString());
            ViewState["AmendJobno"] = txt_AmendmentJobno.Text;

            txtQueryDate.Text = System.DateTime.Now.ToShortDateString();
        }
    }


    private string Fn_JOBNO(string JOBNO, string Running_No)
    {
        string lFileName = "";
        if (JOBNO.Length == 1)
        {
            //logFileName = ddlJobNo.SelectedItem.Text + "0000" + REQUEST_NO + yy + ".beamd";
            //lFileName = ddlJobNo.SelectedItem.Text + "0000" + txtQueryNo.Text;//hide on 06-04-2022 by Chithra sugg.by Subbu sir
            //lFileName = ddlJobNo.SelectedItem.Text + "0000" + txt_AmendmentJobno.Text;
            lFileName = ddlJobNo.SelectedItem.Text + "0000" + Running_No;
        }
        else if (JOBNO.Length == 2)
        {
            lFileName = ddlJobNo.SelectedItem.Text + "000" + Running_No;
        }
        else if (JOBNO.Length == 3)
        {
            lFileName = ddlJobNo.SelectedItem.Text + "00" + Running_No;
        }
        else if (JOBNO.Length == 4)
        {
            lFileName = ddlJobNo.SelectedItem.Text + "0" + Running_No;
        }
        else
        {
            lFileName = ddlJobNo.SelectedItem.Text + Running_No;
        }
        return lFileName;
    }


  
    public void Flat_File(string process)
    {
        if (txtBENo.Text != "" && txtBEDate.Text != "")
        {
           
            //DateTime date = System.DateTime.Now;
            //string datestringg = string.Format("{0:yyyyMMdd}", date);

            DateTime date = System.DateTime.Now;

            //string datestringg = string.Format("{0:yyyyMMdd}", txtJobDate.Text);
            string datestringg = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();

            DateTime tt = System.DateTime.Now;

            string time = string.Format("{0:hhmm}", tt);

            GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
            string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();

            string be_date = Convert.ToDateTime(txtBEDate.Text).ToString("ddMMyy").ToString();

            string JOB_date = Convert.ToDateTime(txtJobDate.Text).ToString("ddMMyy").ToString();

            string beno_date = txtBENo.Text + be_date;

            string be_date_full = Convert.ToDateTime(txtBEDate.Text).ToString("yyyyMMdd").ToString();

            BE_NO = txtBENo.Text;
            BE_DATE = be_date_full;

            //int REQUEST_NO = 1;
            // REQUEST_NO = Get_Request_No_MAX();
            string REQUEST_NO = "";
            REQUEST_NO = txtQueryNo.Text;

         
            //logFileName = ddlJobNo.SelectedItem.Text + yy.Substring(0, 2) + ".be";
            //logFileName = ddlJobNo.SelectedItem.Text + yy.Substring(0, 2) + ".beamd"; 
            //logFileName = ddlJobNo.SelectedItem.Text + yy + ".beamd";// hide on 19-04-2021 sugg.by Bala sir & Sathish sir

            logFileName = ViewState["AmendJobno"].ToString() + yy + ".be";

            JOBNO = ddlJobNo.SelectedItem.Text;

            createfilename = logFileName;
            Session["createflename"] = logFileName;

            //delete the exisitng file 
            if (File.Exists(errorFolder + logFileName))
            {
                File.Delete((errorFolder + logFileName));
            }

            //

            sw = new StreamWriter(errorFolder + logFileName, true);

            CUSTOMS_HOUSE = txtCustomsHouse.Text;
            //ICEGATE_ID = Connection.Get_Icegate_Id();
            ICEGATE_ID = txt_icegate_Id.Text.Trim();

            

            string datestringg_CurrentDate = Convert.ToDateTime(date).ToString("yyyyMMdd").ToString();
            string datestringg_QueryDate = Convert.ToDateTime(txtQueryDate.Text).ToString("yyyyMMdd").ToString();

            AMEND_TYPE_FF = ViewState["AMEND_TYPE_FF"].ToString();


            if (ddl_AmendPage.SelectedItem.Text == "GENERAL")
            {
               // sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ddlJobNo.SelectedItem.Text + JOB_date + ch + datestringg + ch + time);--15-04-2022
               // sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg + ch + time);
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                GENERAL();

                sw.WriteLine("<TABLE>AMEND");
                //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg + ch);
                //this line hide on 29-03-2021 for Icegate New Implementation in QueryDate should be Current Date
                //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg);
               // sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_CurrentDate);
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);


                sw.WriteLine("<END-BE>");
                //sw.WriteLine("TREC" + ch + ddlJobNo.SelectedItem.Text + JOB_date);--15-04-2022
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }
            else if (ddl_AmendPage.SelectedItem.Text == "IGM" || ddl_AmendPage.SelectedItem.Text == "NOMBL_IGM")
            {
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                IGM();

                sw.WriteLine("<TABLE>AMEND");
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);

                sw.WriteLine("<END-BE>");
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }
            else if (ddl_AmendPage.SelectedItem.Text == "CONTAINER")
            {
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                CONTAINER();

                sw.WriteLine("<TABLE>AMEND");
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);

                sw.WriteLine("<END-BE>");
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }
            
            else if (ddl_AmendPage.SelectedItem.Text == "INVOICE")
            {
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                INVOICE();

                sw.WriteLine("<TABLE>AMEND");
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);

                sw.WriteLine("<END-BE>");
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }

            else if (ddl_AmendPage.SelectedItem.Text == "ITEM")
            {
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                ITEM();

                sw.WriteLine("<TABLE>AMEND");
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);

                sw.WriteLine("<END-BE>");
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }
            else if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS")
            {
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                sw.WriteLine("<TABLE>AMEND");
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);

                SupportingDocs();
                sw.WriteLine("<END-BE>");
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }
            else if (ddl_AmendPage.SelectedItem.Text == "STATEMENT")
            {
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                sw.WriteLine("<TABLE>AMEND");
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);

                Statement();
                sw.WriteLine("<END-BE>");
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }

            else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_INFO_TYPE")
            {
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                sw.WriteLine("<TABLE>AMEND");
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);

                SW_INFO_Type();
                sw.WriteLine("<END-BE>");
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }

            else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CONST")
            {
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                sw.WriteLine("<TABLE>AMEND");
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);

                SW_INFO_CONSTITUTE();
                sw.WriteLine("<END-BE>");
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }

            else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_PROD")
            {
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                sw.WriteLine("<TABLE>AMEND");
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);

                SW_INFO_PRODUCTION();
                sw.WriteLine("<END-BE>");
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }

            else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CTRL")
            {
                sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);

                sw.WriteLine("<TABLE>AMEND");
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + txtBENo.Text + ch + be_date_full + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + REQUEST_NO + ch + datestringg_QueryDate);

                SW_INFO_CONTROL();
                sw.WriteLine("<END-BE>");
                sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString());
            }

            //sw.WriteLine("TREC" + ch + txt_jobno_search.Text + yy.Substring(0, 2));
            //sw.WriteLine("TREC" + ch + ddlJobNo.SelectedItem.Text + yy.Substring(0, 2));

            //sw.WriteLine();
            //sw.Write("/n");

         
            DateTime dat = System.DateTime.Now;
            string datestring = string.Format("{0:dd/MM/yyyy}", dat);

            sw.Close();
            sw.Dispose();

            Job_Histroy jh = new Job_Histroy();
            if (process != "SendQueue")
            {
                //Query Reply flatfile auto save to Job History folder also for Agility by Chitha
                if (Connection.COMPANYID() == "11" || Connection.COMPANYID() == "5" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
                {
                    if (File.Exists(errorFolder + logFileName))
                    {
                        DirectoryInfo dir = new DirectoryInfo(errorFolder);

                        if (Directory.Exists(targetPath) == false)
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        string sourceFile = System.IO.Path.Combine(errorFolder, logFileName);
                        string destFile = System.IO.Path.Combine(targetPath, JOBNO + " ~~" + logFileName);

                        System.IO.File.Copy(sourceFile, destFile, true);

                        jh.JOB_ID = "";
                        jh.JOB_TYPE = "IMP";
                        jh.JOBNO = JOBNO;

                        jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
                        jh.DESCRIPTION = targetPath;
                        jh.ATTACHMENT_FILE = JOBNO + " ~~" + logFileName;
                        jh.FLAG = "Upload_File";
                        jh.USER_ID = Session["currentuser"].ToString();
                        jh.JOBDATE = "01/01/1900";

                        jh.BRANCH_CODE = SELECT_BRANCH;
                        jh.YEAR = "Amendment";
                        jh.WORKING_PERIOD = Session["WorkingPeriod"].ToString(); 
                        jh.BRANCH_COMMON = SELECT_BRANCH;
                        dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();

                    }
                    else
                    {
                        Console.WriteLine("Source path does not exist!");
                    }
                }
            }
            else if (process == "SendQueue")
            {
                //DSC_FLATFILE_INSERT_UPDATE

                string SQ_Path = string.Empty;
                string SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
                if (SELECT_TYPE == "Branchwise Job")
                {
                    SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "IMP" + "/"
                        +
                        Session["currentbranch"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                        + "/");
                }
                else if (SELECT_TYPE == "Areawise Job")
                {
                    SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "IMP" + "/"
                        +
                        Session["GroupName"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                        + "/");
                }

                else
                {
                    SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "IMP" + "/");
                }


                if (Directory.Exists(SQ_Path) == false)
                {
                    Directory.CreateDirectory(SQ_Path);
                }

                string sourceFile2 = System.IO.Path.Combine(errorFolder, logFileName);

                System.IO.File.Copy(sourceFile2, SQ_Path + logFileName, true);


                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                url = url.Substring(0, url.IndexOf("Amendment")) + SQ_Path.Substring(SQ_Path.IndexOf("FlatFile_DSC"), SQ_Path.Length - (SQ_Path.IndexOf("FlatFile_DSC"))) + logFileName;
                jh.JOB_ID = url.Replace(@"\", @"/");


                jh.JOB_TYPE = "IMP";
                jh.JOBNO = JOBNO;

                jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
                jh.DESCRIPTION = SQ_Path + logFileName;
                jh.ATTACHMENT_FILE = JOBNO + " ~~" + logFileName;
                jh.FLAG = "Amendment_Insert";
                jh.USER_ID = Session["currentuser"].ToString();
                jh.JOBDATE = txtJobDate.Text;
                jh.BRANCH_CODE = HttpContext.Current.Session["currentbranch"].ToString();
                jh.YEAR = "";
                jh.WORKING_PERIOD = Session["WorkingPeriod"].ToString();  
                jh.BRANCH_COMMON = HttpContext.Current.Session["currentbranch"].ToString();
                dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
                if (dss.Tables.Count > 0)
                {
                    if (dss.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        lblsent_date.Text = dss.Tables[0].Rows[0][1].ToString();
                        Alert_msg("Sent Successfully");
                    }
                    else
                    {
                        lblsent_date.Text = "Failed to Sent";
                        Alert_msg("Failed to Sent");
                    }

                }

            }

            if (IS_Imgbtn == "1")
            {
                Response.Write(sw.ToString());
                Response.Flush();
                // Response.End();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {
            Alert_msg("BE Number & Date - Mandatory");
        }
    }

    protected void imgbtnFlatFile_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            IS_Imgbtn = "1";
            //BE_Details();
            imgbtnFlatFile.Visible = false;
            //btnSubmission.Visible = false;
            btnSendQueue.Visible = false;

            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File("FaltfileImageBUtton");

                imgbtnFlatFile.Visible = true;
                btnSendQueue.Visible = true;
                //btnSubmission.Visible = true;
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File("FaltfileImageBUtton");

                imgbtnFlatFile.Visible = true;
                btnSendQueue.Visible = true;
                //btnSubmission.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'AMENDMENT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'AMENDMENT', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void ddl_AmendType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Amendment_Page();
    }

    private void Load_Amendment_Page()
    {
   
        if (Qry_amd_type != "")
        {
            ddl_AmendType.SelectedValue = Qry_amd_type;
        }
        
        if (ddl_AmendType.SelectedValue == "A")
        {
            ddl_AmendPage.Items.Clear();
            ddl_AmendPage.Items.Add("GENERAL");
            ddl_AmendPage.Items.Add("IGM");
            //ddl_AmendPage.Items.Add("NOMBL_IGM");//18-04-2022
            ddl_AmendPage.Items.Add("INVOICE");
            ddl_AmendPage.Items.Add("ITEM");
            ddl_AmendPage.Items.Add("BE_ITEM_SW_INFO_TYPE");
            ddl_AmendPage.Items.Add("BE_ITEM_SW_CONST");
            ddl_AmendPage.Items.Add("BE_ITEM_SW_PROD");
            ddl_AmendPage.Items.Add("BE_ITEM_SW_CTRL");
            ddl_AmendPage.Items.Add("STATEMENT");
            ddl_AmendPage.Items.Insert(0, "Select");

            ListBox_Invoice_SlNo.Enabled = false;
            //ddl_ItemSlno.Enabled = false;//08-09-2021
            ListBox_ItemSlno.Enabled = false;
            ListBox1.Enabled = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
        }
        else
        {
            ddl_AmendPage.Items.Clear();

            ddl_AmendPage.Items.Add("IGM");
            //ddl_AmendPage.Items.Add("NOMBL_IGM");//18-04-2022
            ddl_AmendPage.Items.Add("INVOICE");
            ddl_AmendPage.Items.Add("ITEM");
            ddl_AmendPage.Items.Add("CONTAINER");
            ddl_AmendPage.Items.Add("BE_ITEM_SW_INFO_TYPE");
            ddl_AmendPage.Items.Add("BE_ITEM_SW_CONST");
            ddl_AmendPage.Items.Add("BE_ITEM_SW_PROD");
            ddl_AmendPage.Items.Add("BE_ITEM_SW_CTRL");
            ddl_AmendPage.Items.Add("SUPPORTING_DOCS");
            ddl_AmendPage.Items.Add("STATEMENT");

            ddl_AmendPage.Items.Insert(0, "Select");

            
            ddlJobNo.Items.Clear();
        }

        if (Qry_amd_page != "")
        {
            Bind_ddl_AmendPage();
            //ddlJobNo.SelectedValue = Qry_amd_Jobno;
        }

    }


    private void Bind_ddl_AmendPage()
    {
        DataSet ds_supp = new DataSet();
        Amnd.JOBNO = "";
        Amnd.INVOICE_SLNO = "";
        Amnd.ITEM_SLNO = "";
        Amnd.SELECT_ITEM = "";
        Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();

        IGM_Y_N.Visible = false;

        if (Qry_amd_page != "")
        {
            ddl_AmendPage.SelectedValue = Qry_amd_page;
        }

        if (ddl_AmendPage.SelectedItem.Text == "GENERAL")
        {
            Amnd.Ename = "select_GENERAL_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = false;
            //ddl_ItemSlno.Enabled = false;//08-09-2021

            ListBox_ItemSlno.Visible = false;
            Item_TextBox.Visible = true;
            Item_TextBox.Enabled = false;
            ListBox1.Visible = false;
            TextBox1.Visible = true;
            TextBox1.Enabled = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";

        }
        else if (ddl_AmendPage.SelectedItem.Text == "CONTAINER")
        {
            Amnd.Ename = "select_CONTAINER_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = false;//08-09-2021
            ListBox_ItemSlno.Enabled = false;
            ListBox_ItemSlno.Visible = false;
            ListBox1.Enabled = false;
            ListBox1.Items.Clear();
            Item_TextBox.Visible = true;
            Item_TextBox.Enabled = false;
            TextBox1.Enabled = false;
            //lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_Invoice_Slno.Text = "Container No";
            //lbl_select_item.Text = "Container No";

        }
        else if (ddl_AmendPage.SelectedItem.Text == "IGM" || ddl_AmendPage.SelectedItem.Text == "NOMBL_IGM")
        {
            Amnd.Ename = "select_IGM_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = false;
            ListBox_ItemSlno.Visible = false;
            ListBox1.Enabled = true;
            Item_TextBox.Visible = true;
            Item_TextBox.Enabled = false;
            lbl_select_item.Text = "Multiple IGM";
            IGM_Y_N.Visible = true;
        }
        else if (ddl_AmendPage.SelectedItem.Text == "INVOICE")
        {
            Amnd.Ename = "select_Invoice_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = false;//08-09-2021
            ListBox_ItemSlno.Enabled = false;
            ListBox1.Enabled = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";

        }
        else if (ddl_AmendPage.SelectedItem.Text == "ITEM")
        {
            Amnd.Ename = "select_Item_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = true;
            ListBox_ItemSlno.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            Item_TextBox.Visible = false;
            ListBox1.Visible = false;
            TextBox1.Visible = true;
            TextBox1.Enabled = false;

            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "Multiple ITEM";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_INFO_TYPE")
        {
            Amnd.Ename = "select_SW_INFO_TYPE_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = true;//08-09-2021
            ListBox_ItemSlno.Enabled = true;
            ListBox1.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            ListBox1.Visible = true;
            Item_TextBox.Visible = false;
            TextBox1.Visible = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "Info Qualifier";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CONST")
        {
            Amnd.Ename = "select_SW_CONSTITUENT_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = true;//08-09-2021
            ListBox_ItemSlno.Enabled = true;
            ListBox1.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            ListBox1.Visible = true;
            Item_TextBox.Visible = false;
            TextBox1.Visible = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "Cons. Sr.No.";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_PROD")
        {
            Amnd.Ename = "select_SW_PRODUCTION_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = true;//08-09-2021
            ListBox_ItemSlno.Enabled = true;
            ListBox1.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            ListBox1.Visible = true;
            Item_TextBox.Visible = false;
            TextBox1.Visible = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "Prod. Batch Identifier";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CTRL")
        {
            Amnd.Ename = "select_SW_CONTROL_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = true;//08-09-2021
            ListBox_ItemSlno.Enabled = true;
            ListBox1.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            ListBox1.Visible = true;
            Item_TextBox.Visible = false;
            TextBox1.Visible = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "Cont.Type Code";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS")
        {
            Amnd.Ename = "select_SupDocs_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = true;//08-09-2021
            ListBox_ItemSlno.Enabled = true;
            ListBox1.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            ListBox1.Visible = true;
            Item_TextBox.Visible = false;
            TextBox1.Visible = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "IRN Number";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "STATEMENT")
        {
            Amnd.Ename = "select_SW_STATEMENT_JOBNO_List";

            ListBox_Invoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = true;//08-09-2021
            ListBox_ItemSlno.Enabled = true;
            ListBox1.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            ListBox1.Visible = true;
            Item_TextBox.Visible = false;
            TextBox1.Visible = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "STMT Code";
        }

        ds_supp = Amnd.RetrieveAll_Amend_Details();

        if (ds_supp.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds_supp.Tables[0];
            ddlJobNo.DataTextField = "JOBNO";
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataBind();
            ddlJobNo.Items.Insert(0, "Select");

            if (Qry_amd_Jobno != "")
            {
                ddlJobNo.SelectedValue = Qry_amd_Jobno;
                Bind_ddlJobno();
            }

        }
        else
        {
            ddlJobNo.Items.Clear();
            ddlJobNo.Items.Insert(0, "Select");
        }
    }

    protected void ddl_AmendPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_ddl_AmendPage();
    }


    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_ddlJobno();
    }

    private void Bind_ddlJobno()
    {
        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            AUTO_JOBNO();

            DataSet ds_supp = new DataSet();
            Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
            Amnd.INVOICE_SLNO = "";
            Amnd.ITEM_SLNO = "";
            Amnd.SELECT_ITEM = ddl_AmendPage.SelectedItem.Text == "NOMBL_IGM" ? "IGM" : ddl_AmendPage.SelectedItem.Text;
            Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
            Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
            Amnd.Ename = "select_JOB_DETAILS";

            ds_supp = Amnd.RetrieveAll_Amend_Details();


            if (ds_supp.Tables[0].Rows.Count > 0)
            {
                txtJobDate.Text = ds_supp.Tables[0].Rows[0]["JOBDATE"].ToString();
                txtCustomsHouse.Text = ds_supp.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
            }
            else
            {
                txtJobDate.Text = "";
                txtCustomsHouse.Text = "";
            }

            if (ds_supp.Tables[1].Rows.Count > 0)
            {
                txtBENo.Text = ds_supp.Tables[1].Rows[0]["BE_NO"].ToString();
                txtBEDate.Text = ds_supp.Tables[1].Rows[0]["BE_DATE"].ToString();
            }
            else
            {
                txtBENo.Text = "";
                txtBEDate.Text = "";
            }

            if (ddl_AmendPage.SelectedItem.Text == "CONTAINER" || ddl_AmendPage.SelectedItem.Text == "IGM" || ddl_AmendPage.SelectedItem.Text == "NOMBL_IGM" || ddl_AmendPage.SelectedItem.Text == "INVOICE" || ddl_AmendPage.SelectedItem.Text == "ITEM" || ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS" || ddl_AmendPage.SelectedItem.Text == "STATEMENT" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_INFO_TYPE" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CONST" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_PROD" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CTRL")
            {
                if (ddl_AmendPage.SelectedItem.Text == "IGM" || ddl_AmendPage.SelectedItem.Text == "NOMBL_IGM")//30-03-2021 newly add if condition
                {
                    if (ds_supp.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Visible = false;
                        ListBox1.Visible = true;
                        ListBox1.DataSource = ds_supp.Tables[2];
                        ListBox1.DataTextField = "IMAGE_REF_NUMBER";
                        ListBox1.DataValueField = "IMAGE_REF_NUMBER";
                        ListBox1.DataBind();

                        Item_TextBox.Visible = true;
                        ListBox_ItemSlno.Visible = false;
                        Item_TextBox.Enabled = false;
                    }
                }

                if (ddl_AmendPage.SelectedItem.Text != "IGM" && ddl_AmendPage.SelectedItem.Text != "NOMBL_IGM")//30-03-2021 newly add if condition
                {
                    if (ds_supp.Tables[2].Rows.Count > 0)
                    {








                        ListBox_Invoice_SlNo.DataSource = ds_supp.Tables[2];
                        ListBox_Invoice_SlNo.DataTextField = "INVOICE_SLNO";
                        ListBox_Invoice_SlNo.DataValueField = "INVOICE_SLNO";
                        ListBox_Invoice_SlNo.DataBind();
                        //ListBox_Invoice_SlNo.Items.Insert(0, "Select");
                        ListBox_Invoice_SlNo.Enabled = true;

                        if (Qry_amd_Invslno != "")
                        {
                            ListBox_Invoice_SlNo.SelectedValue = Qry_amd_Invslno;
                        }
                    }
                }

                if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS" || ddl_AmendPage.SelectedItem.Text == "ITEM" || ddl_AmendPage.SelectedItem.Text == "STATEMENT" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_INFO_TYPE" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CONST" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_PROD" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CTRL")
                //if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS"  || ddl_AmendPage.SelectedItem.Text == "STATEMENT")
                {
                    if (ds_supp.Tables[3].Rows.Count > 0)
                    {
                        /*//08-09-2021
                        ddl_ItemSlno.DataSource = ds_supp.Tables[3];
                        ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                        ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                        ddl_ItemSlno.DataBind();
                        ddl_ItemSlno.Items.Insert(0, "Select");
                         * */

                        //TextBox1.Visible = false;//18-09-2021

                        if (ddl_AmendPage.SelectedItem.Text == "ITEM")
                        {
                            TextBox1.Visible = true;
                        }
                        else
                        {
                            TextBox1.Visible = false;
                        }

                        Item_TextBox.Visible = false;
                        ListBox_ItemSlno.Visible = true;
                        ListBox_ItemSlno.DataSource = ds_supp.Tables[3];
                        ListBox_ItemSlno.DataTextField = "ITEM_SLNO";
                        ListBox_ItemSlno.DataValueField = "ITEM_SLNO";
                        ListBox_ItemSlno.DataBind();
                    }
                }
                else
                {
                    /*
                    if (ddl_AmendPage.SelectedItem.Text == "IGM")//30-03-2021
                    {
                        //ddl_ItemSlno.Enabled = false;//08-09-2021
                        ListBox_ItemSlno.Enabled = false;
                        ListBox1.Enabled = true;
                        lbl_select_item.Text = "Multiple IGM";
                    }
                    if (ddl_AmendPage.SelectedItem.Text == "ITEM")//04-09-2021
                    {
                        //ddl_ItemSlno.Enabled = false;//08-09-2021
                        ListBox_ItemSlno.Enabled = false;
                        ListBox1.Enabled = true;
                        lbl_select_item.Text = "Multiple ITEM";
                    }
                    else
                    {
                        //ddl_ItemSlno.Enabled = false;//08-09-2021
                        ListBox_ItemSlno.Enabled = false;
                        ListBox1.Enabled = false;
                    }
                     *  */
                }
            }

            // ListBox1.Items.Clear();//30-03-2021
        }
    }
 
    protected void ListBox_Invoice_SlNo_SelectedIndexChanged(object sender, EventArgs e)
    {
       
            DataSet ds_supp = new DataSet();
            Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
            string Invoice_Selected_ListBox = "";
            foreach (ListItem invoice in ListBox_Invoice_SlNo.Items)
            {
                if (invoice.Selected)
                {
                    Invoice_Selected_ListBox += invoice.Value + "~";
                }
            }

            if (Invoice_Selected_ListBox != "")
            {

                Amnd.INVOICE_SLNO = Invoice_Selected_ListBox;



                Amnd.ITEM_SLNO = "";
                //Amnd.SELECT_ITEM = "";--29-01-2021
                Amnd.SELECT_ITEM = ddl_AmendPage.SelectedItem.Text;
                Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                Amnd.Ename = "select_INVOICE_Item_Slno";

                ds_supp = Amnd.RetrieveAll_Amend_Details();

                if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS" || ddl_AmendPage.SelectedItem.Text == "STATEMENT" || ddl_AmendPage.SelectedItem.Text == "ITEM" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_INFO_TYPE" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CONST" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_PROD" || ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CTRL")
                {
                    if (ds_supp.Tables[0].Rows.Count > 0)
                    {
                        /* 08-09-2021
                        ddl_ItemSlno.DataSource = ds_supp.Tables[0];
                        ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                        ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                        ddl_ItemSlno.DataBind();
                        ddl_ItemSlno.Items.Insert(0, "Select");
                         * */

                        //TextBox1.Visible = false;//18-09-2021
                        TextBox1.Visible = true;
                        Item_TextBox.Visible = false;
                        ListBox_ItemSlno.Visible = true;
                        ListBox_ItemSlno.DataSource = ds_supp.Tables[0];
                        ListBox_ItemSlno.DataTextField = "ITEM_SLNO";
                        ListBox_ItemSlno.DataValueField = "ITEM_SLNO";
                        ListBox_ItemSlno.DataBind();
                    }
                }
                //else if(ddl_AmendPage.SelectedItem.Text == "ITEM")
                //{
                //    if (ds_supp.Tables[0].Rows.Count > 0)
                //    {
                //        TextBox1.Visible = false;
                //        Item_TextBox.Visible = true;
                //        ListBox1.Visible = true;
                //        ListBox1.DataSource = ds_supp.Tables[0];
                //        ListBox1.DataTextField = "ITEM_SLNO";
                //        ListBox1.DataValueField = "ITEM_SLNO";
                //        ListBox1.DataBind();
                //    }
                //}
            }
        
    }

    protected void ListBox_ItemSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ListBox_ItemSlno.SelectedItem.Text != "Select")
            //{
            if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS")
            {

                string Item_Selected_ListBox = "";
                foreach (ListItem item in ListBox_ItemSlno.Items)
                {
                    if (item.Selected)
                    {
                        Item_Selected_ListBox += item.Value + "~";
                    }
                }


                string[] item_inv_splt = Item_Selected_ListBox.Split('~');
               string invoice_list="",item_list="";
                for (int i = 0; i < item_inv_splt.Length; i++)
                {
                    string[] item_inv_spltv2 = item_inv_splt[i].Split('-');
                    if (item_inv_spltv2[0] != "")
                    {
                        invoice_list += item_inv_spltv2[0].ToString() + "~";
                        item_list += item_inv_spltv2[1].ToString() + "~";
                    }

                }
                if (Item_Selected_ListBox != "")
                {
                    DataSet ds_supp = new DataSet();
                    Amnd.JOBNO = ddlJobNo.SelectedItem.Text;



                    Amnd.INVOICE_SLNO = invoice_list;
                    //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text;//08-09-2021
                    Amnd.ITEM_SLNO = item_list;
                    Amnd.SELECT_ITEM = "";
                    Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                    Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                    Amnd.Ename = "select_SupDocs_IRN_NO";

                    ds_supp = Amnd.RetrieveAll_Amend_Details();

                    if (ds_supp.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Visible = false;
                        Item_TextBox.Visible = false;
                        ListBox1.Visible = true;
                        ListBox1.DataSource = ds_supp.Tables[0];
                        ListBox1.DataTextField = "IMAGE_REF_NUMBER";
                        ListBox1.DataValueField = "IMAGE_REF_NUMBER";
                        ListBox1.DataBind();
                    }
                }
                else
                {
                    TextBox1.Visible = true;
                    ListBox1.Visible = false;
                    Alert_msg("Select Item SlNo");
                }
            }
            else if (ddl_AmendPage.SelectedItem.Text == "STATEMENT")
            {

                string Item_Selected_ListBox = "";
                foreach (ListItem item in ListBox_ItemSlno.Items)
                {
                    if (item.Selected)
                    {
                        Item_Selected_ListBox += item.Value + "~";
                    }
                }


                string[] item_inv_splt = Item_Selected_ListBox.Split('~');
                string invoice_list = "", item_list = "";
                for (int i = 0; i < item_inv_splt.Length; i++)
                {
                    string[] item_inv_spltv2 = item_inv_splt[i].Split('-');
                    if (item_inv_spltv2[0] != "")
                    {
                        invoice_list += item_inv_spltv2[0].ToString() + "~";
                        item_list += item_inv_spltv2[1].ToString() + "~";
                    }

                }


                DataSet ds_supp = new DataSet();
                Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                Amnd.INVOICE_SLNO = invoice_list;
                //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text;
                Amnd.ITEM_SLNO = item_list;
                Amnd.SELECT_ITEM = "";
                Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                Amnd.Ename = "select_STMT_Code";

                ds_supp = Amnd.RetrieveAll_Amend_Details();

                if (ds_supp.Tables[0].Rows.Count > 0)
                {
                    TextBox1.Visible = false;
                    Item_TextBox.Visible = false;
                    ListBox1.Visible = true;
                    ListBox1.DataSource = ds_supp.Tables[0];
                    ListBox1.DataTextField = "STMT_CODE";
                    ListBox1.DataValueField = "STMT_CODE";
                    ListBox1.DataBind();
                }
                else
                {
                    TextBox1.Visible = true;
                    Item_TextBox.Visible = false;
                    ListBox1.Visible = false;
                }
            }
            else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_INFO_TYPE")
            {

                string Item_Selected_ListBox = "";
                foreach (ListItem item in ListBox_ItemSlno.Items)
                {
                    if (item.Selected)
                    {
                        Item_Selected_ListBox += item.Value + "~";
                    }
                }
                string[] item_inv_splt = Item_Selected_ListBox.Split('~');
                string invoice_list = "", item_list = "";
                for (int i = 0; i < item_inv_splt.Length; i++)
                {
                    string[] item_inv_spltv2 = item_inv_splt[i].Split('-');
                    if (item_inv_spltv2[0] != "")
                    {
                        invoice_list += item_inv_spltv2[0].ToString() + "~";
                        item_list += item_inv_spltv2[1].ToString() + "~";
                    }

                }
                if (Item_Selected_ListBox != "")
                {
                    DataSet ds_supp = new DataSet();
                    Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                    Amnd.INVOICE_SLNO = invoice_list;
                    //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text;//08-09-2021
                    Amnd.ITEM_SLNO = item_list;
                    Amnd.SELECT_ITEM = "";
                    Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                    Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                    Amnd.Ename = "select_SW_INFO_TYPE_Qualifier";

                    ds_supp = Amnd.RetrieveAll_Amend_Details();

                    if (ds_supp.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Visible = false;
                        Item_TextBox.Visible = false;
                        ListBox1.Visible = true;
                        ListBox1.DataSource = ds_supp.Tables[0];
                        ListBox1.DataTextField = "INFO_QUALIFIER";
                        ListBox1.DataValueField = "INFO_QUALIFIER";
                        ListBox1.DataBind();
                    }
                }
                else
                {
                    TextBox1.Visible = true;
                    ListBox1.Visible = false;
                    Alert_msg("Select Item SlNo");
                }
            }
            else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CONST")
            {

                string Item_Selected_ListBox = "";
                foreach (ListItem item in ListBox_ItemSlno.Items)
                {
                    if (item.Selected)
                    {
                        Item_Selected_ListBox += item.Value + "~";
                    }
                }


                string[] item_inv_splt = Item_Selected_ListBox.Split('~');
                string invoice_list = "", item_list = "";
                for (int i = 0; i < item_inv_splt.Length; i++)
                {
                    string[] item_inv_spltv2 = item_inv_splt[i].Split('-');
                    if (item_inv_spltv2[0] != "")
                    {
                        invoice_list += item_inv_spltv2[0].ToString() + "~";
                        item_list += item_inv_spltv2[1].ToString() + "~";
                    }

                }

                if (Item_Selected_ListBox != "")
                {
                    DataSet ds_supp = new DataSet();
                    Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                    Amnd.INVOICE_SLNO = invoice_list;
                    //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text;//08-09-2021
                    Amnd.ITEM_SLNO = item_list;
                    Amnd.SELECT_ITEM = "";
                    Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                    Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                    Amnd.Ename = "select_SW_CONSTITUENT_SLNO_List";

                    ds_supp = Amnd.RetrieveAll_Amend_Details();

                    if (ds_supp.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Visible = false;
                        Item_TextBox.Visible = false;
                        ListBox1.Visible = true;
                        ListBox1.DataSource = ds_supp.Tables[0];
                        ListBox1.DataTextField = "CONSTITUENT_SRNO";
                        ListBox1.DataValueField = "CONSTITUENT_SRNO";
                        ListBox1.DataBind();
                    }
                }
                else
                {
                    TextBox1.Visible = true;
                    ListBox1.Visible = false;
                    Alert_msg("Select Item SlNo");
                }
            }
            else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_PROD")
            {

                string Item_Selected_ListBox = "";
                foreach (ListItem item in ListBox_ItemSlno.Items)
                {
                    if (item.Selected)
                    {
                        Item_Selected_ListBox += item.Value + "~";
                    }
                }

                string[] item_inv_splt = Item_Selected_ListBox.Split('~');
                string invoice_list = "", item_list = "";
                for (int i = 0; i < item_inv_splt.Length; i++)
                {
                    string[] item_inv_spltv2 = item_inv_splt[i].Split('-');
                    if (item_inv_spltv2[0] != "")
                    {
                        invoice_list += item_inv_spltv2[0].ToString() + "~";
                        item_list += item_inv_spltv2[1].ToString() + "~";
                    }

                }


                if (Item_Selected_ListBox != "")
                {
                    DataSet ds_supp = new DataSet();
                    Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                    Amnd.INVOICE_SLNO = invoice_list;
                    //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text;//08-09-2021
                    Amnd.ITEM_SLNO = item_list;
                    Amnd.SELECT_ITEM = "";
                    Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                    Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                    Amnd.Ename = "select_SW_PRODUCTION_BATCH_List";

                    ds_supp = Amnd.RetrieveAll_Amend_Details();

                    if (ds_supp.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Visible = false;
                        Item_TextBox.Visible = false;
                        ListBox1.Visible = true;
                        ListBox1.DataSource = ds_supp.Tables[0];
                        ListBox1.DataTextField = "PRODUCTION_BATCH_IDENTIFIER";
                        ListBox1.DataValueField = "PRODUCTION_BATCH_IDENTIFIER";
                        ListBox1.DataBind();
                    }
                }
                else
                {
                    TextBox1.Visible = true;
                    ListBox1.Visible = false;
                    Alert_msg("Select Item SlNo");
                }
            }
            else if (ddl_AmendPage.SelectedItem.Text == "BE_ITEM_SW_CTRL")
            {

                string Item_Selected_ListBox = "";
                foreach (ListItem item in ListBox_ItemSlno.Items)
                {
                    if (item.Selected)
                    {
                        Item_Selected_ListBox += item.Value + "~";
                    }
                }
                string[] item_inv_splt = Item_Selected_ListBox.Split('~');
                string invoice_list = "", item_list = "";
                for (int i = 0; i < item_inv_splt.Length; i++)
                {
                    string[] item_inv_spltv2 = item_inv_splt[i].Split('-');
                    if (item_inv_spltv2[0] != "")
                    {
                        invoice_list += item_inv_spltv2[0].ToString() + "~";
                        item_list += item_inv_spltv2[1].ToString() + "~";
                    }

                }

                if (Item_Selected_ListBox != "")
                {
                    DataSet ds_supp = new DataSet();
                    Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                    Amnd.INVOICE_SLNO = invoice_list;
                    //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text;//08-09-2021
                    Amnd.ITEM_SLNO = item_list;
                    Amnd.SELECT_ITEM = "";
                    Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                    Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                    Amnd.Ename = "select_SW_CONTROL_TYPE_List";

                    ds_supp = Amnd.RetrieveAll_Amend_Details();

                    if (ds_supp.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Visible = false;
                        Item_TextBox.Visible = false;
                        ListBox1.Visible = true;
                        ListBox1.DataSource = ds_supp.Tables[0];
                        ListBox1.DataTextField = "CONTROL_TYPE_CODE";
                        ListBox1.DataValueField = "CONTROL_TYPE_CODE";
                        ListBox1.DataBind();
                    }
                }
                else
                {
                    TextBox1.Visible = true;
                    ListBox1.Visible = false;
                    Alert_msg("Select Item SlNo");
                }
            }
            else
            {
                ListBox1.Enabled = false;
            }
                //}
                //else
                //{
                //    TextBox1.Visible = true;
                //    Item_TextBox.Visible = true;
                //    ListBox1.Visible = false;
                //    ListBox_ItemSlno.Visible = false;
                //}
            
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    /*
    protected void ddl_ItemSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_ItemSlno.SelectedItem.Text != "Select")
        {
            if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS")
            {
                DataSet ds_supp = new DataSet();
                Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                Amnd.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
                Amnd.SELECT_ITEM = "";
                Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                Amnd.Ename = "select_SupDocs_IRN_NO";

                ds_supp = Amnd.RetrieveAll_Amend_Details();

                if (ds_supp.Tables[0].Rows.Count > 0)
                {
                    TextBox1.Visible = false;
                    ListBox1.Visible = true;
                    ListBox1.DataSource = ds_supp.Tables[0];
                    ListBox1.DataTextField = "IMAGE_REF_NUMBER";
                    ListBox1.DataValueField = "IMAGE_REF_NUMBER";
                    ListBox1.DataBind();
                }
            }
            else if (ddl_AmendPage.SelectedItem.Text == "STATEMENT")
            {
                DataSet ds_supp = new DataSet();
                Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                Amnd.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
                Amnd.SELECT_ITEM = "";
                Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                Amnd.Ename = "select_STMT_Code";

                ds_supp = Amnd.RetrieveAll_Amend_Details();

                if (ds_supp.Tables[0].Rows.Count > 0)
                {
                    TextBox1.Visible = false;
                    ListBox1.Visible = true;
                    ListBox1.DataSource = ds_supp.Tables[0];
                    ListBox1.DataTextField = "STMT_CODE";
                    ListBox1.DataValueField = "STMT_CODE";
                    ListBox1.DataBind();
                }
                else
                {
                    TextBox1.Visible = true;
                    ListBox1.Visible = false;
                }
            }
            else
            {
                ListBox1.Enabled = false;
            }
        }
        else
        {
            TextBox1.Visible = true;
            ListBox1.Visible = false;
        }
        
    }

    */
    public string Get_Admin_Master_Codes(string Search_Name)
    {
        IMPORTER_CLASS = "N";
        Export_FlatFile_Generation Imp_FlatFile = new Export_FlatFile_Generation();
        Imp_FlatFile.Ename = "IMPORT_SELECT";

        dss_adm = Imp_FlatFile.Search_Admin_Master();
        DataView view1 = dss_adm.Tables[0].DefaultView;

        if (Search_Name == "COUNTRY_OF_ORIGIN")
        {
            view1 = dss_adm.Tables[1].DefaultView;
            view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_ORIGIN) + "'";
            DataSet dt_1 = new DataSet();
            dt_1.Tables.Add(view1.ToTable());
            if (dt_1.Tables[0].Rows.Count > 0)
            {
                COUNTRY_ORIGIN = dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
                Search_Name = COUNTRY_ORIGIN;
            }
            else
            {
                Search_Name = COUNTRY_ORIGIN;
            }
        }
        else if (Search_Name == "COUNTRY_SHIPMENT")
        {
            view1 = dss_adm.Tables[1].DefaultView;
            view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_SHIPMENT) + "'";

            DataSet ds1 = new DataSet();
            ds1.Tables.Add(view1.ToTable());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                COUNTRY_SHIPMENT = ds1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
                Search_Name = COUNTRY_SHIPMENT;
            }
            else
            {
                Search_Name = COUNTRY_SHIPMENT;
            }
        }

        else if (Search_Name == "PORT_ORIGIN")
        {
            if (PORT_ORIGIN.Contains("-"))
            {
                PORT_ORIGIN = split.Split_main("-", PORT_ORIGIN);
                Search_Name = PORT_ORIGIN;
            }
            else
            {
                Search_Name = PORT_ORIGIN;
            }
        }
        else if (Search_Name == "PORT_SHIPMENT")
        {
            if (PORT_SHIPMENT.Contains("-"))
            {
                PORT_SHIPMENT = split.Split_main("-", PORT_SHIPMENT);
                Search_Name = PORT_SHIPMENT;
            }
            else
            {
                Search_Name = PORT_SHIPMENT;
            }
        }

        return Search_Name;
    }

    private int Get_Request_No_MAX()
    {
        int result = 1;
        DataSet ds_MAX = new DataSet();
        Amnd.JOBNO = "";
        Amnd.INVOICE_SLNO = "";
        Amnd.ITEM_SLNO = "";
        Amnd.SELECT_ITEM = "";
        Amnd.AMEND_TYPE = "";
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
        Amnd.Ename = "Get_REQUEST_NO_MAX";

        ds_MAX = Amnd.RetrieveAll_Amend_Details();

        if (ds_MAX.Tables[0].Rows.Count > 0)
        {
            result = Convert.ToInt32(ds_MAX.Tables[0].Rows[0]["REQUEST_NO"].ToString());
        }


        return result;
    }

    protected void btnSendQueue_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    
        Flat_File("SendQueue");



        //}
        //catch (Exception ex)
        //{
        //    Connection.Error_Msg(ex.Message);
        //}

    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
       
        ddlJobNo.SelectedValue = "Select";
        if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS" || ddl_AmendPage.SelectedItem.Text == "STATEMENT" || ddl_AmendPage.SelectedItem.Text == "ITEM")
        {
            ListBox_Invoice_SlNo.SelectedValue = "Select";
        }
        ddl_AmendPage.SelectedValue = "Select";
        ListBox_ItemSlno.Items.Clear();
        ListBox1.Items.Clear();
        txtQueryNo.Text = "";
        txtQueryDate.Text = "";
        //txtAmendmentReason.Text = "";

    }

    public void Insert_Jobno_MAX_ID()
    {
        DataSet ds_jobno = new DataSet();
        Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
        Amnd.INVOICE_SLNO = Connection.Current_User();
        Amnd.ITEM_SLNO = "";
        Amnd.SELECT_ITEM = "";
        Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
        Amnd.Ename = "Insert_MAX_ID";

        ds_jobno = Amnd.RetrieveAll_Amend_Details();

        if (ds_jobno.Tables[0].Rows.Count > 0)
        {
           
        }
    }
    
}