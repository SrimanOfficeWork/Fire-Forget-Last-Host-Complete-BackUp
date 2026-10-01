<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_Settings.aspx.cs" Inherits="Users_Default_Settings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Supplier Settings</title>
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
           
            <div id="innerbox_MidMain_popup_adcode" style="height:165px;">
            
                <div id="innerbox_MidMain_top_adcode">
                     Supplier Settings
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style="height:130px;">
                  
    
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            </div>
                        <div id="txtcon-m_transaction_Supp_code">
                             
                        </div>
                    </div>
                   
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Manufacturer Name From Supplier</div>
                        <div id="txtcon-m_transaction_pop_gen1">
                       <asp:RadioButtonList ID="rdoDefault_Date" runat="server"     
                                        RepeatDirection="Horizontal"  TabIndex="17">
                                        <asp:ListItem Text="Yes" Value="Yes" ></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                     
                                    </asp:RadioButtonList>

                            
                           </div>
                    </div>
                   
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            </div>
                        <div id="txtcon_mid_size">
                       
                           </div>
                    </div>

                    
                
                </div>
                </div>
                 <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                  
                  
                    <div id="editbu">
                        <asp:Button ID="btn_Change" runat="server"
                     CssClass="autowidmovebut" Text="Change" TabIndex="2" UseSubmitBehavior="false" CausesValidation="false"
                      OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btn_Change_Click" />
                    </div>
                  
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="win_hide();parent.adcodewindow.hide();return false;"
                            tabindex="3" id="btnCancel" />
                      
                    </div>
                </div>
               
            </div>
           
           <%-- <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                  
                  
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server"  CssClass="updates"
                            OnClientClick="return Validation_pwd();" TabIndex="14" />
                    </div>
                  
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                            tabindex="16" id="btnCancel" />
                      
                    </div>
                </div>
            </div>--%>
             
         
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
