<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplateReport.aspx.cs" Inherits="TemplateReport" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DSR Report</title>
    <%-- This page has no MasterPageFile (standalone popup), so - unlike
         DSR_Template/Import_Dynamicreport.aspx, which gets jQuery/Bootstrap/
         the multiselect plugin for free from eRoyalMasters.master - the same
         stack has to be pulled in directly here for ListBox1's Group Name
         picker (see eRoyalMasters.master's own <script>/<link> block for the
         exact same includes). --%>
    <script src="../js/js_bootstrap/jquery.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap-multiselect.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=ListBox1]').multiselect({
                includeSelectAllOption: true,
                nonSelectedText: 'Group Name'
            });
        });
    </script>
    <style>
        html, body { height:100%; margin:0; }
        body { font-family: Segoe UI, Arial, sans-serif; font-size:13px; background:#f4f6f8; }

        /* Fixed-height popup: the toolbar/title stay put and only the grid
           area scrolls (both directions), instead of the whole popup growing
           tall and needing a long page-level scroll to reach the last row. */
        .report-wrap { display:flex; flex-direction:column; height:100vh; padding:16px; box-sizing:border-box; }
        .report-top { flex-shrink:0; }
        .report-scroll { flex:1; overflow:auto; margin-top:4px; }

        .toolbar { margin-bottom:12px; display:flex; align-items:center; gap:12px; }
        h3 { color:#1f3b57; margin-top:0; }
        table.grid-view { border-collapse:collapse; width:100%; background:#fff; }
        table.grid-view th, table.grid-view td { border:1px solid #dde3e8; padding:6px 10px; font-size:12px; white-space:nowrap; }
        table.grid-view th { background:#1f3b57; color:#fff; }
        /* Freeze header row: stays pinned to the top of .report-scroll while
           scrolling down. Each grid-view keeps its own thead sticky (grouped
           reports render one table per group), and the inline background
           AppendHtmlTable already writes on every <th> keeps rows from
           showing through underneath it. */
        table.grid-view thead th { position:sticky; top:0; z-index:2; }
        table.grid-view tbody tr:hover { background:#eef6ff; cursor:pointer; }
        .select-col { text-align:center; width:36px; }

        /* toolbar action buttons - asp:Button renders <input type=submit>,
           #btnEditSelected is a plain <button>, #btnExcel is an asp:LinkButton
           (<a>, so it can hold the inline SVG icon below) - style all three
           consistently */
        .toolbar input[type=submit],
        .toolbar button,
        .toolbar a.btn-action {
            display: inline-flex;
            align-items: center;
            gap: 7px;
            padding: 9px 20px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            font-size: 13px;
            font-weight: 600;
            letter-spacing: .2px;
            color: #fff;
            text-decoration: none;
            box-shadow: 0 2px 5px rgba(0,0,0,0.15);
            transition: transform .12s ease, box-shadow .12s ease, filter .12s ease;
        }
        .toolbar input[type=submit]:hover,
        .toolbar button:hover,
        .toolbar a.btn-action:hover {
            transform: translateY(-1px);
            box-shadow: 0 4px 10px rgba(0,0,0,0.22);
            filter: brightness(1.06);
        }
        .toolbar input[type=submit]:active,
        .toolbar button:active,
        .toolbar a.btn-action:active {
            transform: translateY(0);
            box-shadow: 0 1px 3px rgba(0,0,0,0.18);
            filter: brightness(0.97);
        }
        #btnRefresh { background: linear-gradient(135deg, #3a6ea5, #24466b); }
        #btnExcel   { background: linear-gradient(135deg, #3cb878, #1f7a4d); }
        #btnEditSelected { background: linear-gradient(135deg, #35516f, #1f3b57); }
        #btnCancel { background: linear-gradient(135deg, #8a94a3, #5a6472); margin-left:auto; }
        #txtGridSearch {
            padding:7px 10px;
            border:1px solid #cfd8e2;
            border-radius:4px;
            font-size:13px;
            width:240px;
        }
        #txtGridSearch:focus {
            outline:none;
            border-color:#2e8b57;
            box-shadow:0 0 0 3px rgba(46,139,87,0.15);
        }
        #ddlFieldSearch {
            padding:6px 8px;
            border:1px solid #cfd8e2;
            border-radius:4px;
            font-size:13px;
        }
        #txtFieldSearchValue {
            padding:7px 10px;
            border:1px solid #cfd8e2;
            border-radius:4px;
            font-size:13px;
            width:180px;
        }
        #txtFieldSearchValue:focus {
            outline:none;
            border-color:#2e8b57;
            box-shadow:0 0 0 3px rgba(46,139,87,0.15);
        }
        .filter-label { color:#1f3b57; font-weight:600; font-size:12.5px; }
        .date-input {
            padding:6px 8px;
            border:1px solid #cfd8e2;
            border-radius:4px;
            font-size:13px;
        }
        .date-input:focus {
            outline:none;
            border-color:#2e8b57;
            box-shadow:0 0 0 3px rgba(46,139,87,0.15);
        }
        #lblNoMatch { display:none; color:#a33; font-size:12.5px; margin-top:8px; }
        table.grid-view tfoot td, table.grid-view tr.grid-view-footer td { background:#eef2f5; font-weight:700; }

        /* Group & Sort -> Group By: each group renders as its own card with its
           own heading and its own grid (and its own subtotal footer, if
           Calculate & Summarize has fields selected) instead of one grid with
           banner rows. */
        /* .group-block intentionally has no "overflow:hidden" (it used to, for
           rounded corners) and .group-grid-wrap intentionally has no
           "overflow-x:auto" of its own - either one would make that element
           the nearest scrolling ancestor for CSS position:sticky purposes,
           which would pin each group's header to that (non-scrolling) box
           instead of to .report-scroll, silently breaking the frozen header
           for grouped reports. Horizontal scrolling for every group's table
           is handled once, at the .report-scroll level, instead. */
        .group-block { margin-bottom:20px; border:1px solid #dde3e8; border-radius:6px; background:#fff; }
        .group-banner-cell { background:#1f3b57; color:#fff; font-weight:700; padding:9px 12px; border-radius:6px 6px 0 0; }
        .group-banner-cell .group-count { font-weight:400; color:#cbd9ea; font-size:11.5px; margin-left:8px; }
        .group-block table.grid-view { margin:0; }
    </style>
    <script type="text/javascript">
        function selectRow(radio) {
            document.getElementById('hdnSelectedJobNo').value = radio.value;
        }
        function rowClicked(row) {
            var radio = row.querySelector('input[type=radio]');
            if (radio) {
                radio.checked = true;
                selectRow(radio);
            }
        }
        function openCenteredPopup(url, name, w, h) {
            var left = Math.max(0, (screen.width - w) / 2);
            var top = Math.max(0, (screen.height - h) / 2);
            window.open(url, name,
                'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');
        }

        function openEntryForSelected() {
            var jobNo = document.getElementById('hdnSelectedJobNo').value;
            var templateId = document.getElementById('hdnTemplateId').value;
            if (!jobNo) { alert('Select a row first.'); return; }
            openCenteredPopup(
                'DSREntry.aspx?TemplateID=' + templateId + '&JOBNO=' + encodeURIComponent(jobNo),
                'dsrEntry_' + jobNo,
                1080, 700
            );
        }

        // global search across every column of every grid - client-side, since
        // the columns themselves are dynamic (AutoGenerateColumns) and unknown
        // ahead of time, so this just matches on each row's full text. Grouped
        // reports render one table.grid-view per group, so this walks all of
        // them instead of just the first.
        function closestGroupBlock(el) {
            while (el && el !== document.body) {
                if (el.className && (' ' + el.className + ' ').indexOf(' group-block ') > -1) return el;
                el = el.parentNode;
            }
            return null;
        }

        function filterGrid(term) {
            term = (term || '').toLowerCase();
            var tables = document.querySelectorAll('table.grid-view');
            if (!tables.length) return;

            var visibleCount = 0;
            for (var t = 0; t < tables.length; t++) {
                var table = tables[t];
                var groupBlock = closestGroupBlock(table);
                var groupVisibleCount = 0;

                for (var i = 0; i < table.rows.length; i++) {
                    var row = table.rows[i];
                    if (row.cells.length && row.cells[0].tagName === 'TH') continue; // header row

                    var text = (row.textContent || row.innerText || '').toLowerCase();
                    var isMatch = term === '' || text.indexOf(term) > -1;
                    row.style.display = isMatch ? '' : 'none';
                    if (isMatch) { visibleCount++; groupVisibleCount++; }
                }

                // hide the whole group card (heading included) when none of its rows match
                if (groupBlock) groupBlock.style.display = (term !== '' && groupVisibleCount === 0) ? 'none' : '';
            }

            var noMatch = document.getElementById('lblNoMatch');
            if (noMatch) noMatch.style.display = (term !== '' && visibleCount === 0) ? 'block' : 'none';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="report-wrap">
        <div class="report-top">
            <h3><asp:Label ID="lblTitle" runat="server" /></h3>
            <div class="toolbar">
                <label class="filter-label">Group Name</label>
                <%-- Same concept as DSR_Template/Import_Dynamicreport.aspx's ListBox1:
                     multi-select of TBL_GROUPMASTER groups, turned into the
                     Bootstrap multiselect widget by the script in <head>. No
                     selection = every group/branch (same "empty = All" default
                     BuildReportTable already uses for the importer/exporter
                     filter), so existing templates keep working unchanged. --%>
                <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="180px"></asp:ListBox>
                <label class="filter-label">From Date</label>
                <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" CssClass="date-input" />
                <label class="filter-label">To Date</label>
                <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" CssClass="date-input" />
                <%-- Enter here submits the form (hits btnRefresh, the first submit
                     button) so the search term is re-queried against the database -
                     see BindReport(), which now passes txtGridSearch's value into
                     BuildReportTable. onkeyup still narrows whatever's already on
                     screen instantly, as a preview while typing, before Enter runs
                     the real DB search. --%>
                <input type="text" id="txtGridSearch" runat="server" ClientIDMode="Static" placeholder="Search..."
                    onkeyup="filterGrid(this.value);" />
                <%-- Per-field search: picks one column (populated server-side from the
                     current report's own columns in BindReport) and searches only that
                     column's value against the database - a separate, additive filter
                     from the global search box above, which is untouched. Enter submits
                     the form the same way txtGridSearch does (hits btnRefresh, the first
                     submit button), re-running BindReport() with both filters applied. --%>
                <label class="filter-label">Field Search</label>
                <asp:DropDownList ID="ddlFieldSearch" runat="server" ClientIDMode="Static" />
                <input type="text" id="txtFieldSearchValue" runat="server" ClientIDMode="Static" placeholder="Value..." />
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
                <button type="button" id="btnEditSelected" onclick="openEntryForSelected(); return false;">Edit Custom Data</button>
                <%-- LinkButton (renders <a>), not asp:Button (<input type=submit>, which
                     can't hold child markup) - so the inline SVG icon below can sit next
                     to the label while still posting back to btnExcel_Click. --%>
                <asp:LinkButton ID="btnExcel" runat="server" CssClass="btn-action" OnClick="btnExcel_Click">
                    <svg width="16" height="16" viewBox="0 0 24 24" style="flex-shrink:0;">
                        <path d="M4 2.5C4 1.67 4.67 1 5.5 1H14l6 6v14.5c0 .83-.67 1.5-1.5 1.5h-13C4.67 23 4 22.33 4 21.5v-19z" fill="#fff"/>
                        <path d="M14 1l6 6h-4.5C14.67 7 14 6.33 14 5.5V1z" fill="#cdeede"/>
                        <text x="12" y="18.5" font-family="Segoe UI, Arial, sans-serif" font-size="7.5" font-weight="700" fill="#1f7a4d" text-anchor="middle">XLS</text>
                    </svg>
                    Download as Excel
                </asp:LinkButton>
                <button type="button" id="btnCancel" onclick="window.close(); return false;">Cancel</button>
            </div>
            <div id="lblNoMatch">No rows match your search.</div>
        </div>
        <input type="hidden" id="hdnSelectedJobNo" value="" />
        <asp:HiddenField ID="hdnTemplateId" runat="server" ClientIDMode="Static" />
        <div class="report-scroll">
            <%-- Report body is hand-written HTML (see TemplateReport.aspx.cs), not an
                 asp:GridView - a GridView builds one TableCell/TableRow object per
                 cell, which for a few hundred columns times a few thousand rows means
                 millions of heavyweight control objects, dwarfing the actual data and
                 the real cause behind large-template OutOfMemoryExceptions here. --%>
            <asp:Literal ID="litReport" runat="server" Mode="PassThrough" EnableViewState="false" />
        </div>
    </div>
    </form>
</body>
</html>
