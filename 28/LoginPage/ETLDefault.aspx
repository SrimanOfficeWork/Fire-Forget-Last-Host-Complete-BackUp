<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ETLDefault.aspx.cs" Inherits="LoginPage_DefaultNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <script src="../js/Validation.js" type="text/javascript"></script>
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
<body topmargin="0" id="bg1">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div id="log-pageout">
                <asp:Label ID="expiremsg" runat="server"></asp:Label></div>
            <asp:Button ID="btn_AlreadyLogin" runat="server" 
                class="loginButt" Style="display: none;" />
            <asp:HiddenField ID="hdn_result" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Branch" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Comp_License" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Renewal" runat="server" ClientIDMode="Static" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <asp:UpdatePanel ID="updateParent" runat="Server">
            <ContentTemplate>
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 450px; height: 129px;">
                    <div id="innerbox_MidMain_Transact_popup_new" style="width: 449px; height: 129px;">
                        <div id="tag_srcinner1_new">
                            <div id="editbu">
                                <a href="#" class="edit"></a>
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="text-align: center">
                                Login Alert</div>
                            
                        </div>
                       
                        <div id="tag_transaction_inner_new" style="margin-left: 20px; margin-top: 10px; width: 500px;">
                            <div id="tag_label_transaction_popup_IGM2_empty_gen">
                            </div>
                            <%--------------------------------------------------%>
                            <div id="tag_Exchange_lft_in1_new1" style="text-align: center; width: 420px;">
                                <asp:Label ID="lblRenewal" runat="server" ForeColor="Red"></asp:Label>
                                </br>
                                <asp:Label ID="lblContact" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            
                            
                            </div>
                            
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    </form>
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



        function Call_Branch_Name(src, dest) {
            var ctrl = document.getElementById(src).value;

            var ctrl1 = document.getElementById('expiremsg').innerHTML;

            if (ctrl != '') {


                ShowImage(src);
                PageMethods.BindDatatoDropdown(ctrl, CallSuccess, CallFailed, dest);

            }
            else {

            }
        }

        // set the destination textbox value with the ContactName
        function CallSuccess(data, destCtrl) {


            var dest = document.getElementById(destCtrl);
            dest.value = data;




        }
        // alert message on some failure
        function CallFailed(res, destCtrl) {

        }
        var win = null;
        function NewWindow(mypage, myname, w, h, scroll) {
            LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
            settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
            win = window.open(mypage, myname, settings);
            win.focus();

            return false;
        }
        function open_window() {
            //alert('l');
            NewWindow('E_royal_Impex_Main.aspx', 'index', '1000', '1000', 'yes');
            //OPen_ERoyalImpexMain_Popup();
        }
    </script>
</body>
</html>
