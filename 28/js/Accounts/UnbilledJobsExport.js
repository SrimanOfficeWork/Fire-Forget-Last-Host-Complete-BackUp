function exportToExcel() {

    // Preferred: set this inline on the page before including this script:
    //   <script>var gvUnbilledJobsClientId = '<%= gvUnbilledJobs.ClientID %>';</script>
    var GRID_ID = (typeof gvUnbilledJobsClientId !== 'undefined' && gvUnbilledJobsClientId)
        ? gvUnbilledJobsClientId
        : 'gvUnbilledJobs';
    var REPORT_TITLE = 'Unbilled Jobs Report';
    var JOB_DATE_HEADER_MATCH = /job\s*date/i;   // column used for month grouping
    var EXPENSE_AMT_HEADER_MATCH = /expense\s*amt/i; // column used for the total row

    function resolveGrid(idGuess) {
        // 1) Exact match on the ID we were given.
        var el = document.getElementById(idGuess);
        if (el) return el;

        // 2) Fallback: match any element whose ID *ends with* "gvUnbilledJobs",
        //    which handles master-page/naming-container prefixes like
        //    "ctl00_ContentPlaceHolder1_gvUnbilledJobs".
        el = document.querySelector("[id$='gvUnbilledJobs']");
        if (el) return el;

        return null;
    }

    var grid = resolveGrid(GRID_ID);
    if (!grid) {
        console.error('exportToExcel: could not find the GridView. ' +
            'Checked ID "' + GRID_ID + '" and any element ending in "gvUnbilledJobs". ' +
            'Open DevTools > Inspect the grid table and confirm its rendered id attribute.');
        alert('Grid not found');
        return;
    }

    // ---------------------------------------------------------------------
    // 1. Helpers
    // ---------------------------------------------------------------------

    function escapeXml(str) {
        if (str === null || str === undefined) return '';
        return String(str)
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&apos;');
    }

    // Clean visible text from a cell: strips tags (via innerText), removes
    // &nbsp; (rendered as \u00A0), collapses whitespace.
    function cleanText(cell) {
        var t = (cell.innerText !== undefined ? cell.innerText : cell.textContent) || '';
        t = t.replace(/\u00A0/g, ' ');
        t = t.replace(/\s+/g, ' ').trim();
        return t;
    }

    function rowToArray(row) {
        var arr = [];
        for (var c = 0; c < row.cells.length; c++) {
            arr.push(cleanText(row.cells[c]));
        }
        return arr;
    }

    // Flexible date parser: handles ISO, dd/mm/yyyy, mm/dd/yyyy, dd-mm-yyyy, etc.
    function parseFlexibleDate(str) {
        if (!str) return null;
        str = str.trim();
        if (!str) return null;

        var d = new Date(str);
        if (!isNaN(d.getTime())) return d;

        var m = str.match(/^(\d{1,2})[\/\-.](\d{1,2})[\/\-.](\d{2,4})/);
        if (m) {
            var a = parseInt(m[1], 10);
            var b = parseInt(m[2], 10);
            var year = parseInt(m[3], 10);
            if (year < 100) year += 2000;

            var day = a, month = b;
            if (month > 12 && day <= 12) { // looks like mm/dd/yyyy actually
                day = b; month = a;
            }
            var d2 = new Date(year, month - 1, day);
            if (!isNaN(d2.getTime())) return d2;
        }
        return null;
    }

    // Turns "1,234.56" / "1234.56" / "" into a number (0 if not parseable).
    function parseAmount(str) {
        if (!str) return 0;
        var n = parseFloat(String(str).replace(/,/g, '').trim());
        return isNaN(n) ? 0 : n;
    }

    var MONTH_NAMES = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
                        'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

    // ---------------------------------------------------------------------
    // 2. Extract header + data (fixes the "missing header" scroll bug)
    // ---------------------------------------------------------------------

    var headerCells = [];
    var dataRowsRaw = [];

    var scrollHeaderTable = document.querySelector('.GridViewScrollHeader table');

    if (scrollHeaderTable && scrollHeaderTable.rows.length > 0) {
        // Scrolling grid: header lives in a separate table entirely.
        var hRow = scrollHeaderTable.rows[0];
        for (var i = 0; i < hRow.cells.length; i++) {
            headerCells.push(cleanText(hRow.cells[i]));
        }
        for (var r = 0; r < grid.rows.length; r++) {
            dataRowsRaw.push(grid.rows[r]);
        }
    } else {
        // Non-scrolling grid: first row of the grid itself is the header.
        if (grid.rows.length === 0) {
            alert('No data to export');
            return;
        }
        var hRow2 = grid.rows[0];
        for (var j = 0; j < hRow2.cells.length; j++) {
            headerCells.push(cleanText(hRow2.cells[j]));
        }
        for (var r2 = 1; r2 < grid.rows.length; r2++) {
            dataRowsRaw.push(grid.rows[r2]);
        }
    }

    if (headerCells.length === 0) {
        alert('Could not read grid header');
        return;
    }

    var colCount = headerCells.length;

    // Only keep rows whose cell count matches the header (drops empty-data /
    // pager / footer rows that use colspan or a different cell count, which
    // would otherwise corrupt the grid or get summed into the total twice).
    var dataMatrix = [];
    for (var d = 0; d < dataRowsRaw.length; d++) {
        var row = dataRowsRaw[d];
        if (row.cells.length === colCount &&
            row.className.indexOf('gridFooterRow') === -1) {
            dataMatrix.push(rowToArray(row));
        }
    }

    if (dataMatrix.length === 0) {
        alert('No data to export');
        return;
    }

    // ---------------------------------------------------------------------
    // 3. Expense Amt total (for the "Total Expense Amount" row under the data)
    // ---------------------------------------------------------------------

    var expenseColIndex = -1;
    for (var ec = 0; ec < headerCells.length; ec++) {
        if (EXPENSE_AMT_HEADER_MATCH.test(headerCells[ec])) {
            expenseColIndex = ec;
            break;
        }
    }

    var expenseTotal = 0;
    if (expenseColIndex !== -1) {
        for (var et = 0; et < dataMatrix.length; et++) {
            expenseTotal += parseAmount(dataMatrix[et][expenseColIndex]);
        }
    }

    // ---------------------------------------------------------------------
    // 4. Month-wise summary (grouped from the "Job Date" column)
    // ---------------------------------------------------------------------

    var jobDateColIndex = -1;
    for (var hc = 0; hc < headerCells.length; hc++) {
        if (JOB_DATE_HEADER_MATCH.test(headerCells[hc])) {
            jobDateColIndex = hc;
            break;
        }
    }

    var summaryRows = []; // [{ label: 'Jan-2026', count: 15, sortKey: 202601 }]

    if (jobDateColIndex !== -1) {
        var monthMap = {}; // key -> { count, sortKey }
        for (var m2 = 0; m2 < dataMatrix.length; m2++) {
            var rawDate = dataMatrix[m2][jobDateColIndex];
            var parsed = parseFlexibleDate(rawDate);
            if (!parsed) continue;

            var key = MONTH_NAMES[parsed.getMonth()] + '-' + parsed.getFullYear();
            var sortKey = parsed.getFullYear() * 100 + (parsed.getMonth() + 1);

            if (!monthMap[key]) {
                monthMap[key] = { count: 0, sortKey: sortKey };
            }
            monthMap[key].count++;
        }

        for (var key2 in monthMap) {
            if (monthMap.hasOwnProperty(key2)) {
                summaryRows.push({
                    label: key2,
                    count: monthMap[key2].count,
                    sortKey: monthMap[key2].sortKey
                });
            }
        }
        summaryRows.sort(function (a, b) { return a.sortKey - b.sortKey; });
    }

    // ---------------------------------------------------------------------
    // 5. Build the SpreadsheetML (Excel XML) document
    // ---------------------------------------------------------------------

    var xml = '';
    xml += '<?xml version="1.0" encoding="UTF-8"?>' + '\r\n';
    xml += '<?mso-application progid="Excel.Sheet"?>' + '\r\n';
    xml += '<Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet" ' +
           'xmlns:o="urn:schemas-microsoft-com:office:office" ' +
           'xmlns:x="urn:schemas-microsoft-com:office:excel" ' +
           'xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">';

    // ---- Styles ----
    xml += '<Styles>';

    xml += '<Style ss:ID="TitleStyle">' +
               '<Font ss:Bold="1" ss:Size="16" ss:Color="#1F1F1F"/>' +
               '<Alignment ss:Horizontal="Center" ss:Vertical="Center"/>' +
           '</Style>';

    xml += '<Style ss:ID="HeaderStyle">' +
               '<Font ss:Bold="1" ss:Color="#FFFFFF" ss:Size="11"/>' +
               '<Interior ss:Color="#008000" ss:Pattern="Solid"/>' +
               '<Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>' +
               '<Borders>' +
                   '<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>' +
               '</Borders>' +
           '</Style>';

    xml += '<Style ss:ID="CellStyle">' +
               '<Alignment ss:Horizontal="Left" ss:Vertical="Center"/>' +
               '<Borders>' +
                   '<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>' +
               '</Borders>' +
           '</Style>';

    // Row placed directly under the data: label in the column just before
    // "Expense Amt", value inside the "Expense Amt" column - matches the
    // grid's own footer layout.
    xml += '<Style ss:ID="TotalLabelStyle">' +
               '<Font ss:Bold="1" ss:Size="11" ss:Color="#1F1F1F"/>' +
               '<Alignment ss:Horizontal="Right" ss:Vertical="Center"/>' +
               '<Borders>' +
                   '<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>' +
               '</Borders>' +
           '</Style>';

    xml += '<Style ss:ID="TotalValueStyle">' +
               '<Font ss:Bold="1" ss:Size="11" ss:Color="#1F1F1F"/>' +
               '<Interior ss:Color="#D9EAD3" ss:Pattern="Solid"/>' +
               '<Alignment ss:Horizontal="Right" ss:Vertical="Center"/>' +
               '<NumberFormat ss:Format="#,##0.00"/>' +
               '<Borders>' +
                   '<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>' +
               '</Borders>' +
           '</Style>';

    xml += '<Style ss:ID="SummaryTitleStyle">' +
               '<Font ss:Bold="1" ss:Size="13" ss:Color="#1F1F1F"/>' +
               '<Alignment ss:Horizontal="Left" ss:Vertical="Center"/>' +
           '</Style>';

    xml += '<Style ss:ID="SummaryHeaderStyle">' +
               '<Font ss:Bold="1" ss:Color="#FFFFFF" ss:Size="11"/>' +
               '<Interior ss:Color="#2F4F6F" ss:Pattern="Solid"/>' +
               '<Alignment ss:Horizontal="Center" ss:Vertical="Center"/>' +
               '<Borders>' +
                   '<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>' +
               '</Borders>' +
           '</Style>';

    xml += '<Style ss:ID="SummaryCellStyle">' +
               '<Alignment ss:Horizontal="Center" ss:Vertical="Center"/>' +
               '<Borders>' +
                   '<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>' +
                   '<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>' +
               '</Borders>' +
           '</Style>';

    xml += '</Styles>';

    // ---- Worksheet ----
    xml += '<Worksheet ss:Name="UnbilledJobs">';
    xml += '<Table>';

    // Column widths: size roughly to header text length, clamped.
    for (var cw = 0; cw < colCount; cw++) {
        var w = Math.max(80, Math.min(220, headerCells[cw].length * 9 + 40));
        xml += '<Column ss:Width="' + w + '"/>';
    }

    // Title row (merged across all data columns)
    xml += '<Row ss:Height="26">';
    xml += '<Cell ss:StyleID="TitleStyle" ss:MergeAcross="' + (colCount - 1) + '">' +
               '<Data ss:Type="String">' + escapeXml(REPORT_TITLE) + '</Data>' +
           '</Cell>';
    xml += '</Row>';

    // Blank spacer row
    xml += '<Row ss:Height="6"></Row>';

    // Header row
    xml += '<Row ss:Height="22">';
    for (var hIdx = 0; hIdx < headerCells.length; hIdx++) {
        xml += '<Cell ss:StyleID="HeaderStyle"><Data ss:Type="String">' +
               escapeXml(headerCells[hIdx]) + '</Data></Cell>';
    }
    xml += '</Row>';

    // Data rows
    for (var dr = 0; dr < dataMatrix.length; dr++) {
        xml += '<Row>';
        var rowArr = dataMatrix[dr];
        for (var cIdx = 0; cIdx < rowArr.length; cIdx++) {
            xml += '<Cell ss:StyleID="CellStyle"><Data ss:Type="String">' +
                   escapeXml(rowArr[cIdx]) + '</Data></Cell>';
        }
        xml += '</Row>';
    }

    // ---- Total Expense Amount row (right under the data, same layout as
    //      the grid's own footer: label to the LEFT of "Expense Amt",
    //      total INSIDE the "Expense Amt" column) ----
    if (expenseColIndex !== -1) {
        xml += '<Row>';
        for (var tc = 0; tc < colCount; tc++) {
            if (tc === expenseColIndex - 1) {
                xml += '<Cell ss:StyleID="TotalLabelStyle"><Data ss:Type="String">Total Expense Amount</Data></Cell>';
            } else if (tc === expenseColIndex) {
                xml += '<Cell ss:StyleID="TotalValueStyle"><Data ss:Type="Number">' +
                       expenseTotal.toFixed(2) + '</Data></Cell>';
            } else {
                xml += '<Cell ss:StyleID="CellStyle"><Data ss:Type="String"></Data></Cell>';
            }
        }
        xml += '</Row>';
    }

    // ---- Month-wise summary section ----
    if (summaryRows.length > 0) {
        // Two blank spacer rows before the summary
        xml += '<Row ss:Height="6"></Row>';
        xml += '<Row ss:Height="6"></Row>';

        xml += '<Row ss:Height="22">';
        xml += '<Cell ss:StyleID="SummaryTitleStyle" ss:MergeAcross="' +
               Math.max(1, colCount - 1) + '">' +
               '<Data ss:Type="String">Month-wise Unbilled Summary</Data>' +
           '</Cell>';
        xml += '</Row>';

        xml += '<Row ss:Height="6"></Row>';

        xml += '<Row>';
        xml += '<Cell ss:StyleID="SummaryHeaderStyle"><Data ss:Type="String">Month</Data></Cell>';
        xml += '<Cell ss:StyleID="SummaryHeaderStyle"><Data ss:Type="String">Unbilled Count</Data></Cell>';
        xml += '</Row>';

        for (var sr = 0; sr < summaryRows.length; sr++) {
            xml += '<Row>';
            xml += '<Cell ss:StyleID="SummaryCellStyle"><Data ss:Type="String">' +
                   escapeXml(summaryRows[sr].label) + '</Data></Cell>';
            xml += '<Cell ss:StyleID="SummaryCellStyle"><Data ss:Type="Number">' +
                   summaryRows[sr].count + '</Data></Cell>';
            xml += '</Row>';
        }
    }

    xml += '</Table>';

    // Freeze the title + header rows (2 rows) so they stay visible on scroll.
    xml += '<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">' +
               '<Selected/>' +
               '<FreezePanes/>' +
               '<FrozenNoSplit/>' +
               '<SplitHorizontal>3</SplitHorizontal>' +
               '<TopRowBottomPane>3</TopRowBottomPane>' +
               '<ActivePane>2</ActivePane>' +
           '</WorksheetOptions>';

    xml += '</Worksheet>';
    xml += '</Workbook>';

    // ---------------------------------------------------------------------
    // 6. Download as .xls
    // ---------------------------------------------------------------------

    var blob = new Blob([xml], { type: 'application/vnd.ms-excel' });
    var link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = 'UnbilledJobsReport.xls';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    URL.revokeObjectURL(link.href);
}