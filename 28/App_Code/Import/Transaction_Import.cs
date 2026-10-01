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
using Microsoft.ApplicationBlocks.Data; 
/// <summary>
/// Summary description for Transaction
/// </summary>
public class Transaction_Import : ErrorLogs
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result, IGMSLNO;
    public string err ,INV_SLNO;
    public double  ALL_INVOICE_VALUE, ALL_FREIGHT_TOTAL, ALL_INSURANCE_TOTAL;

    # region Common_Private_Attributes
    private string _flag;

    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _JOBNO;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    #endregion
    #region Private
    #region IGM Details_Private_Attributes


    private string _IGM_ID;
    private string _IGM_SLNO_UPDATE;
    private string _IGM_JOBNO;
    private string _IGM_JOBDATE;
    private string _IGM_AIRLINECODE;
    private string _IGM_AIRLINENAME;
    private string _IGM_FLIGHTNO_VESSELNO;
    private string _IGM_FLIGHT_VESSELDATE;
    private string _IGM_NO;
    private string _IGM_DATE;
    private string _IGM_MAWB_MBL;
    private string _IGM_MAWB_MBLDATE;
    private string _IGM_HAWB_HBLNO;
    private string _IGM_HAWB_HBLDATE;
    private string _IGM_NOOFPACKAGE;
    private string _IGM_PACKAGETYPE;
    private string _IGM_GROSSWEIGHT;
    private string _IGM_TYPEOFWEIGHT;
    private string _IGM_NETWEIGHT;
    private string _IGM_NETWEIGHTTYPE;
    private string _IGM_MARKSNOS;
    private string _IGM_TRANSPORTMODE;
    private string _IGM_GATEWAY_IGM_NO;
    private string _IGM_GATEWAY_IGM_DATE;
    private string _IGM_GATEWAY_PORT_CODE;
   

    #endregion
    #region GeneralDetails_Private_Attributes
    private string _JOBID;
    private string _Ename;
    
    private string _JOBDATE;
    private string _TRANSPORT_MODE;
    private string _BE_TYPE;
    private string _CUSTOMS_HOUSE;
    private string _IMPORTER_NAME;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;
    private string _IEC_NO;
    private string _BRANCH_NO;
    private string _COUNTRY_ORIGIN;
    private string _PORT_ORIGIN;

    private string _PORT_SHIPMENT;
    private string _COUNTRY_SHIPMENT;
    private string _FILING_STATUS;
    private string _SECTION46;
    private string _SECTION46_DESC;
    private string _FIRSTCHECK;
    private string _FIRSTCHECK_DESC;
    private string _GREEN_CHANNEL;
    private string _GREEN_CHANNEL_DESC;
    private string _KACHHA_BE;
    private string _KACHHA_BE_DESC;
    private string _SECTION48;
    private string _SECTION48_DESC;
    private string _HIGH_SEA_SALE;
    private string _HIGH_SEA_SALE_NAME;
    private string _HIGH_SEA_IEC;
    private string _HIGH_SEA_BRANCH_SL_NO;
    private string _HSS_ADD1;
    private string _HSS_ADD2;
    private string _HSS_ADD3;
    private string _HSS_ADD4;
    private string _HSS_ADD5;
    private string _WAREHOUSE_NAME;
    private string _WAREHOUSE_CODE;
    private string _REMARKS;
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
    private string _BOND_TYPE;
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
          private string _SVB_CUSTOM_HOUSE;
          private string _SVB_LOADING_ON;
          private string _SVB_ASSESABLE_RATE;
          private string _SVB_DUTY_RATE;
          private string _SVB_ASSESABLE_STATUS;
          private string _SVB_DUTY_STATUS;
    #endregion

          #region INVOICE_MAIN_Details_Private_Attributes
          private string _INVOICE_ID;
          
          private string _INVOICE_NO;
          private string _INVOICE_DATE;
          private string _TERMS;
          private string _INVOICE_CURRENCY;
          private string _INVOICE_VALUE;
          
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
          #endregion

          #region Re_import_Details_Private_Attributes
          private string _RE_IMPORT_ID;
          private string _RE_IMPORT_SLNO;
          private string _ITEM_SLNO;
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
          #endregion

          #region License_Details_Private_Attributes
    
          private string _LICENSE_ID;
          private string _LICENSE_SLNO;
          private string _REGISTRATION_NO;
          private string _REGISTRATION_DATE;
          private string _EXCEMPTION;
          private string _DEBIT_AMT;
          private string _DEBIT_QTY;
          private string _UNIT_QTY;
          private string _LICENSE_ITEM_NO;
          private string _PORT_OF_LICENSE;
         
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
          #endregion
          #region Item_General_Details_Private_Attributes
          private string _GENERAL_ID;
          
          private string _SCHEME_CODE;
          private string _SCHEME_NOTN;
          private string _SCHEME_NOTN_SLNO;
          private string _CTH_QTY1;
          private string _CTH_QTY2;
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
          #endregion


    #endregion


          #region Public

          #region IGM Details_Public_Attributes
          public string flag { get { return _flag; } set { _flag = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }


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

    #endregion

    #region GeneralDetails_Public_Attributes
    public string JOBID { get { return _JOBID; } set { _JOBID = value; } }
   
    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
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
    public string Ename { get { return _Ename; } set { _Ename = value; } }
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
    public string SVB_CUSTOM_HOUSE { get { return _SVB_CUSTOM_HOUSE; } set { _SVB_CUSTOM_HOUSE = value; } }
    public string SVB_LOADING_ON { get { return _SVB_LOADING_ON; } set { _SVB_LOADING_ON = value; } }
    public string SVB_ASSESABLE_RATE { get { return _SVB_ASSESABLE_RATE; } set { _SVB_ASSESABLE_RATE = value; } }
    public string SVB_DUTY_RATE { get { return _SVB_DUTY_RATE; } set { _SVB_DUTY_RATE = value; } }
    public string SVB_ASSESABLE_STATUS { get { return _SVB_ASSESABLE_STATUS; } set { _SVB_ASSESABLE_STATUS = value; } }
    public string SVB_DUTY_STATUS { get { return _SVB_DUTY_STATUS; } set { _SVB_DUTY_STATUS = value; } }

#endregion
    #region INVOICE_MAIN_Details_Public_Attributes
           public string INVOICE_ID{ get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }
           
           public string INVOICE_NO{ get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
           public string INVOICE_DATE{ get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
           public string TERMS{ get { return _TERMS; } set { _TERMS = value; } }
           public string INVOICE_CURRENCY{ get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }
           public string INVOICE_VALUE{ get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
           
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
           public string MIS_HIGHSEASALE_CHARGES { get { return _MIS_HIGHSEASALE_CHARGES; } set {_MIS_HIGHSEASALE_CHARGES = value; } }
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
           #endregion
           #region Re_import_Details_Public_Attributes
           public string RE_IMPORT_ID { get { return _RE_IMPORT_ID; } set { _RE_IMPORT_ID = value; } }
           public string RE_IMPORT_SLNO { get { return _RE_IMPORT_SLNO; } set { _RE_IMPORT_SLNO = value; } }
           public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
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
           #endregion

           #region License_Details_Public_Attributes
           public string LICENSE_ID { get { return _LICENSE_ID; } set { _LICENSE_ID = value; } }
           public string LICENSE_SLNO { get { return _LICENSE_SLNO; } set { _LICENSE_SLNO = value; } }
           public string REGISTRATION_NO { get { return _REGISTRATION_NO; } set { _REGISTRATION_NO = value; } }
           public string REGISTRATION_DATE { get { return _REGISTRATION_DATE; } set { _REGISTRATION_DATE = value; } }
           public string EXCEMPTION { get { return _EXCEMPTION; } set { _EXCEMPTION = value; } }
           public string DEBIT_AMT { get { return _DEBIT_AMT; } set { _DEBIT_AMT = value; } }
           public string DEBIT_QTY { get { return _DEBIT_QTY; } set { _DEBIT_QTY = value; } }
           public string UNIT_QTY { get { return _UNIT_QTY; } set { _UNIT_QTY = value; } }
           public string LICENSE_ITEM_NO { get { return _LICENSE_ITEM_NO; } set { _LICENSE_ITEM_NO = value; } }
           public string PORT_OF_LICENSE { get { return _PORT_OF_LICENSE; } set { _PORT_OF_LICENSE = value; } }
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
           #endregion
           #region Item_General_Details_Public_Attributes
           public string GENERAL_ID { get { return _GENERAL_ID; } set { _GENERAL_ID = value; } }

           public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
           public string SCHEME_NOTN { get { return _SCHEME_NOTN; } set { _SCHEME_NOTN = value; } }
           public string SCHEME_NOTN_SLNO { get { return _SCHEME_NOTN_SLNO; } set { _SCHEME_NOTN_SLNO = value; } }
           public string CTH_QTY1 { get { return _CTH_QTY1; } set { _CTH_QTY1 = value; } }
           public string CTH_QTY2 { get { return _CTH_QTY2; } set { _CTH_QTY2 = value; } }
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

           public string CTH_NO { get { return _CTH_NO; } set { _CTH_NO = value; } }
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

    public int General_details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[50];

           // param[0] = new SqlParameter("@JOBID", JOBID);

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

            param[44] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[44].Direction = ParameterDirection.Output;

            param[45] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[45].Direction = ParameterDirection.Output;
            param[46] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);



            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[44].Value.ToString());



        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return result;
    }

    public DataSet IGM_Details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[35];
            param[0] = new SqlParameter("@JOBNO", IGM_JOBNO);
            param[31] = new SqlParameter("@IGM_SLNO_Update", IGM_SLNO_UPDATE);
            param[1] = new SqlParameter("@IGM_JOBDATE", DateTime.Parse(IGM_JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[2] = new SqlParameter("@IGM_AIRLINECODE", IGM_AIRLINECODE);
            param[3] = new SqlParameter("@IGM_AIRLINENAME", IGM_AIRLINENAME);
            param[4] = new SqlParameter("@IGM_FLIGHTNO_VESSELNO", IGM_FLIGHTNO_VESSELNO);
            param[5] = new SqlParameter("@IGM_FLIGHT_VESSELDATE", DateTime.Parse(IGM_FLIGHT_VESSELDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[6] = new SqlParameter("@IGM_NO", IGM_NO);
            param[7] = new SqlParameter("@IGM_DATE", DateTime.Parse(IGM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[8] = new SqlParameter("@IGM_MAWB_MBL", IGM_MAWB_MBL);
            param[9] = new SqlParameter("@IGM_MAWB_MBLDATE", DateTime.Parse(IGM_MAWB_MBLDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[10] = new SqlParameter("@IGM_HAWB_HBLNO", IGM_HAWB_HBLNO);
            param[11] = new SqlParameter("@IGM_HAWB_HBLDATE", DateTime.Parse(IGM_HAWB_HBLDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[12] = new SqlParameter("@IGM_NOOFPACKAGE", IGM_NOOFPACKAGE);
            param[13] = new SqlParameter("@IGM_PACKAGETYPE", IGM_PACKAGETYPE);
            param[14] = new SqlParameter("@IGM_GROSSWEIGHT", IGM_GROSSWEIGHT);
            param[15] = new SqlParameter("@IGM_TYPEOFWEIGHT", IGM_TYPEOFWEIGHT);
            param[16] = new SqlParameter("@IGM_NETWEIGHT", IGM_NETWEIGHT);
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


            ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_INSERT_UPDATE", param);

            
            //IGMSLNO = Convert.ToInt32(param[27].Value.ToString());
            result = Convert.ToInt32(param[25].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public DataSet CONTAINER_Details_insertupdate()
    {
        SqlParameter[] param = new SqlParameter[15];
        try
        {


            

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@CONTAINERID", CONTAINERID);

            param[2] = new SqlParameter("@CONTAINER_NO", CONTAINER_NO);
            param[3] = new SqlParameter("@CONTAINER_IGM_SLNO", CONTAINER_IGM_SLNO);
            param[4] = new SqlParameter("@CONTAINER_IGM_NO", CONTAINER_IGM_NO);
            param[5] = new SqlParameter("@CONTAINER_IGM_DATE",DateTime.Parse(CONTAINER_IGM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[6] = new SqlParameter("@SEAL_NO", SEAL_NO);
            param[7] = new SqlParameter("@FCL_OR_LCL", FCL_OR_LCL);

            param[8] = new SqlParameter("@USER_ID", USER_ID);
            param[9] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[10] = new SqlParameter("@YEAR", YEAR);
            param[11] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[12] = new SqlParameter("@Mflag", flag);
            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
           
            ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONTAINER_DETAILS_INSERT_UPDATE", param);
           
            result = Convert.ToInt32(param[13].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
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
            //throw new ArgumentException(ex.Message);
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

            param[3] = new SqlParameter("@USER_ID", USER_ID);
            param[4] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[5] = new SqlParameter("@YEAR", YEAR);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@Mflag", flag);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_BOND_DETAILS_INSERT_UPDATE", param);
            string err = param[9].Value.ToString();
            result = Convert.ToInt32(param[8].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
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
            param[7] = new SqlParameter("@Mflag", flag);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CERTIFICATE_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[8].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
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

            param[17] = new SqlParameter("@Mflag", flag);
            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_RE_IMPORT_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[18].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet License_Details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@LICENSE_ID", LICENSE_ID);
            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);

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

            param[16] = new SqlParameter("@Mflag", flag);
            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;

           ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[17].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    
    public DataSet Invoice_Details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[100];

            param[0] = new SqlParameter("@INVOICE_ID", INVOICE_ID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[89] = new SqlParameter("@INVOICE_SLNO", INV_SLNO);
            param[2] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[3] = new SqlParameter("@INVOICE_DATE",DateTime.Parse(INVOICE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[4] = new SqlParameter("@TERMS", TERMS);
            param[5] = new SqlParameter("@INVOICE_CURRENCY", INVOICE_CURRENCY);
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

            param[48] = new SqlParameter("@MIS_FREIGHT_CHARGES", MIS_FREIGHT_CHARGES);
            param[49] = new SqlParameter("@MIS_FREIGHT_RATE", MIS_FREIGHT_RATE);
            param[50] = new SqlParameter("@MIS_FREIGHT_CURRENCY", MIS_FREIGHT_CURRENCY);
            param[51] = new SqlParameter("@MIS_FREIGHT_EXRATE", MIS_FREIGHT_EXRATE);

            param[52] = new SqlParameter("@MIS_INSURANCE_CHARGES", MIS_INSURANCE_CHARGES);
            param[53] = new SqlParameter("@MIS_INSURANCE_RATE", MIS_INSURANCE_RATE);
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

            if (MIS_SINGLE_OR_MULITIPLE == "M")
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_INSERT_UPDATE", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_INSERT_UPDATE_new", param);

                //ds.t
                result = Convert.ToInt32(param[84].Value.ToString());
                if (result == 1)
                {
                    //ALL_INVOICE_VALUE = Convert.ToDouble(param[86].Value.ToString());
                    ALL_FREIGHT_TOTAL = Convert.ToDouble(param[87].Value.ToString());
                    ALL_INSURANCE_TOTAL = Convert.ToDouble(param[88].Value.ToString());

                    
                }
                string err = param[85].Value.ToString();
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_INSERT_UPDATE_new", param);

                result = Convert.ToInt32(param[84].Value.ToString());

            }
            //err = param[85].Value.ToString();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }
    public DataSet Item_Details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[140];

         
            param[0] = new SqlParameter("@JOBNO", JOBNO);

            //param[0] = new SqlParameter("@JOBNO", JOBNO);
            //param[0] = new SqlParameter("@JOBNO", JOBNO);


            param[1] = new SqlParameter("@INVOICE_SLNO", INV_SLNO);
            param[2] = new SqlParameter("@ITEM_DESCRIPTION", ITEM_DESCRIPTION);
            param[3] = new SqlParameter("@ITEM_QTY", ITEM_QTY);
            param[4] = new SqlParameter("@ITEM_QTY_CODE", ITEM_QTY_CODE);

            param[5] = new SqlParameter("@ITEM_UNIT_PRICE", ITEM_UNIT_PRICE);
            param[6] = new SqlParameter("@ITEM_UNIT_CODE", ITEM_UNIT_CODE);
            param[7] = new SqlParameter("@ITEM_TOTAL_AMOUNT", ITEM_TOTAL_AMOUNT);
            param[8] = new SqlParameter("@ITEM_AMOUNT_CODE", ITEM_AMOUNT_CODE);
            param[9] = new SqlParameter("@CTH_NO", CTH_NO);

            //ITEM_GENERAL

            param[10] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
            param[11] = new SqlParameter("@SCHEME_NOTN", SCHEME_NOTN);
            param[12] = new SqlParameter("@SCHEME_NOTN_SLNO", SCHEME_NOTN_SLNO);
            param[13] = new SqlParameter("@CTH_QTY1", CTH_QTY1);
            param[14] = new SqlParameter("@CTH_QTY2", CTH_QTY2);
            param[15] = new SqlParameter("@GENEARL_DESCRIPTION", GENEARL_DESCRIPTION);
            param[16] = new SqlParameter("@MANUFACTURER", MANUFACTURER);
            param[17] = new SqlParameter("@BRAND", BRAND);
            param[18] = new SqlParameter("@MODEL", MODEL);
            param[19] = new SqlParameter("@END_USE_OF_ITEM", END_USE_OF_ITEM);
            param[20] = new SqlParameter("@COUNTRY_OF_ORIGIN", COUNTRY_OF_ORIGIN);
            param[21] = new SqlParameter("@ACCESSORIES", ACCESSORIES);
            param[22] = new SqlParameter("@PREVIOUS_BE_NO", PREVIOUS_BE_NO);
            param[23] = new SqlParameter("@PREVIOUS_BE_DATE", DateTime.Parse(PREVIOUS_BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[24] = new SqlParameter("@UNIT_PRICE", UNIT_PRICE);
            param[136] = new SqlParameter("@UNIT_CODE", UNIT_CODE);
            param[25] = new SqlParameter("@CUSTOMS_HOUSE", ITEM_CUSTOMS_HOUSE);

            //ITEM_CTH

            param[26] = new SqlParameter("@PRODUCT_RITC", PRODUCT_RITC);
            param[27] = new SqlParameter("@PRODUCT_CTH", PRODUCT_CTH);
            param[28] = new SqlParameter("@PRODUCT_BCD_NOTN", PRODUCT_BCD_NOTN);
            param[29] = new SqlParameter("@PRODUCT_BCD_SLNO", PRODUCT_BCD_SLNO);
            param[30] = new SqlParameter("@PRODUCT_BCD_RATE", PRODUCT_BCD_RATE);
            param[31] = new SqlParameter("@PRODUCT_BCD_SPL", PRODUCT_BCD_SPL);
            param[32] = new SqlParameter("@PRODUCT_BCD_UNIT", PRODUCT_BCD_UNIT);
            param[33] = new SqlParameter("@PRODUCT_BCD_SPL_TYPE", PRODUCT_BCD_SPL_TYPE);
            param[34] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN", PRODUCT_ADDL_DUTY_NOTN);
            param[35] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN_SL", PRODUCT_ADDL_DUTY_NOTN_SL);
            param[36] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN", PRODUCT_EDU_CESS_NOTN);
            param[37] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN_SL", PRODUCT_EDU_CESS_NOTN_SL);
            param[38] = new SqlParameter("@PRODUCT_EDU_CESS_RATE", PRODUCT_EDU_CESS_RATE);
            param[39] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN", PRODUCT_SEC_EDU_CESS_NOTN);
            param[40] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN_SL", PRODUCT_SEC_EDU_CESS_NOTN_SL);
            param[41] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_RATE", PRODUCT_SEC_EDU_CESS_RATE);
            param[42] = new SqlParameter("@PRODUCT_NCD_NOTN", PRODUCT_NCD_NOTN);
            param[43] = new SqlParameter("@PRODUCT_NCD_SLNO", PRODUCT_NCD_SLNO);
            param[44] = new SqlParameter("@PRODUCT_NCD_RATE", PRODUCT_NCD_RATE);
            param[45] = new SqlParameter("@PRODUCT_NCD_SPL", PRODUCT_NCD_SPL);
            param[46] = new SqlParameter("@PRODUCT_NCD_UNIT", PRODUCT_NCD_UNIT);
            param[47] = new SqlParameter("@PRODUCT_NCD_SPL_TYPE", PRODUCT_NCD_SPL_TYPE);
            param[48] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN", PRODUCT_AGGREGATE_DUTY_NOTN);
            param[49] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_SL", PRODUCT_AGGREGATE_DUTY_NOTN_SL);
            param[50] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_RATE", PRODUCT_AGGREGATE_DUTY_NOTN_RATE);
            param[51] = new SqlParameter("@PRODUCT_SAFEGUARD_NOTN", PRODUCT_SAFEGUARD_NOTN);
            param[52] = new SqlParameter("@PRODUCT_SAFEGUARD_SLNO", PRODUCT_SAFEGUARD_SLNO);
            param[53] = new SqlParameter("@PRODUCT_SAFEGUARD_RATE", PRODUCT_SAFEGUARD_RATE);
            param[54] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL", PRODUCT_SAFEGUARD_SPL);
            param[55] = new SqlParameter("@PRODUCT_SAFEGUARD_UNIT", PRODUCT_SAFEGUARD_UNIT);
            param[56] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL_TYPE", PRODUCT_SAFEGUARD_SPL_TYPE);
            //ITEM_CETH

            param[57] = new SqlParameter("@PRODUCT_CETH", PRODUCT_CETH);
            param[58] = new SqlParameter("@PRODUCT_MRP_YN", PRODUCT_MRP_YN);
            param[59] = new SqlParameter("@PRODUCT_MRP_SL_NO", PRODUCT_MRP_SL_NO);
            param[60] = new SqlParameter("@PRODUCT_MRP_AMOUNT", PRODUCT_MRP_AMOUNT);
            param[61] = new SqlParameter("@PRODUCT_MRP_ABT_RATE", PRODUCT_MRP_ABT_RATE);
            param[62] = new SqlParameter("@PRODUCT_CVD_NOTN", PRODUCT_CVD_NOTN);
            param[63] = new SqlParameter("@PRODUCT_CVD_SLNO", PRODUCT_CVD_SLNO);
            param[64] = new SqlParameter("@PRODUCT_CVD_RATE", PRODUCT_CVD_RATE);
            param[65] = new SqlParameter("@PRODUCT_CVD_SPL", PRODUCT_CVD_SPL);
            param[66] = new SqlParameter("@PRODUCT_CVD_UNIT", PRODUCT_CVD_UNIT);
            param[67] = new SqlParameter("@PRODUCT_CVD_SPL_TYPE", PRODUCT_CVD_SPL_TYPE);
            param[68] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_RATE", PRODUCT_CVD_EDU_CESS_RATE);
            param[69] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_RATE", PRODUCT_CVD_SEC_EDU_CESS_RATE);
            param[70] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN", PRODUCT_ADDL5_SIA_NOTN);
            param[71] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN_SL", PRODUCT_ADDL5_SIA_NOTN_SL);
            param[72] = new SqlParameter("@PRODUCT_ADDL5_SIA_RATE", PRODUCT_ADDL5_SIA_RATE);
            param[73] = new SqlParameter("@PRODUCT_ADDL_GSI_NOTN", PRODUCT_ADDL_GSI_NOTN);
            param[74] = new SqlParameter("@PRODUCT_ADDL_GSI_SLNO", PRODUCT_ADDL_GSI_SLNO);
            param[75] = new SqlParameter("@PRODUCT_ADDL_GSI_RATE", PRODUCT_ADDL_GSI_RATE);
            param[76] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL", PRODUCT_ADDL_GSI_SPL);
            param[77] = new SqlParameter("@PRODUCT_ADDL_GSI_UNIT", PRODUCT_ADDL_GSI_UNIT);
            param[78] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL_TYPE", PRODUCT_ADDL_GSI_SPL_TYPE);
            param[79] = new SqlParameter("@PRODUCT_ADDL_SHEII_NOTN", PRODUCT_ADDL_SHEII_NOTN);
            param[80] = new SqlParameter("@PRODUCT_ADDL_SHEII_SLNO", PRODUCT_ADDL_SHEII_SLNO);
            param[81] = new SqlParameter("@PRODUCT_ADDL_SHEII_RATE", PRODUCT_ADDL_SHEII_RATE);
            param[82] = new SqlParameter("@PRODUCT_ADDL_SHEII_SPL", PRODUCT_ADDL_SHEII_SPL);
            param[83] = new SqlParameter("@PRODUCT_ADDL_SHEII_UNIT", PRODUCT_ADDL_SHEII_UNIT);
            param[84] = new SqlParameter("@PRODUCT_ADDL_SHEII_TYPE", PRODUCT_ADDL_SHEII_TYPE);
            param[85] = new SqlParameter("@PRODUCT_ADDL_TTA_NOTN", PRODUCT_ADDL_TTA_NOTN);
            param[86] = new SqlParameter("@PRODUCT_ADDL_TTA_SLNO", PRODUCT_ADDL_TTA_SLNO);
            param[87] = new SqlParameter("@PRODUCT_ADDL_TTA_RATE", PRODUCT_ADDL_TTA_RATE);
            param[88] = new SqlParameter("@PRODUCT_ADDL_TTA_SPL", PRODUCT_ADDL_TTA_SPL);
            param[89] = new SqlParameter("@PRODUCT_ADDL_TTA_UNIT", PRODUCT_ADDL_TTA_UNIT);
            param[90] = new SqlParameter("@PRODUCT_ADDL_TTA_TYPE", PRODUCT_ADDL_TTA_TYPE);
            param[91] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_NOTN", PRODUCT_ADDL_HEALTH_CESS_NOTN);
            param[92] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SLNO", PRODUCT_ADDL_HEALTH_CESS_SLNO);
            param[93] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_RATE", PRODUCT_ADDL_HEALTH_CESS_RATE);
            param[94] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SPL", PRODUCT_ADDL_HEALTH_CESS_SPL);
            param[95] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_UNIT", PRODUCT_ADDL_HEALTH_CESS_UNIT);
            param[96] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_TYPE", PRODUCT_ADDL_HEALTH_CESS_TYPE);
            param[97] = new SqlParameter("@PRODUCT_CESS_NOTN", PRODUCT_CESS_NOTN);
            param[98] = new SqlParameter("@PRODUCT_CESS_SLNO", PRODUCT_CESS_SLNO);
            param[100] = new SqlParameter("@PRODUCT_CESS_RATE", PRODUCT_CESS_RATE);
            param[101] = new SqlParameter("@PRODUCT_CESS_SPL", PRODUCT_CESS_SPL);
            param[102] = new SqlParameter("@PRODUCT_CESS_UNIT", PRODUCT_CESS_UNIT);
            param[103] = new SqlParameter("@PRODUCT_CESS_TYPE", PRODUCT_CESS_TYPE);

            //OTHERDUTY_DETAILS

            param[104] = new SqlParameter("@ANTI_DUMPING_NOTN", ANTI_DUMPING_NOTN);
            param[105] = new SqlParameter("@ANTI_DUMPING_NOTN_SLNO", ANTI_DUMPING_NOTN_SLNO);
            param[106] = new SqlParameter("@CTH_SLNO", CTH_SLNO);
            param[107] = new SqlParameter("@CTH_SUPPLIER_SLNO", CTH_SUPPLIER_SLNO);
            param[108] = new SqlParameter("@CTH_QTY", CTH_QTY);


            //RE_IMPORT_DETAILS


            //param[109] = new SqlParameter("@SB_NO", SB_NO);
            //param[110] = new SqlParameter("@SB_DATE", SB_DATE);
            //param[111] = new SqlParameter("@PORT_EXPORT", PORT_EXPORT);
            //param[112] = new SqlParameter("@SB_INVOICE_NO", SB_INVOICE_NO);
            //param[113] = new SqlParameter("@SB_INVOICE__ITEM_NO", SB_INVOICE__ITEM_NO);
            //param[114] = new SqlParameter("@NOTN_NO", NOTN_NO);
            //param[115] = new SqlParameter("@NOTN_SLNO", NOTN_SLNO);
            //param[116] = new SqlParameter("@EXPORT_FREIGHT", EXPORT_FREIGHT);
            //param[117] = new SqlParameter("@EXPORT_INSURANCE", EXPORT_INSURANCE);
            //param[118] = new SqlParameter("@CUSTOMS_DUTY", CUSTOMS_DUTY);
            //param[119] = new SqlParameter("@EXCISE_DUTY", EXCISE_DUTY);

            ////LICENSE_DETAILS

            //param[120] = new SqlParameter("@REGISTRATION_NO", REGISTRATION_NO);
            //param[121] = new SqlParameter("@REGISTRATION_DATE", REGISTRATION_DATE);
            //param[122] = new SqlParameter("@EXCEMPTION", EXCEMPTION);
            //param[123] = new SqlParameter("@DEBIT_AMT", DEBIT_AMT);
            //param[124] = new SqlParameter("@DEBIT_QTY", DEBIT_QTY);
            //param[125] = new SqlParameter("@UNIT_QTY", UNIT_QTY);
            //param[126] = new SqlParameter("@LICENSE_ITEM_NO", LICENSE_ITEM_NO);
            //param[127] = new SqlParameter("@PORT_OF_LICENSE", PORT_OF_LICENSE);



            param[128] = new SqlParameter("@USER_ID", USER_ID);
            param[129] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[130] = new SqlParameter("@YEAR", YEAR);
            param[131] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);



            param[132] = new SqlParameter("@Mflag", flag);
            param[133] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[133].Direction = ParameterDirection.Output;
            param[134] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[134].Direction = ParameterDirection.Output;
            param[135] = new SqlParameter("@ITEM_ID", ITEM_ID);

            ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_INSERT_UPDATE", param);
            string err=param[134].Value.ToString();
            result = Convert.ToInt32(param[133].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Invoice_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];


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
            param[6] = new SqlParameter("@Mflag", flag);

            if (flag == "INVOICE_NO")
            {
                return SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_SELECT", param);
                
            }
            else if (flag == "INVOICE_VALUE")
            {
                return SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_SELECT", param);

            }
            else if (flag == "Delete")
            {
                return SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_SELECT", param);

            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_INVOICE_DETAILS_SELECT", param);

                string Freight = param[4].Value.ToString();
                string Insurance = param[5].Value.ToString();

                if (Freight!= "")
                {
                    //ALL_FREIGHT_TOTAL = Convert.ToDouble(param[4].Value.ToString());
                    //ALL_INSURANCE_TOTAL = Convert.ToDouble(param[5].Value.ToString());

                    ALL_FREIGHT_TOTAL = Convert.ToDouble(Freight);

                }
                if (Insurance != "")
                {
                    //ALL_FREIGHT_TOTAL = Convert.ToDouble(param[4].Value.ToString());
                    //ALL_INSURANCE_TOTAL = Convert.ToDouble(param[5].Value.ToString());

                    ALL_INSURANCE_TOTAL = Convert.ToDouble(Insurance);

                }
            }
           
            

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_IGM_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];


            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[6] = new SqlParameter("@IGM_SLNO", IGM_SLNO_UPDATE);

            param[1] = new SqlParameter("@name", Ename);

            param[2] = new SqlParameter("@IGM_TRANSPORTMODE", TRANSPORT_MODE);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

          
            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con")
            {
                ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_SELECT", param);
                string err = param[5].Value.ToString();
              
            }
            else if (Ename == "delete")
            {
               ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_SELECT", param);
                //string err = param[5].Value.ToString();
                //string status = param[4].Value.ToString();
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
            }

            if (ds.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
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
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Container_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];


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


            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONTAINER_DETAILS_SELECT", param);
                string err = param[7].Value.ToString();
                

            }
            else if (Ename == "delete")
            {
                ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONTAINER_DETAILS_SELECT", param);
                //string err = param[5].Value.ToString();
                //string status = param[4].Value.ToString();
                result = Convert.ToInt32(param[6].Value.ToString());
               
            }
            else
            {
            }

            if (ds.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
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
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_BOND_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[1] = new SqlParameter("@BOND_NO", BOND_NO);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_BOND_DETAILS_SELECT", param);
                string err = param[5].Value.ToString();

            }
            else if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_BOND_DETAILS_SELECT", param);
                //string err = param[5].Value.ToString();
                //string status = param[4].Value.ToString();
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
            }



        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_Certificate_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[1] = new SqlParameter("@CERTIFICATE_NO", CERTIFICATE_NO);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CERTIFICATE_DETAILS_SELECT", param);
                string err = param[5].Value.ToString();

            }
            else if (Ename == "delete")
            {
                ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CERTIFICATE_DETAILS_SELECT", param);
                //string err = param[5].Value.ToString();
                //string status = param[4].Value.ToString();
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
            }



        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Item_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

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


            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_SELECT", param);
                string err = param[6].Value.ToString();

            }
            else if (Ename == "product_value")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_SELECT", param);
                string err = param[6].Value.ToString();

            }
            else if (Ename == "select_Invoice_No")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_SELECT", param);
                string err = param[6].Value.ToString();

            }
            else if (Ename == "delete")
            {
               ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ITEM_DETAILS_SELECT", param);
                //string err = param[5].Value.ToString();
                //string status = param[4].Value.ToString();
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else
            {
            }



        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_ReImport_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

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


            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_RE_IMPORT_DETAILS_SELECT", param);
                string err = param[8].Value.ToString();

            }
            else if (Ename == "delete")
            {
                ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_RE_IMPORT_DETAILS_SELECT", param);
                //string err = param[5].Value.ToString();
                //string status = param[4].Value.ToString();
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
            }



        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_License_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);

          

            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);

            param[3] = new SqlParameter("@LICENSE_ID", LICENSE_ID);

            param[4] = new SqlParameter("@name", Ename);

            param[5] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;


            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_DETAILS_SELECT", param);
                string err = param[7].Value.ToString();

            }
            else if (Ename == "delete")
            {
                ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_LICENSE_DETAILS_SELECT", param);
                //string err = param[5].Value.ToString();
                //string status = param[4].Value.ToString();
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
            }



        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_General_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

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
            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());


            }
            else
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                //string err = param[8].Value.ToString();
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

   
}