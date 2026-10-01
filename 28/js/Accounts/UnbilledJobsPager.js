var UnbilledJobsPager = (function ($) {
    var PAGE_SIZE = 20;
    var currentPage = 1;
    var allRows = [];        // real data <tr> elements only (header/footer/pager/empty rows excluded)
    var footerRow = null;    // the GridView's footer <tr> - kept OUT of paging entirely
    var totalExpenseText = '0.00';

    function resolveGrid(idGuess) {
        var el = document.getElementById(idGuess);
        if (el) return el;
        // Fallback for master-page prefixed IDs, same trick as the export script.
        el = document.querySelector("[id$='gvUnbilledJobs']");
        return el;
    }

    function getGrid() {
        var GRID_ID = (typeof gvUnbilledJobsClientId !== 'undefined' && gvUnbilledJobsClientId)
            ? gvUnbilledJobsClientId
            : 'gvUnbilledJobs';
        return resolveGrid(GRID_ID);
    }

    function init() {
        var grid = getGrid();
        if (!grid || !grid.rows || grid.rows.length === 0) {
            var $pager = $('#gridPager');
            if ($pager.length) { $pager.empty(); }
            return;
        }

        var headerRow = grid.rows[0];
        var headerColCount = headerRow.cells.length;

        allRows = [];
        footerRow = null;

        for (var r = 1; r < grid.rows.length; r++) {
            var row = grid.rows[r];

            // The footer row is rendered with CssClass="gridFooterRow" (see RowCreated in the
            // code-behind). It must NEVER be treated as a data row, or paging hides it on
            // every page except whichever page its index happens to fall on.
            if (row.className && row.className.indexOf('gridFooterRow') !== -1) {
                footerRow = row;
                continue;
            }

            // Same filter as before: drops the "NO RECORD FOUND" row and any colspan rows,
            // keeps only real data rows.
            if (row.cells.length === headerColCount) {
                allRows.push(row);
            }
        }

        // Capture the total ONCE, straight from the footer label, before paging touches
        // anything. BindTotalExpense() in the code-behind already summed the FULL dataset
        // (not just the current page), so this value is correct regardless of which page
        // the user is looking at.
        if (footerRow) {
            var $totalLbl = $(footerRow).find('#lblTotalExpense');
            totalExpenseText = $totalLbl.length ? $.trim($totalLbl.text()) : '0.00';

            // The footer row now stays visible permanently at the bottom of the grid
            // (it's excluded from the hide/show loop above). If you'd rather show the
            // total ONLY in the pager and hide the grid's own footer row, uncomment:
            // footerRow.style.display = 'none';
        } else {
            totalExpenseText = '0.00';
        }

        currentPage = 1;
        renderPage(1);
    }

    function renderPage(page) {
        var totalRows = allRows.length;
        var totalPages = Math.max(1, Math.ceil(totalRows / PAGE_SIZE));
        currentPage = Math.min(Math.max(1, page), totalPages);
        var start = (currentPage - 1) * PAGE_SIZE;
        var end = start + PAGE_SIZE;
        for (var i = 0; i < allRows.length; i++) {
            allRows[i].style.display = (i >= start && i < end) ? '' : 'none';
        }
        renderPagerUI(currentPage, totalPages, totalRows);
    }

    function renderPagerUI(page, totalPages, totalRows) {
        var $pager = $('#gridPager');
        if ($pager.length === 0) return;

        var html = '';
        html += '<span style="float:left;margin-left:14px;font-weight:bold;color:#333;">' +
                    'Total Expense Amt: ' + totalExpenseText +
                '</span>';
        html += '<span style="margin-right:14px;color:#555;">' + totalRows + ' record(s) found</span>';
        html += '<button type="button" class="pager-btn" onclick="UnbilledJobsPager.goTo(1)" ' +
                (page === 1 ? 'disabled' : '') + '>&laquo; First</button> ';
        html += '<button type="button" class="pager-btn" onclick="UnbilledJobsPager.goTo(' + (page - 1) + ')" ' +
                (page === 1 ? 'disabled' : '') + '>&lsaquo; Prev</button> ';
        html += '<span style="margin:0 12px;font-weight:bold;">Page ' + page + ' of ' + totalPages + '</span>';
        html += '<button type="button" class="pager-btn" onclick="UnbilledJobsPager.goTo(' + (page + 1) + ')" ' +
                (page === totalPages ? 'disabled' : '') + '>Next &rsaquo;</button> ';
        html += '<button type="button" class="pager-btn" onclick="UnbilledJobsPager.goTo(' + totalPages + ')" ' +
                (page === totalPages ? 'disabled' : '') + '>Last &raquo;</button>';

        $pager.html(html);
    }

    return {
        init: init,       // call on page load
        goTo: renderPage, // called by the pager buttons
        refresh: init     // call this if you ever rebind the grid without a full postback (e.g. AJAX/UpdatePanel)
    };
})(jQuery);

$(document).ready(function () {
    UnbilledJobsPager.init();
});