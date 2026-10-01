<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Excel_Upload.aspx.cs" Inherits="Admin_Admin_Excel_Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
<table>
<tr>
<td>
<span style="color: Red">*</span>Attach Excel file
</td>
<td>
<asp:FileUpload ID="fileuploadExcel" runat="server" />
</td>
</tr>
<tr>
<td></td>
<td>
<asp:Button ID="btnSend" runat="server" Text="Export" onclick="btnSend_Click"  />
</td>
</tr>
</table>
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
</div>
</form>
</body>
</html>


