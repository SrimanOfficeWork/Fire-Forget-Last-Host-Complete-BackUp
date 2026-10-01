<%@ Page Language="C#" AutoEventWireup="true" CodeFile="General.aspx.cs" Inherits="Export_General" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
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
        
        .mand-tooltip
        {
            position: absolute;
            background: #2a7ab5;
            color: #fff;
            font-size: 11px;
            font-weight: 600;
            padding: 2px 7px;
            border-radius: 3px;
            z-index: 9999;
            white-space: nowrap;
            pointer-events: none;
            line-height: 16px;
            border: 2px solid #1a5a8a;
            outline: 1px solid #5aaee8;
        }
        .mand-tooltip:after
        {
            content: '';
            position: absolute;
            top: 100%;
            right: 8px;
            left: auto;
            border-width: 4px 4px 0;
            border-style: solid;
            border-color: #1a5a8a transparent transparent;
        }
        
        
        
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script type="text/javascript">
        function RefreshParent_1() {
            // window.parent used to always BE the search grid (Export_General_Search.aspx),
            // back when this popup was opened by that page calling its own local
            // Export_General_Update()/Export_General__New() (js/iframepopupwin.js) - reloading
            // window.parent (itself) was correct.
            //
            // Now that Export_General_Search.aspx opens this popup via window.parent.
            // Export_General_Update()/Export_General__New() instead (full-screen overlay in the
            // top-level E_royal_Impex_Main.aspx shell, not confined to the grid's own iframe box
            // - see that page's gvdetails_RowDataBound / New button), window.parent from THIS
            // page's perspective is Main.aspx itself. Reloading window.parent.location.href
            // unconditionally therefore reloads the ENTIRE shell (topbar, menu, everything) back
            // to its default dashboard view instead of just refreshing the grid underneath this
            // popup - same bug Transaction/General.aspx's RefreshParent_New() had, fixed the
            // same way here: refreshMainIframeWithClosePop() (E_royal_Impex_Main.aspx) reloads
            // ONLY the #mainiframecontainer iframe (the grid), and closeExistingPopup() closes
            // this popup explicitly since we're no longer relying on the parent's own navigation
            // to tear it down.
            if (window.parent && window.parent !== window && typeof window.parent.refreshMainIframeWithClosePop === 'function') {
                window.parent.refreshMainIframeWithClosePop();
                if (typeof window.parent.closeExistingPopup === 'function') window.parent.closeExistingPopup();
                return;
            }
            // Fallback - this popup opened the old way (window.parent IS the grid page), so
            // reloading it directly still works exactly as before.
            var data = window.parent.location.href;
            if (data.indexOf("#") != -1) {

                var s = data.split('#');
                var URl = s[0];
                window.parent.location.href = URl;
            }
            else {
                window.parent.location.href = data;
            }
        }
    </script>
    <script type="text/javascript">
        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <script type="text/javascript">
        function ShowModalPopup() {
            $('#txt_alt').val('');
            $find("EXP_MP_JOB").show();
            return false;
        }
        function HideModalPopup() {
            $('#txt_alt').val('');
            $find("EXP_MP_JOB").hide();
            return false;
        }
  
    </script>
    <script type="text/javascript">
        function Update_TypeOfExporter() {
            var exp_type = document.getElementById('hdn_Type_Of_Exporter');
            var gstn_type = document.getElementById('hdn_ddl_GSTNType');

            document.getElementById('ddlType_Exp').value = exp_type.value;
            document.getElementById('ddl_GSTN_Type').value = gstn_type.value;
        }
    </script>
    <%--<script type="text/javascript">
    $(document).ready(function () {
        $('#check_marks_nos').change(function () {
            if ($(this).is(":checked")) {
                var returnVal = 'WE INTEND TO CLAIM REWARDS UNDER MERCHANDISE EXPORTS FROM INDIA SCHEME (MEIS)';
                $('#txtMarksNos').val(returnVal);
            }
            else {
                $('#txtMarksNos').val('');
            }
        });
    });
</script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#check_marks_nos').change(function () {
                var hdn_Comp_License = $('#hdn_Comp_License');
                if ($(this).is(":checked")) {

                    if (hdn_Comp_License.val() == 'eri00164') {

                        var returnVal = 'WE INTEND TO CLAIM REWARD UNDER MERCHANDISE EXPORTS FROM INDIA SCHEME (MEIS).I/WE DECLARE THAT THE PARTICULARS GIVEN HEREIN ARE TRUE&ARE CORRECT,I/WE UNDERTAKE TO ABIDE BY PROVISIONS OF FOREIGN EXCHANGE MANAGEMENT ACT 1999,AS AMENDED FROM TIME TO TIME INCLUDING REALISATION/RESPATRIATION OF FOREIGNEXCHANGE TO/FROM INDIA.';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri00165') {

                        var returnVal = 'WE INTEND TO CLAIM REWARD UNDER MERCHANDISE EXPORTS FROM INDIA SCHEME (MEIS).I/WE DECLARE THAT THE PARTICULARS GIVEN HEREIN ARE TRUE&ARE CORRECT,I/WE UNDERTAKE TO ABIDE BY PROVISIONS OF FOREIGN EXCHANGE MANAGEMENT ACT 1999,AS AMENDED FROM TIME TO TIME INCLUDING REALISATION/RESPATRIATION OF FOREIGNEXCHANGE TO/FROM INDIA.';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri00116') {

                        var returnVal = 'THESE GOODS FORM PART OF PROJECT EXPORT – WE HEREBY DECLARE THAT WE DO NOT HAVE OBJECTION OT THE DRAWBACK BENEFIT BEING RESTIRICTED BASED ON 150% OF ARE1 VALUE OR FOB VALUE WHICHEVE IS LOWER. WE HEREBY DECLARE THAT WE SHALL CLAIM REWARDS UNDER MERCHANDISE EXPORTS FROM INDIA SCHEME (MEIS)';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri00517') {

                        var returnVal = 'CTN NO: ORDER NO: KIMBALL NO: ';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri00744') {

                        // var returnVal = 'LUT NO.AD3303200028160 DT. 01.04.2020 " We intend to claim Remission of Duties and Taxes on Exported Products (RoDTEP) "';
                        var returnVal = 'Supply meant for Export under Letter of Undertaking (LUT) without payment of IGST & Compensation Cess LUT Application Reference Number (ARN) AD330221009761O valid from 01.04.2021 to 31.03.2022. We intend to claim Remission of Duties and Taxes on Exported Products (RoDTEP) "';

                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri00880') {

                        var returnVal = 'WE INTEND TO CLAIM REWARDS UNDER RoDTEP i.e. (Remission of Duties or Taxes on Export Products Scheme)';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri01121') {

                        var returnVal = 'I/ WE UNDERTAKE TO ABIDE BY THE PROVISIONS INCLUDING CONDITIONS, RESTRICTIONS, EXCLUSIONS AND TIME-LIMITS AS PROVIDED UNDER RODTEP SCHEME AND RELEVANT NOTIFICATIONS, REGULATIONS, ETC., AS AMENDED FROM TIME TO TIME.ANY CLAIM MADE IN THIS SHIPPING BILL';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri01159') {

                        var returnVal = 'SUPPLY MEANT FOR EXPORT UNDER LETTER OF UNDERTAKING WITHOUT PAYMENT OF IGST.WE INTEND TO CLAIM REWARDS UNDER MERCHANDISE EXPORT FROM INDIA SCHEME (MEIS).';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri01242') {

                        var returnVal = 'AS PER INVOICE & PACKING LIST "I/WE IN REGARD TO MY/OUR CLAIM UNDER RODTEP SCHEME MADE IN THIS SHIPPING BILL OR BILL OF EXPORT"';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri01248') {

                        var returnVal = '"WE INTEND TO CLAIM REWARDS UNDER THE REMISSION OF DUTIES AND TAXES ON EXPORTED PRODUCTS (RODTEP) SCHEME"';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri01515') {

                        var returnVal = 'SUPPLY MEANT FOR EXPORT ON PAYMENT OF IGST "WE INTEND TO CLAIM REWARDS UNDER ROSCTL"';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri01519') {

                        var returnVal = 'AS PER INVOICE - WE INTEND TO CLAIM REMISSION OF DUTIES AND TAXES ON EXPORTED PRODUCTS (RODTEP) SCHEME. LUT ARN NO:AD330425000250Y"';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri01572') {

                        var returnVal = 'WE INTEND TO CLAIM REWARDS UNDER ROSCTL/RODTEP';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri01586') {

                        var returnVal = 'WE INTEND TO CLAIM REWARDS UNDER REMISSION OF DUTIES AND TAXES ON EXPORTED PRODECTS ( RODTEP) SCHEME, WE UNDERTAKE TO ABIDE THE DECLARATION FILED UNDER THE RODTEP SCHEME';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri01592') {

                        var returnVal = 'WE INTEND TO CLAIM REWARDS UNDER THE REMISSION OF DUTIES AND TAXES ON EXPORTED PRODUCTS (RoDTEP/RoSCTL) SCHEME';
                        $('#txtMarksNos').val(returnVal);
                    }
                    else if (hdn_Comp_License.val() == 'eri02918') {

                        var returnVal = 'WE INTEND TO CLAIM REWARD UNDER REMISSION OF DUTIES OR TAXES ON EXPORT PRODUCT SCHEME(RODTEP)';
                        $('#txtMarksNos').val(returnVal);
                    }

                    else {
                        var returnVal = 'WE INTEND TO CLAIM REWARDS UNDER MERCHANDISE EXPORTS FROM INDIA SCHEME';

                        if (hdn_Comp_License.val() == 'eri01135') {
                            if ($('#hdn_MarksNos_FEMA').val() != '') {
                                $('#txtMarksNos').val($('#hdn_MarksNos_FEMA').val() + returnVal);

                            }
                            else {
                                $('#txtMarksNos').val(returnVal);
                            }
                        }
                        else {
                            $('#txtMarksNos').val(returnVal);
                        }
                    }
                }
                else {

                    if (hdn_Comp_License.val() == 'eri01135') {
                        if ($('#hdn_MarksNos_FEMA').val() != '') {
                            $('#txtMarksNos').val($('#hdn_MarksNos_FEMA').val());
                        }
                        else {
                            $('#txtMarksNos').val('');
                        }
                    }
                    else {
                        $('#txtMarksNos').val('');
                    }
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#check_marks_nos_FEMA').change(function () {
                if ($(this).is(":checked")) {

                    var hdn_Comp_License = $('#hdn_Comp_License');

                    if (hdn_Comp_License.val() == 'eri01135' || hdn_Comp_License.val() == 'eri00010') {

                        var returnVal = 'I/WE UNDERTAKE TO ABIDE BY THE PROVISIONS OF FOREIGN EXCHANGE MANAGEMENT ACT, 1999, AS AMENDED FROM TIME TO TIME, INCLUDING REALISATION OR REPATRIATION OF FOREIGN EXCHANGE TO OR FROM INDIA.';
                        $('#txtMarksNos').val(returnVal);
                        $('#hdn_MarksNos_FEMA').val(returnVal);
                    }
                }
                else {
                    $('#txtMarksNos').val('');
                    $('#hdn_MarksNos_FEMA').val('');
                }
            });
        });
    </script>
    <script type="text/javascript">
        function handleDropdownChange() {
            var ddlSBType = document.getElementById('ddlSBType');
            var selectedText = ddlSBType.options[ddlSBType.selectedIndex].text;
            var lblImpExpType = document.getElementById('Lbl_Imp_Exp_Type');
            var ddl_Impexp_Type = document.getElementById('ddl_Impexp_Type');

            if (selectedText == "SEZ") {
                lblImpExpType.style.display = "block";
                ddl_Impexp_Type.style.display = "block";
            } else {
                lblImpExpType.style.display = "none";
                ddl_Impexp_Type.style.display = "none";
            }
        }
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
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Transact_popup_new" style="height: 110px">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        &nbsp;&nbsp;Transaction - Export
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 120px; padding-left: 400px;">
                        <span id="lblTrkSBNo" title="SB Status" runat="server" onclick="SB_Track();return false;"
                            style="color: Blue; text-decoration: underline; cursor: hand; font-size: smaller;">
                            Check SB Status</span>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <%--<input type="close" value="Submit" class="clsicon_new" onclick="parent.adcodewindow.hide();return false;" />--%>
                        <span id="F" visible="false" runat="server">
                            <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent_1();return false;"
                                CausesValidation="false" UseSubmitBehavior="false" />
                        </span><span id="S" visible="false" runat="server">
                            <input type="close" value="Submit" causesvalidation="false" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                        </span>
                    </div>
                    <%--<div id="mainmastop2container_lft_tag2_txt1" style="float:right;">
               <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide()" /></div>
                </div>--%>
                </div>
                <div id="tag_transaction_inner_new" style="margin-left: 10px">
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new" style="width: 220px; margin-left: 20px">
                            Job No
                            <asp:TextBox ID="txtjobPS" runat="server" Font-Bold="true" MaxLength="10" Font-Size="12px"
                                CssClass="txtbox_none_Mid_transac_code" Width="130px" ReadOnly="True" TabIndex="1"
                                ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty" style="margin-top: 4px;">
                            <asp:ImageButton ID="btnedit" runat="server" Visible="false" ImageUrl="~/images/icons/icon_edit.jpg"
                                Height="15px" Width="15px" OnClientClick="return ShowModalPopup();" ImageAlign="Middle" />
                        </div>
                        <div id="tag_label_transaction_date" style="width: 95px; text-align: center;">
                            Job Date
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtJobDate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                MaxLength="10" TabIndex="2"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <%-- <div id="txt-container_transaction_list_src2">--%>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 65px;">
                            Tr. Mode</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="listtxt_transac_mode_new"
                                TabIndex="3" AutoPostBack="true" OnSelectedIndexChanged="ddlTransportMode_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <%-- </div>--%>
                        <div id="tag_label_transaction_popup_no_empty" style="width: 37px; margin-left: 2px;">
                            <asp:ImageButton ID="btn_Tr_Mode_Change" ToolTip="Change Tr. Mode" Visible="false"
                               runat="server" ImageUrl="~/images/icons/icon_edit.jpg" Height="15px" Width="16px"
                               OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Exp_Change_Mode_Auto(); return false" />
                        </div>
                        <div id="tag_label_transaction_Src" style="width: 50px;">
                            SB No
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtSB_No" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                TabIndex="4" Enabled="false"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_Src">
                            SB Date
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtSB_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                TabIndex="5" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new" style="width: 55px; margin-left: 20px">
                            SB Type</div>
                        <div id="txtcon-m_transaction_code" style="width: 112px;">
                            <asp:DropDownList ID="ddlSBType" runat="server" CssClass="listtxt_transac_src1" Width="110px"
                                TabIndex="6" onchange="handleDropdownChange()">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtJobNo" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                BorderColor="White" Width="0px" MaxLength="10" ReadOnly="True" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_date">
                            Custom House</div>
                        <div id="txtcon-m_transaction_code" style="width: 80px;">
                            <asp:TextBox ID="txtCustomsHouse" runat="server" ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                onkeyup="ChangeCase(this);" onfocus="ChangeCase(this);" onblur="ChangeCase(this);"
                                Width="78px" onkeypress="return pin1(event)" MaxLength="10" TabIndex="7"></asp:TextBox>
                            <asp:HiddenField ID="hdn_CustomsHouse_Name" runat="server" ClientIDMode="Static" />
                        </div>
                        <div id="magnify_area">
                            <a href="#" class="magnfy" onclick="OpenPopupCustom_House(''); return false"></a>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_date">
                            Port of Loading</div>
                        <div id="txtcon-m_transaction_code" style="width: 80px;">
                            <asp:TextBox ID="txt_PortOfLoading" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"
                                onkeyup="ChangeCase(this);" onfocus="ChangeCase(this);" onblur="ChangeCase(this);"
                                Width="78px" onkeypress="return pin1(event)" MaxLength="10" TabIndex="7"></asp:TextBox>
                            <asp:HiddenField ID="hdn_PortOfLoading" runat="server" ClientIDMode="Static" />
                        </div>
                        <div id="magnify_area">
                            <%--<a href="#" class="magnfy" onclick="OpenPopupCustom_House(''); return false"></a>--%>
                            <a href="#" onclick="jQuery('#form1').validationEngine('hide');OpenPopupCustom_House_Details('Export_PortLoading_SEZ'); return false"
                                class="magnfy"></a>
                        </div>
                        <%--<div id="txt-container_transaction_list_src2">
                         </div>
                        <div id="tag_label_transaction_popup_no_empty_new" style="width: 118px;">
                        </div>--%>
                        <div id="tag_label_transaction_Src">
                            File Ref.No.
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 280px;">
                            <asp:TextBox ID="txtFile_Ref_no" runat="server" MaxLength="25" CssClass="txtbox_none_Mid_transac_code_new"
                                ClientIDMode="Static" TabIndex="8"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtJobNo"
                                FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                            </cc1:FilteredTextBoxExtender>
                            &nbsp; &nbsp;
                            <asp:TextBox ID="txt_FF_Jobno" Visible="false" placeholder="Fr. Jobno" Width="140px"
                                runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_code_new" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_Src" style="position: absolute; margin-top: 22px;
                            margin-left: 21px">
                            Freight Jobs
                        </div>
                        <div id="txtcon-m_Exchange" style="position: absolute; margin-top: 22px; margin-left: 94px">
                            <asp:DropDownList ID="ddlFreightJobs" runat="server" class="chosen-select-deselect"
                                Style="width: 370px; position: absolute;" data-placeholder="Choose a Freight Job"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlFreightJobs_SelectedIndexChanged"
                                TabIndex="8">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_Src" style="position: absolute; margin-top: 22px;
                            margin-left: 475px; width: 120px;">
                            <asp:Label ID="lbl_CHA_No" Text="IcegateID & CHA No" runat="server"></asp:Label>
                        </div>
                        <div id="txtcon-m_Exchange" style="position: absolute; margin-top: 22px; margin-left: 604px">
                            <asp:DropDownList ID="ddl_Multiple_CHA_No" runat="server" class="chosen-select-deselect"
                                Style="width: 295px; position: absolute;" data-placeholder="Icegate ID & CHA PAN No"
                                TabIndex="8">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new" style="height: 480px; width: 1110px;">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();"
                        id="General"><span>General</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                        id="INVOICE"><span>Invoice</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3();"
                        id="ITEM"><span>Item</span></a></li>
                    <%-- <li><a href="#page-8"  onclick="jQuery('#form1').validationEngine('hideAll');tab_page6('../Export/Export_AR4Details.aspx?jobno=',document.getElementById('txtJobNo').value,' &jobdate=',document.getElementById('txtJobDate').value,' &type=EXP')" 
                       id="AR4_Details"><span>AR4 Details</span></a></li>--%>
                    <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4();"
                        id="Annuxure"><span>Annuxure C1</span></a></li>
                    <%--<li><a href="#page-5" target="maineroyal" onclick="tab('0');"><span>Docket</span></a></li>--%>
                    <%--<li><a href="#page-6" target="maineroyal" onclick="tab('0');"><span>Tracking</span></a></li>--%>
                    <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../Report/Export_CheckList.aspx?jobno=',document.getElementById('txtJobNo').value);"
                        id="Checklist"><span>Checklist</span></a></li>
                    <%-- <li><a href="#page-6"  onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../FlatFile/Export_FlatFile_Generation.aspx?jobno=',document.getElementById('txtJobNo').value);" id="Submission" runat="server"><span>Submission</span></a></li>--%>
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../FlatFile/Export_FlatFile_Generation_SingleWindow.aspx?jobno=',document.getElementById('txtJobNo').value);"
                        id="Submission" runat="server"><span>Submission 2.1</span></a></li>
                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');tab_page6('../Job_History/Job_history.aspx?jobno=',document.getElementById('txtJobNo').value,' &jobdate=',document.getElementById('txtJobDate').value,' &type=EXP')"
                        id="Jobhistry"><span>Job History</span></a></li>
                    <li><a href="#page-9" visible="false" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../FlatFile/Exp_e_Way_Bill_Generation.aspx?jobno=',document.getElementById('txtJobNo').value);"
                        id="E_Way_Bill" runat="server"><span>e-Way Bill</span></a></li>
                    <div id="Exp_Billing_Others1" runat="server" visible="false">
                        <li><a href="#page-10" onclick="jQuery('#form1').validationEngine('hideAll');tab_page10();"
                            id="Exp_Billing_Others"><span>Billing-Others</span></a></li>
                    </div>
                    <div id="ETP" runat="server" visible="true">
                        <li><a href="#page-11" onclick="jQuery('#form1').validationEngine('hideAll');tab_page11();"
                            id="SEZ_Transshipment"><span>ETP</span></a></li>
                    </div>
                    <div id="DTA" runat="server" visible="false">
                        <li><a href="#page-12" onclick="jQuery('#form1').validationEngine('hideAll');tab_page12();"
                            id="DTA_SEZ"><span>DTA</span></a></li>
                    </div>
                    <div id="job_release" runat="server" visible="false">
                        <li><a href="#page-8" target="maineroyal" onclick="tab('0');"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></a></li>
                        <li>
                            <asp:Button ID="JobRelease" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                CausesValidation="false" Text="Job Release" OnClick="JobRelease_Click" />
                        </li>
                    </div>

                      <div id="JobLog_frame" runat="server" visible="true">
                        <li><a href="#page-15" id="JobLogs1" onclick="jQuery('#form1').validationEngine('hideAll');
                tab_page15(); return false;"><span>Job Logs</span> </a></li>
                    </div>

                   <%-- <li><a href="#page-15" id="JobLogs" onclick="jQuery('#form1').validationEngine('hideAll');
                tab_page15(); return false;"><span>Job Logs</span> </a></li>--%>

                  <div id="Acc_Charge" runat="server" visible="false">
                        <li><a href="#page-13" onclick="jQuery('#form1').validationEngine('hideAll');tab_page13();"
                            id="A1"><span>Charges</span></a></li>
                    </div>
                   

                    <div id="Acc_Charge_Sun" runat="server" visible="false">
                        <li><a href="#page-13" onclick="jQuery('#form1').validationEngine('hideAll');tab_page_sun();"
                            id="charge_acc_par"><span>Charges</span></a></li>
                    </div>
                    <div id="Acc_fin" runat="server" visible="false">
                        <li><a href="#page-14" onclick="jQuery('#form1').validationEngine('hideAll');tab_page14();"
                            id="finance_acc"><span>Financials</span></a></li>
                    </div>
                      <div id="Acc_Exp_Entity" runat="server" visible="false">
                        <li><a href="#page-16" onclick="jQuery('#form1').validationEngine('hideAll');tab_page16()"
                         id="AccExpEntity"><span>Entity</span></a> </li>
                    </div>
                </ol>
                <div class="content" id="page-1">
                    <div id="area_transac_container_genral">
                        <asp:Panel ID="Panel1" runat="server">
                            <div id="pop_text_area_transac_popup_inn_container_export">
                                <div id="pop_text_area_transac_popup_inn_container_left_export">
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            Exporter Name</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txtExporterName" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Font-Bold="true" ClientIDMode="Static" TabIndex="9"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <div id="ND" runat="server">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('Exporter'); return false">
                                                </a>
                                            </div>
                                            <div id="WD" runat="server">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Imp_Exp_Ryal_Job('EXPORTER_DETAILS'); return false">
                                                </a>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');opennewclientnew_master(document.getElementById('txtBranchNo').value,document.getElementById('txtExporterName').value,document.getElementById('txtIECNo').value,'Job'); return false" />
                                        <%--<asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');openclient_Masternew(); return false" />--%>
                                        <%-- <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');openclient_Masternew(); return false">
                                            New</a>--%>
                                      <%--  <asp:ImageButton ID="btn_Masedit" Height="26px" Width="30px" ToolTip="Client Edit"
                                            ImageUrl="~/images/icons/jobedit_master.png" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');opennewclientupdate_N_JobSearch(document.getElementById('txtBranchNo').value,document.getElementById('txtExporterName').value,document.getElementById('txtIECNo').value,'Job'); return false" />--%>
                                      <asp:ImageButton ID="btn_Masedit" Height="26px" Width="30px" ToolTip="Client Edit"
                                            ImageUrl="~/images/icons/jobedit_master.png" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');opennewclientnew_master(); return false" />
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            IEC No.
                                        </div>
                                        <div id="txtcon-m_transaction_code">
                                            <asp:TextBox ID="txtIECNo" runat="server" MaxLength="10" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"
                                                onkeypress="return pin(event)" TabIndex="10"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="divparty_ref" runat="server">
                                            <div id="tag_label_transaction_Src" style="text-align: center">
                                                Party Ref.No</div>
                                            <div id="txtcon-m_transaction_code" style="width: 163px;">
                                                <asp:TextBox ID="txtParty_RefNo" runat="server" MaxLength="25" CssClass="txtbox_none_Mid_transac_code"
                                                    Width="163px" ClientIDMode="Static" TabIndex="11"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="I_Code_WD" visible="false" runat="server">
                                            <div id="magnify_area">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Imp_Exp_I_Code_Job('EXPORTER_DETAILS'); return false">
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            Branch_SL_No</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 70px;">
                                            <asp:TextBox ID="txtBranchNo" runat="server" MaxLength="3" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                ClientIDMode="Static" onkeypress="return pin(event)" TabIndex="11" Width="70px"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                             <div id="dv_mas_brlso_popup" runat="server">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master_BranchSlno('Export_Branch');">
                                                </a>
                                              </div>
                                        </div>
                                        <div id="txtcon-r_src">
                                        </div>
                                        <div id="txtcon-r_src">
                                        </div>
                                        <%-- <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master_BranchSlno('Export_Branch');">
                                            </a>
                                        </div>--%>
                                        <div id="tag_label_transaction_popup_gen_export" style="width: 30px;">
                                            <asp:Label ID="Lbl_Imp_Exp_Type" runat="server" Text="Type" Style="display: none;"></asp:Label>
                                        </div>
                                        <div id="txtcon-m_src" style="width: 30px;">
                                            <asp:DropDownList ID="ddl_Impexp_Type" runat="server" TabIndex="2" Width="210px"
                                                CssClass="listtxt_transac_src1" Style="display: none;">
                                                <asp:ListItem Text="OTHERS" Value="OTHERS"></asp:ListItem>
                                                <asp:ListItem Text="PRIVATE" Value="PRIVATE"></asp:ListItem>
                                                <asp:ListItem Text="GOVERNMENT DEPARTMENTS" Value="GOVERNMENT DEPARTMENTS"></asp:ListItem>
                                                <asp:ListItem Text="GOVERNMENT UNDERTAKINGS" Value="GOVERNMENT UNDERTAKINGS"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            Address
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                            <asp:TextBox ID="txtAddress" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="12" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_no_empty">
                                        </div>
                                        <div id="txtcon-m_transaction_code">
                                            <asp:TextBox ID="txtAddress3" runat="server" MaxLength="35" ClientIDMode="Static"
                                                Width="145px" TabIndex="14" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 349px;">
                                            <%--<asp:TextBox ID="txtAddress4" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="15" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>--%>
                                            <asp:TextBox ID="txtAddress4" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="15" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                                            Pin
                                            <asp:TextBox ID="txtAddress5" runat="server" MaxLength="6" ClientIDMode="Static"
                                                TabIndex="16" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            GSTN Type
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 351px;">
                                            <asp:DropDownList ID="ddl_GSTN_Type" runat="server" CssClass="listtxt_transac_src1"
                                                ClientIDMode="Static" TabIndex="16" Width="190px" Font-Size="12px">
                                                <asp:ListItem Text="G/GSN  -GSTIN of Normal Persons Individual IEC" Value="GSN"></asp:ListItem>
                                                <asp:ListItem Text="O/GSG GSTIN of Govt.Entities" Value="GSG"></asp:ListItem>
                                                <asp:ListItem Text="D/GSD - GSTIN of Diplomats" Value="GSD"></asp:ListItem>
                                                <asp:ListItem Text="I/PAN PAN Number (AAAPL1234C)" Value="PAN"></asp:ListItem>
                                                <asp:ListItem Text="T/TAN TAN Number (AAAP12345C)" Value="TAN"></asp:ListItem>
                                                <asp:ListItem Text="P/PSP -Passport Number( Max 9 Characters-AN)" Value="PSP"></asp:ListItem>
                                                <asp:ListItem Text="A/ADH Aadhaar Number( 12 Numeric)" Value="ADH"></asp:ListItem>
                                            </asp:DropDownList>
                                            ID
                                            <asp:TextBox ID="txt_GSTN_ID" Width="127px" runat="server" MaxLength="20" ClientIDMode="Static"
                                                TabIndex="16" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            Type of Exporter
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                            <%-- <asp:TextBox ID="txtAddress5" runat="server" MaxLength="6" ClientIDMode="Static"
                                                TabIndex="16" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>--%>
                                            <%--Text="Manufacture"--%>
                                            <asp:DropDownList ID="ddlType_Exp" runat="server" CssClass="listtxt_transac_src1"
                                                ClientIDMode="Static" TabIndex="16" Width="190px">
                                                <asp:ListItem Text="Manufacturer - ( F )" Value="F"></asp:ListItem>
                                                <asp:ListItem Text="Merchant - ( R )" Value="R"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                        <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            Port Discharge
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtPortDischarge" runat="server" MaxLength="50" ClientIDMode="Static"
                                                onkeypress="return char(event)" TabIndex="17" onkeyup="ChangeCase(this);" onblur="ChangeCase(this);"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_CountrySearch_Master('Export_Port_origin'); return false">
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            Country Discharge
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtCountryDischarge" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                TabIndex="18" onkeyup="ChangeCase(this);" onblur="ChangeCase(this);" ClientIDMode="Static"
                                                onkeypress="return char(event)"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Export_Country_origin'); return false">
                                            </a>
                                        </div>
                                    </div>
                                  <%--  <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            Port Discharge
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtPortDischarge" runat="server" MaxLength="50" ClientIDMode="Static"
                                                onkeypress="return char(event)" TabIndex="18" onkeyup="ChangeCase(this);" onblur="ChangeCase(this);"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_CountrySearch_Master('Export_Port_origin'); return false">
                                            </a>
                                        </div>
                                    </div>--%>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            Country Final Destination</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtCountryFinalDestination" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                TabIndex="19" onkeyup="ChangeCase(this);" onblur="ChangeCase(this);" ClientIDMode="Static"
                                                onkeypress="return char(event)"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Export_Country_Shipment'); return false">
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            Port Final Destination
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtPortFinalDestination" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                TabIndex="20" onkeyup="ChangeCase(this);" onblur="ChangeCase(this);" ClientIDMode="Static"
                                                onkeypress="return char(event)"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_CountrySearch_Master('Export_Port_Ship'); return false">
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            State of Export
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtStateExport" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                TabIndex="21" onkeyup="ChangeCase(this);" onblur="ChangeCase(this);" MaxLength="50"
                                                ClientIDMode="Static" onkeypress="return char(event)"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');opennewStatecode('Export'); return false"
                                                class="magnfy"></a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export_marks">
                                        <div id="tag_label_transaction_popup_Item_maindet">
                                            Marks &amp; Nos
                                        </div>
                                        <div id="magnify_area" style="width: 18PX">
                                            <asp:CheckBox ID="check_marks_nos_FEMA" runat="server" Visible="false" />
                                        </div>
                                        <%-- <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>--%>
                                        <div id="magnify_area">
                                            <asp:CheckBox ID="check_marks_nos" runat="server" />
                                        </div>
                                        <div id="txtcon-m_46px_trans_export_marks">
                                            <asp:TextBox ID="txtMarksNos" TextMode="MultiLine" TabIndex="22" runat="server" CssClass="txtbox_none_Mid_transac_export_Marks_nos_gen"
                                                MaxLength="300" onkeyDown="return checkTextAreaMaxLength(this,event,'300');"
                                                onpaste="return checkTextAreaMaxLength(this,event,'300');"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div id="pop_text_area_transac_popup_inn_container_rght_new_export">
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            AD Code
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                                <asp:TextBox ID="txtAdcode" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                    onkeyup="ChangeCase(this);" onfocus="ChangeCase(this);" onblur="ChangeCase(this);"
                                                    MaxLength="14" onkeypress="return numchar(event)" TabIndex="23"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <div id="dv_mas_adcode_popup" runat="server">
                                                <a class="magnfy" href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupAdcode(document.getElementById('txtExporterName').value,document.getElementById('txtIECNo').value,'EXPORT'); return false">
                                                </a>
                                             </div>
                                        </div>
                                        <asp:Button ID="btn_Adcode_new" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');opennewadcodenew_Export(); return false" />
                                        <%-- <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');opennewadcodenew_Export(); return false">
                                            New</a>--%>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Bank Account
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3">
                                            <asp:TextBox ID="txtBankAccount" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                onkeypress="return pin(event)" TabIndex="24"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Drawback Account
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3">
                                            <asp:TextBox ID="txtDrawbackAccount" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                ClientIDMode="Static" TabIndex="25"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            IFSC Code
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3">
                                            <asp:TextBox ID="txt_IFSCCode" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                ClientIDMode="Static" MaxLength="20" TabIndex="25"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Consignee Name
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtConsigneeName" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                MaxLength="60" TabIndex="26"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <div id="dv_mas_consignee_popup" runat="server">
                                                <a class="magnfy" href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupConsignee('CONSIGNEE'); return false">
                                                </a>
                                            </div>
                                        </div>
                                        <%--<asp:Button ID="btn_Consigneenew1" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');opennewconsigneenew_Export(); return false" />--%>
                                        <asp:Button ID="btn_Consigneenew1" CssClass="autowidnewbut" Text="New" runat="server"
                                            OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Consignee_JOB_Edit(document.getElementById('txtConsigneeName').value,document.getElementById('txtConsignee_BranchSlNo').value,'Job'); return false" />
                                        <asp:ImageButton ID="btn_ConsigneeMasedit" Height="26px" Width="30px" ToolTip="Client Edit"
                                            ImageUrl="~/images/icons/jobedit_master.png" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Consignee_JOB_Edit(document.getElementById('txtConsigneeName').value,document.getElementById('txtConsignee_BranchSlNo').value,'Job'); return false" />
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Branch SlNo
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtConsignee_BranchSlNo" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                MaxLength="100" TabIndex="27"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                          <div id="dv_mas_consign_brsl_popup" runat="server">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupConsigneeBranchslno('Consignee_BranchSlNo',document.getElementById('txtConsigneeName').value);">
                                                </a>
                                           </div>
                                        </div>
                                        <asp:Label ID="lbl_consignee_cnt" runat="server" ForeColor="Red" ClientIDMode="Static"></asp:Label>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Address
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3">
                                            <asp:TextBox ID="txtConsigneeAddress" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                MaxLength="100" TabIndex="27"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3">
                                            <asp:TextBox ID="txtConsigneeAddress1" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                MaxLength="100" TabIndex="28"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3">
                                            <asp:TextBox ID="txtConsigneeAddress2" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                MaxLength="100" TabIndex="29"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3">
                                            <asp:TextBox ID="txtConsigneeAddress3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                MaxLength="100" TabIndex="30"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Country
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3">
                                            <asp:TextBox ID="txtConsigneeAddress4" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                MaxLength="50" TabIndex="31"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1new">
                                        <div id="tag_label_transaction_popup_gen2">
                                            NFEI ( Y / N )
                                        </div>
                                        <div id="txtcon-m_transaction_list1" style="width: 60px">
                                            <asp:DropDownList ID="ddlNFEI" runat="server" CssClass="listtxt_transac_src1" Width="55px"
                                                TabIndex="32">
                                                <asp:ListItem>No</asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div id="tag_label_transaction_popup_no_empty">
                                        </div>
                                        <div id="tag_label_transaction_popup_gen2" style="width: 38px">
                                            Type</div>
                                        <div id="txtcon-m_transaction_list1" style="width: 110px">
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="listtxt_transac_src1" Width="100px"
                                                TabIndex="33">
                                            </asp:DropDownList>
                                        </div>
                                        <%-- <div id="txtcon-m_transaction_list1new">
                                            <asp:Label ID="lblType" runat="server" CssClass="tag_label_transaction_Export_General"></asp:Label>
                                        </div>--%>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            RBI Waiver No
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3">
                                            <asp:TextBox ID="txtRBIWaiverNo" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                MaxLength="20" TabIndex="34"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            RBI Waiver Date
                                        </div>
                                        <div id="txtcon-m_transaction_code" style="width: 85px">
                                            <asp:TextBox ID="txtRBIWaiverDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                                TabIndex="35" Width="80px"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                                DisplayMoney="Left" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date"
                                                MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError" TargetControlID="txtRBIWaiverDate">
                                            </cc1:MaskedEditExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtRBIWaiverDate">
                                            </cc1:CalendarExtender>
                                        </div>
                                        <div id="tag_label_transaction_popup_no_empty">
                                        </div>
                                        <div id="tag_label_transaction_popup_gen2" style="width: 80px">
                                            <asp:Label ID="lbl_CartingPoint" runat="server" Text="Carting Point"></asp:Label>
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3" style="width: 85px">
                                            <asp:TextBox ID="txt_CartingPoint" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                MaxLength="20" TabIndex="34" Width="100px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <%--<div id="tag_transac_lft_in1">
                                        <div id="txtcon-m_transaction_code">
                                            <asp:Button ID="btn_Annexure" runat="server" Text="Annexure_C" CausesValidation="false"
                                                UseSubmitBehavior="false" 
                                                OnClientClick="jQuery('#form1').validationEngine('hideAll')" TabIndex="36" />
                                        </div>

                                         <div id="tag_label_transaction_popup_gen2" style="width:85px">
                                            <asp:Label ID="lbl_CartingPoint" runat="server" Text="Carting Point"></asp:Label>
                                        </div>
                                         <div id="txtcon-m_transaction_pop_gen3">
                                            <asp:TextBox ID="txt_CartingPoint" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                MaxLength="20" TabIndex="34" Width="150px"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                    <%--<div id="tag_transac_lft_in1"> 
                                    </div>--%>
                                    <div id="ELogix_Chennai" visible="false" runat="server">
                                        <div id="tag_transac_lft_in1">
                                            <div id="tag_label_transaction_popup_gen2">
                                                Refered Location
                                            </div>
                                            <div id="txtcon-m_transaction_item_maindet" style="width: 110px">
                                                <asp:TextBox ID="txt_Ref_Loc" runat="server" Enabled="false" CssClass="txtbox_none_Mid_transac_item_maindet"
                                                    ClientIDMode="Static" TabIndex="50" Width="100px"></asp:TextBox>
                                            </div>
                                            <div id="tag_label_transaction_Src" style="width: 90px">
                                                Refered Type</div>
                                            <div id="txtcon-m_transaction_item_maindet">
                                                <asp:DropDownList ID="ddl_Ref_Type" runat="server" Enabled="false" CssClass="listtxt_transac_mode_new"
                                                    TabIndex="50">
                                                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                                                    <asp:ListItem Text="M" Value="M"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="innerbox_MidMain_bot_transact" runat="server">
                                <div id="innerbox_transac_bot_inn" style="width: 990px">
                                    <div id="newbu">
                                        <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="40"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll')" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate1();"
                                            TabIndex="37" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                            TabIndex="38" OnClientClick="return validate1();" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnDelete" runat="server" TabIndex="39" CausesValidation="false"
                                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job?', 'GENERAL', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                        <asp:Button ID="btn" runat="server" TabIndex="36" OnClick="btnDelete_Click" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                        <asp:Button ID="btnAuto_Jobno" runat="server" TabIndex="51" OnClick="btnAuto_Jobno_Click"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnsavenext" Text="Save  & Next" TabIndex="37" CssClass="autowidupdatebut"
                                            OnClientClick="return validate1();" runat="server" OnClick="btnsavenext_Click" />
                                    </div>
                                    <div id="editbu">
                                        <%--<input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                                            tabindex="37" id="btn_cancel" />--%>
                                        <input type="submit" value="Submit" class="scancel" onclick="RefreshParent_1();return false;"
                                            tabindex="37" id="btn_cancel" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btngenexcel" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                            Visible="false" CssClass="autowidmovebut" Text="Excel Upload" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXPORT_JobWise_Excel_Upload('New');return false;" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btn_XML_Upload" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                            Visible="false" CssClass="autowidmovebut" Text="XML Upload" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXPORT_JobWise_XML_Upload('New'); return false;" />
                                    </div>
                                    <%-- <div id="editbu">
                                        <asp:Button ID="btn_Reliance_Upload" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                            Visible="false" CssClass="autowidmovebut" Text="Reliance-XML" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXPORT_JobWise_XML_Upload('New'); return false;" />
                                    </div>--%>
                                    <div id="editbu">
                                        <asp:Button ID="btn_Sahi_ExcelUpload" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                            Visible="false" CssClass="autowidmovebut" Text="SHAHI-Excel" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXPORT_SAHI_Export_ExcelUpload('New'); return false;" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnSignedBE" runat="server" Visible="false" CausesValidation="false"
                                            UseSubmitBehavior="false" CssClass="autowidmovebut" Text="FF Reader" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXPORT_SignedSB_Upload('New'); return false;" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btn_Reliance_XML" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                            Visible="false" CssClass="autowidmovebut" Text="Reliance-XML" Width="90px" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXPORT_JobWise_XML_Upload_RELIANCE('New'); return false;" />
                                    </div>
                                    <%--<div id="editbu" style="width: 81px;">
                                        <asp:Button ID="btnPDFUpload" runat="server" Width="80px" CausesValidation="false" Visible="false"
                                            UseSubmitBehavior="false" CssClass="autowidmovebut" Text="PDF Upload" OnClientClick="jQuery('#form1').validationEngine('hide');open_Exp_UPload_PDF('New');return false;" />
                                    </div>--%>
                                    <div id="editbu" style="width: 81px;">
                                        <asp:Button ID="btnPDFUpload_New" runat="server" Width="80px" CausesValidation="false"
                                            Visible="false" UseSubmitBehavior="false" CssClass="autowidmovebut" Text="PDF New"
                                            OnClientClick="jQuery('#form1').validationEngine('hide');open_Exp_UPload_PDF_New('New');return false;" />
                                    </div>
                                    <div id="editbu" style="width: 51px;">
                                        <asp:Button ID="btnPDFUpload_AI" runat="server" Width="50px" CausesValidation="false"
                                            Visible="false" UseSubmitBehavior="false" CssClass="autowidmovebut" Text="PDF-AI"
                                            OnClientClick="jQuery('#form1').validationEngine('hide');open_Exp_UPload_PDF_New_AI('New');return false;" />
                                    </div>
                                    <div id="editbu" style="width: 50px">
                                    </div>
                                    <div id="editbu">
                                        <%--<div id="txtcon-m_transaction_code">--%>
                                        <asp:Button ID="btn_Annexure" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                            CssClass="autowidmovebut" Text="Annexure_C" Width="90px" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                            TabIndex="36" />
                                        <%--<asp:Button ID="btn_Annexure" runat="server" Text="Annexure_C" CausesValidation="false"
                                                UseSubmitBehavior="false" 
                                                OnClientClick="jQuery('#form1').validationEngine('hideAll')" TabIndex="36" />--%>
                                    </div>
                                    <div id="tag_label_transaction_popup_no_empty">
                                    </div>
                                    <div id="div_AmendmentType" visible="false" runat="server">
                                        <div id="tag_label_transaction_popup_gen" style="width: 65px; font-weight: bold;">
                                            Amend Type
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width: 60px">
                                            <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                                Width="60px">
                                                <asp:ListItem Value=""></asp:ListItem>
                                                <asp:ListItem Value="A">Amendment</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <div class="content" id="page-2" style="display: none;">
                    <iframe src="" name="trans_igm" scrolling="no" id="Trans_export_invoice_Iframe">
                    </iframe>
                </div>
                <div class="content" id="page-3" style="display: none;">
                    <iframe src="" name="trans_igm" scrolling="no" id="Trans_export_item_Iframe" style="margin-top: -10px;
                        height: 800px;"></iframe>
                </div>
                <div class="content" id="page-4" style="display: none;">
                    <iframe src="" name="trans_igm" scrolling="no" id="Trans_igm_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-5" style="display: none;">
                </div>
                <div class="content" id="page-6" style="display: none;">
                </div>
                <div class="content" id="page-7" style="display: none;">
                </div>
                <div class="content" id="page-8" style="display: none;">
                </div>
                <div class="content" id="page-10" style="display: none;">
                    <iframe src="" name="trans_igm" scrolling="no" id="Trans_igm_Bill_Others_Iframe">
                    </iframe>
                </div>
                <div class="content" id="page-11" style="display: none;">
                    <iframe src="" name="trans_igm" width="1010px" height="420px" scrolling="no" id="Sez_Trans_Iframe">
                    </iframe>
                </div>
                <div class="content" id="page-12" style="display: none;">
                    <iframe src="" name="trans_igm" width="1010px" height="420px" scrolling="no" id="Sez_DTA_Iframe">
                    </iframe>
                </div>
                <div class="content" id="page-13" style="display: none; margin-left: -16px;">
                    <iframe src="" name="trans_igm" width="1010px" height="420px" scrolling="no" id="Iframe_Charge">
                    </iframe>
                </div>
                <div class="content" id="page-14" style="display: none; margin-left: -16px;">
                    <iframe src="" name="trans_igm" width="1010px" height="420px" scrolling="no" id="Iframe_finance">
                    </iframe>
                </div>
                 <div class="content" id="page-15" style="display: none; margin-left: -16px;">
                    <iframe src="" name="trans_igm" width="1010px" height="420px" scrolling="no" id="Exp_jobLogs_iframe">
                    </iframe>
                </div>
                <div class="content" id="page-16" style="display: none; margin-left: -16px;">
                        <iframe src="" name="trans_igm" width="1010px" height="420px" scrolling="no" id="Iframe_Exp_entity">
                        </iframe>
                    </div>
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                    <asp:HiddenField ID="hd_joblck" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdnCountryDischarge_chk" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdnPortDischarge_chk" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdnCountryFinalDestination_chk" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdnPortFinalDestination_chk" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdexp" runat="server" />
                    <asp:HiddenField ID="hd_Brslno" runat="server" />
                    <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" />
                    <asp:HiddenField ID="hdn_Comp_License" runat="server" />
                    <asp:HiddenField ID="hdprefix" runat="server" />
                    <asp:HiddenField ID="hdsuffix" runat="server" />
                    <asp:HiddenField ID="hdsaveandclose" runat="server" />
                    <asp:HiddenField ID="hdn_New_Update" runat="server" />
                    <asp:HiddenField ID="hdn_Consignee" runat="server" />
                    <asp:HiddenField ID="hdn_Consignee_brSlNo" runat="server" />
                    <asp:HiddenField ID="hdn_MarksNos_FEMA" runat="server" />
                    <asp:HiddenField ID="hdn_currentPage" runat="server" />
                    <asp:HiddenField ID="hdn_source" runat="server" />
                    <asp:HiddenField ID="hdn_Gen_Invoice_enable" runat="server" />
                    <asp:HiddenField ID="hdn_State_of_export_chk" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdn_CompanyID" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdn_FRT_GroupID" runat="server" />
                    <asp:HiddenField ID="hdn_FRT_Branch" runat="server" />
                    <asp:HiddenField ID="hdn_Customhouse_chk" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdn_PortOfLoading_chk" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdn_ExporterType" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdn_Type_Of_Exporter" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdn_ddl_GSTNType" runat="server" ClientIDMode="Static" />
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-10', 'page-11', 'page-12', 'page-13', 'page-14', 'page-15','page-16']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    <%-- ---------------------------------------------------------ModelpopUp---2------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="EXP_MP_JOB" runat="server" TargetControlID="HDU_JOB"
        PopupControlID="MessageDivupdated_Job" BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 450px; height: 129px;">
            <div id="innerbox_MidMain_Transact_popup_new" style="width: 449px; height: 129px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Job Edit
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <asp:Button ID="btnCl" runat="server" CssClass="clsicon_new" OnClientClick="return HideModalPopup()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div id="tag_transaction_inner_new" style="margin-left: 20px; margin-top: 10px; width: 500px;">
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_date" style="width: 75px; text-align: center;">
                            Edit Jobno
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 350px;">
                            <asp:TextBox ID="txt_M_jobps" placeholder="Prefix" Width="80px" runat="server" Onkeypress="return numcharspl1(event)"
                                MaxLength="10" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" autocomplete="off"></asp:TextBox>
                            <asp:TextBox ID="txt_E_jobno" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                autocomplete="off" onkeypress="return pin(event)"></asp:TextBox>
                            <asp:TextBox ID="txt_M_jobsf" runat="server" MaxLength="10" placeholder="Suffix"
                                Onkeypress="return numcharspl1(event)" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                Width="80px" autocomplete="off"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty" style="margin-left: 10px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_E_jobno"
                                ForeColor="Red" runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 30px;">
                        </div>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="txtcon-m_transaction_code" style="width: 300px;">
                            <span style="color: Red;">
                                <asp:Literal ID="txtid" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new" style="width: 30px;">
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 60px;">
                        </div>
                        <div id="tag_label_transaction_date" style="width: 75px; text-align: center;">
                            <asp:Button ID="btnok" runat="server" Text="Ok" UseSubmitBehavior="false" OnClick="btnok_Click" />
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClientClick="return HideModalPopup()"
                                CausesValidation="false" UseSubmitBehavior="false" />
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 30px;">
                        </div>
                        <div id="txtcon-m_transaction_mode" style="width: 60px;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--<div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 450px; height: 129px;">
            <div id="innerbox_MidMain_Transact_popup_new" style="width: 449px; height: 129px;">
               
               
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Export Job Edit
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <asp:Button ID="btnCl" runat="server" CssClass="clsicon_new" OnClientClick="return HideModalPopup()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                </div>


                <div id="tag_transaction_inner_new" style="margin-left: 20px; margin-top: 10px; width: 500px;">
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new" style="width: 30px;">
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 60px;">
                        </div>
                        <div id="tag_label_transaction_date" style="width: 75px; text-align: center;">
                            Edit Jobno
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txt_E_jobno" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                autocomplete="off" onkeypress="return pin(event)"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty" style="margin-left: 10px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_E_jobno"
                                ForeColor="Red" runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 30px;">
                            <asp:TextBox ID="txt_alt" runat="server" ForeColor="Red" BorderStyle="none" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new" style="width: 30px;">
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 60px;">
                        </div>
                        <div id="tag_label_transaction_date" style="width: 75px; text-align: center;">
                            <asp:Button ID="btnok" runat="server" Text="Ok" UseSubmitBehavior="false" OnClick="btnok_Click" />
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClientClick="return HideModalPopup()"
                                CausesValidation="false" UseSubmitBehavior="false" />
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 30px;">
                        </div>
                        <div id="txtcon-m_transaction_mode" style="width: 60px;">
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---2------------------------------------------------------------------------------%>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
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
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>
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
        function close_button() {
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtExporterName').focus(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtExporterName').change(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtExporterName').keyup(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtExporterName').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });

        function Item_desc(val) {

            var data = val;
            if (data == '') {
                $('#txtExporterName').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');
                var compid = document.getElementById("hdn_CompanyID").value;

                var before = s[0];
                var after = '';

                if (compid == '1' || compid == '2145') {
                    after = s[2];
                }
                else {
                    after = s[1];
                }

                $('#txtExporterName').val(after);

                $('#hdexp').val(after);
                $('#hd_Brslno').val(before);

            }
            else {

            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtConsigneeName').focus(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txtConsigneeName').focusout(function () {

                var data1 = $(this).val();
                Item_desc1(data1);


            });
            $('#txtConsigneeName').change(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txtConsigneeName').keyup(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txtConsigneeName').click(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });

            $('#txtConsigneeName').keydown(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
        });

        function Item_desc1(val) {
            $('#lbl_consignee_cnt').val('44r');
            var data1 = val;
            if (data1 == '') {
                $('#txtConsigneeName').val('');
            }
            if (data1.indexOf("--") != -1) {

                var s = data1.split('--');
                var before = s[0];
                var after = s[1];

                $('#txtConsigneeName').val(after);

                $('#hdn_Consignee').val(after);
                $('#hdn_Consignee_brSlNo').val(before);
            }
            else {
                $('#hdn_Consignee_brSlNo').val('');

            }

            if ($('#hdn_CompanyID').val() == '624') {
                var len = $('#txtConsigneeName').val();
                document.getElementById('lbl_consignee_cnt').innerHTML = len.length;
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            // document.onkeydown = click_TABS;
            document.onkeypress = click_TABS;
            document.onkeyup = click_TABS;

            function click_TABS(e) {
                //if (window.event);
                if (window.event.ctrlKey)
                    var keyCode = window.event.keyCode;       // IE
                else
                    var keyCode = e.which;

                var ctrl_n = document.getElementById("hdn_currentPage").value;

                if (e.ctrlKey) {
                    if (keyCode == 39) {
                        if (ctrl_n == 'General') {
                            document.getElementById('INVOICE').click();
                        }
                    }
                }
            }
        });
    </script>
    <script>
        $(function () {

            $("#General").click(function () {

                if (document.getElementById('hdn_Gen_Invoice_enable').value == 'Yes') {
                    document.getElementById('INVOICE').click();
                    document.getElementById('hdn_Gen_Invoice_enable').value = '';
                }

                //alert(document.getElementById("hdn_source").value);
                //------------------------------- Forward Pages - start ------------------------
                if (document.getElementById("hdn_source").value == 'Tab_Invoice') {
                    document.getElementById('ITEM').click();
                }
                if (document.getElementById("hdn_source").value == 'Tab_Item') {
                    document.getElementById('Annuxure').click();
                }

                if (document.getElementById("hdn_source").value == 'Tab_Annuxure') {
                    document.getElementById('Checklist').click();
                }

                if (document.getElementById("hdn_source").value == 'Tab_Checklist') {
                    document.getElementById('Submission').click();
                }
                if (document.getElementById("hdn_source").value == 'Tab_Submission') {
                    document.getElementById('Jobhistry').click();
                }

                //------------------------------- Backward Pages - start ------------------------

                if (document.getElementById("hdn_source").value == 'Tab_Invoice_Prev') {
                    document.getElementById('General').click();
                }

                if (document.getElementById("hdn_source").value == 'Tab_Item_Prev') {
                    document.getElementById('INVOICE').click();
                }
                if (document.getElementById("hdn_source").value == 'Tab_Annuxure_Prev') {
                    document.getElementById('ITEM').click();
                }

                if (document.getElementById("hdn_source").value == 'Tab_Checklist_Prev') {
                    document.getElementById('Annuxure').click();
                }
                if (document.getElementById("hdn_source").value == 'Tab_Submission_Prev') {
                    document.getElementById('Checklist').click();
                }

                //------------------------------- Backward Pages -end ------------------------
            });
        });
    </script>
    <script src="../js/Export_Jscript/Export_Jobedit.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/SB_Status.js" type="text/javascript"></script>
    <script type="text/javascript">

        function SB_Track() {
            var SbNo = document.getElementById("txtSB_No").value;
            var Date = document.getElementById("txtSB_Date").value;
            var Port = document.getElementById("txtCustomsHouse").value;
            var ddl = document.getElementById('ddlTransportMode');
            var mode = ddl.options[ddl.selectedIndex].value;

            var values = Date.split('/');

            var dd = values[0];
            var mm = values[1];
            var yy = values[2];

            var Sbdate = yy + '/' + mm + '/' + dd;
            if (mode == 'Air' || mode == 'Sea' || mode == 'Land') {
                SB_Status(SbNo, Sbdate, Port, mode);
            }
        }
        function open_Exp_Change_Mode_Auto() {

            var currentJobNo = '';

            var ctrl = document.getElementById('txtjobPS');
            if (ctrl != null && ctrl.value != '') {
                currentJobNo = ctrl.value;
            }

            if (currentJobNo == '') {
                var ctrl2 = document.getElementById('<%=txtJobNo.ClientID %>');
                if (ctrl2 != null && ctrl2.value != '') {
                    currentJobNo = ctrl2.value;
                }
            }

            var settings = 'width=940px,height=470px,center=1,resize=0,scrolling=0';

            adcodewindow = dhtmlmodal.open('Branch Change', 'iframe',
        '../Job_Duplicate/Exp_Branch_to_Branch.aspx?Jobno=E&SelectedJob=' +
        encodeURIComponent(currentJobNo) + '', '', settings);
        }

        function opennewclientnew_master() {
            var w = 1266;
            var h = 588;
            var LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            var TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
            settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=yes,resizable=no';
            window.open('../eRoyalMasters/Client_Master_New.aspx?Page=', 'Client Maaster', settings);
        }
    </script>
</body>
</html>
