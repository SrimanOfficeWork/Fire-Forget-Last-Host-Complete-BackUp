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
using System.Net.Mail;

using Microsoft.ApplicationBlocks.Data;

using Microsoft.Reporting.WebForms;

public partial class Transaction_Default2 : ThemeClass
{
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();

    DataSet ds = new DataSet();

    public string ICEGATE_EMAIL_ID = "", ICEGATE_EMAIL_PWD = "";
    public string EMail_ID = "";

    CheckList CHKLIST = new CheckList();
    Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();
    eroyalmaster erm = new eroyalmaster();

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "";
    public string folderName = "/Submission";
    ErrorLogs er = new ErrorLogs();
    public string createfilename = "";
    public char ch = Convert.ToChar(29);
    StreamWriter sw;
    public string CHA_NO = "", ICEGATE_ID = "", JOBDT_DDMMYY;
    public string COMPANY_NAME = "";
    public string COMPANY_ID = "";
    public string Report_type = "";

    #region EGM_Details

    private string EGM_ID;
    private string JOBNO;


    private string JOBDATE;
    private string ROTATION_NO;
    private string ROTATION_DATE;
    private string LINER_NAME;
    private string VESSEL_NAME;

    private string IMO_NO;
    private string VOYAGE_NO;
    private string SBNO;
    private string SB_DATE;
    private string PORT_ORIGIN;
    private string DESTINATION_PORT;
    private string GATEWAY_PORT;
    private string NATURE_OF_CARGO;
    private string QUATITY;
    private string UNIT_QTY;
    private string NO_OF_PKGS;
    private string DESCRIPTION;

    private string EXPORTER_NAME;
    private string EXPORTER_ADD1;
    private string EXPORTER_ADD2;
    private string EXPORTER_ADD3;
    private string EXPORTER_ADD4;

    private string CONSIGNEE_NAME;
    private string CONSIGNEE_ADD1;
    private string CONSIGNEE_ADD2;
    private string CONSIGNEE_ADD3;
    private string CONSIGNEE_ADD4;

    #endregion

    #region Container

    public string EGM_CONID;
    public string SLNO;
    public string CONTAINER_NO;
    public string SIZE;
    public string TYPE;

    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession_Subfolder();

            CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
            ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");

            COMPANY_ID = Session["COMPANY_ID"].ToString();

            if (Request.QueryString["jobno"] != "")
            {
            }

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


                if (!string.IsNullOrEmpty(Request["jobno"]))
                {

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                    currdiv.Style.Add("display", "none");

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("innerbox_Main_Top_User");
                    currdiv1.Style.Add("display", "none");

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("maincontent");
                    currdiv2.Style.Add("margin", "-16px 2px 0 0");
                    currdiv2.Style.Add("padding", "2px 0 0");

                    /*ddlJobNo.Items.Clear();
                    ddlJobNo.Items.Add(Request["jobno"].ToString());
                    //ddlJobNo.Items.Remove("0");
                    //ddlJobNo.Items.Insert(0, "Select");
                    */

                    if (Request["jobno"].ToString().Contains('-'))
                    {
                        string[] sp = Request["jobno"].ToString().Split('-');

                        ddlJobNo.Items.Clear();
                        ddlJobNo.Items.Insert(0, new ListItem(sp[0], Request["jobno"].ToString()));
                        ddlJobNo.SelectedIndex = 0;
                        ViewState["Report_type"] = "Consolidate";
                        hdn_Report_Type.Value = "Consolidate";
                        hdn_Jobno.Value = sp[0];
                    }
                    else
                    {
                        ddlJobNo.Items.Clear();
                        ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                        ddlJobNo.SelectedIndex = 0;
                        ViewState["Report_type"] = "Normal";
                        hdn_Report_Type.Value = "Normal";
                        hdn_Jobno.Value = Request["jobnops"].ToString();

                    }

                }
                else
                {
                    FlatFile.JOBNo = "";
                    FlatFile.Ename = "select_jobno";
                    FlatFile.Workingperiod = Connection.Get_Company_Type();
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
            ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + hdn_Jobno.ClientID + "', '" + hdn_Report_Type.ClientID + "')");
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

  
    public void EGM_Details()
    {
        if (ViewState["Report_type"].ToString() == "Consolidate")
        {
            FlatFile.JOBNo = ddlJobNo.SelectedItem.Text;
            FlatFile.TRANSPORT_MODE = hdn_TransportMode.Value;
            FlatFile.Ename = "EGM_CONSOLIDATE_FlatFile_Format";
            FlatFile.Workingperiod = Connection.Get_Company_Type();
            ds = FlatFile.Retrieve_Export_All_Details();
        }
        else
        {
            FlatFile.JOBNo = ddlJobNo.SelectedValue.ToString();
            FlatFile.TRANSPORT_MODE = hdn_TransportMode.Value;
            FlatFile.Ename = "EGM_FlatFile_Format";
            FlatFile.Workingperiod = Connection.Get_Company_Type();
            ds = FlatFile.Retrieve_Export_All_Details();
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //FlatFile.Get_AllDetails(ddlJobNo.SelectedValue.ToString());
        try
        {
            EGM_Details();
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

    protected void btnSubmission_Click(object sender, EventArgs e)
    {
        try
        {
            EGM_Details();
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

                mail(errorFolder + logFileName);

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

                mail(errorFolder + logFileName);

                imgbtnFlatFile.Visible = true;
                btnSubmission.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Flat_File()
    {
        logFileName = ddlJobNo.SelectedValue.ToString() + ".egm";
        logFileName = hdn_Jobno.Value + ".egm";
        createfilename = logFileName;
        Session["createflename"] = logFileName;
        sw = new StreamWriter(errorFolder + logFileName, true);
        DateTime date = System.DateTime.Now;
        string datestringg = string.Format("{0:yyyyMMdd}", date);

        DateTime tt = System.DateTime.Now;

        string time = string.Format("{0:hhmm}", tt);
        //if (ds.Tables[7].Rows.Count > 0)
        //{
        //    JOBDATE = ds.Tables[7].Rows[0]["JOBDATE"].ToString().Replace("19000101", "");
        //    JOBDT_DDMMYY = ds.Tables[7].Rows[0]["JOBDT_DDMMYY"].ToString().Replace("010100", "");
        //}
        int x = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            while (ds.Tables[0].Rows.Count > x)
            {

                JOBNO = ds.Tables[0].Rows[x]["JOBNO"].ToString();
                JOBDATE = ds.Tables[0].Rows[x]["JOBDATE"].ToString().Replace("19000101", "");
                ROTATION_NO = ds.Tables[0].Rows[x]["ROTATION_NO"].ToString();
                ROTATION_DATE = ds.Tables[0].Rows[x]["ROTATION_DATE"].ToString();
                VOYAGE_NO = ds.Tables[0].Rows[x]["VOYAGE_NO"].ToString();
                SBNO = ds.Tables[0].Rows[x]["SBNO"].ToString();
                SB_DATE = ds.Tables[0].Rows[x]["SB_DATE"].ToString();
                PORT_ORIGIN = ds.Tables[0].Rows[x]["PORT_ORIGIN"].ToString();
                //if (PORT_ORIGIN.Contains("-"))
                //{
                //    string[] sp = PORT_ORIGIN.Split('-');
                //    PORT_ORIGIN = sp[1];
                //}

                DESTINATION_PORT = ds.Tables[0].Rows[x]["DESTINATION_PORT"].ToString();

                if (DESTINATION_PORT.Contains("-"))
                {
                    string[] sp = DESTINATION_PORT.Split('-');
                    DESTINATION_PORT = sp[1];
                }

                GATEWAY_PORT = ds.Tables[0].Rows[x]["GATEWAY_PORT"].ToString();
                NATURE_OF_CARGO = ds.Tables[0].Rows[x]["NATURE_OF_CARGO"].ToString();
                QUATITY = ds.Tables[0].Rows[x]["QUATITY"].ToString();
                UNIT_QTY = ds.Tables[0].Rows[x]["UNIT_QTY"].ToString();
                NO_OF_PKGS = ds.Tables[0].Rows[x]["NO_OF_PKGS"].ToString();
                DESCRIPTION = ds.Tables[0].Rows[x]["DESCRIPTION"].ToString();


                if (x == 0)
                {
                    //sw.WriteLine("HREC" + ch + "ZZ" + ch + Session["currentcomp_name"].ToString().Trim() + ch + "ZZ" + ch + CHA_NO + ch + "ICES1_5" + ch + "P" + ch + "ZZ" + ch + VOYAGE_NO + ch + "SACHE18" + ch + ddlJobNo.SelectedValue.ToString() + JOBDT_DDMMYY + ch + JOBDATE + ch + time);
                    //sw.WriteLine("HREC" + ch + "ZZ" + ch + Session["currentcomp_name"].ToString().Trim() + ch + "ZZ" + ch + CHA_NO + ch + "ICES1_5" + ch + "P" + ch + "ZZ" + ch + VOYAGE_NO + ch + "SACHE18" + ch + ddlJobNo.SelectedValue.ToString()  + ch + JOBDATE + ch + time);
                    sw.WriteLine("HREC" + ch + "ZZ" + ch + Session["currentcomp_name"].ToString().Trim() + ch + "ZZ" + ch + CHA_NO + ch + "ICES1_5" + ch + "P" + ch + "ZZ" + ch + VOYAGE_NO + ch + "SACHE18" + ch + "2018007" + ch + JOBDATE + ch + time);


                    sw.WriteLine("<EGM-manifest>");

                    sw.WriteLine("<egm_master>F");
                }

                //this line hide on 04-03-2020 for changed the New format
                //sw.WriteLine(ROTATION_NO + ch + ROTATION_DATE + ch + SBNO + ch + SB_DATE + ch + PORT_ORIGIN + ch + DESTINATION_PORT + ch + GATEWAY_PORT + ch + NATURE_OF_CARGO + ch + QUATITY + ch + UNIT_QTY + ch + NO_OF_PKGS + ch + "Y" + ch);
                sw.WriteLine(ROTATION_NO + ch + ROTATION_DATE + ch + SBNO + ch + SB_DATE + ch + PORT_ORIGIN + ch + DESTINATION_PORT + ch + GATEWAY_PORT + ch + NATURE_OF_CARGO + ch + QUATITY + ch + UNIT_QTY + ch + NO_OF_PKGS + ch + "Y" + ch + DESCRIPTION + ch);


                //sw1.WriteLine("<END-MASTER>");
                x = x + 1;
            }

        }


        int k = 0;
        if (ds.Tables[1].Rows.Count > 0)
        {
            sw.WriteLine("<egmcont>F");
            while (ds.Tables[1].Rows.Count > k)
            {
                CONTAINER_NO = ds.Tables[1].Rows[k]["CONTAINER_NO"].ToString();
                SIZE = ds.Tables[1].Rows[k]["SIZE"].ToString();
                TYPE = ds.Tables[1].Rows[k]["TYPE"].ToString();
                SBNO = ds.Tables[1].Rows[k]["SBNO"].ToString();

                var query_SBNO = from r in ds.Tables[0].AsEnumerable()
                                 where (r.Field<string>("SBNO") == SBNO)
                                 select r;

                if (query_SBNO.Count() > 0)
                {
                    DataTable dt_sb = query_SBNO.CopyToDataTable();

                    if (dt_sb.Rows.Count > 0)
                    {
                        SB_DATE = dt_sb.Rows[0]["SB_DATE"].ToString();

                    }
                }

                sw.WriteLine(ROTATION_NO + ch + ROTATION_DATE + ch + SBNO + ch + SB_DATE + ch + CONTAINER_NO + ch + TYPE + ch + "Y" + ch);

                k++;
            }
            sw.WriteLine("<END-egmcont>");
        }

        k = 0;
        if (ds.Tables[1].Rows.Count > 0)
        {
            sw.WriteLine("<egmcontsize>F");
            while (ds.Tables[1].Rows.Count > k)
            {
                CONTAINER_NO = ds.Tables[1].Rows[k]["CONTAINER_NO"].ToString();
                SIZE = ds.Tables[1].Rows[k]["SIZE"].ToString();
                TYPE = ds.Tables[1].Rows[k]["TYPE"].ToString();
                SBNO = ds.Tables[1].Rows[k]["SBNO"].ToString();

                sw.WriteLine(ROTATION_NO + ch + SBNO + ch + CONTAINER_NO + ch + SIZE + ch);

                k++;
            }
            sw.WriteLine("<END-egmcontsize>");
        }

        int z = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            sw.WriteLine("<egmexporter>F");
            while (ds.Tables[0].Rows.Count > z)
            {
                SBNO = ds.Tables[0].Rows[z]["SBNO"].ToString();
                SB_DATE = ds.Tables[0].Rows[z]["SB_DATE"].ToString();
                EXPORTER_NAME = ds.Tables[0].Rows[z]["EXPORTER_NAME"].ToString();
                EXPORTER_ADD1 = ds.Tables[0].Rows[z]["EXPORTER_ADD1"].ToString();
                EXPORTER_ADD2 = ds.Tables[0].Rows[z]["EXPORTER_ADD2"].ToString();
                EXPORTER_ADD3 = ds.Tables[0].Rows[z]["EXPORTER_ADD3"].ToString();
                EXPORTER_ADD4 = ds.Tables[0].Rows[z]["EXPORTER_ADD4"].ToString();
                CONSIGNEE_NAME = ds.Tables[0].Rows[z]["CONSIGNEE_NAME"].ToString();
                CONSIGNEE_ADD1 = ds.Tables[0].Rows[z]["CONSIGNEE_ADD1"].ToString();
                CONSIGNEE_ADD2 = ds.Tables[0].Rows[z]["CONSIGNEE_ADD2"].ToString();
                CONSIGNEE_ADD3 = ds.Tables[0].Rows[z]["CONSIGNEE_ADD3"].ToString();
                CONSIGNEE_ADD4 = ds.Tables[0].Rows[z]["CONSIGNEE_ADD4"].ToString();

                sw.WriteLine(SBNO + ch + SB_DATE + ch + EXPORTER_NAME + ch + EXPORTER_ADD1 + ch + EXPORTER_ADD2 + ch + EXPORTER_ADD3 + ch + EXPORTER_ADD4 + ch + CONSIGNEE_NAME + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch);
                z = z + 1;
            }
            sw.WriteLine("<END-egmexporter>");

        }


        sw.WriteLine("<END-egm_master>");

        //sw.WriteLine("TREC" + ch + ddlJobNo.SelectedValue.ToString() + JOBDT_DDMMYY);// Modified on 06Sep2014 with subbu sir
        //sw.WriteLine("TREC" + ch + ddlJobNo.SelectedValue.ToString());
        sw.WriteLine("TREC" + ch + "2018007");

        sw.Flush();
        sw.Close();
        sw.Dispose();

    }
    

    public void mail(string filenm)
    {
        //if (ICEGATE_EMAIL_ID != "" && ICEGATE_EMAIL_PWD != "")
        //{
        EMail_ID = txtCustomHouse.Text + "@icegate.gov.in";

        SmtpClient client = new SmtpClient();

        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        //client.EnableSsl = true;

        //client.Host = "smtp.gmail.com";

        //client.Port = 587;

        //--------------Yahoo Configuration-----------------//
        //client.EnableSsl = true;
        //client.Host = "smtp.mail.yahoo.com";
        //client.Port = 587;

        //--------------Yahoo Configuration-----------------//

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

        //client.Port = 25;
        //client.EnableSsl = false;


        // setup Smtp authentication

        //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("sathishkumar8789@gmail.com", "skoushik");
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ICEGATE_EMAIL_ID, ICEGATE_EMAIL_PWD);

        client.UseDefaultCredentials = false;

        client.Credentials = credentials;

        MailMessage msg = new MailMessage();

        //msg.From = new MailAddress("sathishkumar8789@gmail.com");
        msg.From = new MailAddress(ICEGATE_EMAIL_ID);

        //msg.To.Add(new MailAddress("admin@royaltechsystems.co.in"));
        //msg.To.Add(new MailAddress("balaji71187@gmail.com"));
        msg.To.Add(new MailAddress(EMail_ID));

        // msg.CC.Add(new MailAddress("gsathishkumar83@yahoo.com"));

        msg.Subject = ICEGATE_ID + "-" + ddlJobNo.SelectedValue.ToString() + "(" + "GR" + ")";
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

    [System.Web.Services.WebMethod]
    public static string Get_Import_Details(string custid, string type)
    {
        Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();
        DataSet ds = new DataSet();

        string txtCustomHouse = "",
               txtExporterName = "",
               txtScheme = "",
               txtConsignee = "",
               txtNoofItems = "",
               txtNoofInvoices = "", hdn_TransportMode = "";

        try
        {

            if (custid.Contains('-'))
            {
                string[] sp = custid.Split('-');
                custid = sp[0];
            }

            if (type == "Consolidate")
            {
                FlatFile.JOBNo = custid;
                FlatFile.TRANSPORT_MODE = "";
                FlatFile.Ename = "EGM_CONSOLIDATE_FlatFile_Format";
                FlatFile.Workingperiod = Connection.Get_Company_Type();
                ds = FlatFile.Retrieve_Export_All_Details();
            }
            else
            {
                FlatFile.JOBNo = custid;
                FlatFile.TRANSPORT_MODE = "";
                FlatFile.Ename = "EGM_FlatFile_Format";
                FlatFile.Workingperiod = Connection.Get_Company_Type();
                ds = FlatFile.Retrieve_Export_All_Details();
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse = ds.Tables[0].Rows[0]["GATEWAY_PORT"].ToString();
                txtExporterName = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txtConsignee = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
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
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
        custid = txtCustomHouse + "~~" + txtExporterName + "~~" + txtScheme + "~~" + txtConsignee + "~~" + txtNoofItems + "~~" + txtNoofInvoices + "~~" + hdn_TransportMode;

        return custid;
    }
}