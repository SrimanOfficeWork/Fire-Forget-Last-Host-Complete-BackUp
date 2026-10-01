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

public class Indev_eroyalmaster 
{

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public string str;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
    
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public int result = 0,UPDATE_ID=0;
    private string _Eadcodeid;
    private string _EWorking_Period;
    private string _Ename;
    private string _Eadcode_iec_name;
    private string _Econsigneeid;
    private string _Econsignee_name;
    private string _Ebuyerid;
    private string _Ebuyer_name;

    private string _Eexchange_id;
    private string _Eexchange_effect_dt_from;
    private string _Eexchange_effect_dt_to;
    private string _Eexchange_nont_no;
    private string _Eexchange_notn_date;

    private string _Eproduct_imp_id;
    private string _Eproduct_imp_description;
    private string _Eproduct_imp_cth;
    private string _Eproduct_imp_ceth;
    private string _Eproduct_imp_ritc;

    private string _Eimp_exp_id;
    private string _Eimp_exp_iecno;
    private string _Eimp_exp_brslno;
    private string _Eimp_exp_name;

    private string _Esupid;
    private string _Esup_name;
    private string _permission;
    private string _name;
    private string _companyname;
    private string _Invoice_Currency;

    private string _SVB_ID;
    private string _IMP_NAME;
    private string _SUPPLIER_NAME;



    private string  _PRODUCT_CVD_EDU_CESS_NOTN;
    private string  _PRODUCT_CVD_EDU_CESS_NOTN_SL;
    private string  _PRODUCT_CETH_EDU_CESS_RATE;
    private string  _PRODUCT_CVD_SEC_EDU_CESS_NOTN;
    private string  _PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL;
    private string  _PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE;


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

    public DateTime fdt;
    public DateTime tdt;

    private string _STANDARD_TYPE;
    public string STANDARD_TYPE { get { return _STANDARD_TYPE; } set { _STANDARD_TYPE = value; } }
    private string _TIN_NO;
    public string TIN_NO { get { return _TIN_NO; } set { _TIN_NO = value; } }
    private string _STATE_CODE;
    public string STATE_CODE { get { return _STATE_CODE; } set { _STATE_CODE = value; } }
    private string _PARTNO;
    public string PARTNO { get { return _PARTNO; } set { _PARTNO = value; } }

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
    private string _flag;

    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
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
    public string flag { get { return _flag; } set { _flag = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
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
    // LICENSE MASTER
    public string LICENSE_ID { get; set; }
    public string LICENSE_NO { get; set; }
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

    #endregion
    #region Retrieve
    public DataSet RetrieveAll_Adcode_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@ADCODE_ID",Eadcodeid);
            param[1] = new SqlParameter("@Working_Period",EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@ADCODE_IEC_NAME", Eadcode_iec_name);
            param[9] = new SqlParameter("@ADCODE_IEC_ADCODE", ADCODE_IEC_ADCODE);
            param[11] = new SqlParameter("@ADCODE_IEC_CODE", ADCODE_IEC_CODE);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_ADCODEMASTER__SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_Adcode")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_ADCODEMASTER__SEARCH_SELECT", param);
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
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_ADCODEMASTER__SEARCH_SELECT", param);
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

    public DataSet RetrieveAll_Consignee_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@CONSIGNEE_ID", Econsigneeid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@CONSIGNEE_NAME", Econsignee_name);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_CONSIGNEE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_CONSIGNEE_MASTER_SEARCH_SELECT", param);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_BUYER_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_BUYER_MASTER_SEARCH_SELECT", param);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_IMP_EXP_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_IMP_EXP_MASTER_SEARCH_SELECT", param);
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
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_IMP_EXP_MASTER_SEARCH_SELECT", param);
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
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_IMP_EXP_MASTER_SEARCH_SELECT", param);
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
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_IMP_EXP_MASTER_SEARCH_SELECT", param);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_IMP_EXP_MASTER_SEARCH_SELECT_STD_TYPE", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            if (Ename == "Get_ID" || Ename=="select_conwithcode_STD" || Ename=="BIND_BRANCHES_STANDARD_TYPE" || Ename=="select_branch")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_IMP_EXP_MASTER_SEARCH_SELECT_STD_TYPE", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_IMP_EXP_MASTER_SEARCH_SELECT_STD_TYPE", param);
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
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@EXCHANGE_ID", Eexchange_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM",  Eexchange_effect_dt_from);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_EXCHANGE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_EXCHANGE_MASTER_SEARCH_SELECT", param);
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
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
            }
            else if (Ename == "Ex_Rate")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                string s = param[8].Value.ToString();
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                 string s = param[8].Value.ToString();
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
            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_SUPPLIERMASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "Get_Sup_Name_GMMCO")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_SUPPLIERMASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_SUPPLIERMASTER_SEARCH_SELECT", param);
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
        return  ds;
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "Get_RSP_PARTNO_GMMCO" || Ename == "Get_Product_GMMCO" || Ename == "Get_Product_Details_All_GMMCO" || Ename == "Get_Product_PARTNO_CP" || Ename == "Get_Product_Thailand" || Ename == "Get_Product_Details_All_Thailand" || Ename == "Get_Product_PARTNO_Thailand" || Ename=="Get_Product_Thailand_Check_All" || Ename=="Get_Product_Master_Check_All")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT", param);
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
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@PRODUCT_DESCRIPTION", Eproduct_imp_description);
            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            if (Ename == "Get_RSP_PARTNO_GMMCO" || Ename == "Get_Product_PARTNO_CP")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT_ACCESS_SQL", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_PRODUCT_IMPORT_MASTER_SEARCH_SELECT_ACCESS_SQL", param);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_LICENSE_MASTER__SEARCH_SELECT", param);
               result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_License")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_LICENSE_MASTER__SEARCH_SELECT", param);
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
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_LICENSE_MASTER__SEARCH_SELECT", param);
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
    #endregion
    #region Insert,update

    public int Adcode_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[22];
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
            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            param[20] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_ADCODE_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[17].Value.ToString());
            if(flag=="S")
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
            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_CONSIGNEE_MASTER_INSERT_UPDATE", param);
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

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_BUYER_MASTER_INSERT_UPDATE", param);
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
            param[2] = new SqlParameter("@SUP_ADD1", SUP_ADD1);
            param[3] = new SqlParameter("@SUP_ADD2", SUP_ADD2);
            param[4] = new SqlParameter("@SUP_ADD3", SUP_ADD3);
            param[5] = new SqlParameter("@SUP_COUNTRY_NAME", SUP_COUNTRY_NAME);
            param[6] = new SqlParameter("@SUP_COUNTRY_CODE", SUP_COUNTRY_CODE);
            param[7] = new SqlParameter("@SUP_PIN_CODE", SUP_PIN_CODE);
            param[8] = new SqlParameter("@SUP_REMARKS", SUP_REMARKS);
            param[9] = new SqlParameter("@SUP_USER_ID", USER_ID);
            param[10] = new SqlParameter("@SUP_BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@SUP_YEAR", YEAR);
            param[12] = new SqlParameter("@SUP_WORKING_PERIOD", EWorking_Period);
            param[13] = new SqlParameter("@Mflag", flag);
            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_SUPPLIER_MASTER_INSERT_UPDATE", param);
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

    public int Exchange_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@EXCHANGE_ID", EXCHANGE_ID);
            param[1] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", EXCHANGE_EFFECT_DT_FROM);
            param[2] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", EXCHANGE_EFFECT_DT_TO);
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

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_EXCHANGE_MASTER_INSERT_UPDATE", param);
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
            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_IMP_EXP_MASTER_INSERT_UPDATE", param);

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

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_IMP_EXP_MASTER_INSERT_UPDATE_STD", param);
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
            SqlParameter[] param = new SqlParameter[150];
            param[0] = new SqlParameter("@PRODUCT_IMPORT_ID",PRODUCT_IMPORT_ID);
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
            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SP_PRODUCT_IMPORT_MASTER_INSERT_UPDATE", param);
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
            SqlParameter[] param = new SqlParameter[22];
            param[0] = new SqlParameter("@LICENSE_ID", LICENSE_ID);
            param[1] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
            param[2] = new SqlParameter("@LICENSE_DATE", DateTime.Parse(LICENSE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[3] = new SqlParameter("@LICENSE_R_SL_NO", LICENSE_R_SL_NO);
            param[4] = new SqlParameter("@LICENSE_REG_DATE",DateTime.Parse(LICENSE_REG_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[5] = new SqlParameter("@LICENSE_REG_TYPE", LICENSE_REG_TYPE);
            param[6] = new SqlParameter("@LICENSE_ITEM_SL_NO", LICENSE_ITEM_SL_NO);
            param[7] = new SqlParameter("@LICENSE_ITEM_DESCRIPTION", LICENSE_ITEM_DESCRIPTION);
            param[8] = new SqlParameter("@LICENSE_QTY", LICENSE_QTY);
            param[9] = new SqlParameter("@LICENSE_UNIT", LICENSE_UNIT);
            param[10] = new SqlParameter("@LICENSE_TYPE", LICENSE_TYPE);
            param[12] = new SqlParameter("@LICENSE_USER_ID", USER_ID);
            param[13] = new SqlParameter("@LICENSE_BRANCH_CODE", BRANCH_CODE);
            param[14] = new SqlParameter("@LICENSE_YEAR", YEAR);
            param[15] = new SqlParameter("@LICENSE_WORKING_PERIOD", EWorking_Period);
            param[16] = new SqlParameter("@Mflag", flag);
            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            param[20] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_LICENSE_MASTER_INSERT_UPDATE", param);
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
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SVB_RELATION_MASTER_SEARCH", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_Adcode")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SVB_RELATION_MASTER_SEARCH", param);
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
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_SVB_RELATION_MASTER_SEARCH", param);
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
    
}
