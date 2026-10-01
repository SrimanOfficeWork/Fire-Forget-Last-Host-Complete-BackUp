using System;
using System.Data; // This was added to make CommandType function
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

//using Microsoft.ApplicationBlocks.Data;
//using Microsoft.Reporting.WebForms;
//using System.Text.RegularExpressions;

public partial class Query_Reply_Export_QueryReply : ThemeClass
{
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, val;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();

    DataSet ds = new DataSet();
    DataSet dss = new DataSet();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, IS_Imgbtn;
    public string SELECT_TYPE, SELECT_BRANCH;

    CheckList CHKLIST = new CheckList();
    Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "", targetPath = "";
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
    public int is_Annexure_Mode = 0;
    public string CHA_NO = "", ICEGATE_ID = "";
    public string ICEGATE_EMAIL_ID = "", ICEGATE_EMAIL_PWD = "";
    public string EMail_ID = "";
    public string SB_NO = "";
    public string SB_DATE = "", GetDate_ddmmyy;
    public string IEC_NO;
    public string CUSTOMS_HOUSE;
    public string JOBDATE;
    public string DDMMYY_JOBDATE;
    public string COMPANY_ID = "";


    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();

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
            //errorFolder = Server.MapPath("~/Submission/");
            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Query_Reply/");

            //Removed by George Bush on 13-08-2026
            //if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
            //{
                if (Connection.Get_Company_Type() != "")
                {
                    targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "EXP_Job_history/");
                }
                else
                {
                    targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "EXP_Job_history/");
                }
            //}

            COMPANY_ID = Session["COMPANY_ID"].ToString();
            hdn_CompanyID.Value = COMPANY_ID;

            CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
            ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

            //ICEGATE_EMAIL_ID_NEW.Value = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            //ICEGATE_EMAIL_PWD_NEW.Value = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

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

                //ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
                if (!string.IsNullOrEmpty(Request["jobno"]))
                {

                    if (!string.IsNullOrEmpty(Request["SUB"]))
                    {
                        FlatFile.JOBNo = "";
                        FlatFile.Ename = "select_jobno";
                        FlatFile.Workingperiod = SELECT_BRANCH;
                        ddlJobNo.DataSource = FlatFile.Retrieve_Export_All_Details();
                        ddlJobNo.DataValueField = "JOBNO";
                        ddlJobNo.DataTextField = "JOBNO";
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

                        ddlJobNo.Items.Clear();
                        ddlJobNo.Items.Add(Request["jobno"].ToString());
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
                    ddlJobNo.DataTextField = "JOBNO";
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

                txtIEC_No.Attributes.Add("readonly", "readonly");
                txtCHA_No.Attributes.Add("readonly", "readonly");
                txtCustoms_Code.Attributes.Add("readonly", "readonly");
                txtJobDate.Attributes.Add("readonly", "readonly");

                txtIcegateID.Text = Connection.Get_Icegate_Id();

            }

            ApplyGridTheme();
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
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

            btnSearch.ToolTip = "You don't have permission to access";
            btnSubmission.ToolTip = "You don't have permission to access";
            imgbtnFlatFile.ToolTip = "You don't have permission to access";
        }
        else
        {
            btnSearch.Enabled = true;
            btnSubmission.Enabled = true;
            imgbtnFlatFile.Enabled = true;
        }
    }

    public void SB_Details()
    {
        FlatFile.JOBNo = ddlJobNo.SelectedValue.ToString();
        FlatFile.TRANSPORT_MODE = "";
        FlatFile.Ename = "FlatFile";
        FlatFile.Workingperiod = SELECT_BRANCH;
        ds = FlatFile.Retrieve_Export_All_Details();
        is_Annexure_Mode = FlatFile.result;

        Session["ds"] = ds;

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

                CUSTOMS_HOUSE = dt.Trim(ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString());

                IEC_NO = dt.Trim(ds.Tables[0].Rows[0]["IEC_NO"].ToString());

                //Get_Admin_Master_Codes();
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

                CUSTOMS_HOUSE = dt.Trim(ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString());

                IEC_NO = dt.Trim(ds.Tables[0].Rows[0]["IEC_NO"].ToString());

                //Get_Admin_Master_Codes();
            }
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //FlatFile.Get_AllDetails(ddlJobNo.SelectedValue.ToString());

        try
        {
            IS_Imgbtn = "";

            SB_Details();
            imgbtnFlatFile.Visible = false;
            btnSubmission.Visible = false;

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
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void imgbtnFlatFile_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            IS_Imgbtn = "1";

            imgbtnFlatFile.Visible = false;
            btnSubmission.Visible = false;

            string[] filePaths = Directory.GetFiles(errorFolder);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnSubmission_Click(object sender, EventArgs e)
    {
        SB_Details();
        string[] filePaths = Directory.GetFiles(errorFolder);
        string file = filePaths[0];

        mail(file);

        imgbtnFlatFile.Visible = true;
        btnSubmission.Visible = true;
    }

    public void Flat_File()
    {

        DateTime date = System.DateTime.Now;
        string datestringg = string.Format("{0:yyyyMMdd}", date);

        DateTime tt = System.DateTime.Now;

        string time = string.Format("{0:hhmm}", tt);
        GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
        string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();

        string sb_date = Convert.ToDateTime(txtSBDate.Text).ToString("ddMMyy").ToString();
        string job_date = Convert.ToDateTime(txtJobDate.Text).ToString("ddMMyy").ToString();
        string sbno_date = txtSBNo.Text + job_date;

        string sb_date_full = Convert.ToDateTime(txtSBDate.Text).ToString("yyyyMMdd").ToString();
        string sb_date1 = Convert.ToDateTime(txtSBDate.Text).ToString("yyyyMMMdd").ToString();


        //logFileName = ddlJobNo.SelectedValue.ToString() + yy + ".sb";
        logFileName = "SB_" + txtSBNo.Text + "_" + "QR_" + txtQueryNo.Text + ".rpl";

        createfilename = logFileName;
        Session["createflename"] = logFileName;
        sw = new StreamWriter(errorFolder + logFileName, true);
        // sw=new Html32TextWriter(

        //FileInfo file = new FileInfo(errorFolder + logFileName);
        //sw = file.CreateText();

        if (txtIcegateID.Text == "")
        {
            ICEGATE_ID = Connection.Get_Icegate_Id();
        }
        else
        {
            ICEGATE_ID = txtIcegateID.Text.ToUpper();
        }

        string query_date = Convert.ToDateTime(txtQueryDate.Text).ToString("yyyyMMMdd").ToString();

        sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHE04" + ch + sbno_date + ch + datestringg + ch + time);

        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + txtSBNo.Text + ch + sb_date1 + ch + txtQueryNo.Text + ch + query_date + ch + txtQuery_Reply.Text.Replace("\r\n", " "));

        sw.WriteLine("TREC" + ch + sbno_date);

        sw.Flush();
        sw.Close();
        sw.Dispose();
        //sw = null;


        ////Query Reply flatfile auto save to Job History folder also for Agility by Chitha
        //if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "747")
        //{
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                if (Directory.Exists(targetPath) == false)
                {
                    Directory.CreateDirectory(targetPath);
                }

                string sourceFile = System.IO.Path.Combine(errorFolder, logFileName);
                string destFile = System.IO.Path.Combine(targetPath, ddlJobNo.SelectedItem.Text + " ~~" + logFileName);

                System.IO.File.Copy(sourceFile, destFile, true);


                Job_Histroy jh = new Job_Histroy();

                jh.JOB_ID = "";
                jh.JOB_TYPE = "EXP";
                jh.JOBNO = ddlJobNo.SelectedItem.Text;
                jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
                jh.DESCRIPTION = targetPath;
                jh.ATTACHMENT_FILE = ddlJobNo.SelectedItem.Text + " ~~" + logFileName;
                jh.FLAG = "Upload_File";
                jh.USER_ID = currentuser;
                jh.JOBDATE = txtJobDate.Text;

                jh.BRANCH_CODE = currentbranch;
                jh.YEAR = "";
                jh.WORKING_PERIOD = Working_Period;
                jh.BRANCH_COMMON = SELECT_BRANCH;
                dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();

                if (!string.IsNullOrWhiteSpace(txtSBNo.Text) && !string.IsNullOrWhiteSpace(txtSBDate.Text))
                {
                    Exp_QueryReply_Insert_Update();

                    LoadGVQueryReply();
                }

            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        //}

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

        //client.EnableSsl = true;

        //client.Host = "smtp.gmail.com";

        //client.Port = 587;


        //--------------Live Configuration-----------------//
        //client.EnableSsl = true;
        //client.Host = "smtp.mail.yahoo.com";
        //client.Port = 587;
        //--------------Live Configuration-----------------//

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


        //client.Host = "127.0.0.1";
        //client.Port = 25;
        //client.EnableSsl = false;

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

        msg.Subject = ICEGATE_ID + "-" + ddlJobNo.SelectedValue.ToString() + "(" + "QR" + ")";
        //msg.Subject = "SB";

        msg.IsBodyHtml = true;

        //msg.Body = string.Format("<html><head></head><body><b>Flat File</b></body>");
        msg.Body = string.Format("<html><head></head><body><b></b></body>");

        msg.Attachments.Add(new System.Net.Mail.Attachment(filenm));

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
                txtCustoms_Code.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();

                txtJobDate.Text = ds.Tables[0].Rows[0]["JOBDATE1"].ToString();
                txtIEC_No.Text = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                txtCHA_No.Text = HttpContext.Current.Session["CHA_NO"].ToString();

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

                if (ds.Tables[7].Rows.Count > 0)
                {
                    var row = ds.Tables[7].Rows[0];

                    txtSBNo.Text = row["SB_NO"].ToString();
                    txtSBDate.Text = row["SB_DATE"].ToString();
                    txtQueryNo.Text = row["QUERY_NO"].ToString();
                    txtQueryDate.Text = row["QUERY_DATE"].ToString();
                    txtQuery_Reply.Text = row["QUERY_DESC"].ToString();
                }

                LoadGVQueryReply();
            }
            else
            {
                txtCustomHouse.Text = "";
                txtExporterName.Text = "";
                txtScheme.Text = "";
                txtConsignee.Text = "";
                txtNoofItems.Text = "";
                txtNoofInvoices.Text = "";

                txtIEC_No.Text = "";
                txtCHA_No.Text = "";
                txtJobDate.Text = "";
                txtCustoms_Code.Text = "";

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
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
                  select_branch = "",
                  txtIECNo = "", txtCHANo = "", txtJobDate = "";



        try
        {
            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
            txtCHANo = HttpContext.Current.Session["CHA_NO"].ToString();

            // commented for areawise implementation on 05-mar-2020
            /*
                select_branch = HttpContext.Current.Session["currentbranch"].ToString();
                select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();

                txtCHANo = HttpContext.Current.Session["CHA_NO"].ToString();

                if (select_type_ == "Branchwise Job")
                {
                    select_branch = select_branch;
                }
                else
                {
                    select_branch = "";
                }
                  * */
            select_branch = Connection.Get_Company_Type();
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

                txtJobDate = ds.Tables[0].Rows[0]["JOBDATE1"].ToString();
                txtIECNo = ds.Tables[0].Rows[0]["IEC_NO"].ToString();

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
                txtIECNo = "";
                txtCHANo = "";
                txtJobDate = "";

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
        //custid = txtCustomHouse + "~~" + txtExporterName + "~~" + txtScheme + "~~" + txtConsignee + "~~" + txtNoofItems + "~~" + txtNoofInvoices + "~~" + Annexure_Mode + "~~" + STR_Code;

        custid = txtCustomHouse + "~~" + txtExporterName + "~~" + txtScheme + "~~" + txtConsignee + "~~" + txtNoofItems + "~~" + txtNoofInvoices + "~~" + Annexure_Mode + "~~" + STR_Code + "~~" + txtIECNo + "~~" + txtCHANo + "~~" + txtJobDate;

        return custid;
    }



    private void Exp_QueryReply_Insert_Update()
    {
        var param = new[]
                 {                          
                     new SqlParameter("@JOBNO",              ddlJobNo.SelectedValue),
                     //new SqlParameter("@JOBDATE",            txtJobDate.Text),
                     new SqlParameter("@JOBDATE",            DateTime.Parse(txtJobDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)),
                     new SqlParameter("@QUERY_NO",           txtSBNo.Text),                     
                     //new SqlParameter("@QUERY_DATE",         txtSBDate.Text),
                     new SqlParameter("@QUERY_DATE",         DateTime.Parse(txtSBDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)),
                     new SqlParameter("@QUERY_DESC",         txtQuery_Reply.Text),  
                     new SqlParameter("@ICEGATE_ID",         txtIcegateID.Text.ToUpper()),
                     new SqlParameter("@STATUS",             ""),
                     new SqlParameter("@REMARKS",            ""),
                     new SqlParameter("@YEAR",               ""),
                     new SqlParameter("@USER_ID",            currentuser),   
                     new SqlParameter("@BRANCH_CODE",        currentbranch),
                     new SqlParameter("@WORKING_PERIOD",     Working_Period),
                     new SqlParameter("@Mflag",              "I"),
                 
                     new SqlParameter("@MStatus",    SqlDbType.Int)    { Direction = ParameterDirection.Output },
                     new SqlParameter("@ErrorMsg",   SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output },
                     //new SqlParameter("@Update_Id",  SqlDbType.BigInt) { Direction = ParameterDirection.Output },  
                 }; 

        SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_QUERY_REPLY_SAVE_UPDATE", param);

        int result = Convert.ToInt32(param.First(p => p.ParameterName == "@MStatus").Value);
        string errorMsg = param.First(p => p.ParameterName == "@ErrorMsg").Value.ToString();

    }

    private void LoadGVQueryReply()
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand("SP_EXPORT_QUERY_REPLY_SAVE_UPDATE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JOBNO", ddlJobNo.SelectedValue);
                cmd.Parameters.AddWithValue("@BRANCH_CODE", currentbranch);
                cmd.Parameters.AddWithValue("@Mflag", "S");

                cmd.Parameters.Add(new SqlParameter("@MStatus", SqlDbType.Int) { Direction = ParameterDirection.Output });
                cmd.Parameters.Add(new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output });

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
        }

        gv_QueryReply.DataSource = dt;
        gv_QueryReply.DataBind();
    }

    //protected void btnLoadGVQueryReply_Click(object sender, EventArgs e)
    //{
    //    LoadGVQueryReply();
    //}

    protected void gv_QueryReply_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_QueryReply.PageIndex = e.NewPageIndex;
        LoadGVQueryReply();
    }

    private void ApplyGridTheme()
    {
        string gradTop, gradBot;
        GetThemeColors(out gradTop, out gradBot);

        string css = @"
        <style type='text/css'>
            #gv_QueryReply_wrap .grid-view-styled th {
                background: linear-gradient(" + gradTop + @", " + gradBot + @") !important;
            }
            #gv_QueryReply_wrap .pager-row a {
                color: " + gradBot + @" !important;
                font-weight: 600;
            }
            #gv_QueryReply_wrap .grid-view-styled tr:hover td {
                background-color: " + gradTop + @"22 !important;
            }
            #lblQueryReplyHeading {
                 color: " + gradBot + @" !important;
            }

            .theme-report-btn {
                background-color: transparent !important;
                color: " + gradBot + @" !important;
                border: 1px solid " + gradBot + @" !important;
                padding: 6px 14px !important;
                font-size: 14px !important;
                font-weight: bold !important;
                border-radius: 4px !important;
                cursor: pointer !important;
                transition: background-color 0.15s ease, color 0.15s ease;
            }
            .theme-report-btn:hover {
                background: linear-gradient(" + gradTop + @", " + gradBot + @") !important;
                color: #fff !important;
                border-color: transparent !important;
            }
        </style>";

        litGridThemeCss.Text = css;
    }

    private void GetThemeColors(out string gradTop, out string gradBot)
    {
        string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "") ? Session["Theme"].ToString().ToLower() : "orange";
        switch (theme)
        {
            case "blue": gradTop = "#4a90e2"; gradBot = "#2b6cb0"; break;
            case "dblue": gradTop = "#2c3e60"; gradBot = "#16213a"; break;
            case "green": gradTop = "#43a047"; gradBot = "#2e7d32"; break;
            case "bluefancy": gradTop = "#5b86e5"; gradBot = "#36d1dc"; break;
            case "violetfancy": gradTop = "#8e2de2"; gradBot = "#4a00e0"; break;
            default: gradTop = "#f5a623"; gradBot = "#e08e0b"; break;
        }
    }



}
/* 
 
 vangogh, thasthowki , kafko
 Life changed books : Osho
 Fav Books of Osho The Book of Mirdad by Mikhail Naimy,The Brothers Karamazov by Fyodor Dostoevsky,Thus Spoke Zarathustra by Friedrich Nietzsche,Tao Te Ching by Lao Tzu,The Prophet by Kahlil Gibran.
 watchmen by alan moore,
 Cosmic horror,
 love craft, mahamut dharvesh palasten poet 
 * Multi passionate : Davinci,Einsteine



*/