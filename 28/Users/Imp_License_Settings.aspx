<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_License_Settings.aspx.cs" Inherits="Users_Default_Settings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>License Scheme Settings</title>
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
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
           
            <div id="innerbox_MidMain_popup_adcode" style="height: 315px; width:450px;">
                <div id="innerbox_MidMain_top_adcode" style="width:450px;">
                    License Scheme Settings
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style="height: 240px;">
                    <div id="pop_text_area" style="width: 530px;">
                        <div id="tag_label_adcode">
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Clientname" style="width:110px">
                            DEEC
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                            <asp:CheckBox ID="chk_DEEC_DUTY" Text="Duty Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_DEEC_CIF" Text="CIF Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_DEEC_QTY" Text="Qty Based  " runat="server" Width="110px" />
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Clientname" style="width:110px">
                            EPCG
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                            <asp:CheckBox ID="chk_EPCG_DUTY" Text="Duty Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_EPCG_CIF" Text="CIF Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_EPCG_QTY" Text="Qty Based  " runat="server" Width="110px" />
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Clientname" style="width:110px">
                            MEIS
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                            <asp:CheckBox ID="chk_MEIS_DUTY" Text="Duty Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_MEIS_CIF" Text="CIF Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_MEIS_QTY" Text="Qty Based  " runat="server" Width="110px" />
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Clientname" style="width:110px">
                            SEIS
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                            <asp:CheckBox ID="chk_SEIS_DUTY" Text="Duty Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_SEIS_CIF" Text="CIF Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_SEIS_QTY" Text="Qty Based  " runat="server" Width="110px" />
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Clientname" style="width:110px">
                            SHIS
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                            <asp:CheckBox ID="chk_SHIS_DUTY" Text="Duty Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_SHIS_CIF" Text="CIF Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_SHIS_QTY" Text="Qty Based  " runat="server" Width="110px" />
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Clientname" style="width:110px">
                            FPS
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                            <asp:CheckBox ID="chk_FPS_DUTY" Text="Duty Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_FPS_CIF" Text="CIF Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_FPS_QTY" Text="Qty Based  " runat="server" Width="110px" />
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Clientname" style="width:110px">
                            FMS
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                            <asp:CheckBox ID="chk_FMS_DUTY" Text="Duty Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_FMS_CIF" Text="CIF Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_FMS_QTY" Text="Qty Based  " runat="server" Width="110px" />
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Clientname" style="width:110px">
                            ROSCTL</div>
                        <div id="m_transaction_pop_gen1_srcic_new_add_big">
                            <asp:CheckBox ID="chk_ROSCTL_DUTY" Text="Duty Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_ROSCTL_CIF" Text="CIF Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_ROSCTL_QTY" Text="Qty Based  " runat="server" Width="110px" />
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Clientname" style="width:110px">
                            DFIA</div>
                        <div id="m_transaction_pop_gen1_srcic_new_add_big">
                            <asp:CheckBox ID="chk_DFIA_DUTY" Text="Duty Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_DFIA_CIF" Text="CIF Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_DFIA_QTY" Text="Qty Based  " runat="server" Width="110px" />
                        </div>
                    </div>
                     <div id="tag_transac_lft_svb_relation_in1">
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Clientname" style="width:110px">
                            14-RESTRICTED</div>
                        <div id="m_transaction_pop_gen1_srcic_new_add_big">
                            <asp:CheckBox ID="chk_14_DUTY" Text="Duty Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_14_CIF" Text="CIF Based  " runat="server" Width="110px" />
                            <asp:CheckBox ID="chk_14_QTY" Text="Qty Based  " runat="server" Width="110px" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_top_adcode"> </div>
                <div id="innerbox_adcode_bot_inn">
                <div id="editbu" style="margin-left:120px;"></div>
                    <div id="editbu">
                        <asp:Button ID="btn_Change" runat="server" CssClass="autowidmovebut" Text="Change"
                            TabIndex="2" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            OnClick="btn_Change_Click" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="win_hide();parent.adcodewindow.hide();return false;"
                            tabindex="3" id="btnCancel" />
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

      

        } 

    </script>
</body>
</html>
