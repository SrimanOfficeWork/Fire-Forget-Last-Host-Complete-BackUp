<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Purchase_Mis_Report.aspx.cs"
    Inherits="Purchase_Mis_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        body
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            background-color: #f4f6f8;
            margin: 0;
        }
        
        .message-row
        {
            margin-top: 8px;
        }
        .grid-scroll
        {
            overflow-x: auto;
            margin-top: -19px;
        }
        table.report-grid
        {
            width: 100%;
            border-collapse: collapse;
        }
        .grid-header th
        {
            background-color: #2e8a38;
            color: #ffffff;
            font-weight: bold;
            padding: 8px;
            text-align: center;
            white-space: nowrap;
        }
        .grid-row td, .grid-alt-row td
        {
            padding: 7px 8px;
            border-bottom: 1px solid #e6e6e6;
            white-space: nowrap;
        }
        .grid-alt-row
        {
            background-color: #f2f2f2;
        }
        .amount-cell
        {
            text-align: right !important;
            padding-right: 14px !important;
            font-variant-numeric: tabular-nums;
        }
        
        .total-row td
        {
            font-weight: bold;
            background-color: #f9f656  !important;
            border-top: 2px solid #2b579a;
        }
        .total-col
        {
             font-weight: bold;
            color: red;
        }
        .no-records
        {
            text-align: center;
            color: #cc0000;
            font-weight: bold;
            padding: 18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" />
    <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 1070px;">
        <div id="innerbox_MidMain" style="height: 113px; width: 1072px;">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                    Purchase MIS
                </div>
                <div id="editbu" style="padding-top: 3px;">
                    <asp:ImageButton ID="btnExcel" runat="server" ToolTip="Export to Excel" ImageUrl="~/images/icons/excel.png"
                        Height="28px" Width="28px" CausesValidation="false" OnClick="btnExcel_Click" />
                </div>
                <div id="popupwindow_closebut_right_new">
                    <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
                </div>
            </div>
            <div id="tag_transact_lft_in1" style="width: 1060px; height: 25px; margin-top: 15px;
                margin-left: 9px">
                <div id="tag_label_transact_Src" style="width: 106px; margin-top: 3px">
                    From Date</div>
                <div id="txtcon-m_transaction_code" style="width: 110px">
                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                        MaxLength="10" TabIndex="3"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtfromdate"
                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtfromdate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transact_Src" style="width: 80px; margin-top: 3px">
                    To Date
                </div>
                <div id="txtcon-m_transaction_code" style="width: 110px">
                    <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                        MaxLength="10" TabIndex="4"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txttodate"
                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txttodate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </div>
                <div id="tag_label_transaction_popup_no_empty">
                </div>
                <div id="tag_label_transact_Src" style="width: 50px; margin-top: 3px">
                    Month</div>
                <div id="txtcon-m_transaction_code" style="width: 130px">
                    <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                        Width="130px" TabIndex="5">
                    </asp:DropDownList>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transact_Src" style="width: 60px; display: none;">
                    Branch
                </div>
                <div id="txtcon-m_Exchange" style="width: 140px; display: none;">
                    <asp:DropDownList ID="ddl_Branch" CssClass="listtxt_transac_item_gen_notn" Width="130px"
                        runat="server" TabIndex="44">
                    </asp:DropDownList>
                </div>
                <div class="tag_label_transact_Src">
                    <asp:CheckBox ID="chkExcludeTax" runat="server" Text="Exclude Tax" />
                </div>
                <div id="tag_transact_lft_in1" style="height: 50px; margin-top: 10px;">
                    <div id="tag_label_transact_Src" style="width: 106px;">
                        Customer Name
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 250px;">
                        <asp:DropDownList ID="ddl_Cus_Name" CssClass="listtxt_transac_item_gen_notn" Width="250px"
                            runat="server" TabIndex="44" Height="20px">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                            onserverclick="btnSearch_Click" tabindex="5"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="#" onclick="parent.adcodewindow.hide();return false;" class="cancelButt">
                        </a>
                    </div>
                </div>
                <div class="search-panel">
                    <div class="message-row">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#cc0000" Font-Bold="true"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="grid-scroll">
            <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" CssClass="report-grid"
                GridLines="None" CellPadding="0" CellSpacing="0" EmptyDataText="No Records Found"
                OnRowDataBound="gvReport_RowDataBound">
                <HeaderStyle CssClass="grid-header" />
                <RowStyle CssClass="grid-row" />
                <AlternatingRowStyle CssClass="grid-alt-row" />
                <EmptyDataRowStyle CssClass="no-records" />
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
