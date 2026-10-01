using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Net;
using System.Net.Security;
using System.Security.Authentication;
using System.Threading;
using System.Xml;
using System.Text.RegularExpressions;
using Aspose.Pdf;
using Newtonsoft.Json;
using System.Data.OleDb;
using Aspose.Email.Clients.Pop3;
using Aspose.Email.Tools.Search;
using Aspose.Email.Clients;
using Aspose.Email;
using Aspose.Email.Clients.Imap;
using System.Web;
using System.Web.Script.Serialization;


using System.Web.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using Newtonsoft.Json;
using System.IO;
using System.Web.Hosting;
using Aspose.Foundation.UriResolver.RequestResponses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class Read_mail
{
    public Maildb mdb = new Maildb();
    public Maildb Mail_Db = new Maildb();
   
     eroyalmaster erm = new eroyalmaster();
    public static ImapClient client_IMAP = new ImapClient();
    public static Pop3Client client_POP = new Pop3Client();

    private static readonly object syncLock = new object();
    private static readonly object syncObject = new object();

    public static Manipulation mo;
    public static ImapClient client;
    //-----------------------------------------------------------------------------------
    public IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    //-----------------------------------------------------------------------------------
    public DataSet ds = new DataSet();
    public DataSet dss = new DataSet();
    public DataSet ds_first = new DataSet();
    public DataSet dtuser = new DataSet();
    public DataSet dsEsan = new DataSet();
    public DataSet dsMainGrp = new DataSet();
    public DataSet dsMailSet = new DataSet();
    public DataSet ED = new DataSet();

    //-----------------------------------------------------------------------------------
    public DataRow dr;
    //-----------------------------------------------------------------------------------
    public static List<Maildb> lstMails = new List<Maildb>();
    //-----------------------------------------------------------------------------------
    private int i, j, ii, k, page, pageno, start, first, last, m, n, fir, la, kk, mmm, z, a, b, c, res
          ,result, Update_Id,Cmailid = 0;

    private string str, title, state, magimage, pagestr, startpage, comments, mm, lastpost, selqry, search_datewise, search_From_mailid, Attach_Folder
          ,txtSearch_Date="", txt_Folder, txt_port, txt_Customhouse_Id, ext,Size
          ,New_Jobtype="", BRANCHCODE_prn, JOB_TYPE = "", folder = ""  ,folderName2 = "" ,CompanyID = "",readfile = ""
          ,USER_CREATION_ID = "", CUSTOMHOUSE_CODE = "", IMAP_SERVER = "", USER_NAME = "", readmethod = "", Mailtrackfor = ""
          ,txtLicense = "" , branch = "",wk = "",SELECT_TYPE = "",SELECT_BRANCH = "",COMPANY_ID = "",COMPANY_LIC_ID = "", servername = "";


    private string RoyalMailFolder = "D:/ERoyalImpex_Final_New_New/Submission/";
    private string RoyalErrorLog = "D:/ERoyalImpex_Final_New_New/";
   

    public int[] f = new int[100];
    public int[] l = new int[100];
    public char ch = Convert.ToChar(29);
   // private Dictionary<string, object> GetFirstObject(object obj);
    //-----------------------------------------------------------------------------------

    public void Check_Mail_Search(string newDate, string trackfor)
    {
        string SELECT_TYPE, SELECT_BRANCH;

        if (newDate == "home" || newDate == "")
        {
            newDate = String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        txtSearch_Date = newDate;
        Mailtrackfor = trackfor;

        try
        {
            
        int[] f = new int[100];
        int[] l = new int[100];
        
        List<Maildb> lstMails = new List<Maildb>();
        
        SELECT_BRANCH = Connection.Current_Branch();
        SELECT_TYPE = Connection.Get_Company_Type();
        
        COMPANY_ID = Connection.COMPANYID();
        COMPANY_LIC_ID = Connection.Company_License();

        //------------------------------Dir - I---------------------------------------------------
        if (SELECT_TYPE == "Branchwise Job")
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + COMPANY_ID + "/" + SELECT_TYPE + "/" + "Attachments/");
        }
        else if (SELECT_TYPE == "Areawise Job")
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + COMPANY_ID + "/" + HttpContext.Current.Session["GroupName"].ToString() + "/" + "Attachments/");
        }
        else
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + COMPANY_ID + "/" + "Attachments/");
        }

        if (Directory.Exists(Attach_Folder) == false)
        {
            Directory.CreateDirectory(Attach_Folder);
        }
        //---------------------------Dir - I------------------------------------------------------

        //------------------------------Dir - II---------------------------------------------------
        Attach_Folder = RoyalMailFolder + COMPANY_ID + "/TempCommonAttachments/";

        if (Directory.Exists(Attach_Folder) == false)
        {
            Directory.CreateDirectory(Attach_Folder);
        }
        else
        {
            foreach (FileInfo fileInformation in new DirectoryInfo(Attach_Folder).GetFiles())  // delete all the files inside  TempCommonAttachments
            {
                File.Delete(fileInformation.FullName);
            }
        }
        //------------------------------Dir - II---------------------------------------------------
        //------------------------------------------------------
        ds.Clear();
        ds.Tables.Clear();
        dsEsan.Clear();
        dsEsan.Tables.Clear();
        //-------------MessageDetails--------------------//
        ds.Tables.Add("MessageDetails"); ds.Tables[0].Columns.Add("MessageId"); ds.Tables[0].Columns.Add("MailSubject"); ds.Tables[0].Columns.Add("Body");
        ds.Tables[0].Columns.Add("MailFrom"); ds.Tables[0].Columns.Add("MailDate"); ds.Tables[0].Columns.Add("IsAttachments"); ds.Tables[0].Columns.Add("JOB_NO");
        ds.Tables[0].Columns.Add("JOB_DATE"); ds.Tables[0].Columns.Add("BE_NO"); ds.Tables[0].Columns.Add("BE_DATE"); ds.Tables[0].Columns.Add("SB_NO");
        ds.Tables[0].Columns.Add("SB_DATE"); ds.Tables[0].Columns.Add("IMP_TOTAL_DUTY_VALUE"); ds.Tables[0].Columns.Add("IMP_TOTAL_ASSBL_VALUE"); ds.Tables[0].Columns.Add("Emailid");
        ds.Tables[0].Columns.Add("COMPANY_ID"); ds.Tables[0].Columns.Add("CUSTOM_HOUSE_ID"); ds.Tables[0].Columns.Add("BRANCHCODE"); ds.Tables[0].Columns.Add("TRANSPORT_MODE");
        ds.Tables[0].Columns.Add("TR6_CHALLAN_NO"); ds.Tables[0].Columns.Add("EDD"); ds.Tables[0].Columns.Add("JobTyp"); ds.Tables[0].Columns.Add("PathExt");
        ds.Tables[0].Columns.Add("Grp_ID"); ds.Tables[0].Columns.Add("Grp_Name"); ds.Tables[0].Columns.Add("Client_Name"); ds.Tables[0].Columns.Add("JOBNO_PS");
        ds.Tables[0].Columns.Add("Remarks");

        //-------------Esanchit colunms--------------------//
        dsEsan.Tables.Add("MessageDetails");
        dsEsan.Tables[0].Columns.Add("MessageId"); dsEsan.Tables[0].Columns.Add("CUSTOM_HOUSE_ID"); dsEsan.Tables[0].Columns.Add("MailDate");
        dsEsan.Tables[0].Columns.Add("Emailid"); dsEsan.Tables[0].Columns.Add("MailFrom"); dsEsan.Tables[0].Columns.Add("MailSubject");
        dsEsan.Tables[0].Columns.Add("Body"); dsEsan.Tables[0].Columns.Add("Icegate_ID"); dsEsan.Tables[0].Columns.Add("IRN_NO");
        dsEsan.Tables[0].Columns.Add("DRN_NO"); dsEsan.Tables[0].Columns.Add("Doc_Name"); dsEsan.Tables[0].Columns.Add("Doc_Type");
        dsEsan.Tables[0].Columns.Add("FileDate"); dsEsan.Tables[0].Columns.Add("Imp_Exp"); dsEsan.Tables[0].Columns.Add("Exe_Web");
        dsEsan.Tables[0].Columns.Add("BranchCode"); dsEsan.Tables[0].Columns.Add("GroupID"); dsEsan.Tables[0].Columns.Add("UserName");
        //-------------Esanchit colunms--------------------//

        dss = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];

        DataSet db = new DataSet();
        API_Data_CS API = new API_Data_CS();
        db = API.API_Get_Login_Details(COMPANY_LIC_ID, Connection.WorkingPeriod(), "Server_details", "", "");
        servername = db.Tables[0].Rows[0][0].ToString();
        //---------------------------------------------------------------------------------

        mdb.CUSTOM_HOUSE = HttpContext.Current.Session["CUSTOMHOUSE_CODE"].ToString();
        mdb.IMAP_SERVER = "";
        mdb.USER_NAME = "";
        mdb.PWD = "";
        mdb.FOLDER = "";
        mdb.PORT = "";
        mdb.SERVERTYPE = "IMAP";
        mdb.Ename = "Search_Distinct";
        dsMailSet = mdb.MailSettting_INSERT_UPDATE_SEARCH_New_Read(servername);

       
        if (dsMailSet.Tables[0].Rows.Count > 0)
        {
            string host = dsMailSet.Tables[0].Rows[0]["host_name"]
                .ToString()
                .ToLower();

            if (dsMailSet.Tables[0].Rows[0]["TENANT_ID"].ToString() != "")
            {
                InvokeO365MailProcess(dsMailSet);
            }
            else if (host.StartsWith("imap."))
            {
                InvokeIMAPMailProcess(dsMailSet);
            }
            else if (host.StartsWith("pop.") || host.StartsWith("pop3.") || host.StartsWith("mail.") || host.StartsWith("us2.") || host.StartsWith("zopop."))
            {
                InvokePOP3MailProcess(dsMailSet);
            }
            else
            {
                throw new Exception("Unsupported or unknown mail host");
            }
           
        }
         
    //---------------------------------/////
        
       }
        catch (Exception ex)
        {
          Error_msg("_Mailtrack_IMAP_ErrorLog_", ex.Message);
        }
    }
    public class MailResponse
    {
        public string UniqueId { get; set; }
        public string FromeMail { get; set; }
        public string ToeMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTimeOffset ReceivedDateTime { get; set; }
        public List<MailAttachment> Attachments { get; set; } //= new List<MailAttachment>();
    }

    public class MailAttachment
    {
        public string FileName { get; set; }
        public string ContentBase64 { get; set; }
    }
    public void InvokeO365MailProcess(DataSet dsss)
    {
        for (int ms = 0; ms <= dsss.Tables[0].Rows.Count - 1; ms++)  // pop.aaaonlinux.net
        {
            string username = dsss.Tables[0].Rows[ms]["USER_NAME"].ToString();
            string tenantId = dsss.Tables[0].Rows[ms]["TENANT_ID"].ToString();
            string clientId = dsss.Tables[0].Rows[ms]["CLIENT_ID"].ToString();
            string clientSecret = dsss.Tables[0].Rows[ms]["CLIENT_SEC_ID"].ToString();
            string txt_Company_Id = dsss.Tables[0].Rows[ms]["COMPANY_ID"].ToString();
        try
        {
            string inputStart = txtSearch_Date;//.Text.Trim();

            // 1. Parse dd/MM/yyyy
            DateTime selectedDate = DateTime.ParseExact(
                inputStart,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture);

            // 2. Mark it as UTC (no timezone shift)
            DateTime selectedUtc = DateTime.SpecifyKind(selectedDate, DateTimeKind.Utc);

            // 3. Convert to ISO format "o"
            string isoStartDate = selectedUtc.ToString("o");

            // 4. Today date as end date (UTC)
            string isoEndDate = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Utc).ToString("o");

            List<MailResponse> mails = CallMailReadApi(tenantId, clientId, clientSecret, username, isoStartDate, isoEndDate);

            processmail(null, null, mails, "O365", username, txt_Company_Id);
        }
        catch (Exception ex)
        {
            Error_msg("_Mailtrack_IMAP_ErrorLog_", ex.Message);
        }
    }
    }
    private static Aspose.Email.Attachment ConvertToAsposeAttachment(MailAttachment att)
    {

        if (att == null) return null;

        byte[] bytes = Convert.FromBase64String(att.ContentBase64 ?? string.Empty);

        MemoryStream ms = new MemoryStream(bytes); // keep stream open

        return new Aspose.Email.Attachment(ms, att.FileName ?? "attachment");

    }
    public static List<MailResponse> CallMailReadApi(string tenantId, string clientId, string clientSecret, string emailId, string isoStartDate,string isoEndDate, int intmaxItems = 0)
    {
        // IMPORTANT: .NET 4.0 must force TLS 1.2 for HTTPS
        var url = ConfigurationManager.AppSettings["MailReadApiUrl"];
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS1.2
        //var url = "http://103.185.75.96:8081/api/Mail/read";
        var requestObj = new
        {
            tenantId,
            clientId,
            clientSecret,
            emailId,
            startDate = isoStartDate,  
            endDate = isoEndDate, 
            // Optional
            maxItems = ((int?)intmaxItems ?? 0)
        };

        var serializer = new JavaScriptSerializer();
        string jsonBody = serializer.Serialize(requestObj);

        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(jsonBody);
            streamWriter.Flush();
        }

        try
        {
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var rsp = reader.ReadToEnd();
                //MailResponse mail = JsonConvert.DeserializeObject<MailResponse>(rsp);
                List<MailResponse> lstMail = JsonConvert.DeserializeObject<List<MailResponse>>(rsp);
                return lstMail;  // JSON response from API
            }
        }
        catch (WebException ex)
        {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
            {
                string error = reader.ReadToEnd();
                throw new Exception("API Error: " + error);
            }
        }
    }
    private Dictionary<string, object> GetFirstObject(object obj)
    {
        if (obj == null)
            return null;

        if (obj is Dictionary<string, object>)
        {
            Dictionary<string, object> dict = (Dictionary<string, object>)obj;

            foreach (object value in dict.Values)
            {
                Dictionary<string, object> result = GetFirstObject(value);

                if (result != null)
                    return result;
            }

            return dict;
        }

        if (obj is ArrayList)
        {
            ArrayList arr = (ArrayList)obj;

            foreach (object item in arr)
            {
                Dictionary<string, object> result = GetFirstObject(item);

                if (result != null)
                    return result;
            }
        }

        return null;
    }
    public void InvokePOP3MailProcess(DataSet dsss)
    {
        for (int ms = 0; ms <= dsss.Tables[0].Rows.Count - 1; ms++)  // pop.aaaonlinux.net
        {
            string pop3Server = dsss.Tables[0].Rows[ms]["HOST_NAME"].ToString();
            string username = dsss.Tables[0].Rows[ms]["USER_NAME"].ToString();
            string password = dsss.Tables[0].Rows[ms]["PWD"].ToString();
            string txt_Company_Id = dsss.Tables[0].Rows[ms]["COMPANY_ID"].ToString();
            try
            {
                using (client_POP = new Pop3Client(pop3Server, username, password))
                {
                    client_POP.Timeout = -1;
                    client_POP.SecurityOptions = SecurityOptions.Auto;
                    client_POP.Port = 995;

                    DateTime dtStartDate = Convert.ToDateTime(DateTime.Parse(txtSearch_Date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
                    DateTime dtEndDate = DateTime.Today;
                    
                    MailQueryBuilder builder = new MailQueryBuilder();

                    if (Mailtrackfor == "Esanchit")
                    {
                        builder.From.Contains("esanchit@icegate.gov.in");
                    }
                    else
                    {
                        builder.From.Contains("@icegate.gov.in");
                        builder.From.NotContains("esanchit@icegate.gov.in");
                    }

                    builder.InternalDate.On(dtStartDate);
                    MailQuery query = builder.GetQuery();
                    
                    Pop3MessageInfoCollection messagesPOP = client_POP.ListMessages(query);
                    ImapMessageInfoCollection messagesIMAPDummy = new ImapMessageInfoCollection();

                    processmail(messagesPOP, messagesIMAPDummy,null, "POP3", username, txt_Company_Id);
                }
            }
            catch (Exception ex)
            {
                Error_msg("_MailtrackPop3ErrorLog_", ex.Message);
            }

        }
    }
    public void InvokeIMAPMailProcess(DataSet dsss)
    {
        for (int ms = 0; ms <= dsss.Tables[0].Rows.Count - 1; ms++)
        {
            lock (syncLock)  // Lock to ensure thread-safe access to shared resources
            {
                string username = dsss.Tables[0].Rows[ms]["USER_NAME"].ToString();
                string password = dsss.Tables[0].Rows[ms]["PWD"].ToString();
                string pop3Server = dsss.Tables[0].Rows[ms]["HOST_NAME"].ToString();
                string txt_Company_Id = dsss.Tables[0].Rows[ms]["COMPANY_ID"].ToString();
                int pop3Port = 993;

                try
                {
                    using (ImapClient client = new ImapClient())
                    {
                        client_IMAP.SecurityOptions = SecurityOptions.Auto;
                        client_IMAP.Host = pop3Server;
                        client_IMAP.Port = pop3Port;
                        client_IMAP.Username = username;
                        client_IMAP.Password = password;
                        client_IMAP.SelectFolder("Inbox");

                        DateTime dtStartDate = Convert.ToDateTime(DateTime.Parse(txtSearch_Date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
                        DateTime dtEndDate = DateTime.Today;

                        ImapQueryBuilder builder = new ImapQueryBuilder();

                        if (Mailtrackfor == "Esanchit")
                        {
                            builder.From.Contains("esanchit@icegate.gov.in");    
                            
                        }
                        else
                        {
                            builder.From.Contains("@icegate.gov.in");
                            builder.From.NotContains("esanchit@icegate.gov.in");
                        }

                        builder.Or(builder.InternalDate.On(dtStartDate), builder.InternalDate.On(dtEndDate));

                        MailQuery query = builder.GetQuery();
                        ImapMessageInfoCollection messagesIMAP = client_IMAP.ListMessages(query);

                        Pop3MessageInfoCollection messagesPOP_Dummy = new Pop3MessageInfoCollection();
                        processmail(messagesPOP_Dummy, messagesIMAP,null, "IMAP", username, txt_Company_Id);
                        //string Msg = "Tracked Successfully";
                    }
                }
                catch (Exception ex)
                {
                    Error_msg("_Mailtrack_IMAP_ErrorLog_", ex.Message);
                }
            }
        }
    }
    public void processmail(Pop3MessageInfoCollection messagesPOP, ImapMessageInfoCollection messagesIMAP,List<MailResponse> office365Message, string pop_imap, string Emailid, string txt_Company_Id)
    {
      
        try
        {
            string rem = "";
            Mail_Db.Ename = "Errorcode";
            ED = Mail_Db.Retrieve_Error_Code_details();
            DataView vw_ED = ED.Tables[0].DefaultView; 

        DateTime dtStartDate = DateTime.Today.AddDays(-1);
        DateTime dtEndDate = DateTime.Today;
        DataSet grpDS = new DataSet();
        string remarks = "", pdf_dt = "", LastProcessedTime = "";

        string baseDirectory = HttpContext.Current.Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/" + "ProcessedUIDs/");


        if (Directory.Exists(baseDirectory) == false)
        {
            Directory.CreateDirectory(baseDirectory);
        }
        string uidFileName = DateTime.Now.ToString("yyyyMMdd") + "-IMAP-Processed-UIDs.txt";
        string uidFilePath = Path.Combine(baseDirectory, uidFileName);

        List<string> processedUids = File.Exists(uidFilePath) ? File.ReadAllLines(uidFilePath).ToList() : new List<string>();
        dynamic filteredMessages = null;

        if (pop_imap == "POP3")
        {
            filteredMessages = messagesPOP.Where(messageInfo =>
                  !processedUids.Contains(messageInfo.UniqueId));
        }
        else if (pop_imap == "IMAP")
        {
            filteredMessages = messagesIMAP.Where(messageInfo =>
                  !processedUids.Contains(messageInfo.UniqueId));
        }
        else if (pop_imap == "O365")
        {
            filteredMessages = office365Message.Where(messageInfo =>
                  !processedUids.Contains(messageInfo.UniqueId));
        }

        foreach (var messageInfo in filteredMessages)
        {
            dynamic message = null;
            DateTime istDateTime;
            TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            //DateTime istDateTime = TimeZoneInfo.ConvertTimeFromUtc(messageInfo.Date, istTimeZone);
            /* 
            if (pop_imap == "POP3")
                {
                    message = client_POP.FetchMessage(messageInfo.UniqueId);
                }
                else
                {
                    message = client_IMAP.FetchMessage(messageInfo.UniqueId);
                }
             */
            if (pop_imap == "O365")
            {
                istDateTime = TimeZoneInfo.ConvertTimeFromUtc(messageInfo.ReceivedDateTime.UtcDateTime, istTimeZone);
            }
            else
            {
                istDateTime = TimeZoneInfo.ConvertTimeFromUtc(messageInfo.Date, istTimeZone);
            }
            //if (istDateTime.Date == dtEndDate.Date)
            //{

            if (pop_imap == "POP3")
            {
                message = client_POP.FetchMessage(messageInfo.UniqueId);

            }
            else if (pop_imap == "IMAP")
            {
                message = client_IMAP.FetchMessage(messageInfo.UniqueId);
            }
            else if (pop_imap == "O365")
            {
                var o365Msg = office365Message.FirstOrDefault(j => j.UniqueId == messageInfo.UniqueId);
                // Convert the O365 message (with custom attachments) into an Aspose-style object
                message = new Aspose.Email.MailMessage();
                message.From = o365Msg.FromeMail;
                message.Subject = o365Msg.Subject;
                message.Body = o365Msg.Body;

                // Convert all your custom MailAttachment into Aspose attachments
                foreach (var myAtt in o365Msg.Attachments)
                {
                    var aspAtt = ConvertToAsposeAttachment(myAtt);
                    message.Attachments.Add(aspAtt);
                }
            }
                foreach (var attachment in message.Attachments)
                {
                    if (attachment != null && !string.IsNullOrEmpty(attachment.Name))
                    {
                        string fname = attachment.Name;
                        folder = "";
                        folder = Attach_Folder + fname;
                        
                        if (File.Exists(folder))
                        {
                            File.Delete(folder);
                            attachment.Save(folder);
                        }
                        else
                        {
                            attachment.Save(folder);
                        }
                        i = i + 1;
                        dr = ds.Tables[0].NewRow();

                        dr["MessageId"] = i;
                        dr["MailSubject"] = message.Subject.ToString();
                        dr["Body"] = "";
                        dr["MailFrom"] = message.From.ToString();
                        dr["MailDate"] = istDateTime.ToString(@"MM/dd/yyyy hh:mm:ss tt");
                        dr["COMPANY_ID"] = Connection.COMPANYID();
                        ext = Path.GetExtension(fname).ToLower();

                        if (Mailtrackfor == "Imp_Exp_Mail" && (ext == ".ack" || ext == ".ack_" || ext == ".nak" || ext == ".qry" || ext == ".out" || ext == ".pdf" || ext == ".prn" || ext == ".prn_" || ext == ".json")) // || ext == ".txt" || ext == ".txt_"))  // import - export
                        {
                            dr["MailSubject"] = fname;
                            dr["Emailid"] = Emailid;

                            if (ext == ".prn" || ext == ".prn_")
                            {
                                JOB_TYPE = "Import";
                            }
                            else
                            {
                                string attName = attachment.Name.ToUpper();

                                if (attName.Contains("CHCAE") || attName.Contains("CACHE"))
                                {
                                    JOB_TYPE = "Export";
                                }
                                else if (attName.Contains("CHCAI") || attName.Contains("CACHI"))
                                {
                                    JOB_TYPE = "Import";
                                }
                            }

                            #region PDF

                            if (ext == ".pdf")
                            {
                                remarks = "";
                                dr["Grp_ID"] = "1"; dr["Grp_Name"] = "";
                                dr["Body"] = "";
                                dr["MailFrom"] = message.From.ToString();
                                dr["IsAttachments"] = "";
                                dr["JOB_NO"] = "";
                                dr["JOB_DATE"] = "";
                                pdf_dt = "";
                                if (message.Subject.ToLower().Replace(" ", "").Contains("firstcopy"))
                                {
                                    remarks = "First Copy";
                                }
                                else if (message.Subject.ToLower().Replace(" ", "").Contains("finalooccopy"))
                                {
                                    remarks = "OOC Copy";
                                }
                                else if (message.Subject.ToLower().Replace(" ", "").Contains("egatepasscopy"))
                                {
                                    remarks = "Gatepass Copy";
                                }
                                else if (message.Subject.ToLower().Replace(" ", "").Contains("finalleocopy"))
                                {
                                    remarks = "LEO Copy";
                                }
                                if (attachment.Name.ToUpper().Substring(21, 2) == "BE")
                                {
                                    dr["BE_NO"] = attachment.Name.ToUpper().Substring(0, 7);
                                    pdf_dt = attachment.Name.ToUpper().Substring(7, 8);
                                    dr["BE_DATE"] = pdf_dt.Substring(2, 2) + "/" + pdf_dt.Substring(0, 2) + "/" + pdf_dt.Substring(4, 4);
                                    dr["JobTyp"] = "Import";
                                }

                                else if (attachment.Name.ToUpper().Substring(21, 2) == "SB")
                                {
                                    dr["SB_NO"] = attachment.Name.ToUpper().Substring(0, 7);
                                    pdf_dt = attachment.Name.ToUpper().Substring(7, 8);
                                    dr["SB_DATE"] = pdf_dt.Substring(2, 2) + "/" + pdf_dt.Substring(0, 2) + "/" + pdf_dt.Substring(4, 4);
                                    dr["JobTyp"] = "Export";
                                }

                                dr["IMP_TOTAL_DUTY_VALUE"] = "";
                                dr["IMP_TOTAL_ASSBL_VALUE"] = "";
                                
                                dr["COMPANY_ID"] = Connection.COMPANYID();
                                dr["CUSTOM_HOUSE_ID"] = attachment.Name.ToUpper().Substring(15, 6);

                                grpDS = mdb.GetGroup(attachment.Name.ToUpper().Substring(15, 6), "", "Select_Group_BasedCustom", "", "");
                                if (grpDS.Tables.Count > 0)
                                {
                                    if (grpDS.Tables[0].Rows.Count > 0)
                                    {
                                        dr["Grp_ID"] = grpDS.Tables[0].Rows[0]["Group_ID"].ToString();
                                        dr["Grp_Name"] = grpDS.Tables[0].Rows[0]["Group_Name"].ToString();
                                        dr["BRANCHCODE"] = grpDS.Tables[0].Rows[0]["Branchcode"].ToString();
                                    }
                                }

                                dr["TRANSPORT_MODE"] = "";
                                dr["TR6_CHALLAN_NO"] = "";
                                dr["EDD"] = "";
                                dr["PathExt"] = ".pdf";
                                dr["Client_Name"] = ""; dr["JOBNO_PS"] = ""; dr["Remarks"] = remarks;

                                ds.Tables[0].Rows.Add(dr);

                            }

                            # endregion  PDF
                            //----------------------------------------------------------------------READ IMPORT TRANSACTION JOB--------------------------------------------------------------------//


                            #region Import


                            if (attachment.Name.Contains("CHCAI") || attachment.Name.Contains("CACHI") || message.From.ToString().ToLower().Contains("gxs.imp@icegate.gov.in") || ext == ".prn" || ext == ".prn_")                
                            { 
                                int num;
                                StreamReader reader = new StreamReader(folder);
                                string[] lines = File.ReadAllLines(folder);
                                string[] s1 = null;


                                if (ext == ".ack" || ext == ".ack_" || ext == ".nak" || ext == ".qry" || ext == ".out" || ext == ".txt" || ext == ".txt_")
                                {
                                    
                                   if (lines == null || lines.Length == 0 || lines.All(string.IsNullOrWhiteSpace))
                                    {
                                        dr["JOB_NO"] = ""; dr["JOB_DATE"] = ""; dr["BE_NO"] = ""; dr["BE_DATE"] = ""; dr["SB_NO"] = ""; dr["SB_DATE"] = "";
                                        dr["JobTyp"] = ""; dr["PathExt"] = ""; dr["Grp_ID"] = ""; dr["Grp_Name"] = ""; dr["Client_Name"] = ""; dr["JOBNO_PS"] = ""; dr["Remarks"] = "";
                                    }
                                   else if (!string.IsNullOrWhiteSpace(lines[0]) && lines[0].Length >= 4 && lines[0].Substring(0, 4) == "HREC")  
                                    {
                                        if (ext == ".ack" || ext == ".ack_" || ext == ".txt" || ext == ".txt_")
                                        {

                                            if (lines[1].ToString().Split(' ').Length == 2)
                                            {
                                                if (lines[1].ToString().ToUpper().Replace(" ", "").Contains("MAIN"))
                                                {
                                                    dr["Remarks"] = "GROUP";
                                                }

                                            }

                                            else if (lines[1].ToString().ToUpper().Replace(" ", "").Contains("MAIN"))
                                            {
                                                dr["Remarks"] = "RMS";
                                            }

                                            else if (ext == ".txt" || ext == ".txt_")
                                            {
                                                if (fname.Contains(".ack"))
                                                {
                                                    dr["Remarks"] = "Ammendment Success";
                                                }
                                                else
                                                {
                                                    dr["Remarks"] = "Ammendment Failed";
                                                }
                                            }

                                            else
                                            {

                                                dr["Remarks"] = "";
                                            }
                                        }

                                        else if (ext == ".nak")
                                        {
                                            s1 = lines[1].Split(new string[] { ch.ToString() }, StringSplitOptions.None);
                                            for (int ln = 18; ln < 22; ln++)
                                            {
                                                if (s1[ln].ToString() != "")
                                                {
                                                     string[] errCodes = s1[ln].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                                    foreach (string code in errCodes)
                                                    {
                                                        string trimmedCode = code.Trim();
                                                        if (trimmedCode.ToString() !="null")
                                                        {
                                                            vw_ED.RowFilter = "ERR_CD = '" + trimmedCode + "'";
                                                        }
                                                        if (vw_ED.Count > 0)
                                                        {
                                                            rem += "," + vw_ED[0][0] + "-" + vw_ED[0][1];
                                                        }
                                                        else
                                                        {
                                                            rem += "," + trimmedCode + "-NOT FOUND";
                                                        }
                                                    }
                                                }
                                            }
                                            dr["Remarks"] = rem.ToString().Trim(',');
                                        }

                                        else if (ext == ".qry" || ext == ".out")
                                        {
                                            dr["Remarks"] = "Query";
                                        }

                                        s1 = lines[1].Split(new string[] { ch.ToString() }, StringSplitOptions.None);
                                        readfile = s1[0].ToString();

                                        if (lines.Length > 0)
                                        {
                                            dr["JobTyp"] = JOB_TYPE;
                                            dr["PathExt"] = ext.ToString();

                                            s1 = lines[1].Split(new string[] { ch.ToString() }, StringSplitOptions.None);
                                            readfile = s1[0].ToString();

                                            for (int j = 0; j < s1.Length; j++)
                                            {
                                                if (readfile == "F" || readfile == "A")
                                                {
                                                    if (j == 1)
                                                    {
                                                        if (j == 1)
                                                        {
                                                            string BRANCHCODE = s1[1].ToString();

                                                            var query1 = from t in dss.Tables[3].AsEnumerable()
                                                                         where t.Field<string>("CUSTOMHOUSE_CODE").Equals(BRANCHCODE)
                                                                         select t;

                                                            DataTable dddd = query1.CopyToDataTable();

                                                            dr["BRANCHCODE"] = dddd.Rows[0]["CUSTOMHOUSE_NAME"].ToString();
                                                            dr["TRANSPORT_MODE"] = dddd.Rows[0]["TransMode"].ToString();
                                                            dr["CUSTOM_HOUSE_ID"] = BRANCHCODE;

                                                            grpDS = mdb.GetGroup(BRANCHCODE, "", "Select_Group_BasedCustom", "", "");
                                                            if (grpDS.Tables.Count > 0)
                                                            {
                                                                if (grpDS.Tables[0].Rows.Count > 0)
                                                                {
                                                                    dr["Grp_ID"] = grpDS.Tables[0].Rows[0]["Group_ID"].ToString();
                                                                    dr["Grp_Name"] = grpDS.Tables[0].Rows[0]["Group_Name"].ToString();
                                                                }
                                                            }

                                                        }

                                                    }
                                                    if (ext == ".out")  // added on 30/5/2020 since the out file - position is change
                                                    {
                                                        dr["JOB_NO"] = "";
                                                        dr["JOB_DATE"] = "";
                                                        if (s1[2].ToString() != "")
                                                        {
                                                            dr["BE_NO"] = s1[2].ToString().Trim();
                                                        }
                                                        else
                                                        {
                                                            dr["BE_NO"] = "";
                                                        }

                                                        if (s1[3].ToString() != "")
                                                        {
                                                            dr["BE_DATE"] = s1[3].ToString().Trim();
                                                            dr["BE_DATE"] = conv_date_ddmmyyyy(s1[3].ToString().Trim());
                                                        }
                                                        else
                                                        {
                                                            dr["BE_DATE"] = "";
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (j == 2)
                                                        {

                                                            dr["JOB_NO"] = s1[2].ToString().Trim();
                                                        }
                                                        if (j == 3)
                                                        {
                                                            if (s1[3].ToString() != "")
                                                            {

                                                                dr["JOB_DATE"] = conv_date_ddmmyyyy(s1[3].ToString().Trim());
                                                            }
                                                            else
                                                            {
                                                                dr["JOB_DATE"] = "";
                                                            }
                                                        }

                                                        if (j == 4)
                                                        {

                                                            if (ext != ".nak")
                                                            {
                                                                bool isNum = Int32.TryParse(s1[4].ToString(), out num);

                                                                if (isNum)
                                                                {
                                                                    //Is a Number
                                                                    dr["BE_NO"] = s1[4].ToString().Trim();
                                                                }
                                                                else
                                                                {
                                                                    //Not a number
                                                                    dr["BE_NO"] = "";
                                                                }
                                                            }
                                                        }
                                                        if (j == 5)
                                                        {
                                                            if (ext != ".nak")
                                                            {
                                                                if (s1[5].ToString() != "")
                                                                {

                                                                    dr["BE_DATE"] = conv_date_ddmmyyyy(s1[5].ToString().Trim());
                                                                }
                                                                else
                                                                {
                                                                    dr["BE_DATE"] = "";
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        ds.Tables[0].Rows.Add(dr);
                                    } // END OF THE EMPTY ATTACHMENT CONDITION 
                                }
                                    /*
                                else if (ext == ".json")
                                {
                                    string json = File.ReadAllText(folder);

                                    JavaScriptSerializer js = new JavaScriptSerializer();
                                    var data = js.Deserialize<Dictionary<string, object>>(json);

                                    object masterObj = data["master"];
                                    Dictionary<string, object> item = null;

                                    if (masterObj is ArrayList)
                                    {
                                        // ✅ IMPORT JSON
                                        var masterList = (ArrayList)masterObj;
                                        item = (Dictionary<string, object>)masterList[0];
                                    }
                                    else if (masterObj is Dictionary<string, object>)
                                    {
                                        // ✅ EXPORT JSON
                                        var masterDict = (Dictionary<string, object>)masterObj;

                                        if (masterDict.ContainsKey("main"))
                                        {
                                            var mainList = (ArrayList)masterDict["main"];
                                            item = (Dictionary<string, object>)mainList[0];
                                        }
                                    }

                                    dr["Emailid"] = Emailid;
                                    dr["JobTyp"] = JOB_TYPE;
                                    dr["PathExt"] = ext.ToString();

                                    dr["JOB_NO"] = item.ContainsKey("jobNumber") ? item["jobNumber"].ToString() : "";

                                    if (item.ContainsKey("jobDate") && item["jobDate"] != null)
                                        dr["JOB_DATE"] = conv_date_ddmmyyyy(item["jobDate"].ToString());
                                    else
                                        dr["JOB_DATE"] = "";

                                    if (item.ContainsKey("beNumber") && Int32.TryParse(item["beNumber"].ToString(), out num))
                                        dr["BE_NO"] = item["beNumber"].ToString();
                                    else
                                        dr["BE_NO"] = "";

                                    // BE DATE
                                    if (item.ContainsKey("beDate") && item["beDate"] != null)
                                        dr["BE_DATE"] = conv_date_ddmmyyyy(item["beDate"].ToString());
                                    else
                                        dr["BE_DATE"] = "";

                                    // BRANCHCODE
                                    string BRANCHCODE = item.ContainsKey("customHouseCode") ? item["customHouseCode"].ToString() : "";

                                    var query1 = from t in dss.Tables[3].AsEnumerable()
                                                 where t.Field<string>("CUSTOMHOUSE_CODE").Equals(BRANCHCODE)
                                                 select t;

                                    if (query1.Any())
                                    {
                                        DataTable dddd = query1.CopyToDataTable();

                                        dr["BRANCHCODE"] = dddd.Rows[0]["CUSTOMHOUSE_NAME"].ToString();
                                        dr["TRANSPORT_MODE"] = dddd.Rows[0]["TransMode"].ToString();
                                        dr["CUSTOM_HOUSE_ID"] = BRANCHCODE;
                                        grpDS = mdb.GetGroup(BRANCHCODE, "", "Select_Group_BasedCustom", "", "");
                                        if (grpDS.Tables.Count > 0)
                                        {
                                            if (grpDS.Tables[0].Rows.Count > 0)
                                            {
                                                dr["Grp_ID"] = grpDS.Tables[0].Rows[0]["Group_ID"].ToString();
                                                dr["Grp_Name"] = grpDS.Tables[0].Rows[0]["Group_Name"].ToString();
                                            }
                                        }
                                    }

                                    // ✅ Remarks from JSON
                                    if (item.ContainsKey("tableName") && item["tableName"] != null)
                                        dr["Remarks"] = item["tableName"].ToString();
                                    else if (fname.ToLower().Contains("nak") && ext == ".json")
                                    {
                                        dr["Remarks"] = "Error File";

                                    }
                                    else
                                        dr["Remarks"] = "";

                                    ds.Tables[0].Rows.Add(dr);
                                }
                                */
                                else if (ext == ".json")
                                {
                                        string json = File.ReadAllText(folder);

                                        JavaScriptSerializer js = new JavaScriptSerializer();
                                        var data = js.Deserialize<Dictionary<string, object>>(json);

                                        Dictionary<string, object> item = null;

                                        if (data.ContainsKey("master"))
                                        {
                                            item = GetFirstObject(data["master"]);
                                        }

                                        dr["Emailid"] = Emailid;
                                        dr["JobTyp"] = JOB_TYPE;
                                        dr["PathExt"] = ext;

                                        dr["JOB_NO"] = "";
                                        dr["JOB_DATE"] = "";
                                        dr["BE_NO"] = "";
                                        dr["BE_DATE"] = "";
                                        dr["Remarks"] = "";

                                        if (item != null)
                                        {
                                            if (item.ContainsKey("jobNumber") && item["jobNumber"] != null)
                                                dr["JOB_NO"] = item["jobNumber"].ToString();

                                            if (item.ContainsKey("jobDate") &&
                                                item["jobDate"] != null &&
                                                item["jobDate"].ToString() != "")
                                            {
                                                dr["JOB_DATE"] = conv_date_ddmmyyyy(item["jobDate"].ToString());
                                            }

                                            if (item.ContainsKey("beNumber") &&
                                                item["beNumber"] != null &&
                                                Int32.TryParse(item["beNumber"].ToString(), out num))
                                            {
                                                dr["BE_NO"] = item["beNumber"].ToString();
                                            }

                                            if (item.ContainsKey("beDate") &&
                                                item["beDate"] != null &&
                                                item["beDate"].ToString() != "")
                                            {
                                                dr["BE_DATE"] = conv_date_ddmmyyyy(item["beDate"].ToString());
                                            }

                                            // Branch Code
                                            string BRANCHCODE = item.ContainsKey("customHouseCode")
                                                                ? Convert.ToString(item["customHouseCode"])
                                                                : "";

                                            if (!string.IsNullOrEmpty(BRANCHCODE))
                                            {
                                                var query1 = from t in dss.Tables[3].AsEnumerable()
                                                             where t.Field<string>("CUSTOMHOUSE_CODE") == BRANCHCODE
                                                             select t;

                                                if (query1.Any())
                                                {
                                                    DataTable dddd = query1.CopyToDataTable();

                                                    dr["BRANCHCODE"] = dddd.Rows[0]["CUSTOMHOUSE_NAME"].ToString();
                                                    dr["TRANSPORT_MODE"] = dddd.Rows[0]["TransMode"].ToString();
                                                    dr["CUSTOM_HOUSE_ID"] = BRANCHCODE;

                                                    grpDS = mdb.GetGroup(BRANCHCODE, "", "Select_Group_BasedCustom", "", "");

                                                    if (grpDS.Tables.Count > 0 &&
                                                        grpDS.Tables[0].Rows.Count > 0)
                                                    {
                                                        dr["Grp_ID"] = grpDS.Tables[0].Rows[0]["Group_ID"].ToString();
                                                        dr["Grp_Name"] = grpDS.Tables[0].Rows[0]["Group_Name"].ToString();
                                                    }
                                                }
                                            }

                                            // ACK
                                            if (item.ContainsKey("tableName"))
                                            {
                                                dr["Remarks"] = Convert.ToString(item["tableName"]);
                                            }
                                            // NAK
                                            else if (item.ContainsKey("ErrorCode"))
                                            {
                                                string errorCode = Convert.ToString(item["ErrorCode"]);

                                                string errorMsg = item.ContainsKey("ErrorMessage")
                                                                  ? Convert.ToString(item["ErrorMessage"])
                                                                  : "";

                                                dr["Remarks"] = "Error Code : " +
                                                                errorCode +
                                                                (errorMsg != "" ? " - " + errorMsg : "");
                                            }
                                        }
                                        else
                                        {
                                            dr["Remarks"] = "Master node data not found";
                                        }

                                        ds.Tables[0].Rows.Add(dr);
                                    
                                }
                                if (ext == ".prn" || ext == ".prn_")
                                {
                                    IEnumerable<string> Billof = File.ReadLines(folder).Where(l => l.Contains("BILL OF ENTRY"));
                                    if (Billof.ToList().Count > 0)
                                    {
                                        dr["Remarks"] = Billof.ToList()[0].Trim();
                                    }

                                    IEnumerable<string> resultbranch = File.ReadLines(folder).Where(l => l.Contains("[Custom Stn:"));
                                    if (resultbranch.ToList().Count > 0)
                                    {
                                        var _values_br = resultbranch.AsEnumerable().Select(x => x);
                                        string valueString_br = _values_br.ToList().Aggregate((c, d) => c + d);
                                        string[] s2_br1 = new string[] { };
                                        string[] s2_br = new string[] { };

                                        if (!string.IsNullOrEmpty(valueString_br))
                                        {
                                            s2_br1 = valueString_br.Split(new string[] { "]________" }, StringSplitOptions.None);
                                            s2_br = s2_br1[0].Split(new string[] { "[Custom Stn:" }, StringSplitOptions.None);
                                        }

                                        if (s2_br.Length > 0)
                                        {
                                            grpDS = mdb.GetGroup(s2_br[1].ToString().Trim(), "", "Select_Group_BasedCustom", "", "");
                                            if (grpDS.Tables.Count > 0)
                                            {
                                                if (grpDS.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["Grp_ID"] = grpDS.Tables[0].Rows[0]["Group_ID"].ToString();
                                                    dr["Grp_Name"] = grpDS.Tables[0].Rows[0]["Group_Name"].ToString();
                                                }
                                            }

                                            Read_Prn_File_LCD(JOB_TYPE, s2_br[1].ToString().Trim());
                                        }
                                    }
                                }

                                reader.Close(); reader.Dispose();
                            }
                            #endregion Import

                            //----------------------------------------------------------------------READ EXPORT TRANSACTION JOB--------------------------------------------------------------------//
                            #region Export
                            else if (attachment.Name.Contains("CHCAE") || attachment.Name.Contains("CACHE"))
                            {
                                if (ext == ".ack" || ext == ".ack_" || ext == ".nak" || ext == ".qry" || ext == ".out" || ext == ".txt" || ext == ".txt_")
                                {
                                    int num;
                                    StreamReader reader = new StreamReader(folder);
                                    string[] lines = File.ReadAllLines(folder);
                                    
                                    if (lines == null || lines.Length == 0 || lines.All(string.IsNullOrWhiteSpace))
                                    {
                                        dr["JOB_NO"] = ""; dr["JOB_DATE"] = ""; dr["BE_NO"] = ""; dr["BE_DATE"] = ""; dr["SB_NO"] = ""; dr["SB_DATE"] = "";
                                        dr["JobTyp"] = ""; dr["PathExt"] = ""; dr["Grp_ID"] = ""; dr["Grp_Name"] = ""; dr["Client_Name"] = ""; dr["JOBNO_PS"] = ""; dr["Remarks"] = "";
                                    }
                                  
                                   else if (!string.IsNullOrWhiteSpace(lines[0]) && lines[0].Length >= 4 && lines[0].Substring(0, 4) == "HREC")  
                                    {
                                    if (ext == ".ack" || ext == ".ack_")
                                    {
                                        dr["Remarks"] = "SHIPPING BILL";

                                    }
                                    else if (ext == ".txt" || ext == ".txt_")
                                    {
                                        if (fname.Contains(".ack"))
                                        {
                                            dr["Remarks"] = "Ammendment Success";
                                        }
                                        else
                                        {
                                            dr["Remarks"] = "Ammendment Failed";
                                        }
                                    }
                                    else if (ext == ".nak")
                                    {
                                        dr["Remarks"] = "Error File";
                                    }
                                    else if (ext == ".qry" || ext == ".out")
                                    {
                                        dr["Remarks"] = "Query";
                                    }
                                    dr["JobTyp"] = JOB_TYPE;
                                    dr["PathExt"] = ext.ToString();
                                    string[] s1 = null;
                                    if (lines.Length > 0)
                                    {
                                        s1 = lines[1].Split(new string[] { ch.ToString() }, StringSplitOptions.None);
                                        readfile = s1[0].ToString();

                                        for (int j = 0; j < s1.Length; j++)
                                        {
                                            if (j == 0)
                                            {
                                                if (ext != ".prn")
                                                {
                                                    string BRANCHCODE = s1[0].ToString();

                                                    var query2 = from t in dss.Tables[3].AsEnumerable()
                                                                 where t.Field<string>("CUSTOMHOUSE_CODE").Equals(BRANCHCODE)
                                                                 select t;

                                                    DataTable dddd = query2.CopyToDataTable();

                                                    dr["BRANCHCODE"] = dddd.Rows[0]["CUSTOMHOUSE_NAME"].ToString();

                                                    dr["TRANSPORT_MODE"] = dddd.Rows[0]["TransMode"].ToString();
                                                    dr["CUSTOM_HOUSE_ID"] = BRANCHCODE;
                                                   
                                                    grpDS = mdb.GetGroup(BRANCHCODE, "", "Select_Group_BasedCustom", "", "");
                                                    if (grpDS.Tables.Count > 0)
                                                    {
                                                        if (grpDS.Tables[0].Rows.Count > 0)
                                                        {
                                                            dr["Grp_ID"] = grpDS.Tables[0].Rows[0]["Group_ID"].ToString();
                                                            dr["Grp_Name"] = grpDS.Tables[0].Rows[0]["Group_Name"].ToString();
                                                        }
                                                    }
                                                }
                                            }

                                            if (j == 1)
                                            {
                                                dr["JOB_NO"] = s1[1].ToString();
                                            }
                                            if (j == 2)
                                            {
                                                dr["JOB_DATE"] = s1[2].ToString();
                                                dr["JOB_DATE"] = conv_date_ddmmyyyy(s1[2].ToString().Trim());
                                            }

                                            if (j == 3)
                                            {
                                                bool isNum = Int32.TryParse(s1[3].ToString(), out num);

                                                if (isNum)
                                                {
                                                    //Is a Number
                                                    dr["SB_NO"] = s1[3].ToString();
                                                }
                                                else
                                                {
                                                    //Not a number
                                                    dr["SB_NO"] = "";
                                                }
                                            }
                                            if (j == 4)
                                            {
                                                dr["SB_DATE"] = s1[4].ToString();
                                                dr["SB_DATE"] = conv_date_yyyymmdd(s1[4].ToString().Trim());
                                            }
                                            else
                                            {

                                            }
                                        }
                                        ds.Tables[0].Rows.Add(dr);
                                    }
                                    reader.Close();
                                    reader.Dispose();
                                  } // END OF THE EMPTY ATTACHMENT CONDITION
                                }
                                else if (ext == ".json")
                                {
                                    string json = File.ReadAllText(folder);

                                    JavaScriptSerializer js = new JavaScriptSerializer();
                                    var data = js.Deserialize<Dictionary<string, object>>(json);

                                    object masterObj = data["master"];
                                    Dictionary<string, object> item = null;

                                    if (masterObj is Dictionary<string, object>)
                                    {
                                        var masterDict = (Dictionary<string, object>)masterObj;

                                        // ✅ Check if there's a nested "master" list inside
                                        if (masterDict.ContainsKey("master") && masterDict["master"] is ArrayList)
                                        {
                                            // OLD structure: master > master[0]
                                            var mainList = (ArrayList)masterDict["master"];
                                            if (mainList.Count > 0)
                                                item = (Dictionary<string, object>)mainList[0];
                                        }
                                        else
                                        {
                                            // ✅ NEW structure: master is a direct object (your current JSON)
                                            item = masterDict;
                                        }
                                    }
                                    else if (masterObj is ArrayList)
                                    {
                                        // Fallback: master is directly an array
                                        var mainList = (ArrayList)masterObj;
                                        if (mainList.Count > 0)
                                            item = (Dictionary<string, object>)mainList[0];
                                    }

                                    if (item == null)
                                    {
                                        // Skip if item could not be resolved
                                        continue; // or return/break depending on your loop context
                                    }

                                    // ✅ Assign values
                                    dr["JOB_NO"] = item.ContainsKey("jobNumber") ? item["jobNumber"].ToString() : "";

                                    if (item.ContainsKey("jobDate") && item["jobDate"] != null)
                                        dr["JOB_DATE"] = conv_date_ddmmyyyy(item["jobDate"].ToString());
                                    else
                                        dr["JOB_DATE"] = "";

                                    dr["SB_NO"] = item.ContainsKey("sbNumber") ? item["sbNumber"].ToString() : "";

                                    if (item.ContainsKey("sbDate") && item["sbDate"] != null)
                                        dr["SB_DATE"] = conv_date_yyyymmdd(item["sbDate"].ToString());
                                    else
                                        dr["SB_DATE"] = "";

                                    // ✅ Read error field (new field in your JSON)
                                    //string errorMsg = item.ContainsKey("error") ? item["error"].ToString() : "";

                                    string BRANCHCODE = item.ContainsKey("customHouseCode") ? item["customHouseCode"].ToString() : "";

                                    var query = from t in dss.Tables[3].AsEnumerable()
                                                where t.Field<string>("CUSTOMHOUSE_CODE").Equals(BRANCHCODE)
                                                select t;

                                    if (query.Any())
                                    {
                                        DataTable dddd = query.CopyToDataTable();

                                        dr["BRANCHCODE"] = dddd.Rows[0]["CUSTOMHOUSE_NAME"].ToString();
                                        dr["TRANSPORT_MODE"] = dddd.Rows[0]["TransMode"].ToString();
                                        dr["CUSTOM_HOUSE_ID"] = BRANCHCODE;
                                        grpDS = mdb.GetGroup(BRANCHCODE, "", "Select_Group_BasedCustom", "", "");
                                        if (grpDS.Tables.Count > 0 && grpDS.Tables[0].Rows.Count > 0)
                                        {
                                            dr["Grp_ID"] = grpDS.Tables[0].Rows[0]["Group_ID"].ToString();
                                            dr["Grp_Name"] = grpDS.Tables[0].Rows[0]["Group_Name"].ToString();
                                        }
                                    }

                                    // ✅ Remarks logic with error message support
                                    // ✅ Read error field from master object
                                    string errorMsg = item.ContainsKey("error") && item["error"] != null
                                        ? item["error"].ToString()
                                        : "";

                                    // ✅ Use ToLower() or OrdinalIgnoreCase to handle both NAK and nak
                                    if (fname.ToLower().Contains("nak") && ext == ".json")
                                    {
                                        dr["Remarks"] = !string.IsNullOrEmpty(errorMsg)
                                            ? errorMsg
                                            : "Error File";
                                    }
                                    else if (fname.ToLower().Contains("ack") && ext == ".json")
                                    {
                                        dr["Remarks"] = "SHIPPING BILL";
                                    }

                                    // Common fields
                                    dr["JobTyp"] = JOB_TYPE;
                                    dr["PathExt"] = ext.ToString();
                                    dr["Emailid"] = Emailid;

                                    ds.Tables[0].Rows.Add(dr);
                                }
                                else
                                {
                                    dr["JOB_NO"] = ""; dr["JOB_DATE"] = ""; dr["BE_NO"] = ""; dr["BE_DATE"] = ""; dr["SB_NO"] = ""; dr["SB_DATE"] = "";
                                    dr["JobTyp"] = ""; dr["PathExt"] = ""; dr["Grp_ID"] = ""; dr["Grp_Name"] = ""; dr["Client_Name"] = ""; dr["JOBNO_PS"] = ""; dr["Remarks"] = "";
                                }
                            }
                            #endregion Export

                        }

                        #region ESanchit

                        else if (Mailtrackfor == "Esanchit" && (ext == ".dms" || ext == ".dms_"))
                        {
                            if (message.Subject.ToString().ToLower().Replace(" ", "").Contains("documentuploadconfirmation"))
                            {
                                string IcegateID = "", DRN_NO = "", docname = "", doctype = "", IRN_NO = "", Rem_str;

                                dr = dsEsan.Tables[0].NewRow();
                                string[] sp_icegtid = null;

                                StreamReader reader = new StreamReader(folder);
                                string[] lines = File.ReadAllLines(folder);
                                if (lines.Length > 0)
                                {
                                    sp_icegtid = lines[0].Split('');
                                    IcegateID = sp_icegtid[4].Trim();
                                    DRN_NO = lines[0].Substring(lines[0].ToString().ToUpper().IndexOf("UPLOAD_RESP") + 12, 17);
                                    DRN_NO = DRN_NO.Trim();
                                    for (int k = 1; k <= lines.Length - 2; k++)
                                    {
                                        Cmailid = Cmailid + 1;
                                        dr = dsEsan.Tables[0].NewRow();
                                        dr["MessageId"] = Cmailid;
                                        dr["CUSTOM_HOUSE_ID"] = txt_Customhouse_Id;
                                        dr["MailDate"] = istDateTime.ToString(@"MM/dd/yyyy hh:mm:ss tt");
                                        dr["Emailid"] = Emailid;
                                        dr["MailFrom"] = "esanchit@icegate.gov.in";
                                        dr["MailSubject"] = attachment.Name;
                                        dr["Body"] = "";
                                        dr["Icegate_ID"] = IcegateID;
                                        dr["GroupID"] = "";
                                        docname = lines[k].Substring(1, lines[k].ToString().ToLower().IndexOf(".pdf")) + "pdf";
                                        IRN_NO = lines[k].Substring(lines[k].IndexOf(docname) + docname.Length, 17);
                                        Rem_str = lines[k].Substring(("F" + docname + IRN_NO + DRN_NO).Length, lines[k].Length - (("F" + docname + IRN_NO + DRN_NO).Length)).ToUpper();
                                        if (Rem_str.ToUpper().Contains("AM"))
                                        {
                                            doctype = Rem_str.Substring(Rem_str.IndexOf("AM") + 2, Rem_str.Length - (Rem_str.IndexOf("AM") + 2)).Trim();
                                            doctype = doctype.Substring(7, doctype.Length - 7) + " _ " + doctype.Substring(0, 7);
                                        }
                                        else if (Rem_str.ToUpper().Contains("PM"))
                                        {
                                            doctype = Rem_str.Substring(Rem_str.IndexOf("PM") + 2, Rem_str.Length - (Rem_str.IndexOf("PM") + 2)).Trim();
                                            doctype = doctype.Substring(7, doctype.Length - 7) + " _ " + doctype.Substring(0, 7);
                                        }
                                        else
                                        {
                                            doctype = "";
                                        }

                                        dr["IRN_NO"] = IRN_NO.Trim();
                                        dr["DRN_NO"] = DRN_NO;
                                        dr["Doc_Name"] = docname.Trim();
                                        dr["Doc_Type"] = doctype.Trim();
                                        dr["FileDate"] = istDateTime.ToString(@"MM/dd/yyyy hh:mm:ss tt");
                                        if (docname.ToString().ToLower().Contains("imp_"))
                                        {
                                            dr["Imp_Exp"] = "Import";
                                        }
                                        else if (docname.ToString().ToLower().Contains("exp_"))
                                        {
                                            dr["Imp_Exp"] = "Export";
                                        }
                                        else 
                                        {
                                            dr["Imp_Exp"] = JOB_TYPE;
                                        }
                                        //dr["Imp_Exp"] = JOB_TYPE;
                                        dr["Exe_Web"] = "Web";
                                        dr["BranchCode"] = SELECT_BRANCH;
                                        dr["UserName"] = "Auto_Esanchit_Track";
                                        dsEsan.Tables[0].Rows.Add(dr);
                                            }
                                        }
                                    }
                                }

                                #endregion Esanchit
                             }
                            processedUids.Add(messageInfo.UniqueId);
                        }
                    //}
                    LastProcessedTime = istDateTime.ToString(@"MM/dd/yyyy hh:mm:ss tt").ToString();

                    File.WriteAllLines(uidFilePath, processedUids);
                    }

                    //#endregion whileLoop_start;

                    /////****** Import/Export insert start *******************//
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            
                            DataSet ddt = Check_JOBNO_UnKnown(ds);
                            mdb.Path_ext = "WEB";
                            mdb.StoreMailContents(ddt, Emailid, "STORE MAIL CONTENTS", "", SELECT_BRANCH, servername);

                            if (mdb.LastErrorMessage == "Mismatched Data Received")
                            {
                                string mailtiming1 = RoyalErrorLog + "Email_Error_logs/";
                                string logline11, logFileName11;
                                logFileName11 = txt_Company_Id + "_MismatchedData_Log_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                                StreamWriter sw11 = new StreamWriter(mailtiming1 + logFileName11, true);
                                logline11 = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + LastProcessedTime;
                                sw11.WriteLine(logline11);
                                sw11.Close();
                                sw11.Dispose();
                            }
                           }
                        }
                    /////****** Import/Export insert end *******************//

                    /////****** Esanchit insert start *******************//
                       if (dsEsan.Tables.Count > 0)
                        {
                          if (dsEsan.Tables[0].Rows.Count > 0)
                          {
                             Esanchit_Movefiles(ds);
                             mdb.Esanchit_StoreMailContents(dsEsan, Emailid, "STORE MAIL CONTENTS", "", SELECT_BRANCH, servername);
                             
                           }
                        }


                        string mailtiming = RoyalErrorLog + "logs/";
                        string logline1, logFileName1;
                        logFileName1 = txt_Company_Id + "_MailtimingLog_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                        StreamWriter sw1 = new StreamWriter(mailtiming + logFileName1, true);
                        logline1 = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + LastProcessedTime;
                        sw1.WriteLine(logline1);
                        sw1.Close();
                        sw1.Dispose();

        }

        catch (Exception ex)
        {
            Error_msg("_Mailtrack_ProcessMail_ErrorLog_", ex.Message);
        }

    }
    public void Esanchit_Movefiles(DataSet ds_gen_jobs)
    {
        // --- start to upload file into folder ------//
        string C_Id = Connection.COMPANYID();
        string destFolder = "";

        Attach_Folder = RoyalMailFolder + C_Id + "/Attachments";
        if (Directory.Exists(Attach_Folder) == false)
        {
            Directory.CreateDirectory(Attach_Folder);
        }
        for (int i = 0; i <= dsEsan.Tables[0].Rows.Count - 1; i++)
        {
            Attach_Folder = RoyalMailFolder + C_Id + "/TempCommonAttachments/" + dsEsan.Tables[0].Rows[i]["MailSubject"].ToString();
            if (File.Exists(Attach_Folder))
            {
                try
                {
                    destFolder = RoyalMailFolder + C_Id + "/" + "Attachments/" + dsEsan.Tables[0].Rows[i]["MailSubject"].ToString();
                    if (File.Exists(destFolder))
                    {

                        try
                        {
                            File.Delete(destFolder);
                        }
                        catch
                        {
                        }
                    }
                    File.Move(Attach_Folder, destFolder);
                }
                catch
                {
                    continue;
                }

            }

        }
        // --- end to upload file into folder ------// 


    }
    public DataSet Check_JOBNO_UnKnown(DataSet ds_gen_jobs)
    {
        try
        {
            DataSet ds_final = new DataSet();
            ds_gen_jobs = mdb.StoreMailContents(ds_final, "", "Get_Unknown_JOBS_AreawiseExe", "", "", servername);

            DataView vw_prn = ds.Tables[0].DefaultView;
            vw_prn.RowFilter = "PathExt <> '.pdf'";
            DataSet ds_prn = new DataSet();
            ds_prn.Tables.Add(vw_prn.ToTable());

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                string ext = ds.Tables[0].Rows[i]["PathExt"].ToString();

                if (ext != ".pdf")
                {
                    string Jobno = ds.Tables[0].Rows[i][6].ToString();
                    string Branch = ds.Tables[0].Rows[i][17].ToString();
                    string jobty = ds.Tables[0].Rows[i]["JobTyp"].ToString();
                    string GPID = ds.Tables[0].Rows[i]["Grp_ID"].ToString();

                    if (Jobno != "UNKNOWN")
                    {
                        if (Jobno != "")
                        {
                            DataRow[] dr = ds_gen_jobs.Tables[0].Select("JOBNO = '" + Jobno + "' AND Jobtype = '" + jobty + "' AND GROUP_ID = '" + GPID + "' "); // on 10-apr-2020
                            if (dr.Length <= 0)
                            {
                                ds.Tables[0].AsEnumerable().Where(row => row.Field<string>("JOB_NO") == Jobno && row.Field<string>("Grp_ID") == GPID && row.Field<string>("JobTyp") == jobty)
                                          .Select(b => b["JOB_NO"] = "UNKNOWN").ToList();
                            }
                        }
                        else
                        {
                            string Id = ds.Tables[0].Rows[i][0].ToString();
                            ds.Tables[0].AsEnumerable().Where(row => row.Field<string>("MessageId") == Id && row.Field<string>("Grp_ID") == GPID && row.Field<string>("JobTyp") == jobty)
                                            .Select(b => b["JOB_NO"] = "UNKNOWN").ToList();
                        }
                    }
                } // <> PDF
            }
           
            string be_sb_typ = "";

            int mailcount = ds_gen_jobs.Tables[1].Rows.Count;
            string fil = "";
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {

                fil = ds.Tables[0].Rows[i]["MailSubject"].ToString().Substring(0, 7);
                if (ds.Tables[0].Rows[i]["JobTyp"].ToString() == "Import")
                {
                    be_sb_typ = "BE_NO";
                }
                else
                {
                    be_sb_typ = "SB_NO";
                }

                if (ds.Tables[0].Rows[i]["PathExt"].ToString() == ".pdf")
                {
                    DataRow[] dr1 = ds_prn.Tables[0].Select("" + be_sb_typ + " = '" + fil + "'   ");
                    if (dr1.Length > 0)
                    {
                        ds.Tables[0].Rows[i]["JOB_NO"] = dr1[0].ItemArray[6].ToString().Trim();
                        ds.Tables[0].Rows[i]["JOB_DATE"] = dr1[0].ItemArray[7].ToString().Trim();
                        ds.Tables[0].Rows[i]["BE_NO"] = dr1[0].ItemArray[8].ToString().Trim();
                        ds.Tables[0].Rows[i]["BE_DATE"] = dr1[0].ItemArray[9].ToString().Trim();
                        ds.Tables[0].Rows[i]["IMP_TOTAL_DUTY_VALUE"] = dr1[0].ItemArray[12].ToString().Trim();
                        ds.Tables[0].Rows[i]["IMP_TOTAL_ASSBL_VALUE"] = dr1[0].ItemArray[13].ToString().Trim();
                        ds.Tables[0].Rows[i]["CUSTOM_HOUSE_ID"] = dr1[0].ItemArray[16].ToString().Trim();
                        ds.Tables[0].Rows[i]["BRANCHCODE"] = dr1[0].ItemArray[17].ToString().Trim();
                        ds.Tables[0].Rows[i]["TRANSPORT_MODE"] = dr1[0].ItemArray[18].ToString().Trim();
                        ds.Tables[0].Rows[i]["TR6_CHALLAN_NO"] = dr1[0].ItemArray[19].ToString().Trim();
                        ds.Tables[0].Rows[i]["EDD"] = dr1[0].ItemArray[20].ToString().Trim();
                        ds.Tables[0].Rows[i]["Grp_ID"] = dr1[0].ItemArray[23].ToString().Trim();
                        ds.Tables[0].Rows[i]["Grp_Name"] = dr1[0].ItemArray[24].ToString().Trim();

                    }
                    else
                    {
                        if (mailcount > 0)
                        {
                            dr1 = ds_gen_jobs.Tables[1].Select("" + be_sb_typ + " = '" + fil + "'   "); // on 2-May-2020
                            if (dr1.Length > 0)
                            {
                                ds.Tables[0].Rows[i]["JOB_NO"] = dr1[0].ItemArray[0].ToString().Trim();
                                ds.Tables[0].Rows[i]["JOB_DATE"] = dr1[0].ItemArray[1].ToString().Trim();
                                ds.Tables[0].Rows[i]["BE_NO"] = dr1[0].ItemArray[2].ToString().Trim();
                                ds.Tables[0].Rows[i]["BE_DATE"] = dr1[0].ItemArray[3].ToString().Trim();
                                ds.Tables[0].Rows[i]["IMP_TOTAL_DUTY_VALUE"] = dr1[0].ItemArray[4].ToString().Trim();
                                ds.Tables[0].Rows[i]["IMP_TOTAL_ASSBL_VALUE"] = dr1[0].ItemArray[5].ToString().Trim();
                                ds.Tables[0].Rows[i]["CUSTOM_HOUSE_ID"] = dr1[0].ItemArray[6].ToString().Trim();
                                ds.Tables[0].Rows[i]["BRANCHCODE"] = dr1[0].ItemArray[7].ToString().Trim();
                                ds.Tables[0].Rows[i]["TRANSPORT_MODE"] = dr1[0].ItemArray[8].ToString().Trim();
                                ds.Tables[0].Rows[i]["TR6_CHALLAN_NO"] = dr1[0].ItemArray[9].ToString().Trim();
                                ds.Tables[0].Rows[i]["EDD"] = dr1[0].ItemArray[10].ToString().Trim();
                                ds.Tables[0].Rows[i]["Grp_ID"] = dr1[0].ItemArray[11].ToString().Trim();
                                ds.Tables[0].Rows[i]["Grp_Name"] = dr1[0].ItemArray[12].ToString().Trim();

                            }
                        }
                    }
                }



            }
            ds.Tables[0].AcceptChanges();

            // started added on 29-nov-21 by jayanthi to include job type & client name, jobps no //
            string GID = "", JBNO = "", JTY = "";

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                GID = ds.Tables[0].Rows[i]["Grp_ID"].ToString();
                JBNO = ds.Tables[0].Rows[i]["JOB_NO"].ToString();
                JTY = ds.Tables[0].Rows[i]["JobTyp"].ToString();
                DataRow[] drJob = ds_gen_jobs.Tables[0].Select("GROUP_ID = '" + GID + "'  AND JOBNO = '" + JBNO + "' AND Jobtype= '" + JTY + "' ");
                if (drJob.Length > 0)
                {
                    ds.Tables[0].Rows[i]["Client_Name"] = drJob[0].ItemArray[4].ToString().Trim();
                    ds.Tables[0].Rows[i]["JOBNO_PS"] = drJob[0].ItemArray[5].ToString().Trim();
                }
            }
            ds.Tables[0].AcceptChanges();
            // ended added on 29-nov-21 by jayanthi to include job type & client name, jobps no //

            // --- start to uploa PDF file into folder ------//

            string destFolder = "";
            string sourcefolder = "";

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {

                sourcefolder = Attach_Folder + ds.Tables[0].Rows[i]["MailSubject"];
                if (File.Exists(sourcefolder))
                {

                    if (Directory.Exists(RoyalMailFolder + COMPANY_ID + "/" + ds.Tables[0].Rows[i]["Grp_Name"] + "/Attachments/") == false)
                    {
                        Directory.CreateDirectory(RoyalMailFolder + COMPANY_ID + "/" + ds.Tables[0].Rows[i]["Grp_Name"] + "/Attachments/");
                    }

                    destFolder = RoyalMailFolder + COMPANY_ID + "/" + ds.Tables[0].Rows[i]["Grp_Name"] + "/Attachments/" + ds.Tables[0].Rows[i]["MailSubject"];
                    if (File.Exists(destFolder))
                    {
                        File.Delete(destFolder);
                    }
                    File.Copy(sourcefolder, destFolder);
                }
            }
            return ds;
        }
        catch (Exception ex)
        {
            string errorFolder = RoyalErrorLog + "logs/";
            string logline, logFileName;
            logFileName = Connection.COMPANYID() + "_Mailtrack_IMAP_ErrorLog_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            using (StreamWriter sw = new StreamWriter(errorFolder + logFileName, true))
            {
                logline = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + ex.Message;
                sw.WriteLine(logline);
                throw new Exception(ex.Message);
            }
        }
    }
    public void Read_Prn_File_LCD(string JT, string Ext)
    {
        try
        {
        string BENO_NEW;
        //--------------------------------------------BRANCH CODE-------------------------------//
        string BRANCHCODE = Ext;//INMAA1
        var query1 = from t in dss.Tables[3].AsEnumerable()
                     where t.Field<string>("CUSTOMHOUSE_CODE").Equals(BRANCHCODE)
                     select t;

        DataTable ddd = query1.CopyToDataTable();

        BRANCHCODE_prn = ddd.Rows[0]["CUSTOMHOUSE_NAME"].ToString();
        SELECT_BRANCH = BRANCHCODE_prn;
        dr["BRANCHCODE"] = ddd.Rows[0]["CUSTOMHOUSE_NAME"].ToString();
        string T_Mode = ddd.Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString();

        dr["TRANSPORT_MODE"] = ddd.Rows[0]["TransMode"].ToString();
        dr["CUSTOM_HOUSE_ID"] = BRANCHCODE;

        //------------------------------------------- TR6 CHALLAN -------------------------------//

        IEnumerable<string> result22 = File.ReadLines(folder).Where(l => l.Contains("TR6  CHALLAN No.")).ToList();
        var _values22 = result22.AsEnumerable().Select(x => x);
        //var zz = _values22.ToList().Count();

        if (_values22.ToList().Count > 0)
        {
            string valueString22 = _values22.ToList().Aggregate((a, b) => a + b);
            string[] s22 = new string[] { };
            string[] s222 = new string[] { };

            if (!string.IsNullOrEmpty(valueString22))
            {
                s22 = valueString22.Split(new string[] { "TR6  CHALLAN No. " }, StringSplitOptions.None);
                s222 = s22[1].Split(new string[] { " " }, StringSplitOptions.None);
            }

            if (s222.Length > 0)
            {
                dr["TR6_CHALLAN_NO"] = s222[0].ToString().Trim();
            }
        }


        IEnumerable<string> resultEDD = File.ReadLines(folder).Where(l => l.Contains("XBE Duty FG Int.:")).ToList();
        var _valuesEDD = resultEDD.AsEnumerable().Select(x => x);

        if (_valuesEDD.ToList().Count > 0)
        {
            string valueString_EDD = _valuesEDD.ToList().Aggregate((a, b) => a + b);
            string[] s_EDD = new string[] { };
            string[] s1_EDD = new string[] { };
            string[] s_EDD_XBE = new string[] { };
            string[] s1_EDD_XBE = new string[] { };

            if (!string.IsNullOrEmpty(valueString_EDD))
            {
                s_EDD_XBE = valueString_EDD.Split(new string[] { "XBE Duty FG Int.:" }, StringSplitOptions.None);
                s_EDD = valueString_EDD.Split(new string[] { "EDD          :" }, StringSplitOptions.None);
                s1_EDD = s_EDD[1].Split(new string[] { ":" }, StringSplitOptions.None);

                s1_EDD_XBE = s_EDD[1].Split(new string[] { "XBE Duty FG Int.:" }, StringSplitOptions.None);

            }

            if (s1_EDD_XBE.Length > 0)
            {
                dr["EDD"] = s1_EDD_XBE[0].ToString().Trim();
            }
        }
        else
        {
            IEnumerable<string> resultEDD1 = File.ReadLines(folder).Where(l => l.Contains("EDD          :")).ToList(); ;
            var _valuesEDD1 = resultEDD.AsEnumerable().Select(x => x);

            if (_valuesEDD.ToList().Count > 0)
            {
                string valueString_EDD = _valuesEDD1.ToList().Aggregate((a, b) => a + b);
                string[] s_EDD = new string[] { };
                string[] s1_EDD = new string[] { };
                if (!string.IsNullOrEmpty(valueString_EDD))
                {
                    s_EDD = valueString_EDD.Split(new string[] { "EDD          :" }, StringSplitOptions.None);
                    s1_EDD = s_EDD[1].Split(new string[] { ":" }, StringSplitOptions.None);
                }

                if (s1_EDD.Length > 0)
                {

                    dr["EDD"] = s1_EDD[0].ToString().Trim();
                }
            }
        }
        //--------------------------------------------ASSESABLE PAYABLE-------------------------------//

        IEnumerable<string> result1 = File.ReadLines(folder).Where(l => l.Contains("BE Gross Total"));
        var _values = result1.AsEnumerable().Select(x => x);
        string valueString = _values.ToList().Aggregate((a, b) => a + b);
        string[] s2 = new string[] { };
        if (!string.IsNullOrEmpty(valueString))
        {
            s2 = valueString.Split(new string[] { "BE Gross Total" }, StringSplitOptions.None);
        }

        if (s2.Length > 0)
        {

            dr["IMP_TOTAL_ASSBL_VALUE"] = s2[0].ToString().Replace("Rs.", "").Trim();
        }

        //--------------------------------------------DUTY PAYABLE-------------------------------//
        IEnumerable<string> result2 = File.ReadLines(folder).Where(l => l.Contains("Duty Payable:"));
        var _values1 = result2.AsEnumerable().Select(x => x);
        string valueString1 = _values1.ToList().Aggregate((a, b) => a + b);
        string[] s3 = new string[] { };
        if (!string.IsNullOrEmpty(valueString1))
        {
            s3 = valueString1.Split(new string[] { "Duty Payable:" }, StringSplitOptions.None);
        }

        if (s3.Length > 0)
        {

            dr["IMP_TOTAL_DUTY_VALUE"] = s3[1].ToString().Replace("Rs.", "").Trim();
        }
        //--------------------------------------------BE NO DATE-------------------------------//

        IEnumerable<string> result_BE = File.ReadLines(folder).Where(l => l.Contains("BE No/Dt./cc/Typ:"));
        var values1 = result_BE.AsEnumerable().Select(x => x);
        string valueString_BE = values1.ToList().Aggregate((a, b) => a + b);
        string[] BE2 = new string[] { };
        if (!string.IsNullOrEmpty(valueString_BE))
        {
            BE2 = valueString_BE.Split(new string[] { "BE No/Dt./cc/Typ:" }, StringSplitOptions.None);
            BE2 = BE2[1].Split(new string[] { "/" }, StringSplitOptions.None);
        }

        if (BE2.Length > 0)
        {

            dr["BE_NO"] = BE2[0].ToString().Trim();
            BENO_NEW = BE2[0].ToString().Trim();

            dr["BE_DATE"] = BE2[2].ToString().Trim() + "/" + BE2[1].ToString().Trim() + "/" + BE2[3].ToString().Trim();// +"/" + BE2[1].ToString().Trim();
        }

        //--------------------------------------------JOB NO DATE-------------------------------//
        IEnumerable<string> result_JOB = File.ReadLines(folder).Where(l => l.Contains("H/BL No") || l.Contains("HAWB No"));

        var values2 = result_JOB.AsEnumerable().Select(x => x);

        string valueString_JOB = values2.ToList().Aggregate((a, b) => a + b);
        string[] BE3 = new string[] { };
        string[] BE4 = new string[] { };
        string[] BE5 = new string[] { };

        if (!string.IsNullOrEmpty(valueString_JOB))
        {
            if (valueString_JOB.Contains("H/BL No"))
            {
                BE3 = valueString_JOB.Split(new string[] { "H/BL No" }, StringSplitOptions.None);
            }
            else if (valueString_JOB.Contains("HAWB No"))
            {
                BE3 = valueString_JOB.Split(new string[] { "HAWB No" }, StringSplitOptions.None);

            }
            BE4 = BE3[0].Split(new string[] { ":" }, StringSplitOptions.None);
            BE5 = BE3[1].Split(new string[] { ":" }, StringSplitOptions.None);

        }

        DataTable dt_lcd = ds.Tables[0];

        DataTable dt_bind = ds.Tables[0];
        DataView dv_Bind = new DataView(dt_bind);

        DataTable dt_Rsp_New = dv_Bind.ToTable(true, "JOB_NO", "JOB_DATE", "BE_NO", "BE_DATE");

        string Be_nonew = BE2[0].ToString().Trim();

        //***************************************************

        var FullName1 = from DataRow drr in dt_Rsp_New.AsEnumerable()
                        where drr.Field<string>("BE_NO") == Be_nonew
                        select drr;

        string FullName = "";
        string FullDate = "";
        DataView dvv = FullName1.AsDataView();

        if (dvv.Count > 0)
        {
            DataTable Get_JobNo = FullName1.CopyToDataTable();
            FullName = Get_JobNo.Rows[0]["JOB_NO"].ToString();
            FullDate = Get_JobNo.Rows[0]["JOB_DATE"].ToString();

        }
        string prn_JOBNO = FullName;
        string prn_JOBdate = FullDate;
        //***************************************************

        if (BE4.Length > 0)
        {

            dr["JOB_NO"] = prn_JOBNO;
        }
        if (BE5.Length > 0)
        {


            dr["JOB_DATE"] = FullDate;
        }

        if (prn_JOBNO == "" || prn_JOBNO == null)
        {
            string[] MBLNO = (BE4[1].ToString().Trim() + " , " + prn_JOBNO).Split(new string[] { "," }, StringSplitOptions.None);
            string MBLNO1 = MBLNO[0];

            string[] HBL_NO = (BE5[1].ToString().Trim() + " , " + FullDate).Split(new string[] { "," }, StringSplitOptions.None);
            string HBL_NO1 = HBL_NO[0];

            DataSet ds_igm_vals = Get_HBL_No(MBLNO1, HBL_NO1, Be_nonew, dr["BE_DATE"].ToString(), SELECT_BRANCH);

            if (ds_igm_vals.Tables[0].Rows.Count > 0)
            {
                dr["JOB_NO"] = ds_igm_vals.Tables[0].Rows[0]["JOBNO"].ToString();
                string[] JOB_DATE1 = ds_igm_vals.Tables[0].Rows[0]["IGM_JOBDATE"].ToString().Split('/');

                string IGM_JOBDATE = JOB_DATE1[0] + JOB_DATE1[1] + JOB_DATE1[2];


                dr["JOB_DATE"] = conv_date_ddmmyyyy(IGM_JOBDATE);
            }
        }

        dr["JobTyp"] = JT;
        dr["PathExt"] = ".PRN";

        ds.Tables[0].Rows.Add(dr);
      }
        catch (Exception ex)
        {
            Error_msg("_Mailtrack_IMAP_ErrorLog_", ex.Message);
        }
    }
    public DataSet Get_HBL_No(string MBL_NO, string HBL_NO, string BE_NO, string BE_DATE, string SELECT_BRANCH)
    {
        DataSet ds_igm = new DataSet();
        DataSet ds_igm1 = new DataSet();
        mdb.Emailid = MBL_NO.Trim();
        mdb.Path_ext = HBL_NO.Trim();
        ds_igm1 = mdb.StoreMailContents(ds_igm, MBL_NO.Trim(), "Get_IGM_Details", JOB_TYPE, SELECT_BRANCH,servername);
        return ds_igm1;
    }
    public string conv_date_ddmmyyyy(string objMaildb)
    {
        if (objMaildb != "")
        {
            if (objMaildb.Length == 8)
            {
                DateTime theTime = DateTime.ParseExact(objMaildb, "ddMMyyyy", provider);
                objMaildb = String.Format("{0: MM/dd/yyyy}", theTime);// 
            }
        }
        return objMaildb;
    }
    public string conv_date_yyyymmdd(string objMaildb)
    {
        if (objMaildb != "")
        {
            if (objMaildb.Length == 8)
            {
                DateTime theTime = DateTime.ParseExact(objMaildb, "yyyyMMdd", provider);
                objMaildb = String.Format("{0: MM/dd/yyyy}", theTime);// 
            }
        }
        return objMaildb;
    }

    public void Error_msg (string H_Msg ,string Error)
    {
        string errorFolder = RoyalErrorLog + "logs/";
        string logline, logFileName;
        logFileName = Connection.COMPANYID() + H_Msg + DateTime.Now.ToString("yyyyMMdd") + ".log";
        using (StreamWriter sw = new StreamWriter(errorFolder + logFileName, true))
        {
            logline = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + Error;
            sw.WriteLine(logline);
            throw new Exception(Error);
        }
    }


}


 