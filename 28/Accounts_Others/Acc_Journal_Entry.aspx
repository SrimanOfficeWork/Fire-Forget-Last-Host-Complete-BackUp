<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Journal_Entry.aspx.cs"
    Inherits="Acc_Journal_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Journal Entry</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 13.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 40em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
    <style type="text/css">
        .CalendarStyle
        {
            background-color: Crimson;
            color: White;
            border: solid 2px DarkRed;
        }
        .ajax__calendar_header
        {
            background-color: #FBB117;
            color: black;
        }
        .ajax__calendar_footer
        {
            background-color: #FBB117;
            color: black;
        }
    </style>
    <style type="text/css">
        .jv-grid-wrapper
        {
            width: 100%;
            height: 280px;
            overflow-y: auto;
            overflow-x: auto;
            border: 2px solid #a0b4c8;
            border-radius: 3px;
            margin-top: 4px;
        }
        
        .jv-grid-wrapper .grid-view
        {
            width: 100%;
            border-collapse: collapse;
            table-layout: fixed;
        }
        
        /* Sticky header */
        .jv-grid-wrapper .grid-view th
        {
            position: sticky;
            top: 0;
            z-index: 10;
            background-color: #b8d0e8;
            color: #1a1a1a;
            font-family: Arial, sans-serif;
            font-size: 11px;
            font-weight: bold;
            text-align: center;
            padding: 5px 4px;
            border: 1px solid #8aafc8;
            white-space: normal;
            word-wrap: break-word;
        }
        
        .jv-grid-wrapper .grid-view td
        {
            font-family: Arial, sans-serif;
            font-size: 11px;
            color: #222;
            padding: 3px 5px;
            border: 1px solid #d0dce8;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
            cursor: pointer;
        }
        
        
        .jv-grid-wrapper .grid-view tr.selected-row td
        {
            background-color: #fff3b0 !important;
            font-weight: bold;
        }
        
        .jv-grid-wrapper .grid-view tr:hover td
        {
            background-color: #e8f0fb;
        }
        
        .jv-total-bar
        {
            width: 100%;
            border: 1px solid #a0b4c8;
            border-top: none;
            padding: 4px 8px;
            font-family: Arial, sans-serif;
            font-size: 12px;
            font-weight: bold;
            color: #1a1a1a;
            box-sizing: border-box;
            display: flex;
            justify-content: flex-end;
            gap: 30px;
        }
        .jv-total-bar span
        {
            color: #c0392b;
        }
        .jv-btn-bar
        {
            margin-top: 6px;
            display: flex;
            gap: 6px;
        }
        .col-num
        {
            text-align: right !important;
        }
        .col-ctr
        {
            text-align: center !important;
        }
    </style>
    <script type="text/javascript">
        function Char_Inv(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
                return false;
            return true;
        }
    </script>
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
            <div id="innerbox_MidMain_Billing" style="height: 130px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                        Journal Entry
                    </div>
                    <div id="editbu" style="padding-top: 3px;">
                        <asp:ImageButton ID="btnLedgerDetails" runat="server" ToolTip="Refresh" ImageUrl="~/images/icons/refresh.png"
                            Height="21px" Width="21px" OnClick="btnLedgerDetails_Click" />
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px; height: 70px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 20px; display: flex;
                        align-items: center;">
                        <div style="width: 65px; display: inline-block; vertical-align: middle;">
                            <span style="font-size: 12px; font-family: Arial, sans-serif;">Trans No.</span>
                        </div>
                        <div style="width: 175px; display: inline-block; vertical-align: middle; white-space: nowrap;">
                            <asp:TextBox ID="txt_JV_No_F" runat="server" TabIndex="12" ReadOnly="true" BackColor="#e7e6e6"
                                Width="35px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"
                                Style="display: inline-block; vertical-align: middle;"></asp:TextBox>
                            <asp:TextBox ID="txt_JV_No_M" runat="server" TabIndex="13" ReadOnly="true" BackColor="#e7e6e6"
                                Style="text-align: right; display: inline-block; vertical-align: middle;" Width="51px"
                                Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            <asp:TextBox ID="txt_JV_No_L" runat="server" TabIndex="14" ReadOnly="true" BackColor="#e7e6e6"
                                Width="60px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"
                                Style="display: inline-block; vertical-align: middle;"></asp:TextBox>
                        </div>
                        <div style="width: 55px; display: inline-block;">
                            <span style="font-size: 12px; font-family: Arial, sans-serif;">Tr.Date</span>
                        </div>
                        <div style="width: 105px; display: inline-block;">
                            <asp:TextBox ID="txt_JV_Entry_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                BackColor="#e7e6e6" TabIndex="17" Enabled="false" Height="20px"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_JV_Entry_Date"
                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_JV_Entry_Date"
                                Format="dd/MM/yyyy" Enabled="True">
                            </cc1:CalendarExtender>
                        </div>
                        <div style="width: 85px; display: inline-block;">
                            <span style="font-size: 12px; font-family: Arial, sans-serif;">Posting Date</span>
                        </div>
                        <div style="width: 105px; display: inline-block;">
                            <asp:TextBox ID="txt_Posting_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                TabIndex="18" Height="20px">
                            </asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_Posting_Date"
                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_Posting_Date"
                                Format="dd/MM/yyyy" Enabled="True">
                            </cc1:CalendarExtender>
                        </div>
                    </div>
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 20px; display: flex;
                        align-items: center;">
                        <div id="tag_transact_lft_in1" style="width: 1150px; display: inline-block; vertical-align: middle;
                            height: 20px;">
                            <div id="txt_container_Transact_Main_l" style="width: 60px;">
                                <div id="tag_label_transact_Src" style="width: 40px;">
                                    Currency.
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 110px;">
                                <%--<div id="tag_label_transact_Src" style="width: 50px;">--%>
                                <asp:DropDownList ID="ddl_JV_Cur" runat="server" CssClass="listtxt_transac_mode_new"
                                    Width="50px" TabIndex="25">
                                    <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                </asp:DropDownList>
                                <%--</div>--%>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 70px;">
                                <div id="tag_label_transact_Src" style="width: 65px;">
                                    Exch.Rate
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 60px;">
                                <div id="tag_label_transact_Src" style="width: 50px;">
                                    <asp:TextBox ID="txt_JV_Cur_Val" runat="server" Text="1.000" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                        Height="20px" Width="50px" MaxLength="17" TabIndex="26" onblur="extractNumber(this,2,false);"
                                        onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 20px;">
                        <div id="tag_transact_lft_in1" style="width: 1100px; height: 20px;">
                            <div id="txt_container_Transact_Main_l" style="width: 60px;">
                                <div id="tag_label_transact_Src" style="width: 68px;">
                                    Ref. No.
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 105px;">
                                <asp:TextBox ID="txt_JV_Reference" runat="server" Width="100px" TabIndex="27" CssClass="listtxt_transac_item_gen_notn"
                                    Height="20px"></asp:TextBox>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 70px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Ref. Date
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 105px;">
                                <asp:TextBox ID="txt_JV_Ref_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="28" Height="20px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt_JV_Ref_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_JV_Ref_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 70px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Narration
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 420px;">
                                <asp:TextBox ID="txt_JV_Remarks" runat="server" Width="400px" TabIndex="30" CssClass="listtxt_transac_item_gen_notn"
                                    Height="20px"></asp:TextBox>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 135px;">
                                <asp:Button ID="btnsup" runat="server" TabIndex="35" OnClick="btnsup_Click" />
                                &nbsp;
                                <asp:Button ID="btn_JV_Delete" runat="server" Text="Delete" TabIndex="36" Visible="false"
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');
                                        jConfirm('Are you sure you want to delete this Journal Entry?', 'Journal Entry', function(r) {
                                            var i = r + 'ok';
                                            if (i == 'trueok') {
                                                document.getElementById('btnDelete').click();
                                            }
                                        });
                                        return false;" />
                                <asp:Button ID="btnDelete" runat="server" Style="display: none;" CausesValidation="false"
                                    UseSubmitBehavior="false" OnClick="btn_JV_Delete_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content" id="page-1" style="margin-top: -30px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 480px; width: 1150px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                            id="Page_A" runat="server"><span>Details </span></a></li>
                        <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');"
                            id="Page_B" runat="server"><span>Logs </span></a></li>
                        <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                            id="Page_C" runat="server" visible="false"><span>Gen -3</span></a></li>
                        <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                            id="Page_D" runat="server" visible="false"><span>Gen -4 </span></a></li>
                    </ol>
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_new" style="width: 1130px">
                            <div id="pop_text_area_transac_popup_inn_container_left_new" style="width: 1130px;
                                height: 360px; position: relative;">
                                <div style="width: 1130px; height: 320px; overflow-x: auto; overflow-y: auto; border: 1px solid #C8C8C8;">
                                    <asp:GridView ID="gv_details" runat="server" DataKeyNames="JL_ID" EmptyDataText="NO RECORD's FOUND"
                                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="2000px"
                                        ShowHeaderWhenEmpty="True" PageSize="15" AllowPaging="True" BorderColor="#C8C8C8"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gv_details_RowCreated"
                                        OnRowDataBound="gv_details_RowDataBound" OnRowCommand="gv_details_RowCommand">
                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            BorderWidth="1px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Edit/Update" HeaderStyle-Width="110px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkOrg" runat="server" Text="Edit" OnClientClick='<%# "return open_Journal_Entry_Details_Update(\"" + Eval("JL_ID") + "\", \"" + Eval("JL_ID") + "\", \"I\");" %>'
                                                        CommandName="SelectOrganization">
                                                    </asp:LinkButton>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="dellnkOrg" runat="server" Text="Del" CommandName="DeleteRow"
                                                        CommandArgument='<%# Eval("JL_ID") %>' OnClientClick="return DeleteJournalEntry(this);">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="column_style_left" Width="100px" Font-Size="12px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="JL_ID" HeaderText="Charge id" HeaderStyle-Width="170px"
                                                Visible="false">
                                                <HeaderStyle CssClass="hideGridColumn" />
                                                <ItemStyle CssClass="hideGridColumn" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LINKED_GL" HeaderText="Linked GL Name" HeaderStyle-Width="270px">
                                                <ItemStyle CssClass="column_style_left" Width="270px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CHARGE_NAME" HeaderText="Charge Name" HeaderStyle-Width="230px">
                                                <ItemStyle CssClass="column_style_left" Width="230px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DEBIT" HeaderText="Debit(INR)" DataFormatString="{0:N2}"
                                                HeaderStyle-Width="80px">
                                                <ItemStyle CssClass="column_style_right" Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CREDIT" HeaderText="Credit(INR)" DataFormatString="{0:N2}"
                                                HeaderStyle-Width="80px">
                                                <ItemStyle CssClass="column_style_right" Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BRANCH" HeaderText="Account Branch" HeaderStyle-Width="120px">
                                                <ItemStyle CssClass="column_style_left" Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="COSTCENTER" HeaderText="Cost Center" HeaderStyle-Width="190px">
                                                <ItemStyle CssClass="column_style_left" Width="190px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NARRATION" HeaderText="Narration" HeaderStyle-Width="1200px">
                                                <ItemStyle CssClass="column_style_left narration-cell" Width="1200px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="jv-total-bar">
                                    <span id="spnTotalDebit">Total Debit :
                                        <asp:Literal ID="lbl_Total_Debit" runat="server">0.00</asp:Literal>
                                    </span><span id="spnTotalCredit">Total Credit :
                                        <asp:Literal ID="lbl_Total_Credit" runat="server">0.00</asp:Literal>
                                    </span><span id="spnDifference">Difference :
                                        <asp:Literal ID="lbl_Difference" runat="server">0.00</asp:Literal>
                                    </span>
                                </div>
                                <asp:HiddenField ID="hdn_Sel_JL_ID" runat="server" />
                                <asp:HiddenField ID="hdn_Sel_JV_NO" runat="server" />
                                <div class="jv-btn-bar">
                                    <asp:Button ID="btnJrnNew" Visible="false" runat="server" Text="New" OnClientClick="open_Acc_Journal_Entry_New();" />
                                    <asp:Button ID="btnJrnClose" Visible="false" runat="server" Text="Close" OnClientClick="return ValidateJournalTotals();" />
                                    <asp:Button ID="btnrpt" runat="server" Text="Print" Style="height: 24px; width: 140px;
                                        padding: 0 8px;" OnClientClick="return Journal_Job_Rpt();" />
                                </div>
                                <div class="jv-summary-row">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="popupDiv" style="display: none;">
                    <iframe id="frmJournal" width="1200" height="400" frameborder="0"></iframe>
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Ch_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Group_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Imp_Exp" runat="server" />
            <asp:HiddenField ID="HDupdate_Job_Id" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdnVoucherNo" runat="server" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/Accounts/Acc_iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });

        function open_Acc_Journal_Entry_New() {
            var jvf = document.getElementById('<%= txt_JV_No_F.ClientID %>').value;
            var jvm = document.getElementById('<%= txt_JV_No_M.ClientID %>').value;
            var jvl = document.getElementById('<%= txt_JV_No_L.ClientID %>').value;
            NewWindow1('../Accounts_Others/Acc_Journal_Entry_Details.aspx?JV_F=' + encodeURIComponent(jvf) + '&JV_M=' + encodeURIComponent(jvm) + '&JV_L=' + encodeURIComponent(jvl), '_blank', '1270', '600', 'yes');
        }

        /* required functions  after clean code  */
        function DeleteJournalEntry(btn) {
            jQuery('#form1').validationEngine('hideAll');
            jConfirm('Are you sure you want to delete this Line record?', 'Journal Job Entry', function (r) {
                if (r) {
                    btn.onclick = null;
                    btn.click();
                }
            });
            return false;
        }

        function ValidateBeforeClose() {
            if (Debit != Credit) {
                if (confirm("Debit and Credit amounts are not equal.\n\nClosing this screen will delete the current unsaved records.\n\nAre you sure you want to continue?")) {
                    DeleteRecords();   // Your delete function
                    win_hide();
                    parent.adcodewindow.hide();
                }
            }
            else {
                win_hide();
                parent.adcodewindow.hide();
            }

            return false;
        }

        function getAmount(id) {
            var txt = document.getElementById(id).innerText;
            var match = txt.match(/[-+]?\d*\.?\d+/);
            return match ? parseFloat(match[0]) : 0;
        }

        function ValidateJournalTotals() {
            var debit = getAmount('spnTotalDebit');
            var credit = getAmount('spnTotalCredit');
            var diff = getAmount('spnDifference');
            if (Math.abs(debit - credit) > 0.001 || Math.abs(diff) > 0.001) {

                jQuery('#form1').validationEngine('hideAll');

                jConfirm(
                        'Debit and Credit amounts are not equal.<br/><br/>' +
                        'Closing this screen will delete all the records and this Journal entry.<br/><br/>' +
                        'Are you sure you want to continue?',
                        'Journal Job Entry',
                        function (r) {
                            if (r) {
                                document.getElementById('<%= btnDelete.ClientID %>').click();
                                win_hide();
                                parent.adcodewindow.hide();
                            }
                        });
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function ClosePopupWindow() {
            win_hide();
            if (parent && parent.adcodewindow) {
                parent.adcodewindow.hide();
            }
        }

        function Journal_Job_Rpt() {
            var JV_F = document.getElementById('<%= txt_JV_No_F.ClientID %>').value.trim();
            var JV_M = document.getElementById('<%= txt_JV_No_M.ClientID %>').value.trim();
            var JV_L = document.getElementById('<%= txt_JV_No_L.ClientID %>').value.trim();
            NewWindow1(
        '../Accounts_Others/Acc_Journal_Entry_Rpt.aspx?JV_P=' + encodeURIComponent(JV_F) +
        '&JV_NO=' + encodeURIComponent(JV_M) +
        '&JV_S=' + encodeURIComponent(JV_L),

        'List',
        '870',
        '1024',
        'yes'
    );

            return false;
        }

</script>
</body>
</html>
