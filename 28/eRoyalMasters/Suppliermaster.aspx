<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Suppliermaster.aspx.cs" Inherits="eRoyalMasters_Suppliermaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supplier Master | Updation</title>
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

    <style type="text/css">
        .txtbox_none_Maxtxt_Suppliernew
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            min-height: 58px;
            max-height: 58px;
            margin-top: 1px;
            min-width: 245px;
            max-width: 245px;
            margin-left: 2px;
            border: #c8c8c8 solid thin;
            -moz-border-radius-topleft: 5px;
            -moz-border-radius-topright: 5px;
            -moz-border-radius-bottomleft: 5px;
            -moz-border-radius-bottomright: 5px;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -webkit-border-bottom-right-radius: 5px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            overflow: hidden;
        }
    </style>

</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        EnablePageMethods="true" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_supplier">
                <div id="innerbox_MidMain_top_adcode">
                    SUPPLIER MASTER

                     <%-- <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />--%>
                   <%-- <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
                    </div>--%>
                    <div id="popupwindow_closebut_right_new">
                    <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" />
                            </div>
                </div>
                <div id="innerbox_MidMain_Mid_supplier">
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Name</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="validate[required] txtbox_none"
                                TabIndex="1"  Onkeypress="return numcharsup_Add(event)" AutoPostBack="true" OnTextChanged="txtName_TextChanged" onpaste="return validatePaste(event);"></asp:TextBox>

                                <%--Onkeypress="return numcharspl1(event)" Onkeypress="return numcharsup_Add1(event)" --%>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>

                       <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Branch Slno. </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_branch_slno" runat="server" MaxLength="20" CssClass="txtbox_none" TabIndex="2" Onkeypress="return numcharsup_Add(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                                
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Address 1
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtAdd1" runat="server" MaxLength="35" CssClass="validate[required] txtbox_none"
                                TabIndex="3" Onkeypress="return numcharsup_Add(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Address 2
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtAdd2" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="4" Onkeypress="return numcharsup_Add(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                           
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Address 3
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtAdd3" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="5" Onkeypress="return numcharsup_Add(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                           
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Country Name
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_mid_size">
                            <asp:TextBox ID="txtCountryName" runat="server" CssClass="validate[required] txtbox_none_mid_size"
                                Onkeypress="return char(event)" onpaste="return validatePaste(event);" MaxLength="35" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="opennewcountrycode(); return false" class="magnfy" tabindex="7">
                            </a>
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Country Code</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txtCountryCode" runat="server" MaxLength="2" Onkeypress="return char2(event);"
                                CssClass="validate[required] txtbox_none_suppmas1_Mediam" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            PIN Code</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txtPincode" runat="server" MaxLength="6" Onkeypress="return pin(event)"
                                onkeyup="autotab(this);" CssClass="txtbox_none_suppmas1_Mediam" TabIndex="9"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txtcon-r_src">
                    </div>
                    <div id="pop_max_text_area_supplier_master" style="height:50px;">
                        <div id="tag_label_Consigneename">
                            Remarks</div>
                        <div id="max_txtarea">
                           <%-- <div id="txtcon-t_Maxtxt">
                            </div>--%>
                            <div id="txtcon-Mid_Maxtxt"style="height:50px;">
                                <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200" onkeyDown="return checkTextAreaMaxLength(this,event,'200');"
                                    onpaste="return checkTextAreaMaxLength(this,event,'200');" CssClass="txtbox_none_Maxtxt_Suppliernew"
                                    TextMode="MultiLine" TabIndex="10" Height="50px"></asp:TextBox>
                            </div>
                            <div id="txtcon-b_Maxtxt">
                            </div>
                        </div>
                        <div id="lblMsg2" style="display: none;">
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_top_adcode">
                    <div id="innerbox_adcode_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                TabIndex="14" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick="return validate_Supplier(event)"
                                TabIndex="11" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                                OnClientClick="return validate_Supplier(event)" TabIndex="11" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'SUPPLIER MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" TabIndex="12" />
                            <asp:Button ID="btn" runat="server" TabIndex="15" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <%--onclick="parent.adcodewindow.hide()"--%>
                            <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                                tabindex="13" id="btnCancel" />
                            <asp:HiddenField ID="hdn_Update_SupName" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                             <asp:HiddenField ID="hdn_id" runat="server" />
                        </div>
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

        function numcharsup_Add(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 32 && charCode !== 43 && (charCode < 35 || charCode > 35) &&(charCode < 44 || charCode > 57) &&(charCode < 65 || charCode > 90) &&(charCode < 97 || charCode > 122) &&(charCode < 38 || charCode > 38) &&(charCode < 40 || charCode > 41))
                return false;
            return true;
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
            $("#txtCountryName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Country_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                jQuery('#txtCountryName').validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);

                            }
                            else {
                                jQuery('#txtCountryName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


        $(document).ready(function () {
            $('#txtCountryName').focus(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryName').change(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryName').keyup(function () {

                var data = $(this).val();
                country(data);

            });
        });

        function country(val) {

            var data = val;
            if (data == '') {
                $('#txtCountryCode').val('');
            }
            //$('#hdn_Autosearch').val(data);

            if (data.indexOf("-") != -1) {


                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtCountryCode').val(after);
                $('#txtCountryName').val(before);

            }
            else {

            }
        }

        function CallMe(src, dest) {
            var ctrl = document.getElementById(src);
            // call server side method
            //alert('l');
            PageMethods.GetCountry_code(ctrl.value, CallSuccess, CallFailed, dest);

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

    </script>

     <script type="text/javascript">
         function RefreshParent() {
             window.parent.location.reload();
         }
    </script>

</body>
</html>
