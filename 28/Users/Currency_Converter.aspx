<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Currency_Converter.aspx.cs" Inherits="Users_Currency_Converter" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Currency Converter</title>
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
           
            <div id="innerbox_MidMain_popup_adcode" style="height:200px;">
            
                <div id="innerbox_MidMain_top_adcode">
                    Currency Converter
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style="height:200px;">
                  
          
            
                   
                    <%--<div id="pop_text_area">
                        
                      <div id="txtcon-m_src">
                            <asp:TextBox ID="txtold_pwd" runat="server" CssClass="validate[required] txtbox_none"
                                TabIndex="1"  MaxLength="40" TextMode="Password"
                                ></asp:TextBox>
                        </div>
                    </div>--%>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Convert Amount</div>
                        <div id="txtcon-m_transaction_Supp_code">
                             <asp:TextBox ID="txtConvert_Amount" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="2"  MaxLength="10" AutoPostBack="True" 
                                 ontextchanged="txtConvert_Amount_TextChanged" ></asp:TextBox>
                        </div>
                    </div>
                   
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            From Currency</div>
                        <div id="txtcon_mid_size">
                        <asp:DropDownList ID="ddlSelect_From_Currency" runat="server" 
                                onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_InvNew"
                                 TabIndex="3" MaxLength="40" AutoPostBack="True" 
                                onselectedindexchanged="ddlSelect_From_Currency_SelectedIndexChanged">
                            </asp:DropDownList>

                            <asp:Label ID="lblFrom_Rate" runat="server" Text=""></asp:Label>

                           </div>
                    </div>
                   
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            To Currency</div>
                        <div id="txtcon_mid_size">
                        <asp:DropDownList ID="ddlSelect_To_Currency" runat="server" 
                                onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_InvNew"
                                 TabIndex="3" MaxLength="40" AutoPostBack="True" 
                                onselectedindexchanged="ddlSelect_To_Currency_SelectedIndexChanged">
                            </asp:DropDownList>
                             <asp:Label ID="lblTo_Rate" runat="server" Text=""></asp:Label>
                           </div>
                    </div>

                     <div id="pop_text_area" style="text-align:center;" >
                         <asp:Label ID="lblConverted_Amount_Import" runat="server" Text=""></asp:Label>
                    </div>
                      <div id="pop_text_area" style="text-align:center;" >
                         <asp:Label ID="lblConverted_Amount_Export" runat="server" Text=""></asp:Label>
                    </div>
                
                </div>
                 <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                  
                  
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server"  CssClass="updates"
                             TabIndex="14" />
                    </div>
                  
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="win_hide();parent.adcodewindow.hide();return false;"
                            tabindex="16" id="btnCancel" />
                      
                    </div>
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
