<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Non_standard_currecy_master.aspx.cs"
    Inherits="Non_standard_currecy_master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Non Standard Currency  Master | Updation</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
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
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_Exchange">
                <div id="innerbox_MidMain_top_adcode">
                    NON STANDARD CURRENCY MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="win_close();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_Exchange">
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Effective Date Import
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_Date">
                            <asp:TextBox ID="txtEx_Effect_dt_Imp" onkeyup="autotab(this);" runat="server" MaxLength="10"
                                CssClass="validate[required] txtbox_none_Date" TabIndex="1"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtEx_Effect_dt_Imp"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEx_Effect_dt_Imp"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                            <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"
                                runat="server" ControlToValidate="txtExchange_Date_From" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Effective Date Export
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_Date">
                            <asp:TextBox ID="txtEx_Effect_dt_Exp" runat="server" MaxLength="10" onkeyup="autotab(this);"
                                CssClass="validate[required] txtbox_none_Date" TabIndex="2"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtEx_Effect_dt_Exp"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEx_Effect_dt_Exp"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red"
                                runat="server" ControlToValidate="txtExchange_Date_To" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%></div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    
                    
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Exchange Currency Code
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_SmallCode">
                            <asp:TextBox ID="txtEx_Cur_Code" runat="server" MaxLength="3" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_SmallCode"
                                TabIndex="3" onkeypress="return char2(event)" onkeyup="ChangeCase(this);autotab(this);"
                                onfocus="ChangeCase(this);" onblur="ChangeCase(this);" AutoPostBack="True" 
                                OnTextChanged="txtEx_Cur_Code_TextChanged"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Exchange Name
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtEx_name" runat="server" MaxLength="30" onkeyup="ChangeCase(this);"
                                onfocus="ChangeCase(this);" onblur="ChangeCase(this);" CssClass="validate[required] txtbox_none_mid_size"
                                TabIndex="4" onkeypress="return numchar(event)"></asp:TextBox>                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Exchange Rate Import
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtEx_Rt_Imp" runat="server" MaxLength="15" onblur="extractNumber(this,6,false);"
                                onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                CssClass="validate[required,custom[number]] txtbox_none_mid_size" 
                                TabIndex="5"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Exchange Rate Export
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtEx_Rt_Exp" runat="server" MaxLength="15" CssClass="validate[required,custom[number]] txtbox_none_mid_size"
                                TabIndex="6" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                           Bank Name
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtEx_BankName" runat="server" MaxLength="35" CssClass="validate[required] txtbox_none_mid_size"
                                TabIndex="7" ></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                   <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Certificate No
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtEx_Certificate_no" runat="server" MaxLength="20" CssClass="validate[required] txtbox_none_mid_size"
                                TabIndex="8" onkeypress="return pin(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Certificate Date
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtEx_Certificate_Date" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_mid_size"
                                TabIndex="9" ></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtEx_Certificate_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEx_Certificate_Date"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>

                    
                </div>
                <div id="innerbox_MidMain_bot_Exchange">
                    <div id="innerbox_adcode_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                CssClass="new" OnClick="btnNew_Click" TabIndex="10" 
                                OnClientClick="jQuery('#form1').validationEngine('hide')" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate_NON_CURRENCY_MASTER();"
                                OnClick="btnSave_Click" TabIndex="11" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClientClick="return validate_NON_CURRENCY_MASTER()"
                                OnClick="btnUpdate_Click" TabIndex="11" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" OnClientClick="jConfirm('Delete this Entry?', 'NON CURRENCY MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" CssClass="dlete" TabIndex="12" />
                            <asp:Button ID="btn" runat="server" TabIndex="13" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="win_close();return false;"
                                tabindex="13" id="btnCancel" /></div>
                    </div>
                </div>
              
            </div>
                <asp:HiddenField ID="hdn_Update_Exchange" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
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
