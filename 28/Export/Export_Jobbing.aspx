<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Jobbing.aspx.cs" Inherits="Export_Export_Jobbing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Jobbing</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <style type="text/css">
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Trans_export_annexure_Main">
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_transac_exp_drawback">
                </div>
                <div id="pop_text_area_transac_inn_container_left_export_jobb_new1">
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            Notification No.
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtNotification_No" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                onkeypress="return notn(event)" TabIndex="1" MaxLength="8"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            BE No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtBE_No" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                MaxLength="8" TabIndex="2" Onkeypress="return num1(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            BE Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtBE_Date" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                MaxLength="10" TabIndex="3"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtBE_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtBE_Date"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            BE Invoice SL No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtBE_Invoice_SLNo" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                Onkeypress="return num1(event)" MaxLength="10" TabIndex="4"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            BE Invoice No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtBE_Invoice_No" runat="server" CssClass="txtbox_trans_exp_drawback"
                                 MaxLength="16" TabIndex="5"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            BE Item No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtBE_Item_No" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                Onkeypress="return num1(event)" MaxLength="10" TabIndex="6"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            BE Port Code
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtBE_PortCode" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                ClientIDMode="Static" Onkeypress="return NOTNSLNO(event)" MaxLength="6" TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="OpenPopupCustom_House('EXPORT_JOBBING'); return false" class="magnfy">
                            </a>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_jobb2">
                            Qty</div>
                        <div id="txtcon-m_transaction_item_CTH_small">
                            <asp:TextBox ID="txtQty" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small"
                                onblur="extractNumber(this,6,false);return Clear_Dot(this);" onkeyup="extractNumber(this,6,false);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="8" MaxLength="12"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_jobb3">
                            Unit</div>
                        <div id="txtcon-m_transaction_item_CTH_small">
                            <asp:TextBox ID="txtUnit" runat="server" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_item_CTH_small"
                                Onkeypress="return char1(event)" onblur="return ChangeCase(this);" MaxLength="3"
                                TabIndex="9"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="OpenPopupUnit('EXPORT_JOBBING'); return false" class="magnfy">
                            </a>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_bot_transact_invoice">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                            TabIndex="35" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate_Export_Jobbing();"
                            TabIndex="36" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate_Export_Jobbing();" TabIndex="36" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="37" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'JOBBING', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="37" OnClick="btnDelete_Click" OnClientClick="return validate_Export_Jobbing();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1('ITEM_ID');return false;"
                            tabindex="38" id="btnCancel" />
                    </div>
                </div>
                <div id="tag_transac_export_item_licencedet_gen_Grid_area" style="overflow:auto;  width:710px;">
                    <asp:GridView ID="gv_jobbing" runat="server" DataKeyNames="JOBBING_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="130%"
                        ShowHeaderWhenEmpty="True" PageSize="3" AllowPaging="True" AllowSorting="True"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                        OnRowCreated="gv_License_RowCreated" OnPageIndexChanging="gv_jobbing_PageIndexChanging"
                        OnRowDataBound="gv_jobbing_RowDataBound" OnSelectedIndexChanged="gv_jobbing_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="false">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="NOTIFICATION_NO" HeaderText="Notn No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_NO" HeaderText="BE No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_DATE" HeaderText="BE Date">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_INV_SLNO" HeaderText="BE Inv Sl No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_INV_NO" HeaderText="BE Inv No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_ITEM_NO" HeaderText="BE Item No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_PORT_CODE" HeaderText="BE Port Code">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QTY" HeaderText="Quantity">
                                <ItemStyle CssClass="column_style_right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UNIT" HeaderText="Unit">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                          <PagerSettings FirstPageText="First" LastPageText="Last" 
                                        Mode="NextPreviousFirstLast" NextPageText="Next" Position="Top" 
                                        PreviousPageText="Previous" />
                                        <PagerStyle CssClass="pager" />
                    </asp:GridView>
                </div>
            </div>
            <asp:HiddenField ID="hdfTransport_mode" runat="server" />
            <asp:HiddenField ID="hdn_update_Bond" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />

        </ContentTemplate>
    </asp:UpdatePanel>

    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

       <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
             
             <tr>
                 <td style="padding-left: 125px; padding-top:10px;">
                     <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>



    </form>
    <script src="../js/Export_Jscript/Export_Jobbing.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
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
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
    </script>
</body>
</html>
