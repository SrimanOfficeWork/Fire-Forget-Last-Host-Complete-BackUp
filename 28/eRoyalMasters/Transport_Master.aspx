<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Transport_Master.aspx.cs" Inherits="eRoyalMasters_Suppliermaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transport Master | Updation</title>
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
            <div id="innerbox_MidMain_popup_Transport">
                <div id="innerbox_MidMain_top_adcode">
                    TRANSPORT MASTER
                    <div id="popupwindow_closebut_right">
                       <%-- <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />--%>
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_supplier">
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Transport Name</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_transport_name" runat="server" MaxLength="50"  CssClass="validate[required] txtbox_none"
                                TabIndex="1"  AutoPostBack="true" OnTextChanged="txtName_TextChanged"></asp:TextBox>

                                <%--Onkeypress="return numcharspl1(event)"--%>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>

                       <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Transport Id  </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_transport_Id" runat="server" MaxLength="20" CssClass="txtbox_none" TabIndex="2"  ></asp:TextBox>
                                
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Mode
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_m_transaction_IGM_Airnamenew">
                                 <asp:RadioButtonList ID="Rd_Tr_Mode" runat="server"  
                                   RepeatDirection="Horizontal"    TabIndex="32"  >
                                    <asp:ListItem Text="Road" Value="Road" Selected="True" ></asp:ListItem>
                                    <asp:ListItem Text="Rail" Value="Rail"></asp:ListItem>
                                    <asp:ListItem Text="Air" Value="Air" ></asp:ListItem>
                                    <asp:ListItem Text="Ship" Value="Ship"></asp:ListItem>
                                    </asp:RadioButtonList>
                            </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Transport Doc.No
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_transport_doc_no" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="4" Onkeypress="return numcharsup_Add(event)"></asp:TextBox>
                           
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Vechile No
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_Vachile_No" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="5" Onkeypress="return numcharsup_Add(event)"></asp:TextBox>
                           
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Vechile Type
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_m_transaction_IGM_Airnamenew">
                              
                                     <asp:RadioButtonList ID="Rd_Vachile_Type" runat="server" RepeatDirection="Horizontal" TabIndex="37">
                                    <asp:ListItem Text="Regular" Value="Regular" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Over Dim. Cargo" Value="Over Dim.Cargo"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        <div id="txtcon-r_src">
                        </div>                       
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Transport Date</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txt_tr_Date" runat="server" MaxLength="2" Onkeypress="return char2(event);"
                                CssClass="validate[required] txtbox_none_suppmas1_Mediam" TabIndex="5"></asp:TextBox>                        
                                  <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_tr_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_tr_Date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>
                                </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            User GSTN Id</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txt_User_GSTN_Id" runat="server" MaxLength="50"  CssClass="txtbox_none"
                                TabIndex="6"  ClientIDMode="Static"></asp:TextBox>

                                <%--Onkeypress="return numcharspl1(event)"--%>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <%--div id="pop_text_area">
                        <div id="tag_label_adcode">
                            User GSTN Id</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">                           
                                <asp:TextBox ID="txt_User_GSTN_Id" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="5" Onkeypress="return numcharsup_Add(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txtcon-r_src">
                    </div>--%>
                    
                </div>
                <div id="innerbox_MidMain_top_adcode">
                    <div id="innerbox_adcode_bot_inn" style="height: 80px;width: 100%;" >
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                TabIndex="14" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick="return validate_Transport(event)"
                                TabIndex="11" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                                OnClientClick="return validate_Transport(event)" TabIndex="11" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'TRANSPORT MASTER', function(r) {
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
                            <asp:HiddenField ID="hdn_Update_TransName" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
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
            if (charCode > 32 && (charCode < 35 || charCode > 35) && (charCode < 44 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 38 || charCode > 38) && (charCode < 40 || charCode > 41))
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
</body>
</html>
