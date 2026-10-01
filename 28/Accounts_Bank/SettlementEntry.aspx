<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SettlementEntry.aspx.cs"
    Inherits="SettlementEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Settlement Entry</title>
     <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
     <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css" />
    <!-- jQuery core MUST load before jQuery UI -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script src="../js/Accounts/Acc_listpopup.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
            font-family: Arial, Tahoma, sans-serif;
            font-size: 12px;
        }
        #pageWrapper
        {
            width: 100%;
        }
        
        /* Top task bar */
        .taskBar
        {
            color: #fff;
            padding: 6px 10px;
            font-weight: bold;
        }
        
        .headerRow
        {
            padding: 8px 10px 4px 10px;
            border-bottom: 1px solid #ccc;
            max-width: 1200px;
        }
        
        .rowFloat
        {
            overflow: hidden;
            width: 100%;
            min-height: 26px;
            margin-bottom: 4px;
            margin-top: -5px;
        }
        
        .rowFloat .leftGroup
        {
            float: left;
            display: flex;
            align-items: center;
        }
        
        .rowFloat .rightGroup
        {
            float: right;
            display: flex;
            align-items: center;
            width: 420px;
            margin-right: 57px;
        }
        
        .rowFloat .lblCol
        {
            color: #b03030;
            font-weight: bold;
            white-space: nowrap;
            padding-right: 4px;
        }
        
        .rowFloat .valCol
        {
            padding-right: 10px;
        }
        @media (max-width: 900px)
        {
            .rowFloat .leftGroup, .rowFloat .rightGroup
            {
                float: none;
                width: 100%;
                margin-bottom: 6px;
            }
            .headerRow
            {
                max-width: 100%;
            }
        }
        .tabStrip
        {
            background-color: #dfe6ee;
            padding: 4px 10px;
            border-bottom: 1px solid #ccc;
        }
        .tabStrip a
        {
            margin-right: 15px;
            text-decoration: none;
            color: #333;
            font-weight: bold;
            cursor: pointer;
            padding-bottom: 3px;
        }
        .tabStrip a.active
        {
            color: #1a5fb4;
            border-bottom: 2px solid #1a5fb4;
        }
        .tabPage
        {
            display: none;
        }
        .tabPage.active
        {
            display: block;
        }
        .notesArea
        {
            padding: 15px 10px;
        }
        
        /* Section panel (Unsettled Credits / Debits) */
        .sectionPanel
        {
            margin: 8px 10px;
            border: 1px solid #b7c6d9;
        }
        .sectionHeader
        {
            padding: 5px 8px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
        .leftHeader
        {
            display: flex;
            align-items: center;
            gap: 12px; /* Space between text and dropdown */
        }
        .sectionHeader select
        {
            min-width: 100px;
        }
        
        .filterRow
        {
            background-color: #f2f5f9;
            padding: 5px 8px;
            display: flex;
            align-items: center;
            gap: 10px;
            flex-wrap: wrap;
        }
        .filterRow label
        {
            font-size: 11px;
            color: #333;
            margin-right: 3px;
        }
        
        .gridScroll
        {
            height: 188px;
            overflow-y: auto;
            overflow-x: auto;
            position: relative;
        }
        
        .grid-view
        {
            table-layout: fixed;
            border-collapse: collapse;
        }
        .grid-view th
        {
            position: sticky;
            top: 0;
            z-index: 2;
            background-color: #eef1f5;
            border: 1px solid #d6dde5;
            padding: 4px 6px;
            text-align: center;
            font-size: 11px;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
            border: 1px solid black;
        }
        .grid-view td
        {
            border: 1px solid #767779;
            padding: 4px 6px;
            font-size: 11px;
            white-space: nowrap;
        }
        .settleInput
        {
            text-align: right;
        }
        .field-invalid
        {
            border: 1px solid #d9534f !important;
            background-color: #fdecea !important;
        }
        .totalRow
        {
            background-color: #f2f5f9;
            padding: 5px 8px;
            display: flex;
            justify-content: space-between;
            font-weight: bold;
        }
        .addLink
        {
            color: #1a5fb4;
            text-decoration: none;
            font-weight: bold;
        }
        
        /* Footer */
        .footerBar
        {
            padding: 8px 10px;
            text-align: right;
            border-top: 1px solid #ccc;
        }
        .footerBar input[type=button], .footerBar input[type=submit]
        {
            padding: 5px 18px;
            margin-left: 6px;
            cursor: pointer;
        }
        
        .grid-view tr.rowSelected td
        {
            background-color: #cfe8ff !important;
        }
        .grid-view tr.gridFooterRow td
        {
            position: sticky;
            bottom: 0;
            z-index: 2;
            background-color: #d6d8db; /* #f2f5f9;*/
            border-top: 2px solid #8cb4e7; /*#b7c6d9;*/
        }
        #lblOrgnation
        {
            color: #b03030;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <div id="pageWrapper">
        <asp:UpdatePanel ID="SettlementPanel" runat="server">
            <ContentTemplate>
                <div class="taskBar">
                    <span>Task : New</span>
                </div>
                <div class="headerRow">
                    <div class="rowFloat">
                        <div class="leftGroup">
                            <div class="lblCol" style="width: 90px; margin-right: 68px;">
                                Trans. No.</div>
                            <div class="valCol" style="display: flex; gap: 10px;">
                                <asp:TextBox ID="txtTransPrefix" runat="server" Style="width: 114px;" CssClass="txtbox_none"
                                    ReadOnly="true" TabIndex="1" />
                                <asp:TextBox ID="txtTransNo" runat="server" ReadOnly="true" Style="width: 75px;"
                                    TabIndex="2" CssClass="txtbox_none" />
                                <asp:TextBox ID="txtperiod" runat="server" ReadOnly="true" Style="width: 144px;"
                                    CssClass="txtbox_none" TabIndex="3" />
                            </div>
                        </div>
                        <div class="rightGroup">
                            <div class="lblCol" style="width: 49px; margin-right: 40px;">
                                Entry Date</div>
                            <div class="valCol" style="width: 88px; margin-right: 42px;">
                                <asp:TextBox ID="txtEntryDate" runat="server" Width="90px" CssClass="txtbox_none"
                                    TabIndex="4" />
                                <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtEntryDate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender100" runat="server" TargetControlID="txtEntryDate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div class="lblCol" style="width: 72px;">
                              Posting Date   <span style="color:Red">*</span></div>
                            <div class="valCol" style="width: 100px;margin-left: 10px;">
                                <asp:TextBox ID="txtPostingDate" runat="server" Width="90px" CssClass="validate[required] txtbox_none"
                                    TabIndex="5" />
                                <cc1:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txtPostingDate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPostingDate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                    </div>
                    <div class="rowFloat">
                        <div class="leftGroup">
                            <div class="lblCol" style="width: 90px; margin-right: 69px;">
                                Settlement Type</div>
                            <div class="valCol" style="width: 177px;">
                                <asp:DropDownList ID="ddlSettlementType" Width="157" runat="server" onchange="ClearOrganizationControl();"
                                    CssClass="txtbox_none">
                                    <asp:ListItem Text="Customer" Value="CUSTOMER" />
                                    <asp:ListItem Text="Vendor" Value="VENDOR" />
                                </asp:DropDownList>
                            </div>
                            <div class="lblCol" style="width: 28px;">
                                TDS</div>
                            <div class="valCol" style="width: 120px;">
                                <asp:DropDownList ID="ddlTDS" runat="server" Width="150px">
                                    <asp:ListItem Text="None" Value="" />
                                    <asp:ListItem Text="194 H" Value="194 H"></asp:ListItem>
                                    <asp:ListItem Text="194 C" Value="194 C"></asp:ListItem>
                                    <asp:ListItem Text="194 A" Value="194 A"></asp:ListItem>
                                    <asp:ListItem Text="194 I" Value="194 I"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="rowFloat">
                        <div class="leftGroup">
                            <div class="valCol" style="width: 153px;">
                                <asp:Label ID="lblOrgnation" runat="server" Text="Organization"></asp:Label>
                            </div>
                            <div class="valCol">
                                <div style="display: flex; gap: 10px">
                                    <asp:TextBox ID="txtOrgnaizationName" Style="width: 365px" CssClass="txtbox_none"
                                        ClientIDMode="Static" TabIndex="6" runat="server"></asp:TextBox>
                                    <a href="#" class="magnfy" onclick="openOrganizationClientName(document.getElementById('<%= ddlSettlementType.ClientID %>').value); return false;">
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="rightGroup" style="align-items: flex-start;">
                            <div class="lblCol" style="width: 90px; padding-top: 4px;">
                                Narration</div>
                            <div class="valCol" style="width: 320px;">
                                <asp:TextBox ID="txtNarration" TextMode="MultiLine" runat="server" CssClass="txtbox_none_mid_size"
                                    TabIndex="7" Rows="2" Style="width: 100%; height: 34px; resize: both; overflow: auto;" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="tabStrip">
                    <a id="tabDetails" class="active" onclick="showTab('Details');return false;">Details</a>
                    <a id="tabNotes" onclick="showTab('Notes');return false;">Notes</a>
                </div>
                <div id="pageDetails" class="tabPage active">
                    <div class="sectionPanel">
                        <div class="sectionHeader">
                            <div class="leftHeader">
                                <span>Unsettled Credits</span>
                                <asp:DropDownList ID="ddlCreditsSelf" CssClass="txtbox_none" runat="server">
                                    <asp:ListItem Text="Self" Value="Self" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="filterRow">
                            <label>
                                Show Txns</label>
                            <asp:TextBox ID="txtCreditsFromDate" runat="server" CssClass="txtbox_none_Mid_transac_Inv_No"
                                TabIndex="8" Width="70px" />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txtCreditsFromDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCreditsFromDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            -
                            <asp:TextBox ID="txtCreditsToDate" runat="server" Width="70px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                TabIndex="9" />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txtCreditsToDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtCreditsToDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <label>
                                Location</label>
                            <asp:DropDownList ID="ddlCreditsLocation" runat="server" CssClass="txtbox_none" TabIndex="10"
                                Style="width: 125px">
                                <asp:ListItem Text="All" Value="" />
                            </asp:DropDownList>
                            <label>
                                Branch</label>
                            <asp:DropDownList ID="ddlCreditsBranch" runat="server" Width="130px" TabIndex="11"
                                CssClass="txtbox_none">
                                <asp:ListItem Text="All" Value="" />
                            </asp:DropDownList>
                            <label>
                                Currency</label>
                            <asp:DropDownList ID="ddlCreditsCurrency" Width="60px" runat="server" TabIndex="12"
                                CssClass="txtbox_none">
                                <asp:ListItem Text="INR" Value="INR" />
                            </asp:DropDownList>
                            <label>
                                Rows</label>
                            <asp:TextBox ID="txtCreditsRows" Width="40px" CssClass="txtbox_none_mid_size" TabIndex="13"
                                runat="server" Text="50" />
                            <label>
                                Sort on</label>
                            <asp:DropDownList ID="ddlCreditsSort" Width="141px" runat="server" CssClass="txtbox_none"
                                TabIndex="14">
                                <asp:ListItem Text="Location" Value="Location" />
                            </asp:DropDownList>
                            <asp:Button ID="btnCreditsRetrieve" runat="server" Text="Retrieve" OnClick="btnCreditsRetrieve_Click"
                                TabIndex="15" />
                        </div>
                        <div class="gridScroll">
                            <asp:GridView runat="server" ID="gvCredits" AutoGenerateColumns="False" CssClass="grid-view"
                                ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%" EmptyDataText="NO RECORD FOUND"
                                OnRowCreated="gvCredits_RowCreated" OnRowDataBound="gvCredits_RowDataBound" OnDataBound="gvCredits_DataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="30px" HeaderStyle-Width="30px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAllCredits" runat="server" ClientIDMode="Static" onclick="ToggleAllCheckboxes(this, 'rowCheckCredits');" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelectCredit" runat="server" CssClass="rowCheckCredits" onclick="ToggleRowState(this); CheckHeaderCheckbox(this, 'rowCheckCredits', 'chkSelectAllCredits');" />
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtLocation" Text='<%# Bind("C_LOCATION") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="90px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtDocument" Text='<%# Bind("DOCUMENT") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trns No." HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtTransNo" Text='<%# Bind("TRANSNO") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="90px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtTxndate" Text='<%# Bind("C_DATE", "{0:dd/MM/yyyy}") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="90px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transaction Amount (INR)" HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtTransactionAmount" Text='<%# Bind("TRANSACTIONAMOUNT", "{0:N2}") %>'
                                                runat="server"></asp:Literal><span>&nbsp;INR</span>
                                        </ItemTemplate>
                                        <ItemStyle Width="140px" HorizontalAlign="Right" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Outstanding Amount (INR)" HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <span class="js-outstanding">
                                                <asp:Literal ID="txtOutstandingAmount" Text='<%# Bind("OUTSTANDINGAMOUNT", "{0:N2}") %>'
                                                    runat="server"></asp:Literal><span>&nbsp;INR</span> </span>
                                            <asp:HiddenField ID="hdnOutstanding" runat="server" Value='<%# Eval("OUTSTANDINGAMOUNT", "{0:N2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="140px" HorizontalAlign="Right" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <span>&nbsp;CR</span>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" HorizontalAlign="Right" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Settlement (INR)" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCreditSettlement" runat="server" CssClass="settleInput creditSettle"
                                                Text='<%# Eval("SETTLEMENTAMOUNT", "{0:N2}") %>' Width="70px" data-txn='<%# Eval("TRANSACTIONAMOUNT") %>'
                                                data-outstanding='<%# Eval("OUTSTANDINGAMOUNT") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblCreditsSettlementTotal" runat="server" ClientIDMode="Static" Text="0.00" />
                                            <span>CR</span>
                                        </FooterTemplate>
                                        <ItemStyle Width="140px" HorizontalAlign="Right" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Balance Amount(INR)" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <span class="js-balance">
                                                <asp:Literal ID="txtBalance" Text='<%# Bind("BALANCEAMOUNT", "{0:N2}") %>' runat="server"></asp:Literal>
                                            </span><span>&nbsp;INR</span>
                                            <asp:HiddenField ID="hdnBalance" runat="server" Value='<%# Eval("BALANCEAMOUNT", "{0:N2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="130px" HorizontalAlign="Right" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtBranch" Text='<%# Bind("BRANCH") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="90px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Narration" HeaderStyle-Width="300px">
                                        <ItemTemplate>
                                            <asp:Label ID="txtNarration" Text='<%# Bind("NARRATION") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="300px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="totalRow">
                            <a href="#" class="addLink">Add</a> <span>Total&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblCreditsTotal" runat="server" Text="0.00" ClientIDMode="Static" />
                                CR </span>
                        </div>
                    </div>
                    <div class="sectionPanel">
                        <div class="sectionHeader">
                            <div class="leftHeader">
                                <span>Unsettled Debits of</span>
                                <asp:DropDownList ID="ddlDebitsSelf" CssClass="txtbox_none" runat="server">
                                    <asp:ListItem Text="Self" Value="Self" />
                                </asp:DropDownList>
                            </div>
                            <span>Unsettled Amount
                                <asp:Label ID="lblUnsettledAmount" runat="server" Text="0.00" ClientIDMode="Static" />
                                INR </span>
                        </div>
                        <div class="filterRow">
                            <label>
                                Show Txns</label>
                            <asp:TextBox ID="txtDebitsFromDate" runat="server" Width="70px" CssClass="txtbox_none_mid_size"
                                TabIndex="16" />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender15" runat="server" TargetControlID="txtDebitsFromDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDebitsFromDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            -
                            <asp:TextBox ID="txtDebitsToDate" runat="server" Width="70px" CssClass="txtbox_none_mid_size"
                                TabIndex="17" />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender16" runat="server" TargetControlID="txtDebitsToDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDebitsToDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <label>
                                Location</label>
                            <asp:DropDownList ID="ddlDebitsLocation" runat="server" CssClass="txtbox_none" Width="125px"
                                TabIndex="18">
                                <asp:ListItem Text="All" Value="" />
                            </asp:DropDownList>
                            <label>
                                Branch</label>
                            <asp:DropDownList ID="ddlDebitsBranch" runat="server" CssClass="txtbox_none" Width="130px"
                                TabIndex="19">
                                <asp:ListItem Text="All" Value="" />
                            </asp:DropDownList>
                            <label>
                                Currency</label>
                            <asp:DropDownList ID="ddlDebitCurrency" Width="60px" runat="server" CssClass="txtbox_none"
                                TabIndex="20">
                                <asp:ListItem Text="INR" Value="INR" />
                            </asp:DropDownList>
                            <label>
                                Rows</label>
                            <asp:TextBox ID="txtDebitsRows" CssClass="txtbox_none_mid_size" runat="server" Width="40px"
                                TabIndex="21" Text="50" />
                            <label>
                                Sort on</label>
                            <asp:DropDownList ID="ddlDebitsSort" runat="server" CssClass="txtbox_none" Width="141px"
                                TabIndex="22">
                                <asp:ListItem Text="Location" Value="Location" />
                            </asp:DropDownList>
                            <asp:Button ID="btnDebitsRetrieve" runat="server" Text="Retrieve" OnClick="btnDebitsRetrieve_Click"
                                TabIndex="23" />
                            <asp:Button ID="btnAutoSettle" runat="server" Text="Auto Settle" OnClick="btnAutoSettle_Click"
                                TabIndex="24" />
                        </div>
                        <div class="gridScroll">
                            <asp:GridView runat="server" ID="gvDebits" AutoGenerateColumns="False" CssClass="grid-view"
                                ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%" EmptyDataText="NO RECORD FOUND"
                                OnRowCreated="gvDebits_RowCreated" OnRowDataBound="gvDebits_RowDataBound" OnDataBound="gvDebits_DataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="30px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAllDebits" Visible="false" runat="server" onclick="ToggleAllCheckboxes(this, 'rowCheckDebits');" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelectDebit" runat="server" CssClass="rowCheckDebits" onclick="ToggleRowState(this);" />
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location" HeaderStyle-Width="105px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtLocation2" Text='<%# Bind("V_LOCATION") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="105px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtGvDebitDocument" Text='<%# Bind("DOCUMENT") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="110px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trns No." HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtGvDebit_TransNo" Text='<%# Bind("TRANSNO") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="130px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtDebit_TxnDate" Text='<%# Bind("V_DATE", "{0:dd/MM/yyyy}") %>'
                                                runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="90px" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jobs" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtDebit_jobs" Text='<%# Bind("JOBS") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="REFNO" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtRefNo" Text='<%# Bind("REFNO") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ref Date" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txtRefDate" Text='<%# Bind("REFDATE","{0:dd/MM/yyyy}") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transaction Amount(INR)" HeaderStyle-Width="126px">
                                        <ItemTemplate>
                                            <asp:Literal ID="lit_GvDebit_transAmt" Text='<%# Bind("TRANSACTIONAMOUNT", "{0:N2}") %>'
                                                runat="server"></asp:Literal><span>&nbsp;INR</span>
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#CCCCCC" HorizontalAlign="Right" Width="140px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Outstanding Amount(INR)" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <span class="js-outstanding">
                                                <asp:Literal ID="lblDebitOutstanding" Text='<%# Eval("OUTSTANDINGAMOUNT", "{0:N2}") %>'
                                                    runat="server"></asp:Literal></span><span> INR</span>
                                            <asp:HiddenField ID="hdnDebitOutstandingAmount" Value='<%# Eval("OUTSTANDINGAMOUNT", "{0:N2}") %>'
                                                runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblDebitsOutstandingTotal" Visible="false" runat="server" Text="0.00" />
                                            <span runat="server" visible="false">DR</span>
                                        </FooterTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Right" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <span>DR</span>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" HorizontalAlign="Right" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Settlement(INR)" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDebitSettleINR" runat="server" CssClass="settleInput debitSettleINR"
                                                Text='<%# Eval("SETTLEMENT", "{0:N2}") %>' Width="70px" data-txn='<%# Eval("TRANSACTIONAMOUNT") %>'
                                                data-outstanding='<%# Eval("OUTSTANDINGAMOUNT") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblDebitsSettlementTotal" runat="server" ClientIDMode="Static" Text="0.00" />
                                            <span id="Span2" runat="server">DR</span>
                                        </FooterTemplate>
                                        <ItemStyle Width="120px" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Balance Amount(INR)" HeaderStyle-Width="117px">
                                        <ItemTemplate>
                                            <span class="js-balance">
                                                <asp:Literal ID="lblDebitBalance" Text='<%# Eval("BALANCEAMOUNT", "{0:N2}") %>' runat="server"></asp:Literal><span>&nbsp;INR</span></span>
                                            <asp:HiddenField ID="hdnDebitbalanceAmount" Value='<%# Eval("BALANCEAMOUNT", "{0:N2}") %>'
                                                runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblDebitsBalanceTotal" Visible="false" runat="server" Text="0.00" />
                                            <span id="Span3" runat="server" visible="false">DR</span>
                                        </FooterTemplate>
                                        <ItemStyle Width="105px" HorizontalAlign="Right" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TDS" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGvDebitsTDS" CssClass="debitTDS settleInput" runat="server" Style="width: 72px;
                                                text-align: right;" Text='<%# Bind("TDS") %>'></asp:TextBox><span> INR</span>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalTDS" runat="server" ClientIDMode="Static" Text="0.00" />
                                            <span runat="server">DR</span>
                                        </FooterTemplate>
                                        <ItemStyle Width="80px" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:Literal ID="LitGvDebitBranch" Text='<%# Bind("BRANCH") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="90px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Narration" HeaderStyle-Width="300px">
                                        <ItemTemplate>
                                            <asp:Label ID="LtlGvDebitNarration" runat="server" Text='<%# Bind("NARRATION") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="300px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="totalRow">
                            <a href="#" class="addLink">Add</a> <span>Total&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblDebitsTotal" runat="server" Text="0.00" ClientIDMode="Static" />
                            </span>
                        </div>
                    </div>
                    <div class="footerBar">
                        <label id="Label1" runat="server" visible="false">
                            Rounding</label>
                        <asp:TextBox ID="txtRounding" runat="server" Visible="false" Width="70px" Text="0.00"
                            CssClass="txtbox_none_mid_size" TabIndex="25" />
                        <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="window.close(); return false;"
                            TabIndex="26" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return Validation()" TabIndex="27" />
                        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="return Settlement_Report();" />
                    </div>
                </div>
                <div id="pageNotes" class="tabPage">
                    <div class="notesArea">
                        <asp:TextBox ID="txtNotes" runat="server" CssClass="txtbox_none_mid_size" TextMode="MultiLine"
                            Width="98%" Height="300px" />
                    </div>
                    <div class="footerBar">
                        <asp:Button ID="btnCloseNotes" runat="server" Text="Close" OnClientClick="window.close(); return false;" />
                        <asp:Button ID="btnSaveNotes" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
    <script type="text/javascript">
        function showTab(name) {
            var details = document.getElementById('pageDetails');
            var notes = document.getElementById('pageNotes');
            var tabDetails = document.getElementById('tabDetails');
            var tabNotes = document.getElementById('tabNotes');

            if (name === 'Details') {
                details.className = 'tabPage active';
                notes.className = 'tabPage';
                tabDetails.className = 'active';
                tabNotes.className = '';
            } else {
                details.className = 'tabPage';
                notes.className = 'tabPage active';
                tabDetails.className = '';
                tabNotes.className = 'active';
            }
        }

        var saveLockedByserver = false;

        function parseAmt(val) {
            if (val === null || val === undefined || val === '') return 0;
            var num = parseFloat(val.toString().replace(/,/g, ''));
            return isNaN(num) ? 0 : num;
        }

        function setText(el, val) {
            if (el) el.textContent = parseAmt(val).toFixed(2);
        }

        function tableIdOf(row) {
            var table = row ? row.closest('table') : null;
            return table ? table.id : null;
        }

        function getRowCheckbox(row) {
            return row ? row.querySelector('input[type="checkbox"]') : null;
        }


        function getCheckboxInputsByClass(targetClass) {
            var result = [];
            var nodes = document.getElementsByClassName(targetClass);

            for (var i = 0; i < nodes.length; i++) {
                var node = nodes[i];
                var input = null;

                if (node.tagName && node.tagName.toLowerCase() === 'input' &&
                    node.type && node.type.toLowerCase() === 'checkbox') {
                    input = node;
                } else if (node.querySelector) {
                    input = node.querySelector('input[type="checkbox"]');
                }

                if (input) result.push(input);
            }

            return result;
        }

        function getCheckboxByStaticId(controlId) {
            var node = document.getElementById(controlId);
            if (!node) return null;

            if (node.tagName && node.tagName.toLowerCase() === 'input' &&
                node.type && node.type.toLowerCase() === 'checkbox') {
                return node;
            }

            return node.querySelector ? node.querySelector('input[type="checkbox"]') : null;
        }

        function getCalculationBase(settleInput) {
            if (!settleInput) return 0;

            var explicitBase = settleInput.getAttribute('data-calcbase');
            if (explicitBase !== null && explicitBase !== '') {
                return parseAmt(explicitBase);
            }

            var outstanding = parseAmt(settleInput.getAttribute('data-outstanding'));
            var transaction = parseAmt(settleInput.getAttribute('data-txn'));
            return outstanding > 0 ? outstanding : transaction;
        }

        function getDebitTds(row) {
            var tdsInput = row ? row.querySelector('.debitTDS') : null;
            return tdsInput ? Math.max(parseAmt(tdsInput.value), 0) : 0;
        }


        function recalcRow(row) {
            if (!row) return 0;

            var tableId = tableIdOf(row);
            var settleInput = tableId === 'gvDebits'
                ? row.querySelector('.debitSettleINR')
                : row.querySelector('.creditSettle');

            if (!settleInput) return 0;

            var calcBase = getCalculationBase(settleInput);
            var settlement = Math.max(parseAmt(settleInput.value), 0);
            var tds = tableId === 'gvDebits' ? getDebitTds(row) : 0;

            var outstanding = Math.max(calcBase - settlement - tds, 0);
            var balance = Math.max(calcBase - settlement - tds, 0);

            setText(row.querySelector('.js-outstanding'), outstanding);
            setText(row.querySelector('.js-balance'), balance);

            var hiddenBalance = row.querySelector(
                'input[name$="hdnBalance"], input[name$="hdnDebitbalanceAmount"]'
            );
            if (hiddenBalance) hiddenBalance.value = balance.toFixed(2);

            return balance;
        }

        function displayRowFromServer(row) {

            if (!row) return;

            var tableId = tableIdOf(row);
            var settleInput = tableId === 'gvDebits'
                ? row.querySelector('.debitSettleINR')
                : row.querySelector('.creditSettle');
            if (!settleInput) return;

            var calcBase = getCalculationBase(settleInput);
            // var tds = tableId === 'gvDebits' ? getDebitTds(row) : 0;

            var outstanding = Math.max(calcBase, 0);

            var balance = Math.max(calcBase, 0);

            setText(row.querySelector('.js-outstanding'), outstanding);
            setText(row.querySelector('.js-balance'), balance);

            var hiddenBalance = row.querySelector(
                'input[name$="hdnBalance"], input[name$="hdnDebitbalanceAmount"]'
            );
            if (hiddenBalance) hiddenBalance.value = balance.toFixed(2);
        }


        function sumChecked(inputClass) {
            var total = 0;
            var inputs = document.querySelectorAll('.' + inputClass);

            for (var i = 0; i < inputs.length; i++) {
                var row = inputs[i].closest('tr');
                var checkbox = getRowCheckbox(row);
                if (checkbox && checkbox.checked) {
                    total += Math.max(parseAmt(inputs[i].value), 0);
                }
            }

            return total;
        }

        function updateCreditsTotal() {
            var total = sumChecked('creditSettle');
            setText(document.getElementById('lblCreditsSettlementTotal'), total);
            setText(document.getElementById('lblCreditsTotal'), total);
        }

        function updateDebitsTotals() {
            var settlementTotal = sumChecked('debitSettleINR');
            var tdsTotal = sumChecked('debitTDS');

            setText(document.getElementById('lblDebitsSettlementTotal'), settlementTotal);
            setText(document.getElementById('lblTotalTDS'), tdsTotal);

            setText(document.getElementById('lblDebitsTotal'), settlementTotal + tdsTotal);
        }



        function creditsCheckedTotal() {
            return sumChecked('creditSettle');
        }

        function selectedDebitBaseTotal() {
            var total = 0;
            var table = document.getElementById('gvDebits');
            if (!table) return total;

            var rows = table.querySelectorAll('tr');
            for (var i = 0; i < rows.length; i++) {
                var checkbox = getRowCheckbox(rows[i]);
                var settleInput = rows[i].querySelector('.debitSettleINR');

                if (checkbox && checkbox.checked && settleInput) {
                    total += getCalculationBase(settleInput);
                }
            }

            return total;
        }



        function calculateUnsettledAmount() {

            var creditTotal = creditsCheckedTotal();
            var settlement = sumChecked('debitSettleINR') + sumChecked('debitTDS');

            return creditTotal - settlement;

        }

        function updateUnsettledAmount() {
            var label = document.getElementById('lblUnsettledAmount');
            if (!label) return;
            var unsettledAmount = calculateUnsettledAmount();

            setText(label, unsettledAmount);
            var wasInvalid = label.classList.contains('field-invalid');
            if (Math.abs(unsettledAmount) > 0.004) {
                label.classList.add('field-invalid');
            }
            else if (wasInvalid) {
                label.classList.remove('field-invalid');
            }
            updateSaveButtonState();
        }


        // Proposes a Settlement amount for ONE debit row that has just been
        // checked and has no amount in it yet. Never reads from or writes to
        // any other row's Settlement box directly — it only READS the current
        // (whatever it is: manually typed, previously proposed, doesn't matter)
        // values of OTHER already-checked debit rows to figure out how much of
        // the selected credit pool is left, so this row's own proposal doesn't
        // double-count credit that's already spoken for. It never rewrites them.
        function computeDebitAutoFillAmount(row) {
            var settleInput = row ? row.querySelector('.debitSettleINR') : null;
            if (!settleInput) return 0;

            var calcBase = getCalculationBase(settleInput);
            var tds = Math.min(getDebitTds(row), calcBase);
            var amountPayableThroughBank = Math.max(calcBase - tds, 0);

            var creditCheckboxes = getCheckboxInputsByClass('rowCheckCredits');
            var anyCreditsChecked = false;
            for (var c = 0; c < creditCheckboxes.length; c++) {
                if (creditCheckboxes[c].checked) {
                    anyCreditsChecked = true;
                    break;
                }
            }

            if (!anyCreditsChecked) {
                return amountPayableThroughBank;
            }

            var availableCredit = creditsCheckedTotal();
            var debitTable = document.getElementById('gvDebits');
            if (debitTable) {
                var rows = debitTable.querySelectorAll('tr');
                for (var i = 0; i < rows.length; i++) {
                    var otherRow = rows[i];
                    if (otherRow === row) continue;

                    var otherCheckbox = getRowCheckbox(otherRow);
                    var otherSettle = otherRow.querySelector('.debitSettleINR');
                    if (otherCheckbox && otherCheckbox.checked && otherSettle) {
                        availableCredit -= Math.max(parseAmt(otherSettle.value), 0);
                    }
                }
            }

            return Math.min(amountPayableThroughBank, Math.max(availableCredit, 0));
        }

        function recalcTotalsForRow(row) {
            var tableId = tableIdOf(row);
            if (tableId === 'gvCredits') {
                updateCreditsTotal();
            } else if (tableId === 'gvDebits') {
                updateDebitsTotals();
            }
        }



        function getSaveButtons() {
            var ids = ['<%= btnSave.ClientID %>', '<%= btnSaveNotes.ClientID %>'];
            var result = [];
            for (var i = 0; i < ids.length; i++) {
                var el = document.getElementById(ids[i]);
                if (el) result.push(el);
            }
            return result;
        }

        function updateSaveButtonState() {
            var buttons = getSaveButtons();
            if (saveLockedByserver) {
                for (var j = 0; j < buttons.length; j++) {
                    buttons[j].disabled = true;
                }
                return;
            }

            var disable = document.querySelectorAll('.field-invalid').length > 0;
            for (var i = 0; i < buttons.length; i++) {
                buttons[i].disabled = disable;
            }
        }

        function validateSettleAgainstOutstanding(input) {
            if (!input || !input.classList) return true;
            var isCredit = input.classList.contains('creditSettle');
            var isDebit = input.classList.contains('debitSettleINR');
            if (!isCredit && !isDebit) return true;

            var outstanding = getCalculationBase(input);
            var entered = parseAmt(input.value);
            var wasInvalid = input.classList.contains('field-invalid');

            if (entered > outstanding + 0.004) {
                if (!wasInvalid) {
                    input.classList.add('field-invalid');
                    alert('Settlement amount cannot be greater than the Outstanding Amount (' + outstanding.toFixed(2) + ').');
                }
                updateSaveButtonState();
                return false;
            }

            if (wasInvalid) {
                input.classList.remove('field-invalid');
                updateSaveButtonState();
            }
            return true;
        }


        function validateDebitTds(row, tdsInput) {
            if (!row || !tdsInput) return true;

            var settleInput = row.querySelector('.debitSettleINR');
            if (!settleInput) return true;

            var calcBase = getCalculationBase(settleInput);
            var settlement = Math.max(parseAmt(settleInput.value), 0);
            var room = Math.max(calcBase - settlement, 0);
            var entered = Math.max(parseAmt(tdsInput.value), 0);
            var wasInvalid = tdsInput.classList.contains('field-invalid');

            if (entered > room + 0.004) {
                if (!wasInvalid) {
                    tdsInput.classList.add('field-invalid');
                    alert('TDS amount cannot be greater than the Balance Amount (' + room.toFixed(2) + ').');
                }
                updateSaveButtonState();
                return false;
            }

            if (wasInvalid) {
                tdsInput.classList.remove('field-invalid');
                updateSaveButtonState();
            }
            return true;
        }



        function ToggleRowState(checkbox, suppressFinalAllocation) {
            var row = checkbox ? checkbox.closest('tr') : null;
            if (!row) return;

            var tableId = tableIdOf(row);
            var settleInput = tableId === 'gvDebits'
                ? row.querySelector('.debitSettleINR')
                : row.querySelector('.creditSettle');
            var enableOnly = row.querySelectorAll('.settleEnable');

            if (checkbox.checked) {
                row.classList.add('rowSelected');

                if (settleInput) {
                    if (tableId === 'gvCredits') {
                        settleInput.value = getCalculationBase(settleInput).toFixed(2);
                    } else if (tableId === 'gvDebits') {
                        // Only propose an amount if this row doesn't already have
                        // one — checking THIS row must never rewrite any OTHER
                        // row's Settlement box.
                        var currentVal = parseAmt(settleInput.value);
                        if (currentVal <= 0) {
                            settleInput.value = computeDebitAutoFillAmount(row).toFixed(2);
                        }
                    }
                }

                for (var i = 0; i < enableOnly.length; i++) {
                    enableOnly[i].disabled = false;
                }
            } else {
                row.classList.remove('rowSelected');

                if (settleInput) settleInput.value = '';

                for (var j = 0; j < enableOnly.length; j++) {
                    enableOnly[j].disabled = true;
                }

                if (tableId === 'gvDebits') {
                    var tdsInput = row.querySelector('.debitTDS');
                    if (tdsInput) {
                        var originalTds = parseAmt(tdsInput.getAttribute('data-tds-original'));
                        tdsInput.value = originalTds.toFixed(2);
                    }
                }
            }

            recalcRow(row);
            recalcTotalsForRow(row);

            if (tableId === 'gvCredits') {
                CheckHeaderCheckbox(checkbox, 'rowCheckCredits', 'chkSelectAllCredits');
            }

            if (!suppressFinalAllocation) {
                updateUnsettledAmount();
            }
        }


        document.addEventListener('input', function (e) {
            if (!e.target.classList) return;

            var isCreditSettlement = e.target.classList.contains('creditSettle');
            var isDebitSettlement = e.target.classList.contains('debitSettleINR');
            var isDebitTds = e.target.classList.contains('debitTDS');

            if (!isCreditSettlement && !isDebitSettlement && !isDebitTds) return;

            var row = e.target.closest('tr');
            if (!row) return;

            var checkbox = getRowCheckbox(row);
            var debitSettlement = row.querySelector('.debitSettleINR');
            var debitTds = row.querySelector('.debitTDS');
            var rowEnteredTotal = isCreditSettlement
                ? parseAmt(e.target.value)
                : parseAmt(debitSettlement ? debitSettlement.value : 0) +
                  parseAmt(debitTds ? debitTds.value : 0);

            if (checkbox) {
                if (rowEnteredTotal > 0 && !checkbox.checked) {
                    checkbox.checked = true;
                    row.classList.add('rowSelected');
                } else if (rowEnteredTotal <= 0 && checkbox.checked) {
                    checkbox.checked = false;
                    row.classList.remove('rowSelected');
                }
            }

            if (isCreditSettlement) {
                validateSettleAgainstOutstanding(e.target);
                recalcRow(row);
                updateCreditsTotal();
                CheckHeaderCheckbox(checkbox, 'rowCheckCredits', 'chkSelectAllCredits');

                updateUnsettledAmount();
                return;
            }

            if (isDebitTds) {

                validateDebitTds(row, e.target);
                recalcRow(row);
                updateDebitsTotals();
                updateUnsettledAmount();
                return;
            }


            if (isDebitSettlement) {
                validateSettleAgainstOutstanding(e.target);
            }

            recalcRow(row);
            updateDebitsTotals();
            updateUnsettledAmount();
        });


        document.addEventListener('keydown', function (e) {
            if (!e.target.classList || !e.target.classList.contains('settleInput')) return;

            var allowedKeys = [
                'Backspace', 'Delete', 'ArrowLeft', 'ArrowRight',
                'ArrowUp', 'ArrowDown', 'Tab', 'Home', 'End'
            ];
            if (allowedKeys.indexOf(e.key) !== -1) return;
            if (e.ctrlKey || e.metaKey) return;
            if (/^[0-9]$/.test(e.key)) return;

            if (e.key === '.') {
                if (e.target.value.indexOf('.') !== -1) e.preventDefault();
                return;
            }

            e.preventDefault();
        });


        document.addEventListener('keydown', function (e) {
            if (!e.target.classList || !e.target.classList.contains('field-invalid')) return;
            if (e.key !== 'Tab' && e.key !== 'Enter') return;

            e.preventDefault();
            alert('Please correct the highlighted amount before continuing.');
        });



        function CheckHeaderCheckbox(rowCheckbox, targetClass, headerCheckboxId) {
            var checkboxes = getCheckboxInputsByClass(targetClass);
            var headerCheckbox = getCheckboxByStaticId(headerCheckboxId);
            if (!headerCheckbox) return;

            var allChecked = checkboxes.length > 0;
            for (var i = 0; i < checkboxes.length; i++) {
                if (!checkboxes[i].checked) {
                    allChecked = false;
                    break;
                }
            }

            headerCheckbox.checked = allChecked;
        }

        function ToggleAllCheckboxes(headerCheckbox, targetClass) {
            var actualHeaderCheckbox = headerCheckbox;


            if (actualHeaderCheckbox &&
                (!actualHeaderCheckbox.tagName ||
                 actualHeaderCheckbox.tagName.toLowerCase() !== 'input')) {
                actualHeaderCheckbox = actualHeaderCheckbox.querySelector
                    ? actualHeaderCheckbox.querySelector('input[type="checkbox"]')
                    : null;
            }

            if (!actualHeaderCheckbox) return;

            var desiredState = actualHeaderCheckbox.checked;

            var checkboxes = getCheckboxInputsByClass(targetClass);
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = desiredState;
                ToggleRowState(checkboxes[i], true);
            }

            actualHeaderCheckbox.checked = desiredState;
            updateUnsettledAmount();
        }



        function initGrid(tableId) {
            var table = document.getElementById(tableId);
            if (!table) return;

            var rows = table.querySelectorAll('tr');
            for (var i = 0; i < rows.length; i++) {
                var row = rows[i];
                var settlementInput = tableId === 'gvDebits'
                    ? row.querySelector('.debitSettleINR')
                    : row.querySelector('.creditSettle');

                if (!settlementInput) continue;


                var tdsInput = row.querySelector('.debitTDS');

                if (tdsInput && !tdsInput.getAttribute('data-tds-original')) {
                    tdsInput.setAttribute('data-tds-original', parseAmt(tdsInput.value).toFixed(2));
                }


                displayRowFromServer(row);
            }

            if (tableId === 'gvCredits') {
                updateCreditsTotal();
                CheckHeaderCheckbox(null, 'rowCheckCredits', 'chkSelectAllCredits');
            } else {
                updateDebitsTotals();
            }
        }

        $(document).ready(function () {
            var savedButton = document.getElementById('<%=btnSave.ClientID %>');
            saveLockedByserver = !!(savedButton && savedButton.disabled);
            initGrid('gvCredits');
            initGrid('gvDebits');
            //recalcDebitPoolAllocations();
            updateCreditsTotal();
            updateDebitsTotals();
            updateUnsettledAmount();
        });

        function ClearOrganizationControl() {
            $('#<%= txtOrgnaizationName.ClientID %>').val('');
        }
        
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtOrgnaizationName').autocomplete({
                minLength: 1,
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "SettlementEntry.aspx/ClientNameAutoSearch",
                        data: JSON.stringify({
                            Name: request.term,
                            ddlvalue: $('#<%=ddlSettlementType.ClientID%>').val()
                        }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (result) {

                            response(result.d);
                        },
                        error: function (xhr) {
                            console.error("Autocomplete error:", xhr.status, xhr.responseText);
                        }
                    });
                }

            });

        });
    </script>
    <script type="text/javascript">
        function Settlement_Report() {
            var SF = document.getElementById('<%= txtTransPrefix.ClientID %>').value.trim();
            var SM = document.getElementById('<%= txtTransNo.ClientID %>').value.trim();
            var SL = document.getElementById('<%= txtperiod.ClientID %>').value.trim();
            var SType = document.getElementById('<%= ddlSettlementType.ClientID %>').value;

            NewWindow1('../Accounts_Bank_Report/ACC_Settlement_Report.aspx?SR_P=' + encodeURIComponent(SF) + '&SR_NO=' + encodeURIComponent(SM) +
                        '&SR_S=' + encodeURIComponent(SL) + '&SType=' + encodeURIComponent(SType), 'List', '870', '1024', 'yes');
            return false;
        }

        function Validation() {
            var postingDate = document.getElementById('txtPostingDate').value;
            if (postingDate.length <= 0) {
                jAlert('Please Select Posting Date!', 'Message', function (r) { document.getElementById('txtPostingDate').focus(); })
                return false;
            }
            return true;
        }
    </script>
</body>
</html>
