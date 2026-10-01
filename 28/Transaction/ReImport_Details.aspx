<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReImport_Details.aspx.cs"
    Inherits="Transaction_ReImport_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item | Transaction</title>
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
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            BindControls();
        });
        function BindControls() {
            var Notn = ['094/96', '043/2017', '045/2017', '046/2017', '047/2017', '072/2017', '043/96'];

            $('#txtNOTN_No').autocomplete({
                source: Notn,
                minLength: 0,
                scroll: true
            }).focus(function () {
                $(this).autocomplete("search", "");
            });
        }

        $(document).ready(function () {
            $('#ddlreimp_ntnslno').change(function () {
                var notn = $('#ddl_NOTN_No').val();
                var slno = $('#ddlreimp_ntnslno').val();

                if (notn == '045/2017' || notn == '046/2017' || notn == '047/2017') {
                    if (slno == '1A' || slno == '1B' || slno == '1C' || slno == '1D' || slno == '1E') {
                        $("#txtExport_Freight").attr("disabled", "disabled");
                        $("#txtExport_Insurance").attr("disabled", "disabled");

                        $("#txtCustoms_Duty").removeAttr("disabled");
                        $("#txtExcise_Duty").removeAttr("disabled");

                        $("#txtExport_Freight").val('');
                        $("#txtExport_Insurance").val('');

                        $("#txtCustoms_Duty").val('0.00');
                        $("#txtExcise_Duty").val('0.00');

                    }
                    else if (slno == '2' || slno == '3') {
                        $("#txtExport_Freight").removeAttr("disabled");
                        $("#txtExport_Insurance").removeAttr("disabled");

                        $("#txtCustoms_Duty").attr("disabled", "disabled");
                        $("#txtExcise_Duty").attr("disabled", "disabled");

                        $("#txtExport_Freight").val('0.00');
                        $("#txtExport_Insurance").val('0.00');

                        $("#txtCustoms_Duty").val('');
                        $("#txtExcise_Duty").val('');
                    }
                    else if (slno == '4' || slno == '5') {
                        $("#txtExport_Freight").attr("disabled", "disabled");
                        $("#txtExport_Insurance").attr("disabled", "disabled");
                        $("#txtCustoms_Duty").attr("disabled", "disabled");
                        $("#txtExcise_Duty").attr("disabled", "disabled");

                        $("#txtExport_Freight").val('');
                        $("#txtExport_Insurance").val('');
                        $("#txtCustoms_Duty").val('');
                        $("#txtExcise_Duty").val('');
                    }
                    else {
                        $("#txtExport_Freight").removeAttr("disabled");
                        $("#txtExport_Insurance").removeAttr("disabled");
                        $("#txtCustoms_Duty").removeAttr("disabled");
                        $("#txtExcise_Duty").removeAttr("disabled");

                        $("#txtExport_Freight").val('');
                        $("#txtExport_Insurance").val('');
                        $("#txtCustoms_Duty").val('');
                        $("#txtExcise_Duty").val('');
                    }
                }
                else {
                    $("#txtExport_Freight").removeAttr("disabled");
                    $("#txtExport_Insurance").removeAttr("disabled");
                    $("#txtCustoms_Duty").removeAttr("disabled");
                    $("#txtExcise_Duty").removeAttr("disabled");

                    $("#txtExport_Freight").val('');
                    $("#txtExport_Insurance").val('');
                    $("#txtCustoms_Duty").val('');
                    $("#txtExcise_Duty").val('');
                }
            });
        });
   
    </script>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        SB. No
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtSB_No" runat="server" MaxLength="7" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="1" onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                    <div id="txtcon-m_transaction_item_maindet_ReImport">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        SB. Date
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtSB_Date" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="2" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtSB_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSB_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        SB Invoice SlNo
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtSB_InvoiceNo" runat="server" MaxLength="2" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="3" onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                    <div id="txtcon-m_transaction_item_maindet_ReImport">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        SB Invoice Item No
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtSB_Invoice_ItemNo" runat="server" MaxLength="4" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="4" onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Port Export</div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtPort_Export" runat="server" MaxLength="6" CssClass="validate[minSize[6]] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="5" onkeypress="return NOTNSLNO(event)" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hide');OpenPopupImport_Port_House('IMPORT_REIMPORT'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_maindet_ReImport">
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        NOTN No
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:DropDownList ID="ddl_NOTN_No" Width="155px" TabIndex="6" CssClass="listtxt_transac_item_gen_notn"
                            runat="server" MaxLength="10">
                            <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                            <asp:ListItem Text="045/2017" Value="045/2017"></asp:ListItem>
                            <asp:ListItem Text="046/2017" Value="046/2017"></asp:ListItem>
                            <asp:ListItem Text="047/2017" Value="047/2017"></asp:ListItem>
                            <asp:ListItem Text="072/2017" Value="072/2017"></asp:ListItem>
                            <asp:ListItem Text="043/96" Value="043/96"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="txtcon-m_transaction_item_maindet_ReImport">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        NOTN SL No
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:DropDownList ID="ddlreimp_ntnslno" Width="155px" CssClass="listtxt_transac_item_gen_notn" TabIndex="7"
                            runat="server">
                            <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="1A" Value="1A"></asp:ListItem>
                            <asp:ListItem Text="1B" Value="1B"></asp:ListItem>
                            <asp:ListItem Text="1C" Value="1C"></asp:ListItem>
                            <asp:ListItem Text="1D" Value="1D"></asp:ListItem>
                            <asp:ListItem Text="1E" Value="1E"></asp:ListItem>
                            <asp:ListItem Text="1F" Value="1F"></asp:ListItem>
                            <asp:ListItem Text="1G" Value="1G"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Export Freight
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtExport_Freight" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="8" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                    </div>
                    <div id="txtcon-m_transaction_item_maindet_ReImport">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Export Insurance
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:TextBox ID="txtExport_Insurance" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="9" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Customs Duty
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtCustoms_Duty" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="10" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                    </div>
                    <div id="txtcon-m_transaction_item_maindet_ReImport">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Excise Duty
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtExcise_Duty" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="11" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty_Re_import">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="12"
                            OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                     <div id="editbu">
                        <asp:Button ID="btn_save_new" Text="Save & New" CssClass="autowidupdatebut" TabIndex="12"
                            runat="server"  OnClientClick="return validate_Import_Reimport()" OnClick="btn_save_new_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="12" OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="13" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'RE-IMPORT', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="13" OnClick="btnDelete_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('ItemMain');return false;"
                            TabIndex="14" CausesValidation="false" UseSubmitBehavior="false" />
                        <%-- <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button();"
                            tabindex="14" id="btnCancel" />--%></div>
                    <div id="editbu" style="width: 150px;">
                        <asp:Button ID="btn_Sup_Doc_XL_Upload" Text="Re-Import XL Upload" CssClass="autowidupdatebut"
                            CausesValidation="false" Width="150px" runat="server" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hide');Open_ReImport_Excel_Upload();return false;" />
                    </div>
                </div>
                <div id="tag_transac_lft_Item_reimport_Grid_area" style="overflow: auto; height: 133px;">
                    <asp:GridView ID="gv_ReImport" runat="server" DataKeyNames="RE_IMPORT_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="140%"
                        ShowHeaderWhenEmpty="True" OnRowDataBound="gv_ReImport_RowDataBound" OnSelectedIndexChanged="gv_ReImport_SelectedIndexChanged"
                        AllowPaging="False" AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gv_ReImport_RowCreated">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="44px">
                                <ItemTemplate>
                                    <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="44px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="SB_NO" HeaderText="SB No" ControlStyle-Width="45px">
                                <ItemStyle CssClass="column_style_left5" Width="45px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SB_DATE" HeaderText="SB Date" ControlStyle-Width="40px">
                                <ItemStyle CssClass="column_style_left5" Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PORT_EXPORT" HeaderText="Port of Export">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SB_INVOICE_NO" HeaderText="SB Inv.No">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SB_INVOICE__ITEM_NO" HeaderText="SB Inv Item No">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTN_NO" HeaderText="NOTN No">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTN_SLNO" HeaderText="NOTN Sl.No">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EXPORT_FREIGHT" HeaderText="Export Freight">
                                <ItemStyle CssClass="column_style_right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EXPORT_INSURANCE" HeaderText="Export Insurance">
                                <ItemStyle CssClass="column_style_right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CUSTOMS_DUTY" HeaderText="Customs Duty">
                                <ItemStyle CssClass="column_style_right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EXCISE_DUTY" HeaderText="Excise Duty">
                                <ItemStyle CssClass="column_style_right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:HiddenField ID="hdn_update_Reimport" runat="server" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdn_Customhouse_chk" runat="server" ClientIDMode="Static" />
        </ContentTemplate>
    </asp:UpdatePanel>
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
                        <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    </form>
    <script src="../js/Import_Jscript/Import_ReImport.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script>


        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function OpenPopupImport_Port_House(val) {


            if (document.getElementById('hdfTransport_mode').value != '') {

                var s = document.getElementById('hdfTransport_mode').value;

                OpenPopupCustom_House_Details_Port(s, val);
                return false
            }
        }
   
    </script>
</body>
</html>
