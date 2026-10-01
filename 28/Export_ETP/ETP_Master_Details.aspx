<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ETP_Master_Details.aspx.cs"
    Inherits="ETP_Master_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ETP Master | Updation</title>
    <%--       <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />--%>
    <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }

    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            var icegateid = document.getElementById("hdn_ICEGATE_ID_List").value;
            //         var Notn = icegateid.split(',').map(String);
            var Notn = icegateid.split(', ').map(String);

            if (icegateid != '') {
                $('#txt_icegate_Id').autocomplete({
                    source: Notn,
                    minLength: 0,
                    scroll: true
                }).focus(function () {
                    $(this).autocomplete("search", "");
                });
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            // document.onkeydown = clickRadio;
            document.onkeypress = click_TABS;
            document.onkeyup = click_TABS;

            function click_TABS(e) {
                //if (window.event);
                if (window.event.ctrlKey)
                    var keyCode = window.event.keyCode;       // IE

                else
                    var keyCode = e.which;
                if (e.ctrlKey) {
                    if (keyCode == 39) {
                        document.getElementById("hdn_source").value = 'Tab_IGM';
                        document.getElementById('btnCancel').click();
                    }

                    if (keyCode == 37) {
                        document.getElementById("hdn_source").value = 'Tab_IGM_Prev';
                        document.getElementById('btnCancel').click();
                    }
                }
            }
        });
    </script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Trans_IGM">
                <ol id="toc">
                    <li style="height: 20px"><a href="#page-1" onclick="tab_page1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="IGM"><span>ETP Master </span></a></li>
                    <li style="height: 20px"><a href="#page-2" onclick="tab_page2('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="CONTAINER" runat="server"><span>Container</span></a></li>
                       <li style="height: 20px">
                    <asp:LinkButton ID="REPORT" runat="server"
                        OnClientClick="EXP_Bulk_ETP(); return false;">
                        <span>REPORT</span>
                    </asp:LinkButton>
</li>
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_exp_popup_inn_container_left_invoice" style="width: 920px;">
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 130px;">
                                Job Number <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 125px;">
                                <asp:DropDownList ID="ddl_Jobno" runat="server" Width="120px" CssClass="listtxt_transac_FCL"
                                    TabIndex="7">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                                Job Date <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txtJobDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="8"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px;">
                                SB No <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 100px;">
                                <asp:TextBox ID="txt_SbNo" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="9" MaxLength="7" Enabled="false"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 70px;">
                                SB Date <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 53px;">
                                <asp:TextBox ID="txt_SbDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="10" Enabled="false"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_SbDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_SbDate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        <%---------------------------------------Row 2------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 130px;">
                                Transshipment Date <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 125px;">
                                <asp:TextBox ID="txt_Transship_Date" runat="server" Width="115px" MaxLength="10"
                                    CssClass="validate[required] txtbox_none_Mid_transac_code" TabIndex="11"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Transship_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Transship_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 120px;">
                                Transshipment No
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_Transship_No" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="12" MaxLength="10"></asp:TextBox>
                            </div>
                            <%--<div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px;">
                                Port Discharge
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 100px;">
                                <asp:TextBox ID="txt_port_discharge" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="1" MaxLength="6"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 120px;">
                                Mode of Transport
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 53px;">
                                <asp:DropDownList ID="ddl_Tr_mode" runat="server" Width="120px" CssClass="listtxt_transac_FCL"
                                    TabIndex="7">
                                    <asp:ListItem Text="T-Truck" Value="T"></asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                        </div>
                        <%---------------------------------------Row 3------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 130px;">
                                Gateway Port <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 125px;">
                                <asp:TextBox ID="txt_gateway_port" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="13" MaxLength="6"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                                Port Discharge <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_port_discharge" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="17" MaxLength="6"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px;">
                                Mode of Transport <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 100px;">
                                <asp:DropDownList ID="ddl_Tr_mode" runat="server" Width="120px" CssClass="listtxt_transac_FCL"
                                    TabIndex="20">
                                    <asp:ListItem Text="T - Truck" Value="T"></asp:ListItem>
                                    <asp:ListItem Text="V - Vessel" Value="V"></asp:ListItem>
                                    <asp:ListItem Text="R - Railway" Value="R"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 120px;">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 53px;">
                                <%-- <asp:DropDownList ID="ddl_Tr_mode" runat="server" Width="120px" CssClass="listtxt_transac_FCL"
                                    TabIndex="7">
                                    <asp:ListItem Text="T-Truck" Value="T"></asp:ListItem>
                                </asp:DropDownList>--%>
                            </div>
                        </div>
                        <%---------------------------------------Row 3-II-----------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 130px;">
                                Carrier Code <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 125px;">
                                <asp:TextBox ID="txt_Carrier_Code" Width="115px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="21" MaxLength="10"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                                Carrier No. <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_Carrier_No" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="22" MaxLength="100"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px;">
                                Gross Weight <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 100px;">
                                <asp:TextBox ID="txt_Gross_Wgt" Width="100px" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_exp_invoice_addr"
                                    onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="23"
                                    MaxLength="10"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 120px;">
                                Total Pkg <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 53px;">
                                <asp:TextBox ID="txt_Total_Pkg" Width="100px" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_exp_invoice_addr"
                                    onkeypress="return pin(event)" TabIndex="24" MaxLength="8"></asp:TextBox>
                            </div>
                        </div>
                        <%---------------------------------------Row 4------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 130px;">
                                Nature of Cargo <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 125px;">
                                <asp:DropDownList ID="ddl_nature_of_cargo" runat="server" Width="115px" CssClass="listtxt_transac_FCL"
                                    TabIndex="25">
                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                    <asp:ListItem Text="P - Non Containerized Packages" Value="P"></asp:ListItem>
                                    <asp:ListItem Text="C - Containerd" Value="C"></asp:ListItem>
                                    <asp:ListItem Text="CP - Containerized Packages" Value="CP"></asp:ListItem>
                                    <asp:ListItem Text="DB - Try Bulk" Value="DB"></asp:ListItem>
                                    <asp:ListItem Text="B - Bulk" Value="B"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                                Bond Code <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_Bond_Code" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="26" MaxLength="2"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px;">
                                Bond No <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 100px;">
                                <asp:TextBox ID="txt_Bond_No" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="28" MaxLength="20"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 70px;">
                                Bond Date <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 53px;">
                                <asp:TextBox ID="txt_Bond_Date" runat="server" Width="100px" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="29"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_Bond_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_Bond_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        <%---------------------------------------Row 5------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 130px;">
                                Bond Site <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 125px;">
                                <asp:TextBox ID="txt_Bond_Site" Width="115px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="30" MaxLength="6"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                                Site ID <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_Site_Id" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="31" MaxLength="6"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px;">
                                AWB No.
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 100px;">
                                <asp:TextBox ID="txt_AWB_No" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="32" MaxLength="15"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 120px;">
                                Stuff Port <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 53px;">
                                <asp:TextBox ID="txt_Stuff_Port" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="34" MaxLength="6"></asp:TextBox>
                            </div>
                        </div>
                        <%---------------------------------------Row 6------------------------------------------%>
                        <div id="innerbox_MidMain_bot_transact" style="margin-top: 0px">
                            <div id="innerbox_transac_bot_inn" style="width: 900px;">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" TabIndex="37" Visible="false" CssClass="new"
                                        OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                        CausesValidation="false" UseSubmitBehavior="false" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" ValidationGroup="dt"
                                        OnClientClick="return validation();" TabIndex="35" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                                        OnClick="btnUpdate_Click" Visible="false" TabIndex="36" OnClientClick="return validation();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="38" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'IGM', function(r) {
                                          var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn').click();
                                          }
                                          else {
                                          }
                                         });return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="27" CausesValidation="false" UseSubmitBehavior="false"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                                        CssClass="dlete" Style="display: none;" />
                                </div>
                                <div id="editbu" style="width: 100px">
                                    <asp:Button ID="btn_Json" Visible="false" runat="server" Width="90px" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="autowidmovebut" Text="Generate Json" OnClick="btn_Json_Click" />
                                </div>
                                <div id="editbu" style="width: 105px">
                                    <asp:Button ID="btn_Flatfile" Visible="false" runat="server" Width="100px" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="autowidmovebut" Text="Generate Flatfile"
                                        OnClick="btn_Flatfile_Click" />
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty" style="width: 40px;">
                            </div>
                                <div id="tag_transac_lft_IGM_in1" style="width: 250px;">
                                    <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 85px;
                                        color: Blue;">
                                        Icegate Id
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 150px;">
                                        <asp:TextBox ID="txt_icegate_Id" runat="server" MaxLength="35" Width="145px" Font-Bold="true"
                                            ForeColor="Red" TabIndex="34" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="pop_text_area_transac_popup_inn_container_IGM_gateway_grid">
                            <div id="pop_text_area_transac_popup_inn_container_IGM_Container2_grid_gateway" runat="server"
                                style="overflow: auto; height: 105px; margin-top: 12px;">
                                <div id="tag_transac_lft_IGM_in1" style="width: 820px;">
                                    <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 80px;">
                                        ETP Json :-
                                    </div>
                                    <%--<div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 70px;">
                                <span style="color: Gray;">ETP </span>
                            </div>--%>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew" style="margin-top: 5px; width: 70px;">
                                        <asp:ImageButton ID="imgbtnFlatFile" runat="server" ImageUrl="~/images/icons/Json.jpg"
                                            Visible="False" TabIndex="41" Width="68px" Height="58px" OnClientClick="Print_open();Loading();" />
                                    </div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew" style="margin-top: 5px; width: 250px;">
                                        <asp:ImageButton ID="Image_txtFile" runat="server" ImageUrl="~/images/flatfile.jpeg"
                                            Width="50px" Height="40px" OnClientClick="Text_FF_Print_open();Loading();" Visible="False" />
                                        &nbsp;&nbsp; &nbsp;&nbsp;
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 400px; margin-top: 15px;">
                                        <span style="font-weight: bold; color: Green;">
                                            <asp:Literal ID="lblmsg" runat="server"></asp:Literal></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <iframe src="" name="trans_igm_container" style="width: 910px; height: 400px;" scrolling="no"
                        id="trans_ETP_Container_iframe"></iframe>
                </div>
            </div>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="hdn_ICEGATE_ID_List" runat="server" ClientIDMode="Static" />
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2']);
    </script>
    </form>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
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
    <script src="../js/Autotab.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_ETP.js" type="text/javascript"></script>
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


        function validateLimit(obj, divID, maxchar) {

            objDiv = get_object(divID);

            if (this.id) obj = this;

            var remaningChar = maxchar - trimEnter(obj.value).length;

            if (objDiv.id) {
                objDiv.innerHTML = remaningChar + "";
            }
            if (remaningChar <= 0) {
                obj.value = obj.value.substring(maxchar, 0);
                if (objDiv.id) {
                    objDiv.innerHTML = "0 ";
                }
                return false;
            }
            else
            { return true; }
        }
        function get_object(id) {
            var object = null;
            if (document.layers) {
                object = document.layers[id];
            } else if (document.all) {
                object = document.all[id];
            } else if (document.getElementById) {
                object = document.getElementById(id);
            }
            return object;
        }

        function trimEnter(dataStr) {
            return dataStr.replace(/(\r\n|\r|\n)/g, "");
        }

    </script>
    <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        var win = null;

        function Print_open() {
            win = window.open('../FlatFile/Open_FileDownload.aspx?Query=' + 'ETP_Json' + '', 'ndf');
            Loading_HideImage();
        }

        function Text_FF_Print_open() {
            win = window.open('../FlatFile/Open_FileDownload.aspx?Query=' + 'ETP_Text_FF' + '', 'ndf');
            Loading_HideImage();
        }

        function EXP_Bulk_ETP() {

            var jobno = document.getElementById("<%=ddl_Jobno.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../Export_ETP/Exp_ETP_Bulk.aspx?JOBNO=' + jobno + '&Day_cnt=' + '1' + +'', 'List', '1300', '1024', 'yes');
            }
            else {
                NewWindow1('../Export_ETP/Exp_ETP_Bulk.aspx?JOBNO=' + '' + '&Day_cnt=' + '1' + '', 'List', '1300', '1024', 'yes');
            }
        }
        
    </script>
</body>
</html>
