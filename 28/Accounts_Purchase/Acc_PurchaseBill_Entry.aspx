<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_PurchaseBill_Entry.aspx.cs"
    Inherits="Acc_PurchaseBill_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Purchase Bill Entry</title>
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
        .printBtn
        {
            background: #007bff url('../images/icons/print.png') no-repeat 8px center;
            color: #fff;
            padding: 8px 17px 5px 32px;
            border: 1px solid #007bff;
            cursor: pointer;
        }
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
        /*.jv-total-bar
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
        }*/
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
            justify-content: space-between; /* Left & Right */
            align-items: center;
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
        .jv-header-shell
        {
            width: 1120px;
            display: flex;
            align-items: flex-start;
            gap: 16px;
            box-sizing: border-box;
            margin: 0;
            padding: 0;
        }
        .jv-header-left
        {
            width: 600px;
            display: flex;
            flex-direction: column;
            gap: 4px;
            box-sizing: border-box;
        }
        .jv-header-right
        {
            flex: 1;
            display: flex;
            flex-direction: column;
            gap: 4px;
            box-sizing: border-box;
            width: 449px;
        }
        .jv-header-inline
        {
            display: flex;
            align-items: center;
            gap: 6px;
            height: 24px;
            box-sizing: border-box;
        }
        .jv-header-label
        {
            width: 90px;
            font-size: 12px;
            font-family: Arial, sans-serif;
            line-height: 24px;
            white-space: nowrap;
            flex: 0 0 90px;
        }
        .jv-header-lbl-Date
        {
            width: 50px;
            font-size: 12px;
            font-family: Arial, sans-serif;
            line-height: 24px;
            white-space: nowrap;
        }
        .jv-header-field-180
        {
            width: 180px;
        }
        .jv-header-field-104
        {
            width: 104px;
        }
        .jv-header-field-220
        {
            width: 590px;
        }
        .jv-header-field-360
        {
            width: 310px;
        }
        .jv-header-field-150
        {
            width: 150px;
        }
        .jv-header-field-70
        {
            width: 70px;
        }
        .jv-header-field-240
        {
            width: 239px;
        }
        
        .jv-header-input
        {
            height: 22px;
            padding: 0 4px;
            box-sizing: border-box;
        }
        
        .jv-summary-shell
        {
            width: 470px;
            margin-left: auto;
            margin-right: 55px;
            margin-top: 4px;
            padding: 2px 0;
        }
        .jv-summary-row
        {
            display: flex;
            align-items: center;
            justify-content: flex-end;
            gap: 5px;
            height: 23px;
            margin-bottom: 2px;
        }
        .jv-summary-label
        {
            width: 110px;
            text-align: right;
            font: bold 12px Arial;
            color: #2f2f2f;
            white-space: nowrap;
        }
        .jv-summary-txt
        {
            width: 145px;
            height: 20px;
            padding: 0 6px;
            text-align: right;
            border: 1px solid #B8C7DD;
            border-radius: 2px;
            font: 11px Arial;
            box-sizing: border-box;
            margin-bottom: 9px;
        }
        
        .jv-summary-txt:focus
        {
            outline: none;
            border-color: #8AA9D6;
            background: #F5F8FD;
        }
        .jv-summary-final
        {
            background: #E7EEF9;
            font-weight: bold;
            color: #1B3C6D;
        }
        
        .jv-summary-ddl
        {
            width: 95px;
            height: 22px;
        }
        
        .jv-summary-percent
        {
            width: 70px;
            text-align: right;
        }
        
        .jv-summary-percent-label
        {
            width: 12px;
            text-align: center;
            font-weight: bold;
            margin-bottom: 9px;
        }
        
        .jv-summary-amount
        {
            width: 120px;
            text-align: right;
        }
        
        .jv-summary-btn
        {
            width: 28px;
            height: 22px;
        }
        
        .jv-summary-at
        {
            width: 10px;
            text-align: center;
            font-weight: bold;
            font-size: 12px;
            margin-bottom: 9px;
        }
        .einvoice-textarea
        {
            width: 480px;
            height: 80px;
            padding: 5px;
            box-sizing: border-box;
            resize: both; /* User can drag to resize */
            overflow: auto;
            font-size: 13px;
        }
        .ex-header th
        {
            background: linear-gradient(#E9E9E9, #D3D3D3);
            color: #222;
            font-size: 13px;
            font-weight: bold;
            height: 30px;
            text-align: center;
            border-right: 1px solid #F8F8F8;
            border-bottom: 1px solid #B5B5B5;
        }
        
        .exLink
        {
            color: #0033FF;
            font-weight: bold;
            text-decoration: none;
            font-size: 12px;
        }
        .exLink:hover
        {
            text-decoration: underline;
        }
        
        .ex-row td
        {
            height: 28px;
            font-size: 12px;
            color: #333;
            text-align: center;
            border-bottom: 1px solid #F1F1F1;
        }
        
        .ex-row:hover
        {
            background: #F7FAFF;
        }
        
        .ex-link
        {
            color: #0A58CA;
            font-weight: 600;
            text-decoration: none;
            font-size: 12px;
        }
        
        .ex-link:hover
        {
            text-decoration: underline;
        }
        .branch-serial
        {
            display: inline-block;
            margin-left: 8px;
            color: Blue;
            font-weight: bold;
            font-size: 15px;
            min-width: 20px;
            text-align: center;
        }
        .jv-header-field-220
        {
            width: 500px;
            display: flex;
            align-items: center;
            gap: 6px;
            flex-wrap: nowrap;
        }
        .jv-header-field-220 .chosen-container
        {
            flex-shrink: 0;
        }
        .jv-header-field-220 .branch-serial
        {
            flex-shrink: 0;
            white-space: nowrap;
            margin-left: 0;
        }
        .roundOffChk label
        {
            color: #0066cc;
            font-weight: bold;
            font-size: 13px;
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
    <%--/* */--%>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
        .FixedHeader
        {
            position: absolute;
            font-weight: bold;
        }
        
        .hideGridColumn
        {
            display: none;
        }
        
        .hideGridColumn1
        {
            display: none;
        }
    </style>
    <style>
        div.fileinputs
        {
            position: relative;
        }
        
        div.fakefile
        {
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 1;
        }
        
        input.file
        {
            position: relative;
            text-align: right;
            -moz-opacity: 0;
            filter: alpha(opacity: 0);
            opacity: 0;
            z-index: 2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <%-------------------------------------------------------------------------------%>
            <div id="innerbox_MidMain_Billing" style="height: 129px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                        Purchase Bill
                    </div>
                    <div id="editbu" style="padding-top: 3px;">
                        <asp:ImageButton ID="btnLedgerDetails" runat="server" ToolTip="Refresh" ImageUrl="~/images/icons/refresh.png"
                            Height="21px" Width="21px" OnClick="btnLedgerDetails_Click" />
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px; padding: 2px 0 0 0; box-sizing: border-box;">
                    <div class="jv-header-shell">
                        <div class="jv-header-left">
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Trans No.</div>
                                <div class="jv-header-field-180">
                                    <asp:TextBox ID="txt_PC_No_F" runat="server" TabIndex="1" ReadOnly="true" BackColor="#e7e6e6"
                                        Width="49px" Height="22px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No jv-header-input"
                                        Style="display: inline-block; vertical-align: middle; padding: 0 2px; box-sizing: border-box;">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txt_PC_No_M" runat="server" TabIndex="2" ReadOnly="true" BackColor="#e7e6e6"
                                        Style="text-align: right; display: inline-block; vertical-align: middle; padding: 0 2px;
                                        box-sizing: border-box;" Width="49px" Height="22px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No jv-header-input">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txt_PC_No_L" runat="server" TabIndex="3" ReadOnly="true" BackColor="#e7e6e6"
                                        Width="49px" Height="22px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No jv-header-input"
                                        Style="display: inline-block; vertical-align: middle; padding: 0 2px; box-sizing: border-box;">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Organisaton <span style="color: Red;">* </span>
                                </div>
                                <div class="jv-header-field-220">
                                    <div id="txtcon-m_Exchange" style="width: 0px; display: none;">
                                        <asp:DropDownList ID="ddl_org_name_1" class="validate[required]  chosen-select-deselect"
                                            Style="width: 0px;" data-placeholder="Choose a Branch No" runat="server">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 500px; height: 21px;">
                                        <asp:DropDownList ID="ddl_org_name" class="validate[required]  chosen-select-deselect"
                                            OnSelectedIndexChanged="ddl_org_name_SelectedIndexChanged" AutoPostBack="true"
                                            Style="width: 400px;" data-placeholder="Choose a Org. Name" runat="server" TabIndex="4">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_Br_no" class="validate[required]  chosen-select-deselect"
                                            Width="90px" AutoPostBack="true" data-placeholder="Br. No" runat="server" OnSelectedIndexChanged="ddl_Br_no_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <%-- <asp:DropDownList ID="ddl_Br_no" class="validate[required]  chosen-select-deselect"
                                        Width="90px" AutoPostBack="true" data-placeholder="Br. No" runat="server" OnSelectedIndexChanged="ddl_Br_no_SelectedIndexChanged">
                                    </asp:DropDownList>--%>
                                    <%-- <asp:Label ID="lblBranchSerialNo" runat="server" CssClass="branch-serial"></asp:Label>--%>
                                    <asp:HiddenField ID="hfBranchSerialNo" runat="server" />
                                    <asp:HiddenField ID="hfOrgStateGstId" runat="server" />
                                    <asp:HiddenField ID="hfchkol" runat="server" />
                                </div>
                            </div>
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Vendor Invc No. <span style="color: Red;">* </span>
                                </div>
                                <div class="jv-header-field-180">
                                    <asp:TextBox ID="txt_Vendor_Invoice_No" runat="server" Width="110px" TabIndex="5"
                                        CssClass="listtxt_transac_item_gen_notn jv-header-input" Height="22px" Style="padding: 0 4px;
                                        box-sizing: border-box;"></asp:TextBox>
                                </div>
                                <div class="jv-header-lbl-Date">
                                    Date <span style="color: Red;">* </span>
                                </div>
                                <div class="jv-header-field-104">
                                    <asp:TextBox ID="txt_Vendor_Invoice_Date" runat="server" Width="79px" CssClass="txtbox_none_Mid_transac_code jv-header-input"
                                        TabIndex="6" Height="22px" Style="padding: 0 4px; box-sizing: border-box;"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_Vendor_Invoice_Date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Vendor_Invoice_Date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <div class="jv-header-right">
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Entry Date</div>
                                <div class="jv-header-field-104">
                                    <asp:TextBox ID="txt_PC_Entry_Date" runat="server" Width="84px" CssClass="txtbox_none_Mid_transac_code jv-header-input"
                                        BackColor="#e7e6e6" TabIndex="7" Enabled="false" Height="22px" Style="padding: 0 4px;
                                        box-sizing: border-box;">
                                    </asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_PC_Entry_Date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_PC_Entry_Date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="jv-header-label">
                                    Posting Date <span style="color: Red;">* </span>
                                </div>
                                <div class="jv-header-field-104">
                                    <asp:TextBox ID="txt_Posting_Date" runat="server" Width="84px" CssClass="txtbox_none_Mid_transac_code jv-header-input"
                                        TabIndex="8" Height="22px" Style="padding: 0 4px; box-sizing: border-box;">
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
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Due Date</div>
                                <div class="jv-header-field-104">
                                    <asp:TextBox ID="txt_PC_Due_Date" runat="server" Width="84px" CssClass="txtbox_none_Mid_transac_code jv-header-input"
                                        TabIndex="9" Height="22px" Style="padding: 0 4px; box-sizing: border-box;">
                                    </asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txt_PC_Due_Date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_PC_Due_Date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="jv-header-label">
                                    Currency.</div>
                                <div class="jv-header-field-180">
                                    <asp:DropDownList ID="ddl_PC_Cur" runat="server" CssClass="listtxt_transac_mode_new jv-header-input"
                                        Width="50px" Style="height: 22px; padding: 0 2px; box-sizing: border-box;">
                                        <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Narration</div>
                                <div class="jv-header-field-360">
                                    <asp:TextBox ID="txt_PC_Narration" runat="server" Width="290px" TabIndex="10" CssClass="listtxt_transac_item_gen_notn jv-header-input"
                                        Height="22px" Style="padding: 0 4px; box-sizing: border-box;"></asp:TextBox>
                                </div>
                                <div class="jv-header-field-240">
                                    <asp:Button ID="btnDelete" runat="server" Style="display: none;" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClick="btn_PC_Delete_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content" id="page-1" style="margin-top: -30px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 243px; width: 1150px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                            id="Page_A" runat="server"><span>General </span></a></li>
                        <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');"
                            id="Page_B" runat="server"><span>Payment Details </span></a></li>
                        <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                            id="Page_C" runat="server"><span>Ex-Change Rate</span></a></li>
                        <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                            id="Page_D" runat="server"><span>E-Invoice </span></a></li>
                        <li><a href="#page-10" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page5('0');"
                            id="Page_E" runat="server"><span>Notes </span></a></li>
                    </ol>
                    <%------------------General-------------%>
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_new" style="width: 1130px">
                            <div id="pop_text_area_transac_popup_inn_container_left_new" style="width: 1130px;
                                height: 360px; position: relative;">
                                <%--<div style="width: 1119px; height: 167px; overflow-x: auto; overflow-y: hidden; border: 1px solid #C8C8C8;">--%>
                                <div style="width: 1119px; height: 167px; overflow-x: auto; overflow-y: auto; border: 1px solid #C8C8C8;">
                                    <asp:GridView ID="gv_details" runat="server" DataKeyNames="PCL_ID" EmptyDataText="No Record's Found"
                                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="2000px"
                                        ShowHeaderWhenEmpty="True" PageSize="15" AllowPaging="True" BorderColor="#C8C8C8"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gv_details_RowCreated"
                                        OnRowDataBound="gv_details_RowDataBound" OnRowCommand="gv_details_RowCommand">
                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            BorderWidth="1px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Edit/Update" HeaderStyle-Width="110px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkOrg" runat="server" Text="Edit" OnClientClick='<%# "return open_Purchase_Entry_Details_Update(\"" + Eval("PCL_ID") + "\", \"" + Eval("PCL_ID") + "\", \"I\");" %>'
                                                        CommandName="SelectOrganization">
                                                    </asp:LinkButton>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="dellnkOrg" runat="server" Text="Del" CommandName="DeleteRow"
                                                        CommandArgument='<%# Eval("PCL_ID") %>' OnClientClick="return DeletePurchaseEntry(this);">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="column_style_center" Width="110px" Font-Size="12px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="LINKED_GL" HeaderText="GL Name" HeaderStyle-Width="140px">
                                                <ItemStyle CssClass="column_style_left" Width="140px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CHARGE_NAME" HeaderText="Charge Name" HeaderStyle-Width="190px">
                                                <ItemStyle CssClass="column_style_left" Width="190px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BRANCH" HeaderText="Account Branch" HeaderStyle-Width="110px">
                                                <ItemStyle CssClass="column_style_left" Width="110px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AMOUNT" HeaderText="Amount (INR)" DataFormatString="{0:N2}"
                                                HeaderStyle-Width="90px">
                                                <ItemStyle CssClass="column_style_right" Width="90px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DR_CR" HeaderText="D/C" HeaderStyle-Width="60px">
                                                <ItemStyle CssClass="column_style_center" Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LOB" HeaderText="LOB" HeaderStyle-Width="130px">
                                                <ItemStyle CssClass="column_style_left" Width="130px" />
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="REF_NO" HeaderText="Ref No" HeaderStyle-Width="140px">
                                                <ItemStyle CssClass="column_style_left" Width="140px" />
                                            </asp:BoundField>--%>
                                            
                                            <asp:TemplateField HeaderText="Reference No" HeaderStyle-Width="240px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblreferenceNo" runat="server" Text='<%# Eval("REF_NO") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="column_style_left" Width="240px" />
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="TAX_TYPE" HeaderText="Tax Type" HeaderStyle-Width="100px">
                                                <ItemStyle CssClass="column_style_left" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SUMMARYTAX_RATE" HeaderText="Tax Rate" DataFormatString="{0:N2}"
                                                HeaderStyle-Width="90px">
                                                <ItemStyle CssClass="column_style_right" Width="90px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SACHSNRATE" HeaderText="SAC/HSN Code" HeaderStyle-Width="170px">
                                                <ItemStyle CssClass="column_style_left" Width="170px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AVAIL_TAX_CREDIT" HeaderText="Tax Credit Availed" HeaderStyle-Width="90px">
                                                <ItemStyle CssClass="column_style_center" Width="90px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AVAIL_TAX_CREDIT_RATE" HeaderText="Availed Rate" DataFormatString="{0:N2}"
                                                HeaderStyle-Width="90px">
                                                <ItemStyle CssClass="column_style_right" Width="90px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <%--<div class="jv-total-bar">
                                    <asp:Button ID="btnJrnNew" runat="server" Text="New" OnClientClick="open_Acc_Purchase_Entry_New();"
                                        Style="width: 99px;" />
                                    <span id="spnTotalDebit">Total:
                                        <asp:Literal ID="lbl_Total_Debit" runat="server">0.00</asp:Literal>
                                    </span>
                                </div>--%>
                                <div class="jv-total-bar">
                                    <asp:Button ID="btnJrnNew" runat="server" Text="New" OnClientClick="open_Acc_Purchase_Entry_New();"
                                        Style="width: 99px;" />
                                    <span id="spnTotalDebit">Total:
                                        <asp:Literal ID="lbl_Total_Debit" runat="server">0.00</asp:Literal>
                                    </span>
                                </div>
                                <asp:HiddenField ID="hdn_Sel_JL_ID" runat="server" />
                                <asp:HiddenField ID="hdn_Sel_JV_NO" runat="server" />
                                <div class="jv-btn-bar">
                                    <%--  <asp:Button ID="btnJrnNew" runat="server" Text="New" OnClientClick="open_Acc_Purchase_Entry_New();"
                                        Style="width: 99px;" />--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-------------Payment Details----------%>
                    <%--                    <div class="content" id="page-7">
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px;width: 1194px; margin-top: -10px; margin-left: -18px;">
                        </div>
                    </div>--%>
                    <%-------------Payment Details----------%>
                    <div class="content" id="page-7">
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 199px;
                            width: 1119px; margin-top: -10px; margin-left: -18px;">
                            <%-- Filter Bar --%>
                            <div class="jv-header-inline" style="padding: 6px 10px; gap: 10px;">
                                <div class="jv-header-label" style="width: 40px;">
                                    Date</div>
                                <asp:TextBox ID="txt_PD_DateRange" runat="server" Width="140px" CssClass="jv-header-input"
                                    Style="padding: 0 4px; box-sizing: border-box;" ReadOnly="true"></asp:TextBox>
                                <asp:DropDownList ID="ddl_PD_RefType" runat="server" CssClass="jv-header-input" Width="90px">
                                    <asp:ListItem Text="Ref. No." Value="REFNO"></asp:ListItem>
                                    <asp:ListItem Text="Trans No." Value="TRANSNO"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txt_PD_Search" runat="server" Width="180px" CssClass="jv-header-input"
                                    Style="padding: 0 4px; box-sizing: border-box;"></asp:TextBox>
                                <div class="jv-header-label" style="width: 40px;">
                                    Rows</div>
                                <asp:TextBox ID="txt_PD_Rows" runat="server" Width="50px" CssClass="jv-header-input"
                                    Text="50" Style="padding: 0 4px; text-align: right; box-sizing: border-box;"></asp:TextBox>
                                <asp:LinkButton ID="lnk_PD_Clear" runat="server" Text="Clear" CssClass="exLink" Style="margin-left: 10px;"
                                    OnClick="lnk_PD_Clear_Click"></asp:LinkButton>
                                <asp:Button ID="btn_PD_RetrieveOnAccount" runat="server" Text="Retrieve On Account"
                                    Style="margin-left: 10px; height: 24px;" OnClick="btn_PD_RetrieveOnAccount_Click" />
                            </div>
                            <div class="jv-grid-wrapper" style="height: 130px; margin: 4px 10px 0 10px; width: 1119px;">
                                <table class="grid-view">
                                    <thead>
                                        <tr>
                                            <th style="width: 160px;">
                                                Reference No.
                                            </th>
                                            <th style="width: 100px;">
                                                Ref Date
                                            </th>
                                            <th style="width: 90px;">
                                                Type
                                            </th>
                                            <th style="width: 110px;">
                                                Trans No.
                                            </th>
                                            <th style="width: 100px;">
                                                Trans Date
                                            </th>
                                            <th style="width: 120px;">
                                                Amount
                                            </th>
                                            <th style="width: 130px;">
                                                Advance
                                            </th>
                                            <th style="width: 110px;">
                                                TDS Amt
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td colspan="8" style="text-align: center; color: #888; cursor: default;">
                                                No Records Found
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <%-- Total bar --%>
                            <div class="jv-total-bar" style="width: 1160px; margin: 0 10px; justify-content: space-between;">
                                <span style="margin-left: 4px;">Total</span>
                                <div style="display: flex; gap: 30px;">
                                    <span id="lbl_PD_TotalAdvance">0.00</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-------------Ex-Change Rate-----------%>
                    <div class="content" id="page-8">
                        <div style="width: 760px; border: 1px solid #6A95D6; background: #FFFFFF;">
                            <div style="height: 119px; overflow-y: auto;">
                                <asp:GridView ID="gvExchangeRate" runat="server" AutoGenerateColumns="False" Width="100%"
                                    GridLines="None" BorderWidth="0">
                                    <HeaderStyle BackColor="#E6B04C" Height="28px" HorizontalAlign="Center" Font-Bold="True" />
                                    <Columns>
                                        <asp:BoundField DataField="Currency" HeaderText="Currency" ItemStyle-Width="30%"
                                            ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="ExRate" HeaderText="Ex Rate" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="ConvCurrency" HeaderText="Conversion Currency" ItemStyle-Width="45%"
                                            ItemStyle-HorizontalAlign="Center" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div style="height: 30px; line-height: 30px; border-top: 1px solid #D8D8D8; background: #F4F4F4;
                                padding-left: 10px;">
                                <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CssClass="exLink" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkLoadRates" runat="server" Text="Load today's rates" CssClass="exLink" />
                            </div>
                        </div>
                    </div>
                    <%-------------E-Invoice----------------%>
                    <div class="content" id="page-9">
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px;
                            width: 1194px; margin-top: -10px; margin-left: -18px;">
                            <div style="margin-top: 30px; margin-left: 40px;">
                                <div class="jv-header-label">
                                    E-Invoice Ref No :
                                </div>
                                <div style="float: left;">
                                    <asp:TextBox ID="einvoice_RefNo" runat="server" TextMode="MultiLine" Rows="5" Columns="60"
                                        CssClass="einvoice-textarea">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-------------Notes--------------------%>
                    <div class="content" id="page-10">
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px;
                            width: 1194px; margin-top: -10px; margin-left: -18px;">
                        </div>
                    </div>
                </div>
                <%-------------Summary Section--------------------%>
                <div class="jv-summary-shell">
                    <div class="jv-summary-row">
                        <span class="jv-summary-label">Tax</span>
                        <asp:TextBox ID="txtTax" runat="server" CssClass="jv-summary-txt" ReadOnly="true" />
                    </div>
                    <div class="jv-summary-row">
                        <span class="jv-summary-label">Grand Total</span>
                        <asp:TextBox ID="txtGrandTotal" runat="server" CssClass="jv-summary-txt" ReadOnly="true" />
                    </div>
                    <div class="jv-summary-row">
                        <span class="jv-summary-label">TDS</span>
                        <asp:DropDownList ID="ddlTDS" runat="server" CssClass="jv-summary-txt">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="192B" Value="192B"></asp:ListItem>
                            <asp:ListItem Text="194A" Value="194A"></asp:ListItem>
                            <asp:ListItem Text="194B" Value="194B"></asp:ListItem>
                            <asp:ListItem Text="194C" Value="194C"></asp:ListItem>
                            <asp:ListItem Text="194D" Value="194D"></asp:ListItem>
                            <asp:ListItem Text="194H" Value="194H"></asp:ListItem>
                            <asp:ListItem Text="194I" Value="194I"></asp:ListItem>
                            <asp:ListItem Text="194Ia" Value="194Ia"></asp:ListItem>
                            <asp:ListItem Text="194Ib" Value="194Ib"></asp:ListItem>
                            <asp:ListItem Text="194J" Value="194J"></asp:ListItem>
                        </asp:DropDownList>
                        <span class="jv-summary-at">@</span>
                        <asp:TextBox ID="txtTDSPercent" runat="server" CssClass="jv-summary-txt" onkeyup="extractNumber(this,3,false); return Clear_Dot(this); CalculatePayable('percent');"
                            onblur="extractNumber(this,3,false); CalculatePayable('percent');"></asp:TextBox>
                        <span class="jv-summary-percent-label">%</span>
                        <asp:TextBox ID="txtTDSAmount" runat="server" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="jv-summary-txt" onkeyup="extractNumber(this,3,false); return Clear_Dot(this); CalculatePayable('tdsAmount');"
                            onblur="extractNumber(this,3,false); CalculatePayable('tdsAmount');">
                        </asp:TextBox>
                    </div>
                    <div class="jv-summary-row">
                        <span class="jv-summary-label">Gross Payable </span>
                        <asp:TextBox ID="txtGrossPayable" runat="server" CssClass="jv-summary-txt" ReadOnly="true" />
                    </div>
                    <div class="jv-summary-row">
                        <span class="jv-summary-label">Advance</span>
                        <asp:TextBox ID="txtAdvance" runat="server" CssClass="jv-summary-txt" onblur="extractNumber(this,2,false); formatDecimal(this); CalculatePayable();"
                            onkeyup="extractNumber(this,2,false); Clear_Dot(this); CalculatePayable();" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                    </div>
                    <div class="jv-summary-row">
                        <asp:CheckBox ID="chkRoundOff" runat="server" Text="Round Off" TextAlign="Left" Style="margin-right: 8px;"
                            CssClass="roundOffChk" onclick="CalculatePayable();" />
                        <span class="jv-summary-label">Round Off Amt</span>
                        <asp:TextBox ID="txt_RoundOffAmt" runat="server" CssClass="jv-summary-txt" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="jv-summary-row">
                        <span class="jv-summary-label">Net Payable</span>
                        <asp:TextBox ID="txtNetPayable" runat="server" CssClass="jv-summary-txt" />
                    </div>
                    <%--<div id="editbu" style="padding-top: 5px;">
                        <asp:Button ID="btnrpt" runat="server" Text="Print" CssClass="printBtn" OnClientClick="return Purchase_Job_Rpt();" />
                    </div>--%>
                    <div class="jv-summary-row">
                        <asp:Button ID="btnsup" runat="server" TabIndex="11" OnClientClick="return ValidatePurchaseFields();"
                            OnClick="btnsup_Click" Style="height: 24px; width: 140px; padding: 0 8px;" />
                        <asp:Button ID="btnrpt" runat="server" Text="Print" Style="height: 24px; width: 140px;
                            padding: 0 8px;" OnClientClick="return Purchase_Job_Rpt();" />
                        <asp:Button ID="btn_PC_Delete" runat="server" Text="Delete" TabIndex="36" Visible="true"
                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');
                                            jConfirm('Are you sure you want to delete this Purchase Entry Transaction?', 'Purchase Entry', function(r) {
                                                var i = r + 'ok';
                                                if (i == 'trueok') {
                                                    document.getElementById('btnDelete').click();
                                                }
                                            });
                                            return false;" Style="height: 24px; width: 109px; padding: 0 8px;" />
                    </div>
                </div>
                <%-------------END of Summary Section--------------------%>
                <div id="popupDiv" style="display: none;">
                    <iframe id="frmJournal" width="1200" height="400" frameborder="0"></iframe>
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8', 'page-9', 'page-10']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Ch_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Group_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Imp_Exp" runat="server" />
            <asp:HiddenField ID="HDupdate_Job_Id" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdnVoucherNo" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
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
        $(document).ready(function () {
            CalculatePayable();
        });

    </script>
    <script type="text/javascript">
        function getNumericValue(id) {
            var el = document.getElementById(id);
            if (!el) return 0;
            var val = (el.value !== undefined) ? el.value : el.innerText;
            val = String(val).replace(/,/g, '').trim();
            var num = parseFloat(val);
            return isNaN(num) ? 0 : num;
        }

        function getTotalDebitAmount() {
            var span = document.getElementById('spnTotalDebit');
            if (!span) return 0;
            var text = span.textContent || span.innerText || '';
            text = text.replace(/[^0-9.\-]/g, '');
            var num = parseFloat(text);
            return isNaN(num) ? 0 : num;
        }

        function formatMoney(num) {
            if (isNaN(num)) num = 0;
            return num.toFixed(2);
        }

        function applyRoundOff(value) {
            var isNeg = value < 0;
            var absVal = Math.abs(value);
            var intPart = Math.floor(absVal);
            var decimalPart = Math.round((absVal - intPart) * 100) / 100;
            var result = (decimalPart >= 0.51) ? (intPart + 1) : intPart;
            return isNeg ? -result : result;
        }

        function CalculatePayable(source) {

            var grandTotalId = '<%= txtGrandTotal.ClientID %>';
            var tdsPercentId = '<%= txtTDSPercent.ClientID %>';
            var tdsAmountId = '<%= txtTDSAmount.ClientID %>';
            var grossPayableId = '<%= txtGrossPayable.ClientID %>';
            var advanceId = '<%= txtAdvance.ClientID %>';
            var netPayableId = '<%= txtNetPayable.ClientID %>';
            var roundOffId = '<%= chkRoundOff.ClientID %>';
            var roundOffAmtId = '<%= txt_RoundOffAmt.ClientID %>';

            var grandTotal = getNumericValue(grandTotalId);
            var tdsPercent = getNumericValue(tdsPercentId);
            var advance = getNumericValue(advanceId);
            var totalDebit = getTotalDebitAmount();

            var tdsAmountEl = document.getElementById(tdsAmountId);
            var tdsAmount = 0;

            if (source === 'percent') {
                tdsAmount = (tdsPercent > 0) ? (totalDebit * tdsPercent) / 100 : 0;
                if (tdsAmountEl) tdsAmountEl.value = formatMoney(tdsAmount);
            } else {
                tdsAmount = getNumericValue(tdsAmountId);
            }

            var grossPayable = grandTotal - tdsAmount;
            var grossPayableEl = document.getElementById(grossPayableId);
            if (grossPayableEl) grossPayableEl.value = formatMoney(grossPayable);

            var netPayable = grossPayable - advance;
            var roundChk = document.getElementById(roundOffId);
            var roundOffAmtEl = document.getElementById(roundOffAmtId);

            if (roundChk && roundChk.checked) {
                var beforeRound = netPayable;
                netPayable = applyRoundOff(netPayable);

                var roundOffDiff = Math.round((netPayable - beforeRound) * 100) / 100;

                if (roundOffAmtEl) roundOffAmtEl.value = formatMoney(roundOffDiff);
            } else {
                if (roundOffAmtEl) roundOffAmtEl.value = formatMoney(0);
            }

            var netPayableEl = document.getElementById(netPayableId);
            if (netPayableEl) netPayableEl.value = formatMoney(netPayable);
        }
    </script>
    <script type="text/javascript">
        function ValidatePurchaseFields() {

            if (document.getElementById('txt_Posting_Date').value == '') {
                Alert_msg("Enter Purchase Posting Date@!", "txt_Posting_Date");
                return false;
            }

            if (document.getElementById('ddl_org_name').value == '') {
                Alert_msg("Enter Organisation !", "ddl_org_name");
                return false;
            }
            if (document.getElementById('txt_Vendor_Invoice_No').value == '') {
                Alert_msg("Enter Vendor Invoice Number!", "txt_Vendor_Invoice_No");
                return false;
            }

            if (document.getElementById('txt_Vendor_Invoice_Date').value == '') {
                Alert_msg("Enter Vendor Invoice Date !", "txt_Vendor_Invoice_Date");
                return false;
            }

            return true;
        }
    </script>
    <script type="text/javascript">
        Sys.Application.add_load(function () {
            $("#<%= txt_Vendor_Invoice_No.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../Accounts_Auto_Search/Accounts_Auto_Search.asmx/ACC_PC_VENINV_CHECK_NO_DUPLICATE",
                        data: "{'mail':'" + request.term + "'}",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response(data.d);
                            var exactMatch = $.grep(data.d, function (item) {
                                return item.toUpperCase() === request.term.toUpperCase();
                            });
                            if (exactMatch.length > 0) {
                                jAlert('Vendor Invoice already exists', 'Duplicate');
                            }
                        },
                        error: function (xhr, status, error) {
                            alert(xhr.responseText);
                        }
                    });
                },
                minLength: 1
            });
        });
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();

        });
        function close_button() {
            document.getElementById("General").click();
        }

        function open_Acc_Purchase_Entry_New() {
            var jvf = document.getElementById('<%= txt_PC_No_F.ClientID %>').value;
            var jvm = document.getElementById('<%= txt_PC_No_M.ClientID %>').value;
            var jvl = document.getElementById('<%= txt_PC_No_L.ClientID %>').value;

            var f_osgstId = document.getElementById('<%= hfOrgStateGstId.ClientID %>').value;
            var f_chkol = document.getElementById('<%= hfchkol.ClientID %>').value;
            NewWindow1('../Accounts_Purchase/Acc_PurchaseBill_Entry_Details.aspx?PC_F=' + encodeURIComponent(jvf) + '&PC_M=' + encodeURIComponent(jvm) + '&PC_L=' + encodeURIComponent(jvl) + '&OSGSTID=' + encodeURIComponent(f_osgstId) + '&CHKOL=' + encodeURIComponent(f_chkol), '_blank', '1270', '600', 'yes');
        }

        window.onload = function () {
            Load_Jobno_CusName();

        };


        /* required functions  after clean code  */
        function DeletePurchaseEntry(plId) {
            jQuery('#form1').validationEngine('hideAll');
            jConfirm('Are you sure you want to delete this record?', 'Purchase Bill Job Entry', function (r) {
                if (r) {
                    document.getElementById('<%= HDupdate_id.ClientID %>').value = plId;
                    document.getElementById('btn3').click();
                }
            });
            return false;
        }


        function ConfirmDelete() {
            jQuery('#form1').validationEngine('hideAll');
            var btn = event.target || event.srcElement;
            jConfirm('Are you sure you want to delete this record?', 'Purchase Bill Job Entry', function (r) {
                if (r) {
                    __doPostBack(btn.name, '');
                }
            });
            return false;
        }

        function DeletePurchaseEntry(btn) {
            jQuery('#form1').validationEngine('hideAll');
            jConfirm('Are you sure you want to delete this record?', 'Purchase Bill Job Entry', function (r) {
                if (r) {
                    btn.onclick = null;
                    btn.click();
                }
            });
            return false;
        }

        function Purchase_Job_Rpt() {
            var PC_F = document.getElementById('<%= txt_PC_No_F.ClientID %>').value.trim();
            var PC_M = document.getElementById('<%= txt_PC_No_M.ClientID %>').value.trim();
            var PC_L = document.getElementById('<%= txt_PC_No_L.ClientID %>').value.trim();
            NewWindow1('../Accounts_Purchase/Acc_PurchaseBill_Rpt.aspx?PC_P=' + encodeURIComponent(PC_F) +
                        '&PC_NO=' + encodeURIComponent(PC_M) + '&PC_S=' + encodeURIComponent(PC_L), 'List', '870', '1024', 'yes');

            return false;
        }
    </script>
    <script type="text/javascript">
        function open_Purchase_Entry_Details_Update(val) {
            var w = '1270';
            var h = '600';
            var left = (screen.width - w) / 2;
            var top = (screen.height - h) / 2;

            var f_osgstId = document.getElementById('<%= hfOrgStateGstId.ClientID %>').value;
            var f_chkol = document.getElementById('<%= hfchkol.ClientID %>').value;

            var childWindow = window.open('../Accounts_Purchase/Acc_PurchaseBill_Entry_Details.aspx?PCL_ID=' + encodeURIComponent(val) + '&AB=' + encodeURIComponent(val) + '&I_E=' + encodeURIComponent(val) + '&OSGSTID=' + encodeURIComponent(f_osgstId) + '&CHKOL=' + encodeURIComponent(f_chkol),
        'Purchase Bill', 'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');
            var checkWindowClosed = setInterval(function () {
                if (childWindow.closed) {
                    clearInterval(checkWindowClosed);
                    triggerParentButton();
                }
            }, 100);
        }
    </script>
    <script type="text/javascript">

        $('#<%= ddl_org_name.ClientID %>').change(function () {

            var selected = $(this).find(':selected');

            var branchSerial = selected.attr('data-branchserial');
            var gstState = selected.attr('data-gststate');
            var otherLocal = selected.attr('data-otherlocal');


            $('#<%= hfBranchSerialNo.ClientID %>').val(branchSerial);
            $('#<%= hfOrgStateGstId.ClientID %>').val(gstState);
            $('#<%= hfchkol.ClientID %>').val(otherLocal);
        });

    </script>
</body>
</html>
