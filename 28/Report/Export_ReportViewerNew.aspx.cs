using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Web.UI.WebControls.WebParts;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using Ionic.Zip;
using System.Text.RegularExpressions;
using System.Net;

public partial class Report_Export_Export_ReportViewer : System.Web.UI.Page
{

    Export_CheckList CHKLIST = new Export_CheckList();
    Date_Time dt = new Date_Time();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    AppSession aps = new AppSession();
    public int Is_STR = 0, IS_ANNEXURE_MODE = 0;
    public string Annexure_Mode = "", STR_Code = "", str_FOB_AMOUNT_FC = "";
    double Actual_Individual_Item_Amt = 0.00;
    double Actual_Individual_Item_Amt_INR = 0.00;
    double REMAINING_COMMISSION_AMT = 0.00;

    double indi_commi = 0.00;

    public string errorFolder = "";
    public string SCHEME_CODE_LEV;

    public string DECLARATION = "";
    public string COMPANY_ID = "";

    Job_Histroy jh = new Job_Histroy();
    DataSet job_his = new DataSet();
    DataSet dt_All_Rates = new DataSet();
    ErrorLogs er = new ErrorLogs();

    //-------------------------EXPORT GENERAL ATTRIBUTES--------------------//
    #region Private_Attributes

    private string _Today_dt;


    private string _JOBDATE;
    private string _TRANSPORT_MODE;
    private string _CUSTOMS_HOUSE;
    private string _SB_TYPE;
    private string _EXPORTER_NAME;
    private string _BRANCH_NO;
    private string _IEC_NO;

    private string _ADCODE;
    private string _BANK_ACCOUNT;
    private string _DRAWBACK_ACCOUNT;
    private string _CONSIGNEE_NAME;
    private string _CONSIGNEE_ADD1;
    private string _CONSIGNEE_ADD2;
    private string _CONSIGNEE_ADD3;
    private string _CONSIGNEE_ADD4;
    private string _CONSIGNEE_ADD5;
    private string _COUNTRY_DISCHARGE;
    private string _PORT_DISCHARGE;
    private string _COUNTRY_FINAL_DEST;
    private string _PORT_FINAL_DEST;
    private string _STATE_OF_EXPORT;
    private string _NFEI;
    private string _NFEI_TYPE;
    private string _RBI_WAIVER_NO;
    private string _RBI_WAIVER_DATE;
    private string _MARKS_NO;


    private string _NATURE_OF_CARGO;
    private string _MARKS_NOS;
    private string _TOTAL_PACKAGES;
    private string _LOOSE_PACKETS;
    private string _NO_CONTAINERS;
    private string _GROSS_WEIGHT;
    private string _NET_WEIGHT;
    private string _ANNEX_AIR_MAWB_NO;
    private string _ANNEX_AIR_HAWB_NO;
    private string _ANNEX_AIR_GR_UNIT_CODE;

    private string _DRAWBACK_VALUE;
    private string _FILE_REF_NO;
    private string _IMP_EXP_PAN_NO;

    private string _ANNEX_SEA_SEAL_TYPE;

    private string _STR_AMT;

    private string _TYPE_OF_EXPORTER;

    private double _DBK_STR_AMT;

    private string _Working_Period;
    private string _SB_NO_DATE;

    private string _GSTN_TYPE, _GSTN_ID;

    private string
_TERMS_PLACE,
_THIRDPARTY_NAME,
_THIRDPARTY_ADD1,
_THIRDPARTY_ADD2,
_THIRDPARTY_CITY,
_T_PARTY_COUNTRY_SUB_DIV,
_T_PARTY_COUNTRY_CODE,
_T_PARTY_PIN,
_AUTHORIZED_ECONOMIC_OPERATOR_CODE,
_A_E_O_COUNTRY,
_AUTHORIZED_ECONOMIC_OPERATOR;

    #endregion

    #region Public_Attributes

    public string Today_dt { get { return _Today_dt; } set { _Today_dt = value; } }

    //public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string SB_TYPE { get { return _SB_TYPE; } set { _SB_TYPE = value; } }
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    //public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    //public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    //public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    //public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    //public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
    public string ADCODE { get { return _ADCODE; } set { _ADCODE = value; } }
    public string BANK_ACCOUNT { get { return _BANK_ACCOUNT; } set { _BANK_ACCOUNT = value; } }
    public string DRAWBACK_ACCOUNT { get { return _DRAWBACK_ACCOUNT; } set { _DRAWBACK_ACCOUNT = value; } }
    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADD1 { get { return _CONSIGNEE_ADD1; } set { _CONSIGNEE_ADD1 = value; } }
    public string CONSIGNEE_ADD2 { get { return _CONSIGNEE_ADD2; } set { _CONSIGNEE_ADD2 = value; } }
    public string CONSIGNEE_ADD3 { get { return _CONSIGNEE_ADD3; } set { _CONSIGNEE_ADD3 = value; } }
    public string CONSIGNEE_ADD4 { get { return _CONSIGNEE_ADD4; } set { _CONSIGNEE_ADD4 = value; } }
    public string CONSIGNEE_ADD5 { get { return _CONSIGNEE_ADD5; } set { _CONSIGNEE_ADD5 = value; } }
    public string COUNTRY_DISCHARGE { get { return _COUNTRY_DISCHARGE; } set { _COUNTRY_DISCHARGE = value; } }
    public string PORT_DISCHARGE { get { return _PORT_DISCHARGE; } set { _PORT_DISCHARGE = value; } }
    public string COUNTRY_FINAL_DEST { get { return _COUNTRY_FINAL_DEST; } set { _COUNTRY_FINAL_DEST = value; } }
    public string PORT_FINAL_DEST { get { return _PORT_FINAL_DEST; } set { _PORT_FINAL_DEST = value; } }
    public string STATE_OF_EXPORT { get { return _STATE_OF_EXPORT; } set { _STATE_OF_EXPORT = value; } }
    public string NFEI { get { return _NFEI; } set { _NFEI = value; } }
    public string NFEI_TYPE { get { return _NFEI_TYPE; } set { _NFEI_TYPE = value; } }
    public string RBI_WAIVER_NO { get { return _RBI_WAIVER_NO; } set { _RBI_WAIVER_NO = value; } }
    public string RBI_WAIVER_DATE { get { return _RBI_WAIVER_DATE; } set { _RBI_WAIVER_DATE = value; } }
    public string MARKS_NO { get { return _MARKS_NO; } set { _MARKS_NO = value; } }



    public string NATURE_OF_CARGO { get { return _NATURE_OF_CARGO; } set { _NATURE_OF_CARGO = value; } }
    public string MARKS_NOS { get { return _MARKS_NOS; } set { _MARKS_NOS = value; } }
    public string TOTAL_PACKAGES { get { return _TOTAL_PACKAGES; } set { _TOTAL_PACKAGES = value; } }
    public string LOOSE_PACKETS { get { return _LOOSE_PACKETS; } set { _LOOSE_PACKETS = value; } }
    public string NO_CONTAINERS { get { return _NO_CONTAINERS; } set { _NO_CONTAINERS = value; } }
    public string GROSS_WEIGHT { get { return _GROSS_WEIGHT; } set { _GROSS_WEIGHT = value; } }
    public string NET_WEIGHT { get { return _NET_WEIGHT; } set { _NET_WEIGHT = value; } }
    public string ANNEX_AIR_MAWB_NO { get { return _ANNEX_AIR_MAWB_NO; } set { _ANNEX_AIR_MAWB_NO = value; } }
    public string ANNEX_AIR_HAWB_NO { get { return _ANNEX_AIR_HAWB_NO; } set { _ANNEX_AIR_HAWB_NO = value; } }
    public string ANNEX_AIR_GR_UNIT_CODE { get { return _ANNEX_AIR_GR_UNIT_CODE; } set { _ANNEX_AIR_GR_UNIT_CODE = value; } }
    //public string FOB_VALUE { get { return _FOB_VALUE; } set { _FOB_VALUE = value; } }
    public string DRAWBACK_VALUE { get { return _DRAWBACK_VALUE; } set { _DRAWBACK_VALUE = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }

    public string ANNEX_SEA_SEAL_TYPE { get { return _ANNEX_SEA_SEAL_TYPE; } set { _ANNEX_SEA_SEAL_TYPE = value; } }

    public string STR_AMT { get { return _STR_AMT; } set { _STR_AMT = value; } }

    public string TYPE_OF_EXPORTER { get { return _TYPE_OF_EXPORTER; } set { _TYPE_OF_EXPORTER = value; } }


    public double DBK_STR_AMT { get { return _DBK_STR_AMT; } set { _DBK_STR_AMT = value; } }

    public string IMP_EXP_PAN_NO { get { return _IMP_EXP_PAN_NO; } set { _IMP_EXP_PAN_NO = value; } }


    public string SB_NO_DATE { get { return _SB_NO_DATE; } set { _SB_NO_DATE = value; } }
    public int is_Annexure_Mode = 0, is_STR_Code = 0;

    public string GSTN_TYPE { get { return _GSTN_TYPE; } set { _GSTN_TYPE = value; } }
    public string GSTN_ID { get { return _GSTN_ID; } set { _GSTN_ID = value; } }


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


    #endregion
    //-------------------------EXPORT GENERAL ATTRIBUTES--------------------//
    //-------------------------EXPORT ITEM ATTRIBUTES-----------------------//

    #region Private_Attributes

    private string _INVOICE_SLNO;
    private string _INVOICE_NO;
    private string _ITEM_SLNO;
    private string _ITEM_DESCRIPTION;
    private string _RITCNO;
    private string _ITEM_QTY;
    private string _ITEM_QTY_CODE;
    private string _ITEM_UNIT_PRICE;
    private string _ITEM_PER;
    private string _ITEM_AMOUNT;
    private string _ITEM_PMVVALUE;
    private string _ITEM_SCHEME_CODE;
    private string _ITEM_ACCESSORIES_DESC;
    private string _ITEM_AR4_NO;
    private string _ITEM_AR4_DATE;
    private string _ITEM_COMMISSION_RATE;
    private string _ITEM_DIVISION;
    private string _ITEM_RANGE;
    private string _ITEM_REMARKS;
    private string _ITEM_IECCODE;
    private string _BR_SLNO;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;
    private string _ITEM_STR_CODE;
    private string _REWARD_POINTS;
    private string _NUMBERTOWORDS;
    //private double _INDIVIDUAL_INVOICE_VALUE = 0;
    private decimal _INDIVIDUAL_INVOICE_VALUE = 0;

    private string _ITEM_SCHEME_DESC;
    private double _FOB_VALUE1;
    private double _FOB_VALUE, _ACTUAL_ITEM_FOB_VALUE;
    private double _TOTAL_PMVVALUE, _TOTAL_ITEM_PMVVALUE, _TAXABLE_VALUE1, _IGST_AMT1;
    private double FOB_VALUE_ROUND;

    private string _INVOICE_VALUE_FC, _TAXABLE_VALUE, _IGST_AMT, _IGST_RATE, _PMV_METHOD, _PMV_RATE, _PMV_PER_UNIT, _RODTEP;

    private string _STR_RATE;
    private double _STR_AMOUNT;

    private string _ENDUSE_ITEM, _IGST_PAYMENT;

    //Invoice Details
    private string _TERMS;
    private string _EXCHANGE_RATE;

    private string _INVOICE_VALUE, _STR_AMOUNT1, _CESS_AMOUNT, _CESS_YN;
    private string _COMMISSION_RATE;
    private string _COMMISSION_CHARGES;
    private string _COMMISSION_CURRENCY;
    private string _FOB_RATE;
    private string _FOB_CHARGES;
    private string _FOB_CURRENCY;
    private string _PACKMISC_RATE;
    private string _PACKMISC_CHARGES;

    private string _PACKMISC_CURRENCY, _PACKMISC_EXRATE;
    private string _OTHER_DEDUCTION_RATE;
    private string _OTHER_DEDUCTION_CHARGES;
    private string _OTHER_DEDUCTION_CURRENCY;
    private string _FREIGHT_RATE;
    private string _FREIGHT_CHARGES;
    private string _FREIGHT_CURRENCY;

    private string _INSURANCE_RATE;
    private string _INSURANCE_CHARGES;
    private string _INSURANCE_CURRENCY;
    private string _WHEATHER_UNIT_PRICE, _TOTAL_STR_AMOUNT;
    private double DISCOUNT_RATE_AMOUNT = 0, OTHER_DETDUCTION_RATE_AMOUNT = 0;

    private string _MANUFACTURER_PRODUCER;
    private string _M_P_GROWER_CODE;
    private string _M_P_GROWER_ADD1;
    private string _M_P_GROWER_ADD2;
    private string _M_P_GROWER_CITY;
    private string _M_P_GROWER_COUNTRY_SUBDIV;
    private string _M_P_GROWER_PIN;
    private string _M_P_GROWER_COUNTRY;
    private string _SOURCE_STATE;
    private string _TRANSIT_COUNTRY;
    private string _ACCESSORY_STATUS;
    private string _HAWB_NO;
    private string _TOTAL_PKGS;
    //private double _FOB_AMOUNT_FC;
    private string _FOB_AMOUNT_FC;
    #endregion

    #region Drawback Private_Attributes

    //private string _DRAWBACK_ID;
    private string _JOBNO;
    //private string _INVOICE_SLNO;
    //private string _ITEM_SLNO;
    private string _SCHEME_CODE;
    private string _DRAWBACK_SLNO;
    private string _DRAWBACK_QTY;
    private string _DRAWBACK_UNIT;
    private string _DRAWBACK_NOOFUNITS;
    private string _DRAWBACK_RATE;
    private string _DRAWBACK_CAPS;
    private string _DRAWBACK_DESC;
    private string _DRAWBACK_CUSTOMS;
    private string _DRAWBACK_EXCISE;

    // private double _DBK_VALUE;
    private string _DBK_VALUE;
    private string _TOT_LEV_AMT;

    private string _STATE_LEVEL_ADV_RATE;
    private string _STATE_LEVEL_ADV_AMT;

    private string _CENTRAL_LEVEL_ADV_RATE;
    private string _CENTRAL_LEVEL_ADV_AMT;

    //RODTEP

    private string _RODTEP_TARIFF;
    private string _RODTEP_DESC;
    private string _RODTEP_RATE;
    private string _RODTEP_UQC;
    private string _RODTEP_CAP;
    private string _RODTEP_VALUE;
    private string _RODTEP_QTY;

    public string RODTEP_TARIFF { get { return _RODTEP_TARIFF; } set { _RODTEP_TARIFF = value; } }
    public string RODTEP_DESC { get { return _RODTEP_DESC; } set { _RODTEP_DESC = value; } }
    public string RODTEP_RATE { get { return _RODTEP_RATE; } set { _RODTEP_RATE = value; } }
    public string RODTEP_UQC { get { return _RODTEP_UQC; } set { _RODTEP_UQC = value; } }
    public string RODTEP_CAP { get { return _RODTEP_CAP; } set { _RODTEP_CAP = value; } }
    public string RODTEP_VALUE { get { return _RODTEP_VALUE; } set { _RODTEP_VALUE = value; } }
    public string RODTEP_QTY { get { return _RODTEP_QTY; } set { _RODTEP_QTY = value; } }

    #endregion

    #region Drawback Public Attributes

    //public string DRAWBACK_ID { get { return _DRAWBACK_ID; } set { _DRAWBACK_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    ////public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    ////public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
    public string DRAWBACK_SLNO { get { return _DRAWBACK_SLNO; } set { _DRAWBACK_SLNO = value; } }
    public string DRAWBACK_QTY { get { return _DRAWBACK_QTY; } set { _DRAWBACK_QTY = value; } }
    public string DRAWBACK_UNIT { get { return _DRAWBACK_UNIT; } set { _DRAWBACK_UNIT = value; } }
    public string DRAWBACK_NOOFUNITS { get { return _DRAWBACK_NOOFUNITS; } set { _DRAWBACK_NOOFUNITS = value; } }
    public string DRAWBACK_RATE { get { return _DRAWBACK_RATE; } set { _DRAWBACK_RATE = value; } }
    public string DRAWBACK_CAPS { get { return _DRAWBACK_CAPS; } set { _DRAWBACK_CAPS = value; } }
    public string DRAWBACK_DESC { get { return _DRAWBACK_DESC; } set { _DRAWBACK_DESC = value; } }

    public string DRAWBACK_CUSTOMS { get { return _DRAWBACK_CUSTOMS; } set { _DRAWBACK_CUSTOMS = value; } }
    public string DRAWBACK_EXCISE { get { return _DRAWBACK_EXCISE; } set { _DRAWBACK_EXCISE = value; } }

    // public double DBK_VALUE { get { return _DBK_VALUE; } set { _DBK_VALUE = value; } }
    public string DBK_VALUE { get { return _DBK_VALUE; } set { _DBK_VALUE = value; } }
    public string TOT_LEV_AMT { get { return _TOT_LEV_AMT; } set { _TOT_LEV_AMT = value; } }

    public string STATE_LEVEL_ADV_RATE { get { return _STATE_LEVEL_ADV_RATE; } set { _STATE_LEVEL_ADV_RATE = value; } }
    public string STATE_LEVEL_ADV_AMT { get { return _STATE_LEVEL_ADV_AMT; } set { _STATE_LEVEL_ADV_AMT = value; } }

    public string CENTRAL_LEVEL_ADV_RATE { get { return _CENTRAL_LEVEL_ADV_RATE; } set { _CENTRAL_LEVEL_ADV_RATE = value; } }
    public string CENTRAL_LEVEL_ADV_AMT { get { return _CENTRAL_LEVEL_ADV_AMT; } set { _CENTRAL_LEVEL_ADV_AMT = value; } }


    public double cal1, cal2, DBK_FOB, cal3, cal4, cal5, cal6;

    #endregion

    #region Cess & Duty Private_Attributes

    //private string _INVOICE_SLNO;
    //private string _ITEM_SLNO;
    private string _CESS_SLNO;
    private string _CESS_VALUE;
    private string _CESS_UNIT;

    private string _CESS_FLAG;
    private string _CESS_RATE;
    private string _CESS_ITEM_QTY;
    private string _CESS_ITEM_QTY_CODE;
    private string _CESS_TARIFF_VALUE;

    private string _CESS_TARIFF_UNIT;

    private double _CESS_AMT = 0.00;

    private string _DUTY_SLNO;
    private string _DUTY_RATE;
    private string _DUTY_AMOUNT;
    private string _DUTY_UNIT;
    private string _DUTY_QTY;

    private double _TOTAL_DUTY_AMT = 0.00;

    #endregion


    #region Quota Private_Attributes

    private string _ITEM_SL_NO;
    private string _AGENCY_CODE;
    private string _AGENCY_NAME;
    private string _ALLOCATION_NO;
    private string _EXPIRY_DATE;
    private int _SL_NO;
    #endregion

    #region Cess & Duty Public Attributes

    //public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    //public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string CESS_SLNO { get { return _CESS_SLNO; } set { _CESS_SLNO = value; } }

    public string CESS_VALUE { get { return _CESS_VALUE; } set { _CESS_VALUE = value; } }
    public string CESS_UNIT { get { return _CESS_UNIT; } set { _CESS_UNIT = value; } }

    public string CESS_FLAG { get { return _CESS_FLAG; } set { _CESS_FLAG = value; } }
    public string CESS_RATE { get { return _CESS_RATE; } set { _CESS_RATE = value; } }
    public string CESS_ITEM_QTY { get { return _CESS_ITEM_QTY; } set { _CESS_ITEM_QTY = value; } }

    public string CESS_ITEM_QTY_CODE { get { return _CESS_ITEM_QTY_CODE; } set { _CESS_ITEM_QTY_CODE = value; } }
    public string CESS_TARIFF_VALUE { get { return _CESS_TARIFF_VALUE; } set { _CESS_TARIFF_VALUE = value; } }
    public string CESS_TARIFF_UNIT { get { return _CESS_TARIFF_UNIT; } set { _CESS_TARIFF_UNIT = value; } }

    public double CESS_AMT { get { return _CESS_AMT; } set { _CESS_AMT = value; } }


    public string DUTY_SLNO { get { return _DUTY_SLNO; } set { _DUTY_SLNO = value; } }
    public string DUTY_RATE { get { return _DUTY_RATE; } set { _DUTY_RATE = value; } }
    public string DUTY_AMOUNT { get { return _DUTY_AMOUNT; } set { _DUTY_AMOUNT = value; } }
    public string DUTY_UNIT { get { return _DUTY_UNIT; } set { _DUTY_UNIT = value; } }
    public string DUTY_QTY { get { return _DUTY_QTY; } set { _DUTY_QTY = value; } }
    public double TOTAL_DUTY_AMT { get { return _TOTAL_DUTY_AMT; } set { _TOTAL_DUTY_AMT = value; } }


    #endregion


    #region Quota Public Attributes


    public string ITEM_SL_NO { get { return _ITEM_SL_NO; } set { _ITEM_SL_NO = value; } }
    public string AGENCY_CODE { get { return _AGENCY_CODE; } set { _AGENCY_CODE = value; } }

    public string AGENCY_NAME { get { return _AGENCY_NAME; } set { _AGENCY_NAME = value; } }
    public string ALLOCATION_NO { get { return _ALLOCATION_NO; } set { _ALLOCATION_NO = value; } }

    public string EXPIRY_DATE { get { return _EXPIRY_DATE; } set { _EXPIRY_DATE = value; } }

    public int SL_NO { get { return _SL_NO; } set { _SL_NO = value; } }

    #endregion

    #region RE-EXPORT Attributes

    private string _SB_NO;
    private string _SB_DATE;
    private string _SLNO;
    private string _BE_SITE;
    private string _BE_NO;
    private string _BE_DATE;
    private string _BE_INVOICE_NO;
    private string _BE_INVOICE_ITEM_NO;
    private string _MANUAL_BE_Y_N;
    private string _BE_QTY_UTILISED;
    private string _BE_ITEM_DESC;
    private string _BE_QTY;
    private string _BE_UQC;
    private string _BE_ASS_VALUE;
    private string _BE_DUTY_PAID;
    private string _BE_DUTY_PAYMENT_DATE;
    private string _BE_OTH_IDENTIFIABLE_PARAMETER;
    private string _BE_ASS_VALUE_CLAIM;
    private string _BE_ITEM_USED_Y_N;
    private string _COMMISIONER_PERMISSION_Y_N;
    private string _INPUT_CREDIT_Y_N;
    private string _PERSONAL_USED_Y_N;
    private string _MODVAT_AVAILED_Y_N;
    private string _MODVAT_REPAID_Y_N;

    public string SB_NO { get { return _SB_NO; } set { _SB_NO = value; } }
    public string SB_DATE { get { return _SB_DATE; } set { _SB_DATE = value; } }
    public string SLNO { get { return _SLNO; } set { _SLNO = value; } }
    public string BE_SITE { get { return _BE_SITE; } set { _BE_SITE = value; } }
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string BE_DATE { get { return _BE_DATE; } set { _BE_DATE = value; } }
    public string BE_INVOICE_NO { get { return _BE_INVOICE_NO; } set { _BE_INVOICE_NO = value; } }
    public string BE_INVOICE_ITEM_NO { get { return _BE_INVOICE_ITEM_NO; } set { _BE_INVOICE_ITEM_NO = value; } }
    public string MANUAL_BE_Y_N { get { return _MANUAL_BE_Y_N; } set { _MANUAL_BE_Y_N = value; } }
    public string BE_QTY_UTILISED { get { return _BE_QTY_UTILISED; } set { _BE_QTY_UTILISED = value; } }
    public string BE_ITEM_DESC { get { return _BE_ITEM_DESC; } set { _BE_ITEM_DESC = value; } }
    public string BE_QTY { get { return _BE_QTY; } set { _BE_QTY = value; } }
    public string BE_UQC { get { return _BE_UQC; } set { _BE_UQC = value; } }
    public string BE_ASS_VALUE { get { return _BE_ASS_VALUE; } set { _BE_ASS_VALUE = value; } }
    public string BE_DUTY_PAID { get { return _BE_DUTY_PAID; } set { _BE_DUTY_PAID = value; } }
    public string BE_DUTY_PAYMENT_DATE { get { return _BE_DUTY_PAYMENT_DATE; } set { _BE_DUTY_PAYMENT_DATE = value; } }
    public string BE_OTH_IDENTIFIABLE_PARAMETER { get { return _BE_OTH_IDENTIFIABLE_PARAMETER; } set { _BE_OTH_IDENTIFIABLE_PARAMETER = value; } }
    public string BE_ASS_VALUE_CLAIM { get { return _BE_ASS_VALUE_CLAIM; } set { _BE_ASS_VALUE_CLAIM = value; } }
    public string BE_ITEM_USED_Y_N { get { return _BE_ITEM_USED_Y_N; } set { _BE_ITEM_USED_Y_N = value; } }
    public string COMMISIONER_PERMISSION_Y_N { get { return _COMMISIONER_PERMISSION_Y_N; } set { _COMMISIONER_PERMISSION_Y_N = value; } }
    public string INPUT_CREDIT_Y_N { get { return _INPUT_CREDIT_Y_N; } set { _INPUT_CREDIT_Y_N = value; } }
    public string PERSONAL_USED_Y_N { get { return _PERSONAL_USED_Y_N; } set { _PERSONAL_USED_Y_N = value; } }
    public string MODVAT_AVAILED_Y_N { get { return _MODVAT_AVAILED_Y_N; } set { _MODVAT_AVAILED_Y_N = value; } }
    public string MODVAT_REPAID_Y_N { get { return _MODVAT_REPAID_Y_N; } set { _MODVAT_REPAID_Y_N = value; } }


    #endregion

    #region Public_Attributes
    //public double TOTAL_STR_AMOUNT { get { return _TOTAL_STR_AMOUNT; } set { _TOTAL_STR_AMOUNT = value; } }
    public string TOTAL_STR_AMOUNT { get { return _TOTAL_STR_AMOUNT; } set { _TOTAL_STR_AMOUNT = value; } }
    //public double INVOICE_VALUE_FC { get { return _INVOICE_VALUE_FC; } set { _INVOICE_VALUE_FC = value; } }
    //public double FOB_AMOUNT_FC { get { return _FOB_AMOUNT_FC; } set { _FOB_AMOUNT_FC = value; } }

    public string INVOICE_VALUE_FC { get { return _INVOICE_VALUE_FC; } set { _INVOICE_VALUE_FC = value; } }
    public string FOB_AMOUNT_FC { get { return _FOB_AMOUNT_FC; } set { _FOB_AMOUNT_FC = value; } }


    public string TERMS { get { return _TERMS; } set { _TERMS = value; } }
    public string EXCHANGE_RATE { get { return _EXCHANGE_RATE; } set { _EXCHANGE_RATE = value; } }
    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }

    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }

    public string COMMISSION_RATE { get { return _COMMISSION_RATE; } set { _COMMISSION_RATE = value; } }
    public string COMMISSION_CHARGES { get { return _COMMISSION_CHARGES; } set { _COMMISSION_CHARGES = value; } }
    public string COMMISSION_CURRENCY { get { return _COMMISSION_CURRENCY; } set { _COMMISSION_CURRENCY = value; } }
    public string FOB_RATE { get { return _FOB_RATE; } set { _FOB_RATE = value; } }
    public string FOB_CHARGES { get { return _FOB_CHARGES; } set { _FOB_CHARGES = value; } }

    public string FOB_CURRENCY { get { return _FOB_CURRENCY; } set { _FOB_CURRENCY = value; } }

    public string PACKMISC_RATE { get { return _PACKMISC_RATE; } set { _PACKMISC_RATE = value; } }
    public string PACKMISC_CHARGES { get { return _PACKMISC_CHARGES; } set { _PACKMISC_CHARGES = value; } }
    public string PACKMISC_CURRENCY { get { return _PACKMISC_CURRENCY; } set { _PACKMISC_CURRENCY = value; } }
    public string PACKMISC_EXRATE { get { return _PACKMISC_EXRATE; } set { _PACKMISC_EXRATE = value; } }

    public string OTHER_DEDUCTION_RATE { get { return _OTHER_DEDUCTION_RATE; } set { _OTHER_DEDUCTION_RATE = value; } }
    public string OTHER_DEDUCTION_CHARGES { get { return _OTHER_DEDUCTION_CHARGES; } set { _OTHER_DEDUCTION_CHARGES = value; } }
    public string OTHER_DEDUCTION_CURRENCY { get { return _OTHER_DEDUCTION_CURRENCY; } set { _OTHER_DEDUCTION_CURRENCY = value; } }
    public string FREIGHT_RATE { get { return _FREIGHT_RATE; } set { _FREIGHT_RATE = value; } }
    public string FREIGHT_CHARGES { get { return _FREIGHT_CHARGES; } set { _FREIGHT_CHARGES = value; } }
    public string FREIGHT_CURRENCY { get { return _FREIGHT_CURRENCY; } set { _FREIGHT_CURRENCY = value; } }
    public string FREIGHT_EXRATE;
    public string INSURANCE_RATE { get { return _INSURANCE_RATE; } set { _INSURANCE_RATE = value; } }
    public string INSURANCE_CHARGES { get { return _INSURANCE_CHARGES; } set { _INSURANCE_CHARGES = value; } }
    public string INSURANCE_CURRENCY { get { return _INSURANCE_CURRENCY; } set { _INSURANCE_CURRENCY = value; } }
    public string INSURANCE_EXRATE;

    public string WHEATHER_UNIT_PRICE { get { return _WHEATHER_UNIT_PRICE; } set { _WHEATHER_UNIT_PRICE = value; } }
    //public string FOB_VALUE_ROUND { get { return _FOB_VALUE_ROUND; } set { _FOB_VALUE_ROUND = value; } }

    //********** ITEM MANUFACTURE SW ATTRIBUTES
    public string MANUFACTURER_PRODUCER { get { return _MANUFACTURER_PRODUCER; } set { _MANUFACTURER_PRODUCER = value; } }
    public string M_P_GROWER_CODE { get { return _M_P_GROWER_CODE; } set { _M_P_GROWER_CODE = value; } }
    public string M_P_GROWER_ADD1 { get { return _M_P_GROWER_ADD1; } set { _M_P_GROWER_ADD1 = value; } }
    public string M_P_GROWER_ADD2 { get { return _M_P_GROWER_ADD2; } set { _M_P_GROWER_ADD2 = value; } }
    public string M_P_GROWER_CITY { get { return _M_P_GROWER_CITY; } set { _M_P_GROWER_CITY = value; } }
    public string M_P_GROWER_COUNTRY_SUBDIV { get { return _M_P_GROWER_COUNTRY_SUBDIV; } set { _M_P_GROWER_COUNTRY_SUBDIV = value; } }
    public string M_P_GROWER_PIN { get { return _M_P_GROWER_PIN; } set { _M_P_GROWER_PIN = value; } }
    public string M_P_GROWER_COUNTRY { get { return _M_P_GROWER_COUNTRY; } set { _M_P_GROWER_COUNTRY = value; } }
    public string SOURCE_STATE { get { return _SOURCE_STATE; } set { _SOURCE_STATE = value; } }
    public string TRANSIT_COUNTRY { get { return _TRANSIT_COUNTRY; } set { _TRANSIT_COUNTRY = value; } }
    public string ACCESSORY_STATUS { get { return _ACCESSORY_STATUS; } set { _ACCESSORY_STATUS = value; } }
    public string HAWB_NO { get { return _HAWB_NO; } set { _HAWB_NO = value; } }
    public string TOTAL_PKGS { get { return _TOTAL_PKGS; } set { _TOTAL_PKGS = value; } }

    //------------------------ITEM----------------------------------//
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string RITCNO { get { return _RITCNO; } set { _RITCNO = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
    public string ITEM_PER { get { return _ITEM_PER; } set { _ITEM_PER = value; } }
    public string ITEM_AMOUNT { get { return _ITEM_AMOUNT; } set { _ITEM_AMOUNT = value; } }
    public string ITEM_PMVVALUE { get { return _ITEM_PMVVALUE; } set { _ITEM_PMVVALUE = value; } }
    public string ITEM_SCHEME_CODE { get { return _ITEM_SCHEME_CODE; } set { _ITEM_SCHEME_CODE = value; } }
    public string ITEM_ACCESSORIES_DESC { get { return _ITEM_ACCESSORIES_DESC; } set { _ITEM_ACCESSORIES_DESC = value; } }
    public string ITEM_AR4_NO { get { return _ITEM_AR4_NO; } set { _ITEM_AR4_NO = value; } }
    public string ITEM_AR4_DATE { get { return _ITEM_AR4_DATE; } set { _ITEM_AR4_DATE = value; } }
    public string ITEM_COMMISSION_RATE { get { return _ITEM_COMMISSION_RATE; } set { _ITEM_COMMISSION_RATE = value; } }
    public string ITEM_DIVISION { get { return _ITEM_DIVISION; } set { _ITEM_DIVISION = value; } }
    public string ITEM_RANGE { get { return _ITEM_RANGE; } set { _ITEM_RANGE = value; } }
    public string ITEM_REMARKS { get { return _ITEM_REMARKS; } set { _ITEM_REMARKS = value; } }
    public string ITEM_IECCODE { get { return _ITEM_IECCODE; } set { _ITEM_IECCODE = value; } }
    public string BR_SLNO { get { return _BR_SLNO; } set { _BR_SLNO = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
    public string ITEM_STR_CODE { get { return _ITEM_STR_CODE; } set { _ITEM_STR_CODE = value; } }
    public string REWARD_POINTS { get { return _REWARD_POINTS; } set { _REWARD_POINTS = value; } }
    public string NUMBERTOWORDS { get { return _NUMBERTOWORDS; } set { _NUMBERTOWORDS = value; } }

    public string ITEM_SCHEME_DESC { get { return _ITEM_SCHEME_DESC; } set { _ITEM_SCHEME_DESC = value; } }

    public double FOB_VALUE { get { return _FOB_VALUE; } set { _FOB_VALUE = value; } }
    public double ACTUAL_ITEM_FOB_VALUE { get { return _ACTUAL_ITEM_FOB_VALUE; } set { _ACTUAL_ITEM_FOB_VALUE = value; } }

    //public string FOB_VALUE { get { return _FOB_VALUE; } set { _FOB_VALUE = value; } }
    public double TOTAL_PMVVALUE { get { return _TOTAL_PMVVALUE; } set { _TOTAL_PMVVALUE = value; } }
    public double TOTAL_ITEM_PMVVALUE { get { return _TOTAL_ITEM_PMVVALUE; } set { _TOTAL_ITEM_PMVVALUE = value; } }
    // public double FOB_VALUE;

    //public double IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
    //public double TAXABLE_VALUE { get { return _TAXABLE_VALUE; } set { _TAXABLE_VALUE = value; } }
    public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
    public string TAXABLE_VALUE { get { return _TAXABLE_VALUE; } set { _TAXABLE_VALUE = value; } }
    public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }

    public string STR_RATE { get { return _STR_RATE; } set { _STR_RATE = value; } }
    //public double STR_AMOUNT { get { return _STR_AMOUNT; } set { _STR_AMOUNT = value; } }
    public string STR_AMOUNT { get { return _STR_AMOUNT1; } set { _STR_AMOUNT1 = value; } }
    public string CESS_AMOUNT { get { return _CESS_AMOUNT; } set { _CESS_AMOUNT = value; } }
    public string CESS_YN { get { return _CESS_YN; } set { _CESS_YN = value; } }

    public string PMV_METHOD { get { return _PMV_METHOD; } set { _PMV_METHOD = value; } }
    public string PMV_RATE { get { return _PMV_RATE; } set { _PMV_RATE = value; } }
    public string PMV_PER_UNIT { get { return _PMV_PER_UNIT; } set { _PMV_PER_UNIT = value; } }
    public string RODTEP { get { return _RODTEP; } set { _RODTEP = value; } }



    //------------ITEM FOB CALCULATION ATTRIBUTES-------------------------------//
    public double TOTAL_INVOICE_VALUE = 0;
    public double TOTAL_ITEM_INVOICE_VALUE = 0, TOTAL_ITEM_INV_VALUE = 0;
    public double INDIVIDUAL_ITEM_INVOICE_VALUE = 0;
    public double INDIVIDUAL_ITEM_INVOICE_VALUE_PER_UNIT = 0;
    //public double INDIVIDUAL_INVOICE_VALUE { get { return _INDIVIDUAL_INVOICE_VALUE; } set { _INDIVIDUAL_INVOICE_VALUE = value; } }
    public decimal INDIVIDUAL_INVOICE_VALUE { get { return _INDIVIDUAL_INVOICE_VALUE; } set { _INDIVIDUAL_INVOICE_VALUE = value; } }
    public double INDIVIDUAL_COMMISSION_AMOUNT = 0;
    public double INDIVIDUAL_INSURANCE_AMOUNT = 0;
    public double INDIVIDUAL_OTHER_DISCOUNT_AMOUNT = 0;
    public double INDIVIDUAL_FREIGHT_AMOUNT = 0;
    public double INDIVIDUAL_PACKING_CHARGE_AMOUNT = 0;
    public double INDIVIDUAL_FOB_DISCOUNT_AMOUNT = 0;
    public double INDIVIDUAL_FOB_VALUE = 0;
    public double TOTAL_FOB_AMOUNT = 0, SUM_TOTAL_FOB_VALUE = 0, SUM_TOTAL_DBK_VALUE = 0, SUM_TOTAL_STR_AMT = 0, LEV_VALUE = 0, LEV_VALUE_DBK = 0, LEV_VALUE_ROSL = 0, DRAWBACK_VAL = 0, TOTAL_DBK_VALUE = 0, INV_TOTAL_DBK_VAL = 0, RODTEP_VAL = 0, TOTAL_RODTEP_VALUE = 0, TOT_SUM_LEV_AMT = 0;
    public double SInv_Value = 0, SFIValue1 = 0, SFIValue = 0, Individual_Item_Value = 0, Total_Item_Value = 0, TOTAL_INV_VALUE = 0;
    public double TOTAL_FREIGHT_AMOUNT = 0, TOTAL_INSURANCE_AMOUNT = 0, TOTAL_PACKING_AMOUNT = 0;
    public double IND_INVOICE_VALUE = 0, IND_FREIGHT_AMOUNT = 0, IND_INSURANCE_AMOUNT = 0, IND_PACKING_AMOUNT = 0, IND_PMV_VALUE = 0, IND_TOTAL_PMV_VALUE = 0, IND_PER_QTY = 0;
    public double SUM_TOTAL_TAXABLE_VALUE = 0, SUM_TOTAL_IGST_AMT = 0;
    public double INDIVIDUAL_ITEM_IGST_BASED_VALUE = 0;
    //------------ITEM FOB CALCULATION ATTRIBUTES-------------------------------//
    #endregion
    //-------------------------EXPORT ITEM ATTRIBUTES-----------------------//

    #region Private_Attributes



    private string _INVOICE_CURRENCY;

    private string _PAYMENT_METHOD;
    private string _PERIOD_PAYMENT;

    private string _CONTRACT_NO;
    private string _CONTRACT_DATE;
    private string _INVOICE_DATE;
    private string _BUYER;
    private string _BUYER_NAME;
    private string _BUYER_ADDRESS;
    private string _BUYER_ADDRESS1;
    private string _BUYER_ADDRESS2;
    private string _BUYER_ADDRESS3;
    private string _BUYER_ADDRESS4;
    private string _NOTIFY_NAME, _NOTIFY_ADDRESS_1, _NOTIFY_ADDRESS_2, _NOTIFY_ADDRESS_3, _NOTIFY_ADDRESS_COUNTRY;


    private string _No_Of_Invoices;


    #endregion

    #region Public_Attributes

    // Invoice Details


    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string PAYMENT_METHOD { get { return _PAYMENT_METHOD; } set { _PAYMENT_METHOD = value; } }
    public string PERIOD_PAYMENT { get { return _PERIOD_PAYMENT; } set { _PERIOD_PAYMENT = value; } }

    public string INVOICE_CURRENCY { get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }

    public string CONTRACT_NO { get { return _CONTRACT_NO; } set { _CONTRACT_NO = value; } }
    public string CONTRACT_DATE { get { return _CONTRACT_DATE; } set { _CONTRACT_DATE = value; } }

    public string BUYER { get { return _BUYER; } set { _BUYER = value; } }
    public string BUYER_NAME { get { return _BUYER_NAME; } set { _BUYER_NAME = value; } }

    public string BUYER_ADDRESS { get { return _BUYER_ADDRESS; } set { _BUYER_ADDRESS = value; } }
    public string BUYER_ADDRESS1 { get { return _BUYER_ADDRESS1; } set { _BUYER_ADDRESS1 = value; } }
    public string BUYER_ADDRESS2 { get { return _BUYER_ADDRESS2; } set { _BUYER_ADDRESS2 = value; } }
    public string BUYER_ADDRESS3 { get { return _BUYER_ADDRESS3; } set { _BUYER_ADDRESS3 = value; } }
    public string BUYER_ADDRESS4 { get { return _BUYER_ADDRESS4; } set { _BUYER_ADDRESS4 = value; } }
    // Added by pandiyan on 18/04/2026
    public string NOTIFY_NAME { get { return _NOTIFY_NAME; } set { _NOTIFY_NAME = value; } }
    public string NOTIFY_ADDRESS_1 { get { return _NOTIFY_ADDRESS_1; } set { _NOTIFY_ADDRESS_1 = value; } }
    public string NOTIFY_ADDRESS_2 { get { return _NOTIFY_ADDRESS_2; } set { _NOTIFY_ADDRESS_2 = value; } }
    public string NOTIFY_ADDRESS_3 { get { return _NOTIFY_ADDRESS_3; } set { _NOTIFY_ADDRESS_3 = value; } }
    public string NOTIFY_ADDRESS_COUNTRY { get { return _NOTIFY_ADDRESS_COUNTRY; } set { _NOTIFY_ADDRESS_COUNTRY = value; } }

    public string No_Of_Invoices { get { return _No_Of_Invoices; } set { _No_Of_Invoices = value; } }


    public string ENDUSE_ITEM { get { return _ENDUSE_ITEM; } set { _ENDUSE_ITEM = value; } }
    public string IGST_PAYMENT { get { return _IGST_PAYMENT; } set { _IGST_PAYMENT = value; } }
    //public string TAXABLE_VALUE1 { get { return _TAXABLE_VALUE1; } set { _TAXABLE_VALUE1 = value; } }
    //public string IGST_AMT1 { get { return _IGST_AMT1; } set { _IGST_AMT1 = value; } }

    public double TAXABLE_VALUE1 { get { return _TAXABLE_VALUE1; } set { _TAXABLE_VALUE1 = value; } }
    public double IGST_AMT1 { get { return _IGST_AMT1; } set { _IGST_AMT1 = value; } }



    #endregion


    List<Report_Export_Export_ReportViewer> Rpt_Item_Details_new_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_Invoice_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_DrawBack_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_STR_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_RODTEP_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_CESS_Details_list = new List<Report_Export_Export_ReportViewer>();

    public double text_Discount = 0, text_OTHER_DISCOUNT = 0, text_packing = 0;

    DataTable dt_update = new DataTable();
    DataTable dt_update_Addl = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
        COMPANY_ID = Connection.COMPANYID();

        if (Connection.Get_User_Exp_Settings_Job_Edit("ITEM_TAXABLE_IGST_DECIMAL_POINT") == "D")
        {
            hdn_Taxable_igst_Decimal.Value = "D";
        }

        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            //try
            //{
            ViewState["ErrorJobnos"] = "";

            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {
                if (Request.QueryString["IsBulk"] == "N")
                {
                    jobno_load();
                    ddlJob_No.SelectedValue = Request.QueryString["jobno"].ToString();

                    if (string.IsNullOrEmpty(Session["SB_NO"] as string))
                    {
                        Export_Default_Entry.Post_Data(ddlJob_No.SelectedValue.ToString(), "RODTEP");
                    }

                    if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "1344" || COMPANY_ID == "1572" || COMPANY_ID == "1623" || COMPANY_ID == "2078" || COMPANY_ID == "2118" || COMPANY_ID == "2152" || COMPANY_ID == "2153" || COMPANY_ID == "2154" || COMPANY_ID == "2155" || COMPANY_ID == "2214" || COMPANY_ID == "2305")
                    {
                        Export_Default_Entry.CLIENT_BASED_DBK_DEFAULT_ENTRY(ddlJob_No.SelectedValue.ToString(), "DBK_Decl");
                    }

                    if (COMPANY_ID == "1572" || COMPANY_ID == "517")
                    {
                        Export_PDF_Upload.Exp_PDF_Auto_IRN_Insert();//Esanchit_EmailsRead - Master to Job //Split InvoiceNo_Signed.pdf format
                    }

                    if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "1213" || COMPANY_ID == "1532" || COMPANY_ID == "1702" || COMPANY_ID == "2046" || COMPANY_ID == "2059" || COMPANY_ID == "2062" || COMPANY_ID == "2107" || COMPANY_ID == "2118" || COMPANY_ID == "2262" || COMPANY_ID == "2344")
                    {
                        //#Esanchit_EmailsRead - Master to Job
                        Auto_IRN_Insert_from_Esanchit_EmailsRead("Export", ddlJob_No.SelectedValue.ToString());// Imp_INMAA4_JOBNO_InvSlNo_ItemSlNo_invoice.pdf format
                    }


                    if (Request.QueryString["Combine_CH"] == "Y")
                    {
                        ddlJob_No.Enabled = false;
                    }
                    else
                    {
                        ddlJob_No.Enabled = true;
                        Get_Export_Details();
                    }

                    if (Request.QueryString["IGST_Calc"] == "FOB")
                    {

                    }

                    if (Request.QueryString["Direct_CH"] == "Y")
                    {

                        Response.Redirect("../Report/Export_ReportViewerNew.aspx?jobno=" + ddlJob_No.SelectedValue.ToString() + "&Annexure_Mode=" + Annexure_Mode + "&STR_Code=" + STR_Code + "&jobnops=" + ddlJob_No.SelectedItem.Text + "");
                    }
                    else
                    {
                        if (Request.QueryString["IsHdrRepeat"] == "N")
                        {
                            checklistNew();

                        }
                        else
                        {
                            checklistNew_HeaderRepeat();
                        }
                    }
                }
                else if (Request.QueryString["IsBulk"] == "Y")
                {

                    ddlJob_No.Items.Clear();
                    ddlJob_No.Enabled = false;
                    string[] jobno;
                    jobno = Request.QueryString["jobno"].Split(',');
                    if (jobno.Length > 0)
                    {
                        errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID.ToString() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User() + "/EXP_BulkCheckList/");

                        if (Directory.Exists(errorFolder) == false)
                        {
                            Directory.CreateDirectory(errorFolder);
                        }
                        else
                        {
                            foreach (FileInfo fileInformation in new DirectoryInfo(errorFolder).GetFiles())  // delete all the files inside  
                            {
                                File.Delete(fileInformation.FullName);
                            }
                        }

                        for (int job = 0; job < jobno.Length; job++)
                        {
                            ddlJob_No.Items.Insert(job, jobno[job].ToString());
                            ddlJob_No.SelectedValue = jobno[job].ToString();
                            Get_Export_Details();
                            checklistNew();
                        }
                        string vw = ViewState["ExportedJobnos"].ToString();
                        vw = vw.Trim(',');
                        string vwErr = ViewState["ErrorJobnos"].ToString();
                        vwErr = vwErr.Trim(',');

                        string pp = "alert('" + vw + " only got exported. And " + vwErr + " not exported ')";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", pp, true);

                        if (Request.QueryString["ExportMode"] == "Zip")
                        {
                            //*************** start to ZIP ********************//
                            //errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID.ToString() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User() + "/EXP_BulkCheckList/");
                            errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID.ToString() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User());
                            string SourceFolderPath = System.IO.Path.Combine(errorFolder, "EXP_BulkCheckList");
                            string nameFolder = "BulkCheckList";
                            Response.Clear();
                            Response.ContentType = "application/zip";
                            //Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", "jobs.zip"));
                            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", nameFolder + ".zip"));

                            bool recurseDirectories = true;
                            using (ZipFile zip = new ZipFile())
                            {
                                zip.AddSelectedFiles("*", SourceFolderPath, string.Empty, recurseDirectories);
                                zip.Save(Response.OutputStream);
                            }
                            Response.End();
                            //*************** End to ZIP ********************//
                        }

                        else if (Request.QueryString["ExportMode"] == "PDF")
                        {
                            //*************** start to merge all pdf files ********************//
                            errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID.ToString() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User() + "/EXP_BulkCheckList/");
                            var tempFilename = new List<string>();
                            string[] executedJobs;
                            executedJobs = vw.Split(',');
                            if (executedJobs.Length > 0)
                            {
                                for (int job = 0; job < executedJobs.Length; job++)
                                {
                                    tempFilename.Add(errorFolder + executedJobs[job] + ".pdf");
                                }
                            }

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
                                Response.AppendHeader("content-disposition", "inline; filename=" + vw.Replace(",", "_") + ".pdf");
                                Response.End();
                            }
                            //*************** end to merge all pdf files ********************// 
                        }

                    }
                }
            }

            //}
            //catch (Exception ex)
            //{
            //    ErrorLogs er = new ErrorLogs();
            //    er.makeLog(ex.Message);
            //    //string vw = ViewState["ExportedJobnos"].ToString();
            //    //vw = vw.Trim(',');
            //    //string vwErr = ViewState["ErrorJobnos"].ToString();
            //    //vwErr = vwErr.Trim(',');
            //    ////string prompt = "<script>$(document).ready(function(){{jAlert('" + vw + " only get exported  and " + vwErr + " not exported ', 'Expenses Details', function (r) {});}});</script>";
            //    ////ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

            //    //string pp = "alert('" + vw + " only got exported. And " + vwErr + " not exported ')";
            //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", pp, true);

            //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "id", "closeWP()", true);

            //    // Response.Redirect("../Export/ExportBulkCheckList.aspx");

            //}

        }
    }

    private void checklistNew_HeaderRepeat()
    {

        try
        {
            double FOB_total = 0.00;
            double PMV_total = 0.00;
            double Grand_FOB_total = 0.00;
            double Grand_PMV_total = 0.00;

            double Tax_total = 0.00;
            double Grand_Tax_total = 0.00;
            double IGST_total = 0.00;
            double Grand_IGST_total = 0.00;

            string head1 = "";
            string head2 = "";
            string head3 = "";
            string head4 = "";
            //string head5 = "-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            string head5 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------";

            string head6 = ""; string head6_2 = ""; string head6_3 = "";
            string head7 = ""; string head7_2 = "";
            string head8 = ""; string head8_2 = "";




            List<Report_Export_Export_ReportViewer> Load_Item_DetailsInd = new List<Report_Export_Export_ReportViewer>();
            Rpt_Invoice_Details_list.Clear();

            StringBuilder sb = new StringBuilder();
            DataSet dss = new DataSet();
            DataSet dssAss = new DataSet();
            //ddlJobNo = Request.QueryString["jobno"].ToString();
            ddlJobNo = ddlJob_No.SelectedValue.ToString();
            Session["JobNo"] = ddlJobNo;
            ds = (DataSet)HttpContext.Current.Session["EXPORT_CHECKLIST"];

            string SE = "";

            sb.Append("<html><table>");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Auto_Search Auto = new Auto_Search();
                Auto.Enamesearch = ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString();
                Auto.Ename = "State_Code";

                DataSet ss = new DataSet();
                ss = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (ss.Tables[0].Rows.Count > 0)
                {
                    SE = ", " + ss.Tables[0].Rows[0][0].ToString();
                }

                string Exporter = "";
                string Signature = "";
                string cha_Signature = "";
                string cha = "";
                string cha_title = "";
                string cha_Name = "";


                EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                //cha_Name = HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "");//--02-11-2021
                cha_Name = Connection.Get_EXP_CHA_NAME().Replace("amp;", "");

                if (COMPANY_ID != "517" && COMPANY_ID != "480" && COMPANY_ID != "508" && COMPANY_ID != "3388")
                {
                    Exporter = "Exporter";
                    Signature = "Signature";
                    //EXPORTER_NAME = HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "");                  
                }
                else
                {
                    EXPORTER_NAME = "";
                }

                if (COMPANY_ID != "1014" && COMPANY_ID != "1")
                {
                    cha = "CHA";
                    cha_Signature = "Signature";
                    //cha_title = HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "");//--02-11-2021
                    cha_title = Connection.Get_EXP_CHA_NAME().Replace("amp;", "");
                    //EXPORTER_NAME = HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "");
                }
                else
                {
                    EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                }

                if (COMPANY_ID == "539")
                {
                    cha = "Exporter" + "/" + "CHA with date";
                    cha_Signature = "Signature";
                    //cha_title = "For " + HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "");
                    cha_title = "For " + Connection.Get_EXP_CHA_NAME().Replace("amp;", "");
                    EXPORTER_NAME = "";
                    Exporter = "";
                    Signature = "";
                    cha_Signature = "";
                }

                Get_ITEM_Details(ddlJobNo, ds.Tables[1], ds.Tables[2], ds.Tables[5], ds.Tables[15], ds.Tables[13], ds.Tables[26], ds.Tables[27]);

                FOB_VALUE = Math.Round(SUM_TOTAL_FOB_VALUE, 2);
                //DRAWBACK_VALUE = Convert.ToString(Math.Round(SUM_TOTAL_DBK_VALUE, 2));
                DRAWBACK_VALUE = Convert.ToString(Math.Round(SUM_TOTAL_DBK_VALUE, 2).ToString("0.00"));
                STR_AMT = Convert.ToString(Math.Round(SUM_TOTAL_STR_AMT, 2));
                // DBK_STR_AMT = Convert.ToDouble(DRAWBACK_VALUE) + Convert.ToDouble(STR_AMT);
                DBK_STR_AMT = Convert.ToDouble(Math.Round(SUM_TOTAL_DBK_VALUE, 2)) + Convert.ToDouble(Math.Round(SUM_TOTAL_STR_AMT, 2));
                JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString();

                ////*** added on 5/Jan/2018 by jayanthi for calc.total value ****////
                if (Rpt_Invoice_Details_list.Count > 0)
                {

                    Grand_FOB_total = Rpt_Item_Details_new_list.Sum(item => Convert.ToDouble(item.FOB_VALUE));
                    Grand_Tax_total = Rpt_Item_Details_new_list.Sum(item => Convert.ToDouble(item.TAXABLE_VALUE));
                    Grand_PMV_total = Rpt_Item_Details_new_list.Sum(item => Convert.ToDouble(item.TOTAL_PMVVALUE));
                    Grand_IGST_total = Rpt_Item_Details_new_list.Sum(item => Convert.ToDouble(item.IGST_AMT));


                }
                ////*** end of added on 5/Jan/2018 by jayanthi for calc.total value ****////

                head1 = cha_Name;
                head2 = "CHECK LIST - Shipping Bill";
                head3 = ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString();
                head4 = "S.B No & Date: " + ds.Tables[0].Rows[0]["SB_NO"] + "  " + ds.Tables[0].Rows[0]["SB_Date"] + "                                                                                              Printed On : " + ds.Tables[0].Rows[0]["printdate"] + " ";
                //head6 = "Job No         : " + ddlJob_No.SelectedItem.Text + "                                            File No : " + ds.Tables[0].Rows[0]["FILE_REF_NO"] + " Job Date : " + ds.Tables[0].Rows[0]["JOBDATE"] + " ";
                head6 = "Job No               : " + ddlJob_No.SelectedItem.Text;
                head6_2 = "File No              : " + ds.Tables[0].Rows[0]["FILE_REF_NO"];
                head6_3 = "Job Date : " + ds.Tables[0].Rows[0]["JOBDATE"] + " ";
                //head7 = "CHA                    : " + HttpContext.Current.Session["CHA_NO"].ToString();//--02-11-2021
                //head7_2 = "Name                 : " + HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "");//--02-11-2021

                head7 = "CHA                    : " + Connection.Get_EXP_CHA_NO();
                head7_2 = "Name                 : " + Connection.Get_EXP_CHA_NAME().Replace("amp;", "");

                head8 = "Port Of Loading : " + ds.Tables[0].Rows[0]["Customs_House"];
                head8_2 = "State Of Origin : " + ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString() + " " + SE + " ";



                //sb.Append("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>");

                //sb.Append("<tr style='text-align:center; font-weight:bold; font-size:12px'><td colspan='10'> " + cha_Name + " </td></tr>");
                //sb.Append("<tr style='text-align:center; font-weight:bold; font-size:11px'><td colspan='10'> CHECK LIST - Shipping Bill</td></tr>");
                //sb.Append("<tr style='text-align:center; font-weight:bold; font-size:11px'><td colspan='10'> " + ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString() + "</td></tr>");
                //sb.Append("<tr><td2FWB@123>S.B No & Date</td> <td colspan='3'><b>:</b> " + ds.Tables[0].Rows[0]["SB_NO"] + "  " + ds.Tables[0].Rows[0]["SB_Date"] + " </td> <td colspan='5' style='font-weight:bold'> Printed On : " + ds.Tables[0].Rows[0]["printdate"] + " </td></tr>");
                //sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9
                //sb.Append("<tr><td2FWB@123>Job No</td> <td><b>:</b> " + ddlJob_No.SelectedItem.Text + "</td><td2@CS><b>File No :</b>" + ds.Tables[0].Rows[0]["FILE_REF_NO"] + "</td><td2FWB@123>Job Date</td> <td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["JOBDATE"] + "</td> </tr>");
                //sb.Append("<tr><td2FWB@123>CHA</td><td3@CS><b>:</b> " + HttpContext.Current.Session["CHA_NO"].ToString() + "</td> <td2FWB@123>Name</td><td3@CS><b>:</b> " + HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", "") + "</td></tr>");
                //sb.Append("<tr><td2FWB@123>Port Of Loading</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["Customs_House"] + "</td> <td2FWB@123>State Of Origin</td><td colspan='3'><b>:</b> " + ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString() + " " + SE + "</td></tr>");
                //sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9
                //sb.Append("<html><table>");
                sb.Append("<tr><td4FWB@123>Exporter Details :</td><td6FWB@123>Consignee Details :</td></tr>");

                if (ds.Tables[0].Rows[0]["IMP_EXP_PAN_NO"].ToString() != "")
                    sb.Append("<tr><td4@CS>" + ds.Tables[0].Rows[0]["IEC_NO"] + "  PAN :" + ds.Tables[0].Rows[0]["IMP_EXP_PAN_NO"] + " </td><td6@CS>" + ds.Tables[0].Rows[0]["Consignee_name"] + "</td></tr>");
                else
                    sb.Append("<tr><td5@CS>" + ds.Tables[0].Rows[0]["IEC_NO"] + "</td><td5@CS>" + ds.Tables[0].Rows[0]["Consignee_name"] + "</td></tr>");

                sb.Append("<tr><td4@CS>" + ds.Tables[0].Rows[0]["Exporter_Name"] + "</td><td6@CS>" + ds.Tables[0].Rows[0]["Consignee_Add1"] + "</td></tr>");
                sb.Append("<tr><td4@CS>Branch Sr.No: " + ds.Tables[0].Rows[0]["Branch_NO"] + "</td><td6@CS>" + ds.Tables[0].Rows[0]["Consignee_Add2"] + "</td></tr>");
                sb.Append("<tr><td4@CS>" + ds.Tables[0].Rows[0]["ADDRESS1"] + "</td><td6@CS>" + ds.Tables[0].Rows[0]["Consignee_Add3"] + "</td></tr>");
                sb.Append("<tr><td4@CS>" + ds.Tables[0].Rows[0]["ADDRESS2"] + "</td><td6@CS>" + ds.Tables[0].Rows[0]["Consignee_Add4"] + "</td></tr>");
                sb.Append("<tr><td4@CS>" + ds.Tables[0].Rows[0]["ADDRESS3"] + "</td><td6@CS>" + ds.Tables[0].Rows[0]["Consignee_Add5"] + "</td></tr>");
                sb.Append("<tr><td10@CS>" + ds.Tables[0].Rows[0]["ADDRESS4"] + " " + ds.Tables[0].Rows[0]["ADDRESS5"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>GSTN Type / ID</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["GSTN_TYPE"] + " / " + ds.Tables[0].Rows[0]["GSTN_ID"] + "</td><td2FWB@123>AD Code</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["ADCode"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Type Of Exporter</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER_New"] + "</td><td2FWB@123>SEAL Type</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEAL_TYPE"] + "</td></tr>");

                sb.Append("<tr><td2FWB@123>Port Discharge </td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["PORT_DISCHARGE"] + "</td><td2FWB@123>Total Packages</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["TOTAL_PACKAGES"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Country Discharge</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"] + "</td><td2FWB@123>Loose Packets</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["LOOSE_PACKETS"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Port Final Dest</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["PORT_FINAL_DEST"] + "</td><td2FWB@123>Net Weight</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["NET_WEIGHT"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Country Final Dest</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"] + "</td><td2FWB@123>No Of Containers</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["NO_CONTAINERS"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Gross Weight</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["GROSS_WEIGHT"] + "</td><td2FWB@123>NFEI Type</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["NFEI_TYPE"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Nature Of Cargo</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["NATURE_OF_CARGO"] + "</td><td2FWB@123>RBI Waiver No</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["RBI_WAIVER_NO"] + "</td></tr>");

                if (ds.Tables[0].Rows[0]["MARKS_NO"].ToString() == "")
                    sb.Append("<tr><td2FWB@123>Marks & Nos</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["MARKS_NO"] + "</td><td2FWB@123>RBI Waiver Date</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"] + "</td></tr>");
                else
                {
                    sb.Append("<tr><td4@CS></td><td2FWB@123>RBI Waiver Date</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"] + "</td></tr>");
                    sb.Append("<tr> <td colspan='2' style='font-weight:bold; vertical-align:top'>Marks & Nos</td><td8@CS><b>:</b> " + ds.Tables[0].Rows[0]["MARKS_NO"] + "</td></tr>");
                }

                //if (ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString() != "" && ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString() != "")
                if (ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString() != "" || ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString() != "")
                {
                    sb.Append("<tr><td2FWB@123>Mawb No</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"] + "</td><td2FWB@123>Hawb No</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"] + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Mawb Date</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_DATE"] + "</td><td2FWB@123>Hawb Date</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_DATE"] + "</td></tr>");
                }
                sb.Append("<tr><td2FWB@123>Forex Bank A/C No </td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["BANK_ACCOUNT"] + "</td><td2FWB@123>Drawback (INR)</td><td4@CS><b>:</b> " + DRAWBACK_VALUE + "</td></tr>");


                //sb.Append("<tr><td2FWB@123>FOB Value</td><td2@CS><b>:</b> " + FOB_VALUE + "</td><td2FWB@123>Bank A/C No</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"] + "</td></tr>");
                //sb.Append("<tr><td2FWB@123>IGST Tax Value(INR)</td><td2@CS><b>:</b> " + TAXABLE_VALUE + "</td><td2FWB@123>IGST Amt Paid(INR)</td><td4@CS><b>:</b> " + IGST_AMT + "</td></tr>");
                //if (STR_AMT != "0")
                //    sb.Append("<tr><td2FWB@123>ServiceTax refund(INR)</td><td2@CS><b>:</b> " + STR_AMT + "</td><td2FWB@123>DBK + STR (INR)</td><td4@CS><b>:</b> " + DBK_STR_AMT + "</td></tr>");


                //this line hide by Chithra on 22-01-2020 for agility IFSC Code show & Allignment Corrections
                //sb.Append("<tr><td2FWB@123>FOB Value</td><td2@CS><b>:</b> " + Grand_FOB_total + "</td><td2FWB@123>Bank A/C No</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"] + "</td></tr>");
                //sb.Append("<tr><td2FWB@123>IGST Tax Value(INR)</td><td2@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(Grand_Tax_total, 2)) + "</td><td2FWB@123>IGST Amt Paid(INR)</td><td4@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(Grand_IGST_total, 2)) + "</td></tr>");

                sb.Append("<tr><td2FWB@123>Bank A/C No</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"] + "</td><td2FWB@123>FOB Value</td><td4@CS><b>:</b> " + Grand_FOB_total + "</td></tr>");
                sb.Append("<tr><td2FWB@123>IFSC Code</td><td2@CS><b>:</b> " + ds.Tables[0].Rows[0]["IFSC_CODE"] + "</td><td2FWB@123>IGST Val</td><td4@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(Grand_Tax_total, 2)) + "</td></tr>");
                sb.Append("<tr><td2FWB@123></td><td2@CS><b></b> " + "" + "</td><td2FWB@123>IGST Amt</td><td4@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(Grand_IGST_total, 2)) + "</td></tr>");

                if (STR_AMT != "0")
                    sb.Append("<tr><td2FWB@123>ServiceTax refund(INR)</td><td2@CS><b>:</b> " + STR_AMT + "</td><td2FWB@123>DBK + STR (INR)</td><td4@CS><b>:</b> " + DBK_STR_AMT + "</td></tr>");



                //  ************  start of Invoice details  *****************//

                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9
                sb.Append("<tr><td2FWB@123>INVOICE DETAILS</td><td8@CS>No Of Invoices : " + ds.Tables[1].Rows.Count + "</td></tr>");
                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9

                int rwno = 0;

                for (int inv = 0; inv < Rpt_Invoice_Details_list.Count; inv++)
                {

                    if (inv > 0)
                    {
                        sb.Append("</table></html><html><table>");
                    }

                    sb.Append("<tr><td2FWB@123>Inv.SlNo</td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INVOICE_SLNO + "</td><td2FWB@123>Whether Unit Price </td> <td4@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].WHEATHER_UNIT_PRICE + "</td> </tr>");
                    sb.Append("<tr><td2FWB@123>Invoice No</td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INVOICE_NO + "</td><td2FWB@123>Invoice Date</td> <td4@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INVOICE_DATE + "</td> </tr>");
                    sb.Append("<tr><td2FWB@123>Nature Of Contract</td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].TERMS + "</td><td6FWB@123>Buyer Details</td><b>:</b> </tr>");
                    sb.Append("<tr><td2FWB@123>Nature Of Payment</td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].PAYMENT_METHOD + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].BUYER_NAME + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Period Of Agreement</td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].PERIOD_PAYMENT + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Contract No</td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].CONTRACT_NO + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS1 + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Currency Code</td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INVOICE_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS2 + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Exchange Rate  </td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].EXCHANGE_RATE + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS3 + " " + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS4 + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Invoice Value(FC) </td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INVOICE_VALUE_FC + "</td></tr>");


                    if (COMPANY_ID == "1039")
                    {
                        sb.Append("<tr><td2FWB@123>Invoice Value(INR) </td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INDIVIDUAL_INVOICE_VALUE + "</td><td3@CS><b>DBK Value(INR) :</b> " + Rpt_Invoice_Details_list[inv].DBK_VALUE + "</td><td3@CS><b></b>" + "" + "</td></tr>"); // VETRI IMPEX - FOB (FC) should not show - sugg by Bala sir on 13/11/2019 - done by Chithra
                    }
                    else
                    {
                        sb.Append("<tr><td2FWB@123>Invoice Value(INR) </td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INDIVIDUAL_INVOICE_VALUE + "</td><td3@CS><b>DBK Value(INR) :</b> " + Rpt_Invoice_Details_list[inv].DBK_VALUE + "</td><td3@CS><b>FOB (FC) : </b>" + Rpt_Invoice_Details_list[inv].FOB_AMOUNT_FC + "</td></tr>");
                    }

                    //sb.Append("<tr><td colspan='10'><br/></td></tr>");
                    sb.Append("<tr10br@123>");
                    sb.Append("<tr><td2@CS></td><tdFWB@123>Rate</td><tdFWB@123>Currency</td><td6FWB@123>Amt</td></tr>");
                    sb.Append("<tr><td2FWB@123>Insurance</td><td>" + Rpt_Invoice_Details_list[inv].INSURANCE_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].INSURANCE_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].INSURANCE_CHARGES + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Freight</td><td>" + Rpt_Invoice_Details_list[inv].FREIGHT_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].FREIGHT_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].FREIGHT_CHARGES + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Commission</td><td>" + Rpt_Invoice_Details_list[inv].COMMISSION_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].COMMISSION_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].COMMISSION_CHARGES + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Discount</td><td>" + Rpt_Invoice_Details_list[inv].FOB_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].FOB_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].FOB_CHARGES + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Other Ded</td><td>" + Rpt_Invoice_Details_list[inv].OTHER_DEDUCTION_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].OTHER_DEDUCTION_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].OTHER_DEDUCTION_CHARGES + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Package Charges</td><td>" + Rpt_Invoice_Details_list[inv].PACKMISC_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].PACKMISC_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].PACKMISC_CHARGES + "</td></tr>");
                    sb.Append("<tr10br@123>");
                    if (Rpt_Invoice_Details_list[inv].THIRDPARTY_NAME.ToString() != "")
                        sb.Append("<tr><td2FWB@123>Third Party Name</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].THIRDPARTY_NAME + "</td> </tr>");
                    if (Rpt_Invoice_Details_list[inv].THIRDPARTY_ADD1.ToString() != "")
                        sb.Append("<tr><td2FWB@123>Third Party Add1</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].THIRDPARTY_ADD1 + "</td> </tr>");
                    if (Rpt_Invoice_Details_list[inv].THIRDPARTY_ADD2.ToString() != "")
                        sb.Append("<tr><td2FWB@123>Third Party Add2</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].THIRDPARTY_ADD2 + "</td></tr>");
                    if (Rpt_Invoice_Details_list[inv].THIRDPARTY_CITY.ToString() != "")
                        sb.Append("<tr><td2FWB@123>City & Sub Division</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].THIRDPARTY_CITY + " " + Rpt_Invoice_Details_list[inv].T_PARTY_COUNTRY_SUB_DIV + "</td></tr>");
                    if (Rpt_Invoice_Details_list[inv].T_PARTY_COUNTRY_SUB_DIV.ToString() != "")
                        sb.Append("<tr><td2FWB@123>Country Code </td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].T_PARTY_COUNTRY_CODE + "</td><td2FWB@123>Pin Code </td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].T_PARTY_PIN + "</td></tr>");
                    if (Rpt_Invoice_Details_list[inv].AUTHORIZED_ECONOMIC_OPERATOR_CODE.ToString() != "")
                        sb.Append("<tr><td2FWB@123>AEO Operator Code</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].AUTHORIZED_ECONOMIC_OPERATOR_CODE + "</td><td2FWB@123>AEO Country</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].A_E_O_COUNTRY + "</td></tr>");
                    if (Rpt_Invoice_Details_list[inv].AUTHORIZED_ECONOMIC_OPERATOR.ToString() != "")
                        sb.Append("<tr><td2FWB@123>Terms Place </td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].TERMS_PLACE + "</td><td2FWB@123>AEO Role</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].AUTHORIZED_ECONOMIC_OPERATOR + "</td></tr>");

                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>Item-HeadStarts@Rowno");
                    sb.Append("<tr style='text-align:center'><td10FWB@123>ITEMS OF EXPORT</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    sb.Append("<trFWB@123><td>SLNo</td> <td>RITC</td><td8@CS>Description</td></tr>");
                    sb.Append("<trFWB@123><td>Quantity</td> <td>Units</td> <td colspan='2'>Item &nbsp; &nbsp;&nbsp;&nbsp;       Rate Per</td><td>Unit</td><td colspan='2'>Value (FC)</td><td>FOB (INR)</td><td>Sch Cd</td><td>Reward[Y/N]</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>Scheme Description</td> <td2@CS>End Use</td> <td>PMV</td> <td2@CS>Total PMV</td><td>IGST Pyt.Sts</td><td>IGST Val</td><td>IGST Amt</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    Load_Item_DetailsInd.Clear();

                    Load_Item_DetailsInd = Rpt_Item_Details_new_list.Where(p => p.INVOICE_SLNO == Rpt_Invoice_Details_list[inv].INVOICE_SLNO).ToList();

                    if (Load_Item_DetailsInd.Count > 0)
                    {
                        //  ************  start of Individual Item details  *****************//

                        for (int itm = 0; itm < Load_Item_DetailsInd.Count; itm++)
                        {
                            //if (itm > 0)
                            //{
                            //    rwno = rwno + 1;
                            //    sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "*@ItemFirstLineBreak#<tr><td colspan='10'><br/></td> </tr> Item-contentStarts@Rowno-FirstLnBreak");
                            //}
                            rwno = rwno + 1;
                            sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "*@ItemFirstLine#<tr><td>" + Load_Item_DetailsInd[itm].ITEM_SLNO + "</td><td>" + Load_Item_DetailsInd[itm].RITCNO + "</td><td8@CS>" + Load_Item_DetailsInd[itm].ITEM_DESCRIPTION.Replace("<", "&lt;").Replace(">", "&gt;") + "</td></tr>Item-contentStarts@Rowno-FirstLn");

                            rwno = rwno + 1;
                            sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "*@ItemSecondLine#<tr><td>" + Load_Item_DetailsInd[itm].ITEM_QTY + "</td><td>" + Load_Item_DetailsInd[itm].ITEM_QTY_CODE + "</td><td colspan='2'>" + Load_Item_DetailsInd[itm].ITEM_UNIT_PRICE + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Load_Item_DetailsInd[itm].ITEM_PER + "</td> ");
                            sb.Append("<td>" + Load_Item_DetailsInd[itm].ITEM_QTY_CODE + "</td> <td colspan='2'>" + Load_Item_DetailsInd[itm].ITEM_AMOUNT + "</td> ");
                            sb.Append("<td>" + Load_Item_DetailsInd[itm].FOB_VALUE + "</td><td>" + Load_Item_DetailsInd[itm].ITEM_SCHEME_CODE + "</td><td>" + Load_Item_DetailsInd[itm].REWARD_POINTS + "</td></tr> Item-contentStarts@Rowno-SecondLn ");

                            rwno = rwno + 1;
                            sb.Append("*@Item#" + Load_Item_DetailsInd[itm].ITEM_SLNO + "*@Line#" + rwno + "*@ItemThirdLine#<tr><td2@CS>" + Load_Item_DetailsInd[itm].ITEM_SCHEME_DESC + "</td><td2@CS>" + Load_Item_DetailsInd[itm].ENDUSE_ITEM + "</td><td>" + Load_Item_DetailsInd[itm].ITEM_PMVVALUE + "</td> ");
                            sb.Append("<td2@CS>" + String.Format("{0:0.00}", Math.Round(Load_Item_DetailsInd[itm].TOTAL_PMVVALUE, 2)) + "</td><td>" + Load_Item_DetailsInd[itm].IGST_PAYMENT + "</td><td>" + Load_Item_DetailsInd[itm].TAXABLE_VALUE + "</td> ");


                            //sb.Append("<td2@CS>" + Load_Item_DetailsInd[itm].TOTAL_PMVVALUE + "</td><td>" + Load_Item_DetailsInd[itm].IGST_PAYMENT + "</td><td>" + Load_Item_DetailsInd[itm].TAXABLE_VALUE + "</td> ");
                            sb.Append("<td>" + Load_Item_DetailsInd[itm].IGST_AMT + "</td></tr> Item-contentStarts@Rowno-ThirdLn");
                        }

                        // FOB_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.FOB_VALUE)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.AGGREGATE_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.SAFE_GUARD_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.PRODUCT_OTHER_DUTY_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.CESS_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.CVD_CEC_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.CVD_CHEC_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.SCHED11_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.TOTAL_SOCIAL_WELFARE)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.ADDLTIONAL_DUTY_TOTAL));
                        FOB_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.FOB_VALUE));
                        Tax_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.TAXABLE_VALUE));
                        PMV_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.TOTAL_PMVVALUE));
                        IGST_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.IGST_AMT));

                        //=format(Round(val(Sum(Fields!TAXABLE_VALUE.Value)),1),"0.00") //=format(Round(val(Sum(Fields!TOTAL_PMVVALUE.Value)),1),"0.00") //=format(Round(val(Sum(Fields!IGST_AMT.Value)),1),"0.00")


                        //Grand_FOB_total = Grand_FOB_total + FOB_total;
                        //Grand_Tax_total = Grand_Tax_total + Tax_total;
                        //Grand_PMV_total = Grand_PMV_total + PMV_total;
                        //Grand_IGST_total = Grand_IGST_total + IGST_total;

                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        //sb.Append("<tr><td2@CS></td><td>Total FOB :</td><td3@CS>" + FOB_total + "</td><td>Total TaxVal :</td><td4@CS>" + PMV_total + "</td></tr> ");
                        //sb.Append("<tr><td3@CS>Total PMV :</td><td3@CS>" + PMV_total + "</td><td>Total IGSTAmt :</td><td4@CS>" + PMV_total + "</td></tr> ");

                        sb.Append("<tr><td colspan='6' style='text-align:right'>Total FOB : " + String.Format("{0:0.00}", Math.Round(FOB_total, 2)) + "</td><td></td><td3@CS>Total TaxVal : " + String.Format("{0:0.00}", Math.Round(Tax_total, 2)) + "</td></tr> ");
                        sb.Append("<tr><td colspan='6' style='text-align:right'>Total PMV : " + String.Format("{0:0.00}", Math.Round(PMV_total, 2)) + "</td><td></td><td3@CS>Total IGSTAmt : " + String.Format("{0:0.00}", Math.Round(IGST_total, 2)) + "</td></tr> ");

                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                        //  ************  end of Individual Item details  *****************//
                    }
                }
                //***************  End of invoice ************************ //


                //  ************  start of QUOTA details  *****************//  take direct drawback details fro DB & remover the list add
                if (ds.Tables[14].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>QUOTA DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Sl No</td><td colspan='2'>Agency Code</td> <td colspan='2'>Agency Name</td><td colspan='2'>Alloc. No</td><td>Expiry Date</td><td>Inv Sl No</td><td>Item Sl No</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[14].Rows.Count - 1; i++)
                    {
                        sb.Append("<tr><td>" + (i + 1).ToString() + "</td><td2@CS>" + ds.Tables[14].Rows[i]["AGENCY_CODE"] + "</td><td2@CS>" + ds.Tables[14].Rows[i]["AGENCY_NAME"] + "</td><td2@CS>" + ds.Tables[14].Rows[i]["ALLOCATION_NO"] + "</td><td>" + ds.Tables[14].Rows[i]["EXPIRY_DATE1"] + "</td><td>" + ds.Tables[14].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[14].Rows[i]["ITEM_SL_NO"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }
                //  ************  end of QUOTA details  *****************//

                //  ************  start of DRAWBACK details  *****************//
                /* hide by Chithra on 03-Jun-2019 for ROSCTL Implemetation
                if (Rpt_DrawBack_Details_list.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>DRAWBACK PAYABLE</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Invsl</td><td>Itemsl</td> <td>DBK SNo</td><td>Cus.Rate</td><td2@CS>DBK Adv</td><td>DBK Qty</td><td>Unit</td><td>Sta.Lev.Rate</td><td>TOT LEV</td></tr>");
                    sb.Append("<trFWB@123><td3@CS></td><td>Exc.Rate</td><td2@CS>DBK RateSpl</td><td2@CS>DBK.Amt(INR)</td><td>Sta.Lev.Amt</td><td>AMT</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < Rpt_DrawBack_Details_list.Count; i++)
                    {
                        sb.Append("<tr><td>" + Rpt_DrawBack_Details_list[i].INVOICE_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].ITEM_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_CUSTOMS + "</td>");
                        sb.Append("<td2@CS>" + Rpt_DrawBack_Details_list[i].DRAWBACK_RATE + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_QTY + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_UNIT + "</td><td2@CS>" + Rpt_DrawBack_Details_list[i].STATE_LEVEL_ADV_RATE + "</td></tr>");
                        sb.Append("<tr><td3@CS></td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_EXCISE + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_CAPS + "</td><td2SAR@123>" + Rpt_DrawBack_Details_list[i].DBK_VALUE + "</td><td></td><td>" + Rpt_DrawBack_Details_list[i].STATE_LEVEL_ADV_AMT + "</td><td>" + Rpt_DrawBack_Details_list[i].TOT_LEV_AMT + "</td></tr>");
                    }

                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    //sb.Append("<tr><td colspan='6' style='text-align:right'> " + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(item.DBK_VALUE)) + "</td><td></td><td3@CS>" + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(item.TOT_LEV_AMT)) + "</td></tr> ");
                    sb.Append("<tr><td7SAR@123> " + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.DBK_VALUE) ? "0" : item.DBK_VALUE)) + "</td><td></td> <td2SAR@123>" + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.TOT_LEV_AMT) ? "0" : item.TOT_LEV_AMT)) + "</td></tr> ");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                }
                 * */

                if (Rpt_DrawBack_Details_list.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>DRAWBACK PAYABLE</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Invsl</td><td>Itemsl</td> <td>DBK SNo</td><td2@CS>Cus.Rate</td><td2@CS>DBK Adv</td><td>DBK Qty</td><td2@CS>DBK.Amt(INR)</td></tr>");
                    sb.Append("<trFWB@123><td3@CS></td><td2@CS>Exc.Rate</td><td2@CS>DBK RateSpl</td><td3@CS>Unit</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < Rpt_DrawBack_Details_list.Count; i++)
                    {
                        sb.Append("<tr><td>" + Rpt_DrawBack_Details_list[i].INVOICE_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].ITEM_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_SLNO + "</td><td2@CS>" + Rpt_DrawBack_Details_list[i].DRAWBACK_CUSTOMS + "</td>");
                        sb.Append("<td2@CS>" + Rpt_DrawBack_Details_list[i].DRAWBACK_RATE + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_QTY + "</td><td2@CS>" + Rpt_DrawBack_Details_list[i].DBK_VALUE + "</td><td>" + "</td></tr> Drawback-contentStarts@Rowno");
                        sb.Append("<tr><td3@CS></td><td2@CS>" + Rpt_DrawBack_Details_list[i].DRAWBACK_EXCISE + "</td><td2@CS>" + Rpt_DrawBack_Details_list[i].DRAWBACK_CAPS + "</td><td3@CS>" + Rpt_DrawBack_Details_list[i].DRAWBACK_UNIT + "</td></tr> Drawback-contentStarts@Rowno-2ndLine");
                    }

                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<tr><td8@CS></td><td> " + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.DBK_VALUE) ? "0" : item.DBK_VALUE)) + "</td><td></td></tr> ");
                    //sb.Append("<tr><td7SAR@123> " + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.DBK_VALUE) ? "0" : item.DBK_VALUE))  + "</td></tr> ");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                }

                //  ************  start ROSCTL details  *****************//

                if (Rpt_DrawBack_Details_list.Count > 0)
                {
                    string ROSL = "YES";
                    for (int i = 0; i < Rpt_DrawBack_Details_list.Count; i++)
                    {
                        if (Rpt_DrawBack_Details_list[i].SCHEME_CODE.Substring(0, 2) == "60" || Rpt_DrawBack_Details_list[i].SCHEME_CODE.Substring(0, 2) == "61"
                            || Rpt_DrawBack_Details_list[i].SCHEME_CODE.Substring(0, 2) == "64" || Rpt_DrawBack_Details_list[i].SCHEME_CODE.Substring(0, 2) == "65")
                        {
                            if (ROSL == "YES")
                            {
                                sb.Append("<tr style='text-align:center'><td10FWB@123>ROSCTL PAYABLE</td></tr>");
                                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                                sb.Append("<trFWB@123><td>Invsl</td><td>Itemsl</td> <td>DBK SNo</td><td colspan='2'>State.Lev.Rate</td><td2@CS>Central.Lev.Rate</td><td>Qty</td><td  colspan='3'>ROSCTL Amt(INR)</td></tr>");
                                sb.Append("<trFWB@123><td3@CS></td><td colspan='2'>State.Lev.Amt</td><td2@CS>Central.Lev.Amt</td><td colspan='8'>Unit</td></tr>");
                                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                                ROSL = "";
                            }
                            sb.Append("<tr><td>" + Rpt_DrawBack_Details_list[i].INVOICE_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].ITEM_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_SLNO + "</td><td colspan='2'>" + Rpt_DrawBack_Details_list[i].STATE_LEVEL_ADV_RATE + "</td>");
                            sb.Append("<td2@CS>" + Rpt_DrawBack_Details_list[i].CENTRAL_LEVEL_ADV_RATE + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_QTY + "</td><td>" + Rpt_DrawBack_Details_list[i].TOT_LEV_AMT + "</td><td2@CS>" + "</td></tr>");
                            sb.Append("<tr><td3@CS></td><td colspan='2'>" + Rpt_DrawBack_Details_list[i].STATE_LEVEL_ADV_AMT + "</td><td  colspan='2'>" + Rpt_DrawBack_Details_list[i].CENTRAL_LEVEL_ADV_AMT + "</td><td colspan='8' style='text-align:left'>" + Rpt_DrawBack_Details_list[i].DRAWBACK_UNIT + "</td></tr>");

                            if (i == Rpt_DrawBack_Details_list.Count - 1)
                            {
                                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                                sb.Append("<tr><td colspan='8'></td><td colspan='1' style='text-align:left'> " + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.TOT_LEV_AMT) ? "0" : item.TOT_LEV_AMT)) + "</td><td colspan='3' ></td></tr> ");
                                //sb.Append("<tr><td7SAR@123> " + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.DBK_VALUE) ? "0" : item.DBK_VALUE))  + "</td></tr> ");
                                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            }
                        }
                    }
                }



                //  ************  start of ACCESSORY details  *****************//
                if (ds.Tables[2].Rows.Count > 0 && ds.Tables[23].Rows.Count > 0)
                {
                    if (ds.Tables[23].Rows[0]["CntAcc"].ToString() != "0")  // here we take the count from item table with filtering ITEM_ACCESSORIES_DESC is not empty
                    {
                        sb.Append("<tr style='text-align:center'><td10FWB@123>ACCESSORY CERTIFICATE DETAILS</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td> <td8@CS>Item Description</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            if (ds.Tables[2].Rows[i]["ITEM_ACCESSORIES_DESC"] != "")
                            {
                                sb.Append("<tr><td>" + ds.Tables[2].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[2].Rows[i]["ITEM_SLNO"] + "</td><td8@CS>" + ds.Tables[2].Rows[i]["ITEM_ACCESSORIES_DESC"] + "</td></tr>");
                            }

                        }
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    }
                }

                //  ************  start of LICENSE PARTICULARS  *****************//
                if (ds.Tables[22].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>LICENSE PARTICULARS</td></tr> License-contentStarts@Header");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv Sl</td><td>Item Sl</td> <td>Scheme</td><td2@CS>Regn No</td><td>Regn Date</td><td>SNo-E</td><td>Exp Qty</td><td>Unit</td><td>Imp / Ind</td></tr>");
                    sb.Append("<trFWB@123><td6@CS>Description</td><td>SNo-C</td> <td>Imp Qty</td><td colspan='2'>Unit</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[22].Rows.Count; i++)
                    {
                        //sb.Append("<tr><td>" + ds.Tables[22].Rows[i]["INV_SL_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["ITEM_SL_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["SCHEME_CODE"] + "</td><td2@CS>" + ds.Tables[22].Rows[i]["LICENSE_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["LICENSE_DATE"] + "</td> ");
                        sb.Append("<tr><td>" + ds.Tables[22].Rows[i]["INV_SL_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["ITEM_SL_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["SCHEME"] + "</td><td2@CS>" + ds.Tables[22].Rows[i]["LICENSE_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["LICENSE_DATE"] + "</td> ");
                        sb.Append("<td>" + ds.Tables[22].Rows[i]["LICENSE_E_SL_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["LICENSE_EXP_QTY"] + "</td>");
                        sb.Append("<td>" + ds.Tables[22].Rows[i]["LICENSE_EXP_UNIT"] + "</td><td>" + ds.Tables[22].Rows[i]["LICENSE_IMP_TYPENew"] + "</td></tr> License-contentStarts@Rowno");

                        if (Connection.Get_User_Exp_Settings_Job_Edit("CHKLIST_LICENSE_DESC") == "E")
                        {
                            sb.Append("<tr><td6@CS>" + ds.Tables[22].Rows[i]["LICENSE_IMP_DESC"] + "</td>");
                        }
                        else
                        {
                            sb.Append("<tr><td6@CS></td>");
                        }

                        sb.Append("<td>" + ds.Tables[22].Rows[i]["LICENSE_IMP_ITEM_SL_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["LICENSE_IMP_QTY"] + "</td><td2@CS>" + ds.Tables[22].Rows[i]["LICENSE_IMP_UNIT"] + "</td></tr> License-contentStarts@Rowno-2ndLine");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of JOB WORK DETAILS  *****************//
                if (ds.Tables[6].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>JOB WORK DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv Sl No</td><td>Item Sl No</td> <td>BE No</td><td>BE Date</td><td>BE Inv Slno</td><td>BE Inv No</td><td>BE ItemNo</td><td>BE Port</td><td>BE Qty</td><td>Unit</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[6].Rows.Count; i++)
                    {
                        sb.Append("<tr><td>" + ds.Tables[6].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[6].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[6].Rows[i]["BE_NO"] + "</td><td>" + ds.Tables[6].Rows[i]["BE_DATE"] + "</td>");
                        sb.Append("<td>" + ds.Tables[6].Rows[i]["BE_INV_SLNO"] + "</td><td>" + ds.Tables[6].Rows[i]["BE_INV_NO"] + "</td><td>" + ds.Tables[6].Rows[i]["BE_ITEM_NO"] + "</td>");
                        sb.Append("<td>" + ds.Tables[6].Rows[i]["BE_PORT_CODE"] + "</td><td>" + ds.Tables[6].Rows[i]["QTY"] + "</td><td>" + ds.Tables[6].Rows[i]["UNIT"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }
                //  ************  End of JOB WORK DETAILS  *****************//


                //  ************  start of Cess WORK DETAILS  *****************//
                if (ds.Tables[13].Rows.Count > 0)
                {
                    FOB_VALUE = Math.Round(SUM_TOTAL_FOB_VALUE, 2);
                    double grand_cessTotal = 0.00;
                    double cess_amountNew = 0.00;
                    sb.Append("<tr style='text-align:center'><td10FWB@123>CESS PAYABLE</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv No</td><td>Item No</td> <td2@CS>Cess Sl No</td><td2@CS>Tariff Val</td><td>Cess Rate</td><td>Cess Qty</td><td2@CS>Cess Amt(INR)</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[13].Rows.Count; i++)
                    {

                        if ((ds.Tables[13].Rows[i]["CESS_TARIFF_VALUE"] == "") && (ds.Tables[13].Rows[i]["CESS_RATE"] != ""))
                        {
                            //string cess_amount = Convert.ToString(Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(CESS_RATE) / 100);
                            //cess_amount = Convert.ToString(Math.Round(Convert.ToDouble(cess_amount), 2).ToString("0.00"));
                            //CESS_AMT = Convert.ToDouble(cess_amount);

                            cess_amountNew = (Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(ds.Tables[13].Rows[i]["CESS_RATE"]) / 100);

                        }
                        else
                        {
                            if (ds.Tables[13].Rows[i]["CESS_TARIFF_VALUE"] != "")
                            {
                                //string cess_amount = Convert.ToString(Convert.ToDouble(CESS_TARIFF_VALUE) * Convert.ToDouble(CESS_RATE) / 100);
                                //cess_amount = Convert.ToString(Convert.ToDouble(cess_amount) * Convert.ToDouble(CESS_ITEM_QTY));
                                //cess_amount = Convert.ToString(Math.Round(Convert.ToDouble(cess_amount), 2).ToString("0.00"));
                                //CESS_AMT = Convert.ToDouble(cess_amount);

                                cess_amountNew = Convert.ToDouble(ds.Tables[13].Rows[i]["CESS_ITEM_QTY"]) * (Convert.ToDouble(ds.Tables[13].Rows[i]["CESS_TARIFF_VALUE"]) * Convert.ToDouble(ds.Tables[13].Rows[i]["CESS_RATE"])) / 100;
                            }
                        }
                        grand_cessTotal = grand_cessTotal + cess_amountNew;

                        sb.Append("<tr><td>" + ds.Tables[13].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[13].Rows[i]["ITEM_SLNO"] + "</td><td2@CS>" + ds.Tables[13].Rows[i]["CESS_SLNO"] + "</td> ");
                        sb.Append("<td2@CS>" + ds.Tables[13].Rows[i]["CESS_TARIFF_VALUE"] + "</td><td>" + ds.Tables[13].Rows[i]["CESS_RATE"] + "</td><td>" + ds.Tables[13].Rows[i]["CESS_ITEM_QTY"] + "</td>");
                        sb.Append("<td2@CS>" + cess_amountNew + "</td></tr>");

                        cess_amountNew = 0.00;
                    }
                    sb.Append("<tr><td colspan='8'>Total Cess </td><td2@CS> " + grand_cessTotal + " </td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of THIRD PARTY DETAILS *****************//
                if (ds.Tables[2].Rows.Count > 0)
                {
                    if (ds.Tables[23].Rows[0]["CntIECode"].ToString() != "0")  // here we take the count from item table with filtering ITEM_IECCODE is not empty
                    {
                        sb.Append("<tr style='text-align:center'><td10FWB@123>THIRD PARTY DETAILS</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        sb.Append("<trFWB@123><td>Inv SlNo</td><td2@CS>Item No</td> <td3@CS>IEC</td><td4@CS>Exp Name</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            sb.Append("<tr><td>" + ds.Tables[2].Rows[i]["INVOICE_SLNO"] + "</td><td2@CS>" + ds.Tables[2].Rows[i]["ITEM_SLNO"] + "</td><td3@CS>" + ds.Tables[2].Rows[i]["ITEM_IECCODE"] + "</td><td4@CS>" + ds.Tables[2].Rows[i]["ITEM_EXPORTER_NAME"] + "</td></tr>");
                            if (ds.Tables[2].Rows[i]["ADDRESS1"] != "")
                                sb.Append("<tr><td2@CS><b>Address</b></td><td8@CS><b>:</b> " + ds.Tables[2].Rows[i]["ADDRESS1"] + " " + ds.Tables[2].Rows[i]["ADDRESS2"] + " " + ds.Tables[2].Rows[i]["ADDRESS3"] + " </td></tr>");
                            if (ds.Tables[2].Rows[i]["ADDRESS4"] != "")
                                sb.Append("<tr><td2@CS><b>City</b></td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["ADDRESS4"] + "</td><td><b>Pincode</b></td><td4@CS><b>:</b> " + ds.Tables[2].Rows[i]["ADDRESS5"] + "</td></tr>");
                            if (ds.Tables[2].Rows[i]["GSTN_TYPE"] != "")
                                sb.Append("<tr><td2@CS><b>GSTN Type</b></td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["GSTN_TYPE"] + "</td><td><b>GSTN ID</b></td><td4@CS><b>:</b> " + ds.Tables[2].Rows[i]["GSTN_ID"] + "</td></tr>");
                        }

                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    }
                }

                //  ************  start of AR4 DETAILS  *****************// ds.Tables[9]
                if (ds.Tables[9].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>AR4 DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv No</td><td>Item</td> <td>AR4 No</td><td>AR4 Date</td><td>Commission</td><td>Division</td><td>Range</td><td3@CS>Remarks</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[9].Rows.Count; i++)
                    {
                        sb.Append("<tr><td>" + ds.Tables[9].Rows[i]["AR4_INVOICE_SLNO"] + "</td><td>" + ds.Tables[9].Rows[i]["AR4_ITEM_NO"] + "</td><td>" + ds.Tables[9].Rows[i]["AR4_NO"] + "</td><td>" + ds.Tables[9].Rows[i]["AR4_DATE"] + "</td> ");
                        sb.Append("<td>" + ds.Tables[9].Rows[i]["AR4_COMMISSION_RATE"] + "</td><td>" + ds.Tables[9].Rows[i]["AR4_DIVISION"] + "</td><td>" + ds.Tables[9].Rows[i]["AR4_RANGE"] + "</td><td3@CS>" + ds.Tables[9].Rows[i]["AR4_REMARKS"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of EOU DETAILS  *****************// ds.Tables[7]
                if (ds.Tables[7].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>EOU Details</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    string ANNEX_ADDRESS4, ANNEX_ADDRESS5;
                    string[] s1;


                    for (int i = 0; i < ds.Tables[7].Rows.Count; i++)
                    {
                        ANNEX_ADDRESS4 = ds.Tables[7].Rows[0]["ANNEX_ADDRESS4"].ToString();
                        s1 = ANNEX_ADDRESS4.Split(new string[] { "--" }, StringSplitOptions.None);
                        ANNEX_ADDRESS4 = s1[0].ToString();
                        if (ds.Tables[7].Rows[0]["ANNEX_ADDRESS4"].ToString().Contains("--"))
                        {
                            ANNEX_ADDRESS5 = s1[1].ToString();
                        }
                        else
                        {
                            ANNEX_ADDRESS5 = "";
                        }


                        sb.Append("<tr><td2FWB@123>IEC of EOU </td><td3@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_IECCODE"] + "</td><td2FWB@123>Br Sl.No </td><td3@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_BR_SLNO"] + "</td></tr>");
                        sb.Append("<tr><td2FWB@123>Name of EOU</td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_EXPORTERNAME"] + "</td></tr>");
                        sb.Append("<tr><td2FWB@123>Address of EOU </td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_ADDRESS1"] + "</td></tr>");
                        sb.Append("<tr><td2FWB@123></td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_ADDRESS2"] + "</td></tr>");
                        sb.Append("<tr><td2FWB@123>City</td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_ADDRESS3"] + "</td></tr>");
                        //sb.Append("<tr><td2FWB@123>State</td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_ADDRESS4New"].ToString().Replace("--","")  + "</td></tr>");
                        //sb.Append("<tr><td2FWB@123>PIN</td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_ADDRESS5New"] + "</td></tr>");

                        sb.Append("<tr><td2FWB@123>State</td><td8@CS><b>:</b> " + ANNEX_ADDRESS4 + "</td></tr>");
                        sb.Append("<tr><td2FWB@123>PIN</td><td8@CS><b>:</b> " + ANNEX_ADDRESS5 + "</td></tr>");

                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of ITEM - SW MANUFACTURER DETAILS  *****************//
                if (ds.Tables[2].Rows.Count > 0)  // need to check here ACCESSORY_STATUS <>""
                {
                    if (ds.Tables[23].Rows[0]["CntAccStatus"].ToString() != "0")  // here we take the count from item table with filtering ITEM_IECCODE is not empty
                    {
                        sb.Append("<tr style='text-align:center'><td10FWB@123>ITEM - SW MANUFACTURER DETAILS</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            if (ds.Tables[2].Rows[i]["M_P_GROWER_CODE"].ToString() != "" || ds.Tables[2].Rows[i]["M_P_GROWER_ADD1"].ToString() != "")
                            {
                                sb.Append("<tr><td2FWB@123>Invoice  SlNo</td><td>:" + ds.Tables[2].Rows[i]["INVOICE_SLNO"] + "</td><tdFWB@123>Item SlNo</td><td>:" + ds.Tables[2].Rows[i]["ITEM_SLNO"] + "</td><td2FWB@123>Manufacture Code Type</td><td3@CS>:" + ds.Tables[2].Rows[i]["MANUFACTURER_PRODUCER"] + "</td></tr>");
                                if (ds.Tables[2].Rows[i]["M_P_GROWER_CODE"].ToString() != "")
                                    sb.Append("<tr><td2FWB@123>Grower Code </td><td8@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_CODE"] + "</td></tr>");
                                if (ds.Tables[2].Rows[i]["M_P_GROWER_ADD1"].ToString() != "")
                                    sb.Append("<tr><td2FWB@123>Address 1</td><td8@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_ADD1"] + "</td></tr>");
                                sb.Append("<tr><td2FWB@123>Address 2</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_ADD2"] + "</td><td2FWB@123>City</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_CITY"] + "</td></tr>");
                                sb.Append("<tr><td2FWB@123>Sub Division</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_COUNTRY_SUBDIV"] + "</td><td2FWB@123>Pin Code</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_PIN"] + "</td></tr>");
                                sb.Append("<tr><td2FWB@123>Mnfctr Country</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_COUNTRY"] + "</td><td2FWB@123>Source State </td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["SOURCE_STATE"] + "</td></tr>");
                                sb.Append("<tr><td2FWB@123>Transit Country</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["TRANSIT_COUNTRY"] + "</td><td2FWB@123>Accessory Status</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["ACCESSORY_STATUS"] + "</td></tr>");
                                sb.Append("<tr><td2FWB@123>HAWB No</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["HAWB_NO"] + "</td><td2FWB@123>Total Packages</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["TOTAL_PKGS"] + "</td></tr>");
                            }

                        }
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    }
                }

                //  ************  start of CONTAINER DETAILS   *****************// ds.Tables[10]
                if (ds.Tables[10].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>CONTAINER DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>Container No</td><td2@CS>Size</td><td2@CS>Type</td><td2@CS>Seal No</td><td>Seal Date</td><td>TYPE INDICATOR</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[10].Rows.Count; i++)
                    {
                        sb.Append("<tr><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_CONTAINERNO"] + "</td><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_SIZE"] + "</td><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_TYPE"] + "</td><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_EXCISE_SEALNO"] + "</td>");
                        sb.Append("<td>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_SEAL_DATE"] + "</td><td>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of VESSEL DETAILS   *****************//
                if (ds.Tables[11].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>VESSEL DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    sb.Append("<trFWB@123><td2@CS>Factory Stuffed</td><td2@CS>Sample Acc.</td><td2@CS>Vessel Name & Date</td><td2@CS>Voyage No</td><td2@CS>Factory Address</td</tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[10].Rows.Count; i++)
                    {
                        sb.Append("<tr><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_CONTAINERNO"] + "</td><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_SIZE"] + "</td><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_TYPE"] + "</td><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_EXCISE_SEALNO"] + "</td>");
                        sb.Append("<td>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_SEAL_DATE"] + "</td><td>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"] + "</td></tr>");
                    }

                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of PACKING  DETAILS   *****************// ds.Tables[12]
                if (ds.Tables[12].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>PACKING DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>Package From</td><td2@CS>Package To</td> <td2@CS>Package Kind</td><td2@CS>From Desc</td><td2@CS>To Desc</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[12].Rows.Count; i++)
                    {
                        sb.Append("<tr><td2@CS>" + ds.Tables[12].Rows[i]["ANNEX_SEA_PACK_FROM"] + "</td><td2@CS>" + ds.Tables[12].Rows[i]["ANNEX_SEA_PACK_TO"] + "</td><td2@CS>" + ds.Tables[12].Rows[i]["ANNEX_SEA_PACK_PACKAGETYPE"] + "</td>");
                        sb.Append("<td2@CS>" + ds.Tables[12].Rows[i]["ANNEX_SEA_PACK_FROMDESC"] + "</td><td2@CS>" + ds.Tables[12].Rows[i]["ANNEX_SEA_PACK_TODESC"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of STR   DETAILS   *****************//

                if (Rpt_STR_Details_list.Count > 0)
                {
                    if (Rpt_STR_Details_list.Sum(item => Convert.ToDouble(item.STR_AMOUNT)) > 0)
                    {
                        if (ds.Tables[23].Rows[0]["CntStrCode"].ToString() != "0")  // here we take the count from item table with filtering ITEM_STR_CODE is not empty
                        {
                            sb.Append("<tr style='text-align:center'><td10FWB@123>STR DETAILS</td></tr>");
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            sb.Append("<trFWB@123><td>Inv Sl No</td><td2@CS>Item Sl No</td><td2@CS>STR SRNo</td><td2@CS>STR Rate</td><td3@CS>STR Amount</td></tr>");
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            for (int i = 0; i < Rpt_STR_Details_list.Count; i++)
                            {
                                sb.Append("<tr><td>" + Rpt_STR_Details_list[i].INVOICE_SLNO + "</td><td2@CS>" + Rpt_STR_Details_list[i].ITEM_SLNO + "</td><td2@CS>" + Rpt_STR_Details_list[i].ITEM_STR_CODE + "</td><td2@CS>" + Rpt_STR_Details_list[i].STR_RATE + "</td><td3@CS>" + Rpt_STR_Details_list[i].STR_AMOUNT + "</td></tr>");
                            }
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            sb.Append("<tr><td7@CS>TOTAL SERVICE TAX REFUND AMOUNT = </td><td3@CS>" + Rpt_STR_Details_list.Sum(item => Convert.ToDouble(item.STR_AMOUNT)) + "</td></tr>");
                        }
                    }
                }

                //  ************  start of RE-EXPORT   DETAILS   *****************//  ds.Tables[12]
                if (ds.Tables[21].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>RE-EXPORT DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>InvSlNo</td><td>ItemSlNo</td> <td>BE Site</td><td2@CS>BE No &  BE Date</td><td>BE InvNo</td><td>BE Item</td><td>ManualBE</td><td2@CS>Qty utilised</td></tr>");
                    sb.Append("<trFWB@123><td>BE Qty</td><td>BE UQC</td> <td8@CS>BE Desc</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>BE Assbl Val</td><td2@CS>BE Duty Paid</td> <td2@CS>Paymt Date</td><td2@CS>BE Other Identifiable</td><td2@CS>BE Assbl Value Claim</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>BE Item Used</td><td2@CS>CommisnerPerm</td><td2@CS>InputCredit</td><td>Personal used</td><td>Modvat availed</td><td2@CS>ModvatRepaid</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[21].Rows.Count; i++)
                    {
                        sb.Append("<tr><td>" + ds.Tables[21].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[21].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[21].Rows[i]["BE_SITE"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_NO"] + " & " + ds.Tables[21].Rows[i]["BE_DATE"] + "</td> ");
                        sb.Append("<td>" + ds.Tables[21].Rows[i]["BE_INVOICE_NO"] + "</td><td>" + ds.Tables[21].Rows[i]["BE_INVOICE_ITEM_NO"] + "</td><td>" + ds.Tables[21].Rows[i]["MANUAL_BE_Y_N"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_QTY_UTILISED"] + "</td></tr>");
                        sb.Append("<tr><td>" + ds.Tables[21].Rows[i]["BE_QTY"] + "</td><td>" + ds.Tables[21].Rows[i]["BE_UQC"] + "</td><td8@CS>" + ds.Tables[21].Rows[i]["BE_ITEM_DESC"] + "</td></tr>");
                        sb.Append("<tr><td2@CS>" + ds.Tables[21].Rows[i]["BE_ASS_VALUE"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_DUTY_PAID"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_DUTY_PAYMENT_DATE"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_OTH_IDENTIFIABLE_PARAMETER"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_ASS_VALUE_CLAIM"] + "</td></tr>");
                        sb.Append("<tr><td2@CS>" + ds.Tables[21].Rows[i]["BE_ITEM_USED_Y_N"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["COMMISIONER_PERMISSION_Y_N"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["INPUT_CREDIT_Y_N"] + "</td><td>" + ds.Tables[21].Rows[i]["PERSONAL_USED_Y_N"] + "</td><td>" + ds.Tables[21].Rows[i]["MODVAT_AVAILED_Y_N"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["MODVAT_REPAID_Y_N"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of SINGLE WINDOW - INFO DETAILS   *****************// ds.Tables[15]

                if (ds.Tables[15].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - INFO DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td> <td2@CS>Info Type</td><td2@CS>Info Qualifier</td><td>Info Code</td><td>Info Text</td><td>MSR</td><td>UQC</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[15].Rows.Count; i++)
                    {
                        sb.Append("<tr><td>" + ds.Tables[15].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[15].Rows[i]["ITEM_SLNO"] + "</td><td2@CS>" + ds.Tables[15].Rows[i]["INFO_TYPE"] + "</td><td2@CS>" + ds.Tables[15].Rows[i]["INFO_QUALIFIER"] + "</td>");
                        sb.Append("<td>" + ds.Tables[15].Rows[i]["INFO_CODE"] + "</td><td>" + ds.Tables[15].Rows[i]["INFO_TEXT"] + "</td><td>" + ds.Tables[15].Rows[i]["INFO_MSR"] + "</td><td>" + ds.Tables[15].Rows[i]["INFO_UQC"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of SINGLE WINDOW - CONSTITUENT DETAILS  ******************// ds.Tables[16]
                if (ds.Tables[16].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - CONSTITUENT DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td><td2@CS>Cons.SrNo</td><td3@CS>Cons.Element Name</td><td>Percentage</td><td>Yield%</td><td>Active(Y/N)</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[16].Rows.Count; i++)
                    {
                        if (ds.Tables[16].Rows[i]["CONSTITUENT_SRNO"].ToString() != "")
                        {
                            sb.Append("<tr><td>" + ds.Tables[16].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[16].Rows[i]["ITEM_SLNO"] + "</td><td2@CS>" + ds.Tables[16].Rows[i]["CONSTITUENT_SRNO"] + "</td> ");
                            sb.Append("<td3@CS>" + ds.Tables[16].Rows[i]["CONSTITUENT_ELEMENT_NAME"] + "</td><td>" + ds.Tables[16].Rows[i]["CONSTITUENT_PERCENTAGE"] + "</td>");
                            sb.Append("<td>" + ds.Tables[16].Rows[i]["CONSTITUENT_YIELD_PERCENTAGE"] + "</td><td>" + ds.Tables[16].Rows[i]["ACTIVE_INGREDIENT"] + "</td></tr>");
                        }
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of SINGLE WINDOW - PRODUCTION  DETAILS   *****************// ds.Tables[17] 
                if (ds.Tables[17].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - PRODUCTION  DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td><td2@CS>Batch Identifier</td><td2@CS>Batch Qty</td><td>Manufacture Dt</td><td>Expiry Dt</td><td2@CS>BestBefore Dt</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[17].Rows.Count; i++)
                    {
                        if (ds.Tables[17].Rows[i]["PRODUCTION_BATCH_IDENTIFIER"].ToString() != "")
                        {
                            sb.Append("<tr><td>" + ds.Tables[17].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[17].Rows[i]["ITEM_SLNO"] + "</td><td2@CS>" + ds.Tables[17].Rows[i]["PRODUCTION_BATCH_IDENTIFIER"] + "</td> ");
                            sb.Append("<td2@CS>" + ds.Tables[17].Rows[i]["PRODUCTION_BATCH_QUANTITY"] + " " + ds.Tables[17].Rows[i]["UNIT_QTY_CODE"] + " </td><td>" + ds.Tables[17].Rows[i]["DATE_OF_MANUFACTURING"] + "</td>");
                            sb.Append("<td>" + ds.Tables[17].Rows[i]["DATE_OF_EXPIRY"] + "</td><td>" + ds.Tables[17].Rows[i]["BEST_BEFORE"] + "</td></tr>");
                        }
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of SINGLE WINDOW - CONTROL DETAILS *****************// // ds.Tables[18] 
                if (ds.Tables[18].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - CONTROL DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td> <td>Control Type Code</td><td>Batch Qty</td><td2@CS>Manufacture Dt</td><td2@CS>Expiry Dt</td><td2@CS>Best Before Dt</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[18].Rows.Count; i++)
                    {
                        if (ds.Tables[18].Rows[i]["CONTROL_TYPE_CODE"].ToString() != "")
                        {
                            sb.Append("<tr><td>0</td><td>0</td><td2@CS>" + ds.Tables[18].Rows[i]["CONTROL_TYPE_CODE"] + "</td> ");
                            sb.Append("<td2@CS>" + ds.Tables[18].Rows[i]["CONTROL_LOCATION"] + "</td><td> " + ds.Tables[18].Rows[i]["CONTROL_START_DATE"] + " </td><td>" + ds.Tables[18].Rows[i]["CONTROL_END_DATE"] + "</td>");
                            sb.Append("<td2@CS>" + ds.Tables[18].Rows[i]["CONTROL_RESULT_CODE"] + "</td></tr>");
                        }
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of DECLARATIONS DETAILS *****************// // ds.Tables[19] 
                if (ds.Tables[19].Rows.Count > 0)
                {
                    string decflag = "";
                    if (Request.QueryString["chk_Stmt"] == "" || Request.QueryString["chk_Stmt"] == null)
                    {
                    }
                    else
                    {
                        decflag = Request.QueryString["chk_Stmt"].ToString();
                    }

                    sb.Append("<tr style='text-align:center'><td10FWB@123>DECLARATIONS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td><td>Stmt Type</td><td>Stmt Code</td><td6@CS>Stmt Text</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    for (int i = 0; i < ds.Tables[19].Rows.Count; i++)
                    {
                        if (ds.Tables[19].Rows[i]["STMT_TYPE"].ToString() != "")
                        {
                            if (decflag == "False")
                                sb.Append("<tr><td>" + ds.Tables[19].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_TYPE"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_CODE"] + "</td><td6@CS></td></tr>");
                            else
                                sb.Append("<tr><td>" + ds.Tables[19].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_TYPE"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_CODE"] + "</td><td6@CS>" + ds.Tables[19].Rows[i]["STMT_TEXT"] + "</td></tr>");
                        }
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  Start of SINGLE WINDOW - SUPPORTING DOCUMENTS DETAILS  *****************// ds.Tables[20]

                if (ds.Tables[20].Rows.Count > 0)
                {
                    sb.Append("<tr10br@123>");
                    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - SUPPORTING DOCUMENTS DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>InvSlNo</td><td>ItemSlNo</td><td4@CS>Place of Issue</td><td colspan='4'>File Type</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>Unique Doc Number</td><td colspan='2'>Doc type Code</td><td colspan='2'>Doc reference number</td><td colspan='2'>Doc IssueDate</td><td colspan='2'>Doc Expiry Date</td></tr>");
                    sb.Append("<trFWB@123><td  colspan='4'>Document Issuing Party Code</td><td colspan='2'>Icegate ID</td><td colspan='4'>Document Beneficiary Party Code</td></tr>");
                    //  sb.Append("<trFWB@123><td6@CS>Document Issuing Party Code</td><td4@CS>Document Beneficiary Party Code</td> </tr>");
                    sb.Append("<trFWB@123><td colspan='6'>Document Issuing Party Name</td><td colspan='4'>Document Beneficiary Party Name</td> </tr>");
                    sb.Append("<trFWB@123><td6@CS>Document Issuing Party Name Address1</td><td4@CS>Document Beneficiary Party Name Address1</td> </tr>");
                    sb.Append("<trFWB@123><td6@CS>Document Issuing Party Name Address2</td><td4@CS>Document Beneficiary Party Name Address2</td> </tr>");
                    sb.Append("<trFWB@123><td6@CS>Document Issuing Party City</td><td4@CS>Document Beneficiary Party City</td> </tr>");
                    sb.Append("<trFWB@123><td6@CS>Document Issuing Party PIN</td><td4@CS>Document Beneficiary Party PIN</td> </tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int rsp = 0; rsp < ds.Tables[20].Rows.Count; rsp++)
                    {
                        sb.Append("<tr><td>" + ds.Tables[20].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[20].Rows[rsp]["ITEM_SLNO"] + "</td> <td4@CS>" + ds.Tables[20].Rows[rsp]["PLACE_OF_ISSUE"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["FILE_TYPE"] + "</td></tr>");
                        sb.Append("<tr><td2@CS>" + ds.Tables[20].Rows[rsp]["UNIQUE_DOC_NUMBER"] + "</td><td2@CS>" + ds.Tables[20].Rows[rsp]["DOC_TYPE_CODE"] + "</td> <td2@CS>" + ds.Tables[20].Rows[rsp]["DOC_REF_NUMBER"] + "</td><td2@CS>" + ds.Tables[20].Rows[rsp]["DOC_ISSUE_DATE"] + "</td><td2@CS>" + ds.Tables[20].Rows[rsp]["DOC_EXPIRY_DATE"] + "</td></tr>");
                        sb.Append("<tr><td6@CS>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_CODE"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_CODE"] + "</td></tr>");
                        sb.Append("<tr><td6@CS>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_NAME"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_NAME"] + "</td></tr>");
                        sb.Append("<tr><td6@CS>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_NAME_ADD1"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_ADDRESS1"] + "</td></tr>");
                        sb.Append("<tr><td6@CS>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_NAME_ADD2"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_ADDRESS2"] + "</td></tr>");
                        sb.Append("<tr><td6@CS>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_CITY"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_CITY"] + "</td></tr>");
                        sb.Append("<tr><td6@CS>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_PIN"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_PIN"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  End of SINGLE WINDOW - SUPPORTING DOCUMENTS DETAILS  *****************//

                sb.Append("<tr><td10@CS><br/></td></tr>");
                //sb.Append("<tr><td colspan='10' style='text-align:left'>Declaration</td></tr>");
                sb.Append("<tr><td10@CS>I/We declare that the particulars given herein are true and are correct.</td></tr>");
                sb.Append("<tr><td10@CS>I/We undertake to abide by provisions of Foreign Exchange Management Act,1999, as amended from time to time</td></tr>");
                sb.Append("<tr><td10@CS>including realisation / repatriation of foreign exchange to / from India.</td></tr>");
                sb.Append("<tr><td10@CS>" + DECLARATION + "</td></tr>");
                sb.Append("<tr><td10@CS><br/></td></tr>");


                sb.Append("<tr><td6@CS>" + cha + "</td><td4@CS>" + Exporter + " </td></tr>");
                if (COMPANY_ID == "517" || COMPANY_ID == "480" || COMPANY_ID == "508" || COMPANY_ID == "3388")
                {
                    sb.Append("<tr><td6@CS>" + cha_title + "</td><td4@CS>" + "" + "</td></tr>");
                }
                else
                {
                    sb.Append("<tr><td6@CS>" + cha_title + "</td><td4@CS>" + EXPORTER_NAME + "</td></tr>");
                }
                sb.Append("<tr10br@123>");

                if (COMPANY_ID == "517")
                {
                    sb.Append("<tr><td6@CS>" + "R.DEVANANTH" + "</td><td4@CS>" + "" + "</td></tr>");
                    sb.Append("<tr><td6@CS>" + "P.A.HOLDER" + "</td><td4@CS>" + "" + "</td></tr>");
                    sb.Append("<tr><td6@CS>" + "CARD NO:34/2021" + "</td><td4@CS>" + "" + "</td></tr>");
                }
                else
                {
                    sb.Append("<tr><td6@CS>" + cha_Signature + "</td><td4@CS>" + Signature + "</td></tr>");
                }

                sb.Append("</table></html>");


                HttpResponse Response = HttpContext.Current.Response;
                Literal ltl = new Literal();

                ltl.Text = sb.ToString().Replace("<tdFWB@123>", "<td style='font-weight:bold'>").Replace("<td2FWB@123>", "<td colspan='2' style='font-weight:bold'>").Replace("<td3FWB@123>", "<td colspan='3' style='font-weight:bold'>").Replace("<td4FWB@123>", "<td colspan='4' style='font-weight:bold'>").Replace("<td5FWB@123>", "<td colspan='5' style='font-weight:bold'>").Replace("<td6FWB@123>", "<td colspan='6' style='font-weight:bold'>").Replace("<td7FWB@123>", "<td colspan='7' style='font-weight:bold'>").Replace("<td8FWB@123>", "<td colspan='8' style='font-weight:bold'>").Replace("<td9FWB@123>", "<td colspan='9' style='font-weight:bold'>").Replace("<td10FWB@123>", "<td colspan='10' style='font-weight:bold'>").Replace("<td2@CS>", "<td colspan='2'>").Replace("<td3@CS>", "<td colspan='3'>").Replace("<td4@CS>", "<td colspan='4'>").Replace("<td5@CS>", "<td colspan='5'>").Replace("<td6@CS>", "<td colspan='6'>").Replace("<td7@CS>", "<td colspan='7'>").Replace("<td8@CS>", "<td colspan='8'>").Replace("<td9@CS>", "<td colspan='9'>").Replace("<td10@CS>", "<td colspan='10'>").Replace("<tr10br@123>", "<tr><td colspan='10'><br/></td></tr>").Replace("<tdSAR@123>", "<td style='text-align:right'>").Replace("<td2SAR@123>", "<td colspan='2' style='text-align:right'>").Replace("<td3SAR@123>", "<td colspan='3' style='text-align:right'>").Replace("<td4SAR@123>", "<td colspan='4' style='text-align:right'>").Replace("<td5SAR@123>", "<td colspan='5' style='text-align:right'>").Replace("<td6SAR@123>", "<td colspan='6' style='text-align:right'>").Replace("<td7SAR@123>", "<td colspan='7' style='text-align:right'>").Replace("<trFWB@123>", "<tr style='font-weight:bold'>");
                ds.Dispose();
                GC.Collect();

                string errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID.ToString() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User() + "/Export_CheckList/");


                Response.Clear();
                Response.Buffer = true;

                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }
                else
                {
                    foreach (FileInfo fileInformation in new DirectoryInfo(errorFolder).GetFiles())  // delete all the files inside  Export_CheckList - folder
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

                            //if (resultPage[res].ToString().Contains("@AssVal"))
                            //{
                            //    Page_AssVal = Page_AssVal + Convert.ToDouble(resultPage[res].Substring(resultPage[res].ToString().IndexOf("@AssVal="), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))).Split('@')[1].Split('=')[1]);
                            //}
                            //if (resultPage[res].ToString().Contains("@IGSTVal"))
                            //{
                            //    Page_IGSTVal = Page_IGSTVal + Convert.ToDouble(resultPage[res].Substring(resultPage[res].ToString().IndexOf("@IGSTVal="), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))).Split('@')[1].Split('=')[1]);
                            //}

                            //if (resultPage[res].ToString().Contains("Item-contentStarts@Rowno") && (resultPage[res].ToString().Contains("BE Gross Total"))) //
                            //{
                            //    if (resultPage[res - 1].ToString().Contains("Item-contentStarts@Rowno"))
                            //    {

                            //        tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            //        tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Page_AssVal) + " </td> <td4FWB@123>Page Total</td><tdSAR@123>" + String.Format("{0:0.00}", Page_IGSTVal) + "</td></tr>");


                            //        Grnd_Page_AssVal = Grnd_Page_AssVal + Page_AssVal;
                            //        Grnd_Page_IGSTVal = Grnd_Page_IGSTVal + Page_IGSTVal;


                            //        tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Grnd_Page_AssVal) + " </td> <td4FWB@123>BE Total</td><tdSAR@123>" + String.Format("{0:0.00}", Grnd_Page_IGSTVal) + "</td></tr>");
                            //        tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            //        Page_AssVal = 0;
                            //        Page_IGSTVal = 0;

                            //    }
                            //    //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            //    tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                            //}
                            //else
                            //{
                            //    tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                            //}

                            tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");

                            if (res % 50 == 0 && res > 5)  // prev i used 60 for mod 
                            {
                                // *** need to insert page total **//

                                if (resultPage[res].ToString().Contains("ItemFirstLine"))
                                {
                                    res = res + 1;
                                    tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                                    res = res + 1;
                                    tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");

                                }
                                else if (resultPage[res].ToString().Contains("ItemSecondLine"))
                                {
                                    res = res + 1;
                                    tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");

                                }


                                //else if (resultPage[res].ToString().Contains("Item-contentStarts@Rowno-ThirdLn")) 
                                //{
                                //    if (resultPage[res].ToString().Contains("FirstLine"))
                                //        curposition = 1;
                                //    else

                                //        curposition = Convert.ToInt32(resultPage[res].Substring(resultPage[res].ToString().IndexOf("*@Line#"), resultPage[res].ToString().IndexOf("<tr>")).Split('#')[1].Substring(0, resultPage[res].Substring(resultPage[res].ToString().IndexOf("*@Line#"), resultPage[res].ToString().IndexOf("<tr>")).Split('#')[1].IndexOf("<tr>")));

                                //    nooflines = 3;
                                //    //for (int k = 0; k < 15; k++)
                                //    //{
                                //    //    if (resultPage[res + k].ToString().Contains("Item-contentStarts@Rowno-ThirdLn"))
                                //    //    {
                                //    //        nooflines = Convert.ToInt32(resultPage[res + k].Substring(resultPage[res + k].ToString().IndexOf("*@Line#"), resultPage[res + k].ToString().IndexOf("<tr>")).Split('#')[1].Substring(0, resultPage[res + k].Substring(resultPage[res + k].ToString().IndexOf("*@Line#"), resultPage[res + k].ToString().IndexOf("<tr>")).Split('#')[1].IndexOf("<tr>")));
                                //    //        //nooflines = nooflines + 1;
                                //    //        break;
                                //    //    }
                                //    //}
                                //    if (nooflines - curposition > 2)
                                //    {

                                //        diff = curposition;
                                //        while (diff > 0)
                                //        {
                                //            tempPage.RemoveAt(tempPage.Count - 1);
                                //            diff = diff - 1;
                                //        }
                                //        res = res - curposition;



                                //    }
                                //    else if (nooflines - curposition <= 2)
                                //    {

                                //        diff = nooflines - curposition;
                                //        while (diff > 0)
                                //        {
                                //            res = res + 1;
                                //            tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                                //            curposition = curposition - 1;
                                //            diff = diff - 1;
                                //        }

                                //    }
                                //}



                                //if ((resultPage[res - 1].ToString().Contains("Item-contentStarts@Rowno")) && !(resultPage[res - 1].ToString().Contains("Duty Payable")) && !(resultPage[res].ToString().Contains("Duty Payable")))
                                //{

                                //    tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                                //    tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Page_AssVal) + " </td> <td4FWB@123>Page Total</td><tdSAR@123>" + String.Format("{0:0.00}", Page_IGSTVal) + "</td></tr>");
                                //    //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                                //    Grnd_Page_AssVal = Grnd_Page_AssVal + Page_AssVal;
                                //    Grnd_Page_IGSTVal = Grnd_Page_IGSTVal + Page_IGSTVal;

                                //    //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                                //    tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Grnd_Page_AssVal) + " </td> <td4FWB@123>BE Total</td><tdSAR@123>" + String.Format("{0:0.00}", Grnd_Page_IGSTVal) + "</td></tr>");
                                //    tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                                //    Page_AssVal = 0;
                                //    Page_IGSTVal = 0;

                                //}

                                tempPage.Add("</table></html><html><table>");
                                if (resultPage[res].ToString().Contains("Item-contentStarts@Rowno"))
                                {

                                    //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                                    tempPage.Add("<trFWB@123><td>SLNo</td> <td>RITC</td><td8@CS>Description</td></tr>");
                                    tempPage.Add("<trFWB@123><td>Quantity</td> <td>Units</td> <td2@CS>Item &nbsp; &nbsp;&nbsp;&nbsp;       Rate Per</td><td>Unit</td><td2@CS>Value (FC)</td><td>FOB (INR)</td><td>Sch Cd</td><td>Reward[Y/N]</td></tr>");
                                    tempPage.Add("<trFWB@123><td2@CS>Scheme Description</td> <td2@CS>End Use</td> <td>PMV</td> <td2@CS>Total PMV</td><td>IGST Pyt.Sts</td><td>IGST Val</td><td>IGST Amt</td></tr>");
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

                                else if (resultPage[res].ToString().Contains("Drawback-contentStarts@Rowno"))
                                {
                                    if (resultPage[res].ToString().Contains("Drawback-contentStarts@Rowno-2ndLine"))
                                    {
                                        tempPage.RemoveAt(tempPage.Count - 1);
                                        res = res + 1;
                                        tempPage.Add(resultPage[res].Substring(resultPage[res].ToString().IndexOf("<tr"), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))) + "</tr>");
                                        tempPage.Add("</table></html><html><table>");
                                    }

                                    //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                                    tempPage.Add("<trFWB@123><td>Invsl</td><td>Itemsl</td> <td>DBK SNo</td><td2@CS>Cus.Rate</td><td2@CS>DBK Adv</td><td>DBK Qty</td><td2@CS>DBK.Amt(INR)</td></tr>");
                                    tempPage.Add("<trFWB@123><td3@CS></td><td2@CS>Exc.Rate</td><td2@CS>DBK RateSpl</td><td3@CS>Unit</td></tr>");
                                    tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");


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

                                    // tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                                    tempPage.Add("<trFWB@123><td>Inv Sl</td><td>Item Sl</td> <td>Scheme</td><td2@CS>Regn No</td><td>Regn Date</td><td>SNo-E</td><td>Exp Qty</td><td>Unit</td><td>Imp / Ind</td></tr>");
                                    tempPage.Add("<trFWB@123><td6@CS>Description</td><td>SNo-C</td> <td>Imp Qty</td><td2@CS>Unit</td></tr>");
                                    tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");


                                }

                                //else if (resultPage[res].ToString().Contains("GSTIN-contentStarts@Rowno") && resultPage[res + 1].ToString().Contains("GSTIN-contentStarts@Rowno"))
                                //{

                                //    tempPage.Add("<tr style='text-align:center'><td10FWB@123><u>GSTIN Details</u></td></tr>");
                                //    tempPage.Add("<trFWB@123><td2@CS>Document No</td><td2@CS>Type</td><td2@CS>State Code/ Name</td> <td2@CS>IGST Amt</td><td2@CS>GST Cess Amt</td></tr>");
                                //}


                            }
                        }
                        else
                        {

                            //if (resultPage[res].ToString().Contains("@AssVal"))
                            //{
                            //    Page_AssVal = Page_AssVal + Convert.ToDouble(resultPage[res].Substring(resultPage[res].ToString().IndexOf("@AssVal="), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))).Split('@')[0].Split('=')[1]);
                            //}
                            //if (resultPage[res].ToString().Contains("@IGSTVal"))
                            //{
                            //    Page_IGSTVal = Page_IGSTVal + Convert.ToDouble(resultPage[res].Substring(resultPage[res].ToString().IndexOf("@IGSTVal="), resultPage[res].Length - (resultPage[res].ToString().IndexOf("<tr"))).Split('@')[1].Split('=')[1]);
                            //}

                            if (res == 0)
                            {
                                tempPage.Add(resultPage[res].ToString() + "</tr>");  // 1st row  
                            }
                            //else if (res == resultPage.Length - 1) // last row of the html file
                            //{
                            //    if (resultPage[res - 1].ToString().Contains("Item-contentStarts@Rowno"))
                            //    {
                            //        tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            //        tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Page_AssVal) + " </td> <td4FWB@123>Page Total</td><tdSAR@123>" + String.Format("{0:0.00}", Page_IGSTVal) + "</td></tr>");
                            //        //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                            //        Grnd_Page_AssVal = Grnd_Page_AssVal + Page_AssVal;
                            //        Grnd_Page_IGSTVal = Grnd_Page_IGSTVal + Page_IGSTVal;

                            //        //tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            //        tempPage.Add("<tr> <td3@CS></td> <td2@CS> " + String.Format("{0:0.00}", Grnd_Page_AssVal) + " </td> <td4FWB@123>BE Total</td><tdSAR@123>" + String.Format("{0:0.00}", Grnd_Page_IGSTVal) + "</td></tr>");
                            //        tempPage.Add("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            //        Page_AssVal = 0;
                            //        Page_IGSTVal = 0;

                            //    }
                            //    tempPage.Add(resultPage[res].ToString() + "</tr>");
                            //}
                        }
                    }
                    ltl.Text = ltl.Text + string.Join("", tempPage);

                    if (!ltl.Text.EndsWith("</table></html>"))
                    {
                        ltl.Text = ltl.Text + "</table></html>";
                    }
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
                    {
                        if (result[res].ToString().StartsWith("<tr><td colspan='4' style='font-weight:bold'>Exporter Details :</td>"))
                            temp.Add("<table><html>" + result[res].ToString() + "</table></html>");
                        else
                            temp.Add(result[res].ToString() + "</table></html>");
                    }
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
                        filename1 = "Exp_" + (pdfcount + 1) + "_" + ddlJobNo + ".pdf";
                        HtmlTextWriter hw = new HtmlTextWriter(sw);

                        ltl.Text = temp[pdfcount].ToString().Replace("<tdFWB@123>", "<td style='font-weight:bold'>").Replace("<td2FWB@123>", "<td colspan='2' style='font-weight:bold'>").Replace("<td3FWB@123>", "<td colspan='3' style='font-weight:bold'>").Replace("<td4FWB@123>", "<td colspan='4' style='font-weight:bold'>").Replace("<td5FWB@123>", "<td colspan='5' style='font-weight:bold'>").Replace("<td6FWB@123>", "<td colspan='6' style='font-weight:bold'>").Replace("<td7FWB@123>", "<td colspan='7' style='font-weight:bold'>").Replace("<td8FWB@123>", "<td colspan='8' style='font-weight:bold'>").Replace("<td9FWB@123>", "<td colspan='9' style='font-weight:bold'>").Replace("<td10FWB@123>", "<td colspan='10' style='font-weight:bold'>").Replace("<td2@CS>", "<td colspan='2'>").Replace("<td3@CS>", "<td colspan='3'>").Replace("<td4@CS>", "<td colspan='4'>").Replace("<td5@CS>", "<td colspan='5'>").Replace("<td6@CS>", "<td colspan='6'>").Replace("<td7@CS>", "<td colspan='7'>").Replace("<td8@CS>", "<td colspan='8'>").Replace("<td9@CS>", "<td colspan='9'>").Replace("<td10@CS>", "<td colspan='10'>").Replace("<tr10br@123>", "<tr><td colspan='10'><br/></td></tr>").Replace("<tdSAR@123>", "<td style='text-align:right'>").Replace("<td2SAR@123>", "<td colspan='2' style='text-align:right'>").Replace("<td3SAR@123>", "<td colspan='3' style='text-align:right'>").Replace("<td7SAR@123>", "<td colspan='7' style='text-align:right'>").Replace("<trFWB@123>", "<tr style='font-weight:bold'>");
                        //ltl.Text = temp[pdfcount].ToString().Replace("<tdFWB@123>", "<td style='font-weight:bold'>").Replace("<td2FWB@123>", "<td colspan='2' style='font-weight:bold'>").Replace("<td3FWB@123>", "<td colspan='3' style='font-weight:bold'>").Replace("<td4FWB@123>", "<td colspan='4' style='font-weight:bold'>").Replace("<td5FWB@123>", "<td colspan='5' style='font-weight:bold'>").Replace("<td6FWB@123>", "<td colspan='6' style='font-weight:bold'>").Replace("<td7FWB@123>", "<td colspan='7' style='font-weight:bold'>").Replace("<td8FWB@123>", "<td colspan='8' style='font-weight:bold'>").Replace("<td9FWB@123>", "<td colspan='9' style='font-weight:bold'>").Replace("<td10FWB@123>", "<td colspan='10' style='font-weight:bold'>").Replace("<td2@CS>", "<td colspan='2'>").Replace("<td3@CS>", "<td colspan='3'>").Replace("<td4@CS>", "<td colspan='4'>").Replace("<td5@CS>", "<td colspan='5'>").Replace("<td6@CS>", "<td colspan='6'>").Replace("<td7@CS>", "<td colspan='7'>").Replace("<td8@CS>", "<td colspan='8'>").Replace("<td9@CS>", "<td colspan='9'>").Replace("<td10@CS>", "<td colspan='10'>").Replace("<tr10br@123>", "<tr><td colspan='10'><br/></td></tr>").Replace("<tdSAR@123>", "<td style='text-align:right'>").Replace("<td2SAR@123>", "<td colspan='2' style='text-align:right'>").Replace("<td3SAR@123>", "<td colspan='3' style='text-align:right'>").Replace("<td4SAR@123>", "<td colspan='4' style='text-align:right'>").Replace("<td5SAR@123>", "<td colspan='5' style='text-align:right'>").Replace("<td6SAR@123>", "<td colspan='6' style='text-align:right'>").Replace("<td7SAR@123>", "<td colspan='7' style='text-align:right'>").Replace("<trFWB@123>", "<tr style='font-weight:bold'>");
                        ltl.Text = ltl.Text.Replace("<html><table>", "<html><table width='100%' style='vertical-align:top; font-family:Arial; font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");
                        ltl.RenderControl(hw);
                        StringReader sr = new StringReader(sw.ToString());
                        //Document pdfDoc = new Document(PageSize.A4, 40f, 10f, 80f, 10f);
                        Document pdfDoc = new Document(PageSize.A4, 40f, 10f, 110f, 15f);  // left, right , top, bottom


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
                        filename1 = "Exp_" + (pdfcount + 1) + "_" + ddlJobNo + ".pdf";
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

                        filename1 = "Exp_" + (pdfcount + 1) + "_" + ddlJobNo + ".pdf";

                        byte[] bytes = File.ReadAllBytes(errorFolder + filename1);
                        Font blackFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK);
                        Font blackFont2 = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);
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
                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(head2, blackFont), 300f, 800f, 0); //check list shipping bill                            
                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(head3, blackFont3), 300f, 790f, 0); //break / nefi
                                    ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_LEFT, new Phrase(head4 + "                                                      Page #" + (pno) + "/" + totpno, blackFont3), 40f, 780f, 0);
                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(head5, blackFont2), 300f, 770f, 0); //line ----                           

                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head6, blackFont3), 40f, 760f, 0);  // job no
                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head6_2, blackFont3), 300f, 760f, 0);  // file no
                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head6_3, blackFont3), 450f, 760f, 0);  // job date

                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head7, blackFont3), 40f, 750f, 0);  // CHA
                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head7_2, blackFont3), 300f, 750f, 0);  // CHA

                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head8, blackFont3), 40f, 740f, 0);  //port of filing
                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(head8_2, blackFont3), 300f, 740f, 0);  //port of filing
                                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(head5, blackFont2), 300f, 730f, 0); //line ----   

                                    pno = pno + 1;
                                }
                            }
                            bytes = stream.ToArray();
                        }
                        filename1 = "Exp_" + (pdfcount + 1) + "_" + ddlJobNo + "_hdr.pdf";
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
                    Response.AppendHeader("content-disposition", "inline; filename=" + ddlJobNo + ".pdf");
                    Response.End();
                }
                //*************** end to merge all pdf files ********************//


            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            ViewState["ErrorJobnos"] = ViewState["ErrorJobnos"].ToString() + "," + ddlJobNo;

        }
    }

    private void checklistNew()
    {
        //try
        //{
            double FOB_total = 0.00;
            double PMV_total = 0.00;
            double Grand_FOB_total = 0.00;
            double Grand_PMV_total = 0.00;

            double Tax_total = 0.00;
            double Grand_Tax_total = 0.00;
            double IGST_total = 0.00;
            double Grand_IGST_total = 0.00;
            string FileName_First_InvoiceNo = "";
            double cess_amountNew = 0.00;
            double QTY_total = 0.00;
            double Grand_QTY_total = 0.00;

            DataTable dt_MultipleCHA = new DataTable();
            List<Report_Export_Export_ReportViewer> Load_Item_DetailsInd = new List<Report_Export_Export_ReportViewer>();
            Rpt_Invoice_Details_list.Clear();

            StringBuilder sb = new StringBuilder();
            string indjobstring = "";
            DataSet dss = new DataSet();
            DataSet dssAss = new DataSet();
            //ddlJobNo = Request.QueryString["jobno"].ToString();
            ddlJobNo = ddlJob_No.SelectedValue.ToString();
            Session["JobNo"] = ddlJobNo;
            ds = (DataSet)HttpContext.Current.Session["EXPORT_CHECKLIST"];
            if (!string.IsNullOrEmpty(Request["Annexure_Mode"]))
            {
                IS_ANNEXURE_MODE = Convert.ToInt32(Request["Annexure_Mode"].ToString());
            }
            if (!string.IsNullOrEmpty(Request["STR_CODE"]))
            {
                Is_STR = Convert.ToInt32(Request["STR_CODE"].ToString());

            }

            string SE = "";

            Auto_Search auto = new Auto_Search();
            if (ds.Tables[0].Rows.Count > 0)
            {

                string custom = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                string custom_name = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString();
                string custid = "", name = "", rows = string.Empty;
                //if (custom != "" && custom_name == "")// hide by chithra on 27/03/2019- for Oriental Mumbai
                if (custom != "")
                {
                    if (COMPANY_ID == "532")
                    {
                        if (custom == "INBOM4")
                        {
                            custom_name = "SAHAR AIR CARGO";
                        }
                        else if (custom == "INNSA1")
                        {
                            custom_name = "NHAVA SHEVA(JNPT)";
                        }
                        else
                        {
                            custom_name = auto.Country_Master_FromClientSide_Calling(custid = custom, name = "CUSTOM_HOUSE_MASTER_CUSTOM_NAME", rows = "CUSTOMHOUSE_NAME");
                        }
                    }
                    else
                    {
                        custom_name = auto.Country_Master_FromClientSide_Calling(custid = custom, name = "CUSTOM_HOUSE_MASTER_CUSTOM_NAME", rows = "CUSTOMHOUSE_NAME");
                    }
                }

                Auto_Search Auto = new Auto_Search();
                Auto.Enamesearch = ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString();
                Auto.Ename = "State_Code";

                DataSet ss = new DataSet();
                ss = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (ss.Tables[0].Rows.Count > 0)
                {
                    SE = ", " + ss.Tables[0].Rows[0][0].ToString();
                }

                string Exporter = "";
                string Signature = "";
                string cha_Signature = "";
                string cha = "";
                string cha_title = "";
                string cha_Name = "";

                string CHA_NO = Connection.Get_EXP_CHA_NO();
                EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();

                if (Connection.Exp_Multiple_CHA_IcegateID_enable(COMPANY_ID) == "Y")
                {
                    dt_MultipleCHA = Connection.Get_Multiple_ICE_ID_CHANO_frm_GENERAL_DETAILS(ds.Tables[0].Rows[0]["ICE_ID"].ToString(), "E");

                    if (dt_MultipleCHA.Rows.Count > 0)
                    {
                        cha_Name = dt_MultipleCHA.Rows[0]["CHA_NAME"].ToString();
                        CHA_NO = dt_MultipleCHA.Rows[0]["CHA_NO"].ToString();
                    }
                    else
                    {
                        cha_Name = Connection.Get_EXP_CHA_NAME().Replace("amp;", "");
                    }
                }
                else
                {
                    cha_Name = Connection.Get_EXP_CHA_NAME().Replace("amp;", "");
                }

                if (COMPANY_ID != "517" && COMPANY_ID != "480" && COMPANY_ID != "508" && COMPANY_ID != "3388")
                {
                    Exporter = "Exporter";
                    Signature = "Signature";
                }
                else
                {
                    EXPORTER_NAME = "";
                }

                if (COMPANY_ID != "1014" && COMPANY_ID != "1")
                {
                    cha = "CHA";
                    cha_Signature = "Signature";
                    if (COMPANY_ID == "1307" || COMPANY_ID == "2145" || COMPANY_ID == "2318" || COMPANY_ID == "2478" || COMPANY_ID == "3194")
                    {
                        cha_title = cha_Name;
                    }
                    else
                    {
                        cha_title = Connection.Get_EXP_CHA_NAME().Replace("amp;", "");
                    }
                }
                else
                {
                    EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                }

                if (COMPANY_ID == "539")
                {
                    cha = "Exporter" + "/" + "CHA with date";
                    cha_Signature = "Signature";
                    cha_title = "For " + Connection.Get_EXP_CHA_NAME().Replace("amp;", "");
                    EXPORTER_NAME = "";
                    Exporter = "";
                    Signature = "";
                    cha_Signature = "";
                }
                SB_TYPE = ds.Tables[0].Rows[0]["SB_TYPE"].ToString();

                Get_ITEM_Details(ddlJobNo, ds.Tables[1], ds.Tables[2], ds.Tables[5], ds.Tables[15], ds.Tables[13], ds.Tables[26], ds.Tables[27]);

                FOB_VALUE = Math.Round(SUM_TOTAL_FOB_VALUE, 2);
                //DRAWBACK_VALUE = Convert.ToString(Math.Round(SUM_TOTAL_DBK_VALUE, 2));
                DRAWBACK_VALUE = Convert.ToString(Math.Round(SUM_TOTAL_DBK_VALUE, 2).ToString("0.00"));
                STR_AMT = Convert.ToString(Math.Round(SUM_TOTAL_STR_AMT, 2));
                // DBK_STR_AMT = Convert.ToDouble(DRAWBACK_VALUE) + Convert.ToDouble(STR_AMT);
                DBK_STR_AMT = Convert.ToDouble(Math.Round(SUM_TOTAL_DBK_VALUE, 2)) + Convert.ToDouble(Math.Round(SUM_TOTAL_STR_AMT, 2));
                JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString();

                ////*** added on 5/Jan/2018 by jayanthi for calc.total value ****////
                if (Rpt_Invoice_Details_list.Count > 0)
                {
                    ////#FOB - Sum of TOtal FOB calc 

                    //hide on 04-10-2024 for Elite Ship - eri02745
                    //Grand_FOB_total = Rpt_Item_Details_new_list.Sum(item => Convert.ToDouble(item.FOB_VALUE));
                    Grand_FOB_total = Rpt_Item_Details_new_list.Sum(item => Convert.ToDouble(item.ACTUAL_ITEM_FOB_VALUE));//Newly added on 04-10-2024
                    Grand_Tax_total = Rpt_Item_Details_new_list.Sum(item => Convert.ToDouble(item.TAXABLE_VALUE));
                    Grand_PMV_total = Rpt_Item_Details_new_list.Sum(item => Convert.ToDouble(item.TOTAL_PMVVALUE));
                    Grand_IGST_total = Rpt_Item_Details_new_list.Sum(item => Convert.ToDouble(item.IGST_AMT));
                    Grand_QTY_total = Rpt_Item_Details_new_list.Sum(item => Convert.ToDouble(item.ITEM_QTY));

                }

                //Need Settings here
                //#FOB Value Rounded Value
                //if (COMPANY_ID == "744" || COMPANY_ID == "196")//hide on 19-06-2026
                if (COMPANY_ID == "744")//sun global
                {
                    Grand_FOB_total = Convert.ToDouble((Math.Round(Convert.ToDecimal(Grand_FOB_total), 0, MidpointRounding.AwayFromZero)).ToString());
                }
                else if (COMPANY_ID == "3267") // Cut off 2 Digit after the Decimal
                {
                    //hide on 03-07-2026- Again round off issue for Invoice Value & FOB Value mismatch - checked with shaziya
                    //Grand_FOB_total = Convert.ToDouble((Math.Round(Convert.ToDecimal(Grand_FOB_total), 2, MidpointRounding.AwayFromZero)).ToString());
                    //hide on 24-04-2026- Again round off issue for Invoice Value & FOB Value mismatch
                    Grand_FOB_total = Convert.ToDouble((Math.Truncate(Grand_FOB_total * 100) / 100).ToString("F2"));
                   
                }
                ////*** end of added on 5/Jan/2018 by jayanthi for calc.total value ****////



                sb.Append("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>");
                sb.Append("<tr style='text-align:center; font-weight:bold; font-size:12px'><td colspan='10'> " + cha_Name + " </td></tr>");
                if (COMPANY_ID == "525")
                {
                    sb.Append("<tr style='text-align:center; font-weight:bold; font-size:12px'><td colspan='10'> " + "Indian Customs EDI System - Exports ( ICES / E )" + " </td></tr>");
                }

                int heading = 0;
                if (SB_TYPE == "SEZ")
                {
                    heading = 1;
                }

                if ((COMPANY_ID == "2656") && ds.Tables[21].Rows.Count > 0)//check ReExport Entry Count
                {
                    var dt_SW_Ctrl = from DataRow drr in ds.Tables[18].AsEnumerable()
                                     where drr.Field<string>("CONTROL_TYPE_CODE") == "DUC"
                                     select drr;

                    DataView dvv = dt_SW_Ctrl.AsDataView();

                    if (dvv.Count > 0)//Check Single Window - Control - DUC Entry Count
                    {
                        heading = 2;
                    }
                }
                
                if ((COMPANY_ID == "809" || COMPANY_ID == "816" || COMPANY_ID == "926" || COMPANY_ID == "2666") && ds.Tables[21].Rows.Count > 0)//check ReExport Entry Count
                {
                    var dt_SW_XSB = from DataRow drr in ds.Tables[15].AsEnumerable()
                                    where drr.Field<string>("INFO_QUALIFIER") == "XSB"
                                    select drr;

                    DataView dvv = dt_SW_XSB.AsDataView();

                    if (dvv.Count > 0)//Check Single Window - Info - XSB Entry Count
                    {
                        heading = 2;
                    }
                }

                if (heading == 1)
                {
                    sb.Append("<tr style='text-align:center; font-weight:bold; font-size:11px'><td colspan='10'> CHECK LIST - Shipping Bill for SEZ</td></tr>");
                }
                else if (heading == 2)
                {
                    sb.Append("<tr style='text-align:center; font-weight:bold; font-size:11px'><td colspan='10'> CHECK LIST - EXBOND SHIPPING BILL </td></tr>");
                }
                else 
                {
                    sb.Append("<tr style='text-align:center; font-weight:bold; font-size:11px'><td colspan='10'> CHECK LIST - Shipping Bill</td></tr>");
                }
               
                sb.Append("<tr style='text-align:center; font-weight:bold; font-size:11px'><td colspan='10'> " + ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString() + "</td></tr>");
                sb.Append("<tr><td2FWB@123>S.B No & Date</td> <td colspan='3'><b>:</b> " + ds.Tables[0].Rows[0]["SB_NO"] + "  " + ds.Tables[0].Rows[0]["SB_Date"] + " </td> <td colspan='2' style='font-weight:bold'> Printed On  </td><td colspan='3'  style='font-weight:bold'><b>:</b>" + ds.Tables[0].Rows[0]["printdate"] + " </td></tr>");
                //string regNo = "", role = "";
                //if (dt_MultipleCHA.Rows.Count > 0 && !string.IsNullOrEmpty(dt_MultipleCHA.Rows[0]["AEO_REGISTRATION_NUMBER"].ToString()))
                //{
                //    regNo = dt_MultipleCHA.Rows[0]["AEO_REGISTRATION_NUMBER"].ToString();
                //    role = dt_MultipleCHA.Rows[0]["AEO_REGISTER_ROLE"].ToString();
                //}
                //else if (!string.IsNullOrEmpty(HttpContext.Current.Session["AEO_REG_NO"].ToString()))
                //    {
                //        regNo = HttpContext.Current.Session["AEO_REG_NO"].ToString();
                //        role = HttpContext.Current.Session["AEO_REG_ROLE"].ToString();
                //    }
                
                //if (!string.IsNullOrEmpty(regNo))
                //{
                //    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + regNo + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + role + " </td></tr>");
                //}

               
                if (COMPANY_ID == "333")
                {
                    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAAJCC4858N0F259" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "AEO-LO" + " </td></tr>");
                }
                else if (COMPANY_ID == "421")
                {
                    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAAJFV0053H0F238" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "AEO-LO" + " </td></tr>");
                }
                else if (COMPANY_ID == "438")
                {
                    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAAXCS0682E0F249" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "AEO-LO" + " </td></tr>");
                }
                else if (COMPANY_ID == "752")
                {
                    if (CHA_NO == "AAACR6636ACH001")
                    {
                        sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAAACR6636A0F266" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "AEO-LO" + " </td></tr>");
                    }
                }
                else if (COMPANY_ID == "862")
                {
                    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAAJFC7174Q0F246" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "AEO-LO" + " </td></tr>");
                }
                else if (COMPANY_ID == "824" || COMPANY_ID == "829")
                {
                    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAABCP5904G0F211" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "CUSTOMS" + " </td></tr>");
                }
                else if (COMPANY_ID == "1055")
                {
                    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAARFS2091N0F189" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "AEO-LO" + " </td></tr>");
                }
                else if (COMPANY_ID == "1144")
                {
                    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAAACR0251M0F237" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "AEO-LO" + " </td></tr>");
                }
                else if (COMPANY_ID == "1159" || COMPANY_ID == "1160")
                {
                    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAABCS2390D0F192" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "AEO-LO" + " </td></tr>");
                }
                else if (COMPANY_ID == "1686")
                {
                    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAJRPS0647P0F226" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "AEO-LO" + " </td></tr>");
                }
                else if (COMPANY_ID == "1686")
                {
                    sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAADCV4797M0F233" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "AEO-LO" + " </td></tr>");
                }
                else if (COMPANY_ID == "2266")
                {
                    if (Connection.Current_User_Upper() != "ASHAPURA7" && Connection.Current_User_Upper() != "ASHAPURA8" && Connection.Current_User_Upper() != "ASHAPURA9" && Connection.Current_User_Upper() != "ASHAPURA10")
                    {
                        sb.Append("<tr><td2FWB@123>AEO Registration.No</td> <td colspan='3'><b>:</b> " + "INAACFT7897C0F203" + " </td> <td colspan='2' style='font-weight:bold'> AEO Role </td><td colspan='3'><b>:</b>" + "" + " </td></tr>");
                    }
                }
                
                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9
                sb.Append("<tr><td2FWB@123>Job No & Date</td><td3@CS><b>:</b> " + ddlJob_No.SelectedItem.Text + "   -  " + ds.Tables[0].Rows[0]["JOBDATE"] + "</td> <td2FWB@123>File Ref. No</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["FILE_REF_NO"] + "</td></tr>");


                if (ds.Tables[25].Rows.Count > 0)
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
                        if (ds.Tables[25].Rows[0]["SEZ_PAN_NO"].ToString() != "")
                        {
                            CHA_NO = ds.Tables[25].Rows[0]["SEZ_PAN_NO"].ToString();
                        }
                    }
                }

                sb.Append("<tr><td2FWB@123>CHA</td><td3@CS><b>:</b> " + CHA_NO + "</td> <td2FWB@123>Name</td><td3@CS><b>:</b> " + cha_Name + "</td></tr>");
                // sb.Append("<tr><td2FWB@123>Port Of Loading</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["Customs_House"] + "</td> <td2FWB@123>State Of Origin</td><td colspan='3'><b>:</b> " + ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString() + " " + SE + "</td></tr>");

                if (SB_TYPE == "SEZ")
                {
                    sb.Append("<tr><td2FWB@123>Cus.House & PortOfLoading</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["Customs_House"] + " & " + ds.Tables[0].Rows[0]["PORT_OF_LOADING"] + "</td> <td2FWB@123>State Of Origin</td><td colspan='3'><b>:</b> " + ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString() + " " + SE + "</td></tr>");
                }
                else
                {
                    sb.Append("<tr><td2FWB@123>Custom House</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["Customs_House"] + " - " + custom_name + "</td> <td2FWB@123>State Of Origin</td><td colspan='3'><b>:</b> " + ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString() + " " + SE + "</td></tr>");
                }

                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9
                sb.Append("<tr><td5FWB@123>Exporter Details :</td><td5FWB@123>Consignee Details :</td></tr>");

                if (ds.Tables[0].Rows[0]["IMP_EXP_PAN_NO"].ToString() != "")
                    sb.Append("<tr><td5@CS>" + ds.Tables[0].Rows[0]["IEC_NO"] + "  PAN :" + ds.Tables[0].Rows[0]["IMP_EXP_PAN_NO"] + " </td><td5@CS>" + ds.Tables[0].Rows[0]["Consignee_name"] + "</td></tr>");
                else
                    sb.Append("<tr><td5@CS>" + ds.Tables[0].Rows[0]["IEC_NO"] + "</td><td5@CS>" + ds.Tables[0].Rows[0]["Consignee_name"] + "</td></tr>");

                sb.Append("<tr><td5@CS>" + ds.Tables[0].Rows[0]["Exporter_Name"] + "</td><td5@CS>" + ds.Tables[0].Rows[0]["Consignee_Add1"] + "</td></tr>");
                sb.Append("<tr><td5@CS>Branch Sr.No: " + ds.Tables[0].Rows[0]["Branch_NO"] + "</td><td5@CS>" + ds.Tables[0].Rows[0]["Consignee_Add2"] + "</td></tr>");
                sb.Append("<tr><td5@CS>" + ds.Tables[0].Rows[0]["ADDRESS1"] + "</td><td5@CS>" + ds.Tables[0].Rows[0]["Consignee_Add3"] + "</td></tr>");
                sb.Append("<tr><td5@CS>" + ds.Tables[0].Rows[0]["ADDRESS2"] + "</td><td5@CS>" + ds.Tables[0].Rows[0]["Consignee_Add4"] + "</td></tr>");
                sb.Append("<tr><td5@CS>" + ds.Tables[0].Rows[0]["ADDRESS3"] + "</td><td5@CS>" + ds.Tables[0].Rows[0]["Consignee_Add5"] + "</td></tr>");
                sb.Append("<tr><td10@CS>" + ds.Tables[0].Rows[0]["ADDRESS4"] + " " + ds.Tables[0].Rows[0]["ADDRESS5"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>GSTN Type / ID</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["GSTN_TYPE"] + " / " + ds.Tables[0].Rows[0]["GSTN_ID"] + "</td><td2FWB@123>AD Code</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["ADCode"] + "</td></tr>");

                if (COMPANY_ID == "2188")//Logimetrix 
                {
                    sb.Append("<tr><td2FWB@123></td><td3@CS><b></b> " + "" + "</td><td2FWB@123>SEAL Type</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEAL_TYPE"] + "</td></tr>");
                }
                else
                {
                    sb.Append("<tr><td2FWB@123>Type Of Exporter</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER_New"] + "</td><td2FWB@123>SEAL Type</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEAL_TYPE"] + "</td></tr>");
                }

                sb.Append("<tr><td2FWB@123>Port Discharge </td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["PORT_DISCHARGE"] + "</td><td2FWB@123>Total Packages</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["TOTAL_PACKAGES"] + "</td></tr>");

                DataSet dss_Coo = new DataSet();
                Export_FlatFile_Generation Imp_FlatFile = new Export_FlatFile_Generation();
                Imp_FlatFile.Ename = "IMPORT_SELECT_COUNTRY";
                dss_Coo = Imp_FlatFile.Search_Admin_Master();

                string COUNTRY_DISCHARGE_Code = "", COUNTRY_FINAL_DEST_Code = "";
                DataView view1_Coo = dss_Coo.Tables[0].DefaultView;

                view1_Coo = dss_Coo.Tables[0].DefaultView;
                view1_Coo.RowFilter = "COUNTRY_NAME = '" + ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"] + "'";
                DataSet dt_1 = new DataSet();
                dt_1.Tables.Add(view1_Coo.ToTable());
                if (dt_1.Tables[0].Rows.Count > 0)
                {
                    COUNTRY_DISCHARGE_Code = dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
                }

                view1_Coo.RowFilter = "COUNTRY_NAME = '" + ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"] + "'";
                DataSet dt_2 = new DataSet();
                dt_2.Tables.Add(view1_Coo.ToTable());
                if (dt_2.Tables[0].Rows.Count > 0)
                {
                    COUNTRY_FINAL_DEST_Code = dt_2.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
                }


                sb.Append("<tr><td2FWB@123>Country Discharge</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"] + "-" + COUNTRY_DISCHARGE_Code + "</td><td2FWB@123>Loose Packets</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["LOOSE_PACKETS"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Port Final Dest</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["PORT_FINAL_DEST"] + "</td><td2FWB@123>Net Weight</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["NET_WEIGHT"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Country Final Dest</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"] + "-" + COUNTRY_FINAL_DEST_Code + "</td><td2FWB@123>No Of Containers</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["NO_CONTAINERS"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Gross Weight</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["GROSS_WEIGHT"] + "</td><td2FWB@123>NFEI Type</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["NFEI_TYPE"] + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Nature Of Cargo</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["NATURE_OF_CARGO"] + "</td><td2FWB@123>RBI Waiver No</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["RBI_WAIVER_NO"] + "</td></tr>");

                if (ds.Tables[0].Rows[0]["MARKS_NO"].ToString() == "")
                    sb.Append("<tr><td2FWB@123>Marks & Nos</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["MARKS_NO"] + "</td><td2FWB@123>RBI Waiver Date</td><td4@CS><b>:</b> " + ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"] + "</td></tr>");
                else
                {
                    sb.Append("<tr><td5@CS></td><td2FWB@123>RBI Waiver Date</td><td5@CS><b>:</b> " + ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"] + "</td></tr>");
                    sb.Append("<tr> <td colspan='2' style='font-weight:bold; vertical-align:top'>Marks & Nos</td><td8@CS><b>:</b> " + ds.Tables[0].Rows[0]["MARKS_NO"] + "</td></tr>");
                }

                string MAWB_NO = "";
                string HAWB_NO = "";

                if (ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString() != "")
                {
                    MAWB_NO = ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString() + " - " + ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString();
                }

                if (ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString() != "")
                {
                    HAWB_NO = ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString() + " - " + ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_DATE"].ToString();
                }

                sb.Append("<tr><td2FWB@123>Mawb No & Date</td><td3@CS><b>:</b> " + MAWB_NO + "</td><td2FWB@123>Total Drawback Amt(INR)</td><td3@CS><b>:</b> " + DRAWBACK_VALUE + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Hawb No & Date </td><td3@CS><b>:</b> " + HAWB_NO + "</td><td2FWB@123>Total RODTEP Amt (INR)</td><td3@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(TOTAL_RODTEP_VALUE, 2)) + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Bank A/C No </td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["BANK_ACCOUNT"] + "</td><td2FWB@123>Total ROSCTL Amt (INR)</td><td3@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(TOT_SUM_LEV_AMT, 2)) + "</td></tr>");
                sb.Append("<tr><td2FWB@123>Dbk Bank A/C No</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"] + "</td><td2FWB@123>FOB Value</td><td3@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(Grand_FOB_total, 2)) + "</td></tr>");
                sb.Append("<tr><td2FWB@123>IFSC Code</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["IFSC_CODE"] + "</td><td2FWB@123>IGST Value</td><td3@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(Grand_Tax_total, 2)) + "</td></tr>");
                sb.Append("<tr><td2FWB@123></td><td3@CS><b></b> " + "" + "</td><td2FWB@123>IGST Amount</td><td3@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(Grand_IGST_total, 2)) + "</td></tr>");


                //sb.Append("<tr><td2FWB@123>Dbk Bank A/C No</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"] + "</td><td2FWB@123>FOB Value</td><td3@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(Grand_FOB_total, 2)) + "</td></tr>");
                //sb.Append("<tr><td2FWB@123>IFSC Code</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["IFSC_CODE"] + "</td><td2FWB@123>IGST Value</td><td3@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(Grand_Tax_total, 2)) + "</td></tr>");
                //sb.Append("<tr><td2FWB@123></td><td3@CS><b></b> " + "" + "</td><td2FWB@123>IGST Amount</td><td3@CS><b>:</b> " + String.Format("{0:0.00}", Math.Round(Grand_IGST_total, 2)) + "</td></tr>");


                if (STR_AMT != "0")
                    sb.Append("<tr><td2FWB@123>ServiceTax refund(INR)</td><td3@CS><b>:</b> " + STR_AMT + "</td><td2FWB@123>DBK + STR (INR)</td><td3@CS><b>:</b> " + DBK_STR_AMT + "</td></tr>");



                //  ************  start of Invoice details  *****************//

                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9
                sb.Append("<tr><td2FWB@123>INVOICE DETAILS</td><td8@CS>No Of Invoices : " + ds.Tables[1].Rows.Count + "</td></tr>");
                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9

                for (int inv = 0; inv < Rpt_Invoice_Details_list.Count; inv++)
                {

                    sb.Append("<tr><td2FWB@123>Inv.SlNo</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INVOICE_SLNO + "</td><td2FWB@123>Whether Unit Price </td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].WHEATHER_UNIT_PRICE + "</td> </tr>");
                    sb.Append("<tr><td2FWB@123>GST Invoice No</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INVOICE_NO + "</td><td2FWB@123>Invoice Date</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INVOICE_DATE + "</td> </tr>");
                    sb.Append("<tr><td2FWB@123>Nature Of Contract</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].TERMS + "</td><td5FWB@123>Buyer Details</td><b>:</b> </tr>");
                    sb.Append("<tr><td2FWB@123>Nature Of Payment</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].PAYMENT_METHOD + "</td><td5@CS>" + Rpt_Invoice_Details_list[inv].BUYER_NAME + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Period Of Agreement</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].PERIOD_PAYMENT + "</td><td5@CS>" + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS + "</td></tr>");
                   
                    if (COMPANY_ID == "3416" || COMPANY_ID == "1" || COMPANY_ID == "10")
                    {
                        if (Rpt_Invoice_Details_list[inv].CONTRACT_DATE != "")
                        {
                            sb.Append("<tr><td2FWB@123>Contract No/Date</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].CONTRACT_NO + "/" + Rpt_Invoice_Details_list[inv].CONTRACT_DATE + "</td><td5@CS>" + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS1 + "</td></tr>");
                        }
                        else
                        {
                            sb.Append("<tr><td2FWB@123>Contract No</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].CONTRACT_NO + "</td><td5@CS>" + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS1 + "</td></tr>");
                        }
                    }
                    else
                    {
                        sb.Append("<tr><td2FWB@123>Contract No</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].CONTRACT_NO + "</td><td5@CS>" + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS1 + "</td></tr>");
                    }
                    sb.Append("<tr><td2FWB@123>Currency Code</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INVOICE_CURRENCY + "</td><td5@CS>" + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS2 + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Exchange Rate  </td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].EXCHANGE_RATE + "</td><td5@CS>" + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS3 + " " + Rpt_Invoice_Details_list[inv].BUYER_ADDRESS4 + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Invoice Value(FC) </td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INVOICE_VALUE_FC + "</td></tr>");

                    if (inv == 0)
                    {
                        FileName_First_InvoiceNo = Rpt_Invoice_Details_list[inv].INVOICE_NO;
                    }

                    if (COMPANY_ID == "1039")
                    {
                        sb.Append("<tr><td2FWB@123>Invoice Value(INR) </td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INDIVIDUAL_INVOICE_VALUE + "</td><td3@CS><b>DBK Value(INR) :</b> " + Rpt_Invoice_Details_list[inv].DBK_VALUE + "</td><td3@CS><b></b>" + "" + "</td></tr>"); // VETRI IMPEX - FOB (FC) should not show - sugg by Bala sir on 13/11/2019 - done by Chithra
                    }
                    else
                    {
                        sb.Append("<tr><td2FWB@123>Invoice Value(INR) </td> <td2@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].INDIVIDUAL_INVOICE_VALUE + "</td><td3@CS><b>DBK Value(INR) :</b> " + Rpt_Invoice_Details_list[inv].DBK_VALUE + "</td><td3@CS><b>FOB (FC) : </b>" + Rpt_Invoice_Details_list[inv].FOB_AMOUNT_FC + "</td></tr>");
                    }

                    //sb.Append("<tr><td colspan='10'><br/></td></tr>");
                    sb.Append("<tr10br@123>");
                    sb.Append("<tr><td2@CS></td><tdFWB@123>Rate</td><tdFWB@123>Currency</td><td6FWB@123>Amt</td></tr>");
                    sb.Append("<tr><td2FWB@123>Insurance</td><td>" + Rpt_Invoice_Details_list[inv].INSURANCE_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].INSURANCE_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].INSURANCE_CHARGES + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Freight</td><td>" + Rpt_Invoice_Details_list[inv].FREIGHT_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].FREIGHT_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].FREIGHT_CHARGES + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Commission</td><td>" + Rpt_Invoice_Details_list[inv].COMMISSION_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].COMMISSION_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].COMMISSION_CHARGES + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Discount</td><td>" + Rpt_Invoice_Details_list[inv].FOB_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].FOB_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].FOB_CHARGES + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Other Ded</td><td>" + Rpt_Invoice_Details_list[inv].OTHER_DEDUCTION_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].OTHER_DEDUCTION_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].OTHER_DEDUCTION_CHARGES + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Package Charges</td><td>" + Rpt_Invoice_Details_list[inv].PACKMISC_RATE + "</td><td>" + Rpt_Invoice_Details_list[inv].PACKMISC_CURRENCY + "</td><td6@CS>" + Rpt_Invoice_Details_list[inv].PACKMISC_CHARGES + "</td></tr>");
                    sb.Append("<tr10br@123>");
                    if (Rpt_Invoice_Details_list[inv].THIRDPARTY_NAME.ToString() != "")
                        sb.Append("<tr><td2FWB@123>Third Party Name</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].THIRDPARTY_NAME + "</td> </tr>");
                    if (Rpt_Invoice_Details_list[inv].THIRDPARTY_ADD1.ToString() != "")
                        sb.Append("<tr><td2FWB@123>Third Party Add1</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].THIRDPARTY_ADD1 + "</td> </tr>");
                    if (Rpt_Invoice_Details_list[inv].THIRDPARTY_ADD2.ToString() != "")
                        sb.Append("<tr><td2FWB@123>Third Party Add2</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].THIRDPARTY_ADD2 + "</td></tr>");
                    if (Rpt_Invoice_Details_list[inv].THIRDPARTY_CITY.ToString() != "")
                        sb.Append("<tr><td2FWB@123>City & Sub Division</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].THIRDPARTY_CITY + " " + Rpt_Invoice_Details_list[inv].T_PARTY_COUNTRY_SUB_DIV + "</td></tr>");
                    if (Rpt_Invoice_Details_list[inv].T_PARTY_COUNTRY_SUB_DIV.ToString() != "")
                        sb.Append("<tr><td2FWB@123>Country Code </td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].T_PARTY_COUNTRY_CODE + "</td><td2FWB@123>Pin Code </td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].T_PARTY_PIN + "</td></tr>");
                    if (Rpt_Invoice_Details_list[inv].AUTHORIZED_ECONOMIC_OPERATOR_CODE.ToString() != "")
                        sb.Append("<tr><td2FWB@123>AEO Operator Code</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].AUTHORIZED_ECONOMIC_OPERATOR_CODE + "</td><td2FWB@123>AEO Country</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].A_E_O_COUNTRY + "</td></tr>");
                    if (Rpt_Invoice_Details_list[inv].AUTHORIZED_ECONOMIC_OPERATOR.ToString() != "")
                        sb.Append("<tr><td2FWB@123>Terms Place </td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].TERMS_PLACE + "</td><td2FWB@123>AEO Role</td> <td3@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].AUTHORIZED_ECONOMIC_OPERATOR + "</td></tr>");
                    if (COMPANY_ID == "3416" || COMPANY_ID == "1" || COMPANY_ID == "10")
                    {
                        if (Rpt_Invoice_Details_list[inv].NOTIFY_NAME.ToString() != "")
                            sb.Append("<tr><td2FWB@123>Notify Name</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].NOTIFY_NAME + "</td> </tr>");
                        if (Rpt_Invoice_Details_list[inv].NOTIFY_ADDRESS_1.ToString() != "")
                            sb.Append("<tr><td2FWB@123>Notify Add1</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].NOTIFY_ADDRESS_1 + "</td> </tr>");
                        if (Rpt_Invoice_Details_list[inv].NOTIFY_ADDRESS_2.ToString() != "")
                            sb.Append("<tr><td2FWB@123>Notify Add2</td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].NOTIFY_ADDRESS_2 + "</td></tr>");
                        if (Rpt_Invoice_Details_list[inv].NOTIFY_ADDRESS_3.ToString() != "")
                            sb.Append("<tr><td2FWB@123>Notify Add3 </td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].NOTIFY_ADDRESS_3 + "</td></tr>");
                        if (Rpt_Invoice_Details_list[inv].NOTIFY_ADDRESS_COUNTRY.ToString() != "")
                            sb.Append("<tr><td2FWB@123>Notify Country </td> <td8@CS><b>:</b> " + Rpt_Invoice_Details_list[inv].NOTIFY_ADDRESS_COUNTRY + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<tr style='text-align:center'><td10FWB@123>ITEMS OF EXPORT</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    sb.Append("<trFWB@123><td>SLNo</td> <td>RITC</td><td8@CS>Description</td></tr>");
                    sb.Append("<trFWB@123><td>Quantity</td> <td>Units</td> <td colspan='2'>Item &nbsp; &nbsp;&nbsp;&nbsp;       Rate Per</td><td>Unit</td><td colspan='2'>Value (FC)</td><td>FOB (INR)</td><td>Sch Cd</td><td>Reward[Y/N]</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>Scheme Description</td> <td2@CS>End Use</td> <td>PMV</td> <td2@CS>Total PMV</td><td>IGST Pyt.Sts</td><td>IGST Val</td><td>IGST Amt</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    Load_Item_DetailsInd.Clear();

                    Load_Item_DetailsInd = Rpt_Item_Details_new_list.Where(p => p.INVOICE_SLNO == Rpt_Invoice_Details_list[inv].INVOICE_SLNO).ToList();

                    if (Load_Item_DetailsInd.Count > 0)
                    {
                        //  ************  start of Individual Item details  *****************//

                        for (int itm = 0; itm < Load_Item_DetailsInd.Count; itm++)
                        {

                            sb.Append("<tr><td>" + Load_Item_DetailsInd[itm].ITEM_SLNO + "</td><td>" + Load_Item_DetailsInd[itm].RITCNO + "</td><td8@CS>" + Load_Item_DetailsInd[itm].ITEM_DESCRIPTION.Replace("<", "&lt;").Replace(">", "&gt;") + "</td></tr>");
                            sb.Append("<tr><td>" + Load_Item_DetailsInd[itm].ITEM_QTY + "</td><td>" + Load_Item_DetailsInd[itm].ITEM_QTY_CODE + "</td><td colspan='2'>" + Load_Item_DetailsInd[itm].ITEM_UNIT_PRICE + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Load_Item_DetailsInd[itm].ITEM_PER + "</td> ");
                            sb.Append("<td>" + Load_Item_DetailsInd[itm].ITEM_QTY_CODE + "</td> <td colspan='2'>" + Load_Item_DetailsInd[itm].ITEM_AMOUNT + "</td> ");
                            sb.Append("<td>" + Load_Item_DetailsInd[itm].FOB_VALUE + "</td><td>" + Load_Item_DetailsInd[itm].ITEM_SCHEME_CODE + "</td><td>" + Load_Item_DetailsInd[itm].REWARD_POINTS + "</td></tr> ");
                            sb.Append("<tr><td2@CS>" + Load_Item_DetailsInd[itm].ITEM_SCHEME_DESC + "</td><td2@CS>" + Load_Item_DetailsInd[itm].ENDUSE_ITEM + "</td><td>" + Load_Item_DetailsInd[itm].ITEM_PMVVALUE + "</td> ");
                            sb.Append("<td2@CS>" + String.Format("{0:0.00}", Math.Round(Load_Item_DetailsInd[itm].TOTAL_PMVVALUE, 2)) + "</td><td>" + Load_Item_DetailsInd[itm].IGST_PAYMENT + "</td><td>" + Load_Item_DetailsInd[itm].TAXABLE_VALUE + "</td> ");


                            //sb.Append("<td2@CS>" + Load_Item_DetailsInd[itm].TOTAL_PMVVALUE + "</td><td>" + Load_Item_DetailsInd[itm].IGST_PAYMENT + "</td><td>" + Load_Item_DetailsInd[itm].TAXABLE_VALUE + "</td> ");
                            sb.Append("<td>" + Load_Item_DetailsInd[itm].IGST_AMT + "</td></tr> ");
                        }

                        // FOB_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.FOB_VALUE)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.AGGREGATE_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.SAFE_GUARD_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.PRODUCT_OTHER_DUTY_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.CESS_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.CVD_CEC_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.CVD_CHEC_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.SCHED11_TOTAL)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.TOTAL_SOCIAL_WELFARE)) + Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.ADDLTIONAL_DUTY_TOTAL));

                        //hide on 04-10-2024 for Elite Ship eri02745
                        //FOB_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.FOB_VALUE));
                        FOB_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.ACTUAL_ITEM_FOB_VALUE));//Newly added on 04-10-2024

                        Tax_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.TAXABLE_VALUE));
                        PMV_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.TOTAL_PMVVALUE));
                        IGST_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.IGST_AMT));

                        QTY_total = Load_Item_DetailsInd.Sum(item => Convert.ToDouble(item.ITEM_QTY));


                        //=format(Round(val(Sum(Fields!TAXABLE_VALUE.Value)),1),"0.00") //=format(Round(val(Sum(Fields!TOTAL_PMVVALUE.Value)),1),"0.00") //=format(Round(val(Sum(Fields!IGST_AMT.Value)),1),"0.00")


                        //Grand_FOB_total = Grand_FOB_total + FOB_total;
                        //Grand_Tax_total = Grand_Tax_total + Tax_total;
                        //Grand_PMV_total = Grand_PMV_total + PMV_total;
                        //Grand_IGST_total = Grand_IGST_total + IGST_total;

                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        if (COMPANY_ID == "517")
                        {
                            sb.Append("<tr><td colspan='2' style='text-align:left'> " + "" + "</td><td colspan='4' style='text-align:right'>Total FOB : " + String.Format("{0:0.00}", Math.Round(FOB_total, 2)) + "</td><td></td><td3@CS>Total IGST Val : " + String.Format("{0:0.00}", Math.Round(Tax_total, 2)) + "</td></tr> ");
                        }
                        else
                        {
                            sb.Append("<tr><td colspan='2' style='text-align:left'>Total QTY : " + String.Format("{0:0.00}", Math.Round(QTY_total, 2)) + "</td><td colspan='4' style='text-align:right'>Total FOB : " + String.Format("{0:0.00}", Math.Round(FOB_total, 2)) + "</td><td></td><td3@CS>Total IGST Val : " + String.Format("{0:0.00}", Math.Round(Tax_total, 2)) + "</td></tr> ");
                        }
                        sb.Append("<tr><td colspan='6' style='text-align:right'>Total PMV : " + String.Format("{0:0.00}", Math.Round(PMV_total, 2)) + "</td><td></td><td3@CS>Total IGST Amt : " + String.Format("{0:0.00}", Math.Round(IGST_total, 2)) + "</td></tr> ");

                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                        //  ************  end of Individual Item details  *****************//
                    }
                }
                //***************  End of invoice ************************ //


                //  ************   QUOTA details  *****************//  take direct drawback details fro DB & remover the list add
                if (ds.Tables[14].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>QUOTA DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Sl No</td><td colspan='2'>Agency Code</td> <td colspan='2'>Agency Name</td><td colspan='2'>Alloc. No</td><td>Expiry Date</td><td>Inv Sl No</td><td>Item Sl No</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[14].Rows.Count - 1; i++)
                    {
                        sb.Append("<tr><td>" + (i + 1).ToString() + "</td><td2@CS>" + ds.Tables[14].Rows[i]["AGENCY_CODE"] + "</td><td2@CS>" + ds.Tables[14].Rows[i]["AGENCY_NAME"] + "</td><td2@CS>" + ds.Tables[14].Rows[i]["ALLOCATION_NO"] + "</td><td>" + ds.Tables[14].Rows[i]["EXPIRY_DATE1"] + "</td><td>" + ds.Tables[14].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[14].Rows[i]["ITEM_SL_NO"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  DRAWBACK details  *****************//

                if (Rpt_DrawBack_Details_list.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>DRAWBACK PAYABLE</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Invsl</td><td>Itemsl</td> <td>DBK SNo</td><td colspan='2'>Cus.Rate</td><td2@CS>DBK Adv</td><td>DBK Qty</td><td colspan='3'>DBK.Amt(INR)</td></tr>");
                    sb.Append("<trFWB@123><td3@CS></td><td colspan='2'>Exc.Rate</td><td2@CS>DBK RateSpl</td><td colspan='8'>Unit</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < Rpt_DrawBack_Details_list.Count; i++)
                    {
                        sb.Append("<tr><td>" + Rpt_DrawBack_Details_list[i].INVOICE_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].ITEM_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_SLNO + "</td><td colspan='2'>" + Rpt_DrawBack_Details_list[i].DRAWBACK_CUSTOMS + "</td>");
                        sb.Append("<td2@CS>" + Rpt_DrawBack_Details_list[i].DRAWBACK_RATE + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_QTY + "</td><td>" + Rpt_DrawBack_Details_list[i].DBK_VALUE + "</td><td2@CS>" + "</td></tr>");
                        sb.Append("<tr><td3@CS></td><td  colspan='2'>" + Rpt_DrawBack_Details_list[i].DRAWBACK_EXCISE + "</td><td colspan='2'>" + Rpt_DrawBack_Details_list[i].DRAWBACK_CAPS + "</td><td colspan='8' style='text-align:left'>" + Rpt_DrawBack_Details_list[i].DRAWBACK_UNIT + "</td></tr>");
                    }

                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<tr><td colspan='8'></td><td colspan='1' style='text-align:left'> " + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.DBK_VALUE) ? "0" : item.DBK_VALUE)) + "</td><td colspan='3' ></td></tr> ");
                    //sb.Append("<tr><td7SAR@123> " + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.DBK_VALUE) ? "0" : item.DBK_VALUE))  + "</td></tr> ");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                }


                //  ************  RoSCTL details  *****************//

                if (Rpt_DrawBack_Details_list.Count > 0)
                {
                    string ROSL = "YES";
                    for (int i = 0; i < Rpt_DrawBack_Details_list.Count; i++)
                    {
                        if (Rpt_DrawBack_Details_list[i].SCHEME_CODE.Substring(0, 2) == "60" || Rpt_DrawBack_Details_list[i].SCHEME_CODE.Substring(0, 2) == "61"
                             || Rpt_DrawBack_Details_list[i].SCHEME_CODE.Substring(0, 2) == "64" || Rpt_DrawBack_Details_list[i].SCHEME_CODE.Substring(0, 2) == "65")
                        {
                            if (ROSL == "YES")
                            {
                                sb.Append("<tr style='text-align:center'><td10FWB@123>ROSCTL PAYABLE</td></tr>");
                                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                                sb.Append("<trFWB@123><td>Invsl</td><td>Itemsl</td> <td>DBK SNo</td><td colspan='2'>State.Lev.Rate</td><td2@CS>Central.Lev.Rate</td><td>Qty</td><td  colspan='3'>ROSCTL Amt(INR)</td></tr>");
                                sb.Append("<trFWB@123><td3@CS></td><td colspan='2'>State.Lev.Amt</td><td2@CS>Central.Lev.Amt</td><td colspan='8'>Unit</td></tr>");
                                sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                                ROSL = ""; //Update
                            }
                            sb.Append("<tr><td>" + Rpt_DrawBack_Details_list[i].INVOICE_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].ITEM_SLNO + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_SLNO + "</td><td colspan='2'>" + Rpt_DrawBack_Details_list[i].STATE_LEVEL_ADV_RATE + "</td>");
                            sb.Append("<td2@CS>" + Rpt_DrawBack_Details_list[i].CENTRAL_LEVEL_ADV_RATE + "</td><td>" + Rpt_DrawBack_Details_list[i].DRAWBACK_QTY + "</td><td>" + Rpt_DrawBack_Details_list[i].TOT_LEV_AMT + "</td><td2@CS>" + "</td></tr>");
                            sb.Append("<tr><td3@CS></td><td colspan='2'>" + Rpt_DrawBack_Details_list[i].STATE_LEVEL_ADV_AMT + "</td><td  colspan='2'>" + Rpt_DrawBack_Details_list[i].CENTRAL_LEVEL_ADV_AMT + "</td><td colspan='8' style='text-align:left'>" + Rpt_DrawBack_Details_list[i].DRAWBACK_UNIT + "</td></tr>");
                        }
                    }
                    if (ROSL == "") //Update
                    {
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        sb.Append("<tr><td colspan='8'></td><td colspan='1' style='text-align:left'> " + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.TOT_LEV_AMT) ? "0" : item.TOT_LEV_AMT)) + "</td><td colspan='3' ></td></tr> ");
                        //sb.Append("<tr><td7SAR@123> " + Rpt_DrawBack_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.DBK_VALUE) ? "0" : item.DBK_VALUE))  + "</td></tr> ");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    }
                }


                //  ************  RODTEP details  *****************//
                if (Rpt_RODTEP_Details_list.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>RODTEP PAYABLE</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Invsl</td><td>Itemsl</td> <td>Tariff Item</td><td colspan='2'>RODTEP Rate</td><td>RODTEP Cap</td><td>RODTEP Qty</td><td>RODTEP Unit</td><td colspan='3'>RODTEP.Amt(INR)</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < Rpt_RODTEP_Details_list.Count; i++)
                    {
                        sb.Append("<tr><td>" + Rpt_RODTEP_Details_list[i].INVOICE_SLNO + "</td><td>" + Rpt_RODTEP_Details_list[i].ITEM_SLNO + "</td><td>" + Rpt_RODTEP_Details_list[i].RODTEP_TARIFF + "</td><td colspan='2'>" + Rpt_RODTEP_Details_list[i].RODTEP_RATE + "</td>");
                        sb.Append("<td>" + Rpt_RODTEP_Details_list[i].RODTEP_CAP + "</td><td>" + Rpt_RODTEP_Details_list[i].RODTEP_QTY + "</td><td>" + Rpt_RODTEP_Details_list[i].RODTEP_UQC + "</td><td>" + Rpt_RODTEP_Details_list[i].RODTEP_VALUE + "</td><td2@CS>" + "</td></tr>");
                    }

                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<tr><td colspan='8'></td><td colspan='1' style='text-align:left'> " + Rpt_RODTEP_Details_list.Sum(item => Convert.ToDouble(string.IsNullOrEmpty(item.RODTEP_VALUE) ? "0" : item.RODTEP_VALUE)) + "</td><td colspan='3' ></td></tr> ");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                }


                //  ************  ACCESSORY details  *****************//
                if (ds.Tables[2].Rows.Count > 0 && ds.Tables[23].Rows.Count > 0)
                {
                    if (ds.Tables[23].Rows[0]["CntAcc"].ToString() != "0")  // here we take the count from item table with filtering ITEM_ACCESSORIES_DESC is not empty
                    {
                        sb.Append("<tr style='text-align:center'><td10FWB@123>ACCESSORY CERTIFICATE DETAILS</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td> <td8@CS>Item Description</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            if (ds.Tables[2].Rows[i]["ITEM_ACCESSORIES_DESC"] != "")
                            {
                                sb.Append("<tr><td>" + ds.Tables[2].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[2].Rows[i]["ITEM_SLNO"] + "</td><td8@CS>" + ds.Tables[2].Rows[i]["ITEM_ACCESSORIES_DESC"] + "</td></tr>");
                            }

                        }
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    }
                }

                //  ************ LICENSE PARTICULARS  *****************//
                if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "480" || Connection.COMPANYID() == "1011" || Connection.COMPANYID() == "1019" || Connection.COMPANYID() == "1176" || Connection.COMPANYID() == "3267")
                {
                    if (ds.Tables[22].Rows.Count > 0)
                    {

                        var FullName1 = from DataRow drr in ds.Tables[22].AsEnumerable()
                                        where drr.Field<string>("SCHEME") == "DEEC"
                                        select drr;

                        DataView dvv_DEEC = FullName1.AsDataView();

                        if (dvv_DEEC.Count > 0)
                        {
                            DataTable dt_DEEC = FullName1.CopyToDataTable();
                            sb.Append("<tr style='text-align:center'><td10FWB@123>DEEC - LICENSE PARTICULARS</td></tr>");
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            sb.Append("<trFWB@123><td>Inv Sl</td><td>Item Sl</td> <td>Scheme</td><td2@CS>Regn No</td><td>Regn Date</td><td>SNo-E</td><td>Exp Qty</td><td>Unit</td><td>Imp / Ind</td></tr>");
                            sb.Append("<trFWB@123><td6@CS>Description</td><td>SNo-C</td> <td>Imp Qty</td><td colspan='2'>Unit</td></tr>");
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            for (int i = 0; i < dt_DEEC.Rows.Count; i++)
                            {
                                sb.Append("<tr><td>" + dt_DEEC.Rows[i]["INV_SL_NO"] + "</td><td>" + dt_DEEC.Rows[i]["ITEM_SL_NO"] + "</td><td>" + dt_DEEC.Rows[i]["SCHEME"] + "</td><td2@CS>" + dt_DEEC.Rows[i]["LICENSE_NO"] + "</td><td>" + dt_DEEC.Rows[i]["LICENSE_DATE"] + "</td> ");
                                sb.Append("<td>" + dt_DEEC.Rows[i]["LICENSE_E_SL_NO"] + "</td><td>" + dt_DEEC.Rows[i]["LICENSE_EXP_QTY"] + "</td>");
                                sb.Append("<td>" + dt_DEEC.Rows[i]["LICENSE_EXP_UNIT"] + "</td><td>" + dt_DEEC.Rows[i]["LICENSE_IMP_TYPENew"] + "</td></tr>");

                                if (Connection.Get_User_Exp_Settings_Job_Edit("CHKLIST_LICENSE_DESC") == "E")
                                {
                                    sb.Append("<tr><td6@CS>" + dt_DEEC.Rows[i]["LICENSE_IMP_DESC"] + "</td>");
                                }
                                else
                                {
                                    sb.Append("<tr><td6@CS></td>");
                                }

                                sb.Append("<td>" + dt_DEEC.Rows[i]["LICENSE_IMP_ITEM_SL_NO"] + "</td><td>" + dt_DEEC.Rows[i]["LICENSE_IMP_QTY"] + "</td><td2@CS>" + dt_DEEC.Rows[i]["LICENSE_IMP_UNIT"] + "</td></tr>");
                            }
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        }

                        //-----------------------EPCG----------------------------
                        var FullName2 = from DataRow drr in ds.Tables[22].AsEnumerable()
                                        where drr.Field<string>("SCHEME") == "EPCG"
                                        select drr;

                        DataView dvv_EPCG = FullName2.AsDataView();

                        if (dvv_EPCG.Count > 0)
                        {
                            DataTable dt_EPCG = FullName2.CopyToDataTable();
                            sb.Append("<tr style='text-align:center'><td10FWB@123>EPCG - LICENSE PARTICULARS</td></tr>");
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            sb.Append("<trFWB@123><td>Inv Sl</td><td>Item Sl</td> <td>Scheme</td><td2@CS>Regn No</td><td>Regn Date</td><td>SNo-E</td><td>Exp Qty</td><td>Unit</td><td>Imp / Ind</td></tr>");
                            sb.Append("<trFWB@123><td6@CS>Description</td><td>SNo-C</td> <td>Imp Qty</td><td colspan='2'>Unit</td></tr>");
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            for (int i = 0; i < dt_EPCG.Rows.Count; i++)
                            {
                                sb.Append("<tr><td>" + dt_EPCG.Rows[i]["INV_SL_NO"] + "</td><td>" + dt_EPCG.Rows[i]["ITEM_SL_NO"] + "</td><td>" + dt_EPCG.Rows[i]["SCHEME"] + "</td><td2@CS>" + dt_EPCG.Rows[i]["LICENSE_NO"] + "</td><td>" + dt_EPCG.Rows[i]["LICENSE_DATE"] + "</td> ");
                                sb.Append("<td>" + dt_EPCG.Rows[i]["LICENSE_E_SL_NO"] + "</td><td>" + dt_EPCG.Rows[i]["LICENSE_EXP_QTY"] + "</td>");
                                sb.Append("<td>" + dt_EPCG.Rows[i]["LICENSE_EXP_UNIT"] + "</td><td>" + dt_EPCG.Rows[i]["LICENSE_IMP_TYPENew"] + "</td></tr>");

                                if (Connection.Get_User_Exp_Settings_Job_Edit("CHKLIST_LICENSE_DESC") == "E")
                                {
                                    sb.Append("<tr><td6@CS>" + dt_EPCG.Rows[i]["LICENSE_IMP_DESC"] + "</td>");
                                }
                                else
                                {
                                    sb.Append("<tr><td6@CS></td>");
                                }

                                sb.Append("<td>" + dt_EPCG.Rows[i]["LICENSE_IMP_ITEM_SL_NO"] + "</td><td>" + dt_EPCG.Rows[i]["LICENSE_IMP_QTY"] + "</td><td2@CS>" + dt_EPCG.Rows[i]["LICENSE_IMP_UNIT"] + "</td></tr>");
                            }
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        }
                    }
                }
                else
                {
                    if (ds.Tables[22].Rows.Count > 0)
                    {
                        sb.Append("<tr style='text-align:center'><td10FWB@123>LICENSE PARTICULARS</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        sb.Append("<trFWB@123><td>Inv Sl</td><td>Item Sl</td> <td>Scheme</td><td2@CS>Regn No</td><td>Regn Date</td><td>SNo-E</td><td>Exp Qty</td><td>Unit</td><td>Imp / Ind</td></tr>");
                        sb.Append("<trFWB@123><td6@CS>Description</td><td>SNo-C</td> <td>Imp Qty</td><td colspan='2'>Unit</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        for (int i = 0; i < ds.Tables[22].Rows.Count; i++)
                        {
                            sb.Append("<tr><td>" + ds.Tables[22].Rows[i]["INV_SL_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["ITEM_SL_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["SCHEME"] + "</td><td2@CS>" + ds.Tables[22].Rows[i]["LICENSE_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["LICENSE_DATE"] + "</td> ");
                            sb.Append("<td>" + ds.Tables[22].Rows[i]["LICENSE_E_SL_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["LICENSE_EXP_QTY"] + "</td>");
                            sb.Append("<td>" + ds.Tables[22].Rows[i]["LICENSE_EXP_UNIT"] + "</td><td>" + ds.Tables[22].Rows[i]["LICENSE_IMP_TYPENew"] + "</td></tr>");

                            if (Connection.Get_User_Exp_Settings_Job_Edit("CHKLIST_LICENSE_DESC") == "E")
                            {
                                sb.Append("<tr><td6@CS>" + ds.Tables[22].Rows[i]["LICENSE_IMP_DESC"] + "</td>");
                            }
                            else
                            {
                                sb.Append("<tr><td6@CS></td>");
                            }

                            sb.Append("<td>" + ds.Tables[22].Rows[i]["LICENSE_IMP_ITEM_SL_NO"] + "</td><td>" + ds.Tables[22].Rows[i]["LICENSE_IMP_QTY"] + "</td><td2@CS>" + ds.Tables[22].Rows[i]["LICENSE_IMP_UNIT"] + "</td></tr>");
                        }
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    }
                }

                //  ************ JOB WORK DETAILS  *****************//
                if (ds.Tables[6].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>JOB WORK DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv Sl No</td><td>Item Sl No</td> <td>BE No</td><td>BE Date</td><td>BE Inv Slno</td><td>BE Inv No</td><td>BE ItemNo</td><td>BE Port</td><td>BE Qty</td><td>Unit</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[6].Rows.Count; i++)
                    {
                        sb.Append("<tr><td>" + ds.Tables[6].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[6].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[6].Rows[i]["BE_NO"] + "</td><td>" + ds.Tables[6].Rows[i]["BE_DATE"] + "</td>");
                        sb.Append("<td>" + ds.Tables[6].Rows[i]["BE_INV_SLNO"] + "</td><td>" + ds.Tables[6].Rows[i]["BE_INV_NO"] + "</td><td>" + ds.Tables[6].Rows[i]["BE_ITEM_NO"] + "</td>");
                        sb.Append("<td>" + ds.Tables[6].Rows[i]["BE_PORT_CODE"] + "</td><td>" + ds.Tables[6].Rows[i]["QTY"] + "</td><td>" + ds.Tables[6].Rows[i]["UNIT"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }


                //  ************  start of Cess WORK DETAILS  *****************//


                /* hide on 27-05-2022
                 if (ds.Tables[13].Rows.Count > 0)
                 {
                     FOB_VALUE = Math.Round(SUM_TOTAL_FOB_VALUE, 2);
                     double grand_cessTotal = 0.00;
                     cess_amountNew = 0.00;
                     sb.Append("<tr style='text-align:center'><td10FWB@123>CESS PAYABLE</td></tr>");
                     sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                     sb.Append("<trFWB@123><td>Inv No</td><td>Item No</td> <td2@CS>Cess Sl No</td><td2@CS>Tariff Val</td><td>Cess Rate</td><td>Cess Qty</td><td2@CS>Cess Amt(INR)</td></tr>");
                     sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                     for (int i = 0; i < ds.Tables[13].Rows.Count; i++)
                     {

                         if ((ds.Tables[13].Rows[i]["CESS_TARIFF_VALUE"] == "") && (ds.Tables[13].Rows[i]["CESS_RATE"] != ""))
                         {
                             //string cess_amount = Convert.ToString(Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(CESS_RATE) / 100);
                             //cess_amount = Convert.ToString(Math.Round(Convert.ToDouble(cess_amount), 2).ToString("0.00"));
                             //CESS_AMT = Convert.ToDouble(cess_amount);

                             cess_amountNew = (Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(ds.Tables[13].Rows[i]["CESS_RATE"]) / 100);

                         }
                         else
                         {
                             if (ds.Tables[13].Rows[i]["CESS_TARIFF_VALUE"] != "")
                             {
                                 //string cess_amount = Convert.ToString(Convert.ToDouble(CESS_TARIFF_VALUE) * Convert.ToDouble(CESS_RATE) / 100);
                                 //cess_amount = Convert.ToString(Convert.ToDouble(cess_amount) * Convert.ToDouble(CESS_ITEM_QTY));
                                 //cess_amount = Convert.ToString(Math.Round(Convert.ToDouble(cess_amount), 2).ToString("0.00"));
                                 //CESS_AMT = Convert.ToDouble(cess_amount);

                                 cess_amountNew = Convert.ToDouble(ds.Tables[13].Rows[i]["CESS_ITEM_QTY"]) * (Convert.ToDouble(ds.Tables[13].Rows[i]["CESS_TARIFF_VALUE"]) * Convert.ToDouble(ds.Tables[13].Rows[i]["CESS_RATE"])) / 100;
                             }
                         }
                         grand_cessTotal = grand_cessTotal + cess_amountNew;

                         sb.Append("<tr><td>" + ds.Tables[13].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[13].Rows[i]["ITEM_SLNO"] + "</td><td2@CS>" + ds.Tables[13].Rows[i]["CESS_SLNO"] + "</td> ");
                         sb.Append("<td2@CS>" + ds.Tables[13].Rows[i]["CESS_TARIFF_VALUE"] + "</td><td>" + ds.Tables[13].Rows[i]["CESS_RATE"] + "</td><td>" + ds.Tables[13].Rows[i]["CESS_ITEM_QTY"] + "</td>");
                         sb.Append("<td2@CS>" + cess_amountNew + "</td></tr>");

                         cess_amountNew = 0.00;
                     }
                     sb.Append("<tr><td colspan='8'>Total Cess </td><td2@CS> " + grand_cessTotal + " </td></tr>");
                     sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                 }
                 */

                if (Rpt_CESS_Details_list.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>CESS PAYABLE</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv No</td><td>Item No</td> <td2@CS>Cess Sl No</td><td2@CS>Tariff Val</td><td>Cess Rate</td><td>Cess Qty</td><td2@CS>Cess Amt(INR)</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    for (int i = 0; i < Rpt_CESS_Details_list.Count; i++)
                    {
                        sb.Append("<tr><td>" + Rpt_CESS_Details_list[i].INVOICE_SLNO + "</td><td>" + Rpt_CESS_Details_list[i].ITEM_SLNO + "</td><td2@CS>" + Rpt_CESS_Details_list[i].CESS_SLNO + "</td> ");
                        sb.Append("<td2@CS>" + Rpt_CESS_Details_list[i].CESS_TARIFF_VALUE + "</td><td>" + Rpt_CESS_Details_list[i].CESS_RATE + "</td><td>" + Rpt_CESS_Details_list[i].CESS_ITEM_QTY + "</td>");
                        sb.Append("<td2@CS>" + Rpt_CESS_Details_list[i].CESS_AMOUNT + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<tr><td colspan='8'></td><td colspan='1' style='text-align:left'> " + Rpt_CESS_Details_list.Sum(item1 => Convert.ToDouble(string.IsNullOrEmpty(item1.CESS_AMOUNT) ? "0" : item1.CESS_AMOUNT)) + "</td><td colspan='3' ></td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                }


                if (ds.Tables[2].Rows.Count > 0)
                {
                    if (ds.Tables[23].Rows[0]["CntIECode"].ToString() != "0")  // here we take the count from item table with filtering ITEM_IECCODE is not empty
                    {
                        sb.Append("<tr style='text-align:center'><td10FWB@123>THIRD PARTY DETAILS</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        sb.Append("<trFWB@123><td>Inv SlNo</td><td2@CS>Item No</td> <td2@CS>IEC</td><td>Br.SlNo</td><td4@CS>Exp Name</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            sb.Append("<tr><td>" + ds.Tables[2].Rows[i]["INVOICE_SLNO"] + "</td><td2@CS>" + ds.Tables[2].Rows[i]["ITEM_SLNO"] + "</td><td2@CS>" + ds.Tables[2].Rows[i]["ITEM_IECCODE"] + "</td><td>" + ds.Tables[2].Rows[i]["BR_SLNO"] + "</td><td4@CS>" + ds.Tables[2].Rows[i]["ITEM_EXPORTER_NAME"] + "</td></tr>");
                            if (ds.Tables[2].Rows[i]["ADDRESS1"] != "")
                                sb.Append("<tr><td2@CS><b>Address</b></td><td8@CS><b>:</b> " + ds.Tables[2].Rows[i]["ADDRESS1"] + " " + ds.Tables[2].Rows[i]["ADDRESS2"] + " " + ds.Tables[2].Rows[i]["ADDRESS3"] + " </td></tr>");
                            if (ds.Tables[2].Rows[i]["ADDRESS4"] != "")
                                sb.Append("<tr><td2@CS><b>City</b></td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["ADDRESS4"] + "</td><td><b>Pincode</b></td><td4@CS><b>:</b> " + ds.Tables[2].Rows[i]["ADDRESS5"] + "</td></tr>");
                            if (ds.Tables[2].Rows[i]["GSTN_TYPE"] != "")
                                sb.Append("<tr><td2@CS><b>GSTN Type</b></td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["GSTN_TYPE"] + "</td><td><b>GSTN ID</b></td><td4@CS><b>:</b> " + ds.Tables[2].Rows[i]["GSTN_ID"] + "</td></tr>");
                        }

                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    }
                }
                //  ************  End of THIRD PARTY DETAILS  *****************//


                //  ************  start of AR4 DETAILS  *****************// ds.Tables[9]
                if (ds.Tables[9].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>AR4 DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv No</td><td>Item</td> <td>AR4 No</td><td>AR4 Date</td><td>Commission</td><td>Division</td><td>Range</td><td3@CS>Remarks</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[9].Rows.Count; i++)
                    {
                        sb.Append("<tr><td>" + ds.Tables[9].Rows[i]["AR4_INVOICE_SLNO"] + "</td><td>" + ds.Tables[9].Rows[i]["AR4_ITEM_NO"] + "</td><td>" + ds.Tables[9].Rows[i]["AR4_NO"] + "</td><td>" + ds.Tables[9].Rows[i]["AR4_DATE"] + "</td> ");
                        sb.Append("<td>" + ds.Tables[9].Rows[i]["AR4_COMMISSION_RATE"] + "</td><td>" + ds.Tables[9].Rows[i]["AR4_DIVISION"] + "</td><td>" + ds.Tables[9].Rows[i]["AR4_RANGE"] + "</td><td3@CS>" + ds.Tables[9].Rows[i]["AR4_REMARKS"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of EOU DETAILS  *****************// ds.Tables[7]
                if (ds.Tables[7].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>EOU Details</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    string ANNEX_ADDRESS4, ANNEX_ADDRESS5;
                    string[] s1;


                    for (int i = 0; i < ds.Tables[7].Rows.Count; i++)
                    {
                        ANNEX_ADDRESS4 = ds.Tables[7].Rows[0]["ANNEX_ADDRESS4"].ToString();
                        s1 = ANNEX_ADDRESS4.Split(new string[] { "--" }, StringSplitOptions.None);
                        ANNEX_ADDRESS4 = s1[0].ToString();
                        if (ds.Tables[7].Rows[0]["ANNEX_ADDRESS4"].ToString().Contains("--"))
                        {
                            ANNEX_ADDRESS5 = s1[1].ToString();
                        }
                        else
                        {
                            ANNEX_ADDRESS5 = "";
                        }


                        sb.Append("<tr><td2FWB@123>IEC of EOU </td><td3@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_IECCODE"] + "</td><td2FWB@123>Br Sl.No </td><td3@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_BR_SLNO"] + "</td></tr>");
                        sb.Append("<tr><td2FWB@123>Name of EOU</td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_EXPORTERNAME"] + "</td></tr>");
                        sb.Append("<tr><td2FWB@123>Address of EOU </td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_ADDRESS1"] + "</td></tr>");
                        sb.Append("<tr><td2FWB@123></td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_ADDRESS2"] + "</td></tr>");
                        sb.Append("<tr><td2FWB@123>City</td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_ADDRESS3"] + "</td></tr>");
                        //sb.Append("<tr><td2FWB@123>State</td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_ADDRESS4New"].ToString().Replace("--","")  + "</td></tr>");
                        //sb.Append("<tr><td2FWB@123>PIN</td><td8@CS><b>:</b> " + ds.Tables[7].Rows[i]["ANNEX_ADDRESS5New"] + "</td></tr>");

                        sb.Append("<tr><td2FWB@123>State</td><td8@CS><b>:</b> " + ANNEX_ADDRESS4 + "</td></tr>");
                        sb.Append("<tr><td2FWB@123>PIN</td><td8@CS><b>:</b> " + ANNEX_ADDRESS5 + "</td></tr>");

                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of ITEM - SW MANUFACTURER DETAILS  *****************//
                if (ds.Tables[2].Rows.Count > 0)  // need to check here ACCESSORY_STATUS <>""
                {
                    if (ds.Tables[23].Rows[0]["CntAccStatus"].ToString() != "0")  // here we take the count from item table with filtering ITEM_IECCODE is not empty
                    {
                        sb.Append("<tr style='text-align:center'><td10FWB@123>ITEM - SW MANUFACTURER DETAILS</td></tr>");
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            //if (ds.Tables[2].Rows[i]["M_P_GROWER_CODE"].ToString() != "" || ds.Tables[2].Rows[i]["M_P_GROWER_ADD1"].ToString() != "")
                            //{
                            sb.Append("<tr><td2FWB@123>Invoice  SlNo</td><td>:" + ds.Tables[2].Rows[i]["INVOICE_SLNO"] + "</td><tdFWB@123>Item SlNo</td><td>:" + ds.Tables[2].Rows[i]["ITEM_SLNO"] + "</td><td2FWB@123>Manufacture Code Type</td><td3@CS>:" + ds.Tables[2].Rows[i]["MANUFACTURER_PRODUCER"] + "</td></tr>");
                            if (ds.Tables[2].Rows[i]["M_P_GROWER_CODE"].ToString() != "")
                                sb.Append("<tr><td2FWB@123>Grower Code </td><td8@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_CODE"] + "</td></tr>");
                            if (ds.Tables[2].Rows[i]["M_P_GROWER_ADD1"].ToString() != "")
                                sb.Append("<tr><td2FWB@123>Address 1</td><td8@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_ADD1"] + "</td></tr>");
                            sb.Append("<tr><td2FWB@123>Address 2</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_ADD2"] + "</td><td2FWB@123>City</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_CITY"] + "</td></tr>");
                            sb.Append("<tr><td2FWB@123>Sub Division</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_COUNTRY_SUBDIV"] + "</td><td2FWB@123>Pin Code</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_PIN"] + "</td></tr>");
                            sb.Append("<tr><td2FWB@123>Mnfctr Country</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["M_P_GROWER_COUNTRY"] + "</td><td2FWB@123>Source State </td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["SOURCE_STATE"] + "</td></tr>");
                            sb.Append("<tr><td2FWB@123>Transit Country</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["TRANSIT_COUNTRY"] + "</td><td2FWB@123>Accessory Status</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["ACCESSORY_STATUS"] + "</td></tr>");
                            sb.Append("<tr><td2FWB@123>HAWB No</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["HAWB_NO"] + "</td><td2FWB@123>Total Packages</td><td3@CS><b>:</b> " + ds.Tables[2].Rows[i]["TOTAL_PKGS"] + "</td></tr>");
                            //}
                        }
                        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    }
                }


                //  ************ ITEM - OTHER DETAILS  *****************//

                if (ds.Tables[24].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>ITEM - OTHER DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td> <td>SQC Qty</td><td>SQC Unit</td><td2@CS>State of Origin</td><td2@CS>District of Origin</td><td>Comp.CessAmt(INR)</td><td>PTA/FTA</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[24].Rows.Count; i++)
                    {
                        sb.Append("<tr><td>" + ds.Tables[24].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[24].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[24].Rows[i]["SQC"] + "</td><td>" + ds.Tables[24].Rows[i]["INFO_UQC"] + "</td><td2@CS>" + ds.Tables[24].Rows[i]["STATE"] + "</td>");
                        sb.Append("<td2@CS>" + ds.Tables[24].Rows[i]["DISTRICT"] + "</td><td>" + ds.Tables[24].Rows[i]["GCESS"] + "</td><td>" + ds.Tables[24].Rows[i]["PTA"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of CONTAINER DETAILS   *****************// ds.Tables[10]

                if (ds.Tables[10].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>CONTAINER DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>Container No</td><td>Size</td><td>Type</td><td2@CS>Seal No</td><td2@CS>Type Indicator</td><td2@CS>Mov.Doc.Type</td></tr>");
                    sb.Append("<trFWB@123><td2@CS></td><td></td><td></td><td2@CS>Seal Date</td><td2@CS>Seal Device ID</td><td2@CS>Mov.Doc.Number</td></tr>");

                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[10].Rows.Count; i++)
                    {
                        sb.Append("<tr><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_CONTAINERNO"] + "</td><td>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_SIZE"] + "</td><td>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_TYPE"] + "</td><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_EXCISE_SEALNO"] + "</td>");
                        sb.Append("<td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"] + "</td><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_DOC_TYPE"] + "</td></tr>");
                        sb.Append("<tr><td2@CS>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_SEAL_DATE"] + "</td>");
                        sb.Append("<td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_SEAL_DEVICEID"] + "</td><td2@CS>" + ds.Tables[10].Rows[i]["ANNEX_SEA_CON_DOC_NUMBER"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }
                //  ************  End of CONTAINER DETAILS  *****************//



                //  ************  start of VESSEL DETAILS   *****************//
                if (ds.Tables[11].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>VESSEL DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    sb.Append("<trFWB@123><td2@CS>Factory Stuffed</td><td>Sample Acc.</td><td2@CS>    Vessel Name & Date</td><td2@CS>Voyage No</td><td3@CS>Factory Address</td</tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[11].Rows.Count; i++)
                    {
                        sb.Append("<tr><td2@CS>" + ds.Tables[11].Rows[i]["ANNEX_SEA_FAC_STUFFED"] + "</td><td>" + ds.Tables[11].Rows[i]["ANNEX_SEA_SAMPLE_ACCOM"] + "</td><td2@CS>" + ds.Tables[11].Rows[i]["ANNEX_SEA_VESSELNO"] + " " + ds.Tables[11].Rows[i]["ANNEX_SEA_VESSEL_DATE"] + "</td><td2@CS>" + ds.Tables[11].Rows[i]["ANNEX_SEA_VOYAGENO"] + "</td>");
                        sb.Append("<td3@CS>" + ds.Tables[11].Rows[i]["ANNEX_SEA_FACTORY_ADD"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of PACKING  DETAILS   *****************// ds.Tables[12]
                if (ds.Tables[12].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>PACKING DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>Package From</td><td2@CS>Package To</td> <td2@CS>Package Kind</td><td2@CS>From Desc</td><td2@CS>To Desc</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[12].Rows.Count; i++)
                    {
                        sb.Append("<tr><td2@CS>" + ds.Tables[12].Rows[i]["ANNEX_SEA_PACK_FROM"] + "</td><td2@CS>" + ds.Tables[12].Rows[i]["ANNEX_SEA_PACK_TO"] + "</td><td2@CS>" + ds.Tables[12].Rows[i]["ANNEX_SEA_PACK_PACKAGETYPE"] + "</td>");
                        sb.Append("<td2@CS>" + ds.Tables[12].Rows[i]["ANNEX_SEA_PACK_FROMDESC"] + "</td><td2@CS>" + ds.Tables[12].Rows[i]["ANNEX_SEA_PACK_TODESC"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of STR   DETAILS   *****************//

                if (Rpt_STR_Details_list.Count > 0)
                {
                    if (Rpt_STR_Details_list.Sum(item => Convert.ToDouble(item.STR_AMOUNT)) > 0)
                    {
                        if (ds.Tables[23].Rows[0]["CntStrCode"].ToString() != "0")  // here we take the count from item table with filtering ITEM_STR_CODE is not empty
                        {
                            sb.Append("<tr style='text-align:center'><td10FWB@123>STR DETAILS</td></tr>");
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            sb.Append("<trFWB@123><td>Inv Sl No</td><td2@CS>Item Sl No</td><td2@CS>STR SRNo</td><td2@CS>STR Rate</td><td3@CS>STR Amount</td></tr>");
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            for (int i = 0; i < Rpt_STR_Details_list.Count; i++)
                            {
                                sb.Append("<tr><td>" + Rpt_STR_Details_list[i].INVOICE_SLNO + "</td><td2@CS>" + Rpt_STR_Details_list[i].ITEM_SLNO + "</td><td2@CS>" + Rpt_STR_Details_list[i].ITEM_STR_CODE + "</td><td2@CS>" + Rpt_STR_Details_list[i].STR_RATE + "</td><td3@CS>" + Rpt_STR_Details_list[i].STR_AMOUNT + "</td></tr>");
                            }
                            sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                            sb.Append("<tr><td7@CS>TOTAL SERVICE TAX REFUND AMOUNT = </td><td3@CS>" + Rpt_STR_Details_list.Sum(item => Convert.ToDouble(item.STR_AMOUNT)) + "</td></tr>");
                        }
                    }
                }

                //  ************  start of RE-EXPORT   DETAILS   *****************//  ds.Tables[12]
                if (ds.Tables[21].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>RE-EXPORT DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>InvSlNo</td><td>ItemSlNo</td> <td>BE Site</td><td2@CS>BE No &  BE Date</td><td>BE InvNo</td><td>BE Item</td><td>ManualBE</td><td2@CS>Qty utilised</td></tr>");
                    sb.Append("<trFWB@123><td>BE Qty</td><td>BE UQC</td> <td8@CS>BE Desc</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>BE Assbl Val</td><td2@CS>BE Duty Paid</td> <td2@CS>Paymt Date</td><td2@CS>BE Other Identifiable</td><td2@CS>BE Assbl Value Claim</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>BE Item Used</td><td2@CS>CommisnerPerm</td><td2@CS>InputCredit</td><td>Personal used</td><td>Modvat availed</td><td2@CS>ModvatRepaid</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[21].Rows.Count; i++)
                    {
                        sb.Append("<tr><td>" + ds.Tables[21].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[21].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[21].Rows[i]["BE_SITE"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_NO"] + " & " + ds.Tables[21].Rows[i]["BE_DATE"] + "</td> ");
                        sb.Append("<td>" + ds.Tables[21].Rows[i]["BE_INVOICE_NO"] + "</td><td>" + ds.Tables[21].Rows[i]["BE_INVOICE_ITEM_NO"] + "</td><td>" + ds.Tables[21].Rows[i]["MANUAL_BE_Y_N"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_QTY_UTILISED"] + "</td></tr>");
                        sb.Append("<tr><td>" + ds.Tables[21].Rows[i]["BE_QTY"] + "</td><td>" + ds.Tables[21].Rows[i]["BE_UQC"] + "</td><td8@CS>" + ds.Tables[21].Rows[i]["BE_ITEM_DESC"] + "</td></tr>");
                        sb.Append("<tr><td2@CS>" + ds.Tables[21].Rows[i]["BE_ASS_VALUE"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_DUTY_PAID"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_DUTY_PAYMENT_DATE"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_OTH_IDENTIFIABLE_PARAMETER"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["BE_ASS_VALUE_CLAIM"] + "</td></tr>");
                        sb.Append("<tr><td2@CS>" + ds.Tables[21].Rows[i]["BE_ITEM_USED_Y_N"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["COMMISIONER_PERMISSION_Y_N"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["INPUT_CREDIT_Y_N"] + "</td><td>" + ds.Tables[21].Rows[i]["PERSONAL_USED_Y_N"] + "</td><td>" + ds.Tables[21].Rows[i]["MODVAT_AVAILED_Y_N"] + "</td><td2@CS>" + ds.Tables[21].Rows[i]["MODVAT_REPAID_Y_N"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of SINGLE WINDOW - INFO DETAILS   *****************// ds.Tables[15]

                if (ds.Tables[15].Rows.Count > 0)
                {
                    string INFO_TEXT = "";
                    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - INFO DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td> <td2@CS>Info Type</td><td2@CS>Info Qualifier</td><td>Info Code</td><td>Info Text</td><td>MSR</td><td>UQC</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[15].Rows.Count; i++)
                    {

                        if (ds.Tables[15].Rows[i]["INFO_CODE"].ToString() == "RODTEPY")
                        {
                            INFO_TEXT = "Claimed";
                        }
                        else if (ds.Tables[15].Rows[i]["INFO_CODE"].ToString() == "RODTEPN")
                        {
                            INFO_TEXT = "Not Claimed";
                        }
                        else if (ds.Tables[15].Rows[i]["INFO_CODE"].ToString() == "DTASBY")
                        {
                            INFO_TEXT = ds.Tables[15].Rows[i]["INFO_TEXT"].ToString();
                        }
                        else
                        {
                            INFO_TEXT = "";
                        }

                        sb.Append("<tr><td>" + ds.Tables[15].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[15].Rows[i]["ITEM_SLNO"] + "</td><td2@CS>" + ds.Tables[15].Rows[i]["INFO_TYPE"] + "</td><td2@CS>" + ds.Tables[15].Rows[i]["INFO_QUALIFIER"] + "</td>");
                        sb.Append("<td>" + ds.Tables[15].Rows[i]["INFO_CODE"] + "</td><td>" + INFO_TEXT + "</td><td>" + ds.Tables[15].Rows[i]["INFO_MSR"] + "</td><td>" + ds.Tables[15].Rows[i]["INFO_UQC"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of SINGLE WINDOW - CONSTITUENT DETAILS  ******************// ds.Tables[16]
                if (ds.Tables[16].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - CONSTITUENT DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td><td2@CS>Cons.SrNo</td><td3@CS>Cons.Element Name</td><td>Percentage</td><td>Yield%</td><td>Active(Y/N)</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[16].Rows.Count; i++)
                    {
                        if (ds.Tables[16].Rows[i]["CONSTITUENT_SRNO"].ToString() != "")
                        {
                            sb.Append("<tr><td>" + ds.Tables[16].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[16].Rows[i]["ITEM_SLNO"] + "</td><td2@CS>" + ds.Tables[16].Rows[i]["CONSTITUENT_SRNO"] + "</td> ");
                            sb.Append("<td3@CS>" + ds.Tables[16].Rows[i]["CONSTITUENT_ELEMENT_NAME"] + "</td><td>" + ds.Tables[16].Rows[i]["CONSTITUENT_PERCENTAGE"] + "</td>");
                            sb.Append("<td>" + ds.Tables[16].Rows[i]["CONSTITUENT_YIELD_PERCENTAGE"] + "</td><td>" + ds.Tables[16].Rows[i]["ACTIVE_INGREDIENT"] + "</td></tr>");
                        }
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of SINGLE WINDOW - PRODUCTION  DETAILS   *****************// ds.Tables[17] 
                if (ds.Tables[17].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - PRODUCTION  DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td><td2@CS>Batch Identifier</td><td2@CS>Batch Qty</td><td>Manufacture Dt</td><td>Expiry Dt</td><td2@CS>BestBefore Dt</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[17].Rows.Count; i++)
                    {
                        if (ds.Tables[17].Rows[i]["PRODUCTION_BATCH_IDENTIFIER"].ToString() != "")
                        {
                            sb.Append("<tr><td>" + ds.Tables[17].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[17].Rows[i]["ITEM_SLNO"] + "</td><td2@CS>" + ds.Tables[17].Rows[i]["PRODUCTION_BATCH_IDENTIFIER"] + "</td> ");
                            sb.Append("<td2@CS>" + ds.Tables[17].Rows[i]["PRODUCTION_BATCH_QUANTITY"] + " " + ds.Tables[17].Rows[i]["UNIT_QTY_CODE"] + " </td><td>" + ds.Tables[17].Rows[i]["DATE_OF_MANUFACTURING"] + "</td>");
                            sb.Append("<td>" + ds.Tables[17].Rows[i]["DATE_OF_EXPIRY"] + "</td><td>" + ds.Tables[17].Rows[i]["BEST_BEFORE"] + "</td></tr>");
                        }
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of SINGLE WINDOW - CONTROL DETAILS *****************// // ds.Tables[18] 
                if (ds.Tables[18].Rows.Count > 0)
                {
                    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - CONTROL DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    //sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td> <td2@CS>Control Type Code</td><td colspan='2'>Batch Qty</td><td>Manufacture Dt</td><td>Expiry Dt</td><td>Best Before Dt</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td> <td2@CS>Control Type Code</td><td2@CS>Result Code</td><td>Control Location</td><td>StartDate</td><td>EndDate</td><td>Result Text</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int i = 0; i < ds.Tables[18].Rows.Count; i++)
                    {
                        if (ds.Tables[18].Rows[i]["CONTROL_TYPE_CODE"].ToString() != "")
                        {
                            if (ds.Tables[18].Rows[i]["CONTROL_TYPE_CODE"].ToString() == "DUC")
                            {
                                sb.Append("<tr><td>" + ds.Tables[18].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[18].Rows[i]["ITEM_SLNO"] + "</td><td2@CS>" + ds.Tables[18].Rows[i]["CONTROL_TYPE_CODE"] + "</td> ");
                            }
                            else
                            {
                                sb.Append("<tr><td>0</td><td>0</td><td2@CS>" + ds.Tables[18].Rows[i]["CONTROL_TYPE_CODE"] + "</td> ");
                            }
                            sb.Append("<td2@CS>" + ds.Tables[18].Rows[i]["CONTROL_RESULT_CODE"] + "</td><td>" + ds.Tables[18].Rows[i]["CONTROL_LOCATION"] + "</td><td> " + ds.Tables[18].Rows[i]["CONTROL_START_DATE"] + " </td><td>" + ds.Tables[18].Rows[i]["CONTROL_END_DATE"] + "</td>");
                            sb.Append("<td2@CS>" + ds.Tables[18].Rows[i]["CONTROL_RESULT_TEXT"] + "</td></tr>");
                        }
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  start of DECLARATIONS DETAILS *****************// // ds.Tables[19] 
                if (ds.Tables[19].Rows.Count > 0)
                {
                    string decflag = "";
                    if (Request.QueryString["chk_Stmt"] == "" || Request.QueryString["chk_Stmt"] == null)
                    {
                    }
                    else
                    {
                        decflag = Request.QueryString["chk_Stmt"].ToString();
                    }

                    sb.Append("<tr style='text-align:center'><td10FWB@123>DECLARATIONS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>Inv SlNo</td><td>Item SlNo</td><td>Stmt Type</td><td>Stmt Code</td><td6@CS>Stmt Text</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");

                    for (int i = 0; i < ds.Tables[19].Rows.Count; i++)
                    {
                        if (ds.Tables[19].Rows[i]["STMT_TYPE"].ToString() != "")
                        {
                            if (decflag == "False")
                            {
                                if (COMPANY_ID == "10" || COMPANY_ID == "480")
                                {
                                    if (i == 0)
                                    {
                                        sb.Append("<tr><td>" + ds.Tables[19].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_TYPE"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_CODE"] + "</td><td6@CS>" + ds.Tables[19].Rows[i]["STMT_TEXT"] + "</td></tr>");
                                    }
                                    else
                                    {
                                        sb.Append("<tr><td>" + ds.Tables[19].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_TYPE"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_CODE"] + "</td><td6@CS></td></tr>");
                                    }
                                }
                                else
                                {
                                    sb.Append("<tr><td>" + ds.Tables[19].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_TYPE"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_CODE"] + "</td><td6@CS></td></tr>");
                                }
                            }
                            else
                                sb.Append("<tr><td>" + ds.Tables[19].Rows[i]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["ITEM_SLNO"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_TYPE"] + "</td><td>" + ds.Tables[19].Rows[i]["STMT_CODE"] + "</td><td6@CS>" + ds.Tables[19].Rows[i]["STMT_TEXT"] + "</td></tr>");
                        }
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  Start of SINGLE WINDOW - SUPPORTING DOCUMENTS DETAILS  *****************// ds.Tables[20]

                if (ds.Tables[20].Rows.Count > 0)
                {


                    //------------ Get Distinct SUPDOC Codes Here ----------------------
                    DataView dv_SUPDOC = new DataView(ds.Tables[20]);
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
                                var rowsToUpdate = ds.Tables[20].AsEnumerable().Where(r => r.Field<string>("DOC_TYPE_CODE") == dt_SUPDOC_New.Rows[i][0].ToString());

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

                    sb.Append("<tr10br@123>");
                    sb.Append("<tr style='text-align:center'><td10FWB@123>SINGLE WINDOW - SUPPORTING DOCUMENTS DETAILS</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    sb.Append("<trFWB@123><td>InvSlNo</td><td>ItemSlNo</td><td colspan='2'>Place of Issue</td><td colspan='2'>File Type</td><td colspan='2'>Doc reference number</td><td>IssueDate</td><td>Expiry Date</td></tr>");
                    sb.Append("<trFWB@123><td2@CS>Unique Doc Number</td><td colspan='8'>Doc type Code</td></tr>");
                    sb.Append("<trFWB@123><td  colspan='4'>Doc. Issuing Party Code</td><td colspan='2'>Icegate ID</td><td colspan='4'>Doc. Beneficiary Party Code</td></tr>");
                    sb.Append("<trFWB@123><td colspan='6'>Doc. Issuing Party Name</td><td colspan='4'>Doc. Beneficiary Party Name</td> </tr>");
                    sb.Append("<trFWB@123><td6@CS>Doc. Issuing Party Name Address1</td><td4@CS>Doc. Beneficiary Party Name Address1</td> </tr>");
                    sb.Append("<trFWB@123><td6@CS>Doc. Issuing Party Name Address2</td><td4@CS>Doc. Beneficiary Party Name Address2</td> </tr>");
                    sb.Append("<trFWB@123><td  colspan='4'>Doc. Issuing Party City</td><td colspan='2'>Doc Level</td><td colspan='4'>>Doc. Beneficiary Party City</td></tr>");
                    sb.Append("<trFWB@123><td  colspan='2'>Doc. Issuing Party PIN</td><td colspan='4'>Icegate FileName</td><td colspan='4'>Doc. Beneficiary Party Code</td></tr>");
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                    for (int rsp = 0; rsp < ds.Tables[20].Rows.Count; rsp++)
                    {
                        sb.Append("<tr><td>" + ds.Tables[20].Rows[rsp]["INVOICE_SLNO"] + "</td><td>" + ds.Tables[20].Rows[rsp]["ITEM_SLNO"] + "</td> <td  colspan='2'>" + ds.Tables[20].Rows[rsp]["PLACE_OF_ISSUE"] + "</td><td  colspan='2'>" + ds.Tables[20].Rows[rsp]["FILE_TYPE"] + "</td><td2@CS>" + ds.Tables[20].Rows[rsp]["DOC_REF_NUMBER"] + "</td><td>" + ds.Tables[20].Rows[rsp]["DOC_ISSUE_DATE"] + "</td><td>" + ds.Tables[20].Rows[rsp]["DOC_EXPIRY_DATE"] + "</td></tr>");
                        sb.Append("<tr><td2@CS>" + ds.Tables[20].Rows[rsp]["UNIQUE_DOC_NUMBER"] + "</td><td  colspan='8'>" + ds.Tables[20].Rows[rsp]["DOC_TYPE_CODE"] + "</td> </tr>");
                        sb.Append("<tr><td  colspan='4'>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_CODE"] + "</td><td2@CS>" + ds.Tables[20].Rows[rsp]["ICEGATE_ID"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_CODE"] + "</td></tr>");
                        sb.Append("<tr><td6@CS>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_NAME"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_NAME"] + "</td></tr>");
                        sb.Append("<tr><td6@CS>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_NAME_ADD1"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_ADDRESS1"] + "</td></tr>");
                        sb.Append("<tr><td6@CS>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_NAME_ADD2"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_ADDRESS2"] + "</td></tr>");
                        sb.Append("<tr><td  colspan='4'>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_CITY"] + "</td><td2@CS>" + ds.Tables[20].Rows[rsp]["SELECT_TYPE"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_CITY"] + "</td></tr>");

                        sb.Append("<tr><td  colspan='2'>" + ds.Tables[20].Rows[rsp]["DOC_ISSUING_PARTY_PIN"] + "</td><td  colspan='4'>" + ds.Tables[20].Rows[rsp]["ICEGATE_DOC_FILE_NAME"] + "</td><td4@CS>" + ds.Tables[20].Rows[rsp]["BENEFICIARY_PARTY_PIN"] + "</td></tr>");
                    }
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>");
                }

                //  ************  End of SINGLE WINDOW - SUPPORTING DOCUMENTS DETAILS  *****************//

                sb.Append("<tr><td10@CS><br/></td></tr>");
                //sb.Append("<tr><td colspan='10' style='text-align:left'>Declaration</td></tr>");
                sb.Append("<tr><td10@CS>I/We declare that the particulars given herein are true and are correct.</td></tr>");
                sb.Append("<tr><td10@CS>I/We undertake to abide by provisions of Foreign Exchange Management Act,1999, as amended from time to time</td></tr>");
                sb.Append("<tr><td10@CS>including realisation / repatriation of foreign exchange to / from India.</td></tr>");
                sb.Append("<tr><td10@CS>" + DECLARATION + "</td></tr>");
                sb.Append("<tr><td10@CS><br/></td></tr>");



                sb.Append("<tr><td6@CS>" + cha + "</td><td4@CS>" + Exporter + " </td></tr>");
                if (COMPANY_ID == "517" || COMPANY_ID == "480" || COMPANY_ID == "508" || COMPANY_ID == "3388")
                {
                    sb.Append("<tr><td6@CS>" + cha_title + "</td><td4@CS>" + "" + "</td></tr>");
                }
                else
                {
                    sb.Append("<tr><td6@CS>" + cha_title + "</td><td4@CS>" + EXPORTER_NAME + "</td></tr>");
                }
                sb.Append("<tr10br@123>");

                if (COMPANY_ID == "517")
                {
                    string imgfolder = Server.MapPath("~/images//LIZMA_Sign.png");
                    sb.Append("<tr><td6@CS>" + "<img src='" + imgfolder + "' tooltip='Signature' alt='Signature'/>" + "</td></tr>");
                    sb.Append("<tr10br@123>");
                    sb.Append("<tr><td6@CS>" + "R.DEVANANTH" + "</td><td4@CS>" + "" + "</td></tr>");
                    sb.Append("<tr><td6@CS>" + "P.A.HOLDER" + "</td><td4@CS>" + "" + "</td></tr>");
                    sb.Append("<tr><td6@CS>" + "CARD NO:34/2021" + "</td><td4@CS>" + "" + "</td></tr>");
                }
                else if (COMPANY_ID == "3388")
                {
                    string imgfolder = Server.MapPath("~/images//MAG_STAR_Sign3.png");
                    sb.Append("<tr><td6@CS>" + "<img src='" + imgfolder + "' tooltip='Signature' alt='Signature'/>" + "</td></tr>");
                    sb.Append("<tr10br@123>");
                }
                else
                {
                    sb.Append("<tr><td6@CS>" + cha_Signature + "</td><td4@CS>" + Signature + "</td></tr>");
                }

                sb.Append("</table></html>");


                HttpResponse Response = HttpContext.Current.Response;

                //Literal lbl = new Literal();
                if (Request.QueryString["IsBulk"] != "Y")  // single check list
                {
                    lbl.Text = sb.ToString().Replace("<tdFWB@123>", "<td style='font-weight:bold'>").Replace("<td2FWB@123>", "<td colspan='2' style='font-weight:bold'>").Replace("<td3FWB@123>", "<td colspan='3' style='font-weight:bold'>").Replace("<td4FWB@123>", "<td colspan='4' style='font-weight:bold'>").Replace("<td5FWB@123>", "<td colspan='5' style='font-weight:bold'>").Replace("<trFWB@123>", "<tr style='font-weight:bold'>").Replace("<td6FWB@123>", "<td colspan='6' style='font-weight:bold'>").Replace("<tdSAR@123>", "<td style='text-align:right'>").Replace("<td7FWB@123>", "<td colspan='7' style='font-weight:bold'>").Replace("<td8FWB@123>", "<td colspan='8' style='font-weight:bold'>").Replace("<td9FWB@123>", "<td colspan='9' style='font-weight:bold'>").Replace("<td10FWB@123>", "<td colspan='10' style='font-weight:bold'>").Replace("<td2@CS>", "<td colspan='2'>").Replace("<td3@CS>", "<td colspan='3'>").Replace("<td4@CS>", "<td colspan='4'>").Replace("<td5@CS>", "<td colspan='5'>").Replace("<td6@CS>", "<td colspan='6'>").Replace("<td7@CS>", "<td colspan='7'>").Replace("<td8@CS>", "<td colspan='8'>").Replace("<td9@CS>", "<td colspan='9'>").Replace("<td10@CS>", "<td colspan='10'>").Replace("<tr10br@123>", "<tr><td colspan='10'><br/></td></tr>").Replace("<td2SAR@123>", "<td colspan='2' style='text-align:right'>").Replace("<td7SAR@123>", "<td colspan='7' style='text-align:right'>");

                    ////---------To Print--------Skylift and Airlift On 21Sep2015-----------------------------//
                    string CID = COMPANY_ID.ToString();
                    if (CID == "4" || CID == "164" || CID == "165" || CID == "752")
                    {
                        errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID.ToString() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User() + "/EXP_Job_history/");
                        if (Directory.Exists(errorFolder) == false)
                        {
                            Directory.CreateDirectory(errorFolder);
                        }
                        else
                        {
                            foreach (FileInfo fileInformation in new DirectoryInfo(errorFolder).GetFiles())  // delete all the files inside   folder
                            {
                                File.Delete(fileInformation.FullName);
                            }
                        }

                        StringReader sr = new StringReader(lbl.Text);
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                            pdfDoc.Open();
                            htmlparser.Parse(sr);
                            pdfDoc.Close();
                            byte[] bytes = memoryStream.ToArray();
                            File.WriteAllBytes(errorFolder + ddlJobNo + " ~~" + ddlJobNo + ".pdf", bytes);
                            memoryStream.Close();

                            errorFolder = Server.MapPath("~/Submission/" + CID + "/" + Connection.Current_Branch() + "/" + "EXP_Job_history" + "/");
                            if (Directory.Exists(errorFolder) == false)
                            {
                                Directory.CreateDirectory(errorFolder);
                            }
                            File.WriteAllBytes(errorFolder + ddlJobNo + " ~~" + ddlJobNo + ".pdf", bytes);

                        }


                        Upload_JobHistory();
                    }
                    else if (CID == "816" || CID == "3149") // Added by pandiyan for Icode Checklist stored 
                    {

                        StringReader sr = new StringReader(lbl.Text);
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                            pdfDoc.Open();
                            htmlparser.Parse(sr);
                            pdfDoc.Close();
                            byte[] bytes = memoryStream.ToArray();
                            memoryStream.Close();

                            errorFolder = Server.MapPath("~/Submission/" + CID + "/" + Connection.Current_Branch() + "/" + "EXP_Job_history" + "/");
                            if (Directory.Exists(errorFolder) == false)
                            {
                                Directory.CreateDirectory(errorFolder);
                            }
                            string fileName = "ExpJob" + "_" + ddlJobNo + ".pdf";
                            string fullPath = errorFolder + fileName;
                            File.WriteAllBytes(fullPath, bytes);  
                        }
                        if (CID == "816") // Added by shanthini on 25-07-2026
                        {
                            string logPath = @"D:\Logs\ButtonClick.log";

                            // Auto-create folder if it doesn't exist
                            string logDir = Path.GetDirectoryName(logPath);
                            if (!Directory.Exists(logDir))
                            {
                                Directory.CreateDirectory(logDir);
                            }
                            try
                            {
                                File.AppendAllText(logPath, DateTime.Now + " | btnSendApi_Click STARTED" + Environment.NewLine);

                                File.AppendAllText(logPath, DateTime.Now + " | CID=" + CID + " branch=" + Connection.Current_Branch() + " jobNo=" + ddlJobNo + Environment.NewLine);

                                string errorFolder = Server.MapPath("~/Submission/" + CID + "/" + Connection.Current_Branch() + "/EXP_Job_history/");
                                string fileName = "ExpJob_" + ddlJobNo + ".pdf";
                                string filePath = errorFolder + fileName;

                                File.AppendAllText(logPath, DateTime.Now + " | filePath=" + filePath + Environment.NewLine);

                                // FIX: check actual file existence, not just string emptiness
                                if (File.Exists(filePath))
                                {
                                    File.AppendAllText(logPath, DateTime.Now + " | File exists. Calling API..." + Environment.NewLine);

                                    string result = Checklist_Api_Send.SendAttachmentToApi(filePath, CID, ddlJobNo);

                                    File.AppendAllText(logPath, DateTime.Now + " | API result: " + result + Environment.NewLine);

                                    // FIX: check result before showing success message
                                    if (result != null && result.Contains("jobNumber"))
                                    {
                                        // success — server returned expected JSON
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                                            "alert('API Upload Completed');", true);
                                    }
                                    else
                                    {
                                        // API call failed / returned error text
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                                            "alert('API Upload Failed: " + result.Replace("'", "").Replace("\n", " ").Replace("\r", "") + "');", true);
                                    }
                                }
                                else
                                {
                                    File.AppendAllText(logPath, DateTime.Now + " | ERROR: File does not exist at path." + Environment.NewLine);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                                        "alert('Checklist file not found');", true);
                                }

                                File.AppendAllText(logPath, DateTime.Now + " | btnSendApi_Click ENDED" + Environment.NewLine);
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(logPath, DateTime.Now + " | EXCEPTION: " + ex.ToString() + Environment.NewLine);
                                Connection.Error_Msg(ex.Message);
                            }
                        }
                    }
                    ////-----------------Skylift and Airlift On 21Sep2015-----------------------------//
                    else
                    { // Direct pdf file open
                        if (lbl.Text != "")
                        {
                            //lbl.Text = lbl.Text.Replace("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>", "<html><table width='100%' style='vertical-align:top; font-family:Courier New ;font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");
                            lbl.Text = lbl.Text.Replace("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>", "<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");

                            /*
                             if (Connection.COMPANYID() == "517")
                             {
                                 string imgfolder = Server.MapPath("~/images//LIZMA_Sign.png");
                                 lbl.Text = lbl.Text + "<div style='width:1px; height:1px'> <img src='" + imgfolder + "' tooltip='Signature' alt='Signature'/> </a></div>";
                             }
                            */

                            string jobno = ddlJob_No.SelectedValue.ToString();
                            string filename = "";
                            if (COMPANY_ID == "880")
                            {
                                filename = "ExpChecklist_" + EXPORTER_NAME + "_" + FileName_First_InvoiceNo + "_" + jobno + ".pdf";
                            }
                            else if (COMPANY_ID == "480") // Added by shanthini on 04-06-2026
                            {
                                string cleanInvNo = Regex.Replace(FileName_First_InvoiceNo, @"[^a-zA-Z0-9]", "");
                                filename = "ExpChecklist_" + jobno + "_" + cleanInvNo + ".pdf";
                            }
                            else
                            {
                                filename = "ExpChecklist_" + jobno + ".pdf";
                            }
                            Response.Clear();
                            Response.Buffer = true;
                            Response.ContentType = "application/pdf";
                            //Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
                            Response.AddHeader("content-disposition", "inline;filename=" + filename + "");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            using (StringWriter sw = new StringWriter())
                            {
                                HtmlTextWriter hw = new HtmlTextWriter(sw);
                                lbl.RenderControl(hw);
                                StringReader sr = new StringReader(sw.ToString());
                                Document pdfDoc = new Document(PageSize.A4, 40f, 10f, 5f, 5f);
                                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                                pdfDoc.Open();
                                htmlparser.Parse(sr);
                                pdfDoc.Close();
                                Response.Write(pdfDoc);
                                //Response.End();
                                Response.Flush();

                            }
                        }

                    }
                }
                else
                {
                    indjobstring = sb.ToString().Replace("<tdFWB@123>", "<td style='font-weight:bold'>").Replace("<td2FWB@123>", "<td colspan='2' style='font-weight:bold'>").Replace("<td3FWB@123>", "<td colspan='3' style='font-weight:bold'>").Replace("<td4FWB@123>", "<td colspan='4' style='font-weight:bold'>").Replace("<td5FWB@123>", "<td colspan='5' style='font-weight:bold'>").Replace("<trFWB@123>", "<tr style='font-weight:bold'>").Replace("<td6FWB@123>", "<td colspan='6' style='font-weight:bold'>").Replace("<tdSAR@123>", "<td style='text-align:right'>").Replace("<td7FWB@123>", "<td colspan='7' style='font-weight:bold'>").Replace("<td8FWB@123>", "<td colspan='8' style='font-weight:bold'>").Replace("<td9FWB@123>", "<td colspan='9' style='font-weight:bold'>").Replace("<td10FWB@123>", "<td colspan='10' style='font-weight:bold'>").Replace("<td2@CS>", "<td colspan='2'>").Replace("<td3@CS>", "<td colspan='3'>").Replace("<td4@CS>", "<td colspan='4'>").Replace("<td5@CS>", "<td colspan='5'>").Replace("<td6@CS>", "<td colspan='6'>").Replace("<td7@CS>", "<td colspan='7'>").Replace("<td8@CS>", "<td colspan='8'>").Replace("<td9@CS>", "<td colspan='9'>").Replace("<td10@CS>", "<td colspan='10'>").Replace("<tr10br@123>", "<tr><td colspan='10'><br/></td></tr>").Replace("<td2SAR@123>", "<td colspan='2' style='text-align:right'>").Replace("<td7SAR@123>", "<td colspan='7' style='text-align:right'>");
                    string errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID.ToString() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User() + "/EXP_BulkCheckList/");


                    //**** start of convert into PDF and write into folder ************/////////

                    StringReader sr = new StringReader(indjobstring);
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        File.WriteAllBytes(errorFolder + ddlJobNo + ".pdf", bytes);
                        memoryStream.Close();
                        ViewState["ExportedJobnos"] = ViewState["ExportedJobnos"] + "," + ddlJobNo;
                    }
                    //**** End of convert into PDF and write into folder ************/////////  
                }

                ds.Dispose();
                GC.Collect();

            }
        //}
        //catch (Exception ex)
        //{
        //    ErrorLogs er = new ErrorLogs();
        //    er.makeLog(ex.Message);
        //    ViewState["ErrorJobnos"] = ViewState["ErrorJobnos"].ToString() + "," + ddlJobNo;
        //}
    }


    protected void btnpdf_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbl.Text != "")
            {
                //lbl.Text = lbl.Text.Replace("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>", "<html><table width='100%' style='vertical-align:top; font-family:Courier New ;font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");
                lbl.Text = lbl.Text.Replace("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>", "<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");
                string jobno = ddlJob_No.SelectedValue.ToString();
                string filename = "ExpChecklist_" + jobno + ".pdf";
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
                //Response.AddHeader("content-disposition", "inline;filename=" + filename + "");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    lbl.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 40f, 10f, 5f, 5f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Check List', function (r) {});}});</script>";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                //this.Page.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", prompt);
                string pp = "alert('your Message goes here')";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", pp, true);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        

    }

    public void Upload_JobHistory()
    {
        try
        {
            jh.JOB_ID = "";
            jh.JOB_TYPE = "EXP";
            jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
            jh.JOBNO = Session["JobNo"].ToString();

            if (JOBDATE == "" || JOBDATE == null)
            {
                JOBDATE = "01/01/1900";
            }

            jh.JOBDATE = JOBDATE;
            jh.DESCRIPTION = errorFolder;
            jh.ATTACHMENT_FILE = ddlJobNo + " ~~" + ddlJobNo + ".pdf";
            jh.FLAG = "Upload_File";
            jh.USER_ID = currentuser;

            jh.BRANCH_CODE = currentbranch;
            jh.YEAR = "";

            if (Connection.Ryal() != string.Empty)
            {
                jh.FLAG = "Upload_File_Ryal";
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                url = url.Substring(0, url.IndexOf("Report")) + errorFolder.Substring(errorFolder.IndexOf("Submission"), errorFolder.Length - errorFolder.IndexOf("Submission")) + jh.ATTACHMENT_FILE;
                jh.YEAR = url.Replace(@"\", @"/");
            }

            jh.WORKING_PERIOD = Working_Period;
            jh.BRANCH_COMMON = SELECT_BRANCH;
            job_his = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }


    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbl.Text != "")
            {
                byte[] bytes = Encoding.ASCII.GetBytes(lbl.Text);
                Session.Remove("report");
                Session["report"] = bytes;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "Mail_open()", true);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbl.Text != "")
            {
                byte[] bytes = Encoding.ASCII.GetBytes(lbl.Text);
                Session.Remove("report");
                Session["report"] = bytes;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "Print_open()", true);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }



    public void Get_ITEM_Details(string ddlJobNo, DataTable ds, DataTable ds2, DataTable dt, DataTable dt_sw_info, DataTable dt_cess, DataTable dt_item_Addl, DataTable dt_item_Rodtep)
    {
        try
        {
            Get_dt_Tbl_Items();
            SB_NO = Get_SBNo();

            Rpt_Item_Details_new_list.Clear();
            Rpt_DrawBack_Details_list.Clear();
            Rpt_STR_Details_list.Clear();
            Rpt_CESS_Details_list.Clear();

            int b = 0, C = 0, i = 0;

            /*-------------- TryParse - Need to Implement --10-03-2026--------
            string INVOICE_VALUE_FC = "1449";
            string EXCHANGE_RATE = "90.8";

            decimal invoice = 0;
            decimal rate = 0;

            decimal.TryParse(INVOICE_VALUE_FC, out invoice);
            decimal.TryParse(EXCHANGE_RATE, out rate);

            decimal INDIVIDUAL_INVOICE_VALUE = invoice * rate;

             */

            string curINVOICE_SLNO = "0";
            string count = Convert.ToString(ds.Rows.Count);
            TOTAL_STR_AMOUNT = "0";
            INDIVIDUAL_INVOICE_VALUE = 0;
            INVOICE_VALUE_FC = "0.00";
            SUM_TOTAL_DBK_VALUE = 0;
            DBK_VALUE = "0.00";
            CESS_AMOUNT = "0.00";
            TOT_SUM_LEV_AMT = 0.00;


            Rpt_DrawBack_Details_list.Clear();
            Rpt_STR_Details_list.Clear();

            GET_ALL_Export_Checklist_Admin_Master();

            while (ds.Rows.Count > C)
            {

                TOTAL_ITEM_INVOICE_VALUE = 0;

                string FREIGHT_CHARGES, INSURANCE_CHARGES;
                curINVOICE_SLNO = string.Empty;
                NUMBERTOWORDS = string.Empty;
                curINVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
                INVOICE_VALUE = Return_Zero_Value1(ds.Rows[C]["INVOICE_VALUE"].ToString());

                COMMISSION_CURRENCY = ds.Rows[C]["COMMISSION_CURRENCY"].ToString();
                COMMISSION_RATE = Return_Zero_Value1(ds.Rows[C]["COMMISSION_RATE"].ToString());
                COMMISSION_CHARGES = Return_Zero_Value1(ds.Rows[C]["COMMISSION_CHARGES"].ToString());

                FOB_CURRENCY = ds.Rows[C]["FOB_CURRENCY"].ToString();
                FOB_RATE = Return_Zero_Value1(ds.Rows[C]["FOB_RATE"].ToString());
                FOB_CHARGES = Return_Zero_Value1(ds.Rows[C]["FOB_CHARGES"].ToString());
                //PACKMISC_RATE = Return_Zero_Value1(ds.Rows[C]["PACKMISC_RATE"].ToString());

                //PACKMISC_CHARGES = Return_Zero_Value1(ds.Rows[C]["PACKMISC_CHARGES"].ToString());
                OTHER_DEDUCTION_CURRENCY =ds.Rows[C]["OTHER_DEDUCTION_CURRENCY"].ToString();
                OTHER_DEDUCTION_RATE = Return_Zero_Value1(ds.Rows[C]["OTHER_DEDUCTION_RATE"].ToString());
                OTHER_DEDUCTION_CHARGES = Return_Zero_Value1(ds.Rows[C]["OTHER_DEDUCTION_CHARGES"].ToString());
                //WHEATHER_UNIT_PRICE = Return_Zero_Value1(ds.Rows[C]["WHEATHER_UNIT_PRICE"].ToString());

                //---------------------------------------PMV VALUE INVOICE CALCULATION--------------------------------------//
                ITEM_PMVVALUE = "0";
                TOTAL_ITEM_PMVVALUE = 0;
                TOTAL_PMVVALUE = 0;
                EXCHANGE_RATE = Return_ExRate_Value(ds.Rows[C]["INVOICE_CURRENCY"].ToString(), ds.Rows[C]["EXCHANGE_RATE"].ToString());

                FREIGHT_CHARGES = Return_Zero_Value(ds.Rows[C]["FREIGHT_CHARGES"].ToString());
                FREIGHT_EXRATE = Return_ExRate_Value(ds.Rows[C]["FREIGHT_CURRENCY"].ToString(), ds.Rows[C]["FREIGHT_EXRATE"].ToString());
                INSURANCE_CHARGES = Return_Zero_Value(ds.Rows[C]["INSURANCE_CHARGES"].ToString());
                INSURANCE_EXRATE = Return_ExRate_Value(ds.Rows[C]["INSURANCE_CURRENCY"].ToString(), ds.Rows[C]["INSURANCE_EXRATE"].ToString());
                FREIGHT_RATE = Return_Zero_Value1(ds.Rows[C]["FREIGHT_RATE"].ToString());
                INSURANCE_RATE = Return_Zero_Value1(ds.Rows[C]["INSURANCE_RATE"].ToString());
                TERMS = ds.Rows[C]["TERMS"].ToString();

                PACKMISC_CURRENCY = ds.Rows[C]["PACKMISC_CURRENCY"].ToString();
                PACKMISC_RATE = Return_Zero_Value1(ds.Rows[C]["PACKMISC_RATE"].ToString());
                PACKMISC_CHARGES = Return_Zero_Value1(ds.Rows[C]["PACKMISC_CHARGES"].ToString());

                PACKMISC_EXRATE = EXCHANGE_RATE;
                TOTAL_FREIGHT_AMOUNT = 0;
                TOTAL_INSURANCE_AMOUNT = 0;
                TOTAL_PACKING_AMOUNT = 0;

                WHEATHER_UNIT_PRICE = Return_Zero_Value1(ds.Rows[C]["WHEATHER_UNIT_PRICE"].ToString());
                TOTAL_FREIGHT_AMOUNT = Convert.ToDouble(FREIGHT_CHARGES) * Convert.ToDouble(FREIGHT_EXRATE);
                TOTAL_INSURANCE_AMOUNT = Convert.ToDouble(INSURANCE_CHARGES) * Convert.ToDouble(INSURANCE_EXRATE);
                TOTAL_PACKING_AMOUNT = Convert.ToDouble(PACKMISC_CHARGES) * Convert.ToDouble(PACKMISC_EXRATE);
                //---------------------------------------PMV VALUE INVOICE CALCULATION--------------------------------------//

                DataView view = ds2.DefaultView;
                view.RowFilter = "INVOICE_SLNO = " + curINVOICE_SLNO;
                DataTable table = view.ToTable();

                DataSet dss = new DataSet();
                dss.Tables.Add(table);
                int sum = 0;
                b = 0;

                while (dss.Tables[0].Rows.Count > sum)
                {
                    //--------------Calculation implemented on 26Sep2015--------------//
                    double item_per = Convert.ToDouble(dss.Tables[0].Rows[sum]["ITEM_PER"].ToString());
                    ITEM_AMOUNT = dss.Tables[0].Rows[sum]["ITEM_AMOUNT"].ToString();

                    double item_amtnew = Convert.ToDouble(ITEM_AMOUNT) * item_per;
                    ITEM_AMOUNT = Convert.ToString(item_amtnew);
                    //--------------Calculation implemented on 26Sep2015--------------//

                    double tot_item_inv_val = TOTAL_ITEM_INVOICE_VALUE + Convert.ToDouble(ITEM_AMOUNT);

                    //--------------Enabled on 22Jan2016(for Skylift Bug)------------//
                    TOTAL_ITEM_INVOICE_VALUE = TOTAL_ITEM_INVOICE_VALUE + Convert.ToDouble(ITEM_AMOUNT = dss.Tables[0].Rows[sum]["ITEM_AMOUNT"].ToString());
                    //--------------Enabled on 22Jan2016(for Skylift Bug)------------//
                    sum++;
                }


                INDIVIDUAL_INVOICE_VALUE = 0;
                TOTAL_INV_VALUE = 0;

                SL_NO = 0;

                while (dss.Tables[0].Rows.Count > b)
                {
                    STR_AMOUNT = "0";
                    CESS_AMOUNT = "0";
                    INDIVIDUAL_COMMISSION_AMOUNT = 0;
                    INDIVIDUAL_INSURANCE_AMOUNT = 0;
                    INDIVIDUAL_FOB_DISCOUNT_AMOUNT = 0;
                    INDIVIDUAL_OTHER_DISCOUNT_AMOUNT = 0;
                    INDIVIDUAL_PACKING_CHARGE_AMOUNT = 0;
                    INDIVIDUAL_FOB_VALUE = 0;
                    TOTAL_FOB_AMOUNT = 0;
                    INVOICE_SLNO = dss.Tables[0].Rows[b]["INVOICE_SLNO"].ToString();
                    INVOICE_NO = dss.Tables[0].Rows[b]["INVOICE_NO"].ToString();
                    ITEM_SLNO = dss.Tables[0].Rows[b]["ITEM_SLNO"].ToString();
                    ITEM_DESCRIPTION = dss.Tables[0].Rows[b]["ITEM_DESCRIPTION"].ToString();//.Replace("\r\n",string.Empty);
                    RITCNO = dss.Tables[0].Rows[b]["RITCNO"].ToString();
                    ITEM_QTY = dss.Tables[0].Rows[b]["ITEM_QTY"].ToString();
                    ITEM_QTY_CODE = dss.Tables[0].Rows[b]["ITEM_QTY_CODE"].ToString();
                    ITEM_UNIT_PRICE = dss.Tables[0].Rows[b]["ITEM_UNIT_PRICE"].ToString();
                    ITEM_PER = dss.Tables[0].Rows[b]["ITEM_PER"].ToString();

                    //--------------Calculation implemented on 26Sep2015--------------//

                    ITEM_AMOUNT = dss.Tables[0].Rows[b]["ITEM_AMOUNT"].ToString();

                    double item_amtnew = Convert.ToDouble(ITEM_AMOUNT) * Convert.ToDouble(ITEM_PER);
                    ITEM_AMOUNT = Convert.ToString(item_amtnew);

                    //INDIVIDUAL_ITEM_INVOICE_VALUE = Convert.ToDouble(ITEM_AMOUNT);

                    //--------------Calculation implemented on 26Sep2015--------------//

                    //------------Implemented on 20June2016 for Paramount ------//

                    /* hide on 29-11-2022 by Chithra for Invoice Value Round off issue for SGATE Sugg.by Bala sir
                    //INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE), 2);
                    if (COMPANY_ID == "525" || COMPANY_ID == "508" || COMPANY_ID == "747")
                    {
                        INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE), 5);
                    }
                    else
                    {
                        INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE), 2);
                    }
                    */

                    INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE), 5);

                    /* hide on 17-02-2024 by Chithra - Compared with Final Print & RIfor Invoice Value Round off issue-  Sugg.by Bala sir
                    //-----NILA SEA FOODS - Compared with Final Print & RI - by Chithra Suggg by Bala sir on 02-11-2023
                    if (COMPANY_ID == "10" || COMPANY_ID == "663" || COMPANY_ID == "1344" || COMPANY_ID == "2078" || COMPANY_ID == "2082" || COMPANY_ID == "2151" || COMPANY_ID == "2168" || COMPANY_ID == "2152" || COMPANY_ID == "2153" || COMPANY_ID == "2154" || COMPANY_ID == "2155" || COMPANY_ID == "2219" || COMPANY_ID == "2226")
                    {
                        INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(Convert.ToDouble(INDIVIDUAL_ITEM_INVOICE_VALUE), 2);
                    }
                    */

                    Actual_Individual_Item_Amt = INDIVIDUAL_ITEM_INVOICE_VALUE;//Newly added for All calc - 01-03-2024
                    Actual_Individual_Item_Amt = Math.Round(INDIVIDUAL_ITEM_INVOICE_VALUE / Convert.ToDouble(ITEM_PER), 5);

                    //Commonly round of 2 Digit - Sugg.by Bala sir
                    //INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(Convert.ToDouble(INDIVIDUAL_ITEM_INVOICE_VALUE), 2);//  hide on 22-03-2024 sugg.by Bala sir for LKS - if 5 means takes as "1" after digit
                    //if (Connection.COMPANYID() == "2244")//2 digit cut off after the point
                    //{
                    //    INDIVIDUAL_ITEM_INVOICE_VALUE = Convert.ToDouble((Math.Truncate(INDIVIDUAL_ITEM_INVOICE_VALUE)).ToString("F2"));
                    //}
                    //else
                    //{
                   // INDIVIDUAL_ITEM_INVOICE_VALUE = Convert.ToDouble((Math.Round(Convert.ToDecimal(INDIVIDUAL_ITEM_INVOICE_VALUE), 2, MidpointRounding.AwayFromZero)).ToString());
                    //}
                    //------------Implemented on 20June2016 for Paramount ------//

                    if (COMPANY_ID == "1" || COMPANY_ID == "196")
                    {
                        INDIVIDUAL_ITEM_INVOICE_VALUE = Convert.ToDouble((Math.Round(Convert.ToDecimal(INDIVIDUAL_ITEM_INVOICE_VALUE), 5, MidpointRounding.AwayFromZero)).ToString());
                    }
                    else
                    {
                        INDIVIDUAL_ITEM_INVOICE_VALUE = Convert.ToDouble((Math.Round(Convert.ToDecimal(INDIVIDUAL_ITEM_INVOICE_VALUE), 2, MidpointRounding.AwayFromZero)).ToString());
                    }


                    ITEM_PMVVALUE = dss.Tables[0].Rows[b]["ITEM_PMVVALUE"].ToString();

                    /* hide on 29-11-2022 by Chithra for Invoice Value Round off issue for SGATE Sugg.by Bala sir
                    if (COMPANY_ID == "529" || COMPANY_ID == "508" || COMPANY_ID == "525" || COMPANY_ID == "747")
                    {
                        INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(INDIVIDUAL_ITEM_INVOICE_VALUE / Convert.ToDouble(ITEM_PER), 5);
                    }
                    else
                    {
                        INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(INDIVIDUAL_ITEM_INVOICE_VALUE / Convert.ToDouble(ITEM_PER), 2);
                    }
                     * */

                    INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(INDIVIDUAL_ITEM_INVOICE_VALUE / Convert.ToDouble(ITEM_PER), 5);

                    double item_amt = Convert.ToDouble(ITEM_AMOUNT) / Convert.ToDouble(ITEM_PER);
                    ITEM_AMOUNT = Convert.ToString((item_amt).ToString("0.00"));

                    ITEM_SCHEME_CODE = dss.Tables[0].Rows[b]["ITEM_SCHEME_CODE"].ToString();
                    ITEM_ACCESSORIES_DESC = dss.Tables[0].Rows[b]["ITEM_ACCESSORIES_DESC"].ToString();

                    //---------------------------AR4 DETAILS------------------------------------------//
                    ITEM_AR4_NO = dss.Tables[0].Rows[b]["ITEM_AR4_NO"].ToString();

                    ITEM_AR4_DATE = dss.Tables[0].Rows[b]["ITEM_AR4_DATE"].ToString();
                    if (ITEM_AR4_DATE == "01/01/1900" || ITEM_AR4_DATE == "01-01-1900")
                    {
                        ITEM_AR4_DATE = string.Empty;
                    }

                    ITEM_COMMISSION_RATE = dss.Tables[0].Rows[b]["ITEM_COMMISSION_RATE"].ToString();
                    ITEM_DIVISION = dss.Tables[0].Rows[b]["ITEM_DIVISION"].ToString();
                    ITEM_RANGE = dss.Tables[0].Rows[b]["ITEM_RANGE"].ToString();
                    ITEM_REMARKS = dss.Tables[0].Rows[b]["ITEM_REMARKS"].ToString();

                    ENDUSE_ITEM = dss.Tables[0].Rows[b]["ENDUSE_ITEM"].ToString();
                    IGST_PAYMENT = dss.Tables[0].Rows[b]["IGST_PAYMENT"].ToString();
                    IGST_RATE = dss.Tables[0].Rows[b]["IGST_RATE"].ToString();

                    //---------------------------- ITEM MANUFACTURE SW DETAILS ------------------------------//

                    MANUFACTURER_PRODUCER = dss.Tables[0].Rows[b]["MANUFACTURER_PRODUCER"].ToString();
                    M_P_GROWER_CODE = dss.Tables[0].Rows[b]["M_P_GROWER_CODE"].ToString();
                    M_P_GROWER_ADD1 = dss.Tables[0].Rows[b]["M_P_GROWER_ADD1"].ToString();
                    M_P_GROWER_ADD2 = dss.Tables[0].Rows[b]["M_P_GROWER_ADD2"].ToString();
                    M_P_GROWER_CITY = dss.Tables[0].Rows[b]["M_P_GROWER_CITY"].ToString();
                    M_P_GROWER_COUNTRY_SUBDIV = dss.Tables[0].Rows[b]["M_P_GROWER_COUNTRY_SUBDIV"].ToString();
                    M_P_GROWER_PIN = dss.Tables[0].Rows[b]["M_P_GROWER_PIN"].ToString();
                    M_P_GROWER_COUNTRY = dss.Tables[0].Rows[b]["M_P_GROWER_COUNTRY"].ToString();
                    SOURCE_STATE = dss.Tables[0].Rows[b]["SOURCE_STATE"].ToString();
                    TRANSIT_COUNTRY = dss.Tables[0].Rows[b]["TRANSIT_COUNTRY"].ToString();
                    ACCESSORY_STATUS = dss.Tables[0].Rows[b]["ACCESSORY_STATUS"].ToString();
                    HAWB_NO = dss.Tables[0].Rows[b]["HAWB_NO"].ToString();
                    TOTAL_PKGS = dss.Tables[0].Rows[b]["TOTAL_PKGS"].ToString();

                    ITEM_IECCODE = dss.Tables[0].Rows[b]["ITEM_IECCODE"].ToString();
                    BR_SLNO = dss.Tables[0].Rows[b]["BR_SLNO"].ToString();

                    ADDRESS1 = dss.Tables[0].Rows[b]["ADDRESS1"].ToString();
                    ADDRESS2 = dss.Tables[0].Rows[b]["ADDRESS2"].ToString();
                    ADDRESS3 = dss.Tables[0].Rows[b]["ADDRESS3"].ToString();
                    ADDRESS4 = dss.Tables[0].Rows[b]["ADDRESS4"].ToString();
                    ADDRESS5 = dss.Tables[0].Rows[b]["ADDRESS5"].ToString();
                    ITEM_STR_CODE = dss.Tables[0].Rows[b]["ITEM_STR_CODE"].ToString();
                    REWARD_POINTS = dss.Tables[0].Rows[b]["REWARD_POINTS"].ToString();

                    PMV_METHOD = dss.Tables[0].Rows[b]["PMV_METHOD"].ToString();
                    PMV_RATE = dss.Tables[0].Rows[b]["PMV_RATE"].ToString();
                    PMV_PER_UNIT = dss.Tables[0].Rows[b]["PMV_PER_UNIT"].ToString();

                    RODTEP = dss.Tables[0].Rows[b]["RODTEP"].ToString();
                    CESS_YN = dss.Tables[0].Rows[b]["CESS_YN"].ToString();


                    if (ITEM_SCHEME_CODE != "")
                    {
                        string[] s1 = ITEM_SCHEME_CODE.Split(new string[] { "-" }, StringSplitOptions.None);
                        ITEM_SCHEME_CODE = s1[0].ToString();
                        ITEM_SCHEME_DESC = s1[1].ToString();
                    }
                    else
                    {
                        ITEM_SCHEME_CODE = "0";
                        ITEM_SCHEME_DESC = string.Empty;
                    }
                    //---------------------------------------PMV VALUE ITEM CALCULATION--------------------------------------//

                    IND_INVOICE_VALUE = 0;
                    IND_FREIGHT_AMOUNT = 0;
                    IND_INSURANCE_AMOUNT = 0;
                    IND_PACKING_AMOUNT = 0;
                    IND_PMV_VALUE = 0;
                    IND_TOTAL_PMV_VALUE = 0;
                    IND_PER_QTY = 0;


                    ITEM_QTY = dss.Tables[0].Rows[b]["ITEM_QTY"].ToString();
                    ITEM_UNIT_PRICE = dss.Tables[0].Rows[b]["ITEM_UNIT_PRICE"].ToString();
                    ITEM_PER = dss.Tables[0].Rows[b]["ITEM_PER"].ToString();

                    TOTAL_ITEM_INV_VALUE = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);

                    TOTAL_ITEM_PMVVALUE = Math.Round(Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(EXCHANGE_RATE), 2);
                    IND_INVOICE_VALUE = Math.Round(Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(EXCHANGE_RATE), 2);
                    IND_FREIGHT_AMOUNT = Math.Round(IND_INVOICE_VALUE / TOTAL_ITEM_INV_VALUE * TOTAL_FREIGHT_AMOUNT, 2);
                    IND_INSURANCE_AMOUNT = Math.Round(IND_INVOICE_VALUE / TOTAL_ITEM_INV_VALUE * TOTAL_INSURANCE_AMOUNT, 2);

                    IND_PACKING_AMOUNT = Math.Round(IND_INVOICE_VALUE / TOTAL_ITEM_INV_VALUE * TOTAL_PACKING_AMOUNT, 2);
                    IND_PER_QTY = Convert.ToDouble(ITEM_PER);
                    if (WHEATHER_UNIT_PRICE == "N")
                    {
                        IND_PACKING_AMOUNT = IND_PACKING_AMOUNT / Convert.ToDouble(ITEM_QTY) * 1.1;
                        IND_PMV_VALUE = (Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(EXCHANGE_RATE)) * 1.1 + IND_PACKING_AMOUNT;
                    }
                    else
                    {
                        IND_PACKING_AMOUNT = IND_PACKING_AMOUNT / Convert.ToDouble(ITEM_QTY) * 1.1;
                        IND_PMV_VALUE = ((Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(EXCHANGE_RATE)) - ((IND_FREIGHT_AMOUNT / Convert.ToDouble(ITEM_QTY)) - (IND_INSURANCE_AMOUNT / Convert.ToDouble(ITEM_QTY)))) * 1.1 + IND_PACKING_AMOUNT;
                    }



                    ITEM_PMVVALUE = IND_PMV_VALUE.ToString();

                    IND_TOTAL_PMV_VALUE = (Math.Round(IND_PMV_VALUE, 2) * Convert.ToDouble(ITEM_QTY)) / IND_PER_QTY;
                    //string a = Convert.ToString(Math.Round(IND_TOTAL_PMV_VALUE, 1).ToString("0.00"));// hide by Chithra on 22/04/2019 - for Oriental Mumbai - suggest by Bala & Ayisha
                    string a = Convert.ToString(Math.Round(IND_TOTAL_PMV_VALUE, 2).ToString("0.00"));

                    TOTAL_PMVVALUE = Convert.ToDouble(a);//Corrected on 26Sep2015


                    //#FOB value - Individually shows in "ITEMS OF EXPORT"
                    string fob = "0.00";


                    if (COMPANY_ID == "1039") // for Vetri Impex on 14/11/2019 by Chithra reqst by Bala sir
                    {
                        fob = Convert.ToString(Get_Total_FOB_Value(INSURANCE_CHARGES, FREIGHT_CHARGES).ToString());
                    }
                    else
                    {
                        fob = Convert.ToString(Math.Round(Get_Total_FOB_Value(INSURANCE_CHARGES, FREIGHT_CHARGES), 2).ToString("0.00"));
                    }


                    //#Common Code Implemented checked with ROYAL
                    //fob = Convert.ToString(Get_Total_FOB_Value(INSURANCE_CHARGES, FREIGHT_CHARGES).ToString());

                    FOB_VALUE = Convert.ToDouble(fob);


                    //----------------------------------- TAXABLE VALUE & IGST RATE & IGST AMT -------------------------------------------------------

                    IGST_AMT1 = Convert.ToDouble(dss.Tables[0].Rows[b]["IGST_AMT"].ToString() == "" ? 0.00 : Convert.ToDouble(dss.Tables[0].Rows[b]["IGST_AMT"].ToString()));
                    TAXABLE_VALUE1 = Convert.ToDouble(dss.Tables[0].Rows[b]["TAXABLE_VALUE"].ToString() == "" ? 0.00 : Convert.ToDouble(dss.Tables[0].Rows[b]["TAXABLE_VALUE"].ToString()));

                    //----------- IGST TAXABLE VALUE, IGST AMT Based on FOB, VALUE - new Implemntation for Tuticorin Clients - by Chithra on 15-07-2020
                    double IGST_RATE1 = Convert.ToDouble(dss.Tables[0].Rows[b]["IGST_RATE"].ToString() == "" ? 0.00 : Convert.ToDouble(dss.Tables[0].Rows[b]["IGST_RATE"].ToString()));
                    if (Request.QueryString["IGST_Calc"] == "FOB")
                    {
                        if (hdn_Taxable_igst_Decimal.Value == "D")
                        {
                            TAXABLE_VALUE = Convert.ToString(Math.Round((INDIVIDUAL_FOB_VALUE), 0).ToString("0.00"));
                            IGST_AMT = Convert.ToString(Math.Round((INDIVIDUAL_FOB_VALUE * IGST_RATE1 / 100), 0).ToString("0.00"));
                        }
                        else
                        {
                            TAXABLE_VALUE = Convert.ToString((INDIVIDUAL_FOB_VALUE).ToString("0.00"));
                            IGST_AMT = Convert.ToString((INDIVIDUAL_FOB_VALUE * IGST_RATE1 / 100).ToString("0.00"));
                        }
                    }
                    else if (Request.QueryString["IGST_Calc"] == "VALUE")
                    {
                        if (hdn_Taxable_igst_Decimal.Value == "D")
                        {
                            TAXABLE_VALUE = Convert.ToString(Math.Round((INDIVIDUAL_ITEM_IGST_BASED_VALUE), 0).ToString("0.00"));
                            IGST_AMT = Convert.ToString(Math.Round((INDIVIDUAL_ITEM_IGST_BASED_VALUE * IGST_RATE1 / 100), 0).ToString("0.00"));
                        }
                        else
                        {
                            TAXABLE_VALUE = Convert.ToString((INDIVIDUAL_ITEM_IGST_BASED_VALUE).ToString("0.00"));
                            IGST_AMT = Convert.ToString((INDIVIDUAL_ITEM_IGST_BASED_VALUE * IGST_RATE1 / 100).ToString("0.00"));
                        }
                    }
                    else
                    {
                        if (COMPANY_ID == "1242")
                        {
                            //Perhaps, this is also a solution :
                            //var integer = int.Parse(TAXABLE_VALUE1.ToString().Split('.').First());
                            //done by Chithra on 28-07-2021 for Two Birds sugg.by Mohmed - TAXABLE VALUE should be interger confirmed with Final print
                            int TAXABLE_VALUE_int = (int)Math.Truncate(double.Parse(TAXABLE_VALUE1.ToString()));
                            TAXABLE_VALUE = Convert.ToString(TAXABLE_VALUE_int);
                        }
                        else
                        {
                            if (hdn_Taxable_igst_Decimal.Value == "D")
                            {
                                TAXABLE_VALUE = Convert.ToString(Math.Round((TAXABLE_VALUE1), 0).ToString("0.00"));
                            }
                            else
                            {
                                TAXABLE_VALUE = Convert.ToString((TAXABLE_VALUE1).ToString("0.00"));
                            }
                        }


                        if (hdn_Taxable_igst_Decimal.Value == "D")
                        {
                            IGST_AMT = Convert.ToString(Math.Round((IGST_AMT1), 0).ToString("0.00"));
                        }
                        else
                        {
                            IGST_AMT = Convert.ToString((IGST_AMT1).ToString("0.00"));
                        }
                    }

                    SUM_TOTAL_TAXABLE_VALUE = SUM_TOTAL_TAXABLE_VALUE + Convert.ToDouble(TAXABLE_VALUE);
                    SUM_TOTAL_IGST_AMT = SUM_TOTAL_IGST_AMT + Convert.ToDouble(IGST_AMT);

                    if (IGST_PAYMENT == "P")
                    {
                        IGST_PAYMENT = IGST_PAYMENT + "(" + IGST_RATE1 + "%)";
                    }

                    //--------------------------------------------------------------------------------------------------------------------------------------

                    // this Condition done by chithra on 14-01-2020 for Agility & Safeclearing PMV rate Calc - put general calc
                    double PMV_RATE_calc = 0.00;
                    if (!String.IsNullOrEmpty(PMV_RATE))
                    {
                        PMV_RATE_calc = Convert.ToDouble(PMV_RATE);
                    }
                    else
                    {
                        PMV_RATE_calc = 110;
                    }

                    //-----------------New PMV Calculation on 28Dec2016----------------//

                    double item_pmv1 = 0.00;
                    // this Line hide by chithra on 14-01-2020 for Agility PMV rate Calc - put general calc
                    //TOTAL_PMVVALUE = Convert.ToDouble(INDIVIDUAL_FOB_VALUE * 110 / 100);

                    //TOTAL_PMVVALUE = Convert.ToDouble(INDIVIDUAL_FOB_VALUE * PMV_RATE_calc / 100);//25-06-2024
                    TOTAL_PMVVALUE = Convert.ToDouble(Math.Round(INDIVIDUAL_FOB_VALUE, 2) * PMV_RATE_calc / 100);

                    item_pmv1 = TOTAL_PMVVALUE / Convert.ToDouble(ITEM_QTY);
                    ITEM_PMVVALUE = Convert.ToString(Math.Round(item_pmv1 / IND_PER_QTY, 2));

                    //-----------------New PMV Calculation on 28Dec2016----------------//

                    if (PMV_METHOD == "Amt")
                    {
                        TOTAL_PMVVALUE = Convert.ToDouble(dss.Tables[0].Rows[b]["ITEM_PMVVALUE"].ToString());
                        ITEM_PMVVALUE = Convert.ToString(Convert.ToDouble(TOTAL_PMVVALUE) / Convert.ToDouble(ITEM_QTY));
                    }
                    else if (PMV_METHOD == "Unit" || PMV_METHOD == "PerUnit")
                    {
                        TOTAL_PMVVALUE = Convert.ToDouble(dss.Tables[0].Rows[b]["ITEM_PMVVALUE"].ToString());
                        ITEM_PMVVALUE = Convert.ToString(Convert.ToDouble(PMV_PER_UNIT)); //this condition implmtd for Agility on 24-07-2020 sugg by Bala sir..
                    }

                    //----------Implemented ON 04Mar2016 for Boxco Logistics Kolkatta Branch------------//

                    if (COMPANY_ID == "116")
                    {
                        if (currentbranch == "ACC, Kolkata" || currentbranch == "CusHouse, Kolkata" || currentbranch == "ICD,Petrapole")
                        {
                            TOTAL_PMVVALUE = Convert.ToDouble(dss.Tables[0].Rows[b]["ITEM_PMVVALUE"].ToString());

                            ITEM_PMVVALUE = Convert.ToString(Convert.ToDouble(TOTAL_PMVVALUE) / Convert.ToDouble(ITEM_QTY));
                        }
                    }
                    //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//
                    else if (COMPANY_ID == "233" || COMPANY_ID == "442" || COMPANY_ID == "438" || COMPANY_ID == "436" || COMPANY_ID == "443" || COMPANY_ID == "435" || COMPANY_ID == "434" || COMPANY_ID == "402" || COMPANY_ID == "459" || COMPANY_ID == "444" || COMPANY_ID == "457" || COMPANY_ID == "470" || COMPANY_ID == "477" || COMPANY_ID == "478" || COMPANY_ID == "479" || COMPANY_ID == "488" || COMPANY_ID == "492" || COMPANY_ID == "525" || COMPANY_ID == "538" || COMPANY_ID == "539" || COMPANY_ID == "571")
                    {
                        if (dss.Tables[0].Rows[b]["ITEM_PMVVALUE"].ToString() != "") // condition for check PMV or Normal by Chithra on 01-05-2018
                        {
                            TOTAL_PMVVALUE = Convert.ToDouble(dss.Tables[0].Rows[b]["ITEM_PMVVALUE"].ToString());

                            ITEM_PMVVALUE = Convert.ToString(Convert.ToDouble(TOTAL_PMVVALUE) / Convert.ToDouble(ITEM_QTY));
                        }
                    }
                    //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//

                    //----------Implemented ON 04Mar2016 for Boxco Logistics Kolkatta Branch------------//

                    // --------------------------------------- STR CALCULATION---------------------------------------------------------------


                    #region Get_Calc_Rates_from_ITEM_ADDITIONAL_Table

                    if (dt_item_Addl.Rows.Count > 0)
                    {
                        DataView view_addl = dt_item_Addl.DefaultView;
                        view_addl.RowFilter = "ITEM_SLNO = " + ITEM_SLNO + " and " + "INVOICE_SLNO = " + curINVOICE_SLNO;
                        DataTable dt_table1 = view_addl.ToTable();
                        if (dt_table1.Rows.Count > 0)
                        {

                            STR_RATE = dt_table1.Rows[0]["STR_RATE"].ToString();
                            RODTEP_RATE = dt_table1.Rows[0]["RODTEP_RATE"].ToString();
                            RODTEP_CAP = dt_table1.Rows[0]["RODTEP_CAP"].ToString();
                        }
                    }
                    #endregion



                    if (Is_STR == 2)
                    {
                        if (ITEM_STR_CODE != "")
                        {

                            if (SB_NO == "" || STR_RATE == "")
                            {
                                DataView view_STR = dt_All_Rates.Tables[0].DefaultView;
                                view_STR.RowFilter = "STR_SRNO = " + ITEM_STR_CODE;
                                DataTable STR_table1 = view_STR.ToTable();

                                if (STR_table1.Rows.Count > 0)
                                {
                                    STR_RATE = STR_table1.Rows[0]["STR_RATE"].ToString();
                                }
                            }

                            STR_AMOUNT = Convert.ToString(Convert.ToDouble(STR_RATE) * Convert.ToDouble(FOB_VALUE) / 100);
                            STR_AMOUNT = Convert.ToString(Math.Round(Convert.ToDouble(STR_AMOUNT), 1).ToString("0.00"));

                            //-----------------------------STR LIST START------------------------------//

                            Rpt_STR_Details_list.Add(new Report_Export_Export_ReportViewer()
                            {

                                INVOICE_SLNO = INVOICE_SLNO,
                                INVOICE_NO = INVOICE_NO,
                                ITEM_SLNO = ITEM_SLNO,
                                ITEM_STR_CODE = ITEM_STR_CODE,
                                STR_RATE = STR_RATE,
                                STR_AMOUNT = STR_AMOUNT,
                                // TOTAL_STR_AMOUNT =Math.Round(TOTAL_STR_AMOUNT+Convert.ToDouble(STR_AMOUNT),2),
                                TOTAL_STR_AMOUNT = STR_AMOUNT

                            });
                        }
                        else
                        {
                            STR_RATE = "";
                        }
                    }
                    else
                    {

                        Rpt_STR_Details_list.Add(new Report_Export_Export_ReportViewer()
                        {

                            INVOICE_SLNO = "",
                            INVOICE_NO = "",
                            ITEM_SLNO = "",
                            //ITEM_STR_CODE = ITEM_STR_CODE,
                            STR_RATE = "",
                            STR_AMOUNT = STR_AMOUNT,
                            TOTAL_STR_AMOUNT = "0.00"

                        });
                    }
                    //-----------------------------STR LIST END ------------------------------//


                    // --------------------------------------- CESS CALCULATION---------------------------------------------------------------
                    if (CESS_YN == "Y")
                    {

                        DataView view_cess = dt_cess.DefaultView;
                        view_cess.RowFilter = "ITEM_SLNO = " + ITEM_SLNO + " and " + "INVOICE_SLNO = " + curINVOICE_SLNO;
                        DataTable cess_table1 = view_cess.ToTable();

                        CESS_AMOUNT = "0.00";
                        int ci = 0;

                        if (cess_table1.Rows.Count >= i && cess_table1.Rows.Count != 0)
                        {
                            CESS_SLNO = cess_table1.Rows[ci]["CESS_SLNO"].ToString();
                            CESS_VALUE = cess_table1.Rows[ci]["CESS_VALUE"].ToString();
                            CESS_UNIT = cess_table1.Rows[ci]["CESS_UNIT"].ToString();
                            CESS_FLAG = cess_table1.Rows[ci]["CESS_FLAG"].ToString();
                            CESS_RATE = cess_table1.Rows[ci]["CESS_RATE"].ToString();
                            CESS_ITEM_QTY = cess_table1.Rows[ci]["CESS_ITEM_QTY"].ToString();
                            CESS_ITEM_QTY_CODE = cess_table1.Rows[ci]["CESS_ITEM_QTY_CODE"].ToString();
                            CESS_TARIFF_VALUE = cess_table1.Rows[ci]["CESS_TARIFF_VALUE"].ToString();
                            CESS_TARIFF_UNIT = cess_table1.Rows[ci]["CESS_TARIFF_UNIT"].ToString();

                            if ((CESS_TARIFF_VALUE == "") && (CESS_RATE != ""))
                            {
                                CESS_AMOUNT = Convert.ToString(Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(CESS_RATE) / 100);
                                CESS_AMOUNT = Convert.ToString(Math.Round(Convert.ToDouble(CESS_AMOUNT), 2).ToString("0.00"));
                            }
                            else
                            {
                                if (CESS_TARIFF_VALUE != "")
                                {
                                    CESS_AMOUNT = Convert.ToString(Convert.ToDouble(CESS_ITEM_QTY) * (Convert.ToDouble(CESS_TARIFF_VALUE) * Convert.ToDouble(CESS_RATE)) / 100);
                                    CESS_AMOUNT = Convert.ToString(Math.Round(Convert.ToDouble(CESS_AMOUNT), 2).ToString("0.00"));
                                }
                            }

                            Rpt_CESS_Details_list.Add(new Report_Export_Export_ReportViewer()
                            {

                                INVOICE_SLNO = INVOICE_SLNO,
                                INVOICE_NO = INVOICE_NO,
                                ITEM_SLNO = ITEM_SLNO,
                                CESS_SLNO = CESS_SLNO,
                                CESS_VALUE = CESS_VALUE,
                                CESS_UNIT = CESS_UNIT,
                                CESS_FLAG = CESS_FLAG,
                                CESS_RATE = CESS_RATE,
                                CESS_ITEM_QTY = CESS_ITEM_QTY,
                                CESS_ITEM_QTY_CODE = CESS_ITEM_QTY_CODE,
                                CESS_TARIFF_VALUE = CESS_TARIFF_VALUE,
                                CESS_TARIFF_UNIT = CESS_TARIFF_UNIT,
                                CESS_AMOUNT = CESS_AMOUNT

                            });
                        }
                    }

                    //-----------------------------CESS LIST END ------------------------------//


                    ////// ---------------------------------------START RODTEP CALCULATION---------------------------------------------------------------

                    #region RODTEP
                    if (RODTEP == "Y")
                    {
                        string RODTEP_4RE = "";
                        DataTable dt_RODTEP = new DataTable();
                        int Load_RODTEP = 1;
                        string SBDate = "";

                        if (SB_NO != "")
                        {
                            string[] ssp = SB_NO.Split('~');
                            SBDate = ssp[1];

                            DateTime _SBDate;
                            string compareDate_SbDate1 = "25/02/2026";
                            _SBDate = Convert.ToDateTime(SBDate);

                            if (Convert.ToDateTime(compareDate_SbDate1) <= _SBDate)
                            {
                                Load_RODTEP = 2;//Bind New rates
                            }
                        }
                        else
                        {
                            Load_RODTEP = 2;//Bind New rates
                        }

                        if (Load_RODTEP == 2)//New Rates
                        {
                            if (ITEM_SCHEME_CODE == "01" || ITEM_SCHEME_CODE == "02" || ITEM_SCHEME_CODE == "03" || ITEM_SCHEME_CODE == "05" || ITEM_SCHEME_CODE == "17" || ITEM_SCHEME_CODE == "21" || ITEM_SCHEME_CODE == "25" || ITEM_SCHEME_CODE == "26" || ITEM_SCHEME_CODE == "50" || (ITEM_SCHEME_CODE != "19" && SB_TYPE == "SEZ")) // && Conditiona added by pandiyan on 15-05-2025
                            {
                                DataView view_RODTEP = dt_All_Rates.Tables[3].DefaultView;
                                view_RODTEP.RowFilter = "RODTEP_TARIFF = " + RITCNO;
                                dt_RODTEP = view_RODTEP.ToTable();
                                RODTEP_4RE = "Y";
                            }
                            else
                            {
                                DataView view_RODTEP = dt_All_Rates.Tables[2].DefaultView;
                                view_RODTEP.RowFilter = "RODTEP_TARIFF = " + RITCNO;
                                dt_RODTEP = view_RODTEP.ToTable();
                            }
                        }
                        else
                        {
                            if (ITEM_SCHEME_CODE == "01" || ITEM_SCHEME_CODE == "02" || ITEM_SCHEME_CODE == "03" || ITEM_SCHEME_CODE == "05" || ITEM_SCHEME_CODE == "17" || ITEM_SCHEME_CODE == "21" || ITEM_SCHEME_CODE == "25" || ITEM_SCHEME_CODE == "26" || ITEM_SCHEME_CODE == "50" || (ITEM_SCHEME_CODE != "19" && SB_TYPE == "SEZ")) // && Conditiona added by pandiyan on 15-05-2025
                            {
                                DataView view_RODTEP = dt_All_Rates.Tables[5].DefaultView; //EXPORT_RODTEP_MASTER_4RE_bck_25_02_2026 
                                view_RODTEP.RowFilter = "RODTEP_TARIFF = " + RITCNO;
                                dt_RODTEP = view_RODTEP.ToTable();
                                RODTEP_4RE = "Y";
                            }
                            else
                            {
                                DataView view_RODTEP = dt_All_Rates.Tables[4].DefaultView; //EXPORT_RODTEP_MASTER_bck_25_02_2026
                                view_RODTEP.RowFilter = "RODTEP_TARIFF = " + RITCNO;
                                dt_RODTEP = view_RODTEP.ToTable();
                            }
                        }



                        if (dt_RODTEP.Rows.Count > 0)
                        {
                            RODTEP_TARIFF = dt_RODTEP.Rows[0]["RODTEP_TARIFF"].ToString();
                            RODTEP_DESC = dt_RODTEP.Rows[0]["RODTEP_DESC"].ToString();
                            RODTEP_UQC = dt_RODTEP.Rows[0]["RODTEP_UQC"].ToString();

                            if (SB_NO == "" || RODTEP_RATE == "")
                            {
                                RODTEP_RATE = dt_RODTEP.Rows[0]["RODTEP_RATE"].ToString();
                            }

                            if (SB_NO == "" || RODTEP_CAP == "")
                            {
                                RODTEP_CAP = dt_RODTEP.Rows[0]["RODTEP_CAP"].ToString();
                            }

                            DataView view_sw = dt_sw_info.DefaultView;
                            view_sw.RowFilter = "ITEM_SLNO = " + ITEM_SLNO + " and " + "INVOICE_SLNO = " + curINVOICE_SLNO;
                            DataTable table_sw = view_sw.ToTable();

                            // Added by pandiyan on 25-05-2026 due to Rodtep calculation 
                            DataView view_Rodtep = dt_item_Rodtep.DefaultView;
                            view_Rodtep.RowFilter = "ITEM_SLNO = " + ITEM_SLNO + " and " + "INVOICE_SLNO = " + curINVOICE_SLNO;
                            DataTable table_Rodtep = view_Rodtep.ToTable();

                            DataTable sw_RDT = new DataTable();
                            var FullName1 = from DataRow drr in table_sw.AsEnumerable()
                                            where drr.Field<string>("INFO_QUALIFIER") == "RDT"
                                            select drr;

                            DataView dvv = FullName1.AsDataView();

                            if (dvv.Count > 0)
                            {
                                sw_RDT = FullName1.CopyToDataTable();

                            }

                            if (table_Rodtep.Rows.Count > 0)// Added by pandiyan on 25-05-2026 due to Rodtep calculation 
                            {
                                RODTEP_QTY = table_Rodtep.Rows[0]["ITEM_QTY"].ToString();
                                RODTEP_UQC = table_Rodtep.Rows[0]["ITEM_QTY_CODE"].ToString();
                            }
                            else if (sw_RDT.Rows.Count > 0)
                            {
                                RODTEP_QTY = sw_RDT.Rows[0]["INFO_MSR"].ToString();
                                RODTEP_UQC = sw_RDT.Rows[0]["INFO_UQC"].ToString();
                            }
                            //else
                            //{
                            //    RODTEP_QTY = ITEM_QTY;
                            //}

                            if (RODTEP_RATE == "")
                            {
                                RODTEP_RATE = "0";
                            }
                            if (RODTEP_CAP == "")
                            {
                                RODTEP_CAP = "0";
                            }

                            if (RODTEP_4RE == "" || RODTEP_4RE == "Y") // RODTEP_4RE == "Y" Condition Addded by pandiyan on 30-05-2025 sugg by bala
                            {
                                cal1 = Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(RODTEP_RATE) / 100;

                                if (Convert.ToDouble(RODTEP_CAP) > 0)
                                {
                                    //cal2 = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(RODTEP_CAP);
                                    cal2 = Convert.ToDouble(RODTEP_QTY) * Convert.ToDouble(RODTEP_CAP);
                                }

                                if (Convert.ToDouble(RODTEP_CAP) > 0)
                                {
                                    if (Convert.ToDouble(RODTEP_RATE) > 0)
                                    {
                                        if (cal1 > cal2)
                                        {
                                            RODTEP_VAL = cal2;
                                        }
                                        else
                                        {
                                            RODTEP_VAL = cal1;
                                        }
                                    }
                                    else
                                    {
                                        RODTEP_VAL = cal2;
                                    }
                                }
                                else
                                {
                                    RODTEP_VAL = cal1;
                                }
                            }
                            else
                            {
                                RODTEP_VAL = 0.00;
                            }

                            /* hide on 14-10-2021 by chithra Sugg.by Bala sir
                            if (RODTEP_VAL <= 50)
                            {
                                RODTEP_VAL = 0.00;
                            }
                            */


                            /* hide on 23-10-2024 for Rounded value Below Implemented checked with Final Copy - Sugg.by Bala sir
                            string RODTEP1 = Convert.ToString(Math.Round(RODTEP_VAL, 2).ToString("0.00"));
                            RODTEP_VALUE = RODTEP1;
                             * */

                            //Checked with Final Print on 23-10-2024 for LEO FORWARDERS
                            RODTEP_VALUE = Convert.ToString(Math.Round(RODTEP_VAL, 0).ToString("0.00"));

                            string TOTAL_RODTEP = Convert.ToString(Math.Round(TOTAL_RODTEP_VALUE + Convert.ToDouble(RODTEP_VALUE), 2).ToString("0.00"));
                            TOTAL_RODTEP_VALUE = Convert.ToDouble(TOTAL_RODTEP);


                            //-----------------------------RODTEP LIST ------------------------------//
                            Rpt_RODTEP_Details_list.Add(new Report_Export_Export_ReportViewer()
                            {
                                INVOICE_SLNO = INVOICE_SLNO,
                                INVOICE_NO = INVOICE_NO,
                                ITEM_SLNO = ITEM_SLNO,
                                RODTEP_TARIFF = RODTEP_TARIFF,
                                RODTEP_DESC = RODTEP_DESC,
                                RODTEP_RATE = RODTEP_RATE,
                                RODTEP_UQC = RODTEP_UQC,
                                RODTEP_CAP = RODTEP_CAP,
                                RODTEP_VALUE = RODTEP_VALUE,
                                TOTAL_RODTEP_VALUE = TOTAL_RODTEP_VALUE,
                                RODTEP_QTY = RODTEP_QTY

                            });
                        }
                    }
                    else
                    {
                        RODTEP_RATE = "";
                        RODTEP_CAP = "";
                    }
                    #endregion RODTEP
                    // ---------------------------------------END RODTEP CALCULATION---------------------------------------------------------------

                    // ---------------------------------------START DRAWBACK CALCULATION---------------------------------------------------------------
                    DataView view1 = dt.DefaultView;
                    view1.RowFilter = "ITEM_SLNO = " + ITEM_SLNO + " and " + "INVOICE_SLNO = " + curINVOICE_SLNO;
                    DataTable table1 = view1.ToTable();
                 
                    if (table1.Rows.Count >= i && table1.Rows.Count != 0)
                    {
                        //JOBNO = dt.Rows[i]["JOBNO"].ToString();
                        //INVOICE_SLNO = dt.Rows[i]["INVOICE_SLNO"].ToString();
                        //ITEM_SLNO = dt.Rows[i]["ITEM_SLNO"].ToString();
                        DRAWBACK_SLNO = table1.Rows[i]["DRAWBACK_SLNO"].ToString();
                        DRAWBACK_QTY = table1.Rows[i]["DRAWBACK_QTY"].ToString();
                        DRAWBACK_UNIT = table1.Rows[i]["DRAWBACK_UNIT"].ToString();
                        DRAWBACK_NOOFUNITS = table1.Rows[i]["DRAWBACK_NOOFUNITS"].ToString();
                        DRAWBACK_RATE = table1.Rows[i]["DRAWBACK_RATE"].ToString();
                        DRAWBACK_CAPS = table1.Rows[i]["DRAWBACK_CAPS"].ToString();
                        //DRAWBACK_ID = dt.Rows[i]["DRAWBACK_ID"].ToString();
                        SCHEME_CODE = table1.Rows[i]["SCHEME_CODE"].ToString();


                        if (SCHEME_CODE != "")
                        {
                            string[] s1 = SCHEME_CODE.Split(new string[] { "-" }, StringSplitOptions.None);
                            SCHEME_CODE_LEV = s1[0].ToString();
                        }

                        DRAWBACK_DESC = dt.Rows[i]["DRAWBACK_DESC"].ToString();

                        STATE_LEVEL_ADV_RATE = table1.Rows[i]["STATE_LEVEL_ADV_RATE"].ToString() == string.Empty ? "0.00" : table1.Rows[i]["STATE_LEVEL_ADV_RATE"].ToString();
                        STATE_LEVEL_ADV_AMT = table1.Rows[i]["STATE_LEVEL_ADV_AMT"].ToString() == string.Empty ? "0.00" : table1.Rows[i]["STATE_LEVEL_ADV_AMT"].ToString();

                        CENTRAL_LEVEL_ADV_RATE = table1.Rows[i]["CENTRAL_LEVEL_ADV_RATE"].ToString() == string.Empty ? "0.00" : table1.Rows[i]["CENTRAL_LEVEL_ADV_RATE"].ToString();
                        CENTRAL_LEVEL_ADV_AMT = table1.Rows[i]["CENTRAL_LEVEL_ADV_AMT"].ToString() == string.Empty ? "0.00" : table1.Rows[i]["CENTRAL_LEVEL_ADV_AMT"].ToString();


                        if (DRAWBACK_SLNO != "")
                        {

                            DataTable dt_DBK1 = new DataTable();
                            var Selct_linq = from DataRow drr in dt_All_Rates.Tables[1].AsEnumerable()
                                             where drr.Field<string>("DRAWBACK_SLNO") == DRAWBACK_SLNO
                                             select drr;

                            DataView dvv = Selct_linq.AsDataView();

                            if (dvv.Count > 0)
                            {
                                dt_DBK1 = Selct_linq.CopyToDataTable();
                            }

                            if (dt_DBK1.Rows.Count > 0)
                            {
                                DRAWBACK_CUSTOMS = dt_DBK1.Rows[0]["DRAWBACK_CUSTOMS"].ToString();
                                DRAWBACK_EXCISE = dt_DBK1.Rows[0]["DRAWBACK_EXCISE"].ToString();
                            }

                            // ---------------------------------------START DRAWBACK CALCULATION---------------------------------------------------------------

                            cal1 = Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(DRAWBACK_RATE) / 100;
                            if (DRAWBACK_CAPS == "")
                            {
                                DRAWBACK_CAPS = "0";
                            }
                            if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
                            {
                                if (DRAWBACK_NOOFUNITS == "")
                                {
                                    DRAWBACK_NOOFUNITS = "0";
                                }

                                if (DRAWBACK_NOOFUNITS != "0")
                                {
                                    cal2 = (Convert.ToDouble(DRAWBACK_QTY) * Convert.ToDouble(DRAWBACK_CAPS)) / Convert.ToDouble(DRAWBACK_NOOFUNITS);
                                }
                                else
                                {
                                    cal2 = Convert.ToDouble(DRAWBACK_QTY) * Convert.ToDouble(DRAWBACK_CAPS);
                                }
                            }

                            if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
                            {
                                if (Convert.ToDouble(DRAWBACK_RATE) > 0)
                                {
                                    if (cal1 > cal2)
                                    {
                                        DRAWBACK_VAL = cal2;
                                    }
                                    else
                                    {
                                        DRAWBACK_VAL = cal1;
                                    }
                                }
                                else
                                {
                                    DRAWBACK_VAL = cal2;
                                }

                            }
                            else
                            {
                                DRAWBACK_VAL = cal1;
                            }

                            // -------------Start Implemented on 21Mar2018 with Bala------------------//
                            if (DRAWBACK_VAL <= 50)
                            {
                                DRAWBACK_VAL = 0.00;
                            }
                            // -------------End Implemented on 21Mar2018 with Bala------------------//


                            //FOB_VALUE = FOB_VALUE + FOB_VAL;
                            //DBK_VALUE = DBK_VALUE + DRAWBACK_VAL;
                            //string DBK = Convert.ToString(Math.Round(DRAWBACK_VAL, 1).ToString("0.00"));// hide by Chithra on 22/04/2019 - for Oriental Mumbai - suggest by Bala & Ayisha
                            string DBK = Convert.ToString(Math.Round(DRAWBACK_VAL, 2).ToString("0.00"));
                            //DBK_VALUE = Convert.ToDouble(DBK);
                            DBK_VALUE = DBK;
                            // DBK_VALUE = Math.Round(DRAWBACK_VAL, 2);

                            // ---------------------------------------END DRAWBACK CALCULATION---------------------------------------------------------------


                            // ---------------------------------------START ROSL CALCULATION IMPLEMENTED ON 20SEP2016---------------------------------------------------------------

                            TOT_LEV_AMT = "";

                            //if (SCHEME_CODE_LEV == "60" || SCHEME_CODE_LEV == "61" || SCHEME_CODE_LEV == "62" || SCHEME_CODE_LEV == "63" || SCHEME_CODE_LEV == "64" || SCHEME_CODE_LEV == "65")
                            if (SCHEME_CODE_LEV == "60" || SCHEME_CODE_LEV == "61" || SCHEME_CODE_LEV == "64" || SCHEME_CODE_LEV == "65")
                            {

                                cal3 = Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(STATE_LEVEL_ADV_RATE) / 100;
                                //LEV_VALUE = cal3; // hide  for Levy Amt add with  ROSCTL Amt below..

                                //----------------- ROSCTL New Implementation - 27-05-2019 -------------------

                                //cal4 = Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(CENTRAL_LEVEL_ADV_RATE) / 100;
                                //LEV_VALUE = cal3 + cal4;

                                //----------------- ROSCTL New Implementation - 27-05-2019 -------------------

                                if (DRAWBACK_QTY == "") { DRAWBACK_QTY = "0"; }
                                if (Convert.ToDouble(DRAWBACK_QTY) > 0)
                                {
                                    cal4 = Convert.ToDouble(STATE_LEVEL_ADV_AMT) * Convert.ToDouble(DRAWBACK_QTY);
                                }

                                if (Convert.ToDouble(STATE_LEVEL_ADV_AMT) > 0)
                                {
                                    if (Convert.ToDouble(STATE_LEVEL_ADV_RATE) > 0)
                                    {
                                        if (cal3 > cal4)
                                        {
                                            LEV_VALUE_DBK = cal4;
                                        }
                                        else
                                        {
                                            LEV_VALUE_DBK = cal3;
                                        }
                                    }
                                    else
                                    {
                                        LEV_VALUE_DBK = cal4;
                                    }

                                }
                                else
                                {
                                    LEV_VALUE_DBK = cal3;
                                }


                                //----------------- ROSCTL New Implementation - 27-05-2019 -------------------

                                cal5 = Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(CENTRAL_LEVEL_ADV_RATE) / 100;

                                if (DRAWBACK_QTY == "") { DRAWBACK_QTY = "0"; }
                                if (Convert.ToDouble(DRAWBACK_QTY) > 0)
                                {
                                    cal6 = Convert.ToDouble(CENTRAL_LEVEL_ADV_AMT) * Convert.ToDouble(DRAWBACK_QTY);
                                }

                                if (Convert.ToDouble(CENTRAL_LEVEL_ADV_AMT) > 0)
                                {
                                    if (Convert.ToDouble(CENTRAL_LEVEL_ADV_RATE) > 0)
                                    {
                                        if (cal5 > cal6)
                                        {
                                            LEV_VALUE_ROSL = cal6;
                                        }
                                        else
                                        {
                                            LEV_VALUE_ROSL = cal5;
                                        }
                                    }
                                    else
                                    {
                                        LEV_VALUE_ROSL = cal6;
                                    }

                                }
                                else
                                {
                                    LEV_VALUE_ROSL = cal5;
                                }

                                //----------------- ROSCTL New Implementation - 27-05-2019 -------------------

                                LEV_VALUE = LEV_VALUE_DBK + LEV_VALUE_ROSL;

                                //string LEV = Convert.ToString(Math.Round(LEV_VALUE, 1).ToString("0.00"));
                                string LEV = Convert.ToString(Math.Round(LEV_VALUE, 2).ToString("0.00"));// hide by Chithra on 22/04/2019 - for Oriental Mumbai - suggest by Bala & Ayisha
                                TOT_LEV_AMT = LEV;
                                TOT_SUM_LEV_AMT += LEV_VALUE;

                                if (SCHEME_CODE_LEV == "60" || SCHEME_CODE_LEV == "61" || SCHEME_CODE_LEV == "64" || SCHEME_CODE_LEV == "65")
                                {
                                    DECLARATION = "";
                                    DECLARATION = "I declare that, I have not claimed or shall not claim credit/ rebate/ refund/ reimbursement of these specific State Levies under any other mechanism and I am eligible for the rate and rebate claimed for. Further, declare that an Internal Complaints Committee (ICC), where applicable, in pursuance of the Sexual Harassment of Women at Workplace (Prevention, Prohibition and Redressal) Act, 2013 has been constituted.";
                                }
                            }
                            // ---------------------------------------START ROSL CALCULATION IMPLEMENTED ON 20SEP2016---------------------------------------------------------------
                        }
                        else
                        {
                            DRAWBACK_CUSTOMS = string.Empty;
                            DRAWBACK_EXCISE = string.Empty;
                            //FOB_VALUE = FOB_VALUE + FOB_VAL;
                            //DBK_VALUE = DBK_VALUE + DRAWBACK_VAL;
                            //string DBK = Convert.ToString(Math.Round(DRAWBACK_VAL, 1).ToString("0.00"));// hide by Chithra on 22/04/2019 - for Oriental Mumbai - suggest by Bala & Ayisha
                            string DBK = Convert.ToString(Math.Round(DRAWBACK_VAL, 2).ToString("0.00"));
                            //DBK_VALUE = Convert.ToDouble(DBK);
                            DBK_VALUE = DBK;
                            // DBK_VALUE = Math.Round(DRAWBACK_VAL, 2);
                        }
                        //string TOTAL_DBK = Convert.ToString(Math.Round(TOTAL_DBK_VALUE + Convert.ToDouble(DBK_VALUE), 1).ToString("0.00"));// hide by Chithra on 22/04/2019 - for Oriental Mumbai - suggest by Bala & Ayisha
                        string TOTAL_DBK = Convert.ToString(Math.Round(TOTAL_DBK_VALUE + Convert.ToDouble(DBK_VALUE), 2).ToString("0.00"));
                        TOTAL_DBK_VALUE = Convert.ToDouble(TOTAL_DBK);


                        //-----------------------------DRAWBACK LIST ------------------------------//
                        Rpt_DrawBack_Details_list.Add(new Report_Export_Export_ReportViewer()
                        {
                            INVOICE_SLNO = INVOICE_SLNO,
                            INVOICE_NO = INVOICE_NO,
                            ITEM_SLNO = ITEM_SLNO,
                            //DRAWBACK_ID = DRAWBACK_ID,
                            SCHEME_CODE = SCHEME_CODE,
                            DRAWBACK_SLNO = DRAWBACK_SLNO,
                            DRAWBACK_QTY = DRAWBACK_QTY,
                            DRAWBACK_UNIT = DRAWBACK_UNIT,
                            DRAWBACK_NOOFUNITS = DRAWBACK_NOOFUNITS,
                            DRAWBACK_RATE = DRAWBACK_RATE,
                            DRAWBACK_CAPS = DRAWBACK_CAPS,
                            DRAWBACK_DESC = DRAWBACK_DESC,
                            DRAWBACK_CUSTOMS = DRAWBACK_CUSTOMS,
                            DRAWBACK_EXCISE = DRAWBACK_EXCISE,
                            DBK_VALUE = DBK_VALUE,
                            TOTAL_DBK_VALUE = TOTAL_DBK_VALUE,
                            STATE_LEVEL_ADV_RATE = STATE_LEVEL_ADV_RATE,
                            STATE_LEVEL_ADV_AMT = STATE_LEVEL_ADV_AMT,
                            CENTRAL_LEVEL_ADV_RATE = CENTRAL_LEVEL_ADV_RATE,
                            CENTRAL_LEVEL_ADV_AMT = CENTRAL_LEVEL_ADV_AMT,
                            TOT_LEV_AMT = TOT_LEV_AMT

                        });

                        Rpt_Item_Details_new_list.Add(new Report_Export_Export_ReportViewer()
                        {

                            INVOICE_SLNO = INVOICE_SLNO,
                            INVOICE_NO = INVOICE_NO,
                            ITEM_SLNO = ITEM_SLNO,
                            ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                            RITCNO = RITCNO,
                            ITEM_QTY = ITEM_QTY,
                            ITEM_QTY_CODE = ITEM_QTY_CODE,
                            ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                            ITEM_PER = ITEM_PER,
                            ITEM_AMOUNT = ITEM_AMOUNT,
                            ITEM_PMVVALUE = ITEM_PMVVALUE,
                            ITEM_SCHEME_CODE = ITEM_SCHEME_CODE,
                            ITEM_SCHEME_DESC = ITEM_SCHEME_DESC,
                            ITEM_ACCESSORIES_DESC = ITEM_ACCESSORIES_DESC,
                            ITEM_AR4_NO = ITEM_AR4_NO,
                            ITEM_AR4_DATE = ITEM_AR4_DATE,
                            ITEM_COMMISSION_RATE = ITEM_COMMISSION_RATE,
                            ITEM_DIVISION = ITEM_DIVISION,
                            ITEM_RANGE = ITEM_RANGE,
                            ITEM_REMARKS = ITEM_REMARKS,
                            ITEM_IECCODE = ITEM_IECCODE,
                            BR_SLNO = BR_SLNO,
                            ADDRESS1 = ADDRESS1,
                            ADDRESS2 = ADDRESS2,
                            ADDRESS3 = ADDRESS3,
                            ADDRESS4 = ADDRESS4,
                            ADDRESS5 = ADDRESS5,
                            ITEM_STR_CODE = ITEM_STR_CODE,
                            REWARD_POINTS = REWARD_POINTS,
                            FOB_VALUE = FOB_VALUE,
                            TOTAL_PMVVALUE = TOTAL_PMVVALUE,
                            //DRAWBACK_ID = DRAWBACK_ID,
                            SCHEME_CODE = SCHEME_CODE,
                            DRAWBACK_SLNO = DRAWBACK_SLNO,
                            DRAWBACK_QTY = DRAWBACK_QTY,
                            DRAWBACK_UNIT = DRAWBACK_UNIT,
                            DRAWBACK_NOOFUNITS = DRAWBACK_NOOFUNITS,
                            DRAWBACK_RATE = DRAWBACK_RATE,
                            DRAWBACK_CAPS = DRAWBACK_CAPS,
                            DRAWBACK_DESC = DRAWBACK_DESC,
                            DRAWBACK_CUSTOMS = DRAWBACK_CUSTOMS,
                            DRAWBACK_EXCISE = DRAWBACK_EXCISE,
                            DBK_VALUE = DBK_VALUE,

                            STR_RATE = STR_RATE,
                            STR_AMOUNT = STR_AMOUNT,

                            STATE_LEVEL_ADV_RATE = STATE_LEVEL_ADV_RATE,
                            STATE_LEVEL_ADV_AMT = STATE_LEVEL_ADV_AMT,

                            CENTRAL_LEVEL_ADV_RATE = CENTRAL_LEVEL_ADV_RATE,
                            CENTRAL_LEVEL_ADV_AMT = CENTRAL_LEVEL_ADV_AMT,

                            TOT_LEV_AMT = TOT_LEV_AMT,
                            ENDUSE_ITEM = ENDUSE_ITEM,
                            IGST_PAYMENT = IGST_PAYMENT,
                            TAXABLE_VALUE = TAXABLE_VALUE,
                            IGST_AMT = IGST_AMT,
                            IGST_RATE = IGST_RATE,

                            NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS,

                            MANUFACTURER_PRODUCER = MANUFACTURER_PRODUCER,
                            M_P_GROWER_CODE = M_P_GROWER_CODE,
                            M_P_GROWER_ADD1 = M_P_GROWER_ADD1,
                            M_P_GROWER_ADD2 = M_P_GROWER_ADD2,
                            M_P_GROWER_CITY = M_P_GROWER_CITY,
                            M_P_GROWER_COUNTRY_SUBDIV = M_P_GROWER_COUNTRY_SUBDIV,
                            M_P_GROWER_PIN = M_P_GROWER_PIN,
                            M_P_GROWER_COUNTRY = M_P_GROWER_COUNTRY,
                            SOURCE_STATE = SOURCE_STATE,
                            TRANSIT_COUNTRY = TRANSIT_COUNTRY,
                            ACCESSORY_STATUS = ACCESSORY_STATUS,
                            HAWB_NO = HAWB_NO,
                            TOTAL_PKGS = TOTAL_PKGS,
                            ACTUAL_ITEM_FOB_VALUE = ACTUAL_ITEM_FOB_VALUE

                        });

                        //i++;
                    }
                    else
                    {
                        DBK_VALUE = "0.00";
                        Rpt_Item_Details_new_list.Add(new Report_Export_Export_ReportViewer()
                        {

                            INVOICE_SLNO = INVOICE_SLNO,
                            INVOICE_NO = INVOICE_NO,
                            ITEM_SLNO = ITEM_SLNO,
                            ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                            RITCNO = RITCNO,
                            ITEM_QTY = ITEM_QTY,
                            ITEM_QTY_CODE = ITEM_QTY_CODE,
                            ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                            ITEM_PER = ITEM_PER,
                            ITEM_AMOUNT = ITEM_AMOUNT,
                            ITEM_PMVVALUE = ITEM_PMVVALUE,
                            ITEM_SCHEME_CODE = ITEM_SCHEME_CODE,
                            ITEM_SCHEME_DESC = ITEM_SCHEME_DESC,
                            ITEM_ACCESSORIES_DESC = ITEM_ACCESSORIES_DESC,
                            ITEM_AR4_NO = ITEM_AR4_NO,
                            ITEM_AR4_DATE = ITEM_AR4_DATE,
                            ITEM_COMMISSION_RATE = ITEM_COMMISSION_RATE,
                            ITEM_DIVISION = ITEM_DIVISION,
                            ITEM_RANGE = ITEM_RANGE,
                            ITEM_REMARKS = ITEM_REMARKS,
                            ITEM_IECCODE = ITEM_IECCODE,
                            BR_SLNO = BR_SLNO,
                            ADDRESS1 = ADDRESS1,
                            ADDRESS2 = ADDRESS2,
                            ADDRESS3 = ADDRESS3,
                            ADDRESS4 = ADDRESS4,
                            ADDRESS5 = ADDRESS5,
                            ITEM_STR_CODE = ITEM_STR_CODE,
                            REWARD_POINTS = REWARD_POINTS,
                            FOB_VALUE = FOB_VALUE,
                            TOTAL_PMVVALUE = TOTAL_PMVVALUE,
                            //DRAWBACK_ID = DRAWBACK_ID,
                            SCHEME_CODE = SCHEME_CODE,
                            DRAWBACK_SLNO = DRAWBACK_SLNO,
                            DRAWBACK_QTY = DRAWBACK_QTY,
                            DRAWBACK_UNIT = DRAWBACK_UNIT,
                            DRAWBACK_NOOFUNITS = DRAWBACK_NOOFUNITS,
                            DRAWBACK_RATE = DRAWBACK_RATE,
                            DRAWBACK_CAPS = DRAWBACK_CAPS,
                            DRAWBACK_DESC = DRAWBACK_DESC,
                            DRAWBACK_CUSTOMS = DRAWBACK_CUSTOMS,
                            DRAWBACK_EXCISE = DRAWBACK_EXCISE,
                            DBK_VALUE = DBK_VALUE,
                            STR_RATE = STR_RATE,
                            STR_AMOUNT = STR_AMOUNT,
                            ENDUSE_ITEM = ENDUSE_ITEM,
                            IGST_PAYMENT = IGST_PAYMENT,
                            TAXABLE_VALUE = TAXABLE_VALUE,
                            IGST_AMT = IGST_AMT,
                            IGST_RATE = IGST_RATE,
                            NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS,
                            MANUFACTURER_PRODUCER = MANUFACTURER_PRODUCER,
                            M_P_GROWER_CODE = M_P_GROWER_CODE,
                            M_P_GROWER_ADD1 = M_P_GROWER_ADD1,
                            M_P_GROWER_ADD2 = M_P_GROWER_ADD2,
                            M_P_GROWER_CITY = M_P_GROWER_CITY,
                            M_P_GROWER_COUNTRY_SUBDIV = M_P_GROWER_COUNTRY_SUBDIV,
                            M_P_GROWER_PIN = M_P_GROWER_PIN,
                            M_P_GROWER_COUNTRY = M_P_GROWER_COUNTRY,
                            SOURCE_STATE = SOURCE_STATE,
                            TRANSIT_COUNTRY = TRANSIT_COUNTRY,
                            ACCESSORY_STATUS = ACCESSORY_STATUS,
                            HAWB_NO = HAWB_NO,
                            TOTAL_PKGS = TOTAL_PKGS,
                            FOB_AMOUNT_FC = FOB_AMOUNT_FC,
                            ACTUAL_ITEM_FOB_VALUE = ACTUAL_ITEM_FOB_VALUE

                        });
                    }
                    //-----------------------------UPDATE SINGLE PMV AND FOB VALUE IN ITEM TABLE ------------------------------//

                    if (IGST_PAYMENT == "LUT" || IGST_PAYMENT == "NA")
                    {
                        if (TAXABLE_VALUE == "0.00")
                        {
                            TAXABLE_VALUE = "";
                        }
                        if (IGST_AMT == "0.00")
                        {
                            IGST_AMT = "";
                        }
                    }


                    //-----------------------------#UPDATE SINGLE PMV AND FOB VALUE IN ITEM TABLE ------------------------------//
                    DBK_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(DBK_VALUE), 2).ToString("0.00"));
                    dt_update.Rows.Add(dss.Tables[0].Rows[b]["ITEM_ID"].ToString(), ddlJobNo, INVOICE_SLNO, ITEM_SLNO, Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(FOB_VALUE), Convert.ToString(STR_RATE), Convert.ToString(STR_AMOUNT),
                                        Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(TAXABLE_VALUE), Convert.ToString(IGST_AMT), currentbranch, DBK_VALUE, RODTEP_VALUE, Working_Period);

                    dt_update_Addl.Rows.Add(dss.Tables[0].Rows[b]["ITEM_ID"].ToString(), ddlJobNo, INVOICE_SLNO, INVOICE_NO, ITEM_SLNO, Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(FOB_VALUE), Convert.ToString(STR_RATE), Convert.ToString(STR_AMOUNT),
                                        Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(TAXABLE_VALUE), Convert.ToString(IGST_AMT), DBK_VALUE, RODTEP_VALUE, currentuser, LoginDate, currentbranch, "", Working_Period, Session["JOBNO_PS"].ToString(),
                                         RODTEP_RATE, RODTEP_CAP);

                    SUM_TOTAL_STR_AMT = SUM_TOTAL_STR_AMT + Convert.ToDouble(STR_AMOUNT);

                    b++;

                }


                SUM_TOTAL_DBK_VALUE = SUM_TOTAL_DBK_VALUE + TOTAL_DBK_VALUE;

                //SUM_TOTAL_STR_AMT = SUM_TOTAL_STR_AMT + Convert.ToDouble(STR_AMOUNT);


                INV_TOTAL_DBK_VAL = Convert.ToDouble(TOTAL_DBK_VALUE);

                //start of add the below to insert invoice main details in to the list.//


                INVOICE_CURRENCY = ds.Rows[C]["INVOICE_CURRENCY"].ToString();
                FOB_CHARGES = Return_Zero_Value1(Convert.ToString(DISCOUNT_RATE_AMOUNT));
                OTHER_DEDUCTION_CHARGES = Return_Zero_Value1(Convert.ToString(OTHER_DETDUCTION_RATE_AMOUNT));
                FREIGHT_CURRENCY = ds.Rows[C]["FREIGHT_CURRENCY"].ToString();
                INSURANCE_CURRENCY = ds.Rows[C]["INSURANCE_CURRENCY"].ToString();


                if (TERMS == "CF")
                {
                    INSURANCE_CURRENCY = INVOICE_CURRENCY;
                }
                else if (TERMS == "CI")
                {
                    FREIGHT_CURRENCY = INVOICE_CURRENCY;
                }

                if (COMMISSION_RATE != "" && COMMISSION_RATE != "0.00")
                {
                    double inv_val = Convert.ToDouble(INVOICE_VALUE_FC);
                    COMMISSION_CHARGES = Convert.ToString(Math.Round((inv_val * Convert.ToDouble(COMMISSION_RATE) / 100), 2));
                }

                //#Invoice
                if ((COMPANY_ID == "160" && SELECT_BRANCH == "CusHouse, Chennai") || COMPANY_ID == "2" || COMPANY_ID == "128" || COMPANY_ID == "252" || COMPANY_ID == "284" || COMPANY_ID == "382" || COMPANY_ID == "439" || COMPANY_ID == "472" || COMPANY_ID == "490" || COMPANY_ID == "517" || COMPANY_ID == "525" || COMPANY_ID == "529" || COMPANY_ID == "532" || COMPANY_ID == "538" || COMPANY_ID == "747" || COMPANY_ID == "1088" || COMPANY_ID == "1120" || COMPANY_ID == "1229" || COMPANY_ID == "1520" || COMPANY_ID == "2244" || COMPANY_ID == "2398")
                {
                    //INDIVIDUAL_INVOICE_VALUE = Convert.ToDouble(INVOICE_VALUE_FC) * Convert.ToDouble(EXCHANGE_RATE);
                    INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(INVOICE_VALUE_FC) * Convert.ToDecimal(EXCHANGE_RATE);
                    INDIVIDUAL_INVOICE_VALUE = Math.Round(INDIVIDUAL_INVOICE_VALUE, 2);

                    //INVOICE_VALUE_FC = Math.Round(INVOICE_VALUE_FC, 2);
                    INVOICE_VALUE_FC = Convert.ToString((Math.Round(Convert.ToDouble(INVOICE_VALUE_FC), 2)).ToString("0.00"));
                }
                else if (COMPANY_ID == "3267") // Cut off 2 Digit after the Decimal
                {
                    INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(INVOICE_VALUE_FC) * Convert.ToDecimal(EXCHANGE_RATE);//INDIVIDUAL_INVOICE_VALUE- converted as "Decimal"
                    INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal((Math.Truncate(INDIVIDUAL_INVOICE_VALUE * 100) / 100).ToString("F2"));
                }
                else if (COMPANY_ID == "437" || COMPANY_ID == "441" || COMPANY_ID == "1054") //decimal places without rounding
                {
                    INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(INVOICE_VALUE_FC) * Convert.ToDecimal(EXCHANGE_RATE);
                    INDIVIDUAL_INVOICE_VALUE = Math.Truncate(INDIVIDUAL_INVOICE_VALUE * 100) / 100;
                }
                else
                {
                    INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(INVOICE_VALUE_FC) * Convert.ToDecimal(EXCHANGE_RATE);
                    INVOICE_VALUE_FC = Convert.ToString((Math.Round(Convert.ToDouble(INVOICE_VALUE_FC), 2)).ToString("0.00"));
                }

                if (COMPANY_ID == "441" || COMPANY_ID == "1054")
                {
                    //INVOICE_VALUE_FC = Math.Truncate(INVOICE_VALUE_FC * 100) / 100;
                    //INVOICE_VALUE_FC = Convert.ToString((Math.Truncate(Convert.ToDouble(INVOICE_VALUE_FC) * 100) / 100).ToString("0.00"));
                    INVOICE_VALUE_FC = Convert.ToString(Math.Truncate(Convert.ToDouble(INVOICE_VALUE_FC) * 100) / 100);
                }

                //#FOB (FC) - Value which is showing in Checklist with Round off 2 digit - Need Settings Here
                /*
                if (COMPANY_ID == "1" || COMPANY_ID == "132" || COMPANY_ID == "170" || COMPANY_ID == "196" || COMPANY_ID == "335" || COMPANY_ID == "354" || COMPANY_ID == "387" || COMPANY_ID == "517" || COMPANY_ID == "525" || COMPANY_ID == "582" || COMPANY_ID == "747" || COMPANY_ID == "757" || COMPANY_ID == "1005" || COMPANY_ID == "1039" || COMPANY_ID == "1088" || COMPANY_ID == "944" || COMPANY_ID == "1144" || COMPANY_ID == "1344" || COMPANY_ID == "1545" || COMPANY_ID == "1639" || COMPANY_ID == "1660" || COMPANY_ID == "1663" || COMPANY_ID == "2078" || COMPANY_ID == "2082" || COMPANY_ID == "2151" || COMPANY_ID == "2168" || COMPANY_ID == "2152" || COMPANY_ID == "2153" || COMPANY_ID == "2154" || COMPANY_ID == "2155" || COMPANY_ID == "2226" || COMPANY_ID == "2338" || COMPANY_ID == "2602" || COMPANY_ID == "2745")
                {
                    string str_FOB_AMOUNT_FC = Convert.ToString(Math.Round(Convert.ToDouble(FOB_AMOUNT_FC), 2).ToString("0.00"));
                    FOB_AMOUNT_FC = str_FOB_AMOUNT_FC;
                }
                 * */
                str_FOB_AMOUNT_FC = "";

                //#FOB - Above Condition commonly implemented for all the Clients - Sugg.by Bala sir on 21-10-2024
                //if (COMPANY_ID == "744" || COMPANY_ID == "196")//hide on 19-06-2026
                if (COMPANY_ID == "744")//Sun global
                {
                    str_FOB_AMOUNT_FC = Convert.ToString(Convert.ToDouble((Math.Round(Convert.ToDecimal(FOB_AMOUNT_FC), 0, MidpointRounding.AwayFromZero))).ToString("0.00"));
                }
                else
                {
                    str_FOB_AMOUNT_FC = Convert.ToString(Math.Round(Convert.ToDouble(FOB_AMOUNT_FC), 2).ToString("0.00"));
                }
                FOB_AMOUNT_FC = str_FOB_AMOUNT_FC;


                Rpt_Invoice_Details_list.Add(new Report_Export_Export_ReportViewer()
                {

                    INDIVIDUAL_INVOICE_VALUE = INDIVIDUAL_INVOICE_VALUE,
                    INVOICE_VALUE_FC = INVOICE_VALUE_FC,
                    DBK_VALUE = Convert.ToString(INV_TOTAL_DBK_VAL),

                    FOB_AMOUNT_FC = FOB_AMOUNT_FC,

                    No_Of_Invoices = ds.Rows[C]["No_Of_Invoices"].ToString(),

                    INVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString(),

                    INVOICE_NO = ds.Rows[C]["INVOICE_NO"].ToString(),

                    INVOICE_DATE = ds.Rows[C]["INVOICE_DATE"].ToString(),
                    PAYMENT_METHOD = ds.Rows[C]["PAYMENT_METHOD"].ToString(),
                    PERIOD_PAYMENT = ds.Rows[C]["PERIOD_PAYMENT"].ToString(),
                    INVOICE_VALUE = Convert.ToString(TOTAL_ITEM_INVOICE_VALUE),
                    INVOICE_CURRENCY = ds.Rows[C]["INVOICE_CURRENCY"].ToString(),
                    EXCHANGE_RATE = ds.Rows[C]["EXCHANGE_RATE"].ToString(),
                    CONTRACT_NO = ds.Rows[C]["CONTRACT_NO"].ToString(),
                    CONTRACT_DATE = ds.Rows[C]["CONTRACT_Date"].ToString(),
                    TERMS = ds.Rows[C]["TERMS"].ToString(),
                    BUYER = ds.Rows[C]["BUYER"].ToString(),
                    BUYER_NAME = ds.Rows[C]["BUYER_NAME"].ToString(),
                    BUYER_ADDRESS = ds.Rows[C]["BUYER_ADDRESS"].ToString(),
                    BUYER_ADDRESS1 = ds.Rows[C]["BUYER_ADDRESS1"].ToString(),
                    BUYER_ADDRESS2 = ds.Rows[C]["BUYER_ADDRESS2"].ToString(),
                    BUYER_ADDRESS3 = ds.Rows[C]["BUYER_ADDRESS3"].ToString(),
                    BUYER_ADDRESS4 = ds.Rows[C]["BUYER_ADDRESS4"].ToString(),

                    NOTIFY_NAME = ds.Rows[C]["NOTIFY_NAME"].ToString(),
                    NOTIFY_ADDRESS_1 = ds.Rows[C]["NOTIFY_ADDRESS_1"].ToString(),
                    NOTIFY_ADDRESS_2 = ds.Rows[C]["NOTIFY_ADDRESS_2"].ToString(),
                    NOTIFY_ADDRESS_3 = ds.Rows[C]["NOTIFY_ADDRESS_3"].ToString(),
                    NOTIFY_ADDRESS_COUNTRY = ds.Rows[C]["NOTIFY_ADDRESS_COUNTRY"].ToString(),
                    

                    COMMISSION_RATE = Return_Zero_Value1(ds.Rows[C]["COMMISSION_RATE"].ToString()),
                    //COMMISSION_CHARGES = Return_Zero_Value1(ds.Rows[C]["COMMISSION_CHARGES"].ToString()),
                    COMMISSION_CHARGES = COMMISSION_CHARGES,

                    //COMMISSION_CURRENCY = INVOICE_CURRENCY,
                    COMMISSION_CURRENCY = COMMISSION_CURRENCY,

                    FOB_RATE = FOB_RATE,
                    FOB_CHARGES = FOB_CHARGES,
                    //FOB_CURRENCY = INVOICE_CURRENCY,
                    FOB_CURRENCY = FOB_CURRENCY,

                    PACKMISC_RATE = PACKMISC_RATE,
                    PACKMISC_CHARGES = PACKMISC_CHARGES,
                    //PACKMISC_CURRENCY = INVOICE_CURRENCY,
                    PACKMISC_CURRENCY = PACKMISC_CURRENCY,

                    OTHER_DEDUCTION_RATE = OTHER_DEDUCTION_RATE,
                    OTHER_DEDUCTION_CHARGES = OTHER_DEDUCTION_CHARGES,
                    //OTHER_DEDUCTION_CURRENCY = INVOICE_CURRENCY,
                    OTHER_DEDUCTION_CURRENCY = OTHER_DEDUCTION_CURRENCY,

                    FREIGHT_RATE = FREIGHT_RATE,
                    FREIGHT_CHARGES = FREIGHT_CHARGES,
                    FREIGHT_CURRENCY = FREIGHT_CURRENCY,

                    INSURANCE_RATE = INSURANCE_RATE,

                    INSURANCE_CHARGES = INSURANCE_CHARGES,
                    INSURANCE_CURRENCY = INSURANCE_CURRENCY,
                    WHEATHER_UNIT_PRICE = ds.Rows[C]["WHEATHER_UNIT_PRICE"].ToString(),
                    THIRDPARTY_NAME = ds.Rows[C]["THIRDPARTY_NAME"].ToString(),
                    THIRDPARTY_ADD1 = ds.Rows[C]["THIRDPARTY_ADD1"].ToString(),
                    THIRDPARTY_ADD2 = ds.Rows[C]["THIRDPARTY_ADD2"].ToString(),
                    THIRDPARTY_CITY = ds.Rows[C]["THIRDPARTY_CITY"].ToString(),

                    T_PARTY_COUNTRY_SUB_DIV = ds.Rows[C]["T_PARTY_COUNTRY_SUB_DIV"].ToString(),
                    T_PARTY_COUNTRY_CODE = ds.Rows[C]["T_PARTY_COUNTRY_CODE"].ToString(),
                    T_PARTY_PIN = ds.Rows[C]["T_PARTY_PIN"].ToString(),
                    AUTHORIZED_ECONOMIC_OPERATOR_CODE = ds.Rows[C]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString(),
                    A_E_O_COUNTRY = ds.Rows[C]["A_E_O_COUNTRY"].ToString(),
                    AUTHORIZED_ECONOMIC_OPERATOR = ds.Rows[C]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString(),
                    TERMS_PLACE = ds.Rows[C]["TERMS_PLACE"].ToString(),

                });
                DISCOUNT_RATE_AMOUNT = 0;
                OTHER_DETDUCTION_RATE_AMOUNT = 0;

                //end of add the below to insert invoice main details in to the list.//


                TOTAL_DBK_VALUE = 0;
                FOB_AMOUNT_FC = "0.00";
                C++;

            }


            //*************** All Calc - Final Output Update *************************************
            if (SB_NO == "")
            {
                Export_Item Item_Pmv_Update = new Export_Item();
                Item_Pmv_Update.Export_Item_PMV_FOB_VLAUE_UPDATE_Bulk_New(Common_CS.ConvertDataTableToXML(dt_update), currentbranch, "Exp_Chk_Bulk_Update");


                //#dt_update_Addl
                if (dt_update_Addl.Rows.Count > 0)
                {
                    //-------Delete Bulk Data for this Job------------------------------
                    DataSet dsdel = new DataSet();
                    CHKLIST.JOBNo = ddlJobNo;
                    CHKLIST.Workingperiod = currentbranch;
                    CHKLIST.Ename = "Delete_Exp_Item_Additional";
                    dsdel = CHKLIST.RetrieveAll_General_DetailsNew();

                    //-------Insert Bulk Data to Table------------------------------

                    AdminMasterDetails adm = new AdminMasterDetails();
                    adm.SqlBulk_Upload_Product("EXPORT_ITEM_DETAILS_ADDITIONAL", dt_update_Addl, Connection.GetConnection());
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);

        }
    }


    public double Get_Total_FOB_Value(string INSURANCE_CHARGES, string FREIGHT_CHARGES)
    {
        try
        {
            INDIVIDUAL_COMMISSION_AMOUNT = 0.00;
            //string INDIVIDUAL_COMMISSION_RATE = "";

            INDIVIDUAL_FREIGHT_AMOUNT = 0.00;
            INDIVIDUAL_INSURANCE_AMOUNT = 0.00;
            INDIVIDUAL_INVOICE_VALUE = 0;

            //double FULL_COMMISSION_AMT = 0.00;
            REMAINING_COMMISSION_AMT = 0.00;
            Actual_Individual_Item_Amt_INR = 0.00;
            ACTUAL_ITEM_FOB_VALUE = 0.00;


            //-----COMMSSION AMOUNT CAL--------------//
            if (COMMISSION_RATE != "0" && COMMISSION_RATE != "0.00")
            {
                double commis_rate;

                commis_rate = Convert.ToDouble((Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(COMMISSION_RATE)) / 100);
                COMMISSION_CHARGES = Convert.ToString(commis_rate);

                INDIVIDUAL_COMMISSION_AMOUNT = Convert.ToDouble(COMMISSION_CHARGES) * Convert.ToDouble(EXCHANGE_RATE);//EXCHANGE_RATE - INVOICE EX_RATE

            }
            else if (COMMISSION_CHARGES != "0" && COMMISSION_CHARGES != "0.00")
            {
                if (COMMISSION_CURRENCY == "INR")
                {
                    INDIVIDUAL_COMMISSION_AMOUNT = Convert.ToDouble(COMMISSION_CHARGES) * Convert.ToDouble(1);//EXCHANGE_RATE - INR
                }
                else
                {
                    INDIVIDUAL_COMMISSION_AMOUNT = Convert.ToDouble(COMMISSION_CHARGES) * Convert.ToDouble(EXCHANGE_RATE);//EXCHANGE_RATE - INVOICE EX_RATE
                }
            }

            if (INSURANCE_CHARGES != "0" && INSURANCE_CHARGES != "0.00")
            {
                INDIVIDUAL_INSURANCE_AMOUNT = Convert.ToDouble(INSURANCE_CHARGES) * Convert.ToDouble(INSURANCE_EXRATE);
            }
            else if (INSURANCE_RATE != "0" && INSURANCE_RATE != "0.00")
            {
                INDIVIDUAL_INSURANCE_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(INSURANCE_RATE)) / 100;

                //this line newly implmntd by chithra on 10-03-2020 sugg by Subbu sir & mohmed for SeaGull logs-eri01159
                INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Convert.ToDouble(INSURANCE_EXRATE);
            }

            //-----INSURANCE AMOUNT CAL--------------//

            if (FREIGHT_RATE != "0" && FREIGHT_RATE != "0.00")
            {
                INDIVIDUAL_FREIGHT_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(FREIGHT_RATE)) / 100;
            }
            else if (FREIGHT_CHARGES != "0" && FREIGHT_CHARGES != "0.00")
            {
                INDIVIDUAL_FREIGHT_AMOUNT = Convert.ToDouble(FREIGHT_CHARGES) * Convert.ToDouble(FREIGHT_EXRATE);

            }
            //-----INSURANCE AMOUNT CAL--------------//

            //-----FOB DISCOUNT AMOUNT CAL--------------//


            Individual_Item_Value = INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
            Actual_Individual_Item_Amt_INR = Actual_Individual_Item_Amt * Convert.ToDouble(EXCHANGE_RATE);// Newly added on 01-03-2024 for RoseMount digits mismatch issue


            Total_Item_Value = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
            text_Discount = 0; text_OTHER_DISCOUNT = 0; text_packing = 0;

            if (FOB_RATE != "0" && FOB_RATE != "0.00")
            {
                INDIVIDUAL_FOB_DISCOUNT_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(FOB_RATE)) / 100;
                INDIVIDUAL_FOB_DISCOUNT_AMOUNT = Math.Round(INDIVIDUAL_FOB_DISCOUNT_AMOUNT, 2);
                //INDIVIDUAL_FOB_DISCOUNT_AMOUNT = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
                //double INDIVIDUAL_FOB_DISCOUNT_AMOUNTNEW = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(FOB_RATE)) / 100;
                DISCOUNT_RATE_AMOUNT = DISCOUNT_RATE_AMOUNT + INDIVIDUAL_FOB_DISCOUNT_AMOUNT;
                text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
                //INDIVIDUAL_FOB_DISCOUNT_AMOUNT = DISCOUNT_RATE_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
                // DISCOUNT_RATE_AMOUNT = DISCOUNT_RATE_AMOUNT + Convert.ToDouble(FOB_RATE);
            }
            else if (FOB_CHARGES != "0" && FOB_CHARGES != "0.00")
            {
                if (FOB_CURRENCY == "INR")
                {
                    INDIVIDUAL_FOB_DISCOUNT_AMOUNT = Convert.ToDouble(FOB_CHARGES) * Convert.ToDouble(1);//EXCHANGE_RATE - INR
                }
                else
                {
                    INDIVIDUAL_FOB_DISCOUNT_AMOUNT = Convert.ToDouble(FOB_CHARGES) * Convert.ToDouble(EXCHANGE_RATE);//EXCHANGE_RATE - INVOICE EX_RATE
                }
                DISCOUNT_RATE_AMOUNT = Convert.ToDouble(FOB_CHARGES);
                //text_Discount = (INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value);//hide on 01-03-2024 for RoseMount digits mismatch issue
                text_Discount = (INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value);

            }
            //-----FOB DISCOUNT AMOUNT CAL--------------//

            //-----OTHER DISCOUNT AMOUNT CAL--------------//
            if (OTHER_DEDUCTION_RATE != "0" && OTHER_DEDUCTION_RATE != "0.00")
            {
                INDIVIDUAL_OTHER_DISCOUNT_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(OTHER_DEDUCTION_RATE)) / 100;
                OTHER_DETDUCTION_RATE_AMOUNT = OTHER_DETDUCTION_RATE_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT;
                text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);

            }
            else if (OTHER_DEDUCTION_CHARGES != "0" && OTHER_DEDUCTION_CHARGES != "0.00")
            {
                if (FOB_CURRENCY == "INR")
                {
                    INDIVIDUAL_OTHER_DISCOUNT_AMOUNT = Convert.ToDouble(OTHER_DEDUCTION_CHARGES) * Convert.ToDouble(1);//EXCHANGE_RATE - INR
                }
                else
                {
                    INDIVIDUAL_OTHER_DISCOUNT_AMOUNT = Convert.ToDouble(OTHER_DEDUCTION_CHARGES) * Convert.ToDouble(EXCHANGE_RATE);//EXCHANGE_RATE - INVOICE EX_RATE
                }
                OTHER_DETDUCTION_RATE_AMOUNT = Convert.ToDouble(OTHER_DEDUCTION_CHARGES);
                text_OTHER_DISCOUNT = (INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            //-----OTHER DISCOUNT AMOUNT CAL--------------//

            //-----PACKING AMOUNT CAL--------------//
            if (PACKMISC_RATE != "0" && PACKMISC_RATE != "0.00")
            {
                INDIVIDUAL_PACKING_CHARGE_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(PACKMISC_RATE)) / 100;

            }
            else if (PACKMISC_CHARGES != "0" && PACKMISC_CHARGES != "0.00")
            {
                if (PACKMISC_CURRENCY == "INR")
                {
                    INDIVIDUAL_PACKING_CHARGE_AMOUNT = Convert.ToDouble(PACKMISC_CHARGES) * Convert.ToDouble(1);//EXCHANGE_RATE - INR
                }
                else
                {
                    INDIVIDUAL_PACKING_CHARGE_AMOUNT = Convert.ToDouble(PACKMISC_CHARGES) * Convert.ToDouble(EXCHANGE_RATE);//EXCHANGE_RATE - INVOICE EX_RATE
                }
                text_packing = (INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            //-----PACKING AMOUNT CAL--------------//



            if (TERMS == "FOB")
            {
                text_packing = INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value;
                INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Individual_Item_Value / Total_Item_Value;

                if (FOB_RATE != "" && FOB_RATE != "0.00")
                {
                    text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
                }
                else
                {
                    text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
                }

                if (OTHER_DEDUCTION_RATE != "" && OTHER_DEDUCTION_RATE != "0.00")
                {
                    text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
                }
                else
                {
                    text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
                }


                INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(Individual_Item_Value);

                //INDIVIDUAL_FOB_VALUE = INDIVIDUAL_INVOICE_VALUE + text_packing - (text_Discount + text_OTHER_DISCOUNT); hide by Chithra suggest by Bala sir on 09-06-2018 for add remaining Commission 
                INDIVIDUAL_FOB_VALUE = Convert.ToDouble(INDIVIDUAL_INVOICE_VALUE) + text_packing - (text_Discount + text_OTHER_DISCOUNT + REMAINING_COMMISSION_AMT);//hide on 01-03-2024 for Rosemount Digits mismatch issue

                //INDIVIDUAL_FOB_VALUE = INDIVIDUAL_ITEM_INVOICE_VALUE + INDIVIDUAL_PACKING_CHARGE_AMOUNT - (INDIVIDUAL_FOB_DISCOUNT_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT);
                //INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE * Convert.ToDouble(EXCHANGE_RATE);

                //---CHECKLIST -IGST BASED ON VALUE --
                INDIVIDUAL_ITEM_IGST_BASED_VALUE = INDIVIDUAL_FOB_VALUE;

                //----------- below calc- suggest by Bala sir for TransMarine on 21-02-2020  checked in Final Copy-- done by Chithra -----------------------
                //if (COMPANY_ID == "459" || COMPANY_ID == "441")-- hide on 01-06-2022 by Chithra Sugg.by Bala sir checked with Final print copy eri00775
                //{
                if (COMMISSION_CHARGES != "0" && COMMISSION_CHARGES != "0.00")
                {
                    double fob_12_5 = (INDIVIDUAL_FOB_VALUE * 12.5) / 100;

                    if (INDIVIDUAL_COMMISSION_AMOUNT > fob_12_5)
                    {
                        //fob_12_5 = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                        double commission = 0.00;
                        commission = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                        INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE - commission;
                    }
                }
                //}
                //--------------------------------------------------------------------------------------------------------------------
            }
            else if (TERMS == "CIF")
            {

                INDIVIDUAL_FREIGHT_AMOUNT = INDIVIDUAL_FREIGHT_AMOUNT * Individual_Item_Value / Total_Item_Value;//hide on 01-03-2024 for RoseMount digits mismatch issue
                // INDIVIDUAL_FREIGHT_AMOUNT = INDIVIDUAL_FREIGHT_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value;



                //this line hide by Chithra on 16/07/2020 - sugg by Bala sir & Subbu sir- for Agility (Insurance Rate calc )issue
                //INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Individual_Item_Value / Total_Item_Value;

                //Again this line hide by Chithra on 15/10/2022 - sugg by Bala sir & Subbu sir- for AArkay Marine
                //if (INSURANCE_RATE == "0" || INSURANCE_RATE == "0.0" || INSURANCE_RATE == "0.00")//--ITS for only Insurance Amt
                //{
                //    INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Individual_Item_Value / Total_Item_Value;
                //}

                //Again enabled this line for Insurance Amount calc
                /*//hide on 01-03-2024 for RoseMount digits mismatch issue
                INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Individual_Item_Value / Total_Item_Value;
                INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Individual_Item_Value / Total_Item_Value;
                 * */

                INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Individual_Item_Value / Total_Item_Value;
                INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Individual_Item_Value / Total_Item_Value;

                /*
                INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value;
                INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value;
                 * */

                //double text_packing = (INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value)*Convert.ToDouble(EXCHANGE_RATE);
                //text_Discount = (INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value) * Convert.ToDouble(EXCHANGE_RATE);
                // text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
                //double text_OTHER_DISCOUNT = (INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value) * Convert.ToDouble(EXCHANGE_RATE);
                //INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
                SFIValue1 = INDIVIDUAL_FREIGHT_AMOUNT + INDIVIDUAL_INSURANCE_AMOUNT;
                INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
                //SFIValue = Individual_Item_Value + INDIVIDUAL_PACKING_CHARGE_AMOUNT - (INDIVIDUAL_FOB_DISCOUNT_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT);
                SFIValue = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT);
                INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(Individual_Item_Value);

                //---CHECKLIST -IGST BASED ON VALUE --
                INDIVIDUAL_ITEM_IGST_BASED_VALUE = SFIValue;

                if (WHEATHER_UNIT_PRICE == "B")
                {
                    INDIVIDUAL_FOB_VALUE = SFIValue - SFIValue1;
                    INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(Individual_Item_Value);

                    if (COMMISSION_CHARGES != "0" && COMMISSION_CHARGES != "0.00")
                    {
                        double fob_12_5 = (INDIVIDUAL_FOB_VALUE * 12.5) / 100;

                        if (INDIVIDUAL_COMMISSION_AMOUNT > fob_12_5)
                        {
                            //fob_12_5 = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                            double commission = 0.00;
                            commission = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                            INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE - commission;
                        }

                    }
                }

                else if (WHEATHER_UNIT_PRICE == "N")
                {
                    //INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT); hide by Chithra suggest by Bala sir on 09-06-2018 for add remaining Commission 
                    INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT + REMAINING_COMMISSION_AMT);
                    INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(Individual_Item_Value) + Convert.ToDecimal(SFIValue1);


                    if (COMMISSION_CHARGES != "0" && COMMISSION_CHARGES != "0.00")
                    {
                        double fob_12_5 = (INDIVIDUAL_FOB_VALUE * 12.5) / 100;

                        if (INDIVIDUAL_COMMISSION_AMOUNT > fob_12_5)
                        {
                            //fob_12_5 = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                            double commission = 0.00;
                            commission = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                            INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE - commission;
                        }

                    }
                }
                //else if (WHEATHER_UNIT_PRICE == "F")
                //{
                //    INDIVIDUAL_FOB_VALUE = SFIValue - SFIValue1;
                //    INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value;

                //    if (COMMISSION_CHARGES != "0" && COMMISSION_CHARGES != "0.00")
                //    {
                //        double fob_12_5 = (INDIVIDUAL_FOB_VALUE * 12.5) / 100;

                //        if (INDIVIDUAL_COMMISSION_AMOUNT > fob_12_5)
                //        {
                //            //fob_12_5 = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                //            double commission = 0.00;
                //            commission = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                //            INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE - commission;
                //        }


                //    }

                //}
                //else if (WHEATHER_UNIT_PRICE == "I")
                //{
                //    INDIVIDUAL_FOB_VALUE = SFIValue - SFIValue1;
                //    INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value;

                //    if (COMMISSION_CHARGES != "0" && COMMISSION_CHARGES != "0.00")
                //    {
                //        double fob_12_5 = (INDIVIDUAL_FOB_VALUE * 12.5) / 100;

                //        if (INDIVIDUAL_COMMISSION_AMOUNT > fob_12_5)
                //        {
                //            //fob_12_5 = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                //            double commission = 0.00;
                //            commission = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                //            INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE - commission;
                //        }

                //    }

                //}

            }
            else if (TERMS == "CF")
            {

                //INDIVIDUAL_FREIGHT_AMOUNT = INDIVIDUAL_FREIGHT_AMOUNT * Individual_Item_Value / Total_Item_Value;//hide on 01-03-2024 for RoseMount digits mismatch issue
                //INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Individual_Item_Value / Total_Item_Value;

                /* Actual Amount value mismatch for Rosemount - so, again reset old code.
                INDIVIDUAL_FREIGHT_AMOUNT = INDIVIDUAL_FREIGHT_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value;
                INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value;
                */

                INDIVIDUAL_FREIGHT_AMOUNT = INDIVIDUAL_FREIGHT_AMOUNT * Individual_Item_Value / Total_Item_Value;
                INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Individual_Item_Value / Total_Item_Value;


                SFIValue1 = INDIVIDUAL_FREIGHT_AMOUNT;
                INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
                //double text_packing = INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value;
                //double text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
                // double text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
                SFIValue = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT);
                //SFIValue = Individual_Item_Value + INDIVIDUAL_PACKING_CHARGE_AMOUNT - (INDIVIDUAL_FOB_DISCOUNT_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT);
                INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(Individual_Item_Value);

                //---CHECKLIST -IGST BASED ON VALUE --
                INDIVIDUAL_ITEM_IGST_BASED_VALUE = SFIValue;

                if (WHEATHER_UNIT_PRICE == "F")
                {
                    INDIVIDUAL_FOB_VALUE = SFIValue - SFIValue1;

                    if (COMMISSION_CHARGES != "0" && COMMISSION_CHARGES != "0.00")
                    {
                        double fob_12_5 = (INDIVIDUAL_FOB_VALUE * 12.5) / 100;

                        if (INDIVIDUAL_COMMISSION_AMOUNT > fob_12_5)
                        {
                            //fob_12_5 = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                            double commission = 0.00;
                            commission = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                            INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE - commission;
                        }

                    }

                }

                else if (WHEATHER_UNIT_PRICE == "N")
                {
                    //INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT); hide by Chithra suggest by Bala sir on 09-06-2018 for add remaining Commission 
                    INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT + REMAINING_COMMISSION_AMT);
                    INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(Individual_Item_Value) + Convert.ToDecimal(SFIValue1);


                    if (COMMISSION_CHARGES != "0" && COMMISSION_CHARGES != "0.00")
                    {
                        double fob_12_5 = (INDIVIDUAL_FOB_VALUE * 12.5) / 100;

                        if (INDIVIDUAL_COMMISSION_AMOUNT > fob_12_5)
                        {
                            //fob_12_5 = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                            double commission = 0.00;
                            commission = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                            INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE - commission;
                        }

                    }
                }


                // TOTAL_ITEM_INVOICE_VALUE
                //double Individual_Item_Value = INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
                //double Total_Item_Value = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
                //INDIVIDUAL_FREIGHT_AMOUNT = INDIVIDUAL_FREIGHT_AMOUNT * (Individual_Item_Value) / Total_Item_Value;
                //INDIVIDUAL_FOB_VALUE = INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);


            }
            else if (TERMS == "CI")
            {
                double Indivial_Ins_Amt = 0.00;


                //this line hide by Chithra on 16/07/2020 - sugg by Bala sir & Subbu sir- for Agility (Insurance Rate calc )issue
                //INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Individual_Item_Value / Total_Item_Value;
                if (INSURANCE_RATE == "0" || INSURANCE_RATE == "0.0" || INSURANCE_RATE == "0.00")//--ITS for only Insurance Amt
                {
                    //INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Individual_Item_Value / Total_Item_Value;//hide on 01-03-2024 for RoseMount digits mismatch issue
                    INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value;
                }

                //INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Individual_Item_Value / Total_Item_Value;//hide on 01-03-2024 for RoseMount digits mismatch issue
                INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value;

                //INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
                SFIValue1 = INDIVIDUAL_INSURANCE_AMOUNT;
                INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
                //double text_packing = INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value;
                //double text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
                //double text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
                SFIValue = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT);
                //SFIValue = Individual_Item_Value + INDIVIDUAL_PACKING_CHARGE_AMOUNT - (INDIVIDUAL_FOB_DISCOUNT_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT);
                INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(Individual_Item_Value);

                //---CHECKLIST -IGST BASED ON VALUE --
                INDIVIDUAL_ITEM_IGST_BASED_VALUE = SFIValue;

                if (WHEATHER_UNIT_PRICE == "I")
                {

                    INDIVIDUAL_FOB_VALUE = SFIValue - SFIValue1; // hide by Chithra with Bala sir on 19-06-2018 for LIZMA - Ins rate Calc ..
                    //INDIVIDUAL_FOB_VALUE = SFIValue - Indivial_Ins_Amt;

                    INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(Individual_Item_Value);

                    if (COMMISSION_CHARGES != "0" && COMMISSION_CHARGES != "0.00")
                    {
                        double fob_12_5 = (INDIVIDUAL_FOB_VALUE * 12.5) / 100;

                        if (INDIVIDUAL_COMMISSION_AMOUNT > fob_12_5)
                        {
                            //fob_12_5 = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                            double commission = 0.00;
                            commission = INDIVIDUAL_COMMISSION_AMOUNT - fob_12_5;
                            INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE - commission;
                        }
                    }
                }
                else if (WHEATHER_UNIT_PRICE == "N")
                {
                    //INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT); hide by Chithra suggest by Bala sir on 09-06-2018 for add remaining Commission 
                    INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT + REMAINING_COMMISSION_AMT);
                    INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(Individual_Item_Value) + Convert.ToDecimal(SFIValue1);
                }
                //double Individual_Item_Value = INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
                //double Total_Item_Value = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
                //INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * (Individual_Item_Value) / Total_Item_Value;
                //INDIVIDUAL_FOB_VALUE = INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
            }

            //------------------------PENDING WHETHER THE UNITPRICE INCLUDE----------------------------//

            //------------------------PENDING WHETHER THE UNITPRICE INCLUDE----------------------------//
            //INDIVIDUAL_INVOICE_VALUE = INDIVIDUAL_INVOICE_VALUE;

            //INDIVIDUAL_INVOICE_VALUE = INDIVIDUAL_INVOICE_VALUE/IND_PER_QTY;


            FOB_CHARGES = Convert.ToString(DISCOUNT_RATE_AMOUNT);

            //#INVOICE_VALUE_FC - should be match with Invoice Value - Nila Sea Foods - Ex.Rate divide before sum the TOTAL_INV_VALUE - by Chithra on 26-10-2023
            if (COMPANY_ID == "10" || COMPANY_ID == "517" || COMPANY_ID == "588" || COMPANY_ID == "1129" || COMPANY_ID == "1229" || COMPANY_ID == "1268" || COMPANY_ID == "1344" || COMPANY_ID == "1520" || COMPANY_ID == "1663" || COMPANY_ID == "2078" || COMPANY_ID == "2082" || COMPANY_ID == "2151" || COMPANY_ID == "2168" || COMPANY_ID == "2152" || COMPANY_ID == "2153" || COMPANY_ID == "2154" || COMPANY_ID == "2155" || COMPANY_ID == "2244" || COMPANY_ID == "2301" || COMPANY_ID == "2333" || COMPANY_ID == "2398" || COMPANY_ID == "2745" || COMPANY_ID == "3267")
            {
                INVOICE_VALUE_FC = Convert.ToString((Convert.ToDouble(INDIVIDUAL_INVOICE_VALUE) / Convert.ToDouble(EXCHANGE_RATE)));
                INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal((Math.Round(Convert.ToDecimal(INVOICE_VALUE_FC), 2, MidpointRounding.AwayFromZero)).ToString());
                TOTAL_INV_VALUE = TOTAL_INV_VALUE + Convert.ToDouble(INDIVIDUAL_INVOICE_VALUE);
                INVOICE_VALUE_FC = Convert.ToString((Convert.ToDouble(TOTAL_INV_VALUE) - Convert.ToDouble(DISCOUNT_RATE_AMOUNT)) + Convert.ToDouble(PACKMISC_CHARGES) - (Convert.ToDouble(OTHER_DETDUCTION_RATE_AMOUNT)));
            }
            else //  Ex.Rate divide "after" sum the TOTAL_INV_VALUE
            {
                //TOTAL_INV_VALUE = TOTAL_INV_VALUE + INDIVIDUAL_INVOICE_VALUE;
                TOTAL_INV_VALUE = TOTAL_INV_VALUE + Actual_Individual_Item_Amt_INR;// Newly added on 08-03-2024 for FreightLog - Invoice Value mismatch issue- Sugg.Bala
                INVOICE_VALUE_FC = Convert.ToString((Convert.ToDouble(TOTAL_INV_VALUE) / Convert.ToDouble(EXCHANGE_RATE) - Convert.ToDouble(DISCOUNT_RATE_AMOUNT)) + Convert.ToDouble(PACKMISC_CHARGES) - (Convert.ToDouble(OTHER_DETDUCTION_RATE_AMOUNT)));
            }


            //Need Settings Here
            if (COMPANY_ID == "747" || COMPANY_ID == "196" || COMPANY_ID == "694" || COMPANY_ID == "2004")//Invoice Value should be Round off after 2 digit - reqrd by Mari Agility
            {
                INVOICE_VALUE_FC = Convert.ToString((Math.Round(Convert.ToDecimal(INVOICE_VALUE_FC), 2, MidpointRounding.AwayFromZero)).ToString());
            }
            else if (COMPANY_ID == "128")//Invoice Value should be same as FOB Value
            {
                INVOICE_VALUE_FC = INVOICE_VALUE_FC;
            }
            else
            {
                INVOICE_VALUE_FC = Convert.ToString((Math.Round(Convert.ToDecimal(INVOICE_VALUE_FC), 2)).ToString("0.00"));
                // INVOICE_VALUE_FC = Convert.ToString((Math.Round(Convert.ToDecimal(INVOICE_VALUE_FC), 2, MidpointRounding.AwayFromZero)).ToString());
            }

            //#Common Code checked with ROYAL
            TOTAL_FOB_AMOUNT = TOTAL_FOB_AMOUNT + INDIVIDUAL_FOB_VALUE;



            //**************eLOGIX Requirement dated on 24/05/2018 by Chithra start*************************
            double FOB_AMT_FC = 0.00;
            FOB_AMT_FC = TOTAL_FOB_AMOUNT / Convert.ToDouble(EXCHANGE_RATE);

            if (COMPANY_ID == "2082")
            {
                FOB_AMT_FC = Math.Round(Convert.ToDouble(FOB_AMT_FC), 2);
                FOB_VALUE_ROUND = Math.Round(FOB_AMT_FC * Convert.ToDouble(EXCHANGE_RATE), 2);
                TOTAL_FOB_AMOUNT = FOB_VALUE_ROUND;
            }

            //#FOB (FC) - Value - Item wise Calc here //-need to implement settings here
            /*
            if (COMPANY_ID != "1" && COMPANY_ID != "132" && COMPANY_ID != "170" && COMPANY_ID != "196" && COMPANY_ID != "335" && COMPANY_ID != "354" && COMPANY_ID != "387" && COMPANY_ID != "517" && COMPANY_ID != "525" && COMPANY_ID != "582" && COMPANY_ID != "624" && COMPANY_ID != "757" && COMPANY_ID != "1005" && COMPANY_ID != "1088" && COMPANY_ID != "752" && COMPANY_ID != "747" && COMPANY_ID != "944" && COMPANY_ID != "1144" && COMPANY_ID != "1344" && COMPANY_ID != "1545" && COMPANY_ID != "1639" && COMPANY_ID != "1658" && COMPANY_ID != "1660" && COMPANY_ID != "1663" && COMPANY_ID != "2078" && COMPANY_ID != "2151" && COMPANY_ID != "2168" && COMPANY_ID != "2152" && COMPANY_ID != "2078" && COMPANY_ID != "2151" && COMPANY_ID != "2168" && COMPANY_ID != "2153" && COMPANY_ID != "2154" && COMPANY_ID != "2155" && COMPANY_ID != "2226" && COMPANY_ID != "2338" && COMPANY_ID != "2602" && COMPANY_ID != "2745")
            {
                FOB_AMOUNT_FC = Convert.ToString((Convert.ToDouble(FOB_AMOUNT_FC) + FOB_AMT_FC).ToString("0.00"));
                FOB_AMOUNT_FC = Convert.ToString((Math.Round(Convert.ToDouble(FOB_AMOUNT_FC), 2)).ToString("0.00"));
            }
            else
            {
                FOB_AMOUNT_FC = Convert.ToString((Convert.ToDouble(FOB_AMOUNT_FC) + FOB_AMT_FC).ToString());
            }
             * */

            //#FOB - Above Condition commonly implemented for all the Clients - Sugg.by Bala sir on 21-10-2024
            FOB_AMOUNT_FC = Convert.ToString((Convert.ToDouble(FOB_AMOUNT_FC) + FOB_AMT_FC).ToString());

            //**************eLOGIX Requirement dated on 24/05/2018 by Chithra end*************************

            SUM_TOTAL_FOB_VALUE = SUM_TOTAL_FOB_VALUE + TOTAL_FOB_AMOUNT;
            ACTUAL_ITEM_FOB_VALUE = TOTAL_FOB_AMOUNT;
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

        return TOTAL_FOB_AMOUNT;

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
            Connection.Error_Msg(ex.Message);
        }
       

        return ExRate;
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
            Connection.Error_Msg(ex.Message);
        }
        
        return val;
    }
    public string Return_Zero_Value1(string val)
    {
        try
        {
            if (val == "" || val == "0")
            {
                val = "0.00";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     
        return val;
    }


    // ---------------------------------------------------Jono dropdown work--------------------

    private void jobno_load()
    {
        try
        {
            Export_CheckList chklist = new Export_CheckList();
            Working_Period = Session["WorkingPeriod"].ToString();

            chklist.JOBNo = "";
            chklist.Ename = "select_jobno";
            chklist.Workingperiod = SELECT_BRANCH;

            ddlJob_No.DataSource = chklist.RetrieveAll_General_Details();
            ddlJob_No.DataValueField = "JOBNO";
            ddlJob_No.DataTextField = "JOBNO_PS";
            ddlJob_No.DataBind();
            ddlJob_No.Items.Remove("0");
            ddlJob_No.Items.Insert(0, "Select");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }

    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlJob_No.SelectedItem.Text != "Select")
            {
                Get_Export_Details();
                // remove

                Response.Redirect("../Report/Export_ReportViewerNew.aspx?jobno=" + ddlJob_No.SelectedValue.ToString() + "&Annexure_Mode=" + Annexure_Mode + "&STR_Code=" + STR_Code + "&jobnops= " + ddlJob_No.SelectedItem.Text + "");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    private void Get_Export_Details()
    {
        try
        {
            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
            Export_CheckList chklist = new Export_CheckList();
            //chklist.JOBNo = ddlJob_No.SelectedItem.Text;
            chklist.JOBNo = ddlJob_No.SelectedValue.ToString();
            chklist.Ename = "select_jobno_CheckList";

            chklist.Workingperiod = SELECT_BRANCH;
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_DetailsNew();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Rpt_General_Details Export_General = new Rpt_General_Details();
                //Export_General.Retrieve_GetGeneral(ddlJob_No.SelectedItem.Text);
                Export_General.Retrieve_GetGeneralNew(ddlJob_No.SelectedValue.ToString());
                Annexure_Mode = Convert.ToString(Export_General.is_Annexure_Mode);
                STR_Code = Convert.ToString(Export_General.is_STR_Code);

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
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
            Connection.Error_Msg(ex.Message);
        }
      
        return dss.Tables[0];
    }

    private void Auto_IRN_Insert_from_Esanchit_EmailsRead(string Imp_Exp_type, string Jobno)
    {
        try
        {
            Auto_IRN_Upload IRN = new Auto_IRN_Upload();
            DataSet ds_IRN = new DataSet();
            DataTable dtt = new DataTable();

            ds_IRN = IRN.Imp_Exp_Auto_IRN_Insert(Jobno, "Get_Doc_Type_Code", Imp_Exp_type, dtt);

            if (ds_IRN.Tables[0].Rows.Count > 0)
            {
                ds_IRN = IRN.Imp_Exp_Auto_IRN_Insert(Jobno, "eSanchit_Mail_Insert_to_Job", Imp_Exp_type, Bind_Doc_Type_Desc(ds_IRN.Tables[0].Rows[0]["DOC_CODE"].ToString()));
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }


    public DataSet GET_ALL_Export_Checklist_Admin_Master()
    {
        adminmaster adm = new adminmaster();
        try
        {
            CHKLIST.JOBNo = ddlJob_No.SelectedValue.ToString();
            CHKLIST.Ename = "GET_ALL_RATES_FROM_ADMIN_MASTER";
            CHKLIST.Workingperiod = Connection.Current_Branch();
            DataSet ds_rates1 = new DataSet();
            ds_rates1 = CHKLIST.RetrieveAll_General_DetailsNew();

            if (ds_rates1.Tables[0].Rows.Count > 0)
            {
                adm.ERITC_CODE = ds_rates1.Tables[0].Rows[0]["RITCNO"].ToString();
            }
            else
            {
                adm.ERITC_CODE = "";
            }

            if (ds_rates1.Tables[1].Rows.Count > 0)
            {
                adm.STR_SRNO = ds_rates1.Tables[1].Rows[0]["ITEM_STR_CODE"].ToString();
            }
            else
            {
                adm.STR_SRNO = "";
            }
            if (ds_rates1.Tables[2].Rows.Count > 0)
            {
                adm.Edrawback_slno = ds_rates1.Tables[2].Rows[0]["DRAWBACK_SLNO"].ToString();
            }
            else
            {
                adm.Edrawback_slno = "";
            }

            adm.Ename = "GET_ADMIN_RATES";
            dt_All_Rates = adm.RetrieveAll_Export_Checklist_Admin_Master();


        }
        catch (Exception ex)
        {
        }

        return dt_All_Rates;
    }

    private void Get_dt_Tbl_Items()
    {
        try
        {
            #region TBl_Items Update
            // DataTable dt_update = new DataTable();
            dt_update.Columns.Add("ITEM_ID");
            dt_update.Columns.Add("JOBNO");
            dt_update.Columns.Add("INVOICE_SLNO");
            dt_update.Columns.Add("ITEM_SLNO");
            dt_update.Columns.Add("PMV_VALUE");
            dt_update.Columns.Add("FOB_VALUE");
            dt_update.Columns.Add("STR_RATE");
            dt_update.Columns.Add("STR_AMOUNT");
            dt_update.Columns.Add("ITEM_PMVVALUE");
            dt_update.Columns.Add("TAXABLE_VALUE");
            dt_update.Columns.Add("IGST_AMT");
            dt_update.Columns.Add("BRANCH_COMMON");
            dt_update.Columns.Add("DRAWBACK_VALUE");
            dt_update.Columns.Add("RODTEP_VALUE");
            dt_update.Columns.Add("WORKING_PERIOD");


            //DataTable dt_update_Addl = new DataTable();
            dt_update_Addl.Columns.Add("ITEM_ID");
            dt_update_Addl.Columns.Add("JOBNO");
            dt_update_Addl.Columns.Add("INVOICE_SLNO");
            dt_update_Addl.Columns.Add("INVOICE_NO");
            dt_update_Addl.Columns.Add("ITEM_SLNO");
            dt_update_Addl.Columns.Add("PMV_VALUE");
            dt_update_Addl.Columns.Add("FOB_VALUE");
            dt_update_Addl.Columns.Add("STR_RATE");
            dt_update_Addl.Columns.Add("STR_AMOUNT");
            dt_update_Addl.Columns.Add("ITEM_PMVVALUE");
            dt_update_Addl.Columns.Add("TAXABLE_VALUE");
            dt_update_Addl.Columns.Add("IGST_AMT");
            dt_update_Addl.Columns.Add("DRAWBACK_VALUE");
            dt_update_Addl.Columns.Add("RODTEP_VALUE");

            dt_update_Addl.Columns.Add("USER_ID");
            dt_update_Addl.Columns.Add("DATE_TIME");
            dt_update_Addl.Columns.Add("BRANCH_CODE");
            dt_update_Addl.Columns.Add("YEAR");
            dt_update_Addl.Columns.Add("WORKING_PERIOD");
            dt_update_Addl.Columns.Add("JOBNO_PS");

            dt_update_Addl.Columns.Add("RODTEP_RATE");
            dt_update_Addl.Columns.Add("RODTEP_CAP");
            #endregion TBl_Items Update
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    private string Get_SBNo()
    {
        string SB_No = "";
        try
        {
            DataSet ds_sb = new DataSet();
            Export_CheckList CHKLIST = new Export_CheckList();
            CHKLIST.JOBNo = ddlJob_No.SelectedValue;
            CHKLIST.Ename = "Get_SBNo";
            CHKLIST.Workingperiod = Connection.Get_Company_Type();
            ds_sb = CHKLIST.RetrieveAll_General_Details();
            if (ds_sb.Tables[0].Rows.Count > 0)
            {
                SB_No = ds_sb.Tables[0].Rows[0]["SB_NO"].ToString() + "~" + ds_sb.Tables[0].Rows[0]["SB_DATE"].ToString();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

        return SB_No;
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                 