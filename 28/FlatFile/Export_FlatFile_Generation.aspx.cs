using System;
using System.Data; 
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
using System.Net.Mail;

using Microsoft.ApplicationBlocks.Data;
using Microsoft.Reporting.WebForms;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;



public partial class Transaction_Default2 : ThemeClass
{
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, val;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
 
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();

    public int currentrow = 0, Selected_Row = 0, Cell_Row = 0, ColumnIndex = 0;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,IS_Imgbtn,sealtype_txt="";
    public string SELECT_TYPE, SELECT_BRANCH;
    public string JOB_LOCK, JOB_RELEASE, JOB_USER;
    CheckList CHKLIST = new CheckList();
    Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();

    Export_General_New Export = new Export_General_New();

    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();
    // eroyalmaster erm = new eroyalmaster();
    adminmaster erm = new adminmaster();
    eroyalmaster Imp_Exp = new eroyalmaster();

    EXP_Validation EV = new EXP_Validation();

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "";
    public string folderName = "/Submission";
    ErrorLogs er = new ErrorLogs();
    public string createfilename = "";
    public char ch = Convert.ToChar(29);
    StreamWriter sw;
    //TextWriter sw;
    //Html32TextWriter sw;
    public string Amendment_Type = "";
    public string Amendment_No = "";
    public string Amendment_Date = "";
    public string SRNO = "";
    public int is_Annexure_Mode = 0;
    public string CHA_NO = "", ICEGATE_ID="";
    public string ICEGATE_EMAIL_ID = "", ICEGATE_EMAIL_PWD = "";
    public string EMail_ID = "";
    public string SB_NO = "";
    public string SB_DATE = "", Outlook_From_mail_Address = "";

    public string COMPANY_ID = "";


    #region General_Details

    public string JOBID;
    public string JOBNO;
    public string DDMMYY_JOBDATE,GetDate_ddmmyy;
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

    #endregion

    #region Packing List

    public string ANNEX_SEA_PACK_FROM;
    public string ANNEX_SEA_PACK_TO;
    public string ANNEX_SEA_PACK_PACKAGETYPE;
    public string ANNEX_SEA_PACK_FROMDESC;
    public string ANNEX_SEA_PACK_TODESC;


    #endregion

    #region Container

    public string ANNEX_SEA_CON_ID;
    //public string ANNEX_SEA_CON_JOBNO;
    public string ANNEX_SEA_CON_CONTAINERNO;
    public string ANNEX_SEA_CON_SIZE;
    public string ANNEX_SEA_CON_TYPE;
    public string ANNEX_SEA_CON_EXCISE_SEALNO;
    public string ANNEX_SEA_CON_SEAL_DATE;

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

    //******** Exchange Rate ********//

    public string Standard_Currency = "Y";
    public string Currency_Name;
    public string EXCHANGE_UNIT;
    public string Effective_Date = "";

    #endregion

    #region Item_Details

    public string ITEM_ID;
    //public string JOBNO;
    //public string INVOICE_SLNO;
    //public string INVOICE_NO;
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
    public string ITEM_PMVVALUE;
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

    #endregion

    #region Drawback_Details

    public string DRAWBACK_ID;
    //public string JOBNO;
    //public string INVOICE_SLNO;
    //public string ITEM_SLNO;
    public string SCHEME_CODE;
    public string DRAWBACK_SLNO;
    public string DRAWBACK_QTY;
    public string DRAWBACK_UNIT;
    public string DRAWBACK_NOOFUNITS;
    public string DRAWBACK_RATE;
    public string DRAWBACK_CAPS;
    public string DRAWBACK_DESC;

    #endregion

    #region Job Work

    public string JOBBING_ID;
    //JOBNO
    //INVOICE_SLNO
    //ITEM_SLNO
    //SCHEME_CODE
    public string NOTIFICATION_NO;
    public string BE_NO;
    public string BE_DATE;
    public string BE_INV_SLNO;
    public string BE_INV_NO;
    public string BE_ITEM_NO;
    public string BE_PORT_CODE;
    public string QTY;
    public string UNIT;

    #endregion

    #region License Details

    public string LICENSE_ID;
    //public string SCHEME_CODE;
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

    #region ANNEXURE C1 DETAILS

    public string ANNEX_ID;
    //public string ANNEX_JOBNO;
    public string ANNEX_EXPORTERNAME;
    public string ANNEX_IECCODE;
    public string ANNEX_BR_SLNO;
    public string ANNEX_EXAM_DATE;
    public string ANNEX_EXAM_OFFICER;
    public string ANNEX_EXAM_DESIGN;
    public string ANNEX_SUPER_NAME;
    public string ANNEX_SUPER_DESIGN;
    public string ANNEX_COMMISSION_RATE;
    public string ANNEX_DIVISION;
    public string ANNEX_RANGE;
    public string ANNEX_VERIFIED_EXAM_OFFICER;
    public string ANNEX_SAMPLE_DRAWN;
    public string ANNEX_SEAL_NO;

    #endregion

    #region Cess Details

    public string CESS_ID;
    public string CESS_SLNO;
    public string CESS_VALUE;
    public string CESS_UNIT;
    public string CESS_FLAG;
    public string CESS_RATE;
    public string CESS_ITEM_QTY;
    public string CESS_ITEM_QTY_CODE;
    public string CESS_TARIFF_VALUE;
    public string CESS_TARIFF_UNIT;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            //currentcomp_name = Session["currentcomp_name"].ToString();
            //comp_ConnectionStr = Session["currentcomp_db"].ToString();

            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;

            if (Session["SELECT_TYPE"] != null)
            {
                SELECT_TYPE = Session["SELECT_TYPE"].ToString();

                if (SELECT_TYPE == "Branchwise Job")
                {
                    SELECT_BRANCH = currentbranch;
                    hd_branch.Value = currentbranch;
                }
                else
                {
                    SELECT_BRANCH = "";
                    hd_branch.Value = currentbranch;
                }
            }
            else
            {
                SELECT_BRANCH = "";
                hd_branch.Value = currentbranch;
            }

            //errorFolder = Server.MapPath("~/Submission/");
            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");

            COMPANY_ID = Session["COMPANY_ID"].ToString();


            CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
            ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

            //ICEGATE_EMAIL_ID_NEW.Value = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            //ICEGATE_EMAIL_PWD_NEW.Value = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

            hdlock_or_Not.Value = "False";

            if (!IsPostBack)
            {
                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }  
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 12;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                if (!string.IsNullOrEmpty(Request["Combine_jobs"]))
                {
                    Session["Exp_Combine_Jobs"] = Request["Combine_jobs"].ToString();
                }
                else
                {
                    Session["Exp_Combine_Jobs"] = "";
                }


                ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
                if (!string.IsNullOrEmpty(Request["jobno"]))
                {

                    if (!string.IsNullOrEmpty(Request["SUB"]))
                    {
                        FlatFile.JOBNo = "";
                        FlatFile.Ename = "select_jobno";
                        FlatFile.Workingperiod = SELECT_BRANCH;
                        ddlJobNo.DataSource = FlatFile.Retrieve_Export_All_Details();
                        ddlJobNo.DataValueField = "JOBNO";
                        ddlJobNo.DataTextField = "JOBNO_PS";
                        ddlJobNo.DataBind();
                        ddlJobNo.Items.Remove("0");
                        ddlJobNo.Items.Insert(0, "Select");

                        ddlJobNo.SelectedValue = Request["jobno"].ToString();
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
                        /*
                       ddlJobNo.Items.Clear();
                       ddlJobNo.Items.Add(Request["jobno"].ToString().Trim());
                         */

                       ddlJobNo.Items.Clear();
                       //ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                       ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString().TrimEnd(), Request["jobno"].ToString().TrimEnd()));
                       ddlJobNo.SelectedIndex = 0;
                    }

                }
                else
                {
                    FlatFile.JOBNo = "";
                    FlatFile.TRANSPORT_MODE = "";
                    FlatFile.Ename = "select_jobno";
                    FlatFile.Workingperiod = SELECT_BRANCH;
                    ddlJobNo.DataSource = FlatFile.Retrieve_Export_All_Details();
                    ddlJobNo.DataValueField = "JOBNO";
                    ddlJobNo.DataTextField = "JOBNO_PS";
                    ddlJobNo.DataBind();
                    ddlJobNo.Items.Remove("0");
                    ddlJobNo.Items.Insert(0, "Select");
                }
                txtCustomHouse.Attributes.Add("readonly", "readonly");
                txtExporterName.Attributes.Add("readonly", "readonly");
                txtScheme.Attributes.Add("readonly", "readonly");
                txtConsignee.Attributes.Add("readonly", "readonly");
                txtNoofItems.Attributes.Add("readonly", "readonly");
                txtNoofInvoices.Attributes.Add("readonly", "readonly");

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }

        //Session.Remove("JOB_LOCK");
        //Session.Remove("JOB_RELEASE");
        //Session.Remove("JOB_USER");

        if (!IsPostBack)
        {
            Load_Path();
        }
    }

    private void Joblock()
    {
       
            SB_Details();

            DataSet ds2 = new DataSet();
            Export.JOBID = "";
            //Export.JOBNO = ddlJobNo.SelectedItem.Text;
            Export.JOBNO = ddlJobNo.SelectedValue.ToString();
            Export.EXPORTER_NAME = "";
            Export.TRANSPORT_MODE = "";
            Export.CUSTOMS_HOUSE = "";
            Export.Ename = "select_Id_Submission";
            Export.WORKING_PERIOD = SELECT_BRANCH;
            ds2 = Export.RetrieveAll_General_Details();

            JOB_LOCK = ds2.Tables[0].Rows[0]["JOB_STATUS"].ToString();
            JOB_RELEASE = ds2.Tables[0].Rows[0]["JOB_RELEASE"].ToString();
            JOB_USER = ds2.Tables[0].Rows[0]["USERID"].ToString();

            Session.Remove("JOB_LOCK");
            Session.Remove("JOB_RELEASE");
            Session.Remove("JOB_USER");

            Session["JOB_LOCK"] = JOB_LOCK;
            Session["JOB_RELEASE"] = JOB_RELEASE;
            Session["JOB_USER"] = JOB_USER;
    
    }

    private void Flat_File_Generation()
    {
        //imgbtn.Visible = true; ----- 07-Oct-2016


        imgbtnFlatFile.Enabled = true;
        btnSubmission.Enabled = true;
       // btn_Outlookmail_Submission.Enabled = true;

        hdlock_or_Not.Value = "True";

        try
        {
            IS_Imgbtn = "";
            //SB_Details();
            imgbtnFlatFile.Visible = false;
            btnSubmission.Visible = false;
           // btn_Outlookmail_Submission.Visible = false;

            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Flat_File();
                imgbtnFlatFile.Visible = true;
                btnSubmission.Visible = true;
                //btn_Outlookmail_Submission.Visible = true;
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Flat_File();
                imgbtnFlatFile.Visible = true;
                btnSubmission.Visible = true;
                //btn_Outlookmail_Submission.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
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
            btnSubmission.Enabled = false;
            imgbtnFlatFile.Enabled = false;
           // btn_Outlookmail_Submission.Enabled = false;

            btnSearch.ToolTip = "You don't have permission to access";
            btnSubmission.ToolTip = "You don't have permission to access";
            imgbtnFlatFile.ToolTip = "You don't have permission to access";
        }
        else
        {
            btnSearch.Enabled = true;
            btnSubmission.Enabled = true;
            imgbtnFlatFile.Enabled = true;
           // btn_Outlookmail_Submission.Enabled = true;
        }
    }
   
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Export_CheckList CHKLIST = new Export_CheckList();
            CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
            CHKLIST.Ename = "select_jobno_CheckList";

            CHKLIST.Workingperiod = SELECT_BRANCH;
            DataSet ds = new DataSet();
            ds = CHKLIST.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtExporterName.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtScheme.Text = ds.Tables[1].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtNoofInvoices.Text = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";

                    }
                    else
                    {
                        txtNoofInvoices.Text = "";
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txtNoofItems.Text = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";

                    }
                    else
                    {
                        txtNoofItems.Text = "";
                    }
                }
                else
                {
                    txtScheme.Text = "";
                    txtNoofItems.Text = "";
                    txtNoofInvoices.Text = "";
                }

            }
            else
            {
                txtCustomHouse.Text = "";
                txtExporterName.Text = "";
                txtScheme.Text = "";
                txtConsignee.Text = "";
                txtNoofItems.Text = "";
                txtNoofInvoices.Text = "";

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }
    public void SB_Details()
    {
        if (!string.IsNullOrEmpty(Request["Combine_jobs"]))
        {
            FlatFile.JOBNo = Request["Combine_jobs"].ToString();
            FlatFile.TRANSPORT_MODE = "";
            FlatFile.Ename = "Exp_Combine_FlatFile";
            FlatFile.Workingperiod = SELECT_BRANCH;
            ds = FlatFile.Retrieve_Export_All_Details();
            is_Annexure_Mode = FlatFile.result;

            Session.Remove("ds");
            Session["ds"] = ds;
        }
        else
        {
            FlatFile.JOBNo = ddlJobNo.SelectedValue.ToString();
            FlatFile.TRANSPORT_MODE = "";
            FlatFile.Ename = "FlatFile";
            FlatFile.Workingperiod = SELECT_BRANCH;
            ds = FlatFile.Retrieve_Export_All_Details();
            is_Annexure_Mode = FlatFile.result;

            Session["ds"] = ds;
        }
        if (is_Annexure_Mode == 1)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                //JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//
                string SB_dt = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
                if (SB_dt == "01/01/1900")
                {
                    SB_dt = "";
                }
                SB_NO = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                SB_DATE = SB_dt;
                //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//

                JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString().Replace("19000101", "");
                DDMMYY_JOBDATE = ds.Tables[0].Rows[0]["JOBDT_DDMMYY"].ToString().Replace("010100", "");


                TRANSPORT_MODE = dt.Trim(ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString());

                CUSTOMS_HOUSE = dt.Trim(ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString());

                SB_TYPE = dt.Trim(ds.Tables[0].Rows[0]["SB_TYPE"].ToString());

                EXPORTER_NAME = dt.Trim(ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString());
                BRANCH_NO = dt.Trim(ds.Tables[0].Rows[0]["BRANCH_NO"].ToString());
                IEC_NO = dt.Trim(ds.Tables[0].Rows[0]["IEC_NO"].ToString());
                ADDRESS1 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS1"].ToString());
                ADDRESS2 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS2"].ToString());
                ADDRESS3 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS3"].ToString());
                ADDRESS4 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS4"].ToString());
                ADDRESS5 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS5"].ToString());

                TYPE_OF_EXPORTER = dt.Trim(ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString());

                ADCODE = dt.Trim(ds.Tables[0].Rows[0]["ADCODE"].ToString());
                BANK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString());
                DRAWBACK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString());
                CONSIGNEE_NAME = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString());

                CONSIGNEE_ADD1 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString());

                CONSIGNEE_ADD2 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString());

                //SECTION46_DESC = ds.Tables[0].Rows[0]["SECTION46_DESC"].ToString();

                CONSIGNEE_ADD3 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString());

                //FIRSTCHECK_DESC = ds.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString();

                CONSIGNEE_ADD4 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString());

                //GREEN_CHANNEL_DESC = ds.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString();

                CONSIGNEE_ADD5 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString());

                //KACHHA_BE_DESC = ds.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString();

                COUNTRY_DISCHARGE = dt.Trim(ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString());

                //SECTION48_DESC= ds.Tables[0].Rows[0]["SECTION48_DESC"].ToString();

                PORT_DISCHARGE = dt.Trim(ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString());

                COUNTRY_FINAL_DEST = dt.Trim(ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString());
                PORT_FINAL_DEST = dt.Trim(ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString());
                STATE_OF_EXPORT = dt.Trim(ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString());
                NFEI = dt.Trim(ds.Tables[0].Rows[0]["NFEI"].ToString());
                NFEI_TYPE = dt.Trim(dt.Split("-", ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString()));
                RBI_WAIVER_NO = dt.Trim(ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString());
                RBI_WAIVER_DATE = dt.Trim(ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString().Replace("19000101", ""));
              
                MARKS_NO = dt.Trim(ds.Tables[0].Rows[0]["MARKS_NO"].ToString().Replace("\r\n", " "));

                JOB_STATUS = ds.Tables[0].Rows[0]["JOB_STATUS"].ToString();
                Session.Remove("JOB_LOCK");
                Session["JOB_LOCK"] = JOB_STATUS;

                GROSS_WEIGHT = dt.Trim(ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString());
                UNIT_CODE = dt.Trim(ds.Tables[0].Rows[0]["UNIT_CODE"].ToString());
                NET_WEIGHT = dt.Trim(ds.Tables[0].Rows[0]["NET_WEIGHT"].ToString());
                NATURE_OF_CARGO = dt.Trim(ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString());
                MARKS_NOS = dt.Trim(ds.Tables[0].Rows[0]["MARKS_NOS"].ToString());
                TOTAL_PACKAGES = dt.Trim(ds.Tables[0].Rows[0]["TOTAL_PACKAGES"].ToString());
                ROTATION_NO = dt.Trim(ds.Tables[0].Rows[0]["ROTATION_NO"].ToString());
                ROTATION_DATE = dt.Trim(ds.Tables[0].Rows[0]["ROTATION_DATE"].ToString().Replace("19000101", ""));

                if (TRANSPORT_MODE == "Sea")
                {
                    LOOSE_PACKETS = dt.Trim(ds.Tables[0].Rows[0]["LOOSE_PACKETS"].ToString());
                    NO_CONTAINERS = dt.Trim(ds.Tables[0].Rows[0]["NO_CONTAINERS"].ToString());

                    ANNEX_SEA_FAC_STUFFED = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString());
                    ANNEX_SEA_SAMPLE_ACCOM = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString());
                    ANNEX_SEA_SEAL_TYPE = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString());

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
                    LOOSE_PACKETS = dt.Trim(ds.Tables[0].Rows[0]["LOOSE_PACKETS"].ToString());
                    NO_CONTAINERS = dt.Trim(ds.Tables[0].Rows[0]["NO_CONTAINERS"].ToString());

                    ANNEX_SEA_FAC_STUFFED = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString());
                    ANNEX_SEA_SAMPLE_ACCOM = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString());
                    ANNEX_SEA_SEAL_TYPE = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString());

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
                    ANNEX_AIR_MAWB_NO = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString());
                    ANNEX_AIR_HAWB_NO = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString());
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

            if (ds.Tables[0].Rows.Count > 0)
            {
                //JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//
                string SB_dt = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
                if (SB_dt == "01/01/1900" || SB_dt == "19000101")
                {
                    SB_dt = "";
                }
                SB_NO = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                SB_DATE = SB_dt;
                //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//
                JOBDATE = dt.Trim(ds.Tables[0].Rows[0]["JOBDATE"].ToString().Replace("19000101", ""));
                DDMMYY_JOBDATE = dt.Trim(ds.Tables[0].Rows[0]["JOBDT_DDMMYY"].ToString().Replace("010100", ""));

                TRANSPORT_MODE = dt.Trim(ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString());

                CUSTOMS_HOUSE = dt.Trim(ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString());

                SB_TYPE = dt.Trim(ds.Tables[0].Rows[0]["SB_TYPE"].ToString());

                EXPORTER_NAME = dt.Trim(ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString());
                BRANCH_NO = dt.Trim(ds.Tables[0].Rows[0]["BRANCH_NO"].ToString());
                IEC_NO = dt.Trim(ds.Tables[0].Rows[0]["IEC_NO"].ToString());
                ADDRESS1 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS1"].ToString());
                ADDRESS2 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS2"].ToString());
                ADDRESS3 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS3"].ToString());
                ADDRESS4 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS4"].ToString());
                ADDRESS5 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS5"].ToString());

                TYPE_OF_EXPORTER = dt.Trim(ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString());

                ADCODE = dt.Trim(ds.Tables[0].Rows[0]["ADCODE"].ToString());
                BANK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString());
                DRAWBACK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString());
                CONSIGNEE_NAME = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString());

                CONSIGNEE_ADD1 =dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString());

                CONSIGNEE_ADD2 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString());

                //SECTION46_DESC = ds.Tables[0].Rows[0]["SECTION46_DESC"].ToString();

                CONSIGNEE_ADD3 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString());

                //FIRSTCHECK_DESC = ds.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString();

                CONSIGNEE_ADD4 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString());

                //GREEN_CHANNEL_DESC = ds.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString();

                CONSIGNEE_ADD5 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString());

                //KACHHA_BE_DESC = ds.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString();

                COUNTRY_DISCHARGE = dt.Trim(ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString());

                //SECTION48_DESC= ds.Tables[0].Rows[0]["SECTION48_DESC"].ToString();

                PORT_DISCHARGE = dt.Trim(ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString());

                COUNTRY_FINAL_DEST = dt.Trim(ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString());
                PORT_FINAL_DEST = dt.Trim(ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString());
                STATE_OF_EXPORT = dt.Trim(ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString());
                NFEI = dt.Trim(ds.Tables[0].Rows[0]["NFEI"].ToString());
                NFEI_TYPE = dt.Trim(dt.Split("-", ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString()));

                RBI_WAIVER_NO = dt.Trim(ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString());
                RBI_WAIVER_DATE = dt.Trim(ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString().Replace("19000101", ""));
                MARKS_NO = dt.Trim(ds.Tables[0].Rows[0]["MARKS_NO"].ToString().Replace("\r\n", " "));

                JOB_STATUS = ds.Tables[0].Rows[0]["JOB_STATUS"].ToString();
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
       
    }
    public void Get_Admin_Master_Codes()
    {
        
        //Seal Type
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

        dsImp_Exp=Imp_Exp.RetrieveAll_Imp_exp_master();
        if (dsImp_Exp.Tables[0].Rows.Count > 0)
        {
            EXPORTER_CLASS = dsImp_Exp.Tables[0].Rows[0]["TYPE"].ToString();
            //if (EXPORTER_CLASS == "O")
            //{
            //    EXPORTER_CLASS = "P";
            //}
            //updated 22 may 2013
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
            STATE_OF_EXPORT =dt.Trim(dt_UserRights.Tables[0].Rows[0]["STATE_CODE"].ToString());
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
            COUNTRY_DISCHARGE =dt.Trim(dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString());
        }
        view1 = dss.Tables[1].DefaultView;

        view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-",COUNTRY_FINAL_DEST) + "'";

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
        
        
        //view1 = dss.Tables[2].DefaultView;
        //if (TRANSPORT_MODE == "Air")
        //{

        //    view1.RowFilter = "PORT_NAME = '" + split.Split("-",PORT_DISCHARGE) + "' and len(PORT_CODE) = 3";
        //    DataSet ds2 = new DataSet();

        //    ds2.Tables.Add(view1.ToTable());
        //    if (ds2.Tables[0].Rows.Count > 0)
        //    {
        //        PORT_DISCHARGE = dt.Trim(ds2.Tables[0].Rows[0]["PORT_CODE"].ToString());
        //    }

        //    view1.RowFilter = "PORT_NAME = '" + split.Split("-",PORT_FINAL_DEST) + "' and len(PORT_CODE) = 3";
        //    DataSet ds3 = new DataSet();

        //    ds3.Tables.Add(view1.ToTable());
        //    if (ds3.Tables[0].Rows.Count > 0)
        //    {
        //        PORT_FINAL_DEST = dt.Trim(ds3.Tables[0].Rows[0]["PORT_CODE"].ToString());
        //    }
        //}
        //else
        //{

        //    view1.RowFilter = "PORT_NAME = '" + split.Split("-",PORT_DISCHARGE) + "' and len(PORT_CODE) = 5";
        //    DataSet ds4 = new DataSet();

        //    ds4.Tables.Add(view1.ToTable());

        //    if (ds4.Tables[0].Rows.Count > 0)
        //    {
        //        PORT_DISCHARGE = dt.Trim(ds4.Tables[0].Rows[0]["PORT_CODE"].ToString());
        //    }
        //    view1.RowFilter = "PORT_NAME = '" + split.Split("-",PORT_FINAL_DEST) + "' and len(PORT_CODE) = 5";
        //     DataSet ds5 = new DataSet();

        //    ds5.Tables.Add(view1.ToTable());

        //    if (ds5.Tables[0].Rows.Count > 0)
        //    {
        //        PORT_FINAL_DEST = dt.Trim(ds5.Tables[0].Rows[0]["PORT_CODE"].ToString());
        //    }
        //}
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        if (Rdhelp.SelectedValue.ToString() == "No")
        {
            Flatfile_gen();
            gv_Details.DataSource = null;
            gv_Details.DataBind();
            lbltablename.Text = string.Empty;
        }
        else
        {
            DataSet ds_A = new DataSet();
            
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_Flat_File_DETAILS";
            EV.Branch_Type = SELECT_BRANCH;
            ds_A = EV.EXP_Data_Select();

            if (ds_A.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds_A.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Error Page Details";
                laod_Flat_File_Show();
            }
            else 
            {
                if (General_Details() == 1)
                {
                        if (Invoice_Details() == 1)
                        {
                            if (AR4() == 1)
                            {
                                if (Invoice_Item() == 1)
                                {
                                    if (Item_Details() == 1)
                                    {
                                        if (Item_Special_Charaters() == 1)
                                        {
                                            if (Item_Cess_Details() == 1)
                                            {
                                                if (Item_Lic() == 1)
                                                {
                                                    //if (Item_Lic_val_chk() == 1)
                                                    //{

                                                        Flatfile_gen();
                                                        /*imgbtnFlatFile.Visible = true;
                                                        btnSubmission.Visible = true;*/
                                                    //}
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                   
                }
            }
        }
    }

    private int General_Details()
    {
        int G = 1;
        DataSet ds_1 = new DataSet();

        EV.Jobno = ddlJobNo.SelectedValue.ToString();
        EV.Flag = "EXP_GENERAL_DETAILS";
        EV.Branch_Type = SELECT_BRANCH;
        ds_1 = EV.EXP_Data_Select();

        if (ds_1.Tables[0].Rows.Count > 0)
        {
            DataSet ds_2 = new DataSet();
            String xmlData = ConvertDataTableToXML(ds_1.Tables[0]);
            EV.Xml_D = xmlData;
            ds_2 = EV.EXP_Admin_Select();

            if (ds_2.Tables[0].Rows.Count > 0)//G
            {
                gv_Details.DataSource = ds_2.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur General Details page";
                laod_Flat_File_Show();
                G = 0;
            }
            
        }

        return G;
    }
    private int Invoice_Details()
    {
        int INV = 1;
        DataSet ds_4 = new DataSet();
        EV.Flag = "EXP_EXCHANGE_RATE";
        ds_4 = EV.EXP_Admin_Select();

        if (ds_4.Tables[0].Rows.Count > 0)//AE
        {
            DataSet ds_5 = new DataSet();
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_INVOICE_DETAILS";
            EV.Branch_Type = SELECT_BRANCH;
            String xmlData_I = ConvertDataTableToXML(ds_4.Tables[0]);
            EV.Xml_D = xmlData_I;
            ds_5 = EV.EXP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Invoice Details page";
                laod_Flat_File_Show();
                INV = 0;
            }
        }
        return INV;
    }
    private int AR4()
    {
        int AR4 = 1;
         DataSet ds_5 = new DataSet();
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_AR4_DETAILS";
            EV.Branch_Type = SELECT_BRANCH;
            EV.Xml_D = "";
            ds_5 = EV.EXP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur AR4 Details page";
                laod_Flat_File_Show();
                AR4 = 0;
            }
        return AR4;
    }
    private int Invoice_Item()
    {
        int Inv_Item = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = ddlJobNo.SelectedValue.ToString();
        EV.Flag = "EXP_Invoice_Item";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Details.DataSource = ds_5.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");

            lbltablename.Text = "* Check Ur Invoice Details Entry page";
            laod_Flat_File_Show();
            Inv_Item = 0;
        }
        return Inv_Item;
    }
    private int Item_Details()
    {
        int Item = 1;
        DataSet ds_6 = new DataSet();
        EV.Jobno = ddlJobNo.SelectedValue.ToString();
        EV.Flag = "EXP_ITEM_DETAILS_ADMIN";
        EV.Branch_Type = SELECT_BRANCH;
        ds_6 = EV.EXP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            EV.Xml_D = xmlData_Item;
            EV.Flag = "IMP_Items_Details";
            ds_7 = EV.EXP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds_7.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Item Details Page";
                laod_Flat_File_Show();
                Item = 0;
            }
        }
        else
        {
            Item = 0;
        }
        return Item;
    }
    private int Item_Special_Charaters()
    {
        int CR = 1;
        DataSet ds_12 = new DataSet();
        EV.Jobno = ddlJobNo.SelectedValue.ToString();
        EV.Flag = "Item_Special_Character";
        EV.Branch_Type = SELECT_BRANCH;
        ds_12 = EV.EXP_Data_Select();
        if (ds_12.Tables[0].Rows.Count > 0)
        {
            gv_Details.DataSource = ds_12.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");
            lbltablename.Text = "* Check Ur Item Description Special Character";
            laod_Flat_File_Show();
            CR = 0;
        }
        return CR;
    }
    private int Item_Cess_Details()
    {
        int Item = 1;
        DataSet ds_6 = new DataSet();
        EV.Jobno = ddlJobNo.SelectedValue.ToString();
        EV.Flag = "EXP_ITEM_CESS_DETAILS";
        EV.Branch_Type = SELECT_BRANCH;
        ds_6 = EV.EXP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            gv_Details.DataSource = ds_6.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");

            lbltablename.Text = "* Check Ur Item CESS Details Page";
            laod_Flat_File_Show();
            Item = 0;
        }
        
        return Item;
    }
    private int Item_Lic()
    {
        int I_Lic = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = ddlJobNo.SelectedValue.ToString();
        EV.Flag = "EXP_ITEM_LIC_DETAILS";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Details.DataSource = ds_5.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");

            lbltablename.Text = "* Check Ur Item License Details Page";
            laod_Flat_File_Show();
            I_Lic = 0;
        }
        return I_Lic;
    }
    private int Item_Lic_val_chk()
    {
        int Lic_val_chk = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = ddlJobNo.SelectedValue.ToString();
        EV.Flag = "EXP_ITEM_LIC_VAL_DETAILS";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Details.DataSource = ds_5.Tables[0];
            gv_Details.DataBind();
            gv_Details.Attributes.Add("Width", "100%");

            lbltablename.Text = "* Check Ur Item License Details Page";
            laod_Flat_File_Show();
            Lic_val_chk = 0;
        }
        return Lic_val_chk;
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
    private void laod_Flat_File_Show()
    {
        imgbtnFlatFile.Visible = false;
        btnSubmission.Visible = false;
    }


    private void Flatfile_gen()
    {
        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            if (hdn_Check_PMV.Value == "Yes")
            {
                Joblock();
                if (Session["USER_JOB_LOCK"].ToString() == "Yes")//Company lock chk
                {
                    Admin_lock();
                }
                else if (Session["USER_JOB_LOCK"].ToString() == "No" || Session["USER_JOB_LOCK"] == null || Session["USER_JOB_LOCK"] == "")
                {
                    Only_admin_lock_Chk();
                }
            }
            else
            {
                Alert_msg("First you generate Checklist");
            }
        }
        else
        {
            Alert_msg("Select the Job Number.");
        }

    }
    private void Only_admin_lock_Chk()
    {
        if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
        {
            JOB_LOCK = Session["JOB_LOCK"].ToString();
            if (Convert.ToInt32(JOB_LOCK) == 1)
            {
                btnSearch.Enabled = false;
                btnSubmission.Enabled = false;

                imgbtnFlatFile.Enabled = false;
                btnSubmission.Enabled = false;
               // btn_Outlookmail_Submission.Enabled = false;
                Alert_msg("This Job is Locked by Admin");
            }
            else
            {
                //generate flat file
                Flat_File_Generation();
               
            }
        }
        else
        { 
           //geneate flat file
            Flat_File_Generation();
        }

    }
    private void Admin_lock()
    {
        if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
        {
            JOB_LOCK = Session["JOB_LOCK"].ToString();
            if (Convert.ToInt32(JOB_LOCK) == 1)
            {
                btnSearch.Enabled = false;
                btnSubmission.Enabled = false;

                imgbtnFlatFile.Enabled = false;
                btnSubmission.Enabled = false;
                //btn_Outlookmail_Submission.Enabled = false;
                Alert_msg("This Job is Locked by Admin");
            }
            else
            {
                //user joblock chk
                User_lock_Chk();
            }

        }
        else
        {
            //user job lock chk
            User_lock_Chk();
        }

    }
    private void User_lock_Chk()
    {
        if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
        {
            if (Session["JOB_USER"] != null && Session["JOB_USER"] != "")
            {
                if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
                {
                    JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                    if (JOB_RELEASE == "No")
                    {
                        MP_U.Show();
                        lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                       // btnSubmission.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        imgbtnFlatFile.Enabled = false;
                        btnSubmission.Enabled = false;
                       // btn_Outlookmail_Submission.Enabled = false;
                    }
                    else
                    { 
                      //generate flat file
                        Flat_File_Generation();
                    }
                }
                else
                { 
                   // generate flat file
                    Flat_File_Generation();
                }

            }
            else
            {
                //Generate flat file
                Flat_File_Generation();
            }
        }
        else
        { 
           // generate flat file
            Flat_File_Generation();
        }

    }
    protected void imgbtnFlatFile_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            IS_Imgbtn = "1";
            imgbtnFlatFile.Visible = false;
            btnSubmission.Visible = false;
           // btn_Outlookmail_Submission.Visible = false;
            string[] filePaths = Directory.GetFiles(errorFolder);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        }
    protected void imgbtnFlatFile_Old_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            SB_Details();
            string attachment = "attachment; filename=" + Session["createflename"].ToString();

            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "text/plain";

            logFileName = ddlJobNo.SelectedValue.ToString() + ".sb";

            createfilename = logFileName;
            Session["createflename"] = logFileName;
            StringWriter sw1 = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw1);

            DateTime date = System.DateTime.Now;
            string datestringg = string.Format("{0:yyyyMMdd}", date);

            DateTime tt = System.DateTime.Now;

            string time = string.Format("{0:hhmm}", tt);

            sw1.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + ch + "CACHE01" + ch + ddlJobNo.SelectedValue.ToString() + DDMMYY_JOBDATE + ch + JOBDATE + ch + time);

            sw1.WriteLine("<TABLE>SB");

            sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + "Type of Exporter" + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD5 + ch + CONSIGNEE_ADD4 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + CUSTOMS_HOUSE + ch + PORT_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + COUNTRY_DISCHARGE + ch + PORT_FINAL_DEST + ch + "Seal Type" + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NOS + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

            int i = 0;
            if (ds.Tables[1].Rows.Count > 0)
            {
                sw1.WriteLine("<TABLE>INVOICE");
                while (ds.Tables[1].Rows.Count > i)
                {
                    INVOICE_SLNO = ds.Tables[1].Rows[i]["INVOICE_SLNO"].ToString();
                    INVOICE_NO = ds.Tables[1].Rows[i]["INVOICE_NO"].ToString();
                    INVOICE_DATE = ds.Tables[1].Rows[i]["INVOICE_DATE"].ToString().Replace("19000101", "");
                    PAYMENT_METHOD = ds.Tables[1].Rows[i]["PAYMENT_METHOD"].ToString();
                    PERIOD_PAYMENT = ds.Tables[1].Rows[i]["PERIOD_PAYMENT"].ToString();
                    INVOICE_VALUE = ds.Tables[1].Rows[i]["INVOICE_VALUE"].ToString();
                    INVOICE_CURRENCY = ds.Tables[1].Rows[i]["INVOICE_CURRENCY"].ToString();
                    EXCHANGE_RATE = ds.Tables[1].Rows[i]["EXCHANGE_RATE"].ToString();
                    CONTRACT_NO = ds.Tables[1].Rows[i]["CONTRACT_NO"].ToString();
                    TERMS = ds.Tables[1].Rows[i]["TERMS"].ToString();
                    BUYER = ds.Tables[1].Rows[i]["BUYER"].ToString();

                    BUYER_NAME = ds.Tables[1].Rows[i]["BUYER_NAME"].ToString();
                    BUYER_ADDRESS = ds.Tables[1].Rows[i]["BUYER_ADDRESS"].ToString();
                    BUYER_ADDRESS1 = ds.Tables[1].Rows[i]["BUYER_ADDRESS1"].ToString();
                    BUYER_ADDRESS2 = ds.Tables[1].Rows[i]["BUYER_ADDRESS2"].ToString();
                    BUYER_ADDRESS3 = ds.Tables[1].Rows[i]["BUYER_ADDRESS3"].ToString();
                    BUYER_ADDRESS4 = ds.Tables[1].Rows[i]["BUYER_ADDRESS4"].ToString();
                    COMMISSION_RATE = ds.Tables[1].Rows[i]["COMMISSION_RATE"].ToString();
                    COMMISSION_CHARGES = ds.Tables[1].Rows[i]["COMMISSION_CHARGES"].ToString();
                    COMMISSION_CURRENCY = ds.Tables[1].Rows[i]["COMMISSION_CURRENCY"].ToString();
                    FOB_RATE = ds.Tables[1].Rows[i]["FOB_RATE"].ToString();

                    FOB_CHARGES = ds.Tables[1].Rows[i]["FOB_CHARGES"].ToString();
                    FOB_CURRENCY = ds.Tables[1].Rows[i]["FOB_CURRENCY"].ToString();
                    PACKMISC_RATE = ds.Tables[1].Rows[i]["PACKMISC_RATE"].ToString();
                    PACKMISC_CHARGES = ds.Tables[1].Rows[i]["PACKMISC_CHARGES"].ToString();
                    PACKMISC_CURRENCY = ds.Tables[1].Rows[i]["PACKMISC_CURRENCY"].ToString();
                    OTHER_DEDUCTION_RATE = ds.Tables[1].Rows[i]["OTHER_DEDUCTION_RATE"].ToString();
                    OTHER_DEDUCTION_CHARGES = ds.Tables[1].Rows[i]["OTHER_DEDUCTION_CHARGES"].ToString();
                    OTHER_DEDUCTION_CURRENCY = ds.Tables[1].Rows[i]["OTHER_DEDUCTION_CURRENCY"].ToString();
                    FREIGHT_RATE = ds.Tables[1].Rows[i]["FREIGHT_RATE"].ToString();
                    FREIGHT_CHARGES = ds.Tables[1].Rows[i]["FREIGHT_CHARGES"].ToString();
                    FREIGHT_CURRENCY = ds.Tables[1].Rows[i]["FREIGHT_CURRENCY"].ToString();
                    INSURANCE_RATE = ds.Tables[1].Rows[i]["INSURANCE_RATE"].ToString();
                    INSURANCE_CHARGES = ds.Tables[1].Rows[i]["INSURANCE_CHARGES"].ToString();
                    INSURANCE_CURRENCY = ds.Tables[1].Rows[i]["INSURANCE_CURRENCY"].ToString();
                    WHEATHER_UNIT_PRICE = ds.Tables[1].Rows[i]["WHEATHER_UNIT_PRICE"].ToString();

                    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + INVOICE_NO + ch + INVOICE_DATE + ch + INVOICE_CURRENCY + ch + TERMS + ch + BUYER_NAME + ch + BUYER_ADDRESS + ch + BUYER_ADDRESS1 + ch + BUYER_ADDRESS2 + ch + BUYER_ADDRESS3 + ch + FREIGHT_CURRENCY + ch + FREIGHT_CHARGES + ch + INSURANCE_RATE + ch + INSURANCE_CURRENCY + ch + INSURANCE_CHARGES + ch + COMMISSION_RATE + ch + COMMISSION_CURRENCY + ch + COMMISSION_CHARGES + ch + FOB_RATE + ch + FOB_CURRENCY + ch + FOB_CHARGES + ch + OTHER_DEDUCTION_RATE + ch + OTHER_DEDUCTION_CURRENCY + ch + OTHER_DEDUCTION_CHARGES + ch + WHEATHER_UNIT_PRICE + ch + PACKMISC_CHARGES + ch + CONTRACT_NO + ch + PAYMENT_METHOD + ch + PERIOD_PAYMENT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                    i++;
                }
            }

            int f = 0;
            if (INVOICE_CURRENCY != "")
            {
                sw1.WriteLine("<TABLE>EXCHANGE");
                while (ds.Tables[9].Rows.Count > f)
                {

                    INVOICE_CURRENCY = ds.Tables[9].Rows[f]["INVOICE_CURRENCY"].ToString();
                    //EXCHANGE_RATE = ds.Tables[1].Rows[i]["EXCHANGE_RATE"].ToString();

                    if (INVOICE_CURRENCY != "")
                    {

                        erm.Invoice_Currency = INVOICE_CURRENCY;

                        erm.Ename = "Ex_Rate";
                        erm.EWorking_Period = Working_Period;

                        DataSet ds1 = new DataSet();

                        ds1 = erm.RetrieveAll_Exchange_master_INV_Currency();

                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            EXCHANGE_RATE = ds1.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
                            Currency_Name = ds1.Tables[0].Rows[0]["EXCHANGE_NAME"].ToString();
                            EXCHANGE_UNIT = ds1.Tables[0].Rows[0]["EXCHANGE_PER_UNIT"].ToString();

                        }
                    }
                    else
                    {
                        INVOICE_CURRENCY = "";
                        EXCHANGE_RATE = "";
                        Currency_Name = "";

                    }

                    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + Currency_Name + ch + EXCHANGE_UNIT + ch + EXCHANGE_RATE + ch + Effective_Date + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                    f++;
                }
            }

            int j = 0;
            if (ds.Tables[2].Rows.Count > 0)
            {
                sw1.WriteLine("<TABLE>ITEM");
                while (ds.Tables[2].Rows.Count > j)
                {
                    INVOICE_SLNO = ds.Tables[2].Rows[j]["INVOICE_SLNO"].ToString();
                    INVOICE_NO = ds.Tables[2].Rows[j]["INVOICE_NO"].ToString();
                    ITEM_SLNO = ds.Tables[2].Rows[j]["ITEM_SLNO"].ToString();
                    ITEM_DESCRIPTION1 = ds.Tables[2].Rows[j]["ITEM_DESCRIPTION1"].ToString();
                    ITEM_DESCRIPTION2 = ds.Tables[2].Rows[j]["ITEM_DESCRIPTION2"].ToString();
                    ITEM_DESCRIPTION3 = ds.Tables[2].Rows[j]["ITEM_DESCRIPTION3"].ToString();
                    RITCNO = ds.Tables[2].Rows[j]["RITCNO"].ToString();
                    ITEM_QTY = ds.Tables[2].Rows[j]["ITEM_QTY"].ToString();
                    ITEM_QTY_CODE = ds.Tables[2].Rows[j]["ITEM_QTY_CODE"].ToString();
                    ITEM_UNIT_PRICE = ds.Tables[2].Rows[j]["ITEM_UNIT_PRICE"].ToString();
                    ITEM_PER = ds.Tables[2].Rows[j]["ITEM_PER"].ToString();
                    ITEM_AMOUNT = ds.Tables[2].Rows[j]["ITEM_AMOUNT"].ToString();
                    ITEM_PMVVALUE = ds.Tables[2].Rows[j]["ITEM_PMVVALUE"].ToString();

                    ITEM_SCHEME_CODE = ds.Tables[2].Rows[j]["ITEM_SCHEME_CODE"].ToString();
                    ITEM_ACCESSORIES_DESC = ds.Tables[2].Rows[j]["ITEM_ACCESSORIES_DESC"].ToString();
                    ITEM_AR4_NO = ds.Tables[2].Rows[j]["ITEM_AR4_NO"].ToString();
                    ITEM_AR4_DATE = ds.Tables[2].Rows[j]["ITEM_AR4_DATE"].ToString().Replace("19000101", "");
                    ITEM_COMMISSION_RATE = ds.Tables[2].Rows[j]["ITEM_COMMISSION_RATE"].ToString();
                    ITEM_DIVISION = ds.Tables[2].Rows[j]["ITEM_DIVISION"].ToString();
                    ITEM_RANGE = ds.Tables[2].Rows[j]["ITEM_RANGE"].ToString();
                    ITEM_REMARKS = ds.Tables[2].Rows[j]["ITEM_REMARKS"].ToString();
                    ITEM_IECCODE = ds.Tables[2].Rows[j]["ITEM_IECCODE"].ToString();
                    ITEM_EXPORTER_NAME = ds.Tables[2].Rows[j]["ITEM_EXPORTER_NAME"].ToString();

                    BR_SLNO = ds.Tables[2].Rows[j]["BR_SLNO"].ToString();
                    ITEM_ADDRESS1 = ds.Tables[2].Rows[j]["ADDRESS1"].ToString();
                    ITEM_ADDRESS2 = ds.Tables[2].Rows[j]["ADDRESS2"].ToString();
                    ITEM_ADDRESS3 = ds.Tables[2].Rows[j]["ADDRESS3"].ToString();
                    ITEM_ADDRESS4 = ds.Tables[2].Rows[j]["ADDRESS4"].ToString();
                    ITEM_ADDRESS5 = ds.Tables[2].Rows[j]["ADDRESS5"].ToString();
                    ITEM_STR_CODE = ds.Tables[2].Rows[j]["ITEM_STR_CODE"].ToString();
                    REWARD_POINTS = ds.Tables[2].Rows[j]["REWARD_POINTS"].ToString();


                    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + ITEM_PMVVALUE + ch + "JOB Work Notification No" + ch + "Third Party" + ch + REWARD_POINTS);
                    j++;
                }
            }



            int K = 0;
            if (ITEM_EXPORTER_NAME != "")
            {
                sw1.WriteLine("<TABLE>THIRDPARTY");
                while (ds.Tables[2].Rows.Count > K)
                {
                    INVOICE_SLNO = ds.Tables[2].Rows[K]["INVOICE_SLNO"].ToString();
                    INVOICE_NO = ds.Tables[2].Rows[K]["INVOICE_NO"].ToString();
                    ITEM_SLNO = ds.Tables[2].Rows[K]["ITEM_SLNO"].ToString();

                    ITEM_IECCODE = ds.Tables[2].Rows[K]["ITEM_IECCODE"].ToString();
                    ITEM_EXPORTER_NAME = ds.Tables[2].Rows[K]["ITEM_EXPORTER_NAME"].ToString();

                    BR_SLNO = ds.Tables[2].Rows[K]["BR_SLNO"].ToString();
                    ITEM_ADDRESS1 = ds.Tables[2].Rows[K]["ADDRESS1"].ToString();
                    ITEM_ADDRESS2 = ds.Tables[2].Rows[K]["ADDRESS2"].ToString();
                    ITEM_ADDRESS3 = ds.Tables[2].Rows[K]["ADDRESS3"].ToString();
                    ITEM_ADDRESS4 = ds.Tables[2].Rows[K]["ADDRESS4"].ToString();
                    ITEM_ADDRESS5 = ds.Tables[2].Rows[K]["ADDRESS5"].ToString();
                    ITEM_STR_CODE = ds.Tables[2].Rows[K]["ITEM_STR_CODE"].ToString();
                    REWARD_POINTS = ds.Tables[2].Rows[K]["REWARD_POINTS"].ToString();

                    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_IECCODE + ch + BR_SLNO + ch + ITEM_EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS5 + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                    K++;
                }
            }


            if (ds.Tables[3].Rows.Count > 0)
            {
                //JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();

                INVOICE_SLNO = ds.Tables[3].Rows[0]["INVOICE_SLNO"].ToString();

                ITEM_SLNO = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString();

                //SCHEME_CODE = ds.Tables[3].Rows[0]["SCHEME_CODE"].ToString();

                DRAWBACK_SLNO = ds.Tables[3].Rows[0]["DRAWBACK_SLNO"].ToString();

                DRAWBACK_QTY = ds.Tables[3].Rows[0]["DRAWBACK_QTY"].ToString();
                //DRAWBACK_UNIT = ds.Tables[3].Rows[0]["DRAWBACK_UNIT"].ToString();
                //DRAWBACK_NOOFUNITS = ds.Tables[3].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();

                //DRAWBACK_RATE = ds.Tables[3].Rows[0]["DRAWBACK_RATE"].ToString();
                //DRAWBACK_CAPS = ds.Tables[3].Rows[0]["DRAWBACK_CAPS"].ToString();
                //DRAWBACK_DESC = ds.Tables[3].Rows[0]["DRAWBACK_DESC"].ToString();

                sw1.WriteLine("<TABLE>DBK");
                sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + DRAWBACK_SLNO + ch + DRAWBACK_QTY + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
            }


            int m = 0;
            if (ds.Tables[4].Rows.Count > 0)
            {
                sw1.WriteLine("<TABLE>LICENSE");
                while (ds.Tables[4].Rows.Count > m)
                {
                    INVOICE_SLNO = ds.Tables[4].Rows[m]["INVOICE_SLNO"].ToString();
                    ITEM_SLNO = ds.Tables[4].Rows[m]["ITEM_SLNO"].ToString();
                    SCHEME_CODE = ds.Tables[4].Rows[m]["SCHEME_CODE"].ToString();
                    SCHEME = ds.Tables[4].Rows[m]["SCHEME"].ToString();
                    LICENSE_R_SL_NO = ds.Tables[4].Rows[m]["LICENSE_R_SL_NO"].ToString();
                    LICENSE_NO = ds.Tables[4].Rows[m]["LICENSE_NO"].ToString();
                    LICENSE_DATE = ds.Tables[4].Rows[m]["LICENSE_DATE"].ToString();

                    LICENSE_E_SL_NO = ds.Tables[4].Rows[m]["LICENSE_E_SL_NO"].ToString();
                    LICENSE_EXP_QTY = ds.Tables[4].Rows[m]["LICENSE_EXP_QTY"].ToString();
                    LICENSE_EXP_UNIT = ds.Tables[4].Rows[m]["LICENSE_EXP_UNIT"].ToString();
                    LICENSE_IMP_ITEM_SL_NO = ds.Tables[4].Rows[m]["LICENSE_IMP_ITEM_SL_NO"].ToString();
                    LICENSE_IMP_DESC = ds.Tables[4].Rows[m]["LICENSE_IMP_DESC"].ToString();

                    LICENSE_IMP_QTY = ds.Tables[4].Rows[m]["LICENSE_IMP_QTY"].ToString();
                    LICENSE_IMP_UNIT = ds.Tables[4].Rows[m]["LICENSE_IMP_UNIT"].ToString();
                    LICENSE_IMP_TYPE = ds.Tables[4].Rows[m]["LICENSE_IMP_TYPE"].ToString();

                    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + LICENSE_NO + ch + LICENSE_DATE + ch + LICENSE_E_SL_NO + ch + LICENSE_IMP_ITEM_SL_NO + ch + LICENSE_IMP_QTY + ch + LICENSE_EXP_QTY + ch + LICENSE_IMP_TYPE + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                    m++;
                }
            }

            int n = 0;
            if (ds.Tables[5].Rows.Count > 0)
            {
                sw1.WriteLine("<TABLE>JOBWORK");
                while (ds.Tables[5].Rows.Count > n)
                {
                    INVOICE_SLNO = ds.Tables[5].Rows[n]["INVOICE_SLNO"].ToString();
                    ITEM_SLNO = ds.Tables[5].Rows[n]["ITEM_SLNO"].ToString();
                    SCHEME_CODE = ds.Tables[5].Rows[n]["SCHEME_CODE"].ToString();
                    NOTIFICATION_NO = ds.Tables[5].Rows[n]["NOTIFICATION_NO"].ToString();
                    BE_NO = ds.Tables[5].Rows[n]["BE_NO"].ToString();
                    BE_DATE = ds.Tables[5].Rows[n]["BE_DATE"].ToString().Replace("19000101", "");
                    BE_INV_SLNO = ds.Tables[5].Rows[n]["BE_INV_SLNO"].ToString();

                    BE_INV_NO = ds.Tables[5].Rows[n]["BE_INV_NO"].ToString();
                    BE_ITEM_NO = ds.Tables[5].Rows[n]["BE_ITEM_NO"].ToString();
                    BE_PORT_CODE = ds.Tables[5].Rows[n]["BE_PORT_CODE"].ToString();
                    QTY = ds.Tables[5].Rows[n]["QTY"].ToString();
                    UNIT = ds.Tables[5].Rows[n]["UNIT"].ToString();

                    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + BE_NO + ch + BE_DATE + ch + BE_INV_SLNO + ch + BE_INV_NO + ch + BE_ITEM_NO + ch + BE_PORT_CODE + ch + QTY + ch + UNIT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                    n++;
                }
            }


            int a = 0;
            if (ITEM_AR4_NO != "")
            {
                sw1.WriteLine("<TABLE>AR4");
                while (ds.Tables[2].Rows.Count > a)
                {
                    INVOICE_SLNO = ds.Tables[2].Rows[a]["INVOICE_SLNO"].ToString();

                    ITEM_SLNO = ds.Tables[2].Rows[a]["ITEM_SLNO"].ToString();

                    ITEM_AR4_NO = ds.Tables[2].Rows[a]["ITEM_AR4_NO"].ToString();
                    ITEM_AR4_DATE = ds.Tables[2].Rows[a]["ITEM_AR4_DATE"].ToString().Replace("19000101", "");
                    ITEM_COMMISSION_RATE = ds.Tables[2].Rows[a]["ITEM_COMMISSION_RATE"].ToString();
                    ITEM_DIVISION = ds.Tables[2].Rows[a]["ITEM_DIVISION"].ToString();
                    ITEM_RANGE = ds.Tables[2].Rows[a]["ITEM_RANGE"].ToString();
                    ITEM_REMARKS = ds.Tables[2].Rows[a]["ITEM_REMARKS"].ToString();

                    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_AR4_NO + ch + ITEM_AR4_DATE + ch + ITEM_COMMISSION_RATE + ch + ITEM_DIVISION + ch + ITEM_RANGE + ch + ITEM_REMARKS);

                    a++;
                }
            }



            int b = 0;
            if (ds.Tables[6].Rows.Count > 0)
            {
                sw1.WriteLine("<TABLE>PACKINGLIST");
                while (ds.Tables[6].Rows.Count > b)
                {
                    ANNEX_SEA_PACK_FROM = ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_FROM"].ToString();

                    ANNEX_SEA_PACK_TO = ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_TO"].ToString();

                    ANNEX_SEA_PACK_PACKAGETYPE = ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString();

                    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + ANNEX_SEA_PACK_FROM + ch + ANNEX_SEA_PACK_TO + ch + ANNEX_SEA_PACK_PACKAGETYPE);

                    b++;
                }
            }

            if (ROTATION_NO != "")
            {
                sw1.WriteLine("<TABLE>ROTATION");
                sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + ROTATION_DATE + ch + ROTATION_NO);
            }



            if (ds.Tables[7].Rows.Count > 0)
            {
                ANNEX_EXPORTERNAME = ds.Tables[7].Rows[0]["ANNEX_EXPORTERNAME"].ToString();

                ANNEX_IECCODE = ds.Tables[7].Rows[0]["ANNEX_IECCODE"].ToString();

                ANNEX_BR_SLNO = ds.Tables[7].Rows[0]["ANNEX_BR_SLNO"].ToString();

                ANNEX_EXAM_DATE = ds.Tables[7].Rows[0]["ANNEX_EXAM_DATE"].ToString();

                ANNEX_EXAM_OFFICER = ds.Tables[7].Rows[0]["ANNEX_EXAM_OFFICER"].ToString();

                ANNEX_EXAM_DESIGN = ds.Tables[7].Rows[0]["ANNEX_EXAM_DESIGN"].ToString();
                ANNEX_SUPER_NAME = ds.Tables[7].Rows[0]["ANNEX_SUPER_NAME"].ToString();
                ANNEX_SUPER_DESIGN = ds.Tables[7].Rows[0]["ANNEX_SUPER_DESIGN"].ToString();

                ANNEX_COMMISSION_RATE = ds.Tables[7].Rows[0]["ANNEX_COMMISSION_RATE"].ToString();
                ANNEX_DIVISION = ds.Tables[7].Rows[0]["ANNEX_DIVISION"].ToString();
                ANNEX_RANGE = ds.Tables[7].Rows[0]["ANNEX_RANGE"].ToString();

                ANNEX_VERIFIED_EXAM_OFFICER = ds.Tables[7].Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString();
                ANNEX_SAMPLE_DRAWN = ds.Tables[7].Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString();
                ANNEX_SEAL_NO = ds.Tables[7].Rows[0]["ANNEX_SEAL_NO"].ToString();

                sw1.WriteLine("<TABLE>EOU");
                sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + ANNEX_IECCODE + ch + ANNEX_BR_SLNO + ch + ANNEX_EXAM_DATE + ch + ANNEX_EXAM_OFFICER + ch + ANNEX_EXAM_DESIGN + ch + ANNEX_SUPER_NAME + ch + ANNEX_SUPER_DESIGN + ch + ANNEX_COMMISSION_RATE + ch + ANNEX_DIVISION + ch + ANNEX_RANGE + ch + ANNEX_SEAL_NO + ch + ANNEX_VERIFIED_EXAM_OFFICER + ch + ANNEX_SAMPLE_DRAWN + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
            }

            //if (ANNEX_SEA_FAC_STUFFED != "")
            //{
            //    sw1.WriteLine("<TABLE>STUFF");
            //    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + ANNEX_SEA_FAC_STUFFED + ch + ANNEX_SEA_SAMPLE_ACCOM);
            //}

            int c = 0;
            if (ds.Tables[8].Rows.Count > 0)
            {
                sw1.WriteLine("<TABLE>CONTAINER");
                while (ds.Tables[8].Rows.Count > c)
                {
                    ANNEX_SEA_CON_CONTAINERNO = ds.Tables[8].Rows[c]["ANNEX_SEA_CON_CONTAINERNO"].ToString();

                    ANNEX_SEA_CON_SIZE = ds.Tables[8].Rows[c]["ANNEX_SEA_CON_SIZE"].ToString();

                    ANNEX_SEA_CON_TYPE = ds.Tables[8].Rows[c]["ANNEX_SEA_CON_TYPE"].ToString();

                    ANNEX_SEA_CON_EXCISE_SEALNO = ds.Tables[8].Rows[c]["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString();

                    ANNEX_SEA_CON_SEAL_DATE = ds.Tables[8].Rows[c]["ANNEX_SEA_CON_SEAL_DATE"].ToString().Replace("19000101", "");

                    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + ANNEX_SEA_CON_CONTAINERNO + ch + ANNEX_SEA_CON_SIZE + ch + ANNEX_SEA_CON_EXCISE_SEALNO + ch + ANNEX_SEA_CON_SEAL_DATE);

                    c++;
                }
            }


            int d = 0;
            if (ITEM_STR_CODE != "")
            {
                sw1.WriteLine("<TABLE>STR");
                while (ds.Tables[2].Rows.Count > d)
                {
                    INVOICE_SLNO = ds.Tables[2].Rows[d]["INVOICE_SLNO"].ToString();

                    ITEM_SLNO = ds.Tables[2].Rows[d]["ITEM_SLNO"].ToString();

                    ITEM_STR_CODE = ds.Tables[2].Rows[d]["ITEM_STR_CODE"].ToString();

                    //ANNEX_SEA_CON_SEAL_DATE = ds.Tables[8].Rows[c]["ANNEX_SEA_CON_SEAL_DATE"].ToString().Replace("19000101", "");


                    sw1.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + ITEM_STR_CODE + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                    d++;
                }
            }

            sw1.WriteLine("<END-SB>");
            sw1.WriteLine("TREC" + ch + ddlJobNo.SelectedValue.ToString());

            //        DateTime dat = System.DateTime.Now;
            //        string datestring = string.Format("{0:dd/MM/yyyy}", dat);


            sw1.Close();
            sw1.Dispose();
            Response.Write(sw1.ToString());
            Response.Flush();
            // Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }
    protected void btnSubmission_Click(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
        if (hdlock_or_Not.Value == "True" && ddlJobNo.SelectedItem.Text != "Select")
        {
            SB_Details();
            string[] filePaths = Directory.GetFiles(errorFolder);
            string file = filePaths[0];

            mail(file);

            imgbtnFlatFile.Visible = true;
            btnSubmission.Visible = true;
            //btn_Outlookmail_Submission.Visible = true;
        }
        else
        {
            //imgbtn.Visible = false; -- 07-Oct-2016
        }

    }

    public void k(string file)
    {
        // Creates a new Outlook Application Instance
        Outlook.Application objOutlook = new Outlook.Application();
        // Creating a new Outlook Message from the Outlook Application Instance
        Outlook.MailItem mic = (Outlook.MailItem)(objOutlook.CreateItem(Outlook.OlItemType.olMailItem));
        mic.To = EMail_ID;
        mic.SaveAs(file, Outlook.OlSaveAsType.olMSG);
        mic.Display(true);

    }
    public void d()
    {
        Outlook.Application outlookApp = new Outlook.Application();
        Outlook._MailItem mailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
        mailItem.To = EMail_ID;

        // body, bcc etc...

        mailItem.Display(true);



    }
    public void DisplayOutlook(string file, string from_email_id)
    {
        Outlook.Application objApp = new Outlook.Application();
        Outlook.MailItem mail = null;
        mail = (Outlook.MailItem)objApp.CreateItem(Outlook.OlItemType.olMailItem);
        //The CreateItem method returns an object which has to be typecast to MailItem 
        //before using it.
        mail.Attachments.Add((object)file, Outlook.OlAttachmentType.olEmbeddeditem, 1, (object)"Attachment");
        //The parameters are explained below
        mail.To = CUSTOMS_HOUSE + "@icegate.gov.in";

        mail.Subject = "SB";

        mail.Display(true);

        //mail.CC="con@def.com";//All the mail lists have to be separated by the ';'
    }

    public string DisplayAccountInformation()
    {
        try
        {
            Outlook.Application application = new Outlook.Application();

            //Outlook.ApplicationClass application = new Outlook.ApplicationClass();


            // The Namespace Object (Session) has a collection of accounts.
            Outlook.Accounts accounts = application.Session.Accounts;

            // Concatenate a message with information about all accounts.
            StringBuilder builder = new StringBuilder();

            // Loop over all accounts and print detail account information.
            // All properties of the Account object are read-only.
            foreach (Outlook.Account account in accounts)
            {

                // The DisplayName property represents the friendly name of the account.
                builder.AppendFormat("DisplayName: {0}\n", account.DisplayName);

                // The UserName property provides an account-based context to determine identity.
                builder.AppendFormat("UserName: {0}\n", account.UserName);

                // The SmtpAddress property provides the SMTP address for the account.
                builder.AppendFormat("SmtpAddress: {0}\n", account.SmtpAddress);

              Outlook_From_mail_Address = account.SmtpAddress;

                // The AccountType property indicates the type of the account.
                builder.Append("AccountType: ");
                switch (account.AccountType)
                {

                    case Outlook.OlAccountType.olExchange:
                        builder.AppendLine("Exchange");
                        break;

                    case Outlook.OlAccountType.olHttp:
                        builder.AppendLine("Http");
                        break;

                    case Outlook.OlAccountType.olImap:
                        builder.AppendLine("Imap");
                        break;

                    case Outlook.OlAccountType.olOtherAccount:
                        builder.AppendLine("Other");
                        break;

                    case Outlook.OlAccountType.olPop3:
                        builder.AppendLine("Pop3");
                        break;
                }

                builder.AppendLine();
            }

            // Display the account information.
            //System.Windows.Forms.MessageBox.Show(builder.ToString());
            if (Outlook_From_mail_Address != "")
            {
                SB_Details();
                string[] filePaths = Directory.GetFiles(errorFolder);
                string file = filePaths[0];

                Outlook.Application objApp = new Outlook.Application();
                Outlook.MailItem mail = null;
                mail = (Outlook.MailItem)objApp.CreateItem(Outlook.OlItemType.olMailItem);
                //The CreateItem method returns an object which has to be typecast to MailItem 
                //before using it.
                mail.Attachments.Add((object)file, Outlook.OlAttachmentType.olEmbeddeditem, 1, (object)"Attachment");
                //The parameters are explained below
                //mail.To = CUSTOMS_HOUSE + "@icegate.gov.in";
                mail.To = "sathish34@gmail.com";
                mail.Subject = "SB";
                mail.Display(true);
            }
            else
            {
                //Alert_msg("CV not forwarded. An instance of Ms Outlook needs to be running to send email, Mail error");
                Alert_msg("not opened. An instance of Ms Outlook needs to be running to send email, Mail error");
            }
        }//end of try block
        catch (Exception ex)
        {
        }//end of catch
        return Outlook_From_mail_Address;
    }

        //method to send email to outlook
    //public void sendEMailThroughOUTLOOK(string file)
    //{
    //    try
    //    {
    //        // Create the Outlook application.
    //        Outlook.Application oApp = new Outlook.Application();
    //        // Create a new mail item.
    //        Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
    //        // Set HTMLBody. 
    //        //add the body of the email
    //        oMsg.HTMLBody = "SB";
    //        //Add an attachment.
    //        String sDisplayName = "MyAttachment";
    //        int iPosition = (int)oMsg.Body.Length + 1;
    //        int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
    //        //now attached the file
    //        Outlook.Attachment oAttach = oMsg.Attachments.Add(file, iAttachType, iPosition, sDisplayName);
    //        //Subject line
    //        oMsg.Subject = "SB";
    //        // Add a recipient.
    //        Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
    //        // Change the recipient in the next line if necessary.
    //        //Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(CUSTOMS_HOUSE + "@icegate.gov.in");
    //        Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add("sathish34@gmail.com");
    //        //oMsg.BCC = "sathishkumar8789@gmail.com";
          
    //        oRecip.Resolve();
    //        // Send.
    //        oMsg.Send();
    //        // Clean up.
    //        oRecip = null;
    //        oRecips = null;
    //        oMsg = null;
    //        oApp = null;
    //    }//end of try block
    //    catch (Exception ex)
    //    {
    //    }//end of catch
    //}//end of Email Method


    protected void btn_Outlookmail_Submission_Click(object sender, EventArgs e)
    {

        btnSearch_Click(sender, e);

        if (hdlock_or_Not.Value == "True" && ddlJobNo.SelectedItem.Text != "Select")
        {
            imgbtnFlatFile.Visible = true;
            btnSubmission.Visible = true;
           // btn_Outlookmail_Submission.Visible = true;
            //btn_Outlookmail_Submission.Enabled = true;
            DisplayAccountInformation();
        }
        else
        {
            //imgbtn.Visible = false; ---07-Oct_2016
        }

        //SB_Details();
        //string[] filePaths = Directory.GetFiles(errorFolder);
        //string file = filePaths[0];
        //sendEMailThroughOUTLOOK(file);

        //string filename = Session["createflename"].ToString();
        //d();
        //k(file);
        //Process[] p = Process.GetProcessesByName("Outlook");
        //if (Process.GetProcessesByName("Outlook.exe").Length > 0)
        //{
        //    SB_Details();
        //    string[] filePaths = Directory.GetFiles(errorFolder);
        //    string file = filePaths[0];
        //    DisplayOutlook(file);
        //}
        //else
        //{

        //    Alert_msg("CV not forwarded. An instance of Ms Outlook needs to be running to send email, Mail error");
        //}


        //if(DisplayAccountInformation()!="")
        //{
        //    SB_Details();
        //    string[] filePaths = Directory.GetFiles(errorFolder);
        //    string file = filePaths[0];
        //    DisplayOutlook(file, Outlook_From_mail_Address);
        //}
        //else
        //{
        //    //Alert_msg("CV not forwarded. An instance of Ms Outlook needs to be running to send email, Mail error");
        //    Alert_msg("not opened. An instance of Ms Outlook needs to be running to send email, Mail error");
        //}

    }

    public void Flat_File()
    {
                
        DateTime date = System.DateTime.Now;
        string datestringg = string.Format("{0:yyyyMMdd}", date);

        DateTime tt = System.DateTime.Now;

        string time = string.Format("{0:hhmm}", tt);
        GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
       string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();

        logFileName = ddlJobNo.SelectedValue.ToString()+ yy + ".sb";
        createfilename = logFileName;
        Session["createflename"] = logFileName;
        sw = new StreamWriter(errorFolder + logFileName, true);

        if (COMPANY_ID == "203")
        {
            if (TRANSPORT_MODE == "Air")
            {
                ICEGATE_ID = "NEINBLR2";
            }
        }

       // sw=new Html32TextWriter(

        //FileInfo file = new FileInfo(errorFolder + logFileName);
        //sw = file.CreateText();

        sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + ch + "CACHE01" + ch + ddlJobNo.SelectedValue.ToString() + DDMMYY_JOBDATE + ch + datestringg + ch + time);

        sw.WriteLine("<TABLE>SB");

        //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + "F" + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + CUSTOMS_HOUSE + ch + PORT_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + COUNTRY_DISCHARGE + ch + PORT_FINAL_DEST + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + TYPE_OF_EXPORTER + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + CUSTOMS_HOUSE + ch + PORT_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + COUNTRY_DISCHARGE + ch + PORT_FINAL_DEST + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

        int i = 0;
        if (ds.Tables[1].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>INVOICE");
            while (ds.Tables[1].Rows.Count > i)
            {
                INVOICE_SLNO = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_SLNO"].ToString());
                INVOICE_NO = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_NO"].ToString());
                INVOICE_DATE = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_DATE"].ToString().Replace("19000101", ""));
                PAYMENT_METHOD = dt.Trim(ds.Tables[1].Rows[i]["PAYMENT_METHOD"].ToString());
                PERIOD_PAYMENT = dt.Trim(ds.Tables[1].Rows[i]["PERIOD_PAYMENT"].ToString());
                INVOICE_VALUE = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_VALUE"].ToString());
                INVOICE_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_CURRENCY"].ToString());
                EXCHANGE_RATE = dt.Trim(ds.Tables[1].Rows[i]["EXCHANGE_RATE"].ToString());
                CONTRACT_NO = dt.Trim(ds.Tables[1].Rows[i]["CONTRACT_NO"].ToString());
                TERMS = dt.Trim(ds.Tables[1].Rows[i]["TERMS"].ToString());
                BUYER = dt.Trim(ds.Tables[1].Rows[i]["BUYER"].ToString());

                BUYER_NAME = dt.Trim(ds.Tables[1].Rows[i]["BUYER_NAME"].ToString().Replace("amp);", ""));
                BUYER_ADDRESS = dt.Trim(ds.Tables[1].Rows[i]["BUYER_ADDRESS"].ToString().Replace("amp);", ""));
                BUYER_ADDRESS1 = dt.Trim(ds.Tables[1].Rows[i]["BUYER_ADDRESS1"].ToString().Replace("amp);", ""));
                BUYER_ADDRESS2 = dt.Trim(ds.Tables[1].Rows[i]["BUYER_ADDRESS2"].ToString().Replace("amp);", ""));
                BUYER_ADDRESS3 = dt.Trim(ds.Tables[1].Rows[i]["BUYER_ADDRESS3"].ToString().Replace("amp);", ""));
                BUYER_ADDRESS4 = dt.Trim(ds.Tables[1].Rows[i]["BUYER_ADDRESS4"].ToString());
                COMMISSION_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["COMMISSION_RATE"].ToString()));
                COMMISSION_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["COMMISSION_CHARGES"].ToString()));
                COMMISSION_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["COMMISSION_CURRENCY"].ToString());
                FOB_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["FOB_RATE"].ToString()));

                FOB_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["FOB_CHARGES"].ToString()));
                FOB_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["FOB_CURRENCY"].ToString());
                PACKMISC_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["PACKMISC_RATE"].ToString()));
                PACKMISC_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["PACKMISC_CHARGES"].ToString()));
                PACKMISC_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["PACKMISC_CURRENCY"].ToString());
                OTHER_DEDUCTION_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["OTHER_DEDUCTION_RATE"].ToString()));
                OTHER_DEDUCTION_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["OTHER_DEDUCTION_CHARGES"].ToString()));
                OTHER_DEDUCTION_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["OTHER_DEDUCTION_CURRENCY"].ToString());
                FREIGHT_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["FREIGHT_RATE"].ToString()));
                FREIGHT_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["FREIGHT_CHARGES"].ToString()));
                FREIGHT_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["FREIGHT_CURRENCY"].ToString());
                INSURANCE_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["INSURANCE_RATE"].ToString()));
                INSURANCE_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["INSURANCE_CHARGES"].ToString()));
                INSURANCE_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["INSURANCE_CURRENCY"].ToString());
                WHEATHER_UNIT_PRICE = dt.Trim(ds.Tables[1].Rows[i]["WHEATHER_UNIT_PRICE"].ToString());
                if (BUYER_NAME == "SAME AS CONSIGNEE")
                {
                    BUYER_ADDRESS = "`";
                }
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + INVOICE_NO + ch + INVOICE_DATE + ch + INVOICE_CURRENCY + ch + TERMS + ch + BUYER_NAME + ch + BUYER_ADDRESS + ch + BUYER_ADDRESS1 + ch + BUYER_ADDRESS2 + ch + BUYER_ADDRESS3 + ch + FREIGHT_CURRENCY + ch + FREIGHT_CHARGES + ch + INSURANCE_RATE + ch + INSURANCE_CURRENCY + ch + INSURANCE_CHARGES + ch + COMMISSION_RATE + ch + COMMISSION_CURRENCY + ch + COMMISSION_CHARGES + ch + FOB_RATE + ch + FOB_CURRENCY.ToUpper() + ch + FOB_CHARGES + ch + OTHER_DEDUCTION_RATE + ch + OTHER_DEDUCTION_CURRENCY + ch + OTHER_DEDUCTION_CHARGES + ch + WHEATHER_UNIT_PRICE + ch + PACKMISC_CHARGES + ch + CONTRACT_NO + ch + PAYMENT_METHOD + ch + PERIOD_PAYMENT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                i++;
            }
        }

        //int f = 0;
        //if (INVOICE_CURRENCY != "")
        //{
        //    sw.WriteLine("<TABLE>EXCHANGE");
        //    while (ds.Tables[9].Rows.Count > f)
        //    {

        //        INVOICE_CURRENCY = dt.Trim(ds.Tables[9].Rows[f]["INVOICE_CURRENCY"].ToString());
        //        EXCHANGE_RATE = "";
               
        //        if (INVOICE_CURRENCY != "")

        //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + Currency_Name + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXCHANGE_RATE + ch + Effective_Date + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
        //        f++;

        //    }
        //}


        int f = 0;
        if (INVOICE_CURRENCY != "")
        {
            sw.WriteLine("<TABLE>EXCHANGE");
            //while (ds.Tables[9].Rows.Count > f)
            //{

            //    INVOICE_CURRENCY = dt.Trim(ds.Tables[9].Rows[f]["INVOICE_CURRENCY"].ToString());
            //    EXCHANGE_RATE = "";

            //    if (INVOICE_CURRENCY != "")

            //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + Currency_Name + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXCHANGE_RATE + ch + Effective_Date + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
            //    f++;

            //}


            if (ds.Tables[9].Rows.Count > 0)
            {
                while (ds.Tables[9].Rows.Count > f)
                {
                    INVOICE_CURRENCY = dt.Trim(ds.Tables[9].Rows[f]["INVOICE_CURRENCY"].ToString());
                    //INVOICE_EXRATE = dt.Trim(ds.Tables[10].Rows[gg]["EX_RATE"].ToString());
                    string EXRATE = "";

                    //---------------For Non Standard Currency on 01Sep2015----------------//
                    Standard_Currency = "";
                    DataView view1 = dss.Tables[3].DefaultView;
                    view1.RowFilter = "EXCHANGE_CUR_CODE = '" + INVOICE_CURRENCY + "'";
                    DataSet dt_1 = new DataSet();
                    dt_1.Tables.Add(view1.ToTable());
                    if (dt_1.Tables[0].Rows.Count > 0)
                    {
                        EXCHANGE_RATE = dt_1.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
                        Standard_Currency = "Y";
                        NON_STD_EFFECT_DT_EXP = "";
                        NON_STD_BANKNAME = "";
                        NON_STD_CERTIFICATE_NO = "";
                        NON_STD_CERTIFICATE_DATE = "";
                    }
                    else
                    {
                        DataView view2 = ds.Tables[1].DefaultView;

                        view2.RowFilter = "INVOICE_CURRENCY = '" + INVOICE_CURRENCY + "'";
                        DataSet dt_2 = new DataSet();
                        dt_2.Tables.Add(view2.ToTable());

                        if (dt_2.Tables[0].Rows.Count > 0)
                        {
                            NON_STD_EFFECT_DT_EXP = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString().Replace("19000101", ""));
                            NON_STD_BANKNAME = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString());
                            NON_STD_CERTIFICATE_NO = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString());
                            NON_STD_CERTIFICATE_DATE = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString().Replace("19000101", ""));
                            EXCHANGE_RATE = dt.Trim(dt_2.Tables[0].Rows[0]["EXCHANGE_RATE"].ToString());
                            Standard_Currency = "N";
                        }


                    }


                    //---------------For Non Standard Currency on 01Sep2015----------------//

                    if (INVOICE_CURRENCY != "")

                        //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + Currency_Name + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXCHANGE_RATE + ch + Effective_Date + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + NON_STD_BANKNAME + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXCHANGE_RATE + ch + NON_STD_EFFECT_DT_EXP + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                        

                    f++;
                }
            }


        }


        int j = 0;
        if (ds.Tables[2].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>ITEM");
            while (ds.Tables[2].Rows.Count > j)
            {
                INVOICE_SLNO = dt.Trim(ds.Tables[2].Rows[j]["INVOICE_SLNO"].ToString());
                INVOICE_NO = dt.Trim(ds.Tables[2].Rows[j]["INVOICE_NO"].ToString());
                ITEM_SLNO = dt.Trim(ds.Tables[2].Rows[j]["ITEM_SLNO"].ToString());
                ITEM_DESCRIPTION1 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION1"].ToString());
                ITEM_DESCRIPTION2 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION2"].ToString());
                ITEM_DESCRIPTION3 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION3"].ToString());
                RITCNO = dt.Trim(ds.Tables[2].Rows[j]["RITCNO"].ToString());
                ITEM_QTY = dt.Trim(ds.Tables[2].Rows[j]["ITEM_QTY"].ToString());
                ITEM_QTY_CODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_QTY_CODE"].ToString());
                ITEM_UNIT_PRICE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_UNIT_PRICE"].ToString());
                ITEM_PER = dt.Trim(ds.Tables[2].Rows[j]["ITEM_PER"].ToString());
                ITEM_AMOUNT = dt.Trim(ds.Tables[2].Rows[j]["ITEM_AMOUNT"].ToString());
                ITEM_PMVVALUE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_PMVVALUE"].ToString());

                ITEM_SCHEME_CODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_SCHEME_CODE"].ToString());
                ITEM_ACCESSORIES_DESC = dt.Trim(ds.Tables[2].Rows[j]["ITEM_ACCESSORIES_DESC"].ToString());
                ITEM_AR4_NO = dt.Trim(ds.Tables[2].Rows[j]["ITEM_AR4_NO"].ToString());
                ITEM_AR4_DATE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_AR4_DATE"].ToString().Replace("19000101", ""));
                ITEM_COMMISSION_RATE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_COMMISSION_RATE"].ToString());
                ITEM_DIVISION = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DIVISION"].ToString());
                ITEM_RANGE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_RANGE"].ToString());
                ITEM_REMARKS = dt.Trim(ds.Tables[2].Rows[j]["ITEM_REMARKS"].ToString());
                ITEM_IECCODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_IECCODE"].ToString());
                ITEM_EXPORTER_NAME = dt.Trim(ds.Tables[2].Rows[j]["ITEM_EXPORTER_NAME"].ToString());

                BR_SLNO = dt.Trim(ds.Tables[2].Rows[j]["BR_SLNO"].ToString());
                ITEM_ADDRESS1 = dt.Trim(ds.Tables[2].Rows[j]["ADDRESS1"].ToString());
                ITEM_ADDRESS2 = dt.Trim(ds.Tables[2].Rows[j]["ADDRESS2"].ToString());
                ITEM_ADDRESS3 = dt.Trim(ds.Tables[2].Rows[j]["ADDRESS3"].ToString());
                ITEM_ADDRESS4 = dt.Trim(ds.Tables[2].Rows[j]["ADDRESS4"].ToString());
                ITEM_ADDRESS5 = dt.Trim(ds.Tables[2].Rows[j]["ADDRESS5"].ToString());
                ITEM_STR_CODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_STR_CODE"].ToString());
                REWARD_POINTS = dt.Trim(ds.Tables[2].Rows[j]["REWARD_POINTS"].ToString());
                string val = dt.Trim(ds.Tables[2].Rows[j]["PMV_VALUE"].ToString());

                if (Session["COMPANY_ID"].ToString() == "116")
                {
                    if (currentbranch == "ACC, Kolkata" || currentbranch == "CusHouse, Kolkata" || currentbranch == "ICD,Petrapole")
                    {
                        val = dt.Trim(ds.Tables[2].Rows[j]["ITEM_PMVVALUE"].ToString());
                    }
                }

                if (val == "")
                {
                    val = "0.00";
                }

                if (val.Trim() != "" && Convert.ToDouble(val) != 0.00 && Convert.ToDouble(val) != 0)
                {
                    //PMV_VALUE = Convert.ToString(Convert.ToDouble(val) / Convert.ToDouble(ITEM_QTY));
                    PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(val) / Convert.ToDouble(ITEM_QTY),2).ToString("0.00"));
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
                    if (currentbranch == "ACC, Kolkata" || currentbranch == "CusHouse, Kolkata" || currentbranch == "ICD,Petrapole")
                    {
                        if (Convert.ToDouble(PMV_VALUE) == 0.01 || Convert.ToDouble(PMV_VALUE) == 0)
                            PMV_VALUE = "0.00";
                    }
                }

                //Check IS_JOBBING
                DataView view1 = ds.Tables[5].DefaultView;
                
                view1.RowFilter = "INVOICE_SLNO = " + INVOICE_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;

                //DataTable table1 = view1.ToTable();
                DataSet dt_UserRights = new DataSet();
                dt_UserRights.Tables.Add(view1.ToTable());
                if (dt_UserRights.Tables[0].Rows.Count > 0)
                {
                    NOTIFICATION_NO = dt.Trim(dt_UserRights.Tables[0].Rows[0]["NOTIFICATION_NO"].ToString());
                }
                
                //Check IS_JOBBING

                //Check IS_ThirdPaty or Rewardpoints

                string IS_ThirdParty = "",Is_Reward="";
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


                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + ch + ch);
                j++;
            }
        }
        
        //-------------------------

        int ac = 0;
        if (ds.Tables[13].Rows.Count > 0)
        {
            if (ITEM_ACCESSORIES_DESC != "")
            {
                sw.WriteLine("<TABLE>ITEMACCESS");
                while (ds.Tables[2].Rows.Count > ac)
                {
                    INVOICE_SLNO = dt.Trim(ds.Tables[2].Rows[ac]["INVOICE_SLNO"].ToString());
                    INVOICE_NO = dt.Trim(ds.Tables[2].Rows[ac]["INVOICE_NO"].ToString());
                    ITEM_SLNO = dt.Trim(ds.Tables[2].Rows[ac]["ITEM_SLNO"].ToString());

                    ITEM_ACCESSORIES_DESC = dt.Trim(ds.Tables[2].Rows[ac]["ITEM_ACCESSORIES_DESC"].ToString());

                    if (ITEM_ACCESSORIES_DESC != "")
                    {
                        //    sw.WriteLine("<TABLE>ITEMACCESS");
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_ACCESSORIES_DESC);
                    }
                    ac++;
                }
            }
        }


        //-------------------------


        int K = 0;

        DataView view_third = ds.Tables[2].DefaultView;

        //view_third.RowFilter = "ITEM_EXPORTER_NAME = '" + ITEM_EXPORTER_NAME_THIRD + "'";
        view_third.RowFilter = "ITEM_EXPORTER_NAME <> ''";
        DataSet dS_third = new DataSet();
        dS_third.Tables.Add(view_third.ToTable());

        if (dS_third.Tables[0].Rows.Count > 0)
        {
            ITEM_EXPORTER_NAME = dt.Trim(dS_third.Tables[0].Rows[0]["ITEM_EXPORTER_NAME"].ToString());

        }

        if (ITEM_EXPORTER_NAME != "")
        {
            sw.WriteLine("<TABLE>THIRDPARTY");
            while (dS_third.Tables[0].Rows.Count > K)
            {
                INVOICE_SLNO = dt.Trim(dS_third.Tables[0].Rows[K]["INVOICE_SLNO"].ToString());
                INVOICE_NO = dt.Trim(dS_third.Tables[0].Rows[K]["INVOICE_NO"].ToString());
                ITEM_SLNO = dt.Trim(dS_third.Tables[0].Rows[K]["ITEM_SLNO"].ToString());

                ITEM_IECCODE = dt.Trim(dS_third.Tables[0].Rows[K]["ITEM_IECCODE"].ToString());
                ITEM_EXPORTER_NAME = dt.Trim(dS_third.Tables[0].Rows[K]["ITEM_EXPORTER_NAME"].ToString());

                BR_SLNO = dt.Trim(dS_third.Tables[0].Rows[K]["BR_SLNO"].ToString());
                ITEM_ADDRESS1 = dt.Trim(dS_third.Tables[0].Rows[K]["ADDRESS1"].ToString());
                ITEM_ADDRESS2 = dt.Trim(dS_third.Tables[0].Rows[K]["ADDRESS2"].ToString());
                ITEM_ADDRESS3 = dt.Trim(dS_third.Tables[0].Rows[K]["ADDRESS3"].ToString());
                ITEM_ADDRESS4 = dt.Trim(dS_third.Tables[0].Rows[K]["ADDRESS4"].ToString());
                ITEM_ADDRESS5 = dt.Trim(dS_third.Tables[0].Rows[K]["ADDRESS5"].ToString());
                ITEM_STR_CODE = dt.Trim(dS_third.Tables[0].Rows[K]["ITEM_STR_CODE"].ToString());
                REWARD_POINTS = dt.Trim(dS_third.Tables[0].Rows[K]["REWARD_POINTS"].ToString());

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_IECCODE + ch + BR_SLNO + ch + ITEM_EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS5 + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                K++;
            }
        }

        //-----------------------------------Cess Details--------------------------------------//

        int CC = 0;
         if (ds.Tables[12].Rows.Count > 0)
         {
            sw.WriteLine("<TABLE>CESS");
            while (ds.Tables[12].Rows.Count > CC)
            {
                INVOICE_SLNO = dt.Trim(ds.Tables[12].Rows[CC]["INVOICE_SLNO"].ToString());           
                ITEM_SLNO = dt.Trim(ds.Tables[12].Rows[CC]["ITEM_SLNO"].ToString());

                CESS_ID = dt.Trim(ds.Tables[12].Rows[CC]["CESS_ID"].ToString());
                CESS_SLNO = dt.Trim(ds.Tables[12].Rows[CC]["CESS_SLNO"].ToString());
                CESS_VALUE = dt.Trim(ds.Tables[12].Rows[CC]["CESS_VALUE"].ToString());
                CESS_UNIT = dt.Trim(ds.Tables[12].Rows[CC]["CESS_UNIT"].ToString());

                CESS_FLAG = dt.Trim(ds.Tables[12].Rows[CC]["CESS_FLAG"].ToString());
                CESS_RATE = dt.Trim(ds.Tables[12].Rows[CC]["CESS_RATE"].ToString());
                CESS_ITEM_QTY = dt.Trim(ds.Tables[12].Rows[CC]["CESS_ITEM_QTY"].ToString());
                CESS_ITEM_QTY_CODE = dt.Trim(ds.Tables[12].Rows[CC]["CESS_ITEM_QTY_CODE"].ToString());
                CESS_TARIFF_VALUE = dt.Trim(ds.Tables[12].Rows[CC]["CESS_TARIFF_VALUE"].ToString());
                CESS_TARIFF_UNIT = dt.Trim(ds.Tables[12].Rows[CC]["CESS_TARIFF_UNIT"].ToString());

                CESS_ID = "";

                if (CESS_ITEM_QTY == "")
                {
                    CESS_ITEM_QTY = "0";
                }

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CESS_ID + ch + CESS_SLNO + ch + CESS_ITEM_QTY + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                CC++;
            }
        }

        //-----------------------------------Cess Details--------------------------------------//



        int dbk = 0;
        if (ds.Tables[3].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>DBK");
            while (ds.Tables[3].Rows.Count > dbk)
            {
                //JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();

                INVOICE_SLNO = dt.Trim(ds.Tables[3].Rows[dbk]["INVOICE_SLNO"].ToString());

                ITEM_SLNO = dt.Trim(ds.Tables[3].Rows[dbk]["ITEM_SLNO"].ToString());

                //SCHEME_CODE = ds.Tables[3].Rows[0]["SCHEME_CODE"].ToString();

                DRAWBACK_SLNO = dt.Trim(ds.Tables[3].Rows[dbk]["DRAWBACK_SLNO"].ToString());

                DRAWBACK_QTY = dt.Trim(ds.Tables[3].Rows[dbk]["DRAWBACK_QTY"].ToString());

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + DRAWBACK_SLNO + ch + DRAWBACK_QTY + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                dbk++;
            }
        }

        
        int mm=0;

        if (ds.Tables[11].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>LICENCE");
            while (ds.Tables[11].Rows.Count > mm)
            {
                INVOICE_SLNO = dt.Trim(ds.Tables[11].Rows[mm]["INV_SL_NO"].ToString());
                ITEM_SLNO = dt.Trim(ds.Tables[11].Rows[mm]["ITEM_SL_NO"].ToString());
                LICENSE_NO = dt.Trim(ds.Tables[11].Rows[mm]["LICENSE_NO"].ToString());
                LICENSE_ID = dt.Trim(ds.Tables[11].Rows[mm]["LICENSE_ID"].ToString());

                //if (ds.Tables[4].Rows.Count > 0)
                //{
                //sw.WriteLine("<TABLE>LICENCE");

                //-------------------------------------

                //j = 0;

                
                DataSet dss = new DataSet();
                if (ds.Tables[4].Rows.Count > 0)
                {
                    DataView view = ds.Tables[4].DefaultView;
                    //view.RowFilter = "LICENSE_NO" + " = '" +LICENSE_NO+ "'";
                    view.RowFilter = "LICENSE_NO = '" + LICENSE_NO + "' and " + "LICENSE_ID = " + LICENSE_ID;


                    DataTable table = view.ToTable();

                    dss.Tables.Add(table);

                   
                    //if (dss.Tables[0].Rows.Count > 0)
                    //{
                    int m = 0;
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

                        //----------------------------------

                        //SCHEME_CODE = dt.Trim(dss.Tables[0].Rows[0]["SCHEME_CODE"].ToString());
                        //SCHEME = dt.Trim(dss.Tables[0].Rows[0]["SCHEME"].ToString());
                        //LICENSE_R_SL_NO = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_R_SL_NO"].ToString());
                        ////LICENSE_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_NO"].ToString());
                        //LICENSE_DATE = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_DATE"].ToString().Replace("19000101", ""));

                        //LICENSE_E_SL_NO = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_E_SL_NO"].ToString());
                        //LICENSE_EXP_QTY = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_EXP_QTY"].ToString());
                        //LICENSE_EXP_UNIT = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_EXP_UNIT"].ToString());
                        //LICENSE_IMP_ITEM_SL_NO = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_IMP_ITEM_SL_NO"].ToString());
                        //LICENSE_IMP_DESC = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_IMP_DESC"].ToString());

                        //LICENSE_IMP_QTY = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_IMP_QTY"].ToString());
                        //LICENSE_IMP_UNIT = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_IMP_UNIT"].ToString());
                        //LICENSE_IMP_TYPE = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_IMP_TYPE"].ToString());

                        //----------------------------------

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + LICENSE_NO + ch + LICENSE_DATE + ch + LICENSE_E_SL_NO + ch + LICENSE_IMP_ITEM_SL_NO + ch + LICENSE_IMP_QTY + ch + LICENSE_EXP_QTY + ch + LICENSE_IMP_TYPE + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);


                        m++;
                    }
                }
                mm++;
            }
        }
        
        int n = 0;
        if (ds.Tables[5].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>JOBWORK");
            while (ds.Tables[5].Rows.Count > n)
            {
                INVOICE_SLNO = dt.Trim(ds.Tables[5].Rows[n]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds.Tables[5].Rows[n]["ITEM_SLNO"].ToString());
                SCHEME_CODE = dt.Trim(ds.Tables[5].Rows[n]["SCHEME_CODE"].ToString());
                NOTIFICATION_NO = dt.Trim(ds.Tables[5].Rows[n]["NOTIFICATION_NO"].ToString());
                BE_NO = dt.Trim(ds.Tables[5].Rows[n]["BE_NO"].ToString());
                BE_DATE = dt.Trim(ds.Tables[5].Rows[n]["BE_DATE"].ToString().Replace("19000101", ""));
                BE_INV_SLNO = dt.Trim(ds.Tables[5].Rows[n]["BE_INV_SLNO"].ToString());

                BE_INV_NO = dt.Trim(ds.Tables[5].Rows[n]["BE_INV_NO"].ToString());
                BE_ITEM_NO = dt.Trim(ds.Tables[5].Rows[n]["BE_ITEM_NO"].ToString());
                BE_PORT_CODE = dt.Trim(ds.Tables[5].Rows[n]["BE_PORT_CODE"].ToString());
                QTY = dt.Trim(ds.Tables[5].Rows[n]["QTY"].ToString());
                UNIT = dt.Trim(ds.Tables[5].Rows[n]["UNIT"].ToString());
                               
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + BE_NO + ch + BE_DATE + ch + BE_INV_SLNO + ch + BE_INV_NO + ch + BE_ITEM_NO + ch + BE_PORT_CODE + ch + QTY + ch + UNIT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                n++;
            }
        }
        //--------------------------------------------------job based AR4 details---------------------------------------//
        int a = 0;
        if (ds.Tables[10].Rows.Count>0)
        {
            sw.WriteLine("<TABLE>AR4");
            while (ds.Tables[10].Rows.Count > a)
            {
                //INVOICE_SLNO = "1";//set default as Invoice No 1

                INVOICE_SLNO = dt.Trim(ds.Tables[10].Rows[a]["AR4_INVOICE_SLNO"].ToString());

                ITEM_SLNO = dt.Trim(ds.Tables[10].Rows[a]["AR4_ITEM_NO"].ToString());
                
                //ITEM_SLNO = dt.Trim(ds.Tables[10].Rows[a]["AR4_RUN_ID"].ToString());
                //ITEM_SLNO = Convert.ToString(a + 1);
               // ITEM_SLNO = dt.Trim(ds.Tables[10].Rows[a]["AR4_ID"].ToString());

                ITEM_AR4_NO = dt.Trim(ds.Tables[10].Rows[a]["AR4_NO"].ToString());
                ITEM_AR4_DATE = dt.Trim(ds.Tables[10].Rows[a]["AR4_DATE"].ToString().Replace("19000101", ""));
                ITEM_COMMISSION_RATE = dt.Trim(ds.Tables[10].Rows[a]["AR4_COMMISSION_RATE"].ToString());
                ITEM_DIVISION = dt.Trim(ds.Tables[10].Rows[a]["AR4_DIVISION"].ToString());
                ITEM_RANGE = dt.Trim(ds.Tables[10].Rows[a]["AR4_RANGE"].ToString());
                ITEM_REMARKS = dt.Trim(ds.Tables[10].Rows[a]["AR4_REMARKS"].ToString());

                if (ITEM_REMARKS == "")
                {
                    ITEM_REMARKS = "NIL";
                }

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_AR4_NO + ch + ITEM_AR4_DATE + ch + ITEM_COMMISSION_RATE + ch + ITEM_DIVISION + ch + ITEM_RANGE + ch + ITEM_REMARKS);

                a++;
            }
        }
        //--------------------------------------------------job based AR4 details---------------------------------------//
        int b = 0;
        if (ds.Tables[6].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>PACKINGLIST");
            while (ds.Tables[6].Rows.Count > b)
            {
                ANNEX_SEA_PACK_FROM = dt.Trim(ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_FROM"].ToString());

                ANNEX_SEA_PACK_TO = dt.Trim(ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_TO"].ToString());

                ANNEX_SEA_PACK_PACKAGETYPE = dt.Trim(ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString());

                ANNEX_SEA_PACK_FROMDESC = dt.Trim(ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_FROMDESC"].ToString());
                ANNEX_SEA_PACK_TODESC = dt.Trim(ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_TODESC"].ToString());

                if (COMPANY_ID == "146" || COMPANY_ID == "158" || COMPANY_ID == "7" || COMPANY_ID == "137" || COMPANY_ID == "164" || COMPANY_ID == "165")
                {
                    ANNEX_SEA_PACK_FROM = ANNEX_SEA_PACK_FROMDESC;
                    ANNEX_SEA_PACK_TO = ANNEX_SEA_PACK_TODESC;
                }               

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + ANNEX_SEA_PACK_FROM + ch + ANNEX_SEA_PACK_TO + ch + ANNEX_SEA_PACK_PACKAGETYPE);

                b++;
            }
        }

        if (ROTATION_NO != "")
        {
            sw.WriteLine("<TABLE>ROTATION");
            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + ROTATION_DATE + ch + ROTATION_NO);
        }             
        
        if (ds.Tables[7].Rows.Count > 0)
        {
            ANNEX_EXPORTERNAME = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_EXPORTERNAME"].ToString());

            ANNEX_IECCODE = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_IECCODE"].ToString());

            ANNEX_BR_SLNO = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_BR_SLNO"].ToString());

            ANNEX_EXAM_DATE = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_EXAM_DATE"].ToString().Replace("19000101", ""));

            ANNEX_EXAM_OFFICER = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_EXAM_OFFICER"].ToString());

            ANNEX_EXAM_DESIGN = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_EXAM_DESIGN"].ToString());
            ANNEX_SUPER_NAME = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_SUPER_NAME"].ToString());
            ANNEX_SUPER_DESIGN = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_SUPER_DESIGN"].ToString());

            ANNEX_COMMISSION_RATE = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_COMMISSION_RATE"].ToString());
            ANNEX_DIVISION = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_DIVISION"].ToString());
            ANNEX_RANGE = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_RANGE"].ToString());

            ANNEX_VERIFIED_EXAM_OFFICER = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString());
            ANNEX_SAMPLE_DRAWN = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString());
            ANNEX_SEAL_NO = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_SEAL_NO"].ToString());

            sw.WriteLine("<TABLE>EOU");
            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + ANNEX_IECCODE + ch + ANNEX_BR_SLNO + ch + ANNEX_EXAM_DATE + ch + ANNEX_EXAM_OFFICER + ch + ANNEX_EXAM_DESIGN + ch + ANNEX_SUPER_NAME + ch + ANNEX_SUPER_DESIGN + ch + ANNEX_COMMISSION_RATE + ch + ANNEX_DIVISION + ch + ANNEX_RANGE + ch + ANNEX_SEAL_NO + ch + ANNEX_VERIFIED_EXAM_OFFICER + ch + ANNEX_SAMPLE_DRAWN + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
        }

        int c = 0;
        if (ds.Tables[8].Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>CONTAINER");
            while (ds.Tables[8].Rows.Count > c)
            {
                ANNEX_SEA_CON_CONTAINERNO = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_CONTAINERNO"].ToString());

                ANNEX_SEA_CON_SIZE = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_SIZE"].ToString());

                ANNEX_SEA_CON_TYPE = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_TYPE"].ToString());

                ANNEX_SEA_CON_EXCISE_SEALNO = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString());

                ANNEX_SEA_CON_SEAL_DATE = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_SEAL_DATE"].ToString().Replace("19000101", ""));
               
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + ANNEX_SEA_CON_CONTAINERNO + ch + ANNEX_SEA_CON_SIZE + ch + ANNEX_SEA_CON_EXCISE_SEALNO + ch + ANNEX_SEA_CON_SEAL_DATE);

                c++;
            }
        }

        int d = 0;              
        DataView str_view = ds.Tables[2].DefaultView;
        str_view.RowFilter = "NOT ITEM_STR_CODE = '' ";
        DataTable str_table = str_view.ToTable();

        if (str_table.Rows.Count > 0)
        {
            sw.WriteLine("<TABLE>STR");
            while (str_table.Rows.Count > d)
            {
                INVOICE_SLNO = dt.Trim(str_table.Rows[d]["INVOICE_SLNO"].ToString());

                ITEM_SLNO = dt.Trim(str_table.Rows[d]["ITEM_SLNO"].ToString());

                ITEM_STR_CODE = dt.Trim(str_table.Rows[d]["ITEM_STR_CODE"].ToString());
                               
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + ITEM_STR_CODE + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
               
                d++;
            }
        }

        sw.WriteLine("<END-SB>");
        TextBox txt = new TextBox();
        sw.WriteLine("TREC" + ch + ddlJobNo.SelectedValue.ToString() +DDMMYY_JOBDATE);
       
        sw.Flush();
        sw.Close();
        sw.Dispose();
        //sw = null;
       
        if (IS_Imgbtn == "1")
        {
            Response.Write(sw.ToString());
            Response.Flush();
            // Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        
    }
   
    public void mail(string filenm)
    {
        //if (ICEGATE_EMAIL_ID != "" && ICEGATE_EMAIL_PWD != "")
        //{
            EMail_ID = CUSTOMS_HOUSE + "@icegate.gov.in";

            //EMail_ID = "admin@royaltechsystems.co.in";

            //CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
            //ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            //ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            //ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

            //ICEGATE_EMAIL_ID_NEW.Value = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            //ICEGATE_EMAIL_PWD_NEW.Value = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

            SmtpClient client = new SmtpClient();

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //---------------------------------------------
            //client.EnableSsl = true;

            //client.Host = "smtp.gmail.com";

            //client.Port = 587;
        //----------------------------------

            //--------------Live Configuration-----------------//
            if (COMPANY_ID == "116")
            {
                client.Host = "smtp.gmail.com";//For Boxco Logistics Server
                client.Port = 25;
                client.EnableSsl = true;
            }           
            else
            {
                client.Host = "smtp.mail.yahoo.com";//For ERoyal Server
                client.Port = 587;
                client.EnableSsl = true;
            }

            //--------------Live Configuration-----------------//


            //client.Host = "127.0.0.1";//For Royal Tech Server

            //client.Host = "11.0.0.3";//For Boxco Logistics Server

            //----------------------------------
            //client.Port = 25;
            //client.EnableSsl = false;
            //----------------------------------
            // setup Smtp authentication

            //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("sathishkumar8789@gmail.com", "skoushik");
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ICEGATE_EMAIL_ID, ICEGATE_EMAIL_PWD);
            //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("orientalmaa@gmail.com", "oriental123");

            //client.UseDefaultCredentials = false;
            client.UseDefaultCredentials = true;

            client.Credentials = credentials;

            MailMessage msg = new MailMessage();

             //msg.From = new MailAddress("sathishkumar8789@gmail.com");
            //msg.From = new MailAddress("orientalmaa@gmail.com");
            msg.From = new MailAddress(ICEGATE_EMAIL_ID);

            //msg.To.Add(new MailAddress("admin@royaltechsystems.co.in"));
             //msg.To.Add(new MailAddress("balaji71187@gmail.com"));
            msg.To.Add(new MailAddress(EMail_ID));

            msg.CC.Add(new MailAddress(ICEGATE_EMAIL_ID));

            if (COMPANY_ID == "146")
            {
                msg.Bcc.Add(new MailAddress("edi@bwclogistics.com"));
            }
            else
            {

            }

            msg.Subject = ICEGATE_ID + "-" + ddlJobNo.SelectedValue.ToString() + "(" + "SB" + ")";
            //msg.Subject = "SB";

            msg.IsBodyHtml = true;

            //msg.Body = string.Format("<html><head></head><body><b>Flat File</b></body>");
            msg.Body = string.Format("<html><head></head><body><b></b></body>");

            msg.Attachments.Add(new Attachment(filenm));

            try
            {
                
                client.Send(msg);
               
                if (msg.DeliveryNotificationOptions.ToString() == "Failure sending mail.")
                {
                    Alert_msg("Failure sending mail!");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Failure sending mail!')</script>", false);
                    msg.Dispose();

                }
                else
                {
                    
                    
                    Alert_msg("Auto submitted");

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Auto submitted')</script>", false);
                    msg.Dispose();
                }
                //lblMsg.Text = "Your message has been successfully sent.";
            }

            catch (Exception ex)
            {
                //lblMsg.ForeColor = Color.Red;

                string messege = "Error occured while sending your message." + ex.Message;
                //lblMsg.Text = "Error occured while sending your message." + ex.Message;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('" + messege + "')</script>", false);
                Alert_msg(messege);

                msg.Dispose();

            }
       // }
       // else
            //Alert_msg("IceGate Email-Id & Password cannot be Empty");


    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    [System.Web.Services.WebMethod]
    public static string Get_Import_Details(string custid)
    {
        string Working_Period = "", txtCustomHouse = "",
               txtExporterName = "",
               txtScheme = "",
               txtConsignee = "",
               txtNoofItems = "",
               txtNoofInvoices = "",
                Annexure_Mode = "",
                  STR_Code = "",
                  select_branch = "", select_type_ = "", Flatfile_Generate = "";


        try
        {
            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
            select_branch = HttpContext.Current.Session["currentbranch"].ToString();
            select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();

            if (select_type_ == "Branchwise Job")
            {
                select_branch = select_branch;
            }
            else
            {
                select_branch = "";
            }


            if (HttpContext.Current.Session["Exp_Combine_Jobs"] != "" && HttpContext.Current.Session["Exp_Combine_Jobs"] != null)
            {
                Export_CheckList CHKLIST = new Export_CheckList();
                CHKLIST.JOBNo = custid;
                CHKLIST.Ename = "select_Combine_jobno_Flatfile";
                CHKLIST.TRANSPORT_MODE = HttpContext.Current.Session["Exp_Combine_Jobs"].ToString();
                CHKLIST.Workingperiod = select_branch;

                DataSet ds = new DataSet();
                ds = CHKLIST.RetrieveAll_General_Details();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCustomHouse = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    txtExporterName = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    txtConsignee = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtScheme = ds.Tables[1].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            txtNoofInvoices = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";
                        }
                        else
                        {
                            txtNoofInvoices = "";
                        }

                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            txtNoofItems = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";
                        }
                        else
                        {
                            txtNoofItems = "";
                        }
                    }
                    else
                    {
                        txtScheme = "";
                        txtNoofItems = "";
                        txtNoofInvoices = "";
                    }

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        Flatfile_Generate = "No";
                    }
                    else
                    {
                        Flatfile_Generate = "Yes";
                    }

                    /*
                    Rpt_General_Details Export_General = new Rpt_General_Details();
                    Export_General.Retrieve_GetGeneral(custid);
                    Annexure_Mode = Convert.ToString(Export_General.is_Annexure_Mode);
                    STR_Code = Convert.ToString(Export_General.is_STR_Code);
                    */

                    EXP_combined EC = new EXP_combined();
                    EC.Jobno = HttpContext.Current.Session["Exp_Combine_Jobs"].ToString();
                    EC.Exp_name = HttpContext.Current.Session["EC_Exp_name"].ToString(); ;
                    EC.Branch = select_branch;
                    EC.Mode = HttpContext.Current.Session["EC_Tr_mode"].ToString();
                    EC.Flag = "Checklist";
                    ds = EC.New_item_load();
                    Annexure_Mode = EC.result.ToString();
                    STR_Code = EC.Is_STR.ToString();

                    HttpContext.Current.Session.Remove("EXPORT_CHECKLIST");
                    HttpContext.Current.Session["EXPORT_CHECKLIST"] = ds;
                }
                else
                {
                    txtCustomHouse = "";
                    txtExporterName = "";
                    txtScheme = "";
                    txtConsignee = "";
                    txtNoofItems = "";
                    txtNoofInvoices = "";

                }
                //------------------------
            }
            else
            {

                Export_CheckList CHKLIST = new Export_CheckList();
                CHKLIST.JOBNo = custid;
                CHKLIST.Ename = "select_jobno_CheckList";

                CHKLIST.Workingperiod = select_branch;
                DataSet ds = new DataSet();
                ds = CHKLIST.RetrieveAll_General_Details();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCustomHouse = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    txtExporterName = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    txtConsignee = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtScheme = ds.Tables[1].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            txtNoofInvoices = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";

                        }
                        else
                        {
                            txtNoofInvoices = "";
                        }

                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            txtNoofItems = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";

                        }
                        else
                        {
                            txtNoofItems = "";
                        }
                    }
                    else
                    {
                        txtScheme = "";
                        txtNoofItems = "";
                        txtNoofInvoices = "";
                    }
                    Rpt_General_Details Export_General = new Rpt_General_Details();
                    Export_General.Retrieve_GetGeneral(custid);
                    Annexure_Mode = Convert.ToString(Export_General.is_Annexure_Mode);
                    STR_Code = Convert.ToString(Export_General.is_STR_Code);

                }
                else
                {
                    txtCustomHouse = "";
                    txtExporterName = "";
                    txtScheme = "";
                    txtConsignee = "";
                    txtNoofItems = "";
                    txtNoofInvoices = "";

                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    Flatfile_Generate = "No";
                }
                else
                {
                    Flatfile_Generate = "Yes";
                }

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
        custid = txtCustomHouse + "~~" + txtExporterName + "~~" + txtScheme + "~~" + txtConsignee + "~~" + txtNoofItems + "~~" + txtNoofInvoices + "~~" + Annexure_Mode + "~~" + STR_Code + "~~" + Flatfile_Generate;

        return custid;
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        MP_DSC.Show();
        txt_path.Text = txt_Download_path.Text;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Path_details(string Folder_path, string branch_common)
    {
        //DSC_Insert_update
        string Branch = string.Empty;
        string userid = string.Empty;

        Branch = HttpContext.Current.Session["currentbranch"].ToString();
        userid = HttpContext.Current.Session["currentuser"].ToString();

        IMP_EXP_DSC IED = new IMP_EXP_DSC();
        IED.FILE_PATH = Folder_path;
        IED.IMP_EXP = "E";
        IED.BRANCH_CODE = Branch;
        IED.BRANCH_COMMON = branch_common;
        IED.USER_ID = userid;
        IED.FLAG = "S";
        IED.DSC_Insert_update();
        return "Save Successfully";
    }

    private void Load_Path()
    {
        IMP_EXP_DSC IED = new IMP_EXP_DSC();
        DataSet ds_d = new DataSet();
        IED.IMP_EXP = "E";
        IED.BRANCH_COMMON = SELECT_BRANCH;
        IED.USER_ID = currentuser;
        IED.FLAG = "";
        ds_d = IED.DSC_Insert_update();
        if (ds_d.Tables[0].Rows.Count > 0)
        {
            txt_Download_path.Text = ds_d.Tables[0].Rows[0]["FILE_PATH"].ToString();
        }

    }
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;

            for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
            {

                if (e.Row.Cells[i].Text == "F")
                {
                    e.Row.Cells[i].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[i].Font.Bold = true;

                }

            }

        }
    }
}