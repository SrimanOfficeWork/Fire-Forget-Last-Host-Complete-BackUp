using System;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Text;
using System.Data;

public partial class Live_Query : ThemeClass
{
    AppSession aps = new AppSession();
    string[] arr = new string[] { };
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            txtclientID.Text = Session["COMPANY_LICENSE"].ToString();
            txtqueryby.Text = Connection.Current_User();
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, System.EventArgs e)
    {
        Mail();
    }
    private void Mail()
    {
        MailMessage myMessage = new MailMessage();
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("royaltech1006@gmail.com", "E-Royal Query");
        SmtpClient client = new SmtpClient();
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //-----------------------------------------------------------//
        
        client.EnableSsl = true;
        client.Host = "127.0.0.1";//For Royal Tech Server
        client.Port = 25;
        client.EnableSsl = false;
        
        //-----------------------------------------------------------//

        /*
         client.EnableSsl = true;
         client.Host = "smtp.gmail.com";//Gmail
         client.Port = 587;
        */

        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("royaltech1006@gmail.com", "rtschennai123");
        client.UseDefaultCredentials = true;
        client.Credentials = credentials;
       
         string Server = string.Empty;
           DataSet ds = new DataSet();
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            if (ds.Tables[2].Rows[0][1].ToString() != string.Empty && ds.Tables[2].Rows[0][1].ToString() != null)
            {
                arr = ds.Tables[2].Rows[0][1].ToString().Split(';');
                if (arr[0] == "Server=74.63.193.105")
                {
                    Server = "Url:Eroyalimpex.co.in";
                }
                else if (arr[0] == "Server=69.162.74.182")
                {
                    Server = "Url:Eroyalimpex.net";
                }
                else if (arr[0] == "Server=74.208.90.62")
                {
                    Server = "Url:Eroyalimpex.org";
                }
            }

        try
        {

            string strbdyCHM = "", strallhdrtd = "", stralltbl = "";
            strallhdrtd = "style=\"background-color:silver;font-size:8pt;border-width:0px 0px 1px 0px;border-style:solid;border-color:black\" align=\"center\" valign=\"middle\"";
            stralltbl = "cellpadding=\"1\" cellspacing=\"1\" style=\"font-size:8pt;width:75%\"";

            strbdyCHM = "<div></div><div></div><div></div><div></div><div style=\"font-family:verdana;font-size:10pt;color:#0000FF\"> Hi Team,<br/> <div style=\"font-family:verdana;font-size:10pt;color:#FF69B4\"> <b> Type      :</b>" + ddltype.SelectedItem.Text + " <br/> </div>  ";
            strbdyCHM = strbdyCHM + "<div style=\"font-family:verdana;font-size:10pt;color:#FF69B4\"><b>Priority    : </b> " + ddlpriority.SelectedItem.Text + "<br/> </div>";
            strbdyCHM = strbdyCHM + "<div style=\"font-family:verdana;font-size:10pt;color:#FF69B4\"><b>Jobno       : </b>" + txtjobno.Text + "<br/> </div>";

            strbdyCHM = strbdyCHM + "<div style=\"font-family:verdana;font-size:10pt;color:#FF69B4\"><b>Query       : </b> " + txtQuery.Text + "<br/> </div>";
            strbdyCHM = strbdyCHM + "<div style=\"font-family:verdana;font-size:10pt;color:#FF69B4\"><b>Client ID   : </b> " + txtclientID.Text + "<br/> </div>";
            strbdyCHM = strbdyCHM + "<div style=\"font-family:verdana;font-size:10pt;color:#FF69B4\"><b>EMail ID    : </b> " + txtEmail_Id.Text + "<br/> </div>";
            strbdyCHM = strbdyCHM + "<div style=\"font-family:verdana;font-size:10pt;color:#FF69B4\"><b>Contact No  : </b> " + txt_contactNo.Text + "<br/> </div>";
            strbdyCHM = strbdyCHM + "<div style=\"font-family:verdana;font-size:10pt;color:#FF69B4\"><b>Query Created by : </b> " + txtqueryby.Text + " <br/> </div>";
            strbdyCHM = strbdyCHM + "<div style=\"font-family:verdana;font-size:10pt;color:#FF69B4\"><b>Alias Created by : </b> " + txt_alias_by.Text + " <br/> </div>";

            strbdyCHM = strbdyCHM + "<div></div><div></div><div></div><div></div><div style=\"font-family:verdana;font-size:10pt;color:#0000FF\"><br/>Thanks/Regards,<br/><b>Royal Tech Systems,</b><br/>No.8, Old No.19, 2nd Floor,<br/> 2nd Cross Street,Kalaimagal Nagar,<br/> Ekkatuthangal, Chennai-600032<br/>Cell:09840668986 <br/></br> Ph:044-42669886 (10 Lines)<br/></br>Email: admin@royaltechsystems.co.in<br/></br> " + Server + "<br/><br/> </div>";
            mail.Subject = "E-royal Live Query : " + DateTime.Now.AddDays(0).ToString("dd/MM/yyyy") + "";

            //---------------------
            
            mail.To.Add(new MailAddress("admin@royaltechsystems.co.in"));
            mail.To.Add(new MailAddress("sales@royaltechsystems.co.in"));
            mail.To.Add(new MailAddress("sathishkumarg@royaltechsystems.co.in"));
            mail.To.Add(new MailAddress("balamurugan@royaltechsystems.co.in"));
            mail.To.Add(new MailAddress("balamurugan@royaltechsystems.co.in"));
            mail.To.Add(new MailAddress("chithra.karthik@royaltechsystems.co.in"));
          
            //---------------------

            mail.IsBodyHtml = true;
            mail.Body = strbdyCHM.ToString();
            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;
            client.Send(mail);
            mail.Attachments.Clear();

            Alert_msg("Message Sent Successfully");

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
}