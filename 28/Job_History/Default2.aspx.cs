using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mail;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.Configuration;

namespace EMailSample
{
public partial class Job_Histry_Default2 : System.Web.UI.Page
{
       
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			lblMessage.Text = "";
		}

		

		protected void btnSend_Click(object sender, System.EventArgs e)
		{
			try
			{
				/* Create a new blank MailMessage */
				MailMessage mailMessage = new MailMessage ();
		
				mailMessage.From = txtSender.Text;
				mailMessage.To = txtReceiver.Text;
				mailMessage.Cc = txtCc.Text;
				mailMessage.Bcc = txtBcc.Text;
				mailMessage.Subject = txtSubject.Text;
				mailMessage.Body = txtBody.Text;

				/* Set the properties of the MailMessage to the
				   values on the form  */
				if (rblMailFormat.SelectedItem.Text == "Text")
					mailMessage.BodyFormat = MailFormat.Text;
				else
					mailMessage.BodyFormat = MailFormat.Html;
				
				/* We use the following variables to keep track of
				   attachments and after we can delete them */				   
				string attach1 = null;
				string attach2 = null;
				string attach3 = null;

				/*strFileName has a attachment file name for 
				  attachment process. */
				string strFileName = null;

				/* Bigining of Attachment1 process   & 
				   Check the first open file dialog for a attachment */
				if (inpAttachment1.PostedFile != null)
				{
					/* Get a reference to PostedFile object */
					HttpPostedFile attFile = inpAttachment1.PostedFile;
					/* Get size of the file */
					int attachFileLength = attFile.ContentLength; 
					/* Make sure the size of the file is > 0  */
					if (attachFileLength > 0)
					{
						/* Get the file name */
						strFileName = Path.GetFileName(inpAttachment1.PostedFile.FileName);
						/* Save the file on the server */
						inpAttachment1.PostedFile.SaveAs(Server.MapPath(strFileName));
						/* Create the email attachment with the uploaded file */
						MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
						/* Attach the newly created email attachment */
						mailMessage.Attachments.Add(attach);
						/* Store the attach filename so we can delete it later */
						attach1 = strFileName;
					}
				}
				/* Attachment-2 Repeat previous step */
				if (inpAttachment2.PostedFile != null)
				{
					HttpPostedFile attFile = inpAttachment2.PostedFile;
					int attachFileLength = attFile.ContentLength; 
					if (attachFileLength > 0)
					{
						strFileName = Path.GetFileName(inpAttachment2.PostedFile.FileName);
						inpAttachment2.PostedFile.SaveAs(Server.MapPath(strFileName));
						MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
						mailMessage.Attachments.Add(attach);
						attach2 = strFileName;
					}
				}
				/* Attachment-3 Repeat previous steps  */
				if (inpAttachment3.PostedFile != null)
				{
					HttpPostedFile attFile = inpAttachment3.PostedFile;
					int attachFileLength = attFile.ContentLength; 
					if (attachFileLength > 0)
					{
						strFileName = Path.GetFileName(inpAttachment3.PostedFile.FileName);
						inpAttachment3.PostedFile.SaveAs(Server.MapPath(strFileName));
						MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
						mailMessage.Attachments.Add(attach);
						attach3 = strFileName;
					}
				}
            
				/* Set the SMTP server and send the email with attachment */

				// SmtpMail.SmtpServer = "127.0.0.1";
                SmtpMail.SmtpServer.Insert(0, "127.0.0.1");
                //SmtpMail.SmtpServer.Insert(0, "103.21.58.151");
								
				SmtpMail.Send (mailMessage);

				/* Delete the attachements if any */
				if (attach1 != null)
					File.Delete(Server.MapPath(attach1));
				if (attach2 != null)
					File.Delete(Server.MapPath(attach2));
				if (attach3 != null)
					File.Delete(Server.MapPath(attach3));	

				/* clear the controls */
				txtSender.Text = "";
				txtReceiver.Text = "";
				txtCc.Text = "";
				txtBcc.Text = "";
				txtSubject.Text = "";
				txtBody.Text = "";

				/* Dispaly a confirmation message to the user. */
				lblMessage.Visible = true;
				lblMessage.ForeColor = Color.Black;
				lblMessage.Text = "Message sent.";
			}
			catch(Exception ex)
			{
				/* Print a message informing the 
				user about the exception that was risen */
				lblMessage.Visible = true;
				lblMessage.ForeColor = Color.Red;
				lblMessage.Text = ex.ToString();
			}
		
		}
	}
}