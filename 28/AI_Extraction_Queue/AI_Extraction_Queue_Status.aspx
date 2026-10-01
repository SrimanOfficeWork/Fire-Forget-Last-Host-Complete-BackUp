<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AI_Extraction_Queue_Status.aspx.cs"
    Inherits="AI_Extraction_Queue_Status" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>PDF AI - Queue Status</title>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <link href="../css/MainStyle.css" rel="stylesheet" type="text/css" />
    <link href="../main.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <script src="../windowfiles/dhtmlwindow.js" type="text/javascript"></script>
    <script src="../modalfiles/modal.js" type="text/javascript"></script>
    <link href="../windowfiles/dhtmlwindow.css" rel="stylesheet" type="text/css" />
    <link href="../modalfiles/modal.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .ajax__calendar_container
        {
            z-index: 99999 !important;
        }
        body
        {
            background: #f0f2f5;
            font-family: Segoe UI, Arial, sans-serif;
            font-size: 13px;
            margin: 0;
            padding: 0;
        }
        /* ── Page Header ── */.page-header
        {
            background: linear-gradient(135deg, #6e0d0d 0%, #a01010 100%);
            color: white;
            padding: 10px 24px;
            display: table;
            width: 100%;
            box-sizing: border-box;
        }
        .page-header-left
        {
            display: table-cell;
            vertical-align: middle;
        }
        .page-header-right
        {
            display: table-cell;
            vertical-align: middle;
            text-align: right;
        }
        .page-header h2
        {
            margin: 0;
            font-size: 16px;
            font-weight: 600;
            letter-spacing: 0.5px;
        }
        .page-header p
        {
            margin: 2px 0 0 0;
            font-size: 10px;
            opacity: 0.85;
        }
        /* ── Header icon buttons ── */.icon-btn
        {
            background: rgba(255,255,255,0.15);
            border: 1px solid rgba(255,255,255,0.4);
            border-radius: 5px;
            padding: 3px 5px;
            cursor: pointer;
            vertical-align: middle;
            margin-left: 5px;
        }
        .icon-btn:hover
        {
            background: rgba(255,255,255,0.3);
        }
        .icon-btn img
        {
            width: 16px;
            height: 16px;
            vertical-align: middle;
            border: none;
        }
        /* ── Close X ── */.btn-close-x
        {
            background: rgba(255,255,255,0.15);
            color: white;
            border: 2px solid rgba(255,255,255,0.5);
            border-radius: 50%;
            width: 26px;
            height: 26px;
            font-size: 12px;
            font-weight: 700;
            cursor: pointer;
            line-height: 22px;
            text-align: center;
            padding: 0;
            vertical-align: middle;
            margin-left: 5px;
        }
        .btn-close-x:hover
        {
            background: #ffffff;
            color: #6e0d0d;
            border-color: #ffffff;
        }
        /* ── Auto refresh text ── */.refresh-indicator
        {
            display: inline-block;
            font-size: 11px;
            color: #ffcc80;
            margin-right: 6px;
            font-weight: 600;
        }
        /* ── Mode Toggle — Simple Import/Export ── */.mode-toggle-panel
        {
            background: #ffffff;
            border: 1px solid #e0e0e0;
            border-radius: 8px;
            padding: 8px 16px;
            margin: 10px 16px 0 16px;
            display: inline-block;
            box-sizing: border-box;
            box-shadow: 0 1px 4px rgba(0,0,0,0.06);
        }
        .mode-label-text
        {
            color: #555;
            font-size: 12px;
            font-weight: 700;
            margin-right: 12px;
            text-transform: uppercase;
            letter-spacing: 0.4px;
        }
        .simple-toggle-wrap
        {
            display: inline-block;
            vertical-align: middle;
        }
        .simple-toggle-label
        {
            font-size: 13px;
            font-weight: 700;
            vertical-align: middle;
            cursor: pointer;
        }
        .simple-toggle-label.active
        {
            color: #6e0d0d;
        }
        .simple-toggle-label.inactive
        {
            color: #bbb;
        }
        /* The track */.simple-toggle-track
        {
            display: inline-block;
            width: 52px;
            height: 26px;
            background: #ddd;
            border-radius: 13px;
            position: relative;
            vertical-align: middle;
            margin: 0 10px;
            cursor: pointer;
            transition: background 0.3s;
        }
        .simple-toggle-track.exp
        {
            background: #a01010;
        }
        /* The sliding knob */.simple-toggle-knob
        {
            position: absolute;
            top: 3px;
            left: 3px;
            width: 20px;
            height: 20px;
            background: white;
            border-radius: 50%;
            box-shadow: 0 1px 4px rgba(0,0,0,0.3);
            transition: left 0.25s ease;
        }
        .simple-toggle-track.exp .simple-toggle-knob
        {
            left: 29px;
        }
        /* ── Icon with label below (like screenshot) ── */.icon-with-label
        {
            display: inline-block;
            text-align: center;
            vertical-align: middle;
            margin: 0 6px;
        }
        .icon-label
        {
            font-size: 10px;
            color: #555;
            margin-top: 2px;
            font-weight: 600;
            text-transform: uppercase;
            letter-spacing: 0.3px;
        }
        /* ── Filter icon buttons ── */.filter-icon-btn
        {
            background: none;
            border: none;
            cursor: pointer;
            padding: 2px;
        }
        .filter-icon-btn:hover img
        {
            opacity: 0.7;
        }
        /* ── Summary Cards ── */.summary-row
        {
            display: table;
            width: 100%;
            padding: 10px 16px 0 16px;
            box-sizing: border-box;
        }
        .summary-cell
        {
            display: table-cell;
            padding-right: 10px;
            width: 25%;
        }
        .summary-card
        {
            background: white;
            border-radius: 8px;
            padding: 10px 16px;
            border-left: 4px solid #ccc;
            box-shadow: 0 1px 4px rgba(0,0,0,0.06);
        }
        .summary-card.total
        {
            border-left-color: #6c757d;
        }
        .summary-card.progress
        {
            border-left-color: #fd7e14;
        }
        .summary-card.ready
        {
            border-left-color: #28a745;
        }
        .summary-card.failed
        {
            border-left-color: #dc3545;
        }
        .summary-num
        {
            font-size: 22px;
            font-weight: 700;
            color: #333;
        }
        .summary-lbl
        {
            font-size: 10px;
            color: #777;
            text-transform: uppercase;
            letter-spacing: 0.4px;
            margin-top: 2px;
        }
        /* ── Filter Panel ── */.filter-panel
        {
            background: #ffffff;
            border: 1px solid #e0e0e0;
            border-radius: 8px;
            padding: 10px 16px;
            margin: 10px 16px 0 16px;
            box-shadow: 0 1px 4px rgba(0,0,0,0.06);
        }
        .filter-row
        {
            display: table;
            width: 100%;
        }
        .filter-cell
        {
            display: table-cell;
            vertical-align: middle;
            padding-right: 10px;
            white-space: nowrap;
            margin-left: 10px;
        }
        .filter-label
        {
            display: block;
            font-size: 10px;
            font-weight: 600;
            color: #555;
            margin-bottom: 3px;
            text-transform: uppercase;
            letter-spacing: 0.4px;
        }
        .filter-input
        {
            height: 26px;
            border: 1px solid #ccc;
            border-radius: 4px;
            padding: 0 6px;
            font-size: 12px;
            width: 120px;
            box-sizing: border-box;
            color: #333;
        }
        .filter-input:focus
        {
            border-color: #a01010;
            outline: none;
        }
        .filter-select
        {
            height: 26px;
            border: 1px solid #ccc;
            border-radius: 4px;
            padding: 0 4px;
            font-size: 12px;
            width: 120px;
            background: white;
            color: #333;
        }
        /* ── Filter icon buttons — FIXED SIZE ── */.filter-icon-btn
        {
            background: none;
            border: none;
            cursor: pointer;
            padding: 2px;
            vertical-align: middle;
            margin-left: 3px;
        }
        .filter-icon-btn img
        {
            width: 35px;
            height: 20px;
            vertical-align: middle;
        }
        .filter-icon-btn:hover img
        {
            opacity: 0.7;
        }
        /* ── Grid Container ── */.grid-container
        {
            background: white;
            border: 1px solid #e0e0e0;
            border-radius: 8px;
            margin: 10px 16px 12px 16px;
            box-shadow: 0 1px 4px rgba(0,0,0,0.06);
            overflow: hidden;
        }
        .grid-title-bar
        {
            background: #f8f9fa;
            border-bottom: 1px solid #e0e0e0;
            padding: 7px 14px;
            display: table;
            width: 100%;
            box-sizing: border-box;
        }
        .grid-title-bar-left
        {
            display: table-cell;
            vertical-align: middle;
            font-size: 12px;
            font-weight: 600;
            color: #444;
        }
        .grid-title-bar-right
        {
            display: table-cell;
            vertical-align: middle;
            text-align: right;
        }
        /* ── Title bar icon button — FIXED SIZE ── */.title-icon-btn
        {
            background: none;
            border: none;
            cursor: pointer;
            padding: 2px;
            vertical-align: middle;
        }
        .title-icon-btn img
        {
            width: 20px;
            height: 20px;
            vertical-align: middle;
        }
        .title-icon-btn:hover img
        {
            opacity: 0.7;
        }
        /* ── GridView ── */.queue-grid
        {
            width: 100% !important;
            border-collapse: collapse !important;
            border-spacing: 0 !important;
            font-size: 12px;
        }
        .queue-grid tr.header, .queue-grid thead tr
        {
            background: #6e0d0d !important;
            color: white !important;
            height: 28px !important;
        }
        .queue-grid tr.header td, .queue-grid tr.header th, .queue-grid thead tr td, .queue-grid thead tr th, .queue-grid th
        {
            background: #6e0d0d !important;
            color: white !important;
            padding: 5px 10px !important;
            text-align: left !important;
            font-weight: 600 !important;
            font-size: 11px !important;
            text-transform: uppercase !important;
            letter-spacing: 0.4px !important;
            white-space: nowrap !important;
            border: none !important;
            border-bottom: 2px solid #5a0a0a !important;
        }
        .queue-grid tr.normal td
        {
            background: #ffffff !important;
            color: #444 !important;
        }
        .queue-grid tr.alternate td
        {
            background: #fafafa !important;
            color: #444 !important;
        }
        .queue-grid td
        {
            padding: 6px 10px !important;
            border-bottom: 1px solid #f0f0f0 !important;
            vertical-align: middle !important;
            color: #444 !important;
            border-top: none !important;
            border-left: none !important;
            border-right: none !important;
        }
        .queue-grid tr:hover td
        {
            background: #fff3f3 !important;
        }
        /* ── Status Badges ── */.badge
        {
            display: inline-block;
            padding: 2px 8px;
            border-radius: 10px;
            font-size: 10px;
            font-weight: 600;
        }
        .badge-progress
        {
            background: #fff3e0;
            color: #e65100;
            border: 1px solid #ffcc80;
        }
        .badge-ready
        {
            background: #e8f5e9;
            color: #2e7d32;
            border: 1px solid #a5d6a7;
        }
        .badge-failed
        {
            background: #ffebee;
            color: #c62828;
            border: 1px solid #ef9a9a;
        }
        /* ── Grid action icon buttons — FIXED SIZE ── */.grid-icon-btn
        {
            background: none;
            border: none;
            cursor: pointer;
            padding: 1px 3px;
            vertical-align: middle;
        }
        .grid-icon-btn img
        {
            width: 30px;
            height: 22px;
            vertical-align: middle;
        }
        .grid-icon-btn:hover img
        {
            opacity: 0.7;
        }
        /* ── Vendor Badges ── */.badge-royal
        {
            background: #e3f2fd;
            color: #1565c0;
            border: 1px solid #90caf9;
            border-radius: 10px;
            padding: 2px 6px;
            font-size: 10px;
            font-weight: 600;
        }
        .badge-eroyal
        {
            background: #f3e5f5;
            color: #6a1b9a;
            border: 1px solid #ce93d8;
            border-radius: 10px;
            padding: 2px 6px;
            font-size: 10px;
            font-weight: 600;
        }
        /* ── Checkbox ── */.chk-select
        {
            cursor: pointer;
            width: 13px;
            height: 13px;
        }
        /* ── Pagination ── */.pagination-bar
        {
            padding: 8px 14px;
            border-top: 1px solid #f0f0f0;
            display: table;
            width: 100%;
            box-sizing: border-box;
        }
        .pagination-bar-left
        {
            display: table-cell;
            vertical-align: middle;
            font-size: 11px;
            color: #666;
        }
        .pagination-bar-right
        {
            display: table-cell;
            vertical-align: middle;
            text-align: right;
        }
        .btn-page
        {
            background: white;
            border: 1px solid #ddd;
            border-radius: 3px;
            padding: 3px 8px;
            font-size: 11px;
            cursor: pointer;
            margin-left: 3px;
            color: #444;
        }
        .btn-page:hover
        {
            background: #6e0d0d;
            color: white;
            border-color: #6e0d0d;
        }
        .page-select
        {
            height: 24px;
            border: 1px solid #ddd;
            border-radius: 3px;
            font-size: 11px;
            padding: 0 3px;
            margin: 0 3px;
        }
        /* ── No data ── */.no-data
        {
            text-align: center;
            padding: 30px;
            color: #aaa;
            font-size: 12px;
        }
        .no-data-icon
        {
            font-size: 30px;
            display: block;
            margin-bottom: 6px;
        }
    </style>
    <script type="text/javascript">

        var autoRefreshTimer = null;
        var countdown = 30;

        function startAutoRefresh() {
            countdown = 30;
            updateCountdown();
            autoRefreshTimer = setInterval(function () {
                countdown--;
                updateCountdown();
                if (countdown <= 0) {
                    clearInterval(autoRefreshTimer);
                    __doPostBack('btnAutoRefresh', '');
                }
            }, 1000);
        }

        function updateCountdown() {
            var el = document.getElementById('spanCountdown');
            if (el) el.innerHTML = 'Auto refresh in ' + countdown + 's';
        }

        jQuery(document).ready(function () {
            startAutoRefresh();
            // Set toggle from hidden field on load
            var val = document.getElementById('hdnJobType').value;
            if (!val || val === '') val = 'IMP';
            applyToggleUI(val === 'EXP');
        });

        // ── Simple Import / Export Toggle ────────────────────────────
        function toggleMode() {
            var current = document.getElementById('hdnJobType').value;
            var isExp = (current === 'EXP');
            setToggle(isExp ? 'IMP' : 'EXP');
        }

        function setToggle(val) {
            document.getElementById('hdnJobType').value = val;
            applyToggleUI(val === 'EXP');
            __doPostBack('btnJobTypeToggle', val);
        }

        function applyToggleUI(isExp) {
            var track = document.getElementById('toggleTrack');
            var lblImp = document.getElementById('lblImport');
            var lblExp = document.getElementById('lblExport');
            if (!track) return;

            if (isExp) {
                track.className = 'simple-toggle-track exp';
                lblImp.className = 'simple-toggle-label inactive';
                lblExp.className = 'simple-toggle-label active';
            } else {
                track.className = 'simple-toggle-track';
                lblImp.className = 'simple-toggle-label active';
                lblExp.className = 'simple-toggle-label inactive';
            }
        }

        function getGridCheckboxes() {
            // ASP.NET renders asp:CheckBox as <span><input type="checkbox"/></span>
            // Find all checkboxes inside grid tbody (data rows only, skip header)
            var table = document.querySelector('table.queue-grid');
            if (!table) return [];
            var tbody = table.querySelector('tbody');
            var searchIn = tbody || table;
            var inputs = searchIn.getElementsByTagName('input');
            var chks = [];
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == 'checkbox') chks.push(inputs[i]);
            }
            return chks;
        }

        function checkAll(chk) {
            var chks = getGridCheckboxes();
            for (var i = 0; i < chks.length; i++) {
                chks[i].checked = chk.checked;
            }
        }

        function confirmDelete() {
            var chks = getGridCheckboxes();
            var count = 0;
            for (var i = 0; i < chks.length; i++) {
                if (chks[i].checked) count++;
            }
            if (count == 0) { alert('Please select at least one record to delete.'); return false; }
            return confirm('Are you sure you want to delete ' + count + ' selected record(s)?');
        }

        function openViewScreen(url) {
            var w = 1200;
            var h = 700;
            var L = (screen.width) ? (screen.width - w) / 2 : 0;
            var T = (screen.height) ? (screen.height - h) / 60 : 0;
            var settings = 'width=' + w + ',height=' + h + ',top=' + T + ',left=' + L
                         + ',resizable=1,scrollbars=1,toolbar=0,menubar=0,location=0,status=0';
            window.open(url, '_blank', settings);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:HiddenField ID="hdnJobType" runat="server" Value="IMP" ClientIDMode="Static" />
    <asp:Button ID="btnAutoRefresh" runat="server" Text="" Style="display: none;" OnClick="btnAutoRefresh_Click" />
    <asp:Button ID="btnJobTypeToggle" runat="server" Text="" Style="display: none;" OnClick="btnJobTypeToggle_Click" />
    <!-- ── Page Header ── -->
    <div class="page-header">
        <div class="page-header-left">
            <h2>
                PDF AI - Queue Status</h2>
            <p>
                Track your PDF extraction jobs in real time</p>
        </div>
        <div class="page-header-right">
            <span id="spanCountdown" class="refresh-indicator"></span>
            <asp:ImageButton ID="imgRefreshNow" runat="server" ImageUrl="~/images/icons/arrow.png"
                CssClass="icon-btn" ToolTip="Refresh Now" OnClick="btnSearch_Click" CausesValidation="false"
                Width="30px" Height="30px" />
            <input type="button" value="X" class="btn-close-x" onclick="parent.adcodewindow.hide(); return false;"
                title="Close" />
        </div>
    </div>
    <!-- ── Summary Cards ── -->
    <div class="summary-row">
        <div class="summary-cell">
            <div class="summary-card total">
                <div class="summary-num">
                    <asp:Label ID="lblTotalCount" runat="server" Text="0" /></div>
                <div class="summary-lbl">
                    Total Jobs</div>
            </div>
        </div>
        <div class="summary-cell">
            <div class="summary-card progress">
                <div class="summary-num">
                    <asp:Label ID="lblProgressCount" runat="server" Text="0" /></div>
                <div class="summary-lbl">
                    In Progress</div>
            </div>
        </div>
        <div class="summary-cell">
            <div class="summary-card ready">
                <div class="summary-num">
                    <asp:Label ID="lblReadyCount" runat="server" Text="0" /></div>
                <div class="summary-lbl">
                    Ready</div>
            </div>
        </div>
        <div class="summary-cell" style="padding-right: 0;">
            <div class="summary-card failed">
                <div class="summary-num">
                    <asp:Label ID="lblFailedCount" runat="server" Text="0" /></div>
                <div class="summary-lbl">
                    Failed</div>
            </div>
        </div>
    </div>
    <!-- ── Filter Panel ── -->
    <div class="filter-panel">
        <div class="filter-row">
            <%-- Mode Toggle — inline beside Job No --%>
            <!-- ── Mode Toggle ── -->
            <div class="mode-toggle-panel" style="margin-left: -13px;">
                <span class="mode-label-text">Mode :</span>
                <div class="simple-toggle-wrap">
                    <span id="lblImport" class="simple-toggle-label active" onclick="setToggle('IMP')">Import</span>
                    <div id="toggleTrack" class="simple-toggle-track" onclick="toggleMode()">
                        <div id="toggleKnob" class="simple-toggle-knob">
                        </div>
                    </div>
                    <span id="lblExport" class="simple-toggle-label inactive" onclick="setToggle('EXP')">
                        Export</span>
                </div>
            </div>
            <div class="filter-cell">
                <span class="filter-label">Job No</span>
                <asp:TextBox ID="txtJobNo" runat="server" CssClass="filter-input" placeholder="Search Job No..." />
            </div>
            <%-- Vendor dropdown — hidden, kept for admin use and CS compile --%>
            <asp:DropDownList ID="ddlVendor" runat="server" Style="display: none;">
                <asp:ListItem Value="" Text="-- All --" />
                <asp:ListItem Value="ROYAL" Text="Royal" />
                <asp:ListItem Value="EROYAL" Text="Eroyal" />
            </asp:DropDownList>
            <div class="filter-cell">
                <span class="filter-label">Status</span>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="filter-select">
                    <asp:ListItem Value="" Text="-- All --" />
                    <asp:ListItem Value="IN PROGRESS" Text="In Progress" />
                    <asp:ListItem Value="READY" Text="Ready" />
                    <asp:ListItem Value="FAILED" Text="Failed" />
                </asp:DropDownList>
            </div>
            <div class="filter-cell">
                <span class="filter-label">From Date</span><br />
                <asp:TextBox ID="txtFromDate" runat="server" CssClass="filter-input" placeholder="DD/MM/YYYY"
                    ReadOnly="true" Style="cursor: pointer; margin-top: -15px;" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                    Format="dd/MM/yyyy" />
            </div>
            <div class="filter-cell">
                <span class="filter-label">To Date</span><br />
                <asp:TextBox ID="txtToDate" runat="server" CssClass="filter-input" placeholder="DD/MM/YYYY"
                    ReadOnly="true" Style="cursor: pointer; margin-top: -15px;" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                    Format="dd/MM/yyyy" />
            </div>
            <div class="filter-cell" style="text-align: center; vertical-align: middle;">
                <%-- Search icon with label --%>
                <div class="icon-with-label">
                    <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/icons/search_IRN.png"
                        CssClass="filter-icon-btn" ToolTip="Search" OnClick="btnSearch_Click" CausesValidation="false"
                        Width="28px" Height="28px" />
                    <div class="icon-label">
                        Search</div>
                </div>
                <%-- Clear icon with label --%>
                <div class="icon-with-label">
                    <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/icons/delete-sign.png"
                        CssClass="filter-icon-btn" ToolTip="Clear" OnClick="btnClear_Click" CausesValidation="false"
                        Width="28px" Height="28px" />
                    <div class="icon-label">
                        Clear</div>
                </div>
                <div style="display: inline-block; text-align: center; vertical-align: middle;">
                    <asp:ImageButton ID="imgDeleteSelected" runat="server" ImageUrl="~/images/icons/delete_IRN.png"
                        CssClass="title-icon-btn" ToolTip="Delete Selected" OnClick="imgDeleteSelected_Click"
                        CausesValidation="false" OnClientClick="return confirmDelete();" Width="28px"
                        Height="28px" />
                    <div style="font-size: 10px; color: #555; font-weight: 600; text-transform: uppercase;
                        letter-spacing: 0.3px;">
                        Delete</div>
                </div>
            </div>
        </div>
    </div>
    <!-- ── Grid Container ── -->
    <div class="grid-container">
        <div class="grid-title-bar">
            <div class="grid-title-bar-left">
                Queue Jobs List &nbsp;&nbsp;
            </div>
            <div class="grid-title-bar-right">
                <asp:Label ID="lblCurrentPage" runat="server" Text="1" Style="display: none;" />
                <asp:Label ID="lblTotalPages" runat="server" Text="0" Style="display: none;" />
            </div>
        </div>
        <asp:UpdatePanel ID="upGrid" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvQueue" runat="server" AutoGenerateColumns="False" CssClass="queue-grid"
                    DataKeyNames="QUEUE_ID,PROCESS_ID,VENDOR_TYPE,STATUS,SL_NO,IMPORTER_NAME,JOB_TYPE" OnRowDataBound="gvQueue_RowDataBound"
                    OnRowCreated="gvQueue_RowCreated" OnRowCommand="gvQueue_RowCommand" ShowHeaderWhenEmpty="True"
                    UseAccessibleHeader="True">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="28px">
                            <HeaderTemplate>
                                <input type="checkbox" onclick="checkAll(this);" class="chk-select" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" CssClass="chk-select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="QUEUE_ID" HeaderText="#" ItemStyle-Width="35px" />
                        <asp:BoundField DataField="JOB_NO" HeaderText="Job No" ItemStyle-Width="90px" />
                        <asp:BoundField DataField="FILE_NAME" HeaderText="File Name" ItemStyle-Width="130px" />
                        <asp:BoundField DataField="IMPORTER_NAME" HeaderText="Importer" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="SL_NO" HeaderText="Br.slno" ItemStyle-Width="120px" />
                        <%--<asp:TemplateField HeaderText="Vendor" ItemStyle-Width="75px">
                            <ItemTemplate>
                                <asp:Label ID="lblVendor" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Extraction Status" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job Status" ItemStyle-Width="75px">
                            <ItemTemplate>
                                <asp:Label ID="lblJobStatus" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CREATED_DATE" HeaderText="Uploaded At" ItemStyle-Width="120px" />
                        <asp:BoundField DataField="UPDATED_DATE" HeaderText="Updated At" ItemStyle-Width="120px" />  
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px">
                            <ItemTemplate>
                                <%-- Check Status icon with label — shown when IN PROGRESS --%>
                                <div class="icon-with-label">
                                    <asp:ImageButton ID="imgCheckStatus" runat="server"
                                        ImageUrl="~/images/icons/loading.png"
                                        CssClass="grid-icon-btn" ToolTip="Check Status"
                                        CommandName="CheckStatus"
                                        CommandArgument='<%# Eval("PROCESS_ID") + "~" + Eval("VENDOR_TYPE") + "~" + Eval("SL_NO") + "~" + Eval("IMPORTER_NAME") + "~" + Eval("JOB_TYPE") %>'
                                        CausesValidation="false" Width="22px" Height="22px" />
                                    <asp:Label ID="lblStatusIconLabel" runat="server" Text="Status" CssClass="icon-label" />
                                </div>
                                <%-- View icon with label — shown when READY --%>
                                <div class="icon-with-label">
                                    <asp:ImageButton ID="imgView" runat="server"
                                        ImageUrl="~/images/icons/view.png"
                                        CssClass="grid-icon-btn" ToolTip="View"
                                        CommandName="ViewResult"
                                        CommandArgument='<%# Eval("PROCESS_ID") + "~" + Eval("VENDOR_TYPE") + "~" + Eval("SL_NO") + "~" + Eval("IMPORTER_NAME") + "~" + Eval("JOB_TYPE") %>'
                                        CausesValidation="false" Width="22px" Height="22px" />
                                    <asp:Label ID="lblViewIconLabel" runat="server" Text="View" CssClass="icon-label" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="no-data">
                            <span class="no-data-icon">&#128202;</span> No queue records found.
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- ── Pagination ── -->
        <asp:Panel ID="Div_Pagination" runat="server" Visible="false">
            <div class="pagination-bar">
                <div class="pagination-bar-left">
                    Page
                    <asp:DropDownList ID="ddlSelectPageno" runat="server" CssClass="page-select" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged" />
                    of
                    <asp:Label ID="lblTotalPagesDisplay" runat="server" Text="1" />
                    &nbsp;|&nbsp; Total:
                    <asp:Label ID="lblTotalRecords" runat="server" Text="0" />
                </div>
                <div class="pagination-bar-right">
                    <asp:Button ID="btnFirst" runat="server" Text="First" CssClass="btn-page" CommandName="First"
                        OnCommand="ChangePage" />
                    <asp:Button ID="btnPrev" runat="server" Text="Prev" CssClass="btn-page" CommandName="Previous"
                        OnCommand="ChangePage" />
                    <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn-page" CommandName="Next"
                        OnCommand="ChangePage" />
                    <asp:Button ID="btnLast" runat="server" Text="Last" CssClass="btn-page" CommandName="Last"
                        OnCommand="ChangePage" />
                </div>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
