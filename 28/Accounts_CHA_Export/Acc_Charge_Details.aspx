<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Charge_Details.aspx.cs"
    Inherits="Export_Acc_Charge_Details" %>

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
            <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 990px;
                height: 390px; background-color: #FFFFFF; margin-top: 37px;">
                <asp:CheckBox ID="chkQuotation" runat="server" Text="Quotation" AutoPostBack="true"
                    OnCheckedChanged="chkQuotation_CheckedChanged" ForeColor="#000099" />
                <div id="tag_transac_lft_IGM_Invoice_Grid_area" style="width: 975px; height: 320px; margin-top: 0px;">
                   
                    <asp:GridView ID="gv_details" runat="server" DataKeyNames="JOBNO,CHARGE_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="230%"
                        ShowHeaderWhenEmpty="True" PageSize="25" AllowPaging="True" AllowSorting="True"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                        OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:TemplateField HeaderText="Edit/Update" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkOrg" runat="server" Text="Edit" OnClientClick='<%# "return open_Imp_Exp_Charge_Upd(\"" + Eval("JOBNO") + "\", \"" + Eval("CHARGE_ID") + "\", \"E\");" %>'
                                        CommandName="SelectOrganization">
</asp:LinkButton>

                                </ItemTemplate>
                                <ItemStyle CssClass="column_style_left" Width="100px" Font-Size="12px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="CHARGE_ID" HeaderText="Charge id">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHARGE_HEAD" HeaderText="Charge Head">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="520px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TAX_TYPE" HeaderText="Tax Type">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CURRENCY" HeaderText="Currency">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QTY" HeaderText="Qty">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UNIT_PRICE" HeaderText="Unit Price">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AMOUNT_INR" HeaderText="Revenue Amount(INR)">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="REV_RECEIVABLE_FROM" HeaderText="Receivable">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="500px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COST_CURRENCY" HeaderText="Currency">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COST_QTY" HeaderText="Qty">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COST_UNIT_PRICE" HeaderText="Unit Price">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COST_AMOUNT_INR" HeaderText="Cost Amount(INR)">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COST_PAYABLE_TO" HeaderText="Payable">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="500px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>

                </div>

                <div id="tag_transac_lft_IGM_Invoice_Grid_area" style="width: 975px; height: 25px;
                    border-style: none; overflow: hidden; margin-top: -1px;">
                    <asp:LinkButton ID="linkCharge" runat="server" Text="New" OnClientClick="open_Acc_Charge_Entry();"
                        CommandName="SelectOrganization">
                    </asp:LinkButton>
                    &nbsp; <a href="javascript:void(0);" onclick="Excel()">Cost Sheet</a> &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkOrg" runat="server" Text="Book Purchase" OnClientClick="open_PurchaseEntry_New();"
                        CommandName="SelectOrganization">
                    </asp:LinkButton>
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Load_Click" Style="display: none" />
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
        <asp:HiddenField ID="HiddenField_ExportJobNo" runat="server" />
        <asp:HiddenField ID="Hdn_amt_inr" runat="server" />
        <asp:HiddenField ID="hdn_TaxValue" runat="server" />
    </div>
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/Accounts/Acc_iframepopupwin.js"></script>
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

     
    </script>
    <script type="text/javascript">
        var win = null;
        var JOBNO_PS = '<%= Session["JOBNO_PS"] != null ? Session["JOBNO_PS"].ToString() : "" %>';
        var JOBTYPE = 'E';
        var Flag = 'COST_SHEET';
        function Excel() {
            win = window.open('../Accounts_Data_Link/Ac_Data_Rpt_Link.aspx?Cost_Sheet_Data=Yes&JOBNO_PS=' + encodeURIComponent(JOBNO_PS) + '&JOBTYPE=' + JOBTYPE + '&Flag=' + Flag + '', 'ndf');
        }


        function open_PurchaseEntry_New() {


            NewWindow1('../Accounts_Purchase/Acc_PurchaseBill_Entry.aspx', '_blank', '1150', '597', 'yes');

        }

        function open_Acc_Charge_Entry() {
            NewWindow1('../Accounts_CHA_Import/Acc_Imp_Exp_Charges.aspx?I_E=E', '_blank', '1200', '400', 'yes');
        }
        function open_Acc_Charge_Entry_Upd(Ch_Id, Jobno) {
            NewWindow1('../Accounts_CHA_Import/Acc_Imp_Exp_Charges.aspx?Ch_Id=' + Ch_Id + '&I_E=' + 'I' + '&Jobno=' + Jobno, '_blank', '1200', '400', 'yes');
        }
    </script>
</body>
</html>
