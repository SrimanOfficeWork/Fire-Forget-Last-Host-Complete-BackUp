using System;
using System.Web.UI.WebControls;
using System.Net.Mail;
public partial class SendMail : System.Web.UI.Page
{
    protected void Btn_SendMail_Click(object sender, EventArgs e)
    {
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
    mail.To.Add("cloudlinkstechnology@gmail.com");
    mail.From = new MailAddress("info@eroyalimpex.trade", "HostingHome Technical Support", System.Text.Encoding.UTF8);
    mail.Subject = "This mail is send from asp.net application";
    mail.SubjectEncoding = System.Text.Encoding.UTF8;
    mail.Body = "This is Email Body Text";
    mail.BodyEncoding = System.Text.Encoding.UTF8;
    mail.IsBodyHtml = true;
    mail.Priority = MailPriority.High;
    SmtpClient client = new SmtpClient();
    client.Credentials = new System.Net.NetworkCredential("info@eroyalimpex.trade", "eroyalimpex176");
    client.Port = 587;
    client.Host = "mail.eroyalimpex.trade";
    try
    {
        client.Send(mail);
        Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
    }
    catch (Exception ex)
    {
        Exception ex2 = ex;
        string errorMessage = string.Empty;
        while (ex2 != null)
        {
            errorMessage += ex2.ToString();
            ex2 = ex2.InnerException;
        }
        Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
    }

    }
}