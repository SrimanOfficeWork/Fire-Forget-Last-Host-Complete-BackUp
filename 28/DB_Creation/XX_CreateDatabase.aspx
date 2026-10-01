<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XX_CreateDatabase.aspx.cs" Inherits="XX_CreateDatabase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <div>
      <asp:Label ID="lblname" runat="server" Text="Database Name"></asp:Label>
      <asp:TextBox ID="txtName" runat="server"  Width="250px"></asp:TextBox>
    </div>
    <div></div>
      <asp:Button ID="btn_Create" runat="server" Text="Create DB" 
            onclick="btn_Create_Click" />
    </div>
    </form>
</body>
</html>
