<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="Job_Histry_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript">
    // Select/Deselect checkboxes based on header checkbox
    function SelectheaderCheckboxes(headerchk) {
        debugger
        var gvcheck = document.getElementById('gvdetails');
        var i;
        //Condition to check header checkbox selected or not if that is true checked all checkboxes
        if (headerchk.checked) {
            for (i = 0; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                inputs[0].checked = true;
            }
        }
        //if condition fails uncheck all checkboxes in gridview
        else {
            for (i = 0; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                inputs[0].checked = false;
            }
        }
    }
    //function to check header checkbox based on child checkboxes condition
    function Selectchildcheckboxes(header) {
        var ck = header;
        var count = 0;
        var gvcheck = document.getElementById('gvdetails');
        var headerchk = document.getElementById(header);
        var rowcount = gvcheck.rows.length;
        //By using this for loop we will count how many checkboxes has checked
        for (i = 1; i < gvcheck.rows.length; i++) {
            var inputs = gvcheck.rows[i].getElementsByTagName('input');
            if (inputs[0].checked) {
                count++;
            }
        }
        //Condition to check all the checkboxes selected or not
        if (count == rowcount - 1) {
            headerchk.checked = true;
        }
        else {
            headerchk.checked = false;
        }
    }
</script>
</head>
<body>
<form id="form1" runat="server">
<div>
<asp:GridView ID="gvdetails" runat="server"  onrowdatabound="gvdetails_RowDataBound" >
<Columns>
<asp:TemplateField>
<HeaderTemplate>
<asp:CheckBox ID="chkheader" runat="server" onclick="javascript:SelectheaderCheckboxes(this)" />
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox ID="chkchild" runat="server"/>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>

</div>
</form>
</body>
</html>  