<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Change_Branch.aspx.cs" Inherits="Change_Branch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Change Branch</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style type="text/css">
        :root {
            --pmb-bg-panel: #ffffff;
            --pmb-bg-panel-alt: #f2f4fa;
            --pmb-border: rgba(20, 28, 55, 0.10);
            --pmb-border-soft: rgba(20, 28, 55, 0.06);
            --pmb-text-primary: #1a2137;
            --pmb-text-muted: #5b6584;
            --pmb-text-faint: #8892ac;
            --pmb-accent: #2563eb;
            --pmb-accent-2: #0ea5b7;
            --pmb-danger: #dc2626;
            --pmb-radius: 10px;
            --pmb-font: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
        }
        * { box-sizing: border-box; }
        html, body {
            margin: 0;
            padding: 0;
            background: var(--pmb-bg-panel);
            font-family: var(--pmb-font);
            color: var(--pmb-text-primary);
            /* This page loads inside a small FIXED-HEIGHT iframe (270px - see
               .pm-branch-modal-frame in premium-theme.css). overflow:hidden here used to
               mean anything taller than that - like the "Select Branch" dropdown panel,
               which opens near the bottom of the card - was silently clipped with no way
               to reach it. overflow-y left to its default (visible, which the browser
               treats as auto on the root) lets the iframe grow its own scrollbar instead,
               so the panel can spill past the popup's edge without ever being cut off.
               overflow-x stays hidden since nothing on this page needs to scroll sideways. */
            overflow-x: hidden;
        }
        .pmb-card {
            display: flex;
            flex-direction: column;
            height: 100%;
            padding: 20px 22px 18px 22px;
        }
        .pmb-header {
            display: flex;
            align-items: center;
            gap: 8px;
            margin-bottom: 16px;
        }
        .pmb-header-text {
            font-size: 14px;
            font-weight: 700;
            color: var(--pmb-text-primary);
        }
        .pmb-body { flex: 1; min-height: 0; }
        .pmb-field { margin-bottom: 30px; }
        .pmb-field-last { margin-bottom: 8px; }

        /* Material "Outlined TextField" look: border runs all the way around, and the
           label sits notched into the top border line (bg-colored backdrop behind the
           label text punches a gap through the border) instead of floating above it. */
        .pmb-outlined {
            position: relative;
            margin-top: 20px;
        }
        .pmb-outlined label {
            position: absolute;
            top: -8px;
            left: 10px;
            padding: 0 6px;
            background: var(--pmb-bg-panel);
            font-size: 10.5px;
            font-weight: 700;
            letter-spacing: .3px;
            text-transform: uppercase;
            color: var(--pmb-text-faint);
            pointer-events: none;
            z-index: 1;
        }
        .pmb-select {
            width: 100%;
            height: 38px;
            padding: 0 30px 0 12px;
            font-family: var(--pmb-font);
            font-size: 12.5px;
            font-weight: 600;
            color: var(--pmb-text-primary);
            background: var(--pmb-bg-panel) url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 24 24' fill='none' stroke='%235b6584' stroke-width='2' stroke-linecap='round' stroke-linejoin='round'%3E%3Cpolyline points='6 9 12 15 18 9'%3E%3C/polyline%3E%3C/svg%3E") no-repeat right 10px center;
            background-size: 15px;
            border: 1.5px solid var(--pmb-border);
            border-radius: var(--pmb-radius);
            appearance: none;
            -webkit-appearance: none;
            -moz-appearance: none;
            cursor: pointer;
            transition: border-color .15s ease, box-shadow .15s ease;
        }
        /* Style the native <option> list itself (font/colors/padding) so the dropdown
           that opens matches the outlined field's look wherever the browser allows it. */
        .pmb-select option {
            font-family: var(--pmb-font);
            font-size: 12.5px;
            font-weight: 600;
            color: var(--pmb-text-primary);
            background: var(--pmb-bg-panel);
            padding: 8px 10px;
        }
        .pmb-select option:checked {
            color: var(--pmb-accent);
            background: rgba(37, 99, 235, .10);
        }
        .pmb-select:focus + label {
            color: var(--pmb-accent);
        }
        .pmb-select:focus {
            outline: none;
            border-color: rgba(37, 99, 235, .45);
            box-shadow: 0 0 0 3px rgba(37, 99, 235, .12);
        }

        /* Custom dropdown list (built by JS) - the native <select> popup can't be styled
           consistently across browsers, so once JS runs, the real <select> is hidden
           (kept only to carry the posted value / fire AutoPostBack) and this fully
           CSS-controlled trigger + panel is shown instead, matching the outlined field. */
        select.pmb-select.pmb-js-enhanced { display: none; }
        .pmb-outlined.pmb-focused label { color: var(--pmb-accent); }
        .pmb-select-display {
            display: flex;
            align-items: center;
            width: 100%;
            height: 38px;
            padding: 0 30px 0 12px;
            font-family: var(--pmb-font);
            font-size: 12.5px;
            font-weight: 600;
            color: var(--pmb-text-primary);
            background: var(--pmb-bg-panel);
            border: 1.5px solid var(--pmb-border);
            border-radius: var(--pmb-radius);
            cursor: pointer;
            user-select: none;
            position: relative;
            transition: border-color .15s ease, box-shadow .15s ease;
        }
        .pmb-select-display::after {
            content: "";
            position: absolute;
            right: 10px;
            top: 50%;
            width: 15px;
            height: 15px;
            margin-top: -8px;
            background: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 24 24' fill='none' stroke='%235b6584' stroke-width='2' stroke-linecap='round' stroke-linejoin='round'%3E%3Cpolyline points='6 9 12 15 18 9'%3E%3C/polyline%3E%3C/svg%3E") no-repeat center;
            background-size: 15px;
            transition: transform .15s ease;
        }
        .pmb-select-display.open::after { transform: rotate(180deg); }
        .pmb-select-display.open,
        .pmb-select-display:focus {
            outline: none;
            border-color: rgba(37, 99, 235, .45);
            box-shadow: 0 0 0 3px rgba(37, 99, 235, .12);
        }
        .pmb-select-panel {
            display: none;
            position: absolute;
            left: 0;
            right: 0;
            top: calc(100% + 6px);
            background: var(--pmb-bg-panel);
            border: 1px solid var(--pmb-border);
            border-radius: var(--pmb-radius);
            box-shadow: 0 14px 32px rgba(30, 41, 80, .20);
            padding: 6px;
            z-index: 30;
            overflow: hidden;
            /* Always opens downward from the field, regardless of how much room is left
               in the small iframe modal this page loads into - fine for it to spill past
               the popup's edge rather than flipping upward. */
            max-height: 220px;
        }
        .pmb-select-panel.open { display: flex; flex-direction: column; animation: pmbPanelPop .14s ease; }
        @keyframes pmbPanelPop {
            from { opacity: 0; transform: translateY(-4px) scale(.98); }
            to { opacity: 1; transform: translateY(0) scale(1); }
        }
        /* Search box - only added by JS when a dropdown has enough options to be worth
           filtering (see NEEDS_SEARCH in initPmbCustomSelects), so short lists like
           "Select Group" stay exactly as compact as before. */
        .pmb-select-search-wrap {
            position: relative;
            flex: 0 0 auto;
            padding: 2px 2px 6px 2px;
        }
        .pmb-select-search-wrap::after {
            content: "";
            position: absolute;
            left: 10px;
            top: 50%;
            width: 12px;
            height: 12px;
            margin-top: -5px;
            background: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 24 24' fill='none' stroke='%238892ac' stroke-width='2.5' stroke-linecap='round' stroke-linejoin='round'%3E%3Ccircle cx='11' cy='11' r='7'%3E%3C/circle%3E%3Cpath d='m21 21-4.3-4.3'%3E%3C/path%3E%3C/svg%3E") no-repeat center;
            background-size: 12px;
            pointer-events: none;
        }
        .pmb-select-search {
            width: 100%;
            height: 30px;
            padding: 0 10px 0 28px;
            font-family: var(--pmb-font);
            font-size: 12px;
            font-weight: 600;
            color: var(--pmb-text-primary);
            background: var(--pmb-bg-panel-alt);
            border: 1.5px solid transparent;
            border-radius: 7px;
            outline: none;
            transition: border-color .15s ease, background .15s ease;
        }
        .pmb-select-search:focus { background: var(--pmb-bg-panel); border-color: rgba(37, 99, 235, .4); }
        .pmb-select-list {
            flex: 1 1 auto;
            min-height: 0;
            overflow-y: auto;
            scrollbar-width: thin;
            scrollbar-color: var(--pmb-border) transparent;
        }
        .pmb-select-list::-webkit-scrollbar { width: 7px; }
        .pmb-select-list::-webkit-scrollbar-track { background: transparent; }
        .pmb-select-list::-webkit-scrollbar-thumb { background: var(--pmb-border); border-radius: 10px; }
        .pmb-select-list::-webkit-scrollbar-thumb:hover { background: var(--pmb-text-faint); }
        .pmb-select-option {
            display: flex;
            align-items: center;
            justify-content: space-between;
            gap: 8px;
            padding: 8px 10px;
            margin: 1px 0;
            font-size: 12.5px;
            font-weight: 600;
            color: var(--pmb-text-primary);
            border-radius: 7px;
            cursor: pointer;
            transition: background .1s ease, color .1s ease;
        }
        .pmb-select-option .pmb-opt-check {
            flex: 0 0 auto;
            width: 14px;
            height: 14px;
            opacity: 0;
            background: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 24 24' fill='none' stroke='%232563eb' stroke-width='3' stroke-linecap='round' stroke-linejoin='round'%3E%3Cpolyline points='20 6 9 17 4 12'%3E%3C/polyline%3E%3C/svg%3E") no-repeat center;
            background-size: 14px;
        }
        .pmb-select-option:hover,
        .pmb-select-option.pmb-active { background: var(--pmb-bg-panel-alt); }
        .pmb-select-option.selected { color: var(--pmb-accent); background: rgba(37, 99, 235, .10); }
        .pmb-select-option.selected .pmb-opt-check { opacity: 1; }
        .pmb-select-option.selected.pmb-active { background: rgba(37, 99, 235, .16); }
        .pmb-select-empty {
            padding: 14px 10px;
            font-size: 12px;
            font-weight: 600;
            color: var(--pmb-text-faint);
            text-align: center;
        }
        .pmb-error {
            display: block;
            min-height: 14px;
            font-size: 11px;
            font-weight: 700;
            color: var(--pmb-danger) !important;
            margin-top: 2px;
        }
        .pmb-actions {
            display: flex;
            gap: 8px;
            padding-top: 10px;
            border-top: 1px solid var(--pmb-border-soft);
        }
        .pmb-btn {
            flex: 1;
            height: 38px;
            font-family: var(--pmb-font);
            font-size: 12.5px;
            font-weight: 700;
            border-radius: var(--pmb-radius);
            cursor: pointer;
            border: 1px solid transparent;
            transition: transform .15s ease, box-shadow .15s ease, background .15s ease;
        }
        .pmb-btn-primary {
            background: linear-gradient(135deg, var(--pmb-accent) 0%, #3b82f6 100%);
            color: #fff;
            box-shadow: 0 6px 16px rgba(37, 99, 235, .3);
        }
        .pmb-btn-primary:hover { transform: translateY(-1px); box-shadow: 0 8px 20px rgba(37, 99, 235, .4); }
        .pmb-btn-ghost {
            background: var(--pmb-bg-panel-alt);
            border-color: var(--pmb-border);
            color: var(--pmb-text-primary);
        }
        .pmb-btn-ghost:hover { background: var(--pmb-border-soft); }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div class="pmb-card">
                <div class="pmb-header">
                    <span class="pmb-header-text">Branch Selection</span>
                </div>
                <div class="pmb-body">
                    <div class="pmb-field pmb-outlined">
                        <asp:DropDownList ID="ddlGrpname" runat="server" onkeyup="autotab(this);" CssClass="pmb-select"
                            OnSelectedIndexChanged="ddlGrpname_SelectedIndexChanged" AutoPostBack="true"
                            TabIndex="1">
                        </asp:DropDownList>
                        <label for="ddlGrpname">Select Group</label>
                    </div>
                    <div class="pmb-field pmb-outlined pmb-field-last">
                        <asp:DropDownList ID="ddlSelect_Branch" runat="server" onkeyup="autotab(this);" CssClass="pmb-select"
                            TabIndex="2">
                        </asp:DropDownList>
                        <label for="ddlSelect_Branch">Select Branch</label>
                    </div>
                    <asp:Label ID="lbl_msg" runat="server" CssClass="pmb-error"></asp:Label>
                </div>
                <div class="pmb-actions">
                    <asp:Button ID="btn_Change_Branch" runat="server" CssClass="pmb-btn pmb-btn-primary" Text="Change"
                        TabIndex="3" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                        OnClick="btn_Change_Branch_Click" />
                    <input type="submit" value="Cancel" class="pmb-btn pmb-btn-ghost" onclick="parent.closeBranchSelection();return false;"
                        tabindex="4" id="btnCancel" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->

    <script type="text/javascript">

        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });

        // Replaces each .pmb-select <select>'s native dropdown popup (which browsers
        // render with their own uncustomizable chrome) with a fully CSS-styled
        // trigger + panel, so the open list visually matches the outlined field design.
        // The real <select> is kept (just hidden) so its value still posts back and
        // AutoPostBack (ddlGrpname) still fires normally via a dispatched 'change' event.
        // Lists with more options than this get a filter box at the top of the panel -
        // short ones (like "Select Group", usually a handful of entries) stay as compact
        // as before with no extra chrome.
        var PMB_SEARCH_THRESHOLD = 6;

        // This page always loads inside a small FIXED-HEIGHT iframe (E_royal_Impex_Main.aspx's
        // Branch Selection popup) - an iframe hard-clips its own content to its box in the
        // parent page, so no CSS trick in here can make an open dropdown panel escape that box.
        // When the parent exposes pmMountBranchDropdown() (see E_royal_Impex_Main.aspx), each
        // select's openPanel() below reparents its panel element into the parent document
        // instead, positioned to line up under its own field, so it can genuinely overlap past
        // the popup's edge. Falls back to the normal local (iframe-clipped) panel when this page
        // is opened standalone with no such parent - e.g. during development.
        // pmbExternallyMountedPanel tracks whichever ONE panel (Select Group or Select Branch)
        // is currently reparented out, shared across both selects, so opening one closes the
        // other's externally-mounted panel too.
        var pmbExternallyMountedPanel = null;
        function pmbCloseAllOpenPanels() {
            var openPanels = document.querySelectorAll('.pmb-select-panel.open');
            for (var p = 0; p < openPanels.length; p++) openPanels[p].classList.remove('open');
            var openDisplays = document.querySelectorAll('.pmb-select-display.open');
            for (var d = 0; d < openDisplays.length; d++) openDisplays[d].classList.remove('open');
            var focusedWraps = document.querySelectorAll('.pmb-outlined.pmb-focused');
            for (var w = 0; w < focusedWraps.length; w++) focusedWraps[w].classList.remove('pmb-focused');
            if (pmbExternallyMountedPanel) {
                pmbExternallyMountedPanel.classList.remove('open');
                pmbExternallyMountedPanel = null;
            }
        }
        // Exposed so the parent page can reset THIS iframe's own trigger/label state when it
        // detects a click outside the reparented panel - such a click happens in the PARENT
        // document, so this iframe's own click listeners never see it on their own.
        window.pmbCloseAllOpenPanels = pmbCloseAllOpenPanels;

        function initPmbCustomSelects() {
            var selects = document.querySelectorAll('.pmb-select');
            for (var s = 0; s < selects.length; s++) {
                (function (sel) {
                    var wrap = sel.parentNode;
                    if (!wrap || wrap.className.indexOf('pmb-outlined') === -1) return;

                    var display = document.createElement('div');
                    display.className = 'pmb-select-display';
                    display.tabIndex = 0;
                    display.textContent = sel.options.length ? sel.options[sel.selectedIndex].text : '';

                    var panel = document.createElement('div');
                    panel.className = 'pmb-select-panel';

                    var showSearch = sel.options.length > PMB_SEARCH_THRESHOLD;
                    var searchInput = null;
                    if (showSearch) {
                        var searchWrap = document.createElement('div');
                        searchWrap.className = 'pmb-select-search-wrap';
                        searchInput = document.createElement('input');
                        searchInput.type = 'text';
                        searchInput.className = 'pmb-select-search';
                        searchInput.placeholder = 'Search...';
                        searchInput.autocomplete = 'off';
                        searchWrap.appendChild(searchInput);
                        panel.appendChild(searchWrap);
                    }

                    var list = document.createElement('div');
                    list.className = 'pmb-select-list';
                    panel.appendChild(list);

                    var activeIndex = -1; // keyboard-highlighted row, within the CURRENT (possibly filtered) render

                    function renderOptions(filterText) {
                        list.innerHTML = '';
                        var q = (filterText || '').trim().toLowerCase();
                        var rendered = [];

                        for (var i = 0; i < sel.options.length; i++) {
                            (function (opt, idx) {
                                if (q && opt.text.toLowerCase().indexOf(q) === -1) return;

                                var item = document.createElement('div');
                                item.className = 'pmb-select-option' + (opt.selected ? ' selected' : '');
                                item.setAttribute('data-idx', idx);

                                var label = document.createElement('span');
                                label.textContent = opt.text;
                                var check = document.createElement('span');
                                check.className = 'pmb-opt-check';
                                item.appendChild(label);
                                item.appendChild(check);

                                item.onclick = function () { chooseIndex(idx); };
                                item.addEventListener('mouseenter', function () { setActive(rendered.indexOf(item)); });

                                list.appendChild(item);
                                rendered.push(item);
                            })(sel.options[i], i);
                        }

                        if (rendered.length === 0) {
                            var empty = document.createElement('div');
                            empty.className = 'pmb-select-empty';
                            empty.textContent = 'No matches found';
                            list.appendChild(empty);
                        }

                        activeIndex = -1;
                        return rendered;
                    }

                    function currentRows() {
                        return list.querySelectorAll('.pmb-select-option');
                    }

                    function setActive(idx) {
                        var rows = currentRows();
                        for (var k = 0; k < rows.length; k++) rows[k].classList.remove('pmb-active');
                        if (idx >= 0 && idx < rows.length) {
                            rows[idx].classList.add('pmb-active');
                            rows[idx].scrollIntoView({ block: 'nearest' });
                        }
                        activeIndex = idx;
                    }

                    function chooseIndex(idx) {
                        sel.selectedIndex = idx;
                        display.textContent = sel.options[idx].text;
                        closePanel();
                        var evt;
                        try { evt = new Event('change', { bubbles: true }); }
                        catch (e) { evt = document.createEvent('HTMLEvents'); evt.initEvent('change', true, false); }
                        sel.dispatchEvent(evt);
                    }

                    renderOptions('');

                    function openPanel() {
                        pmbCloseAllOpenPanels();
                        if (searchInput) searchInput.value = '';
                        renderOptions('');
                        panel.classList.add('open');
                        display.classList.add('open');
                        wrap.classList.add('pmb-focused');

                        // Reparent into the parent page's floating host when available (see the
                        // comment above pmbExternallyMountedPanel) so the panel can overlap past
                        // the popup's edge instead of being clipped by this iframe's box.
                        if (window.parent && window.parent !== window && window.frameElement &&
                            typeof window.parent.pmMountBranchDropdown === 'function') {
                            var frameRect = window.frameElement.getBoundingClientRect();
                            var triggerRect = display.getBoundingClientRect();
                            window.parent.pmMountBranchDropdown(panel, {
                                left: frameRect.left + triggerRect.left,
                                top: frameRect.top + triggerRect.bottom + 6,
                                width: triggerRect.width
                            });
                            pmbExternallyMountedPanel = panel;
                        }

                        // Land the keyboard highlight on whatever's currently selected, and
                        // scroll it into view instead of always opening at the top of the list.
                        var rows = currentRows();
                        for (var i = 0; i < rows.length; i++) {
                            if (parseInt(rows[i].getAttribute('data-idx'), 10) === sel.selectedIndex) {
                                setActive(i);
                                break;
                            }
                        }
                        if (searchInput) searchInput.focus(); else display.focus();
                    }
                    function closePanel() {
                        panel.classList.remove('open');
                        display.classList.remove('open');
                        wrap.classList.remove('pmb-focused');
                        if (pmbExternallyMountedPanel === panel) {
                            if (window.parent && typeof window.parent.pmUnmountBranchDropdown === 'function') {
                                window.parent.pmUnmountBranchDropdown();
                            }
                            pmbExternallyMountedPanel = null;
                        }
                    }

                    function moveActive(delta) {
                        var rows = currentRows();
                        if (!rows.length) return;
                        var next = activeIndex + delta;
                        if (next < 0) next = rows.length - 1;
                        if (next >= rows.length) next = 0;
                        setActive(next);
                    }

                    display.addEventListener('click', function (e) {
                        e.stopPropagation();
                        if (panel.classList.contains('open')) closePanel(); else openPanel();
                    });
                    display.addEventListener('keydown', function (e) {
                        if (e.key === 'ArrowDown' || e.key === 'ArrowUp') {
                            e.preventDefault();
                            if (!panel.classList.contains('open')) openPanel();
                            else moveActive(e.key === 'ArrowDown' ? 1 : -1);
                        } else if (e.key === 'Enter' || e.key === ' ') {
                            e.preventDefault();
                            if (!panel.classList.contains('open')) { openPanel(); return; }
                            var rows = currentRows();
                            if (activeIndex >= 0 && rows[activeIndex]) chooseIndex(parseInt(rows[activeIndex].getAttribute('data-idx'), 10));
                        } else if (e.key === 'Escape') closePanel();
                    });
                    panel.addEventListener('click', function (e) { e.stopPropagation(); });

                    if (searchInput) {
                        searchInput.addEventListener('click', function (e) { e.stopPropagation(); });
                        searchInput.addEventListener('input', function () { renderOptions(searchInput.value); });
                        searchInput.addEventListener('keydown', function (e) {
                            if (e.key === 'ArrowDown' || e.key === 'ArrowUp') { e.preventDefault(); moveActive(e.key === 'ArrowDown' ? 1 : -1); }
                            else if (e.key === 'Enter') {
                                e.preventDefault();
                                var rows = currentRows();
                                var pick = activeIndex >= 0 ? activeIndex : 0;
                                if (rows[pick]) chooseIndex(parseInt(rows[pick].getAttribute('data-idx'), 10));
                            } else if (e.key === 'Escape') closePanel();
                        });
                    }

                    sel.classList.add('pmb-js-enhanced');
                    wrap.insertBefore(display, sel.nextSibling);
                    wrap.insertBefore(panel, display.nextSibling);
                })(selects[s]);
            }

            document.addEventListener('click', pmbCloseAllOpenPanels);
        }
        initPmbCustomSelects();

    </script>
</body>
</html>
