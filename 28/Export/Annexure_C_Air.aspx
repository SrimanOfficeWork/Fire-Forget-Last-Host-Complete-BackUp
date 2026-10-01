<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Annexure_C_Air.aspx.cs" Inherits="Export_Annexure_C_Air" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Annexure C Air</title>
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


    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnUpdate,#btnSave').click(function () {

                var Gross_Weight = document.getElementById("txtGross_Weight").value;
                var Net_Weight = document.getElementById("txtNet_Weight").value;

                if (parseFloat(Net_Weight) > parseFloat(Gross_Weight)) {
                    alert("Net Weight is Greater than Gross Weight...");
                    return false;
                }

            });
        });
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
            <%-- <div id="innerbox_MidMain_Transact_annuxerecair">--%>
            <%--<div id="tag_srcinner1_annexurec_air_main_cont1">
                    <div id="tag_srcinner1_annexurec_air">
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Annexure-C-Air
                        </div>
                        <div id="popupwindow_closebut_right">
                            <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
                        </div>
                    </div>
                </div>--%>
            <div id="innerbox_MidMain_annx_CSea" style="width: 812px;">
                <ol id="toc">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();"
                        id="Annexure_Sea_Id"><span>Annexure-C-Air</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                        style="display: none;" runat="server" id="Package_Id"><span>Package</span></a></li>
                    <div id="popupwindow_closebut_right_opt1">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
                    </div>
                </ol>
                <div class="content" id="page-1">
                    <div id="tag_srcinner1_annexurec_air_main_cont2">
                        <div id="annexure_c_main">
                            <div id="annexure_c_main_inner">
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                    <div id="tag_label_transaction_annuxeairC">
                                        Seal No
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtSealNo" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="20" TabIndex="1" onkeypress="return charnum2(event)"></asp:TextBox>
                                    </div>
                                    <div id="annuxreair_emptyarea">
                                    </div>
                                    <div id="tag_label_transaction_annuxeairC">
                                        Seal Agency
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtSealAgency" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="40"
                                            TabIndex="10" onkeypress="return charnum2(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                    <div id="tag_label_transaction_annuxeairC">
                                        Nature of Cargo
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:DropDownList ID="ddlNatureOfCargo" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                            TabIndex="2">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="annuxreair_emptyarea">
                                    </div>
                                    <div id="tag_label_transaction_annuxeairC">
                                        Marks_Numbers</div>
                                    <div id="txtcon-m_46px_trans_export_marks" style="width: 250px">
                                        <asp:TextBox ID="txtMarks_Numbers" runat="server" CssClass="txtbox_none_Mid_transac_export_Marks_nos_gen"
                                            Width="250px" TextMode="MultiLine" MaxLength="200" TabIndex="11"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                    <div id="tag_label_transaction_annuxeairC">
                                        Total No of Package</div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtTotal_No_Packages" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="8" TabIndex="3" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="annexure_c_txt_area_2">
                                        <asp:TextBox ID="txtUnit_Code" runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_annuxrec_air2"
                                            ClientIDMode="Static" MaxLength="3" TabIndex="4" onkeypress="return char1(event)"
                                            onblur="ChangeCase(this);"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="OpenPopupUnit('ANNEX_C_AIR_PKG'); return false" class="magnfy">
                                        </a>
                                    </div>
                                    <div id="ann_c_empty_1">
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                    <div id="tag_label_transaction_annuxeairC">
                                        Net Weight
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtNet_Weight" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="14" TabIndex="5" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                    <div id="annuxreair_emptyarea">
                                    </div>
                                    <div id="tag_label_transaction_annuxeairC">
                                        Gross Weight
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtGross_Weight" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="14" TabIndex="13" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="annexure_c_txt_area_2">
                                        <asp:TextBox ID="txtUnitCode" runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_annuxrec_air2"
                                            ClientIDMode="Static" MaxLength="3" TabIndex="14" onkeypress="return char1(event)"
                                            onblur="ChangeCase(this);"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="OpenPopupUnit('ANNEX_C_AIR_GR_WGT'); return false" class="magnfy">
                                        </a>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                    <div id="tag_label_transaction_annuxeairC">
                                        MAWB No  & Date
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtMawb_No" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="15" TabIndex="6" onkeypress="return charnum2(event)"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="annuxreair_emptyarea" style="width: 115px">
                                        <asp:TextBox ID="txtMawb_Date" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            MaxLength="10" TabIndex="7"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtMawb_Date"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtMawb_Date"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transaction_annuxeairC">
                                        Freight Amount
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtFreight_Amount" runat="server" CssClass="txtbox_annuxrec_air1"
                                            MaxLength="200" TabIndex="15" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                    <div id="tag_label_transaction_annuxeairC">
                                        HAWB No  & Date
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtHawb_No" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="15"
                                            TabIndex="7" onkeypress="return charnum2(event)"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="annuxreair_emptyarea" style="width: 115px">
                                        <asp:TextBox ID="txtHawb_Date" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            MaxLength="10" TabIndex="8"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtHawb_Date"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtHawb_Date"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transaction_annuxeairC">
                                        Insurance Amount
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtInsurance_Amount" runat="server" CssClass="txtbox_annuxrec_air1"
                                            MaxLength="200" TabIndex="16" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                    <div id="tag_label_transaction_annuxeairC">
                                        Rotation No & Date
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtRotationNo" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="8"
                                            TabIndex="8" onkeypress="return num1(event)"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="annuxreair_emptyarea" style="width: 115px">
                                        <asp:TextBox ID="txtRotationDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="10" TabIndex="9"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtRotationDate"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRotationDate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transaction_annuxeairC">
                                        FOB Value
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtFOBValue" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="15"
                                            TabIndex="17" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                    <div id="tag_label_transaction_annuxeairC">
                                        Total No of Pkgs
                                        <br />
                                        MAWB Against
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtPackages_Against_MAWB" runat="server" CssClass="txtbox_annuxrec_air1"
                                            MaxLength="8" TabIndex="9" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="annuxreair_emptyarea" style="width: 110px">
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                </div>
                                <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                                </div>
                                <div id="innerbox_MidMain_bot_transact_invoice">
                                    <div id="newbu">
                                        <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="18" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                                            OnClick="btnNew_Click" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="19"
                                            OnClientClick="return validate_Export_AnnexureC1_Air_Details();" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                            TabIndex="19" OnClientClick="return validate_Export_AnnexureC1_Air_Details();" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnDelete" runat="server" TabIndex="20" Visible="false" CssClass="dlete"
                                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'ANNEXURE_C_AIR', function(r) {
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
                                        <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                                            tabindex="21" id="btnCancel" /></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <iframe src="#" name="trans_igm" scrolling="no" id="annexureCSea_Package_Iframe">
                    </iframe>
                </div>
            </div>
                <script src="../activatables.js" type="text/javascript"></script>
                <script type="text/javascript">
                    activatables('page', ['page-1', 'page-2']);
                </script>
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
    <script src="../js/Export_Jscript/Export_Annexure_C_Air.js" type="text/javascript"></script>
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
