<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
.Gridview
{
font-family:Verdana;
font-size:10pt;
font-weight:normal;
color:black;

}
</style>
<script type="text/javascript">
function ConfirmationBox(username) {

var result = confirm('Are you sure you want to delete  Details?' );
if (result) {

return true;
}
else {
return false;
}
}
</script>
</head>
<body>
    <form id="form1" runat="server">
<div>
<asp:GridView ID="gvDetails" DataKeyNames="ITEM_ID" runat="server" 
        AutoGenerateColumns="false" CssClass="Gridview" HeaderStyle-BackColor="#61A6F8" 
ShowFooter="true" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" 
        onrowcancelingedit="gvDetails_RowCancelingEdit" 
        onrowdeleting="gvDetails_RowDeleting" onrowediting="gvDetails_RowEditing" 
        onrowupdating="gvDetails_RowUpdating" 
        onrowcommand="gvDetails_RowCommand">
     
<Columns>
<asp:TemplateField>
<EditItemTemplate>
<asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Images/update.jpg" ToolTip="Update" Height="20px" Width="20px" />
<asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/Cancel.jpg" ToolTip="Cancel" Height="20px" Width="20px" />

</EditItemTemplate>
<ItemTemplate>
<asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Images/Edit.jpg" ToolTip="Edit" Height="20px" Width="20px" />
<asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server" ImageUrl="~/Images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
</ItemTemplate>
<FooterTemplate>
<asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/Images/AddNewitem.jpg" CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new User" ValidationGroup="validaiton" />

</FooterTemplate>
 </asp:TemplateField>
<asp:TemplateField HeaderText="UserName">
<EditItemTemplate>
<asp:Label ID="lbleditusr" runat="server" Text='<%#Eval("MARKS_NOS") %>'/>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="lblitemUsr" runat="server" Text='<%#Eval("MARKS_NOS") %>'/>
</ItemTemplate>
<FooterTemplate>
<asp:TextBox ID="txtftrusrname" runat="server"/>
<asp:RequiredFieldValidator ID="rfvusername" runat="server" ControlToValidate="txtftrusrname" Text="*" ValidationGroup="validaiton"/>
</FooterTemplate> 
</asp:TemplateField>
 <asp:TemplateField HeaderText="City">
 <EditItemTemplate>
 <asp:TextBox ID="txtcity" runat="server" Text='<%#Eval("DESCRIPTION") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lblcity" runat="server" Text='<%#Eval("DESCRIPTION") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtftrcity" runat="server"/>
 <asp:RequiredFieldValidator ID="rfvcity" runat="server" ControlToValidate="txtftrcity" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>
 <asp:TemplateField HeaderText="Designation">
 <EditItemTemplate>
 <asp:TextBox ID="txtstate" runat="server" Text='<%#Eval("QTY") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lblstate" runat="server" Text='<%#Eval("QTY") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtftrDesignation" runat="server"/>
  <asp:RequiredFieldValidator ID="rfvdesignation" runat="server" ControlToValidate="txtftrDesignation" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>
 </Columns>
</asp:GridView>

    </div>
<div>
<asp:Label ID="lblresult" runat="server"></asp:Label>
</div>
    </form>
</body>
</html>