<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OCR_Dashboard.aspx.cs" Inherits="Acc_Rpt_Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>OCR Logistics Dashboard</title>
    <!-- Bootstrap for layout -->
    <!-- ================= CSS ================= -->
    <link rel="stylesheet" href="../OCR_Bootstrap/css/bootstrap.min.css" type="text/css" />
    <link rel="stylesheet" href="../OCR_Bootstrap/css/daterangepicker.min.css" type="text/css" />
    <!-- ================= JAVASCRIPT ================= -->
    <!-- 1. jQuery FIRST -->
    <script type="text/javascript" src="../OCR_Bootstrap/jquery/jquery-3.6.0.min.js"></script>
    <!-- 2. Moment SECOND -->
    <script type="text/javascript" src="../OCR_Bootstrap/js/moment.min.js"></script>
    <!-- 3. DateRangePicker THIRD -->
    <script type="text/javascript" src="../OCR_Bootstrap/js/daterangepicker.min.js"></script>
    <!-- 4. Chart.js LAST -->
    <script type="text/javascript" src="../OCR_Bootstrap/js/chart.js"></script>
    <script>
        var $new = jQuery.noConflict(true);
        window.myJQ = $new;
    </script>
    <script type="text/javascript">
        function showToast(message, type) {
            type = type || 'info';
            var container = document.getElementById('toastContainer');
            if (!container) return;   // defensive guard

            var toast = document.createElement('div');
            toast.className = 'toast toast-' + type;
            toast.innerText = message;
            container.appendChild(toast);

            setTimeout(function () { toast.classList.add('show'); }, 50);
            setTimeout(function () {
                toast.classList.remove('show');
                setTimeout(function () { toast.remove(); }, 350);
            }, 3500);
        }
    </script>
    <script type="text/javascript">
        function closeAndReturnToAI() {
            console.log('1. fired');
            console.log('2. parent.adcodewindow exists?', !!(parent && parent.adcodewindow));
            console.log('3. window.top.open_Ocr_Ai_Dashboard exists?', !!(window.top && window.top.open_Ocr_Ai_Dashboard));

            var dashboardRef = (parent && parent.adcodewindow) ? parent.adcodewindow : null;

            try {
                window.top.open_Ocr_Ai_Dashboard('NEW');
                console.log('4. open_Ocr_Ai_Dashboard called OK');
            } catch (e) {
                console.error('4. FAILED to open AI dashboard:', e);
            }

            try {
                if (dashboardRef) dashboardRef.hide();
                console.log('5. hide() called OK');
            } catch (e) {
                console.error('5. FAILED to hide:', e);
            }
        }
    </script>
    <style type="text/css">                     
            html,body {
                margin: 0;
                padding: 0;
                overflow: hidden;   /* hides both scrollbars */
                height: 100%;
            }

            body {
                min-height: 100vh;
                background: linear-gradient(135deg, #f5f7fa, #e4ecf5);
            }

            /* DASHBOARD CONTAINER */

            .container-fluid {
                position: relative;
                padding: 20px;

                height: 100vh;
                box-sizing: border-box;
                overflow: hidden;
                
                /*min-height: 100vh;*/
                background: linear-gradient(
                to bottom,
                #51E2F5 0%,
                #51E2F5 24%,
                #9DF9EF 28%,
                #EDF7F6 38%,
                #FFA8B6 46%,
                #A28089 100%
            );    
                border-radius: 28px;
                box-shadow: 0 25px 60px rgba(0,0,0,0.25);
                overflow: visible !important;
            }
            
            /* ALL cards (KPI + charts + tables) */
            .card {

                border-radius: 18px;
                border: none;
                box-shadow: 0 10px 28px rgba(0,0,0,0.18);
                background: rgba(255, 255, 255, 0.55);
                backdrop-filter: blur(8px);
                -webkit-backdrop-filter: blur(8px);
            }

            /* KPI row – top teal zone */
            .row:first-of-type .card {
                background-color: rgba(255, 255, 255, 0.65) !important;
            }

            /* Charts row – mint zone */
            .row:nth-of-type(2) .card {
                background-color: rgba(255, 255, 255, 0.75) !important;
            }

            /* Lower rows – pink/mauve */
            .row:nth-of-type(3) .card,
            .row:nth-of-type(4) .card {
                background-color: rgba(255, 255, 255, 0.82) !important;
            }

            /* KPI CARDS */

            .card-body {
                padding: 10px 8px;
            }

            .card-title {
                font-size: 0.75rem;
                font-weight: 600;
                margin-bottom: 4px;
                letter-spacing: 0.5px;
                text-transform: uppercase;
                color: #334155;
            }

            .metric-value {
                font-size: 1.6rem;
                font-weight: 700;
                line-height: 1;
                color: #0f172a;
            }

            /* CHART CARDS (6-COLUMN)*/

            .col-md-6 .card {
                min-height: 240px;
                transition: transform 0.35s ease, box-shadow 0.35s ease;
            }

            .col-md-6 .card:hover {
                transform: translateY(-6px);
                box-shadow: 0 18px 40px rgba(0,0,0,0.25);
            }

            .col-md-6 .card-body {
                padding: 14px 16px 10px;
            }

            .col-md-6 .card-title {
                font-size: 0.85rem;
                font-weight: 600;
                letter-spacing: 0.4px;
                margin-bottom: 8px;
            }

            .col-md-6 canvas {
                max-height: 200px;
            }

            /* HEADINGS*/

            h2 
            {
                
                font-weight: 800;
                background: linear-gradient(90deg, #2563eb, #7c3aed);
                -webkit-background-clip: text;
                -webkit-text-fill-color: transparent;
            }

            .dashboard-divider {
                height: 4px;
                width: 80px;
                background: linear-gradient(90deg, #2563eb, #7c3aed);
                border-radius: 10px;
            }

            /* TABLE STYLING*/

            .table {
                border-radius: 12px;
                overflow: hidden;
            }

            .table thead {
                background: linear-gradient(90deg, #1e3a8a, #2563eb);
                color: #fff;
            }

            .table tbody tr {
                transition: background 0.2s ease, transform 0.2s ease;
            }

            .table tbody tr:hover {
                background: rgba(255,255,255,0.6);
                transform: scale(1.01);
            }

            td[data-mode="IMPORT"] {
                color: #16a34a;
                font-weight: 600;
            }

            td[data-mode="EXPORT"] {
                color: #2563eb;
                font-weight: 600;
            }

            /* FORMS */

            .form-control,
            .form-select {
                border-radius: 10px;
                border: 1px solid #e5e7eb;
            }

            .form-control:focus,
            .form-select:focus {
                border-color: #6366f1;
                box-shadow: 0 0 0 0.2rem rgba(99,102,241,0.25);
            }
                .zone-top .card {
                background: rgba(255,255,255,0.50);
            }

            .zone-middle .card {
                background: rgba(255,255,255,0.60);
            }

            .zone-bottom .card {
                background: rgba(255,255,255,0.70);
            }
         
            .container-fluid::before {
                content: "";
                position: absolute;
                width: 300px;
                height: 300px;
                background: radial-gradient(circle, rgba(255,255,255,0.4), transparent);
                top: -100px;
                right: -100px;
                border-radius: 50%;
                animation: float 6s infinite ease-in-out;
            }

            @keyframes float {
                0%, 100% { transform: translateY(0); }
                50% { transform: translateY(20px); }
            }

            button {
                transition: all 0.3s ease;
            }

            button:hover {
                transform: translateY(-2px);
                box-shadow: 0 10px 20px rgba(0,0,0,0.2);
            }

            @keyframes fadeSlideUp {
                from {
                    opacity: 0;
                    transform: translateY(30px);
                }
                to {
                    opacity: 1;
                    transform: translateY(0);
                }
            }

            .card {
                animation: fadeSlideUp 0.8s ease forwards;
            }

            .card:nth-child(1) { animation-delay: 0.1s; }
            .card:nth-child(2) { animation-delay: 0.2s; }
            .card:nth-child(3) { animation-delay: 0.3s; }
            .card:nth-child(4) { animation-delay: 0.4s; }

            canvas:hover {
                transform: scale(1.02);
                transition: transform 0.3s ease;
            }



            .daterangepicker {
                border-radius: 12px !important;
                box-shadow: 0 15px 40px rgba(0,0,0,0.2) !important;
                padding: 10px !important;
            }

            .daterangepicker .calendar-table {
                border: 1px solid #ddd ;
            }

            .daterangepicker td.active,
            .daterangepicker td.active:hover {
                background-color: #0d6efd ; 
                color: #fff ;
            }

            .daterangepicker td.in-range {
                background-color: #dbeafe ;
            }

            .daterangepicker .ranges li.active {
                background-color: #0d6efd;
                color: #fff ;
            }


            .daterangepicker .drp-buttons {
                text-align: right;
            }

            .daterangepicker .btn {
                border-radius: 6px !important;
            }

            .date-range-box {
                width: 228px !important;
                min-width: 228px;
            }

            .company-dropdown {
                width: 180px !important;
                min-width: 180px;
            }
            .dashboard-title {
                font-size: 27px;
                font-weight: 900;
                letter-spacing: 2px;
                margin-left:7px;

                background: linear-gradient(
                    135deg,
                    #0066FF,
                    #4F46E5,
                    #8B5CF6,
                    #EC4899
                );

                background-size: 300% 300%;

                -webkit-background-clip: text;
                -webkit-text-fill-color: transparent;

                animation: dashboardGradient 6s ease infinite;
            }

            @keyframes dashboardGradient {
                0%   { background-position: 0% 50%; }
                50%  { background-position: 100% 50%; }
                100% { background-position: 0% 50%; }
            }
            
            .token-stats {
                margin-top: 20px;
                display: flex;
                justify-content: space-around;
                align-items: center;
                flex-wrap: wrap;
                gap: 15px;
            }

            .stat-item {
                text-align: center;
                font-size: 14px;
            }

            .stat-item strong {
                display: block;
                font-size: 18px;
                margin-top: 5px;
                color: #111827;
            }

            .dot {
                width: 10px;
                height: 10px;
                display: inline-block;
                border-radius: 50%;
                margin-right: 6px;
            }

            .dot.used {
                background: #3B82F6;
            }

            .dot.remaining {
                background: #22C55E;
            }

            .latest-jobs-panel {
                height: 280px;
            }

            .latest-jobs-filter {
                display: flex;
                gap: 6px;
                margin-bottom: 8px;
            }

            .job-filter-btn {
                font-size: 0.72rem;
                font-weight: 600;
                padding: 3px 10px;
                border-radius: 12px;
                background: rgba(37, 99, 235, 0.08);
                color: #2563eb !important;
                text-decoration: none;
                cursor: pointer;
                border: none;
            }

            .job-filter-btn:hover {
                background: rgba(37, 99, 235, 0.18);
                text-decoration: none;
            }

            .latest-jobs-wrap {
                height: 238px;
                max-height: 255px;
                overflow: auto;
                background: #fff;
                border-radius: 10px;
            }

            .latest-jobs-table {
                margin-bottom: 0;
                width: 100%;
            }

            .latest-jobs-table thead {
                background: linear-gradient(90deg, #1e3a8a, #2563eb);
                color: #fff;
                font-size: 0.72rem;
            }

            .latest-jobs-table td,
            .latest-jobs-table th {
                padding: 5px 8px;
                font-size: 0.74rem;
                white-space: nowrap;
            }
            
            .latest-jobs-table th {
                background: #2563eb !important;
                color: #ffffff !important;
                font-weight: 700;
                font-size: 0.74rem;
                letter-spacing: 0.3px;
                padding: 7px 8px !important;
                border-right: 1px solid rgba(255, 255, 255, 0.25) !important;
                border-bottom: none !important;
                text-transform: uppercase;
            }

            .latest-jobs-table th:first-child {
                border-top-left-radius: 10px;
            }

            .latest-jobs-table th:last-child {
                border-top-right-radius: 10px;
            }

            .latest-jobs-table td {
                border-bottom: 1px solid rgba(148, 163, 184, 0.18);
            }

            .latest-jobs-table tr:hover td {
                background: rgba(37, 99, 235, 0.06);
            }
            
            .latest-jobs-table th,
            .latest-jobs-table td {
                text-align: center;
                vertical-align: middle;
            }

            .latest-jobs-table .date-col,
            .latest-jobs-table .status-col {
                text-align: center !important;
            }
            
            .job-col {
                border-right: 1px solid #e5e7eb;
            }

            .job-no-col {
                width: 80px;
            }

            .party-col {
                width: 210px;
            }

            .mode-col {
                width: 85px;
                text-align: center;
            }

            .pages-col,
            .uploads-col {
                width: 80px;
                text-align: center;
            }

            .user-col {
                width: 90px;
                text-align: center;
            }

            .date-col {
                width: 190px;
            }

            .status-col {
                width: 170px;
            }

            .mode-pill {
                display: inline-block;
                min-width: 42px;
                padding: 2px 8px;
                border-radius: 10px;
                font-weight: 700;
                font-size: 0.7rem;
            }

            .mode-EXP {
                background: rgba(37, 99, 235, 0.12);
                color: #2563eb;
            }

            .mode-IMP {
                background: rgba(22, 163, 74, 0.12);
                color: #16a34a;
            }

            .status-pill {
                display: inline-block;
                padding: 3px 9px;
                border-radius: 10px;
                font-weight: 700;
                font-size: 0.7rem;
                white-space: nowrap;
            }

            .status-success {
                background: rgba(34, 197, 94, 0.16);
                color: #15803d;
            }

            .status-failed {
                background: rgba(239, 68, 68, 0.16);
                color: #dc2626;
            }

            .status-neutral {
                background: rgba(100, 116, 139, 0.16);
                color: #475569;
            }
            
            .toast-container {
                position: fixed;
                top: 20px;
                left: 70%;
                transform: translateX(-50%);
                z-index: 99999;
            }

                .toast {
                    min-width: 260px;
                    max-width: 280px;
                    padding: 14px 18px;
                    border-radius: 12px;
                    color: #fff;
                    font-size: 0.85rem;
                    font-weight: 600;
                    box-shadow: 0 10px 28px rgba(0,0,0,0.25);
                    backdrop-filter: blur(8px);
                    -webkit-backdrop-filter: blur(8px);
                    opacity: 0;
                    transform: translateX(40px);
                    transition: all 0.35s ease;
                }

                .toast.show {
                    opacity: 1;
                    transform: translateX(0);
                }

                .toast-warning { background: linear-gradient(90deg, #f59e0b, #f97316); }
                .toast-error   { background: linear-gradient(90deg, #ef4444, #dc2626); }
                .toast-success { background: linear-gradient(90deg, #16a34a, #22c55e); }
                .toast-info    { background: linear-gradient(90deg, #2563eb, #7c3aed); }
                
             .btn-close-modern {
                width: 42px;
                height: 42px;
                border: none;
                border-radius: 50%;
                background: rgba(255, 255, 255, 0.55);
                color: #1e3a8a;
                font-size: 20px;
                font-weight: 600;
                cursor: pointer;
                backdrop-filter: blur(8px);
                -webkit-backdrop-filter: blur(8px);
                border: 1px solid rgba(255, 255, 255, 0.6);
                display: flex;
                align-items: center;
                justify-content: center;
                box-shadow: 0 6px 16px rgba(0,0,0,0.15);
                transition: all 0.3s ease;
            }
            .excel-tooltip.close-btn-wrapper {
                position: absolute;
                top: 14px;
                right: 18px;
                z-index: 100000;
            }

            .btn-close-modern:hover {
                background: linear-gradient(135deg, #06b6d4, #0891b2);
                color: #fff;
                transform: rotate(90deg) scale(1.08);
                box-shadow: 0 10px 24px rgba(8, 145, 178, 0.35);
            }

            .btn-close-modern:active {
                transform: scale(0.95);
            }

            .btn-close-modern:focus {
                outline: none;
            }
            .excel-tooltip {
                position: relative;
                display: inline-block;
            }

            .tooltip-text {
                visibility: hidden;
                opacity: 0;
                position: absolute;
                bottom: -35px;
                left: 50%;
                transform: translateX(-50%);
                background: #1f2937;
                color: #fff;
                padding: 6px 12px;
                border-radius: 6px;
                font-size: 12px;
                white-space: nowrap;
                transition: 0.3s;
                z-index: 99999;
            }

            .excel-tooltip:hover .tooltip-text {
                visibility: visible;
                opacity: 1;
            }
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="toastContainer" class="toast-container">
    </div>
    <div class="container-fluid p-4 border rounded">
        <div class="excel-tooltip close-btn-wrapper">
            <button type="button" id="btnCloseOcrDashboard" class="btn-close-modern" onclick="closeAndReturnToAI();">
                ✕</button>
            <span class="tooltip-text">Close </span>
        </div>
        <!-- Header -->
        <div class="d-flex justify-content-between align-items-center mb-3">
            <!-- Left Side (Title + Filters) -->
            <div class="d-flex align-items-center gap-2">
                <h2 class="dashboard-title fw-bold mb-0 me-3">
                    AI DASHBOARD
                </h2>
                <div class="excel-tooltip">
                    <asp:TextBox ID="txtDateRange" runat="server" CssClass="form-control date-range-box"
                        Placeholder="Select Date Range"></asp:TextBox>
                    <span class="tooltip-text">Select Date Range</span>
                </div>
                <asp:Button ID="btnRefresh" runat="server" Style="display: none;" OnClick="btnRefresh_Click" />
                <div class="excel-tooltip">
                    <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-select company-dropdown"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                    </asp:DropDownList>
                    <span class="tooltip-text">Select Company</span>
                </div>
            </div>
            <!-- Right Side (Excel Button) -->
            <div>
                <div class="excel-tooltip">
                    <asp:ImageButton ID="btnExportExcel" runat="server" ImageUrl="~/images/icons/New-Excel.PNG"
                        Width="75px" Height="50px" OnClick="btnExportExcel_Click" CausesValidation="false"
                        Style="cursor: pointer; position: relative; z-index: 9999; margin-right: 85px;" />
                    <span class="tooltip-text">Download Excel</span>
                </div>
            </div>
        </div>
        <!-- KPI Cards -->
        <div class="row g-3 mb-4 zone-top">
            <div class="col-md-2">
                <div class="card text-center ">
                    <div class="card-body">
                        <p class="card-title">
                            Total Jobs Uploaded</p>
                        <p class="metric-value">
                            <asp:Label ID="lblTotalJobs" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="card text-center">
                    <div class="card-body">
                        <p class="card-title">
                            Import Jobs</p>
                        <p class="metric-value">
                            <asp:Label ID="lblImportJobs" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="card text-center ">
                    <div class="card-body">
                        <p class="card-title">
                            Export Jobs</p>
                        <p class="metric-value">
                            <asp:Label ID="lblExportJobs" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="card text-center ">
                    <div class="card-body">
                        <p class="card-title">
                            Total Page Extracted</p>
                        <p class="metric-value">
                            <asp:Label ID="lblTotalPages" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="card text-center ">
                    <div class="card-body">
                        <p class="card-title">
                            Total Sucess Count</p>
                        <p class="metric-value">
                            <asp:Label ID="lblTotalSucess" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="card text-center ">
                    <div class="card-body">
                        <p class="card-title">
                            Total failed count</p>
                        <p class="metric-value">
                            <asp:Label ID="lblTotalFailed" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
        </div>
        <!-- Charts Row -->
        <div class="row g-3 mb-4 zone-top">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h6 class="card-title">
                            Jobs List Out
                        </h6>
                        <asp:Literal ID="ltrChartTitle" runat="server"></asp:Literal>
                        <canvas id="importExportChart"></canvas>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <%--<div class="card">
                        <div class="card-body">
                            <h6 class="card-title">Token Usage Trend</h6>
                            <canvas id="tokenChart"></canvas>
                        </div>
                    </div>--%>
                <div class="card">
                    <div class="card-body">
                        <h6 class="card-title">
                            Total Page Count</h6>
                        <canvas id="uploadJobCharts"></canvas>
                    </div>
                </div>
            </div>
        </div>
        <div class="row g-3 mb-4 zone-middle">
            <div class="col-md-6">
                <%--<div class="card">
                        <div class="card-body" ">
                            <h6 class="card-title">Total Page Count</h6>
                            <canvas id="uploadJobCharts" ></canvas>
                        </div>
                    </div>--%>
                <div class="card">
                    <div class="card-body">
                        <h6 class="card-title">
                            Token Usage Trend</h6>
                        <div class="token-stats">
                            <canvas id="tokenChart"></canvas>
                            <div class="stat-item">
                                <span class="dot used"></span><span>Used</span> <strong>720,000</strong>
                            </div>
                            <div class="stat-item">
                                <span class="dot remaining"></span><span>Remaining</span> <strong>280,000</strong>
                            </div>
                            <div class="stat-item">
                                <span>Total</span> <strong>1,000,000</strong>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h6 class="card-title">
                            <asp:Literal ID="ltrVendorOrJobsTitle" runat="server" Text="Vendor Wise Page Count"></asp:Literal>
                        </h6>
                        <asp:Panel ID="pnlVendorChart" runat="server">
                            <canvas id="vendorChart"></canvas>
                        </asp:Panel>
                        <asp:Panel ID="pnlLatestJobs" runat="server" Visible="false" CssClass="latest-jobs-panel">
                            <div class="latest-jobs-filter">
                                <asp:LinkButton ID="lnkJobsAll" runat="server" CssClass="job-filter-btn" OnClick="lnkJobsAll_Click"
                                    CausesValidation="false">All</asp:LinkButton>
                                <asp:LinkButton ID="lnkJobsImp" runat="server" CssClass="job-filter-btn" OnClick="lnkJobsImp_Click"
                                    CausesValidation="false">Import</asp:LinkButton>
                                <asp:LinkButton ID="lnkJobsExp" runat="server" CssClass="job-filter-btn" OnClick="lnkJobsExp_Click"
                                    CausesValidation="false">Export</asp:LinkButton>
                            </div>
                            <div class="latest-jobs-wrap">
                                <asp:GridView ID="gvLatestJobs" runat="server" AutoGenerateColumns="false" CssClass="table table-sm latest-jobs-table"
                                    GridLines="None" EmptyDataText="No recent jobs found.">
                                    <Columns>
                                        <asp:BoundField DataField="PDF_JOB_NO" HeaderText="Job No">
                                            <HeaderStyle CssClass="job-col job-no-col" />
                                            <ItemStyle CssClass="job-col job-no-col" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PDF_EXP_IMP_NAME" HeaderText="IMP/EXP Name">
                                            <HeaderStyle CssClass="job-col party-col" />
                                            <ItemStyle CssClass="job-col party-col" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Mode">
                                            <HeaderStyle CssClass="job-col mode-col" />
                                            <ItemStyle CssClass="job-col mode-col" />
                                            <ItemTemplate>
                                                <span class='<%# "mode-pill mode-" + Eval("PDF_MODE") %>'>
                                                    <%# Eval("PDF_MODE") %>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PDF_REMARKS" HeaderText="Pages">
                                            <HeaderStyle CssClass="job-col pages-col" />
                                            <ItemStyle CssClass="job-col pages-col" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PDF_UPLOAD_COUNT" HeaderText="Uploads">
                                            <HeaderStyle CssClass="job-col uploads-col" />
                                            <ItemStyle CssClass="job-col uploads-col" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PDF_USER_ID" HeaderText="User">
                                            <HeaderStyle CssClass="job-col user-col" />
                                            <ItemStyle CssClass="job-col user-col" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PDF_DATE_TIME" HeaderText="Date / Time" DataFormatString="{0:dd-MMM-yyyy hh:mm tt}">
                                            <HeaderStyle CssClass="job-col date-col" />
                                            <ItemStyle CssClass="job-col date-col" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Status">
                                            <HeaderStyle CssClass="job-col status-col" />
                                            <ItemStyle CssClass="job-col status-col" />
                                            <ItemTemplate>
                                                <span class='<%# GetStatusCss(Eval("PDF_PROCESS_STATUS")) %>'>
                                                    <%# Eval("PDF_PROCESS_STATUS") %>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">

               const ctxToken = document.getElementById('tokenChart').getContext('2d');

            // Example values
            const usedTokens = 720000;
            const remainingTokens = 280000;
            const totalTokens = usedTokens + remainingTokens;
            const usedPercent = ((usedTokens / totalTokens) * 100).toFixed(1);

            // Plugin to display percentage in center
            const centerTextPlugin = {
                id: 'centerText',
                beforeDraw(chart) {
                    const { ctx, chartArea } = chart;

                    if (!chartArea) return;

                    const centerX = (chartArea.left + chartArea.right) / 2;
                    const centerY = (chartArea.top + chartArea.bottom) / 2;

                    ctx.save();

                    // Percentage
                    ctx.font = "bold 42px Arial";
                    ctx.fillStyle = "#1F2937";
                    ctx.textAlign = "center";
                    ctx.textBaseline = "middle";
                    ctx.fillText(usedPercent + "%", centerX, centerY - 8);

                    // Subtitle
                    ctx.font = "16px Arial";
                    ctx.fillStyle = "#6B7280";
                    ctx.fillText("Used", centerX, centerY + 28);

                    ctx.restore();
                }
            };

            new Chart(ctxToken, {
                type: 'doughnut',
                data: {
                    labels: ['Tokens Used', 'Tokens Remaining'],
                    datasets: [{
                        data: [usedTokens, remainingTokens],
                        backgroundColor: [
                            '#3B82F6', // Blue
                            '#22C55E'  // Green
                        ],
                        borderWidth: 0,
                        hoverOffset: 8
                    }]
                },
                plugins: [centerTextPlugin],
                options: {
                    responsive: true,
                    cutout: '86%',
                    plugins: {
                        legend: {
                            position: 'bottom',
                            labels: {
                                usePointStyle: true,
                                pointStyle: 'circle',
                                padding: 20
                            }
                        },
                        tooltip: {
                            callbacks: {
                                label: function (context) {
                                    return context.label + ": " +
                                        context.raw.toLocaleString();
                                }
                            }
                        }
                    }
                }
            });

    // ===== Import/Export Jobs Chart (Line/Stacked) =====
    const ctxImportExport = document.getElementById('importExportChart').getContext('2d');
    new Chart(ctxImportExport, {
        type: 'line',
        data: {
            labels: [<%= MonthLabels %>],
            datasets: [
                {
                    label: 'Import Jobs',
                    data: [<%= ImportCounts %>],
                    borderColor: 'green',
                    backgroundColor: 'rgba(0, 128, 0, 0.3)',
                    borderWidth: 2,
                    tension: 0.3,
                    fill: true
                },
                {
                    label: 'Export Jobs',
                    data: [<%= ExportCounts %>],
                    borderColor: 'blue',
                    backgroundColor: 'rgba(0, 0, 255, 0.3)',
                    borderWidth: 2,
                    tension: 0.3,
                    fill: true
                }
            ]
        },
        options: {
            responsive: true,
            interaction: { mode: 'index', intersect: false },
            stacked: true,
            plugins: { legend: { display: true }, tooltip: { mode: 'index', intersect: false } },
            scales: {
                x: { title: { display: true, text: '<%= XAxisTitle %>' } },
                y: { title: { display: true, text: 'Jobs Uploaded' }, beginAtZero: true }
            }
        }
    });  
    
        // ===== Upload Job Chart =====
        const uploadChartData = <%= UploadChartJson %>;

        const ctxUpload = document.getElementById('uploadJobCharts').getContext('2d');

        new Chart(ctxUpload, {
        type: 'line',
        data: uploadChartData,
        options: {
            responsive: true,
            plugins: { legend: { display: true } },
            scales: {
                y: { beginAtZero: true }
            }
        }
    });
       
    // ===== Vendor wise page count =========
        var vendorChartCanvas = document.getElementById('vendorChart');

        if (vendorChartCanvas) {
            const vendorDataRaw = <%= VendorChartData %>;

            const labels = vendorDataRaw.map(v => v.label);
            const dataValues = vendorDataRaw.map(v => v.data);

            function getRandomColor() {
                const letters = '0123456789ABCDEF';
                let color = '#';
                for (let i = 0; i < 6; i++) color += letters[Math.floor(Math.random() * 16)];
                return color;
            }

            const backgroundColors = labels.map(_ => getRandomColor());

            const ctx = vendorChartCanvas.getContext('2d');

            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Pages Uploaded',
                        data: dataValues,
                        backgroundColor: backgroundColors
                    }]
                },
                options: {
                    indexAxis: 'y',
                    responsive: true,
                    plugins: { legend: { display: false } },
                    scales: {
                        x: { title: { display: true, text: 'Page Count' }, beginAtZero: true },
                        y: { title: { display: true, text: 'Vendor' } }
                    }
                }
            });
        }

    </script>
    <!-- OLD jQuery already loaded by master (leave it) -->
    <!-- Load NEW jQuery -->
    <script type="text/javascript">
        var $new = jQuery.noConflict(true);  // isolate jQuery 3.6
    </script>
    <!-- Load plugins using NEW jQuery -->
    <script type="text/javascript">

        var txt, start, end, arr;
        txt = myJQ('#<%= txtDateRange.ClientID %>').val();

        start = moment().startOf('month');
        end = moment();

        if (txt && txt.indexOf(" - ") > -1) {

            arr = txt.split(" - ");

            start = moment(arr[0], "DD-MMM-YYYY");

            end = moment(arr[1], "DD-MMM-YYYY");
        }

        myJQ('#<%= txtDateRange.ClientID %>').daterangepicker({
            parentEl: 'body',
            opens: 'center',
            drops: 'down',
            autoApply: false,
            startDate: start,
            endDate: end,

            ranges: {
                'Today': [moment(), moment()],
                'This Week': [moment().startOf('week'), moment().endOf('week')],
                'Last Week': [
                moment().subtract(1, 'week').startOf('week'),
                moment().subtract(1, 'week').endOf('week')
            ],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Previous Month': [
                moment().subtract(1, 'month').startOf('month'),
                moment().subtract(1, 'month').endOf('month')
            ],
                'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                'Last 30 Days': [moment().subtract(29, 'days'), moment()]
            },

            locale: {
                format: 'DD-MMM-YYYY'
            }
        }).on('apply.daterangepicker', function (ev, picker) {
            //alert('date changed')
            myJQ(this).val(picker.startDate.format('DD-MMM-YYYY') + ' - ' +
        picker.endDate.format('DD-MMM-YYYY'));

            document.getElementById('<%= btnRefresh.ClientID %>').click();
        });
    </script>
</body>
</html>
