using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;
using BussinessObject;




public class eroyalmaster
{

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    public string str;
    public int result = 0, UPDATE_ID = 0;
    private string _startRowIndex, _maximumRows, _totalRows, _Eadcodeid, _EWorking_Period, _Ename, _Eadcode_iec_name, _Econsigneeid, _Econsignee_name, _Econscountry, _Eimp_state, _Ebuyerid, _Ebuyer_name
        , _Eexchange_id, _Eexchange_effect_dt_from, _Eexchange_effect_dt_to, _Eexchange_nont_no, _Eexchange_notn_date, _Eproduct_imp_id, _Eproduct_imp_description
        , _Eproduct_imp_cth, _Eproduct_imp_ceth, _Eproduct_imp_ritc, _Eimp_exp_id, _Eimp_exp_iecno, _Eimp_exp_brslno, _Eimp_exp_name, _Esupid, _Esup_name, _permission, _name
        , _companyname, _Invoice_Currency, _SVB_ID, _IMP_NAME, _SUPPLIER_NAME, _PRODUCT_NOTN, _PARTY_NAME, _SUP_BRANCH_SLNO
        , _IMPORTER_NAME, _IEC_NO, _BRANCH_NO, _COMMON_PART_NO, _ADCODE, _PO_TYPE, _PARTNAME, _TAX_BENIFIT_YN, _TAX_BENIFIT_PERC, _EPA_NOTIFI, _SIMS_YN, _FTA_YN
        , _Eproduct_imp_potype, _EExp_cli_mas_id, _EExp_cli_iec_name, _EXP_CLIENT_BRANCH_SLNO, _INSURANCE_RATE, _TAN_NUMBER, _TDS_CODE, _TDS_RATE
        , _NATURE_OF_TRANS, _NATURE_OF_PAYMENT, _VALUATION_METHOD;

    private string _Etransid, _Etrans_name;
    private string _PDF_COUNTRY_NAME, _COUNTRY_CODE, _COUNTRY_NAME, _PDF_PORTNAME, _PORT_NAME, _PORT_CODE;
    private string _Exp_Imp_Name, _From_Date, _To_Dates, _Modes, _Branches, _Client_Names, _Report_Type, _companyId;//kavi-ajith-karthi//
    public string companyId { get { return _companyId; } set { _companyId = value; } }//kavi-ajith-karthi//

    public string PDF_COUNTRY_NAME { get { return _PDF_COUNTRY_NAME; } set { _PDF_COUNTRY_NAME = value; } }
    public string COUNTRY_CODE { get { return _COUNTRY_CODE; } set { _COUNTRY_CODE = value; } }
    public string COUNTRY_NAME { get { return _COUNTRY_NAME; } set { _COUNTRY_NAME = value; } }

    public string PDF_PORTNAME { get { return _PDF_PORTNAME; } set { _PDF_PORTNAME = value; } }
    public string PORT_NAME { get { return _PORT_NAME; } set { _PORT_NAME = value; } }
    public string PORT_CODE { get { return _PORT_CODE; } set { _PORT_CODE = value; } }


    public string PRODUCT_NOTN { get { return _PRODUCT_NOTN; } set { _PRODUCT_NOTN = value; } }
    public string PARTY_NAME { get { return _PARTY_NAME; } set { _PARTY_NAME = value; } }
    public string SUP_BRANCH_SLNO { get { return _SUP_BRANCH_SLNO; } set { _SUP_BRANCH_SLNO = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }


    public string INSURANCE_RATE { get { return _INSURANCE_RATE; } set { _INSURANCE_RATE = value; } }
    public string TAN_NUMBER { get { return _TAN_NUMBER; } set { _TAN_NUMBER = value; } }
    public string TDS_CODE { get { return _TDS_CODE; } set { _TDS_CODE = value; } }
    public string TDS_RATE { get { return _TDS_RATE; } set { _TDS_RATE = value; } }

    public string NATURE_OF_TRANS { get { return _NATURE_OF_TRANS; } set { _NATURE_OF_TRANS = value; } }
    public string NATURE_OF_PAYMENT { get { return _NATURE_OF_PAYMENT; } set { _NATURE_OF_PAYMENT = value; } }
    public string VALUATION_METHOD { get { return _VALUATION_METHOD; } set { _VALUATION_METHOD = value; } }


    private string _PRODUCT_CVD_EDU_CESS_NOTN;
    private string _PRODUCT_CVD_EDU_CESS_NOTN_SL;
    private string _PRODUCT_CETH_EDU_CESS_RATE;
    private string _PRODUCT_CVD_SEC_EDU_CESS_NOTN;
    private string _PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL;
    private string _PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE;
    private string _EXP_STR_YN;
    private string _TYPE_OF_EXPORTER;
    private string _MARKS_NO;
    private string _EXP_DBK_DECL_CHK, _SEZ_ICEGATE_ID, _SEZ_PAN_NO, _SEZ_AP_ID, _SEZ_AP_NAME,_WAREHOUSE_CODE,_PAYMEMT_METHOD;

    //-------Start SingleWindow UserWise---------//
    private string _SW_ID;
    private string _SW_FROM_CTH;
    private string _SW_TO_CTH;
    private string _SW_AGENCY_CODE;

    public string SW_ID { get { return _SW_ID; } set { _SW_ID = value; } }
    public string SW_FROM_CTH { get { return _SW_FROM_CTH; } set { _SW_FROM_CTH = value; } }
    public string SW_TO_CTH { get { return _SW_TO_CTH; } set { _SW_TO_CTH = value; } }
    public string SW_AGENCY_CODE { get { return _SW_AGENCY_CODE; } set { _SW_AGENCY_CODE = value; } }
    //-------End SingleWindow UserWise---------//

    //-------Start Transport Master---------//
    private string _TRANS_ID;
    private string _TRANSPORT_NAME;
    private string _TRANSPORT_ID;
    private string _MODE;
    private string _TRANSPORT_DOC_NO;
    private string _VACHILE_NO;
    private string _TRANSPORT_DATE;
    private string _VACHILE_TYPE;
    private string _USER_GSTN_ID;

    
    public string TRANS_ID { get { return _TRANS_ID; } set { _TRANS_ID = value; } }
    public string TRANSPORT_NAME { get { return _TRANSPORT_NAME; } set { _TRANSPORT_NAME = value; } }
    public string TRANSPORT_ID { get { return _TRANSPORT_ID; } set { _TRANSPORT_ID = value; } }
    public string MODE { get { return _MODE; } set { _MODE = value; } }
    public string TRANSPORT_DOC_NO { get { return _TRANSPORT_DOC_NO; } set { _TRANSPORT_DOC_NO = value; } }
    public string VACHILE_NO { get { return _VACHILE_NO; } set { _VACHILE_NO = value; } }
    public string TRANSPORT_DATE { get { return _TRANSPORT_DATE; } set { _TRANSPORT_DATE = value; } }
    public string VACHILE_TYPE { get { return _VACHILE_TYPE; } set { _VACHILE_TYPE = value; } }
    public string USER_GSTN_ID { get { return _USER_GSTN_ID; } set { _USER_GSTN_ID = value; } }
    //-------End Transport Master---------//

    //--------EXP THIRD PARTY MASTER -----------------------------

    private string _THIRDPARTY_ID;
    private string _THIRDPARTY_NAME;
    private string _THIRDPARTY_ADD1;
    private string _THIRDPARTY_ADD2;
    private string _THIRDPARTY_CITY;
    private string _THIRDPARTY_COUNTRY_SUBDIVISION;
    private string _THIRDPARTY_COUNTRY_CODE;
    private string _TERMS_PLACE;
    private string _THIRDPARTY_PIN;
    private string _AEO_CODE;
    private string _AEO_COUNTRY;
    private string _AEO_ROLE;
    private string _BUYER_RELATED_Y_N;

    //--------EXP THIRD PARTY MASTER---------

    public string THIRDPARTY_ID { get { return _THIRDPARTY_ID; } set { _THIRDPARTY_ID = value; } }
    public string THIRDPARTY_NAME { get { return _THIRDPARTY_NAME; } set { _THIRDPARTY_NAME = value; } }
    public string THIRDPARTY_ADD1 { get { return _THIRDPARTY_ADD1; } set { _THIRDPARTY_ADD1 = value; } }
    public string THIRDPARTY_ADD2 { get { return _THIRDPARTY_ADD2; } set { _THIRDPARTY_ADD2 = value; } }
    public string THIRDPARTY_CITY { get { return _THIRDPARTY_CITY; } set { _THIRDPARTY_CITY = value; } }
    public string THIRDPARTY_COUNTRY_SUBDIVISION { get { return _THIRDPARTY_COUNTRY_SUBDIVISION; } set { _THIRDPARTY_COUNTRY_SUBDIVISION = value; } }
    public string THIRDPARTY_COUNTRY_CODE { get { return _THIRDPARTY_COUNTRY_CODE; } set { _THIRDPARTY_COUNTRY_CODE = value; } }
    public string TERMS_PLACE { get { return _TERMS_PLACE; } set { _TERMS_PLACE = value; } }
    public string THIRDPARTY_PIN { get { return _THIRDPARTY_PIN; } set { _THIRDPARTY_PIN = value; } }
    public string AEO_CODE { get { return _AEO_CODE; } set { _AEO_CODE = value; } }
    public string AEO_COUNTRY { get { return _AEO_COUNTRY; } set { _AEO_COUNTRY = value; } }
    public string AEO_ROLE { get { return _AEO_ROLE; } set { _AEO_ROLE = value; } }
    public string BUYER_RELATED_Y_N { get { return _BUYER_RELATED_Y_N; } set { _BUYER_RELATED_Y_N = value; } }


    //--------EXP THIRD PARTY MASTER---------

    public string PRODUCT_CVD_EDU_CESS_NOTN { get { return _PRODUCT_CVD_EDU_CESS_NOTN; } set { _PRODUCT_CVD_EDU_CESS_NOTN = value; } }
    public string PRODUCT_CVD_EDU_CESS_NOTN_SL { get { return _PRODUCT_CVD_EDU_CESS_NOTN_SL; } set { _PRODUCT_CVD_EDU_CESS_NOTN_SL = value; } }
    public string PRODUCT_CETH_EDU_CESS_RATE { get { return _PRODUCT_CETH_EDU_CESS_RATE; } set { _PRODUCT_CETH_EDU_CESS_RATE = value; } }

    public string PRODUCT_CVD_SEC_EDU_CESS_NOTN { get { return _PRODUCT_CVD_SEC_EDU_CESS_NOTN; } set { _PRODUCT_CVD_SEC_EDU_CESS_NOTN = value; } }
    public string PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL { get { return _PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL; } set { _PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL = value; } }
    public string PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE { get { return _PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE; } set { _PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE = value; } }


    public string SVB_ID { get { return _SVB_ID; } set { _SVB_ID = value; } }
    public string IMP_NAME { get { return _IMP_NAME; } set { _IMP_NAME = value; } }
    public string SUPPLIER_NAME { get { return _SUPPLIER_NAME; } set { _SUPPLIER_NAME = value; } }
    public string Invoice_Currency { get { return _Invoice_Currency; } set { _Invoice_Currency = value; } }
    public string EXP_STR_YN { get { return _EXP_STR_YN; } set { _EXP_STR_YN = value; } }

    public string TYPE_OF_EXPORTER { get { return _TYPE_OF_EXPORTER; } set { _TYPE_OF_EXPORTER = value; } }
    public string MARKS_NO { get { return _MARKS_NO; } set { _MARKS_NO = value; } }
    public string EXP_DBK_DECL_CHK { get { return _EXP_DBK_DECL_CHK; } set { _EXP_DBK_DECL_CHK = value; } }
    public string SEZ_ICEGATE_ID { get { return _SEZ_ICEGATE_ID; } set { _SEZ_ICEGATE_ID = value; } }
    public string SEZ_PAN_NO { get { return _SEZ_PAN_NO; } set { _SEZ_PAN_NO = value; } }
    public string SEZ_AP_ID { get { return _SEZ_AP_ID; } set { _SEZ_AP_ID = value; } }
    public string SEZ_AP_NAME { get { return _SEZ_AP_NAME; } set { _SEZ_AP_NAME = value; } }

    public string WAREHOUSE_CODE { get { return _WAREHOUSE_CODE; } set { _WAREHOUSE_CODE = value; } }
    public string PAYMEMT_METHOD { get { return _PAYMEMT_METHOD; } set { _PAYMEMT_METHOD = value; } }


    public DateTime fdt;
    public DateTime tdt;
    public DateTime _CEPA;

    private string _STANDARD_TYPE;
    public string STANDARD_TYPE { get { return _STANDARD_TYPE; } set { _STANDARD_TYPE = value; } }
    private string _TIN_NO;
    public string TIN_NO { get { return _TIN_NO; } set { _TIN_NO = value; } }

    private string _STATE_CODE;
    public string STATE_CODE { get { return _STATE_CODE; } set { _STATE_CODE = value; } }


    private string _PARTNO;

    public string PARTNO { get { return _PARTNO; } set { _PARTNO = value; } }

    private string _PRODUCT_ADDL_DUTY_RATE;
    public string PRODUCT_ADDL_DUTY_RATE { get { return _PRODUCT_ADDL_DUTY_RATE; } set { _PRODUCT_ADDL_DUTY_RATE = value; } }
    public string EExp_cli_mas_id { get { return _EExp_cli_mas_id; } set { _EExp_cli_mas_id = value; } }
    public string EExp_client_iec_name { get { return _EExp_cli_iec_name; } set { _EExp_cli_iec_name = value; } }
    public string EXP_CLIENT_BRANCH_SLNO { get { return _EXP_CLIENT_BRANCH_SLNO; } set { _EXP_CLIENT_BRANCH_SLNO = value; } }



    #region Insert,update Private Attributes

    //---------adcode--------------
    private string _ADCODE_ID;

    private string _ADCODE_IEC_CODE;
    private string _ADCODE_IEC_NAME;
    private string _ADCODE_IEC_ADCODE;
    private string _ADCODE_BANK_NAME;
    private string _ADCODE_BANK_ACCOUNT_NO;
    private string _ADCODE_BANK_ADD1;
    private string _ADCODE_BANK_ADD2;
    private string _ADCODE_BANK_CITY;
    private string _ADCODE_BANK_STATE;
    private string _ADCODE_BANK_PIN_CODE;
    private string _ADCODE_REMARKS;
    private string _IMPORT_ADCODE;
    private string _ADCODE_BRANCH_SLNO;
    private string _flag;

    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;

    private string _ADCODE_IFSC_CODE;
    //--------CONSIGNEE---------

    private string _CONSIGNEE_ID;
    private string _CONSIGNEE_NAME;
    private string _CONSIGNEE_ADD1;
    private string _CONSIGNEE_ADD2;
    private string _CONSIGNEE_ADD3;
    private string _CONSIGNEE_COUNTRY_NAME;
    private string _CONSIGNEE_COUNTRY_CODE;
    private string _CONSIGNEE_PIN_CODE;
    private string _CONSIGNEE_REMARKS;
    private string _CONSIGNEE_ADD4;
    private string _CONSIGNEE_BRANCHSLNO;

    //--------BUYER---------

    private string _BUYER_ID;
    private string _BUYER_NAME;
    private string _BUYER_ADD1;
    private string _BUYER_ADD2;
    private string _BUYER_ADD3;
    private string _BUYER_COUNTRY_NAME;
    private string _BUYER_COUNTRY_CODE;
    private string _BUYER_PIN_CODE;
    private string _BUYER_REMARKS;


    //---------SUPPLIERMASTER--------
    private string _SUP_ID;
    private string _SUP_NAME;
    private string _SUP_ADD1;
    private string _SUP_ADD2;
    private string _SUP_ADD3;
    private string _SUP_COUNTRY_NAME;
    private string _SUP_COUNTRY_CODE;
    private string _SUP_PIN_CODE;
    private string _SUP_REMARKS;
    //---------EXCHANGEMASTER--------  


    private string _EXCHANGE_ID;
    private string _EXCHANGE_EFFECT_DT_FROM;
    private string _EXCHANGE_EFFECT_DT_TO;
    private string _EXCHANGE_NONT_NO;
    private string _EXCHANGE_NOTN_DATE;
    private string _EXCHANGE_CUR_CODE;
    private string _EXCHANGE_NAME;
    private string _EXCHANGE_PER_UNIT;
    private string _EXCHANGE_RATE_IMPORT;
    private string _EXCHANGE_RATE_EXPORT;
    private string _EXCHANGE_S_OR_N;

    //---------IMP_EXP_EMASTER-------- 
    private string _IMP_EXP_ID;
    private string _IMP_EXP_NAME;
    private string _IMP_EXP_IECNO;
    private string _IMP_EXP_BRSLNO;
    private string _IMP_EXP_TYPE;
    private string _IMP_EXP_ADD1;
    private string _IMP_EXP_ADD2;
    private string _IMP_EXP_ADD3;
    private string _IMP_EXP_ADD4;
    private string _IMP_EXP_PIN_CODE;
    private string _IMP_EXP_CONTACT_PERSON;
    private string _IMP_EXP_PHONE;
    private string _IMP_EXP_FAX;
    private string _IMP_EXP_EMAIL;
    private string _IMP_EXP_BINNO;
    private string _IMP_EXP_REMARKS;
    private string _IMP_EXP_DRAWBACK_AC_NO;
    private string _IMP_EXP_PAN_NO;
    private string _GSTN_TYPE;
    private string _GSTN_ID;
    private string _DISTRICT;


    //---------private string _PRODUCTMASTER-------- 
    private string _PRODUCT_IMPORT_ID;
    private string _PRODUCT_DESCRIPTION;
    private string _PRODUCT_CODE;
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
    private string _PRODUCT_GENERAL_DESC;
    private string _PRODUCT_MANUFACTURER;
    private string _PRODUCT_BRAND;
    private string _PRODUCT_MODEL;
    private string _PRODUCT_END_USE;
    private string _PRODUCT_COUNTRY_ORIGIN;
    private string _PRODUCT_ACCESSORIES;
    private string _PRODUCT_REMARKS;
    private string _PRODUCT_SAPTA_NOTN;
    private string _PRODUCT_SAPTA_SLNO;
    private string _PRODUCT_SAPTA_RATE;
    private string _PRODUCT_TARIFF_NOTN;
    private string _PRODUCT_TARIFF_SLNO;
    private string _PRODUCT_TARIFF_QTY;
    private string _PRODUCT_TARIFF_AMOUNT;
    private string _PRODUCT_TARIFF_AMOUNT_UNIT;
    private string _RSP_NOTN_NO;
    private string _RSP_NOTN_SL_NO;

    private string _PRODUCT_CTH_INFRA_CESS_NOTN;
    private string _PRODUCT_CTH_INFRA_CESS_NOTN_SLNO;
    private string _PRODUCT_CTH_INFRA_CESS_RATE;

    private string _AIDC_NOTN, _AIDC_NOTN_SLNO, _AIDC_RATE, _CLIENT_NAME;
    private string _ANTI_DUMPING_NOTN;
    private string _ANTI_DUMPING_NOTN_SLNO;
    private string _CTH_SLNO;
    private string _CTH_SUPPLIER_SLNO;
    private string _CTH_QTY;

    private string _PRODUCT_IMP_EXP_NAME, _PRODUCT_IMP_EXP_IECNO, _PRODUCT_IMP_EXP_BRSLNO, _PRODUCT_ITEM_QTY_CODE, _PRODUCT_OTHER_DUTY_NOTN, _PRODUCT_OTHER_DUTY_SLNO,
                  _PRODUCT_OTHER_DUTY_RATE, _PRODUCT_OTHER_DUTY_SPL, _PRODUCT_OTHER_DUTY_UNIT, _PRODUCT_OTHER_DUTY_TYPE, _PRODUCT_INFO_MSR, _PRODUCT_INFO_UQC;
    //---------- IMPORT BOND MASTER -------------

    private string _ID;
    private string _BOND_NO;
    private string _BOND_DATE;
    private string _BOND_LOCATION;
    private string _BOND_TYPE;
    private string _BOND_AMT;
    private string _REMAINING_AMT;
    private string _BOND_REMARKS;

    //---------- IMPORT BOND MASTER -------------

    //SIMS report

    private string _STLNO, _FRMDATE, _TODATE, _REGNDATE, _JOBNO;
    public string STLNO { get { return _STLNO; } set { _STLNO = value; } }
    public string FRMDATE { get { return _FRMDATE; } set { _FRMDATE = value; } }
    public string TODATE { get { return _TODATE; } set { _TODATE = value; } }
    public string REGNDATE { get { return _REGNDATE; } set { _REGNDATE = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }

    //-------Start Exp Client Master--------// kavi & Ajith
    private string _EXP_CLIENT_ID;
    private string _EXP_CLIENT_IEC_NAME;
    private string _EXP_CLIENT_IEC_CODE;
    private string _EXP_CLIENT_REMARKS;
	private string _EXP_PDF_CLIENT_NAME;//Dec 19 OCR kavi & Ajith & karthik
    private string _EXP_PDF_COMPANY_ID;//Dec 19 OCR avi & Ajith & karthik

    //-------Start IMP Client Master--------// kavi & Ajith $ karthickraja

    private string _IMP_CLIENT_ID;
    private string _IMP_CLIENT_IEC_NAME;
    private string _IMP_CLIENT_IEC_CODE;
    private string _IMP_CLIENT_REMARKS;
    private string _IMP_PDF_CLIENT_NAME;
    private string _IMP_PDF_COMPANY_ID;
    private string _IMP_CLIENT_BRANCH_SLNO;


    public string EXP_CLIENT_ID { get { return _EXP_CLIENT_ID; } set { _EXP_CLIENT_ID = value; } }
    public string EXP_CLIENT_IEC_NAME { get { return _EXP_CLIENT_IEC_NAME; } set { _EXP_CLIENT_IEC_NAME = value; } }
    public string EXP_CLIENT_IEC_CODE { get { return _EXP_CLIENT_IEC_CODE; } set { _EXP_CLIENT_IEC_CODE = value; } }
    public string EXP_CLIENT_REMARKS { get { return _EXP_CLIENT_REMARKS; } set { _EXP_CLIENT_REMARKS = value; } }
    public string EXP_PDF_CLIENT_NAME { get { return _EXP_PDF_CLIENT_NAME; } set { _EXP_PDF_CLIENT_NAME = value; } }//Dec 19 kavi & Ajith & karthik
    public string EXP_PDF_COMPANY_ID { get { return _EXP_PDF_COMPANY_ID; } set { _EXP_PDF_COMPANY_ID = value; } }//Dec 19 kavi & Ajith & karthik

    //-------Start IMP Client Master--------// kavi & Ajith $ karthickraja

    public string IMP_CLIENT_ID { get { return _IMP_CLIENT_ID; } set { _IMP_CLIENT_ID = value; } }
    public string IMP_CLIENT_IEC_NAME { get { return _IMP_CLIENT_IEC_NAME; } set { _IMP_CLIENT_IEC_NAME = value; } }
    public string IMP_CLIENT_IEC_CODE { get { return _IMP_CLIENT_IEC_CODE; } set { _IMP_CLIENT_IEC_CODE = value; } }
    public string IMP_CLIENT_REMARKS { get { return _IMP_CLIENT_REMARKS; } set { _IMP_CLIENT_REMARKS = value; } }
    public string IMP_PDF_CLIENT_NAME { get { return _IMP_PDF_CLIENT_NAME; } set { _IMP_PDF_CLIENT_NAME = value; } }
    public string IMP_PDF_COMPANY_ID { get { return _IMP_PDF_COMPANY_ID; } set { _IMP_PDF_COMPANY_ID = value; } }
    public string IMP_CLIENT_BRANCH_SLNO { get { return _IMP_CLIENT_BRANCH_SLNO; } set { _IMP_CLIENT_BRANCH_SLNO = value; } }

    //--------------Start Annexure Default Master Fetch-----------------//
    private string _ANNEX_SEA_SEAL_TYPE;
    private string _ANNEX_SEA_FAC_STUFFED;
    private string _ANNEX_SEA_SAMPLE_ACCOM;
    private string _ANNEX_SEA_NATURE_OF_CARGO;
    private string _ANNEX_SEA_PKG_UNIT_CODE;
    private string _ANNEX_SEA_UNIT_MEASUREMENT;
    private string _ANNEX_SEA_CON_TYPE;
    private string _ANNEX_SEA_CON_SEALTYPE_INDICATOR;
    private string _ANNEX_AIR_NATURE_OF_CARGO;
    private string _ANNEX_AIR_GR_UNIT_CODE;
    private string _ANNEX_AIR_UNIT_CODE;

    public string ANNEX_SEA_SEAL_TYPE { get { return _ANNEX_SEA_SEAL_TYPE; } set { _ANNEX_SEA_SEAL_TYPE = value; } }
    public string ANNEX_SEA_FAC_STUFFED { get { return _ANNEX_SEA_FAC_STUFFED; } set { _ANNEX_SEA_FAC_STUFFED = value; } }
    public string ANNEX_SEA_SAMPLE_ACCOM { get { return _ANNEX_SEA_SAMPLE_ACCOM; } set { _ANNEX_SEA_SAMPLE_ACCOM = value; } }
    public string ANNEX_SEA_NATURE_OF_CARGO { get { return _ANNEX_SEA_NATURE_OF_CARGO; } set { _ANNEX_SEA_NATURE_OF_CARGO = value; } }
    public string ANNEX_SEA_UNIT_MEASUREMENT { get { return _ANNEX_SEA_UNIT_MEASUREMENT; } set { _ANNEX_SEA_UNIT_MEASUREMENT = value; } }
    public string ANNEX_SEA_PKG_UNIT_CODE { get { return _ANNEX_SEA_PKG_UNIT_CODE; } set { _ANNEX_SEA_PKG_UNIT_CODE = value; } }
    public string ANNEX_SEA_CON_TYPE { get { return _ANNEX_SEA_CON_TYPE; } set { _ANNEX_SEA_CON_TYPE = value; } }
    public string ANNEX_SEA_CON_SEALTYPE_INDICATOR { get { return _ANNEX_SEA_CON_SEALTYPE_INDICATOR; } set { _ANNEX_SEA_CON_SEALTYPE_INDICATOR = value; } }
    public string ANNEX_AIR_NATURE_OF_CARGO { get { return _ANNEX_AIR_NATURE_OF_CARGO; } set { _ANNEX_AIR_NATURE_OF_CARGO = value; } }
    public string ANNEX_AIR_GR_UNIT_CODE { get { return _ANNEX_AIR_GR_UNIT_CODE; } set { _ANNEX_AIR_GR_UNIT_CODE = value; } }
    public string ANNEX_AIR_UNIT_CODE { get { return _ANNEX_AIR_UNIT_CODE; } set { _ANNEX_AIR_UNIT_CODE = value; } }
    #endregion

    #region Attributes
    public string Eadcodeid { get { return _Eadcodeid; } set { _Eadcodeid = value; } }
    public string EWorking_Period { get { return _EWorking_Period; } set { _EWorking_Period = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string Eadcode_iec_name { get { return _Eadcode_iec_name; } set { _Eadcode_iec_name = value; } }
    public string Econsigneeid { get { return _Econsigneeid; } set { _Econsigneeid = value; } }
    public string Econsignee_name { get { return _Econsignee_name; } set { _Econsignee_name = value; } }
    public string Ebuyerid { get { return _Ebuyerid; } set { _Ebuyerid = value; } }
    public string Ebuyer_name { get { return _Ebuyer_name; } set { _Ebuyer_name = value; } }
    public string Econscountry { get { return _Econscountry; } set { _Econscountry = value; } }
    public string Eimp_state { get { return _Eimp_state; } set { _Eimp_state = value; } }

    public string Eexchange_id { get { return _Eexchange_id; } set { _Eexchange_id = value; } }
    public string Eexchange_effect_dt_from { get { return _Eexchange_effect_dt_from; } set { _Eexchange_effect_dt_from = value; } }
    public string Eexchange_effect_dt_to { get { return _Eexchange_effect_dt_to; } set { _Eexchange_effect_dt_to = value; } }
    public string Eexchange_nont_no { get { return _Eexchange_nont_no; } set { _Eexchange_nont_no = value; } }
    public string Eexchange_notn_date { get { return _Eexchange_notn_date; } set { _Eexchange_notn_date = value; } }

    public string Eproduct_imp_id { get { return _Eproduct_imp_id; } set { _Eproduct_imp_id = value; } }
    public string Eproduct_imp_description { get { return _Eproduct_imp_description; } set { _Eproduct_imp_description = value; } }
    public string Eproduct_imp_cth { get { return _Eproduct_imp_cth; } set { _Eproduct_imp_cth = value; } }
    public string Eproduct_imp_ceth { get { return _Eproduct_imp_ceth; } set { _Eproduct_imp_ceth = value; } }
    public string Eproduct_imp_ritc { get { return _Eproduct_imp_ritc; } set { _Eproduct_imp_ritc = value; } }


    public string Eimp_exp_id { get { return _Eimp_exp_id; } set { _Eimp_exp_id = value; } }
    public string Eimp_exp_iecno { get { return _Eimp_exp_iecno; } set { _Eimp_exp_iecno = value; } }
    public string Eimp_exp_brslno { get { return _Eimp_exp_brslno; } set { _Eimp_exp_brslno = value; } }
    public string Eimp_exp_name { get { return _Eimp_exp_name; } set { _Eimp_exp_name = value; } }

    public string Esupid { get { return _Esupid; } set { _Esupid = value; } }
    public string Esup_name { get { return _Esup_name; } set { _Esup_name = value; } }
    public string permission { get { return _permission; } set { _permission = value; } }
    public string name { get { return _name; } set { _name = value; } }
    public string companyname { get { return _companyname; } set { _companyname = value; } }

    public string Etransid { get { return _Etransid; } set { _Etransid = value; } }
    public string Etrans_name { get { return _Etrans_name; } set { _Etrans_name = value; } }
    public string Eproduct_imp_potype { get { return _Eproduct_imp_potype; } set { _Eproduct_imp_potype = value; } }

    public string Exp_Imp_Name { get { return _Exp_Imp_Name; } set { _Exp_Imp_Name = value; } }//OCR kavi-Ajith-Karthi//
    public string From_Date { get { return _From_Date; } set { _From_Date = value; } }
    public string To_Dates { get { return _To_Dates; } set { _To_Dates = value; } }
    public string Branches { get { return _Branches; } set { _Branches = value; } }
    public string Modes { get { return _Modes; } set { _Modes = value; } }
    public string Client_Names { get { return _Client_Names; } set { _Client_Names = value; } }
    public string Report_Type { get { return _Report_Type; } set { _Report_Type = value; } }//OCR kavi-Ajith-Karthi//
    

    #endregion

    #region Insert,update Attributes

    //---------adcode--------------
    public string ADCODE_ID { get { return _ADCODE_ID; } set { _ADCODE_ID = value; } }

    public string ADCODE_IEC_CODE { get { return _ADCODE_IEC_CODE; } set { _ADCODE_IEC_CODE = value; } }
    public string ADCODE_IEC_NAME { get { return _ADCODE_IEC_NAME; } set { _ADCODE_IEC_NAME = value; } }
    public string ADCODE_IEC_ADCODE { get { return _ADCODE_IEC_ADCODE; } set { _ADCODE_IEC_ADCODE = value; } }
    public string ADCODE_BANK_NAME { get { return _ADCODE_BANK_NAME; } set { _ADCODE_BANK_NAME = value; } }
    public string ADCODE_BANK_ACCOUNT_NO { get { return _ADCODE_BANK_ACCOUNT_NO; } set { _ADCODE_BANK_ACCOUNT_NO = value; } }
    public string ADCODE_BANK_ADD1 { get { return _ADCODE_BANK_ADD1; } set { _ADCODE_BANK_ADD1 = value; } }
    public string ADCODE_BANK_ADD2 { get { return _ADCODE_BANK_ADD2; } set { _ADCODE_BANK_ADD2 = value; } }
    public string ADCODE_BANK_CITY { get { return _ADCODE_BANK_CITY; } set { _ADCODE_BANK_CITY = value; } }
    public string ADCODE_BANK_STATE { get { return _ADCODE_BANK_STATE; } set { _ADCODE_BANK_STATE = value; } }
    public string ADCODE_BANK_PIN_CODE { get { return _ADCODE_BANK_PIN_CODE; } set { _ADCODE_BANK_PIN_CODE = value; } }
    public string ADCODE_REMARKS { get { return _ADCODE_REMARKS; } set { _ADCODE_REMARKS = value; } }

    public string IMPORT_ADCODE { get { return _IMPORT_ADCODE; } set { _IMPORT_ADCODE = value; } }
    public string ADCODE_BRANCH_SLNO { get { return _ADCODE_BRANCH_SLNO; } set { _ADCODE_BRANCH_SLNO = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string ADCODE_IFSC_CODE { get { return _ADCODE_IFSC_CODE; } set { _ADCODE_IFSC_CODE = value; } }

    //--------CONSIGNEE---------

    public string CONSIGNEE_ID { get { return _CONSIGNEE_ID; } set { _CONSIGNEE_ID = value; } }
    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADD1 { get { return _CONSIGNEE_ADD1; } set { _CONSIGNEE_ADD1 = value; } }
    public string CONSIGNEE_ADD2 { get { return _CONSIGNEE_ADD2; } set { _CONSIGNEE_ADD2 = value; } }
    public string CONSIGNEE_ADD3 { get { return _CONSIGNEE_ADD3; } set { _CONSIGNEE_ADD3 = value; } }
    public string CONSIGNEE_COUNTRY_NAME { get { return _CONSIGNEE_COUNTRY_NAME; } set { _CONSIGNEE_COUNTRY_NAME = value; } }
    public string CONSIGNEE_COUNTRY_CODE { get { return _CONSIGNEE_COUNTRY_CODE; } set { _CONSIGNEE_COUNTRY_CODE = value; } }
    public string CONSIGNEE_PIN_CODE { get { return _CONSIGNEE_PIN_CODE; } set { _CONSIGNEE_PIN_CODE = value; } }
    public string CONSIGNEE_REMARKS { get { return _CONSIGNEE_REMARKS; } set { _CONSIGNEE_REMARKS = value; } }

    public string CONSIGNEE_ADD4 { get { return _CONSIGNEE_ADD4; } set { _CONSIGNEE_ADD4 = value; } }
    public string CONSIGNEE_BRANCHSLNO { get { return _CONSIGNEE_BRANCHSLNO; } set { _CONSIGNEE_BRANCHSLNO = value; } }


    //--------BUYER---------

    public string BUYER_ID { get { return _BUYER_ID; } set { _BUYER_ID = value; } }
    public string BUYER_NAME { get { return _BUYER_NAME; } set { _BUYER_NAME = value; } }
    public string BUYER_ADD1 { get { return _BUYER_ADD1; } set { _BUYER_ADD1 = value; } }
    public string BUYER_ADD2 { get { return _BUYER_ADD2; } set { _BUYER_ADD2 = value; } }
    public string BUYER_ADD3 { get { return _BUYER_ADD3; } set { _BUYER_ADD3 = value; } }
    public string BUYER_COUNTRY_NAME { get { return _BUYER_COUNTRY_NAME; } set { _BUYER_COUNTRY_NAME = value; } }
    public string BUYER_COUNTRY_CODE { get { return _BUYER_COUNTRY_CODE; } set { _BUYER_COUNTRY_CODE = value; } }
    public string BUYER_PIN_CODE { get { return _BUYER_PIN_CODE; } set { _BUYER_PIN_CODE = value; } }
    public string BUYER_REMARKS { get { return _BUYER_REMARKS; } set { _BUYER_REMARKS = value; } }

    //---------SUPPLIERMASTER--------
    public string SUP_ID { get { return _SUP_ID; } set { _SUP_ID = value; } }
    public string SUP_NAME { get { return _SUP_NAME; } set { _SUP_NAME = value; } }
    public string SUP_ADD1 { get { return _SUP_ADD1; } set { _SUP_ADD1 = value; } }
    public string SUP_ADD2 { get { return _SUP_ADD2; } set { _SUP_ADD2 = value; } }
    public string SUP_ADD3 { get { return _SUP_ADD3; } set { _SUP_ADD3 = value; } }
    public string SUP_COUNTRY_NAME { get { return _SUP_COUNTRY_NAME; } set { _SUP_COUNTRY_NAME = value; } }
    public string SUP_COUNTRY_CODE { get { return _SUP_COUNTRY_CODE; } set { _SUP_COUNTRY_CODE = value; } }
    public string SUP_PIN_CODE { get { return _SUP_PIN_CODE; } set { _SUP_PIN_CODE = value; } }
    public string SUP_REMARKS { get { return _SUP_REMARKS; } set { _SUP_REMARKS = value; } }
    //---------EXCHANGEMASTER--------  


    public string EXCHANGE_ID { get { return _EXCHANGE_ID; } set { _EXCHANGE_ID = value; } }
    public string EXCHANGE_EFFECT_DT_FROM { get { return _EXCHANGE_EFFECT_DT_FROM; } set { _EXCHANGE_EFFECT_DT_FROM = value; } }
    public string EXCHANGE_EFFECT_DT_TO { get { return _EXCHANGE_EFFECT_DT_TO; } set { _EXCHANGE_EFFECT_DT_TO = value; } }
    public string EXCHANGE_NONT_NO { get { return _EXCHANGE_NONT_NO; } set { _EXCHANGE_NONT_NO = value; } }
    public string EXCHANGE_NOTN_DATE { get { return _EXCHANGE_NOTN_DATE; } set { _EXCHANGE_NOTN_DATE = value; } }
    public string EXCHANGE_CUR_CODE { get { return _EXCHANGE_CUR_CODE; } set { _EXCHANGE_CUR_CODE = value; } }
    public string EXCHANGE_NAME { get { return _EXCHANGE_NAME; } set { _EXCHANGE_NAME = value; } }
    public string EXCHANGE_PER_UNIT { get { return _EXCHANGE_PER_UNIT; } set { _EXCHANGE_PER_UNIT = value; } }
    public string EXCHANGE_RATE_IMPORT { get { return _EXCHANGE_RATE_IMPORT; } set { _EXCHANGE_RATE_IMPORT = value; } }
    public string EXCHANGE_RATE_EXPORT { get { return _EXCHANGE_RATE_EXPORT; } set { _EXCHANGE_RATE_EXPORT = value; } }
    public string EXCHANGE_S_OR_N { get { return _EXCHANGE_S_OR_N; } set { _EXCHANGE_S_OR_N = value; } }

    //---------IMP_EXP_EMASTER-------- 
    public string IMP_EXP_ID { get { return _IMP_EXP_ID; } set { _IMP_EXP_ID = value; } }
    public string IMP_EXP_NAME { get { return _IMP_EXP_NAME; } set { _IMP_EXP_NAME = value; } }
    public string IMP_EXP_IECNO { get { return _IMP_EXP_IECNO; } set { _IMP_EXP_IECNO = value; } }
    public string IMP_EXP_BRSLNO { get { return _IMP_EXP_BRSLNO; } set { _IMP_EXP_BRSLNO = value; } }
    public string IMP_EXP_TYPE { get { return _IMP_EXP_TYPE; } set { _IMP_EXP_TYPE = value; } }
    public string IMP_EXP_ADD1 { get { return _IMP_EXP_ADD1; } set { _IMP_EXP_ADD1 = value; } }
    public string IMP_EXP_ADD2 { get { return _IMP_EXP_ADD2; } set { _IMP_EXP_ADD2 = value; } }
    public string IMP_EXP_ADD3 { get { return _IMP_EXP_ADD3; } set { _IMP_EXP_ADD3 = value; } }
    public string IMP_EXP_ADD4 { get { return _IMP_EXP_ADD4; } set { _IMP_EXP_ADD4 = value; } }
    public string IMP_EXP_PIN_CODE { get { return _IMP_EXP_PIN_CODE; } set { _IMP_EXP_PIN_CODE = value; } }
    public string IMP_EXP_CONTACT_PERSON { get { return _IMP_EXP_CONTACT_PERSON; } set { _IMP_EXP_CONTACT_PERSON = value; } }
    public string IMP_EXP_PHONE { get { return _IMP_EXP_PHONE; } set { _IMP_EXP_PHONE = value; } }
    public string IMP_EXP_FAX { get { return _IMP_EXP_FAX; } set { _IMP_EXP_FAX = value; } }
    public string IMP_EXP_EMAIL { get { return _IMP_EXP_EMAIL; } set { _IMP_EXP_EMAIL = value; } }
    public string IMP_EXP_BINNO { get { return _IMP_EXP_BINNO; } set { _IMP_EXP_BINNO = value; } }
    public string IMP_EXP_REMARKS { get { return _IMP_EXP_REMARKS; } set { _IMP_EXP_REMARKS = value; } }
    public string IMP_EXP_DRAWBACK_AC_NO { get { return _IMP_EXP_DRAWBACK_AC_NO; } set { _IMP_EXP_DRAWBACK_AC_NO = value; } }

    public string IMP_EXP_PAN_NO { get { return _IMP_EXP_PAN_NO; } set { _IMP_EXP_PAN_NO = value; } }
    public string GSTN_TYPE { get { return _GSTN_TYPE; } set { _GSTN_TYPE = value; } }
    public string GSTN_ID { get { return _GSTN_ID; } set { _GSTN_ID = value; } }
    public string DISTRICT { get { return _DISTRICT; } set { _DISTRICT = value; } }



    //---------public string PRODUCTMASTER-------- 
    public string PRODUCT_IMPORT_ID { get { return _PRODUCT_IMPORT_ID; } set { _PRODUCT_IMPORT_ID = value; } }
    public string PRODUCT_DESCRIPTION { get { return _PRODUCT_DESCRIPTION; } set { _PRODUCT_DESCRIPTION = value; } }
    public string PRODUCT_CODE { get { return _PRODUCT_CODE; } set { _PRODUCT_CODE = value; } }
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
    public string PRODUCT_GENERAL_DESC { get { return _PRODUCT_GENERAL_DESC; } set { _PRODUCT_GENERAL_DESC = value; } }
    public string PRODUCT_MANUFACTURER { get { return _PRODUCT_MANUFACTURER; } set { _PRODUCT_MANUFACTURER = value; } }
    public string PRODUCT_BRAND { get { return _PRODUCT_BRAND; } set { _PRODUCT_BRAND = value; } }
    public string PRODUCT_MODEL { get { return _PRODUCT_MODEL; } set { _PRODUCT_MODEL = value; } }
    public string PRODUCT_END_USE { get { return _PRODUCT_END_USE; } set { _PRODUCT_END_USE = value; } }
    public string PRODUCT_COUNTRY_ORIGIN { get { return _PRODUCT_COUNTRY_ORIGIN; } set { _PRODUCT_COUNTRY_ORIGIN = value; } }
    public string PRODUCT_ACCESSORIES { get { return _PRODUCT_ACCESSORIES; } set { _PRODUCT_ACCESSORIES = value; } }
    public string PRODUCT_REMARKS { get { return _PRODUCT_REMARKS; } set { _PRODUCT_REMARKS = value; } }
    public string PRODUCT_SAPTA_NOTN { get { return _PRODUCT_SAPTA_NOTN; } set { _PRODUCT_SAPTA_NOTN = value; } }
    public string PRODUCT_SAPTA_SLNO { get { return _PRODUCT_SAPTA_SLNO; } set { _PRODUCT_SAPTA_SLNO = value; } }
    public string PRODUCT_SAPTA_RATE { get { return _PRODUCT_SAPTA_RATE; } set { _PRODUCT_SAPTA_RATE = value; } }
    public string PRODUCT_TARIFF_NOTN { get { return _PRODUCT_TARIFF_NOTN; } set { _PRODUCT_TARIFF_NOTN = value; } }
    public string PRODUCT_TARIFF_SLNO { get { return _PRODUCT_TARIFF_SLNO; } set { _PRODUCT_TARIFF_SLNO = value; } }
    public string PRODUCT_TARIFF_QTY { get { return _PRODUCT_TARIFF_QTY; } set { _PRODUCT_TARIFF_QTY = value; } }
    public string PRODUCT_TARIFF_AMOUNT { get { return _PRODUCT_TARIFF_AMOUNT; } set { _PRODUCT_TARIFF_AMOUNT = value; } }
    public string PRODUCT_TARIFF_AMOUNT_UNIT { get { return _PRODUCT_TARIFF_AMOUNT_UNIT; } set { _PRODUCT_TARIFF_AMOUNT_UNIT = value; } }
    public string RSP_NOTN_NO { get { return _RSP_NOTN_NO; } set { _RSP_NOTN_NO = value; } }
    public string RSP_NOTN_SL_NO { get { return _RSP_NOTN_SL_NO; } set { _RSP_NOTN_SL_NO = value; } }

    public string PRODUCT_CTH_INFRA_CESS_NOTN { get { return _PRODUCT_CTH_INFRA_CESS_NOTN; } set { _PRODUCT_CTH_INFRA_CESS_NOTN = value; } }
    public string PRODUCT_CTH_INFRA_CESS_NOTN_SLNO { get { return _PRODUCT_CTH_INFRA_CESS_NOTN_SLNO; } set { _PRODUCT_CTH_INFRA_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_CTH_INFRA_CESS_RATE { get { return _PRODUCT_CTH_INFRA_CESS_RATE; } set { _PRODUCT_CTH_INFRA_CESS_RATE = value; } }

    public string ANTI_DUMPING_NOTN { get { return _ANTI_DUMPING_NOTN; } set { _ANTI_DUMPING_NOTN = value; } }
    public string ANTI_DUMPING_NOTN_SLNO { get { return _ANTI_DUMPING_NOTN_SLNO; } set { _ANTI_DUMPING_NOTN_SLNO = value; } }
    public string CTH_SLNO { get { return _CTH_SLNO; } set { _CTH_SLNO = value; } }
    public string CTH_SUPPLIER_SLNO { get { return _CTH_SUPPLIER_SLNO; } set { _CTH_SUPPLIER_SLNO = value; } }
    public string CTH_QTY { get { return _CTH_QTY; } set { _CTH_QTY = value; } }
    public string AIDC_NOTN { get { return _AIDC_NOTN; } set { _AIDC_NOTN = value; } }
    public string AIDC_NOTN_SLNO { get { return _AIDC_NOTN_SLNO; } set { _AIDC_NOTN_SLNO = value; } }
    public string AIDC_RATE { get { return _AIDC_RATE; } set { _AIDC_RATE = value; } }
    public string CLIENT_NAME { get { return _CLIENT_NAME; } set { _CLIENT_NAME = value; } }




    public string PRODUCT_IMP_EXP_NAME { get { return _PRODUCT_IMP_EXP_NAME; } set { _PRODUCT_IMP_EXP_NAME = value; } }
    public string PRODUCT_IMP_EXP_IECNO { get { return _PRODUCT_IMP_EXP_IECNO; } set { _PRODUCT_IMP_EXP_IECNO = value; } }
    public string PRODUCT_IMP_EXP_BRSLNO { get { return _PRODUCT_IMP_EXP_BRSLNO; } set { _PRODUCT_IMP_EXP_BRSLNO = value; } }
    public string PRODUCT_ITEM_QTY_CODE { get { return _PRODUCT_ITEM_QTY_CODE; } set { _PRODUCT_ITEM_QTY_CODE = value; } }
    public string PRODUCT_OTHER_DUTY_NOTN { get { return _PRODUCT_OTHER_DUTY_NOTN; } set { _PRODUCT_OTHER_DUTY_NOTN = value; } }
    public string PRODUCT_OTHER_DUTY_SLNO { get { return _PRODUCT_OTHER_DUTY_SLNO; } set { _PRODUCT_OTHER_DUTY_SLNO = value; } }
    public string PRODUCT_OTHER_DUTY_RATE { get { return _PRODUCT_OTHER_DUTY_RATE; } set { _PRODUCT_OTHER_DUTY_RATE = value; } }
    public string PRODUCT_OTHER_DUTY_SPL { get { return _PRODUCT_OTHER_DUTY_SPL; } set { _PRODUCT_OTHER_DUTY_SPL = value; } }
    public string PRODUCT_OTHER_DUTY_UNIT { get { return _PRODUCT_OTHER_DUTY_UNIT; } set { _PRODUCT_OTHER_DUTY_UNIT = value; } }
    public string PRODUCT_OTHER_DUTY_TYPE { get { return _PRODUCT_OTHER_DUTY_TYPE; } set { _PRODUCT_OTHER_DUTY_TYPE = value; } }
    public string PRODUCT_INFO_MSR { get { return _PRODUCT_INFO_MSR; } set { _PRODUCT_INFO_MSR = value; } }
    public string PRODUCT_INFO_UQC { get { return _PRODUCT_INFO_UQC; } set { _PRODUCT_INFO_UQC = value; } }



    // LICENSE MASTER
    public string LICENSE_ID { get; set; }
    public string LICENSE_NO { get; set; }
    public string SCHEME_CODE { get; set; }
    public string REPORT_TYPE { get; set; }

    public string PORT_OF_LICENSE { get; set; }
    public string LICENSE_DATE { get; set; }
    public string LICENSE_R_SL_NO { get; set; }
    public string LICENSE_REG_DATE { get; set; }
    public string LICENSE_REG_TYPE { get; set; }
    public string LICENSE_ITEM_SL_NO { get; set; }
    public string LICENSE_ITEM_DESCRIPTION { get; set; }
    public string LICENSE_QTY { get; set; }
    public string LICENSE_UNIT { get; set; }
    public string LICENSE_TYPE { get; set; }
    public string LICENSE_USER_ID { get; set; }
    public string LICENSE_DATE_TIME { get; set; }
    public string LICENSE_STATUS { get; set; }
    public string LICENSE_BRANCH_CODE { get; set; }
    public string LICENSE_YEAR { get; set; }
    public string LICENSE_WORKING_PERIOD { get; set; }
    public string LICENSE_EXP_ITEM_SLNO { get; set; }
    public string LICENSE_ITEM_NO { get; set; }
    public string LIC_EXPIRED_DATE { get; set; }
    public string LICENSE_EXP_QTY { get; set; }
    public string LICENSE_EXP_UNIT { get; set; }


    
    // IMPORT BOND MASTER
    public string ID { get { return _ID; } set { _ID = value; } }
    public string BOND_NO { get { return _BOND_NO; } set { _BOND_NO = value; } }
    public string BOND_DATE { get { return _BOND_DATE; } set { _BOND_DATE = value; } }
    public string BOND_LOCATION { get { return _BOND_LOCATION; } set { _BOND_LOCATION = value; } }
    public string BOND_TYPE { get { return _BOND_TYPE; } set { _BOND_TYPE = value; } }
    public string BOND_AMT { get { return _BOND_AMT; } set { _BOND_AMT = value; } }
    public string REMAINING_AMT { get { return _REMAINING_AMT; } set { _REMAINING_AMT = value; } }
    public string BOND_REMARKS { get { return _BOND_REMARKS; } set { _BOND_REMARKS = value; } }


    public string PARTNAME { get { return _PARTNAME; } set { _PARTNAME = value; } }
    public string TAX_BENIFIT_YN { get { return _TAX_BENIFIT_YN; } set { _TAX_BENIFIT_YN = value; } }
    public string TAX_BENIFIT_PERC { get { return _TAX_BENIFIT_PERC; } set { _TAX_BENIFIT_PERC = value; } }
    public string EPA_NOTIFI { get { return _EPA_NOTIFI; } set { _EPA_NOTIFI = value; } }
    public string SIMS_YN { get { return _SIMS_YN; } set { _SIMS_YN = value; } }
    public string FTA_YN { get { return _FTA_YN; } set { _FTA_YN = value; } }
    public DateTime CEPA { get { return _CEPA; } set { _CEPA = value; } }

    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string PART_NO { get { return _COMMON_PART_NO; } set { _COMMON_PART_NO = value; } }
    public string ADCODE { get { return _ADCODE; } set { _ADCODE = value; } }
    public string PO_TYPE { get { return _PO_TYPE; } set { _PO_TYPE = value; } }
  
    #endregion



    #region Private_Attributes

    private string _PREFIX, _SUFFIX, _BANK_ID, _ACCOUNT_HOLDER,
                    _BANK_NAME,
                    _BRANCH_NAME,
                    _IFSC_CODE,
                    _ACCOUNT_NO,
                    _ACCOUNT_TYPE,
                    _SWIFT_CODE,
                    _AD_CODE,
                    _CURRENCY,
                    _OPENING_BALANCE,
                    _ADDRESS1,
                    _ADDRESS2,
                    _CITY,
                    _STATE,
                    _PINCODE,
                    _CONTACT_PERSON,
                    _CONTACT_NO,
                    _EMAIL_ID,
                    _DATE_TIME,
                    _STATUS,


                    _WORKING_PERIOD,
                    _MODIFIEDBY,
                    _MODIFIEDON
                    ;

    public int licen_slno;

    #endregion
    #region Public_Attributes

    public string PREFIX { get { return _PREFIX; } set { _PREFIX = value; } }
    public string SUFFIX { get { return _SUFFIX; } set { _SUFFIX = value; } }
    public string ACCOUNT_HOLDER { get { return _ACCOUNT_HOLDER; } set { _ACCOUNT_HOLDER = value; } }

    public string BANK_ID { get { return _BANK_ID; } set { _BANK_ID = value; } }
    public string BANK_NAME { get { return _BANK_NAME; } set { _BANK_NAME = value; } }
    public string BRANCH_NAME { get { return _BRANCH_NAME; } set { _BRANCH_NAME = value; } }
    public string IFSC_CODE { get { return _IFSC_CODE; } set { _IFSC_CODE = value; } }
    public string ACCOUNT_NO { get { return _ACCOUNT_NO; } set { _ACCOUNT_NO = value; } }
    public string ACCOUNT_TYPE { get { return _ACCOUNT_TYPE; } set { _ACCOUNT_TYPE = value; } }
    public string SWIFT_CODE { get { return _SWIFT_CODE; } set { _SWIFT_CODE = value; } }
    public string AD_CODE { get { return _AD_CODE; } set { _AD_CODE = value; } }
    public string CURRENCY { get { return _CURRENCY; } set { _CURRENCY = value; } }
    public string OPENING_BALANCE { get { return _OPENING_BALANCE; } set { _OPENING_BALANCE = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string CITY { get { return _CITY; } set { _CITY = value; } }
    public string STATE { get { return _STATE; } set { _STATE = value; } }
    public string PINCODE { get { return _PINCODE; } set { _PINCODE = value; } }
    public string CONTACT_PERSON { get { return _CONTACT_PERSON; } set { _CONTACT_PERSON = value; } }
    public string CONTACT_NO { get { return _CONTACT_NO; } set { _CONTACT_NO = value; } }
    public string EMAIL_ID { get { return _EMAIL_ID; } set { _EMAIL_ID = value; } }

    //public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string DATE_TIME { get { return _DATE_TIME; } set { _DATE_TIME = value; } }
    public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
    //public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }

    //public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string MODIFIEDBY { get { return _MODIFIEDBY; } set { _MODIFIEDBY = value; } }
    public string MODIFIEDON { get { return _MODIFIEDON; } set { _MODIFIEDON = value; } }
    //public string flag { get { return _flag; } set { _flag = value; } }

    //public int result, UPDATE_ID;


    #endregion

    #region BANK_MASTER_PURPOSE  //BANK MASTER PURPOSE
    private string _IFSCCODE, _SWIFTCCODE;
    public string IFSCCODE { get { return _IFSCCODE; } set { _IFSCCODE = value; } }
    public string SWIFTCCODE { get { return _SWIFTCCODE; } set { _SWIFTCCODE = value; } }
    #endregion

    #region Retrieve
    public DataSet RetrieveAll_Adcode_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ADCODE_ID", Eadcodeid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@ADCODE_IEC_NAME", Eadcode_iec_name);
            param[9] = new SqlParameter("@ADCODE_IEC_ADCODE", ADCODE_IEC_ADCODE);
            param[11] = new SqlParameter("@ADCODE_IEC_CODE", ADCODE_IEC_CODE);
            param[12] = new SqlParameter("@IMPORT_ADCODE", IMPORT_ADCODE);
            param[10] = new SqlParameter("@ADCODE_BANK_ACCOUNT_NO", ADCODE_BANK_ACCOUNT_NO);
            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODEMASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODEMASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_Adcode")
            {
                //s = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODEMASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODEMASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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

                //s = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODEMASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODEMASTER__SEARCH_SELECT", param);

                result = Convert.ToInt32(param[8].Value.ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Prevent IEC NO value not assign to CLIENT textbox
                        Ename = "1";
                        //Prevent IEC NO value not assign to CLIENT textbox

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

            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Consignee_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CONSIGNEE_ID", Econsigneeid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@CONSIGNEE_NAME", Econsignee_name);
            param[9] = new SqlParameter("@COUNTRY", Econscountry);
            param[10] = new SqlParameter("@BRANCH_SLNO", CONSIGNEE_BRANCHSLNO);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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

            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_EXP_THIRDPARTY_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@THIRDPARTY_ID", Econsigneeid);
            param[1] = new SqlParameter("@THIRDPARTY_NAME", Econsignee_name);
            param[2] = new SqlParameter("@Working_Period", EWorking_Period);

            param[3] = new SqlParameter("@name", Ename);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_THIRDPARTY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_THIRDPARTY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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

            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Buyer_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@BUYER_ID", Ebuyerid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@BUYER_NAME", Ebuyer_name);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_BUYER_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_BUYER_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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

            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Imp_exp_master()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@IMP_EXP_ID", Eimp_exp_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@IMP_EXP_IECNO", Eimp_exp_iecno);
            param[4] = new SqlParameter("@IMP_EXP_BRSLNO", Eimp_exp_brslno);
            param[5] = new SqlParameter("@IMP_EXP_NAME", Eimp_exp_name);


            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);

            param[9] = new SqlParameter("@maximumRows", maximumRows);

            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());


            }
            else if (Ename == "autoid")
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());
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
            else if (Ename == "Export_FlatFile_select_Type")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT", param);
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
            else if (Ename == "check_iecname" || Ename == "Check_select_br_slno")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());

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
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[10].Value.ToString());
                string s = param[7].Value.ToString();
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

            er.makeLog(ex.Message);
        }


        return ds;


    }


    public DataSet RetrieveAll_Imp_exp_master_STD_TYPE()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@IMP_EXP_ID", Eimp_exp_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@IMP_EXP_IECNO", Eimp_exp_iecno);
            param[4] = new SqlParameter("@IMP_EXP_BRSLNO", Eimp_exp_brslno);
            param[5] = new SqlParameter("@IMP_EXP_NAME", Eimp_exp_name);
            param[11] = new SqlParameter("@STANDARD_TYPE", STANDARD_TYPE);
            param[12] = new SqlParameter("@STATE", Eimp_state);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT_STD_TYPE", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            if (Ename == "Get_ID" || Ename == "select_conwithcode_STD" || Ename == "BIND_BRANCHES_STANDARD_TYPE" || Ename == "select_branch" || Ename == "Get_STATE_DISTRICT")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT_STD_TYPE", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT_STD_TYPE", param);
                result = Convert.ToInt32(param[10].Value.ToString());
                string s = param[7].Value.ToString();
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

            er.makeLog(ex.Message);
        }

        return ds;
    }

    public DataSet RetrieveAll_Exchange_master()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@EXCHANGE_ID", Eexchange_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", Eexchange_effect_dt_from);

            param[4] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", Eexchange_effect_dt_to);
            param[5] = new SqlParameter("@EXCHANGE_NONT_NO", Eexchange_nont_no);
            param[6] = new SqlParameter("@EXCHANGE_NOTN_DATE", Eexchange_notn_date);


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
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());


            }


            else
            {
                // ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_SELECT", param);
                string s = param[8].Value.ToString();
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

            er.makeLog(ex.Message);
        }

        return ds;


    }
    public DataSet RetrieveAll_Exchange_master_INV_Currency()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];


            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@INVOICE_CURRENCY", Invoice_Currency);


            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            if (Ename == "IMPORT_INVOICE_EX_RATE")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);


            }
            else if (Ename == "Ex_Rate")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);

                string s = param[8].Value.ToString();
                //result = Convert.ToInt32(param[11].Value.ToString());

            }

            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);

                string s = param[8].Value.ToString();
                //result = Convert.ToInt32(param[11].Value.ToString());

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

            er.makeLog(ex.Message);
        }


        return ds;


    }
    public DataSet RetrieveAll_Supplier_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@SUP_ID", Esupid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@SUP_NAME", Esup_name);
            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);
            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@COUNTRY", Econscountry);

            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIERMASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "Get_Sup_Name_GMMCO")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIERMASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIERMASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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

            er.makeLog(ex.Message);
        }


        return ds;

    }

    public DataSet RetrieveAll_Product_import_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@PRODUCT_IMPORT_ID", Eproduct_imp_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@PRODUCT_DESCRIPTION", Eproduct_imp_description);
            param[4] = new SqlParameter("@PRODUCT_CTH", Eproduct_imp_cth);
            param[5] = new SqlParameter("@PRODUCT_CETH", Eproduct_imp_ceth);
            param[6] = new SqlParameter("@PRODUCT_RITC", Eproduct_imp_ritc);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "Get_RSP_PARTNO_GMMCO" || Ename == "Get_Product_GMMCO" || Ename == "Get_Product_Details_All_GMMCO" || Ename == "Get_Product_PARTNO_CP" || Ename == "Get_Product_Thailand" || Ename == "Get_Product_Details_All_Thailand" || Ename == "Get_Product_PARTNO_Thailand" || Ename == "Get_Product_Details_All_INDEV")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT", param);
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
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet RetrieveAll_Product_import_MASTER_Fairmax()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@PRODUCT_IMPORT_ID", Eproduct_imp_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@PRODUCT_DESCRIPTION", Eproduct_imp_description);
            param[4] = new SqlParameter("@PRODUCT_CTH", Eproduct_imp_cth);
            param[5] = new SqlParameter("@PRODUCT_CETH", Eproduct_imp_ceth);
            param[6] = new SqlParameter("@PRODUCT_RITC", Eproduct_imp_ritc);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT_FAIRMAX", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "Get_RSP_PARTNO_GMMCO" || Ename == "Get_Product_GMMCO" || Ename == "Get_Product_Details_All_GMMCO" || Ename == "Get_Product_PARTNO_CP" || Ename == "Get_Product_Thailand" || Ename == "Get_Product_Details_All_Thailand" || Ename == "Get_Product_PARTNO_Thailand" || Ename == "Get_Product_Details_All_INDEV")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT_FAIRMAX", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT_FAIRMAX", param);
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
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Product_import_MASTER_RSP_ACCESS_SQL()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];

            //param[0] = new SqlParameter("@PRODUCT_IMPORT_ID", Eproduct_imp_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@PRODUCT_DESCRIPTION", Eproduct_imp_description);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            if (Ename == "Get_RSP_PARTNO_GMMCO" || Ename == "Get_Product_PARTNO_CP")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT_ACCESS_SQL", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT_ACCESS_SQL", param);
                result = Convert.ToInt32(param[4].Value.ToString());

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

            er.makeLog(ex.Message);
        }

        return ds;
    }

    public DataSet RetrieveAll_License_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@LICENSE_ID", LICENSE_ID);
            param[1] = new SqlParameter("@LICENSE_WORKING_PERIOD", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
            param[9] = new SqlParameter("@LICENSE_R_SL_NO", LICENSE_R_SL_NO);
            param[11] = new SqlParameter("@LICENSE_REG_TYPE", LICENSE_REG_TYPE);
            param[12] = new SqlParameter("@LICENSE_ITEM_DESCRIPTION", LICENSE_ITEM_DESCRIPTION);

            param[10] = new SqlParameter("@LICENSE_ITEM_SL_NO", LICENSE_ITEM_SL_NO);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;



            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "LICENSE_MASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_License")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "LICENSE_MASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "LICENSE_MASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Prevent IEC NO value not assign to CLIENT textbox
                        Ename = "1";
                        //Prevent IEC NO value not assign to CLIENT textbox
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
            er.makeLog(ex.Message);
        }
        return ds;
    }



    #endregion


    private string _COMMERCIAL_DETAILS_STATUS, _COMMERCIAL_TAX_STATENAME, _COMMERCIAL_TAX_STATECODE, _COMMERCIAL_TAX_TYPE, _COMMERCIAL_TAX_REGISTRATION_NO;
    public string COMMERCIAL_DETAILS_STATUS { get { return _COMMERCIAL_DETAILS_STATUS; } set { _COMMERCIAL_DETAILS_STATUS = value; } }
    public string COMMERCIAL_TAX_STATENAME { get { return _COMMERCIAL_TAX_STATENAME; } set { _COMMERCIAL_TAX_STATENAME = value; } }
    public string COMMERCIAL_TAX_STATECODE { get { return _COMMERCIAL_TAX_STATECODE; } set { _COMMERCIAL_TAX_STATECODE = value; } }
    public string COMMERCIAL_TAX_TYPE { get { return _COMMERCIAL_TAX_TYPE; } set { _COMMERCIAL_TAX_TYPE = value; } }
    public string COMMERCIAL_TAX_REGISTRATION_NO { get { return _COMMERCIAL_TAX_REGISTRATION_NO; } set { _COMMERCIAL_TAX_REGISTRATION_NO = value; } }

    private string _IGST_LEVY_NOTN, _IGST_LEVY_SLNO, _IGST_LEVY_RATE, _IGST_LEVY_SPL, _IGST_LEVY_UNIT, _IGST_LEVY_SPL_TYPE, _IGST_LEVY_EXCEPTION_NOTN, _IGST_LEVY_EXCEPTION_SLNO
, _IGST_LEVY_EXCEPTION_RATE, _IGST_LEVY_COMPENSATION_CESS_NOTN, _IGST_LEVY_COMPENSATION_CESS_SLNO, _IGST_LEVY_COMPENSATION_CESS_RATE, _IGST_LEVY_COMPENSATION_CESS_SPL
, _IGST_LEVY_COMPENSATION_CESS_UNIT, _IGST_LEVY_COMPENSATION_CESS_SPL_TYPE, _IGST_LEVY_EXCEPTION_CC_NOTN, _IGST_LEVY_EXCEPTION_CC_SLNO, _IGST_LEVY_EXCEPTION_CC_RATE
, _LEVY_EXCEMPTION_NOTN_TYPE, _LEVY_EXCEPTION_CC_NOTN_TYPE, _SOCIAL_WELFARE_NOTN, _SOCIAL_WELFARE_NOTN_SLNO, _SOCIAL_WELFARE_RATE;



    public string IGST_LEVY_NOTN { get { return _IGST_LEVY_NOTN; } set { _IGST_LEVY_NOTN = value; } }
    public string IGST_LEVY_SLNO { get { return _IGST_LEVY_SLNO; } set { _IGST_LEVY_SLNO = value; } }
    public string IGST_LEVY_RATE { get { return _IGST_LEVY_RATE; } set { _IGST_LEVY_RATE = value; } }
    public string IGST_LEVY_SPL { get { return _IGST_LEVY_SPL; } set { _IGST_LEVY_SPL = value; } }
    public string IGST_LEVY_UNIT { get { return _IGST_LEVY_UNIT; } set { _IGST_LEVY_UNIT = value; } }
    public string IGST_LEVY_SPL_TYPE { get { return _IGST_LEVY_SPL_TYPE; } set { _IGST_LEVY_SPL_TYPE = value; } }
    public string IGST_LEVY_EXCEPTION_NOTN { get { return _IGST_LEVY_EXCEPTION_NOTN; } set { _IGST_LEVY_EXCEPTION_NOTN = value; } }

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

    public string SOCIAL_WELFARE_NOTN { get { return _SOCIAL_WELFARE_NOTN; } set { _SOCIAL_WELFARE_NOTN = value; } }
    public string SOCIAL_WELFARE_NOTN_SLNO { get { return _SOCIAL_WELFARE_NOTN_SLNO; } set { _SOCIAL_WELFARE_NOTN_SLNO = value; } }
    public string SOCIAL_WELFARE_RATE { get { return _SOCIAL_WELFARE_RATE; } set { _SOCIAL_WELFARE_RATE = value; } }

    private string _CENTRAL_EXCISE_FLAG, _MANUFACTURER_PRODUCER, _M_P_GROWER_CODE, _M_P_GROWER_ADD1, _M_P_GROWER_ADD2, _M_P_GROWER_CITY, _M_P_GROWER_COUNTRY_SUBDIV
               , _M_P_GROWER_PIN, _M_P_GROWER_COUNTRY, _SOURCE_COUNTRY, _TRANSIT_COUNTRY, _ACCESSORY_STATUS, _INFRA_CESS_NOTN, _INFRA_CESS_NOTN_SL, _INFRA_CESS_NOTN_RATE;

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


    #region Insert,update
    public int Adcode_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@ADCODE_ID", ADCODE_ID);
            param[1] = new SqlParameter("@ADCODE_IEC_CODE", ADCODE_IEC_CODE);

            param[2] = new SqlParameter("@ADCODE_IEC_NAME", ADCODE_IEC_NAME);
            param[3] = new SqlParameter("@ADCODE_IEC_ADCODE", ADCODE_IEC_ADCODE);
            param[4] = new SqlParameter("@ADCODE_BANK_NAME", ADCODE_BANK_NAME);
            param[5] = new SqlParameter("@ADCODE_BANK_ACCOUNT_NO", ADCODE_BANK_ACCOUNT_NO);
            param[6] = new SqlParameter("@ADCODE_BANK_ADD1", ADCODE_BANK_ADD1);
            param[7] = new SqlParameter("@ADCODE_BANK_ADD2", ADCODE_BANK_ADD2);
            param[8] = new SqlParameter("@ADCODE_BANK_CITY", ADCODE_BANK_CITY);
            param[9] = new SqlParameter("@ADCODE_BANK_STATE", ADCODE_BANK_STATE);
            param[10] = new SqlParameter("@ADCODE_BANK_PIN_CODE", ADCODE_BANK_PIN_CODE);
            param[11] = new SqlParameter("@ADCODE_REMARKS", ADCODE_REMARKS);
            param[12] = new SqlParameter("@ADCODE_USER_ID", USER_ID);
            param[13] = new SqlParameter("@ADCODE_BRANCH_CODE", BRANCH_CODE);
            param[14] = new SqlParameter("@ADCODE_YEAR", YEAR);
            param[15] = new SqlParameter("@ADCODE_WORKING_PERIOD", EWorking_Period);
            param[16] = new SqlParameter("@Mflag", flag);
            param[21] = new SqlParameter("@IMPORT_ADCODE", IMPORT_ADCODE);
            param[22] = new SqlParameter("@ADCODE_BRANCH_SLNO", ADCODE_BRANCH_SLNO);
            param[23] = new SqlParameter("@ADCODE_IFSC_CODE", ADCODE_IFSC_CODE);

            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            param[20] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODE_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[17].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[20].Value.ToString());

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return result;

    }


    public int Consignee_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@CONSIGNEE_ID", CONSIGNEE_ID);
            param[1] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);

            param[2] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);
            param[3] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);
            param[4] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);
            param[5] = new SqlParameter("@CONSIGNEE_COUNTRY_NAME", CONSIGNEE_COUNTRY_NAME);
            param[6] = new SqlParameter("@CONSIGNEE_COUNTRY_CODE", CONSIGNEE_COUNTRY_CODE);
            param[7] = new SqlParameter("@CONSIGNEE_PIN_CODE", CONSIGNEE_PIN_CODE);
            param[8] = new SqlParameter("@CONSIGNEE_REMARKS", CONSIGNEE_REMARKS);
            param[17] = new SqlParameter("@CONSIGNEE_ADD4", CONSIGNEE_ADD4);
            param[18] = new SqlParameter("@CONSIGNEE_BRANCHSLNO", CONSIGNEE_BRANCHSLNO);

            param[9] = new SqlParameter("@CONSIGNEE_USER_ID", USER_ID);
            param[10] = new SqlParameter("@CONSIGNEE_BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@CONSIGNEE_YEAR", YEAR);
            param[12] = new SqlParameter("@CONSIGNEE_WORKING_PERIOD", EWorking_Period);
            param[13] = new SqlParameter("@Mflag", flag);

            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[14].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[16].Value.ToString());

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return result;

    }
    public int Buyer_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@BUYER_ID", BUYER_ID);
            param[1] = new SqlParameter("@BUYER_NAME", BUYER_NAME);

            param[2] = new SqlParameter("@BUYER_ADD1", BUYER_ADD1);
            param[3] = new SqlParameter("@BUYER_ADD2", BUYER_ADD2);
            param[4] = new SqlParameter("@BUYER_ADD3", BUYER_ADD3);
            param[5] = new SqlParameter("@BUYER_COUNTRY_NAME", BUYER_COUNTRY_NAME);
            param[6] = new SqlParameter("@BUYER_COUNTRY_CODE", BUYER_COUNTRY_CODE);
            param[7] = new SqlParameter("@BUYER_PIN_CODE", BUYER_PIN_CODE);
            param[8] = new SqlParameter("@BUYER_REMARKS", BUYER_REMARKS);

            param[9] = new SqlParameter("@BUYER_USER_ID", USER_ID);
            param[10] = new SqlParameter("@BUYER_BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@BUYER_YEAR", YEAR);
            param[12] = new SqlParameter("@BUYER_WORKING_PERIOD", EWorking_Period);

            param[13] = new SqlParameter("@Mflag", flag);
            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_BUYER_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[14].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[16].Value.ToString());

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }

    public int Supplier_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@SUP_ID", SUP_ID);
            param[1] = new SqlParameter("@SUP_NAME", SUP_NAME);
            param[2] = new SqlParameter("@SUP_BRANCH_SLNO", SUP_BRANCH_SLNO);
            param[4] = new SqlParameter("@SUP_ADD1", SUP_ADD1);
            param[5] = new SqlParameter("@SUP_ADD2", SUP_ADD2);
            param[6] = new SqlParameter("@SUP_ADD3", SUP_ADD3);
            param[7] = new SqlParameter("@SUP_COUNTRY_NAME", SUP_COUNTRY_NAME);
            param[8] = new SqlParameter("@SUP_COUNTRY_CODE", SUP_COUNTRY_CODE);
            param[9] = new SqlParameter("@SUP_PIN_CODE", SUP_PIN_CODE);
            param[10] = new SqlParameter("@SUP_REMARKS", SUP_REMARKS);

            param[11] = new SqlParameter("@SUP_USER_ID", USER_ID);
            param[12] = new SqlParameter("@SUP_BRANCH_CODE", BRANCH_CODE);
            param[13] = new SqlParameter("@SUP_YEAR", YEAR);
            param[14] = new SqlParameter("@SUP_WORKING_PERIOD", EWorking_Period);
            param[15] = new SqlParameter("@Mflag", flag);

            param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIER_MASTER_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[16].Value.ToString());
            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;
    }

    public int Exchange_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@EXCHANGE_ID", EXCHANGE_ID);
            param[1] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", DateTime.Parse(EXCHANGE_EFFECT_DT_FROM, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[2] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", DateTime.Parse(EXCHANGE_EFFECT_DT_TO, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[3] = new SqlParameter("@EXCHANGE_NONT_NO", EXCHANGE_NONT_NO);
            param[4] = new SqlParameter("@EXCHANGE_NOTN_DATE", EXCHANGE_NOTN_DATE);
            param[5] = new SqlParameter("@EXCHANGE_CUR_CODE", EXCHANGE_CUR_CODE);
            param[6] = new SqlParameter("@EXCHANGE_NAME", EXCHANGE_NAME);
            param[7] = new SqlParameter("@EXCHANGE_PER_UNIT", EXCHANGE_PER_UNIT);
            param[8] = new SqlParameter("@EXCHANGE_RATE_IMPORT", EXCHANGE_RATE_IMPORT);
            param[9] = new SqlParameter("@EXCHANGE_RATE_EXPORT", EXCHANGE_RATE_EXPORT);
            param[10] = new SqlParameter("@EXCHANGE_S_OR_N", EXCHANGE_S_OR_N);

            param[11] = new SqlParameter("@EXCHANGE_USER_ID", USER_ID);
            param[17] = new SqlParameter("@EXCHANGE_BRANCH_CODE", BRANCH_CODE);
            param[12] = new SqlParameter("@EXCHANGE_YEAR", YEAR);
            param[13] = new SqlParameter("@EXCHANGE_WORKING_PERIOD", EWorking_Period);
            param[14] = new SqlParameter("@Mflag", flag);

            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[15].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return result;
    }

    public int Imp_Exp_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@IMP_EXP_ID", IMP_EXP_ID);
            param[1] = new SqlParameter("@IMP_EXP_NAME", IMP_EXP_NAME);

            param[2] = new SqlParameter("@IMP_EXP_IECNO", IMP_EXP_IECNO);
            param[3] = new SqlParameter("@IMP_EXP_BRSLNO", IMP_EXP_BRSLNO);
            param[4] = new SqlParameter("@IMP_EXP_TYPE", IMP_EXP_TYPE);
            param[5] = new SqlParameter("@IMP_EXP_ADD1", IMP_EXP_ADD1);
            param[6] = new SqlParameter("@IMP_EXP_ADD2", IMP_EXP_ADD2);
            param[7] = new SqlParameter("@IMP_EXP_ADD3", IMP_EXP_ADD3);
            param[8] = new SqlParameter("@IMP_EXP_ADD4", IMP_EXP_ADD4);

            param[9] = new SqlParameter("@IMP_EXP_PIN_CODE", IMP_EXP_PIN_CODE);
            param[10] = new SqlParameter("@IMP_EXP_CONTACT_PERSON", IMP_EXP_CONTACT_PERSON);
            param[11] = new SqlParameter("@IMP_EXP_PHONE", IMP_EXP_PHONE);
            param[12] = new SqlParameter("@IMP_EXP_EMAIL", IMP_EXP_EMAIL);
            param[13] = new SqlParameter("@IMP_EXP_BINNO", IMP_EXP_BINNO);
            param[14] = new SqlParameter("@IMP_EXP_REMARKS", IMP_EXP_REMARKS);
            param[15] = new SqlParameter("@IMP_EXP_USER_ID", USER_ID);
            param[16] = new SqlParameter("@IMP_EXP_BRANCH_CODE", BRANCH_CODE);
            param[17] = new SqlParameter("@IMP_EXP_YEAR", YEAR);
            param[18] = new SqlParameter("@IMP_EXP_WORKING_PERIOD", EWorking_Period);
            param[24] = new SqlParameter("@IMP_EXP_DRAWBACK_AC_NO", IMP_EXP_DRAWBACK_AC_NO);

            param[25] = new SqlParameter("@IMP_EXP_PAN_NO", IMP_EXP_PAN_NO);


            param[22] = new SqlParameter("@IMP_EXP_FAX", IMP_EXP_FAX);
            param[19] = new SqlParameter("@Mflag", flag);

            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;

            param[23] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[20].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[23].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return result;

    }

    public int Imp_Exp_Master_Insert_update_STD()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[70];
            param[0] = new SqlParameter("@IMP_EXP_ID", IMP_EXP_ID);
            param[1] = new SqlParameter("@IMP_EXP_NAME", IMP_EXP_NAME);

            param[2] = new SqlParameter("@IMP_EXP_IECNO", IMP_EXP_IECNO);
            param[3] = new SqlParameter("@IMP_EXP_BRSLNO", IMP_EXP_BRSLNO);
            param[4] = new SqlParameter("@IMP_EXP_TYPE", IMP_EXP_TYPE);
            param[5] = new SqlParameter("@IMP_EXP_ADD1", IMP_EXP_ADD1);
            param[6] = new SqlParameter("@IMP_EXP_ADD2", IMP_EXP_ADD2);
            param[7] = new SqlParameter("@IMP_EXP_ADD3", IMP_EXP_ADD3);
            param[8] = new SqlParameter("@IMP_EXP_ADD4", IMP_EXP_ADD4);

            param[9] = new SqlParameter("@IMP_EXP_PIN_CODE", IMP_EXP_PIN_CODE);
            param[10] = new SqlParameter("@IMP_EXP_CONTACT_PERSON", IMP_EXP_CONTACT_PERSON);
            param[11] = new SqlParameter("@IMP_EXP_PHONE", IMP_EXP_PHONE);
            param[12] = new SqlParameter("@IMP_EXP_EMAIL", IMP_EXP_EMAIL);
            param[13] = new SqlParameter("@IMP_EXP_BINNO", IMP_EXP_BINNO);
            param[14] = new SqlParameter("@IMP_EXP_REMARKS", IMP_EXP_REMARKS);
            param[15] = new SqlParameter("@IMP_EXP_USER_ID", USER_ID);
            param[16] = new SqlParameter("@IMP_EXP_BRANCH_CODE", BRANCH_CODE);
            param[17] = new SqlParameter("@IMP_EXP_YEAR", YEAR);
            param[18] = new SqlParameter("@IMP_EXP_WORKING_PERIOD", EWorking_Period);
            param[24] = new SqlParameter("@IMP_EXP_DRAWBACK_AC_NO", IMP_EXP_DRAWBACK_AC_NO);

            param[25] = new SqlParameter("@IMP_EXP_PAN_NO", IMP_EXP_PAN_NO);

            param[26] = new SqlParameter("@STANDARD_TYPE", STANDARD_TYPE);
            param[27] = new SqlParameter("@TIN_NO", TIN_NO);
            param[28] = new SqlParameter("@STATE_CODE", STATE_CODE);


            param[22] = new SqlParameter("@IMP_EXP_FAX", IMP_EXP_FAX);
            param[19] = new SqlParameter("@Mflag", flag);

            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;

            param[23] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;

            param[30] = new SqlParameter("@EXP_STR_YN", EXP_STR_YN);
            param[31] = new SqlParameter("@TYPE_OF_EXPORTER", TYPE_OF_EXPORTER);
            param[32] = new SqlParameter("@MARKS_NO", MARKS_NO);

            param[33] = new SqlParameter("@COMMERCIAL_DETAILS_STATUS", COMMERCIAL_DETAILS_STATUS);
            param[34] = new SqlParameter("@COMMERCIAL_TAX_STATENAME", COMMERCIAL_TAX_STATENAME);
            param[35] = new SqlParameter("@COMMERCIAL_TAX_STATECODE", COMMERCIAL_TAX_STATECODE);
            param[36] = new SqlParameter("@COMMERCIAL_TAX_TYPE", COMMERCIAL_TAX_TYPE);
            param[37] = new SqlParameter("@COMMERCIAL_TAX_REGISTRATION_NO", COMMERCIAL_TAX_REGISTRATION_NO);

            param[38] = new SqlParameter("@GSTN_TYPE", GSTN_TYPE);
            param[39] = new SqlParameter("@GSTN_ID", GSTN_ID);
            param[40] = new SqlParameter("@DISTRICT", DISTRICT);
            param[41] = new SqlParameter("@EXP_DBK_DECL_CHK", EXP_DBK_DECL_CHK);
            param[42] = new SqlParameter("@SEZ_ICEGATE_ID", SEZ_ICEGATE_ID);
            param[43] = new SqlParameter("@SEZ_PAN_NO", SEZ_PAN_NO);
            param[44] = new SqlParameter("@SEZ_AP_ID", SEZ_AP_ID);
            param[45] = new SqlParameter("@SEZ_AP_NAME", SEZ_AP_NAME);
            param[46] = new SqlParameter("@WAREHOUSE_CODE", WAREHOUSE_CODE);
            param[47] = new SqlParameter("@PAYMEMT_METHOD", PAYMEMT_METHOD);
            param[48] = new SqlParameter("@ITEM_END_USE", PRODUCT_END_USE);
            param[49] = new SqlParameter("@CLIENT_INSURANCE_RATE", INSURANCE_RATE);
            param[50] = new SqlParameter("@TAN_NUMBER", TAN_NUMBER);
            param[51] = new SqlParameter("@TDS_CODE", TDS_CODE);
            param[52] = new SqlParameter("@TDS_RATE", TDS_RATE);

            param[53] = new SqlParameter("@NATURE_OF_TRANS", NATURE_OF_TRANS); // Added by shanthini on 12-06-2026
            param[54] = new SqlParameter("@NATURE_OF_PAYMENT", NATURE_OF_PAYMENT);
            param[55] = new SqlParameter("@VALUATION_METHOD", VALUATION_METHOD);

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_INSERT_UPDATE_STD", param);
            result = Convert.ToInt32(param[20].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[23].Value.ToString());

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }
        return result;

    }


    public int Product_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[190];

            param[0] = new SqlParameter("@PRODUCT_IMPORT_ID", PRODUCT_IMPORT_ID);
            param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", PRODUCT_DESCRIPTION);
            param[2] = new SqlParameter("@PRODUCT_CODE", PRODUCT_CODE);
            param[3] = new SqlParameter("@PRODUCT_RITC", PRODUCT_RITC);
            param[4] = new SqlParameter("@PRODUCT_CTH", PRODUCT_CTH);
            param[5] = new SqlParameter("@PRODUCT_BCD_NOTN", PRODUCT_BCD_NOTN);
            param[6] = new SqlParameter("@PRODUCT_BCD_SLNO", PRODUCT_BCD_SLNO);
            param[7] = new SqlParameter("@PRODUCT_BCD_RATE", PRODUCT_BCD_RATE);
            param[8] = new SqlParameter("@PRODUCT_BCD_SPL", PRODUCT_BCD_SPL);
            param[9] = new SqlParameter("@PRODUCT_BCD_UNIT", PRODUCT_BCD_UNIT);
            param[10] = new SqlParameter("@PRODUCT_BCD_SPL_TYPE", PRODUCT_BCD_SPL_TYPE);
            param[11] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN", PRODUCT_ADDL_DUTY_NOTN);
            param[12] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN_SL", PRODUCT_ADDL_DUTY_NOTN_SL);
            param[13] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN", PRODUCT_EDU_CESS_NOTN);
            param[14] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN_SL", PRODUCT_EDU_CESS_NOTN_SL);
            param[15] = new SqlParameter("@PRODUCT_EDU_CESS_RATE", PRODUCT_EDU_CESS_RATE);
            param[16] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN", PRODUCT_SEC_EDU_CESS_NOTN);
            param[17] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN_SL", PRODUCT_SEC_EDU_CESS_NOTN_SL);
            param[18] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_RATE", PRODUCT_SEC_EDU_CESS_RATE);
            param[19] = new SqlParameter("@PRODUCT_NCD_NOTN", PRODUCT_NCD_NOTN);
            param[20] = new SqlParameter("@PRODUCT_NCD_SLNO", PRODUCT_NCD_SLNO);
            param[21] = new SqlParameter("@PRODUCT_NCD_RATE", PRODUCT_NCD_RATE);
            param[22] = new SqlParameter("@PRODUCT_NCD_SPL", PRODUCT_NCD_SPL);
            param[23] = new SqlParameter("@PRODUCT_NCD_UNIT", PRODUCT_NCD_UNIT);
            param[24] = new SqlParameter("@PRODUCT_NCD_SPL_TYPE", PRODUCT_NCD_SPL_TYPE);
            param[25] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN", PRODUCT_AGGREGATE_DUTY_NOTN);
            param[26] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_SL", PRODUCT_AGGREGATE_DUTY_NOTN_SL);
            param[27] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_RATE", PRODUCT_AGGREGATE_DUTY_NOTN_RATE);
            param[28] = new SqlParameter("@PRODUCT_SAFEGUARD_NOTN", PRODUCT_SAFEGUARD_NOTN);
            param[29] = new SqlParameter("@PRODUCT_SAFEGUARD_SLNO", PRODUCT_SAFEGUARD_SLNO);
            param[30] = new SqlParameter("@PRODUCT_SAFEGUARD_RATE", PRODUCT_SAFEGUARD_RATE);
            param[31] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL", PRODUCT_SAFEGUARD_SPL);
            param[32] = new SqlParameter("@PRODUCT_SAFEGUARD_UNIT", PRODUCT_SAFEGUARD_UNIT);
            param[33] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL_TYPE", PRODUCT_SAFEGUARD_SPL_TYPE);
            param[34] = new SqlParameter("@PRODUCT_CETH", PRODUCT_CETH);
            param[35] = new SqlParameter("@PRODUCT_MRP_YN", PRODUCT_MRP_YN);
            param[36] = new SqlParameter("@PRODUCT_MRP_SL_NO", PRODUCT_MRP_SL_NO);
            param[37] = new SqlParameter("@PRODUCT_MRP_AMOUNT", PRODUCT_MRP_AMOUNT);
            param[38] = new SqlParameter("@PRODUCT_MRP_ABT_RATE", PRODUCT_MRP_ABT_RATE);
            param[39] = new SqlParameter("@PRODUCT_CVD_NOTN", PRODUCT_CVD_NOTN);
            param[40] = new SqlParameter("@PRODUCT_CVD_SLNO", PRODUCT_CVD_SLNO);
            param[41] = new SqlParameter("@PRODUCT_CVD_RATE", PRODUCT_CVD_RATE);
            param[42] = new SqlParameter("@PRODUCT_CVD_SPL", PRODUCT_CVD_SPL);
            param[43] = new SqlParameter("@PRODUCT_CVD_UNIT", PRODUCT_CVD_UNIT);
            param[44] = new SqlParameter("@PRODUCT_CVD_SPL_TYPE", PRODUCT_CVD_SPL_TYPE);
            param[45] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_RATE", PRODUCT_CVD_EDU_CESS_RATE);
            param[46] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_RATE", PRODUCT_CVD_SEC_EDU_CESS_RATE);
            param[47] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN", PRODUCT_ADDL5_SIA_NOTN);
            param[48] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN_SL", PRODUCT_ADDL5_SIA_NOTN_SL);
            param[49] = new SqlParameter("@PRODUCT_ADDL5_SIA_RATE", PRODUCT_ADDL5_SIA_RATE);
            param[50] = new SqlParameter("@PRODUCT_ADDL_GSI_NOTN", PRODUCT_ADDL_GSI_NOTN);
            param[51] = new SqlParameter("@PRODUCT_ADDL_GSI_SLNO", PRODUCT_ADDL_GSI_SLNO);
            param[52] = new SqlParameter("@PRODUCT_ADDL_GSI_RATE", PRODUCT_ADDL_GSI_RATE);
            param[53] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL", PRODUCT_ADDL_GSI_SPL);
            param[54] = new SqlParameter("@PRODUCT_ADDL_GSI_UNIT", PRODUCT_ADDL_GSI_UNIT);
            param[55] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL_TYPE", PRODUCT_ADDL_GSI_SPL_TYPE);
            param[56] = new SqlParameter("@PRODUCT_ADDL_SHEII_NOTN", PRODUCT_ADDL_SHEII_NOTN);
            param[57] = new SqlParameter("@PRODUCT_ADDL_SHEII_SLNO", PRODUCT_ADDL_SHEII_SLNO);
            param[58] = new SqlParameter("@PRODUCT_ADDL_SHEII_RATE", PRODUCT_ADDL_SHEII_RATE);
            param[59] = new SqlParameter("@PRODUCT_ADDL_SHEII_SPL", PRODUCT_ADDL_SHEII_SPL);
            param[60] = new SqlParameter("@PRODUCT_ADDL_SHEII_UNIT", PRODUCT_ADDL_SHEII_UNIT);
            param[61] = new SqlParameter("@PRODUCT_ADDL_SHEII_TYPE", PRODUCT_ADDL_SHEII_TYPE);
            param[62] = new SqlParameter("@PRODUCT_ADDL_TTA_NOTN", PRODUCT_ADDL_TTA_NOTN);
            param[63] = new SqlParameter("@PRODUCT_ADDL_TTA_SLNO", PRODUCT_ADDL_TTA_SLNO);
            param[64] = new SqlParameter("@PRODUCT_ADDL_TTA_RATE", PRODUCT_ADDL_TTA_RATE);
            param[65] = new SqlParameter("@PRODUCT_ADDL_TTA_SPL", PRODUCT_ADDL_TTA_SPL);
            param[66] = new SqlParameter("@PRODUCT_ADDL_TTA_UNIT", PRODUCT_ADDL_TTA_UNIT);
            param[67] = new SqlParameter("@PRODUCT_ADDL_TTA_TYPE", PRODUCT_ADDL_TTA_TYPE);
            param[68] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_NOTN", PRODUCT_ADDL_HEALTH_CESS_NOTN);
            param[69] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SLNO", PRODUCT_ADDL_HEALTH_CESS_SLNO);
            param[70] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_RATE", PRODUCT_ADDL_HEALTH_CESS_RATE);
            param[71] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SPL", PRODUCT_ADDL_HEALTH_CESS_SPL);
            param[72] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_UNIT", PRODUCT_ADDL_HEALTH_CESS_UNIT);
            param[73] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_TYPE", PRODUCT_ADDL_HEALTH_CESS_TYPE);
            param[74] = new SqlParameter("@PRODUCT_CESS_NOTN", PRODUCT_CESS_NOTN);
            param[75] = new SqlParameter("@PRODUCT_CESS_SLNO", PRODUCT_CESS_SLNO);
            param[76] = new SqlParameter("@PRODUCT_CESS_RATE", PRODUCT_CESS_RATE);
            param[77] = new SqlParameter("@PRODUCT_CESS_SPL", PRODUCT_CESS_SPL);
            param[78] = new SqlParameter("@PRODUCT_CESS_UNIT", PRODUCT_CESS_UNIT);
            param[79] = new SqlParameter("@PRODUCT_CESS_TYPE", PRODUCT_CESS_TYPE);
            param[80] = new SqlParameter("@PRODUCT_GENERAL_DESC", PRODUCT_GENERAL_DESC);
            param[81] = new SqlParameter("@PRODUCT_MANUFACTURER", PRODUCT_MANUFACTURER);
            param[82] = new SqlParameter("@PRODUCT_BRAND", PRODUCT_BRAND);
            param[83] = new SqlParameter("@PRODUCT_MODEL", PRODUCT_MODEL);
            param[84] = new SqlParameter("@PRODUCT_END_USE", PRODUCT_END_USE);
            param[85] = new SqlParameter("@PRODUCT_COUNTRY_ORIGIN", PRODUCT_COUNTRY_ORIGIN);
            param[86] = new SqlParameter("@PRODUCT_ACCESSORIES", PRODUCT_ACCESSORIES);
            param[87] = new SqlParameter("@PRODUCT_REMARKS", PRODUCT_REMARKS);
            param[88] = new SqlParameter("@PRODUCT_USER_ID", USER_ID);
            param[89] = new SqlParameter("@PRODUCT_BRANCH_CODE", BRANCH_CODE);
            param[90] = new SqlParameter("@PRODUCT_YEAR", YEAR);
            param[91] = new SqlParameter("@PRODUCT_WORKING_PERIOD", EWorking_Period);

            param[92] = new SqlParameter("@Mflag", flag);
            param[93] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[93].Direction = ParameterDirection.Output;

            param[94] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[94].Direction = ParameterDirection.Output;
            param[95] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[95].Direction = ParameterDirection.Output;

            param[96] = new SqlParameter("@PRODUCT_SAPTA_NOTN", PRODUCT_SAPTA_NOTN);
            param[97] = new SqlParameter("@PRODUCT_SAPTA_SLNO", PRODUCT_SAPTA_SLNO);
            param[98] = new SqlParameter("@PRODUCT_SAPTA_RATE", PRODUCT_SAPTA_RATE);
            param[99] = new SqlParameter("@PRODUCT_TARIFF_NOTN", PRODUCT_TARIFF_NOTN);
            param[100] = new SqlParameter("@PRODUCT_TARIFF_SLNO", PRODUCT_TARIFF_SLNO);
            param[101] = new SqlParameter("@PRODUCT_TARIFF_QTY", PRODUCT_TARIFF_QTY);
            param[102] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT", PRODUCT_TARIFF_AMOUNT);
            param[103] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT_UNIT", PRODUCT_TARIFF_AMOUNT_UNIT);
            param[104] = new SqlParameter("@PRODUCT_RSP_NOTN_NO", RSP_NOTN_NO);
            param[105] = new SqlParameter("@PRODUCT_RSP_NOTN_SL_NO", RSP_NOTN_SL_NO);

            param[110] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_NOTN", PRODUCT_CVD_EDU_CESS_NOTN);
            param[111] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_NOTN_SL", PRODUCT_CVD_EDU_CESS_NOTN_SL);
            param[112] = new SqlParameter("@PRODUCT_CETH_EDU_CESS_RATE", PRODUCT_CETH_EDU_CESS_RATE);

            param[113] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_NOTN", PRODUCT_CVD_SEC_EDU_CESS_NOTN);
            param[114] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL", PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL);
            param[115] = new SqlParameter("@PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE", PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE);

            param[116] = new SqlParameter("@PARTNO", PARTNO);

            param[117] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_NOTN", PRODUCT_CTH_INFRA_CESS_NOTN);
            param[118] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_NOTN_SLNO", PRODUCT_CTH_INFRA_CESS_NOTN_SLNO);
            param[119] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_RATE", PRODUCT_CTH_INFRA_CESS_RATE);

            param[120] = new SqlParameter("@PRODUCT_ADDL_DUTY_RATE", PRODUCT_ADDL_DUTY_RATE);

            param[121] = new SqlParameter("@CENTRAL_EXCISE_FLAG", CENTRAL_EXCISE_FLAG);
            param[122] = new SqlParameter("@MANUFACTURER_PRODUCER", MANUFACTURER_PRODUCER);
            param[123] = new SqlParameter("@M_P_GROWER_CODE", M_P_GROWER_CODE);
            param[124] = new SqlParameter("@M_P_GROWER_ADD1", M_P_GROWER_ADD1);
            param[125] = new SqlParameter("@M_P_GROWER_ADD2", M_P_GROWER_ADD2);
            param[126] = new SqlParameter("@M_P_GROWER_CITY", M_P_GROWER_CITY);
            param[127] = new SqlParameter("@M_P_GROWER_COUNTRY_SUBDIV", M_P_GROWER_COUNTRY_SUBDIV);
            param[128] = new SqlParameter("@M_P_GROWER_PIN", M_P_GROWER_PIN);
            param[129] = new SqlParameter("@M_P_GROWER_COUNTRY", M_P_GROWER_COUNTRY);
            param[130] = new SqlParameter("@SOURCE_COUNTRY", SOURCE_COUNTRY);
            param[131] = new SqlParameter("@TRANSIT_COUNTRY", TRANSIT_COUNTRY);
            param[132] = new SqlParameter("@ACCESSORY_STATUS", ACCESSORY_STATUS);

            param[133] = new SqlParameter("@IGST_LEVY_NOTN", IGST_LEVY_NOTN);
            param[134] = new SqlParameter("@IGST_LEVY_SLNO", IGST_LEVY_SLNO);
            param[135] = new SqlParameter("@IGST_LEVY_RATE", IGST_LEVY_RATE);
            param[136] = new SqlParameter("@IGST_LEVY_SPL", IGST_LEVY_SPL);
            param[137] = new SqlParameter("@IGST_LEVY_UNIT", IGST_LEVY_UNIT);
            param[138] = new SqlParameter("@IGST_LEVY_SPL_TYPE", IGST_LEVY_SPL_TYPE);
            param[139] = new SqlParameter("@IGST_LEVY_EXCEPTION_NOTN", IGST_LEVY_EXCEPTION_NOTN);
            param[140] = new SqlParameter("@IGST_LEVY_EXCEPTION_SLNO", IGST_LEVY_EXCEPTION_SLNO);
            param[141] = new SqlParameter("@IGST_LEVY_EXCEPTION_RATE", IGST_LEVY_EXCEPTION_RATE);
            param[142] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_NOTN", IGST_LEVY_COMPENSATION_CESS_NOTN);
            param[143] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SLNO", IGST_LEVY_COMPENSATION_CESS_SLNO);
            param[144] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_RATE", IGST_LEVY_COMPENSATION_CESS_RATE);
            param[145] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SPL", IGST_LEVY_COMPENSATION_CESS_SPL);
            param[146] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_UNIT", IGST_LEVY_COMPENSATION_CESS_UNIT);
            param[147] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SPL_TYPE", IGST_LEVY_COMPENSATION_CESS_SPL_TYPE);
            param[148] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_NOTN", IGST_LEVY_EXCEPTION_CC_NOTN);
            param[149] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_SLNO", IGST_LEVY_EXCEPTION_CC_SLNO);
            param[150] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_RATE", IGST_LEVY_EXCEPTION_CC_RATE);

            param[151] = new SqlParameter("@LEVY_EXCEMPTION_NOTN_TYPE", LEVY_EXCEMPTION_NOTN_TYPE);
            param[152] = new SqlParameter("@LEVY_EXCEPTION_CC_NOTN_TYPE", LEVY_EXCEPTION_CC_NOTN_TYPE);

            param[153] = new SqlParameter("@SOCIAL_WELFARE_NOTN", SOCIAL_WELFARE_NOTN);
            param[154] = new SqlParameter("@SOCIAL_WELFARE_NOTN_SLNO", SOCIAL_WELFARE_NOTN_SLNO);
            param[155] = new SqlParameter("@SOCIAL_WELFARE_RATE", SOCIAL_WELFARE_RATE);

            param[156] = new SqlParameter("@ANTI_DUMPING_NOTN", ANTI_DUMPING_NOTN);
            param[157] = new SqlParameter("@ANTI_DUMPING_NOTN_SLNO", ANTI_DUMPING_NOTN_SLNO);
            param[158] = new SqlParameter("@CTH_SLNO", CTH_SLNO);
            param[159] = new SqlParameter("@CTH_SUPPLIER_SLNO", CTH_SUPPLIER_SLNO);
            param[160] = new SqlParameter("@CTH_QTY", CTH_QTY);

            param[161] = new SqlParameter("@AIDC_NOTN", AIDC_NOTN);
            param[162] = new SqlParameter("@AIDC_NOTN_SLNO", AIDC_NOTN_SLNO);
            param[163] = new SqlParameter("@AIDC_RATE", AIDC_RATE);
            param[164] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[93].Value.ToString());

            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[95].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;
    }


    public int License_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@LICENSE_ID", LICENSE_ID);
            param[1] = new SqlParameter("@LICENSE_NO", LICENSE_NO);

            param[2] = new SqlParameter("@LICENSE_DATE", DateTime.Parse(LICENSE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[3] = new SqlParameter("@LICENSE_R_SL_NO", LICENSE_R_SL_NO);
            param[4] = new SqlParameter("@LICENSE_REG_DATE", DateTime.Parse(LICENSE_REG_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[5] = new SqlParameter("@LICENSE_REG_TYPE", LICENSE_REG_TYPE);
            param[6] = new SqlParameter("@LICENSE_ITEM_SL_NO", LICENSE_ITEM_SL_NO);
            param[7] = new SqlParameter("@LICENSE_ITEM_DESCRIPTION", LICENSE_ITEM_DESCRIPTION);
            param[8] = new SqlParameter("@LICENSE_QTY", LICENSE_QTY);
            param[9] = new SqlParameter("@LICENSE_UNIT", LICENSE_UNIT);
            param[10] = new SqlParameter("@LICENSE_TYPE", LICENSE_TYPE);
            //param[11] = new SqlParameter("@ADCODE_REMARKS", ADCODE_REMARKS);
            param[12] = new SqlParameter("@LICENSE_USER_ID", USER_ID);
            param[13] = new SqlParameter("@LICENSE_BRANCH_CODE", BRANCH_CODE);
            param[14] = new SqlParameter("@LICENSE_YEAR", YEAR);
            param[15] = new SqlParameter("@LICENSE_WORKING_PERIOD", EWorking_Period);
            param[21] = new SqlParameter("@LICENSE_EXP_ITEM_SLNO", LICENSE_EXP_ITEM_SLNO);
            param[22] = new SqlParameter("@LIC_EXPIRED_DATE", DateTime.Parse(LIC_EXPIRED_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[23] = new SqlParameter("@LICENSE_EXP_QTY", LICENSE_EXP_QTY);
            param[24] = new SqlParameter("@LICENSE_EXP_UNIT", LICENSE_EXP_UNIT);


            param[16] = new SqlParameter("@Mflag", flag);
            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            param[20] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "LICENSE_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[17].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[20].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return result;
    }

    #endregion


    public DataSet RetrieveAll_SVB_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@SVB_ID", SVB_ID);
            param[1] = new SqlParameter("@WORKING_PERIOD", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@IMP_NAME", IMP_NAME);
            param[9] = new SqlParameter("@SUPPLIER_NAME", SUPPLIER_NAME);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@startRowIndex", startRowIndex);
            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SVB_RELATION_MASTER_SEARCH", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_Adcode")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SVB_RELATION_MASTER_SEARCH", param);
                result = Convert.ToInt32(param[8].Value.ToString());
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
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SVB_RELATION_MASTER_SEARCH", param);
                result = Convert.ToInt32(param[8].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Ename = "1";
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

            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet RetrieveAll_IMPORT_LICENSE_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@LICENSE_ID", LICENSE_ID);
            param[1] = new SqlParameter("@LICENSE_WORKING_PERIOD", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
            param[9] = new SqlParameter("@LICENSE_DATE", LICENSE_DATE);
            param[11] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
            param[12] = new SqlParameter("@PARTY_NAME", PARTY_NAME);
            param[13] = new SqlParameter("@LICENSE_DESC", LICENSE_ITEM_DESCRIPTION);
            param[14] = new SqlParameter("@PART_NO", PART_NO);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;


            if (Ename == "delete" || Ename == "Check_Avail")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LICENSE_MASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_License")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LICENSE_MASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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
            else if (Ename == "select_license_all")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LICENSE_MASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());

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

            else if (Ename == "Get_Remaining_Debit_Amt")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LICENSE_MASTER__SEARCH_SELECT", param);
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LICENSE_MASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Prevent IEC NO value not assign to CLIENT textbox
                        Ename = "1";
                        //Prevent IEC NO value not assign to CLIENT textbox
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
            er.makeLog(ex.Message);
        }
        return ds;
    }
   
    public DataSet RetrieveAll_IMPORT_LICENSE_DEBIT_AMT_REPORT()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
            param[1] = new SqlParameter("@LICENSE_DATE", LICENSE_DATE);
            param[2] = new SqlParameter("@PORT_OF_LICENSE", PORT_OF_LICENSE);
            param[3] = new SqlParameter("@LICENSE_WORKING_PERIOD", EWorking_Period);

            param[9] = new SqlParameter("@name", Ename);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;


            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LICENSE_DEBIT_REPORT_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_License" || Ename == "select_License_Details")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LICENSE_DEBIT_REPORT_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet PORT_MASTER_USERWISE_Insert_update(UserBO objUser)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@PORT_ID", objUser.PORT_ID);
            param[1] = new SqlParameter("@PORT_CODE", objUser.PORT_CODE);
            param[2] = new SqlParameter("@PORT_NAME", objUser.PORT_NAME);
            param[3] = new SqlParameter("@REMARKS", objUser.ITEM_REMARKS);
            param[4] = new SqlParameter("@USER_ID", objUser.USER_ID);
            param[5] = new SqlParameter("@BRANCH_CODE", objUser.BRANCH_CODE);
            param[6] = new SqlParameter("@WORKING_PERIOD", objUser.WORKING_PERIOD);
            param[7] = new SqlParameter("@Mflag", objUser.flag);

            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@startRowIndex", objUser.startRowIndex);
            param[13] = new SqlParameter("@maximumRows", objUser.maximumRows);
            param[14] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            if (objUser.flag == "S" || objUser.flag == "U" || objUser.flag == "Delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "PORT_MASTER_USERWISE_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[9].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "PORT_MASTER_USERWISE_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[14].Value.ToString());
            }
            //string ss = param[16].Value.ToString();

            if (objUser.flag == "S")
                UPDATE_ID = Convert.ToInt32(param[11].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_SingleWindow_UserWise_master() // Added by shanthini on 18-09-2026
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@SW_ID", SW_ID);
            param[1] = new SqlParameter("@Ename", Ename);
            param[2] = new SqlParameter("@FROM_CTH", SW_FROM_CTH);
            param[3] = new SqlParameter("@AGENCY_CODE", SW_AGENCY_CODE);
            param[4] = new SqlParameter("@USER_CODE", Connection.Current_User());

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@startRowIndex", startRowIndex);

            param[8] = new SqlParameter("@maximumRows", maximumRows);

            param[9] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SW_CTH_CODE_MASTER_USERWISE", param);
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SW_CTH_CODE_MASTER_USERWISE", param);
                result = Convert.ToInt32(param[9].Value.ToString());

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
            er.makeLog(ex.Message);
        }

        return ds;
    }

    public int SingleWindow_UserWise_Insert_update() // Added by shanthini on 18-09-2026
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@SW_ID", SW_ID);
            param[1] = new SqlParameter("@FROM_CTH", SW_FROM_CTH);
            param[2] = new SqlParameter("@TO_CTH", SW_TO_CTH);
            param[3] = new SqlParameter("@AGENCY_CODE", SW_AGENCY_CODE);
            param[4] = new SqlParameter("@USER_CODE", Connection.Current_User());
            param[5] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[6] = new SqlParameter("@Mflag", flag);

            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SW_CTH_CODE_MASTER_USERWISE", param);

            result = Convert.ToInt32(param[7].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[9].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return result;
    }

    public DataSet RetrieveAll_IMPORT_LICENSE_DEBIT_AMT_REPORT_PARTYWISE()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
            param[1] = new SqlParameter("@PartyName", IMP_EXP_NAME);
            param[2] = new SqlParameter("@PORT_OF_LICNESE", PORT_OF_LICENSE);
            param[6] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
            param[3] = new SqlParameter("@BRANCH_CODE", EWorking_Period);
            param[9] = new SqlParameter("@Ename", Ename);
            param[10] = new SqlParameter("@Partbr_slno", IMP_EXP_BRSLNO);
            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            if (Ename == "SELECT_LICENSE_PARTYWISE" || Ename == "select_License_JOBNO_TO_IMPORTER_NAME" || Ename == "select_General_IMPORTER_NAME" || Ename == "PARTYWISE")
            {
                if (Ename == "SELECT_LICENSE_PARTYWISE" && Connection.COMPANYID() == "293")
                {
                    ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_LICENSE_DEBIT_RPT_SEARCH_SELECT_PARAMOUNT", param);
                }
                else if (Ename == "PARTYWISE")
                {
                    ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_LICENSE_PARTYWISE_REPORT", param);

                }
                else
                {
                    ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_LICENSE_DEBIT_RPT_SEARCH_SELECT", param);
                }
                result = Convert.ToInt32(param[4].Value.ToString());

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
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet WAREHOUSE_MASTER_USERWISE_Insert_update(UserBO objUser)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@WH_ID", objUser.WH_ID);
            param[1] = new SqlParameter("@WAREHOUSE_CODE", objUser.WAREHOUSE_CODE);
            param[2] = new SqlParameter("@WAREHOUSE_NAME", objUser.WAREHOUSE_NAME);
            param[3] = new SqlParameter("@WAREHOUSE_ADDRESS", objUser.WAREHOUSE_ADDRESS);

            param[4] = new SqlParameter("@REMARKS", objUser.ITEM_REMARKS);
            param[5] = new SqlParameter("@USER_ID", objUser.USER_ID);
            param[6] = new SqlParameter("@BRANCH_CODE", objUser.BRANCH_CODE);
            param[7] = new SqlParameter("@WORKING_PERIOD", objUser.WORKING_PERIOD);
            param[8] = new SqlParameter("@Mflag", objUser.flag);

            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@startRowIndex", objUser.startRowIndex);
            param[13] = new SqlParameter("@maximumRows", objUser.maximumRows);
            param[14] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            if (objUser.flag == "S" || objUser.flag == "U" || objUser.flag == "Delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "WAREHOUSE_MASTER_USERWISE_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[9].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "WAREHOUSE_MASTER_USERWISE_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[14].Value.ToString());
            }
            //string ss = param[16].Value.ToString();

            if (objUser.flag == "S")
                UPDATE_ID = Convert.ToInt32(param[11].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Exp_ThirdParty_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@THIRDPARTY_ID", Ebuyerid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@THIRDPARTY_NAME", Ebuyer_name);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {

                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_THIRDPARTY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_THIRDPARTY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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

            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Imp_ThirdParty_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@THIRDPARTY_ID", Ebuyerid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@THIRDPARTY_NAME", Ebuyer_name);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {

                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_THIRDPARTY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_THIRDPARTY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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

            er.makeLog(ex.Message);
        }
        return ds;
    }

    public int ThirdParty_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@THIRDPARTY_ID", THIRDPARTY_ID);
            param[1] = new SqlParameter("@THIRDPARTY_NAME", THIRDPARTY_NAME);

            param[2] = new SqlParameter("@THIRDPARTY_ADD1", THIRDPARTY_ADD1);
            param[3] = new SqlParameter("@THIRDPARTY_ADD2", THIRDPARTY_ADD2);
            param[4] = new SqlParameter("@THIRDPARTY_CITY", THIRDPARTY_CITY);
            param[5] = new SqlParameter("@THIRDPARTY_COUNTRY_SUBDIVISION", THIRDPARTY_COUNTRY_SUBDIVISION);
            param[6] = new SqlParameter("@THIRDPARTY_COUNTRY_CODE", THIRDPARTY_COUNTRY_CODE);
            param[7] = new SqlParameter("@TERMS_PLACE", TERMS_PLACE);
            param[19] = new SqlParameter("@THIRDPARTY_PIN", THIRDPARTY_PIN);

            param[8] = new SqlParameter("@AEO_CODE", AEO_CODE);
            param[9] = new SqlParameter("@AEO_COUNTRY", AEO_COUNTRY);
            param[10] = new SqlParameter("@AEO_ROLE", AEO_ROLE);

            param[11] = new SqlParameter("@THIRDPARTY_USER_ID", USER_ID);
            param[12] = new SqlParameter("@THIRDPARTY_BRANCH_CODE", BRANCH_CODE);
            param[14] = new SqlParameter("@THIRDPARTY_WORKING_PERIOD", EWorking_Period);

            param[15] = new SqlParameter("@Mflag", flag);

            param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_THIRDPARTY_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[16].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return result;
    }

    public int Import_ThirdParty_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[22];

            param[0] = new SqlParameter("@THIRDPARTY_ID", THIRDPARTY_ID);
            param[1] = new SqlParameter("@THIRDPARTY_NAME", THIRDPARTY_NAME);

            param[2] = new SqlParameter("@THIRDPARTY_ADD1", THIRDPARTY_ADD1);
            param[3] = new SqlParameter("@THIRDPARTY_ADD2", THIRDPARTY_ADD2);
            param[4] = new SqlParameter("@THIRDPARTY_CITY", THIRDPARTY_CITY);
            param[5] = new SqlParameter("@THIRDPARTY_COUNTRY_SUBDIVISION", THIRDPARTY_COUNTRY_SUBDIVISION);
            param[6] = new SqlParameter("@THIRDPARTY_COUNTRY_CODE", THIRDPARTY_COUNTRY_CODE);
            param[7] = new SqlParameter("@TERMS_PLACE", TERMS_PLACE);
            param[19] = new SqlParameter("@THIRDPARTY_PIN", THIRDPARTY_PIN);

            param[8] = new SqlParameter("@AEO_CODE", AEO_CODE);
            param[9] = new SqlParameter("@AEO_COUNTRY", AEO_COUNTRY);
            param[10] = new SqlParameter("@AEO_ROLE", AEO_ROLE);

            param[11] = new SqlParameter("@THIRDPARTY_USER_ID", USER_ID);
            param[12] = new SqlParameter("@THIRDPARTY_BRANCH_CODE", BRANCH_CODE);
            param[14] = new SqlParameter("@THIRDPARTY_WORKING_PERIOD", EWorking_Period);
            param[20] = new SqlParameter("@BUYER_RELATED_Y_N", BUYER_RELATED_Y_N);

            param[15] = new SqlParameter("@Mflag", flag);

            param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_THIRDPARTY_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[16].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return result;
    }

    public DataSet RetrieveAll_Import_ItemDesc_Search_from_JOB_MASTER(string DB_CONN)
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@PRODUCT_IMPORT_ID", Eproduct_imp_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@ITEM_DESCRIPTION", Eproduct_imp_description);
            param[4] = new SqlParameter("@PRODUCT_RITC", Eproduct_imp_ritc);
            param[5] = new SqlParameter("@PRODUCT_NOTN", PRODUCT_NOTN);
            param[6] = new SqlParameter("@PARTY_NAME", PARTY_NAME);

            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);

            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(DB_CONN, CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_DESC_PARTYNAME_SEARCH_SELECT", param);
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
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }
        return ds;
    }


    public int Exchange_PDF_update(DataTable dtdata)
    {
        DataSet ds = new DataSet();
        //try
        //{

        SqlParameter[] param = new SqlParameter[30];

        param[0] = new SqlParameter("@EXCHANGE_ID", 0);
        //param[1] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", DateTime.Parse(EXCHANGE_EFFECT_DT_FROM, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
        //param[2] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", DateTime.Parse(EXCHANGE_EFFECT_DT_TO, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

        param[1] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", "");
        param[2] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", "");

        param[3] = new SqlParameter("@Exc_NotNo", EXCHANGE_NONT_NO);
        param[4] = new SqlParameter("@Exc_NotDt", EXCHANGE_NOTN_DATE);
        param[5] = new SqlParameter("@Exc_date", EXCHANGE_NOTN_DATE);
        param[6] = new SqlParameter("@UserID", USER_ID);

        param[7] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
        param[8] = new SqlParameter("@EXCHANGE_YEAR", YEAR);
        param[9] = new SqlParameter("@WorkPeriod", EWorking_Period);
        param[10] = new SqlParameter("@Opr_Flag", flag);


        param[11] = new SqlParameter("@ExchangeData", dtdata);
        param[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

        param[12].Direction = ParameterDirection.Output;




        SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ExchangeRateUpdate_SP", param);

        result = Convert.ToInt32(param[12].Value.ToString());

        //}
        //catch (Exception ex)
        //{

        //    er.makeLog(ex.Message);
        //}


        return result;

    }



    public DataSet RetrieveAll_EGM_LINER_VESSEL_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@ID", Esupid);

            param[1] = new SqlParameter("@Flag", Ename);
            param[2] = new SqlParameter("@NAME", Esup_name);
            param[3] = new SqlParameter("@Search_Type", Eadcode_iec_name);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EGM_LINER_VESSEL_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[8].Value.ToString());

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

            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_IMPORT_BOND_DETAILS_SummaryReport()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@BOND_NO", LICENSE_NO);
            param[1] = new SqlParameter("@BOND_TYPE", LICENSE_TYPE);
            param[2] = new SqlParameter("@BOND_LOCATION", PORT_OF_LICENSE);
            param[5] = new SqlParameter("@BRANCH_CODE", EWorking_Period);
            param[9] = new SqlParameter("@JOB_NO", PARTNO);
            param[6] = new SqlParameter("@Ename", Ename);

            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            if (Ename == "Distinct_Bond_Details" || Ename == "SELECT_RITC_JOBNO_BOND" || Ename == "SELECT_PD_BOND_REPORT" || Ename == "SELECT_RE_BOND_REPORT"
                || Ename == "SELECT_DEEC_BOND_REPORT" || Ename == "SELECT_EPCG_BOND_REPORT" || Ename == "SELECT_WAREHOUSE_BOND_REPORT" || Ename == "SELECT_EI_IGCR_BOND_REPORT"
                || Ename == "SELECT_EU_END_USE_BOND_REPORT")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_BOND_SUMMARY_REPORT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public int Import_BOND_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@BOND_NO", BOND_NO);
            param[2] = new SqlParameter("@BOND_DATE", DateTime.Parse(BOND_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[3] = new SqlParameter("@BOND_LOCATION", BOND_LOCATION);
            param[4] = new SqlParameter("@BOND_TYPE", BOND_TYPE);
            param[5] = new SqlParameter("@BOND_AMT", BOND_AMT);
            param[6] = new SqlParameter("@REMAINING_AMT", REMAINING_AMT);
            param[7] = new SqlParameter("@BOND_REMARKS", BOND_REMARKS);

            param[9] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[10] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[11] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[13] = new SqlParameter("@Mflag", flag);

            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_BOND_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[14].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[16].Value.ToString());

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }

    public DataSet RetrieveAll_Import_BOND_Master()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@BOND_NO", BOND_NO);
            param[2] = new SqlParameter("@BOND_TYPE", BOND_TYPE);

            param[3] = new SqlParameter("@Working_Period", Connection.Get_Company_Type());

            param[9] = new SqlParameter("@name", Ename);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_BOND_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_BOND_MASTER_SEARCH_SELECT", param);
                //result = Convert.ToInt32(param[8].Value.ToString());

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

            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet Retrive_Import_Sims()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@INFO_TEXT", STLNO);
            param[1] = new SqlParameter("@REGN_DATE", REGNDATE);
            param[2] = new SqlParameter("@FROM_DATE", FRMDATE);
            param[3] = new SqlParameter("@TO_DATE", TODATE);
            param[4] = new SqlParameter("@BRANCH_CODE", EWorking_Period);
            param[5] = new SqlParameter("@Ename", Ename);
            param[6] = new SqlParameter("@JOBNO", JOBNO);
            param[7] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_SIMS_RPT_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public int Bank_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[40];

            param[0] = new SqlParameter("@BANK_ID", BANK_ID);
            param[1] = new SqlParameter("@BANK_NAME", BANK_NAME);
            param[2] = new SqlParameter("@BRANCH_NAME", BRANCH_NAME);
            param[3] = new SqlParameter("@IFSC_CODE", IFSC_CODE);
            param[4] = new SqlParameter("@ACCOUNT_NUMBER", ACCOUNT_NO);
            param[5] = new SqlParameter("@ACCOUNT_TYPE", ACCOUNT_TYPE);
            param[6] = new SqlParameter("@SWIFT_CODE", SWIFT_CODE);
            param[7] = new SqlParameter("@AD_CODE", AD_CODE);
            param[8] = new SqlParameter("@CURRENCY", CURRENCY);
            param[10] = new SqlParameter("@OPENING_BALANCE", OPENING_BALANCE);
            param[11] = new SqlParameter("@ADDRESS1", ADDRESS1);
            param[12] = new SqlParameter("@ADDRESS2", ADDRESS2);
            param[13] = new SqlParameter("@CITY", CITY);
            param[14] = new SqlParameter("@STATE", STATE);
            param[15] = new SqlParameter("@PINCODE", PINCODE);
            param[16] = new SqlParameter("@CONTACT_PERSON", CONTACT_PERSON);
            param[17] = new SqlParameter("@CONTACT_NO", CONTACT_NO);
            param[18] = new SqlParameter("@EMAIL_ID", EMAIL_ID);
            param[31] = new SqlParameter("@PREFIX", PREFIX);
            param[32] = new SqlParameter("@SUFFIX", SUFFIX);
            param[33] = new SqlParameter("@ACCOUNT_HOLDER", ACCOUNT_HOLDER);

            param[22] = new SqlParameter("@USER_ID", USER_ID);
            param[23] = new SqlParameter("@DATE_TIME", DateTime.Parse(DATE_TIME, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[24] = new SqlParameter("@STATUS", STATUS);
            param[25] = new SqlParameter("@Mflag", flag);
            param[26] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[27] = new SqlParameter("@YEAR", YEAR);
            param[28] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[29] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
            param[30] = new SqlParameter("@MODIFIEDON", DateTime.Parse(MODIFIEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[19] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[21].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BANK_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[19].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[21].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;

    }


    public DataSet RetrieveAll_Bank_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[17];

            param[0] = new SqlParameter("@BANK_ID", BANK_ID);
            param[1] = new SqlParameter("@WORKING_PERIOD", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@BANK_NAME", BANK_NAME);
            param[9] = new SqlParameter("@BRANCH_NAME", BRANCH_NAME);

            param[11] = new SqlParameter("@ACCOUNT_NO", ACCOUNT_NO);
            //param[11] = new SqlParameter("@ACCOUNT_NO", ACCOUNT_NUMBER);
            param[12] = new SqlParameter("@ACCOUNT_TYPE", ACCOUNT_TYPE);
            param[13] = new SqlParameter("@IFSCCODE", IFSCCODE);
            param[14] = new SqlParameter("@SWIFTCCODE", SWIFTCCODE);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;


            if (Ename == "delete" || Ename == "Check_Avail")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BANK_MASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_BanId" || Ename == "select_con" || Ename == "select_conwithcode")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BANK_MASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_IMPORT_LICENSE_BALANCE_REPORT()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
            param[1] = new SqlParameter("@LICENSE_DATE", LICENSE_DATE);
            param[2] = new SqlParameter("@PORT_OF_LICENSE", PORT_OF_LICENSE);
            param[3] = new SqlParameter("@LICENSE_WORKING_PERIOD", EWorking_Period);
            param[10] = new SqlParameter("@LICENSE_ITEM_NO", LICENSE_ITEM_NO);
            param[11] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);

            param[9] = new SqlParameter("@name", Ename);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LICENSE_BALANCE_REPORT", param);
            result = Convert.ToInt32(param[8].Value.ToString());

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
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_Export_PDF_Settings_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", Eproduct_imp_id);

            param[3] = new SqlParameter("@ITEM_DESC", Eproduct_imp_description);
            param[4] = new SqlParameter("@RITC_NO", Eproduct_imp_cth);
            param[5] = new SqlParameter("@EXPORTER_NAME", Eproduct_imp_ceth);
            param[6] = new SqlParameter("@PRODUCT_PARTNO", Eproduct_imp_ritc);

            param[2] = new SqlParameter("@name", Ename);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_PDF_UPLOAD_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_PDF_UPLOAD_MASTER_SEARCH_SELECT", param);
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
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public int Pdf_Reader_Product_Master_Insert_update_()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[220];

            param[0] = new SqlParameter("@PRODUCT_IMPORT_ID", PRODUCT_IMPORT_ID);
            param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", PRODUCT_DESCRIPTION);
            param[2] = new SqlParameter("@PRODUCT_CODE", PRODUCT_CODE);
            param[3] = new SqlParameter("@PRODUCT_RITC", PRODUCT_RITC);
            param[4] = new SqlParameter("@PRODUCT_CTH", PRODUCT_CTH);
            param[5] = new SqlParameter("@PRODUCT_BCD_NOTN", PRODUCT_BCD_NOTN);
            param[6] = new SqlParameter("@PRODUCT_BCD_SLNO", PRODUCT_BCD_SLNO);
            param[7] = new SqlParameter("@PRODUCT_BCD_RATE", PRODUCT_BCD_RATE);
            param[8] = new SqlParameter("@PRODUCT_BCD_SPL", PRODUCT_BCD_SPL);
            param[9] = new SqlParameter("@PRODUCT_BCD_UNIT", PRODUCT_BCD_UNIT);
            param[10] = new SqlParameter("@PRODUCT_BCD_SPL_TYPE", PRODUCT_BCD_SPL_TYPE);
            param[11] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN", PRODUCT_ADDL_DUTY_NOTN);
            param[12] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN_SL", PRODUCT_ADDL_DUTY_NOTN_SL);
            param[13] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN", PRODUCT_EDU_CESS_NOTN);
            param[14] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN_SL", PRODUCT_EDU_CESS_NOTN_SL);
            param[15] = new SqlParameter("@PRODUCT_EDU_CESS_RATE", PRODUCT_EDU_CESS_RATE);
            param[16] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN", PRODUCT_SEC_EDU_CESS_NOTN);
            param[17] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN_SL", PRODUCT_SEC_EDU_CESS_NOTN_SL);
            param[18] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_RATE", PRODUCT_SEC_EDU_CESS_RATE);
            param[19] = new SqlParameter("@PRODUCT_NCD_NOTN", PRODUCT_NCD_NOTN);
            param[20] = new SqlParameter("@PRODUCT_NCD_SLNO", PRODUCT_NCD_SLNO);
            param[21] = new SqlParameter("@PRODUCT_NCD_RATE", PRODUCT_NCD_RATE);
            param[22] = new SqlParameter("@PRODUCT_NCD_SPL", PRODUCT_NCD_SPL);
            param[23] = new SqlParameter("@PRODUCT_NCD_UNIT", PRODUCT_NCD_UNIT);
            param[24] = new SqlParameter("@PRODUCT_NCD_SPL_TYPE", PRODUCT_NCD_SPL_TYPE);
            param[25] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN", PRODUCT_AGGREGATE_DUTY_NOTN);
            param[26] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_SL", PRODUCT_AGGREGATE_DUTY_NOTN_SL);
            param[27] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_RATE", PRODUCT_AGGREGATE_DUTY_NOTN_RATE);
            param[28] = new SqlParameter("@PRODUCT_SAFEGUARD_NOTN", PRODUCT_SAFEGUARD_NOTN);
            param[29] = new SqlParameter("@PRODUCT_SAFEGUARD_SLNO", PRODUCT_SAFEGUARD_SLNO);
            param[30] = new SqlParameter("@PRODUCT_SAFEGUARD_RATE", PRODUCT_SAFEGUARD_RATE);
            param[31] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL", PRODUCT_SAFEGUARD_SPL);
            param[32] = new SqlParameter("@PRODUCT_SAFEGUARD_UNIT", PRODUCT_SAFEGUARD_UNIT);
            param[33] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL_TYPE", PRODUCT_SAFEGUARD_SPL_TYPE);
            param[34] = new SqlParameter("@PRODUCT_CETH", PRODUCT_CETH);
            param[35] = new SqlParameter("@PRODUCT_MRP_YN", PRODUCT_MRP_YN);
            param[36] = new SqlParameter("@PRODUCT_MRP_SL_NO", PRODUCT_MRP_SL_NO);
            param[37] = new SqlParameter("@PRODUCT_MRP_AMOUNT", PRODUCT_MRP_AMOUNT);
            param[38] = new SqlParameter("@PRODUCT_MRP_ABT_RATE", PRODUCT_MRP_ABT_RATE);
            param[39] = new SqlParameter("@PRODUCT_CVD_NOTN", PRODUCT_CVD_NOTN);
            param[40] = new SqlParameter("@PRODUCT_CVD_SLNO", PRODUCT_CVD_SLNO);
            param[41] = new SqlParameter("@PRODUCT_CVD_RATE", PRODUCT_CVD_RATE);
            param[42] = new SqlParameter("@PRODUCT_CVD_SPL", PRODUCT_CVD_SPL);
            param[43] = new SqlParameter("@PRODUCT_CVD_UNIT", PRODUCT_CVD_UNIT);
            param[44] = new SqlParameter("@PRODUCT_CVD_SPL_TYPE", PRODUCT_CVD_SPL_TYPE);
            param[45] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_RATE", PRODUCT_CVD_EDU_CESS_RATE);
            param[46] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_RATE", PRODUCT_CVD_SEC_EDU_CESS_RATE);
            param[47] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN", PRODUCT_ADDL5_SIA_NOTN);
            param[48] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN_SL", PRODUCT_ADDL5_SIA_NOTN_SL);
            param[49] = new SqlParameter("@PRODUCT_ADDL5_SIA_RATE", PRODUCT_ADDL5_SIA_RATE);
            param[50] = new SqlParameter("@PRODUCT_ADDL_GSI_NOTN", PRODUCT_ADDL_GSI_NOTN);
            param[51] = new SqlParameter("@PRODUCT_ADDL_GSI_SLNO", PRODUCT_ADDL_GSI_SLNO);
            param[52] = new SqlParameter("@PRODUCT_ADDL_GSI_RATE", PRODUCT_ADDL_GSI_RATE);
            param[53] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL", PRODUCT_ADDL_GSI_SPL);
            param[54] = new SqlParameter("@PRODUCT_ADDL_GSI_UNIT", PRODUCT_ADDL_GSI_UNIT);
            param[55] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL_TYPE", PRODUCT_ADDL_GSI_SPL_TYPE);
            param[56] = new SqlParameter("@PRODUCT_ADDL_SHEII_NOTN", PRODUCT_ADDL_SHEII_NOTN);
            param[57] = new SqlParameter("@PRODUCT_ADDL_SHEII_SLNO", PRODUCT_ADDL_SHEII_SLNO);
            param[58] = new SqlParameter("@PRODUCT_ADDL_SHEII_RATE", PRODUCT_ADDL_SHEII_RATE);
            param[59] = new SqlParameter("@PRODUCT_ADDL_SHEII_SPL", PRODUCT_ADDL_SHEII_SPL);
            param[60] = new SqlParameter("@PRODUCT_ADDL_SHEII_UNIT", PRODUCT_ADDL_SHEII_UNIT);
            param[61] = new SqlParameter("@PRODUCT_ADDL_SHEII_TYPE", PRODUCT_ADDL_SHEII_TYPE);
            param[62] = new SqlParameter("@PRODUCT_ADDL_TTA_NOTN", PRODUCT_ADDL_TTA_NOTN);
            param[63] = new SqlParameter("@PRODUCT_ADDL_TTA_SLNO", PRODUCT_ADDL_TTA_SLNO);
            param[64] = new SqlParameter("@PRODUCT_ADDL_TTA_RATE", PRODUCT_ADDL_TTA_RATE);
            param[65] = new SqlParameter("@PRODUCT_ADDL_TTA_SPL", PRODUCT_ADDL_TTA_SPL);
            param[66] = new SqlParameter("@PRODUCT_ADDL_TTA_UNIT", PRODUCT_ADDL_TTA_UNIT);
            param[67] = new SqlParameter("@PRODUCT_ADDL_TTA_TYPE", PRODUCT_ADDL_TTA_TYPE);
            param[68] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_NOTN", PRODUCT_ADDL_HEALTH_CESS_NOTN);
            param[69] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SLNO", PRODUCT_ADDL_HEALTH_CESS_SLNO);
            param[70] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_RATE", PRODUCT_ADDL_HEALTH_CESS_RATE);
            param[71] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SPL", PRODUCT_ADDL_HEALTH_CESS_SPL);
            param[72] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_UNIT", PRODUCT_ADDL_HEALTH_CESS_UNIT);
            param[73] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_TYPE", PRODUCT_ADDL_HEALTH_CESS_TYPE);
            param[74] = new SqlParameter("@PRODUCT_CESS_NOTN", PRODUCT_CESS_NOTN);
            param[75] = new SqlParameter("@PRODUCT_CESS_SLNO", PRODUCT_CESS_SLNO);
            param[76] = new SqlParameter("@PRODUCT_CESS_RATE", PRODUCT_CESS_RATE);
            param[77] = new SqlParameter("@PRODUCT_CESS_SPL", PRODUCT_CESS_SPL);
            param[78] = new SqlParameter("@PRODUCT_CESS_UNIT", PRODUCT_CESS_UNIT);
            param[79] = new SqlParameter("@PRODUCT_CESS_TYPE", PRODUCT_CESS_TYPE);
            param[80] = new SqlParameter("@PRODUCT_GENERAL_DESC", PRODUCT_GENERAL_DESC);
            param[81] = new SqlParameter("@PRODUCT_MANUFACTURER", PRODUCT_MANUFACTURER);
            param[82] = new SqlParameter("@PRODUCT_BRAND", PRODUCT_BRAND);
            param[83] = new SqlParameter("@PRODUCT_MODEL", PRODUCT_MODEL);
            param[84] = new SqlParameter("@PRODUCT_END_USE", PRODUCT_END_USE);
            param[85] = new SqlParameter("@PRODUCT_COUNTRY_ORIGIN", PRODUCT_COUNTRY_ORIGIN);
            param[86] = new SqlParameter("@PRODUCT_ACCESSORIES", PRODUCT_ACCESSORIES);
            param[87] = new SqlParameter("@PRODUCT_REMARKS", PRODUCT_REMARKS);
            param[88] = new SqlParameter("@PRODUCT_USER_ID", USER_ID);
            param[89] = new SqlParameter("@PRODUCT_BRANCH_CODE", BRANCH_CODE);
            param[90] = new SqlParameter("@PRODUCT_YEAR", YEAR);
            param[91] = new SqlParameter("@PRODUCT_WORKING_PERIOD", EWorking_Period);

            param[92] = new SqlParameter("@Mflag", flag);
            param[93] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[93].Direction = ParameterDirection.Output;

            param[94] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[94].Direction = ParameterDirection.Output;
            param[95] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[95].Direction = ParameterDirection.Output;

            param[96] = new SqlParameter("@PRODUCT_SAPTA_NOTN", PRODUCT_SAPTA_NOTN);
            param[97] = new SqlParameter("@PRODUCT_SAPTA_SLNO", PRODUCT_SAPTA_SLNO);
            param[98] = new SqlParameter("@PRODUCT_SAPTA_RATE", PRODUCT_SAPTA_RATE);
            param[99] = new SqlParameter("@PRODUCT_TARIFF_NOTN", PRODUCT_TARIFF_NOTN);
            param[100] = new SqlParameter("@PRODUCT_TARIFF_SLNO", PRODUCT_TARIFF_SLNO);
            param[101] = new SqlParameter("@PRODUCT_TARIFF_QTY", PRODUCT_TARIFF_QTY);
            param[102] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT", PRODUCT_TARIFF_AMOUNT);
            param[103] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT_UNIT", PRODUCT_TARIFF_AMOUNT_UNIT);
            param[104] = new SqlParameter("@PRODUCT_RSP_NOTN_NO", RSP_NOTN_NO);
            param[105] = new SqlParameter("@PRODUCT_RSP_NOTN_SL_NO", RSP_NOTN_SL_NO);

            param[110] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_NOTN", PRODUCT_CVD_EDU_CESS_NOTN);
            param[111] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_NOTN_SL", PRODUCT_CVD_EDU_CESS_NOTN_SL);
            param[112] = new SqlParameter("@PRODUCT_CETH_EDU_CESS_RATE", PRODUCT_CETH_EDU_CESS_RATE);

            param[113] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_NOTN", PRODUCT_CVD_SEC_EDU_CESS_NOTN);
            param[114] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL", PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL);
            param[115] = new SqlParameter("@PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE", PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE);

            param[116] = new SqlParameter("@PARTNO", PARTNO);

            param[117] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_NOTN", PRODUCT_CTH_INFRA_CESS_NOTN);
            param[118] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_NOTN_SLNO", PRODUCT_CTH_INFRA_CESS_NOTN_SLNO);
            param[119] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_RATE", PRODUCT_CTH_INFRA_CESS_RATE);

            param[120] = new SqlParameter("@PRODUCT_ADDL_DUTY_RATE", PRODUCT_ADDL_DUTY_RATE);

            param[121] = new SqlParameter("@CENTRAL_EXCISE_FLAG", CENTRAL_EXCISE_FLAG);
            param[122] = new SqlParameter("@MANUFACTURER_PRODUCER", MANUFACTURER_PRODUCER);
            param[123] = new SqlParameter("@M_P_GROWER_CODE", M_P_GROWER_CODE);
            param[124] = new SqlParameter("@M_P_GROWER_ADD1", M_P_GROWER_ADD1);
            param[125] = new SqlParameter("@M_P_GROWER_ADD2", M_P_GROWER_ADD2);
            param[126] = new SqlParameter("@M_P_GROWER_CITY", M_P_GROWER_CITY);
            param[127] = new SqlParameter("@M_P_GROWER_COUNTRY_SUBDIV", M_P_GROWER_COUNTRY_SUBDIV);
            param[128] = new SqlParameter("@M_P_GROWER_PIN", M_P_GROWER_PIN);
            param[129] = new SqlParameter("@M_P_GROWER_COUNTRY", M_P_GROWER_COUNTRY);
            param[130] = new SqlParameter("@SOURCE_COUNTRY", SOURCE_COUNTRY);
            param[131] = new SqlParameter("@TRANSIT_COUNTRY", TRANSIT_COUNTRY);
            param[132] = new SqlParameter("@ACCESSORY_STATUS", ACCESSORY_STATUS);

            param[133] = new SqlParameter("@IGST_LEVY_NOTN", IGST_LEVY_NOTN);
            param[134] = new SqlParameter("@IGST_LEVY_SLNO", IGST_LEVY_SLNO);
            param[135] = new SqlParameter("@IGST_LEVY_RATE", IGST_LEVY_RATE);
            param[136] = new SqlParameter("@IGST_LEVY_SPL", IGST_LEVY_SPL);
            param[137] = new SqlParameter("@IGST_LEVY_UNIT", IGST_LEVY_UNIT);
            param[138] = new SqlParameter("@IGST_LEVY_SPL_TYPE", IGST_LEVY_SPL_TYPE);
            param[139] = new SqlParameter("@IGST_LEVY_EXCEPTION_NOTN", IGST_LEVY_EXCEPTION_NOTN);
            param[140] = new SqlParameter("@IGST_LEVY_EXCEPTION_SLNO", IGST_LEVY_EXCEPTION_SLNO);
            param[141] = new SqlParameter("@IGST_LEVY_EXCEPTION_RATE", IGST_LEVY_EXCEPTION_RATE);
            param[142] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_NOTN", IGST_LEVY_COMPENSATION_CESS_NOTN);
            param[143] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SLNO", IGST_LEVY_COMPENSATION_CESS_SLNO);
            param[144] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_RATE", IGST_LEVY_COMPENSATION_CESS_RATE);
            param[145] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SPL", IGST_LEVY_COMPENSATION_CESS_SPL);
            param[146] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_UNIT", IGST_LEVY_COMPENSATION_CESS_UNIT);
            param[147] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SPL_TYPE", IGST_LEVY_COMPENSATION_CESS_SPL_TYPE);
            param[148] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_NOTN", IGST_LEVY_EXCEPTION_CC_NOTN);
            param[149] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_SLNO", IGST_LEVY_EXCEPTION_CC_SLNO);
            param[150] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_RATE", IGST_LEVY_EXCEPTION_CC_RATE);

            param[151] = new SqlParameter("@LEVY_EXCEMPTION_NOTN_TYPE", LEVY_EXCEMPTION_NOTN_TYPE);
            param[152] = new SqlParameter("@LEVY_EXCEPTION_CC_NOTN_TYPE", LEVY_EXCEPTION_CC_NOTN_TYPE);

            param[153] = new SqlParameter("@SOCIAL_WELFARE_NOTN", SOCIAL_WELFARE_NOTN);
            param[154] = new SqlParameter("@SOCIAL_WELFARE_NOTN_SLNO", SOCIAL_WELFARE_NOTN_SLNO);
            param[155] = new SqlParameter("@SOCIAL_WELFARE_RATE", SOCIAL_WELFARE_RATE);

            param[156] = new SqlParameter("@ANTI_DUMPING_NOTN", ANTI_DUMPING_NOTN);
            param[157] = new SqlParameter("@ANTI_DUMPING_NOTN_SLNO", ANTI_DUMPING_NOTN_SLNO);
            param[158] = new SqlParameter("@CTH_SLNO", CTH_SLNO);
            param[159] = new SqlParameter("@CTH_SUPPLIER_SLNO", CTH_SUPPLIER_SLNO);
            param[160] = new SqlParameter("@CTH_QTY", CTH_QTY);

            param[161] = new SqlParameter("@AIDC_NOTN", AIDC_NOTN);
            param[162] = new SqlParameter("@AIDC_NOTN_SLNO", AIDC_NOTN_SLNO);
            param[163] = new SqlParameter("@AIDC_RATE", AIDC_RATE);
            // param[164] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);

            param[165] = new SqlParameter("@PRODUCT_IMP_EXP_NAME", PRODUCT_IMP_EXP_NAME);
            param[166] = new SqlParameter("@PRODUCT_IMP_EXP_IECNO", PRODUCT_IMP_EXP_IECNO);
            param[167] = new SqlParameter("@PRODUCT_IMP_EXP_BRSLNO", PRODUCT_IMP_EXP_BRSLNO);
            param[168] = new SqlParameter("@PRODUCT_ITEM_QTY_CODE", PRODUCT_ITEM_QTY_CODE);
            param[169] = new SqlParameter("@PRODUCT_OTHER_DUTY_NOTN", PRODUCT_OTHER_DUTY_NOTN);
            param[170] = new SqlParameter("@PRODUCT_OTHER_DUTY_SLNO", PRODUCT_OTHER_DUTY_SLNO);
            param[171] = new SqlParameter("@PRODUCT_OTHER_DUTY_RATE", PRODUCT_OTHER_DUTY_RATE);
            param[172] = new SqlParameter("@PRODUCT_OTHER_DUTY_SPL", PRODUCT_OTHER_DUTY_SPL);
            param[173] = new SqlParameter("@PRODUCT_OTHER_DUTY_UNIT", PRODUCT_OTHER_DUTY_UNIT);
            param[174] = new SqlParameter("@PRODUCT_OTHER_DUTY_TYPE", PRODUCT_OTHER_DUTY_TYPE);
            param[175] = new SqlParameter("@PRODUCT_INFO_MSR", PRODUCT_INFO_MSR);
            param[176] = new SqlParameter("@PRODUCT_INFO_UQC", PRODUCT_INFO_UQC);


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PDF_READER_PRODUCT_IMPORT_MASTER_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[93].Value.ToString());

            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[95].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;
    }





    public DataSet RetrieveAll_Pdf_Reader_Product_import_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@PRODUCT_IMPORT_ID", Eproduct_imp_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@PRODUCT_DESCRIPTION", Eproduct_imp_description);
            param[4] = new SqlParameter("@PRODUCT_CTH", Eproduct_imp_cth);
            param[5] = new SqlParameter("@PRODUCT_CETH", Eproduct_imp_ceth);
            param[6] = new SqlParameter("@PRODUCT_RITC", Eproduct_imp_ritc);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PDF_READER_PRODUCT_IMPORT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "Get_RSP_PARTNO_GMMCO" || Ename == "Get_Product_GMMCO" || Ename == "Get_Product_Details_All_GMMCO" || Ename == "Get_Product_PARTNO_CP" || Ename == "Get_Product_Thailand" || Ename == "Get_Product_Details_All_Thailand" || Ename == "Get_Product_PARTNO_Thailand" || Ename == "Get_Product_Details_All_INDEV")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PDF_READER_PRODUCT_IMPORT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PDF_READER_PRODUCT_IMPORT_MASTER_SEARCH_SELECT", param);
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
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet PDF_PORT_MASTER_Insert_update_OLD(UserBO objUser)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@PORT_ID", objUser.PORT_ID);
            param[1] = new SqlParameter("@COUNTRY_NAME", objUser.COUNTRY_SHIPMENT);
            param[2] = new SqlParameter("@PORT_CODE", objUser.PORT_CODE);
            param[3] = new SqlParameter("@PORT_NAME", objUser.PORT_NAME);
            param[4] = new SqlParameter("@REMARKS", objUser.ITEM_REMARKS);
            param[5] = new SqlParameter("@USER_ID", objUser.USER_ID);
            param[6] = new SqlParameter("@BRANCH_CODE", objUser.BRANCH_CODE);
            param[7] = new SqlParameter("@WORKING_PERIOD", objUser.WORKING_PERIOD);
            param[8] = new SqlParameter("@Mflag", objUser.flag);

            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@startRowIndex", objUser.startRowIndex);
            param[13] = new SqlParameter("@maximumRows", objUser.maximumRows);
            param[14] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            if (objUser.flag == "S" || objUser.flag == "U" || objUser.flag == "Delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "PDF_PORT_MASTER_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[9].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "PDF_PORT_MASTER_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[14].Value.ToString());
            }
            //string ss = param[16].Value.ToString();

            if (objUser.flag == "S")
                UPDATE_ID = Convert.ToInt32(param[11].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet PDF_COUNTRY_MASTER_Insert_update_Search()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@PDF_COUNTRY_NAME", PDF_COUNTRY_NAME);
            param[2] = new SqlParameter("@COUNTRY_CODE", COUNTRY_CODE);
            param[3] = new SqlParameter("@COUNTRY_NAME", COUNTRY_NAME);
            param[4] = new SqlParameter("@USERID", USER_ID);
            param[5] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);

            param[6] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;



            if (Ename == "S" || Ename == "U" || Ename == "Delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PDF_COUNTRY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PDF_COUNTRY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[10].Value.ToString());
            }
            //string ss = param[16].Value.ToString();

            if (Ename == "S")
                UPDATE_ID = Convert.ToInt32(param[11].Value.ToString());

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

            er.makeLog(ex.Message);
        }

        return ds;
    }


    public DataSet PDF_PORT_MASTER_Insert_update_Search()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@PDF_PORTNAME", PDF_PORTNAME);
            param[2] = new SqlParameter("@PORT_NAME", PORT_NAME);
            param[3] = new SqlParameter("@PORT_CODE", PORT_CODE);
            param[13] = new SqlParameter("@COUNTRY_CODE", COUNTRY_CODE);
            param[4] = new SqlParameter("@USERID", USER_ID);
            param[5] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);

            param[6] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;



            if (Ename == "S" || Ename == "U" || Ename == "Delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PDF_PORT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PDF_PORT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[10].Value.ToString());
            }
            //string ss = param[16].Value.ToString();

            if (Ename == "S")
                UPDATE_ID = Convert.ToInt32(param[11].Value.ToString());

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

            er.makeLog(ex.Message);
        }

        return ds;
    }

    public int Transport_Master_Insert_update() //***Kavipriya***//
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@TRANS_ID", TRANS_ID);
            param[1] = new SqlParameter("@TRANSPORT_NAME", TRANSPORT_NAME);
            param[2] = new SqlParameter("@TRANSPORT_ID", TRANSPORT_ID);
            param[4] = new SqlParameter("@MODE", MODE);
            param[5] = new SqlParameter("@TRANSPORT_DOC_NO", TRANSPORT_DOC_NO);
            param[6] = new SqlParameter("@VACHILE_NO", VACHILE_NO);
            param[7] = new SqlParameter("@TRANSPORT_DATE", DateTime.Parse(TRANSPORT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[8] = new SqlParameter("@VACHILE_TYPE", VACHILE_TYPE);
            param[9] = new SqlParameter("@USER_GSTN_ID", USER_GSTN_ID);

            param[11] = new SqlParameter("@TRANS_USER_ID", USER_ID);
            param[12] = new SqlParameter("@TRANS_BRANCH_CODE", BRANCH_CODE);
            param[13] = new SqlParameter("@TRANS_YEAR", YEAR);
            param[14] = new SqlParameter("@TRANS_WORKING_PERIOD", EWorking_Period);
            param[15] = new SqlParameter("@Mflag", flag);

            param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "TRANSPORT_MASTER_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[16].Value.ToString());
            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;
    }
    public DataSet RetrieveAll_Transport_MASTER()//***Kavipriya***//
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@TRANS_ID", Etransid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@TRANSPORT_NAME", Etrans_name);
            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);
            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;


            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "TRANSPORT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }

            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "TRANSPORT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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

            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Import_PDF_Settings_MASTER()//** kavi & Ajith **//
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", Eproduct_imp_id);

            param[3] = new SqlParameter("@ITEM_DESC", Eproduct_imp_description);
            param[4] = new SqlParameter("@CTH_CODE", Eproduct_imp_cth);
            param[5] = new SqlParameter("@IMPORTER_NAME", Eproduct_imp_ceth);
            //param[6] = new SqlParameter("@PRODUCT_PARTNO", Eproduct_imp_ritc);

            param[2] = new SqlParameter("@name", Ename);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_PDF_UPLOAD_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_PDF_UPLOAD_MASTER_SEARCH_SELECT", param);
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
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public int Import_Product_PDFSetting_Master_Insert_update()//** kavi & Ajith **//
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[200];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", PRODUCT_DESCRIPTION);
            param[2] = new SqlParameter("@PRODUCT_CODE", PRODUCT_CODE);
            param[3] = new SqlParameter("@PRODUCT_RITC", PRODUCT_RITC);
            param[4] = new SqlParameter("@PRODUCT_CTH", PRODUCT_CTH);
            param[5] = new SqlParameter("@PRODUCT_BCD_NOTN", PRODUCT_BCD_NOTN);
            param[6] = new SqlParameter("@PRODUCT_BCD_SLNO", PRODUCT_BCD_SLNO);
            param[7] = new SqlParameter("@PRODUCT_BCD_RATE", PRODUCT_BCD_RATE);
            param[8] = new SqlParameter("@PRODUCT_BCD_SPL", PRODUCT_BCD_SPL);
            param[9] = new SqlParameter("@PRODUCT_BCD_UNIT", PRODUCT_BCD_UNIT);
            param[10] = new SqlParameter("@PRODUCT_BCD_SPL_TYPE", PRODUCT_BCD_SPL_TYPE);
            param[11] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN", PRODUCT_ADDL_DUTY_NOTN);
            param[12] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN_SL", PRODUCT_ADDL_DUTY_NOTN_SL);
            param[13] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN", PRODUCT_EDU_CESS_NOTN);
            param[14] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN_SL", PRODUCT_EDU_CESS_NOTN_SL);
            param[15] = new SqlParameter("@PRODUCT_EDU_CESS_RATE", PRODUCT_EDU_CESS_RATE);
            param[16] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN", PRODUCT_SEC_EDU_CESS_NOTN);
            param[17] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN_SL", PRODUCT_SEC_EDU_CESS_NOTN_SL);
            param[18] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_RATE", PRODUCT_SEC_EDU_CESS_RATE);
            param[19] = new SqlParameter("@PRODUCT_NCD_NOTN", PRODUCT_NCD_NOTN);
            param[20] = new SqlParameter("@PRODUCT_NCD_SLNO", PRODUCT_NCD_SLNO);
            param[21] = new SqlParameter("@PRODUCT_NCD_RATE", PRODUCT_NCD_RATE);
            param[22] = new SqlParameter("@PRODUCT_NCD_SPL", PRODUCT_NCD_SPL);
            param[23] = new SqlParameter("@PRODUCT_NCD_UNIT", PRODUCT_NCD_UNIT);
            param[24] = new SqlParameter("@PRODUCT_NCD_SPL_TYPE", PRODUCT_NCD_SPL_TYPE);
            param[25] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN", PRODUCT_AGGREGATE_DUTY_NOTN);
            param[26] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_SL", PRODUCT_AGGREGATE_DUTY_NOTN_SL);
            param[27] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_RATE", PRODUCT_AGGREGATE_DUTY_NOTN_RATE);
            param[28] = new SqlParameter("@PRODUCT_SAFEGUARD_NOTN", PRODUCT_SAFEGUARD_NOTN);
            param[29] = new SqlParameter("@PRODUCT_SAFEGUARD_SLNO", PRODUCT_SAFEGUARD_SLNO);
            param[30] = new SqlParameter("@PRODUCT_SAFEGUARD_RATE", PRODUCT_SAFEGUARD_RATE);
            param[31] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL", PRODUCT_SAFEGUARD_SPL);
            param[32] = new SqlParameter("@PRODUCT_SAFEGUARD_UNIT", PRODUCT_SAFEGUARD_UNIT);
            param[33] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL_TYPE", PRODUCT_SAFEGUARD_SPL_TYPE);
            param[34] = new SqlParameter("@PRODUCT_CETH", PRODUCT_CETH);
            param[35] = new SqlParameter("@PRODUCT_MRP_YN", PRODUCT_MRP_YN);
            param[36] = new SqlParameter("@PRODUCT_MRP_SL_NO", PRODUCT_MRP_SL_NO);
            param[37] = new SqlParameter("@PRODUCT_MRP_AMOUNT", PRODUCT_MRP_AMOUNT);
            param[38] = new SqlParameter("@PRODUCT_MRP_ABT_RATE", PRODUCT_MRP_ABT_RATE);
            param[39] = new SqlParameter("@PRODUCT_CVD_NOTN", PRODUCT_CVD_NOTN);
            param[40] = new SqlParameter("@PRODUCT_CVD_SLNO", PRODUCT_CVD_SLNO);
            param[41] = new SqlParameter("@PRODUCT_CVD_RATE", PRODUCT_CVD_RATE);
            param[42] = new SqlParameter("@PRODUCT_CVD_SPL", PRODUCT_CVD_SPL);
            param[43] = new SqlParameter("@PRODUCT_CVD_UNIT", PRODUCT_CVD_UNIT);
            param[44] = new SqlParameter("@PRODUCT_CVD_SPL_TYPE", PRODUCT_CVD_SPL_TYPE);
            param[45] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_RATE", PRODUCT_CVD_EDU_CESS_RATE);
            param[46] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_RATE", PRODUCT_CVD_SEC_EDU_CESS_RATE);
            param[47] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN", PRODUCT_ADDL5_SIA_NOTN);
            param[48] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN_SL", PRODUCT_ADDL5_SIA_NOTN_SL);
            param[49] = new SqlParameter("@PRODUCT_ADDL5_SIA_RATE", PRODUCT_ADDL5_SIA_RATE);
            param[50] = new SqlParameter("@PRODUCT_ADDL_GSI_NOTN", PRODUCT_ADDL_GSI_NOTN);
            param[51] = new SqlParameter("@PRODUCT_ADDL_GSI_SLNO", PRODUCT_ADDL_GSI_SLNO);
            param[52] = new SqlParameter("@PRODUCT_ADDL_GSI_RATE", PRODUCT_ADDL_GSI_RATE);
            param[53] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL", PRODUCT_ADDL_GSI_SPL);
            param[54] = new SqlParameter("@PRODUCT_ADDL_GSI_UNIT", PRODUCT_ADDL_GSI_UNIT);
            param[55] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL_TYPE", PRODUCT_ADDL_GSI_SPL_TYPE);
            param[56] = new SqlParameter("@PRODUCT_ADDL_SHEII_NOTN", PRODUCT_ADDL_SHEII_NOTN);
            param[57] = new SqlParameter("@PRODUCT_ADDL_SHEII_SLNO", PRODUCT_ADDL_SHEII_SLNO);
            param[58] = new SqlParameter("@PRODUCT_ADDL_SHEII_RATE", PRODUCT_ADDL_SHEII_RATE);
            param[59] = new SqlParameter("@PRODUCT_ADDL_SHEII_SPL", PRODUCT_ADDL_SHEII_SPL);
            param[60] = new SqlParameter("@PRODUCT_ADDL_SHEII_UNIT", PRODUCT_ADDL_SHEII_UNIT);
            param[61] = new SqlParameter("@PRODUCT_ADDL_SHEII_TYPE", PRODUCT_ADDL_SHEII_TYPE);
            param[62] = new SqlParameter("@PRODUCT_ADDL_TTA_NOTN", PRODUCT_ADDL_TTA_NOTN);
            param[63] = new SqlParameter("@PRODUCT_ADDL_TTA_SLNO", PRODUCT_ADDL_TTA_SLNO);
            param[64] = new SqlParameter("@PRODUCT_ADDL_TTA_RATE", PRODUCT_ADDL_TTA_RATE);
            param[65] = new SqlParameter("@PRODUCT_ADDL_TTA_SPL", PRODUCT_ADDL_TTA_SPL);
            param[66] = new SqlParameter("@PRODUCT_ADDL_TTA_UNIT", PRODUCT_ADDL_TTA_UNIT);
            param[67] = new SqlParameter("@PRODUCT_ADDL_TTA_TYPE", PRODUCT_ADDL_TTA_TYPE);
            param[68] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_NOTN", PRODUCT_ADDL_HEALTH_CESS_NOTN);
            param[69] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SLNO", PRODUCT_ADDL_HEALTH_CESS_SLNO);
            param[70] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_RATE", PRODUCT_ADDL_HEALTH_CESS_RATE);
            param[71] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SPL", PRODUCT_ADDL_HEALTH_CESS_SPL);
            param[72] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_UNIT", PRODUCT_ADDL_HEALTH_CESS_UNIT);
            param[73] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_TYPE", PRODUCT_ADDL_HEALTH_CESS_TYPE);
            param[74] = new SqlParameter("@PRODUCT_CESS_NOTN", PRODUCT_CESS_NOTN);
            param[75] = new SqlParameter("@PRODUCT_CESS_SLNO", PRODUCT_CESS_SLNO);
            param[76] = new SqlParameter("@PRODUCT_CESS_RATE", PRODUCT_CESS_RATE);
            param[77] = new SqlParameter("@PRODUCT_CESS_SPL", PRODUCT_CESS_SPL);
            param[78] = new SqlParameter("@PRODUCT_CESS_UNIT", PRODUCT_CESS_UNIT);
            param[79] = new SqlParameter("@PRODUCT_CESS_TYPE", PRODUCT_CESS_TYPE);
            param[80] = new SqlParameter("@PRODUCT_GENERAL_DESC", PRODUCT_GENERAL_DESC);
            param[81] = new SqlParameter("@PRODUCT_MANUFACTURER", PRODUCT_MANUFACTURER);
            param[82] = new SqlParameter("@PRODUCT_BRAND", PRODUCT_BRAND);
            param[83] = new SqlParameter("@PRODUCT_MODEL", PRODUCT_MODEL);
            param[84] = new SqlParameter("@PRODUCT_END_USE", PRODUCT_END_USE);
            param[85] = new SqlParameter("@PRODUCT_COUNTRY_ORIGIN", PRODUCT_COUNTRY_ORIGIN);
            param[86] = new SqlParameter("@PRODUCT_ACCESSORIES", PRODUCT_ACCESSORIES);
            param[87] = new SqlParameter("@PRODUCT_REMARKS", PRODUCT_REMARKS);
            param[88] = new SqlParameter("@PRODUCT_USER_ID", USER_ID);
            param[89] = new SqlParameter("@PRODUCT_BRANCH_CODE", BRANCH_CODE);
            param[90] = new SqlParameter("@PRODUCT_YEAR", YEAR);
            param[91] = new SqlParameter("@PRODUCT_WORKING_PERIOD", EWorking_Period);

            param[92] = new SqlParameter("@Mflag", flag);
            param[93] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[93].Direction = ParameterDirection.Output;

            param[94] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[94].Direction = ParameterDirection.Output;
            param[95] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[95].Direction = ParameterDirection.Output;

            param[96] = new SqlParameter("@PRODUCT_SAPTA_NOTN", PRODUCT_SAPTA_NOTN);
            param[97] = new SqlParameter("@PRODUCT_SAPTA_SLNO", PRODUCT_SAPTA_SLNO);
            param[98] = new SqlParameter("@PRODUCT_SAPTA_RATE", PRODUCT_SAPTA_RATE);
            param[99] = new SqlParameter("@PRODUCT_TARIFF_NOTN", PRODUCT_TARIFF_NOTN);
            param[100] = new SqlParameter("@PRODUCT_TARIFF_SLNO", PRODUCT_TARIFF_SLNO);
            param[101] = new SqlParameter("@PRODUCT_TARIFF_QTY", PRODUCT_TARIFF_QTY);
            param[102] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT", PRODUCT_TARIFF_AMOUNT);
            param[103] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT_UNIT", PRODUCT_TARIFF_AMOUNT_UNIT);
            param[104] = new SqlParameter("@PRODUCT_RSP_NOTN_NO", RSP_NOTN_NO);
            param[105] = new SqlParameter("@PRODUCT_RSP_NOTN_SL_NO", RSP_NOTN_SL_NO);

            param[110] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_NOTN", PRODUCT_CVD_EDU_CESS_NOTN);
            param[111] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_NOTN_SL", PRODUCT_CVD_EDU_CESS_NOTN_SL);
            param[112] = new SqlParameter("@PRODUCT_CETH_EDU_CESS_RATE", PRODUCT_CETH_EDU_CESS_RATE);

            param[113] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_NOTN", PRODUCT_CVD_SEC_EDU_CESS_NOTN);
            param[114] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL", PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL);
            param[115] = new SqlParameter("@PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE", PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE);

            //param[116] = new SqlParameter("@PARTNO", PARTNO);

            param[117] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_NOTN", PRODUCT_CTH_INFRA_CESS_NOTN);
            param[118] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_NOTN_SLNO", PRODUCT_CTH_INFRA_CESS_NOTN_SLNO);
            param[119] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_RATE", PRODUCT_CTH_INFRA_CESS_RATE);

            param[120] = new SqlParameter("@PRODUCT_ADDL_DUTY_RATE", PRODUCT_ADDL_DUTY_RATE);

            param[121] = new SqlParameter("@CENTRAL_EXCISE_FLAG", CENTRAL_EXCISE_FLAG);
            param[122] = new SqlParameter("@MANUFACTURER_PRODUCER", MANUFACTURER_PRODUCER);
            param[123] = new SqlParameter("@M_P_GROWER_CODE", M_P_GROWER_CODE);
            param[124] = new SqlParameter("@M_P_GROWER_ADD1", M_P_GROWER_ADD1);
            param[125] = new SqlParameter("@M_P_GROWER_ADD2", M_P_GROWER_ADD2);
            param[126] = new SqlParameter("@M_P_GROWER_CITY", M_P_GROWER_CITY);
            param[127] = new SqlParameter("@M_P_GROWER_COUNTRY_SUBDIV", M_P_GROWER_COUNTRY_SUBDIV);
            param[128] = new SqlParameter("@M_P_GROWER_PIN", M_P_GROWER_PIN);
            param[129] = new SqlParameter("@M_P_GROWER_COUNTRY", M_P_GROWER_COUNTRY);
            param[130] = new SqlParameter("@SOURCE_COUNTRY", SOURCE_COUNTRY);
            param[131] = new SqlParameter("@TRANSIT_COUNTRY", TRANSIT_COUNTRY);
            param[132] = new SqlParameter("@ACCESSORY_STATUS", ACCESSORY_STATUS);

            param[133] = new SqlParameter("@IGST_LEVY_NOTN", IGST_LEVY_NOTN);
            param[134] = new SqlParameter("@IGST_LEVY_SLNO", IGST_LEVY_SLNO);
            param[135] = new SqlParameter("@IGST_LEVY_RATE", IGST_LEVY_RATE);
            param[136] = new SqlParameter("@IGST_LEVY_SPL", IGST_LEVY_SPL);
            param[137] = new SqlParameter("@IGST_LEVY_UNIT", IGST_LEVY_UNIT);
            param[138] = new SqlParameter("@IGST_LEVY_SPL_TYPE", IGST_LEVY_SPL_TYPE);
            param[139] = new SqlParameter("@IGST_LEVY_EXCEPTION_NOTN", IGST_LEVY_EXCEPTION_NOTN);
            param[140] = new SqlParameter("@IGST_LEVY_EXCEPTION_SLNO", IGST_LEVY_EXCEPTION_SLNO);
            param[141] = new SqlParameter("@IGST_LEVY_EXCEPTION_RATE", IGST_LEVY_EXCEPTION_RATE);
            param[142] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_NOTN", IGST_LEVY_COMPENSATION_CESS_NOTN);
            param[143] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SLNO", IGST_LEVY_COMPENSATION_CESS_SLNO);
            param[144] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_RATE", IGST_LEVY_COMPENSATION_CESS_RATE);
            param[145] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SPL", IGST_LEVY_COMPENSATION_CESS_SPL);
            param[146] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_UNIT", IGST_LEVY_COMPENSATION_CESS_UNIT);
            param[147] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SPL_TYPE", IGST_LEVY_COMPENSATION_CESS_SPL_TYPE);
            param[148] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_NOTN", IGST_LEVY_EXCEPTION_CC_NOTN);
            param[149] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_SLNO", IGST_LEVY_EXCEPTION_CC_SLNO);
            param[150] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_RATE", IGST_LEVY_EXCEPTION_CC_RATE);

            param[151] = new SqlParameter("@LEVY_EXCEMPTION_NOTN_TYPE", LEVY_EXCEMPTION_NOTN_TYPE);
            param[152] = new SqlParameter("@LEVY_EXCEPTION_CC_NOTN_TYPE", LEVY_EXCEPTION_CC_NOTN_TYPE);

            param[153] = new SqlParameter("@SOCIAL_WELFARE_NOTN", SOCIAL_WELFARE_NOTN);
            param[154] = new SqlParameter("@SOCIAL_WELFARE_NOTN_SLNO", SOCIAL_WELFARE_NOTN_SLNO);
            param[155] = new SqlParameter("@SOCIAL_WELFARE_RATE", SOCIAL_WELFARE_RATE);

            param[156] = new SqlParameter("@AIDC_NOTN", AIDC_NOTN);
            param[157] = new SqlParameter("@AIDC_NOTN_SLNO", AIDC_NOTN_SLNO);
            param[158] = new SqlParameter("@AIDC_RATE", AIDC_RATE);

            param[159] = new SqlParameter("@ANTI_DUMPING_NOTN", ANTI_DUMPING_NOTN);
            param[160] = new SqlParameter("@ANTI_DUMPING_NOTN_SLNO", ANTI_DUMPING_NOTN_SLNO);
            param[161] = new SqlParameter("@CTH_SLNO", CTH_SLNO);
            param[162] = new SqlParameter("@CTH_SUPPLIER_SLNO", CTH_SUPPLIER_SLNO);
            param[163] = new SqlParameter("@CTH_QTY", CTH_QTY);

            //param[161] = new SqlParameter("@AIDC_NOTN", AIDC_NOTN);
            //param[162] = new SqlParameter("@AIDC_NOTN_SLNO", AIDC_NOTN_SLNO);
            //param[163] = new SqlParameter("@AIDC_RATE", AIDC_RATE);
            param[164] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);


            param[165] = new SqlParameter("@PRODUCT_OTHER_DUTY_NOTN", PRODUCT_OTHER_DUTY_NOTN);
            param[166] = new SqlParameter("@PRODUCT_OTHER_DUTY_SLNO", PRODUCT_OTHER_DUTY_SLNO);
            param[167] = new SqlParameter("@PRODUCT_OTHER_DUTY_RATE", PRODUCT_OTHER_DUTY_RATE);
            param[168] = new SqlParameter("@PRODUCT_OTHER_DUTY_SPL", PRODUCT_OTHER_DUTY_SPL);
            param[169] = new SqlParameter("@PRODUCT_OTHER_DUTY_UNIT", PRODUCT_OTHER_DUTY_UNIT);
            param[170] = new SqlParameter("@PRODUCT_OTHER_DUTY_TYPE", PRODUCT_OTHER_DUTY_TYPE);

            //param[171] = new SqlParameter("@PART_NO_HE", HE_PartNo);
            //param[172] = new SqlParameter("@PART_NAME_HE", HE_PartName);
            //param[173] = new SqlParameter("@TAX_BENIFIT_Y_N_HE", HE_Tax_Benifit_YN);
            //param[174] = new SqlParameter("@TAX_BENIFIT_PERC_HE", HE_Tax_Benifit_Perc);
            //param[175] = new SqlParameter("@EPA_NOTIFICAION_HE", HE_EPA_Notifi);
            //param[176] = new SqlParameter("@SIMS_YES_NO_HE", HE_SIMS_YN);
            //param[177] = new SqlParameter("@FTA_YES_NO_HE", HE_FTA_YN);

            //param[178] = new SqlParameter("@PART_NO_DT", DT_PartNo);
            //param[179] = new SqlParameter("@PART_NAME_DT", DT_PartName);
            //param[180] = new SqlParameter("@TAX_BENIFIT_Y_N_DT", DT_Tax_Benifit_YN);
            //param[181] = new SqlParameter("@TAX_BENIFIT_PERC_DT", DT_Tax_Benifit_Perc);
            //param[182] = new SqlParameter("@EPA_NOTIFICAION_DT", DT_EPA_Notifi);
            //param[183] = new SqlParameter("@CEPA_IMPL_DATE_DT", DT_CEPA);
            //param[184] = new SqlParameter("@SIMS_YES_NO_DT", DT_SIMS_YN);

            //param[185] = new SqlParameter("@PART_NO_RP", RP_PartNo);
            //param[186] = new SqlParameter("@PART_NAME_RP", RP_Part_Name);
            //param[187] = new SqlParameter("@NET_WEIGHT_RP", RP_Net_Weight);

            param[171] = new SqlParameter("@HE_DT_RP_PART_NO", null);
            param[172] = new SqlParameter("@PART_NAME", PARTNAME);
            param[173] = new SqlParameter("@TAX_BENIFIT_Y_N", TAX_BENIFIT_YN);
            param[174] = new SqlParameter("@TAX_BENIFIT_PERC", TAX_BENIFIT_PERC);
            param[175] = new SqlParameter("@EPA_NOTIFICAION", EPA_NOTIFI);
            param[176] = new SqlParameter("@SIMS_YES_NO", SIMS_YN);
            param[177] = new SqlParameter("@FTA_YES_NO", FTA_YN);
            param[178] = new SqlParameter("@CEPA_IMPL_DATE", CEPA);
            //param[178] = new SqlParameter("@CEPA_IMPL_DATE", DateTime.Now);

            param[179] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[180] = new SqlParameter("@IEC_NO", IEC_NO);
            param[181] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[182] = new SqlParameter("@PART_NO", PART_NO);
            param[183] = new SqlParameter("@ADCODE", ADCODE);
            param[184] = new SqlParameter("@PO_TYPE", PO_TYPE);

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_PDF_SETTINGS_MASTER_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[93].Value.ToString());

            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[95].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;
    }



    public DataSet RetrieveAll_Product_import_PDF_MASTER()//*** kavi & Ajith ***//
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@ID", Eproduct_imp_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@PRODUCT_DESCRIPTION", Eproduct_imp_description);
            param[4] = new SqlParameter("@PRODUCT_CTH", Eproduct_imp_cth);
            param[5] = new SqlParameter("@PRODUCT_CETH", Eproduct_imp_ceth);
            param[6] = new SqlParameter("@PRODUCT_RITC", Eproduct_imp_ritc);
            param[12] = new SqlParameter("@PRODUCT_POTYPE", Eproduct_imp_potype);
            param[13] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[14] = new SqlParameter("@IEC_NO", IEC_NO);
            param[15] = new SqlParameter("@ADCODE", ADCODE);
            param[16] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[17] = new SqlParameter("@PARTNO", PARTNO);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_PDF_SETTINGS_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "Get_RSP_PARTNO_GMMCO" || Ename == "Get_Product_GMMCO" || Ename == "Get_Product_Details_All_GMMCO" || Ename == "Get_Product_PARTNO_CP" || Ename == "Get_Product_Thailand" || Ename == "Get_Product_Details_All_Thailand" || Ename == "Get_Product_PARTNO_Thailand" || Ename == "Get_Product_Details_All_INDEV" || Ename == "Select_Whole_Data")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_PDF_SETTINGS_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_PDF_SETTINGS_MASTER_SEARCH_SELECT", param);
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
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public int EXP_CLIENT_MASTER_Insert_update()//***Kavi & Ajith***//
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@EXP_CLIENT_ID", EXP_CLIENT_ID);
            param[1] = new SqlParameter("@EXP_CLIENT_IEC_NAME", EXP_CLIENT_IEC_NAME);
            param[2] = new SqlParameter("@EXP_CLIENT_BRANCH_SLNO", EXP_CLIENT_BRANCH_SLNO);
            param[3] = new SqlParameter("@EXP_CLIENT_IEC_CODE", EXP_CLIENT_IEC_CODE);
            param[4] = new SqlParameter("@EXP_CLIENT_REMARKS", EXP_CLIENT_REMARKS);
            param[5] = new SqlParameter("@EXP_PDF_CLIENT_NAME", EXP_PDF_CLIENT_NAME);//Dec 19 OCR kavi & Ajith & karthik
            param[6] = new SqlParameter("@EXP_PDF_COMPANY_ID", EXP_PDF_COMPANY_ID);//Dec 19 OCR kavi & Ajith & karthik			
            param[9] = new SqlParameter("@EXP_CLIENT_USER_ID", USER_ID);
            param[10] = new SqlParameter("@EXP_CLIENT_BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@EXP_CLIENT_YEAR", YEAR);
            param[12] = new SqlParameter("@EXP_CLIENT_WORKING_PERIOD", EWorking_Period);

            param[13] = new SqlParameter("@Mflag", flag);
            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_CLIENT_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[14].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[16].Value.ToString());

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }




    public DataSet RetrieveAll_Exp_Client_Master()//***Kavi & Ajith***//
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@EXP_CLIENT_ID", EExp_cli_mas_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@EXP_CLIENT_IEC_NAME", EExp_client_iec_name);
            param[4] = new SqlParameter("@EXP_CLIENT_BRANCH_SLNO", EXP_CLIENT_BRANCH_SLNO);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@startRowIndex", startRowIndex);

            param[8] = new SqlParameter("@maximumRows", maximumRows);

            param[9] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_CLIENT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_CLIENT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[9].Value.ToString());

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

            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_Import_Caterpillar_MASTER()//*** kavi & Ajith ***//
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@ID", Eproduct_imp_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@PRODUCT_DESCRIPTION", Eproduct_imp_description);
            param[4] = new SqlParameter("@PRODUCT_CTH", Eproduct_imp_cth);
            param[5] = new SqlParameter("@PRODUCT_CETH", Eproduct_imp_ceth);
            param[6] = new SqlParameter("@PRODUCT_RITC", Eproduct_imp_ritc);
            param[13] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[14] = new SqlParameter("@IEC_NO", IEC_NO);
            param[15] = new SqlParameter("@ADCODE", ADCODE);
            param[16] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[17] = new SqlParameter("@PARTNO", PARTNO);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_CATERPILLAR_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "Get_RSP_PARTNO_GMMCO" || Ename == "Get_Product_GMMCO" || Ename == "Get_Product_Details_All_GMMCO" || Ename == "Get_Product_PARTNO_CP" || Ename == "Get_Product_Thailand" || Ename == "Get_Product_Details_All_Thailand" || Ename == "Get_Product_PARTNO_Thailand" || Ename == "Get_Product_Details_All_INDEV" || Ename == "Select_Whole_Data")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_CATERPILLAR_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_CATERPILLAR_MASTER_SEARCH_SELECT", param);
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
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public int Import_Product_Caterpillar_Master_Insert_update()//** kavi & Ajith **//
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[200];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", PRODUCT_DESCRIPTION);
            param[2] = new SqlParameter("@PRODUCT_CODE", PRODUCT_CODE);
            param[3] = new SqlParameter("@PRODUCT_RITC", PRODUCT_RITC);
            param[4] = new SqlParameter("@PRODUCT_CTH", PRODUCT_CTH);
            param[5] = new SqlParameter("@PRODUCT_BCD_NOTN", PRODUCT_BCD_NOTN);
            param[6] = new SqlParameter("@PRODUCT_BCD_SLNO", PRODUCT_BCD_SLNO);
            param[7] = new SqlParameter("@PRODUCT_BCD_RATE", PRODUCT_BCD_RATE);
            param[8] = new SqlParameter("@PRODUCT_BCD_SPL", PRODUCT_BCD_SPL);
            param[9] = new SqlParameter("@PRODUCT_BCD_UNIT", PRODUCT_BCD_UNIT);
            param[10] = new SqlParameter("@PRODUCT_BCD_SPL_TYPE", PRODUCT_BCD_SPL_TYPE);
            param[11] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN", PRODUCT_ADDL_DUTY_NOTN);
            param[12] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN_SL", PRODUCT_ADDL_DUTY_NOTN_SL);
            param[13] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN", PRODUCT_EDU_CESS_NOTN);
            param[14] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN_SL", PRODUCT_EDU_CESS_NOTN_SL);
            param[15] = new SqlParameter("@PRODUCT_EDU_CESS_RATE", PRODUCT_EDU_CESS_RATE);
            param[16] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN", PRODUCT_SEC_EDU_CESS_NOTN);
            param[17] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN_SL", PRODUCT_SEC_EDU_CESS_NOTN_SL);
            param[18] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_RATE", PRODUCT_SEC_EDU_CESS_RATE);
            param[19] = new SqlParameter("@PRODUCT_NCD_NOTN", PRODUCT_NCD_NOTN);
            param[20] = new SqlParameter("@PRODUCT_NCD_SLNO", PRODUCT_NCD_SLNO);
            param[21] = new SqlParameter("@PRODUCT_NCD_RATE", PRODUCT_NCD_RATE);
            param[22] = new SqlParameter("@PRODUCT_NCD_SPL", PRODUCT_NCD_SPL);
            param[23] = new SqlParameter("@PRODUCT_NCD_UNIT", PRODUCT_NCD_UNIT);
            param[24] = new SqlParameter("@PRODUCT_NCD_SPL_TYPE", PRODUCT_NCD_SPL_TYPE);
            param[25] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN", PRODUCT_AGGREGATE_DUTY_NOTN);
            param[26] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_SL", PRODUCT_AGGREGATE_DUTY_NOTN_SL);
            param[27] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_RATE", PRODUCT_AGGREGATE_DUTY_NOTN_RATE);
            param[28] = new SqlParameter("@PRODUCT_SAFEGUARD_NOTN", PRODUCT_SAFEGUARD_NOTN);
            param[29] = new SqlParameter("@PRODUCT_SAFEGUARD_SLNO", PRODUCT_SAFEGUARD_SLNO);
            param[30] = new SqlParameter("@PRODUCT_SAFEGUARD_RATE", PRODUCT_SAFEGUARD_RATE);
            param[31] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL", PRODUCT_SAFEGUARD_SPL);
            param[32] = new SqlParameter("@PRODUCT_SAFEGUARD_UNIT", PRODUCT_SAFEGUARD_UNIT);
            param[33] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL_TYPE", PRODUCT_SAFEGUARD_SPL_TYPE);
            param[34] = new SqlParameter("@PRODUCT_CETH", PRODUCT_CETH);
            param[35] = new SqlParameter("@PRODUCT_MRP_YN", PRODUCT_MRP_YN);
            param[36] = new SqlParameter("@PRODUCT_MRP_SL_NO", PRODUCT_MRP_SL_NO);
            param[37] = new SqlParameter("@PRODUCT_MRP_AMOUNT", PRODUCT_MRP_AMOUNT);
            param[38] = new SqlParameter("@PRODUCT_MRP_ABT_RATE", PRODUCT_MRP_ABT_RATE);
            param[39] = new SqlParameter("@PRODUCT_CVD_NOTN", PRODUCT_CVD_NOTN);
            param[40] = new SqlParameter("@PRODUCT_CVD_SLNO", PRODUCT_CVD_SLNO);
            param[41] = new SqlParameter("@PRODUCT_CVD_RATE", PRODUCT_CVD_RATE);
            param[42] = new SqlParameter("@PRODUCT_CVD_SPL", PRODUCT_CVD_SPL);
            param[43] = new SqlParameter("@PRODUCT_CVD_UNIT", PRODUCT_CVD_UNIT);
            param[44] = new SqlParameter("@PRODUCT_CVD_SPL_TYPE", PRODUCT_CVD_SPL_TYPE);
            param[45] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_RATE", PRODUCT_CVD_EDU_CESS_RATE);
            param[46] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_RATE", PRODUCT_CVD_SEC_EDU_CESS_RATE);
            param[47] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN", PRODUCT_ADDL5_SIA_NOTN);
            param[48] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN_SL", PRODUCT_ADDL5_SIA_NOTN_SL);
            param[49] = new SqlParameter("@PRODUCT_ADDL5_SIA_RATE", PRODUCT_ADDL5_SIA_RATE);
            param[50] = new SqlParameter("@PRODUCT_ADDL_GSI_NOTN", PRODUCT_ADDL_GSI_NOTN);
            param[51] = new SqlParameter("@PRODUCT_ADDL_GSI_SLNO", PRODUCT_ADDL_GSI_SLNO);
            param[52] = new SqlParameter("@PRODUCT_ADDL_GSI_RATE", PRODUCT_ADDL_GSI_RATE);
            param[53] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL", PRODUCT_ADDL_GSI_SPL);
            param[54] = new SqlParameter("@PRODUCT_ADDL_GSI_UNIT", PRODUCT_ADDL_GSI_UNIT);
            param[55] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL_TYPE", PRODUCT_ADDL_GSI_SPL_TYPE);
            param[56] = new SqlParameter("@PRODUCT_ADDL_SHEII_NOTN", PRODUCT_ADDL_SHEII_NOTN);
            param[57] = new SqlParameter("@PRODUCT_ADDL_SHEII_SLNO", PRODUCT_ADDL_SHEII_SLNO);
            param[58] = new SqlParameter("@PRODUCT_ADDL_SHEII_RATE", PRODUCT_ADDL_SHEII_RATE);
            param[59] = new SqlParameter("@PRODUCT_ADDL_SHEII_SPL", PRODUCT_ADDL_SHEII_SPL);
            param[60] = new SqlParameter("@PRODUCT_ADDL_SHEII_UNIT", PRODUCT_ADDL_SHEII_UNIT);
            param[61] = new SqlParameter("@PRODUCT_ADDL_SHEII_TYPE", PRODUCT_ADDL_SHEII_TYPE);
            param[62] = new SqlParameter("@PRODUCT_ADDL_TTA_NOTN", PRODUCT_ADDL_TTA_NOTN);
            param[63] = new SqlParameter("@PRODUCT_ADDL_TTA_SLNO", PRODUCT_ADDL_TTA_SLNO);
            param[64] = new SqlParameter("@PRODUCT_ADDL_TTA_RATE", PRODUCT_ADDL_TTA_RATE);
            param[65] = new SqlParameter("@PRODUCT_ADDL_TTA_SPL", PRODUCT_ADDL_TTA_SPL);
            param[66] = new SqlParameter("@PRODUCT_ADDL_TTA_UNIT", PRODUCT_ADDL_TTA_UNIT);
            param[67] = new SqlParameter("@PRODUCT_ADDL_TTA_TYPE", PRODUCT_ADDL_TTA_TYPE);
            param[68] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_NOTN", PRODUCT_ADDL_HEALTH_CESS_NOTN);
            param[69] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SLNO", PRODUCT_ADDL_HEALTH_CESS_SLNO);
            param[70] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_RATE", PRODUCT_ADDL_HEALTH_CESS_RATE);
            param[71] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SPL", PRODUCT_ADDL_HEALTH_CESS_SPL);
            param[72] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_UNIT", PRODUCT_ADDL_HEALTH_CESS_UNIT);
            param[73] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_TYPE", PRODUCT_ADDL_HEALTH_CESS_TYPE);
            param[74] = new SqlParameter("@PRODUCT_CESS_NOTN", PRODUCT_CESS_NOTN);
            param[75] = new SqlParameter("@PRODUCT_CESS_SLNO", PRODUCT_CESS_SLNO);
            param[76] = new SqlParameter("@PRODUCT_CESS_RATE", PRODUCT_CESS_RATE);
            param[77] = new SqlParameter("@PRODUCT_CESS_SPL", PRODUCT_CESS_SPL);
            param[78] = new SqlParameter("@PRODUCT_CESS_UNIT", PRODUCT_CESS_UNIT);
            param[79] = new SqlParameter("@PRODUCT_CESS_TYPE", PRODUCT_CESS_TYPE);
            param[80] = new SqlParameter("@PRODUCT_GENERAL_DESC", PRODUCT_GENERAL_DESC);
            param[81] = new SqlParameter("@PRODUCT_MANUFACTURER", PRODUCT_MANUFACTURER);
            param[82] = new SqlParameter("@PRODUCT_BRAND", PRODUCT_BRAND);
            param[83] = new SqlParameter("@PRODUCT_MODEL", PRODUCT_MODEL);
            param[84] = new SqlParameter("@PRODUCT_END_USE", PRODUCT_END_USE);
            param[85] = new SqlParameter("@PRODUCT_COUNTRY_ORIGIN", PRODUCT_COUNTRY_ORIGIN);
            param[86] = new SqlParameter("@PRODUCT_ACCESSORIES", PRODUCT_ACCESSORIES);
            param[87] = new SqlParameter("@PRODUCT_REMARKS", PRODUCT_REMARKS);
            param[88] = new SqlParameter("@PRODUCT_USER_ID", USER_ID);
            param[89] = new SqlParameter("@PRODUCT_BRANCH_CODE", BRANCH_CODE);
            param[90] = new SqlParameter("@PRODUCT_YEAR", YEAR);
            param[91] = new SqlParameter("@PRODUCT_WORKING_PERIOD", EWorking_Period);

            param[92] = new SqlParameter("@Mflag", flag);
            param[93] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[93].Direction = ParameterDirection.Output;

            param[94] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[94].Direction = ParameterDirection.Output;
            param[95] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[95].Direction = ParameterDirection.Output;

            param[96] = new SqlParameter("@PRODUCT_SAPTA_NOTN", PRODUCT_SAPTA_NOTN);
            param[97] = new SqlParameter("@PRODUCT_SAPTA_SLNO", PRODUCT_SAPTA_SLNO);
            param[98] = new SqlParameter("@PRODUCT_SAPTA_RATE", PRODUCT_SAPTA_RATE);
            param[99] = new SqlParameter("@PRODUCT_TARIFF_NOTN", PRODUCT_TARIFF_NOTN);
            param[100] = new SqlParameter("@PRODUCT_TARIFF_SLNO", PRODUCT_TARIFF_SLNO);
            param[101] = new SqlParameter("@PRODUCT_TARIFF_QTY", PRODUCT_TARIFF_QTY);
            param[102] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT", PRODUCT_TARIFF_AMOUNT);
            param[103] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT_UNIT", PRODUCT_TARIFF_AMOUNT_UNIT);
            param[104] = new SqlParameter("@PRODUCT_RSP_NOTN_NO", RSP_NOTN_NO);
            param[105] = new SqlParameter("@PRODUCT_RSP_NOTN_SL_NO", RSP_NOTN_SL_NO);
            param[110] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_NOTN", PRODUCT_CVD_EDU_CESS_NOTN);
            param[111] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_NOTN_SL", PRODUCT_CVD_EDU_CESS_NOTN_SL);
            param[112] = new SqlParameter("@PRODUCT_CETH_EDU_CESS_RATE", PRODUCT_CETH_EDU_CESS_RATE);
            param[113] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_NOTN", PRODUCT_CVD_SEC_EDU_CESS_NOTN);
            param[114] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL", PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL);
            param[115] = new SqlParameter("@PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE", PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE);

            param[117] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_NOTN", PRODUCT_CTH_INFRA_CESS_NOTN);
            param[118] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_NOTN_SLNO", PRODUCT_CTH_INFRA_CESS_NOTN_SLNO);
            param[119] = new SqlParameter("@PRODUCT_CTH_INFRA_CESS_RATE", PRODUCT_CTH_INFRA_CESS_RATE);
            param[120] = new SqlParameter("@PRODUCT_ADDL_DUTY_RATE", PRODUCT_ADDL_DUTY_RATE);
            param[121] = new SqlParameter("@CENTRAL_EXCISE_FLAG", CENTRAL_EXCISE_FLAG);
            param[122] = new SqlParameter("@MANUFACTURER_PRODUCER", MANUFACTURER_PRODUCER);
            param[123] = new SqlParameter("@M_P_GROWER_CODE", M_P_GROWER_CODE);
            param[124] = new SqlParameter("@M_P_GROWER_ADD1", M_P_GROWER_ADD1);
            param[125] = new SqlParameter("@M_P_GROWER_ADD2", M_P_GROWER_ADD2);
            param[126] = new SqlParameter("@M_P_GROWER_CITY", M_P_GROWER_CITY);
            param[127] = new SqlParameter("@M_P_GROWER_COUNTRY_SUBDIV", M_P_GROWER_COUNTRY_SUBDIV);
            param[128] = new SqlParameter("@M_P_GROWER_PIN", M_P_GROWER_PIN);
            param[129] = new SqlParameter("@M_P_GROWER_COUNTRY", M_P_GROWER_COUNTRY);
            param[130] = new SqlParameter("@SOURCE_COUNTRY", SOURCE_COUNTRY);
            param[131] = new SqlParameter("@TRANSIT_COUNTRY", TRANSIT_COUNTRY);
            param[132] = new SqlParameter("@ACCESSORY_STATUS", ACCESSORY_STATUS);
            param[133] = new SqlParameter("@IGST_LEVY_NOTN", IGST_LEVY_NOTN);
            param[134] = new SqlParameter("@IGST_LEVY_SLNO", IGST_LEVY_SLNO);
            param[135] = new SqlParameter("@IGST_LEVY_RATE", IGST_LEVY_RATE);
            param[136] = new SqlParameter("@IGST_LEVY_SPL", IGST_LEVY_SPL);
            param[137] = new SqlParameter("@IGST_LEVY_UNIT", IGST_LEVY_UNIT);
            param[138] = new SqlParameter("@IGST_LEVY_SPL_TYPE", IGST_LEVY_SPL_TYPE);
            param[139] = new SqlParameter("@IGST_LEVY_EXCEPTION_NOTN", IGST_LEVY_EXCEPTION_NOTN);
            param[140] = new SqlParameter("@IGST_LEVY_EXCEPTION_SLNO", IGST_LEVY_EXCEPTION_SLNO);
            param[141] = new SqlParameter("@IGST_LEVY_EXCEPTION_RATE", IGST_LEVY_EXCEPTION_RATE);
            param[142] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_NOTN", IGST_LEVY_COMPENSATION_CESS_NOTN);
            param[143] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SLNO", IGST_LEVY_COMPENSATION_CESS_SLNO);
            param[144] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_RATE", IGST_LEVY_COMPENSATION_CESS_RATE);
            param[145] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SPL", IGST_LEVY_COMPENSATION_CESS_SPL);
            param[146] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_UNIT", IGST_LEVY_COMPENSATION_CESS_UNIT);
            param[147] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SPL_TYPE", IGST_LEVY_COMPENSATION_CESS_SPL_TYPE);
            param[148] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_NOTN", IGST_LEVY_EXCEPTION_CC_NOTN);
            param[149] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_SLNO", IGST_LEVY_EXCEPTION_CC_SLNO);
            param[150] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_RATE", IGST_LEVY_EXCEPTION_CC_RATE);
            param[151] = new SqlParameter("@LEVY_EXCEMPTION_NOTN_TYPE", LEVY_EXCEMPTION_NOTN_TYPE);
            param[152] = new SqlParameter("@LEVY_EXCEPTION_CC_NOTN_TYPE", LEVY_EXCEPTION_CC_NOTN_TYPE);
            param[153] = new SqlParameter("@SOCIAL_WELFARE_NOTN", SOCIAL_WELFARE_NOTN);
            param[154] = new SqlParameter("@SOCIAL_WELFARE_NOTN_SLNO", SOCIAL_WELFARE_NOTN_SLNO);
            param[155] = new SqlParameter("@SOCIAL_WELFARE_RATE", SOCIAL_WELFARE_RATE);
            param[156] = new SqlParameter("@AIDC_NOTN", AIDC_NOTN);
            param[157] = new SqlParameter("@AIDC_NOTN_SLNO", AIDC_NOTN_SLNO);
            param[158] = new SqlParameter("@AIDC_RATE", AIDC_RATE);
            param[159] = new SqlParameter("@ANTI_DUMPING_NOTN", ANTI_DUMPING_NOTN);
            param[160] = new SqlParameter("@ANTI_DUMPING_NOTN_SLNO", ANTI_DUMPING_NOTN_SLNO);
            param[161] = new SqlParameter("@CTH_SLNO", CTH_SLNO);
            param[162] = new SqlParameter("@CTH_SUPPLIER_SLNO", CTH_SUPPLIER_SLNO);
            param[163] = new SqlParameter("@CTH_QTY", CTH_QTY);
            param[164] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);
            param[165] = new SqlParameter("@PRODUCT_OTHER_DUTY_NOTN", PRODUCT_OTHER_DUTY_NOTN);
            param[166] = new SqlParameter("@PRODUCT_OTHER_DUTY_SLNO", PRODUCT_OTHER_DUTY_SLNO);
            param[167] = new SqlParameter("@PRODUCT_OTHER_DUTY_RATE", PRODUCT_OTHER_DUTY_RATE);
            param[168] = new SqlParameter("@PRODUCT_OTHER_DUTY_SPL", PRODUCT_OTHER_DUTY_SPL);
            param[169] = new SqlParameter("@PRODUCT_OTHER_DUTY_UNIT", PRODUCT_OTHER_DUTY_UNIT);
            param[170] = new SqlParameter("@PRODUCT_OTHER_DUTY_TYPE", PRODUCT_OTHER_DUTY_TYPE);
            param[179] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[180] = new SqlParameter("@IEC_NO", IEC_NO);
            param[181] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[182] = new SqlParameter("@PART_NO", PART_NO);
            param[183] = new SqlParameter("@ADCODE", ADCODE);


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_CATERPILLAR_MASTER_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[93].Value.ToString());

            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[95].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;
    }

    public DataSet Export_Report_Master_OCR()//OCR-Kavi-Ajith-Karthi//
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@EXPORTER_NAME", Exp_Imp_Name);
            param[1] = new SqlParameter("@From_Date", From_Date);
            param[1].Value = string.IsNullOrWhiteSpace(From_Date) ? (object)DBNull.Value : Convert.ToDateTime(From_Date);
            param[2] = new SqlParameter("@To_Date", To_Dates);
            param[2].Value = string.IsNullOrWhiteSpace(To_Dates) ? (object)DBNull.Value : Convert.ToDateTime(To_Dates);
            param[3] = new SqlParameter("@Branch_No", Branches);
            param[4] = new SqlParameter("@Client_Name", Client_Names);
            param[5] = new SqlParameter("@Report_Type", Report_Type);
            param[6] = new SqlParameter("@Mode", Modes);
            param[7] = new SqlParameter("@name", Ename);
            param[8] = new SqlParameter("@CompanyID", companyId);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_REPORT_OCR", param);
            //result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return ds;
    }    
    public int SW_CONSTITUENT_Details_Insert_Update(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_CONST_ID", objUserBL.SW_ID);
            param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", objUserBL.PRODUCT_DESCRIPTION);
            param[2] = new SqlParameter("@PRODUCT_RITC", objUserBL.PRODUCT_RITC);
            param[3] = new SqlParameter("@PART_NO", objUserBL.PART_NO);
            param[4] = new SqlParameter("@CONSTITUENT_SRNO", objUserBL.CONSTITUENT_SRNO);
            param[5] = new SqlParameter("@CONSTITUENT_ELEMENT_NAME", objUserBL.CONSTITUENT_ELEMENT_NAME);
            param[6] = new SqlParameter("@CONSTITUENT_ELEMENT_CODE", objUserBL.CONSTITUENT_ELEMENT_CODE);
            param[7] = new SqlParameter("@CONSTITUENT_PERCENTAGE", objUserBL.CONSTITUENT_PERCENTAGE);
            param[8] = new SqlParameter("@CONSTITUENT_YIELD_PERCENTAGE", objUserBL.CONSTITUENT_YIELD_PERCENTAGE);
            param[9] = new SqlParameter("@ACTIVE_INGREDIENT", objUserBL.ACTIVE_INGREDIENT);
            param[10] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[14] = new SqlParameter("@Mflag", objUserBL.flag);
            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("SINGLEWINDOW_CONSTITUENT_MASTER_INS_UPD_DEL", param);
            result = Convert.ToInt32(param[15].Value.ToString());

            if (objUserBL.flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[17].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }


    public DataSet SingleWindow_CONSTITUENT_Select(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[1] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[1].Direction = ParameterDirection.Output;

            param[2] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@PRODUCT_RITC", objUserBL.PRODUCT_RITC);
            param[4] = new SqlParameter("@PART_NO", objUserBL.PART_NO);

            ds = Connection.Get_Dataset("SINGLEWINDOW_MASTER_SELECT", param);
            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public int SW_Statement(UserBO objUserBL, string Type)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];

            param[0] = new SqlParameter("@SW_STMT_ID", objUserBL.SW_STMT_ID);
            param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", objUserBL.PRODUCT_DESCRIPTION);
            param[2] = new SqlParameter("@PRODUCT_RITC", objUserBL.PRODUCT_RITC);
            param[3] = new SqlParameter("@PART_NO", objUserBL.PART_NO);
            param[4] = new SqlParameter("@USER_ID", objUserBL.USER_ID);

            param[28] = new SqlParameter("@STMT_DECLARATION_TYPE", objUserBL.STMT_DECLARATION_TYPE);
            param[29] = new SqlParameter("@STMT_DECLARATION_NUMBER", objUserBL.STMT_DECLARATION_NUMBER);
            param[30] = new SqlParameter("@STMT_DECLARATION_DATE", Connection.DATE_FORMAT(objUserBL.STMT_DECLARATION_DATE == "" ? "01/01/1900" : objUserBL.STMT_DECLARATION_DATE));

            param[31] = new SqlParameter("@STMT_TYPE", objUserBL.STMT_TYPE);
            param[32] = new SqlParameter("@STMT_CODE", objUserBL.STMT_CODE);
            param[33] = new SqlParameter("@STMT_TEXT", objUserBL.STMT_TEXT);
            param[59] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[62] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[62].Direction = ParameterDirection.Output;

            param[63] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[63].Direction = ParameterDirection.Output;

            param[64] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[64].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("SINGLEWINDOW_STMT_MASTER_INS_UPD", param);

            result = Convert.ToInt32(param[62].Value.ToString());

            if (objUserBL.Ename == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[64].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }


    public DataSet SingleWindow_Statement_Select(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[1] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[1].Direction = ParameterDirection.Output;

            param[2] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@PRODUCT_RITC", objUserBL.PRODUCT_RITC);
            param[4] = new SqlParameter("@PART_NO", objUserBL.PART_NO);

            ds = Connection.Get_Dataset("SINGLEWINDOW_MASTER_SELECT", param);
            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public int SW_INFOTYPE_Details_Insert_Update(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_INFO_TYPE_ID", objUserBL.SW_ID);
            param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", objUserBL.PRODUCT_DESCRIPTION);
            param[2] = new SqlParameter("@PRODUCT_RITC", objUserBL.PRODUCT_RITC);
            param[3] = new SqlParameter("@PART_NO", objUserBL.PART_NO);
            param[4] = new SqlParameter("@INFO_TYPE", objUserBL.INFO_TYPE);
            param[5] = new SqlParameter("@INFO_QUALIFIER", objUserBL.INFO_QUALIFIER);
            param[6] = new SqlParameter("@INFO_CODE", objUserBL.INFO_CODE);
            param[7] = new SqlParameter("@INFO_TEXT", objUserBL.INFO_TEXT);
            param[8] = new SqlParameter("@INFO_MSR", objUserBL.INFO_MSR);
            param[9] = new SqlParameter("@INFO_UQC", objUserBL.INFO_UQC);
            param[10] = new SqlParameter("@DEPARTMENT", objUserBL.DEPARTMENT);
            param[11] = new SqlParameter("@I_U_TYPE", objUserBL.I_U_TYPE);
            param[21] = new SqlParameter("@REGN_DATE", Connection.DATE_FORMAT(objUserBL.REGN_DATE));
            param[22] = new SqlParameter("@REGN_VALIDITY", objUserBL.REGN_VALIDITY);
            param[12] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[16] = new SqlParameter("@Mflag", objUserBL.flag);
            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            param[20] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("SINGLEWINDOW_INFOTYPE_MATSER_INS_UPD", param);
            result = Convert.ToInt32(param[18].Value.ToString());

            if (objUserBL.flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[20].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }



    public DataSet SingleWindow_INFOTYPE_Select(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[1] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[1].Direction = ParameterDirection.Output;

            param[2] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@PRODUCT_RITC", objUserBL.PRODUCT_RITC);
            param[4] = new SqlParameter("@PART_NO", objUserBL.PART_NO);

            ds = Connection.Get_Dataset("SINGLEWINDOW_MASTER_SELECT", param);
            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public int SW_CONTROL_Details_Insert_Update(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_CONTROL_ID", objUserBL.SW_ID);
            param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", objUserBL.PRODUCT_DESCRIPTION);
            param[2] = new SqlParameter("@PRODUCT_RITC", objUserBL.PRODUCT_RITC);
            param[3] = new SqlParameter("@PART_NO", objUserBL.PART_NO);
            param[4] = new SqlParameter("@CONTROL_TYPE_CODE", objUserBL.CONTROL_TYPE_CODE);
            param[5] = new SqlParameter("@CONTROL_LOCATION", objUserBL.CONTROL_LOCATION);
            param[6] = new SqlParameter("@CONTROL_START_DATE", Connection.DATE_FORMAT(objUserBL.CONTROL_START_DATE == null ? "01/01/1900" : objUserBL.CONTROL_START_DATE));
            param[7] = new SqlParameter("@CONTROL_END_DATE", Connection.DATE_FORMAT(objUserBL.CONTROL_END_DATE == null ? "01/01/1900" : objUserBL.CONTROL_END_DATE));
            param[8] = new SqlParameter("@CONTROL_RESULT_CODE", objUserBL.CONTROL_RESULT_CODE);
            param[9] = new SqlParameter("@CONTROL_RESULT_TEXT", objUserBL.CONTROL_RESULT_TEXT);
            param[10] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[14] = new SqlParameter("@Mflag", objUserBL.flag);
            param[21] = new SqlParameter("@CONTROL_MSR", objUserBL.CONTROL_MSR);
            param[22] = new SqlParameter("@CONTROL_UQC", objUserBL.CONTROL_UQC);
            param[23] = new SqlParameter("@CONTROL_SLNO", objUserBL.CONTROL_SLNO);
            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("SINGLEWINDOW_CONTROL_MASTER_INS_UPD", param);
            result = Convert.ToInt32(param[15].Value.ToString());

            if (objUserBL.flag == "S" || objUserBL.flag == "BES")
            {
                UPDATE_ID = Convert.ToInt32(param[17].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }


    public DataSet SingleWindow_CONTROL_Select(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[1] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[1].Direction = ParameterDirection.Output;

            param[2] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@PRODUCT_RITC", objUserBL.PRODUCT_RITC);
            param[4] = new SqlParameter("@PART_NO", objUserBL.PART_NO);

            ds = Connection.Get_Dataset("SINGLEWINDOW_MASTER_SELECT", param);
            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public int SW_PRODUCTION_Details_Insert_Update(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_PROD_ID", objUserBL.SW_ID);
            param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", objUserBL.PRODUCT_DESCRIPTION);
            param[2] = new SqlParameter("@PRODUCT_RITC", objUserBL.PRODUCT_RITC);
            param[3] = new SqlParameter("@PART_NO", objUserBL.PART_NO);

            param[4] = new SqlParameter("@PRODUCTION_BATCH_IDENTIFIER", objUserBL.PRODUCTION_BATCH_IDENTIFIER);
            param[5] = new SqlParameter("@PRODUCTION_BATCH_QUANTITY", objUserBL.PRODUCTION_BATCH_QUANTITY);
            param[6] = new SqlParameter("@UNIT_QTY_CODE", objUserBL.UNIT_QTY_CODE);

            param[7] = new SqlParameter("@DATE_OF_MANUFACTURING", Connection.DATE_FORMAT(objUserBL.DATE_OF_MANUFACTURING == null ? "01/01/1900" : objUserBL.DATE_OF_MANUFACTURING));
            param[8] = new SqlParameter("@DATE_OF_EXPIRY", Connection.DATE_FORMAT(objUserBL.DATE_OF_EXPIRY == null ? "01/01/1900" : objUserBL.DATE_OF_EXPIRY));

            param[9] = new SqlParameter("@BEST_BEFORE", Connection.DATE_FORMAT(objUserBL.BEST_BEFORE == null ? "01/01/1900" : objUserBL.BEST_BEFORE));

            param[10] = new SqlParameter("@RESIDUAL_SHELF_LIFE_DAYS", objUserBL.RESIDUAL_SHELF_LIFE_DAYS);
            param[11] = new SqlParameter("@TOTAL_SHELF_LIFE_DAYS", objUserBL.TOTAL_SHELF_LIFE_DAYS);
            param[12] = new SqlParameter("@RESIDUAL_SHELF_PERCENT", objUserBL.RESIDUAL_SHELF_PERCENT);

            param[13] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[22] = new SqlParameter("@Mflag", objUserBL.flag);
            param[23] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            param[25] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[25].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("SINGLEWINDOW_PRODUCTION_MASTER_INS_UPD", param);
            result = Convert.ToInt32(param[23].Value.ToString());
            if (objUserBL.Ename == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[25].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    public DataSet SingleWindow_PRODUCTION_Select(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[1] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[1].Direction = ParameterDirection.Output;

            param[2] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@PRODUCT_RITC", objUserBL.PRODUCT_RITC);
            param[4] = new SqlParameter("@PART_NO", objUserBL.PART_NO);

            ds = Connection.Get_Dataset("SINGLEWINDOW_MASTER_SELECT", param);
            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public int IMP_CLIENT_MASTER_Insert_update()//***Kavi & Ajith***karthickraja//27-12-2025
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@IMP_CLIENT_ID", IMP_CLIENT_ID);
            param[1] = new SqlParameter("@IMP_CLIENT_IEC_NAME", IMP_CLIENT_IEC_NAME);
            param[2] = new SqlParameter("@IMP_CLIENT_BRANCH_SLNO", IMP_CLIENT_BRANCH_SLNO);
            param[3] = new SqlParameter("@IMP_CLIENT_IEC_CODE", IMP_CLIENT_IEC_CODE);
            param[4] = new SqlParameter("@IMP_CLIENT_REMARKS", IMP_CLIENT_REMARKS);
            param[9] = new SqlParameter("@IMP_CLIENT_USER_ID", USER_ID);
            param[10] = new SqlParameter("@IMP_CLIENT_BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@IMP_CLIENT_YEAR", YEAR);
            param[12] = new SqlParameter("@IMP_CLIENT_WORKING_PERIOD", EWorking_Period);
            param[13] = new SqlParameter("@IMP_PDF_CLIENT_NAME", IMP_PDF_CLIENT_NAME);
            param[14] = new SqlParameter("@IMP_PDF_COMPANY_ID", IMP_PDF_COMPANY_ID);
            param[15] = new SqlParameter("@Mflag", flag);
            param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;



            if (flag == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "OCR_IMP_CLIENT_MASTER_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[16].Value.ToString());
            }
            else
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "OCR_IMP_CLIENT_MASTER_INSERT_UPDATE", param);

                result = Convert.ToInt32(param[16].Value.ToString());
                if (flag == "IMP S")
                    UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());

            }

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }
    public DataSet RetrieveAll_IMP_Client_Master()//***Kavi & Ajith***Karthickraja***//27-12-2025
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[12];

            param[0] = new SqlParameter("@IMP_CLIENT_ID", IMP_CLIENT_ID);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@IMP_CLIENT_IEC_NAME", IMP_CLIENT_IEC_NAME);
            param[4] = new SqlParameter("@IMP_CLIENT_BRANCH_SLNO", IMP_CLIENT_BRANCH_SLNO);

            param[5] = new SqlParameter("@startRowIndex", startRowIndex);

            param[6] = new SqlParameter("@maximumRows", maximumRows);

            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;


            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "OCR_IMP_CLIENT_MASTER_SEARCH_SELECT", param);
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
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet OCR_ANNEXURE_DEFAULT_MASTER()
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@Ename", Ename);
            param[1] = new SqlParameter("@ID", ID);
            param[2] = new SqlParameter("@EXPORTER_NAME", Exp_Imp_Name);
            param[3] = new SqlParameter("@USER_ID", USER_ID);
            param[4] = new SqlParameter("@BRANCH_SL", IMP_CLIENT_BRANCH_SLNO);
            param[5] = new SqlParameter("@MODIFY_USER", MODIFIEDBY);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            // SEA
            param[7] = new SqlParameter("@ANNEX_SEA_SEAL_TYPE", ANNEX_SEA_SEAL_TYPE);
            param[8] = new SqlParameter("@ANNEX_SEA_FAC_STUFFED", ANNEX_SEA_FAC_STUFFED);
            param[9] = new SqlParameter("@ANNEX_SEA_SAMPLE_ACCOM", ANNEX_SEA_SAMPLE_ACCOM);
            param[10] = new SqlParameter("@ANNEX_SEA_NATURE_OF_CARGO", ANNEX_SEA_NATURE_OF_CARGO);
            param[11] = new SqlParameter("@ANNEX_SEA_PKG_UNIT_CODE", ANNEX_SEA_PKG_UNIT_CODE);
            param[12] = new SqlParameter("@ANNEX_SEA_UNIT_MEASUREMENT", ANNEX_SEA_UNIT_MEASUREMENT);
            // CONTAINER
            param[13] = new SqlParameter("@ANNEX_SEA_CON_TYPE", ANNEX_SEA_CON_TYPE);
            param[14] = new SqlParameter("@ANNEX_SEA_CON_SEALTYPE_INDICATOR", ANNEX_SEA_CON_SEALTYPE_INDICATOR);

            // AIR
            param[15] = new SqlParameter("@ANNEX_AIR_GR_UNIT_CODE", ANNEX_AIR_GR_UNIT_CODE);
            param[16] = new SqlParameter("@ANNEX_AIR_UNIT_CODE", ANNEX_AIR_UNIT_CODE);

            // Row Count
            param[17] = new SqlParameter("@startRowIndex", startRowIndex);

            param[18] = new SqlParameter("@maximumRows", maximumRows);

            param[19] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[19].Direction = ParameterDirection.Output;
            //if (Ename == "delete")

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "OCR_ANNEXURE_DEFAULT_MASTER_SEARCH_UPDATE", param);

            if (ds.Tables.Count == 0)
            {
                DataTable dt = new DataTable();
                ds.Tables.Add(dt);
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return ds;
    }

}
