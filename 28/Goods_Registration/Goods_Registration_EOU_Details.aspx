<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods_Registration_EOU_Details.aspx.cs"
    Inherits="Export_Annexure_C1Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Annexure C1 | Transaction</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .hideGridColumn
        {
            display: none;
        }
        
        .hideGridColumn1
        {
            display: none;
        }
    </style>
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
            <div id="innerbox_MidMain_Trans_Goods_new">
                <ol id="toc">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');" id="ITEM_ID">
                        <span>EOU Details</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="innerbox_MidMain_Trans_export_annexure_Main">
                        <div id="pop_text_area_transac_inn_container_left_export_annexure_other">
                            <%--
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_long">
                                    Exporter Name</div>
                                
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                    <asp:TextBox ID="txtExporterName" runat="server" MaxLength="40" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"
                                        ClientIDMode="Static" TabIndex="1"></asp:TextBox>
                                </div>
                                
                                <div id="magnify_area">
                                    <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('Exporter'); return false">
                                    </a>
                                </div><%--<a href="#" onclick="jQuery('#form1').validationEngine('hideAll');openclient_Masternew(); return false">New</a>
                           
   <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
  <div id="tag_label_transaction_popup_trand_exp_annex_rght_long">IEC No </div>

 <div id="txtcon-m_transaction_Supp_code">
   <asp:TextBox ID="txtIECNo" runat="server" MaxLength="10"  onkeypress="return pin(event)" TabIndex="2"  ClientIDMode="Static" CssClass="validate[required,minSize[10],custom[number]] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
   
  </div>
<%--<div id="magnify_area">
<a href="#" onClick="jQuery('#form1').validationEngine('hideAll'); OpenPopupImporterDetails('Exporter_AnnuxureC1'); return false"  class="magnfy"></a></div>
   </div>
   <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
  <div id="tag_label_transaction_popup_trand_exp_annex_rght_long">Branch SL. No. </div>

 <div id="txtcon-m_transaction_Supp_code">
 <asp:TextBox ID="txtBranchSLNo" runat="server"  CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_Supp_Name"  onkeypress="return pin(event)" MaxLength="3" TabIndex="3" ClientIDMode="Static"></asp:TextBox>

  </div>
<div id="magnify_area"></div>
   </div>--%>
                            <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_long">
                                    Exammination Date
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtExaminationDate" MaxLength="10" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        TabIndex="4"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtExaminationDate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExaminationDate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"
                        runat="server" ControlToValidate="txtExaminationDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                                </div>
                                <div id="magnify_area">
                                </div>
                            </div>
                            <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_long">
                                    Examination Officer
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtExam_Officer" runat="server" MaxLength="30" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        TabIndex="5"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_small">
                                    Designation</div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtExam_Design" MaxLength="30" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        TabIndex="6"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_long">
                                    Supervising Officer</div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtSuperv_Officer" MaxLength="30" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        TabIndex="7"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_small">
                                    Designation</div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtSuperv_Design" MaxLength="30" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        TabIndex="8"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_long">
                                    Commissionerate
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtCommissionRate" MaxLength="20" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        TabIndex="9"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_small">
                                    Division</div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtDivision" MaxLength="20" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        TabIndex="10"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_small2">
                                    Range</div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtRange" MaxLength="20" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        TabIndex="11"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Transexport_annexure_Supp_in2">
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_long">
                                    Verified by Examination Officer
                                </div>
                                <div id="txtcon_transac_checkbox">
                                    <asp:CheckBox ID="chkVerifiedOfficer" runat="server" CssClass="validate[required]"
                                        TabIndex="12" />
                                    <%-- <input name="" type="checkbox" value="" checked>--%>
                                </div>
                                <div id="trans_exp_annexure_emptyarea">
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_small3">
                                    Sample Drawn
                                </div>
                                <div id="txtcon_transac_checkbox">
                                    <asp:CheckBox ID="chkSampleDrawn" runat="server" CssClass="validate[required]" TabIndex="13" />
                                    <%-- <input name="" type="checkbox" value="" checked>--%>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                <div id="tag_label_transaction_popup_trand_exp_annex_rght_long">
                                    Seal No
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtSealNo" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        MaxLength="100" TabIndex="14"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact_invoice">
                            <div id="newbu">
                                <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="15" CausesValidation="false"
                                    UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                                    OnClick="btnNew_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="16"
                                    OnClientClick="return validate_Export_GOODS_REG_EOU_Details();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                    TabIndex="16" OnClientClick="return validate_Export_GOODS_REG_EOU_Details();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDelete" runat="server" TabIndex="17" Visible="false" CssClass="dlete"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'ANNEXURE_C1', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                <asp:Button ID="btn" runat="server" TabIndex="17" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />
                            </div>
                            <div id="editbu">
                                <input type="submit" value="Submit" class="scancel" onclick="parent.parent.adcodewindow.hide()"
                                    tabindex="18" id="btnCancel" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1']);
    </script>
    </form>
    <script src="../js/Export_Jscript/Export_Goods_Reg_EOU.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
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
    <script src="../js/listpopup.js" type="text/javascript"></script>
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
