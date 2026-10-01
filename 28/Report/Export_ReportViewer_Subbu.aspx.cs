using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;

using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
using System.Web.UI.WebControls.WebParts;
//using ReportViewerLib;
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
    AppSession aps = new AppSession();
    public int Is_STR = 0, IS_ANNEXURE_MODE = 0;
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

    private string _Working_Period;

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
    public int is_Annexure_Mode = 0, is_STR_Code = 0;

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
    private double _INDIVIDUAL_INVOICE_VALUE = 0;

    private string _ITEM_SCHEME_DESC;
    private double _FOB_VALUE1;
    private double _FOB_VALUE;
    private double _TOTAL_PMVVALUE, _TOTAL_ITEM_PMVVALUE, _INVOICE_VALUE_FC;


    private string _STR_RATE;
    private double _STR_AMOUNT;

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
    private string _WHEATHER_UNIT_PRICE;
    private double _TOTAL_STR_AMOUNT = 0, DISCOUNT_RATE_AMOUNT = 0, OTHER_DETDUCTION_RATE_AMOUNT = 0;
    #endregion

    #region Drawback Private_Attributes

    private string _DRAWBACK_ID;
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

    private double _DBK_VALUE;

    #endregion

    #region Drawback Public Attributes

    public string DRAWBACK_ID { get { return _DRAWBACK_ID; } set { _DRAWBACK_ID = value; } }
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

    public double DBK_VALUE { get { return _DBK_VALUE; } set { _DBK_VALUE = value; } }

    public double cal1, cal2, DBK_FOB;

    #endregion

    #region Public_Attributes
    public double TOTAL_STR_AMOUNT { get { return _TOTAL_STR_AMOUNT; } set { _TOTAL_STR_AMOUNT = value; } }
    public double INVOICE_VALUE_FC { get { return _INVOICE_VALUE_FC; } set { _INVOICE_VALUE_FC = value; } }

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
    //public string FOB_VALUE { get { return _FOB_VALUE; } set { _FOB_VALUE = value; } }
    public double TOTAL_PMVVALUE { get { return _TOTAL_PMVVALUE; } set { _TOTAL_PMVVALUE = value; } }
    public double TOTAL_ITEM_PMVVALUE { get { return _TOTAL_ITEM_PMVVALUE; } set { _TOTAL_ITEM_PMVVALUE = value; } }
    // public double FOB_VALUE;

    public string STR_RATE { get { return _STR_RATE; } set { _STR_RATE = value; } }
    //public double STR_AMOUNT { get { return _STR_AMOUNT; } set { _STR_AMOUNT = value; } }
    public string STR_AMOUNT { get { return _STR_AMOUNT1; } set { _STR_AMOUNT1 = value; } }
    //------------ITEM FOB CALCULATION ATTRIBUTES-------------------------------//
    public double TOTAL_INVOICE_VALUE = 0;
    public double TOTAL_ITEM_INVOICE_VALUE = 0, TOTAL_ITEM_INV_VALUE = 0;
    public double INDIVIDUAL_ITEM_INVOICE_VALUE = 0;
    public double INDIVIDUAL_INVOICE_VALUE { get { return _INDIVIDUAL_INVOICE_VALUE; } set { _INDIVIDUAL_INVOICE_VALUE = value; } }
    public double INDIVIDUAL_COMMISSION_AMOUNT = 0;
    public double INDIVIDUAL_INSURANCE_AMOUNT = 0;
    public double INDIVIDUAL_OTHER_DISCOUNT_AMOUNT = 0;
    public double INDIVIDUAL_FREIGHT_AMOUNT = 0;
    public double INDIVIDUAL_PACKING_CHARGE_AMOUNT = 0;
    public double INDIVIDUAL_FOB_DISCOUNT_AMOUNT = 0;
    public double INDIVIDUAL_FOB_VALUE = 0;
    public double TOTAL_FOB_AMOUNT = 0, SUM_TOTAL_FOB_VALUE = 0, SUM_TOTAL_DBK_VALUE = 0, DRAWBACK_VAL = 0, TOTAL_DBK_VALUE = 0;
    public double SInv_Value = 0, SFIValue1 = 0, SFIValue = 0, Individual_Item_Value = 0, Total_Item_Value = 0, TOTAL_INV_VALUE = 0;
    public double TOTAL_FREIGHT_AMOUNT = 0, TOTAL_INSURANCE_AMOUNT = 0, TOTAL_PACKING_AMOUNT = 0;
    public double IND_INVOICE_VALUE = 0, IND_FREIGHT_AMOUNT = 0, IND_INSURANCE_AMOUNT = 0, IND_PACKING_AMOUNT = 0, IND_PMV_VALUE = 0, IND_TOTAL_PMV_VALUE = 0, IND_PER_QTY = 0;

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


    #endregion

    List<Report_Export_Export_ReportViewer> Rpt_General_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_Item_Details_new_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_Invoice_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_DrawBack_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_AR4_Details_list = new List<Report_Export_Export_ReportViewer>();
    List<Report_Export_Export_ReportViewer> Rpt_STR_Details_list = new List<Report_Export_Export_ReportViewer>();
    //public double text_Discount = 0, text_OTHER_DISCOUNT = 0, text_packing = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {

                }
                else
                {
                    ddlJobNo = Request.QueryString["jobno"].ToString();
                    currentuser = Session["currentuser"].ToString();
                    currentbranch = Session["currentbranch"].ToString();
                    currentcomp_name = Session["currentcomp_name"].ToString();
                    comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
                    Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
                    LoginDate = HttpContext.Current.Session["LoginDate"].ToString();

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
                    License_Details();
                    ThirdParty_Details();
                    Jobbing_Details();
                    STR_Details();
                    AR4_Details();
                    EOU_Details();


                   
                    ReportParameter param = new ReportParameter("Title", Session["currentcomp_name"].ToString());
                    ReportParameter param1 = new ReportParameter("SubTitle", "CHECK LIST - Shipping Bill");
                    //ReportParameter param2= new ReportParameter("CustomHouse", currentbranch + "," + CUSTOMS_HOUSE + "]");
                    ReportParameter param3 = new ReportParameter("PrintDate", dt.Today_Date());
                    ReportParameter param4 = new ReportParameter("TodayDate", dt.Today_Date());
                    ReportParameter param5 = new ReportParameter("Jobno", ddlJobNo);
                    ReportParameter param6 = new ReportParameter("CHA_NO", HttpContext.Current.Session["CHA_NO"].ToString());
                    ReportParameter param7 = new ReportParameter("CHA_NAME", HttpContext.Current.Session["CHA_NAME"].ToString());
                    ReportParameter[] p = { param, param1, param3, param4, param5, param6, param7 };
                    ReportViewer1.LocalReport.SetParameters(p);

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

    public void GetGeneral()
    {


        //Rpt_General_Details Rpt_Export_General = new Rpt_General_Details();
        GetGeneral1(ds, IS_ANNEXURE_MODE, Is_STR);
        ReportDataSource dataSource1 = new ReportDataSource("Export_General_DetailsNew", Rpt_General_list);
        Is_STR = is_STR_Code;
        // ReportDataSource dataSource1 = new ReportDataSource("DataSet1", Rpt_Export_General.GetGeneral(ddlJobNo));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);

    }
    public void GetGeneral1(DataSet ds, int Annexue_Mode, int IS_STR)
    {


        is_Annexure_Mode = Annexue_Mode;
        is_STR_Code = IS_STR;

        Auto_Search auto = new Auto_Search();

        //list.Clear();

        //int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        if (ds.Tables[0].Rows.Count > 0)
        {
            string custom = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
            string custom_name = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString();
            string custid = "", name = "", rows = string.Empty;
            if (custom != "" && custom_name == "")
            {
                custom_name = auto.Country_Master_FromClientSide_Calling(custid = custom, name = "CUSTOM_HOUSE_MASTER_CUSTOM_NAME", rows = "CUSTOMHOUSE_NAME");
            }
            TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
            if (is_Annexure_Mode == 1)
            {


                if (TRANSPORT_MODE == "Air")
                {
                    NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString();

                    LOOSE_PACKETS = string.Empty;
                    NO_CONTAINERS = string.Empty;
                    ANNEX_AIR_MAWB_NO = ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString();
                    ANNEX_AIR_HAWB_NO = ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString();

                    if (NATURE_OF_CARGO == "P")
                    {
                        NATURE_OF_CARGO = "P Packaged";
                    }
                }
                else if (TRANSPORT_MODE == "Sea")
                {
                    NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString();

                    LOOSE_PACKETS = ds.Tables[0].Rows[0]["LOOSE_PACKETS"].ToString();
                    NO_CONTAINERS = ds.Tables[0].Rows[0]["NO_CONTAINERS"].ToString();
                    ANNEX_AIR_MAWB_NO = string.Empty;
                    ANNEX_AIR_HAWB_NO = string.Empty;

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
                else if (TRANSPORT_MODE == "Sea")
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
            //Calculate Total FOB And DRAWBACK Value
            //Rpt_Item_Details ITEM = new Rpt_Item_Details();
            //ITEM.Get_FOB_DRAWBACK_VALUE_Details(ddlJobNo, ds.Tables[1], ds.Tables[2], ds.Tables[5]);
            //Rpt_Item_Details_new ITEM = new Rpt_Item_Details_new();
            //FOB_VALUE = Convert.ToString(ITEM.FOB_VALUE);
            //DRAWBACK_VALUE = Convert.ToString(ITEM.DBK_VALUE);
            Get_ITEM_Details(ddlJobNo, ds.Tables[1], ds.Tables[2], ds.Tables[5]);
            FOB_VALUE = Math.Round(SUM_TOTAL_FOB_VALUE, 2);
            DRAWBACK_VALUE = Convert.ToString(Math.Round(SUM_TOTAL_DBK_VALUE, 2));
            //Calculate Total FOB And DRAWBACK Value

            Rpt_General_list.Add(new Report_Export_Export_ReportViewer()
            {
                JOBNO = ddlJobNo,
                Today_dt = dt.Today_Date(),
                JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString(),

                TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString(),
                CUSTOMS_HOUSE = custom,
                SB_TYPE = ds.Tables[0].Rows[0]["SB_TYPE"].ToString(),
                EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString(),
                BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString(),
                IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString(),
                ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString(),
                ADDRESS3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString(),
                ADDRESS4 = ds.Tables[0].Rows[0]["ADDRESS4"].ToString(),
                ADDRESS5 = ds.Tables[0].Rows[0]["ADDRESS5"].ToString(),
                ADCODE = ds.Tables[0].Rows[0]["ADCODE"].ToString(),
                BANK_ACCOUNT = ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString(),
                DRAWBACK_ACCOUNT = ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString(),
                CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString(),
                CONSIGNEE_ADD1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString(),
                CONSIGNEE_ADD2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString(),
                CONSIGNEE_ADD3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString(),
                CONSIGNEE_ADD4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString(),
                CONSIGNEE_ADD5 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString(),
                COUNTRY_DISCHARGE = dt.Split("-",ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString()),
                PORT_DISCHARGE = dt.Split("-",ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString()),
                COUNTRY_FINAL_DEST = dt.Split("-",ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString()),
                PORT_FINAL_DEST = dt.Split("-",ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString()),
                STATE_OF_EXPORT = dt.Split("-",ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString()),
                NFEI = ds.Tables[0].Rows[0]["NFEI"].ToString(),
                NFEI_TYPE = ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString(),
                //RBI_WAIVER_NO = ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString(),

                RBI_WAIVER_NO = RBI_WAIVER_NO ,
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
                DRAWBACK_VALUE = DRAWBACK_VALUE


            });



        }
        //return list;
    }

    public void Get_ITEM_Details(string ddlJobNo, DataTable ds, DataTable ds2, DataTable dt)
    {



        Rpt_Item_Details_new_list.Clear();


        int b = 0, C = 0, i = 0;

        double salary = 0.0;
        double salary1 = 0.0;
        double TOTAL_ITEM = 0.0;
        string preINVOICE_SLNO = "0", curINVOICE_SLNO = "0";
        string count = Convert.ToString(ds.Rows.Count);
        TOTAL_STR_AMOUNT = 0;
        INDIVIDUAL_INVOICE_VALUE = 0;
        INVOICE_VALUE_FC = 0;
        
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

            COMMISSION_RATE = Return_Zero_Value1(ds.Rows[C]["COMMISSION_RATE"].ToString());

            COMMISSION_CHARGES = Return_Zero_Value1(ds.Rows[C]["COMMISSION_CHARGES"].ToString());
            FOB_RATE = Return_Zero_Value1(ds.Rows[C]["FOB_RATE"].ToString());
            FOB_CHARGES = Return_Zero_Value1(ds.Rows[C]["FOB_CHARGES"].ToString());
            //PACKMISC_RATE = Return_Zero_Value1(ds.Rows[C]["PACKMISC_RATE"].ToString());

            //PACKMISC_CHARGES = Return_Zero_Value1(ds.Rows[C]["PACKMISC_CHARGES"].ToString());

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
            //object sumObject;
            //sumObject = 
            //table.Compute("Sum(ITEM_AMOUNT)", "");
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            int sum = 0;
            while (dss.Tables[0].Rows.Count > sum)
            {
                TOTAL_ITEM_INVOICE_VALUE = TOTAL_ITEM_INVOICE_VALUE + Convert.ToDouble(ITEM_AMOUNT = dss.Tables[0].Rows[sum]["ITEM_AMOUNT"].ToString());
                sum++;
            }
            INDIVIDUAL_INVOICE_VALUE = 0;
            TOTAL_INV_VALUE = 0;
            Rpt_DrawBack_Details_list.Clear();
            Rpt_STR_Details_list.Clear();
            while (dss.Tables[0].Rows.Count > b)
            {
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
                ITEM_SLNO = dss.Tables[0].Rows[b]["ITEM_SLNO"].ToString();
                ITEM_DESCRIPTION = dss.Tables[0].Rows[b]["ITEM_DESCRIPTION"].ToString();
                RITCNO = dss.Tables[0].Rows[b]["RITCNO"].ToString();
                ITEM_QTY = dss.Tables[0].Rows[b]["ITEM_QTY"].ToString();
                ITEM_QTY_CODE = dss.Tables[0].Rows[b]["ITEM_QTY_CODE"].ToString();
                ITEM_UNIT_PRICE = dss.Tables[0].Rows[b]["ITEM_UNIT_PRICE"].ToString();
                ITEM_PER = dss.Tables[0].Rows[b]["ITEM_PER"].ToString();
                INDIVIDUAL_ITEM_INVOICE_VALUE = Convert.ToDouble(ITEM_AMOUNT = dss.Tables[0].Rows[b]["ITEM_AMOUNT"].ToString());
                ITEM_PMVVALUE = dss.Tables[0].Rows[b]["ITEM_PMVVALUE"].ToString();

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

                ITEM_IECCODE = dss.Tables[0].Rows[b]["ITEM_IECCODE"].ToString();
                BR_SLNO = dss.Tables[0].Rows[b]["BR_SLNO"].ToString();


                ADDRESS1 = dss.Tables[0].Rows[b]["ADDRESS1"].ToString();
                ADDRESS2 = dss.Tables[0].Rows[b]["ADDRESS2"].ToString();
                ADDRESS3 = dss.Tables[0].Rows[b]["ADDRESS3"].ToString();
                ADDRESS4 = dss.Tables[0].Rows[b]["ADDRESS4"].ToString();
                ADDRESS5 = dss.Tables[0].Rows[b]["ADDRESS5"].ToString();
                ITEM_STR_CODE = dss.Tables[0].Rows[b]["ITEM_STR_CODE"].ToString();
                REWARD_POINTS = dss.Tables[0].Rows[b]["REWARD_POINTS"].ToString();

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

                TOTAL_ITEM_PMVVALUE = Math.Round(Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(EXCHANGE_RATE),2);
                IND_INVOICE_VALUE = Math.Round(Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(EXCHANGE_RATE),2);
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
                    IND_PMV_VALUE = ((Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(EXCHANGE_RATE)) - (IND_FREIGHT_AMOUNT / Convert.ToDouble(ITEM_QTY)) - (IND_INSURANCE_AMOUNT / Convert.ToDouble(ITEM_QTY))) * 1.1 + IND_PACKING_AMOUNT;
                }
               
                ITEM_PMVVALUE = Convert.ToString(Math.Round(IND_PMV_VALUE, 1).ToString("0.00"));
                IND_TOTAL_PMV_VALUE = IND_PMV_VALUE * Convert.ToDouble(ITEM_QTY);
                string a = Convert.ToString(Math.Round(IND_TOTAL_PMV_VALUE, 1).ToString("0.00"));

                TOTAL_PMVVALUE = Convert.ToDouble(a);
                //TOTAL_PMVVALUE = Math.Round(IND_TOTAL_PMV_VALUE, 2);
                //---------------------------------------PMV VALUE ITEM CALCULATION--------------------------------------//

                //if (ITEM_PMVVALUE != "")
                //{
                //    //ITEM_PMVVALUE = Convert.ToString(Convert.ToDouble(ITEM_PMVVALUE)/10);
                //    TOTAL_PMVVALUE = Convert.ToDouble(ITEM_PMVVALUE) * Convert.ToDouble(ITEM_QTY); //* Convert.ToDouble(EXCHANGE_RATE));
                //}
                //else
                ////if (ITEM_PMVVALUE == "")
                //{
                //    TOTAL_PMVVALUE = 0.00;
                //}

                // --------------------------------------- ITEM CALCULATION---------------------------------------------------------------


                //if (TERMS == "FOB")
                //{
                //    FOB_VALUE = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) * Convert.ToDouble(EXCHANGE_RATE));
                //}
                //else if (TERMS == "CIF")
                //{
                //    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(FREIGHT_CHARGES) + Convert.ToDouble(INSURANCE_CHARGES)));
                //    FOB_VALUE = FOB * Convert.ToDouble(EXCHANGE_RATE);
                //}
                //else if (TERMS == "CF")
                //{
                //    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(FREIGHT_CHARGES)));
                //    FOB_VALUE = FOB * Convert.ToDouble(EXCHANGE_RATE);
                //}
                //else if (TERMS == "CI")
                //{
                //    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(INSURANCE_CHARGES)));
                //    FOB_VALUE = FOB * Convert.ToDouble(EXCHANGE_RATE);
                //}
                string fob = Convert.ToString(Math.Round(Get_Total_FOB_Value(INSURANCE_CHARGES, FREIGHT_CHARGES), 1).ToString("0.00"));
                FOB_VALUE = Convert.ToDouble(fob);
                //FOB_VALUE = Math.Round(Get_Total_FOB_Value(INSURANCE_CHARGES, FREIGHT_CHARGES), 2);
                // --------------------------------------- STR CALCULATION---------------------------------------------------------------
                if (Is_STR == 2)
                {

                    if (ITEM_STR_CODE != "")
                    {
                        adminmaster adm = new adminmaster();
                        adm.STR_ID = "0";
                        adm.STR_SRNO = ITEM_STR_CODE;

                        adm.Ename = "select_value";

                        adm.startRowIndex = "0";
                        adm.maximumRows = "0";

                        DataSet ds1 = new DataSet();
                        ds1 = adm.RetrieveAll_STR_master();

                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            STR_RATE = ds1.Tables[0].Rows[0]["STR_RATE"].ToString();

                        }

                        STR_AMOUNT = Convert.ToString(Convert.ToDouble(STR_RATE) * Convert.ToDouble(FOB_VALUE));

                        //-----------------------------STR LIST ------------------------------//

                        Rpt_STR_Details_list.Add(new Report_Export_Export_ReportViewer()
                        {

                            INVOICE_SLNO = INVOICE_SLNO,
                            INVOICE_NO = INVOICE_NO,
                            ITEM_SLNO = ITEM_SLNO,

                            ITEM_STR_CODE = ITEM_STR_CODE,


                            STR_RATE = STR_RATE,
                            STR_AMOUNT = STR_AMOUNT,
                            TOTAL_STR_AMOUNT =Math.Round(TOTAL_STR_AMOUNT+Convert.ToDouble(STR_AMOUNT),2)


                        });
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
                        TOTAL_STR_AMOUNT = 0.00



                    });
                }
                //-----------------------------STR LIST ------------------------------//
                DataView view1 = dt.DefaultView;
                view1.RowFilter = "ITEM_SLNO = " + ITEM_SLNO;
                DataTable table1 = view1.ToTable();
                //DataSet dss1 = new DataSet();
                //dss1.Tables.Add(table1);
                //while (dss.Tables[0].Rows.Count > b)
                //{

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
                    DRAWBACK_ID = dt.Rows[i]["DRAWBACK_ID"].ToString();
                    SCHEME_CODE = dt.Rows[i]["SCHEME_CODE"].ToString();
                    DRAWBACK_DESC = dt.Rows[i]["DRAWBACK_DESC"].ToString();

                    if (DRAWBACK_SLNO != "")
                    {
                        adminmaster adm = new adminmaster();
                        adm.Edrawback_id = "0";
                        adm.Edrawback_slno = DRAWBACK_SLNO;
                        adm.Edrawback_description = string.Empty;
                        adm.Ename = "select_checklist";

                        DataSet ds1 = new DataSet();
                        ds1 = adm.Checklist_Drawback_master();

                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            DRAWBACK_CUSTOMS = ds1.Tables[0].Rows[0]["DRAWBACK_CUSTOMS"].ToString();
                            DRAWBACK_EXCISE = ds1.Tables[0].Rows[0]["DRAWBACK_EXCISE"].ToString();


                        }



                        // --------------------------------------- DRAWBACK CALCULATION---------------------------------------------------------------


                        cal1 = Convert.ToDouble(FOB_VALUE) * Convert.ToDouble(DRAWBACK_RATE) / 100;

                        if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
                        {
                            cal2 = Convert.ToDouble(DRAWBACK_QTY) * Convert.ToDouble(DRAWBACK_CAPS);
                        }

                        if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
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
                            DRAWBACK_VAL = cal1;
                        }

                        //FOB_VALUE = FOB_VALUE + FOB_VAL;
                        //DBK_VALUE = DBK_VALUE + DRAWBACK_VAL;
                        string DBK = Convert.ToString(Math.Round(DRAWBACK_VAL, 1).ToString("0.00"));
                        DBK_VALUE = Convert.ToDouble(DBK);
                       // DBK_VALUE = Math.Round(DRAWBACK_VAL, 2);
                    }
                    else
                    {
                        DRAWBACK_CUSTOMS = string.Empty;
                        DRAWBACK_EXCISE = string.Empty;
                        //FOB_VALUE = FOB_VALUE + FOB_VAL;
                        //DBK_VALUE = DBK_VALUE + DRAWBACK_VAL;
                        string DBK = Convert.ToString(Math.Round(DRAWBACK_VAL, 1).ToString("0.00"));
                        DBK_VALUE = Convert.ToDouble(DBK);
                        // DBK_VALUE = Math.Round(DRAWBACK_VAL, 2);
                    }
                    string TOTAL_DBK = Convert.ToString(Math.Round(TOTAL_DBK_VALUE + DBK_VALUE, 1).ToString("0.00"));
                    TOTAL_DBK_VALUE = Convert.ToDouble(TOTAL_DBK);

                   
                    
                    //-----------------------------DRAWBACK LIST ------------------------------//
                    Rpt_DrawBack_Details_list.Add(new Report_Export_Export_ReportViewer()
                    {
                        INVOICE_SLNO = INVOICE_SLNO,
                        INVOICE_NO = INVOICE_NO,
                        ITEM_SLNO = ITEM_SLNO,
                        DRAWBACK_ID = DRAWBACK_ID,
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
                        DBK_VALUE = DBK_VALUE
                    });
                    //-----------------------------DRAWBACK LIST ------------------------------//
                   
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

                        DRAWBACK_ID = DRAWBACK_ID,
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

                        NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS


                    });

                    //i++;
                }
                else
                {
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

                        DRAWBACK_ID = DRAWBACK_ID,
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

                        NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS


                    });
                }


                b++;

            }
            
            Get_Invoice_Details(ds.Rows[C], count, Convert.ToString(TOTAL_INV_VALUE));
            SUM_TOTAL_DBK_VALUE = SUM_TOTAL_DBK_VALUE + TOTAL_DBK_VALUE;
            C++;

        }

        //return list1;
    }
    public void Get_Invoice_Details(DataRow row, string count, string INDIVIDUAL_INV_VALUE)
    {
        
        INVOICE_CURRENCY = row["INVOICE_CURRENCY"].ToString();
        COMMISSION_RATE = Return_Zero_Value1(row["COMMISSION_RATE"].ToString());

        COMMISSION_CHARGES = Return_Zero_Value1(row["COMMISSION_CHARGES"].ToString());

        FOB_RATE = Return_Zero_Value1(row["FOB_RATE"].ToString());

        //FOB_CHARGES = Return_Zero_Value1(row["FOB_CHARGES"].ToString());
        FOB_CHARGES = Return_Zero_Value1(Convert.ToString(DISCOUNT_RATE_AMOUNT));

        PACKMISC_RATE = Return_Zero_Value1(row["PACKMISC_RATE"].ToString());

        PACKMISC_CHARGES = Return_Zero_Value1(row["PACKMISC_CHARGES"].ToString());

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
        Rpt_Invoice_Details_list.Add(new Report_Export_Export_ReportViewer()
        {
            //INDIVIDUAL_INVOICE_VALUE = Convert.ToDouble(INDIVIDUAL_INV_VALUE),
            INDIVIDUAL_INVOICE_VALUE = Convert.ToDouble(INVOICE_VALUE_FC) * Convert.ToDouble(EXCHANGE_RATE),
            INVOICE_VALUE_FC=INVOICE_VALUE_FC,
            DBK_VALUE = DBK_VALUE,

            No_Of_Invoices = Convert.ToString(count),

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
            COMMISSION_CURRENCY = INVOICE_CURRENCY,

            FOB_RATE = FOB_RATE,
            FOB_CHARGES = FOB_CHARGES,

            FOB_CURRENCY = INVOICE_CURRENCY,

            PACKMISC_RATE = PACKMISC_RATE,

            PACKMISC_CHARGES = PACKMISC_CHARGES,
            PACKMISC_CURRENCY = INVOICE_CURRENCY,
            OTHER_DEDUCTION_RATE = OTHER_DEDUCTION_RATE,
            OTHER_DEDUCTION_CHARGES = OTHER_DEDUCTION_CHARGES,
            OTHER_DEDUCTION_CURRENCY = INVOICE_CURRENCY,

            FREIGHT_RATE = FREIGHT_RATE,
            FREIGHT_CHARGES = FREIGHT_CHARGES,
            FREIGHT_CURRENCY = FREIGHT_CURRENCY,



            INSURANCE_RATE = INSURANCE_RATE,

            INSURANCE_CHARGES = INSURANCE_CHARGES,
            INSURANCE_CURRENCY = INSURANCE_CURRENCY,
            WHEATHER_UNIT_PRICE = row["WHEATHER_UNIT_PRICE"].ToString()
        });
        DISCOUNT_RATE_AMOUNT = 0;
        OTHER_DETDUCTION_RATE_AMOUNT = 0;
    }
    public double Get_Total_FOB_Value(string INSURANCE_CHARGES, string FREIGHT_CHARGES)
    {

        //-----COMMSSION AMOUNT CAL--------------//
        if (COMMISSION_RATE != "0" && COMMISSION_RATE != "0.00")
        {
            INDIVIDUAL_COMMISSION_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(COMMISSION_RATE)) / 100;

        }
        else if (COMMISSION_CHARGES != "0" && COMMISSION_CHARGES != "0.00")
        {
            INDIVIDUAL_COMMISSION_AMOUNT = Convert.ToDouble(COMMISSION_CHARGES) * Convert.ToDouble(EXCHANGE_RATE);//EXCHANGE_RATE - INVOICE EX_RATE

        }
        //-----COMMSSION AMOUNT CAL--------------//

        //-----INSURANCE AMOUNT CAL--------------//
        if (INSURANCE_RATE != "0" && INSURANCE_RATE != "0.00")
        {
            INDIVIDUAL_INSURANCE_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(INSURANCE_RATE)) / 100;

        }
        else if (INSURANCE_CHARGES != "0" && INSURANCE_CHARGES != "0.00")
        {
            INDIVIDUAL_INSURANCE_AMOUNT = Convert.ToDouble(INSURANCE_CHARGES) * Convert.ToDouble(INSURANCE_EXRATE);

        }
        //-----INSURANCE AMOUNT CAL--------------//
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
        if (FOB_RATE != "0" && FOB_RATE != "0.00")
        {
            
            INDIVIDUAL_FOB_DISCOUNT_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(FOB_RATE)) / 100;
            //INDIVIDUAL_FOB_DISCOUNT_AMOUNT = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
            //double INDIVIDUAL_FOB_DISCOUNT_AMOUNTNEW = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(FOB_RATE)) / 100;
            DISCOUNT_RATE_AMOUNT = DISCOUNT_RATE_AMOUNT + INDIVIDUAL_FOB_DISCOUNT_AMOUNT;
            
            //INDIVIDUAL_FOB_DISCOUNT_AMOUNT = DISCOUNT_RATE_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
           // DISCOUNT_RATE_AMOUNT = DISCOUNT_RATE_AMOUNT + Convert.ToDouble(FOB_RATE);
        }
        else if (FOB_CHARGES != "0" && FOB_CHARGES != "0.00")
        {
            INDIVIDUAL_FOB_DISCOUNT_AMOUNT = Convert.ToDouble(FOB_CHARGES) * Convert.ToDouble(EXCHANGE_RATE);//EXCHANGE_RATE - INVOICE EX_RATE
            DISCOUNT_RATE_AMOUNT = Convert.ToDouble(FOB_CHARGES);

        }
        //-----FOB DISCOUNT AMOUNT CAL--------------//

        //-----OTHER DISCOUNT AMOUNT CAL--------------//
        if (OTHER_DEDUCTION_RATE != "0" && OTHER_DEDUCTION_RATE != "0.00")
        {
            INDIVIDUAL_OTHER_DISCOUNT_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(OTHER_DEDUCTION_RATE)) / 100;
            OTHER_DETDUCTION_RATE_AMOUNT = OTHER_DETDUCTION_RATE_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT;


        }
        else if (OTHER_DEDUCTION_CHARGES != "0" && OTHER_DEDUCTION_CHARGES != "0.00")
        {
            INDIVIDUAL_OTHER_DISCOUNT_AMOUNT = Convert.ToDouble(OTHER_DEDUCTION_CHARGES) * Convert.ToDouble(EXCHANGE_RATE);//EXCHANGE_RATE - INVOICE EX_RATE
            OTHER_DETDUCTION_RATE_AMOUNT = Convert.ToDouble(OTHER_DEDUCTION_CHARGES);

        }
        //-----OTHER DISCOUNT AMOUNT CAL--------------//

        //-----PACKING AMOUNT CAL--------------//
        if (PACKMISC_RATE != "0" && PACKMISC_RATE != "0.00")
        {
            INDIVIDUAL_PACKING_CHARGE_AMOUNT = (INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(PACKMISC_RATE)) / 100;

        }
        else if (PACKMISC_CHARGES != "0" && PACKMISC_CHARGES != "0.00")
        {
            INDIVIDUAL_PACKING_CHARGE_AMOUNT = Convert.ToDouble(PACKMISC_CHARGES) * Convert.ToDouble(EXCHANGE_RATE);//EXCHANGE_RATE - INVOICE EX_RATE

        }
        //-----PACKING AMOUNT CAL--------------//

        Individual_Item_Value = INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
        Total_Item_Value = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
        if (TERMS == "FOB")
        {
            double text_packing = INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value;
            double text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
            double text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
            INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value;
           
            INDIVIDUAL_FOB_VALUE = INDIVIDUAL_ITEM_INVOICE_VALUE + text_packing - (text_Discount + text_OTHER_DISCOUNT);
           
            //INDIVIDUAL_FOB_VALUE = INDIVIDUAL_ITEM_INVOICE_VALUE + INDIVIDUAL_PACKING_CHARGE_AMOUNT - (INDIVIDUAL_FOB_DISCOUNT_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT);
           
            INDIVIDUAL_FOB_VALUE = INDIVIDUAL_FOB_VALUE * Convert.ToDouble(EXCHANGE_RATE);
        }
        else if (TERMS == "CIF")
        {
            double text_Discount = 0, text_OTHER_DISCOUNT = 0, text_packing=0;
            INDIVIDUAL_FREIGHT_AMOUNT = INDIVIDUAL_FREIGHT_AMOUNT * Individual_Item_Value / Total_Item_Value;
            INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Individual_Item_Value / Total_Item_Value;
            if (FOB_CHARGES != "0" && FOB_CHARGES != "0.00")
            {
                text_Discount = (INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            if (OTHER_DEDUCTION_CHARGES != "0" && OTHER_DEDUCTION_CHARGES != "0.00")
            {
                text_OTHER_DISCOUNT = (INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            if (PACKMISC_CHARGES != "0" && PACKMISC_CHARGES != "0.00")
            {
                text_packing = (INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            if (FOB_RATE != "0" && FOB_RATE != "0.00")
            {
                text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
            }
            if (OTHER_DEDUCTION_RATE != "0" && OTHER_DEDUCTION_RATE != "0.00")
            {
                text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
            }
           
            //double text_packing = (INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value)*Convert.ToDouble(EXCHANGE_RATE);
             //text_Discount = (INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value) * Convert.ToDouble(EXCHANGE_RATE);
            // text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
            //double text_OTHER_DISCOUNT = (INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value) * Convert.ToDouble(EXCHANGE_RATE);
            //INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
            SFIValue1 = INDIVIDUAL_FREIGHT_AMOUNT + INDIVIDUAL_INSURANCE_AMOUNT;
            INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
            //SFIValue = Individual_Item_Value + INDIVIDUAL_PACKING_CHARGE_AMOUNT - (INDIVIDUAL_FOB_DISCOUNT_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT);
            SFIValue = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT);
            INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value;
            if (WHEATHER_UNIT_PRICE == "B")
            {
                INDIVIDUAL_FOB_VALUE = SFIValue - SFIValue1;
                INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value;
            }
            else if (WHEATHER_UNIT_PRICE == "N")
            {
                INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT); 
                INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value + SFIValue1;
            }

           

        }
        else if (TERMS == "CF")
        {

            double text_Discount = 0, text_OTHER_DISCOUNT = 0, text_packing = 0;

            INDIVIDUAL_FREIGHT_AMOUNT = INDIVIDUAL_FREIGHT_AMOUNT * Individual_Item_Value / Total_Item_Value;
            if (FOB_CHARGES != "0" && FOB_CHARGES != "0.00")
            {
                text_Discount = (INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            if (OTHER_DEDUCTION_CHARGES != "0" && OTHER_DEDUCTION_CHARGES != "0.00")
            {
                text_OTHER_DISCOUNT = (INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            if (PACKMISC_CHARGES != "0" && PACKMISC_CHARGES != "0.00")
            {
                text_packing = (INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            if (FOB_RATE != "0" && FOB_RATE != "0.00")
            {
                text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
            }
            if (OTHER_DEDUCTION_RATE != "0" && OTHER_DEDUCTION_RATE != "0.00")
            {
                text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
            }
            //INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
            SFIValue1 = INDIVIDUAL_FREIGHT_AMOUNT;
            INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
            //double text_packing = INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value;
            //double text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
           // double text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
            SFIValue = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT);
            //SFIValue = Individual_Item_Value + INDIVIDUAL_PACKING_CHARGE_AMOUNT - (INDIVIDUAL_FOB_DISCOUNT_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT);
            INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value;
            if (WHEATHER_UNIT_PRICE == "F")
            {
                INDIVIDUAL_FOB_VALUE = SFIValue - SFIValue1;
                INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value;
            }
            else if (WHEATHER_UNIT_PRICE == "N")
            {
                INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT);
                INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value + SFIValue1;
            }

            
           // TOTAL_ITEM_INVOICE_VALUE
            //double Individual_Item_Value = INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
            //double Total_Item_Value = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
            //INDIVIDUAL_FREIGHT_AMOUNT = INDIVIDUAL_FREIGHT_AMOUNT * (Individual_Item_Value) / Total_Item_Value;
            //INDIVIDUAL_FOB_VALUE = INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);


        }
        else if (TERMS == "CI")
        {


            double text_Discount = 0, text_OTHER_DISCOUNT = 0, text_packing = 0;

            INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * Individual_Item_Value / Total_Item_Value;
            if (FOB_CHARGES != "0" && FOB_CHARGES != "0.00")
            {
                text_Discount = (INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            if (OTHER_DEDUCTION_CHARGES != "0" && OTHER_DEDUCTION_CHARGES != "0.00")
            {
                text_OTHER_DISCOUNT = (INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            if (PACKMISC_CHARGES != "0" && PACKMISC_CHARGES != "0.00")
            {
                text_packing = (INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value);
            }
            if (FOB_RATE != "0" && FOB_RATE != "0.00")
            {
                text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
            }
            if (OTHER_DEDUCTION_RATE != "0" && OTHER_DEDUCTION_RATE != "0.00")
            {
                text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Convert.ToDouble(EXCHANGE_RATE);
            }
            //INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
            SFIValue1 = INDIVIDUAL_INSURANCE_AMOUNT;
            INDIVIDUAL_FOB_VALUE = Individual_Item_Value;
            //double text_packing = INDIVIDUAL_PACKING_CHARGE_AMOUNT * Individual_Item_Value / Total_Item_Value;
            //double text_Discount = INDIVIDUAL_FOB_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
            //double text_OTHER_DISCOUNT = INDIVIDUAL_OTHER_DISCOUNT_AMOUNT * Individual_Item_Value / Total_Item_Value;
            SFIValue = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT);
            //SFIValue = Individual_Item_Value + INDIVIDUAL_PACKING_CHARGE_AMOUNT - (INDIVIDUAL_FOB_DISCOUNT_AMOUNT + INDIVIDUAL_OTHER_DISCOUNT_AMOUNT);
            INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value;
            if (WHEATHER_UNIT_PRICE == "I")
            {
                INDIVIDUAL_FOB_VALUE = SFIValue - SFIValue1;
                INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value;
            }
            else if (WHEATHER_UNIT_PRICE == "N")
            {
                INDIVIDUAL_FOB_VALUE = Individual_Item_Value + text_packing - (text_Discount + text_OTHER_DISCOUNT);
                INDIVIDUAL_INVOICE_VALUE = Individual_Item_Value + SFIValue1;
            }
            //double Individual_Item_Value = INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
            //double Total_Item_Value = TOTAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);
            //INDIVIDUAL_INSURANCE_AMOUNT = INDIVIDUAL_INSURANCE_AMOUNT * (Individual_Item_Value) / Total_Item_Value;
            //INDIVIDUAL_FOB_VALUE = INDIVIDUAL_ITEM_INVOICE_VALUE * Convert.ToDouble(EXCHANGE_RATE);


        }
        
        //------------------------PENDING WHETHER THE UNITPRICE INCLUDE----------------------------//

        //------------------------PENDING WHETHER THE UNITPRICE INCLUDE----------------------------//
        //INDIVIDUAL_INVOICE_VALUE = INDIVIDUAL_INVOICE_VALUE;


          TOTAL_INV_VALUE = TOTAL_INV_VALUE + INDIVIDUAL_INVOICE_VALUE;
          FOB_CHARGES = Convert.ToString(DISCOUNT_RATE_AMOUNT);
          INVOICE_VALUE_FC = (Convert.ToDouble(TOTAL_INV_VALUE) / Convert.ToDouble(EXCHANGE_RATE) - Convert.ToDouble(DISCOUNT_RATE_AMOUNT)) + Convert.ToDouble(PACKMISC_CHARGES) - Convert.ToDouble(OTHER_DETDUCTION_RATE_AMOUNT);
          //INVOICE_VALUE_FC = INVOICE_VALUE_FC + Convert.ToDouble(OTHER_DEDUCTION_CHARGES);
        //TOTAL_INV_VALUE = INVOICE_VALUE_FC;
        TOTAL_FOB_AMOUNT = TOTAL_FOB_AMOUNT + INDIVIDUAL_FOB_VALUE;
        SUM_TOTAL_FOB_VALUE = SUM_TOTAL_FOB_VALUE + TOTAL_FOB_AMOUNT;
        return TOTAL_FOB_AMOUNT;
    }

    public void Get_InvoiceValue_FC()
    {

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
        if (val == "" || val=="0")
        {
            val = "0.00";
        }
        return val;
    }
    public void Invoice_Details()
    {
        //Rpt_Invoice_Details INV = new Rpt_Invoice_Details();
        //INVOICE_DETAILS INV = new INVOICE_DETAILS();

        //ReportDataSource dataSource = new ReportDataSource("Export_Invoice_Details", INV.Get_Invoice_Details(ddlJobNo, ds.Tables[1]));

        ReportDataSource dataSource = new ReportDataSource("Export_Invoice_Details", Rpt_Invoice_Details_list);
        ReportViewer1.LocalReport.DataSources.Add(dataSource);

    }

    public void Item_Details()
    {

        ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);

    }

    protected void ReportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        //Rpt_Item_Details ITEM = new Rpt_Item_Details();
        //Rpt_Item_Details_new ITEM = new Rpt_Item_Details_new();
        //ReportDataSource dataSource = new ReportDataSource("Item_Details", ITEM.Get_ITEM_Details(ddlJobNo, ds.Tables[1], ds.Tables[2],ds.Tables[5]));

        ReportDataSource dataSource = new ReportDataSource("Item_Details", Rpt_Item_Details_new_list);

        e.DataSources.Add(dataSource);
    }

    public void Drawback_Details()
    {
        //Rpt_Item_Details ITEM = new Rpt_Item_Details();
        //INVOICE_DETAILS INV = new INVOICE_DETAILS();
        //ReportDataSource dataSource = new ReportDataSource("Export_Drawback_Details", (DataSet)Session["DRAWBACK"]);
        //ReportDataSource dataSource = new ReportDataSource("Item_Details", ITEM.Get_ITEM_Details(ddlJobNo, ds.Tables[1], ds.Tables[2], ds.Tables[5]));
        ReportDataSource dataSource = new ReportDataSource("Item_Details", Rpt_DrawBack_Details_list);

        ReportViewer1.LocalReport.DataSources.Add(dataSource);

    }

    //public void Drawback_Details()
    //{
    //    Rpt_Drawback_Details Draw = new Rpt_Drawback_Details();
    //    //INVOICE_DETAILS INV = new INVOICE_DETAILS();
    //    ReportDataSource dataSource = new ReportDataSource("Drawback_Details", Draw.Get_DRAWBACK_DETAILS(ds.Tables[4],ds.Tables[2]));
    //    ReportViewer1.LocalReport.DataSources.Add(dataSource);

    //}

    public void License_Details()
    {
        Rpt_License_Details License = new Rpt_License_Details();
        //INVOICE_DETAILS INV = new INVOICE_DETAILS();
        ReportDataSource dataSource = new ReportDataSource("Export_License_Details", License.Get_LICENSE_DETAILS(ds.Tables[3], ds.Tables[4]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource);

    }

    public void ThirdParty_Details()
    {
        Rpt_ThirdParty_Details Third = new Rpt_ThirdParty_Details();
        //INVOICE_DETAILS INV = new INVOICE_DETAILS();
        ReportDataSource dataSource = new ReportDataSource("Export_ThirdParty_Details", Third.Get_ThirdParty_Details(ds.Tables[2]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource);

    }

    public void Jobbing_Details()
    {
        Rpt_Jobbing_Details Job = new Rpt_Jobbing_Details();
        //INVOICE_DETAILS INV = new INVOICE_DETAILS();
        ReportDataSource dataSource = new ReportDataSource("Export_Jobbing_Details", Job.Get_JOBBING_DETAILS(ds.Tables[6]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource);

    }

    public void STR_Details()
    {
       
        //Rpt_Item_Details ITEM = new Rpt_Item_Details();

        //ReportDataSource dataSource1 = new ReportDataSource("Export_STR_Details", ITEM.Get_STR_Details(ddlJobNo, ds.Tables[1], ds.Tables[2], ds.Tables[5], Is_STR));
         ReportDataSource dataSource1 = new ReportDataSource("Export_STR_Details", Rpt_STR_Details_list);

        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        //Rpt_STR_Details STR = new Rpt_STR_Details();
        //INVOICE_DETAILS INV = new INVOICE_DETAILS();
        //ReportDataSource dataSource = new ReportDataSource("Export_Drawback_Details", (DataSet)Session["DRAWBACK"]);
        // ReportDataSource dataSource = new ReportDataSource("Export_STR_Details", STR.Get_ThirdParty_Details(ds.Tables[2]));

        //ReportViewer1.LocalReport.DataSources.Add(dataSource);

    }
    public void AR4_Details()
    {

        ReportDataSource dataSource1 = new ReportDataSource("EXPORT_AR4_DETAILS", Rpt_AR4_Details_list);

        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }
    public void EOU_Details()
    {
        Rpt_Annexure_C1_Details Annex = new Rpt_Annexure_C1_Details();
        ReportDataSource dataSource1 = new ReportDataSource("EXPORT_ANNEX_C1_DETAILS", Annex.Get_Export_Annexure_c1_Details(ds.Tables[7]));

        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }
}