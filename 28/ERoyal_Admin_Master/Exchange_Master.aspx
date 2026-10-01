<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exchange_Master.aspx.cs"
    Inherits="eRoyalMasters_Exchange_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Master | Updation</title>
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


     <script type="text/javascript">
         function RefreshParent_1() {
             var data = window.parent.location.href;
             if (data.indexOf("#") != -1) {

                 var s = data.split('#');
                 var URl = s[0];
                 window.parent.location.href = URl;
             }
             else {
                 window.parent.location.href = data;
             }
         }
        </script>

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
                    EXCHANGE MASTER
                    <div id="popupwindow_closebut_right">
  
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />

                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_Exchange">
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Exchange Date From
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_Date">
                            <asp:TextBox ID="txtExchange_Date_From" onkeyup="autotab(this);" runat="server" MaxLength="8"
                                CssClass="validate[required] txtbox_none_Date" TabIndex="1"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtExchange_Date_From"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExchange_Date_From"
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
                            Exchange Date To
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_Date">
                            <asp:TextBox ID="txtExchange_Date_To" runat="server" MaxLength="8" onkeyup="autotab(this);"
                                CssClass="validate[required] txtbox_none_Date" TabIndex="2"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtExchange_Date_To"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtExchange_Date_To"
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
                            Exchange NOTN No
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_No">
                            <asp:TextBox ID="txtExchange_NONT_NO" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_SmallNo"
                                TabIndex="3" ></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Exchange NOTN Date</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_No">
                            <asp:TextBox ID="txtExchange_NONT_Date" runat="server" MaxLength="8" CssClass="validate[required] txtbox_none_SmallNo"
                                TabIndex="4"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtExchange_NONT_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtExchange_NONT_Date"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red"
                                runat="server" ControlToValidate="txtExchange_NONT_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
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
                            <asp:TextBox ID="txtExchange_Cur_Code" runat="server" MaxLength="3" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_SmallCode"
                                TabIndex="5" onkeypress="return char2(event)" onkeyup="ChangeCase(this);autotab(this);"
                                onfocus="ChangeCase(this);" onblur="ChangeCase(this);" AutoPostBack="True" OnTextChanged="txtExchange_Cur_Code_TextChanged"></asp:TextBox>
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
                            <asp:TextBox ID="txtExchange_Name" runat="server" MaxLength="30" onkeyup="ChangeCase(this);"
                                onfocus="ChangeCase(this);" onblur="ChangeCase(this);" CssClass="validate[required] txtbox_none_mid_size"
                                TabIndex="6" onkeypress="return numchar(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Exchange Per Unit
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtExchange_Per_Unit" runat="server" MaxLength="3" CssClass="validate[required,custom[integer]] txtbox_none_SmallCode"
                                TabIndex="7" onkeypress="return pin(event)"></asp:TextBox>
                        </div>
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
                            <asp:TextBox ID="txtExchange_Rate_Import" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                CssClass="validate[required,custom[number]] txtbox_none_mid_size" TabIndex="8"></asp:TextBox>
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
                            <asp:TextBox ID="txtExchange_Rate_Export" runat="server" MaxLength="10" CssClass="validate[required,custom[number]] txtbox_none_mid_size"
                                TabIndex="9" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Exchange">
                            Exchange ( Y/N )
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_yesno">
                            <asp:DropDownList ID="ddlExchange" runat="server" CssClass="listtxt_YN" TabIndex="10">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdn_Update_Exchange" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_bot_Exchange">
                    <div id="innerbox_adcode_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                CssClass="new" OnClick="btnNew_Click" TabIndex="15" OnClientClick="jQuery('#form1').validationEngine('hide')" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate_Exchange();"
                                OnClick="btnSave_Click" TabIndex="11" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClientClick="return validate_Exchange(event)"
                                OnClick="btnUpdate_Click" TabIndex="12" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" OnClientClick="jConfirm('Delete this Entry?', 'EXCHANGE MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" CssClass="dlete" TabIndex="13" />
                            <asp:Button ID="btn" runat="server" TabIndex="13" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                                tabindex="14" id="btnCancel" /></div>
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
