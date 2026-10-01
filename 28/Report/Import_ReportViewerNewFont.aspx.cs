using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using BussinessObject;
using System.Linq;

 
//using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net;

 

public partial class Transaction_Default2 : System.Web.UI.Page
{
    #region

    private string _BE_NO, _BE_NO_DATE, _FIRSTCHECK, _GREEN_CHANNEL, _KACHHA_BE, _SECTION48, _BE_TYPE, _EXBOND_ADDL_LOAD_HSS, _EXBOND_MISC_LOAD_RATE, _HIGH_SEA_SALE_NAME, _HIGH_SEA_IEC
        , _HIGH_SEA_BRANCH_SL_NO, _HSS_ADD1, _HSS_ADD2, _HSS_ADD3, _HSS_ADD4, _HSS_ADD5, _SUPPLIER_COUNTRY_NAME, _SUPPLIER_COUNTRY_PINCODE, _SVB_ASSESABLE_STATUS, _SVB_DUTY_STATUS, _INVOICE_NO
        , _BETYPE , _endusedescnew;
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //General Details
    public string Endusedescnew { get { return _endusedescnew; } set { _endusedescnew = value; } }

     public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
     public string BE_NO_DATE { get { return _BE_NO_DATE; } set { _BE_NO_DATE = value; } }
     public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }
     public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
     public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
     public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }
     public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
     public string EXBOND_ADDL_LOAD_HSS { get { return _EXBOND_ADDL_LOAD_HSS; } set { _EXBOND_ADDL_LOAD_HSS = value; } }
     public string EXBOND_MISC_LOAD_RATE { get { return _EXBOND_MISC_LOAD_RATE; } set { _EXBOND_MISC_LOAD_RATE = value; } }
     public string BETYPE { get { return _BETYPE; } set { _BETYPE = value; } }
         
    //---------------------ITEM ATTRIBUTES-----------------//
    private int _INVOICE_SLNO;
    public int INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }

    private double _ASSESABLE_VALUE, _ASSESSABLE_TOTAL, _ITEM_TOTAL;

    public double ASSESSABLE_TOTAL { get { return _ASSESSABLE_TOTAL; } set { _ASSESSABLE_TOTAL = value; } }
    public double ITEM_TOTAL { get { return _ITEM_TOTAL; } set { _ITEM_TOTAL = value; } }
    public double ASSESABLE_VALUE { get { return _ASSESABLE_VALUE; } set { _ASSESABLE_VALUE = value; } }
    //------------------------------------------------------------------------------

    private string _INVOICE_DATE, _SUPPLIER_NAME, _SUPPLIER_ADDRESS, _SUPPLIER_ADDRESS1, _SUPPLIER_ADDRESS2, _SVB_RELATION, _SVB_REF_NO, _TERMS, _SVB_LOADING_ON, _SVB_REF_DATE
    , _SVB_STATUS, _EOU_MERIT_BASIC_DUTY, _EOU_MERIT_CVD, _INVOICE_NO_ITEM, _Invoice_No, _Invoice_Details, _INVOICE_VALUE, _Invoice_value, _INVOICE_EXRATE, _MIS_FREIGHT_RATE
    , _MIS_INSURANCE_RATE, _REVENUEDEPOSIT_RATE, _REVENUEDEPOSIT_ON, _IGM_TRANSPORTMODE, _PORT_ORIGIN,_PORT_SHIPMENT, _COUNTRY_OF_ORIGIN, _Country_Shipment,_FILING_STATUS, _SVB_CUSTOM_HOUSE, _ITEM_SLNO
    , _ITEM_DESCRIPTION, _ITEM_QTY, _ITEM_QTY_CODE, _ITEM_UNIT_PRICE, _Total_Invoice, _SupplierCountry_Name_Pincode, _SCHEME_CODE, _SCHEME, _SCHEME_NOTN, _SCHEME_NOTN_SLNO, _ANTI_DUMPING_NOTN
    , _ANTI_DUMPING_NOTN_SLNO, _CTH_SLNO, _CTH_SUPPLIER_SLNO, _CTH_QTY, _CTH_NO, _PRODUCT_RITC, _PRODUCT_CTH, _PRODUCT_CVD_RATE, _MERIT_PRODUCT_CVD_RATE, _PRODUCT_CVD_RATE_UPDATE
    , _PRODUCT_CVD_NOTN, _PRODUCT_CVD_NOTN_SLNO, _PRODUCT_CVD_SPL, _PRODUCT_EDU_CESS_RATE, _PRODUCT_SEC_EDU_CESS_RATE
    ,_PRODUCT_BCD_RATE, _MERIT_PRODUCT_BCD_RATE, _PRODUCT_BCD_RATE_UPDATE, _CTH_SPL_UNIT , _PRODUCT_BCD_NOTN, _PRODUCT_ADDL_DUTY_NOTN, _ADDTIONAL_DUTY_RATE, _PRODUCT_ADDL_DUTY_RATE, _PRODUCT_SEC_EDU_CESS_NOTN, _PRODUCT_EDU_CESS_NOTN, _EXCEMPTION, _INVOICE_CURRENCY, _Invoice_Currency
    ,_PRODUCT_CETH, _ADDTIONAL_DUTY, _AGGREGATE_TOTAL, _BASIC_DUTY_TOATAL, _CVD_TOTAL, _NCD_TOTAL, _CESS_TOTAL, _CEC_TOTAL, _CHEC_TOTAL, _ADDLTIONAL_DUTY_TOTAL, _TOTAL_ITEM_DUTY, _NUMBERTOWORDS, _INFRA_CESS_TOTAL
    ,_PRODUCT_MRP_YN, _PRODUCT_MRP_SL_NO, _PRODUCT_MRP_AMOUNT, _PRODUCT_MRP_ABT_RATE, _RSP_NOTN_NO, _RSP_NOTN_SL_NO, _RSP_APPLICABLE
    ,_PRODUCT_OTHER_DUTY_NOTN, _PRODUCT_OTHER_DUTY_SLNO, _PRODUCT_OTHER_DUTY_RATE, _PRODUCT_OTHER_DUTY_SPL, _PRODUCT_OTHER_DUTY_UNIT, _PRODUCT_OTHER_DUTY_TYPE, _PRODUCT_OTHER_DUTY_TOTAL
    ,_PRODUCT_CVD_EDU_CESS_RATE, _PRODUCT_CVD_SEC_EDU_CESS_RATE, _CETH_CVD_EDU_CESS_SL, _CETH_CVD_EDU_CESS_RATE, _CETH_CVD_SEC_EDU_CESS_SL, _CETH_CVD_SEC_EDU_CESS_RATE
    ,_CVD_CEC_TOTAL,_CVD_CHEC_TOTAL ,_ITEM_SVB_RELATION, _ITEM_SVB_REF_NO, _ITEM_SVB_REF_DATE, _ITEM_SVB_CUSTOM_HOUSE, _ITEM_SVB_LOADING_ON, _ITEM_SVB_ASSESABLE_RATE, _ITEM_SVB_DUTY_RATE, _ITEM_SVB_ASSESABLE_STATUS, _ITEM_SVB_DUTY_STATUS
    ,_INFRA_CESS_NOTN, _INFRA_CESS_NOTN_SL, _INFRA_CESS_NOTN_RATE

    //----------------GST IMPLEMENTATION ON 30JUNE2017------------------------//
    ,_IGST_LEVY_NOTN, _IGST_LEVY_SLNO, _IGST_LEVY_RATE, _IGST_LEVY_RATE_UPDATE, _IGST_LEVY_EXCEPTION_NOTN, _IGST_LEVY_EXCEPTION_SLNO, _IGST_LEVY_EXCEPTION_RATE, _IGST_LEVY_COMPENSATION_CESS_NOTN, _IGST_LEVY_COMPENSATION_CESS_SLNO
    ,_IGST_LEVY_COMPENSATION_CESS_RATE, _IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE, _IGST_LEVY_EXCEPTION_CC_NOTN, _IGST_LEVY_EXCEPTION_CC_SLNO, _IGST_LEVY_EXCEPTION_CC_RATE
    ,_LEVY_EXCEMPTION_NOTN_TYPE, _LEVY_EXCEPTION_CC_NOTN_TYPE,_END_USE_OF_ITEM,_NOTIFICATION_EXCISE_BCD_SPL
    //----------------GST IMPLEMENTATION ON 30JUNE2017------------------------//
    ,_SCHED11_TOTAL, _PRODUCT_ADDL_SHEII_NOTN, _PRODUCT_ADDL_SHEII_SLNO, _PRODUCT_ADDL_SHEII_RATE, _GSI_TOTAL,_PRODUCT_ADDL_GSI_NOTN, _PRODUCT_ADDL_GSI_SLNO
    ,_PRODUCT_ADDL_GSI_RATE, _PRODUCT_ADDL_GSI_SPL, _PRODUCT_ADDL_GSI_UNIT, _PRODUCT_ADDL_GSI_SPL_TYPE,_TTA_TOTAL, _PRODUCT_ADDL_TTA_NOTN, _PRODUCT_ADDL_TTA_SLNO, _PRODUCT_ADDL_TTA_RATE, _PRODUCT_ADDL_TTA_SPL, _PRODUCT_ADDL_TTA_UNIT, _PRODUCT_ADDL_TTA_TYPE
    ,_PRODUCT_NCD_NOTN, _PRODUCT_NCD_SLNO, _PRODUCT_NCD_RATE, _PRODUCT_NCD_SPL, _PRODUCT_NCD_UNIT, _PRODUCT_NCD_SPL_TYPE,_PRODUCT_SAPTA_NOTN, _PRODUCT_SAPTA_SLNO, _PRODUCT_SAPTA_RATE
    ,_PRODUCT_TARIFF_NOTN, _PRODUCT_TARIFF_SLNO, _PRODUCT_TARIFF_QTY, _PRODUCT_TARIFF_AMOUNT, _PRODUCT_TARIFF_AMOUNT_UNIT,_PRODUCT_SAFEGUARD_NOTN, _PRODUCT_SAFEGUARD_SLNO, _PRODUCT_SAFEGUARD_RATE
    ,_PRODUCT_SAFEGUARD_SPL, _PRODUCT_SAFEGUARD_UNIT, _PRODUCT_SAFEGUARD_SPL_TYPE,_PRODUCT_AGGREGATE_DUTY_NOTN, _PRODUCT_AGGREGATE_DUTY_NOTN_SL, _PRODUCT_AGGREGATE_DUTY_NOTN_RATE
    ,_CETH_SPL_AMT,_CTH_SPL_AMT, _TOTAL_DEBIT_DUTY, _MERIT_TOTAL_DEBIT_DUTY, _TOTAL_DEBIT_DUTY_FINAL, _CTH_QTY1, _CTH_QTY1_CODE, _CTH_NCD_D_RATE, _CTH_SAFEGUARD_RATE, _NOTIFICATION_CUSTOMS_BCD_RATE
    ,_NOTIFICATION_CUSTOMS_CVD_RATE, _NOTIFICATION_CUSTOMS_BCD_SPL, _CTH_INFRA_CESS_RATE, _CETH_CESS_AMTS, _CETH_CESS_RTA, _CETH_CESS_UQC, _CESS_ROW_VISIBLE, _ENTRY_DEBIT_DUTY,_SAFE_GUARD_TOTAL
    , _PRODUCT_BCD_NOTN_SLNO, _PRODUCT_ADDL_DUTY_NOTN_SLNO, _PRODUCT_SEC_EDU_CESS_NOTN_SLNO, _PRODUCT_EDU_CESS_NOTN_SLNO, _PRODUCT_BCD_SPL, _SOCIAL_WELFARE_NOTN, _SOCIAL_WELFARE_NOTN_SLNO, _SOCIAL_WELFARE_RATE;
    
    public string PRODUCT_BCD_NOTN_SLNO { get { return _PRODUCT_BCD_NOTN_SLNO; } set { _PRODUCT_BCD_NOTN_SLNO = value; } }
    public string PRODUCT_BCD_SPL { get { return _PRODUCT_BCD_SPL; } set { _PRODUCT_BCD_SPL = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN_SLNO { get { return _PRODUCT_ADDL_DUTY_NOTN_SLNO; } set { _PRODUCT_ADDL_DUTY_NOTN_SLNO = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN_SLNO { get { return _PRODUCT_SEC_EDU_CESS_NOTN_SLNO; } set { _PRODUCT_SEC_EDU_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_EDU_CESS_NOTN_SLNO { get { return _PRODUCT_EDU_CESS_NOTN_SLNO; } set { _PRODUCT_EDU_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_CVD_NOTN_SLNO { get { return _PRODUCT_CVD_NOTN_SLNO; } set { _PRODUCT_CVD_NOTN_SLNO = value; } }
    public string PRODUCT_CVD_SPL { get { return _PRODUCT_CVD_SPL; } set { _PRODUCT_CVD_SPL = value; } }
    public string CESS_ROW_VISIBLE { get { return _CESS_ROW_VISIBLE; } set { _CESS_ROW_VISIBLE = value; } }
    public string SAFE_GUARD_TOTAL { get { return _SAFE_GUARD_TOTAL; } set { _SAFE_GUARD_TOTAL = value; } }

    public string SOCIAL_WELFARE_NOTN { get { return _SOCIAL_WELFARE_NOTN; } set { _SOCIAL_WELFARE_NOTN = value; } }
    public string SOCIAL_WELFARE_NOTN_SLNO { get { return _SOCIAL_WELFARE_NOTN_SLNO; } set { _SOCIAL_WELFARE_NOTN_SLNO = value; } }
    public string SOCIAL_WELFARE_RATE { get { return _SOCIAL_WELFARE_RATE; } set { _SOCIAL_WELFARE_RATE = value; } }

    public string TRANSPORT_MODE, MIS_FREIGHT_CHARGES, MIS_FREIGHT_CURRENCY, MIS_FREIGHT_EXRATE, MIS_INSURANCE_CHARGES, MIS_INSURANCE_CURRENCY, MIS_INSURANCE_EXRATE, SVB_ASSESABLE_RATE
   ,SVB_DUTY_RATE, MIS_CHARGES, MIS_RATE, MIS_EXRATE, MIS_HIGHSEASALE_RATE, MIS_HIGHSEASALE_CHARGES, MIS_DISCOUNT_RATE, MIS_DISCOUNT_CHARGES, D_AMOUNT, M_AMOUNT, N_AMOUNT, TERMS_PLACE
   ,THIRDPARTY_NAME, THIRDPARTY_ADD1, THIRDPARTY_ADD2, THIRDPARTY_CITY, T_PARTY_COUNTRY_SUB_DIV, T_PARTY_COUNTRY_CODE, T_PARTY_PIN, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY
   ,AUTHORIZED_ECONOMIC_OPERATOR, WHETHER_BUYER_SELLER_RELATED, MIS_CURRENCY, MIS_LOADING_CHARGES, MIS_LOADING_CURRENCY, MIS_LOADING_EXRATE, MIS_DISCOUNT_CURRENCY, MIS_DISCOUNT_EXRATE
   ,MIS_HIGHSEASALE_CURRENCY, REIMPORT_FREIGHT, REIMPORT_INSURANCE, NOTN_NO, NOTN_SLNO, MIS_HIGHSEASALE_EXRATE
   ,ADD_AMT_MINUS_ASSESABLE, ANTI_AMTS, MAX_DIFF,ADD_DIFF_CUR, TOTAL_ANTI_AMT = "0", MERIT_TOTAL_ANTI_AMT = "0"
   , ADD_ANTI_CUR, SCHEME_RATE_NEW, BCD_NOTN, CVD_NOTN, EDU_CESS_NOTN, SEC_EDU_CESS_NOTN, PRODUCT_CVD_EDU_CESS_NOTN_SL, PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL, SCHEME_NOTN_ = "";
  

    public double INVOICE_VALUE_INR, TOTAL_INVOICE_VALUE, REIMPORT_FREIGHT_AMOUNT, REIMPORT_INSURANCE_AMOUNT, MISC_AMOUNT, DISCOUNT_AMOUNT = 0, INVOICE_AMOUNT = 0, INSURANCE_AMOUNT = 0
   , FREIGHT_AMOUNT = 0, INDIVITUAL_INVOICE_VALUE = 0, INDIVITUAL_FREIGHT_AMOUNT = 0, INDIVITUAL_INSURANCE_AMOUNT = 0, INDIVITUAL_MISC_AMOUNT = 0, INDIVITUAL_TOTAL_AMOUNT = 0, INDIVITUAL_HSS_AMOUNT = 0
   , INDIVITUAL_SVB_AMOUNT = 0, INDIVITUAL_CIF_AMOUNT = 0, INDIVITUAL_LANDING_COST = 0, INDIVITUAL_ASSESSABLE_AMOUNT = 0, CHECK_FREIGHT_RATE = 0, CHECK_FREIGHT_EXRATE = 0, LICENSE_DEBIT_AMT = 0
   , TOTAL_ANTIDUMP_AMT = 0, MERIT_TOTAL_ANTIDUMP_AMT = 0, ADD_ANTI_AMTS, EXCHANGE_RATE, ADD_MAX_DIFF

   , INDIVITUAL_DISCOUNT_AMOUNT = 0, BASIC_DUTY, MERIT_BASIC_DUTY, CVD, INFRA_CESS, MERIT_CVD, NCD, CESS, MERIT_CESS, Customs_Edu_Cess, merit_Customs_Edu_Cess, Customs_Higher_Edu_Cess, merit_Customs_Higher_Edu_Cess, AddL_DUTY, merit_AddL_DUTY, TOTAL_DUTY = 0.0, MERIT_TOTAL_DUTY = 0.0, SAFE_GUARD, AGGREGATE_DUTY, _TOTAL_CUSTOMS_DUTY = 0.0, _TOTAL_IGST_DUTY = 0.0
   , MERIT_BASIC_VALUE, MERIT_CVD_VALUE, MERIT_CEC_VALUE, MERIT_CHEC_VALUE, MERIT_ADD_DUTY_VALUE
   , MERIT_NOTN_BASIC_VALUE, MERIT_NOTN_CVD_VALUE, MERIT_NOTN_CEC_VALUE, MERIT_NOTN_CHEC_VALUE, MERIT_NOTN_ADD_DUTY_VALUE, MERIT_NOTN_CESS_VALUE, MERIT_NOTN_NCD_VALUE
   , BASIC_DUTY_BCD_SPL, cvd_Customs_Edu_Cess, cvd_Customs_Higher_Edu_Cess, Other_duty = 0.00
   , Aggregate_cvd, Aggregate_basic_duty, Aggregate_ncd, Aggregate_cess, Aggregate_Customs_Edu_Cess, Aggregate_Customs_Higher_Edu_Cess, Aggregate_AddL_DUTY, Aggregate_safe_guard
   , MRP_AMT;

    public double merit_social_welfare_cess, social_welfare, SOCIAL_welf_Rate, Customs_Social_welfare;
    public string _TOTAL_SOCIAL_WELFARE;

    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_NO_ITEM { get { return _INVOICE_NO_ITEM; } set { _INVOICE_NO_ITEM = value; } }
    public string Invoice_No { get { return _Invoice_No; } set { _Invoice_No = value; } }
    public string Invoice_Details { get { return _Invoice_Details; } set { _Invoice_Details = value; } }
    public string EXCEMPTION { get { return _EXCEMPTION; } set { _EXCEMPTION = value; } }
    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string Invoice_value { get { return _Invoice_value; } set { _Invoice_value = value; } }
    public string INVOICE_CURRENCY { get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }
    public string INVOICE_EXRATE { get { return _INVOICE_EXRATE; } set { _INVOICE_EXRATE = value; } }
    public string Invoice_Currency { get { return _Invoice_Currency; } set { _Invoice_Currency = value; } }
    public string MIS_FREIGHT_RATE { get { return _MIS_FREIGHT_RATE; } set { _MIS_FREIGHT_RATE = value; } }
    public string MIS_INSURANCE_RATE { get { return _MIS_INSURANCE_RATE; } set { _MIS_INSURANCE_RATE = value; } }
    public string REVENUEDEPOSIT_RATE { get { return _REVENUEDEPOSIT_RATE; } set { _REVENUEDEPOSIT_RATE = value; } }
    public string REVENUEDEPOSIT_ON { get { return _REVENUEDEPOSIT_ON; } set { _REVENUEDEPOSIT_ON = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }
    public string PORT_SHIPMENT { get { return _PORT_SHIPMENT; } set { _PORT_SHIPMENT = value; } }
    public string FILING_STATUS { get { return _FILING_STATUS; } set { _FILING_STATUS = value; } }

    public string COUNTRY_OF_ORIGIN { get { return _COUNTRY_OF_ORIGIN; } set { _COUNTRY_OF_ORIGIN = value; } }
    public string Country_Shipment { get { return _Country_Shipment; } set { _Country_Shipment = value; } }
    //ITEM DETAILS
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
    public string SCHEME { get { return _SCHEME; } set { _SCHEME = value; } }
    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
    public string SCHEME_NOTN { get { return _SCHEME_NOTN; } set { _SCHEME_NOTN = value; } }
    public string SCHEME_NOTN_SLNO { get { return _SCHEME_NOTN_SLNO; } set { _SCHEME_NOTN_SLNO = value; } }
    public string ANTI_DUMPING_NOTN { get { return _ANTI_DUMPING_NOTN; } set { _ANTI_DUMPING_NOTN = value; } }
    public string ANTI_DUMPING_NOTN_SLNO { get { return _ANTI_DUMPING_NOTN_SLNO; } set { _ANTI_DUMPING_NOTN_SLNO = value; } }
    public string CTH_SLNO { get { return _CTH_SLNO; } set { _CTH_SLNO = value; } }
    public string CTH_SUPPLIER_SLNO { get { return _CTH_SUPPLIER_SLNO; } set { _CTH_SUPPLIER_SLNO = value; } }
    public string CTH_QTY { get { return _CTH_QTY; } set { _CTH_QTY = value; } }
    public string CTH_NO { get { return _CTH_NO; } set { _CTH_NO = value; } }
    public string PRODUCT_RITC { get { return _PRODUCT_RITC; } set { _PRODUCT_RITC = value; } }
    public string PRODUCT_CTH { get { return _PRODUCT_CTH; } set { _PRODUCT_CTH = value; } }
    public string PRODUCT_CVD_RATE { get { return _PRODUCT_CVD_RATE; } set { _PRODUCT_CVD_RATE = value; } }
    public string MERIT_PRODUCT_CVD_RATE { get { return _MERIT_PRODUCT_CVD_RATE; } set { _MERIT_PRODUCT_CVD_RATE = value; } }
    public string PRODUCT_CVD_RATE_UPDATE { get { return _PRODUCT_CVD_RATE_UPDATE; } set { _PRODUCT_CVD_RATE_UPDATE = value; } }
    public string PRODUCT_EDU_CESS_RATE { get { return _PRODUCT_EDU_CESS_RATE; } set { _PRODUCT_EDU_CESS_RATE = value; } }
    public string PRODUCT_EDU_CESS_NOTN { get { return _PRODUCT_EDU_CESS_NOTN; } set { _PRODUCT_EDU_CESS_NOTN = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN { get { return _PRODUCT_SEC_EDU_CESS_NOTN; } set { _PRODUCT_SEC_EDU_CESS_NOTN = value; } }
    public string PRODUCT_SEC_EDU_CESS_RATE { get { return _PRODUCT_SEC_EDU_CESS_RATE; } set { _PRODUCT_SEC_EDU_CESS_RATE = value; } }
    public string PRODUCT_BCD_NOTN { get { return _PRODUCT_BCD_NOTN; } set { _PRODUCT_BCD_NOTN = value; } }
    public string PRODUCT_BCD_RATE { get { return _PRODUCT_BCD_RATE; } set { _PRODUCT_BCD_RATE = value; } }
    public string MERIT_PRODUCT_BCD_RATE { get { return _MERIT_PRODUCT_BCD_RATE; } set { _MERIT_PRODUCT_BCD_RATE = value; } }
    public string PRODUCT_BCD_RATE_UPDATE { get { return _PRODUCT_BCD_RATE_UPDATE; } set { _PRODUCT_BCD_RATE_UPDATE = value; } }
    public string CTH_SPL_UNIT { get { return _CTH_SPL_UNIT; } set { _CTH_SPL_UNIT = value; } }
    public string PRODUCT_CVD_NOTN { get { return _PRODUCT_CVD_NOTN; } set { _PRODUCT_CVD_NOTN = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN { get { return _PRODUCT_ADDL_DUTY_NOTN; } set { _PRODUCT_ADDL_DUTY_NOTN = value; } }
    public string PRODUCT_ADDL_DUTY_RATE { get { return _PRODUCT_ADDL_DUTY_RATE; } set { _PRODUCT_ADDL_DUTY_RATE = value; } }
    public string PRODUCT_CETH { get { return _PRODUCT_CETH; } set { _PRODUCT_CETH = value; } }
    public string ADDTIONAL_DUTY { get { return _ADDTIONAL_DUTY; } set { _ADDTIONAL_DUTY = value; } }
    public string ADDTIONAL_DUTY_RATE { get { return _ADDTIONAL_DUTY_RATE; } set { _ADDTIONAL_DUTY_RATE = value; } }
    public string PRODUCT_ADDL_SHEII_NOTN { get { return _PRODUCT_ADDL_SHEII_NOTN; } set { _PRODUCT_ADDL_SHEII_NOTN = value; } }
    public string PRODUCT_ADDL_SHEII_SLNO { get { return _PRODUCT_ADDL_SHEII_SLNO; } set { _PRODUCT_ADDL_SHEII_SLNO = value; } }
    public string PRODUCT_ADDL_SHEII_RATE { get { return _PRODUCT_ADDL_SHEII_RATE; } set { _PRODUCT_ADDL_SHEII_RATE = value; } }
    public string SCHED11_TOTAL { get { return _SCHED11_TOTAL; } set { _SCHED11_TOTAL = value; } }
    public string PRODUCT_ADDL_GSI_NOTN { get { return _PRODUCT_ADDL_GSI_NOTN; } set { _PRODUCT_ADDL_GSI_NOTN = value; } }
    public string PRODUCT_ADDL_GSI_SLNO { get { return _PRODUCT_ADDL_GSI_SLNO; } set { _PRODUCT_ADDL_GSI_SLNO = value; } }
    public string PRODUCT_ADDL_GSI_RATE { get { return _PRODUCT_ADDL_GSI_RATE; } set { _PRODUCT_ADDL_GSI_RATE = value; } }
    public string PRODUCT_ADDL_GSI_SPL { get { return _PRODUCT_ADDL_GSI_SPL; } set { _PRODUCT_ADDL_GSI_SPL = value; } }
    public string PRODUCT_ADDL_GSI_UNIT { get { return _PRODUCT_ADDL_GSI_UNIT; } set { _PRODUCT_ADDL_GSI_UNIT = value; } }
    public string PRODUCT_ADDL_GSI_SPL_TYPE { get { return _PRODUCT_ADDL_GSI_SPL_TYPE; } set { _PRODUCT_ADDL_GSI_SPL_TYPE = value; } }
    public string GSI_TOTAL { get { return _GSI_TOTAL; } set { _GSI_TOTAL = value; } }
    public string PRODUCT_ADDL_TTA_NOTN { get { return _PRODUCT_ADDL_TTA_NOTN; } set { _PRODUCT_ADDL_TTA_NOTN = value; } }
    public string PRODUCT_ADDL_TTA_SLNO { get { return _PRODUCT_ADDL_TTA_SLNO; } set { _PRODUCT_ADDL_TTA_SLNO = value; } }
    public string PRODUCT_ADDL_TTA_RATE { get { return _PRODUCT_ADDL_TTA_RATE; } set { _PRODUCT_ADDL_TTA_RATE = value; } }
    public string PRODUCT_ADDL_TTA_SPL { get { return _PRODUCT_ADDL_TTA_SPL; } set { _PRODUCT_ADDL_TTA_SPL = value; } }
    public string PRODUCT_ADDL_TTA_UNIT { get { return _PRODUCT_ADDL_TTA_UNIT; } set { _PRODUCT_ADDL_TTA_UNIT = value; } }
    public string PRODUCT_ADDL_TTA_TYPE { get { return _PRODUCT_ADDL_TTA_TYPE; } set { _PRODUCT_ADDL_TTA_TYPE = value; } }
    public string PRODUCT_NCD_NOTN { get { return _PRODUCT_NCD_NOTN; } set { _PRODUCT_NCD_NOTN = value; } }
    public string PRODUCT_NCD_SLNO { get { return _PRODUCT_NCD_SLNO; } set { _PRODUCT_NCD_SLNO = value; } }
    public string PRODUCT_NCD_RATE { get { return _PRODUCT_NCD_RATE; } set { _PRODUCT_NCD_RATE = value; } }
    public string PRODUCT_NCD_SPL { get { return _PRODUCT_NCD_SPL; } set { _PRODUCT_NCD_SPL = value; } }
    public string PRODUCT_NCD_UNIT { get { return _PRODUCT_NCD_UNIT; } set { _PRODUCT_NCD_UNIT = value; } }
    public string PRODUCT_NCD_SPL_TYPE { get { return _PRODUCT_NCD_SPL_TYPE; } set { _PRODUCT_NCD_SPL_TYPE = value; } }
    public string PRODUCT_TARIFF_NOTN { get { return _PRODUCT_TARIFF_NOTN; } set { _PRODUCT_TARIFF_NOTN = value; } }
    public string PRODUCT_TARIFF_SLNO { get { return _PRODUCT_TARIFF_SLNO; } set { _PRODUCT_TARIFF_SLNO = value; } }
    public string PRODUCT_TARIFF_QTY { get { return _PRODUCT_TARIFF_QTY; } set { _PRODUCT_TARIFF_QTY = value; } }
    public string PRODUCT_TARIFF_AMOUNT { get { return _PRODUCT_TARIFF_AMOUNT; } set { _PRODUCT_TARIFF_AMOUNT = value; } }
    public string PRODUCT_TARIFF_AMOUNT_UNIT { get { return _PRODUCT_TARIFF_AMOUNT_UNIT; } set { _PRODUCT_TARIFF_AMOUNT_UNIT = value; } }
    public string PRODUCT_SAPTA_NOTN { get { return _PRODUCT_SAPTA_NOTN; } set { _PRODUCT_SAPTA_NOTN = value; } }
    public string PRODUCT_SAPTA_SLNO { get { return _PRODUCT_SAPTA_SLNO; } set { _PRODUCT_SAPTA_SLNO = value; } }
    public string PRODUCT_SAPTA_RATE { get { return _PRODUCT_SAPTA_RATE; } set { _PRODUCT_SAPTA_RATE = value; } }
    public string PRODUCT_SAFEGUARD_NOTN { get { return _PRODUCT_SAFEGUARD_NOTN; } set { _PRODUCT_SAFEGUARD_NOTN = value; } }
    public string PRODUCT_SAFEGUARD_SLNO { get { return _PRODUCT_SAFEGUARD_SLNO; } set { _PRODUCT_SAFEGUARD_SLNO = value; } }
    public string PRODUCT_SAFEGUARD_RATE { get { return _PRODUCT_SAFEGUARD_RATE; } set { _PRODUCT_SAFEGUARD_RATE = value; } }
    public string PRODUCT_SAFEGUARD_SPL { get { return _PRODUCT_SAFEGUARD_SPL; } set { _PRODUCT_SAFEGUARD_SPL = value; } }
    public string PRODUCT_SAFEGUARD_UNIT { get { return _PRODUCT_SAFEGUARD_UNIT; } set { _PRODUCT_SAFEGUARD_UNIT = value; } }
    public string PRODUCT_SAFEGUARD_SPL_TYPE { get { return _PRODUCT_SAFEGUARD_SPL_TYPE; } set { _PRODUCT_SAFEGUARD_SPL_TYPE = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN { get { return _PRODUCT_AGGREGATE_DUTY_NOTN; } set { _PRODUCT_AGGREGATE_DUTY_NOTN = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN_SL { get { return _PRODUCT_AGGREGATE_DUTY_NOTN_SL; } set { _PRODUCT_AGGREGATE_DUTY_NOTN_SL = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN_RATE { get { return _PRODUCT_AGGREGATE_DUTY_NOTN_RATE; } set { _PRODUCT_AGGREGATE_DUTY_NOTN_RATE = value; } }
    public string PRODUCT_MRP_YN { get { return _PRODUCT_MRP_YN; } set { _PRODUCT_MRP_YN = value; } }
    public string PRODUCT_MRP_SL_NO { get { return _PRODUCT_MRP_SL_NO; } set { _PRODUCT_MRP_SL_NO = value; } }
    public string PRODUCT_MRP_AMOUNT { get { return _PRODUCT_MRP_AMOUNT; } set { _PRODUCT_MRP_AMOUNT = value; } }
    public string PRODUCT_MRP_ABT_RATE { get { return _PRODUCT_MRP_ABT_RATE; } set { _PRODUCT_MRP_ABT_RATE = value; } }
    public string RSP_APPLICABLE { get { return _RSP_APPLICABLE; } set { _RSP_APPLICABLE = value; } }  
    public string RSP_NOTN_NO { get { return _RSP_NOTN_NO; } set { _RSP_NOTN_NO = value; } }
    public string RSP_NOTN_SL_NO { get { return _RSP_NOTN_SL_NO; } set { _RSP_NOTN_SL_NO = value; } }
    public string PRODUCT_OTHER_DUTY_NOTN { get { return _PRODUCT_OTHER_DUTY_NOTN; } set { _PRODUCT_OTHER_DUTY_NOTN = value; } }
    public string PRODUCT_OTHER_DUTY_SLNO { get { return _PRODUCT_OTHER_DUTY_SLNO; } set { _PRODUCT_OTHER_DUTY_SLNO = value; } }
    public string PRODUCT_OTHER_DUTY_RATE { get { return _PRODUCT_OTHER_DUTY_RATE; } set { _PRODUCT_OTHER_DUTY_RATE = value; } }
    public string PRODUCT_OTHER_DUTY_SPL { get { return _PRODUCT_OTHER_DUTY_SPL; } set { _PRODUCT_OTHER_DUTY_SPL = value; } }
    public string PRODUCT_OTHER_DUTY_UNIT { get { return _PRODUCT_OTHER_DUTY_UNIT; } set { _PRODUCT_OTHER_DUTY_UNIT = value; } }
    public string PRODUCT_OTHER_DUTY_TYPE { get { return _PRODUCT_OTHER_DUTY_TYPE; } set { _PRODUCT_OTHER_DUTY_TYPE = value; } }
    public string PRODUCT_OTHER_DUTY_TOTAL { get { return _PRODUCT_OTHER_DUTY_TOTAL; } set { _PRODUCT_OTHER_DUTY_TOTAL = value; } }
    //------------------------------
    public string PRODUCT_CVD_EDU_CESS_RATE { get { return _PRODUCT_CVD_EDU_CESS_RATE; } set { _PRODUCT_CVD_EDU_CESS_RATE = value; } }
    public string PRODUCT_CVD_SEC_EDU_CESS_RATE { get { return _PRODUCT_CVD_SEC_EDU_CESS_RATE; } set { _PRODUCT_CVD_SEC_EDU_CESS_RATE = value; } }
    public string CETH_CVD_EDU_CESS_SL { get { return _CETH_CVD_EDU_CESS_SL; } set { _CETH_CVD_EDU_CESS_SL = value; } }
    public string CETH_CVD_EDU_CESS_RATE { get { return _CETH_CVD_EDU_CESS_RATE; } set { _CETH_CVD_EDU_CESS_RATE = value; } }
    public string CETH_CVD_SEC_EDU_CESS_SL { get { return _CETH_CVD_SEC_EDU_CESS_SL; } set { _CETH_CVD_SEC_EDU_CESS_SL = value; } }
    public string CETH_CVD_SEC_EDU_CESS_RATE { get { return _CETH_CVD_SEC_EDU_CESS_RATE; } set { _CETH_CVD_SEC_EDU_CESS_RATE = value; } }
    public string CVD_CEC_TOTAL { get { return _CVD_CEC_TOTAL; } set { _CVD_CEC_TOTAL = value; } }
    public string CVD_CHEC_TOTAL { get { return _CVD_CHEC_TOTAL; } set { _CVD_CHEC_TOTAL = value; } }
    public string TOTAL_SOCIAL_WELFARE { get { return _TOTAL_SOCIAL_WELFARE; } set { _TOTAL_SOCIAL_WELFARE = value; } }


    //-----------------------ITEMWISE SVB DETAIS FOR NIPPON----------------------------//
    public string ITEM_SVB_RELATION { get { return _ITEM_SVB_RELATION; } set { _ITEM_SVB_RELATION = value; } }
    public string ITEM_SVB_REF_NO { get { return _ITEM_SVB_REF_NO; } set { _ITEM_SVB_REF_NO = value; } }
    public string ITEM_SVB_REF_DATE { get { return _ITEM_SVB_REF_DATE; } set { _ITEM_SVB_REF_DATE = value; } }
    public string ITEM_SVB_CUSTOM_HOUSE { get { return _ITEM_SVB_CUSTOM_HOUSE; } set { _ITEM_SVB_CUSTOM_HOUSE = value; } }
    public string ITEM_SVB_LOADING_ON { get { return _ITEM_SVB_LOADING_ON; } set { _ITEM_SVB_LOADING_ON = value; } }
    public string ITEM_SVB_ASSESABLE_RATE { get { return _ITEM_SVB_ASSESABLE_RATE; } set { _ITEM_SVB_ASSESABLE_RATE = value; } }
    public string ITEM_SVB_DUTY_RATE { get { return _ITEM_SVB_DUTY_RATE; } set { _ITEM_SVB_DUTY_RATE = value; } }
    public string ITEM_SVB_ASSESABLE_STATUS { get { return _ITEM_SVB_ASSESABLE_STATUS; } set { _ITEM_SVB_ASSESABLE_STATUS = value; } }
    public string ITEM_SVB_DUTY_STATUS { get { return _ITEM_SVB_DUTY_STATUS; } set { _ITEM_SVB_DUTY_STATUS = value; } }
    public string INFRA_CESS_NOTN { get { return _INFRA_CESS_NOTN; } set { _INFRA_CESS_NOTN = value; } }
    public string INFRA_CESS_NOTN_SL { get { return _INFRA_CESS_NOTN_SL; } set { _INFRA_CESS_NOTN_SL = value; } }
    public string INFRA_CESS_NOTN_RATE { get { return _INFRA_CESS_NOTN_RATE; } set { _INFRA_CESS_NOTN_RATE = value; } }
    //-----------------------ITEMWISE SVB DETAIS FOR NIPPON----------------------------//

     //-----------------------GST IMPLEMENTATION ON 30JUNE2017----------------------------//
    public string IGST_LEVY_NOTN { get { return _IGST_LEVY_NOTN; } set { _IGST_LEVY_NOTN = value; } }
    public string IGST_LEVY_SLNO { get { return _IGST_LEVY_SLNO; } set { _IGST_LEVY_SLNO = value; } }
    public string IGST_LEVY_RATE { get { return _IGST_LEVY_RATE; } set { _IGST_LEVY_RATE = value; } }
    public string IGST_LEVY_RATE_UPDATE { get { return _IGST_LEVY_RATE_UPDATE; } set { _IGST_LEVY_RATE_UPDATE = value; } }
    public string IGST_LEVY_EXCEPTION_NOTN { get { return _IGST_LEVY_EXCEPTION_NOTN; } set { _IGST_LEVY_EXCEPTION_NOTN = value; } }
    public string IGST_LEVY_EXCEPTION_SLNO { get { return _IGST_LEVY_EXCEPTION_SLNO; } set { _IGST_LEVY_EXCEPTION_SLNO = value; } }
    public string IGST_LEVY_EXCEPTION_RATE { get { return _IGST_LEVY_EXCEPTION_RATE; } set { _IGST_LEVY_EXCEPTION_RATE = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_NOTN { get { return _IGST_LEVY_COMPENSATION_CESS_NOTN; } set { _IGST_LEVY_COMPENSATION_CESS_NOTN = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_SLNO { get { return _IGST_LEVY_COMPENSATION_CESS_SLNO; } set { _IGST_LEVY_COMPENSATION_CESS_SLNO = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_RATE { get { return _IGST_LEVY_COMPENSATION_CESS_RATE; } set { _IGST_LEVY_COMPENSATION_CESS_RATE = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE { get { return _IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE; } set { _IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE = value; } }
    public string IGST_LEVY_EXCEPTION_CC_NOTN { get { return _IGST_LEVY_EXCEPTION_CC_NOTN; } set { _IGST_LEVY_EXCEPTION_CC_NOTN = value; } }
    public string IGST_LEVY_EXCEPTION_CC_SLNO { get { return _IGST_LEVY_EXCEPTION_CC_SLNO; } set { _IGST_LEVY_EXCEPTION_CC_SLNO = value; } }
    public string IGST_LEVY_EXCEPTION_CC_RATE { get { return _IGST_LEVY_EXCEPTION_CC_RATE; } set { _IGST_LEVY_EXCEPTION_CC_RATE = value; } }
    public string LEVY_EXCEMPTION_NOTN_TYPE { get { return _LEVY_EXCEMPTION_NOTN_TYPE; } set { _LEVY_EXCEMPTION_NOTN_TYPE = value; } }
    public string LEVY_EXCEPTION_CC_NOTN_TYPE { get { return _LEVY_EXCEPTION_CC_NOTN_TYPE; } set { _LEVY_EXCEPTION_CC_NOTN_TYPE = value; } }
    public double TOTAL_CUSTOMS_DUTY { get { return _TOTAL_CUSTOMS_DUTY; } set { _TOTAL_CUSTOMS_DUTY = value; } }
    public double TOTAL_IGST_DUTY { get { return _TOTAL_IGST_DUTY; } set { _TOTAL_IGST_DUTY = value; } }
    public string END_USE_OF_ITEM { get { return _END_USE_OF_ITEM; } set { _END_USE_OF_ITEM = value; } }
    public string NOTIFICATION_EXCISE_BCD_SPL { get { return _NOTIFICATION_EXCISE_BCD_SPL; } set { _NOTIFICATION_EXCISE_BCD_SPL = value; } }
    //-----------------------GST IMPLEMENTATION ON 30JUNE2017----------------------------//                  
    public string TTA_TOTAL { get { return _TTA_TOTAL; } set { _TTA_TOTAL = value; } }
    public string CETH_SPL_AMT { get { return _CETH_SPL_AMT; } set { _CETH_SPL_AMT = value; } }
    public string CTH_SPL_AMT { get { return _CTH_SPL_AMT; } set { _CTH_SPL_AMT = value; } }
    public string TOTAL_DEBIT_DUTY { get { return _TOTAL_DEBIT_DUTY; } set { _TOTAL_DEBIT_DUTY = value; } }
    public string MERIT_TOTAL_DEBIT_DUTY { get { return _MERIT_TOTAL_DEBIT_DUTY; } set { _MERIT_TOTAL_DEBIT_DUTY = value; } }
    public string TOTAL_DEBIT_DUTY_FINAL { get { return _TOTAL_DEBIT_DUTY_FINAL; } set { _TOTAL_DEBIT_DUTY_FINAL = value; } }
    public string CTH_QTY1 { get { return _CTH_QTY1; } set { _CTH_QTY1 = value; } }
    public string CTH_QTY1_CODE { get { return _CTH_QTY1_CODE; } set { _CTH_QTY1_CODE = value; } }
    public string CTH_NCD_D_RATE { get { return _CTH_NCD_D_RATE; } set { _CTH_NCD_D_RATE = value; } }
    public string CTH_SAFEGUARD_RATE { get { return _CTH_SAFEGUARD_RATE; } set { _CTH_SAFEGUARD_RATE = value; } }
    public string NOTIFICATION_CUSTOMS_BCD_RATE { get { return _NOTIFICATION_CUSTOMS_BCD_RATE; } set { _NOTIFICATION_CUSTOMS_BCD_RATE = value; } }
    public string NOTIFICATION_CUSTOMS_CVD_RATE { get { return _NOTIFICATION_CUSTOMS_CVD_RATE; } set { _NOTIFICATION_CUSTOMS_CVD_RATE = value; } }
    public string NOTIFICATION_CUSTOMS_BCD_SPL { get { return _NOTIFICATION_CUSTOMS_BCD_SPL; } set { _NOTIFICATION_CUSTOMS_BCD_SPL = value; } }
    public string CTH_INFRA_CESS_RATE { get { return _CTH_INFRA_CESS_RATE; } set { _CTH_INFRA_CESS_RATE = value; } }
    public string CETH_CESS_AMTS { get { return _CETH_CESS_AMTS; } set { _CETH_CESS_AMTS = value; } }
    public string CETH_CESS_RTA { get { return _CETH_CESS_RTA; } set { _CETH_CESS_RTA = value; } }
    public string CETH_CESS_UQC { get { return _CETH_CESS_UQC; } set { _CETH_CESS_UQC = value; } }
    public string ENTRY_DEBIT_DUTY { get { return _ENTRY_DEBIT_DUTY; } set { _ENTRY_DEBIT_DUTY = value; } }
    //----------------------------------------//

    public string AGGREGATE_TOTAL { get { return _AGGREGATE_TOTAL; } set { _AGGREGATE_TOTAL = value; } }
    public string BASIC_DUTY_TOTAL { get { return _BASIC_DUTY_TOATAL; } set { _BASIC_DUTY_TOATAL = value; } }
    public string CVD_TOTAL { get { return _CVD_TOTAL; } set { _CVD_TOTAL = value; } }
    public string NCD_TOTAL { get { return _NCD_TOTAL; } set { _NCD_TOTAL = value; } }
    public string CESS_TOTAL { get { return _CESS_TOTAL; } set { _CESS_TOTAL = value; } }
    public string INFRA_CESS_TOTAL { get { return _INFRA_CESS_TOTAL; } set { _INFRA_CESS_TOTAL = value; } }
    public string CEC_TOTAL { get { return _CEC_TOTAL; } set { _CEC_TOTAL = value; } }
    public string CHEC_TOTAL { get { return _CHEC_TOTAL; } set { _CHEC_TOTAL = value; } }
    public string ADDLTIONAL_DUTY_TOTAL { get { return _ADDLTIONAL_DUTY_TOTAL; } set { _ADDLTIONAL_DUTY_TOTAL = value; } }
    public string TOTAL_ITEM_DUTY { get { return _TOTAL_ITEM_DUTY; } set { _TOTAL_ITEM_DUTY = value; } }
    public string NUMBERTOWORDS { get { return _NUMBERTOWORDS; } set { _NUMBERTOWORDS = value; } }
    
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string SUPPLIER_COUNTRY_NAME { get { return _SUPPLIER_COUNTRY_NAME; } set { _SUPPLIER_COUNTRY_NAME = value; } }
    public string SUPPLIER_COUNTRY_PINCODE { get { return _SUPPLIER_COUNTRY_PINCODE; } set { _SUPPLIER_COUNTRY_PINCODE = value; } }
    public string SVB_ASSESABLE_STATUS { get { return _SVB_ASSESABLE_STATUS; } set { _SVB_ASSESABLE_STATUS = value; } }
    public string SVB_DUTY_STATUS { get { return _SVB_DUTY_STATUS; } set { _SVB_DUTY_STATUS = value; } }
    public string Total_Invoice { get { return _Total_Invoice; } set { _Total_Invoice = value; } }
    public string SupplierCountry_Name_Pincode { get { return _SupplierCountry_Name_Pincode; } set { _SupplierCountry_Name_Pincode = value; } }
    public string SVB_CUSTOM_HOUSE { get { return _SVB_CUSTOM_HOUSE; } set { _SVB_CUSTOM_HOUSE = value; } }
    public string SUPPLIER_NAME { get { return _SUPPLIER_NAME; } set { _SUPPLIER_NAME = value; } }
    public string SUPPLIER_ADDRESS { get { return _SUPPLIER_ADDRESS; } set { _SUPPLIER_ADDRESS = value; } }
    public string SUPPLIER_ADDRESS1 { get { return _SUPPLIER_ADDRESS1; } set { _SUPPLIER_ADDRESS1 = value; } }
    public string SUPPLIER_ADDRESS2 { get { return _SUPPLIER_ADDRESS2; } set { _SUPPLIER_ADDRESS2 = value; } }
    public string TERMS { get { return _TERMS; } set { _TERMS = value; } }
    public string SVB_RELATION { get { return _SVB_RELATION; } set { _SVB_RELATION = value; } }
    public string SVB_REF_NO { get { return _SVB_REF_NO; } set { _SVB_REF_NO = value; } }
    public string SVB_LOADING_ON { get { return _SVB_LOADING_ON; } set { _SVB_LOADING_ON = value; } }
    public string SVB_REF_DATE { get { return _SVB_REF_DATE; } set { _SVB_REF_DATE = value; } }
    public string SVB_STATUS { get { return _SVB_STATUS; } set { _SVB_STATUS = value; } }
    public string EOU_MERIT_BASIC_DUTY { get { return _EOU_MERIT_BASIC_DUTY; } set { _EOU_MERIT_BASIC_DUTY = value; } }
    public string EOU_MERIT_CVD { get { return _EOU_MERIT_CVD; } set { _EOU_MERIT_CVD = value; } }
    
    #endregion

    //------------------R------------------------------------------
    //CheckList CHKLIST = new CheckList();
    Imp_Checklist IC = new Imp_Checklist();

    

    //---------------------------------------------------------------------------------------------------------------------- 
    #region 2
    Double DEBIT_AMT = 0.0,DEBIT_QTY = 0.0,SUM_DEBIT_QTY = 0.0,INDI_DEBIT_QTY = 0.0,DEBIT_DUTY = 0.0,SUM_ENTRY_DEBIT_DUTY = 0.0;
    DateTime IGMDate, compareDate_IGM;
    string NOTIFICATION_EXCISE_BCD_RATE = "";
    private string _INVOICE_ID, MIS_CHARGES_Add, INVOICE_EXCHANGERATE;
    double IGST_LEV_1_AMT = 0.00,IGST_LEV_2_Excemption = 0.00,IGST_LEV_1_COMPENSATION_AMT = 0.00,IGST_LEV_2_COMPENSATION_AMT = 0.00;

    public string _IGST_LEVY_TOTAL,_IGST_LEVY_TOTAL_DEBIT, _IGST_LEVY_COMPENSATION_CESS_TOTAL,_DUTY_TYPE = "", _ADDL_FLAG = "",ddlJobNo,Igm_DATE,_MIS_CHARGES_
    ,SELECT_BRANCH, Check_Stmt = "", LICENSE_ID;

    public string IGST_LEVY_TOTAL{get { return _IGST_LEVY_TOTAL; }set { _IGST_LEVY_TOTAL = value; }}
    public string IGST_LEVY_TOTAL_DEBIT{get { return _IGST_LEVY_TOTAL_DEBIT; }set { _IGST_LEVY_TOTAL_DEBIT = value; }}
    public string IGST_LEVY_COMPENSATION_CESS_TOTAL {get { return _IGST_LEVY_COMPENSATION_CESS_TOTAL; }set { _IGST_LEVY_COMPENSATION_CESS_TOTAL = value; }}
    public string DUTY_TYPE { get { return _DUTY_TYPE; } set { _DUTY_TYPE = value; } }
    public string ADDL_FLAG { get { return _ADDL_FLAG; } set { _ADDL_FLAG = value; } }
    public string MIS_CHARGES_ { get { return _MIS_CHARGES_; } set { _MIS_CHARGES_ = value; } }
    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }
#endregion 2

    //********************** GST IMPLEMENTATION 30-JUN-2016 DECLARATIONS END ***********************
    
    DataSet dt_All_Rates = new DataSet();
    DataSet ds_Gen = new DataSet();
    Auto_Search auto = new Auto_Search();

    public double CHK_IGST_ASSBL_VAL = 0.00, CHK_IGST_LEVY_AMT = 0.00, CHK_IGST_CESS_AMT = 0.00, tot_CHK_IGST_ASSBL_VAL = 0.00, tot_CHK_IGST_LEVY_AMT = 0.00, tot_CHK_IGST_CESS_AMT = 0.00;
    

    List<INVOICE_DETAILS> Load_Invoice_Details = new List<INVOICE_DETAILS>();
    List<Transaction_Default2> Load_Item_Details = new List<Transaction_Default2>();
    List<Transaction_Default2> Load_Item_IGST_Details = new List<Transaction_Default2>();
    DataTable dtt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
         

        GV.DataSource = null;
        GV.DataBind();

        AppSession aps = new AppSession();
        aps.checkSession_Subfolder();
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
              DataSet d = new DataSet();
              ddlJob_No.Items.Clear();
              d=IC.GetData(ddlJobNo, "", "Jobno");
              if (d.Tables[0].Rows.Count > 0)
              {
                  ddlJob_No.DataSource = d.Tables[0];
                  ddlJob_No.DataTextField = "JOBNO_PS";
                  ddlJob_No.DataValueField = "JOBNO";
                  ddlJob_No.DataBind();
              }
                
              ddlJob_No.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, "Select"));
              

            if (Request.QueryString["chk_Stmt"] == "" || Request.QueryString["chk_Stmt"] == null)
            {
            }
            else
            {
                Check_Stmt = Request.QueryString["chk_Stmt"].ToString();
            }
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {
            }
            else
            {
                ddlJob_No.SelectedValue = Request.QueryString["jobno"].ToString();              
                Load_Job_Item_Cnt();               
                checklistTry_FontBasedNewDec03();
            }
        }
    }
    private void Load_Job_Item_Cnt()
    {
        DataSet dd = new DataSet();
        ViewState["Item_Cnt"] = "L";
        dd = IC.GetData(ddlJob_No.SelectedValue.ToString(), "", "Jobno_Item_Cnt");
        if(dd.Tables[0].Rows.Count > 0)
        {
            if (int.Parse(dd.Tables[0].Rows[0][0].ToString()) > 1001)
            {
                ViewState["Item_Cnt"] = "H";
            }
            else
            {
                ViewState["Item_Cnt"] = "L";
            }
        }
        else
        {
        ViewState["Item_Cnt"] = "L";
        }

    }


    private void checklistTry_FontBasedNewDec03()
    {
        string jobno = ddlJob_No.SelectedValue.ToString();
        string impname = "";
        double Customs_total = 0.00;
        double IGST_total = 0.00;
        double Grand_Customs_total = 0.00;
        double Grand_IGST_total = 0.00;
        double tot_ItemValue = 0.00;
        double Grand_tot_ItemValue = 0.00;
        double tot_AssValue = 0.00;
        double Grand_tot_AssValue = 0.00;
        double RevenueDeposit = 0.00;


        string head1 = "";
        string head2 = "";
        string head3 = "";
        string head4 = "-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

        string head6 = "";
        string head5_1 = "";
        string head5_2 = "";
        string head7_1 = "";
        string head7_2 = "";


        List<Transaction_Default2> Load_Item_DetailsInd = new List<Transaction_Default2>();


        DataSet ds_Gen = IC.GetData_ChkListNew(jobno, "", "General");  // general, BE date, IGM         

        if (ds_Gen.Tables[0].Rows.Count > 0)
            TRANSPORT_MODE = ds_Gen.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();

        Load_Invoice_Details.Clear();
        DataSet dsI = IC.GetData_ChkListNew(jobno, "", "INVOICE_LICENSE_RE_IMP");

        Get_ITEM_Details_new(jobno, dsI.Tables[0], dsI.Tables[1], dsI.Tables[2]);


        StringBuilder sb = new StringBuilder();



        DataSet dss = new DataSet();
        DataSet dssAss = new DataSet();


        sb.Append("<html><table>");

        if (ds_Gen.Tables[0].Rows.Count > 0)
        {


            // string custom_name = auto.Country_Master_FromClientSide_Calling(ds_Gen.Tables[0].Rows[0]["CUSTOMS_HOUSE"], "CUSTOM_HOUSE_MASTER_CUSTOM_NAME", "CUSTOMHOUSE_NAME");
            impname = ds_Gen.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();

            auto.Ename = "CUSTOM_HOUSE_MASTER_CUSTOM_NAME";
            auto.Enamesearch = ds_Gen.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
            DataSet dssCust = auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            string custhouse = "";
            custhouse = dssCust.Tables[0].Rows[0][0].ToString() + ",";

            HttpContext.Current.Session["CHECKLIST_BE_TYPE"] = ds_Gen.Tables[0].Rows[0]["BE_TYPE"].ToString();


            string IMP_EXP_TYPE = "P";
            if (ds_Gen.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString() != "")
            {
                IMP_EXP_TYPE = ds_Gen.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString().Substring(0, 1);
                if (IMP_EXP_TYPE == "O")
                    IMP_EXP_TYPE = "P";
            }



            //  ************  start of general details  *****************//

            if (Connection.COMPANYID() == "1014" || Connection.COMPANYID() == "100")
            {

                head1 = ds_Gen.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
            }
            else
            {

                head1 = HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "");
            }


            head2 = "CHECK LIST - BILL OF ENTRY FOR " + ds_Gen.Tables[0].Rows[0]["BE_TYPE"].ToString().ToUpper() + ds_Gen.Tables[0].Rows[0]["KACHHA_BE"].ToString().ToUpper();


            head3 = "Printed On: " + ds_Gen.Tables[0].Rows[0]["printdate"].ToString() + "                                               [Customs stn: " + custhouse + " " + ds_Gen.Tables[0].Rows[0]["CUSTOMS_HOUSE"] + " ] ";



            if (ds_Gen.Tables[1].Rows.Count > 0)
            {
                head5_1 = "B/E No./Date " + ds_Gen.Tables[1].Rows[0]["BE_NO_DATE"];
                head5_2 = "Job No    " + ddlJob_No.SelectedItem.Text;
            }
            else
            {
                head5_1 = "B/E No./Date ";
                head5_2 = "Job No    " + ddlJob_No.SelectedItem.Text;
            }


            head6 = "Party Ref    " + ds_Gen.Tables[0].Rows[0]["FILE_REF_NO"];

            head7_1 = "CHA Details  " + HttpContext.Current.Session["CHA_NO"].ToString();
            head7_2 = "Importer Details  " + ds_Gen.Tables[0].Rows[0]["IEC_NO"].ToString() + "  AD Code " + ds_Gen.Tables[0].Rows[0]["ADCODE"].ToString();


            sb.Append("<tr><td5@CS>" + HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "") + "</td> <td5@CS>" + ds_Gen.Tables[0].Rows[0]["IMPORTER_NAME"] + "</td> </tr>");
            sb.Append("<tr><td colspan='5'>" + HttpContext.Current.Session["CHA_NO"].ToString() + "</td> <td5@CS><b>Br.Slno :</b>" + ds_Gen.Tables[0].Rows[0]["BRANCH_NO"] + " &nbsp;&nbsp; <b>PAN:</b> " + ds_Gen.Tables[0].Rows[0]["IMP_EXP_PAN_NO"] + "</td> </tr>");
            sb.Append("<tr><td5@CS>" + HttpContext.Current.Session["CHA_ADDRESS"].ToString() + "</td> <td5@CS>" + ds_Gen.Tables[0].Rows[0]["ADDRESS1"] + "</td> </tr>");
            sb.Append("<tr><td5@CS>" + HttpContext.Current.Session["CHA_ADDRESS1"].ToString() + "</td> <td5@CS>" + ds_Gen.Tables[0].Rows[0]["ADDRESS2"] + "</td> </tr>");
            sb.Append("<tr><td5@CS>" + HttpContext.Current.Session["CHA_ADDRESS2"].ToString() + "</td> <td5@CS>" + ds_Gen.Tables[0].Rows[0]["ADDRESS3"] + "</td> </tr>");
            sb.Append("<tr><td5@CS>" + HttpContext.Current.Session["CHA_ADDRESS3"].ToString() + "</td> <td5@CS>" + ds_Gen.Tables[0].Rows[0]["ADDRESS4"] + "-" + ds_Gen.Tables[0].Rows[0]["ADDRESS5"] + "</td> </tr>");



            //  ************  end of general details  *****************//
        }

        //  ************  start of IGM details  *****************//
        if (ds_Gen.Tables[2].Rows.Count > 0 && ds_Gen.Tables[0].Rows.Count > 0)
        {
            string mrk = "";
            for (int rsp = 0; rsp < ds_Gen.Tables[2].Rows.Count; rsp++)
            {
                mrk = ds_Gen.Tables[2].Rows[rsp]["IGM_MARKSNOS"].ToString();
                string[] mn = mrk.Split('/');


                if (ds_Gen.Tables[2].Rows[rsp]["IGM_NO"].ToString() != "" && ds_Gen.Tables[2].Rows[rsp]["IGM_DATE"].ToString() != "01-01-1900")
                {
                    if (ds_Gen.Tables[0].Rows[0]["cnt"] == "0")
                    {
                        sb.Append("<tr><td2FWB@123>IGM NO</td> <td2@CS>" + ds_Gen.Tables[2].Rows[rsp]["IGM_NO"] + "  /dt." + ds_Gen.Tables[2].Rows[rsp]["IGM_DATE"] + "  </td><td><b>Inw Dt</b></td><td2FWB@123>Port of Loading</td><td3@CS>" + ds_Gen.Tables[0].Rows[0]["PORT_ORIGIN"] + "</td></tr>");
                        if (ds_Gen.Tables[2].Rows[rsp]["IGM_FLIGHT_VESSELDATE"].ToString() != "01-01-1900" && ds_Gen.Tables[2].Rows[rsp]["IGM_FLIGHT_VESSELDATE"].ToString() != "01/01/1900")
                        {
                            sb.Append("<tr><td4@CS></td><td6@CS>" + ds_Gen.Tables[2].Rows[rsp]["IGM_FLIGHT_VESSELDATE"] + "</td></tr>");
                        }
                    }
                    else
                    {
                        sb.Append("<tr><td2FWB@123>IGM NO</td> <td2@CS> " + ds_Gen.Tables[2].Rows[rsp]["IGM_NO"] + " /dt." + ds_Gen.Tables[2].Rows[rsp]["IGM_DATE"] + "  </td><td><b>Inw Dt</b></td><td2FWB@123>Port of Loading</td><td3@CS>" + ds_Gen.Tables[0].Rows[0]["PORT_ORIGIN"] + "</td></tr>");                         
                        if (ds_Gen.Tables[2].Rows[rsp]["IGM_FLIGHT_VESSELDATE"].ToString() != "01-01-1900" && ds_Gen.Tables[2].Rows[rsp]["IGM_FLIGHT_VESSELDATE"].ToString() != "01/01/1900")
                        {
                            sb.Append("<tr><td4@CS></td><td6@CS>" + ds_Gen.Tables[2].Rows[rsp]["IGM_FLIGHT_VESSELDATE"] + "</td></tr>");
                        }
                    }
                }

                sb.Append("<tr10br@123>");
                sb.Append("<tr><td2FWB@123>Cntry Of Origin</td> <td3@CS>" + ds_Gen.Tables[0].Rows[0]["COUNTRY_ORIGIN"] + "</td> <td2FWB@123>Cons.Country</td><td3@CS>" + ds_Gen.Tables[0].Rows[0]["COUNTRY_SHIPMENT"] + "</td> </tr>");
                sb.Append("<tr><td2FWB@123>MAwb No</td> <td3@CS> " + ds_Gen.Tables[2].Rows[rsp]["IGM_MAWB_MBL"] + "</td> <td2FWB@123>HAwb No</td><td3@CS>" + ds_Gen.Tables[2].Rows[rsp]["IGM_HAWB_HBLNO"] + "</td> </tr>");
                sb.Append("<tr><td2FWB@123>Date</td><td3@CS>" + ds_Gen.Tables[2].Rows[rsp]["IGM_MAWB_MBLDATE"] + "</td> <td2FWB@123>Date</td><td3@CS>" + ds_Gen.Tables[2].Rows[rsp]["IGM_HAWB_HBLDATE"] + "</td> </tr>");
                sb.Append("<tr><td2FWB@123>No Of Pkgs</td> <td3@CS> " + ds_Gen.Tables[2].Rows[rsp]["IGM_NOOFPACKAGE"] + " " + ds_Gen.Tables[2].Rows[rsp]["IGM_PACKAGETYPE"] + " </td> <td2FWB@123>Gross Weight</td><td3@CS>" + ds_Gen.Tables[2].Rows[rsp]["IGM_GROSSWEIGHT"] + " " + ds_Gen.Tables[2].Rows[rsp]["IGM_TYPEOFWEIGHT"] + "</td> </tr>");

                if (mrk != "" && mn.Length > 1)
                {
                    sb.Append("<tr><td2FWB@123>Marks & Nos </td> <td3@CS> " + mn[0].ToString() + "</td><td2FWB@123>Payment Method</td><td3@CS>" + ds_Gen.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"] + "</td>  </tr>");
                    sb.Append("<tr><td2FWB@123></td> <td8@CS> ---------------------</td></tr>");
                    sb.Append("<tr><td2FWB@123></td> <td8@CS> " + mn[1].ToString().Trim() + "</td></tr>");

                }
                else
                {
                    sb.Append("<tr><td2FWB@123>Marks & Nos </td> <td3@CS> " + ds_Gen.Tables[2].Rows[rsp]["IGM_MARKSNOS"] + "</td><td2FWB@123>Payment Method</td><td3@CS>" + ds_Gen.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"] + "</td>  </tr>");

                }
            }
        }
        //  ************  End of IGM details  *****************//


        //  ************  start of Invoice details  *****************//

        int rwno = 0;

        for (int inv = 0; inv < Load_Invoice_Details.Count; inv++)
        {

            if (inv > 0)
            {
                sb.Append("</table></html><html><table>");
            }

            sb.Append("<tr><td2FWB@123>Inv.No & Date</td><td3@CS> " + Load_Invoice_Details[inv].INVOICE_NO + " dt, " + Load_Invoice_Details[inv].INVOICE_DATE + "</td> <td5FWB@123>Supplier Details</td> </tr>");
            sb.Append("<tr><td2FWB@123>Invoice Value</td><td3@CS> " + Load_Invoice_Details[inv].INVOICE_VALUE + " &nbsp;&nbsp;<b>ToI</b> &nbsp;&nbsp;&nbsp;&nbsp; " + Load_Invoice_Details[inv].TERMS + "</td><td5@CS>" + Load_Invoice_Details[inv].SUPPLIER_NAME + "</td> </tr>");

            sb.Append("<tr><td2FWB@123>Freight</td> <td3@CS>  " + Load_Invoice_Details[inv].MIS_FREIGHT_CHARGES + "</td> <td5@CS> " + Load_Invoice_Details[inv].SUPPLIER_ADDRESS + "</td> </tr>");
            sb.Append("<tr><td2FWB@123>Insurance</td> <td3@CS>  " + Load_Invoice_Details[inv].MIS_INSURANCE_CHARGES + "</td> <td5@CS>" + Load_Invoice_Details[inv].SUPPLIER_ADDRESS1 + "</td> </tr>");
            sb.Append("<tr><td2FWB@123>SVB Ref</td> <td3@CS>  " + Load_Invoice_Details[inv].SVB_REF_NO + "</td><td5@CS>" + Load_Invoice_Details[inv].SUPPLIER_ADDRESS2 + " " + Load_Invoice_Details[inv].SUPPLIER_COUNTRY_NAME + " </td> </tr>");
            sb.Append("<tr><td2FWB@123>SVBLoad(Ass)</td><td>  " + Load_Invoice_Details[inv].SVB_ASSESABLE_RATE + "</td><td2FWB@123>Cus.House</td> <td5@CS></td> </tr>");
            sb.Append("<tr><td2FWB@123>SVBLoad(Dty)</td><td8@CS>  " + Load_Invoice_Details[inv].SVB_DUTY_RATE + "</td></tr>");
            sb.Append("<tr><td2FWB@123>HSS Load Rate</td><td> " + Load_Invoice_Details[inv].MIS_HIGHSEASALE_RATE + "</td> <td2@CS><b>Amount</b>" + Load_Invoice_Details[inv].MIS_HIGHSEASALE_CHARGES + "</td> <td2FWB@123>Green Channel</td>  <td>" + ds_Gen.Tables[0].Rows[0]["GREEN_CHANNEL"] + "</td> <tdFWB@123>Related</td>  <td>" + ds_Gen.Tables[0].Rows[0]["GREEN_CHANNEL"] + "</td> </tr>");

            sb.Append("<tr><td2FWB@123>Misc.Charges</td> <td3@CS>" + Load_Invoice_Details[inv].MIS_CHARGES + "</td> <td2FWB@123>Section 48</td> <td>" + ds_Gen.Tables[0].Rows[0]["SECTION46"] + "</td> <tdFWB@123>First Check</td>  <td>" + ds_Gen.Tables[0].Rows[0]["FIRSTCHECK"] + "</td> </tr>");
            sb.Append("<tr><td2FWB@123>Loading Charges</td> <td3@CS> " + Load_Invoice_Details[inv].MIS_LOADING_CHARGES + "</td> <td2FWB@123>Kachha B/E</td> <td3@CS>" + ds_Gen.Tables[0].Rows[0]["KACHHA_BE"].ToString().ToUpper() + "</td>   </tr>");
            sb.Append("<tr><td2FWB@123>Discount Rate</td> <td> " + Load_Invoice_Details[inv].MIS_LOADING_CHARGES + "</td> <td2FWB@123>Amount</td> <td5@CS>" + ds_Gen.Tables[0].Rows[0]["KACHHA_BE"].ToString().ToUpper() + "</td>   </tr>");
            sb.Append("<tr><td2FWB@123>Exchange Rate</td><td3@CS>" + Load_Invoice_Details[inv].INVOICE_EXRATE + "</td> <td5FWB@123>ITEM DETAILS</td> </tr>");


            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>Item-HeadStarts@Rowno");
            sb.Append("<trFWB@123><td>Sl No</td> <td2@CS>RITC</td><td7@CS>Description</td></tr>");
            sb.Append("<trFWB@123><td3@CS>QTY</td> <td2@CS>Unit Price</td> <td>CTH</td><td>Cus.Notn</td><td colspan='2' style='text-align:center'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cus.Duty.Rate</td><td>BCDAmt(Rs)</td></tr>");
            sb.Append("<trFWB@123><td3@CS>Unit</td> <td2@CS>Assessable Value</td><td>CETH</td><td>Exc.Notn</td><td colspan='2' style='text-align:center'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exc.Duty.Rate</td><td>CVDAmt(Rs)</td></tr>");

            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

            Load_Item_DetailsInd.Clear();

            Load_Item_DetailsInd = Load_Item_Details.Where(p => p.INVOICE_SLNO == Load_Invoice_Details[inv].INVOICE_SLNO).ToList();

            if (Load_Item_DetailsInd.Count > 0)
            {
                //  ************  start of Individual Item details  *****************//
                for (int itm = 0; itm < Load_Item_DetailsInd.Count; itm++)
                {

                    if (Load_Item_DetailsInd[itm].INVOICE_NO.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "*@ItemFirstLine#<tr><td colspan='10'><br/></td> </tr> Item-contentStarts@Rowno@ItemFirstLine");

                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td>" + Load_Item_DetailsInd[itm].ITEM_SLNO + "</td> <td2@CS>" + Load_Item_DetailsInd[itm].CTH_NO + "</td> <td7@CS>" + Load_Item_DetailsInd[itm].ITEM_DESCRIPTION + "</td> </tr> Item-contentStarts@Rowno");

                    }
                    if (Load_Item_DetailsInd[itm].INVOICE_NO.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td3@CS>" + Load_Item_DetailsInd[itm].ITEM_QTY + "</td> <td2@CS>" + Load_Item_DetailsInd[itm].ITEM_UNIT_PRICE + "</td> <td2@CS>" + Load_Item_DetailsInd[itm].PRODUCT_CTH + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_BCD_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_BCD_RATE + "</td><tdSAR@123>" + Load_Item_DetailsInd[itm].BASIC_DUTY_TOTAL + " </td></tr> Item-contentStarts@Rowno");

                    }

                    if (Load_Item_DetailsInd[itm].CTH_SPL_AMT.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td>Qty</td><td colspan='2'>" + Load_Item_DetailsInd[itm].CTH_QTY1 + "</td> <td colspan='7'>" + Load_Item_DetailsInd[itm].CTH_SPL_AMT + "</td> </tr> Item-contentStarts@Rowno");

                    }
                    if (Load_Item_DetailsInd[itm].CTH_SAFEGUARD_RATE.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td colspan='4'>Customs(CVD)</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_SAFEGUARD_NOTN + "</td> <td>" + Load_Item_DetailsInd[itm].CTH_SAFEGUARD_RATE + "</td><td colspan='4'>" + Load_Item_DetailsInd[itm].SAFE_GUARD_TOTAL + "</td> </tr> Item-contentStarts@Rowno");
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td colspan='10'>" + Load_Item_DetailsInd[itm].SCHEME_NOTN + "</td>  </tr> Item-contentStarts@Rowno");

                    }
                    //if (Load_Item_DetailsInd[itm].SCHEME_CODE.ToString() != "" && (!String.IsNullOrEmpty(Load_Item_DetailsInd[itm].EOU_MERIT_BASIC_DUTY.ToString()) && !String.IsNullOrEmpty(Load_Item_DetailsInd[itm].EOU_MERIT_CVD.ToString() )))
                    //{
                    //    if ((Load_Item_DetailsInd[itm].EOU_MERIT_BASIC_DUTY.ToString() != "" || Load_Item_DetailsInd[itm].EOU_MERIT_CVD.ToString() != ""))
                    //    {
                    //        rwno = rwno + 1;
                    //        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td colspan='7'>" + Load_Item_DetailsInd[itm].EOU_MERIT_BASIC_DUTY + "</td><td3@CS>" + Load_Item_DetailsInd[itm].EOU_MERIT_CVD + "</td>  </tr> Item-contentStarts@Rowno");
                    //    }                         
                    //}
                    if (Load_Item_DetailsInd[itm].ANTI_DUMPING_NOTN.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td colspan='10'>" + Load_Item_DetailsInd[itm].ANTI_DUMPING_NOTN + "</td>  </tr> Item-contentStarts@Rowno");

                    }

                    if (Load_Item_DetailsInd[itm].PRODUCT_SAPTA_NOTN.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td5SAR@123>SAPTA Exemption:</td><td></td><td>" + Load_Item_DetailsInd[itm].PRODUCT_SAPTA_NOTN + "</td> ");
                        if (Load_Item_DetailsInd[itm].PRODUCT_SAPTA_SLNO.Split(new char[0]).Length > 0)
                            sb.Append("<td>" + Load_Item_DetailsInd[itm].PRODUCT_SAPTA_SLNO.Split(new char[0])[0] + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_SAPTA_RATE + "%</td><td></td> </tr> Item-contentStarts@Rowno");
                        else
                            sb.Append("<td>" + Load_Item_DetailsInd[itm].PRODUCT_SAPTA_SLNO + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_SAPTA_RATE + "%</td><td></td> </tr> Item-contentStarts@Rowno");
                    }

                    if (Load_Item_DetailsInd[itm].PRODUCT_TARIFF_NOTN.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td3@CS>Tarf Duty Itm : </td><td>" + Load_Item_DetailsInd[itm].PRODUCT_TARIFF_QTY + "</td> <td>" + Load_Item_DetailsInd[itm].PRODUCT_TARIFF_NOTN + "</td><td colspan='5'>" + Load_Item_DetailsInd[itm].PRODUCT_TARIFF_SLNO + "</td> </tr> Item-contentStarts@Rowno");

                    }
                    if (Load_Item_DetailsInd[itm].PRODUCT_OTHER_DUTY_NOTN.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td colspan='4'>Other CVD Duty :</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_OTHER_DUTY_NOTN + "</td> <td>" + Load_Item_DetailsInd[itm].PRODUCT_OTHER_DUTY_RATE + "</td><td colspan='4'>" + Load_Item_DetailsInd[itm].PRODUCT_OTHER_DUTY_TOTAL + "</td> </tr> Item-contentStarts@Rowno");

                    }
                    if (Load_Item_DetailsInd[itm].INVOICE_NO.ToString() != "")
                    //sb.Append("<tr><td>" + Load_Item_DetailsInd[itm].ITEM_QTY_CODE + "</td> <td colspan='2'>" + String.Format("{0:0.00}", Math.Round(Convert.ToDouble(Load_Item_DetailsInd[itm].ASSESABLE_VALUE), 2)) + "</td><td colspan='2'>" + Load_Item_DetailsInd[itm].END_USE_OF_ITEM + "</td><td colspan='2'>" + Load_Item_DetailsInd[itm].PRODUCT_CETH + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_CVD_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_CVD_RATE + "</td><tdSAR@123>" + Load_Item_DetailsInd[itm].CVD_TOTAL + "</td> </tr>");
                    ////********* Ass value *********////
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td3@CS>" + Load_Item_DetailsInd[itm].ITEM_QTY_CODE + "</td> <td2@CS>" + String.Format("{0:0.00}", Math.Round(Convert.ToDouble(Load_Item_DetailsInd[itm].ASSESABLE_VALUE), 2)) + "</td><td colspan='2'>" + Load_Item_DetailsInd[itm].PRODUCT_CETH + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_CVD_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_CVD_RATE + "</td><tdSAR@123>" + Load_Item_DetailsInd[itm].CVD_TOTAL + "</td> </tr> Item-contentStarts@Rowno@InvNo=" + Load_Invoice_Details[inv].INVOICE_NO + "@ItmNo=" + Load_Item_DetailsInd[itm].ITEM_SLNO + "@AssVal=" + Math.Round(Convert.ToDouble(Load_Item_DetailsInd[itm].ASSESABLE_VALUE), 2) + "@");

                    }
                    if (Load_Item_DetailsInd[itm].CETH_SPL_AMT.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td colspan='10'>" + Load_Item_DetailsInd[itm].CETH_SPL_AMT + "</td>  </tr> Item-contentStarts@Rowno");

                    }
                    rwno = rwno + 1;
                    sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td3SAR@123>Social Welfare Surcharge:</td><td4@CS></td>  <td>" + Load_Item_DetailsInd[itm].SOCIAL_WELFARE_NOTN_SLNO + "</td><td>" + Load_Item_DetailsInd[itm].SOCIAL_WELFARE_RATE + "</td><tdSAR@123>" + Load_Item_DetailsInd[itm].TOTAL_SOCIAL_WELFARE + "</td> </tr> Item-contentStarts@Rowno");

                    if (Load_Item_DetailsInd[itm].PRODUCT_ADDL_SHEII_RATE.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td colspan='4'>Special Excise Duty (Sch2)</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_ADDL_SHEII_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_ADDL_SHEII_RATE + "</td><td colspan='4'>" + Load_Item_DetailsInd[itm].SCHED11_TOTAL + "</td> </tr> Item-contentStarts@Rowno");

                    }
                    if (Load_Item_DetailsInd[itm].PRODUCT_ADDL_GSI_RATE.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td colspan='4'>Aduty (SIA) Duty</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_ADDL_GSI_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_ADDL_GSI_RATE + "</td><td colspan='4'>" + Load_Item_DetailsInd[itm].GSI_TOTAL + "</td> </tr> Item-contentStarts@Rowno");

                    }
                    if (Load_Item_DetailsInd[itm].PRODUCT_ADDL_TTA_RATE.ToString() != "")
                    {
                        rwno = rwno + 1;
                        sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td colspan='4'>Aduty (TTA) Duty</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_ADDL_TTA_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].PRODUCT_ADDL_TTA_RATE + "</td><td colspan='4'>" + Load_Item_DetailsInd[itm].TTA_TOTAL + "</td> </tr> Item-contentStarts@Rowno");
                    }

                    rwno = rwno + 1;
                    sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td3SAR@123>IGST Duty:</td><td2@CS>" + Load_Item_DetailsInd[itm].IGST_LEVY_NOTN + "</td><td2@CS>" + Load_Item_DetailsInd[itm].IGST_LEVY_SLNO + "</td><td>" + Load_Item_DetailsInd[itm].IGST_LEVY_EXCEPTION_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].IGST_LEVY_RATE + "</td><tdSAR@123>" + Load_Item_DetailsInd[itm].IGST_LEVY_TOTAL + "</td> </tr> Item-contentStarts@Rowno=@InvNo=" + Load_Invoice_Details[inv].INVOICE_NO + "@ItmNo=" + Load_Item_DetailsInd[itm].ITEM_SLNO + "@IGSTVal=" + Math.Round(Convert.ToDouble(Load_Item_DetailsInd[itm].BASIC_DUTY_TOTAL) + Convert.ToDouble(Load_Item_DetailsInd[itm].CVD_TOTAL) + Convert.ToDouble(Load_Item_DetailsInd[itm].TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(Load_Item_DetailsInd[itm].IGST_LEVY_TOTAL) + Convert.ToDouble(Load_Item_DetailsInd[itm].IGST_LEVY_COMPENSATION_CESS_TOTAL), 2) + "@");
                    //sb.Append("<tr><td3SAR@123>GST Compensation Cess:</td><td2@CS></td><td>" + Load_Item_DetailsInd[itm].IGST_LEVY_COMPENSATION_CESS_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].IGST_LEVY_COMPENSATION_CESS_SLNO + "</td><td>" + Load_Item_DetailsInd[itm].IGST_LEVY_EXCEPTION_CC_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].IGST_LEVY_COMPENSATION_CESS_RATE + "</td><tdSAR@123>" + Load_Item_DetailsInd[itm].IGST_LEVY_COMPENSATION_CESS_TOTAL + "</td> </tr>");
                    rwno = rwno + 1;
                    sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "<tr><td3SAR@123>GST Compensation Cess:</td><td2@CS></td><td>" + Load_Item_DetailsInd[itm].IGST_LEVY_COMPENSATION_CESS_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].IGST_LEVY_COMPENSATION_CESS_SLNO + "</td><td style='text-align:center'>" + Load_Item_DetailsInd[itm].IGST_LEVY_EXCEPTION_CC_NOTN + "</td><td>" + Load_Item_DetailsInd[itm].IGST_LEVY_COMPENSATION_CESS_RATE + "</td><tdSAR@123>" + Load_Item_DetailsInd[itm].IGST_LEVY_COMPENSATION_CESS_TOTAL + "</td> </tr> Item-contentStarts@Rowno");
                   
                    rwno = 0;
                }

                //  ************  End of Individual Item details  *****************//



                tot_ItemValue = Math.Round(Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.ITEM_TOTAL)), 2);
                Grand_tot_ItemValue = Grand_tot_ItemValue + tot_ItemValue;

                tot_AssValue = Math.Round(Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.ASSESABLE_VALUE)), 2);
                Grand_tot_AssValue = Grand_tot_AssValue + tot_AssValue;


                IGST_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.BASIC_DUTY_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.CVD_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.TOTAL_SOCIAL_WELFARE)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.IGST_LEVY_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.IGST_LEVY_COMPENSATION_CESS_TOTAL));

                IGST_total = Math.Round(IGST_total, 2);
                Grand_IGST_total = Grand_IGST_total + IGST_total;

                //if (Load_Item_DetailsInd.Count <= 7)
                //{
                //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr> Item-contentStarts@Rowno");
                //    sb.Append("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", tot_AssValue) + " </td> <td4FWB@123>Page Total</td><tdSAR@123>" + String.Format("{0:0.00}", IGST_total) + "</td></tr> Item-contentStarts@Rowno");
                //    sb.Append("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Grand_tot_AssValue) + " </td> <td4FWB@123>BE Total</td><tdSAR@123>" + String.Format("{0:0.00}", Grand_IGST_total) + "</td></tr> Item-contentStarts@Rowno");
                //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                //}

                Customs_total = 0.00; IGST_total = 0.00; tot_ItemValue = 0.00; tot_AssValue = 0.00;




            }

        }

        if (Load_Item_Details.Count > 0)
        {
            if (Load_Item_Details[0].REVENUEDEPOSIT_RATE != "")
            {
                if ((Load_Item_Details[0].REVENUEDEPOSIT_RATE != "0.00") && (Load_Item_Details[0].REVENUEDEPOSIT_RATE != "0"))
                {
                    //RevenueDeposit
                    if (Load_Item_Details[0].REVENUEDEPOSIT_ON == "0")
                        RevenueDeposit = Grand_tot_ItemValue * Convert.ToDouble(Load_Item_Details[0].REVENUEDEPOSIT_RATE) / 100;
                    else if (Load_Item_Details[0].REVENUEDEPOSIT_ON == "A")
                        RevenueDeposit = Grand_tot_AssValue * Convert.ToDouble(Load_Item_Details[0].REVENUEDEPOSIT_RATE) / 100;
                    else if (Load_Item_Details[0].REVENUEDEPOSIT_ON == "B")
                    {
                        sb.Append("<tr><td colspan='9' style='text-align:right'>Add Revenue Deposit @ " + Load_Item_Details[0].REVENUEDEPOSIT_RATE + "</td><td>:" + RevenueDeposit + "</td></tr>");

                    }
                }
            }
        }



        // changed as per new format
        // sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
        sb.Append("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Grand_tot_AssValue) + " </td> <td4FWB@123>BE Gross Total </td><tdSAR@123>" + String.Format("{0:0.00}", Grand_IGST_total) + "</td></tr> Item-contentStarts@Rowno");
        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr> Item-contentStarts@Rowno");

        double duty = Math.Round((Grand_Customs_total + Grand_IGST_total + RevenueDeposit), 2);

        DataSet DssConvNo = IC.GetData_ChkListNew(Convert.ToInt64(duty).ToString(), "", "ConvNumberToWord");  // convert number to word 


        if (DssConvNo.Tables[0].Rows.Count > 0)
        {
            sb.Append("<tr><td10FWB@123>Duty Payable</td></tr>");
            sb.Append("<tr><td10@CS>Rs. " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DssConvNo.Tables[0].Rows[0][0].ToString()) + " Only</td></tr>");
        }


        //  ************  start of HSS details  *****************//
        if (ds_Gen.Tables[0].Rows.Count > 0 && ds_Gen.Tables[0].Rows[0]["HIGH_SEA_IEC"] != "")
        {
            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
            sb.Append("<tr><td10@CS>HSS Orig. Importer  " + ds_Gen.Tables[0].Rows[0]["HIGH_SEA_IEC"] + " [" + ds_Gen.Tables[0].Rows[0]["PRECEDING_LEVEL"] + "] M/S " + ds_Gen.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"] + " </td></tr>");           
        }
        //  ************  End of HSS details  *****************//


        //  ************  start of License details  *****************//
        Transaction Transact = new Transaction();
        Transact.JOBNO = jobno;
        Transact.INVOICE_SLNO = Convert.ToString(INVOICE_SLNO);
        Transact.ITEM_SLNO = ITEM_SLNO;
        Transact.LICENSE_ID = "";
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.Ename = "Get_Update_Debitamt_License_Details";
        DataSet ds_License = new DataSet();
        ds_License = Transact.RetrieveAll_License_Details();
        if (ds_License.Tables[0].Rows.Count > 0)
        {
            License_Details LICENSE = new License_Details();
            List<License_Details> ListLic = LICENSE.Get_LICENCE_DETAILS(ds_License.Tables[0], TOTAL_DEBIT_DUTY_FINAL);

            if (ListLic.Count > 0)
            {

                sb.Append("<tr style='text-align:center'><td10FWB@123><u>LICENSE DETAILS</u></td></tr>");
                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                sb.Append("<trFWB@123><td>Sl.No</td><td>Reg.No</td><td>Reg.Date</td><td>Scheme</td><td>DebitValue</td><td>Duty</td><td>QTY</td><td>INV/ITSL</td><td>L.Sno</td><td>Port</td></tr>");
                sb.Append("<trFWB@123><td></td><td>LIC.No</td><td colspan='4'>LIC.Date</td><td colspan='4'>Unit </td></tr>");
                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                for (int rsp = 0; rsp < ListLic.Count; rsp++)
                {
                    sb.Append("<tr><td>" + ListLic[rsp].LICENSE_SLNO + "</td><td>" + ListLic[rsp].REGISTRATION_NO + " </td><td>" + ListLic[rsp].REGISTRATION_DATE + "</td>");
                    sb.Append("<td>" + ListLic[rsp].SCHEME_CODE + " </td><td> " + ListLic[rsp].DEBIT_AMT + "</td><td>" + ListLic[rsp].ENTRY_DEBIT_DUTY + " </td>");
                    sb.Append("<td>" + ListLic[rsp].DEBIT_QTY + "</td> <td>" + ListLic[rsp].INVOICE_SLNO + "</td><td>" + ListLic[rsp].LICENSE_ITEM_NO + " </td><td>" + ListLic[rsp].PORT_OF_LICENSE + "</td>  </tr> License-contentStarts@Rowno");
                    sb.Append("<tr><td></td><td>" + ListLic[rsp].LICENSE_NO + "</td><td colspan='4'>" + ListLic[rsp].LICENSE_DATE + "</td> <td colspan='4'>" + ListLic[rsp].UNIT_QTY + "</td> </tr> License-contentStarts@Rowno-2ndLine");

                }

                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                sb.Append("<tr> <td3@CS>Total Debit value & Duty :</td><td2@CS>" + String.Format("{0:0.00}", ListLic.Sum(item => Convert.ToDouble(item.DEBIT_AMT))) + "</td> <td>" + String.Format("{0:0.00}", ListLic.Sum(item => Convert.ToDouble(item.DEBIT_DUTY))) + "</td> <td4@CS></td></tr>");
                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

            }
        }
        //  ************  End of License details  *****************//


        DataSet ds_comn = IC.GetData_ChkListNew(jobno, "", "commondetails");  // ds_comn contains RSP , Bond , certificate, container , GSTIN Details   , reimport  details

        //  ************  start of Container details  *****************//

        if (ds_comn.Tables[3].Rows.Count > 0)
        {
            sb.Append("<tr10br@123>");

            sb.Append("<tr style='text-align:center'><td10FWB@123><u>Container Details</u></td></tr>");
           // sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
            sb.Append("<trFWB@123><td>SL</td><td colspan='2'>Container No</td><td colspan='2'>Seal No</td> <td>Type</td><td colspan='2'>Size</td><td colspan='2'>Truck No</td></tr>");
            //sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
            for (int rsp = 0; rsp < ds_comn.Tables[3].Rows.Count; rsp++)
            {
                sb.Append("<tr><td>" + ds_comn.Tables[3].Rows[rsp]["CONTAINER_IGM_SLNO"] + "</td><td colspan='2'>" + ds_comn.Tables[3].Rows[rsp]["CONTAINER_NO"] + "</td><td colspan='2'>" + ds_comn.Tables[3].Rows[rsp]["SEAL_NO"] + "</td><td>" + ds_comn.Tables[3].Rows[rsp]["FCL_OR_LCL"] + "</td><td colspan='2'>" + ds_comn.Tables[3].Rows[rsp]["TYPE"] + "</td><td colspan='2'>" + ds_comn.Tables[3].Rows[rsp]["TRUCK_NO"] + "</td></tr>");
            }
        }
        //  ************  End of Container details  *****************//


        //  ************  start of GSTIN details  *****************//
        if (ds_comn.Tables[4].Rows.Count > 0)
        {

            sb.Append("<tr10br@123>");
            sb.Append("<tr style='text-align:center'><td10FWB@123><u>GSTIN Details</u></td></tr>");
            sb.Append("<trFWB@123><td2@CS>Document No</td><td2@CS>Type</td><td2@CS>State Code/ Name</td> <td2@CS>IGST Amt</td><td2@CS>GST Cess Amt</td></tr>");

            for (int rsp = 0; rsp < ds_comn.Tables[4].Rows.Count; rsp++)
            {
                sb.Append("<tr><td2@CS>" + ds_comn.Tables[4].Rows[rsp]["COMMERCIAL_TAX_REGISTRATION_NO"] + "</td><td2@CS>" + ds_comn.Tables[4].Rows[rsp]["COMMERCIAL_TAX_TYPE"] + "</td><td2@CS>" + ds_comn.Tables[4].Rows[rsp]["COMMERCIAL_TAX_STATECODE_NEW"] + "</td><td2@CS>" + ds_comn.Tables[4].Rows[rsp]["IGST_IGST_LEVY_AMOUNT"] + "</td><td2@CS>" + ds_comn.Tables[4].Rows[rsp]["IGST_COMPENSATION_CC_AMOUNT"] + "</td></tr> GSTIN-contentStarts@Rowno");

            }

        }
        //  ************  End of GSTIN details  *****************//

        //  ************  start of Single Window details  *****************//
        DataSet ds_SW = new DataSet();
        ds_SW = IC.GetData_ChkListNew(jobno, "", "SINGLE_WINDOW");

        if (ds_SW.Tables[0].Rows.Count > 0)
        {
            sb.Append("<tr10br@123>");
            sb.Append("<tr style='text-align:center'><td10FWB@123><u> SINGLE WINDOW - Additional Product Information</u></td></tr>");
            sb.Append("<trFWB@123><td>InvNo</td><td>ItemNo</td> <td>Info Type</td><td2@CS>Info Qualifier</td><td2@CS>Code/Information</td><td2@CS>Info Text</td><td>MSR-UQC</td></tr>");           
            for (int rsp = 0; rsp < ds_SW.Tables[0].Rows.Count; rsp++)
            {
                sb.Append("<tr><td>" + ds_SW.Tables[0].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds_SW.Tables[0].Rows[rsp]["ITEM_SLNO"] + "</td> <td>" + ds_SW.Tables[0].Rows[rsp]["INFO_TYPE"] + "</td>");
                sb.Append("<td2@CS>" + ds_SW.Tables[0].Rows[rsp]["INFO_QUALIFIER"] + "</td><td2@CS>" + ds_SW.Tables[0].Rows[rsp]["INFO_CODE"] + "</td> <td2@CS>" + ds_SW.Tables[0].Rows[rsp]["INFO_TEXT"] + "</td> <td>" + ds_SW.Tables[0].Rows[rsp]["INFO_MSR"] + "-" + ds_SW.Tables[0].Rows[rsp]["INFO_UQC"] + " </td></tr>SingWindAddPrd-contentStarts@Rowno");
            }
        }

        //if (ds_SW.Tables[1].Rows.Count > 0)
        //{
        //    sb.Append("<tr><td colspan='10'><br/></td></tr>");
        //    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - CONSTITUENT DETAILS</td></tr>");
        //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
        //    sb.Append("<trFWB@123><td>InvSlNo</td><td>ItemSlNo</td> <td colspan='2'>Cons.SrNo</td><td colspan='2'>Cons.Element Name</td><td>Percentage</td><td>Yield%</td><td colspan='2'>Active(Y/N)</td></tr>");
        //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
        //    for (int rsp = 0; rsp < ds_SW.Tables[1].Rows.Count; rsp++)
        //    {
        //        sb.Append("<tr><td>" + ds_SW.Tables[1].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds_SW.Tables[1].Rows[rsp]["ITEM_SLNO"] + "</td> <td colspan='2'>" + ds_SW.Tables[1].Rows[rsp]["CONSTITUENT_SRNO"] + "</td><td colspan='2'>" + ds_SW.Tables[1].Rows[rsp]["CONSTITUENT_ELEMENT_NAME"] + "</td><td>" + ds_SW.Tables[1].Rows[rsp]["CONSTITUENT_ELEMENT_CODE"] + "</td> <td>" + ds_SW.Tables[1].Rows[rsp]["CONSTITUENT_PERCENTAGE"] + "</td> <td <td colspan='2'>" + ds_SW.Tables[1].Rows[rsp]["CONSTITUENT_YIELD_PERCENTAGE"] + "-" + ds_SW.Tables[1].Rows[rsp]["ACTIVE_INGREDIENT"] + " </td></tr>");
        //    }
        //}

        //if (ds_SW.Tables[2].Rows.Count > 0)
        //{
        //    sb.Append("<tr><td colspan='10'><br/></td></tr>");
        //    sb.Append("<tr style='text-align:center'><td10FWB@123> SINGLE WINDOW - PRODUCTION DETAILS</td></tr>");
        //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
        //    sb.Append("<trFWB@123><td>InvSlNo</td><td>ItemSlNo</td> <td>Batch Identifier</td><td>Batch Qty</td><td>Manufacture Dt</td><td>Expiry Dt</td><td colspan='4'>BestBefore Dt</td></tr>");
        //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
        //    for (int rsp = 0; rsp < ds_SW.Tables[2].Rows.Count; rsp++)
        //    {
        //        sb.Append("<tr><td>" + ds_SW.Tables[2].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds_SW.Tables[2].Rows[rsp]["ITEM_SLNO"] + "</td> <td>" + ds_SW.Tables[2].Rows[rsp]["PRODUCTION_BATCH_IDENTIFIER"] + "</td><td>" + ds_SW.Tables[2].Rows[rsp]["PRODUCTION_BATCH_QUANTITY"] + "</td><td>" + ds_SW.Tables[2].Rows[rsp]["DATE_OF_MANUFACTURING"] + "</td> <td>" + ds_SW.Tables[2].Rows[rsp]["DATE_OF_EXPIRY"] + "</td> <td colspan='4'>" + ds_SW.Tables[2].Rows[rsp]["BEST_BEFORE"] + "-" + ds_SW.Tables[2].Rows[rsp]["ACTIVE_INGREDIENT"] + " </td></tr>");
        //    }
        //}
        //if (ds_SW.Tables[3].Rows.Count > 0)
        //{
        //    sb.Append("<tr><td colspan='10'><br/></td></tr>");
        //    sb.Append("<tr style='text-align:center'><td10FWB@123> SINGLE WINDOW - CONTROL DETAILS</td></tr>");
        //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
        //    sb.Append("<trFWB@123><td>InvSlNo</td><td>ItemSlNo</td> <td>Control Type Code</td><td>Control Location</td><td>Start Date</td><td>End Date</td><td colspan='4'>Result Code</td></tr>");
        //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
        //    for (int rsp = 0; rsp < ds_SW.Tables[3].Rows.Count; rsp++)
        //    {
        //        sb.Append("<tr><td>" + ds_SW.Tables[3].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds_SW.Tables[3].Rows[rsp]["ITEM_SLNO"] + "</td> <td>" + ds_SW.Tables[3].Rows[rsp]["CONTROL_TYPE_CODE"] + "</td><td>" + ds_SW.Tables[3].Rows[rsp]["CONTROL_LOCATION"] + "</td><td>" + ds_SW.Tables[3].Rows[rsp]["CONTROL_START_DATE"] + "</td> <td>" + ds_SW.Tables[3].Rows[rsp]["CONTROL_END_DATE"] + "</td> <td colspan='4'>" + ds_SW.Tables[3].Rows[rsp]["CONTROL_RESULT_CODE"] + "</td></tr>");
        //    }
        //}

        //if (ds_SW.Tables[4].Rows.Count > 0)
        //{
        //    sb.Append("<tr10br@123>");
        //    sb.Append("<tr style='text-align:center'><td10FWB@123><u> SINGLE WINDOW - Statement Details</u></td></tr>");
        //    sb.Append("<trFWB@123><td>InvNo</td><td2@CS>ItemNo</td> <td2@CS>Stmt Type</td><td5@CS>Stmt Code</td></tr>");            
        //    for (int rsp = 0; rsp < ds_SW.Tables[4].Rows.Count; rsp++)
        //    {
        //        sb.Append("<tr><td>" + ds_SW.Tables[4].Rows[rsp]["INVOICE_SLNO"] + "</td><td2@CS>" + ds_SW.Tables[4].Rows[rsp]["ITEM_SLNO"] + "</td> <td2@CS>" + ds_SW.Tables[4].Rows[rsp]["STMT_TYPE"] + "</td><td5@CS>" + ds_SW.Tables[4].Rows[rsp]["STMT_CODE"] + "</td></tr>SingWindstatement-contentStarts@Rowno");
        //    }
        //}

        //if (ds_SW.Tables[5].Rows.Count > 0)
        //{
        //    sb.Append("<tr><td colspan='10'><br/></td></tr>");
        //    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - SUPPORTING DOCUMENTS DETAILS</td></tr>");
        //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
        //    sb.Append("<trFWB@123><td>InvSlNo</td><td>ItemSlNo</td><td>Decl Type</td><td>Level Wise</td><td colspan='2'>Place of Issue</td><td colspan='4'>File Type </td></tr>");
        //    sb.Append("<trFWB@123><td colspan='2'>Image Ref Number</td><td colspan='2'>Doc type Code</td><td colspan='2'>Doc reference number</td><td colspan='2'>Doc IssueDate</td><td colspan='2'>Doc Expiry Date</td></tr>");
        //    sb.Append("<trFWB@123><td colspan='6'>Document Issuing Party Code</td><td colspan='4'>Document Beneficiary Party Code</td> </tr>");
        //    sb.Append("<trFWB@123><td colspan='6'>Document Issuing Party Name</td><td colspan='4'>Document Beneficiary Party Name</td> </tr>");
        //    sb.Append("<trFWB@123><td colspan='6'>Document Issuing Party Name Address1</td><td colspan='4'>Document Beneficiary Party Name Address1</td> </tr>");
        //    sb.Append("<trFWB@123><td colspan='6'>Document Issuing Party Name Address2</td><td colspan='4'>Document Beneficiary Party Name Address2</td> </tr>");
        //    sb.Append("<trFWB@123><td colspan='6'>Document Issuing Party City</td><td colspan='4'>Document Beneficiary Party City</td> </tr>");
        //    sb.Append("<trFWB@123><td colspan='6'>Document Issuing Party PIN</td><td colspan='4'>Document Beneficiary Party PIN</td> </tr>");
        //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
        //    for (int rsp = 0; rsp < ds_SW.Tables[5].Rows.Count; rsp++)
        //    {
        //        sb.Append("<tr><td>" + ds_SW.Tables[5].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds_SW.Tables[5].Rows[rsp]["ITEM_SLNO"] + "</td> <td>" + ds_SW.Tables[5].Rows[rsp]["DECLARATION_TYPE"] + "</td><td>" + ds_SW.Tables[5].Rows[rsp]["SELECT_TYPE"] + "</td><td colspan='2'>" + ds_SW.Tables[5].Rows[rsp]["PLACE_OF_ISSUE"] + "</td><td colspan='4'>" + ds_SW.Tables[5].Rows[rsp]["FILE_TYPE"] + "</td></tr>");
        //        sb.Append("<tr><td colspan='2'>" + ds_SW.Tables[5].Rows[rsp]["IMAGE_REF_NUMBER"] + "</td><td colspan='2'>" + ds_SW.Tables[5].Rows[rsp]["DOC_TYPE_CODE"] + "</td> <td colspan='2'>" + ds_SW.Tables[5].Rows[rsp]["DOC_REF_NUMBER"] + "</td><td colspan='2'>" + ds_SW.Tables[5].Rows[rsp]["DOC_ISSUE_DATE"] + "</td><td colspan='2'>" + ds_SW.Tables[5].Rows[rsp]["DOC_EXPIRY_DATE"] + "</td></tr>");
        //        sb.Append("<tr><td colspan='6'>" + ds_SW.Tables[5].Rows[rsp]["DOC_ISSUING_PARTY_CODE"] + "</td><td colspan='4'>" + ds_SW.Tables[5].Rows[rsp]["BENEFICIARY_PARTY_CODE"] + "</td></tr>");
        //        sb.Append("<tr><td colspan='6'>" + ds_SW.Tables[5].Rows[rsp]["DOC_ISSUING_PARTY_NAME"] + "</td><td colspan='4'>" + ds_SW.Tables[5].Rows[rsp]["BENEFICIARY_PARTY_NAME"] + "</td></tr>");
        //        sb.Append("<tr><td colspan='6'>" + ds_SW.Tables[5].Rows[rsp]["DOC_ISSUING_PARTY_NAME_ADD1"] + "</td><td colspan='4'>" + ds_SW.Tables[5].Rows[rsp]["BENEFICIARY_PARTY_ADDRESS1"] + "</td></tr>");
        //        sb.Append("<tr><td colspan='6'>" + ds_SW.Tables[5].Rows[rsp]["DOC_ISSUING_PARTY_NAME_ADD2"] + "</td><td colspan='4'>" + ds_SW.Tables[5].Rows[rsp]["BENEFICIARY_PARTY_ADDRESS2"] + "</td></tr>");
        //        sb.Append("<tr><td colspan='6'>" + ds_SW.Tables[5].Rows[rsp]["DOC_ISSUING_PARTY_CITY"] + "</td><td colspan='4'>" + ds_SW.Tables[5].Rows[rsp]["BENEFICIARY_PARTY_CITY"] + "</td></tr>");
        //        sb.Append("<tr><td colspan='6'>" + ds_SW.Tables[5].Rows[rsp]["DOC_ISSUING_PARTY_PIN"] + "</td><td colspan='4'>" + ds_SW.Tables[5].Rows[rsp]["BENEFICIARY_PARTY_PIN"] + "</td></tr>");
        //    }
        //    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
        //}

        //  ************  End of Single Window details  *****************//



        //  ************  start of REIMPORT details  *****************//
        if (ds_comn.Tables[5].Rows.Count > 0)
        {

            sb.Append("<tr10br@123>");
            sb.Append("<tr style='text-align:center'><td10FWB@123><u>RE-IMPORT DETAILS</u></td></tr>");

            sb.Append("<trFWB@123><td>InvNo</td><td>ItmNo</td> <td>Notn No</td><td>SB No</td><td colspan='2'>SB Inv Sr.No.</td><td colspan='2'>Exp Freight</td><td colspan='2'>Custom Duty</td></tr>");
            sb.Append("<trFWB@123><td colspan='2'></td><td>Notn SNo</td><td>SB Dt</td><td colspan='2'>Exp Port</td><td colspan='2'>Exp Insurance</td><td colspan='2'>Excise Duty</td></tr>");
            //sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
            sb.Append("<tr10br@123>");
            for (int rsp = 0; rsp < ds_comn.Tables[5].Rows.Count; rsp++)
            {
                sb.Append("<tr><td>" + ds_comn.Tables[5].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds_comn.Tables[5].Rows[rsp]["ITEM_SLNO"] + "</td><td>" + ds_comn.Tables[5].Rows[rsp]["NOTN_NO"] + "</td><td>" + ds_comn.Tables[5].Rows[rsp]["SB_NO"] + "</td><td colspan='2'>" + ds_comn.Tables[5].Rows[rsp]["SB_INVOICE_NO"] + "</td><td colspan='2'>" + ds_comn.Tables[5].Rows[rsp]["EXPORT_FREIGHT"] + "</td><td colspan='2'>" + ds_comn.Tables[5].Rows[rsp]["CUSTOMS_DUTY"] + "</td></tr> Reimport-contentStarts@Rowno");
                sb.Append("<tr><td colspan='2'></td><td>" + ds_comn.Tables[5].Rows[rsp]["NOTN_SLNO"] + "</td><td>" + ds_comn.Tables[5].Rows[rsp]["SB_DATE"] + "</td><td colspan='2'>" + ds_comn.Tables[5].Rows[rsp]["PORT_EXPORT"] + "</td><td colspan='2'>" + ds_comn.Tables[5].Rows[rsp]["EXPORT_INSURANCE"] + "</td><td colspan='2'>" + ds_comn.Tables[5].Rows[rsp]["EXCISE_DUTY"] + "</td></tr> Reimport-contentStarts@Rowno");
            }
        }
        //  ************  End of REIMPORT details  *****************//

        //  ************  start of End use information details  *****************//    

        if (ds_comn.Tables[7].Rows.Count > 0)
        {
            sb.Append("<tr10br@123>");
            sb.Append("<tr style='text-align:center'><td10FWB@123><u>END USE INFORMATION</u></td></tr>");

            sb.Append("<trFWB@123><td>InvNo</td><td>ItmNo</td><td2@CS>Code</td><td6@CS>Description</td></tr>");

            for (int rsp = 0; rsp < ds_comn.Tables[7].Rows.Count; rsp++)
            {
                sb.Append("<tr><td>" + ds_comn.Tables[7].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds_comn.Tables[7].Rows[rsp]["ITEM_SLNO"] + "</td><td2@CS>" + ds_comn.Tables[7].Rows[rsp]["END_USE_OF_ITEM"] + "</td> ");
                sb.Append("<td6@CS>" + ds_comn.Tables[7].Rows[rsp]["END_USE_DESCRIPTION_NEW"] + "</td></tr> EndUse-contentStarts@Rowno");
            }

        }

        //  ************  End of End use information details  *****************//


        //  ************  start of Manufacturer details  *****************//
        if (ds_comn.Tables[6].Rows.Count > 0)
        {

            sb.Append("<tr10br@123>");
            sb.Append("<tr style='text-align:center'><td10FWB@123><U>MANUFACTURER DETAILS</U></td></tr>");
            sb.Append("<trFWB@123><td>InvNo</td><td>ItmNo</td><td2@CS>Name</td> <td4@CS>Address</td><td>Source</td><td>Transit</td></tr>");

            for (int rsp = 0; rsp < ds_comn.Tables[6].Rows.Count; rsp++)
            {
                sb.Append("<tr><td>" + ds_comn.Tables[6].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds_comn.Tables[6].Rows[rsp]["ITEM_SLNO"] + "</td><td2@CS>" + ds_comn.Tables[6].Rows[rsp]["MANUFACTURER"] + "</td> ");
                sb.Append("<td4@CS>" + ds_comn.Tables[6].Rows[rsp]["ManufactAddress"] + "</td><td>" + ds_comn.Tables[6].Rows[rsp]["SOURCE_COUNTRY"] + "</td><td>" + ds_comn.Tables[6].Rows[rsp]["TRANSIT_COUNTRY"] + "</td></tr> Manufact-contentStarts@Rowno");
            }

        }
        //  ************  End of Manufacturer details  *****************//


        //  ************  start of Single Window details  *****************//
       

        if (ds_SW.Tables[4].Rows.Count > 0)
        {

            sb.Append("<tr10br@123>");
            sb.Append("<tr style='text-align:center'><td10FWB@123><u>DECLARATIONS</u></td></tr>");
            sb.Append("<trFWB@123><td>InvNo</td><td>ItmNo</td><td8@CS>Declaration Codes</td></tr>");

            for (int rsp = 0; rsp < ds_SW.Tables[4].Rows.Count; rsp++)
            {
                sb.Append("<tr><td>" + ds_SW.Tables[4].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds_SW.Tables[4].Rows[rsp]["ITEM_SLNO"] + "</td> <td8@CS>" + ds_SW.Tables[4].Rows[rsp]["STMT_TYPE"] + " " + ds_SW.Tables[4].Rows[rsp]["STMT_CODE"] + "</td></tr> SingleWindow-contentStarts@Rowno");
            }

        }

        if (ds_SW.Tables[5].Rows.Count > 0)
        {

            sb.Append("<tr10br@123>");
            sb.Append("<tr style='text-align:center'><td10FWB@123><u>SUPPORTING DOCUMENTS</u></td></tr>");
            sb.Append("<trFWB@123><td>InvNo</td><td>ItmNo</td><td>Icegate ID</td><td2@CS>Image Ref.No (IRN)</td><td2@CS>Doc. Name</td><td>Doc. Type</td><td2@CS>Uploaded On</td></tr>");

            for (int rsp = 0; rsp < ds_SW.Tables[5].Rows.Count; rsp++)
            {
                sb.Append("<tr><td>" + ds_SW.Tables[5].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds_SW.Tables[5].Rows[rsp]["ITEM_SLNO"] + "</td><td>" + HttpContext.Current.Session["ICEGATE_ID"].ToString() + "</td> <td2@CS>" + ds_SW.Tables[5].Rows[rsp]["IMAGE_REF_NUMBER"] + "</td> ");
                sb.Append("<td2@CS>" + ds_SW.Tables[5].Rows[rsp]["DOC_REF_NUMBER"] + "</td><td>" + ds_SW.Tables[5].Rows[rsp]["DOC_TYPE_CODE"] + "</td><td2@CS>" + ds_SW.Tables[5].Rows[rsp]["DOC_ISSUE_DATE"] + "</td></tr> SupDoc-contentStarts@Rowno");
            }

        }



        ////  ************  End of Single Window details  *****************//

        sb.Append("<tr><td colspan='10'><br/></td></tr>");
        sb.Append("<tr><td colspan='10' style='text-align:left'>DECLARATION</td></tr>");
        sb.Append("<tr><td colspan='10'>1. I/We Certify that the above entries are correct.</td></tr>");

        sb.Append("<tr><td colspan='10'><br/></td></tr>");

        if (Connection.COMPANYID() == "1014" || Connection.COMPANYID() == "100")
        {
            sb.Append("<tr><td colspan='6'></td><td colspan='4'>Importer</td></tr>");
            sb.Append("<tr><td colspan='6'></td><td colspan='4'>" + impname + "</td></tr>");
            sb.Append("<tr><td colspan='6'></td><td colspan='4'>Signature</td></tr>");
        }
        else
        {
            sb.Append("<tr><td colspan='6'>CHA</td><td colspan='4'>Importer</td></tr>");
            sb.Append("<tr><td colspan='6'>" + HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "") + "</td><td colspan='4'>" + impname + "</td></tr>");
            sb.Append("<tr><td colspan='6'>Signature</td><td colspan='4'>Signature</td></tr>");
        }
        sb.Append("</table></html>");


        HttpResponse Response = HttpContext.Current.Response;
        Literal ltl = new Literal();
        ltl.Text = sb.ToString().Replace("<tdFWB@123>", "<td style='font-weight:bold'>").Replace("<td2FWB@123>", "<td colspan='2' style='font-weight:bold'>").Replace("<td3FWB@123>", "<td colspan='3' style='font-weight:bold'>").Replace("<td4FWB@123>", "<td colspan='4' style='font-weight:bold'>").Replace("<td5FWB@123>", "<td colspan='5' style='font-weight:bold'>").Replace("<td6FWB@123>", "<td colspan='6' style='font-weight:bold'>").Replace("<td7FWB@123>", "<td colspan='7' style='font-weight:bold'>").Replace("<td8FWB@123>", "<td colspan='8' style='font-weight:bold'>").Replace("<td9FWB@123>", "<td colspan='9' style='font-weight:bold'>").Replace("<td10FWB@123>", "<td colspan='10' style='font-weight:bold'>").Replace("<td2@CS>", "<td colspan='2'>").Replace("<td3@CS>", "<td colspan='3'>").Replace("<td4@CS>", "<td colspan='4'>").Replace("<td5@CS>", "<td colspan='5'>").Replace("<td6@CS>", "<td colspan='6'>").Replace("<td7@CS>", "<td colspan='7'>").Replace("<td8@CS>", "<td colspan='8'>").Replace("<td9@CS>", "<td colspan='9'>").Replace("<td10@CS>", "<td colspan='10'>").Replace("<tr10br@123>", "<tr><td colspan='10'><br/></td></tr>").Replace("<tdSAR@123>", "<td style='text-align:right'>").Replace("<td2SAR@123>", "<td colspan='2' style='text-align:right'>").Replace("<td3SAR@123>", "<td colspan='3' style='text-align:right'>").Replace("<td4SAR@123>", "<td colspan='4' style='text-align:right'>").Replace("<td5SAR@123>", "<td colspan='5' style='text-align:right'>").Replace("<td6SAR@123>", "<td colspan='6' style='text-align:right'>").Replace("<td7SAR@123>", "<td colspan='7' style='text-align:right'>").Replace("<trFWB@123>", "<tr style='font-weight:bold'>");


        ds_Gen.Dispose();
        dsI.Dispose();
        dss.Dispose();
        dssAss.Dispose();
        ds_comn.Dispose();
        ds_License.Dispose();
        ds_SW.Dispose();
        GC.Collect();

        string CID = Connection.COMPANYID().ToString();

        string errorFolder = Server.MapPath("~/Submission/" + CID + "/" + Connection.Current_Branch() + "/" + Connection.Current_User() + "/Import_CheckList/");
        if (CID == "10" || CID == "164" || CID == "165")
        {
            IC.Upload_JobHistory(jobno, errorFolder, CID, SELECT_BRANCH);
        }



        Response.Clear();
        Response.Buffer = true;

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        if (Directory.Exists(errorFolder) == false)
        {
            Directory.CreateDirectory(errorFolder);
        }
        else
        {
            foreach (FileInfo fileInformation in new DirectoryInfo(errorFolder).GetFiles())  // delete all the files inside  Import_CheckList - folder
            {
                File.Delete(fileInformation.FullName);
            }
        }


        //************ Start invoice wise break up here ************//
        string[] result = Regex.Split(ltl.Text.ToString(), "</table></html>");
        var temp = new List<string>();
        for (int res = 0; res < result.Length; res++)
        {

            if (result[res].ToString() != "")
                temp.Add(result[res].ToString() + "</table></html>");
        }
        //************ end invoice wise break up here ************//


        //************ start of Page break up here (it include all headings) ************//
        double Page_AssVal = 0;
        double Page_IGSTVal = 0;
        double Grnd_Page_AssVal = 0;
        double Grnd_Page_IGSTVal = 0;




        ltl.Text = "";
        for (int pdfcount = 0; pdfcount < temp.Count; pdfcount++)
        {
            var tempPage = new List<string>();
            string[] resultPage = Regex.Split(temp[pdfcount].ToString(), "</tr>");

            resultPage = resultPage.Where(w => w != "").ToArray();

            int curposition = 0;
            int nooflines = 0;
            int diff = 0;

            for (int res = 0; res < resultPage.Length; res++)
            {
                if (res > 0 && res < resultPage.Length - 1)
                {
                    
                    if (resultPage[res].ToString().Contains("@AssVal"))
                    {
                        Page_AssVal = Page_AssVal + Convert.ToDouble(resultPage[res].Substring(resultPage[res].ToString().IndexOf("@AssVal="), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))).Split('@')[1].Split('=')[1]);
                    }
                    if (resultPage[res].ToString().Contains("@IGSTVal"))
                    {
                        Page_IGSTVal = Page_IGSTVal + Convert.ToDouble(resultPage[res].Substring(resultPage[res].ToString().IndexOf("@IGSTVal="), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))).Split('@')[1].Split('=')[1]);
                    }

                    if (resultPage[res].ToString().Contains("Item-contentStarts@Rowno") && (resultPage[res].ToString().Contains("BE Gross Total")) ) //
                    {
                        if (resultPage[res - 1].ToString().Contains("Item-contentStarts@Rowno"))
                        {

                            tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Page_AssVal) + " </td> <td4FWB@123>Page Total</td><tdSAR@123>" + String.Format("{0:0.00}", Page_IGSTVal) + "</td></tr>");


                            Grnd_Page_AssVal = Grnd_Page_AssVal + Page_AssVal;
                            Grnd_Page_IGSTVal = Grnd_Page_IGSTVal + Page_IGSTVal;


                            tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Grnd_Page_AssVal) + " </td> <td4FWB@123>BE Total</td><tdSAR@123>" + String.Format("{0:0.00}", Grnd_Page_IGSTVal) + "</td></tr>");
                            tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            Page_AssVal = 0;
                            Page_IGSTVal = 0;

                        }
                        //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                    }
                    else
                    {
                        tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                    }
                    if (res % 50 == 0 && res > 5)  // prev i used 60 for mod 
                    {
                        // *** need to insert page total **//

                        if ((resultPage[res].ToString().Contains("Item-contentStarts@Rowno")) && (resultPage[res].ToString().Contains("Aduty (TTA) Duty")))
                        {
                            res = res + 1;
                            tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                            res = res + 1;
                            tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                            
                        }
                        else if ((resultPage[res].ToString().Contains("Item-contentStarts@Rowno")) && (resultPage[res].ToString().Contains("IGST Duty:")))
                        {
                            res = res + 1;
                            tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                            
                        }
                        

                        else if ((resultPage[res].ToString().Contains("Item-contentStarts@Rowno")) && !(resultPage[res].ToString().Contains("GST Compensation Cess:")))
                        {
                            if (resultPage[res].ToString().Contains("FirstLine"))
                                curposition = 1;
                            else

                                curposition = Convert.ToInt32(resultPage[res].Substring(resultPage[res].ToString().IndexOf("*@Line#"), resultPage[res].ToString().IndexOf("<tr>")).Split('#')[1].Substring(0, resultPage[res].Substring(resultPage[res].ToString().IndexOf("*@Line#"), resultPage[res].ToString().IndexOf("<tr>")).Split('#')[1].IndexOf("<tr>")));
                            
                            for (int k = 0; k < 15; k++)
                            {
                                if (resultPage[res + k].ToString().Contains("GST Compensation Cess:"))
                                {
                                    nooflines = Convert.ToInt32(resultPage[res + k].Substring(resultPage[res + k].ToString().IndexOf("*@Line#"), resultPage[res + k].ToString().IndexOf("<tr>")).Split('#')[1].Substring(0, resultPage[res + k].Substring(resultPage[res + k].ToString().IndexOf("*@Line#"), resultPage[res + k].ToString().IndexOf("<tr>")).Split('#')[1].IndexOf("<tr>")));
                                    //nooflines = nooflines + 1;
                                    break;
                                }
                            }
                            if (nooflines - curposition > 2)
                            {

                                diff = curposition;
                                while (diff > 0)
                                {
                                    tempPage.RemoveAt(tempPage.Count - 1);
                                    diff = diff - 1;
                                }
                                res = res - curposition;

                                

                            }
                            else if (nooflines - curposition <= 2)
                            {

                                //while (curposition > 0)
                                //{
                                //    res = res + 1;
                                //    tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                                //    curposition = curposition - 1;
                                //}
                                diff = nooflines-curposition;
                                while (diff > 0)
                                {
                                    res = res + 1;
                                    tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                                    curposition = curposition - 1;
                                    diff = diff - 1;
                                }

                            }
                        }



                        if ((resultPage[res - 1].ToString().Contains("Item-contentStarts@Rowno")) && !(resultPage[res - 1].ToString().Contains("Duty Payable")) && !(resultPage[res].ToString().Contains("Duty Payable")))
                        {

                            tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Page_AssVal) + " </td> <td4FWB@123>Page Total</td><tdSAR@123>" + String.Format("{0:0.00}", Page_IGSTVal) + "</td></tr>");
                            //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                            Grnd_Page_AssVal = Grnd_Page_AssVal + Page_AssVal;
                            Grnd_Page_IGSTVal = Grnd_Page_IGSTVal + Page_IGSTVal;

                            //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Grnd_Page_AssVal) + " </td> <td4FWB@123>BE Total</td><tdSAR@123>" + String.Format("{0:0.00}", Grnd_Page_IGSTVal) + "</td></tr>");
                            tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            Page_AssVal = 0;
                            Page_IGSTVal = 0;

                        }

                        tempPage.Add("</table></html><html><table>");
                        if ((resultPage[res].ToString().Contains("Item-contentStarts@Rowno")) && !(resultPage[res].ToString().Contains("Duty Payable")) && !(resultPage[res - 1].ToString().Contains("Duty Payable")))
                        {

                            tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            tempPage.Add("<trFWB@123><td>Sl No</td> <td2@CS>RITC</td><td7@CS>Description</td></tr>");
                            tempPage.Add("<trFWB@123><td3@CS>QTY</td> <td2@CS>Unit Price</td> <td>CTH</td><td>Cus.Notn</td><td colspan='2' style='text-align:center'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cus.Duty.Rate</td><td>BCDAmt(Rs)</td></tr>");
                            tempPage.Add("<trFWB@123><td3@CS>Unit</td> <td2@CS>Assessable Value</td><td>CETH</td><td>Exc.Notn</td><td colspan='2' style='text-align:center'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exc.Duty.Rate</td><td>CVDAmt(Rs)</td></tr>");
                            tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                            if (curposition > 0)
                            {
                                while (curposition > 0)
                                {
                                    res = res + 1;
                                    tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                                    curposition = curposition - 1;
                                }
                            }

                        }

                        else if (resultPage[res].ToString().Contains("License-contentStarts@Rowno"))
                        {
                            if (resultPage[res].ToString().Contains("License-contentStarts@Rowno-2ndLine"))
                            {
                                tempPage.RemoveAt(tempPage.Count - 1);
                                res = res + 1;
                                tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                                tempPage.Add("</table></html><html><table>");
                            }
                            
                            tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            tempPage.Add("<trFWB@123><td>Sl.No</td><td>Reg.No</td><td>Reg.Date</td><td>Scheme</td><td>DebitValue</td><td>Duty</td><td>QTY</td><td>INV/ITSL</td><td>L.Sno</td><td>Port</td></tr>");
                            tempPage.Add("<trFWB@123><td></td><td>LIC.No</td><td colspan='4'>LIC.Date</td><td colspan='4'>Unit </td></tr>");
                            tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                        }
                        else if (resultPage[res].ToString().Contains("GSTIN-contentStarts@Rowno") && resultPage[res + 1].ToString().Contains("GSTIN-contentStarts@Rowno"))
                        {
                            
                            tempPage.Add("<tr style='text-align:center'><td10FWB@123><u>GSTIN Details</u></td></tr>");
                            tempPage.Add("<trFWB@123><td2@CS>Document No</td><td2@CS>Type</td><td2@CS>State Code/ Name</td> <td2@CS>IGST Amt</td><td2@CS>GST Cess Amt</td></tr>");
                        }
                        else if (resultPage[res].ToString().Contains("SingWindAddPrd-contentStarts@Rowno") && resultPage[res + 1].ToString().Contains("SingWindAddPrd-contentStarts@Rowno"))
                        {
                            tempPage.Add("<tr style='text-align:center'><td10FWB@123><u> SINGLE WINDOW - Additional Product Information</u></td></tr>");
                            tempPage.Add("<trFWB@123><td>InvNo</td><td>ItemNo</td> <td>Info Type</td><td2@CS>Info Qualifier</td><td2@CS>Code/Information</td><td2@CS>Info Text</td><td>MSR-UQC</td></tr>");           

                            
                        }
                        else if (resultPage[res].ToString().Contains("Reimport-contentStarts@Rowno") && resultPage[res + 1].ToString().Contains("Reimport-contentStarts@Rowno"))
                        {
                           
                            tempPage.Add("<trFWB@123><td>InvNo</td><td>ItmNo</td> <td>Notn No</td><td>SB No</td><td colspan='2'>SB Inv Sr.No.</td><td colspan='2'>Exp Freight</td><td colspan='2'>Custom Duty</td></tr>");
                            tempPage.Add("<trFWB@123><td colspan='2'></td><td>Notn SNo</td><td>SB Dt</td><td colspan='2'>Exp Port</td><td colspan='2'>Exp Insurance</td><td colspan='2'>Excise Duty</td></tr>");
                        }
                        else if (resultPage[res].ToString().Contains("EndUse-contentStarts@Rowno") && resultPage[res + 1].ToString().Contains("EndUse-contentStarts@Rowno"))
                        {
                           
                            tempPage.Add("<trFWB@123><td>InvNo</td><td>ItmNo</td><td2@CS>Code</td><td6@CS>Description</td></tr>");
                        }
                        else if (resultPage[res].ToString().Contains("Manufact-contentStarts@Rowno") && resultPage[res + 1].ToString().Contains("Manufact-contentStarts@Rowno"))
                        {
                            
                            tempPage.Add("<trFWB@123><td>InvNo</td><td>ItmNo</td><td2@CS>Name</td> <td4@CS>Address</td><td>Source</td><td>Transit</td></tr>");
                        }
                        else if (resultPage[res].ToString().Contains("SingleWindow-contentStarts@Rowno") && resultPage[res + 1].ToString().Contains("SingleWindow-contentStarts@Rowno"))
                        {
                           
                            tempPage.Add("<trFWB@123><td>InvNo</td><td>ItmNo</td><td8@CS>Declaration Codes</td></tr>");
                        }
                        else if (resultPage[res].ToString().Contains("SupDoc-contentStarts@Rowno") && resultPage[res + 1].ToString().Contains("SupDoc-contentStarts@Rowno"))
                        {
                          
                            tempPage.Add("<trFWB@123><td>InvNo</td><td>ItmNo</td><td>Icegate ID</td><td2@CS>Image Ref.No (IRN)</td><td2@CS>Doc. Name</td><td>Doc. Type</td><td2@CS>Uploaded On</td></tr>");
                        }

                    }
                }
                else
                {

                    if (resultPage[res].ToString().Contains("@AssVal"))
                    {
                        Page_AssVal = Page_AssVal + Convert.ToDouble(resultPage[res].Substring(resultPage[res].ToString().IndexOf("@AssVal="), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))).Split('@')[0].Split('=')[1]);
                    }
                    if (resultPage[res].ToString().Contains("@IGSTVal"))
                    {
                        Page_IGSTVal = Page_IGSTVal + Convert.ToDouble(resultPage[res].Substring(resultPage[res].ToString().IndexOf("@IGSTVal="), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))).Split('@')[1].Split('=')[1]);
                    }

                    if (res == 0)
                    {
                        tempPage.Add(resultPage[res].ToString() + "</tr>");  // 1st row  
                    }
                    else if (res == resultPage.Length - 1) // last row of the html file
                    {
                        if (resultPage[res - 1].ToString().Contains("Item-contentStarts@Rowno"))
                        {
                            tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Page_AssVal) + " </td> <td4FWB@123>Page Total</td><tdSAR@123>" + String.Format("{0:0.00}", Page_IGSTVal) + "</td></tr>");
                            //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                            Grnd_Page_AssVal = Grnd_Page_AssVal + Page_AssVal;
                            Grnd_Page_IGSTVal = Grnd_Page_IGSTVal + Page_IGSTVal;

                            //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Grnd_Page_AssVal) + " </td> <td4FWB@123>BE Total</td><tdSAR@123>" + String.Format("{0:0.00}", Grnd_Page_IGSTVal) + "</td></tr>");
                            tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            Page_AssVal = 0;
                            Page_IGSTVal = 0;

                        }
                        tempPage.Add(resultPage[res].ToString() + "</tr>");
                    }
                }
            }
            ltl.Text = ltl.Text + string.Join("", tempPage);
            tempPage.Clear();

        }
        //************ end of Page break up here (it include all headings) ************//

        //************ start of converting pages into html text ************//
        temp.Clear();
        


        ltl.Text = ltl.Text.Replace("</table></html></tr>", "</table></html>");   
        ltl.Text = ltl.Text.Replace("<html><table></table></html>", "");

        result = Regex.Split(ltl.Text.ToString(), "</table></html>");


        for (int res = 0; res < result.Length; res++)
        {

            if (result[res].ToString() != "")
                temp.Add(result[res].ToString() + "</table></html>");
        }
        //************ end of converting pages into html text ************//


        //************ start of converting html text to pdf files ************//
        var tempFilename = new List<string>();
        string filename1 = "";

        int pno = 1;
        int totpno = 0;

        for (int pdfcount = 0; pdfcount < temp.Count; pdfcount++)
        {

            ltl.Text = "";
            if (temp[pdfcount].ToString() != "")
            {
                StringWriter sw = new StringWriter();
                filename1 = "Imp_" + (pdfcount + 1) + "_" + jobno + ".pdf";
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                ltl.Text = temp[pdfcount].ToString().Replace("<tdFWB@123>", "<td style='font-weight:bold'>").Replace("<td2FWB@123>", "<td colspan='2' style='font-weight:bold'>").Replace("<td3FWB@123>", "<td colspan='3' style='font-weight:bold'>").Replace("<td4FWB@123>", "<td colspan='4' style='font-weight:bold'>").Replace("<td5FWB@123>", "<td colspan='5' style='font-weight:bold'>").Replace("<td6FWB@123>", "<td colspan='6' style='font-weight:bold'>").Replace("<td7FWB@123>", "<td colspan='7' style='font-weight:bold'>").Replace("<td8FWB@123>", "<td colspan='8' style='font-weight:bold'>").Replace("<td9FWB@123>", "<td colspan='9' style='font-weight:bold'>").Replace("<td10FWB@123>", "<td colspan='10' style='font-weight:bold'>").Replace("<td2@CS>", "<td colspan='2'>").Replace("<td3@CS>", "<td colspan='3'>").Replace("<td4@CS>", "<td colspan='4'>").Replace("<td5@CS>", "<td colspan='5'>").Replace("<td6@CS>", "<td colspan='6'>").Replace("<td7@CS>", "<td colspan='7'>").Replace("<td8@CS>", "<td colspan='8'>").Replace("<td9@CS>", "<td colspan='9'>").Replace("<td10@CS>", "<td colspan='10'>").Replace("<tr10br@123>", "<tr><td colspan='10'><br/></td></tr>").Replace("<tdSAR@123>", "<td style='text-align:right'>").Replace("<td2SAR@123>", "<td colspan='2' style='text-align:right'>").Replace("<td3SAR@123>", "<td colspan='3' style='text-align:right'>").Replace("<td7SAR@123>", "<td colspan='7' style='text-align:right'>").Replace("<trFWB@123>", "<tr style='font-weight:bold'>");
                //ltl.Text = temp[pdfcount].ToString().Replace("<tdFWB@123>", "<td style='font-weight:bold'>").Replace("<td2FWB@123>", "<td colspan='2' style='font-weight:bold'>").Replace("<td3FWB@123>", "<td colspan='3' style='font-weight:bold'>").Replace("<td4FWB@123>", "<td colspan='4' style='font-weight:bold'>").Replace("<td5FWB@123>", "<td colspan='5' style='font-weight:bold'>").Replace("<td6FWB@123>", "<td colspan='6' style='font-weight:bold'>").Replace("<td7FWB@123>", "<td colspan='7' style='font-weight:bold'>").Replace("<td8FWB@123>", "<td colspan='8' style='font-weight:bold'>").Replace("<td9FWB@123>", "<td colspan='9' style='font-weight:bold'>").Replace("<td10FWB@123>", "<td colspan='10' style='font-weight:bold'>").Replace("<td2@CS>", "<td colspan='2'>").Replace("<td3@CS>", "<td colspan='3'>").Replace("<td4@CS>", "<td colspan='4'>").Replace("<td5@CS>", "<td colspan='5'>").Replace("<td6@CS>", "<td colspan='6'>").Replace("<td7@CS>", "<td colspan='7'>").Replace("<td8@CS>", "<td colspan='8'>").Replace("<td9@CS>", "<td colspan='9'>").Replace("<td10@CS>", "<td colspan='10'>").Replace("<tr10br@123>", "<tr><td colspan='10'><br/></td></tr>").Replace("<tdSAR@123>", "<td style='text-align:right'>").Replace("<td2SAR@123>", "<td colspan='2' style='text-align:right'>").Replace("<td3SAR@123>", "<td colspan='3' style='text-align:right'>").Replace("<td4SAR@123>", "<td colspan='4' style='text-align:right'>").Replace("<td5SAR@123>", "<td colspan='5' style='text-align:right'>").Replace("<td6SAR@123>", "<td colspan='6' style='text-align:right'>").Replace("<td7SAR@123>", "<td colspan='7' style='text-align:right'>").Replace("<trFWB@123>", "<tr style='font-weight:bold'>");
                ltl.Text = ltl.Text.Replace("<html><table>", "<html><table width='100%' style='vertical-align:top; font-family:Courier New; font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");
                ltl.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                //Document pdfDoc = new Document(PageSize.A4, 40f, 10f, 80f, 10f);
                Document pdfDoc = new Document(PageSize.A4, 40f, 10f, 95f, 15f);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, new FileStream(errorFolder + filename1, FileMode.Create));
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                tempFilename.Add(errorFolder + filename1);
            }

        }
        //************ end of converting html text to pdf files ************//

        //*************** start to find total no of pages ********************//
        for (int pdfcount = 0; pdfcount < temp.Count; pdfcount++)
        {
            if (temp[pdfcount].ToString() != "")
            {
                filename1 = "Imp_" + (pdfcount + 1) + "_" + jobno + ".pdf";
                byte[] bytes = File.ReadAllBytes(errorFolder + filename1);

                using (MemoryStream stream = new MemoryStream())
                {
                    PdfReader reader = new PdfReader(bytes);
                    using (PdfStamper stamper = new PdfStamper(reader, stream))
                    {
                        int pages = reader.NumberOfPages;
                        totpno = totpno + pages;
                    }
                }

            }

        }
        //*************** end to find total no of pages ********************//

        //*************** start to put header ********************//
        tempFilename.Clear();
        for (int pdfcount = 0; pdfcount < temp.Count; pdfcount++)
        {
            if (temp[pdfcount].ToString() != "")
            {

                filename1 = "Imp_" + (pdfcount + 1) + "_" + jobno + ".pdf";

                byte[] bytes = File.ReadAllBytes(errorFolder + filename1);
                Font blackFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK);
                Font blackFont2 = FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK);
                Font blackFont3 = FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK);

                using (MemoryStream stream = new MemoryStream())
                {
                    PdfReader reader = new PdfReader(bytes);
                    using (PdfStamper stamper = new PdfStamper(reader, stream))
                    {
                        int pages = reader.NumberOfPages;
                        for (int i = 1; i <= pages; i++)
                        {
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_CENTER, new Phrase(head1, blackFont), 300f, 810f, 0); //company name
                            ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(head2, blackFont2), 300f, 800f, 0); //check list name                            
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_CENTER, new Phrase(head3 + "                                        Page #" + (pno) + "/" + totpno, blackFont2), 300f, 790f, 0);
                            ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(head4, blackFont2), 300f, 785f, 0); //line ----                           

                            ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head5_1, blackFont3), 40f, 775f, 0);  // BE no
                            ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head5_2, blackFont3), 312f, 775f, 0);  // JOB no

                            ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head6, blackFont3), 312f, 765f, 0);  //Party
                            ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head7_1, blackFont3), 40f, 755f, 0);  // CHA details
                            ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head7_2, blackFont3), 312f, 755f, 0);  // Importer details

                            pno = pno + 1;
                        }
                    }
                    bytes = stream.ToArray();
                }
                filename1 = "Imp_" + (pdfcount + 1) + "_" + jobno + "_hdr.pdf";
                File.WriteAllBytes(errorFolder + filename1, bytes);
                tempFilename.Add(errorFolder + filename1);
            }
        }
        //*************** end of header ********************//


        //*************** start to merge all pdf files ********************//
        if (tempFilename.Count > 0)
        {
            List<PdfReader> readerList = new List<PdfReader>();
            for (int tf = 0; tf < tempFilename.Count; tf++)
            {
                PdfReader pdfReader1 = new PdfReader(tempFilename[tf]);
                readerList.Add(pdfReader1);
            }

            Document document = new Document(PageSize.A4, 0, 0, 0, 0);
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();

            foreach (PdfReader reader in readerList)
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    document.Add(iTextSharp.text.Image.GetInstance(page));
                }
            }
            document.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + jobno + ".pdf");
            Response.End();
        }
        //*************** end to merge all pdf files ********************//


    }

   


    protected void btnpdf_Click(object sender, EventArgs e)
    {
        if (lbl.Text != "")
        {
            string fnt = ddlFont.SelectedValue.ToString();

            lbl.Text = lbl.Text.Replace("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>", "<html><table width='100%' style='vertical-align:top; font-family:Courier New; font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");
            //lbl.Text = lbl.Text.Replace("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>", "<html><head></head><body style='font-family: Times New Roman'><table width='100%' style='vertical-align:top; font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");
            string jobno = ddlJob_No.SelectedValue.ToString();
            string filename = "ImpChecklist_" + jobno + ".pdf";
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";

           // Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
            Response.AppendHeader("Content-Disposition", "inline; filename=" + filename);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            using (StringWriter sw = new StringWriter())
            {

                HtmlTextWriter hw = new HtmlTextWriter(sw);
                lbl.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                // Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 100f, 0f);                

                Document pdfDoc = new Document(PageSize.A4, 40f, 10f, 5f, 5f);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

              

                pdfDoc.Open();

                //pdfDoc.HtmlStyleClass = " <style type='text/css'>  .style1  {  font-family: 'Arial Black'; } </style>";

                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
            }

           

        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Check List', function (r) {});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }

    }

    public string Return_ExRate_Value(string currency, string ExRate)
    {
        if (ExRate == "")
        {
            ExRate = "0.00";
        }
        else if (currency == "INR")
        {
            ExRate = "1";

        }
        else if (currency == "JPY")
        {
            ExRate = Convert.ToString(Convert.ToDouble(ExRate) / 100); 
        }

        return ExRate;
    }

    public void Get_Invoice_Details(string ddlJobNo, DataRow row, int count)
    {

        //Load_Invoice_Details.Clear();

        //if (ds.Rows.Count > 0)
        //{
        //    SECTION46 = ds.Rows[0]["SECTION46"].ToString();
        //    FIRSTCHECK = ds.Rows[0]["FIRSTCHECK"].ToString();
        //    GREEN_CHANNEL = ds.Rows[0]["GREEN_CHANNEL"].ToString();
        //    KACHHA_BE = ds.Rows[0]["KACHHA_BE"].ToString();
        //    SECTION48 = ds.Rows[0]["SECTION48"].ToString();

        //}

        INVOICE_SLNO = Convert.ToInt32(row["INVOICE_SLNO"].ToString());
        INVOICE_NO = row["INVOICE_NO"].ToString();

        INVOICE_DATE = row["INVOICE_DATE"].ToString();
        INVOICE_VALUE = Return_Zero_Value1(row["INVOICE_VALUE"].ToString());
        INVOICE_CURRENCY = row["INVOICE_CURRENCY"].ToString();
        MIS_FREIGHT_CHARGES = row["MIS_FREIGHT_CHARGES"].ToString();
        MIS_FREIGHT_RATE = row["MIS_FREIGHT_RATE"].ToString();
        MIS_FREIGHT_CURRENCY = row["MIS_FREIGHT_CURRENCY"].ToString();
        MIS_FREIGHT_EXRATE = row["MIS_FREIGHT_EXRATE"].ToString();
        MIS_INSURANCE_CHARGES = row["MIS_INSURANCE_CHARGES"].ToString();
        MIS_INSURANCE_RATE = row["MIS_INSURANCE_RATE"].ToString();

        MIS_INSURANCE_CURRENCY = row["MIS_INSURANCE_CURRENCY"].ToString();
        MIS_INSURANCE_EXRATE = row["MIS_INSURANCE_EXRATE"].ToString();
        SUPPLIER_COUNTRY_NAME = row["SUPPLIER_COUNTRY_NAME"].ToString();
        SUPPLIER_COUNTRY_PINCODE = row["SUPPLIER_COUNTRY_PINCODE"].ToString();

        MIS_CHARGES = Return_Zero_Value(row["MIS_CHARGES"].ToString());
        MIS_CURRENCY = Return_Zero_Value(row["MIS_CURRENCY"].ToString());
        MIS_RATE = Return_Zero_Value(row["MIS_RATE"].ToString());
        MIS_EXRATE = Return_Zero_Value(row["MIS_EXRATE"].ToString());

        if (INVOICE_DATE == "01/01/1900" || INVOICE_DATE == "01-01-1900")
            INVOICE_DATE = "";

        Invoice_value = INVOICE_VALUE + " " + INVOICE_CURRENCY;
        //----------------------------------------------------------------------------------------------------------------//

        double mis_fri_charge = 0.00;
        double mis_insu_charge = 0.00;

        //if (TERMS == "CI")
        //{
        //    MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES) /  Convert.ToDouble(INVOICE_EXRATE));               
        //    MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MIS_CHARGES) + Convert.ToDouble(D_AMOUNT) + +Convert.ToDouble(M_AMOUNT) + Convert.ToDouble(N_AMOUNT),2));
        //    MIS_CURRENCY = INVOICE_CURRENCY;
        //    MIS_EXRATE = INVOICE_EXRATE;
        //}

        //************ CI Terms display in CHECKLIST ******************** 03/01/2018 

        if (TERMS == "CI")
        {
            if (MIS_CHARGES == "" || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
            {
                if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
                {
                    MIS_CURRENCY = INVOICE_CURRENCY;
                    MIS_EXRATE = INVOICE_EXRATE;
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
                        MIS_EXRATE = INVOICE_EXRATE;
                        MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
                    }
                    else
                    {
                        double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
                        MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
                        MIS_CURRENCY = INVOICE_CURRENCY;
                        MIS_EXRATE = INVOICE_EXRATE;
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

        if (TERMS != "CIF")
        {
            if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00" && MIS_FREIGHT_RATE != "0.0000" && MIS_FREIGHT_RATE != "")
            {
                //----------FOR CHECKLIST PURPOSE-------------//
                if (MIS_FREIGHT_RATE == "20.0000" || MIS_FREIGHT_RATE == "20.0")
                {
                    MIS_FREIGHT_RATE = "20";

                }

                //mis_fri_charge = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;

                //mis_fri_charge = Convert.ToDouble(INVOICE_VALUE_INR) * Convert.ToDouble(MIS_FREIGHT_RATE) / 100; // hide by Chithra on 03-Apr-2018 - ENSEN SHIP
                mis_fri_charge = (Convert.ToDouble(INVOICE_VALUE_INR) + Convert.ToDouble(MISC_AMOUNT)) * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;

                if (MIS_FREIGHT_CURRENCY != "INR" && MIS_FREIGHT_CURRENCY != "JPY" && MIS_FREIGHT_CURRENCY != "KRW")
                {
                    mis_fri_charge = mis_fri_charge / Convert.ToDouble(MIS_FREIGHT_EXRATE);
                }
                else if (MIS_FREIGHT_CURRENCY == "JPY" || MIS_FREIGHT_CURRENCY == "KRW")
                {
                    mis_fri_charge = (mis_fri_charge / Convert.ToDouble(MIS_FREIGHT_EXRATE)) * 100;
                }

                //else
                //{

                //}

                MIS_FREIGHT_CHARGES = Convert.ToString(mis_fri_charge);
                //----------FOR CHECKLIST PURPOSE-------------//

                MIS_FREIGHT_CHARGES = MIS_FREIGHT_RATE + "%" + "(" + Math.Round(Convert.ToDouble(MIS_FREIGHT_CHARGES), 2) + " " + MIS_FREIGHT_CURRENCY + ")";
            }
            else
            {
                if (MIS_FREIGHT_CHARGES != "")
                {
                    MIS_FREIGHT_CHARGES = MIS_FREIGHT_CHARGES + " " + MIS_FREIGHT_CURRENCY + " " + MIS_FREIGHT_EXRATE;
                }
                else
                {

                    // MIS_FREIGHT_CHARGES = "20%";
                }
                MIS_FREIGHT_RATE = "20";
            }
            //----------------------------------------------------------------------------------------------------------------//
            if (MIS_INSURANCE_RATE != "0" && MIS_INSURANCE_RATE != "0.00" && MIS_INSURANCE_RATE != "0.0000" && MIS_INSURANCE_RATE != "")
            {
                if (MIS_CHARGES != "0" && MIS_CHARGES != "0.00" && MIS_CHARGES != "")
                {
                    if (INVOICE_CURRENCY == MIS_CURRENCY)
                    {
                        double inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES);

                        double ins_charge = inv_value * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;

                        /*
                        if (INVOICE_CURRENCY != MIS_INSURANCE_CURRENCY)
                        {
                            if (MIS_INSURANCE_CURRENCY != "JPY")
                            {
                                ins_charge = ins_charge * Convert.ToDouble(INVOICE_EXRATE);
                            }
                            else
                            {
                                ins_charge = (ins_charge / Convert.ToDouble(INVOICE_EXRATE)) * 100;
                            }
                        }
                         * */

                        if (INVOICE_CURRENCY != MIS_INSURANCE_CURRENCY)
                        {
                            if (MIS_INSURANCE_CURRENCY == "INR")
                            {
                                ins_charge = ins_charge * Convert.ToDouble(INVOICE_EXRATE);
                            }
                            else if (MIS_INSURANCE_CURRENCY == "JPY" || MIS_INSURANCE_CURRENCY == "KRW")
                            {
                                //ins_charge = (ins_charge / Convert.ToDouble(INVOICE_EXRATE)) * 100;
                                double Ins_Exrate = Convert.ToDouble(MIS_INSURANCE_EXRATE) / 100;
                                ins_charge = (ins_charge * Convert.ToDouble(INVOICE_EXRATE)) / Ins_Exrate;
                            }
                            else
                            {
                                ins_charge = (ins_charge * Convert.ToDouble(INVOICE_EXRATE)) / Convert.ToDouble(MIS_INSURANCE_EXRATE);
                            }
                        }


                        //MIS_INSURANCE_CHARGES = MIS_INSURANCE_RATE + "%" + "(" + Math.Round(Convert.ToDouble(MIS_INSURANCE_CHARGES), 2) + " " + MIS_INSURANCE_CURRENCY + ")";
                        MIS_INSURANCE_CHARGES = MIS_INSURANCE_RATE + "%" + "(" + Math.Round(Convert.ToDouble(ins_charge), 2) + " " + MIS_INSURANCE_CURRENCY + ")";
                    }
                    else if (INVOICE_CURRENCY != MIS_CURRENCY)
                    {
                        double Mischarges = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);

                        double inv_value = Convert.ToDouble(INVOICE_VALUE) + Mischarges;

                        double ins_charge = inv_value * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;

                        /*
                        if (INVOICE_CURRENCY != MIS_INSURANCE_CURRENCY)
                        {
                            if (MIS_INSURANCE_CURRENCY != "JPY")
                            {
                                ins_charge = ins_charge * Convert.ToDouble(INVOICE_EXRATE);
                            }
                            else
                            {
                                ins_charge = (ins_charge / Convert.ToDouble(INVOICE_EXRATE)) * 100;
                            }
                        }
                        */

                        if (INVOICE_CURRENCY != MIS_INSURANCE_CURRENCY)
                        {
                            if (MIS_INSURANCE_CURRENCY == "INR")
                            {
                                ins_charge = ins_charge * Convert.ToDouble(INVOICE_EXRATE);
                            }
                            else if (MIS_INSURANCE_CURRENCY == "JPY" || MIS_INSURANCE_CURRENCY == "KRW")
                            {
                                //ins_charge = (ins_charge / Convert.ToDouble(INVOICE_EXRATE)) * 100;
                                double Ins_Exrate = Convert.ToDouble(MIS_INSURANCE_EXRATE) / 100;
                                ins_charge = (ins_charge * Convert.ToDouble(INVOICE_EXRATE)) / Ins_Exrate;
                            }
                            else
                            {
                                ins_charge = (ins_charge * Convert.ToDouble(INVOICE_EXRATE)) / Convert.ToDouble(MIS_INSURANCE_EXRATE);
                            }
                        }


                        //MIS_INSURANCE_CHARGES = MIS_INSURANCE_RATE + "%" + "(" + Math.Round(Convert.ToDouble(MIS_INSURANCE_CHARGES), 2) + " " + MIS_INSURANCE_CURRENCY + ")";
                        MIS_INSURANCE_CHARGES = MIS_INSURANCE_RATE + "%" + "(" + Math.Round(Convert.ToDouble(ins_charge), 2) + " " + MIS_INSURANCE_CURRENCY + ")";
                    }
                }
                else
                {
                    //mis_insu_charge = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                    mis_insu_charge = Convert.ToDouble(INVOICE_VALUE_INR) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;

                    if (MIS_INSURANCE_CURRENCY != "INR" && MIS_INSURANCE_CURRENCY != "JPY" && MIS_INSURANCE_CURRENCY != "KRW")
                    {
                        mis_insu_charge = mis_insu_charge / Convert.ToDouble(MIS_INSURANCE_EXRATE);
                    }
                    else if (MIS_INSURANCE_CURRENCY == "JPY" || MIS_INSURANCE_CURRENCY == "KRW")
                    {
                        mis_insu_charge = (mis_insu_charge / Convert.ToDouble(MIS_INSURANCE_EXRATE)) * 100;
                    }

                    MIS_INSURANCE_CHARGES = Convert.ToString(mis_insu_charge);

                    MIS_INSURANCE_CHARGES = MIS_INSURANCE_RATE + "%" + "(" + Math.Round(Convert.ToDouble(MIS_INSURANCE_CHARGES), 2) + " " + MIS_INSURANCE_CURRENCY + ")";
                }
            }
            else
            {
                if (MIS_INSURANCE_CHARGES != "")
                {
                    MIS_INSURANCE_CHARGES = MIS_INSURANCE_CHARGES + " " + MIS_INSURANCE_CURRENCY + " " + MIS_INSURANCE_EXRATE;
                    // MIS_FREIGHT_CHARGES = MIS_FREIGHT_CHARGES + " " + MIS_FREIGHT_CURRENCY + " " + MIS_FREIGHT_EXRATE;
                }
                else
                {

                    //MIS_INSURANCE_CHARGES = "1.125%";
                }
                MIS_INSURANCE_RATE = "1.125";

            }
        }
        else
        {
            MIS_FREIGHT_RATE = "";
            MIS_INSURANCE_RATE = "";
        }
        //----------------------------------------------------------------------------------------------------------------//
        SVB_RELATION = row["SVB_RELATION"].ToString();

        if (SVB_RELATION == "Y")
        {
            SVB_REF_NO = row["SVB_REF_NO"].ToString();
            if (SVB_REF_NO == "")
            {
                SVB_REF_NO = "";
            }
            SVB_REF_DATE = row["SVB_REF_DATE"].ToString();
            if (SVB_REF_DATE == "01/01/1900" || SVB_REF_DATE == "01-01-1900")
                SVB_REF_DATE = "";
            SVB_ASSESABLE_RATE = row["SVB_ASSESABLE_RATE"].ToString();

            SVB_LOADING_ON = row["SVB_LOADING_ON"].ToString();

            SVB_ASSESABLE_STATUS = row["SVB_ASSESABLE_STATUS"].ToString();
            SVB_DUTY_STATUS = row["SVB_DUTY_STATUS"].ToString();


            SVB_DUTY_RATE = row["SVB_DUTY_RATE"].ToString();
            SVB_CUSTOM_HOUSE = row["SVB_CUSTOM_HOUSE"].ToString();
            if (SVB_ASSESABLE_RATE != "")
            {
                SVB_ASSESABLE_RATE = SVB_ASSESABLE_RATE + "%" + "(" + SVB_ASSESABLE_STATUS + ")";
            }
            else
            {
                SVB_ASSESABLE_RATE = "";
            }
            if (SVB_DUTY_RATE != "")
            {
                SVB_DUTY_RATE = SVB_DUTY_RATE + "%" + "(" + SVB_DUTY_STATUS + ")";
            }
            else
            {
                SVB_DUTY_RATE = "";
            }
        }
        else
        {
            SVB_REF_NO = "";
            SVB_REF_DATE = "";
            SVB_ASSESABLE_RATE = "";
            SVB_LOADING_ON = "";
            SVB_ASSESABLE_STATUS = "";
            SVB_DUTY_STATUS = "";
            SVB_DUTY_RATE = "";
            SVB_CUSTOM_HOUSE = "";
            SVB_ASSESABLE_RATE = "";
        }


        //MIS_CHARGES = Return_Zero_Value(row["MIS_CHARGES"].ToString());
        //MIS_CURRENCY = Return_Zero_Value(row["MIS_CURRENCY"].ToString());
        //MIS_RATE = Return_Zero_Value(row["MIS_RATE"].ToString());
        //MIS_EXRATE = Return_Zero_Value(row["MIS_EXRATE"].ToString());

        //double mis_charge = Convert.ToDouble(MIS_CHARGES);
        // double mis_rate = Convert.ToDouble(MIS_EXRATE);
        //double ttl = Convert.ToDouble(mis_charge) * Convert.ToDouble(mis_rate);
        //Total_Invoice = Convert.ToString(ttl);
        string MIS_CHARGES_Add = "";
        SupplierCountry_Name_Pincode = SUPPLIER_COUNTRY_NAME + " " + SUPPLIER_COUNTRY_PINCODE;
        if (MIS_CHARGES != "0")
        {
            MIS_CHARGES_Add = MIS_CHARGES + " " + MIS_CURRENCY + " " + MIS_EXRATE;
        }
        else
        {
            MIS_CHARGES_Add = "";
        }
        MIS_HIGHSEASALE_RATE = row["MIS_HIGHSEASALE_RATE"].ToString();
        string MIS_Hss_RATE = MIS_HIGHSEASALE_RATE;


        if (MIS_HIGHSEASALE_RATE != "" && MIS_Hss_RATE != "0")
        {
            MIS_Hss_RATE = MIS_HIGHSEASALE_RATE.Substring(0, 1);
            MIS_HIGHSEASALE_RATE = MIS_HIGHSEASALE_RATE + "%";
        }
        else
        {
            MIS_HIGHSEASALE_RATE = "";
        }

        MIS_HIGHSEASALE_CHARGES = row["MIS_HIGHSEASALE_CHARGES"].ToString();
        MIS_HIGHSEASALE_CURRENCY = row["MIS_HIGHSEASALE_CURRENCY"].ToString();
        MIS_HIGHSEASALE_EXRATE = row["MIS_HIGHSEASALE_EXRATE"].ToString();


        MIS_LOADING_CHARGES = row["MIS_LOADING_CHARGES"].ToString();
        MIS_LOADING_CURRENCY = row["MIS_LOADING_CURRENCY"].ToString();
        MIS_LOADING_EXRATE = row["MIS_LOADING_EXRATE"].ToString();
        if (MIS_LOADING_CHARGES != "" && MIS_LOADING_CHARGES != "0")
        {
            MIS_LOADING_CHARGES = MIS_LOADING_CHARGES + " " + MIS_LOADING_CURRENCY + " " + MIS_LOADING_EXRATE;
        }
        else
        {
            MIS_LOADING_CHARGES = "";
        }


        MIS_DISCOUNT_RATE = row["MIS_DISCOUNT_RATE"].ToString();
        MIS_DISCOUNT_CHARGES = row["MIS_DISCOUNT_CHARGES"].ToString();
        MIS_DISCOUNT_CURRENCY = row["MIS_DISCOUNT_CURRENCY"].ToString();
        MIS_DISCOUNT_EXRATE = row["MIS_DISCOUNT_EXRATE"].ToString();
        string MIS_Dscount_RATE = MIS_DISCOUNT_RATE.Substring(0, 1);

        if (MIS_DISCOUNT_RATE != "" && MIS_Dscount_RATE != "0")
        {
            MIS_DISCOUNT_RATE = MIS_DISCOUNT_RATE + "%";
        }
        else
        {
            MIS_DISCOUNT_RATE = "";
        }
        if (MIS_DISCOUNT_CHARGES != "" && MIS_DISCOUNT_CHARGES != "0")
        {
            MIS_DISCOUNT_CHARGES = MIS_DISCOUNT_CHARGES + " " + MIS_DISCOUNT_CURRENCY + " " + MIS_DISCOUNT_EXRATE;
        }
        else
        {
            MIS_DISCOUNT_CHARGES = "";
        }
        // ITem(ddlJobNo, i);
        INVOICE_EXRATE = Return_Zero_Value1(row["INVOICE_EXRATE"].ToString());
        // if (INVOICE_EXRATE != "")


        if (INVOICE_CURRENCY == "JPY" || INVOICE_CURRENCY == "KRW")
        {
            INVOICE_EXCHANGERATE = "100" + " " + INVOICE_CURRENCY + "=" + INVOICE_EXRATE + " " + "INR";
        }
        else
        {
            INVOICE_EXCHANGERATE = "1.00" + " " + INVOICE_CURRENCY + "=" + INVOICE_EXRATE + " " + "INR";
        }

        //INVOICE_EXCHANGERATE = "1.00" + " " + INVOICE_CURRENCY + "=" + INVOICE_EXRATE + " " + "INR";
        ///else
        // INVOICE_EXRATE = "1.00" + " " + INVOICE_CURRENCY + "=" + "0" + " " + "INR";

        //Invoice Details
        INVOICE_ID = row["INVOICE_ID"].ToString();

        TERMS_PLACE = row["TERMS_PLACE"].ToString();
        THIRDPARTY_NAME = row["THIRDPARTY_NAME"].ToString();
        THIRDPARTY_ADD1 = row["THIRDPARTY_ADD1"].ToString();
        THIRDPARTY_ADD2 = row["THIRDPARTY_ADD2"].ToString();
        THIRDPARTY_CITY = row["THIRDPARTY_CITY"].ToString();
        T_PARTY_COUNTRY_SUB_DIV = row["T_PARTY_COUNTRY_SUB_DIV"].ToString();

        T_PARTY_COUNTRY_CODE = row["T_PARTY_COUNTRY_CODE"].ToString();
        T_PARTY_PIN = row["T_PARTY_PIN"].ToString();
        AUTHORIZED_ECONOMIC_OPERATOR_CODE = row["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString();
        A_E_O_COUNTRY = row["A_E_O_COUNTRY"].ToString();
        AUTHORIZED_ECONOMIC_OPERATOR = row["AUTHORIZED_ECONOMIC_OPERATOR"].ToString();
        WHETHER_BUYER_SELLER_RELATED = row["WHETHER_BUYER_SELLER_RELATED"].ToString();

        //if (Session["COMPANY_ID"].ToString() == "227" || Session["COMPANY_ID"].ToString() == "194")

        if (Session["COMPANY_ID"].ToString() == "227" || Session["COMPANY_ID"].ToString() == "353")
        {
            MIS_HIGHSEASALE_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(INDIVITUAL_HSS_AMOUNT), 2));
        }

        if (MIS_HIGHSEASALE_CHARGES != "0" && MIS_HIGHSEASALE_CHARGES != "")
        {
            MIS_HIGHSEASALE_CHARGES = MIS_HIGHSEASALE_CHARGES + " " + MIS_HIGHSEASALE_CURRENCY + " " + MIS_HIGHSEASALE_EXRATE;
        }
        else
        {
            MIS_HIGHSEASALE_CHARGES = "";
        }

        Load_Invoice_Details.Add(new INVOICE_DETAILS()
        {
            INVOICE_ID = INVOICE_ID,

            INVOICE_EXRATE = INVOICE_EXCHANGERATE,

            Invoice_Details = Convert.ToString(count),
            FIRSTCHECK = FIRSTCHECK,
            GREEN_CHANNEL = GREEN_CHANNEL,
            KACHHA_BE = KACHHA_BE,
            SECTION48 = SECTION48,

            //INVOICE_NO = row["INVOICE_NO"].ToString(),
            INVOICE_NO = row["INVOICE_NO"].ToString(),
            INVOICE_SLNO = INVOICE_SLNO,
            INVOICE_DATE = INVOICE_DATE,
            INVOICE_VALUE = Invoice_value,
            TERMS = row["TERMS"].ToString(),
            INVOICE_CURRENCY = row["INVOICE_CURRENCY"].ToString(),
            SUPPLIER_NAME = row["SUPPLIER_NAME"].ToString(),
            SUPPLIER_ADDRESS = row["SUPPLIER_ADDRESS"].ToString(),
            SUPPLIER_ADDRESS1 = row["SUPPLIER_ADDRESS1"].ToString(),
            SUPPLIER_ADDRESS2 = row["SUPPLIER_ADDRESS2"].ToString(),
            SUPPLIER_COUNTRY_NAME = SupplierCountry_Name_Pincode,

            MIS_FREIGHT_CHARGES = MIS_FREIGHT_CHARGES,

            MIS_INSURANCE_CHARGES = MIS_INSURANCE_CHARGES,

            SVB_RELATION = row["SVB_RELATION"].ToString(),
            SVB_REF_NO = row["SVB_REF_NO"].ToString(),
            SVB_REF_DATE = SVB_REF_DATE,

            SVB_ASSESABLE_RATE = SVB_ASSESABLE_RATE,
            SVB_DUTY_RATE = SVB_DUTY_RATE,

            SVB_LOADING_ON = SVB_LOADING_ON,
            SVB_ASSESABLE_STATUS = row["SVB_ASSESABLE_STATUS"].ToString(),
            SVB_DUTY_STATUS = row["SVB_DUTY_STATUS"].ToString(),

            SVB_CUSTOM_HOUSE = row["SVB_CUSTOM_HOUSE"].ToString(),

            MIS_CHARGES_ = Return_Zero_Value(MIS_CHARGES),

            MIS_CURRENCY = row["MIS_CURRENCY"].ToString(),

            MIS_CHARGES = MIS_CHARGES_Add,
            MIS_RATE = Return_Zero_Value(row["MIS_RATE"].ToString()),
            MIS_EXRATE = MIS_EXRATE,
            MIS_HIGHSEASALE_RATE = MIS_HIGHSEASALE_RATE,
            MIS_HIGHSEASALE_CHARGES = MIS_HIGHSEASALE_CHARGES,

            MIS_LOADING_CHARGES = MIS_LOADING_CHARGES,
            MIS_DISCOUNT_RATE = MIS_DISCOUNT_RATE,
            MIS_DISCOUNT_CHARGES = MIS_DISCOUNT_CHARGES,

            TERMS_PLACE = TERMS_PLACE,
            THIRDPARTY_NAME = THIRDPARTY_NAME,
            THIRDPARTY_ADD1 = THIRDPARTY_ADD1,
            THIRDPARTY_ADD2 = THIRDPARTY_ADD2,
            THIRDPARTY_CITY = THIRDPARTY_CITY,
            T_PARTY_COUNTRY_SUB_DIV = T_PARTY_COUNTRY_SUB_DIV,

            T_PARTY_COUNTRY_CODE = T_PARTY_COUNTRY_CODE,
            T_PARTY_PIN = T_PARTY_PIN,
            AUTHORIZED_ECONOMIC_OPERATOR_CODE = AUTHORIZED_ECONOMIC_OPERATOR_CODE,
            A_E_O_COUNTRY = A_E_O_COUNTRY,
            AUTHORIZED_ECONOMIC_OPERATOR = AUTHORIZED_ECONOMIC_OPERATOR,
            WHETHER_BUYER_SELLER_RELATED = WHETHER_BUYER_SELLER_RELATED

        });
    }


    public DataSet GET_ALL_NOTIFICATIONS_RATE(DataTable dt_all)
    {
        UserBO ObjUBO = new UserBO();

        System.Data.DataView view = new System.Data.DataView(dt_all);
        System.Data.DataTable selected = view.ToTable("Selected", true, "PRODUCT_CTH", "PRODUCT_CETH", "PRODUCT_BCD_NOTN"
            , "PRODUCT_BCD_SLNO", "PRODUCT_TARIFF_NOTN", "PRODUCT_TARIFF_SLNO", "PRODUCT_SAFEGUARD_NOTN", "PRODUCT_SAFEGUARD_SLNO", "PRODUCT_SAPTA_NOTN", "PRODUCT_SAPTA_SLNO"
            , "PRODUCT_AGGREGATE_DUTY_NOTN", "PRODUCT_AGGREGATE_DUTY_NOTN_SL", "IGST_LEVY_NOTN", "IGST_LEVY_SLNO", "IGST_LEVY_EXCEPTION_NOTN", "IGST_LEVY_EXCEPTION_SLNO"
            , "IGST_LEVY_COMPENSATION_CESS_NOTN", "IGST_LEVY_COMPENSATION_CESS_SLNO", "IGST_LEVY_EXCEPTION_CC_NOTN", "IGST_LEVY_EXCEPTION_CC_SLNO", "PRODUCT_CVD_NOTN"
            , "PRODUCT_CVD_SLNO", "SCHEME_CODE", "SCHEME_NOTN", "SCHEME_NOTN_SLNO", "ANTI_DUMPING_NOTN", "ANTI_DUMPING_NOTN_SLNO", "CTH_SLNO", "CTH_SUPPLIER_SLNO", "SOCIAL_WELFARE_NOTN", "SOCIAL_WELFARE_NOTN_SLNO");

        ObjUBO.Xml_D = ConvertDataTableToXML(selected);
        ObjUBO.flag = "Get_Notification_Rate";
        dt_All_Rates = IC.Get_Notifications_Rate(ObjUBO);

        return dt_All_Rates;
    }





    public void Get_ITEM_Details_new(string ddlJobNo, DataTable ds, DataTable ds3, DataTable dt_ReImport)
    {
        try
        {
            //-----------------------------------------------------------


            ViewState["Checklist_Value"] = "";
            DataTable dtt = new DataTable();
            DataRow dr;


            DataSet dssEmpty = IC.GetData_ChkListNew(ddlJobNo, "", "EmptyChklistStr");
            dtt = dssEmpty.Tables[0];

            //------------------------------------------------------------
            Transaction Transact = new Transaction();
            DataTable dt_error = new DataTable();
            DataTable ds_RE_IMPORT = new DataTable();

            dt_error = dssEmpty.Tables[1];

            Load_Item_Details.Clear();

            TRANSPORT_MODE = TRANSPORT_MODE;

            CHECK_FREIGHT_EXRATE = 20;
            int b = 0, C = 0;

            double TOTAL_ITEM = 0.0;
            string curINVOICE_SLNO = "0";

            while (ds.Rows.Count > C) //  main no of invoices looop  3-5 invoices
            {
                NUMBERTOWORDS = "";
                curINVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
                INVOICE_VALUE = Return_Zero_Value1(ds.Rows[C]["INVOICE_VALUE"].ToString());
                INVOICE_CURRENCY = Return_Zero_Value1(ds.Rows[C]["INVOICE_CURRENCY"].ToString());

                TERMS = Return_Zero_Value1(ds.Rows[C]["TERMS"].ToString());
                INVOICE_EXRATE = Return_ExRate_Value(ds.Rows[C]["INVOICE_CURRENCY"].ToString(), ds.Rows[C]["INVOICE_EXRATE"].ToString());
                MIS_FREIGHT_RATE = Return_Zero_Value1(ds.Rows[C]["MIS_FREIGHT_RATE"].ToString());
                MIS_FREIGHT_CHARGES = Return_Zero_Value1(ds.Rows[C]["MIS_FREIGHT_CHARGES"].ToString());
                MIS_FREIGHT_EXRATE = Return_ExRate_Value(ds.Rows[C]["MIS_FREIGHT_CURRENCY"].ToString(), ds.Rows[C]["MIS_FREIGHT_EXRATE"].ToString());
                MIS_INSURANCE_CHARGES = Return_Zero_Value1(ds.Rows[C]["MIS_INSURANCE_CHARGES"].ToString());
                MIS_INSURANCE_EXRATE = Return_ExRate_Value(ds.Rows[C]["MIS_INSURANCE_CURRENCY"].ToString(), ds.Rows[C]["MIS_INSURANCE_EXRATE"].ToString());

                MIS_INSURANCE_RATE = Return_Zero_Value1(ds.Rows[C]["MIS_INSURANCE_RATE"].ToString());

                ASSESSABLE_TOTAL = 0;
                TOTAL_ITEM = 0.0;
                TOTAL_DUTY = 0.0;
                b = 0;
                SVB_ASSESABLE_RATE = Return_Zero_Value(ds.Rows[C]["SVB_ASSESABLE_RATE"].ToString());

                MIS_EXRATE = Return_ExRate_Value(ds.Rows[C]["MIS_CURRENCY"].ToString(), ds.Rows[C]["MIS_EXRATE"].ToString());
                MIS_RATE = Return_Zero_Value(ds.Rows[C]["MIS_RATE"].ToString());
                MIS_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_CHARGES"].ToString());
                MIS_CURRENCY = Return_Zero_Value(ds.Rows[C]["MIS_CURRENCY"].ToString());

                MIS_HIGHSEASALE_RATE = Return_Zero_Value(ds.Rows[C]["MIS_HIGHSEASALE_RATE"].ToString());
                MIS_HIGHSEASALE_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_HIGHSEASALE_CHARGES"].ToString());
                MIS_HIGHSEASALE_CURRENCY = ds.Rows[C]["MIS_HIGHSEASALE_CURRENCY"].ToString();
                MIS_HIGHSEASALE_EXRATE = Return_ExRate_Value(MIS_HIGHSEASALE_CURRENCY, ds.Rows[C]["MIS_HIGHSEASALE_EXRATE"].ToString());
                MIS_LOADING_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_LOADING_CHARGES"].ToString());
                MIS_LOADING_CURRENCY = ds.Rows[C]["MIS_LOADING_CURRENCY"].ToString();
                MIS_LOADING_EXRATE = Return_ExRate_Value(MIS_LOADING_CURRENCY, ds.Rows[C]["MIS_LOADING_EXRATE"].ToString());
                MIS_DISCOUNT_RATE = Return_Zero_Value(ds.Rows[C]["MIS_DISCOUNT_RATE"].ToString());
                MIS_DISCOUNT_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_DISCOUNT_CHARGES"].ToString());
                MIS_DISCOUNT_CURRENCY = ds.Rows[C]["MIS_DISCOUNT_CURRENCY"].ToString();
                MIS_DISCOUNT_EXRATE = Return_ExRate_Value(MIS_DISCOUNT_CURRENCY, ds.Rows[C]["MIS_DISCOUNT_EXRATE"].ToString());

                string MIS_Dscount_RATE = MIS_DISCOUNT_RATE.Substring(0, 1);

                REVENUEDEPOSIT_RATE = ds.Rows[C]["REVENUEDEPOSIT_RATE"].ToString();
                REVENUEDEPOSIT_ON = ds.Rows[C]["REVENUEDEPOSIT_ON"].ToString();

                D_AMOUNT = Return_Zero_Value(ds.Rows[C]["D_AMOUNT"].ToString());
                M_AMOUNT = Return_Zero_Value(ds.Rows[C]["M_AMOUNT"].ToString());
                N_AMOUNT = Return_Zero_Value(ds.Rows[C]["N_AMOUNT"].ToString());

                DataSet dss = new DataSet();
                dss.Clear();
                dss = IC.GetData_ChkListNew(ddlJobNo, curINVOICE_SLNO, "ITEM");

                ITEM_TOTAL = 0;

                GET_ALL_NOTIFICATIONS_RATE(dss.Tables[0]);

                while (dss.Tables[0].Rows.Count > b)
                {
                    SCHED11_TOTAL = "0.00";
                    IGST_LEVY_TOTAL = "0.00";
                    IGST_LEVY_COMPENSATION_CESS_TOTAL = "0.00";

                    IGST_LEVY_COMPENSATION_CESS_RATE = "";
                    IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE = "";

                    INVOICE_NO_ITEM = dss.Tables[0].Rows[b]["INVOICE_NO"].ToString();
                    INVOICE_SLNO = Convert.ToInt32(dss.Tables[0].Rows[b]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dss.Tables[0].Rows[b]["ITEM_SLNO"].ToString();
                    //ITEM_DESCRIPTION = dss.Tables[0].Rows[b]["ITEM_DESCRIPTION"].ToString();


                    if (dss.Tables[0].Rows[b]["COUNTRY_OF_ORIGIN_NEW"].ToString() != "")
                        COUNTRY_OF_ORIGIN = dss.Tables[0].Rows[b]["COUNTRY_OF_ORIGIN_NEW"].ToString();
                    else
                        COUNTRY_OF_ORIGIN = dss.Tables[0].Rows[b]["COUNTRY_OF_ORIGIN"].ToString();

                    END_USE_OF_ITEM = dss.Tables[0].Rows[b]["END_USE_OF_ITEM"].ToString();

                    ITEM_QTY = dss.Tables[0].Rows[b]["ITEM_QTY"].ToString();
                    ITEM_QTY_CODE = dss.Tables[0].Rows[b]["ITEM_QTY_CODE"].ToString();
                    ITEM_UNIT_PRICE = dss.Tables[0].Rows[b]["ITEM_UNIT_PRICE"].ToString();
                    CTH_NO = dss.Tables[0].Rows[b]["CTH_NO"].ToString();
                    PRODUCT_RITC = dss.Tables[0].Rows[b]["PRODUCT_RITC"].ToString();
                    PRODUCT_CTH = dss.Tables[0].Rows[b]["PRODUCT_CTH"].ToString();
                    PRODUCT_CVD_RATE = dss.Tables[0].Rows[b]["PRODUCT_CVD_RATE"].ToString();
                    PRODUCT_EDU_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_EDU_CESS_RATE"].ToString();

                    PRODUCT_SEC_EDU_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();
                    PRODUCT_SEC_EDU_CESS_NOTN = dss.Tables[0].Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();

                    PRODUCT_SEC_EDU_CESS_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();

                    PRODUCT_BCD_RATE = dss.Tables[0].Rows[b]["PRODUCT_BCD_RATE"].ToString();
                    PRODUCT_CETH = dss.Tables[0].Rows[b]["PRODUCT_CETH"].ToString();
                    PRODUCT_BCD_NOTN = dss.Tables[0].Rows[b]["PRODUCT_BCD_NOTN"].ToString();
                    PRODUCT_BCD_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_BCD_SLNO"].ToString();

                    PRODUCT_BCD_SPL = dss.Tables[0].Rows[b]["PRODUCT_BCD_SPL"].ToString();

                    PRODUCT_CVD_NOTN = dss.Tables[0].Rows[b]["PRODUCT_CVD_NOTN"].ToString();
                    PRODUCT_CVD_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_CVD_SLNO"].ToString();

                    PRODUCT_CVD_SPL = dss.Tables[0].Rows[b]["PRODUCT_CVD_SPL"].ToString();

                    PRODUCT_EDU_CESS_NOTN = dss.Tables[0].Rows[b]["PRODUCT_EDU_CESS_NOTN"].ToString();
                    PRODUCT_EDU_CESS_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                    PRODUCT_ADDL_DUTY_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                    PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN.Trim();
                    PRODUCT_ADDL_DUTY_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
                    PRODUCT_ADDL_DUTY_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_DUTY_RATE"].ToString();

                    //----------------------------------------------------//
                    PRODUCT_ADDL_SHEII_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL_SHEII_NOTN"].ToString();
                    PRODUCT_ADDL_SHEII_SLNO = dss.Tables[0].Rows[b]["PRODUCT_ADDL_SHEII_SLNO"].ToString();
                    PRODUCT_ADDL_SHEII_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_SHEII_RATE"].ToString();
                    //----------------------------------------------------//

                    //----------------------------------------------------//
                    PRODUCT_ADDL_TTA_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL_TTA_NOTN"].ToString();
                    PRODUCT_ADDL_TTA_SLNO = dss.Tables[0].Rows[b]["PRODUCT_ADDL_TTA_SLNO"].ToString();
                    PRODUCT_ADDL_TTA_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_TTA_RATE"].ToString();
                    //----------------------------------------------------//

                    PRODUCT_ADDL_GSI_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL_GSI_NOTN"].ToString();
                    PRODUCT_ADDL_GSI_SLNO = dss.Tables[0].Rows[b]["PRODUCT_ADDL_GSI_SLNO"].ToString();
                    PRODUCT_ADDL_GSI_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_GSI_RATE"].ToString();

                    //----------------------------------------------------//

                    PRODUCT_CVD_EDU_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_CVD_EDU_CESS_RATE"].ToString();

                    PRODUCT_CVD_SEC_EDU_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString();
                    CETH_CVD_EDU_CESS_SL = dss.Tables[0].Rows[b]["CETH_CVD_EDU_CESS_SL"].ToString();
                    CETH_CVD_EDU_CESS_RATE = dss.Tables[0].Rows[b]["CETH_CVD_EDU_CESS_RATE"].ToString();
                    CETH_CVD_SEC_EDU_CESS_SL = dss.Tables[0].Rows[b]["CETH_CVD_SEC_EDU_CESS_SL"].ToString();
                    CETH_CVD_SEC_EDU_CESS_RATE = dss.Tables[0].Rows[b]["CETH_CVD_SEC_EDU_CESS_RATE"].ToString();

                    //---------------------NCD-------------------------------//

                    PRODUCT_NCD_NOTN = dss.Tables[0].Rows[b]["PRODUCT_NCD_NOTN"].ToString();
                    PRODUCT_NCD_SLNO = dss.Tables[0].Rows[b]["PRODUCT_NCD_SLNO"].ToString();
                    PRODUCT_NCD_RATE = dss.Tables[0].Rows[b]["PRODUCT_NCD_RATE"].ToString();
                    //PRODUCT_NCD_SPL = dss.Tables[0].Rows[b]["PRODUCT_NCD_SPL"].ToString();
                    //PRODUCT_NCD_UNIT = dss.Tables[0].Rows[b]["PRODUCT_NCD_UNIT"].ToString();
                    //PRODUCT_NCD_SPL_TYPE = dss.Tables[0].Rows[b]["PRODUCT_NCD_SPL_TYPE"].ToString();

                    //--------------------END NCD----------------------------//

                    //---------------------TARIFF-------------------------------//

                    PRODUCT_TARIFF_NOTN = dss.Tables[0].Rows[b]["PRODUCT_TARIFF_NOTN"].ToString();
                    PRODUCT_TARIFF_SLNO = dss.Tables[0].Rows[b]["PRODUCT_TARIFF_SLNO"].ToString();
                    PRODUCT_TARIFF_QTY = dss.Tables[0].Rows[b]["PRODUCT_TARIFF_QTY"].ToString();
                    PRODUCT_TARIFF_AMOUNT = dss.Tables[0].Rows[b]["PRODUCT_TARIFF_AMOUNT"].ToString();
                    PRODUCT_TARIFF_AMOUNT_UNIT = dss.Tables[0].Rows[b]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString();

                    if (PRODUCT_TARIFF_NOTN.Trim() == "36/2001" && PRODUCT_TARIFF_SLNO.Trim() == "2(1)A")
                    {
                        if (PRODUCT_TARIFF_QTY == "")
                        {
                            PRODUCT_TARIFF_QTY = "0.00";
                        }
                    }
                    else
                    {
                        if (PRODUCT_TARIFF_QTY == "")
                        {
                            PRODUCT_TARIFF_QTY = ITEM_QTY;
                        }
                    }

                    //--------------------END TARIFF----------------------------//

                    //---------------------SAPTA-------------------------------//

                    PRODUCT_SAPTA_NOTN = dss.Tables[0].Rows[b]["PRODUCT_SAPTA_NOTN"].ToString();
                    PRODUCT_SAPTA_SLNO = dss.Tables[0].Rows[b]["PRODUCT_SAPTA_SLNO"].ToString();
                    PRODUCT_SAPTA_RATE = dss.Tables[0].Rows[b]["PRODUCT_SAPTA_RATE"].ToString();

                    //--------------------END SAPTA----------------------------//

                    PRODUCT_SAFEGUARD_NOTN = dss.Tables[0].Rows[b]["PRODUCT_SAFEGUARD_NOTN"].ToString();
                    PRODUCT_SAFEGUARD_SLNO = dss.Tables[0].Rows[b]["PRODUCT_SAFEGUARD_SLNO"].ToString();
                    PRODUCT_SAFEGUARD_RATE = dss.Tables[0].Rows[b]["PRODUCT_SAFEGUARD_RATE"].ToString();

                    PRODUCT_AGGREGATE_DUTY_NOTN = dss.Tables[0].Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
                    PRODUCT_AGGREGATE_DUTY_NOTN_SL = dss.Tables[0].Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
                    PRODUCT_AGGREGATE_DUTY_NOTN_RATE = dss.Tables[0].Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString();


                    PRODUCT_MRP_YN = dss.Tables[0].Rows[b]["PRODUCT_MRP_YN"].ToString();

                    ITEM_DESCRIPTION = dss.Tables[0].Rows[b]["ITEM_DESCRIPTION"].ToString();

                    PRODUCT_MRP_SL_NO = dss.Tables[0].Rows[b]["PRODUCT_MRP_SL_NO"].ToString();
                    PRODUCT_MRP_AMOUNT = dss.Tables[0].Rows[b]["PRODUCT_MRP_AMOUNT"].ToString();
                    PRODUCT_MRP_ABT_RATE = dss.Tables[0].Rows[b]["PRODUCT_MRP_ABT_RATE"].ToString();

                    RSP_APPLICABLE = dss.Tables[0].Rows[b]["RSP_APPLICABLE"].ToString();


                    //------------Start Other CVD Duty 02June2015-------------------//

                    PRODUCT_OTHER_DUTY_NOTN = dss.Tables[0].Rows[b]["PRODUCT_OTHER_DUTY_NOTN"].ToString();
                    PRODUCT_OTHER_DUTY_SLNO = dss.Tables[0].Rows[b]["PRODUCT_OTHER_DUTY_SLNO"].ToString();
                    PRODUCT_OTHER_DUTY_RATE = dss.Tables[0].Rows[b]["PRODUCT_OTHER_DUTY_RATE"].ToString();
                    PRODUCT_OTHER_DUTY_SPL = dss.Tables[0].Rows[b]["PRODUCT_OTHER_DUTY_SPL"].ToString();
                    PRODUCT_OTHER_DUTY_UNIT = dss.Tables[0].Rows[b]["PRODUCT_OTHER_DUTY_UNIT"].ToString();
                    PRODUCT_OTHER_DUTY_TYPE = dss.Tables[0].Rows[b]["PRODUCT_OTHER_DUTY_TYPE"].ToString();

                    //--------------End Other CVD Duty 02June2015-------------------//

                    //-----------Start Infra Cess 18May2016-----------------//

                    ////INFRA_CESS_NOTN = dss.Tables[0].Rows[b]["INFRA_CESS_NOTN"].ToString();
                    ////INFRA_CESS_NOTN_SL = dss.Tables[0].Rows[b]["INFRA_CESS_NOTN_SL"].ToString();
                    ////INFRA_CESS_NOTN_RATE = dss.Tables[0].Rows[b]["INFRA_CESS_NOTN_RATE"].ToString();

                    //-----------End Infra Cess 18May2016-----------------//

                    //------------ITEMWISE SVB DETAILS FOR NIPPON EXPRESS ON 29FEB2016-------------------//

                    ITEM_SVB_RELATION = dss.Tables[0].Rows[b]["SVB_RELATION"].ToString();
                    ITEM_SVB_REF_NO = dss.Tables[0].Rows[b]["SVB_REF_NO"].ToString();
                    ITEM_SVB_REF_DATE = dss.Tables[0].Rows[b]["SVB_REF_DATE"].ToString();
                    ITEM_SVB_CUSTOM_HOUSE = dss.Tables[0].Rows[b]["SVB_CUSTOM_HOUSE"].ToString();
                    ITEM_SVB_LOADING_ON = dss.Tables[0].Rows[b]["SVB_LOADING_ON"].ToString();
                    ITEM_SVB_ASSESABLE_RATE = dss.Tables[0].Rows[b]["SVB_ASSESABLE_RATE"].ToString();

                    ITEM_SVB_DUTY_RATE = dss.Tables[0].Rows[b]["SVB_DUTY_RATE"].ToString();
                    ITEM_SVB_ASSESABLE_STATUS = dss.Tables[0].Rows[b]["SVB_ASSESABLE_STATUS"].ToString();

                    ITEM_SVB_DUTY_STATUS = dss.Tables[0].Rows[b]["SVB_DUTY_STATUS"].ToString();

                    //--------------ITEMWISE SVB DETAILS FOR NIPPON EXPRESS ON 29FEB2016-------------------//           


                    //------------GST  IMPLEMENTATION ON 30JUNE2017-------------------//

                    IGST_LEVY_NOTN = dss.Tables[0].Rows[b]["IGST_LEVY_NOTN"].ToString();
                    IGST_LEVY_SLNO = dss.Tables[0].Rows[b]["IGST_LEVY_SLNO"].ToString();
                    IGST_LEVY_RATE = dss.Tables[0].Rows[b]["IGST_LEVY_RATE"].ToString() == "" ? "0" : dss.Tables[0].Rows[b]["IGST_LEVY_RATE"].ToString();

                    IGST_LEVY_EXCEPTION_NOTN = dss.Tables[0].Rows[b]["IGST_LEVY_EXCEPTION_NOTN"].ToString();
                    IGST_LEVY_EXCEPTION_SLNO = dss.Tables[0].Rows[b]["IGST_LEVY_EXCEPTION_SLNO"].ToString();
                    IGST_LEVY_EXCEPTION_RATE = dss.Tables[0].Rows[b]["IGST_LEVY_EXCEPTION_RATE"].ToString();
                    IGST_LEVY_COMPENSATION_CESS_NOTN = dss.Tables[0].Rows[b]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString();
                    IGST_LEVY_COMPENSATION_CESS_SLNO = dss.Tables[0].Rows[b]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString();
                    IGST_LEVY_COMPENSATION_CESS_RATE = dss.Tables[0].Rows[b]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString();
                    IGST_LEVY_EXCEPTION_CC_NOTN = dss.Tables[0].Rows[b]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString();
                    IGST_LEVY_EXCEPTION_CC_SLNO = dss.Tables[0].Rows[b]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString();
                    IGST_LEVY_EXCEPTION_CC_RATE = dss.Tables[0].Rows[b]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString();

                    LEVY_EXCEMPTION_NOTN_TYPE = dss.Tables[0].Rows[b]["LEVY_EXCEMPTION_NOTN_TYPE"].ToString();
                    LEVY_EXCEPTION_CC_NOTN_TYPE = dss.Tables[0].Rows[b]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString();

                    SOCIAL_WELFARE_NOTN = dss.Tables[0].Rows[b]["SOCIAL_WELFARE_NOTN"].ToString();
                    SOCIAL_WELFARE_NOTN_SLNO = dss.Tables[0].Rows[b]["SOCIAL_WELFARE_NOTN_SLNO"].ToString();
                    SOCIAL_WELFARE_RATE = dss.Tables[0].Rows[b]["SOCIAL_WELFARE_RATE"].ToString();

                    //--------------GST  IMPLEMENTATION ON 30JUNE2017-------------------//                              


                    PRODUCT_BCD_RATE_UPDATE = "";
                    PRODUCT_CVD_RATE_UPDATE = "";
                    //-----------------Start Country of Origin on 04May2017 (For VSM Logistics)------------------------//

                    //commented by jayanthi on 29jun18
                    //DataView view1_Coo = dss_Coo.Tables[0].DefaultView;

                    //view1_Coo = dss_Coo.Tables[0].DefaultView;
                    //view1_Coo.RowFilter = "COUNTRY_NAME = '" + COUNTRY_OF_ORIGIN + "'";
                    //DataSet dt_1 = new DataSet();
                    //dt_1.Tables.Add(view1_Coo.ToTable());
                    //if (dt_1.Tables[0].Rows.Count > 0)
                    //{
                    //    COUNTRY_OF_ORIGIN = dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
                    //}

                    //-----------------End Country of Origin on 04May2017 (For VSM Logistics)--------------------------//

                    //----------Start RSP Calculation on 06Sep2018-------------//

                    if (RSP_APPLICABLE == "S")
                    {
                        if (PRODUCT_MRP_AMOUNT != "")
                        {
                            if (Convert.ToDouble(PRODUCT_MRP_AMOUNT) > 0.00)
                            {
                                MRP_AMT = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_MRP_AMOUNT);
                            }
                        }
                    }

                    //----------End RSP Calculation on 06Sep2018-------------//

                    SCHEME_CODE = dss.Tables[0].Rows[b]["SCHEME_CODE"].ToString();
                    SCHEME_NOTN = dss.Tables[0].Rows[b]["SCHEME_NOTN"].ToString();
                    SCHEME_NOTN_SLNO = dss.Tables[0].Rows[b]["SCHEME_NOTN_SLNO"].ToString();

                    CTH_QTY1 = dss.Tables[0].Rows[b]["CTH_QTY1"].ToString();
                    CTH_QTY1_CODE = dss.Tables[0].Rows[b]["CTH_QTY1_CODE"].ToString();

                    if (CTH_QTY1 == "")
                    {
                        CTH_QTY1 = "0";
                    }

                    if (PRODUCT_BCD_NOTN != "")
                    {
                        BCD_NOTN = PRODUCT_BCD_NOTN;
                        PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN + " " + PRODUCT_BCD_NOTN_SLNO;
                    }
                    if (PRODUCT_CVD_NOTN != "")
                    {
                        CVD_NOTN = PRODUCT_CVD_NOTN;
                        PRODUCT_CVD_NOTN = PRODUCT_CVD_NOTN + " " + PRODUCT_CVD_NOTN_SLNO;
                    }

                    if (PRODUCT_EDU_CESS_NOTN != "")
                    {
                        EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN;
                        PRODUCT_EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN + " " + PRODUCT_EDU_CESS_NOTN_SLNO;
                    }
                    else
                    {
                        EDU_CESS_NOTN = "";
                    }
                    if (PRODUCT_SEC_EDU_CESS_NOTN != "")
                    {
                        SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN;
                        PRODUCT_SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN + " " + PRODUCT_SEC_EDU_CESS_NOTN_SLNO;
                    }

                    if (PRODUCT_BCD_SPL != "")
                    {
                        if (Convert.ToDouble(PRODUCT_BCD_SPL) < 0)
                        {
                            PRODUCT_BCD_SPL = "";
                        }
                    }

                    //---------End After Customs Updation on 28Feb2015-------------//

                    //------------End CVD New Edu Cess Calculation------------------//

                    if (SCHEME_CODE != "")
                    {
                        string[] s1 = SCHEME_CODE.Split(new string[] { "-" }, StringSplitOptions.None);
                        SCHEME_CODE = s1[0].ToString();
                        SCHEME_NOTN_ = s1[1].ToString();
                    }
                    else
                    {
                        SCHEME_NOTN_ = "0";
                    }

                    //--------------------- 5-Nov-2015  ---------------------//
                    ASSESABLE_VALUE = Get_Indivitual_Assesable_Value(dt_ReImport, INVOICE_SLNO, INVOICE_NO_ITEM, ITEM_SLNO);

                    //--------------------- 5-Nov-2015  ---------------------//

                    // --------------------------------------- Anti-Dumping Calculation-------------------------------------------------------

                    ANTI_DUMPING_NOTN = dss.Tables[0].Rows[b]["ANTI_DUMPING_NOTN"].ToString();
                    ANTI_DUMPING_NOTN_SLNO = dss.Tables[0].Rows[b]["ANTI_DUMPING_NOTN_SLNO"].ToString();
                    CTH_SLNO = dss.Tables[0].Rows[b]["CTH_SLNO"].ToString();
                    CTH_SUPPLIER_SLNO = dss.Tables[0].Rows[b]["CTH_SUPPLIER_SLNO"].ToString();
                    CTH_QTY = dss.Tables[0].Rows[b]["CTH_QTY"].ToString();

                    // ******************* CALL ANTI_DUMPING_CALC METHOD *******************************
                    Notn_ANTI_DUMPING_CALC(dt_error);

                    // --------------------------------------- End Anti-Dumping --------------------------------------------------------------

                    if (PRODUCT_EDU_CESS_RATE == "")
                    {
                        PRODUCT_EDU_CESS_RATE = "2.00";
                    }
                    if (PRODUCT_SEC_EDU_CESS_RATE == "")
                    {
                        PRODUCT_SEC_EDU_CESS_RATE = "1.00";
                    }
                    //if (SOCIAL_WELFARE_RATE == "")
                    //{
                    //    SOCIAL_WELFARE_RATE = "10.00";
                    //}

                    ////-----------------------End Additional Duty Details Hided on 11Sep2017 due to Out Of Memory problem-----------------------------------//

                    //string[] arr = { "DEEC", "REP", "DIL", "JBG", "EOU", "DUTIABLE" };
                    //string[] arr1 = { "DEPB", "DFRC", "DFCC", "TRG+", "(KRSH)", "DFCS", "DFIA", "FMS", "FPS", "SHIS", "MEIS", "INC", "SEIS" };
                    //string[] arr2 = { "EPCG" };


                    if (SCHEME_NOTN_ != "")
                    {
                        adminmaster adm_Mas = new adminmaster();

                        //******************************* GET IGST_LEVY_NOTN_RATE START*****************************// CHK SPEEDUP EDITED FILTER_RATES

                        if (dt_All_Rates.Tables[3].Rows.Count > 0)
                        {
                            if (IGST_LEVY_NOTN != "" && IGST_LEVY_SLNO != "")
                            {
                                var FullName1 = from DataRow drr in dt_All_Rates.Tables[3].AsEnumerable()
                                                where drr.Field<string>("NOTIFICATION_EXCISE_NOTN") == IGST_LEVY_NOTN && drr.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == IGST_LEVY_SLNO
                                                select drr;

                                DataView dvv = FullName1.AsDataView();

                                if (dvv.Count > 0)
                                {
                                    DataTable Get_JobNo = FullName1.CopyToDataTable();
                                    IGST_LEVY_RATE = Get_JobNo.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                                    IGST_LEVY_RATE_UPDATE = Get_JobNo.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                                }
                            }
                        }

                        //******************************* GET IGST_LEVY_EXCEPTION_CESS_RATE START*****************************

                        if (dt_All_Rates.Tables[4].Rows.Count > 0)
                        {
                            if (IGST_LEVY_EXCEPTION_NOTN != "" && IGST_LEVY_EXCEPTION_SLNO != "")
                            {
                                var FullName1 = from DataRow drr in dt_All_Rates.Tables[4].AsEnumerable()
                                                where drr.Field<string>("NOTIFICATION_EXCISE_NOTN") == IGST_LEVY_EXCEPTION_NOTN && drr.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == IGST_LEVY_EXCEPTION_SLNO
                                                select drr;

                                DataView dvv = FullName1.AsDataView();

                                if (dvv.Count > 0)
                                {
                                    DataTable Get_JobNo = FullName1.CopyToDataTable();
                                    IGST_LEVY_EXCEPTION_RATE = Get_JobNo.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                                }
                            }
                        }

                        //******************************* GET IGST_LEVY_EXCEPTION_CESS_RATE START *****************************

                        if (dt_All_Rates.Tables[5].Rows.Count > 0)
                        {
                            if (IGST_LEVY_COMPENSATION_CESS_NOTN != "" && IGST_LEVY_COMPENSATION_CESS_SLNO != "")
                            {
                                var FullName1 = from DataRow drr in dt_All_Rates.Tables[5].AsEnumerable()
                                                where drr.Field<string>("NOTIFICATION_EXCISE_NOTN") == IGST_LEVY_COMPENSATION_CESS_NOTN && drr.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == IGST_LEVY_COMPENSATION_CESS_SLNO
                                                select drr;

                                DataView dvv = FullName1.AsDataView();

                                if (dvv.Count > 0)
                                {
                                    DataTable Get_JobNo = FullName1.CopyToDataTable();
                                    IGST_LEVY_COMPENSATION_CESS_RATE = Get_JobNo.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();

                                    IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE = Get_JobNo.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();

                                    NOTIFICATION_EXCISE_BCD_SPL = Get_JobNo.Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                                }
                            }
                        }

                        //******************************* GET IGST_LEVY_EXCEPTION_CESS_RATE START*****************************

                        if (dt_All_Rates.Tables[6].Rows.Count > 0)
                        {
                            if (IGST_LEVY_EXCEPTION_CC_NOTN != "" && IGST_LEVY_EXCEPTION_CC_SLNO != "")
                            {
                                var FullName1 = from DataRow drr in dt_All_Rates.Tables[6].AsEnumerable()
                                                where drr.Field<string>("NOTIFICATION_EXCISE_NOTN") == IGST_LEVY_EXCEPTION_CC_NOTN && drr.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == IGST_LEVY_EXCEPTION_CC_SLNO
                                                select drr;

                                DataView dvv = FullName1.AsDataView();

                                if (dvv.Count > 0)
                                {
                                    DataTable Get_JobNo = FullName1.CopyToDataTable();
                                    IGST_LEVY_EXCEPTION_CC_RATE = Get_JobNo.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                                }
                            }
                        }

                        if (dt_All_Rates.Tables[0].Rows.Count > 0)
                        {

                            var PRODUCT_CTH_RATE = from DataRow drr in dt_All_Rates.Tables[0].AsEnumerable()
                                                   where drr.Field<string>("CTH_CODE") == PRODUCT_CTH
                                                   select drr;

                            DataView dv_CTH_RATE = PRODUCT_CTH_RATE.AsDataView();

                            if (dv_CTH_RATE.Count > 0)
                            {
                                DataTable CTH_RateS = PRODUCT_CTH_RATE.CopyToDataTable();

                                string CTH_Rate = CTH_RateS.Rows[0]["CTH_RATE"].ToString();
                                double CTH_Rate1 = Convert.ToDouble(CTH_Rate);

                                MERIT_PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(CTH_Rate1).ToString("F"));
                                NOTIFICATION_CUSTOMS_BCD_RATE = MERIT_PRODUCT_BCD_RATE;

                                //CTH_SPL_UNIT = ds_rate.Tables[0].Rows[0]["CTH_SPL_UNIT"].ToString();
                                CTH_SPL_UNIT = CTH_RateS.Rows[0]["CTH_SPL_UNIT"].ToString();


                                //************** SPECIAL AMOUNT FOR CTH RATE ***********************
                                string CTH_spl_amt = CTH_RateS.Rows[0]["CTH_SPL_AMT"].ToString();
                                if (CTH_spl_amt == "")
                                {
                                    CTH_spl_amt = "0";
                                }

                                CTH_SPL_AMT = Convert.ToString(Convert.ToDouble(CTH_spl_amt).ToString("F"));

                                //************** NCD NOTN RATE ***********************
                                if (PRODUCT_NCD_NOTN == "" && PRODUCT_NCD_SLNO == "" && PRODUCT_NCD_RATE == "")
                                {
                                    string CTH_ncd_rate = CTH_RateS.Rows[0]["CTH_NCD_D_RATE"].ToString();
                                    if (CTH_ncd_rate == "")
                                    {
                                        CTH_ncd_rate = "0";
                                    }

                                    CTH_NCD_D_RATE = Convert.ToString(Convert.ToDouble(CTH_ncd_rate).ToString("F"));
                                }
                                else
                                {
                                    CTH_NCD_D_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_NCD_RATE).ToString("F"));
                                }
                            }
                            else
                            {
                                //error CTH Here
                                dt_error.Rows.Add(PRODUCT_CTH, "CTH", INVOICE_SLNO, ITEM_SLNO);
                            }
                        }

                        //************** SAFEGUARD NOTN RATE ***********************

                        if (PRODUCT_SAFEGUARD_NOTN != "" && PRODUCT_SAFEGUARD_SLNO != "")
                        {
                            if (PRODUCT_SAFEGUARD_RATE != "")
                            {
                                CTH_SAFEGUARD_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_SAFEGUARD_RATE).ToString("F"));
                            }
                            else
                            {
                                var PRODUCT_SAFEGUARD_RATES = from DataRow drr in dt_All_Rates.Tables[2].AsEnumerable()
                                                              where drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN") == PRODUCT_SAFEGUARD_NOTN && drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == PRODUCT_SAFEGUARD_SLNO
                                                              && drr.Field<string>("NOTIFICATION_TYPE") == "S"
                                                              select drr;

                                DataView dv_SAFEGUARD_RATE = PRODUCT_SAFEGUARD_RATES.AsDataView();

                                if (dv_SAFEGUARD_RATE.Count > 0)
                                {
                                    DataTable CTH_SAFEGUARD = PRODUCT_SAFEGUARD_RATES.CopyToDataTable();

                                    string CTH_safe_rate = CTH_SAFEGUARD.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                    if (CTH_safe_rate == "")
                                    {
                                        CTH_safe_rate = "0";
                                    }

                                    CTH_SAFEGUARD_RATE = Convert.ToString(Convert.ToDouble(CTH_safe_rate).ToString("F"));
                                }
                                else
                                {
                                    //error SAFEGUARD here
                                    dt_error.Rows.Add(PRODUCT_SAFEGUARD_NOTN, PRODUCT_SAFEGUARD_SLNO, INVOICE_SLNO, ITEM_SLNO);
                                }
                            }
                        }
                        else
                        {
                            CTH_SAFEGUARD_RATE = "0.00";
                        }

                        //************** AGGREGATE NOTN RATE ***********************

                        if (PRODUCT_AGGREGATE_DUTY_NOTN != "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL != "")
                        {
                            if (PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                            {
                                var PRODUCT_AGGREGATE_RATES = from DataRow drr in dt_All_Rates.Tables[2].AsEnumerable()
                                                              where drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN") == PRODUCT_AGGREGATE_DUTY_NOTN && drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == PRODUCT_AGGREGATE_DUTY_NOTN_SL
                                                              && drr.Field<string>("NOTIFICATION_TYPE") == "A"
                                                              select drr;

                                DataView dv_AGGREGATE_RATE = PRODUCT_AGGREGATE_RATES.AsDataView();

                                if (dv_AGGREGATE_RATE.Count > 0)
                                {
                                    DataTable CTH_AGGREGATE = PRODUCT_AGGREGATE_RATES.CopyToDataTable();
                                    PRODUCT_AGGREGATE_DUTY_NOTN_RATE = CTH_AGGREGATE.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                }
                                else
                                {
                                    //error table here
                                    dt_error.Rows.Add(PRODUCT_AGGREGATE_DUTY_NOTN, PRODUCT_AGGREGATE_DUTY_NOTN_SL, INVOICE_SLNO, ITEM_SLNO);
                                }
                            }
                        }
                        else
                        {
                            PRODUCT_AGGREGATE_DUTY_NOTN_RATE = "";
                        }

                        //-----------------Start  Social Welfare Notn Rate from master implemented on 03Feb2018----------------

                        if (SOCIAL_WELFARE_NOTN != "" && SOCIAL_WELFARE_NOTN_SLNO != "")
                        {
                            if (SOCIAL_WELFARE_RATE == "")
                            {
                                var PRODUCT_SOCIAL_RATES = from DataRow drr in dt_All_Rates.Tables[2].AsEnumerable()
                                                           where drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN") == SOCIAL_WELFARE_NOTN && drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == SOCIAL_WELFARE_NOTN_SLNO
                                                              && drr.Field<string>("NOTIFICATION_TYPE") == "C"
                                                           select drr;

                                DataView dv_SOCIAL_RATE = PRODUCT_SOCIAL_RATES.AsDataView();

                                if (dv_SOCIAL_RATE.Count > 0)
                                {
                                    DataTable CTH_AGGREGATE = PRODUCT_SOCIAL_RATES.CopyToDataTable();
                                    SOCIAL_WELFARE_RATE = CTH_AGGREGATE.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                }
                                else
                                {
                                    //error table here
                                    dt_error.Rows.Add(SOCIAL_WELFARE_NOTN, SOCIAL_WELFARE_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
                                }
                            }
                        }
                        else
                        {
                            SOCIAL_WELFARE_RATE = "10.00";
                        }

                        //----------------- End Social Welfare Notn Rate from master implemented on 03Feb2018----------------



                        //------------------------------------------DATA FETCH FROM CTH MASTER------------------------------------------//
                        if (PRODUCT_BCD_NOTN.Trim() == "" && PRODUCT_BCD_NOTN_SLNO.Trim() == "" && PRODUCT_BCD_RATE.Trim() == "")
                        {
                            PRODUCT_BCD_RATE = MERIT_PRODUCT_BCD_RATE;

                            NOTIFICATION_CUSTOMS_BCD_RATE = "";
                            NOTIFICATION_CUSTOMS_CVD_RATE = "";
                        }
                        else
                        {
                            string[] BCD = PRODUCT_BCD_NOTN.Split(' ');
                            string PRODUCT_BCD_NOTN1 = BCD[0];

                            var PRODUCT_BCD_RATES = from DataRow drr in dt_All_Rates.Tables[2].AsEnumerable()
                                                    where drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN") == PRODUCT_BCD_NOTN1 && drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == PRODUCT_BCD_NOTN_SLNO
                                                    && drr.Field<string>("NOTIFICATION_TYPE") == "C"
                                                    select drr;

                            DataView dv_BCD_RATE = PRODUCT_BCD_RATES.AsDataView();

                            if (dv_BCD_RATE.Count > 0)
                            {
                                DataTable CTH_RateS = PRODUCT_BCD_RATES.CopyToDataTable();
                                string CTH_RATE = CTH_RateS.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                double CTH_RATE1 = Convert.ToDouble(CTH_RATE);

                                PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(CTH_RATE1).ToString("F"));

                                //string CTH_spl_amt = ds_rate.Tables[0].Rows[0]["CTH_SPL_AMT"].ToString();
                                ////double CTH_spl_amt1 = Convert.ToDouble(CTH_spl_amt);
                                //if (CTH_spl_amt == "")
                                //{
                                //    CTH_spl_amt = "0";
                                //}

                                //CTH_SPL_AMT = Convert.ToString(Convert.ToDouble(CTH_spl_amt).ToString("F"));                           
                                NOTIFICATION_CUSTOMS_BCD_RATE = "";
                                NOTIFICATION_CUSTOMS_CVD_RATE = "";


                                string Notn_Bcd_Rate = CTH_RateS.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                //double Notn_Bcd_Rate1 = Convert.ToDouble(Notn_Bcd_Rate);

                                //NOTIFICATION_CUSTOMS_BCD_RATE = Convert.ToString(Convert.ToDouble(Notn_Bcd_Rate1).ToString("F"));
                                NOTIFICATION_CUSTOMS_BCD_RATE = Notn_Bcd_Rate;

                                PRODUCT_BCD_RATE_UPDATE = Notn_Bcd_Rate;

                                PRODUCT_BCD_RATE = Notn_Bcd_Rate;

                                string Notn_Cvd_Rate = CTH_RateS.Rows[0]["NOTIFICATION_CUSTOMS_CVD_RATE"].ToString();
                                //double Notn_Cvd_Rate1 = Convert.ToDouble(Notn_Cvd_Rate);

                                //NOTIFICATION_CUSTOMS_CVD_RATE = Convert.ToString(Convert.ToDouble(Notn_Cvd_Rate1).ToString("F"));
                                NOTIFICATION_CUSTOMS_CVD_RATE = Notn_Cvd_Rate;


                                string Notn_Bcd_spl = CTH_RateS.Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                                NOTIFICATION_CUSTOMS_BCD_SPL = Notn_Bcd_spl;


                                if (NOTIFICATION_CUSTOMS_BCD_SPL == "-1.000000" || NOTIFICATION_CUSTOMS_BCD_SPL == "")
                                {
                                    NOTIFICATION_CUSTOMS_BCD_SPL = "0.00";
                                }
                            }
                            else
                            {
                                if (PRODUCT_BCD_NOTN.Trim() == "104/94" || PRODUCT_BCD_NOTN.Trim() == "003/57" || PRODUCT_BCD_NOTN.Trim() == "084/97")
                                {
                                    NOTIFICATION_CUSTOMS_BCD_RATE = "0.00";
                                    NOTIFICATION_CUSTOMS_CVD_RATE = "0.00";
                                    PRODUCT_BCD_RATE = "0.00";
                                }
                                else if (PRODUCT_BCD_NOTN.Trim() == "043/2017")
                                {
                                    NOTIFICATION_CUSTOMS_BCD_RATE = "0.00";
                                    NOTIFICATION_CUSTOMS_CVD_RATE = "0.00";
                                    PRODUCT_BCD_RATE = "0.00";
                                }
                                else
                                {
                                    //NOTIFICATION_CUSTOMS_BCD_RATE = "0.00";
                                    //NOTIFICATION_CUSTOMS_CVD_RATE = "0.00";
                                    //PRODUCT_BCD_RATE = "0.00";
                                    NOTIFICATION_CUSTOMS_BCD_RATE = "";
                                    NOTIFICATION_CUSTOMS_CVD_RATE = "";

                                    //error table here
                                    dt_error.Rows.Add(PRODUCT_BCD_NOTN, PRODUCT_BCD_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
                                }
                            }
                        }


                        if (BCD_NOTN == "146/94") //------Implemented On 30Nov2016 for Pro Cargo with Bala
                        {
                            PRODUCT_BCD_RATE = "0.00";
                        }

                        ////-----------------------End Infra Cess Details Hided on 11Sep2017 due to Out Of Memory problem-----------------------------------//

                        if (PRODUCT_TARIFF_NOTN.Trim() != "" && PRODUCT_TARIFF_SLNO.Trim() != "")
                        {
                            var PRODUCT_TARRIF_RATES = from DataRow drr in dt_All_Rates.Tables[2].AsEnumerable()
                                                       where drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN") == PRODUCT_TARIFF_NOTN && drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == PRODUCT_TARIFF_SLNO
                                                       && drr.Field<string>("NOTIFICATION_TYPE") == "T"
                                                       select drr;

                            DataView dv_TARRIF_RATE = PRODUCT_TARRIF_RATES.AsDataView();
                            if (dv_TARRIF_RATE.Count > 0)
                            {
                                DataTable TARRIF_RateS = PRODUCT_TARRIF_RATES.CopyToDataTable();
                                if (PRODUCT_TARIFF_AMOUNT == "")
                                {
                                    PRODUCT_TARIFF_AMOUNT = TARRIF_RateS.Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                                }
                                if (PRODUCT_TARIFF_AMOUNT_UNIT == "")
                                {
                                    PRODUCT_TARIFF_AMOUNT_UNIT = TARRIF_RateS.Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                                }
                            }
                            else
                            {
                                //error table here
                                dt_error.Rows.Add(PRODUCT_BCD_NOTN, PRODUCT_BCD_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
                            }
                        }

                        //---------------TARIFF CALCULATION----------------------------//
                        double tariff_amt = 0.00;
                        string inv_exrate = ds.Rows[C]["INVOICE_EXRATE"].ToString();


                        if (PRODUCT_TARIFF_NOTN.Trim() != "" && PRODUCT_TARIFF_SLNO.Trim() != "")
                        {
                            if (PRODUCT_TARIFF_NOTN.Trim() == "36/2001" && PRODUCT_TARIFF_SLNO.Trim() == "2(1)A")
                            {
                                if (PRODUCT_TARIFF_AMOUNT != "")
                                {
                                    if (Convert.ToDecimal(PRODUCT_TARIFF_AMOUNT) >= 0)
                                    {
                                        tariff_amt = Convert.ToDouble(PRODUCT_TARIFF_QTY) * Convert.ToDouble(PRODUCT_TARIFF_AMOUNT) * Convert.ToDouble(inv_exrate);
                                        ASSESABLE_VALUE = tariff_amt;
                                        ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE;
                                    }
                                }
                            }
                            else
                            {
                                if (PRODUCT_TARIFF_AMOUNT != "")
                                {
                                    if (Convert.ToDecimal(PRODUCT_TARIFF_AMOUNT) >= 0)
                                    {
                                        tariff_amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_TARIFF_AMOUNT) * Convert.ToDouble(inv_exrate);
                                        ASSESABLE_VALUE = tariff_amt;
                                        ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE;
                        }

                        //---------------END TARIFF CALCULATION-------------------------//

                        if (dt_All_Rates.Tables[1].Rows.Count > 0)
                        {
                            //string CETH_Rate = ds_rate.Tables[1].Rows[0]["CETH_ADDITIONAL_CVD_S_RATE"].ToString();

                            var PRODUCT_CETH_RATE = from DataRow drr in dt_All_Rates.Tables[1].AsEnumerable()
                                                    where drr.Field<string>("CETH_CODE") == PRODUCT_CETH
                                                    select drr;

                            DataView dv_CTH_RATE = PRODUCT_CETH_RATE.AsDataView();

                            if (dv_CTH_RATE.Count > 0)
                            {
                                DataTable CETH_RateS = PRODUCT_CETH_RATE.CopyToDataTable();

                                string CETH_Rate = CETH_RateS.Rows[0]["CETH_RATE"].ToString();
                                double CETH_Rate1 = Convert.ToDouble(CETH_Rate);
                                MERIT_PRODUCT_CVD_RATE = Convert.ToString(Convert.ToDouble(CETH_Rate1).ToString("F"));

                                string CETH_spl_amt = CETH_RateS.Rows[0]["CETH_SPL_AMT"].ToString();
                                if (CETH_spl_amt == "")
                                {
                                    CETH_spl_amt = "0";
                                }
                                CETH_SPL_AMT = Convert.ToString(Convert.ToDouble(CETH_spl_amt).ToString("F"));

                                //-------------------------------------

                                CESS = 0.00;

                                string ceth_cess_amount = CETH_RateS.Rows[0]["CETH_CESS_AMTS"].ToString();
                                if (ceth_cess_amount == "")
                                {
                                    ceth_cess_amount = "0";
                                }
                                CETH_CESS_AMTS = Convert.ToString(Convert.ToDouble(ceth_cess_amount).ToString("F"));
                                //CETH_CESS_AMTS = ceth_cess_amount;


                                string ceth_cess_rate = CETH_RateS.Rows[0]["CETH_CESS_RTA"].ToString();
                                if (ceth_cess_rate == "")
                                {
                                    ceth_cess_rate = "0";
                                }
                                if (ceth_cess_rate == "-1.000")
                                {
                                    ceth_cess_rate = "0";
                                }
                                //CETH_CESS_RTA = Convert.ToString(Convert.ToDouble(ceth_cess_rate).ToString("F"));
                                CETH_CESS_RTA = ceth_cess_rate;
                                //CETH_CESS_RTA = ceth_cess_rate;
                                string ceth_cess_unit = CETH_RateS.Rows[0]["CETH_CESS_UQC"].ToString();
                                CETH_CESS_UQC = ceth_cess_unit;
                            }
                            else
                            {
                                dt_error.Rows.Add(PRODUCT_CETH, "CETH", INVOICE_SLNO, ITEM_SLNO);
                            }
                        }

                        //------------------------------------------DATA FETCH FROM CETH MASTER------------------------------------------//

                        //------------------Start Exclusive for Indev Logistics on 05Feb2016-----------------------------//

                        if (PRODUCT_CETH.Substring(0, 2) == "24")
                        {
                            if (PRODUCT_CVD_NOTN.Trim() == "" && PRODUCT_CVD_NOTN_SLNO.Trim() == "" && PRODUCT_CVD_RATE.Trim() == "")
                            {

                                PRODUCT_CVD_RATE = MERIT_PRODUCT_CVD_RATE;
                            }
                            else
                            {
                                if (PRODUCT_CVD_RATE.Trim() != "")
                                {
                                    PRODUCT_CVD_RATE = PRODUCT_CVD_RATE;
                                    PRODUCT_CVD_RATE_UPDATE = PRODUCT_CVD_RATE;
                                }
                                else
                                {
                                    if (PRODUCT_CVD_NOTN.Trim() != "" && PRODUCT_CVD_NOTN_SLNO.Trim() != "")
                                    {

                                        string[] CVD = PRODUCT_CVD_NOTN.Split(' ');
                                        PRODUCT_CVD_NOTN = CVD[0];

                                        var PRODUCT_CVD_RATES = from DataRow drr in dt_All_Rates.Tables[7].AsEnumerable()
                                                                where drr.Field<string>("NOTIFICATION_EXCISE_NOTN") == PRODUCT_CVD_NOTN && drr.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == PRODUCT_CVD_NOTN_SLNO
                                                                && drr.Field<string>("NOTIFICATION_TYPE") == "E"
                                                                select drr;

                                        DataView dv_CVD_RATE = PRODUCT_CVD_RATES.AsDataView();

                                        if (dv_CVD_RATE.Count > 0)
                                        {
                                            DataTable CTH_RateS = PRODUCT_CVD_RATES.CopyToDataTable();

                                            PRODUCT_CVD_RATE = CTH_RateS.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                                            PRODUCT_CVD_RATE_UPDATE = CTH_RateS.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                                        }
                                        else
                                        {
                                            PRODUCT_CVD_RATE_UPDATE = PRODUCT_CVD_RATE;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            PRODUCT_CVD_RATE = "0.00";
                        }

                        //*********************************** END FETCH ALL RATES By Chithra 08-12-2017 *****************************XXXXXX

                        //------------------Start Exclusive for Indev Logistics on 05Feb2016-----------------------------//

                        //if (Session["COMPANY_ID"].ToString() == "196" || Session["COMPANY_ID"].ToString() == "4" || Session["COMPANY_ID"].ToString() == "248")
                        //{
                        double merit_bcd_rate = 0.00;

                        //if (NOTIFICATION_CUSTOMS_BCD_RATE != "")
                        //{
                        //    if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) != 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) != 0)
                        //    {
                        //        merit_bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) / 100;
                        //        MERIT_PRODUCT_BCD_RATE = NOTIFICATION_CUSTOMS_BCD_RATE;
                        //    }
                        //    else if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0)
                        //    {
                        //        merit_bcd_rate = Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE);
                        //        MERIT_PRODUCT_BCD_RATE = NOTIFICATION_CUSTOMS_BCD_RATE;
                        //    }
                        //}
                        //else
                        //{
                        merit_bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(MERIT_PRODUCT_BCD_RATE) / 100;
                        //}


                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                        {
                            //CTH_SPL_AMT = "";
                            MERIT_BASIC_DUTY = merit_bcd_rate;
                        }
                        else
                        {
                            double merit_bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                            double merit_cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                            if (merit_bcd_rate >= merit_bcd_Amt)
                            {
                                if (merit_cth_Amt >= merit_bcd_rate)
                                {
                                    MERIT_BASIC_DUTY = merit_cth_Amt;
                                }
                                else
                                {
                                    MERIT_BASIC_DUTY = merit_bcd_rate;
                                }
                            }
                            else
                            {
                                if (merit_cth_Amt >= merit_bcd_Amt)
                                {
                                    MERIT_BASIC_DUTY = merit_cth_Amt;
                                }
                                else
                                {
                                    MERIT_BASIC_DUTY = merit_bcd_Amt;
                                }
                            }
                        }

                        //----------------------------------//

                        //-----------GST IMPLEMENTATION ON 01JULY2017 ------------------//                                      

                        if (PRODUCT_CETH.Substring(0, 2) != "24")
                        {
                            MERIT_CVD = 0.00;
                            MERIT_PRODUCT_CVD_RATE = "0.00";
                        }
                        //-----------GST IMPLEMENTATION ON 01JULY2017 ------------------//


                        MERIT_CVD = (ASSESABLE_VALUE + MERIT_BASIC_DUTY) * Convert.ToDouble(MERIT_PRODUCT_CVD_RATE) / 100;

                        //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra

                        //------------------------------CESS CALCULATION--------------------------------//

                        if ((Convert.ToDouble(CETH_CESS_AMTS) != 0.00) || (Convert.ToDouble(CETH_CESS_AMTS) > 0.00))
                        {
                            if (Convert.ToDouble(CETH_CESS_AMTS) != 0.00)
                            {
                                MERIT_CESS = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_CESS_AMTS);
                            }
                        }
                        else if (Convert.ToDouble(CETH_CESS_RTA) != 0.00 || Convert.ToDouble(CETH_CESS_RTA) > 0.00)
                        {
                            MERIT_CESS = (ASSESABLE_VALUE + MERIT_BASIC_DUTY) * Convert.ToDouble(CETH_CESS_RTA) / 100;
                        }
                        else
                        {
                        }

                        //---------------------------END CESS CALCULATION--------------------------------//                                      

                        merit_Customs_Edu_Cess = (MERIT_BASIC_DUTY + MERIT_CVD + MERIT_CESS) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
                        double merit_Customs_Edu_Cess_tot = Math.Round(Convert.ToDouble(merit_Customs_Edu_Cess), 1);


                        merit_Customs_Higher_Edu_Cess = (MERIT_BASIC_DUTY + MERIT_CVD + MERIT_CESS) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                        double merit_Customs_Higher_Edu_Cess_tot = Math.Round(Convert.ToDouble(merit_Customs_Higher_Edu_Cess), 1);

                        //02feb
                        merit_social_welfare_cess = MERIT_BASIC_DUTY * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                        double merit_social_welfare_cess_tot = Math.Round(Convert.ToDouble(merit_social_welfare_cess), 1);

                        /*
                         CHK_IGST_ASSBL_VAL = 0.00;
                         CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + MERIT_BASIC_DUTY + merit_social_welfare_cess;
                         tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                         */

                        CHK_IGST_LEVY_AMT = 0.00;

                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                        merit_AddL_DUTY = 0.00;
                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                        double merit_AddL_DUTY_tot = Math.Round(Convert.ToDouble(merit_AddL_DUTY), 1);
                        double MERIT_BASIC_DUTY_TOT = Math.Round(Convert.ToDouble(MERIT_BASIC_DUTY), 1);
                        double MERIT_CVD_TOT = Math.Round(Convert.ToDouble(MERIT_CVD), 1);

                        double merit_SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

                        MERIT_BASIC_VALUE = MERIT_BASIC_DUTY_TOT;
                        MERIT_CVD_VALUE = MERIT_CVD_TOT;
                        MERIT_CEC_VALUE = merit_Customs_Edu_Cess_tot;
                        MERIT_CHEC_VALUE = merit_Customs_Higher_Edu_Cess_tot;
                        MERIT_ADD_DUTY_VALUE = merit_AddL_DUTY_tot;


                        //------------New Anti-Dumping Calculation implemented on 04July2016------------//
                        if (ANTI_AMTS != null && ANTI_AMTS != "")
                        {
                            if (ADD_AMT_MINUS_ASSESABLE == "1")
                            {
                                MERIT_TOTAL_ANTIDUMP_AMT = MERIT_TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(MERIT_BASIC_DUTY_TOT);

                                if (MERIT_TOTAL_ANTIDUMP_AMT <= 0)
                                {
                                    MERIT_TOTAL_ANTIDUMP_AMT = 0.00;
                                }

                                MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(MERIT_TOTAL_ANTIDUMP_AMT, 2).ToString("F"));


                            }

                            //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "          " + TOTAL_ANTI_AMT;
                        }


                        //------------New Anti-Dumping Calculation implemented on 04July2016------------//

                        MERIT_TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(MERIT_BASIC_DUTY_TOT + MERIT_CVD_TOT + merit_Customs_Edu_Cess_tot + merit_Customs_Higher_Edu_Cess_tot + merit_AddL_DUTY_tot + merit_SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));


                        //------------------End Exclusive for Indev Logistics on 05Feb2016-----------------------------//

                        MERIT_NOTN_BASIC_VALUE = 0.00;
                        MERIT_NOTN_CVD_VALUE = 0.00;
                        MERIT_NOTN_CEC_VALUE = 0.00;
                        MERIT_NOTN_CHEC_VALUE = 0.00;
                        MERIT_NOTN_ADD_DUTY_VALUE = 0.00;
                        MERIT_NOTN_CESS_VALUE = 0.00;
                        MERIT_NOTN_NCD_VALUE = 0.00;


                        string[] arr = { "DEEC", "REP", "DIL", "JBG", "EOU", "DUTIABLE" };
                        string[] arr1 = { "DEPB", "DFRC", "DFCC", "TRG+", "(KRSH)", "DFCS", "DFIA", "FMS", "FPS", "SHIS", "MEIS", "INC", "SEIS" };
                        string[] arr2 = { "EPCG" };

                        if (SCHEME_NOTN_ != "0")
                        {
                            string value1 = Array.Find(arr, element => element.StartsWith(SCHEME_NOTN_, StringComparison.Ordinal));
                            string value2 = Array.Find(arr1, element => element.StartsWith(SCHEME_NOTN_, StringComparison.Ordinal));

                            if (SCHEME_NOTN_.Trim() == "DUTIABLE")
                            {
                                value1 = "";
                                SCHEME_NOTN_ = "";
                            }


                            //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//
                            DataView view1 = ds3.DefaultView;
                            view1.RowFilter = "INVOICE_SLNO = " + INVOICE_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                            DataTable table1 = view1.ToTable();
                            DataSet dss1 = new DataSet();
                            dss1.Tables.Add(table1);


                            if (SCHEME_NOTN_ == value1)
                            {
                                if ("DEEC" == value1 || "" == value1)//this code for to check scheme 00-Dutiable)
                                {
                                    if (dss1.Tables[0].Rows.Count > 0)
                                    {
                                        //DEEC 
                                        Scheme_DEEC(dss1);
                                    }
                                    else
                                    {
                                        //DUTIABLE
                                        Scheme_DUTIABLE();
                                    }
                                }
                                else if (SCHEME_NOTN_ == "REP" || SCHEME_NOTN_ == "DIL" || SCHEME_NOTN_ == "JBG" || SCHEME_NOTN_ == "EOU")
                                {
                                    // REP & DIL & JBG & EOU
                                    Scheme_SAME_CODE_GENERAL_CALC();
                                }
                            }

                                //***************Start Developed on 27June2015 for ONDOT Express*******************//
                            //else if (SCHEME_NOTN_ == "INC")
                            //{
                            //    if (dss1.Tables[0].Rows.Count > 0)
                            //    {
                            //        EXCEMPTION = dss1.Tables[0].Rows[0]["EXCEMPTION"].ToString();
                            //        if (EXCEMPTION == "E")
                            //        {
                            //            Scheme_SAME_CODE_GENERAL_CALC();
                            //        }
                            //    }
                            //}
                            //***************End Developed on 27June2015 for ONDOT Express*******************//
                            else if (SCHEME_NOTN_ == "EPCG")
                            {
                                //Scheme_EPCG(ds3, adm_Mas);
                                Scheme_EPCG(dss1.Tables[0], adm_Mas);
                            }

                            else
                            {
                                //MEIS & SEIS

                                if (SCHEME_NOTN_ == value2)
                                {
                                    if (dss1.Tables[0].Rows.Count > 0)
                                    {
                                        EXCEMPTION = dss1.Tables[0].Rows[0]["EXCEMPTION"].ToString();

                                        //-----------------Calculation implemented on 28Apr2017 for Paramount---------------//
                                        /* hide on 20/02/2018 discuss with subbu sir --------- start
                                        double bcd_rate1 = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;

                                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                                        {
                                            // CTH_SPL_AMT = "";
                                            BASIC_DUTY = bcd_rate1;
                                        }
                                        else
                                        {
                                            double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                            double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                                            if (bcd_rate1 >= bcd_Amt)
                                            {
                                                if (cth_Amt >= bcd_rate1)
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = bcd_rate1;
                                                }
                                            }
                                            else
                                            {
                                                if (cth_Amt >= bcd_Amt)
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = bcd_Amt;
                                                }
                                            }
                                        }

                                      hide on 20/02/2018 discuss with subbu sir --------- End  */

                                        NCD = 0.00;
                                        Customs_Edu_Cess = 0.00;
                                        Customs_Higher_Edu_Cess = 0.00;

                                        BASIC_DUTY = 0.00;
                                        SAFE_GUARD = 0.00;
                                        CVD = 0.00;

                                        AddL_DUTY = 0.00;
                                        CESS = 0.00;
                                        cvd_Customs_Edu_Cess = 0.00;
                                        cvd_Customs_Higher_Edu_Cess = 0.00;

                                        Customs_Social_welfare = 0.00;



                                        if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                                        {
                                        }
                                        else
                                        {
                                            Aggregate_safe_guard = SAFE_GUARD;
                                            Aggregate_AddL_DUTY = AddL_DUTY;
                                            Aggregate_basic_duty = BASIC_DUTY;
                                            Aggregate_cvd = CVD;
                                            Aggregate_ncd = NCD;
                                            Aggregate_Customs_Edu_Cess = Customs_Edu_Cess;
                                            Aggregate_Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess;

                                            SAFE_GUARD = SAFE_GUARD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            BASIC_DUTY = BASIC_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            CVD = CVD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            NCD = NCD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            Customs_Edu_Cess = Customs_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            //AddL_DUTY = AddL_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            AddL_DUTY = 0.00;

                                            Aggregate_safe_guard = Aggregate_safe_guard * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                            Aggregate_AddL_DUTY = Aggregate_AddL_DUTY * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                            Aggregate_basic_duty = Aggregate_basic_duty * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                            Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                                            Aggregate_ncd = Aggregate_ncd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                            Aggregate_Customs_Edu_Cess = Aggregate_Customs_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                            Aggregate_Customs_Higher_Edu_Cess = Aggregate_Customs_Higher_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                                            AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;

                                        }

                                        CVD_CEC_TOTAL = "0.00";
                                        CVD_CHEC_TOTAL = "0.00";

                                        /* hide on 20/02/2018 discuss with subbu sir --------- start
                                        if (PRODUCT_CVD_EDU_CESS_RATE == "013/2012")
                                        {
                                            CVD_CEC_TOTAL = "0.00";
                                            CVD_CHEC_TOTAL = "0.00";
                                        }
                                        else
                                        {
                                            CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
                                            CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                                        }
                                       hide on 20/02/2018 discuss with subbu sir --------- End  * */

                                        BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                                        SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
                                        AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));

                                        CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CESS), 1).ToString("0.00"));

                                        CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));

                                        NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
                                        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                                        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                                        TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(SOCIAL_welf_Rate), 1).ToString("0.00"));

                                        //-----------------------CALCULATION FOR TOTAL DEBIT DUTY--------------------------------//


                                        double bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;



                                        if (Session["COMPANY_ID"].ToString() == "224")
                                        {
                                            if (NOTIFICATION_CUSTOMS_BCD_SPL == "-1.000000" || NOTIFICATION_CUSTOMS_BCD_SPL == "")
                                            {
                                            }
                                            else
                                            {
                                                CTH_SPL_AMT = NOTIFICATION_CUSTOMS_BCD_SPL;
                                            }
                                        }


                                        /*  hide by Chithra suggest by Bala Sir on 30-05-18 for PARAMOUNT
                                         
                                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                                        {
                                            // CTH_SPL_AMT = "";
                                            BASIC_DUTY = bcd_rate;
                                        }
                                        else
                                        {
                                            double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                            double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                                            if (bcd_rate >= bcd_Amt)
                                            {
                                                if (cth_Amt >= bcd_rate)
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = bcd_rate;
                                                }
                                            }
                                            else
                                            {
                                                if (cth_Amt >= bcd_Amt)
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = bcd_Amt;
                                                }
                                            }
                                        }
                                         *  */


                                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                                        {
                                            //CTH_SPL_AMT = "";
                                            BASIC_DUTY = bcd_rate;
                                        }
                                        else
                                        {
                                            double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                            double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                                            if (bcd_rate >= bcd_Amt)
                                            {
                                                if (cth_Amt >= bcd_rate)
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = bcd_rate;
                                                }
                                            }
                                            else
                                            {
                                                if (cth_Amt >= bcd_Amt)
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = bcd_Amt;
                                                }
                                            }

                                            if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                                            {
                                                if (bcd_Amt <= bcd_rate)
                                                {
                                                    BASIC_DUTY = bcd_Amt;
                                                }
                                            }
                                        }

                                        if (PRODUCT_BCD_SPL != "")
                                        {
                                            if (Convert.ToDouble(PRODUCT_BCD_SPL) != 0.000000 || Convert.ToDouble(PRODUCT_BCD_SPL) != 000000)
                                            {
                                                double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                                double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                                                bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_BCD_SPL);

                                                if (bcd_rate >= cth_Amt)
                                                {
                                                    BASIC_DUTY = bcd_rate;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }

                                                if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                                                {
                                                    if (bcd_Amt <= bcd_rate)
                                                    {
                                                        BASIC_DUTY = bcd_Amt;
                                                    }
                                                }

                                                if (Session["COMPANY_ID"].ToString() == "313")
                                                {
                                                    if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                                                    {
                                                        BASIC_DUTY = cth_Amt;
                                                    }
                                                }

                                                //BASIC_DUTY_BCD_SPL = cth_Amt;
                                                //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                                                CTH_SPL_AMT = PRODUCT_BCD_SPL;
                                            }
                                        }

                                        //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

                                        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

                                        //---------------END SAPTA CALCULATION-------------------------//


                                        //-----------------------------END NCD CALCULATION---------------------------------------//      

                                        CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                                        //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra

                                        //------------------------------CESS CALCULATION--------------------------------//

                                        /* hide on 20/02/2018 discuss with subbu sir --------- start
                                        if ((Convert.ToDouble(CETH_CESS_AMTS) != 0.00) || (Convert.ToDouble(CETH_CESS_AMTS) > 0.00))
                                        {
                                            if (Convert.ToDouble(CETH_CESS_AMTS) != 0.00)
                                            {
                                                CESS = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_CESS_AMTS);
                                            }
                                        }
                                        else if (Convert.ToDouble(CETH_CESS_RTA) != 0.00 || Convert.ToDouble(CETH_CESS_RTA) > 0.00)
                                        {
                                            CESS = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(CETH_CESS_RTA) / 100;

                                        }
                                        else
                                        {

                                        }
                                       hide on 20/02/2018 discuss with subbu sir --------- End  * */

                                        //---------------------------END CESS CALCULATION--------------------------------//    

                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        CESS = 0.00;
                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
                                        if (PRODUCT_CETH.Substring(0, 2) != "24")
                                        {
                                            CVD_TOTAL = "0";
                                            CVD = 0.00;
                                            PRODUCT_CVD_RATE = "0.00";
                                            PRODUCT_CETH = "NOEXCISE";
                                        }
                                        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//

                                        /* hide on 20/02/2018 discuss with subbu sir --------- start
                                        Customs_Edu_Cess = (BASIC_DUTY + CVD + CESS + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;

                                        Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + CESS + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;

                                       hide on 20/02/2018 discuss with subbu sir --------- End  * */

                                        Customs_Social_welfare = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

                                        //IGST ASSESABLE VALUE SHOWS IN CHECKLIST - BY CHITHRA ON 05/05/2018
                                        CHK_IGST_ASSBL_VAL = 0.00;
                                        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare;
                                        tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);


                                        ////AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + CESS + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;

                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                                        AddL_DUTY = 0.00;
                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//
                                        if (Session["COMPANY_ID"].ToString() == "247" || Session["COMPANY_ID"].ToString() == "10")
                                        {
                                            MERIT_NOTN_BASIC_VALUE = Math.Round(Convert.ToDouble(BASIC_DUTY), 2);
                                            MERIT_NOTN_CVD_VALUE = Math.Round(Convert.ToDouble(CVD), 2);
                                            MERIT_NOTN_CEC_VALUE = Math.Round(Convert.ToDouble(Customs_Edu_Cess), 2);
                                            MERIT_NOTN_CHEC_VALUE = Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 2);
                                            MERIT_NOTN_ADD_DUTY_VALUE = Math.Round(Convert.ToDouble(AddL_DUTY), 2);
                                            MERIT_NOTN_CESS_VALUE = Math.Round(Convert.ToDouble(CESS), 2);
                                            MERIT_NOTN_NCD_VALUE = Math.Round(Convert.ToDouble(NCD), 2);
                                        }
                                        //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//

                                        //------------New Anti-Dumping Calculation implemented on 06Oct2018------------//
                                        string TOTAL_ANTI_AMT_LICNESE;

                                        if (ANTI_AMTS != null && ANTI_AMTS != "")
                                        {
                                            if (ADD_AMT_MINUS_ASSESABLE == "1")
                                            {
                                                TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);

                                                if (TOTAL_ANTIDUMP_AMT <= 0)
                                                {
                                                    TOTAL_ANTIDUMP_AMT = 0.00;
                                                }
                                                MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                                            }

                                            if (ANTI_DUMPING_NOTN == "002/2017")
                                            {
                                                if (Convert.ToDouble(ITEM_UNIT_PRICE) >= 755 && ITEM_QTY_CODE == "MTS")
                                                {
                                                    MERIT_TOTAL_ANTI_AMT = "0.00";
                                                }
                                            }


                                            //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                                            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + TOTAL_ANTI_AMT;

                                        }
                                        else if (MAX_DIFF != "" && MAX_DIFF != null)
                                        {


                                            if (PRODUCT_OTHER_DUTY_NOTN != "" && PRODUCT_OTHER_DUTY_SLNO != "")
                                            {
                                                if (PRODUCT_OTHER_DUTY_RATE != "")
                                                {
                                                    ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                                                    TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY) * (ADD_MAX_DIFF) / 100;
                                                    TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));


                                                    double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                    double Final_Anti_Dump = TOTAL_ANTIDUMP_AMT - Anti_Dump_Cal2;

                                                    TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(Final_Anti_Dump, 2).ToString("F"));
                                                    if (Convert.ToDouble(TOTAL_ANTI_AMT_LICNESE) < 0.00)
                                                        TOTAL_ANTI_AMT_LICNESE = "0.00";

                                                    MERIT_TOTAL_ANTI_AMT = TOTAL_ANTI_AMT_LICNESE;

                                                }
                                            }
                                            else
                                            {
                                                ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                                                TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                                                MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                                                TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                                                MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                                            }


                                            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + TOTAL_ANTI_AMT;
                                            //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + "0.00";

                                        }
                                        else if (ADD_DIFF_CUR != null && ADD_DIFF_CUR != "")
                                        {
                                            if (ADD_AMT_MINUS_ASSESABLE == "2")
                                            {
                                                TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble((ADD_DIFF_CUR)) / 100;

                                                if (TOTAL_ANTIDUMP_AMT <= 0)
                                                {
                                                    TOTAL_ANTIDUMP_AMT = 0.00;
                                                }
                                                TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                                                MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                                            }

                                            //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                                            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "           " + " " + ADD_DIFF_CUR + "%" + "     " + TOTAL_ANTIDUMP_AMT;

                                        }
                                        //------------End Anti-Dumping Calculation implemented on 06Oct2018------------//

                                        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
                                        Call_IGST_General();


                                        //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD), 1).ToString("0.00"));
                                        //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + CESS).ToString("0.00"));

                                        TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS).ToString("0.00"));

                                    }
                                    else // MEIS WITHOUT LICENSE ENTRY START
                                    {
                                        //BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                                        double bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;

                                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                                        {
                                            //CTH_SPL_AMT = "";
                                            BASIC_DUTY = bcd_rate;
                                        }
                                        else
                                        {
                                            double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                            double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                                            if (bcd_rate >= bcd_Amt)
                                            {
                                                if (cth_Amt >= bcd_rate)
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = bcd_rate;
                                                }
                                            }
                                            else
                                            {
                                                if (cth_Amt >= bcd_Amt)
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = bcd_Amt;
                                                }
                                            }
                                        }

                                        //SOCIAL WELFARE CALCULATION

                                        if (SOCIAL_WELFARE_NOTN != "")
                                        {
                                            SOCIAL_welf_Rate = BASIC_DUTY * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }

                                        //-----------------------------NCD CALCULATION---------------------------------------//
                                        NCD = 0.00;
                                        //-----------------------------END NCD CALCULATION---------------------------------------//      

                                        // CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                                        double CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;
                                        double CVD_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_SPL_AMT);

                                        if (CVD_Rate >= CVD_Amt)
                                        {
                                            CVD = CVD_Rate;
                                        }
                                        else
                                        {
                                            CVD = CVD_Amt;
                                        }

                                        //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra

                                        Aggregate_cvd = CVD;

                                        if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                                        {

                                        }
                                        else
                                        {
                                            Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                        }

                                        CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Aggregate_cvd), 1).ToString("0.00"));
                                        //CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                                        //CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                                        //ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                                        ////TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));

                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                                        if (PRODUCT_CETH.Substring(0, 2) != "24")
                                        {
                                            CVD_TOTAL = "0";
                                            CVD = 0.00;
                                            PRODUCT_CVD_RATE = "0.00";
                                            PRODUCT_CETH = "NOEXCISE";
                                        }
                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        // -----------------Spl Excise Duty(Sched-11) Calculation-------------------------------//
                                        // -----------------GSI Calculation-------------------------------//
                                        // -----------------TTA Calculation-------------------------------//

                                        if (!string.IsNullOrEmpty(EDU_CESS_NOTN))
                                        {
                                            if (EDU_CESS_NOTN == "054/2017")
                                            {
                                                PRODUCT_SEC_EDU_CESS_NOTN = "055/2017";
                                            }
                                            else
                                            {
                                                PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                                            }
                                            Customs_Edu_Cess = 0.00;
                                            Customs_Higher_Edu_Cess = 0.00;
                                            //PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                                            PRODUCT_EDU_CESS_RATE = "0.00";
                                            PRODUCT_SEC_EDU_CESS_RATE = "0.00";

                                        }
                                        else
                                        {
                                            Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
                                            Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                                        }

                                        Customs_Social_welfare = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

                                        //IGST ASSESABLE VALUE SHOWS IN CHECKLIST - BY CHITHRA ON 05/05/2018
                                        CHK_IGST_ASSBL_VAL = 0.00;
                                        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare;
                                        tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);

                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                                        AddL_DUTY = 0.00;
                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                                        SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

                                        if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                                        {

                                        }
                                        else
                                        {
                                            Aggregate_safe_guard = SAFE_GUARD;
                                            Aggregate_AddL_DUTY = AddL_DUTY;
                                            Aggregate_basic_duty = BASIC_DUTY;
                                            Aggregate_cvd = CVD;
                                            Aggregate_ncd = NCD;
                                            Aggregate_Customs_Edu_Cess = Customs_Edu_Cess;
                                            Aggregate_Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess;

                                            SAFE_GUARD = SAFE_GUARD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            BASIC_DUTY = BASIC_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            NCD = NCD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            Customs_Edu_Cess = Customs_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                            //AddL_DUTY = AddL_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;

                                            AddL_DUTY = 0.00;

                                            Aggregate_safe_guard = Aggregate_safe_guard * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                            Aggregate_AddL_DUTY = Aggregate_AddL_DUTY * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                                            Aggregate_AddL_DUTY = 0.00;
                                            Aggregate_basic_duty = Aggregate_basic_duty * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                            Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                                            Aggregate_ncd = Aggregate_ncd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                            Aggregate_Customs_Edu_Cess = Aggregate_Customs_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                            Aggregate_Customs_Higher_Edu_Cess = Aggregate_Customs_Higher_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                                            //AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;
                                            AGGREGATE_DUTY = (AddL_DUTY + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess);

                                        }

                                        if (PRODUCT_CVD_EDU_CESS_RATE == "013/2012")
                                        {
                                            CVD_CEC_TOTAL = "0.00";
                                            CVD_CHEC_TOTAL = "0.00";
                                        }
                                        else
                                        {
                                            CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
                                            CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                                        }

                                        SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
                                        AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
                                        BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                                        NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
                                        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                                        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                                        TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));

                                        //TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Conv
                                    }
                                }
                            }
                        }
                        else
                        {

                            //BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                            double bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;

                            if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                            {

                                // CTH_SPL_AMT = "";
                                BASIC_DUTY = bcd_rate;
                            }
                            else
                            {
                                double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                                if (bcd_rate >= bcd_Amt)
                                {
                                    if (cth_Amt >= bcd_rate)
                                    {
                                        BASIC_DUTY = cth_Amt;
                                    }
                                    else
                                    {
                                        BASIC_DUTY = bcd_rate;
                                    }
                                }
                                else
                                {
                                    if (cth_Amt >= bcd_Amt)
                                    {
                                        BASIC_DUTY = cth_Amt;
                                    }
                                    else
                                    {
                                        BASIC_DUTY = bcd_Amt;
                                    }
                                }
                            }

                            //SOCIAL WELFARE CALCULATION

                            if (SOCIAL_WELFARE_NOTN != "")
                            {
                                SOCIAL_welf_Rate = BASIC_DUTY * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                            }

                            //-----------------------------NCD CALCULATION---------------------------------------//
                            NCD = 0.00;
                            //-----------------------------END NCD CALCULATION---------------------------------------//      

                            // CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                            double CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                            double CVD_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_SPL_AMT);

                            if (CVD_Rate >= CVD_Amt)
                            {
                                CVD = CVD_Rate;
                            }
                            else
                            {
                                CVD = CVD_Amt;
                            }

                            //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra

                            Aggregate_cvd = CVD;

                            if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                            {

                            }
                            else
                            {
                                Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                            }

                            CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Aggregate_cvd), 1).ToString("0.00"));
                            //CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                            //CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                            //ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                            ////TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));

                            // -----------------Spl Excise Duty(Sched-11) Calculation-------------------------------//
                            // -----------------GSI Calculation-------------------------------//
                            // -----------------TTA Calculation-------------------------------//

                            if (!string.IsNullOrEmpty(EDU_CESS_NOTN))
                            {
                                if (EDU_CESS_NOTN == "054/2017")
                                {
                                    PRODUCT_SEC_EDU_CESS_NOTN = "055/2017";
                                }
                                else
                                {
                                    PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                                }
                                Customs_Edu_Cess = 0.00;
                                Customs_Higher_Edu_Cess = 0.00;
                                //PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                                PRODUCT_EDU_CESS_RATE = "0.00";
                                PRODUCT_SEC_EDU_CESS_RATE = "0.00";
                            }
                            else
                            {
                                Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
                                Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                            }

                            Customs_Social_welfare = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;


                            //IGST ASSESABLE VALUE SHOWS IN CHECKLIST - BY CHITHRA ON 05/05/2018
                            CHK_IGST_ASSBL_VAL = 0.00;
                            CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare;
                            tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);

                            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                            AddL_DUTY = 0.00;
                            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                            //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                            SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;


                            if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                            {

                            }
                            else
                            {
                                Aggregate_safe_guard = SAFE_GUARD;
                                Aggregate_AddL_DUTY = AddL_DUTY;
                                Aggregate_basic_duty = BASIC_DUTY;
                                Aggregate_cvd = CVD;
                                Aggregate_ncd = NCD;
                                Aggregate_Customs_Edu_Cess = Customs_Edu_Cess;
                                Aggregate_Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess;

                                SAFE_GUARD = SAFE_GUARD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                BASIC_DUTY = BASIC_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                NCD = NCD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                Customs_Edu_Cess = Customs_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                                //AddL_DUTY = AddL_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;

                                Aggregate_safe_guard = Aggregate_safe_guard * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                //Aggregate_AddL_DUTY = Aggregate_AddL_DUTY * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                Aggregate_basic_duty = Aggregate_basic_duty * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                Aggregate_ncd = Aggregate_ncd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                Aggregate_Customs_Edu_Cess = Aggregate_Customs_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                                Aggregate_Customs_Higher_Edu_Cess = Aggregate_Customs_Higher_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                                AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;
                            }

                            if (PRODUCT_CVD_EDU_CESS_RATE == "013/2012")
                            {
                                CVD_CEC_TOTAL = "0.00";
                                CVD_CHEC_TOTAL = "0.00";
                            }
                            else
                            {
                                CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
                                CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                            }

                            SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
                            AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
                            BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                            NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
                            CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                            CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                            ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));

                            //TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));
                        }


                        //----------------Re-Import Calculation--------------------------------//
                        DataView Re_view = new DataView(dt_ReImport);

                        //DataView Re_view = dt_ReImport.DefaultView;
                        if (Re_view.Count > 0)
                        {
                            ITEM_REIMPORT(Re_view);
                        }

                        //----------------Re-Import Calculation--------------------------------//

                        //-----------------New Implementation On 30Nov2016 ------------------//

                        if (BCD_NOTN == "146/94") //------Implemented On 30Nov2016 for Pro Cargo with Bala
                        {
                            TOTAL_ANTI_AMT = "0.00";
                            BASIC_DUTY_TOTAL = "0.00";
                            CVD_TOTAL = "0.00";
                            CEC_TOTAL = "0.00";
                            CHEC_TOTAL = "0.00";
                            SCHED11_TOTAL = "0.00";
                            GSI_TOTAL = "0.00";
                            TTA_TOTAL = "0.00";
                            NCD_TOTAL = "0.00";
                            CESS_TOTAL = "0.00";
                            SAFE_GUARD_TOTAL = "0.00";

                            CVD_CEC_TOTAL = "0.00";
                            CVD_CHEC_TOTAL = "0.00";

                            ADDLTIONAL_DUTY_TOTAL = "0.00";
                        }
                        //-----------------New Implementation On 30Nov2016 ------------------//


                        //------------New Anti-Dumping Calculation implemented on 04July2016------------//
                        //if (ANTI_AMTS != null && ANTI_AMTS != "")
                        //{
                        //    if (ADD_AMT_MINUS_ASSESABLE == "1")
                        //    {
                        //        TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);

                        //        if (TOTAL_ANTIDUMP_AMT <= 0)
                        //        {
                        //            TOTAL_ANTIDUMP_AMT = 0.00;
                        //        }
                        //        TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                        //    }

                        //    if (ANTI_DUMPING_NOTN == "002/2017")
                        //    {
                        //        if (Convert.ToDouble(ITEM_UNIT_PRICE) >= 755 && ITEM_QTY_CODE == "MTS")
                        //        {
                        //            TOTAL_ANTI_AMT = "0.00";
                        //        }
                        //    }


                        //    ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + TOTAL_ANTI_AMT;

                        //}
                        ////------------New Anti-Dumping Calculation implemented on 04July2016------------//
                        ////---------Start New Anti-Dumping Calculation implemented on 27Sep2018------------//
                        //else if (MAX_DIFF != "" && MAX_DIFF != null)
                        //{


                        //    if (PRODUCT_OTHER_DUTY_NOTN != "" && PRODUCT_OTHER_DUTY_SLNO != "")
                        //    {
                        //        if (PRODUCT_OTHER_DUTY_RATE != "")
                        //        {
                        //            ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                        //            TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY)*(ADD_MAX_DIFF) / 100;                                    
                        //            TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));


                        //            double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                        //            double Final_Anti_Dump = TOTAL_ANTIDUMP_AMT - Anti_Dump_Cal2;                                   

                        //            TOTAL_ANTI_AMT = Convert.ToString(Math.Round(Final_Anti_Dump, 2).ToString("F"));
                        //            if (Convert.ToDouble(TOTAL_ANTI_AMT) < 0.00)
                        //                TOTAL_ANTI_AMT = "0.00";

                        //            MERIT_TOTAL_ANTI_AMT = TOTAL_ANTI_AMT;

                        //        }
                        //    }
                        //    else
                        //    {
                        //        ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                        //        TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        //        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        //        TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                        //        MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                        //    }


                        //   ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + TOTAL_ANTI_AMT;

                        //}
                        //---------End New Anti-Dumping Calculation implemented on 27Sep2018------------//


                        //TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));
                        //TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL));


                        //******************** GST IMPLEMENTATION ON 30-JUN-2017 START***************************

                        //TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL));

                        //if (PRODUCT_CETH.Substring(0, 2) != "24" && PRODUCT_CETH.Substring(0, 2) != "27")
                        //{
                        //    CVD_TOTAL = "0";
                        //}
                        if (PRODUCT_CETH.Substring(0, 2) != "24")
                        {
                            CVD_TOTAL = "0";
                            CVD = 0.00;
                            PRODUCT_CVD_RATE = "0.00";
                            PRODUCT_CETH = "NOEXCISE";
                        }



                        //******************** GST IMPLEMENTATION ON 11-JULY-2017 START***************************
                        //double igst_anti_dump_amt = 0.00;

                        //if (Session["COMPANY_ID"].ToString() == "293")
                        //{
                        //    if (PRODUCT_OTHER_DUTY_NOTN != "" && PRODUCT_OTHER_DUTY_SLNO != "")
                        //    {

                        //    }
                        //    else
                        //    {
                        //        if (ANTI_DUMPING_NOTN != "")
                        //        {
                        //            if (IGST_LEVY_EXCEPTION_NOTN != "" && IGST_LEVY_EXCEPTION_SLNO != "")
                        //            {
                        //                igst_anti_dump_amt = Convert.ToDouble(TOTAL_ANTI_AMT) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;

                        //                IGST_LEVY_TOTAL = Convert.ToString(Convert.ToDouble(IGST_LEVY_TOTAL) + igst_anti_dump_amt);
                        //            }
                        //            else if (IGST_LEVY_NOTN != "" && IGST_LEVY_SLNO != "")
                        //            {
                        //                igst_anti_dump_amt = Convert.ToDouble(TOTAL_ANTI_AMT) * Convert.ToDouble(IGST_LEVY_RATE) / 100;

                        //                IGST_LEVY_TOTAL = Convert.ToString(Convert.ToDouble(IGST_LEVY_TOTAL) + igst_anti_dump_amt);
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{

                        //    if (ANTI_DUMPING_NOTN != "")
                        //    {
                        //        if (IGST_LEVY_EXCEPTION_NOTN != "" && IGST_LEVY_EXCEPTION_SLNO != "")
                        //        {
                        //            igst_anti_dump_amt = Convert.ToDouble(TOTAL_ANTI_AMT) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;

                        //            IGST_LEVY_TOTAL = Convert.ToString(Convert.ToDouble(IGST_LEVY_TOTAL) + igst_anti_dump_amt);
                        //        }
                        //        else if (IGST_LEVY_NOTN != "" && IGST_LEVY_SLNO != "")
                        //        {
                        //            igst_anti_dump_amt = Convert.ToDouble(TOTAL_ANTI_AMT) * Convert.ToDouble(IGST_LEVY_RATE) / 100;

                        //            IGST_LEVY_TOTAL = Convert.ToString(Convert.ToDouble(IGST_LEVY_TOTAL) + igst_anti_dump_amt);
                        //        }
                        //    }
                        //}

                        //******************** GST IMPLEMENTATION ON 11-JULY-2017 START***************************




                        if (IGST_LEVY_EXCEPTION_NOTN == "104/94" || IGST_LEVY_EXCEPTION_NOTN == "051/96" || IGST_LEVY_EXCEPTION_NOTN == "084/97" || IGST_LEVY_EXCEPTION_NOTN == "153/94" || IGST_LEVY_EXCEPTION_NOTN == "084/71")
                        {
                            IGST_LEVY_TOTAL = "0.00";
                        }

                        //-----------------Start Scheme-20 Jobbing Duty Nil Implemented on 26July2017------------------//
                        if (SCHEME_NOTN_ == "JBG")
                        {
                            TOTAL_ANTI_AMT = "0.00";
                            BASIC_DUTY_TOTAL = "0.00";
                            CVD_TOTAL = "0.00";
                            CEC_TOTAL = "0.00";
                            CHEC_TOTAL = "0.00";
                            SCHED11_TOTAL = "0.00";
                            GSI_TOTAL = "0.00";
                            TTA_TOTAL = "0.00";
                            NCD_TOTAL = "0.00";
                            CESS_TOTAL = "0.00";
                            SAFE_GUARD_TOTAL = "0.00";

                            CVD_CEC_TOTAL = "0.00";
                            CVD_CHEC_TOTAL = "0.00";

                            ADDLTIONAL_DUTY_TOTAL = "0.00";
                            //IGST_LEVY_TOTAL = "0.00";
                            //IGST_LEVY_COMPENSATION_CESS_TOTAL = "0.00";
                        }
                        //-----------------End Scheme-20 Jobbing Duty Nil Implemented on 26July2017------------------//


                        //******************** GST IMPLEMENTATION ON 11-JULY-2017 END***************************

                        //TOTAL_CUSTOMS_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL));

                        TOTAL_CUSTOMS_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL));
                        TOTAL_IGST_DUTY = Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL);

                        //TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL));
                        TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL));

                        //******************** GST IMPLEMENTATION ON 30-JUN-2017 END***************************


                        PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_BCD_RATE).ToString("F")) + "%";
                        PRODUCT_CVD_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_CVD_RATE).ToString("F")) + "%";

                        //---------------------------------------------------------------------------//

                        if (CETH_SPL_AMT == "" || CETH_SPL_AMT == "0.00")
                        {
                            CETH_SPL_AMT = "";
                        }
                        else
                        {
                            CETH_SPL_AMT = "Rs." + Convert.ToString(Convert.ToDouble(CETH_SPL_AMT).ToString("F")) + "/" + ITEM_QTY_CODE;
                        }

                        //---------------------------------------------------------------------------//

                        //---------------------------------------------------------------------------//

                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                        {
                            CTH_SPL_AMT = "";
                        }

                        if (CTH_SPL_AMT == "" || CTH_SPL_AMT == "0.00")
                        {
                            CTH_SPL_AMT = "";
                        }
                        else
                        {
                            //CTH_SPL_AMT = "Rs." + Convert.ToString(Convert.ToDouble(CTH_SPL_AMT).ToString("F")) + "/" + CTH_SPL_UNIT;
                            CTH_SPL_AMT = "Rs." + Convert.ToString(Convert.ToDouble(CTH_SPL_AMT).ToString("F")) + "/" + CTH_SPL_UNIT;
                        }

                        //---------------------------------------------------------------------------//

                        if (PRODUCT_ADDL_SHEII_NOTN == "009/2006")
                        {
                            PRODUCT_ADDL_SHEII_RATE = "0.00";
                        }

                        if (PRODUCT_ADDL_GSI_NOTN == "011/2006")
                        {
                            PRODUCT_ADDL_GSI_RATE = "0.00";
                        }

                        if (PRODUCT_ADDL_TTA_NOTN == "031/2004")
                        {
                            PRODUCT_ADDL_TTA_RATE = "0.00";
                        }

                        // -----------------Spl Excise Duty(Sched-11) -------------------------------//
                        if (PRODUCT_ADDL_SHEII_RATE == "")
                        {
                            PRODUCT_ADDL_SHEII_RATE = "";
                        }
                        else
                        {
                            PRODUCT_ADDL_SHEII_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_ADDL_SHEII_RATE).ToString("F")) + "%";
                        }

                        //PRODUCT_ADDL_SHEII_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_ADDL_SHEII_RATE).ToString("F")) + "%";
                        // -----------------END Spl Excise Duty(Sched-11) ---------------------------//

                        // -----------------GSI -------------------------------//
                        if (PRODUCT_ADDL_GSI_RATE == "")
                        {
                            PRODUCT_ADDL_GSI_RATE = "";
                        }
                        else
                        {
                            PRODUCT_ADDL_GSI_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_ADDL_GSI_RATE).ToString("F")) + "%";
                        }

                        // -----------------END GSI ---------------------------//

                        // -----------------TTA -------------------------------//
                        if (PRODUCT_ADDL_TTA_RATE == "")
                        {
                            PRODUCT_ADDL_TTA_RATE = "";
                        }
                        else
                        {
                            PRODUCT_ADDL_TTA_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_ADDL_TTA_RATE).ToString("F")) + "%";
                        }

                        if (SOCIAL_WELFARE_RATE == "")
                        {
                            SOCIAL_WELFARE_RATE = "";
                        }
                        else
                        {
                            SOCIAL_WELFARE_RATE = Convert.ToString(Convert.ToDouble(SOCIAL_WELFARE_RATE).ToString("F")) + "%";
                        }

                        // -----------------END TTA ---------------------------//


                        // -----------------CTH QTY1 -------------------------------//
                        if (CTH_QTY1 == "" || CTH_QTY1 == "0")
                        {
                            CTH_QTY1 = "";
                        }
                        else
                        {
                            CTH_QTY1 = CTH_QTY1 + " " + CTH_QTY1_CODE;
                        }

                        // -----------------END CTH QTY1 ---------------------------//

                        // -----------------GSI -------------------------------//
                        if (CTH_NCD_D_RATE == "" || CTH_NCD_D_RATE == "0" || CTH_NCD_D_RATE == "0.00")
                        {
                            CTH_NCD_D_RATE = "";
                        }
                        else
                        {
                            CTH_NCD_D_RATE = Convert.ToString(Convert.ToDouble(CTH_NCD_D_RATE).ToString("F")) + "%";
                        }

                        // -----------------END GSI ---------------------------//


                        // -----------------SAFE GUARD -------------------------------//
                        if (CTH_SAFEGUARD_RATE == "" || CTH_SAFEGUARD_RATE == "0" || CTH_SAFEGUARD_RATE == "0.00")
                        {
                            CTH_SAFEGUARD_RATE = "";
                        }
                        else
                        {
                            CTH_SAFEGUARD_RATE = Convert.ToString(Convert.ToDouble(CTH_SAFEGUARD_RATE).ToString("F")) + "%";
                        }

                        // -----------------END SAFE GUAR ---------------------------//

                        // -----------------AGGREGATE DUTY-------------------------------//
                        if (PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "" || PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "0" || PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "0.00")
                        {
                            PRODUCT_AGGREGATE_DUTY_NOTN_RATE = "";
                        }
                        else
                        {
                            PRODUCT_AGGREGATE_DUTY_NOTN_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE).ToString("F")) + "%";
                        }

                        // -----------------END AGGREGATE DUTY ---------------------------//

                        // -----------------CESS ---------------------------//
                        if (Convert.ToDouble(CETH_CESS_AMTS) == 0.00 || Convert.ToDouble(CETH_CESS_AMTS) <= 0.00)
                        {
                            CETH_CESS_AMTS = "";
                        }
                        else
                        {
                            CETH_CESS_AMTS = ITEM_QTY + "*" + CETH_CESS_AMTS + " " + CETH_CESS_UQC;
                        }

                        if (Convert.ToDouble(CETH_CESS_RTA) == 0.00 || Convert.ToDouble(CETH_CESS_RTA) <= 0.00)
                        {
                            CETH_CESS_RTA = "";
                        }
                        else
                        {
                            CETH_CESS_RTA = CETH_CESS_RTA + "%";
                        }

                        if (CETH_CESS_AMTS == "" && CETH_CESS_RTA == "")
                        {
                            CESS_ROW_VISIBLE = "";
                        }
                        else if (CETH_CESS_AMTS != "")
                        {
                            CESS_ROW_VISIBLE = CETH_CESS_AMTS;
                        }
                        else if (CETH_CESS_RTA != "")
                        {
                            CESS_ROW_VISIBLE = CETH_CESS_RTA;
                        }
                        // -----------------END CESS ---------------------------//

                        //if (PRODUCT_CVD_EDU_CESS_RATE == "013/2012")
                        //{
                        //    PRODUCT_CVD_EDU_CESS_RATE = PRODUCT_CVD_EDU_CESS_RATE + " " + CETH_CVD_EDU_CESS_SL;
                        //    CETH_CVD_EDU_CESS_RATE = "0.00";
                        //    CETH_CVD_SEC_EDU_CESS_RATE = "0.00";
                        //}

                        //----------After Customs Updation on 28Feb2015--------------//

                        if (PRODUCT_CVD_EDU_CESS_RATE == "013/2012")
                        {
                            PRODUCT_CVD_EDU_CESS_RATE = "";
                        }
                        else
                        {
                            PRODUCT_CVD_EDU_CESS_RATE = "";
                        }

                        //----------End After Customs Updation on 28Feb2015----------//

                        //-----------Start Other CVD Duty on 02June2015---------------//

                        if (PRODUCT_OTHER_DUTY_RATE != "")
                        {
                            PRODUCT_OTHER_DUTY_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE).ToString("F")) + "%";
                        }
                        else
                        {
                            if (PRODUCT_OTHER_DUTY_SPL != "")
                            {
                                PRODUCT_OTHER_DUTY_RATE = "Rs." + Convert.ToString(Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL).ToString("F")) + "/" + PRODUCT_OTHER_DUTY_UNIT;
                            }
                        }


                        if (PRODUCT_OTHER_DUTY_NOTN != "")
                        {
                            PRODUCT_OTHER_DUTY_NOTN = PRODUCT_OTHER_DUTY_NOTN + "   " + PRODUCT_OTHER_DUTY_SLNO;
                        }

                        if (IGST_LEVY_EXCEPTION_NOTN != "")
                        {
                            IGST_LEVY_EXCEPTION_NOTN = IGST_LEVY_EXCEPTION_NOTN + " " + IGST_LEVY_EXCEPTION_SLNO + "  " + LEVY_EXCEMPTION_NOTN_TYPE;
                        }

                        if (IGST_LEVY_EXCEPTION_CC_NOTN != "")
                        {
                            IGST_LEVY_EXCEPTION_CC_NOTN = IGST_LEVY_EXCEPTION_CC_NOTN + "   " + IGST_LEVY_EXCEPTION_CC_SLNO;
                        }

                        if (IGST_LEVY_RATE != "")
                        {
                            if (IGST_LEVY_EXCEPTION_RATE != "")
                            {
                                IGST_LEVY_RATE = Convert.ToString(Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE).ToString("F")) + "%";
                            }
                            else
                            {
                                IGST_LEVY_RATE = Convert.ToString(Convert.ToDouble(IGST_LEVY_RATE).ToString("F")) + "%";
                            }
                        }

                        if (IGST_LEVY_COMPENSATION_CESS_RATE != "")
                        {
                            if (IGST_LEVY_EXCEPTION_CC_RATE != "")
                            {
                                IGST_LEVY_COMPENSATION_CESS_RATE = Convert.ToString(Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE).ToString("F")) + "%";
                            }
                            else
                            {
                                IGST_LEVY_COMPENSATION_CESS_RATE = Convert.ToString(Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE).ToString("F")) + "%";
                            }
                        }

                        //-----------End Other CVD Duty on 02June2015---------------//          

                        PRODUCT_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_EDU_CESS_RATE).ToString("F")) + "%";
                        PRODUCT_SEC_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE).ToString("F")) + "%";

                        CETH_CVD_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(CETH_CVD_EDU_CESS_RATE).ToString("F")) + "%";
                        CETH_CVD_SEC_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(CETH_CVD_SEC_EDU_CESS_RATE).ToString("F")) + "%";

                        ////ADDTIONAL_DUTY = Convert.ToString(Convert.ToDouble(ADDTIONAL_DUTY).ToString("F")) + "%";
                        ADDTIONAL_DUTY = "0.00";
                        string ITEM_TTL = Convert.ToString(TOTAL_DUTY);
                        ITEM_TTL = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(TOTAL_DUTY, 2).ToString("F"))));
                        ITEM_TOTAL = Convert.ToDouble(ITEM_TTL);
                        string ASS_TTL = Convert.ToString(ASSESSABLE_TOTAL);
                        ASS_TTL = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(ASSESSABLE_TOTAL, 2).ToString("F"))));
                        ASSESSABLE_TOTAL = Convert.ToDouble(ASS_TTL);
                        string ASS_Value = Convert.ToString(ASSESSABLE_TOTAL);
                        ASS_Value = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(ASSESABLE_VALUE, 2).ToString("F"))));
                        ASSESABLE_VALUE = Convert.ToDouble(ASS_Value);

                        //---------------------------Start Revenue Deposit Calculation------------------------------------------//

                        //if (REVENUEDEPOSIT_ON == "D")
                        //{
                        //    REVENUEDEPOSIT_TOTAL = (ITEM_TOTAL * Convert.ToDouble(REVENUEDEPOSIT_RATE)) / 100;
                        //}
                        //else if (REVENUEDEPOSIT_ON == "A")
                        //{
                        //    REVENUEDEPOSIT_TOTAL = (ASSESABLE_VALUE * Convert.ToDouble(REVENUEDEPOSIT_RATE)) / 100;
                        //}
                        //else if (REVENUEDEPOSIT_ON == "B")
                        //{
                        //    REVENUEDEPOSIT_TOTAL = ((ITEM_TOTAL+ASSESABLE_VALUE) * Convert.ToDouble(REVENUEDEPOSIT_RATE)) / 100;
                        //}

                        if (REVENUEDEPOSIT_ON == "")
                        {
                            REVENUEDEPOSIT_ON = "EMPTY";
                            REVENUEDEPOSIT_RATE = "0.00";
                        }

                        //---------------------------End Revenue Deposit Calculation--------------------------------------------//

                        // OLD --17-May-2018
                        if (ViewState["Item_Cnt"].ToString() == "L")
                        {

                            //-----------------------------UPDATE SINGLE ASS , DUTY , CIF ,CVD VALUE IN ITEM TABLE ------------------------------//
                            Transaction Item_Value_Update = new Transaction();
                            Item_Value_Update.JOBNO = ddlJobNo;
                            Item_Value_Update.ITEM_ID = dss.Tables[0].Rows[b]["ITEM_ID"].ToString();
                            Item_Value_Update.INVOICE_SLNO = Convert.ToString(INVOICE_SLNO);
                            Item_Value_Update.ITEM_SLNO = ITEM_SLNO;
                            Item_Value_Update.ASSESSABLE_VALUE = Convert.ToString(ASSESABLE_VALUE);
                            Item_Value_Update.DUTY_VALUE = Convert.ToString(TOTAL_DUTY);
                            Item_Value_Update.CIF_VALUE = Convert.ToString(INDIVITUAL_CIF_AMOUNT);
                            Item_Value_Update.CVD_VALUE = Convert.ToString(CVD_TOTAL);

                            Item_Value_Update.BASIC_VALUE = Convert.ToString(BASIC_DUTY_TOTAL);
                            Item_Value_Update.CEC_VALUE = Convert.ToString(CEC_TOTAL);
                            Item_Value_Update.CHEC_VALUE = Convert.ToString(CHEC_TOTAL);
                            Item_Value_Update.ADD_DUTY_VALUE = Convert.ToString(ADDLTIONAL_DUTY_TOTAL);

                            Item_Value_Update.INDIVITUAL_FREIGHT_AMOUNT = Convert.ToString(Math.Round(INDIVITUAL_FREIGHT_AMOUNT, 2).ToString("F"));
                            Item_Value_Update.INDIVITUAL_INSURANCE_AMOUNT = Convert.ToString(Math.Round(INDIVITUAL_INSURANCE_AMOUNT, 2).ToString("F"));
                            Item_Value_Update.INDIVITUAL_MISC_AMOUNT = Convert.ToString(Math.Round(INDIVITUAL_MISC_AMOUNT, 2).ToString("F"));


                            Item_Value_Update.INDIVITUAL_EDU_CESS_AMT = CEC_TOTAL;
                            Item_Value_Update.INDIVITUAL_SEC_HIGHER_CESS_AMT = CHEC_TOTAL;
                            Item_Value_Update.INDIVITUAL_LANDING_CHARGE = Convert.ToString(Math.Round(INDIVITUAL_LANDING_COST, 2).ToString("F"));


                            Item_Value_Update.CHECKLIST_BCD_RATE = MERIT_PRODUCT_BCD_RATE;
                            Item_Value_Update.CHECKLIST_CVD_RATE = MERIT_PRODUCT_CVD_RATE;
                            Item_Value_Update.CHECKLIST_ADDL_DUTY_RATE = ADDTIONAL_DUTY_RATE;

                            Item_Value_Update.MERIT_DUTY_VALUE = MERIT_TOTAL_DEBIT_DUTY;

                            //Item_Value_Update.PRODUCT_BCD_RATE = "";
                            //Item_Value_Update.PRODUCT_CVD_RATE = "";
                            //Item_Value_Update.ADDTIONAL_DUTY_RATE = "";

                            Item_Value_Update.PRODUCT_BCD_RATE = PRODUCT_BCD_RATE_UPDATE;
                            Item_Value_Update.PRODUCT_CVD_RATE = PRODUCT_CVD_RATE_UPDATE;
                            //Item_Value_Update.ADDTIONAL_DUTY_RATE = ADDTIONAL_DUTY_RATE;


                            Item_Value_Update.MERIT_BASIC_VALUE = Convert.ToString(MERIT_BASIC_VALUE);
                            Item_Value_Update.MERIT_CVD_VALUE = Convert.ToString(MERIT_CVD_VALUE);
                            Item_Value_Update.MERIT_CEC_VALUE = Convert.ToString(MERIT_CEC_VALUE);
                            Item_Value_Update.MERIT_CHEC_VALUE = Convert.ToString(MERIT_CHEC_VALUE);
                            Item_Value_Update.MERIT_ADD_DUTY_VALUE = Convert.ToString(MERIT_ADD_DUTY_VALUE);


                            Item_Value_Update.MERIT_NOTN_BASIC_VALUE = Convert.ToString(MERIT_NOTN_BASIC_VALUE);
                            Item_Value_Update.MERIT_NOTN_CVD_VALUE = Convert.ToString(MERIT_NOTN_CVD_VALUE);
                            Item_Value_Update.MERIT_NOTN_CEC_VALUE = Convert.ToString(MERIT_NOTN_CEC_VALUE);
                            Item_Value_Update.MERIT_NOTN_CHEC_VALUE = Convert.ToString(MERIT_NOTN_CHEC_VALUE);
                            Item_Value_Update.MERIT_NOTN_ADD_DUTY_VALUE = Convert.ToString(MERIT_NOTN_ADD_DUTY_VALUE);
                            Item_Value_Update.MERIT_NOTN_CESS_VALUE = Convert.ToString(MERIT_NOTN_CESS_VALUE);
                            Item_Value_Update.MERIT_NOTN_NCD_VALUE = Convert.ToString(MERIT_NOTN_NCD_VALUE);
                            Item_Value_Update.INDIVITUAL_HSS_AMOUNT = Convert.ToString(INDIVITUAL_HSS_AMOUNT);

                            Item_Value_Update.CHECKLIST_IGST_LEVY_AMOUNT = Convert.ToString(IGST_LEVY_TOTAL);
                            Item_Value_Update.CHECKLIST_COMPENSATION_CC_AMOUNT = Convert.ToString(IGST_LEVY_COMPENSATION_CESS_TOTAL);

                            Item_Value_Update.IGST_LEVY_RATE = Convert.ToString(IGST_LEVY_RATE_UPDATE);
                            Item_Value_Update.IGST_LEVY_COMPENSATION_CESS_RATE = Convert.ToString(IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE);

                            Item_Value_Update.CHECKLIST_SOCIAL_WELFARE_AMT = Convert.ToString(TOTAL_SOCIAL_WELFARE);

                            //Item_Value_Update.WORKING_PERIOD = HttpContext.Current.Session["WorkingPeriod"].ToString();
                            Item_Value_Update.WORKING_PERIOD = SELECT_BRANCH;
                            Item_Value_Update.Import_Item_ASS_Duty_CIF_CVD_VLAUE_UPDATE();

                            //-----------------------------UPDATE SINGLE ASS , DUTY , CIF ,CVD VALUE IN ITEM TABLE ------------------------------//
                        }
                        else
                        {
                            //-----------------------------UPDATE SINGLE ASS , DUTY , CIF ,CVD VALUE IN ITEM TABLE ------------------------------//

                            dr = dtt.NewRow();
                            dr[0] = Convert.ToString(INVOICE_SLNO);
                            dr[1] = Convert.ToString(ITEM_SLNO);
                            dr[2] = Convert.ToString(ASSESABLE_VALUE);
                            dr[3] = Convert.ToString(TOTAL_DUTY);
                            dr[4] = Convert.ToString(INDIVITUAL_CIF_AMOUNT);
                            dr[5] = Convert.ToString(CVD_TOTAL);
                            dr[6] = Convert.ToString(BASIC_DUTY_TOTAL);
                            dr[7] = Convert.ToString(CEC_TOTAL);  //------------1
                            dr[8] = Convert.ToString(CHEC_TOTAL); //------------2
                            dr[9] = Convert.ToString(ADDLTIONAL_DUTY_TOTAL);
                            dr[10] = Convert.ToString(Math.Round(INDIVITUAL_FREIGHT_AMOUNT, 2).ToString("F"));
                            dr[11] = Convert.ToString(Math.Round(INDIVITUAL_INSURANCE_AMOUNT, 2).ToString("F"));
                            dr[12] = Convert.ToString(Math.Round(INDIVITUAL_MISC_AMOUNT, 2).ToString("F"));
                            dr[13] = Convert.ToString(CEC_TOTAL); //------------1
                            dr[14] = Convert.ToString(CHEC_TOTAL);//------------2
                            dr[15] = Convert.ToString(Math.Round(INDIVITUAL_LANDING_COST, 2).ToString("F"));
                            dr[16] = MERIT_PRODUCT_BCD_RATE;
                            dr[17] = MERIT_PRODUCT_CVD_RATE;
                            dr[18] = ADDTIONAL_DUTY_RATE;
                            dr[19] = MERIT_TOTAL_DEBIT_DUTY;
                            dr[20] = PRODUCT_BCD_RATE_UPDATE;
                            dr[21] = PRODUCT_CVD_RATE_UPDATE;
                            dr[22] = Convert.ToString(MERIT_BASIC_VALUE);
                            dr[23] = Convert.ToString(MERIT_CVD_VALUE);
                            dr[24] = Convert.ToString(MERIT_CEC_VALUE);
                            dr[25] = Convert.ToString(MERIT_CHEC_VALUE);
                            dr[26] = Convert.ToString(MERIT_ADD_DUTY_VALUE);
                            dr[27] = Convert.ToString(MERIT_NOTN_BASIC_VALUE);
                            dr[28] = Convert.ToString(MERIT_NOTN_CVD_VALUE);
                            dr[29] = Convert.ToString(MERIT_NOTN_CEC_VALUE);
                            dr[30] = Convert.ToString(MERIT_NOTN_CHEC_VALUE);
                            dr[31] = Convert.ToString(MERIT_NOTN_ADD_DUTY_VALUE);
                            dr[32] = Convert.ToString(MERIT_NOTN_CESS_VALUE);
                            dr[33] = Convert.ToString(MERIT_NOTN_NCD_VALUE);
                            dr[34] = Convert.ToString(INDIVITUAL_HSS_AMOUNT);
                            dr[35] = Convert.ToString(IGST_LEVY_TOTAL);
                            dr[36] = Convert.ToString(IGST_LEVY_COMPENSATION_CESS_TOTAL);
                            dr[37] = Convert.ToString(IGST_LEVY_RATE_UPDATE);
                            dr[38] = Convert.ToString(IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE);
                            dr[39] = Convert.ToString(TOTAL_SOCIAL_WELFARE);

                            dtt.Rows.Add(dr);
                        }

                        //-----------------------------UPDATE SINGLE ASS , DUTY , CIF ,CVD VALUE IN ITEM TABLE ------------------------------//


                        //------------License_Details  Debit Amount Calculation ------------------------//

                        //License_ds = (DataSet)HttpContext.Current.Session["IMPORT_CHECKLIST"];
                        //DataView view_lic = License_ds.Tables[8].DefaultView;


                        DataView view_lic = ds3.DefaultView;
                        view_lic.RowFilter = "INVOICE_SLNO = '" + INVOICE_SLNO + "' and " + "ITEM_SLNO = '" + ITEM_SLNO + "'";

                        DataTable table_Lic = view_lic.ToTable();
                        DataSet dss_Lic = new DataSet();
                        dss_Lic.Tables.Add(table_Lic);

                        int l = 0;

                        SUM_DEBIT_QTY = 0.0;

                        while (dss_Lic.Tables[0].Rows.Count > l)
                        {
                            DEBIT_QTY = Convert.ToDouble(dss_Lic.Tables[0].Rows[l]["DEBIT_QTY"].ToString());
                            //ENTRY_DEBIT_DUTY = dss_Lic.Tables[0].Rows[l]["ENTRY_DEBIT_DUTY"].ToString();
                            //SUM_ENTRY_DEBIT_DUTY = SUM_ENTRY_DEBIT_DUTY +Convert.ToDouble(ENTRY_DEBIT_DUTY);
                            SUM_DEBIT_QTY = SUM_DEBIT_QTY + DEBIT_QTY;
                            l++;
                        }

                        //DEBIT_DUTY = Convert.ToDouble(TOTAL_DEBIT_DUTY);//CHITHRA HIDE BY 16/03/2017
                        DEBIT_DUTY = Math.Round(Convert.ToDouble(TOTAL_DEBIT_DUTY) + 0.00, 2);

                        int li = 0;
                        while (dss_Lic.Tables[0].Rows.Count > li)
                        {
                            //if (dss_Lic.Tables[0].Rows.Count > 0)
                            //{

                            string debit;

                            ENTRY_DEBIT_DUTY = dss_Lic.Tables[0].Rows[li]["ENTRY_DEBIT_DUTY"].ToString();
                            //SUM_ENTRY_DEBIT_DUTY =  Convert.ToDouble(ENTRY_DEBIT_DUTY);

                            debit = dss_Lic.Tables[0].Rows[li]["DEBIT_AMT"].ToString();
                            INDI_DEBIT_QTY = Convert.ToDouble(dss_Lic.Tables[0].Rows[li]["DEBIT_QTY"].ToString());
                            LICENSE_ID = dss_Lic.Tables[0].Rows[li]["LICENSE_ID"].ToString();


                            if (debit == "")
                            {
                                debit = "0";
                            }

                            DEBIT_AMT = Convert.ToDouble(debit);

                            if (DEBIT_AMT == null || DEBIT_AMT == 0.00 || DEBIT_AMT == 0.0 || DEBIT_AMT == 1.0 || DEBIT_AMT == 1.00)
                            {
                                //if (DEBIT_AMT == "" || DEBIT_AMT == "0" || DEBIT_AMT == "1")
                                //{
                                double debit_amt = 0;

                                //debit_amt = Math.Round((ASSESABLE_VALUE * 0.99) / 100);

                                //debit_amt = Math.Round((ASSESABLE_VALUE * 100) / 101); //modified on 15_Feb_2014 with Subbu sir
                                //debit_amt = (ASSESABLE_VALUE * 100) / 101; //modified on 15_Feb_2014 with Subbu sir

                                debit_amt = ASSESABLE_VALUE; //Implemented on 29Sep2017

                                //LICENSE_DEBIT_AMT = ASSESABLE_VALUE - debit_amt; //Disabled and uploaded to server on 26_Feb_2014 with Subbu sir

                                LICENSE_DEBIT_AMT = Math.Round(debit_amt + 0.00, 2);

                                if (SCHEME_NOTN_ == "DEEC" || SCHEME_NOTN_ == "EPCG" || SCHEME_NOTN_ == "FPS" || SCHEME_NOTN_ == "SHIS" || SCHEME_NOTN_ == "FMS" || SCHEME_NOTN_ == "DEPB" || SCHEME_NOTN_ == "MEIS" || SCHEME_NOTN_ == "INC" || SCHEME_NOTN_ == "(KRSH)" || SCHEME_NOTN_ == "SEIS" || SCHEME_NOTN_ == "DFCC" || SCHEME_NOTN_ == "DFIA")
                                {
                                    if (DEBIT_QTY != null)
                                    {

                                        LICENSE_DEBIT_AMT = (LICENSE_DEBIT_AMT * INDI_DEBIT_QTY) / SUM_DEBIT_QTY;

                                        LICENSE_DEBIT_AMT = Math.Round(LICENSE_DEBIT_AMT + 0.00, 2);

                                        //DEBIT_DUTY = Convert.ToDouble(TOTAL_DEBIT_DUTY);

                                        TOTAL_DEBIT_DUTY = Convert.ToString((DEBIT_DUTY * INDI_DEBIT_QTY) / SUM_DEBIT_QTY);

                                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_DEBIT_DUTY) + 0.00, 2));
                                    }
                                }


                                //-------------Update Debit Amount and Debit Duty in License Details Table--------------------//
                                Transact.JOBNO = ddlJobNo;
                                Transact.INVOICE_SLNO = Convert.ToString(INVOICE_SLNO);
                                Transact.ITEM_SLNO = ITEM_SLNO;
                                Transact.DEBIT_AMT = Convert.ToString(LICENSE_DEBIT_AMT);
                                Transact.DEBIT_DUTY = Convert.ToString(TOTAL_DEBIT_DUTY);
                                Transact.LICENSE_ID = LICENSE_ID;
                                // Transact.WORKING_PERIOD = working_period;
                                Transact.WORKING_PERIOD = SELECT_BRANCH;
                                Transact.Ename = "Update_Debit_Amt";
                                Transact.RetrieveAll_License_Details();
                                //------------End License_Details-----------------------------------------------//
                            }
                            else
                            {
                                if (SCHEME_NOTN_ == "DEEC" || SCHEME_NOTN_ == "EPCG" || SCHEME_NOTN_ == "SHIS" || SCHEME_NOTN_ == "FMS" || SCHEME_NOTN_ == "DEPB" || SCHEME_NOTN_ == "MEIS" || SCHEME_NOTN_ == "INC" || SCHEME_NOTN_ == "(KRSH)" || SCHEME_NOTN_ == "SEIS" || SCHEME_NOTN_ == "DFCC" || SCHEME_NOTN_ == "DFIA")
                                {
                                    if (DEBIT_QTY != null)
                                    {

                                        LICENSE_DEBIT_AMT = (LICENSE_DEBIT_AMT * INDI_DEBIT_QTY) / SUM_DEBIT_QTY;

                                        LICENSE_DEBIT_AMT = Math.Round(LICENSE_DEBIT_AMT + 0.00, 2);

                                        //DEBIT_DUTY = Convert.ToDouble(TOTAL_DEBIT_DUTY);

                                        TOTAL_DEBIT_DUTY = Convert.ToString((DEBIT_DUTY * INDI_DEBIT_QTY) / SUM_DEBIT_QTY);

                                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_DEBIT_DUTY) + 0.00, 2));
                                    }

                                }

                                else if (SCHEME_NOTN_ == "FPS")
                                {
                                    if (DEBIT_QTY != null)
                                    {
                                        if (SUM_DEBIT_QTY > 0.00)
                                        {
                                            LICENSE_DEBIT_AMT = (LICENSE_DEBIT_AMT * INDI_DEBIT_QTY) / SUM_DEBIT_QTY;
                                        }

                                        LICENSE_DEBIT_AMT = Math.Round(LICENSE_DEBIT_AMT + 0.00, 2);

                                        //DEBIT_DUTY = Convert.ToDouble(TOTAL_DEBIT_DUTY);
                                        if (SUM_DEBIT_QTY > 0.00)
                                        {
                                            TOTAL_DEBIT_DUTY = Convert.ToString((DEBIT_DUTY * INDI_DEBIT_QTY) / SUM_DEBIT_QTY);
                                        }
                                        else
                                        {
                                            if (Session["COMPANY_ID"].ToString() == "333")
                                            {
                                                TOTAL_DEBIT_DUTY = ENTRY_DEBIT_DUTY;
                                            }
                                        }

                                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_DEBIT_DUTY) + 0.00, 2));
                                    }
                                }


                                //-------------Update Debit Duty in License Details Table--------------------//
                                Transact.JOBNO = ddlJobNo;
                                Transact.INVOICE_SLNO = Convert.ToString(INVOICE_SLNO);
                                Transact.ITEM_SLNO = ITEM_SLNO;
                                Transact.DEBIT_AMT = "";
                                Transact.DEBIT_DUTY = Convert.ToString(TOTAL_DEBIT_DUTY);
                                Transact.LICENSE_ID = LICENSE_ID;
                                // Transact.WORKING_PERIOD = working_period;
                                Transact.WORKING_PERIOD = SELECT_BRANCH;
                                Transact.Ename = "Update_Debit_Amt";
                                Transact.RetrieveAll_License_Details();

                                //------------End License_Details-----------------------------------------------//
                            }
                            //}
                            li++;
                        }


                        PRODUCT_TARIFF_QTY = PRODUCT_TARIFF_QTY + " " + PRODUCT_TARIFF_AMOUNT_UNIT;

                        //PRODUCT_TARIFF_AMOUNT = "USD"+" "+ PRODUCT_TARIFF_AMOUNT;

                        PRODUCT_TARIFF_SLNO = PRODUCT_TARIFF_SLNO + "   " + "USD" + " " + PRODUCT_TARIFF_AMOUNT;

                        if (PRODUCT_SAPTA_RATE == "" || PRODUCT_SAPTA_RATE == "0" || PRODUCT_SAPTA_RATE == "0.00" || Convert.ToDecimal(PRODUCT_SAPTA_RATE) <= 0)
                        {
                            PRODUCT_SAPTA_SLNO = PRODUCT_SAPTA_SLNO;
                        }
                        else
                        {
                            PRODUCT_SAPTA_SLNO = PRODUCT_SAPTA_SLNO + "       " + PRODUCT_SAPTA_RATE + "%";
                        }

                        if (SCHEME_CODE.Trim() == "00")
                        {
                            SCHEME_CODE = "";
                        }


                        if (SCHEME_NOTN_ == "0" || SCHEME_NOTN_ == "")
                        {
                            SCHEME_NOTN = "";

                            Load_Item_Details.Add(new Transaction_Default2()
                            {
                                INVOICE_SLNO = INVOICE_SLNO,
                                INVOICE_NO = INVOICE_NO_ITEM,
                                ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                                ITEM_QTY = ITEM_QTY,
                                ITEM_QTY_CODE = ITEM_QTY_CODE,
                                ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                                SCHEME_CODE = SCHEME_CODE,
                                ANTI_DUMPING_NOTN = ANTI_DUMPING_NOTN,
                                CTH_NO = CTH_NO,
                                PRODUCT_RITC = PRODUCT_RITC,
                                PRODUCT_CTH = PRODUCT_CTH,
                                PRODUCT_CVD_RATE = PRODUCT_CVD_RATE,
                                PRODUCT_EDU_CESS_RATE = PRODUCT_EDU_CESS_RATE,
                                PRODUCT_EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN,
                                PRODUCT_SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN,

                                PRODUCT_SEC_EDU_CESS_RATE = PRODUCT_SEC_EDU_CESS_RATE,
                                PRODUCT_BCD_RATE = PRODUCT_BCD_RATE,
                                PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN,
                                PRODUCT_CVD_NOTN = PRODUCT_CVD_NOTN,
                                PRODUCT_ADDL_GSI_NOTN = PRODUCT_ADDL_GSI_NOTN,
                                PRODUCT_ADDL_TTA_NOTN = PRODUCT_ADDL_TTA_NOTN,
                                PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN + " " + PRODUCT_ADDL_DUTY_NOTN_SLNO,
                                PRODUCT_CETH = PRODUCT_CETH,
                                ITEM_SLNO = ITEM_SLNO,
                                BASIC_DUTY_TOTAL = BASIC_DUTY_TOTAL,
                                ASSESABLE_VALUE = ASSESABLE_VALUE,
                                ADDTIONAL_DUTY = ADDTIONAL_DUTY,

                                CVD_TOTAL = CVD_TOTAL,

                                //------------------//
                                PRODUCT_ADDL_SHEII_NOTN = PRODUCT_ADDL_SHEII_NOTN,
                                PRODUCT_ADDL_SHEII_RATE = PRODUCT_ADDL_SHEII_RATE,
                                SCHED11_TOTAL = SCHED11_TOTAL,

                                PRODUCT_ADDL_GSI_RATE = PRODUCT_ADDL_GSI_RATE,
                                GSI_TOTAL = GSI_TOTAL,

                                PRODUCT_ADDL_TTA_RATE = PRODUCT_ADDL_TTA_RATE,
                                TTA_TOTAL = TTA_TOTAL,

                                CETH_SPL_AMT = CETH_SPL_AMT,
                                CTH_SPL_AMT = CTH_SPL_AMT,

                                CTH_QTY1 = CTH_QTY1,

                                CTH_NCD_D_RATE = CTH_NCD_D_RATE,
                                NCD_TOTAL = NCD_TOTAL,

                                CETH_CESS_RTA = CETH_CESS_RTA,
                                CETH_CESS_AMTS = CETH_CESS_AMTS,
                                CESS_TOTAL = CESS_TOTAL,

                                CESS_ROW_VISIBLE = CESS_ROW_VISIBLE,

                                CTH_SAFEGUARD_RATE = CTH_SAFEGUARD_RATE,
                                SAFE_GUARD_TOTAL = SAFE_GUARD_TOTAL,
                                PRODUCT_SAFEGUARD_NOTN = PRODUCT_SAFEGUARD_NOTN + " " + PRODUCT_SAFEGUARD_SLNO,

                                //------------------//

                                CEC_TOTAL = CEC_TOTAL,
                                CHEC_TOTAL = CHEC_TOTAL,
                                ADDLTIONAL_DUTY_TOTAL = ADDLTIONAL_DUTY_TOTAL,
                                TOTAL_ITEM_DUTY = TOTAL_ITEM_DUTY,
                                NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS,
                                ASSESSABLE_TOTAL = ASSESSABLE_TOTAL,
                                ITEM_TOTAL = ITEM_TOTAL,

                                PRODUCT_AGGREGATE_DUTY_NOTN = PRODUCT_AGGREGATE_DUTY_NOTN,
                                PRODUCT_AGGREGATE_DUTY_NOTN_SL = PRODUCT_AGGREGATE_DUTY_NOTN_SL,
                                PRODUCT_AGGREGATE_DUTY_NOTN_RATE = PRODUCT_AGGREGATE_DUTY_NOTN_RATE,
                                AGGREGATE_TOTAL = AGGREGATE_TOTAL,

                                PRODUCT_TARIFF_NOTN = PRODUCT_TARIFF_NOTN,
                                PRODUCT_TARIFF_SLNO = PRODUCT_TARIFF_SLNO,
                                PRODUCT_TARIFF_QTY = PRODUCT_TARIFF_QTY,
                                PRODUCT_TARIFF_AMOUNT = PRODUCT_TARIFF_AMOUNT,
                                PRODUCT_TARIFF_AMOUNT_UNIT = PRODUCT_TARIFF_AMOUNT_UNIT,

                                PRODUCT_SAPTA_NOTN = PRODUCT_SAPTA_NOTN,
                                PRODUCT_SAPTA_SLNO = PRODUCT_SAPTA_SLNO,
                                PRODUCT_SAPTA_RATE = PRODUCT_SAPTA_RATE,

                                PRODUCT_CVD_EDU_CESS_RATE = PRODUCT_CVD_EDU_CESS_RATE,
                                PRODUCT_CVD_SEC_EDU_CESS_RATE = PRODUCT_CVD_SEC_EDU_CESS_RATE,
                                CVD_CEC_TOTAL = CVD_CEC_TOTAL,
                                CVD_CHEC_TOTAL = CVD_CHEC_TOTAL,

                                CETH_CVD_EDU_CESS_SL = CETH_CVD_EDU_CESS_SL,
                                PRODUCT_CVD_EDU_CESS_NOTN_SL = PRODUCT_CVD_EDU_CESS_NOTN_SL,
                                CETH_CVD_EDU_CESS_RATE = CETH_CVD_EDU_CESS_RATE,
                                CETH_CVD_SEC_EDU_CESS_RATE = CETH_CVD_SEC_EDU_CESS_RATE,
                                PRODUCT_OTHER_DUTY_TOTAL = PRODUCT_OTHER_DUTY_TOTAL,
                                PRODUCT_OTHER_DUTY_RATE = PRODUCT_OTHER_DUTY_RATE,
                                PRODUCT_OTHER_DUTY_NOTN = PRODUCT_OTHER_DUTY_NOTN,

                                REVENUEDEPOSIT_RATE = REVENUEDEPOSIT_RATE,
                                REVENUEDEPOSIT_ON = REVENUEDEPOSIT_ON,
                                // REVENUEDEPOSIT_TOTAL = REVENUEDEPOSIT_TOTAL

                                INFRA_CESS_NOTN = INFRA_CESS_NOTN,
                                INFRA_CESS_NOTN_SL = INFRA_CESS_NOTN_SL,
                                INFRA_CESS_NOTN_RATE = INFRA_CESS_NOTN_RATE,
                                INFRA_CESS_TOTAL = INFRA_CESS_TOTAL,
                                COUNTRY_OF_ORIGIN = COUNTRY_OF_ORIGIN,
                                IGST_LEVY_TOTAL = IGST_LEVY_TOTAL,
                                IGST_LEVY_COMPENSATION_CESS_TOTAL = IGST_LEVY_COMPENSATION_CESS_TOTAL,
                                IGST_LEVY_NOTN = IGST_LEVY_NOTN,
                                IGST_LEVY_SLNO = IGST_LEVY_SLNO,
                                IGST_LEVY_RATE = IGST_LEVY_RATE,
                                IGST_LEVY_EXCEPTION_NOTN = IGST_LEVY_EXCEPTION_NOTN,
                                IGST_LEVY_EXCEPTION_SLNO = IGST_LEVY_EXCEPTION_SLNO,
                                IGST_LEVY_EXCEPTION_RATE = IGST_LEVY_EXCEPTION_RATE,
                                IGST_LEVY_COMPENSATION_CESS_NOTN = IGST_LEVY_COMPENSATION_CESS_NOTN,
                                IGST_LEVY_COMPENSATION_CESS_SLNO = IGST_LEVY_COMPENSATION_CESS_SLNO,
                                IGST_LEVY_COMPENSATION_CESS_RATE = IGST_LEVY_COMPENSATION_CESS_RATE,
                                IGST_LEVY_EXCEPTION_CC_NOTN = IGST_LEVY_EXCEPTION_CC_NOTN,
                                IGST_LEVY_EXCEPTION_CC_SLNO = IGST_LEVY_EXCEPTION_CC_SLNO,
                                IGST_LEVY_EXCEPTION_CC_RATE = IGST_LEVY_EXCEPTION_CC_RATE,
                                END_USE_OF_ITEM = END_USE_OF_ITEM,
                                TOTAL_CUSTOMS_DUTY = TOTAL_CUSTOMS_DUTY,
                                TOTAL_IGST_DUTY = TOTAL_IGST_DUTY,
                                TOTAL_SOCIAL_WELFARE = TOTAL_SOCIAL_WELFARE,
                                SOCIAL_WELFARE_NOTN = SOCIAL_WELFARE_NOTN,
                                SOCIAL_WELFARE_NOTN_SLNO = SOCIAL_WELFARE_NOTN_SLNO,
                                SOCIAL_WELFARE_RATE = SOCIAL_WELFARE_RATE

                            });

                            if (Session["COMPANY_ID"].ToString() == "381" || Session["COMPANY_ID"].ToString() == "382")
                            {
                                if (IGST_LEVY_EXCEPTION_NOTN == "")
                                {
                                    LEVY_EXCEMPTION_NOTN_TYPE = "";
                                }

                                if (IGST_LEVY_EXCEPTION_CC_NOTN == "")
                                {
                                    LEVY_EXCEPTION_CC_NOTN_TYPE = "";
                                }

                                if (IGST_LEVY_NOTN != "")
                                {
                                    DUTY_TYPE = "G  /  I";
                                }
                                else
                                {
                                    DUTY_TYPE = "";
                                }
                                if (IGST_LEVY_COMPENSATION_CESS_NOTN != "")
                                {
                                    ADDL_FLAG = "G  /  P";
                                }
                                else
                                {
                                    ADDL_FLAG = "";
                                }
                                if (IGST_LEVY_NOTN != "")
                                {
                                    Load_Item_IGST_Details.Add(new Transaction_Default2()
                                    {

                                        INVOICE_SLNO = INVOICE_SLNO,
                                        ITEM_SLNO = ITEM_SLNO,
                                        IGST_LEVY_TOTAL = IGST_LEVY_TOTAL,
                                        IGST_LEVY_COMPENSATION_CESS_TOTAL = IGST_LEVY_COMPENSATION_CESS_TOTAL,
                                        IGST_LEVY_NOTN = IGST_LEVY_NOTN,
                                        IGST_LEVY_SLNO = IGST_LEVY_SLNO,
                                        IGST_LEVY_RATE = IGST_LEVY_RATE,
                                        IGST_LEVY_EXCEPTION_NOTN = IGST_LEVY_EXCEPTION_NOTN,
                                        IGST_LEVY_EXCEPTION_SLNO = IGST_LEVY_EXCEPTION_SLNO,
                                        IGST_LEVY_EXCEPTION_RATE = IGST_LEVY_EXCEPTION_RATE,
                                        IGST_LEVY_COMPENSATION_CESS_NOTN = IGST_LEVY_COMPENSATION_CESS_NOTN,
                                        IGST_LEVY_COMPENSATION_CESS_SLNO = IGST_LEVY_COMPENSATION_CESS_SLNO,
                                        IGST_LEVY_COMPENSATION_CESS_RATE = IGST_LEVY_COMPENSATION_CESS_RATE,
                                        IGST_LEVY_EXCEPTION_CC_NOTN = IGST_LEVY_EXCEPTION_CC_NOTN,
                                        IGST_LEVY_EXCEPTION_CC_SLNO = IGST_LEVY_EXCEPTION_CC_SLNO,
                                        IGST_LEVY_EXCEPTION_CC_RATE = IGST_LEVY_EXCEPTION_CC_RATE,
                                        LEVY_EXCEMPTION_NOTN_TYPE = LEVY_EXCEMPTION_NOTN_TYPE,
                                        LEVY_EXCEPTION_CC_NOTN_TYPE = LEVY_EXCEPTION_CC_NOTN_TYPE,
                                        DUTY_TYPE = DUTY_TYPE,
                                        ADDL_FLAG = ADDL_FLAG

                                    });
                                }
                            }
                            b++;
                        }
                        else
                        {
                            SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO;

                            if (SCHEME_CODE == "21")
                            {
                                //EOU_MERIT_BASIC_DUTY = "BCD   " + Convert.ToString(Math.Round(Convert.ToDouble(MERIT_BASIC_DUTY) + 0.00, 2));

                                //EOU_MERIT_BASIC_DUTY = "BCD   " + Convert.ToString(Math.Round(Convert.ToDouble(MERIT_BASIC_DUTY + MERIT_NOTN_CEC_VALUE + MERIT_NOTN_CHEC_VALUE) + 0.00, 2));                                              

                                //EOU_MERIT_BASIC_DUTY = "BCD   " + Convert.ToString(Math.Round(Convert.ToDouble(MERIT_NOTN_BASIC_VALUE + MERIT_NOTN_CEC_VALUE + MERIT_NOTN_CHEC_VALUE) + 0.00, 2));

                                EOU_MERIT_BASIC_DUTY = "BCD  Fg " + Convert.ToString(Math.Round(Convert.ToDouble(MERIT_NOTN_BASIC_VALUE + merit_social_welfare_cess) + 0.00, 2));


                                //EOU_MERIT_CVD = "CVD   " + Convert.ToString(Math.Round(Convert.ToDouble(MERIT_CVD) + 0.00, 2)); ;
                            }

                            Load_Item_Details.Add(new Transaction_Default2()
                            {
                                INVOICE_SLNO = INVOICE_SLNO,
                                INVOICE_NO = INVOICE_NO_ITEM,
                                ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                                ITEM_QTY = ITEM_QTY,
                                ITEM_QTY_CODE = ITEM_QTY_CODE,
                                ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                                SCHEME_CODE = SCHEME_CODE,
                                SCHEME_NOTN = SCHEME_NOTN,
                                ANTI_DUMPING_NOTN = ANTI_DUMPING_NOTN,
                                CTH_NO = CTH_NO,
                                PRODUCT_RITC = PRODUCT_RITC,
                                PRODUCT_CTH = PRODUCT_CTH,
                                PRODUCT_CVD_RATE = PRODUCT_CVD_RATE,
                                PRODUCT_EDU_CESS_RATE = PRODUCT_EDU_CESS_RATE,
                                PRODUCT_EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN,
                                PRODUCT_SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN,

                                PRODUCT_SEC_EDU_CESS_RATE = PRODUCT_SEC_EDU_CESS_RATE,
                                PRODUCT_BCD_RATE = PRODUCT_BCD_RATE,
                                PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN,
                                PRODUCT_CVD_NOTN = PRODUCT_CVD_NOTN,
                                PRODUCT_ADDL_GSI_NOTN = PRODUCT_ADDL_GSI_NOTN,
                                PRODUCT_ADDL_TTA_NOTN = PRODUCT_ADDL_TTA_NOTN,
                                PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN + " " + PRODUCT_ADDL_DUTY_NOTN_SLNO,

                                PRODUCT_CETH = PRODUCT_CETH,
                                ITEM_SLNO = ITEM_SLNO,
                                BASIC_DUTY_TOTAL = BASIC_DUTY_TOTAL,
                                ASSESABLE_VALUE = ASSESABLE_VALUE,
                                ADDTIONAL_DUTY = ADDTIONAL_DUTY,

                                CVD_TOTAL = CVD_TOTAL,
                                //------------------//
                                PRODUCT_ADDL_SHEII_NOTN = PRODUCT_ADDL_SHEII_NOTN,
                                PRODUCT_ADDL_SHEII_RATE = PRODUCT_ADDL_SHEII_RATE,
                                SCHED11_TOTAL = SCHED11_TOTAL,

                                PRODUCT_ADDL_GSI_RATE = PRODUCT_ADDL_GSI_RATE,
                                GSI_TOTAL = GSI_TOTAL,

                                PRODUCT_ADDL_TTA_RATE = PRODUCT_ADDL_TTA_RATE,
                                TTA_TOTAL = TTA_TOTAL,

                                CETH_SPL_AMT = CETH_SPL_AMT,
                                CTH_SPL_AMT = CTH_SPL_AMT,

                                CTH_QTY1 = CTH_QTY1,

                                CTH_NCD_D_RATE = CTH_NCD_D_RATE,
                                NCD_TOTAL = NCD_TOTAL,

                                CETH_CESS_RTA = CETH_CESS_RTA,
                                CETH_CESS_AMTS = CETH_CESS_AMTS,
                                CESS_TOTAL = CESS_TOTAL,
                                CESS_ROW_VISIBLE = CESS_ROW_VISIBLE,

                                CTH_SAFEGUARD_RATE = CTH_SAFEGUARD_RATE,
                                SAFE_GUARD_TOTAL = SAFE_GUARD_TOTAL,
                                PRODUCT_SAFEGUARD_NOTN = PRODUCT_SAFEGUARD_NOTN + " " + PRODUCT_SAFEGUARD_SLNO,
                                //------------------//
                                CEC_TOTAL = CEC_TOTAL,
                                CHEC_TOTAL = CHEC_TOTAL,
                                ADDLTIONAL_DUTY_TOTAL = ADDLTIONAL_DUTY_TOTAL,
                                TOTAL_ITEM_DUTY = TOTAL_ITEM_DUTY,
                                NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS,
                                ASSESSABLE_TOTAL = ASSESSABLE_TOTAL,
                                ITEM_TOTAL = ITEM_TOTAL,

                                PRODUCT_AGGREGATE_DUTY_NOTN = PRODUCT_AGGREGATE_DUTY_NOTN,
                                PRODUCT_AGGREGATE_DUTY_NOTN_SL = PRODUCT_AGGREGATE_DUTY_NOTN_SL,
                                PRODUCT_AGGREGATE_DUTY_NOTN_RATE = PRODUCT_AGGREGATE_DUTY_NOTN_RATE,
                                AGGREGATE_TOTAL = AGGREGATE_TOTAL,

                                PRODUCT_TARIFF_NOTN = PRODUCT_TARIFF_NOTN,
                                PRODUCT_TARIFF_SLNO = PRODUCT_TARIFF_SLNO,
                                PRODUCT_TARIFF_QTY = PRODUCT_TARIFF_QTY,
                                PRODUCT_TARIFF_AMOUNT = PRODUCT_TARIFF_AMOUNT,
                                PRODUCT_TARIFF_AMOUNT_UNIT = PRODUCT_TARIFF_AMOUNT_UNIT,

                                PRODUCT_SAPTA_NOTN = PRODUCT_SAPTA_NOTN,
                                PRODUCT_SAPTA_SLNO = PRODUCT_SAPTA_SLNO,
                                PRODUCT_SAPTA_RATE = PRODUCT_SAPTA_RATE,

                                PRODUCT_CVD_EDU_CESS_RATE = PRODUCT_CVD_EDU_CESS_RATE,
                                PRODUCT_CVD_SEC_EDU_CESS_RATE = PRODUCT_CVD_SEC_EDU_CESS_RATE,
                                CVD_CEC_TOTAL = CVD_CEC_TOTAL,
                                CVD_CHEC_TOTAL = CVD_CHEC_TOTAL,

                                CETH_CVD_EDU_CESS_SL = CETH_CVD_EDU_CESS_SL,
                                PRODUCT_CVD_EDU_CESS_NOTN_SL = PRODUCT_CVD_EDU_CESS_NOTN_SL,
                                //PRODUCT_CVD_EDU_CESS_NOTN_SL ="013/2012 1",
                                CETH_CVD_EDU_CESS_RATE = CETH_CVD_EDU_CESS_RATE,
                                CETH_CVD_SEC_EDU_CESS_RATE = CETH_CVD_SEC_EDU_CESS_RATE,
                                PRODUCT_OTHER_DUTY_TOTAL = PRODUCT_OTHER_DUTY_TOTAL,
                                PRODUCT_OTHER_DUTY_RATE = PRODUCT_OTHER_DUTY_RATE,
                                PRODUCT_OTHER_DUTY_NOTN = PRODUCT_OTHER_DUTY_NOTN,

                                REVENUEDEPOSIT_RATE = REVENUEDEPOSIT_RATE,
                                REVENUEDEPOSIT_ON = REVENUEDEPOSIT_ON,
                                // REVENUEDEPOSIT_TOTAL = REVENUEDEPOSIT_TOTAL

                                INFRA_CESS_NOTN = INFRA_CESS_NOTN,
                                INFRA_CESS_NOTN_SL = INFRA_CESS_NOTN_SL,
                                INFRA_CESS_NOTN_RATE = INFRA_CESS_NOTN_RATE,
                                INFRA_CESS_TOTAL = INFRA_CESS_TOTAL,
                                EOU_MERIT_BASIC_DUTY = EOU_MERIT_BASIC_DUTY,
                                EOU_MERIT_CVD = EOU_MERIT_CVD,
                                COUNTRY_OF_ORIGIN = COUNTRY_OF_ORIGIN,
                                IGST_LEVY_TOTAL = IGST_LEVY_TOTAL,
                                IGST_LEVY_COMPENSATION_CESS_TOTAL = IGST_LEVY_COMPENSATION_CESS_TOTAL,
                                IGST_LEVY_NOTN = IGST_LEVY_NOTN,
                                IGST_LEVY_SLNO = IGST_LEVY_SLNO,
                                IGST_LEVY_RATE = IGST_LEVY_RATE,
                                IGST_LEVY_EXCEPTION_NOTN = IGST_LEVY_EXCEPTION_NOTN,
                                IGST_LEVY_EXCEPTION_SLNO = IGST_LEVY_EXCEPTION_SLNO,
                                IGST_LEVY_EXCEPTION_RATE = IGST_LEVY_EXCEPTION_RATE,
                                IGST_LEVY_COMPENSATION_CESS_NOTN = IGST_LEVY_COMPENSATION_CESS_NOTN,
                                IGST_LEVY_COMPENSATION_CESS_SLNO = IGST_LEVY_COMPENSATION_CESS_SLNO,
                                IGST_LEVY_COMPENSATION_CESS_RATE = IGST_LEVY_COMPENSATION_CESS_RATE,
                                IGST_LEVY_EXCEPTION_CC_NOTN = IGST_LEVY_EXCEPTION_CC_NOTN,
                                IGST_LEVY_EXCEPTION_CC_SLNO = IGST_LEVY_EXCEPTION_CC_SLNO,
                                IGST_LEVY_EXCEPTION_CC_RATE = IGST_LEVY_EXCEPTION_CC_RATE,
                                END_USE_OF_ITEM = END_USE_OF_ITEM,
                                TOTAL_CUSTOMS_DUTY = TOTAL_CUSTOMS_DUTY,
                                TOTAL_IGST_DUTY = TOTAL_IGST_DUTY,
                                TOTAL_SOCIAL_WELFARE = TOTAL_SOCIAL_WELFARE,
                                SOCIAL_WELFARE_NOTN = SOCIAL_WELFARE_NOTN,
                                SOCIAL_WELFARE_NOTN_SLNO = SOCIAL_WELFARE_NOTN_SLNO,
                                SOCIAL_WELFARE_RATE = SOCIAL_WELFARE_RATE

                            });

                            if (Session["COMPANY_ID"].ToString() == "381")
                            {
                                if (IGST_LEVY_EXCEPTION_NOTN == "")
                                {
                                    LEVY_EXCEMPTION_NOTN_TYPE = "";
                                }

                                if (IGST_LEVY_EXCEPTION_CC_NOTN == "")
                                {
                                    LEVY_EXCEPTION_CC_NOTN_TYPE = "";
                                }

                                if (IGST_LEVY_NOTN != "")
                                {
                                    DUTY_TYPE = "G  /  I";
                                }
                                else
                                {
                                    DUTY_TYPE = "";
                                }
                                if (IGST_LEVY_COMPENSATION_CESS_NOTN != "")
                                {
                                    ADDL_FLAG = "G  /  P";
                                }
                                else
                                {
                                    ADDL_FLAG = "";
                                }

                                if (IGST_LEVY_NOTN != "")
                                {
                                    Load_Item_IGST_Details.Add(new Transaction_Default2()
                                    {

                                        INVOICE_SLNO = INVOICE_SLNO,
                                        ITEM_SLNO = ITEM_SLNO,
                                        IGST_LEVY_TOTAL = IGST_LEVY_TOTAL,
                                        IGST_LEVY_COMPENSATION_CESS_TOTAL = IGST_LEVY_COMPENSATION_CESS_TOTAL,
                                        IGST_LEVY_NOTN = IGST_LEVY_NOTN,
                                        IGST_LEVY_SLNO = IGST_LEVY_SLNO,
                                        IGST_LEVY_RATE = IGST_LEVY_RATE,
                                        IGST_LEVY_EXCEPTION_NOTN = IGST_LEVY_EXCEPTION_NOTN,
                                        IGST_LEVY_EXCEPTION_SLNO = IGST_LEVY_EXCEPTION_SLNO,
                                        IGST_LEVY_EXCEPTION_RATE = IGST_LEVY_EXCEPTION_RATE,
                                        IGST_LEVY_COMPENSATION_CESS_NOTN = IGST_LEVY_COMPENSATION_CESS_NOTN,
                                        IGST_LEVY_COMPENSATION_CESS_SLNO = IGST_LEVY_COMPENSATION_CESS_SLNO,
                                        IGST_LEVY_COMPENSATION_CESS_RATE = IGST_LEVY_COMPENSATION_CESS_RATE,
                                        IGST_LEVY_EXCEPTION_CC_NOTN = IGST_LEVY_EXCEPTION_CC_NOTN,
                                        IGST_LEVY_EXCEPTION_CC_SLNO = IGST_LEVY_EXCEPTION_CC_SLNO,
                                        IGST_LEVY_EXCEPTION_CC_RATE = IGST_LEVY_EXCEPTION_CC_RATE,
                                        LEVY_EXCEMPTION_NOTN_TYPE = LEVY_EXCEMPTION_NOTN_TYPE,
                                        LEVY_EXCEPTION_CC_NOTN_TYPE = LEVY_EXCEPTION_CC_NOTN_TYPE,
                                        DUTY_TYPE = DUTY_TYPE,
                                        ADDL_FLAG = ADDL_FLAG
                                    });
                                }
                            }
                            b++;
                        }

                        double final_debitduty = Math.Round(Convert.ToDouble(TOTAL_DEBIT_DUTY_FINAL) + Convert.ToDouble(TOTAL_DEBIT_DUTY), 0.00);
                        TOTAL_DEBIT_DUTY_FINAL = Convert.ToString(final_debitduty);
                    }

                }
                Get_Invoice_Details(ddlJobNo, ds.Rows[C], ds.Rows.Count);

                C++;

            }

            if (dtt.Rows.Count > 0)
            {
                /* UserBO ObjUBO = new UserBO();
                 Imp_Checklist IC = new Imp_Checklist();
                 ObjUBO.JOBNO = ddlJobNo;
                 String xmlData = ConvertDataTableToXML(dtt);
                 ObjUBO.Xml_D = xmlData;
                 IC.Import_Item_ASS_Duty_CIF_CVD_VLAUE_UPDATE(ObjUBO);*/

                ViewState["Checklist_Value"] = dtt;
                btn_checklist_Value_Update.Visible = true;
            }
            else
            {
                btn_checklist_Value_Update.Visible = false;
            }

            ds_RE_IMPORT.Dispose();
            //ds_Invoice.Dispose();
            //ds_LICENSE.Dispose();
            //ds_RE_IMPORT.Dispose();

            GC.Collect();


        }
        catch (Exception ex)
        {

            GV.DataSource = dtt;
            GV.DataBind();
            btn_checklist_Value_Update.Visible = false;
        }

    }


    private void Scheme_DEEC(DataSet dss1)
    {
        EXCEMPTION = dss1.Tables[0].Rows[0]["EXCEMPTION"].ToString();

        if (EXCEMPTION == "Y")
        {
            BASIC_DUTY = 0.00;
            SAFE_GUARD = 0.00;
            CVD = 0.00;
            CESS = 0.00;
            NCD = 0.00;
            Customs_Edu_Cess = 0.00;
            Customs_Higher_Edu_Cess = 0.00;
            AddL_DUTY = 0.00;

            cvd_Customs_Edu_Cess = 0.00;
            cvd_Customs_Higher_Edu_Cess = 0.00;
            Customs_Social_welfare = 0.00;//02feb

            TOTAL_ANTI_AMT = "0.00";

            if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
            {

            }
            else
            {
                BASIC_DUTY = 0.00;
                SAFE_GUARD = 0.00;
                AGGREGATE_DUTY = 0.00;
                CVD = 0.00;
                CESS = 0.00;
                NCD = 0.00;
                Customs_Edu_Cess = 0.00;
                Customs_Higher_Edu_Cess = 0.00;
                AddL_DUTY = 0.00;

                cvd_Customs_Edu_Cess = 0.00;
                cvd_Customs_Higher_Edu_Cess = 0.00;
                Customs_Social_welfare = 0.00;//02feb
            }

            /* hide on 20/02/2018 discuss with subbu sir --------- start
             * 
            if (!string.IsNullOrEmpty(EDU_CESS_NOTN))
            {
                if (EDU_CESS_NOTN == "054/2017")
                {
                    PRODUCT_SEC_EDU_CESS_NOTN = "055/2017";
                }
                else
                {
                    PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                }
                Customs_Edu_Cess = 0.00;
                Customs_Higher_Edu_Cess = 0.00;
                Customs_Social_welfare = 0.00;//02feb
                //PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                PRODUCT_EDU_CESS_RATE = "0.00";
                PRODUCT_SEC_EDU_CESS_RATE = "0.00";
            }
            else
            {
                PRODUCT_SEC_EDU_CESS_NOTN = "";
                PRODUCT_SEC_EDU_CESS_RATE = "1.00";
                PRODUCT_EDU_CESS_RATE = "2.00";
            }
             * hide on 20/02/2018 discuss with subbu sir --------- end
             * */

            BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
            SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
            AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
            CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));
            CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
            CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));

            CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CESS), 1).ToString("0.00"));
            NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
            CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
            CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
            ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));

            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));//02feb


            //-----------------------CALCULATION FOR TOTAL DEBIT DUTY--------------------------------//


            //double bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;


            double bcd_rate = 0.00;

            if (NOTIFICATION_CUSTOMS_BCD_RATE != "")
            {
                if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) != 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) != 0)
                {
                    bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) / 100;
                    PRODUCT_BCD_RATE = NOTIFICATION_CUSTOMS_BCD_RATE;
                }
                else if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0)
                {
                    bcd_rate = Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE);
                    PRODUCT_BCD_RATE = NOTIFICATION_CUSTOMS_BCD_RATE;
                }
            }
            else
            {
                bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
            }


            if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
            {

                //CTH_SPL_AMT = "";
                BASIC_DUTY = bcd_rate;
            }
            else
            {
                double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                if (bcd_rate >= bcd_Amt)
                {
                    if (cth_Amt >= bcd_rate)
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                    else
                    {
                        BASIC_DUTY = bcd_rate;
                    }
                }
                else
                {
                    if (cth_Amt >= bcd_Amt)
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                    else
                    {
                        BASIC_DUTY = bcd_Amt;
                    }
                }
                if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                {
                    if (bcd_Amt <= bcd_rate)
                    {
                        BASIC_DUTY = bcd_Amt;
                    }
                }
            }


            if (PRODUCT_BCD_SPL != "")
            {
                if (Convert.ToDouble(PRODUCT_BCD_SPL) != 0.000000 || Convert.ToDouble(PRODUCT_BCD_SPL) != 000000)
                {
                    /* hide by Chithra Suggest by Bala on 12-06-2018 for PIONEER
                    //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                    //BASIC_DUTY_BCD_SPL = cth_Amt;
                    //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);
                    //CTH_SPL_AMT = PRODUCT_BCD_SPL;
                     */

                    double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                    double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_BCD_SPL);

                    if (bcd_rate >= cth_Amt)
                    {
                        BASIC_DUTY = bcd_rate;
                    }
                    else
                    {
                        BASIC_DUTY = cth_Amt;
                    }

                    if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                    {
                        if (bcd_Amt <= bcd_rate)
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                    }

                    if (Session["COMPANY_ID"].ToString() == "313")
                    {
                        if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                    }

                    //BASIC_DUTY_BCD_SPL = cth_Amt;
                    //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                    CTH_SPL_AMT = PRODUCT_BCD_SPL;
                }
            }


            //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

            bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

            //---------------END SAPTA CALCULATION-------------------------//

            //SOCIAL WELFARE CALCULATION

            if (SOCIAL_WELFARE_NOTN != "")
            {
                SOCIAL_welf_Rate = BASIC_DUTY * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }

            //-----------------------------NCD CALCULATION---------------------------------------//
            NCD = 0.00;
            //-----------------------------END NCD CALCULATION---------------------------------------//

            //--------------NEW CVD 16Jan2015-----------------------//
            double CVD_Rate = 0.00;

            if (NOTIFICATION_CUSTOMS_CVD_RATE != "")
            {
                if (Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE) != 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE) != 0)
                {
                    CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE) / 100;
                    PRODUCT_CVD_RATE = NOTIFICATION_CUSTOMS_CVD_RATE;
                }
                else if (Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE) == 0)
                {
                    bcd_rate = Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE);
                    PRODUCT_CVD_RATE = NOTIFICATION_CUSTOMS_CVD_RATE;
                }
            }



            //--------------END NEW CVD 16Jan2015-----------------------//


            CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

            //if (RSP_APPLICABLE == "Y")- RSP condition removed by Chithra

            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            if (PRODUCT_CETH.Substring(0, 2) != "24")
            {
                CVD_TOTAL = "0";
                CVD = 0.00;
                PRODUCT_CVD_RATE = "0.00";
                PRODUCT_CETH = "NOEXCISE";
            }
            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//


            //------------------------------CESS CALCULATION--------------------------------//


            /* hide on 20/02/2018 discuss with subbu sir --------- start
             * 
            if ((Convert.ToDouble(CETH_CESS_AMTS) != 0.00) || (Convert.ToDouble(CETH_CESS_AMTS) > 0.00))
            {
                if (Convert.ToDouble(CETH_CESS_AMTS) != 0.00)
                {
                    CESS = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_CESS_AMTS);
                }
            }
            else if (Convert.ToDouble(CETH_CESS_RTA) != 0.00 || Convert.ToDouble(CETH_CESS_RTA) > 0.00)
            {
                CESS = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(CETH_CESS_RTA) / 100;

            }
            else
            {
            }
            hide on 20/02/2018 discuss with subbu sir --------- End */


            //---------------------------END CESS CALCULATION--------------------------------//
            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            CESS = 0.00;

            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            //---------------CVD New Education Cess Calculation------------------------------//

            //cvd_Customs_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_EDU_CESS_RATE) / 100;
            //cvd_Customs_Higher_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_SEC_EDU_CESS_RATE) / 100;


            //---------------End CVD New Education Cess Calculation--------------------------//

            /* hide on 20/02/2018 discuss with subbu sir --------- start

            Customs_Edu_Cess = (BASIC_DUTY + CVD + Convert.ToDouble(GSI_TOTAL) + CESS) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
            Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + Convert.ToDouble(GSI_TOTAL) + CESS) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
             * 
           hide on 20/02/2018 discuss with subbu sir --------- End  */

            Customs_Edu_Cess = 0.00;
            Customs_Higher_Edu_Cess = 0.00;


            Customs_Social_welfare = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;


            //IGST ASSESABLE VALUE SHOWS IN CHECKLIST - BY CHITHRA ON 05/05/2018
            CHK_IGST_ASSBL_VAL = 0.00;
            CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare;
            tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);


            //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//

            if (Session["COMPANY_ID"].ToString() == "247" || Session["COMPANY_ID"].ToString() == "10")
            {
                MERIT_NOTN_BASIC_VALUE = Math.Round(Convert.ToDouble(BASIC_DUTY), 2);
                MERIT_NOTN_CVD_VALUE = Math.Round(Convert.ToDouble(CVD), 2);
                MERIT_NOTN_CEC_VALUE = Math.Round(Convert.ToDouble(Customs_Edu_Cess), 2);
                MERIT_NOTN_CHEC_VALUE = Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 2);
                MERIT_NOTN_ADD_DUTY_VALUE = Math.Round(Convert.ToDouble(AddL_DUTY), 2);
                MERIT_NOTN_CESS_VALUE = Math.Round(Convert.ToDouble(CESS), 2);
                MERIT_NOTN_NCD_VALUE = Math.Round(Convert.ToDouble(NCD), 2);
            }
            //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//

            if (MERIT_TOTAL_ANTI_AMT == "")
            {
                MERIT_TOTAL_ANTI_AMT = "0";
            }

            //------------New Anti-Dumping Calculation implemented on 06Oct2018------------//
            string TOTAL_ANTI_AMT_LICNESE;

            if (ANTI_AMTS != null && ANTI_AMTS != "")
            {
                if (ADD_AMT_MINUS_ASSESABLE == "1")
                {
                    TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);

                    if (TOTAL_ANTIDUMP_AMT <= 0)
                    {
                        TOTAL_ANTIDUMP_AMT = 0.00;
                    }
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }

                if (ANTI_DUMPING_NOTN == "002/2017")
                {
                    if (Convert.ToDouble(ITEM_UNIT_PRICE) >= 755 && ITEM_QTY_CODE == "MTS")
                    {
                        MERIT_TOTAL_ANTI_AMT = "0.00";
                    }
                }


                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";

            }
            //---------Start New Anti-Dumping Calculation implemented on 27Sep2018------------//
            else if (MAX_DIFF != "" && MAX_DIFF != null)
            {


                if (PRODUCT_OTHER_DUTY_NOTN != "" && PRODUCT_OTHER_DUTY_SLNO != "")
                {
                    if (PRODUCT_OTHER_DUTY_RATE != "")
                    {
                        ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY) * (ADD_MAX_DIFF) / 100;
                        TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));


                        double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                        double Final_Anti_Dump = TOTAL_ANTIDUMP_AMT - Anti_Dump_Cal2;

                        TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(Final_Anti_Dump, 2).ToString("F"));
                        if (Convert.ToDouble(TOTAL_ANTI_AMT_LICNESE) < 0.00)
                            TOTAL_ANTI_AMT_LICNESE = "0.00";

                        MERIT_TOTAL_ANTI_AMT = TOTAL_ANTI_AMT_LICNESE;

                    }
                }
                else
                {
                    ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                    TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }


                //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + TOTAL_ANTI_AMT;
                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + "0.00";

            }
            else if (ADD_DIFF_CUR != null && ADD_DIFF_CUR != "")
            {
                if (ADD_AMT_MINUS_ASSESABLE == "2")
                {
                    TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble((ADD_DIFF_CUR)) / 100;

                    if (TOTAL_ANTIDUMP_AMT <= 0)
                    {
                        TOTAL_ANTIDUMP_AMT = 0.00;
                    }
                    TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }

                //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "           " + " " + ADD_DIFF_CUR + "%" + "     " + TOTAL_ANTIDUMP_AMT;

            }
            //---------End New Anti-Dumping Calculation implemented on 27Sep2018------------//                      


            if (PRODUCT_OTHER_DUTY_RATE != "")
            {
                //Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100; EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT
                Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT
                PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));

            }
            else if (PRODUCT_OTHER_DUTY_SPL != "")
            {
                Other_duty = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
                PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));
            }

            // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
            //doing

            Call_IGST_General();

            // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - END 88 **************************************//



            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            AddL_DUTY = 0.00;

            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));//HIDE BY CHITHRA ON 20/12/2017 for add IGST With Debit Duty

            if (SCHEME_CODE == "12" || SCHEME_CODE == "03" || SCHEME_CODE == "17")
            {
                //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
                //02feb
                //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));

            }
            else
            {
                //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
                //02feb
                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
            }

            //Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL) + CESS) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
            //Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL) + CESS) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
            //AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Edu_Cess + Customs_Higher_Edu_Cess + CESS) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;

            //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + CESS).ToString("0.00"));
            PRODUCT_OTHER_DUTY_TOTAL = "0";
        }
    }

    private void Scheme_DUTIABLE()
    {
        double bcd_rate = 0.00;
        double bcd_Amt = 0.00;
        //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

        if (PRODUCT_BCD_NOTN != "")
        {
            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
            {
                //NOTIFICATION_CUSTOMS_BCD_RATE = "";

                if (Session["COMPANY_ID"].ToString() == "145" || Session["COMPANY_ID"].ToString() == "262" || Session["COMPANY_ID"].ToString() == "184" || Session["COMPANY_ID"].ToString() == "223" || Session["COMPANY_ID"].ToString() == "224" || Session["COMPANY_ID"].ToString() == "164" || Session["COMPANY_ID"].ToString() == "1026")
                {
                    CTH_SPL_AMT = "0";
                }
            }
        }

        //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

        if (NOTIFICATION_CUSTOMS_BCD_RATE != "")
        {
            if (BCD_NOTN == "051/96" && (PRODUCT_BCD_NOTN_SLNO == "1" || PRODUCT_BCD_NOTN_SLNO == "2" || PRODUCT_BCD_NOTN_SLNO == "3"))
            {
                string bcd_rate_new = "0.00";

                if (Convert.ToDouble(MERIT_PRODUCT_BCD_RATE) > 5.00)
                {
                    bcd_rate_new = "5.00";
                    PRODUCT_BCD_RATE = "5.00";
                }
                else if (Convert.ToDouble(MERIT_PRODUCT_BCD_RATE) <= 5.00)
                {
                    //bcd_rate_new = "0.00";
                    //PRODUCT_BCD_RATE = "0.00";
                    bcd_rate_new = MERIT_PRODUCT_BCD_RATE;
                    PRODUCT_BCD_RATE = MERIT_PRODUCT_BCD_RATE;
                }

                bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(bcd_rate_new) / 100;
            }
            else
            {
                if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) != 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) != 0)
                {
                    bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) / 100;
                    PRODUCT_BCD_RATE = NOTIFICATION_CUSTOMS_BCD_RATE;
                }
                else if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0)
                {
                    bcd_rate = Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE);
                    PRODUCT_BCD_RATE = NOTIFICATION_CUSTOMS_BCD_RATE;
                }
            }
        }
        else
        {
            if (BCD_NOTN == "051/96" && (PRODUCT_BCD_NOTN_SLNO == "1" || PRODUCT_BCD_NOTN_SLNO == "2"))
            {
                string bcd_rate_new = "0.00";

                if (Convert.ToDouble(MERIT_PRODUCT_BCD_RATE) > 5.00)
                {
                    bcd_rate_new = "5.00";
                    PRODUCT_BCD_RATE = "5.00";
                }
                else if (Convert.ToDouble(MERIT_PRODUCT_BCD_RATE) <= 5.00)
                {
                    //bcd_rate_new = "0.00";
                    //PRODUCT_BCD_RATE = "0.00";
                    bcd_rate_new = MERIT_PRODUCT_BCD_RATE;
                    PRODUCT_BCD_RATE = MERIT_PRODUCT_BCD_RATE;
                }

                bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(bcd_rate_new) / 100;
            }
            else
            {
                bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
            }
        }

        //---------------SAPTA CALCULATION----------------------------//

        //if (PRODUCT_SAPTA_NOTN != "" && PRODUCT_SAPTA_SLNO != "") // Disable on 12Oct2017 with Bala (Note- This calculation posted below page)
        //{
        //    if (PRODUCT_SAPTA_RATE != "")
        //    {
        //        if (Convert.ToDecimal(PRODUCT_SAPTA_RATE) >= 0)
        //        {
        //            double bcd_sapta_rate = 100 - Convert.ToDouble(PRODUCT_SAPTA_RATE);

        //            bcd_rate = (bcd_rate * bcd_sapta_rate) / 100;
        //        }
        //    }
        //}

        //---------------END SAPTA CALCULATION-------------------------//

        if (Convert.ToDouble(PRODUCT_BCD_RATE) == 0.00 || Convert.ToDouble(PRODUCT_BCD_RATE) == 0)
        {
            BASIC_DUTY = 0.00;
        }

        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
        {
            //CTH_SPL_AMT = "";
            BASIC_DUTY = bcd_rate;
        }
        else
        {
            //bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
            double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

            if (bcd_rate >= bcd_Amt)
            {
                if (cth_Amt >= bcd_rate)
                {
                    BASIC_DUTY = cth_Amt;
                }
                else
                {
                    BASIC_DUTY = bcd_rate;
                }
            }
            else
            {
                if (cth_Amt >= bcd_Amt)
                {
                    BASIC_DUTY = cth_Amt;
                }
                else
                {
                    BASIC_DUTY = bcd_Amt;
                }
            }

            if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
            {
                if (bcd_Amt <= bcd_rate)
                {
                    BASIC_DUTY = bcd_Amt;
                }
            }
        }

        if (PRODUCT_BCD_SPL != "")
        {
            if (Convert.ToDouble(PRODUCT_BCD_SPL) != 0.000000 || Convert.ToDouble(PRODUCT_BCD_SPL) != 000000)
            {
                double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_BCD_SPL);

                if (bcd_rate >= cth_Amt)
                {
                    BASIC_DUTY = bcd_rate;
                }
                else
                {
                    BASIC_DUTY = cth_Amt;
                }

                if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                {
                    if (bcd_Amt <= bcd_rate)
                    {
                        BASIC_DUTY = bcd_Amt;
                    }
                }

                if (Session["COMPANY_ID"].ToString() == "313")
                {
                    if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                }

                //BASIC_DUTY_BCD_SPL = cth_Amt;
                //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                CTH_SPL_AMT = PRODUCT_BCD_SPL;
            }
        }

        //SOCIAL WELFARE CALCULATION

        if (SOCIAL_WELFARE_NOTN != "")
        {
            SOCIAL_welf_Rate = BASIC_DUTY * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
        }


        //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

        //---------------END SAPTA CALCULATION-------------------------//

        //----------------Start 28Apr2015---------------------//
        if (NOTIFICATION_CUSTOMS_BCD_RATE != "")
        {
            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
            {
                BASIC_DUTY = 0.00;
            }
        }

        //----------------End 28Apr2015---------------------//

        //if (Convert.ToDouble(BASIC_DUTY_BCD_SPL) > BASIC_DUTY)
        //{
        //    BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

        //    CTH_SPL_AMT = PRODUCT_BCD_SPL;
        //}
        //else
        //{
        //    BASIC_DUTY = BASIC_DUTY;
        //}


        INFRA_CESS = 0.00;
        NCD = 0.00;

        // CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;


        double CVD_Rate = 0.00;

        if (NOTIFICATION_CUSTOMS_CVD_RATE != "")
        {
            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE) != 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE) != 0)
            {
                CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE) / 100;
                PRODUCT_CVD_RATE = NOTIFICATION_CUSTOMS_CVD_RATE;
            }
            else if (Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE) == 0)
            {
                bcd_rate = Convert.ToDouble(NOTIFICATION_CUSTOMS_CVD_RATE);
                PRODUCT_CVD_RATE = NOTIFICATION_CUSTOMS_CVD_RATE;
            }
        }
        else
        {
            CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY + NCD) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;
        }


        //---------------Start Updated on 04 July 2014------------------//

        double CVD_Amt = 0.00;

        if (PRODUCT_CVD_SPL != "")
        {
            if (Convert.ToDouble(PRODUCT_CVD_SPL) != 0.00 || Convert.ToDouble(PRODUCT_CVD_SPL) != 0)
            {
                CVD_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_CVD_SPL);
                CETH_SPL_AMT = PRODUCT_CVD_SPL;
            }
        }
        else
        {
            CVD_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_SPL_AMT);
        }

        //---------------End Updated on 04 July 2014------------------//


        //double CVD_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_SPL_AMT); //disabled on 04 July 2014

        if (CVD_Rate >= CVD_Amt)
        {
            CVD = CVD_Rate;
        }
        else
        {
            CVD = CVD_Amt;
        }

        //--------------------Mahzel KSU Shipping & Logistics On 07Jan2015---------------------//

        //if (Session["COMPANY_ID"].ToString() == "182")
        //{
        //    CVD = CVD_Rate + CVD_Amt;
        //}

        //--------------------Mahzel KSU Shipping & Logistics On 07Jan2015---------------------//

        //------------------------------CESS CALCULATION--------------------------------//

        /* hide on 20/02/2018 discuss with subbu sir --------- start
        if (BCD_NOTN != "012/2012" || PRODUCT_BCD_NOTN_SLNO != "232")
        {
            if ((Convert.ToDouble(CETH_CESS_AMTS) != 0.00) || (Convert.ToDouble(CETH_CESS_AMTS) > 0.00))
            {
                if (Convert.ToDouble(CETH_CESS_AMTS) != 0.00)
                {
                    CESS = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_CESS_AMTS);
                }
            }
            else if (Convert.ToDouble(CETH_CESS_RTA) != 0.00 || Convert.ToDouble(CETH_CESS_RTA) > 0.00)
            {
                CESS = (ASSESABLE_VALUE + BASIC_DUTY + NCD) * Convert.ToDouble(CETH_CESS_RTA) / 100;

            }
            else
            {
            }
        }
         * 
       hide on 20/02/2018 discuss with subbu sir --------- End  * */

        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

        CESS = 0.00;
        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

        if (Session["COMPANY_ID"].ToString() == "182")
        {
            //CVD = CVD * 20;
            CVD = CVD + CVD_Amt;
        }

        if (Session["COMPANY_ID"].ToString() == "162" && CVD_NOTN == "012/2012" && PRODUCT_CVD_NOTN_SLNO == "51(ii)")
        {
            CVD = CVD + CVD_Amt;
        }

        //--------------------Mahzel KSU Shipping & Logistics On 07Jan2015-------SEASWAN SHIPPING on 12May2017-----------------//


        Aggregate_cvd = CVD;

        if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
        {

        }
        else
        {
            Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
        }

        CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Aggregate_cvd), 1).ToString("0.00"));
        //CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
        //CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
        //ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
        ////TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));


        //-----------GST IMPLEMENTATION ON 01JULY2017 ------------------//

        //if (PRODUCT_CETH.Substring(0, 2) != "24" && PRODUCT_CETH.Substring(0, 2) != "27")
        //{
        //    CVD = 0.00;
        //    CVD_TOTAL = "0.00";
        //}

        if (PRODUCT_CETH.Substring(0, 2) != "24")
        {
            CVD = 0.00;
            CVD_TOTAL = "0.00";
            PRODUCT_CVD_RATE = "0.00";
        }
        else if (PRODUCT_CETH == "24029090" || PRODUCT_CETH == "24022090")
        {
            CVD = 0.00;
            CVD_TOTAL = "0.00";
            PRODUCT_CVD_RATE = "0.00";
        }

        //*********************** CAR CHECKLIST -PARAMOUNT- By Chithra on 06-Sep-2017 ***********************/
        /* hide on 20/02/2018 discuss with subbu sir --------- start
        if (Session["COMPANY_ID"].ToString() == "293" || Session["COMPANY_ID"].ToString() == "10")
        {
            if (PRODUCT_CETH.Substring(0, 4) == "8703")
            {
                CESS = 0.00;
                NCD = 0.00;
                INFRA_CESS = 0.00;
            }
        }
       hide on 20/02/2018 discuss with subbu sir --------- End  * */
        //****************************************************************************************************/

        // -----------------Spl Excise Duty(Sched-11) Calculation-------------------------------//
        // -----------------GSI Calculation-------------------------------//
        // -----------------TTA Calculation-------------------------------//


        //---------------Start Other CVD Duty Calculation On 02June2015(Boxco)---------------//

        if (PRODUCT_OTHER_DUTY_RATE != "")
        {
            //Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100; EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT
            Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT
            PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));

        }
        else if (PRODUCT_OTHER_DUTY_SPL != "")
        {
            Other_duty = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
            PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));
        }
        else if (PRODUCT_OTHER_DUTY_SPL == "" && PRODUCT_OTHER_DUTY_RATE == "")
        {
            Other_duty = 0.00;
            PRODUCT_OTHER_DUTY_TOTAL = "0.00";
        }

        if (PRODUCT_OTHER_DUTY_TOTAL == "")
        {
            PRODUCT_OTHER_DUTY_TOTAL = "0.00";
        }


        //---------------End Other CVD Duty Calculation On 02June2015(Boxco)---------------//

        /* hide on 20/02/2018 discuss with subbu sir --------- start
         * 
        if (!string.IsNullOrEmpty(EDU_CESS_NOTN))
        {
            if (EDU_CESS_NOTN == "054/2017")
            {
                PRODUCT_SEC_EDU_CESS_NOTN = "055/2017";
            }
            else
            {
                PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
            }
            Customs_Edu_Cess = 0.00;
            Customs_Higher_Edu_Cess = 0.00;
            //PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
            PRODUCT_EDU_CESS_RATE = "0.00";
            PRODUCT_SEC_EDU_CESS_RATE = "0.00";
        }
        else
        {
            //Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + NCD + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + CESS + Other_duty+ INFRA_CESS) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
            //Customs_Higher_Edu_Cess = (BASIC_DUTY + NCD + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + CESS + Other_duty + INFRA_CESS) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;

            Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + NCD + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + CESS + INFRA_CESS) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
            Customs_Higher_Edu_Cess = (BASIC_DUTY + NCD + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + CESS + INFRA_CESS) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
        }
       hide on 20/02/2018 discuss with subbu sir --------- End  * */

        //Customs_Social_welfare = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

        AddL_DUTY = 0.00;

        SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

        if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
        {
        }
        else
        {
            Aggregate_safe_guard = SAFE_GUARD;
            Aggregate_AddL_DUTY = AddL_DUTY;
            Aggregate_basic_duty = BASIC_DUTY;
            Aggregate_cvd = CVD;
            Aggregate_cess = CESS;
            Aggregate_ncd = NCD;
            Aggregate_Customs_Edu_Cess = Customs_Edu_Cess;
            Aggregate_Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess;

            double AGGREGATE_DUTY_a = (Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess);
            //double AGGREGATE_DUTY_a = (Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess );

            SAFE_GUARD = SAFE_GUARD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            //AddL_DUTY = AddL_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            AddL_DUTY = 0.00;

            BASIC_DUTY = BASIC_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            CESS = CESS * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            NCD = NCD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            Customs_Edu_Cess = Customs_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;

            //Aggregate_safe_guard = Aggregate_safe_guard * (Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE))/ 100);
            //Aggregate_AddL_DUTY = Aggregate_AddL_DUTY * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            //Aggregate_basic_duty = Aggregate_basic_duty * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            //Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            //Aggregate_cess = Aggregate_cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            //Aggregate_ncd = Aggregate_ncd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            //Aggregate_Customs_Edu_Cess = Aggregate_Customs_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            //Aggregate_Customs_Higher_Edu_Cess = Aggregate_Customs_Higher_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

            Aggregate_safe_guard = Aggregate_safe_guard * (Convert.ToDouble(Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100);
            Aggregate_AddL_DUTY = Aggregate_AddL_DUTY * Convert.ToDouble(Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_basic_duty = Aggregate_basic_duty * Convert.ToDouble(Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_cess = Aggregate_cess * Convert.ToDouble(Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_ncd = Aggregate_ncd * Convert.ToDouble(Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_Customs_Edu_Cess = Aggregate_Customs_Edu_Cess * Convert.ToDouble(Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_Customs_Higher_Edu_Cess = Aggregate_Customs_Higher_Edu_Cess * Convert.ToDouble(Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

            //AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;

            AGGREGATE_DUTY = AGGREGATE_DUTY_a - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess);
            //AGGREGATE_DUTY = AGGREGATE_DUTY_a - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd);
        }

        CVD_CEC_TOTAL = "0.00";
        CVD_CHEC_TOTAL = "0.00";

        Customs_Social_welfare = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;


        //IGST ASSESABLE VALUE SHOWS IN CHECKLIST - BY CHITHRA ON 05/05/2018
        CHK_IGST_ASSBL_VAL = 0.00;
        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare;
        tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);

        /* hide on 20/02/2018 discuss with subbu sir --------- start
        if (PRODUCT_CVD_EDU_CESS_RATE == "013/2012")
        {
            CVD_CEC_TOTAL = "0.00";
            CVD_CHEC_TOTAL = "0.00";
        }
        else
        {
            CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
            CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));
        }
         * 
       hide on 20/02/2018 discuss with subbu sir --------- End  * */

        SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 2).ToString("0.00"));

        if (Session["COMPANY_ID"].ToString() == "248")
        {
            BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 2).ToString("0.00"));
        }
        else
        {
            BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
        }

        AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));

        CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CESS), 1).ToString("0.00"));
        NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
        TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));

        ADDLTIONAL_DUTY_TOTAL = "0.00";
        INFRA_CESS_TOTAL = "0.00";


        //------------New Anti-Dumping Calculation implemented on 04July2016------------//
        if (ANTI_AMTS != null && ANTI_AMTS != "")
        {
            if (ADD_AMT_MINUS_ASSESABLE == "1")
            {
                TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);

                if (TOTAL_ANTIDUMP_AMT <= 0)
                {
                    TOTAL_ANTIDUMP_AMT = 0.00;
                }
                TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
            }

            if (ANTI_DUMPING_NOTN == "002/2017")
            {
                if (Convert.ToDouble(ITEM_UNIT_PRICE) >= 755 && ITEM_QTY_CODE == "MTS")
                {
                    TOTAL_ANTI_AMT = "0.00";
                }
            }

            MERIT_TOTAL_ANTI_AMT = TOTAL_ANTI_AMT;

            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + TOTAL_ANTI_AMT;

        }
        //------------New Anti-Dumping Calculation implemented on 04July2016------------//
        //---------Start New Anti-Dumping Calculation implemented on 27Sep2018------------//
        else if (MAX_DIFF != "" && MAX_DIFF != null)
        {


            if (PRODUCT_OTHER_DUTY_NOTN != "" && PRODUCT_OTHER_DUTY_SLNO != "")
            {
                if (PRODUCT_OTHER_DUTY_RATE != "")
                {
                    ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                    TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY) * (ADD_MAX_DIFF) / 100;
                    TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));


                    double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                    double Final_Anti_Dump = TOTAL_ANTIDUMP_AMT - Anti_Dump_Cal2;

                    TOTAL_ANTI_AMT = Convert.ToString(Math.Round(Final_Anti_Dump, 2).ToString("F"));
                    if (Convert.ToDouble(TOTAL_ANTI_AMT) < 0.00)
                        TOTAL_ANTI_AMT = "0.00";

                    MERIT_TOTAL_ANTI_AMT = TOTAL_ANTI_AMT;

                }
            }
            else
            {
                ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
            }


            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + TOTAL_ANTI_AMT;

        }
        else if (ADD_DIFF_CUR != null && ADD_DIFF_CUR != "")
        {
            if (ADD_AMT_MINUS_ASSESABLE == "2")
            {
                TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble((ADD_DIFF_CUR)) / 100;

                if (TOTAL_ANTIDUMP_AMT <= 0)
                {
                    TOTAL_ANTIDUMP_AMT = 0.00;
                }
                TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
            }

            //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "               " + " " + ADD_DIFF_CUR + "%" + "     " + TOTAL_ANTIDUMP_AMT;

        }
        //---------End New Anti-Dumping Calculation implemented on 27Sep2018------------//



        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
        Call_IGST_General();
    }



    private double NOTN_SAPTA_CALC(double bcd_rate)
    {
        if (PRODUCT_SAPTA_NOTN != "" && PRODUCT_SAPTA_SLNO != "")
        {
            if (PRODUCT_SAPTA_RATE != "")
            {
                if (Convert.ToDecimal(PRODUCT_SAPTA_RATE) >= 0)
                {
                    double bcd_sapta_rate = 100 - Convert.ToDouble(PRODUCT_SAPTA_RATE);

                    bcd_rate = (bcd_rate * bcd_sapta_rate) / 100;
                    BASIC_DUTY = bcd_rate;
                }
            }
            else
            {
                var PRODUCT_SAPTA_RATES = from DataRow drr in dt_All_Rates.Tables[2].AsEnumerable()
                                          where drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN") == PRODUCT_SAPTA_NOTN && drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == PRODUCT_SAPTA_SLNO
                                          && drr.Field<string>("NOTIFICATION_TYPE") == "C"
                                          select drr;

                DataView dv_SAPTA_RATE = PRODUCT_SAPTA_RATES.AsDataView();

                if (dv_SAPTA_RATE.Count > 0)
                {
                    DataTable CTH_SAPTA = PRODUCT_SAPTA_RATES.CopyToDataTable();
                    PRODUCT_SAPTA_RATE = CTH_SAPTA.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();

                    double bcd_sapta_rate = 100 - Convert.ToDouble(PRODUCT_SAPTA_RATE);

                    bcd_rate = (bcd_rate * bcd_sapta_rate) / 100;
                    BASIC_DUTY = bcd_rate;
                }
                else
                {
                    //error table here
                }
            }
        }
        return bcd_rate;
    }

    private void Notn_ANTI_DUMPING_CALC(DataTable dt_error)
    {
        double qty = 0;
        TOTAL_ANTI_AMT = "0";
        TOTAL_ANTIDUMP_AMT = 0;
        MERIT_TOTAL_ANTIDUMP_AMT = 0;
        ANTI_AMTS = "";
        MERIT_TOTAL_ANTI_AMT = "0";
        MAX_DIFF = "";
        ADD_DIFF_CUR = "";

        if (ANTI_DUMPING_NOTN != "")
        {
            if (CTH_QTY != "")
            {
                qty = Convert.ToDouble(CTH_QTY);
            }


            var ANTI_DUMPING = from DataRow drr in dt_All_Rates.Tables[9].AsEnumerable()
                               //where drr.Field<string>("ADD_NOTN") == ANTI_DUMPING_NOTN && drr.Field<string>("ADD_SLNO") == ANTI_DUMPING_NOTN_SLNO
                               where drr.Field<string>("ADD_NOTN") == ANTI_DUMPING_NOTN && drr.Field<string>("ADD_CTH") == CTH_SLNO // Checked only CTH slno as per old coding
                               //&& drr.Field<string>("ADD_CTH") == CTH_SLNO && drr.Field<string>("ADD_SUP_SLNO") == CTH_SUPPLIER_SLNO

                               select drr;

            DataView dv_ANTI_DUMPING = ANTI_DUMPING.AsDataView();

            //dss5.Tables.Add(dv_ANTI_DUMPING.ToTable());

            if (dv_ANTI_DUMPING.Count > 0)
            {
                DataTable dt_ANTI_DUMPING = ANTI_DUMPING.CopyToDataTable();

                ANTI_AMTS = dt_ANTI_DUMPING.Rows[0]["ADD_ANTI_AMTS"].ToString();
                MAX_DIFF = dt_ANTI_DUMPING.Rows[0]["ADD_MAX_DIFF"].ToString();
                ADD_AMT_MINUS_ASSESABLE = dt_ANTI_DUMPING.Rows[0]["ADD_AMT_MINUS_ASSESABLE"].ToString();
                ADD_DIFF_CUR = dt_ANTI_DUMPING.Rows[0]["ADD_DIFF_CUR"].ToString();

                if (ANTI_AMTS != "")
                {
                    ADD_ANTI_AMTS = Convert.ToDouble(ANTI_AMTS);
                    ADD_ANTI_CUR = dt_ANTI_DUMPING.Rows[0]["ADD_ANTI_CUR"].ToString();
                    EXCHANGE_RATE = Convert.ToDouble(dt_ANTI_DUMPING.Rows[0]["EXCHANGE_RATE"].ToString());

                    //TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);

                    if (Session["COMPANY_ID"].ToString() == "381" || Session["COMPANY_ID"].ToString() == "382" || Session["COMPANY_ID"].ToString() == "385" || Session["COMPANY_ID"].ToString() == "461" || Session["COMPANY_ID"].ToString() == "458")
                    {
                        if (BE_TYPE == "Ex-Bond")
                        {
                            TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(INVOICE_EXRATE);
                        }
                        else
                        {
                            TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);
                        }
                    }
                    else
                    {
                        TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);
                    }

                    MERIT_TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);

                    TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));

                    //if (ADD_ANTI_CUR == "USD")
                    //    TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(INVOICE_EXRATE);
                    //else
                    //    TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);

                }
                //---------Start Disabled on 27Sep2018------------//
                //else if (MAX_DIFF != "")
                //{
                //    ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                //    TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                //    MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                //    TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                //    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                //}               

                //if (MAX_DIFF != "")
                //{
                //    ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "  " + ADD_MAX_DIFF + "%" + "   " + TOTAL_ANTI_AMT;
                //}
                //---------End Disabled on 27Sep2018------------//
            }
            else
            {
                //error datatable here
                dt_error.Rows.Add(ANTI_DUMPING_NOTN, ANTI_DUMPING_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
            }
        }
    }

  
    private void ITEM_REIMPORT(DataView Re_view)
    {
        Re_view.RowFilter = "INVOICE_NO = '" + INVOICE_NO_ITEM + "' and " + "INVOICE_SLNO = '" + INVOICE_SLNO + "' and " + "ITEM_SLNO = '" + ITEM_SLNO + "'";
        //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
        DataTable Re_table = Re_view.ToTable();
        DataSet Re_dss = new DataSet();
        Re_dss.Tables.Add(Re_table);
        int bb = 0;
        if (Re_dss.Tables[0].Rows.Count > bb)
        {
            NOTN_NO = Return_Zero_Value(Re_dss.Tables[0].Rows[bb]["NOTN_NO"].ToString());
            NOTN_SLNO = Return_Zero_Value(Re_dss.Tables[0].Rows[bb]["NOTN_SLNO"].ToString());

            //if (NOTN_NO == "094/96" && NOTN_SLNO == "1" || NOTN_SLNO == "3")
            // if (NOTN_NO == "094/96" && NOTN_SLNO == "1" || NOTN_SLNO == "1(a)" || NOTN_SLNO == "1(b)" || NOTN_SLNO == "1(c)" || NOTN_SLNO == "1(d)" || NOTN_SLNO == "1(e)" || NOTN_SLNO == "3" || NOTN_SLNO == "1A")
            if (NOTN_NO == "094/96" && NOTN_SLNO == "1" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1(B)" || NOTN_SLNO == "1(C)" || NOTN_SLNO == "1(D)" || NOTN_SLNO == "1(E)" || NOTN_SLNO == "3" || NOTN_SLNO == "1A" || NOTN_SLNO == "1D") //------Implemented On 11Aug2016 for Bas Shipping with Bala
            {
                TOTAL_ANTI_AMT = "0.00";
                BASIC_DUTY_TOTAL = "0.00";
                CVD_TOTAL = "0.00";
                CEC_TOTAL = "0.00";
                CHEC_TOTAL = "0.00";
                SCHED11_TOTAL = "0.00";
                GSI_TOTAL = "0.00";
                TTA_TOTAL = "0.00";
                NCD_TOTAL = "0.00";
                CESS_TOTAL = "0.00";
                SAFE_GUARD_TOTAL = "0.00";

                CVD_CEC_TOTAL = "0.00";
                CVD_CHEC_TOTAL = "0.00";

                ADDLTIONAL_DUTY_TOTAL = "0.00";

                TOTAL_SOCIAL_WELFARE = "0.00";
            }
            else if (NOTN_NO == "045/2017" && NOTN_SLNO == "1" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1(B)" || NOTN_SLNO == "1(C)" || NOTN_SLNO == "1(D)" || NOTN_SLNO == "1(E)" || NOTN_SLNO == "3" || NOTN_SLNO == "1A" || NOTN_SLNO == "1D") //------Implemented On 12Oct2017 for Paramount with Bala
            {
                TOTAL_ANTI_AMT = "0.00";
                BASIC_DUTY_TOTAL = "0.00";
                CVD_TOTAL = "0.00";
                CEC_TOTAL = "0.00";
                CHEC_TOTAL = "0.00";
                SCHED11_TOTAL = "0.00";
                GSI_TOTAL = "0.00";
                TTA_TOTAL = "0.00";
                NCD_TOTAL = "0.00";
                CESS_TOTAL = "0.00";
                SAFE_GUARD_TOTAL = "0.00";

                CVD_CEC_TOTAL = "0.00";
                CVD_CHEC_TOTAL = "0.00";

                ADDLTIONAL_DUTY_TOTAL = "0.00";

                TOTAL_SOCIAL_WELFARE = "0.00";
            }
            else if (NOTN_NO == "045/2017" && NOTN_SLNO == "5")
            {
                TOTAL_ANTI_AMT = "0.00";
                BASIC_DUTY_TOTAL = "0.00";
                CVD_TOTAL = "0.00";
                CEC_TOTAL = "0.00";
                CHEC_TOTAL = "0.00";
                SCHED11_TOTAL = "0.00";
                GSI_TOTAL = "0.00";
                TTA_TOTAL = "0.00";
                NCD_TOTAL = "0.00";
                CESS_TOTAL = "0.00";
                SAFE_GUARD_TOTAL = "0.00";

                CVD_CEC_TOTAL = "0.00";
                CVD_CHEC_TOTAL = "0.00";

                ADDLTIONAL_DUTY_TOTAL = "0.00";
                IGST_LEVY_TOTAL = "0.00";
                IGST_LEVY_COMPENSATION_CESS_TOTAL = "0.00";

                TOTAL_SOCIAL_WELFARE = "0.00";
            }
            else if (NOTN_NO == "046/2017" && NOTN_SLNO == "5")
            {
                TOTAL_ANTI_AMT = "0.00";
                BASIC_DUTY_TOTAL = "0.00";
                CVD_TOTAL = "0.00";
                CEC_TOTAL = "0.00";
                CHEC_TOTAL = "0.00";
                SCHED11_TOTAL = "0.00";
                GSI_TOTAL = "0.00";
                TTA_TOTAL = "0.00";
                NCD_TOTAL = "0.00";
                CESS_TOTAL = "0.00";
                SAFE_GUARD_TOTAL = "0.00";

                CVD_CEC_TOTAL = "0.00";
                CVD_CHEC_TOTAL = "0.00";

                ADDLTIONAL_DUTY_TOTAL = "0.00";
                IGST_LEVY_TOTAL = "0.00";
                IGST_LEVY_COMPENSATION_CESS_TOTAL = "0.00";
                TOTAL_SOCIAL_WELFARE = "0.00";
            }
            else if (NOTN_NO == "047/2017" &&(NOTN_SLNO == "1" || NOTN_SLNO == "2"))
            {
                TOTAL_ANTI_AMT = "0.00";
                BASIC_DUTY_TOTAL = "0.00";
                CVD_TOTAL = "0.00";
                CEC_TOTAL = "0.00";
                CHEC_TOTAL = "0.00";
                SCHED11_TOTAL = "0.00";
                GSI_TOTAL = "0.00";
                TTA_TOTAL = "0.00";
                NCD_TOTAL = "0.00";
                CESS_TOTAL = "0.00";
                SAFE_GUARD_TOTAL = "0.00";

                CVD_CEC_TOTAL = "0.00";
                CVD_CHEC_TOTAL = "0.00";

                ADDLTIONAL_DUTY_TOTAL = "0.00";
                IGST_LEVY_TOTAL = "0.00";
                IGST_LEVY_COMPENSATION_CESS_TOTAL = "0.00";
                TOTAL_SOCIAL_WELFARE = "0.00";

            }


            //REIMPORT_FREIGHT_AMOUNT = REIMPORT_FREIGHT_AMOUNT + Convert.ToDouble(REIMPORT_FREIGHT);
            //REIMPORT_INSURANCE_AMOUNT = REIMPORT_INSURANCE_AMOUNT + Convert.ToDouble(REIMPORT_INSURANCE);
            //b++;
        }
    }

    private void Scheme_EPCG(DataTable dss1, adminmaster adm_Mas)
    {
        adminmaster adm = new adminmaster();

        if (dss1.Rows.Count > 0)
        {
            EXCEMPTION = dss1.Rows[0]["EXCEMPTION"].ToString();

            //------------------------------------------DATA FETCH FROM SCHEME IMPORT MASTER------------------------------------------//

            if (SCHEME_CODE != "" && SCHEME_NOTN != "")
            {
                var FullName1 = from DataRow drr in dt_All_Rates.Tables[8].AsEnumerable()
                                where drr.Field<string>("SCHEME_IMPORT_CODE") == SCHEME_CODE && drr.Field<string>("SCHEME_NOTN") == SCHEME_NOTN && drr.Field<string>("SCHEME_NOTN_SLNO") == SCHEME_NOTN_SLNO
                                select drr;

                DataView dv_SCHEMECODE = FullName1.AsDataView();

                if (dv_SCHEMECODE.Count > 0)
                {
                    DataTable dS_SCHEMECODE = FullName1.CopyToDataTable();
                    string SCHEME_Rate = dS_SCHEMECODE.Rows[0]["SCHEME_RATE"].ToString();
                    //double SCHEME_Rate1 = Convert.ToDouble(SCHEME_Rate);
                    if (SCHEME_Rate == "")
                    {
                        SCHEME_Rate = "0";
                    }
                    SCHEME_RATE_NEW = Convert.ToString(Convert.ToDouble(SCHEME_Rate).ToString("F"));
                }
            }

            //------------------------------------------------END   SCHEME IMPORT MASTER------------------------------------------//

            //if (EXCEMPTION == "Y")
            //{
            if (Convert.ToDecimal(SCHEME_RATE_NEW) <= 0)
            {
                BASIC_DUTY = 0.00;
                SAFE_GUARD = 0.00;
                CVD = 0.00;
                NCD = 0.00;
                Customs_Edu_Cess = 0.00;
                Customs_Higher_Edu_Cess = 0.00;
                AddL_DUTY = 0.00;

                cvd_Customs_Edu_Cess = 0.00;
                cvd_Customs_Higher_Edu_Cess = 0.00;
                Customs_Social_welfare = 0.00;
            }
            else
            {
                CVD = 0.00;
                NCD = 0.00;
                AddL_DUTY = 0.00;
                BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(SCHEME_RATE_NEW) / 100;

                cvd_Customs_Edu_Cess = 0.00;
                cvd_Customs_Higher_Edu_Cess = 0.00;
                Customs_Social_welfare = 0.00;

                /* hide on 20/02/2018 discuss with subbu sir --------- start
                if (!string.IsNullOrEmpty(EDU_CESS_NOTN))
                {
                    if (EDU_CESS_NOTN == "054/2017")
                    {
                        PRODUCT_SEC_EDU_CESS_NOTN = "055/2017";
                    }
                    else
                    {
                        PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                    }
                    Customs_Edu_Cess = 0.00;
                    Customs_Higher_Edu_Cess = 0.00;
                    //PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                    PRODUCT_EDU_CESS_RATE = "0.00";
                    PRODUCT_SEC_EDU_CESS_RATE = "0.00";
                }
                else
                {
                    Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
                    Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                }
               hide on 20/02/2018 discuss with subbu sir --------- End  */

                Customs_Social_welfare = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

                SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;
            }


            if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
            {
            }
            else
            {
                Aggregate_safe_guard = SAFE_GUARD;
                Aggregate_AddL_DUTY = AddL_DUTY;
                Aggregate_basic_duty = BASIC_DUTY;
                Aggregate_cvd = CVD;
                Aggregate_ncd = NCD;
                Aggregate_Customs_Edu_Cess = Customs_Edu_Cess;
                Aggregate_Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess;

                SAFE_GUARD = SAFE_GUARD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                BASIC_DUTY = BASIC_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                CVD = CVD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                NCD = NCD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                Customs_Edu_Cess = Customs_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                //AddL_DUTY = AddL_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                AddL_DUTY = 0.00;
                Aggregate_safe_guard = Aggregate_safe_guard * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                Aggregate_AddL_DUTY = Aggregate_AddL_DUTY * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                Aggregate_basic_duty = Aggregate_basic_duty * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                Aggregate_ncd = Aggregate_ncd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                Aggregate_Customs_Edu_Cess = Aggregate_Customs_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                Aggregate_Customs_Higher_Edu_Cess = Aggregate_Customs_Higher_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;

            }

            CVD_CEC_TOTAL = "0.00";
            CVD_CHEC_TOTAL = "0.00";

            /* hide on 20/02/2018 discuss with subbu sir --------- start
            if (PRODUCT_CVD_EDU_CESS_RATE == "013/2012")
            {
                CVD_CEC_TOTAL = "0.00";
                CVD_CHEC_TOTAL = "0.00";
            }
            else
            {
                CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
                CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));
            }
             * 
           hide on 20/02/2018 discuss with subbu sir --------- End  * */



            BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
            SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
            AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
            CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));

            NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
            CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
            CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
            ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));

            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));


            //-----------------------CALCULATION FOR TOTAL DEBIT DUTY--------------------------------//

            double bcd_rate = Convert.ToDouble(PRODUCT_BCD_RATE) - Convert.ToDouble(SCHEME_RATE_NEW);
            bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(bcd_rate) / 100;

            if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
            {
                //CTH_SPL_AMT = "";
                BASIC_DUTY = bcd_rate;
            }
            else
            {
                double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                if (bcd_rate >= bcd_Amt)
                {
                    if (cth_Amt >= bcd_rate)
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                    else
                    {
                        BASIC_DUTY = bcd_rate;
                    }
                }
                else
                {
                    if (cth_Amt >= bcd_Amt)
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                    else
                    {
                        BASIC_DUTY = bcd_Amt;
                    }
                }
            }

            //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

            bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

            //---------------END SAPTA CALCULATION-------------------------//

            //SOCIAL WELFARE CALCULATION
            if (SOCIAL_WELFARE_NOTN != "")
            {
                SOCIAL_welf_Rate = BASIC_DUTY * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }

            //-----------------------------NCD CALCULATION---------------------------------------//
            NCD = 0.00;
            //-----------------------------END NCD CALCULATION---------------------------------------//


            double bcd = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
            CVD = (ASSESABLE_VALUE + bcd) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

            //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra

            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            if (PRODUCT_CETH.Substring(0, 2) != "24")
            {
                CVD_TOTAL = "0";
                CVD = 0.00;
                PRODUCT_CVD_RATE = "0.00";
                PRODUCT_CETH = "NOEXCISE";
            }

            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            //double Customs_Edu_Cess_a = 0.00;
            //double Customs_Higher_Edu_Cess_a = 0.00;
            double Customs_social_welfare_a = 0.00;

            /* hide on 20/02/2018 discuss with subbu sir --------- start
            Customs_Edu_Cess = (bcd + CVD + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
            Customs_Higher_Edu_Cess = (bcd + CVD + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;

            Customs_Edu_Cess_a = (BASIC_DUTY + CVD + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
            Customs_Higher_Edu_Cess_a = (BASIC_DUTY + CVD + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
             * 
            hide on 20/02/2018 discuss with subbu sir --------- End * */

            Customs_Edu_Cess = 0.00;
            Customs_Higher_Edu_Cess = 0.00;


            //02feb
            Customs_Social_welfare = (bcd + CVD + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            Customs_social_welfare_a = (BASIC_DUTY + CVD + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

            AddL_DUTY = 0.00;

            //IGST ASSBLE SHOW CHECKLIST 
            CHK_IGST_ASSBL_VAL = 0.00;
            CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_social_welfare_a;
            tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);

            //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//
            if (Session["COMPANY_ID"].ToString() == "247" || Session["COMPANY_ID"].ToString() == "10")
            {
                MERIT_NOTN_BASIC_VALUE = Math.Round(Convert.ToDouble(BASIC_DUTY), 2);
                MERIT_NOTN_CVD_VALUE = Math.Round(Convert.ToDouble(CVD), 2);
                MERIT_NOTN_CEC_VALUE = Math.Round(Convert.ToDouble(Customs_Edu_Cess), 2);
                MERIT_NOTN_CHEC_VALUE = Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 2);
                MERIT_NOTN_ADD_DUTY_VALUE = Math.Round(Convert.ToDouble(AddL_DUTY), 2);
                MERIT_NOTN_CESS_VALUE = Math.Round(Convert.ToDouble(CESS), 2);
                MERIT_NOTN_NCD_VALUE = Math.Round(Convert.ToDouble(NCD), 2);
            }
            //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//

            //------------New Anti-Dumping Calculation implemented on 06Oct2018------------//
            string TOTAL_ANTI_AMT_LICNESE;

            if (ANTI_AMTS != null && ANTI_AMTS != "")
            {
                if (ADD_AMT_MINUS_ASSESABLE == "1")
                {
                    TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);

                    if (TOTAL_ANTIDUMP_AMT <= 0)
                    {
                        TOTAL_ANTIDUMP_AMT = 0.00;
                    }
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }

                if (ANTI_DUMPING_NOTN == "002/2017")
                {
                    if (Convert.ToDouble(ITEM_UNIT_PRICE) >= 755 && ITEM_QTY_CODE == "MTS")
                    {
                        MERIT_TOTAL_ANTI_AMT = "0.00";
                    }
                }


                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";

            }
            else if (MAX_DIFF != "" && MAX_DIFF != null)
            {


                if (PRODUCT_OTHER_DUTY_NOTN != "" && PRODUCT_OTHER_DUTY_SLNO != "")
                {
                    if (PRODUCT_OTHER_DUTY_RATE != "")
                    {
                        ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY) * (ADD_MAX_DIFF) / 100;
                        TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));


                        double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                        double Final_Anti_Dump = TOTAL_ANTIDUMP_AMT - Anti_Dump_Cal2;

                        TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(Final_Anti_Dump, 2).ToString("F"));
                        if (Convert.ToDouble(TOTAL_ANTI_AMT_LICNESE) < 0.00)
                            TOTAL_ANTI_AMT_LICNESE = "0.00";

                        MERIT_TOTAL_ANTI_AMT = TOTAL_ANTI_AMT_LICNESE;

                    }
                }
                else
                {
                    ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                    TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }


                //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + TOTAL_ANTI_AMT;
                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + "0.00";

            }
            else if (ADD_DIFF_CUR != null && ADD_DIFF_CUR != "")
            {
                if (ADD_AMT_MINUS_ASSESABLE == "2")
                {
                    TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble((ADD_DIFF_CUR)) / 100;

                    if (TOTAL_ANTIDUMP_AMT <= 0)
                    {
                        TOTAL_ANTIDUMP_AMT = 0.00;
                    }
                    TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }

                //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "           " + " " + ADD_DIFF_CUR + "%" + "     " + TOTAL_ANTIDUMP_AMT;

            }
            //------------End Anti-Dumping Calculation implemented on 06Oct2018------------//

            //------------Start Calculation implemented on 06Oct2018------------//
            if (PRODUCT_OTHER_DUTY_RATE != "")
            {
                //Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100; EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT
                Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT
                PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));

            }
            else if (PRODUCT_OTHER_DUTY_SPL != "")
            {
                Other_duty = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
                PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));
            }
            //------------End Calculation implemented on 06Oct2018------------//

            Call_IGST_General();

            //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD), 1).ToString("0.00"));
            //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess_a + Customs_Higher_Edu_Cess_a + AddL_DUTY + NCD).ToString("0.00"));//HIDE BY CHITHRA ON 20/12/2017 for add IGST With Debit Duty

            if (SCHEME_CODE == "12")
            {
                //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess_a + Customs_Higher_Edu_Cess_a + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT)).ToString("0.00"));
                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_social_welfare_a + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT)).ToString("0.00"));
            }
            else
            {
                //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess_a + Customs_Higher_Edu_Cess_a + AddL_DUTY + NCD).ToString("0.00"));
                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_social_welfare_a + AddL_DUTY + NCD).ToString("0.00"));
            }

            //-----------------------------END TOTAL DEBIT DUTY---------------------------------------//
            // -----------------Spl Excise Duty(Sched-11) Calculation-------------------------------//
            // -----------------GSI Calculation-------------------------------//
            // -----------------TTA Calculation-------------------------------//
            //}
            PRODUCT_OTHER_DUTY_TOTAL = "0";

        }
        //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//

        else
        {
            DataSet ds1 = new DataSet();
            if (PRODUCT_BCD_NOTN == "" && PRODUCT_BCD_NOTN_SLNO == "" && PRODUCT_BCD_RATE == "")
            {
                adm.SCHEME_IMPORT_CODE = SCHEME_CODE;
                adm.SCHEME_IMPORT_NAME = SCHEME_NOTN_;
                adm.SCHEME_NOTN = SCHEME_NOTN;
                adm_Mas.PRODUCT_CETH = PRODUCT_CETH;
                adm.SCHEME_NOTN_SLNO = SCHEME_NOTN_SLNO;
                adm.Name = "SCHEME_NOTN_RATE";

                ds1 = adm.RetrieveAll_CheckList_Scheme_Import();
                //------------------------------------------DATA FETCH FROM SCHEME IMPORT MASTER------------------------------------------//

                if (ds1.Tables[0].Rows.Count > 0)
                {

                    string SCHEME_Rate = ds1.Tables[0].Rows[0]["SCHEME_RATE"].ToString();
                    double SCHEME_Rate1 = Convert.ToDouble(SCHEME_Rate);
                    PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(SCHEME_Rate1).ToString("F"));

                    //BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;

                    double bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;

                    if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                    {
                        // CTH_SPL_AMT = "";
                        BASIC_DUTY = bcd_rate;
                    }
                    else
                    {
                        double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                        double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                        if (bcd_rate >= bcd_Amt)
                        {
                            if (cth_Amt >= bcd_rate)
                            {
                                BASIC_DUTY = cth_Amt;
                            }
                            else
                            {
                                BASIC_DUTY = bcd_rate;
                            }
                        }
                        else
                        {
                            if (cth_Amt >= bcd_Amt)
                            {
                                BASIC_DUTY = cth_Amt;
                            }
                            else
                            {
                                BASIC_DUTY = bcd_Amt;
                            }
                        }
                    }

                    //SOCIAL WELFARE CALCULATION
                    if (SOCIAL_WELFARE_NOTN != "")
                    {
                        SOCIAL_welf_Rate = BASIC_DUTY * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }

                    //-----------------------------NCD CALCULATION---------------------------------------//
                    NCD = 0.00;
                    //-----------------------------END NCD CALCULATION---------------------------------------//

                    // CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                    double CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                    double CVD_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_SPL_AMT);

                    if (CVD_Rate >= CVD_Amt)
                    {
                        CVD = CVD_Rate;
                    }
                    else
                    {
                        CVD = CVD_Amt;
                    }


                    //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra


                    Aggregate_cvd = CVD;

                    if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                    {

                    }
                    else
                    {
                        Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                    }

                    CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Aggregate_cvd), 1).ToString("0.00"));
                    //CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                    //CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                    //ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                    ////TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));


                    // -----------------Spl Excise Duty(Sched-11) Calculation-------------------------------//
                    // -----------------GSI Calculation-------------------------------//
                    // -----------------TTA Calculation-------------------------------//

                    //BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                    //CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                    //cvd_Customs_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_EDU_CESS_RATE) / 100;
                    //cvd_Customs_Higher_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_SEC_EDU_CESS_RATE) / 100;

                    if (!string.IsNullOrEmpty(EDU_CESS_NOTN))
                    {
                        if (EDU_CESS_NOTN == "054/2017")
                        {
                            PRODUCT_SEC_EDU_CESS_NOTN = "055/2017";
                        }
                        else
                        {
                            PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                        }
                        Customs_Edu_Cess = 0.00;
                        Customs_Higher_Edu_Cess = 0.00;
                        //PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                        PRODUCT_EDU_CESS_RATE = "0.00";
                        PRODUCT_SEC_EDU_CESS_RATE = "0.00";

                    }
                    else
                    {
                        Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;

                        Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                    }

                    //02feb
                    Customs_Social_welfare = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

                    //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                    AddL_DUTY = 0.00;
                    //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                    //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                    SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

                    if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                    {

                    }
                    else
                    {
                        Aggregate_safe_guard = SAFE_GUARD;
                        Aggregate_AddL_DUTY = AddL_DUTY;
                        Aggregate_basic_duty = BASIC_DUTY;
                        Aggregate_cvd = CVD;
                        Aggregate_ncd = NCD;
                        Aggregate_Customs_Edu_Cess = Customs_Edu_Cess;
                        Aggregate_Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess;

                        SAFE_GUARD = SAFE_GUARD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                        BASIC_DUTY = BASIC_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                        NCD = NCD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                        Customs_Edu_Cess = Customs_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                        Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                        //AddL_DUTY = AddL_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                        AddL_DUTY = 0.00;
                        Aggregate_safe_guard = Aggregate_safe_guard * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                        Aggregate_AddL_DUTY = Aggregate_AddL_DUTY * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                        Aggregate_basic_duty = Aggregate_basic_duty * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                        Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                        Aggregate_ncd = Aggregate_ncd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                        Aggregate_Customs_Edu_Cess = Aggregate_Customs_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                        Aggregate_Customs_Higher_Edu_Cess = Aggregate_Customs_Higher_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                        AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;
                    }

                    if (PRODUCT_CVD_EDU_CESS_RATE == "013/2012")
                    {
                        CVD_CEC_TOTAL = "0.00";
                        CVD_CHEC_TOTAL = "0.00";
                    }
                    else
                    {
                        CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
                        CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                    }

                    //CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
                    //CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));

                    SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
                    AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
                    BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                    NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
                    CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                    CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                    ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                    //TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));
                }
            }
            else
            {
                //BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                double bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;

                if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                {
                    // CTH_SPL_AMT = "";
                    BASIC_DUTY = bcd_rate;
                }
                else
                {
                    double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                    double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                    if (bcd_rate >= bcd_Amt)
                    {
                        if (cth_Amt >= bcd_rate)
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                        else
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                    }
                    else
                    {
                        if (cth_Amt >= bcd_Amt)
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                        else
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                    }
                }

                //SOCIAL WELFARE CALCULATION
                if (SOCIAL_WELFARE_NOTN != "")
                {
                    SOCIAL_welf_Rate = BASIC_DUTY * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }

                //-----------------------------NCD CALCULATION---------------------------------------//
                NCD = 0.00;
                //-----------------------------END NCD CALCULATION---------------------------------------//                              

                // CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                double CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                double CVD_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_SPL_AMT);

                if (CVD_Rate >= CVD_Amt)
                {
                    CVD = CVD_Rate;
                }
                else
                {
                    CVD = CVD_Amt;
                }


                //Customs_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
                //Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                //AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;
                ////TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                //BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));

                //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra


                Aggregate_cvd = CVD;

                if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                {

                }
                else
                {
                    Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                }

                CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Aggregate_cvd), 1).ToString("0.00"));
                //CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                //CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                //ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                ////TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));

                // -----------------Spl Excise Duty(Sched-11) Calculation-------------------------------//
                // -----------------GSI Calculation-------------------------------//
                // -----------------TTA Calculation-------------------------------//

                //BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                //CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;



                //cvd_Customs_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_EDU_CESS_RATE) / 100;
                //cvd_Customs_Higher_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_SEC_EDU_CESS_RATE) / 100;

                if (!string.IsNullOrEmpty(EDU_CESS_NOTN))
                {
                    if (EDU_CESS_NOTN == "054/2017")
                    {
                        PRODUCT_SEC_EDU_CESS_NOTN = "055/2017";
                    }
                    else
                    {
                        PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                    }
                    Customs_Edu_Cess = 0.00;
                    Customs_Higher_Edu_Cess = 0.00;
                    //PRODUCT_SEC_EDU_CESS_NOTN = "028/2007";
                    PRODUCT_EDU_CESS_RATE = "0.00";
                    PRODUCT_SEC_EDU_CESS_RATE = "0.00";

                }
                else
                {
                    Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
                    Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                }

                Customs_Social_welfare = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

                ////AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;
                //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                AddL_DUTY = 0.00;
                //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

                if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                {

                }
                else
                {
                    Aggregate_safe_guard = SAFE_GUARD;
                    Aggregate_AddL_DUTY = AddL_DUTY;
                    Aggregate_basic_duty = BASIC_DUTY;
                    Aggregate_cvd = CVD;
                    Aggregate_ncd = NCD;
                    Aggregate_Customs_Edu_Cess = Customs_Edu_Cess;
                    Aggregate_Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess;

                    SAFE_GUARD = SAFE_GUARD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                    BASIC_DUTY = BASIC_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                    NCD = NCD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                    Customs_Edu_Cess = Customs_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                    Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                    //AddL_DUTY = AddL_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                    AddL_DUTY = 0.00;
                    Aggregate_safe_guard = Aggregate_safe_guard * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                    Aggregate_AddL_DUTY = Aggregate_AddL_DUTY * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                    Aggregate_basic_duty = Aggregate_basic_duty * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                    Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                    Aggregate_ncd = Aggregate_ncd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                    Aggregate_Customs_Edu_Cess = Aggregate_Customs_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
                    Aggregate_Customs_Higher_Edu_Cess = Aggregate_Customs_Higher_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

                    AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;

                }

                if (PRODUCT_CVD_EDU_CESS_RATE == "013/2012")
                {
                    CVD_CEC_TOTAL = "0.00";
                    CVD_CHEC_TOTAL = "0.00";
                }
                else
                {
                    CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
                    CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                }

                //CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
                //CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));

                SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
                AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
                CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));

                //TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));
            }
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Call_IGST_General() // ********* GST IMPLEMENTATION ON 30 JUN 2017  - START ****************//
    {
        if (IGST_LEVY_NOTN != "")
        {
            double IGST_LEV_2_COMPENSATION_AMT1 = 0.00;

            if (IGST_LEVY_EXCEPTION_NOTN == "" && IGST_LEVY_EXCEPTION_SLNO == "")
            {
                //IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Edu_Cess) + Convert.ToDouble(Customs_Higher_Edu_Cess)  + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_RATE) / 100;

                //--------------------Start RSP Calculation on 11Sep2018-------------------------//
                if (RSP_APPLICABLE == "S")
                {
                    //if (MRP_AMT > BASIC_DUTY)
                    //{
                    //    BASIC_DUTY = MRP_AMT;

                    //    IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    //}
                    //else
                    //{
                    //    IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    //}
                    IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT));

                    if (MRP_AMT > IGST_LEV_1_AMT)
                    {
                        IGST_LEV_1_AMT = (Convert.ToDouble(MRP_AMT)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }
                    else
                    {
                        IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }

                }
                else
                {
                    IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                }
                //--------------------End RSP Calculation on 11Sep2018-------------------------//


                //IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;

                IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_AMT), 1).ToString("0.00"));
            }
            else
            {
                if (IGST_LEVY_EXCEPTION_NOTN != "" && IGST_LEVY_EXCEPTION_SLNO != "")
                {
                    //IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Edu_Cess) + Convert.ToDouble(Customs_Higher_Edu_Cess) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;



                    /* HIDE BY CHITHRA ON 03-02-2019 - FOR IGST EXCEMPTION SPL AMT CALC FOR BOXCO SUGGEST BY BALA SIR..
                   IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;
                   IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                   */


                    // START -  NEWLY IMPLEMENTED BY CHITHRA  ON 03-02-2019 - FOR IGST EXCEMPTION SPL AMT CALC FOR BOXCO SUGGEST BY BALA SIR..

                    var IGST_RATES = from DataRow drr in dt_All_Rates.Tables[4].AsEnumerable()
                                     where drr.Field<string>("NOTIFICATION_EXCISE_NOTN") == IGST_LEVY_EXCEPTION_NOTN && drr.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == IGST_LEVY_EXCEPTION_SLNO //&& drr.Field<string>("NOTIFICATION_TYPE") == "C"
                                     select drr;

                    DataView dv_IGST_RATE = IGST_RATES.AsDataView();

                    double igst_NOTIFICATION_EXCISE_BCD_SPL = 0.00;
                    if (dv_IGST_RATE.Count > 0)
                    {
                        DataTable dt_IGST_SPL = IGST_RATES.CopyToDataTable();
                        igst_NOTIFICATION_EXCISE_BCD_SPL = Convert.ToDouble(dt_IGST_SPL.Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString() == string.Empty ? 0.00 : Convert.ToDouble(dt_IGST_SPL.Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString()));
                    }

                    if (igst_NOTIFICATION_EXCISE_BCD_SPL > 0)
                    {
                        IGST_LEV_2_Excemption = (Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(igst_NOTIFICATION_EXCISE_BCD_SPL)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;
                        IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                    }
                    else
                    {
                        IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;
                        IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                    }
                    // END -  NEWLY IMPLEMENTED BY CHITHRA  ON 03-02-2019 - FOR IGST EXCEMPTION SPL AMT CALC FOR BOXCO SUGGEST BY BALA SIR..



                    if (SCHEME_CODE == "12" || SCHEME_CODE == "03" || SCHEME_CODE == "17")
                    {

                        IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;

                        IGST_LEVY_TOTAL_DEBIT = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_AMT), 1).ToString("0.00"));
                    }
                }
            }

            //******************* COMPENSATION CALCULATION ************************

            if (IGST_LEVY_EXCEPTION_CC_NOTN == "" && IGST_LEVY_EXCEPTION_CC_SLNO == "")
            {
                if (IGST_LEVY_COMPENSATION_CESS_RATE != "")
                {
                    //IGST_LEV_1_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Edu_Cess) + Convert.ToDouble(Customs_Higher_Edu_Cess) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                    IGST_LEV_1_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                    IGST_LEVY_COMPENSATION_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_COMPENSATION_AMT), 1).ToString("0.00"));
                }
            }
            else
            {
                if (IGST_LEVY_EXCEPTION_CC_NOTN != "" && IGST_LEVY_EXCEPTION_CC_SLNO != "")
                {
                    //IGST_LEV_2_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Edu_Cess) + Convert.ToDouble(Customs_Higher_Edu_Cess) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE) / 100;
                    IGST_LEV_2_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE) / 100;
                    IGST_LEVY_COMPENSATION_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_COMPENSATION_AMT), 1).ToString("0.00"));
                }
            }


            if (IGST_LEVY_COMPENSATION_CESS_NOTN != "" && IGST_LEVY_COMPENSATION_CESS_SLNO != "")
            {
                if ((Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL) != 0.00) || (Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL) > 0.00))
                {
                    if (Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL) != 0.00)
                    {
                        IGST_LEV_2_COMPENSATION_AMT1 = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL);

                        IGST_LEV_2_COMPENSATION_AMT1 = Math.Round(Convert.ToDouble(IGST_LEV_2_COMPENSATION_AMT1), 1);

                        if (Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) <= IGST_LEV_2_COMPENSATION_AMT1)
                        {
                            IGST_LEVY_COMPENSATION_CESS_TOTAL = Convert.ToString(IGST_LEV_2_COMPENSATION_AMT1);
                        }
                    }
                }
            }
        }
    }

    public double Get_Indivitual_Assesable_Value(DataTable dt_ReImport, int INV_SLNO, string INV_NO, string ITEM_SLNO)
    {
        double freight_amt_air = 0.00;
        INDIVITUAL_SVB_AMOUNT = 0;
        INSURANCE_AMOUNT = 0;
        FREIGHT_AMOUNT = 0;
        MISC_AMOUNT = 0;

        INDIVITUAL_INSURANCE_AMOUNT = 0;
        INDIVITUAL_FREIGHT_AMOUNT = 0;
        INDIVITUAL_MISC_AMOUNT = 0;
        INDIVITUAL_HSS_AMOUNT = 0;
        INDIVITUAL_DISCOUNT_AMOUNT = 0;

        INVOICE_VALUE_INR = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);


        //************ CI Terms display in CHECKLIST ******************** 03/01/2018 

        if (TERMS == "CI")
        {

            string Cal_MIS_CHARGES;

            if (MIS_CHARGES == "" || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
            {
                if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
                {
                    MIS_CURRENCY = INVOICE_CURRENCY;
                    Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
                    MISC_AMOUNT = Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) * Convert.ToDouble(INVOICE_EXRATE);
                    //MIS_CHARGES = Convert.ToString(MISC_AMOUNT);
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
                        Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
                        MISC_AMOUNT = Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) * Convert.ToDouble(INVOICE_EXRATE);
                        //MIS_CHARGES = Convert.ToString(MISC_AMOUNT);
                    }
                    else
                    {
                        double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
                        Cal_MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
                        MIS_CURRENCY = INVOICE_CURRENCY;
                        Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
                        MISC_AMOUNT = Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) * Convert.ToDouble(INVOICE_EXRATE);
                        //MIS_CHARGES = Convert.ToString(MISC_AMOUNT);
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
            MISC_AMOUNT = Convert.ToDouble(MIS_CHARGES) * Convert.ToDouble(MIS_EXRATE);
        }



        //-----DISCOUNT AMOUNT CAL--------------//
        if (MIS_DISCOUNT_RATE != "0" && MIS_DISCOUNT_RATE != "0.00")
        {
            DISCOUNT_AMOUNT = (INVOICE_VALUE_INR / 100) * Convert.ToDouble(MIS_DISCOUNT_RATE);
            TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR - DISCOUNT_AMOUNT;
        }
        else if (MIS_DISCOUNT_CHARGES != "0" && MIS_DISCOUNT_CHARGES != "0.00")
        {
            DISCOUNT_AMOUNT = Convert.ToDouble(MIS_DISCOUNT_CHARGES) * Convert.ToDouble(MIS_DISCOUNT_EXRATE);
            //TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR - DISCOUNT_AMOUNT;
            TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR;
        }
        else
            TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR;
        //-----DISCOUNT AMOUNT CAL--------------//

        //-----INSURANCE AMOUNT CAL--------------//
        if (MIS_INSURANCE_RATE != "0" && MIS_INSURANCE_RATE != "0.00" && MIS_INSURANCE_RATE != "0.0000" && MIS_INSURANCE_RATE != "")
        {
            INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;

        }
        else if (MIS_INSURANCE_CHARGES != "0" && MIS_INSURANCE_CHARGES != "0.00")
        {
            INSURANCE_AMOUNT = Convert.ToDouble(MIS_INSURANCE_CHARGES) * Convert.ToDouble(MIS_INSURANCE_EXRATE);

        }
        //-----INSURANCE AMOUNT CAL--------------//

        //-----FREIGHT AMOUNT CAL--------------//


        if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00")
        {
            FREIGHT_AMOUNT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;

        }
        if (TRANSPORT_MODE == "Sea" || TRANSPORT_MODE == "Land")
        {
            if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00" && MIS_FREIGHT_RATE != "0.0000" && MIS_FREIGHT_RATE != "")
            {
            }
            else
            {
                if (MIS_FREIGHT_CHARGES != "")
                {
                    FREIGHT_AMOUNT = Convert.ToDouble(MIS_FREIGHT_CHARGES) * Convert.ToDouble(MIS_FREIGHT_EXRATE);
                }
            }
        }
        else
        {
            if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00" && MIS_FREIGHT_RATE != "0.0000" && MIS_FREIGHT_RATE != "")
            {
            }
            else
            {
                if (MIS_FREIGHT_CHARGES != "0" && MIS_FREIGHT_CHARGES != "0.00")
                {

                    //freight_amt_air = (Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES)) * 20 / 100;

                    //if (freight_amt_air < Convert.ToDouble(MIS_FREIGHT_CHARGES))
                    //{                       
                    //    FREIGHT_AMOUNT = Convert.ToDouble(freight_amt_air) * Convert.ToDouble(MIS_FREIGHT_EXRATE);
                    //}
                    //else
                    //{
                    //    FREIGHT_AMOUNT = Convert.ToDouble(MIS_FREIGHT_CHARGES) * Convert.ToDouble(MIS_FREIGHT_EXRATE);
                    //}


                    freight_amt_air = (INVOICE_VALUE_INR + MISC_AMOUNT) * 20 / 100;
                    FREIGHT_AMOUNT = Convert.ToDouble(MIS_FREIGHT_CHARGES) * Convert.ToDouble(MIS_FREIGHT_EXRATE);

                    if (freight_amt_air < FREIGHT_AMOUNT)
                    {
                        FREIGHT_AMOUNT = freight_amt_air;
                    }
                    else
                    {
                        FREIGHT_AMOUNT = FREIGHT_AMOUNT;
                    }

                    //Calculation not understandable 27/08/2013 //

                    //CHECK_FREIGHT_RATE = (CHECK_FREIGHT_EXRATE * TOTAL_INVOICE_VALUE) / 100;
                    //if (CHECK_FREIGHT_EXRATE >= Convert.ToDouble(MIS_FREIGHT_CHARGES))
                    //{
                    //    FREIGHT_AMOUNT = CHECK_FREIGHT_RATE;
                    //}
                }
            }
        }

        //-----FREIGHT AMOUNT CAL--------------//

        //-----ITEM AMOUNT CAL--------------//
        INDIVITUAL_INVOICE_VALUE = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(INVOICE_EXRATE);
        //INDIVITUAL_DISCOUNT_AMOUNT = INDIVITUAL_INVOICE_VALUE * DISCOUNT_AMOUNT / TOTAL_INVOICE_VALUE;
        INDIVITUAL_DISCOUNT_AMOUNT = INDIVITUAL_INVOICE_VALUE * DISCOUNT_AMOUNT / TOTAL_INVOICE_VALUE;

        //-----REIMPORTT CAL--------------//
        DataView view = dt_ReImport.DefaultView;
        view.RowFilter = "INVOICE_NO = '" + INV_NO + "' and " + "INVOICE_SLNO = '" + INV_SLNO + "' and " + "ITEM_SLNO = '" + ITEM_SLNO + "'";

        REIMPORT_FREIGHT = "0.00";
        REIMPORT_INSURANCE = "0.00";

        REIMPORT_FREIGHT_AMOUNT = 0.00;
        REIMPORT_INSURANCE_AMOUNT = 0.00;

        if (view.Count > 0)
        {
            view.RowFilter = "INVOICE_NO = '" + INV_NO + "' and " + "INVOICE_SLNO = '" + INV_SLNO + "' and " + "ITEM_SLNO = '" + ITEM_SLNO + "'";
            //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
            DataTable table = view.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            int b = 0;
            while (dss.Tables[0].Rows.Count > b)
            {
                REIMPORT_FREIGHT = Return_Zero_Value(dss.Tables[0].Rows[b]["EXPORT_FREIGHT"].ToString());
                REIMPORT_INSURANCE = Return_Zero_Value(dss.Tables[0].Rows[b]["EXPORT_INSURANCE"].ToString());

                //REIMPORT_FREIGHT_AMOUNT = REIMPORT_FREIGHT_AMOUNT + Convert.ToDouble(REIMPORT_FREIGHT);
                //REIMPORT_INSURANCE_AMOUNT = REIMPORT_INSURANCE_AMOUNT + Convert.ToDouble(REIMPORT_INSURANCE);

                REIMPORT_FREIGHT_AMOUNT = Convert.ToDouble(REIMPORT_FREIGHT);
                REIMPORT_INSURANCE_AMOUNT = Convert.ToDouble(REIMPORT_INSURANCE);


                b++;
            }
        }
        //-----REIMPORTT CAL--------------//
        //-----REIMPORTT FREIGHT CAL--------------//

        INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * FREIGHT_AMOUNT;
        INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_FREIGHT_AMOUNT + REIMPORT_FREIGHT_AMOUNT;

        //-----REIMPORTT FREIGHT CAL--------------//

        //-----REIMPORTT INSURANCE CAL--------------//

        INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * INSURANCE_AMOUNT;
        INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;

        //-----REIMPORTT INSURANCE CAL--------------//

        //-----MISC CAL--------------//

        INDIVITUAL_MISC_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * MISC_AMOUNT;

        if (Session["COMPANY_ID"].ToString() == "163")
        {
            INDIVITUAL_TOTAL_AMOUNT = INDIVITUAL_INVOICE_VALUE + INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_MISC_AMOUNT;
        }
        else
        {
            //INDIVITUAL_TOTAL_AMOUNT = INDIVITUAL_DISCOUNT_AMOUNT + INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_MISC_AMOUNT;
            INDIVITUAL_TOTAL_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_MISC_AMOUNT) - INDIVITUAL_DISCOUNT_AMOUNT;
        }
        //-----MISC CAL--------------//

        //-----HSS CAL--------------//
        if (MIS_HIGHSEASALE_RATE != "0" && MIS_HIGHSEASALE_RATE != "0.00")
        {
            INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(MIS_HIGHSEASALE_RATE)) / 100;
        }
        else if (MIS_HIGHSEASALE_CHARGES != "0" && MIS_HIGHSEASALE_CHARGES != "0.00")
        {
            //modified on 23aug2013 by subbu sir
            INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT) / TOTAL_INVOICE_VALUE * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES);
            //modified on 23aug2013 by subbu sir

            //modified on 28Dec2013 by subbu sir
            INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_INVOICE_VALUE) / TOTAL_INVOICE_VALUE * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES);
            //modified on 28Dec2013 by subbu sir


            //INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES)) / 100;
        }

        //-----HSS CAL--------------//

        //-----SVB CAL--------------//

        //if (SVB_ASSESABLE_RATE != "0" && SVB_ASSESABLE_RATE != "0.00")
        //{
        //if (TERMS == "CIF")
        //{
        //    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
        //}
        //else if (TERMS == "FOB")
        //{
        //    if (MIS_FREIGHT_RATE == "0.00" || MIS_FREIGHT_RATE == "0" && MIS_INSURANCE_RATE == "0.00" || MIS_INSURANCE_RATE == "0" )
        //    {
        //        INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT - (INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT ))*Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //       // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //    }
        //    else if(MIS_FREIGHT_RATE != "0.00" || MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE != "0.00" || MIS_INSURANCE_RATE != "0" )
        //    {
        //        INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //    }
        //}
        //}

        //-----SVB CAL--------------//

        //-----CIF CAL--------------//
        INDIVITUAL_CIF_AMOUNT = INDIVITUAL_TOTAL_AMOUNT + INDIVITUAL_HSS_AMOUNT + INDIVITUAL_SVB_AMOUNT;

        if (BE_TYPE == "Ex-Bond")
        {
            if (EXBOND_ADDL_LOAD_HSS != "")
            {
                double ADDL_LOAD_HSS = 0.00;

                ADDL_LOAD_HSS = INDIVITUAL_CIF_AMOUNT * (Convert.ToDouble(EXBOND_ADDL_LOAD_HSS)) / 100;
                INDIVITUAL_CIF_AMOUNT = INDIVITUAL_CIF_AMOUNT + ADDL_LOAD_HSS;

            }

            if (EXBOND_MISC_LOAD_RATE != "")
            {
                double ADDL_MISC_LOAD_RATE = 0.00;

                ADDL_MISC_LOAD_RATE = INDIVITUAL_CIF_AMOUNT * (Convert.ToDouble(EXBOND_MISC_LOAD_RATE)) / 100;
                INDIVITUAL_CIF_AMOUNT = INDIVITUAL_CIF_AMOUNT + ADDL_MISC_LOAD_RATE;
            }

            string compareDate_IGM1 = "27/09/2017";
            compareDate_IGM = Convert.ToDateTime(compareDate_IGM1);

            if (Igm_DATE != "" || Igm_DATE == null)
            {
                if (IGMDate <= compareDate_IGM)
                {
                    double LANDING_COST = (INDIVITUAL_CIF_AMOUNT * 1) / 100;
                    INDIVITUAL_CIF_AMOUNT = INDIVITUAL_CIF_AMOUNT + LANDING_COST;
                }
            }
        }

        //-----CIF CAL--------------//
        //-----LANDING COST CAL--------------//
        INDIVITUAL_LANDING_COST = (INDIVITUAL_CIF_AMOUNT * 1) / 100;

        //-----LANDING COST CAL--------------//

        //-----ASSESABLE CAL--------------//

        //INDIVITUAL_ASSESSABLE_AMOUNT =  INDIVITUAL_CIF_AMOUNT + INDIVITUAL_LANDING_COST; //Disabled on 28Sep2017

        //INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_CIF_AMOUNT; //Implemented on 28Sep2017               

        //string compareDate_IGM1 = "27/09/2017";
        //compareDate_IGM = Convert.ToDateTime(compareDate_IGM1);

        //if (Igm_DATE != "" || Igm_DATE == null)
        //{
        //    if (IGMDate <= compareDate_IGM)
        //    {
        //        INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_CIF_AMOUNT + INDIVITUAL_LANDING_COST; //Disabled on 28Sep2017
        //    }
        //    else
        //    {
        //        INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_CIF_AMOUNT;
        //    }
        //}
        //else
        //{
        //    INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_CIF_AMOUNT;
        //}

        INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_CIF_AMOUNT;

        //-----ASSESABLE CAL--------------//


        //-----ITEM AMOUNT CAL--------------//

        if (SVB_ASSESABLE_RATE != "0" && SVB_ASSESABLE_RATE != "0.00")
        {
            if (TERMS == "CIF")
            {
                INDIVITUAL_SVB_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT * (Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
            }
            else if (TERMS == "FOB")
            {
                if (MIS_FREIGHT_RATE == "0" || MIS_FREIGHT_RATE == "0.00" || MIS_FREIGHT_RATE == "0.000" || MIS_FREIGHT_RATE == "0.0000")
                {
                    MIS_FREIGHT_RATE = "0";
                }

                if (MIS_INSURANCE_RATE == "0" || MIS_INSURANCE_RATE == "0.00")
                {
                    MIS_INSURANCE_RATE = "0";
                }

                if (MIS_FREIGHT_RATE == "0" && MIS_INSURANCE_RATE != "0")
                {

                    //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;

                    /* -- HIDE BY CHITHRA ON 27-03-2018 - CAPITAL SHIPPING- RAMESH ASKED
                    double AA = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);
                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) *  Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                     */
                    //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }

                else if (MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE == "0")
                {
                    double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }

                else if (MIS_FREIGHT_RATE == "0" && MIS_INSURANCE_RATE == "0")
                {
                    double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);
                    double BB = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);
                    double CC = AA + BB;

                    //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - CC) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;

                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }

                else if (MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE != "0")
                {
                    double AA = INDIVITUAL_INSURANCE_AMOUNT - (INDIVITUAL_INSURANCE_AMOUNT * 0.01);
                    double BB = INDIVITUAL_FREIGHT_AMOUNT - (INDIVITUAL_FREIGHT_AMOUNT * 0.01);
                    double CC = AA + BB;

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - CC) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }
            }
            else if (TERMS == "CF")
            {

                if (MIS_INSURANCE_RATE == "0" || MIS_INSURANCE_RATE == "0.00")
                {
                    MIS_INSURANCE_RATE = "0";
                }

                if (MIS_INSURANCE_RATE != "0")
                {
                    double AA = INDIVITUAL_INSURANCE_AMOUNT - (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }
                else if (MIS_INSURANCE_RATE == "0")
                {
                    double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }
            }
            else if (TERMS == "CI")
            {

                if (MIS_FREIGHT_RATE == "0" || MIS_FREIGHT_RATE == "0.00" || MIS_FREIGHT_RATE == "0.000" || MIS_FREIGHT_RATE == "0.0000")
                {
                    MIS_FREIGHT_RATE = "0";
                }

                if (MIS_FREIGHT_RATE != "0")
                {
                    double AA = INDIVITUAL_FREIGHT_AMOUNT - (INDIVITUAL_FREIGHT_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }
                else if (MIS_FREIGHT_RATE == "0")
                {
                    double AA = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }
            }
        }

        //--------ITEMWISE SVB CALCULATION FOR NIPPON EXPRESS--------//

        //else if (ITEM_SVB_ASSESABLE_RATE != "0" && ITEM_SVB_ASSESABLE_RATE != "0.00" && ITEM_SVB_ASSESABLE_RATE != "")
        //{
        //    if (TERMS == "CIF")
        //    {
        //        INDIVITUAL_SVB_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT * (Convert.ToDouble(ITEM_SVB_ASSESABLE_RATE)) / 100;
        //    }
        //    else if (TERMS == "FOB")
        //    {
        //        if (MIS_FREIGHT_RATE == "0" || MIS_FREIGHT_RATE == "0.00")
        //        {
        //            MIS_FREIGHT_RATE = "0";
        //        }


        //        if (MIS_INSURANCE_RATE == "0" || MIS_INSURANCE_RATE == "0.00")
        //        {
        //            MIS_INSURANCE_RATE = "0";
        //        }



        //        if (MIS_FREIGHT_RATE == "0" && MIS_INSURANCE_RATE != "0")
        //        {
        //            double AA = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);

        //            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(ITEM_SVB_ASSESABLE_RATE) / 100;
        //            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //        }

        //        else if (MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE == "0")
        //        {
        //            double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

        //            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(ITEM_SVB_ASSESABLE_RATE) / 100;
        //            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //        }

        //        else if (MIS_FREIGHT_RATE == "0" && MIS_INSURANCE_RATE == "0")
        //        {
        //            double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);
        //            double BB = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);
        //            double CC = AA + BB;

        //            //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - CC) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT) * Convert.ToDouble(ITEM_SVB_ASSESABLE_RATE) / 100;

        //            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //        }

        //        else if (MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE != "0")
        //        {
        //            double AA = INDIVITUAL_INSURANCE_AMOUNT - (INDIVITUAL_INSURANCE_AMOUNT * 0.01);
        //            double BB = INDIVITUAL_FREIGHT_AMOUNT - (INDIVITUAL_FREIGHT_AMOUNT * 0.01);
        //            double CC = AA + BB;

        //            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - CC) * Convert.ToDouble(ITEM_SVB_ASSESABLE_RATE) / 100;
        //            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //        }

        //    }
        //    else if (TERMS == "CF")
        //    {

        //        if (MIS_INSURANCE_RATE == "0" || MIS_INSURANCE_RATE == "0.00")
        //        {
        //            MIS_INSURANCE_RATE = "0";
        //        }

        //        if (MIS_INSURANCE_RATE != "0")
        //        {
        //            double AA = INDIVITUAL_INSURANCE_AMOUNT - (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

        //            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(ITEM_SVB_ASSESABLE_RATE) / 100;
        //            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //        }
        //        else if (MIS_INSURANCE_RATE == "0")
        //        {
        //            double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

        //            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(ITEM_SVB_ASSESABLE_RATE) / 100;
        //            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //        }
        //    }
        //    else if (TERMS == "CI")
        //    {

        //        if (MIS_FREIGHT_RATE == "0" || MIS_FREIGHT_RATE == "0.00")
        //        {
        //            MIS_FREIGHT_RATE = "0";
        //        }

        //        if (MIS_FREIGHT_RATE != "0")
        //        {
        //            double AA = INDIVITUAL_FREIGHT_AMOUNT - (INDIVITUAL_FREIGHT_AMOUNT * 0.01);

        //            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(ITEM_SVB_ASSESABLE_RATE) / 100;
        //            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //        }
        //        else if (MIS_FREIGHT_RATE == "0")
        //        {
        //            double AA = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);

        //            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(ITEM_SVB_ASSESABLE_RATE) / 100;
        //            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //        }
        //    }
        //}

        //--------ITEMWISE SVB CALCULATION FOR NIPPON EXPRESS--------//

        INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT + INDIVITUAL_SVB_AMOUNT;
        return INDIVITUAL_ASSESSABLE_AMOUNT;
    }

   

    public string Return_Zero_Value(string val)
    {
        if (val == "")
        {
            val = "0";
        }
        return val;
    }
    public string Return_Zero_Value1(string val)
    {
        if (val == "")
        {
            val = "0.00";
        }
        return val;
    }
     

    // ---------------------------------------------------Jono dropdown work--------------------

    public void Scheme_SAME_CODE_GENERAL_CALC()
    {
        BASIC_DUTY = 0.00;
        SAFE_GUARD = 0.00;
        CVD = 0.00;
        NCD = 0.00;
        Customs_Edu_Cess = 0.00;
        Customs_Higher_Edu_Cess = 0.00;
        AddL_DUTY = 0.00;


        cvd_Customs_Edu_Cess = 0.00;
        cvd_Customs_Higher_Edu_Cess = 0.00;
        Customs_Social_welfare = 0.00;

        if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
        {

        }
        else
        {
            Aggregate_safe_guard = SAFE_GUARD;
            Aggregate_AddL_DUTY = AddL_DUTY;
            Aggregate_basic_duty = BASIC_DUTY;
            Aggregate_cvd = CVD;
            Aggregate_ncd = NCD;
            Aggregate_Customs_Edu_Cess = Customs_Edu_Cess;
            Aggregate_Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess;

            SAFE_GUARD = SAFE_GUARD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            //AddL_DUTY = AddL_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            AddL_DUTY = 0.00;

            BASIC_DUTY = BASIC_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            CVD = CVD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            NCD = NCD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            Customs_Edu_Cess = Customs_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
            Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;

            Aggregate_safe_guard = Aggregate_safe_guard * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_AddL_DUTY = Aggregate_AddL_DUTY * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_basic_duty = Aggregate_basic_duty * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_cvd = Aggregate_cvd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

            Aggregate_ncd = Aggregate_ncd * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_Customs_Edu_Cess = Aggregate_Customs_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;
            Aggregate_Customs_Higher_Edu_Cess = Aggregate_Customs_Higher_Edu_Cess * Convert.ToDouble(100 - Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE)) / 100;

            AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;
        }

        CVD_CEC_TOTAL = "0.00";
        CVD_CHEC_TOTAL = "0.00";

        /* hide on 20/02/2018 discuss with subbu sir --------- start
        if (PRODUCT_CVD_EDU_CESS_RATE == "013/2012")
        {
            CVD_CEC_TOTAL = "0.00";
            CVD_CHEC_TOTAL = "0.00";
        }
        else
        {
            CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
            CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));
        }
         * 
       hide on 20/02/2018 discuss with subbu sir --------- End  * */

        SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
        BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
        AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
        CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));

        NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
        TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));

        //ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));


        //-----------------------CALCULATION FOR TOTAL DEBIT DUTY--------------------------------//

        double bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;

        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
        {
            //CTH_SPL_AMT = "";
            BASIC_DUTY = bcd_rate;
        }
        else
        {
            double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
            double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

            if (bcd_rate >= bcd_Amt)
            {
                if (cth_Amt >= bcd_rate)
                {
                    BASIC_DUTY = cth_Amt;
                }
                else
                {
                    BASIC_DUTY = bcd_rate;
                }
            }
            else
            {
                if (cth_Amt >= bcd_Amt)
                {
                    BASIC_DUTY = cth_Amt;
                }
                else
                {
                    BASIC_DUTY = bcd_Amt;
                }
            }
        }

        //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

        //---------------END SAPTA CALCULATION-------------------------//

        CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

        //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra

        //cvd_Customs_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_EDU_CESS_RATE) / 100;
        //cvd_Customs_Higher_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_SEC_EDU_CESS_RATE) / 100;

        if (PRODUCT_CETH.Substring(0, 2) != "24")
        {
            CVD = 0.00;
            CVD_TOTAL = "0.00";
            PRODUCT_CVD_RATE = "0.00";
        }

        Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
        Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;

        //02feb
        Customs_Social_welfare = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;//02feb

        //IGST ASSESABLE VALUE SHOWS IN CHECKLIST - BY CHITHRA ON 05/05/2018
        CHK_IGST_ASSBL_VAL = 0.00;
        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare;
        tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);


        ADDLTIONAL_DUTY_TOTAL = "0.00";

        AddL_DUTY = 0.00;

        //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//
        if (Session["COMPANY_ID"].ToString() == "247" || Session["COMPANY_ID"].ToString() == "218" || Session["COMPANY_ID"].ToString() == "392" || Session["COMPANY_ID"].ToString() == "10" || Session["COMPANY_ID"].ToString() == "4" || Session["COMPANY_ID"].ToString() == "480" || Session["COMPANY_ID"].ToString() == "508" || Session["COMPANY_ID"].ToString() == "1026")
        {
            MERIT_NOTN_BASIC_VALUE = Math.Round(Convert.ToDouble(BASIC_DUTY), 2);
            MERIT_NOTN_CVD_VALUE = Math.Round(Convert.ToDouble(CVD), 2);
            MERIT_NOTN_CEC_VALUE = Math.Round(Convert.ToDouble(Customs_Edu_Cess), 2);
            MERIT_NOTN_CHEC_VALUE = Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 2);
            MERIT_NOTN_ADD_DUTY_VALUE = Math.Round(Convert.ToDouble(AddL_DUTY), 2);
            MERIT_NOTN_CESS_VALUE = Math.Round(Convert.ToDouble(CESS), 2);
            MERIT_NOTN_NCD_VALUE = Math.Round(Convert.ToDouble(NCD), 2);

            merit_social_welfare_cess = Math.Round(Convert.ToDouble(Customs_Social_welfare), 2);
        }
        //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//

        Call_IGST_General();

        //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD), 1).ToString("0.00"));
        //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD).ToString("0.00"));//hide 02feb 2018 by chithra
        TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Social_welfare + AddL_DUTY + NCD).ToString("0.00"));

        //-----------------------------END TOTAL DEBIT DUTY---------------------------------------//

        // -----------------Spl Excise Duty(Sched-11) Calculation-------------------------------//
        // -----------------GSI Calculation-------------------------------//
        // -----------------TTA Calculation-------------------------------//
    }

    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJob_No.SelectedItem.Text != "Select")
        {
           
            Response.Redirect("../Report/Import_ReportViewerNewFont.aspx?jobno=" + ddlJob_No.SelectedItem.Value + "&jobnops='" + ddlJob_No.SelectedItem.Text + "' ");
        }
    }

   

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (lbl.Text != "")
        {
            byte[] bytes = Encoding.ASCII.GetBytes(lbl.Text);
            Session.Remove("report");
            Session["report"] = bytes;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "Mail_open()", true);
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
    protected void btn_checklist_Value_Update_Click(object sender, EventArgs e)
    {
        DataTable dt =new DataTable();
        dt = null;
        dt=(DataTable)ViewState["Checklist_Value"];

        if (dt.Rows.Count > 0)
        {
            UserBO ObjUBO = new UserBO();
            Imp_Checklist IC = new Imp_Checklist();
            ObjUBO.JOBNO = ddlJob_No.SelectedValue.ToString();
            String xmlData = ConvertDataTableToXML(dt);
            ObjUBO.Xml_D = xmlData;
            IC.Import_Item_ASS_Duty_CIF_CVD_VLAUE_UPDATE(ObjUBO);

            lblmsg.Text = "Updated Successfully";
        }
        else
        {
            lblmsg.Text = "Incorect Value(s)";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Incorect Checklist Value')</script>", false);
        }
    }
}