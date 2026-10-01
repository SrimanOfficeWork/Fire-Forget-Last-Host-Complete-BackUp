using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BussinessObject;
using System.Text;
using System.IO;
/// <summary>
/// Summary description for Imp_Checklist_Item_License
/// </summary>
public class Imp_Checklist_Item_License
{
    #region ITEM ATTRIBUTES
    #region Private_Attributes
    private int _INVOICE_SLNO;
    private string _INVOICE_DATE;
    private string _SUPPLIER_NAME;
    private string _SUPPLIER_ADDRESS;
    private string _SUPPLIER_ADDRESS1;
    private string _SUPPLIER_ADDRESS2;
    private string _SVB_RELATION;
    private string _SVB_REF_NO, _TERMS;
    private string _SVB_LOADING_ON;
    private string _SVB_REF_DATE;
    private string _SVB_STATUS;
    private string _EOU_MERIT_BASIC_DUTY;
    private string _EOU_MERIT_CVD;
    private string _INVOICE_NO_ITEM, _Invoice_No, _Invoice_Details;
    private string _SUPPLIER_COUNTRY_NAME;
    private string _SUPPLIER_COUNTRY_PINCODE;
    private string _SVB_ASSESABLE_STATUS;
    private string _SVB_DUTY_STATUS;

    private string _INVOICE_VALUE, _Invoice_value, _INVOICE_EXRATE, _INVOICE_NO;
    private string _MIS_FREIGHT_RATE;

    private string _MIS_INSURANCE_RATE;
    private string _BE_TYPE;
    private string _REVENUEDEPOSIT_RATE;
    private string _REVENUEDEPOSIT_ON;

    private string _IGM_TRANSPORTMODE;
    private string _PORT_ORIGIN;
    private string _Country_Origin;
    private string _Country_Shipment;
    //item Details
    private string _SVB_CUSTOM_HOUSE;
    private string _ITEM_SLNO;
    private string _ITEM_DESCRIPTION;
    private string _ITEM_QTY;
    private string _ITEM_QTY_CODE;
    private string _ITEM_UNIT_PRICE;
    private string _Total_Invoice, _SupplierCountry_Name_Pincode;
    private string _SCHEME_CODE, _SCHEME;
    private string _SCHEME_NOTN;
    private string _SCHEME_NOTN_SLNO;

    private string _ANTI_DUMPING_NOTN;
    private string _ANTI_DUMPING_NOTN_SLNO;
    private string _CTH_SLNO;
    private string _CTH_SUPPLIER_SLNO;
    private string _CTH_QTY, _ADD_EX_RATE;

    private string _CTH_NO;
    private string _PRODUCT_RITC;
    private string _PRODUCT_CTH;

    private string _PRODUCT_CVD_RATE, _MERIT_PRODUCT_CVD_RATE, _PRODUCT_CVD_RATE_UPDATE, _PRODUCT_CVD_NOTN, _PRODUCT_CVD_NOTN_SLNO, _PRODUCT_CVD_SPL;
    private string _PRODUCT_EDU_CESS_RATE;
    private string _PRODUCT_SEC_EDU_CESS_RATE;

    private string _PRODUCT_BCD_RATE, _MERIT_PRODUCT_BCD_RATE, _PRODUCT_BCD_RATE_UPDATE, _PRODUCT_BCD_NOTN, _PRODUCT_ADDL_DUTY_NOTN, _ADDTIONAL_DUTY_RATE, _PRODUCT_ADDL_DUTY_RATE, _PRODUCT_SEC_EDU_CESS_NOTN, _PRODUCT_EDU_CESS_NOTN, _EXCEMPTION, _INVOICE_CURRENCY, _Invoice_Currency;

    private string _PRODUCT_CETH, _ADDTIONAL_DUTY, _AGGREGATE_TOTAL, _BASIC_DUTY_TOATAL, _CVD_TOTAL, _NCD_TOTAL, _CESS_TOTAL, _CEC_TOTAL, _CHEC_TOTAL, _ADDLTIONAL_DUTY_TOTAL, _TOTAL_ITEM_DUTY, _NUMBERTOWORDS, _INFRA_CESS_TOTAL;

    private string _PRODUCT_MRP_YN, _PRODUCT_MRP_SL_NO, _PRODUCT_MRP_AMOUNT, _PRODUCT_MRP_ABT_RATE, _RSP_NOTN_NO, _RSP_NOTN_SL_NO, _RSP_APPLICABLE;

    private string _PRODUCT_OTHER_DUTY_NOTN, _PRODUCT_OTHER_DUTY_SLNO, _PRODUCT_OTHER_DUTY_RATE, _PRODUCT_OTHER_DUTY_SPL, _PRODUCT_OTHER_DUTY_UNIT, _PRODUCT_OTHER_DUTY_TYPE, _PRODUCT_OTHER_DUTY_TOTAL;

    private string _PRODUCT_CVD_EDU_CESS_RATE, _PRODUCT_CVD_SEC_EDU_CESS_RATE, _CETH_CVD_EDU_CESS_SL, _CETH_CVD_EDU_CESS_RATE, _CETH_CVD_SEC_EDU_CESS_SL, _CETH_CVD_SEC_EDU_CESS_RATE;
    private string _CVD_CEC_TOTAL, _CVD_CHEC_TOTAL;

    private string _ITEM_SVB_RELATION, _ITEM_SVB_REF_NO, _ITEM_SVB_REF_DATE, _ITEM_SVB_CUSTOM_HOUSE, _ITEM_SVB_LOADING_ON, _ITEM_SVB_ASSESABLE_RATE, _ITEM_SVB_DUTY_RATE, _ITEM_SVB_ASSESABLE_STATUS, _ITEM_SVB_DUTY_STATUS;

    private string _INFRA_CESS_NOTN, _INFRA_CESS_NOTN_SL, _INFRA_CESS_NOTN_RATE;

    //----------------------------------------//
    private string _SCHED11_TOTAL, _PRODUCT_ADDL_SHEII_NOTN, _PRODUCT_ADDL_SHEII_SLNO, _PRODUCT_ADDL_SHEII_RATE;
    private string _GSI_TOTAL, _PRODUCT_ADDL_GSI_NOTN, _PRODUCT_ADDL_GSI_SLNO, _PRODUCT_ADDL_GSI_RATE, _PRODUCT_ADDL_GSI_SPL, _PRODUCT_ADDL_GSI_UNIT, _PRODUCT_ADDL_GSI_SPL_TYPE;

    private string _TTA_TOTAL, _PRODUCT_ADDL_TTA_NOTN, _PRODUCT_ADDL_TTA_SLNO, _PRODUCT_ADDL_TTA_RATE, _PRODUCT_ADDL_TTA_SPL, _PRODUCT_ADDL_TTA_UNIT, _PRODUCT_ADDL_TTA_TYPE;

    private string _PRODUCT_NCD_NOTN, _PRODUCT_NCD_SLNO, _PRODUCT_NCD_RATE, _PRODUCT_NCD_SPL, _PRODUCT_NCD_UNIT, _PRODUCT_NCD_SPL_TYPE;

    private string _PRODUCT_SAPTA_NOTN, _PRODUCT_SAPTA_SLNO, _PRODUCT_SAPTA_RATE;

    private string _PRODUCT_TARIFF_NOTN, _PRODUCT_TARIFF_SLNO, _PRODUCT_TARIFF_QTY, _PRODUCT_TARIFF_AMOUNT, _PRODUCT_TARIFF_AMOUNT_UNIT;

    private string _PRODUCT_SAFEGUARD_NOTN, _PRODUCT_SAFEGUARD_SLNO, _PRODUCT_SAFEGUARD_RATE, _PRODUCT_SAFEGUARD_SPL, _PRODUCT_SAFEGUARD_UNIT, _PRODUCT_SAFEGUARD_SPL_TYPE;

    private string _PRODUCT_AGGREGATE_DUTY_NOTN, _PRODUCT_AGGREGATE_DUTY_NOTN_SL, _PRODUCT_AGGREGATE_DUTY_NOTN_RATE;

    private string _EXBOND_ADDL_LOAD_HSS;
    private string _EXBOND_MISC_LOAD_RATE;
    private string _CETH_SPL_AMT;
    private string _CTH_SPL_AMT;
    private string _DIFF_AMT_BDC_TRQ_SW;
    private string _DIFF_AMT_BDC_TRQ;
    private string _TOTAL_DEBIT_DUTY;
    private string _MERIT_TOTAL_DEBIT_DUTY;
    private string _TOTAL_DEBIT_DUTY_FINAL;
    private string _CTH_QTY1;
    private string _CTH_QTY1_CODE;

    private string _CTH_NCD_D_RATE;
    private string _CTH_SAFEGUARD_RATE;

    private string _NOTIFICATION_CUSTOMS_BCD_RATE;
    private string _NOTIFICATION_CUSTOMS_CVD_RATE;
    private string _NOTIFICATION_CUSTOMS_BCD_SPL;
    private string _CTH_INFRA_CESS_RATE;

    private string _CETH_CESS_AMTS;
    private string _CETH_CESS_RTA;
    private string _CETH_CESS_UQC;
    private string _CESS_ROW_VISIBLE;

    // private string _SAFE_GUARD; _DIFF_AMT_BDC_TRQ
    private string _SAFE_GUARD_TOTAL;
    //----------------------------------------//
    private string _PRODUCT_BCD_NOTN_SLNO, _PRODUCT_ADDL_DUTY_NOTN_SLNO, _PRODUCT_SEC_EDU_CESS_NOTN_SLNO, _PRODUCT_EDU_CESS_NOTN_SLNO, _PRODUCT_BCD_SPL;
    private double _ASSESABLE_VALUE, _ASSESSABLE_TOTAL, _ITEM_TOTAL;
    public string PRODUCT_BCD_NOTN_SLNO { get { return _PRODUCT_BCD_NOTN_SLNO; } set { _PRODUCT_BCD_NOTN_SLNO = value; } }
    public string DIFF_AMT_BDC_TRQ_SW { get { return _DIFF_AMT_BDC_TRQ_SW; } set { _DIFF_AMT_BDC_TRQ_SW = value; } }
    public string DIFF_AMT_BDC_TRQ { get { return _DIFF_AMT_BDC_TRQ; } set { _DIFF_AMT_BDC_TRQ = value; } }
    public string PRODUCT_BCD_SPL { get { return _PRODUCT_BCD_SPL; } set { _PRODUCT_BCD_SPL = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN_SLNO { get { return _PRODUCT_ADDL_DUTY_NOTN_SLNO; } set { _PRODUCT_ADDL_DUTY_NOTN_SLNO = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN_SLNO { get { return _PRODUCT_SEC_EDU_CESS_NOTN_SLNO; } set { _PRODUCT_SEC_EDU_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_EDU_CESS_NOTN_SLNO { get { return _PRODUCT_EDU_CESS_NOTN_SLNO; } set { _PRODUCT_EDU_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_CVD_NOTN_SLNO { get { return _PRODUCT_CVD_NOTN_SLNO; } set { _PRODUCT_CVD_NOTN_SLNO = value; } }

    public string PRODUCT_CVD_SPL { get { return _PRODUCT_CVD_SPL; } set { _PRODUCT_CVD_SPL = value; } }


    public string CESS_ROW_VISIBLE { get { return _CESS_ROW_VISIBLE; } set { _CESS_ROW_VISIBLE = value; } }

    //public string SAFE_GUARD { get { return _SAFE_GUARD; } set { _SAFE_GUARD = value; } }
    public string SAFE_GUARD_TOTAL { get { return _SAFE_GUARD_TOTAL; } set { _SAFE_GUARD_TOTAL = value; } }
    //public string CESS_ROW_VISIBLE="0";

    #endregion

    #region Public_Attributes
    public string TRANSPORT_MODE;

    public string MIS_FREIGHT_CHARGES;

    public string MIS_FREIGHT_CURRENCY;
    public string MIS_FREIGHT_EXRATE;
    public string MIS_INSURANCE_CHARGES;

    public string MIS_INSURANCE_CURRENCY;
    public string MIS_INSURANCE_EXRATE;

    public string SVB_ASSESABLE_RATE;
    public string SVB_DUTY_RATE;

    public string MIS_CHARGES;
    public string MIS_RATE;
    public string MIS_EXRATE;
    public string MIS_HIGHSEASALE_RATE;
    public string MIS_HIGHSEASALE_CHARGES;
    public string MIS_DISCOUNT_RATE;
    public string MIS_DISCOUNT_CHARGES;


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


    public string MIS_CURRENCY;
    public string MIS_LOADING_CHARGES;
    public string MIS_LOADING_CURRENCY;
    public string MIS_LOADING_EXRATE;
    public string MIS_DISCOUNT_CURRENCY;
    public string MIS_DISCOUNT_EXRATE;

    public string MIS_HIGHSEASALE_CURRENCY;

    public string REIMPORT_FREIGHT;
    public string REIMPORT_INSURANCE;

    public string NOTN_NO;
    public string NOTN_SLNO;

    public string MIS_HIGHSEASALE_EXRATE;
    public double INVOICE_VALUE_INR;
    public double TOTAL_INVOICE_VALUE;

    public double REIMPORT_FREIGHT_AMOUNT;
    public double REIMPORT_INSURANCE_AMOUNT;
    public double MISC_AMOUNT;
    public double DISCOUNT_AMOUNT = 0;
    public double INVOICE_AMOUNT = 0;
    public double INSURANCE_AMOUNT = 0;
    public double FREIGHT_AMOUNT = 0;
    public double INDIVITUAL_INVOICE_VALUE = 0;
    public double INDIVITUAL_FREIGHT_AMOUNT = 0;
    public double INDIVITUAL_INSURANCE_AMOUNT = 0;
    public double INDIVITUAL_MISC_AMOUNT = 0;
    public double INDIVITUAL_TOTAL_AMOUNT = 0;
    public double INDIVITUAL_HSS_AMOUNT = 0;
    public double INDIVITUAL_SVB_AMOUNT = 0;
    public double INDIVITUAL_CIF_AMOUNT = 0;
    public double INDIVITUAL_LANDING_COST = 0;
    public double INDIVITUAL_ASSESSABLE_AMOUNT = 0;
    public double CHECK_FREIGHT_RATE = 0;
    public double CHECK_FREIGHT_EXRATE = 0;

    public double LICENSE_DEBIT_AMT = 0;

    public double TOTAL_ANTIDUMP_AMT = 0;
    public double MERIT_TOTAL_ANTIDUMP_AMT = 0;
    public string ADD_AMT_MINUS_ASSESABLE;
    public string ANTI_AMTS;
    public string MAX_DIFF;
    public string ADD_DIFF_CUR;
    public string TOTAL_ANTI_AMT = "0";
    public string MERIT_TOTAL_ANTI_AMT = "0";

    public double ADD_ANTI_AMTS, EXCHANGE_RATE, ADD_MAX_DIFF;
    public string ADD_ANTI_CUR;
    public string SCHEME_RATE_NEW;

    public string BCD_NOTN;
    public string CVD_NOTN;
    public string EDU_CESS_NOTN;
    public string SEC_EDU_CESS_NOTN;

    public string PRODUCT_CVD_EDU_CESS_NOTN_SL;
    public string PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL;

    public double INDIVITUAL_DISCOUNT_AMOUNT = 0;

    public double BASIC_DUTY, MERIT_BASIC_DUTY, CVD, INFRA_CESS, MERIT_CVD, NCD, CESS, MERIT_CESS, Customs_Edu_Cess, merit_Customs_Edu_Cess, Customs_Higher_Edu_Cess, merit_Customs_Higher_Edu_Cess, AddL_DUTY, merit_AddL_DUTY, TOTAL_DUTY = 0.0, MERIT_TOTAL_DUTY = 0.0, SAFE_GUARD, AGGREGATE_DUTY;

    public double MERIT_BASIC_VALUE, MERIT_CVD_VALUE, MERIT_CEC_VALUE, MERIT_CHEC_VALUE, MERIT_ADD_DUTY_VALUE;

    public double MERIT_NOTN_BASIC_VALUE, MERIT_NOTN_CVD_VALUE, MERIT_NOTN_CEC_VALUE, MERIT_NOTN_CHEC_VALUE, MERIT_NOTN_ADD_DUTY_VALUE, MERIT_NOTN_CESS_VALUE, MERIT_NOTN_NCD_VALUE;

    public double BASIC_DUTY_BCD_SPL;

    public double cvd_Customs_Edu_Cess, cvd_Customs_Higher_Edu_Cess;

    public double Other_duty = 0.00;

    public double Aggregate_cvd, Aggregate_basic_duty, Aggregate_ncd, Aggregate_cess, Aggregate_Customs_Edu_Cess, Aggregate_Customs_Higher_Edu_Cess, Aggregate_AddL_DUTY, Aggregate_safe_guard, Aggregate_SWS;
    public double MRP_AMT;
    public string SCHEME_NOTN_ = "";
    public int INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
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


    // public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }
    public string Country_Origin { get { return _Country_Origin; } set { _Country_Origin = value; } }
    public string Country_Shipment { get { return _Country_Shipment; } set { _Country_Shipment = value; } }
    //ITEM DETAILS
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
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
    public string ADD_EX_RATE { get { return _ADD_EX_RATE; } set { _ADD_EX_RATE = value; } }

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
    public string EXBOND_ADDL_LOAD_HSS { get { return _EXBOND_ADDL_LOAD_HSS; } set { _EXBOND_ADDL_LOAD_HSS = value; } }
    public string EXBOND_MISC_LOAD_RATE { get { return _EXBOND_MISC_LOAD_RATE; } set { _EXBOND_MISC_LOAD_RATE = value; } }


    public string PRODUCT_CVD_NOTN { get { return _PRODUCT_CVD_NOTN; } set { _PRODUCT_CVD_NOTN = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN { get { return _PRODUCT_ADDL_DUTY_NOTN; } set { _PRODUCT_ADDL_DUTY_NOTN = value; } }
    public string PRODUCT_ADDL_DUTY_RATE { get { return _PRODUCT_ADDL_DUTY_RATE; } set { _PRODUCT_ADDL_DUTY_RATE = value; } }

    public string PRODUCT_CETH { get { return _PRODUCT_CETH; } set { _PRODUCT_CETH = value; } }

    public double ASSESABLE_VALUE { get { return _ASSESABLE_VALUE; } set { _ASSESABLE_VALUE = value; } }
    public string ADDTIONAL_DUTY { get { return _ADDTIONAL_DUTY; } set { _ADDTIONAL_DUTY = value; } }
    public string ADDTIONAL_DUTY_RATE { get { return _ADDTIONAL_DUTY_RATE; } set { _ADDTIONAL_DUTY_RATE = value; } }

    //----------------------------------------//
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
    //------------------------------

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
    public double ASSESSABLE_TOTAL { get { return _ASSESSABLE_TOTAL; } set { _ASSESSABLE_TOTAL = value; } }
    public double ITEM_TOTAL { get { return _ITEM_TOTAL; } set { _ITEM_TOTAL = value; } }
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
    #endregion

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet ds_item = new DataSet();
    DataSet ds_bind = new DataSet();
    adminmaster adm_Mas = new adminmaster();
    Imp_Checklist IC = new Imp_Checklist();
    DataSet dt_All_Rates = new DataSet();

    CheckList chklist = new CheckList();
    string JobNo = "", Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH, currentbranch;

    double less_INDIVITUAL_ASSESSABLE_AMOUNT = 0.00;

    public string _IGST_LEVY_TOTAL, _IGST_LEVY_TOTAL_DEBIT, _IGST_LEVY_COMPENSATION_CESS_TOTAL
                ,_IGST_LEVY_NOTN, _IGST_LEVY_SLNO, _IGST_LEVY_RATE, _IGST_LEVY_RATE_UPDATE, _IGST_LEVY_EXCEPTION_NOTN, _IGST_LEVY_EXCEPTION_SLNO, _IGST_LEVY_EXCEPTION_RATE, _IGST_LEVY_COMPENSATION_CESS_NOTN, _IGST_LEVY_COMPENSATION_CESS_SLNO
                ,_IGST_LEVY_COMPENSATION_CESS_RATE, _IGST_LEVY_COMPENSATION_CESS_RATE_UPDATE, _IGST_LEVY_EXCEPTION_CC_NOTN, _IGST_LEVY_EXCEPTION_CC_SLNO, _IGST_LEVY_EXCEPTION_CC_RATE
                , _LEVY_EXCEMPTION_NOTN_TYPE, _LEVY_EXCEPTION_CC_NOTN_TYPE, _SOCIAL_WELFARE_NOTN, _SOCIAL_WELFARE_NOTN_SLNO, _SOCIAL_WELFARE_RATE, _NOTIFICATION_EXCISE_BCD_SPL,
                _CTH_SPL_UNIT, _ENTRY_DEBIT_DUTY, D_AMOUNT, M_AMOUNT, N_AMOUNT;
    public string _TOTAL_SOCIAL_WELFARE,LICENSE_ID,_CETH_SIA_I_RATE;
    public string NOTIFICATION_EXCISE_BCD_SPL { get { return _NOTIFICATION_EXCISE_BCD_SPL; } set { _NOTIFICATION_EXCISE_BCD_SPL = value; } }
    DateTime IGMDate, compareDate_IGM;

    public string IGST_LEVY_TOTAL { get { return _IGST_LEVY_TOTAL; } set { _IGST_LEVY_TOTAL = value; } }
    public string IGST_LEVY_TOTAL_DEBIT { get { return _IGST_LEVY_TOTAL_DEBIT; } set { _IGST_LEVY_TOTAL_DEBIT = value; } }
    public string IGST_LEVY_COMPENSATION_CESS_TOTAL { get { return _IGST_LEVY_COMPENSATION_CESS_TOTAL; } set { _IGST_LEVY_COMPENSATION_CESS_TOTAL = value; } }
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

    public string SOCIAL_WELFARE_NOTN { get { return _SOCIAL_WELFARE_NOTN; } set { _SOCIAL_WELFARE_NOTN = value; } }
    public string SOCIAL_WELFARE_NOTN_SLNO { get { return _SOCIAL_WELFARE_NOTN_SLNO; } set { _SOCIAL_WELFARE_NOTN_SLNO = value; } }
    public string SOCIAL_WELFARE_RATE { get { return _SOCIAL_WELFARE_RATE; } set { _SOCIAL_WELFARE_RATE = value; } }
    public string TOTAL_SOCIAL_WELFARE { get { return _TOTAL_SOCIAL_WELFARE; } set { _TOTAL_SOCIAL_WELFARE = value; } }
    public string CTH_SPL_UNIT { get { return _CTH_SPL_UNIT; } set { _CTH_SPL_UNIT = value; } }
    public string CETH_SIA_I_RATE { get { return _CETH_SIA_I_RATE; } set { _CETH_SIA_I_RATE = value; } }

    Double DEBIT_AMT = 0.0, DEBIT_QTY = 0.0, SUM_DEBIT_QTY = 0.0, INDI_DEBIT_QTY = 0.0, DEBIT_DUTY = 0.0, SUM_ENTRY_DEBIT_DUTY = 0.0;
    public double merit_social_welfare_cess, social_welfare, SOCIAL_welf_Rate, Customs_Social_welfare, Healthcess_RateVal;
    

    public double _TOTAL_CUSTOMS_DUTY = 0.0, _TOTAL_IGST_DUTY = 0.0;
    double IGST_LEV_1_AMT = 0.00, IGST_LEV_2_Excemption = 0.00, IGST_LEV_1_COMPENSATION_AMT = 0.00, IGST_LEV_2_COMPENSATION_AMT = 0.00, AIDC_Amt = 0.00;

    public double TOTAL_CUSTOMS_DUTY { get { return _TOTAL_CUSTOMS_DUTY; } set { _TOTAL_CUSTOMS_DUTY = value; } }
    public double TOTAL_IGST_DUTY { get { return _TOTAL_IGST_DUTY; } set { _TOTAL_IGST_DUTY = value; } }
    public string ENTRY_DEBIT_DUTY { get { return _ENTRY_DEBIT_DUTY; } set { _ENTRY_DEBIT_DUTY = value; } }

    public string NOTIFICATION_FLAG = "", PRODUCT_CETH_CHAPTER = "", IGST_NOTIFICATION_FLAG = "", CETH_CATEGORY = "";

    public string _CTH_NCD_SPL_DUTY, _CTH_NCD_SPL_UNIT, _CTH_FLAG, _CETH_NCD_RATE = "", _CETH_NCD_SPL_DUTY = "", _CETH_NCD_SPL_UNIT = "", _CETH_FLAG = "";

    public string CTH_NCD_SPL_DUTY { get { return _CTH_NCD_SPL_DUTY; } set { _CTH_NCD_SPL_DUTY = value; } }
    public string CTH_NCD_SPL_UNIT { get { return _CTH_NCD_SPL_UNIT; } set { _CTH_NCD_SPL_UNIT = value; } }
    public string CTH_FLAG { get { return _CTH_FLAG; } set { _CTH_FLAG = value; } }
    public string CETH_NCD_RATE { get { return _CETH_NCD_RATE; } set { _CETH_NCD_RATE = value; } }
    public string CETH_NCD_SPL_DUTY { get { return _CETH_NCD_SPL_DUTY; } set { _CETH_NCD_SPL_DUTY = value; } }
    public string CETH_NCD_SPL_UNIT { get { return _CETH_NCD_SPL_UNIT; } set { _CETH_NCD_SPL_UNIT = value; } }
    public string CETH_FLAG { get { return _CETH_FLAG; } set { _CETH_FLAG = value; } }

    public string _INV_MISC_T_F, _INV_MISC_CURRENCY, _INV_MISC_EXRATE, _INV_MISC_CHARGES, _INV_MISC_TOTAL_CHARGES, _INV_MISC_ADD_FRT_INS_YN
     , _PRODUCT_ADDL_HEALTH_CESS_NOTN, _PRODUCT_ADDL_HEALTH_CESS_SLNO, _PRODUCT_ADDL_HEALTH_CESS_RATE, _PRODUCT_ADDL_HEALTH_CESS_SPL, _PRODUCT_ADDL_HEALTH_CESS_TYPE, _PRODUCT_ADDL_HEALTH_CESS_UNIT;

    public string _HEALTH_CESS_CTH_CODE, _HEALTH_CESS_RATE, _HEALTH_CESS_SQC, _HEALTH_CESS_TOTAL, _AIDC_NOTN, _AIDC_NOTN_SLNO, _AIDC_RATE, _AIDC_TOTAL;

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

    public string AIDC_NOTN { get { return _AIDC_NOTN; } set { _AIDC_NOTN = value; } }
    public string AIDC_NOTN_SLNO { get { return _AIDC_NOTN_SLNO; } set { _AIDC_NOTN_SLNO = value; } }
    public string AIDC_RATE { get { return _AIDC_RATE; } set { _AIDC_RATE = value; } }
    public string AIDC_TOTAL { get { return _AIDC_TOTAL; } set { _AIDC_TOTAL = value; } }

    public string PRODUCT_ADDL_HEALTH_CESS_NOTN { get { return _PRODUCT_ADDL_HEALTH_CESS_NOTN; } set { _PRODUCT_ADDL_HEALTH_CESS_NOTN = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_SLNO { get { return _PRODUCT_ADDL_HEALTH_CESS_SLNO; } set { _PRODUCT_ADDL_HEALTH_CESS_SLNO = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_RATE { get { return _PRODUCT_ADDL_HEALTH_CESS_RATE; } set { _PRODUCT_ADDL_HEALTH_CESS_RATE = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_SPL { get { return _PRODUCT_ADDL_HEALTH_CESS_SPL; } set { _PRODUCT_ADDL_HEALTH_CESS_SPL = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_TYPE { get { return _PRODUCT_ADDL_HEALTH_CESS_TYPE; } set { _PRODUCT_ADDL_HEALTH_CESS_TYPE = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_UNIT { get { return _PRODUCT_ADDL_HEALTH_CESS_UNIT; } set { _PRODUCT_ADDL_HEALTH_CESS_UNIT = value; } }

    string CETH_SIA_I_amt1 = "";
    double CETH_SIA_I_amt = 0.00;
    double CVD_SPL_AMT = 0.00;

    double Scheme_Notn_BCD_Rate = 0.00;
    double Scheme_Notn_BCD_Amt = 0.00;
    double AIDC_Split_Rate = 0.00;
    double AIDC_Split_Amt = 0.00;
    double Actual_BASIC_DUTY = 0.00;
    double bcd_sapta_rate_Less_Value = 0.00;
    double Scheme_Notn_SWS_Amt = 0.00;
    int sum = 0;
    string INV_TOTAL_ITEM_AMOUNT = "";
    double TOTAL_ITEM_INVOICE_VALUE = 0.00;
    double SCHEME_AIDC_Rate = 0.00;

    public void Page_Load_Item_Details(string INVOICE_SLNO, string ITEM_SLNO, string Debit_Qty, string EntryMode)
    {
        JobNo = HttpContext.Current.Session["IMPORT_JOBNO"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        currentbranch =HttpContext.Current.Session["currentbranch"].ToString();
         // commented for areawise implementation on 05-mar-2020
     
        SELECT_BRANCH = Connection.Current_Branch();

        HttpContext.Current.Session["INDIVITUAL_CIF_AMOUNT"] = "";
        HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = "";

        //DataSet dsI = new DataSet();
        //dsI.Clear();
        //dsI = IC.GetData(JobNo, "", "INVOICE_LICENSE_RE_IMP");

        //Get_ITEM_Details_new(JobNo, dsI.Tables[0], dsI.Tables[1], dsI.Tables[2]);

        Transact.JOBNO = JobNo;
        Transact.INVOICE_SLNO = INVOICE_SLNO;
        Transact.ITEM_SLNO = ITEM_SLNO;
        Transact.LICENSE_ITEM_NO = "";
        Transact.Ename = "ITEM_WISE_CALCULATION";
        Transact.BRANCH_CODE = SELECT_BRANCH;
        Transact.WORKING_PERIOD = SELECT_BRANCH;

        ds = Transact.RetrieveAll_License_Details_ITEM_WISE();

        Get_ITEM_Details_new(JobNo, ds.Tables[0], ds.Tables[1], ds.Tables[2], ds.Tables[3], ds.Tables[4], Debit_Qty, EntryMode);

    }

    //public void Get_ITEM_Details_new(string ddlJobNo, DataTable ds, DataTable ds3, DataTable dt_ReImport)
    public void Get_ITEM_Details_new(string ddlJobNo, DataTable ds, DataTable dss, DataTable ds3, DataTable dt_ReImport, DataTable ds_Gen, string Debit_Qty, string EntryMode)
    {
        Transaction Transact = new Transaction();
        DataTable dt_error = new DataTable();
        DataTable ds_RE_IMPORT = new DataTable();

        dt_error.Columns.Add("NOTN_NO");
        dt_error.Columns.Add("NOTN_SLNO");
        dt_error.Columns.Add("INVOICE_SLNO");
        dt_error.Columns.Add("ITEM_SLNO");

        TRANSPORT_MODE = HttpContext.Current.Session["TRANSPORT_MODE"].ToString();

        CHECK_FREIGHT_EXRATE = 20;
        int b = 0, C = 0;

        double TOTAL_ITEM = 0.0;
        string curINVOICE_SLNO = "0";
        string entry_type = "";
        while (ds.Rows.Count > C)
        {
            NUMBERTOWORDS = "";
            curINVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
            INVOICE_VALUE = Return_Zero_Value1(ds.Rows[C]["INVOICE_VALUE"].ToString());
            INVOICE_CURRENCY = Return_Zero_Value1(ds.Rows[C]["INVOICE_CURRENCY"].ToString());

            BE_TYPE = ds_Gen.Rows[0]["BE_TYPE"].ToString();
            EXBOND_ADDL_LOAD_HSS = ds_Gen.Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString();
            EXBOND_MISC_LOAD_RATE = ds_Gen.Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString();

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
            SVB_ASSESABLE_STATUS = Return_Zero_Value(ds.Rows[C]["SVB_ASSESABLE_STATUS"].ToString());
            SVB_LOADING_ON = ds.Rows[C]["SVB_LOADING_ON"].ToString();

            MIS_EXRATE = Return_ExRate_Value(ds.Rows[C]["MIS_CURRENCY"].ToString(), ds.Rows[C]["MIS_EXRATE"].ToString());
            MIS_RATE = Return_Zero_Value(ds.Rows[C]["MIS_RATE"].ToString());
            MIS_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_CHARGES"].ToString());
            MIS_CURRENCY = Return_Zero_Value(ds.Rows[C]["MIS_CURRENCY"].ToString());

            INV_MISC_T_F = Return_Zero_Value(ds.Rows[C]["INV_MISC_T_F"].ToString());
            INV_MISC_CURRENCY = Return_Zero_Value(ds.Rows[C]["INV_MISC_CURRENCY"].ToString());
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
            MIS_DISCOUNT_RATE = Return_Zero_Value(ds.Rows[C]["MIS_DISCOUNT_RATE"].ToString());
            MIS_DISCOUNT_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_DISCOUNT_CHARGES"].ToString());
            MIS_DISCOUNT_CURRENCY = ds.Rows[C]["MIS_DISCOUNT_CURRENCY"].ToString();
            MIS_DISCOUNT_EXRATE = Return_ExRate_Value(MIS_DISCOUNT_CURRENCY, ds.Rows[C]["MIS_DISCOUNT_EXRATE"].ToString());

            string MIS_Dscount_RATE = MIS_DISCOUNT_RATE.Substring(0, 1);

            REVENUEDEPOSIT_RATE = ds.Rows[C]["REVENUEDEPOSIT_RATE"].ToString();
            REVENUEDEPOSIT_ON = ds.Rows[C]["REVENUEDEPOSIT_ON"].ToString();


            //DataSet dss = new DataSet();
            //dss.Clear();
            //dss = IC.GetData(ddlJobNo, curINVOICE_SLNO, "ITEM");

            //ITEM_TOTAL = 0;

            //DataSet dss = new DataSet();
            //dss.Tables.Add(dss_ITEM);

            sum = 0;
            TOTAL_ITEM_INVOICE_VALUE = 0.00;

            //Get ITEM_TOTAL_AMOUNT for Split Individual FRT,INS Instead of INVOICE_VALUE - for FOC Items-- Implemented for Common - Sugg.by Bala sir on 14-03-2025
            //if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "2787" || COMPANY_ID == "2907")
            //{
            while (dss.Rows.Count > sum)
            {
                INV_TOTAL_ITEM_AMOUNT = dss.Rows[sum]["ITEM_TOTAL_AMOUNT"].ToString();
                TOTAL_ITEM_INVOICE_VALUE = TOTAL_ITEM_INVOICE_VALUE + Convert.ToDouble(INV_TOTAL_ITEM_AMOUNT);
                sum++;
            }
            //}


            GET_ALL_NOTIFICATIONS_RATE(dss);

            while (dss.Rows.Count > b)
            {
                SCHED11_TOTAL = "0.00";
                IGST_LEVY_TOTAL = "0.00";
                IGST_LEVY_COMPENSATION_CESS_TOTAL = "0.00";

                INVOICE_NO_ITEM = dss.Rows[b]["INVOICE_NO"].ToString();
                INVOICE_SLNO = Convert.ToInt32(dss.Rows[b]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dss.Rows[b]["ITEM_SLNO"].ToString();
                //ITEM_DESCRIPTION = dss.Rows[b]["ITEM_DESCRIPTION"].ToString();              

                if (EntryMode == "License_edit_Qty")
                {
                    ITEM_QTY = Debit_Qty;
                }
                else
                {
                    ITEM_QTY = dss.Rows[b]["ITEM_QTY"].ToString();
                }
                ITEM_QTY_CODE = dss.Rows[b]["ITEM_QTY_CODE"].ToString();
                ITEM_UNIT_PRICE = dss.Rows[b]["ITEM_UNIT_PRICE"].ToString();
                CTH_NO = dss.Rows[b]["CTH_NO"].ToString();
                PRODUCT_RITC = dss.Rows[b]["PRODUCT_RITC"].ToString();
                PRODUCT_CTH = dss.Rows[b]["PRODUCT_CTH"].ToString();
                PRODUCT_CVD_RATE = dss.Rows[b]["PRODUCT_CVD_RATE"].ToString();
                PRODUCT_EDU_CESS_RATE = dss.Rows[b]["PRODUCT_EDU_CESS_RATE"].ToString();

                PRODUCT_SEC_EDU_CESS_RATE = dss.Rows[b]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();
                PRODUCT_SEC_EDU_CESS_NOTN = dss.Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();

                PRODUCT_SEC_EDU_CESS_NOTN_SLNO = dss.Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();

                PRODUCT_BCD_RATE = dss.Rows[b]["PRODUCT_BCD_RATE"].ToString();
                PRODUCT_CETH = dss.Rows[b]["PRODUCT_CETH"].ToString();
                PRODUCT_BCD_NOTN = dss.Rows[b]["PRODUCT_BCD_NOTN"].ToString();
                PRODUCT_BCD_NOTN_SLNO = dss.Rows[b]["PRODUCT_BCD_SLNO"].ToString();

                PRODUCT_BCD_SPL = dss.Rows[b]["PRODUCT_BCD_SPL"].ToString();

                PRODUCT_CVD_NOTN = dss.Rows[b]["PRODUCT_CVD_NOTN"].ToString();
                PRODUCT_CVD_NOTN_SLNO = dss.Rows[b]["PRODUCT_CVD_SLNO"].ToString();

                PRODUCT_CVD_SPL = dss.Rows[b]["PRODUCT_CVD_SPL"].ToString();

                PRODUCT_EDU_CESS_NOTN = dss.Rows[b]["PRODUCT_EDU_CESS_NOTN"].ToString();
                PRODUCT_EDU_CESS_NOTN_SLNO = dss.Rows[b]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                PRODUCT_ADDL_DUTY_NOTN = dss.Rows[b]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN.Trim();
                PRODUCT_ADDL_DUTY_NOTN_SLNO = dss.Rows[b]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
                PRODUCT_ADDL_DUTY_RATE = dss.Rows[b]["PRODUCT_ADDL_DUTY_RATE"].ToString();

                //----------------------------------------------------//
                PRODUCT_ADDL_SHEII_NOTN = dss.Rows[b]["PRODUCT_ADDL_SHEII_NOTN"].ToString();
                PRODUCT_ADDL_SHEII_SLNO = dss.Rows[b]["PRODUCT_ADDL_SHEII_SLNO"].ToString();
                PRODUCT_ADDL_SHEII_RATE = dss.Rows[b]["PRODUCT_ADDL_SHEII_RATE"].ToString();
                //----------------------------------------------------//

                //----------------------------------------------------//
                PRODUCT_ADDL_TTA_NOTN = dss.Rows[b]["PRODUCT_ADDL_TTA_NOTN"].ToString();
                PRODUCT_ADDL_TTA_SLNO = dss.Rows[b]["PRODUCT_ADDL_TTA_SLNO"].ToString();
                PRODUCT_ADDL_TTA_RATE = dss.Rows[b]["PRODUCT_ADDL_TTA_RATE"].ToString();
                //----------------------------------------------------//

                PRODUCT_ADDL_GSI_NOTN = dss.Rows[b]["PRODUCT_ADDL_GSI_NOTN"].ToString();
                PRODUCT_ADDL_GSI_SLNO = dss.Rows[b]["PRODUCT_ADDL_GSI_SLNO"].ToString();
                PRODUCT_ADDL_GSI_RATE = dss.Rows[b]["PRODUCT_ADDL_GSI_RATE"].ToString();

                //----------------------------------------------------//

                PRODUCT_CVD_EDU_CESS_RATE = dss.Rows[b]["PRODUCT_CVD_EDU_CESS_RATE"].ToString();

                PRODUCT_CVD_SEC_EDU_CESS_RATE = dss.Rows[b]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString();
                CETH_CVD_EDU_CESS_SL = dss.Rows[b]["CETH_CVD_EDU_CESS_SL"].ToString();
                CETH_CVD_EDU_CESS_RATE = dss.Rows[b]["CETH_CVD_EDU_CESS_RATE"].ToString();
                CETH_CVD_SEC_EDU_CESS_SL = dss.Rows[b]["CETH_CVD_SEC_EDU_CESS_SL"].ToString();
                CETH_CVD_SEC_EDU_CESS_RATE = dss.Rows[b]["CETH_CVD_SEC_EDU_CESS_RATE"].ToString();

                //---------------------NCD-------------------------------//

                PRODUCT_NCD_NOTN = dss.Rows[b]["PRODUCT_NCD_NOTN"].ToString();
                PRODUCT_NCD_SLNO = dss.Rows[b]["PRODUCT_NCD_SLNO"].ToString();
                PRODUCT_NCD_RATE = dss.Rows[b]["PRODUCT_NCD_RATE"].ToString();
                //PRODUCT_NCD_SPL = dss.Rows[b]["PRODUCT_NCD_SPL"].ToString();
                //PRODUCT_NCD_UNIT = dss.Rows[b]["PRODUCT_NCD_UNIT"].ToString();
                //PRODUCT_NCD_SPL_TYPE = dss.Rows[b]["PRODUCT_NCD_SPL_TYPE"].ToString();

                //--------------------END NCD----------------------------//

                //---------------------TARIFF-------------------------------//

                PRODUCT_TARIFF_NOTN = dss.Rows[b]["PRODUCT_TARIFF_NOTN"].ToString();
                PRODUCT_TARIFF_SLNO = dss.Rows[b]["PRODUCT_TARIFF_SLNO"].ToString();
                PRODUCT_TARIFF_QTY = dss.Rows[b]["PRODUCT_TARIFF_QTY"].ToString();
                PRODUCT_TARIFF_AMOUNT = dss.Rows[b]["PRODUCT_TARIFF_AMOUNT"].ToString();
                PRODUCT_TARIFF_AMOUNT_UNIT = dss.Rows[b]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString();

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

                PRODUCT_SAPTA_NOTN = dss.Rows[b]["PRODUCT_SAPTA_NOTN"].ToString();
                PRODUCT_SAPTA_SLNO = dss.Rows[b]["PRODUCT_SAPTA_SLNO"].ToString();
                PRODUCT_SAPTA_RATE = dss.Rows[b]["PRODUCT_SAPTA_RATE"].ToString();

                //--------------------END SAPTA----------------------------//

                PRODUCT_SAFEGUARD_NOTN = dss.Rows[b]["PRODUCT_SAFEGUARD_NOTN"].ToString();
                PRODUCT_SAFEGUARD_SLNO = dss.Rows[b]["PRODUCT_SAFEGUARD_SLNO"].ToString();
                PRODUCT_SAFEGUARD_RATE = dss.Rows[b]["PRODUCT_SAFEGUARD_RATE"].ToString();

                PRODUCT_AGGREGATE_DUTY_NOTN = dss.Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
                PRODUCT_AGGREGATE_DUTY_NOTN_SL = dss.Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
                PRODUCT_AGGREGATE_DUTY_NOTN_RATE = dss.Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString();


                PRODUCT_MRP_YN = dss.Rows[b]["PRODUCT_MRP_YN"].ToString();

                ITEM_DESCRIPTION = dss.Rows[b]["ITEM_DESCRIPTION"].ToString();

                PRODUCT_MRP_SL_NO = dss.Rows[b]["PRODUCT_MRP_SL_NO"].ToString();
                PRODUCT_MRP_AMOUNT = dss.Rows[b]["PRODUCT_MRP_AMOUNT"].ToString();
                PRODUCT_MRP_ABT_RATE = dss.Rows[b]["PRODUCT_MRP_ABT_RATE"].ToString();

                RSP_APPLICABLE = dss.Rows[b]["RSP_APPLICABLE"].ToString();


                //------------Start Other CVD Duty 02June2015-------------------//

                PRODUCT_OTHER_DUTY_NOTN = dss.Rows[b]["PRODUCT_OTHER_DUTY_NOTN"].ToString();
                PRODUCT_OTHER_DUTY_SLNO = dss.Rows[b]["PRODUCT_OTHER_DUTY_SLNO"].ToString();
                PRODUCT_OTHER_DUTY_RATE = dss.Rows[b]["PRODUCT_OTHER_DUTY_RATE"].ToString();
                PRODUCT_OTHER_DUTY_SPL = dss.Rows[b]["PRODUCT_OTHER_DUTY_SPL"].ToString();
                PRODUCT_OTHER_DUTY_UNIT = dss.Rows[b]["PRODUCT_OTHER_DUTY_UNIT"].ToString();
                PRODUCT_OTHER_DUTY_TYPE = dss.Rows[b]["PRODUCT_OTHER_DUTY_TYPE"].ToString();

                //--------------End Other CVD Duty 02June2015-------------------//

                //-----------Start Infra Cess 18May2016-----------------//

                ////INFRA_CESS_NOTN = dss.Rows[b]["INFRA_CESS_NOTN"].ToString();
                ////INFRA_CESS_NOTN_SL = dss.Rows[b]["INFRA_CESS_NOTN_SL"].ToString();
                ////INFRA_CESS_NOTN_RATE = dss.Rows[b]["INFRA_CESS_NOTN_RATE"].ToString();

                //-----------End Infra Cess 18May2016-----------------//

                //------------ITEMWISE SVB DETAILS FOR NIPPON EXPRESS ON 29FEB2016-------------------//

                ITEM_SVB_RELATION = dss.Rows[b]["SVB_RELATION"].ToString();
                ITEM_SVB_REF_NO = dss.Rows[b]["SVB_REF_NO"].ToString();
                ITEM_SVB_REF_DATE = dss.Rows[b]["SVB_REF_DATE"].ToString();
                ITEM_SVB_CUSTOM_HOUSE = dss.Rows[b]["SVB_CUSTOM_HOUSE"].ToString();
                ITEM_SVB_LOADING_ON = dss.Rows[b]["SVB_LOADING_ON"].ToString();
                ITEM_SVB_ASSESABLE_RATE = dss.Rows[b]["SVB_ASSESABLE_RATE"].ToString();

                ITEM_SVB_DUTY_RATE = dss.Rows[b]["SVB_DUTY_RATE"].ToString();
                ITEM_SVB_ASSESABLE_STATUS = dss.Rows[b]["SVB_ASSESABLE_STATUS"].ToString();

                ITEM_SVB_DUTY_STATUS = dss.Rows[b]["SVB_DUTY_STATUS"].ToString();

                //--------------ITEMWISE SVB DETAILS FOR NIPPON EXPRESS ON 29FEB2016-------------------//           


                //------------GST  IMPLEMENTATION ON 30JUNE2017-------------------//

                IGST_LEVY_NOTN = dss.Rows[b]["IGST_LEVY_NOTN"].ToString();
                IGST_LEVY_SLNO = dss.Rows[b]["IGST_LEVY_SLNO"].ToString();
                IGST_LEVY_RATE = dss.Rows[b]["IGST_LEVY_RATE"].ToString() == "" ? "0" : dss.Rows[b]["IGST_LEVY_RATE"].ToString();

                IGST_LEVY_EXCEPTION_NOTN = dss.Rows[b]["IGST_LEVY_EXCEPTION_NOTN"].ToString();
                IGST_LEVY_EXCEPTION_SLNO = dss.Rows[b]["IGST_LEVY_EXCEPTION_SLNO"].ToString();
                IGST_LEVY_EXCEPTION_RATE = dss.Rows[b]["IGST_LEVY_EXCEPTION_RATE"].ToString();
                IGST_LEVY_COMPENSATION_CESS_NOTN = dss.Rows[b]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString();
                IGST_LEVY_COMPENSATION_CESS_SLNO = dss.Rows[b]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString();
                IGST_LEVY_COMPENSATION_CESS_RATE = dss.Rows[b]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString();
                IGST_LEVY_EXCEPTION_CC_NOTN = dss.Rows[b]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString();
                IGST_LEVY_EXCEPTION_CC_SLNO = dss.Rows[b]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString();
                IGST_LEVY_EXCEPTION_CC_RATE = dss.Rows[b]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString();

                LEVY_EXCEMPTION_NOTN_TYPE = dss.Rows[b]["LEVY_EXCEMPTION_NOTN_TYPE"].ToString();
                LEVY_EXCEPTION_CC_NOTN_TYPE = dss.Rows[b]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString();

                SOCIAL_WELFARE_NOTN = dss.Rows[b]["SOCIAL_WELFARE_NOTN"].ToString();
                SOCIAL_WELFARE_NOTN_SLNO = dss.Rows[b]["SOCIAL_WELFARE_NOTN_SLNO"].ToString();
                SOCIAL_WELFARE_RATE = dss.Rows[b]["SOCIAL_WELFARE_RATE"].ToString();

                AIDC_NOTN = dss.Rows[b]["AIDC_NOTN"].ToString();
                AIDC_NOTN_SLNO = dss.Rows[b]["AIDC_NOTN_SLNO"].ToString();
                AIDC_RATE = dss.Rows[b]["AIDC_RATE"].ToString();
                //--------------GST  IMPLEMENTATION ON 30JUNE2017-------------------//                              

                //------------------- HEALTH CESS -------------------------------------//

                PRODUCT_ADDL_HEALTH_CESS_NOTN = dss.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_SLNO = dss.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_RATE = dss.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_SPL = dss.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_TYPE = dss.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_UNIT = dss.Rows[b]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString();


                PRODUCT_BCD_RATE_UPDATE = "";
                PRODUCT_CVD_RATE_UPDATE = "";


                SCHEME_CODE = dss.Rows[b]["SCHEME_CODE"].ToString();
                SCHEME_NOTN = dss.Rows[b]["SCHEME_NOTN"].ToString();
                SCHEME_NOTN_SLNO = dss.Rows[b]["SCHEME_NOTN_SLNO"].ToString();

                CTH_QTY1 = dss.Rows[b]["CTH_QTY1"].ToString();
                CTH_QTY1_CODE = dss.Rows[b]["CTH_QTY1_CODE"].ToString();

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
                ASSESABLE_VALUE = Get_Indivitual_Assesable_Value(dt_ReImport, INVOICE_SLNO, INVOICE_NO_ITEM, ITEM_SLNO, TOTAL_ITEM_INVOICE_VALUE);

                //--------------------- 5-Nov-2015  ---------------------//

                // --------------------------------------- Anti-Dumping Calculation-------------------------------------------------------

                ANTI_DUMPING_NOTN = dss.Rows[b]["ANTI_DUMPING_NOTN"].ToString();
                ANTI_DUMPING_NOTN_SLNO = dss.Rows[b]["ANTI_DUMPING_NOTN_SLNO"].ToString();
                CTH_SLNO = dss.Rows[b]["CTH_SLNO"].ToString();
                CTH_SUPPLIER_SLNO = dss.Rows[b]["CTH_SUPPLIER_SLNO"].ToString();
                CTH_QTY = dss.Rows[b]["CTH_QTY"].ToString();
                ADD_EX_RATE = dss.Rows[b]["ADD_EX_RATE"].ToString();

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
                                HEALTH_CESS_RATE = dt_HEALTH_CTH.Rows[0]["HEALTH_CESS_RATE"].ToString();
                                HEALTH_CESS_SQC = dt_HEALTH_CTH.Rows[0]["CTH_SQC"].ToString();

                                PRODUCT_ADDL_HEALTH_CESS_RATE = HEALTH_CESS_RATE;
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
                                    //AIDC_AMT_UPDATE = DT_AIDC_RATES.Rows[0]["AIDC_NOTN_RATE"].ToString();
                                }
                                else
                                {
                                    //error table here
                                    dt_error.Rows.Add(AIDC_NOTN, AIDC_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
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
                                    //AIDC_AMT_UPDATE = DT_AIDC_RATES.Rows[0]["AIDC_NOTN_RATE"].ToString();
                                }
                                else
                                {
                                    //error table here
                                    AIDC_RATE = "0";
                                    dt_error.Rows.Add(AIDC_NOTN, AIDC_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
                                }
                            }
                        }
                    }
                    else
                    {
                        AIDC_RATE = "";
                        //AIDC_AMT_UPDATE = "";
                    }

                    /* hide on 15-04-2021 - for Duty mismatch issue
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
                                }
                                else if (NOTIFICATION_CUSTOMS_BCD_SPL != "-1.000000" || NOTIFICATION_CUSTOMS_BCD_SPL != "")
                                {
                                    CTH_SPL_AMT = NOTIFICATION_CUSTOMS_BCD_SPL;
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
                            }
                        }
                    }
                    */

                    
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

                                //NOTIFICATION_CUSTOMS_BCD_UNIT = CTH_RateS.Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                            }
                            else
                            {
                                CTH_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_BCD_RATE).ToString("F"));

                                NOTIFICATION_CUSTOMS_BCD_RATE = CTH_RATE;
                                PRODUCT_BCD_RATE_UPDATE = CTH_RATE;
                                PRODUCT_BCD_RATE = CTH_RATE;
                                NOTIFICATION_CUSTOMS_BCD_SPL = PRODUCT_BCD_SPL;
                                //NOTIFICATION_CUSTOMS_BCD_UNIT = PRODUCT_BCD_UNIT;
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
                                   // CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
                                }
                                else if (NOTIFICATION_CUSTOMS_BCD_SPL != "-1.000000" || NOTIFICATION_CUSTOMS_BCD_SPL != "")
                                {
                                    CTH_SPL_AMT = NOTIFICATION_CUSTOMS_BCD_SPL;
                                   // CTH_SPL_UNIT = NOTIFICATION_CUSTOMS_BCD_UNIT;

                                    PRODUCT_BCD_SPL = NOTIFICATION_CUSTOMS_BCD_SPL;
                                   // PRODUCT_BCD_UNIT = NOTIFICATION_CUSTOMS_BCD_UNIT;
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


                    if (PRODUCT_CTH == "71081200" && SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO == "III1")// Gold Bill- should not take Tariff value- Sugg.By Bala sir & KAMAKSHI ENTERPRISES on 11-01-2023
                    {
                    }
                    else
                    {
                       // if (PRODUCT_TARIFF_NOTN.Trim() != "" && PRODUCT_TARIFF_SLNO.Trim() != "") Condition hided by pandiyan on 26/05/2025 sugg by bala 
                        if ((PRODUCT_TARIFF_NOTN.Trim() != "" && PRODUCT_TARIFF_SLNO.Trim() != "") && Connection.COMPANYID() !="314")  //Condition (314) added by pandiyan on 26/05/2025 sugg by bala 
                        {
                            if ((PRODUCT_TARIFF_NOTN.Trim() == "36/2001") && (PRODUCT_TARIFF_SLNO.Trim() == "2(1)A" || PRODUCT_TARIFF_SLNO.Trim() == "2(2)A" || PRODUCT_TARIFF_SLNO.Trim() == "2(1)" || PRODUCT_TARIFF_SLNO.Trim() == "2(2)" || PRODUCT_TARIFF_SLNO.Trim() == "2(3)" || PRODUCT_TARIFF_SLNO.Trim() == "2(4)" || PRODUCT_TARIFF_SLNO.Trim() == "2(4)(i)" || PRODUCT_TARIFF_SLNO.Trim() == "2(4)(ii)"))
                            {
                                if (PRODUCT_TARIFF_AMOUNT != "")
                                {
                                    if (Convert.ToDecimal(PRODUCT_TARIFF_AMOUNT) >= 0)
                                    {
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

                                        HttpContext.Current.Session["INDIVITUAL_CIF_AMOUNT"] = Math.Round(Convert.ToDouble(ASSESABLE_VALUE), 2);
                                    }
                                }
                            }
                            else if ((PRODUCT_TARIFF_NOTN.Trim() == "36/2001") && (PRODUCT_TARIFF_SLNO.Trim() == "5" ))//Newly added on 18-02-2025 sugg.by Bala - Its only for License Page Calc not a checklist
                            {
                                ASSESABLE_VALUE = ASSESSABLE_TOTAL + INDIVITUAL_INVOICE_VALUE + Convert.ToDouble(INDIVITUAL_FREIGHT_AMOUNT) + Convert.ToDouble(INDIVITUAL_INSURANCE_AMOUNT); 

                                ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE;
                                HttpContext.Current.Session["INDIVITUAL_CIF_AMOUNT"] = Math.Round(Convert.ToDouble(ASSESABLE_VALUE), 2); 
                            }
                            else
                            {
                                if (PRODUCT_TARIFF_AMOUNT != "")
                                {
                                    if (Convert.ToDecimal(PRODUCT_TARIFF_AMOUNT) >= 0)
                                    {
                                        tariff_amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_TARIFF_AMOUNT) * Convert.ToDouble(inv_exrate);
                                        ASSESABLE_VALUE = tariff_amt;
                                        //ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE; -- this line hide by Chithra for SAAbari log sugg by BALA sir on 23-10-2019
                                        //HttpContext.Current.Session["INDIVITUAL_CIF_AMOUNT"] = ASSESABLE_VALUE;

                                        if (SCHEME_CODE == "36" || SCHEME_CODE == "37")
                                        {
                                            ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + INDIVITUAL_INVOICE_VALUE + Convert.ToDouble(INDIVITUAL_FREIGHT_AMOUNT) + Convert.ToDouble(INDIVITUAL_INSURANCE_AMOUNT);
                                            HttpContext.Current.Session["INDIVITUAL_CIF_AMOUNT"] = INDIVITUAL_INVOICE_VALUE + Convert.ToDouble(INDIVITUAL_FREIGHT_AMOUNT) + Convert.ToDouble(INDIVITUAL_INSURANCE_AMOUNT);
                                        }
                                        else
                                        {
                                            ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE;
                                            HttpContext.Current.Session["INDIVITUAL_CIF_AMOUNT"] = Math.Round(Convert.ToDouble(ASSESABLE_VALUE), 2); 
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE;
                        }
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

                            CETH_NCD_RATE = CETH_RateS.Rows[0]["CETH_NCD_RATE"].ToString();
                            CETH_NCD_SPL_DUTY = CETH_RateS.Rows[0]["CETH_NCD_SPL_DUTY"].ToString();
                            CETH_NCD_SPL_UNIT = CETH_RateS.Rows[0]["CETH_NCD_SPL_UNIT"].ToString();
                            CETH_FLAG = CETH_RateS.Rows[0]["CETH_FLAG"].ToString();
                            CETH_SIA_I_RATE = CETH_RateS.Rows[0]["CETH_SIA_I_RATE"].ToString();
                            CETH_CATEGORY = CETH_RateS.Rows[0]["CETH_CATEGOTY"].ToString();
                            //CETH_IGST_YN = CETH_RateS.Rows[0]["IGST_YN"].ToString();
                            //CETH_ADDL_DUTY_IMPORTS_YN = CETH_RateS.Rows[0]["ADDL_DUTY_IMPORTS_YN"].ToString();
                            //CETH_CVD_NIL_YN = CETH_RateS.Rows[0]["CVD_NIL_YN"].ToString();
                            //CIGARATTE_RITC_YN = CETH_RateS.Rows[0]["CIGARATTE_RITC_YN"].ToString();
                            //CETH_EXEC_AIDC_RATE = CETH_RateS.Rows[0]["EXEC_AIDC_RATE"].ToString();
                            //EXC_AIDC_RATE = CETH_EXEC_AIDC_RATE;
                        }
                        else
                        {
                            dt_error.Rows.Add(PRODUCT_CETH, "CETH", INVOICE_SLNO, ITEM_SLNO);
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
                    //if ((Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "125") && (PRODUCT_CETH == "24029090" || PRODUCT_CETH == "24022090"))
                    //if ((Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "116" || Connection.COMPANYID() == "125") && (PRODUCT_CETH == "24022090"))
                    if (CETH_CATEGORY == "RITC")
                    {
                        PRODUCT_CETH_CHAPTER = PRODUCT_CETH;
                    }

                    //if (PRODUCT_CETH.Substring(0, 2) == "24")// hide by Chithra on 06-08-2019 for 24,27 Chapter HPCL
                    if (PRODUCT_CETH_CHAPTER != "NOEXCISE")
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
                    }
                    else
                    {
                        PRODUCT_CVD_RATE = "0.00";
                    }

                    //*********************************** END FETCH ALL RATES By Chithra 08-12-2017 *****************************XXXXXX

                    //------------------Start Exclusive for Indev Logistics on 05Feb2016-----------------------------//

                    //if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "196" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "4" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "248")
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
                    string[] arr1 = { "DEPB", "DFRC", "DFCC", "TRG+", "(KRSH)", "DFCS", "DFIA", "FMS", "FPS", "SHIS", "MEIS", "INC", "SEIS", "ROSCTL", "RoDTEP Scheme", "ROSCTL Scheme", "MEIS eCom", "Tariff Quota", "Restricted Items", "Post Export EPCG" };
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
                                        PRODUCT_CETH_CHAPTER = PRODUCT_CETH;
                                    }
                                    //Fairmacs - Cigaratte RITC - ON 12-09-2019 by Chithra
                                    else if ((Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "116" || Connection.COMPANYID() == "125") && (PRODUCT_CETH == "24022090"))
                                    {
                                        Scheme_DUTIABLE_CIGARETTE_Calc(); // Implemented for Fairmacs on 12-09-2019 by Chithra
                                    }
                                    else
                                    {

                                        Scheme_DUTIABLE();
                                        PRODUCT_CETH_CHAPTER = "NOEXCISE";
                                    }
                                }
                            }
                            else if (SCHEME_NOTN_ == "REP" || SCHEME_NOTN_ == "DIL" || SCHEME_NOTN_ == "JBG" || SCHEME_NOTN_ == "EOU")
                            {
                                // REP & DIL & JBG & EOU
                                CALL_GENERAL_SCHEME_SAME_CODE();
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
                        //            CALL_GENERAL_SCHEME_SAME_CODE();
                        //        }
                        //    }
                        //}
                        //***************End Developed on 27June2015 for ONDOT Express*******************//
                        else if (SCHEME_NOTN_ == "EPCG")
                        {
                            //Scheme_EPCG(ds3, adm_Mas);
                            Scheme_EPCG(dss1.Tables[0], adm_Mas);
                        }
                        else if (SCHEME_NOTN_.Trim() == "Restricted Items")
                        {
                            Scheme_14_RestrictedItems();
                        }
                        else if (SCHEME_NOTN_.Trim() == "Post Export EPCG")
                        {
                            Scheme_Post_Export_EPCG(dss1);
                        }
                        else
                        {
                            //MEIS & SEIS

                            if (SCHEME_NOTN_ == value2)
                            {
                                if (dss1.Tables[0].Rows.Count > 0)
                                {
                                    EXCEMPTION = dss1.Tables[0].Rows[0]["EXCEMPTION"].ToString();

                                    if (EXCEMPTION == "Y")
                                    {
                                  
                                        //-----------------Calculation implemented on 28Apr2017 for Paramount---------------//
                                        double bcd_rate1 = 0.00;
                                        double TRQ_rate = 0.00;
                                        //if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III")) hided by pandiyan on 19-06-2025 sugg by bala 
                                        if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "062/2022" || SCHEME_NOTN == "029/2026") && (SCHEME_NOTN_SLNO.Contains("III") || SCHEME_NOTN_SLNO.Contains("IV")))
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
                                                    SCHEME_AIDC_Rate = Convert.ToDouble(dS_SCHEMECODE.Rows[0]["SCHEME_AIDC_RATE"].ToString() == string.Empty ? "0.00" : dS_SCHEMECODE.Rows[0]["SCHEME_AIDC_RATE"].ToString());

                                                    //double SCHEME_Rate1 = Convert.ToDouble(SCHEME_Rate);
                                                    if (SCHEME_Rate == "")
                                                    {
                                                        SCHEME_Rate = "0";
                                                    }
                                                    TRQ_rate = Convert.ToDouble(SCHEME_Rate);
                                                }
                                            }

                                            bcd_rate1 = ASSESABLE_VALUE * TRQ_rate / 100;
                                            Scheme_Notn_BCD_Amt = bcd_rate1;
                                        }
                                        else
                                        {
                                            if (PRODUCT_BCD_RATE != "")
                                            {
                                                bcd_rate1 = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
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

                                                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "145" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "262" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "184" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "223" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "224" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "164" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1026" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1048" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1057")
                                                {
                                                    CTH_SPL_AMT = "0";
                                                }
                                            }
                                        }

                                        //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

                                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                                        {
                                            // CTH_SPL_AMT = "";
                                            BASIC_DUTY = bcd_rate1;
                                        }
                                        else
                                        {
                                            double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                            //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                                            double cth_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);


                                            if (NOTIFICATION_FLAG == "L")// Higher,Lower,Plus - Implentd by Chithra on 02-08-2019
                                            {
                                                if (cth_Amt <= bcd_rate1)
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
                                                        BASIC_DUTY = bcd_rate1;
                                                    }
                                                }
                                            }
                                            else if (NOTIFICATION_FLAG == "+")
                                            {
                                                if (bcd_rate1 >= bcd_Amt)
                                                {
                                                    BASIC_DUTY = cth_Amt + bcd_rate1;
                                                }
                                                else
                                                {
                                                    BASIC_DUTY = cth_Amt + bcd_Amt;
                                                }
                                            }
                                            else //-- NOTIFICATION_FLAG == "H" or others
                                            {
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

                                        }
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

                                        //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
                                        Get_Less_Sapta_Rate();

                                        //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                                        AIDC_Amt = NOTN_AIDC_CALC();

                                        //#SWS
                                        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                       // Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

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

                                        BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                                        SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
                                        AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));

                                        CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CESS), 1).ToString("0.00"));

                                        CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));

                                        //CVD_CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Edu_Cess), 1).ToString("0.00"));
                                        //CVD_CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(cvd_Customs_Higher_Edu_Cess), 1).ToString("0.00"));

                                        NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
                                        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                                        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                                        TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(SOCIAL_welf_Rate), 1).ToString("0.00"));
                                        AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));


                                        //newly added on 28-10-2020
                                        HEALTH_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Healthcess_RateVal), 1).ToString("0.00"));

                                        

                                        //-----------------------CALCULATION FOR TOTAL DEBIT DUTY--------------------------------//
                                        double bcd_rate = 0.00;

                                        if (PRODUCT_BCD_RATE != "")
                                        {
                                            //Start Tariff Ass cal.
                                            if (PRODUCT_TARIFF_AMOUNT != "")// Condition added by Pandiyan (suggested by Bala) on 29-05-2025,When Tariff NTN = "36/2006" and Tariff Amount !="",calculate the Assessable Value as:(Tariff Qty * Tariff Amt * Exchange Rate).This value is used as the Basic Value for License Debit Duty.
                                            {
                                                if (Convert.ToDecimal(PRODUCT_TARIFF_AMOUNT) >= 0)
                                                {
                                                    Auto_Search auto = new Auto_Search();
                                                    DataSet ds_exrate = new DataSet();
                                                    auto.Enamesearch = "USD";//Get USD Exrate from Admin Master
                                                    auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
                                                    ds_exrate = auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                                                    if (ds_exrate.Tables[0].Rows.Count > 0)
                                                    {
                                                        tariff_amt = Convert.ToDouble(PRODUCT_TARIFF_QTY) * Convert.ToDouble(PRODUCT_TARIFF_AMOUNT) * Convert.ToDouble(ds_exrate.Tables[0].Rows[0][0].ToString());
                                                    }

                                                    ASSESABLE_VALUE = tariff_amt;
                                                    ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE;
                                                }
                                            }  //End Tariff Ass cal.
                                            bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
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

                                        if (SCHEME_NOTN_ != "DFIA" && SCHEME_NOTN_ != "DFRC" && SCHEME_NOTN_ != "Tariff Quota")
                                        {
                                            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Customs_Social_welfare, 2).ToString("F"));
                                        }

                                        if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "029/2026") && SCHEME_NOTN_SLNO.Contains("III"))
                                        {
                                            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Customs_Social_welfare, 2).ToString("F"));
                                            Scheme_Notn_SWS_Amt = (Scheme_Notn_BCD_Amt + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }

                                        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "224")
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
                                     * */

                                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                                        {
                                            //CTH_SPL_AMT = "";
                                            BASIC_DUTY = bcd_rate;
                                        }
                                        else
                                        {
                                            double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                            //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                                            double cth_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);

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
                                                double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                                double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                                                bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_BCD_SPL);

                                                /* hide By chithra for implement H,L,+ - above code value again update here.. on 02/08/2019
                                                //if (bcd_rate >= cth_Amt)
                                                //{
                                                //    BASIC_DUTY = bcd_rate;
                                                //}
                                                //else
                                                //{
                                                //    BASIC_DUTY = cth_Amt;
                                                //}
                                                 * */

                                                if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                                                {
                                                    if (bcd_Amt <= bcd_rate)
                                                    {
                                                        BASIC_DUTY = bcd_Amt;
                                                    }
                                                }

                                                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "313")
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

                                        //-----------------------------END NCD CALCULATION---------------------------------------//  

                                        //---------------SAPTA CALCULATION----------------------------//

                                        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

                                        //---------------END SAPTA CALCULATION-------------------------//

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


                                        //if (RSP_APPLICABLE == "Y")RSP condition removed by Chithra

                                        //------------------------------CESS CALCULATION--------------------------------//

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
                                        //---------------------------END CESS CALCULATION--------------------------------//    

                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        CESS = 0.00;
                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
                                       // if (PRODUCT_CETH.Substring(0, 2) != "24")
                                        if (PRODUCT_CETH_CHAPTER == "NOEXCISE")// hide by Chithra on 06-08-2019 for 24,27 Chapter HPCL
                                        {
                                            CVD_TOTAL = "0";
                                            CVD = 0.00;
                                            PRODUCT_CVD_RATE = "0.00";
                                            PRODUCT_CETH = "NOEXCISE";
                                        }
                                        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//


                                        Customs_Edu_Cess = (BASIC_DUTY + CVD + CESS + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;

                                        Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + CESS + Convert.ToDouble(GSI_TOTAL)) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;


                                        //-------HEALTH CESS CALCULATION
                                        HEALTH_CESS_TOTAL = "0.00";
                                        Healthcess_RateVal = 0.00;
                                        if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                                        {
                                            if (HEALTH_CESS_CTH_CODE != "")
                                            {
                                                Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                                            }
                                        }

                                        //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                                        AIDC_Amt = NOTN_AIDC_CALC();

                                        //#SWS
                                          Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

                                        if (SCHEME_NOTN_ != "DFIA" && SCHEME_NOTN_ != "DFRC" && SCHEME_NOTN_ != "Tariff Quota")
                                        {
                                            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Customs_Social_welfare, 2).ToString("F"));
                                        }

                                        if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "029/2026") && SCHEME_NOTN_SLNO.Contains("III"))
                                        {
                                            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Customs_Social_welfare, 2).ToString("F"));
                                            Scheme_Notn_SWS_Amt = (Scheme_Notn_BCD_Amt + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }

                                        ////AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + CESS + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;

                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                                        AddL_DUTY = 0.00;
                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//
                                        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "247" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "10")
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

                                            //this line newly by Chithra on 23-06-2020 sugg by bala sir for PARAMOUNT gowri Anti dupming Amt should add with Customs Duty
                                            TOTAL_ANTI_AMT = MERIT_TOTAL_ANTI_AMT;


                                            //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                                            //hide on 28-11-2020 for Dial Ess-sugg.by Subbu sir & Bala sir done by Chithra
                                            // ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + TOTAL_ANTI_AMT; 

                                            if (SCHEME_NOTN_ == "ROSCTL" || SCHEME_NOTN_ == "MEIS" || SCHEME_NOTN_ == "MEIS eCom")
                                            {
                                                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                                            }
                                            else
                                            {
                                                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + TOTAL_ANTI_AMT;
                                            }
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


                                                    double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
                                                    double Final_Anti_Dump = TOTAL_ANTIDUMP_AMT - Anti_Dump_Cal2;

                                                    TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(Final_Anti_Dump, 2).ToString("F"));
                                                    if (Convert.ToDouble(TOTAL_ANTI_AMT_LICNESE) < 0.00)
                                                        TOTAL_ANTI_AMT_LICNESE = "0.00";

                                                    MERIT_TOTAL_ANTI_AMT = TOTAL_ANTI_AMT_LICNESE;

                                                    //this line newly by Chithra on 29-02-2020 sugg by bala sir for PARAMOUNT Anti dupming with Other Duty calc
                                                    //TOTAL_ANTIDUMP_AMT = Convert.ToDouble(TOTAL_ANTI_AMT_LICNESE);

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

                                            //this line newly by Chithra on 23-06-2020 sugg by bala sir for PARAMOUNT gowri Anti dupming Amt should add with Customs Duty
                                            TOTAL_ANTI_AMT = MERIT_TOTAL_ANTI_AMT;

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


                                            //this line newly by Chithra on 23-06-2020 sugg by bala sir for PARAMOUNT gowri Anti dupming Amt should add with Customs Duty
                                            TOTAL_ANTI_AMT = MERIT_TOTAL_ANTI_AMT;

                                            //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                                            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "      " + CTH_QTY + "      " + " " + ADD_DIFF_CUR + "%" + " " + TOTAL_ANTI_AMT;

                                        }
                                        //------------End Anti-Dumping Calculation implemented on 06Oct2018------------//


                                        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
                                        Call_IGST_General();

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
                                        //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD + CESS).ToString("0.00"));

                                        //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS).ToString("0.00"));

                                        // hid eby Chithra on 11-01-2020 for ICEGATE IMPLEMENTATION
                                        //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS).ToString("0.00"));

                                        if (SCHEME_NOTN_ != "DFIA" && SCHEME_NOTN_ != "DFRC" && SCHEME_NOTN_ != "Tariff Quota")
                                        {
                                            //hide on 28-11-2020 for Dial Ess-sugg.by Subbu sir & Bala sir done by Chithra
                                            //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS).ToString("0.00"));

                                            //Again condition changed on 21-05-2021 for Guru Shipping sugg.by Subbu sir & Bala sir - Anti Dumping Should not add with MEIS License- done by Chithra 
                                            //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)).ToString("0.00"));

                                            TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS ).ToString("0.00"));
                                        }
                                        else
                                        {

                                            //TRQ-Calc ---for 32- Tariff Quota - BASIC Duty should be divided by 2 sugg.by Bala & Subbu sir on 30-08-2023 Implemntd by Chithra
                                            if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "062/2022" && SCHEME_NOTN_SLNO.Contains("III"))
                                            {
                                                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
                                            }
                                            //Added by pandiyan on 13-06-2025 sugg by bala & subbu
                                            else if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "029/2026") && SCHEME_NOTN_SLNO.Contains("III") && HttpContext.Current.Session["COMPANY_ID"].ToString() == "1217")
                                            {
                                                //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Scheme_Notn_SWS_Amt + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
                                                DIFF_AMT_BDC_TRQ = Convert.ToString((Convert.ToDouble(BASIC_DUTY)) - Convert.ToDouble(Scheme_Notn_BCD_Amt));
                                                DIFF_AMT_BDC_TRQ_SW = Convert.ToString(Convert.ToDouble(DIFF_AMT_BDC_TRQ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100);
                                                TOTAL_DEBIT_DUTY = Convert.ToString((Convert.ToDouble(DIFF_AMT_BDC_TRQ)) + Convert.ToDouble(DIFF_AMT_BDC_TRQ_SW));
                                            }
                                            else if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "029/2026") && SCHEME_NOTN_SLNO.Contains("III"))
                                            {
                                                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Scheme_Notn_SWS_Amt + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
                                            }
                                            else
                                            {
                                                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
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
                                       
                                        if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
                                        {
                                            HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
                                        }
                                        else
                                        {
                                            HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
                                        }
                                    }
                                    //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//
                                    else
                                    {
                                        BASIC_DUTY = 0.00;

                                        // CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;

                                        double bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                                        // double bcd;

                                        //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

                                        if (PRODUCT_BCD_NOTN != "")
                                        {
                                            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
                                            {
                                                //NOTIFICATION_CUSTOMS_BCD_RATE = "";

                                                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "145" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "262" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "184" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "223" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "224" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "164" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1026" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1048" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1057")
                                                {
                                                    CTH_SPL_AMT = "0";
                                                }
                                            }
                                        }

                                        //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

                                        if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                                        {
                                            //CTH_SPL_AMT = "";
                                            bcd_rate = bcd_rate;
                                        }
                                        else
                                        {
                                            double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                            double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                                            if (bcd_rate >= bcd_Amt)
                                            {
                                                if (cth_Amt >= bcd_rate)
                                                {
                                                    bcd_rate = cth_Amt;
                                                }
                                                else
                                                {
                                                    bcd_rate = bcd_rate;
                                                }
                                            }
                                            else
                                            {
                                                if (cth_Amt >= bcd_Amt)
                                                {
                                                    bcd_rate = cth_Amt;
                                                }
                                                else
                                                {
                                                    bcd_rate = bcd_Amt;
                                                }
                                            }
                                        }


                                        double CVD_Rate = (ASSESABLE_VALUE + bcd_rate) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;
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

                                        //-----------------------------NCD CALCULATION---------------------------------------//
                                        NCD = 0.00;
                                        //-----------------------------END NCD CALCULATION---------------------------------------//      

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
                                            }
                                        }

                                        //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                                        AIDC_Amt = NOTN_AIDC_CALC();


                                        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

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

                                        SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
                                        AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
                                        BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                                        NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
                                        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                                        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));

                                        TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));
                                        AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));

                                        //-----------------------CALCULATION FOR TOTAL DEBIT DUTY--------------------------------//


                                        //if (Convert.ToDecimal(CTH_SPL_AMT) <= 0)
                                        //{

                                        //    //CTH_SPL_AMT = "";
                                        //    BASIC_DUTY = bcd_rate;
                                        //}
                                        //else
                                        //{
                                        //    double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
                                        //    double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);

                                        //    if (bcd_rate >= bcd_Amt)
                                        //    {
                                        //        if (cth_Amt >= bcd_rate)
                                        //        {
                                        //            BASIC_DUTY = cth_Amt;
                                        //        }
                                        //        else
                                        //        {
                                        //            BASIC_DUTY = bcd_rate;
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        if (cth_Amt >= bcd_Amt)
                                        //        {
                                        //            BASIC_DUTY = cth_Amt;
                                        //        }
                                        //        else
                                        //        {
                                        //            BASIC_DUTY = bcd_Amt;
                                        //        }

                                        //    }

                                        //}


                                        if (PRODUCT_BCD_RATE != "")
                                        {
                                            bcd_rate = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                                        }

                                        double TRQ_rate = 0.00;
                                        if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III"))
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
                                                    //double SCHEME_Rate1 = Convert.ToDouble(SCHEME_Rate);
                                                    if (SCHEME_Rate == "")
                                                    {
                                                        SCHEME_Rate = "0";
                                                    }
                                                    TRQ_rate = Convert.ToDouble(SCHEME_Rate);
                                                }
                                            }

                                            Scheme_Notn_BCD_Amt = ASSESABLE_VALUE * TRQ_rate / 100;

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

                                      



                                        Customs_Edu_Cess = (bcd_rate) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
                                        Customs_Higher_Edu_Cess = (bcd_rate) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;

                                        //#SWS
                                        if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                                        {
                                            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                            //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }
                                        else
                                        {
                                            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }

                                        //if (SCHEME_NOTN_ == "MEIS" || SCHEME_NOTN_ == "SEIS")
                                        if (SCHEME_NOTN_ != "DFIA" && SCHEME_NOTN_ != "DFRC" && SCHEME_NOTN_ != "Tariff Quota")
                                        {
                                            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Customs_Social_welfare, 2).ToString("F"));
                                        }

                                        if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "029/2026") && SCHEME_NOTN_SLNO.Contains("III"))
                                        {
                                            TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Customs_Social_welfare, 2).ToString("F"));
                                            Scheme_Notn_SWS_Amt = (Scheme_Notn_BCD_Amt + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        }

                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//
                                        AddL_DUTY = 0.00;
                                        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

                                        Actual_BASIC_DUTY = BASIC_DUTY;

                                        //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//

                                        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "247" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "10")
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

                                        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
                                        Call_IGST_General();

                                        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - END 88 **************************************//

                                        //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY+Customs_Edu_Cess+Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                                        //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(bcd_rate + Customs_Edu_Cess + Customs_Higher_Edu_Cess).ToString("0.00"));

                                        //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(bcd_rate + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));

                                        //if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
                                        //{
                                        //    HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
                                        //}
                                        //else
                                        //{
                                        //    HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
                                        //}

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
                                                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
                                            }
                                            //Condition Added by pandiyan on 13-06-2025 sugg by bala & subbu
                                            else if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "022/2022" && SCHEME_NOTN_SLNO.Contains("III") && HttpContext.Current.Session["COMPANY_ID"].ToString() == "1217")
                                            {
                                                //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Scheme_Notn_SWS_Amt + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
                                                DIFF_AMT_BDC_TRQ = Convert.ToString((Convert.ToDouble(BASIC_DUTY)) - Convert.ToDouble(Scheme_Notn_BCD_Amt));
                                                DIFF_AMT_BDC_TRQ_SW = Convert.ToString(Convert.ToDouble(DIFF_AMT_BDC_TRQ) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100);
                                                TOTAL_DEBIT_DUTY = Convert.ToString((Convert.ToDouble(DIFF_AMT_BDC_TRQ)) + Convert.ToDouble(DIFF_AMT_BDC_TRQ_SW));
                                            }
                                            else if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "029/2026") && SCHEME_NOTN_SLNO.Contains("III"))
                                            {
                                                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Scheme_Notn_SWS_Amt + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
                                            }
                                            else
                                            {
                                                TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt + Convert.ToDouble(AIDC_Amt)).ToString("0.00"));
                                            }

                                            /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                                            //if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                                            //{
                                            //    if (HEALTH_CESS_CTH_CODE != "")
                                            //    {
                                            //        TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS + Customs_SWS_HealthCess).ToString("0.00"));
                                            //    }
                                            //}
                                        }

                                       
                                        if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
                                        {
                                            HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
                                        }
                                        else
                                        {
                                            HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
                                        }

                                    }

                                }
                                else //MEIS WITHOUT LICENSE ENTRY START
                                {

                                    //BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;

                                    double bcd_rate = 0.00;
                                    double TRQ_rate = 0.00;
                                    if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "062/2022" || SCHEME_NOTN == "029/2026") && (SCHEME_NOTN_SLNO.Contains("III") || SCHEME_NOTN_SLNO.Contains("IV")))
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
                                                SCHEME_AIDC_Rate = Convert.ToDouble(dS_SCHEMECODE.Rows[0]["SCHEME_AIDC_RATE"].ToString() == string.Empty ? "0.00" : dS_SCHEMECODE.Rows[0]["SCHEME_AIDC_RATE"].ToString());

                                                if (SCHEME_Rate == "")
                                                {
                                                    SCHEME_Rate = "0";
                                                }
                                                TRQ_rate = Convert.ToDouble(SCHEME_Rate);
                                            }
                                        }

                                        bcd_rate = ASSESABLE_VALUE * TRQ_rate / 100;
                                        Scheme_Notn_BCD_Amt = bcd_rate;

                                    }
                                    else
                                    {
                                        if (PRODUCT_BCD_RATE != "")
                                        {

                                            //Start Tariff Ass cal.
                                            if (PRODUCT_TARIFF_AMOUNT != "")// Condition added by Pandiyan (suggested by Bala) on 29-05-2025,When Tariff NTN = "36/2006" and Tariff Amount !="",calculate the Assessable Value as:(Tariff Qty * Tariff Amt * Exchange Rate).This value is used as the Basic Value for License Debit Duty.
                                            {
                                                if (Convert.ToDecimal(PRODUCT_TARIFF_AMOUNT) >= 0)
                                                {
                                                    Auto_Search auto = new Auto_Search();
                                                    DataSet ds_exrate = new DataSet();
                                                    auto.Enamesearch = "USD";//Get USD Exrate from Admin Master
                                                    auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
                                                    ds_exrate = auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                                                    if (ds_exrate.Tables[0].Rows.Count > 0)
                                                    {
                                                        tariff_amt = Convert.ToDouble(PRODUCT_TARIFF_QTY) * Convert.ToDouble(PRODUCT_TARIFF_AMOUNT) * Convert.ToDouble(ds_exrate.Tables[0].Rows[0][0].ToString());
                                                    }

                                                    ASSESABLE_VALUE = tariff_amt;
                                                    ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE;
                                                }
                                            }  //End Tariff Ass cal.
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

                                            if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "145" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "262" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "184" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "223" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "224" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "164" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1026" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1048" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1057")
                                            {
                                                CTH_SPL_AMT = "0";
                                            }
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

                                    /*  write by  Chithra suggest by Bala Sir on 30-05-18 for PARAMOUNT - start*/
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

                                            if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "313")
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
                                    /*  write by  Chithra suggest by Bala Sir on 30-05-18 for PARAMOUNT - end*/
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

                                    //---------------SAPTA CALCULATION----------------------------//

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
                                    }

                                    //---------------END SAPTA CALCULATION-------------------------//

                                    //-------HEALTH CESS CALCULATION
                                    HEALTH_CESS_TOTAL = "0.00";
                                    Healthcess_RateVal = 0.00;
                                    if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                                    {
                                        if (HEALTH_CESS_CTH_CODE != "")
                                        {
                                            Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                                        }
                                    }

                                    //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                                    AIDC_Amt = NOTN_AIDC_CALC();

                                    //#SWS
                                      //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                    //#SWS
                                    if (PRODUCT_RITC.Substring(0, 4) == "7106" || PRODUCT_RITC.Substring(0, 4) == "7108")
                                    {
                                        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                        //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                    }
                                    else
                                    {
                                        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                                    }

                                    //if (SCHEME_NOTN_ == "MEIS" || SCHEME_NOTN_ == "SEIS")
                                    if (SCHEME_NOTN_ != "DFIA" && SCHEME_NOTN_ != "DFRC" && SCHEME_NOTN_ != "Tariff Quota")
                                    {
                                        TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Customs_Social_welfare, 2).ToString("F"));
                                    }

                                    if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "029/2026") && SCHEME_NOTN_SLNO.Contains("III"))
                                    {
                                        TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Customs_Social_welfare, 2).ToString("F"));
                                        Scheme_Notn_SWS_Amt = (Scheme_Notn_BCD_Amt + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
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

                                    //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS).ToString("0.00"));
                                    //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS + Healthcess_RateVal ).ToString("0.00"));


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
                                        //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)).ToString("0.00"));

                                        //Again condition changed on 21-05-2021 for Guru Shipping sugg.by Subbu sir & Bala sir - Anti Dumping Should not add with MEIS License- done by Chithra 
                                        //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)).ToString("0.00"));

                                        TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + CESS).ToString("0.00"));
                                    }
                                    else
                                    {
                                        //TRQ-Calc ---for 32- Tariff Quota - BASIC Duty should be divided by 2 sugg.by Bala & Subbu sir on 30-08-2023 Implemntd by Chithra
                                        if (SCHEME_NOTN_ == "Tariff Quota" && SCHEME_NOTN == "062/2022" && SCHEME_NOTN_SLNO.Contains("III"))
                                        {
                                            TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
                                        }
                                        else if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "022/2022" || SCHEME_NOTN == "029/2026") && SCHEME_NOTN_SLNO.Contains("III"))
                                        {
                                            TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(Scheme_Notn_BCD_Amt + CVD + Scheme_Notn_SWS_Amt + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt).ToString("0.00"));
                                        }
                                        else
                                        {
                                            //#need to recheck
                                            TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + CESS + Healthcess_RateVal + AIDC_Amt + Convert.ToDouble(AIDC_Amt)).ToString("0.00"));
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

                                   

                                    if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
                                    {
                                        HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
                                    }
                                    else
                                    {
                                        HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
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

                        //-------HEALTH CESS CALCULATION
                        HEALTH_CESS_TOTAL = "0.00";
                        Healthcess_RateVal = 0.00;
                        if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                        {
                            if (HEALTH_CESS_CTH_CODE != "")
                            {
                                Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                            }
                        }

                        //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
                        AIDC_Amt = NOTN_AIDC_CALC();

                        //#SWS
                        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
                        //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

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


                    //------------Start New Anti-Dumping Calculation implemented on 04July2016------------//
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


                        ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + TOTAL_ANTI_AMT;

                    }
                    //------------End New Anti-Dumping Calculation implemented on 04July2016------------//
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


                                double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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


                        ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "       " + CTH_QTY + "     " + "         " + "  " + ADD_MAX_DIFF + "%" + "   " + TOTAL_ANTI_AMT;

                    }
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
                    double igst_anti_dump_amt = 0.00;

                    if (ANTI_DUMPING_NOTN != "")
                    {
                        if (IGST_LEVY_EXCEPTION_NOTN != "" && IGST_LEVY_EXCEPTION_SLNO != "")
                        {
                            igst_anti_dump_amt = Convert.ToDouble(TOTAL_ANTI_AMT) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;

                            IGST_LEVY_TOTAL = Convert.ToString(Convert.ToDouble(IGST_LEVY_TOTAL) + igst_anti_dump_amt);
                        }
                        else if (IGST_LEVY_NOTN != "" && IGST_LEVY_SLNO != "")
                        {
                            igst_anti_dump_amt = Convert.ToDouble(TOTAL_ANTI_AMT) * Convert.ToDouble(IGST_LEVY_RATE) / 100;

                            IGST_LEVY_TOTAL = Convert.ToString(Convert.ToDouble(IGST_LEVY_TOTAL) + igst_anti_dump_amt);
                        }
                    }


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
                        IGST_LEVY_TOTAL = "0.00";
                        IGST_LEVY_COMPENSATION_CESS_TOTAL = "0.00";
                    }
                    //-----------------End Scheme-20 Jobbing Duty Nil Implemented on 26July2017------------------//


                    //******************** GST IMPLEMENTATION ON 11-JULY-2017 END***************************

                    //TOTAL_CUSTOMS_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL));

                    TOTAL_CUSTOMS_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Healthcess_RateVal + AIDC_Amt);
                    TOTAL_IGST_DUTY = Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL);

                    //TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL));
                    TOTAL_DUTY = (Convert.ToDouble(TOTAL_ANTI_AMT) + Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(TOTAL_SOCIAL_WELFARE) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(NCD_TOTAL) + Convert.ToDouble(CESS_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(CVD_CEC_TOTAL) + Convert.ToDouble(CVD_CHEC_TOTAL) + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(INFRA_CESS_TOTAL) + Healthcess_RateVal + AIDC_Amt);


                   
                    //******************** GST IMPLEMENTATION ON 30-JUN-2017 END***************************


                    if (REVENUEDEPOSIT_ON == "")
                    {
                        REVENUEDEPOSIT_ON = "EMPTY";
                        REVENUEDEPOSIT_RATE = "0.00";
                    }

                    //---------------------------End Revenue Deposit Calculation--------------------------------------------//

                    //************************UPDATE LICENSE CIF & TOTAL DUTY VALIE IN LICENSE DETAILS-CHITHRA 03/03/2017*************************//
                    if (HttpContext.Current.Session["btn_cif_click"].ToString() != "btn_Calc")
                    {
                        DataSet ds_Update = new DataSet();
                        Transact.JOBNO = JobNo;
                        Transact.INVOICE_SLNO = Convert.ToString(INVOICE_SLNO);
                        Transact.ITEM_SLNO = ITEM_SLNO;
                        Transact.LICENSE_ITEM_NO = "";
                        Transact.CIF_VALUE = HttpContext.Current.Session["INDIVITUAL_CIF_AMOUNT"].ToString();
                        Transact.DUTY_VALUE = HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"].ToString();
                        Transact.Ename = "ITEM_WISE_LICENSE_UPDATE";
                        Transact.BRANCH_CODE = SELECT_BRANCH;
                        Transact.WORKING_PERIOD = SELECT_BRANCH;

                        ds_Update = Transact.RetrieveAll_License_Details_ITEM_WISE();
                    }

                    //************************UPDATE LICENSE CIF & TOTAL DUTY VALIE IN LICENSE DETAILS-CHITHRA 03/03/2017*************************//
                }
                b++;

                double final_debitduty = Math.Round(Convert.ToDouble(TOTAL_DEBIT_DUTY_FINAL) + Convert.ToDouble(TOTAL_DEBIT_DUTY), 0.00);
                TOTAL_DEBIT_DUTY_FINAL = Convert.ToString(final_debitduty);
                //HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY_FINAL;
            }

            C++;
        }
    }

    private double Get_Less_Sapta_Rate()
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

        return bcd_sapta_rate_Less_Value;
    }

    private double NOTN_SAPTA_CALC(double bcd_rate)
    {
        if (PRODUCT_SAPTA_NOTN != "" && PRODUCT_SAPTA_SLNO != "")
        {
            bcd_rate = (BASIC_DUTY * bcd_sapta_rate_Less_Value) / 100;
            BASIC_DUTY = bcd_rate;
        }
        return bcd_rate;
    }

    /*
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
    */

    private double NOTN_AIDC_CALC()
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
                //if ((PRODUCT_SAPTA_NOTN == "096/2008" && (PRODUCT_SAPTA_SLNO == "(i)" || PRODUCT_SAPTA_SLNO == "(ii)")) || PRODUCT_SAPTA_NOTN == "057/2009" || PRODUCT_SAPTA_NOTN == "101/2007" || PRODUCT_SAPTA_NOTN == "050/2018")//hide on 11-09-2023
                if (PRODUCT_SAPTA_NOTN == "057/2009" || PRODUCT_SAPTA_NOTN == "101/2007" || PRODUCT_SAPTA_NOTN == "050/2018")
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
                */

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
                    if (SCHEME_NOTN_ == "Tariff Quota" && (SCHEME_NOTN == "029/2026" && SCHEME_NOTN_SLNO.Contains("III")))//New Impmtn on 20-07-2026 sugg.by Bala sir  done ny Chithra
                    {
                        if (SCHEME_AIDC_Rate != 0.00)
                        {
                            AIDC_Amt = (ASSESABLE_VALUE) * Convert.ToDouble(SCHEME_AIDC_Rate) / 100;
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
            }
            else
            {
                //error table here - Need to Implement
            }
        }

        return AIDC_Amt;
    }

    private void Scheme_DEEC(DataSet dss1)
    {
        //EXCEMPTION = dss1.Tables[0].Rows[0]["EXCEMPTION"].ToString();
        //if (EXCEMPTION == "Y")
        //{
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


            //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

            if (PRODUCT_BCD_NOTN != "")
            {
                if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
                {
                    //NOTIFICATION_CUSTOMS_BCD_RATE = "";

                    if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "145" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "262" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "184" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "223" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "224" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "164" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1026" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1048" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1057")
                    {
                        CTH_SPL_AMT = "0";
                    }
                }
            }

            //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//


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
                //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
                double cth_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);


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
                    /* hide by Chithra Suggest by Bala on 12-06-2018 for PIONEER
                     //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                     //BASIC_DUTY_BCD_SPL = cth_Amt;
                     //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);
                     //CTH_SPL_AMT = PRODUCT_BCD_SPL;
                      */

                    double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                    double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_BCD_SPL);

                    /* hide By chithra for implement H,L,+ - above code value again update here.. 
                    //if (bcd_rate >= cth_Amt)
                    //{
                    //    BASIC_DUTY = bcd_rate;
                    //}
                    //else
                    //{
                    //    BASIC_DUTY = cth_Amt;
                    //}
                     * */

                    if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                    {
                        if (bcd_Amt <= bcd_rate)
                        //if (bcd_Amt >= bcd_rate)//which ever lower
                        {
                            BASIC_DUTY = bcd_Amt;
                        }
                    }

                    if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "313")
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
            //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
            Get_Less_Sapta_Rate();

            bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

            //---------------END SAPTA CALCULATION-------------------------//

            HEALTH_CESS_TOTAL = "0.00";
            Healthcess_RateVal = 0.00;
            if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
            {
                if (HEALTH_CESS_CTH_CODE != "")
                {
                    Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
                }
            }


            //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
            AIDC_Amt = NOTN_AIDC_CALC();
        
            //-------SOCIAL WELFARE CALCULATION
        /* --02-02-2021
            if (SOCIAL_WELFARE_NOTN != "")
            {
                SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            }
        */

            //#SWS
            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

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

            //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
            Actual_BASIC_DUTY = BASIC_DUTY;

            CESS = 0.00;

            //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

            //---------------CVD New Education Cess Calculation------------------------------//

            //cvd_Customs_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_EDU_CESS_RATE) / 100;
            //cvd_Customs_Higher_Edu_Cess = CVD * Convert.ToDouble(CETH_CVD_SEC_EDU_CESS_RATE) / 100;


            //---------------End CVD New Education Cess Calculation--------------------------//
            /* hide on 20/02/2018 discuss with subbu sir --------- start
               Customs_Edu_Cess = (BASIC_DUTY + CVD + Convert.ToDouble(GSI_TOTAL) + CESS) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
               Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD + Convert.ToDouble(GSI_TOTAL) + CESS) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
               ////AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + CESS) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;

            hide on 20/02/2018 discuss with subbu sir --------- End  */

            Customs_Edu_Cess = 0.00;
            Customs_Higher_Edu_Cess = 0.00;

            //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;--02-02-2021


            //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//

            if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "247" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "10")
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

                        TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * (ADD_MAX_DIFF) / 100;
                        TOTAL_ANTI_AMT_LICNESE = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));


                        double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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
                    TOTAL_ANTIDUMP_AMT = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble((ADD_DIFF_CUR)) / 100;

                    if (TOTAL_ANTIDUMP_AMT <= 0)
                    {
                        TOTAL_ANTIDUMP_AMT = 0.00;
                    }
                    TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                    MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                }

                //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
                ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "      " + CTH_QTY + "   " + " " + ADD_DIFF_CUR + "%" + " " + TOTAL_ANTIDUMP_AMT;

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

                //10-06-2024
               // TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));

                if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                {
                    if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (HttpContext.Current.Session["COMPANY_ID"].ToString() != "2404" && HttpContext.Current.Session["COMPANY_ID"].ToString() != "951"))// Condition Added by pandiyan suggest by bala for sai clearing  
                    {
                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT)  + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));
                    }
                    else
                    {
                        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));

                    }
                }

                else
                {
                    TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal), 1).ToString("0.00"));
                }

                /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                {
                    if (HEALTH_CESS_CTH_CODE != "")
                    {
                        //10-06-2024
                        //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess + AIDC_Amt), 1).ToString("0.00"));

                        if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess + AIDC_Amt), 1).ToString("0.00"));
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
                //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));

                if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                {
                    TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));
                }
                else
                {
                    TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal ), 1).ToString("0.00"));
                }

                /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
                if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                {
                    if (HEALTH_CESS_CTH_CODE != "")
                    {
                        //10-06-2024
                        //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess + AIDC_Amt), 1).ToString("0.00"));

                        if (AIDC_NOTN == "011/2021" && (AIDC_NOTN_SLNO == "17" || AIDC_NOTN_SLNO == "18" || AIDC_NOTN_SLNO == "19" || AIDC_NOTN_SLNO == "17A"))
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess + AIDC_Amt), 1).ToString("0.00"));
                        }
                        else
                        {
                            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess), 1).ToString("0.00"));
                        }
                    }
                }
            }

            PRODUCT_OTHER_DUTY_TOTAL = "0";

           

            if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
            {
                HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
            }
            else
            {
                HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
            }
        //}
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

                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "145" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "262" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "184" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "223" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "224" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "164" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1026" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1048" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1057")
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
                    bcd_rate_new = "0.00";
                    PRODUCT_BCD_RATE = "0.00";
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
            //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
            double cth_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);

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
                bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_BCD_SPL);

                /* hide By chithra for implement H,L,+ - above code value again update here.. 
                //if (bcd_rate >= cth_Amt)
                //{
                //    BASIC_DUTY = bcd_rate;
                //}
                //else
                //{
                //    BASIC_DUTY = cth_Amt;
                //}
                 * */

                if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                {
                    if (bcd_Amt <= bcd_rate)
                    {
                        BASIC_DUTY = bcd_Amt;
                    }
                }

                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "313")
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
        //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
        Get_Less_Sapta_Rate();
        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

        //---------------END SAPTA CALCULATION-------------------------//

        //----------------Start 28Apr2015---------------------//
        if (NOTIFICATION_CUSTOMS_BCD_RATE != "")
        {
            //this line hide by chithra on 16-01-2020 with sathish sir- bcz condition wrongly execute even  NOTIFICATION_CUSTOMS_BCD_SPL is more than "0" 
            //if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
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

        //if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "182")
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

       if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "182")
       {
           //CVD = CVD * 20;
           CVD = CVD + CVD_Amt;
       }

       if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "162" && CVD_NOTN == "012/2012" && PRODUCT_CVD_NOTN_SLNO == "51(ii)")
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
      if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "293" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "10")
      {
          if (PRODUCT_CETH.Substring(0, 4) == "8703")
          {
              CESS = 0.00;
              NCD = 0.00;
              INFRA_CESS = 0.00;
          }
      }
        * hide on 20/02/2018 discuss with subbu sir --------- End  * */
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
        //Customs_Social_welfare = (BASIC_DUTY + NCD + CVD + SOCIAL_welf_Rate + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(TTA_TOTAL) + Convert.ToDouble(SCHED11_TOTAL) + CESS + INFRA_CESS) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
        
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

           //----- New Impelmentation for RYAL Logistics suggest by Bala sir.. on 27-02-2020

           double aggregate1 = AGGREGATE_DUTY * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
           AGGREGATE_DUTY = AGGREGATE_DUTY + aggregate1;
       }

       CVD_CEC_TOTAL = "0.00";
       CVD_CHEC_TOTAL = "0.00";

       HEALTH_CESS_TOTAL = "0.00";
       Healthcess_RateVal = 0.00;
       if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
       {
           if (HEALTH_CESS_CTH_CODE != "")
           {
               Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
           }
       }

       //#AIDC CALCULATION - New implmntion on 01-02-2021- Union Budget
       AIDC_Amt = NOTN_AIDC_CALC();

       //-------SOCIAL WELFARE CALCULATION
        /*
       if (SOCIAL_WELFARE_NOTN != "")
       {
           SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
       }
        */

       //#SWS
       Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
       //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

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

        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "248")
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
        AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));

        ADDLTIONAL_DUTY_TOTAL = "0.00";
        INFRA_CESS_TOTAL = "0.00";


        //------------New Anti-Dumping Calculation implemented on 04July2016------------//
        if (ANTI_AMTS != null && ANTI_AMTS != "")
        {
            if (ADD_AMT_MINUS_ASSESABLE == "1")
            {
                //TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - ASSESABLE_VALUE - Convert.ToDouble(BASIC_DUTY_TOTAL);

                TOTAL_ANTIDUMP_AMT = TOTAL_ANTIDUMP_AMT - (ASSESABLE_VALUE + Convert.ToDouble(BASIC_DUTY_TOTAL));

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


                    double Anti_Dump_Cal2 = (ASSESABLE_VALUE + BASIC_DUTY + AIDC_Amt) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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

        if (SCHEME_NOTN_ == "DEEC")
        {
            
            //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
            //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));
            if (SCHEME_NOTN_ == "DEEC" && SCHEME_NOTN == "022/2023" && (HttpContext.Current.Session["COMPANY_ID"].ToString() != "2404" && HttpContext.Current.Session["COMPANY_ID"].ToString() != "951"))
            {
                TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));
            }
            else
            { 
            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(TOTAL_ANTIDUMP_AMT) + Healthcess_RateVal + AIDC_Amt), 1).ToString("0.00"));
            }
            if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
            {
                HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
            }
            else
            {
                HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
            }
        }
    }


    private void Scheme_DUTIABLE_Chapter_24_27()
    {
        double bcd_rate = 0.00;
        double bcd_Amt = 0.00;
        //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

        if (PRODUCT_BCD_NOTN != "")
        {
            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
            {
                //NOTIFICATION_CUSTOMS_BCD_RATE = "";

                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "145" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "262" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "184" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "223" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "224" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "164" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1026" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1048" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1057")
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
            bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
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
            //bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
            //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
            double cth_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);

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
                bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_BCD_SPL);

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

                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "313")
                {
                    if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                }

                //BASIC_DUTY_BCD_SPL = cth_Amt;
                //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                CTH_SPL_AMT = PRODUCT_BCD_SPL;
                //CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
            }
        }

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
            NCD = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_NCD_SPL_DUTY);
        }
        else if (Convert.ToDecimal(CTH_NCD_D_RATE) == 1)
        {
            NCD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(CTH_NCD_D_RATE) / 100;
        }
        else
        {
            NCD = 0.00;
        }

        //-----------------------------END NCD CALCULATION---------------------------------------//

        //SOCIAL WELFARE CALCULATION

        if (SOCIAL_WELFARE_NOTN != "")
        {
            SOCIAL_welf_Rate = BASIC_DUTY * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
        }


        //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//
        //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
        Get_Less_Sapta_Rate();
        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

        //---------------END SAPTA CALCULATION-------------------------//

        //----------------Start 28Apr2015---------------------//
        if (NOTIFICATION_CUSTOMS_BCD_RATE != "")
        {
            //this line hide by chithra on 16-01-2020 with sathish sir- bcz condition wrongly execute even  NOTIFICATION_CUSTOMS_BCD_SPL is more than "0" 
           // if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
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

        //---------------------------- CESS AMT Calc again enable for BOXCO on 25-10-2019 by Chithra sugg by Bala sir & Sathish sir..
        if ((Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "116") && (PRODUCT_CETH == "27101930" || PRODUCT_CETH == "27101949"))
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
        else
        {
            CESS = 0.00;
        }
        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "182")
        {
            //CVD = CVD * 20;
            CVD = CVD + CVD_Amt;
        }

        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "162" && CVD_NOTN == "012/2012" && PRODUCT_CVD_NOTN_SLNO == "51(ii)")
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
        if (PRODUCT_CETH_CHAPTER == "NOEXCISE")
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

        if ((Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "116") && (PRODUCT_CETH == "27101930" || PRODUCT_CETH == "27101949"))
        {
            GSI_TOTAL = "0.00";
            if (CETH_SIA_I_RATE != "")
            {
                if (Convert.ToDouble(CETH_SIA_I_RATE) > 0)
                {
                    CETH_SIA_I_amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_SIA_I_RATE);
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

        if ((Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "116") && (PRODUCT_CETH == "27101930" || PRODUCT_CETH == "27101949"))
        {
            //#SWS
            Customs_Social_welfare = (BASIC_DUTY + CVD + NCD + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(CESS) + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            //Customs_Social_welfare = (BASIC_DUTY + CVD + NCD + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(CESS) + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
        }
        else
        {
            //#SWS
            // Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            Customs_Social_welfare = (BASIC_DUTY + CVD + NCD + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            //Customs_Social_welfare = (BASIC_DUTY + CVD + NCD + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
        }

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

        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "248")
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
        if ((Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "116") && (PRODUCT_CETH == "27101930" || PRODUCT_CETH == "27101949"))
        {
            if (PRODUCT_ADDL_DUTY_RATE != "")
            {
                ADDLTIONAL_DUTY_TOTAL = Convert.ToString((Convert.ToDouble(ASSESABLE_VALUE) + Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(GSI_TOTAL) + Convert.ToDouble(CESS)) * Convert.ToDouble(PRODUCT_ADDL_DUTY_RATE) / 100);
            }
        }

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


        if (SCHEME_NOTN_ == "DEEC")
        {

            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CESS + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(TOTAL_ANTIDUMP_AMT)), 1).ToString("0.00"));

            
            if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
            {
                HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
            }
            else
            {
                HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
            }
        }
    }


    private void Scheme_DUTIABLE_CIGARETTE_Calc()
    {
        double bcd_rate = 0.00;
        double bcd_Amt = 0.00;
        //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

        if (PRODUCT_BCD_NOTN != "")
        {
            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
            {
                //NOTIFICATION_CUSTOMS_BCD_RATE = "";

                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "145" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "262" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "184" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "223" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "224" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "164" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1026" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1048" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1057")
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
            bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
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
            //bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
            //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
            double cth_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);

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
                bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_BCD_SPL);

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

                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "313")
                {
                    if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                }

                //BASIC_DUTY_BCD_SPL = cth_Amt;
                //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

                CTH_SPL_AMT = PRODUCT_BCD_SPL;
               // CTH_SPL_UNIT = PRODUCT_BCD_UNIT;
            }
        }


        //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//
        //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
        Get_Less_Sapta_Rate();
        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

        //---------------END SAPTA CALCULATION-------------------------//

        //----------------Start 28Apr2015---------------------//
        if (NOTIFICATION_CUSTOMS_BCD_RATE != "")
        {
            //this line hide by chithra on 16-01-2020 with sathish sir- bcz condition wrongly execute even  NOTIFICATION_CUSTOMS_BCD_SPL is more than "0" 
            //if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_RATE) == 0 && Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00)
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
                CVD_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_CVD_SPL);
                CETH_SPL_AMT = PRODUCT_CVD_SPL;
            }
        }
        else
        {
            CVD_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_SPL_AMT);
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

        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "182")
        {
            //CVD = CVD * 20;
            CVD = CVD + CVD_Amt;
        }

        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "162" && CVD_NOTN == "012/2012" && PRODUCT_CVD_NOTN_SLNO == "51(ii)")
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

        //CETH_CESS_AMTS = Convert.ToString(Convert.ToDouble(ceth_cess_amount).ToString("F"));

        GSI_TOTAL = "0.00";
        if (CETH_SIA_I_RATE != "")
        {
            if (Convert.ToDouble(CETH_SIA_I_RATE) > 0)
            {
                CETH_SIA_I_amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CETH_SIA_I_RATE);
                GSI_TOTAL = Convert.ToString(CETH_SIA_I_amt);
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

        //#SWS
        Customs_Social_welfare = (BASIC_DUTY + CVD + CETH_SIA_I_amt + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
        //Customs_Social_welfare = (BASIC_DUTY + CVD + CETH_SIA_I_amt + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;


        //IGST ASSESABLE VALUE SHOWS IN CHECKLIST - BY CHITHRA ON 05/05/2018
        //CHK_IGST_ASSBL_VAL = 0.00;
        //CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare;
        //tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);

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

        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "248")
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
                //TOTAL_ANTIDUMP_AMT = Convert.ToDouble(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                MERIT_TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
                TOTAL_ANTI_AMT = Convert.ToString(Math.Round(TOTAL_ANTIDUMP_AMT, 2).ToString("F"));
            }

            //ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "     " + ADD_ANTI_AMTS + " " + ADD_ANTI_CUR + "     " + "0.00";
            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "        " + CTH_QTY + "         " + "        " + ADD_DIFF_CUR + "%" + "  " + TOTAL_ANTIDUMP_AMT;

        }
        //---------End New Anti-Dumping Calculation implemented on 27Sep2018------------//



        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
        Call_IGST_General_CIGARETTE();

        if (SCHEME_NOTN_ == "DEEC") 
        {

            //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + CESS + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT)), 1).ToString("0.00"));
            TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + CESS + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(TOTAL_ANTIDUMP_AMT)), 1).ToString("0.00"));
          
           
            if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
            {
                HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
            }
            else
            {
                HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
            }
        }
    }


    public void CALL_GENERAL_SCHEME_SAME_CODE()
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
            //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
            double cth_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);

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


        NCD = 0.00;

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

        //-------HEALTH CESS CALCULATION
        HEALTH_CESS_TOTAL = "0.00";
        Healthcess_RateVal = 0.00;
        if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
        {
            if (HEALTH_CESS_CTH_CODE != "")
            {
                Healthcess_RateVal = Math.Round(Convert.ToDouble(ASSESABLE_VALUE * Convert.ToDouble(HEALTH_CESS_RATE) / 100), 2);
            }
        }

        //-------SOCIAL WELFARE CALCULATION

        if (SOCIAL_WELFARE_NOTN != "")
        {
            SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
        }

        //#SWS
        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;//02feb
        //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;//02feb

        ADDLTIONAL_DUTY_TOTAL = "0.00";

        AddL_DUTY = 0.00;

        //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//
        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "247" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "218" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "392" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "10")
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

        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//
        //doing

        Call_IGST_General();

        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - END 88 **************************************//

        //TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD), 1).ToString("0.00"));
        //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY + NCD).ToString("0.00"));//hide 02feb 2018 by chithra
        TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + cvd_Customs_Edu_Cess + cvd_Customs_Higher_Edu_Cess + Customs_Social_welfare + AddL_DUTY + NCD + Healthcess_RateVal).ToString("0.00"));


        if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
        {
            HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
        }
        else
        {
            HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
        }
    }

    public void Call_IGST_General() // ********* GST IMPLEMENTATION ON 30 JUN 2017  - START ****************//
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

                    //hide on 30-10-2024 for w/o Aggregate BASIC Duty should not calc for IGSt .. Sugg.by Bala sir
                    // IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt));
                    IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt));

                    if (MRP_AMT > IGST_LEV_1_AMT)
                    {
                        IGST_LEV_1_AMT = (Convert.ToDouble(MRP_AMT)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }
                    else
                    {
                        IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }

                }
                else
                {
                    IGST_LEV_1_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
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
                        IGST_LEV_2_Excemption = (Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(igst_NOTIFICATION_EXCISE_BCD_SPL)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;
                        IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                    }
                    else
                    {
                        if (LEVY_EXCEMPTION_NOTN_TYPE == "G")
                        {

                            if (dt_IGST_SPL.Rows[0]["NOTIFICATION_TYPE"].ToString() == "1C")
                            {
                                IGST_LEV_2_Excemption = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));

                            }
                            else
                            {
                                IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE_cal) / 100;
                                IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                            }
                        }
                        else
                        {
                            if (dt_IGST_SPL.Rows[0]["NOTIFICATION_TYPE"].ToString() == "1C")
                            {
                                IGST_LEV_2_Excemption = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE_cal) / 100;
                                IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                            }
                            else
                            {
                                IGST_LEV_2_Excemption = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
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

                    if (SCHEME_CODE == "12" || SCHEME_CODE == "17") // sugg by bala Condition Splited as per lotus & capricorn  on 18-06-2025 for while coming add ntn gst duty shuld add with add value.
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
                }
            }

            //******************* COMPENSATION CALCULATION ************************

            if (IGST_LEVY_EXCEPTION_CC_NOTN == "" && IGST_LEVY_EXCEPTION_CC_SLNO == "")
            {
                if (IGST_LEVY_COMPENSATION_CESS_RATE != "")
                {
                    //IGST_LEV_1_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Edu_Cess) + Convert.ToDouble(Customs_Higher_Edu_Cess) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                    IGST_LEV_1_COMPENSATION_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                    IGST_LEVY_COMPENSATION_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_1_COMPENSATION_AMT), 1).ToString("0.00"));
                }
            }
            else
            {
                if (IGST_LEVY_EXCEPTION_CC_NOTN != "" && IGST_LEVY_EXCEPTION_CC_SLNO != "")
                {
                    //IGST_LEV_2_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Edu_Cess) + Convert.ToDouble(Customs_Higher_Edu_Cess) + ASSESABLE_VALUE) * Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE) / 100;
                    IGST_LEV_2_COMPENSATION_AMT = (Convert.ToDouble(Actual_BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Healthcess_RateVal + Convert.ToDouble(AIDC_Amt)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE) / 100;
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


    public void Call_IGST_General_CIGARETTE()
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
                    IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL));

                    if (MRP_AMT > IGST_LEV_1_AMT)
                    {
                        IGST_LEV_1_AMT = (Convert.ToDouble(MRP_AMT)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }
                    else
                    {
                        IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                    }

                }
                else
                {
                    IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD) + Convert.ToDouble(CETH_SIA_I_amt) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
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
                        IGST_LEV_2_Excemption = (Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(igst_NOTIFICATION_EXCISE_BCD_SPL)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE) / 100;
                        IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                    }
                    else
                    {
                        if (LEVY_EXCEMPTION_NOTN_TYPE == "G")
                        {

                            if (dt_IGST_SPL.Rows[0]["NOTIFICATION_TYPE"].ToString() == "1C")
                            {
                                IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));

                            }
                            else
                            {
                                IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE_cal) / 100;
                                IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                            }
                        }
                        else
                        {
                            if (dt_IGST_SPL.Rows[0]["NOTIFICATION_TYPE"].ToString() == "1C")
                            {
                                IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_RATE_cal) / 100;
                                IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                            }
                            else
                            {
                                IGST_LEV_2_Excemption = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
                                IGST_LEVY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(IGST_LEV_2_Excemption), 1).ToString("0.00"));
                            }
                        }
                    }
                    // END -  NEWLY IMPLEMENTED BY CHITHRA  ON 03-02-2019 - FOR IGST EXCEMPTION SPL AMT CALC FOR BOXCO SUGGEST BY BALA SIR..



                    if (SCHEME_CODE == "12" || SCHEME_CODE == "03" || SCHEME_CODE == "17")
                    {
                        if (LEVY_EXCEMPTION_NOTN_TYPE == "C")
                        {
                            IGST_LEV_1_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Convert.ToDouble(PRODUCT_OTHER_DUTY_TOTAL) + Convert.ToDouble(SAFE_GUARD_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)) * Convert.ToDouble(IGST_LEVY_RATE) / 100;
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
                        ceth_splamt = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD) + Convert.ToDouble(CETH_SIA_I_amt) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)) * Convert.ToDouble(IGST_LEVY_COMPENSATION_CESS_RATE) / 100;
                        CVD_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(igst_NOTIFICATION_EXCISE_BCD_SPL);

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
                    IGST_LEV_2_COMPENSATION_AMT = (Convert.ToDouble(BASIC_DUTY) + Convert.ToDouble(CVD) + Convert.ToDouble(CETH_SIA_I_amt) + Convert.ToDouble(Customs_Social_welfare) + ASSESABLE_VALUE + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)) * Convert.ToDouble(IGST_LEVY_EXCEPTION_CC_RATE) / 100;
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
                HEALTH_CESS_TOTAL = "0.00";
            }
            else if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1(B)" || NOTN_SLNO == "1(C)" || NOTN_SLNO == "1(D)" || NOTN_SLNO == "1(E)" || NOTN_SLNO == "3" || NOTN_SLNO == "1A" || NOTN_SLNO == "1D")) //------Implemented On 12Oct2017 for Paramount with Bala
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
                HEALTH_CESS_TOTAL = "0.00";
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
                HEALTH_CESS_TOTAL = "0.00";
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
                HEALTH_CESS_TOTAL = "0.00";
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
                HEALTH_CESS_TOTAL = "0.00";
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
                HEALTH_CESS_TOTAL = "0.00";
            }


            //REIMPORT_FREIGHT_AMOUNT = REIMPORT_FREIGHT_AMOUNT + Convert.ToDouble(REIMPORT_FREIGHT);
            //REIMPORT_INSURANCE_AMOUNT = REIMPORT_INSURANCE_AMOUNT + Convert.ToDouble(REIMPORT_INSURANCE);
            //b++;
        }
    }

    private void Scheme_EPCG(DataTable dss1, adminmaster adm_Mas)
    {
        adminmaster adm = new adminmaster();

        //if (dss1.Rows.Count > 0)
        //{
        //    EXCEMPTION = dss1.Rows[0]["EXCEMPTION"].ToString();

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

        //-------HEALTH CESS CALCULATION
        HEALTH_CESS_TOTAL = "0.00";
        Healthcess_RateVal = 0.00;
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
        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
        //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

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

            //#SWS
            Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
            //Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

            SAFE_GUARD = (ASSESABLE_VALUE) * Convert.ToDouble(CTH_SAFEGUARD_RATE) / 100;
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
         *  hide on 20/02/2018 discuss with subbu sir --------- End  * */

        BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
        SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 1).ToString("0.00"));
        AGGREGATE_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AGGREGATE_DUTY), 1).ToString("0.00"));
        CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));

        NCD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(NCD), 1).ToString("0.00"));
        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));

        TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));
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

                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "145" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "262" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "184" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "223" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "224" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "164" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1026" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1048" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "1057")
                {
                    CTH_SPL_AMT = "0";
                }
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
            double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
            //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
            double cth_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);

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

        //SOCIAL WELFARE CALCULATION
        if (SOCIAL_WELFARE_NOTN != "")
        {
            SOCIAL_welf_Rate = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
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
          hide on 20/02/2018 discuss with subbu sir --------- End * */

        Customs_Edu_Cess = 0.00;
        Customs_Higher_Edu_Cess = 0.00;


        //#SWS
        Customs_Social_welfare = (bcd + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
        Customs_social_welfare_a = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

        //Customs_Social_welfare = (bcd + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;
        //Customs_social_welfare_a = (BASIC_DUTY + Healthcess_RateVal) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

        AddL_DUTY = 0.00;

        //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//
        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "247" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "10")
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
            ANTI_DUMPING_NOTN = "Antdump:" + "  " + "CTH:" + CTH_SLNO + "   " + "Sup:" + CTH_SUPPLIER_SLNO + "     " + ANTI_DUMPING_NOTN + "  " + ANTI_DUMPING_NOTN_SLNO + "      " + CTH_QTY + "      " + " " + ADD_DIFF_CUR + "%" + " " + TOTAL_ANTIDUMP_AMT;

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

        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//


        if (PRODUCT_AGGREGATE_DUTY_NOTN == "" && PRODUCT_AGGREGATE_DUTY_NOTN_SL == "" && PRODUCT_AGGREGATE_DUTY_NOTN_RATE == "")
        {
            //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
            Actual_BASIC_DUTY = BASIC_DUTY;
        }

        Call_IGST_General();

        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - END 88 **************************************//

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
           //hide on 21-07-2026 by chitha for AIDC should not add with License sugg.by Bala sir
            //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_social_welfare_a + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)).ToString("0.00"));
            TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_social_welfare_a + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Healthcess_RateVal ).ToString("0.00"));


            /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
            if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
            {
                if (HEALTH_CESS_CTH_CODE != "")
                {
                    TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Customs_SWS_HealthCess).ToString("0.00"));
                }
            }
        }
        else
        {
            //TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Edu_Cess_a + Customs_Higher_Edu_Cess_a + AddL_DUTY + NCD).ToString("0.00"));
            TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + Customs_social_welfare_a + AddL_DUTY + NCD + Healthcess_RateVal + Convert.ToDouble(AIDC_TOTAL)).ToString("0.00"));


            /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
            if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
            {
                if (HEALTH_CESS_CTH_CODE != "")
                {
                    TOTAL_DEBIT_DUTY = Convert.ToString(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Customs_SWS_HealthCess).ToString("0.00"));
                }
            }
        }

        PRODUCT_OTHER_DUTY_TOTAL = "0";



        if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
        {
            HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
        }
        else
        {
            HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
        }
        //}

        //}
    }


    private void Scheme_Post_Export_EPCG(DataSet dss1)
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

        if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (Connection.COMPANYID() != "2404" && Connection.COMPANYID() != "951"))// Condition Added by pandiyan suggest by bala for sai clearing  
        {
            TOTAL_ANTI_AMT = TOTAL_ANTI_AMT;
        }
        else
        {
            TOTAL_ANTI_AMT = "0.00";
        }

        //BCD_FG_AMT = 0.00;

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
            double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
            //double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(CTH_SPL_AMT);--hide on 18-03-2021 sugg.by Bala sir - for Customs directly taking Item Qty instead of CTH_QTY1
            double cth_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);

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
                double bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_BCD_SPL);

                if (PRODUCT_CTH == "40012200" && BCD_NOTN == "050/2017" && PRODUCT_BCD_NOTN_SLNO == "281")
                {
                    if (bcd_Amt <= bcd_rate)
                    {
                        BASIC_DUTY = bcd_Amt;
                    }
                }

                if (Connection.COMPANYID() == "313")
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

        //--Get SAPTA RATE Less value - on 09-12-2024 by Chithra
        Get_Less_Sapta_Rate();

        //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//
        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

        //---------------END SAPTA CALCULATION-------------------------//


        //--------------BCD FOREGONE AMOUNT----By Chithra on 25-11-2023 for Capricorn-----------
        //BCD_FG_AMT = MERIT_BASIC_DUTY - BASIC_DUTY;
        //BCD_FOREGONE_AMT = Convert.ToString(Math.Round(Convert.ToDouble(BCD_FG_AMT), 1).ToString("0.00"));
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

        if (Connection.COMPANYID() == "614")
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

        //if (CETH_CVD_NIL_YN == "Y")
        //{
        //    CVD = 0.00;
        //    CVD_TOTAL = "0.00";
        //    PRODUCT_CVD_RATE = "0.00";
        //}

        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

        //Before get the Aggregate BASIC DUTY - For IGST Calc -- on 30-10-2024 Sugg.By Bala sir
        Actual_BASIC_DUTY = BASIC_DUTY;


        CESS = 0.00;


        Customs_Edu_Cess = 0.00;
        Customs_Higher_Edu_Cess = 0.00;

        //------------NEW IMPLEMENTATION FOR BAS SHIPPING ON 22AUG2016--------//

        if (Connection.COMPANYID() == "247" || Connection.COMPANYID() == "10")
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

            if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (Connection.COMPANYID() != "2404" && Connection.COMPANYID() != "951"))// Condition Added by pandiyan suggest by bala for sai clearing  
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
            Other_duty = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_SPL);
            PRODUCT_OTHER_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Other_duty), 1).ToString("0.00"));
        }

        // ********************* GST IMPLEMENTATION ON 30 JUN 2017  - START **************************************//

        TOTAL_SOCIAL_WELFARE = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Social_welfare), 1).ToString("0.00"));

        Call_IGST_General();

        //CHK_IGST_ASSBL_VAL = 0.00;
        //if (RSP_APPLICABLE == "S" && (MRP_AMT > IGST_LEV_1_AMT_ASS))
        //{
        //    CHK_IGST_ASSBL_VAL = MRP_AMT; //Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
        //    tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
        //}
        //else
        //{
        //    if (NOTN_NO == "045/2017" && (NOTN_SLNO == "1A" || NOTN_SLNO == "1(A)" || NOTN_SLNO == "1D" || NOTN_SLNO == "1(D)"))
        //    {
        //        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE;
        //    }
        //    else
        //    {
        //        CHK_IGST_ASSBL_VAL = ASSESABLE_VALUE + BASIC_DUTY + Customs_Social_welfare + Healthcess_RateVal + AIDC_Amt + SAFE_GUARD + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT);//Implemented on 20July2021 by Sathish with Bala (Pegasus Forwarding)
        //    }
        //    tot_CHK_IGST_LEVY_AMT += Math.Round(CHK_IGST_ASSBL_VAL, 1);
        //}

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
                if (SCHEME_CODE == "03" && SCHEME_NOTN == "022/2023" && (Connection.COMPANYID() != "2404" && Connection.COMPANYID() != "951"))//Condition Added by pandiyan suggest by bala for sai clearing    
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



        if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
        {
            HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
        }
        else
        {
            HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
        }
    }

    private void Scheme_14_RestrictedItems()
    {
        double bcd_rate = 0.00;
        double bcd_Amt = 0.00;
        //----------------New Implementation For Bullet Cargo on 09Aug2016 with Bala----------------//

        if (PRODUCT_BCD_NOTN != "")
        {
            if (Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0.00 || Convert.ToDouble(NOTIFICATION_CUSTOMS_BCD_SPL) == 0)
            {
                CTH_SPL_AMT = "0";
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

        if ((Convert.ToDecimal(CTH_SPL_AMT) > 0) && PRODUCT_BCD_RATE == "")
        {
            BASIC_DUTY = 0.00;
            bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);
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
            double cth_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(CTH_SPL_AMT);


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

        if (PRODUCT_BCD_SPL != "")
        {
            if (Convert.ToDouble(PRODUCT_BCD_SPL) != 0.000000 || Convert.ToDouble(PRODUCT_BCD_SPL) != 000000)
            {
                double cth_Amt = Convert.ToDouble(CTH_QTY1) * Convert.ToDouble(PRODUCT_BCD_SPL);
                bcd_Amt = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(PRODUCT_BCD_SPL);

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

                if (Connection.COMPANYID() == "313")
                {
                    if (BCD_NOTN == "012/2012" && PRODUCT_BCD_NOTN_SLNO == "252(ii)")
                    {
                        BASIC_DUTY = cth_Amt;
                    }
                }

                //BASIC_DUTY_BCD_SPL = cth_Amt;
                //BASIC_DUTY = Convert.ToDouble(BASIC_DUTY_BCD_SPL);

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

        //---------------SAPTA CALCULATION-// Enabled on 12Oct2017 with Bala ---------------------//

        bcd_rate = NOTN_SAPTA_CALC(bcd_rate);

        //--------------------------------------------------------------------------------------------

        //----------------Start 28Apr2015---------------------//
        if (NOTIFICATION_CUSTOMS_BCD_RATE != "")
        {
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

        INFRA_CESS = 0.00;
        NCD = 0.00;

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

        if (CVD_Rate >= CVD_Amt)
        {
            CVD = CVD_Rate;
        }
        else
        {
            CVD = CVD_Amt;
        }


        CESS = 0.00;
        //-----------GST IMPLEMENTATION ON 04JULY2017 ------------------//

        if (Connection.COMPANYID() == "182")
        {
            //CVD = CVD * 20;
            CVD = CVD + CVD_Amt;
        }

        if (Connection.COMPANYID() == "162" && CVD_NOTN == "012/2012" && PRODUCT_CVD_NOTN_SLNO == "51(ii)")
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

        //if (CETH_CVD_NIL_YN == "Y")//if (PRODUCT_CETH == "24029090" || PRODUCT_CETH == "24022090" || PRODUCT_CETH == "24039100" || PRODUCT_CETH == "24011090")
        //{
        //    CVD = 0.00;
        //    CVD_TOTAL = "0.00";
        //    PRODUCT_CVD_RATE = "0.00";
        //}

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
                                            * */

            Other_duty = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_OTHER_DUTY_RATE) / 100;
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

        Customs_Social_welfare = (BASIC_DUTY + Healthcess_RateVal + AIDC_Amt) * Convert.ToDouble(SOCIAL_WELFARE_RATE) / 100;

        SAFE_GUARD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SAFE_GUARD), 2).ToString("0.00"));

        if (Connection.COMPANYID() == "248")
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
        AIDC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AIDC_Amt), 1).ToString("0.00"));


        //newly added on 28-10-2020
        HEALTH_CESS_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Healthcess_RateVal), 1).ToString("0.00"));

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
                      * */
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


        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + Customs_Social_welfare + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Convert.ToDouble(HEALTH_CESS_TOTAL) + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));

        /*  HEALTH Cess & Social_welfare should be Show Duty & should not debited with License - implmntd on 29-10-2020 for Paramount sugg.by Subbu sir & Bala sir  */
        //if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
        //{
        //    if (HEALTH_CESS_CTH_CODE != "")
        //    {
        //        TOTAL_DEBIT_DUTY = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY + CVD + AddL_DUTY + NCD + Convert.ToDouble(Other_duty) + Convert.ToDouble(IGST_LEVY_TOTAL_DEBIT) + Convert.ToDouble(MERIT_TOTAL_ANTI_AMT) + Customs_SWS_HealthCess + Convert.ToDouble(AIDC_Amt)), 1).ToString("0.00"));
        //    }
        //}

        if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
        {
            HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
        }
        else
        {
            HttpContext.Current.Session["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY;
        }
    }


   
    public DataSet GET_ALL_NOTIFICATIONS_RATE(DataTable dt_all)
    {
        UserBO ObjUBO = new UserBO();

        System.Data.DataView view = new System.Data.DataView(dt_all);
        System.Data.DataTable selected = view.ToTable("Selected", true, "PRODUCT_CTH", "PRODUCT_CETH", "PRODUCT_BCD_NOTN"
            , "PRODUCT_BCD_SLNO", "PRODUCT_TARIFF_NOTN", "PRODUCT_TARIFF_SLNO", "PRODUCT_SAFEGUARD_NOTN", "PRODUCT_SAFEGUARD_SLNO", "PRODUCT_SAPTA_NOTN", "PRODUCT_SAPTA_SLNO"
            , "PRODUCT_AGGREGATE_DUTY_NOTN", "PRODUCT_AGGREGATE_DUTY_NOTN_SL", "IGST_LEVY_NOTN", "IGST_LEVY_SLNO", "IGST_LEVY_EXCEPTION_NOTN", "IGST_LEVY_EXCEPTION_SLNO"
            , "IGST_LEVY_COMPENSATION_CESS_NOTN", "IGST_LEVY_COMPENSATION_CESS_SLNO", "IGST_LEVY_EXCEPTION_CC_NOTN", "IGST_LEVY_EXCEPTION_CC_SLNO", "PRODUCT_CVD_NOTN"
            , "PRODUCT_CVD_SLNO", "SCHEME_CODE", "SCHEME_NOTN", "SCHEME_NOTN_SLNO", "ANTI_DUMPING_NOTN", "ANTI_DUMPING_NOTN_SLNO", "CTH_SLNO", "CTH_SUPPLIER_SLNO", "SOCIAL_WELFARE_NOTN", "SOCIAL_WELFARE_NOTN_SLNO",
            "AIDC_NOTN", "AIDC_NOTN_SLNO", "PRODUCT_ADDL_DUTY_NOTN", "PRODUCT_ADDL_DUTY_NOTN_SL");

        ObjUBO.Xml_D = Common_CS.ConvertDataTableToXML(selected);
        ObjUBO.flag = "Get_Notification_Rate";
        dt_All_Rates = IC.Get_Notifications_Rate(ObjUBO);

        return dt_All_Rates;
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
                  
                    //TOTAL_ANTIDUMP_AMT = qty * ADD_ANTI_AMTS * Convert.ToDouble(EXCHANGE_RATE);

                    /*
                    if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "381" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "382" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "385" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "461" || HttpContext.Current.Session["COMPANY_ID"].ToString() == "458")
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

                    */


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

                }
           
            }
            else
            {
                //error datatable here
                dt_error.Rows.Add(ANTI_DUMPING_NOTN, ANTI_DUMPING_NOTN_SLNO, INVOICE_SLNO, ITEM_SLNO);
            }
        }
    }


    public double Get_Individual_CIF_Amount_Calc_LICENSE(double INDIVIDUAL_CIF_AMOUNT)
    {
          
            INDIVITUAL_ASSESSABLE_AMOUNT = INDIVIDUAL_CIF_AMOUNT; 

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

                            INDIVITUAL_INSURANCE_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_SVB_AMOUNT) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                            INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;
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

                            INDIVITUAL_FREIGHT_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_SVB_AMOUNT) * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;
                            INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_FREIGHT_AMOUNT + REIMPORT_FREIGHT_AMOUNT;

                            INDIVITUAL_INSURANCE_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_SVB_AMOUNT) * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;
                            INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;
                        }
                        else
                        {
                            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE + INDIVITUAL_MISC_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_INSURANCE_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                        }
                    }
                    
                }
             
            }


            //*************************************** SVB Provisional /Final *** code copied from HTML Checklist on 31-12-2024
            //here SVB calc removed on 14-04-2026 sugg.by Bala sir - for centralized the above code
            //Back maintaining previous days
             //***************************************

            //INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT + INDIVITUAL_SVB_AMOUNT;
            //less_INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT * 1 / 100;

            if (HttpContext.Current.Session["btn_cif_click"] != "btn_Calc")
            {
                INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT + INDIVITUAL_SVB_AMOUNT;
                //less_INDIVITUAL_ASSESSABLE_AMOUNT = ((INDIVITUAL_ASSESSABLE_AMOUNT * 100) / 101); //modified on 15_Feb_2014 with Subbu sir
                less_INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT; //modified on 15_Feb_2014 with Subbu sir // Implemented on 29Sep2017 by Sathish 
            }
            else
            {
                //less_INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT * 1 / 100;
                less_INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT;
            }

            //LICENSE_DEBIT_AMT = ASSESABLE_VALUE - debit_amt; //Disabled and uploaded to server on 26_Feb_2014 with Subbu sir
            //LICENSE_DEBIT_AMT = Math.Round(less_INDIVITUAL_ASSESSABLE_AMOUNT + 0.00, 2);

            //HttpContext.Current.Session["INDIVITUAL_CIF_AMOUNT"] = less_INDIVITUAL_ASSESSABLE_AMOUNT;//BY BALA SIR TOLD 2 DIGIT AFTER POINT , ITS HIDEN.
            HttpContext.Current.Session["INDIVITUAL_CIF_AMOUNT"] = Math.Round(less_INDIVITUAL_ASSESSABLE_AMOUNT + 0.00, 2);

        return INDIVITUAL_ASSESSABLE_AMOUNT;
    }

    public double Get_Indivitual_Assesable_Value(DataTable dt_ReImport, int INV_SLNO, string INV_NO, string ITEM_SLNO, double TOTAL_ITEM_INVOICE_VALUE)
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
        DISCOUNT_AMOUNT = 0;

        double INV_MISC_CHARGES_CONVERT_INV = 0;
        double INV_MISC_CHARGES_CONVERT_fc = 0;
        double final_INV_MISC_CHARGES = 0.00;

        //INVOICE_VALUE_INR = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);

        //Get ITEM_TOTAL_AMOUNT for Split Individual FRT,INS Instead of INVOICE_VALUE - for FOC Items -- Implemented for Common - Sugg.by Bala sir on 14-03-2025
        //if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "2787" || COMPANY_ID == "2907")
        //{
           // INVOICE_VALUE_INR = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(INVOICE_EXRATE);
        //}
        //else
        //{
        //    INVOICE_VALUE_INR = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);
        //}

        //Newly Implemnted for 19-03-2025 - Sugg.by Bala sir
        //if (BE_TYPE == "Ex-Bond")
        //{
        //    INVOICE_VALUE_INR = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);
        //}
        //else
        //{
        //    INVOICE_VALUE_INR = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(INVOICE_EXRATE);
        //}


        //Again replace above code on 11-04-2025 - Sugg by Bala sir - Need to Implemet FOC Items
        INVOICE_VALUE_INR = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);

        if (INV_MISC_T_F == "T")
        {

            if (INVOICE_CURRENCY.ToUpper() == "JPY")
            {
                double invmisc_exrate1 = 0.00;
                invmisc_exrate1 = Convert.ToDouble(INV_MISC_EXRATE) / 100;
                INV_MISC_EXRATE = Convert.ToString(invmisc_exrate1);
            }

            INV_MISC_CHARGES_CONVERT_INV = Convert.ToDouble(INV_MISC_CHARGES) * Convert.ToDouble(INV_MISC_EXRATE);
            INV_MISC_CHARGES_CONVERT_fc = INV_MISC_CHARGES_CONVERT_INV / Convert.ToDouble(MIS_EXRATE);
            // INVOICE_VALUE_INR = INVOICE_VALUE_INR + INV_MISC_CHARGES_CONVERT_INV;
        }

        //************ CI Terms display in CHECKLIST ******************** 03/01/2018 

        if (TERMS == "CI")
        {

            string Cal_MIS_CHARGES;

            if (MIS_CHARGES == "" || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
            {
                if (D_AMOUNT != "" || M_AMOUNT != "" || N_AMOUNT != "")
                {
                    MIS_CURRENCY = INVOICE_CURRENCY;
                    Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
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
                        Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
                        MISC_AMOUNT = Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) * Convert.ToDouble(INVOICE_EXRATE);
                        //MIS_CHARGES = Convert.ToString(MISC_AMOUNT);
                    }
                    else
                    {
                        double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
                        Cal_MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
                        MIS_CURRENCY = INVOICE_CURRENCY;
                        Cal_MIS_CHARGES = Convert.ToString(Convert.ToDouble(Cal_MIS_CHARGES == string.Empty ? "0" : Cal_MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
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
            //MISC_AMOUNT = Convert.ToDouble(MIS_CHARGES) * Convert.ToDouble(MIS_EXRATE);// hide by chithra on 02-01-2020 for INVOICE MISC SPLIT CALC- AGILITY
            MISC_AMOUNT = (Convert.ToDouble(MIS_CHARGES) + Convert.ToDouble(INV_MISC_CHARGES_CONVERT_fc)) * Convert.ToDouble(MIS_EXRATE);
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

        //-----INSURANCE AMOUNT CAL--------------//
        if (MIS_INSURANCE_RATE != "0" && MIS_INSURANCE_RATE != "0.00" && MIS_INSURANCE_RATE != "0.0000" && MIS_INSURANCE_RATE != "")
        {
            if (INV_MISC_T_F != "T")
            {
                INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;
            }
            else
            {
                // INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (INV_MISC_CHARGES_CONVERT_INV + TOTAL_INVOICE_VALUE)) / 100;//01-02-2020
                INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;
            }

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
                FREIGHT_AMOUNT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;
            }
            else
            {
                //FREIGHT_AMOUNT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (INV_MISC_CHARGES_CONVERT_INV + TOTAL_INVOICE_VALUE)) / 100;
                FREIGHT_AMOUNT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;
            }
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


                    //this condition newly put for INDIA IMPEX - sugg.by Bala sir with Sathish Sir - for Air shipment SVB should add even FRT in Charges also
                    if (Connection.COMPANYID() == "656" || Connection.COMPANYID() == "1213")
                    {
                        INDIVITUAL_SVB_AMOUNT = (TOTAL_INVOICE_VALUE + MISC_AMOUNT) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                        freight_amt_air = (TOTAL_INVOICE_VALUE + MISC_AMOUNT + INDIVITUAL_SVB_AMOUNT) * 20 / 100;
                    }
                    else
                    {
                        freight_amt_air = (TOTAL_INVOICE_VALUE + MISC_AMOUNT) * 20 / 100;
                    }

                    FREIGHT_AMOUNT = Convert.ToDouble(MIS_FREIGHT_CHARGES) * Convert.ToDouble(MIS_FREIGHT_EXRATE);

                    if (SCHEME_CODE != "14")// for Restricted Items FRT shuould be take Actual Value- Capricorn 20-01-2025 sugg.by Bala sir - Only for License Debit
                    {
                        if (freight_amt_air < FREIGHT_AMOUNT)
                        {
                            FREIGHT_AMOUNT = freight_amt_air;
                        }
                        else
                        {
                            FREIGHT_AMOUNT = FREIGHT_AMOUNT;
                        }
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

        //-----REIMPORTT FREIGHT CAL--------------//

        //-----REIMPORTT INSURANCE CAL--------------//

        //INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * INSURANCE_AMOUNT;
        INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INVOICE_VALUE / INVOICE_VALUE_INR * INSURANCE_AMOUNT;// Claculation changed by Sathish with Bala/Ayisha on 25May2019
        INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;

        //-----REIMPORTT INSURANCE CAL--------------//

        //-----MISC CAL--------------//

        //INDIVITUAL_MISC_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * MISC_AMOUNT;
        INDIVITUAL_MISC_AMOUNT = INDIVITUAL_INVOICE_VALUE / INVOICE_VALUE_INR * MISC_AMOUNT;// Claculation changed by Sathish with Bala/Ayisha on 25May2019




        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "163")
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
            //      INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT) / TOTAL_INVOICE_VALUE * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES);
            //modified on 23aug2013 by subbu sir

            //modified on 28Dec2013 by subbu sir
            INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_INVOICE_VALUE) / TOTAL_INVOICE_VALUE * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES);
            //modified on 28Dec2013 by subbu sir


            //INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES)) / 100;
        }

        
        //-----CIF CAL--------------//
        //INDIVITUAL_CIF_AMOUNT = INDIVITUAL_TOTAL_AMOUNT + INDIVITUAL_HSS_AMOUNT + INDIVITUAL_SVB_AMOUNT;//07-04-2020 chithra -- svb amount add finally so hide here
        INDIVITUAL_CIF_AMOUNT = INDIVITUAL_TOTAL_AMOUNT + INDIVITUAL_HSS_AMOUNT;

        BE_TYPE = HttpContext.Current.Session["BE_TYPE"].ToString();
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

            //if (Igm_DATE != "" || Igm_DATE == null)
            //{
            //    if (IGMDate <= compareDate_IGM)
            //    {
            //        double LANDING_COST = (INDIVITUAL_CIF_AMOUNT * 1) / 100;
            //        INDIVITUAL_CIF_AMOUNT = INDIVITUAL_CIF_AMOUNT + LANDING_COST;
            //    }
            //}
        }

       

        INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_CIF_AMOUNT;

        //-----ASSESABLE CAL--------------//



        //INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT + INDIVITUAL_SVB_AMOUNT;

        if (HttpContext.Current.Session["btn_cif_click"].ToString() == "btn_Calc")
        {
            INDIVITUAL_ASSESSABLE_AMOUNT = Get_Individual_CIF_Amount_Calc_LICENSE(Convert.ToDouble(HttpContext.Current.Session["INDIVIDUAL_CIF_VALUE"].ToString()));
        }
        else
        {
            INDIVITUAL_ASSESSABLE_AMOUNT = Get_Individual_CIF_Amount_Calc_LICENSE(INDIVITUAL_CIF_AMOUNT);
           // INDIVITUAL_ASSESSABLE_AMOUNT = Get_Individual_CIF_Amount_Calc_LICENSE(INDIVITUAL_ASSESSABLE_AMOUNT);
        }

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
        else if (currency == "JPY" || currency == "KRW")
        {
            ExRate = Convert.ToString(Convert.ToDouble(ExRate) / 100);
        }
        return ExRate;
    }

    public DataSet RetrieveAll_CheckList_Scheme_Import_DS(string NOTN_NO, string NOTN_SLNO, string FLAG)
    {
        adm_Mas.SCHEME_IMPORT_CODE = PRODUCT_CTH;
        adm_Mas.PRODUCT_CETH = PRODUCT_CETH;
        adm_Mas.SCHEME_IMPORT_NAME = "";
        adm_Mas.SCHEME_NOTN = NOTN_NO;
        adm_Mas.SCHEME_NOTN_SLNO = NOTN_SLNO;
        adm_Mas.Name = FLAG;

        ds_bind = adm_Mas.RetrieveAll_CheckList_Scheme_Import();
        return ds_bind;
    }

    public string Get_PRODUCT_ADDL_SHEII_RATE(string PRODUCT_ADDL_SHEII_RATE)
    {
        string ADDL_SHEII_RATE = "";
        double SCHED11 = 0.00;
        string SCHED11_TOTAL = "";

        if (Convert.ToDecimal(PRODUCT_ADDL_SHEII_RATE) <= 0)
        {
            PRODUCT_ADDL_SHEII_RATE = "";
            ADDL_SHEII_RATE = PRODUCT_ADDL_SHEII_RATE;
        }
        else
        {
            //double SCHED11 = Convert.ToDouble(CVD_TOTAL) * Convert.ToDouble(PRODUCT_ADDL_SHEII_RATE) / 100;

            SCHED11 = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_ADDL_SHEII_RATE) / 100;
            SCHED11_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(SCHED11), 1).ToString("0.00"));

            if (PRODUCT_ADDL_SHEII_NOTN == "009/2006")
            {
                SCHED11_TOTAL = "0.00";
            }
            ADDL_SHEII_RATE = SCHED11_TOTAL;
        }
        return ADDL_SHEII_RATE;
    }

    public string get_PRODUCT_ADDL_GSI_RATE(string PRODUCT_ADDL_GSI_RATE)
    {
        string GSI_RATE="";
        double Gsi = 0.00;
        if (Convert.ToDecimal(PRODUCT_ADDL_GSI_RATE) <= 0)
        {
            PRODUCT_ADDL_GSI_RATE = "";
            GSI_RATE = PRODUCT_ADDL_GSI_RATE;
        }
        else
        {
            Gsi = Convert.ToDouble(CVD_TOTAL) * Convert.ToDouble(PRODUCT_ADDL_GSI_RATE) / 100;

            GSI_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Gsi), 1).ToString("0.00"));

            if (PRODUCT_ADDL_GSI_NOTN == "011/2006")
            {
                GSI_TOTAL = "0.00";
            }
            GSI_RATE = GSI_TOTAL;
        }
        return GSI_RATE;
    }

    public string Get_ADDL_TTA_RATE(string PRODUCT_ADDL_TTA_RATE)
    {
        string ADDL_TTA_RATE = "";
        string TTA_TOTAL = "";
        double Tta = 0.00;

        if (Convert.ToDecimal(PRODUCT_ADDL_TTA_RATE) <= 0)
        {
            PRODUCT_ADDL_TTA_RATE = "";
            ADDL_TTA_RATE = PRODUCT_ADDL_TTA_RATE;
        }
        else
        {
            Tta = Convert.ToDouble(CVD_TOTAL) * Convert.ToDouble(PRODUCT_ADDL_TTA_RATE) / 100;
            TTA_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Tta), 1).ToString("0.00"));

            if (PRODUCT_ADDL_TTA_NOTN == "031/2004")
            {
                TTA_TOTAL = "0.00";
            }
            ADDL_TTA_RATE = TTA_TOTAL;
        }
        return ADDL_TTA_RATE;
    }
}
