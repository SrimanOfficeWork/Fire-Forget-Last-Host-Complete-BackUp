<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ACC_Account_Daywise_Summary_Rpt.aspx.cs"
    Inherits="Accounts_General_Reports_New_ACC_Account_Daywise_Summary_Rpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Account Daywise Summary Report</title>
    <style type="text/css">
        .rptWrapper
        {
            width: 420px;
            margin: 20px auto;
            font-family: Arial, Helvetica, sans-serif;
        }
        .rptTable
        {
            width: 100%;
            border-collapse: collapse;
        }
        .rptTable td
        {
            border: 1px solid #000000;
            padding: 8px 10px;
            font-size: 14px;
        }
        .rptTitle
        {
            text-align: center;
            font-weight: bold;
            font-size: 16px;
        }
        .rptHeader
        {
            text-align: center;
            font-weight: bold;
            background-color: #ffffff;
        }
        .rptValue
        {
            text-align: center;
        }
        .rptSpacerRow td
        {
            border: none;
            padding: 4px;
        }
        .rptAvailHeader
        {
            text-align: center;
            font-weight: bold;
        }
        .btnDownloadWrap
        {
            width: 345px;
            margin: 0 auto 20px auto;
            text-align: right;
        }
        .btnDownload
        {
            padding: 5px 25px;
            font-size: 14px;
            cursor: pointer;
            background-color: cornflowerblue;
            border-radius: 9px;
            color: white;
        }
        #popupwindow_closebut_right
        {
            float: right;
            width: 28px;
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="btnDownloadWrap">
            <asp:Button ID="btnDownloadExcel" runat="server" Text="Download Excel" CssClass="btnDownload"
                OnClick="btnDownloadExcel_Click" />
            &nbsp;
            <asp:Button ID="btnDownloadPdf" runat="server" Text="Download PDF" CssClass="btnDownload"
                OnClick="btnDownloadPdf_Click" />
        </div>
        <div id="popupwindow_closebut_right">
            <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
        </div>
        <asp:Panel ID="pnlReport" runat="server">
            <div class="rptWrapper">
                <table class="rptTable" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="2" class="rptTitle">
                            <asp:Literal ID="litTitle" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="rptHeader" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            font-weight: bold; text-align: center;">
                            Sales
                        </td>
                        <td class="rptHeader" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            font-weight: bold; text-align: center;">
                            Purchase
                        </td>
                    </tr>
                    <tr>
                        <td class="rptValue" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            text-align: center;">
                            <asp:Label ID="lblSales" runat="server" Text="0.00" />
                        </td>
                        <td class="rptValue" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            text-align: center;">
                            <asp:Label ID="lblPurchase" runat="server" Text="0.00" />
                        </td>
                    </tr>
                    <tr>
                        <td class="rptHeader" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            font-weight: bold; text-align: center;">
                            Receipts
                        </td>
                        <td class="rptHeader" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            font-weight: bold; text-align: center;">
                            Payments
                        </td>
                    </tr>
                    <tr>
                        <td class="rptValue" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            text-align: center;">
                            <asp:Label ID="lblReceipts" runat="server" Text="-" />
                        </td>
                        <td class="rptValue" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            text-align: center;">
                            <asp:Label ID="lblPayments" runat="server" Text="0.00" />
                        </td>
                    </tr>
                    <tr>
                        <td class="rptHeader" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            font-weight: bold; text-align: center;">
                            On Account
                        </td>
                        <td class="rptHeader" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            font-weight: bold; text-align: center;">
                            Unbilled Value
                        </td>
                    </tr>
                    <tr>
                        <td class="rptValue" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            text-align: center;">
                            <asp:Label ID="lblOnAccount" runat="server" Text="0.00" />
                        </td>
                        <td class="rptValue" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            text-align: center;">
                            <asp:Label ID="lblUnbilledValue" runat="server" Text="0.00" />
                        </td>
                    </tr>
                    <tr>
                        <td class="rptHeader" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            font-weight: bold; text-align: center;">
                            Bank
                        </td>
                        <td class="rptHeader" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                            font-weight: bold; text-align: center;">
                            OD Balance
                        </td>
                    </tr>
                    <asp:Repeater ID="rptBanks" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="rptValue" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                                    text-align: center;">
                                    <%# Eval("BANK_NAME") %>
                                    (<%# Eval("ACCOUNT_NUMBER") %>)
                                </td>
                                <td class="rptValue" style="border: 1px solid #000000; padding: 8px 10px; font-size: 14px;
                                    text-align: center;">
                                    <%# FormatBankAmount(Eval("Bal_Amt")) %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="2" class="rptAvailHeader" style="border: 1px solid #000000; padding: 8px 10px;
                            font-size: 14px; font-weight: bold; text-align: center;">
                            Total Available Balance
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="rptValue" style="border: 1px solid #000000; padding: 8px 10px;
                            font-size: 14px; text-align: center;">
                            <asp:Label ID="lblAvailableBalance" runat="server" Text="0.00" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
