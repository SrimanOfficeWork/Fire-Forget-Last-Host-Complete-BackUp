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
using BussinessObject;
using System.Data.OleDb;
using Aspose.Pdf;
using Aspose.Pdf.Devices;

public partial class Transaction_Default2 : ThemeClass
{
    adminmaster erm = new adminmaster();
    Date_Time split = new Date_Time();
    DataSet dss = new DataSet();
    DataRow[] dr;
    string val = "", Is_val = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, Inv_SLNo, errorFolder_json;
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
    public string EMail_ID = "", targetPath = "";

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, IS_Imgbtn, IMPORTER_CLASS, EXCHANGE_PER_UNIT;

    IMP_Validation IV = new IMP_Validation();
    UserBO ObjUBO = new UserBO();

    CheckList CHKLIST = new CheckList();
    FlatFile_Generation FlatFile = new FlatFile_Generation();
    Flatfile_Json FJ = new Flatfile_Json();
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "";
    public string folderName = "/Submission";
    ErrorLogs er = new ErrorLogs();
    StreamWriter sw;
    public string createfilename = "";
    public char ch = Convert.ToChar(29);
    public string CHA_NO = "", ICEGATE_ID = "", SUP_DOC_ICEGATE_ID = "";
    public string LOADING_EXBOND_WARWHOUSE = "", MISC_LOAD_RATE = "", Warehouse_Customs_Site_ID = "";
    public string PREVIOUS_UNITPRICE = "", PREVIOUS_CURRENY = "", PREVIOUS_CUSTOMSITE = "";
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
    public string PROVISIONAL;
    public string PROVISIONAL_DESC;
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

    public string AIDC_NOTN, AIDC_NOTN_SLNO;
    public string EXC_AIDC_NOTN, EXC_AIDC_NOTN_SLNO;



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
    public string CONTROL_MSR;
    public string CONTROL_UQC;
    public string CONTROL_SLNO;


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

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();

            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();

            CHA_NO = Connection.Get_IMP_CHA_NO();
            COMPANY_ID = Session["COMPANY_ID"].ToString();
            hdn_CompanyID.Value = COMPANY_ID;

            Dsc_HandleUnsignedJsonRequest();

            Dsc_InitializeSigning();

            // txt_icegate_Id.Text = Connection.Get_IMP_ICEGATE_ID_New();

            if (Connection.Imp_Multiple_CHA_IcegateID_enable(COMPANY_ID) == "Y")
            {
                if (!string.IsNullOrEmpty(Session["Multiple_ICE_ID"] as string))
                {
                    txt_icegate_Id.Text = Session["Multiple_ICE_ID"].ToString();
                }
            }

            ddlJobNo.Focus();

            ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

            errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/");
            
            hdn_ICEGATE_ID_List.Value = Connection.Get_User_ICEGATE_ID_DropdownList("Load_IMP_ICEGATE_ID_dropdown");


            SELECT_BRANCH = Connection.Get_Company_Type();

            string jobtyp = HttpContext.Current.Session["SELECT_TYPE"].ToString();

            if (jobtyp == "Branchwise Job")
            {
                targetPath = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + "IMP_Job_history/");
            }
            else if (jobtyp == "Areawise Job")
            {
                targetPath = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + Session["GroupName"].ToString() + "/" + "IMP_Job_history/");
            }
            else
            {
                targetPath = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + "IMP_Job_history/");
            }


            hd_branch.Value = SELECT_BRANCH;

            if (!IsPostBack)
            {
               

                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 8;
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
                        /*hide for Dashboard changes - sidebar & innerbox_Main_Top_User controls removed on 24-08-2026*/
                        //System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                        //currdiv.Style.Add("display", "none");

                        //System.Web.UI.HtmlControls.HtmlGenericControl currdiv1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("innerbox_Main_Top_User");
                        //currdiv1.Style.Add("display", "none");

                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("maincontent");
                        currdiv2.Style.Add("margin", "-16px 2px 0 0");
                        currdiv2.Style.Add("padding", "2px 0 0");

                        ddlJobNo.Items.Clear();
                        ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                        ddlJobNo.SelectedIndex = 0;

                        hdn_Jobno.Value = Request["jobno"].ToString().TrimEnd();
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

                if (COMPANY_ID == "293" || COMPANY_ID == "1" || COMPANY_ID == "10")
                {
                    DutyandAssesableValueChecking();
                }
               
                txt_icegate_Id.Text = Connection.Get_IMP_ICEGATE_ID_New();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        if (!IsPostBack)
        {
            if (Connection.Company_License().ToLower() == "eri00001")
            {
                btn_Auto_Spl_Char.Visible = false;
            }

            //Load_Duplicate_Invoice_Chk_Import();

            string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "")
          ? Session["Theme"].ToString().ToLower()
          : "orange";

             ScriptManager.RegisterStartupScript(this, this.GetType(),
             "setTheme",
             "var PAGE_THEME = '" + theme + "';",
              true);

             Check_Duplicate_Invoice_OnLoad();

             string jobNo = ddlJobNo.SelectedValue.ToString();
             if (!string.IsNullOrEmpty(jobNo))
             {
                 LoadExistingDummyJobNo(jobNo);
             }



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
                    btnsend_Queue.Enabled = false;
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
                                    btnsend_Queue.Enabled = false;
                                    MP_U.Show();
                                    lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                    btnsend_Queue.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
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
            imgbtnFlatFile.Enabled = false;
            btnsend_Queue.Enabled = false;

            btnSearch.ToolTip = "You don't have permission to access";
            imgbtnFlatFile.ToolTip = "You don't have permission to access";
        }
        else
        {
            btnSearch.Enabled = true;
            imgbtnFlatFile.Enabled = true;
            btnsend_Queue.Enabled = true;

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

                //if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "2145")
                //{
                    if (ds.Tables[8].Rows.Count > 0)
                    {
                        if (txtBE_Type.Text == "SEZ FTA-Z" || txtBE_Type.Text == "SEZ DTA-T" || txtBE_Type.Text == "SEZ DTA-M"
                                             || txtBE_Type.Text == "Jobbing" || txtBE_Type.Text == "Repair & Return" || txtBE_Type.Text == "Exhibition" || txtBE_Type.Text == "Destruction" || txtBE_Type.Text == "Movement of Goods")
                        {
                            if (ds.Tables[8].Rows[0]["SEZ_ICEGATE_ID"].ToString() != "")
                            {
                                txt_icegate_Id.Text = ds.Tables[8].Rows[0]["SEZ_ICEGATE_ID"].ToString();
                            }
                        }
                    }
                //}
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
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Ex-Bond")
            {
                BE_TYPE = "X";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString();
            }
            else if (BE_TYPE == "SEZ FTA-Z")
            {
                BE_TYPE = "Z";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "SEZ DTA-T")
            {
                BE_TYPE = "T";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString();
            }
            else if (BE_TYPE == "SEZ DTA-M")
            {
                BE_TYPE = "M";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Jobbing")
            {
                BE_TYPE = "J";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Repair & Return")
            {
                BE_TYPE = "R";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Exhibition")
            {
                BE_TYPE = "E";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Destruction")
            {
                BE_TYPE = "D";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Movement of Goods")
            {
                BE_TYPE = "V";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }
            else if (BE_TYPE == "Stock Item")
            {
                BE_TYPE = "S";
                EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
            }

			if (COMPANY_ID == "10" || COMPANY_ID == "1307" || COMPANY_ID == "1713" || COMPANY_ID == "2099" || COMPANY_ID == "2145" || COMPANY_ID == "2394" || COMPANY_ID == "2318" || COMPANY_ID == "2478" || COMPANY_ID == "3122" || COMPANY_ID == "3194" || COMPANY_ID == "3384" || COMPANY_ID == "3387" || COMPANY_ID == "4047" || COMPANY_ID == "4082")				
            {
                if (ds.Tables[0].Rows[0]["CHA_NO"].ToString() != "")
                {
                    CHA_NO = ds.Tables[0].Rows[0]["CHA_NO"].ToString();
                    txt_icegate_Id.Text = ds.Tables[0].Rows[0]["ICE_ID"].ToString();
                }
            }
            else
            {
                if (BE_TYPE == "Z" || BE_TYPE == "T" || BE_TYPE == "M" || BE_TYPE == "J" || BE_TYPE == "R" || BE_TYPE == "E" || BE_TYPE == "D" || BE_TYPE == "V" || BE_TYPE == "S")
                {
                    if (ds.Tables[19].Rows.Count > 0)
                    {
                        if (ds.Tables[19].Rows[0]["SEZ_ICEGATE_ID"].ToString() != "")
                        {
                            if (Connection.COMPANYID() == "2650" && (Connection.Current_User_Upper() == "CAPIMPORT" || Connection.Current_User_Upper() == "CAPEXPORT" || Connection.Current_User_Upper() == "SRIVALLIMPORT" || Connection.Current_User_Upper() == "SRIVALLIEXPORT" || Connection.Current_User_Upper() == "SUNIMPEX"))
                            {
                                CHA_NO = CHA_NO;
                            }
                            else if (Connection.COMPANYID() == "2659" && Connection.Current_User_Upper() == "MILINDCIRCLE")
                            {
                                CHA_NO = CHA_NO;
                            }
                            else
                            {
                                if (ds.Tables[19].Rows[0]["SEZ_PAN_NO"].ToString() != "")
                                {
                                    CHA_NO = ds.Tables[19].Rows[0]["SEZ_PAN_NO"].ToString();
                                }
                            }
                                
                            txt_icegate_Id.Text = ds.Tables[19].Rows[0]["SEZ_ICEGATE_ID"].ToString();
                        }
                    }
                }
            }


            CUSTOMS_HOUSE = dt.Trim(ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString().ToUpper());

            IMPORTER_NAME = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString().TrimEnd();
            ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString().TrimEnd();
            ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString().TrimEnd();
            ADDRESS3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString().TrimEnd();
            ADDRESS4 = ds.Tables[0].Rows[0]["ADDRESS4"].ToString().TrimEnd();
            ADDRESS5 = ds.Tables[0].Rows[0]["ADDRESS5"].ToString().TrimEnd();
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

            PROVISIONAL = ds.Tables[0].Rows[0]["PROVISIONAL"].ToString();

            PROVISIONAL_DESC = ds.Tables[0].Rows[0]["PROVISIONAL_DESC"].ToString();

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
            //WAREHOUSE_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();


            if (FILING_STATUS == "P")
            {
                FILING_STATUS = "Y";
            }


            IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
            
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
            else if (IMP_EXP_TYPE == "UNCLAIMED CARGO")
            {
                IMP_EXP_TYPE = "I";
            }
            else if (IMP_EXP_TYPE == "SEZ-T TO SEZ")
            {
                IMP_EXP_TYPE = "B";
            }
            else if (IMP_EXP_TYPE == "SEZ-M TO SEZ")
            {
                IMP_EXP_TYPE = "F";
            }
            else
            {
                IMP_EXP_TYPE = "P";
            }

            //HSS_ADD3_4 = HSS_ADD3 + HSS_ADD4;

            HSS_ADD3_4 = HSS_ADD3;

            COMMERCIAL_DETAILS_STATUS = ds.Tables[0].Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString();
            COMMERCIAL_TAX_STATECODE = ds.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString();
            COMMERCIAL_TAX_TYPE = ds.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString();
            COMMERCIAL_TAX_REGISTRATION_NO = dt.Trim(ds.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString());

            EXBOND_INBOND_BE_NO = ds.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString();
            EXBOND_INBOND_BE_DATE = ds.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString().Replace("19000101", "");
            EXBOND_BOND_NO = ds.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString();
            EXBOND_BOND_DATE = ds.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString().Replace("19000101", "");
            EXBOND_WAREHOUSE_CUSTOMS = ds.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString();
            //EXBOND_WAREHOUSE_CUSTOMS_CODE = ds.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString();
            EXBOND_NOOFPACKAGE = ds.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString();
            EXBOND_NOOFPACKAGE_UNITCODE = ds.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString();
            EXBOND_GROSS_WEIGHT = ds.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString();
            EXBOND_GROSS_WEIGHT_UNITCODE = ds.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString();
            EXBOND_DIRECT_EXBONDING = ds.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString();

            EXBOND_ADDL_LOAD_HSS = ds.Tables[0].Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString();
            EXBOND_MISC_LOAD_RATE = ds.Tables[0].Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString();

            JOB_STATUS = ds.Tables[0].Rows[0]["JOB_STATUS"].ToString();

            Authorized_Dealer_Code = ds.Tables[0].Rows[0]["ADCODE"].ToString();
            //#HSS_ADCODE
            /*-- hide on 12-04_2025 sugg.by Bala sir - Implemented for common all
            if (COMPANY_ID == "2046" || COMPANY_ID == "2059" || COMPANY_ID == "2463" || COMPANY_ID == "2514" || COMPANY_ID == "2709")
            {
                if (HIGH_SEA_SALE == "Y")
                {
                    Authorized_Dealer_Code = ds.Tables[0].Rows[0]["HSS_ADCODE"].ToString();
                }
            }
             * */

            if (HIGH_SEA_SALE == "Y")
            {
                if (ds.Tables[0].Rows[0]["HSS_ADCODE"].ToString() != "")
                {
                    Authorized_Dealer_Code = ds.Tables[0].Rows[0]["HSS_ADCODE"].ToString();
                }
            }

            if (Authorized_Dealer_Code != "")
            {
                if (BE_TYPE == "Z" || BE_TYPE == "T" || BE_TYPE == "M" || BE_TYPE == "J" || BE_TYPE == "R" || BE_TYPE == "E" || BE_TYPE == "D" || BE_TYPE == "V" || BE_TYPE == "S")
                {
                }
                else
                {
                    Authorized_Dealer_Code = Authorized_Dealer_Code.Substring(0, 7);
                }
            }

            UCR_NO = ds.Tables[0].Rows[0]["UCR_NO"].ToString();
            UCR_TYPE = ds.Tables[0].Rows[0]["UCR_TYPE"].ToString();
            PAYMENT_METHOD_CODE = ds.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString().ToUpper();
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
        IMPORTER_CLASS = "N";
        Export_FlatFile_Generation Imp_FlatFile = new Export_FlatFile_Generation();
        Imp_FlatFile.Ename = "IMPORT_SELECT";

        dss = Imp_FlatFile.Search_Admin_Master();
        DataView view1 = dss.Tables[0].DefaultView;

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

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {


            if (COMPANY_ID == "1" || COMPANY_ID == "10")
            {
                if (!Check_Invoice_Lock())
                    return;
            }

            if (Check_BondMandatory_Notn045())
            {
                if (Connection.Get_User_Imp_Settings_Job_Edit("FF_ALLOW_WITHOUT_REBOND_NOTN") != "E")
                {
                    ShowJsAlert("Bond Details Mandatory for Notn-045/2025 - I414");
                    return;
                }
            }


            DataSet ds_Logs = new DataSet();
            Imp_Checklist IC = new Imp_Checklist();
            ds_Logs = IC.Imp_Checklist_Open_Logs(ddlJobNo.SelectedValue.ToString(), "Search_Logs");

            if (ds_Logs.Tables[0].Rows.Count == 0)
            {
                Import_Default_Entry.Post_Data(ddlJobNo.SelectedValue.ToString(), "CDRUG_Entry");
                if (Rdhelp.SelectedValue.ToString() == "No")
                {
                    Flatfile_gen();
                    gv_Details.DataSource = null;
                    gv_Details.DataBind();
                    lbltablename.Text = string.Empty;
                }
                else
                {
                    DataSet ds_A = new DataSet();

                    IV.Jobno = ddlJobNo.SelectedValue.ToString();
                    IV.Flag = "IMP_Flat_File_DETAILS";
                    IV.Branch_Type = SELECT_BRANCH;
                    ds_A = IV.IMP_Data_Select();

                    if (ds_A.Tables[0].Rows.Count > 0 || ds_A.Tables[1].Rows.Count > 0)
                    {
                        if (ds_A.Tables[0].Rows.Count > 0)
                        {
                            gv_Details.DataSource = ds_A.Tables[0];
                        }
                        else if (ds_A.Tables[1].Rows.Count > 0)
                        {
                            gv_Details.DataSource = ds_A.Tables[1];
                        }

                        gv_Details.DataBind();
                        gv_Details.Attributes.Add("Width", "100%");

                        lbltablename.Text = "* Check below Error Page Details";
                        laod_Flat_File_Show();
                    }
                    else
                    {

                        if (General_Details() == 1)
                        {
                            if (IGM_Details() == 1)
                            {
                                if (IGM_Bond_Item_Scheme() == 1)
                                {
                                    if (Invoice_Details() == 1)
                                    {
                                        if (Invoice_Cur_Ex_Rate_Details() == 1)
                                        {
                                            if (Invoice_Item() == 1)
                                            {
                                                if (Item_Details() == 1)
                                                {
                                                    if (Item_Special_Charaters() == 1)
                                                    {
                                                        if (Item_Details_Notification() == 1)
                                                        {
                                                            if (Item_License() == 1 && Re_Import() == 1 && Single_Window() == 1)
                                                            {
                                                                if (Single_Window_Entry() == 1)
                                                                {
                                                                    if (Single_Window_Entry_Cnt() == 1)
                                                                    {
                                                                        if (Item_Details_SingWindow_Default_Entry() == 1)
                                                                        {
                                                                            if (Single_Window_SIMS() == 1)
                                                                            {
                                                                                if (Single_Window_SIMS_sup_doc() == 1)
                                                                                {
                                                                                    if (Connection.COMPANYID() == "293")
                                                                                    {
                                                                                        if (Paramount() == 1)
                                                                                        {
                                                                                            Flatfile_gen();
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Flatfile_gen();
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                    }

                                }
                            }
                        }

                    }
                }
            }//ds_Logs
            else
            {
                gv_Details.DataSource = ds_Logs.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Attention : Please ensure your checklist. The following changes have been made to the Job.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>showCustomAlert1('✔ Attention : ','“Please verify the checklist before generating the Flat File, since updates were made to the Job.”')</script>", false);

            }
        }
        catch (Exception ex)
        {
        }
    }

    private int General_Details()
    {
        int G = 1;
        DataSet ds_1 = new DataSet();

        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_GENERAL_DETAILS";
        IV.Branch_Type = SELECT_BRANCH;
        ds_1 = IV.IMP_Data_Select();

        if (ds_1.Tables[0].Rows.Count > 0)
        {
            DataSet ds_2 = new DataSet();
            String xmlData = ConvertDataTableToXML(ds_1.Tables[0]);
            IV.Xml_D = xmlData;
            ds_2 = IV.IMP_Admin_Select();

            if (ds_2.Tables[0].Rows.Count > 0)//G
            {
                gv_Details.DataSource = ds_2.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur General Details page";
                laod_Flat_File_Show();
                G = 0;
            }
        }

        return G;
    }
    private int IGM_Details()
    {
        int IGM = 1;

        DataSet dsss = new DataSet();

        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "Check_Exbond_Job";
        IV.Branch_Type = SELECT_BRANCH;
        dsss = IV.IMP_Data_Select();

        if (dsss.Tables[0].Rows.Count > 0)
        {
            DataSet ds_10 = new DataSet();
            IV.Jobno = ddlJobNo.SelectedValue.ToString();
            IV.Flag = "Validate_Exbond_Job";
            IV.Branch_Type = SELECT_BRANCH;
            ds_10 = IV.IMP_Data_Select();

            if (ds_10.Tables[0].Rows.Count > 0)
            {
                DataSet ds_2 = new DataSet();
                String xmlData = ConvertDataTableToXML(ds_10.Tables[0]);
                IV.Xml_D = xmlData;
                ds_2 = IV.IMP_Admin_Select();
                if (ds_2.Tables[0].Rows.Count > 0)
                {
                    gv_Details.DataSource = ds_2.Tables[0];
                    gv_Details.DataBind();
                    gv_Details.Attributes.Add("Width", "180%");

                    lbltablename.Text = "* Check Ur EX-Bond Details page";
                    laod_Flat_File_Show();
                    IGM = 0;
                }
            }
        }
        else
        {

            DataSet ds_3 = new DataSet();
            IV.Jobno = ddlJobNo.SelectedValue.ToString();
            IV.Flag = "IMP_IGM_DETAILS";
            IV.Branch_Type = SELECT_BRANCH;
            ds_3 = IV.IMP_Data_Select();

            if (ds_3.Tables[0].Rows.Count > 0)//I
            {
                gv_Details.DataSource = ds_3.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "180%");

                lbltablename.Text = "* Check Ur IGM Details page";
                laod_Flat_File_Show();
                IGM = 0;
            }
        }

        return IGM;
    }
    private int IGM_Bond_Item_Scheme()
    {
        int Igm_Bond = 1;
        DataSet ds_B = new DataSet();

        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "Check_Bond_Item_Scheme";
        IV.Branch_Type = SELECT_BRANCH;
        ds_B = IV.IMP_Data_Select();
        if (ds_B.Tables[0].Rows.Count > 0)
        {
            gv_Details.DataSource = ds_B.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");

            lbltablename.Text = "* Check Ur IGM Bond Details page";
            Igm_Bond = 0;
        }
        return Igm_Bond;
    }
    private int Invoice_Details()
    {
        int INV = 1;
        DataSet ds_4 = new DataSet();
        IV.Flag = "IMP_EXCHANGE_RATE";
        ds_4 = IV.IMP_Admin_Select();

        if (ds_4.Tables[0].Rows.Count > 0)//AE
        {
            DataSet ds_5 = new DataSet();
            IV.Jobno = ddlJobNo.SelectedValue.ToString();
            IV.Flag = "IMP_INVOICE_DETAILS";
            IV.Branch_Type = SELECT_BRANCH;
            String xmlData_I = ConvertDataTableToXML(ds_4.Tables[0]);
            IV.Xml_D = xmlData_I;
            ds_5 = IV.IMP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "200%");

                lbltablename.Text = "* Check Ur Invoice Details page";
                laod_Flat_File_Show();

                INV = 0;
            }
        }

        return INV;
    }
    private int Invoice_Cur_Ex_Rate_Details()
    {
        int INV = 1;
        DataSet ds_4E = new DataSet();
        IV.Flag = "IMP_EXCHANGE_RATE";
        ds_4E = IV.IMP_Admin_Select();

        if (ds_4E.Tables[0].Rows.Count > 0)//AE
        {
            DataSet ds_5E = new DataSet();
            IV.Jobno = ddlJobNo.SelectedValue.ToString();
            IV.Flag = "IMP_INVOICE_CUR_EXCHANGE_RATE";
            IV.Branch_Type = SELECT_BRANCH;
            String xmlData_I = ConvertDataTableToXML(ds_4E.Tables[0]);
            IV.Xml_D = xmlData_I;
            ds_5E = IV.IMP_Data_Select();
            if (ds_5E.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5E.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "130%");

                lbltablename.Text = "* Check Ur Invoice Details page";
                laod_Flat_File_Show();
                INV = 0;
            }
        }
        return INV;
    }
    private int Invoice_Item()
    {
        int Inv_Item = 1;
        DataSet ds_3 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_Invoice_Item_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_3 = IV.IMP_Data_Select();

        if (ds_3.Tables[0].Rows.Count > 0)//I
        {
            gv_Details.DataSource = ds_3.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");

            lbltablename.Text = "* Check Ur Item Details Entry Page";
            laod_Flat_File_Show();
            Inv_Item = 0;
        }
        return Inv_Item;
    }
    private int Item_Details()
    {
        int Item = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_ITEM_DETAILS_ADMIN";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Items_Details";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds_7.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "200%");

                lbltablename.Text = "* Check Ur Item Details page";
                laod_Flat_File_Show();
                Item = 0;
            }
        }
        else
        {
            Item = 0;
        }
        return Item;
    }
    private int Item_Special_Charaters()
    {
        int CR = 1;
        DataSet ds_12 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "Item_Special_Character";
        IV.Branch_Type = SELECT_BRANCH;
        ds_12 = IV.IMP_Data_Select();
        if (ds_12.Tables[0].Rows.Count > 0)
        {
            gv_Details.DataSource = ds_12.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");
            lbltablename.Text = "* Check Ur Item Description Special Character";
            laod_Flat_File_Show();
            CR = 0;
        }
        return CR;
    }
    private int Item_Details_Notification()
    {
        int Item_N = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_ITEM_NOTIF_ADMIN";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Item_Notification";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds_7.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "350%");

                lbltablename.Text = "* Check Ur Item Details page";
                laod_Flat_File_Show();
                Item_N = 0;
            }
        }
        else
        {
            Item_N = 0;
        }
        return Item_N;
    }
    private int Item_License()
    {
        int lic = 1;

        DataSet ds_10 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_ITEM_Lic";
        IV.Branch_Type = SELECT_BRANCH;
        ds_10 = IV.IMP_Data_Select();
        if (ds_10.Tables[0].Rows.Count > 0)
        {
            DataSet ds_11 = new DataSet();
            String xmlData_Port = ConvertDataTableToXML(ds_10.Tables[0]);
            IV.Xml_D = xmlData_Port;
            IV.Flag = "IMP_Item_Lic";
            ds_11 = IV.IMP_Admin_Select();
            if (ds_11.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds_11.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur License Port Details Page";
                laod_Flat_File_Show();
                lic = 0;
            }
        }


        return lic;
    }
    private int Certificate()
    {
        int Cer = 1;
        DataSet ds_12 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_CERTIFICATE_DETAILS";
        IV.Branch_Type = SELECT_BRANCH;
        ds_12 = IV.IMP_Data_Select();
        if (ds_12.Tables[0].Rows.Count > 0)
        {
            gv_Details.DataSource = ds_12.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");
            lbltablename.Text = "* Check Ur IGM Certificate Details Page";
            laod_Flat_File_Show();
            Cer = 0;
        }
        return Cer;
    }
    private int Re_Import()
    {
        int RE_Imp = 1;
        DataSet ds_13 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_RE_IMPORT_DETAILS_Admin_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_13 = IV.IMP_Data_Select();
        if (ds_13.Tables[0].Rows.Count > 0)
        {
            DataSet ds_14 = new DataSet();
            String xmlData_Port = ConvertDataTableToXML(ds_13.Tables[0]);
            IV.Xml_D = xmlData_Port;
            IV.Flag = "RE_Import";
            ds_14 = IV.IMP_Admin_Select();

            if (ds_14.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds_14.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");
                lbltablename.Text = "* Check Ur Re-Import Details Page";
                laod_Flat_File_Show();

                RE_Imp = 0;
            }
        }
        return RE_Imp;
    }
    private int Single_Window()
    {
        int SW = 1;

        DataSet ds_6 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_Single_Window_Admin_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Items_Single_Window";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds_7.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "210%");

                lbltablename.Text = "* Check Ur Single Window Details page";
                laod_Flat_File_Show();
                SW = 0;
            }
        }
        return SW;
    }
    private int Single_Window_Entry()
    {
        int SWE = 1;

        DataSet ds_6 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_Single_Window_Entry_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Items_SW_Entry";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                DataSet ds_8 = new DataSet();
                String xmlData_Item_2 = ConvertDataTableToXML(ds_7.Tables[0]);
                IV.Xml_D = xmlData_Item_2;
                IV.Flag = "SW_Control_Table";
                ds_8 = IV.IMP_Data_Select();
                if (ds_8.Tables[0].Rows.Count > 0)
                {
                    gv_Details.DataSource = ds_8.Tables[0];
                    gv_Details.DataBind();
                    gv_Details.Attributes.Add("Width", "100%");

                    lbltablename.Text = "* Check Ur Single Window Control Entry Details";
                    laod_Flat_File_Show();
                    SWE = 0;
                }
                else
                {
                    DataSet ds_9 = new DataSet();
                    String xmlData_Item_22 = ConvertDataTableToXML(ds_7.Tables[0]);
                    IV.Xml_D = xmlData_Item_22;
                    IV.Flag = "IMP_Items_SW_Entry_Table";
                    ds_9 = IV.IMP_Data_Select();

                    if (ds_9.Tables[0].Rows.Count > 0)
                    {
                        gv_Details.DataSource = ds_9.Tables[0];
                        gv_Details.DataBind();
                        gv_Details.Attributes.Add("Width", "100%");

                        lbltablename.Text = "* Check Ur Single Window Entry Details page";
                        laod_Flat_File_Show();
                        SWE = 0;
                    }
                }
            }
        }
        return SWE;
    }
    private int Single_Window_Entry_Cnt()  //N
    {
        int SWE = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_Single_Window_Entry_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_PLANT_COMMODITY_NAMES_PQIS";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0) // Single Window Entry Aval..
            {
                DataSet ds_8 = new DataSet();
                String xmlData_Item_2 = ConvertDataTableToXML(ds_7.Tables[0]);
                String xmlData_Item_A = ConvertDataTableToXML(ds_7.Tables[1]);
                IV.Xml_D = xmlData_Item_2;
                IV.Xml_A = xmlData_Item_A;
                IV.Flag = "Item_SW";
                ds_8 = IV.IMP_Data_Select();
                if (ds_8.Tables[0].Rows.Count > 0)
                {
                    gv_Details.DataSource = ds_8.Tables[0];
                    gv_Details.DataBind();
                    gv_Details.Attributes.Add("Width", "100%");

                    lbltablename.Text = "* Check Ur Single Window Control Entry Details";
                    laod_Flat_File_Show();
                    SWE = 0;
                }
            }
        }
        return SWE;
    }
    private int Item_Details_SingWindow_Default_Entry()
    {
        int Item = 1;
        DataSet ds_8 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_Items_SW_Auto_Entry";
        IV.Branch_Type = SELECT_BRANCH;
        ds_8 = IV.IMP_Data_Select();
        if (ds_8.Tables[0].Rows.Count > 0)
        {
            DataSet ds_9 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_8.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Items_CTH_Info_UQC";
            ds_9 = IV.IMP_Admin_Select();
            if (ds_9.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds_9.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Item Details page";
                Item = 0;
            }
        }
        else
        {
            Item = 0;
        }
        return Item;
    }
    private int Single_Window_SIMS()  //SIMS
    {
        int SIMS = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_Single_Window_Entry_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Items_SW_SIMS_Entry";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                DataSet ds_8 = new DataSet();
                String xmlData_Item_2 = ConvertDataTableToXML(ds_7.Tables[0]);
                IV.Xml_D = xmlData_Item_2;
                IV.Flag = "SW_SIMS_InfoType_Table";
                ds_8 = IV.IMP_Data_Select();
                if (ds_8.Tables[0].Rows.Count > 0)
                {
                    gv_Details.DataSource = ds_8.Tables[0];
                    gv_Details.DataBind();
                    gv_Details.Attributes.Add("Width", "100%");
                    lbltablename.Text = "* Check Ur Single Window Info Type SIMS Entry Details";
                    SIMS = 0;
                }
            }
        }
        return SIMS;
    }
    private int Single_Window_SIMS_sup_doc()  //SIMS
    {
        int SIMS = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = ddlJobNo.SelectedValue.ToString();
        IV.Flag = "IMP_SW_SIMS_Sup_Doc_Entry_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            gv_Details.DataSource = ds_6.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");

            lbltablename.Text = "* e-Sanchit Document Missing.";
            SIMS = 0;
        }
        return SIMS;
    }
    private int Paramount()
    {
        Imp_Checklist IC = new Imp_Checklist();
        int Imp_Chk = 1;
        DataSet ds_3 = new DataSet();
        ds_3 = IC.GetData(ddlJobNo.SelectedValue.ToString(), "", "Checklist_NOTN_Chk_Paramount");

        if (ds_3.Tables[0].Rows.Count > 0)//I
        {
            gv_Details.DataSource = ds_3.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");

            lbltablename.Text = "* Check Ur Item Details Entry Page";
            laod_Flat_File_Show();
            Imp_Chk = 0;
        }
        return Imp_Chk;
    }
    private void laod_Flat_File_Show()
    {
        imgbtnFlatFile.Visible = false;
        btnsend_Queue.Visible = false;
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
    private void Flatfile_gen()
    {
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

            ds2 = Transact.RetrieveAll_General_Details(); //0

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
                imgbtnFlatFile.Enabled = false;
                btnsend_Queue.Enabled = false;

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
                                        btnsend_Queue.Enabled = false;
                                        imgbtnFlatFile.Enabled = false;

                                        MP_U.Show();
                                        lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                        btnsend_Queue.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                    }
                                }
                            }
                            else
                            {
                                imgbtnFlatFile.Enabled = true;
                                btnsend_Queue.Enabled = true;

                                IS_Imgbtn = "";

                                imgbtnFlatFile.Visible = false;
                                btnsend_Queue.Visible = false;

                                if (File.Exists(errorFolder + logFileName))
                                {
                                    DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                    foreach (FileInfo fi in dir.GetFiles())
                                    {
                                        fi.Delete();
                                    }

                                    Flat_File("", "");

                                    imgbtnFlatFile.Visible = true;
                                    btnsend_Queue.Visible = true;
                                }

                                else
                                {
                                    DirectoryInfo dir = new DirectoryInfo(errorFolder);
                                    foreach (FileInfo fi in dir.GetFiles())
                                    {
                                        fi.Delete();
                                    }

                                    Flat_File("", "");

                                    imgbtnFlatFile.Visible = true;
                                    btnsend_Queue.Visible = true;
                                }

                            }
                        }
                    }
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
                                    imgbtnFlatFile.Enabled = false;
                                    btnsend_Queue.Enabled = false;

                                    MP_U.Show();
                                    lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                    btnsend_Queue.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                }
                                else
                                {
                                    IS_Imgbtn = "";
                                    imgbtnFlatFile.Visible = false;
                                    btnsend_Queue.Visible = false;

                                    imgbtnFlatFile.Enabled = true;
                                    btnsend_Queue.Enabled = true;

                                    if (File.Exists(errorFolder + logFileName))
                                    {
                                        DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                        foreach (FileInfo fi in dir.GetFiles())
                                        {
                                            fi.Delete();
                                        }

                                        Flat_File("", "");
                                        imgbtnFlatFile.Visible = true;
                                        btnsend_Queue.Visible = true;
                                    }
                                    else
                                    {

                                        DirectoryInfo dir = new DirectoryInfo(errorFolder);
                                        foreach (FileInfo fi in dir.GetFiles())
                                        {
                                            fi.Delete();
                                        }

                                        Flat_File("", "");
                                        imgbtnFlatFile.Visible = true;
                                        btnsend_Queue.Visible = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            IS_Imgbtn = "";
                            imgbtnFlatFile.Visible = false;
                            btnsend_Queue.Visible = false;

                            imgbtnFlatFile.Enabled = true;
                            btnsend_Queue.Enabled = true;

                            if (File.Exists(errorFolder + logFileName))
                            {
                                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                foreach (FileInfo fi in dir.GetFiles())
                                {
                                    fi.Delete();
                                }

                                Flat_File("", "");
                                imgbtnFlatFile.Visible = true;
                                btnsend_Queue.Visible = true;
                            }
                            else
                            {
                                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                                foreach (FileInfo fi in dir.GetFiles())
                                {
                                    fi.Delete();
                                }

                                Flat_File("", "");
                                imgbtnFlatFile.Visible = true;
                                btnsend_Queue.Visible = true;
                            }
                        }
                    }

                    else
                    {
                        IS_Imgbtn = "";
                        imgbtnFlatFile.Visible = false;
                        btnsend_Queue.Visible = false;
                        imgbtnFlatFile.Enabled = true;
                        btnsend_Queue.Enabled = true;

                        if (File.Exists(errorFolder + logFileName))
                        {
                            DirectoryInfo dir = new DirectoryInfo(errorFolder);
                            foreach (FileInfo fi in dir.GetFiles())
                            {
                                fi.Delete();
                            }
                            Flat_File("", "");
                            imgbtnFlatFile.Visible = true;
                            btnsend_Queue.Visible = true;
                        }
                        else
                        {
                            DirectoryInfo dir = new DirectoryInfo(errorFolder);
                            foreach (FileInfo fi in dir.GetFiles())
                            {
                                fi.Delete();
                            }

                            Flat_File("", "");

                            imgbtnFlatFile.Visible = true;
                            btnsend_Queue.Visible = true;
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
            btnsend_Queue.Visible = false;
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Flat_File("", "");
                imgbtnFlatFile.Visible = true;
                btnsend_Queue.Visible = true;

            }

            else
            {

                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File("", "");
                imgbtnFlatFile.Visible = true;
                btnsend_Queue.Visible = true;
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
            btnsend_Queue.Visible = false;
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File("", "");

                mail(errorFolder + logFileName);
                imgbtnFlatFile.Visible = true;
                btnsend_Queue.Visible = true;
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Flat_File("", "");
                mail(errorFolder + logFileName);
                imgbtnFlatFile.Visible = true;
                btnsend_Queue.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    public void Flat_File(string Type, string path)
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

        JOBNO = ddlJobNo.SelectedValue.ToString();

        if (chkDummyFlatFile.Checked)
        {
            try
            {
                //JOBNO = GetAndSaveDummyJobNo(JOBNO); 

                JOBNO = GetAndSaveDummyJobNo(JOBNO, "F");
  

                txtDummyJobNo.Text = JOBNO;           
            }
            catch (InvalidOperationException ex)
            {
                ShowMessage(ex.Message, false);
                return; 
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("DummyFlatFile Save Error: " + ex.ToString());
                ShowMessage("Could not save Dummy Job No. Please try again.", false);
                return;
            }
        }


        if (Type == "SQ")
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(path + logFileName);
            try
            {
                fi.Delete();
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }

            sw = new StreamWriter(path + logFileName, true);

        }
        else
        {
            sw = new StreamWriter(errorFolder + logFileName, true);
        }

        ICEGATE_ID = txt_icegate_Id.Text.ToUpper();

        //----------------------- Kiran Group --------------------------
        if (Connection.COMPANYID() == "1636")
        {
            if (txt_icegate_Id.Text == "RKLPLCHA" || txt_icegate_Id.Text == "RKLPLCHAJM" || txt_icegate_Id.Text == "RKLPLCHAUM" || txt_icegate_Id.Text == "RKLPLCHARK")
            {
                CHA_NO = "AADCR4880PCH001";
            }
            else if (txt_icegate_Id.Text == "RKRLCHA")
            {
                if (CUSTOMS_HOUSE == "INMUN1")
                {
                    CHA_NO = "AACFK1870ECH002";
                }
                else
                {
                    CHA_NO = "AACFK1870ECH001";
                }
            }
            else if (txt_icegate_Id.Text == "KRSACHA")
            {
                CHA_NO = "AAGFK4878CCH001";
            }
        }



        if (BE_TYPE == "X")
        {
            sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + BE_TYPE + ch + "CACHI01" + ch + JOBNO + ch + JOBDATE + ch + time);
        }
        else
        {
            sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + ch + "CACHI01" + ch + JOBNO + ch + JOBDATE + ch + time);
        }
        sw.WriteLine("<TABLE>BE");


        ADDRESS1 = ADDRESS1.Length == 1 ? ADDRESS1 : ADDRESS1.TrimEnd('.');
        ADDRESS2 = ADDRESS2.Length == 1 ? ADDRESS2 : ADDRESS2.TrimEnd('.');
        ADDRESS3 = ADDRESS3.Length == 1 ? ADDRESS3 : ADDRESS3.TrimEnd('.');
        ADDRESS4 = ADDRESS4.Length == 1 ? ADDRESS4 : ADDRESS4.TrimEnd('.');
        ADDRESS5 = ADDRESS5.Length == 1 ? ADDRESS5 : ADDRESS5.TrimEnd('.');

        if (BE_TYPE == "M" || BE_TYPE == "V")
        {
            COUNTRY_ORIGIN = "IN";
            COUNTRY_SHIPMENT = "IN";
        }

        //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + BE_TYPE + ch + IEC_NO + ch + BRANCH_NO + ch + IMPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + IMPORTER_CLASS + ch + TRANSPORT_MODE + ch + IMP_EXP_TYPE + ch + KACHHA_BE + ch + HIGH_SEA_SALE + ch + PORT_ORIGIN + ch + "CHA CODE" + ch + COUNTRY_ORIGIN + ch + COUNTRY_SHIPMENT + ch + PORT_SHIPMENT + ch + GREEN_CHANNEL + ch + SECTION48 + ch + FILING_STATUS + Authorized_Dealer_Code + FIRSTCHECK + ch + WAREHOUSE_CODE + ch + "Warehouse Customs Site ID" + ch + "Ware house BE No" + ch + "Ware house BE Date" + ch + "No of packages released" + ch + "PACKAGE CODE" + ch + "GROSS WEIGHT" + ch + "UNIT OF MEASUREMENT" + ch + "Loading for X-Bond Over Ware-House BE" + ch + "Miscellaneous load Rate" + time);
        //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + BE_TYPE + ch + IEC_NO + ch + BRANCH_NO + ch + IMPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + IMPORTER_CLASS + ch + TRANSPORT_MODE + ch + IMP_EXP_TYPE + ch + KACHHA_BE + ch + HIGH_SEA_SALE + ch + PORT_ORIGIN + ch + CHA_NO + ch + COUNTRY_ORIGIN + ch + COUNTRY_SHIPMENT + ch + PORT_SHIPMENT + ch + GREEN_CHANNEL + ch + SECTION48 + ch + FILING_STATUS + ch + Authorized_Dealer_Code + ch + FIRSTCHECK + ch + EXBOND_WAREHOUSE_CUSTOMS_CODE + ch + EXBOND_WAREHOUSE_CUSTOMS + ch + EXBOND_INBOND_BE_NO + ch + EXBOND_INBOND_BE_DATE + ch + EXBOND_NOOFPACKAGE + ch + EXBOND_NOOFPACKAGE_UNITCODE + ch + EXBOND_GROSS_WEIGHT + ch + EXBOND_GROSS_WEIGHT_UNITCODE + ch + LOADING_EXBOND_WARWHOUSE + ch + MISC_LOAD_RATE + ch + UCR_NO + ch + UCR_TYPE + ch + PAYMENT_METHOD_CODE);//+ time);
        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + BE_TYPE + ch + IEC_NO + ch + BRANCH_NO + ch + IMPORTER_NAME.TrimEnd('.') + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + IMPORTER_CLASS + ch + TRANSPORT_MODE + ch + IMP_EXP_TYPE + ch + KACHHA_BE + ch + HIGH_SEA_SALE + ch + PORT_ORIGIN + ch + CHA_NO + ch + COUNTRY_ORIGIN + ch + COUNTRY_SHIPMENT + ch + PORT_SHIPMENT + ch + GREEN_CHANNEL + ch + SECTION48 + ch + FILING_STATUS + ch + Authorized_Dealer_Code + ch + FIRSTCHECK + ch + EXBOND_WAREHOUSE_CUSTOMS_CODE + ch + EXBOND_WAREHOUSE_CUSTOMS + ch + EXBOND_INBOND_BE_NO + ch + EXBOND_INBOND_BE_DATE + ch + EXBOND_NOOFPACKAGE + ch + EXBOND_NOOFPACKAGE_UNITCODE + ch + EXBOND_GROSS_WEIGHT + ch + EXBOND_GROSS_WEIGHT_UNITCODE + ch + EXBOND_ADDL_LOAD_HSS + ch + EXBOND_MISC_LOAD_RATE + ch + UCR_NO + ch + UCR_TYPE + ch + PAYMENT_METHOD_CODE);//+ time);

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
                            // hide on 06-08-2021 by Chithra for NOn-STD FRT,INS Curr move in Flatfile
                            /*
                            DataView view2 = ds.Tables[1].DefaultView;
                            view2.RowFilter = "INVOICE_CURRENCY = '" + INVOICE_CURRENCY + "'";
                            */

                            DataView view2 = ds.Tables[18].DefaultView;
                            view2.RowFilter = "NON_STD_CUR_CODE = '" + INVOICE_CURRENCY + "'";

                            DataSet dt_2 = new DataSet();
                            dt_2.Tables.Add(view2.ToTable());

                            if (dt_2.Tables[0].Rows.Count > 0)
                            {
                                NON_STD_EFFECT_DT_IMP = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString().Replace("19000101", ""));
                                NON_STD_BANKNAME = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString());
                                NON_STD_CERTIFICATE_NO = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString());
                                NON_STD_CERTIFICATE_DATE = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString().Replace("19000101", ""));
                                //INVOICE_EXRATE = dt.Trim(dt_2.Tables[0].Rows[0]["INVOICE_EXRATE"].ToString());// hide on 06-08-2021 by Chithra for NOn-STD move in Flatfile
                                INVOICE_EXRATE = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString());
                                Standard_Currency = "N";

                                NON_STD_CERTIFICATE_NO = NON_STD_CERTIFICATE_NO.Length == 1 ? NON_STD_CERTIFICATE_NO : NON_STD_CERTIFICATE_NO.TrimEnd('.');
                                NON_STD_BANKNAME = NON_STD_BANKNAME.Length == 1 ? NON_STD_BANKNAME : NON_STD_BANKNAME.TrimEnd('.');

                            }
                        }


                        //---------------For Non Standard Currency on 01Sep2015----------------//



                        if (INVOICE_CURRENCY != "")

                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + NON_STD_EFFECT_DT_IMP + ch + NON_STD_BANKNAME + ch + NON_STD_CERTIFICATE_NO + ch + NON_STD_CERTIFICATE_DATE);

                        //if (currentcomp_name == "Royal Tech Systems")
                        //{
                        //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXRATE + ch + NON_STD_EFFECT_DT_IMP + ch + NON_STD_BANKNAME + ch + NON_STD_CERTIFICATE_NO + ch + NON_STD_CERTIFICATE_DATE);
                        //}
                        //else
                        //{
                        //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
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

                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //        else
                //        {
                //            //l1.Text = " A = B = C ";
                //            //l2.Text = " D ";

                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_CURRENCY) + ch + MIS_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //        }
                //    }
                //    else
                //    {
                //        if (INVOICE_CURRENCY == MIS_CURRENCY)
                //        {
                //            //l1.Text = " A = B = D";
                //            //l2.Text = " C";

                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        }
                //        else
                //        {
                //            if (MIS_INSURANCE_CURRENCY == MIS_CURRENCY)
                //            {
                //                //l1.Text = " A = B ";
                //                //l2.Text = " C = D ";

                //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //            }
                //            else
                //            {
                //                //l1.Text = " A = B ";
                //                //l2.Text = " C";
                //                //l3.Text = " D";

                //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_CURRENCY) + ch + MIS_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
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

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //    }
                //    else
                //    {
                //        if (MIS_FREIGHT_CURRENCY == MIS_CURRENCY)
                //        {
                //            //l1.Text = " A = C ";
                //            //l2.Text = " B = D ";

                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //        }
                //        else
                //        {
                //            //l1.Text = " A = C ";
                //            //l2.Text = " B ";
                //            //l3.Text = " D ";

                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_CURRENCY) + ch + MIS_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //        }
                //    }
                //}

                //else if (INVOICE_CURRENCY == MIS_CURRENCY)
                //{
                //    if (MIS_FREIGHT_CURRENCY == MIS_INSURANCE_CURRENCY)
                //    {
                //        //l1.Text = " A = D ";
                //        //l2.Text = " B = C ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);


                //    }
                //    else
                //    {
                //        //l1.Text = " A = D ";
                //        //l2.Text = " B ";
                //        //l3.Text = " C ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //    }

                //}
                //else if (MIS_FREIGHT_CURRENCY == MIS_INSURANCE_CURRENCY)
                //{
                //    if (MIS_FREIGHT_CURRENCY == MIS_CURRENCY)
                //    {
                //        //l1.Text = " A ";
                //        //l2.Text = " B = C = D ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //    }
                //    else
                //    {
                //        //l1.Text = " A ";
                //        //l2.Text = " B = C ";
                //        //l3.Text = " D ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_CURRENCY) + ch + MIS_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    }
                //}
                //else if (MIS_FREIGHT_CURRENCY == MIS_CURRENCY)
                //{
                //    if (MIS_INSURANCE_CURRENCY == MIS_CURRENCY)
                //    {
                //        //l1.Text = " A ";
                //        //l2.Text = " B = C = D ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //    }
                //    else
                //    {
                //        //l1.Text = " A ";
                //        //l2.Text = " B = D ";
                //        //l3.Text = " C ";

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    }
                //}
                //else if (MIS_INSURANCE_CURRENCY == MIS_CURRENCY)
                //{
                //    //l1.Text = " A ";
                //    //l2.Text = " B ";
                //    //l3.Text = " C = D ";

                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);

                //}
                //else
                //{
                //    //l1.Text = " A ";
                //    //l2.Text = " B ";
                //    //l3.Text = " C ";
                //    //l4.Text = " D ";

                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + INVOICE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_FREIGHT_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_FREIGHT_CURRENCY) + ch + MIS_FREIGHT_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_INSURANCE_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_INSURANCE_CURRENCY) + ch + MIS_INSURANCE_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + MIS_CURRENCY + ch + Standard_Currency + ch + dt.Get_Exchange_PerUnit(MIS_CURRENCY) + ch + MIS_EXRATE + ch + Effective_Date + ch + Bank_Name_Non_Std_Cur + ch + Exch_Certificate_No + ch + Exch_Certificate_Date);
                //}




            }
        }
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (SECTION48 == "Y" || FIRSTCHECK == "Y" || PROVISIONAL == "Y")
            {
                sw.WriteLine("<TABLE>PERMISSION");

                SECTION48_DESC = SECTION48_DESC.Length == 1 ? SECTION48_DESC : SECTION48_DESC.TrimEnd('.');
                PROVISIONAL_DESC = PROVISIONAL_DESC.Length == 1 ? PROVISIONAL_DESC : PROVISIONAL_DESC.TrimEnd('.');

                if (SECTION48 == "Y")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + "S48" + ch + SECTION48_DESC);
                }
                else if (FIRSTCHECK == "Y")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + "FCK" + ch + FIRSTCHECK_DESC);
                }
                
                if (PROVISIONAL == "Y")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + "PRV" + ch + PROVISIONAL_DESC);
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
                INVOICE_EXRATE = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_EXRATE"].ToString().Replace("19000101", ""));

                SVB_RELATION = dt.Trim(ds.Tables[1].Rows[i]["SVB_RELATION"].ToString());

                if (SVB_RELATION == "Y")
                {
                    SVB_REF_NO = dt.Trim(ds.Tables[1].Rows[i]["SVB_REF_NO"].ToString());
                    SVB_REF_DATE = dt.Trim(ds.Tables[1].Rows[i]["SVB_REF_DATE"].ToString().Replace("19000101", ""));
                    SVB_CUSTOM_HOUSE = dt.Trim(ds.Tables[1].Rows[i]["SVB_CUSTOM_HOUSE"].ToString()).ToUpper();
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

                D_AMOUNT = dt.Trim(ds.Tables[1].Rows[i]["D_AMOUNT"].ToString());
                M_AMOUNT = dt.Trim(ds.Tables[1].Rows[i]["M_AMOUNT"].ToString());
                N_AMOUNT = dt.Trim(ds.Tables[1].Rows[i]["N_AMOUNT"].ToString());

                MIS_RATE = dt.Get_Nullval(dt.Num_Trim(ds.Tables[1].Rows[i]["MIS_RATE"].ToString()));

                //if (TERMS == "CI")
                //{
                //    if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
                //    {
                //        MIS_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_CHARGES"].ToString() + D_AMOUNT + M_AMOUNT + N_AMOUNT));
                //        MIS_CURRENCY = dt.Trim(INVOICE_CURRENCY);
                //    }
                //    else
                //    {
                //        MIS_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_CHARGES"].ToString()));
                //        MIS_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["MIS_CURRENCY"].ToString());
                //    }
                //}
                //else
                //{
                //    MIS_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["MIS_CHARGES"].ToString()));
                //    MIS_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["MIS_CURRENCY"].ToString());
                //}

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

                SUPPLIER_NAME = dt.Trim_Single_Quote(ds.Tables[1].Rows[i]["SUPPLIER_NAME"].ToString());
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


                //---------------- INVOICE MISC Charges -NEW
                INV_MISC_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["INV_MISC_CHARGES"].ToString()));
                INV_MISC_EXRATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["INV_MISC_EXRATE"].ToString()));
                INV_MISC_CURRENCY = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["INV_MISC_CURRENCY"].ToString()));
                INV_MISC_TOTAL_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["INV_MISC_TOTAL_CHARGES"].ToString()));
                INV_MISC_T_F = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["INV_MISC_T_F"].ToString()));

                if (INVOICE_CURRENCY.ToUpper() == "JPY" || INVOICE_CURRENCY.ToUpper() == "KRW")
                {
                    if (INV_MISC_EXRATE != "")
                    {
                        double invmisc_exrate1 = 0.00;
                        invmisc_exrate1 = Convert.ToDouble(INV_MISC_EXRATE) / 100;
                        INV_MISC_EXRATE = Convert.ToString(invmisc_exrate1);
                    }
                }

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
                                /* hide on 12-04-2022 by Chithra  for MISC+INV_MISC charges diff from checklist and FF.. Issue faced by Fairmacs
                                MIS_CHARGES = INV_MISC_TOTAL_CHARGES;
                                 * */

                                //------------ Same checklist calc impelmnted here for avoid entry page script loading issue ------------

                                double INV_MISC_CHARGES_CONVERT_INV = 0.00;
                                double INV_MISC_CHARGES_CONVERT_fc = 0.00;
                                double final_INV_MISC_CHARGES = 0.00;

                                if (MIS_CURRENCY != INV_MISC_CURRENCY)
                                {
                                    INV_MISC_CHARGES_CONVERT_INV = Convert.ToDouble(INV_MISC_CHARGES) * Convert.ToDouble(INV_MISC_EXRATE);
                                    INV_MISC_CHARGES_CONVERT_fc = INV_MISC_CHARGES_CONVERT_INV / Convert.ToDouble(MIS_EXRATE);
                                }
                                else
                                {
                                    INV_MISC_CHARGES_CONVERT_fc = Convert.ToDouble(INV_MISC_CHARGES);
                                }

                                final_INV_MISC_CHARGES = Convert.ToDouble(INV_MISC_CHARGES_CONVERT_fc) + Convert.ToDouble(MIS_CHARGES == "" ? "0.00" : MIS_CHARGES);
                                MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(final_INV_MISC_CHARGES), 2));

                                //-------------------------------------- end ---------------------------------------------------------------
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

                //if (txtBE_Type.Text == "Ex-Bond")
                //{
                //    OTHER_CONTRACT_NO = "";
                //    OTHER_CONTRACT_DATE = "";
                //    OTHER_LOC_NO = "";
                //    OTHER_LOC_DATE = "";
                //}




                INVOICE_NO = INVOICE_NO.Length == 1 ? INVOICE_NO : INVOICE_NO.TrimEnd('.');
                OTHER_PURCHASE_ORDER = OTHER_PURCHASE_ORDER.Length == 1 ? OTHER_PURCHASE_ORDER : OTHER_PURCHASE_ORDER.TrimEnd('.');
                OTHER_CONTRACT_NO = OTHER_CONTRACT_NO.Length == 1 ? OTHER_CONTRACT_NO : OTHER_CONTRACT_NO.TrimEnd('.');
                OTHER_LOC_NO = OTHER_LOC_NO.Length == 1 ? OTHER_LOC_NO : OTHER_LOC_NO.TrimEnd('.');
                SVB_REF_NO = SVB_REF_NO.Length == 1 ? SVB_REF_NO : SVB_REF_NO.TrimEnd('.');                
                //SUPPLIER_NAME = SUPPLIER_NAME.Length == 1 ? SUPPLIER_NAME : SUPPLIER_NAME.TrimEnd('.');
                SUPPLIER_NAME = SUPPLIER_NAME.Length == 1 ? SUPPLIER_NAME : SUPPLIER_NAME.TrimEnd(); // . Removed by pandiyan suggest by bala 05/02/2025
                SUPPLIER_ADDRESS = SUPPLIER_ADDRESS.Length == 1 ? SUPPLIER_ADDRESS : SUPPLIER_ADDRESS.TrimEnd('.');
                SUPPLIER_ADDRESS1 = SUPPLIER_ADDRESS1.Length == 1 ? SUPPLIER_ADDRESS1 : SUPPLIER_ADDRESS1.TrimEnd('.');
                SUPPLIER_ADDRESS2 = SUPPLIER_ADDRESS2.Length == 1 ? SUPPLIER_ADDRESS2 : SUPPLIER_ADDRESS2.TrimEnd('.');
                SUPPLIER_COUNTRY_NAME = SUPPLIER_COUNTRY_NAME.Length == 1 ? SUPPLIER_COUNTRY_NAME : SUPPLIER_COUNTRY_NAME.TrimEnd('.');
                SELLER_NAME = SELLER_NAME.Length == 1 ? SELLER_NAME : SELLER_NAME.TrimEnd('.');
                SELLER_ADDRESS = SELLER_ADDRESS.Length == 1 ? SELLER_ADDRESS : SELLER_ADDRESS.TrimEnd('.');
                SELLER_ADDRESS1 = SELLER_ADDRESS1.Length == 1 ? SELLER_ADDRESS1 : SELLER_ADDRESS1.TrimEnd('.');
                SELLER_ADDRESS2 = SELLER_ADDRESS2.Length == 1 ? SELLER_ADDRESS2 : SELLER_ADDRESS2.TrimEnd('.');
                SELLER_COUNTRY_NAME = SELLER_COUNTRY_NAME.Length == 1 ? SELLER_COUNTRY_NAME : SELLER_COUNTRY_NAME.TrimEnd('.');
                SELLERCOUNTRY_PINCODE = SELLERCOUNTRY_PINCODE.Length == 1 ? SELLERCOUNTRY_PINCODE : SELLERCOUNTRY_PINCODE.TrimEnd('.');
                BROKER_NAME = BROKER_NAME.Length == 1 ? BROKER_NAME : BROKER_NAME.TrimEnd('.');
                BROKER_ADDRESS = BROKER_ADDRESS.Length == 1 ? BROKER_ADDRESS : BROKER_ADDRESS.TrimEnd('.');
                BROKER_ADDRESS1 = BROKER_ADDRESS1.Length == 1 ? BROKER_ADDRESS1 : BROKER_ADDRESS1.TrimEnd('.');
                BROKER_ADDRESS2 = BROKER_ADDRESS2.Length == 1 ? BROKER_ADDRESS2 : BROKER_ADDRESS2.TrimEnd('.');
                BROKER_COUNTRY_NAME = BROKER_COUNTRY_NAME.Length == 1 ? BROKER_COUNTRY_NAME : BROKER_COUNTRY_NAME.TrimEnd('.');
                BROKER_COUNTRY_CODE = BROKER_COUNTRY_CODE.Length == 1 ? BROKER_COUNTRY_CODE : BROKER_COUNTRY_CODE.TrimEnd('.');
                BROKER_COUNTRY_PINCODE = BROKER_COUNTRY_PINCODE.Length == 1 ? BROKER_COUNTRY_PINCODE : BROKER_COUNTRY_PINCODE.TrimEnd('.');
                TERMS_PLACE = TERMS_PLACE.Length == 1 ? TERMS_PLACE : TERMS_PLACE.TrimEnd('.');
                THIRDPARTY_NAME = THIRDPARTY_NAME.Length == 1 ? THIRDPARTY_NAME : THIRDPARTY_NAME.TrimEnd('.');
                THIRDPARTY_ADD1 = THIRDPARTY_ADD1.Length == 1 ? THIRDPARTY_ADD1 : THIRDPARTY_ADD1.TrimEnd('.');
                THIRDPARTY_ADD2 = THIRDPARTY_ADD2.Length == 1 ? THIRDPARTY_ADD2 : THIRDPARTY_ADD2.TrimEnd('.');
                THIRDPARTY_CITY = THIRDPARTY_CITY.Length == 1 ? THIRDPARTY_CITY : THIRDPARTY_CITY.TrimEnd('.');
                T_PARTY_COUNTRY_SUB_DIV = T_PARTY_COUNTRY_SUB_DIV.Length == 1 ? T_PARTY_COUNTRY_SUB_DIV : T_PARTY_COUNTRY_SUB_DIV.TrimEnd('.');
                T_PARTY_COUNTRY_CODE = T_PARTY_COUNTRY_CODE.Length == 1 ? T_PARTY_COUNTRY_CODE : T_PARTY_COUNTRY_CODE.TrimEnd('.');
                T_PARTY_PIN = T_PARTY_PIN.Length == 1 ? T_PARTY_PIN : T_PARTY_PIN.TrimEnd('.');
                A_E_O_COUNTRY = A_E_O_COUNTRY.Length == 1 ? A_E_O_COUNTRY : A_E_O_COUNTRY.TrimEnd('.');
                AUTHORIZED_ECONOMIC_OPERATOR = AUTHORIZED_ECONOMIC_OPERATOR.Length == 1 ? AUTHORIZED_ECONOMIC_OPERATOR : AUTHORIZED_ECONOMIC_OPERATOR.TrimEnd('.');



                if ((Connection.COMPANYID() == "1636" || Connection.COMPANYID() == "293" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4") && txtBE_Type.Text == "Ex-Bond")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + "" + ch + "" + ch + INVOICE_SLNO + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + INVOICE_NO + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "");
                }
                else
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + INVOICE_DATE + ch + OTHER_PURCHASE_ORDER + ch + OTHER_PURCHASE_ORDER_DATE + ch + OTHER_CONTRACT_NO + ch + OTHER_CONTRACT_DATE + ch + OTHER_LOC_NO + ch + OTHER_LOC_DATE + ch + SVB_REF_NO + ch + SVB_REF_DATE + ch + SVB_ASSESABLE_RATE + ch + SVB_DUTY_RATE + ch + SVB_LOADING_ON + ch + SVB_ASSESABLE_STATUS + ch + SVB_DUTY_STATUS + ch + SVB_CUSTOM_HOUSE + ch + SUPPLIER_NAME + ch + SUPPLIER_ADDRESS + ch + SUPPLIER_ADDRESS1 + ch + SUPPLIER_ADDRESS2 + ch + SUPPLIER_COUNTRY_NAME + ch + SUPPLIER_COUNTRY_PINCODE + ch + SELLER_NAME + ch + SELLER_ADDRESS + ch + SELLER_ADDRESS1 + ch + SELLER_ADDRESS2 + ch + SELLER_COUNTRY_NAME + ch + SELLERCOUNTRY_PINCODE + ch + BROKER_NAME + ch + BROKER_ADDRESS + ch + BROKER_ADDRESS1 + ch + BROKER_ADDRESS2 + ch + BROKER_COUNTRY_NAME + ch + BROKER_COUNTRY_PINCODE + ch + INVOICE_VALUE + ch + TERMS + ch + INVOICE_CURRENCY + ch + Nature_of_Discount + ch + MIS_DISCOUNT_RATE + ch + MIS_DISCOUNT_CHARGES + ch + MIS_HIGHSEASALE_RATE + ch + MIS_HIGHSEASALE_CHARGES + ch + MIS_FREIGHT_CHARGES + ch + MIS_FREIGHT_RATE + ch + Freight_Actual + ch + MIS_FREIGHT_CURRENCY + ch + MIS_INSURANCE_CHARGES + ch + MIS_INSURANCE_RATE + ch + MIS_INSURANCE_CURRENCY + ch + MIS_CHARGES + ch + MIS_CURRENCY + ch + MIS_RATE + ch + Landing_Rate + ch + MIS_LOADING_CHARGES + ch + MIS_LOADING_CURRENCY + ch + MIS_LOADING_RATE + ch + MIS_AGENCY_CHARGES + ch + MIS_AGENCY_CURRENCY + ch + MIS_AGENCY_RATE + ch + OTHER_NATURE_OF_TRANSACTION + ch + OTHER_TERMS_OF_PAYMENT + ch + Conditions_Attached_Sale1 + ch + Conditions_Attached_Sale2 + ch + Conditions_Attached_Sale3 + ch + Conditions_Attached_Sale4 + ch + Conditions_Attached_Sale5 + ch + OTHER_VALUATION_METHOD + ch + INVOICE_NO + ch + Other_Relevant_Information + ch + TERMS_PLACE + ch + THIRDPARTY_NAME + ch + THIRDPARTY_ADD1 + ch + THIRDPARTY_ADD2 + ch + THIRDPARTY_CITY + ch + T_PARTY_COUNTRY_SUB_DIV + ch + T_PARTY_COUNTRY_CODE + ch + T_PARTY_PIN + ch + AUTHORIZED_ECONOMIC_OPERATOR_CODE + ch + A_E_O_COUNTRY + ch + AUTHORIZED_ECONOMIC_OPERATOR + ch + WHETHER_BUYER_SELLER_RELATED);
                }
                i++;
            }
        }

        int l = 0;
        int l_CI_terms = 0;

        if (BE_TYPE != "X") // Modified by shanthini on 06-08-2026 suggest by bala sir 
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                while (ds.Tables[1].Rows.Count > l)
                {
                    INVOICE_SLNO = dt.Trim(ds.Tables[1].Rows[l]["INVOICE_SLNO"].ToString());
                    A_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["A_AMOUNT"].ToString());
                    B_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["B_AMOUNT"].ToString());
                    C_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["C_AMOUNT"].ToString());
                    D_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["D_AMOUNT"].ToString());
                    E_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["E_AMOUNT"].ToString());
                    F_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["F_AMOUNT"].ToString());
                    G_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["G_AMOUNT"].ToString());
                    H_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["H_AMOUNT"].ToString());
                    I_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["I_AMOUNT"].ToString());
                    J_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["J_AMOUNT"].ToString());
                    K_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["K_AMOUNT"].ToString());
                    L_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["L_AMOUNT"].ToString());
                    M_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["M_AMOUNT"].ToString());
                    N_AMOUNT = dt.Trim(ds.Tables[1].Rows[l]["N_AMOUNT"].ToString());

                    if (A_AMOUNT != "" || B_AMOUNT != "" || C_AMOUNT != "" || D_AMOUNT != "" ||
                        E_AMOUNT != "" || F_AMOUNT != "" || G_AMOUNT != "" || H_AMOUNT != "" ||
                        I_AMOUNT != "" || J_AMOUNT != "" || K_AMOUNT != "" || L_AMOUNT != "" ||
                        M_AMOUNT != "" || N_AMOUNT != "")
                    {
                        if (l_CI_terms == 0)
                        {
                            sw.WriteLine("<TABLE>MISC_CH");
                            l_CI_terms = 1;
                        }

                        if (A_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "A" + ch + "Brokerage and commissions" + ch + A_AMOUNT + ch + "0");
                        }
                        if (B_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "B" + ch + "Cost of Containers" + ch + B_AMOUNT + ch + "0");
                        }
                        if (C_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "C" + ch + "Cost of Packing" + ch + C_AMOUNT + ch + "0");
                        }
                        if (D_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "D" + ch + "Handling Charges" + ch + D_AMOUNT + ch + "0");
                        }
                        if (E_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "E" + ch + "Cost of Goods and Services" + ch + E_AMOUNT + ch + "0");
                        }
                        if (F_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "F" + ch + "Documentation" + ch + F_AMOUNT + ch + "0");
                        }
                        if (G_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "G" + ch + "Country of Origin Certificate" + ch + G_AMOUNT + ch + "0");
                        }
                        if (H_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "H" + ch + "Royalties and licence fees" + ch + H_AMOUNT + ch + "0");
                        }
                        if (I_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "I" + ch + "Value of proceeds which accrue" + ch + I_AMOUNT + ch + "0");
                        }
                        if (J_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "J" + ch + "Cost of Warrenty Services" + ch + J_AMOUNT + ch + "0");
                        }
                        if (K_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "K" + ch + "Other Cost or Payment" + ch + K_AMOUNT + ch + "0");
                        }
                        if (L_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "L" + ch + "Other Charges and Payments" + ch + L_AMOUNT + ch + "0");
                        }
                        if (M_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "M" + ch + "Loading Charges" + ch + M_AMOUNT + ch + "0");
                        }
                        if (N_AMOUNT != "")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + "N" + ch + "Unloading Charges" + ch + N_AMOUNT + ch + "0");
                        }

                    }
                    l++;
                }
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

                //ITEM_DESCRIPTION1 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION1"].ToString());
                //ITEM_DESCRIPTION2 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION2"].ToString());

                ITEM_DESCRIPTION1 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION1"].ToString()).Replace(System.Environment.NewLine, " ").Replace("\n", "");
                ITEM_DESCRIPTION2 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION2"].ToString()).Replace(System.Environment.NewLine, " ").Replace("\n", "");

                SCHEME_CODE_FULL = dt.Trim(ds.Tables[2].Rows[j]["SCHEME_CODE"].ToString());
                SCHEME_CODE = dt.Split("-", SCHEME_CODE_FULL);
                if (dt.Trim(SCHEME_CODE) == "00")
                    SCHEME_CODE = "";
                GENEARL_DESCRIPTION = dt.Trim(ds.Tables[2].Rows[j]["GENEARL_DESCRIPTION"].ToString().Replace(System.Environment.NewLine, " ").Replace("\n", ""));
                ACCESSORIES = dt.Trim(ds.Tables[2].Rows[j]["ACCESSORIES"].ToString().Replace(System.Environment.NewLine, " ").Replace("\n", ""));
                MANUFACTURER = dt.Trim(ds.Tables[2].Rows[j]["MANUFACTURER"].ToString());
                BRAND = dt.Trim(ds.Tables[2].Rows[j]["BRAND"].ToString());
                MODEL = dt.Trim(ds.Tables[2].Rows[j]["MODEL"].ToString());
                END_USE_OF_ITEM = dt.Trim(ds.Tables[2].Rows[j]["END_USE_OF_ITEM"].ToString()).ToUpper();

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

                //PRODUCT_TARIFF_QTY = "";

                /* hide by Chithra on 17-05-2023 sugg.by Subbu sir
                if (PRODUCT_TARIFF_NOTN.Trim() == "36/2001" && PRODUCT_TARIFF_SLNO.Trim() == "2(1)A")
                {
                    PRODUCT_TARIFF_QTY = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_TARIFF_QTY"].ToString());
                }
                else
                {
                    PRODUCT_TARIFF_QTY = "";
                }
                 * */

                PRODUCT_TARIFF_QTY = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_TARIFF_QTY"].ToString());

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

                CTH_QTY1 = "";
                CTH_QTY2 = "";

                PREVIOUS_BE_NO = dt.Trim(ds.Tables[2].Rows[j]["PREVIOUS_BE_NO"].ToString());
                PREVIOUS_BE_DATE = dt.Trim(ds.Tables[2].Rows[j]["PREVIOUS_BE_DATE"].ToString().Replace("19000101", ""));
                UNIT_PRICE = dt.amt_Trim(ds.Tables[2].Rows[j]["UNIT_PRICE"].ToString());

                UNIT_CODE = dt.Trim(ds.Tables[2].Rows[j]["UNIT_CODE"].ToString());
                PREVIOUS_CUSTOMS_HOUSE = dt.Trim(ds.Tables[2].Rows[j]["CUSTOMS_HOUSE"].ToString()).ToUpper();

                PRODUCT_MRP_YN = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_MRP_YN"].ToString());


                PRODUCT_CVD_EDU_CESS_RATE = dt.Trim(ds.Tables[2].Rows[j]["PRODUCT_CVD_EDU_CESS_RATE"].ToString());
                CETH_CVD_EDU_CESS_SL = dt.Trim(ds.Tables[2].Rows[j]["CETH_CVD_EDU_CESS_SL"].ToString());


                PRODUCT_CVD_EDU_CESS_RATE = dt.Trim(ds.Tables[2].Rows[j]["SOCIAL_WELFARE_NOTN"].ToString());
                CETH_CVD_EDU_CESS_SL = dt.Trim(ds.Tables[2].Rows[j]["SOCIAL_WELFARE_NOTN_SLNO"].ToString());

                //----------------ITEMWISE SVB FOR NIPPON EXPPRESS-----------------//                

                ITEM_SVB_RELATION = dt.Trim(ds.Tables[2].Rows[j]["SVB_RELATION"].ToString());

                if (ITEM_SVB_RELATION == "true")
                {
                    ITEM_SVB_REF_NO = dt.Trim(ds.Tables[2].Rows[j]["SVB_REF_NO"].ToString());
                    ITEM_SVB_REF_DATE = dt.Trim(ds.Tables[2].Rows[j]["SVB_REF_DATE"].ToString().Replace("19000101", ""));
                    ITEM_SVB_CUSTOM_HOUSE = dt.Trim(ds.Tables[2].Rows[j]["SVB_CUSTOM_HOUSE"].ToString()).ToUpper();
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
                if (CENTRAL_EXCISE_FALG == "C")
                {
                    if (M_P_GROWER_CODE == "")
                    {
                        M_P_GROWER_CODE = MANUFACTURER.Length > 17 ? MANUFACTURER.Substring(0, 17) : MANUFACTURER;
                    }
                }
                M_P_GROWER_ADD1 = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_ADD1"].ToString());
                M_P_GROWER_ADD2 = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_ADD2"].ToString());
                M_P_GROWER_CITY = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_CITY"].ToString());
                M_P_GROWER_COUNTRY_SUBDIV = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_COUNTRY_SUBDIV"].ToString());
                M_P_GROWER_PIN = dt.amt_Trim(ds.Tables[2].Rows[j]["M_P_GROWER_PIN"].ToString());
                M_P_GROWER_COUNTRY = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_COUNTRY"].ToString()).ToUpper();
                SOURCE_COUNTRY = dt.Trim(ds.Tables[2].Rows[j]["SOURCE_COUNTRY"].ToString()).ToUpper();
                TRANSIT_COUNTRY = dt.Trim(ds.Tables[2].Rows[j]["TRANSIT_COUNTRY"].ToString()).ToUpper();
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
                    CTH_QTY = "";
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

                //Need Settings here
                if (PRODUCT_CETH != "24022090" && PRODUCT_CETH != "24012010" && PRODUCT_CETH != "27090000" && PRODUCT_CETH != "27090010" && PRODUCT_CETH != "27090090" && PRODUCT_CETH != "27111100" && PRODUCT_CETH != "27101949" && PRODUCT_CETH != "27101241" && PRODUCT_CETH != "27101290" && PRODUCT_CETH != "24013000" && PRODUCT_CETH != "24012090" && PRODUCT_CETH != "24039100" && PRODUCT_CETH != "24012010" && PRODUCT_CETH != "24012040" && PRODUCT_CETH != "24011090")
                {
                    PRODUCT_CETH = "NOEXCISE";
                    /* hide on 06-02-2026- New budget updation CVD Notn should move. sugg.by Bala for PATKAR & SONS
                    PRODUCT_CVD_NOTN = "";
                    PRODUCT_CVD_SLNO = "";
                     * */
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
              
                if (ITEM_DESCRIPTION1.EndsWith("."))
                {
                    ITEM_DESCRIPTION1 = ITEM_DESCRIPTION1.Length == 1 ? ITEM_DESCRIPTION1 : ITEM_DESCRIPTION1.TrimEnd('.');
                    if (ITEM_DESCRIPTION2.Length > 59)
                    {
                        ITEM_DESCRIPTION2 = ITEM_DESCRIPTION2.Length == 1 ? "." + ITEM_DESCRIPTION2 : "." + ITEM_DESCRIPTION2.TrimEnd('.');
                        ITEM_DESCRIPTION2 = ITEM_DESCRIPTION2.Substring(0, 60);
                    }
                    else
                    {
                        ITEM_DESCRIPTION2 = ITEM_DESCRIPTION2.Length == 1 ? "." + ITEM_DESCRIPTION2 : "." + ITEM_DESCRIPTION2.TrimEnd('.');
                    }
                }
                else
                {
                    ITEM_DESCRIPTION1 = ITEM_DESCRIPTION1.Length == 1 ? ITEM_DESCRIPTION1 : ITEM_DESCRIPTION1.TrimEnd('.');
                    ITEM_DESCRIPTION2 = ITEM_DESCRIPTION2.Length == 1 ? ITEM_DESCRIPTION2 : ITEM_DESCRIPTION2.TrimEnd('.');
                }

                GENEARL_DESCRIPTION = GENEARL_DESCRIPTION.Length == 1 ? GENEARL_DESCRIPTION : GENEARL_DESCRIPTION.TrimEnd('.');
                ACCESSORIES = ACCESSORIES.Length == 1 ? ACCESSORIES : ACCESSORIES.TrimEnd('.');
                MANUFACTURER = MANUFACTURER.Length == 1 ? MANUFACTURER : MANUFACTURER.TrimEnd('.');
                BRAND = BRAND.Length == 1 ? BRAND : BRAND.TrimEnd('.');
                MODEL = MODEL.Length == 1 ? MODEL : MODEL.TrimEnd('.');
                END_USE_OF_ITEM = END_USE_OF_ITEM.Length == 1 ? END_USE_OF_ITEM : END_USE_OF_ITEM.TrimEnd('.');
                MANUFACTURER_PRODUCER = MANUFACTURER_PRODUCER.Length == 1 ? MANUFACTURER_PRODUCER : MANUFACTURER_PRODUCER.TrimEnd('.');
                M_P_GROWER_CODE = M_P_GROWER_CODE.Length == 1 ? M_P_GROWER_CODE : M_P_GROWER_CODE.TrimEnd('.');
                M_P_GROWER_ADD1 = M_P_GROWER_ADD1.Length == 1 ? M_P_GROWER_ADD1 : M_P_GROWER_ADD1.TrimEnd('.');
                M_P_GROWER_ADD2 = M_P_GROWER_ADD2.Length == 1 ? M_P_GROWER_ADD2 : M_P_GROWER_ADD2.TrimEnd('.');
                M_P_GROWER_CITY = M_P_GROWER_CITY.Length == 1 ? M_P_GROWER_CITY : M_P_GROWER_CITY.TrimEnd('.');
                M_P_GROWER_COUNTRY_SUBDIV = M_P_GROWER_COUNTRY_SUBDIV.Length == 1 ? M_P_GROWER_COUNTRY_SUBDIV : M_P_GROWER_COUNTRY_SUBDIV.TrimEnd('.');
                M_P_GROWER_PIN = M_P_GROWER_PIN.Length == 1 ? M_P_GROWER_PIN : M_P_GROWER_PIN.TrimEnd('.');
                M_P_GROWER_COUNTRY = M_P_GROWER_COUNTRY.Length == 1 ? M_P_GROWER_COUNTRY : M_P_GROWER_COUNTRY.TrimEnd('.');
                SOURCE_COUNTRY = SOURCE_COUNTRY.Length == 1 ? SOURCE_COUNTRY : SOURCE_COUNTRY.TrimEnd('.');
                TRANSIT_COUNTRY = TRANSIT_COUNTRY.Length == 1 ? TRANSIT_COUNTRY : TRANSIT_COUNTRY.TrimEnd('.');


                //PRODUCT_CETH

                // sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_QTY + ch + ITEM_QTY_CODE + ch + CTH_NO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + SCHEME_CODE + ch + GENEARL_DESCRIPTION + ch + ACCESSORIES + ch + MANUFACTURER + ch + BRAND + ch + MODEL + ch + END_USE_OF_ITEM + ch + COUNTRY_OF_ORIGIN + ch + CTH_NO + ch + PREFERENTIAL + ch + PRODUCT_CETH + ch + PRODUCT_BCD_NOTN + ch + PRODUCT_BCD_SLNO + ch + PRODUCT_CVD_NOTN + ch + PRODUCT_CVD_SLNO + ch + PRODUCT_ADDL_GSI_NOTN + ch + PRODUCT_ADDL_GSI_SLNO + ch + PRODUCT_ADDL_SHEII_NOTN + ch + PRODUCT_ADDL_SHEII_SLNO + ch + PRODUCT_ADDL_TTA_NOTN + ch + PRODUCT_ADDL_TTA_SLNO + ch + PRODUCT_ADDL_DUTY_NOTN + ch + PRODUCT_ADDL_DUTY_NOTN_SL  + ch + PRODUCT_NCD_NOTN + ch + PRODUCT_NCD_SLNO + ch + ANTI_DUMPING_NOTN + ch + ANTI_DUMPING_NOTN_SLNO + ch + CTH_SLNO + ch + CTH_SUPPLIER_SLNO + ch + CTH_QTY + ch + PRODUCT_TARIFF_NOTN + ch + PRODUCT_TARIFF_SLNO + ch + PRODUCT_TARIFF_QTY + ch + PRODUCT_SAPTA_NOTN + ch + PRODUCT_SAPTA_SLNO + ch + PRODUCT_ADDL_HEALTH_CESS_NOTN + ch + PRODUCT_ADDL_HEALTH_CESS_SLNO + ch + PRODUCT_CESS_NOTN + ch + PRODUCT_CESS_SLNO + ch + PRODUCT_AGGREGATE_DUTY_NOTN + ch + PRODUCT_AGGREGATE_DUTY_NOTN_SL + ch + PRODUCT_SAFEGUARD_NOTN + ch + PRODUCT_SAFEGUARD_SLNO + ch + ITEM_UNIT_PRICE + ch + DISCOUNT_RATE + ch + DISCOUNT_AMOUNT + ch + CTH_QTY1 + ch + CTH_QTY2 + ch + SVB_REFERENCE + ch + SVB_REFERENCE_DATE + ch + SVB_LOAD_ASSESSABLE + ch + SVB_LOAD_ON_DUTY + ch + SVB_FLAG + ch + WHETHER_LOAD_FINAL_ON_ASS + ch + WHETHER_LOAD_FINAL_ON_DUTY + ch + SVB_CUSTOM_HOUSE_CODE + ch + POLICY_PARA_NO + ch + POLICY_YEAR + ch + WHETHER_RSP_DECLARED + ch + WHETHER_REIMPORT + ch + PREVIOUS_BE_NO + ch + PREVIOUS_BE_DATE + ch + PREVIOUS_UNITPRICE + ch + PREVIOUS_CURRENY + ch + PREVIOUS_CUSTOMSITE);

                // sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_QTY + ch + ITEM_QTY_CODE + ch + CTH_NO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + SCHEME_CODE + ch + GENEARL_DESCRIPTION + ch + ACCESSORIES + ch + MANUFACTURER + ch + BRAND + ch + MODEL + ch + END_USE_OF_ITEM + ch + COUNTRY_OF_ORIGIN + ch + PRODUCT_CTH + ch + PREFERENTIAL + ch + PRODUCT_CETH + ch + PRODUCT_BCD_NOTN + ch + PRODUCT_BCD_SLNO + ch + PRODUCT_CVD_NOTN + ch + PRODUCT_CVD_SLNO + ch + PRODUCT_ADDL_GSI_NOTN + ch + PRODUCT_ADDL_GSI_SLNO + ch + PRODUCT_ADDL_SHEII_NOTN + ch + PRODUCT_ADDL_SHEII_SLNO + ch + PRODUCT_ADDL_TTA_NOTN + ch + PRODUCT_ADDL_TTA_SLNO + ch + PRODUCT_EDU_CESS_NOTN + ch + PRODUCT_EDU_CESS_NOTN_SL + ch + PRODUCT_NCD_NOTN + ch + PRODUCT_NCD_SLNO + ch + ANTI_DUMPING_NOTN + ch + ANTI_DUMPING_NOTN_SLNO + ch + CTH_SLNO + ch + CTH_SUPPLIER_SLNO + ch + CTH_QTY + ch + PRODUCT_TARIFF_NOTN + ch + PRODUCT_TARIFF_SLNO + ch + PRODUCT_TARIFF_QTY + ch + PRODUCT_SAPTA_NOTN + ch + PRODUCT_SAPTA_SLNO + ch + PRODUCT_ADDL_HEALTH_CESS_NOTN + ch + PRODUCT_ADDL_HEALTH_CESS_SLNO + ch + PRODUCT_ADDL_DUTY_NOTN + ch + PRODUCT_ADDL_DUTY_NOTN_SL + ch + PRODUCT_AGGREGATE_DUTY_NOTN + ch + PRODUCT_AGGREGATE_DUTY_NOTN_SL + ch + PRODUCT_SAFEGUARD_NOTN + ch + PRODUCT_SAFEGUARD_SLNO + ch + ITEM_UNIT_PRICE + ch + DISCOUNT_RATE + ch + DISCOUNT_AMOUNT + ch + CTH_QTY1 + ch + CTH_QTY2 + ch + SVB_REFERENCE + ch + SVB_REFERENCE_DATE + ch + SVB_LOAD_ASSESSABLE + ch + SVB_LOAD_ON_DUTY + ch + SVB_FLAG + ch + WHETHER_LOAD_FINAL_ON_ASS + ch + WHETHER_LOAD_FINAL_ON_DUTY + ch + SVB_CUSTOM_HOUSE_CODE + ch + POLICY_PARA_NO + ch + POLICY_YEAR + ch + WHETHER_RSP_DECLARED + ch + WHETHER_REIMPORT + ch + PREVIOUS_BE_NO + ch + PREVIOUS_BE_DATE + ch + PREVIOUS_UNITPRICE + ch + PREVIOUS_CURRENY + ch + PREVIOUS_CUSTOMS_HOUSE);

                //PREVIOUS_CURRENY , PREVIOUS_UNITPRICE - value should be move in FF - Sugg.By Bala Sir on 28-12-2023
                //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_QTY + ch + ITEM_QTY_CODE + ch + CTH_NO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + SCHEME_CODE + ch + GENEARL_DESCRIPTION + ch + ACCESSORIES + ch + MANUFACTURER + ch + BRAND + ch + MODEL + ch + END_USE_OF_ITEM + ch + COUNTRY_OF_ORIGIN + ch + PRODUCT_CTH + ch + PREFERENTIAL + ch + PRODUCT_CETH + ch + PRODUCT_BCD_NOTN + ch + PRODUCT_BCD_SLNO + ch + PRODUCT_CVD_NOTN + ch + PRODUCT_CVD_SLNO + ch + PRODUCT_ADDL_GSI_NOTN + ch + PRODUCT_ADDL_GSI_SLNO + ch + PRODUCT_ADDL_SHEII_NOTN + ch + PRODUCT_ADDL_SHEII_SLNO + ch + PRODUCT_ADDL_TTA_NOTN + ch + PRODUCT_ADDL_TTA_SLNO + ch + PRODUCT_EDU_CESS_NOTN + ch + PRODUCT_EDU_CESS_NOTN_SL + ch + PRODUCT_CVD_EDU_CESS_RATE + ch + CETH_CVD_EDU_CESS_SL + ch + PRODUCT_NCD_NOTN + ch + PRODUCT_NCD_SLNO + ch + ANTI_DUMPING_NOTN + ch + ANTI_DUMPING_NOTN_SLNO + ch + CTH_SLNO + ch + CTH_SUPPLIER_SLNO + ch + CTH_QTY + ch + PRODUCT_TARIFF_NOTN + ch + PRODUCT_TARIFF_SLNO + ch + PRODUCT_TARIFF_QTY + ch + PRODUCT_SAPTA_NOTN + ch + PRODUCT_SAPTA_SLNO + ch + PRODUCT_ADDL_HEALTH_CESS_NOTN + ch + PRODUCT_ADDL_HEALTH_CESS_SLNO + ch + PRODUCT_ADDL_DUTY_NOTN + ch + PRODUCT_ADDL_DUTY_NOTN_SL + ch + PRODUCT_AGGREGATE_DUTY_NOTN + ch + PRODUCT_AGGREGATE_DUTY_NOTN_SL + ch + PRODUCT_SAFEGUARD_NOTN + ch + PRODUCT_SAFEGUARD_SLNO + ch + ITEM_UNIT_PRICE + ch + DISCOUNT_RATE + ch + DISCOUNT_AMOUNT + ch + CTH_QTY1 + ch + CTH_QTY2 + ch + ITEM_SVB_REF_NO + ch + ITEM_SVB_REF_DATE + ch + ITEM_SVB_ASSESABLE_RATE + ch + ITEM_SVB_DUTY_RATE + ch + ITEM_SVB_LOADING_ON + ch + ITEM_SVB_ASSESABLE_STATUS + ch + ITEM_SVB_DUTY_STATUS + ch + ITEM_SVB_CUSTOM_HOUSE + ch + POLICY_PARA_NO + ch + POLICY_YEAR + ch + RSP_APPLICABLE + ch + WHETHER_REIMPORT + ch + PREVIOUS_BE_NO + ch + PREVIOUS_BE_DATE + ch + PREVIOUS_UNITPRICE + ch + PREVIOUS_CURRENY + ch + PREVIOUS_CUSTOMS_HOUSE + ch + CENTRAL_EXCISE_FALG + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_COUNTRY + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS);

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_QTY + ch + ITEM_QTY_CODE + ch + CTH_NO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + SCHEME_CODE + ch + GENEARL_DESCRIPTION + ch + ACCESSORIES + ch + MANUFACTURER + ch + BRAND + ch + MODEL + ch + END_USE_OF_ITEM + ch + COUNTRY_OF_ORIGIN + ch + PRODUCT_CTH + ch + PREFERENTIAL + ch + PRODUCT_CETH + ch + PRODUCT_BCD_NOTN + ch + PRODUCT_BCD_SLNO + ch + PRODUCT_CVD_NOTN + ch + PRODUCT_CVD_SLNO + ch + PRODUCT_ADDL_GSI_NOTN + ch + PRODUCT_ADDL_GSI_SLNO + ch + PRODUCT_ADDL_SHEII_NOTN + ch + PRODUCT_ADDL_SHEII_SLNO + ch + PRODUCT_ADDL_TTA_NOTN + ch + PRODUCT_ADDL_TTA_SLNO + ch + PRODUCT_EDU_CESS_NOTN + ch + PRODUCT_EDU_CESS_NOTN_SL + ch + PRODUCT_CVD_EDU_CESS_RATE + ch + CETH_CVD_EDU_CESS_SL + ch + PRODUCT_NCD_NOTN + ch + PRODUCT_NCD_SLNO + ch + ANTI_DUMPING_NOTN + ch + ANTI_DUMPING_NOTN_SLNO + ch + CTH_SLNO + ch + CTH_SUPPLIER_SLNO + ch + CTH_QTY + ch + PRODUCT_TARIFF_NOTN + ch + PRODUCT_TARIFF_SLNO + ch + PRODUCT_TARIFF_QTY + ch + PRODUCT_SAPTA_NOTN + ch + PRODUCT_SAPTA_SLNO + ch + PRODUCT_ADDL_HEALTH_CESS_NOTN + ch + PRODUCT_ADDL_HEALTH_CESS_SLNO + ch + PRODUCT_ADDL_DUTY_NOTN + ch + PRODUCT_ADDL_DUTY_NOTN_SL + ch + PRODUCT_AGGREGATE_DUTY_NOTN + ch + PRODUCT_AGGREGATE_DUTY_NOTN_SL + ch + PRODUCT_SAFEGUARD_NOTN + ch + PRODUCT_SAFEGUARD_SLNO + ch + ITEM_UNIT_PRICE + ch + DISCOUNT_RATE + ch + DISCOUNT_AMOUNT + ch + CTH_QTY1 + ch + CTH_QTY2 + ch + ITEM_SVB_REF_NO + ch + ITEM_SVB_REF_DATE + ch + ITEM_SVB_ASSESABLE_RATE + ch + ITEM_SVB_DUTY_RATE + ch + ITEM_SVB_LOADING_ON + ch + ITEM_SVB_ASSESABLE_STATUS + ch + ITEM_SVB_DUTY_STATUS + ch + ITEM_SVB_CUSTOM_HOUSE + ch + POLICY_PARA_NO + ch + POLICY_YEAR + ch + RSP_APPLICABLE + ch + WHETHER_REIMPORT + ch + PREVIOUS_BE_NO + ch + PREVIOUS_BE_DATE + ch + UNIT_PRICE + ch + UNIT_CODE + ch + PREVIOUS_CUSTOMS_HOUSE + ch + CENTRAL_EXCISE_FALG + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_COUNTRY + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS);


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
                PORT_OF_LICENSE = dt.Trim(ds.Tables[3].Rows[k]["PORT_OF_LICENSE"].ToString()).ToUpper();


                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + LICENSE_ITEM_NO + ch + DEBIT_AMT + ch + DEBIT_QTY + ch + UNIT_QTY + ch + REGISTRATION_NO + ch + REGISTRATION_DATE + ch + SCHEME_CODE + ch + PORT_OF_LICENSE);
                k++;
            }
        }

        int m = 0;
        if (ds.Tables[2].Rows.Count > 0)
        {

            //val = "Y";//Hide by Chithra on 31/03/2018 - 
            //dr = ds.Tables[2].Select("PRODUCT_MRP_YN like '%" + val + "%'");

            val = "S";
            dr = ds.Tables[2].Select("RSP_APPLICABLE like '%" + val + "%'");


            if (dr.Length > 0)
            {
                sw.WriteLine("<TABLE>RSP");
                while (dr.Length > m)
                {
                    Is_val = dt.Trim(dr[m]["RSP_APPLICABLE"].ToString());
                    if (Is_val == val)
                    {


                        INVOICE_SLNO = dt.Trim(dr[m]["INVOICE_SLNO"].ToString());
                        ITEM_SLNO = dt.Trim(dr[m]["ITEM_SLNO"].ToString());
                        ITEM_QTY = dt.Trim(dr[m]["ITEM_QTY"].ToString());
                        //ITEM_DESCRIPTION = dt.Trim(dr[m]["ITEM_DESCRIPTION"].ToString());
                        ITEM_DESCRIPTION = dt.Trim(dr[m]["ITEM_DESCRIPTION"].ToString()).Replace(System.Environment.NewLine, " ");
                        // myString = myString.Replace(System.Environment.NewLine, "replacement text"); 

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

                        ITEM_DESCRIPTION = ITEM_DESCRIPTION.Length == 1 ? ITEM_DESCRIPTION : ITEM_DESCRIPTION.TrimEnd('.');

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + PRODUCT_MRP_SL_NO + ch + PRODUCT_MRP_AMOUNT + ch + ITEM_QTY + ch + ITEM_DESCRIPTION + ch + RSP_NOTN_NO + ch + RSP_NOTN_SL_NO);

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

        //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + Whether_Exemption + ch + SCHEME_NOTN + ch + SCHEME_NOTN_SLNO);
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
        //                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + Whether_Exemption + ch + SCHEME_NOTN + ch + SCHEME_NOTN_SLNO);
        //            }
        //            a++;
        //        }
        //    }
        //}


        int a = 0;
        int rowcnt = 0;

        if (ds.Tables[11].Rows.Count > 0)
        {
            while (ds.Tables[11].Rows.Count > a)
            {
                if (ds.Tables[11].Rows[a]["SCHEME_CODE"].ToString().Substring(0, 2) != "PI")
                {
                    if (ds.Tables[11].Rows[a]["SCHEME_CODE"].ToString().Substring(0, 2) != "14")
                    {
                        if (rowcnt == 0)
                        {
                            sw.WriteLine("<TABLE>DEPB");
                            rowcnt++;
                        }

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

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + EXCEMPTION + ch + SCHEME_NOTN + ch + SCHEME_NOTN_SLNO);
                    }
                }
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
                BOND_LOCATION = dt.Trim(ds.Tables[4].Rows[b]["BOND_LOCATION"].ToString()).ToUpper();

                if (BOND_LOCATION.Contains('-'))
                {
                    Str_Bond_Location = BOND_LOCATION.Split('-');

                    BOND_LOCATION = Str_Bond_Location[1].Trim();
                }

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + BOND_NO + ch + BOND_TYPE + ch + BOND_LOCATION);
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

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + CERTIFICATE_NO + ch + CERTIFICATE_DATE + ch + CERTIFICATE_TYPE);
                c++;
            }
        }

        if (HIGH_SEA_SALE == "Y")
        {
            if (BE_TYPE != "X")
            {
                sw.WriteLine("<TABLE>HSS");
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + HIGH_SEA_IEC + ch + HIGH_SEA_BRANCH_SL_NO + ch + HIGH_SEA_SALE_NAME + ch + HSS_ADD1 + ch + HSS_ADD2 + ch + HSS_ADD3_4 + ch + HSS_ADD5 + ch + PRECEDING_LEVEL);
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
                PORT_EXPORT = dt.Trim(ds.Tables[6].Rows[d]["PORT_EXPORT"].ToString()).ToUpper();
                SB_INVOICE_NO = dt.Trim(ds.Tables[6].Rows[d]["SB_INVOICE_NO"].ToString());
                SB_INVOICE__ITEM_NO = dt.Trim(ds.Tables[6].Rows[d]["SB_INVOICE__ITEM_NO"].ToString());
                NOTN_NO = dt.Trim(ds.Tables[6].Rows[d]["NOTN_NO"].ToString());
                NOTN_SLNO = dt.Trim(ds.Tables[6].Rows[d]["NOTN_SLNO"].ToString());
                EXPORT_FREIGHT = dt.Trim(ds.Tables[6].Rows[d]["EXPORT_FREIGHT"].ToString());
                EXPORT_INSURANCE = dt.Trim(ds.Tables[6].Rows[d]["EXPORT_INSURANCE"].ToString());

                CUSTOMS_DUTY = dt.Trim(ds.Tables[6].Rows[d]["CUSTOMS_DUTY"].ToString());
                EXCISE_DUTY = dt.Trim(ds.Tables[6].Rows[d]["EXCISE_DUTY"].ToString());


                if (NOTN_NO == "094/96" && NOTN_SLNO != "2")
                {
                    if (CUSTOMS_DUTY == "")
                    {
                        CUSTOMS_DUTY = "0";
                    }
                    if (EXCISE_DUTY == "")
                    {
                        EXCISE_DUTY = "0";
                    }
                }
                else if (NOTN_NO == "046/2017" && NOTN_SLNO == "5" || NOTN_SLNO == "1E")
                {
                    if (CUSTOMS_DUTY == "")
                    {
                        CUSTOMS_DUTY = "0";
                    }
                    if (EXCISE_DUTY == "")
                    {
                        EXCISE_DUTY = "0";
                    }
                }
                //else if (NOTN_NO == "045/2017" && NOTN_SLNO != "1A" || NOTN_SLNO != "2")
                else if (NOTN_NO == "045/2017" && (NOTN_SLNO != "1A" && NOTN_SLNO != "2" && NOTN_SLNO != "3"))
                {
                    if (CUSTOMS_DUTY == "")
                    {
                        CUSTOMS_DUTY = "0";
                    }
                    if (EXCISE_DUTY == "")
                    {
                        EXCISE_DUTY = "0";
                    }
                }


                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SB_NO + ch + SB_DATE + ch + PORT_EXPORT + ch + SB_INVOICE_NO + ch + SB_INVOICE__ITEM_NO + ch + NOTN_NO + ch + NOTN_SLNO + ch + EXPORT_FREIGHT + ch + EXPORT_INSURANCE + ch + CUSTOMS_DUTY + ch + EXCISE_DUTY);
                d++;
            }
        }


        int od = 0;
        DataView OD_view = ds.Tables[2].DefaultView;
        IGST_LEVY_NOTN = dt.Trim(ds.Tables[2].Rows[0]["IGST_LEVY_NOTN"].ToString());

        IGST_LEVY_COMPENSATION_CESS_NOTN = dt.Trim(ds.Tables[2].Rows[0]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString());

        //OD_view.RowFilter = "IGST_LEVY_NOTN = '" + IGST_LEVY_NOTN + "'";
        OD_view.RowFilter = "Isnull(IGST_LEVY_NOTN,'') <> ''";
        DataTable OD_table = OD_view.ToTable();

        if (OD_table.Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>SBEDUTY");
            while (OD_table.Rows.Count > od)
            {
                INVOICE_SLNO = dt.Trim(OD_table.Rows[od]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(OD_table.Rows[od]["ITEM_SLNO"].ToString());
                PRODUCT_CETH = dt.Trim(OD_table.Rows[od]["PRODUCT_CETH"].ToString());

                IGST_LEVY_NOTN = dt.Trim(OD_table.Rows[od]["IGST_LEVY_NOTN"].ToString());
                IGST_LEVY_SLNO = dt.Trim(OD_table.Rows[od]["IGST_LEVY_SLNO"].ToString());
                IGST_LEVY_RATE = dt.Trim(OD_table.Rows[od]["IGST_LEVY_RATE"].ToString());
                IGST_LEVY_SPL = dt.Trim(OD_table.Rows[od]["IGST_LEVY_SPL"].ToString());
                IGST_LEVY_UNIT = dt.Trim(OD_table.Rows[od]["IGST_LEVY_UNIT"].ToString());
                IGST_LEVY_SPL_TYPE = dt.Trim(OD_table.Rows[od]["IGST_LEVY_SPL_TYPE"].ToString());
                IGST_LEVY_EXCEPTION_NOTN = dt.Trim(OD_table.Rows[od]["IGST_LEVY_EXCEPTION_NOTN"].ToString());
                IGST_LEVY_EXCEPTION_SLNO = dt.Trim(OD_table.Rows[od]["IGST_LEVY_EXCEPTION_SLNO"].ToString());
                IGST_LEVY_EXCEPTION_RATE = dt.Trim(OD_table.Rows[od]["IGST_LEVY_EXCEPTION_RATE"].ToString());
                IGST_LEVY_COMPENSATION_CESS_NOTN = dt.Trim(OD_table.Rows[od]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString());
                IGST_LEVY_COMPENSATION_CESS_SLNO = dt.Trim(OD_table.Rows[od]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString());
                IGST_LEVY_COMPENSATION_CESS_RATE = dt.Trim(OD_table.Rows[od]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString());
                IGST_LEVY_COMPENSATION_CESS_SPL = dt.Trim(OD_table.Rows[od]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString());
                IGST_LEVY_COMPENSATION_CESS_UNIT = dt.Trim(OD_table.Rows[od]["IGST_LEVY_COMPENSATION_CESS_UNIT"].ToString());
                IGST_LEVY_COMPENSATION_CESS_SPL_TYPE = dt.Trim(OD_table.Rows[od]["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"].ToString());
                IGST_LEVY_EXCEPTION_CC_NOTN = dt.Trim(OD_table.Rows[od]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString());
                IGST_LEVY_EXCEPTION_CC_SLNO = dt.Trim(OD_table.Rows[od]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString());
                IGST_LEVY_EXCEPTION_CC_RATE = dt.Trim(OD_table.Rows[od]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString());

                LEVY_EXCEMPTION_NOTN_TYPE = dt.Trim(OD_table.Rows[od]["LEVY_EXCEMPTION_NOTN_TYPE"].ToString());
                LEVY_EXCEPTION_CC_NOTN_TYPE = dt.Trim(OD_table.Rows[od]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString());

                PRODUCT_OTHER_DUTY_NOTN = dt.Trim(OD_table.Rows[od]["PRODUCT_OTHER_DUTY_NOTN"].ToString());
                PRODUCT_OTHER_DUTY_SLNO = dt.Trim(OD_table.Rows[od]["PRODUCT_OTHER_DUTY_SLNO"].ToString());


                string Excep_Flag;
                if (IGST_LEVY_NOTN != "")
                {
                    if (IGST_LEVY_EXCEPTION_NOTN != "")
                    {
                        //if (IGST_LEVY_EXCEPTION_NOTN == "104/94" || IGST_LEVY_EXCEPTION_NOTN == "051/96" || IGST_LEVY_EXCEPTION_NOTN == "153/94")
                        //{
                        //    Excep_Flag = "C";
                        //}                       
                        //else
                        //{
                        //    Excep_Flag = "G";
                        //}

                        Excep_Flag = LEVY_EXCEMPTION_NOTN_TYPE;
                    }
                    else
                    {
                        Excep_Flag = "";
                    }


                    //if (IGST_LEVY_EXCEPTION_NOTN != "")
                    //{
                    //    Excep_Flag = "G";
                    //}
                    //else
                    //{
                    //    Excep_Flag = "";
                    //}

                    //G=E,I=X

                    //hide on 07-04-2026 for Notification No. 19/2025- Integrated Tax (Rate)  by Chithra sugg.by Bala sir
                    //if (PRODUCT_CETH != "24012010" && PRODUCT_CETH != "27090000" && PRODUCT_CETH != "27090010" && PRODUCT_CETH != "27090090" && PRODUCT_CETH != "27111100" && PRODUCT_CETH != "27101949" && PRODUCT_CETH != "27101241" && PRODUCT_CETH != "27101290" && PRODUCT_CETH != "24013000" && PRODUCT_CETH != "24012090" && PRODUCT_CETH != "24039100" && PRODUCT_CETH != "24012040" && PRODUCT_CETH != "24011090")
                    if (PRODUCT_CETH != "27090000" && PRODUCT_CETH != "27090010" && PRODUCT_CETH != "27090090" && PRODUCT_CETH != "27111100" && PRODUCT_CETH != "27101949" && PRODUCT_CETH != "27101241" && PRODUCT_CETH != "27101290")                    
                    {
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + IGST_LEVY_NOTN + ch + IGST_LEVY_SLNO + ch + "G" + ch + "I" + ch + IGST_LEVY_EXCEPTION_NOTN + ch + IGST_LEVY_EXCEPTION_SLNO + ch + Excep_Flag + ch + "" + ch + "" + ch + "");
                    }
                }
                if (IGST_LEVY_COMPENSATION_CESS_NOTN != "")
                {
                    if (IGST_LEVY_EXCEPTION_CC_NOTN != "")
                    {
                        //Excep_Flag = "G";
                        Excep_Flag = LEVY_EXCEPTION_CC_NOTN_TYPE;
                    }
                    else
                    {
                        Excep_Flag = "";
                    }

                    //hide on 12-02-2026 for below Tariff should not move IGST_LEVY_COMPENSATION_CESS_NOTN
                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + IGST_LEVY_COMPENSATION_CESS_NOTN + ch + IGST_LEVY_COMPENSATION_CESS_SLNO + ch + "G" + ch + "P" + ch + IGST_LEVY_EXCEPTION_CC_NOTN + ch + IGST_LEVY_EXCEPTION_CC_SLNO + ch + Excep_Flag + ch + "" + ch + "" + ch + "");

                    //hide on 07-04-2026 for Notification No. 19/2025- Integrated Tax (Rate)  by Chithra sugg.by Bala sir
                    //if (PRODUCT_CETH != "24012010" && PRODUCT_CETH != "27090000" && PRODUCT_CETH != "27090010" && PRODUCT_CETH != "27090090" && PRODUCT_CETH != "27111100" && PRODUCT_CETH != "27101949" && PRODUCT_CETH != "27101241" && PRODUCT_CETH != "27101290" && PRODUCT_CETH != "24013000" && PRODUCT_CETH != "24012090" && PRODUCT_CETH != "24039100" && PRODUCT_CETH != "24012040" && PRODUCT_CETH != "24011090")
                    if (PRODUCT_CETH != "27090000" && PRODUCT_CETH != "27090010" && PRODUCT_CETH != "27090090" && PRODUCT_CETH != "27111100" && PRODUCT_CETH != "27101949" && PRODUCT_CETH != "27101241" && PRODUCT_CETH != "27101290")                                        
                    {
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + IGST_LEVY_COMPENSATION_CESS_NOTN + ch + IGST_LEVY_COMPENSATION_CESS_SLNO + ch + "G" + ch + "P" + ch + IGST_LEVY_EXCEPTION_CC_NOTN + ch + IGST_LEVY_EXCEPTION_CC_SLNO + ch + Excep_Flag + ch + "" + ch + "" + ch + "");
                    }
                }

                if (PRODUCT_OTHER_DUTY_NOTN != "")
                {

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + PRODUCT_OTHER_DUTY_NOTN + ch + PRODUCT_OTHER_DUTY_SLNO + ch + "E" + ch + "X" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "");

                }
                od++;
            }
        }
        else
        {

            OD_view.RowFilter = "Isnull(IGST_LEVY_COMPENSATION_CESS_NOTN,'') <> ''";
            DataTable OD_table1 = OD_view.ToTable();

            if (OD_table1.Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>SBEDUTY");
                while (OD_table1.Rows.Count > od)
                {
                    INVOICE_SLNO = dt.Trim(OD_table1.Rows[od]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(OD_table1.Rows[od]["ITEM_SLNO"].ToString());

                    IGST_LEVY_NOTN = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_NOTN"].ToString());
                    IGST_LEVY_SLNO = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_SLNO"].ToString());
                    IGST_LEVY_RATE = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_RATE"].ToString());
                    IGST_LEVY_SPL = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_SPL"].ToString());
                    IGST_LEVY_UNIT = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_UNIT"].ToString());
                    IGST_LEVY_SPL_TYPE = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_SPL_TYPE"].ToString());
                    IGST_LEVY_EXCEPTION_NOTN = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_EXCEPTION_NOTN"].ToString());
                    IGST_LEVY_EXCEPTION_SLNO = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_EXCEPTION_SLNO"].ToString());
                    IGST_LEVY_EXCEPTION_RATE = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_EXCEPTION_RATE"].ToString());
                    IGST_LEVY_COMPENSATION_CESS_NOTN = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString());
                    IGST_LEVY_COMPENSATION_CESS_SLNO = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString());
                    IGST_LEVY_COMPENSATION_CESS_RATE = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString());
                    IGST_LEVY_COMPENSATION_CESS_SPL = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString());
                    IGST_LEVY_COMPENSATION_CESS_UNIT = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_COMPENSATION_CESS_UNIT"].ToString());
                    IGST_LEVY_COMPENSATION_CESS_SPL_TYPE = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"].ToString());
                    IGST_LEVY_EXCEPTION_CC_NOTN = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString());
                    IGST_LEVY_EXCEPTION_CC_SLNO = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString());
                    IGST_LEVY_EXCEPTION_CC_RATE = dt.Trim(OD_table1.Rows[od]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString());

                    LEVY_EXCEMPTION_NOTN_TYPE = dt.Trim(OD_table1.Rows[od]["LEVY_EXCEMPTION_NOTN_TYPE"].ToString());
                    LEVY_EXCEPTION_CC_NOTN_TYPE = dt.Trim(OD_table1.Rows[od]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString());


                    string Excep_Flag;
                    if (IGST_LEVY_NOTN != "")
                    {
                        if (IGST_LEVY_EXCEPTION_NOTN != "")
                        {
                            //if (IGST_LEVY_EXCEPTION_NOTN == "104/94" || IGST_LEVY_EXCEPTION_NOTN == "051/96" || IGST_LEVY_EXCEPTION_NOTN == "153/94")
                            //{
                            //    Excep_Flag = "C";
                            //}                            
                            //else
                            //{
                            //    Excep_Flag = "G";
                            //}

                            Excep_Flag = LEVY_EXCEMPTION_NOTN_TYPE;
                        }
                        else
                        {
                            Excep_Flag = "";
                        }


                        //if (IGST_LEVY_EXCEPTION_NOTN != "")
                        //{
                        //    Excep_Flag = "G";
                        //}
                        //else
                        //{
                        //    Excep_Flag = "";
                        //}
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + IGST_LEVY_NOTN + ch + IGST_LEVY_SLNO + ch + "G" + ch + "I" + ch + IGST_LEVY_EXCEPTION_NOTN + ch + IGST_LEVY_EXCEPTION_SLNO + ch + Excep_Flag + ch + "" + ch + "" + ch + "");
                    }
                    if (IGST_LEVY_COMPENSATION_CESS_NOTN != "")
                    {
                        if (IGST_LEVY_EXCEPTION_CC_NOTN != "")
                        {
                            //Excep_Flag = "G";
                            Excep_Flag = LEVY_EXCEPTION_CC_NOTN_TYPE;
                        }
                        else
                        {
                            Excep_Flag = "";
                        }
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + IGST_LEVY_COMPENSATION_CESS_NOTN + ch + IGST_LEVY_COMPENSATION_CESS_SLNO + ch + "G" + ch + "P" + ch + IGST_LEVY_EXCEPTION_CC_NOTN + ch + IGST_LEVY_EXCEPTION_CC_SLNO + ch + Excep_Flag + ch + "" + ch + "" + ch + "");

                    }
                    od++;
                }
            }
        }



        //------------------------------------ HEALTH CESS -----START----------------------------------------------
        int hc = 0;
        DataView HC_view = ds.Tables[2].DefaultView;
        PRODUCT_ADDL_HEALTH_CESS_NOTN = dt.Trim(ds.Tables[2].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString());

        HC_view.RowFilter = "Isnull(PRODUCT_ADDL_HEALTH_CESS_NOTN,'') <> ''";
        DataTable HC_table = HC_view.ToTable();

        if (HC_table.Rows.Count > 0)
        {
            if (od == 0)
            {
                sw.WriteLine("<TABLE>SBEDUTY");
            }
            while (HC_table.Rows.Count > hc)
            {
                INVOICE_SLNO = dt.Trim(HC_table.Rows[hc]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(HC_table.Rows[hc]["ITEM_SLNO"].ToString());

                IGST_LEVY_NOTN = dt.Trim(HC_table.Rows[hc]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString());
                IGST_LEVY_SLNO = dt.Trim(HC_table.Rows[hc]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString());

                IGST_LEVY_EXCEPTION_NOTN = "";
                IGST_LEVY_EXCEPTION_SLNO = "";

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + IGST_LEVY_NOTN + ch + IGST_LEVY_SLNO + ch + "C" + ch + "+" + ch + IGST_LEVY_EXCEPTION_NOTN + ch + IGST_LEVY_EXCEPTION_SLNO + ch + "" + ch + "" + ch + "" + ch + "");
                hc++;
            }
        }
        //------------------------------------ HEALTH CESS -----END----------------------------------------------


        //------------------------------------ AIDC -----START----------------------------------------------
        int Aid = 0;
        DataView AID_view = ds.Tables[2].DefaultView;
        AIDC_NOTN = dt.Trim(ds.Tables[2].Rows[0]["AIDC_NOTN"].ToString());

        AID_view.RowFilter = "Isnull(AIDC_NOTN,'') <> ''";
        DataTable AIDC_table = AID_view.ToTable();

        if (AIDC_table.Rows.Count > 0)
        {
            if (od == 0)
            {
                sw.WriteLine("<TABLE>SBEDUTY");
            }
            while (AIDC_table.Rows.Count > Aid)
            {
                INVOICE_SLNO = dt.Trim(AIDC_table.Rows[Aid]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(AIDC_table.Rows[Aid]["ITEM_SLNO"].ToString());

                IGST_LEVY_NOTN = dt.Trim(AIDC_table.Rows[Aid]["AIDC_NOTN"].ToString());
                IGST_LEVY_SLNO = dt.Trim(AIDC_table.Rows[Aid]["AIDC_NOTN_SLNO"].ToString());

                IGST_LEVY_EXCEPTION_NOTN = "";
                IGST_LEVY_EXCEPTION_SLNO = "";

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + IGST_LEVY_NOTN + ch + IGST_LEVY_SLNO + ch + "C" + ch + "A" + ch + IGST_LEVY_EXCEPTION_NOTN + ch + IGST_LEVY_EXCEPTION_SLNO + ch + "" + ch + "" + ch + "" + ch + "");

                //--------------- For Petrolium Items
                EXC_AIDC_NOTN = dt.Trim(AIDC_table.Rows[Aid]["EXC_AIDC_NOTN"].ToString());
                EXC_AIDC_NOTN_SLNO = dt.Trim(AIDC_table.Rows[Aid]["EXC_AIDC_NOTN_SLNO"].ToString());

                if (EXC_AIDC_NOTN != "")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + EXC_AIDC_NOTN + ch + EXC_AIDC_NOTN_SLNO + ch + "E" + ch + "A" + ch + IGST_LEVY_EXCEPTION_NOTN + ch + IGST_LEVY_EXCEPTION_SLNO + ch + "" + ch + "" + ch + "" + ch + "");
                }


                Aid++;
            }
        }
        //------------------------------------ AIDC -----END----------------------------------------------



        if (BE_TYPE == "X" || BE_TYPE == "T" || BE_TYPE == "J" || BE_TYPE == "R" || BE_TYPE == "E" || BE_TYPE == "D" || BE_TYPE == "V")
        {
            //No need to display IGM & Container when BE TYPE is EX-BOND & SEZ Trading & SEZ Manufacturing
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

                    if (COMPANY_ID == "247" || COMPANY_ID == "4")
                    {
                        if (TRANSPORT_MODE == "Air" || TRANSPORT_MODE == "A")
                        {
                            if (FILING_STATUS == "P" || FILING_STATUS == "A")
                            {
                                IGM_FLIGHT_VESSELDATE = "";
                            }
                        }
                    }

                    if (TRANSPORT_MODE == "Land" || TRANSPORT_MODE == "L")
                    {
                        IGM_GATEWAY_IGM_NO = dt.Trim(ds.Tables[7].Rows[f]["IGM_GATEWAY_IGM_NO"].ToString());
                        IGM_GATEWAY_IGM_DATE = dt.Trim(ds.Tables[7].Rows[f]["IGM_GATEWAY_IGM_DATE"].ToString().Replace("19000101", ""));
                        IGM_GATEWAY_PORT_CODE = dt.Trim(ds.Tables[7].Rows[f]["IGM_GATEWAY_PORT_CODE"].ToString()).ToUpper();

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
                    if (TRANSPORT_MODE == "Sea" || TRANSPORT_MODE == "S" || TRANSPORT_MODE == "Air" || TRANSPORT_MODE == "A")
                    {
                        IGM_GATEWAY_PORT_CODE = dt.Trim(ds.Tables[7].Rows[f]["IGM_GATEWAY_PORT_CODE"].ToString()).ToUpper();


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

                    IGM_MAWB_MBL = dt.Trim(ds.Tables[7].Rows[f]["IGM_MAWB_MBL"].ToString());
                    IGM_MAWB_MBLDATE = dt.Trim(ds.Tables[7].Rows[f]["IGM_MAWB_MBLDATE"].ToString().Replace("19000101", ""));
                    IGM_HAWB_HBLNO = dt.Trim(ds.Tables[7].Rows[f]["IGM_HAWB_HBLNO"].ToString());
                    IGM_HAWB_HBLDATE = dt.Trim(ds.Tables[7].Rows[f]["IGM_HAWB_HBLDATE"].ToString().Replace("19000101", ""));
                    IGM_NOOFPACKAGE = dt.Trim(ds.Tables[7].Rows[f]["IGM_NOOFPACKAGE"].ToString());

                    IGM_GROSSWEIGHT = dt.Trim(ds.Tables[7].Rows[f]["IGM_GROSSWEIGHT"].ToString());
                    IGM_TYPEOFWEIGHT = dt.Trim(ds.Tables[7].Rows[f]["IGM_TYPEOFWEIGHT"].ToString());
                    IGM_PACKAGETYPE = dt.Trim(ds.Tables[7].Rows[f]["IGM_PACKAGETYPE"].ToString());

                    IGM_MARKSNOS1 = dt.Trim(ds.Tables[7].Rows[f]["IGM_MARKSNOS1"].ToString().Replace("\r\n", ""));
                    IGM_MARKSNOS2 = dt.Trim(ds.Tables[7].Rows[f]["IGM_MARKSNOS2"].ToString().Replace("\r\n", ""));
                    IGM_MARKSNOS3 = dt.Trim(ds.Tables[7].Rows[f]["IGM_MARKSNOS3"].ToString().Replace("\r\n", ""));


                    IGM_MAWB_MBL = IGM_MAWB_MBL.Length == 1 ? IGM_MAWB_MBL : IGM_MAWB_MBL.TrimEnd('.');
                    IGM_HAWB_HBLNO = IGM_HAWB_HBLNO.Length == 1 ? IGM_HAWB_HBLNO : IGM_HAWB_HBLNO.TrimEnd('.');
                    IGM_MARKSNOS1 = IGM_MARKSNOS1.Length == 1 ? IGM_MARKSNOS1 : IGM_MARKSNOS1.TrimEnd('.');
                    IGM_MARKSNOS2 = IGM_MARKSNOS2.Length == 1 ? IGM_MARKSNOS2 : IGM_MARKSNOS2.TrimEnd('.');
                    IGM_MARKSNOS3 = IGM_MARKSNOS3.Length == 1 ? IGM_MARKSNOS3 : IGM_MARKSNOS3.TrimEnd('.');

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + IGM_NO + ch + IGM_DATE + ch + IGM_FLIGHT_VESSELDATE + ch + IGM_GATEWAY_IGM_NO + ch + IGM_GATEWAY_IGM_DATE + ch + IGM_GATEWAY_PORT_CODE + ch + IGM_MAWB_MBL + ch + IGM_MAWB_MBLDATE + ch + IGM_HAWB_HBLNO + ch + IGM_HAWB_HBLDATE + ch + IGM_NOOFPACKAGE + ch + IGM_GROSSWEIGHT + ch + IGM_TYPEOFWEIGHT + ch + IGM_PACKAGETYPE + ch + IGM_MARKSNOS1 + ch + IGM_MARKSNOS2 + ch + IGM_MARKSNOS3);
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
                        if (TRANSPORT_MODE == "Sea" || TRANSPORT_MODE == "S" || TRANSPORT_MODE == "Land" || TRANSPORT_MODE == "L")
                        {
                            CONTAINER_IGM_NO = "";
                        }
                    }
                    if (FILING_STATUS == "Y")
                    {
                        if (TRANSPORT_MODE == "Land" || TRANSPORT_MODE == "L")
                        {
                            if (BE_TYPE != "Z")
                            {
                                CONTAINER_IGM_NO = "";
                            }
                        }
                    }

                    SEAL_NO = SEAL_NO.Length == 1 ? SEAL_NO : SEAL_NO.TrimEnd('.');

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + CONTAINER_IGM_NO + ch + CONTAINER_IGM_DATE + ch + FCL_OR_LCL + ch + CONTAINER_NO + ch + SEAL_NO + ch + TRUCK_NO);
                    g++;
                }
            }
        }


        if (COMMERCIAL_DETAILS_STATUS == "Y")
        {
            sw.WriteLine("<TABLE>CTX");
            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + COMMERCIAL_TAX_STATECODE + ch + COMMERCIAL_TAX_TYPE + ch + COMMERCIAL_TAX_REGISTRATION_NO);
        }


        //---------------Single Window Process Live--------------------//



        DataView sw_type = ds.Tables[12].DefaultView;

        sw_type = ds.Tables[12].DefaultView;
        //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
        sw_type.RowFilter = "Isnull(INFO_TYPE,'') <> ''";

        DataSet ds_type = new DataSet();
        ds_type.Tables.Add(sw_type.ToTable());
        int sw_sez_yn = 0;
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

                if (INFO_TYPE != "")
                {
                    /*
                    if (Connection.COMPANYID() == "660" || Connection.COMPANYID() == "1636" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4")
                    {
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                    }
                    else
                    {
                        if (dt.Trim(ds_type.Tables[0].Rows[sws_type]["DEPARTMENT"].ToString()) != "FTA" || BE_TYPE != "X")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                        }
                    }
                     * */

                    string impExp = Session["IMP_EXP_TYPE"].ToString();
                    bool isTradingType = (impExp == "TRADING" || impExp == "MANUFATURED GOODS" || impExp == "CBW");
                    int sw_SEZ = 0;
                    if (isTradingType)
                    {
                        if (INFO_TYPE == "SEZ" && INFO_QUALIFIER == "CBW")
                        {
                            sw_SEZ = 1;
                        }
                    }

                    if (Connection.Get_User_Imp_Settings_Job_Edit("FF_FTA_EXBOND") == "E")
                    {
                        if (sw_SEZ == 1)
                        {
                            if (sw_sez_yn == 0)
                                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + "0" + ch + "0" + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                            sw_sez_yn = 1;
                        }
                        else
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                        }
                    }
                    else
                    {
                        //if (dt.Trim(ds_type.Tables[0].Rows[sws_type]["DEPARTMENT"].ToString()) != "FTA" || BE_TYPE != "X")
                        //{
                        //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                        //}

                        if (BE_TYPE == "X")
                        {
                            if ((dt.Trim(ds_type.Tables[0].Rows[sws_type]["DEPARTMENT"].ToString()) == "FTA") || (dt.Trim(ds_type.Tables[0].Rows[sws_type]["DEPARTMENT"].ToString()) == "SIMS"))
                            {
                                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                            }
                            else if (INFO_TYPE == "CHR" && INFO_QUALIFIER == "SQC")
                            {
                                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                            }
                        }
                        else if (BE_TYPE == "W" || BE_TYPE == "Z" || BE_TYPE == "T" || BE_TYPE == "SEZ DTA-M" || BE_TYPE == "Jobbing" || BE_TYPE == "Repair & Return" || BE_TYPE == "Exhibition" || BE_TYPE == "Destruction" || BE_TYPE == "Movement of Goods" || BE_TYPE == "Stock Item")
                        {
                            if (sw_SEZ == 1)
                            {
                                if (sw_sez_yn == 0)
                                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + "0" + ch + "0" + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                                sw_sez_yn = 1;
                            }
                            else
                            {
                                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                            }
                        }
                        else
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                        }
                    }

                }
                sws_type++;
            }
        }


            DataView sw_const = ds.Tables[13].DefaultView;

            sw_const = ds.Tables[13].DefaultView;
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

                    CONSTITUENT_ELEMENT_NAME = CONSTITUENT_ELEMENT_NAME.Length == 1 ? CONSTITUENT_ELEMENT_NAME : CONSTITUENT_ELEMENT_NAME.TrimEnd('.');

                    if (CONSTITUENT_SRNO != "")
                    {

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONSTITUENT_SRNO + ch + CONSTITUENT_ELEMENT_NAME + ch + CONSTITUENT_ELEMENT_CODE + ch + CONSTITUENT_PERCENTAGE + ch + CONSTITUENT_YIELD_PERCENTAGE + ch + ACTIVE_INGREDIENT);
                    }
                    sws_const++;
                }
            }

            DataView sw_prod = ds.Tables[14].DefaultView;

            sw_prod = ds.Tables[14].DefaultView;
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

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + PRODUCTION_BATCH_IDENTIFIER + ch + PRODUCTION_BATCH_QUANTITY + ch + UNIT_QTY_CODE + ch + DATE_OF_MANUFACTURING + ch + DATE_OF_EXPIRY + ch + BEST_BEFORE);
                    }
                    sws_prod++;
                }
            }


            DataView sw_ctrl = ds.Tables[15].DefaultView;

            sw_ctrl = ds.Tables[15].DefaultView;
            //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";

            //sw_ctrl.RowFilter = "Isnull(CONTROL_TYPE_CODE,'') <> ''";

            sw_ctrl.RowFilter = "Isnull(CONTROL_TYPE_CODE,'') <> '' or Isnull(CONTROL_RESULT_CODE,'') <> ''";

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

                    if (CONTROL_TYPE_CODE != "" || CONTROL_RESULT_CODE != "")
                    {
                        //THIS line hide on 17-09-2020 for Icegate New Impelmntn 3 fileds added - by Chithra
                        //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONTROL_TYPE_CODE + ch + CONTROL_LOCATION + ch + CONTROL_START_DATE + ch + CONTROL_END_DATE + ch + CONTROL_RESULT_CODE + ch + CONTROL_RESULT_TEXT);
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONTROL_TYPE_CODE + ch + CONTROL_LOCATION + ch + CONTROL_START_DATE + ch + CONTROL_END_DATE + ch + CONTROL_RESULT_CODE + ch + CONTROL_RESULT_TEXT + ch + CONTROL_MSR + ch + CONTROL_UQC + ch + CONTROL_SLNO);
                    }

                    sws_ctrl++;
                }
            }

            if (BE_TYPE != "V")
            {

            DataView sw_stmt = ds.Tables[16].DefaultView;

            sw_stmt = ds.Tables[16].DefaultView;
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
                    STMT_TEXT = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_TEXT"].ToString().Replace("\r\n", " ").Replace("–", "").Replace("•", ""));

                    STMT_TEXT = STMT_TEXT.Length == 1 ? STMT_TEXT : STMT_TEXT.TrimEnd('.');

                    if (STMT_TYPE != "REM")// implmnetd on 26-01-2021 
                    {
                        STMT_TEXT = "";
                    }

                    /*
                    if (Connection.COMPANYID() == "648")//SUNSHINE
                    {
                        STMT_TEXT = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_TEXT"].ToString().Replace("\r\n", " ").Replace("–", "").Replace("•", ""));
                    }
                    */


                    if (Connection.Get_User_Imp_Settings_Job_Edit("FF_STMT_TEXT") == "E")
                    {
                        STMT_TEXT = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_TEXT"].ToString().Replace("\r\n", " ").Replace("–", "").Replace("•", ""));
                    }

                    STMT_DECLARATION_TYPE = "B";

                    if (STMT_CODE == "CUG00" || STMT_CODE == "CUG01")
                    {
                        INVOICE_SLNO = "0";
                        ITEM_SLNO = "0";
                    }
                    if (STMT_CODE == "CUV01" || STMT_CODE == "CUV02" || STMT_CODE == "CUV03")
                    {
                        ITEM_SLNO = "0";
                    }

                    if (STMT_TYPE != "")
                    {
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + STMT_DECLARATION_TYPE + ch + STMT_DECLARATION_NUMBER + ch + STMT_DECLARATION_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                    }

                    sws_stmt++;
                }
            }

            //if (BE_TYPE != "X")
            //{

            DataView sw_supp = ds.Tables[17].DefaultView;

            sw_supp = ds.Tables[17].DefaultView;
            //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
            sw_supp.RowFilter = "Isnull(IMAGE_REF_NUMBER,'') <> ''";

            DataSet ds_supp = new DataSet();
            ds_supp.Tables.Add(sw_supp.ToTable());

            if (ds_supp.Tables[0].Rows.Count > 0)
            {
                int sws_supp = 0;
                sw.WriteLine("<TABLE>SUPPORTINGDOCS");
                while (ds_supp.Tables[0].Rows.Count > sws_supp)
                {

                    //INVOICE_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["INVOICE_SLNO"].ToString());
                    //ITEM_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ITEM_SLNO"].ToString());


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


                    IMAGE_REF_NUMBER = IMAGE_REF_NUMBER.Length == 1 ? IMAGE_REF_NUMBER : IMAGE_REF_NUMBER.TrimEnd('.');
                    DOC_ISSUING_PARTY_CODE = DOC_ISSUING_PARTY_CODE.Length == 1 ? DOC_ISSUING_PARTY_CODE : DOC_ISSUING_PARTY_CODE.TrimEnd('.');
                    DOC_ISSUING_PARTY_NAME = DOC_ISSUING_PARTY_NAME.Length == 1 ? DOC_ISSUING_PARTY_NAME : DOC_ISSUING_PARTY_NAME.TrimEnd('.');
                    DOC_ISSUING_PARTY_NAME_ADD1 = DOC_ISSUING_PARTY_NAME_ADD1.Length == 1 ? DOC_ISSUING_PARTY_NAME_ADD1 : DOC_ISSUING_PARTY_NAME_ADD1.TrimEnd('.');
                    DOC_ISSUING_PARTY_NAME_ADD2 = DOC_ISSUING_PARTY_NAME_ADD2.Length == 1 ? DOC_ISSUING_PARTY_NAME_ADD2 : DOC_ISSUING_PARTY_NAME_ADD2.TrimEnd('.');
                    DOC_ISSUING_PARTY_CITY = DOC_ISSUING_PARTY_CITY.Length == 1 ? DOC_ISSUING_PARTY_CITY : DOC_ISSUING_PARTY_CITY.TrimEnd('.');
                    DOC_ISSUING_PARTY_PIN = DOC_ISSUING_PARTY_PIN.Length == 1 ? DOC_ISSUING_PARTY_PIN : DOC_ISSUING_PARTY_PIN.TrimEnd('.');
                    DOC_REF_NUMBER = DOC_REF_NUMBER.Length == 1 ? DOC_REF_NUMBER : DOC_REF_NUMBER.TrimEnd('.');
                    PLACE_OF_ISSUE = PLACE_OF_ISSUE.Length == 1 ? PLACE_OF_ISSUE : PLACE_OF_ISSUE.TrimEnd('.');
                    BENEFICIARY_PARTY_CODE = BENEFICIARY_PARTY_CODE.Length == 1 ? BENEFICIARY_PARTY_CODE : BENEFICIARY_PARTY_CODE.TrimEnd('.');
                    BENEFICIARY_PARTY_NAME = BENEFICIARY_PARTY_NAME.Length == 1 ? BENEFICIARY_PARTY_NAME : BENEFICIARY_PARTY_NAME.TrimEnd('.');
                    BENEFICIARY_PARTY_ADDRESS1 = BENEFICIARY_PARTY_ADDRESS1.Length == 1 ? BENEFICIARY_PARTY_ADDRESS1 : BENEFICIARY_PARTY_ADDRESS1.TrimEnd('.');
                    BENEFICIARY_PARTY_ADDRESS2 = BENEFICIARY_PARTY_ADDRESS2.Length == 1 ? BENEFICIARY_PARTY_ADDRESS2 : BENEFICIARY_PARTY_ADDRESS2.TrimEnd('.');
                    BENEFICIARY_PARTY_CITY = BENEFICIARY_PARTY_CITY.Length == 1 ? BENEFICIARY_PARTY_CITY : BENEFICIARY_PARTY_CITY.TrimEnd('.');
                    BENEFICIARY_PARTY_PIN = BENEFICIARY_PARTY_PIN.Length == 1 ? BENEFICIARY_PARTY_PIN : BENEFICIARY_PARTY_PIN.TrimEnd('.');
                    ICEGATE_ID = ICEGATE_ID.Length == 1 ? ICEGATE_ID : ICEGATE_ID.TrimEnd('.');
                    FILE_TYPE = FILE_TYPE.Length == 1 ? FILE_TYPE : FILE_TYPE.TrimEnd('.');


                    if (SUP_DOC_ICEGATE_ID == "")
                    {
                        SUP_DOC_ICEGATE_ID = ICEGATE_ID;
                    }


                    if (DECLARATION_TYPE != "")
                    {
                        //CHA_NO = ""; IEC_NO = "";

                        //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + DECLARATION_TYPE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CHA_NO + ch + IEC_NO + ch + ICEGATE_ID + ch + IMAGE_REF_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_NAME + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE);
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + BE_NO + ch + BE_DATE + ch + DECLARATION_TYPE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CHA_NO + ch + IEC_NO + ch + SUP_DOC_ICEGATE_ID + ch + IMAGE_REF_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_NAME + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE);
                    }

                    sws_supp++;
                }
            }
        }


        //---------------Single Window Process--------------------//

        sw.WriteLine("<END-BE>");
        sw.WriteLine("TREC" + ch + JOBNO);
        //sw.WriteLine();
        //sw.Write("/n");

        DateTime dat = System.DateTime.Now;
        string datestring = string.Format("{0:dd/MM/yyyy}", dat);

        sw.Close();
        sw.Dispose();


        //Query Reply flatfile auto save to Job History folder also for Agility by Chitha
        if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
        {
            DataSet ds_jb_hstry = new DataSet();

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


                Job_Histroy jh = new Job_Histroy();

                jh.JOB_ID = "";
                jh.JOB_TYPE = "IMP";
                jh.JOBNO = JOBNO;
                jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
                jh.DESCRIPTION = targetPath;
                jh.ATTACHMENT_FILE = JOBNO + " ~~" + logFileName;
                jh.FLAG = "Upload_File";
                jh.USER_ID = currentuser;
                jh.JOBDATE = "01/01/1900";

                jh.BRANCH_CODE = currentbranch;
                jh.YEAR = "";
                jh.WORKING_PERIOD = Working_Period;
                jh.BRANCH_COMMON = SELECT_BRANCH;
                ds_jb_hstry = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();

            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }



        if (IS_Imgbtn == "1")
        {
            Response.Write(sw.ToString());
            Response.Flush();
            // Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        DSC_Flatfile_Sent_Check();

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

        //msg.Attachments.Add(new Attachment(filenm));

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
        string select_branch = "", Working_Period = "", txtCustomHouse = "",
               txtImporterName = "",
               txtBE_Type = "",
               txtSupplier = "",
               txtNoofItems = "",
               txtNoofInvoices = "",
               txt_IcegateId = "",
               BEType = "";


        try
        {
            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
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


                if (ds.Tables[8].Rows.Count > 0)
                {
                    BEType = HttpContext.Current.Session["BE_TYPE"].ToString();
                    if (BEType == "SEZ FTA-Z" || BEType == "SEZ DTA-T" || BEType == "SEZ DTA-M"
                                         || BEType == "Jobbing" || BEType == "Repair & Return" || BEType == "Exhibition" || BEType == "Destruction" || BEType == "Movement of Goods")
                    {
                        if (ds.Tables[8].Rows[0]["SEZ_ICEGATE_ID"].ToString() != "")
                        {
                            txt_IcegateId = ds.Tables[8].Rows[0]["SEZ_ICEGATE_ID"].ToString();
                        }
                    }
                }


                /*hide on 25-06-2024
                //General_Details Import_General = new General_Details();
                //Import_General.Retrieve_GetGeneral(custid);
                */
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
        custid = txtCustomHouse + "~~" + txtImporterName + "~~" + txtBE_Type + "~~" + txtSupplier + "~~" + txtNoofItems + "~~" + txtNoofInvoices + "~~" + txt_IcegateId;

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Path_details(string Folder_path, string branch_common)
    {
        //DSC_Insert_update
        string Branch = string.Empty;
        string userid = string.Empty;

        Branch = HttpContext.Current.Session["currentbranch"].ToString();
        userid = HttpContext.Current.Session["currentuser"].ToString();

        IMP_EXP_DSC IED = new IMP_EXP_DSC();
        IED.FILE_PATH = Folder_path;
        IED.IMP_EXP = "I";
        IED.BRANCH_CODE = Branch;
        IED.BRANCH_COMMON = branch_common;
        IED.USER_ID = userid;
        IED.FLAG = "S";
        IED.DSC_Insert_update();
        return "Save Successfully";
    }


    /*
    private void Load_Path()
    {
    IMP_EXP_DSC IED = new IMP_EXP_DSC();
    DataSet ds_d=new DataSet();
    IED.IMP_EXP = "I";
    IED.BRANCH_COMMON = SELECT_BRANCH;
    IED.USER_ID = currentuser;
    IED.FLAG = "";
    ds_d= IED.DSC_Insert_update();
    if(ds_d.Tables[0].Rows.Count>0)
    {
        txt_Download_path.Text = ds_d.Tables[0].Rows[0]["FILE_PATH"].ToString();
    }

    }
    
    protected void btnShow_Click(object sender, EventArgs e)
    {
    MP_DSC.Show();
    txt_path.Text = txt_Download_path.Text;
    }*/

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
                if (e.Row.Cells[i].Text == "F")
                {
                    e.Row.Cells[i].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[i].Font.Bold = true;
                }

            }

        }
    }
    protected void btnsend_Queue_Click(object sender, EventArgs e)
    {
        try
        {
            //DSC_FLATFILE_INSERT_UPDATE
            string SQ_Path = string.Empty;
            //if (SELECT_BRANCH != string.Empty)
            //{
            //    SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "IMP" + "/"
            //        +
            //        Session["currentbranch"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
            //        + "/");
            //}
            //else
            //{
            //    SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" +"IMP"+ "/");
            //}


            string SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            if (SELECT_TYPE == "Branchwise Job")
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + COMPANY_ID + "/" + "IMP" + "/"
                +
                Session["currentbranch"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                + "/");
            }
            else if (SELECT_TYPE == "Areawise Job")
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + COMPANY_ID + "/" + "IMP" + "/"
                +
                Session["GroupName"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                + "/");
            }

            else
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + COMPANY_ID + "/" + "IMP" + "/");
            }


            if (Directory.Exists(SQ_Path) == false)
            {
                Directory.CreateDirectory(SQ_Path);
            }
            Flatfile_gen();
            Flat_File("SQ", SQ_Path);
            Json_generation("SQ", SQ_Path);

            DateTime date = System.DateTime.Now;
            string datestringg = string.Format("{0:yyyyMMdd}", date);
            DateTime tt = System.DateTime.Now;
            string time = string.Format("{0:hhmm}", tt);
            GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
            string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();


            int i = 0;

            logFileName = ddlJobNo.SelectedValue.ToString() + yy + ".be";
            ObjUBO.File_Type = "I";
            ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
            ObjUBO.ITEM_DESCRIPTION = SQ_Path + logFileName;
            ObjUBO.Select_Item = "";
            if (btnsend_Queue.Text == "Send_Queue")
            {
                ObjUBO.flag = "S";
            }
            else
            {
                ObjUBO.flag = "U";
            }

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            url = url.Substring(0, url.IndexOf("FlatFile")) + SQ_Path.Substring(SQ_Path.IndexOf("FlatFile"), SQ_Path.Length - (SQ_Path.IndexOf("FlatFile"))) + logFileName;
            ObjUBO.ADDRESS1 = url.Replace(@"\", @"/");


            if (Connection.COMPANYID() == "747" || Connection.COMPANYID() == "2145")
            {
                //D:\ERoyalImpex_Final_New_New\Submission\747\CHENNAI-CHN\IMP_Job_history //17 ~~172020Signed
                path = ""; logFileName = "";
                path = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/" + Session["GroupName"].ToString() + "/IMP_Job_history" + "/");
                logFileName = ddlJobNo.SelectedValue.ToString() + " ~~" + ddlJobNo.SelectedValue.ToString() + yy + "Signed.be";
                System.IO.FileInfo fi = new System.IO.FileInfo(path + logFileName);
                try
                {
                    if (fi.Exists == true)
                    {
                        fi.Delete();
                    }
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }
            }


            i = IV.DSC_Flatfile_DML(ObjUBO);

            DSC_Flatfile_Sent_Check();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void DSC_Flatfile_Sent_Check()
    {
        //DSC_FLATFILE_SELECT
        DataSet ds = new DataSet();

        ObjUBO.File_Type = "I";
        ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
        ObjUBO.flag = "Flatfile_Sent_Status";
        ds = IV.DSC_Flatfile_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnsend_Queue.Text = "Resend_Queue";
            lblsent_date.Text = "FlatFile Sent Queue Dt : " + ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            btnsend_Queue.Text = "Send_Queue";
            lblsent_date.Text = string.Empty;
        }
    }

    protected void btn_Auto_Spl_Char_Click(object sender, EventArgs e)
    {
        if (ddlJobNo.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            IV.Jobno = ddlJobNo.SelectedValue.ToString();
            IV.Flag = "IMP_SPL_CHAR_Auto_Remove";
            IV.Branch_Type = SELECT_BRANCH;
            ds = IV.IMP_Data_Select();
        }
    }


    public Tuple<decimal, decimal, decimal, DataTable> ReadTotAssVal_Dynamically()
    {
        string pdfPath = GetBE_FirstPagePdfPath();

        if (string.IsNullOrEmpty(pdfPath))
            return Tuple.Create(0m, 0m, 0m, new DataTable());

        string excelPath = ConvertPDFToExcel_FromPath(pdfPath);

        return GetTotAssVal_FromExcel(excelPath);
    }


    
    private string GetBE_FirstPagePdfPath()
    {
        try
        {
            DataSet ds = new DataSet();

            Job_Histroy jh = new Job_Histroy();
            jh.JOBNO = Request["jobno"].ToString();
            jh.FLAG = "Select_pdf";
            jh.BRANCH_CODE = SELECT_BRANCH;
            jh.JOB_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString(); // Request["type"].ToString();

            ds = jh.Job_History_Details();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;

            DataRow dr = ds.Tables[0].Rows[0];

            if (!ds.Tables[0].Columns.Contains("MailSubject"))
                return null;

            string pdfFileName = dr["MailSubject"].ToString().Trim();

            if (string.IsNullOrEmpty(pdfFileName))
                return null;
            if (!pdfFileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                pdfFileName += ".pdf";

            string folderPath = HttpContext.Current.Server.MapPath(
                "~/Submission/" +
                HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" +
                Session["GroupName"].ToString() + "/" +
                "Attachments/"
            );

            if (!Directory.Exists(folderPath))
                return null;

            string fullPath = Path.Combine(folderPath, pdfFileName);

            //if (File.Exists(fullPath))
            //    return fullPath;

            return fullPath;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    private string ConvertPDFToExcel_FromPath(string pdfPath)
    {
   
        string outputFolder = HttpContext.Current.Server.MapPath(
              "~/Submission/" +
              HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" +
              Session["GroupName"].ToString() + "/" +
              "Output/");

        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);
        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pdfPath);
        string excelPath = Path.Combine(
            outputFolder,
            fileNameWithoutExt + ".xlsx"
        );

        if (File.Exists(excelPath))
            File.Delete(excelPath);

        Document pdfDocument = new Document(pdfPath);

        ExcelSaveOptions options = new ExcelSaveOptions
        {
            Format = ExcelSaveOptions.ExcelFormat.XLSX
        };

        pdfDocument.Save(excelPath, options);

        return excelPath;
    }




    private Tuple<decimal, decimal, decimal, DataTable> GetTotAssVal_FromExcel(string excelPath)
    {
        decimal totalDuty = 0;
        decimal totalAssessableValue = 0;

        decimal totaldebitValue = 0;

        bool dutyFound = false;
        bool assessFound = false;

        bool debitFound = false;

        DataTable Bond_Details = new DataTable();
        Bond_Details.Columns.Add("BOND_NO");
        Bond_Details.Columns.Add("PORT");
        Bond_Details.Columns.Add("DEBIT_AMT");

        string connString =
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + excelPath + ";" +
            "Extended Properties=\"Excel 12.0 Xml;HDR=No;IMEX=1\"";

        using (OleDbConnection conn = new OleDbConnection(connString))
        {
            conn.Open();

            DataTable schema =
                conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string sheetName = string.Empty;
            foreach (DataRow r in schema.Rows)
            {
                string name = r["TABLE_NAME"].ToString();
                if (name.EndsWith("$") && !name.Contains("Print_Area"))
                {
                    sheetName = name;
                    break;
                }
            }

            if (string.IsNullOrEmpty(sheetName))
                return Tuple.Create(0m, 0m, 0m, new DataTable());

            DataTable dt = new DataTable();
            using (OleDbDataAdapter da =
                new OleDbDataAdapter("SELECT * FROM [" + sheetName + "]", conn))
            {
                da.Fill(dt);
            }

            for (int r = 18; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    string cellText = dt.Rows[r][c].ToString();

                    if (!dutyFound && r >= 19 && c >= 5 &&
                        cellText.Contains("14.TOTAL DUTY"))
                    {
                        if (r + 1 < dt.Rows.Count)
                        {
                            string val = dt.Rows[r + 1][c]
                                .ToString()
                                .Replace(",", "");

                            decimal.TryParse(val, out totalDuty);
                            dutyFound = true;
                        }
                    }

                    if (!assessFound && r >= 18 && c >= 10 &&
                        cellText.Contains("18.TOT.ASS VAL"))
                    {
                        if (r + 1 < dt.Rows.Count)
                        {
                            string val = dt.Rows[r + 1][c]
                                .ToString()
                                .Replace(",", "");

                            decimal.TryParse(val, out totalAssessableValue);
                            assessFound = true;
                        }
                    }

                      if (r >= 25 && c >= 0 && cellText.Contains("1.BOND NO."))
                    {
                        int startRow = r + 1;
                        for (int i = startRow; i < dt.Rows.Count; i++)
                        {
                            string stopText = dt.Rows[i][c].ToString();

                            // 🔴 Stop when WBE NO found
                            if (stopText.Contains("1.WBE NO."))
                                break;

                            string bondNo = dt.Rows[i][c].ToString().Replace(",", "");
                            string port = dt.Rows[i][c + 2].ToString().Replace(",", "");
                            string debitAmt = dt.Rows[i][c + 4].ToString().Replace(",", "");

                            if (!string.IsNullOrWhiteSpace(bondNo))
                            {
                                Bond_Details.Rows.Add(bondNo, port, debitAmt);

                                decimal amt = 0;
                                decimal.TryParse(debitAmt, out amt);
                                totaldebitValue += amt;
                            }
                        }

                        debitFound = true;
                    }

                      if (dutyFound && assessFound && debitFound)
                        break;
                }

                if (dutyFound && assessFound && debitFound)
                    break;
            }
        }

        return Tuple.Create(totalDuty, totalAssessableValue, totaldebitValue, Bond_Details);
    }
    public void DutyandAssesableValueChecking()
    {
        decimal dbAssessable = 0;
        decimal ocrAssessable = 0;
        decimal ocrDuty = 0;

        decimal bondamount = 0;
        //decimal dbbondamount = 0;
        DataTable bonddetails;

        try
        {
            string pdfPath = GetBE_FirstPagePdfPath();

            if (string.IsNullOrEmpty(pdfPath))
            {
                assessMainBlock.Style["display"] = "none";
                dutyMainBlock.Style["display"] = "none";
                bondMainBlock.Style["display"] = "none";
                return;
            }

            var ocrValues = ReadTotAssVal_Dynamically();

            ocrDuty = ocrValues.Item1;
            ocrAssessable = ocrValues.Item2;
            bondamount = ocrValues.Item3;
            bonddetails = ocrValues.Item4;

            if (ocrAssessable <= 0)
            {
                assessMainBlock.Style["display"] = "none";
                dutyMainBlock.Style["display"] = "none";
                bondMainBlock.Style["display"] = "none";
                return;
            }

            assessMainBlock.Style["display"] = "block";
            dutyMainBlock.Style["display"] = "block";
            bondMainBlock.Style["display"] = "block";

            Transaction Transact = new Transaction();
            Transact.JOBNO = ddlJobNo.SelectedValue.Trim();
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "select_Assable_Val";

            DataSet ds = Transact.RetrieveAll_General_Details();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                decimal.TryParse(dr["TOTAL_ASSESSABLE_VALUE"].ToString(), out dbAssessable);
            }
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                bool allMatched = true;
                string mismatchDetails = "";

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    string dbBondNo = dr["BOND_NO"].ToString().Trim();

                    decimal dbbondamount = 0;
                    decimal.TryParse(dr["BOND_AMT"].ToString(), out dbbondamount);

                    // Find same bond in PDF table
                    DataRow[] pdfRows = bonddetails.Select("BOND_NO='" + dbBondNo.Replace("'", "''") + "'");

                    if (pdfRows.Length > 0)
                    {
                        decimal pdfAmt = 0;
                        decimal.TryParse(pdfRows[0]["DEBIT_AMT"].ToString(), out pdfAmt);
                        string pdfBondNo = pdfRows[0]["BOND_NO"].ToString().Trim();

                        Transact.BOND_NO = pdfBondNo;
                        Transact.JOBNO = ddlJobNo.SelectedValue.Trim();
                        Transact.WORKING_PERIOD = SELECT_BRANCH;
                        Transact.PDF_AMT = pdfAmt.ToString();
                        Transact.Ename = "PDF_ICE_AMT";

                        DataSet da = Transact.BOND_IECGATE_AMT();

                        // Check amount difference
                        if (Math.Abs(dbbondamount - pdfAmt) >= 1m)
                        {
                            allMatched = false;

                            mismatchDetails += "Bond No: " + dbBondNo +
                                               " |BD Amt: " + dbbondamount.ToString("0.00") +
                                               " |BE Amt: " + pdfAmt.ToString("0.00");
                        }
                        else
                        {
                            mismatchDetails += "Bond No: " + dbBondNo +
                                              " |BD Amt: " + dbbondamount.ToString("0.00") +
                                              " |BE Amt: " + pdfAmt.ToString("0.00");
                        }
                    }
                    else
                    {
                        // Bond number missing in PDF
                        allMatched = false;

                        mismatchDetails += "Bond No: " + dbBondNo +
                                           "not found in BE";
                    }
                }

                // Show total bond value
                txtTotalBondValue.Text = mismatchDetails;
                txtTotalBondValue.CssClass = "valueBox";

                if (allMatched)
                {
                    txtTotalBondValue.CssClass += " greenShadow";
                    lblbondMessage.Text = "Matched";
                    lblbondMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    txtTotalBondValue.CssClass += " redShadow";

                    lblbondMessage.Text = "Mismatch";
                    lblbondMessage.ForeColor = System.Drawing.Color.Red;
                }

                msgBondWrapper.Style["display"] = "inline-block";
            }

            txtTotalAssessableValue.Text = dbAssessable.ToString("0.00");
            txtTotalDutyValue.Text = ocrDuty.ToString("0.00");

            txtTotalAssessableValue.CssClass = "valueBox";
            txtTotalDutyValue.CssClass = "valueBox";

            msgWrapper.Style["display"] = "none";
            msgDutyWrapper.Style["display"] = "none";

            if (Math.Abs(dbAssessable - ocrAssessable) < 1m)
            {
                txtTotalAssessableValue.CssClass += " greenShadow";
                lblAssessMessage.Text = "Matched";
                lblAssessMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                txtTotalAssessableValue.CssClass += " redShadow";
                lblAssessMessage.Text = "Mismatch";
                lblAssessMessage.ForeColor = System.Drawing.Color.Red;
            }

            msgWrapper.Style["display"] = "inline-block";

            txtTotalDutyValue.CssClass += " greenShadow";
            lblDutyMessage.Text = "Duty Verified";
            lblDutyMessage.ForeColor = System.Drawing.Color.Green;
            msgDutyWrapper.Style["display"] = "inline-block";


        }
        catch (Exception ex)
        {
            assessMainBlock.Style["display"] = "none";
            dutyMainBlock.Style["display"] = "none";
            bondMainBlock.Style["display"] = "none";
        }
    }

    public decimal GetOrSaveOCRValue(string jobNo)
    {
        decimal ocrValue = 0;

        using (SqlConnection con = new SqlConnection(Connection.GetConnection()))
        {
            con.Open();

            SqlCommand checkCmd = new SqlCommand(
                "SELECT OCR_TOTAL_ASSESSABLE_VALUE FROM JOB_OCR_VALUES WHERE JOBNO=@JOBNO",
                con);

            checkCmd.Parameters.AddWithValue("@JOBNO", jobNo);

            object result = checkCmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                decimal.TryParse(result.ToString(), out ocrValue);

                if (ocrValue > 0)
                    return ocrValue;
            }

            var values = ReadTotAssVal_Dynamically();

            ocrValue = values.Item2;

            SqlCommand insertCmd = new SqlCommand(
                "INSERT INTO JOB_OCR_VALUES (JOBNO, OCR_TOTAL_ASSESSABLE_VALUE) VALUES (@JOBNO, @VAL)",
                con);

            insertCmd.Parameters.AddWithValue("@JOBNO", jobNo);
            insertCmd.Parameters.AddWithValue("@VAL", ocrValue);

            insertCmd.ExecuteNonQuery();
        }

        return ocrValue;
    }


    protected void btnJson_Click(object sender, EventArgs e)
    {
        try
        {
            Json_generation("", "");

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ImagebtnJsonfile_Click(object sender, ImageClickEventArgs e) // Added by shanthini on 14-08-2026 
    {
        try
        {

            logFileName = "BE" + ddlJobNo.SelectedValue.ToString() + DateTime.Now.Year.ToString() + ".json";
            errorFolder_json = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + "json" + "/");

            string fullFilePath = Path.Combine(errorFolder_json, logFileName);

            if (File.Exists(fullFilePath))
            {

                ObjUBO.File_Type = "I";
                ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
                ObjUBO.ITEM_DESCRIPTION = fullFilePath;
                ObjUBO.Select_Item = "";
                ObjUBO.flag = "S";

                IV.DSC_Flatfile_DML(ObjUBO);

                DSC_Flatfile_Sent_Check();
            }
            else
            {
                Alert_msg("JSON file not found. Please generate it first.");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Connection.Error_Msg(ex.Message);
        }
    }


    //private void Json_generation(string type, string path)
    //{
    //    logFileName = "BE" + ddlJobNo.SelectedValue.ToString() + DateTime.Now.Year.ToString() + ".json";
    //    if (type == "SQ")
    //    {
    //        errorFolder_json = path;
    //    }
    //    else
    //    {
    //        errorFolder_json = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + "json" + "/");
    //    }

    //    if (!Directory.Exists(errorFolder_json))
    //    {
    //        Directory.CreateDirectory(errorFolder_json);
    //    }

    //    string fullFilePath = Path.Combine(errorFolder_json, logFileName);
    //    if (File.Exists(fullFilePath))
    //    {
    //        try
    //        {
    //            File.Delete(fullFilePath);
    //        }
    //        catch (Exception ex)
    //        {
    //            Connection.Error_Msg(ex.Message);
    //            return;
    //        }
    //    }
    //    ICEGATE_ID = txt_icegate_Id.Text;
    //    FJ.JOBNo = ddlJobNo.SelectedValue.ToString();
    //    FJ.Ename = "General ";
    //    FJ.Inv_Slno = Inv_SLNo;
    //    DataSet dss = FJ.Get_Imp_ChkList_All_New(ICEGATE_ID, logFileName, errorFolder_json, CHA_NO);
    //    if (dss.Tables[0].Rows.Count > 0)
    //    {
    //        ImagebtnJsonfile.Visible = true;
    //    }
    //}


    private void Json_generation(string type, string path)
    {
        logFileName = "BE" + ddlJobNo.SelectedValue.ToString() + DateTime.Now.Year.ToString() + ".json";
        if (type == "SQ")
        {
            errorFolder_json = path;
        }
        else
        {
            errorFolder_json = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + "json" + "/");
        }
        if (!Directory.Exists(errorFolder_json))
        {
            Directory.CreateDirectory(errorFolder_json);
        }
        string fullFilePath = Path.Combine(errorFolder_json, logFileName);
        if (File.Exists(fullFilePath))
        {
            try
            {
                File.Delete(fullFilePath);
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
                return;
            }
        }

        string realJobNo = ddlJobNo.SelectedValue.ToString();
        string jobNumberForJson = null;
        string sequenceForJson = null;

        if (chkDummyFlatFile.Checked)
        {
            try
            {
                string dummyValue = GetAndSaveDummyJobNo(realJobNo, "J");   // TYPE = 'J'
                txtDummyJobNo.Text = dummyValue;

                jobNumberForJson = dummyValue;
                sequenceForJson = dummyValue;
            }
            catch (InvalidOperationException ex)
            {
                ShowMessage(ex.Message, false);
                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("DummyJson Save Error: " + ex.ToString());
                ShowMessage("Could not save Dummy Job No. Please try again.", false);
                return;
            }
        }

        ICEGATE_ID = txt_icegate_Id.Text;
        FJ.JOBNo = realJobNo;
        FJ.Ename = "General ";
        FJ.Inv_Slno = Inv_SLNo;

        DataSet dss = FJ.Get_Imp_ChkList_All_New(ICEGATE_ID, logFileName, errorFolder_json, CHA_NO,
                                                  jobNumberForJson, sequenceForJson);   // ← 2 புது parameter pass

        if (dss.Tables[0].Rows.Count > 0)
        {
            ImagebtnJsonfile.Visible = true;
        }
    }



    // ============================================================================
    // New DSC - Signing (added). Everything in this region is additive: it does not
    // modify Json_generation, btnJson_Click, ImagebtnJsonfile_Click, or
    // JSON_IEC_GATE_UPLOAD below, all of which continue to work exactly as before,
    // whether triggered by this new section or the existing "Select a Json" flow.
    // ============================================================================

    private const string Dsc_DefaultAgentBaseUrl = "http://127.0.0.1:9095";
    private const string Dsc_DefaultInstallUrl = "https://dscapp.eroyalimpex.co.in/Icegate.Agent.UI.application";
    // Must exactly match Api:JwtSecret in Icegate.Agent's own appsettings.json -- these
    // two are kept in sync manually, same as in SignFiles.aspx, which mints tokens the
    // same way for the same Agent.
    private const string Dsc_DefaultJwtSecret = "E0g6ya670OG-BEf26gt-vz3XHpUQnfsTCRMmDO6mP6QO48c2C-FHWEl8t31nZcmJ";
    private const string Dsc_DefaultJwtIssuer = "eroyalimpex-erp";
    private const string Dsc_DefaultJwtAudience = "icegate-agent";
    private const int Dsc_DefaultJwtValidityMinutes = 15;

    protected string Dsc_AgentBaseUrl;
    protected string Dsc_InstallUrl;
    protected string Dsc_BearerToken;

    /// <summary>
    /// Mints the short-lived bearer token the new "New DSC - Signing" section's
    /// JavaScript sends to the local Agent. Reads the same Web.config appSettings keys
    /// SignFiles.aspx already uses (IcegateAgentBaseUrl, IcegateJwtSecret, etc.), so a
    /// single Web.config change (if ever needed) applies to both pages consistently --
    /// falls back to the same hardcoded defaults if those keys aren't present.
    /// </summary>
    private void Dsc_InitializeSigning()
    {
        Dsc_AgentBaseUrl = ConfigurationManager.AppSettings["IcegateAgentBaseUrl"];
        if (string.IsNullOrEmpty(Dsc_AgentBaseUrl))
        {
            Dsc_AgentBaseUrl = Dsc_DefaultAgentBaseUrl;
        }

        Dsc_InstallUrl = ConfigurationManager.AppSettings["IcegateInstallUrl"];
        if (string.IsNullOrEmpty(Dsc_InstallUrl))
        {
            Dsc_InstallUrl = Dsc_DefaultInstallUrl;
        }

        string secret = ConfigurationManager.AppSettings["IcegateJwtSecret"];
        if (string.IsNullOrEmpty(secret))
        {
            secret = Dsc_DefaultJwtSecret;
        }

        string issuer = ConfigurationManager.AppSettings["IcegateJwtIssuer"];
        if (string.IsNullOrEmpty(issuer))
        {
            issuer = Dsc_DefaultJwtIssuer;
        }

        string audience = ConfigurationManager.AppSettings["IcegateJwtAudience"];
        if (string.IsNullOrEmpty(audience))
        {
            audience = Dsc_DefaultJwtAudience;
        }

        int validityMinutes = Dsc_DefaultJwtValidityMinutes;
        string validityRaw = ConfigurationManager.AppSettings["IcegateJwtValidityMinutes"];
        int parsedValidity;
        if (!string.IsNullOrEmpty(validityRaw) && int.TryParse(validityRaw, out parsedValidity) && parsedValidity > 0)
        {
            validityMinutes = parsedValidity;
        }

        Dsc_BearerToken = Dsc_GenerateJwt(secret, issuer, audience, TimeSpan.FromMinutes(validityMinutes));
    }

    // Hand-rolled HS256 JWT -- same algorithm already independently verified via a
    // Python round-trip when this was first built for SignFiles.aspx (base64url
    // header/payload, HMACSHA256 signature over "header.payload"). No new NuGet
    // dependency introduced for this one page.
    private static string Dsc_GenerateJwt(string secret, string issuer, string audience, TimeSpan validFor)
    {
        string header = "{\"alg\":\"HS256\",\"typ\":\"JWT\"}";

        long exp = Dsc_ToUnixTimeSeconds(DateTime.UtcNow.Add(validFor));
        string payload = string.Format(
            "{{\"iss\":\"{0}\",\"aud\":\"{1}\",\"exp\":{2}}}",
            Dsc_EscapeJsonString(issuer), Dsc_EscapeJsonString(audience), exp);

        string headerEncoded = Dsc_Base64UrlEncode(Encoding.UTF8.GetBytes(header));
        string payloadEncoded = Dsc_Base64UrlEncode(Encoding.UTF8.GetBytes(payload));
        string signingInput = headerEncoded + "." + payloadEncoded;

        byte[] signatureBytes;
        using (System.Security.Cryptography.HMACSHA256 hmac = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(secret)))
        {
            signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(signingInput));
        }
        string signatureEncoded = Dsc_Base64UrlEncode(signatureBytes);

        return signingInput + "." + signatureEncoded;
    }

    private static string Dsc_Base64UrlEncode(byte[] input)
    {
        string base64 = Convert.ToBase64String(input);
        return base64.Replace('+', '-').Replace('/', '_').TrimEnd('=');
    }

    private static string Dsc_EscapeJsonString(string s)
    {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }

    private static long Dsc_ToUnixTimeSeconds(DateTime utcDateTime)
    {
        return (long)(utcDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }

    /// <summary>
    /// Serves the unsigned JSON's raw content for the new section's JavaScript to fetch
    /// and hand to the local Agent for signing. Uses the exact same folder/filename
    /// logic Json_generation() already uses (see btnJson_Click above) -- reads whatever
    /// "Generate Json" most recently produced for this job, rather than duplicating or
    /// guessing at that logic separately. Exits via Response.End() when the query
    /// parameter is present; a normal page request (parameter absent) falls through
    /// untouched.
    /// </summary>
    private void Dsc_HandleUnsignedJsonRequest()
    {
        if (Request.QueryString["DscGetUnsignedJson"] != "1")
        {
            return;
        }

        try
        {
            string jobNo = Request.QueryString["Jobno"];
            if (string.IsNullOrEmpty(jobNo))
            {
                Response.StatusCode = 400;
                Response.Write("Job number is required.");
                Response.End();
                return;
            }

            string jsonFolder = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/json/");
            string fileName = "BE" + jobNo + DateTime.Now.Year.ToString() + ".json";
            string fullPath = Path.Combine(jsonFolder, fileName);

            if (!File.Exists(fullPath))
            {
                Response.StatusCode = 404;
                Response.Write("Unsigned JSON not found. Please click 'Generate Json' first.");
                Response.End();
                return;
            }

            Response.ContentType = "application/json";
            Response.Write(File.ReadAllText(fullPath));
            Response.End();
        }
        catch (System.Threading.ThreadAbortException)
        {
            // Expected: Response.End() above triggers this internally; ASP.NET handles it
            // as part of that call's normal contract, not a real error to report.
            throw;
        }
        catch (Exception ex)
        {
            Response.StatusCode = 500;
            Response.Write("Error: " + ex.Message);
            Response.End();
        }
    }



    //public void JSON_IEC_GATE_UPLOAD(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        string fileName = fileuploadExcel.FileName;
    //        int fileSize = fileuploadExcel.PostedFile.ContentLength;
    //        string fileType = fileuploadExcel.PostedFile.ContentType;
    //        string baseFolderPath = Server.MapPath("~/Submission/" +
    //                                        HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" +
    //                                        HttpContext.Current.Session["currentbranch"].ToString() + "/" +
    //                                        HttpContext.Current.Session["currentuser"].ToString() + "/DOWNLOAD");

    //        if (!Directory.Exists(baseFolderPath))
    //        {
    //            Directory.CreateDirectory(baseFolderPath);
    //        }
    //        else
    //        {
    //            // If folder exists, delete all existing files inside
    //            string[] existingFiles = Directory.GetFiles(baseFolderPath);
    //            foreach (string file in existingFiles)
    //            {
    //                File.Delete(file);
    //            }
    //        }
    //        string savePath = Path.Combine(baseFolderPath, fileName);
    //        fileuploadExcel.SaveAs(savePath);

    //        string jsonContent = File.ReadAllText(savePath);
    //        Newtonsoft.Json.Linq.JObject jsonObj = Newtonsoft.Json.Linq.JObject.Parse(jsonContent);

    //        string senderID = "";
    //        if (jsonObj["headerField"] != null && jsonObj["headerField"]["senderID"] != null)
    //        {
    //            senderID = jsonObj["headerField"]["senderID"].ToString();
    //        }
    //        string icegateId = txt_icegate_Id.Text.ToUpper();

    //        if (!senderID.Trim().ToUpper().Equals(icegateId))
    //        {
    //            Alert_msg_json("JSON ID does not match ICEGATE ID.Please verify and try again.");
    //            return;
    //        }
    //        else if (string.IsNullOrEmpty(senderID))
    //        {
    //            Alert_msg("Invalid JSON: senderID not found in headerField.");
    //            return;
    //        }

    //        Transaction Transact = new Transaction();
    //        string url = "http://icegateapi.eroyalimpex.co.in/api/icegate/submit";
    //        string clientCode = Connection.Company_License();
    //        // string com_id = Session["COMPANY_ID"].ToString();
    //        // string icegateId = txt_icegate_Id.Text.ToUpper();

    //        Transact.icegateId = icegateId;
    //        Transact.Ename = "GET_ICEGATE_PASS";
    //        Transact.Current_Working_Period = Working_Period;
    //        Transact.BRANCH_CODE = currentbranch;

    //        DataSet ds = Transact.Retrieve_Api_key_GET_ICEGATE();

    //        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
    //        {
    //            Alert_msg("API KEY NOT FOUND");
    //            return;
    //        }

    //        string api_key = ds.Tables[0].Rows[0]["API_KEY"].ToString();
    //        string filePath = savePath;

    //        string response = IceGateApiClient.SubmitIcegateRequest(
    //          url,
    //           clientCode,
    //           api_key,
    //           filePath
    //       );

    //        if (!string.IsNullOrEmpty(response) && response.Contains("\"validationStatus\":\"SUCCESS\""))
    //        {
    //            Alert_msg("JSON Successfully Submitted to ICEGATE");
    //        }
    //        else
    //        {
    //            string errorMsg = "Submission Failed.";

    //            if (!string.IsNullOrEmpty(response))
    //            {
    //                try
    //                {
    //                    var json = Newtonsoft.Json.Linq.JObject.Parse(response.Replace("HTTP ERROR: ", ""));
    //                    var message = json["message"];
    //                    if (message != null)
    //                    {
    //                        string msg = (string)message;
    //                        if (msg.Contains("ICEGATE Auth Failed"))
    //                        {
    //                            errorMsg = "ICEGATE Auth Failed. Please generate a new API Key and update.";
    //                        }
    //                        else
    //                        {
    //                            errorMsg = msg;
    //                        }
    //                    }
    //                }
    //                catch
    //                {
    //                    errorMsg = "Submission Failed.";
    //                }
    //            }

    //            Alert_msg(errorMsg);
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        string errorMsg = ex.Message.Replace("'", "\\'");

    //        Alert_msg("Error: " + errorMsg);
    //    }
    //}

    public void JSON_IEC_GATE_UPLOAD(object sender, EventArgs e)
    {

        try
        {
            string fileName = fileuploadExcel.FileName;
            int fileSize = fileuploadExcel.PostedFile.ContentLength;
            string file_ = Path.GetFileNameWithoutExtension(fileName).Replace("Signed", "");
            string type = file_.Substring(0, 2);
            string jobno = file_.Substring(2);



            string fileType = fileuploadExcel.PostedFile.ContentType;
            string baseFolderPath = Server.MapPath("~/Submission/" +
                                            HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" +
                                            HttpContext.Current.Session["currentbranch"].ToString() + "/" +
                                            HttpContext.Current.Session["currentuser"].ToString() + "/DOWNLOAD");

            if (!Directory.Exists(baseFolderPath))
            {
                Directory.CreateDirectory(baseFolderPath);
            }
            else
            {
                // If folder exists, delete all existing files inside
                string[] existingFiles = Directory.GetFiles(baseFolderPath);
                foreach (string file in existingFiles)
                {
                    File.Delete(file);
                }
            }
            string savePath = Path.Combine(baseFolderPath, fileName);
            fileuploadExcel.SaveAs(savePath);

            string jsonContent = File.ReadAllText(savePath);
            Newtonsoft.Json.Linq.JObject jsonObj = Newtonsoft.Json.Linq.JObject.Parse(jsonContent);

            string senderID = "";
            if (jsonObj["headerField"] != null && jsonObj["headerField"]["senderID"] != null)
            {
                senderID = jsonObj["headerField"]["senderID"].ToString();
            }
            string icegateId = txt_icegate_Id.Text.ToUpper();

            if (!senderID.Trim().ToUpper().Equals(icegateId))
            {
                Alert_msg_json("JSON ID does not match ICEGATE ID.Please verify and try again.");
                return;
            }
            else if (string.IsNullOrEmpty(senderID))
            {
                Alert_msg("Invalid JSON: senderID not found in headerField.");
                return;
            }

            Transaction Transact = new Transaction();
            string url = "http://icegateapi.eroyalimpex.co.in/api/icegate/submit";
            string clientCode = Connection.Company_License();
            // string com_id = Session["COMPANY_ID"].ToString();
            // string icegateId = txt_icegate_Id.Text.ToUpper();

            Transact.icegateId = icegateId;
            Transact.Ename = "GET_ICEGATE_PASS";
            Transact.Current_Working_Period = Working_Period;
            Transact.BRANCH_CODE = currentbranch;

            DataSet ds = Transact.Retrieve_Api_key_GET_ICEGATE();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Alert_msg("API KEY NOT FOUND");
                return;
            }

            string api_key = ds.Tables[0].Rows[0]["API_KEY"].ToString();
            string filePath = savePath;

            string response = IceGateApiClient.SubmitIcegateRequest(
              url,
               clientCode,
               api_key,
               filePath
           );

            if (!string.IsNullOrEmpty(response) && response.Contains("\"validationStatus\":\"SUCCESS\""))
            {
                InsertFlatFile("Success", jobno, fileName, type, currentbranch, Working_Period, currentuser, "");
                Alert_msg("JSON Successfully Submitted to ICEGATE");
            }
            else
            {
                string errorMsg = "Submission Failed.";

                if (!string.IsNullOrEmpty(response))
                {
                    try
                    {
                        var json = Newtonsoft.Json.Linq.JObject.Parse(response.Replace("HTTP ERROR: ", ""));
                        var message = json["message"];
                        if (message != null)
                        {
                            string msg = (string)message;
                            if (msg.Contains("ICEGATE Auth Failed"))
                            {
                                errorMsg = "ICEGATE Auth Failed. Please generate a new API Key and update.";
                            }
                            else
                            {
                                errorMsg = msg;
                            }
                        }
                    }
                    catch
                    {
                        errorMsg = "Submission Failed.";
                    }
                }
                InsertFlatFile("Error", jobno, fileName, type, currentbranch, Working_Period, currentuser, errorMsg);
                Alert_msg(errorMsg);
            }
        }

        catch (Exception ex)
        {
            string errorMsg = ex.Message.Replace("'", "\\'");

            Alert_msg("Error: " + errorMsg);
        }
    }

    public void InsertFlatFile(string tableType, string jobNo, string fileName, string type, string branchCode, string workingPeriod, string createdBy, string errorMessage = null)
    {
        string tableName;
        string typeResult = type.Equals("BE", StringComparison.OrdinalIgnoreCase) ? "I" : "E";

        if (tableType.Equals("Success", StringComparison.OrdinalIgnoreCase))
        {
            tableName = "FlatFile_Success";
        }
        else if (tableType.Equals("Error", StringComparison.OrdinalIgnoreCase))
        {
            tableName = "FlatFile_Error";
        }
        else
        {
            throw new ArgumentException("Invalid table type. Use Success or Error.");
        }

        string query;

        if (tableType.Equals("Success", StringComparison.OrdinalIgnoreCase))
        {
            query = "INSERT INTO " + tableName + " (JOBNO, FILENAME, TYPE, BRANCH_CODE, WORKINGPERIOD, CREATEDON, CREATEDBY) VALUES (@JOBNO, @FILENAME, @TYPE, @BRANCH_CODE, @WORKINGPERIOD, GETDATE(), @CREATEDBY)";
        }
        else
        {
            query = "INSERT INTO " + tableName + " (JOBNO, FILENAME, TYPE, ERRORMESSAGE, BRANCH_CODE, WORKINGPERIOD, CREATEDON, CREATEDBY) VALUES (@JOBNO, @FILENAME, @TYPE, @ERRORMESSAGE, @BRANCH_CODE, @WORKINGPERIOD, GETDATE(), @CREATEDBY)";
        }

        using (SqlConnection con = new SqlConnection(Connection.GetConnection()))
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@JOBNO", jobNo ?? "");
            cmd.Parameters.AddWithValue("@FILENAME", fileName ?? "");
            cmd.Parameters.AddWithValue("@TYPE", typeResult ?? "");
            cmd.Parameters.AddWithValue("@BRANCH_CODE", branchCode ?? "");
            cmd.Parameters.AddWithValue("@WORKINGPERIOD", workingPeriod ?? "");
            cmd.Parameters.AddWithValue("@CREATEDBY", createdBy ?? "");

            if (tableType.Equals("Error", StringComparison.OrdinalIgnoreCase))
            {
                cmd.Parameters.AddWithValue("@ERRORMESSAGE", errorMessage ?? "");
            }

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void Alert_msg_json(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {{}}, 20000);}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    private void Check_Duplicate_Invoice_OnLoad()
    {
        try
        {
            if (ddlJobNo.SelectedValue == "Select" || ddlJobNo.SelectedValue == "")
                return;

            CheckList chklist = new CheckList();
            chklist.JOBNo = ddlJobNo.SelectedValue.ToString();
            chklist.Ename = "Import_Duplicate_Invoice_Chk";
            chklist.Workingperiod = SELECT_BRANCH;

            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return;

            List<string> allJobs = new List<string>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                string existsIn = r["EXISTS_IN_JOBNO"].ToString().Trim();
                if (existsIn == "") continue;

                string[] jobArr = existsIn.Split(',');
                foreach (string jb in jobArr)
                {
                    string job = jb.Trim();
                    if (job != "" && !allJobs.Contains(job))
                        allJobs.Add(job);
                }
            }

            if (allJobs.Count == 0) return;

            string jobStr = "";
            foreach (string j in allJobs)
                jobStr += (jobStr == "" ? "" : ", ") + "'" + j + "'";

            string msg = "This Invoice Number Already Exists in Job No - " +
                         "<span style='color:red;font-weight:bold;'>" + jobStr + "</span>";

            Show_duplicate_Popup("Duplicate Invoice No", msg);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog("Check_Duplicate_Invoice_OnLoad: " + ex.Message);
        }
    }
    private void Show_duplicate_Popup(string title, string htmlMsg)
    {
        string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "")
                        ? Session["Theme"].ToString().ToLower()
                        : "orange";

        string gradTop, gradBot;
        switch (theme)
        {
            case "blue": gradTop = "#4a90e2"; gradBot = "#2b6cb0"; break;
            case "dblue": gradTop = "#2c3e60"; gradBot = "#16213a"; break;
            case "green": gradTop = "#43a047"; gradBot = "#2e7d32"; break;
            case "bluefancy": gradTop = "#5b86e5"; gradBot = "#36d1dc"; break;
            case "violetfancy": gradTop = "#8e2de2"; gradBot = "#4a00e0"; break;
            default: gradTop = "#f5a623"; gradBot = "#e08e0b"; break;
        }

        string t = (title ?? "").Replace("\\", "\\\\").Replace("'", "\\'");
        string m = (htmlMsg ?? "").Replace("\\", "\\\\").Replace("'", "\\'")
                                  .Replace("\r", "").Replace("\n", "");

        string js = @"
   (function () {
    var old = document.getElementById('cstm_pop_ovl');
    if (old) old.parentNode.removeChild(old);
    var gradTop = '" + gradTop + @"'; var gradBot = '" + gradBot + @"';
    var ovl = document.createElement('div');
    ovl.id = 'cstm_pop_ovl';
    ovl.style.cssText = 'position:fixed;top:0;left:0;width:100%;height:100%;background:rgba(0,0,0,.50);z-index:999998;display:flex;align-items:center;justify-content:center;';
    var box = document.createElement('div');
    box.style.cssText = 'width:460px;max-width:94vw;background:#fff;border-radius:8px;z-index:999999;box-shadow:0 8px 32px rgba(0,0,0,.40);font-family:Segoe UI,Tahoma,Arial,sans-serif;font-size:13px;color:#2d3436;display:flex;flex-direction:column;max-height:85vh;overflow:hidden;';
    box.innerHTML =
        '<div style=""background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;font-weight:700;font-size:14px;padding:10px 16px;flex-shrink:0;"">' + '" + t + @"' + '</div>' +
        '<div style=""padding:16px 18px;line-height:1.55;overflow:auto;flex:1;"">' + '" + m + @"' + '</div>' +
        '<div style=""padding:10px 14px;text-align:center;border-top:1px solid #eee;flex-shrink:0;"">' +
            '<button type=""button"" id=""cstm_pop_ok"" style=""min-width:88px;height:30px;background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;border:0;border-radius:5px;font-weight:600;cursor:pointer;"">OK</button></div>';
    ovl.appendChild(box);
    document.body.appendChild(ovl);
    document.getElementById('cstm_pop_ok').onclick = function () {
        var el = document.getElementById('cstm_pop_ovl');
        if (el) el.parentNode.removeChild(el);
    };
   })();";

        ScriptManager.RegisterStartupScript(this, GetType(),
            "cstmPop_" + Guid.NewGuid().ToString("N"), js, true);
    }



    private bool Check_Invoice_Lock()
    {

        CheckList chklist = new CheckList();
        chklist.JOBNo = ddlJobNo.SelectedValue.ToString().Trim();
        chklist.Ename = "Import_Check_Invoice_Generate_Lock";
        chklist.Workingperiod = SELECT_BRANCH;
        //chklist.currentuser = Session["currentuser"].ToString();
        DataSet dsLock = new DataSet();

        dsLock = chklist.RetrieveAll_Invoice_Details();

        if (dsLock == null || dsLock.Tables.Count == 0 || dsLock.Tables[0].Rows.Count == 0)
        {
            return true;
        }

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string lastInv = "";
        foreach (DataRow r in dsLock.Tables[0].Rows)
        {
            string inv = r["INVOICE_NO"].ToString();
            if (inv != lastInv)
            {
                if (lastInv != "") sb.Append("<br/><br/>");
                sb.Append("Invoice No <b>'" + inv + "'</b> is <b style='color:#c0392b;'>LOCKED</b>.<br/>");
                sb.Append("This invoice is already used in Job No : <b>" + r["DUPLICATE_JOBNO"].ToString() + "'");
                lastInv = inv;
            }
            else
            {
                sb.Append(", '" + r["DUPLICATE_JOBNO"].ToString() + "'");
            }
        }
        sb.Append("</b>.");
        sb.Append("<br/><br/>Go to <b>Admin &raquo; Duplicate Invoice Lock &raquo; Release</b>.");

        Show_Popup("Duplicate Invoice No", sb.ToString());

        return false;
    }


    private void Show_Popup(string title, string htmlMsg)
    {
        string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "")
                        ? Session["Theme"].ToString().ToLower()
                        : "orange";

        string gradTop, gradBot;

        switch (theme)
        {
            case "blue":
                gradTop = "#4a90e2"; gradBot = "#2b6cb0";
                break;
            case "dblue":
                gradTop = "#2c3e60"; gradBot = "#16213a";
                break;
            case "green":
                gradTop = "#43a047"; gradBot = "#2e7d32";
                break;
            case "bluefancy":
                gradTop = "#5b86e5"; gradBot = "#36d1dc";
                break;
            case "violetfancy":
                gradTop = "#8e2de2"; gradBot = "#4a00e0";
                break;
            case "orange":
            default:
                gradTop = "#f5a623"; gradBot = "#e08e0b";
                break;
        }

        string t = (title ?? "").Replace("\\", "\\\\").Replace("'", "\\'");
        string m = (htmlMsg ?? "").Replace("\\", "\\\\").Replace("'", "\\'")
                                  .Replace("\r", "").Replace("\n", "");

        string js = @"
(function () {
    var old = document.getElementById('cstm_pop_ovl');
    if (old) old.parentNode.removeChild(old);

    var gradTop = '" + gradTop + @"';
    var gradBot = '" + gradBot + @"';

    var ovl = document.createElement('div');
    ovl.id = 'cstm_pop_ovl';
    ovl.style.cssText = 'position:fixed;top:0;left:0;width:100%;height:100%;' +
        'background:rgba(0,0,0,.50);z-index:999998;' +
        'display:flex;align-items:center;justify-content:center;';

    var box = document.createElement('div');
    box.style.cssText = 'width:460px;max-width:94vw;' +
        'background:#fff;border-radius:8px;z-index:999999;' +
        'box-shadow:0 8px 32px rgba(0,0,0,.40);' +
        'font-family:Segoe UI,Tahoma,Arial,sans-serif;font-size:13px;color:#2d3436;' +
        'display:flex;flex-direction:column;max-height:85vh;overflow:hidden;';

    box.innerHTML =
        '<div style=""background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;' +
            'font-weight:700;font-size:14px;padding:10px 16px;flex-shrink:0;"">' + '" + t + @"' + '</div>' +
        '<div style=""padding:16px 18px;line-height:1.55;overflow:auto;flex:1;"">' + '" + m + @"' + '</div>' +
        '<div style=""padding:10px 14px;text-align:center;border-top:1px solid #eee;flex-shrink:0;"">' +
            '<button type=""button"" id=""cstm_pop_ok"" style=""min-width:88px;height:30px;' +
            'background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;border:0;' +
            'border-radius:5px;font-weight:600;cursor:pointer;"">OK</button></div>';

    ovl.appendChild(box);
    document.body.appendChild(ovl);

    document.getElementById('cstm_pop_ok').onclick = function () {
        var el = document.getElementById('cstm_pop_ovl');
        if (el) el.parentNode.removeChild(el);
    };
})();";

        ScriptManager.RegisterStartupScript(this, GetType(),
            "cstmPop_" + Guid.NewGuid().ToString("N"), js, true);
    }


     //Added By Benjamin 02092026

    protected void chkDummyFlatFile_CheckedChanged(object sender, EventArgs e)
    {
        hdn_Jobno.Value = Request["jobno"] != null ? Request["jobno"].ToString().TrimEnd() : string.Empty;
        string jobNo = hdn_Jobno.Value.Trim();
        string type="";

        if (string.IsNullOrEmpty(jobNo))
        {
            ShowMessage("Job No not found on this page.", false);
            chkDummyFlatFile.Checked = false;
            return;
        }

        if (chkDummyFlatFile.Checked)
        {
            try
            {
                //txtDummyJobNo.Text = GetPreviewDummyJobNo(jobNo);
                txtDummyJobNo.Text = GetPreviewDummyJobNo(jobNo,type);

                ShowMessage("Review the Dummy Job No, then click Submit to save.", true);
            }
            catch (InvalidOperationException ex)
            {
                ShowMessage(ex.Message, false);
                chkDummyFlatFile.Checked = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("DummyFlatFile Preview Error: " + ex.ToString());
                ShowMessage("Could not generate preview. Please try again.", false);
                chkDummyFlatFile.Checked = false;
            }
        }
        else
        {

            txtDummyJobNo.Text = string.Empty;
            ShowMessage(string.Empty, true);
        }
    }



//    private string GetPreviewDummyJobNo(string jobNo)
//    {
//        string impExp = "IMP";                   
//        string branchCode = Connection.Current_Branch();  

//        int existingMaxCount = 0;
//        using (SqlConnection conn = new SqlConnection(Connection.GetConnection()))
//        using (SqlCommand cmd = new SqlCommand(@"
//        SELECT ISNULL(MAX(d.CLICK_COUNT), 0)
//        FROM IMP_EXP_DUMMY_DUPLICATE_JOB d
//        WHERE d.JOBNO = @JobNo
//          AND d.IMP_EXP = @ImpExp
//          AND d.BRANCH_CODE IN (
//                SELECT BRANCHCODE FROM TBL_GROUPMASTER
//                WHERE GROUP_ID = (
//                    CASE WHEN @BranchCode <> ''
//                         THEN (SELECT GROUP_ID FROM TBL_GROUPMASTER WHERE BRANCHCODE = @BranchCode)
//                         ELSE 1 END))", conn))
//        {
//            cmd.Parameters.AddWithValue("@JobNo", jobNo);
//            cmd.Parameters.AddWithValue("@ImpExp", impExp);
//            cmd.Parameters.AddWithValue("@BranchCode", branchCode);
//            conn.Open();
//            object result = cmd.ExecuteScalar();
//            if (result != null && result != DBNull.Value)
//                existingMaxCount = Convert.ToInt32(result);
//        }

//        int previewCount = existingMaxCount + 1;
//        return BuildDummyJobNo(jobNo, previewCount);
//    }



    private string GetPreviewDummyJobNo(string jobNo, string type)   // ← "type" புது parameter
    {
      

         string impExp = "IMP";
        string branchCode = Connection.Current_Branch();  


        int existingMaxCount = 0;
        using (SqlConnection conn = new SqlConnection(Connection.GetConnection()))
        using (SqlCommand cmd = new SqlCommand(@"
        SELECT ISNULL(MAX(d.CLICK_COUNT), 0)
        FROM IMP_EXP_DUMMY_DUPLICATE_JOB d
        WHERE d.JOBNO = @JobNo
          AND d.IMP_EXP = @ImpExp
          AND d.TYPE = @Type
          AND d.BRANCH_CODE IN (
                SELECT BRANCHCODE FROM TBL_GROUPMASTER
                WHERE GROUP_ID = (
                    CASE WHEN @BranchCode <> ''
                         THEN (SELECT GROUP_ID FROM TBL_GROUPMASTER WHERE BRANCHCODE = @BranchCode)
                         ELSE 1 END))", conn))
        {
            cmd.Parameters.AddWithValue("@JobNo", jobNo);
            cmd.Parameters.AddWithValue("@ImpExp", impExp);
            cmd.Parameters.AddWithValue("@Type", type);
            cmd.Parameters.AddWithValue("@BranchCode", branchCode);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
                existingMaxCount = Convert.ToInt32(result);
        }

        int previewCount = existingMaxCount + 1;
        return BuildDummyJobNo(jobNo, previewCount);
    }




    //private string BuildDummyJobNo(string jobNo, int clickCount)
    //{
    //    const int CounterDigits = 2;
    //    const int TotalLength = 7;
    //    const int JobFieldLength = TotalLength - CounterDigits;   

    //    int maxCount = (int)Math.Pow(10, CounterDigits) - 1;     
    //    if (clickCount > maxCount)
    //    {
    //        throw new InvalidOperationException(
    //            string.Format("Maximum dummy attempts ({0}) reached for Job No {1}.", maxCount, jobNo));
    //    }

    //    string jobPart = jobNo.Length >= JobFieldLength
    //        ? jobNo.Substring(0, JobFieldLength)
    //        : jobNo.PadLeft(JobFieldLength, '0');                 

    //    string counterPart = clickCount.ToString().PadLeft(CounterDigits, '0');  

    //    return jobPart + counterPart;     
    //}




    private string BuildDummyJobNo(string jobNo, int clickCount)
    {
        const int TotalLength = 7;

        int jobFieldLength = Math.Max(5, jobNo.Length);
        int counterDigits = TotalLength - jobFieldLength;
        if (counterDigits < 1) counterDigits = 1;

        int maxCount = (int)Math.Pow(10, counterDigits) - 1;
        if (clickCount > maxCount)
        {
            throw new InvalidOperationException(
                string.Format("Maximum dummy attempts ({0}) reached for Job No {1}.", maxCount, jobNo));
        }

        string jobPart = jobNo.PadLeft(jobFieldLength, '0');
        string counterPart = clickCount.ToString().PadLeft(counterDigits, '0');

        return jobPart + counterPart;
    }









    //private string GetAndSaveDummyJobNo(string realJobNo)
    //{
    //    string impExp = "IMP";
    //    string branchCode = Connection.Current_Branch();
    //    string userId = Session["UserId"] != null ? Session["UserId"].ToString() : string.Empty;

    //    string dummyJobNo;

    //    try
    //    {
    //        using (SqlConnection conn = new SqlConnection(Connection.GetConnection()))
    //        using (SqlCommand cmd = new SqlCommand("IMP_EXP_DUMMY_DUPLICATE_JOB_INS", conn))
    //        {
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            cmd.Parameters.AddWithValue("@IMP_EXP", impExp);
    //            cmd.Parameters.AddWithValue("@JOBNO", realJobNo);
    //            cmd.Parameters.AddWithValue("@BRANCH_CODE", branchCode);
    //            cmd.Parameters.AddWithValue("@User_ID", userId);

    //            SqlParameter outParam = new SqlParameter("@DummyJobNo", SqlDbType.NVarChar, 7);
    //            outParam.Direction = ParameterDirection.Output;
    //            cmd.Parameters.Add(outParam);

    //            conn.Open();
    //            cmd.ExecuteNonQuery();

    //            dummyJobNo = outParam.Value != DBNull.Value ? outParam.Value.ToString() : null;
    //        }
    //    }
    //    catch (SqlException sqlEx)
    //    {
    //        // SP-ல RAISERROR('Maximum dummy attempts (99) reached...') throw பண்ணா இங்க வந்து
    //        // InvalidOperationException ஆ மாறி, Flat_File()-ல இருக்கிற catch block ShowMessage காட்டும்
    //        throw new InvalidOperationException(sqlEx.Message);
    //    }

    //    if (string.IsNullOrEmpty(dummyJobNo))
    //        throw new InvalidOperationException("Could not generate Dummy Job No. Please try again.");

    //    return dummyJobNo;
    //}



    private string GetAndSaveDummyJobNo(string realJobNo, string type)   // ← "type" புது parameter
    {
        if (string.IsNullOrEmpty(realJobNo))
            throw new InvalidOperationException("Job No not found. Please select a Job No before generating Dummy Job No.");

        string impExp = "IMP";   
        
        

        string dummyJobNo;
        try
        {
            using (SqlConnection conn = new SqlConnection(Connection.GetConnection()))
            using (SqlCommand cmd = new SqlCommand("IMP_EXP_DUMMY_DUPLICATE_JOB_INS", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IMP_EXP", impExp);
                cmd.Parameters.AddWithValue("@JOBNO", realJobNo);
                cmd.Parameters.AddWithValue("@BRANCH_CODE", Connection.Current_Branch());
                cmd.Parameters.AddWithValue("@User_ID", Connection.Current_User());
                cmd.Parameters.AddWithValue("@TYPE", type);

                SqlParameter outParam = new SqlParameter("@DummyJobNo", SqlDbType.NVarChar, 20);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                dummyJobNo = outParam.Value != DBNull.Value ? outParam.Value.ToString() : null;
            }
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException(sqlEx.Message);
        }

        if (string.IsNullOrEmpty(dummyJobNo))
            throw new InvalidOperationException("Could not generate Dummy Job No. Please try again.");

        return dummyJobNo;
    }



    private void LoadExistingDummyJobNo(string jobNo)
    {
        string impExp = "IMP";
        string branchCode = Connection.Current_Branch();

        string existingDummyJobNo = null;

        using (SqlConnection conn = new SqlConnection(Connection.GetConnection()))
        using (SqlCommand cmd = new SqlCommand(@"
        SELECT TOP 1 d.DUMMY_JOBNO
        FROM IMP_EXP_DUMMY_DUPLICATE_JOB d
        WHERE d.JOBNO = @JobNo
          AND d.IMP_EXP = @ImpExp
          AND d.BRANCH_CODE IN (
                SELECT BRANCHCODE FROM TBL_GROUPMASTER
                WHERE GROUP_ID = (
                    CASE WHEN @BranchCode <> ''
                         THEN (SELECT GROUP_ID FROM TBL_GROUPMASTER WHERE BRANCHCODE = @BranchCode)
                         ELSE 1 END))
        ORDER BY d.CLICK_COUNT DESC", conn))
        {
            cmd.Parameters.AddWithValue("@JobNo", jobNo);
            cmd.Parameters.AddWithValue("@ImpExp", impExp);
            cmd.Parameters.AddWithValue("@BranchCode", branchCode);

            conn.Open();
            object result = cmd.ExecuteScalar();
            existingDummyJobNo = (result != null && result != DBNull.Value) ? result.ToString() : null;
        }

        if (!string.IsNullOrEmpty(existingDummyJobNo))
        {
            chkDummyFlatFile.Checked = true;
            txtDummyJobNo.Text = existingDummyJobNo;
            ShowMessage("Existing Dummy Job No: " + existingDummyJobNo, true);
        }
        else
        {
            chkDummyFlatFile.Checked = false;
            //txtDummyJobNo.Text = string.Empty;

            txtDummyJobNo.Text = existingDummyJobNo ?? string.Empty;
        }
    }



    private void ShowJsAlert(string message)
    {
        message = message.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r\n", " ").Replace("\n", " ");
        string script = "alert('" + message + "');";

        if (ScriptManager.GetCurrent(this.Page) != null)
            ScriptManager.RegisterStartupScript(this, this.GetType(), "BondMandatoryAlert", script, true);
        else
            ClientScript.RegisterStartupScript(this.GetType(), "BondMandatoryAlert", script, true);
    }


    private bool Check_BondMandatory_Notn045()
    {
        try
        {
            CheckList chklist = new CheckList();
            chklist.JOBNo = ddlJobNo.SelectedValue.ToString().Trim();
            chklist.Ename = "Check_Bond_Mandatory_Notn045";
            chklist.Workingperiod = SELECT_BRANCH;

            DataSet dsBond = new DataSet();
            dsBond = chklist.RetrieveAll_Invoice_Details();

            if (dsBond != null && dsBond.Tables.Count > 0 && dsBond.Tables[0].Rows.Count > 0)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog("Check_BondMandatory_Notn045 failed: " + ex.Message);
        }
        return false;
    }


    private void ShowMessage(string message, bool isSuccess)
    {
        lblDummyMsg.Text = message;
        lblDummyMsg.ForeColor = isSuccess ? System.Drawing.Color.Green : System.Drawing.Color.Red;
    }



}