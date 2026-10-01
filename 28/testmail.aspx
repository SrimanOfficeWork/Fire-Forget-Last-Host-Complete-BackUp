<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Net.Mail" %>
 
<script language="C#" runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
       //create the mail message
        MailMessage mail = new MailMessage();
 
        //set the addresses
        mail.From = new MailAddress("sathishkumarg@eroyalimpex.info");
        //mail.To.Add("ovihosting@gmail.com");
		mail.To.Add("sathish34@gmail.com");
        
        //set the content
        mail.Subject = "This is a test email from C# script";
        mail.Body = "This is a test email from C# script";
        //send the message
         SmtpClient smtp = new SmtpClient("mail.eroyalimpex.info");
          
         NetworkCredential Credentials = new NetworkCredential("sathishkumarg@eroyalimpex.info", "wCxo0*59");
         smtp.Credentials = Credentials;
         smtp.Send(mail);
         lblMessage.Text = "Mail Sent";
    }
</script>
<html>
<body>
    <form runat="server">
        <asp:Label id="lblMessage" runat="server"></asp:Label>
    </form>
</body>