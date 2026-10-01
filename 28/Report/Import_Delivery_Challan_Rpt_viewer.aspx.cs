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

public partial class Report_delivery_Challan : System.Web.UI.Page
{


    #region Private_Attributes
    private string _BE_NO;
    private string _JOB_NO;
    private string _Today_dt;
    //private string _IGM_TRANSPORTMODE;
    //General Details
    private string _Importer_Name;

    private string _TRANSPORT_MODE;

    private string _CUSTOMS_HOUSE;

    private string _SECTION46;
    private string _FIRSTCHECK;
    private string _GREEN_CHANNEL;
    private string _KACHHA_BE;
    private string _SECTION48;
    private string _HIGH_SEA_SALE_NAME;
    private string _HIGH_SEA_IEC;
    private string _HIGH_SEA_BRANCH_SL_NO;
    private string _HSS_ADD1;
    private string _HSS_ADD2;
    private string _HSS_ADD3;
    private string _HSS_ADD4;
    private string _HSS_ADD5;
    private string _SUPPLIER_COUNTRY_NAME;
    private string _SUPPLIER_COUNTRY_PINCODE;
    private string _SVB_ASSESABLE_STATUS;
    private string _SVB_DUTY_STATUS;
    //IGM


    // Invoice Details
    //private string _INVOICE_SLNO;
    private string _INVOICE_NO;


    //ITEM DETAILS
    //private string _ITEM_SLNO;

    //private string _SCHEME_CODE;

    #endregion
    #region Public_Attributes

    //public string SCHEME_NOTN_ = "";
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string JOB_NO { get { return _BE_NO; } set { _JOB_NO = value; } }
    public string Today_dt { get { return _BE_NO; } set { _Today_dt = value; } }
    public string Importer_Name { get { return _Importer_Name; } set { _Importer_Name = value; } }
    //public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }

    //General Details

    public string SECTION46 { get { return _SECTION46; } set { _SECTION46 = value; } }
    public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }
    public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
    public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
    public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }

    //public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }

    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }



    #endregion
    //---------------------ITEM ATTRIBUTES-----------------//
    #region ITEM ATTRIBUTES
    #region Private_Attributes
    private string _INVOICE_SLNO;
    private string _INVOICE_DATE;
    private string _SUPPLIER_NAME;
    private string _SUPPLIER_ADDRESS;
    private string _SUPPLIER_ADDRESS1;
    private string _SUPPLIER_ADDRESS2;
    private string _SVB_RELATION;
    private string _SVB_REF_NO, _TERMS;
    private string _INVOICE_NO_ITEM, _Invoice_No, _Invoice_Details;

    private string _INVOICE_VALUE, _Invoice_value, _INVOICE_EXRATE;
    private string _MIS_FREIGHT_RATE;

    private string _MIS_INSURANCE_RATE;

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
    private string _CTH_QTY;

    private string _PRODUCT_RITC;
    private string _PRODUCT_CTH;

    private string _PRODUCT_CVD_RATE, _PRODUCT_CVD_NOTN, _PRODUCT_CVD_NOTN_SLNO;
    private string _PRODUCT_EDU_CESS_RATE;
    private string _PRODUCT_SEC_EDU_CESS_RATE;

    private string _PRODUCT_BCD_RATE, _PRODUCT_BCD_NOTN, _PRODUCT_ADDL_DUTY_NOTN, _ADDTIONAL_DUTY_RATE, _PRODUCT_ADDL_DUTY_RATE, _PRODUCT_SEC_EDU_CESS_NOTN, _PRODUCT_EDU_CESS_NOTN, _EXCEMPTION, _INVOICE_CURRENCY, _Invoice_Currency;

    private string _PRODUCT_CETH, _ADDTIONAL_DUTY, _BASIC_DUTY_TOATAL, _CVD_TOTAL, _NCD_TOTAL, _CEC_TOTAL, _CHEC_TOTAL, _ADDLTIONAL_DUTY_TOTAL, _TOTAL_ITEM_DUTY, _NUMBERTOWORDS;
    //----------------------------------------//
    private string _SCHED11_TOTAL, _PRODUCT_ADDL_SHEII_NOTN, _PRODUCT_ADDL_SHEII_SLNO, _PRODUCT_ADDL_SHEII_RATE;
    private string _GSI_TOTAL, _PRODUCT_ADDL_GSI_NOTN, _PRODUCT_ADDL_GSI_SLNO, _PRODUCT_ADDL_GSI_RATE, _PRODUCT_ADDL_GSI_SPL, _PRODUCT_ADDL_GSI_UNIT, _PRODUCT_ADDL_GSI_SPL_TYPE;

    private string _TTA_TOTAL, _PRODUCT_ADDL_TTA_NOTN, _PRODUCT_ADDL_TTA_SLNO, _PRODUCT_ADDL_TTA_RATE, _PRODUCT_ADDL_TTA_SPL, _PRODUCT_ADDL_TTA_UNIT, _PRODUCT_ADDL_TTA_TYPE;

    private string _CETH_SPL_AMT;
    private string _CTH_SPL_AMT;

    private string _TOTAL_DEBIT_DUTY;
    private string _CTH_QTY1;
    private string _CTH_QTY1_CODE;

    private string _CTH_NCD_D_RATE;
    //----------------------------------------//
    private string _PRODUCT_BCD_NOTN_SLNO, _PRODUCT_ADDL_DUTY_NOTN_SLNO, _PRODUCT_SEC_EDU_CESS_NOTN_SLNO, _PRODUCT_EDU_CESS_NOTN_SLNO;
    private double _ASSESABLE_VALUE, _ASSESSABLE_TOTAL, _ITEM_TOTAL;
    public string PRODUCT_BCD_NOTN_SLNO { get { return _PRODUCT_BCD_NOTN_SLNO; } set { _PRODUCT_BCD_NOTN_SLNO = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN_SLNO { get { return _PRODUCT_ADDL_DUTY_NOTN_SLNO; } set { _PRODUCT_ADDL_DUTY_NOTN_SLNO = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN_SLNO { get { return _PRODUCT_SEC_EDU_CESS_NOTN_SLNO; } set { _PRODUCT_SEC_EDU_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_EDU_CESS_NOTN_SLNO { get { return _PRODUCT_EDU_CESS_NOTN_SLNO; } set { _PRODUCT_EDU_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_CVD_NOTN_SLNO { get { return _PRODUCT_CVD_NOTN_SLNO; } set { _PRODUCT_CVD_NOTN_SLNO = value; } }


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

    public string MIS_CURRENCY;
    public string MIS_LOADING_CHARGES;
    public string MIS_LOADING_CURRENCY;
    public string MIS_LOADING_EXRATE;
    public string MIS_DISCOUNT_CURRENCY;
    public string MIS_DISCOUNT_EXRATE;

    public string MIS_HIGHSEASALE_CURRENCY;

    public string REIMPORT_FREIGHT;
    public string REIMPORT_INSURANCE;

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
    public double ADD_ANTI_AMTS, EXCHANGE_RATE;
    public string ADD_ANTI_CUR;
    public string SCHEME_RATE_NEW;

    public double INDIVITUAL_DISCOUNT_AMOUNT = 0;

    public double BASIC_DUTY, CVD, NCD, Customs_Edu_Cess, Customs_Higher_Edu_Cess, AddL_DUTY, TOTAL_DUTY = 0.0;
    public string SCHEME_NOTN_ = "";
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
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
    // public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }
    public string Country_Origin { get { return _Country_Origin; } set { _Country_Origin = value; } }
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

    public string PRODUCT_RITC { get { return _PRODUCT_RITC; } set { _PRODUCT_RITC = value; } }
    public string PRODUCT_CTH { get { return _PRODUCT_CTH; } set { _PRODUCT_CTH = value; } }

    public string PRODUCT_CVD_RATE { get { return _PRODUCT_CVD_RATE; } set { _PRODUCT_CVD_RATE = value; } }
    public string PRODUCT_EDU_CESS_RATE { get { return _PRODUCT_EDU_CESS_RATE; } set { _PRODUCT_EDU_CESS_RATE = value; } }
    public string PRODUCT_EDU_CESS_NOTN { get { return _PRODUCT_EDU_CESS_NOTN; } set { _PRODUCT_EDU_CESS_NOTN = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN { get { return _PRODUCT_SEC_EDU_CESS_NOTN; } set { _PRODUCT_SEC_EDU_CESS_NOTN = value; } }

    public string PRODUCT_SEC_EDU_CESS_RATE { get { return _PRODUCT_SEC_EDU_CESS_RATE; } set { _PRODUCT_SEC_EDU_CESS_RATE = value; } }

    public string PRODUCT_BCD_NOTN { get { return _PRODUCT_BCD_NOTN; } set { _PRODUCT_BCD_NOTN = value; } }
    public string PRODUCT_BCD_RATE { get { return _PRODUCT_BCD_RATE; } set { _PRODUCT_BCD_RATE = value; } }
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

    public string TTA_TOTAL { get { return _TTA_TOTAL; } set { _TTA_TOTAL = value; } }

    public string CETH_SPL_AMT { get { return _CETH_SPL_AMT; } set { _CETH_SPL_AMT = value; } }
    public string CTH_SPL_AMT { get { return _CTH_SPL_AMT; } set { _CTH_SPL_AMT = value; } }

    public string TOTAL_DEBIT_DUTY { get { return _TOTAL_DEBIT_DUTY; } set { _TOTAL_DEBIT_DUTY = value; } }

    public string CTH_QTY1 { get { return _CTH_QTY1; } set { _CTH_QTY1 = value; } }
    public string CTH_QTY1_CODE { get { return _CTH_QTY1_CODE; } set { _CTH_QTY1_CODE = value; } }

    public string CTH_NCD_D_RATE { get { return _CTH_NCD_D_RATE; } set { _CTH_NCD_D_RATE = value; } }
    //----------------------------------------//

    public string BASIC_DUTY_TOTAL { get { return _BASIC_DUTY_TOATAL; } set { _BASIC_DUTY_TOATAL = value; } }
    public string CVD_TOTAL { get { return _CVD_TOTAL; } set { _CVD_TOTAL = value; } }

    public string NCD_TOTAL { get { return _NCD_TOTAL; } set { _NCD_TOTAL = value; } }

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
    #endregion
    #endregion
    public string working_period;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();

    private string _Workingperiod, _INVOICE_ID;
    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }
    public string MIS_CHARGES_Add;
    public string INVOICE_EXCHANGERATE;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    CheckBoxList chklist_Invoice_No = new CheckBoxList();
    CheckBoxList chklist_Invoice_SlNo = new CheckBoxList();
    string CompanyName, Company_Add;

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    
    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH, Company_Lic;
    CheckList CHKLIST = new CheckList();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    private string _MIS_CHARGES_;
    public string MIS_CHARGES_ { get { return _MIS_CHARGES_; } set { _MIS_CHARGES_ = value; } }

    DataTable dtt = new DataTable();
    public double Ass_Value_ttl;
    GridView gv = new GridView();
    //List<Transaction_Default2> Load_Invoice_Details = new List<Transaction_Default2>();

    List<INVOICE_DETAILS> Load_Invoice_Details = new List<INVOICE_DETAILS>();
    List<Report_delivery_Challan> Load_Item_Details = new List<Report_delivery_Challan>();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
        Company_Lic = Connection.Company_License().ToLower();
        // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            Page_loaItem_Details();

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
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                GetGeneral();

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

    public void GetGeneral()
    {
        //string img_path = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Img_Delivery_Chellan/");
        string img_path = "";
        string phone_no = "";
        string GST_Id = "";
        string img_path1 = "";
        //string Logo;
        LocalReport localReport = ReportViewer1.LocalReport;
        Delivery_Challan Import_dc = new Delivery_Challan();
        ReportDataSource dataSource1;

        img_path = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Img_Delivery_Chellan/");
        img_path1 = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Img_Delivery_Chellan/");
        CompanyName = HttpContext.Current.Session["CHA_NAME"].ToString();
        Company_Add = HttpContext.Current.Session["CHA_ADDRESS"].ToString();

        localReport.ReportPath = @"Report/Import_Delivery_Challan.rdlc";



        if (Company_Lic == "eri00188" || Company_Lic == "eri00653")   // Co.in Server KSquare
        {
            //Logo = new Uri(Server.MapPath("~/images/Company_Logo/KSQUARE_CHENNAI.jpg")).AbsoluteUri;
            img_path = new Uri(Server.MapPath("~/images/LetterTemplate/ksquare.png")).AbsoluteUri;

            localReport.ReportPath = @"Report/Import_Delivery_Challan_KSquare.rdlc";
            dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_KSquare(ddlJobNo, SELECT_BRANCH));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);


            ReportParameter param = new ReportParameter("IMAGE", img_path);
            ReportParameter[] p = { param };
            ReportViewer1.LocalReport.SetParameters(p);
        }
        //else
        //{

        else if (Company_Lic.ToUpper() == "ERI00520" || Company_Lic.ToUpper() == "ERI01509" || Company_Lic.ToUpper() == "ERI00519" || Company_Lic.ToUpper() == "ERI00524" || Company_Lic.ToUpper() == "ERI00736" || Company_Lic.ToUpper() == "ERI00863")
        {
            img_path = new Uri(Server.MapPath("~/images/Company_Logo/vintagelog.jpg")).AbsoluteUri;
            localReport.ReportPath = @"Report/Import_Delivery_Challan_Vintage.rdlc";
            if (currentbranch == "ACC, Bangalore" || currentbranch == "ICD,  Banglore")
            {
                    CompanyName = "LOGISTICS GROUP" +
                                     "\r\n" +
                  "VINTAGE INTEGRATED LOGISTICS SERVICES PVT LTD.,";
                    Company_Add = "I Floor, No 824, HAL, 2nd Stage, 11th Main,2nd Cross, Indira Nagar" +
                                        "\r\n" +
                                                 "Bengaluru, Karnataka-560008";
                    phone_no = "080-40901532";
                    GST_Id = "29AADCV9116C1ZB";

            }
            else if (currentbranch == "CusHouse, Chennai" || currentbranch == "ACC, Chennai" || currentbranch == "Customs, KATTUPALLI" || currentbranch == "ICD, CONCOR")
            {
                    CompanyName = "LOGISTICS GROUP" +
                                  "\r\n" +
               "VINTAGE INTEGRATED LOGISTICS SERVICES PVT LTD.,";
                    Company_Add = "New No.356,Plot No.517,1st Floor,MKN Road,Morrison 1st Street,Alandur," +
                                        "\r\n" +
                                                 "Chennai - 600 016" +
                                                 "\r\n" +
                                          "COROPRATE ADDRESS" +
                                          "\r\n" +
                                          "HIGH GATE,Level 4, 153 (Old 82) Santhome High Road," +
                                           "\r\n" +
                                                "Raja Annamalaipuram ,Chennai-600028";
                    phone_no = "044-48530506";
                    GST_Id = "33ADCV9116C1ZM";
                }
                dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new(ddlJobNo, SELECT_BRANCH, img_path));
                ReportViewer1.LocalReport.DataSources.Add(dataSource1);

                ReportParameter param = new ReportParameter("image", img_path);
                ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
                ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
                ReportParameter param3 = new ReportParameter("phone_no", phone_no);
                ReportParameter param4 = new ReportParameter("GST_Id", GST_Id);
                ReportParameter param5 = new ReportParameter("image1", img_path1);

                ReportParameter[] p = { param, param1, param2, param3, param4, param5 };
                ReportViewer1.LocalReport.SetParameters(p);
        }
        else if (Company_Lic.ToUpper() == "ERI01532") //.Live Server SMS
        {
            img_path = new Uri(Server.MapPath("~/images/Company_Logo/SMS.png")).AbsoluteUri;
            img_path1 = new Uri(Server.MapPath("~/images/Company_Logo/SMS_SEAL.png")).AbsoluteUri;
            localReport.ReportPath = @"Report/Import_Delivery_Challan_SMS.rdlc";

            dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new(ddlJobNo, SELECT_BRANCH, img_path));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);

            ReportParameter param = new ReportParameter("image", img_path);
            ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
            ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
            ReportParameter param3 = new ReportParameter("phone_no", phone_no);
            ReportParameter param4 = new ReportParameter("GST_Id", GST_Id);
            ReportParameter param5 = new ReportParameter("image1", img_path1);

            ReportParameter[] p = { param, param1, param2, param3, param4, param5 };
            ReportViewer1.LocalReport.SetParameters(p);

        }
        /*else if (Company_Lic.ToUpper() == "ERI00829")  //.ORG  PRADEEP CARGO BLR
        {
            Company_Add = "1542,2ND MAIN, E BLOCK, AECS LAYOUT,KUNDALLAHALLI POST," +
                                   "\r\n" +
                                        "BANGALORE - 560037";
            img_path = new Uri(Server.MapPath("~/images/Company_Logo/PRADEEP.jpg")).AbsoluteUri;
            localReport.ReportPath = @"Report/Import_Delivery_Challan_pradeep.rdlc";

            dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new(ddlJobNo, SELECT_BRANCH, img_path));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);

            ReportParameter param = new ReportParameter("image", img_path);
            ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
            ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
            ReportParameter param3 = new ReportParameter("phone_no", phone_no);
            ReportParameter param4 = new ReportParameter("GST_Id", GST_Id);
            ReportParameter param5 = new ReportParameter("image1", img_path1);

            ReportParameter[] p = { param, param1, param2, param3, param4, param5 };
            ReportViewer1.LocalReport.SetParameters(p);
        }*/
        else if (Company_Lic.ToUpper() == "ERI02373")  //.Trade  Sudarshan Cargo
        {
            Company_Add = "Air & Sea Freight, Warehousing, Shipping, Transporting, Customs Approved Clearing & Forwarding Agents." +
                                   "\r\n" +
                                        "25/9, 1ST FLOOR, NOBLE 1ST STREET, ALANDUR CHENNAI-600016, TAMIL NADU";
            img_path = new Uri(Server.MapPath("~/images/Company_Logo/Sudarshan_Cargo.png")).AbsoluteUri;
            localReport.ReportPath = @"Report/Import_Delivery_Challan_Sudarshan_Cargo.rdlc";

            dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new(ddlJobNo, SELECT_BRANCH, img_path));
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);

            ReportParameter param = new ReportParameter("image", img_path);
            ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
            ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);

            ReportParameter[] p = { param, param1, param2 };
            ReportViewer1.LocalReport.SetParameters(p);
        }

        else// All other ERI Customers used Import_Delivery_Challan.rdlc  --NEW COMMON MODEL ELSE OLD MODEL
        {
           if (Company_Lic.ToUpper() == "ERI00139")  //.COM ANNAI LOGISTICS ---NEW COMMON MODEL
           {
               localReport.ReportPath = @"Report/Import_Delivery_Challan_DC_Common.rdlc";
               img_path = " ";
               CompanyName = "SRI ANNAI LOGISTICS";
               Company_Add = "NO: 24, GST ROAD, MEENAMBAKKAM, CHENNAI - 600 027. " +                            
                       "\r\n" +
                       " Tel. No: 044 22560146  Email: sriannailogistics@gmail.com";

                dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new_pl_Global(ddlJobNo, SELECT_BRANCH, img_path));
                ReportViewer1.LocalReport.DataSources.Add(dataSource1);
                ReportParameter param = new ReportParameter("image", img_path);
                ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
                ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
                ReportParameter[] p = { param, param1, param2 };
                ReportViewer1.LocalReport.SetParameters(p);
           }
           else if (Company_Lic.ToUpper() == "ERI00829")  //.PRADEEP CARGO BLR ---NEW COMMON MODEL
           {
               localReport.ReportPath = @"Report/Import_Delivery_Challan_DC_Common_Ver1.rdlc";
               img_path = new Uri(Server.MapPath("~/images/Company_Logo/PRADEEP_BLR.jpg")).AbsoluteUri;
               CompanyName = "    PRADEEP CARGO SERVICES PVT LTD  ";
               Company_Add = "      1542, 2ND MAIN, E BLOCK, AECS LAYOUT, KUNDALLAHALLI POST,  " +
                                      "\r\n" +
                                           "    BANGALORE - 560037. Ph +9180 49094000  ";              
               

               dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new_pl_Global(ddlJobNo, SELECT_BRANCH, img_path));
               ReportViewer1.LocalReport.DataSources.Add(dataSource1);
               ReportParameter param = new ReportParameter("image", img_path);
               ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
               ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
               ReportParameter[] p = { param, param1, param2 };
               ReportViewer1.LocalReport.SetParameters(p);
           }
           else if (Company_Lic.ToUpper() == "ERI01246")  //SEA CLEAR LOGISTICS, BLR ---NEW COMMON MODEL
           {
               localReport.ReportPath = @"Report/Import_Delivery_Challan_DC_Common_Ver1.rdlc";
               img_path = new Uri(Server.MapPath("~/images/Company_Logo/SEA_CLEAR.png")).AbsoluteUri;
               CompanyName = " SEA CLEAR LOGISTICS PVT LTD ";
               Company_Add = " NO.13/1, FLOUR MILL ROAD, MES COLONY, KONENA AGRAHARA, " +
                                      "\r\n" +
                                           " HAL POST, BENGALURU - 560017. Ph 080 - 4148 2493 ";


               dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new_pl_Global(ddlJobNo, SELECT_BRANCH, img_path));
               ReportViewer1.LocalReport.DataSources.Add(dataSource1);
               ReportParameter param = new ReportParameter("image", img_path);
               ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
               ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
               ReportParameter[] p = { param, param1, param2 };
               ReportViewer1.LocalReport.SetParameters(p);
           }


           else if (Company_Lic.ToUpper() == "ERI03229")  //.NET PL GLOBAL ---NEW COMMON MODEL
           {
               localReport.ReportPath = @"Report/Import_Delivery_Challan_DC_Common.rdlc";
               img_path = " ";
               CompanyName = "PL GLOBAL FORWARDERS PRIVATE LIMITED";
               Company_Add = "No.8 Kodi krupa, Ground Floor 5th cross, " +
                       "\r\n" +
                            "Airview colony Konenna Agrahara, HAL, Bengaluru - 560017, KARNATAKA" +
                       "\r\n" +
                       " Tel. No: 080 25230388  Email: accountspll@pllogistics.co.in";

               dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new_pl_Global(ddlJobNo, SELECT_BRANCH, img_path));
               ReportViewer1.LocalReport.DataSources.Add(dataSource1);
               ReportParameter param = new ReportParameter("image", img_path);
               ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
               ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
               ReportParameter[] p = { param, param1, param2 };
               ReportViewer1.LocalReport.SetParameters(p);
           }
           else if (Company_Lic.ToUpper() == "ERI03260")  //.NET SRI CHOWDESHWARI, BLR
           {
               //localReport.ReportPath = @"Report/Import_Delivery_Challan_DC_Common_with_only_logo.rdlc";
               localReport.ReportPath = @"Report/Import_Delivery_Challan_DC_Common_SRI_CHOWDESHWARI_BLR.rdlc";
               img_path = new Uri(Server.MapPath("~/images/Company_Logo/SRI_CHOWDESHWARI.png")).AbsoluteUri;
               CompanyName = "SRI CHOWDESHWARI LOGISTICS LLP";
               Company_Add = "REG OFFICE : NO.275, 2ND FLOOR, 8TH MAIN, BEML LAYOUT," +
                       "\r\n" +
                            " THUBARAHALLI, BENGALURU, KARNATAKA, 560066. ";

               dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new_pl_Global(ddlJobNo, SELECT_BRANCH, img_path));
               ReportViewer1.LocalReport.DataSources.Add(dataSource1);
               ReportParameter param = new ReportParameter("image", img_path);
               ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
               ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
               ReportParameter[] p = { param, param1, param2 };
               ReportViewer1.LocalReport.SetParameters(p);
           }
          else if (Company_Lic.ToUpper() == "ERI03275")  //.NET QUICK LINK
          {
              localReport.ReportPath = @"Report/Import_Delivery_Challan_DC_Common_Delhi.rdlc";                
                img_path = new Uri(Server.MapPath("~/images/Company_Logo/QUICKLINK.jpg")).AbsoluteUri;
                CompanyName = "QUICK LINK CARGO SERVICES";
                Company_Add = "WZ-209/4, CABIN NO 5, VARINDER NAGAR," +
                        "\r\n" +
                             "GALI NO 3, P O JANAKPURI, NEW DELHI - 110058." +
                        "\r\n" +
                        "  Ph No: 9911217373, 9212217373 Email: billing@qlcsdelhi.com";
                dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new_pl_Global(ddlJobNo, SELECT_BRANCH, img_path));
                ReportViewer1.LocalReport.DataSources.Add(dataSource1);
                ReportParameter param = new ReportParameter("image", img_path);
                ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
                ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
                ReportParameter[] p = { param, param1, param2 };
                ReportViewer1.LocalReport.SetParameters(p);
           }

           else
           {
                dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new(ddlJobNo, SELECT_BRANCH, img_path));
                ReportViewer1.LocalReport.DataSources.Add(dataSource1);
                ReportParameter param = new ReportParameter("image", img_path);
                ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
                ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
                ReportParameter param3 = new ReportParameter("phone_no", phone_no);
                ReportParameter param4 = new ReportParameter("GST_Id", GST_Id);
                //ReportParameter param5 = new ReportParameter("image1", img_path1);
                //ReportParameter[] p = { param, param1, param2, param3, param4, param5 };
                ReportParameter[] p = { param, param1, param2, param3, param4 };
                ReportViewer1.LocalReport.SetParameters(p);
           }
       }        
    }

    //public void GetGeneral_old()
    //{
    //    //string img_path = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Img_Delivery_Chellan/");
    //    string img_path = "";
    //    string phone_no = "";
    //    string GST_Id = "";
    //    string img_path1 = "";
    //    //string Logo;
    //    LocalReport localReport = ReportViewer1.LocalReport;
    //    Delivery_Challan Import_dc = new Delivery_Challan();
    //    ReportDataSource dataSource1;
    //    if (Company_Lic == "eri00188" || Company_Lic == "eri00653")
    //    {
    //        //Logo = new Uri(Server.MapPath("~/images/Company_Logo/KSQUARE_CHENNAI.jpg")).AbsoluteUri;
    //        img_path = new Uri(Server.MapPath("~/images/LetterTemplate/ksquare.png")).AbsoluteUri;

    //        localReport.ReportPath = @"Report/Import_Delivery_Challan_KSquare.rdlc";
    //        dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_KSquare(ddlJobNo, SELECT_BRANCH));
    //        ReportViewer1.LocalReport.DataSources.Add(dataSource1);


    //        ReportParameter param = new ReportParameter("IMAGE", img_path);
    //        ReportParameter[] p = { param };
    //        ReportViewer1.LocalReport.SetParameters(p);
    //    }
    //    else
    //    {
    //        img_path = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Img_Delivery_Chellan/");            
    //        img_path1 = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Img_Delivery_Chellan/");
    //        CompanyName = HttpContext.Current.Session["CHA_NAME"].ToString();
    //        Company_Add = HttpContext.Current.Session["CHA_ADDRESS"].ToString();

    //        localReport.ReportPath = @"Report/Import_Delivery_Challan.rdlc";

    //        if (Company_Lic.ToUpper() == "ERI00520" || Company_Lic.ToUpper() == "ERI01509" || Company_Lic.ToUpper() == "ERI00519" || Company_Lic.ToUpper() == "ERI00524" || Company_Lic.ToUpper() == "ERI00736" || Company_Lic.ToUpper() == "ERI00863")
    //        {
    //            img_path = new Uri(Server.MapPath("~/images/Company_Logo/vintagelog.jpg")).AbsoluteUri;                
    //            localReport.ReportPath = @"Report/Import_Delivery_Challan_Vintage.rdlc";
    //            if (currentbranch == "ACC, Bangalore" || currentbranch == "ICD,  Banglore")
    //            {
    //                CompanyName = "LOGISTICS GROUP" +
    //                                 "\r\n" +
    //              "VINTAGE INTEGRATED LOGISTICS SERVICES PVT LTD.,";
    //                Company_Add = "I Floor, No 824, HAL, 2nd Stage, 11th Main,2nd Cross, Indira Nagar" +
    //                                    "\r\n" +
    //                                             "Bengaluru, Karnataka-560008";
    //                phone_no = "080-40901532";
    //                GST_Id = "29AADCV9116C1ZB";

    //            }
    //            else if (currentbranch == "CusHouse, Chennai" || currentbranch == "ACC, Chennai" || currentbranch == "Customs, KATTUPALLI" || currentbranch == "ICD, CONCOR")
    //            {
    //                CompanyName = "LOGISTICS GROUP" +
    //                              "\r\n" +
    //           "VINTAGE INTEGRATED LOGISTICS SERVICES PVT LTD.,";
    //                Company_Add = "New No.356,Plot No.517,1st Floor,MKN Road,Morrison 1st Street,Alandur," +
    //                                    "\r\n" +
    //                                             "Chennai - 600 016" +
    //                                             "\r\n" +
    //                                      "COROPRATE ADDRESS" +
    //                                      "\r\n" +
    //                                      "HIGH GATE,Level 4, 153 (Old 82) Santhome High Road," +
    //                                       "\r\n" +
    //                                            "Raja Annamalaipuram ,Chennai-600028";
    //                phone_no = "044-48530506";
    //                GST_Id = "33ADCV9116C1ZM";
    //            }
    //        }
    //        else if (Company_Lic.ToUpper() == "ERI01532")
    //        {
               
    //            img_path = new Uri(Server.MapPath("~/images/Company_Logo/SMS log.jpg")).AbsoluteUri;
    //            img_path1 = new Uri(Server.MapPath("~/images/Company_Logo/SMS_SEAL log.jpg")).AbsoluteUri;
    //            localReport.ReportPath = @"Report/Import_Delivery_Challan_SMS.rdlc";

    //        }
    //        else if (Company_Lic.ToUpper() == "ERI00829")
    //        {
    //            Company_Add = "1542,2ND MAIN, E BLOCK, AECS LAYOUT,KUNDALLAHALLI POST," +
    //                                   "\r\n" +
    //                                        "BANGALORE - 560037";
    //            img_path = new Uri(Server.MapPath("~/images/Company_Logo/PRADEEP.jpg")).AbsoluteUri;
    //            localReport.ReportPath = @"Report/Import_Delivery_Challan_pradeep.rdlc";
    //        }

    //        dataSource1 = new ReportDataSource("DELIVERY_CHALLAN", Import_dc.Load_Report_new(ddlJobNo, SELECT_BRANCH, img_path));
    //        ReportViewer1.LocalReport.DataSources.Add(dataSource1);

    //        ReportParameter param = new ReportParameter("image", img_path);
    //        ReportParameter param1 = new ReportParameter("CHA_NAME", CompanyName);
    //        ReportParameter param2 = new ReportParameter("CHA_ADDRESS", Company_Add);
    //        ReportParameter param3 = new ReportParameter("phone_no", phone_no);
    //        ReportParameter param4 = new ReportParameter("GST_Id", GST_Id);
    //        ReportParameter param5 = new ReportParameter("image1", img_path1);

    //        ReportParameter[] p = { param, param1, param2, param3, param4, param5 };
    //        ReportViewer1.LocalReport.SetParameters(p);
            
    //    }
    //}


    protected void Button1_Click(object sender, EventArgs e)
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
}