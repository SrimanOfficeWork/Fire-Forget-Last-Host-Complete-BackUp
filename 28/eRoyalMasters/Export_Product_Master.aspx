<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Product_Master.aspx.cs" Inherits="eRoyalMasters_EXPORT_Product" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Master | Updation</title>
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
    <%--<script src="../js/Export_Jscript/Export_Product.js" type="text/javascript"></script>--%>
    <script src="../js/eRoyalmaster_Jscript/Export_Product.js" type="text/javascript"></script>
    <%--<script src="../js/Export_Jscript/Export_Item.js" type="text/javascript"></script>--%>
     


<script type="text/javascript">
    $(document).ready(function () {
        var aa = $('#ddlSTRYesNo').val();
        var xx = $('#Get_STR').val();
        if (aa == 'Yes') {
            $("#txtSTRCode").attr("disabled", false);
            $("#txtSTRCode").val(xx);
        }
        else {
            $("#txtSTRCode").attr("disabled", true);
        }
    });
</script>

    <script type="text/javascript">

        $(document).ready(function Calljs() {
            $('#ddlSTRYesNo').change(function () {
                var aa = $('#ddlSTRYesNo').val();
                var xx = $('#Get_STR').val();
                if (aa == 'Yes') {
                    $("#txtSTRCode").attr("disabled", false);
                    $("#str_lcd").show();
                    $("#txtSTRCode").val(xx);

                }
                else {
                    $("#txtSTRCode").attr("disabled", true);
                    $("#txtSTRCode").val('');
                    $("#str_lcd").hide();
                   
                }

            });
        });
      
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtDrawback_SLNo').keyup(function () {
                var RITC = $('#txtRITCNo').val();

                if (RITC != '') {
                    var aa = RITC.substring(0, 4);
                    $('#Hdn_RITC_4_digit').val(aa);                 
//                    alert(aa);
                }
            });
        });
    </script>

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
                   EXPORT PRODUCT MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>

                <div id="innerbox_MidMain_Mid_supplier" style="height:265px">
                     <div id="pop_text_area" style="margin-left:10px; height:30px;">
                            <div id="tag_label_adcode" style="width:100px">
                               RITC NO</div>
                            <div id="txtcon-l_src">
                            </div>
                            <div id="txtcon-m_src" style="width:105px">
                                <asp:TextBox ID="txtRITCNo" runat="server" MaxLength="8" 
                                    CssClass="validate[required] txtbox_none" Width="100px"
                                    TabIndex="1" onkeypress="return pin(event)" AutoPostBack="true" 
                                     ></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Export_Product_Ritc('Export_Product_RITCNO','Desc'); return false"
                                            class="magnfy"></a>
                            </div>
                        </div>

                    <div id="tag_transac_lft_in1_export_marks" style="width:400px;margin-left:10px; height:60px;">
                                        <div id="tag_label_transaction_popup_gen_export" style="width:100px">
                                           Description
                                        </div>
                                        <div id="txtcon-m_46px_trans_export_marks" style="width:290px;">
                                           <asp:TextBox ID="txtDesc" runat="server" MaxLength="200" onkeyDown="return checkTextAreaMaxLength(this,event,'200');"  Width="280px"
                                    onpaste="return checkTextAreaMaxLength(this,event,'200');" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1"  
                                    TextMode="MultiLine" TabIndex="2" Onkeypress="return numcharspl1(event)"></asp:TextBox>
                                        </div>
                                    </div>

                    <div id="pop_text_area" style="margin-left: 10px;">
                        <div id="tag_label_adcode" style="width: 100px">
                            Drawback SlNo
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src" style="width: 150px">
                            <asp:TextBox ID="txtDrawback_SLNo" runat="server" MaxLength="15" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="3" Width="150px" ClientIDMode="Static" Onkeypress="return numcharspl1(event)"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupDrawback('EXPORT_Product_DrawbackNo'); return false"
                                class="magnfy"></a>
                        </div>
                    </div>
                    <div id="pop_text_area" style="margin-left: 10px; height: 20px;">
                        <div id="tag_label_adcode" style="width: 100px">
                            Reward Y/N
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:DropDownList ID="ddlRewardYesNo" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                Width="80px" TabIndex="4">
                                <asp:ListItem>No</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                            </asp:DropDownList>
                            
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area" style="margin-left: 10px; height: 20px;">
                        <div id="tag_label_adcode" style="width: 100px">
                            STR Y/N
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                           
                            <asp:DropDownList ID="ddlSTRYesNo" runat="server" CssClass="listtxt_transac_exp_item_yn" 
                                Width="80px"  TabIndex="5" >
                                <asp:ListItem>No</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                            </asp:DropDownList>
                            
                        </div>
                        
                    </div>
                    <div id="pop_text_area" style="margin-left: 10px; height: 20px;">
                        <div id="tag_label_adcode" style="width: 100px">
                            STR Code
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src" style="width: 90px">
                            <asp:TextBox ID="txtSTRCode" runat="server" MaxLength="4" CssClass="txtbox_none"
                                TabIndex="6" onkeypress="return pin(event)" Width="80px"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" id="str_lcd" onclick="jQuery('#form1').validationEngine('hideAll');opennew_STR_DETAILS(); return false"
                                class="magnfy"></a>
                        </div>
                    </div>
                     <div id="pop_text_area" style="margin-left:10px; height:30px;">
                            <div id="tag_label_adcode" style="width:100px">
                               PART NO</div>
                            <div id="txtcon-l_src">
                            </div>
                            <div id="txtcon-m_src" style="width:105px">
                                <asp:TextBox ID="txtPARTNo" runat="server" MaxLength="50" 
                                    CssClass="validate[required] txtbox_none" Width="150px"
                                    TabIndex="1" onkeypress="return pin(event)" AutoPostBack="true" 
                                     ></asp:TextBox>
                            </div>
                        </div>
                    <%--<div id="txtcon-r_src">
                    </div>
                    <div id="txtcon-r_src">
                    </div>--%>
                </div>

                <div id="innerbox_MidMain_top_adcode">
                    <div id="innerbox_adcode_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                TabIndex="13" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick="return validate_Supplier(event)"
                                TabIndex="10" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                                OnClientClick="return validate_Supplier(event)" TabIndex="10" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'PRODUCT MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" TabIndex="11" />
                            <asp:Button ID="btn" runat="server" TabIndex="15" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <%--onclick="parent.adcodewindow.hide()"--%>
                            <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                                tabindex="12" id="btnCancel" />
                            <asp:HiddenField ID="hdn_Update_SupName" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="Hdn_RITC_4_digit" runat="server" />
                            <asp:HiddenField ID="Get_STR" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
           
           
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
     <script src="../js/Export_Jscript/Export_DrawBack.js" type="text/javascript"></script>
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
