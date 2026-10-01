using System;
using System.Data;
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


public partial class eRoyalMasters_Adcode_Master : ThemeClass
{
    StringBuilder sb = new StringBuilder();
    StringBuilder sb_File = new StringBuilder();
    StringBuilder sb_RandNo = new StringBuilder();
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    ErrorLogs er = new ErrorLogs();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int a,Update_Id;
    public string AUTO_ID, inbox_id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, TO_ADDRESS, RAND_ID, Attach_Folder,FILE_NAME;

    public int Screen_Id;
    DataSet ds = new DataSet();
    DataTable dtuser = new DataTable();
    Internal_Mail mail = new Internal_Mail();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        aps.checkSession();
      
        
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        Attach_Folder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentuser"].ToString() +"/" + "UploadFiles/");
         
        if (!IsPostBack)
        {
            ddlBind();
            if (Directory.Exists(Attach_Folder) == false)
            {
                Directory.CreateDirectory(Attach_Folder);
            }
            EditDetails();
        }


    }
    public void EditDetails()
    {
        if (Request.QueryString["inbox_id"] != "" && Request.QueryString["inbox_id"] != null && Request.QueryString["ref_id"] != "" && Request.QueryString["ref_id"] != null)
        {

            FileUpload1.Visible = false;
            inbox_id = Request.QueryString["inbox_id"];


            mail.USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();

            mail.INBOX_ID = inbox_id;
            mail.REFERENCE_ID = Request.QueryString["ref_id"];

            mail.flag = "EDIT_SENT";
            mail.WORKING_PERIOD = Working_Period;
            
            mail.READ_STATUS = "";
            mail.DELETE_STATUS = "";
           
           //mail.SENT = "Yes";

            
            //if (Request.QueryString["mail"] != "" && Request.QueryString["mail"] != null)
            if (Session["mail"] != "" && Session["mail"] != null)
            {
                //string val = Request.QueryString["mail"];
                string val = Session["mail"].ToString();
                if (val == "INBOX")
                {
                    mail.USER_CREATION_ID = "";

                    mail.SENT = "";
                    mail.TRASH = "";
                    mail.FOLDER = "";
                    mail.INBOX = "Yes";
                    mail.flag = "EDIT_INBOX";
                }
                else if (val == "SENT")
                {
                    mail.SENT = "Yes";
                    mail.TRASH = "";
                    mail.FOLDER = "";
                    mail.INBOX = "";
                }
                else if (val == "TRASH")
                {
                    mail.SENT = "";
                    mail.TRASH = "Yes";
                    mail.FOLDER = "";
                    mail.INBOX = "";
                }
                else if (val == "FOLDER")
                {
                    mail.SENT = "";
                    mail.TRASH = "";
                    mail.FOLDER = "Yes";
                    mail.INBOX = "";
                }

            }
            dtuser = mail.GetMail();
            if (dtuser.Rows.Count > 0)
            {
                ddlFrom_Address.DataSource = dtuser;
                ddlFrom_Address.DataTextField = "Splitcolumn";
                ddlFrom_Address.DataValueField = "Splitcolumn";
                ddlFrom_Address.DataBind();
                //if (dtuser.Rows.Count > 1)
                //{
                //    ddlFrom_Address.Items.Insert(0, "All");
                //}
                txt_Subject.Text = dtuser.Rows[0]["SUBJECT"].ToString();
                txt_Body.Text = dtuser.Rows[0]["BODY_CONTENT"].ToString();
                string str = dtuser.Rows[0]["FILE_NAME"].ToString();
                StringBuilder sb_link = new StringBuilder();
                sb_link.Clear();
                ltrInfo.Text = "<div> Download ";
                if (str != "")
                {
                    string[] s1 = str.Split(new string[] { "~/" }, StringSplitOptions.None);


                    foreach (string value in s1)
                    {
                        if (value != "")
                        {
                           
                            string[] s2 = value.Split(new string[] { "~~" }, StringSplitOptions.None);
                            String AnchorLink="javascript:Print_open('" + value + "')";
                            AnchorLink = "<" + "a href=" + AnchorLink + "" + ">";
                            //string f="javascript:Print_open(" + value + ""+";
                            //string d = "<li><a href='javascript:Print_open(" + value + ")' >";
                            //string d = "<li><a href='javascript:Print_open(" + value + ")'>";
                            //string d = "<li><a href='javascript//:window.open('../FlatFile/Open_FileDownload.aspx?inbox='" + value + "'', 'ndf')'>";

                            ltrInfo.Text += AnchorLink + s2[1].ToString() + "</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                            //ltrInfo.Text += "<li><a href='javascript://Print_open()'>" + s2[1].ToString() + "</a></li>";
                            //ltrInfo.Text += "<li><a href='')" + "'>" + s2[1].ToString() + "</a></li>";
                           
                        }
                        
                    }
                    ltrInfo.Text += "</div>";
                }
                else
                {
                    ltrInfo.Text = "";
                    sb_link.Clear();
                }
                //txtAdcode.Text = dtuser.Tables[0].Rows[0]["RECEIVED_FROM"].ToString();
                //txtBankName.Text = dtuser.Tables[0].Rows[0]["FILE_NAME"].ToString();
                //txtBankAccountNo.Text = dtuser.Tables[0].Rows[0]["RANDOM_FILE_NO"].ToString();
                //txtAddress1.Text = dtuser.Tables[0].Rows[0]["TO_ADDRESS"].ToString();
               
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["inbox_id"].ToString();
                //FOR UPDATED SUCCESSFULLY


            }
            HiddenField1.Value = Request.QueryString["inbox_id"].ToString();
           
            btnSend.Visible = false;
            ////btn_compose_update.Style.Add("display", "block");
            ////btn_Compose_update_cancel.Style.Add("display", "block");
            //btnCancel.Style.Add("display", "none");
            //btn_Compose_update_cancel.Style.Add("display", "none");
            
            ////not_edit_Inbox.Style.Add("display", "none");
            ////edit_inbox.Style.Add("display", "block");


        }
        else
        {
            //btn_compose_update.Style.Add("display", "none");
            //btn_Compose_update_cancel.Style.Add("display", "none");
            //btnCancel.Style.Add("display", "block");
            //btn_exbond.Style.Add("display", "block");
            btnSend.Visible = true;

            not_edit_Inbox.Style.Add("display", "block");
            edit_inbox.Style.Add("display", "none");

        }
    }
    public void ddlBind()
    {
        mail.flag = "BIND_USERNAME";
        mail.FROM_DATE = "";
        mail.TO_DATE = "";
        ddlFrom_Address.Items.Clear();
        ddlFrom_Address.DataSource=mail.GetMail();
        ddlFrom_Address.DataTextField = "USER_NAME";
        ddlFrom_Address.DataValueField = "USER_NAME";
        ddlFrom_Address.DataBind();
        //ddlFrom_Address.Items.Remove(currentuser);
        //ddlFrom_Address.Items.Insert(0, currentuser);
        
    }
   
    protected void btnSend_Click(object sender, EventArgs e)
    {
        StringBuilder file_sb = new StringBuilder();
        HttpFileCollection fileCollection = Request.Files;
         int b = 0;
         for (int i = 0; i < fileCollection.Count; i++)
         {
             HttpPostedFile uploadfile = fileCollection[i];
            string fileName = Path.GetFileName(uploadfile.FileName);
            string ext = Path.GetExtension(uploadfile.FileName).ToLower();
            
            if (ext == ".sb" || ext == ".be" || ext == ".rtf" || ext == ".txt" || ext == ".doc" || ext == ".docx" || ext == ".xml" || ext == ".html" || ext == ".htm" || ext == ".xls" || ext == ".xlsx" || ext == ".pdf" || ext == ".jpg" || ext == ".jpeg" || ext == ".zip" || ext == ".rar" || ext == ".png" || ext == ".gif")
            {
                if (uploadfile.ContentLength > 0)
                {

                    //Alert_msg(getFilesizeDesc(uploadfile.ContentLength));
                    b = b + uploadfile.ContentLength;
                }
            }
            else
            {
                file_sb.AppendLine(ext);
            }
         }
         if (file_sb.ToString() != "")
         {
             Alert_msg(file_sb.ToString()+" File format not allowed.");
         }
         else
         {
             if (b < 10485760)
             {

                 string check = "";
                 for (int i = 0; i < ddlFrom_Address.Items.Count; i++)
                 {
                     if (ddlFrom_Address.Items[i].Selected)
                     {
                         check = "1";
                     }

                 }
                 if (check != "")
                 {

                     string fileName, Is_File_Exceeds = "";
                     StringBuilder sbm = new StringBuilder();
                     sb.Clear();
                     sb_File.Clear();
                     sb_RandNo.Clear();
                     sbm.Clear();
                     string Attach = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "UploadFiles/");
                     //+ fileName + "~~" + RAND_ID

                     Randon_No("");
                     b = 0;
                     for (int i = 0; i < fileCollection.Count; i++)
                     {
                         HttpPostedFile uploadfile = fileCollection[i];
                         fileName = Path.GetFileName(uploadfile.FileName);
                         if (uploadfile.ContentLength > 0)
                         {

                             //Alert_msg(getFilesizeDesc(uploadfile.ContentLength));
                             b = b + uploadfile.ContentLength;
                             if (uploadfile.ContentLength < 10485760)
                             {
                                 uploadfile.SaveAs(Attach + currentuser + RAND_ID + "~~" + fileName);
                                 //lblMessage.Text += fileName + "Saved Successfully<br>";

                                 sbm.Append(",");
                                 sbm.Append(fileName);
                                 sb_File.Append(currentuser + RAND_ID + "~~");
                                 sb_File.Append(fileName + "~/");




                             }
                             //else
                             //{
                             //    Alert_msg("File size exceeds maximum limit 10 MB.");
                             //}
                         }

                     }
                     if (b < 10485760)
                     {
                         if (sbm.ToString() != "")
                         {
                             lblMessage.Text += sbm.ToString().Remove(0, 1);// + "Saved Successfully<br>";
                         }
                         a = Send_mail("Yes", "No", "No", "No", "0", "0");
                         if (a == 1)
                         {
                             //Alert_msg("sent");
                             string prompt = "<script>$(document).ready(function(){{jAlert('Message Sent...', 'COMPOSE', function (r) {var i = r + 'ok';if (i == 'trueok'){window.location.href = window.location.href;} else {}});}});</script>";
                             ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                         }
                         else
                         {
                             //delete upload files
                             for (int ii = 0; ii < fileCollection.Count; ii++)
                             {
                                 HttpPostedFile uploadfile1 = fileCollection[ii];
                                 fileName = Path.GetFileName(uploadfile1.FileName);
                                 if (uploadfile1.ContentLength > 0)
                                 {
                                     Date_Time dt = new Date_Time();
                                     string d = Attach + currentuser + dt.Split("~~", sb_File.ToString()) + "~~" + fileName;
                                     if (File.Exists(d))
                                     {


                                         File.Delete(d);

                                     }

                                 }
                             }
                             //delete upload files

                         }
                     }
                     else
                     {
                         Alert_msg("File size exceeds maximum limit 10 MB.");
                     }
                 }
                 else
                     Alert_msg("Select to address..");
             }
             else
             {
                 Alert_msg("File size exceeds maximum limit 10 MB.");
             }
         }
    }
    public static string getFilesizeDesc(double sizeInBytes)
    {

        const double Terabyte = 1099511627776;
        const double Gigabyte = 1073741824;
        const double Megabyte = 1048576;
        const double Kilobyte = 1024;

        string result = string.Empty;
        double the_size = 0;
        string units = string.Empty;

        if (sizeInBytes >= Terabyte)
        {
            the_size = sizeInBytes / Terabyte;
            units = " Tb";
        }
        else
        {
            if (sizeInBytes >= Gigabyte)
            {
                the_size = sizeInBytes / Gigabyte;
                units = " Gb";
            }
            else
            {
                if (sizeInBytes >= Megabyte)
                {
                    the_size = sizeInBytes / Megabyte;
                    units = " Mb";
                }
                else
                {
                    if (sizeInBytes >= Kilobyte)
                    {
                        the_size = sizeInBytes / Kilobyte;
                        units = " Kb";
                    }
                    else
                    {
                        the_size = sizeInBytes;
                        units = " bytes";
                    }
                }
            }
        }

        if (units != "bytes")
        {
            result = the_size.ToString("N3") + " " + units;
        }
        else
        {
            result = the_size.ToString() + " " + units;
        }
        return result;
    }
    public int Send_mail(string inbox,string sent,string trash,string folder,string read,string delete)
    {
        mail.USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
       
        mail.INBOX_ID="";
        mail.RECEIVED_FROM=Session["currentuser"].ToString();
        mail.TO_ADDRESS = ddlBind_All().Remove(0, 2);
        //if (ddlFrom_Address.Value.ToString() == "All")
        //    mail.TO_ADDRESS = ddlBind_All().Remove(0, 2);
        //else
        //{
        //    mail.TO_ADDRESS = ddlFrom_Address.Value.ToString();
        //}
        mail.SUBJECT=txt_Subject.Text;
        mail.BODY_CONTENT=txt_Body.Text;
        mail.RECEIVED_DATE="";
        mail.FILE_NAME = sb_File.ToString();
        mail.RANDOM_FILE_NO = sb_RandNo.ToString().Remove(0, 2);

        mail.INBOX=inbox;
        mail.SENT=sent;
        mail.TRASH=trash;
        mail.FOLDER=folder;


        mail.READ_STATUS=read;
        mail.DELETE_STATUS=delete;
    
        mail.BRANCH_CODE=currentbranch;
        mail.YEAR="";
        mail.WORKING_PERIOD = Working_Period;
        mail.USER_ID = currentuser;

        mail.flag = "MAIL_SEND";

        mail.Send_Mail();
        return a = mail.result;
    }

    public string ddlBind_All()
    {

        for (int i = 0; i < ddlFrom_Address.Items.Count; i++)
        {
            if (ddlFrom_Address.Items[i].Selected)
            {

                sb.Append("~~");

                sb.Append(ddlFrom_Address.Items[i].Value);

            }

        }
           
                TO_ADDRESS = sb.ToString();
    
        //}
        //else
        //{
        //    TO_ADDRESS = ddlFrom_Address.SelectedValue.ToString();
        //}
        return TO_ADDRESS;
    }

    public string Randon_No(string file)
    {

        RAND_ID = GetRandomNumber(9, "0123456789");
        
        
        sb_RandNo.Append("~~");
        sb_RandNo.Append(RAND_ID);
        
        return FILE_NAME;
       
    }

    protected string GetRandomNumber(int length, string characterSet)
    {

        string randomData = "";

        int position = 0;

        byte[] data = new byte[length];

        int characterSetLength = characterSet.Length;

        System.Security.Cryptography.RandomNumberGenerator random = System.Security.Cryptography.RandomNumberGenerator.Create();

        random.GetBytes(data);

        for (int index = 0; (index < length); index++)
        {

            position = data[index];

            position = (position % characterSetLength);

            randomData = (randomData + characterSet.Substring(position, 1));

        }

        return randomData;



    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'COMPOSE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'COMPOSE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

     [System.Web.Services.WebMethod]
    public static string Getsize()
    {
        
         //HttpFileCollection fileCollection = HttpContext.Current.Request.Files;
        List<HttpPostedFile> fileCollection = (List<HttpPostedFile>)HttpContext.Current.Session["Files"];
        HttpPostedFile postedFile = HttpContext.Current.Request.Files["Filedata"];
            int b = 0;
            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile uploadfile = fileCollection[i];
                string fileName = Path.GetFileName(uploadfile.FileName);
                if (uploadfile.ContentLength > 0)
                {

                    //Alert_msg(getFilesizeDesc(uploadfile.ContentLength));
                    b = b + uploadfile.ContentLength;
                    
                }
            }

            return Convert.ToString(b);
    }
}