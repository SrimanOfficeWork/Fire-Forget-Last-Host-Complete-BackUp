<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exp_Branch_to_Branch.aspx.cs"
    Inherits="Exp_Branch_to_Branch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .hideGridColumn
        {
            display: none;
        }
        #tag_transac_lft_in2
        {
            height: 25px;
            margin: auto;
            width: 370px;
            margin-left: 10px;
        }
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <span id="Close" runat="server" visible="false">
        <div id="innerbox_MidMain_Trans_new" style="margin-left: 0px; height: 455px; margin-top: 0%;
            width: 934px;">
            <ol id="toc_new">
                <li style="margin-top: 5px;">Export Branch to Branch </li>
                <div id="popupwindow_closebut_right_new">
                    <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                </div>
            </ol>
            <%-- </div>--%>
    </span>
    <div class="content active" id="page-1" style="padding-top: 0px; height: 445px;">
        <div id="pop_text_area_transac_popup_inn_container_new" style="width: 900px;">
            <div id="pop_text_area_transac_popup_inn_container_left_new" style="width: 430px;">
                <div id="tag_transac_lft_in2">
                    <div id="tag_label_transaction_popup_gen">
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                    </div>
                </div>
                <div id="tag_transac_lft_in2" style="width: 750px;">
                    <div id="tag_label_transaction_popup_gen">
                        <span style="color: Green; font-weight: bold;">Job Process To </span>
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 400px;">
                        <asp:RadioButtonList ID="Rd_Convert" runat="server" RepeatDirection="Horizontal"
                            OnSelectedIndexChanged="Rd_Convert_SelectedIndexChanged" ForeColor="Red" AutoPostBack="true"
                            TabIndex="1">
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="tag_transac_lft_in2">
                    <div id="tag_label_transaction_popup_gen">
                        Working Period</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                        <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlWorkingPeriod_SelectedIndexChanged" TabIndex="3">
                        </asp:DropDownList>
                    </div>
                </div>
                <fieldset id="fld">
                    <span id="From_Grp" visible="false" runat="server">
                        <div id="tag_transac_lft_in2">
                            <div id="tag_label_transaction_popup_gen">
                                From Group
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:DropDownList ID="ddlFromGrp" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    TabIndex="4" OnSelectedIndexChanged="ddlFromGrp_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </span><legend style="border: Black; border-collapse: collapse; width: 70px; text-align: center;">
                        From Job </legend>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <span style="font-weight: bold;">
                                <asp:Literal ID="lblfromMsg" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                    <span id="From_Branch" visible="false" runat="server">
                        <div id="tag_transac_lft_in2">
                            <div id="tag_label_transaction_popup_gen">
                                From Branch
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:DropDownList ID="ddlFrom_Branch" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlFrom_Branch_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </span>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                            From Job No
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <asp:DropDownList ID="ddlJobNo" runat="server" class="validate[required] chosen-select-deselect"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged" Width="200px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                            Exporter Name
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 250px;">
                            <span style="color: Green; font-size: 12px;">
                                <asp:Literal ID="txtExporterName" runat="server"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                            Tr. Mode
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 250px;">
                            <span style="color: Green;">
                                <asp:Literal ID="txt_Tr_Mode" runat="server"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                            Customs House
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 250px;">
                            <span style="color: Green;">
                                <asp:Literal ID="txtCustoms_House" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                            Port Discharge
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 250px;">
                            <span style="color: Green;">
                                <asp:Literal ID="txt_OPortDischarge" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                            Port Final Des.
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 250px;">
                            <span style="color: Green;">
                                <asp:Literal ID="txt_OPortFinalDestination" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                            Job Date:
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <span style="color: Green;">
                                <asp:Literal ID="txtjobdate" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                            No of Invoice(s)
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <span style="color: Green;">
                                <asp:Literal ID="txtNoof_Inv" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                            No of Items(s)
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <span style="color: Green;">
                                <asp:Literal ID="txtnoofItems" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                </fieldset>
                <div id="tag_transac_lft_in2">
                    <div id="tag_label_transaction_popup_gen">
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                    </div>
                </div>
                <div id="tag_transac_lft_in2">
                    <div id="tag_label_transaction_popup_gen">
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                        <asp:Button ID="btnconvert" runat="server" Visible="false" TabIndex="7" OnClick="btnconvert_Click" />
                    </div>
                </div>
            </div>
            <div id="pop_text_area_transac_popup_inn_container_rght_new" style="width: 440px;">
                <div id="tag_transac_lft_in2">
                    <div id="tag_label_transaction_popup_gen">
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                        <span style="font-weight: bold;">
                            <asp:Literal ID="bltoMsg" runat="server"></asp:Literal></span>
                    </div>
                </div>
                <div id="tag_transac_lft_in2">
                    <div id="tag_label_transaction_popup_gen">
                        <span style="color: Green; font-weight: bold;"></span>
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                    </div>
                </div>
                <div id="tag_transac_lft_in2">
                    <div id="tag_label_transaction_popup_gen">
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                    </div>
                </div>
                <fieldset id="fld" style="width: 250px;">
                    <legend style="border: Black; border-collapse: collapse; width: 50px; text-align: center;">
                        To Job </legend>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                        </div>
                    </div>
                    <span id="To_Grp" visible="false" runat="server">
                        <div id="tag_transac_lft_in2">
                            <div id="tag_label_transaction_popup_gen">
                                To Group
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:DropDownList ID="ddlToGrp" runat="server" ForeColor="Blue" Font-Bold="true"
                                    CssClass="txtbox_none" TabIndex="6" AutoPostBack="true" OnSelectedIndexChanged="ddlToGrp_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </span>
                    <%----------------P1---------------------%>
                    <span id="Part_1" visible="false" runat="server">
                        <div id="tag_transac_lft_in2">
                            <div id="tag_label_transaction_popup_gen">
                                Branch
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:DropDownList ID="ddltoBranch" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddltoBranch_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </span>
                    <%----------------P2---------------------%>
                    <span id="Part_5" visible="false" runat="server">
                        <div id="tag_transac_lft_in2">
                            <div id="tag_label_transaction_popup_gen">
                                Tr. Mode
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <span style="color: Blue;">
                                    <asp:Literal ID="lbl_To_Tr_mode" runat="server"></asp:Literal></span>
                            </div>
                        </div>
                    </span>
                    <%----------------P3---------------------%>
                    <span id="Part_2" visible="false" runat="server">
                        <div id="tag_transac_lft_in2">
                            <div id="tag_label_transaction_popup_gen">
                                Job No</div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 250px;">
                                <asp:TextBox ID="txt_Prefix" placeholder="Prefix" Font-Size="12px" ReadOnly="true"
                                    runat="server" MaxLength="17" onkeyup="autotab(this);" Width="65px" CssClass="txtbox_none_CheckList"
                                    TabIndex="9" Enabled="false"></asp:TextBox>
                                /
                                <asp:TextBox ID="txtCurrent_Job" runat="server" Font-Size="12px" MaxLength="17" onkeyup="autotab(this);"
                                    Width="62px" Enabled="false" CssClass="validate[required] txtbox_none_Mid_transac_Inv_No"
                                    TabIndex="9"></asp:TextBox>/
                                <asp:TextBox ID="txt_Suffix" runat="server" ReadOnly="true" Font-Size="12px" MaxLength="17"
                                    onkeyup="autotab(this);" Width="65px" CssClass="txtbox_none_CheckList" placeholder="Suffix"
                                    Enabled="false" TabIndex="9"></asp:TextBox>
                            </div>
                        </div>
                    </span>
                    <%----------------P4---------------------%>
                    <span id="Part_3" visible="false" runat="server">
                        <div id="tag_transac_lft_in2">
                            <div id="tag_label_transaction_popup_gen">
                                Port Discharge</div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <%-- <asp:TextBox ID="txtPortDischarge" runat="server" MaxLength="50" ClientIDMode="Static"
                                                onkeypress="return char(event)" TabIndex="18" onkeyup="ChangeCase(this);" onblur="ChangeCase(this);"
                                                CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>--%>
                                <asp:TextBox ID="txtPortDischarge" runat="server" MaxLength="50" onkeypress="Port_origin(document.getElementById('txtPortOrigin').value);"
                                    onblur="ChangeCase(this);updateTextbox2();" onkeyup="ChangeCase(this);" onfocus="updateTextbox2();"
                                    onkeydown="Port_origin(document.getElementById('txtPortOrigin').value);" onchange="updateTextbox2();"
                                    CssClass="txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static" TabIndex="10"></asp:TextBox>
                            </div>
                        </div>
                    </span>
                    <%----------------P5---------------------%>
                    <span id="Part_4" visible="false" runat="server">
                        <div id="tag_transac_lft_in2">
                            <div id="tag_label_transaction_popup_gen">
                                Port Final Destination
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <%--  <asp:TextBox ID="txtPortFinalDestination" runat="server" MaxLength="50" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"
                                                TabIndex="20" onkeyup="ChangeCase(this);" onblur="ChangeCase(this);" ClientIDMode="Static"
                                                onkeypress="return char(event)"></asp:TextBox>--%>
                                <asp:TextBox ID="txtPortFinalDestination" runat="server" MaxLength="50" onkeypress="return char(event)"
                                    onblur="ChangeCase(this);" onkeyup="ChangeCase(this);" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                    ClientIDMode="Static" TabIndex="11"></asp:TextBox>
                            </div>
                        </div>
                    </span>
                    <%----------------P6---------------------%>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                        </div>
                    </div>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_transaction_popup_gen">
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <%--  <asp:Button ID="btnSave" runat="server" CssClass="save" onClientClick="Go_Product();return false;" TabIndex="37" />--%>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    </div>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2']);
    </script>

     <asp:HiddenField runat="server" ID="hdn_Server" />
    <asp:HiddenField ID="hdn_button_click" runat="server" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="HD_Tr_mode" ClientIDMode="Static" />
    <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="HD_DB_Name" runat="server" ClientIDMode="Static" />
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            //document.getElementById("btnCancel").click();
            document.getElementById("General").click();
        }

    </script>
    <script type="text/javascript">

        $(function () {
            $("#txtPortDischarge,#txtPortFinalDestination").autocomplete({

                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
                        data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdfTransport_mode").value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {

                            if (data.d == '') {
                                if (field == 'txtPortDischarge') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Discharge', 'error', 'topRight', true);

                                }
                                if (field == 'txtPortFinalDestination') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Final Destination', 'error', 'topRight', true);
                                }
                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                            response(data.d);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
    </script>
    <script type="text/javascript">
        function OpenPopupPort_Master(val) {

            if (document.getElementById('hdfTransport_mode').value != '') {

                OpenPopupPortDetails(val);
                return false
            }
        }


    </script>
       <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }
    </script>
</body>
</html>
