<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Accounts_No_Invoice_Details.aspx.cs"
    Inherits="Accounts_CHA_Import_Accounts_No_Invoice_Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
    
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="tag_transac_lft_IGM_Invoice_Grid_area" style="width: 970px; height: 330px;
                margin-top: 20px;">
                <asp:GridView ID="gv_details" runat="server" DataKeyNames="BILL_INV_NO,JOBNO_PS"
                    EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                    CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True" PageSize="15" AllowPaging="True"
                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="1" CellSpacing="1" OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound">
                    
                    <HeaderStyle CssClass="header" BackColor="#808080" Font-Bold="True" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Inv No" ItemStyle-BackColor="Black">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMP_EXP" HeaderText="Inv No">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BILL_INV_NO" HeaderText="Inv No">
                            <ItemStyle CssClass="column_style_left" />
                            <ItemStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JOBNO_PS" HeaderText="Jobno" ControlStyle-Width="110px">
                            <ItemStyle CssClass="column_style_left" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REG_SEZ" HeaderText="Reg/Sez">
                            <ItemStyle CssClass="column_style_left" />
                            <ItemStyle Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TR_YN" HeaderText="Trans bill">
                            <ItemStyle CssClass="column_style_left" />
                            <ItemStyle Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNAPPROVAL_APPROVED" HeaderText="Status">
                            <ItemStyle CssClass="column_style_left" />
                            <ItemStyle Width="10px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="GRAND_TOTAL" HeaderText="Grand Total">
                            <ItemStyle CssClass="column_style_left" />
                            <ItemStyle Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INV_STATUS" HeaderText="Inv Status">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="E -Invoice" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Image ID="Image1" ImageUrl='<%# "~/images/icons/" + (Eval("INV_STATUS").ToString() == "DONE" ? "P.png" : "A.png") %>'
                                    runat="server" Height="10px" Width="10px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Button ID="btnrpt" runat="server" TabIndex="125" Text="Get Bill" OnClientClick='<%# "return GST_Billing_Job_Rpt(\"" + Eval("id") + "\", \"" + Eval("IMP_EXP") + "\", \"" + Eval("BILL_INV_NO") + "\");" %>'
                                    Height="30px" Width="50px" />
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="display: none;">
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="hdn_Grid_Disable" runat="server" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/Accounts/Imp_Exp_Invoice_Tab.js"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        body
        {
            font-size: 62.5%;
        }
    </style>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    </form>
    <script type="text/javascript">
        function GST_Billing_Job_Rpt(Job_Id, Imp_Exp, Bill_Inv_No) {
            if (Job_Id != '') {
                NewWindow1('../Accounts_Sales_Inv_Rpt/GST_Imp_Exp_rpt.aspx?Job_Id=' + Job_Id + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Inv_No, 'List', '870', '1024', 'yes');
            } else {
                jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
            }
        }
    </script>
</body>
</html>
