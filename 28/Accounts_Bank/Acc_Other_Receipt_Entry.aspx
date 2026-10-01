<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Other_Receipt_Entry.aspx.cs"
    Inherits="Acc_Other_Receipt_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Other Receipt </title>
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
            width: 360px;
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
            padding-left: 69px;
        }
        .jv-header-inline
        {
            display: flex;
            align-items: center;
            gap: 6px;
            height: 27px;
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
        .jv-header-posting-label
        {
            width: 90px;
            font-size: 12px;
            font-family: Arial, sans-serif;
            line-height: 24px;
            white-space: nowrap;
            flex: 0 0 90px;
            padding-left: 95px;
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
            width: 220px;
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
            min-height: 19px;
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
            height: 17px;
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
            resize: both;
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
            width: 300px;
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
        .jv-header-row-grid
        {
            display: grid;
            grid-template-columns: 90px 200px 90px 104px;
            align-items: center;
            column-gap: 6px;
            height: 27px;
            box-sizing: border-box;
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
            <div id="innerbox_MidMain_Billing" style="height: 169px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                        Other Receipts
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
                        <%----------------------------------LEFT column fields-----------------------------------------------------%>
                        <div class="jv-header-left">
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Trans No.</div>
                                <div class="jv-header-field-180">
                                    <asp:TextBox ID="txt_BR_No_F" runat="server" TabIndex="1" ReadOnly="true" BackColor="#e7e6e6"
                                        Width="49px" Height="22px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No jv-header-input"
                                        Style="display: inline-block; vertical-align: middle; padding: 0 2px; box-sizing: border-box;">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txt_BR_No_M" runat="server" TabIndex="2" ReadOnly="true" BackColor="#e7e6e6"
                                        Style="text-align: right; display: inline-block; vertical-align: middle; padding: 0 2px;
                                        box-sizing: border-box;" Width="49px" Height="22px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No jv-header-input">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txt_BR_No_L" runat="server" TabIndex="3" ReadOnly="true" BackColor="#e7e6e6"
                                        Width="49px" Height="22px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No jv-header-input"
                                        Style="display: inline-block; vertical-align: middle; padding: 0 2px; box-sizing: border-box;">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Bank Name <span style="color: Red;">* </span>
                                </div>
                                <div class="jv-header-field-220">
                                    <asp:DropDownList ID="ddl_Bank_From" runat="server" Width="261px" TabIndex="4" CssClass="listtxt_transac_item_gen_notn jv-header-input"
                                        OnSelectedIndexChanged="ddl_Bank_From_SelectedIndexChanged" AutoPostBack="true"
                                        Height="22px" Style="padding: 0 4px; box-sizing: border-box; background-color: white;">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hfBankGLCode" runat="server" />
                                    <asp:HiddenField ID="hfBankName" runat="server" />
                                </div>
                            </div>
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Amount <span style="color: Red;">* </span>
                                </div>
                                <div class="jv-header-field-220">
                                    <asp:TextBox ID="txt_Cur_Amt" runat="server" Width="89px" TabIndex="5" CssClass="listtxt_transac_item_gen_notn jv-header-input"
                                        onblur="extractNumber(this,2,false); formatDecimal(this);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Height="22px"
                                        Style="padding: 0 4px; box-sizing: border-box;"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:DropDownList ID="ddl_Cur" Style="width: 55px;" runat="server" TabIndex="6">
                                        <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:TextBox ID="txt_Ex_Rate" Width="60px" Text="1.00" Enabled="false" CssClass="txtbox_none_Mid_transac_code"
                                        TabIndex="7" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%------%>
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Reference No
                                </div>
                                <div class="jv-header-field-180">
                                    <asp:TextBox ID="txt_Reference" runat="server" Width="110px" TabIndex="8" CssClass="listtxt_transac_item_gen_notn jv-header-input"
                                        Height="22px" Style="padding: 0 4px; box-sizing: border-box;"></asp:TextBox>
                                </div>
                                <div class="jv-header-lbl-Date">
                                    Ref Date
                                </div>
                                <div class="jv-header-field-104">
                                    <asp:TextBox ID="txtReference_Date" runat="server" Width="79px" CssClass="txtbox_none_Mid_transac_code jv-header-input"
                                        TabIndex="9" Height="22px" Style="padding: 0 4px; box-sizing: border-box;"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtReference_Date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtReference_Date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                            <%------%>
                        </div>
                        <%----------------------------------right column fields-----------------------------------------------------%>
                        <div class="jv-header-right">
                            <%----RR1--%>
                            <div class="jv-header-inline">
                                <div class="jv-header-label jv-header-row-grid">
                                    Entry Date</div>
                                <div class="jv-header-field-104">
                                    <asp:TextBox ID="txt_BR_Entry_Date" runat="server" Width="84px" CssClass="txtbox_none_Mid_transac_code jv-header-input"
                                        TabIndex="10" BackColor="#e7e6e6" Enabled="false" Height="22px" Style="padding: 0 4px;
                                        box-sizing: border-box;">
                                    </asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_BR_Entry_Date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_BR_Entry_Date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="jv-header-posting-label">
                                    Posting Date <span style="color: Red;">* </span>
                                </div>
                                <div class="jv-header-field-104">
                                    <asp:TextBox ID="txt_Posting_Date" runat="server" Width="84px" CssClass="txtbox_none_Mid_transac_code jv-header-input"
                                        TabIndex="11" Height="22px" Style="padding: 0 4px; box-sizing: border-box;">
                                    </asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_Posting_Date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Posting_Date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <%--------RR2------%>
                            <div class="jv-header-inline jv-header-row-grid">
                                <div class="jv-header-field-104">
                                    <asp:DropDownList ID="ddl_Issuer_Bank_info_Type" Style="width: 95px;" runat="server"
                                        TabIndex="12">
                                        <asp:ListItem Text="Cheque No." Value="CQ"></asp:ListItem>
                                        <asp:ListItem Text="DD No." Value="DD"></asp:ListItem>
                                        <asp:ListItem Text="NEFT" Value="NT"></asp:ListItem>
                                        <asp:ListItem Text="RTGS" Value="RT"></asp:ListItem>
                                        <asp:ListItem Text="Wire" Value="WR"></asp:ListItem>
                                        <asp:ListItem Text="IMPS" Value="IM"></asp:ListItem>
                                        <asp:ListItem Text="Others" Value="OT"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:TextBox ID="txt_Issuer_Bank_info_No" runat="server" Width="199px" TabIndex="13"
                                        CssClass="txtbox_none_Mid_transac_code jv-header-input" Height="22px" Style="padding: 0 4px;
                                        box-sizing: border-box;">
                                    </asp:TextBox>
                                </div>
                                <div class="jv-header-label">
                                    Date <span style="color: Red;">* </span>
                                </div>
                                <div class="jv-header-field-104">
                                    <asp:TextBox ID="txt_Issuer_Bank_info_Date" runat="server" Width="84px" CssClass="txtbox_none_Mid_transac_code jv-header-input"
                                        TabIndex="14" Height="22px" Style="padding: 0 4px; box-sizing: border-box;">
                                    </asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt_Issuer_Bank_info_Date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_Issuer_Bank_info_Date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <%--------RR3------%>
                            <div class="jv-header-inline jv-header-row-grid">
                                <div class="jv-header-label">
                                    Issuer Bank
                                </div>
                                <div class="jv-header-field-104">
                                    <asp:DropDownList ID="ddl_Issuer_Bank_Name" Style="width: 199px;" runat="server"
                                        TabIndex="15">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Axis Bank Ltd." Value="Axis Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="Bandhan Bank Ltd." Value="Bandhan Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="Bank of Baroda" Value="Bank of Baroda"></asp:ListItem>
                                        <asp:ListItem Text="Bank of India" Value="Bank of India"></asp:ListItem>
                                        <asp:ListItem Text="Bank of Maharashtra" Value="Bank of Maharashtra"></asp:ListItem>
                                        <asp:ListItem Text="Canara Bank" Value="Canara Bank"></asp:ListItem>
                                        <asp:ListItem Text="City Union Bank Ltd." Value="City Union Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="CSB Bank Ltd." Value="CSB Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="DCB Bank Ltd." Value="DCB Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="Dhanlaxmi Bank Ltd." Value="Dhanlaxmi Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="Federal Bank Ltd." Value="Federal Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="HDFC Bank Ltd" Value="HDFC Bank Ltd"></asp:ListItem>
                                        <asp:ListItem Text="ICICI Bank Ltd." Value="ICICI Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="IDBI Bank Ltd." Value="IDBI Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="IDFC First Bank Ltd." Value="IDFC First Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="Indian Bank" Value="Indian Bank"></asp:ListItem>
                                        <asp:ListItem Text="Indian Overseas Bank" Value="Indian Overseas Bank"></asp:ListItem>
                                        <asp:ListItem Text="Induslnd Bank Ltd" Value="Induslnd Bank Ltd"></asp:ListItem>
                                        <asp:ListItem Text="Jammu & Kashmir Bank Ltd." Value="Jammu & Kashmir Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="Karnataka Bank Ltd." Value="Karnataka Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="Karur Vysya Bank Ltd." Value="Karur Vysya Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="Kotak Mahindra Bank Ltd" Value="Kotak Mahindra Bank Ltd"></asp:ListItem>
                                        <asp:ListItem Text="Nainital Bank Ltd." Value="Nainital Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="Punjab National Bank" Value="Punjab National Bank"></asp:ListItem>
                                        <asp:ListItem Text="RBL Bank Ltd." Value="RBL Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="South Indian Bank Ltd." Value="South Indian Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="State Bank of India" Value="State Bank of India"></asp:ListItem>
                                        <asp:ListItem Text="Tamilnad Mercantile Bank Ltd." Value="Tamilnad Mercantile Bank Ltd."></asp:ListItem>
                                        <asp:ListItem Text="UCO Bank" Value="UCO Bank"></asp:ListItem>
                                        <asp:ListItem Text="Union Bank of India" Value="Union Bank of India"></asp:ListItem>
                                        <asp:ListItem Text="YES Bank Ltd." Value="YES Bank Ltd."></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="jv-header-label">
                                    Branch
                                </div>
                                <div class="jv-header-field-104">
                                    <asp:TextBox ID="txt_Issuer_Bank_Branch" runat="server" Width="125px" CssClass="txtbox_none_Mid_transac_code jv-header-input"
                                        TabIndex="16" Height="22px" Style="padding: 0 4px; box-sizing: border-box;">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <%--------RR3------%>
                            <div class="jv-header-inline">
                                <div class="jv-header-label">
                                    Narration</div>
                                <div class="jv-header-field-360">
                                    <asp:TextBox ID="txt_Narration" runat="server" Width="290px" TabIndex="17" CssClass="listtxt_transac_item_gen_notn jv-header-input"
                                        Height="22px" Style="padding: 0 4px; box-sizing: border-box;"></asp:TextBox>
                                </div>
                                <%-------ButtonSection--%>
                                <div class="jv-header-field-240">
                                    <asp:Button ID="btnsup" runat="server" TabIndex="18" OnClientClick="return val_OtherReceiptFields();"
                                        OnClick="btnsup_Click" Style="height: 24px; width: 109px; padding: 0 8px;" />
                                    &nbsp;
                                    <asp:Button ID="btn_OR_Delete" runat="server" Text="Delete" TabIndex="19" Visible="true"
                                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="return DeleteOtherReceipts();"
                                        Style="height: 24px; width: 109px; padding: 0 8px;" />
                                    <asp:Button ID="btnDelete" runat="server" Style="display: none;" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClick="btn_OR_Delete_Click" />
                                </div>
                                <%---END  ButtonSection --%>
                            </div>
                        </div>
                        <%------- -----END right column fields------------------------%>
                    </div>
                </div>
            </div>
            <div class="content" id="page-1" style="margin-top: -30px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 219px; width: 1150px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                            id="Page_A" runat="server"><span>Details </span></a></li>
                        <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');"
                            id="Page_B" runat="server"><span>Notes</span></a></li>
                    </ol>
                    <%------------------General-------------%>
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_new" style="width: 1130px">
                            <div id="pop_text_area_transac_popup_inn_container_left_new" style="width: 1130px;
                                height: 360px; position: relative;">
                                <div style="width: 1119px; height: 139px; overflow-x: auto; overflow-y: hidden; border: 1px solid #C8C8C8;">
                                    <asp:GridView ID="gv_details" runat="server" EmptyDataText="No Record's Found" AutoGenerateColumns="False"
                                        BackColor="WhiteSmoke" CssClass="grid-view" Width="2000px" ShowHeaderWhenEmpty="True"
                                        PageSize="15" AllowPaging="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound"
                                        OnRowCommand="gv_details_RowCommand" DataKeyNames="BORL_ID">
                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            BorderWidth="1px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Edit/Update" HeaderStyle-Width="110px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkOrg" runat="server" Text="Edit" OnClientClick='<%# "return open_OtherReceipts_Details_Update(\"" + Eval("BORL_ID") + "\", \"" + Eval("BORL_ID") + "\", \"I\");" %>'
                                                        CommandName="SelectOrganization">
                                                    </asp:LinkButton>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="dellnkOrg" runat="server" Text="Del" CommandName="DeleteRow"
                                                        CommandArgument='<%# Eval("BORL_ID") %>' OnClientClick="return del_OthRptsLineRecord(this);">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="column_style_center" Width="110px" Font-Size="12px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="LINKED_GL" HeaderText="G/L Name" HeaderStyle-Width="130px">
                                                <ItemStyle CssClass="column_style_left" Width="130px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CHARGE_NAME" HeaderText="Charge Name" HeaderStyle-Width="130px">
                                                <ItemStyle CssClass="column_style_left" Width="130px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BRANCH" HeaderText="Branch" HeaderStyle-Width="110px">
                                                <ItemStyle CssClass="column_style_left" Width="110px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AMOUNT" HeaderText="Amount (INR)" HeaderStyle-Width="70px">
                                                <ItemStyle CssClass="column_style_right" Width="70px" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DR_cR" HeaderText="Dr/Cr" HeaderStyle-Width="50px">
                                                <ItemStyle CssClass="column_style_center" Width="50px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LOB" HeaderText="LOB" HeaderStyle-Width="80px">
                                                <ItemStyle CssClass="column_style_center" Width="80px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="REF_NO" HeaderText="Ref No" HeaderStyle-Width="100px">
                                                <ItemStyle CssClass="column_style_left" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NARRATION" HeaderText="Narration" HeaderStyle-Width="160px">
                                                <ItemStyle CssClass="column_style_left" Width="160px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:HiddenField ID="hdn_Sel_JL_ID" runat="server" />
                                <asp:HiddenField ID="hdn_Sel_JV_NO" runat="server" />
                                <div class="jv-btn-bar">
                                    <asp:Button ID="btnJrnNew" runat="server" Text="New" OnClientClick="open_Acc_OtherReceipts_Entry_v1();"
                                        Visible="true" Style="width: 99px;" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-------------Notes--------------------%>
                    <div class="content" id="page-7">
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px;
                            width: 1194px; margin-top: -10px; margin-left: -18px;">
                        </div>
                    </div>
                </div>
                <%---------------------Print Button ------------------%>
                <div style="width: 1119px; text-align: right; padding: 45px 35px 10px 0;">
                    <asp:Button ID="btnrpt" runat="server" Text="Print" Width="119px" Height="25px" OnClientClick="return bankReceipts_Job_Rpt();" />
                </div>
                <div id="popupDiv" style="display: none;">
                    <iframe id="frmJournal" width="1200" height="400" frameborder="0"></iframe>
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Ch_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Group_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Imp_Exp" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript"></script>
    <script src="../Validation Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script src="../windowfiles/dhtmlwindow.js" type="text/javascript"></script>
    <script src="../modalfiles/modal.js" type="text/javascript"></script>
    <script src="../js/slide.js" type="text/javascript"></script>
    <script src="../js/jscolor.js" type="text/javascript"></script>
    <%--<script src="../js/iframepopupwin.js" type="text/javascript"></script>--%>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script type="text/javascript">
        function open_Acc_OtherReceipts_Entry_v1() {
            var orf = document.getElementById('<%= txt_BR_No_F.ClientID %>').value;
            var orm = document.getElementById('<%= txt_BR_No_M.ClientID %>').value;
            var orl = document.getElementById('<%= txt_BR_No_L.ClientID %>').value;
            var amt = document.getElementById('<%= txt_Cur_Amt.ClientID %>').value;

            NewWindow1(
                        '../Accounts_Bank/Acc_BOReceiptEntry_Details.aspx?BR_O_P=' + encodeURIComponent(orf) +
                        '&BR_O_NO=' + encodeURIComponent(orm) +
                        '&BR_O_S=' + encodeURIComponent(orl) +
                        '&AMT=' + encodeURIComponent(amt),
                        '_blank',
                        '1270',
                        '600',
                        'yes'
                    );
        }
    </script>
    <script type="text/javascript">
        function formatDecimal(txt) {
            var num = parseFloat(txt.value);
            txt.value = isNaN(num) ? "0.00" : num.toFixed(2);
        }
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });
        function close_button() {
            document.getElementById("General").click();
        }
        window.onload = function () {
            Load_Jobno_CusName();
        };


        /* required functions  after clean code
        function del_OthRptsLineRecord(btn) {                 
        jQuery('#form1').validationEngine('hideAll');
        jConfirm('Are you sure you want to delete this Line record?', 'Other Receipts Entry', function (r) {
        if (r) {
        btn.onclick = null;
        btn.click();
        }
        });
        return false;
        }
        */

        function del_OthRptsLineRecord(borlineID) {
            jQuery('#form1').validationEngine('hideAll');
            jConfirm('Are you sure you want to delete this record?', 'Other Receipts Entry', function (r) {
                if (r) {
                    document.getElementById('<%= HDupdate_id.ClientID %>').value = borlineID;
                    document.getElementById('btn3').click();
                }
            });
            return false;
        }
        
    </script>
    <script type="text/javascript">
        function DeleteOtherReceipts() {
            // jQuery('#form1').validationEngine('hideAll');

            jConfirm(
        'Are you sure you want to delete this Other Receipts Transaction?',
        'Other Receipts',
        function (r) {
            if (r) {
                document.getElementById('<%= btnDelete.ClientID %>').click();
            }
        });
            return false;
        }
    </script>
    <script type="text/javascript">
        function bankReceipts_Job_Rpt() {
            var BR_F = document.getElementById('<%= txt_BR_No_F.ClientID %>').value.trim();
            var BR_M = document.getElementById('<%= txt_BR_No_M.ClientID %>').value.trim();
            var BR_L = document.getElementById('<%= txt_BR_No_L.ClientID %>').value.trim();

            NewWindow1('../Accounts_Bank_Report/Acc_BankReceipt_OtherReceipt_Rpt.aspx?BR_P=' + encodeURIComponent(BR_F) + '&BR_NO=' + encodeURIComponent(BR_M) + '&BR_S=' + encodeURIComponent(BR_L), 'List', '870', '1024', 'yes');
            return false;
        } 
    </script>
</body>
</html>
