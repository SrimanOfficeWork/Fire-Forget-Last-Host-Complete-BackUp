<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendMail.aspx.cs" Inherits="SendMail" %>
<html>
<head runat="server"><title>Email Test Page</title></head>
<body>
    <form id="form1" runat="server">
        Message to: <asp:TextBox ID="txtTo" runat="server" /><br>
        Message from: <asp:TextBox ID="txtFrom" runat="server" /><br>
        Subject: <asp:TextBox ID="txtSubject" runat="server" /><br>
        Message Body:<br>
        <asp:TextBox ID="txtBody" runat="server" Height="171px" TextMode="MultiLine" Width="270px" /><br>
        <asp:Button ID="Btn_SendMail" runat="server" onclick="Btn_SendMail_Click" Text="Send Email" /><br>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>