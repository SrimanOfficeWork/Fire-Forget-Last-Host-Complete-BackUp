<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="EMailSample.Job_Histry_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   	<title>Email with Attachment </title>
	
</head>
<body>
   <form id="SendMail" method="post" runat="server">
			<table borderColor="#ff9933" cellSpacing="0" cellPadding="4" width="55%" align="center"
				border="1">
				<tr>
					<td>
						<table cellPadding="4" width="70%" align="center" border="0">
							<tr bgColor="#ff9933">
								<td align="center" colSpan="2"><asp:label id="lblHeader" Runat="server" Font-Bold="True">SMTP Mail with Attachment</asp:label></td>
							</tr>
							<tr>
								<td vAlign="middle" align="right" width="40%">From :</td>
								<td vAlign="middle" width="60%"><asp:textbox id="txtSender" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="X-Small"
										Width="350px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="middle" align="right">To :</td>
								<td><asp:textbox id="txtReceiver" tabIndex="1" runat="server" Font-Names="Verdana"
										Font-Size="X-Small" Width="350px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="middle" align="right">Cc :</td>
								<td><asp:textbox id="txtCc" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="X-Small"
										Width="350px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="middle" align="right">Bcc :</td>
								<td><asp:textbox id="txtBcc" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="X-Small"
										Width="350px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="middle" align="right">Subject :</td>
								<td><asp:textbox id="txtSubject" tabIndex="2" runat="server" Font-Names="Verdana"
										Font-Size="X-Small" Width="350px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="middle" align="right">Format :</td>
								<td><asp:radiobuttonlist id="rblMailFormat" tabIndex="3" runat="server" repeatcolumns="2" repeatdirection="Horizontal">
										<asp:ListItem Value="Text" Selected="True">Text</asp:ListItem>
										<asp:ListItem Value="HTML">HTML</asp:ListItem>
									</asp:radiobuttonlist></td>
							</tr>
							<tr>
								<td vAlign="middle" align="right">Message :</td>
								<td height="84">
									<p><asp:textbox id="txtBody" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="X-Small"
											columns="40" rows="5" textmode="MultiLine" width="350px"></asp:textbox></p>
								</td>
							</tr>
							<tr>
								<td vAlign="middle" align="right">Attachment :</td>
								<td><input id="inpAttachment1" tabIndex="5" type="file" size="53" name="filMyFile" runat="server"></td>
							</tr>
							<tr>
								<td vAlign="middle" align="right">Attachment :</td>
								<td><input id="inpAttachment2" tabIndex="6" type="file" size="53" name="filMyFile" runat="server"></td>
							</tr>
							<tr>
								<td vAlign="middle" align="right">Attachment :</td>
								<td><input id="inpAttachment3" tabIndex="7" type="file" size="53" name="filMyFile" runat="server"></td>
							</tr>
							<tr>
								<td align="center" colSpan="2">
                                <asp:button id="btnSend" tabIndex="9" runat="server" width="100px" text="Send" OnClick="btnSend_Click"></asp:button></td>
							</tr>
							<tr>
								<td align="center" colSpan="2"><asp:Label ID="lblMessage" Runat="server"></asp:Label>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
    </form>
</body>
</html>
