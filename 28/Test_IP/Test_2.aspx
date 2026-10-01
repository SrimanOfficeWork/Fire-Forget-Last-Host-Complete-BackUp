<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test_2.aspx.cs" Inherits="FlatFile_Test_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    <div style="font-weight:bold; border:1px;">
        Your IP Address :- <asp:Label ID="lblIPAddress" runat="server" Text=""></asp:Label><br /><br />
        Your Computer/Host Name :- <asp:Label ID="lblHostName" runat="server" Text=""></asp:Label>
        <br /><br />
      Your IP Address Behind Proxy :- <asp:Label ID="lblIPBehindProxy" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
