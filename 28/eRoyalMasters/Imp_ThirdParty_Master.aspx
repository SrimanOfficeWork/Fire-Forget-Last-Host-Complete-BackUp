<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_ThirdParty_Master.aspx.cs"
    Inherits="Imp_ThirdParty_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Import Third Party Master | Updation</title>
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
        EnablePageMethods="true" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_supplier">
                <div id="innerbox_MidMain_top_adcode">
                    IMPORT THIRD PARTY MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_Consignee" style="height:320px">
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Third PartyName</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtName" runat="server"  onkeypress="return numcharspl1(event)" MaxLength="70"   CssClass="txtbox_none" TabIndex="1" AutoPostBack="True" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            &nbsp;Address 1
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtAdd1" runat="server" CssClass="txtbox_none" MaxLength="70" onkeypress="return numcharspl1(event)"
                                TabIndex="2"></asp:TextBox>
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
                            <asp:TextBox ID="txtAdd2" runat="server"  MaxLength="50" CssClass="txtbox_none" TabIndex="3"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            City</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtCity" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="4"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Country Subdivision</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_mid_size">
                        <asp:TextBox ID="txtctydivision" runat="server" CssClass="txtbox_none"
                                 MaxLength="35" TabIndex="5"></asp:TextBox>
                           <%-- <asp:TextBox ID="txtCountryName" runat="server" CssClass="validate[required] txtbox_none_mid_size"
                                Onkeypress="return char(event)" MaxLength="35" TabIndex="5"></asp:TextBox>--%>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                       <div id="magnify_area" style="display:none;">
                            <a href="#" onclick="opennewcountrycode(); return false" class="magnfy" tabindex="6">
                            </a>
                        </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Country Code
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txtCountryCode" runat="server" MaxLength="20" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Onkeypress="return char2(event)" TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Terms Place
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txttermsplace" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"  MaxLength="35" onkeypress="return numcharspl1(event)"
                                TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="Div5">
                        </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Third Party Pin
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txtpartypin" runat="server"  CssClass="txtbox_none_Mid_transac_Supp_Name" Onkeypress="return num1(event)"  MaxLength="10"
                                TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>


                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            AEO Code
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txtaeocode" runat="server"  CssClass="txtbox_none_Mid_transac_Supp_Name"  MaxLength="17"
                                 TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            AEO Country
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txtaeocountry" runat="server"  CssClass="txtbox_none_Mid_transac_Supp_Name"   MaxLength="20"
                              TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>


                  <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            AEO Role
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txtaeorole" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="3"
                               TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode" style="width:220px">
                            Whether Buyer & Seller are Related 
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon_suppmas1_Mediam"  style="width:80px">
                           <%-- <asp:TextBox ID="txtRelated_YN" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="3"
                               TabIndex="7"></asp:TextBox>--%>
                               <asp:DropDownList ID="ddl_Related_YN" runat="server" TabIndex="8"  CssClass="listtxt_transac_FCL" >
                               <asp:ListItem></asp:ListItem>
                               <asp:ListItem>Y</asp:ListItem>
                               <asp:ListItem>N</asp:ListItem>

                               </asp:DropDownList>
                        </div>

                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    
                    
                    
                </div>
                <div id="innerbox_MidMain_top_adcode">
                    <div id="innerbox_adcode_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                TabIndex="13" />
                        </div>
                        <div id="editbu">
                            <%--<asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" OnClientClick="return validate(event)" CssClass="save"  />--%>
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick=" return validate_Buyer()"
                                TabIndex="10" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                                OnClientClick="return validate_Buyer()" TabIndex="10" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'BUYER MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="11" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                tabindex="12" id="btnCancel" />
                            <asp:HiddenField ID="hdn_Update_BUYER_Name" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
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
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }

        $(function () {
            $("#txtCountryCode,#txtaeocountry").autocomplete({
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
                                jQuery('#txtCountryCode').validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);

                                //jAlert('Country Name is Incorrect', 'CONSIGNEE MASTER', function (r) { document.getElementById('txtCountryName').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtCountryCode').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
            $('#txtCountryCode').focus(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryCode').change(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryCode').keyup(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryCode').keydown(function () {

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
               
            }
            else {

            }
        }


        $(document).ready(function () {
            $('#txtaeocountry').focus(function () {

                var data = $(this).val();
                country_aeo(data);

            });
            $('#txtaeocountry').change(function () {

                var data = $(this).val();
                country_aeo(data);

            });
            $('#txtaeocountry').keyup(function () {

                var data = $(this).val();
                country_aeo(data);

            });
            $('#txtaeocountry').keydown(function () {

                var data = $(this).val();
                country_aeo(data);

            });
        });

        function country_aeo(val) {

            var data = val;
            if (data == '') {
                $('#txtaeocountry').val('');
            }
            //$('#hdn_Autosearch').val(data);

            if (data.indexOf("-") != -1) {

                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtaeocountry').val(after);

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
