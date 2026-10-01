<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consignee_Master.aspx.cs"
    Inherits="eRoyalMasters_Consignee_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Consignee Master | Updation</title>
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
                    CONSIGNEE MASTER
                    <div id="popupwindow_closebut_right">
                        <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_Consignee">

                    <%-- NAME with counter --%>
                    <div id="pop_text_area" style="width:360px;">
                        <div id="tag_label_adcode">Name</div>
                        <div id="txtcon-l_src"></div>
                        <div id="txtcon-m_src" style="width:220px;">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="210px"
                                CssClass="validate[required] txtbox_none" TabIndex="1"
                                Onkeypress="return numcharspl1(event);CheckCharCounter(this,'lblcnt',35);"
                                onpaste="return validatePaste(event);CheckCharCounter(this,'lblcnt',35);"
                                onkeyup="CheckCharCounter(this,'lblcnt',35)"
                                AutoPostBack="true" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src" style="width:20px;">
                            <asp:TextBox ID="lblcnt" BorderStyle="None" BackColor="White" Width="15px" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <%-- BRANCH SLNO --%>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">Branch SlNo</div>
                        <div id="txtcon-l_src"></div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtBranchSlNo" runat="server" MaxLength="100"
                                CssClass="txtbox_none" TabIndex="2"
                                Onkeypress="return numcharspl1(event)"
                                onpaste="return validatePaste(event);"
                                AutoPostBack="true" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src"></div>
                    </div>

                    <%-- ADDRESS 1 with counter --%>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">Address 1</div>
                        <div id="txtcon-l_src"></div>
                        <div id="txtcon-m_src" style="width:220px;">
                            <asp:TextBox ID="txtAdd1" runat="server"
                                CssClass="validate[required] txtbox_none"
                                MaxLength="100" TabIndex="3" Width="210px"
                                Onkeypress="return numcharspl1(event);CheckCharCounter(this,'lblcntAdd1',35);"
                                onpaste="return validatePaste(event);CheckCharCounter(this,'lblcntAdd1',35);"
                                onkeyup="CheckCharCounter(this,'lblcntAdd1',35)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src" style="width:20px;">
                            <asp:TextBox ID="lblcntAdd1" BorderStyle="None" BackColor="White" Width="15px" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <%-- ADDRESS 2 with counter --%>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">Address 2</div>
                        <div id="txtcon-l_src"></div>
                        <div id="txtcon-m_src" style="width:220px;">
                            <asp:TextBox ID="txtAdd2" runat="server"
                                MaxLength="100" CssClass="txtbox_none" TabIndex="3" Width="210px"
                                Onkeypress="return numcharspl1(event);CheckCharCounter(this,'lblcntAdd2',35);"
                                onpaste="return validatePaste(event);CheckCharCounter(this,'lblcntAdd2',35);"
                                onkeyup="CheckCharCounter(this,'lblcntAdd2',35)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src" style="width:20px;">
                            <asp:TextBox ID="lblcntAdd2" BorderStyle="None" BackColor="White" Width="15px" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <%-- ADDRESS 3 with counter --%>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">Address 3</div>
                        <div id="txtcon-l_src"></div>
                        <div id="txtcon-m_src" style="width:220px;">
                            <asp:TextBox ID="txtAdd3" runat="server"
                                MaxLength="100" CssClass="txtbox_none" TabIndex="4" Width="210px"
                                Onkeypress="return numcharspl1(event);CheckCharCounter(this,'lblcntAdd3',35);"
                                onpaste="return validatePaste(event);CheckCharCounter(this,'lblcntAdd3',35);"
                                onkeyup="CheckCharCounter(this,'lblcntAdd3',35)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src" style="width:20px;">
                            <asp:TextBox ID="lblcntAdd3" BorderStyle="None" BackColor="White" Width="15px" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <%-- ADDRESS 4 with counter --%>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">Address 4</div>
                        <div id="txtcon-l_src"></div>
                        <div id="txtcon-m_src" style="width:220px;">
                            <asp:TextBox ID="txtAdd4" runat="server"
                                MaxLength="100" CssClass="txtbox_none" TabIndex="5" Width="210px"
                                Onkeypress="return numcharspl1(event);CheckCharCounter(this,'lblcntAdd4',35);"
                                onpaste="return validatePaste(event);CheckCharCounter(this,'lblcntAdd4',35);"
                                onkeyup="CheckCharCounter(this,'lblcntAdd4',35)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src" style="width:20px;">
                            <asp:TextBox ID="lblcntAdd4" BorderStyle="None" BackColor="White" Width="15px" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <%-- COUNTRY NAME --%>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">Country Name</div>
                        <div id="txtcon-l_src"></div>
                        <div id="txtcon_mid_size">
                            <asp:TextBox ID="txtCountryName" runat="server" CssClass="validate[required] txtbox_none_mid_size"
                                Onkeypress="return char(event)" onpaste="return validatePaste(event);" MaxLength="35" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src"></div>
                        <div id="magnify_area">
                            <a href="#" onclick="opennewcountrycode(); return false" class="magnfy"></a>
                        </div>
                    </div>

                    <%-- COUNTRY CODE --%>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">Country Code</div>
                        <div id="txtcon-l_src"></div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txtCountryCode" runat="server" MaxLength="2" CssClass="validate[required] txtbox_none_suppmas1_Mediam"
                                Onkeypress="return char2(event)" TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src"></div>
                    </div>

                    <%-- PIN CODE --%>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">PIN code</div>
                        <div id="txtcon-l_src"></div>
                        <div id="txtcon_suppmas1_Mediam">
                            <asp:TextBox ID="txtPincode" runat="server" MaxLength="10" CssClass="validate[custom[integer]] txtbox_none_suppmas1_Mediam"
                                Onkeypress="return pin(event)" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src"></div>
                    </div>

                    <%-- REMARKS --%>
                    <div id="pop_max_text_area_supplier_master">
                        <div id="tag_label_Consigneename">Remarks</div>
                        <div id="max_txtarea">
                            <div id="txtcon-t_Maxtxt"></div>
                            <div id="txtcon-m_Maxtxt">
                                <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200"
                                    onkeyDown="return checkTextAreaMaxLength(this,event,'200');"
                                    onpaste="return checkTextAreaMaxLength(this,event,'200');"
                                    CssClass="txtbox_none_Maxtxt_Client" TextMode="MultiLine" TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="txtcon-b_Maxtxt"></div>
                        </div>
                        <div id="lblMsg2" style="display: none;"></div>
                    </div>

                </div>

                <%-- BUTTONS --%>
                <div id="innerbox_MidMain_top_adcode">
                    <div id="innerbox_adcode_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" CssClass="new"
                                OnClientClick="jQuery('#form1').validationEngine('hide')" TabIndex="13" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save"
                                OnClientClick="return validate_Consignee()" TabIndex="10" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                                OnClientClick="return validate_Consignee()" TabIndex="10" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete"
                                OnClientClick="jConfirm('Delete this Entry?', 'CONSIGNEE MASTER', function(r) {
                                    var i = r + 'ok';
                                    if(i == 'trueok') { document.getElementById('btn').click(); }
                                });return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="11" OnClick="btnDelete_Click" CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;" tabindex="12" id="btnCancel" />
                            <asp:HiddenField ID="hdn_Update_Consignee_Name" runat="server" />
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
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>

    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });

        $(function () {
            $("[id$='txtCountryName']").autocomplete({
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
                                jQuery('[id$="txtCountryName"]').validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);
                            } else {
                                jQuery('[id$="txtCountryName"]').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) { }
                    });
                },
                minLength: 1,
                select: function (event, ui) {
                    var selected = ui.item.value;
                    if (selected.indexOf("-") != -1) {
                        var parts = selected.split('-');
                        $('[id$="txtCountryName"]').val(parts[0]);
                        $('[id$="txtCountryCode"]').val(parts[1]);
                    }
                    return false;
                }
            });
        });

        $(document).ready(function () {
            $('[id$="txtCountryName"]').on('focus change keyup keydown', function () {
                country($(this).val());
            });
        });

        function country(val) {
            var codeBox = $('[id$="txtCountryCode"]');
            var nameBox = $('[id$="txtCountryName"]');
            if (val == '') {
                codeBox.val('');
                return;
            }
            if (val.indexOf("-") != -1) {
                var s = val.split('-');
                nameBox.val(s[0]);
                codeBox.val(s[1]);
            }
        }

        function CallMe(src, dest) {
            var ctrl = document.getElementById(src);
            PageMethods.GetCountry_code(ctrl.value, CallSuccess, CallFailed, dest);
        }
        function CallSuccess(res, destCtrl) {
            document.getElementById(destCtrl).value = res;
        }
        function CallFailed(res, destCtrl) {}

        function ValidateConsigneeName(event) {
            var regex = new RegExp("^[']");
            var key = String.fromCharCode(event.charCode ? event.which : event.charCode);
            if (regex.test(key)) {
                event.preventDefault();
                return false;
            }
        }

        function RefreshParent() {
            window.parent.location.reload();
        }

        // -------------------------------------------------------
        // UNIFIED CheckCharCounter works for Name AND Address 1-4
        // Parameters:
        //   textBox   : the input element itself
        //   counterId : client-side ID of the counter TextBox
        //   maxLength : the character limit to display in red
        // -------------------------------------------------------
        function CheckCharCounter(textBox, counterId, maxLength) {
            var currentLen = textBox.value.length;
            var counterEl = document.getElementById(counterId);
            if (!counterEl) return;

            counterEl.value = currentLen;

            if (currentLen <= maxLength) {
                textBox.style.color = "black";
                $(counterEl).attr('style', 'width:20px;border-style:none;background-color:white;color:black');
            } else {
                textBox.style.color = "red";
                $(counterEl).attr('style', 'width:20px;border-style:none;background-color:white;color:red');
            }
        }
    </script>
</body>
</html>
