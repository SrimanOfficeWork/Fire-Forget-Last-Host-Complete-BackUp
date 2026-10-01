<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods_Registration_Air.aspx.cs"
    Inherits="Export_Annexure_C_Air" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Annexure C Air</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
     <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
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
   
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
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
            <%-- <div id="innerbox_MidMain_Transact_annuxerecair">
  <div id="tag_srcinner1_annexurec_air_main_cont1">
  <div id="tag_srcinner1_annexurec_air">
       <div id="mainmastop2container_rght_tag2_txt1">Annexure-C-Air </div>
        <div id="popupwindow_closebut_right"><input type="close" value="Submit" class="clsicon"  onclick="parent.adcodewindow.hide()" /> </div>
  </div>
  </div>
            --%>
            <div id="innerbox_MidMain_Trans_Goods_new">
                <ol id="toc">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();" id="Air_Id">
                        <span>Air</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                        runat="server" id="Package_Id"><span>Package</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="area_transac_container_genral">
                        <div id="popup_inn_container_Annuex_C_Sea">
                            <div id="annexure_c_main">
                                <div id="annexure_c_main_inner_Goods_Air">
                                    <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                        <div id="tag_label_transaction_annuxeairC">
                                            SB No
                                        </div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txtSBNo" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="7" TabIndex="1" onkeypress="return num1(event)"></asp:TextBox>
                                        </div>
                                        <div id="annuxreair_emptyarea">
                                        </div>
                                        <div id="tag_label_transaction_annuxeairC">
                                            SB Date
                                        </div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txtSBDate" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="10"
                                                TabIndex="2"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtSBDate"
                                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                            </cc1:MaskedEditExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtSBDate"
                                                Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                        <div id="tag_label_transaction_annuxeairC">
                                            Seal Type
                                        </div>
                                        <div id="txtcon_m_anncair">
                                            <asp:DropDownList ID="ddl_SealType" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                                TabIndex="3">
                                                <asp:ListItem>Agency</asp:ListItem>
                                                <asp:ListItem>Self</asp:ListItem>
                                                <asp:ListItem>WareHouse</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div id="annuxreair_emptyarea">
                                        </div>
                                        <div id="tag_label_transaction_annuxeairC">
                                            Nature of Cargo</div>
                                        <div id="txtcon_m_anncair">
                                            <asp:DropDownList ID="ddlNatureOfCargo" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                                TabIndex="4">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                        <div id="tag_label_transaction_annuxeairC">
                                            Gross Weight</div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txtGross_Weight" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="8" onblur="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" TabIndex="5"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="annexure_c_txt_area_2">
                                        </div>
                                        <div id="magnify_area">
                                        </div>
                                        <div id="ann_c_empty_1">
                                        </div>
                                        <div id="tag_label_transaction_annuxeairC">
                                            Net Weight
                                        </div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txtNet_Weight" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="8" onblur="extractNumber(this,2,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" TabIndex="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                        <div id="tag_label_transaction_annuxeairC">
                                            Unit of Measurement</div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txtUnit_Of_Measurement" runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_annuxrec_air1"
                                                ClientIDMode="Static" MaxLength="3" TabIndex="7" onkeypress="return char1(event)"
                                                onblur="ChangeCase(this);"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" onclick="OpenPopupUnit_Goods_Reg('ANNEX_C_SEA'); return false" class="magnfy">
                                            </a>
                                        </div>
                                        <div id="ann_c_empty_1">
                                        </div>
                                        <div id="annexure_c_txt_area_2">
                                        </div>
                                        <div id="tag_label_transaction_annuxeairC">
                                            Total No of Package</div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txtTotal_No_Packages" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="8" onblur="extractNumber(this,2,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" TabIndex="8"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="annexure_c_txt_area_2">
                                            
                                        </div>
                                        <div id="magnify_area">
                                           </div>
                                    </div>
                                    <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                        <div id="tag_label_transaction_annuxeairC">
                                            MAWB No/Date
                                        </div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txtMawb_No" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="11" onkeypress="return charnum2(event)" TabIndex="9"></asp:TextBox>
                                        </div>
                                        <div id="annuxreair_emptyarea">
                                            <div id="tag_label_transaction_popup_IGM2_empty">
                                            </div>
                                            <div id="txtcon-m_transaction_code">
                                                <asp:TextBox ID="txtMAWB_Date" runat="server" MaxLength="10" TabIndex="10" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtMAWB_Date"
                                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                </cc1:MaskedEditExtender>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtMAWB_Date"
                                                    Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </div>
                                        </div>
                                        <div id="tag_label_transaction_annuxeairC">
                                            HAWB No/Date
                                        </div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txtHawb_No" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="11" onkeypress="return charnum2(event)" TabIndex="11"></asp:TextBox>
                                        </div>
                                        <div id="annuxreair_emptyarea">
                                            <div id="tag_label_transaction_popup_IGM2_empty">
                                            </div>
                                            <div id="txtcon-m_transaction_code">
                                                <asp:TextBox ID="txtHAWB_Date" runat="server" MaxLength="10" TabIndex="12" CssClass="validate[required] txtbox_none_Mid_transac_code"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtHAWB_Date"
                                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                </cc1:MaskedEditExtender>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtHAWB_Date"
                                                    Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                        <div id="tag_label_transaction_annuxeairC">
                                            No.Of loose packets</div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txt_No_Of_LoosePkts" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="8" onblur="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" TabIndex="13"></asp:TextBox>
                                        </div>

                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="annexure_c_txt_area_2">
                                        </div>
                                        <div id="magnify_area">
                                        </div>
                                        <div id="ann_c_empty_1">
                                        </div>
                                        <div id="tag_label_transaction_annuxeairC">
                                            Transhipper Code
                                        </div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txt_TranshipperCode" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="10" TabIndex="14"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                        <div id="tag_label_transaction_annuxeairC">
                                            Gateway Port</div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txt_GatewayPort" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="6" TabIndex="15"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="annexure_c_txt_area_2">
                                        </div>
                                        <div id="magnify_area">
                                        </div>
                                        <div id="ann_c_empty_1">
                                        </div>
                                        <div id="tag_label_transaction_annuxeairC">
                                            WareHouse Code
                                        </div>
                                        <div id="txtcon_m_anncair">
                                            <asp:TextBox ID="txt_WareHouseCode" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="10"  TabIndex="16"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_exports_item_margs_nos_others_new1">
                                        <div id="tag_label_transaction_annuxeairC">
                                            Marks_Number
                                        </div>
                                        <asp:TextBox ID="txtMarks_Numbers" runat="server" MaxLength="300" CssClass="validate[required] txtbox_none_Mid_transac_item_gen_decs"
                                            TabIndex="16" TextMode="MultiLine" onkeyDown="return checkTextAreaMaxLength(this,event,'300');"
                                            onpaste="return checkTextAreaMaxLength(this,event,'300');"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                    <div id="tag_label_transaction_annuxeairC">
                                    </div>
                                    <div id="txtcon_m_anncair">
                                    </div>
                                    <div id="annuxreair_emptyarea">
                                    </div>
                                    <div id="tag_label_transaction_annuxeairC">
                                    </div>
                                    <div id="txtcon_m_anncair">
                                    </div>
                                </div>
                                <div id="innerbox_MidMain_bot_transact_invoice">
                                    <div id="newbu">
                                        <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="18" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="19"
                                            OnClientClick="return validate_Export_Goods_Reg_Air_Details();" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                            TabIndex="19" OnClientClick="return validate_Export_Goods_Reg_Air_Details();" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnDelete" runat="server" TabIndex="20" Visible="false" CssClass="dlete"
                                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'GOODS_REG_AIR', function(r) {
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
                                        <input type="submit" value="Submit" class="scancel" onclick="parent.parent.adcodewindow.hide()"
                                            tabindex="21" id="btnCancel" /></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <iframe name="trans_igm" scrolling="no" id="annexureCSea_Package_Iframe">
                    </iframe>
                </div>
            </div>
            </div>
            <asp:HiddenField ID="hdnTransport_mode" runat="server" />

            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Export_Jscript/Export_Goods_Reg_Air.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
   
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    
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
