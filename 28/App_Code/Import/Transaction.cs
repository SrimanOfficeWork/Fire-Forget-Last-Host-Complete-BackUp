using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;


public class Transaction : ErrorLogs
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    SqlCommand cmd;
    DataTable dt = new DataTable();


    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    int A1, A2;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    public int result = 0, IGMSLNO, UPDATE_ID = 0, UPDATE_ITEMSLNO = 0;
    public string err, INV_SLNO, UPDATE_INVOICE_NO = "", TOTAL_ITEM_VALUE = "", Inv_result = "";
    public double ALL_INVOICE_VALUE, ALL_FREIGHT_TOTAL, ALL_INSURANCE_TOTAL, Gridview_Rowcount, TOTAL_MULTIPLE_MISC_AMT, TOTAL_MULTIPLE_HSS_AMT;

    SqlConnection conn;

    private string _SEARCH_CAT, _SEARCH_ITEM, _MI_FREIGHT, _MI_INSURANCE, _TRUCK_NO, _GSTN_TYPE, _GSTN_ID, _PARTY_REF_NO, _ETA, _SIMS, _SUPPLIER_BRANCH_SLNO
        , _AMENDMENT_TYPE, _AMENDMENT_STATUS, _AIDC_NOTN, _AIDC_NOTN_SLNO, _AIDC_RATE;

    public string MI_INSURANCE { get { return _MI_INSURANCE; } set { _MI_INSURANCE = value; } }
    public string MI_FREIGHT { get { return _MI_FREIGHT; } set { _MI_FREIGHT = value; } }
    public string SUPPLIER_BRANCH_SLNO { get { return _SUPPLIER_BRANCH_SLNO; } set { _SUPPLIER_BRANCH_SLNO = value; } }
    public string AMENDMENT_TYPE { get { return _AMENDMENT_TYPE; } set { _AMENDMENT_TYPE = value; } }
    public string AMENDMENT_STATUS { get { return _AMENDMENT_STATUS; } set { _AMENDMENT_STATUS = value; } }
    public string AIDC_NOTN { get { return _AIDC_NOTN; } set { _AIDC_NOTN = value; } }
    public string AIDC_NOTN_SLNO { get { return _AIDC_NOTN_SLNO; } set { _AIDC_NOTN_SLNO = value; } }
    public string AIDC_RATE { get { return _AIDC_RATE; } set { _AIDC_RATE = value; } }

    public string SEARCH_CAT { get { return _SEARCH_CAT; } set { _SEARCH_CAT = value; } }
    public string SEARCH_ITEM { get { return _SEARCH_ITEM; } set { _SEARCH_ITEM = value; } }
    public string TRUCK_NO { get { return _TRUCK_NO; } set { _TRUCK_NO = value; } }
    public string GSTN_ID { get { return _GSTN_ID; } set { _GSTN_ID = value; } }
    public string GSTN_TYPE { get { return _GSTN_TYPE; } set { _GSTN_TYPE = value; } }
    public string PARTY_REF_NO { get { return _PARTY_REF_NO; } set { _PARTY_REF_NO = value; } }
    public string ETA { get { return _ETA; } set { _ETA = value; } }

    public string SIMS { get { return _SIMS; } set { _SIMS = value; } }


    private string _CETH_CVD_EDU_CESS_SL, _CETH_CVD_EDU_CESS_RATE, _CETH_CVD_SEC_EDU_CESS_SL, _CETH_CVD_SEC_EDU_CESS_RATE;
    public string CETH_CVD_EDU_CESS_SL { get { return _CETH_CVD_EDU_CESS_SL; } set { _CETH_CVD_EDU_CESS_SL = value; } }
    public string CETH_CVD_EDU_CESS_RATE { get { return _CETH_CVD_EDU_CESS_RATE; } set { _CETH_CVD_EDU_CESS_RATE = value; } }
    public string CETH_CVD_SEC_EDU_CESS_SL { get { return _CETH_CVD_SEC_EDU_CESS_SL; } set { _CETH_CVD_SEC_EDU_CESS_SL = value; } }
    public string CETH_CVD_SEC_EDU_CESS_RATE { get { return _CETH_CVD_SEC_EDU_CESS_RATE; } set { _CETH_CVD_SEC_EDU_CESS_RATE = value; } }


    // Start
    private string _DB_Type, _DBS_Name, _Current_Working_Period;
    public string DB_Type { get { return _DB_Type; } set { _DB_Type = value; } }
    public string DBS_Name { get { return _DBS_Name; } set { _DBS_Name = value; } }
    public string Current_Working_Period { get { return _Current_Working_Period; } set { _Current_Working_Period = value; } }

    // End

    private string _JOB_PREFIX, _JOB_SUFFIX;
    public string JOB_PREFIX { get { return _JOB_PREFIX; } set { _JOB_PREFIX = value; } }
    public string JOB_SUFFIX { get { return _JOB_SUFFIX; } set { _JOB_SUFFIX = value; } }

    //MISC ----HSS------------
    private string _MULTIPLE_MISC_AMT, _MULTIPLE_HSS_AMT, _MI_MISC, _MI_HSS;
    public string MULTIPLE_MISC_AMT { get { return _MULTIPLE_MISC_AMT; } set { _MULTIPLE_MISC_AMT = value; } }
    public string MULTIPLE_HSS_AMT { get { return _MULTIPLE_HSS_AMT; } set { _MULTIPLE_HSS_AMT = value; } }
    public string MI_MISC { get { return _MI_MISC; } set { _MI_MISC = value; } }
    public string MI_HSS { get { return _MI_HSS; } set { _MI_HSS = value; } }
    //MISC ----HSS------------

    // ----Budget 2016------ Start------
    private string _RSP_APPLICABLE, _CENTRAL_EXCISE_FALG, _MANUFACTURER_PRODUCER, _M_P_GROWER_CODE, _M_P_GROWER_ADD1, _M_P_GROWER_ADD2, _M_P_GROWER_CITY, _M_P_GROWER_COUNTRY_SUBDIV
                   , _M_P_GROWER_PIN, _M_P_GROWER_COUNTRY, _SOURCE_COUNTRY, _TRANSIT_COUNTRY, _ACCESSORY_STATUS, _INFRA_CESS_NOTN, _INFRA_CESS_NOTN_SL, _INFRA_CESS_NOTN_RATE;

    public string RSP_APPLICABLE { get { return _RSP_APPLICABLE; } set { _RSP_APPLICABLE = value; } }
    public string CENTRAL_EXCISE_FALG { get { return _CENTRAL_EXCISE_FALG; } set { _CENTRAL_EXCISE_FALG = value; } }
    public string MANUFACTURER_PRODUCER { get { return _MANUFACTURER_PRODUCER; } set { _MANUFACTURER_PRODUCER = value; } }
    public string M_P_GROWER_CODE { get { return _M_P_GROWER_CODE; } set { _M_P_GROWER_CODE = value; } }
    public string M_P_GROWER_ADD1 { get { return _M_P_GROWER_ADD1; } set { _M_P_GROWER_ADD1 = value; } }
    public string M_P_GROWER_ADD2 { get { return _M_P_GROWER_ADD2; } set { _M_P_GROWER_ADD2 = value; } }
    public string M_P_GROWER_CITY { get { return _M_P_GROWER_CITY; } set { _M_P_GROWER_CITY = value; } }
    public string M_P_GROWER_COUNTRY_SUBDIV { get { return _M_P_GROWER_COUNTRY_SUBDIV; } set { _M_P_GROWER_COUNTRY_SUBDIV = value; } }
    public string M_P_GROWER_PIN { get { return _M_P_GROWER_PIN; } set { _M_P_GROWER_PIN = value; } }
    public string M_P_GROWER_COUNTRY { get { return _M_P_GROWER_COUNTRY; } set { _M_P_GROWER_COUNTRY = value; } }
    public string SOURCE_COUNTRY { get { return _SOURCE_COUNTRY; } set { _SOURCE_COUNTRY = value; } }
    public string TRANSIT_COUNTRY { get { return _TRANSIT_COUNTRY; } set { _TRANSIT_COUNTRY = value; } }
    public string ACCESSORY_STATUS { get { return _ACCESSORY_STATUS; } set { _ACCESSORY_STATUS = value; } }


    public string INFRA_CESS_NOTN { get { return _INFRA_CESS_NOTN; } set { _INFRA_CESS_NOTN = value; } }
    public string INFRA_CESS_NOTN_SL { get { return _INFRA_CESS_NOTN_SL; } set { _INFRA_CESS_NOTN_SL = value; } }
    public string INFRA_CESS_NOTN_RATE { get { return _INFRA_CESS_NOTN_RATE; } set { _INFRA_CESS_NOTN_RATE = value; } }

    // ----Budget 2016------ End------

    # region Common_Private_Attributes
    private string _IMP_EXP_TYPE, _flag;

    private string _USER_ID, _BRANCH_CODE, _YEAR, _WORKING_PERIOD, _DB_NAME, _JOBNO, _startRowIndex, _OLD_JOBNO, _BRANCH_COMMON, _LICENSE_NO, _TYPE, _maximumRows
                   , _totalRows, _QTY, _Flag;

    private decimal _ITEM_VALUE;
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string OLD_JOBNO { get { return _OLD_JOBNO; } set { _OLD_JOBNO = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public string QTY { get { return _QTY; } set { _QTY = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public decimal ITEM_VALUE { get { return _ITEM_VALUE; } set { _ITEM_VALUE = value; } }
    #endregion
    #region Private
    #region IGM Details_Private_Attributes
    private string _IGM_ID, _IGM_SLNO_UPDATE, _IGM_JOBNO, _IGM_JOBDATE, _IGM_AIRLINECODE, _IGM_AIRLINENAME, _IGM_FLIGHTNO_VESSELNO, _IGM_FLIGHT_VESSELDATE, _IGM_NO, _IGM_DATE, _IGM_MAWB_MBL
                   , _IGM_MAWB_MBLDATE, _IGM_HAWB_HBLNO, _IGM_HAWB_HBLDATE, _IGM_NOOFPACKAGE, _IGM_PACKAGETYPE, _IGM_GROSSWEIGHT, _IGM_TYPEOFWEIGHT, _IGM_NETWEIGHT, _IGM_NETWEIGHTTYPE
                   , _IGM_MARKSNOS, _IGM_TRANSPORTMODE, _IGM_GATEWAY_IGM_NO, _IGM_GATEWAY_IGM_DATE, _IGM_GATEWAY_PORT_CODE, _IGM_LINE_NUMBER, _IGM_SHIPPING_LINE_NUMBER, _IGM_VOYAGE
                   , _IGM_CHARGEABLE_WGT, _ROTATION_NO, _ROTATION_DATE;
    #endregion

    #region GeneralDetails_Private_Attributes
    private string _JOBID, _Name_Search, _Ename, _JOBDATE, _TRANSPORT_MODE, _BE_TYPE, _CUSTOMS_HOUSE, _CUSTOMS_HOUSE_NAME, _FILE_REF_NO, _CONTAINER_TYPE, _IMPORTER_NAME, _ADDRESS1
, _ADDRESS2, _ADDRESS3, _ADDRESS4, _ADDRESS5, _IEC_NO, _BRANCH_NO, _COUNTRY_ORIGIN, _PORT_ORIGIN, _PORT_SHIPMENT, _COUNTRY_SHIPMENT, _FILING_STATUS, _SECTION46, _SECTION46_DESC
, _FIRSTCHECK, _FIRSTCHECK_DESC, _GREEN_CHANNEL, _GREEN_CHANNEL_DESC, _KACHHA_BE, _KACHHA_BE_DESC, _SECTION48, _SECTION48_DESC, _HIGH_SEA_SALE, _HIGH_SEA_SALE_NAME, _HIGH_SEA_IEC
, _HIGH_SEA_BRANCH_SL_NO, _HSS_ADD1, _HSS_ADD2, _HSS_ADD3, _HSS_ADD4, _HSS_ADD5, _HSS_ADCODE, _WAREHOUSE_NAME, _WAREHOUSE_CODE, _COMMERCIAL_DETAILS_STATUS, _COMMERCIAL_TAX_STATENAME
 , _COMMERCIAL_TAX_STATECODE, _COMMERCIAL_TAX_TYPE, _COMMERCIAL_TAX_REGISTRATION_NO, _EXBOND_INBOND_BE_NO, _EXBOND_INBOND_BE_DATE, _EXBOND_BOND_NO, _EXBOND_BOND_DATE
, _EXBOND_WAREHOUSE_CUSTOMS, _EXBOND_WAREHOUSE_CUSTOMS_CODE, _EXBOND_NOOFPACKAGE, _EXBOND_NOOFPACKAGE_UNITCODE, _EXBOND_GROSS_WEIGHT, _EXBOND_GROSS_WEIGHT_UNITCODE, _EXBOND_DIRECT_EXBONDING
, _REMARKS, _UCR_NO, _UCR_TYPE, _PAYMENT_METHOD_CODE, _PRECEDING_LEVEL, _ADCODE, _EXBOND_ADDL_LOAD_HSS, _EXBOND_MISC_LOAD_RATE, _ICE_ID, _CHA_NO, _PROVISIONAL, _PROVISIONAL_DESC, _BE_NO;
    #endregion

    #region Container Details_Private_Attributes

    private string _CONTAINERID;

    private string _CONTAINER_NO;
    private string _CONTAINER_IGM_SLNO;
    private string _CONTAINER_IGM_NO;
    private string _CONTAINER_IGM_DATE;
    private string _SEAL_NO;
    private string _FCL_OR_LCL;


    #endregion
    #region Bond Details_Private_Attributes
    private string _BONDID;

    private string _BOND_NO;
    private string _BOND_TYPE, _BOND_LOCATION;
    #endregion

    #region Certificate Details_Private_Attributes
    private string _CERTIFICATEID;

    private string _CERTIFICATE_NO;
    private string _CERTIFICATE_DATE;
    private string _CERTIFICATE_TYPE;

    #endregion

    #region SVB Details_Private_Attributes
    private string _SVB_ID;

    private string _SVB_RELATION;
    private string _SVB_REF_NO;
    private string _SVB_REF_DATE;
    private string _SVB_CUSTOM_HOUSE;
    private string _SVB_LOADING_ON;
    private string _SVB_ASSESABLE_RATE;
    private string _SVB_DUTY_RATE;
    private string _SVB_ASSESABLE_STATUS;
    private string _SVB_DUTY_STATUS;
    #endregion

    #region Invoice_Other_Charges_Private_Attributes

    private string _A_AMOUNT;
    private string _B_AMOUNT;
    private string _C_AMOUNT;
    private string _D_AMOUNT;
    private string _E_AMOUNT;
    private string _F_AMOUNT;
    private string _G_AMOUNT;
    private string _H_AMOUNT;
    private string _I_AMOUNT;
    private string _J_AMOUNT;
    private string _K_AMOUNT;
    private string _L_AMOUNT;
    private string _M_AMOUNT;
    private string _N_AMOUNT;
    private string _TOTAL_OTHER_AMOUNT;
    #endregion

    #region INVOICE_MAIN_Details_Private_Attributes
    private string _INVOICE_ID;

    private string _INVOICE_NO;
    private string _INVOICE_DATE;
    private string _TERMS;
    private string _INVOICE_CURRENCY;
    private string _INVOICE_EXRATE;

    private string _INVOICE_VALUE;
    private string _NON_STD_EFFECT_DT_IMP, _NON_STD_BANKNAME, _NON_STD_CERTIFICATE_NO, _NON_STD_CERTIFICATE_DATE;
    private string _SAP_DELIEVERY_ID, _SHIP_DATE, _INVOICE_LEVEL, _COUNTRY_OF_DEPARTURE;
    private string _REVENUEDEPOSIT_ON, _REVENUEDEPOSIT_RATE;

    #endregion
    #region MISC_Details_Private_Attributes
    private string _MIS_ID;

    private string _MIS_CHARGES;
    private string _MIS_RATE;
    private string _MIS_CURRENCY;
    private string _MIS_EXRATE;
    private string _MIS_AGENCY_CHARGES;
    private string _MIS_AGENCY_RATE;
    private string _MIS_AGENCY_CURRENCY;
    private string _MIS_AGENCY_EXRATE;
    private string _MIS_DISCOUNT_CHARGES;
    private string _MIS_DISCOUNT_RATE;
    private string _MIS_DISCOUNT_CURRENCY;
    private string _MIS_DISCOUNT_EXRATE;
    private string _MIS_DISCOUNT_REASON;
    private string _MIS_LOADING_CHARGES;
    private string _MIS_LOADING_RATE;
    private string _MIS_LOADING_CURRENCY;
    private string _MIS_LOADING_EXRATE;
    private string _MIS_FREIGHT_CHARGES;
    private string _MIS_FREIGHT_RATE;
    private string _MIS_FREIGHT_CURRENCY;
    private string _MIS_FREIGHT_EXRATE;
    private string _MIS_INSURANCE_CHARGES;
    private string _MIS_INSURANCE_RATE;
    private string _MIS_INSURANCE_CURRENCY;
    private string _MIS_LOADING_PERCENTAGE;
    private string _MIS_INSURANCE_EXRATE;
    private string _MIS_HIGHSEASALE_CHARGES;
    private string _MIS_HIGHSEASALE_RATE;
    private string _MIS_HIGHSEASALE_CURRENCY;
    private string _MIS_HIGHSEASALE_EXRATE;
    private string _MIS_SINGLE_OR_MULITIPLE;
    #endregion

    #region Other_Details_Private_Attributes
    private string _OTHER_ID;

    private string _OTHER_PURCHASE_ORDER;
    private string _OTHER_PURCHASE_ORDER_DATE;
    private string _OTHER_CONTRACT_NO;
    private string _OTHER_CONTRACT_DATE;
    private string _OTHER_LOC_NO;
    private string _OTHER_LOC_DATE;
    private string _OTHER_NATURE_OF_TRANSACTION;
    private string _OTHER_TERMS_OF_PAYMENT;
    private string _OTHER_CONDITIONS;
    private string _OTHER_VALUATION_METHOD;
    #endregion
    #region Supplier_Details_Private_Attributes
    private string _SUPPLIER_ID;

    private string _SUPPLIER_NAME;
    private string _SUPPLIER_ADDRESS;
    private string _SUPPLIER_ADDRESS1;
    private string _SUPPLIER_ADDRESS2;
    private string _SUPPLIER_ADDRESS3;
    private string _SUPPLIER_COUNTRY_NAME;
    private string _SUPPLIER_COUNTRY_CODE;
    private string _SUPPLIER_COUNTRY_PINCODE;
    private string _SELLER_NAME;
    private string _SELLER_ADDRESS;
    private string _SELLER_ADDRESS1;
    private string _SELLER_ADDRESS2;
    private string _SELLER_ADDRESS3;
    private string _SELLER_COUNTRY_NAME;
    private string _SELLER_COUNTRY_CODE;
    private string _SELLERCOUNTRY_PINCODE;
    private string _BROKER_NAME;
    private string _BROKER_ADDRESS;
    private string _BROKER_ADDRESS1;
    private string _BROKER_ADDRESS2;
    private string _BROKER_ADDRESS3;
    private string _BROKER_COUNTRY_NAME;
    private string _BROKER_COUNTRY_CODE;
    private string _BROKER_COUNTRY_PINCODE;

    #endregion

    #region OtherDuty_Details_Private_Attributes
    private string _DUTY_ID;

    private string _ANTI_DUMPING_NOTN;
    private string _ANTI_DUMPING_NOTN_SLNO;
    private string _CTH_SLNO;
    private string _CTH_SUPPLIER_SLNO;
    private string _CTH_QTY;
    private string _RSP_DUTY_STATUS;
    private string _RSP_SL_NO;
    private string _RSP_DESC;
    private string _RSP_QTY;
    private string _RSP_AMOUNT;
    private string _RSP_NOTN_NO;
    private string _RSP_NOTN_SL_NO;
    private string _RSP_ABT_RATE;


    #endregion


    #region Single_Window_Details_Private_Attributes

    private string _TERMS_PLACE,
                    _THIRDPARTY_NAME,
                    _THIRDPARTY_ADD1,
                    _THIRDPARTY_ADD2,
                    _THIRDPARTY_CITY,
                    _T_PARTY_COUNTRY_SUB_DIV,
                    _T_PARTY_COUNTRY_CODE,
                    _T_PARTY_PIN,
                    _AUTHORIZED_ECONOMIC_OPERATOR_CODE,
                    _A_E_O_COUNTRY,
                    _AUTHORIZED_ECONOMIC_OPERATOR,
                    _WHETHER_BUYER_SELLER_RELATED;
    #endregion


    #region Re_import_Details_Private_Attributes
    private string _RE_IMPORT_ID;
    private string _RE_IMPORT_SLNO;
    private string _ITEM_SLNO;
    private string _SCHEME_CODE_LICENSE;
    private string _INVOICE_SLNO;
    private string _SB_NO;
    private string _SB_DATE;
    private string _PORT_EXPORT;
    private string _SB_INVOICE_NO;
    private string _SB_INVOICE__ITEM_NO;
    private string _NOTN_NO;
    private string _NOTN_SLNO;
    private string _EXPORT_FREIGHT;
    private string _EXPORT_INSURANCE;
    private string _CUSTOMS_DUTY;
    private string _EXCISE_DUTY;
    private string _PAGE_NAME;
    private string _STATUS;

    #endregion

    #region License_Details_Private_Attributes

    private string _LICENSE_ID;
    private string _LICENSE_SLNO;
    private string _REGISTRATION_NO;
    private string _REGISTRATION_DATE;
    private string _EXCEMPTION;
    private string _DEBIT_AMT;
    private string _DEBIT_DUTY;
    private string _DEBIT_QTY;
    private string _UNIT_QTY;
    private string _LICENSE_ITEM_NO;
    private string _PORT_OF_LICENSE;
    private string _LICENSE_CURRENCY;
    private string _EX_RATE;

    private string _LICENSE_DATE;


    private string _TOTAL_CIF_VALUE;
    private string _TOTAL_DEBIT_DUTY;
    private string _ENTRY_CIF_VALUE;
    private string _ENTRY_DEBIT_DUTY;

    #endregion


    #region Item_CTH_Details_Private_Attributes
    private string _PRODUCT_RITC;
    private string _PRODUCT_CTH;
    private string _PRODUCT_BCD_NOTN;
    private string _PRODUCT_BCD_SLNO;
    private string _PRODUCT_BCD_RATE;
    private string _PRODUCT_BCD_SPL;
    private string _PRODUCT_BCD_UNIT;
    private string _PRODUCT_BCD_SPL_TYPE;
    private string _PRODUCT_ADDL_DUTY_NOTN;
    private string _PRODUCT_ADDL_DUTY_NOTN_SL;
    private string _PRODUCT_ADDL_DUTY_RATE;
    private string _PRODUCT_EDU_CESS_NOTN;
    private string _PRODUCT_EDU_CESS_NOTN_SL;
    private string _PRODUCT_EDU_CESS_RATE;
    private string _PRODUCT_SEC_EDU_CESS_NOTN;
    private string _PRODUCT_SEC_EDU_CESS_NOTN_SL;
    private string _PRODUCT_SEC_EDU_CESS_RATE;
    private string _PRODUCT_NCD_NOTN;
    private string _PRODUCT_NCD_SLNO;
    private string _PRODUCT_NCD_RATE;
    private string _PRODUCT_NCD_SPL;
    private string _PRODUCT_NCD_UNIT;
    private string _PRODUCT_NCD_SPL_TYPE;
    private string _PRODUCT_AGGREGATE_DUTY_NOTN;
    private string _PRODUCT_AGGREGATE_DUTY_NOTN_SL;
    private string _PRODUCT_AGGREGATE_DUTY_NOTN_RATE;
    private string _PRODUCT_SAFEGUARD_NOTN;
    private string _PRODUCT_SAFEGUARD_SLNO;
    private string _PRODUCT_SAFEGUARD_RATE;
    private string _PRODUCT_SAFEGUARD_SPL;
    private string _PRODUCT_SAFEGUARD_UNIT;
    private string _PRODUCT_SAFEGUARD_SPL_TYPE;
    private string _PRODUCT_SAPTA_NOTN;
    private string _PRODUCT_SAPTA_SLNO;
    private string _PRODUCT_SAPTA_RATE;
    private string _PRODUCT_TARIFF_NOTN;
    private string _PRODUCT_TARIFF_SLNO;
    private string _PRODUCT_TARIFF_QTY;
    private string _PRODUCT_TARIFF_AMOUNT;
    private string _PRODUCT_TARIFF_AMOUNT_UNIT;

    private string _SOCIAL_WELFARE_NOTN;
    private string _SOCIAL_WELFARE_NOTN_SLNO;
    private string _SOCIAL_WELFARE_RATE;

    private string _EXC_AIDC_NOTN;
    private string _EXC_AIDC_NOTN_SLNO;
    private string _EXC_AIDC_RATE;


    #endregion


    #region Item_CETH_Details_Private_Attributes
    private string _CETH_ID;

    private string _PRODUCT_CETH;
    private string _PRODUCT_MRP_YN;
    private string _PRODUCT_MRP_SL_NO;
    private string _PRODUCT_MRP_AMOUNT;
    private string _PRODUCT_MRP_ABT_RATE;
    private string _PRODUCT_CVD_NOTN;
    private string _PRODUCT_CVD_SLNO;
    private string _PRODUCT_CVD_RATE;
    private string _PRODUCT_CVD_SPL;
    private string _PRODUCT_CVD_UNIT;
    private string _PRODUCT_CVD_SPL_TYPE;
    private string _PRODUCT_CVD_EDU_CESS_RATE;
    private string _PRODUCT_CVD_SEC_EDU_CESS_RATE;
    private string _PRODUCT_ADDL5_SIA_NOTN;
    private string _PRODUCT_ADDL5_SIA_NOTN_SL;
    private string _PRODUCT_ADDL5_SIA_RATE;
    private string _PRODUCT_ADDL_GSI_NOTN;
    private string _PRODUCT_ADDL_GSI_SLNO;
    private string _PRODUCT_ADDL_GSI_RATE;
    private string _PRODUCT_ADDL_GSI_SPL;
    private string _PRODUCT_ADDL_GSI_UNIT;
    private string _PRODUCT_ADDL_GSI_SPL_TYPE;
    private string _PRODUCT_ADDL_SHEII_NOTN;
    private string _PRODUCT_ADDL_SHEII_SLNO;
    private string _PRODUCT_ADDL_SHEII_RATE;
    private string _PRODUCT_ADDL_SHEII_SPL;
    private string _PRODUCT_ADDL_SHEII_UNIT;
    private string _PRODUCT_ADDL_SHEII_TYPE;
    private string _PRODUCT_ADDL_TTA_NOTN;
    private string _PRODUCT_ADDL_TTA_SLNO;
    private string _PRODUCT_ADDL_TTA_RATE;
    private string _PRODUCT_ADDL_TTA_SPL;
    private string _PRODUCT_ADDL_TTA_UNIT;
    private string _PRODUCT_ADDL_TTA_TYPE;
    private string _PRODUCT_ADDL_HEALTH_CESS_NOTN;
    private string _PRODUCT_ADDL_HEALTH_CESS_SLNO;
    private string _PRODUCT_ADDL_HEALTH_CESS_RATE;
    private string _PRODUCT_ADDL_HEALTH_CESS_SPL;
    private string _PRODUCT_ADDL_HEALTH_CESS_UNIT;
    private string _PRODUCT_ADDL_HEALTH_CESS_TYPE;
    private string _PRODUCT_CESS_NOTN;
    private string _PRODUCT_CESS_SLNO;
    private string _PRODUCT_CESS_RATE;
    private string _PRODUCT_CESS_SPL;
    private string _PRODUCT_CESS_UNIT;
    private string _PRODUCT_CESS_TYPE;

    private string _PRODUCT_OTHER_DUTY_NOTN;
    private string _PRODUCT_OTHER_DUTY_SLNO;
    private string _PRODUCT_OTHER_DUTY_RATE;
    private string _PRODUCT_OTHER_DUTY_SPL;
    private string _PRODUCT_OTHER_DUTY_UNIT;
    private string _PRODUCT_OTHER_DUTY_TYPE;

    #endregion
    #region Item_General_Details_Private_Attributes
    private string _GENERAL_ID;

    private string _SCHEME_CODE;
    private string _SCHEME_NOTN;
    private string _SCHEME_NOTN_SLNO;
    private string _CTH_QTY1, _CTH_QTY1_CODE;
    private string _CTH_QTY2, _CTH_QTY2_CODE;
    private string _GENEARL_DESCRIPTION;
    private string _MANUFACTURER;
    private string _BRAND;
    private string _MODEL;
    private string _END_USE_OF_ITEM;
    private string _COUNTRY_OF_ORIGIN;
    private string _ACCESSORIES;
    private string _PREVIOUS_BE_NO;
    private string _PREVIOUS_BE_DATE;
    private string _UNIT_PRICE;
    private string _UNIT_CODE;
    private string _ITEM_CUSTOMS_HOUSE;
    #endregion

    #region Item_Main_Details_Private_Attributes
    private string _MAIN_ID;

    private string _ITEM_DESCRIPTION;
    private string _ITEM_QTY;
    private string _ITEM_QTY_CODE;

    private string _ITEM_UNIT_PRICE;
    private string _ITEM_UNIT_CODE;
    private string _ITEM_TOTAL_AMOUNT;
    private string _ITEM_AMOUNT_CODE;
    private string _CTH_NO;
    private string _ITEM_FOC_QTY;

    private string _WAREHOUSE_JOBNO;
    private string _WAREHOUSE_INVOICE_SLNO;
    private string _WAREHOUSE_ITEM_SLNO;
    private string _ASSESSABLE_VALUE;
    private string _DUTY_VALUE;
    private string _CIF_VALUE;
    private string _CVD_VALUE;
    private string _BASIC_VALUE;
    private string _CEC_VALUE;
    private string _CHEC_VALUE;
    private string _ADD_DUTY_VALUE;

    private string _INDIVITUAL_FREIGHT_AMOUNT;
    private string _INDIVITUAL_INSURANCE_AMOUNT;
    private string _INDIVITUAL_MISC_AMOUNT;

    private string _INDIVITUAL_EDU_CESS_AMT;
    private string _INDIVITUAL_SEC_HIGHER_CESS_AMT;
    private string _INDIVITUAL_LANDING_CHARGE;

    private string _ADDTIONAL_DUTY_RATE;

    private string _CHECKLIST_BCD_RATE;
    private string _CHECKLIST_CVD_RATE;
    private string _CHECKLIST_ADDL_DUTY_RATE;

    private string _MERIT_DUTY_VALUE;

    private string _MERIT_BASIC_VALUE;
    private string _MERIT_CVD_VALUE;
    private string _MERIT_CEC_VALUE;
    private string _MERIT_CHEC_VALUE;
    private string _MERIT_ADD_DUTY_VALUE;

    private string _MERIT_NOTN_BASIC_VALUE;
    private string _MERIT_NOTN_CVD_VALUE;
    private string _MERIT_NOTN_CEC_VALUE;
    private string _MERIT_NOTN_CHEC_VALUE;
    private string _MERIT_NOTN_ADD_DUTY_VALUE;
    private string _MERIT_NOTN_CESS_VALUE;
    private string _MERIT_NOTN_NCD_VALUE;
    private string _INDIVITUAL_HSS_AMOUNT;

    private string _CHECKLIST_IGST_LEVY_AMOUNT, _CHECKLIST_COMPENSATION_CC_AMOUNT;

    private string _Port_Orgin;
    private string _Port_Shipment;
    private string _Tr_Mode;
    private string _Cus_House;

    #endregion

    #endregion
    #region Public

    #region IGM Details_Public_Attributes
    public string IMP_EXP_TYPE { get { return _IMP_EXP_TYPE; } set { _IMP_EXP_TYPE = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string DB_NAME { get { return _DB_NAME; } set { _DB_NAME = value; } }

    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string LICENSE_NO { get { return _LICENSE_NO; } set { _LICENSE_NO = value; } }

    public string TYPE { get { return _TYPE; } set { _TYPE = value; } }

    public string IGM_SLNO_UPDATE { get { return _IGM_SLNO_UPDATE; } set { _IGM_SLNO_UPDATE = value; } }
    public string IGM_ID { get { return _IGM_ID; } set { _IGM_ID = value; } }
    public string IGM_JOBNO { get { return _IGM_JOBNO; } set { _IGM_JOBNO = value; } }
    public string IGM_JOBDATE { get { return _IGM_JOBDATE; } set { _IGM_JOBDATE = value; } }
    public string IGM_AIRLINECODE { get { return _IGM_AIRLINECODE; } set { _IGM_AIRLINECODE = value; } }
    public string IGM_AIRLINENAME { get { return _IGM_AIRLINENAME; } set { _IGM_AIRLINENAME = value; } }
    public string IGM_FLIGHTNO_VESSELNO { get { return _IGM_FLIGHTNO_VESSELNO; } set { _IGM_FLIGHTNO_VESSELNO = value; } }
    public string IGM_FLIGHT_VESSELDATE { get { return _IGM_FLIGHT_VESSELDATE; } set { _IGM_FLIGHT_VESSELDATE = value; } }
    public string IGM_NO { get { return _IGM_NO; } set { _IGM_NO = value; } }
    public string IGM_DATE { get { return _IGM_DATE; } set { _IGM_DATE = value; } }
    public string IGM_MAWB_MBL { get { return _IGM_MAWB_MBL; } set { _IGM_MAWB_MBL = value; } }
    public string IGM_MAWB_MBLDATE { get { return _IGM_MAWB_MBLDATE; } set { _IGM_MAWB_MBLDATE = value; } }
    public string IGM_HAWB_HBLNO { get { return _IGM_HAWB_HBLNO; } set { _IGM_HAWB_HBLNO = value; } }
    public string IGM_HAWB_HBLDATE { get { return _IGM_HAWB_HBLDATE; } set { _IGM_HAWB_HBLDATE = value; } }
    public string IGM_NOOFPACKAGE { get { return _IGM_NOOFPACKAGE; } set { _IGM_NOOFPACKAGE = value; } }
    public string IGM_PACKAGETYPE { get { return _IGM_PACKAGETYPE; } set { _IGM_PACKAGETYPE = value; } }
    public string IGM_GROSSWEIGHT { get { return _IGM_GROSSWEIGHT; } set { _IGM_GROSSWEIGHT = value; } }
    public string IGM_TYPEOFWEIGHT { get { return _IGM_TYPEOFWEIGHT; } set { _IGM_TYPEOFWEIGHT = value; } }
    public string IGM_NETWEIGHT { get { return _IGM_NETWEIGHT; } set { _IGM_NETWEIGHT = value; } }
    public string IGM_NETWEIGHTTYPE { get { return _IGM_NETWEIGHTTYPE; } set { _IGM_NETWEIGHTTYPE = value; } }
    public string IGM_MARKSNOS { get { return _IGM_MARKSNOS; } set { _IGM_MARKSNOS = value; } }
    public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }
    public string IGM_GATEWAY_IGM_NO { get { return _IGM_GATEWAY_IGM_NO; } set { _IGM_GATEWAY_IGM_NO = value; } }
    public string IGM_GATEWAY_IGM_DATE { get { return _IGM_GATEWAY_IGM_DATE; } set { _IGM_GATEWAY_IGM_DATE = value; } }
    public string IGM_GATEWAY_PORT_CODE { get { return _IGM_GATEWAY_PORT_CODE; } set { _IGM_GATEWAY_PORT_CODE = value; } }

    public string IGM_LINE_NUMBER { get { return _IGM_LINE_NUMBER; } set { _IGM_LINE_NUMBER = value; } }
    public string IGM_SHIPPING_LINE_NUMBER { get { return _IGM_SHIPPING_LINE_NUMBER; } set { _IGM_SHIPPING_LINE_NUMBER = value; } }
    public string IGM_VOYAGE { get { return _IGM_VOYAGE; } set { _IGM_VOYAGE = value; } }
    public string IGM_CHARGEABLE_WGT { get { return _IGM_CHARGEABLE_WGT; } set { _IGM_CHARGEABLE_WGT = value; } }
    public string ROTATION_NO { get { return _ROTATION_NO; } set { _ROTATION_NO = value; } }
    public string ROTATION_DATE { get { return _ROTATION_DATE; } set { _ROTATION_DATE = value; } }

    private string _JOBNO_PS;
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }

    #endregion

    #region GeneralDetails_Public_Attributes

    public string Name_Search { get { return _Name_Search; } set { _Name_Search = value; } }
    public string JOBID { get { return _JOBID; } set { _JOBID = value; } }

    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string CUSTOMS_HOUSE_NAME { get { return _CUSTOMS_HOUSE_NAME; } set { _CUSTOMS_HOUSE_NAME = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
    public string CONTAINER_TYPE { get { return _CONTAINER_TYPE; } set { _CONTAINER_TYPE = value; } }
    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string COUNTRY_ORIGIN { get { return _COUNTRY_ORIGIN; } set { _COUNTRY_ORIGIN = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }

    public string PORT_SHIPMENT { get { return _PORT_SHIPMENT; } set { _PORT_SHIPMENT = value; } }
    public string COUNTRY_SHIPMENT { get { return _COUNTRY_SHIPMENT; } set { _COUNTRY_SHIPMENT = value; } }
    public string FILING_STATUS { get { return _FILING_STATUS; } set { _FILING_STATUS = value; } }
    public string SECTION46 { get { return _SECTION46; } set { _SECTION46 = value; } }
    public string SECTION46_DESC { get { return _SECTION46_DESC; } set { _SECTION46_DESC = value; } }
    public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }
    public string FIRSTCHECK_DESC { get { return _FIRSTCHECK_DESC; } set { _FIRSTCHECK_DESC = value; } }
    public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
    public string GREEN_CHANNEL_DESC { get { return _GREEN_CHANNEL_DESC; } set { _GREEN_CHANNEL_DESC = value; } }
    public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
    public string KACHHA_BE_DESC { get { return _KACHHA_BE_DESC; } set { _KACHHA_BE_DESC = value; } }
    public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }
    public string SECTION48_DESC { get { return _SECTION48_DESC; } set { _SECTION48_DESC = value; } }
    public string HIGH_SEA_SALE { get { return _HIGH_SEA_SALE; } set { _HIGH_SEA_SALE = value; } }
    public string HIGH_SEA_SALE_NAME { get { return _HIGH_SEA_SALE_NAME; } set { _HIGH_SEA_SALE_NAME = value; } }
    public string HIGH_SEA_IEC { get { return _HIGH_SEA_IEC; } set { _HIGH_SEA_IEC = value; } }
    public string HIGH_SEA_BRANCH_SL_NO { get { return _HIGH_SEA_BRANCH_SL_NO; } set { _HIGH_SEA_BRANCH_SL_NO = value; } }
    public string HSS_ADD1 { get { return _HSS_ADD1; } set { _HSS_ADD1 = value; } }
    public string HSS_ADD2 { get { return _HSS_ADD2; } set { _HSS_ADD2 = value; } }
    public string HSS_ADD3 { get { return _HSS_ADD3; } set { _HSS_ADD3 = value; } }
    public string HSS_ADD4 { get { return _HSS_ADD4; } set { _HSS_ADD4 = value; } }
    public string HSS_ADD5 { get { return _HSS_ADD5; } set { _HSS_ADD5 = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
    public string WAREHOUSE_NAME { get { return _WAREHOUSE_NAME; } set { _WAREHOUSE_NAME = value; } }
    public string WAREHOUSE_CODE { get { return _WAREHOUSE_CODE; } set { _WAREHOUSE_CODE = value; } }
    public string HSS_ADCODE { get { return _HSS_ADCODE; } set { _HSS_ADCODE = value; } }
    public string ICE_ID { get { return _ICE_ID; } set { _ICE_ID = value; } }
    public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }
    public string PROVISIONAL { get { return _PROVISIONAL; } set { _PROVISIONAL = value; } }
    public string PROVISIONAL_DESC { get { return _PROVISIONAL_DESC; } set { _PROVISIONAL_DESC = value; } }


    public string COMMERCIAL_DETAILS_STATUS { get { return _COMMERCIAL_DETAILS_STATUS; } set { _COMMERCIAL_DETAILS_STATUS = value; } }
    public string COMMERCIAL_TAX_STATENAME { get { return _COMMERCIAL_TAX_STATENAME; } set { _COMMERCIAL_TAX_STATENAME = value; } }
    public string COMMERCIAL_TAX_STATECODE { get { return _COMMERCIAL_TAX_STATECODE; } set { _COMMERCIAL_TAX_STATECODE = value; } }
    public string COMMERCIAL_TAX_TYPE { get { return _COMMERCIAL_TAX_TYPE; } set { _COMMERCIAL_TAX_TYPE = value; } }
    public string COMMERCIAL_TAX_REGISTRATION_NO { get { return _COMMERCIAL_TAX_REGISTRATION_NO; } set { _COMMERCIAL_TAX_REGISTRATION_NO = value; } }
    public string EXBOND_INBOND_BE_NO { get { return _EXBOND_INBOND_BE_NO; } set { _EXBOND_INBOND_BE_NO = value; } }
    public string EXBOND_INBOND_BE_DATE { get { return _EXBOND_INBOND_BE_DATE; } set { _EXBOND_INBOND_BE_DATE = value; } }
    public string EXBOND_BOND_NO { get { return _EXBOND_BOND_NO; } set { _EXBOND_BOND_NO = value; } }
    public string EXBOND_BOND_DATE { get { return _EXBOND_BOND_DATE; } set { _EXBOND_BOND_DATE = value; } }
    public string EXBOND_WAREHOUSE_CUSTOMS { get { return _EXBOND_WAREHOUSE_CUSTOMS; } set { _EXBOND_WAREHOUSE_CUSTOMS = value; } }
    public string EXBOND_WAREHOUSE_CUSTOMS_CODE { get { return _EXBOND_WAREHOUSE_CUSTOMS_CODE; } set { _EXBOND_WAREHOUSE_CUSTOMS_CODE = value; } }
    public string EXBOND_NOOFPACKAGE { get { return _EXBOND_NOOFPACKAGE; } set { _EXBOND_NOOFPACKAGE = value; } }
    public string EXBOND_NOOFPACKAGE_UNITCODE { get { return _EXBOND_NOOFPACKAGE_UNITCODE; } set { _EXBOND_NOOFPACKAGE_UNITCODE = value; } }
    public string EXBOND_GROSS_WEIGHT { get { return _EXBOND_GROSS_WEIGHT; } set { _EXBOND_GROSS_WEIGHT = value; } }
    public string EXBOND_GROSS_WEIGHT_UNITCODE { get { return _EXBOND_GROSS_WEIGHT_UNITCODE; } set { _EXBOND_GROSS_WEIGHT_UNITCODE = value; } }
    public string EXBOND_DIRECT_EXBONDING { get { return _EXBOND_DIRECT_EXBONDING; } set { _EXBOND_DIRECT_EXBONDING = value; } }

    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string UCR_NO { get { return _UCR_NO; } set { _UCR_NO = value; } }
    public string UCR_TYPE { get { return _UCR_TYPE; } set { _UCR_TYPE = value; } }
    public string PAYMENT_METHOD_CODE { get { return _PAYMENT_METHOD_CODE; } set { _PAYMENT_METHOD_CODE = value; } }
    public string PRECEDING_LEVEL { get { return _PRECEDING_LEVEL; } set { _PRECEDING_LEVEL = value; } }
    public string ADCODE { get { return _ADCODE; } set { _ADCODE = value; } }

    public string EXBOND_ADDL_LOAD_HSS { get { return _EXBOND_ADDL_LOAD_HSS; } set { _EXBOND_ADDL_LOAD_HSS = value; } }
    public string EXBOND_MISC_LOAD_RATE { get { return _EXBOND_MISC_LOAD_RATE; } set { _EXBOND_MISC_LOAD_RATE = value; } }
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }


    #endregion

    #region Container Details_Public_Attributes


    public string CONTAINERID { get { return _CONTAINERID; } set { _CONTAINERID = value; } }

    public string CONTAINER_IGM_SLNO { get { return _CONTAINER_IGM_SLNO; } set { _CONTAINER_IGM_SLNO = value; } }
    public string CONTAINER_IGM_NO { get { return _CONTAINER_IGM_NO; } set { _CONTAINER_IGM_NO = value; } }
    public string CONTAINER_IGM_DATE { get { return _CONTAINER_IGM_DATE; } set { _CONTAINER_IGM_DATE = value; } }
    public string CONTAINER_NO { get { return _CONTAINER_NO; } set { _CONTAINER_NO = value; } }
    public string SEAL_NO { get { return _SEAL_NO; } set { _SEAL_NO = value; } }
    public string FCL_OR_LCL { get { return _FCL_OR_LCL; } set { _FCL_OR_LCL = value; } }

    #endregion

    #region Bond Details_Public_Attributes

    public string BONDID { get { return _BONDID; } set { _BONDID = value; } }

    public string BOND_NO { get { return _BOND_NO; } set { _BOND_NO = value; } }
    public string BOND_TYPE { get { return _BOND_TYPE; } set { _BOND_TYPE = value; } }
    public string BOND_LOCATION { get { return _BOND_LOCATION; } set { _BOND_LOCATION = value; } }


    #endregion

    #region Certificate Details_Public_Attributes

    public string CERTIFICATEID { get { return _CERTIFICATEID; } set { _CERTIFICATEID = value; } }

    public string CERTIFICATE_NO { get { return _CERTIFICATE_NO; } set { _CERTIFICATE_NO = value; } }
    public string CERTIFICATE_DATE { get { return _CERTIFICATE_DATE; } set { _CERTIFICATE_DATE = value; } }
    public string CERTIFICATE_TYPE { get { return _CERTIFICATE_TYPE; } set { _CERTIFICATE_TYPE = value; } }


    #endregion

    #region SVB Details_Public_Attributes
    public string SVB_ID { get { return _SVB_ID; } set { _SVB_ID = value; } }

    public string SVB_RELATION { get { return _SVB_RELATION; } set { _SVB_RELATION = value; } }
    public string SVB_REF_NO { get { return _SVB_REF_NO; } set { _SVB_REF_NO = value; } }
    public string SVB_REF_DATE { get { return _SVB_REF_DATE; } set { _SVB_REF_DATE = value; } }
    public string SVB_CUSTOM_HOUSE { get { return _SVB_CUSTOM_HOUSE; } set { _SVB_CUSTOM_HOUSE = value; } }
    public string SVB_LOADING_ON { get { return _SVB_LOADING_ON; } set { _SVB_LOADING_ON = value; } }
    public string SVB_ASSESABLE_RATE { get { return _SVB_ASSESABLE_RATE; } set { _SVB_ASSESABLE_RATE = value; } }
    public string SVB_DUTY_RATE { get { return _SVB_DUTY_RATE; } set { _SVB_DUTY_RATE = value; } }
    public string SVB_ASSESABLE_STATUS { get { return _SVB_ASSESABLE_STATUS; } set { _SVB_ASSESABLE_STATUS = value; } }
    public string SVB_DUTY_STATUS { get { return _SVB_DUTY_STATUS; } set { _SVB_DUTY_STATUS = value; } }

    #endregion

    #region Invoice_Other Charges Details_Public_Attributes

    public string A_AMOUNT { get { return _A_AMOUNT; } set { _A_AMOUNT = value; } }
    public string B_AMOUNT { get { return _B_AMOUNT; } set { _B_AMOUNT = value; } }
    public string C_AMOUNT { get { return _C_AMOUNT; } set { _C_AMOUNT = value; } }
    public string D_AMOUNT { get { return _D_AMOUNT; } set { _D_AMOUNT = value; } }
    public string E_AMOUNT { get { return _E_AMOUNT; } set { _E_AMOUNT = value; } }
    public string F_AMOUNT { get { return _F_AMOUNT; } set { _F_AMOUNT = value; } }
    public string G_AMOUNT { get { return _G_AMOUNT; } set { _G_AMOUNT = value; } }
    public string H_AMOUNT { get { return _H_AMOUNT; } set { _H_AMOUNT = value; } }
    public string I_AMOUNT { get { return _I_AMOUNT; } set { _I_AMOUNT = value; } }
    public string J_AMOUNT { get { return _J_AMOUNT; } set { _J_AMOUNT = value; } }
    public string K_AMOUNT { get { return _K_AMOUNT; } set { _K_AMOUNT = value; } }
    public string L_AMOUNT { get { return _L_AMOUNT; } set { _L_AMOUNT = value; } }
    public string M_AMOUNT { get { return _M_AMOUNT; } set { _M_AMOUNT = value; } }
    public string N_AMOUNT { get { return _N_AMOUNT; } set { _N_AMOUNT = value; } }
    public string TOTAL_OTHER_AMOUNT { get { return _TOTAL_OTHER_AMOUNT; } set { _TOTAL_OTHER_AMOUNT = value; } }

    #endregion

    #region INVOICE_MAIN_Details_Public_Attributes
    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }

    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string TERMS { get { return _TERMS; } set { _TERMS = value; } }
    public string INVOICE_CURRENCY { get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }

    public string INVOICE_EXRATE { get { return _INVOICE_EXRATE; } set { _INVOICE_EXRATE = value; } }
    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string NON_STD_EFFECT_DT_IMP { get { return _NON_STD_EFFECT_DT_IMP; } set { _NON_STD_EFFECT_DT_IMP = value; } }
    public string NON_STD_BANKNAME { get { return _NON_STD_BANKNAME; } set { _NON_STD_BANKNAME = value; } }
    public string NON_STD_CERTIFICATE_NO { get { return _NON_STD_CERTIFICATE_NO; } set { _NON_STD_CERTIFICATE_NO = value; } }
    public string NON_STD_CERTIFICATE_DATE { get { return _NON_STD_CERTIFICATE_DATE; } set { _NON_STD_CERTIFICATE_DATE = value; } }


    public string SAP_DELIEVERY_ID { get { return _SAP_DELIEVERY_ID; } set { _SAP_DELIEVERY_ID = value; } }
    public string SHIP_DATE { get { return _SHIP_DATE; } set { _SHIP_DATE = value; } }
    public string INVOICE_LEVEL { get { return _INVOICE_LEVEL; } set { _INVOICE_LEVEL = value; } }
    public string COUNTRY_OF_DEPARTURE { get { return _COUNTRY_OF_DEPARTURE; } set { _COUNTRY_OF_DEPARTURE = value; } }

    public string REVENUEDEPOSIT_RATE { get { return _REVENUEDEPOSIT_RATE; } set { _REVENUEDEPOSIT_RATE = value; } }
    public string REVENUEDEPOSIT_ON { get { return _REVENUEDEPOSIT_ON; } set { _REVENUEDEPOSIT_ON = value; } }

    #endregion

    #region MISC_Details_Public_Attributes
    public string MIS_ID { get { return _MIS_ID; } set { _MIS_ID = value; } }

    public string MIS_CHARGES { get { return _MIS_CHARGES; } set { _MIS_CHARGES = value; } }
    public string MIS_RATE { get { return _MIS_RATE; } set { _MIS_RATE = value; } }
    public string MIS_CURRENCY { get { return _MIS_CURRENCY; } set { _MIS_CURRENCY = value; } }
    public string MIS_EXRATE { get { return _MIS_EXRATE; } set { _MIS_EXRATE = value; } }
    public string MIS_AGENCY_CHARGES { get { return _MIS_AGENCY_CHARGES; } set { _MIS_AGENCY_CHARGES = value; } }
    public string MIS_AGENCY_RATE { get { return _MIS_AGENCY_RATE; } set { _MIS_AGENCY_RATE = value; } }
    public string MIS_AGENCY_CURRENCY { get { return _MIS_AGENCY_CURRENCY; } set { _MIS_AGENCY_CURRENCY = value; } }
    public string MIS_AGENCY_EXRATE { get { return _MIS_AGENCY_EXRATE; } set { _MIS_AGENCY_EXRATE = value; } }
    public string MIS_DISCOUNT_CHARGES { get { return _MIS_DISCOUNT_CHARGES; } set { _MIS_DISCOUNT_CHARGES = value; } }
    public string MIS_DISCOUNT_RATE { get { return _MIS_DISCOUNT_RATE; } set { _MIS_DISCOUNT_RATE = value; } }
    public string MIS_DISCOUNT_CURRENCY { get { return _MIS_DISCOUNT_CURRENCY; } set { _MIS_DISCOUNT_CURRENCY = value; } }
    public string MIS_DISCOUNT_EXRATE { get { return _MIS_DISCOUNT_EXRATE; } set { _MIS_DISCOUNT_EXRATE = value; } }
    public string MIS_DISCOUNT_REASON { get { return _MIS_DISCOUNT_REASON; } set { _MIS_DISCOUNT_REASON = value; } }
    public string MIS_LOADING_CHARGES { get { return _MIS_LOADING_CHARGES; } set { _MIS_LOADING_CHARGES = value; } }
    public string MIS_LOADING_RATE { get { return _MIS_LOADING_RATE; } set { _MIS_LOADING_RATE = value; } }
    public string MIS_LOADING_CURRENCY { get { return _MIS_LOADING_CURRENCY; } set { _MIS_LOADING_CURRENCY = value; } }
    public string MIS_LOADING_EXRATE { get { return _MIS_LOADING_EXRATE; } set { _MIS_LOADING_EXRATE = value; } }
    public string MIS_FREIGHT_CHARGES { get { return _MIS_FREIGHT_CHARGES; } set { _MIS_FREIGHT_CHARGES = value; } }
    public string MIS_FREIGHT_RATE { get { return _MIS_FREIGHT_RATE; } set { _MIS_FREIGHT_RATE = value; } }
    public string MIS_FREIGHT_CURRENCY { get { return _MIS_FREIGHT_CURRENCY; } set { _MIS_FREIGHT_CURRENCY = value; } }
    public string MIS_FREIGHT_EXRATE { get { return _MIS_FREIGHT_EXRATE; } set { _MIS_FREIGHT_EXRATE = value; } }
    public string MIS_INSURANCE_CHARGES { get { return _MIS_INSURANCE_CHARGES; } set { _MIS_INSURANCE_CHARGES = value; } }
    public string MIS_INSURANCE_RATE { get { return _MIS_INSURANCE_RATE; } set { _MIS_INSURANCE_RATE = value; } }
    public string MIS_INSURANCE_CURRENCY { get { return _MIS_INSURANCE_CURRENCY; } set { _MIS_INSURANCE_CURRENCY = value; } }
    public string MIS_INSURANCE_EXRATE { get { return _MIS_INSURANCE_EXRATE; } set { _MIS_INSURANCE_EXRATE = value; } }
    public string MIS_HIGHSEASALE_CHARGES { get { return _MIS_HIGHSEASALE_CHARGES; } set { _MIS_HIGHSEASALE_CHARGES = value; } }
    public string MIS_HIGHSEASALE_RATE { get { return _MIS_HIGHSEASALE_RATE; } set { _MIS_HIGHSEASALE_RATE = value; } }
    public string MIS_HIGHSEASALE_CURRENCY { get { return _MIS_HIGHSEASALE_CURRENCY; } set { _MIS_HIGHSEASALE_CURRENCY = value; } }
    public string MIS_HIGHSEASALE_EXRATE { get { return _MIS_HIGHSEASALE_EXRATE; } set { _MIS_HIGHSEASALE_EXRATE = value; } }
    public string MIS_SINGLE_OR_MULITIPLE { get { return _MIS_SINGLE_OR_MULITIPLE; } set { _MIS_SINGLE_OR_MULITIPLE = value; } }
    #endregion
    #region Other_Details_Public_Attributes
    public string OTHER_ID { get { return _OTHER_ID; } set { _OTHER_ID = value; } }

    public string OTHER_PURCHASE_ORDER { get { return _OTHER_PURCHASE_ORDER; } set { _OTHER_PURCHASE_ORDER = value; } }
    public string OTHER_PURCHASE_ORDER_DATE { get { return _OTHER_PURCHASE_ORDER_DATE; } set { _OTHER_PURCHASE_ORDER_DATE = value; } }
    public string OTHER_CONTRACT_NO { get { return _OTHER_CONTRACT_NO; } set { _OTHER_CONTRACT_NO = value; } }
    public string OTHER_CONTRACT_DATE { get { return _OTHER_CONTRACT_DATE; } set { _OTHER_CONTRACT_DATE = value; } }
    public string OTHER_LOC_NO { get { return _OTHER_LOC_NO; } set { _OTHER_LOC_NO = value; } }
    public string OTHER_LOC_DATE { get { return _OTHER_LOC_DATE; } set { _OTHER_LOC_DATE = value; } }
    public string OTHER_NATURE_OF_TRANSACTION { get { return _OTHER_NATURE_OF_TRANSACTION; } set { _OTHER_NATURE_OF_TRANSACTION = value; } }
    public string OTHER_TERMS_OF_PAYMENT { get { return _OTHER_TERMS_OF_PAYMENT; } set { _OTHER_TERMS_OF_PAYMENT = value; } }
    public string OTHER_CONDITIONS { get { return _OTHER_CONDITIONS; } set { _OTHER_CONDITIONS = value; } }
    public string OTHER_VALUATION_METHOD { get { return _OTHER_VALUATION_METHOD; } set { _OTHER_VALUATION_METHOD = value; } }
    #endregion
    #region Supplier_Details_Public_Attributes
    public string SUPPLIER_ID { get { return _SUPPLIER_ID; } set { _SUPPLIER_ID = value; } }

    public string SUPPLIER_NAME { get { return _SUPPLIER_NAME; } set { _SUPPLIER_NAME = value; } }
    public string SUPPLIER_ADDRESS { get { return _SUPPLIER_ADDRESS; } set { _SUPPLIER_ADDRESS = value; } }
    public string SUPPLIER_ADDRESS1 { get { return _SUPPLIER_ADDRESS1; } set { _SUPPLIER_ADDRESS1 = value; } }
    public string SUPPLIER_ADDRESS2 { get { return _SUPPLIER_ADDRESS2; } set { _SUPPLIER_ADDRESS2 = value; } }
    public string SUPPLIER_ADDRESS3 { get { return _SUPPLIER_ADDRESS3; } set { _SUPPLIER_ADDRESS3 = value; } }
    public string SUPPLIER_COUNTRY_NAME { get { return _SUPPLIER_COUNTRY_NAME; } set { _SUPPLIER_COUNTRY_NAME = value; } }
    public string SUPPLIER_COUNTRY_CODE { get { return _SUPPLIER_COUNTRY_CODE; } set { _SUPPLIER_COUNTRY_CODE = value; } }
    public string SUPPLIER_COUNTRY_PINCODE { get { return _SUPPLIER_COUNTRY_PINCODE; } set { _SUPPLIER_COUNTRY_PINCODE = value; } }
    public string SELLER_NAME { get { return _SELLER_NAME; } set { _SELLER_NAME = value; } }
    public string SELLER_ADDRESS { get { return _SELLER_ADDRESS; } set { _SELLER_ADDRESS = value; } }
    public string SELLER_ADDRESS1 { get { return _SELLER_ADDRESS1; } set { _SELLER_ADDRESS1 = value; } }
    public string SELLER_ADDRESS2 { get { return _SELLER_ADDRESS2; } set { _SELLER_ADDRESS2 = value; } }
    public string SELLER_ADDRESS3 { get { return _SELLER_ADDRESS3; } set { _SELLER_ADDRESS3 = value; } }
    public string SELLER_COUNTRY_NAME { get { return _SELLER_COUNTRY_NAME; } set { _SELLER_COUNTRY_NAME = value; } }
    public string SELLER_COUNTRY_CODE { get { return _SELLER_COUNTRY_CODE; } set { _SELLER_COUNTRY_CODE = value; } }
    public string SELLERCOUNTRY_PINCODE { get { return _SELLERCOUNTRY_PINCODE; } set { _SELLERCOUNTRY_PINCODE = value; } }
    public string BROKER_NAME { get { return _BROKER_NAME; } set { _BROKER_NAME = value; } }
    public string BROKER_ADDRESS { get { return _BROKER_ADDRESS; } set { _BROKER_ADDRESS = value; } }
    public string BROKER_ADDRESS1 { get { return _BROKER_ADDRESS1; } set { _BROKER_ADDRESS1 = value; } }
    public string BROKER_ADDRESS2 { get { return _BROKER_ADDRESS2; } set { _BROKER_ADDRESS2 = value; } }
    public string BROKER_ADDRESS3 { get { return _BROKER_ADDRESS3; } set { _BROKER_ADDRESS3 = value; } }
    public string BROKER_COUNTRY_NAME { get { return _BROKER_COUNTRY_NAME; } set { _BROKER_COUNTRY_NAME = value; } }
    public string BROKER_COUNTRY_CODE { get { return _BROKER_COUNTRY_CODE; } set { _BROKER_COUNTRY_CODE = value; } }
    public string BROKER_COUNTRY_PINCODE { get { return _BROKER_COUNTRY_PINCODE; } set { _BROKER_COUNTRY_PINCODE = value; } }
    #endregion
    #region Otherduty_Details_Public_Attributes
    public string DUTY_ID { get { return _DUTY_ID; } set { _DUTY_ID = value; } }

    public string ANTI_DUMPING_NOTN { get { return _ANTI_DUMPING_NOTN; } set { _ANTI_DUMPING_NOTN = value; } }
    public string ANTI_DUMPING_NOTN_SLNO { get { return _ANTI_DUMPING_NOTN_SLNO; } set { _ANTI_DUMPING_NOTN_SLNO = value; } }
    public string CTH_SLNO { get { return _CTH_SLNO; } set { _CTH_SLNO = value; } }
    public string CTH_SUPPLIER_SLNO { get { return _CTH_SUPPLIER_SLNO; } set { _CTH_SUPPLIER_SLNO = value; } }
    public string CTH_QTY { get { return _CTH_QTY; } set { _CTH_QTY = value; } }
    public string RSP_DUTY_STATUS { get { return _RSP_DUTY_STATUS; } set { _RSP_DUTY_STATUS = value; } }


    public string RSP_SL_NO { get { return _RSP_SL_NO; } set { _RSP_SL_NO = value; } }
    public string RSP_DESC { get { return _RSP_DESC; } set { _RSP_DESC = value; } }
    public string RSP_QTY { get { return _RSP_QTY; } set { _RSP_QTY = value; } }
    public string RSP_AMOUNT { get { return _RSP_AMOUNT; } set { _RSP_AMOUNT = value; } }
    public string RSP_NOTN_NO { get { return _RSP_NOTN_NO; } set { _RSP_NOTN_NO = value; } }
    public string RSP_NOTN_SL_NO { get { return _RSP_NOTN_SL_NO; } set { _RSP_NOTN_SL_NO = value; } }
    public string RSP_ABT_RATE { get { return _RSP_ABT_RATE; } set { _RSP_ABT_RATE = value; } }



    #endregion

    #region Single_Window_Details_Public_Attributes

    public string TERMS_PLACE { get { return _TERMS_PLACE; } set { _TERMS_PLACE = value; } }
    public string THIRDPARTY_NAME { get { return _THIRDPARTY_NAME; } set { _THIRDPARTY_NAME = value; } }
    public string THIRDPARTY_ADD1 { get { return _THIRDPARTY_ADD1; } set { _THIRDPARTY_ADD1 = value; } }
    public string THIRDPARTY_ADD2 { get { return _THIRDPARTY_ADD2; } set { _THIRDPARTY_ADD2 = value; } }
    public string THIRDPARTY_CITY { get { return _THIRDPARTY_CITY; } set { _THIRDPARTY_CITY = value; } }
    public string T_PARTY_COUNTRY_SUB_DIV { get { return _T_PARTY_COUNTRY_SUB_DIV; } set { _T_PARTY_COUNTRY_SUB_DIV = value; } }
    public string T_PARTY_COUNTRY_CODE { get { return _T_PARTY_COUNTRY_CODE; } set { _T_PARTY_COUNTRY_CODE = value; } }
    public string T_PARTY_PIN { get { return _T_PARTY_PIN; } set { _T_PARTY_PIN = value; } }
    public string AUTHORIZED_ECONOMIC_OPERATOR_CODE { get { return _AUTHORIZED_ECONOMIC_OPERATOR_CODE; } set { _AUTHORIZED_ECONOMIC_OPERATOR_CODE = value; } }
    public string A_E_O_COUNTRY { get { return _A_E_O_COUNTRY; } set { _A_E_O_COUNTRY = value; } }
    public string AUTHORIZED_ECONOMIC_OPERATOR { get { return _AUTHORIZED_ECONOMIC_OPERATOR; } set { _AUTHORIZED_ECONOMIC_OPERATOR = value; } }
    public string WHETHER_BUYER_SELLER_RELATED { get { return _WHETHER_BUYER_SELLER_RELATED; } set { _WHETHER_BUYER_SELLER_RELATED = value; } }


    #endregion

    #region Re_import_Details_Public_Attributes
    public string RE_IMPORT_ID { get { return _RE_IMPORT_ID; } set { _RE_IMPORT_ID = value; } }
    public string RE_IMPORT_SLNO { get { return _RE_IMPORT_SLNO; } set { _RE_IMPORT_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string SCHEME_CODE_LICENSE { get { return _SCHEME_CODE_LICENSE; } set { _SCHEME_CODE_LICENSE = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }

    public string SB_NO { get { return _SB_NO; } set { _SB_NO = value; } }
    public string SB_DATE { get { return _SB_DATE; } set { _SB_DATE = value; } }
    public string PORT_EXPORT { get { return _PORT_EXPORT; } set { _PORT_EXPORT = value; } }
    public string SB_INVOICE_NO { get { return _SB_INVOICE_NO; } set { _SB_INVOICE_NO = value; } }
    public string SB_INVOICE__ITEM_NO { get { return _SB_INVOICE__ITEM_NO; } set { _SB_INVOICE__ITEM_NO = value; } }
    public string NOTN_NO { get { return _NOTN_NO; } set { _NOTN_NO = value; } }
    public string NOTN_SLNO { get { return _NOTN_SLNO; } set { _NOTN_SLNO = value; } }
    public string EXPORT_FREIGHT { get { return _EXPORT_FREIGHT; } set { _EXPORT_FREIGHT = value; } }
    public string EXPORT_INSURANCE { get { return _EXPORT_INSURANCE; } set { _EXPORT_INSURANCE = value; } }
    public string CUSTOMS_DUTY { get { return _CUSTOMS_DUTY; } set { _CUSTOMS_DUTY = value; } }
    public string EXCISE_DUTY { get { return _EXCISE_DUTY; } set { _EXCISE_DUTY = value; } }

    public string PAGE_NAME { get { return _PAGE_NAME; } set { _PAGE_NAME = value; } }
    public string STATUS { get { return _STATUS; } set { _STATUS = value; } }

    #endregion

    #region License_Details_Public_Attributes
    public string LICENSE_ID { get { return _LICENSE_ID; } set { _LICENSE_ID = value; } }
    public string LICENSE_SLNO { get { return _LICENSE_SLNO; } set { _LICENSE_SLNO = value; } }
    public string REGISTRATION_NO { get { return _REGISTRATION_NO; } set { _REGISTRATION_NO = value; } }
    public string REGISTRATION_DATE { get { return _REGISTRATION_DATE; } set { _REGISTRATION_DATE = value; } }
    public string EXCEMPTION { get { return _EXCEMPTION; } set { _EXCEMPTION = value; } }
    public string DEBIT_AMT { get { return _DEBIT_AMT; } set { _DEBIT_AMT = value; } }
    public string DEBIT_DUTY { get { return _DEBIT_DUTY; } set { _DEBIT_DUTY = value; } }
    public string LICENSE_CURRENCY { get { return _LICENSE_CURRENCY; } set { _LICENSE_CURRENCY = value; } }
    public string EX_RATE { get { return _EX_RATE; } set { _EX_RATE = value; } }

    public string DEBIT_QTY { get { return _DEBIT_QTY; } set { _DEBIT_QTY = value; } }
    public string UNIT_QTY { get { return _UNIT_QTY; } set { _UNIT_QTY = value; } }
    public string LICENSE_ITEM_NO { get { return _LICENSE_ITEM_NO; } set { _LICENSE_ITEM_NO = value; } }
    public string PORT_OF_LICENSE { get { return _PORT_OF_LICENSE; } set { _PORT_OF_LICENSE = value; } }

    public string LICENSE_DATE { get { return _LICENSE_DATE; } set { _LICENSE_DATE = value; } }

    public string TOTAL_CIF_VALUE { get { return _TOTAL_CIF_VALUE; } set { _TOTAL_CIF_VALUE = value; } }
    public string TOTAL_DEBIT_DUTY { get { return _TOTAL_DEBIT_DUTY; } set { _TOTAL_DEBIT_DUTY = value; } }
    public string ENTRY_CIF_VALUE { get { return _ENTRY_CIF_VALUE; } set { _ENTRY_CIF_VALUE = value; } }
    public string ENTRY_DEBIT_DUTY { get { return _ENTRY_DEBIT_DUTY; } set { _ENTRY_DEBIT_DUTY = value; } }

    #endregion

    #region Item_CTH_Details_Public_Attributes
    public string PRODUCT_RITC { get { return _PRODUCT_RITC; } set { _PRODUCT_RITC = value; } }
    public string PRODUCT_CTH { get { return _PRODUCT_CTH; } set { _PRODUCT_CTH = value; } }
    public string PRODUCT_BCD_NOTN { get { return _PRODUCT_BCD_NOTN; } set { _PRODUCT_BCD_NOTN = value; } }
    public string PRODUCT_BCD_SLNO { get { return _PRODUCT_BCD_SLNO; } set { _PRODUCT_BCD_SLNO = value; } }
    public string PRODUCT_BCD_RATE { get { return _PRODUCT_BCD_RATE; } set { _PRODUCT_BCD_RATE = value; } }
    public string PRODUCT_BCD_SPL { get { return _PRODUCT_BCD_SPL; } set { _PRODUCT_BCD_SPL = value; } }
    public string PRODUCT_BCD_UNIT { get { return _PRODUCT_BCD_UNIT; } set { _PRODUCT_BCD_UNIT = value; } }
    public string PRODUCT_BCD_SPL_TYPE { get { return _PRODUCT_BCD_SPL_TYPE; } set { _PRODUCT_BCD_SPL_TYPE = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN { get { return _PRODUCT_ADDL_DUTY_NOTN; } set { _PRODUCT_ADDL_DUTY_NOTN = value; } }
    public string PRODUCT_ADDL_DUTY_RATE { get { return _PRODUCT_ADDL_DUTY_RATE; } set { _PRODUCT_ADDL_DUTY_RATE = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN_SL { get { return _PRODUCT_ADDL_DUTY_NOTN_SL; } set { _PRODUCT_ADDL_DUTY_NOTN_SL = value; } }
    public string PRODUCT_EDU_CESS_NOTN { get { return _PRODUCT_EDU_CESS_NOTN; } set { _PRODUCT_EDU_CESS_NOTN = value; } }
    public string PRODUCT_EDU_CESS_NOTN_SL { get { return _PRODUCT_EDU_CESS_NOTN_SL; } set { _PRODUCT_EDU_CESS_NOTN_SL = value; } }
    public string PRODUCT_EDU_CESS_RATE { get { return _PRODUCT_EDU_CESS_RATE; } set { _PRODUCT_EDU_CESS_RATE = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN { get { return _PRODUCT_SEC_EDU_CESS_NOTN; } set { _PRODUCT_SEC_EDU_CESS_NOTN = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN_SL { get { return _PRODUCT_SEC_EDU_CESS_NOTN_SL; } set { _PRODUCT_SEC_EDU_CESS_NOTN_SL = value; } }
    public string PRODUCT_SEC_EDU_CESS_RATE { get { return _PRODUCT_SEC_EDU_CESS_RATE; } set { _PRODUCT_SEC_EDU_CESS_RATE = value; } }
    public string PRODUCT_NCD_NOTN { get { return _PRODUCT_NCD_NOTN; } set { _PRODUCT_NCD_NOTN = value; } }
    public string PRODUCT_NCD_SLNO { get { return _PRODUCT_NCD_SLNO; } set { _PRODUCT_NCD_SLNO = value; } }
    public string PRODUCT_NCD_RATE { get { return _PRODUCT_NCD_RATE; } set { _PRODUCT_NCD_RATE = value; } }
    public string PRODUCT_NCD_SPL { get { return _PRODUCT_NCD_SPL; } set { _PRODUCT_NCD_SPL = value; } }
    public string PRODUCT_NCD_UNIT { get { return _PRODUCT_NCD_UNIT; } set { _PRODUCT_NCD_UNIT = value; } }
    public string PRODUCT_NCD_SPL_TYPE { get { return _PRODUCT_NCD_SPL_TYPE; } set { _PRODUCT_NCD_SPL_TYPE = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN { get { return _PRODUCT_AGGREGATE_DUTY_NOTN; } set { _PRODUCT_AGGREGATE_DUTY_NOTN = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN_SL { get { return _PRODUCT_AGGREGATE_DUTY_NOTN_SL; } set { _PRODUCT_AGGREGATE_DUTY_NOTN_SL = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN_RATE { get { return _PRODUCT_AGGREGATE_DUTY_NOTN_RATE; } set { _PRODUCT_AGGREGATE_DUTY_NOTN_RATE = value; } }
    public string PRODUCT_SAFEGUARD_NOTN { get { return _PRODUCT_SAFEGUARD_NOTN; } set { _PRODUCT_SAFEGUARD_NOTN = value; } }
    public string PRODUCT_SAFEGUARD_SLNO { get { return _PRODUCT_SAFEGUARD_SLNO; } set { _PRODUCT_SAFEGUARD_SLNO = value; } }
    public string PRODUCT_SAFEGUARD_RATE { get { return _PRODUCT_SAFEGUARD_RATE; } set { _PRODUCT_SAFEGUARD_RATE = value; } }
    public string PRODUCT_SAFEGUARD_SPL { get { return _PRODUCT_SAFEGUARD_SPL; } set { _PRODUCT_SAFEGUARD_SPL = value; } }
    public string PRODUCT_SAFEGUARD_UNIT { get { return _PRODUCT_SAFEGUARD_UNIT; } set { _PRODUCT_SAFEGUARD_UNIT = value; } }
    public string PRODUCT_SAFEGUARD_SPL_TYPE { get { return _PRODUCT_SAFEGUARD_SPL_TYPE; } set { _PRODUCT_SAFEGUARD_SPL_TYPE = value; } }
    public string PRODUCT_SAPTA_NOTN { get { return _PRODUCT_SAPTA_NOTN; } set { _PRODUCT_SAPTA_NOTN = value; } }
    public string PRODUCT_SAPTA_SLNO { get { return _PRODUCT_SAPTA_SLNO; } set { _PRODUCT_SAPTA_SLNO = value; } }
    public string PRODUCT_SAPTA_RATE { get { return _PRODUCT_SAPTA_RATE; } set { _PRODUCT_SAPTA_RATE = value; } }
    public string PRODUCT_TARIFF_NOTN { get { return _PRODUCT_TARIFF_NOTN; } set { _PRODUCT_TARIFF_NOTN = value; } }
    public string PRODUCT_TARIFF_SLNO { get { return _PRODUCT_TARIFF_SLNO; } set { _PRODUCT_TARIFF_SLNO = value; } }
    public string PRODUCT_TARIFF_QTY { get { return _PRODUCT_TARIFF_QTY; } set { _PRODUCT_TARIFF_QTY = value; } }
    public string PRODUCT_TARIFF_AMOUNT { get { return _PRODUCT_TARIFF_AMOUNT; } set { _PRODUCT_TARIFF_AMOUNT = value; } }
    public string PRODUCT_TARIFF_AMOUNT_UNIT { get { return _PRODUCT_TARIFF_AMOUNT_UNIT; } set { _PRODUCT_TARIFF_AMOUNT_UNIT = value; } }


    public string SOCIAL_WELFARE_NOTN { get { return _SOCIAL_WELFARE_NOTN; } set { _SOCIAL_WELFARE_NOTN = value; } }
    public string SOCIAL_WELFARE_NOTN_SLNO { get { return _SOCIAL_WELFARE_NOTN_SLNO; } set { _SOCIAL_WELFARE_NOTN_SLNO = value; } }
    public string SOCIAL_WELFARE_RATE { get { return _SOCIAL_WELFARE_RATE; } set { _SOCIAL_WELFARE_RATE = value; } }

    public string EXC_AIDC_NOTN { get { return _EXC_AIDC_NOTN; } set { _EXC_AIDC_NOTN = value; } }
    public string EXC_AIDC_NOTN_SLNO { get { return _EXC_AIDC_NOTN_SLNO; } set { _EXC_AIDC_NOTN_SLNO = value; } }
    public string EXC_AIDC_RATE { get { return _EXC_AIDC_RATE; } set { _EXC_AIDC_RATE = value; } }

    #endregion

    #region Item_CETH_Details_Public_Attributes
    public string CETH_ID { get { return _CETH_ID; } set { _CETH_ID = value; } }

    public string PRODUCT_CETH { get { return _PRODUCT_CETH; } set { _PRODUCT_CETH = value; } }
    public string PRODUCT_MRP_YN { get { return _PRODUCT_MRP_YN; } set { _PRODUCT_MRP_YN = value; } }
    public string PRODUCT_MRP_SL_NO { get { return _PRODUCT_MRP_SL_NO; } set { _PRODUCT_MRP_SL_NO = value; } }
    public string PRODUCT_MRP_AMOUNT { get { return _PRODUCT_MRP_AMOUNT; } set { _PRODUCT_MRP_AMOUNT = value; } }
    public string PRODUCT_MRP_ABT_RATE { get { return _PRODUCT_MRP_ABT_RATE; } set { _PRODUCT_MRP_ABT_RATE = value; } }
    public string PRODUCT_CVD_NOTN { get { return _PRODUCT_CVD_NOTN; } set { _PRODUCT_CVD_NOTN = value; } }
    public string PRODUCT_CVD_SLNO { get { return _PRODUCT_CVD_SLNO; } set { _PRODUCT_CVD_SLNO = value; } }
    public string PRODUCT_CVD_RATE { get { return _PRODUCT_CVD_RATE; } set { _PRODUCT_CVD_RATE = value; } }
    public string PRODUCT_CVD_SPL { get { return _PRODUCT_CVD_SPL; } set { _PRODUCT_CVD_SPL = value; } }
    public string PRODUCT_CVD_UNIT { get { return _PRODUCT_CVD_UNIT; } set { _PRODUCT_CVD_UNIT = value; } }
    public string PRODUCT_CVD_SPL_TYPE { get { return _PRODUCT_CVD_SPL_TYPE; } set { _PRODUCT_CVD_SPL_TYPE = value; } }
    public string PRODUCT_CVD_EDU_CESS_RATE { get { return _PRODUCT_CVD_EDU_CESS_RATE; } set { _PRODUCT_CVD_EDU_CESS_RATE = value; } }
    public string PRODUCT_CVD_SEC_EDU_CESS_RATE { get { return _PRODUCT_CVD_SEC_EDU_CESS_RATE; } set { _PRODUCT_CVD_SEC_EDU_CESS_RATE = value; } }
    public string PRODUCT_ADDL5_SIA_NOTN { get { return _PRODUCT_ADDL5_SIA_NOTN; } set { _PRODUCT_ADDL5_SIA_NOTN = value; } }
    public string PRODUCT_ADDL5_SIA_NOTN_SL { get { return _PRODUCT_ADDL5_SIA_NOTN_SL; } set { _PRODUCT_ADDL5_SIA_NOTN_SL = value; } }
    public string PRODUCT_ADDL5_SIA_RATE { get { return _PRODUCT_ADDL5_SIA_RATE; } set { _PRODUCT_ADDL5_SIA_RATE = value; } }
    public string PRODUCT_ADDL_GSI_NOTN { get { return _PRODUCT_ADDL_GSI_NOTN; } set { _PRODUCT_ADDL_GSI_NOTN = value; } }
    public string PRODUCT_ADDL_GSI_SLNO { get { return _PRODUCT_ADDL_GSI_SLNO; } set { _PRODUCT_ADDL_GSI_SLNO = value; } }
    public string PRODUCT_ADDL_GSI_RATE { get { return _PRODUCT_ADDL_GSI_RATE; } set { _PRODUCT_ADDL_GSI_RATE = value; } }
    public string PRODUCT_ADDL_GSI_SPL { get { return _PRODUCT_ADDL_GSI_SPL; } set { _PRODUCT_ADDL_GSI_SPL = value; } }
    public string PRODUCT_ADDL_GSI_UNIT { get { return _PRODUCT_ADDL_GSI_UNIT; } set { _PRODUCT_ADDL_GSI_UNIT = value; } }
    public string PRODUCT_ADDL_GSI_SPL_TYPE { get { return _PRODUCT_ADDL_GSI_SPL_TYPE; } set { _PRODUCT_ADDL_GSI_SPL_TYPE = value; } }
    public string PRODUCT_ADDL_SHEII_NOTN { get { return _PRODUCT_ADDL_SHEII_NOTN; } set { _PRODUCT_ADDL_SHEII_NOTN = value; } }
    public string PRODUCT_ADDL_SHEII_SLNO { get { return _PRODUCT_ADDL_SHEII_SLNO; } set { _PRODUCT_ADDL_SHEII_SLNO = value; } }
    public string PRODUCT_ADDL_SHEII_RATE { get { return _PRODUCT_ADDL_SHEII_RATE; } set { _PRODUCT_ADDL_SHEII_RATE = value; } }
    public string PRODUCT_ADDL_SHEII_SPL { get { return _PRODUCT_ADDL_SHEII_SPL; } set { _PRODUCT_ADDL_SHEII_SPL = value; } }
    public string PRODUCT_ADDL_SHEII_UNIT { get { return _PRODUCT_ADDL_SHEII_UNIT; } set { _PRODUCT_ADDL_SHEII_UNIT = value; } }
    public string PRODUCT_ADDL_SHEII_TYPE { get { return _PRODUCT_ADDL_SHEII_TYPE; } set { _PRODUCT_ADDL_SHEII_TYPE = value; } }
    public string PRODUCT_ADDL_TTA_NOTN { get { return _PRODUCT_ADDL_TTA_NOTN; } set { _PRODUCT_ADDL_TTA_NOTN = value; } }
    public string PRODUCT_ADDL_TTA_SLNO { get { return _PRODUCT_ADDL_TTA_SLNO; } set { _PRODUCT_ADDL_TTA_SLNO = value; } }
    public string PRODUCT_ADDL_TTA_RATE { get { return _PRODUCT_ADDL_TTA_RATE; } set { _PRODUCT_ADDL_TTA_RATE = value; } }
    public string PRODUCT_ADDL_TTA_SPL { get { return _PRODUCT_ADDL_TTA_SPL; } set { _PRODUCT_ADDL_TTA_SPL = value; } }
    public string PRODUCT_ADDL_TTA_UNIT { get { return _PRODUCT_ADDL_TTA_UNIT; } set { _PRODUCT_ADDL_TTA_UNIT = value; } }
    public string PRODUCT_ADDL_TTA_TYPE { get { return _PRODUCT_ADDL_TTA_TYPE; } set { _PRODUCT_ADDL_TTA_TYPE = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_NOTN { get { return _PRODUCT_ADDL_HEALTH_CESS_NOTN; } set { _PRODUCT_ADDL_HEALTH_CESS_NOTN = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_SLNO { get { return _PRODUCT_ADDL_HEALTH_CESS_SLNO; } set { _PRODUCT_ADDL_HEALTH_CESS_SLNO = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_RATE { get { return _PRODUCT_ADDL_HEALTH_CESS_RATE; } set { _PRODUCT_ADDL_HEALTH_CESS_RATE = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_SPL { get { return _PRODUCT_ADDL_HEALTH_CESS_SPL; } set { _PRODUCT_ADDL_HEALTH_CESS_SPL = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_UNIT { get { return _PRODUCT_ADDL_HEALTH_CESS_UNIT; } set { _PRODUCT_ADDL_HEALTH_CESS_UNIT = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_TYPE { get { return _PRODUCT_ADDL_HEALTH_CESS_TYPE; } set { _PRODUCT_ADDL_HEALTH_CESS_TYPE = value; } }
    public string PRODUCT_CESS_NOTN { get { return _PRODUCT_CESS_NOTN; } set { _PRODUCT_CESS_NOTN = value; } }
    public string PRODUCT_CESS_SLNO { get { return _PRODUCT_CESS_SLNO; } set { _PRODUCT_CESS_SLNO = value; } }
    public string PRODUCT_CESS_RATE { get { return _PRODUCT_CESS_RATE; } set { _PRODUCT_CESS_RATE = value; } }
    public string PRODUCT_CESS_SPL { get { return _PRODUCT_CESS_SPL; } set { _PRODUCT_CESS_SPL = value; } }
    public string PRODUCT_CESS_UNIT { get { return _PRODUCT_CESS_UNIT; } set { _PRODUCT_CESS_UNIT = value; } }
    public string PRODUCT_CESS_TYPE { get { return _PRODUCT_CESS_TYPE; } set { _PRODUCT_CESS_TYPE = value; } }


    public string PRODUCT_OTHER_DUTY_NOTN { get { return _PRODUCT_OTHER_DUTY_NOTN; } set { _PRODUCT_OTHER_DUTY_NOTN = value; } }
    public string PRODUCT_OTHER_DUTY_SLNO { get { return _PRODUCT_OTHER_DUTY_SLNO; } set { _PRODUCT_OTHER_DUTY_SLNO = value; } }
    public string PRODUCT_OTHER_DUTY_RATE { get { return _PRODUCT_OTHER_DUTY_RATE; } set { _PRODUCT_OTHER_DUTY_RATE = value; } }
    public string PRODUCT_OTHER_DUTY_SPL { get { return _PRODUCT_OTHER_DUTY_SPL; } set { _PRODUCT_OTHER_DUTY_SPL = value; } }
    public string PRODUCT_OTHER_DUTY_UNIT { get { return _PRODUCT_OTHER_DUTY_UNIT; } set { _PRODUCT_OTHER_DUTY_UNIT = value; } }
    public string PRODUCT_OTHER_DUTY_TYPE { get { return _PRODUCT_OTHER_DUTY_TYPE; } set { _PRODUCT_OTHER_DUTY_TYPE = value; } }

    #endregion
    #region Item_General_Details_Public_Attributes
    public string GENERAL_ID { get { return _GENERAL_ID; } set { _GENERAL_ID = value; } }

    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
    public string SCHEME_NOTN { get { return _SCHEME_NOTN; } set { _SCHEME_NOTN = value; } }
    public string SCHEME_NOTN_SLNO { get { return _SCHEME_NOTN_SLNO; } set { _SCHEME_NOTN_SLNO = value; } }
    public string CTH_QTY1 { get { return _CTH_QTY1; } set { _CTH_QTY1 = value; } }
    public string CTH_QTY2 { get { return _CTH_QTY2; } set { _CTH_QTY2 = value; } }
    public string CTH_QTY1_CODE { get { return _CTH_QTY1_CODE; } set { _CTH_QTY1_CODE = value; } }
    public string CTH_QTY2_CODE { get { return _CTH_QTY2_CODE; } set { _CTH_QTY2_CODE = value; } }
    public string GENEARL_DESCRIPTION { get { return _GENEARL_DESCRIPTION; } set { _GENEARL_DESCRIPTION = value; } }
    public string MANUFACTURER { get { return _MANUFACTURER; } set { _MANUFACTURER = value; } }
    public string BRAND { get { return _BRAND; } set { _BRAND = value; } }
    public string MODEL { get { return _MODEL; } set { _MODEL = value; } }
    public string END_USE_OF_ITEM { get { return _END_USE_OF_ITEM; } set { _END_USE_OF_ITEM = value; } }
    public string COUNTRY_OF_ORIGIN { get { return _COUNTRY_OF_ORIGIN; } set { _COUNTRY_OF_ORIGIN = value; } }
    public string ACCESSORIES { get { return _ACCESSORIES; } set { _ACCESSORIES = value; } }
    public string PREVIOUS_BE_NO { get { return _PREVIOUS_BE_NO; } set { _PREVIOUS_BE_NO = value; } }
    public string PREVIOUS_BE_DATE { get { return _PREVIOUS_BE_DATE; } set { _PREVIOUS_BE_DATE = value; } }
    public string UNIT_PRICE { get { return _UNIT_PRICE; } set { _UNIT_PRICE = value; } }
    public string UNIT_CODE { get { return _UNIT_CODE; } set { _UNIT_CODE = value; } }
    public string ITEM_CUSTOMS_HOUSE { get { return _ITEM_CUSTOMS_HOUSE; } set { _ITEM_CUSTOMS_HOUSE = value; } }
    #endregion

    #region Item_Main_Details_Public_Attributes
    public string ITEM_ID { get { return _MAIN_ID; } set { _MAIN_ID = value; } }

    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }


    public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
    public string ITEM_UNIT_CODE { get { return _ITEM_UNIT_CODE; } set { _ITEM_UNIT_CODE = value; } }

    public string ITEM_TOTAL_AMOUNT { get { return _ITEM_TOTAL_AMOUNT; } set { _ITEM_TOTAL_AMOUNT = value; } }
    public string ITEM_AMOUNT_CODE { get { return _ITEM_AMOUNT_CODE; } set { _ITEM_AMOUNT_CODE = value; } }
    public string ITEM_FOC_QTY { get { return _ITEM_FOC_QTY; } set { _ITEM_FOC_QTY = value; } }

    public string CTH_NO { get { return _CTH_NO; } set { _CTH_NO = value; } }

    public string WAREHOUSE_JOBNO { get { return _WAREHOUSE_JOBNO; } set { _WAREHOUSE_JOBNO = value; } }
    public string WAREHOUSE_INVOICE_SLNO { get { return _WAREHOUSE_INVOICE_SLNO; } set { _WAREHOUSE_INVOICE_SLNO = value; } }
    public string WAREHOUSE_ITEM_SLNO { get { return _WAREHOUSE_ITEM_SLNO; } set { _WAREHOUSE_ITEM_SLNO = value; } }
    public string ASSESSABLE_VALUE { get { return _ASSESSABLE_VALUE; } set { _ASSESSABLE_VALUE = value; } }
    public string DUTY_VALUE { get { return _DUTY_VALUE; } set { _DUTY_VALUE = value; } }
    public string CIF_VALUE { get { return _CIF_VALUE; } set { _CIF_VALUE = value; } }
    public string CVD_VALUE { get { return _CVD_VALUE; } set { _CVD_VALUE = value; } }

    public string BASIC_VALUE { get { return _BASIC_VALUE; } set { _BASIC_VALUE = value; } }
    public string CEC_VALUE { get { return _CEC_VALUE; } set { _CEC_VALUE = value; } }
    public string CHEC_VALUE { get { return _CHEC_VALUE; } set { _CHEC_VALUE = value; } }
    public string ADD_DUTY_VALUE { get { return _ADD_DUTY_VALUE; } set { _ADD_DUTY_VALUE = value; } }

    public string INDIVITUAL_FREIGHT_AMOUNT { get { return _INDIVITUAL_FREIGHT_AMOUNT; } set { _INDIVITUAL_FREIGHT_AMOUNT = value; } }
    public string INDIVITUAL_INSURANCE_AMOUNT { get { return _INDIVITUAL_INSURANCE_AMOUNT; } set { _INDIVITUAL_INSURANCE_AMOUNT = value; } }
    public string INDIVITUAL_MISC_AMOUNT { get { return _INDIVITUAL_MISC_AMOUNT; } set { _INDIVITUAL_MISC_AMOUNT = value; } }

    public string INDIVITUAL_EDU_CESS_AMT { get { return _INDIVITUAL_EDU_CESS_AMT; } set { _INDIVITUAL_EDU_CESS_AMT = value; } }
    public string INDIVITUAL_SEC_HIGHER_CESS_AMT { get { return _INDIVITUAL_SEC_HIGHER_CESS_AMT; } set { _INDIVITUAL_SEC_HIGHER_CESS_AMT = value; } }
    public string INDIVITUAL_LANDING_CHARGE { get { return _INDIVITUAL_LANDING_CHARGE; } set { _INDIVITUAL_LANDING_CHARGE = value; } }

    public string ADDTIONAL_DUTY_RATE { get { return _ADDTIONAL_DUTY_RATE; } set { _ADDTIONAL_DUTY_RATE = value; } }


    public string CHECKLIST_BCD_RATE { get { return _CHECKLIST_BCD_RATE; } set { _CHECKLIST_BCD_RATE = value; } }
    public string CHECKLIST_CVD_RATE { get { return _CHECKLIST_CVD_RATE; } set { _CHECKLIST_CVD_RATE = value; } }
    public string CHECKLIST_ADDL_DUTY_RATE { get { return _CHECKLIST_ADDL_DUTY_RATE; } set { _CHECKLIST_ADDL_DUTY_RATE = value; } }

    public string MERIT_DUTY_VALUE { get { return _MERIT_DUTY_VALUE; } set { _MERIT_DUTY_VALUE = value; } }


    public string MERIT_BASIC_VALUE { get { return _MERIT_BASIC_VALUE; } set { _MERIT_BASIC_VALUE = value; } }
    public string MERIT_CVD_VALUE { get { return _MERIT_CVD_VALUE; } set { _MERIT_CVD_VALUE = value; } }
    public string MERIT_CEC_VALUE { get { return _MERIT_CEC_VALUE; } set { _MERIT_CEC_VALUE = value; } }
    public string MERIT_CHEC_VALUE { get { return _MERIT_CHEC_VALUE; } set { _MERIT_CHEC_VALUE = value; } }
    public string MERIT_ADD_DUTY_VALUE { get { return _MERIT_ADD_DUTY_VALUE; } set { _MERIT_ADD_DUTY_VALUE = value; } }


    public string MERIT_NOTN_BASIC_VALUE { get { return _MERIT_NOTN_BASIC_VALUE; } set { _MERIT_NOTN_BASIC_VALUE = value; } }
    public string MERIT_NOTN_CVD_VALUE { get { return _MERIT_NOTN_CVD_VALUE; } set { _MERIT_NOTN_CVD_VALUE = value; } }
    public string MERIT_NOTN_CEC_VALUE { get { return _MERIT_NOTN_CEC_VALUE; } set { _MERIT_NOTN_CEC_VALUE = value; } }
    public string MERIT_NOTN_CHEC_VALUE { get { return _MERIT_NOTN_CHEC_VALUE; } set { _MERIT_NOTN_CHEC_VALUE = value; } }
    public string MERIT_NOTN_ADD_DUTY_VALUE { get { return _MERIT_NOTN_ADD_DUTY_VALUE; } set { _MERIT_NOTN_ADD_DUTY_VALUE = value; } }
    public string MERIT_NOTN_CESS_VALUE { get { return _MERIT_NOTN_CESS_VALUE; } set { _MERIT_NOTN_CESS_VALUE = value; } }
    public string MERIT_NOTN_NCD_VALUE { get { return _MERIT_NOTN_NCD_VALUE; } set { _MERIT_NOTN_NCD_VALUE = value; } }
    public string INDIVITUAL_HSS_AMOUNT { get { return _INDIVITUAL_HSS_AMOUNT; } set { _INDIVITUAL_HSS_AMOUNT = value; } }

    public string CHECKLIST_IGST_LEVY_AMOUNT { get { return _CHECKLIST_IGST_LEVY_AMOUNT; } set { _CHECKLIST_IGST_LEVY_AMOUNT = value; } }
    public string CHECKLIST_COMPENSATION_CC_AMOUNT { get { return _CHECKLIST_COMPENSATION_CC_AMOUNT; } set { _CHECKLIST_COMPENSATION_CC_AMOUNT = value; } }

    public string Port_Orgin { get { return _Port_Orgin; } set { _Port_Orgin = value; } }
    public string Port_Shipment { get { return _Port_Shipment; } set { _Port_Shipment = value; } }
    public string Tr_Mode { get { return _Tr_Mode; } set { _Tr_Mode = value; } }
    public string Cus_House { get { return _Cus_House; } set { _Cus_House = value; } }

    #endregion
    #endregion
    # region ClearFunction
    public void ResetFields(ControlCollection pageControls)
    {
        foreach (Control contl in pageControls)
        {
            string strCntName = (contl.GetType()).Name;
            switch (strCntName)
            {
                case "TextBox":
                    TextBox tbSource = (TextBox)contl;
                    tbSource.Text = "";
                    break;
                //case "RadioButtonList":
                //    RadioButtonList rblSource = (RadioButtonList)contl;
                //    rblSource.SelectedIndex = -1;
                //    break;
                case "DropDownList":
                    DropDownList ddlSource = (DropDownList)contl;
                    ddlSource.SelectedIndex = -1;

                    break;

                case "CheckBox":
                    CheckBox chkSource = (CheckBox)contl;
                    chkSource.Checked = false;
                    break;

            }

            ResetFields(contl.Controls);
        }
    }

    public void ResetFields_without_dropdown(ControlCollection pageControls)
    {
        foreach (Control contl in pageControls)
        {
            string strCntName = (contl.GetType()).Name;
            switch (strCntName)
            {
                case "TextBox":
                    TextBox tbSource = (TextBox)contl;
                    tbSource.Text = "";
                    break;

                //case "DropDownList":
                //    DropDownList ddlSource = (DropDownList)contl;
                //    ddlSource.SelectedIndex = -1;

                //    break;

                case "CheckBox":
                    CheckBox chkSource = (CheckBox)contl;
                    chkSource.Checked = false;
                    break;

            }

            ResetFields(contl.Controls);
        }
    }


    # endregion
    # region Insert,Update,Delete

    public int tbmanipulate(string commandText, string ConStr)
    {
        con = new SqlConnection(ConStr);
        int i = 0;
        con.Open();

        try
        {
            cmd = new SqlCommand(commandText, con);
            i = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        con.Close();
        return i;
    }

    # endregion
    #region AutoIncrementID
    public int RetrieveID()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[50];


            param[1] = new SqlParameter("@Working_Period", WORKING_PERIOD);


            param[4] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;



            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GENERAL_DETAILS_SP_AUTOID", param);

            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {

        }
        return result;
    }
    public int RetrieveID(string SP_QUERY, string ConStr, string Working_Period)
    {

        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            cmd = new SqlCommand(SP_QUERY, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    A1 = Convert.ToInt32(dr[0].ToString());
                    A2 = Convert.ToInt32(A1 + 1);
                    //userid = A2.ToString();
                }
                else
                {
                    A2 = 1;
                    //userid = "1";

                }
            }
            else
            {
                A2 = 1;
                //userid = "1";
            }

            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return A2;
    }
    #endregion

    private string _IGST_LEVY_NOTN, _IGST_LEVY_SLNO, _IGST_LEVY_RATE, _IGST_LEVY_SPL, _IGST_LEVY_UNIT, _IGST_LEVY_SPL_TYPE, _IGST_LEVY_EXCEPTION_NOTN, _IGST_LEVY_EXCEPTION_SLNO
  , _IGST_LEVY_EXCEPTION_RATE, _IGST_LEVY_COMPENSATION_CESS_NOTN, _IGST_LEVY_COMPENSATION_CESS_SLNO, _IGST_LEVY_COMPENSATION_CESS_RATE, _IGST_LEVY_COMPENSATION_CESS_SPL
  , _IGST_LEVY_COMPENSATION_CESS_UNIT, _IGST_LEVY_COMPENSATION_CESS_SPL_TYPE, _IGST_LEVY_EXCEPTION_CC_NOTN, _IGST_LEVY_EXCEPTION_CC_SLNO, _IGST_LEVY_EXCEPTION_CC_RATE
  , _LEVY_EXCEMPTION_NOTN_TYPE, _LEVY_EXCEPTION_CC_NOTN_TYPE, _CHECKLIST_SOCIAL_WELFARE_AMT, _CHECKLIST_HEALTH_CESS_AMT, _CHECKLIST_ANTI_DUMPING_AMT
  , _Info_Msr, _Info_Uqc, _ADD_EX_RATE, _PART_NO,_FOC_ITEM;

    public string PART_NO { get { return _PART_NO; } set { _PART_NO = value; } }
    public string FOC_ITEM { get { return _FOC_ITEM; } set { _FOC_ITEM = value; } }
    public string IGST_LEVY_NOTN { get { return _IGST_LEVY_NOTN; } set { _IGST_LEVY_NOTN = value; } }
    public string IGST_LEVY_SLNO { get { return _IGST_LEVY_SLNO; } set { _IGST_LEVY_SLNO = value; } }
    public string IGST_LEVY_RATE { get { return _IGST_LEVY_RATE; } set { _IGST_LEVY_RATE = value; } }
    public string IGST_LEVY_SPL { get { return _IGST_LEVY_SPL; } set { _IGST_LEVY_SPL = value; } }
    public string IGST_LEVY_UNIT { get { return _IGST_LEVY_UNIT; } set { _IGST_LEVY_UNIT = value; } }
    public string IGST_LEVY_SPL_TYPE { get { return _IGST_LEVY_SPL_TYPE; } set { _INFRA_CESS_NOTN = value; } }
    public string IGST_LEVY_EXCEPTION_NOTN { get { return _IGST_LEVY_EXCEPTION_NOTN; } set { _IGST_LEVY_EXCEPTION_NOTN = value; } }

    public string Info_Msr { get { return _Info_Msr; } set { _Info_Msr = value; } }
    public string Info_Uqc { get { return _Info_Uqc; } set { _Info_Uqc = value; } }
    public string ADD_EX_RATE { get { return _ADD_EX_RATE; } set { _ADD_EX_RATE = value; } }



    public string IGST_LEVY_EXCEPTION_SLNO { get { return _IGST_LEVY_EXCEPTION_SLNO; } set { _IGST_LEVY_EXCEPTION_SLNO = value; } }
    public string IGST_LEVY_EXCEPTION_RATE { get { return _IGST_LEVY_EXCEPTION_RATE; } set { _IGST_LEVY_EXCEPTION_RATE = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_NOTN { get { return _IGST_LEVY_COMPENSATION_CESS_NOTN; } set { _IGST_LEVY_COMPENSATION_CESS_NOTN = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_SLNO { get { return _IGST_LEVY_COMPENSATION_CESS_SLNO; } set { _IGST_LEVY_COMPENSATION_CESS_SLNO = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_RATE { get { return _IGST_LEVY_COMPENSATION_CESS_RATE; } set { _IGST_LEVY_COMPENSATION_CESS_RATE = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_SPL { get { return _IGST_LEVY_COMPENSATION_CESS_SPL; } set { _IGST_LEVY_COMPENSATION_CESS_SPL = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_UNIT { get { return _IGST_LEVY_COMPENSATION_CESS_UNIT; } set { _IGST_LEVY_COMPENSATION_CESS_UNIT = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_SPL_TYPE { get { return _IGST_LEVY_COMPENSATION_CESS_SPL_TYPE; } set { _IGST_LEVY_COMPENSATION_CESS_SPL_TYPE = value; } }
    public string IGST_LEVY_EXCEPTION_CC_NOTN { get { return _IGST_LEVY_EXCEPTION_CC_NOTN; } set { _IGST_LEVY_EXCEPTION_CC_NOTN = value; } }
    public string IGST_LEVY_EXCEPTION_CC_SLNO { get { return _IGST_LEVY_EXCEPTION_CC_SLNO; } set { _IGST_LEVY_EXCEPTION_CC_SLNO = value; } }
    public string IGST_LEVY_EXCEPTION_CC_RATE { get { return _IGST_LEVY_EXCEPTION_CC_RATE; } set { _IGST_LEVY_EXCEPTION_CC_RATE = value; } }

    public string LEVY_EXCEMPTION_NOTN_TYPE { get { return _LEVY_EXCEMPTION_NOTN_TYPE; } set { _LEVY_EXCEMPTION_NOTN_TYPE = value; } }
    public string LEVY_EXCEPTION_CC_NOTN_TYPE { get { return _LEVY_EXCEPTION_CC_NOTN_TYPE; } set { _LEVY_EXCEPTION_CC_NOTN_TYPE = value; } }

    public string CHECKLIST_SOCIAL_WELFARE_AMT { get { return _CHECKLIST_SOCIAL_WELFARE_AMT; } set { _CHECKLIST_SOCIAL_WELFARE_AMT = value; } }
    public string CHECKLIST_HEALTH_CESS_AMT { get { return _CHECKLIST_HEALTH_CESS_AMT; } set { _CHECKLIST_HEALTH_CESS_AMT = value; } }
    public string CHECKLIST_ANTI_DUMPING_AMT { get { return _CHECKLIST_ANTI_DUMPING_AMT; } set { _CHECKLIST_ANTI_DUMPING_AMT = value; } }


    private string _INV_MISC_T_F, _INV_MISC_CURRENCY, _INV_MISC_EXRATE, _INV_MISC_CHARGES, _INV_MISC_TOTAL_CHARGES, _INV_MISC_ADD_FRT_INS_YN;

    public string INV_MISC_T_F { get { return _INV_MISC_T_F; } set { _INV_MISC_T_F = value; } }
    public string INV_MISC_CURRENCY { get { return _INV_MISC_CURRENCY; } set { _INV_MISC_CURRENCY = value; } }
    public string INV_MISC_EXRATE { get { return _INV_MISC_EXRATE; } set { _INV_MISC_EXRATE = value; } }
    public string INV_MISC_CHARGES { get { return _INV_MISC_CHARGES; } set { _INV_MISC_CHARGES = value; } }
    public string INV_MISC_TOTAL_CHARGES { get { return _INV_MISC_TOTAL_CHARGES; } set { _INV_MISC_TOTAL_CHARGES = value; } }
    public string INV_MISC_ADD_FRT_INS_YN { get { return _INV_MISC_ADD_FRT_INS_YN; } set { _INV_MISC_ADD_FRT_INS_YN = value; } }

    //***********  start added by jayanthi to link freight job ***********//
    private string _FRT_JOBNO, _FRT_BRANCHCODE, _FRT_GROUPID;
    public string FRT_JOBNO { get { return _FRT_JOBNO; } set { _FRT_JOBNO = value; } }
    public string FRT_BRANCHCODE { get { return _FRT_BRANCHCODE; } set { _FRT_BRANCHCODE = value; } }
    public string FRT_GROUPID { get { return _FRT_GROUPID; } set { _FRT_GROUPID = value; } }
    //***********  start added by jayanthi to link freight job ***********//

    public string _xmlString;
    public string xmlString { get { return _xmlString; } set { _xmlString = value; } }

    public string _BOND_AMT;
    public string BOND_AMT { get { return _BOND_AMT; } set { _BOND_AMT = value; } }
    public string _PDF_AMT;
    public string PDF_AMT { get { return _PDF_AMT; } set { _PDF_AMT = value; } }

   public string _icegateId;
    public string icegateId { get { return _icegateId; } set { _icegateId = value; } }
    public int General_details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[120];
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@JOBDATE", DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[4] = new SqlParameter("@BE_TYPE", BE_TYPE);
            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[6] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[7] = new SqlParameter("@ADDRESS1", ADDRESS1);
            param[8] = new SqlParameter("@ADDRESS2", ADDRESS2);
            param[9] = new SqlParameter("@ADDRESS3", ADDRESS3);
            param[10] = new SqlParameter("@ADDRESS4", ADDRESS4);
            param[11] = new SqlParameter("@IEC_NO", IEC_NO);
            param[12] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[13] = new SqlParameter("@COUNTRY_ORIGIN", COUNTRY_ORIGIN);
            param[14] = new SqlParameter("@PORT_SHIPMENT", PORT_SHIPMENT);
            param[15] = new SqlParameter("@COUNTRY_SHIPMENT", COUNTRY_SHIPMENT);
            param[16] = new SqlParameter("@FILING_STATUS", FILING_STATUS);
            param[17] = new SqlParameter("@SECTION46", SECTION46);
            param[18] = new SqlParameter("@SECTION46_DESC", SECTION46_DESC);
            param[19] = new SqlParameter("@FIRSTCHECK", FIRSTCHECK);
            param[20] = new SqlParameter("@FIRSTCHECK_DESC", FIRSTCHECK_DESC);
            param[21] = new SqlParameter("@GREEN_CHANNEL", GREEN_CHANNEL);
            param[22] = new SqlParameter("@GREEN_CHANNEL_DESC", GREEN_CHANNEL_DESC);
            param[23] = new SqlParameter("@KACHHA_BE", KACHHA_BE);
            param[24] = new SqlParameter("@KACHHA_BE_DESC", KACHHA_BE_DESC);
            param[25] = new SqlParameter("@SECTION48", SECTION48);
            param[26] = new SqlParameter("@SECTION48_DESC", SECTION48_DESC);
            param[27] = new SqlParameter("@HIGH_SEA_SALE", HIGH_SEA_SALE);
            param[28] = new SqlParameter("@HIGH_SEA_SALE_NAME", HIGH_SEA_SALE_NAME);
            param[29] = new SqlParameter("@HIGH_SEA_IEC", HIGH_SEA_IEC);
            param[30] = new SqlParameter("@HIGH_SEA_BRANCH_SL_NO", HIGH_SEA_BRANCH_SL_NO);
            param[31] = new SqlParameter("@HSS_ADD1", HSS_ADD1);
            param[32] = new SqlParameter("@HSS_ADD2", HSS_ADD2);
            param[33] = new SqlParameter("@HSS_ADD3", HSS_ADD3);
            param[34] = new SqlParameter("@HSS_ADD4", HSS_ADD4);
            param[35] = new SqlParameter("@HSS_ADD5", HSS_ADD5);
            param[36] = new SqlParameter("@WAREHOUSE_NAME", WAREHOUSE_NAME);
            param[37] = new SqlParameter("@WAREHOUSE_CODE", WAREHOUSE_CODE);
            param[38] = new SqlParameter("@REMARKS", REMARKS);
            param[39] = new SqlParameter("@USERID", USER_ID);
            param[40] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[41] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);
            param[42] = new SqlParameter("@ADDRESS5", ADDRESS5);
            param[43] = new SqlParameter("@Mflag", flag);
            param[63] = new SqlParameter("@IMP_EXP_TYPE", IMP_EXP_TYPE);
            param[44] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[44].Direction = ParameterDirection.Output;
            param[45] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[45].Direction = ParameterDirection.Output;
            param[46] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);
            param[47] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[47].Direction = ParameterDirection.Output;
            param[48] = new SqlParameter("@COMMERCIAL_DETAILS_STATUS", COMMERCIAL_DETAILS_STATUS);
            param[67] = new SqlParameter("@COMMERCIAL_TAX_STATENAME", COMMERCIAL_TAX_STATENAME);
            param[49] = new SqlParameter("@COMMERCIAL_TAX_STATECODE", COMMERCIAL_TAX_STATECODE);
            param[50] = new SqlParameter("@COMMERCIAL_TAX_TYPE", COMMERCIAL_TAX_TYPE);
            param[51] = new SqlParameter("@COMMERCIAL_TAX_REGISTRATION_NO", COMMERCIAL_TAX_REGISTRATION_NO);
            param[52] = new SqlParameter("@EXBOND_INBOND_BE_NO", EXBOND_INBOND_BE_NO);
            param[53] = new SqlParameter("@EXBOND_INBOND_BE_DATE", DateTime.Parse(EXBOND_INBOND_BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[54] = new SqlParameter("@EXBOND_BOND_NO", EXBOND_BOND_NO);
            param[55] = new SqlParameter("@EXBOND_BOND_DATE", DateTime.Parse(EXBOND_BOND_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[56] = new SqlParameter("@EXBOND_WAREHOUSE_CUSTOMS", EXBOND_WAREHOUSE_CUSTOMS);
            param[57] = new SqlParameter("@EXBOND_WAREHOUSE_CUSTOMS_CODE", EXBOND_WAREHOUSE_CUSTOMS_CODE);
            param[58] = new SqlParameter("@EXBOND_NOOFPACKAGE", EXBOND_NOOFPACKAGE);
            param[59] = new SqlParameter("@EXBOND_NOOFPACKAGE_UNITCODE", EXBOND_NOOFPACKAGE_UNITCODE);
            param[60] = new SqlParameter("@EXBOND_GROSS_WEIGHT", EXBOND_GROSS_WEIGHT);
            param[61] = new SqlParameter("@EXBOND_GROSS_WEIGHT_UNITCODE", EXBOND_GROSS_WEIGHT_UNITCODE);
            param[62] = new SqlParameter("@EXBOND_DIRECT_EXBONDING", EXBOND_DIRECT_EXBONDING);
            param[64] = new SqlParameter("@CUSTOMS_HOUSE_NAME", CUSTOMS_HOUSE_NAME);
            param[65] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);
            param[66] = new SqlParameter("@CONTAINER_TYPE", CONTAINER_TYPE);

            param[68] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[69] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

            param[70] = new SqlParameter("@ADCODE", ADCODE);
            param[71] = new SqlParameter("@UCR_NO", UCR_NO);
            param[72] = new SqlParameter("@UCR_TYPE", UCR_TYPE);
            param[73] = new SqlParameter("@PAYMENT_METHOD_CODE", PAYMENT_METHOD_CODE);
            param[74] = new SqlParameter("@PRECEDING_LEVEL", PRECEDING_LEVEL);

            param[75] = new SqlParameter("@EXBOND_ADDL_LOAD_HSS", EXBOND_ADDL_LOAD_HSS);
            param[76] = new SqlParameter("@EXBOND_MISC_LOAD_RATE", EXBOND_MISC_LOAD_RATE);

            param[77] = new SqlParameter("@JOB_PREFIX", JOB_PREFIX);
            param[78] = new SqlParameter("@JOB_SUFFIX", JOB_SUFFIX);

            param[79] = new SqlParameter("@GSTN_TYPE", GSTN_TYPE);
            param[80] = new SqlParameter("@GSTN_ID", GSTN_ID);

            param[81] = new SqlParameter("@PARTY_REF_NO", PARTY_REF_NO);
            param[82] = new SqlParameter("@ETA", ETA);

            param[83] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
            param[84] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);

            // *********** start aded to link Freight jobs **************//
            param[85] = new SqlParameter("@GRP_ID", HttpContext.Current.Session["GroupID"].ToString());
            param[86] = new SqlParameter("@FRT_JOBNO", FRT_JOBNO);
            param[87] = new SqlParameter("@FRTGROUP_ID", FRT_GROUPID);
            param[88] = new SqlParameter("@FRT_BRANCHCODE", FRT_BRANCHCODE);
            // *********** start aded to link Freight jobs **************//

            param[89] = new SqlParameter("@HSS_ADCODE", HSS_ADCODE);
            param[90] = new SqlParameter("@Company_id", Connection.COMPANYID());

            param[91] = new SqlParameter("@ICE_ID", ICE_ID);
            param[92] = new SqlParameter("@CHA_NO", CHA_NO);

            param[93] = new SqlParameter("@PROVISIONAL", PROVISIONAL);
            param[94] = new SqlParameter("@PROVISIONAL_DESC", PROVISIONAL_DESC);

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_INSERT_UPDATE", param);
            //SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_INSERT_UPDATE_KJ", param);

            result = Convert.ToInt32(param[44].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[47].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }


    //public DataSet IGM_Details_insertupdate()
    //{
    //    try
    //    {

    //        SqlParameter[] param = new SqlParameter[45];
    //        param[0] = new SqlParameter("@JOBNO", IGM_JOBNO);
    //        param[31] = new SqlParameter("@IGM_SLNO_Update", IGM_SLNO_UPDATE);
    //        param[1] = new SqlParameter("@IGM_JOBDATE", DateTime.Parse(IGM_JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
    //        param[2] = new SqlParameter("@IGM_AIRLINECODE", IGM_AIRLINECODE);
    //        param[3] = new SqlParameter("@IGM_AIRLINENAME", IGM_AIRLINENAME);
    //        param[4] = new SqlParameter("@IGM_FLIGHTNO_VESSELNO", IGM_FLIGHTNO_VESSELNO);
    //        param[5] = new SqlParameter("@IGM_FLIGHT_VESSELDATE", DateTime.Parse(IGM_FLIGHT_VESSELDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
    //        param[6] = new SqlParameter("@IGM_NO", IGM_NO);
    //        param[7] = new SqlParameter("@IGM_DATE", DateTime.Parse(IGM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
    //        param[8] = new SqlParameter("@IGM_MAWB_MBL", IGM_MAWB_MBL);
    //        param[9] = new SqlParameter("@IGM_MAWB_MBLDATE", DateTime.Parse(IGM_MAWB_MBLDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
    //        param[10] = new SqlParameter("@IGM_HAWB_HBLNO", IGM_HAWB_HBLNO);
    //        param[11] = new SqlParameter("@IGM_HAWB_HBLDATE", DateTime.Parse(IGM_HAWB_HBLDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
    //        param[12] = new SqlParameter("@IGM_NOOFPACKAGE", IGM_NOOFPACKAGE);
    //        param[13] = new SqlParameter("@IGM_PACKAGETYPE", IGM_PACKAGETYPE);
    //        param[14] = new SqlParameter("@IGM_GROSSWEIGHT", IGM_GROSSWEIGHT);
    //        param[15] = new SqlParameter("@IGM_TYPEOFWEIGHT", IGM_TYPEOFWEIGHT);
    //        param[16] = new SqlParameter("@IGM_NETWEIGHT", IGM_NETWEIGHT);
    //        param[17] = new SqlParameter("@IGM_NETWEIGHTTYPE", IGM_NETWEIGHTTYPE);
    //        param[18] = new SqlParameter("@IGM_TRANSPORTMODE", IGM_TRANSPORTMODE);
    //        param[19] = new SqlParameter("@IGM_MARKSNOS", IGM_MARKSNOS);
    //        param[20] = new SqlParameter("@IGM_USER_ID", USER_ID);
    //        param[21] = new SqlParameter("@IGM_BRANCH_CODE", BRANCH_CODE);
    //        param[22] = new SqlParameter("@IGM_YEAR", YEAR);
    //        param[23] = new SqlParameter("@IGM_WORKING_PERIOD", WORKING_PERIOD);
    //        param[24] = new SqlParameter("@Mflag", flag);
    //        param[25] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
    //        param[25].Direction = ParameterDirection.Output;
    //        param[26] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[26].Direction = ParameterDirection.Output;
    //        param[27] = new SqlParameter("@IGMSLNO", SqlDbType.Int, 1);
    //        param[27].Direction = ParameterDirection.Output;
    //        param[28] = new SqlParameter("@IGM_GATEWAY_IGM_NO", IGM_GATEWAY_IGM_NO);
    //        param[29] = new SqlParameter("@IGM_GATEWAY_IGM_DATE", DateTime.Parse(IGM_GATEWAY_IGM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
    //        param[30] = new SqlParameter("@IGM_GATEWAY_PORT_CODE", IGM_GATEWAY_PORT_CODE);
    //        param[32] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
    //        param[32].Direction = ParameterDirection.Output;

    //        param[33] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

    //        param[34] = new SqlParameter("@IGM_LINE_NUMBER", IGM_LINE_NUMBER);
    //        param[35] = new SqlParameter("@IGM_SHIPPING_LINE_NUMBER", IGM_SHIPPING_LINE_NUMBER);
    //        param[36] = new SqlParameter("@IGM_VOYAGE", IGM_VOYAGE);
    //        param[37] = new SqlParameter("@IGM_CHARGEABLE_WGT", IGM_CHARGEABLE_WGT);
    //        param[38] = new SqlParameter("@ROTATION_NO", ROTATION_NO);
    //        param[39] = new SqlParameter("@ROTATION_DATE", ROTATION_DATE);

    //        param[40] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
    //        param[41] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);
    //        param[42] = new SqlParameter("@JOBNO_PS", JOBNO_PS);


    //        ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_INSERT_UPDATE", param);


    //        string IGMSLNO = param[26].Value.ToString();
    //        result = Convert.ToInt32(param[25].Value.ToString());

    //        if (flag == "S")
    //        {
    //            UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
    //        }
    //        else if (flag == "U")
    //        {
    //            UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
    //        }
    //        if (ds.Tables.Count > 0)
    //        {
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //            }
    //            else
    //                ds.Tables.Add(dt);

    //        }
    //        else
    //            ds.Tables.Add(dt);
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return ds;
    //}


    public DataSet IGM_Details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[45];
            param[0] = new SqlParameter("@JOBNO", IGM_JOBNO);
            param[31] = new SqlParameter("@IGM_SLNO_Update", IGM_SLNO_UPDATE);
            param[1] = new SqlParameter("@IGM_JOBDATE", DateTime.Parse(IGM_JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[2] = new SqlParameter("@IGM_AIRLINECODE", IGM_AIRLINECODE);
            param[3] = new SqlParameter("@IGM_AIRLINENAME", IGM_AIRLINENAME);
            param[4] = new SqlParameter("@IGM_FLIGHTNO_VESSELNO", IGM_FLIGHTNO_VESSELNO);
            param[5] = new SqlParameter("@IGM_FLIGHT_VESSELDATE", DateTime.Parse(IGM_FLIGHT_VESSELDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            //param[6] = new SqlParameter("@IGM_NO", IGM_NO);

            param[6] = new SqlParameter("@IGM_NO", SqlDbType.BigInt);
            param[6].Value = string.IsNullOrEmpty(IGM_NO) ? 0 : Convert.ToInt64(IGM_NO);

            param[7] = new SqlParameter("@IGM_DATE", DateTime.Parse(IGM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[8] = new SqlParameter("@IGM_MAWB_MBL", IGM_MAWB_MBL);
            param[9] = new SqlParameter("@IGM_MAWB_MBLDATE", DateTime.Parse(IGM_MAWB_MBLDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[10] = new SqlParameter("@IGM_HAWB_HBLNO", IGM_HAWB_HBLNO);
           // param[11] = new SqlParameter("@IGM_HAWB_HBLDATE", DateTime.Parse(IGM_HAWB_HBLDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            DateTime hblDate;

            if (DateTime.TryParse(
                    IGM_HAWB_HBLDATE,
                    provider,
                    System.Globalization.DateTimeStyles.NoCurrentDateDefault,
                    out hblDate))
            {
                param[11] = new SqlParameter("@IGM_HAWB_HBLDATE", hblDate);
            }
            else
            {
                param[11] = new SqlParameter("@IGM_HAWB_HBLDATE", DBNull.Value);
            }
            //param[12] = new SqlParameter("@IGM_NOOFPACKAGE", IGM_NOOFPACKAGE);

            param[12] = new SqlParameter("@IGM_NOOFPACKAGE", SqlDbType.BigInt);
            param[12].Value = string.IsNullOrEmpty(IGM_NOOFPACKAGE) ? 0 : Convert.ToInt64(IGM_NOOFPACKAGE);

            param[13] = new SqlParameter("@IGM_PACKAGETYPE", IGM_PACKAGETYPE);
            //param[14] = new SqlParameter("@IGM_GROSSWEIGHT", IGM_GROSSWEIGHT);

            param[14] = new SqlParameter("@IGM_GROSSWEIGHT", SqlDbType.Decimal);
            param[14].Value = string.IsNullOrEmpty(IGM_GROSSWEIGHT) ? 0 : Convert.ToDecimal(IGM_GROSSWEIGHT);

            param[15] = new SqlParameter("@IGM_TYPEOFWEIGHT", IGM_TYPEOFWEIGHT);

            //param[16] = new SqlParameter("@IGM_NETWEIGHT", IGM_NETWEIGHT);

            param[16] = new SqlParameter("@IGM_NETWEIGHT", SqlDbType.Decimal);
            param[16].Value = string.IsNullOrEmpty(IGM_NETWEIGHT) ? 0 : Convert.ToDecimal(IGM_NETWEIGHT);

            param[17] = new SqlParameter("@IGM_NETWEIGHTTYPE", IGM_NETWEIGHTTYPE);
            param[18] = new SqlParameter("@IGM_TRANSPORTMODE", IGM_TRANSPORTMODE);
            param[19] = new SqlParameter("@IGM_MARKSNOS", IGM_MARKSNOS);
            param[20] = new SqlParameter("@IGM_USER_ID", USER_ID);
            param[21] = new SqlParameter("@IGM_BRANCH_CODE", BRANCH_CODE);
            param[22] = new SqlParameter("@IGM_YEAR", YEAR);
            param[23] = new SqlParameter("@IGM_WORKING_PERIOD", WORKING_PERIOD);
            param[24] = new SqlParameter("@Mflag", flag);
            param[25] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[25].Direction = ParameterDirection.Output;
            param[26] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[26].Direction = ParameterDirection.Output;
            param[27] = new SqlParameter("@IGMSLNO", SqlDbType.Int, 1);
            param[27].Direction = ParameterDirection.Output;
            param[28] = new SqlParameter("@IGM_GATEWAY_IGM_NO", IGM_GATEWAY_IGM_NO);
            param[29] = new SqlParameter("@IGM_GATEWAY_IGM_DATE", DateTime.Parse(IGM_GATEWAY_IGM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[30] = new SqlParameter("@IGM_GATEWAY_PORT_CODE", IGM_GATEWAY_PORT_CODE);
            param[32] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[32].Direction = ParameterDirection.Output;

            param[33] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[34] = new SqlParameter("@IGM_LINE_NUMBER", IGM_LINE_NUMBER);
            param[35] = new SqlParameter("@IGM_SHIPPING_LINE_NUMBER", IGM_SHIPPING_LINE_NUMBER);
            param[36] = new SqlParameter("@IGM_VOYAGE", IGM_VOYAGE);
            param[37] = new SqlParameter("@IGM_CHARGEABLE_WGT", IGM_CHARGEABLE_WGT);
            param[38] = new SqlParameter("@ROTATION_NO", ROTATION_NO);
            param[39] = new SqlParameter("@ROTATION_DATE", ROTATION_DATE);

            param[40] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
            param[41] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);
            param[42] = new SqlParameter("@JOBNO_PS", JOBNO_PS);


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_INSERT_UPDATE", param);


            string IGMSLNO = param[26].Value.ToString();
            result = Convert.ToInt32(param[25].Value.ToString());

            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
            }
            else if (flag == "U")
            {
                UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }







   public DataSet CONTAINER_Details_insertupdate()
    {
        SqlParameter[] param = new SqlParameter[22];
        try
        {
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@CONTAINERID", CONTAINERID);
            param[2] = new SqlParameter("@CONTAINER_NO", CONTAINER_NO);
            param[3] = new SqlParameter("@CONTAINER_IGM_SLNO", CONTAINER_IGM_SLNO);
            param[4] = new SqlParameter("@CONTAINER_IGM_NO", CONTAINER_IGM_NO);
            param[5] = new SqlParameter("@CONTAINER_IGM_DATE", DateTime.Parse(CONTAINER_IGM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[6] = new SqlParameter("@SEAL_NO", SEAL_NO);
            param[7] = new SqlParameter("@FCL_OR_LCL", FCL_OR_LCL);
            param[8] = new SqlParameter("@USER_ID", USER_ID);
            param[9] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[10] = new SqlParameter("@YEAR", YEAR);
            param[11] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[16] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[17] = new SqlParameter("@TYPE", TYPE);
            param[18] = new SqlParameter("@TRUCK_NO", TRUCK_NO);

            param[19] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
            param[20] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);
            param[21] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

            param[12] = new SqlParameter("@Mflag", flag);
            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONTAINER_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[13].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[15].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet BOND_Details_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[10] = new SqlParameter("@BONDID", BONDID);
            param[1] = new SqlParameter("@BOND_NO", BOND_NO);
            param[2] = new SqlParameter("@BOND_TYPE", BOND_TYPE);
            param[11] = new SqlParameter("@BOND_LOCATION", BOND_LOCATION);
            param[3] = new SqlParameter("@USER_ID", USER_ID);
            param[4] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[5] = new SqlParameter("@YEAR", YEAR);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[13] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[14] = new SqlParameter("@BOND_AMT", BOND_AMT);   //Ajith Added
            param[7] = new SqlParameter("@Mflag", flag);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_BOND_DETAILS_INSERT_UPDATE", param);
            string err = param[9].Value.ToString();
            result = Convert.ToInt32(param[8].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[12].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet CERTIFICATE_Details_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[11] = new SqlParameter("@CERTIFICATEID", CERTIFICATEID);
            param[1] = new SqlParameter("@CERTIFICATE_NO", CERTIFICATE_NO);
            param[2] = new SqlParameter("@CERTIFICATE_DATE", DateTime.Parse(CERTIFICATE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[10] = new SqlParameter("@CERTIFICATE_TYPE", CERTIFICATE_TYPE);
            param[3] = new SqlParameter("@USER_ID", USER_ID);
            param[4] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[5] = new SqlParameter("@YEAR", YEAR);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[13] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[7] = new SqlParameter("@Mflag", flag);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CERTIFICATE_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[8].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[12].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Re_Import_Details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@RE_IMPORT_ID", RE_IMPORT_ID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[20] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[21] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[22] = new SqlParameter("@INVOICE_NO", INVOICE_NO);

            param[2] = new SqlParameter("@SB_NO", SB_NO);
            param[3] = new SqlParameter("@SB_DATE", DateTime.Parse(SB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[4] = new SqlParameter("@PORT_EXPORT", PORT_EXPORT);
            param[5] = new SqlParameter("@SB_INVOICE_NO", SB_INVOICE_NO);
            param[6] = new SqlParameter("@SB_INVOICE__ITEM_NO", SB_INVOICE__ITEM_NO);
            param[7] = new SqlParameter("@NOTN_NO", NOTN_NO);
            param[8] = new SqlParameter("@NOTN_SLNO", NOTN_SLNO);
            param[9] = new SqlParameter("@EXPORT_FREIGHT", EXPORT_FREIGHT);
            param[10] = new SqlParameter("@EXPORT_INSURANCE", EXPORT_INSURANCE);
            param[11] = new SqlParameter("@CUSTOMS_DUTY", CUSTOMS_DUTY);
            param[12] = new SqlParameter("@USER_ID", USER_ID);
            param[13] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[14] = new SqlParameter("@EXCISE_DUTY", EXCISE_DUTY);
            param[15] = new SqlParameter("@YEAR", YEAR);
            param[16] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[24] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[17] = new SqlParameter("@Mflag", flag);
            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            param[23] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_RE_IMPORT_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[18].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[23].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet License_Details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[40];
            param[0] = new SqlParameter("@LICENSE_ID", LICENSE_ID);
            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[19] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE_LICENSE);

            param[3] = new SqlParameter("@JOBNO", JOBNO);
            param[4] = new SqlParameter("@REGISTRATION_NO", REGISTRATION_NO);
            param[5] = new SqlParameter("@REGISTRATION_DATE", DateTime.Parse(REGISTRATION_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[6] = new SqlParameter("@EXCEMPTION", EXCEMPTION);
            param[7] = new SqlParameter("@DEBIT_AMT", DEBIT_AMT);
            param[8] = new SqlParameter("@DEBIT_QTY", DEBIT_QTY);
            param[9] = new SqlParameter("@UNIT_QTY", UNIT_QTY);
            param[10] = new SqlParameter("@LICENSE_ITEM_NO", LICENSE_ITEM_NO);
            param[11] = new SqlParameter("@PORT_OF_LICENSE", PORT_OF_LICENSE);

            param[12] = new SqlParameter("@USER_ID", USER_ID);
            param[13] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[14] = new SqlParameter("@YEAR", YEAR);
            param[15] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[21] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[22] = new SqlParameter("@LICENSE_NO", LICENSE_NO);

            param[23] = new SqlParameter("@LICENSE_DATE", DateTime.Parse(LICENSE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[24] = new SqlParameter("@TOTAL_CIF_VALUE", TOTAL_CIF_VALUE);
            param[25] = new SqlParameter("@TOTAL_DEBIT_DUTY", TOTAL_DEBIT_DUTY);
            //param[26] = new SqlParameter("@ENTRY_CIF_VALUE", ENTRY_CIF_VALUE);
            param[27] = new SqlParameter("@ENTRY_DEBIT_DUTY", ENTRY_DEBIT_DUTY);
            param[28] = new SqlParameter("@DEBIT_DUTY", DEBIT_DUTY);

            param[31] = new SqlParameter("@LIC_DESC", ITEM_DESCRIPTION);
            param[32] = new SqlParameter("@LICENSE_CURRENCY", LICENSE_CURRENCY);
            param[33] = new SqlParameter("@EX_RATE", EX_RATE);
            param[34] = new SqlParameter("@JOBNO_PS", JOBNO_PS);
            param[35] = new SqlParameter("@PART_NO", PART_NO);


            param[16] = new SqlParameter("@Mflag", flag);
            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;
            param[20] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[17].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[20].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Invoice_Details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[180];

            param[0] = new SqlParameter("@INVOICE_ID", INVOICE_ID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[89] = new SqlParameter("@INVOICE_SLNO", INV_SLNO);
            param[2] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[3] = new SqlParameter("@INVOICE_DATE", DateTime.Parse(INVOICE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[4] = new SqlParameter("@TERMS", TERMS);
            param[5] = new SqlParameter("@INVOICE_CURRENCY", INVOICE_CURRENCY);
            param[91] = new SqlParameter("@INVOICE_EXRATE", INVOICE_EXRATE);

            param[6] = new SqlParameter("@INVOICE_VALUE", INVOICE_VALUE);

            // SUPPLIER
            param[7] = new SqlParameter("@SUPPLIER_NAME", SUPPLIER_NAME);
            param[8] = new SqlParameter("@SUPPLIER_ADDRESS", SUPPLIER_ADDRESS);
            param[9] = new SqlParameter("@SUPPLIER_ADDRESS1", SUPPLIER_ADDRESS1);
            param[10] = new SqlParameter("@SUPPLIER_ADDRESS2", SUPPLIER_ADDRESS2);
            //param[11] = new SqlParameter("@SUPPLIER_ADDRESS3", SUPPLIER_ADDRESS3);

            param[12] = new SqlParameter("@SUPPLIER_COUNTRY_NAME", SUPPLIER_COUNTRY_NAME);
            param[13] = new SqlParameter("@SUPPLIER_COUNTRY_CODE", SUPPLIER_COUNTRY_CODE);
            param[14] = new SqlParameter("@SUPPLIER_COUNTRY_PINCODE", SUPPLIER_COUNTRY_PINCODE);
            param[15] = new SqlParameter("@SELLER_NAME", SELLER_NAME);
            param[16] = new SqlParameter("@SELLER_ADDRESS", SELLER_ADDRESS);
            param[17] = new SqlParameter("@SELLER_ADDRESS1", SELLER_ADDRESS1);
            param[18] = new SqlParameter("@SELLER_ADDRESS2", SELLER_ADDRESS2);
            //param[19] = new SqlParameter("@SELLER_ADDRESS3", SELLER_ADDRESS3);
            param[20] = new SqlParameter("@SELLER_COUNTRY_NAME", SELLER_COUNTRY_NAME);
            param[21] = new SqlParameter("@SELLER_COUNTRY_CODE", SELLER_COUNTRY_CODE);
            param[22] = new SqlParameter("@SELLERCOUNTRY_PINCODE", SELLERCOUNTRY_PINCODE);
            param[23] = new SqlParameter("@BROKER_NAME", BROKER_NAME);
            param[24] = new SqlParameter("@BROKER_ADDRESS", BROKER_ADDRESS);
            param[25] = new SqlParameter("@BROKER_ADDRESS1", BROKER_ADDRESS1);
            param[26] = new SqlParameter("@BROKER_ADDRESS2", BROKER_ADDRESS2);
            //param[27] = new SqlParameter("@BROKER_ADDRESS3", BROKER_ADDRESS3);
            param[28] = new SqlParameter("@BROKER_COUNTRY_NAME", BROKER_COUNTRY_NAME);
            param[29] = new SqlParameter("@BROKER_COUNTRY_CODE", BROKER_COUNTRY_CODE);
            param[30] = new SqlParameter("@BROKER_COUNTRY_PINCODE", BROKER_COUNTRY_PINCODE);
            //MIS

            param[31] = new SqlParameter("@MIS_CHARGES", MIS_CHARGES);
            param[32] = new SqlParameter("@MIS_RATE", MIS_RATE);
            param[33] = new SqlParameter("@MIS_CURRENCY", MIS_CURRENCY);
            param[34] = new SqlParameter("@MIS_EXRATE", MIS_EXRATE);

            param[35] = new SqlParameter("@MIS_AGENCY_CHARGES", MIS_AGENCY_CHARGES);
            param[36] = new SqlParameter("@MIS_AGENCY_RATE", MIS_AGENCY_RATE);
            param[37] = new SqlParameter("@MIS_AGENCY_CURRENCY", MIS_AGENCY_CURRENCY);
            param[38] = new SqlParameter("@MIS_AGENCY_EXRATE", MIS_AGENCY_EXRATE);

            param[39] = new SqlParameter("@MIS_DISCOUNT_CHARGES", MIS_DISCOUNT_CHARGES);
            param[40] = new SqlParameter("@MIS_DISCOUNT_RATE", MIS_DISCOUNT_RATE);
            param[41] = new SqlParameter("@MIS_DISCOUNT_CURRENCY", MIS_DISCOUNT_CURRENCY);
            param[42] = new SqlParameter("@MIS_DISCOUNT_EXRATE", MIS_DISCOUNT_EXRATE);
            param[43] = new SqlParameter("@MIS_DISCOUNT_REASON", MIS_DISCOUNT_REASON);

            param[44] = new SqlParameter("@MIS_LOADING_CHARGES", MIS_LOADING_CHARGES);
            param[45] = new SqlParameter("@MIS_LOADING_RATE", MIS_LOADING_RATE);
            param[46] = new SqlParameter("@MIS_LOADING_CURRENCY", MIS_LOADING_CURRENCY);
            param[47] = new SqlParameter("@MIS_LOADING_EXRATE", MIS_LOADING_EXRATE);

            param[48] = new SqlParameter("@MIS_FREIGHT_CHARGES", MIS_FREIGHT_CHARGES == "" ? "0" : MIS_FREIGHT_CHARGES);
            param[49] = new SqlParameter("@MIS_FREIGHT_RATE", MIS_FREIGHT_RATE == "" ? "0" : MIS_FREIGHT_RATE);
            param[50] = new SqlParameter("@MIS_FREIGHT_CURRENCY", MIS_FREIGHT_CURRENCY);
            param[51] = new SqlParameter("@MIS_FREIGHT_EXRATE", MIS_FREIGHT_EXRATE);

            param[52] = new SqlParameter("@MIS_INSURANCE_CHARGES", MIS_INSURANCE_CHARGES == "" ? "0" : MIS_INSURANCE_CHARGES);
            param[53] = new SqlParameter("@MIS_INSURANCE_RATE", MIS_INSURANCE_RATE == "" ? "0" : MIS_INSURANCE_RATE);

            param[54] = new SqlParameter("@MIS_INSURANCE_CURRENCY", MIS_INSURANCE_CURRENCY);
            param[55] = new SqlParameter("@MIS_INSURANCE_EXRATE", MIS_INSURANCE_EXRATE);

            param[56] = new SqlParameter("@MIS_HIGHSEASALE_CHARGES", MIS_HIGHSEASALE_CHARGES);
            param[57] = new SqlParameter("@MIS_HIGHSEASALE_RATE", MIS_HIGHSEASALE_RATE);
            param[58] = new SqlParameter("@MIS_HIGHSEASALE_CURRENCY", MIS_HIGHSEASALE_CURRENCY);
            param[59] = new SqlParameter("@MIS_HIGHSEASALE_EXRATE", MIS_HIGHSEASALE_EXRATE);

            param[60] = new SqlParameter("@MIS_SINGLE_OR_MULITIPLE", MIS_SINGLE_OR_MULITIPLE);
            //SVB
            param[61] = new SqlParameter("@SVB_RELATION", SVB_RELATION);

            param[62] = new SqlParameter("@SVB_REF_NO", SVB_REF_NO);
            param[90] = new SqlParameter("@SVB_REF_DATE", DateTime.Parse(SVB_REF_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[63] = new SqlParameter("@SVB_CUSTOM_HOUSE", SVB_CUSTOM_HOUSE);
            param[64] = new SqlParameter("@SVB_LOADING_ON", SVB_LOADING_ON);
            param[65] = new SqlParameter("@SVB_ASSESABLE_RATE", SVB_ASSESABLE_RATE);
            param[66] = new SqlParameter("@SVB_DUTY_RATE", SVB_DUTY_RATE);
            param[67] = new SqlParameter("@SVB_ASSESABLE_STATUS", SVB_ASSESABLE_STATUS);
            param[68] = new SqlParameter("@SVB_DUTY_STATUS", SVB_DUTY_STATUS);
            //OTHER_DETAILS
            param[69] = new SqlParameter("@OTHER_PURCHASE_ORDER", OTHER_PURCHASE_ORDER);
            param[70] = new SqlParameter("@OTHER_PURCHASE_ORDER_DATE", DateTime.Parse(OTHER_PURCHASE_ORDER_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[71] = new SqlParameter("@OTHER_CONTRACT_NO", OTHER_CONTRACT_NO);
            param[72] = new SqlParameter("@OTHER_CONTRACT_DATE", DateTime.Parse(OTHER_CONTRACT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[73] = new SqlParameter("@OTHER_LOC_NO", OTHER_LOC_NO);
            param[74] = new SqlParameter("@OTHER_LOC_DATE", DateTime.Parse(OTHER_LOC_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[75] = new SqlParameter("@OTHER_NATURE_OF_TRANSACTION", OTHER_NATURE_OF_TRANSACTION);
            param[76] = new SqlParameter("@OTHER_TERMS_OF_PAYMENT", OTHER_TERMS_OF_PAYMENT);
            param[77] = new SqlParameter("@OTHER_CONDITIONS", OTHER_CONDITIONS);
            param[78] = new SqlParameter("@OTHER_VALUATION_METHOD", OTHER_VALUATION_METHOD);

            //SINGLE WINDOW

            param[113] = new SqlParameter("@TERMS_PLACE", TERMS_PLACE);
            param[114] = new SqlParameter("@THIRDPARTY_NAME", THIRDPARTY_NAME);
            param[115] = new SqlParameter("@THIRDPARTY_ADD1", THIRDPARTY_ADD1);
            param[116] = new SqlParameter("@THIRDPARTY_ADD2", THIRDPARTY_ADD2);
            param[117] = new SqlParameter("@THIRDPARTY_CITY", THIRDPARTY_CITY);
            param[118] = new SqlParameter("@T_PARTY_COUNTRY_SUB_DIV", T_PARTY_COUNTRY_SUB_DIV);
            param[119] = new SqlParameter("@T_PARTY_COUNTRY_CODE", T_PARTY_COUNTRY_CODE);
            param[120] = new SqlParameter("@T_PARTY_PIN", T_PARTY_PIN);
            param[121] = new SqlParameter("@AUTHORIZED_ECONOMIC_OPERATOR_CODE", AUTHORIZED_ECONOMIC_OPERATOR_CODE);
            param[122] = new SqlParameter("@A_E_O_COUNTRY", A_E_O_COUNTRY);
            param[123] = new SqlParameter("@AUTHORIZED_ECONOMIC_OPERATOR", AUTHORIZED_ECONOMIC_OPERATOR);
            param[124] = new SqlParameter("@WHETHER_BUYER_SELLER_RELATED", WHETHER_BUYER_SELLER_RELATED);

            param[125] = new SqlParameter("@A_AMOUNT", A_AMOUNT);
            param[126] = new SqlParameter("@B_AMOUNT", B_AMOUNT);
            param[127] = new SqlParameter("@C_AMOUNT", C_AMOUNT);
            param[128] = new SqlParameter("@D_AMOUNT", D_AMOUNT);
            param[129] = new SqlParameter("@E_AMOUNT", E_AMOUNT);
            param[130] = new SqlParameter("@F_AMOUNT", F_AMOUNT);
            param[131] = new SqlParameter("@G_AMOUNT", G_AMOUNT);
            param[132] = new SqlParameter("@H_AMOUNT", H_AMOUNT);
            param[133] = new SqlParameter("@I_AMOUNT", I_AMOUNT);
            param[134] = new SqlParameter("@J_AMOUNT", J_AMOUNT);
            param[135] = new SqlParameter("@K_AMOUNT", K_AMOUNT);
            param[136] = new SqlParameter("@L_AMOUNT", L_AMOUNT);
            param[137] = new SqlParameter("@M_AMOUNT", M_AMOUNT);
            param[138] = new SqlParameter("@N_AMOUNT", N_AMOUNT);
            param[139] = new SqlParameter("@TOTAL_OTHER_AMOUNT", TOTAL_OTHER_AMOUNT);
            param[140] = new SqlParameter("@DOC_RECD_DATE", REGISTRATION_DATE);

            param[141] = new SqlParameter("@INV_MISC_T_F", INV_MISC_T_F);
            param[142] = new SqlParameter("@INV_MISC_CURRENCY", INV_MISC_CURRENCY);
            param[143] = new SqlParameter("@INV_MISC_EXRATE", INV_MISC_EXRATE);
            param[144] = new SqlParameter("@INV_MISC_CHARGES", INV_MISC_CHARGES);
            param[145] = new SqlParameter("@INV_MISC_TOTAL_CHARGES", INV_MISC_TOTAL_CHARGES);
            param[146] = new SqlParameter("@INV_MISC_ADD_FRT_INS_YN", INV_MISC_ADD_FRT_INS_YN);


            param[79] = new SqlParameter("@USER_ID", USER_ID);
            param[80] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[81] = new SqlParameter("@YEAR", YEAR);
            param[82] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[83] = new SqlParameter("@Mflag", flag);
            param[84] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[84].Direction = ParameterDirection.Output;
            param[85] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[85].Direction = ParameterDirection.Output;

            param[86] = new SqlParameter("@ALL_INVOICE_VALUE", SqlDbType.NVarChar, 1000);
            param[86].Direction = ParameterDirection.Output;
            param[87] = new SqlParameter("@ALL_FREIGHT_TOTAL", SqlDbType.NVarChar, 1000);
            param[87].Direction = ParameterDirection.Output;
            param[88] = new SqlParameter("@ALL_INSURANCE_TOTAL", SqlDbType.NVarChar, 1000);
            param[88].Direction = ParameterDirection.Output;

            if (string.IsNullOrEmpty(NON_STD_EFFECT_DT_IMP))
            {
                NON_STD_EFFECT_DT_IMP = "01/01/1900";
            }
            if (string.IsNullOrEmpty(NON_STD_CERTIFICATE_DATE))
            {
                NON_STD_CERTIFICATE_DATE = "01/01/1900";
            }
            param[92] = new SqlParameter("@NON_STD_EFFECT_DT_IMP", DateTime.Parse(NON_STD_EFFECT_DT_IMP, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[93] = new SqlParameter("@NON_STD_BANKNAME", NON_STD_BANKNAME);
            param[94] = new SqlParameter("@NON_STD_CERTIFICATE_NO", NON_STD_CERTIFICATE_NO);
            param[95] = new SqlParameter("@NON_STD_CERTIFICATE_DATE", DateTime.Parse(NON_STD_CERTIFICATE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[96] = new SqlParameter("@SAP_DELIEVERY_ID", SAP_DELIEVERY_ID);
            param[97] = new SqlParameter("@SHIP_DATE", DateTime.Parse(SHIP_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[98] = new SqlParameter("@INVOICE_LEVEL", INVOICE_LEVEL);
            param[99] = new SqlParameter("@COUNTRY_OF_DEPARTURE", COUNTRY_OF_DEPARTURE);

            param[100] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[101] = new SqlParameter("@REVENUEDEPOSIT_RATE", REVENUEDEPOSIT_RATE);
            param[102] = new SqlParameter("@REVENUEDEPOSIT_ON", REVENUEDEPOSIT_ON);

            param[103] = new SqlParameter("@MI_FREIGHT", MI_FREIGHT);
            param[104] = new SqlParameter("@MI_INSURANCE", MI_INSURANCE);

            param[105] = new SqlParameter("@MI_MISC", MI_MISC);
            param[106] = new SqlParameter("@MI_HSS", MI_HSS);
            param[107] = new SqlParameter("@MULTIPLE_MISC_AMT", MULTIPLE_MISC_AMT);
            param[108] = new SqlParameter("@MULTIPLE_HSS_AMT", MULTIPLE_HSS_AMT);

            param[167] = new SqlParameter("@SUPPLIER_BRANCH_SLNO", SUPPLIER_BRANCH_SLNO);

            param[168] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
            param[169] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);
            param[170] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

            param[110] = new SqlParameter("@TOTAL_MULTIPLE_MISC_AMT", SqlDbType.NVarChar, 1000);
            param[110].Direction = ParameterDirection.Output;

            param[111] = new SqlParameter("@TOTAL_MULTIPLE_HSS_AMT", SqlDbType.NVarChar, 1000);
            param[111].Direction = ParameterDirection.Output;

            if (MIS_SINGLE_OR_MULITIPLE == "M")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[84].Value.ToString());

                if (result == 1)
                {
                    ALL_FREIGHT_TOTAL = Convert.ToDouble(param[87].Value.ToString());
                    ALL_INSURANCE_TOTAL = Convert.ToDouble(param[88].Value.ToString());
                }
                string err = param[85].Value.ToString();

                if (param[110].Value.ToString() != string.Empty)
                {
                    TOTAL_MULTIPLE_MISC_AMT = Convert.ToDouble(param[110].Value.ToString());
                }
                else
                {
                    TOTAL_MULTIPLE_MISC_AMT = 0.00;
                }

                if (param[111].Value.ToString() != string.Empty)
                {
                    TOTAL_MULTIPLE_HSS_AMT = Convert.ToDouble(param[111].Value.ToString());
                }
                else
                {
                    TOTAL_MULTIPLE_HSS_AMT = 0.00;
                }

            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[84].Value.ToString());
                string err = param[85].Value.ToString();

            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Item_Details_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[325];

            param[0] = new SqlParameter("@ITEM_ID", ITEM_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", INV_SLNO);
            param[3] = new SqlParameter("@ITEM_DESCRIPTION", ITEM_DESCRIPTION);
            param[4] = new SqlParameter("@ITEM_QTY", ITEM_QTY);
            param[5] = new SqlParameter("@ITEM_QTY_CODE", ITEM_QTY_CODE);
            param[6] = new SqlParameter("@ITEM_UNIT_PRICE", ITEM_UNIT_PRICE);
            param[7] = new SqlParameter("@ITEM_UNIT_CODE", ITEM_UNIT_CODE);
            param[8] = new SqlParameter("@ITEM_TOTAL_AMOUNT", ITEM_TOTAL_AMOUNT);
            param[9] = new SqlParameter("@ITEM_AMOUNT_CODE", ITEM_AMOUNT_CODE);
            param[10] = new SqlParameter("@CTH_NO", CTH_NO);
            //ITEM_GENERAL
            param[11] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
            param[12] = new SqlParameter("@SCHEME_NOTN", SCHEME_NOTN);
            param[13] = new SqlParameter("@SCHEME_NOTN_SLNO", SCHEME_NOTN_SLNO);
            param[14] = new SqlParameter("@CTH_QTY1", CTH_QTY1);
            param[15] = new SqlParameter("@CTH_QTY2", CTH_QTY2);
            param[16] = new SqlParameter("@GENEARL_DESCRIPTION", GENEARL_DESCRIPTION);
            param[17] = new SqlParameter("@MANUFACTURER", MANUFACTURER);
            param[18] = new SqlParameter("@BRAND", BRAND);
            param[19] = new SqlParameter("@MODEL", MODEL);
            param[20] = new SqlParameter("@END_USE_OF_ITEM", END_USE_OF_ITEM);
            param[21] = new SqlParameter("@COUNTRY_OF_ORIGIN", COUNTRY_OF_ORIGIN);
            param[22] = new SqlParameter("@ACCESSORIES", ACCESSORIES);
            param[23] = new SqlParameter("@PREVIOUS_BE_NO", PREVIOUS_BE_NO);
            param[24] = new SqlParameter("@PREVIOUS_BE_DATE", DateTime.Parse(PREVIOUS_BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[25] = new SqlParameter("@UNIT_PRICE", UNIT_PRICE);
            param[26] = new SqlParameter("@UNIT_CODE", UNIT_CODE);
            param[27] = new SqlParameter("@CUSTOMS_HOUSE", ITEM_CUSTOMS_HOUSE);
            //ITEM_CTH
            param[28] = new SqlParameter("@PRODUCT_RITC", PRODUCT_RITC);
            param[29] = new SqlParameter("@PRODUCT_CTH", PRODUCT_CTH);
            param[30] = new SqlParameter("@PRODUCT_BCD_NOTN", PRODUCT_BCD_NOTN);
            param[31] = new SqlParameter("@PRODUCT_BCD_SLNO", PRODUCT_BCD_SLNO);
            param[32] = new SqlParameter("@PRODUCT_BCD_RATE", PRODUCT_BCD_RATE);
            param[33] = new SqlParameter("@PRODUCT_BCD_SPL", PRODUCT_BCD_SPL);
            param[34] = new SqlParameter("@PRODUCT_BCD_UNIT", PRODUCT_BCD_UNIT);
            param[35] = new SqlParameter("@PRODUCT_BCD_SPL_TYPE", PRODUCT_BCD_SPL_TYPE);
            param[36] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN", PRODUCT_ADDL_DUTY_NOTN);
            param[37] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN_SL", PRODUCT_ADDL_DUTY_NOTN_SL);
            param[38] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN", PRODUCT_EDU_CESS_NOTN);
            param[39] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN_SL", PRODUCT_EDU_CESS_NOTN_SL);
            param[40] = new SqlParameter("@PRODUCT_EDU_CESS_RATE", PRODUCT_EDU_CESS_RATE);
            param[41] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN", PRODUCT_SEC_EDU_CESS_NOTN);
            param[42] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN_SL", PRODUCT_SEC_EDU_CESS_NOTN_SL);
            param[43] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_RATE", PRODUCT_SEC_EDU_CESS_RATE);
            param[44] = new SqlParameter("@PRODUCT_NCD_NOTN", PRODUCT_NCD_NOTN);
            param[45] = new SqlParameter("@PRODUCT_NCD_SLNO", PRODUCT_NCD_SLNO);
            param[46] = new SqlParameter("@PRODUCT_NCD_RATE", PRODUCT_NCD_RATE);
            param[47] = new SqlParameter("@PRODUCT_NCD_SPL", PRODUCT_NCD_SPL);
            param[48] = new SqlParameter("@PRODUCT_NCD_UNIT", PRODUCT_NCD_UNIT);
            param[49] = new SqlParameter("@PRODUCT_NCD_SPL_TYPE", PRODUCT_NCD_SPL_TYPE);
            param[50] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN", PRODUCT_AGGREGATE_DUTY_NOTN);
            param[51] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_SL", PRODUCT_AGGREGATE_DUTY_NOTN_SL);
            param[52] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_RATE", PRODUCT_AGGREGATE_DUTY_NOTN_RATE);
            param[53] = new SqlParameter("@PRODUCT_SAFEGUARD_NOTN", PRODUCT_SAFEGUARD_NOTN);
            param[54] = new SqlParameter("@PRODUCT_SAFEGUARD_SLNO", PRODUCT_SAFEGUARD_SLNO);
            param[55] = new SqlParameter("@PRODUCT_SAFEGUARD_RATE", PRODUCT_SAFEGUARD_RATE);
            param[56] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL", PRODUCT_SAFEGUARD_SPL);
            param[57] = new SqlParameter("@PRODUCT_SAFEGUARD_UNIT", PRODUCT_SAFEGUARD_UNIT);
            param[58] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL_TYPE", PRODUCT_SAFEGUARD_SPL_TYPE);
            //ITEM_CETH
            param[59] = new SqlParameter("@PRODUCT_CETH", PRODUCT_CETH);
            param[60] = new SqlParameter("@PRODUCT_MRP_YN", PRODUCT_MRP_YN);
            param[61] = new SqlParameter("@PRODUCT_MRP_SL_NO", PRODUCT_MRP_SL_NO);
            param[62] = new SqlParameter("@PRODUCT_MRP_AMOUNT", PRODUCT_MRP_AMOUNT);
            param[63] = new SqlParameter("@PRODUCT_MRP_ABT_RATE", PRODUCT_MRP_ABT_RATE);
            param[64] = new SqlParameter("@PRODUCT_CVD_NOTN", PRODUCT_CVD_NOTN);
            param[65] = new SqlParameter("@PRODUCT_CVD_SLNO", PRODUCT_CVD_SLNO);
            param[66] = new SqlParameter("@PRODUCT_CVD_RATE", PRODUCT_CVD_RATE);
            param[67] = new SqlParameter("@PRODUCT_CVD_SPL", PRODUCT_CVD_SPL);
            param[68] = new SqlParameter("@PRODUCT_CVD_UNIT", PRODUCT_CVD_UNIT);
            param[69] = new SqlParameter("@PRODUCT_CVD_SPL_TYPE", PRODUCT_CVD_SPL_TYPE);
            param[70] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_RATE", PRODUCT_CVD_EDU_CESS_RATE);
            param[71] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_RATE", PRODUCT_CVD_SEC_EDU_CESS_RATE);
            param[72] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN", PRODUCT_ADDL5_SIA_NOTN);
            param[73] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN_SL", PRODUCT_ADDL5_SIA_NOTN_SL);
            param[74] = new SqlParameter("@PRODUCT_ADDL5_SIA_RATE", PRODUCT_ADDL5_SIA_RATE);
            param[75] = new SqlParameter("@PRODUCT_ADDL_GSI_NOTN", PRODUCT_ADDL_GSI_NOTN);
            param[76] = new SqlParameter("@PRODUCT_ADDL_GSI_SLNO", PRODUCT_ADDL_GSI_SLNO);
            param[77] = new SqlParameter("@PRODUCT_ADDL_GSI_RATE", PRODUCT_ADDL_GSI_RATE);
            param[78] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL", PRODUCT_ADDL_GSI_SPL);
            param[79] = new SqlParameter("@PRODUCT_ADDL_GSI_UNIT", PRODUCT_ADDL_GSI_UNIT);
            param[80] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL_TYPE", PRODUCT_ADDL_GSI_SPL_TYPE);
            param[81] = new SqlParameter("@PRODUCT_ADDL_SHEII_NOTN", PRODUCT_ADDL_SHEII_NOTN);
            param[82] = new SqlParameter("@PRODUCT_ADDL_SHEII_SLNO", PRODUCT_ADDL_SHEII_SLNO);
            param[83] = new SqlParameter("@PRODUCT_ADDL_SHEII_RATE", PRODUCT_ADDL_SHEII_RATE);
            param[84] = new SqlParameter("@PRODUCT_ADDL_SHEII_SPL", PRODUCT_ADDL_SHEII_SPL);
            param[85] = new SqlParameter("@PRODUCT_ADDL_SHEII_UNIT", PRODUCT_ADDL_SHEII_UNIT);
            param[86] = new SqlParameter("@PRODUCT_ADDL_SHEII_TYPE", PRODUCT_ADDL_SHEII_TYPE);
            param[87] = new SqlParameter("@PRODUCT_ADDL_TTA_NOTN", PRODUCT_ADDL_TTA_NOTN);
            param[88] = new SqlParameter("@PRODUCT_ADDL_TTA_SLNO", PRODUCT_ADDL_TTA_SLNO);
            param[89] = new SqlParameter("@PRODUCT_ADDL_TTA_RATE", PRODUCT_ADDL_TTA_RATE);
            param[90] = new SqlParameter("@PRODUCT_ADDL_TTA_SPL", PRODUCT_ADDL_TTA_SPL);
            param[91] = new SqlParameter("@PRODUCT_ADDL_TTA_UNIT", PRODUCT_ADDL_TTA_UNIT);
            param[92] = new SqlParameter("@PRODUCT_ADDL_TTA_TYPE", PRODUCT_ADDL_TTA_TYPE);
            param[93] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_NOTN", PRODUCT_ADDL_HEALTH_CESS_NOTN);
            param[94] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SLNO", PRODUCT_ADDL_HEALTH_CESS_SLNO);
            param[95] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_RATE", PRODUCT_ADDL_HEALTH_CESS_RATE);
            param[96] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SPL", PRODUCT_ADDL_HEALTH_CESS_SPL);
            param[97] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_UNIT", PRODUCT_ADDL_HEALTH_CESS_UNIT);
            param[98] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_TYPE", PRODUCT_ADDL_HEALTH_CESS_TYPE);
            param[99] = new SqlParameter("@PRODUCT_CESS_NOTN", PRODUCT_CESS_NOTN);
            param[100] = new SqlParameter("@PRODUCT_CESS_SLNO", PRODUCT_CESS_SLNO);
            param[101] = new SqlParameter("@PRODUCT_CESS_RATE", PRODUCT_CESS_RATE);
            param[102] = new SqlParameter("@PRODUCT_CESS_SPL", PRODUCT_CESS_SPL);
            param[103] = new SqlParameter("@PRODUCT_CESS_UNIT", PRODUCT_CESS_UNIT);
            param[104] = new SqlParameter("@PRODUCT_CESS_TYPE", PRODUCT_CESS_TYPE);
            //OTHERDUTY_DETAILS
            param[105] = new SqlParameter("@ANTI_DUMPING_NOTN", ANTI_DUMPING_NOTN);
            param[106] = new SqlParameter("@ANTI_DUMPING_NOTN_SLNO", ANTI_DUMPING_NOTN_SLNO);
            param[107] = new SqlParameter("@CTH_SLNO", CTH_SLNO);
            param[108] = new SqlParameter("@CTH_SUPPLIER_SLNO", CTH_SUPPLIER_SLNO);
            param[109] = new SqlParameter("@CTH_QTY", CTH_QTY);
            param[110] = new SqlParameter("@RSP_DUTY_STATUS", RSP_DUTY_STATUS);

            param[111] = new SqlParameter("@RSP_SL_NO", RSP_SL_NO);
            param[112] = new SqlParameter("@RSP_DESC", RSP_DESC);
            param[113] = new SqlParameter("@RSP_QTY", RSP_QTY);
            param[114] = new SqlParameter("@RSP_AMOUNT", RSP_AMOUNT);
            param[115] = new SqlParameter("@RSP_NOTN_NO", RSP_NOTN_NO);
            param[116] = new SqlParameter("@RSP_NOTN_SL_NO", RSP_NOTN_SL_NO);
            param[117] = new SqlParameter("@RSP_ABT_RATE", RSP_ABT_RATE);
            param[118] = new SqlParameter("ITEM_SLNO_LICENSE", ITEM_SLNO);
            param[119] = new SqlParameter("@CTH_QTY1_CODE", CTH_QTY1_CODE);
            param[120] = new SqlParameter("@CTH_QTY2_CODE", CTH_QTY2_CODE);
            param[121] = new SqlParameter("@PRODUCT_ADDL_DUTY_RATE", PRODUCT_ADDL_DUTY_RATE);

            param[122] = new SqlParameter("@PRODUCT_SAPTA_NOTN", PRODUCT_SAPTA_NOTN);
            param[123] = new SqlParameter("@PRODUCT_SAPTA_SLNO", PRODUCT_SAPTA_SLNO);
            param[124] = new SqlParameter("@PRODUCT_SAPTA_RATE", PRODUCT_SAPTA_RATE);
            param[125] = new SqlParameter("@PRODUCT_TARIFF_NOTN", PRODUCT_TARIFF_NOTN);
            param[126] = new SqlParameter("@PRODUCT_TARIFF_SLNO", PRODUCT_TARIFF_SLNO);
            param[127] = new SqlParameter("@PRODUCT_TARIFF_QTY", PRODUCT_TARIFF_QTY);
            param[128] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT", PRODUCT_TARIFF_AMOUNT);
            param[129] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT_UNIT", PRODUCT_TARIFF_AMOUNT_UNIT);
            param[130] = new SqlParameter("@WAREHOUSE_JOBNO", WAREHOUSE_JOBNO);
            param[131] = new SqlParameter("@WAREHOUSE_INVOICE_SLNO", WAREHOUSE_INVOICE_SLNO);
            param[132] = new SqlParameter("@WAREHOUSE_ITEM_SLNO", WAREHOUSE_ITEM_SLNO);

            param[134] = new SqlParameter("@CETH_CVD_EDU_CESS_SL", CETH_CVD_EDU_CESS_SL);
            param[135] = new SqlParameter("@CETH_CVD_EDU_CESS_RATE", CETH_CVD_EDU_CESS_RATE);
            param[136] = new SqlParameter("@CETH_CVD_SEC_EDU_CESS_SL", CETH_CVD_SEC_EDU_CESS_SL);
            param[137] = new SqlParameter("@CETH_CVD_SEC_EDU_CESS_RATE", CETH_CVD_SEC_EDU_CESS_RATE);
            //------01June2015---------------//
            param[138] = new SqlParameter("@PRODUCT_OTHER_DUTY_NOTN", PRODUCT_OTHER_DUTY_NOTN);
            param[139] = new SqlParameter("@PRODUCT_OTHER_DUTY_SLNO", PRODUCT_OTHER_DUTY_SLNO);
            param[140] = new SqlParameter("@PRODUCT_OTHER_DUTY_RATE", PRODUCT_OTHER_DUTY_RATE);
            param[141] = new SqlParameter("@PRODUCT_OTHER_DUTY_SPL", PRODUCT_OTHER_DUTY_SPL);
            param[142] = new SqlParameter("@PRODUCT_OTHER_DUTY_UNIT", PRODUCT_OTHER_DUTY_UNIT);
            param[143] = new SqlParameter("@PRODUCT_OTHER_DUTY_TYPE", PRODUCT_OTHER_DUTY_TYPE);
            //------01June2015---------------//
            param[144] = new SqlParameter("@SVB_RELATION", SVB_RELATION);
            param[145] = new SqlParameter("@SVB_REF_NO", SVB_REF_NO);
            param[146] = new SqlParameter("@SVB_REF_DATE", DateTime.Parse(SVB_REF_DATE == "" ? "01/01/1900" : SVB_REF_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[147] = new SqlParameter("@SVB_CUSTOM_HOUSE", SVB_CUSTOM_HOUSE);
            param[148] = new SqlParameter("@SVB_LOADING_ON", SVB_LOADING_ON);
            param[149] = new SqlParameter("@SVB_ASSESABLE_RATE", SVB_ASSESABLE_RATE);
            param[150] = new SqlParameter("@SVB_DUTY_RATE", SVB_DUTY_RATE);
            param[151] = new SqlParameter("@SVB_ASSESABLE_STATUS", SVB_ASSESABLE_STATUS);
            param[152] = new SqlParameter("@SVB_DUTY_STATUS", SVB_DUTY_STATUS);
            param[153] = new SqlParameter("@RSP_APPLICABLE", RSP_APPLICABLE);
            param[154] = new SqlParameter("@CENTRAL_EXCISE_FALG", CENTRAL_EXCISE_FALG);
            param[155] = new SqlParameter("@MANUFACTURER_PRODUCER", MANUFACTURER_PRODUCER);
            param[156] = new SqlParameter("@M_P_GROWER_CODE", M_P_GROWER_CODE);
            param[157] = new SqlParameter("@M_P_GROWER_ADD1", M_P_GROWER_ADD1);
            param[158] = new SqlParameter("@M_P_GROWER_ADD2", M_P_GROWER_ADD2);
            param[159] = new SqlParameter("@M_P_GROWER_CITY", M_P_GROWER_CITY);
            param[160] = new SqlParameter("@M_P_GROWER_COUNTRY_SUBDIV", M_P_GROWER_COUNTRY_SUBDIV);
            param[161] = new SqlParameter("@M_P_GROWER_PIN", M_P_GROWER_PIN);
            param[162] = new SqlParameter("@M_P_GROWER_COUNTRY", M_P_GROWER_COUNTRY);
            param[163] = new SqlParameter("@SOURCE_COUNTRY", SOURCE_COUNTRY);
            param[164] = new SqlParameter("@TRANSIT_COUNTRY", TRANSIT_COUNTRY);
            param[165] = new SqlParameter("@ACCESSORY_STATUS", ACCESSORY_STATUS);
            param[166] = new SqlParameter("@INFRA_CESS_NOTN", INFRA_CESS_NOTN);
            param[167] = new SqlParameter("@INFRA_CESS_NOTN_SL", INFRA_CESS_NOTN_SL);
            param[168] = new SqlParameter("@INFRA_CESS_NOTN_RATE", INFRA_CESS_NOTN_RATE);
            param[169] = new SqlParameter("@IGST_LEVY_NOTN", IGST_LEVY_NOTN);
            param[170] = new SqlParameter("@IGST_LEVY_SLNO", IGST_LEVY_SLNO);

            param[171] = new SqlParameter("@IGST_LEVY_RATE", IGST_LEVY_RATE);
            param[172] = new SqlParameter("@IGST_LEVY_SPL", IGST_LEVY_SPL);
            param[173] = new SqlParameter("@IGST_LEVY_UNIT", IGST_LEVY_UNIT);
            param[174] = new SqlParameter("@IGST_LEVY_SPL_TYPE", IGST_LEVY_SPL_TYPE);
            param[175] = new SqlParameter("@IGST_LEVY_EXCEPTION_NOTN", IGST_LEVY_EXCEPTION_NOTN);
            param[176] = new SqlParameter("@IGST_LEVY_EXCEPTION_SLNO", IGST_LEVY_EXCEPTION_SLNO);
            param[177] = new SqlParameter("@IGST_LEVY_EXCEPTION_RATE", IGST_LEVY_EXCEPTION_RATE);
            param[178] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_NOTN", IGST_LEVY_COMPENSATION_CESS_NOTN);
            param[179] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SLNO", IGST_LEVY_COMPENSATION_CESS_SLNO);
            param[180] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_RATE", IGST_LEVY_COMPENSATION_CESS_RATE);
            param[181] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SPL", IGST_LEVY_COMPENSATION_CESS_SPL);
            param[182] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_UNIT", IGST_LEVY_COMPENSATION_CESS_UNIT);
            param[183] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SPL_TYPE", IGST_LEVY_COMPENSATION_CESS_SPL_TYPE);
            param[184] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_NOTN", IGST_LEVY_EXCEPTION_CC_NOTN);
            param[185] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_SLNO", IGST_LEVY_EXCEPTION_CC_SLNO);
            param[186] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_RATE", IGST_LEVY_EXCEPTION_CC_RATE);
            param[187] = new SqlParameter("@LEVY_EXCEMPTION_NOTN_TYPE", LEVY_EXCEMPTION_NOTN_TYPE);
            param[188] = new SqlParameter("@LEVY_EXCEPTION_CC_NOTN_TYPE", LEVY_EXCEPTION_CC_NOTN_TYPE);
            param[189] = new SqlParameter("@SOCIAL_WELFARE_NOTN", SOCIAL_WELFARE_NOTN);
            param[190] = new SqlParameter("@SOCIAL_WELFARE_NOTN_SLNO", SOCIAL_WELFARE_NOTN_SLNO);
            param[191] = new SqlParameter("@SOCIAL_WELFARE_RATE", SOCIAL_WELFARE_RATE);
            param[192] = new SqlParameter("@INFO_MSR", Info_Msr);
            param[193] = new SqlParameter("@INFO_UQC", Info_Uqc);
            param[194] = new SqlParameter("@SIMS", SIMS);

            param[195] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
            param[196] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);

            param[197] = new SqlParameter("@AIDC_NOTN", AIDC_NOTN);
            param[198] = new SqlParameter("@AIDC_NOTN_SLNO", AIDC_NOTN_SLNO);
            param[199] = new SqlParameter("@AIDC_RATE", AIDC_RATE);
            param[200] = new SqlParameter("@ADD_EX_RATE", ADD_EX_RATE);

            param[201] = new SqlParameter("@EXC_AIDC_NOTN", EXC_AIDC_NOTN);
            param[202] = new SqlParameter("@EXC_AIDC_NOTN_SLNO", EXC_AIDC_NOTN_SLNO);
            param[203] = new SqlParameter("@EXC_AIDC_RATE", EXC_AIDC_RATE);


            //--------------Continue To param[196]---196-----------------------
            param[279] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[280] = new SqlParameter("@USER_ID", USER_ID);
            param[281] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[282] = new SqlParameter("@YEAR", YEAR);
            param[283] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[284] = new SqlParameter("@Mflag", flag);
            //-------------------------------------
            param[285] = new SqlParameter("@UPDATE_ITEMSLNO", SqlDbType.Int, 1);
            param[285].Direction = ParameterDirection.Output;
            param[286] = new SqlParameter("@UPDATE_INVOICE_NO", SqlDbType.VarChar, 30);
            param[286].Direction = ParameterDirection.Output;
            param[287] = new SqlParameter("@TOTAL_PRODUCT_VALUE", SqlDbType.Money);
            param[287].Direction = ParameterDirection.Output;
            param[288] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[288].Direction = ParameterDirection.Output;
            param[299] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[299].Direction = ParameterDirection.Output;
            param[300] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[300].Direction = ParameterDirection.Output;
            param[301] = new SqlParameter("@JOBNO_PS", JOBNO_PS);
            param[302] = new SqlParameter("@PART_NO", PART_NO);//Added by pandiyan on 12-05-2025
            param[303] = new SqlParameter("@FOC_ITEM", FOC_ITEM);//Added by pandiyan on 14-09-2026

            ds = Connection.Get_Dataset("SP_ITEM_DETAILS_INSERT_UPDATE_NEW", param);

            string err = param[300].Value.ToString();
            result = Convert.ToInt32(param[299].Value.ToString());

            TOTAL_ITEM_VALUE = param[287].Value.ToString();
            if (TOTAL_ITEM_VALUE != "")
                TOTAL_ITEM_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_ITEM_VALUE), 2).ToString("0.00"));

            if (flag == "S")
            {
                UPDATE_ITEMSLNO = Convert.ToInt32(param[285].Value.ToString());
                UPDATE_INVOICE_NO = param[286].Value.ToString();
                UPDATE_ID = Convert.ToInt32(param[288].Value.ToString());
            }
            else if (flag == "U")
            {
                UPDATE_INVOICE_NO = param[286].Value.ToString();
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Gridview_Rowcount = ds.Tables[0].Rows.Count;
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Import_Item_ASS_Duty_CIF_CVD_VLAUE_UPDATE()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[60];
            param[0] = new SqlParameter("@ITEM_ID", ITEM_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INV_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[4] = new SqlParameter("@ASSESSABLE_VALUE", ASSESSABLE_VALUE);
            param[5] = new SqlParameter("@DUTY_VALUE", DUTY_VALUE);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@Mflag", flag);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@CIF_VALUE", CIF_VALUE);
            param[11] = new SqlParameter("@CVD_VALUE", CVD_VALUE);
            param[12] = new SqlParameter("@BASIC_VALUE", BASIC_VALUE);
            param[13] = new SqlParameter("@CEC_VALUE", CEC_VALUE);
            param[14] = new SqlParameter("@CHEC_VALUE", CHEC_VALUE);
            param[15] = new SqlParameter("@ADD_DUTY_VALUE", ADD_DUTY_VALUE);

            param[16] = new SqlParameter("@INDIVITUAL_FREIGHT_AMOUNT", INDIVITUAL_FREIGHT_AMOUNT);
            param[17] = new SqlParameter("@INDIVITUAL_INSURANCE_AMOUNT", INDIVITUAL_INSURANCE_AMOUNT);
            param[18] = new SqlParameter("@INDIVITUAL_MISC_AMOUNT", INDIVITUAL_MISC_AMOUNT);

            param[19] = new SqlParameter("@INDIVITUAL_EDU_CESS_AMT", INDIVITUAL_EDU_CESS_AMT);
            param[20] = new SqlParameter("@INDIVITUAL_SEC_HIGHER_CESS_AMT", INDIVITUAL_SEC_HIGHER_CESS_AMT);
            param[21] = new SqlParameter("@INDIVITUAL_LANDING_CHARGE", INDIVITUAL_LANDING_CHARGE);

            param[22] = new SqlParameter("@CHECKLIST_BCD_RATE", CHECKLIST_BCD_RATE);
            param[23] = new SqlParameter("@CHECKLIST_CVD_RATE", CHECKLIST_CVD_RATE);
            param[24] = new SqlParameter("@CHECKLIST_ADDL_DUTY_RATE", CHECKLIST_ADDL_DUTY_RATE);

            param[25] = new SqlParameter("@MERIT_DUTY_VALUE", MERIT_DUTY_VALUE);
            param[26] = new SqlParameter("@PRODUCT_BCD_RATE", PRODUCT_BCD_RATE);
            param[27] = new SqlParameter("@PRODUCT_CVD_RATE", PRODUCT_CVD_RATE);


            param[28] = new SqlParameter("@MERIT_BASIC_VALUE", MERIT_BASIC_VALUE);
            param[29] = new SqlParameter("@MERIT_CVD_VALUE", MERIT_CVD_VALUE);
            param[30] = new SqlParameter("@MERIT_CEC_VALUE", MERIT_CEC_VALUE);
            param[31] = new SqlParameter("@MERIT_CHEC_VALUE", MERIT_CHEC_VALUE);
            param[32] = new SqlParameter("@MERIT_ADD_DUTY_VALUE", MERIT_ADD_DUTY_VALUE);

            param[33] = new SqlParameter("@MERIT_NOTN_BASIC_VALUE", MERIT_NOTN_BASIC_VALUE);
            param[34] = new SqlParameter("@MERIT_NOTN_CVD_VALUE", MERIT_NOTN_CVD_VALUE);
            param[35] = new SqlParameter("@MERIT_NOTN_CEC_VALUE", MERIT_NOTN_CEC_VALUE);
            param[36] = new SqlParameter("@MERIT_NOTN_CHEC_VALUE", MERIT_NOTN_CHEC_VALUE);
            param[37] = new SqlParameter("@MERIT_NOTN_ADD_DUTY_VALUE", MERIT_NOTN_ADD_DUTY_VALUE);
            param[38] = new SqlParameter("@MERIT_NOTN_CESS_VALUE", MERIT_NOTN_CESS_VALUE);
            param[39] = new SqlParameter("@MERIT_NOTN_NCD_VALUE", MERIT_NOTN_NCD_VALUE);
            param[40] = new SqlParameter("@INDIVITUAL_HSS_AMOUNT", INDIVITUAL_HSS_AMOUNT);

            param[41] = new SqlParameter("@CHECKLIST_IGST_LEVY_AMOUNT", CHECKLIST_IGST_LEVY_AMOUNT == null ? "0" : CHECKLIST_IGST_LEVY_AMOUNT);
            param[42] = new SqlParameter("@CHECKLIST_COMPENSATION_CC_AMOUNT", CHECKLIST_COMPENSATION_CC_AMOUNT == null ? "0" : CHECKLIST_COMPENSATION_CC_AMOUNT);

            param[43] = new SqlParameter("@IGST_LEVY_RATE", IGST_LEVY_RATE);
            param[44] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_RATE", IGST_LEVY_COMPENSATION_CESS_RATE);

            param[45] = new SqlParameter("@CHECKLIST_SOCIAL_WELFARE_AMT", CHECKLIST_SOCIAL_WELFARE_AMT);

            param[46] = new SqlParameter("@CHECKLIST_HEALTH_CESS_AMT", CHECKLIST_HEALTH_CESS_AMT);
            param[47] = new SqlParameter("@CHECKLIST_ANTI_DUMPING_AMT", CHECKLIST_ANTI_DUMPING_AMT);


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_ITEM_ASS_DUTY_CIF_CVD_VALUE_UPDATE", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Invoice_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[7] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[8] = new SqlParameter("@TERMS", TERMS);
            param[9] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);

            param[1] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@ALL_FREIGHT_TOTAL", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ALL_INSURANCE_TOTAL", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@TOTAL_MULTIPLE_MISC_AMT", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@TOTAL_MULTIPLE_HSS_AMT", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@Mflag", flag);


            param[23] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[24] = new SqlParameter("@USER_ID", Connection.Current_User());


            if (flag == "INVOICE_NO" || flag == "Bind_Invoice_SlNo_Dropdown" || flag == "Get_InvoiceSlno_MAX" || flag == "Check_Inv_Slno_Avail_Save" || flag == "Check_Inv_Slno_Avail_Update")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_SELECT", param);

            }
            else if (flag == "Update_SVB_All_Invoices" || flag == "Distinct_Invoice_Currency_List" || flag == "Update_Invoice_exRate_Currency_List" || flag == "Update_Manufacturer_from_Supplier")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[2].Value.ToString());
            }
            else if (flag == "INVOICE_VALUE")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_SELECT", param);

            }
            else if (flag == "Delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_SELECT", param);

                result = Convert.ToInt32(param[2].Value.ToString());
                string err = param[3].Value.ToString();
                if (result == 1)
                {
                    string Freight = param[4].Value.ToString();
                    string Insurance = param[5].Value.ToString();

                    if (Freight != "")
                    {
                        ALL_FREIGHT_TOTAL = Convert.ToDouble(Freight);
                    }
                    if (Insurance != "")
                    {
                        ALL_INSURANCE_TOTAL = Convert.ToDouble(Insurance);
                    }

                    if (param[11].Value.ToString() != string.Empty)
                    {
                        TOTAL_MULTIPLE_MISC_AMT = Convert.ToDouble(param[11].Value.ToString());
                    }
                    else
                    {
                        TOTAL_MULTIPLE_MISC_AMT = 0.00;
                    }

                    if (param[12].Value.ToString() != string.Empty)
                    {
                        TOTAL_MULTIPLE_HSS_AMT = Convert.ToDouble(param[12].Value.ToString());
                    }
                    else
                    {
                        TOTAL_MULTIPLE_HSS_AMT = 0.00;
                    }
                }
            }
            else if (flag == "Delete_Excel")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[2].Value.ToString());
                string err = param[3].Value.ToString();
                if (result == 1)
                {
                    string Freight = param[4].Value.ToString();
                    string Insurance = param[5].Value.ToString();

                    if (Freight != "")
                    {
                        ALL_FREIGHT_TOTAL = Convert.ToDouble(Freight);
                    }
                    if (Insurance != "")
                    {
                        ALL_INSURANCE_TOTAL = Convert.ToDouble(Insurance);
                    }
                }
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_SELECT", param);
                string Freigh1t = param[3].Value.ToString();

                string Freight = param[4].Value.ToString();
                string Insurance = param[5].Value.ToString();

                if (Freight != "")
                {
                    ALL_FREIGHT_TOTAL = Convert.ToDouble(Freight);
                }
                if (Insurance != "")
                {
                    ALL_INSURANCE_TOTAL = Convert.ToDouble(Insurance);
                }
                if (param[11].Value.ToString() != string.Empty)
                {
                    TOTAL_MULTIPLE_MISC_AMT = Convert.ToDouble(param[11].Value.ToString());
                }
                else
                {
                    TOTAL_MULTIPLE_MISC_AMT = 0.00;
                }

                if (param[12].Value.ToString() != string.Empty)
                {
                    TOTAL_MULTIPLE_HSS_AMT = Convert.ToDouble(param[12].Value.ToString());
                }
                else
                {
                    TOTAL_MULTIPLE_HSS_AMT = 0.00;
                }

            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Inv_result = "1";
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_IGM_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[6] = new SqlParameter("@IGM_SLNO", IGM_SLNO_UPDATE);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@IGM_TRANSPORTMODE", TRANSPORT_MODE);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[14] = new SqlParameter("@USER_ID", Connection.Current_User());

            if (Ename == "select_con" || Ename == "Update_Gen_FilingStatus")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_SELECT", param);
                string err = param[5].Value.ToString();
            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Container_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@CONTAINER_IGM_NO", CONTAINER_IGM_NO);
            param[2] = new SqlParameter("@CONTAINER_IGM_SLNO", CONTAINER_IGM_SLNO);
            param[3] = new SqlParameter("@CONTAINER_NO", CONTAINER_NO);
            param[4] = new SqlParameter("@name", Ename);
            param[5] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;


            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[14] = new SqlParameter("@USER_ID", Connection.Current_User());

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONTAINER_DETAILS_SELECT", param);
                string err = param[7].Value.ToString();


            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONTAINER_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_BOND_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@BOND_NO", BOND_NO);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[14] = new SqlParameter("@USER_ID", Connection.Current_User());

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_BOND_DETAILS_SELECT", param);
                string err = param[5].Value.ToString();

            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_BOND_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);



        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_Certificate_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@CERTIFICATE_NO", CERTIFICATE_NO);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[14] = new SqlParameter("@USER_ID", Connection.Current_User());


            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CERTIFICATE_DETAILS_SELECT", param);
                string err = param[5].Value.ToString();
            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CERTIFICATE_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);



        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Item_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[7] = new SqlParameter("@ITEM_ID", ITEM_ID);
            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[3] = new SqlParameter("@name", Ename);
            param[4] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[9] = new SqlParameter("@TOTAL_PRODUCT_VALUE", SqlDbType.Money);
            param[9].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[14] = new SqlParameter("@USER_ID", Connection.Current_User());

            if (Ename == "select_con" || Ename == "Item_Move" || Ename == "Item_MoveUp" || Ename == "Item_MoveDown" || Ename == "Item_Sl_No_Select" || Ename == "Select_BindAll_ItemDetails" || Ename == "Update_CountryOfOrigin" || Ename == "select_con_GridBind_New" || Ename == "select_con_ItemSlNo" || Ename == "Get_SupplierName")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_SELECT", param);
            }
            else if (Ename == "product_value" || Ename == "Check_Higher_than_Value_Sum")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_SELECT", param);
            }
            else if (Ename == "select_Invoice_No" || Ename == "Get_ItemSlno_MAX" || Ename == "Check_Item_Slno_Avail_Save" || Ename == "Check_Item_Slno_Avail_Update")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_SELECT", param);
            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            string err = param[6].Value.ToString();


            TOTAL_ITEM_VALUE = param[9].Value.ToString();
            if (TOTAL_ITEM_VALUE != "")
                TOTAL_ITEM_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_ITEM_VALUE), 2).ToString("0.00"));


            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Gridview_Rowcount = ds.Tables[0].Rows.Count;

                }
                else
                    ds.Tables.Add(dt.Copy());

            }
            else
                ds.Tables.Add(dt.Copy());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_ReImport_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[2] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[4] = new SqlParameter("@RE_IMPORT_ID", RE_IMPORT_ID);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[14] = new SqlParameter("@USER_ID", Connection.Current_User());

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_RE_IMPORT_DETAILS_SELECT", param);
                string err = param[8].Value.ToString();

            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_RE_IMPORT_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt.Copy());
            }
            else
                ds.Tables.Add(dt.Copy());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    //public DataSet RetrieveAll_License_Details()
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[15];
    //        param[0] = new SqlParameter("@JOBNO", JOBNO);
    //        param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
    //        param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
    //        param[8] = new SqlParameter("@DEBIT_AMT", DEBIT_AMT);
    //        param[9] = new SqlParameter("@DEBIT_DUTY", DEBIT_DUTY);
    //        param[3] = new SqlParameter("@LICENSE_ID", LICENSE_ID);
    //        param[4] = new SqlParameter("@name", Ename);
    //        param[5] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
    //        param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
    //        param[6].Direction = ParameterDirection.Output;
    //        param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[7].Direction = ParameterDirection.Output;

    //        param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
    //        param[14] = new SqlParameter("@USER_ID", Connection.Current_User());

    //        string find = "";
    //        if (Ename == "select_con" || Ename == "Get_Update_Debitamt_License_Details" || Ename == "select_ExRate_Grid_UpdateAll")
    //        {
    //            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_DETAILS_SELECT", param);
    //            string err = param[7].Value.ToString();
    //        }
    //        else if (Ename == "Update_Debit_Amt" || Ename == "UpdateAll_ExRate_Job" || Ename == "Clear_All_CIF_Duty_for_new_Exrate_Update")
    //        {
    //            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_DETAILS_SELECT", param);
    //            result = Convert.ToInt32(param[6].Value.ToString());
    //            find = "no";
    //        }
    //        else if (Ename == "delete")
    //        {
    //            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_DETAILS_SELECT", param);
    //            result = Convert.ToInt32(param[6].Value.ToString());
    //        }
    //        if (find == "")
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows.Count > 0)
    //                {
    //                }
    //                else
    //                    ds.Tables.Add(dt);

    //            }
    //            else
    //                ds.Tables.Add(dt);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return ds;
    //}

    public DataSet RetrieveAll_License_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[3] = new SqlParameter("@DEBIT_AMT", DEBIT_AMT);
            param[4] = new SqlParameter("@DEBIT_DUTY", DEBIT_DUTY);
            param[5] = new SqlParameter("@LICENSE_ID", LICENSE_ID);
            param[6] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@USER_ID", Connection.Current_User());
            string find = "";
            if (Ename == "select_con" || Ename == "Get_Update_Debitamt_License_Details" || Ename == "select_ExRate_Grid_UpdateAll")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_DETAILS_SELECT", param);
                string err = param[9].Value.ToString();
            }
            else if (Ename == "Update_Debit_Amt" || Ename == "UpdateAll_ExRate_Job" || Ename == "Clear_All_CIF_Duty_for_new_Exrate_Update")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());
                find = "no";
            }
            else if (Ename == "delete" || Ename == "delete_all")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());
            }

            if (find == "")
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataTable RetrieveAll_General_Details_datatable()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@JOBID", JOBID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
            param[13] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);

            param[23] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[24] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[15] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());

            if (Ename == "delete")
            {
               // SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT_USERWISE_IEC_BASED_SEARCH", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "select_Id")
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT_USERWISE_IEC_BASED_SEARCH", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
            }
            else
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT_USERWISE_IEC_BASED_SEARCH", param);
                string err = param[8].Value.ToString();
                result = Convert.ToInt32(param[11].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds.Tables[0];
    }

    public DataSet RetrieveAll_General_Details_datatablefrmDelJobs()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@JOBID", JOBID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);



            param[7] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
            param[8] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);
            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[11] = new SqlParameter("@USER_ID", Connection.Current_User());

            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT_DEL_BCK", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_General_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@JOBID", JOBID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
            param[13] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);

            param[14] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[15] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[16] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());


            if (Ename == "delete" || Ename == "Delete_Exbond_Details")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT_USERWISE_IEC_BASED_SEARCH", param);
                // SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param); //hide on 17-08-2026

                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "select_Id" || Ename == "Exbond_select_Id" || Ename == "select_Id_Submission")
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param); //hide on 17-08-2026
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT_USERWISE_IEC_BASED_SEARCH", param);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
            }

            else if (Ename == "select_Details" || Ename == "GetJobId")
            {
                // ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param); //hide on 17-08-2026
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT_USERWISE_IEC_BASED_SEARCH", param);

                result = Convert.ToInt32(param[7].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
            }
            else if (Ename == "select_Assable_Val")
            {
                ds = SqlHelper.ExecuteDataset(
                    HttpContext.Current.Session["currentcomp_db"].ToString(),
                    CommandType.StoredProcedure,
                    //"SP_GENERAL_DETAILS_SEARCH_SELECT",
                     "SP_GENERAL_DETAILS_SEARCH_SELECT_USERWISE_IEC_BASED_SEARCH",
                    param);

                return ds;
            }

            else
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);//hide on 17-08-2026
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT_USERWISE_IEC_BASED_SEARCH", param);
                result = Convert.ToInt32(param[11].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    public DataSet RetrieveAll_General_Details(string Con_str)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@JOBID", JOBID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
            param[13] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);

            param[23] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[24] = new SqlParameter("@USER_ID", Connection.Current_User());


            if (Ename == "delete" || Ename == "Delete_Exbond_Details")
            {
                SqlHelper.ExecuteDataset(Con_str, CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "select_Id" || Ename == "Exbond_select_Id")
            {
                ds = SqlHelper.ExecuteDataset(Con_str, CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
            }

            else if (Ename == "select_Details")
            {
                ds = SqlHelper.ExecuteDataset(Con_str, CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
            }
            else
            {

                ds = SqlHelper.ExecuteDataset(Con_str, CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[11].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public int Generate_Duplicate_Job()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@OLD_JOBNO", OLD_JOBNO);
            param[1] = new SqlParameter("@CURRENT_JOBNO", JOBNO);
            param[2] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[3] = new SqlParameter("@USERID", USER_ID);
            param[4] = new SqlParameter("@name", Ename);
            param[5] = new SqlParameter("@Working_Period", WORKING_PERIOD);
            param[6] = new SqlParameter("@DB_Name", DBS_Name);

            param[7] = new SqlParameter("@Company_license", Connection.Company_License());
            param[8] = new SqlParameter("@Current_Branch", Connection.Current_Branch());
            param[9] = new SqlParameter("@Job_Prefix", JOB_PREFIX);
            param[10] = new SqlParameter("@Job_Suffix", JOB_SUFFIX);

            param[11] = new SqlParameter("@Current_Working_Period", Current_Working_Period);
            param[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;

            if (Ename == "Duplicate_Job")
            {
                if (DB_Type == "Same")
                {
                    SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GENERATE_IMPORT_DUPLICATE_JOB", param);
                }
                else if (DB_Type == "Diff")
                {
                    SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GENERATE_IMPORT_DUPLICATE_JOB_WORK_PERIOD", param);
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }


    public DataSet RetrieveAll_Warehouse_Job_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            if (Ename == "select_Warehouse_JobNo" || Ename == "select_SEZ_Warehouse_JobNo")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "WAREHOUSE_EXBOND_DETAILS_SELECT", param);
            }
            else if (Ename == "select_Details" || Ename == "WH_select_Details")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "WAREHOUSE_EXBOND_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public int Generate_Warehouse_Duplicate_Job()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[35];
            param[0] = new SqlParameter("@OLD_JOBNO", OLD_JOBNO);
            param[1] = new SqlParameter("@CURRENT_JOBNO", JOBNO);
            param[9] = new SqlParameter("@ITEM_ID", ITEM_ID);
            param[10] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[11] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[12] = new SqlParameter("@ITEM_DESCRIPTION", ITEM_DESCRIPTION);
            param[13] = new SqlParameter("@ITEM_QTY", ITEM_QTY);
            param[14] = new SqlParameter("@ITEM_QTY_CODE", ITEM_QTY_CODE);
            param[2] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[3] = new SqlParameter("@USERID", USER_ID);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@Working_Period", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Port_Orgin", Port_Orgin);
            param[18] = new SqlParameter("@Port_Shipment", Port_Shipment);
            param[19] = new SqlParameter("@Cus_House", Cus_House);
            param[20] = new SqlParameter("@Tr_Mode", Tr_Mode);

            param[21] = new SqlParameter("@JOBNO_PS", JOBNO_PS);
            param[22] = new SqlParameter("@JOB_PREFIX", JOB_PREFIX);
            param[23] = new SqlParameter("@JOB_SUFFIX", JOB_SUFFIX);
            param[24] = new SqlParameter("@Company_Id", Connection.COMPANYID());

            if (Ename == "Duplicate_Job")
            {
                Connection.Get_Dataset("IMPORT_WAREHOUSE_EXBOND_DETAILS_DUPLICATE_JOB", param);
                string err = param[8].Value.ToString();
                result = Convert.ToInt32(param[7].Value.ToString());
            }

            else if (Ename == "Duplicate_Job_Branch_TO_Branch")
            {
                Connection.Get_Dataset("IMPORT_WAREHOUSE_EXBOND_DETAILS_DUPLICATE_JOB_BRANCH_TO_BRANCH", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }


    public DataSet Retrieve_General_Gridbind_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@startRowIndex", startRowIndex);
            param[1] = new SqlParameter("@maximumRows", maximumRows);
            param[2] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GENERAL_SELECT_GRIDBIND", param);
            result = (int)param[2].Value;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public double RetrieveAll_()
    {
        double f = 0;
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[7] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[1] = new SqlParameter("@QTY", QTY);
            param[3] = new SqlParameter("@Mflag", Ename);
            param[4] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[5] = new SqlParameter("@MStatus", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ITEM_VALUE", ITEM_VALUE);
            param[9] = new SqlParameter("@flag", Flag);
            param[10] = new SqlParameter("@ITEM_ID", ITEM_ID);

            if (Ename == "QTY")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_INSERT_UPDATE_CALC", param);
                string err = param[6].Value.ToString();
                f = Convert.ToDouble(param[5].Value);

            }
            else if (Ename == "UNITPRICE")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_INSERT_UPDATE_CALC", param);
                string err = param[6].Value.ToString();
                f = Convert.ToDouble(param[5].Value);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return f;
    }

    public void Bulk_Item_Excel_Upload(DataTable dt, DataTable dt1, DataTable dt2, string mode)
    {

        try
        {
            cmd = new SqlCommand();
            conn = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "IMPORT_BULK_ITEM_EXCEL_UPLOAD_NEW";
            cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 100).Value = mode.Trim();
            cmd.Parameters.Add("@InvoiceDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt);
            cmd.Parameters.Add("@ItemDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt1);
            cmd.Parameters.Add("@LicenseDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt2);
            cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mstatus", SqlDbType.Int, 10).Direction = ParameterDirection.Output;
            cmd.Connection = conn;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            string result1 = cmd.Parameters["@ErrorMsg"].Value.ToString();

            result = Convert.ToInt32(cmd.Parameters["@Mstatus"].Value.ToString());
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(HttpContext.Current.Session["currentcomp_db"].ToString(), SqlBulkCopyOptions.KeepIdentity))
            {
                bulkCopy.DestinationTableName = "INVOICE_DETAILS";
                bulkCopy.WriteToServer(ds.Tables[0]);
                bulkCopy.DestinationTableName = "ITEM_PRODUCT_DETAILS";
                bulkCopy.WriteToServer(ds.Tables[1]);
                bulkCopy.DestinationTableName = "LICENSE_DETAILS";
                bulkCopy.WriteToServer(ds.Tables[2]);
                bulkCopy.Close();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {
            conn.Dispose();
            conn.Close();
        }
    }


    public void IMP_XL_UPLOAD_BULK_ENTRY()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@JOBNO", Connection.IMP_Jobno());
            param[2] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[3] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[5] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("IMP_XL_UPLOAD_DECLARATION_BULK_ENTRY", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public string ConvertDatatableToXML(DataTable dt)
    {
        MemoryStream str = new MemoryStream();
        dt.WriteXml(str, true);
        str.Seek(0, SeekOrigin.Begin);
        StreamReader sr = new StreamReader(str);
        string xmlstr;
        xmlstr = sr.ReadToEnd();
        return (xmlstr);
    }
    public DataSet Bulk_Item_Excel_Upload1(DataSet ds, string mode)
    {
        SqlConnection con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandTimeout = 0;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "IMPORT_BULK_ITEM_EXCEL_UPLOAD";
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 100).Value = mode.Trim();
        cmd.Parameters.Add("@InvoiceDetails", SqlDbType.Xml).Value = ds.GetXml();
        cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Mstatus", SqlDbType.Int, 10).Direction = ParameterDirection.Output;
        cmd.Connection = con;
        try
        {
            ds.Clear();
            ds.Dispose();
            con.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(ds);
            sdr.Dispose();
            string result1 = cmd.Parameters["@ErrorMsg"].Value.ToString();
            con.Dispose();
            con.Close();
            result = Convert.ToInt32(cmd.Parameters["@Mstatus"].Value.ToString());
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;
    }
    public int SQLBULK(DataSet dss, int i)
    {
        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(HttpContext.Current.Session["currentcomp_db"].ToString(), SqlBulkCopyOptions.KeepIdentity))
        {
            bulkCopy.DestinationTableName = "INVOICE_DETAILS";
            bulkCopy.WriteToServer(dss.Tables[0]);
            bulkCopy.DestinationTableName = "ITEM_PRODUCT_DETAILS";
            bulkCopy.WriteToServer(dss.Tables[1]);
            bulkCopy.DestinationTableName = "LICENSE_DETAILS";
            bulkCopy.WriteToServer(dss.Tables[2]);
            bulkCopy.Close();
        }
        return i;
    }
    public DataTable Bind_Dt(DataTable dt, DataTable dt1, DataTable dt2, string mode)
    {
        conn = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());
        SqlCommand cmdd = new SqlCommand();
        DataTable dss = new DataTable();
        cmdd.CommandTimeout = 0;
        cmdd.CommandType = CommandType.StoredProcedure;
        cmdd.CommandText = "IMPORT_BULK_ITEM_EXCEL_UPLOAD_NEW";
        cmdd.Parameters.Add("@Mode", SqlDbType.VarChar, 100).Value = mode.Trim();
        cmdd.Parameters.Add("@InvoiceDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt);
        cmdd.Parameters.Add("@ItemDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt1);
        cmdd.Parameters.Add("@LicenseDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt2);
        cmdd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
        cmdd.Parameters.Add("@Mstatus", SqlDbType.Int, 10).Direction = ParameterDirection.Output;
        cmdd.Connection = conn;

        SqlDataAdapter da = new SqlDataAdapter(cmdd);
        da.Fill(dss);
        string result1 = cmdd.Parameters["@ErrorMsg"].Value.ToString();
        conn.Dispose();
        conn.Close();
        result = Convert.ToInt32(cmdd.Parameters["@Mstatus"].Value.ToString());

        return dss;
    }

    public DataSet RetrieveAll_IGM_HAWB_NO()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@IGM_HAWB_HBLNO", IGM_HAWB_HBLNO);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[3] = new SqlParameter("@Ename", Ename);
            param[4] = new SqlParameter("@IGMSLNO", IGMSLNO);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_CHK_IGM_HAWB_HBLNO", param);
            string err = param[5].Value.ToString();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Bulk_Item_Excel_Upload_GMMCO(DataTable dt, DataTable dt1, string mode, string INDEV_INV_TYPE)
    {
        try
        {
            cmd = new SqlCommand();
            conn = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "IMPORT_BULK_ITEM_EXCEL_UPLOAD_NEW_GMMCO";
            cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 100).Value = mode.Trim();
            cmd.Parameters.Add("@INDEV_INV_TYPE", SqlDbType.VarChar, 100).Value = INDEV_INV_TYPE;
            cmd.Parameters.Add("@InvoiceDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt);
            cmd.Parameters.Add("@ItemDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt1);
            cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mstatus", SqlDbType.Int, 10).Direction = ParameterDirection.Output;
            cmd.Connection = conn;
            da = new SqlDataAdapter(cmd);
            DataSet dsss = new DataSet();

            da.Fill(dsss);
            string result1 = cmd.Parameters["@ErrorMsg"].Value.ToString();

            result = Convert.ToInt32(cmd.Parameters["@Mstatus"].Value.ToString());
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(HttpContext.Current.Session["currentcomp_db"].ToString(), SqlBulkCopyOptions.KeepIdentity))
            {
                bulkCopy.DestinationTableName = "INVOICE_DETAILS";
                bulkCopy.WriteToServer(dsss.Tables[0]);
                bulkCopy.DestinationTableName = "ITEM_PRODUCT_DETAILS";
                bulkCopy.WriteToServer(dsss.Tables[1]);
                bulkCopy.Close();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {
            conn.Dispose();
            conn.Close();
        }
    }

    public DataSet ExcelUpload_Container_Details()
    {
        DataSet ds_con = new DataSet();
        DataTable dt_con = new DataTable();

        try
        {

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@CONTAINERID", CONTAINERID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            if (Ename == "delete" || Ename == "Delete_All_Containers" || Ename == "Delete_All_Containers_IGM_Slno_Wise")
            {
                ds_con = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_CONTAINER_DETAILS_BULKUPOLAD", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select" || Ename == "Select_MAX_Container_ID")
            {
                ds_con = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_CONTAINER_DETAILS_BULKUPOLAD", param);
                string err = param[5].Value.ToString();
            }

            if (ds_con.Tables.Count > 0)
            {
                if (ds_con.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds_con.Tables.Add(dt_con);
            }
            else
                ds_con.Tables.Add(dt_con);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_con;
    }

    public DataSet Bind_Import_ExcelUpload_SpecialChars(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];

            //param[0] = new SqlParameter("@xmlString", objUserBL.Xml_D);
            param[0] = new SqlParameter("@ITEM_DESCRIPTION", objUserBL.ITEM_DESCRIPTION);
            param[1] = new SqlParameter("@flag", objUserBL.Ename);
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DESC_VALIDATION_EXCEL_UPLOAD", param);
            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_License_Details_ITEM_WISE()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[7] = new SqlParameter("@LICENSE_ITEM_NO", LICENSE_ITEM_NO);
            param[8] = new SqlParameter("@CIF_VALUE", CIF_VALUE);
            param[9] = new SqlParameter("@DUTY_VALUE", DUTY_VALUE);

            param[3] = new SqlParameter("@name", Ename);
            param[4] = new SqlParameter("@Working_Period", WORKING_PERIOD);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            string find = "";
            if (Ename == "ITEM_WISE_CALCULATION" || Ename == "ITEM_WISE_LICENSE_REMAINING_CIF_VALUE" || Ename == "Check_Higher_than_Value_Sum_CIF")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_CIF_DEBIT_CALCULATION", param);
                string err = param[6].Value.ToString();
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else if (Ename == "ITEM_WISE_LICENSE_UPDATE")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_CIF_DEBIT_CALCULATION", param);
                result = Convert.ToInt32(param[5].Value.ToString());
                find = "no";
            }
            if (find == "")
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt.Copy());
                }
                else
                    ds.Tables.Add(dt.Copy());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet FREIGHT_IMP_EXP_Job_Load()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
            param[2] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);
            param[3] = new SqlParameter("@IMPORTER_NAME", "");
            param[4] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@GROUP_ID", HttpContext.Current.Session["GroupID"].ToString());
            param[8] = new SqlParameter("@flag", @flag);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db_FRT"].ToString(), CommandType.StoredProcedure, "FromFreight_CHA_JobLoad", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Imp_Job_Logs_All_Details(string Jobno, string Invslno, string Item_slno, string Pagename, string Status, string Ename)
    {
        DataSet ds1 = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Invoice_slno", Invslno);
            param[2] = new SqlParameter("@Item_slno", Item_slno);
            param[3] = new SqlParameter("@PageName", Pagename);
            param[4] = new SqlParameter("@Status", Status);
            param[5] = new SqlParameter("@UserID", Connection.Current_User());
            param[6] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[7] = new SqlParameter("@Ename", Ename);

            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds1 = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_JOB_LOGS_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[9].Value.ToString());
            string err = param[10].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds1;
    }
    public DataSet Check_Container_Details_Avail()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Jobno", JOBNO);
            param[1] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[2] = new SqlParameter("@Ename", flag);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "CONTAINER_DETAILS_CHECK_AIR_MODE", param);
            result = Convert.ToInt32(param[3].Value.ToString());
            string err = param[4].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet SDF_Details_insertupdate(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[1] = new SqlParameter("@SDFID", objUserBL.A2);
            param[2] = new SqlParameter("@CASH_NO", objUserBL.A3);
            param[3] = new SqlParameter("@CASH_DATE", objUserBL.A4);
            param[4] = new SqlParameter("@CASH_AMT", objUserBL.A5);
            param[5] = new SqlParameter("@USERID", Connection.Current_User());
            param[6] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[7] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[8] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@Mflag", objUserBL.A14);
            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SDF_DETAILS_INSERT_UPDATE", param);
            string err = param[11].Value.ToString();
            result = Convert.ToInt32(param[10].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[12].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Wh_Job_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@WAREHOUSE_JOBNO", WAREHOUSE_JOBNO);
            param[2] = new SqlParameter("@JOBNO", JOBNO);
            param[3] = new SqlParameter("@name", Ename);
            param[4] = new SqlParameter("@DB_Name", DB_NAME);
            param[5] = new SqlParameter("@WORKING_PERIOD", Current_Working_Period);
            param[6] = new SqlParameter("@OLD_WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_WAREHOUSE_JOB_FEW_DETAILS_SELECT", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Import_Bulk_License_Select()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@name", Ename);
            // param[5] = new SqlParameter("@ITEM_ID", ITEM_ID);
            //param[6] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
            //param[7] = new SqlParameter("@SCHEME_NOTN", SCHEME_NOTN);
            //param[8] = new SqlParameter("@SCHEME_NOTN_SLNO", SCHEME_NOTN_SLNO);
            param[9] = new SqlParameter("@JOBNO", JOBNO);
            param[10] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[11] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[12] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            // param[13] = new SqlParameter("@ITEM_ID", ITEM_ID);
            param[14] = new SqlParameter("@xmlString", xmlString);

            if (Ename == "select_con" || Ename == "GET_IMPORT_LICENSE_ID_MAX" || Ename == "License_details_delete")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_BULK_LICENSE_SELECT", param);

                string err = param[3].Value.ToString();

            }
            if (Ename == "Update_item_details")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_BULK_LICENSE_SELECT", param);

                string err = param[3].Value.ToString();
            }

            if (Ename == "validate_invoice_item")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_BULK_LICENSE_SELECT", param);

                result = Convert.ToInt32(param[2].Value.ToString());
            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    // Ajith
    public DataSet RetrieveAll_IMPORT_BOND_AMOUNT_DETAILS_SummaryReport()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@BOND_NO", BOND_NO);
            param[1] = new SqlParameter("@BOND_TYPE", BOND_TYPE);
            param[2] = new SqlParameter("@BOND_LOCATION", BOND_LOCATION);
            param[3] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[4] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[9] = new SqlParameter("@JOB_NO", JOBNO);
            param[6] = new SqlParameter("@Ename", Ename);

            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            if (Ename == "Distinct_Bond_Details" || Ename == "SELECT_RITC_JOBNO_BOND" || Ename == "SELECT_PD_BOND_REPORT" || Ename == "SELECT_RE_BOND_REPORT"
                || Ename == "SELECT_DEEC_BOND_REPORT" || Ename == "SELECT_EPCG_BOND_REPORT" || Ename == "SELECT_WAREHOUSE_BOND_REPORT" || Ename == "SELECT_EI_IGCR_BOND_REPORT"
                || Ename == "SELECT_EU_END_USE_BOND_REPORT" || Ename == "BOND_DETAILS_GET")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_BOND_AMOUNT_SUMMARY_REPORT", param);
                result = Convert.ToInt32(param[7].Value.ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);
                }
                else
                    ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet BOND_AMOUNT_DETAIL_GET()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@BOND_NO", BOND_NO);
            param[2] = new SqlParameter("@BOND_TYPE", BOND_TYPE);
            param[3] = new SqlParameter("@BOND_LOCATION", BOND_LOCATION);
            param[4] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[5] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[6] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Ename", Ename);
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_BOND_AMT_BALANCE", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet BOND_IECGATE_AMT()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@BOND_NO", BOND_NO);
            param[2] = new SqlParameter("@JOBNO", JOBNO);
            param[3] = new SqlParameter("@ICEGATE_AMT", PDF_AMT);
            param[4] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[5] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[6] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "ICEGATE_DETAILS_SELECT", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

     // ajith

    public DataSet Retrieve_Api_key_GET_ICEGATE()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@Company_id", Connection.COMPANYID());
            param[2] = new SqlParameter("@icegateId", icegateId);
            param[3] = new SqlParameter("@name", Ename);
            param[5] = new SqlParameter("@WORKING_PERIOD", Current_Working_Period);
            param[7] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GET_ICEGATE_PASSWORD", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Get_ICEGATE_ASS_DUTYVAL()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[2] = new SqlParameter("@BE_NO", BE_NO);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GET_ICEGATE_OCR_VALUES", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet INSERT_ICEGATE_ASS_DUTY_BOND_VALUE()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[2] = new SqlParameter("@BE_NO", BE_NO);
            param[3] = new SqlParameter("@ASS_VALUE", ASSESSABLE_VALUE);
            param[4] = new SqlParameter("@DUTY_VALUE", DUTY_VALUE);
            param[5] = new SqlParameter("@BOND_NO", BOND_NO);
            param[6] = new SqlParameter("@BOND_AMT", BOND_AMT);
            param[7] = new SqlParameter("@FLAG", flag);
            param[8] = new SqlParameter("@Status", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INSERT_ICEGATE_OCR_VALUES", param);
            result = Convert.ToInt32(param[8].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt.Clone());
            }
            else
                ds.Tables.Add(dt.Clone());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}