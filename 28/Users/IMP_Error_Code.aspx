<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IMP_Error_Code.aspx.cs"
    Inherits="IMP_Error_Code" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Details</title>
    <style type="text/css">
        .txtbox_Multi {
            border: thin solid #c8c8c8;
            border-radius: 5px;
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 200px;
            margin-top: 2px;
            max-height: 140px;
            max-width: 750px;
            overflow: auto;
            width: 235px;
            margin-left:-20px;
        }
    </style>
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
    <div class="loading" align="center" id="load" style="display: none;">
        <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
    </div>
    <div id="innerbox_MidMain_popup_Product">
                <div id="innerbox_MidMain_top_Product">
                    Error code Check
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="pop_tabs_area1_prod_master">
                    <div id="pop_text_area_prod_master_lft">
                            <div id="tag_label_adcode">
                                Error Code
                            </div>
                            <div id="txtcon-m_Date">
                                <asp:TextBox ID="txtError_code" runat="server" ClientIDMode="Static" Onkeypress="return num1(event)" 
                                    MaxLength="15" CssClass="validate[required] txtbox_none_Date" TabIndex="2"></asp:TextBox>
                            </div>
                            <div id="tag_label_adcode">
                               
                            </div>
                        </div>


                        <div id="pop_text_area_prod_master_lft"></div>
                        
                          <div id="pop_tabs_menu_prod_master" style="height: 5px;"></div>
                    <div id="pop_max_text_area_prod_master_New">
                   


                        <div id="pop_max_text_area_prod_master">

                             <asp:TextBox ID="txtErr_Desc" Width="680px" oncopy="false" oncut="false" ReadOnly="true" onpaste="false" TextMode="MultiLine" ForeColor="Red" Font-Bold="true" runat="server" 
                             CssClass="txtbox_Multi" ></asp:TextBox>
                              
                            
                        </div>
                        
                    </div>
                </div>
            </div>
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
    <script src="../js/IMP_Error_Code.js" type="text/javascript"></script>
</body>
</html>
