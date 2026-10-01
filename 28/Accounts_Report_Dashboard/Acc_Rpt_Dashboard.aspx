<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="Acc_Rpt_Dashboard.aspx.cs" Inherits="Acc_Rpt_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language='javascript'>
        window.onload = happycode;
        function happycode() {
            var masterId = document.getElementById("Master_Id");
            if (masterId) masterId.click();
        }
        function tab_page1() {
            document.getElementById('page-1').style.display = 'block';
        }
    </script>
    <style type="text/css">
        .dashboard-container
        {
            max-width: 1400px;
            margin: 0 auto;
        }
        
        /* Top Header */
        .page-header
        {
            display: flex;
            align-items: center;
            justify-content: space-between;
            margin-bottom: 20px;
            padding: 5px;
        }
        
        .page-header h1
        {
            font-size: 1.3rem;
            color: #1e293b;
            font-weight: 700;
            margin: 0;
        }
        
        /* Grid System */
        .report-grid
        {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(234px, 1fr));
            gap: 8px;
        }
        
        /* Menu Card Styles */
        .menu-card
        {
            background: #ffffff;
            border-radius: 12px;
            border: 1px solid #e2e8f0;
            box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.05);
            transition: transform 0.2s, box-shadow 0.2s;
            overflow: hidden;
        }
        .menu-card4
        {
            background: #ffffff;
            border-radius: 12px;
            border: 1px solid #e2e8f0;
            box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.05);
            transition: transform 0.2s, box-shadow 0.2s;
            overflow: hidden;
        }
        .menu-card:hover
        {
            transform: translateY(-4px);
            box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.1);
        }
        
        .card-header
        {
            padding: 16px 20px;
            color: white;
            font-weight: 600;
            font-size: 0.9rem;
            text-transform: uppercase;
            letter-spacing: 0.05em;
            display: flex;
            align-items: center;
        }
        
        /* Category Colors */
        .bg-general
        {
            background: #6366f1;
        }
        /* Indigo */
        .bg-sales
        {
            background: #10b981;
        }
        /* Emerald */
        .bg-purchase
        {
            background: #f59e0b;
        }
        /* Amber */
        .bg-finance
        {
            background: #8b5cf6;
        }
        /* Violet */
        .bg-cash
        {
            background: #06b6d4;
        }
        /* Cyan */
        
        
        
        /* Link List Items */
        .menu-link
        {
            display: flex;
            align-items: center;
            padding: 10px 20px;
            text-decoration: none !important;
            color: #475569;
            font-size: 0.92rem;
            transition: all 0.2s;
            border-left: 3px solid transparent;
        }
        
        .menu-link:hover
        {
            background-color: #f1f5f9;
            color: #1e293b;
            border-left-color: currentColor;
            padding-left: 25px;
        }
        
        .link-icon
        {
            margin-right: 12px;
            font-size: 1.2rem;
            opacity: 0.7;
        }
        
        /* ASPX Hidden Control styling */
        .hidden-controls
        {
            display: none;
        }
    </style>
    <div id="innerbox_MidMain_Grid" style="margin-left: -10px; width: 1010px;">
        <div class="dashboard-container">
            <div class="page-header">
                <h1>
                    Accounting Reports Center</h1>
            </div>
            <div id="page-1" class="report-grid">
                <!-- 1. GENERAL REPORTS -->
                <div class="menu-card">
                    <div class="card-header bg-general">
                        General Reports</div>
                    <div class="card-body">
                        <span id="Acc_Gen" runat="server"><a class="menu-link" href="javascript:void(0);"
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_General_Reports/Acc_Job_Revenue_Cost_Rpt.aspx?DASH_ID=1', '', NewWindow('1005', '452'));">
                            <span class="link-icon">&#128202;</span> Profit and Loss </a></span>
                        <span id="Accledg"
                                runat="server" style="display: none"><a class="menu-link" href="javascript:void(0);" onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Cash_Report/Accounts_Ledger_Transact_Rpt.aspx', '', NewWindow('1100', '580'));">
                                    <span class="link-icon">&#128209;</span> Ledger Transaction </a></span>
                        <span id="Accgstr3" runat="server"><a class="menu-link" href="javascript:void(0);"
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_General_Reports/Acc_GSTR3_Report.aspx', '', NewWindow('1100', '580'));">
                            <span class="link-icon">&#128203;</span> GSTR3b </a></span><span id="Span3" runat="server">
                                <a class="menu-link" href="javascript:void(0);" onclick="dhtmlmodal.open(
           'adcodewindow',
           'iframe',
           '../Accounts_General_Reports_New/Acc_Billing_Mis_Report.aspx',
           '',
           'width=1075px,height=400px,left=90px,top=73px,resize=1,scrolling=1'
       );">
                                    <span class="link-icon">&#128200;</span> billing Mis </a></span><span id="Span4"
                                        runat="server"><a class="menu-link" href="javascript:void(0);" onclick="dhtmlmodal.open(
           'adcodewindow',
           'iframe',
           '../Accounts_General_Reports_New/Acc_Purchase_Mis_Report.aspx',
           '',
           'width=1075px,height=400px,left=90px,top=73px,resize=1,scrolling=1'
       );">
                                            <span class="link-icon">&#128200;</span> Purchase Mis </a></span>
                        <span id="Span1" runat="server" style="display: none"><a class="menu-link" href="javascript:void(0);"
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_General_Reports/Acc_Ledger_Wise_Profit_Loss_Report.aspx', '', NewWindow('1100', '580'));">
                            <span class="link-icon">&#128200;</span> Ledgerwise Profit & Loss </a></span>
                        <span id="Acc_PL" runat="server" style="display: none"><a class="menu-link" href="javascript:void(0);"
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Cash_Report/Accounts_Ledger_Transact_PL_Rpt.aspx', '', NewWindow('1100', '580'));">
                            <span class="link-icon">&#128201;</span> Ledgerwise P/L II </a></span>
                    </div>
                </div>
                <!-- 2. SALES REPORTS -->
                <div class="menu-card">
                    <div class="card-header bg-sales">
                        Sales & Revenue</div>
                    <div class="card-body">
                        <span id="Accsalessum" runat="server"><a class="menu-link" href="javascript:void(0);"
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Sales_Rpt/Acc_Sales_Summary_Report.aspx', '', NewWindow('1100', '580'));">
                            <span class="link-icon">&#128176;</span> Sales Summary </a></span><span id="AccsalesLedsum"
                                runat="server"><a class="menu-link" href="javascript:void(0);" onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Sales_Rpt/Acc_Sales_Ledger_Summary_Report.aspx', '', NewWindow('1100', '580'));">
                                    <span class="link-icon">&#128216;</span> Sales Ledger Summary </a></span>
                        <span id="Accsales" runat="server"><a class="menu-link" href="javascript:void(0);"
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Sales_Rpt/Acc_Sales_outstanding_Rpt.aspx', '', NewWindow('1100', '580'));">
                            <span class="link-icon">&#9203;</span> Sales Outstanding </a></span><span id="accContainer"
                                runat="server"><a class="menu-link" href="javascript:void(0);" onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Sales_Rpt/Acc_Sales_Container_Report.aspx', '', NewWindow('1100', '580'));">
                                    <span class="link-icon">&#128230;</span> Container Report </a></span>
                        <span id="accgstr1" runat="server"><a class="menu-link" href="javascript:void(0);"
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Sales_Rpt/Acc_GSTR1_Report.aspx', '', NewWindow('1100', '580'));">
                            <span class="link-icon">&#128221;</span> GSTR 1 </a></span><span id="accgroup" runat="server">
                                <a class="menu-link" href="javascript:void(0);" onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Sales_Rpt/Acc_Sales_Group_Summary.aspx', '', NewWindow('860', '480'));">
                                    <span class="link-icon">&#128101;</span> Group Summary </a></span>
                        <%--<span id="accAR" runat="server">
                            <a class="menu-link" href="javascript:void(0);" onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_General_Reports_New/ACC_AccountReceivable.aspx', '', NewWindow('1100', '590'));">
                                <span class="link-icon">&#129534;</span> Accounts Receivable
                            </a>
                        </span>--%>
                        <span id="accAR" runat="server"><a class="menu-link" href="../Accounts_General_Reports_New/ACC_AccountReceivable.aspx"
                            target="_blank"><span class="link-icon">&#129534;</span> Accounts Receivable </a>
                        </span><span id="accTDS_receivable" runat="server">
                            <a class="menu-link" href="../Accounts_General_Reports_New/Acc_TDS_receivable.aspx" target="_blank">
                                <span class="link-icon">&#129534;</span> TDS Receivable
                            </a>
                        </span>
                        <span id="unbilledJobs"
                           runat="server"><a class="menu-link" href="../Accounts_Sales/Accounts_Unbilled_Jobs_Search.aspx" target="_blank">
                               <span class="link-icon">&#129534;</span> Unbilled Jobs</a> </span>
                    </div>
                </div>
                <!-- 3. PURCHASE REPORTS -->
                <div class="menu-card">
                    <div class="card-header bg-purchase">
                        Purchase & Payables</div>
                    <div class="card-body">
                        <span id="Accpurchase" runat="server"><a class="menu-link" href="javascript:void(0);"
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Purchase_Report/Acc_Purchase_Rpt.aspx', '', NewWindow('1100', '580'));">
                            <span class="link-icon">&#128722;</span> Purchase Report </a></span><span id="Accpayment"
                                runat="server"><a class="menu-link" href="javascript:void(0);" onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Purchase_Report/Acc_Payment_outstanding_Rpt.aspx', '', NewWindow('1100', '580'));">
                                    <span class="link-icon">&#128184;</span> Payment Outstanding </a></span>
                        <span id="Accgstr" runat="server"><a class="menu-link" href="javascript:void(0);"
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Purchase_Report/Acc_GSTR2_Rpt.aspx', '', NewWindow('1220', '580'));">
                            <span class="link-icon">&#128203;</span> GSTR2 </a></span>
                        <%--<span id="AccPayable" runat="server">
                                <a class="menu-link" href="javascript:void(0);" onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_General_Reports_New/ACC_AccountPayable.aspx', '', NewWindow('1220', '580'));">
                                    <span class="link-icon">&#128179;</span> Accounts Payable </a>
                                    </span>--%>
                        <span id="AccPayable" runat="server"><a class="menu-link" href="../Accounts_General_Reports_New/ACC_AccountPayable.aspx"
                            target="_blank"><span class="link-icon">&#128179;</span> Accounts Payable </a>
                        </span><span id="TDSPayable" runat="server"><a class="menu-link" href="../Accounts_General_Reports_New/ACC_TDS_Payable.aspx"
                            target="_blank"><span class="link-icon">&#129534;</span> TDS Payable </a></span>
                    </div>
                </div>
                <!-- 4. FINANCIAL STATEMENTS -->
                <div class="menu-card4">
                    <div class="card-header bg-finance">
                        Financial Statements</div>
                    <div class="card-body">
                        <span id="Span2" runat="server"><a class="menu-link" href="javascript:void(0);" onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_General_Reports_New/Acc_Profit_Loss_Rpt.aspx', '', NewWindow('780', '580'));">
                            <span class="link-icon">&#9878;&#65039;</span> Profit and Loss Report </a></span>
                        <span id="Accfinstate" runat="server"><a class="menu-link" href="javascript:void(0);"
                            
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Financial_Statements/Acc_Trail_Balance_Rpt_New.aspx', '', NewWindow('780', '580'));" 
                            style="display: none">
                            <span class="link-icon">&#9878;&#65039;</span> Trial Balance </a></span><span id="Accfinbal"
                                runat="server"><a class="menu-link" href="javascript:void(0);" 
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Financial_Statements/Acc_Balance_Sheet_Rpt.aspx', '', NewWindow('1100', '580'));" 
                            style="display: none">
                                    <span class="link-icon">&#127963;&#65039;</span> Balance Sheet </a></span>
                        <span id="AccTransaction" runat="server"><a class="menu-link" href="javascript:void(0);"
                            
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Financial_Statements/Acc_Bank_Transaction_Report.aspx', '', NewWindow('1100', '580'));" 
                            >
                            <span class="link-icon">&#128179;</span> Acc. Transaction </a></span>
                            <span id="Span5" runat="server"><a class="menu-link" href="javascript:void(0);"
                            
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_General_Reports_New/ACC_Account_Daywise_Summary_Rpt.aspx', '', NewWindow('500', '580'));" 
                            >
                            <span class="link-icon">&#128179;</span> Daywise Summary Report </a></span>
                    </div>
                </div>
                <!-- 5. CASH REPORTS -->
                <div class="menu-card4" style="display: none">
                    <div class="card-header bg-cash">
                        Cash Management</div>
                    <div class="card-body">
                        <span id="Acccash" runat="server"><a class="menu-link" href="javascript:void(0);"
                            onclick="dhtmlmodal.open('adcodewindow', 'iframe', '../Accounts_Cash_Report/Accounts_Cash_Report.aspx', '', NewWindow('1100', '580'));">
                            <span class="link-icon">&#128181;</span> Cash Book </a></span>
                    </div>
                </div>
            </div>
        </div>
        <!-- Hidden Logic Section -->
        <div class="hidden-controls">
            <asp:HiddenField ID="txt_Imapserver" runat="server" />
            <asp:HiddenField ID="txt_username" runat="server" />
            <asp:HiddenField ID="txt_pwd" runat="server" />
            <asp:HiddenField ID="txt_Folder" runat="server" />
            <asp:HiddenField ID="txt_User_Creation_Id" runat="server" />
            <asp:HiddenField ID="txt_Company_Id" runat="server" />
            <asp:HiddenField ID="txt_Customhouse_Id" runat="server" />
            <asp:HiddenField ID="txtSearch_Date" runat="server" />
            <asp:HiddenField ID="txt_port" runat="server" />
            <asp:HiddenField ID="HDF" runat="server" />
            <asp:ModalPopupExtender ID="MPEU" runat="server" TargetControlID="HDF" PopupControlID="MessageDivupdated"
                BackgroundCssClass="modalBackground" DropShadow="false" />
            <asp:Panel ID="MessageDivupdated" runat="server" align="center" Style="display: none;">
            </asp:Panel>
        </div>
    </div>
</asp:Content>
