<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_License_Details.aspx.cs"
    Inherits="Export_Export_License_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>License Details</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
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
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="frame2_export_item_license_lft1_new1" style="height:300px;">
                <div id="tag_transac_lft_trans_item_maindet_license_lft1_new1">
                    <div id="tag_label_transaction_licencetab_new1">
                        Sl. No
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtRegn_Sl_No" CssClass="txtbox_none_Mid_transac_Supp_Name" runat="server"
                            MaxLength="10" TabIndex="1"></asp:TextBox>
                    </div>
                </div>

                <div id="tag_transac_lft_trans_item_maindet_license_lft1_new1">
                    <div id="tag_label_transaction_licencetab_new1">
                        License No
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtLicenseNo" CssClass="txtbox_none_Mid_transac_Supp_Name" runat="server"
                          MaxLength="25" TabIndex="2"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupLicense_Master(document.getElementById('hdn_License_Scheme').value); return false"
                                    class="magnfy"></a>
                            </div>
                    
                </div>


                <div id="tag_transac_lft_trans_item_maindet_license_lft1_new1">
                    <div id="tag_label_transaction_licencetab_new1">
                        Date</div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtDate" CssClass="txtbox_none_Mid_transac_Supp_Name" runat="server"
                            MaxLength="10" TabIndex="3"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div id="innerbox_MidMain_bot_transact_exp_licen_new1" style="width:400px;">
                    <div id="newbu">
                        <asp:Button ID="btnLicense_New" runat="server" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                            CausesValidation="false" UseSubmitBehavior="false" TabIndex="6" OnClick="btnLicense_New_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnLicense_Save" runat="server" CssClass="save" OnClick="btnLicense_Save_Click"
                            OnClientClick="return validate_Export_License(event)" TabIndex="4" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnLicense_Update" runat="server" CssClass="updates" OnClick="btnLicense_Update_Click"
                            OnClientClick="return validate_Export_License(event)" TabIndex="5" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnLicense_Delete" runat="server" TabIndex="7" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'LICENSE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn1').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn1" runat="server" TabIndex="10" OnClick="btnLicense_Delete_Click"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1('ITEM_ID');"
                            tabindex="11" id="Submit1" /></div>
                </div>
                <div id="tag_transac_export_lft1_license_Grid_area_new1" style="overflow:auto; height:180px; width:338px; background-color:White;">
                    <asp:GridView ID="gv_License" runat="server" DataKeyNames="LICENSE_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                        ShowHeaderWhenEmpty="True" PageSize="7" AllowPaging="True" AllowSorting="True"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                        OnPageIndexChanging="gv_License_PageIndexChanging" OnRowCreated="gv_License_RowCreated"
                        OnRowDataBound="gv_License_RowDataBound" OnSelectedIndexChanged="gv_License_SelectedIndexChanged">

                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                          
                            <asp:BoundField DataField="LICENSE_R_SL_NO" HeaderText="Sl NO">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                              <asp:BoundField DataField="LICENSE_NO" HeaderText="License No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LICENSE_DATE" HeaderText="License Date">
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
            <div id="frame2_export_item_license_rght1_new1">
                <asp:Panel ID="Panel1" runat="server" Enabled="false">
                    <div id="pop_exp_item_licen_new1_tagrght_tag2">
                        <div id="tag_transac_lft_trans_item_maindet_license_rght1_new1">
                            <div id="tag_label_transaction_licencetab_rght_new1">
                                Export Item SL. No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_new" style="width:80px;">
                                <asp:TextBox ID="txtExport_Item_Sl_No" CssClass="validate[required] txtbox_none_Mid_transac_BrSl_No"
                                    runat="server" MaxLength="10" TabIndex="12" Onkeypress="return num1(event)" Width="70px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_licencetab_new1" style="width:70px;">
                                Export Qty
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_new" style="width:103px;">
                                <asp:TextBox ID="txtExport_Qty" CssClass="validate[required] txtbox_none_Mid_transac_BrSl_No"
                                    runat="server" MaxLength="17" TabIndex="13" onblur="extractNumber(this,3,false);" Width="100px"
                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_licencetab_rght_new2"  style="width:40px; margin-left:-10px;">
                                <asp:Label ID="lblQtyCode" runat="server" Text="Label" Visible="false" CssClass="tag_label_transaction_Export_License" Width="20px"></asp:Label>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="editbu">
                                <asp:Button ID="btn_ExpQty_all" Text="Set ExpQty-All" Width="100px" runat="server"
                                    UseSubmitBehavior="false" OnClick="btn_ExpQty_all_Click" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_item_maindet_license_rght1_new1_empty">
                        </div>
                        <div id="tag_transac_lft_trans_item_maindet_license_rght1_new1" style="height:50px;">
                            <div id="tag_label_transaction_licencetab_rght_new1">
                                Import Item SL. No</div>
                            <div id="txtcon-m_transaction_Supp_code_new" style="width:80px;">
                                <asp:TextBox ID="txtImport_Item_Sl_No" CssClass="txtbox_none_Mid_transac_BrSl_No"
                                   Onkeypress="return num1(event)" runat="server" MaxLength="10" TabIndex="14"  Width="70px"></asp:TextBox>
                            </div>

                            <div id="tag_label_transaction_licencetab_rght_desc_new1" style="width:70px;">
                                Description</div>
                            <div id="txtcon_m_transaction_exp_license_new1_desc">
                                <asp:TextBox ID="txtDescription" CssClass="txtbox_none_Mid_transac_exp_license_desc_new1"
                                    runat="server" MaxLength="250" TabIndex="15" ></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_item_maindet_license_rght1_desc_multi_new1"  style="height:8px;">
                            <%--<div id="tag_label_transaction_licencetab_rght_desc_new1">
                                Description</div>
                            <div id="txtcon_m_transaction_exp_license_new1_desc">
                                <asp:TextBox ID="txtDescription" CssClass="txtbox_none_Mid_transac_exp_license_desc_new1"
                                    runat="server" MaxLength="250" TabIndex="15" ></asp:TextBox>
                            </div>--%>
                        </div>
                        <div id="tag_transac_lft_trans_item_maindet_license_rght1_new1">
                            <div id="tag_label_transaction_licencetab_rght_new1">
                                Import Quantity
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_new">
                                <asp:TextBox ID="txtImport_Qty" CssClass="txtbox_none_Mid_transac_BrSl_No" runat="server"
                                    onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="16"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice_terms">
                                Unit
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtImport_Unit" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" ClientIDMode="Static" MaxLength="3" TabIndex="17" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('EXPORT_LICENSE'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice_terms">
                                N/M
                            </div>
                            <div id="txtcon-m_transaction_list1">
                                <asp:DropDownList ID="ddlNM" runat="server" CssClass="listtxt_transac_src1" TabIndex="18">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact_exp_licen_new1" style="margin-left:10px; width:560px; ">
                            <div id="newbu">
                                <asp:Button ID="btnNew" runat="server" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                    CausesValidation="false" UseSubmitBehavior="false" TabIndex="22" OnClick="btnNew_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnSave" runat="server" ValidationGroup="bond" CssClass="save" OnClick="btnSave_Click"
                                    OnClientClick="return validate_Export_License_Imp_Exp(event)" TabIndex="19" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnSaveNew" runat="server" ValidationGroup="bond" CssClass="autowidupdatebut" Text="Save &amp; New" OnClick="btnSaveNew_Click"
                                   OnClientClick="return validate_Export_License_Imp_Exp(event)" TabIndex="20" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" ValidationGroup="bond" CssClass="updates"
                                    TabIndex="19" OnClick="btnUpdate_Click" OnClientClick="return validate_Export_License_Imp_Exp(event)"
                                    Visible="false" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDelete" runat="server" TabIndex="20" Visible="false" CssClass="dlete"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'LICENSE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                <asp:Button ID="btn" runat="server" TabIndex="20" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />
                            </div>
                            <div id="editbu">
                                <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1('ITEM_ID');return false;"
                                    tabindex="21" id="btnCancel" /></div>
                                    <div id="div_AmendmentType"  visible="false"  runat="server">
                                <div id="tag_label_transaction_popup_gen" style="width: 85px; font-weight: bold;">
                                    Amend Type
                                </div>
                                <div id="txtcon-m_transaction_item_maindet" style="width: 120px">
                                    <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                        Width="120px">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="A">AMENDMENT</asp:ListItem>
                                        <asp:ListItem Value="S">SUPPLEMENT</asp:ListItem>
                                        <asp:ListItem Value="D">DELETE</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="tag_transac_export_rght1_license_Grid_area_new1" style="overflow:auto; height:148px; background-color:White;">
                            <asp:GridView ID="gv_License_Imp_Exp" runat="server" DataKeyNames="LICENSE_IMP_EXP_ID"
                                EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                                CssClass="grid-view" Width="150%" ShowHeaderWhenEmpty="True" PageSize="100" AllowPaging="True"
                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" OnPageIndexChanging="gv_License_Imp_Exp_PageIndexChanging"
                                OnRowCreated="gv_License_Imp_Exp_RowCreated" OnRowDataBound="gv_License_Imp_Exp_RowDataBound"
                                OnSelectedIndexChanged="gv_License_Imp_Exp_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="LICENSE_NO" HeaderText="License No" HeaderStyle-Width="10px">
                                        <ItemStyle CssClass="column_style_left" Width="10px" />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="LICENSE_REG_SLNO" HeaderText="License Reg.No">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>--%>
                                      <asp:BoundField DataField="LICENSE_REG_SLNO">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                    <asp:BoundField DataField="LICENSE_E_SL_NO" HeaderText="Exp Sl No"  HeaderStyle-Width="20px">
                                        <ItemStyle CssClass="column_style_left"  Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_EXP_QTY" HeaderText="Exp Qty"  HeaderStyle-Width="20px">
                                        <ItemStyle CssClass="column_style_left" Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_EXP_UNIT" HeaderText="Unit" HeaderStyle-Width="10px">
                                        <ItemStyle CssClass="column_style_left"  Width="10px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_IMP_ITEM_SL_NO" HeaderText="Imp.Sl No"  HeaderStyle-Width="20px">
                                        <ItemStyle CssClass="column_style_left" Width="20px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_IMP_QTY" HeaderText="Quantity"  HeaderStyle-Width="20px">
                                        <ItemStyle CssClass="column_style_left"  Width="20px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_IMP_UNIT" HeaderText="Unit"  HeaderStyle-Width="10px">
                                        <ItemStyle CssClass="column_style_left"  Width="10px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_IMP_TYPE" HeaderText="N/M"  HeaderStyle-Width="10px">
                                        <ItemStyle CssClass="column_style_left"  Width="10px"/>
                                    </asp:BoundField>
                                     <asp:BoundField DataField="LICENSE_IMP_DESC" HeaderText="Imp Desc">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AMENDMENT_TYPE" HeaderText="Amend Type">
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
                </asp:Panel>
            </div>
            <asp:HiddenField ID="hdn_update_License_Imp_Exp" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_reg_sl_no" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_License_no" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_update_License" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_License_Scheme" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Import_Slno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_desc" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Import_qty" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Import_unit" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_NM_type" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_license_istrue" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" ClientIDMode="Static" />

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
    <script src="../js/Export_Jscript/Export_License.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Autotab.js" type="text/javascript"></script>
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
