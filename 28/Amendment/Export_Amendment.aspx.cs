using System;
using System.Data; // This was added to make CommandType function
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
using System.IO;
using Microsoft.ApplicationBlocks.Data;

using Microsoft.Reporting.WebForms;
using System.Net.Mail;

public partial class Export_Amendment : ThemeClass
{
    adminmaster erm = new adminmaster();
    Date_Time split = new Date_Time();
    DataSet dss = new DataSet();
    DataSet dss_adm = new DataSet();
    eroyalmaster Imp_Exp = new eroyalmaster();
    Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();

    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();

    Exp_Amendment Amnd = new Exp_Amendment();
    DataSet ds = new DataSet();

    public string ICEGATE_EMAIL_ID = "", ICEGATE_EMAIL_PWD = "";
    public string EMail_ID = "";

    public string IS_Imgbtn, IMPORTER_CLASS;
    public string GetDate_ddmmyy;
  
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "", targetPath = "";
    public string folderName = "/Submission";
    ErrorLogs er = new ErrorLogs();
    StreamWriter sw;
    public string createfilename = "";
    public char ch = Convert.ToChar(29);
    public string CHA_NO = "", ICEGATE_ID = "";
    public string PREVIOUS_UNITPRICE = "", PREVIOUS_CURRENY = "", PREVIOUS_CUSTOMSITE = "";
    public string SELECT_TYPE,SELECT_BRANCH;    
    public string COMPANY_ID = "";
    public string Amendment_Type = "";
    public string Amendment_No = "";
    public string Amendment_Date = "";
    string lICENSE_Item_Selected_ListBox = "";

     #region General_Details

    public string JOBID;
    public string JOBNO;
    public string DDMMYY_JOBDATE;
    public string JOBDATE;
    public string TRANSPORT_MODE;
    public string CUSTOMS_HOUSE;
    public string SB_TYPE;
    public string EXPORTER_NAME;
    public string BRANCH_NO;
    public string IEC_NO;
    public string ADDRESS1;
    public string ADDRESS2;
    public string ADDRESS3;
    public string ADDRESS4;
    public string ADDRESS5;

    public string TYPE_OF_EXPORTER;

    public string ADCODE;
    public string BANK_ACCOUNT;
    public string DRAWBACK_ACCOUNT;
    public string CONSIGNEE_NAME;
    public string CONSIGNEE_ADD1;
    public string CONSIGNEE_ADD2;
    public string CONSIGNEE_ADD3;
    public string CONSIGNEE_ADD4;
    public string CONSIGNEE_ADD5;
    public string COUNTRY_DISCHARGE;
    public string PORT_DISCHARGE;
    public string COUNTRY_FINAL_DEST;
    public string PORT_FINAL_DEST;
    public string STATE_OF_EXPORT;
    public string NFEI;
    public string NFEI_TYPE;
    public string RBI_WAIVER_NO;
    public string RBI_WAIVER_DATE;
    public string MARKS_NO;
    public string EPZ_CODE = "";
    public string EXPORTER_CLASS = "";

    public string GROSS_WEIGHT;
    public string UNIT_CODE;
    public string NET_WEIGHT;
    public string NATURE_OF_CARGO;
    public string MARKS_NOS;
    public string TOTAL_PACKAGES;
    public string LOOSE_PACKETS;
    public string NO_CONTAINERS;
    public string ANNEX_AIR_MAWB_NO;
    public string ANNEX_AIR_HAWB_NO;
    public string ROTATION_DATE;
    public string ROTATION_NO;
    public string ANNEX_SEA_FAC_STUFFED;
    public string ANNEX_SEA_SAMPLE_ACCOM;
    public string ANNEX_SEA_SEAL_TYPE;
    public string PMV_VALUE;
    public string JOB_STATUS;

    public string GSTN_TYPE;
    public string GSTN_ID;

    #endregion

    #region IGM Details_Public_Attributes

    public string IGM_ID;
    public string IGM_SLNO_UPDATE;
    public string IGM_JOBNO;
    public string IGM_JOBDATE;
    public string IGM_AIRLINECODE;
    public string IGM_AIRLINENAME;
    public string IGM_FLIGHTNO_VESSELNO;
    public string IGM_FLIGHT_VESSELDATE;
    public string IGM_NO;
    public string IGM_DATE;
    public string IGM_MAWB_MBL;
    public string IGM_MAWB_MBLDATE;
    public string IGM_HAWB_HBLNO;
    public string IGM_HAWB_HBLDATE;
    public string IGM_NOOFPACKAGE;
    public string IGM_PACKAGETYPE;
    public string IGM_GROSSWEIGHT;
    public string IGM_TYPEOFWEIGHT;
    public string IGM_NETWEIGHT;
    public string IGM_NETWEIGHTTYPE;
    public string IGM_MARKSNOS1;
    public string IGM_MARKSNOS2;
    public string IGM_MARKSNOS3;

    public string IGM_TRANSPORTMODE;
    public string IGM_GATEWAY_IGM_NO;
    public string IGM_GATEWAY_IGM_DATE;
    public string IGM_GATEWAY_PORT_CODE;

    #endregion

    #region Container Details_Public_Attributes

    public string CONTAINERID;
    public string CONTAINER_NO;
    public string CONTAINER_IGM_SLNO;
    public string CONTAINER_IGM_NO;
    public string CONTAINER_IGM_DATE;
    public string SEAL_NO;
    public string FCL_OR_LCL;
    private string TRUCK_NO;

    #endregion

    #region Invoice_Details

    public string INVOICE_ID;
    //public string JOBNO;
    //public string JOBDATE;
    public string INVOICE_SLNO;
    public string INVOICE_NO;
    public string INVOICE_DATE;
    public string PAYMENT_METHOD;
    public string PERIOD_PAYMENT;
    public string INVOICE_VALUE;
    public string INVOICE_CURRENCY;
    public string EXCHANGE_RATE;
    public string CONTRACT_NO;
    public string TERMS;
    public string BUYER;
    public string BUYER_NAME;
    public string BUYER_ADDRESS;
    public string BUYER_ADDRESS1;
    public string BUYER_ADDRESS2;
    public string BUYER_ADDRESS3;
    public string BUYER_ADDRESS4;
    public string COMMISSION_RATE;
    public string COMMISSION_CHARGES;
    public string COMMISSION_CURRENCY;
    public string FOB_RATE;
    public string FOB_CHARGES;
    public string FOB_CURRENCY;
    public string PACKMISC_RATE;
    public string PACKMISC_CHARGES;
    public string PACKMISC_CURRENCY;
    public string OTHER_DEDUCTION_RATE;
    public string OTHER_DEDUCTION_CHARGES;
    public string OTHER_DEDUCTION_CURRENCY;
    public string FREIGHT_RATE;
    public string FREIGHT_CHARGES;
    public string FREIGHT_CURRENCY;
    public string INSURANCE_RATE;
    public string INSURANCE_CHARGES;
    public string INSURANCE_CURRENCY;
    public string WHEATHER_UNIT_PRICE;


    public string NON_STD_EFFECT_DT_EXP;
    public string NON_STD_BANKNAME;
    public string NON_STD_CERTIFICATE_NO;
    public string NON_STD_CERTIFICATE_DATE;

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


    //******** Exchange Rate ********//

    public string Standard_Currency = "Y";
    public string Currency_Name;
    public string EXCHANGE_UNIT;
    public string Effective_Date = "";

    #endregion

    #region Item_Details

    public string ITEM_ID;
    public string ITEM_SLNO;
    public string ITEM_DESCRIPTION1;
    public string ITEM_DESCRIPTION2;
    public string ITEM_DESCRIPTION3;
    public string RITCNO;
    public string ITEM_QTY;
    public string ITEM_QTY_CODE;
    public string ITEM_UNIT_PRICE;
    public string ITEM_PER;
    public string ITEM_AMOUNT;
    public string ITEM_PMVVALUE, PMV_PER_UNIT, PMV_METHOD;
    public string ITEM_SCHEME_CODE;
    public string ITEM_ACCESSORIES_DESC;
    public string ITEM_AR4_NO;
    public string ITEM_AR4_DATE;
    public string ITEM_COMMISSION_RATE;
    public string ITEM_DIVISION;
    public string ITEM_RANGE;
    public string ITEM_REMARKS;
    public string ITEM_IECCODE;
    public string ITEM_EXPORTER_NAME;
    public string ITEM_EXPORTER_NAME_THIRD;
    public string BR_SLNO;
    public string ITEM_ADDRESS1;
    public string ITEM_ADDRESS2;
    public string ITEM_ADDRESS3;
    public string ITEM_ADDRESS4;
    public string ITEM_ADDRESS5;
    public string ITEM_STR_CODE;
    public string REWARD_POINTS;


    public string MANUFACTURER_PRODUCER;
    public string M_P_GROWER_CODE;
    public string M_P_GROWER_ADD1;
    public string M_P_GROWER_ADD2;
    public string M_P_GROWER_CITY;
    public string M_P_GROWER_COUNTRY_SUBDIV;
    public string M_P_GROWER_PIN;
    public string M_P_GROWER_COUNTRY;
    public string SOURCE_STATE;
    public string TRANSIT_COUNTRY;
    public string ACCESSORY_STATUS;
    public string HAWB_NO;
    public string TOTAL_PKGS;
    public string ENDUSE_ITEM;
    public string IGST_PAYMENT;
    public string TAXABLE_VALUE;
    public string IGST_AMT;
    public string RODTEP;

    public string DRAWBACK_SLNO;
    public string DRAWBACK_QTY;
    #endregion

    #region Supporting Docs Public_Attributes

    public string SUP_DECLARATION_NUMBER;
    public string SUP_DECLARATION_DATE;
    public string SUP_DECLARATION_TYPE;
    public string UNIQUE_DOC_NUMBER;
    public string DOC_TYPE_CODE;
    public string DOC_ISSUING_PARTY_CODE;
    public string DOC_ISSUING_PARTY_NAME_ADD1;
    public string DOC_ISSUING_PARTY_NAME_ADD2;
    public string DOC_ISSUING_PARTY_CITY;
    public string DOC_ISSUING_PARTY_PIN;
    public string SUP_DOC_SERIAL_NO;

    public string DOC_REF_NUMBER;
    public string PLACE_OF_ISSUE;
    public string DOC_ISSUE_DATE;
    public string DOC_EXPIRY_DATE;
    public string BENEFICIARY_PARTY_CODE;

    public string BENEFICIARY_PARTY_ADDRESS1;
    public string BENEFICIARY_PARTY_ADDRESS2;
    public string BENEFICIARY_PARTY_CITY;
    public string BENEFICIARY_PARTY_PIN;
    public string FILE_TYPE;
    
    public string DECLARATION_TYPE;
    //public string UNIQUE_DOC_NUMBER;
    public string DOC_ISSUING_PARTY_NAME;
    public string BENEFICIARY_PARTY_NAME;
    public string SUP_DOC_ICEGATE_ID;


    #endregion Supporting Docs Public_Attributes

    #region Statement_Public_Attributes

    public string STMT_DECLARATION_TYPE;
    public string STMT_DECLARATION_NUMBER;
    public string STMT_DECLARATION_DATE;
    public string STMT_TYPE;
    public string STMT_CODE;
    public string STMT_TEXT;

    #endregion Statement_Public_Attributes

    public string AMEND_TYPE_FF;

    #region BE_ENTRY Details_Public_Attributes

    public string BE_JOBNO;
    public string SB_NO;
    public string SB_DATE;
    public string SB_NO_OF_PACKAGES;
    public string BE_PACKAGE_CODE;
    public string BE_WEIGHT;
    public string BE_UNIT_CODE;
    public string BE_INBOND_NO;
    public string BE_INBOND_DATE;
    public string BE_WAREHOUSE_CUSTOMS;
    public string BE_WAREHOUSE_CUSTOMS_CODE;
    public string JOB_LOCK, JOB_RELEASE, JOB_USER;
    #endregion

    #region License Details
    public string LICENSE_ID;
    public string SCHEME_CODE;
    public string SCHEME;
    public string LICENSE_R_SL_NO;
    public string LICENSE_NO;
    public string LICENSE_DATE;

    public string LICENSE_IMP_EXP_ID;
    public string LICENSE_E_SL_NO;
    public string LICENSE_EXP_QTY;
    public string LICENSE_EXP_UNIT;
    public string LICENSE_IMP_ITEM_SL_NO;
    public string LICENSE_IMP_DESC;
    public string LICENSE_IMP_QTY;
    public string LICENSE_IMP_UNIT;
    public string LICENSE_IMP_TYPE;
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
           

            CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
            //ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            ICEGATE_ID = Connection.Get_EXP_ICEGATE_ID_New();
            ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Query_Reply/");
            hdn_ICEGATE_ID_List.Value = Connection.Get_User_ICEGATE_ID_DropdownList("Load_EXP_ICEGATE_ID_dropdown");

            if (Connection.COMPANYID() == "11" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "5" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
            {

                if (SELECT_TYPE == "Branchwise Job")
                {
                    targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "IMP_Job_history/");
                }
                else if (SELECT_TYPE == "Areawise Job")
                {
                    targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["GroupName"].ToString() + "/" + "IMP_Job_history/");
                }

                else
                {
                    targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "IMP_Job_history/");
                }

            }

            COMPANY_ID = Session["COMPANY_ID"].ToString();
              
            SELECT_BRANCH = Connection.Get_Company_Type();
            
            HDBranch.Value = SELECT_BRANCH;
            imgbtnFlatFile.Visible = false;

            if (!IsPostBack)
            {
                //txt_icegate_Id.Text = Connection.Get_Icegate_Id();
                txt_icegate_Id.Text = Connection.Get_EXP_ICEGATE_ID_New();
                Load_Amendment_Page();
                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }

                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 7;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                //ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
               // txt_jobno_search.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txt_jobno_search.ClientID + "', '" + txtCustomHouse.ClientID + "')");
                
                if (!string.IsNullOrEmpty(Request["jobno"]))
                {

                    if (!string.IsNullOrEmpty(Request["SUB"]))
                    {
                        //ddlJobNo.SelectedValue = Request["jobno"].ToString();
                        btnSearch_Click(sender, e);
                    }
                    else
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                        currdiv.Style.Add("display", "none");

                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("innerbox_Main_Top_User");
                        currdiv1.Style.Add("display", "none");

                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("maincontent");
                        currdiv2.Style.Add("margin", "-16px 2px 0 0");
                        currdiv2.Style.Add("padding", "2px 0 0");

                        //ddlJobNo.Items.Clear();
                        //ddlJobNo.Items.Add(Request["jobno"].ToString());

                    }
                }
                else
                {

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

    private void GENERAL()
    {
        setdata();
        int is_Annexure_Mode = Amnd.result;

        if (is_Annexure_Mode == 1)
        {

            if (dss.Tables[0].Rows.Count > 0)
            {
                //JOBNO = dss.Tables[0].Rows[0]["JOBNO"].ToString();
                //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//
                string SB_dt = dss.Tables[0].Rows[0]["SB_DATE"].ToString();
                if (SB_dt == "01/01/1900")
                {
                    SB_dt = "";
                }
                SB_NO = dss.Tables[0].Rows[0]["SB_NO"].ToString();
                SB_DATE = SB_dt;
                //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//

                JOBDATE = dss.Tables[0].Rows[0]["JOBDATE"].ToString().Replace("19000101", "");
                DDMMYY_JOBDATE = dss.Tables[0].Rows[0]["JOBDT_DDMMYY"].ToString().Replace("010100", "");


                TRANSPORT_MODE = dt.Trim(dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString());

                CUSTOMS_HOUSE = dt.Trim(dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString());

                SB_TYPE = dt.Trim(dss.Tables[0].Rows[0]["SB_TYPE"].ToString());

                //EXPORTER_NAME = dt.Trim_Single_Quote(dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString());
                EXPORTER_NAME = dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();

                BRANCH_NO = dt.Trim(dss.Tables[0].Rows[0]["BRANCH_NO"].ToString());
                IEC_NO = dt.Trim(dss.Tables[0].Rows[0]["IEC_NO"].ToString());
                ADDRESS1 = dt.Trim(dss.Tables[0].Rows[0]["ADDRESS1"].ToString());
                ADDRESS2 = dt.Trim(dss.Tables[0].Rows[0]["ADDRESS2"].ToString());
                ADDRESS3 = dt.Trim(dss.Tables[0].Rows[0]["ADDRESS3"].ToString());
                ADDRESS4 = dt.Trim(dss.Tables[0].Rows[0]["ADDRESS4"].ToString());
                ADDRESS5 = dt.Trim(dss.Tables[0].Rows[0]["ADDRESS5"].ToString());

                TYPE_OF_EXPORTER = dt.Trim(dss.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString());

                ADCODE = dt.Trim(dss.Tables[0].Rows[0]["ADCODE"].ToString());

                if (ADCODE != "")
                {
                    if (SB_TYPE == "SEZ")
                    {
                        if (ADCODE != "NFEI")
                        {
                            ADCODE = ADCODE.Substring(0, 7);
                        }
                    }
                    else
                    {
                        ADCODE = ADCODE.Substring(0, 7);
                    }
                }

                BANK_ACCOUNT = dt.Trim(dss.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString());
                DRAWBACK_ACCOUNT = dt.Trim(dss.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString());
                //CONSIGNEE_NAME = dt.Trim_Single_Quote(dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString());
                CONSIGNEE_NAME = dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                CONSIGNEE_ADD1 = dt.Trim(dss.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString());

                CONSIGNEE_ADD2 = dt.Trim(dss.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString());

                //SECTION46_DESC = dss.Tables[0].Rows[0]["SECTION46_DESC"].ToString();

                CONSIGNEE_ADD3 = dt.Trim(dss.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString());

                //FIRSTCHECK_DESC = dss.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString();

                CONSIGNEE_ADD4 = dt.Trim(dss.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString());

                //GREEN_CHANNEL_DESC = dss.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString();

                CONSIGNEE_ADD5 = dt.Trim(dss.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString());

                //KACHHA_BE_DESC = dss.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString();

                COUNTRY_DISCHARGE = dt.Trim(dss.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString());

                //SECTION48_DESC= dss.Tables[0].Rows[0]["SECTION48_DESC"].ToString();

                PORT_DISCHARGE = dt.Trim(dss.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString());

                COUNTRY_FINAL_DEST = dt.Trim(dss.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString());
                PORT_FINAL_DEST = dt.Trim(dss.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString());
                STATE_OF_EXPORT = dt.Trim(dss.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString());
                NFEI = dt.Trim(dss.Tables[0].Rows[0]["NFEI"].ToString());
                NFEI_TYPE = dt.Trim(dt.Split("-", dss.Tables[0].Rows[0]["NFEI_TYPE"].ToString()));
                RBI_WAIVER_NO = dt.Trim(dss.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString());
                RBI_WAIVER_DATE = dt.Trim(dss.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString().Replace("19000101", ""));

                MARKS_NO = dt.Trim(dss.Tables[0].Rows[0]["MARKS_NO"].ToString().Replace("\r\n", " "));

                JOB_STATUS = dss.Tables[0].Rows[0]["JOB_STATUS"].ToString();
                Session.Remove("JOB_LOCK");
                Session["JOB_LOCK"] = JOB_STATUS;

                GROSS_WEIGHT = dt.Trim(dss.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString());
                UNIT_CODE = dt.Trim(dss.Tables[0].Rows[0]["UNIT_CODE"].ToString());
                NET_WEIGHT = dt.Trim(dss.Tables[0].Rows[0]["NET_WEIGHT"].ToString());
                NATURE_OF_CARGO = dt.Trim(dss.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString());
                MARKS_NOS = dt.Trim(dss.Tables[0].Rows[0]["MARKS_NOS"].ToString());
                TOTAL_PACKAGES = dt.Trim(dss.Tables[0].Rows[0]["TOTAL_PACKAGES"].ToString());
                ROTATION_NO = dt.Trim(dss.Tables[0].Rows[0]["ROTATION_NO"].ToString());
                ROTATION_DATE = dt.Trim(dss.Tables[0].Rows[0]["ROTATION_DATE"].ToString().Replace("19000101", ""));

                GSTN_TYPE = dt.Trim(dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString());
                GSTN_ID = dt.Trim(dss.Tables[0].Rows[0]["GSTN_ID"].ToString());

                if (TRANSPORT_MODE == "Sea")
                {
                    LOOSE_PACKETS = dt.Trim(dss.Tables[0].Rows[0]["LOOSE_PACKETS"].ToString());
                    NO_CONTAINERS = dt.Trim(dss.Tables[0].Rows[0]["NO_CONTAINERS"].ToString());

                    ANNEX_SEA_FAC_STUFFED = dt.Trim(dss.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString());
                    ANNEX_SEA_SAMPLE_ACCOM = dt.Trim(dss.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString());
                    ANNEX_SEA_SEAL_TYPE = dt.Trim(dss.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString());

                    if (ANNEX_SEA_SEAL_TYPE == "Agency")
                    {
                        ANNEX_SEA_SEAL_TYPE = "A";
                    }
                    else if (ANNEX_SEA_SEAL_TYPE == "Self")
                    {
                        ANNEX_SEA_SEAL_TYPE = "S";
                    }
                    else if (ANNEX_SEA_SEAL_TYPE == "Warehouse")
                    {
                        ANNEX_SEA_SEAL_TYPE = "W";
                    }

                    if (NO_CONTAINERS == "")
                    {
                        NO_CONTAINERS = "0";
                    }

                }
                else if (TRANSPORT_MODE == "Land")
                {
                    LOOSE_PACKETS = dt.Trim(dss.Tables[0].Rows[0]["LOOSE_PACKETS"].ToString());
                    NO_CONTAINERS = dt.Trim(dss.Tables[0].Rows[0]["NO_CONTAINERS"].ToString());

                    ANNEX_SEA_FAC_STUFFED = dt.Trim(dss.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString());
                    ANNEX_SEA_SAMPLE_ACCOM = dt.Trim(dss.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString());
                    ANNEX_SEA_SEAL_TYPE = dt.Trim(dss.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString());

                    if (ANNEX_SEA_SEAL_TYPE == "Agency")
                    {
                        ANNEX_SEA_SEAL_TYPE = "A";
                    }
                    else if (ANNEX_SEA_SEAL_TYPE == "Self")
                    {
                        ANNEX_SEA_SEAL_TYPE = "S";
                    }
                    else if (ANNEX_SEA_SEAL_TYPE == "Warehouse")
                    {
                        ANNEX_SEA_SEAL_TYPE = "W";
                    }
                    if (NO_CONTAINERS == "")
                    {
                        NO_CONTAINERS = "0";
                    }

                }
                else
                {
                    LOOSE_PACKETS = "";
                    NO_CONTAINERS = "";
                    ANNEX_SEA_FAC_STUFFED = "";
                    ANNEX_SEA_SAMPLE_ACCOM = "";
                    ANNEX_SEA_SEAL_TYPE = "";

                }


                if (TRANSPORT_MODE == "Air")
                {
                    ANNEX_AIR_MAWB_NO = dt.Trim(dss.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString());
                    ANNEX_AIR_HAWB_NO = dt.Trim(dss.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString());
                }
                else
                {
                    ANNEX_AIR_MAWB_NO = "";
                    ANNEX_AIR_HAWB_NO = "";
                }
                Get_Admin_Master_Codes();
            }
        }

        else if (is_Annexure_Mode == 2)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                //JOBNO = dss.Tables[0].Rows[0]["JOBNO"].ToString();
                //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//
                //string SB_dt = dss.Tables[0].Rows[0]["SB_DATE"].ToString();
                //if (SB_dt == "01/01/1900" || SB_dt == "19000101")
                //{
                //    SB_dt = "";
                //}
                //SB_NO = dss.Tables[0].Rows[0]["SB_NO"].ToString();
                //SB_DATE = SB_dt;
                //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//
                JOBDATE = dt.Trim(dss.Tables[0].Rows[0]["JOBDATE"].ToString().Replace("19000101", ""));
                DDMMYY_JOBDATE = dt.Trim(dss.Tables[0].Rows[0]["JOBDT_DDMMYY"].ToString().Replace("010100", ""));

                TRANSPORT_MODE = dt.Trim(dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString());

                CUSTOMS_HOUSE = dt.Trim(dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString());

                SB_TYPE = dt.Trim(dss.Tables[0].Rows[0]["SB_TYPE"].ToString());

                //EXPORTER_NAME = dt.Trim(dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString());
                EXPORTER_NAME = dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();

                BRANCH_NO = dt.Trim(dss.Tables[0].Rows[0]["BRANCH_NO"].ToString());
                IEC_NO = dt.Trim(dss.Tables[0].Rows[0]["IEC_NO"].ToString());
                ADDRESS1 = dt.Trim(dss.Tables[0].Rows[0]["ADDRESS1"].ToString());
                ADDRESS2 = dt.Trim(dss.Tables[0].Rows[0]["ADDRESS2"].ToString());
                ADDRESS3 = dt.Trim(dss.Tables[0].Rows[0]["ADDRESS3"].ToString());
                ADDRESS4 = dt.Trim(dss.Tables[0].Rows[0]["ADDRESS4"].ToString());
                ADDRESS5 = dt.Trim(dss.Tables[0].Rows[0]["ADDRESS5"].ToString());

                TYPE_OF_EXPORTER = dt.Trim(dss.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString());

                ADCODE = dt.Trim(dss.Tables[0].Rows[0]["ADCODE"].ToString());
                if (ADCODE != "")
                {
                    ADCODE = ADCODE.Substring(0, 7);
                }

                BANK_ACCOUNT = dt.Trim(dss.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString());
                DRAWBACK_ACCOUNT = dt.Trim(dss.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString());
                //CONSIGNEE_NAME = dt.Trim_Single_Quote(dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString());
                CONSIGNEE_NAME = dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                CONSIGNEE_ADD1 = dt.Trim(dss.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString());

                CONSIGNEE_ADD2 = dt.Trim(dss.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString());

                //SECTION46_DESC = dss.Tables[0].Rows[0]["SECTION46_DESC"].ToString();

                CONSIGNEE_ADD3 = dt.Trim(dss.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString());

                //FIRSTCHECK_DESC = dss.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString();

                CONSIGNEE_ADD4 = dt.Trim(dss.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString());

                //GREEN_CHANNEL_DESC = dss.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString();

                CONSIGNEE_ADD5 = dt.Trim(dss.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString());

                //KACHHA_BE_DESC = dss.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString();

                COUNTRY_DISCHARGE = dt.Trim(dss.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString());

                //SECTION48_DESC= dss.Tables[0].Rows[0]["SECTION48_DESC"].ToString();

                PORT_DISCHARGE = dt.Trim(dss.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString());

                COUNTRY_FINAL_DEST = dt.Trim(dss.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString());
                PORT_FINAL_DEST = dt.Trim(dss.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString());
                STATE_OF_EXPORT = dt.Trim(dss.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString());
                NFEI = dt.Trim(dss.Tables[0].Rows[0]["NFEI"].ToString());
                NFEI_TYPE = dt.Trim(dt.Split("-", dss.Tables[0].Rows[0]["NFEI_TYPE"].ToString()));

                RBI_WAIVER_NO = dt.Trim(dss.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString());
                RBI_WAIVER_DATE = dt.Trim(dss.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString().Replace("19000101", ""));
                MARKS_NO = dt.Trim(dss.Tables[0].Rows[0]["MARKS_NO"].ToString().Replace("\r\n", " "));

                GSTN_TYPE = dt.Trim(dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString());
                GSTN_ID = dt.Trim(dss.Tables[0].Rows[0]["GSTN_ID"].ToString());

                JOB_STATUS = dss.Tables[0].Rows[0]["JOB_STATUS"].ToString();
                Session.Remove("JOB_LOCK");
                Session["JOB_LOCK"] = JOB_STATUS;

                GROSS_WEIGHT = "";
                UNIT_CODE = "";
                NET_WEIGHT = "";
                NATURE_OF_CARGO = "";
                MARKS_NOS = "";
                TOTAL_PACKAGES = "";
                ROTATION_NO = "";
                ROTATION_DATE = "";
                LOOSE_PACKETS = "";
                NO_CONTAINERS = "";
                ANNEX_SEA_FAC_STUFFED = "";
                ANNEX_SEA_SAMPLE_ACCOM = "";
                ANNEX_AIR_MAWB_NO = "";
                ANNEX_AIR_HAWB_NO = "";

                Get_Admin_Master_Codes();
            }
        }

       
        JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
        string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

        sw.WriteLine("<TABLE>SB");
        sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + "" + ch + "" + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + TYPE_OF_EXPORTER + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + CUSTOMS_HOUSE + ch + PORT_DISCHARGE + ch + COUNTRY_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + PORT_FINAL_DEST + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + GSTN_ID);

    }
      

    
    private void SupportingDocs()
    {
        DataSet ds_supp = new DataSet();
        setdata();

        ds_supp = dss;
        
        if (ds_supp.Tables[0].Rows.Count > 0)
        {
            int sws_supp = 0;
            int SERIAL_NO = 1;
            //sw.WriteLine("<TABLE>SUPPORTINGDOCS");
            sw.WriteLine("<TABLE>Supportingdocs");
            while (ds_supp.Tables[0].Rows.Count > sws_supp)
            {
                UNIQUE_DOC_NUMBER = "";

                INVOICE_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ITEM_SLNO"].ToString());            
               
                UNIQUE_DOC_NUMBER = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["UNIQUE_DOC_NUMBER"].ToString());
                DOC_TYPE_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_TYPE_CODE"].ToString());
                DOC_ISSUING_PARTY_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_CODE"].ToString());
                DOC_ISSUING_PARTY_NAME_ADD1 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString());
                DOC_ISSUING_PARTY_NAME_ADD2 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString());

                DOC_ISSUING_PARTY_CITY = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_CITY"].ToString());
                DOC_ISSUING_PARTY_PIN = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_PIN"].ToString());
                DOC_REF_NUMBER = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_REF_NUMBER"].ToString());
                PLACE_OF_ISSUE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["PLACE_OF_ISSUE"].ToString());
                DOC_ISSUE_DATE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUE_DATE"].ToString().Replace("19000101", ""));
                DOC_EXPIRY_DATE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_EXPIRY_DATE"].ToString().Replace("19000101", ""));
                BENEFICIARY_PARTY_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_CODE"].ToString());

                BENEFICIARY_PARTY_ADDRESS1 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_ADDRESS1"].ToString());
                BENEFICIARY_PARTY_ADDRESS2 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_ADDRESS2"].ToString());
                BENEFICIARY_PARTY_CITY = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_CITY"].ToString());
                BENEFICIARY_PARTY_PIN = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_PIN"].ToString());
                FILE_TYPE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["FILE_TYPE"].ToString());

                SUP_DOC_SERIAL_NO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SLNO"].ToString());

                DOC_ISSUING_PARTY_NAME = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME"].ToString());
                BENEFICIARY_PARTY_NAME = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_NAME"].ToString());
                SUP_DOC_ICEGATE_ID = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ICEGATE_ID"].ToString());

                if (Connection.COMPANYID() == "1014")
                {
                    SUP_DOC_ICEGATE_ID = "";
                }

                if (SUP_DOC_ICEGATE_ID == "")
                {
                    SUP_DOC_ICEGATE_ID = ICEGATE_ID;
                }
                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

                if (UNIQUE_DOC_NUMBER != "")
                {
                    if (ICEGATE_ID.Length > 15)
                    {
                        ICEGATE_ID = ICEGATE_ID.Substring(0, 15);
                    }
                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SUP_DOC_SERIAL_NO + ch + UNIQUE_DOC_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE);
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SERIAL_NO + ch + UNIQUE_DOC_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE + ch + DOC_ISSUING_PARTY_NAME + ch + BENEFICIARY_PARTY_NAME + ch + SUP_DOC_ICEGATE_ID);
                }

                
               
                sws_supp++;
                SERIAL_NO++;
            }

        }
    }

    private void Statement()
    {
        DataSet ds_stmt = new DataSet();
        setdata();

        ds_stmt = dss;

        if (ds_stmt.Tables[0].Rows.Count > 0)
        {
            int sws_stmt = 0;
            sw.WriteLine("<TABLE>STATEMENT");
            while (ds_stmt.Tables[0].Rows.Count > sws_stmt)
            {
               
                STMT_TYPE = "";
                INVOICE_SLNO = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["ITEM_SLNO"].ToString());

                STMT_DECLARATION_TYPE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_DECLARATION_TYPE"].ToString());

                STMT_DECLARATION_NUMBER = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_DECLARATION_NUMBER"].ToString());
                STMT_DECLARATION_DATE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_DECLARATION_DATE"].ToString().Replace("19000101", ""));
                STMT_TYPE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_TYPE"].ToString());

                STMT_CODE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_CODE"].ToString());
                STMT_TEXT = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_TEXT"].ToString());

                if (STMT_TYPE != "REM")
                {
                    STMT_TEXT = "";
                }

                STMT_DECLARATION_TYPE = "B";
                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                STMT_DECLARATION_DATE = JOBDATE;
                STMT_DECLARATION_NUMBER = Convert.ToString(sws_stmt + 1);
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

                
                if (STMT_TYPE != "")
                {
                    if (ddl_AmendType.SelectedValue == "A")
                    {
                        sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + "" + ch + "" + ch + STMT_DECLARATION_TYPE + ch + STMT_DECLARATION_NUMBER + ch + STMT_DECLARATION_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                    }
                    else
                    {
                        //sw.WriteLine("S" + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + JOBDATE + ch + STMT_DECLARATION_TYPE + ch + STMT_DECLARATION_NUMBER + ch + STMT_DECLARATION_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                        sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + STMT_DECLARATION_TYPE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                    }
                }

                sws_stmt++;
            }
        }
    }

    private void INVOICE()
    {
        int i = 0;
        setdata();
        if (dss.Tables[0].Rows.Count > 0)
        {
            while (dss.Tables[0].Rows.Count > i)
            {
                sw.WriteLine("<TABLE>INVOICE");

                INVOICE_SLNO = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_SLNO"].ToString());
                INVOICE_NO = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_NO"].ToString());
                INVOICE_DATE = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_DATE"].ToString().Replace("19000101", ""));
                PAYMENT_METHOD = dt.Trim(dss.Tables[0].Rows[i]["PAYMENT_METHOD"].ToString());
                PERIOD_PAYMENT = dt.Trim(dss.Tables[0].Rows[i]["PERIOD_PAYMENT"].ToString());
                INVOICE_VALUE = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_VALUE"].ToString());
                INVOICE_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["INVOICE_CURRENCY"].ToString());
                EXCHANGE_RATE = dt.Trim(dss.Tables[0].Rows[i]["EXCHANGE_RATE"].ToString());
                CONTRACT_NO = dt.Trim(dss.Tables[0].Rows[i]["CONTRACT_NO"].ToString());
                TERMS = dt.Trim(dss.Tables[0].Rows[i]["TERMS"].ToString());
                BUYER = dt.Trim(dss.Tables[0].Rows[i]["BUYER"].ToString());

                BUYER_NAME = dt.Trim(dss.Tables[0].Rows[i]["BUYER_NAME"].ToString().Replace("amp);", ""));
                BUYER_ADDRESS = dt.Trim(dss.Tables[0].Rows[i]["BUYER_ADDRESS"].ToString().Replace("amp);", ""));
                BUYER_ADDRESS1 = dt.Trim(dss.Tables[0].Rows[i]["BUYER_ADDRESS1"].ToString().Replace("amp);", ""));
                BUYER_ADDRESS2 = dt.Trim(dss.Tables[0].Rows[i]["BUYER_ADDRESS2"].ToString().Replace("amp);", ""));
                BUYER_ADDRESS3 = dt.Trim(dss.Tables[0].Rows[i]["BUYER_ADDRESS3"].ToString().Replace("amp);", ""));
                BUYER_ADDRESS4 = dt.Trim(dss.Tables[0].Rows[i]["BUYER_ADDRESS4"].ToString());
                COMMISSION_RATE = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["COMMISSION_RATE"].ToString()));
                COMMISSION_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["COMMISSION_CHARGES"].ToString()));
                COMMISSION_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["COMMISSION_CURRENCY"].ToString());
                FOB_RATE = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["FOB_RATE"].ToString()));

                FOB_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["FOB_CHARGES"].ToString()));
                FOB_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["FOB_CURRENCY"].ToString());
                PACKMISC_RATE = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["PACKMISC_RATE"].ToString()));
                PACKMISC_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["PACKMISC_CHARGES"].ToString()));
                PACKMISC_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["PACKMISC_CURRENCY"].ToString());
                OTHER_DEDUCTION_RATE = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["OTHER_DEDUCTION_RATE"].ToString()));
                OTHER_DEDUCTION_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["OTHER_DEDUCTION_CHARGES"].ToString()));
                OTHER_DEDUCTION_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["OTHER_DEDUCTION_CURRENCY"].ToString());
                FREIGHT_RATE = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["FREIGHT_RATE"].ToString()));
                FREIGHT_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["FREIGHT_CHARGES"].ToString()));
                FREIGHT_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["FREIGHT_CURRENCY"].ToString());
                INSURANCE_RATE = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["INSURANCE_RATE"].ToString()));
                INSURANCE_CHARGES = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["INSURANCE_CHARGES"].ToString()));
                INSURANCE_CURRENCY = dt.Trim(dss.Tables[0].Rows[i]["INSURANCE_CURRENCY"].ToString());
                WHEATHER_UNIT_PRICE = dt.Trim(dss.Tables[0].Rows[i]["WHEATHER_UNIT_PRICE"].ToString());

                THIRDPARTY_NAME = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["THIRDPARTY_NAME"].ToString()));
                THIRDPARTY_ADD1 = dt.Trim(dss.Tables[0].Rows[i]["THIRDPARTY_ADD1"].ToString());
                THIRDPARTY_ADD2 = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["THIRDPARTY_ADD2"].ToString()));
                THIRDPARTY_CITY = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["THIRDPARTY_CITY"].ToString()));
                T_PARTY_COUNTRY_SUB_DIV = dt.Trim(dss.Tables[0].Rows[i]["T_PARTY_COUNTRY_SUB_DIV"].ToString());
                T_PARTY_COUNTRY_CODE = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["T_PARTY_COUNTRY_CODE"].ToString()));
                T_PARTY_PIN = dt.Get_Nullval(dt.Trim(dss.Tables[0].Rows[i]["T_PARTY_PIN"].ToString()));
                AUTHORIZED_ECONOMIC_OPERATOR_CODE = dt.Trim(dss.Tables[0].Rows[i]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString());
                A_E_O_COUNTRY = dt.Trim(dss.Tables[0].Rows[i]["A_E_O_COUNTRY"].ToString());
                AUTHORIZED_ECONOMIC_OPERATOR = dt.Trim(dss.Tables[0].Rows[i]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString());
                TERMS_PLACE = dt.Trim(dss.Tables[0].Rows[i]["TERMS_PLACE"].ToString());

                if (BUYER_NAME == "SAME AS CONSIGNEE")
                {
                    BUYER_ADDRESS = "`";
                }

                if (COMMISSION_RATE != "0.00" & COMMISSION_RATE != "0.0" && COMMISSION_RATE != "0" && COMMISSION_RATE != "")
                {
                    COMMISSION_CHARGES = "";
                    //COMMISSION_CURRENCY = "";
                }

                if (FOB_RATE != "0.00" & FOB_RATE != "0.0" && FOB_RATE != "0" && FOB_RATE != "")
                {
                    FOB_CHARGES = "";
                    //FOB_CURRENCY = "";
                }

                //if (PACKMISC_RATE != "0.00" & PACKMISC_RATE != "0.0" && PACKMISC_RATE != "0" && PACKMISC_RATE != "")
                //{
                //    PACKMISC_CHARGES = "";
                //    //PACKMISC_CURRENCY = "";
                //}

                if (OTHER_DEDUCTION_RATE != "0.00" & OTHER_DEDUCTION_RATE != "0.0" && OTHER_DEDUCTION_RATE != "0" && OTHER_DEDUCTION_RATE != "")
                {
                    OTHER_DEDUCTION_CHARGES = "";
                    //OTHER_DEDUCTION_CURRENCY = "";
                }


                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();
                

               // sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + Fn_JOBNO(ddlJobNo.SelectedValue.ToString()) + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + INVOICE_NO + ch + INVOICE_DATE + ch + INVOICE_CURRENCY + ch + TERMS + ch + BUYER_NAME + ch + BUYER_ADDRESS + ch + BUYER_ADDRESS1 + ch + BUYER_ADDRESS2 + ch + BUYER_ADDRESS3 + ch + FREIGHT_CURRENCY + ch + FREIGHT_CHARGES + ch + INSURANCE_RATE + ch + INSURANCE_CURRENCY + ch + INSURANCE_CHARGES + ch + COMMISSION_RATE + ch + COMMISSION_CURRENCY + ch + COMMISSION_CHARGES + ch + FOB_RATE + ch + FOB_CURRENCY + ch + FOB_CHARGES + ch + OTHER_DEDUCTION_RATE + ch + OTHER_DEDUCTION_CURRENCY + ch + OTHER_DEDUCTION_CHARGES + ch + WHEATHER_UNIT_PRICE + ch + PACKMISC_CHARGES + ch + CONTRACT_NO + ch + PAYMENT_METHOD + ch + PERIOD_PAYMENT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
              //  sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + INVOICE_NO + ch + INVOICE_DATE + ch + INVOICE_CURRENCY + ch + TERMS + ch + BUYER_NAME + ch + BUYER_ADDRESS + ch + BUYER_ADDRESS1 + ch + BUYER_ADDRESS2 + ch + BUYER_ADDRESS3 + ch + FREIGHT_CURRENCY + ch + FREIGHT_CHARGES + ch + INSURANCE_RATE + ch + INSURANCE_CURRENCY + ch + INSURANCE_CHARGES + ch + COMMISSION_RATE + ch + COMMISSION_CURRENCY + ch + COMMISSION_CHARGES + ch + FOB_RATE + ch + FOB_CURRENCY + ch + FOB_CHARGES + ch + OTHER_DEDUCTION_RATE + ch + OTHER_DEDUCTION_CURRENCY + ch + OTHER_DEDUCTION_CHARGES + ch + WHEATHER_UNIT_PRICE + ch + PACKMISC_CHARGES + ch + CONTRACT_NO + ch + PAYMENT_METHOD + ch + PERIOD_PAYMENT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                sw.WriteLine(Amendment_Type + ch + CUSTOMS_HOUSE + ch + "" + ch + "" + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + INVOICE_NO + ch + INVOICE_DATE + ch + INVOICE_CURRENCY + ch + TERMS + ch + BUYER_NAME + ch + BUYER_ADDRESS + ch + BUYER_ADDRESS1 + ch + BUYER_ADDRESS2 + ch + BUYER_ADDRESS3 + ch + FREIGHT_CURRENCY + ch + FREIGHT_CHARGES + ch + INSURANCE_RATE + ch + INSURANCE_CURRENCY + ch + INSURANCE_CHARGES + ch + COMMISSION_RATE + ch + COMMISSION_CURRENCY + ch + COMMISSION_CHARGES + ch + FOB_RATE + ch + FOB_CURRENCY.ToUpper() + ch + FOB_CHARGES + ch + OTHER_DEDUCTION_RATE + ch + OTHER_DEDUCTION_CURRENCY + ch + OTHER_DEDUCTION_CHARGES + ch + WHEATHER_UNIT_PRICE + ch + PACKMISC_CHARGES + ch + CONTRACT_NO + ch + PAYMENT_METHOD + ch + PERIOD_PAYMENT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + THIRDPARTY_NAME + ch + THIRDPARTY_ADD1 + ch + THIRDPARTY_ADD2 + ch + THIRDPARTY_CITY + ch + T_PARTY_COUNTRY_SUB_DIV + ch + T_PARTY_COUNTRY_CODE + ch + T_PARTY_PIN + ch + AUTHORIZED_ECONOMIC_OPERATOR_CODE + ch + A_E_O_COUNTRY + ch + AUTHORIZED_ECONOMIC_OPERATOR + ch + TERMS_PLACE);
                i++;

             
                //if (ddl_AmendType.SelectedValue == "S")
                //{
                //    sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + INVOICE_DATE + ch + OTHER_PURCHASE_ORDER + ch + OTHER_PURCHASE_ORDER_DATE + ch + OTHER_CONTRACT_NO + ch + OTHER_CONTRACT_DATE + ch + OTHER_LOC_NO + ch + OTHER_LOC_DATE + ch + SVB_REF_NO + ch + SVB_REF_DATE + ch + SVB_ASSESABLE_RATE + ch + SVB_DUTY_RATE + ch + SVB_LOADING_ON + ch + SVB_ASSESABLE_STATUS + ch + SVB_DUTY_STATUS + ch + SVB_CUSTOM_HOUSE + ch + SUPPLIER_NAME + ch + SUPPLIER_ADDRESS + ch + SUPPLIER_ADDRESS1 + ch + SUPPLIER_ADDRESS2 + ch + SUPPLIER_COUNTRY_NAME + ch + SUPPLIER_COUNTRY_PINCODE + ch + SELLER_NAME + ch + SELLER_ADDRESS + ch + SELLER_ADDRESS1 + ch + SELLER_ADDRESS2 + ch + SELLER_COUNTRY_NAME + ch + SELLERCOUNTRY_PINCODE + ch + BROKER_NAME + ch + BROKER_ADDRESS + ch + BROKER_ADDRESS1 + ch + BROKER_ADDRESS2 + ch + BROKER_COUNTRY_NAME + ch + BROKER_COUNTRY_PINCODE + ch + INVOICE_VALUE + ch + TERMS + ch + INVOICE_CURRENCY + ch + Nature_of_Discount + ch + MIS_DISCOUNT_RATE + ch + MIS_DISCOUNT_CHARGES + ch + MIS_HIGHSEASALE_RATE + ch + MIS_HIGHSEASALE_CHARGES + ch + MIS_FREIGHT_CHARGES + ch + MIS_FREIGHT_RATE + ch + Freight_Actual + ch + MIS_FREIGHT_CURRENCY + ch + MIS_INSURANCE_CHARGES + ch + MIS_INSURANCE_RATE + ch + MIS_INSURANCE_CURRENCY + ch + MIS_CHARGES + ch + MIS_CURRENCY + ch + MIS_RATE + ch + Landing_Rate + ch + MIS_LOADING_CHARGES + ch + MIS_LOADING_CURRENCY + ch + MIS_LOADING_RATE + ch + MIS_AGENCY_CHARGES + ch + MIS_AGENCY_CURRENCY + ch + MIS_AGENCY_RATE + ch + OTHER_NATURE_OF_TRANSACTION + ch + OTHER_TERMS_OF_PAYMENT + ch + Conditions_Attached_Sale1 + ch + Conditions_Attached_Sale2 + ch + Conditions_Attached_Sale3 + ch + Conditions_Attached_Sale4 + ch + Conditions_Attached_Sale5 + ch + OTHER_VALUATION_METHOD + ch + INVOICE_NO + ch + Other_Relevant_Information + ch + TERMS_PLACE + ch + THIRDPARTY_NAME + ch + THIRDPARTY_ADD1 + ch + THIRDPARTY_ADD2 + ch + THIRDPARTY_CITY + ch + T_PARTY_COUNTRY_SUB_DIV + ch + T_PARTY_COUNTRY_CODE + ch + T_PARTY_PIN + ch + AUTHORIZED_ECONOMIC_OPERATOR_CODE + ch + A_E_O_COUNTRY + ch + AUTHORIZED_ECONOMIC_OPERATOR + ch + WHETHER_BUYER_SELLER_RELATED);
                //}
                //else if (ddl_AmendType.SelectedValue == "A")
                //{
                //    sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + INVOICE_DATE + ch + OTHER_PURCHASE_ORDER + ch + OTHER_PURCHASE_ORDER_DATE + ch + OTHER_CONTRACT_NO + ch + OTHER_CONTRACT_DATE + ch + OTHER_LOC_NO + ch + OTHER_LOC_DATE + ch + SVB_REF_NO + ch + SVB_REF_DATE + ch + SVB_ASSESABLE_RATE + ch + SVB_DUTY_RATE + ch + SVB_LOADING_ON + ch + SVB_ASSESABLE_STATUS + ch + SVB_DUTY_STATUS + ch + SVB_CUSTOM_HOUSE + ch + SUPPLIER_NAME + ch + SUPPLIER_ADDRESS + ch + SUPPLIER_ADDRESS1 + ch + SUPPLIER_ADDRESS2 + ch + SUPPLIER_COUNTRY_NAME + ch + SUPPLIER_COUNTRY_PINCODE + ch + SELLER_NAME + ch + SELLER_ADDRESS + ch + SELLER_ADDRESS1 + ch + SELLER_ADDRESS2 + ch + SELLER_COUNTRY_NAME + ch + SELLERCOUNTRY_PINCODE + ch + BROKER_NAME + ch + BROKER_ADDRESS + ch + BROKER_ADDRESS1 + ch + BROKER_ADDRESS2 + ch + BROKER_COUNTRY_NAME + ch + BROKER_COUNTRY_PINCODE + ch + INVOICE_VALUE + ch + TERMS + ch + INVOICE_CURRENCY + ch + Nature_of_Discount + ch + MIS_DISCOUNT_RATE + ch + MIS_DISCOUNT_CHARGES + ch + MIS_HIGHSEASALE_RATE + ch + MIS_HIGHSEASALE_CHARGES + ch + MIS_FREIGHT_CHARGES + ch + MIS_FREIGHT_RATE + ch + Freight_Actual + ch + MIS_FREIGHT_CURRENCY + ch + MIS_INSURANCE_CHARGES + ch + MIS_INSURANCE_RATE + ch + MIS_INSURANCE_CURRENCY + ch + MIS_CHARGES + ch + MIS_CURRENCY + ch + MIS_RATE + ch + Landing_Rate + ch + MIS_LOADING_CHARGES + ch + MIS_LOADING_CURRENCY + ch + MIS_LOADING_RATE + ch + MIS_AGENCY_CHARGES + ch + MIS_AGENCY_CURRENCY + ch + MIS_AGENCY_RATE + ch + OTHER_NATURE_OF_TRANSACTION + ch + OTHER_TERMS_OF_PAYMENT + ch + Conditions_Attached_Sale1 + ch + Conditions_Attached_Sale2 + ch + Conditions_Attached_Sale3 + ch + Conditions_Attached_Sale4 + ch + Conditions_Attached_Sale5 + ch + OTHER_VALUATION_METHOD + ch + INVOICE_NO + ch + Other_Relevant_Information + ch + TERMS_PLACE + ch + THIRDPARTY_NAME + ch + THIRDPARTY_ADD1 + ch + THIRDPARTY_ADD2 + ch + THIRDPARTY_CITY + ch + T_PARTY_COUNTRY_SUB_DIV + ch + T_PARTY_COUNTRY_CODE + ch + T_PARTY_PIN + ch + AUTHORIZED_ECONOMIC_OPERATOR_CODE + ch + A_E_O_COUNTRY + ch + AUTHORIZED_ECONOMIC_OPERATOR + ch + WHETHER_BUYER_SELLER_RELATED);
                //}
                //else if (ddl_AmendType.SelectedValue == "D")
                //{
                //    sw.WriteLine(ddl_AmendType.SelectedValue + ch + txtCustomsHouse.Text + ch + ViewState["AmendJobno"].ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "" + ch + "");
                //}
                //else
                //{
                //}

            }
        }
    }

    private void STR()
    {
        int d = 0;
        DataView str_view = dss.Tables[0].DefaultView;
        str_view.RowFilter = "NOT ITEM_STR_CODE = '' ";
        DataTable str_table = str_view.ToTable();
        string SRNO = "";

        if (str_table.Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>STR");
            while (str_table.Rows.Count > d)
            {
                INVOICE_SLNO = dt.Trim(str_table.Rows[d]["INVOICE_SLNO"].ToString());

                ITEM_SLNO = dt.Trim(str_table.Rows[d]["ITEM_SLNO"].ToString());

                ITEM_STR_CODE = dt.Trim(str_table.Rows[d]["ITEM_STR_CODE"].ToString());

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + "" + ch + "" + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + ITEM_STR_CODE + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                d++;
            }
        }
    }

    private void ITEMACCESS()
    {
        int ac = 0;

        DataView view_accessdesc = dss.Tables[0].DefaultView;

        view_accessdesc.RowFilter = "ITEM_ACCESSORIES_DESC <> ''";
        DataSet ds_accessdesc = new DataSet();
        ds_accessdesc.Tables.Add(view_accessdesc.ToTable());

        if (ds_accessdesc.Tables[0].Rows.Count > 0)
        {
            ITEM_ACCESSORIES_DESC = dt.Trim(ds_accessdesc.Tables[0].Rows[0]["ITEM_ACCESSORIES_DESC"].ToString());

        }

        if (ITEM_ACCESSORIES_DESC != "")
        {
            sw.WriteLine("<TABLE>ITEMACCESS");
            while (ds_accessdesc.Tables[0].Rows.Count > ac)
            {
                INVOICE_SLNO = dt.Trim(ds_accessdesc.Tables[0].Rows[ac]["INVOICE_SLNO"].ToString());
                INVOICE_NO = dt.Trim(ds_accessdesc.Tables[0].Rows[ac]["INVOICE_NO"].ToString());
                ITEM_SLNO = dt.Trim(ds_accessdesc.Tables[0].Rows[ac]["ITEM_SLNO"].ToString());

                ITEM_ACCESSORIES_DESC = dt.Trim(ds_accessdesc.Tables[0].Rows[ac]["ITEM_ACCESSORIES_DESC"].ToString());

                if (ITEM_ACCESSORIES_DESC != "")
                {
                    //    sw.WriteLine("<TABLE>ITEMACCESS");
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + "" + ch + "" + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_ACCESSORIES_DESC);
                }
                ac++;
            }
        }
    }

    private void ITEM()
    {
        int j = 0;
        setdata();
        if (dss.Tables[0].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>ITEM");
            
            while (dss.Tables[0].Rows.Count > j)
            {
                INVOICE_SLNO = dt.Trim(dss.Tables[0].Rows[j]["INVOICE_SLNO"].ToString());
                INVOICE_NO = dt.Trim(dss.Tables[0].Rows[j]["INVOICE_NO"].ToString());
                ITEM_SLNO = dt.Trim(dss.Tables[0].Rows[j]["ITEM_SLNO"].ToString());
                ITEM_DESCRIPTION1 = dt.Trim(dss.Tables[0].Rows[j]["ITEM_DESCRIPTION1"].ToString());
                ITEM_DESCRIPTION2 = dt.Trim(dss.Tables[0].Rows[j]["ITEM_DESCRIPTION2"].ToString());
                ITEM_DESCRIPTION3 = dt.Trim(dss.Tables[0].Rows[j]["ITEM_DESCRIPTION3"].ToString());
                RITCNO = dt.Trim(dss.Tables[0].Rows[j]["RITCNO"].ToString());
                ITEM_QTY = dt.Trim(dss.Tables[0].Rows[j]["ITEM_QTY"].ToString());
                ITEM_QTY_CODE = dt.Trim(dss.Tables[0].Rows[j]["ITEM_QTY_CODE"].ToString());
                ITEM_UNIT_PRICE = dt.Trim(dss.Tables[0].Rows[j]["ITEM_UNIT_PRICE"].ToString());
                ITEM_PER = dt.Trim(dss.Tables[0].Rows[j]["ITEM_PER"].ToString());
                ITEM_AMOUNT = dt.Trim(dss.Tables[0].Rows[j]["ITEM_AMOUNT"].ToString());
                ITEM_PMVVALUE = dt.Trim(dss.Tables[0].Rows[j]["ITEM_PMVVALUE"].ToString());
                PMV_PER_UNIT = dt.Trim(dss.Tables[0].Rows[j]["PMV_PER_UNIT"].ToString());
                PMV_METHOD = dt.Trim(dss.Tables[0].Rows[j]["PMV_METHOD"].ToString());
                
                ITEM_SCHEME_CODE = dt.Trim(dss.Tables[0].Rows[j]["ITEM_SCHEME_CODE"].ToString());
                ITEM_ACCESSORIES_DESC = dt.Trim(dss.Tables[0].Rows[j]["ITEM_ACCESSORIES_DESC"].ToString());
                ITEM_AR4_NO = dt.Trim(dss.Tables[0].Rows[j]["ITEM_AR4_NO"].ToString());
                ITEM_AR4_DATE = dt.Trim(dss.Tables[0].Rows[j]["ITEM_AR4_DATE"].ToString().Replace("19000101", ""));
                ITEM_COMMISSION_RATE = dt.Trim(dss.Tables[0].Rows[j]["ITEM_COMMISSION_RATE"].ToString());
                ITEM_DIVISION = dt.Trim(dss.Tables[0].Rows[j]["ITEM_DIVISION"].ToString());
                ITEM_RANGE = dt.Trim(dss.Tables[0].Rows[j]["ITEM_RANGE"].ToString());
                ITEM_REMARKS = dt.Trim(dss.Tables[0].Rows[j]["ITEM_REMARKS"].ToString());
                ITEM_IECCODE = dt.Trim(dss.Tables[0].Rows[j]["ITEM_IECCODE"].ToString());
                ITEM_EXPORTER_NAME = dt.Trim(dss.Tables[0].Rows[j]["ITEM_EXPORTER_NAME"].ToString());

                BR_SLNO = dt.Trim(dss.Tables[0].Rows[j]["BR_SLNO"].ToString());
                ITEM_ADDRESS1 = dt.Trim(dss.Tables[0].Rows[j]["ADDRESS1"].ToString());
                ITEM_ADDRESS2 = dt.Trim(dss.Tables[0].Rows[j]["ADDRESS2"].ToString());
                ITEM_ADDRESS3 = dt.Trim(dss.Tables[0].Rows[j]["ADDRESS3"].ToString());
                ITEM_ADDRESS4 = dt.Trim(dss.Tables[0].Rows[j]["ADDRESS4"].ToString());
                ITEM_ADDRESS5 = dt.Trim(dss.Tables[0].Rows[j]["ADDRESS5"].ToString());
                ITEM_STR_CODE = dt.Trim(dss.Tables[0].Rows[j]["ITEM_STR_CODE"].ToString());
                REWARD_POINTS = dt.Trim(dss.Tables[0].Rows[j]["REWARD_POINTS"].ToString());


                MANUFACTURER_PRODUCER = dt.Trim(dss.Tables[0].Rows[j]["MANUFACTURER_PRODUCER"].ToString());
                M_P_GROWER_CODE = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_CODE"].ToString());
                M_P_GROWER_ADD1 = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_ADD1"].ToString());
                M_P_GROWER_ADD2 = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_ADD2"].ToString());
                M_P_GROWER_CITY = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_CITY"].ToString());
                M_P_GROWER_COUNTRY_SUBDIV = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_COUNTRY_SUBDIV"].ToString());
                M_P_GROWER_PIN = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_PIN"].ToString());
                M_P_GROWER_COUNTRY = dt.Trim(dss.Tables[0].Rows[j]["M_P_GROWER_COUNTRY"].ToString());
                SOURCE_STATE = dt.Trim(dss.Tables[0].Rows[j]["SOURCE_STATE"].ToString());
                TRANSIT_COUNTRY = dt.Trim(dss.Tables[0].Rows[j]["TRANSIT_COUNTRY"].ToString());
                ACCESSORY_STATUS = dt.Trim(dss.Tables[0].Rows[j]["ACCESSORY_STATUS"].ToString());
                HAWB_NO = dt.Trim(dss.Tables[0].Rows[j]["HAWB_NO"].ToString());
                TOTAL_PKGS = dt.Trim(dss.Tables[0].Rows[j]["TOTAL_PKGS"].ToString());
                ENDUSE_ITEM = dt.Trim(dss.Tables[0].Rows[j]["ENDUSE_ITEM"].ToString());
                IGST_PAYMENT = dt.Trim(dss.Tables[0].Rows[j]["IGST_PAYMENT"].ToString());
                TAXABLE_VALUE = dt.Trim(dss.Tables[0].Rows[j]["TAXABLE_VALUE"].ToString());
                IGST_AMT = dt.Trim(dss.Tables[0].Rows[j]["IGST_AMT"].ToString());
                RODTEP = dt.Trim(dss.Tables[0].Rows[j]["RODTEP"].ToString());



                string val = dt.Trim(dss.Tables[0].Rows[j]["PMV_VALUE"].ToString());

                if (Session["COMPANY_ID"].ToString() == "116")
                {
                    if (Connection.Current_Branch() == "ACC, Kolkata" || Connection.Current_Branch() == "CusHouse, Kolkata" || Connection.Current_Branch() == "ICD,Petrapole")
                    {
                        val = dt.Trim(dss.Tables[0].Rows[j]["ITEM_PMVVALUE"].ToString());
                    }
                }
                //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//
                else if (Session["COMPANY_ID"].ToString() == "233" || Session["COMPANY_ID"].ToString() == "442" || Session["COMPANY_ID"].ToString() == "438" || Session["COMPANY_ID"].ToString() == "436" || Session["COMPANY_ID"].ToString() == "443" || Session["COMPANY_ID"].ToString() == "435" || Session["COMPANY_ID"].ToString() == "434" || Session["COMPANY_ID"].ToString() == "402" || Session["COMPANY_ID"].ToString() == "459" || Session["COMPANY_ID"].ToString() == "444" || Session["COMPANY_ID"].ToString() == "457" || Session["COMPANY_ID"].ToString() == "470" || Session["COMPANY_ID"].ToString() == "477" || Session["COMPANY_ID"].ToString() == "478" || Session["COMPANY_ID"].ToString() == "479" || Session["COMPANY_ID"].ToString() == "488" || Session["COMPANY_ID"].ToString() == "492" || Session["COMPANY_ID"].ToString() == "525" || Session["COMPANY_ID"].ToString() == "538" || Session["COMPANY_ID"].ToString() == "539" || Session["COMPANY_ID"].ToString() == "571")
                {
                    val = dt.Trim(dss.Tables[0].Rows[j]["ITEM_PMVVALUE"].ToString());
                }
                //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//

               

                if (val == "")
                {
                    val = "0.00";
                }

                if (val.Trim() != "" && Convert.ToDouble(val) != 0.00 && Convert.ToDouble(val) != 0)
                {
                    //PMV_VALUE = Convert.ToString(Convert.ToDouble(val) / Convert.ToDouble(ITEM_QTY));
                    PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(val) / Convert.ToDouble(ITEM_QTY), 2).ToString("0.00"));


                    //this line hide by Chithra on 20-01-2020 for ITEM_PER calc wrong - do not (* Multiply) -should be (/- divide) 
                    //PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(PMV_VALUE) * Convert.ToDouble(ITEM_PER), 2).ToString("0.00"));

                    //this line hide by Chithra on 19-06-2020 for DBK value not come in Final Copy sugg.by Bala sir..
                   // PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(PMV_VALUE) / Convert.ToDouble(ITEM_PER), 2).ToString("0.00"));

                    //Again this line enabled on 05-08-2020 for DBK Rate Not Update in Icegate issue-Sugg.by Subbu sir..
                    PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(PMV_VALUE) * Convert.ToDouble(ITEM_PER), 2).ToString("0.00"));

                    if (Convert.ToDouble(PMV_VALUE) == 0.00 || Convert.ToDouble(PMV_VALUE) == 0)
                        PMV_VALUE = "0.01";

                    //PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(val), 1)/ Convert.ToDouble(ITEM_QTY).ToString("0.00"));
                    //string fob = Convert.ToString(Math.Round(val), 1).ToString("0.00"));

                }
                else
                {
                    if (Convert.ToDouble(val) == 0.00 || Convert.ToDouble(val) == 0)
                        PMV_VALUE = "0.01";
                    else
                        PMV_VALUE = "0";
                }


                if (Session["COMPANY_ID"].ToString() == "116")
                {
                    if (Connection.Current_Branch() == "ACC, Kolkata" || Connection.Current_Branch() == "CusHouse, Kolkata" || Connection.Current_Branch() == "ICD,Petrapole")
                    {
                        if (Convert.ToDouble(PMV_VALUE) == 0.01 || Convert.ToDouble(PMV_VALUE) == 0)
                            PMV_VALUE = "0.00";
                    }
                }
                //-------------Implemented on 16Mar2018 For elogix Clients  and eroyal Clients EXCEPTT FrightLog(ERI00525)----------------//
                else if (Session["COMPANY_ID"].ToString() == "233" || Session["COMPANY_ID"].ToString() == "442" || Session["COMPANY_ID"].ToString() == "438" || Session["COMPANY_ID"].ToString() == "436" || Session["COMPANY_ID"].ToString() == "443" || Session["COMPANY_ID"].ToString() == "435" || Session["COMPANY_ID"].ToString() == "434" || Session["COMPANY_ID"].ToString() == "402" || Session["COMPANY_ID"].ToString() == "459" || Session["COMPANY_ID"].ToString() == "444" || Session["COMPANY_ID"].ToString() == "457" || Session["COMPANY_ID"].ToString() == "477" || Session["COMPANY_ID"].ToString() == "478" || Session["COMPANY_ID"].ToString() == "479" || Session["COMPANY_ID"].ToString() == "488" || Session["COMPANY_ID"].ToString() == "492" || Session["COMPANY_ID"].ToString() == "538" || Session["COMPANY_ID"].ToString() == "571")
                {
                    if (Convert.ToDouble(PMV_VALUE) == 0.01 || Convert.ToDouble(PMV_VALUE) == 0)
                        PMV_VALUE = "0.00";
                }
                //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//
                

                //this condition implmtd for Agility on 24-07-2020 sugg by Bala sir..
                if (PMV_METHOD == "Unit" || PMV_METHOD == "PerUnit")
                {
                    PMV_VALUE = PMV_PER_UNIT;
                }

                //Check IS_JOBBING
                /*
                DataView view1 = ds.Tables[5].DefaultView;

                view1.RowFilter = "INVOICE_SLNO = " + INVOICE_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;

                //DataTable table1 = view1.ToTable();
                DataSet dt_UserRights = new DataSet();
                dt_UserRights.Tables.Add(view1.ToTable());

                string NOTIFICATION_NO = "";
                if (dt_UserRights.Tables[0].Rows.Count > 0)
                {
                    NOTIFICATION_NO = dt.Trim(dt_UserRights.Tables[0].Rows[0]["NOTIFICATION_NO"].ToString());
                }
               */
                string NOTIFICATION_NO = "";//15-04-2022

                //Check IS_JOBBING

                //Check IS_ThirdPaty or Rewardpoints

                string IS_ThirdParty = "", Is_Reward = "";
                if (ITEM_EXPORTER_NAME != "")
                {
                    IS_ThirdParty = "Y";
                    ITEM_EXPORTER_NAME_THIRD = ITEM_EXPORTER_NAME;
                }
                else
                    IS_ThirdParty = "N";

                //if (REWARD_POINTS != "")
                //{
                //    Is_Reward = "Y";
                //}
                //else
                //    Is_Reward = "N";
                //Check IS_ThirdPaty or Rewardpoints


                JOBDATE = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();
                string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

               


                if (MANUFACTURER_PRODUCER != "" || M_P_GROWER_CODE != "" || M_P_GROWER_ADD1 != "")
                {
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + "" + ch + "" + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_STATE + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS + ch + ENDUSE_ITEM + ch + HAWB_NO + ch + TOTAL_PKGS + ch + IGST_PAYMENT + ch + TAXABLE_VALUE + ch + IGST_AMT);
                }
                else
                {
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + "" + ch + "" + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_STATE + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS + ch + ENDUSE_ITEM + ch + HAWB_NO + ch + TOTAL_PKGS + ch + IGST_PAYMENT + ch + TAXABLE_VALUE + ch + IGST_AMT);
                }

                j++;
            }
        }
    }

    private void LICENSE()
    {
        int m = 0;
        setdata();
        if (dss.Tables[0].Rows.Count > 0)
        {
            
            sw.WriteLine("<TABLE>LICENCE");
            //while (ds.Tables[11].Rows.Count > mm)
            //{
            //    INVOICE_SLNO = dt.Trim(ds.Tables[11].Rows[mm]["INV_SL_NO"].ToString());
            //    ITEM_SLNO = dt.Trim(ds.Tables[11].Rows[mm]["ITEM_SL_NO"].ToString());
            //    LICENSE_NO = dt.Trim(ds.Tables[11].Rows[mm]["LICENSE_NO"].ToString());
            //    LICENSE_ID = dt.Trim(ds.Tables[11].Rows[mm]["LICENSE_ID"].ToString());

            //    //if (ds.Tables[4].Rows.Count > 0)
            //    //{
            //    //sw.WriteLine("<TABLE>LICENCE");

            //    //-------------------------------------

            //    //j = 0;


            //    DataSet dss = new DataSet();
            //    if (ds.Tables[4].Rows.Count > 0)
            //    {
            //        DataView view = ds.Tables[4].DefaultView;
            //        //view.RowFilter = "LICENSE_NO" + " = '" +LICENSE_NO+ "'";
            //        view.RowFilter = "LICENSE_NO = '" + LICENSE_NO + "' and " + "LICENSE_ID = " + LICENSE_ID;


            //        DataTable table = view.ToTable();

            //        dss.Tables.Add(table);


                    //if (dss.Tables[0].Rows.Count > 0)
                    //{
                   
                    while (dss.Tables[0].Rows.Count > m)
                    {
                        //---------------Modified on 4th Oct 2014-------------------//

                        SCHEME_CODE = dt.Trim(dss.Tables[0].Rows[m]["SCHEME_CODE"].ToString());
                        SCHEME = dt.Trim(dss.Tables[0].Rows[m]["SCHEME"].ToString());
                        LICENSE_R_SL_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_R_SL_NO"].ToString());
                        //LICENSE_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_NO"].ToString());
                        LICENSE_DATE = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_DATE"].ToString().Replace("19000101", ""));

                        LICENSE_E_SL_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_E_SL_NO"].ToString());
                        LICENSE_EXP_QTY = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_EXP_QTY"].ToString());
                        LICENSE_EXP_UNIT = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_EXP_UNIT"].ToString());
                        LICENSE_IMP_ITEM_SL_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_IMP_ITEM_SL_NO"].ToString());
                        LICENSE_IMP_DESC = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_IMP_DESC"].ToString());

                        LICENSE_IMP_QTY = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_IMP_QTY"].ToString());
                        LICENSE_IMP_UNIT = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_IMP_UNIT"].ToString());
                        LICENSE_IMP_TYPE = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_IMP_TYPE"].ToString());

                        //----------------------------------//
                        string SRNO = "";

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + LICENSE_NO + ch + LICENSE_DATE + ch + LICENSE_E_SL_NO + ch + LICENSE_IMP_ITEM_SL_NO + ch + LICENSE_IMP_QTY + ch + LICENSE_EXP_QTY + ch + LICENSE_IMP_TYPE + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);


                        m++;
                    }
                //}
                //mm++;
            //}
        }
    }

    private void DRAWBACK()
    {
        DataSet ds_stmt = new DataSet();
        setdata();

        if (dss.Tables[0].Rows.Count > 0)
        {   
            int dbk = 0;
            sw.WriteLine("<TABLE>DBK");

            while (dss.Tables[0].Rows.Count > dbk)
            {

                INVOICE_SLNO = dt.Trim(dss.Tables[0].Rows[dbk]["INVOICE_SLNO"].ToString());

                ITEM_SLNO = dt.Trim(dss.Tables[0].Rows[dbk]["ITEM_SLNO"].ToString());

                DRAWBACK_SLNO = dt.Trim(dss.Tables[0].Rows[dbk]["DRAWBACK_SLNO"].ToString());

                DRAWBACK_QTY = dt.Trim(dss.Tables[0].Rows[dbk]["DRAWBACK_QTY"].ToString());

                
                sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + "" + ch + "" + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + DRAWBACK_SLNO + ch + DRAWBACK_QTY + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                dbk++;
            }
        }
    }


    private void setdata()
    {
        Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
        Amnd.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;

        Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();

        if (ddl_AmendPage.SelectedItem.Text == "GENERAL")
        {
            Amnd.ITEM_SLNO = "";
            Amnd.SELECT_ITEM = "";
            Amnd.Ename = "select_GENERAL_Details_Flatfile";

            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "sb_updt";
        }

        
       
        else if (ddl_AmendPage.SelectedItem.Text == "INVOICE")
        {
            Amnd.ITEM_SLNO = "";
            Amnd.SELECT_ITEM = "";
            Amnd.Ename = "select_Invoice_Details_Flatfile";
            
            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "inv_insrt";
            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "inv_updt";
            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "inv_del";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "ITEM")
        {
            //Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text == null ? "" : ddl_ItemSlno.SelectedItem.Text;//08-09-2021
            Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text == null ? "" : ListBox_ItemSlno.SelectedItem.Text;


            string Item_slno_ListBox = "";
            //foreach (ListItem item in ListBox1.Items)
            foreach (ListItem item in ListBox_ItemSlno.Items)
            {
                if (item.Selected)
                {
                    Item_slno_ListBox += item.Value + "~";
                }
            }

            Amnd.SELECT_ITEM = Item_slno_ListBox;
            Amnd.Ename = "select_Item_Details_Flatfile";

            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "item_insrt";
            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "item_updt";
            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "item_del";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "DRAWBACK")
        {
            Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text == null ? "" : ListBox_ItemSlno.SelectedItem.Text;
            string Item_slno_ListBox = "";
            //foreach (ListItem item in ListBox1.Items)
            foreach (ListItem item in ListBox_ItemSlno.Items)
            {
                if (item.Selected)
                {
                    Item_slno_ListBox += item.Value + "~";
                }
            }

            Amnd.SELECT_ITEM = Item_slno_ListBox;
            Amnd.Ename = "select_Drawback_Flatfile";
           
            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "dbk_updt";
           
        }
        else if (ddl_AmendPage.SelectedItem.Text == "STATEMENT")
        {
            //Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text == null ? "" : ddl_ItemSlno.SelectedItem.Text;//08-09-2021
            Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text == null ? "" : ListBox_ItemSlno.SelectedItem.Text;

            string Sup_Doc_Item_slno_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    Sup_Doc_Item_slno_ListBox += item.Value + "~";
                }
            }

            //Amnd.SELECT_ITEM = ListBox1.SelectedItem.Text == null ? "" : ListBox1.SelectedItem.Text;
            Amnd.SELECT_ITEM = Sup_Doc_Item_slno_ListBox;
            Amnd.Ename = "select_SW_STATEMENT_Flatfile";

            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "stmt_updt";
            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "stmt_insrt";
            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "stmt_del";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS")
        {
            //Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text == null ? "" : ddl_ItemSlno.SelectedItem.Text;//08-09-2021
            //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text == null ? "" : ListBox_ItemSlno.SelectedItem.Text;

            string Item_Selected_ListBox = "";
            foreach (ListItem item in ListBox_ItemSlno.Items)
            {
                if (item.Selected)
                {
                    Item_Selected_ListBox += item.Value + "~";
                }
            }

            Amnd.ITEM_SLNO = Item_Selected_ListBox;


            string Sup_Doc_Item_slno_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    Sup_Doc_Item_slno_ListBox += item.Value + "~";
                }
            }

            //Amnd.SELECT_ITEM = ListBox1.SelectedItem.Text == null ? "" : ListBox1.SelectedItem.Text;
            Amnd.SELECT_ITEM = Sup_Doc_Item_slno_ListBox;
            Amnd.Ename = "select_SupDocs_Flatfile";

            if (ddl_AmendType.SelectedValue == "A")
                AMEND_TYPE_FF = "spdc_updt";

            if (ddl_AmendType.SelectedValue == "S")
                AMEND_TYPE_FF = "spdc_insrt";

            if (ddl_AmendType.SelectedValue == "D")
                AMEND_TYPE_FF = "spdc_del";
        }

        else if (ddl_AmendPage.SelectedItem.Text == "LICENSE")
        {
            //Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text == null ? "" : ddl_ItemSlno.SelectedItem.Text;//08-09-2021
            //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text == null ? "" : ListBox_ItemSlno.SelectedItem.Text;

            string Item_Selected_ListBox = "";
            foreach (ListItem item in ListBox_ItemSlno.Items)
            {
                if (item.Selected)
                {
                    Item_Selected_ListBox += item.Value + "~";
                }
            }

            Amnd.ITEM_SLNO = Item_Selected_ListBox;


            string License_Item_slno_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    License_Item_slno_ListBox += item.Value + "~";
                }
            }

            Amnd.SELECT_ITEM = License_Item_slno_ListBox;
            Amnd.Ename = "select_License_Flatfile";

            if (ddl_AmendPage.SelectedItem.Text == "DEEC")
            {
                if (ddl_AmendType.SelectedValue == "A")
                    AMEND_TYPE_FF = "deec_updt";

                if (ddl_AmendType.SelectedValue == "S")
                    AMEND_TYPE_FF = "deec_insrt";

                if (ddl_AmendType.SelectedValue == "D")
                    AMEND_TYPE_FF = "deec_del";
            }
            else if (ddl_AmendPage.SelectedItem.Text == "DEPB")
            {
                if (ddl_AmendType.SelectedValue == "A")
                    AMEND_TYPE_FF = "depb_updt";

            }
        }

        ViewState["AMEND_TYPE_FF"] = AMEND_TYPE_FF;
        dss = Amnd.RetrieveAll_Amend_Details();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtAmendmentReason.Text != "")
        {
            if (txtSBNo.Text != "" && txtSBDate.Text != "")
            {
                if (txtQueryNo.Text != "" && txtQueryDate.Text != "")
                {
                    try
                    {
                        setdata();

                        if (dss.Tables[0].Rows.Count > 0)
                        {

                            IS_Imgbtn = "";

                            //BE_Details();
                            imgbtnFlatFile.Visible = false;
                            btnSendQueue.Visible = false;
                            //btnSubmission.Visible = false;

                            if (File.Exists(errorFolder + logFileName))
                            {
                                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                                foreach (FileInfo fi in dir.GetFiles())
                                {
                                    fi.Delete();
                                }

                                Flat_File("GenerateButton");
                                Insert_Jobno_MAX_ID();

                                imgbtnFlatFile.Visible = true;
                                //btnSubmission.Visible = true;
                                btnSendQueue.Visible = true;
                            }
                            else
                            {
                                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                                foreach (FileInfo fi in dir.GetFiles())
                                {
                                    fi.Delete();
                                }

                                Flat_File("GenerateButton");
                                Insert_Jobno_MAX_ID();

                                imgbtnFlatFile.Visible = true;
                                //btnSubmission.Visible = true;
                                btnSendQueue.Visible = true;
                            }
                        }
                        else
                        {
                            Alert_msg("Not Valid Record..!!");
                        }
                    }
                    catch (Exception ex)
                    {
                        er.makeLog(ex.Message);
                    }
                }
                else
                {
                    Alert_msg("Query No & Date - Mandatory");
                }
            }
            else
            {
                //Alert_msg("BE Number & Date - Mandatory");


                //string script = string.Format("alert('{0}');", "BE Number & Date - Mandatory");
                //if (Page != null && !Page.ClientScript.IsClientScriptBlockRegistered("alert"))
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", script, true /* addScriptTags */);
                //}

            }
        }
        else
        {
            Alert_msg("Amendment Reason - Mandatory");
        }
    }

    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSearch.Enabled = false;
            //btnSubmission.Enabled = false;
            imgbtnFlatFile.Enabled = false;

            btnSearch.ToolTip = "You don't have permission to access";
            //btnSubmission.ToolTip = "You don't have permission to access";
            imgbtnFlatFile.ToolTip = "You don't have permission to access";
        }
        else
        {
            btnSearch.Enabled = true;
            //btnSubmission.Enabled = true;
            imgbtnFlatFile.Enabled = true;

        }
    }


    protected void btnSubmission_Click(object sender, EventArgs e)
    {
        try
        {
            IS_Imgbtn = "";

            //BE_Details();
            imgbtnFlatFile.Visible = false;
            btnSubmission.Visible = false;
            btnSendQueue.Visible = false;

            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File("SubmissionButton");

               // mail(errorFolder + logFileName);

                imgbtnFlatFile.Visible = true;
                btnSubmission.Visible = true;
                btnSendQueue.Visible = true;
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
  
    public void Flat_File(string process)
    {
        if (txtSBNo.Text != "" && txtSBDate.Text != "")
        {
           
            //DateTime date = System.DateTime.Now;
            //string datestringg = string.Format("{0:yyyyMMdd}", date);

            DateTime date = System.DateTime.Now;

            //string datestringg = string.Format("{0:yyyyMMdd}", txtJobDate.Text);
            string datestringg = Convert.ToDateTime(txtJobDate.Text).ToString("yyyyMMdd").ToString();

            DateTime tt = System.DateTime.Now;

            string time = string.Format("{0:hhmm}", tt);

            GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
            string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();

            SB_DATE = Convert.ToDateTime(txtSBDate.Text).ToString("ddMMyy").ToString();

            string JOB_date = Convert.ToDateTime(txtJobDate.Text).ToString("ddMMyy").ToString();

            string beno_date = txtSBNo.Text + SB_DATE;

            string SB_DATE_full = Convert.ToDateTime(txtSBDate.Text).ToString("yyyyMMdd").ToString();

            SB_NO = txtSBNo.Text;
            SB_DATE = SB_DATE_full;

            //int REQUEST_NO = 1;
            // REQUEST_NO = Get_Request_No_MAX();
            string REQUEST_NO = "";
            REQUEST_NO = txtQueryNo.Text;

            logFileName = ViewState["AmendJobno"].ToString() + yy + ".sb";

            JOBNO = ddlJobNo.SelectedItem.Text;

            createfilename = logFileName;
            Session["createflename"] = logFileName;

            //delete the exisitng file 
            if (File.Exists(errorFolder + logFileName))
            {
                File.Delete((errorFolder + logFileName));
            }

            //

            sw = new StreamWriter(errorFolder + logFileName, true);

            CUSTOMS_HOUSE = txtCustomsHouse.Text;
            //ICEGATE_ID = Connection.Get_Icegate_Id();
            ICEGATE_ID = txt_icegate_Id.Text.Trim();

            

           // string datestringg_CurrentDate = Convert.ToDateTime(date).ToString("yyyyMMdd").ToString();
            string datestringg_QueryDate = Convert.ToDateTime(txtQueryDate.Text).ToString("yyyyMMdd").ToString();
            string datestringg_CurrentDate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyyMMdd").ToString();

            
            AMEND_TYPE_FF = ViewState["AMEND_TYPE_FF"].ToString();
            Amendment_Type = ddl_AmendType.SelectedValue;
            Amendment_No = txtQueryNo.Text;
            Amendment_Date = datestringg_QueryDate;


                if (ddl_AmendPage.SelectedItem.Text == "GENERAL")
                {
                    //sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHE01_A" + ch + ViewState["AmendJobno"].ToString() + ch + datestringg_CurrentDate + ch + time);
                    sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHE01_A" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy + ch + datestringg_CurrentDate + ch + time);

                    GENERAL();

                    sw.WriteLine("<TABLE>AMENDHISTORY");
                    //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + SB_DATE_full + ch + txtSBNo.Text + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg + ch);
                    //this line hide on 29-03-2021 for Icegate New Implementation in QueryDate should be Current Date
                    //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + SB_DATE_full + ch + txtSBNo.Text + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg);
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + txtSBNo.Text + ch + SB_DATE_full + ch + datestringg_QueryDate + ch + REQUEST_NO + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg_QueryDate);

                    sw.WriteLine("<END-SB>");
                    sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy);
                }



                else if (ddl_AmendPage.SelectedItem.Text == "INVOICE")
                {
                    sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHE01_A" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy + ch + datestringg_CurrentDate + ch + time);

                    INVOICE();

                    sw.WriteLine("<TABLE>AMENDHISTORY");
                    //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + SB_DATE_full + ch + txtSBNo.Text + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg + ch);
                    //this line hide on 29-03-2021 for Icegate New Implementation in QueryDate should be Current Date
                    //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + SB_DATE_full + ch + txtSBNo.Text + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg );
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + txtSBNo.Text + ch + SB_DATE_full + ch + datestringg_QueryDate + ch + REQUEST_NO + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg_QueryDate);

                    sw.WriteLine("<END-SB>");
                    sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy);
                }

                else if (ddl_AmendPage.SelectedItem.Text == "ITEM")
                {
                    int xx = 0;
                    sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHE01_A" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy + ch + datestringg_CurrentDate + ch + time);

                    foreach (ListItem item1 in List_ddl_Item.Items)
                    {
                        if (item1.Selected)
                        {
                            //Item_Selected_ListBox += item1.Value + "~";
                            xx = 1;
                            if (item1.Value == "ITEM")
                            {
                                ITEM();
                            }
                            if (item1.Value == "ITEMACCESS")
                            {
                                ITEMACCESS();
                            }
                            if (item1.Value == "STR")
                            {
                                STR();
                            }
                        }
                    }
                   

                    sw.WriteLine("<TABLE>AMENDHISTORY");
                    //this line hide on 29-03-2021 for Icegate New Implementation in QueryDate should be Current Date
                    //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + SB_DATE_full + ch + txtSBNo.Text + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg );
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + txtSBNo.Text + ch + SB_DATE_full + ch + datestringg_QueryDate + ch + REQUEST_NO + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg_QueryDate);

                    sw.WriteLine("<END-SB>");
                    sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy);
                }
                else if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS")
                {
                    //sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "T" + ch + "" + ch + "CACHI01" + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + time);
                    sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHE01_A" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy + ch + datestringg_CurrentDate + ch + time);
                    SupportingDocs();
                    sw.WriteLine("<TABLE>AMENDHISTORY");
                    //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + SB_DATE_full + ch + txtSBNo.Text + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg + ch);
                    //this line hide on 29-03-2021 for Icegate New Implementation in QueryDate should be Current Date
                    //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + SB_DATE_full + ch + txtSBNo.Text + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg);
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + txtSBNo.Text + ch + SB_DATE_full + ch + datestringg_QueryDate + ch + REQUEST_NO + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg_QueryDate);


                    sw.WriteLine("<END-SB>");
                    sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy);
                }
                else if (ddl_AmendPage.SelectedItem.Text == "STATEMENT")
                {
                    //sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "T" + ch + "" + ch + "CACHI01" + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + time);
                    sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHE01_A" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy + ch + datestringg_CurrentDate + ch + time);
                    Statement();
                    sw.WriteLine("<TABLE>AMENDHISTORY");
                    //this line hide on 29-03-2021 for Icegate New Implementation in QueryDate should be Current Date
                    //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + SB_DATE_full + ch + txtSBNo.Text + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg);
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + txtSBNo.Text + ch + SB_DATE_full + ch + datestringg_QueryDate + ch + REQUEST_NO + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg_QueryDate);


                    sw.WriteLine("<END-SB>");
                    sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy);
                }
                else if (ddl_AmendPage.SelectedItem.Text == "DRAWBACK")
                {
                    //sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "T" + ch + "" + ch + "CACHI01" + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + time);
                    sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHE01_A" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy + ch + datestringg_CurrentDate + ch + time);
                    DRAWBACK();
                    sw.WriteLine("<TABLE>AMENDHISTORY");
                    //this line hide on 29-03-2021 for Icegate New Implementation in QueryDate should be Current Date
                    //sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedItem.Text + ch + datestringg + ch + SB_DATE_full + ch + txtSBNo.Text + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg);
                    sw.WriteLine(ddl_AmendType.SelectedValue + ch + CUSTOMS_HOUSE + ch + txtSBNo.Text + ch + SB_DATE_full + ch + datestringg_QueryDate + ch + REQUEST_NO + ch + AMEND_TYPE_FF + ch + txtAmendmentReason.Text.Replace("\r\n", " ") + ch + "" + ch + REQUEST_NO + ch + datestringg_QueryDate);


                    sw.WriteLine("<END-SB>");
                    sw.WriteLine("TREC" + ch + ViewState["AmendJobno"].ToString() + GetDate_ddmmyy);
                }


            //sw.WriteLine("TREC" + ch + txt_jobno_search.Text + yy.Substring(0, 2));
            //sw.WriteLine("TREC" + ch + ddlJobNo.SelectedItem.Text + yy.Substring(0, 2));

            //sw.WriteLine();
            //sw.Write("/n");

            DateTime dat = System.DateTime.Now;
            string datestring = string.Format("{0:dd/MM/yyyy}", dat);

            sw.Close();
            sw.Dispose();

            Job_Histroy jh = new Job_Histroy();
            if (process != "SendQueue")
            {
                //Query Reply flatfile auto save to Job History folder also for Agility by Chitha
                if (Connection.COMPANYID() == "11" || Connection.COMPANYID() == "5" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
                {
                    if (File.Exists(errorFolder + logFileName))
                    {
                        DirectoryInfo dir = new DirectoryInfo(errorFolder);

                        if (Directory.Exists(targetPath) == false)
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        string sourceFile = System.IO.Path.Combine(errorFolder, logFileName);
                        string destFile = System.IO.Path.Combine(targetPath, JOBNO + " ~~" + logFileName);

                        System.IO.File.Copy(sourceFile, destFile, true);

                        jh.JOB_ID = "";
                        jh.JOB_TYPE = "EXP";
                        jh.JOBNO = JOBNO;

                        jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
                        jh.DESCRIPTION = targetPath;
                        jh.ATTACHMENT_FILE = JOBNO + " ~~" + logFileName;
                        jh.FLAG = "Upload_File";
                        jh.USER_ID = Session["currentuser"].ToString();
                        jh.JOBDATE = "01/01/1900";

                        jh.BRANCH_CODE = SELECT_BRANCH;
                        jh.YEAR = "Amendment";
                        jh.WORKING_PERIOD = Session["WorkingPeriod"].ToString(); 
                        jh.BRANCH_COMMON = SELECT_BRANCH;
                        dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();

                    }
                    else
                    {
                        Console.WriteLine("Source path does not exist!");
                    }
                }
            }
            else if (process == "SendQueue")
            {
                //DSC_FLATFILE_INSERT_UPDATE

                string SQ_Path = string.Empty;
                string SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
                if (SELECT_TYPE == "Branchwise Job")
                {
                    SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "EXP" + "/"
                        +
                        Session["currentbranch"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                        + "/");
                }
                else if (SELECT_TYPE == "Areawise Job")
                {
                    SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "EXP" + "/"
                        +
                        Session["GroupName"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                        + "/");
                }

                else
                {
                    SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "EXP" + "/");
                }


                if (Directory.Exists(SQ_Path) == false)
                {
                    Directory.CreateDirectory(SQ_Path);
                }

                string sourceFile2 = System.IO.Path.Combine(errorFolder, logFileName);

                System.IO.File.Copy(sourceFile2, SQ_Path + logFileName, true);


                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                url = url.Substring(0, url.IndexOf("Amendment")) + SQ_Path.Substring(SQ_Path.IndexOf("FlatFile_DSC"), SQ_Path.Length - (SQ_Path.IndexOf("FlatFile_DSC"))) + logFileName;
                jh.JOB_ID = url.Replace(@"\", @"/");


                jh.JOB_TYPE = "EXP";
                jh.JOBNO = JOBNO;

                jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
                jh.DESCRIPTION = SQ_Path + logFileName;
                jh.ATTACHMENT_FILE = JOBNO + " ~~" + logFileName;
                jh.FLAG = "Amendment_Insert";
                jh.USER_ID = Session["currentuser"].ToString();
                jh.JOBDATE = txtJobDate.Text;
                jh.BRANCH_CODE = SELECT_BRANCH;
                jh.YEAR = "";
                jh.WORKING_PERIOD = Session["WorkingPeriod"].ToString(); ;
                jh.BRANCH_COMMON = SELECT_BRANCH;
                dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
                if (dss.Tables.Count > 0)
                {
                    if (dss.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        lblsent_date.Text = dss.Tables[0].Rows[0][1].ToString();
                        Alert_msg("Sent Successfully");
                    }
                    else
                    {
                        lblsent_date.Text = "Failed to Sent";
                        Alert_msg("Failed to Sent");
                    }

                }

            }

            if (IS_Imgbtn == "1")
            {
                Response.Write(sw.ToString());
                Response.Flush();
                // Response.End();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {
            Alert_msg("SB Number & Date - Mandatory");
        }
    }

    protected void imgbtnFlatFile_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            IS_Imgbtn = "1";
            //BE_Details();
            imgbtnFlatFile.Visible = false;
            //btnSubmission.Visible = false;
            btnSendQueue.Visible = false;

            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File("FaltfileImageBUtton");

                imgbtnFlatFile.Visible = true;
                btnSendQueue.Visible = true;
                //btnSubmission.Visible = true;
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File("FaltfileImageBUtton");

                imgbtnFlatFile.Visible = true;
                btnSendQueue.Visible = true;
                //btnSubmission.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'AMENDMENT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'AMENDMENT', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddl_AmendPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds_supp=new DataSet();
        Amnd.JOBNO = "";
        Amnd.INVOICE_SLNO = "";
        Amnd.ITEM_SLNO = "";
        Amnd.SELECT_ITEM = "";
        Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();

        div_AmendmentType.Visible = false;
        if (ddl_AmendPage.SelectedItem.Text == "GENERAL")
        {
            Amnd.Ename = "select_GENERAL_JOBNO_List";

            ddlInvoice_SlNo.Enabled = false;
            //ddl_ItemSlno.Enabled = false;//08-09-2021
           
            ListBox_ItemSlno.Visible = false;
            Item_TextBox.Visible = true;
            Item_TextBox.Enabled = false;
            ListBox1.Visible = false;
            TextBox1.Visible = true;
            TextBox1.Enabled = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "INVOICE")
        {
            Amnd.Ename = "select_Invoice_JOBNO_List";

            ddlInvoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = false;//08-09-2021
            ListBox_ItemSlno.Enabled = false;
            ListBox1.Enabled = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "ITEM")
        {
            Amnd.Ename = "select_Item_JOBNO_List";

            ddlInvoice_SlNo.Enabled = true;
            ListBox_ItemSlno.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            Item_TextBox.Visible = false;
            ListBox1.Visible = false;
            TextBox1.Visible = true;
            TextBox1.Enabled = false;
            div_AmendmentType.Visible = true;

            List_ddl_Item.Items.Clear();
            List_ddl_Item.Items.Add("ITEM");
            List_ddl_Item.Items.Add("ITEMACCESS");
            List_ddl_Item.Items.Add("STR");
            
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "Multiple ITEM";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "DRAWBACK")
        {
            Amnd.Ename = "select_Drawback_JOBNO_List";

            ddlInvoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = true;//08-09-2021
            ListBox_ItemSlno.Enabled = true;
            ListBox1.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            ListBox1.Visible = true;
            Item_TextBox.Visible = false;
            TextBox1.Visible = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "Multiple ITEM";
        }
        else if ( ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS")
        {
            Amnd.Ename = "select_SupDocs_JOBNO_List";

            ddlInvoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = true;//08-09-2021
            ListBox_ItemSlno.Enabled = true;
            ListBox1.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            ListBox1.Visible = true;
            Item_TextBox.Visible = false;
            TextBox1.Visible = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "IRN Number";
        }
        else if (ddl_AmendPage.SelectedItem.Text == "STATEMENT")
        {
            Amnd.Ename = "select_SW_STATEMENT_JOBNO_List";

            ddlInvoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = true;//08-09-2021
            ListBox_ItemSlno.Enabled = true;
            ListBox1.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            ListBox1.Visible = true;
            Item_TextBox.Visible = false;
            TextBox1.Visible = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "STMT Code";
        }
        //else if (ddl_AmendPage.SelectedItem.Text == "DEEC")
        else if (ddl_AmendPage.SelectedItem.Text == "LICENSE")
        {
            div_AmendmentType.Visible = true;

            List_ddl_Item.Items.Clear();
            List_ddl_Item.Items.Add("DEEC");
            List_ddl_Item.Items.Add("DFIA");
            List_ddl_Item.Items.Add("DEPB");
            
            //Amnd.SELECT_ITEM = ddl_AmendPage.SelectedItem.Text;
            //Amnd.SELECT_ITEM = List_ddl_Item.SelectedItem.Text;

            /*
            Amnd.Ename = "select_License_JOBNO_List";

            ddlInvoice_SlNo.Enabled = true;
            //ddl_ItemSlno.Enabled = true;//08-09-2021
            ListBox_ItemSlno.Enabled = true;
            ListBox1.Enabled = true;
            ListBox_ItemSlno.Visible = true;
            ListBox1.Visible = true;
            Item_TextBox.Visible = false;
            TextBox1.Visible = false;
            div_AmendmentType.Visible = true;


            lbl_Invoice_Slno.Text = "Invoice Sr.No";
            lbl_select_item.Text = "License Number";
             * */
        }
        if (ddl_AmendPage.SelectedItem.Text != "LICENSE")
        {
            ds_supp = Amnd.RetrieveAll_Amend_Details();

            if (ds_supp.Tables[0].Rows.Count > 0)
            {
                ddlJobNo.DataSource = ds_supp.Tables[0];
                ddlJobNo.DataTextField = "JOBNO";
                ddlJobNo.DataValueField = "JOBNO";
                ddlJobNo.DataBind();
                ddlJobNo.Items.Insert(0, "Select");

            }
            else
            {
                ddlJobNo.Items.Clear();
                ddlJobNo.Items.Insert(0, "Select");
            }
        }
    }

    protected void ddl_AmendType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Amendment_Page();
    }

    private void Load_Amendment_Page()
    {
        if (ddl_AmendType.SelectedValue == "A")
        {
            ddl_AmendPage.Items.Clear();
            ddl_AmendPage.Items.Add("GENERAL");
            ddl_AmendPage.Items.Add("INVOICE");
            ddl_AmendPage.Items.Add("ITEM");
            ddl_AmendPage.Items.Add("DRAWBACK");
            //ddl_AmendPage.Items.Add("LICENSE");
            ////ddl_AmendPage.Items.Add("DEEC");
            ////ddl_AmendPage.Items.Add("DEPB");
            //ddl_AmendPage.Items.Add("CESS");
            ////ddl_AmendPage.Items.Add("DFIA");
            //ddl_AmendPage.Items.Add("JOBWORK");
            //ddl_AmendPage.Items.Add("REWARD");
            ddl_AmendPage.Items.Add("STATEMENT");
            ddl_AmendPage.Items.Add("SUPPORTING_DOCS");
            ddl_AmendPage.Items.Insert(0, "Select");

            ddlInvoice_SlNo.Enabled = false;
            //ddl_ItemSlno.Enabled = false;//08-09-2021
            ListBox_ItemSlno.Enabled = false;
            ListBox1.Enabled = false;
            lbl_Invoice_Slno.Text = "Invoice Sr.No";
        }
        else
        {
            ddl_AmendPage.Items.Clear();

            ddl_AmendPage.Items.Add("INVOICE");
            ddl_AmendPage.Items.Add("ITEM");
            ddl_AmendPage.Items.Add("DRAWBACK");
            //ddl_AmendPage.Items.Add("LICENSE");
            ////ddl_AmendPage.Items.Add("DEEC");
            ////ddl_AmendPage.Items.Add("DEPB");
            //ddl_AmendPage.Items.Add("CESS");
            ////ddl_AmendPage.Items.Add("DFIA");
            //ddl_AmendPage.Items.Add("JOBWORK");
            //ddl_AmendPage.Items.Add("REWARD");
            ddl_AmendPage.Items.Add("STATEMENT");
            ddl_AmendPage.Items.Add("SUPPORTING_DOCS");

            ddl_AmendPage.Items.Insert(0, "Select");

            
            ddlJobNo.Items.Clear();
        }
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            AUTO_JOBNO();

            DataSet ds_supp = new DataSet();
            Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
            Amnd.INVOICE_SLNO = "";
            Amnd.ITEM_SLNO = "";
            Amnd.SELECT_ITEM = ddl_AmendPage.SelectedItem.Text;
            Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
            Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
            Amnd.Ename = "select_JOB_DETAILS";


            ds_supp = Amnd.RetrieveAll_Amend_Details();

            if (ds_supp.Tables[0].Rows.Count > 0)
            {
                txtJobDate.Text = ds_supp.Tables[0].Rows[0]["JOBDATE"].ToString();
                txtCustomsHouse.Text = ds_supp.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
            }
            else
            {
                txtJobDate.Text = "";
                txtCustomsHouse.Text = "";
            }

            if (ds_supp.Tables[1].Rows.Count > 0)
            {
                txtSBNo.Text = ds_supp.Tables[1].Rows[0]["SB_NO"].ToString();
                txtSBDate.Text = ds_supp.Tables[1].Rows[0]["SB_DATE"].ToString();
            }
            else
            {
                txtSBNo.Text = "";
                txtSBDate.Text = "";
            }

            if (ddl_AmendPage.SelectedItem.Text == "CONTAINER" || ddl_AmendPage.SelectedItem.Text == "IGM" || ddl_AmendPage.SelectedItem.Text == "INVOICE" 
                || ddl_AmendPage.SelectedItem.Text == "ITEM" || ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS" || ddl_AmendPage.SelectedItem.Text == "STATEMENT" 
                || ddl_AmendPage.SelectedItem.Text == "DRAWBACK" || ddl_AmendPage.SelectedItem.Text == "LICENSE")
            {
                if (ddl_AmendPage.SelectedItem.Text == "IGM")//30-03-2021 newly add if condition
                {                 
                    if (ds_supp.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Visible = false;
                        ListBox1.Visible = true;
                        ListBox1.DataSource = ds_supp.Tables[2];
                        ListBox1.DataTextField = "UNIQUE_DOC_NUMBER";
                        ListBox1.DataValueField = "UNIQUE_DOC_NUMBER";
                        ListBox1.DataBind();

                        Item_TextBox.Visible = true;
                        ListBox_ItemSlno.Visible = false;
                        Item_TextBox.Enabled = false;
                    }
                }

                if (ddl_AmendPage.SelectedItem.Text != "IGM")//30-03-2021 newly add if condition
                {
                    if (ds_supp.Tables[2].Rows.Count > 0)
                    {
                        ddlInvoice_SlNo.DataSource = ds_supp.Tables[2];
                        ddlInvoice_SlNo.DataTextField = "INVOICE_SLNO";
                        ddlInvoice_SlNo.DataValueField = "INVOICE_SLNO";
                        ddlInvoice_SlNo.DataBind();
                        ddlInvoice_SlNo.Items.Insert(0, "Select");
                        ddlInvoice_SlNo.Enabled = true;
                    }
                }

                if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS" || ddl_AmendPage.SelectedItem.Text == "ITEM" || ddl_AmendPage.SelectedItem.Text == "STATEMENT"
                    || ddl_AmendPage.SelectedItem.Text == "DRAWBACK" || ddl_AmendPage.SelectedItem.Text == "LICENSE")
                //if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS"  || ddl_AmendPage.SelectedItem.Text == "STATEMENT")
                {
                    if (ds_supp.Tables[3].Rows.Count > 0)
                    {
                        /*//08-09-2021
                        ddl_ItemSlno.DataSource = ds_supp.Tables[3];
                        ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                        ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                        ddl_ItemSlno.DataBind();
                        ddl_ItemSlno.Items.Insert(0, "Select");
                         * */

                        //TextBox1.Visible = false;//18-09-2021
                        TextBox1.Visible = true;
                        Item_TextBox.Visible = false;
                        ListBox_ItemSlno.Visible = true;
                        ListBox_ItemSlno.DataSource = ds_supp.Tables[3];
                        ListBox_ItemSlno.DataTextField = "ITEM_SLNO";
                        ListBox_ItemSlno.DataValueField = "ITEM_SLNO";
                        ListBox_ItemSlno.DataBind();
                    }
                }
                else
                {
                    /*
                    if (ddl_AmendPage.SelectedItem.Text == "IGM")//30-03-2021
                    {
                        //ddl_ItemSlno.Enabled = false;//08-09-2021
                        ListBox_ItemSlno.Enabled = false;
                        ListBox1.Enabled = true;
                        lbl_select_item.Text = "Multiple IGM";
                    }
                    if (ddl_AmendPage.SelectedItem.Text == "ITEM")//04-09-2021
                    {
                        //ddl_ItemSlno.Enabled = false;//08-09-2021
                        ListBox_ItemSlno.Enabled = false;
                        ListBox1.Enabled = true;
                        lbl_select_item.Text = "Multiple ITEM";
                    }
                    else
                    {
                        //ddl_ItemSlno.Enabled = false;//08-09-2021
                        ListBox_ItemSlno.Enabled = false;
                        ListBox1.Enabled = false;
                    }
                     *  */
                }              
            }

            // ListBox1.Items.Clear();//30-03-2021
        }
    }
 
    protected void ddlInvoice_SlNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInvoice_SlNo.SelectedItem.Text != "Select" || ddlInvoice_SlNo.SelectedItem.Text != "")
        {
            DataSet ds_supp = new DataSet();
            Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
            Amnd.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
            Amnd.ITEM_SLNO = "";
            //Amnd.SELECT_ITEM = "";--29-01-2021
            Amnd.SELECT_ITEM = ddl_AmendPage.SelectedItem.Text;
            Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
            Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
            Amnd.Ename = "select_INVOICE_Item_Slno";

            ds_supp = Amnd.RetrieveAll_Amend_Details();

            if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS" || ddl_AmendPage.SelectedItem.Text == "STATEMENT" || ddl_AmendPage.SelectedItem.Text == "ITEM"
                || ddl_AmendPage.SelectedItem.Text == "DRAWBACK" || ddl_AmendPage.SelectedItem.Text == "LICENSE")
            {
                if (ds_supp.Tables[0].Rows.Count > 0)
                {
                    /* 08-09-2021
                    ddl_ItemSlno.DataSource = ds_supp.Tables[0];
                    ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                    ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                    ddl_ItemSlno.DataBind();
                    ddl_ItemSlno.Items.Insert(0, "Select");
                     * */

                    //TextBox1.Visible = false;//18-09-2021
                    TextBox1.Visible = true;
                    Item_TextBox.Visible = false;
                    ListBox_ItemSlno.Visible = true;
                    ListBox_ItemSlno.DataSource = ds_supp.Tables[0];
                    ListBox_ItemSlno.DataTextField = "ITEM_SLNO";
                    ListBox_ItemSlno.DataValueField = "ITEM_SLNO";
                    ListBox_ItemSlno.DataBind();
                }
            }
            //else if(ddl_AmendPage.SelectedItem.Text == "ITEM")
            //{
            //    if (ds_supp.Tables[0].Rows.Count > 0)
            //    {
            //        TextBox1.Visible = false;
            //        Item_TextBox.Visible = true;
            //        ListBox1.Visible = true;
            //        ListBox1.DataSource = ds_supp.Tables[0];
            //        ListBox1.DataTextField = "ITEM_SLNO";
            //        ListBox1.DataValueField = "ITEM_SLNO";
            //        ListBox1.DataBind();
            //    }
            //}
        }
    }

    protected void List_ddl_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        foreach (ListItem item in List_ddl_Item.Items)
        {
            if (item.Selected)
            {
                lICENSE_Item_Selected_ListBox += item.Value + "~";
            }
        }

        DataSet ds_supp = new DataSet();
        Amnd.JOBNO = "";
        Amnd.INVOICE_SLNO = "";
        Amnd.ITEM_SLNO = "";
        Amnd.SELECT_ITEM = lICENSE_Item_Selected_ListBox;
        Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();

        if (ddl_AmendPage.SelectedItem.Text == "ITEM")
        {
            Amnd.Ename = "select_Item_JOBNO_List";
        }

        if (ddl_AmendPage.SelectedItem.Text == "LICENSE")
        {
            Amnd.Ename = "select_License_JOBNO_List";
        }

        ds_supp = Amnd.RetrieveAll_Amend_Details();

        if (ds_supp.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds_supp.Tables[0];
            ddlJobNo.DataTextField = "JOBNO";
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataBind();
            ddlJobNo.Items.Insert(0, "Select");

        }
        else
        {
            ddlJobNo.Items.Clear();
            ddlJobNo.Items.Insert(0, "Select");
        }
    }

    protected void ListBox_ItemSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ListBox_ItemSlno.SelectedItem.Text != "Select")
            //{
            if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS")
            {

                string Item_Selected_ListBox = "";
                foreach (ListItem item in ListBox_ItemSlno.Items)
                {
                    if (item.Selected)
                    {
                        Item_Selected_ListBox += item.Value + "~";
                    }
                }

                if (Item_Selected_ListBox != "")
                {
                    DataSet ds_supp = new DataSet();
                    Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                    Amnd.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                    //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text;//08-09-2021
                    Amnd.ITEM_SLNO = Item_Selected_ListBox;
                    Amnd.SELECT_ITEM = "";
                    Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                    Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                    Amnd.Ename = "select_SupDocs_IRN_NO";

                    ds_supp = Amnd.RetrieveAll_Amend_Details();

                    if (ds_supp.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Visible = false;
                        Item_TextBox.Visible = false;
                        ListBox1.Visible = true;
                        ListBox1.DataSource = ds_supp.Tables[0];
                        ListBox1.DataTextField = "UNIQUE_DOC_NUMBER";
                        ListBox1.DataValueField = "UNIQUE_DOC_NUMBER";
                        ListBox1.DataBind();
                    }
                }
                else
                {
                    TextBox1.Visible = true;
                    ListBox1.Visible = false;
                    Alert_msg("Select Item SlNo");
                }
            }
            else if (ddl_AmendPage.SelectedItem.Text == "STATEMENT")
            {

                string Item_Selected_ListBox = "";
                foreach (ListItem item in ListBox_ItemSlno.Items)
                {
                    if (item.Selected)
                    {
                        Item_Selected_ListBox += item.Value + "~";
                    }
                }


                DataSet ds_supp = new DataSet();
                Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                Amnd.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text;
                Amnd.ITEM_SLNO = Item_Selected_ListBox;
                Amnd.SELECT_ITEM = "";
                Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                Amnd.Ename = "select_STMT_Code";

                ds_supp = Amnd.RetrieveAll_Amend_Details();

                if (ds_supp.Tables[0].Rows.Count > 0)
                {
                    TextBox1.Visible = false;
                    Item_TextBox.Visible = false;
                    ListBox1.Visible = true;
                    ListBox1.DataSource = ds_supp.Tables[0];
                    ListBox1.DataTextField = "STMT_CODE";
                    ListBox1.DataValueField = "STMT_CODE";
                    ListBox1.DataBind();
                }
                else
                {
                    TextBox1.Visible = true;
                    Item_TextBox.Visible = false;
                    ListBox1.Visible = false;
                }
            }
            //else if (ddl_AmendPage.SelectedItem.Text == "DEEC" || ddl_AmendPage.SelectedItem.Text == "DFIA" || ddl_AmendPage.SelectedItem.Text == "DEPB")
            else if (ddl_AmendPage.SelectedItem.Text == "LICENSE")
            {

                string Item_Selected_ListBox = "";
                foreach (ListItem item in ListBox_ItemSlno.Items)
                {
                    if (item.Selected)
                    {
                        Item_Selected_ListBox += item.Value + "~";
                    }
                }

                foreach (ListItem item1 in List_ddl_Item.Items)
                {
                    if (item1.Selected)
                    {
                        lICENSE_Item_Selected_ListBox += item1.Value + "~";
                    }
                }


                DataSet ds_supp = new DataSet();
                Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                Amnd.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                //Amnd.ITEM_SLNO = ListBox_ItemSlno.SelectedItem.Text;
                Amnd.ITEM_SLNO = Item_Selected_ListBox;
                Amnd.SELECT_ITEM = lICENSE_Item_Selected_ListBox;
                Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                Amnd.Ename = "select_Scheme_License_No";

                ds_supp = Amnd.RetrieveAll_Amend_Details();

                if (ds_supp.Tables[0].Rows.Count > 0)
                {
                    TextBox1.Visible = false;
                    Item_TextBox.Visible = false;
                    ListBox1.Visible = true;
                    ListBox1.DataSource = ds_supp.Tables[0];
                    ListBox1.DataTextField = "LICENSE_SLNO";
                    ListBox1.DataValueField = "LICENSE_SLNO";
                    ListBox1.DataBind();
                }
                else
                {
                    TextBox1.Visible = true;
                    Item_TextBox.Visible = false;
                    ListBox1.Visible = false;
                }
            }
            else
            {
                ListBox1.Enabled = false;
            }
                //}
                //else
                //{
                //    TextBox1.Visible = true;
                //    Item_TextBox.Visible = true;
                //    ListBox1.Visible = false;
                //    ListBox_ItemSlno.Visible = false;
                //}
            
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    /*
    protected void ddl_ItemSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_ItemSlno.SelectedItem.Text != "Select")
        {
            if (ddl_AmendPage.SelectedItem.Text == "SUPPORTING_DOCS")
            {
                DataSet ds_supp = new DataSet();
                Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                Amnd.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
                Amnd.SELECT_ITEM = "";
                Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                Amnd.Ename = "select_SupDocs_IRN_NO";

                ds_supp = Amnd.RetrieveAll_Amend_Details();

                if (ds_supp.Tables[0].Rows.Count > 0)
                {
                    TextBox1.Visible = false;
                    ListBox1.Visible = true;
                    ListBox1.DataSource = ds_supp.Tables[0];
                    ListBox1.DataTextField = "UNIQUE_DOC_NUMBER";
                    ListBox1.DataValueField = "UNIQUE_DOC_NUMBER";
                    ListBox1.DataBind();
                }
            }
            else if (ddl_AmendPage.SelectedItem.Text == "STATEMENT")
            {
                DataSet ds_supp = new DataSet();
                Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
                Amnd.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                Amnd.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
                Amnd.SELECT_ITEM = "";
                Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
                Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
                Amnd.Ename = "select_STMT_Code";

                ds_supp = Amnd.RetrieveAll_Amend_Details();

                if (ds_supp.Tables[0].Rows.Count > 0)
                {
                    TextBox1.Visible = false;
                    ListBox1.Visible = true;
                    ListBox1.DataSource = ds_supp.Tables[0];
                    ListBox1.DataTextField = "STMT_CODE";
                    ListBox1.DataValueField = "STMT_CODE";
                    ListBox1.DataBind();
                }
                else
                {
                    TextBox1.Visible = true;
                    ListBox1.Visible = false;
                }
            }
            else
            {
                ListBox1.Enabled = false;
            }
        }
        else
        {
            TextBox1.Visible = true;
            ListBox1.Visible = false;
        }
        
    }

    */
    public string Get_Admin_Master_Codes(string Search_Name)
    {
        IMPORTER_CLASS = "N";
        Export_FlatFile_Generation Imp_FlatFile = new Export_FlatFile_Generation();
        Imp_FlatFile.Ename = "IMPORT_SELECT";

        dss_adm = Imp_FlatFile.Search_Admin_Master();
        DataView view1 = dss_adm.Tables[0].DefaultView;
        /*
        if (Search_Name == "COUNTRY_OF_ORIGIN")
        {
            view1 = dss_adm.Tables[1].DefaultView;
            view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_ORIGIN) + "'";
            DataSet dt_1 = new DataSet();
            dt_1.Tables.Add(view1.ToTable());
            if (dt_1.Tables[0].Rows.Count > 0)
            {
                COUNTRY_ORIGIN = dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
                Search_Name = COUNTRY_ORIGIN;
            }
            else
            {
                Search_Name = COUNTRY_ORIGIN;
            }
        }
        else if (Search_Name == "COUNTRY_SHIPMENT")
        {
            view1 = dss_adm.Tables[1].DefaultView;
            view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_SHIPMENT) + "'";

            DataSet ds1 = new DataSet();
            ds1.Tables.Add(view1.ToTable());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                COUNTRY_SHIPMENT = ds1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
                Search_Name = COUNTRY_SHIPMENT;
            }
            else
            {
                Search_Name = COUNTRY_SHIPMENT;
            }
        }

        else if (Search_Name == "PORT_ORIGIN")
        {
            if (PORT_ORIGIN.Contains("-"))
            {
                PORT_ORIGIN = split.Split_main("-", PORT_ORIGIN);
                Search_Name = PORT_ORIGIN;
            }
            else
            {
                Search_Name = PORT_ORIGIN;
            }
        }
        else if (Search_Name == "PORT_SHIPMENT")
        {
            if (PORT_SHIPMENT.Contains("-"))
            {
                PORT_SHIPMENT = split.Split_main("-", PORT_SHIPMENT);
                Search_Name = PORT_SHIPMENT;
            }
            else
            {
                Search_Name = PORT_SHIPMENT;
            }
        }
        */
        return Search_Name;
    }

    private int Get_Request_No_MAX()
    {
        int result = 1;
        DataSet ds_MAX = new DataSet();
        Amnd.JOBNO = "";
        Amnd.INVOICE_SLNO = "";
        Amnd.ITEM_SLNO = "";
        Amnd.SELECT_ITEM = "";
        Amnd.AMEND_TYPE = "";
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
        Amnd.Ename = "Get_REQUEST_NO_MAX";

        ds_MAX = Amnd.RetrieveAll_Amend_Details();

        if (ds_MAX.Tables[0].Rows.Count > 0)
        {
            result = Convert.ToInt32(ds_MAX.Tables[0].Rows[0]["REQUEST_NO"].ToString());
        }


        return result;
    }

    protected void btnSendQueue_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    
        Flat_File("SendQueue");



        //}
        //catch (Exception ex)
        //{
        //    Connection.Error_Msg(ex.Message);
        //}

    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        ddl_AmendPage.SelectedValue = "Select";
        ddlJobNo.SelectedValue = "Select";
        ddlInvoice_SlNo.SelectedValue = "Select";
        ListBox_ItemSlno.Items.Clear();
        ListBox1.Items.Clear();
        txtQueryNo.Text = "";
        txtQueryDate.Text = "";
        //txtAmendmentReason.Text = "";


    }

    private string Fn_JOBNO(string JOBNO, string Running_No)
    {
        string lFileName = "";
        if (JOBNO.Length == 1)
        {
            //logFileName = ddlJobNo.SelectedItem.Text + "0000" + REQUEST_NO + yy + ".beamd";
            //lFileName = ddlJobNo.SelectedItem.Text + "0000" + txtQueryNo.Text;//hide on 06-04-2022 by Chithra sugg.by Subbu sir
            //lFileName = ddlJobNo.SelectedItem.Text + "0000" + txt_AmendmentJobno.Text;
            lFileName = ddlJobNo.SelectedItem.Text + "0000" + Running_No;
        }
        else if (JOBNO.Length == 2)
        {
            lFileName = ddlJobNo.SelectedItem.Text + "000" + Running_No;
        }
        else if (JOBNO.Length == 3)
        {
            lFileName = ddlJobNo.SelectedItem.Text + "00" + Running_No;
        }
        else if (JOBNO.Length == 4)
        {
            lFileName = ddlJobNo.SelectedItem.Text + "0" + Running_No;
        }
        else
        {
            lFileName = ddlJobNo.SelectedItem.Text + Running_No;
        }
        return lFileName;
    }

    public void AUTO_JOBNO()
    {
        DataSet ds_jobno = new DataSet();
        Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
        Amnd.INVOICE_SLNO = "";
        Amnd.ITEM_SLNO = "";
        Amnd.SELECT_ITEM = "";
        Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
        Amnd.Ename = "select_MAX_ID";

        ds_jobno = Amnd.RetrieveAll_Amend_Details();

        if (ds_jobno.Tables[0].Rows.Count > 0)
        {
            txt_AmendmentJobno.Text = Fn_JOBNO(ddlJobNo.SelectedItem.Text, ds_jobno.Tables[0].Rows[0][0].ToString());
            ViewState["AmendJobno"] = txt_AmendmentJobno.Text;

            txtQueryDate.Text = System.DateTime.Now.ToShortDateString();
        }
    }

    public void Insert_Jobno_MAX_ID()
    {
        DataSet ds_jobno = new DataSet();
        Amnd.JOBNO = ddlJobNo.SelectedItem.Text;
        Amnd.INVOICE_SLNO = Connection.Current_User();
        Amnd.ITEM_SLNO = "";
        Amnd.SELECT_ITEM = "";
        Amnd.AMEND_TYPE = ddl_AmendType.SelectedValue;
        Amnd.WORKING_PERIOD = Connection.Get_Company_Type();
        Amnd.Ename = "Insert_MAX_ID";

        ds_jobno = Amnd.RetrieveAll_Amend_Details();

    }

    public void Get_Admin_Master_Codes()
    {
        string sealtype_txt = "";
        if (NATURE_OF_CARGO != "")
        {
            sealtype_txt = "";
        }
        Imp_Exp.Eimp_exp_id = "";
        Imp_Exp.Eimp_exp_name = EXPORTER_NAME;
        Imp_Exp.Eimp_exp_iecno = IEC_NO;
        Imp_Exp.Eimp_exp_brslno = BRANCH_NO;
        Imp_Exp.Ename = "Export_FlatFile_select_Type";
        Imp_Exp.EWorking_Period = "";

        Imp_Exp.startRowIndex = "0";
        Imp_Exp.maximumRows = "0";
        DataSet dsImp_Exp = new DataSet();

        dsImp_Exp = Imp_Exp.RetrieveAll_Imp_exp_master();
        if (dsImp_Exp.Tables[0].Rows.Count > 0)
        {
            EXPORTER_CLASS = dsImp_Exp.Tables[0].Rows[0]["TYPE"].ToString();
            if (EXPORTER_CLASS == "O" || EXPORTER_CLASS == "")
            {
                EXPORTER_CLASS = "P";
            }
            else if (EXPORTER_CLASS == "G")
            {
                EXPORTER_CLASS = "G";
            }
        }
        Date_Time split = new Date_Time();
        FlatFile.Ename = "IMPORT_SELECT";

        dss = FlatFile.Search_Admin_Master();
        DataView view1 = dss.Tables[0].DefaultView;
        view1.RowFilter = "STATE_NAME = '" + split.Split("-", STATE_OF_EXPORT) + "'";
        //DataTable table1 = view1.ToTable();
        DataSet dt_UserRights = new DataSet();
        dt_UserRights.Tables.Add(view1.ToTable());
        if (dt_UserRights.Tables[0].Rows.Count > 0)
        {
            STATE_OF_EXPORT = dt.Trim(dt_UserRights.Tables[0].Rows[0]["STATE_CODE"].ToString());
        }
        //CONSIGNEE COUNTRY CODE
        view1 = dss.Tables[1].DefaultView;
        view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", CONSIGNEE_ADD5) + "'";
        DataSet dt_2 = new DataSet();
        dt_2.Tables.Add(view1.ToTable());
        if (dt_2.Tables[0].Rows.Count > 0)
        {
            CONSIGNEE_ADD5 = dt.Trim(dt_2.Tables[0].Rows[0]["COUNTRY_CODE"].ToString());
        }

        view1 = dss.Tables[1].DefaultView;
        view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_DISCHARGE) + "'";
        DataSet dt_1 = new DataSet();
        dt_1.Tables.Add(view1.ToTable());
        if (dt_1.Tables[0].Rows.Count > 0)
        {
            COUNTRY_DISCHARGE = dt.Trim(dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString());
        }
        view1 = dss.Tables[1].DefaultView;

        view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_FINAL_DEST) + "'";

        DataSet ds1 = new DataSet();
        ds1.Tables.Add(view1.ToTable());
        if (ds1.Tables[0].Rows.Count > 0)
        {
            COUNTRY_FINAL_DEST = dt.Trim(ds1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString());
        }
        if (PORT_DISCHARGE.Contains("-"))
        {
            PORT_DISCHARGE = split.Split_main("-", PORT_DISCHARGE);
        }
        if (PORT_FINAL_DEST.Contains("-"))
        {
            PORT_FINAL_DEST = split.Split_main("-", PORT_FINAL_DEST);
        }
    }
    
}