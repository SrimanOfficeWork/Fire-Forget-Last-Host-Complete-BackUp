using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using BussinessObject;
using System.Diagnostics;
using System.Globalization;


public partial class Transaction_Default2 : System.Web.UI.Page
{
    Imp_Checklist IC = new Imp_Checklist();

    private string _BE_NO, _BE_NO_DATE, _FIRSTCHECK, _GREEN_CHANNEL, _KACHHA_BE, _SECTION48, _PROVISIONAL, _BE_TYPE, _EXBOND_ADDL_LOAD_HSS, _EXBOND_MISC_LOAD_RATE, _HIGH_SEA_SALE_NAME, _HIGH_SEA_IEC
        , _HIGH_SEA_BRANCH_SL_NO, _HSS_ADD1, _HSS_ADD2, _HSS_ADD3, _HSS_ADD4, _HSS_ADD5, _SUPPLIER_COUNTRY_NAME, _SUPPLIER_COUNTRY_PINCODE, _SVB_ASSESABLE_STATUS, _SVB_DUTY_STATUS, _INVOICE_NO
        , _BETYPE, _BE_TYPE_New;
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //General Details
     public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
     public string BE_NO_DATE { get { return _BE_NO_DATE; } set { _BE_NO_DATE = value; } }
     public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }
     public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
     public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
     public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }
     public string PROVISIONAL { get { return _PROVISIONAL; } set { _PROVISIONAL = value; } }
     public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
     public string EXBOND_ADDL_LOAD_HSS { get { return _EXBOND_ADDL_LOAD_HSS; } set { _EXBOND_ADDL_LOAD_HSS = value; } }
     public string EXBOND_MISC_LOAD_RATE { get { return _EXBOND_MISC_LOAD_RATE; } set { _EXBOND_MISC_LOAD_RATE = value; } }
     public string BETYPE { get { return _BETYPE; } set { _BETYPE = value; } }
     public string BE_TYPE_New { get { return _BE_TYPE_New; } set { _BE_TYPE_New = value; } }

     private string _DIFF_AMT_BDC_TRQ_SW;
     private string _DIFF_AMT_BDC_TRQ;
     private string _DIFF_FG_AMT_BDC_TRQ;
     public string DIFF_FG_AMT_BDC_TRQ { get { return _DIFF_FG_AMT_BDC_TRQ; } set { _DIFF_FG_AMT_BDC_TRQ = value; } }
     public string DIFF_AMT_BDC_TRQ_SW { get { return _DIFF_AMT_BDC_TRQ_SW; } set { _DIFF_AMT_BDC_TRQ_SW = value; } }
     public string DIFF_AMT_BDC_TRQ { get { return _DIFF_AMT_BDC_TRQ; } set { _DIFF_AMT_BDC_TRQ = value; } }
    //---------------------ITEM ATTRIBUTES-----------------//
    private int _INVOICE_SLNO;
    public int INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }

    private double _ASSESABLE_VALUE, _ASSESSABLE_TOTAL, _ITEM_TOTAL, _ITEM_TOTAL_SVB_DUTY;

    public double ASSESSABLE_TOTAL { get { return _ASSESSABLE_TOTAL; } set { _ASSESSABLE_TOTAL = value; } }
    public double ITEM_TOTAL { get { return _ITEM_TOTAL; } set { _ITEM_TOTAL = value; } }
    public double ITEM_TOTAL_SVB_DUTY { get { return _ITEM_TOTAL_SVB_DUTY; } set { _ITEM_TOTAL_SVB_DUTY = value; } }
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
    ,_IGST_LEVY_COMPENSATION_CESS_RATE,_IGST_LEVY_COMPENSATION_CESS_SPL, _IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE, _IGST_LEVY_EXCEPTION_CC_NOTN, _IGST_LEVY_EXCEPTION_CC_SLNO, _IGST_LEVY_EXCEPTION_CC_RATE
    ,_LEVY_EXCEMPTION_NOTN_TYPE, _LEVY_EXCEPTION_CC_NOTN_TYPE,_END_USE_OF_ITEM,_NOTIFICATION_EXCISE_BCD_SPL
    //----------------GST IMPLEMENTATION ON 30JUNE2017------------------------//
    ,_SCHED11_TOTAL, _PRODUCT_ADDL_SHEII_NOTN, _PRODUCT_ADDL_SHEII_SLNO, _PRODUCT_ADDL_SHEII_RATE, _GSI_TOTAL,_PRODUCT_ADDL_GSI_NOTN, _PRODUCT_ADDL_GSI_SLNO
    ,_PRODUCT_ADDL_GSI_RATE, _PRODUCT_ADDL_GSI_SPL, _PRODUCT_ADDL_GSI_UNIT, _PRODUCT_ADDL_GSI_SPL_TYPE,_TTA_TOTAL, _PRODUCT_ADDL_TTA_NOTN, _PRODUCT_ADDL_TTA_SLNO, _PRODUCT_ADDL_TTA_RATE, _PRODUCT_ADDL_TTA_SPL, _PRODUCT_ADDL_TTA_UNIT, _PRODUCT_ADDL_TTA_TYPE
    ,_PRODUCT_NCD_NOTN, _PRODUCT_NCD_SLNO, _PRODUCT_NCD_RATE, _PRODUCT_NCD_SPL, _PRODUCT_NCD_UNIT, _PRODUCT_NCD_SPL_TYPE,_PRODUCT_SAPTA_NOTN, _PRODUCT_SAPTA_SLNO, _PRODUCT_SAPTA_RATE
    ,_PRODUCT_TARIFF_NOTN, _PRODUCT_TARIFF_SLNO, _PRODUCT_TARIFF_QTY, _PRODUCT_TARIFF_AMOUNT, _PRODUCT_TARIFF_AMOUNT_UNIT,_PRODUCT_SAFEGUARD_NOTN, _PRODUCT_SAFEGUARD_SLNO, _PRODUCT_SAFEGUARD_RATE
    ,_PRODUCT_SAFEGUARD_SPL, _PRODUCT_SAFEGUARD_UNIT, _PRODUCT_SAFEGUARD_SPL_TYPE,_PRODUCT_AGGREGATE_DUTY_NOTN, _PRODUCT_AGGREGATE_DUTY_NOTN_SL, _PRODUCT_AGGREGATE_DUTY_NOTN_RATE
    ,_CETH_SPL_AMT,_CTH_SPL_AMT, _TOTAL_DEBIT_DUTY, _MERIT_TOTAL_DEBIT_DUTY, _TOTAL_DEBIT_DUTY_FINAL, _CTH_QTY1, _CTH_QTY1_CODE, _CTH_NCD_D_RATE, _CTH_SAFEGUARD_RATE, _NOTIFICATION_CUSTOMS_BCD_RATE
    , _NOTIFICATION_CUSTOMS_CVD_RATE, _NOTIFICATION_CUSTOMS_BCD_SPL, _NOTIFICATION_CUSTOMS_BCD_UNIT, _CTH_INFRA_CESS_RATE, _CETH_CESS_AMTS, _CETH_CESS_RTA, _CETH_CESS_UQC, _CESS_ROW_VISIBLE, _ENTRY_DEBIT_DUTY, _SAFE_GUARD_TOTAL
    , _PRODUCT_BCD_NOTN_SLNO, _PRODUCT_ADDL_DUTY_NOTN_SLNO, _PRODUCT_SEC_EDU_CESS_NOTN_SLNO, _PRODUCT_EDU_CESS_NOTN_SLNO, _PRODUCT_BCD_SPL,_PRODUCT_BCD_UNIT, _SOCIAL_WELFARE_NOTN, _SOCIAL_WELFARE_NOTN_SLNO, _SOCIAL_WELFARE_RATE
    , _INV_MISC_T_F, _INV_MISC_CURRENCY, _INV_MISC_EXRATE, _INV_MISC_CHARGES, _INV_MISC_TOTAL_CHARGES, _INV_MISC_ADD_FRT_INS_YN, _TOTAL_ANTI_AMT
    , _PRODUCT_ADDL_HEALTH_CESS_NOTN, _PRODUCT_ADDL_HEALTH_CESS_SLNO, _PRODUCT_ADDL_HEALTH_CESS_RATE, _PRODUCT_ADDL_HEALTH_CESS_SPL, _PRODUCT_ADDL_HEALTH_CESS_TYPE, _PRODUCT_ADDL_HEALTH_CESS_UNIT
    , _AIDC_NOTN, _AIDC_NOTN_SLNO, _AIDC_RATE, _AIDC_TOTAL, _EXC_AIDC_NOTN, _EXC_AIDC_NOTN_SLNO, _EXC_AIDC_RATE, _EXC_AIDC_TOTAL, _EXC_AIDC_SPL_AMT, _EXC_AIDC_SPL_UNIT
    , _EXC_AIDC_CHECKLIST_AMT, _CHKLIST_IGST_ASSBL_VAL, _BCD_FOREGONE_AMT, _TOTAL_DUTY_FOREGONE_AMT, _SWS_FOREGONE_AMT
     , _CHECKLIST_NCD_DUTY_AMT, _CHECKLIST_GSI_DUTY_AMT, _CHECKLIST_TTA_DUTY_AMT, _CHECKLIST_AGGREGATE_DUTY_AMT, _CHECKLIST_OTHER_DUTY_AMT, _CHECKLIST_SCHED11_DUTY_AMT, _CHECKLIST_SAFEGUARD_DUTY_AMT, _CHECKLIST_INFRACESS_DUTY_AMT, _CHECKLIST_SAPTA_DUTY_AMT
    , _SAPTA_TOTAL, _Tot_Customs_Duty, _Tot_Excise_Duty, _CETH_ADDL_DUTY_IMPORTS_YN

    , _BASIC_VALUE, _CHECKLIST_SOCIAL_WELFARE_AMT, _CEC_VALUE, _CHEC_VALUE, _AIDC_CHECKLIST_AMT, _CHECKLIST_IGST_LEVY_AMOUNT, _CHECKLIST_COMPENSATION_CC_AMOUNT
    ,_CHECKLIST_ANTI_DUMPING_AMT, _CVD_VALUE, _INDIVITUAL_EDU_CESS_AMT, _INDIVITUAL_SEC_HIGHER_CESS_AMT, _CHECKLIST_ADDL_DUTY_RATE, _CHECKLIST_HEALTH_CESS_AMT, _CHECKLIST_CESS_DUTY_AMT
    //------------------ Seller Details--------------------------//
    , _SELLER_NAME, _SELLER_ADDRESS, _SELLER_ADDRESS1, _SELLER_ADDRESS2, _SELLER_COUNTRY_NAME, _SELLER_COUNTRY_CODE, _SELLERCOUNTRY_PINCODE, _OTHER_PURCHASE_ORDER, _OTHER_PURCHASE_ORDER_DATE, _SVB_DUTY_CALC, _OTHER_LOC_NO, _OTHER_LOC_DATE;

    public string BASIC_VALUE { get { return _BASIC_VALUE; } set { _BASIC_VALUE = value; } }
    public string CHECKLIST_SOCIAL_WELFARE_AMT { get { return _CHECKLIST_SOCIAL_WELFARE_AMT; } set { _CHECKLIST_SOCIAL_WELFARE_AMT = value; } }
    public string CEC_VALUE { get { return _CEC_VALUE; } set { _CEC_VALUE = value; } }
    public string CHEC_VALUE { get { return _CHEC_VALUE; } set { _CHEC_VALUE = value; } }
    public string AIDC_CHECKLIST_AMT { get { return _AIDC_CHECKLIST_AMT; } set { _AIDC_CHECKLIST_AMT = value; } }
    public string CHECKLIST_IGST_LEVY_AMOUNT { get { return _CHECKLIST_IGST_LEVY_AMOUNT; } set { _CHECKLIST_IGST_LEVY_AMOUNT = value; } }
    public string CHECKLIST_COMPENSATION_CC_AMOUNT { get { return _CHECKLIST_COMPENSATION_CC_AMOUNT; } set { _CHECKLIST_COMPENSATION_CC_AMOUNT = value; } }
    public string CHECKLIST_ANTI_DUMPING_AMT { get { return _CHECKLIST_ANTI_DUMPING_AMT; } set { _CHECKLIST_ANTI_DUMPING_AMT = value; } }
    public string CVD_VALUE { get { return _CVD_VALUE; } set { _CVD_VALUE = value; } }
    public string INDIVITUAL_EDU_CESS_AMT { get { return _INDIVITUAL_EDU_CESS_AMT; } set { _INDIVITUAL_EDU_CESS_AMT = value; } }
    public string INDIVITUAL_SEC_HIGHER_CESS_AMT { get { return _INDIVITUAL_SEC_HIGHER_CESS_AMT; } set { _INDIVITUAL_SEC_HIGHER_CESS_AMT = value; } }
    public string CHECKLIST_ADDL_DUTY_RATE { get { return _CHECKLIST_ADDL_DUTY_RATE; } set { _CHECKLIST_ADDL_DUTY_RATE = value; } }
    public string CHECKLIST_HEALTH_CESS_AMT { get { return _CHECKLIST_HEALTH_CESS_AMT; } set { _CHECKLIST_HEALTH_CESS_AMT = value; } }
    public string CHECKLIST_CESS_DUTY_AMT { get { return _CHECKLIST_CESS_DUTY_AMT; } set { _CHECKLIST_CESS_DUTY_AMT = value; } }
    public string CETH_ADDL_DUTY_IMPORTS_YN { get { return _CETH_ADDL_DUTY_IMPORTS_YN; } set { _CETH_ADDL_DUTY_IMPORTS_YN = value; } }
    public string SVB_DUTY_CALC { get { return _SVB_DUTY_CALC; } set { _SVB_DUTY_CALC = value; } }
  

    public string PRODUCT_BCD_NOTN_SLNO { get { return _PRODUCT_BCD_NOTN_SLNO; } set { _PRODUCT_BCD_NOTN_SLNO = value; } }
    public string PRODUCT_BCD_SPL { get { return _PRODUCT_BCD_SPL; } set { _PRODUCT_BCD_SPL = value; } }
    public string PRODUCT_BCD_UNIT { get { return _PRODUCT_BCD_UNIT; } set { _PRODUCT_BCD_UNIT = value; } }
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
    public string TOTAL_ANTI_AMT { get { return _TOTAL_ANTI_AMT; } set { _TOTAL_ANTI_AMT = value; } }

    public string AIDC_NOTN { get { return _AIDC_NOTN; } set { _AIDC_NOTN = value; } }
    public string AIDC_NOTN_SLNO { get { return _AIDC_NOTN_SLNO; } set { _AIDC_NOTN_SLNO = value; } }
    public string AIDC_RATE { get { return _AIDC_RATE; } set { _AIDC_RATE = value; } }
    public string AIDC_TOTAL { get { return _AIDC_TOTAL; } set { _AIDC_TOTAL = value; } }

    public string EXC_AIDC_NOTN { get { return _EXC_AIDC_NOTN; } set { _EXC_AIDC_NOTN = value; } }
    public string EXC_AIDC_NOTN_SLNO { get { return _EXC_AIDC_NOTN_SLNO; } set { _EXC_AIDC_NOTN_SLNO = value; } }
    public string EXC_AIDC_RATE { get { return _EXC_AIDC_RATE; } set { _EXC_AIDC_RATE = value; } }
    public string EXC_AIDC_TOTAL { get { return _EXC_AIDC_TOTAL; } set { _EXC_AIDC_TOTAL = value; } }
    public string EXC_AIDC_SPL_AMT { get { return _EXC_AIDC_SPL_AMT; } set { _EXC_AIDC_SPL_AMT = value; } }
    public string EXC_AIDC_SPL_UNIT { get { return _EXC_AIDC_SPL_UNIT; } set { _EXC_AIDC_SPL_UNIT = value; } }


    public string EXC_AIDC_CHECKLIST_AMT { get { return _EXC_AIDC_CHECKLIST_AMT; } set { _EXC_AIDC_CHECKLIST_AMT = value; } }
    public string CHKLIST_IGST_ASSBL_VAL { get { return _CHKLIST_IGST_ASSBL_VAL; } set { _CHKLIST_IGST_ASSBL_VAL = value; } }
    public string BCD_FOREGONE_AMT { get { return _BCD_FOREGONE_AMT; } set { _BCD_FOREGONE_AMT = value; } }
    public string TOTAL_DUTY_FOREGONE_AMT { get { return _TOTAL_DUTY_FOREGONE_AMT; } set { _TOTAL_DUTY_FOREGONE_AMT = value; } }
    public string SWS_FOREGONE_AMT { get { return _SWS_FOREGONE_AMT; } set { _SWS_FOREGONE_AMT = value; } }
   

    public string SELLER_NAME { get { return _SELLER_NAME; } set { _SELLER_NAME = value; } }
    public string SELLER_ADDRESS { get { return _SELLER_ADDRESS; } set { _SELLER_ADDRESS = value; } }
    public string SELLER_ADDRESS1 { get { return _SELLER_ADDRESS1; } set { _SELLER_ADDRESS1 = value; } }
    public string SELLER_ADDRESS2 { get { return _SELLER_ADDRESS2; } set { _SELLER_ADDRESS2 = value; } }
    public string SELLER_COUNTRY_NAME { get { return _SELLER_COUNTRY_NAME; } set { _SELLER_COUNTRY_NAME = value; } }
    public string SELLER_COUNTRY_CODE { get { return _SELLER_COUNTRY_CODE; } set { _SELLER_COUNTRY_CODE = value; } }
    public string SELLERCOUNTRY_PINCODE { get { return _SELLERCOUNTRY_PINCODE; } set { _SELLERCOUNTRY_PINCODE = value; } }

    public string OTHER_PURCHASE_ORDER { get { return _OTHER_PURCHASE_ORDER; } set { _OTHER_PURCHASE_ORDER = value; } }
    public string OTHER_PURCHASE_ORDER_DATE { get { return _OTHER_PURCHASE_ORDER_DATE; } set { _OTHER_PURCHASE_ORDER_DATE = value; } }
    public string OTHER_LOC_NO { get { return _OTHER_LOC_NO; } set { _OTHER_LOC_NO = value; } }
    public string OTHER_LOC_DATE { get { return _OTHER_LOC_DATE; } set { _OTHER_LOC_DATE = value; } }

    public string TRANSPORT_MODE, MIS_FREIGHT_CHARGES, MIS_FREIGHT_CURRENCY, MIS_FREIGHT_EXRATE, MIS_INSURANCE_CHARGES, MIS_INSURANCE_CURRENCY, MIS_INSURANCE_EXRATE, SVB_ASSESABLE_RATE
   , SVB_DUTY_RATE, MIS_CHARGES, MIS_RATE, MIS_EXRATE, MIS_HIGHSEASALE_RATE, MIS_HIGHSEASALE_CHARGES, MIS_DISCOUNT_RATE, MIS_DISCOUNT_CHARGES, D_AMOUNT, M_AMOUNT, N_AMOUNT, TERMS_PLACE, A_AMOUNT, B_AMOUNT, C_AMOUNT, E_AMOUNT, F_AMOUNT, G_AMOUNT, H_AMOUNT, I_AMOUNT, J_AMOUNT, K_AMOUNT, L_AMOUNT
   , THIRDPARTY_NAME, THIRDPARTY_ADD1, THIRDPARTY_ADD2, THIRDPARTY_CITY, T_PARTY_COUNTRY_SUB_DIV, T_PARTY_COUNTRY_CODE, T_PARTY_PIN, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY
   , AUTHORIZED_ECONOMIC_OPERATOR, WHETHER_BUYER_SELLER_RELATED, MIS_CURRENCY, MIS_LOADING_CHARGES, MIS_LOADING_CURRENCY, MIS_LOADING_EXRATE, MIS_LOADING_RATE, MIS_DISCOUNT_CURRENCY, MIS_DISCOUNT_EXRATE, MIS_AGENCY_RATE, MIS_AGENCY_CHARGES, MIS_AGENCY_CURRENCY, MIS_AGENCY_EXRATE
   , MIS_HIGHSEASALE_CURRENCY, REIMPORT_FREIGHT, REIMPORT_INSURANCE, NOTN_NO, NOTN_SLNO, MIS_HIGHSEASALE_EXRATE, OTHER_NATURE_OF_TRANSACTION
   , ADD_AMT_MINUS_ASSESABLE, ANTI_AMTS, MAX_DIFF, ADD_DIFF_CUR, MERIT_TOTAL_ANTI_AMT = "0"
   , ADD_ANTI_CUR, SCHEME_RATE_NEW, BCD_NOTN, CVD_NOTN, EDU_CESS_NOTN, SEC_EDU_CESS_NOTN, PRODUCT_CVD_EDU_CESS_NOTN_SL, PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL, SCHEME_NOTN_ = "", ITEM_ID;

    public double INVOICE_VALUE_INR, TOTAL_INVOICE_VALUE, REIMPORT_FREIGHT_AMOUNT, REIMPORT_INSURANCE_AMOUNT, MISC_AMOUNT, DISCOUNT_AMOUNT = 0, INVOICE_AMOUNT = 0, INSURANCE_AMOUNT = 0
   , FREIGHT_AMOUNT = 0, INDIVITUAL_INVOICE_VALUE = 0, INDIVITUAL_FREIGHT_AMOUNT = 0, INDIVITUAL_INSURANCE_AMOUNT = 0, INDIVITUAL_MISC_AMOUNT = 0, INDIVITUAL_TOTAL_AMOUNT = 0, INDIVITUAL_HSS_AMOUNT = 0
   , INDIVITUAL_SVB_AMOUNT = 0, INDIVITUAL_CIF_AMOUNT = 0, INDIVITUAL_LANDING_COST = 0, INDIVITUAL_ASSESSABLE_AMOUNT = 0, CHECK_FREIGHT_RATE = 0, CHECK_FREIGHT_EXRATE = 0, LICENSE_DEBIT_AMT = 0
   , TOTAL_ANTIDUMP_AMT = 0, MERIT_TOTAL_ANTIDUMP_AMT = 0, ADD_ANTI_AMTS, EXCHANGE_RATE, ADD_MAX_DIFF

   , INDIVITUAL_DISCOUNT_AMOUNT = 0, BASIC_DUTY, MERIT_BASIC_DUTY, CVD, INFRA_CESS, MERIT_CVD, NCD, CESS, MERIT_CESS, Customs_Edu_Cess, merit_Customs_Edu_Cess, Customs_Higher_Edu_Cess, merit_Customs_Higher_Edu_Cess, AddL_DUTY, merit_AddL_DUTY, TOTAL_DUTY = 0.0, MERIT_TOTAL_DUTY = 0.0, SAFE_GUARD, AGGREGATE_DUTY, _TOTAL_CUSTOMS_DUTY = 0.0, _TOTAL_IGST_DUTY = 0.0
   , MERIT_BASIC_VALUE, MERIT_CVD_VALUE, MERIT_CEC_VALUE, MERIT_CHEC_VALUE, MERIT_ADD_DUTY_VALUE
   , MERIT_NOTN_BASIC_VALUE, MERIT_NOTN_CVD_VALUE, MERIT_NOTN_CEC_VALUE, MERIT_NOTN_CHEC_VALUE, MERIT_NOTN_ADD_DUTY_VALUE, MERIT_NOTN_CESS_VALUE, MERIT_NOTN_NCD_VALUE
   , BASIC_DUTY_BCD_SPL, cvd_Customs_Edu_Cess, cvd_Customs_Higher_Edu_Cess, Other_duty = 0.00
   , Aggregate_cvd, Aggregate_basic_duty, Aggregate_ncd, Aggregate_cess, Aggregate_Customs_Edu_Cess, Aggregate_Customs_Higher_Edu_Cess, Aggregate_AddL_DUTY, Aggregate_safe_guard, Aggregate_SWS
   , MRP_AMT, BCD_FG_AMT = 0, IGST_FG_AMT = 0, SWS_FG_AMT = 0, SAPTA_DUTY = 0, Actual_BASIC_DUTY = 0, LOADING_AMOUNT = 0, INDIVITUAL_LOADING_AMOUNT = 0, LOADING_INSURANCE_AMT = 0, LOADING_FREIGHT_AMT = 0, INDIVITUAL_AGENCY_AMOUNT = 0, AGENCY_AMOUNT = 0, ITEM_INDIVITUAL_SVB_AMOUNT = 0;

    public double merit_social_welfare_cess, social_welfare, SOCIAL_welf_Rate, Customs_Social_welfare, Healthcess_RateVal;
    public string _TOTAL_SOCIAL_WELFARE, _CETH_SIA_I_RATE;
    public string _HEALTH_CESS_CTH_CODE, _HEALTH_CESS_RATE, _HEALTH_CESS_SQC, _HEALTH_CESS_TOTAL, _ADD_EX_RATE;
    public double AIDC_Amt;

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
    public string CETH_SIA_I_RATE { get { return _CETH_SIA_I_RATE; } set { _CETH_SIA_I_RATE = value; } }

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
    public string IGST_LEVY_COMPENSATION_CESS_SPL { get { return _IGST_LEVY_COMPENSATION_CESS_SPL; } set { _IGST_LEVY_COMPENSATION_CESS_SPL = value; } }
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
    public string NOTIFICATION_CUSTOMS_BCD_UNIT { get { return _NOTIFICATION_CUSTOMS_BCD_UNIT; } set { _NOTIFICATION_CUSTOMS_BCD_UNIT = value; } }
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

    public string CHECKLIST_NCD_DUTY_AMT { get { return _CHECKLIST_NCD_DUTY_AMT; } set { _CHECKLIST_NCD_DUTY_AMT = value; } }
    public string CHECKLIST_GSI_DUTY_AMT { get { return _CHECKLIST_GSI_DUTY_AMT; } set { _CHECKLIST_GSI_DUTY_AMT = value; } }
    public string CHECKLIST_TTA_DUTY_AMT { get { return _CHECKLIST_TTA_DUTY_AMT; } set { _CHECKLIST_TTA_DUTY_AMT = value; } }
    public string CHECKLIST_AGGREGATE_DUTY_AMT { get { return _CHECKLIST_AGGREGATE_DUTY_AMT; } set { _CHECKLIST_AGGREGATE_DUTY_AMT = value; } }
    public string CHECKLIST_OTHER_DUTY_AMT { get { return _CHECKLIST_OTHER_DUTY_AMT; } set { _CHECKLIST_OTHER_DUTY_AMT = value; } }
    public string CHECKLIST_SCHED11_DUTY_AMT { get { return _CHECKLIST_SCHED11_DUTY_AMT; } set { _CHECKLIST_SCHED11_DUTY_AMT = value; } }
    public string CHECKLIST_SAFEGUARD_DUTY_AMT { get { return _CHECKLIST_SAFEGUARD_DUTY_AMT; } set { _CHECKLIST_SAFEGUARD_DUTY_AMT = value; } }
    public string CHECKLIST_INFRACESS_DUTY_AMT { get { return _CHECKLIST_INFRACESS_DUTY_AMT; } set { _CHECKLIST_INFRACESS_DUTY_AMT = value; } }
    public string CHECKLIST_SAPTA_DUTY_AMT { get { return _CHECKLIST_SAPTA_DUTY_AMT; } set { _CHECKLIST_SAPTA_DUTY_AMT = value; } }
    public string SAPTA_TOTAL { get { return _SAPTA_TOTAL; } set { _SAPTA_TOTAL = value; } }
    public string Tot_Customs_Duty { get { return _Tot_Customs_Duty; } set { _Tot_Customs_Duty = value; } }
    public string Tot_Excise_Duty { get { return _Tot_Excise_Duty; } set { _Tot_Excise_Duty = value; } }

    
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

    public string INV_MISC_T_F { get { return _INV_MISC_T_F; } set { _INV_MISC_T_F = value; } }
    public string INV_MISC_CURRENCY { get { return _INV_MISC_CURRENCY; } set { _INV_MISC_CURRENCY = value; } }
    public string INV_MISC_EXRATE { get { return _INV_MISC_EXRATE; } set { _INV_MISC_EXRATE = value; } }
    public string INV_MISC_CHARGES { get { return _INV_MISC_CHARGES; } set { _INV_MISC_CHARGES = value; } }
    public string INV_MISC_TOTAL_CHARGES { get { return _INV_MISC_TOTAL_CHARGES; } set { _INV_MISC_TOTAL_CHARGES = value; } }
    public string INV_MISC_ADD_FRT_INS_YN { get { return _INV_MISC_ADD_FRT_INS_YN; } set { _INV_MISC_ADD_FRT_INS_YN = value; } }

    public string HEALTH_CESS_CTH_CODE { get { return _HEALTH_CESS_CTH_CODE; } set { _HEALTH_CESS_CTH_CODE = value; } }
    public string HEALTH_CESS_RATE { get { return _HEALTH_CESS_RATE; } set { _HEALTH_CESS_RATE = value; } }
    public string HEALTH_CESS_SQC { get { return _HEALTH_CESS_SQC; } set { _HEALTH_CESS_SQC = value; } }
    public string HEALTH_CESS_TOTAL { get { return _HEALTH_CESS_TOTAL; } set { _HEALTH_CESS_TOTAL = value; } }
    public string ADD_EX_RATE { get { return _ADD_EX_RATE; } set { _ADD_EX_RATE = value; } }

    public string PRODUCT_ADDL_HEALTH_CESS_NOTN { get { return _PRODUCT_ADDL_HEALTH_CESS_NOTN; } set { _PRODUCT_ADDL_HEALTH_CESS_NOTN = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_SLNO { get { return _PRODUCT_ADDL_HEALTH_CESS_SLNO; } set { _PRODUCT_ADDL_HEALTH_CESS_SLNO = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_RATE { get { return _PRODUCT_ADDL_HEALTH_CESS_RATE; } set { _PRODUCT_ADDL_HEALTH_CESS_RATE = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_SPL { get { return _PRODUCT_ADDL_HEALTH_CESS_SPL; } set { _PRODUCT_ADDL_HEALTH_CESS_SPL = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_TYPE { get { return _PRODUCT_ADDL_HEALTH_CESS_TYPE; } set { _PRODUCT_ADDL_HEALTH_CESS_TYPE = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_UNIT { get { return _PRODUCT_ADDL_HEALTH_CESS_UNIT; } set { _PRODUCT_ADDL_HEALTH_CESS_UNIT = value; } }

    public string CTH_SAFEGUARD_RATE_UPDATE, PRODUCT_AGGREGATE_DUTY_NOTN_RATE_UPDATE, SOCIAL_WELFARE_RATE_UPDATE, PRODUCT_TARIFF_AMOUNT_UPDATE, PRODUCT_ADDL_DUTY_RATE_UPDATE, AIDC_AMT_UPDATE;
    

    //------------------R------------------------------------------
   
   

   //---------------------------------------------------------------------------------------------------------------------- 
    Double DEBIT_AMT = 0.0,DEBIT_QTY = 0.0,SUM_DEBIT_QTY = 0.0,INDI_DEBIT_QTY = 0.0,DEBIT_DUTY = 0.0,SUM_ENTRY_DEBIT_DUTY = 0.0;
    DateTime IGMDate, compareDate_IGM;
    string NOTIFICATION_EXCISE_BCD_RATE = "";
    private string _INVOICE_ID, MIS_CHARGES_Add, INVOICE_EXCHANGERATE;
    double IGST_LEV_1_AMT = 0.00, IGST_LEV_2_Excemption = 0.00, IGST_LEV_1_COMPENSATION_AMT = 0.00, IGST_LEV_2_COMPENSATION_AMT = 0.00, IGST_LEV_1_AMT_ASS = 0.00;

    public string _IGST_LEVY_TOTAL, _IGST_LEVY_TOTAL_DEBIT, _IGST_LEVY_COMPENSATION_CESS_TOTAL, _DUTY_TYPE = "", _ADDL_FLAG = "", ddlJobNo, Igm_DATE, _MIS_CHARGES_
    , SELECT_BRANCH, Check_Stmt = "", LICENSE_ID;

    public string IGST_LEVY_TOTAL{get { return _IGST_LEVY_TOTAL; }set { _IGST_LEVY_TOTAL = value; }}
    public string IGST_LEVY_TOTAL_DEBIT{get { return _IGST_LEVY_TOTAL_DEBIT; }set { _IGST_LEVY_TOTAL_DEBIT = value; }}
    public string IGST_LEVY_COMPENSATION_CESS_TOTAL {get { return _IGST_LEVY_COMPENSATION_CESS_TOTAL; }set { _IGST_LEVY_COMPENSATION_CESS_TOTAL = value; }}

    public string DUTY_TYPE { get { return _DUTY_TYPE; } set { _DUTY_TYPE = value; } }
    public string ADDL_FLAG { get { return _ADDL_FLAG; } set { _ADDL_FLAG = value; } }
    public string MIS_CHARGES_ { get { return _MIS_CHARGES_; } set { _MIS_CHARGES_ = value; } }
    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }

    //********************** GST IMPLEMENTATION 30-JUN-2016 DECLARATIONS END ***********************

    public string _GENEARL_DESCRIPTION, _MANUFACTURER, _BRAND, _MODEL, _CENTRAL_EXCISE_FLAG, _MANUFACTURER_PRODUCER, _M_P_GROWER_CODE, _M_P_GROWER_ADD1, _M_P_GROWER_ADD2,
                _M_P_GROWER_CITY, _M_P_GROWER_COUNTRY_SUBDIV, _M_P_GROWER_PIN, _M_P_GROWER_COUNTRY, _SOURCE_COUNTRY, _TRANSIT_COUNTRY, _ACCESSORY_STATUS;

    public string GENEARL_DESCRIPTION { get { return _GENEARL_DESCRIPTION; } set { _GENEARL_DESCRIPTION = value; } }
    public string MANUFACTURER { get { return _MANUFACTURER; } set { _MANUFACTURER = value; } }
    public string BRAND { get { return _BRAND; } set { _BRAND = value; } }
    public string MODEL { get { return _MODEL; } set { _MODEL = value; } }
    public string CENTRAL_EXCISE_FLAG { get { return _CENTRAL_EXCISE_FLAG; } set { _CENTRAL_EXCISE_FLAG = value; } }
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

    private string _CHECKLIST_BCD_RATE, _CHECKLIST_CVD_RATE;
    public string CHECKLIST_BCD_RATE { get { return _CHECKLIST_BCD_RATE; } set { _CHECKLIST_BCD_RATE = value; } }
    public string CHECKLIST_CVD_RATE { get { return _CHECKLIST_CVD_RATE; } set { _CHECKLIST_CVD_RATE = value; } }

    private string _AIDC_24_27_Exec, _AIDC_EXEC_AMT;
    public string AIDC_24_27_Exec { get { return _AIDC_24_27_Exec; } set { _AIDC_24_27_Exec = value; } }
    public string AIDC_EXEC_AMT { get { return _AIDC_EXEC_AMT; } set { _AIDC_EXEC_AMT = value; } }

    DataSet dss_Coo = new DataSet();
    DataSet dt_All_Rates = new DataSet();
    DataSet ds_Gen = new DataSet();

    public double CHK_IGST_ASSBL_VAL = 0.00, CHK_IGST_LEVY_AMT = 0.00, CHK_IGST_CESS_AMT = 0.00, tot_CHK_IGST_ASSBL_VAL = 0.00, tot_CHK_IGST_LEVY_AMT = 0.00, tot_CHK_IGST_CESS_AMT = 0.00;

    public string NOTIFICATION_FLAG = "", PRODUCT_CETH_CHAPTER = "", IGST_NOTIFICATION_FLAG = "", ADD_AMTS_RPT, CETH_CATEGORY, CETH_IGST_YN,  CETH_CVD_NIL_YN, CIGARATTE_RITC_YN, CETH_EXEC_AIDC_RATE;


    //--------------------------CETH NCD new Implemetation on 07-08-2019 for HPCL Checklist -START-----------------

    public string _CTH_NCD_SPL_DUTY, _CTH_NCD_SPL_UNIT, _CTH_FLAG, _CETH_NCD_RATE = "", _CETH_NCD_SPL_DUTY = "", _CETH_NCD_SPL_UNIT = "", _CETH_FLAG = "";

    public string CTH_NCD_SPL_DUTY { get { return _CTH_NCD_SPL_DUTY; } set { _CTH_NCD_SPL_DUTY = value; } }
    public string CTH_NCD_SPL_UNIT { get { return _CTH_NCD_SPL_UNIT; } set { _CTH_NCD_SPL_UNIT = value; } }
    public string CTH_FLAG { get { return _CTH_FLAG; } set { _CTH_FLAG = value; } }
    public string CETH_NCD_RATE { get { return _CETH_NCD_RATE; } set { _CETH_NCD_RATE = value; } }
    public string CETH_NCD_SPL_DUTY { get { return _CETH_NCD_SPL_DUTY; } set { _CETH_NCD_SPL_DUTY = value; } }
    public string CETH_NCD_SPL_UNIT { get { return _CETH_NCD_SPL_UNIT; } set { _CETH_NCD_SPL_UNIT = value; } }
    public string CETH_FLAG { get { return _CETH_FLAG; } set { _CETH_FLAG = value; } }


    //--------------------------CETH NCD new Implemetation on 07-08-2019 for HPCL Checklist -END -----------------

    List<INVOICE_DETAILS> Load_Invoice_Details = new List<INVOICE_DETAILS>();
    List<Transaction_Default2> Load_Item_Details = new List<Transaction_Default2>();
    List<Transaction_Default2> Load_Item_IGST_Details = new List<Transaction_Default2>();
    List<Transaction_Default2> Load_Item_Manufacturer_Details = new List<Transaction_Default2>();
    List<Transaction_Default2> Load_Item_Total_Duty_Details = new List<Transaction_Default2>();



    DataTable dtt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    string CETH_SIA_I_amt1 = "";
    double CETH_SIA_I_amt = 0.00;
    double CVD_SPL_AMT = 0.00;
    string Company_Lic = "";
    public string COMPANY_ID = "", JOBNO_PS="";
    
    double c_ITEM_QTY = 0.00;
    double c_CTH_SPL_AMT = 0.00;
    double c_PRODUCT_BCD_RATE = 0.00;


    double Scheme_Notn_BCD_Rate = 0.00;
    double Scheme_Notn_BCD_Amt = 0.00;
    double AIDC_Split_Rate = 0.00;
    double AIDC_Split_Amt = 0.00;
    double Scheme_Notn_SWS_Amt = 0.00;

    int sum = 0;
    string INV_TOTAL_ITEM_AMOUNT = "";
    double TOTAL_ITEM_INVOICE_VALUE = 0.00;
    double bcd_sapta_rate_Less_Value = 0.00;
    double TOTAL_HSS_AMOUNT = 0.00;
    double MERIT_BCD_FG_AMT = 0.00;
    double MERIT_IGST_AMT = 0.00;
    double IGST_LEV_1_AMT_ASS_1 = 0.00;
    double IGST_LEV_1_AMT_1 = 0.00;
    double TOTAL_FOC_Item_AMT = 0.00;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ClearAll();

            GV.DataSource = null;
            GV.DataBind();

            AppSession aps = new AppSession();
            aps.checkSession_Subfolder();
            SELECT_BRANCH = Connection.Get_Company_Type();
            Company_Lic = Connection.Company_License().ToLower();
            COMPANY_ID = Connection.COMPANYID();

            if (!IsPostBack)
            {
                DataSet d = new DataSet();
                ddlJob_No.Items.Clear();
                d = IC.GetData(ddlJobNo, "", "Jobno");
                if (d.Tables[0].Rows.Count > 0)
                {
                    ddlJob_No.DataSource = d.Tables[0];
                    ddlJob_No.DataTextField = "JOBNO_PS";
                    ddlJob_No.DataValueField = "JOBNO";
                    ddlJob_No.DataBind();
                }

                ddlJob_No.Items.Insert(0, new ListItem(String.Empty, "Select"));


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

                    if (!string.IsNullOrEmpty(Session["JOBNO_PS"] as string))
                    {
                        JOBNO_PS = Session["JOBNO_PS"].ToString();
                    }
                    else
                    {
                        JOBNO_PS = ddlJob_No.SelectedItem.Text;
                    }


                    if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "1213" || COMPANY_ID == "1532" || COMPANY_ID == "1702" || COMPANY_ID == "2046" || COMPANY_ID == "2059" || COMPANY_ID == "2062" || COMPANY_ID == "2107" || COMPANY_ID == "2118" || COMPANY_ID == "2262" || COMPANY_ID == "2344")
                    {
                        //#Esanchit_EmailsRead - Master to Job
                        Auto_IRN_Insert_from_Esanchit_EmailsRead("Import", ddlJob_No.SelectedValue);// Imp_INMAA4_JOBNO_InvSlNo_ItemSlNo_invoice.pdf format
                    }

                    Page_loaItem_Details();

                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void Load_inc()
    {
        try
        {
            for (int i = 0; i < 1000000; i++)
            {
                //for (int j = 0; j < 1000000; j++)
                //{
                //    for (int k = 0; k < 1000000; k++)
                //    {

                //    }
                //}
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Page_loaItem_Details()
    {
        try
        {
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {
                Date_Time dt = new Date_Time();

                ddlJobNo = Request.QueryString["jobno"].ToString();
                Get_Admin_Master_Codes();
                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();


                DataSet ds_Gen = IC.Get_Imp_ChkList_All_New(ddlJobNo, "", "General");

                GetGeneral(ds_Gen.Tables[0], ds_Gen.Tables[1], ds_Gen.Tables[2]);
                Invoice_Detail(ds_Gen.Tables[4],ds_Gen.Tables[3], ds_Gen.Tables[5], ds_Gen.Tables[6]);
                Item_Details();
                TotalItem__DETAILS();
                RSP_Details(ds_Gen.Tables[3]);
                HSS_Details(ds_Gen.Tables[0]);
                RE_IMPORT_DETAILS(ds_Gen.Tables[6]);
                BOND_DETAILS(ds_Gen.Tables[13]);
                CERTIFICATE_DETAILS(ds_Gen.Tables[14]);
                CONTAINER_DETAILS(ds_Gen.Tables[15]);
                //Commercial_Tax_Details(ds_Gen.Tables[16]);
                Commercial_Tax_Details();
                Exbond_Details(ds_Gen.Tables[0]);
                LICENSE_DETAILS();
                Single_Window(ds_Gen.Tables[7], ds_Gen.Tables[8], ds_Gen.Tables[9], ds_Gen.Tables[10], ds_Gen.Tables[11], ds_Gen.Tables[12]);
                Item_IGST_DETAILS();
                Item_Manufacturer_DETAILS();
                ITEM_Total_Duty_Details();

                DataTable dt_MultipleCHA = new DataTable();

                string IMP_Name = string.Empty, CHA_Lable = string.Empty, CHA_Name = string.Empty, CHA_Signature = string.Empty ;
                if (COMPANY_ID == "1014")
                {
                    IMP_Name =ds_Gen.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    CHA_Lable ="";
                    CHA_Name ="";
                    CHA_Signature = ""; 
                }
                else
                {
                    IMP_Name = HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "");
                    CHA_Lable = "CHA";
                    //CHA_Name =  dt.Replace(HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", ""));--02-11-2021

                    if (Connection.Imp_Multiple_CHA_IcegateID_enable(COMPANY_ID) == "Y")
                    {
                        dt_MultipleCHA = Connection.Get_Multiple_ICE_ID_CHANO_frm_GENERAL_DETAILS(ds_Gen.Tables[0].Rows[0]["ICE_ID"].ToString(), "I");

                        if (dt_MultipleCHA.Rows.Count > 0)
                        {
                            IMP_Name = dt_MultipleCHA.Rows[0]["CHA_NAME"].ToString();
                            CHA_Name = dt_MultipleCHA.Rows[0]["CHA_NAME"].ToString();
                        }
                        else
                        {
                            CHA_Name = dt.Replace(Connection.Get_IMP_CHA_NAME().Replace("amp;", ""));
                        }
                    }
                    else
                    {
                        CHA_Name = dt.Replace(Connection.Get_IMP_CHA_NAME().Replace("amp;", ""));
                    }
                  
                    if (COMPANY_ID == "517")
                    {
                        CHA_Signature = Environment.NewLine + "R.DEVANANTH" + Environment.NewLine + "P.A.HOLDER" + Environment.NewLine + "CARD NO:34/2021";
                    }
                    else
                    {
                        CHA_Signature = "Signature";
                    }
                }

                ReportParameter param; // Condition added by pandiyan on 21-05-2025

                if (COMPANY_ID == "2266" &&(Connection.Current_User_Upper() == "ASHAPURA7" || Connection.Current_User_Upper() == "ASHAPURA8" || Connection.Current_User_Upper() == "ASHAPURA9" || Connection.Current_User_Upper() == "ASHAPURA10"))
                {
                    param = new ReportParameter("Title", CHA_Name);
                }
                else
                {
                    param = new ReportParameter("Title", IMP_Name);
                }
                ReportParameter param1 = new ReportParameter("SubTitle", "CHECK LIST - BILL OF ENTRY FOR "+BETYPE + KACHHA_BE);
                ReportParameter param3 = new ReportParameter("PrintDate", dt.Today_Date());
                ReportParameter param4 = new ReportParameter("TodayDate", dt.Today_Date());
                ReportParameter param5 = new ReportParameter("Jobno", ddlJob_No.SelectedItem.Text);

                string CHA_NO = string.Empty, CHA_NAME = string.Empty, CHA_ADDRESS = string.Empty, CHA_ADDRESS1 = string.Empty, CHA_ADDRESS2 = string.Empty, CHA_ADDRESS3 = string.Empty;
                if (Connection.Imp_Multiple_CHA_IcegateID_enable(COMPANY_ID) == "Y")
                {
                    if (dt_MultipleCHA.Rows.Count > 0)
                    {
                        CHA_NO = dt_MultipleCHA.Rows[0]["CHA_NO"].ToString();
                        CHA_Name = dt_MultipleCHA.Rows[0]["CHA_NAME"].ToString();
                        CHA_ADDRESS = dt_MultipleCHA.Rows[0]["CHA_ADDRESS"].ToString();
                        CHA_ADDRESS1 = dt_MultipleCHA.Rows[0]["CHA_ADDRESS1"].ToString();
                        CHA_ADDRESS2 = dt_MultipleCHA.Rows[0]["CHA_ADDRESS2"].ToString();
                        CHA_ADDRESS3 = dt_MultipleCHA.Rows[0]["CHA_ADDRESS3"].ToString();
                       
                    }
                    else
                    {
                        CHA_NO = Connection.Get_IMP_CHA_NO();
                        //CHA_NAME = Connection.Get_IMP_CHA_NAME();
                        CHA_ADDRESS = Connection.Get_IMP_CHA_ADDRESS();
                        CHA_ADDRESS1 = Connection.Get_IMP_CHA_ADDRESS1();
                        CHA_ADDRESS2 = Connection.Get_IMP_CHA_ADDRESS2();
                        CHA_ADDRESS3 = Connection.Get_IMP_CHA_ADDRESS3();
                    }
                }
                else if (COMPANY_ID == "2529")
                {
                    CHA_NO = "";
                    CHA_Name = "";
                    CHA_ADDRESS = "";
                    CHA_ADDRESS1 = "";
                    CHA_ADDRESS2 = "";
                    CHA_ADDRESS3 = "";
                }
                else
                {
                    if (BE_TYPE == "SEZ FTA-Z" || BE_TYPE == "SEZ DTA-T" || BE_TYPE == "SEZ DTA-M"
                                           || BE_TYPE == "Jobbing" || BE_TYPE == "Repair & Return" || BE_TYPE == "Exhibition" || BE_TYPE == "Destruction" || BE_TYPE == "Movement of Goods")
                    {
                        if (ds_Gen.Tables[17].Rows.Count > 0)
                        {
                            if (Connection.COMPANYID() == "2650" && (Connection.Current_User_Upper() == "CAPIMPORT" || Connection.Current_User_Upper() == "CAPEXPORT" || Connection.Current_User_Upper() == "SRIVALLIMPORT" || Connection.Current_User_Upper() == "SRIVALLIEXPORT" || Connection.Current_User_Upper() == "SUNIMPEX"))
                            {
                                CHA_NO = Connection.Get_IMP_CHA_NO();
                            }
                            else if (Connection.COMPANYID() == "2659" && Connection.Current_User_Upper() == "MILINDCIRCLE")
                            {
                                CHA_NO = Connection.Get_IMP_CHA_NO();
                            }
                            else
                            {
                                if (ds_Gen.Tables[17].Rows[0]["SEZ_ICEGATE_ID"].ToString() != "")
                                {
                                    CHA_NO = ds_Gen.Tables[17].Rows[0]["SEZ_PAN_NO"].ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        CHA_NO = Connection.Get_IMP_CHA_NO();
                    }
                    CHA_ADDRESS = Connection.Get_IMP_CHA_ADDRESS();
                    CHA_ADDRESS1 = Connection.Get_IMP_CHA_ADDRESS1();
                    CHA_ADDRESS2 = Connection.Get_IMP_CHA_ADDRESS2();
                    CHA_ADDRESS3 = Connection.Get_IMP_CHA_ADDRESS3();
                }
               
                ReportParameter param6 = new ReportParameter("CHA_NO", dt.Replace(CHA_NO));
                ReportParameter param7 = new ReportParameter("CHA_NAME", CHA_Name);
                ReportParameter param8 = new ReportParameter("CHA_ADDRESS", dt.Replace(CHA_ADDRESS));
                ReportParameter param9 = new ReportParameter("CHA_ADDRESS1", dt.Replace(CHA_ADDRESS1));
                ReportParameter param10 = new ReportParameter("CHA_ADDRESS2", dt.Replace(CHA_ADDRESS2));
                ReportParameter param11 = new ReportParameter("CHA_ADDRESS3", dt.Replace(CHA_ADDRESS3));

                ReportParameter param12 = new ReportParameter("BE_NO_DATE", BE_NO_DATE);

                ReportParameter param13 = new ReportParameter("CHA_Lable", CHA_Lable);
                ReportParameter param14 = new ReportParameter("CHA_Signature", CHA_Signature);
                
                string AEO_regn_no = "", AEO_regn_no_heading = "", AEO_Role = "", AEO_Role_heading = "";

                if (COMPANY_ID == "333")
                {
                    AEO_regn_no = ":INAAJCC4858N0F259";
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "438")
                {
                    AEO_regn_no = ":INAAXCS0682E0F249";
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "747")
                {
                    AEO_regn_no = ":INAAACL3717A0F191";
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "752")
                {
                    if (Connection.Get_IMP_CHA_NO() == "AAACR6636ACH001")
                    {
                        AEO_regn_no = ":INAAACR6636A0F266";
                        AEO_Role = ":AEO-LO";
                        AEO_regn_no_heading = "AEO Regn.No";
                        AEO_Role_heading = "AEO Role";
                    }
                }
                else if (COMPANY_ID == "601")
                {
                    AEO_regn_no = ":INAGXPP7136M0F180";
                    AEO_Role = ":AEO-Customs Clearance";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "665")
                {
                    AEO_regn_no = ":INAAACD6487H0F185";
                    AEO_Role = ":AEO-Customs Clearance";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "824" || COMPANY_ID == "829")
                {
                    AEO_regn_no = ":INAABCP5904G0F211";
                    AEO_Role = ":CUSTOMS";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "917")
                {
                    AEO_regn_no = ":INAAFCT9874P0F201";
                    AEO_Role = ":CONSOL";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "1055")
                {
                    AEO_regn_no = ":INAARFS2091N0F189";
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "1144")
                {
                    AEO_regn_no = ":INAAACR0251M0F237";
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "1159")
                {
                    AEO_regn_no = ":INAABCS2390D0F262";
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "1160")
                {
                    AEO_regn_no = ":INAABCS2390D0F192"; 
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                
                else if (COMPANY_ID == "1686")
                {
                    AEO_regn_no = ":INAJRPS0647P0F226";
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "1207")
                {
                    AEO_regn_no = ":INAADCV4797M0F233";
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "1273")
                {
                    AEO_regn_no = ":INBEDPS4188D0F243";
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else if (COMPANY_ID == "3099")
                {
                    AEO_regn_no = ":INAAAFE9163GOF254";
                    AEO_Role = ":AEO-LO";
                    AEO_regn_no_heading = "AEO Regn.No";
                    AEO_Role_heading = "AEO Role";
                }
                else
                {
                    AEO_regn_no_heading = "UCR Number";
                    AEO_Role_heading = "UCR Type";
                    AEO_regn_no = ": ";
                    AEO_Role = ": ";
                    
                }

                ReportParameter param15 = new ReportParameter("AEO_regn_no", AEO_regn_no);
                ReportParameter param16 = new ReportParameter("AEO_regn_heading", AEO_regn_no_heading);
                ReportParameter param17 = new ReportParameter("AEO_Role", AEO_Role);
                ReportParameter param18 = new ReportParameter("AEO_Role_heading", AEO_Role_heading);

                string Seller_Y_N = "";
                if (Connection.Get_User_Imp_Settings_Job_Edit("CHKLIST_SELLER") == "E")
                {
                    Seller_Y_N = "Seller Details";
                }

                ReportParameter param19 = new ReportParameter("Seller_Y_N", Seller_Y_N);
                
                //#Item Total Assbl Value & Duty
                string Tot_Assbl_Val = "", Tot_Duty_Val = "", PO_Number_YN = "", LC_Number_YN = "";
                if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "1057")//Trans Global
                {
                    DataSet dss_Total = new DataSet();
                    dss_Total = IC.GetData_ChkListNew(ddlJobNo, "", "Item_Total_Value");
                    Tot_Assbl_Val = String.Format("{0:0.00}", dss_Total.Tables[0].Rows[0]["Tot_ASSESSABLE_VALUE"].ToString());
                    Tot_Duty_Val = String.Format("{0:0.00}", Convert.ToInt64(dss_Total.Tables[0].Rows[0]["Tot_DUTY_VALUE"]));
                }

                if (COMPANY_ID == "1057" || COMPANY_ID == "1686" || COMPANY_ID == "2190" || COMPANY_ID == "2238" || COMPANY_ID == "3137")
                {
                    PO_Number_YN = "Y";
                }
                if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "917" || COMPANY_ID == "2190")
                {
                    LC_Number_YN = "Y";
                }

                ReportParameter param20 = new ReportParameter("Tot_Assbl_Val1", Tot_Assbl_Val);
                ReportParameter param21 = new ReportParameter("Tot_Duty_Val1", Tot_Duty_Val);
                ReportParameter param22 = new ReportParameter("PO_Number_YN", PO_Number_YN);
                ReportParameter param23 = new ReportParameter("LC_Number_YN", LC_Number_YN);
                //----------------------Added by pandiyan on 09-09-2026 ----------------------------------
                decimal itemTotalSum = 0m;
                decimal revenueDepositSum = 0m;

                foreach (var item in Load_Item_Details)
                {
                    decimal itemTotal = Convert.ToDecimal(item.ITEM_TOTAL);
                    decimal assessableValue = Convert.ToDecimal(item.ASSESABLE_VALUE);
                    string revenueDepositOn = item.REVENUEDEPOSIT_ON;
                    decimal revenueDepositRate = Convert.ToDecimal(item.REVENUEDEPOSIT_RATE);

                    itemTotalSum += itemTotal;

                    switch (revenueDepositOn)
                    {
                        case "D":
                            revenueDepositSum += itemTotal * revenueDepositRate;
                            break;
                        case "A":
                            revenueDepositSum += assessableValue * revenueDepositRate;
                            break;
                        case "B":
                            revenueDepositSum += (itemTotal + assessableValue) * revenueDepositRate;
                            break;
                    }
                }

                decimal revenueDeposit = Math.Round(revenueDepositSum / 100, 1);
                decimal dutyVal = Math.Round(itemTotalSum, 2) + revenueDeposit;

                ReportParameter param24;
                try
                {
                    DataSet DssConvNo = IC.Get_Number_to_Words(Convert.ToInt64(Math.Round(dutyVal, MidpointRounding.AwayFromZero)).ToString());

                    if (DssConvNo != null && DssConvNo.Tables.Count > 0 && DssConvNo.Tables[0].Rows.Count > 0)
                    {
                        string words = DssConvNo.Tables[0].Rows[0][0].ToString();
                        param24 = new ReportParameter("Tot_Duty_Val_Words", words);
                    }
                    else
                    {
                        param24 = new ReportParameter("Tot_Duty_Val_Words", "");
                    }
                }
                catch (Exception ex)
                {
                    param24 = new ReportParameter("Tot_Duty_Val_Words", "");
                    Connection.Error_Msg(ex.Message);
                }
                //--------------------------------end-----------------------------
                ReportParameter[] p = { param, param1, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16, param17, param18, param19, param20, param21, param22, param23,param24};
                ReportViewer1.LocalReport.SetParameters(p);
               
                ReportViewer1.LocalReport.DisplayName = "Imp Checklist "+ddlJob_No.SelectedItem.Text;

                //--------------------------------------To Print------------------------------------------------------------------------------------//
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty,encoding = string.Empty,extension = string.Empty;
                byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Session.Remove("report");
                Session["report"] = bytes;
                //---------To Print--------Skylift and Airlift On 21Sep2015-----------------------------//
                string CID = COMPANY_ID.ToString();
                if (CID == "164" || CID == "165" || CID == "752" )
                {
                    string  errorFolder = Server.MapPath("~/Submission/" + CID + "/" + Connection.Current_Branch() + "/" + "IMP_Job_history" + "/");
                    if (Directory.Exists(errorFolder) == false)
                    {
                        Directory.CreateDirectory(errorFolder);
                    }
                    File.WriteAllBytes(errorFolder + ddlJobNo + " ~~" + ddlJobNo + ".pdf", bytes);
                    IC.Upload_JobHistory(ddlJobNo, errorFolder, CID ,SELECT_BRANCH);
                }
                //-----------------Skylift and Airlift On 21Sep2015-----------------------------//
            }
        }
        catch (System.OutOfMemoryException ex)
        {
            Connection.Error_Msg(ex.Message);
            btn_checklist_Value_Update.Visible = false;
        }
        //catch (Exception ex)
        //{
        //    Connection.Error_Msg(ex.Message);
        //    btn_checklist_Value_Update.Visible = false;
        //}
    }

    public void GetGeneral(DataTable ds_Gen, DataTable Be_Entry, DataTable ds_IGM)
    {
        try
        {
            Date_Time dt = new Date_Time();

            General_Details Import_General = new General_Details();
            ReportDataSource dataSource1 = new ReportDataSource("GENERAL_DETAILS", Import_General.GetGeneral1(ds_Gen, ddlJobNo));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
            BE_NO = Import_General.BE_NO;
            if (ds_Gen.Rows.Count > 0)
            {
                PORT_ORIGIN = dt.Split("-", ds_Gen.Rows[0]["PORT_ORIGIN"].ToString());
                PORT_SHIPMENT = dt.Split("-", ds_Gen.Rows[0]["PORT_SHIPMENT"].ToString());
                COUNTRY_OF_ORIGIN = dt.Split("-", ds_Gen.Rows[0]["COUNTRY_ORIGIN"].ToString());
                Country_Shipment = dt.Split("-", ds_Gen.Rows[0]["COUNTRY_SHIPMENT"].ToString());
                TRANSPORT_MODE = ds_Gen.Rows[0]["TRANSPORT_MODE"].ToString();
                FILING_STATUS = ds_Gen.Rows[0]["FILING_STATUS"].ToString();
                KACHHA_BE = ds_Gen.Rows[0]["KACHHA_BE"].ToString();
                SVB_STATUS = ds_Gen.Rows[0]["SVB_ASSESABLE_STATUS"].ToString();

                BE_TYPE = ds_Gen.Rows[0]["BE_TYPE"].ToString();
                BE_TYPE_New = ds_Gen.Rows[0]["BE_TYPE_New"].ToString();
                EXBOND_ADDL_LOAD_HSS = ds_Gen.Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString();
                EXBOND_MISC_LOAD_RATE = ds_Gen.Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString();

                BETYPE = ds_Gen.Rows[0]["BE_TYPE_Desc"].ToString();

            }
            if (Be_Entry.Rows.Count > 0)
            {
                BE_NO_DATE = Be_Entry.Rows[0]["BE_NO_DATE"].ToString();
            }
            else
            {
                BE_NO_DATE = "";
            }

            //IGM_DETAILS

            IGM_Details IGM = new IGM_Details();
            ReportDataSource dataSource = new ReportDataSource("IGM_DETAILS", IGM.Get_IGM_Details(ddlJobNo, ds_Gen, ds_IGM));
            ReportViewer1.LocalReport.DataSources.Add(dataSource);

            if (ds_IGM.Rows.Count > 0)
            {
                Igm_DATE = ds_IGM.Rows[0]["IGM_DATE"].ToString().Replace("01/01/1900", "");
                if (Igm_DATE != "")
                {
                    IGMDate = Convert.ToDateTime(Igm_DATE);
                }
            }
            else
            {
                Igm_DATE = "";
            }

            ds_IGM.Dispose();
            GC.Collect();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    public void Invoice_Detail(DataTable dt_Invoice,DataTable ds_Item,DataTable License , DataTable ReImport)
    {
        try
        {
            Load_Invoice_Details.Clear();

            Get_ITEM_Details_new(ddlJobNo, dt_Invoice, ds_Item, License, ReImport);

            ReportDataSource dataSource = new ReportDataSource("INVOICE_DETAILS", Load_Invoice_Details);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Item_Details()
    {
        try
        {
            ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void ReportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("ITEM", Load_Item_Details);
            e.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void TotalItem__DETAILS()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("ITEM", Load_Item_Details);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Item_IGST_DETAILS()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("DataSet1", Load_Item_IGST_Details);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Item_Manufacturer_DETAILS()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("DataSet4", Load_Item_Manufacturer_Details);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void BOND_DETAILS(DataTable dt_Bond)
    {
        try
        {
            Bond_Details BOND = new Bond_Details();
            ReportDataSource dataSource1 = new ReportDataSource("BOND_DETAILS", BOND.Get_Bond_Details(dt_Bond));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
            dt_Bond.Dispose();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void CERTIFICATE_DETAILS(DataTable dt_Cert)
    {
        try
        {
            Certificate_Details CERTIFICATE = new Certificate_Details();
            ReportDataSource dataSource1 = new ReportDataSource("CERTIFICATE_DETAILS", CERTIFICATE.Get_CERTIFICATE_DETAILS(dt_Cert));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
            dt_Cert.Dispose();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void RSP_Details(DataTable dt_Item_RSP)
    {
        try
        {
            RSP_Details RSP = new RSP_Details();
            DataTable dt_RSP = new DataTable();
            var FullName1 = from DataRow drr in dt_Item_RSP.AsEnumerable()
                            where drr.Field<string>("RSP_APPLICABLE") == "S"
                            select drr;
            DataView dvv = FullName1.AsDataView();

            if (dvv.Count > 0)
            {
                dt_RSP = FullName1.CopyToDataTable();
            }

            ReportDataSource dataSource1 = new ReportDataSource("DataSet3", RSP.Get_RSP_DETAILS(dt_RSP));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void CONTAINER_DETAILS(DataTable dt_CONT)
    {
        try
        {
            Container_Details CONTAINER = new Container_Details();
            ReportDataSource dataSource1 = new ReportDataSource("CONTAINER_DETAILS", CONTAINER.Get_CONTAINER_DETAILS(dt_CONT));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);

            dt_CONT.Dispose();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    public void RE_IMPORT_DETAILS(DataTable dt_ReImp)
    {
        try
        {
            Re_Import_Details RE_IMPORT = new Re_Import_Details();
            ReportDataSource dataSource1 = new ReportDataSource("REIMPORT_DETAILS", RE_IMPORT.Get_RE_IMPORT_DETAILS(dt_ReImp));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void ITEM_Total_Duty_Details()
    {
        try
        {
            ReportDataSource dataSource1 = new ReportDataSource("Item_Total_Duty_Details", Load_Item_Total_Duty_Details);
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Single_Window(DataTable dt_Info, DataTable dt_Constitute, DataTable dt_Production, DataTable dt_Control, DataTable dt_Stmt, DataTable dt_SupDoc)
    {
        try
        {
            Single_Window_details SW_Details = new Single_Window_details();
            ReportDataSource dataSource1 = new ReportDataSource("SW_ITEM_INFO_TYPE", SW_Details.Get_Single_Window_details_INFOTYPE(dt_Info));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);

            ReportDataSource dataSource2 = new ReportDataSource("SW_ITEM_CONSTITUENT_DETAILS", SW_Details.Get_Single_Window_details_Constituent(dt_Constitute));
            ReportViewer1.LocalReport.DataSources.Add(dataSource2);

            ReportDataSource dataSource3 = new ReportDataSource("SW_ITEM_PRODUCTION_DETAILS", SW_Details.Get_Single_Window_details_PRODUCTION(dt_Production));
            ReportViewer1.LocalReport.DataSources.Add(dataSource3);

            ReportDataSource dataSource4 = new ReportDataSource("SW_ITEM_CONTROL_DETAILS", SW_Details.Get_Single_Window_details_CONTROL(dt_Control));
            ReportViewer1.LocalReport.DataSources.Add(dataSource4);

            Session["Check_Stmt"] = Check_Stmt;
            ReportDataSource dataSource5 = new ReportDataSource("SW_ITEM_STATEMENT_DETAILS", SW_Details.Get_Single_Window_details_STATEMENT(dt_Stmt));
            ReportViewer1.LocalReport.DataSources.Add(dataSource5);


            //--------------------------------------------------- IMPORT SUPPORTING DOCUMENTS DETAILS -----------------------------------------------
            //------------ Get Distinct SUPDOC Codes Here ----------------------
            DataView dv_SUPDOC = new DataView(dt_SupDoc);
            DataTable dt_SUPDOC_New = dv_SUPDOC.ToTable(true, "DOC_TYPE_CODE");

            string str_codes = "";
            for (int i = 0; i <= dt_SUPDOC_New.Rows.Count - 1; i++)
            {
                str_codes += dt_SUPDOC_New.Rows[i][0].ToString() + ",";
            }

            //------------ Get  SUPDOC Codes with Desc from Admin Master Here ----------------------
            DataTable dt_result = Bind_Doc_Type_Desc(str_codes);

            if (dt_result.Rows.Count > 0)
            {
                for (int i = 0; i <= dt_SUPDOC_New.Rows.Count - 1; i++)
                {
                    var query = from t in dt_result.AsEnumerable()
                                where t.Field<string>("DOC_CODE").Equals(dt_SUPDOC_New.Rows[i][0].ToString())
                                select t;
                    int doc_cnt = query.Count();
                    if (doc_cnt > 0)
                    {
                        DataTable dddd = query.CopyToDataTable();

                        //------------ Update SUPDOC Codes with Desc to Datatable ----------------------
                        var rowsToUpdate = dt_SupDoc.AsEnumerable().Where(r => r.Field<string>("DOC_TYPE_CODE") == dt_SUPDOC_New.Rows[i][0].ToString());

                        foreach (var row in rowsToUpdate)
                        {
                            if (dddd.Rows.Count > 0)
                            {
                                if (row.Field<string>("DOC_TYPE_CODE") == dt_SUPDOC_New.Rows[i][0].ToString())
                                    row.SetField("DOC_TYPE_CODE", dddd.Rows[0][0].ToString() + "-" + dddd.Rows[0][1].ToString());
                            }
                        }
                    }
                }
            }

            ReportDataSource dataSource6 = new ReportDataSource("DataSet2", SW_Details.Get_Single_Window_details_SUP_DOC(dt_SupDoc));
            ReportViewer1.LocalReport.DataSources.Add(dataSource6);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void LICENSE_DETAILS()
    {
        try
        {
            Transaction Transact = new Transaction();
            //-------------Get Update Debit Amount in License Details Table--------------------//
            Transact.JOBNO = ddlJobNo;
            Transact.INVOICE_SLNO = Convert.ToString(INVOICE_SLNO);
            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.LICENSE_ID = "";
            Transact.WORKING_PERIOD = SELECT_BRANCH;

            Transact.Ename = "Get_Update_Debitamt_License_Details";
            DataSet ds_License = new DataSet();
            ds_License = Transact.RetrieveAll_License_Details();

            //------------End License_Details-----------------------------------------------//
            License_Details LICENSE = new License_Details();
            ReportDataSource dataSource1 = new ReportDataSource("LICENSE_DETAILS", LICENSE.Get_LICENCE_DETAILS(ds_License.Tables[0], TOTAL_DEBIT_DUTY_FINAL));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void HSS_Details(DataTable ds_Gen)
    {
        try
        {
            HSS_Details HSS = new HSS_Details();
            ReportDataSource dataSource1 = new ReportDataSource("HSS_DETAILS", HSS.Get_HSS_Details(ds_Gen));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
  
    /*
    public void Commercial_Tax_Details(DataTable dt_IGST)
    {
        Commercial_Tax_Details Commercial_Tax = new Commercial_Tax_Details();
        ReportDataSource dataSource1 = new ReportDataSource("COMMERCIAL_TAX_DETAILS", Commercial_Tax.Get_Commercial_Tax_Details(dt_IGST, Convert.ToString(tot_CHK_IGST_LEVY_AMT)));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }
    */

    public void Commercial_Tax_Details()
    {
        try
        {
            DataSet ds_IGST = new DataSet();
            ds_IGST.Clear();
            ds_IGST = IC.GetData_ChkListNew(ddlJobNo, "", "IGST_DETAILS");

            Commercial_Tax_Details Commercial_Tax = new Commercial_Tax_Details();
            ReportDataSource dataSource1 = new ReportDataSource("COMMERCIAL_TAX_DETAILS", Commercial_Tax.Get_Commercial_Tax_Details(ds_IGST.Tables[0], Convert.ToString(tot_CHK_IGST_LEVY_AMT)));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Exbond_Details(DataTable ds_Gen)
    {
        try
        {
            Exbond_Details Exbond = new Exbond_Details();
            ReportDataSource dataSource1 = new ReportDataSource("EXBOND_DETAILS", Exbond.Get_Exbond_Details(ds_Gen));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public string Return_ExRate_Value(string currency, string ExRate)
    {
        try
        {
            if (ExRate == "")
            {
                ExRate = "0.00";
            }
            else if (currency == "INR")
            {
                ExRate = "1";
            }
            else if (currency == "JPY" || currency == "KRW")
            {
                ExRate = Convert.ToString(Convert.ToDouble(ExRate) / 100);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return ExRate;
    }

    public void Get_Invoice_Details(string ddlJobNo, DataRow row, int count, double TOTAL_FOC_Item_AMT)
    {
        try
        {
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
            //MIS_EXRATE = Return_Zero_Value(row["MIS_EXRATE"].ToString());--this condition hide on 28-09-2020 for Agility JPY conversion issue 

            INV_MISC_T_F = Return_Zero_Value(row["INV_MISC_T_F"].ToString());
            string str_TOTAL_FOC_Item_AMT = Convert.ToString(TOTAL_FOC_Item_AMT);

            double INV_MISC_CHARGES_CONVERT_INV = 0.00;
            double INV_MISC_CHARGES_CONVERT_fc = 0.00;
            double final_INV_MISC_CHARGES = 0.00;

            if (INVOICE_DATE == "01/01/1900" || INVOICE_DATE == "01-01-1900")
                INVOICE_DATE = "";

            Invoice_value = INVOICE_VALUE + " " + INVOICE_CURRENCY;
            //----------------------------------------------------------------------------------------------------------------//

            double mis_fri_charge = 0.00;
            double mis_insu_charge = 0.00;
            string str_TOTAL_HSS_AMOUNT = "";
            //Condition added by pandiyan on 16-07-2025 sugg by bala 
            if (MIS_HIGHSEASALE_RATE != "" && MIS_HIGHSEASALE_RATE != "0.00" && MIS_HIGHSEASALE_RATE != "0" && (HttpContext.Current.Session["COMPANY_ID"].ToString() == "1644" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "951"))
            {
                str_TOTAL_HSS_AMOUNT = "";
            }
            else
            {
                str_TOTAL_HSS_AMOUNT = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_HSS_AMOUNT), 2));
            }

            //if (TERMS == "CI")
            //{
            //    MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES) /  Convert.ToDouble(INVOICE_EXRATE));               
            //    MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MIS_CHARGES) + Convert.ToDouble(D_AMOUNT) + +Convert.ToDouble(M_AMOUNT) + Convert.ToDouble(N_AMOUNT),2));
            //    MIS_CURRENCY = INVOICE_CURRENCY;
            //    MIS_EXRATE = INVOICE_EXRATE;
            //}

            //************ CI Terms display in CHECKLIST ******************** 03/01/2018 

            //if (TERMS == "CI")
            //{
            //    if (MIS_CHARGES == "" || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
            //    {
            //        if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
            //        {
            //            MIS_CURRENCY = INVOICE_CURRENCY;
            //            MIS_EXRATE = INVOICE_EXRATE;
            //            MIS_CHARGES = Convert.ToString(Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
            //        }
            //        else
            //        {
            //            MIS_CURRENCY = "";
            //            MIS_CHARGES = "";
            //        }
            //    }
            //    else
            //    {
            //        if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
            //        {
            //            if (MIS_CURRENCY == INVOICE_CURRENCY)
            //            {
            //                MIS_CURRENCY = INVOICE_CURRENCY;
            //                MIS_EXRATE = INVOICE_EXRATE;
            //                MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
            //            }
            //            else
            //            {
            //                double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
            //                MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
            //                MIS_CURRENCY = INVOICE_CURRENCY;
            //                MIS_EXRATE = INVOICE_EXRATE;
            //                MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
            //            }
            //        }
            //        else
            //        {
            //            MIS_CURRENCY = MIS_CURRENCY;
            //            MIS_CHARGES = MIS_CHARGES;
            //        }
            //    }
            //}
            // Modified by shanthini on 07-08-2026 & suggest by bala sir - widened D/M/N to full A-N amount range, and now applies for ALL TERMS (not just "CI")

            {
                bool isAnyAmount_AtoN = (A_AMOUNT != "" && A_AMOUNT != "0" && A_AMOUNT != "0.00") ||
                                        (B_AMOUNT != "" && B_AMOUNT != "0" && B_AMOUNT != "0.00") ||
                                        (C_AMOUNT != "" && C_AMOUNT != "0" && C_AMOUNT != "0.00") ||
                                        (D_AMOUNT != "" && D_AMOUNT != "0" && D_AMOUNT != "0.00") ||
                                        (E_AMOUNT != "" && E_AMOUNT != "0" && E_AMOUNT != "0.00") ||
                                        (F_AMOUNT != "" && F_AMOUNT != "0" && F_AMOUNT != "0.00") ||
                                        (G_AMOUNT != "" && G_AMOUNT != "0" && G_AMOUNT != "0.00") ||
                                        (H_AMOUNT != "" && H_AMOUNT != "0" && H_AMOUNT != "0.00") ||
                                        (I_AMOUNT != "" && I_AMOUNT != "0" && I_AMOUNT != "0.00") ||
                                        (J_AMOUNT != "" && J_AMOUNT != "0" && J_AMOUNT != "0.00") ||
                                        (K_AMOUNT != "" && K_AMOUNT != "0" && K_AMOUNT != "0.00") ||
                                        (L_AMOUNT != "" && L_AMOUNT != "0" && L_AMOUNT != "0.00") ||
                                        (M_AMOUNT != "" && M_AMOUNT != "0" && M_AMOUNT != "0.00") ||
                                        (N_AMOUNT != "" && N_AMOUNT != "0" && N_AMOUNT != "0.00");

                double sumAtoN_1 = Convert.ToDouble(A_AMOUNT == "" ? "0" : A_AMOUNT)
                                 + Convert.ToDouble(B_AMOUNT == "" ? "0" : B_AMOUNT)
                                 + Convert.ToDouble(C_AMOUNT == "" ? "0" : C_AMOUNT)
                                 + Convert.ToDouble(D_AMOUNT == "" ? "0" : D_AMOUNT)
                                 + Convert.ToDouble(E_AMOUNT == "" ? "0" : E_AMOUNT)
                                 + Convert.ToDouble(F_AMOUNT == "" ? "0" : F_AMOUNT)
                                 + Convert.ToDouble(G_AMOUNT == "" ? "0" : G_AMOUNT)
                                 + Convert.ToDouble(H_AMOUNT == "" ? "0" : H_AMOUNT)
                                 + Convert.ToDouble(I_AMOUNT == "" ? "0" : I_AMOUNT)
                                 + Convert.ToDouble(J_AMOUNT == "" ? "0" : J_AMOUNT)
                                 + Convert.ToDouble(K_AMOUNT == "" ? "0" : K_AMOUNT)
                                 + Convert.ToDouble(L_AMOUNT == "" ? "0" : L_AMOUNT)
                                 + Convert.ToDouble(M_AMOUNT == "" ? "0" : M_AMOUNT)
                                 + Convert.ToDouble(N_AMOUNT == "" ? "0" : N_AMOUNT);

                if (MIS_CHARGES == "" || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
                {
                    if (isAnyAmount_AtoN)
                    {
                        MIS_CURRENCY = INVOICE_CURRENCY;
                        MIS_EXRATE = INVOICE_EXRATE;
                        MIS_CHARGES = Convert.ToString(sumAtoN_1);
                    }
                    else
                    {
                        MIS_CURRENCY = MIS_CURRENCY;
                        MIS_CHARGES = MIS_CHARGES;
                    }
                }
                else
                {
                    if (isAnyAmount_AtoN)
                    {
                        if (MIS_CURRENCY == INVOICE_CURRENCY)
                        {
                            MIS_CURRENCY = INVOICE_CURRENCY;
                            MIS_EXRATE = INVOICE_EXRATE;
                            MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + sumAtoN_1);
                        }
                        else
                        {
                            double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
                            MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
                            MIS_CURRENCY = INVOICE_CURRENCY;
                            MIS_EXRATE = INVOICE_EXRATE;
                            MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + sumAtoN_1);
                        }
                    }
                    else
                    {
                        MIS_CURRENCY = MIS_CURRENCY;
                        MIS_CHARGES = MIS_CHARGES;
                    }
                }
            }

            if (INV_MISC_T_F == "T")
            {
                //already converted in Get_ITEM_Details_new method
                //if (INVOICE_CURRENCY.ToUpper() == "JPY")
                //{
                //    double invmisc_exrate1 = 0.00;
                //    invmisc_exrate1 = Convert.ToDouble(INV_MISC_EXRATE) / 100;
                //    INV_MISC_EXRATE = Convert.ToString(invmisc_exrate1);
                //}

                //this MiSC convertion issue for same curr. for Agility on 14-09-2020 - hide by Chithra sugg.by Mohmed
                //INV_MISC_CHARGES_CONVERT_INV = Convert.ToDouble(INV_MISC_CHARGES) * Convert.ToDouble(INV_MISC_EXRATE);
                //INV_MISC_CHARGES_CONVERT_fc = INV_MISC_CHARGES_CONVERT_INV / Convert.ToDouble(MIS_EXRATE);

                //this same curr.condition put for Agility on 14-09-2020
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
                //INVOICE_VALUE_INR = INVOICE_VALUE_INR + INV_MISC_CHARGES_CONVERT_INV;
                MIS_CHARGES_ = Convert.ToString(Math.Round(Convert.ToDouble(final_INV_MISC_CHARGES), 2));

                //this line newly added by Chithra on 22-07-2020 for MISC value should be show in Checklist
                MIS_CHARGES = MIS_CHARGES_;
            }
            else
            {
                MIS_CHARGES_ = MIS_CHARGES; // Total SC Misc(INR) in Checklist show
            }

            if (TERMS != "CIF")
            {
                if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00" && MIS_FREIGHT_RATE != "0.0000" && MIS_FREIGHT_RATE != "")
                {
                    if (MIS_CHARGES != "0" && MIS_CHARGES != "0.00" && MIS_CHARGES != "")
                    {
                        if (INVOICE_CURRENCY == MIS_CURRENCY)
                        {
                            double inv_value = 0;
                            double FRT_charge = 0;

                            if (INV_MISC_T_F != "T")
                            {
                                //inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES);// hided by pandiyan on 17-06-2025
                                inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES) + Convert.ToDouble(MIS_LOADING_CHARGES);
                                mis_fri_charge = inv_value * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;
                            }
                            else
                            {
                                //inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(INV_MISC_CHARGES);// hide on 01-02-2020
                                //inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES);// hided by pandiyan on 17-06-2025
                                inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES) + Convert.ToDouble(MIS_LOADING_CHARGES);

                                mis_fri_charge = inv_value * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;
                            }


                            if (INVOICE_CURRENCY != MIS_FREIGHT_CURRENCY)
                            {
                                if (MIS_FREIGHT_CURRENCY == "INR")
                                {
                                    mis_fri_charge = mis_fri_charge * Convert.ToDouble(INVOICE_EXRATE);
                                }
                                else if (MIS_FREIGHT_CURRENCY == "JPY" || MIS_FREIGHT_CURRENCY == "KRW")
                                {
                                    //ins_charge = (ins_charge / Convert.ToDouble(INVOICE_EXRATE)) * 100;
                                    double FRT_Exrate = Convert.ToDouble(MIS_FREIGHT_EXRATE) / 100;
                                    mis_fri_charge = (mis_fri_charge * Convert.ToDouble(INVOICE_EXRATE)) / FRT_Exrate;
                                }
                                else
                                {
                                    mis_fri_charge = (mis_fri_charge * Convert.ToDouble(INVOICE_EXRATE)) / Convert.ToDouble(MIS_FREIGHT_EXRATE);
                                }
                            }

                            MIS_FREIGHT_CHARGES = Convert.ToString(mis_fri_charge);

                            MIS_FREIGHT_CHARGES = MIS_FREIGHT_RATE + "%" + "(" + Math.Round(Convert.ToDouble(MIS_FREIGHT_CHARGES), 2) + " " + MIS_FREIGHT_CURRENCY + ")";
                        }
                        else if (INVOICE_CURRENCY != MIS_CURRENCY)
                        {

                            //MISC Val convert Invoice Exrate - suggest by Karthik for freightLog
                            double Mischarges = 0;
                            double inv_value = 0;
                            if (INV_MISC_T_F != "T")
                            {
                                Mischarges = Convert.ToDouble(MIS_CHARGES) * (Convert.ToDouble(MIS_EXRATE) / Convert.ToDouble(INVOICE_EXRATE));

                            }
                            else
                            {
                                //Mischarges = Convert.ToDouble(INV_MISC_CHARGES);// hide on 01-02-2020
                                //Mischarges = Convert.ToDouble(MIS_CHARGES_) * (Convert.ToDouble(MIS_EXRATE));
                                //Mischarges = Convert.ToDouble(MIS_CHARGES_) / Convert.ToDouble(INVOICE_EXRATE);
                                Mischarges = Convert.ToDouble(MIS_CHARGES_) * (Convert.ToDouble(MIS_EXRATE) / Convert.ToDouble(INVOICE_EXRATE));
                            }


                            inv_value = Convert.ToDouble(INVOICE_VALUE) + Mischarges;
                            mis_fri_charge = inv_value * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;

                            double FRT_charge = inv_value * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;


                            if (INVOICE_CURRENCY != MIS_FREIGHT_CURRENCY)
                            {
                                if (MIS_FREIGHT_CURRENCY == "INR")
                                {
                                    mis_fri_charge = FRT_charge * Convert.ToDouble(INVOICE_EXRATE);
                                }
                                else if (MIS_FREIGHT_CURRENCY == "JPY" || MIS_FREIGHT_CURRENCY == "KRW")
                                {
                                    //ins_charge = (ins_charge / Convert.ToDouble(INVOICE_EXRATE)) * 100;
                                    double FRT_Exrate = Convert.ToDouble(MIS_FREIGHT_EXRATE) / 100;
                                    mis_fri_charge = (FRT_charge * Convert.ToDouble(INVOICE_EXRATE)) / FRT_Exrate;
                                }
                                else
                                {
                                    mis_fri_charge = (FRT_charge * Convert.ToDouble(INVOICE_EXRATE)) / Convert.ToDouble(MIS_FREIGHT_RATE);
                                }
                            }

                            MIS_FREIGHT_CHARGES = Convert.ToString(mis_fri_charge);

                            MIS_FREIGHT_CHARGES = MIS_FREIGHT_RATE + "%" + "(" + Math.Round(Convert.ToDouble(MIS_FREIGHT_CHARGES), 2) + " " + MIS_FREIGHT_CURRENCY + ")";
                        }
                    }
                    else
                    {

                        double inv_value = 0;

                        if (INV_MISC_T_F != "T")
                        {
                            //inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES); // hided by pandiyan on 17-06-2025
                            inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES) + Convert.ToDouble(MIS_LOADING_CHARGES);
                            mis_fri_charge = inv_value * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;
                        }
                        else
                        {
                            //inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(INV_MISC_CHARGES);// hide on 01-02-2020
                            //inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES_);// hided by pandiyan on 17-06-2025
                            inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES_) + Convert.ToDouble(MIS_LOADING_CHARGES);
                            mis_fri_charge = inv_value * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;
                        }

                        if (INVOICE_CURRENCY != MIS_FREIGHT_CURRENCY)
                        {
                            if (MIS_FREIGHT_CURRENCY == "INR")
                            {
                                mis_fri_charge = mis_fri_charge * Convert.ToDouble(INVOICE_EXRATE);
                            }
                            else if (MIS_FREIGHT_CURRENCY == "JPY" || MIS_FREIGHT_CURRENCY == "KRW")
                            {
                                //ins_charge = (ins_charge / Convert.ToDouble(INVOICE_EXRATE)) * 100;
                                double FRT_Exrate = Convert.ToDouble(MIS_FREIGHT_EXRATE) / 100;
                                mis_fri_charge = (mis_fri_charge * Convert.ToDouble(INVOICE_EXRATE)) / FRT_Exrate;
                            }
                            else
                            {
                                mis_fri_charge = (mis_fri_charge * Convert.ToDouble(INVOICE_EXRATE)) / Convert.ToDouble(MIS_FREIGHT_RATE);
                            }
                        }

                        MIS_FREIGHT_CHARGES = Convert.ToString(mis_fri_charge);

                        MIS_FREIGHT_CHARGES = MIS_FREIGHT_RATE + "%" + "(" + Math.Round(Convert.ToDouble(MIS_FREIGHT_CHARGES), 2) + " " + MIS_FREIGHT_CURRENCY + ")";

                    }
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
                            double inv_value = 0;
                            double ins_charge = 0;

                            if (INV_MISC_T_F != "T")
                            {
                                //inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES);// hided by pandiyan on 17-06-2025
                                inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES) + Convert.ToDouble(MIS_LOADING_CHARGES);
                                ins_charge = inv_value * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                            }
                            else
                            {
                                //inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(INV_MISC_CHARGES);// hide on 01-02-2020
                                //inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES_);// hided by pandiyan on 17-06-2025
                                inv_value = Convert.ToDouble(INVOICE_VALUE) + Convert.ToDouble(MIS_CHARGES_) + Convert.ToDouble(MIS_LOADING_CHARGES);
                                ins_charge = inv_value * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                            }

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

                            //MISC Val convert Invoice Exrate - suggest by Karthik for freightLog
                            double Mischarges = 0;
                            double inv_value = 0;
                            if (INV_MISC_T_F != "T")
                            {
                                Mischarges = Convert.ToDouble(MIS_CHARGES) * (Convert.ToDouble(MIS_EXRATE) / Convert.ToDouble(INVOICE_EXRATE));

                            }
                            else
                            {
                                //Mischarges = Convert.ToDouble(INV_MISC_CHARGES);// hide on 01-02-2020
                                //Mischarges = Convert.ToDouble(MIS_CHARGES_) * (Convert.ToDouble(MIS_EXRATE));
                                //Mischarges = Convert.ToDouble(MIS_CHARGES_) / Convert.ToDouble(INVOICE_EXRATE);
                                Mischarges = Convert.ToDouble(MIS_CHARGES_) * (Convert.ToDouble(MIS_EXRATE) / Convert.ToDouble(INVOICE_EXRATE));
                            }


                            inv_value = Convert.ToDouble(INVOICE_VALUE) + Mischarges;

                            double ins_charge = inv_value * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;

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
                        if (INV_MISC_T_F != "T")
                        {
                            //mis_insu_charge = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                            mis_insu_charge = Convert.ToDouble(INVOICE_VALUE_INR) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                        }
                        else
                        {
                            mis_insu_charge = (Convert.ToDouble(INVOICE_VALUE_INR) + Convert.ToDouble(INV_MISC_CHARGES_CONVERT_INV)) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                        }

                        if (MIS_INSURANCE_CURRENCY != "INR" && MIS_INSURANCE_CURRENCY != "JPY" && MIS_INSURANCE_CURRENCY != "KRW")
                        {
                            mis_insu_charge = mis_insu_charge / Convert.ToDouble(MIS_INSURANCE_EXRATE);
                        }
                        else if (MIS_INSURANCE_CURRENCY == "JPY" || MIS_INSURANCE_CURRENCY == "KRW")
                        {
                            mis_insu_charge = (mis_insu_charge / Convert.ToDouble(MIS_INSURANCE_EXRATE)) * 100;
                        }

                        if (MIS_LOADING_CHARGES != "") // Condition Added by pandiyan on 17-06-2025 for adding the loading value in ins
                        {
                            MIS_INSURANCE_CHARGES = Convert.ToString(MIS_INSURANCE_CHARGES);
                        }
                        else
                        {
                            MIS_INSURANCE_CHARGES = Convert.ToString(mis_insu_charge);
                        }

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

            string MIS_CHARGES_Add = "";
            SupplierCountry_Name_Pincode = SUPPLIER_COUNTRY_NAME + " " + SUPPLIER_COUNTRY_PINCODE;

           // if (MIS_CHARGES != "0")
            if (MIS_CHARGES != "" && MIS_CHARGES != "0" && MIS_CHARGES != "0.00")
            {
                if (INV_MISC_T_F != "T")
                {
                    MIS_CHARGES_Add = MIS_CHARGES + " " + MIS_CURRENCY + " " + MIS_EXRATE;
                }
                else
                {
                    MIS_CHARGES_Add = Convert.ToString(Math.Round(Convert.ToDouble(final_INV_MISC_CHARGES), 2)) + " " + MIS_CURRENCY + " " + MIS_EXRATE;
                }
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

            //string MIS_Dscount_RATE = MIS_DISCOUNT_RATE.Substring(0, 1); // this line hide by Chithra on 20-03-2020 for Discount rate hide in Invoice details

            string MIS_Dscount_RATE = "";
            MIS_Dscount_RATE = MIS_DISCOUNT_RATE;

            if (MIS_DISCOUNT_RATE != "" && MIS_Dscount_RATE != "0")
            {
                MIS_Dscount_RATE = MIS_DISCOUNT_RATE.Substring(0, 1);
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

            MIS_AGENCY_RATE = row["MIS_AGENCY_RATE"].ToString();
            MIS_AGENCY_CHARGES = row["MIS_AGENCY_CHARGES"].ToString();
            MIS_AGENCY_CURRENCY = row["MIS_AGENCY_CURRENCY"].ToString();
            MIS_AGENCY_EXRATE = row["MIS_AGENCY_EXRATE"].ToString();

            if (MIS_AGENCY_CHARGES != "" && MIS_AGENCY_CHARGES != "0")
            {
                MIS_AGENCY_CHARGES = MIS_AGENCY_CHARGES + " " + MIS_AGENCY_CURRENCY + " " + MIS_AGENCY_EXRATE;
            }
            else
            {
                MIS_AGENCY_CHARGES = "";
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
            //OTHER_NATURE_OF_TRANSACTION = row["OTHER_NATURE_OF_TRANSACTION"].ToString();
            OTHER_NATURE_OF_TRANSACTION = row["OTHER_NATURE_OF_TRANSACTION"].ToString() + " & " + row["OTHER_TERMS_OF_PAYMENT"].ToString();

            if (COMPANY_ID == "227")
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


            SELLER_NAME = row["SELLER_NAME"].ToString();
            SELLER_ADDRESS = row["SELLER_ADDRESS"].ToString();
            SELLER_ADDRESS1 = row["SELLER_ADDRESS1"].ToString();
            SELLER_ADDRESS2 = row["SELLER_ADDRESS2"].ToString();
            SELLER_COUNTRY_CODE = row["SELLER_COUNTRY_CODE"].ToString();
            SELLER_COUNTRY_NAME = row["SELLER_COUNTRY_NAME"].ToString();
            SELLERCOUNTRY_PINCODE = row["SELLERCOUNTRY_PINCODE"].ToString();

            OTHER_PURCHASE_ORDER = row["OTHER_PURCHASE_ORDER"].ToString();
            OTHER_PURCHASE_ORDER_DATE = row["OTHER_PURCHASE_ORDER_DATE"].ToString();
            OTHER_LOC_NO = row["OTHER_LOC_NO"].ToString();
            OTHER_LOC_DATE = row["OTHER_LOC_DATE"].ToString();

            //----------------------------SELLER DETAILS - end -----------------------------------------------------------------

            Load_Invoice_Details.Add(new INVOICE_DETAILS()
            {
                INVOICE_ID = INVOICE_ID,

                INVOICE_EXRATE = INVOICE_EXCHANGERATE,

                Invoice_Details = Convert.ToString(count),
                FIRSTCHECK = FIRSTCHECK,
                GREEN_CHANNEL = GREEN_CHANNEL,
                KACHHA_BE = KACHHA_BE,
                SECTION48 = SECTION48,
                PROVISIONAL = PROVISIONAL,
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

                //MIS_CHARGES_ = Return_Zero_Value(MIS_CHARGES),
                MIS_CHARGES_ = Return_Zero_Value(MIS_CHARGES_),

                MIS_CURRENCY = row["MIS_CURRENCY"].ToString(),

                MIS_CHARGES = MIS_CHARGES_Add,
                MIS_RATE = Return_Zero_Value(row["MIS_RATE"].ToString()),
                MIS_EXRATE = MIS_EXRATE,
                MIS_HIGHSEASALE_RATE = MIS_HIGHSEASALE_RATE,
                //MIS_HIGHSEASALE_CHARGES = MIS_HIGHSEASALE_CHARGES,// hide on 11-04-2025
                MIS_HIGHSEASALE_CHARGES = str_TOTAL_HSS_AMOUNT,

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
                WHETHER_BUYER_SELLER_RELATED = WHETHER_BUYER_SELLER_RELATED,
                OTHER_NATURE_OF_TRANSACTION = OTHER_NATURE_OF_TRANSACTION,

                SELLER_NAME = SELLER_NAME,
                SELLER_ADDRESS = SELLER_ADDRESS,
                SELLER_ADDRESS1 = SELLER_ADDRESS1,
                SELLER_ADDRESS2 = SELLER_ADDRESS2,
                SELLER_COUNTRY_CODE = SELLER_COUNTRY_CODE,
                SELLER_COUNTRY_NAME = SELLER_COUNTRY_NAME,
                SELLERCOUNTRY_PINCODE = SELLERCOUNTRY_PINCODE,
                OTHER_PURCHASE_ORDER = OTHER_PURCHASE_ORDER,
                OTHER_PURCHASE_ORDER_DATE = OTHER_PURCHASE_ORDER_DATE,
                MIS_AGENCY_CHARGES = MIS_AGENCY_CHARGES,
                MIS_AGENCY_CURRENCY = MIS_AGENCY_CURRENCY,
                MIS_AGENCY_RATE = MIS_AGENCY_RATE,
                MIS_AGENCY_EXRATE = MIS_AGENCY_EXRATE,
                OTHER_LOC_NO = OTHER_LOC_NO,
                OTHER_LOC_DATE = OTHER_LOC_DATE,
                TOTAL_FOC_Item_AMT = str_TOTAL_FOC_Item_AMT

            });
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    


    public DataSet GET_ALL_NOTIFICATIONS_RATE(DataTable dt_all)
    {
        try
        {
            UserBO ObjUBO = new UserBO();

            System.Data.DataView view = new System.Data.DataView(dt_all);
            System.Data.DataTable selected = view.ToTable("Selected", true, "PRODUCT_CTH", "PRODUCT_CETH", "PRODUCT_BCD_NOTN"
                , "PRODUCT_BCD_SLNO", "PRODUCT_TARIFF_NOTN", "PRODUCT_TARIFF_SLNO", "PRODUCT_SAFEGUARD_NOTN", "PRODUCT_SAFEGUARD_SLNO", "PRODUCT_SAPTA_NOTN", "PRODUCT_SAPTA_SLNO"
                , "PRODUCT_AGGREGATE_DUTY_NOTN", "PRODUCT_AGGREGATE_DUTY_NOTN_SL", "IGST_LEVY_NOTN", "IGST_LEVY_SLNO", "IGST_LEVY_EXCEPTION_NOTN", "IGST_LEVY_EXCEPTION_SLNO"
                , "IGST_LEVY_COMPENSATION_CESS_NOTN", "IGST_LEVY_COMPENSATION_CESS_SLNO", "IGST_LEVY_EXCEPTION_CC_NOTN", "IGST_LEVY_EXCEPTION_CC_SLNO", "PRODUCT_CVD_NOTN"
                , "PRODUCT_CVD_SLNO", "SCHEME_CODE", "SCHEME_NOTN", "SCHEME_NOTN_SLNO", "ANTI_DUMPING_NOTN", "ANTI_DUMPING_NOTN_SLNO", "CTH_SLNO", "CTH_SUPPLIER_SLNO"
                , "SOCIAL_WELFARE_NOTN", "SOCIAL_WELFARE_NOTN_SLNO", "AIDC_NOTN", "AIDC_NOTN_SLNO", "PRODUCT_ADDL_DUTY_NOTN", "PRODUCT_ADDL_DUTY_NOTN_SL", "EXC_AIDC_NOTN", "EXC_AIDC_NOTN_SLNO");

            ObjUBO.Xml_D = ConvertDataTableToXML(selected);
            ObjUBO.flag = "Get_Notification_Rate";
            dt_All_Rates = IC.Get_Notifications_Rate(ObjUBO);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return dt_All_Rates;
    }

    public void Get_ITEM_Details_new(string ddlJobNo, DataTable ds,DataTable ds_Item, DataTable ds3, DataTable dt_ReImport)
    {
        try
        {
            //-----------------------------------------------------------

            ViewState["Checklist_Value"] = "";

            DataTable dtt_Addl = new DataTable();
            DataTable dtt_License = new DataTable();
            dtt_License.Columns.Add("LICENSE_ID");
            dtt_License.Columns.Add("JOBNO");
            dtt_License.Columns.Add("INVOICE_SLNO");
            dtt_License.Columns.Add("ITEM_SLNO");
            dtt_License.Columns.Add("DEBIT_AMT");
            dtt_License.Columns.Add("DEBIT_DUTY");
            dtt_License.Columns.Add("BRANCH_CODE");

            DataSet dssEmpty = IC.GetData_ChkListNew(ddlJobNo, "", "EmptyChklistStr-BulkNew");
            dtt = dssEmpty.Tables[0];
            dtt_Addl = dssEmpty.Tables[2];


            Transaction Transact = new Transaction();
            DataTable dt_error = new DataTable();
          
            dt_error.Columns.Add("NOTN_NO");
            dt_error.Columns.Add("NOTN_SLNO");
            dt_error.Columns.Add("INVOICE_SLNO");
            dt_error.Columns.Add("ITEM_SLNO");

            //List<ITEM_DETAILS> list1 = new List<ITEM_DETAILS>();
            Load_Item_Details.Clear();

            TRANSPORT_MODE = TRANSPORT_MODE;

            CHECK_FREIGHT_EXRATE = 20;
            int b = 0, C = 0;

            //double TOTAL_ITEM = 0.0;
            string curINVOICE_SLNO = "0";

            GET_ALL_NOTIFICATIONS_RATE(ds_Item);

            while (ds.Rows.Count > C)
            {
                NUMBERTOWORDS = "";
                curINVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
                INVOICE_VALUE = Return_Zero_Value1(ds.Rows[C]["INVOICE_VALUE"].ToString());
                INVOICE_CURRENCY = ds.Rows[C]["INVOICE_CURRENCY"].ToString();

                TERMS = Return_Zero_Value1(ds.Rows[C]["TERMS"].ToString());
                INVOICE_EXRATE = Return_ExRate_Value(ds.Rows[C]["INVOICE_CURRENCY"].ToString(), ds.Rows[C]["INVOICE_EXRATE"].ToString());
                MIS_FREIGHT_RATE = Return_Zero_Value1(ds.Rows[C]["MIS_FREIGHT_RATE"].ToString());
                MIS_FREIGHT_CHARGES = Return_Zero_Value1(ds.Rows[C]["MIS_FREIGHT_CHARGES"].ToString());
                MIS_FREIGHT_CURRENCY = ds.Rows[C]["MIS_FREIGHT_CURRENCY"].ToString();
                MIS_FREIGHT_EXRATE = Return_ExRate_Value(ds.Rows[C]["MIS_FREIGHT_CURRENCY"].ToString(), ds.Rows[C]["MIS_FREIGHT_EXRATE"].ToString());
                MIS_INSURANCE_CHARGES = Return_Zero_Value1(ds.Rows[C]["MIS_INSURANCE_CHARGES"].ToString());
                MIS_INSURANCE_EXRATE = Return_ExRate_Value(ds.Rows[C]["MIS_INSURANCE_CURRENCY"].ToString(), ds.Rows[C]["MIS_INSURANCE_EXRATE"].ToString());
                MIS_INSURANCE_CURRENCY = ds.Rows[C]["MIS_INSURANCE_CURRENCY"].ToString();
                MIS_INSURANCE_RATE = Return_Zero_Value1(ds.Rows[C]["MIS_INSURANCE_RATE"].ToString());

                ASSESSABLE_TOTAL = 0;
                TOTAL_DUTY = 0.0;
                b = 0;
                TOTAL_HSS_AMOUNT = 0.0;

                SVB_ASSESABLE_RATE = Return_Zero_Value(ds.Rows[C]["SVB_ASSESABLE_RATE"].ToString());
                SVB_ASSESABLE_STATUS = Return_Zero_Value(ds.Rows[C]["SVB_ASSESABLE_STATUS"].ToString());
                SVB_LOADING_ON = ds.Rows[C]["SVB_LOADING_ON"].ToString();
                SVB_DUTY_RATE = Return_Zero_Value(ds.Rows[C]["SVB_DUTY_RATE"].ToString());


                MIS_EXRATE = Return_ExRate_Value(ds.Rows[C]["MIS_CURRENCY"].ToString(), ds.Rows[C]["MIS_EXRATE"].ToString());
                MIS_RATE = Return_Zero_Value(ds.Rows[C]["MIS_RATE"].ToString());
                MIS_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_CHARGES"].ToString());
                MIS_CURRENCY = ds.Rows[C]["MIS_CURRENCY"].ToString();

                INV_MISC_T_F = Return_Zero_Value(ds.Rows[C]["INV_MISC_T_F"].ToString());
                INV_MISC_CURRENCY = ds.Rows[C]["INV_MISC_CURRENCY"].ToString();
                INV_MISC_EXRATE = Return_Zero_Value(ds.Rows[C]["INV_MISC_EXRATE"].ToString());
                INV_MISC_CHARGES = Return_Zero_Value(ds.Rows[C]["INV_MISC_CHARGES"].ToString());
                INV_MISC_ADD_FRT_INS_YN = Return_Zero_Value(ds.Rows[C]["INV_MISC_ADD_FRT_INS_YN"].ToString());
                INV_MISC_TOTAL_CHARGES = Return_Zero_Value(ds.Rows[C]["INV_MISC_TOTAL_CHARGES"].ToString());

                MIS_HIGHSEASALE_RATE = Return_Zero_Value(ds.Rows[C]["MIS_HIGHSEASALE_RATE"].ToString());
                MIS_HIGHSEASALE_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_HIGHSEASALE_CHARGES"].ToString());
                MIS_HIGHSEASALE_CURRENCY = ds.Rows[C]["MIS_HIGHSEASALE_CURRENCY"].ToString();
                MIS_HIGHSEASALE_EXRATE = Return_ExRate_Value(MIS_HIGHSEASALE_CURRENCY, ds.Rows[C]["MIS_HIGHSEASALE_EXRATE"].ToString());
                MIS_LOADING_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_LOADING_CHARGES"].ToString());
                MIS_LOADING_CURRENCY = ds.Rows[C]["MIS_LOADING_CURRENCY"].ToString();
                MIS_LOADING_EXRATE = Return_ExRate_Value(MIS_LOADING_CURRENCY, ds.Rows[C]["MIS_LOADING_EXRATE"].ToString());
                MIS_LOADING_RATE = Return_ExRate_Value(MIS_LOADING_RATE, ds.Rows[C]["MIS_LOADING_RATE"].ToString());
                MIS_DISCOUNT_RATE = Return_Zero_Value(ds.Rows[C]["MIS_DISCOUNT_RATE"].ToString());
                MIS_DISCOUNT_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_DISCOUNT_CHARGES"].ToString());
                MIS_DISCOUNT_CURRENCY = ds.Rows[C]["MIS_DISCOUNT_CURRENCY"].ToString();
                MIS_DISCOUNT_EXRATE = Return_ExRate_Value(MIS_DISCOUNT_CURRENCY, ds.Rows[C]["MIS_DISCOUNT_EXRATE"].ToString());
                MIS_AGENCY_RATE = Return_Zero_Value(ds.Rows[C]["MIS_AGENCY_RATE"].ToString());
                MIS_AGENCY_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_AGENCY_CHARGES"].ToString());
                MIS_AGENCY_CURRENCY = ds.Rows[C]["MIS_AGENCY_CURRENCY"].ToString();
                MIS_AGENCY_EXRATE = ds.Rows[C]["MIS_AGENCY_EXRATE"].ToString();
                OTHER_PURCHASE_ORDER = ds.Rows[C]["OTHER_PURCHASE_ORDER"].ToString();
                OTHER_PURCHASE_ORDER_DATE = ds.Rows[C]["OTHER_PURCHASE_ORDER_DATE"].ToString();
                OTHER_LOC_NO = ds.Rows[C]["OTHER_LOC_NO"].ToString();
                OTHER_LOC_DATE = ds.Rows[C]["OTHER_LOC_DATE"].ToString();

                string MIS_Dscount_RATE = MIS_DISCOUNT_RATE.Substring(0, 1);

                REVENUEDEPOSIT_RATE = ds.Rows[C]["REVENUEDEPOSIT_RATE"].ToString();
                REVENUEDEPOSIT_ON = ds.Rows[C]["REVENUEDEPOSIT_ON"].ToString();

                D_AMOUNT = Return_Zero_Value(ds.Rows[C]["D_AMOUNT"].ToString());
                M_AMOUNT = Return_Zero_Value(ds.Rows[C]["M_AMOUNT"].ToString());
                N_AMOUNT = Return_Zero_Value(ds.Rows[C]["N_AMOUNT"].ToString());
                // Added by shanthini on 06-08-2026 - A,B,C,E-L amounts, same pattern as D/M/N above
                A_AMOUNT = Return_Zero_Value(ds.Rows[C]["A_AMOUNT"].ToString());
                B_AMOUNT = Return_Zero_Value(ds.Rows[C]["B_AMOUNT"].ToString());
                C_AMOUNT = Return_Zero_Value(ds.Rows[C]["C_AMOUNT"].ToString());
                E_AMOUNT = Return_Zero_Value(ds.Rows[C]["E_AMOUNT"].ToString());
                F_AMOUNT = Return_Zero_Value(ds.Rows[C]["F_AMOUNT"].ToString());
                G_AMOUNT = Return_Zero_Value(ds.Rows[C]["G_AMOUNT"].ToString());
                H_AMOUNT = Return_Zero_Value(ds.Rows[C]["H_AMOUNT"].ToString());
                I_AMOUNT = Return_Zero_Value(ds.Rows[C]["I_AMOUNT"].ToString());
                J_AMOUNT = Return_Zero_Value(ds.Rows[C]["J_AMOUNT"].ToString());
                K_AMOUNT = Return_Zero_Value(ds.Rows[C]["K_AMOUNT"].ToString());
                L_AMOUNT = Return_Zero_Value(ds.Rows[C]["L_AMOUNT"].ToString());

                //this JPY,KRW Conversion globally implnted on 14-09-2020 for Agility Diff. Curr Conversion issue sugg.by Mohmed
                if (INVOICE_CURRENCY.ToUpper() == "JPY" || INVOICE_CURRENCY.ToUpper() == "KRW")
                {
                    double invmisc_exrate1 = 0.00;
                    invmisc_exrate1 = Convert.ToDouble(INV_MISC_EXRATE) / 100;
                    INV_MISC_EXRATE = Convert.ToString(invmisc_exrate1);
                }


                //GET_ALL_NOTIFICATIONS_RATE(ds_Item);

                //DataSet dss = new DataSet();
               // dss = IC.GetData(ddlJobNo, curINVOICE_SLNO, "ITEM"); // hide on 04-06-2024 for Common SP

                DataView vw = ds_Item.DefaultView;
                vw.RowFilter = "INVOICE_SLNO = " + curINVOICE_SLNO;
                DataTable dt_Item = vw.ToTable();

                sum = 0;
                TOTAL_ITEM_INVOICE_VALUE = 0.00;
                TOTAL_FOC_Item_AMT = 0.00;

                //Get ITEM_TOTAL_AMOUNT for Split Individual FRT,INS Instead of INVOICE_VALUE - for FOC Items-- Implemented for Common - Sugg.by Bala sir on 14-03-2025
                //if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "2787" || COMPANY_ID == "2907")
                //{
                    while (dt_Item.Rows.Count > sum)
                    {
                        INV_TOTAL_ITEM_AMOUNT = dt_Item.Rows[sum]["ITEM_TOTAL_AMOUNT"].ToString();
                        TOTAL_ITEM_INVOICE_VALUE = TOTAL_ITEM_INVOICE_VALUE + Convert.ToDouble(INV_TOTAL_ITEM_AMOUNT);

                        if (dt_Item.Rows[sum]["FOC_ITEM"].ToString() == "Y")
                        {
                            TOTAL_FOC_Item_AMT = TOTAL_FOC_Item_AMT + Convert.ToDouble(INV_TOTAL_ITEM_AMOUNT);
                        }

                        sum++;
                    }
                //}


                ITEM_TOTAL = 0;

                while (dt_Item.Rows.Count > b)
                {
                    SCHED11_TOTAL = "0.00";
                    IGST_LEVY_TOTAL = "0.00";
                    IGST_LEVY_COMPENSATION_CESS_TOTAL = "0.00";
                    GSI_TOTAL = "0.00";
                    TOTAL_ANTI_AMT = "0.00";

                    IGST_LEVY_RATE_UPDATE = "";
                    IGST_LEVY_COMPENSATION_CESS_RATE = "";
                    IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE = "";
                    AIDC_24_27_Exec = "";
                    AIDC_EXEC_AMT = "0.00";
                    EXC_AIDC_SPL_AMT = "0.00";
                    EXC_AIDC_CHECKLIST_AMT = "0.00";
                    BCD_FOREGONE_AMT = "0.00";
                    TOTAL_DUTY_FOREGONE_AMT = "0.00";
                    Scheme_Notn_BCD_Amt = 0.00;
                    Scheme_Notn_SWS_Amt = 0.00;
                    bcd_sapta_rate_Less_Value = 0.00;

                    CHECKLIST_NCD_DUTY_AMT = "0.00";
                    CHECKLIST_GSI_DUTY_AMT = "0.00";
                    CHECKLIST_TTA_DUTY_AMT = "0.00";
                    CHECKLIST_AGGREGATE_DUTY_AMT = "0.00";
                    CHECKLIST_OTHER_DUTY_AMT = "0.00";
                    CHECKLIST_SCHED11_DUTY_AMT = "0.00";
                    CHECKLIST_SAFEGUARD_DUTY_AMT = "0.00";
                    CHECKLIST_INFRACESS_DUTY_AMT = "0.00";
                    CHECKLIST_SAPTA_DUTY_AMT = "0.00";
                    ADD_AMTS_RPT = "0.00";
                    MERIT_BCD_FG_AMT = 0.00;
                    MERIT_IGST_AMT = 0.00;

                    ITEM_ID = dt_Item.Rows[b]["ITEM_ID"].ToString();
                    INVOICE_NO_ITEM = dt_Item.Rows[b]["INVOICE_NO"].ToString();
                    INVOICE_SLNO = Convert.ToInt32(dt_Item.Rows[b]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt_Item.Rows[b]["ITEM_SLNO"].ToString();
                    //ITEM_DESCRIPTION = dt_Item.Rows[b]["ITEM_DESCRIPTION"].ToString();
                    COUNTRY_OF_ORIGIN = dt_Item.Rows[b]["COUNTRY_OF_ORIGIN"].ToString();
                    END_USE_OF_ITEM = dt_Item.Rows[b]["END_USE_OF_ITEM"].ToString();

                    ITEM_QTY = dt_Item.Rows[b]["ITEM_QTY"].ToString();
                    ITEM_QTY_CODE = dt_Item.Rows[b]["ITEM_QTY_CODE"].ToString();
                    ITEM_UNIT_PRICE = dt_Item.Rows[b]["ITEM_UNIT_PRICE"].ToString();
                    CTH_NO = dt_Item.Rows[b]["CTH_NO"].ToString();
                    PRODUCT_RITC = dt_Item.Rows[b]["PRODUCT_RITC"].ToString();
                    PRODUCT_CTH = dt_Item.Rows[b]["PRODUCT_CTH"].ToString();
                    PRODUCT_CVD_RATE = dt_Item.Rows[b]["PRODUCT_CVD_RATE"].ToString();
                    PRODUCT_EDU_CESS_RATE = dt_Item.Rows[b]["PRODUCT_EDU_CESS_RATE"].ToString();

                    PRODUCT_SEC_EDU_CESS_RATE = dt_Item.Rows[b]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();
                    PRODUCT_SEC_EDU_CESS_NOTN = dt_Item.Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();

                    PRODUCT_SEC_EDU_CESS_NOTN_SLNO = dt_Item.Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();

                    PRODUCT_BCD_RATE = dt_Item.Rows[b]["PRODUCT_BCD_RATE"].ToString();
                    PRODUCT_CETH = dt_Item.Rows[b]["PRODUCT_CETH"].ToString();
                    PRODUCT_BCD_NOTN = dt_Item.Rows[b]["PRODUCT_BCD_NOTN"].ToString();
                    PRODUCT_BCD_NOTN_SLNO = dt_Item.Rows[b]["PRODUCT_BCD_SLNO"].ToString();

                    PRODUCT_BCD_SPL = dt_Item.Rows[b]["PRODUCT_BCD_SPL"].ToString();
                    PRODUCT_BCD_UNIT = dt_Item.Rows[b]["PRODUCT_BCD_UNIT"].ToString();
                    

                    PRODUCT_CVD_NOTN = dt_Item.Rows[b]["PRODUCT_CVD_NOTN"].ToString();
                    PRODUCT_CVD_NOTN_SLNO = dt_Item.Rows[b]["PRODUCT_CVD_SLNO"].ToString();

                    PRODUCT_CVD_SPL = dt_Item.Rows[b]["PRODUCT_CVD_SPL"].ToString();

                    PRODUCT_EDU_CESS_NOTN = dt_Item.Rows[b]["PRODUCT_EDU_CESS_NOTN"].ToString();
                    PRODUCT_EDU_CESS_NOTN_SLNO = dt_Item.Rows[b]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                    PRODUCT_ADDL_DUTY_NOTN = dt_Item.Rows[b]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                    PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN.Trim();
                    PRODUCT_ADDL_DUTY_NOTN_SLNO = dt_Item.Rows[b]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
                    PRODUCT_ADDL_DUTY_RATE = dt_Item.Rows[b]["PRODUCT_ADDL_DUTY_RATE"].ToString();

                    //----------------------------------------------------//
                    PRODUCT_ADDL_SHEII_NOTN = dt_Item.Rows[b]["PRODUCT_ADDL_SHEII_NOTN"].ToString();
                    PRODUCT_ADDL_SHEII_SLNO = dt_Item.Rows[b]["PRODUCT_ADDL_SHEII_SLNO"].ToString();
                    PRODUCT_ADDL_SHEII_RATE = dt_Item.Rows[b]["PRODUCT_ADDL_SHEII_RATE"].ToString();
                    //----------------------------------------------------//

                    //----------------------------------------------------//
                    PRODUCT_ADDL_TTA_NOTN = dt_Item.Rows[b]["PRODUCT_ADDL_TTA_NOTN"].ToString();
                    PRODUCT_ADDL_TTA_SLNO = dt_Item.Rows[b]["PRODUCT_ADDL_TTA_SLNO"].ToString();
                    PRODUCT_ADDL_TTA_RATE = dt_Item.Rows[b]["PRODUCT_ADDL_TTA_RATE"].ToString();
                    //----------------------------------------------------//

                    PRODUCT_ADDL_GSI_NOTN = dt_Item.Rows[b]["PRODUCT_ADDL_GSI_NOTN"].ToString();
                    PRODUCT_ADDL_GSI_SLNO = dt_Item.Rows[b]["PRODUCT_ADDL_GSI_SLNO"].ToString();
                    PRODUCT_ADDL_GSI_RATE = dt_Item.Rows[b]["PRODUCT_ADDL_GSI_RATE"].ToString();

                    //----------------------------------------------------//

                    PRODUCT_CVD_EDU_CESS_RATE = dt_Item.Rows[b]["PRODUCT_CVD_EDU_CESS_RATE"].ToString();

                    PRODUCT_CVD_SEC_EDU_CESS_RATE = dt_Item.Rows[b]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString();
                    CETH_CVD_EDU_CESS_SL = dt_Item.Rows[b]["CETH_CVD_EDU_CESS_SL"].ToString();
                    CETH_CVD_EDU_CESS_RATE = dt_Item.Rows[b]["CETH_CVD_EDU_CESS_RATE"].ToString();
                    CETH_CVD_SEC_EDU_CESS_SL = dt_Item.Rows[b]["CETH_CVD_SEC_EDU_CESS_SL"].ToString();
                    CETH_CVD_SEC_EDU_CESS_RATE = dt_Item.Rows[b]["CETH_CVD_SEC_EDU_CESS_RATE"].ToString();

                    //--------------------- CTH ,CETH ------------------------------//

                    CHECKLIST_BCD_RATE = dt_Item.Rows[b]["CHECKLIST_BCD_RATE"].ToString();
                    CHECKLIST_CVD_RATE = dt_Item.Rows[b]["CHECKLIST_CVD_RATE"].ToString();


                    //---------------------NCD-------------------------------//

                    PRODUCT_NCD_NOTN = dt_Item.Rows[b]["PRODUCT_NCD_NOTN"].ToString();
                    PRODUCT_NCD_SLNO = dt_Item.Rows[b]["PRODUCT_NCD_SLNO"].ToString();
                    PRODUCT_NCD_RATE = dt_Item.Rows[b]["PRODUCT_NCD_RATE"].ToString();
                    //PRODUCT_NCD_SPL = dt_Item.Rows[b]["PRODUCT_NCD_SPL"].ToString();
                    //PRODUCT_NCD_UNIT = dt_Item.Rows[b]["PRODUCT_NCD_UNIT"].ToString();
                    //PRODUCT_NCD_SPL_TYPE = dt_Item.Rows[b]["PRODUCT_NCD_SPL_TYPE"].ToString();

                    //--------------------END NCD----------------------------//

                    //---------------------TARIFF-------------------------------//

                    PRODUCT_TARIFF_NOTN = dt_Item.Rows[b]["PRODUCT_TARIFF_NOTN"].ToString();
                    PRODUCT_TARIFF_SLNO = dt_Item.Rows[b]["PRODUCT_TARIFF_SLNO"].ToString();
                    PRODUCT_TARIFF_QTY = dt_Item.Rows[b]["PRODUCT_TARIFF_QTY"].ToString();
                    PRODUCT_TARIFF_AMOUNT = dt_Item.Rows[b]["PRODUCT_TARIFF_AMOUNT"].ToString();
                    PRODUCT_TARIFF_AMOUNT_UNIT = dt_Item.Rows[b]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString();

                    if ((PRODUCT_TARIFF_NOTN.Trim() == "36/2001") && (PRODUCT_TARIFF_SLNO.Trim() == "2(1)A" || PRODUCT_TARIFF_SLNO.Trim() == "2(1)" || PRODUCT_TARIFF_SLNO.Trim() == "2(2)" || PRODUCT_TARIFF_SLNO.Trim() == "2(3)" || PRODUCT_TARIFF_SLNO.Trim() == "2(4)"))
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

                    PRODUCT_SAPTA_NOTN = dt_Item.Rows[b]["PRODUCT_SAPTA_NOTN"].ToString();
                    PRODUCT_SAPTA_SLNO = dt_Item.Rows[b]["PRODUCT_SAPTA_SLNO"].ToString();
                    PRODUCT_SAPTA_RATE = dt_Item.Rows[b]["PRODUCT_SAPTA_RATE"].ToString();

                    //--------------------END SAPTA----------------------------//

                    PRODUCT_SAFEGUARD_NOTN = dt_Item.Rows[b]["PRODUCT_SAFEGUARD_NOTN"].ToString();
                    PRODUCT_SAFEGUARD_SLNO = dt_Item.Rows[b]["PRODUCT_SAFEGUARD_SLNO"].ToString();
                    PRODUCT_SAFEGUARD_RATE = dt_Item.Rows[b]["PRODUCT_SAFEGUARD_RATE"].ToString();

                    PRODUCT_AGGREGATE_DUTY_NOTN = dt_Item.Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
                    PRODUCT_AGGREGATE_DUTY_NOTN_SL = dt_Item.Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
                    PRODUCT_AGGREGATE_DUTY_NOTN_RATE = dt_Item.Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString();


                    PRODUCT_MRP_YN = dt_Item.Rows[b]["PRODUCT_MRP_YN"].ToString();

                    ITEM_DESCRIPTION = dt_Item.Rows[b]["ITEM_DESCRIPTION"].ToString();

                    PRODUCT_MRP_SL_NO = dt_Item.Rows[b]["PRODUCT_MRP_SL_NO"].ToString();
                    PRODUCT_MRP_AMOUNT = dt_Item.Rows[b]["PRODUCT_MRP_AMOUNT"].ToString();
                    PRODUCT_MRP_ABT_RATE = dt_Item.Rows[b]["PRODUCT_MRP_ABT_RATE"].ToString();

                    RSP_APPLICABLE = dt_Item.Rows[b]["RSP_APPLICABLE"].ToString();


                    //------------Start Other CVD Duty 02June2015-------------------//

                    PRODUCT_OTHER_DUTY_NOTN = dt_Item.Rows[b]["PRODUCT_OTHER_DUTY_NOTN"].ToString();
                    PRODUCT_OTHER_DUTY_SLNO = dt_Item.Rows[b]["PRODUCT_OTHER_DUTY_SLNO"].ToString();
                    PRODUCT_OTHER_DUTY_RATE = dt_Item.Rows[b]["PRODUCT_OTHER_DUTY_RATE"].ToString();
                    PRODUCT_OTHER_DUTY_SPL = dt_Item.Rows[b]["PRODUCT_OTHER_DUTY_SPL"].ToString();
                    PRODUCT_OTHER_DUTY_UNIT = dt_Item.Rows[b]["PRODUCT_OTHER_DUTY_UNIT"].ToString();
                    PRODUCT_OTHER_DUTY_TYPE = dt_Item.Rows[b]["PRODUCT_OTHER_DUTY_TYPE"].ToString();

                    //--------------End Other CVD Duty 02June2015-------------------//

                    //-----------Start Infra Cess 18May2016-----------------//

                    ////INFRA_CESS_NOTN = dt_Item.Rows[b]["INFRA_CESS_NOTN"].ToString();
                    ////INFRA_CESS_NOTN_SL = dt_Item.Rows[b]["INFRA_CESS_NOTN_SL"].ToString();
                    ////INFRA_CESS_NOTN_RATE = dt_Item.Rows[b]["INFRA_CESS_NOTN_RATE"].ToString();

                    //-----------End Infra Cess 18May2016-----------------//

                    //------------ITEMWISE SVB DETAILS FOR NIPPON EXPRESS ON 29FEB2016-------------------//

                    ITEM_SVB_RELATION = dt_Item.Rows[b]["SVB_RELATION"].ToString();
                    ITEM_SVB_REF_NO = dt_Item.Rows[b]["SVB_REF_NO"].ToString();
                    ITEM_SVB_REF_DATE = dt_Item.Rows[b]["SVB_REF_DATE"].ToString();
                    ITEM_SVB_CUSTOM_HOUSE = dt_Item.Rows[b]["SVB_CUSTOM_HOUSE"].ToString();
                    ITEM_SVB_LOADING_ON = dt_Item.Rows[b]["SVB_LOADING_ON"].ToString();
                    ITEM_SVB_ASSESABLE_RATE = dt_Item.Rows[b]["SVB_ASSESABLE_RATE"].ToString();

                    ITEM_SVB_DUTY_RATE = dt_Item.Rows[b]["SVB_DUTY_RATE"].ToString();
                    ITEM_SVB_ASSESABLE_STATUS = dt_Item.Rows[b]["SVB_ASSESABLE_STATUS"].ToString();

                    ITEM_SVB_DUTY_STATUS = dt_Item.Rows[b]["SVB_DUTY_STATUS"].ToString();

                    //--------------ITEMWISE SVB DETAILS FOR NIPPON EXPRESS ON 29FEB2016-------------------//           


                    //------------GST  IMPLEMENTATION ON 30JUNE2017-------------------//

                    IGST_LEVY_NOTN = dt_Item.Rows[b]["IGST_LEVY_NOTN"].ToString();
                    IGST_LEVY_SLNO = dt_Item.Rows[b]["IGST_LEVY_SLNO"].ToString();
                    IGST_LEVY_RATE = dt_Item.Rows[b]["IGST_LEVY_RATE"].ToString() == "" ? "0" : dt_Item.Rows[b]["IGST_LEVY_RATE"].ToString();

                    IGST_LEVY_EXCEPTION_NOTN = dt_Item.Rows[b]["IGST_LEVY_EXCEPTION_NOTN"].ToString();
                    IGST_LEVY_EXCEPTION_SLNO = dt_Item.Rows[b]["IGST_LEVY_EXCEPTION_SLNO"].ToString();
                    IGST_LEVY_EXCEPTION_RATE = dt_Item.Rows[b]["IGST_LEVY_EXCEPTION_RATE"].ToString();
                    IGST_LEVY_COMPENSATION_CESS_NOTN = dt_Item.Rows[b]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString();
                    IGST_LEVY_COMPENSATION_CESS_SLNO = dt_Item.Rows[b]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString();
                    IGST_LEVY_COMPENSATION_CESS_RATE = dt_Item.Rows[b]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString();
                    IGST_LEVY_COMPENSATION_CESS_SPL = dt_Item.Rows[b]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString();
                    IGST_LEVY_EXCEPTION_CC_NOTN = dt_Item.Rows[b]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString();
                    IGST_LEVY_EXCEPTION_CC_SLNO = dt_Item.Rows[b]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString();
                    IGST_LEVY_EXCEPTION_CC_RATE = dt_Item.Rows[b]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString();

                    LEVY_EXCEMPTION_NOTN_TYPE = dt_Item.Rows[b]["LEVY_EXCEMPTION_NOTN_TYPE"].ToString();
                    LEVY_EXCEPTION_CC_NOTN_TYPE = dt_Item.Rows[b]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString();

                    SOCIAL_WELFARE_NOTN = dt_Item.Rows[b]["SOCIAL_WELFARE_NOTN"].ToString();
                    SOCIAL_WELFARE_NOTN_SLNO = dt_Item.Rows[b]["SOCIAL_WELFARE_NOTN_SLNO"].ToString();
                    SOCIAL_WELFARE_RATE = dt_Item.Rows[b]["SOCIAL_WELFARE_RATE"].ToString();

                    AIDC_NOTN = dt_Item.Rows[b]["AIDC_NOTN"].ToString();
                    AIDC_NOTN_SLNO = dt_Item.Rows[b]["AIDC_NOTN_SLNO"].ToString();
                    AIDC_RATE = dt_Item.Rows[b]["AIDC_RATE"].ToString();

                    EXC_AIDC_NOTN = dt_Item.Rows[b]["EXC_AIDC_NOTN"].ToString();
                    EXC_AIDC_NOTN_SLNO = dt_Item.Rows[b]["EXC_AIDC_NOTN_SLNO"].ToString();
                    EXC_AIDC_RATE = dt_Item.Rows[b]["EXC_AIDC_RATE"].ToString();
                    //--------------GST  IMPLEMENTATION ON 30JUNE2017-------------------//  

                    //------------------- HEALTH CESS -------------------------------------//

                    PRODUCT_ADDL_HEALTH_CESS_NOTN = dt_Item.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString();
                    PRODUCT_ADDL_HEALTH_CESS_SLNO = dt_Item.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString();
                    PRODUCT_ADDL_HEALTH_CESS_RATE = dt_Item.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString();
                    PRODUCT_ADDL_HEALTH_CESS_SPL = dt_Item.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString();
                    PRODUCT_ADDL_HEALTH_CESS_TYPE = dt_Item.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString();
                    PRODUCT_ADDL_HEALTH_CESS_UNIT = dt_Item.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString();

                    PRODUCT_BCD_RATE_UPDATE = "";
                    PRODUCT_CVD_RATE_UPDATE = "";

                    //--------------ITEM MANUFACTURER DETAILS FOR AGILITY ON 23-12-2019 By Chithra-------------------// 

                    if (Connection.Get_User_Imp_Settings_Job_Edit("CHKLIST_GENERAL") == "E")
                    {
                        GENEARL_DESCRIPTION = dt_Item.Rows[b]["GENEARL_DESCRIPTION"].ToString();
                        BRAND = dt_Item.Rows[b]["BRAND"].ToString();
                        MODEL = dt_Item.Rows[b]["MODEL"].ToString();
                    }

                    if (Connection.Get_User_Imp_Settings_Job_Edit("CHKLIST_MANUF") == "E")
                    {
                        MANUFACTURER = dt_Item.Rows[b]["MANUFACTURER"].ToString();
                        CENTRAL_EXCISE_FLAG = dt_Item.Rows[b]["CENTRAL_EXCISE_FLAG"].ToString();
                        MANUFACTURER_PRODUCER = dt_Item.Rows[b]["MANUFACTURER_PRODUCER"].ToString();
                        M_P_GROWER_CODE = dt_Item.Rows[b]["M_P_GROWER_CODE"].ToString();
                        M_P_GROWER_ADD1 = dt_Item.Rows[b]["M_P_GROWER_ADD1"].ToString();
                        M_P_GROWER_ADD2 = dt_Item.Rows[b]["M_P_GROWER_ADD2"].ToString();
                        M_P_GROWER_CITY = dt_Item.Rows[b]["M_P_GROWER_CITY"].ToString();
                        M_P_GROWER_COUNTRY_SUBDIV = dt_Item.Rows[b]["M_P_GROWER_COUNTRY_SUBDIV"].ToString();
                        M_P_GROWER_PIN = dt_Item.Rows[b]["M_P_GROWER_PIN"].ToString();
                        M_P_GROWER_COUNTRY = dt_Item.Rows[b]["M_P_GROWER_COUNTRY"].ToString();
                        SOURCE_COUNTRY = dt_Item.Rows[b]["SOURCE_COUNTRY"].ToString();
                        TRANSIT_COUNTRY = dt_Item.Rows[b]["TRANSIT_COUNTRY"].ToString();
                        ACCESSORY_STATUS = dt_Item.Rows[b]["ACCESSORY_STATUS"].ToString();
                    }

                    //----------------------------------------------------------------------------------------------//  

                    PRODUCT_BCD_RATE_UPDATE = "";
                    PRODUCT_CVD_RATE_UPDATE = "";

                    //-----------------Start Country of Origin on 04May2017 (For VSM Logistics)------------------------//

                    DataView view1_Coo = dss_Coo.Tables[0].DefaultView;

                    view1_Coo = dss_Coo.Tables[0].DefaultView;
                    view1_Coo.RowFilter = "COUNTRY_NAME = '" + COUNTRY_OF_ORIGIN + "'";
                    DataSet dt_1 = new DataSet();
                    dt_1.Tables.Add(view1_Coo.ToTable());
                    if (dt_1.Tables[0].Rows.Count > 0)
                    {
                        COUNTRY_OF_ORIGIN = dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
                    }

                    //-----------------End Country of Origin on 04May2017 (For VSM Logistics)--------------------------//

                    SCHEME_CODE = dt_Item.Rows[b]["SCHEME_CODE"].ToString();
                    SCHEME_NOTN = dt_Item.Rows[b]["SCHEME_NOTN"].ToString();
                    SCHEME_NOTN_SLNO = dt_Item.Rows[b]["SCHEME_NOTN_SLNO"].ToString();

                    CTH_QTY1 = dt_Item.Rows[b]["CTH_QTY1"].ToString();
                    CTH_QTY1_CODE = dt_Item.Rows[b]["CTH_QTY1_CODE"].ToString();

                    if (CTH_QTY1 == "")
                    {
                        CTH_QTY1 = "0";
                    }

                    BCD_NOTN = "";
                    if (PRODUCT_BCD_NOTN != "")
                    {
                        BCD_NOTN = PRODUCT_BCD_NOTN;
                        PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN + " " + PRODUCT_BCD_NOTN_SLNO;
                    }

                    CVD_NOTN = "";
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


                    //--------------------- All value conversion here-------------

                    c_ITEM_QTY = Convert.ToDouble(ITEM_QTY);

                    //----------Start RSP Calculation on 06Sep2018-------------//

                    if (RSP_APPLICABLE == "S")
                    {
                        if (PRODUCT_MRP_AMOUNT != "")
                        {
                            if (Convert.ToDouble(PRODUCT_MRP_AMOUNT) > 0.00)
                            {
                                MRP_AMT = c_ITEM_QTY * Convert.ToDouble(PRODUCT_MRP_AMOUNT);
                            }
                        }
                    }

                    //----------End RSP Calculation on 06Sep2018-------------//


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
                    ASSESABLE_VALUE = Get_Indivitual_Assesable_Value(dt_ReImport, INVOICE_SLNO, INVOICE_NO_ITEM, ITEM_SLNO, TOTAL_ITEM_INVOICE_VALUE);

                    //--------------------- 5-Nov-2015  ---------------------//

                    //----------------- ReImport Details---------------------//
                    DataView view = dt_ReImport.DefaultView;
                    view.RowFilter = "INVOICE_NO = '" + INVOICE_NO_ITEM + "' and " + "INVOICE_SLNO = '" + INVOICE_SLNO + "' and " + "ITEM_SLNO = '" + ITEM_SLNO + "'";

                    if (view.Count > 0)
                    {
                        DataTable table = view.ToTable();

                        NOTN_NO = table.Rows[0]["NOTN_NO"].ToString();
                        NOTN_SLNO = table.Rows[0]["NOTN_SLNO"].ToString();
                    }

                    // --------------------------------------- Anti-Dumping Calculation-------------------------------------------------------

                    ANTI_DUMPING_NOTN = dt_Item.Rows[b]["ANTI_DUMPING_NOTN"].ToString();
                    ANTI_DUMPING_NOTN_SLNO = dt_Item.Rows[b]["ANTI_DUMPING_NOTN_SLNO"].ToString();
                    CTH_SLNO = dt_Item.Rows[b]["CTH_SLNO"].ToString();
                    CTH_SUPPLIER_SLNO = dt_Item.Rows[b]["CTH_SUPPLIER_SLNO"].ToString();
                    CTH_QTY = dt_Item.Rows[b]["CTH_QTY"].ToString();
                    ADD_EX_RATE = dt_Item.Rows[b]["ADD_EX_RATE"].ToString();

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
                   
                    DataView dvw = new DataView();

                    if (SCHEME_NOTN_ != "")
                    {
                        adminmaster adm_Mas = new adminmaster();

                        //******************************* GET IGST_LEVY_NOTN_RATE START*****************************// CHK SPEEDUP EDITED FILTER_RATES

                        if (dt_All_Rates.Tables[3].Rows.Count > 0)
                        {
                            if (IGST_LEVY_NOTN != "" && IGST_LEVY_SLNO != "")
                            {
                                if (String.IsNullOrEmpty(IGST_LEVY_RATE) || (IGST_LEVY_RATE == "0" || IGST_LEVY_RATE == "0.00"))// chk if IGST_LEVY_RATE is empty new rate updte else maintain old rate - by Chithra on 18-12-2019
                                {
                                    var FullName1 = from DataRow drr in dt_All_Rates.Tables[3].AsEnumerable()
                                                    where drr.Field<string>("NOTIFICATION_EXCISE_NOTN") == IGST_LEVY_NOTN && drr.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == IGST_LEVY_SLNO
                                                    select drr;

                                    dvw = FullName1.AsDataView();

                                    if (dvw.Count > 0)
                                    {
                                        DataTable Get_JobNo = FullName1.CopyToDataTable();
                                        IGST_LEVY_RATE = Get_JobNo.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                                        IGST_LEVY_RATE_UPDATE = Get_JobNo.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                                    }
                                    else
                                    {
                                        //error IGST Here
                                        dt_error.Rows.Add(IGST_LEVY_NOTN, "IGST", INVOICE_SLNO, ITEM_SLNO);
                                        break;
                                    }
                                }
                                else
                                {
                                    IGST_LEVY_RATE = Convert.ToString(Convert.ToDouble(IGST_LEVY_RATE).ToString("F"));
                                    IGST_LEVY_RATE_UPDATE = IGST_LEVY_RATE;
                                }
                            }
                        }

                        //******************************* GET IGST_LEVY_EXCEPTION_CESS_RATE START*****************************

                        
                        if (dt_All_Rates.Tables[4].Rows.Count > 0)
                        {
                            if (IGST_LEVY_EXCEPTION_NOTN != "")
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
                                else
                                {
                                    //error IGST Here
                                    dt_error.Rows.Add(IGST_LEVY_NOTN, "IGST", INVOICE_SLNO, ITEM_SLNO);
                                    break;
                                }
                            }
                        }

                        //******************************* GET IGST_LEVY_EXCEPTION_CESS_RATE START *****************************

                        if (dt_All_Rates.Tables[5].Rows.Count > 0)
                        {
                            if (IGST_LEVY_COMPENSATION_CESS_NOTN != "" && IGST_LEVY_COMPENSATION_CESS_SLNO != "")
                            {
                                if (String.IsNullOrEmpty(IGST_LEVY_COMPENSATION_CESS_RATE)) // chk if IGST_LEVY_EXCEPTION_RATE is empty new rate updte else maintain old rate - by Chithra on 18-12-2019
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
                                        IGST_LEVY_COMPENSATION_CESS_SPL = NOTIFICATION_EXCISE_BCD_SPL;
                                    }
                                    else
                                    {
                                        //error IGST Here
                                        dt_error.Rows.Add(IGST_LEVY_NOTN, "IGST", INVOICE_SLNO, ITEM_SLNO);
                                        break;
                                    }
                                }
                                else
                                {
                                    IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE = IGST_LEVY_COMPENSATION_CESS_RATE;

                                    if (IGST_LEVY_COMPENSATION_CESS_SPL == "-1.000000" || IGST_LEVY_COMPENSATION_CESS_SPL == "")
                                    {
                                        IGST_LEVY_COMPENSATION_CESS_SPL = "0.00";
                                    }
                                    NOTIFICATION_EXCISE_BCD_SPL = IGST_LEVY_COMPENSATION_CESS_SPL;
                                }
                            }
                        }

                        //******************************* GET IGST_LEVY_EXCEPTION_CESS_RATE START*****************************

                        if (dt_All_Rates.Tables[6].Rows.Count > 0)
                        {
                            if (IGST_LEVY_EXCEPTION_CC_NOTN != "" && IGST_LEVY_EXCEPTION_CC_SLNO != "")
                            {
                                if (String.IsNullOrEmpty(IGST_LEVY_EXCEPTION_CC_RATE)) // chk if IGST_LEVY_EXCEPTION_RATE is empty new rate updte else maintain old rate - by Chithra on 18-12-2019
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
                                    else
                                    {
                                        //error IGST Here
                                        dt_error.Rows.Add(IGST_LEVY_NOTN, "IGST", INVOICE_SLNO, ITEM_SLNO);
                                        break;
                                    }
                                }
                            }
                        }

                        //------------------Start------ Health Cess CTH - on Budget Updation of 01-Feb-2020-----------------


                        if (dt_All_Rates.Tables[0].Rows.Count > 0)
                        {
                            HEALTH_CESS_CTH_CODE = "";
                            HEALTH_CESS_RATE = "";
                            HEALTH_CESS_SQC = "";

                            if (PRODUCT_CTH.Substring(0, 2) == "90")
                            {
                                var PRODUCT_CTH_RATE = from DataRow drr in dt_All_Rates.Tables[12].AsEnumerable()
                                                       where drr.Field<string>("CTH_CODE") == PRODUCT_CTH
                                                       select drr;

                                DataView dv_Health_CTH = PRODUCT_CTH_RATE.AsDataView();

                                if (dv_Health_CTH.Count > 0)
                                {
                                    DataTable dt_HEALTH_CTH = PRODUCT_CTH_RATE.CopyToDataTable();

                                    HEALTH_CESS_CTH_CODE = dt_HEALTH_CTH.Rows[0]["CTH_CODE"].ToString();
                                    HEALTH_CESS_SQC = dt_HEALTH_CTH.Rows[0]["CTH_SQC"].ToString();

                                    /* hide on 05-02-2026 - for New Budget Updation on 01-02-2026 - suggest by Bala sir. Final print SMS Clearing*/
                                    //HEALTH_CESS_RATE = dt_HEALTH_CTH.Rows[0]["HEALTH_CESS_RATE"].ToString();
                                    //PRODUCT_ADDL_HEALTH_CESS_RATE = HEALTH_CESS_RATE;

                                    //05-02-2026
                                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN != "")
                                    {
                                        HEALTH_CESS_RATE = PRODUCT_ADDL_HEALTH_CESS_RATE;
                                    }
                                    else
                                    {
                                        HEALTH_CESS_RATE = dt_HEALTH_CTH.Rows[0]["HEALTH_CESS_RATE"].ToString();
                                        PRODUCT_ADDL_HEALTH_CESS_RATE = HEALTH_CESS_RATE;
                                    }
                                }
                            }
                        }

                        if (PRODUCT_ADDL_HEALTH_CESS_NOTN != "")
                        {
                            PRODUCT_ADDL_HEALTH_CESS_RATE = "0.00";
                        }

                        //------------------End------ Health Cess CTH - on Budget Updation of 01-Feb-2020-----------------


                        if (dt_All_Rates.Tables[0].Rows.Count > 0)
                        {

                            var PRODUCT_CTH_RATE = from DataRow drr in dt_All_Rates.Tables[0].AsEnumerable()
                                                   where drr.Field<string>("CTH_CODE") == PRODUCT_CTH
                                                   select drr;

                            DataView dv_CTH_RATE = PRODUCT_CTH_RATE.AsDataView();

                            if (dv_CTH_RATE.Count > 0)
                            {
                                DataTable CTH_RateS = PRODUCT_CTH_RATE.CopyToDataTable();

                                if (String.IsNullOrEmpty(CHECKLIST_BCD_RATE)) // chk if CHECKLIST_BCD_RATE is empty new rate updte else maintain old rate - by Chithra on 18-12-2019
                                {
                                    string CTH_Rate = CTH_RateS.Rows[0]["CTH_RATE"].ToString();
                                    double CTH_Rate1 = Convert.ToDouble(CTH_Rate);

                                    MERIT_PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(CTH_Rate1).ToString("F"));
                                    NOTIFICATION_CUSTOMS_BCD_RATE = MERIT_PRODUCT_BCD_RATE;
                                }
                                else
                                {
                                    string CTH_Rate = CHECKLIST_BCD_RATE;//old rate
                                    double CTH_Rate1 = Convert.ToDouble(CTH_Rate);

                                    MERIT_PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(CTH_Rate1).ToString("F"));
                                    NOTIFICATION_CUSTOMS_BCD_RATE = MERIT_PRODUCT_BCD_RATE;
                                }

                                //CTH_SPL_UNIT = ds_rate.Tables[0].Rows[0]["CTH_SPL_UNIT"].ToString();
                                CTH_SPL_UNIT = CTH_RateS.Rows[0]["CTH_SPL_UNIT"].ToString();


                                //************** SPECIAL AMOUNT FOR CTH RATE ***********************
                                string CTH_spl_amt = CTH_RateS.Rows[0]["CTH_SPL_AMT"].ToString();
                                if (CTH_spl_amt == "")
                                {
                                    CTH_spl_amt = "0";
                                }

                                CTH_SPL_AMT = Convert.ToString(Convert.ToDouble(CTH_spl_amt).ToString("F"));
                                c_CTH_SPL_AMT = Convert.ToDouble(CTH_SPL_AMT);

                                //************** NCD NOTN RATE ***********************

                                CTH_NCD_SPL_DUTY = CTH_RateS.Rows[0]["CTH_NCD_SPL_DUTY"].ToString();
                                CTH_NCD_SPL_UNIT = CTH_RateS.Rows[0]["CTH_NCD_SPL_UNIT"].ToString();
                                CTH_FLAG = CTH_RateS.Rows[0]["CTH_FLAG"].ToString();
                                NOTIFICATION_FLAG = CTH_FLAG;


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
                                break;
                            }
                        }

                        //************** SAFEGUARD NOTN RATE ***********************

                        if (PRODUCT_SAFEGUARD_NOTN != "")
                        {
                            //if (PRODUCT_SAFEGUARD_RATE != "")
                            if (!String.IsNullOrEmpty(PRODUCT_SAFEGUARD_RATE)) // chk if PRODUCT_SAFEGUARD_RATE is empty new rate updte else maintain old rate - by Chithra on 18-12-2019
                            {
                                CTH_SAFEGUARD_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_SAFEGUARD_RATE).ToString("F"));
                                CTH_SAFEGUARD_RATE_UPDATE = CTH_SAFEGUARD_RATE;
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
                                    CTH_SAFEGUARD_RATE_UPDATE = CTH_SAFEGUARD_RATE;
                                }
                                else
                                {
                                    //error SAFEGUARD here
                                    dt_error.Rows.Add(PRODUCT_SAFEGUARD_NOTN, PRODUCT_SAFEGUARD_SLNO, INVOICE_SLNO, ITEM_SLNO);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            CTH_SAFEGUARD_RATE = "0.00";
                            CTH_SAFEGUARD_RATE_UPDATE = "0.00";
                        }

                        //************** AGGREGATE NOTN RATE ***********************

                        if (PRODUCT_AGGREGATE_DUTY_NOTN != "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL != "")
                        {
                            //if (PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                            if (String.IsNullOrEmpty(PRODUCT_AGGREGATE_DUTY_NOTN_RATE))
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
                                    PRODUCT_AGGREGATE_DUTY_NOTN_RATE_UPDATE = CTH_AGGREGATE.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                }
                                else
                                {
                                    //error table here
                                    dt_error.Rows.Add(PRODUCT_AGGREGATE_DUTY_NOTN, PRODUCT_AGGREGATE_DUTY_NOTN_SL, INVOICE_SLNO, ITEM_SLNO);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            PRODUCT_AGGREGATE_DUTY_NOTN_RATE = "";
                            PRODUCT_AGGREGATE_DUTY_NOTN_RATE_UPDATE = "";
                        }

                        //-----------------Start  Addl Duty Notn Rate from master implemented on 20-02-2021----------------

                        if (PRODUCT_ADDL_DUTY_NOTN != "" && PRODUCT_ADDL_DUTY_NOTN_SLNO != "")
                        {
                            if (String.IsNullOrEmpty(PRODUCT_ADDL_DUTY_RATE))
                            {
                                var PRODUCT_ADDL_RATES = from DataRow drr in dt_All_Rates.Tables[2].AsEnumerable()
                                                         where drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN") == PRODUCT_ADDL_DUTY_NOTN && drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == PRODUCT_ADDL_DUTY_NOTN_SLNO
                                                              && drr.Field<string>("NOTIFICATION_TYPE") == "C"
                                                         select drr;

                                DataView dv_ADDL_RATE = PRODUCT_ADDL_RATES.AsDataView();

                                if (dv_ADDL_RATE.Count > 0)
                                {
                                    DataTable CTH_AGGREGATE = PRODUCT_ADDL_RATES.CopyToDataTable();
                                    PRODUCT_ADDL_DUTY_RATE = CTH_AGGREGATE.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                    PRODUCT_ADDL_DUTY_RATE_UPDATE = CTH_AGGREGATE.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                }
                                else
                                {
                                    //error table here
                                    dt_error.Rows.Add(PRODUCT_ADDL_DUTY_NOTN, PRODUCT_ADDL_DUTY_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            PRODUCT_ADDL_DUTY_RATE = "0.00";
                            PRODUCT_ADDL_DUTY_RATE_UPDATE = "0.00";
                        }


                        //-----------------Start  Social Welfare Notn Rate from master implemented on 03Feb2018----------------

                        if (SOCIAL_WELFARE_NOTN != "")
                        {
                            if (String.IsNullOrEmpty(SOCIAL_WELFARE_RATE))
                            {
                                DataView dv_SOCIAL_RATE = new DataView();
                                DataTable CTH_AGGREGATE = new DataTable();
                                string IsValid_Notn = "";

                                var PRODUCT_SOCIAL_RATES = from DataRow drr in dt_All_Rates.Tables[2].AsEnumerable()
                                                           where drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN") == SOCIAL_WELFARE_NOTN && drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == SOCIAL_WELFARE_NOTN_SLNO
                                                              && drr.Field<string>("NOTIFICATION_TYPE") == "SWS"
                                                           select drr;

                                dv_SOCIAL_RATE = PRODUCT_SOCIAL_RATES.AsDataView();

                                if (dv_SOCIAL_RATE.Count > 0)
                                {
                                    IsValid_Notn = "Y";
                                    CTH_AGGREGATE = PRODUCT_SOCIAL_RATES.CopyToDataTable();
                                }
                                else
                                {
                                    var PRODUCT_SOCIAL_RATES1 = from DataRow drr in dt_All_Rates.Tables[2].AsEnumerable()
                                                                where drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN") == SOCIAL_WELFARE_NOTN && drr.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == SOCIAL_WELFARE_NOTN_SLNO
                                                                   && drr.Field<string>("NOTIFICATION_TYPE") == "C"
                                                                select drr;

                                    dv_SOCIAL_RATE = PRODUCT_SOCIAL_RATES1.AsDataView();
                                    IsValid_Notn = "Y";
                                    CTH_AGGREGATE = PRODUCT_SOCIAL_RATES1.CopyToDataTable();
                                }


                                if (IsValid_Notn == "Y")
                                {
                                    if (dv_SOCIAL_RATE.Count > 0)
                                    {
                                        SOCIAL_WELFARE_RATE = CTH_AGGREGATE.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                        SOCIAL_WELFARE_RATE_UPDATE = CTH_AGGREGATE.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                    }
                                    else
                                    {
                                        //error table here
                                        dt_error.Rows.Add(SOCIAL_WELFARE_NOTN, SOCIAL_WELFARE_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            SOCIAL_WELFARE_RATE = "10.00";
                            SOCIAL_WELFARE_RATE_UPDATE = "10.00";
                        }

                        //----------------- End Social Welfare Notn Rate from master implemented on 03Feb2018----------------

                        //-----------------Start  AIDC Notn Rate from master implemented on 03Feb2018----------------

                        //#AIDC - Bind Rate
                        if (AIDC_NOTN != "" && AIDC_NOTN_SLNO != "")
                        {
                            DataView dv_AIDC_RATES = new DataView();
                            if (String.IsNullOrEmpty(AIDC_RATE))
                            {
                                if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                                {
                                    var PRODUCT_AIDC_RATES = from DataRow drr in dt_All_Rates.Tables[13].AsEnumerable()
                                                             where drr.Field<string>("AIDC_NOTN") == AIDC_NOTN && drr.Field<string>("AIDC_NOTN_SLNO") == AIDC_NOTN_SLNO
                                                             //&& drr.Field<string>("PRODUCT_CTH") == PRODUCT_CTH
                                                             select drr;
                                    dv_AIDC_RATES = PRODUCT_AIDC_RATES.AsDataView();

                                    if (dv_AIDC_RATES.Count > 0)
                                    {
                                        DataTable DT_AIDC_RATES = PRODUCT_AIDC_RATES.CopyToDataTable();
                                        AIDC_RATE = DT_AIDC_RATES.Rows[0]["AIDC_NOTN_RATE"].ToString();
                                        AIDC_AMT_UPDATE = DT_AIDC_RATES.Rows[0]["AIDC_NOTN_RATE"].ToString();
                                    }
                                    else
                                    {
                                        //error table here
                                        dt_error.Rows.Add(AIDC_NOTN, AIDC_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
                                        break;
                                    }
                                }
                                else
                                {
                                    var PRODUCT_AIDC_RATES = from DataRow drr in dt_All_Rates.Tables[13].AsEnumerable()
                                                             where drr.Field<string>("AIDC_NOTN") == AIDC_NOTN && drr.Field<string>("AIDC_NOTN_SLNO") == AIDC_NOTN_SLNO
                                                                && drr.Field<string>("PRODUCT_CTH") == PRODUCT_CTH
                                                             select drr;
                                    dv_AIDC_RATES = PRODUCT_AIDC_RATES.AsDataView();

                                    if (dv_AIDC_RATES.Count > 0)
                                    {
                                        DataTable DT_AIDC_RATES = PRODUCT_AIDC_RATES.CopyToDataTable();
                                        AIDC_RATE = DT_AIDC_RATES.Rows[0]["AIDC_NOTN_RATE"].ToString();
                                        AIDC_AMT_UPDATE = DT_AIDC_RATES.Rows[0]["AIDC_NOTN_RATE"].ToString();
                                    }
                                    else
                                    {
                                        AIDC_RATE = "0"; // Manually update '0' - for checklist not opening issue - Suggest by Subbu sir on 05-02-2021..
                                        //error table here
                                        dt_error.Rows.Add(AIDC_NOTN, AIDC_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
                                        
                                    }

                                }
                            }
                            else
                            {
                                AIDC_AMT_UPDATE = AIDC_RATE;
                            }
                        }
                        else
                        {
                            //AIDC_RATE = "0.00";
                            AIDC_RATE = "";
                            AIDC_AMT_UPDATE = "";
                        }

                        //------------------------------------------DATA FETCH FROM CTH MASTER------------------------------------------//
                        if (PRODUCT_BCD_NOTN.Trim() == "" && PRODUCT_BCD_NOTN_SLNO.Trim() == "" && PRODUCT_BCD_RATE.Trim() == "")
                        {
                            PRODUCT_BCD_RATE = MERIT_PRODUCT_BCD_RATE;

                            NOTIFICATION_CUSTOMS_BCD_RATE = "";
                            NOTIFICATION_CUSTOMS_CVD_RATE = "";
                        }
                        else
                        {
                            //if (String.IsNullOrEmpty(PRODUCT_BCD_RATE)) // chk if PRODUCT_BCD_RATE is empty new rate updte else maintain old rate - by Chithra on 18-12-2019
                            //{
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

                                string CTH_RATE = "";
                                NOTIFICATION_CUSTOMS_BCD_RATE = "";
                                NOTIFICATION_CUSTOMS_CVD_RATE = "";

                                if (String.IsNullOrEmpty(PRODUCT_BCD_RATE)) // chk if PRODUCT_BCD_RATE is empty new rate updte else maintain old rate - by Chithra on 18-12-2019
                                {
                                    CTH_RATE = CTH_RateS.Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                    if (CTH_RATE != "")
                                    {
                                        double CTH_RATE1 = Convert.ToDouble(CTH_RATE);

                                        CTH_RATE = Convert.ToString(Convert.ToDouble(CTH_RATE1).ToString("F"));
                                    }

                                    NOTIFICATION_CUSTOMS_BCD_RATE = CTH_RATE;
                                    PRODUCT_BCD_RATE_UPDATE = CTH_RATE;
                                    PRODUCT_BCD_RATE = CTH_RATE;

                                    NOTIFICATION_CUSTOMS_BCD_SPL = CTH_RateS.Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();

                                    NOTIFICATION_CUSTOMS_BCD_UNIT = CTH_RateS.Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                                }
                                else
                                {
                                    CTH_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_BCD_RATE).ToString("F"));

                                    NOTIFICATION_CUSTOMS_BCD_RATE = CTH_RATE;
                                    PRODUCT_BCD_RATE_UPDATE = CTH_RATE;
                                    PRODUCT_BCD_RATE = CTH_RATE;
                                    NOTIFICATION_CUSTOMS_BCD_SPL = PRODUCT_BCD_SPL;
                                    NOTIFICATION_CUSTOMS_BCD_UNIT = PRODUCT_BCD_UNIT;
                                }

                                //string CTH_spl_amt = ds_rate.Tables[0].Rows[0]["CTH_SPL_AMT"].ToString();
                                ////double CTH_spl_amt1 = Convert.ToDouble(CTH_spl_amt);
                                //if (CTH_spl_amt == "")
                                //{
                                //    CTH_spl_amt = "0";
                                //}

                                //CTH_SPL_AMT = Convert.ToString(Convert.ToDouble(CTH_spl_amt).ToString("F"));                           

                                NOTIFICATION_CUSTOMS_CVD_RATE = CTH_RateS.Rows[0]["NOTIFICATION_CUSTOMS_CVD_RATE"].ToString();
                                NOTIFICATION_FLAG = CTH_RateS.Rows[0]["NOTIFICATION_FLAG"].ToString();


                                if (NOTIFICATION_CUSTOMS_BCD_SPL == "-1.000000" || NOTIFICATION_CUSTOMS_BCD_SPL == "")
                                {
                                    NOTIFICATION_CUSTOMS_BCD_SPL = "0.00";
                                }
                                else
                                {
                                    if (PRODUCT_BCD_SPL != "")
                                    {
                                        CTH_SPL_AMT = PRODUCT_BCD_SPL;
                                        CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
                                    }
                                    else if (NOTIFICATION_CUSTOMS_BCD_SPL != "-1.000000" || NOTIFICATION_CUSTOMS_BCD_SPL != "")
                                    {
                                        CTH_SPL_AMT = NOTIFICATION_CUSTOMS_BCD_SPL;
                                        CTH_SPL_UNIT = NOTIFICATION_CUSTOMS_BCD_UNIT;

                                        PRODUCT_BCD_SPL = NOTIFICATION_CUSTOMS_BCD_SPL;
                                        PRODUCT_BCD_UNIT = NOTIFICATION_CUSTOMS_BCD_UNIT;
                                    }
                                    else
                                    {
                                        CTH_SPL_AMT = "-1.000000";
                                    }

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
                                    break;
                                }
                            }
                            //}//-- END - check PRODUCT_BCD_RATE NULL OR EMPTY
                            //else
                            //{
                            //    PRODUCT_BCD_RATE_UPDATE = PRODUCT_BCD_RATE;
                            //}
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
                                    if (PRODUCT_TARIFF_AMOUNT != "")
                                    {
                                        PRODUCT_TARIFF_AMOUNT_UPDATE = Convert.ToString((Math.Round(Convert.ToDouble(PRODUCT_TARIFF_AMOUNT), 2)).ToString("0.00"));
                                    }
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
                                break;
                            }
                        }
                        else
                        {
                            PRODUCT_TARIFF_AMOUNT_UPDATE = "";
                        }

                        //---------------TARIFF CALCULATION----------------------------//
                        double tariff_amt = 0.00;
                        string inv_exrate = ds.Rows[C]["INVOICE_EXRATE"].ToString();


                        if (PRODUCT_TARIFF_NOTN.Trim() != "" && PRODUCT_TARIFF_SLNO.Trim() != "")
                        {
                            if ((PRODUCT_TARIFF_NOTN.Trim() == "36/2001") && (PRODUCT_TARIFF_SLNO.Trim() == "2(1)A" || PRODUCT_TARIFF_SLNO.Trim() == "2(2)A" || PRODUCT_TARIFF_SLNO.Trim() == "2(1)" || PRODUCT_TARIFF_SLNO.Trim() == "2(2)" || PRODUCT_TARIFF_SLNO.Trim() == "2(3)" || PRODUCT_TARIFF_SLNO.Trim() == "2(4)" || PRODUCT_TARIFF_SLNO.Trim() == "2(4)(i)" || PRODUCT_TARIFF_SLNO.Trim() == "2(4)(ii)"))       
                            {
                                if (PRODUCT_TARIFF_AMOUNT != "")
                                {
                                    if (Convert.ToDecimal(PRODUCT_TARIFF_AMOUNT) >= 0)
                                    {
                                        //if (PRODUCT_TARIFF_SLNO.Trim() == "2(4)i")// This new modification implemented on 02-July-2021 with Bala for Group A Logistics (ERI00576)
                                        //{
                                        //    tariff_amt = Convert.ToDouble(PRODUCT_TARIFF_QTY) * Convert.ToDouble(PRODUCT_TARIFF_AMOUNT) * Convert.ToDouble(inv_exrate)*10;
                                        //}
                                        //else
                                        //{
                                        //    tariff_amt = Convert.ToDouble(PRODUCT_TARIFF_QTY) * Convert.ToDouble(PRODUCT_TARIFF_AMOUNT) * Convert.ToDouble(inv_exrate);
                                        //}

                                        Auto_Search auto = new Auto_Search();
                                        DataSet ds_exrate = new DataSet();
                                        auto.Enamesearch = "USD";//Get USD Exrate from Admin Master
                                        auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
                                        ds_exrate = auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                                        // hide on 21-02-2025 Sugg.by Bala sir for M>D.Overseas - should not calc with Invoice Currecncy
                                        // tariff_amt = Convert.ToDouble(PRODUCT_TARIFF_QTY) * Convert.ToDouble(PRODUCT_TARIFF_AMOUNT) * Convert.ToDouble(inv_exrate);
                                        if (ds_exrate.Tables[0].Rows.Count > 0)
                                        {
                                            tariff_amt = Convert.ToDouble(PRODUCT_TARIFF_QTY) * Convert.ToDouble(PRODUCT_TARIFF_AMOUNT) * Convert.ToDouble(ds_exrate.Tables[0].Rows[0][0].ToString());
                                        }

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
                                        tariff_amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_TARIFF_AMOUNT) * Convert.ToDouble(inv_exrate);
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

                                string CETH_Rate = "";
                                if (String.IsNullOrEmpty(CHECKLIST_CVD_RATE)) // chk if CHECKLIST_CVD_RATE is empty new rate updte else maintain old rate - by Chithra on 18-12-2019
                                {

                                    CETH_Rate = CETH_RateS.Rows[0]["CETH_RATE"].ToString();
                                    double CETH_Rate1 = Convert.ToDouble(CETH_Rate);
                                    MERIT_PRODUCT_CVD_RATE = Convert.ToString(Convert.ToDouble(CETH_Rate1).ToString("F"));
                                }
                                else
                                {
                                    CETH_Rate = CHECKLIST_CVD_RATE;
                                    double CETH_Rate1 = Convert.ToDouble(CETH_Rate);
                                    MERIT_PRODUCT_CVD_RATE = Convert.ToString(Convert.ToDouble(CETH_Rate1).ToString("F"));
                                }

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

                                CETH_CESS_UQC = CETH_RateS.Rows[0]["CETH_CESS_UQC"].ToString();

                                CETH_NCD_RATE = CETH_RateS.Rows[0]["CETH_NCD_RATE"].ToString();
                                CETH_NCD_SPL_DUTY = CETH_RateS.Rows[0]["CETH_NCD_SPL_DUTY"].ToString();
                                CETH_NCD_SPL_UNIT = CETH_RateS.Rows[0]["CETH_NCD_SPL_UNIT"].ToString();
                                CETH_FLAG = CETH_RateS.Rows[0]["CETH_FLAG"].ToString();
                                CETH_SIA_I_RATE = CETH_RateS.Rows[0]["CETH_SIA_I_RATE"].ToString();
                                CETH_CATEGORY = CETH_RateS.Rows[0]["CETH_CATEGOTY"].ToString();
                                CETH_IGST_YN = CETH_RateS.Rows[0]["IGST_YN"].ToString();
                                CETH_ADDL_DUTY_IMPORTS_YN = CETH_RateS.Rows[0]["ADDL_DUTY_IMPORTS_YN"].ToString();
                                CETH_CVD_NIL_YN = CETH_RateS.Rows[0]["CVD_NIL_YN"].ToString();
                                CIGARATTE_RITC_YN = CETH_RateS.Rows[0]["CIGARATTE_RITC_YN"].ToString();
                                CETH_EXEC_AIDC_RATE = CETH_RateS.Rows[0]["EXEC_AIDC_RATE"].ToString();
                                EXC_AIDC_RATE = CETH_EXEC_AIDC_RATE;
                            }
                            else
                            {
                                dt_error.Rows.Add(PRODUCT_CETH, "CETH", INVOICE_SLNO, ITEM_SLNO);
                                break;
                            }
                        }

                        //------------------------------------------DATA FETCH FROM CETH MASTER------------------------------------------//

                        //------------------Start Exclusive for Indev Logistics on 05Feb2016-----------------------------//

                        var PRODUCT_CETH_24_27 = from DataRow drr in dt_All_Rates.Tables[11].AsEnumerable()
                                                 where drr.Field<string>("CETH_CODE") == PRODUCT_CETH
                                                 select drr;

                        DataView dv_CETH_24_27 = PRODUCT_CETH_24_27.AsDataView();

                        if (dv_CETH_24_27.Count > 0)
                        {
                            PRODUCT_CETH_CHAPTER = PRODUCT_CETH;
                        }
                        else
                        {
                            PRODUCT_CETH_CHAPTER = "NOEXCISE";
                        }
                        // Fairmacs - Cigaratte RITC - ON 12-09-2019 by Chithra
                        //if ((COMPANY_ID == "1" || COMPANY_ID == "4" || COMPANY_ID == "125") && (PRODUCT_CETH == "24029090" || PRODUCT_CETH == "24022090"))
                        //if (PRODUCT_CETH == "24022090" || PRODUCT_CETH == "24012090" || PRODUCT_CETH == "24012010" || PRODUCT_CETH == "24012040" || PRODUCT_CETH == "27101241")
                        if (CETH_CATEGORY == "RITC")
                        {
                            PRODUCT_CETH_CHAPTER = PRODUCT_CETH;
                        }

                        //if (PRODUCT_CETH.Substring(0, 2) == "24")// hide by Chithra on 06-08-2019 for 24,27 Chapter HPCL
                        //if (PRODUCT_CETH_CHAPTER != "NOEXCISE")//hide on 04-09-2024 for Sudharsan Cargo Sugg.by Bala sir & mohmed
                        //{
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
                                        string PRODUCT_CVD_NOTN1 = CVD[0];

                                        var PRODUCT_CVD_RATES = from DataRow drr in dt_All_Rates.Tables[7].AsEnumerable()
                                                                where drr.Field<string>("NOTIFICATION_EXCISE_NOTN") == PRODUCT_CVD_NOTN1 && drr.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == PRODUCT_CVD_NOTN_SLNO
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
                        //}
                        //else
                        //{
                        //    PRODUCT_CVD_RATE = "0.00";
                        //}

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
                            double merit_bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
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

                        //if (PRODUCT_CETH.Substring(0, 2) != "24")// hide by Chithra on 06-08-2019 for 24,27 Chapter HPCL
                        //{
                        //    MERIT_CVD = 0.00;
                        //    MERIT_PRODUCT_CVD_RATE = "0.00";
                        //}

                        if (PRODUCT_CETH_CHAPTER == "NOEXCISE")
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
                                MERIT_CESS = c_ITEM_QTY * Convert.ToDouble(CETH_CESS_AMTS);
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

                           // ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "          " + TOTAL_ANTI_AMT;
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




                        //---------------- NOTE ----------------------//

                        //Reference - RITC Chapters description
                        //CIGARETTES, OF TOBACCO OR OF TOBACCO SUBSTITUTES
                        //24022090

                        //PETROLEUM OILS AND OILS OBTAINED FROM BITUMINOUS MINERALS
                        //27101930,27101949,27101290

                        //---------------- NOTE ----------------------//


                        string[] arr = { "DEEC", "REP", "DIL", "JBG", "EOU", "DUTIABLE" };
                        string[] arr1 = { "DEPB", "DFRC", "DFCC", "TRG+", "(KRSH)", "DFCS", "DFIA", "FMS", "FPS", "SHIS", "MEIS", "INC", "SEIS", "ROSCTL", "RoDTEP Scheme", "ROSCTL Scheme", "MEIS eCom", "Tariff Quota", "Restricted Items", "Restricted Items", "Post Export EPCG" };
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
                                        var PRODUCT_CTH_24_27 = from DataRow drr in dt_All_Rates.Tables[10].AsEnumerable()
                                                                where drr.Field<string>("CTH_CODE") == PRODUCT_CTH
                                                                select drr;

                                        DataView dv_CTH_24_27 = PRODUCT_CTH_24_27.AsDataView();

                                        if (dv_CTH_24_27.Count > 0)
                                        {
                                            Scheme_DUTIABLE_Chapter_24_27();
                                            //PRODUCT_CETH_CHAPTER = PRODUCT_CETH;//hide on 23-10-2024 for New Settings
                                        }
                                        //Fairmacs - Cigaratte RITC - ON 12-09-2019 by Chithra
                                        //else if (PRODUCT_CETH == "24022090" || PRODUCT_CETH == "24039100" || PRODUCT_CETH == "24011090" || PRODUCT_CETH == "24012090" || PRODUCT_CETH == "24012010" || PRODUCT_CETH == "24012040" || PRODUCT_CETH == "27101241")
                                        if (CIGARATTE_RITC_YN == "Y")
                                        {
                                            Scheme_DUTIABLE_CIGARETTE_Calc(); // Implemented for Fairmacs on 12-09-2019 by Chithra
                                        }
                                        else
                                        {
                                            Scheme_DUTIABLE();
                                            //PRODUCT_CETH_CHAPTER = "NOEXCISE";//hide on 23-10-2024 for New Settings
                                        }
                                    }
                                }
                                else if (SCHEME_NOTN_ == "REP" || SCHEME_NOTN_ == "DIL" || SCHEME_NOTN_ == "JBG" || SCHEME_NOTN_ == "EOU")
                                {
                                    // REP & DIL & JBG & EOU
                                    Scheme_SAME_CODE_GENERAL_CALC();
                                }
                            }
                            else if (SCHEME_NOTN_ == "EPCG")
                            {
                                Scheme_EPCG(dss1.Tables[0], adm_Mas);
                            }
                            else if (SCHEME_NOTN_.Trim() == "Post Export EPCG")
                            {
                                Scheme_Post_Export_EPCG(dss1);
                            }
                            //else if (SCHEME_NOTN_.Trim() == "Project Imports" || SCHEME_NOTN_.Trim() == "RoDTEP Scheme" || SCHEME_NOTN_.Trim() == "ROSL Scheme")//16-11-2021
                            else if (SCHEME_NOTN_.Trim() == "Project Imports")
                            {
                                Scheme_DUTIABLE();
                                PRODUCT_CETH_CHAPTER = "NOEXCISE";
                            }
                            else if (SCHEME_NOTN_.Trim() == "Restricted Items")
                            {
                                Scheme_14_RestrictedItems();
                            }
                            else if (SCHEME_NOTN_.Trim() == "RoDTEP Scheme" && CIGARATTE_RITC_YN == "Y")
                            {
                                Scheme_DUTIABLE_CIGARETTE_Calc();
                            }

                            else
                            {
                                //MEIS & SEIS

                                if (SCHEME_NOTN_ == value2)
                                {
                                    if (dss1.Tables[0].Rows.Count > 0)
                                    {
                                        EXCEMPTION = dss1.Tables[0].Rows[0]["EXCEMPTION"].ToString();

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
                                        Healthcess_RateVal = 0.00;
                                        BCD_FG_AMT = 0.00;
                                        IGST_FG_AMT = 0.00;
                                        SWS_FG_AMT = 0.00;

                                        /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                                        HEALTH_CESS_TOTAL = "0.00";
                                        if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                                        {
                                            if (HEALTH_CESS_CTH_CODE != "")
                                            {
                                                Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                                                //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                            }
                                        }
                                        if (SCHEME_NOTN_ == "RoDTEP Scheme") // Added by pandiyan on 10-09-2026
                                        {
                                            if (HEALTH_CESS_RATE != "")
                                            {
                                                Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                                            }
                                        }

                                        //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
                                        Get_Less_Sapta_Rate();

                                        //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                                        AIDC_Amt = NOTN_AIDC_CALC();

                                        //#SWS
                                        if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                                        {
                                            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }
                                        else
                                        {
                                            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                            //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }

                                        //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                                        Actual_BASIC_DUTY = BASIC_DUTY;

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
                                        HEALTH_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Healthcess_RateVal), 1).ToString("0.00"));//30-10-2020
                                        AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));//01-feb-2021

                                        //-----------------------CALCULATION FOR TOTAL DEBIT DUTY--------------------------------//

                                        double bcd_rate = 0.00;

                                        if (PRODUCT_BCD_RATE != "")
                                        {
                                            bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                                        }

                                        double TRQ_rate = 0.00;
                                        //if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III")) hided by pandiyan on 19-06-2025 sugg by bala 
                                        if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "062/2022") && (SCHEME_NOTN_SLNO.Contains("III") || SCHEME_NOTN_SLNO.Contains("IV")))
                                        {
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
                                                    
                                                    if (SCHEME_Rate == "")
                                                    {
                                                        SCHEME_Rate = "0";
                                                    }
                                                    TRQ_rate = Convert.ToDouble(SCHEME_Rate);
                                                }
                                            }

                                            Scheme_Notn_BCD_Amt = ASSESABLE_VALUE * TRQ_rate / 100; 
                                        }
                                        else
                                        {
                                            if (PRODUCT_BCD_RATE != "")
                                            {
                                                bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                                            }
                                        }




                                        //TRQ-Calc
                                        if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "062/2022" && SCHEME_NOTN_SLNO.Contains("III"))
                                        {
                                            if (PRODUCT_BCD_RATE != "")
                                            {
                                                Scheme_Notn_BCD_Rate = Convert.ToDouble(PRODUCT_BCD_RATE) / 2;
                                                Scheme_Notn_BCD_Amt = ASSESABLE_VALUE * Convert.ToDouble(Scheme_Notn_BCD_Rate) / 100;
                                            }
                                        }

                                        //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

                                        if (PRODUCT_BCD_NOTN != "")
                                        {
                                            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
                                            {
                                                //NOTIFICATION_CUSTOMS_BCD_RATE = "";

                                                //--if "NOTIFICATION_CUSTOMS_BCD_SPL" is "0" "CTH_SPL_AMT" - should be "0" - confirmed with Final Print for Aeroship.. sugg.By Bala Sir on 20-03-2021
                                                //if (Session["COMPANY_ID"].ToString() == "145" || Session["COMPANY_ID"].ToString() == "262" || Session["COMPANY_ID"].ToString() == "184" || Session["COMPANY_ID"].ToString() == "223" || Session["COMPANY_ID"].ToString() == "224" || Session["COMPANY_ID"].ToString() == "164" || Session["COMPANY_ID"].ToString() == "1026" || Session["COMPANY_ID"].ToString() == "1048")
                                                //{
                                                    CTH_SPL_AMT = "0";
                                                //}
                                            }
                                        }

                                        //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

                                        if (COMPANY_ID == "224")
                                        {
                                            if (NOTIFICATION_CUSTOMS_BCD_SPL == "-1.000000" || NOTIFICATION_CUSTOMS_BCD_SPL == "")
                                            {
                                            }
                                            else
                                            {
                                                CTH_SPL_AMT = NOTIFICATION_CUSTOMS_BCD_SPL;
                                            }
                                        }

                                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                                        {
                                            BASIC_DUTY = bcd_rate;
                                        }
                                        else
                                        {
                                            double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                                            //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                                            double cth_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);

                                            if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                                            {
                                                if (cth_Amt <= bcd_rate)
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }
                                                else
                                                {
                                                    if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                                                    {
                                                        BASIC_DUTY = bcd_Amt;
                                                    }
                                                    else
                                                    {
                                                        BASIC_DUTY = bcd_rate;
                                                    }
                                                }
                                            }
                                            else if (NOTIFICATION_FLAG == "+")
                                            {
                                                if (bcd_rate >= bcd_Amt)
                                                {
                                                    BASIC_DUTY = cth_Amt + bcd_rate;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = cth_Amt + bcd_Amt;
                                                }
                                            }
                                            else //-- NOTIFICATION_FLAG == "H" or others
                                            {
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
                                        }

                                        if (PRODUCT_BCD_SPL != "")
                                        {
                                            if (Convert.ToDouble(PRODUCT_BCD_SPL) != 0.000000 || Convert.ToDouble(PRODUCT_BCD_SPL) != 000000)
                                            {
                                                double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                                                double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                                                bcd_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_BCD_SPL);

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

                                                if (COMPANY_ID == "313")
                                                {
                                                    if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                                                    {
                                                        BASIC_DUTY = cth_Amt;
                                                    }
                                                }

                                                //BASIC_DUTY_BCD_SPL = cth_Amt;
                                                //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                                                CTH_SPL_AMT = PRODUCT_BCD_SPL;
                                                CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
                                            }
                                        }

                                        //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

                                        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);
                                        

                                        //---------------END SAPTA CALCULATION-------------------------//

                                        //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
                                       		//based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
                                        if (PRODUCT_BCD_NOTN != "")
                                        {
                                            BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
                                            BCD_FOREGONE_AMT = Convert.ToString(Math.Round(BCD_FG_AMT, 1).ToString("0.00"));
                                        }
                                        else
                                        {
                                            BCD_FG_AMT = BASIC_DUTY;
                                            BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
                                        } 
                                        //--------------------------------------------


                                        //-----------------------------END NCD CALCULATION---------------------------------------//      
                                        //hide on 20-01-2026
                                        //CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;


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
                                            if (PRODUCT_CVD_NOTN == "003/2025 1")
                                            {
                                                double CVD_Calc1 = 0.00, Individual_CVD = 0.00;
                                                CVD_Calc1 = ASSESABLE_VALUE + BASIC_DUTY;
                                                Individual_CVD = CVD_Calc1 / Convert.ToDouble(CTH_QTY) / EXCHANGE_RATE;
                                                CVD_Calc1 = Convert.ToDouble(PRODUCT_CVD_SPL) - Individual_CVD;

                                                if (CVD_Calc1 < 0)
                                                {
                                                    CVD_Amt = 0.00;
                                                }
                                                else
                                                {
                                                    CVD_Amt = CVD_Calc1 * Convert.ToDouble(CTH_QTY) * EXCHANGE_RATE;
                                                }
                                            }
                                            else if (Convert.ToDouble(PRODUCT_CVD_SPL) != 0.00 || Convert.ToDouble(PRODUCT_CVD_SPL) != 0)
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

                                        if (CVD_Rate >= CVD_Amt)
                                        {
                                            CVD = CVD_Rate;
                                        }
                                        else
                                        {
                                            CVD = CVD_Amt;
                                        }


                                        //if (RSP_APPLICABLE == "Y")RSP condition 
                                        CESS = 0.00;
                                        
                                        
                                        if (CETH_CVD_NIL_YN == "Y")
                                        {
                                            CVD = 0.00;
                                            CVD_TOTAL = "0.00";
                                            PRODUCT_CVD_RATE = "0.00";
                                        }

                                        //#SWS
                                        if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                                        {
                                            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }
                                        else
                                        {
                                            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }

                                        //--------------SWS FOREGONE AMOUNT----By Chithra on 24-11-2025 for Capricorn-----------
                                        //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
                                        SWS_FOREGONE_AMT = "0.00";

                                        if (SCHEME_NOTN_ != "DFIA" && SCHEME_NOTN_ != "DFRC" && SCHEME_NOTN_ != "Tariff Quota")
                                        {
                                            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Customs_Social_welfare, 2).ToString("F"));
                                        }

                                        if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III")) 
                                        {
                                            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Customs_Social_welfare, 2).ToString("F"));
                                            Scheme_Notn_SWS_Amt = (Scheme_Notn_BCD_Amt + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }

                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                                        AddL_DUTY = 0.00;
                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                                        Actual_BASIC_DUTY = BASIC_DUTY;

                                        //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//
                                        if (COMPANY_ID == "247" || COMPANY_ID == "10")
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

                                        //---------------Start Other CVD Duty Calculation On 02June2015(Boxco)---------------//

                                        if (PRODUCT_OTHER_DUTY_RATE != "")
                                        {
                                            //Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT-- hide on 05-03-2024

                                            /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                            if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                            {
                                                Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                            }
                                            else
                                            {
                                                Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                            }
                                            */
                                            Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;

                                            PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));
                                        }
                                        else if (PRODUCT_OTHER_DUTY_SPL != "")
                                        {
                                            Other_duty = c_ITEM_QTY * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
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

                                        //------------New Anti-Dumping Calculation implemented on 06Oct2018------------//
                                        string TOTAL_ANTI_AMT_LICNESE;

                                        if (ANTI_AMTS != null && ANTI_AMTS != "")
                                        {
                                            if (ADD_AMT_MINUS_ASSESABLE == "1")
                                            {
                                                //hide on 07-10-2022 done by Chithra sugg.by Bala sir for Premji Kanji
                                                //TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);

                                                if (SCHEME_NOTN_ == "RoDTEP Scheme" || SCHEME_NOTN_ == "ROSCTL Scheme")
                                                {
                                                    TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY);
                                                }
                                                else
                                                {
                                                    TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);
                                                }

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

                                            //this line newly by Chithra on 23-06-2020 sugg by bala sir for PARAMOUNT gowri Anti dupming Amt should add with Customs Duty
                                            TOTAL_ANTI_AMT = MERIT_TOTAL_ANTI_AMT;

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

                                                    //hide on 05-03-2024 Sugg.by Bala Sir
                                                    //double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                    double Anti_Dump_Cal2 = 0.00;
                                                   /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                   if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                   {
                                                       Anti_Dump_Cal2 = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                   }
                                                   else
                                                   {
                                                       Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                   }
                                                     */
                                                    Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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

                                                 /* hide on 05-11-2024 - Sugg.by Bala sir
                                                TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY)) / 100;
                                                MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY)) / 100;
                                                  * */

                                                if (ANTI_DUMPING_NOTN == "015/2023" || ANTI_DUMPING_NOTN == "017/2023" || ANTI_DUMPING_NOTN == "011/2024" || ANTI_DUMPING_NOTN == "006/2025" || ANTI_DUMPING_NOTN == "021/2025" || ANTI_DUMPING_NOTN == "004/2025")// Sugg.By Bala sir on 22-02-2024 for OECL Shipping 
                                                {
                                                    TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                                                    MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                                                }
                                                else
                                                {
                                                    //this calc newly added sugg.by Bala sir done by Chithra on 23/12/2020
                                                    TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                                                    MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt)) / 100;
                                                }

                                                TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                                                MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                                            }

                                            //this line newly by Chithra on 23-06-2020 sugg by bala sir for PARAMOUNT gowri Anti dupming Amt should add with Customs Duty
                                            TOTAL_ANTI_AMT = MERIT_TOTAL_ANTI_AMT;

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


                                            //this line newly by Chithra on 23-06-2020 sugg by bala sir for PARAMOUNT gowri Anti dupming Amt should add with Customs Duty
                                            TOTAL_ANTI_AMT = MERIT_TOTAL_ANTI_AMT;

                                            //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                                            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "      " + CTH_QTY + "      " + " " + ADD_DIFF_CUR + "%" + " " + TOTAL_ANTI_AMT;

                                        }
                                        //------------End Anti-Dumping Calculation implemented on 06Oct2018------------//

                                        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
                                        Call_IGST_General();


                                        CHK_IGST_ASSBL_VAL = 0.00;
                                        if (RSP_APPLICABLE == "S" && (MRP_AMT > IGST_LEV_1_AMT_ASS))
                                        {
                                            CHK_IGST_ASSBL_VAL = MRP_AMT; //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                                            tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                                        }
                                        else
                                        {
                                            if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                                            {
                                                CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
                                            }
                                            else
                                            {
                                                CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt + SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT); //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                                            }
                                            tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                                        }

                                        //for SWS - without Health Cess, Basic Duty only add with License debit duty - sugg by Bala sir & Subbu sir on 30-10-2020
                                        double Customs_SWS_HealthCess = 0.00;
                                        if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                                        {
                                            if (HEALTH_CESS_CTH_CODE != "")
                                            {
                                                Customs_SWS_HealthCess = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                            }
                                        }

                                        if (SCHEME_NOTN_ != "DFIA" && SCHEME_NOTN_ != "DFRC" && SCHEME_NOTN_ != "Tariff Quota")
                                        {
                                            //hide on 28-11-2020 for Dial Ess-sugg.by Subbu sir & Bala sir done by Chithra
                                            //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS).ToString("0.00"));

                                            //Again condition changed on 21-05-2021 for Guru Shipping sugg.by Subbu sir & Bala sir - Anti Dumping Should not add with MEIS License- done by Chithra 
                                            //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)).ToString("0.00"));

                                            //Again condition changed on 07-06-2021 for SANCO sugg.by Mohmed done by Chithra & Sathish sir
                                            TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS).ToString("0.00"));
                                        }
                                        else
                                        {
                                            //TRQ-Calc ---for 32- Tariff Quota - BASIC Duty should be divided by 2 sugg.by Bala & Subbu sir on 30-08-2023 Implemntd by Chithra
                                            if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "062/2022" && SCHEME_NOTN_SLNO.Contains("III"))
                                            {
                                                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt + Convert.ToDouble(AIDC_EXEC_AMT)).ToString("0.00"));
                                            }
                                            else if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III") && HttpContext.Current.Session["COMPANY_ID"].ToString() == "1217")
                                            {
                                                //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Scheme_Notn_SWS_Amt + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
                                                DIFF_AMT_BDC_TRQ = Convert.ToString((Convert.ToDouble(BASIC_DUTY)) - Convert.ToDouble(Scheme_Notn_BCD_Amt));
                                                DIFF_AMT_BDC_TRQ_SW = Convert.ToString(Convert.ToDouble(DIFF_AMT_BDC_TRQ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100);
                                                TOTAL_DEBIT_DUTY = Convert.ToString((Convert.ToDouble(DIFF_AMT_BDC_TRQ)) + Convert.ToDouble(DIFF_AMT_BDC_TRQ_SW));
                                            }
                                            else if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III"))
                                            {
                                                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
                                            }
                                            else
                                            {
                                                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt + Convert.ToDouble(AIDC_EXEC_AMT)).ToString("0.00"));
                                            }
                                               

                                            /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                                            if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                                            {
                                                if (HEALTH_CESS_CTH_CODE != "")
                                                {
                                                    TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS + Customs_SWS_HealthCess).ToString("0.00"));
                                                }
                                            }
                                        }
                                      
                                    }
                                    else // MEIS WITHOUT LICENSE ENTRY START
                                    {
                                        //BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                                        double bcd_rate = 0.00;
                                        if (PRODUCT_BCD_RATE != "")
                                        {
                                            bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                                        }

                                       
                                        //TRQ-Calc - done by Chithra, Sugg.by Bala sir on 17-11-2023 - Final Print checked wirh Seaswan shipping
                                        if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO == "III5")
                                        {
                                            double TRQ_rate = 0.00;
                                            TRQ_rate = Convert.ToDouble(PRODUCT_BCD_RATE) - 1;

                                            bcd_rate = ASSESABLE_VALUE * TRQ_rate / 100; // set 3%
                                            Scheme_Notn_BCD_Amt = bcd_rate;
                                        }
                                        else if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III3"))
                                        {
                                            bcd_rate = ASSESABLE_VALUE * 5 / 100; // set 5%
                                            Scheme_Notn_BCD_Amt = bcd_rate;
                                        }
                                        else if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III"))
                                        {
                                            bcd_rate = ASSESABLE_VALUE * 3 / 100; // set 3%
                                            Scheme_Notn_BCD_Amt = bcd_rate;
                                        }
                                        else
                                        {
                                            if (PRODUCT_BCD_RATE != "")
                                            {
                                                bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                                            }
                                        }


                                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                                        {
                                            //CTH_SPL_AMT = "";
                                            BASIC_DUTY = bcd_rate;
                                        }
                                        else
                                        {
                                            double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                                            //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                                            double cth_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);


                                            if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                                            {
                                                if (cth_Amt <= bcd_rate)
                                                {
                                                    BASIC_DUTY = cth_Amt;
                                                }
                                                else
                                                {
                                                    //BASIC_DUTY = bcd_Amt;
                                                    if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                                                    {
                                                        BASIC_DUTY = bcd_Amt;
                                                    }
                                                    else
                                                    {
                                                        BASIC_DUTY = bcd_rate;
                                                    }
                                                }
                                            }
                                            else if (NOTIFICATION_FLAG == "+")
                                            {
                                                if (bcd_rate >= bcd_Amt)
                                                {
                                                    BASIC_DUTY = cth_Amt + bcd_rate;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = cth_Amt + bcd_Amt;
                                                }
                                            }
                                            else //-- NOTIFICATION_FLAG == "H" or others
                                            {
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
                                        }
                                        //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
                                        Get_Less_Sapta_Rate();

                                        //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

                                        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

                                        //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
                                        BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
                                        BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
                                        //--------------------------------------------


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
                                        double CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT);

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
                                      
                                        if (CETH_CVD_NIL_YN == "Y")
                                        {
                                            CVD = 0.00;
                                            CVD_TOTAL = "0.00";
                                            PRODUCT_CVD_RATE = "0.00";
                                        }

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

                                        //-------HEALTH CESS CALCULATION
                                        HEALTH_CESS_TOTAL = "0.00";
                                        Healthcess_RateVal = 0.00;
                                        if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                                        {
                                            if (HEALTH_CESS_CTH_CODE != "")
                                            {
                                                Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                                                HEALTH_CESS_TOTAL = Convert.ToString(Healthcess_RateVal);
                                            }
                                        }

                                        //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                                        AIDC_Amt = NOTN_AIDC_CALC();

                                        //#SWS
                                        if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                                        {
                                            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }
                                        else
                                        {
                                            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }


                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                                        AddL_DUTY = 0.00;
                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                                        SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

                                        //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                                        Actual_BASIC_DUTY = BASIC_DUTY;

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
                                        AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));//01-feb-2021

                                        //TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Conv

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

                                                    TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                                                    TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));

                                                    //hide on 05-03-2024 Sugg.by Bala Sir
                                                    //double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                    double Anti_Dump_Cal2 = 0.00;
                                                    /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                  if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                  {
                                                      Anti_Dump_Cal2 = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                  }
                                                  else
                                                  {
                                                      Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                  }
                                                    */
                                                    Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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

                                                 /* hide on 05-11-2024 - Sugg.by Bala sir
                                                TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                                                MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                                                  * */

                                                if (ANTI_DUMPING_NOTN == "015/2023" || ANTI_DUMPING_NOTN == "017/2023" || ANTI_DUMPING_NOTN == "011/2024" || ANTI_DUMPING_NOTN == "006/2025" || ANTI_DUMPING_NOTN == "021/2025" || ANTI_DUMPING_NOTN == "004/2025")// Sugg.By Bala sir on 22-02-2024 for OECL Shipping 
                                                {
                                                    TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                                                    MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                                                }
                                                else
                                                {
                                                    //this calc newly added sugg.by Bala sir done by Chithra on 23/12/2020
                                                    TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                                                    MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt)) / 100;
                                                }
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
                                                TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble((ADD_DIFF_CUR)) / 100;

                                                if (TOTAL_ANTIDUMP_AMT <= 0)
                                                {
                                                    TOTAL_ANTIDUMP_AMT = 0.00;
                                                }
                                                TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                                                MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                                            }

                                            //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                                            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "      " + CTH_QTY + "      " + " " + ADD_DIFF_CUR + "%" + " " + TOTAL_ANTIDUMP_AMT;

                                        }
                                        //------------End Anti-Dumping Calculation implemented on 06Oct2018------------//

                                        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
                                        Call_IGST_General();

                                        CHK_IGST_ASSBL_VAL = 0.00;
                                        if (RSP_APPLICABLE == "S" && (MRP_AMT > IGST_LEV_1_AMT_ASS))
                                        {
                                            CHK_IGST_ASSBL_VAL = MRP_AMT; //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                                            tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                                        }
                                        else
                                        {
                                            if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                                            {
                                                CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
                                            }
                                            else
                                            {
                                                CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt + SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT); //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                                            }
                                            tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                                        }
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
                                double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
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

                            //-------HEALTH CESS CALCULATION
                            HEALTH_CESS_TOTAL = "0.00";
                            Healthcess_RateVal = 0.00;
                            if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                            {
                                if (HEALTH_CESS_CTH_CODE != "")
                                {
                                    Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                                    HEALTH_CESS_TOTAL = Convert.ToString(Healthcess_RateVal);
                                }
                            }

                            //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
                            Get_Less_Sapta_Rate();

                            //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                            AIDC_Amt = NOTN_AIDC_CALC();
 
                            //SOCIAL WELFARE CALCULATION

                            if (SOCIAL_WELFARE_NOTN != "")
                            {
                                SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                            }



                            //-----------------------------NCD CALCULATION---------------------------------------//
                            NCD = 0.00;
                            //-----------------------------END NCD CALCULATION---------------------------------------//      

                            // CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                            double CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                            double CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT);

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

                            //#SWS
                            if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                            {
                                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                            }
                            else
                            {
                                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                            }

                            //IGST ASSESABLE VALUE SHOWS IN CHECKLIST - BY CHITHRA ON 05/05/2018
                            CHK_IGST_ASSBL_VAL = 0.00;


                            if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                            {
                                CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
                            }
                            else
                            {
                                CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + AIDC_Amt;
                            }
                            tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);

                            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                            AddL_DUTY = 0.00;
                            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                            //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                            SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

                            //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                            Actual_BASIC_DUTY = BASIC_DUTY;

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
                            AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));//01-feb-2021

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


                        if (PRODUCT_CETH_CHAPTER == "NOEXCISE")
                        {
                            CVD_TOTAL = "0";
                            CVD = 0.00;
                            PRODUCT_CVD_RATE = "0.00";
                            PRODUCT_CETH = "NOEXCISE";
                        }



                        if (IGST_LEVY_EXCEPTION_NOTN == "104/94" || IGST_LEVY_EXCEPTION_NOTN == "051/96" || IGST_LEVY_EXCEPTION_NOTN == "084/97" || IGST_LEVY_EXCEPTION_NOTN == "153/94" || IGST_LEVY_EXCEPTION_NOTN == "084/71")
                        {
                            if (LEVY_EXCEMPTION_NOTN_TYPE == "C")
                            {
                                IGST_LEVY_TOTAL = "0.00";
                            }
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

                        //TRQ-Calc
                        if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "062/2022" && SCHEME_NOTN_SLNO.Contains("III"))
                        {
                            BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Scheme_Notn_BCD_Amt), 1).ToString("0.00"));
                        }

                        if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III"))
                        {
                            BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Scheme_Notn_BCD_Amt), 1).ToString("0.00"));
                            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Scheme_Notn_SWS_Amt), 1).ToString("0.00"));
                        }


                        TOTAL_CUSTOMS_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL) + Convert.ToDouble(AIDC_EXEC_AMT));
                        TOTAL_IGST_DUTY = Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL);

                        //TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL));
                       // TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL));
                        //TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL) + Convert.ToDouble(HEALTH_CESS_TOTAL));

                        if (SCHEME_NOTN_ == "MEIS" || SCHEME_NOTN_ == "SEIS" || SCHEME_NOTN_ == "MEIS eCom")
                        {
                            /* hide by chithra on 09-04-2022 Sugg.by bala sir - ADD Duty should be Add with Total Customs Duty
                            if (COMPANY_ID == "572") // TOTAL_ANTI_AMT should add sugg.by Bala sir for Excel Maritime on 17-08-2021 by Chithra
                            {
                                TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(AGGREGATE_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL) + Convert.ToDouble(AIDC_EXEC_AMT));
                            }
                            else
                            {
                                TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(AGGREGATE_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL) + Convert.ToDouble(AIDC_EXEC_AMT));
                            }
                             * */

                           // TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(AGGREGATE_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL) + Convert.ToDouble(AIDC_EXEC_AMT));
                            TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL) + Convert.ToDouble(AIDC_EXEC_AMT));

                        }
                        else
                        {
                           // TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(AGGREGATE_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL) + Convert.ToDouble(AIDC_EXEC_AMT));
                            TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL)  + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL) + Convert.ToDouble(AIDC_EXEC_AMT));

                        }

                        if (SCHEME_NOTN_ != "")
                        {
                            TOTAL_DUTY_FOREGONE_AMT = Convert.ToString(TOTAL_DUTY);
                        }

                        //******************** GST IMPLEMENTATION ON 30-JUN-2017 END***************************


                        if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                        {
                            PRODUCT_BCD_RATE = "";
                        }
                        else
                        {
                            if (PRODUCT_BCD_RATE != "")
                            {
                                PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_BCD_RATE).ToString("F")) + "%";
                            }
                        }

                        //---------------------------------------------------------------------------//

                        if (CETH_SPL_AMT == "" || CETH_SPL_AMT == "0.00")
                        {
                            CETH_SPL_AMT = "";
                        }
                        else
                        {
                            CETH_SPL_AMT = "Rs." + Convert.ToString(Convert.ToDouble(CETH_SPL_AMT).ToString("F")) + "/" + ITEM_QTY_CODE;
                        }


                        if (CETH_SIA_I_RATE == "" || CETH_SIA_I_RATE == "0.00")
                        {
                            CETH_SIA_I_RATE = "";
                        }
                        else
                        {
                            CETH_SIA_I_RATE = "Rs." + Convert.ToString(Convert.ToDouble(CETH_SIA_I_RATE).ToString("F")) + "/" + ITEM_QTY_CODE;
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


                        if (PRODUCT_ADDL_GSI_RATE == "")
                        {
                            if (PRODUCT_CETH == "27101930" || PRODUCT_CETH == "27101949" || PRODUCT_CETH == "27101290" || PRODUCT_CETH == "27101241")//Need Settings Here
                            {
                                if (CETH_SIA_I_RATE != "")
                                {
                                    PRODUCT_ADDL_GSI_RATE = CETH_SIA_I_RATE;
                                }
                                else
                                {
                                    PRODUCT_ADDL_GSI_RATE = "";
                                }
                            }
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

                        if (AIDC_RATE == "")
                        {
                            AIDC_RATE = "";
                        }
                        else
                        {
                            AIDC_RATE = Convert.ToString(Convert.ToDouble(AIDC_RATE).ToString("F")) + "%";
                        }

                        if (EXC_AIDC_RATE == "")
                        {
                            EXC_AIDC_RATE = "";
                        }
                        else
                        {
                            EXC_AIDC_RATE = Convert.ToString(Convert.ToDouble(EXC_AIDC_RATE).ToString("F")) + "%";
                        }

                        if (Convert.ToDouble(EXC_AIDC_SPL_AMT) == 0.00 || Convert.ToDouble(EXC_AIDC_SPL_AMT) <= 0.00)
                        {
                            EXC_AIDC_SPL_AMT = "";
                        }
                        else
                        {
                            EXC_AIDC_SPL_AMT = ITEM_QTY + "*" + EXC_AIDC_SPL_AMT + " " + CETH_CESS_UQC;
                        }

                        if (PRODUCT_ADDL_HEALTH_CESS_RATE == "")
                        {
                            PRODUCT_ADDL_HEALTH_CESS_RATE = "";
                        }
                        else
                        {
                            PRODUCT_ADDL_HEALTH_CESS_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_ADDL_HEALTH_CESS_RATE).ToString("F")) + "%";
                        }

                        if (PRODUCT_ADDL_DUTY_RATE == "")
                        {
                            PRODUCT_ADDL_DUTY_RATE = "";
                            PRODUCT_ADDL_DUTY_RATE_UPDATE = "";
                        }
                        else
                        {
                            PRODUCT_ADDL_DUTY_RATE_UPDATE = PRODUCT_ADDL_DUTY_RATE;
                            PRODUCT_ADDL_DUTY_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_ADDL_DUTY_RATE).ToString("F")) + "%";
                            ADDTIONAL_DUTY = PRODUCT_ADDL_DUTY_RATE;
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

                        //--------------------------------- HEALTH CESS---------------------------------
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            //PRODUCT_ADDL_HEALTH_CESS_NOTN = PRODUCT_ADDL_HEALTH_CESS_NOTN + " " + PRODUCT_ADDL_HEALTH_CESS_SLNO + "  " + PRODUCT_ADDL_HEALTH_CESS_RATE;
                            PRODUCT_ADDL_HEALTH_CESS_NOTN = PRODUCT_ADDL_HEALTH_CESS_NOTN + " " + PRODUCT_ADDL_HEALTH_CESS_SLNO;
                        }

                        //-----------End Other CVD Duty on 02June2015---------------//          

                        PRODUCT_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_EDU_CESS_RATE).ToString("F")) + "%";
                        PRODUCT_SEC_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE).ToString("F")) + "%";

                        CETH_CVD_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(CETH_CVD_EDU_CESS_RATE).ToString("F")) + "%";
                        CETH_CVD_SEC_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(CETH_CVD_SEC_EDU_CESS_RATE).ToString("F")) + "%";

                        ////ADDTIONAL_DUTY = Convert.ToString(Convert.ToDouble(ADDTIONAL_DUTY).ToString("F")) + "%";
                        //ADDTIONAL_DUTY = "0.00";--20-02-2021

                       

                        string ITEM_TTL = Convert.ToString(TOTAL_DUTY);
                        ITEM_TTL = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(TOTAL_DUTY, 2).ToString("F"))));
                        ITEM_TOTAL = Convert.ToDouble(ITEM_TTL);
                        string ASS_TTL = Convert.ToString(ASSESSABLE_TOTAL);
                        ASS_TTL = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(ASSESSABLE_TOTAL, 2).ToString("F"))));
                        ASSESSABLE_TOTAL = Convert.ToDouble(ASS_TTL);
                        string ASS_Value = Convert.ToString(ASSESSABLE_TOTAL);
                        ASS_Value = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(ASSESABLE_VALUE, 2).ToString("F"))));
                        ASSESABLE_VALUE = Convert.ToDouble(ASS_Value);

                        double svb_duty = 0.00;
                        if (SVB_LOADING_ON == "B")//implemnted on 24-12-2024 by Chithra sugg.by Bala sir for CAPRICORN
                        {
                            svb_duty = ITEM_TOTAL * Convert.ToDouble(SVB_DUTY_RATE.Replace("(", "").Replace("%F)", "").Replace("%P)", "")) / 100;
                            ITEM_TOTAL = ITEM_TOTAL + svb_duty;
                        }

                        SVB_DUTY_CALC = "Add " + SVB_DUTY_RATE + " SVB On Duty  " + Convert.ToString(Math.Round(svb_duty, 2).ToString("F"));
                      
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

                        //#final
                        if (MIS_FREIGHT_CURRENCY == "JPY" || MIS_FREIGHT_CURRENCY == "KRW")
                        {
                            INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_FREIGHT_AMOUNT * 100;
                        }
                        if (MIS_INSURANCE_CURRENCY == "JPY" || MIS_INSURANCE_CURRENCY == "KRW")
                        {
                            INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT * 100;
                        }


                        //-----------------------------UPDATE SINGLE ASS , DUTY , CIF ,CVD VALUE IN ITEM TABLE ------------------------------//
                        // **** start on 20-Jul-19 this logic is changed to update in bulk way by jayanthi   

                        /*hide on 26-06-2026 by Chithra for All calc values maintained in Additional table  * */
                            dtt.Rows.Add(C + 1, ddlJobNo, ITEM_ID, INVOICE_SLNO, ITEM_SLNO, Convert.ToString(ASSESABLE_VALUE), Convert.ToString(TOTAL_DUTY),
                            Convert.ToString(INDIVITUAL_CIF_AMOUNT), Convert.ToString(CVD_TOTAL), Convert.ToString(BASIC_DUTY_TOTAL), Convert.ToString(CEC_TOTAL), Convert.ToString(CHEC_TOTAL), Convert.ToString(ADDLTIONAL_DUTY_TOTAL),
                            Convert.ToString(Math.Round(INDIVITUAL_FREIGHT_AMOUNT, 2).ToString("F")), Convert.ToString(Math.Round(INDIVITUAL_INSURANCE_AMOUNT, 2).ToString("F")), Convert.ToString(Math.Round(INDIVITUAL_MISC_AMOUNT, 2).ToString("F")),
                            CEC_TOTAL, CHEC_TOTAL, Convert.ToString(Math.Round(INDIVITUAL_LANDING_COST, 2).ToString("F")), MERIT_PRODUCT_BCD_RATE, MERIT_PRODUCT_CVD_RATE, ADDTIONAL_DUTY_RATE, MERIT_TOTAL_DEBIT_DUTY,
                            PRODUCT_BCD_RATE_UPDATE, PRODUCT_CVD_RATE_UPDATE, Convert.ToString(MERIT_BASIC_VALUE), Convert.ToString(MERIT_CVD_VALUE), Convert.ToString(MERIT_CEC_VALUE), Convert.ToString(MERIT_CHEC_VALUE), Convert.ToString(MERIT_ADD_DUTY_VALUE),
                            Convert.ToString(MERIT_NOTN_BASIC_VALUE), Convert.ToString(MERIT_NOTN_CVD_VALUE), Convert.ToString(MERIT_NOTN_CEC_VALUE), Convert.ToString(MERIT_NOTN_CHEC_VALUE), Convert.ToString(MERIT_NOTN_ADD_DUTY_VALUE),
                            Convert.ToString(MERIT_NOTN_CESS_VALUE), Convert.ToString(MERIT_NOTN_NCD_VALUE), Convert.ToString(INDIVITUAL_HSS_AMOUNT), Convert.ToString(IGST_LEVY_TOTAL), Convert.ToString(IGST_LEVY_COMPENSATION_CESS_TOTAL),
                            Convert.ToString(IGST_LEVY_RATE_UPDATE), Convert.ToString(IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE), Convert.ToString(TOTAL_SOCIAL_WELFARE), Convert.ToString(HEALTH_CESS_TOTAL), Convert.ToString(TOTAL_ANTI_AMT)

                            , Convert.ToString(PRODUCT_ADDL_DUTY_RATE_UPDATE), Convert.ToString(PRODUCT_AGGREGATE_DUTY_NOTN_RATE_UPDATE)
                            , Convert.ToString(CTH_SAFEGUARD_RATE_UPDATE), Convert.ToString(PRODUCT_SAPTA_RATE), Convert.ToString(SOCIAL_WELFARE_RATE_UPDATE), Convert.ToString(PRODUCT_BCD_SPL), Convert.ToString(PRODUCT_BCD_UNIT)
                            , Convert.ToString(PRODUCT_TARIFF_AMOUNT_UPDATE), Convert.ToString(PRODUCT_TARIFF_AMOUNT_UNIT), Convert.ToString(IGST_LEVY_EXCEPTION_RATE), Convert.ToString(IGST_LEVY_COMPENSATION_CESS_SPL)
                            , Convert.ToString(IGST_LEVY_EXCEPTION_CC_RATE), Convert.ToString(AIDC_TOTAL), Convert.ToString(AIDC_AMT_UPDATE)
                            , Convert.ToString(EXC_AIDC_CHECKLIST_AMT), Convert.ToString(CHK_IGST_ASSBL_VAL), Convert.ToString(BCD_FOREGONE_AMT), Convert.ToString(TOTAL_DUTY_FOREGONE_AMT)


                            );
                          
                        // **** end of 20-Jul-19 this logic is changed to update in bulk way by jayanthi   

                        //-----------------------------UPDATE SINGLE ASS , DUTY , CIF ,CVD VALUE IN ITEM TABLE ------------------------------//


                        //#dtt_Addl
                        dtt_Addl.Rows.Add(ITEM_ID, ddlJobNo, INVOICE_SLNO, INVOICE_NO_ITEM, ITEM_SLNO, CHECKLIST_NCD_DUTY_AMT, CHECKLIST_SAFEGUARD_DUTY_AMT, CHECKLIST_AGGREGATE_DUTY_AMT,
                          CHECKLIST_SAPTA_DUTY_AMT, CHECKLIST_GSI_DUTY_AMT, CHECKLIST_TTA_DUTY_AMT, CHECKLIST_SCHED11_DUTY_AMT, CHECKLIST_OTHER_DUTY_AMT, CHECKLIST_INFRACESS_DUTY_AMT,
                        Connection.Current_User(), Session["LoginDate"].ToString(), "N", Connection.Current_Branch(), "", Connection.WorkingPeriod(), ADD_AMTS_RPT,
                        Convert.ToString(ASSESABLE_VALUE), Convert.ToString(TOTAL_DUTY), Convert.ToString(INDIVITUAL_CIF_AMOUNT), Convert.ToString(CVD_TOTAL), Convert.ToString(BASIC_DUTY_TOTAL), Convert.ToString(CEC_TOTAL), Convert.ToString(CHEC_TOTAL), Convert.ToString(ADDLTIONAL_DUTY_TOTAL),
                        Convert.ToString(Math.Round(INDIVITUAL_FREIGHT_AMOUNT, 2).ToString("F")), Convert.ToString(Math.Round(INDIVITUAL_INSURANCE_AMOUNT, 2).ToString("F")), Convert.ToString(Math.Round(INDIVITUAL_MISC_AMOUNT, 2).ToString("F")),
                        CEC_TOTAL, CHEC_TOTAL, Convert.ToString(Math.Round(INDIVITUAL_LANDING_COST, 2).ToString("F")), MERIT_PRODUCT_BCD_RATE, MERIT_PRODUCT_CVD_RATE, ADDTIONAL_DUTY_RATE, MERIT_TOTAL_DEBIT_DUTY,
                        PRODUCT_BCD_RATE_UPDATE, PRODUCT_CVD_RATE_UPDATE, Convert.ToString(MERIT_BASIC_VALUE), Convert.ToString(MERIT_CVD_VALUE), Convert.ToString(MERIT_CEC_VALUE), Convert.ToString(MERIT_CHEC_VALUE), Convert.ToString(MERIT_ADD_DUTY_VALUE),
                        Convert.ToString(MERIT_NOTN_BASIC_VALUE), Convert.ToString(MERIT_NOTN_CVD_VALUE), Convert.ToString(MERIT_NOTN_CEC_VALUE), Convert.ToString(MERIT_NOTN_CHEC_VALUE), Convert.ToString(MERIT_NOTN_ADD_DUTY_VALUE),
                        Convert.ToString(MERIT_NOTN_CESS_VALUE), Convert.ToString(MERIT_NOTN_NCD_VALUE), Convert.ToString(INDIVITUAL_HSS_AMOUNT), Convert.ToString(IGST_LEVY_TOTAL), Convert.ToString(IGST_LEVY_COMPENSATION_CESS_TOTAL),
                        Convert.ToString(IGST_LEVY_RATE_UPDATE), Convert.ToString(IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE), Convert.ToString(TOTAL_SOCIAL_WELFARE), Convert.ToString(HEALTH_CESS_TOTAL), Convert.ToString(TOTAL_ANTI_AMT)
                        , Convert.ToString(PRODUCT_ADDL_DUTY_RATE_UPDATE), Convert.ToString(PRODUCT_AGGREGATE_DUTY_NOTN_RATE_UPDATE), Convert.ToString(CTH_SAFEGUARD_RATE_UPDATE), Convert.ToString(SOCIAL_WELFARE_RATE_UPDATE), Convert.ToString(PRODUCT_BCD_SPL), Convert.ToString(PRODUCT_BCD_UNIT)
                        , Convert.ToString(PRODUCT_SAPTA_RATE) , Convert.ToString(PRODUCT_TARIFF_AMOUNT_UPDATE), Convert.ToString(PRODUCT_TARIFF_AMOUNT_UNIT), Convert.ToString(IGST_LEVY_EXCEPTION_RATE), Convert.ToString(IGST_LEVY_COMPENSATION_CESS_SPL), Convert.ToString(IGST_LEVY_EXCEPTION_CC_RATE)
                         , Convert.ToString(AIDC_TOTAL), Convert.ToString(AIDC_AMT_UPDATE), Convert.ToString(EXC_AIDC_CHECKLIST_AMT), Convert.ToString(CHK_IGST_ASSBL_VAL)
                        , Convert.ToString(BCD_FOREGONE_AMT), Convert.ToString(TOTAL_DUTY_FOREGONE_AMT), JOBNO_PS, EXC_AIDC_RATE, SWS_FOREGONE_AMT, Convert.ToString(IGST_FG_AMT)

                        );


                        //------------License_Details  Debit Amount Calculation ------------------------//

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
                            LICENSE_DEBIT_AMT = DEBIT_AMT;// 23-07-2022 -- for update Demit Amt Update for Common if (@Mflag='Update_Debit_Amt') in SP

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

                                if (SCHEME_NOTN_ == "DEEC" || SCHEME_NOTN_ == "EPCG" || SCHEME_NOTN_ == "FPS" || SCHEME_NOTN_ == "SHIS" || SCHEME_NOTN_ == "FMS" || SCHEME_NOTN_ == "DEPB" || SCHEME_NOTN_ == "MEIS" || SCHEME_NOTN_ == "INC" || SCHEME_NOTN_ == "(KRSH)" || SCHEME_NOTN_ == "SEIS" || SCHEME_NOTN_ == "DFCC" || SCHEME_NOTN_ == "DFIA" || SCHEME_NOTN_ == "ROSCTL" || SCHEME_NOTN_ == "RoDTEP Scheme" || SCHEME_NOTN_ == "ROSCTL Scheme" || SCHEME_NOTN_ == "MEIS eCom")
                                {
                                    if (DEBIT_QTY != null)
                                    {
                                        //if (dss_Lic.Tables[0].Rows[li]["DEBIT_QTY"].ToString() != "0.00")
                                        //{
                                        LICENSE_DEBIT_AMT = (LICENSE_DEBIT_AMT * INDI_DEBIT_QTY) / SUM_DEBIT_QTY;

                                        LICENSE_DEBIT_AMT = Math.Round(LICENSE_DEBIT_AMT + 0.00, 2);

                                        //DEBIT_DUTY = Convert.ToDouble(TOTAL_DEBIT_DUTY);

                                        TOTAL_DEBIT_DUTY = Convert.ToString((DEBIT_DUTY * INDI_DEBIT_QTY) / SUM_DEBIT_QTY);

                                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_DEBIT_DUTY) + 0.00, 2));
                                        //}
                                        //else
                                        //{
                                        //    TOTAL_DEBIT_DUTY = Convert.ToString(DEBIT_DUTY);
                                        //}
                                    }
                                }

                                //else if (SCHEME_NOTN_.Trim() == "Project Imports" || SCHEME_NOTN_.Trim() == "RoDTEP Scheme" || SCHEME_NOTN_.Trim() == "ROSL Scheme")//16-11-2021
                                else if (SCHEME_NOTN_.Trim() == "Project Imports")
                                {
                                    TOTAL_DEBIT_DUTY = "0.00";
                                }



                                //#Bulk_License_Update
                                dtt_License.Rows.Add(LICENSE_ID, ddlJobNo, INVOICE_SLNO, ITEM_SLNO, Convert.ToString(LICENSE_DEBIT_AMT), Convert.ToString(TOTAL_DEBIT_DUTY), Connection.Current_Branch());
                                //------------End License_Details-----------------------------------------------//
                            }
                            else
                            {
                                if (SCHEME_NOTN_ == "DEEC" || SCHEME_NOTN_ == "EPCG" || SCHEME_NOTN_ == "SHIS" || SCHEME_NOTN_ == "FMS" || SCHEME_NOTN_ == "DEPB" || SCHEME_NOTN_ == "MEIS" || SCHEME_NOTN_ == "INC" || SCHEME_NOTN_ == "(KRSH)" || SCHEME_NOTN_ == "SEIS" || SCHEME_NOTN_ == "DFCC" || SCHEME_NOTN_ == "DFIA" || SCHEME_NOTN_ == "ROSCTL" || SCHEME_NOTN_ == "RoDTEP Scheme" || SCHEME_NOTN_ == "ROSCTL Scheme" || SCHEME_NOTN_ == "MEIS eCom")
                                {
                                    if (DEBIT_QTY != null)
                                    {
                                        //if (dss_Lic.Tables[0].Rows[li]["DEBIT_QTY"].ToString() != "0.00")
                                        //{
                                        
                                        /*- hide by Chithra on 28-07-2022 for Debit Amt should not calc again for Manual Entry value
                                        LICENSE_DEBIT_AMT = (LICENSE_DEBIT_AMT * INDI_DEBIT_QTY) / SUM_DEBIT_QTY;
                                        LICENSE_DEBIT_AMT = Math.Round(LICENSE_DEBIT_AMT + 0.00, 2);
                                        */
                                        //DEBIT_DUTY = Convert.ToDouble(TOTAL_DEBIT_DUTY);

                                        TOTAL_DEBIT_DUTY = Convert.ToString((DEBIT_DUTY * INDI_DEBIT_QTY) / SUM_DEBIT_QTY);

                                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_DEBIT_DUTY) + 0.00, 2));
                                        //}
                                        //else
                                        //{
                                        //    TOTAL_DEBIT_DUTY = Convert.ToString(DEBIT_DUTY);
                                        //}
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
                                            if (COMPANY_ID == "333")
                                            {
                                                TOTAL_DEBIT_DUTY = ENTRY_DEBIT_DUTY;
                                            }
                                        }

                                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_DEBIT_DUTY) + 0.00, 2));
                                    }
                                }


                                //else if (SCHEME_NOTN_.Trim() == "Project Imports" || SCHEME_NOTN_.Trim() == "RoDTEP Scheme" || SCHEME_NOTN_.Trim() == "ROSL Scheme")//16-11-2021
                                else if (SCHEME_NOTN_.Trim() == "Project Imports")
                                {
                                    TOTAL_DEBIT_DUTY = "0.00";
                                }


                                //#Bulk_License_Update
                                dtt_License.Rows.Add(LICENSE_ID, ddlJobNo, INVOICE_SLNO, ITEM_SLNO, Convert.ToString(LICENSE_DEBIT_AMT), Convert.ToString(TOTAL_DEBIT_DUTY), Connection.Current_Branch());
                                //------------End License_Details-----------------------------------------------//
                            }
                            //}
                            li++;
                        }


                        PRODUCT_TARIFF_QTY = PRODUCT_TARIFF_QTY + " " + PRODUCT_TARIFF_AMOUNT_UNIT;

                        //PRODUCT_TARIFF_AMOUNT = "USD"+" "+ PRODUCT_TARIFF_AMOUNT;

                        PRODUCT_TARIFF_SLNO = PRODUCT_TARIFF_SLNO + " " + PRODUCT_TARIFF_AMOUNT;

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


                        if (ITEM_SVB_REF_NO != "")
                        {
                            ITEM_SVB_REF_NO = "SVB Loading : " + ITEM_SVB_ASSESABLE_RATE + "% on " + ITEM_SVB_LOADING_ON + " ( " + ITEM_SVB_ASSESABLE_STATUS + ") Ref. No : " + ITEM_SVB_REF_NO + " Dt: " + ITEM_SVB_REF_DATE;
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
                                PRODUCT_ADDL_DUTY_RATE = PRODUCT_ADDL_DUTY_RATE,
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
                                SOCIAL_WELFARE_RATE = SOCIAL_WELFARE_RATE,

                                TOTAL_ANTI_AMT = TOTAL_ANTI_AMT,
                                CETH_SIA_I_RATE = CETH_SIA_I_RATE,

                                HEALTH_CESS_CTH_CODE = HEALTH_CESS_CTH_CODE,
                                HEALTH_CESS_RATE = HEALTH_CESS_RATE,
                                HEALTH_CESS_SQC = HEALTH_CESS_SQC,
                                HEALTH_CESS_TOTAL = HEALTH_CESS_TOTAL,

                                PRODUCT_ADDL_HEALTH_CESS_NOTN = PRODUCT_ADDL_HEALTH_CESS_NOTN,
                                PRODUCT_ADDL_HEALTH_CESS_SLNO = PRODUCT_ADDL_HEALTH_CESS_SLNO,
                                PRODUCT_ADDL_HEALTH_CESS_RATE = PRODUCT_ADDL_HEALTH_CESS_RATE,
                                PRODUCT_ADDL_HEALTH_CESS_SPL = PRODUCT_ADDL_HEALTH_CESS_SPL,
                                PRODUCT_ADDL_HEALTH_CESS_TYPE = PRODUCT_ADDL_HEALTH_CESS_TYPE,
                                PRODUCT_ADDL_HEALTH_CESS_UNIT = PRODUCT_ADDL_HEALTH_CESS_UNIT,

                                AIDC_NOTN = AIDC_NOTN,
                                AIDC_NOTN_SLNO = AIDC_NOTN_SLNO,
                                AIDC_RATE = AIDC_RATE,
                                AIDC_TOTAL = AIDC_TOTAL,
                                AIDC_24_27_Exec = AIDC_24_27_Exec,
                                AIDC_EXEC_AMT = AIDC_EXEC_AMT,
                                EXC_AIDC_NOTN = EXC_AIDC_NOTN,
                                EXC_AIDC_NOTN_SLNO = EXC_AIDC_NOTN_SLNO,
                                EXC_AIDC_RATE = EXC_AIDC_RATE,
                                EXC_AIDC_SPL_AMT = EXC_AIDC_SPL_AMT,
                                EXC_AIDC_CHECKLIST_AMT = EXC_AIDC_CHECKLIST_AMT,
                                CHK_IGST_ASSBL_VAL = CHK_IGST_ASSBL_VAL,
                                BCD_FOREGONE_AMT = BCD_FOREGONE_AMT,
                                TOTAL_DUTY_FOREGONE_AMT = TOTAL_DUTY_FOREGONE_AMT,
                                CETH_ADDL_DUTY_IMPORTS_YN = CETH_ADDL_DUTY_IMPORTS_YN,
                                SVB_DUTY_CALC = SVB_DUTY_CALC,
                                SVB_DUTY_RATE = SVB_DUTY_RATE,

                                ITEM_INDIVITUAL_SVB_AMOUNT = ITEM_INDIVITUAL_SVB_AMOUNT,
                                ITEM_SVB_ASSESABLE_RATE = ITEM_SVB_ASSESABLE_RATE,
                                ITEM_SVB_DUTY_RATE = ITEM_SVB_DUTY_RATE,
                                ITEM_SVB_REF_NO = ITEM_SVB_REF_NO,
                                ITEM_SVB_REF_DATE = ITEM_SVB_REF_DATE,
                                ITEM_SVB_ASSESABLE_STATUS = ITEM_SVB_ASSESABLE_STATUS,
                                ITEM_SVB_DUTY_STATUS = ITEM_SVB_DUTY_STATUS,
                                ITEM_SVB_LOADING_ON = ITEM_SVB_LOADING_ON

                            });

                            if (COMPANY_ID == "353" || COMPANY_ID == "381" || COMPANY_ID == "382")
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


                            Load_Item_Manufacturer_Details.Add(new Transaction_Default2()
                            {
                                INVOICE_SLNO = INVOICE_SLNO,
                                ITEM_SLNO = ITEM_SLNO,
                                GENEARL_DESCRIPTION = GENEARL_DESCRIPTION,
                                MANUFACTURER = MANUFACTURER,
                                BRAND = BRAND,
                                MODEL = MODEL,
                                CENTRAL_EXCISE_FLAG = CENTRAL_EXCISE_FLAG,
                                MANUFACTURER_PRODUCER = MANUFACTURER_PRODUCER,
                                M_P_GROWER_CODE = M_P_GROWER_CODE,
                                M_P_GROWER_ADD1 = M_P_GROWER_ADD1,
                                M_P_GROWER_ADD2 = M_P_GROWER_ADD2,
                                M_P_GROWER_CITY = M_P_GROWER_CITY,
                                M_P_GROWER_COUNTRY_SUBDIV = M_P_GROWER_COUNTRY_SUBDIV,
                                M_P_GROWER_PIN = M_P_GROWER_PIN,
                                M_P_GROWER_COUNTRY = M_P_GROWER_COUNTRY,
                                SOURCE_COUNTRY = SOURCE_COUNTRY,
                                TRANSIT_COUNTRY = TRANSIT_COUNTRY,
                                ACCESSORY_STATUS = ACCESSORY_STATUS
                            });

                            
                            b++;

                        }
                        else
                        {

                            EOU_MERIT_BASIC_DUTY = "";
                            if (SCHEME_CODE == "14")
                            {
                                SCHEME_NOTN = "";
                            }
                            else if (SCHEME_CODE == "21" || SCHEME_CODE == "20")
                            {
                                /* hided by Chithra on 09-06-2022 sugg.by Bala sir
                                if (PRODUCT_BCD_NOTN == "" && PRODUCT_BCD_NOTN_SLNO == "")
                                {
                                    EOU_MERIT_BASIC_DUTY = "BCD  Fg " + Convert.ToString(Math.Round(Convert.ToDouble(MERIT_BASIC_DUTY + merit_social_welfare_cess) + 0.00, 2)); // Implemented on 15Feb2019 by Sathish with Bala
                                }
                                else
                                {
                                    EOU_MERIT_BASIC_DUTY = "BCD  Fg " + Convert.ToString(Math.Round(Convert.ToDouble(MERIT_NOTN_BASIC_VALUE + merit_social_welfare_cess) + 0.00, 2));
                                }
                                */

                                //checked with Final Print copy for RK Container on 09-06-2022

                                TOTAL_DUTY_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + Customs_Social_welfare) + 0.00, 2));
                                //EOU_MERIT_BASIC_DUTY = "BCD  Fg " + TOTAL_DUTY_FOREGONE_AMT;//09-06-2022 ==> 22-08-2024

                                if (LEVY_EXCEMPTION_NOTN_TYPE == "C")
                                {
                                    SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO + "  BCD  Fg : " + TOTAL_DUTY_FOREGONE_AMT + " GST : " + IGST_LEVY_TOTAL_DEBIT;// for eri02518
                                }
                                else
                                {
                                    SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO + "  BCD  Fg : " + TOTAL_DUTY_FOREGONE_AMT;
                                }
                                //EOU_MERIT_CVD = "CVD   " + Convert.ToString(Math.Round(Convert.ToDouble(MERIT_CVD) + 0.00, 2));
                            }
                            else
                            {
                                //Need Settings here
                                if (COMPANY_ID == "10" || COMPANY_ID == "392" || COMPANY_ID == "909" || COMPANY_ID == "660" || COMPANY_ID == "1157" || COMPANY_ID == "1315" || COMPANY_ID == "1520" || COMPANY_ID == "1648" || COMPANY_ID == "2046" || COMPANY_ID == "2059" || COMPANY_ID == "2145" || COMPANY_ID == "2344" || COMPANY_ID == "2518")//Premji Kanji
                                {
                                    //for Ref..
                                    //TOTAL_CUSTOMS_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL));

                                    double Tot_Debit_Duty = 0.00;
                                    if (SCHEME_NOTN_ == "MEIS" || SCHEME_NOTN_ == "SEIS" || SCHEME_NOTN_ == "RoDTEP Scheme" || SCHEME_NOTN_ == "ROSCTL Scheme" || SCHEME_NOTN_ == "MEIS eCom")
                                    {
                                        Tot_Debit_Duty = (BASIC_DUTY + CVD + Healthcess_RateVal + AIDC_Amt);//sugg by bala sir on 11-12-2021
                                    }
                                    else
                                    {
                                        Tot_Debit_Duty = (BASIC_DUTY + Customs_Social_welfare + CVD + Healthcess_RateVal + AIDC_Amt + Convert.ToDouble(TOTAL_ANTI_AMT));
                                    }

                                    TOTAL_DUTY_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(Tot_Debit_Duty) + 0.00, 2));

                                    if (COMPANY_ID == "392" || COMPANY_ID == "909" || COMPANY_ID == "1315" || COMPANY_ID == "1648" || COMPANY_ID == "10" || COMPANY_ID == "2145" || COMPANY_ID == "2344")//GNXT Logistics
                                    {
                                        if ((SCHEME_CODE == "12" || SCHEME_CODE == "17") && LEVY_EXCEMPTION_NOTN_TYPE == "C")
                                        {
                                            //SCHEME_NOTN = "";
                                            SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO + " BCD :" + Convert.ToString(Math.Round(Convert.ToDouble(Tot_Debit_Duty) + 0.00, 2)) + " GST : " + IGST_LEVY_TOTAL_DEBIT;
                                        }
                                        else if (SCHEME_CODE == "03")
                                        {
                                            if (COMPANY_ID == "392" || COMPANY_ID == "2145" || COMPANY_ID == "909")
                                            {
                                                if (PRODUCT_BCD_NOTN == "" && PRODUCT_BCD_NOTN_SLNO == "")
                                                {
                                                    TOTAL_DUTY_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(MERIT_BASIC_DUTY + merit_social_welfare_cess) + 0.00, 2));
                                                    EOU_MERIT_BASIC_DUTY = "BCD  Fg : " + TOTAL_DUTY_FOREGONE_AMT;
                                                }
                                                else
                                                {
                                                    TOTAL_DUTY_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(MERIT_NOTN_BASIC_VALUE + merit_social_welfare_cess) + 0.00, 2));
                                                    EOU_MERIT_BASIC_DUTY = "BCD  Fg : " + TOTAL_DUTY_FOREGONE_AMT;
                                                }
                                            }
                                            else
                                            {
                                                if (LEVY_EXCEMPTION_NOTN_TYPE == "C")
                                                {
                                                    SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO + " BCD Fg :" + Convert.ToString(Math.Round(Convert.ToDouble(Tot_Debit_Duty) + 0.00, 2)) + " GST : " + IGST_LEVY_TOTAL_DEBIT;
                                                }
                                                else
                                                {
                                                    //SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO + " BCD :" + Convert.ToString(Math.Round(Convert.ToDouble(Tot_Debit_Duty) + 0.00, 2)) + " GST : " + TOTAL_IGST_DUTY;
                                                    SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO + " BCD :" + Convert.ToString(Math.Round(Convert.ToDouble(Tot_Debit_Duty) + 0.00, 2));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO + " BCD Fg : " + Convert.ToString(Math.Round(Convert.ToDouble(Tot_Debit_Duty) + 0.00, 2)) + " GST : " + TOTAL_IGST_DUTY;
                                        }

                                    }
                                    else
                                    {
                                        SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO + " BCD Fg : " + Convert.ToString(Math.Round(Convert.ToDouble(Tot_Debit_Duty) + 0.00, 2)) + " GST : " + TOTAL_IGST_DUTY;
                                    }


                                }
                                else
                                {
                                    //Condition Added by pandiyan on 13-06-2025 sugg by bala & subbu
                                    if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III") && HttpContext.Current.Session["COMPANY_ID"].ToString() == "1217")
                                    {
                                        DIFF_AMT_BDC_TRQ = Convert.ToString((Convert.ToDouble(BASIC_DUTY)) - Convert.ToDouble(Scheme_Notn_BCD_Amt));
                                        DIFF_AMT_BDC_TRQ_SW = Convert.ToString(Convert.ToDouble(DIFF_AMT_BDC_TRQ) * Convert.ToDouble(SOCIAL_WELFARE_RATE_UPDATE) / 100);
                                        DIFF_FG_AMT_BDC_TRQ = Convert.ToString((Convert.ToDouble(DIFF_AMT_BDC_TRQ)) + Convert.ToDouble(DIFF_AMT_BDC_TRQ_SW));
                                        
                                        SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO + "," + "BCD Fg :" + DIFF_FG_AMT_BDC_TRQ;
                                    }
                                    else
                                    {
                                        SCHEME_NOTN = "SCHEME NOTN: " + SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO;
                                    }
                                }
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
                                PRODUCT_ADDL_DUTY_RATE = PRODUCT_ADDL_DUTY_RATE,
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
                                SOCIAL_WELFARE_RATE = SOCIAL_WELFARE_RATE,

                                TOTAL_ANTI_AMT = TOTAL_ANTI_AMT,
                                CETH_SIA_I_RATE = CETH_SIA_I_RATE,

                                HEALTH_CESS_CTH_CODE = HEALTH_CESS_CTH_CODE,
                                HEALTH_CESS_RATE = HEALTH_CESS_RATE,
                                HEALTH_CESS_SQC = HEALTH_CESS_SQC,
                                HEALTH_CESS_TOTAL = HEALTH_CESS_TOTAL,

                                PRODUCT_ADDL_HEALTH_CESS_NOTN = PRODUCT_ADDL_HEALTH_CESS_NOTN,
                                PRODUCT_ADDL_HEALTH_CESS_SLNO = PRODUCT_ADDL_HEALTH_CESS_SLNO,
                                PRODUCT_ADDL_HEALTH_CESS_RATE = PRODUCT_ADDL_HEALTH_CESS_RATE,
                                PRODUCT_ADDL_HEALTH_CESS_SPL = PRODUCT_ADDL_HEALTH_CESS_SPL,
                                PRODUCT_ADDL_HEALTH_CESS_TYPE = PRODUCT_ADDL_HEALTH_CESS_TYPE,
                                PRODUCT_ADDL_HEALTH_CESS_UNIT = PRODUCT_ADDL_HEALTH_CESS_UNIT,

                                AIDC_NOTN = AIDC_NOTN,
                                AIDC_NOTN_SLNO = AIDC_NOTN_SLNO,
                                AIDC_RATE = AIDC_RATE,
                                AIDC_TOTAL = AIDC_TOTAL,
                                AIDC_24_27_Exec = AIDC_24_27_Exec,
                                AIDC_EXEC_AMT = AIDC_EXEC_AMT,
                                EXC_AIDC_NOTN = EXC_AIDC_NOTN,
                                EXC_AIDC_NOTN_SLNO = EXC_AIDC_NOTN_SLNO,
                                EXC_AIDC_RATE = EXC_AIDC_RATE,
                                EXC_AIDC_SPL_AMT = EXC_AIDC_SPL_AMT,
                                EXC_AIDC_CHECKLIST_AMT = EXC_AIDC_CHECKLIST_AMT,
                                CHK_IGST_ASSBL_VAL = CHK_IGST_ASSBL_VAL,
                                BCD_FOREGONE_AMT = BCD_FOREGONE_AMT,
                                TOTAL_DUTY_FOREGONE_AMT = TOTAL_DUTY_FOREGONE_AMT,
                                CETH_ADDL_DUTY_IMPORTS_YN = CETH_ADDL_DUTY_IMPORTS_YN,
                                SVB_DUTY_CALC = SVB_DUTY_CALC,
                                SVB_DUTY_RATE = SVB_DUTY_RATE,

                                ITEM_INDIVITUAL_SVB_AMOUNT = ITEM_INDIVITUAL_SVB_AMOUNT,
                                ITEM_SVB_ASSESABLE_RATE = ITEM_SVB_ASSESABLE_RATE,
                                ITEM_SVB_DUTY_RATE = ITEM_SVB_DUTY_RATE,
                                ITEM_SVB_REF_NO = ITEM_SVB_REF_NO,
                                ITEM_SVB_REF_DATE = ITEM_SVB_REF_DATE,
                                ITEM_SVB_ASSESABLE_STATUS = ITEM_SVB_ASSESABLE_STATUS,
                                ITEM_SVB_DUTY_STATUS = ITEM_SVB_DUTY_STATUS,
                                ITEM_SVB_LOADING_ON = ITEM_SVB_LOADING_ON

                            });

                            if (COMPANY_ID == "353" || COMPANY_ID == "381" || COMPANY_ID == "382")
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

                            Load_Item_Manufacturer_Details.Add(new Transaction_Default2()
                            {
                                INVOICE_SLNO = INVOICE_SLNO,
                                ITEM_SLNO = ITEM_SLNO,
                                GENEARL_DESCRIPTION = GENEARL_DESCRIPTION,
                                MANUFACTURER = MANUFACTURER,
                                BRAND = BRAND,
                                MODEL = MODEL,
                                CENTRAL_EXCISE_FLAG = CENTRAL_EXCISE_FLAG,
                                MANUFACTURER_PRODUCER = MANUFACTURER_PRODUCER,
                                M_P_GROWER_CODE = M_P_GROWER_CODE,
                                M_P_GROWER_ADD1 = M_P_GROWER_ADD1,
                                M_P_GROWER_ADD2 = M_P_GROWER_ADD2,
                                M_P_GROWER_CITY = M_P_GROWER_CITY,
                                M_P_GROWER_COUNTRY_SUBDIV = M_P_GROWER_COUNTRY_SUBDIV,
                                M_P_GROWER_PIN = M_P_GROWER_PIN,
                                M_P_GROWER_COUNTRY = M_P_GROWER_COUNTRY,
                                SOURCE_COUNTRY = SOURCE_COUNTRY,
                                TRANSIT_COUNTRY = TRANSIT_COUNTRY,
                                ACCESSORY_STATUS = ACCESSORY_STATUS
                            });

                            b++;
                        }

                        double final_debitduty = Math.Round(Convert.ToDouble(TOTAL_DEBIT_DUTY_FINAL) + Convert.ToDouble(TOTAL_DEBIT_DUTY), 0.00);
                        TOTAL_DEBIT_DUTY_FINAL = Convert.ToString(final_debitduty);
                    }

                }
                Get_Invoice_Details(ddlJobNo, ds.Rows[C], ds.Rows.Count, TOTAL_FOC_Item_AMT);

                C++;

            }

            //#dtt_Addl
            if (dtt_Addl.Rows.Count > 0)
            {
                //if (string.IsNullOrEmpty(Session["BE_No"] as string))
                //{
                    //-------Delete Bulk Data for this Job------------------------------
                    DataSet dsdel = new DataSet();
                    dsdel = IC.GetData_ChkListNew(ddlJobNo, "", "Delete_Item_Additional");

                    //-------Insert Bulk Data to Table------------------------------
                    AdminMasterDetails adm = new AdminMasterDetails();
                    adm.SqlBulk_Upload_Product("ITEM_PRODUCT_DETAILS_ADDITIONAL", dtt_Addl, Connection.GetConnection());

                    //#License_Update
                    if (dtt_License.Rows.Count > 0)
                    {
                        UserBO ObjUBO = new UserBO();
                        IC.Import_Item_ASS_ValueBulkUpdate(ObjUBO, dtt_License, "Update_Debit_Amt", "SP_IMPORT_LICENSE_DUTY_BULK_UPDATE_UDT");
                    }
                //}


                DataSet dss_TD = new DataSet();
                dss_TD = IC.GetData_ChkListNew(ddlJobNo, "", "Get_Checklist_Total_Duty_Value");

                //BASIC_VALUE = "";
                if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "2373")
                {
                    Load_Item_Total_Duty_Details.Add(new Transaction_Default2()
                    {
                        BASIC_VALUE = dss_TD.Tables[0].Rows[0]["BASIC_VALUE"].ToString(),
                        CHECKLIST_SOCIAL_WELFARE_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_SOCIAL_WELFARE_AMT"].ToString(),
                        CEC_VALUE = dss_TD.Tables[0].Rows[0]["CEC_VALUE"].ToString(),
                        CHEC_VALUE = dss_TD.Tables[0].Rows[0]["CHEC_VALUE"].ToString(),
                        AIDC_CHECKLIST_AMT = dss_TD.Tables[0].Rows[0]["AIDC_CHECKLIST_AMT"].ToString(),
                        CHECKLIST_IGST_LEVY_AMOUNT = dss_TD.Tables[0].Rows[0]["CHECKLIST_IGST_LEVY_AMOUNT"].ToString(),
                        CHECKLIST_COMPENSATION_CC_AMOUNT = dss_TD.Tables[0].Rows[0]["CHECKLIST_COMPENSATION_CC_AMOUNT"].ToString(),
                        CHECKLIST_ANTI_DUMPING_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_ANTI_DUMPING_AMT"].ToString(),
                        CHECKLIST_NCD_DUTY_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_NCD_DUTY_AMT"].ToString(),

                        CHECKLIST_AGGREGATE_DUTY_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_AGGREGATE_DUTY_AMT"].ToString(),
                        CHECKLIST_SAPTA_DUTY_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_SAPTA_DUTY_AMT"].ToString(),
                        CVD_VALUE = dss_TD.Tables[0].Rows[0]["CVD_VALUE"].ToString(),
                        INDIVITUAL_EDU_CESS_AMT = dss_TD.Tables[0].Rows[0]["INDIVITUAL_EDU_CESS_AMT"].ToString(),
                        INDIVITUAL_SEC_HIGHER_CESS_AMT = dss_TD.Tables[0].Rows[0]["INDIVITUAL_SEC_HIGHER_CESS_AMT"].ToString(),
                        CHECKLIST_OTHER_DUTY_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_OTHER_DUTY_AMT"].ToString(),
                        CHECKLIST_GSI_DUTY_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_GSI_DUTY_AMT"].ToString(),
                        CHECKLIST_ADDL_DUTY_RATE = dss_TD.Tables[0].Rows[0]["CHECKLIST_ADDL_DUTY_RATE"].ToString(),
                        CHECKLIST_TTA_DUTY_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_TTA_DUTY_AMT"].ToString(),
                        CHECKLIST_HEALTH_CESS_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_HEALTH_CESS_AMT"].ToString(),
                        CHECKLIST_CESS_DUTY_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_CESS_DUTY_AMT"].ToString(),
                        CHECKLIST_SCHED11_DUTY_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_SCHED11_DUTY_AMT"].ToString(),
                        CHECKLIST_SAFEGUARD_DUTY_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_SAFEGUARD_DUTY_AMT"].ToString(),
                        CHECKLIST_INFRACESS_DUTY_AMT = dss_TD.Tables[0].Rows[0]["CHECKLIST_INFRACESS_DUTY_AMT"].ToString(),

                        Tot_Customs_Duty = dss_TD.Tables[1].Rows[0]["Tot_Customs_Duty"].ToString(),
                        Tot_Excise_Duty = dss_TD.Tables[1].Rows[0]["Tot_Excise_Duty"].ToString()
                    });
                }
                else
                {
                    Load_Item_Total_Duty_Details.Add(new Transaction_Default2()
                    {
                        BASIC_VALUE = ""
                    });
                }
            }
            else
            {
                btn_checklist_Value_Update.Visible = false;
            }

            if (dtt.Rows.Count > 0)
            {
                UserBO ObjUBO = new UserBO();
                ObjUBO.flag = "Update";
                //IC.Import_Item_ASS_ValueBulkUpdate(ObjUBO, dtt);// hide by Chithra on 23-07-2022
                IC.Import_Item_ASS_ValueBulkUpdate(ObjUBO, dtt, "Update", "SP_IMPORT_ITEM_ASSVALUE_UPDATE_BULK_UDT");
                int i = IC.result;

            }

            // Audit for Checklist to Flatfile
            IC.Imp_Checklist_Open_Logs(Connection.IMP_Jobno(), "Insert");

            GC.Collect();
            ReportViewer1.Visible = true;
        }
        catch (Exception ex)
        {
            
            ReportViewer1.Visible = false;
            GV.DataSource = dtt;
            GV.DataBind();
            btn_checklist_Value_Update.Visible = false;
        }

    }




    private void Scheme_DEEC(DataSet dss1)
    {
        try
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
                Other_duty = 0.00;

                cvd_Customs_Edu_Cess = 0.00;
                cvd_Customs_Higher_Edu_Cess = 0.00;
                Customs_Social_welfare = 0.00;//02feb
                Healthcess_RateVal = 0.00;
                AIDC_Amt = 0.00;
                BCD_FG_AMT = 0.00;
                IGST_FG_AMT = 0.00;
                SWS_FG_AMT = 0.00;

                if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (COMPANY_ID != "2404" && COMPANY_ID != "3085" && COMPANY_ID != "951"))// Condition Added by pandiyan suggest by bala for sai clearing  
                {
                    TOTAL_ANTI_AMT = TOTAL_ANTI_AMT;
                }
                else
                {
                    TOTAL_ANTI_AMT = "0.00";
                }


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
                    Healthcess_RateVal = 0.00;
                    AIDC_Amt = 0.00;
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
                HEALTH_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Healthcess_RateVal), 1).ToString("0.00"));//02feb
                AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));//01-feb-2021

                //-----------------------CALCULATION FOR TOTAL DEBIT DUTY--------------------------------//


                //double bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;


                double bcd_rate = 0.00;

                //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

                if (PRODUCT_BCD_NOTN != "")
                {
                    if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
                    {
                        //NOTIFICATION_CUSTOMS_BCD_RATE = "";

                        //--if "NOTIFICATION_CUSTOMS_BCD_SPL" is "0" "CTH_SPL_AMT" - should be "0" - confirmed with Final Print for Aeroship.. sugg.By Bala Sir on 20-03-2021
                        //if (Session["COMPANY_ID"].ToString() == "145" || Session["COMPANY_ID"].ToString() == "262" || Session["COMPANY_ID"].ToString() == "184" || Session["COMPANY_ID"].ToString() == "223" || Session["COMPANY_ID"].ToString() == "224" || Session["COMPANY_ID"].ToString() == "164" || Session["COMPANY_ID"].ToString() == "1026" || Session["COMPANY_ID"].ToString() == "1048")
                        //{
                        CTH_SPL_AMT = "0";
                        //}
                    }
                }


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
                    double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                    //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                    double cth_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);


                    if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                    {
                        if (cth_Amt <= bcd_rate)
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                        else
                        {
                            //BASIC_DUTY = bcd_Amt;
                            if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                            {
                                BASIC_DUTY = bcd_Amt;
                            }
                            else
                            {
                                BASIC_DUTY = bcd_rate;
                            }
                        }
                    }
                    else if (NOTIFICATION_FLAG == "+")
                    {
                        if (bcd_rate >= bcd_Amt)
                        {
                            BASIC_DUTY = cth_Amt + bcd_rate;
                        }
                        else
                        {
                            BASIC_DUTY = cth_Amt + bcd_Amt;
                        }
                    }
                    else //-- NOTIFICATION_FLAG == "H" or others
                    {
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
                        double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_BCD_SPL);

                        /* hide By chithra for implement H,L,+ - above code BASIC_DUTY value again update here.. on 02/08/2019
                            if (bcd_rate >= cth_Amt)
                            {
                                BASIC_DUTY = bcd_rate;
                            }
                            else
                            {
                                BASIC_DUTY = cth_Amt;
                            }
                        */
                        if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                        {
                            if (bcd_Amt <= bcd_rate)
                            {
                                BASIC_DUTY = bcd_Amt;
                            }
                        }

                        if (COMPANY_ID == "313")
                        {
                            if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                            {
                                BASIC_DUTY = cth_Amt;
                            }
                        }

                        //BASIC_DUTY_BCD_SPL = cth_Amt;
                        //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                        CTH_SPL_AMT = PRODUCT_BCD_SPL;
                        CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
                    }
                }

                //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
                Get_Less_Sapta_Rate();

                //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//
                bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

                //---------------END SAPTA CALCULATION-------------------------//

                //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
                /*hide on 25-11-2025
               BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
               BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
                 * */

                //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
                if (PRODUCT_BCD_NOTN != "")
                {
                    BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
                    BCD_FOREGONE_AMT = Convert.ToString(Math.Round(BCD_FG_AMT, 1).ToString("0.00"));
                }
                else
                {
                    BCD_FOREGONE_AMT = Convert.ToString(BASIC_DUTY);
                }

                //--------------------------------------------


                //-------HEALTH CESS CALCULATION

                HEALTH_CESS_TOTAL = "0.00";
                if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                {
                    if (HEALTH_CESS_CTH_CODE != "")
                    {
                        Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                        //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }
                }

                //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                AIDC_Amt = NOTN_AIDC_CALC();

                if (COMPANY_ID == "614")
                {
                    AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));
                }

                //10-06-2024 for SHAANU LOGISTICS - Sugg.By Bala sir
                if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO != "17" && AIDC_NOTN_SLNO != "18" && AIDC_NOTN_SLNO != "19" && AIDC_NOTN_SLNO != "17A"))
                {
                    AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));
                }

                //#SWS
                if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                {
                    Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }
                else
                {
                    Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }


                //--------------SWS FOREGONE AMOUNT----By Chithra on 24-11-2025 for Capricorn-----------
                //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
                if (SOCIAL_WELFARE_NOTN != "")
                {
                    SWS_FG_AMT = merit_social_welfare_cess - Customs_Social_welfare;
                    SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Customs_Social_welfare, 1).ToString("0.00"));
                }
                else
                {
                    SWS_FOREGONE_AMT = Convert.ToString(Customs_Social_welfare);
                }
                SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));


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

                /*//hide on 23-10-2024 for New Settings
                if (PRODUCT_CETH.Substring(0, 2) != "24")
                {
                    CVD_TOTAL = "0";
                    CVD = 0.00;
                    PRODUCT_CVD_RATE = "0.00";
                    PRODUCT_CETH = "NOEXCISE";
                }
                 * */

                if (CETH_CVD_NIL_YN == "Y")
                {
                    CVD = 0.00;
                    CVD_TOTAL = "0.00";
                    PRODUCT_CVD_RATE = "0.00";
                }
                //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                Actual_BASIC_DUTY = BASIC_DUTY;


                //------------------------------CESS CALCULATION--------------------------------//


                /* hide on 20/02/2018 discuss with subbu sir --------- start
                 * 
                if ((Convert.ToDouble(CETH_CESS_AMTS) != 0.00) || (Convert.ToDouble(CETH_CESS_AMTS) > 0.00))
                {
                    if (Convert.ToDouble(CETH_CESS_AMTS) != 0.00)
                    {
                        CESS = c_ITEM_QTY * Convert.ToDouble(CETH_CESS_AMTS);
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


                //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;--02-02-2021


                //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//

                if (COMPANY_ID == "247" || COMPANY_ID == "10")
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
                        //TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);
                        TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY);

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

                    if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (COMPANY_ID != "2404" && COMPANY_ID != "3085" && COMPANY_ID != "951"))// Condition Added by pandiyan suggest by bala for sai clearing  
                    {
                        ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + TOTAL_ANTIDUMP_AMT;
                    }
                    else
                    {
                        ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                    }
                }
                //---------Start New Anti-Dumping Calculation implemented on 27Sep2018------------//
                else if (MAX_DIFF != "" && MAX_DIFF != null)
                {


                    if (PRODUCT_OTHER_DUTY_NOTN != "" && PRODUCT_OTHER_DUTY_SLNO != "")
                    {
                        if (PRODUCT_OTHER_DUTY_RATE != "")
                        {
                            ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                            TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                            TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));

                            //hide on 05-03-2024 Sugg.by Bala Sir
                            //double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                            double Anti_Dump_Cal2 = 0.00;
                            /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                        if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                        {
                                                            Anti_Dump_Cal2 = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                        }
                                                        else
                                                        {
                                                            Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                        }
                                                          */
                            Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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

                        /* hide on 05-11-2024 - Sugg.by Bala sir
                       TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                       MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                         * */


                        if (ANTI_DUMPING_NOTN == "015/2023" || ANTI_DUMPING_NOTN == "017/2023" || ANTI_DUMPING_NOTN == "011/2024" || ANTI_DUMPING_NOTN == "006/2025" || ANTI_DUMPING_NOTN == "021/2025" || ANTI_DUMPING_NOTN == "004/2025")// Sugg.By Bala sir on 22-02-2024 for OECL Shipping
                        {
                            TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                            MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        }
                        else
                        {
                            //this calc newly added sugg.by Bala sir done by Chithra on 23/12/2020
                            TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                            MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt)) / 100;
                        }

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
                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble((ADD_DIFF_CUR)) / 100;

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
                    //Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT-- hide on 05-03-2024


                    /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                               if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                               {
                                                   Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                               }
                                               else
                                               {
                                                   Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                               }
                                               */
                    Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;

                    PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));

                }
                else if (PRODUCT_OTHER_DUTY_SPL != "")
                {
                    Other_duty = c_ITEM_QTY * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
                    PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));
                }

                // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
                //doing

                Call_IGST_General();

                CHK_IGST_ASSBL_VAL = 0.00;
                if (RSP_APPLICABLE == "S" && (MRP_AMT > IGST_LEV_1_AMT_ASS))
                {
                    CHK_IGST_ASSBL_VAL = MRP_AMT; //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                    tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                }
                else
                {
                    if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                    {
                        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
                    }
                    else
                    {
                        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt + SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT); //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                    }
                    tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                }

                // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - END 88 **************************************//



                //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                AddL_DUTY = 0.00;

                //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//


                //for SWS - without Health Cess, Basic Duty only add with License debit duty - sugg by Bala sir & Subbu sir on 30-10-2020
                double Customs_SWS_HealthCess = 0.00;
                if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                {
                    if (HEALTH_CESS_CTH_CODE != "")
                    {
                        Customs_SWS_HealthCess = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }
                }

                //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));//HIDE BY CHITHRA ON 20/12/2017 for add IGST With Debit Duty

                if (SCHEME_CODE == "12" || SCHEME_CODE == "03" || SCHEME_CODE == "17")
                {

                    if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                    {
                        // TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(HEALTH_CESS_TOTAL) + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));
                        if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (COMPANY_ID != "2404" && COMPANY_ID != "3085" && COMPANY_ID != "951"))//Condition Added by pandiyan suggest by bala for sai clearing    
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));
                        }
                        else
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));
                        }
                    }
                    else
                    {
                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(HEALTH_CESS_TOTAL)), 1).ToString("0.00"));
                    }

                    /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    {
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            //10-06-2024
                            // TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));

                            if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                            {
                                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));
                            }
                            else
                            {
                                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess), 1).ToString("0.00"));
                            }
                        }
                    }
                }
                else
                {
                    //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
                    //02feb
                    // TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal), 1).ToString("0.00"));

                    //10-06-2024
                    // TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(HEALTH_CESS_TOTAL) + Customs_SWS_HealthCess + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));

                    if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                    {
                        if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (COMPANY_ID != "2404" && COMPANY_ID != "951"))// Condition Added by pandiyan suggest by bala for sai clearing  
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));
                        }
                        else
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));

                        }
                    }
                    else
                    {
                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(HEALTH_CESS_TOTAL) + Customs_SWS_HealthCess), 1).ToString("0.00"));
                    }

                    /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    {
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            //10-06-2024
                            //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess), 1).ToString("0.00"));


                            if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                            {
                                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));
                            }
                            else
                            {
                                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
                            }
                        }
                    }
                }

                //Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL) + CESS) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
                //Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL) + CESS) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                //AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Edu_Cess + Customs_Higher_Edu_Cess + CESS) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;

                //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + CESS).ToString("0.00"));
                PRODUCT_OTHER_DUTY_TOTAL = "0";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void Scheme_DUTIABLE()
    {
        try
        {
            double bcd_rate = 0.00;
            double bcd_Amt = 0.00;
            BCD_FG_AMT = 0.00;
            IGST_FG_AMT = 0.00;
            SWS_FG_AMT = 0.00;
            //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

            if (PRODUCT_BCD_NOTN != "")
            {
                if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
                {
                    //NOTIFICATION_CUSTOMS_BCD_RATE = "";


                    //--if "NOTIFICATION_CUSTOMS_BCD_SPL" is "0" "CTH_SPL_AMT" - should be "0" - confirmed with Final Print for Aeroship.. sugg.By Bala Sir on 20-03-2021
                    //if (Session["COMPANY_ID"].ToString() == "145" || Session["COMPANY_ID"].ToString() == "262" || Session["COMPANY_ID"].ToString() == "184" || Session["COMPANY_ID"].ToString() == "223" || Session["COMPANY_ID"].ToString() == "224" || Session["COMPANY_ID"].ToString() == "164" || Session["COMPANY_ID"].ToString() == "1026" || Session["COMPANY_ID"].ToString() == "1048")
                    //{
                    CTH_SPL_AMT = "0";
                    //}
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
                    if (PRODUCT_BCD_RATE != "")
                    {
                        bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                    }
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
            if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
            {
                BASIC_DUTY = 0.00;
                bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
            }
            else
            {
                if (Convert.ToDouble(PRODUCT_BCD_RATE) == 0.00 || Convert.ToDouble(PRODUCT_BCD_RATE) == 0)
                {
                    BASIC_DUTY = 0.00;
                }
            }

            if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
            {
                //CTH_SPL_AMT = "";
                BASIC_DUTY = bcd_rate;
            }
            else
            {
                //bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                double cth_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);


                if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                {
                    if (cth_Amt <= bcd_rate)
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                    else
                    {
                        //BASIC_DUTY = bcd_Amt;
                        if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                        else
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                    }
                }
                else if (NOTIFICATION_FLAG == "+")
                {
                    if (bcd_rate >= bcd_Amt)
                    {
                        BASIC_DUTY = cth_Amt + bcd_rate;
                    }
                    else
                    {
                        BASIC_DUTY = cth_Amt + bcd_Amt;
                    }
                }
                else //-- NOTIFICATION_FLAG == "H" or others
                {
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

                /* hide by Chithra on 17-09-2019 discuss with sathish sir - Master Cargo - above value updated nill here..
                //if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                //{
                //    if (bcd_Amt <= bcd_rate)
                //    {
                //        BASIC_DUTY = bcd_Amt;
                //    }
                //}
                 * */
            }

            if (PRODUCT_BCD_SPL != "")
            {
                if (Convert.ToDouble(PRODUCT_BCD_SPL) != 0.000000 || Convert.ToDouble(PRODUCT_BCD_SPL) != 000000)
                {
                    double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                    bcd_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_BCD_SPL);

                    /* hide By chithra for implement H,L,+ - above code BASIC_DUTY value again update here.. on 02/08/2019
                        if (bcd_rate >= cth_Amt)
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                        else
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                     */

                    if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                    {
                        if (bcd_Amt <= bcd_rate)
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                        else
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                    }

                    if (COMPANY_ID == "313")
                    {
                        if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                    }

                    //BASIC_DUTY_BCD_SPL = cth_Amt;
                    //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                    CTH_SPL_AMT = PRODUCT_BCD_SPL;
                    CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
                }
            }


            //-------HEALTH CESS CALCULATION
            HEALTH_CESS_TOTAL = "0.00";
            Healthcess_RateVal = 0.00;
            //if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")//hide on 05-02-2026 for New Budget updation changes on 01-02-2026
            //{
            if (HEALTH_CESS_RATE != "")
            {
                if (HEALTH_CESS_CTH_CODE != "")
                {
                    Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                    HEALTH_CESS_TOTAL = Convert.ToString(Healthcess_RateVal);
                }
            }
            //}


            //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
            Get_Less_Sapta_Rate();

            //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//
            bcd_rate = NOTN_SAPTA_CALC(bcd_rate);


            //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
            AIDC_Amt = NOTN_AIDC_CALC();

            //-------SOCIAL WELFARE CALCULATION
            /*--02-02-2021
            if (SOCIAL_WELFARE_NOTN != "")
            {
                SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }
            */



            //---------------END SAPTA CALCULATION-------------------------//

            //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
            //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
            if (PRODUCT_BCD_NOTN != "")
            {
                BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
                BCD_FOREGONE_AMT = Convert.ToString(Math.Round(BCD_FG_AMT, 1).ToString("0.00"));
            }
            else
            {
                BCD_FG_AMT = BASIC_DUTY;
                BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
            }
            //--------------------------------------------




            //----------------Start 28Apr2015---------------------//
            if (NOTIFICATION_CUSTOMS_BCD_RATE != "")
            {
                /*
                if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
                {
                    BASIC_DUTY = 0.00;
                }
                 */

                if (PRODUCT_RITC == "08021100" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "24AA")//--its for Pankaj Goyal eri00555 - asked by pandian
                {
                }
                else
                {
                    if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
                    {
                        BASIC_DUTY = 0.00;
                    }
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
                if (PRODUCT_CVD_NOTN == "003/2025 1")
                {
                    double CVD_Calc1 = 0.00, Individual_CVD = 0.00;
                    CVD_Calc1 = ASSESABLE_VALUE + BASIC_DUTY;
                    Individual_CVD = CVD_Calc1 / Convert.ToDouble(CTH_QTY) / EXCHANGE_RATE;
                    CVD_Calc1 = Convert.ToDouble(PRODUCT_CVD_SPL) - Individual_CVD;

                    if (CVD_Calc1 < 0)
                    {
                        CVD_Amt = 0.00;
                    }
                    else
                    {
                        CVD_Amt = CVD_Calc1 * Convert.ToDouble(CTH_QTY) * EXCHANGE_RATE;
                    }
                }
                else if (Convert.ToDouble(PRODUCT_CVD_SPL) != 0.00 || Convert.ToDouble(PRODUCT_CVD_SPL) != 0)
                {
                    CVD_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_CVD_SPL);
                    CETH_SPL_AMT = PRODUCT_CVD_SPL;
                }
            }
            else
            {
                CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT);
            }

            //---------------End Updated on 04 July 2014------------------//

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
                        CESS = c_ITEM_QTY * Convert.ToDouble(CETH_CESS_AMTS);
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
            if (CETH_CATEGORY != "NOEXCISE")
            {
                if ((Convert.ToDouble(CETH_CESS_AMTS) != 0.00) || (Convert.ToDouble(CETH_CESS_AMTS) > 0.00))
                {
                    if (Convert.ToDouble(CETH_CESS_AMTS) != 0.00)
                    {
                        CESS = c_ITEM_QTY * Convert.ToDouble(CETH_CESS_AMTS);
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
            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            if (COMPANY_ID == "182")
            {
                //CVD = CVD * 20;
                CVD = CVD + CVD_Amt;
            }

            if (COMPANY_ID == "162" && CVD_NOTN == "012/2012" && PRODUCT_CVD_NOTN_SLNO == "51(ii)")
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


            /*//hide on 23-10-2024 for New Settings
            if (PRODUCT_CETH.Substring(0, 2) != "24")
            {
                CVD = 0.00;
                CVD_TOTAL = "0.00";
                PRODUCT_CVD_RATE = "0.00";
            }
            else if (PRODUCT_CETH == "24029090" || PRODUCT_CETH == "24022090" || PRODUCT_CETH == "24039100" || PRODUCT_CETH == "24011090" || PRODUCT_CETH == "24012090" || PRODUCT_CETH == "27101241")
            {
                CVD = 0.00;
                CVD_TOTAL = "0.00";
                PRODUCT_CVD_RATE = "0.00";
            }
            */

            if (CETH_CVD_NIL_YN == "Y")
            {
                CVD = 0.00;
                CVD_TOTAL = "0.00";
                PRODUCT_CVD_RATE = "0.00";
            }

            // -----------------Spl Excise Duty(Sched-11) Calculation-------------------------------//
            // -----------------GSI Calculation-------------------------------//
            // -----------------TTA Calculation-------------------------------//


            //---------------Start Other CVD Duty Calculation On 02June2015(Boxco)---------------//

            if (PRODUCT_OTHER_DUTY_RATE != "")
            {
                //Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100; EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT
                //Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT-- hide on 05-03-2024

                /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                  if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                  {
                                                      Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                  }
                                                  else
                                                  {
                                                      Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                  }
                                                  */
                Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));

            }
            else if (PRODUCT_OTHER_DUTY_SPL != "")
            {
                Other_duty = c_ITEM_QTY * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
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


            AddL_DUTY = 0.00;

            SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

            //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
            Actual_BASIC_DUTY = BASIC_DUTY;

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
                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                Aggregate_SWS = Customs_Social_welfare;

                double AGGREGATE_DUTY_a = (Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess + Aggregate_SWS);
                //double AGGREGATE_DUTY_a = (Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess );

                SAFE_GUARD = SAFE_GUARD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                //AddL_DUTY = AddL_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                AddL_DUTY = 0.00;

                BASIC_DUTY = BASIC_DUTY * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                CESS = CESS * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                NCD = NCD * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                Customs_Edu_Cess = Customs_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                Customs_Higher_Edu_Cess = Customs_Higher_Edu_Cess * Convert.ToDouble(PRODUCT_AGGREGATE_DUTY_NOTN_RATE) / 100;
                Aggregate_SWS = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;//SWS

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

                AGGREGATE_DUTY = AGGREGATE_DUTY_a - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess + Aggregate_SWS);
                //AGGREGATE_DUTY = AGGREGATE_DUTY_a - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd);

                /*hide on 24-01-2025 by Chithra Sugg.by Bala sir & Nabil - for ARYA OFFSHORE
                //----- New Impelmentation for RYAL Logistics suggest by Bala sir.. on 27-02-2020
                double aggregate1 = AGGREGATE_DUTY * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                AGGREGATE_DUTY = AGGREGATE_DUTY + aggregate1;
                 * */
            }

            CVD_CEC_TOTAL = "0.00";
            CVD_CHEC_TOTAL = "0.00";

            //#SWS
            /* condition for 7106 & 7108 chapter AIDC amt should not calculate - hide by Chithra on 17-06-2023 sugg.by Bala sir
            if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
            {
                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }
            else
            {
                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }
             * */

            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            //--------------SWS FOREGONE AMOUNT----By Chithra on 24-11-2025 for Capricorn-----------
            //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
            if (SOCIAL_WELFARE_NOTN != "")
            {
                SWS_FG_AMT = merit_social_welfare_cess - Customs_Social_welfare;
                SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Customs_Social_welfare, 1).ToString("0.00"));
            }
            else
            {
                SWS_FOREGONE_AMT = Convert.ToString(Customs_Social_welfare);
            }
            SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));


            SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 2).ToString("0.00"));

            if (COMPANY_ID == "248")
            {
                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 2).ToString("0.00"));
            }
            else
            {
                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
            }

            AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
            SAPTA_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAPTA_DUTY), 1).ToString("0.00"));

            CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CESS), 1).ToString("0.00"));
            NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
            CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
            CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));
            AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));//01-feb-2021
            HEALTH_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Healthcess_RateVal), 1).ToString("0.00"));

            ADDLTIONAL_DUTY_TOTAL = "0.00";
            INFRA_CESS_TOTAL = "0.00";

            //ITEM_PRODUCT_DETAILS_ADDITIONAL
            CHECKLIST_SAFEGUARD_DUTY_AMT = SAFE_GUARD_TOTAL;
            CHECKLIST_NCD_DUTY_AMT = NCD_TOTAL;
            CHECKLIST_AGGREGATE_DUTY_AMT = AGGREGATE_TOTAL;
            CHECKLIST_SAPTA_DUTY_AMT = SAPTA_TOTAL;
            CHECKLIST_GSI_DUTY_AMT = "0.00";
            CHECKLIST_TTA_DUTY_AMT = "0.00";
            CHECKLIST_SCHED11_DUTY_AMT = "0.00";
            CHECKLIST_OTHER_DUTY_AMT = PRODUCT_OTHER_DUTY_TOTAL;
            CHECKLIST_INFRACESS_DUTY_AMT = INFRA_CESS_TOTAL;


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

                        //hide on 05-03-2024 Sugg.by Bala Sir
                        //double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                        double Anti_Dump_Cal2 = 0.00;
                        /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                      if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                      {
                                                          Anti_Dump_Cal2 = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                      }
                                                      else
                                                      {
                                                          Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                      }
                                                        */
                        Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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

                    //this line hide by Chithra on 23/12/2020 sugg.By Bala sir - issue for ABM Logistics Services
                    //TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    //MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;

                    if (ANTI_DUMPING_NOTN == "015/2023" || ANTI_DUMPING_NOTN == "017/2023" || ANTI_DUMPING_NOTN == "011/2024" || ANTI_DUMPING_NOTN == "006/2025" || ANTI_DUMPING_NOTN == "021/2025" || ANTI_DUMPING_NOTN == "004/2025")// Sugg.By Bala sir on 22-02-2024 for OECL Shipping
                    {
                        TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    }
                    else
                    {
                        //this calc newly added sugg.by Bala sir done by Chithra on 23/12/2020
                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt)) / 100;
                    }


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
                    //TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }

                //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "         " + "        " + ADD_DIFF_CUR + "%" + "  " + TOTAL_ANTIDUMP_AMT;

            }
            //---------End New Anti-Dumping Calculation implemented on 27Sep2018------------//




            // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
            Call_IGST_General();

            /* Newly Implemented on 27-10-2025 by chithra for Paramount Sugg.by Bala sir - Dutiable  only*/
            MERIT_IGST_AMT = (ASSESABLE_VALUE + MERIT_BASIC_DUTY + merit_social_welfare_cess + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
            MERIT_BCD_FG_AMT = MERIT_BASIC_DUTY + merit_social_welfare_cess + AIDC_Amt + MERIT_IGST_AMT;
            MERIT_BCD_FG_AMT = MERIT_BCD_FG_AMT - (BASIC_DUTY + Customs_Social_welfare + AIDC_Amt + IGST_LEV_1_AMT);
            TOTAL_DUTY_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(MERIT_BCD_FG_AMT), 1).ToString("0.00"));

            CHK_IGST_ASSBL_VAL = 0.00;
            if (RSP_APPLICABLE == "S" && (MRP_AMT > IGST_LEV_1_AMT_ASS))
            {
                CHK_IGST_ASSBL_VAL = MRP_AMT; //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
            }
            else
            {
                if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                {
                    CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
                }
                else
                {
                    CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt + SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT); //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                }
                tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void Scheme_DUTIABLE_Chapter_24_27()
    {
        try
        {
            double bcd_rate = 0.00;
            double bcd_Amt = 0.00;
            Healthcess_RateVal = 0.00;
            //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

            if (PRODUCT_BCD_NOTN != "")
            {
                if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
                {
                    //NOTIFICATION_CUSTOMS_BCD_RATE = "";


                    //--if "NOTIFICATION_CUSTOMS_BCD_SPL" is "0" "CTH_SPL_AMT" - should be "0" - confirmed with Final Print for Aeroship.. sugg.By Bala Sir on 20-03-2021
                    //if (Session["COMPANY_ID"].ToString() == "145" || Session["COMPANY_ID"].ToString() == "262" || Session["COMPANY_ID"].ToString() == "184" || Session["COMPANY_ID"].ToString() == "223" || Session["COMPANY_ID"].ToString() == "224" || Session["COMPANY_ID"].ToString() == "164" || Session["COMPANY_ID"].ToString() == "1026" || Session["COMPANY_ID"].ToString() == "1048")
                    //{
                    CTH_SPL_AMT = "0";
                    //}
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
                    if (PRODUCT_BCD_RATE != "")
                    {
                        bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                    }
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

            if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
            {

                BASIC_DUTY = 0.00;
                bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
            }
            else
            {
                if (Convert.ToDouble(PRODUCT_BCD_RATE) == 0.00 || Convert.ToDouble(PRODUCT_BCD_RATE) == 0)
                {
                    BASIC_DUTY = 0.00;
                }
            }

            if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
            {
                //CTH_SPL_AMT = "";
                BASIC_DUTY = bcd_rate;
            }
            else
            {
                //bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                double cth_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);

                if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                {
                    if (cth_Amt <= bcd_rate)
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                    else
                    {
                        //BASIC_DUTY = bcd_Amt;
                        if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                        else
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                    }
                }
                else if (NOTIFICATION_FLAG == "+")
                {
                    if (bcd_rate >= bcd_Amt)
                    {
                        BASIC_DUTY = cth_Amt + bcd_rate;
                    }
                    else
                    {
                        BASIC_DUTY = cth_Amt + bcd_Amt;
                    }
                }
                else //-- NOTIFICATION_FLAG == "H" or others
                {
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
                    bcd_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_BCD_SPL);

                    /* hide By chithra for implement H,L,+ - above code BASIC_DUTY value again update here.. on 02/08/2019
                        if (bcd_rate >= cth_Amt)
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                        else
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                     */

                    if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                    {
                        if (bcd_Amt <= bcd_rate)
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                    }

                    if (COMPANY_ID == "313")
                    {
                        if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                    }

                    //BASIC_DUTY_BCD_SPL = cth_Amt;
                    //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                    CTH_SPL_AMT = PRODUCT_BCD_SPL;
                    CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
                }
            }


            //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
            //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
            if (PRODUCT_BCD_NOTN != "")
            {
                BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
                BCD_FOREGONE_AMT = Convert.ToString(Math.Round(BCD_FG_AMT, 1).ToString("0.00"));
            }
            else
            {
                BCD_FG_AMT = BASIC_DUTY;
                BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
            }
            //--------------------------------------------

            //-----------------------------NCD CALCULATION---------------------------------------//
            /* hide by Chithra on 07-08-2019 for HPCL Checklist NCD SPL AMOUNT
            if (Convert.ToDecimal(CTH_NCD_D_RATE) == 1)
            {
                NCD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(CTH_NCD_D_RATE) / 100;
            }
            else
            {
                NCD = 0.00;
            }
            */


            if (CETH_NCD_SPL_DUTY != "")
            {
                NCD = c_ITEM_QTY * Convert.ToDouble(CETH_NCD_SPL_DUTY);
            }
            //else if (Convert.ToDecimal(CTH_NCD_D_RATE) == 1)
            //{
            //    NCD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(CTH_NCD_D_RATE) / 100;
            //}
            else if (CETH_NCD_RATE != "")
            {
                CTH_NCD_D_RATE = CETH_NCD_RATE;
                NCD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(CTH_NCD_D_RATE) / 100;
            }
            else
            {
                NCD = 0.00;
            }

            //-----------------------------END NCD CALCULATION---------------------------------------//

            //-------HEALTH CESS CALCULATION
            HEALTH_CESS_TOTAL = "0.00";
            if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
            {
                if (HEALTH_CESS_CTH_CODE != "")
                {
                    Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                    HEALTH_CESS_TOTAL = Convert.ToString(Healthcess_RateVal);
                }
            }
            else
            {
                HEALTH_CESS_RATE = "0.00";
            }

            //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
            Get_Less_Sapta_Rate();

            //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
            AIDC_Amt = NOTN_AIDC_CALC();

            //-------SOCIAL WELFARE CALCULATION

            /*--02-02-2021
            if (SOCIAL_WELFARE_NOTN != "")
            {
                SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }
            */

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

            if (PRODUCT_CETH_CHAPTER == "NOEXCISE")
            {
                NCD = 0.00;
            }

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
                if (PRODUCT_CVD_RATE != "")
                {
                    CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY + NCD) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;
                }
            }


            //---------------Start Updated on 04 July 2014------------------//


            double CVD_Amt = 0.00;

            if (PRODUCT_CVD_SPL != "")
            {
                if (PRODUCT_CVD_NOTN == "003/2025 1")
                {
                    double CVD_Calc1 = 0.00, Individual_CVD = 0.00;
                    CVD_Calc1 = ASSESABLE_VALUE + BASIC_DUTY;
                    Individual_CVD = CVD_Calc1 / Convert.ToDouble(CTH_QTY) / EXCHANGE_RATE;
                    CVD_Calc1 = Convert.ToDouble(PRODUCT_CVD_SPL) - Individual_CVD;

                    if (CVD_Calc1 < 0)
                    {
                        CVD_Amt = 0.00;
                    }
                    else
                    {
                        CVD_Amt = CVD_Calc1 * Convert.ToDouble(CTH_QTY) * EXCHANGE_RATE;
                    }
                }
                else if (Convert.ToDouble(PRODUCT_CVD_SPL) != 0.00 || Convert.ToDouble(PRODUCT_CVD_SPL) != 0)
                {
                    CVD_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_CVD_SPL);
                    CETH_SPL_AMT = PRODUCT_CVD_SPL;
                }
            }
            else
            {
                CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT);
            }

            //---------------End Updated on 04 July 2014------------------//

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
                        CESS = c_ITEM_QTY * Convert.ToDouble(CETH_CESS_AMTS);
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

            //---------------------------- CESS AMT Calc again enable for BOXCO on 25-10-2019 by Chithra sugg by Bala sir & Sathish sir..
            //if ((COMPANY_ID == "1" || COMPANY_ID == "4" || COMPANY_ID == "116") && (PRODUCT_CETH == "27101930"))
            if (CETH_EXEC_AIDC_RATE != "")//Newly Implemented on 23-10-2024 Rate getting from CETH_MASTER
            {
                AIDC_24_27_Exec = "Y";

                if (EXC_AIDC_NOTN != "")
                {
                    AIDC_EXEC_AMT = Convert.ToString(c_ITEM_QTY * Convert.ToDouble(EXC_AIDC_RATE));
                }
                else
                {
                    AIDC_EXEC_AMT = Convert.ToString(c_ITEM_QTY * Convert.ToDouble(EXC_AIDC_RATE));
                    EXC_AIDC_SPL_AMT = EXC_AIDC_RATE;
                }

                EXC_AIDC_CHECKLIST_AMT = AIDC_EXEC_AMT;
            }

            CESS = 0.00;
            if ((Convert.ToDouble(CETH_CESS_AMTS) != 0.00) || (Convert.ToDouble(CETH_CESS_AMTS) > 0.00))
            {
                if (Convert.ToDouble(CETH_CESS_AMTS) != 0.00)
                {
                    CESS = c_ITEM_QTY * Convert.ToDouble(CETH_CESS_AMTS);
                }
            }
            else if (Convert.ToDouble(CETH_CESS_RTA) != 0.00 || Convert.ToDouble(CETH_CESS_RTA) > 0.00)
            {
                CESS = (ASSESABLE_VALUE + BASIC_DUTY + NCD) * Convert.ToDouble(CETH_CESS_RTA) / 100;

            }
            else
            {
            }

            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            if (COMPANY_ID == "182")
            {
                //CVD = CVD * 20;
                CVD = CVD + CVD_Amt;
            }

            if (COMPANY_ID == "162" && CVD_NOTN == "012/2012" && PRODUCT_CVD_NOTN_SLNO == "51(ii)")
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

            //if (PRODUCT_CETH.Substring(0, 2) != "24")// hide by Chithra on 06-08-2019 for 24,27 Chapter HPCL
            /*//hide on 23-10-2024 for New Settings
            if (PRODUCT_CETH_CHAPTER == "NOEXCISE")
            {
                CVD = 0.00;
                CVD_TOTAL = "0.00";
                PRODUCT_CVD_RATE = "0.00";
            }
            else if (PRODUCT_CETH == "24029090" || PRODUCT_CETH == "24022090" || PRODUCT_CETH == "24039100" || PRODUCT_CETH == "24011090" || PRODUCT_CETH == "24012090")//Need Settings Here
            {
                CVD = 0.00;
                CVD_TOTAL = "0.00";
                PRODUCT_CVD_RATE = "0.00";
            }
             * */

            if (CETH_CVD_NIL_YN == "Y")
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
                //Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT-- hide on 05-03-2024

                /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                {
                                                    Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                }
                                                else
                                                {
                                                    Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                }
                                                */
                Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));

            }
            else if (PRODUCT_OTHER_DUTY_SPL != "")
            {
                Other_duty = c_ITEM_QTY * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
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

            //if ((COMPANY_ID == "1" || COMPANY_ID == "4" || COMPANY_ID == "116") && (PRODUCT_CETH == "27101930"))
            if (PRODUCT_CETH == "27101930" || PRODUCT_CETH == "27101949" || PRODUCT_CETH == "27101290" || PRODUCT_CETH == "27101241")
            {
                GSI_TOTAL = "0.00";
                if (CETH_SIA_I_RATE != "")
                {
                    if (Convert.ToDouble(CETH_SIA_I_RATE) > 0)
                    {
                        CETH_SIA_I_amt = c_ITEM_QTY * Convert.ToDouble(CETH_SIA_I_RATE);
                        GSI_TOTAL = Convert.ToString(CETH_SIA_I_amt);

                    }
                }
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

            //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;




            AddL_DUTY = 0.00;

            SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

            //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
            Actual_BASIC_DUTY = BASIC_DUTY;

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
                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                Aggregate_SWS = Customs_Social_welfare;

                double AGGREGATE_DUTY_a = (Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess + Aggregate_SWS);
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
                Aggregate_SWS = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;//SWS


                //AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;

                AGGREGATE_DUTY = AGGREGATE_DUTY_a - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess + Aggregate_SWS);
                //AGGREGATE_DUTY = AGGREGATE_DUTY_a - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd);
            }

            CVD_CEC_TOTAL = "0.00";
            CVD_CHEC_TOTAL = "0.00";

            //if ((COMPANY_ID == "1" || COMPANY_ID == "4" || COMPANY_ID == "116") && (PRODUCT_CETH == "27101930"))
            if (PRODUCT_CETH == "27101930" || PRODUCT_CETH == "27101949" || PRODUCT_CETH == "27101290" || PRODUCT_CETH == "27101241")//Need Settings Here
            {
                //#SWS
                if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                {
                    Customs_Social_welfare = (BASIC_DUTY + CVD + NCD + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(CESS) + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }
                else
                {
                    Customs_Social_welfare = (BASIC_DUTY + CVD + NCD + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(CESS) + Healthcess_RateVal + AIDC_Amt + Convert.ToDouble(AIDC_EXEC_AMT)) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    //Customs_Social_welfare = (BASIC_DUTY + CVD + NCD + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(CESS) + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }
            }
            else
            {
                //#SWS
                if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                {
                    Customs_Social_welfare = (BASIC_DUTY + CVD + NCD + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }
                else
                {
                    Customs_Social_welfare = (BASIC_DUTY + CVD + NCD + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }
            }

            //--------------SWS FOREGONE AMOUNT----By Chithra on 24-11-2025 for Capricorn-----------
            //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
            if (SOCIAL_WELFARE_NOTN != "")
            {
                SWS_FG_AMT = merit_social_welfare_cess - Customs_Social_welfare;
                SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Customs_Social_welfare, 1).ToString("0.00"));
            }
            else
            {
                SWS_FOREGONE_AMT = Convert.ToString(Customs_Social_welfare);
            }
            SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));


            SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 2).ToString("0.00"));

            if (COMPANY_ID == "248")
            {
                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 2).ToString("0.00"));
            }
            else
            {
                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
            }

            AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
            SAPTA_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAPTA_DUTY), 1).ToString("0.00"));
            CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CESS), 1).ToString("0.00"));
            NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
            CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
            CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));
            AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));


            ADDLTIONAL_DUTY_TOTAL = "0.00";
            //if ((COMPANY_ID == "1" || COMPANY_ID == "4" || COMPANY_ID == "116") && (PRODUCT_CETH == "27101930"))
            if (PRODUCT_CETH == "27101930" || PRODUCT_CETH == "27101949" || PRODUCT_CETH == "27101290")
            {
                if (PRODUCT_ADDL_DUTY_RATE != "")
                {
                    ADDLTIONAL_DUTY_TOTAL = Convert.ToString((Convert.ToDouble(ASSESABLE_VALUE) + Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(CESS)) * Convert.ToDouble(PRODUCT_ADDL_DUTY_RATE) / 100);
                    ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL), 1).ToString("0.00"));//19-feb-2021
                }
                else
                {
                    PRODUCT_ADDL_DUTY_RATE = "0.00";
                }
            }

            INFRA_CESS_TOTAL = "0.00";

            //ITEM_PRODUCT_DETAILS_ADDITIONAL
            CHECKLIST_SAFEGUARD_DUTY_AMT = SAFE_GUARD_TOTAL;
            CHECKLIST_NCD_DUTY_AMT = NCD_TOTAL;
            CHECKLIST_AGGREGATE_DUTY_AMT = AGGREGATE_TOTAL;
            CHECKLIST_SAPTA_DUTY_AMT = SAPTA_TOTAL;
            CHECKLIST_GSI_DUTY_AMT = "0.00";
            CHECKLIST_TTA_DUTY_AMT = "0.00";
            CHECKLIST_SCHED11_DUTY_AMT = "0.00";
            CHECKLIST_OTHER_DUTY_AMT = PRODUCT_OTHER_DUTY_TOTAL;
            CHECKLIST_INFRACESS_DUTY_AMT = INFRA_CESS_TOTAL;


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

                        //hide on 05-03-2024 Sugg.by Bala Sir
                        //double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                        double Anti_Dump_Cal2 = 0.00;
                        /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                       if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                       {
                                                           Anti_Dump_Cal2 = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                       }
                                                       else
                                                       {
                                                           Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                       }
                                                         */
                        Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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

                    /* hide on 05-11-2024 - Sugg.by Bala sir
                   TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                   MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                   */

                    if (ANTI_DUMPING_NOTN == "015/2023" || ANTI_DUMPING_NOTN == "017/2023" || ANTI_DUMPING_NOTN == "011/2024" || ANTI_DUMPING_NOTN == "006/2025" || ANTI_DUMPING_NOTN == "021/2025" || ANTI_DUMPING_NOTN == "004/2025")// Sugg.By Bala sir on 22-02-2024 for OECL Shipping
                    {
                        TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    }
                    else
                    {
                        //this calc newly added sugg.by Bala sir done by Chithra on 23/12/2020
                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt)) / 100;
                    }

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
                    //TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }

                //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "         " + "        " + ADD_DIFF_CUR + "%" + "  " + TOTAL_ANTIDUMP_AMT;

            }
            //---------End New Anti-Dumping Calculation implemented on 27Sep2018------------//



            // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
            if (CETH_ADDL_DUTY_IMPORTS_YN == "N")// added by pandiyan on 12-06-2025 sugg by bala 
            {
                Call_IGST_General();
            }
            else
            {
                IGST_LEV_1_AMT = 0.00;
            }
            CHK_IGST_ASSBL_VAL = 0.00;
            if (RSP_APPLICABLE == "S" && (MRP_AMT > IGST_LEV_1_AMT_ASS))
            {
                CHK_IGST_ASSBL_VAL = MRP_AMT; //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
            }
            else
            {

                if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                {
                    CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
                }
                else
                {
                    CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt + SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT); //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                }
                tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    private void Scheme_DUTIABLE_CIGARETTE_Calc()
    {
        try
        {
            double bcd_rate = 0.00;
            double bcd_Amt = 0.00;
            Healthcess_RateVal = 0.00;
            BCD_FG_AMT = 0.00;
            IGST_FG_AMT = 0.00;
            SWS_FG_AMT = 0.00;
            //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

            if (PRODUCT_BCD_NOTN != "")
            {
                if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
                {
                    //NOTIFICATION_CUSTOMS_BCD_RATE = "";

                    //--if "NOTIFICATION_CUSTOMS_BCD_SPL" is "0" "CTH_SPL_AMT" - should be "0" - confirmed with Final Print for Aeroship.. sugg.By Bala Sir on 20-03-2021
                    //if (Session["COMPANY_ID"].ToString() == "145" || Session["COMPANY_ID"].ToString() == "262" || Session["COMPANY_ID"].ToString() == "184" || Session["COMPANY_ID"].ToString() == "223" || Session["COMPANY_ID"].ToString() == "224" || Session["COMPANY_ID"].ToString() == "164" || Session["COMPANY_ID"].ToString() == "1026" || Session["COMPANY_ID"].ToString() == "1048")
                    //{
                    CTH_SPL_AMT = "0";
                    //}
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
                    if (PRODUCT_BCD_RATE != "")
                    {
                        bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                    }
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
            if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
            {
                BASIC_DUTY = 0.00;
                bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
            }
            else
            {
                if (Convert.ToDouble(PRODUCT_BCD_RATE) == 0.00 || Convert.ToDouble(PRODUCT_BCD_RATE) == 0)
                {
                    BASIC_DUTY = 0.00;
                }
            }

            if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
            {
                //CTH_SPL_AMT = "";
                BASIC_DUTY = bcd_rate;
            }
            else
            {
                //bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                double cth_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);


                if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                {
                    if (cth_Amt <= bcd_rate)
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                    else
                    {
                        //BASIC_DUTY = bcd_Amt;
                        if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                        else
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                    }
                }
                else if (NOTIFICATION_FLAG == "+")
                {
                    if (bcd_rate >= bcd_Amt)
                    {
                        BASIC_DUTY = cth_Amt + bcd_rate;
                    }
                    else
                    {
                        BASIC_DUTY = cth_Amt + bcd_Amt;
                    }
                }
                else //-- NOTIFICATION_FLAG == "H" or others
                {
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
                    bcd_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_BCD_SPL);

                    /* hide By chithra for implement H,L,+ - above code BASIC_DUTY value again update here.. on 02/08/2019
                        if (bcd_rate >= cth_Amt)
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                        else
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                     */

                    if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                    {
                        if (bcd_Amt <= bcd_rate)
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                    }

                    if (COMPANY_ID == "313")
                    {
                        if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                    }

                    //BASIC_DUTY_BCD_SPL = cth_Amt;
                    //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                    CTH_SPL_AMT = PRODUCT_BCD_SPL;
                    CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
                }
            }


            //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

            bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

            //---------------END SAPTA CALCULATION-------------------------//

            //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
            //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
            if (PRODUCT_BCD_NOTN != "")
            {
                BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
                BCD_FOREGONE_AMT = Convert.ToString(Math.Round(BCD_FG_AMT, 1).ToString("0.00"));
            }
            else
            {
                BCD_FG_AMT = BASIC_DUTY;
                BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
            }
            //--------------------------------------------


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
                if (PRODUCT_CVD_RATE != "")
                {
                    CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY + NCD) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;
                }
            }


            //---------------Start Updated on 04 July 2014------------------//

            double CVD_Amt = 0.00;

            if (PRODUCT_CVD_SPL != "")
            {
                if (Convert.ToDouble(PRODUCT_CVD_SPL) != 0.00 || Convert.ToDouble(PRODUCT_CVD_SPL) != 0)
                {
                    CVD_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_CVD_SPL);
                    CETH_SPL_AMT = PRODUCT_CVD_SPL;
                }
            }
            else
            {
                CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT);
            }




            //------------ CETH SPL AMOUNT CALC- Newly implented on 11-09-2019 by Chithra for CIGARATTE Fairmacs

            CVD_SPL_AMT = 0.00;


            if (Convert.ToDecimal(CETH_SPL_AMT) <= 0)
            {
                //CTH_SPL_AMT = "";
                CVD_SPL_AMT = CVD_Rate;
            }
            else
            {
                CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT);
            }


            //---------------End Updated on 04 July 2014------------------//






            //double CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT); //disabled on 04 July 2014

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
                        CESS = c_ITEM_QTY * Convert.ToDouble(CETH_CESS_AMTS);
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


            if (CETH_EXEC_AIDC_RATE != "")//Newly Implemented on 23-10-2024 Rate getting from CETH_MASTER
            {
                AIDC_24_27_Exec = "Y";

                if (EXC_AIDC_NOTN != "")
                {
                    AIDC_EXEC_AMT = Convert.ToString(c_ITEM_QTY * Convert.ToDouble(EXC_AIDC_RATE));
                }
                else
                {
                    AIDC_EXEC_AMT = Convert.ToString(c_ITEM_QTY * Convert.ToDouble(EXC_AIDC_RATE));
                    EXC_AIDC_SPL_AMT = EXC_AIDC_RATE;
                }

                EXC_AIDC_CHECKLIST_AMT = AIDC_EXEC_AMT;
            }

            CESS = 0.00;
            if ((Convert.ToDouble(CETH_CESS_AMTS) != 0.00) || (Convert.ToDouble(CETH_CESS_AMTS) > 0.00))
            {
                if (Convert.ToDouble(CETH_CESS_AMTS) != 0.00)
                {
                    CESS = c_ITEM_QTY * Convert.ToDouble(CETH_CESS_AMTS);
                }
            }
            else if (Convert.ToDouble(CETH_CESS_RTA) != 0.00 || Convert.ToDouble(CETH_CESS_RTA) > 0.00)
            {
                CESS = (ASSESABLE_VALUE + BASIC_DUTY + NCD) * Convert.ToDouble(CETH_CESS_RTA) / 100;

            }
            else
            {
            }
            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            if (COMPANY_ID == "182")
            {
                //CVD = CVD * 20;
                CVD = CVD + CVD_Amt;
            }

            if (COMPANY_ID == "162" && CVD_NOTN == "012/2012" && PRODUCT_CVD_NOTN_SLNO == "51(ii)")
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

            //if (PRODUCT_CETH.Substring(0, 2) != "24")
            //{
            //    CVD = 0.00;
            //    CVD_TOTAL = "0.00";
            //    PRODUCT_CVD_RATE = "0.00";
            //}
            //else if (PRODUCT_CETH == "24029090" || PRODUCT_CETH == "24022090")
            //{
            //    CVD = 0.00;
            //    CVD_TOTAL = "0.00";
            //    PRODUCT_CVD_RATE = "0.00";
            //}

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
                //Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT-- hide on 05-03-2024

                /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                {
                                                    Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                }
                                                else
                                                {
                                                    Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                }
                                                */
                Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));

            }
            else if (PRODUCT_OTHER_DUTY_SPL != "")
            {
                Other_duty = c_ITEM_QTY * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
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

            //CETH_CESS_AMTS = Convert.ToString(Convert.ToDouble(ceth_cess_amount).ToString("F"));

            GSI_TOTAL = "0.00";
            if (CETH_SIA_I_RATE != "")
            {
                if (Convert.ToDouble(CETH_SIA_I_RATE) > 0)
                {
                    CETH_SIA_I_amt = c_ITEM_QTY * Convert.ToDouble(CETH_SIA_I_RATE);
                    GSI_TOTAL = Convert.ToString(CETH_SIA_I_amt);
                }
            }

            //---------------National Calamity Contingent Duty (NCCD) - NCD DUTY ------------------------------
            /* hide on 29-07-2024
            if (CETH_NCD_SPL_DUTY != "")
            {
                NCD = c_ITEM_QTY * Convert.ToDouble(CETH_NCD_SPL_DUTY);
            }
            else if (Convert.ToDecimal(CTH_NCD_D_RATE) == 1)
            {
                NCD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(CTH_NCD_D_RATE) / 100;
            }
            else
            {
                NCD = 0.00;
            }
             * */

            if (CETH_NCD_SPL_DUTY != "")
            {
                NCD = c_ITEM_QTY * Convert.ToDouble(CETH_NCD_SPL_DUTY);
            }
            else if (CETH_NCD_RATE != "")
            {
                CTH_NCD_D_RATE = CETH_NCD_RATE;
                NCD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(CTH_NCD_D_RATE) / 100;
            }
            else
            {
                NCD = 0.00;
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

            //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

            AddL_DUTY = 0.00;

            SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

            //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
            Actual_BASIC_DUTY = BASIC_DUTY;

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
                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                Aggregate_SWS = Customs_Social_welfare;

                double AGGREGATE_DUTY_a = (Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess + Aggregate_SWS);
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
                Aggregate_SWS = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;//SWS

                //AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;

                AGGREGATE_DUTY = AGGREGATE_DUTY_a - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess + Aggregate_SWS);
                //AGGREGATE_DUTY = AGGREGATE_DUTY_a - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd);
            }

            CVD_CEC_TOTAL = "0.00";
            CVD_CHEC_TOTAL = "0.00";

            //-------HEALTH CESS CALCULATION
            HEALTH_CESS_TOTAL = "0.00";
            if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
            {
                if (HEALTH_CESS_CTH_CODE != "")
                {
                    Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                    HEALTH_CESS_TOTAL = Convert.ToString(Healthcess_RateVal);
                }
            }
            else
            {
                HEALTH_CESS_RATE = "0.00";
            }


            //-------SOCIAL WELFARE CALCULATION
            /* --02-02-2021
            if (SOCIAL_WELFARE_NOTN != "")
            {
                SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }
            */

            //#SWS
            if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
            {
                Customs_Social_welfare = (BASIC_DUTY + CVD + CETH_SIA_I_amt + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }
            else
            {
                //hide on 23-03-2025 by Chithra - Sugg.by Bala sir & Checked with Final Print
                //Customs_Social_welfare = (BASIC_DUTY + CVD + CETH_SIA_I_amt + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                Customs_Social_welfare = (BASIC_DUTY + CVD + CETH_SIA_I_amt + Healthcess_RateVal + NCD + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(EXC_AIDC_CHECKLIST_AMT) + CESS) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

            }

            //--------------SWS FOREGONE AMOUNT----By Chithra on 24-11-2025 for Capricorn-----------
            //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
            if (SOCIAL_WELFARE_NOTN != "")
            {
                SWS_FG_AMT = merit_social_welfare_cess - Customs_Social_welfare;
                SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Customs_Social_welfare, 1).ToString("0.00"));
            }
            else
            {
                SWS_FOREGONE_AMT = Convert.ToString(Customs_Social_welfare);
            }
            SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));


            SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 2).ToString("0.00"));

            if (COMPANY_ID == "248")
            {
                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 2).ToString("0.00"));
            }
            else
            {
                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
            }

            if (SCHEME_NOTN_.Trim() == "RoDTEP Scheme" && CIGARATTE_RITC_YN == "Y")
            {
                BASIC_DUTY_TOTAL = Convert.ToString("0.00");
            }

            AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));

            CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CESS), 1).ToString("0.00"));
            NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
            CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
            CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));

            ADDLTIONAL_DUTY_TOTAL = "0.00";
            if (PRODUCT_CETH == "27101930" || PRODUCT_CETH == "27101949" || PRODUCT_CETH == "27101290")
            {
                if (PRODUCT_ADDL_DUTY_RATE != "")
                {
                    //hide on 23-03-2025 by Chithra - Sugg.by Bala sir & Checked with Final Print
                    // ADDLTIONAL_DUTY_TOTAL = Convert.ToString((Convert.ToDouble(ASSESABLE_VALUE) + Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(CESS)) * Convert.ToDouble(PRODUCT_ADDL_DUTY_RATE) / 100);
                    ADDLTIONAL_DUTY_TOTAL = Convert.ToString((Convert.ToDouble(ASSESABLE_VALUE) + Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(CESS)) * Convert.ToDouble(PRODUCT_ADDL_DUTY_RATE) / 100);

                    ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL), 1).ToString("0.00"));//19-feb-2021
                }
                else
                {
                    PRODUCT_ADDL_DUTY_RATE = "0.00";
                }
            }
            INFRA_CESS_TOTAL = "0.00";

            //ITEM_PRODUCT_DETAILS_ADDITIONAL
            CHECKLIST_SAFEGUARD_DUTY_AMT = SAFE_GUARD_TOTAL;
            CHECKLIST_NCD_DUTY_AMT = NCD_TOTAL;
            CHECKLIST_AGGREGATE_DUTY_AMT = AGGREGATE_TOTAL;
            CHECKLIST_SAPTA_DUTY_AMT = SAPTA_TOTAL;
            CHECKLIST_GSI_DUTY_AMT = "0.00";
            CHECKLIST_TTA_DUTY_AMT = "0.00";
            CHECKLIST_SCHED11_DUTY_AMT = "0.00";
            CHECKLIST_OTHER_DUTY_AMT = PRODUCT_OTHER_DUTY_TOTAL;
            CHECKLIST_INFRACESS_DUTY_AMT = INFRA_CESS_TOTAL;


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

                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                        TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));

                        //hide on 05-03-2024 Sugg.by Bala Sir
                        //double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                        double Anti_Dump_Cal2 = 0.00;
                        /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                      if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                      {
                                                          Anti_Dump_Cal2 = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                      }
                                                      else
                                                      {
                                                          Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                      }
                                                        */
                        Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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

                    /* hide on 05-11-2024 - Sugg.by Bala sir
                   TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                   MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                     * */


                    if (ANTI_DUMPING_NOTN == "015/2023" || ANTI_DUMPING_NOTN == "017/2023" || ANTI_DUMPING_NOTN == "011/2024" || ANTI_DUMPING_NOTN == "006/2025" || ANTI_DUMPING_NOTN == "021/2025" || ANTI_DUMPING_NOTN == "004/2025")// Sugg.By Bala sir on 22-02-2024 for OECL Shipping
                    {
                        TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    }
                    else
                    {
                        //this calc newly added sugg.by Bala sir done by Chithra on 23/12/2020
                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt)) / 100;
                    }

                    TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }


                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + TOTAL_ANTI_AMT;

            }
            else if (ADD_DIFF_CUR != null && ADD_DIFF_CUR != "")
            {
                if (ADD_AMT_MINUS_ASSESABLE == "2")
                {
                    TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble((ADD_DIFF_CUR)) / 100;

                    if (TOTAL_ANTIDUMP_AMT <= 0)
                    {
                        TOTAL_ANTIDUMP_AMT = 0.00;
                    }
                    //TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }

                //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "         " + "        " + ADD_DIFF_CUR + "%" + "  " + TOTAL_ANTIDUMP_AMT;

            }

            if (SCHEME_NOTN_.Trim() == "RoDTEP Scheme" && CIGARATTE_RITC_YN == "Y") // added by pandiyan on 08-07-2025 sugg by bala 
            {
                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY));
            }


            //---------End New Anti-Dumping Calculation implemented on 27Sep2018------------//



            // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
            /* //Hided by pandiyan on 01-07-2025 
            if (CIGARATTE_RITC_YN == "N") // added by pandiyan on 12-06-2025 sugg by bala 
            {
                Call_IGST_General_CIGARETTE();
            }
            else
            {
                IGST_LEV_1_AMT = 0.00;
            }
            */
            Call_IGST_General_CIGARETTE();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    private void Scheme_EPCG(DataTable dss1, adminmaster adm_Mas)
    {
        try
        {
            adminmaster adm = new adminmaster();
            BCD_FG_AMT = 0.00;
            IGST_FG_AMT = 0.00;
            SWS_FG_AMT = 0.00;

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
                    Healthcess_RateVal = 0.00;


                    /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                    //-------HEALTH CESS CALCULATION
                    HEALTH_CESS_TOTAL = "0.00";
                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    {
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                        }
                    }

                    //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
                    Get_Less_Sapta_Rate();

                    //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                    AIDC_Amt = NOTN_AIDC_CALC();

                    //#SWS
                    if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                    {
                        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }
                    else
                    {
                        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }

                    SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

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
                    Healthcess_RateVal = 0.00;

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

                    //-------HEALTH CESS CALCULATION
                    HEALTH_CESS_TOTAL = "0.00";
                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    {
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                        }
                    }

                    //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
                    Get_Less_Sapta_Rate();

                    //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                    AIDC_Amt = NOTN_AIDC_CALC();


                    SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;
                }

                //#SWS
                if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                {
                    Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }
                else
                {
                    Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }

                //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                Actual_BASIC_DUTY = BASIC_DUTY;

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
                HEALTH_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Healthcess_RateVal), 1).ToString("0.00"));
                AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));//01-feb-2021

                //-----------------------CALCULATION FOR TOTAL DEBIT DUTY--------------------------------//

                double bcd_rate = Convert.ToDouble(PRODUCT_BCD_RATE) - Convert.ToDouble(SCHEME_RATE_NEW);
                bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(bcd_rate) / 100;

                //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

                if (PRODUCT_BCD_NOTN != "")
                {
                    if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
                    {
                        //NOTIFICATION_CUSTOMS_BCD_RATE = "";

                        //--if "NOTIFICATION_CUSTOMS_BCD_SPL" is "0" "CTH_SPL_AMT" - should be "0" - confirmed with Final Print for Aeroship.. sugg.By Bala Sir on 20-03-2021
                        //if (Session["COMPANY_ID"].ToString() == "145" || Session["COMPANY_ID"].ToString() == "262" || Session["COMPANY_ID"].ToString() == "184" || Session["COMPANY_ID"].ToString() == "223" || Session["COMPANY_ID"].ToString() == "224" || Session["COMPANY_ID"].ToString() == "164" || Session["COMPANY_ID"].ToString() == "1026" || Session["COMPANY_ID"].ToString() == "1048")
                        //{
                        CTH_SPL_AMT = "0";
                        //}
                    }
                }

                //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

                if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                {
                    //CTH_SPL_AMT = "";
                    BASIC_DUTY = bcd_rate;
                }
                else
                {
                    double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                    //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                    double cth_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);

                    if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                    {
                        if (cth_Amt <= bcd_rate)
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                        else
                        {
                            //BASIC_DUTY = bcd_Amt;
                            if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                            {
                                BASIC_DUTY = bcd_Amt;
                            }
                            else
                            {
                                BASIC_DUTY = bcd_rate;
                            }
                        }
                    }
                    else if (NOTIFICATION_FLAG == "+")
                    {
                        if (bcd_rate >= bcd_Amt)
                        {
                            BASIC_DUTY = cth_Amt + bcd_rate;
                        }
                        else
                        {
                            BASIC_DUTY = cth_Amt + bcd_Amt;
                        }
                    }
                    else //-- NOTIFICATION_FLAG == "H" or others
                    {

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
                }

                //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

                bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

                //---------------END SAPTA CALCULATION-------------------------//

                //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
                //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
                if (PRODUCT_BCD_NOTN != "")
                {
                    BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
                    BCD_FOREGONE_AMT = Convert.ToString(Math.Round(BCD_FG_AMT, 1).ToString("0.00"));
                }
                else
                {
                    BCD_FG_AMT = BASIC_DUTY;
                    BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
                }
                //--------------------------------------------


                //SOCIAL WELFARE CALCULATION
                /*
                if (SOCIAL_WELFARE_NOTN != "")
                {
                    SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }
                */


                //-----------------------------NCD CALCULATION---------------------------------------//
                NCD = 0.00;
                //-----------------------------END NCD CALCULATION---------------------------------------//


                double bcd = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                CVD = (ASSESABLE_VALUE + bcd) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra

                //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                /*//hide on 23-10-2024 for New Settings
                if (PRODUCT_CETH.Substring(0, 2) != "24")
                {
                    CVD_TOTAL = "0";
                    CVD = 0.00;
                    PRODUCT_CVD_RATE = "0.00";
                    PRODUCT_CETH = "NOEXCISE";
                }
                 * */

                if (CETH_CVD_NIL_YN == "Y")
                {
                    CVD = 0.00;
                    CVD_TOTAL = "0.00";
                    PRODUCT_CVD_RATE = "0.00";
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


                //#SWS
                if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                {
                    Customs_Social_welfare = (bcd + CVD + Convert.ToDouble(GSI_TOTAL) + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    Customs_social_welfare_a = (BASIC_DUTY + CVD + Convert.ToDouble(GSI_TOTAL) + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }
                else
                {
                    Customs_Social_welfare = (bcd + CVD + Convert.ToDouble(GSI_TOTAL) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    Customs_social_welfare_a = (BASIC_DUTY + CVD + Convert.ToDouble(GSI_TOTAL) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }

                //Customs_Social_welfare = (bcd + CVD + Convert.ToDouble(GSI_TOTAL) + Healthcess_RateVal ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                //Customs_social_welfare_a = (BASIC_DUTY + CVD + Convert.ToDouble(GSI_TOTAL) + Healthcess_RateVal ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

                //--------------SWS FOREGONE AMOUNT----By Chithra on 24-11-2025 for Capricorn-----------
                //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
                if (SOCIAL_WELFARE_NOTN != "")
                {
                    SWS_FG_AMT = merit_social_welfare_cess - Customs_Social_welfare;
                    SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Customs_Social_welfare, 1).ToString("0.00"));
                }
                else
                {
                    SWS_FOREGONE_AMT = Convert.ToString(Customs_Social_welfare);
                }
                SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));


                AddL_DUTY = 0.00;


                //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//
                if (COMPANY_ID == "247" || COMPANY_ID == "10")
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

                            //hide on 05-03-2024 Sugg.by Bala Sir
                            //double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                            double Anti_Dump_Cal2 = 0.00;
                            /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                       if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                       {
                                                           Anti_Dump_Cal2 = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                       }
                                                       else
                                                       {
                                                           Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                       }
                                                         */
                            Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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

                        /* hide on 05-11-2024 - Sugg.by Bala sir
                       TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                       MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                       */

                        if (ANTI_DUMPING_NOTN == "015/2023" || ANTI_DUMPING_NOTN == "017/2023" || ANTI_DUMPING_NOTN == "011/2024" || ANTI_DUMPING_NOTN == "006/2025" || ANTI_DUMPING_NOTN == "021/2025" || ANTI_DUMPING_NOTN == "004/2025")// Sugg.By Bala sir on 22-02-2024 for OECL Shipping
                        {
                            TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                            MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        }
                        else
                        {
                            //this calc newly added sugg.by Bala sir done by Chithra on 23/12/2020
                            TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                            MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt)) / 100;
                        }
                        TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                        MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                        TOTAL_ANTI_AMT = MERIT_TOTAL_ANTI_AMT; //added by pandiyan 22/04/25 
                    }


                    ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + TOTAL_ANTI_AMT;
                    // Hided by pandiyan 22/04/2025
                    // ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + "0.00";

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
                    //Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT-- hide on 05-03-2024

                    /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                {
                                                    Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                }
                                                else
                                                {
                                                    Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                }
                                                */
                    Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                    PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));

                }
                else if (PRODUCT_OTHER_DUTY_SPL != "")
                {
                    Other_duty = c_ITEM_QTY * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
                    PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));
                }
                //------------End Calculation implemented on 06Oct2018------------//

                if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
                {
                    //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                    Actual_BASIC_DUTY = BASIC_DUTY;
                }

                Call_IGST_General();



                CHK_IGST_ASSBL_VAL = 0.00;
                if (RSP_APPLICABLE == "S" && (MRP_AMT > IGST_LEV_1_AMT_ASS))
                {
                    CHK_IGST_ASSBL_VAL = MRP_AMT; //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                    tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                }
                else
                {

                    if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                    {
                        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
                    }
                    else
                    {
                        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt + SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT); //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                    }
                    tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                }


                //for SWS - without Health Cess, Basic Duty only add with License debit duty - sugg by Bala sir & Subbu sir on 30-10-2020
                double Customs_SWS_HealthCess = 0.00;
                if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                {
                    if (HEALTH_CESS_CTH_CODE != "")
                    {
                        Customs_SWS_HealthCess = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }
                }

                //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD), 1).ToString("0.00"));
                //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess_a + Customs_Higher_Edu_Cess_a + AddL_DUTY + NCD).ToString("0.00"));//HIDE BY CHITHRA ON 20/12/2017 for add IGST With Debit Duty

                if (SCHEME_CODE == "12")
                {
                    //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess_a + Customs_Higher_Edu_Cess_a + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT)).ToString("0.00"));
                    TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_social_welfare_a + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));

                    /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    {
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Customs_SWS_HealthCess + AIDC_Amt).ToString("0.00"));
                        }
                    }
                }
                else
                {
                    //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess_a + Customs_Higher_Edu_Cess_a + AddL_DUTY + NCD).ToString("0.00"));
                    TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_social_welfare_a + AddL_DUTY + NCD + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));

                    /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    {
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Customs_SWS_HealthCess + AIDC_Amt).ToString("0.00"));
                        }
                    }
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

                    //-------HEALTH CESS CALCULATION
                    HEALTH_CESS_TOTAL = "0.00";
                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    {
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                        }
                    }
                    else
                    {
                        HEALTH_CESS_RATE = "0.00";
                    }

                    //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
                    Get_Less_Sapta_Rate();

                    //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                    AIDC_Amt = NOTN_AIDC_CALC();


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
                            double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
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
                            SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                        }

                        //-----------------------------NCD CALCULATION---------------------------------------//
                        NCD = 0.00;
                        //-----------------------------END NCD CALCULATION---------------------------------------//

                        // CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                        double CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                        double CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT);

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

                        //#SWS
                        if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                        {
                            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                        }
                        else
                        {
                            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                            //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                        }

                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                        AddL_DUTY = 0.00;
                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                        //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                        SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

                        //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                        Actual_BASIC_DUTY = BASIC_DUTY;

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
                        AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));//01-feb-2021

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
                        double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
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


                    //-------HEALTH CESS CALCULATION
                    HEALTH_CESS_TOTAL = "0.00";
                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    {
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                        }
                    }
                    //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
                    Get_Less_Sapta_Rate();

                    //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                    AIDC_Amt = NOTN_AIDC_CALC();

                    //-------SOCIAL WELFARE CALCULATION

                    if (SOCIAL_WELFARE_NOTN != "")
                    {
                        SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }



                    //-----------------------------NCD CALCULATION---------------------------------------//
                    NCD = 0.00;
                    //-----------------------------END NCD CALCULATION---------------------------------------//                              

                    // CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                    double CVD_Rate = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                    double CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT);

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

                    //#SWS
                    if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                    {
                        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }
                    else
                    {
                        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                        //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }


                    ////AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;
                    //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                    AddL_DUTY = 0.00;
                    //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                    //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                    SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

                    //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                    Actual_BASIC_DUTY = BASIC_DUTY;

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
                    AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));//01-feb-2021

                    //TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    private void Scheme_Post_Export_EPCG(DataSet dss1)
    {
        try
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
                Other_duty = 0.00;

                cvd_Customs_Edu_Cess = 0.00;
                cvd_Customs_Higher_Edu_Cess = 0.00;
                Customs_Social_welfare = 0.00;//02feb
                Healthcess_RateVal = 0.00;
                AIDC_Amt = 0.00;
                BCD_FG_AMT = 0.00;
                IGST_FG_AMT = 0.00;
                SWS_FG_AMT = 0.00;

                if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (COMPANY_ID != "2404" && COMPANY_ID != "951"))// Condition Added by pandiyan suggest by bala for sai clearing  
                {
                    TOTAL_ANTI_AMT = TOTAL_ANTI_AMT;
                }
                else
                {
                    TOTAL_ANTI_AMT = "0.00";
                }

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
                    Healthcess_RateVal = 0.00;
                    AIDC_Amt = 0.00;
                }


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
                HEALTH_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Healthcess_RateVal), 1).ToString("0.00"));//02feb
                AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));//01-feb-2021

                //-----------------------CALCULATION FOR TOTAL DEBIT DUTY--------------------------------//

                //double bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;

                double bcd_rate = 0.00;

                //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

                if (PRODUCT_BCD_NOTN != "")
                {
                    if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
                    {
                        CTH_SPL_AMT = "0";
                    }
                }


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
                    double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                    //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                    double cth_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);

                    if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                    {
                        if (cth_Amt <= bcd_rate)
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                        else
                        {
                            //BASIC_DUTY = bcd_Amt;
                            if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                            {
                                BASIC_DUTY = bcd_Amt;
                            }
                            else
                            {
                                BASIC_DUTY = bcd_rate;
                            }
                        }
                    }
                    else if (NOTIFICATION_FLAG == "+")
                    {
                        if (bcd_rate >= bcd_Amt)
                        {
                            BASIC_DUTY = cth_Amt + bcd_rate;
                        }
                        else
                        {
                            BASIC_DUTY = cth_Amt + bcd_Amt;
                        }
                    }
                    else //-- NOTIFICATION_FLAG == "H" or others
                    {
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
                }


                if (PRODUCT_BCD_SPL != "")
                {
                    if (Convert.ToDouble(PRODUCT_BCD_SPL) != 0.000000 || Convert.ToDouble(PRODUCT_BCD_SPL) != 000000)
                    {
                        double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                        double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_BCD_SPL);

                        if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                        {
                            if (bcd_Amt <= bcd_rate)
                            {
                                BASIC_DUTY = bcd_Amt;
                            }
                        }

                        if (COMPANY_ID == "313")
                        {
                            if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                            {
                                BASIC_DUTY = cth_Amt;
                            }
                        }

                        //BASIC_DUTY_BCD_SPL = cth_Amt;
                        //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                        CTH_SPL_AMT = PRODUCT_BCD_SPL;
                        CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
                    }
                }

                //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
                Get_Less_Sapta_Rate();

                //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//
                bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

                //---------------END SAPTA CALCULATION-------------------------//


                //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
                //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
                if (PRODUCT_BCD_NOTN != "")
                {
                    BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
                    BCD_FOREGONE_AMT = Convert.ToString(Math.Round(BCD_FG_AMT, 1).ToString("0.00"));
                }
                else
                {
                    BCD_FG_AMT = BASIC_DUTY;
                    BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
                }
                //--------------------------------------------

                HEALTH_CESS_TOTAL = "0.00";
                if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                {
                    if (HEALTH_CESS_CTH_CODE != "")
                    {
                        Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }
                }


                //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                AIDC_Amt = NOTN_AIDC_CALC();

                if (COMPANY_ID == "614")
                {
                    AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));
                }

                //10-06-2024 for SHAANU LOGISTICS - Sugg.By Bala sir
                if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO != "17" && AIDC_NOTN_SLNO != "18" && AIDC_NOTN_SLNO != "19" && AIDC_NOTN_SLNO != "17A"))
                {
                    AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));
                }

                //#SWS
                if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                {
                    Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }
                else
                {
                    Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                }

                //--------------SWS FOREGONE AMOUNT----By Chithra on 24-11-2025 for Capricorn-----------
                //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
                if (SOCIAL_WELFARE_NOTN != "")
                {
                    SWS_FG_AMT = merit_social_welfare_cess - Customs_Social_welfare;
                    SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Customs_Social_welfare, 1).ToString("0.00"));
                }
                else
                {
                    SWS_FOREGONE_AMT = Convert.ToString(Customs_Social_welfare);
                }
                SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));


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


                CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                //if (RSP_APPLICABLE == "Y")- RSP condition removed by Chithra

                if (CETH_CVD_NIL_YN == "Y")
                {
                    CVD = 0.00;
                    CVD_TOTAL = "0.00";
                    PRODUCT_CVD_RATE = "0.00";
                }

                //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                Actual_BASIC_DUTY = BASIC_DUTY;


                CESS = 0.00;


                Customs_Edu_Cess = 0.00;
                Customs_Higher_Edu_Cess = 0.00;

                //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//

                if (COMPANY_ID == "247" || COMPANY_ID == "10")
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
                        //TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);
                        TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY);

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

                    if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (COMPANY_ID != "2404" && COMPANY_ID != "951"))// Condition Added by pandiyan suggest by bala for sai clearing  
                    {
                        ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + TOTAL_ANTIDUMP_AMT;
                    }
                    else
                    {
                        ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                    }
                }
                //---------Start New Anti-Dumping Calculation implemented on 27Sep2018------------//
                else if (MAX_DIFF != "" && MAX_DIFF != null)
                {
                    if (PRODUCT_OTHER_DUTY_NOTN != "" && PRODUCT_OTHER_DUTY_SLNO != "")
                    {
                        if (PRODUCT_OTHER_DUTY_RATE != "")
                        {
                            ADD_MAX_DIFF = Convert.ToDouble(MAX_DIFF);

                            TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                            TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));

                            //hide on 05-03-2024 Sugg.by Bala Sir
                            //double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                            double Anti_Dump_Cal2 = 0.00;
                            /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                        if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                        {
                            Anti_Dump_Cal2 = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                        }
                        else
                        {
                            Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                        }
                          * */
                            Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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
                        /* hide on 05-11-2024 - Sugg.by Bala sir
                        TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        */

                        if (ANTI_DUMPING_NOTN == "015/2023" || ANTI_DUMPING_NOTN == "017/2023" || ANTI_DUMPING_NOTN == "011/2024" || ANTI_DUMPING_NOTN == "006/2025" || ANTI_DUMPING_NOTN == "021/2025" || ANTI_DUMPING_NOTN == "004/2025")// Sugg.By Bala sir on 22-02-2024 for OECL Shipping
                        {
                            TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                            MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        }
                        else
                        {
                            //this calc newly added sugg.by Bala sir done by Chithra on 23/12/2020
                            TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                            MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt)) / 100;
                        }

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
                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble((ADD_DIFF_CUR)) / 100;

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
                    //Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT-- hide on 05-03-2024
                    /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                               if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                               {
                                                   Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                               }
                                               else
                                               {
                                                   Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                               }
                                                * */

                    Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                    PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));

                }
                else if (PRODUCT_OTHER_DUTY_SPL != "")
                {
                    Other_duty = c_ITEM_QTY * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
                    PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));
                }

                // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//

                TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));

                Call_IGST_General();

                CHK_IGST_ASSBL_VAL = 0.00;
                if (RSP_APPLICABLE == "S" && (MRP_AMT > IGST_LEV_1_AMT_ASS))
                {
                    CHK_IGST_ASSBL_VAL = MRP_AMT; //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                    tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                }
                else
                {
                    if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                    {
                        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
                    }
                    else
                    {
                        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt + SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT);//Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                    }
                    tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
                }

                // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - END 88 **************************************//


                //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                AddL_DUTY = 0.00;

                //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                //for SWS - without Health Cess, Basic Duty only add with License debit duty - sugg by Bala sir & Subbu sir on 30-10-2020
                double Customs_SWS_HealthCess = 0.00;
                if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                {
                    if (HEALTH_CESS_CTH_CODE != "")
                    {
                        Customs_SWS_HealthCess = (BASIC_DUTY) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                    }
                }

                //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));//HIDE BY CHITHRA ON 20/12/2017 for add IGST With Debit Duty

                if (SCHEME_CODE == "12" || SCHEME_CODE == "03" || SCHEME_CODE == "17")
                {
                    //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
                    //02feb
                    //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));

                    if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                    {
                        if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (COMPANY_ID != "2404" && COMPANY_ID != "951"))//Condition Added by pandiyan suggest by bala for sai clearing    
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));
                        }
                        else
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));

                        }
                    }
                    else
                    {
                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(HEALTH_CESS_TOTAL)), 1).ToString("0.00"));
                    }

                    /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    {
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            //10-06-2024
                            // TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));

                            if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                            {
                                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));
                            }
                            else
                            {
                                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess), 1).ToString("0.00"));
                            }
                        }
                    }
                }
                else
                {
                    //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
                    //02feb

                    //10-06-2024
                    //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(HEALTH_CESS_TOTAL) + Customs_SWS_HealthCess + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));

                    if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                    {
                        //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(HEALTH_CESS_TOTAL) + Customs_SWS_HealthCess + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));
                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));

                    }
                    else
                    {
                        //hide on 10-11-20252 
                        //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(HEALTH_CESS_TOTAL) + Customs_SWS_HealthCess), 1).ToString("0.00"));
                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));

                    }

                    /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    {
                        if (HEALTH_CESS_CTH_CODE != "")
                        {
                            //10-06-2024
                            // TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));


                            if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                            {
                                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));
                            }
                            else
                            {
                                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
                            }
                        }
                    }
                }

                PRODUCT_OTHER_DUTY_TOTAL = "0";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    public void Scheme_SAME_CODE_GENERAL_CALC()
    {
        try
        {
            BASIC_DUTY = 0.00;
            SAFE_GUARD = 0.00;
            CVD = 0.00;
            NCD = 0.00;
            Customs_Edu_Cess = 0.00;
            Customs_Higher_Edu_Cess = 0.00;
            AddL_DUTY = 0.00;
            BCD_FG_AMT = 0.00;
            IGST_FG_AMT = 0.00;
            SWS_FG_AMT = 0.00;

            cvd_Customs_Edu_Cess = 0.00;
            cvd_Customs_Higher_Edu_Cess = 0.00;
            Customs_Social_welfare = 0.00;
            Healthcess_RateVal = 0.00;

            //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
            Actual_BASIC_DUTY = BASIC_DUTY;

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


            /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
            //-------HEALTH CESS CALCULATION
            HEALTH_CESS_TOTAL = "0.00";
            if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
            {
                if (HEALTH_CESS_CTH_CODE != "")
                {
                    Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                }
            }

            //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
            Get_Less_Sapta_Rate();

            //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
            AIDC_Amt = NOTN_AIDC_CALC();

            //#SWS
            if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
            {
                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }
            else
            {
                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }

            SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
            BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
            AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
            CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));

            NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
            CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
            CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));
            HEALTH_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Healthcess_RateVal), 1).ToString("0.00"));
            AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));//01-feb-2021

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
                double bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                double cth_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);

                if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                {
                    if (cth_Amt <= bcd_rate)
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                    else
                    {
                        //BASIC_DUTY = bcd_Amt;
                        if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                        else
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                    }
                }
                else if (NOTIFICATION_FLAG == "+")
                {
                    if (bcd_rate >= bcd_Amt)
                    {
                        BASIC_DUTY = cth_Amt + bcd_rate;
                    }
                    else
                    {
                        BASIC_DUTY = cth_Amt + bcd_Amt;
                    }
                }
                else //-- NOTIFICATION_FLAG == "H" or others
                {
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

            }

            //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

            bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

            //---------------END SAPTA CALCULATION-------------------------//

            //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
            //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
            if (PRODUCT_BCD_NOTN != "")
            {
                BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
                BCD_FOREGONE_AMT = Convert.ToString(Math.Round(BCD_FG_AMT, 1).ToString("0.00"));
            }
            else
            {
                BCD_FG_AMT = BASIC_DUTY;
                BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
            }
            //--------------------------------------------


            CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

            //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra

            //cvd_Customs_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_EDU_CESS_RATE) / 100;
            //cvd_Customs_Higher_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_SEC_EDU_CESS_RATE) / 100;


            /*//hide on 23-10-2024 for New Settings
            if (PRODUCT_CETH.Substring(0, 2) != "24")
            {
                CVD = 0.00;
                CVD_TOTAL = "0.00";
                PRODUCT_CVD_RATE = "0.00";
            }
             * */

            if (CETH_CVD_NIL_YN == "Y")
            {
                CVD = 0.00;
                CVD_TOTAL = "0.00";
                PRODUCT_CVD_RATE = "0.00";
            }

            Actual_BASIC_DUTY = BASIC_DUTY;

            Customs_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
            Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;

            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;//02feb

            //--------------SWS FOREGONE AMOUNT----By Chithra on 24-11-2025 for Capricorn-----------
            //based on BCD Notn Forgone amt should changes - refer by Bala sir done by Chithra on 25-11-2025
            if (SOCIAL_WELFARE_NOTN != "")
            {
                SWS_FG_AMT = merit_social_welfare_cess - Customs_Social_welfare;
                SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Customs_Social_welfare, 1).ToString("0.00"));
            }
            else
            {
                SWS_FOREGONE_AMT = Convert.ToString(Customs_Social_welfare);
            }
            SWS_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));


            ADDLTIONAL_DUTY_TOTAL = "0.00";
            AddL_DUTY = 0.00;

            //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//
            if (COMPANY_ID == "247" || COMPANY_ID == "218" || COMPANY_ID == "392" || COMPANY_ID == "10" || COMPANY_ID == "4" || COMPANY_ID == "480" || COMPANY_ID == "508" || COMPANY_ID == "1026")
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



            //------------New Anti-Dumping Calculation implemented on 06Oct2018------------//
            string TOTAL_ANTI_AMT_LICNESE;

            if (ANTI_AMTS != null && ANTI_AMTS != "")
            {
                if (ADD_AMT_MINUS_ASSESABLE == "1")
                {
                    //TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);
                    TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY);

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

                        //hide on 05-03-2024 Sugg.by Bala Sir
                        //double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                        double Anti_Dump_Cal2 = 0.00;
                        /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                      if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                      {
                                                          Anti_Dump_Cal2 = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                      }
                                                      else
                                                      {
                                                          Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                      }
                                                        */
                        Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;

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

                    /* hide on 05-11-2024 - Sugg.by Bala sir
                   TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                   MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                     * */

                    if (ANTI_DUMPING_NOTN == "015/2023" || ANTI_DUMPING_NOTN == "017/2023" || ANTI_DUMPING_NOTN == "011/2024" || ANTI_DUMPING_NOTN == "006/2025" || ANTI_DUMPING_NOTN == "021/2025" || ANTI_DUMPING_NOTN == "004/2025")// Sugg.By Bala sir on 22-02-2024 for OECL Shipping
                    {
                        TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    }
                    else
                    {
                        //this calc newly added sugg.by Bala sir done by Chithra on 23/12/2020
                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt)) / 100;
                    }

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

            if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
            {
                //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
                Actual_BASIC_DUTY = BASIC_DUTY;
            }


            Call_IGST_General();

            CHK_IGST_ASSBL_VAL = 0.00;
            if (RSP_APPLICABLE == "S" && (MRP_AMT > IGST_LEV_1_AMT_ASS))
            {
                CHK_IGST_ASSBL_VAL = MRP_AMT; //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
            }
            else
            {

                if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                {
                    CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
                }
                else
                {
                    CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt + SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT); //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                }
                tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
            }

            //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD), 1).ToString("0.00"));
            //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD).ToString("0.00"));//hide 02feb 2018 by chithra
            TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Social_welfare + AddL_DUTY + NCD + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)).ToString("0.00"));

            //-----------------------------END TOTAL DEBIT DUTY---------------------------------------//

            // -----------------Spl Excise Duty(Sched-11) Calculation-------------------------------//
            // -----------------GSI Calculation-------------------------------//
            // -----------------TTA Calculation-------------------------------//
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void Scheme_14_RestrictedItems()
    {
        try
        {
            double bcd_rate = 0.00;
            double bcd_Amt = 0.00;
            //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

            if (PRODUCT_BCD_NOTN != "")
            {
                if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
                {
                    //NOTIFICATION_CUSTOMS_BCD_RATE = "";


                    //--if "NOTIFICATION_CUSTOMS_BCD_SPL" is "0" "CTH_SPL_AMT" - should be "0" - confirmed with Final Print for Aeroship.. sugg.By Bala Sir on 20-03-2021
                    //if (Session["COMPANY_ID"].ToString() == "145" || Session["COMPANY_ID"].ToString() == "262" || Session["COMPANY_ID"].ToString() == "184" || Session["COMPANY_ID"].ToString() == "223" || Session["COMPANY_ID"].ToString() == "224" || Session["COMPANY_ID"].ToString() == "164" || Session["COMPANY_ID"].ToString() == "856" || Session["COMPANY_ID"].ToString() == "1026" || Session["COMPANY_ID"].ToString() == "1048")
                    //{
                    CTH_SPL_AMT = "0";
                    //}
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
                    if (PRODUCT_BCD_RATE != "")
                    {
                        bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                    }
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
            if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
            {
                BASIC_DUTY = 0.00;
                bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
            }
            else
            {
                if (Convert.ToDouble(PRODUCT_BCD_RATE) == 0.00 || Convert.ToDouble(PRODUCT_BCD_RATE) == 0)
                {
                    BASIC_DUTY = 0.00;
                }
            }

            if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
            {
                //CTH_SPL_AMT = "";
                BASIC_DUTY = bcd_rate;
            }
            else
            {
                //bcd_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);
                // double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT); --hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                double cth_Amt = c_ITEM_QTY * Convert.ToDouble(CTH_SPL_AMT);


                if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                {
                    if (cth_Amt <= bcd_rate)
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                    else
                    {
                        //BASIC_DUTY = bcd_Amt;
                        if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                        else
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                    }
                }
                else if (NOTIFICATION_FLAG == "+")
                {
                    if (bcd_rate >= bcd_Amt)
                    {
                        BASIC_DUTY = cth_Amt + bcd_rate;
                    }
                    else
                    {
                        BASIC_DUTY = cth_Amt + bcd_Amt;
                    }
                }
                else //-- NOTIFICATION_FLAG == "H" or others
                {
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

                /* hide by Chithra on 17-09-2019 discuss with sathish sir - Master Cargo - above value updated nill here..
                //if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                //{
                //    if (bcd_Amt <= bcd_rate)
                //    {
                //        BASIC_DUTY = bcd_Amt;
                //    }
                //}
                 * */
            }

            if (PRODUCT_BCD_SPL != "")
            {
                if (Convert.ToDouble(PRODUCT_BCD_SPL) != 0.000000 || Convert.ToDouble(PRODUCT_BCD_SPL) != 000000)
                {
                    double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                    bcd_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_BCD_SPL);

                    /* hide By chithra for implement H,L,+ - above code BASIC_DUTY value again update here.. on 02/08/2019
                        if (bcd_rate >= cth_Amt)
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                        else
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                     */

                    if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                    {
                        if (bcd_Amt <= bcd_rate)
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                        else
                        {
                            BASIC_DUTY = bcd_rate;
                        }
                    }

                    if (COMPANY_ID == "313")
                    {
                        if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                        {
                            BASIC_DUTY = cth_Amt;
                        }
                    }

                    //BASIC_DUTY_BCD_SPL = cth_Amt;
                    //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                    CTH_SPL_AMT = PRODUCT_BCD_SPL;
                    CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
                }
            }


            //-------HEALTH CESS CALCULATION
            HEALTH_CESS_TOTAL = "0.00";
            Healthcess_RateVal = 0.00;
            if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
            {
                if (HEALTH_CESS_CTH_CODE != "")
                {
                    Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                    HEALTH_CESS_TOTAL = Convert.ToString(Healthcess_RateVal);
                }
            }

            //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
            Get_Less_Sapta_Rate();

            //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
            AIDC_Amt = NOTN_AIDC_CALC();

            //-------SOCIAL WELFARE CALCULATION
            /* -02-02-2021
            if (SOCIAL_WELFARE_NOTN != "")
            {
                SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;--02-02-2021
            }
            */

            //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//
            bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

            //--------------------------------------------------------------------------------------------

            //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
            BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
            BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
            //--------------------------------------------



            //---------------END SAPTA CALCULATION-------------------------//

            //----------------Start 28Apr2015---------------------//
            if (NOTIFICATION_CUSTOMS_BCD_RATE != "")
            {
                /*
                if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
                {
                    BASIC_DUTY = 0.00;
                }
                */

                if (PRODUCT_RITC == "08021100" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "24AA")//--its for Pankaj Goyal eri00555 - asked by pandian
                {
                }
                else
                {
                    if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
                    {
                        BASIC_DUTY = 0.00;
                    }
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
                    CVD_Amt = c_ITEM_QTY * Convert.ToDouble(PRODUCT_CVD_SPL);
                    CETH_SPL_AMT = PRODUCT_CVD_SPL;
                }
            }
            else
            {
                CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT);
            }

            //---------------End Updated on 04 July 2014------------------//


            //double CVD_Amt = c_ITEM_QTY * Convert.ToDouble(CETH_SPL_AMT); //disabled on 04 July 2014

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
                        CESS = c_ITEM_QTY * Convert.ToDouble(CETH_CESS_AMTS);
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

            if (COMPANY_ID == "182")
            {
                //CVD = CVD * 20;
                CVD = CVD + CVD_Amt;
            }

            if (COMPANY_ID == "162" && CVD_NOTN == "012/2012" && PRODUCT_CVD_NOTN_SLNO == "51(ii)")
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

            /*//hide on 23-10-2024 for New Settings
            if (PRODUCT_CETH.Substring(0, 2) != "24")
            {
                CVD = 0.00;
                CVD_TOTAL = "0.00";
                PRODUCT_CVD_RATE = "0.00";
            }
            else if (PRODUCT_CETH == "24029090" || PRODUCT_CETH == "24022090" || PRODUCT_CETH == "24039100" || PRODUCT_CETH == "24011090" || PRODUCT_CETH == "24012090")
            {
                CVD = 0.00;
                CVD_TOTAL = "0.00";
                PRODUCT_CVD_RATE = "0.00";
            }
             * */

            if (CETH_CVD_NIL_YN == "Y")
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
                //Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;//---EDITED BY  CHITHRA 12-sep-2017 ---for PARAMOUNT-- hide on 05-03-2024


                /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                               if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                               {
                                                   Other_duty = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                               }
                                               else
                                               {
                                                   Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                               }
                                               */
                Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;

                PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));

            }
            else if (PRODUCT_OTHER_DUTY_SPL != "")
            {
                Other_duty = c_ITEM_QTY * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
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

            //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

            AddL_DUTY = 0.00;

            SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;

            //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
            Actual_BASIC_DUTY = BASIC_DUTY;

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
                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                Aggregate_SWS = Customs_Social_welfare;

                double AGGREGATE_DUTY_a = (Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess + Aggregate_SWS);
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
                Aggregate_SWS = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;//SWS

                //AGGREGATE_DUTY = Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess;

                AGGREGATE_DUTY = AGGREGATE_DUTY_a - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd + Aggregate_Customs_Edu_Cess + Aggregate_Customs_Higher_Edu_Cess + Aggregate_SWS);
                //AGGREGATE_DUTY = AGGREGATE_DUTY_a - (Aggregate_safe_guard + Aggregate_AddL_DUTY + Aggregate_basic_duty + Aggregate_cvd + Aggregate_cess + Aggregate_ncd);

                /*hide on 24-01-2025 by Chithra Sugg.by Bala sir & Nabil - for ARYA OFFSHORE
                //----- New Impelmentation for RYAL Logistics suggest by Bala sir.. on 27-02-2020
                double aggregate1 = AGGREGATE_DUTY * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                AGGREGATE_DUTY = AGGREGATE_DUTY + aggregate1;
                 * */
            }

            CVD_CEC_TOTAL = "0.00";
            CVD_CHEC_TOTAL = "0.00";

            //#SWS
            /* condition for 7106 & 7108 chapter AIDC amt should not calculate - hide by Chithra on 17-06-2023 sugg.by Bala sir
            if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
            { 
                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }
            else
            {
                Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }
             * */

            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;


            SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 2).ToString("0.00"));

            if (COMPANY_ID == "248")
            {
                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 2).ToString("0.00"));
            }
            else
            {
                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
            }

            AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
            SAPTA_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAPTA_DUTY), 1).ToString("0.00"));
            CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CESS), 1).ToString("0.00"));
            NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
            CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
            CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));
            AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));


            //newly added on 28-10-2020
            HEALTH_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Healthcess_RateVal), 1).ToString("0.00"));

            ADDLTIONAL_DUTY_TOTAL = "0.00";
            INFRA_CESS_TOTAL = "0.00";

            //ITEM_PRODUCT_DETAILS_ADDITIONAL
            CHECKLIST_SAFEGUARD_DUTY_AMT = SAFE_GUARD_TOTAL;
            CHECKLIST_NCD_DUTY_AMT = NCD_TOTAL;
            CHECKLIST_AGGREGATE_DUTY_AMT = AGGREGATE_TOTAL;
            CHECKLIST_SAPTA_DUTY_AMT = SAPTA_TOTAL;
            CHECKLIST_GSI_DUTY_AMT = "0.00";
            CHECKLIST_TTA_DUTY_AMT = "0.00";
            CHECKLIST_SCHED11_DUTY_AMT = "0.00";
            CHECKLIST_OTHER_DUTY_AMT = PRODUCT_OTHER_DUTY_TOTAL;
            CHECKLIST_INFRACESS_DUTY_AMT = INFRA_CESS_TOTAL;


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

                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                        TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));

                        //hide on 05-03-2024 Sugg.by Bala Sir
                        //double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                        double Anti_Dump_Cal2 = 0.00;
                        /* ----Edited by Sathish on 14May2025 with Bala (Fast Track Logistics)----------/
                                                      if (PRODUCT_OTHER_DUTY_NOTN == "003/2021")
                                                      {
                                                          Anti_Dump_Cal2 = (ASSESABLE_VALUE) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                      }
                                                      else
                                                      {
                                                          Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                      }
                                                        */
                        Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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

                    //this line hide by Chithra on 23/12/2020 sugg.By Bala sir - issue for ABM Logistics Services
                    //TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    //MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;

                    if (ANTI_DUMPING_NOTN == "015/2023" || ANTI_DUMPING_NOTN == "017/2023" || ANTI_DUMPING_NOTN == "011/2024" || ANTI_DUMPING_NOTN == "006/2025" || ANTI_DUMPING_NOTN == "021/2025" || ANTI_DUMPING_NOTN == "004/2025")// Sugg.By Bala sir on 22-02-2024 for OECL Shipping
                    {
                        TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * ASSESABLE_VALUE) / 100;
                    }
                    else
                    {
                        //this calc newly added sugg.by Bala sir done by Chithra on 23/12/2020
                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                        MERIT_TOTAL_ANTIDUMP_AMT = (ADD_MAX_DIFF * (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt)) / 100;
                    }


                    TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }


                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "           " + ADD_MAX_DIFF + "%" + "     " + TOTAL_ANTI_AMT;

            }
            else if (ADD_DIFF_CUR != null && ADD_DIFF_CUR != "")
            {
                if (ADD_AMT_MINUS_ASSESABLE == "2")
                {
                    TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble((ADD_DIFF_CUR)) / 100;

                    if (TOTAL_ANTIDUMP_AMT <= 0)
                    {
                        TOTAL_ANTIDUMP_AMT = 0.00;
                    }
                    //TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }

                //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "         " + "        " + ADD_DIFF_CUR + "%" + "  " + TOTAL_ANTIDUMP_AMT;

            }
            //---------End New Anti-Dumping Calculation implemented on 27Sep2018------------//




            // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
            Call_IGST_General();

            CHK_IGST_ASSBL_VAL = 0.00;
            if (RSP_APPLICABLE == "S" && (MRP_AMT > IGST_LEV_1_AMT_ASS))
            {
                CHK_IGST_ASSBL_VAL = MRP_AMT; //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
            }
            else
            {
                if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                {
                    CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
                }
                else
                {
                    CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt + SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT); //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
                }
                tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
            }

            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(HEALTH_CESS_TOTAL) + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));

            /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
            //if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
            //{
            //    if (HEALTH_CESS_CTH_CODE != "")
            //    {
            //        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));
            //    }
            //}
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private double Get_Less_Sapta_Rate()
    {
        try
        {
            if (PRODUCT_SAPTA_NOTN != "" && PRODUCT_SAPTA_SLNO != "")
            {
                if (PRODUCT_SAPTA_RATE != "")
                {
                    if (Convert.ToDecimal(PRODUCT_SAPTA_RATE) >= 0)
                    {
                        /* hide on 06-12-2024 by Chithra Sugg.By Bala sir*/
                        //double bcd_sapta_rate = 100 - Convert.ToDouble(PRODUCT_SAPTA_RATE);
                        bcd_sapta_rate_Less_Value = 100 - Convert.ToDouble(PRODUCT_SAPTA_RATE);
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

                        bcd_sapta_rate_Less_Value = 100 - Convert.ToDouble(PRODUCT_SAPTA_RATE);
                    }
                }
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return bcd_sapta_rate_Less_Value;
    }


    private double NOTN_SAPTA_CALC(double bcd_rate)
    {
        try
        {
            if (PRODUCT_SAPTA_NOTN != "" && PRODUCT_SAPTA_SLNO != "")
            {
                bcd_rate = (BASIC_DUTY * bcd_sapta_rate_Less_Value) / 100;
                BASIC_DUTY = bcd_rate;

                SAPTA_DUTY = bcd_rate;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return bcd_rate;
    }

    private double NOTN_AIDC_CALC()
    {
        try
        {
            AIDC_Amt = 0.00;
            if (AIDC_NOTN != "")
            {
                if (Convert.ToDecimal(AIDC_RATE) >= 0)
                {
                    /* hide on 06-12-2024 by Chithra Sugg.By Bala sir
                    //AIDC_Amt = (BASIC_DUTY) * Convert.ToDouble(AIDC_RATE) / 100;
                    AIDC_Amt = (ASSESABLE_VALUE) * Convert.ToDouble(AIDC_RATE) / 100;

                    //below condition implmentd on 12-02-2021 by Chithra Sugg.by Bala sir
                    if ((PRODUCT_SAPTA_NOTN == "096/2008" && (PRODUCT_SAPTA_SLNO == "(i)" || PRODUCT_SAPTA_SLNO == "(ii)")) || PRODUCT_SAPTA_NOTN == "057/2009" || PRODUCT_SAPTA_NOTN == "101/2007" || PRODUCT_SAPTA_NOTN == "050/2018")//hide on 11-09-2023
                    //if (PRODUCT_SAPTA_NOTN == "057/2009" || PRODUCT_SAPTA_NOTN == "101/2007" || PRODUCT_SAPTA_NOTN == "050/2018")
                    {
                        AIDC_Amt = 0.00;
                    }

                    //below condition implmentd on 11-09-2023 by Chithra Sugg.by Bala sir
                    if ((PRODUCT_SAPTA_NOTN == "096/2008" && PRODUCT_SAPTA_SLNO == "84a"))
                    {
                        AIDC_Split_Rate = Convert.ToDouble(AIDC_RATE) / 2;
                        AIDC_Split_Amt = ASSESABLE_VALUE * Convert.ToDouble(AIDC_Split_Rate) / 100;
                        AIDC_Amt = AIDC_Split_Amt;
                    }
                     * */

                    if (PRODUCT_SAPTA_NOTN != "" && PRODUCT_SAPTA_SLNO != "")
                    {
                        double Aidc_Sapta_Rate = 0.00;
                        if (bcd_sapta_rate_Less_Value > 0)
                        {
                            Aidc_Sapta_Rate = 100 / bcd_sapta_rate_Less_Value;

                            AIDC_Split_Rate = Convert.ToDouble(AIDC_RATE) / Aidc_Sapta_Rate;

                            AIDC_Amt = (ASSESABLE_VALUE) * Convert.ToDouble(AIDC_Split_Rate) / 100;
                        }
                        else
                        {
                            AIDC_Amt = (ASSESABLE_VALUE) * Convert.ToDouble(AIDC_RATE) / 100;
                        }
                    }
                    else
                    {
                        AIDC_Amt = (ASSESABLE_VALUE) * Convert.ToDouble(AIDC_RATE) / 100;
                    }
                }
                else
                {
                    //error table here - Need to Implement
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return AIDC_Amt;
    }

    private void Notn_ANTI_DUMPING_CALC(DataTable dt_error)
    {
        try
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
                        ADD_AMTS_RPT = ANTI_AMTS;
                    }
                    else if (MAX_DIFF != "")
                    {
                        ADD_AMTS_RPT = MAX_DIFF;
                    }
                    else
                    {
                        ADD_AMTS_RPT = "";
                    }

                    if (ANTI_AMTS != "")
                    {
                        ADD_ANTI_AMTS = Convert.ToDouble(ANTI_AMTS);
                        ADD_ANTI_CUR = dt_ANTI_DUMPING.Rows[0]["ADD_ANTI_CUR"].ToString();
                        //EXCHANGE_RATE = Convert.ToDouble(dt_ANTI_DUMPING.Rows[0]["EXCHANGE_RATE"].ToString());// hide on 14-12-2022 by Chithra for Pacific Maritime - if ADD_EXRATE is availed, should be take first

                        //TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);

                        //--- Start Hided  on 29Sep2021 by Sathish and Chithra with Bala
                        /*
                        if (Session["COMPANY_ID"].ToString() == "125" || Session["COMPANY_ID"].ToString() == "146" || Session["COMPANY_ID"].ToString() == "381" || Session["COMPANY_ID"].ToString() == "382" || Session["COMPANY_ID"].ToString() == "385" || Session["COMPANY_ID"].ToString() == "461" || Session["COMPANY_ID"].ToString() == "458" || Session["COMPANY_ID"].ToString() == "520" || Session["COMPANY_ID"].ToString() == "665" || Session["COMPANY_ID"].ToString() == "1068" || Session["COMPANY_ID"].ToString() == "1158")
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
                        else if(Session["COMPANY_ID"].ToString() == "539")
                        {
                            if (BE_TYPE == "Warehouse" || BE_TYPE == "Ex-Bond")
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
                         * */
                        //--- End Hided  on 29Sep2021 by Sathish and Chithra with Bala



                        //--- Start Hided  on 08Dec2021 by Sathish and Chithra with Bala
                        /*
                        if (BE_TYPE == "Warehouse" || BE_TYPE == "Ex-Bond")
                        {
                            TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(INVOICE_EXRATE);
                        }
                        else
                        {
                            TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);
                        }
                        */


                        //TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(INVOICE_EXRATE);-- hide on 20-12-2021 by Chithra sugg by Bala sir for Sun Global

                        /* hide on 22-12-2021 by Chithra sugg.by Bala sir
                       if (ADD_ANTI_CUR == INVOICE_CURRENCY)
                       {
                           TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(INVOICE_EXRATE);
                       }
                       else
                       {
                           TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);
                       }
                         * */

                        if (ADD_EX_RATE != "" && ADD_EX_RATE != null)
                        {
                            TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(ADD_EX_RATE);
                            MERIT_TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(ADD_EX_RATE);
                        }
                        else
                        {
                            EXCHANGE_RATE = Convert.ToDouble(dt_ANTI_DUMPING.Rows[0]["EXCHANGE_RATE"].ToString());//placed from above
                            TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);
                            MERIT_TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);
                        }


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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

  
    private void ITEM_REIMPORT(DataView Re_view)
    {
        try
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
                string BCD_FRM_REIMP = Return_Zero_Value(Re_dss.Tables[0].Rows[bb]["CUSTOMS_DUTY"].ToString());
                //if (NOTN_NO == "094/96" && NOTN_SLNO == "1" || NOTN_SLNO == "3")
                // if (NOTN_NO == "094/96" && NOTN_SLNO == "1" || NOTN_SLNO == "1(a)" || NOTN_SLNO == "1(b)" || NOTN_SLNO == "1(c)" || NOTN_SLNO == "1(d)" || NOTN_SLNO == "1(e)" || NOTN_SLNO == "3" || NOTN_SLNO == "1A")
                if (NOTN_NO == "094/96" && (NOTN_SLNO == "1" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1(B)" || NOTN_SLNO == "1(C)" || NOTN_SLNO == "1(D)" || NOTN_SLNO == "1(E)" || NOTN_SLNO == "3" || NOTN_SLNO == "1A" || NOTN_SLNO == "1D")) //------Implemented On 11Aug2016 for Bas Shipping with Bala
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

                else if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A")) // Condition added by pandiyan 24/04/2025 for reimport custom duty value shown and adding cus duty in checklist   
                {
                    TOTAL_ANTI_AMT = "0.00";
                    BASIC_DUTY_TOTAL = BCD_FRM_REIMP;
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
                    double basic = Convert.ToDouble(BCD_FRM_REIMP);
                    double rate = Convert.ToDouble(SOCIAL_WELFARE_RATE);
                    double result = (basic * rate) / 100;
                    TOTAL_SOCIAL_WELFARE = result.ToString("F2");
                }
                else if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1(B)" || NOTN_SLNO == "1C" || NOTN_SLNO == "1(E)" || NOTN_SLNO == "1(D)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1F" || NOTN_SLNO == "1G"
                   || NOTN_SLNO == "3")) //------Implemented On 12Oct2017 for Paramount with Bala           
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
                else if (NOTN_NO == "045/2017" && (NOTN_SLNO == "5" || NOTN_SLNO == "1(C)" || NOTN_SLNO == "1E" || NOTN_SLNO == "1B"))
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
                else if (NOTN_NO == "046/2017" && (NOTN_SLNO == "5" || NOTN_SLNO == "1A" || NOTN_SLNO == "1D"))
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
                else if (NOTN_NO == "046/2017" && NOTN_SLNO == "1B")
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
                else if (NOTN_NO == "047/2017" && (NOTN_SLNO == "1" || NOTN_SLNO == "2"))
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
                else if (NOTN_NO == "043/96" && NOTN_SLNO == "1")
                {
                    //ALl duty should be come -sugg. by bala sir on 24-12-2020
                }

                //REIMPORT_FREIGHT_AMOUNT = REIMPORT_FREIGHT_AMOUNT + Convert.ToDouble(REIMPORT_FREIGHT);
                //REIMPORT_INSURANCE_AMOUNT = REIMPORT_INSURANCE_AMOUNT + Convert.ToDouble(REIMPORT_INSURANCE);
                //b++;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Call_IGST_Forgone_Amt()
    {
        try
        {
            IGST_LEV_1_AMT_ASS_1 = 0.00;
            IGST_LEV_1_AMT_1 = 0.00;

            if (IGST_LEVY_EXCEPTION_NOTN != "")
            {
                //--------------------Start RSP Calculation on 11Sep2018-------------------------//
                if (RSP_APPLICABLE == "S")
                {

                    IGST_LEV_1_AMT_ASS_1 = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + AIDC_Amt + Healthcess_RateVal);

                    if (MRP_AMT > IGST_LEV_1_AMT_ASS_1)
                    {
                        IGST_LEV_1_AMT_1 = (Convert.ToDouble(MRP_AMT)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }
                    else
                    {
                        IGST_LEV_1_AMT_1 = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }
                }
                else
                {
                    if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                    {
                        IGST_LEV_1_AMT_1 = ASSESABLE_VALUE * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }
                    else
                    {
                        IGST_LEV_1_AMT_1 = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt + Convert.ToDouble(CVD_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }
                }
                //--------------------End RSP Calculation on 11Sep2018-------------------------//


                IGST_FG_AMT = Math.Round(IGST_LEV_1_AMT_1, 1);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    public void Call_IGST_General() // ********* GST IMPLEMENTATION ON 30 JUN 2017  - START ****************//
    {
        try
        {
            string IGST_LEVY_EXCEPTION_RATE_cal = "";

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

                        //IGST_LEV_1_AMT_ASS = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt);
                        IGST_LEV_1_AMT_ASS = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt);

                        if (MRP_AMT > IGST_LEV_1_AMT_ASS)
                        {
                            IGST_LEV_1_AMT = (Convert.ToDouble(MRP_AMT)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                        }
                        else
                        {
                            // IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                            IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                        }

                    }
                    else
                    {
                        if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
                        {
                            IGST_LEV_1_AMT = ASSESABLE_VALUE * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                        }
                        else
                        {
                            // IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                            //hide on 11-02-2025 for FASTRACK - Sugg.By Bala sir - CVD Amount should add with IGST - checked with Final copy
                            //IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                            IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt + Convert.ToDouble(CVD_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                        }
                    }
                    //--------------------End RSP Calculation on 11Sep2018-------------------------//


                    //IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;

                    IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_AMT), 1).ToString("0.00"));
                }
                else
                {
                    //if (IGST_LEVY_EXCEPTION_NOTN != "" && IGST_LEVY_EXCEPTION_SLNO != "")
                    if (IGST_LEVY_EXCEPTION_NOTN != "")
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
                        DataTable dt_IGST_SPL = new DataTable();


                        if (dv_IGST_RATE.Count > 0)
                        {
                            dt_IGST_SPL = IGST_RATES.CopyToDataTable();
                            igst_NOTIFICATION_EXCISE_BCD_SPL = Convert.ToDouble(dt_IGST_SPL.Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString() == string.Empty ? 0.00 : Convert.ToDouble(dt_IGST_SPL.Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString()));
                        }

                        if (dt_IGST_SPL.Rows.Count > 0)
                        {
                            if (IGST_LEVY_EXCEPTION_RATE == "" || IGST_LEVY_EXCEPTION_RATE == null)
                            {
                                IGST_LEVY_EXCEPTION_RATE_cal = dt_IGST_SPL.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                            }
                            else
                            {
                                IGST_LEVY_EXCEPTION_RATE_cal = IGST_LEVY_EXCEPTION_RATE;
                            }
                        }

                        if (igst_NOTIFICATION_EXCISE_BCD_SPL > 0)
                        {
                            IGST_LEV_2_Excemption = (c_ITEM_QTY * Convert.ToDouble(igst_NOTIFICATION_EXCISE_BCD_SPL)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;
                            IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                        }
                        else
                        {
                            if (LEVY_EXCEMPTION_NOTN_TYPE == "G" || LEVY_EXCEMPTION_NOTN_TYPE == "")
                            {

                                if (dt_IGST_SPL.Rows[0]["NOTIFICATION_TYPE"].ToString() == "1C")
                                {
                                    // IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                    IGST_LEV_2_Excemption = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                    IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));

                                }
                                else
                                {
                                    // IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE_cal) / 100;
                                    IGST_LEV_2_Excemption = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE_cal) / 100;
                                    IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                                }
                            }
                            else
                            {
                                if (dt_IGST_SPL.Rows[0]["NOTIFICATION_TYPE"].ToString() == "1C")
                                {
                                    //IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE_cal) / 100;
                                    IGST_LEV_2_Excemption = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE_cal) / 100;
                                    IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                                }
                                else
                                {
                                    //IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                    IGST_LEV_2_Excemption = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                    IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                                }
                            }
                        }
                        // END -  NEWLY IMPLEMENTED BY CHITHRA  ON 03-02-2019 - FOR IGST EXCEMPTION SPL AMT CALC FOR BOXCO SUGGEST BY BALA SIR..



                        /* 
                    if (SCHEME_CODE == "12" || SCHEME_CODE == "03" || SCHEME_CODE == "17") // Condition Splited as per lotus & capricorn  on 18-06-2025
                    {
                        if (LEVY_EXCEMPTION_NOTN_TYPE == "C")
                        {
                            //Hide on 22-04-2025 by Pandiyan
                            // IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                            IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                            IGST_LEVY_TOTAL_DEBIT = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_AMT), 1).ToString("0.00"));
                        }
                        else
                        {
                            IGST_LEVY_TOTAL_DEBIT = "0.00";
                        }
                    }
                    */

                        if (SCHEME_CODE == "12" || SCHEME_CODE == "17" || SCHEME_CODE == "21" || SCHEME_CODE == "20") // sugg by bala Condition Splited as per lotus & capricorn  on 18-06-2025 for while coming add ntn gst duty shuld add with add value.
                        {
                            if (LEVY_EXCEMPTION_NOTN_TYPE == "C")
                            {
                                IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                //IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                IGST_LEVY_TOTAL_DEBIT = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_AMT), 1).ToString("0.00"));
                            }
                            else
                            {
                                IGST_LEVY_TOTAL_DEBIT = "0.00";
                            }
                        }

                        else if (SCHEME_CODE == "03")
                        {
                            if (LEVY_EXCEMPTION_NOTN_TYPE == "C")
                            {
                                //IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                IGST_LEVY_TOTAL_DEBIT = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_AMT), 1).ToString("0.00"));
                            }
                            else
                            {
                                IGST_LEVY_TOTAL_DEBIT = "0.00";
                            }
                        }

                        //IGST FORGONE AMOUNT - Done by Chithra on 27-11-2025 - Sugg.by Bala sir
                        Call_IGST_Forgone_Amt();
                    }
                }

                //******************* COMPENSATION CALCULATION ************************

                if (IGST_LEVY_EXCEPTION_CC_NOTN == "" && IGST_LEVY_EXCEPTION_CC_SLNO == "")
                {
                    if (IGST_LEVY_COMPENSATION_CESS_RATE != "")
                    {
                        //IGST_LEV_1_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Edu_Cess) + Convert.ToDouble(Customs_Higher_Edu_Cess) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                        // IGST_LEV_1_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                        IGST_LEV_1_COMPENSATION_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                        IGST_LEVY_COMPENSATION_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_COMPENSATION_AMT), 1).ToString("0.00"));
                    }
                }
                else
                {
                    if (IGST_LEVY_EXCEPTION_CC_NOTN != "" && IGST_LEVY_EXCEPTION_CC_SLNO != "")
                    {
                        //IGST_LEV_2_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Edu_Cess) + Convert.ToDouble(Customs_Higher_Edu_Cess) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE) / 100;
                        // IGST_LEV_2_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE) / 100;
                        IGST_LEV_2_COMPENSATION_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE) / 100;
                        IGST_LEVY_COMPENSATION_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_COMPENSATION_AMT), 1).ToString("0.00"));
                    }
                }


                if (IGST_LEVY_COMPENSATION_CESS_NOTN != "" && IGST_LEVY_COMPENSATION_CESS_SLNO != "")
                {
                    if ((Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL) != 0.00) || (Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL) > 0.00))
                    {
                        if (Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL) != 0.00)
                        {
                            if (IGST_LEVY_EXCEPTION_CC_NOTN == "052/2003")// Conditon added by pandiyan on 02-06-2025 sugg by bala & subhash
                            {
                                IGST_LEV_2_COMPENSATION_AMT1 = 0.00;
                                IGST_LEVY_COMPENSATION_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_COMPENSATION_AMT1), 1).ToString("0.00"));
                            }
                            else
                            {
                                IGST_LEV_2_COMPENSATION_AMT1 = c_ITEM_QTY * Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL);

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
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Call_IGST_General_CIGARETTE()
    {
        try
        {

            string IGST_LEVY_EXCEPTION_RATE_cal = "";

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
                        IGST_LEV_1_AMT_ASS = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt);

                        if (MRP_AMT > IGST_LEV_1_AMT_ASS)
                        {
                            IGST_LEV_1_AMT = (Convert.ToDouble(MRP_AMT)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                        }
                        else
                        {
                            IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                        }

                    }
                    else
                    {
                        IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD) + Convert.ToDouble(CETH_SIA_I_amt) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(AIDC_EXEC_AMT)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }
                    //--------------------End RSP Calculation on 11Sep2018-------------------------//


                    //IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;

                    IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_AMT), 1).ToString("0.00"));
                }
                else
                {
                    //if (IGST_LEVY_EXCEPTION_NOTN != "" && IGST_LEVY_EXCEPTION_SLNO != "")
                    if (IGST_LEVY_EXCEPTION_NOTN != "")
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
                        DataTable dt_IGST_SPL = new DataTable();


                        if (dv_IGST_RATE.Count > 0)
                        {
                            dt_IGST_SPL = IGST_RATES.CopyToDataTable();
                            igst_NOTIFICATION_EXCISE_BCD_SPL = Convert.ToDouble(dt_IGST_SPL.Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString() == string.Empty ? 0.00 : Convert.ToDouble(dt_IGST_SPL.Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString()));
                        }

                        if (dt_IGST_SPL.Rows.Count > 0)
                        {
                            if (IGST_LEVY_EXCEPTION_RATE == "" || IGST_LEVY_EXCEPTION_RATE == null)
                            {
                                IGST_LEVY_EXCEPTION_RATE_cal = dt_IGST_SPL.Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                            }
                            else
                            {
                                IGST_LEVY_EXCEPTION_RATE_cal = IGST_LEVY_EXCEPTION_RATE;
                            }
                        }

                        if (igst_NOTIFICATION_EXCISE_BCD_SPL > 0)
                        {
                            IGST_LEV_2_Excemption = (c_ITEM_QTY * Convert.ToDouble(igst_NOTIFICATION_EXCISE_BCD_SPL)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;
                            IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                        }
                        else
                        {
                            if (LEVY_EXCEMPTION_NOTN_TYPE == "G")
                            {

                                if (dt_IGST_SPL.Rows[0]["NOTIFICATION_TYPE"].ToString() == "1C")
                                {
                                    IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                    IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));

                                }
                                else
                                {
                                    IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE_cal) / 100;
                                    IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                                }
                            }
                            else
                            {
                                if (dt_IGST_SPL.Rows[0]["NOTIFICATION_TYPE"].ToString() == "1C")
                                {
                                    IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE_cal) / 100;
                                    IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                                }
                                else
                                {
                                    IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                    IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                                }
                            }
                        }
                        // END -  NEWLY IMPLEMENTED BY CHITHRA  ON 03-02-2019 - FOR IGST EXCEMPTION SPL AMT CALC FOR BOXCO SUGGEST BY BALA SIR..



                        if (SCHEME_CODE == "12" || SCHEME_CODE == "03" || SCHEME_CODE == "17")
                        {
                            if (LEVY_EXCEMPTION_NOTN_TYPE == "C")
                            {
                                IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                IGST_LEVY_TOTAL_DEBIT = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_AMT), 1).ToString("0.00"));
                            }
                            else
                            {
                                IGST_LEVY_TOTAL_DEBIT = "0.00";
                            }
                        }
                    }
                }

                //******************* COMPENSATION CALCULATION ************************

                if (IGST_LEVY_EXCEPTION_CC_NOTN == "" && IGST_LEVY_EXCEPTION_CC_SLNO == "")
                {
                    if (IGST_LEVY_COMPENSATION_CESS_RATE != "")
                    {
                        double ceth_splamt = 0.00;
                        double CVD_Amt = 0.00;


                        // START -  NEWLY IMPLEMENTED BY CHITHRA  ON 21-10-2019 - FOR IGST COMPENSATION CESS EXCEMPTION SPL AMT CALC FOR FAIRMACS..

                        var IGST_RATES = from DataRow drr in dt_All_Rates.Tables[5].AsEnumerable()
                                         where drr.Field<string>("NOTIFICATION_EXCISE_NOTN") == IGST_LEVY_COMPENSATION_CESS_NOTN && drr.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == IGST_LEVY_COMPENSATION_CESS_SLNO //&& drr.Field<string>("NOTIFICATION_TYPE") == "C"
                                         select drr;

                        DataView dv_IGST_RATE = IGST_RATES.AsDataView();


                        double igst_NOTIFICATION_EXCISE_BCD_SPL = 0.00;
                        DataTable dt_IGST_SPL = new DataTable();

                        IGST_NOTIFICATION_FLAG = "";
                        if (dv_IGST_RATE.Count > 0)
                        {
                            dt_IGST_SPL = IGST_RATES.CopyToDataTable();
                            igst_NOTIFICATION_EXCISE_BCD_SPL = Convert.ToDouble(dt_IGST_SPL.Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString() == string.Empty ? 0.00 : Convert.ToDouble(dt_IGST_SPL.Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString()));
                            IGST_NOTIFICATION_FLAG = dt_IGST_SPL.Rows[0]["NOTIFICATION_FLAG"].ToString();
                        }

                        if ((Convert.ToDecimal(igst_NOTIFICATION_EXCISE_BCD_SPL) > 0))
                        {
                            ceth_splamt = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD) + Convert.ToDouble(CETH_SIA_I_amt) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(AIDC_EXEC_AMT)) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                            CVD_Amt = c_ITEM_QTY * Convert.ToDouble(igst_NOTIFICATION_EXCISE_BCD_SPL);

                            if (IGST_NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                            {
                                if (CVD_Amt <= ceth_splamt)
                                {
                                    CVD_SPL_AMT = CVD_Amt;
                                }
                                else
                                {
                                    CVD_SPL_AMT = ceth_splamt;
                                }
                            }
                            else if (IGST_NOTIFICATION_FLAG == "+")
                            {
                                if (ceth_splamt >= CVD_Amt)
                                {
                                    CVD_SPL_AMT = CVD_Amt + ceth_splamt;
                                }
                                else
                                {
                                    CVD_SPL_AMT = CVD_Amt + ceth_splamt;
                                }
                            }
                            else if (IGST_NOTIFICATION_FLAG == "H")
                            {
                                if (ceth_splamt >= CVD_Amt)
                                {
                                    if (CVD_Amt >= ceth_splamt)
                                    {
                                        CVD_SPL_AMT = CVD_Amt;
                                    }
                                    else
                                    {
                                        CVD_SPL_AMT = ceth_splamt;
                                    }
                                }
                                else
                                {
                                    if (ceth_splamt >= CVD_Amt)
                                    {
                                        CVD_SPL_AMT = ceth_splamt;
                                    }
                                    else
                                    {
                                        CVD_SPL_AMT = CVD_Amt;
                                    }
                                }
                            }
                            else
                            {
                            }
                            //IGST_LEV_1_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Edu_Cess) + Convert.ToDouble(Customs_Higher_Edu_Cess) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                            //IGST_LEV_1_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD) + Convert.ToDouble(CETH_SIA_I_amt) + Convert.ToDouble(CVD_SPL_AMT) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                            IGST_LEV_1_COMPENSATION_AMT = (Convert.ToDouble(ceth_splamt) + Convert.ToDouble(CVD_Amt));

                        }
                        else
                        {
                            NOTIFICATION_EXCISE_BCD_SPL = "0.00";
                            IGST_LEV_1_COMPENSATION_AMT = 0.00;
                        }

                        IGST_LEVY_COMPENSATION_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_COMPENSATION_AMT), 1).ToString("0.00"));
                    }
                }
                else
                {
                    if (IGST_LEVY_EXCEPTION_CC_NOTN != "" && IGST_LEVY_EXCEPTION_CC_SLNO != "")
                    {
                        //IGST_LEV_2_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Edu_Cess) + Convert.ToDouble(Customs_Higher_Edu_Cess) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE) / 100;
                        IGST_LEV_2_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD) + Convert.ToDouble(CETH_SIA_I_amt) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE) / 100;
                        IGST_LEVY_COMPENSATION_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_COMPENSATION_AMT), 1).ToString("0.00"));
                    }
                }


                if (IGST_LEVY_COMPENSATION_CESS_NOTN != "" && IGST_LEVY_COMPENSATION_CESS_SLNO != "")
                {
                    if ((Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL) != 0.00) || (Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL) > 0.00))
                    {
                        if (Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL) != 0.00)
                        {
                            IGST_LEV_2_COMPENSATION_AMT1 = c_ITEM_QTY * Convert.ToDouble(NOTIFICATION_EXCISE_BCD_SPL);

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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public double Get_Indivitual_Assesable_Value(DataTable dt_ReImport, int INV_SLNO, string INV_NO, string ITEM_SLNO, double TOTAL_ITEM_INVOICE_VALUE)
    {
        try
        {
            double freight_amt_air = 0.00;
            INDIVITUAL_SVB_AMOUNT = 0;
            INSURANCE_AMOUNT = 0;
            FREIGHT_AMOUNT = 0;
            MISC_AMOUNT = 0;
            LOADING_AMOUNT = 0.00;

            INDIVITUAL_INSURANCE_AMOUNT = 0;
            INDIVITUAL_FREIGHT_AMOUNT = 0;
            INDIVITUAL_MISC_AMOUNT = 0;
            INDIVITUAL_HSS_AMOUNT = 0;
            INDIVITUAL_DISCOUNT_AMOUNT = 0;
            DISCOUNT_AMOUNT = 0;
            INDIVITUAL_LOADING_AMOUNT = 0;
            ITEM_INDIVITUAL_SVB_AMOUNT = 0;

            double INV_MISC_CHARGES_CONVERT_INV = 0;
            double INV_MISC_CHARGES_CONVERT_fc = 0;
            double final_INV_MISC_CHARGES = 0.00;


            //Get ITEM_TOTAL_AMOUNT for Split Individual FRT,INS Instead of INVOICE_VALUE - for FOC Items -- Implemented for Common - Sugg.by Bala sir on 14-03-2025
            /*
            if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "2787" || COMPANY_ID == "2907")
            {
                INVOICE_VALUE_INR = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(INVOICE_EXRATE);
            }
            else
            {
                INVOICE_VALUE_INR = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);
            }
             * */

            //Newly Implemnted for 19-03-2025 - Sugg.by Bala sir
            if (BE_TYPE == "Ex-Bond")
            {
                INVOICE_VALUE_INR = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);
            }
            else
            {
                INVOICE_VALUE_INR = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(INVOICE_EXRATE);
            }

            if (INV_MISC_T_F == "T")
            {
                INV_MISC_CHARGES_CONVERT_INV = Convert.ToDouble(INV_MISC_CHARGES) * Convert.ToDouble(INV_MISC_EXRATE);
                INV_MISC_CHARGES_CONVERT_fc = INV_MISC_CHARGES_CONVERT_INV / Convert.ToDouble(MIS_EXRATE);
            }

            //************ CI Terms display in CHECKLIST ******************** 03/01/2018 

            //if (TERMS == "CI")
            //{

            //    string Cal_MIS_CHARGES;

            //    if (MIS_CHARGES == "" || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
            //    {
            //        if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
            //        {
            //            MIS_CURRENCY = INVOICE_CURRENCY;
            //            Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
            //            MISC_AMOUNT = Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) * Convert.ToDouble(INVOICE_EXRATE);
            //            //MIS_CHARGES = Convert.ToString(MISC_AMOUNT);
            //        }
            //        else
            //        {
            //            MIS_CURRENCY = "";
            //            MIS_CHARGES = "";
            //        }
            //    }
            //    else
            //    {
            //        if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
            //        {
            //            if (MIS_CURRENCY == INVOICE_CURRENCY)
            //            {
            //                MIS_CURRENCY = INVOICE_CURRENCY;
            //                Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
            //                MISC_AMOUNT = Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) * Convert.ToDouble(INVOICE_EXRATE);
            //                //MIS_CHARGES = Convert.ToString(MISC_AMOUNT);
            //            }
            //            else
            //            {
            //                double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
            //                Cal_MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
            //                MIS_CURRENCY = INVOICE_CURRENCY;
            //                Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
            //                MISC_AMOUNT = Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) * Convert.ToDouble(INVOICE_EXRATE);
            //                //MIS_CHARGES = Convert.ToString(MISC_AMOUNT);
            //            }
            //        }
            //        else
            //        {
            //            MIS_CURRENCY = MIS_CURRENCY;
            //            MIS_CHARGES = MIS_CHARGES;
            //        }
            //    }
            //}
            //else
            //{
            //    //MISC_AMOUNT = Convert.ToDouble(MIS_CHARGES) * Convert.ToDouble(MIS_EXRATE);// hide by chithra on 02-01-2020 for INVOICE MISC SPLIT CALC- AGILITY
            //    MISC_AMOUNT = (Convert.ToDouble(MIS_CHARGES) + Convert.ToDouble(INV_MISC_CHARGES_CONVERT_fc)) * Convert.ToDouble(MIS_EXRATE);
            //}
            // Modified by shanthini on 07-08-2026 & suggest by bala sir - widened D/M/N to full A-N amount range, and now applies for ALL TERMS (not just "CI")
            {
                string Cal_MIS_CHARGES;

                bool isAnyAmount_AtoN2 = (A_AMOUNT != "" && A_AMOUNT != "0" && A_AMOUNT != "0.00") ||
                                         (B_AMOUNT != "" && B_AMOUNT != "0" && B_AMOUNT != "0.00") ||
                                         (C_AMOUNT != "" && C_AMOUNT != "0" && C_AMOUNT != "0.00") ||
                                         (D_AMOUNT != "" && D_AMOUNT != "0" && D_AMOUNT != "0.00") ||
                                         (E_AMOUNT != "" && E_AMOUNT != "0" && E_AMOUNT != "0.00") ||
                                         (F_AMOUNT != "" && F_AMOUNT != "0" && F_AMOUNT != "0.00") ||
                                         (G_AMOUNT != "" && G_AMOUNT != "0" && G_AMOUNT != "0.00") ||
                                         (H_AMOUNT != "" && H_AMOUNT != "0" && H_AMOUNT != "0.00") ||
                                         (I_AMOUNT != "" && I_AMOUNT != "0" && I_AMOUNT != "0.00") ||
                                         (J_AMOUNT != "" && J_AMOUNT != "0" && J_AMOUNT != "0.00") ||
                                         (K_AMOUNT != "" && K_AMOUNT != "0" && K_AMOUNT != "0.00") ||
                                         (L_AMOUNT != "" && L_AMOUNT != "0" && L_AMOUNT != "0.00") ||
                                         (M_AMOUNT != "" && M_AMOUNT != "0" && M_AMOUNT != "0.00") ||
                                         (N_AMOUNT != "" && N_AMOUNT != "0" && N_AMOUNT != "0.00");

                double sumAtoN_2 = Convert.ToDouble(A_AMOUNT == "" ? "0" : A_AMOUNT)
                                 + Convert.ToDouble(B_AMOUNT == "" ? "0" : B_AMOUNT)
                                 + Convert.ToDouble(C_AMOUNT == "" ? "0" : C_AMOUNT)
                                 + Convert.ToDouble(D_AMOUNT == "" ? "0" : D_AMOUNT)
                                 + Convert.ToDouble(E_AMOUNT == "" ? "0" : E_AMOUNT)
                                 + Convert.ToDouble(F_AMOUNT == "" ? "0" : F_AMOUNT)
                                 + Convert.ToDouble(G_AMOUNT == "" ? "0" : G_AMOUNT)
                                 + Convert.ToDouble(H_AMOUNT == "" ? "0" : H_AMOUNT)
                                 + Convert.ToDouble(I_AMOUNT == "" ? "0" : I_AMOUNT)
                                 + Convert.ToDouble(J_AMOUNT == "" ? "0" : J_AMOUNT)
                                 + Convert.ToDouble(K_AMOUNT == "" ? "0" : K_AMOUNT)
                                 + Convert.ToDouble(L_AMOUNT == "" ? "0" : L_AMOUNT)
                                 + Convert.ToDouble(M_AMOUNT == "" ? "0" : M_AMOUNT)
                                 + Convert.ToDouble(N_AMOUNT == "" ? "0" : N_AMOUNT);

                if (isAnyAmount_AtoN2)
                {
                    if (MIS_CHARGES == "" || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
                    {
                        MIS_CURRENCY = INVOICE_CURRENCY;
                        Cal_MIS_CHARGES = Convert.ToString(sumAtoN_2 + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
                        MISC_AMOUNT = Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) * Convert.ToDouble(INVOICE_EXRATE);
                        //MIS_CHARGES = Convert.ToString(MISC_AMOUNT);
                    }
                    else
                    {
                        if (MIS_CURRENCY == INVOICE_CURRENCY)
                        {
                            MIS_CURRENCY = INVOICE_CURRENCY;
                            Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + sumAtoN_2 + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
                            MISC_AMOUNT = Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) * Convert.ToDouble(INVOICE_EXRATE);
                            //MIS_CHARGES = Convert.ToString(MISC_AMOUNT);
                        }
                        else
                        {
                            double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
                            Cal_MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
                            MIS_CURRENCY = INVOICE_CURRENCY;
                            Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) + sumAtoN_2 + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
                            MISC_AMOUNT = Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) * Convert.ToDouble(INVOICE_EXRATE);
                            //MIS_CHARGES = Convert.ToString(MISC_AMOUNT);
                        }
                    }
                }
                else
                {
                    // No A-N amount present - keep MIS_CHARGES/MIS_CURRENCY as-is, use original MISC_AMOUNT formula
                    //MISC_AMOUNT = Convert.ToDouble(MIS_CHARGES) * Convert.ToDouble(MIS_EXRATE);// hide by chithra on 02-01-2020 for INVOICE MISC SPLIT CALC- AGILITY
                    MISC_AMOUNT = (Convert.ToDouble(MIS_CHARGES) + Convert.ToDouble(INV_MISC_CHARGES_CONVERT_fc)) * Convert.ToDouble(MIS_EXRATE);
                }
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
                TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR - DISCOUNT_AMOUNT;
                //TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR;
            }
            else
                TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR;
            //-----DISCOUNT AMOUNT CAL--------------//

            //------- LOADING CHARGES CALC --------------//

            if (MIS_LOADING_RATE != "0" && MIS_LOADING_RATE != "0.00" && MIS_LOADING_RATE != "0.0000" && MIS_LOADING_RATE != "") //here Loading cal added by pandiyan on 18-06-2025 asked by bala 
            {
                LOADING_AMOUNT = INVOICE_VALUE_INR + LOADING_FREIGHT_AMT + LOADING_INSURANCE_AMT;
                LOADING_AMOUNT = LOADING_AMOUNT * Convert.ToDouble(MIS_LOADING_RATE) / 100;
            }
            else
            {
                LOADING_AMOUNT = Convert.ToDouble(MIS_LOADING_CHARGES) * Convert.ToDouble(MIS_LOADING_EXRATE);
            }

            //-----INSURANCE AMOUNT CAL--------------//
            if (MIS_INSURANCE_RATE != "0" && MIS_INSURANCE_RATE != "0.00" && MIS_INSURANCE_RATE != "0.0000" && MIS_INSURANCE_RATE != "")
            {
                if (INV_MISC_T_F != "T")
                {
                    //INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100; // Hided by pandiyan on 18-06-2025 for loading charge shuld add in ins 
                    INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (MISC_AMOUNT + LOADING_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;
                }
                else
                {
                    // INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (INV_MISC_CHARGES_CONVERT_INV + TOTAL_INVOICE_VALUE)) / 100;//01-02-2020 
                    //INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100; // Hided by pandiyan on 18-06-2025 for loading charge shuld add in ins
                    INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (MISC_AMOUNT + LOADING_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;
                }
                LOADING_INSURANCE_AMT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (TOTAL_INVOICE_VALUE)) / 100;
            }
            else if (MIS_INSURANCE_CHARGES != "0" && MIS_INSURANCE_CHARGES != "0.00")
            {
                INSURANCE_AMOUNT = Convert.ToDouble(MIS_INSURANCE_CHARGES) * Convert.ToDouble(MIS_INSURANCE_EXRATE);

            }
            //-----INSURANCE AMOUNT CAL--------------//

            //-----FREIGHT AMOUNT CAL--------------//


            if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00")
            {
                if (INV_MISC_T_F != "T")
                {
                    //FREIGHT_AMOUNT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100; // Hided by pandiyan on 18-06-2025 for loading charge shuld add in fri
                    FREIGHT_AMOUNT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (MISC_AMOUNT + LOADING_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;
                }
                else
                {
                    //FREIGHT_AMOUNT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (INV_MISC_CHARGES_CONVERT_INV + TOTAL_INVOICE_VALUE)) / 100;
                    FREIGHT_AMOUNT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;
                }
                LOADING_FREIGHT_AMT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (TOTAL_INVOICE_VALUE)) / 100;
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

                        //this line hide by Chithra on 19-08-2020 for SHIFTCO - DiscAmt calc issue
                        //freight_amt_air = (INVOICE_VALUE_INR + MISC_AMOUNT) * 20 / 100;


                        //this condition newly put for INDIA IMPEX - sugg.by Bala sir with Sathish Sir - for Air shipment SVB should add even FRT in Charges also
                        if (COMPANY_ID == "656" || COMPANY_ID == "1213")
                        {
                            INDIVITUAL_SVB_AMOUNT = (TOTAL_INVOICE_VALUE + MISC_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            freight_amt_air = (TOTAL_INVOICE_VALUE + MISC_AMOUNT + INDIVITUAL_SVB_AMOUNT) * 20 / 100;
                        }
                        else
                        {
                            freight_amt_air = (TOTAL_INVOICE_VALUE + MISC_AMOUNT) * 20 / 100;

                            if (dt_ReImport.Rows.Count > 0)
                            {
                                if (dt_ReImport.Rows[0]["NOTN_NO"].ToString() == "045/2017" && dt_ReImport.Rows[0]["NOTN_SLNO"].ToString() == "2")//Sugg.By Bala sir On 13-02-2024
                                {
                                    freight_amt_air = Convert.ToDouble(MIS_FREIGHT_CHARGES) * Convert.ToDouble(MIS_FREIGHT_EXRATE);
                                }
                            }
                        }


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
            INDIVITUAL_INVOICE_VALUE = c_ITEM_QTY * Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(INVOICE_EXRATE);
            //INDIVITUAL_DISCOUNT_AMOUNT = INDIVITUAL_INVOICE_VALUE * DISCOUNT_AMOUNT / TOTAL_INVOICE_VALUE;
            INDIVITUAL_DISCOUNT_AMOUNT = INDIVITUAL_INVOICE_VALUE * DISCOUNT_AMOUNT / INVOICE_VALUE_INR; // Claculation changed by Sathish with Bala/Ayisha on 25May2019

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

            //INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * FREIGHT_AMOUNT;
            INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_INVOICE_VALUE / INVOICE_VALUE_INR * FREIGHT_AMOUNT; // Claculation changed by Sathish with Bala/Ayisha on 25May2019
            INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_FREIGHT_AMOUNT + REIMPORT_FREIGHT_AMOUNT;


            //-----REIMPORTT INSURANCE CAL--------------//

            //INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * INSURANCE_AMOUNT;
            INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INVOICE_VALUE / INVOICE_VALUE_INR * INSURANCE_AMOUNT;// Claculation changed by Sathish with Bala/Ayisha on 25May2019
            INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;

            //------- LOADING CHARGES CALC --------------//
            INDIVITUAL_LOADING_AMOUNT = INDIVITUAL_INVOICE_VALUE / INVOICE_VALUE_INR * LOADING_AMOUNT;

            //------- AGENCY CHARGES CALC --------------//
            if (MIS_AGENCY_RATE != "0" && MIS_AGENCY_RATE != "0.00" && MIS_AGENCY_RATE != "0.0000" && MIS_AGENCY_RATE != "")
            {
                AGENCY_AMOUNT = INVOICE_VALUE_INR * Convert.ToDouble(MIS_AGENCY_RATE) / 100;
                INDIVITUAL_AGENCY_AMOUNT = INDIVITUAL_INVOICE_VALUE / INVOICE_VALUE_INR * AGENCY_AMOUNT;
            }
            else
            {
                AGENCY_AMOUNT = Convert.ToDouble(MIS_AGENCY_CHARGES) * Convert.ToDouble(MIS_AGENCY_EXRATE);
                INDIVITUAL_AGENCY_AMOUNT = INDIVITUAL_INVOICE_VALUE / INVOICE_VALUE_INR * AGENCY_AMOUNT;
            }

            //-----MISC CAL--------------//

            //INDIVITUAL_MISC_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * MISC_AMOUNT;
            INDIVITUAL_MISC_AMOUNT = INDIVITUAL_INVOICE_VALUE / INVOICE_VALUE_INR * MISC_AMOUNT;// Claculation changed by Sathish with Bala/Ayisha on 25May2019


            // FREIGHT & INSURANCE IN RATE WITH SVB BELOW CALC - IMPLENTED BY CHITHRA ON 08-04-2020 FOR AGILITY

            if (SVB_ASSESABLE_RATE != "0" && SVB_ASSESABLE_RATE != "0.00")
            {
                if (TERMS == "CIF")
                {
                    INDIVITUAL_SVB_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT * (Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
                }
                else if (TERMS == "FOB" || TERMS == "CI" || TERMS == "CF")
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
                        if (SVB_LOADING_ON != "B")//Newly Impemented on 27-12-2024 by Chithra Sugg.by Bala for CAPRICORN
                        {
                            //Insurance Amount need to add for SVB
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_INSURANCE_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;

                            //This line hide on 11-04-2026 by chithra sugg.by Bala sir - checked with Final copy
                            //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            //INDIVITUAL_SVB_AMOUNT = (Convert.ToDouble(SVB_ASSESABLE_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;
                            //INDIVITUAL_SVB_AMOUNT = INDIVITUAL_INVOICE_VALUE / INVOICE_VALUE_INR * INDIVITUAL_SVB_AMOUNT;

                            //this line hide by Chithra on 24-08-2020 for Agility- Checked with Final print given by Karthik-Agility
                            //INDIVITUAL_INSURANCE_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_SVB_AMOUNT) / INVOICE_VALUE_INR * INSURANCE_AMOUNT;// Claculation changed by Sathish with Bala/Ayisha on 25May2019
                            //INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;

                            /*this line hide by Chithra on 14-03-2025 sUGG.BY Bala sir Checked with Final Print for GK Logistics
                           INDIVITUAL_INSURANCE_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_SVB_AMOUNT) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                           INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;
                             * */
                        }
                        else
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_INSURANCE_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                        }
                    }

                    else if (MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE == "0")
                    {
                        if (SVB_LOADING_ON != "B")//Newly Impemented on 27-12-2024 by Chithra Sugg.by Bala for CAPRICORN
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;

                            //This line hide on 11-04-2026 by chithra sugg.by Bala sir - checked with Final copy
                            //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            //INDIVITUAL_SVB_AMOUNT = (Convert.ToDouble(SVB_ASSESABLE_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;
                            //INDIVITUAL_SVB_AMOUNT = INDIVITUAL_INVOICE_VALUE / INVOICE_VALUE_INR * INDIVITUAL_SVB_AMOUNT;

                            //this line hide by Chithra on 24-08-2020 for Agility- Checked with Final print given by Karthik-Agility
                            //INDIVITUAL_FREIGHT_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_SVB_AMOUNT) / INVOICE_VALUE_INR * FREIGHT_AMOUNT;// Claculation changed by Sathish with Bala/Ayisha on 25May2019
                            //INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_FREIGHT_AMOUNT + REIMPORT_FREIGHT_AMOUNT;

                            INDIVITUAL_FREIGHT_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_SVB_AMOUNT) * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;
                            INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_FREIGHT_AMOUNT + REIMPORT_FREIGHT_AMOUNT;
                        }
                        else
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_INSURANCE_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                        }
                    }
                    else if (MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE != "0")
                    {
                        if (SVB_LOADING_ON != "B")//Newly Impemented on 27-12-2024 by Chithra Sugg.by Bala for CAPRICORN
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_INSURANCE_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;

                            //This line hide on 11-04-2026 by chithra sugg.by Bala sir - checked with Final copy
                            //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;

                            /* this line hide by Chithra on 24-08-2020 for Agility- Checked with Final print given by Karthik-Agility
                           INDIVITUAL_FREIGHT_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_SVB_AMOUNT) / INVOICE_VALUE_INR * FREIGHT_AMOUNT;// Claculation changed by Sathish with Bala/Ayisha on 25May2019
                           INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_FREIGHT_AMOUNT + REIMPORT_FREIGHT_AMOUNT;

                           INDIVITUAL_INSURANCE_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_SVB_AMOUNT) / INVOICE_VALUE_INR * INSURANCE_AMOUNT;// Claculation changed by Sathish with Bala/Ayisha on 25May2019
                           INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;
                            */

                            /*this line hide by Chithra on 21-02-2025 sUGG.BY Bala sir Checked with Final Print
                          INDIVITUAL_FREIGHT_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_SVB_AMOUNT) * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;
                          INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_FREIGHT_AMOUNT + REIMPORT_FREIGHT_AMOUNT;

                          INDIVITUAL_INSURANCE_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_SVB_AMOUNT) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                          INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;
                             * */
                        }
                        else
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_INSURANCE_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                        }
                    }
                }
            }



            if (COMPANY_ID == "163")
            {
                INDIVITUAL_TOTAL_AMOUNT = INDIVITUAL_INVOICE_VALUE + INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_MISC_AMOUNT;
            }
            else
            {
                //INDIVITUAL_TOTAL_AMOUNT = INDIVITUAL_DISCOUNT_AMOUNT + INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_MISC_AMOUNT;
                INDIVITUAL_TOTAL_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_LOADING_AMOUNT + INDIVITUAL_AGENCY_AMOUNT) - INDIVITUAL_DISCOUNT_AMOUNT;
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
                //      INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT) / TOTAL_INVOICE_VALUE * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES);
                //modified on 23aug2013 by subbu sir

                //modified on 28Dec2013 by subbu sir
                INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_INVOICE_VALUE) / TOTAL_INVOICE_VALUE * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES);
                //modified on 28Dec2013 by subbu sir


                //INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES)) / 100;
            }

            TOTAL_HSS_AMOUNT += INDIVITUAL_HSS_AMOUNT;

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
            //INDIVITUAL_CIF_AMOUNT = INDIVITUAL_TOTAL_AMOUNT + INDIVITUAL_HSS_AMOUNT + INDIVITUAL_SVB_AMOUNT;//07-04-2020 chithra -- svb amount add finally so hide here
            INDIVITUAL_CIF_AMOUNT = INDIVITUAL_TOTAL_AMOUNT + INDIVITUAL_HSS_AMOUNT;

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

                //if (Igm_DATE != "" || Igm_DATE == null)-hide on 24-Nov-2020 for Agility - when IGM date is empty
                if ((Igm_DATE != "" && Igm_DATE != "01-01-1900") || Igm_DATE == null)
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
                        //-- INSURANCE RATE CALC - IMPELMETED ABOVE AS PER RATE

                        //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;

                        //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;

                        //INDIVITUAL_INSURANCE_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_SVB_AMOUNT) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;

                        /* -- HIDE BY CHITHRA ON 27-03-2018 - CAPITAL SHIPPING- RAMESH ASKED
                        double AA = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);
                        INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) *  Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                         */
                        //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    }

                    else if (MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE == "0")
                    {
                        if (SVB_ASSESABLE_STATUS == "F")// this Final condition newly put by Chithra sugg by Bala sir for PARAMOUNT On 28-02-2020
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT * Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
                        }
                        else
                        {
                            double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                        }
                    }

                    else if (MIS_FREIGHT_RATE == "0" && MIS_INSURANCE_RATE == "0")
                    {
                        if (SVB_ASSESABLE_STATUS == "F")// this Final condition newly put by Chithra sugg by Bala sir for PARAMOUNT On 28-02-2020
                        {
                            /*  -- below code hide by Chithra on 26-05-2020 for Pioneer issue compare with logisys checklist calc
                           // this Final condition newly put by Chithra sugg by Bala sir for PARAMOUNT On 28-02-2020
                           INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT * Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
                            * */


                            //newly Implemented on 07-04-2020 for Agility checked with Final BOE
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                        }
                        else
                        {
                            /*
                            double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);
                            double BB = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);
                            double CC = AA + BB;

                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - CC) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            //INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            */

                            //newly Implemented on 07-04-2020 for Agility checked with Final BOE
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                        }
                    }

                    else if (MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE != "0")
                    {
                        if (SVB_ASSESABLE_STATUS == "F")// this Final condition newly put by Chithra sugg by Bala sir for PARAMOUNT On 28-02-2020
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT * Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
                        }
                        else
                        {
                            // FREIGHT RATE & INSURANCE RATE CALC IMPELMENTED IN ABOVE AS PER RATE CALC
                            /*
                            double AA = INDIVITUAL_INSURANCE_AMOUNT - (INDIVITUAL_INSURANCE_AMOUNT * 0.01);
                            double BB = INDIVITUAL_FREIGHT_AMOUNT - (INDIVITUAL_FREIGHT_AMOUNT * 0.01);
                            double CC = AA + BB;

                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - CC) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                             * */
                        }
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
                        if (SVB_ASSESABLE_STATUS == "F")// this Final condition newly put by Chithra sugg by Bala sir for PARAMOUNT On 28-02-2020
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT * Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
                        }
                        else
                        {
                            //-- INSURANCE RATE CALC - IMPELMETED ABOVE AS PER RATE 
                            /* hide by Chitha on 08-04-2020 for Agility checked with final BOE
                            double AA = INDIVITUAL_INSURANCE_AMOUNT - (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                             * 
                             * */
                        }
                    }
                    else if (MIS_INSURANCE_RATE == "0")
                    {
                        if (SVB_ASSESABLE_STATUS == "F")// this Final condition newly put by Chithra sugg by Bala sir for PARAMOUNT On 28-02-2020
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT * Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
                        }
                        else
                        {
                            double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                        }
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
                        if (SVB_ASSESABLE_STATUS == "F")// this Final condition newly put by Chithra sugg by Bala sir for PARAMOUNT On 28-02-2020
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT * Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
                        }
                        else
                        {
                            //-- FREIGHT RATE CALC - IMPELMETED ABOVE AS PER RATE
                            /*
                            double AA = INDIVITUAL_FREIGHT_AMOUNT - (INDIVITUAL_FREIGHT_AMOUNT * 0.01);

                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                             */
                        }
                    }
                    else if (MIS_FREIGHT_RATE == "0")
                    {
                        if (SVB_ASSESABLE_STATUS == "F")// this Final condition newly put by Chithra sugg by Bala sir for PARAMOUNT On 28-02-2020
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT * Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
                        }
                        else
                        {
                            double AA = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);

                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                            // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                        }
                    }
                }
            }


            //--------ITEMWISE SVB CALCULATION FOR NIPPON EXPRESS--------//

            INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT + INDIVITUAL_SVB_AMOUNT;


            //--------ITEMWISE SVB CALCULATION FOR NIPPON EXPRESS--New Implementation on 26-12-2025 by Chithra & Bala------//
            if (ITEM_SVB_ASSESABLE_RATE != "0" && ITEM_SVB_ASSESABLE_RATE != "0.00" && ITEM_SVB_ASSESABLE_RATE != "")
            {
                ITEM_INDIVITUAL_SVB_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT * (Convert.ToDouble(ITEM_SVB_ASSESABLE_RATE)) / 100;
            }

            INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT + ITEM_INDIVITUAL_SVB_AMOUNT;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return INDIVITUAL_ASSESSABLE_AMOUNT;
    }

    public void Get_Admin_Master_Codes()
    {
        try
        {
            Export_FlatFile_Generation Imp_FlatFile = new Export_FlatFile_Generation();
            Imp_FlatFile.Ename = "IMPORT_SELECT_COUNTRY";
            dss_Coo = Imp_FlatFile.Search_Admin_Master();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public string Return_Zero_Value(string val)
    {
        try
        {
            if (val == "")
            {
                val = "0";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return val;
    }

    public string Return_Zero_Value1(string val)
    {
        try
        {
            if (val == "")
            {
                val = "0.00";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return val;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            string fileName = "a";

            byte[] bytes = ReportViewer1.LocalReport.Render("word", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Session["report"] = bytes;


            //Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/rtf";

            //Response.BinaryWrite(bytes); // create the file
            //Response.Flush(); // send it to the client to download
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + "RTF");
            //String encodedImgData = Convert.ToBase64String(bytes);

            //Response.Write(String.Format(encodedImgData)); // create the file
            //Response.Flush(); // send it to the client to download
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.Close();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
    }

    // ---------------------------------------------------Jono dropdown work--------------------



    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlJob_No.SelectedItem.Text != "Select")
            {
                ReportViewer1.LocalReport.DataSources.Clear();
                Response.Redirect("../Report/Import_ReportViewer.aspx?jobno=" + ddlJob_No.SelectedItem.Value + "&jobnops='" + ddlJob_No.SelectedItem.Text + "' ");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnpdf_Click(object sender, EventArgs e)
    {
        try
        {
            byte[] bytes = (byte[])Session["report"];
            Response.ClearHeaders();
            Response.Clear();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=IMPChecklist" + ddlJob_No.SelectedItem.Text + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
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
        try
        {
            DataTable dt = new DataTable();
            dt = null;
            dt = (DataTable)ViewState["Checklist_Value"];

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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private DataTable Bind_Doc_Type_Desc(string Doc_TypeCode)
    {
        DataSet dss = new DataSet();
        adminmaster Am = new adminmaster();
        try
        {
           
            Am.SCHEME_IMPORT_CODE = Doc_TypeCode;
            Am.name = "Select_SUPPORTING_DOCS_DESC_Checklist";
            dss = Am.IMP_Single_Window();
          
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return dss.Tables[0];
    }

    public void ClearAll()
    {
        try
        {
            OutOfMemoryException aa = new OutOfMemoryException();

            aa.Data.Clear();

            //        string message,_memoryCache;
            //// _memoryCache is of type IMemoryCache and was set via dependency injection.
            //var    memoryCache = _memoryCache as MemoryCache;
            //if (memoryCache != null)
            //{
            //    memoryCache.Compact(1);

            //    message ="Cache cleared";
            // } else {
            //    message = "Could not cast cache object to MemoryCache. Cache NOT cleared.";
            // }


            //        var allKeys = _cache.Select(o => o.Key);
            //        Parallel.ForEach(allKeys, key => _cache.Remove(key));

            //        var cache = GlobalCachingProvider.Instance.GetAllItems();
            //        if (dbOperation.SuccessLoadingAllCacheToDB(cache))
            //        {
            //            cache.Clear();
            //        }


            //        var cacheKeys = MemoryCache.Default.Where(kvp.Value is MyType).Select(kvp => kvp.Key).ToList();
            //        foreach (string cacheKey in cacheKeys)
            //        {
            //            MemoryCache.Default.Remove(cacheKey);
            //        }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void Auto_IRN_Insert_from_Esanchit_EmailsRead(string Imp_Exp_type, string Jobno)
    {
        try
        {
            Auto_IRN_Upload IRN = new Auto_IRN_Upload();
            DataSet ds_IRN = new DataSet();

            ds_IRN = IRN.Imp_Exp_Auto_IRN_Insert(Jobno, "Get_Doc_Type_Code", Imp_Exp_type, dtt);

            if (ds_IRN.Tables[0].Rows.Count > 0)
            {
                ds_IRN = IRN.Imp_Exp_Auto_IRN_Insert(Jobno, "eSanchit_Mail_Insert_to_Job", Imp_Exp_type, Bind_Doc_Type_Desc(ds_IRN.Tables[0].Rows[0]["DOC_CODE"].ToString()));
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
}