using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Web.UI.WebControls.WebParts;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;

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
    public string Annexure_Mode = "", STR_Code = "", str_FOB_AMOUNT_FC = "0.00";
    double Actual_Individual_Item_Amt = 0.00;
    double Actual_Individual_Item_Amt_INR = 0.00;
    double REMAINING_COMMISSION_AMT = 0.00;

    double indi_commi = 0.00;

    public string errorFolder = "", COMPANY_ID = "";
    public string SCHEME_CODE_LEV;

    public string DECLARATION = "", Check_Stmt = "";
    DateTime CurrentDate, compareDate_ROSCTL;


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
    private string _PORT_OF_LOADING;

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
    private string _ANNEX_AIR_MAWB_DATE;
    private string _ANNEX_AIR_HAWB_DATE;

    private string _ANNEX_AIR_ROTATION_NO;
    private string _ANNEX_AIR_ROTATION_DATE;


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
    public string PORT_OF_LOADING { get { return _PORT_OF_LOADING; } set { _PORT_OF_LOADING = value; } }
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
    public string ANNEX_AIR_MAWB_DATE { get { return _ANNEX_AIR_MAWB_DATE; } set { _ANNEX_AIR_MAWB_DATE = value; } }
    public string ANNEX_AIR_HAWB_DATE { get { return _ANNEX_AIR_HAWB_DATE; } set { _ANNEX_AIR_HAWB_DATE = value; } }
    public string ANNEX_AIR_GR_UNIT_CODE { get { return _ANNEX_AIR_GR_UNIT_CODE; } set { _ANNEX_AIR_GR_UNIT_CODE = value; } }
    //public string FOB_VALUE { get { return _FOB_VALUE; } set { _FOB_VALUE = value; } }
    public string DRAWBACK_VALUE { get { return _DRAWBACK_VALUE; } set { _DRAWBACK_VALUE = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }

    public string ANNEX_SEA_SEAL_TYPE { get { return _ANNEX_SEA_SEAL_TYPE; } set { _ANNEX_SEA_SEAL_TYPE = value; } }


    public string ANNEX_AIR_ROTATION_NO { get { return _ANNEX_AIR_ROTATION_NO; } set { _ANNEX_AIR_ROTATION_NO = value; } }
    public string ANNEX_AIR_ROTATION_DATE { get { return _ANNEX_AIR_ROTATION_DATE; } set { _ANNEX_AIR_ROTATION_DATE = value; } }

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

    private string _INVOICE_VALUE_FC, _TAXABLE_VALUE, _IGST_AMT, _IFSC_CODE;

    private string _STR_RATE;
    private double _STR_AMOUNT;

    private string _ENDUSE_ITEM, _IGST_PAYMENT, _IGST_RATE, _PMV_METHOD, _PMV_RATE, _PMV_PER_UNIT, _RODTEP;

    //Invoice Details
    private string _TERMS;
    private string _EXCHANGE_RATE;

    private string _INVOICE_VALUE, _STR_AMOUNT1;
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

    #region ITEM OTHER Attributes
    private string _SQC, _INFO_UQC, _STATE, _DISTRICT, _GCESS, _PTA;

    public string SQC { get { return _SQC; } set { _SQC = value; } }
    public string INFO_UQC { get { return _INFO_UQC; } set { _INFO_UQC = value; } }
    public string STATE { get { return _STATE; } set { _STATE = value; } }
    public string DISTRICT { get { return _DISTRICT; } set { _DISTRICT = value; } }
    public string GCESS { get { return _GCESS; } set { _GCESS = value; } }
    public string PTA { get { return _PTA; } set { _PTA = value; } }

    #endregion

    #region RODTEP Private_Attributes

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

    #endregion RODTEP Private_Attributes

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
    public string IFSC_CODE { get { return _IFSC_CODE; } set { _IFSC_CODE = value; } }


    public string STR_RATE { get { return _STR_RATE; } set { _STR_RATE = value; } }
    //public double STR_AMOUNT { get { return _STR_AMOUNT; } set { _STR_AMOUNT = value; } }
    public string STR_AMOUNT { get { return _STR_AMOUNT1; } set { _STR_AMOUNT1 = value; } }


    //------------ITEM FOB CALCULATION ATTRIBUTES-------------------------------//
    public double TOTAL_INVOICE_VALUE = 0;
    public double TOTAL_ITEM_INVOICE_VALUE = 0, TOTAL_ITEM_INV_VALUE = 0;
    public double INDIVIDUAL_ITEM_INVOICE_VALUE = 0;
    //public double INDIVIDUAL_INVOICE_VALUE { get { return _INDIVIDUAL_INVOICE_VALUE; } set { _INDIVIDUAL_INVOICE_VALUE = value; } }
    public decimal INDIVIDUAL_INVOICE_VALUE { get { return _INDIVIDUAL_INVOICE_VALUE; } set { _INDIVIDUAL_INVOICE_VALUE = value; } }

    public double INDIVIDUAL_COMMISSION_AMOUNT = 0;
    public double INDIVIDUAL_INSURANCE_AMOUNT = 0;
    public double INDIVIDUAL_OTHER_DISCOUNT_AMOUNT = 0;
    public double INDIVIDUAL_FREIGHT_AMOUNT = 0;
    public double INDIVIDUAL_PACKING_CHARGE_AMOUNT = 0;
    public double INDIVIDUAL_FOB_DISCOUNT_AMOUNT = 0;
    public double INDIVIDUAL_FOB_VALUE = 0;
    public double TOTAL_FOB_AMOUNT = 0, SUM_TOTAL_FOB_VALUE = 0, SUM_TOTAL_DBK_VALUE = 0, SUM_TOTAL_STR_AMT = 0, LEV_VALUE = 0, LEV_VALUE_STATE = 0, LEV_VALUE_CENTRAL = 0, DRAWBACK_VAL = 0, TOTAL_DBK_VALUE = 0, INV_TOTAL_DBK_VAL = 0, RODTEP_VAL = 0, TOTAL_RODTEP_VALUE = 0, TOT_SUM_LEV_AMT = 0;
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
    private string _INVOICE_DATE;
    private string _BUYER;
    private string _BUYER_NAME;
    private string _BUYER_ADDRESS;
    private string _BUYER_ADDRESS1;
    private string _BUYER_ADDRESS2;
    private string _BUYER_ADDRESS3;
    private string _BUYER_ADDRESS4;


    private string _No_Of_Invoices;


    #endregion



    #region Public_Attributes

    // Invoice Details


    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string PAYMENT_METHOD { get { return _PAYMENT_METHOD; } set { _PAYMENT_METHOD = value; } }
    public string PERIOD_PAYMENT { get { return _PERIOD_PAYMENT; } set { _PERIOD_PAYMENT = value; } }

    public string INVOICE_CURRENCY { get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }

    public string CONTRACT_NO { get { return _CONTRACT_NO; } set { _CONTRACT_NO = value; } }

    public string BUYER { get { return _BUYER; } set { _BUYER = value; } }
    public string BUYER_NAME { get { return _BUYER_NAME; } set { _BUYER_NAME = value; } }

    public string BUYER_ADDRESS { get { return _BUYER_ADDRESS; } set { _BUYER_ADDRESS = value; } }
    public string BUYER_ADDRESS1 { get { return _BUYER_ADDRESS1; } set { _BUYER_ADDRESS1 = value; } }
    public string BUYER_ADDRESS2 { get { return _BUYER_ADDRESS2; } set { _BUYER_ADDRESS2 = value; } }
    public string BUYER_ADDRESS3 { get { return _BUYER_ADDRESS3; } set { _BUYER_ADDRESS3 = value; } }
    public string BUYER_ADDRESS4 { get { return _BUYER_ADDRESS4; } set { _BUYER_ADDRESS4 = value; } }

    public string No_Of_Invoices { get { return _No_Of_Invoices; } set { _No_Of_Invoices = value; } }


    public string ENDUSE_ITEM { get { return _ENDUSE_ITEM; } set { _ENDUSE_ITEM = value; } }
    public string IGST_PAYMENT { get { return _IGST_PAYMENT; } set { _IGST_PAYMENT = value; } }
    public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
    public double TAXABLE_VALUE1 { get { return _TAXABLE_VALUE1; } set { _TAXABLE_VALUE1 = value; } }
    //public string IGST_AMT1 { get { return _IGST_AMT1; } set { _IGST_AMT1 = value; } }
    public double IGST_AMT1 { get { return _IGST_AMT1; } set { _IGST_AMT1 = value; } }


    public string PMV_METHOD { get { return _PMV_METHOD; } set { _PMV_METHOD = value; } }
    public string PMV_RATE { get { return _PMV_RATE; } set { _PMV_RATE = value; } }
    public string PMV_PER_UNIT { get { return _PMV_PER_UNIT; } set { _PMV_PER_UNIT = value; } }
    public string RODTEP { get { return _RODTEP; } set { _RODTEP = value; } }


    #endregion

    List<Report_Export_Export_ReportViewer> Rpt_General_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_Item_Details_new_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_Invoice_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_DrawBack_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_AR4_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_STR_Details_list = new List<Report_Export_Export_ReportViewer>();

    List<Report_Export_Export_ReportViewer> Rpt_Cess_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_Quota_Details_list = new List<Report_Export_Export_ReportViewer>();

    List<Report_Export_Export_ReportViewer> Rpt_Reward_Details_list = new List<Report_Export_Export_ReportViewer>();

    List<Report_Export_Export_ReportViewer> Rpt_Duty_Details_list = new List<Report_Export_Export_ReportViewer>();

    List<Report_Export_Export_ReportViewer> Rpt_ITEM_MANUFACTURER_SW_Details_list = new List<Report_Export_Export_ReportViewer>();

    List<Report_Export_Export_ReportViewer> Rpt_ITEM_RE_EXPORT_Details_list = new List<Report_Export_Export_ReportViewer>();

    List<Report_Export_Export_ReportViewer> Rpt_ROSCTL_Details_list = new List<Report_Export_Export_ReportViewer>();

    List<Report_Export_Export_ReportViewer> Rpt_ITEM_OTHER_Details_list = new List<Report_Export_Export_ReportViewer>();

    List<Report_Export_Export_ReportViewer> Rpt_RODTEP_Details_list = new List<Report_Export_Export_ReportViewer>();


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
            try
            {
                jobno_load();

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

                    if (string.IsNullOrEmpty(Session["SB_NO"] as string))
                    {
                        Export_Default_Entry.Post_Data(ddlJob_No.SelectedValue.ToString(), "RODTEP");
                    }


                    if (COMPANY_ID == "1" || COMPANY_ID == "1344" || COMPANY_ID == "1572" || COMPANY_ID == "1623" || COMPANY_ID == "2078" || COMPANY_ID == "2118" || COMPANY_ID == "2152" || COMPANY_ID == "2153" || COMPANY_ID == "2154" || COMPANY_ID == "2155" || COMPANY_ID == "2214" || COMPANY_ID == "2305")
                    {
                        Export_Default_Entry.CLIENT_BASED_DBK_DEFAULT_ENTRY(ddlJob_No.SelectedValue.ToString(), "DBK_Decl");
                    }

                    if (COMPANY_ID == "1572" || COMPANY_ID == "517")
                    {
                        Export_PDF_Upload.Exp_PDF_Auto_IRN_Insert();//Esanchit_EmailsRead - Master to Job
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

                    if (Request.QueryString["Direct_CH"] == "Y")
                    {
                        Response.Redirect("../Report/Export_ReportViewer.aspx?jobno=" + ddlJob_No.SelectedValue.ToString() + "&Annexure_Mode=" + Annexure_Mode + "&STR_Code=" + STR_Code + "&jobnops=" + ddlJob_No.SelectedItem.Text + "&chk_Stmt=" + Check_Stmt + "");
                    }
                    else
                    {
                        Page_loaItem_Details();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();

                er.makeLog
                    (ex.Message);
            }
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
                ddlJobNo = Request.QueryString["jobno"].ToString();
                Session["JobNo"] = ddlJobNo;

                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

                ReportViewer1.LocalReport.DataSources.Clear();
                //---------------------Dataset Value Calling From webservice EXPORT CHECKLIST PAGE------------------------------//
                ds = (DataSet)HttpContext.Current.Session["EXPORT_CHECKLIST"];
                if (!string.IsNullOrEmpty(Request["Annexure_Mode"]))
                {
                    IS_ANNEXURE_MODE = Convert.ToInt32(Request["Annexure_Mode"].ToString());
                }
                if (!string.IsNullOrEmpty(Request["STR_CODE"]))
                {
                    Is_STR = Convert.ToInt32(Request["STR_CODE"].ToString());

                }
                //---------------------Dataset Value Calling From webservice EXPORT CHECKLIST PAGE------------------------------//

                GetGeneral();
                Invoice_Details();
                Item_Details();
                Drawback_Details();
                ROSCTL_Details();
                Accessory_Details();
                License_Details();
                ThirdParty_Details();
                Jobbing_Details();
                STR_Details();

                //Reward_Details();

                AR4_Details();
                EOU_Details();
                Container_Details();
                Annexure_Sea_Details();
                Package_Details();
                Cess_Details();
                Duty_Details();
                Quota_Details();
                SW_ITEM_INFO_TYPE_DETAILS();
                SW_ITEM_CONSTITUTE_DETAILS();
                SW_ITEM_PRODUCTION_DETAILS();
                SW_ITEM_CONTROL_DETAILS();
                SW_ITEM_STATEMENT_DETAILS();
                SW_ITEM_SUPPORTING_DETAILS();
                Item_Manufaturer_SW_Details();
                Item_RE_EXPORT_Details();
                Item_Other_Details();
                RODTEP_Details();

                DataTable dt_MultipleCHA = new DataTable();


                string cha_Name = "", CHA_NO = "";
                CHA_NO = Connection.Get_EXP_CHA_NO();

                if (Connection.Exp_Multiple_CHA_IcegateID_enable(COMPANY_ID) == "Y")
                {
                    dt_MultipleCHA = Connection.Get_Multiple_ICE_ID_CHANO_frm_GENERAL_DETAILS(ds.Tables[0].Rows[0]["ICE_ID"].ToString(), "E");

                    if (dt_MultipleCHA.Rows.Count > 0)
                    {
                        cha_Name = dt_MultipleCHA.Rows[0]["CHA_NAME"].ToString().Replace("amp;", "");
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

                //------------------------- Start Checklist -----------------------
                ReportParameter param = new ReportParameter("Title", cha_Name);


                string param1_head = "";
                if (COMPANY_ID == "525")
                {
                    param1_head = "Indian Customs EDI System - Exports ( ICES / E )" + Environment.NewLine + "CHECK LIST - Shipping Bill";
                }
                else
                {
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
                        param1_head = "CHECK LIST - Shipping Bill for SEZ";
                    }
                    else if (heading == 2)
                    {
                        param1_head = "CHECK LIST - EXBOND SHIPPING BILL";
                    }
                    else
                    {
                        param1_head = "CHECK LIST - Shipping Bill";
                    }
                }

                ReportParameter param1 = new ReportParameter("SubTitle", param1_head);
                //ReportParameter param2= new ReportParameter("CustomHouse", currentbranch + "," + CUSTOMS_HOUSE + "]");
                ReportParameter param3 = new ReportParameter("PrintDate", dt.Today_Date());
                ReportParameter param4 = new ReportParameter("TodayDate", dt.Today_Date());
                ReportParameter param5 = new ReportParameter("Jobno", ddlJob_No.SelectedItem.ToString() == "" ? " " : ddlJob_No.SelectedItem.ToString());



                if (ds.Tables[23].Rows.Count > 0)
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
                        if (ds.Tables[23].Rows[0]["SEZ_PAN_NO"].ToString() != "")
                        {
                            CHA_NO = ds.Tables[23].Rows[0]["SEZ_PAN_NO"].ToString();
                        }
                    }
                }

                ReportParameter param6 = new ReportParameter("CHA_NO", CHA_NO);
                ReportParameter param7 = new ReportParameter("CHA_NAME", cha_Name);
                ReportParameter param8 = new ReportParameter("SB_NO_DATE", SB_NO_DATE);
                ReportParameter param9 = new ReportParameter("NFEI_TYPE", NFEI_TYPE);
                ReportParameter param10 = new ReportParameter("DECLARATION", DECLARATION);



                if (ds.Tables[0].Rows.Count > 0)
                {
                    EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    ViewState["EXPORTER_NAME"] = EXPORTER_NAME;
                }

                string Exporter = "";
                string Signature = "";

                string cha_Signature = "";
                string cha = "";
                string cha_title = "";
                string Img_sign = "";


                if (COMPANY_ID != "517" && COMPANY_ID != "480" && COMPANY_ID != "508")
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
                    // cha_title = Connection.Get_EXP_CHA_NAME().Replace("amp;", "");
                    cha_title = cha_Name;
                }
                else
                {
                    param = new ReportParameter("Title", EXPORTER_NAME);
                }

                if (COMPANY_ID == "517")
                {
                    Img_sign = "Y";
                    cha_Signature = Environment.NewLine + "R.DEVANANTH" + Environment.NewLine + "P.A.HOLDER" + Environment.NewLine + "CARD NO:34/2021";
                }
                else if (COMPANY_ID == "539")
                {
                    cha = "Exporter" + "/" + "CHA with date";
                    cha_Signature = "Signature";
                    cha_title = "For " + Connection.Get_EXP_CHA_NAME().Replace("amp;", "");
                    EXPORTER_NAME = "";
                    Exporter = "";
                    Signature = "";
                    cha_Signature = "";
                }


                ReportParameter param12 = new ReportParameter("Exporter", Exporter);
                ReportParameter param13 = new ReportParameter("EXPORTER_NAME", EXPORTER_NAME);
                ReportParameter param14 = new ReportParameter("Signature", Signature);

                ReportParameter param15 = new ReportParameter("CHA", cha);
                ReportParameter param16 = new ReportParameter("CHA_SIGNATURE", cha_Signature);
                ReportParameter param17 = new ReportParameter("CHA_TITLE", cha_title);

                string AEO_Regn = "";

                if (COMPANY_ID == "333")
                {
                    AEO_Regn = "AEO Regn.No   : INAAJCC4858N0F259       AEO_Role    : AEO-LO";
                }
                else if (COMPANY_ID == "421")
                {
                    AEO_Regn = "AEO Regn.No   : INAAJFV0053H0F238       AEO_Role    : AEO-LO";
                }
                else if (COMPANY_ID == "438")
                {
                    AEO_Regn = "AEO Regn.No   : INAAXCS0682E0F249       AEO_Role    : AEO-LO";
                }
                else if (COMPANY_ID == "752")
                {
                    if (CHA_NO == "AAACR6636ACH001")
                    {
                        AEO_Regn = "AEO Regn.No   : INAAACR6636A0F266       AEO_Role    : AEO-LO";
                    }
                }
                else if (COMPANY_ID == "862")
                {
                    AEO_Regn = "AEO Regn.No   : INAAJFC7174Q0F246       AEO_Role    : AEO-LO";
                }
                else if (COMPANY_ID == "824" || COMPANY_ID == "829")
                {
                    AEO_Regn = "AEO Regn.No   : INAABCP5904G0F211       AEO_Role    : CUSTOMS";
                }
                else if (COMPANY_ID == "1055")
                {
                    AEO_Regn = "AEO Regn.No   : INAARFS2091N0F189       AEO_Role    : AEO-LO";
                }
                else if (COMPANY_ID == "1144")
                {
                    AEO_Regn = "AEO Regn.No   : INAAACR0251M0F237       AEO_Role    : AEO-LO";
                }
                else if (COMPANY_ID == "1159" || COMPANY_ID == "1160")
                {
                    AEO_Regn = "AEO Regn.No   : INAABCS2390D0F192       AEO_Role    : AEO-LO";
                }
                else if (COMPANY_ID == "1686")
                {
                    AEO_Regn = "AEO Regn.No   : INAJRPS0647P0F226       AEO_Role    : AEO-LO";
                }
                else if (COMPANY_ID == "1207")
                {
                    AEO_Regn = "AEO Regn.No   : INAADCV4797M0F233       AEO_Role    : AEO-LO";
                }
                else if (COMPANY_ID == "2266")
                {
                    if (Connection.Current_User_Upper() != "ASHAPURA7" && Connection.Current_User_Upper() != "ASHAPURA8" && Connection.Current_User_Upper() != "ASHAPURA9" && Connection.Current_User_Upper() != "ASHAPURA10")
                    {
                        AEO_Regn = "AEO Regn.No   : INAACFT7897C0F203       AEO_Role    : ";
                    }
                }

                ReportParameter param18 = new ReportParameter("AEO_Regn", AEO_Regn);

                string SE = string.Empty;

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
                    else
                    {
                        SE = " ";
                    }
                }
                else
                {
                    SE = " ";
                }

                ReportParameter param11 = new ReportParameter("STATE_OF_EXPORT_CODE", SE);

                string CusHouse_Heading = "";
                if (SB_TYPE == "SEZ")
                {
                    CusHouse_Heading = "Cus.House & PortOf Loading";
                }
                else
                {
                    CusHouse_Heading = "Custom House";
                }
                ReportParameter param19 = new ReportParameter("CusHouse_Heading", CusHouse_Heading);
                ReportParameter param20 = new ReportParameter("Total_RODTEP_Amt", String.Format("{0:0.00}", Math.Round(TOTAL_RODTEP_VALUE, 2)));
                ReportParameter param21 = new ReportParameter("Total_ROSCTL_Amt", String.Format("{0:0.00}", Math.Round(TOT_SUM_LEV_AMT, 2)));
                ReportParameter param22 = new ReportParameter("Img_sign", Img_sign);

                //#FOB
                string Chk_Tot_Fob_Amt = "";
                //if (COMPANY_ID == "744" || COMPANY_ID == "196")
                if (COMPANY_ID == "744")
                {
                    Chk_Tot_Fob_Amt = String.Format("{0:0.00}", Convert.ToDouble((Math.Round(Convert.ToDecimal(SUM_TOTAL_FOB_VALUE), 0, MidpointRounding.AwayFromZero)).ToString()));
                }
                else if (COMPANY_ID == "3267")//newly implemented on 20-02-2026 by Chithra for KPS - sugg.by Bala //replacced RDLC -=Format(Round(val(Sum(val(Fields!FOB_VALUE.Value))),2),"0.00")
                {
                    Chk_Tot_Fob_Amt = String.Format("{0:0.00}", Convert.ToDouble((Math.Round(Convert.ToDecimal(SUM_TOTAL_FOB_VALUE), 2, MidpointRounding.AwayFromZero)).ToString()));// Cut off 2 Digit after the Decimal
                    //hide on 24-04-2026- Again round off issue for Invoice Value & FOB Value mismatch
                    //Chk_Tot_Fob_Amt = String.Format("{0:0.00}", Convert.ToDouble((Math.Truncate(SUM_TOTAL_FOB_VALUE * 100) / 100).ToString("F2")));// Cut off 2 Digit after the Decimal
                }
                else
                {
                    Chk_Tot_Fob_Amt = String.Format("{0:0.00}", Math.Round(SUM_TOTAL_FOB_VALUE, 2));
                }

                ReportParameter param23 = new ReportParameter("Total_FOB_Amt", Chk_Tot_Fob_Amt);

                ReportParameter[] p = { param, param1, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16, param17, param18, param19, param20, param21, param22, param23 };
                ReportViewer1.LocalReport.SetParameters(p);

                ReportViewer1.LocalReport.DisplayName = "Exp Checklist " + ddlJob_No.SelectedItem.Text;

                //--------------------------------------To Print------------------------------------------------------------------------------------//
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                string fileName = "a";
                byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Session.Remove("report");
                Session["report"] = bytes;
                //--------------------------------------To Print------------------------------------------------------------------------------------//


                //-----------------Skylift and Airlift On 21Sep2015-----------------------------//

                if (Session["COMPANY_ID"] != null)
                {

                    if (COMPANY_ID == "164" || COMPANY_ID == "165" || COMPANY_ID == "752")
                    {

                        errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + "EXP_Job_history" + "/");

                        if (Directory.Exists(errorFolder) == false)
                        {
                            Directory.CreateDirectory(errorFolder);
                        }

                        File.WriteAllBytes(errorFolder + ddlJobNo + " ~~" + ddlJobNo + ".pdf", bytes);
                        Upload_JobHistory();

                    }
                }

                //-----------------Skylift and Airlift On 21Sep2015-----------------------------//

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }


    public void Upload_JobHistory()
    {
        try
        {
            jh.JOB_ID = "";
            jh.JOB_TYPE = "EXP";
            jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
            //jh.JOBNO = ddlJobNo;
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


    public void GetGeneral()
    {
        try
        {
            GetGeneral1(ds, IS_ANNEXURE_MODE, Is_STR);
            ReportDataSource dataSource1 = new ReportDataSource("Export_General_DetailsNew", Rpt_General_list);
            Is_STR = is_STR_Code;
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }
    public void GetGeneral1(DataSet ds, int Annexue_Mode, int IS_STR)
    {
        try
        {
            is_Annexure_Mode = Annexue_Mode;
            is_STR_Code = IS_STR;

            Auto_Search auto = new Auto_Search();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string custom = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                string custom_name = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString();
                string custid = "", name = "", rows = string.Empty;
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
                TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();

                //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//
                string SB_dt = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
                if (SB_dt == "01/01/1900")
                {
                    SB_dt = "";
                }
                SB_NO_DATE = ds.Tables[0].Rows[0]["SB_NO"].ToString() + "  " + SB_dt;
                //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//

                if (is_Annexure_Mode == 1)
                {

                    if (TRANSPORT_MODE == "Air")
                    {
                        NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString();

                        LOOSE_PACKETS = string.Empty;
                        NO_CONTAINERS = string.Empty;
                        ANNEX_AIR_MAWB_NO = ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString();
                        ANNEX_AIR_HAWB_NO = ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString();

                        ANNEX_AIR_MAWB_DATE = ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString();
                        ANNEX_AIR_HAWB_DATE = ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_DATE"].ToString();

                        if (NATURE_OF_CARGO == "P")
                        {
                            NATURE_OF_CARGO = "P Packaged";
                        }
                    }
                    else if (TRANSPORT_MODE == "Sea" || TRANSPORT_MODE == "Land")
                    {
                        NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString();

                        LOOSE_PACKETS = ds.Tables[0].Rows[0]["LOOSE_PACKETS"].ToString();
                        NO_CONTAINERS = ds.Tables[0].Rows[0]["NO_CONTAINERS"].ToString();
                        ANNEX_AIR_MAWB_NO = string.Empty;
                        ANNEX_AIR_HAWB_NO = string.Empty;

                        ANNEX_SEA_SEAL_TYPE = ds.Tables[0].Rows[0]["SEAL_TYPE"].ToString();

                        if (NATURE_OF_CARGO == "C")
                        {
                            NATURE_OF_CARGO = "C Containerized";
                        }
                        else if (NATURE_OF_CARGO == "P")
                        {
                            NATURE_OF_CARGO = "P Packaged";
                        }
                        else if (NATURE_OF_CARGO == "CP")
                        {
                            NATURE_OF_CARGO = "CP Containerized";
                        }
                        else if (NATURE_OF_CARGO == "LB")
                        {
                            NATURE_OF_CARGO = "LB Liquid and Bulk";
                        }
                        else if (NATURE_OF_CARGO == "DB")
                        {
                            NATURE_OF_CARGO = "DB Dry Bulk";
                        }
                    }


                    ANNEX_AIR_ROTATION_NO = ds.Tables[0].Rows[0]["ROTATION_NO"].ToString();
                    ANNEX_AIR_ROTATION_DATE = ds.Tables[0].Rows[0]["ROTATION_DATE"].ToString().Replace("01/01/1900", "");


                    TOTAL_PACKAGES = ds.Tables[0].Rows[0]["TOTAL_PACKAGES"].ToString();
                    GROSS_WEIGHT = ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();
                    NET_WEIGHT = ds.Tables[0].Rows[0]["NET_WEIGHT"].ToString();
                    MARKS_NOS = ds.Tables[0].Rows[0]["MARKS_NOS"].ToString();

                }
                else if (is_Annexure_Mode == 2)
                {
                    if (TRANSPORT_MODE == "Air")
                    {
                        NATURE_OF_CARGO = string.Empty;

                        LOOSE_PACKETS = string.Empty;
                        NO_CONTAINERS = string.Empty;
                        ANNEX_AIR_MAWB_NO = string.Empty;
                        ANNEX_AIR_HAWB_NO = string.Empty;

                    }
                    else if (TRANSPORT_MODE == "Sea" || TRANSPORT_MODE == "Land")
                    {
                        NATURE_OF_CARGO = string.Empty;

                        LOOSE_PACKETS = string.Empty;
                        NO_CONTAINERS = string.Empty;
                        ANNEX_AIR_MAWB_NO = string.Empty;
                        ANNEX_AIR_HAWB_NO = string.Empty;

                    }
                }

                RBI_WAIVER_NO = ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString();
                RBI_WAIVER_DATE = ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString();
                if (RBI_WAIVER_DATE == "01/01/1900" || RBI_WAIVER_DATE == "01-01-1900")
                {
                    RBI_WAIVER_DATE = string.Empty;
                }
                else
                {
                    RBI_WAIVER_DATE = RBI_WAIVER_DATE;
                }
                IFSC_CODE = ds.Tables[0].Rows[0]["IFSC_CODE"].ToString();
                SB_TYPE = ds.Tables[0].Rows[0]["SB_TYPE"].ToString();
                PORT_OF_LOADING = ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();


                Get_ITEM_Details(ddlJobNo, ds.Tables[1], ds.Tables[2], ds.Tables[5], ds.Tables[15], ds.Tables[24], ds.Tables[25]);
                FOB_VALUE = Math.Round(SUM_TOTAL_FOB_VALUE, 2);

                DRAWBACK_VALUE = Convert.ToString(Math.Round(SUM_TOTAL_DBK_VALUE, 2).ToString("0.00"));
                STR_AMT = Convert.ToString(Math.Round(SUM_TOTAL_STR_AMT, 2));
                DBK_STR_AMT = Convert.ToDouble(DRAWBACK_VALUE) + Convert.ToDouble(STR_AMT);


                TAXABLE_VALUE = Convert.ToString(Math.Round(SUM_TOTAL_TAXABLE_VALUE, 2).ToString("0.00"));
                IGST_AMT = Convert.ToString(Math.Round(SUM_TOTAL_IGST_AMT, 2).ToString("0.00"));

                //Calculate Total FOB And DRAWBACK Value

                IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                IMP_EXP_PAN_NO = ds.Tables[0].Rows[0]["IMP_EXP_PAN_NO"].ToString();

                if (IMP_EXP_PAN_NO != "")
                {

                    IEC_NO = IEC_NO + "  PAN :" + IMP_EXP_PAN_NO;

                }
                else
                {
                    IEC_NO = IEC_NO;
                }

                TYPE_OF_EXPORTER = ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();

                if (TYPE_OF_EXPORTER == "R")
                {
                    TYPE_OF_EXPORTER = "[R] - Merchant";
                }
                else
                {
                    TYPE_OF_EXPORTER = "[F] - Manufacturer";
                }


                if (COMPANY_ID == "525")
                {
                    TYPE_OF_EXPORTER = "";
                }

                NFEI = ds.Tables[0].Rows[0]["NFEI"].ToString();
                NFEI_TYPE = ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString();

                GSTN_TYPE = ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                GSTN_ID = ds.Tables[0].Rows[0]["GSTN_ID"].ToString();


                //------------------------ Country Nama with Code----------------------------------
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
                //------------------------ Country Nama with Code----------------------------------

                if (SB_TYPE == "SEZ")
                {
                    CUSTOMS_HOUSE = custom + " & " + ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();
                }
                else
                {
                    CUSTOMS_HOUSE = custom + "-" + custom_name;
                }

                Rpt_General_list.Add(new Report_Export_Export_ReportViewer()
                {
                    JOBNO = ddlJobNo,
                    Today_dt = dt.Today_Date(),
                    JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString(),

                    TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString(),
                    CUSTOMS_HOUSE = CUSTOMS_HOUSE,
                    SB_TYPE = ds.Tables[0].Rows[0]["SB_TYPE"].ToString(),
                    EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString().Replace("amp;", ""),
                    BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString(),
                    //IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString(),
                    IEC_NO = IEC_NO,
                    ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString().Replace("amp;", ""),
                    ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString().Replace("amp;", ""),
                    ADDRESS3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString().Replace("amp;", ""),
                    ADDRESS4 = ds.Tables[0].Rows[0]["ADDRESS4"].ToString().Replace("amp;", ""),
                    ADDRESS5 = ds.Tables[0].Rows[0]["ADDRESS5"].ToString(),
                    ADCODE = ds.Tables[0].Rows[0]["ADCODE"].ToString(),
                    BANK_ACCOUNT = ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString(),
                    DRAWBACK_ACCOUNT = ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString(),
                    CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString().Replace("amp;", ""),
                    CONSIGNEE_ADD1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString().Replace("amp;", ""),
                    CONSIGNEE_ADD2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString().Replace("amp;", ""),
                    CONSIGNEE_ADD3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString().Replace("amp;", ""),
                    CONSIGNEE_ADD4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString().Replace("amp;", ""),
                    CONSIGNEE_ADD5 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString(),
                    COUNTRY_DISCHARGE = dt.Split("-", ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString()) + "-" + COUNTRY_DISCHARGE_Code,
                    //PORT_DISCHARGE = dt.Split("-", ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString()),
                    PORT_DISCHARGE = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString(),
                    COUNTRY_FINAL_DEST = dt.Split("-", ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString()) + "-" + COUNTRY_FINAL_DEST_Code,
                    //PORT_FINAL_DEST = dt.Split("-", ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString()),
                    PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString(),
                    STATE_OF_EXPORT = dt.Split("-", ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString()),
                    NFEI = NFEI,
                    NFEI_TYPE = NFEI_TYPE,
                    //RBI_WAIVER_NO = ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString(),

                    RBI_WAIVER_NO = RBI_WAIVER_NO,
                    RBI_WAIVER_DATE = RBI_WAIVER_DATE,
                    //RBI_WAIVER_DATE = RBI_WAIVER_NO + RBI_WAIVER_DATE,
                    MARKS_NO = ds.Tables[0].Rows[0]["MARKS_NO"].ToString(),


                    //NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString(),
                    NATURE_OF_CARGO = NATURE_OF_CARGO,
                    MARKS_NOS = MARKS_NOS,
                    TOTAL_PACKAGES = TOTAL_PACKAGES,
                    LOOSE_PACKETS = LOOSE_PACKETS,
                    NO_CONTAINERS = NO_CONTAINERS,

                    GROSS_WEIGHT = GROSS_WEIGHT,
                    NET_WEIGHT = NET_WEIGHT,
                    ANNEX_AIR_MAWB_NO = ANNEX_AIR_MAWB_NO,
                    ANNEX_AIR_HAWB_NO = ANNEX_AIR_HAWB_NO,
                    FOB_VALUE = FOB_VALUE,
                    DRAWBACK_VALUE = DRAWBACK_VALUE,
                    FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString(),
                    STR_AMT = STR_AMT,
                    DBK_STR_AMT = DBK_STR_AMT,
                    TYPE_OF_EXPORTER = TYPE_OF_EXPORTER,
                    GSTN_TYPE = GSTN_TYPE,
                    GSTN_ID = GSTN_ID,
                    ANNEX_SEA_SEAL_TYPE = ANNEX_SEA_SEAL_TYPE,
                    TAXABLE_VALUE = TAXABLE_VALUE,
                    IGST_AMT = IGST_AMT,
                    ANNEX_AIR_ROTATION_NO = ANNEX_AIR_ROTATION_NO,
                    ANNEX_AIR_ROTATION_DATE = ANNEX_AIR_ROTATION_DATE,
                    IFSC_CODE = IFSC_CODE,

                    ANNEX_AIR_MAWB_DATE = ANNEX_AIR_MAWB_DATE,
                    ANNEX_AIR_HAWB_DATE = ANNEX_AIR_HAWB_DATE,
                    ACTUAL_ITEM_FOB_VALUE = ACTUAL_ITEM_FOB_VALUE
                    //IMP_EXP_PAN_NO = ds.Tables[0].Rows[0]["IMP_EXP_PAN_NO"].ToString()

                });
            }
            //return list;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        
    }


    public void Get_ITEM_Details(string ddlJobNo, DataTable ds, DataTable ds2, DataTable dt, DataTable dt_sw_info, DataTable dt_item_Addl, DataTable dt_item_Rodtep)
    {
        try
        {
            Get_dt_Tbl_Items();
            SB_NO = Get_SBNo();

            Rpt_Item_Details_new_list.Clear();
            Rpt_DrawBack_Details_list.Clear();
            Rpt_ROSCTL_Details_list.Clear();
            Rpt_STR_Details_list.Clear();

            int b = 0, C = 0, i = 0;

            /*-------------- TryParse - Need to Implement for Fast Performance--10-03-2026--------
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
            DBK_VALUE = "0.00";
            TOT_SUM_LEV_AMT = 0.00;

            Rpt_DrawBack_Details_list.Clear();
            Rpt_ROSCTL_Details_list.Clear();
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
                // EXCHANGE_RATE = Return_Zero_Value1(ds.Rows[C]["EXCHANGE_RATE"].ToString());
                //INDIVIDUAL_FREIGHT_AMOUNT = Convert.ToDouble(FREIGHT_CHARGES = Return_Zero_Value(ds.Rows[C]["FREIGHT_CHARGES"].ToString()));
                //FREIGHT_CHARGES = Return_Zero_Value(ds.Rows[C]["FREIGHT_CHARGES"].ToString());
                //FREIGHT_EXRATE = Return_Zero_Value(ds.Rows[C]["FREIGHT_EXRATE"].ToString());
                //INSURANCE_CHARGES = Return_Zero_Value(ds.Rows[C]["INSURANCE_CHARGES"].ToString());
                //INSURANCE_EXRATE = Return_Zero_Value(ds.Rows[C]["INSURANCE_EXRATE"].ToString());
                //FREIGHT_RATE = Return_Zero_Value1(ds.Rows[C]["FREIGHT_RATE"].ToString());
                //INSURANCE_RATE = Return_Zero_Value1(ds.Rows[C]["INSURANCE_RATE"].ToString());
                //TERMS = ds.Rows[C]["TERMS"].ToString();

                COMMISSION_CURRENCY = ds.Rows[C]["COMMISSION_CURRENCY"].ToString();
                COMMISSION_RATE = Return_Zero_Value1(ds.Rows[C]["COMMISSION_RATE"].ToString());
                COMMISSION_CHARGES = Return_Zero_Value1(ds.Rows[C]["COMMISSION_CHARGES"].ToString());

                FOB_CURRENCY = ds.Rows[C]["FOB_CURRENCY"].ToString();
                FOB_RATE = Return_Zero_Value1(ds.Rows[C]["FOB_RATE"].ToString());
                FOB_CHARGES = Return_Zero_Value1(ds.Rows[C]["FOB_CHARGES"].ToString());
                //PACKMISC_RATE = Return_Zero_Value1(ds.Rows[C]["PACKMISC_RATE"].ToString());

                //PACKMISC_CHARGES = Return_Zero_Value1(ds.Rows[C]["PACKMISC_CHARGES"].ToString());
                OTHER_DEDUCTION_CURRENCY = ds.Rows[C]["OTHER_DEDUCTION_CURRENCY"].ToString();
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
                TOTAL_INSURANCE_AMOUNT = Convert.ToDouble(INSURANCE_CHARGES) * Convert.ToDouble(INSURANCE_EXRATE); ;
                TOTAL_PACKING_AMOUNT = Convert.ToDouble(PACKMISC_CHARGES) * Convert.ToDouble(PACKMISC_EXRATE);
                //---------------------------------------PMV VALUE INVOICE CALCULATION--------------------------------------//

                //ASSESSABLE_TOTAL = 0;
                //TOTAL_ITEM = 0.0;
                //TOTAL_DUTY = 0.0;
                b = 0;

                DataView view = ds2.DefaultView;
                view.RowFilter = "INVOICE_SLNO = " + curINVOICE_SLNO;
                DataTable table = view.ToTable();
              
                DataSet dss = new DataSet();
                dss.Tables.Add(table);
                int sum = 0;
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
                    INDIVIDUAL_COMMISSION_AMOUNT = 0;
                    INDIVIDUAL_INSURANCE_AMOUNT = 0;
                    INDIVIDUAL_FOB_DISCOUNT_AMOUNT = 0;
                    INDIVIDUAL_OTHER_DISCOUNT_AMOUNT = 0;
                    INDIVIDUAL_PACKING_CHARGE_AMOUNT = 0;
                    INDIVIDUAL_FOB_VALUE = 0;
                    TOTAL_FOB_AMOUNT = 0;
                    //TOTAL_ITEM_INVOICE_VALUE = Convert.ToDouble(sumObject.ToString());
                    INVOICE_SLNO = dss.Tables[0].Rows[b]["INVOICE_SLNO"].ToString();
                    INVOICE_NO = dss.Tables[0].Rows[b]["INVOICE_NO"].ToString();
                    //if (b == 0)
                    //{
                    //    ViewState["INVOICE_NO"] = INVOICE_NO;
                    //}
                    if (C == 0 && b == 0)
                    {
                        ViewState["FIRST_INVOICE_NO"] = INVOICE_NO;
                    }
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
                     * */



                    INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE), 5);

                    /* hide on 17-02-2024 by Chithra - Compared with Final Print & RIfor Invoice Value Round off issue-  Sugg.by Bala sir
                    //-----NILA SEA FOODS - Compared with Final Print & RI - by Chithra Suggg by Bala sir on 02-11-2023
                    if (COMPANY_ID == "10" || Session["COMPANY_ID"].ToString() == "663" || Session["COMPANY_ID"].ToString() == "1344" || Session["COMPANY_ID"].ToString() == "2078" || COMPANY_ID == "2082" || COMPANY_ID == "2151" || COMPANY_ID == "2168" || COMPANY_ID == "2152" || COMPANY_ID == "2153" || COMPANY_ID == "2154" || COMPANY_ID == "2155" || COMPANY_ID == "2219" || COMPANY_ID == "2226")
                    {
                        INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(Convert.ToDouble(INDIVIDUAL_ITEM_INVOICE_VALUE), 2);
                    }
                     */

                    Actual_Individual_Item_Amt = INDIVIDUAL_ITEM_INVOICE_VALUE;//Newly added for All calc - 01-03-2024
                    Actual_Individual_Item_Amt = Math.Round(INDIVIDUAL_ITEM_INVOICE_VALUE / Convert.ToDouble(ITEM_PER), 5);


                    //Commonly round of 2 Digit - Sugg.by Bala sir
                    // INDIVIDUAL_ITEM_INVOICE_VALUE = Math.Round(Convert.ToDouble(INDIVIDUAL_ITEM_INVOICE_VALUE), 2);//  hide on 22-03-2024 sugg.by Bala sir for LKS - if 5 means takes as "1" after digit
                    //if (Connection.COMPANYID() == "2244")//2 digit cut off after the point
                    //{
                    //    INDIVIDUAL_ITEM_INVOICE_VALUE = Convert.ToDouble((Math.Truncate(INDIVIDUAL_ITEM_INVOICE_VALUE)).ToString("F2"));
                    //}
                    //else
                    //{
                    //INDIVIDUAL_ITEM_INVOICE_VALUE = Convert.ToDouble((Math.Round(Convert.ToDecimal(INDIVIDUAL_ITEM_INVOICE_VALUE), 2, MidpointRounding.AwayFromZero)).ToString());
                    //}

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
                    //ITEM_AMOUNT = Convert.ToString(item_amt);
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

                    IGST_RATE = dss.Tables[0].Rows[b]["IGST_RATE"].ToString();
                    IGST_PAYMENT = dss.Tables[0].Rows[b]["IGST_PAYMENT"].ToString();


                    if (ITEM_AR4_NO != string.Empty)
                    {
                        Rpt_AR4_Details_list.Add(new Report_Export_Export_ReportViewer()
                        {
                            INVOICE_SLNO = INVOICE_SLNO,
                            ITEM_SLNO = ITEM_SLNO,
                            ITEM_AR4_NO = ITEM_AR4_NO,
                            ITEM_AR4_DATE = ITEM_AR4_DATE,
                            ITEM_COMMISSION_RATE = ITEM_COMMISSION_RATE,
                            ITEM_DIVISION = ITEM_DIVISION,
                            ITEM_RANGE = ITEM_RANGE,
                            ITEM_REMARKS = ITEM_REMARKS
                        });
                    }

                    //---------------------------AR4 DETAILS------------------------------------------//


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

                    //MANUFACTURER_PRODUCER = dss.Tables[0].Rows[b]["MANUFACTURER_PRODUCER"].ToString();
                    //M_P_GROWER_CODE = dss.Tables[0].Rows[b]["M_P_GROWER_CODE"].ToString();
                    //M_P_GROWER_ADD1 = dss.Tables[0].Rows[b]["M_P_GROWER_ADD1"].ToString();
                    //M_P_GROWER_ADD2 = dss.Tables[0].Rows[b]["M_P_GROWER_ADD2"].ToString();
                    //M_P_GROWER_CITY = dss.Tables[0].Rows[b]["M_P_GROWER_CITY"].ToString();
                    //M_P_GROWER_COUNTRY_SUBDIV = dss.Tables[0].Rows[b]["M_P_GROWER_COUNTRY_SUBDIV"].ToString();


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

                    //IND_PMV_VALUE = (Convert.ToDouble(IND_PMV_VALUE) / IND_PER_QTY);//Corrected on 26Sep2015

                    IND_TOTAL_PMV_VALUE = (Math.Round(IND_PMV_VALUE, 2) * Convert.ToDouble(ITEM_QTY)) / IND_PER_QTY;
                    //string a = Convert.ToString(Math.Round(IND_TOTAL_PMV_VALUE, 1).ToString("0.00"));// hide by Chithra on 22/04/2019 - for Oriental Mumbai - suggest by Bala & Ayisha
                    string a = Convert.ToString(Math.Round(IND_TOTAL_PMV_VALUE, 2).ToString("0.00"));

                    TOTAL_PMVVALUE = Convert.ToDouble(a);//Corrected on 26Sep2015

                    string fob = Convert.ToString(Math.Round(Get_Total_FOB_Value(INSURANCE_CHARGES, FREIGHT_CHARGES), 2).ToString("0.00"));
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
                        if (COMPANY_ID == "1242" || COMPANY_ID == "1")
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

                  
                    double item_pmv1 = 0.00;
                    //TOTAL_PMVVALUE = Convert.ToDouble(INDIVIDUAL_FOB_VALUE * 110 / 100);

                    // this Line hide by chithra on 14-01-2020 for Agility PMV rate Calc - put general calc
                    //TOTAL_PMVVALUE = Convert.ToDouble(Math.Round(INDIVIDUAL_FOB_VALUE, 2) * 110 / 100);

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

                    //------------------Start Cess and Duty Calculation-----------------------//

                    int ci = 0;
                    //foreach (DataRow dr in ds.Tables[0].Rows)


                    DataSet ds_cess = (DataSet)HttpContext.Current.Session["EXPORT_CHECKLIST"];

                    DataView cess_view1 = ds_cess.Tables[13].DefaultView;
                    cess_view1.RowFilter = "ITEM_SLNO = " + ITEM_SLNO + " and " + "INVOICE_SLNO = " + curINVOICE_SLNO;
                    DataTable cess_table1 = cess_view1.ToTable();


                    while (cess_table1.Rows.Count > ci)
                    {

                        INVOICE_SLNO = cess_table1.Rows[ci]["INVOICE_SLNO"].ToString();
                        ITEM_SLNO = cess_table1.Rows[ci]["ITEM_SLNO"].ToString();
                        CESS_SLNO = cess_table1.Rows[ci]["CESS_SLNO"].ToString();

                        CESS_VALUE = cess_table1.Rows[ci]["CESS_VALUE"].ToString();
                        CESS_UNIT = cess_table1.Rows[ci]["CESS_UNIT"].ToString();


                        CESS_FLAG = cess_table1.Rows[ci]["CESS_FLAG"].ToString();
                        CESS_RATE = cess_table1.Rows[ci]["CESS_RATE"].ToString();
                        CESS_ITEM_QTY = cess_table1.Rows[ci]["CESS_ITEM_QTY"].ToString();

                        CESS_ITEM_QTY_CODE = cess_table1.Rows[ci]["CESS_ITEM_QTY_CODE"].ToString();
                        CESS_TARIFF_VALUE = cess_table1.Rows[ci]["CESS_TARIFF_VALUE"].ToString();
                        CESS_TARIFF_UNIT = cess_table1.Rows[ci]["CESS_TARIFF_UNIT"].ToString();


                        if (CESS_TARIFF_VALUE == "")
                        {
                            if (CESS_RATE != "")
                            {
                                string cess_amount = Convert.ToString(Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(CESS_RATE) / 100);
                                cess_amount = Convert.ToString(Math.Round(Convert.ToDouble(cess_amount), 2).ToString("0.00"));

                                CESS_AMT = Convert.ToDouble(cess_amount);
                            }
                        }
                        else
                        {
                            if (CESS_TARIFF_VALUE != "")
                            {
                                if (CESS_RATE == "")
                                {
                                    CESS_RATE = "0.00";
                                }
                                if (CESS_ITEM_QTY == "")
                                {
                                    CESS_ITEM_QTY = "0.00";
                                }

                                string cess_amount = Convert.ToString(Convert.ToDouble(CESS_TARIFF_VALUE) * Convert.ToDouble(CESS_RATE) / 100);
                                cess_amount = Convert.ToString(Convert.ToDouble(cess_amount) * Convert.ToDouble(CESS_ITEM_QTY));
                                cess_amount = Convert.ToString(Math.Round(Convert.ToDouble(cess_amount), 2).ToString("0.00"));

                                CESS_AMT = Convert.ToDouble(cess_amount);
                            }
                        }

                        Rpt_Cess_Details_list.Add(new Report_Export_Export_ReportViewer()
                        {

                            INVOICE_SLNO = INVOICE_SLNO,
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
                            CESS_AMT = CESS_AMT

                        });

                        ci++;
                    }


                    //------------------End Cess and Duty Calculation-----------------------//

                    //---------------------- ITEM MANUFACTURE SW DETAILS --------------------------//

                    if (ACCESSORY_STATUS != "")
                    {
                        Rpt_ITEM_MANUFACTURER_SW_Details_list.Add(new Report_Export_Export_ReportViewer()
                        {

                            INVOICE_SLNO = INVOICE_SLNO,
                            ITEM_SLNO = ITEM_SLNO,
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
                            TOTAL_PKGS = TOTAL_PKGS

                        });
                    }

                    //---------------------- ITEM MANUFACTURE SW DETAILS --------------------------//


                    int oth = 0;

                    DataSet ds_other = (DataSet)HttpContext.Current.Session["EXPORT_CHECKLIST"];
                    DataView other_view1 = ds_other.Tables[22].DefaultView;
                    other_view1.RowFilter = "ITEM_SLNO = " + ITEM_SLNO + " and " + "INVOICE_SLNO = " + curINVOICE_SLNO;
                    DataTable oth_tbl = other_view1.ToTable();

                    while (oth_tbl.Rows.Count > oth)
                    {
                        INVOICE_SLNO = oth_tbl.Rows[oth]["INVOICE_SLNO"].ToString();
                        ITEM_SL_NO = oth_tbl.Rows[oth]["ITEM_SLNO"].ToString();
                        SQC = oth_tbl.Rows[oth]["SQC"].ToString();
                        INFO_UQC = oth_tbl.Rows[oth]["INFO_UQC"].ToString();
                        STATE = oth_tbl.Rows[oth]["STATE"].ToString();
                        DISTRICT = oth_tbl.Rows[oth]["DISTRICT"].ToString();
                        GCESS = oth_tbl.Rows[oth]["GCESS"].ToString();
                        PTA = oth_tbl.Rows[oth]["PTA"].ToString();

                        Rpt_ITEM_OTHER_Details_list.Add(new Report_Export_Export_ReportViewer()
                        {
                            INVOICE_SLNO = INVOICE_SLNO,
                            ITEM_SLNO = ITEM_SLNO,
                            SQC = SQC,
                            INFO_UQC = INFO_UQC,
                            STATE = STATE,
                            DISTRICT = DISTRICT,
                            GCESS = GCESS,
                            PTA = PTA
                        });
                        oth++;
                    }



                    //-------------------Start Quota Details----------------------------------//

                    int qi = 0;

                    DataSet ds_quota = (DataSet)HttpContext.Current.Session["EXPORT_CHECKLIST"];

                    DataView quota_view1 = ds_quota.Tables[14].DefaultView;
                    quota_view1.RowFilter = "ITEM_SL_NO = " + ITEM_SLNO + " and " + "INVOICE_SLNO = " + curINVOICE_SLNO;
                    DataTable quota_table1 = quota_view1.ToTable();


                    while (quota_table1.Rows.Count > qi)
                    {
                        INVOICE_SLNO = quota_table1.Rows[qi]["INVOICE_SLNO"].ToString();
                        ITEM_SL_NO = quota_table1.Rows[qi]["ITEM_SL_NO"].ToString();
                        AGENCY_CODE = quota_table1.Rows[qi]["AGENCY_CODE"].ToString();

                        AGENCY_NAME = quota_table1.Rows[qi]["AGENCY_NAME"].ToString();
                        ALLOCATION_NO = quota_table1.Rows[qi]["ALLOCATION_NO"].ToString();
                        EXPIRY_DATE = quota_table1.Rows[qi]["EXPIRY_DATE"].ToString();

                        SL_NO = SL_NO + 1;
                        Rpt_Quota_Details_list.Add(new Report_Export_Export_ReportViewer()
                          {
                              SL_NO = SL_NO,
                              INVOICE_SLNO = INVOICE_SLNO,
                              ITEM_SL_NO = ITEM_SL_NO,
                              AGENCY_CODE = AGENCY_CODE,
                              AGENCY_NAME = AGENCY_NAME,
                              ALLOCATION_NO = ALLOCATION_NO,
                              EXPIRY_DATE = EXPIRY_DATE


                          });

                        qi++;
                    }

                    //---------------------End Quota Details ---------------------------------//


                    //------------------Start Reward Details-----------------------//

                    //if (REWARD_POINTS != "")
                    //{
                    //    if (REWARD_POINTS == "Y")
                    //    {
                    //        Rpt_Reward_Details_list.Add(new Report_Export_Export_ReportViewer()
                    //        {

                    //            INVOICE_SLNO = INVOICE_SLNO,
                    //            ITEM_SLNO = ITEM_SLNO,
                    //            REWARD_POINTS = REWARD_POINTS


                    //        });
                    //    }
                    //}

                    //------------------End Reward Details-----------------------//


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

                    // --------------------------------------- STR CALCULATION---------------------------------------------------------------
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
                            //STR_AMOUNT = Convert.ToString(Math.Round(Convert.ToDouble(STR_AMOUNT), 1).ToString("0.00"));// hide by Chithra on 22/04/2019 - for Oriental Mumbai - suggest by Bala & Ayisha
                            STR_AMOUNT = Convert.ToString(Math.Round(Convert.ToDouble(STR_AMOUNT), 2).ToString("0.00"));

                            //TOTAL_STR_AMOUNT = Convert.ToString(Convert.ToDouble(TOTAL_STR_AMOUNT) + Convert.ToDouble(STR_AMOUNT));

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

                    // ---------------------------------------RE-EXPORT DETAILS--START-------------------------------------------------------------
                    DataSet ds_ReExport = (DataSet)HttpContext.Current.Session["EXPORT_CHECKLIST"];
                    int re = 0;

                    DataView Re_Export_view1 = ds_ReExport.Tables[21].DefaultView;
                    Re_Export_view1.RowFilter = "ITEM_SLNO = " + ITEM_SLNO + " and " + "INVOICE_SLNO = " + curINVOICE_SLNO;
                    DataTable Re_Exp_table1 = Re_Export_view1.ToTable();


                    while (Re_Exp_table1.Rows.Count > re)
                    {
                        INVOICE_SLNO = Re_Exp_table1.Rows[re]["INVOICE_SLNO"].ToString();
                        ITEM_SLNO = Re_Exp_table1.Rows[re]["ITEM_SLNO"].ToString();
                        SB_NO = Re_Exp_table1.Rows[re]["SB_NO"].ToString();

                        SB_DATE = Re_Exp_table1.Rows[re]["SB_DATE"].ToString();
                        SLNO = Re_Exp_table1.Rows[re]["SLNO"].ToString();
                        BE_SITE = Re_Exp_table1.Rows[re]["BE_SITE"].ToString();
                        BE_NO = Re_Exp_table1.Rows[re]["BE_NO"].ToString();
                        BE_DATE = Re_Exp_table1.Rows[re]["BE_DATE"].ToString();
                        BE_INVOICE_NO = Re_Exp_table1.Rows[re]["BE_INVOICE_NO"].ToString();
                        BE_INVOICE_ITEM_NO = Re_Exp_table1.Rows[re]["BE_INVOICE_ITEM_NO"].ToString();
                        MANUAL_BE_Y_N = Re_Exp_table1.Rows[re]["MANUAL_BE_Y_N"].ToString();
                        BE_QTY_UTILISED = Re_Exp_table1.Rows[re]["BE_QTY_UTILISED"].ToString();
                        BE_ITEM_DESC = Re_Exp_table1.Rows[re]["BE_ITEM_DESC"].ToString();
                        BE_QTY = Re_Exp_table1.Rows[re]["BE_QTY"].ToString();
                        BE_UQC = Re_Exp_table1.Rows[re]["BE_UQC"].ToString();
                        BE_ASS_VALUE = Re_Exp_table1.Rows[re]["BE_ASS_VALUE"].ToString();
                        BE_DUTY_PAID = Re_Exp_table1.Rows[re]["BE_DUTY_PAID"].ToString();
                        BE_DUTY_PAYMENT_DATE = Re_Exp_table1.Rows[re]["BE_DUTY_PAYMENT_DATE"].ToString();
                        BE_OTH_IDENTIFIABLE_PARAMETER = Re_Exp_table1.Rows[re]["BE_OTH_IDENTIFIABLE_PARAMETER"].ToString();
                        BE_ASS_VALUE_CLAIM = Re_Exp_table1.Rows[re]["BE_ASS_VALUE_CLAIM"].ToString();
                        BE_ITEM_USED_Y_N = Re_Exp_table1.Rows[re]["BE_ITEM_USED_Y_N"].ToString();
                        COMMISIONER_PERMISSION_Y_N = Re_Exp_table1.Rows[re]["COMMISIONER_PERMISSION_Y_N"].ToString();
                        INPUT_CREDIT_Y_N = Re_Exp_table1.Rows[re]["INPUT_CREDIT_Y_N"].ToString();
                        PERSONAL_USED_Y_N = Re_Exp_table1.Rows[re]["PERSONAL_USED_Y_N"].ToString();
                        MODVAT_AVAILED_Y_N = Re_Exp_table1.Rows[re]["MODVAT_AVAILED_Y_N"].ToString();
                        MODVAT_REPAID_Y_N = Re_Exp_table1.Rows[re]["MODVAT_REPAID_Y_N"].ToString();

                        //SL_NO = SL_NO + 1;
                        Rpt_ITEM_RE_EXPORT_Details_list.Add(new Report_Export_Export_ReportViewer()
                        {

                            INVOICE_SLNO = INVOICE_SLNO,
                            ITEM_SLNO = ITEM_SLNO,
                            SB_NO = SB_NO,
                            SB_DATE = SB_DATE,
                            SL_NO = SL_NO,
                            BE_SITE = BE_SITE,
                            BE_NO = BE_NO,
                            BE_DATE = BE_DATE,
                            BE_INVOICE_NO = BE_INVOICE_NO,
                            BE_INVOICE_ITEM_NO = BE_INVOICE_ITEM_NO,
                            MANUAL_BE_Y_N = MANUAL_BE_Y_N,
                            BE_QTY_UTILISED = BE_QTY_UTILISED,
                            BE_ITEM_DESC = BE_ITEM_DESC,
                            BE_QTY = BE_QTY,
                            BE_UQC = BE_UQC,
                            BE_ASS_VALUE = BE_ASS_VALUE,
                            BE_DUTY_PAID = BE_DUTY_PAID,
                            BE_DUTY_PAYMENT_DATE = BE_DUTY_PAYMENT_DATE,
                            BE_OTH_IDENTIFIABLE_PARAMETER = BE_OTH_IDENTIFIABLE_PARAMETER,
                            BE_ASS_VALUE_CLAIM = BE_ASS_VALUE_CLAIM,
                            BE_ITEM_USED_Y_N = BE_ITEM_USED_Y_N,
                            COMMISIONER_PERMISSION_Y_N = COMMISIONER_PERMISSION_Y_N,
                            INPUT_CREDIT_Y_N = INPUT_CREDIT_Y_N,
                            PERSONAL_USED_Y_N = PERSONAL_USED_Y_N,
                            MODVAT_AVAILED_Y_N = MODVAT_AVAILED_Y_N,
                            MODVAT_REPAID_Y_N = MODVAT_REPAID_Y_N

                        });

                        re++;
                    }


                    DataView dv_Other = dt.DefaultView;
                    dv_Other.RowFilter = "ITEM_SLNO = " + ITEM_SLNO + " and " + "INVOICE_SLNO = " + curINVOICE_SLNO;
                    DataTable tbl_other = dv_Other.ToTable();

                    if (tbl_other.Rows.Count >= i && tbl_other.Rows.Count != 0)
                    {
                    }



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
                    // ---------------------------------------END RODTEP CALCULATION--------------------------------------------------------------- ---------------------------------------END RODTEP CALCULATION---------------------------------------------------------------



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

                        //STATE_LEVEL_ADV_RATE = table1.Rows[i]["STATE_LEVEL_ADV_RATE"].ToString();
                        //STATE_LEVEL_ADV_AMT = table1.Rows[i]["STATE_LEVEL_ADV_AMT"].ToString();

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

                            //char last = DRAWBACK_SLNO[DRAWBACK_SLNO.Length - 1];
                            //string output = DRAWBACK_SLNO.Substring(DRAWBACK_SLNO.Length - 1, 1);


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
                                            LEV_VALUE_STATE = cal4;
                                        }
                                        else
                                        {
                                            LEV_VALUE_STATE = cal3;
                                        }
                                    }
                                    else
                                    {
                                        LEV_VALUE_STATE = cal4;
                                    }

                                }
                                else
                                {
                                    LEV_VALUE_STATE = cal3;
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
                                            LEV_VALUE_CENTRAL = cal6;
                                        }
                                        else
                                        {
                                            LEV_VALUE_CENTRAL = cal5;
                                        }
                                    }
                                    else
                                    {
                                        LEV_VALUE_CENTRAL = cal6;
                                    }

                                }
                                else
                                {
                                    LEV_VALUE_CENTRAL = cal5;
                                }

                                //----------------- ROSCTL New Implementation - 27-05-2019 -------------------

                                LEV_VALUE = LEV_VALUE_STATE + LEV_VALUE_CENTRAL;

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
                            //string DBK = Convert.ToString(Math.Round(DRAWBACK_VAL, 1).ToString("0.00"));
                            string DBK = Convert.ToString(Math.Round(DRAWBACK_VAL, 2).ToString("0.00"));// hide by Chithra on 22/04/2019 - for Oriental Mumbai - suggest by Bala & Ayisha
                            //DBK_VALUE = Convert.ToDouble(DBK);
                            DBK_VALUE = DBK;
                            // DBK_VALUE = Math.Round(DRAWBACK_VAL, 2);
                        }
                        //string TOTAL_DBK = Convert.ToString(Math.Round(TOTAL_DBK_VALUE + Convert.ToDouble(DBK_VALUE), 1).ToString("0.00"));
                        string TOTAL_DBK = Convert.ToString(Math.Round(TOTAL_DBK_VALUE + Convert.ToDouble(DBK_VALUE), 2).ToString("0.00"));// hide by Chithra on 22/04/2019 - for Oriental Mumbai - suggest by Bala & Ayisha
                        TOTAL_DBK_VALUE = Convert.ToDouble(TOTAL_DBK);


                        //-----------------------------DRAWBACK LIST ------------------------------//
                        Rpt_DrawBack_Details_list.Add(new Report_Export_Export_ReportViewer()
                        {
                            INVOICE_SLNO = INVOICE_SLNO,
                            INVOICE_NO = INVOICE_NO,
                            ITEM_SLNO = ITEM_SLNO,
                            // DRAWBACK_ID = DRAWBACK_ID,
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

                        if (SCHEME_CODE.Substring(0, 2) == "60" || SCHEME_CODE.Substring(0, 2) == "61" || SCHEME_CODE.Substring(0, 2) == "64" || SCHEME_CODE.Substring(0, 2) == "65")
                        {
                            if (STATE_LEVEL_ADV_RATE != "")
                            {
                                Rpt_ROSCTL_Details_list.Add(new Report_Export_Export_ReportViewer()
                                {
                                    INVOICE_SLNO = INVOICE_SLNO,
                                    ITEM_SLNO = ITEM_SLNO,
                                    DRAWBACK_SLNO = DRAWBACK_SLNO,
                                    DRAWBACK_QTY = DRAWBACK_QTY,
                                    DRAWBACK_UNIT = DRAWBACK_UNIT,

                                    STATE_LEVEL_ADV_RATE = STATE_LEVEL_ADV_RATE,
                                    STATE_LEVEL_ADV_AMT = STATE_LEVEL_ADV_AMT,

                                    CENTRAL_LEVEL_ADV_RATE = CENTRAL_LEVEL_ADV_RATE,
                                    CENTRAL_LEVEL_ADV_AMT = CENTRAL_LEVEL_ADV_AMT,

                                    TOT_LEV_AMT = TOT_LEV_AMT

                                });
                            }
                        }

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
                            TOT_LEV_AMT = TOT_LEV_AMT,

                            ENDUSE_ITEM = ENDUSE_ITEM,
                            IGST_PAYMENT = IGST_PAYMENT,
                            TAXABLE_VALUE = TAXABLE_VALUE,
                            IGST_AMT = IGST_AMT,

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
                            IFSC_CODE = IFSC_CODE,
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
                            IFSC_CODE = IFSC_CODE,
                            ACTUAL_ITEM_FOB_VALUE = ACTUAL_ITEM_FOB_VALUE

                        });
                    }


                    //Rpt_ITEM_OTHER_Details_list.Add(new Report_Export_Export_ReportViewer()
                    //    {
                    //    });
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

                    //dt_update.Rows.Add(dss.Tables[0].Rows[b]["ITEM_ID"].ToString(), ddlJobNo, INVOICE_SLNO, ITEM_SLNO, Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(FOB_VALUE), Convert.ToString(STR_RATE), Convert.ToString(STR_AMOUNT),
                    //                    Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(TAXABLE_VALUE), Convert.ToString(IGST_AMT), currentbranch, DBK_VALUE, RODTEP_VALUE, Working_Period);

                    //dt_update_Addl.Rows.Add(dss.Tables[0].Rows[b]["ITEM_ID"].ToString(), ddlJobNo, INVOICE_SLNO, INVOICE_NO, ITEM_SLNO, Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(FOB_VALUE), Convert.ToString(STR_RATE), Convert.ToString(STR_AMOUNT),
                    //                 Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(TAXABLE_VALUE), Convert.ToString(IGST_AMT), DBK_VALUE, RODTEP_VALUE, currentuser, LoginDate, currentbranch, "", Working_Period, Session["JOBNO_PS"].ToString());

                    if (Request.QueryString["Combine_CH"] == "Y")
                    {
                        dt_update.Rows.Add(dss.Tables[0].Rows[b]["ITEM_ID"].ToString(), dss.Tables[0].Rows[b]["JOBNO"].ToString(), INVOICE_SLNO, ITEM_SLNO, Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(FOB_VALUE), Convert.ToString(STR_RATE), Convert.ToString(STR_AMOUNT),
                                            Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(TAXABLE_VALUE), Convert.ToString(IGST_AMT), currentbranch, DBK_VALUE, RODTEP_VALUE, Working_Period);
                    }
                    else
                    {
                        dt_update.Rows.Add(dss.Tables[0].Rows[b]["ITEM_ID"].ToString(), ddlJobNo, INVOICE_SLNO, ITEM_SLNO, Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(FOB_VALUE), Convert.ToString(STR_RATE), Convert.ToString(STR_AMOUNT),
                                            Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(TAXABLE_VALUE), Convert.ToString(IGST_AMT), currentbranch, DBK_VALUE, RODTEP_VALUE, Working_Period);
                    }

                    if (Request.QueryString["Combine_CH"] == "Y")
                    {
                        dt_update_Addl.Rows.Add(dss.Tables[0].Rows[b]["ITEM_ID"].ToString(), dss.Tables[0].Rows[b]["JOBNO"].ToString(), INVOICE_SLNO, INVOICE_NO, ITEM_SLNO, Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(FOB_VALUE), Convert.ToString(STR_RATE), Convert.ToString(STR_AMOUNT),
                                    Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(TAXABLE_VALUE), Convert.ToString(IGST_AMT), DBK_VALUE, RODTEP_VALUE, currentuser, LoginDate, currentbranch, "", Working_Period, dss.Tables[0].Rows[b]["JOBNO_PS"].ToString(),
                                     RODTEP_RATE, RODTEP_CAP);

                    }
                    else
                    {
                        dt_update_Addl.Rows.Add(dss.Tables[0].Rows[b]["ITEM_ID"].ToString(), ddlJobNo, INVOICE_SLNO, INVOICE_NO, ITEM_SLNO, Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(FOB_VALUE), Convert.ToString(STR_RATE), Convert.ToString(STR_AMOUNT),
                                    Convert.ToString(TOTAL_PMVVALUE), Convert.ToString(TAXABLE_VALUE), Convert.ToString(IGST_AMT), DBK_VALUE, RODTEP_VALUE, currentuser, LoginDate, currentbranch, "", Working_Period, Session["JOBNO_PS"].ToString(),
                                     RODTEP_RATE, RODTEP_CAP);

                    }

                    SUM_TOTAL_STR_AMT = SUM_TOTAL_STR_AMT + Convert.ToDouble(STR_AMOUNT);

                    b++;

                }
                SUM_TOTAL_DBK_VALUE = SUM_TOTAL_DBK_VALUE + TOTAL_DBK_VALUE;

                //SUM_TOTAL_STR_AMT = SUM_TOTAL_STR_AMT + Convert.ToDouble(STR_AMOUNT);


                INV_TOTAL_DBK_VAL = Convert.ToDouble(TOTAL_DBK_VALUE);

                Get_Invoice_Details(ds.Rows[C], count, Convert.ToString(TOTAL_INV_VALUE));
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

    public void Get_Invoice_Details(DataRow row, string count, string INDIVIDUAL_INV_VALUE)
    {
        try
        {
            No_Of_Invoices = row["No_Of_Invoices"].ToString();
            INVOICE_CURRENCY = row["INVOICE_CURRENCY"].ToString();

            COMMISSION_CURRENCY = row["COMMISSION_CURRENCY"].ToString();
            COMMISSION_RATE = Return_Zero_Value1(row["COMMISSION_RATE"].ToString());
            COMMISSION_CHARGES = Return_Zero_Value1(row["COMMISSION_CHARGES"].ToString());

            FOB_CURRENCY = Return_Zero_Value1(row["FOB_CURRENCY"].ToString());
            FOB_RATE = Return_Zero_Value1(row["FOB_RATE"].ToString());
            //FOB_CHARGES = Return_Zero_Value1(row["FOB_CHARGES"].ToString());
            FOB_CHARGES = Return_Zero_Value1(Convert.ToString(DISCOUNT_RATE_AMOUNT));


            PACKMISC_CURRENCY = Return_Zero_Value1(row["PACKMISC_CURRENCY"].ToString());
            PACKMISC_RATE = Return_Zero_Value1(row["PACKMISC_RATE"].ToString());
            PACKMISC_CHARGES = Return_Zero_Value1(row["PACKMISC_CHARGES"].ToString());

            OTHER_DEDUCTION_CURRENCY = Return_Zero_Value1(row["OTHER_DEDUCTION_CURRENCY"].ToString());
            OTHER_DEDUCTION_RATE = Return_Zero_Value1(row["OTHER_DEDUCTION_RATE"].ToString());
            //OTHER_DEDUCTION_CHARGES = Return_Zero_Value1(row["OTHER_DEDUCTION_CHARGES"].ToString());
            OTHER_DEDUCTION_CHARGES = Return_Zero_Value1(Convert.ToString(OTHER_DETDUCTION_RATE_AMOUNT));

            FREIGHT_RATE = Return_Zero_Value1(row["FREIGHT_RATE"].ToString());
            FREIGHT_CHARGES = Return_Zero_Value1(row["FREIGHT_CHARGES"].ToString());

            INSURANCE_RATE = Return_Zero_Value1(row["INSURANCE_RATE"].ToString());

            INSURANCE_CHARGES = Return_Zero_Value1(row["INSURANCE_CHARGES"].ToString());
            FREIGHT_CURRENCY = row["FREIGHT_CURRENCY"].ToString();

            INSURANCE_CURRENCY = row["INSURANCE_CURRENCY"].ToString();
            TERMS = row["TERMS"].ToString();

            if (TERMS == "CF")
            {
                INSURANCE_CURRENCY = INVOICE_CURRENCY;
            }
            else if (TERMS == "CI")
            {
                FREIGHT_CURRENCY = INVOICE_CURRENCY;
            }

            INVOICE_SLNO = row["INVOICE_SLNO"].ToString();

            INVOICE_NO = row["INVOICE_NO"].ToString();

            if (COMMISSION_RATE != "" && COMMISSION_RATE != "0.00")
            {
                double inv_val = Convert.ToDouble(INVOICE_VALUE_FC);
                COMMISSION_CHARGES = Convert.ToString(Math.Round((inv_val * Convert.ToDouble(COMMISSION_RATE) / 100), 2));
            }

            //#Invoice
            if ((COMPANY_ID == "160" && SELECT_BRANCH == "CusHouse, Chennai") || COMPANY_ID == "1" || COMPANY_ID == "2" || COMPANY_ID == "128" || COMPANY_ID == "252" || COMPANY_ID == "284" || COMPANY_ID == "382" || COMPANY_ID == "439" || COMPANY_ID == "472" || COMPANY_ID == "490" || COMPANY_ID == "517" || COMPANY_ID == "525" || COMPANY_ID == "529" || COMPANY_ID == "532" || COMPANY_ID == "538" || COMPANY_ID == "747" || COMPANY_ID == "1088" || COMPANY_ID == "1120" || COMPANY_ID == "1229" || COMPANY_ID == "1520" || COMPANY_ID == "2244" || COMPANY_ID == "2398")
            {
                INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(INVOICE_VALUE_FC) * Convert.ToDecimal(EXCHANGE_RATE);
                INDIVIDUAL_INVOICE_VALUE = Math.Round(INDIVIDUAL_INVOICE_VALUE, 2);
                //INVOICE_VALUE_FC = Math.Round(INVOICE_VALUE_FC, 2);
                INVOICE_VALUE_FC = Convert.ToString((Math.Round(Convert.ToDouble(INVOICE_VALUE_FC), 2)).ToString("0.00"));
            }
            else if (COMPANY_ID == "3267") // Cut off 2 Digit after the Decimal
            {
                INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(INVOICE_VALUE_FC) * Convert.ToDecimal(EXCHANGE_RATE);
                INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal((Math.Truncate(INDIVIDUAL_INVOICE_VALUE * 100) / 100).ToString("F2"));
            }
            else if (COMPANY_ID == "437" || COMPANY_ID == "441" || COMPANY_ID == "1054" || COMPANY_ID == "1033")
            {
                INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(INVOICE_VALUE_FC) * Convert.ToDecimal(EXCHANGE_RATE);
                //INDIVIDUAL_INVOICE_VALUE =Convert.ToDouble(Convert.ToString(INDIVIDUAL_INVOICE_VALUE.ToString("0.000")));

                INDIVIDUAL_INVOICE_VALUE = Math.Truncate(INDIVIDUAL_INVOICE_VALUE * 100) / 100; //decimal places without rounding
            }
            else
            {
                INDIVIDUAL_INVOICE_VALUE = Convert.ToDecimal(INVOICE_VALUE_FC) * Convert.ToDecimal(EXCHANGE_RATE);
                INVOICE_VALUE_FC = Convert.ToString((Math.Round(Convert.ToDouble(INVOICE_VALUE_FC), 2)).ToString("0.00"));
            }

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
            TERMS_PLACE = row["TERMS_PLACE"].ToString();

            if (COMPANY_ID == "441" || COMPANY_ID == "1054" || COMPANY_ID == "1033")
            {
                //INVOICE_VALUE_FC = Math.Truncate(INVOICE_VALUE_FC * 100) / 100;
                INVOICE_VALUE_FC = Convert.ToString(Math.Truncate(Convert.ToDouble(INVOICE_VALUE_FC) * 100) / 100);
            }

            //#FOB (FC) - Value which is showing in Checklist with Round off 2 digit
            /*
            if (COMPANY_ID == "1" || COMPANY_ID == "132" || COMPANY_ID == "170" || COMPANY_ID == "196" || COMPANY_ID == "335" || COMPANY_ID == "354" || COMPANY_ID == "387" || COMPANY_ID == "517" || COMPANY_ID == "525" || COMPANY_ID == "582" || COMPANY_ID == "747" || COMPANY_ID == "757" || COMPANY_ID == "944" || COMPANY_ID == "1005" || COMPANY_ID == "1039" || COMPANY_ID == "1088" || COMPANY_ID == "1144" || COMPANY_ID == "1344" || COMPANY_ID == "1545" || COMPANY_ID == "1639" || COMPANY_ID == "1660" || COMPANY_ID == "1663" || COMPANY_ID == "2078" || COMPANY_ID == "2082" || COMPANY_ID == "2151" || COMPANY_ID == "2168" || COMPANY_ID == "2152" || COMPANY_ID == "2153" || COMPANY_ID == "2154" || COMPANY_ID == "2155" || COMPANY_ID == "2226" || COMPANY_ID == "2338" || COMPANY_ID == "2602" || COMPANY_ID == "2745")
            {
                string str_FOB_AMOUNT_FC = Convert.ToString(Math.Round(Convert.ToDouble(FOB_AMOUNT_FC), 2).ToString("0.00"));
                FOB_AMOUNT_FC = str_FOB_AMOUNT_FC;
            }
            */

            //#FOB - Above Condition commonly implemented for all the Clients - Sugg.by Bala sir on 21-10-2024
            str_FOB_AMOUNT_FC = "0.00";

            //if (COMPANY_ID == "744" || COMPANY_ID == "196")//196 newly added on 17-06-2026 by Chithra
            if (COMPANY_ID == "744")//sunglobal
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
                //INDIVIDUAL_INVOICE_VALUE = Convert.ToDouble(INDIVIDUAL_INV_VALUE),

                //INDIVIDUAL_INVOICE_VALUE = Convert.ToDouble(INVOICE_VALUE_FC) * Convert.ToDouble(EXCHANGE_RATE),
                INDIVIDUAL_INVOICE_VALUE = INDIVIDUAL_INVOICE_VALUE,
                INVOICE_VALUE_FC = INVOICE_VALUE_FC,
                DBK_VALUE = Convert.ToString(INV_TOTAL_DBK_VAL),

                //FOB_AMOUNT_FC=Math.Round(FOB_AMOUNT_FC,2),
                FOB_AMOUNT_FC = FOB_AMOUNT_FC,
                //No_Of_Invoices = Convert.ToString(count),
                No_Of_Invoices = No_Of_Invoices,

                INVOICE_SLNO = row["INVOICE_SLNO"].ToString(),

                INVOICE_NO = row["INVOICE_NO"].ToString(),

                INVOICE_DATE = row["INVOICE_DATE"].ToString(),
                PAYMENT_METHOD = row["PAYMENT_METHOD"].ToString(),
                PERIOD_PAYMENT = row["PERIOD_PAYMENT"].ToString(),
                //INVOICE_VALUE = row["INVOICE_VALUE"].ToString(),
                INVOICE_VALUE = Convert.ToString(TOTAL_ITEM_INVOICE_VALUE),

                INVOICE_CURRENCY = INVOICE_CURRENCY,
                EXCHANGE_RATE = row["EXCHANGE_RATE"].ToString(),
                CONTRACT_NO = row["CONTRACT_NO"].ToString(),
                TERMS = TERMS,
                BUYER = row["BUYER"].ToString(),
                BUYER_NAME = row["BUYER_NAME"].ToString(),
                BUYER_ADDRESS = row["BUYER_ADDRESS"].ToString(),
                BUYER_ADDRESS1 = row["BUYER_ADDRESS1"].ToString(),
                BUYER_ADDRESS2 = row["BUYER_ADDRESS2"].ToString(),
                BUYER_ADDRESS3 = row["BUYER_ADDRESS3"].ToString(),

                BUYER_ADDRESS4 = row["BUYER_ADDRESS4"].ToString(),

                COMMISSION_RATE = COMMISSION_RATE,

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
                WHEATHER_UNIT_PRICE = row["WHEATHER_UNIT_PRICE"].ToString(),
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
                TERMS_PLACE = TERMS_PLACE

            });
            DISCOUNT_RATE_AMOUNT = 0;
            OTHER_DETDUCTION_RATE_AMOUNT = 0;
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
            //string INDIVIDUAL_COMMISSION_RATE="";

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

                /* hide by Chithra suggest by Ayisha on 08/02/2019 for ATCL & SANCO Compared in Final Copy
                if (Convert.ToDouble(COMMISSION_RATE) > 12.50)
                {
                    FULL_COMMISSION_AMT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(COMMISSION_RATE)) / 100;

                    commis_rate = Convert.ToDouble(COMMISSION_RATE) - 12.50;
                    //COMMISSION_RATE = Convert.ToString(Convert.ToDouble(COMMISSION_RATE) - commis_rate);
                    INDIVIDUAL_COMMISSION_RATE = Convert.ToString(Convert.ToDouble(COMMISSION_RATE) - commis_rate);
                    INDIVIDUAL_COMMISSION_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(INDIVIDUAL_COMMISSION_RATE)) / 100;
                }
                else
                {
                    INDIVIDUAL_COMMISSION_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(COMMISSION_RATE)) / 100;                
                    INDIVIDUAL_COMMISSION_AMOUNT = Convert.ToDouble(INDIVIDUAL_COMMISSION_AMOUNT) * Convert.ToDouble(EXCHANGE_RATE); //-----Updated on 29Jan2019 By Sathish with Ayisha and Bala ( For Transmarine)------//
                }
            

                //newly condition put for ATCL by Chithra suggest by Bala sir on 09-06-2018
                if (FULL_COMMISSION_AMT > 0)
                {
                    REMAINING_COMMISSION_AMT = FULL_COMMISSION_AMT - INDIVIDUAL_COMMISSION_AMOUNT;
                    REMAINING_COMMISSION_AMT = Convert.ToDouble(REMAINING_COMMISSION_AMT) * Convert.ToDouble(EXCHANGE_RATE);//EXCHANGE_RATE - INVOICE EX_RATE
                }        
                */

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
            //-----COMMSSION AMOUNT CAL--------------//

            //-----INSURANCE AMOUNT CAL--------------//
            /*// hide on 14-12-2020 for Agility by Chithra sugg.by Mohmed&Bala - first should be check  INSURANCE_CHARGES ,then only check INSURANCE_RATE
            if (INSURANCE_RATE != "0" && INSURANCE_RATE != "0.00")
            {
                INDIVIDUAL_INSURANCE_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(INSURANCE_RATE)) / 100;

                //this line newly implmntd by chithra on 10-03-2020 sugg by Subbu sir & mohmed for SeaGull logs-eri01159
                INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Convert.ToDouble(INSURANCE_EXRATE);
            }
            else if (INSURANCE_CHARGES != "0" && INSURANCE_CHARGES != "0.00")
            {
                INDIVIDUAL_INSURANCE_AMOUNT = Convert.ToDouble(INSURANCE_CHARGES) * Convert.ToDouble(INSURANCE_EXRATE);
            }
           */

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
                // text_Discount = (INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value);//hide on 01-03-2024 for RoseMount digits mismatch issue
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
                INDIVIDUAL_FOB_VALUE = Convert.ToDouble(INDIVIDUAL_INVOICE_VALUE) + text_packing - (text_Discount + text_OTHER_DISCOUNT + REMAINING_COMMISSION_AMT);

                //INDIVIDUAL_FOB_VALUE = INDIVIDUAL_ITEM_INVOICE_VALUE + INDIVIDUAL_PACKING_CHARGE_AMOUNT - (INDIVIDUAL_FOB_DISCOUNT_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT);

                //INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE * Convert.ToDouble(EXCHANGE_RATE);

                //---CHECKLIST -IGST BASED ON VALUE --
                INDIVIDUAL_ITEM_IGST_BASED_VALUE = INDIVIDUAL_FOB_VALUE;


                //----------- below calc- suggest by Bala sir for TransMarine on 21-02-2020 checked in Final Copy -- done by Chithra -----------------------
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
                //INDIVIDUAL_FREIGHT_AMOUNT = INDIVIDUAL_FREIGHT_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value;

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

                /*
                INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value;
                INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Actual_Individual_Item_Amt_INR / Total_Item_Value;
                 * */

                INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Individual_Item_Value / Total_Item_Value;
                INDIVIDUAL_COMMISSION_AMOUNT = INDIVIDUAL_COMMISSION_AMOUNT * Individual_Item_Value / Total_Item_Value;

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
                        fob_12_5 = Math.Round(fob_12_5, 2);

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

                //INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
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
                //else if (WHEATHER_UNIT_PRICE == "N")
                //{
                //    //INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT); hide by Chithra suggest by Bala sir on 09-06-2018 for add remaining Commission 
                //    INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT + REMAINING_COMMISSION_AMT);
                //    INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value + SFIValue1;
                //}

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

                //INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Individual_Item_Value / Total_Item_Value; // hide by Chithra with Bala sir on 19-06-2018 for LIZMA

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
                TOTAL_INV_VALUE = TOTAL_INV_VALUE + Actual_Individual_Item_Amt_INR;// Newly added on 08-03-2024 for FreightLog - Invoice Value mismatch issue - Sugg.Bala
                INVOICE_VALUE_FC = Convert.ToString((Convert.ToDouble(TOTAL_INV_VALUE) / Convert.ToDouble(EXCHANGE_RATE) - Convert.ToDouble(DISCOUNT_RATE_AMOUNT)) + Convert.ToDouble(PACKMISC_CHARGES) - (Convert.ToDouble(OTHER_DETDUCTION_RATE_AMOUNT)));
            }

            //Need Settings Here
            if (COMPANY_ID == "747" || COMPANY_ID == "694" || COMPANY_ID == "2004")//Invoice Value should be Round off after 2 digit - reqrd by Mari Agility
            {
                INVOICE_VALUE_FC = Convert.ToString((Math.Round(Convert.ToDecimal(INVOICE_VALUE_FC), 2, MidpointRounding.AwayFromZero)).ToString());
            }
            else if (COMPANY_ID == "128")//Invoice Value should be same as FOB Value
            {
                INVOICE_VALUE_FC = INVOICE_VALUE_FC;
            }
            else
            {
                INVOICE_VALUE_FC = Convert.ToString((Math.Round(Convert.ToDouble(INVOICE_VALUE_FC), 2)).ToString("0.00"));
            }

            //INVOICE_VALUE_FC = INVOICE_VALUE_FC / IND_PER_QTY;
            //INVOICE_VALUE_FC = INVOICE_VALUE_FC + INVOICE_VALUE_FC;

            //INVOICE_VALUE_FC = INVOICE_VALUE_FC + Convert.ToDouble(OTHER_DEDUCTION_CHARGES);
            //TOTAL_INV_VALUE = INVOICE_VALUE_FC;


            //TOTAL_FOB_AMOUNT = TOTAL_FOB_AMOUNT + INDIVIDUAL_FOB_VALUE; // hide by Chithra on 07-05-2019 for Oriental - FOB Value round off 2 digit suggest by Bala sir
            /* hide on 19-03-2024 By chithra for checklist top TOTAL_FOB_AMOUNT digits mimatch issue for Rosemount
           if (COMPANY_ID != "525" && COMPANY_ID != "1039" && COMPANY_ID != "1344" && COMPANY_ID != "2078" && COMPANY_ID != "2082" && COMPANY_ID != "2151" && COMPANY_ID != "2168" && COMPANY_ID != "2152" && COMPANY_ID != "2153" && COMPANY_ID != "2154" && COMPANY_ID != "2155")
           {
               TOTAL_FOB_AMOUNT = TOTAL_FOB_AMOUNT + Math.Round(Convert.ToDouble(INDIVIDUAL_FOB_VALUE), 2);
           }
           else
           {
               TOTAL_FOB_AMOUNT = TOTAL_FOB_AMOUNT + INDIVIDUAL_FOB_VALUE;
           }
             * */

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

            /*
             FOB_AMOUNT_FC = Convert.ToString((Convert.ToDouble(FOB_AMOUNT_FC) + FOB_AMT_FC).ToString("0.00"));
             if (COMPANY_ID != "525")
             {
                 //FOB_AMOUNT_FC = Math.Round(FOB_AMOUNT_FC, 2);
                 FOB_AMOUNT_FC =Convert.ToString(( Math.Round(Convert.ToDouble(FOB_AMOUNT_FC), 2)).ToString("0.00"));
             }
             */


            //#FOB (FC) - Value - Item wise Calc here //-need to implement settings here
            /*
            if (COMPANY_ID != "1" && COMPANY_ID != "132" && COMPANY_ID != "170" && COMPANY_ID != "196" && COMPANY_ID != "335" && COMPANY_ID != "354" && COMPANY_ID != "387" && COMPANY_ID != "517" && COMPANY_ID != "525" && COMPANY_ID != "582" && COMPANY_ID != "624" && COMPANY_ID != "757" && COMPANY_ID != "944" && COMPANY_ID != "752" && COMPANY_ID != "747" && COMPANY_ID != "1005" && COMPANY_ID != "1144" && COMPANY_ID != "1344" && COMPANY_ID != "1088" && COMPANY_ID != "1545" && COMPANY_ID != "1639" && COMPANY_ID != "1658" && COMPANY_ID != "1660" && COMPANY_ID != "1663" && COMPANY_ID != "2078" && COMPANY_ID != "2082" && COMPANY_ID != "2151" && COMPANY_ID != "2168" && COMPANY_ID != "2152" && COMPANY_ID != "2153" && COMPANY_ID != "2154" && COMPANY_ID != "2155" && COMPANY_ID != "2226" && COMPANY_ID != "2338" && COMPANY_ID != "2602" && COMPANY_ID != "2745")
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
    public void Invoice_Details()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("Export_Invoice_Details", Rpt_Invoice_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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
            Connection.Error_Msg(ex.Message);
        }
       
    }

    protected void ReportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("Item_Details", Rpt_Item_Details_new_list);
            e.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     
    }

    public void Drawback_Details()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("Item_Details", Rpt_DrawBack_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }

    public void ROSCTL_Details()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("DataSet3", Rpt_ROSCTL_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public void License_Details()
    {
        try
        {
            Rpt_License_Details License = new Rpt_License_Details();
            ReportDataSource dataSource = new ReportDataSource("Export_License_Details", License.Get_LICENSE_DETAILS(ds.Tables[3], ds.Tables[4]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    

    }

    public void ThirdParty_Details()
    {
        try
        {
            Rpt_ThirdParty_Details Third = new Rpt_ThirdParty_Details();
            ReportDataSource dataSource = new ReportDataSource("Export_ThirdParty_Details", Third.Get_ThirdParty_Details(ds.Tables[2]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }

    public void Accessory_Details()
    {
        try
        {
            Rpt_Accessory_Details Accessory = new Rpt_Accessory_Details();
            ReportDataSource dataSource = new ReportDataSource("EXPORT_ACCESSORY_DETAILS", Accessory.Get_Accessory_Details(ds.Tables[2]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    

    }

    public void Jobbing_Details()
    {
        try
        {
            Rpt_Jobbing_Details Job = new Rpt_Jobbing_Details();
            ReportDataSource dataSource = new ReportDataSource("Export_Jobbing_Details", Job.Get_JOBBING_DETAILS(ds.Tables[6]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     

    }

    public void STR_Details()
    {
        try
        {
            //Rpt_Item_Details ITEM = new Rpt_Item_Details();
            //ReportDataSource dataSource1 = new ReportDataSource("Export_STR_Details", ITEM.Get_STR_Details(ddlJobNo, ds.Tables[1], ds.Tables[2], ds.Tables[5], Is_STR));
            ReportDataSource dataSource1 = new ReportDataSource("Export_STR_Details", Rpt_STR_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
       
    }

    public void Item_Manufaturer_SW_Details()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("DataSet1", Rpt_ITEM_MANUFACTURER_SW_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }

    public void Item_Other_Details()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("DataSet4", Rpt_ITEM_OTHER_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }


    public void RODTEP_Details()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("DataSet5", Rpt_RODTEP_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     
    }

    public void Item_RE_EXPORT_Details()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("DataSet2", Rpt_ITEM_RE_EXPORT_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }

    public void Reward_Details()
    {
        try
        {
            ReportDataSource dataSource1 = new ReportDataSource("Export_Reward_Details", Rpt_Reward_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }


    public void AR4_Details()
    {
        try
        {
            Rpt_Goods_Reg_AR4 ar4 = new Rpt_Goods_Reg_AR4();
            ReportDataSource dataSource1 = new ReportDataSource("EXPORT_AR4_DETAILS", ar4.Export_AR4(ds.Tables[9]));

            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    public void EOU_Details()
    {
        try
        {
            Rpt_Annexure_C1_Details Annex = new Rpt_Annexure_C1_Details();
            ReportDataSource dataSource1 = new ReportDataSource("EXPORT_ANNEX_C1_DETAILS", Annex.Get_Export_Annexure_c1_Details(ds.Tables[7]));

            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public void Container_Details()
    {
        try
        {
            Rpt_Container_Details Container = new Rpt_Container_Details();
            ReportDataSource dataSource = new ReportDataSource("EXPORT_ANNEXURE_C_SEA_CONTAINER", Container.Get_CONTAINER_DETAILS(ds.Tables[10]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      

    }

    public void Annexure_Sea_Details()
    {
        try
        {
            Rpt_Annexure_Sea_Details Sea = new Rpt_Annexure_Sea_Details();
            ReportDataSource dataSource = new ReportDataSource("EXPORT_ANNEXURE_C_SEA", Sea.Get_ANNEXURE_SEA_DETAILS(ds.Tables[11]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     

    }

    public void Package_Details()
    {
        try
        {
            Rpt_Package_Details Package = new Rpt_Package_Details();
            ReportDataSource dataSource = new ReportDataSource("EXPORT_ANNEXURE_C_SEA_PACKAGE", Package.Get_PACKAGE_DETAILS(ds.Tables[12]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }

    public void SW_ITEM_INFO_TYPE_DETAILS()
    {
        try
        {
            Rpt_Single_Window SW_Details = new Rpt_Single_Window();
            ReportDataSource dataSource1 = new ReportDataSource("Exp_Sw_Info_Type", SW_Details.Get_Single_Window_details_INFOTYPE(ds.Tables[15]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    public void SW_ITEM_CONSTITUTE_DETAILS()
    {
        try
        {
            Rpt_Single_Window SW_Details = new Rpt_Single_Window();
            ReportDataSource dataSource1 = new ReportDataSource("Exp_Sw_Const", SW_Details.Get_Single_Window_details_Constituent(ds.Tables[16]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }

    public void SW_ITEM_PRODUCTION_DETAILS()
    {
        try
        {
            Rpt_Single_Window SW_Details = new Rpt_Single_Window();
            ReportDataSource dataSource1 = new ReportDataSource("Exp_Sw_Prod", SW_Details.Get_Single_Window_details_PRODUCTION(ds.Tables[17]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public void SW_ITEM_CONTROL_DETAILS()
    {
        try
        {
            Rpt_Single_Window SW_Details = new Rpt_Single_Window();
            ReportDataSource dataSource1 = new ReportDataSource("Exp_Sw_Control", SW_Details.Get_Single_Window_details_CONTROL(ds.Tables[18]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }

    public void SW_ITEM_STATEMENT_DETAILS()
    {
        try
        {
            Session["Check_Stmt"] = Check_Stmt;
            Rpt_Single_Window SW_Details = new Rpt_Single_Window();
            ReportDataSource dataSource1 = new ReportDataSource("Exp_Sw_Stmt", SW_Details.Get_Single_Window_details_STATEMENT(ds.Tables[19]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public void SW_ITEM_SUPPORTING_DETAILS()
    {
        try
        {
            Rpt_Single_Window SW_Details = new Rpt_Single_Window();


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


            ReportDataSource dataSource1 = new ReportDataSource("Exp_Sw_Sup_Doc", SW_Details.Get_Single_Window_details_SUP_DOC(ds.Tables[20]));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public void Cess_Details()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("EXPORT_CESS_DETAILS", Rpt_Cess_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

       

    }

    public void Quota_Details()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("Export_Quota_Details", Rpt_Quota_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }

    public void Duty_Details()
    {
        try
        {
            ReportDataSource dataSource = new ReportDataSource("Export_Duty_Details", Rpt_Duty_Details_list);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

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
                ReportViewer1.LocalReport.DataSources.Clear();
                Response.Redirect("../Report/Export_ReportViewer.aspx?jobno=" + ddlJob_No.SelectedValue.ToString() + "&Annexure_Mode=" + Annexure_Mode + "&STR_Code=" + STR_Code + "&jobnops= " + ddlJob_No.SelectedItem.Text + "");
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
            chklist.JOBNo = ddlJob_No.SelectedValue.ToString();
            chklist.Ename = "select_jobno_CheckList";

            chklist.Workingperiod = SELECT_BRANCH;
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Rpt_General_Details Export_General = new Rpt_General_Details();
                Export_General.Retrieve_GetGeneral(ddlJob_No.SelectedValue.ToString());
                Annexure_Mode = Convert.ToString(Export_General.is_Annexure_Mode);
                STR_Code = Convert.ToString(Export_General.is_STR_Code);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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

            if (COMPANY_ID == "880")
            {
                Response.AddHeader("content-disposition", "attachment;filename=EXPChecklist_" + ViewState["EXPORTER_NAME"].ToString() + "_" + ViewState["INVOICE_NO"].ToString() + "_" + ddlJob_No.SelectedItem.Text + ".pdf");
            }

            else if (COMPANY_ID == "480") // Added by shanthini on 04-06-2026
            {
                string firstInvNo = ViewState["FIRST_INVOICE_NO"].ToString();
                string cleanInvNo = Regex.Replace(firstInvNo, @"[^a-zA-Z0-9]", "");
                Response.AddHeader("content-disposition", "attachment;filename=EXPChecklist_" + ddlJob_No.SelectedItem.Text + "_" + cleanInvNo + ".pdf");
            }

            else
            {
                Response.AddHeader("content-disposition", "attachment;filename=EXPChecklist" + ddlJob_No.SelectedItem.Text + ".pdf");
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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
            //DataTable dt_update = new DataTable();
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
}                                                                                           