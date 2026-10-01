<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact_Details.aspx.cs"
    Inherits="eRoyalMasters_Adcode_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Details</title>
    <style type="text/css">
        #pop_text_Conduct
        {
            margin: auto;
            width: 360px;
            font-family: Arial, Helvetica, sans-serif;
            background-repeat: repeat-x;
            font-size: 12px;
            font-weight:normal;
            height: 14px;
            margin-top: 10px;
            text-align: left;
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
    <div id="innerbox_MidMain_popup_adcode" style="height: 200px;">
        <div id="innerbox_MidMain_top_adcode">
            Contact Us
            <div id="popupwindow_closebut_right">
                <input type="close" value="Submit" class="clsicon" onclick="win_hide();parent.adcodewindow.hide();return false;" />
            </div>
        </div>
        <div id="innerbox_MidMain_Mid_adcode" style="height: 200px;">
            <div id="pop_text_Conduct">
                No: 5/41, Balaji Nagar, 5th Cross Street,
            </div>
            <div id="pop_text_Conduct">
                Ekkatuthangal, Chennai-600032,</div>
            <%--<div id="pop_text_Conduct">
                
            </div>--%>
            <div id="pop_text_Conduct">
                Phone No : +91 98402 41678 / +91 93854 13685</div>
            <div id="pop_text_Conduct">
                E-Mail : admin@royaltechsystems.Co.in</div>
            <div id="pop_text_Conduct">
                Web : www.royaltechsystems.co.in
            </div>
            <div id="pop_text_Conduct">
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
    
</body>
</html>
