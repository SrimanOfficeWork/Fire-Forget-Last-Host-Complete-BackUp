<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_AP_Invoice.aspx.cs"
    Inherits="Acc_AP_Invoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title></title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
             <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 990px;height: 390px; background-color: #FFFFFF; margin-top: 10px;">
                        
                         <div id="tag_transac_lft_IGM_Invoice_Grid_area" style="width: 970px; height: 330px;margin-top: 20px; border-style:none;">
                              <div id="tag_transac_lft_Inv_in1" style="width: 670px; height: 22px;">
                                <div id="tag_label_transaction_popup_gen" style="width: 50px">
                                   
                                </div>
                                <div id="tag_label_transaction_popup_gen" style="width: 200px">
                                    <asp:LinkButton ID="lnkOrg" runat="server" Text="Book Purchase" OnClientClick="open_GST_Purchase_Entry_N();"
                                        CommandName="SelectOrganization">
                                    </asp:LinkButton>

                                       &nbsp;
                                     <asp:LinkButton ID="lnkExp" runat="server" Text="Expenses Entry" OnClientClick="open_Expense_PaymentEntry_N();" CommandName="SelectOrganization">
                                    </asp:LinkButton>

                                </div>
                                
                            </div>

                            <asp:GridView ID="gv_details" runat="server" DataKeyNames="V_ID,VOUCHER_NO"
                                EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                                CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True" PageSize="15" AllowPaging="True"
                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound">
                                <HeaderStyle CssClass="header" BackColor="#808080" Font-Bold="True" ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="VOUCHER_DATE" HeaderText="Date" HeaderStyle-Width="40px">
                                        <ItemStyle CssClass="column_style_left"  Width="40px" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Bill No" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkOrg" runat="server" Text='<%# Eval("VOUCHER_NO") %>'  OnClientClick='<%# "return open_GST_Purchase_Entry(\"" + Eval("VOUCHER_NO") + "\");" %>'
                                             CommandName="SelectOrganization">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="column_style_left" Width="100px" Font-Size="12px" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Bill_Type" HeaderText="Type" HeaderStyle-Width="40px">
                                        <ItemStyle CssClass="column_style_left" Width="40px"  Font-Size="12px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VENDOR_NAME" HeaderText="Organization" HeaderStyle-Width="300px">
                                        <ItemStyle CssClass="column_style_left"  Width="300px" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BILL_CUR" HeaderText="Curr" HeaderStyle-Width="40px">
                                        <ItemStyle CssClass="column_style_left"  Width="40px"  Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CH_Amt" HeaderText="Amount" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"  Width="50px" Font-Size="12px" ForeColor="Green" Font-Bold="true" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="VENDOR_BILL_NO" HeaderText="Vendor Bill No." HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="column_style_left"  Width="80px" Font-Size="12px" Font-Bold="true" />
                                    </asp:BoundField>


                                   <%-- <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" Height="16px" Width="25px" ToolTip="Invoice Report"
                                                ImageUrl="~/images/icons/ACC_PDF.png" runat="server" OnClientClick='<%# "return GST_Billing_Job_Rpt(\"" + Eval("id") + "\", \"" + Eval("IMP_EXP") + "\", \"" + Eval("BILL_INV_NO") + "\");" %>'>
                                            </asp:ImageButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>--%>
                                      <asp:BoundField DataField="Balance_Outstanding" HeaderText="Balance" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"  Width="50px" Font-Size="12px" ForeColor="Green" Font-Bold="true" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="display: none;">
        <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
        <asp:HiddenField ID="HiddenGstn" runat="server" />
        <asp:HiddenField ID="hdntotal" runat="server" />
        <asp:HiddenField ID="HiddenField_index" runat="server" />
        <asp:HiddenField ID="HiddenField_ImportJobNo" runat="server" />
        <asp:HiddenField ID="Hdn_amt_inr" runat="server" />
        <asp:HiddenField ID="hdn_TaxValue" runat="server" />
    </div>
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
   
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/Accounts/Imp_Exp_Invoice_Tab.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }

        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });

        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {
                return options.allrules.validate2fields.alertText;
            }
        }

        function open_GST_Purchase_Entry(VOUCHER_NO) {
            NewWindow1('../Accounts_Purchase/PurchaseEntry.aspx?voucherno=' + VOUCHER_NO, '_blank', '1200', '585', 'yes');
        }
        function open_GST_Purchase_Entry_N() {
            NewWindow1('../Accounts_Purchase/PurchaseEntry.aspx', '_blank', '1200', '585', 'yes');
        }
        function open_Expense_PaymentEntry_N() {
            NewWindow1('../Accounts_Expense/Expense_Payment_Entry.aspx', '_blank', '1150', '630', 'yes');
        }
    </script>
</body>
</html>
