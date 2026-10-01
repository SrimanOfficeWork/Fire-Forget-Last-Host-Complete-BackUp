
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inbox_search.aspx.cs" Inherits="Export_General" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection"
        type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
          
          
                <%--<div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="opencomposemsg(); return false;" /></div>
                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>--%>
               <%-- <div id="mainmastop2container_rght_tag2_txt1">
                    RTS Mail</div>
                  <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.inboxwindow.hide();return false;" />
                    </div>--%>
           
            
    
            <div id="innerbox_MidMain_Grid" style="margin:1px 0 20px 0px;">
                       <div id="mainmastop2container_rght_tag2_txt1">
                    RTS Mail</div>
                  <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_close();parent.adcodewindow.hide();return false;" />
                    </div>
         <div id="tag_srcinner1grid">
                   
                   
                        <div  style="float:left;width:130px;margin-top:15px;margin-left:-10px;">
                       
                       <a href="#" onclick="opencomposemsg();return false;" class="smenu" id="A1" >Compose</a>
                           <a href="../Internal_Mail/Inbox.aspx?mail=INBOX" class="smenu" id="Inbox_tab" target="trans_igm">Inbox</a>
                      
                            <a href="../Internal_Mail/Inbox.aspx?mail=SENT" class="smenu" id="Sent_tab" target="trans_igm">
                                Sent</a>
                      
                            <a href="../Internal_Mail/Inbox.aspx?mail=TRASH" class="smenu" id="Trash_tab" target="trans_igm">
                            <%-- <a href="../Internal_Mail/Inbox.aspx?mail=INBOX" class="smenu" id="Trash_tab" target="trans_igm">--%>
                                Trash</a>
                     
                       
                            <a href="../Internal_Mail/Inbox.aspx?mail=FOLDER" class="smenu" id="Personal_tab" target="trans_igm">Personal</a>

                            
                        
                   
               </div>
                        
                         
                       <div style="margin-top:15px;">
                    <iframe src="../Internal_Mail/Inbox.aspx?mail=INBOX" name="trans_igm" scrolling="no" width="840px" height="500px" style="margin-top:1px;">
                    </iframe>
                 
                </div>
                   
            </div>
               </div>
          
            
            <asp:HiddenField runat="server" ID="HiddenField1"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdn_Edit_TransportMode"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdfTransport_mode"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdn_Jobno"></asp:HiddenField>
               <asp:HiddenField runat="server" ID="hdn_BE_ID"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdn_PackType"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdn_WeightType"></asp:HiddenField>
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
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

        function compose(val,val1,val2) {
            
            w = '700';
            h = '500';
            LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
            TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
            settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
            compose_update = dhtmlmodal.open('adcode', 'iframe', '../Internal_Mail/Mail_Compose.aspx?inbox_id=' + val + '&ref_id=' + val1 + '&mail=' + val2 + '', '', settings)

        }
      
    </script>
</body>
</html>
