<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Item_Excel_Upload.aspx.cs" Inherits="Transaction_Item_Excel_Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

 <html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Read and Display Data From an Excel File (.xsl or .xlsx) in ASP.NET</title>
</head>
<body>
<form id="form1" runat="server">
<div>
<b>Please Select Excel File: </b>
<asp:FileUpload ID="fileuploadExcel" runat="server" />&nbsp;&nbsp;
<asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" />
<br />
<asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label><br />
<asp:GridView ID="grvExcelData" runat="server">
<HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
</asp:GridView>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
     <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

</div>
</form>
</body>
</html>
