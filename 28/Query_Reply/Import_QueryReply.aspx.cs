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
//using Microsoft.ApplicationBlocks.Data;
//using Microsoft.Reporting.WebForms;
using System.Net.Mail;
using Microsoft.ApplicationBlocks.Data;

public partial class Query_Reply_Import_QueryReply : ThemeClass
{
    DataSet dss = new DataSet();
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
    public string working_period;
    private string _Workingperiod;
    DataSet ds = new DataSet();

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public string ICEGATE_EMAIL_ID = "", ICEGATE_EMAIL_PWD = "";
    public string EMail_ID = "";
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string LoginDate, IS_Imgbtn;
    public string GetDate_ddmmyy;
    public string CUSTOMS_HOUSE;

    FlatFile_Generation FlatFile = new FlatFile_Generation();
    AppSession aps = new AppSession();

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "", targetPath = "";
    public string folderName = "/Submission";
    ErrorLogs er = new ErrorLogs();
    StreamWriter sw;
    public string createfilename = "";
    public char ch = Convert.ToChar(29);
    public string CHA_NO = "", ICEGATE_ID = "";
    public string SELECT_TYPE, SELECT_BRANCH;
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
            CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
            ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Query_Reply/");

            //Removed by George Bush on 13-08-2026
            //if (Connection.COMPANYID() == "11" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "5" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
            //{

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

            //}

            COMPANY_ID = Session["COMPANY_ID"].ToString();
            hdn_CompanyID.Value = COMPANY_ID;

            SELECT_BRANCH = Connection.Get_Company_Type();
            HDBranch.Value = SELECT_BRANCH;


            if (!IsPostBack)
            {
                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }

                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 7;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                //ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
                txt_jobno_search.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txt_jobno_search.ClientID + "', '" + txtCustomHouse.ClientID + "')");

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
                txtCustomHouse.Attributes.Add("readonly", "readonly");
                txtImporterName.Attributes.Add("readonly", "readonly");
                txtBE_Type.Attributes.Add("readonly", "readonly");
                txtSupplier.Attributes.Add("readonly", "readonly");
                txtNoofItems.Attributes.Add("readonly", "readonly");
                txtNoofInvoices.Attributes.Add("readonly", "readonly");

                txtIcegateID.Text = Connection.Get_Icegate_Id();
                txt_jobno_search.Focus();
            }

            ApplyGridTheme();
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //FlatFile.Get_AllDetails(ddlJobNo.SelectedValue.ToString());

        try
        {
            IS_Imgbtn = "";

            //BE_Details();
            imgbtnFlatFile.Visible = false;
            btnSubmission.Visible = false;
            btnSendQueue.Visible = false;

            DirectoryInfo dir = new DirectoryInfo(errorFolder);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            Flat_File("GenerateButton");

            imgbtnFlatFile.Visible = true;
            // btnSubmission.Visible = true;
            btnSendQueue.Visible = true;

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
            btnSendQueue.Enabled = false;

            btnSearch.ToolTip = "You don't have permission to access";
            btnSubmission.ToolTip = "You don't have permission to access";
            imgbtnFlatFile.ToolTip = "You don't have permission to access";
            btnSendQueue.ToolTip = "You don't have permission to access";
        }
        else
        {
            btnSearch.Enabled = true;
            btnSubmission.Enabled = true;
            imgbtnFlatFile.Enabled = true;
            btnSendQueue.Enabled = true;

        }
    }

    [System.Web.Services.WebMethod]
    public static string Get_Import_Details(string custid)
    {
        string select_branch = "", Working_Period = "", txtCustomHouse = "",
               txtImporterName = "",
               txtBE_Type = "",
               txtSupplier = "",
               txtNoofItems = "",
               txtNoofInvoices = "",
               txtBENo = "",
               txtBEDate = "",
               hdn_JOBNO = "", txtJobdate = "";


        try
        {
            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
            select_branch = Connection.Get_Company_Type();
            CheckList chklist = new CheckList();
            chklist.JOBNo = custid;
            //chklist.Ename = "select_jobno_CheckList";
            chklist.Ename = "select_jobno_QueryReply";

            chklist.Workingperiod = select_branch;
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();


            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                HttpContext.Current.Session["CUSTOMS_HOUSE"] = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtImporterName = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txtBE_Type = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();
                txtJobdate = ds.Tables[0].Rows[0]["JOBDATE"].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtSupplier = ds.Tables[1].Rows[0]["SUPPLIER_NAME"].ToString();
                }
                else
                {
                    txtSupplier = "";
                }

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

                if (ds.Tables[4].Rows.Count > 0)
                {
                    txtBENo = ds.Tables[4].Rows[0]["BE_NO"].ToString();
                    txtBEDate = ds.Tables[4].Rows[0]["BE_DATE"].ToString();

                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    hdn_JOBNO = ds.Tables[5].Rows[0]["JOBNO"].ToString();
                }
                //General_Details Import_General = new General_Details();
                //Import_General.Retrieve_GetGeneral(custid);

            }
            else
            {
                txtCustomHouse = "";
                txtImporterName = "";
                txtBE_Type = "";
                txtSupplier = "";
                txtNoofItems = "";
                txtNoofInvoices = "";
                txtBENo = "";
                txtBEDate = ""; txtJobdate = "";

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
        custid = txtCustomHouse + "~~" + txtImporterName + "~~" + txtBE_Type + "~~" + txtSupplier + "~~" + txtNoofItems + "~~" + txtNoofInvoices + "~~" + txtBENo + "~~" + txtBEDate + "~~" + hdn_JOBNO + "~~" + txtJobdate;

        return custid;
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

                mail(errorFolder + logFileName);

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

        //string JOBNO = txt_jobno_search.Text;
        string JOBNO = hdn_JOBNO.Value;


        DateTime date = System.DateTime.Now;
        string datestringg = string.Format("{0:yyyyMMdd}", date);

        DateTime tt = System.DateTime.Now;
        string time = string.Format("{0:hhmm}", tt);

        GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
        string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();
        string be_date = Convert.ToDateTime(txtBEDate.Text).ToString("ddMMyy").ToString();
        string beno_date = txtBENo.Text + be_date;
        string be_date_full = Convert.ToDateTime(txtBEDate.Text).ToString("yyyyMMdd").ToString();


        logFileName = "bereply_" + txtBENo.Text + "_" + JOBNO + ".rpl";
        //"bereply_"  + "beno" + "_"  + "jobno" + ".rpl"//
        createfilename = logFileName;
        Session["createflename"] = logFileName;

        //delete the exisitng file

        if (File.Exists(errorFolder + logFileName))
        {

            File.Delete((errorFolder + logFileName));
        }

        //
        sw = new StreamWriter(errorFolder + logFileName, true);

        CUSTOMS_HOUSE = HttpContext.Current.Session["CUSTOMS_HOUSE"].ToString();

        if (txtIcegateID.Text == "")
        {
            ICEGATE_ID = Connection.Get_Icegate_Id();
        }
        else
        {
            ICEGATE_ID = txtIcegateID.Text.ToUpper();
        }



        sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + "" + ch + "CACHI06" + ch + beno_date + ch + datestringg + ch + time);
        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + txtBENo.Text + ch + be_date_full + ch + txtQueryNo.Text + ch + datestringg + ch + txtQuery_Reply.Text.Replace("\r\n", " "));
        sw.WriteLine("TREC" + ch + beno_date);
        //sw.WriteLine();
        //sw.Write("/n");

        DateTime dat = System.DateTime.Now;
        string datestring = string.Format("{0:dd/MM/yyyy}", dat);

        sw.Close();
        sw.Dispose();
        Job_Histroy jh = new Job_Histroy();
        if (process != "SendQueue")
        {
            ////Query Reply flatfile auto save to Job History folder also for Agility by Chitha
            //if (Connection.COMPANYID() == "11" || Connection.COMPANYID() == "5" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
            //{
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
                jh.JOB_TYPE = "IMP";
                jh.JOBNO = JOBNO;

                jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
                jh.DESCRIPTION = targetPath;
                jh.ATTACHMENT_FILE = JOBNO + " ~~" + logFileName;
                jh.FLAG = "Upload_File";
                jh.USER_ID = currentuser;
                jh.JOBDATE = "01/01/1900";

                jh.BRANCH_CODE = currentbranch;
                jh.YEAR = "QueryReply";
                jh.WORKING_PERIOD = Working_Period;
                jh.BRANCH_COMMON = SELECT_BRANCH;
                dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();

                if (!string.IsNullOrWhiteSpace(txtQueryNo.Text) && !string.IsNullOrWhiteSpace(txtQuery_Reply.Text))
                {
                    Imp_QueryReply_Insert_Update(process);

                    LoadGVQueryReply();
                }

            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
            //}
        }
        else if (process == "SendQueue")
        {
            //DSC_FLATFILE_INSERT_UPDATE

            string SQ_Path = string.Empty;
            string SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            if (SELECT_TYPE == "Branchwise Job")
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "IMP" + "/"
                    +
                    Session["currentbranch"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                    + "/");
            }
            else if (SELECT_TYPE == "Areawise Job")
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "IMP" + "/"
                    +
                    Session["GroupName"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                    + "/");
            }

            else
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "IMP" + "/");
            }


            if (Directory.Exists(SQ_Path) == false)
            {
                Directory.CreateDirectory(SQ_Path);
            }

            string sourceFile2 = System.IO.Path.Combine(errorFolder, logFileName);

            System.IO.File.Copy(sourceFile2, SQ_Path + logFileName, true);


            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            url = url.Substring(0, url.IndexOf("Query_Reply")) + SQ_Path.Substring(SQ_Path.IndexOf("FlatFile_DSC"), SQ_Path.Length - (SQ_Path.IndexOf("FlatFile_DSC"))) + logFileName;
            jh.JOB_ID = url.Replace(@"\", @"/");


            jh.JOB_TYPE = "IMP";
            jh.JOBNO = JOBNO;

            jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
            jh.DESCRIPTION = SQ_Path + logFileName;
            jh.ATTACHMENT_FILE = JOBNO + " ~~" + logFileName;
            jh.FLAG = "QueryReply_Insert";
            jh.USER_ID = currentuser;
            jh.JOBDATE = txtJobdate.Text;
            jh.BRANCH_CODE = currentbranch;
            jh.YEAR = "";
            jh.WORKING_PERIOD = Working_Period;
            jh.BRANCH_COMMON = SELECT_BRANCH;
            dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows[0][0].ToString() == "1")
                {
                    lblsent_date.Text = dss.Tables[0].Rows[0][1].ToString();
                    Alert_msg("Sent Successfully");

                    if (!string.IsNullOrWhiteSpace(txtQueryNo.Text) && !string.IsNullOrWhiteSpace(txtQuery_Reply.Text)) //YG
                    {
                        Imp_QueryReply_Insert_Update(process);

                        LoadGVQueryReply();
                    }
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

    protected void imgbtnFlatFile_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            IS_Imgbtn = "1";
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

                Flat_File("ImageButton");

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

    public void mail(string filenm)
    {

        //string JOBNO = txt_jobno_search.Text;
        string JOBNO = hdn_JOBNO.Value;

        //if (ICEGATE_EMAIL_ID != "" && ICEGATE_EMAIL_PWD != "")
        //{
        EMail_ID = CUSTOMS_HOUSE + "@icegate.gov.in";


        //CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
        //ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
        //ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
        //ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

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

        //msg.Subject = ICEGATE_ID + "-" + ddlJobNo.SelectedValue.ToString() + "(" + "QR" + ")";
        msg.Subject = ICEGATE_ID + "-" + JOBNO + "(" + "QR" + ")";
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

    protected void btnSendQueue_Click(object sender, EventArgs e)
    {

        try
        {
            Flat_File("SendQueue");



        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    private void Imp_QueryReply_Insert_Update(string process)
    {

        var param = new[]
                 {                          
                     new SqlParameter("@JOBNO",              txt_jobno_search.Text),
                     //new SqlParameter("@JOBDATE",            txtJobdate.Text),//DateTime.Parse(txtJobdate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)),
                     new SqlParameter("@JOBDATE",            DateTime.Parse(txtJobdate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)),
                     new SqlParameter("@QUERY_NO",           txtQueryNo.Text),
                     new SqlParameter("@QUERY_DESC",         txtQuery_Reply.Text),  
                     new SqlParameter("@ICEGATE_ID",         txtIcegateID.Text.ToUpper()),
                     new SqlParameter("@STATUS",             ""),
                     new SqlParameter("@REMARKS",            ""),
                     new SqlParameter("@YEAR",               process),
                     new SqlParameter("@USER_ID",            currentuser),   
                     new SqlParameter("@BRANCH_CODE",        currentbranch),
                     new SqlParameter("@WORKING_PERIOD",     Working_Period),
                     new SqlParameter("@Mflag",              "I"),
                 
                     new SqlParameter("@MStatus",    SqlDbType.Int)    { Direction = ParameterDirection.Output },
                     new SqlParameter("@ErrorMsg",   SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output },
                     //new SqlParameter("@Update_Id",  SqlDbType.BigInt) { Direction = ParameterDirection.Output },  
                 };


        SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_QUERY_REPLY_SAVE_UPDATE", param);


        int result = Convert.ToInt32(param.First(p => p.ParameterName == "@MStatus").Value);
        string errorMsg = param.First(p => p.ParameterName == "@ErrorMsg").Value.ToString();

    }

    private void LoadGVQueryReply()
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand("SP_IMPORT_QUERY_REPLY_SAVE_UPDATE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JOBNO", txt_jobno_search.Text);
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

    protected void btnLoadGVQueryReply_Click(object sender, EventArgs e)
    {
        LoadGVQueryReply();
        LoadGVQueryRaised();
    }

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

    private void LoadGVQueryRaised()
    {
        #region

        string financialYear = GetFinancialYear();
        

        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(  HttpContext.Current.Session["currentcomp_db"].ToString()))
        {
            //string query = @"SELECT BE_NO,BE_DATE,MailSubject FROM emailsread WHERE file_remarks = 'Query' AND BE_NO = @BE_NO AND JOB_NO = @JOB_NO ORDER BY job_no DESC";
            string query = @"SELECT BE_NO,BE_DATE,MailSubject FROM emailsread WHERE file_remarks = 'Query' AND BE_NO = @BE_NO ORDER BY job_no DESC";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@BE_NO", txtBENo.Text.Trim());
                //cmd.Parameters.AddWithValue("@JOB_NO", txt_jobno_search.Text.Trim());
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
        }


        string outFolderPath = HttpContext.Current.Server.MapPath("~/Submission/" + financialYear + "/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + Session["GroupName"].ToString() + "/" + "Attachments/");
        //string outFolderPath = @"C:\Users\RoyalTech\Downloads\";


        DataTable dtQueryRaised = new DataTable();
        //dtQueryRaised.Columns.Add("SNo");
        dtQueryRaised.Columns.Add("BE_NO");
        dtQueryRaised.Columns.Add("BE_DATE");
        dtQueryRaised.Columns.Add("QueryDescription");
        dtQueryRaised.Columns.Add("FileName");

        //int sno = 1;

        foreach (DataRow row in dt.Rows)
        {
            string mailSubject = row["MailSubject"].ToString().Trim();

            if (string.IsNullOrEmpty(mailSubject))
                continue;

            string filePath = Path.Combine(outFolderPath, mailSubject);

            if (!File.Exists(filePath))
                continue;

            string fileContent = File.ReadAllText(filePath);

            string queryDescription = "";

            string[] lines = fileContent.Split(new[] { "\r\n", "\n", "\r" },StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                if (line.StartsWith("F" + "\x1D"))
                {
                    int lastSeparator = line.LastIndexOf('\x1D');

                    if (lastSeparator >= 0)
                    {
                        queryDescription = line.Substring(lastSeparator + 1).Trim();
                    }

                    break;
                }
            }
            // Get values from original DataTable
            string beNo = row["BE_NO"].ToString();
            string beDate = row["BE_DATE"].ToString();
            string fileName = row["MailSubject"].ToString().Trim();

            // Add into QueryRaised DataTable
            DataRow newRow = dtQueryRaised.NewRow();

            //newRow["SNo"] = sno++;
            newRow["BE_NO"] = beNo;
            newRow["BE_DATE"] = beDate;
            newRow["QueryDescription"] = queryDescription;
            newRow["FileName"] = fileName;

            dtQueryRaised.Rows.Add(newRow);
        }


        // Bind to GridView
        gvQueryRaised.DataSource = dtQueryRaised;
        gvQueryRaised.DataBind();

        #endregion       
    }

    protected void gvQueryRaised_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQueryRaised.PageIndex = e.NewPageIndex;
        LoadGVQueryRaised();
    }

    private string GetFinancialYear()
    {
        DateTime today = DateTime.Now;

        if (today.Month >= 4) // April to December
        {
            return today.Year + "-" + (today.Year + 1).ToString().Substring(2);
        }
        else // January to March
        {
            return (today.Year - 1) + "-" + today.Year.ToString().Substring(2);
        }
    }

}