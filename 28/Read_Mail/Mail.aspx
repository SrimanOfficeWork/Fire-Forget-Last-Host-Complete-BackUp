<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mail.aspx.cs" Inherits="Mail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    Mail Server Name:
    <asp:TextBox ID="txtMailServer" runat="server" />
    <br />
    UserName:
    <asp:TextBox ID="txtUserName" runat="server" />
    <br />
    Password:
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
    <br />
    Port:
    <asp:TextBox ID="txtPort" runat="server" Text="110" />
    <br />
    SSL:
    <asp:CheckBox ID="chkSSL" runat="server" />
    <br />
    <asp:Button ID="btnReadEmails" runat="server" Text="Read Emails" OnClick="Read_Emails" />
    <br />
    <hr />
    <asp:GridView ID="gvEmails" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="From" DataField="From" />
            <asp:HyperLinkField HeaderText="Subject" DataNavigateUrlFields="MessageNumber" DataNavigateUrlFormatString="~/ShowMessageCS.aspx?MessageNumber={0}"
                DataTextField="Subject" />
            <asp:BoundField HeaderText="Date" DataField="DateSent" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
