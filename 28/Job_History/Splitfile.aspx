<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Splitfile.aspx.cs" Inherits="Job_History_Splitfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server"  />
        <asp:TextBox ID="txtBrowsFile" runat="server"></asp:TextBox>
        <asp:Button ID="browse" runat="server" Text="browse" onclick="browse_Click" OnClientClick="document.getElementById('hiddenField1').value = document.getElementById('FileUpload1').value" />
        <asp:Button ID="Split" runat="server" Text="Split" onclick="btnSplit_Click" />
        <br />
        <asp:Label ID="lblSendingResult" runat="server" ></asp:Label>
        <div>
        <asp:ListBox ID="listBox1" runat="server"></asp:ListBox>
        <asp:Button ID="merge" runat="server" Text="merge" OnClick="btnMergeFile_Click"/>
        </div>
        <asp:HiddenField ID="hiddenField1" runat="server" />
    </div>
    </form>
</body>
</html>
