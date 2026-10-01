<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BE_Entry_General.aspx.cs"
    Inherits="Export_General" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
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
            <div id="innerbox_MidMain_Transact_popup_new">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        BE Entry
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transaction_inner_new">
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new">
                            Job No
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtJobNo" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                MaxLength="10" ReadOnly="True" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_date">
                            Job Date
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtJobDate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                MaxLength="10" TabIndex="2"></asp:TextBox>
                            <%-- <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>--%>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel">
                            Transport Mode</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlTransportMode" runat="server" Enabled="false" CssClass="listtxt_transac_mode_new"
                                TabIndex="3">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new">
                            BE Type</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlBEType" runat="server" CssClass="listtxt_transac_src1" TabIndex="4"
                                Enabled="false">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_date">
                            Custom House</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtCustomsHouse" runat="server" ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                onkeyup="ChangeCase(this);" onfocus="ChangeCase(this);" onblur="ChangeCase(this);"
                                onkeypress="return pin1(event)" MaxLength="50" TabIndex="5" Enabled="false"></asp:TextBox>
                        </div>
                        <div id="magnify_area" runat="server">
                            <%-- <a href="#" class="magnfy" onclick="OpenPopupCustom_House(''); return false" tabindex="6"></a>--%>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_popup_no_empty_new">
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();"
                        id="Air_Page"><span>BE Entry</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="area_transac_container_genral">
                        <div id="pop_text_area_transac_popup_inn_container_new">
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                            </div>
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                    No. of Packages
                                </div>
                                <div id="txtcon-m_transaction_Supp_code_Re_Import">
                                    <asp:TextBox ID="txtNo_Packages" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                        MaxLength="8" onblur="extractNumber(this,2,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" TabIndex="6"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                    Assessable Value
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtAssessableValue" runat="server" CssClass="txtbox_annuxrec_air1"
                                        MaxLength="23" onblur="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" TabIndex="7"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                    Weight
                                </div>
                                <div id="txtcon-m_transaction_Supp_code_Re_Import">
                                    <asp:TextBox ID="txtWeight" runat="server" MaxLength="8" CssClass="validate[required] txtbox_annuxrec_air1"
                                        TabIndex="8" onkeypress="return blockNonNumbers(this, event, true, false);" onblur="extractNumber(this,2,false);"
                                        onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                    Duty Value
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtDutyValue" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="20"
                                        onkeypress="return num1(event)" TabIndex="9"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                    BE No
                                </div>
                                <div id="txtcon-m_transaction_Supp_code_Re_Import">
                                    <asp:TextBox ID="txtBE_No" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                        TabIndex="10" MaxLength="7" onblur="extractNumber(this,2,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        onkeyup="extractNumber(this,0,false);return Clear_Dot(this);"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                    BE Date
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtBE_Date" runat="server" MaxLength="200" CssClass="validate[required] txtbox_annuxrec_air1"
                                        TabIndex="11"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                        DisplayMoney="Left" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date"
                                        MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError" TargetControlID="txtBE_Date">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtBE_Date">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                                <span id="Exp_Amt" runat="server" visible="false">
                                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                        Expense Amt
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                                        <asp:TextBox ID="txt_Expense_Amt" runat="server" MaxLength="20" CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                                            onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtItem_UnitPrice');return Clear_Dot(this);"
                                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            TabIndex="12"></asp:TextBox>
                                    </div>
                                </span>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                               
                            </div>
                            
                            <div id="warehouse1" style="display: none;" runat="server">
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                        BE INBond No.
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                                        <asp:TextBox ID="txtINBond_No" runat="server" MaxLength="20" CssClass="txtbox_annuxrec_air1"
                                            TabIndex="12" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                        BE INBond Date
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txtINBond_Date" runat="server" MaxLength="200" CssClass="txtbox_annuxrec_air1"
                                                TabIndex="13"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptNegative="Left"
                                                DisplayMoney="Left" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date"
                                                MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError" TargetControlID="txtINBond_Date">
                                            </cc1:MaskedEditExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtINBond_Date">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                        WareHouse Customs
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtWareHouse_Customs" runat="server" TabIndex="14" ClientIDMode="Static"
                                            CssClass="txtbox_none_Mid_transac_code_new"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" class="magnfy" onclick="OpenPopupCustom_House('Warehouse_Customs'); return false">
                                        </a>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_item_licens_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                        WareHouse Customs Code
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txtWareHouse_Customs_Code" runat="server" CssClass="txtbox_annuxrec_air1"
                                                MaxLength="15" TabIndex="15"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <fieldset id="fieldset_Fairmacs" runat="server" visible="false" style="border: Black; border-style: double; margin-left: 0px; margin-top:10px; width: 820px; height:97px;" >
                            <legend style="border: Black; border-collapse: collapse; width: 250px; font-weight: bold; background-color:Scrollbar; color:Teal; ">
                    Fairmacs Customs Duty Report</legend>
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:900px; margin-top:15px;">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others"  style="width:60px;">
                                    TR No
                                </div>
                                <div id="txtcon-m_transaction_Supp_code_Re_Import"  style="width:170px;">
                                    <asp:TextBox ID="txtTR_No" runat="server" CssClass="txtbox_annuxrec_air1"
                                        TabIndex="16" MaxLength="50" ></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others"  style="width:80px;">
                                    Late Fees
                                </div>
                                <div id="txtcon-m_transaction_Supp_code"  style="width:150px;">
                                    <asp:TextBox ID="txtLateFees" runat="server" MaxLength="20" CssClass="txtbox_annuxrec_air1"
                                       Width="140px" TabIndex="16"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:60px;">
                                    Interest
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtInterest" runat="server" MaxLength="20" CssClass="txtbox_annuxrec_air1"
                                        TabIndex="16" Width="100px"></asp:TextBox>
                                </div>
                            </div>
                            </fieldset>
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                            </div>
                            <div id="innerbox_MidMain_bot_transact">
                                <div id="innerbox_transac_bot_inn">
                                    <div id="newbu">
                                        <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="17" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                                            OnClick="btnNew_Click" Visible="false" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="16"
                                            OnClientClick="return validate_Export_AnnexureC1_Sea_Details();" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                            TabIndex="18" OnClientClick="return validate_Export_AnnexureC1_Sea_Details();" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnDelete" runat="server" TabIndex="19" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'BE_ENTRY', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                        <asp:Button ID="btn" runat="server" TabIndex="19" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                    </div>
                                    <div id="editbu">
                                        <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                                            tabindex="20" id="btnCancel" /></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div> </div> </div>
            <asp:HiddenField runat="server" ID="HiddenField1"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdn_Edit_TransportMode"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdfTransport_mode"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdn_Jobno"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdn_BE_ID"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdn_PackType"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdn_WeightType"></asp:HiddenField>
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1']);
            </script>
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
    <script src="../js/Import_Jscript/Import_BE_Entry.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
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
