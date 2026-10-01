<%@ Page Language="C#" AutoEventWireup="true" CodeFile="License_Master.aspx.cs" Inherits="eRoyalMasters_Adcode_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>License Master | Updation</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
            LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
            <ContentTemplate>
                <div class="loading" align="center" id="load" style="display: none;">
                    <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
                </div>

                <div id="innerbox_MidMain_popup_adcode">
                    <div id="innerbox_MidMain_top_adcode">
                        LICENSE MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide(); RefreshParent(); return false;" />
                    </div>
                    </div>
                    <div id="innerbox_MidMain_Mid_adcode">
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                License Number
                            </div>
                            <div id="txtcon_mid_size">
                                <asp:TextBox ID="txtLicense_No" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    TabIndex="1" MaxLength="25"></asp:TextBox>
                            </div>

                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                License Date
                            </div>
                            <div id="txtcon-m_src" style="width:90px;">
                                <asp:TextBox ID="txtLicense_date" runat="server" CssClass="validate[required] txtbox_none" Width="80px"
                                    Onkeypress="return numchar(event)" TabIndex="3" MaxLength="40"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtLicense_date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtLicense_date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_adcode" style="width:35px;">
                                Type
                            </div>
                            <div id="txtcon-m_src" style="width:100px;">
                                <asp:DropDownList ID="ddlLicense_type" runat="server" CssClass="listtxt-s_inner" Width="100px"
                                    TabIndex="6">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="pop_text_area" style="display: none">
                            <div id="tag_label_adcode">
                                Reg.No.
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtReg_No" runat="server" CssClass="txtbox_none"
                                    TabIndex="4" Onkeypress="return pin(event)" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area" style="display: none">
                            <div id="tag_label_adcode">
                                Reg.Date
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtReg_date" runat="server" CssClass="txtbox_none" TabIndex="5"
                                    Onkeypress="return numchar(event)" MaxLength="40"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtReg_date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtReg_date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        <%--<div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Type
                            </div>
                            <div id="txtcon-m_src">
                                <asp:DropDownList ID="ddlLicense_type" runat="server" CssClass="listtxt-s_inner"
                                    TabIndex="6">
                                </asp:DropDownList>
                            </div>
                        </div>--%>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Exp Item S.No
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Exp_Item_Slno" runat="server" CssClass="txtbox_none" TabIndex="7"
                                    MaxLength="10" Onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Imp Item S.No
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtItem_Slno" runat="server" CssClass="txtbox_none" TabIndex="7"
                                    MaxLength="10" Onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area"  style="height:40px;">
                            <div id="tag_label_adcode">
                                Description
                            </div>
                            <div id="txtcon-m_Maxtxt">
                                <asp:TextBox ID="txtDescription" runat="server" MaxLength="250" TextMode="MultiLine"
                                    CssClass="txtbox_none_Maxtxt_Client" onkeyDown="return checkTextAreaMaxLength(this,event,'250');"
                                    onpaste="return checkTextAreaMaxLength(this,event,'250');" TabIndex="8"></asp:TextBox>
                            </div>

                        </div>
                         <%--<div id="pop_text_area"></div>--%>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                               Total Imp Qty
                            </div>
                            <div id="txtcon-m_src" style="width:120px;">
                                <asp:TextBox ID="txtTotImportQty" runat="server" CssClass="txtbox_none" TabIndex="9" MaxLength="13" Width="100px"
                                    onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_adcode" style="width:30px;">
                                Unit
                            </div>
                            <div id="txtcon_mid_size" style="width:50px;">
                                <asp:TextBox ID="txtUnit" runat="server" CssClass="validate[minSize[3]] txtbox_none_mid_size" TabIndex="10" Width="50px"
                                    MaxLength="3" Onkeypress="return char(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" shape="poly" onclick="OpenPopupUnit('LICENSE_MASTER'); return false" class="magnfy"
                                    tabindex="11"></a>
                            </div>
                        </div>
                        <div id="pop_Remaining_Imp_Qty" runat="server" style="margin-left:40px; width:360px; height:32px;">
                            <div id="tag_label_adcode">
                               Remaining Imp Qty
                            </div>
                            <div id="txtcon-m_src" style="width:220px;">
                                <asp:TextBox ID="txt_Remaining_ImportQty" runat="server" CssClass="txtbox_none" TabIndex="12" MaxLength="13" Width="100px"
                                    onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" Enabled="false"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>
                        
                         <div id="pop_text_area_Exp_Qty" runat="server"  style="margin-left:40px; width:360px; height:15px;">
                            <div id="tag_label_adcode">
                               Total Exp Qty
                            </div>
                            <div id="txtcon-m_src" style="width:120px;">
                                <asp:TextBox ID="txtTotExportQty" runat="server" CssClass="txtbox_none" TabIndex="12" MaxLength="13" Width="100px"
                                    onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_adcode" style="width:30px;">
                                Unit
                            </div>
                            <div id="txtcon_mid_size" style="width:50px;">
                                <asp:TextBox ID="txtExpUnit" runat="server" CssClass="validate[minSize[3]] txtbox_none_mid_size" TabIndex="13" Width="50px"
                                    MaxLength="3" Onkeypress="return char(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" shape="poly" onclick="OpenPopupUnit('LICENSE_MASTER_ExpQty'); return false" class="magnfy"
                                    tabindex="14"></a>
                            </div>
                        </div>

                         <div id="pop_Remaining_Exp_Qty" runat="server"  style="margin-left:40px; width:360px; height:30px;">
                            <div id="tag_label_adcode">
                               Remaining Exp Qty
                            </div>
                            <div id="txtcon-m_src" style="width:220px;">
                                <asp:TextBox ID="txt_Remaining_ExportQty" runat="server" CssClass="txtbox_none" TabIndex="12" MaxLength="13" Width="100px"
                                    onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" Enabled="false"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>

                        <div id="pop_text_area" style="height:20px;">
                            <div id="tag_label_adcode">
                                N / M
                            </div>
                            <div id="txtcon-m_src">
                                <asp:DropDownList ID="ddlNM_type" runat="server" CssClass="listtxt-s_inner"
                                    TabIndex="15">
                                </asp:DropDownList>

                            </div>
                        </div>
                         <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Lic. Expired Date
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtLicense_Expireddate" runat="server" CssClass="txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="16" MaxLength="40"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtLicense_Expireddate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtLicense_Expireddate"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        <div id="lblMsg2" style="display: none;">
                        </div>

                    </div>
                </div>
                <div id="innerbox_MidMain_top_adcode">
                    <div id="innerbox_adcode_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                CssClass="new" TabIndex="19" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick="return validate_License();"
                                TabIndex="17" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                                OnClientClick="return validate_License();" TabIndex="17" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="18" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'LICENSE MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="18" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSaveNew" Text="Save & New" TabIndex="18" CssClass="autowidupdatebut"
                                OnClientClick="return validate();" runat="server"
                                OnClick="btnSaveNew_Click" />
                        </div>

                        <div id="editbu">
                            <input type="submit" value="" class="scancel" onclick="RefreshParent(); return false;"
                                tabindex="20" id="btnCancel" />
                            <asp:HiddenField ID="hdn_Update_Adcode" runat="server" />
                            <asp:HiddenField ID="hdn_check_adcode" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>

                        <div id="editbu">
                            <asp:Button ID="btn_LicenseReport" Text="Qty Utilized Rpt" TabIndex="18" CssClass="autowidupdatebut" Width="98px"
                               OnClientClick="open_jobno(); return false" runat="server"
                                />
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
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
        //        $(window).bind("load", function () {
        //            $('#load').hide(); ;
        //        });

        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }

        $(function () {
            $("#txtUnit,#txtExpUnit").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txtUnit') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Unit', 'error', 'topRight', true);
                                }
                                if (field == 'txtExpUnit') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Unit', 'error', 'topRight', true);
                                }
                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            //alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });


        function open_jobno() {

            var lic = document.getElementById("<%=txtLicense_No.ClientID %>").value;
            var exp = document.getElementById("<%=txt_Exp_Item_Slno.ClientID %>").value;
            var imp = document.getElementById("<%=txtItem_Slno.ClientID %>").value;

            NewWindow1('../Export_Report/Export_License_Utilization_Report.aspx?License_No=' + lic + '&ExpSlNo=' + exp + '&ImpSlNo=' + imp + '', 'List', '810', '1024', 'yes');

            return false
            
        }


    </script>
</body>
</html>
