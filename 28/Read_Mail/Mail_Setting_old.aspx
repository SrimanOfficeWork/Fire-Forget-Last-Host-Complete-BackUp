<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mail_Setting_old.aspx.cs" Inherits="eRoyalMasters_Adcode_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADcode Master | Updation</title>
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
           
            <div id="innerbox_MidMain_popup_adcode">
                <div id="innerbox_MidMain_top_adcode">
                    MAIL SETTING
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode">
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Imap Server</div>
                        <div id="txtcon_mid_size">
                            <%--<asp:TextBox ID="txt_Imapserver" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_mid_size"
                                 TabIndex="1" MaxLength="40"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddl_Imapserver" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_InvNew"
                                 TabIndex="1" MaxLength="40">
                            </asp:DropDownList>
                        </div>
                        <%--<div id="magnify_area">
                            <a href="#" shape="poly" onclick="opennewieccode(); return false" class="magnfy"
                                tabindex="2"></a>
                        </div>--%>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            </div>
                        <div id="txtcon-m_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            User Name</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_username" runat="server" CssClass="validate[required] txtbox_none"
                                TabIndex="2"  MaxLength="40" 
                                ></asp:TextBox>
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            </div>
                        <div id="txtcon-m_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Password</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_pwd" runat="server" CssClass="txtbox_none" TabIndex="3"
                                MaxLength="40" ></asp:TextBox></div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            </div>
                        <div id="txtcon-m_src">
                            </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Folder Name</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_Folder" runat="server" CssClass="txtbox_none" TabIndex="4"
                                MaxLength="40"></asp:TextBox></div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            </div>
                        <div id="txtcon-m_src">
                            </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Port</div>
                        <div id="txtcon_mid_size">
                            <asp:TextBox ID="txt_port" runat="server" CssClass="txtbox_none_mid_size" TabIndex="5"
                                MaxLength="10" Onkeypress="return pin(event)" Text="993" Enabled="false"></asp:TextBox></div>
                        <div id="magnify_area">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            </div>
                        <div id="txtcon-m_src">
                            </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            </div>
                        <div id="txtcon-m_Maxtxt">
                        </div>
                    </div>
                    <div id="lblMsg2" style="display: none;">
                    </div>
                    <%--  <div id="pop_text_area">
             <div id="tag_label_adcode">
                 Remarks</div>
             <div id="txtcon-l_src">
             </div>
             <div id="txtcon-m_src">
                 <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtbox_none"></asp:TextBox>
                      </div>
             <div id="txtcon-r_src">
             </div>
         </div>--%>
                </div>
            </div>
            <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="17" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick=" return validate_mail();"
                            TabIndex="14" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            OnClientClick="return validate_mail();" TabIndex="14" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="15" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'MAIL SETTING', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="15" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="parent.adcodewindow.hide();win_hide();return false;"
                            tabindex="16" id="btnCancel" />
                        <asp:HiddenField ID="hdn_Update_Adcode" runat="server" />
                        <asp:HiddenField ID="hdn_check_adcode" runat="server" />
                        <asp:HiddenField ID="hdn_imapServer" runat="server" ClientIDMode="Static"/>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
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
        function hide1() {
            $(".dhtmlwindow").css("background-color", "");
            $(".dhtmlwindow").css("opacity", "");
            $(".dhtmlwindow").css("filter", "");
        }
        function validate_mail() {
            var ieccode;
            ieccode = document.getElementById("ddl_Imapserver").value;

            if (ieccode.length <= 0) {

                jAlert('Imap server Field cannot be blank', 'MAIL SETTING', function (r) { document.getElementById("ddl_Imapserver").focus(); });

                return false;
            }
            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
            var emailid = document.getElementById("txtEmail").value;
            var matchArray = emailid.match(emailPat);
            if (document.getElementById("txt_username").value != "") {
                if (matchArray == null) {

                    jAlert('Email id not valid', 'MAIL SETTING', function (r) { document.getElementById("txt_username").focus(); });


                    return false;
                }
            }
            var iecname;
            iecname = document.getElementById("txt_pwd").value;

            if (iecname.length <= 0) {
                jAlert('Password  cannot be blank', 'MAIL SETTING', function (r) { document.getElementById("txt_pwd").focus(); });

                return false;
            }


            var adcode;
            adcode = document.getElementById("txt_port").value;
            if (adcode.length <= 0) {

                jAlert('Port cannot be blank', 'MAIL SETTING', function (r) { document.getElementById("txt_port").focus(); });

                return false;

            }
            
        }
      
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }

        $(function () {
            $("#txtStateName").autocomplete({
                source: function (request, response) {
                    var errorField = $(this.element).attr('id');
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/BindDatatoDropdown_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {


                                jQuery('#txtStateName').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);
                                //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtStateName').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
        

        function Call_Client_Name(src, dest) {
            var ctrl = document.getElementById(src);
            // call server side method
            //alert('l');
            var ieccode = document.getElementById("txtIec_Code").value;
            //if (ieccode.length == 10) {
            PageMethods.GetClient_Name(ctrl.value, CallSuccess, CallFailed, dest);

            //}

        }

        // set the destination textbox value with the ContactName
        function CallSuccess(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            dest.value = res;
        }
        // alert message on some failure
        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }

        $(function () {

            var dropDownList1 = $('#ddl_Imapserver');

            dropDownList1.change(function (e) {
                var selectedValue = $(this).val();

                if (selectedValue != '') {

                                  
                    if (selectedValue == "Gmail") {

                        document.getElementById("hdn_imapServer").value = "imap.gmail.com";
                      

                    }
                    else if (selectedValue == "Yahoo") {
                        document.getElementById("hdn_imapServer").value = "imap.mail.yahoo.com";
                        

                    }
                    else if (selectedValue == "Sify") {
                        document.getElementById("hdn_imapServer").value = "imap.gmail.com";
                       

                    }
                    else if (selectedValue == "Webmail") {
                        document.getElementById("hdn_imapServer").value = "imap.mailhostbox.com";
                      
                    }
                }


            });
        });
    </script>
</body>
</html>
