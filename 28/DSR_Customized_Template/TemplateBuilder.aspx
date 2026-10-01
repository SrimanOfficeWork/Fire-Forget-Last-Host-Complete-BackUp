<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplateBuilder.aspx.cs" Inherits="TemplateBuilder" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.min.js"></script>
    <script>
        // The master page loads its own (much older) jQuery further down the body,
        // which overwrites window.$/jQuery before this page's ready handlers fire.
        // noConflict(true) hands the master's globals back and keeps our jQuery
        // 3.6 + UI instance private to this page via window.TBQuery.
        window.TBQuery = jQuery.noConflict(true);
    </script>
    <style>
        body { font-family: Segoe UI, Arial, sans-serif; font-size: 13px; background:#f4f6f8; margin:0; }
        .topbar { background:#1f3b57; color:#fff; padding:12px 20px; display:flex; align-items:center; gap:16px; }
        .topbar input[type=text], .topbar select { padding:6px; border-radius:4px; border:1px solid #ccc; }
        .topbar button { padding:7px 16px; border:none; border-radius:4px; background:#2e8b57; color:#fff; cursor:pointer; }
        .topbar button:hover { background:#256b44; }
        .topbar button#btnCancel { background:#5a6472; }
        .topbar button#btnCancel:hover { background:#454e5a; }
        .wrap { display:flex; gap:16px; padding:16px; }
        .panel { background:#fff; border:1px solid #dde3e8; border-radius:6px; padding:12px; }
        .left { width:260px; flex-shrink:0; }
        .canvas { flex:1; min-height:500px; }
        .left h4 { margin:6px 0; color:#1f3b57; border-bottom:2px solid #eef2f5; padding-bottom:4px;}
        select#ddlTable, select#ddlFieldType { width:100%; margin-bottom:8px; padding:5px; }
        #schemaFieldList { max-height:360px; overflow-y:auto; overflow-x:hidden; border:1px solid #dde3e8; border-radius:4px; padding:4px; }
        .field-chip { padding:8px 10px; margin:6px 0; background:#eaf3ff; border:1px solid #b8d6f7; border-radius:4px; cursor:grab; }
        .field-chip small { display:block; color:#607a94; }
        .field-chip.formula { background:#f3ecfb; border-color:#c9aeed; }
        .field-chip.used { opacity:.45; cursor:not-allowed; background:#eef1f4; border-color:#ccd3da; }
        .field-chip.used small:after { content:" (already used)"; }
        .field-row.formula { background:#f8f5fc; border-color:#c9aeed; }
        .field-row.formula .type-select { opacity:.6; }
        .custom-field-form input, .custom-field-form select { width:100%; margin-bottom:6px; padding:5px; }
        .custom-field-form button { width:100%; padding:6px; background:#1f3b57; color:#fff; border:none; border-radius:4px; cursor:pointer; }
        .header-block { border:1px dashed #9db4c7; border-radius:6px; margin-bottom:14px; background:#fafcfe; }
        .header-title-bar { display:flex; justify-content:space-between; align-items:center; gap:10px; background:#dfe9f2; padding:8px 12px; border-radius:6px 6px 0 0; }
        .header-title-bar input { font-weight:bold; border:none; background:transparent; font-size:14px; color:#1f3b57; flex:1; min-width:0; }
        .header-title-bar .remove-header { color:#c0392b; cursor:pointer; font-weight:bold; flex-shrink:0; }
        .header-field-count { font-size:11px; font-weight:700; color:#5a7897; background:#eef4fa; padding:3px 10px; border-radius:10px; flex-shrink:0; white-space:nowrap; }
        .header-toggle { cursor:pointer; color:#1f3b57; font-size:11px; width:14px; text-align:center; flex-shrink:0; user-select:none; transition:transform .12s ease; }
        .header-block.collapsed .header-toggle { transform:rotate(-90deg); }
        .header-block.collapsed .dropzone { display:none; }
        /* Template Settings tab -> Header Access: a header the current user
           isn't granted, still shown but read-only - same "No Access" badge
           language DSREntry.aspx already uses on its own header titles. */
        .header-block.access-locked { background:#f7f4f2; border-color:#e0c9c9; }
        .header-block.access-locked .header-title-bar { background:#ecdede; }
        .header-block.access-locked .header-name { color:#8a7570; cursor:not-allowed; }
        .header-block.access-locked .remove-header { display:none; }
        .header-no-access {
            flex-shrink:0; background:rgba(192,57,43,0.18); color:#a8362a;
            font-size:10.5px; font-weight:700; letter-spacing:.3px; text-transform:uppercase;
            padding:2px 9px; border-radius:10px;
        }
        .field-row.locked { background:#f5f5f5; cursor:default; }
        .field-row.locked .handle, .field-row.locked .remove-field { visibility:hidden; }
        .field-row.locked input:disabled, .field-row.locked select:disabled { background:#eef1f4; color:#8a94a3; cursor:not-allowed; }
        .canvas-total { font-size:12.5px; font-weight:700; color:#1f3b57; margin-bottom:10px; }
        .canvas-total span { color:#2e8b57; }
        .canvas-collapse-btns { margin-left:14px; font-weight:400; }
        .canvas-collapse-btns a { color:#3a6ea5; text-decoration:none; cursor:pointer; }
        .canvas-collapse-btns a:hover { text-decoration:underline; }
        .dropzone { min-height:60px; padding:10px; }
        .dropzone.drag-over { background:#eef8ee; }
        .field-row { display:flex; align-items:center; gap:8px; background:#fff; border:1px solid #dde3e8; border-radius:4px; padding:8px; margin-bottom:6px; cursor:move; }
        .field-row .handle { color:#aab; }
        .field-row input.label-edit { flex:1; border:1px solid #ccc; border-radius:3px; padding:4px; }
        .field-row select.type-select { padding:4px; }
        .field-row input.dropdown-opts { flex:1; border:1px solid #ccc; border-radius:3px; padding:4px; }
        .field-row .remove-field { color:#c0392b; cursor:pointer; margin-left:auto; }
        .add-header-btn { padding:8px 14px; border:1px dashed #1f3b57; background:#fff; color:#1f3b57; border-radius:4px; cursor:pointer; }
        .required-flag { transform: scale(1.1); }
        #lblStatus { margin-left:auto; font-size:12px; }
        .templates-panel { margin:0 16px 16px 16px; padding:0; overflow:hidden; background:#f5f9ff; border-color:#d9e6f7; }
        .templates-panel .panel-header {
            display:flex; align-items:center; justify-content:space-between;
            padding:14px 16px; border-bottom:1px solid #dbe7f6;
            background:#f5f9ff;
        }
        .templates-panel .panel-header h4 { margin:0; color:#1f3b57; font-size:15px; }
        .templates-panel .tpl-count {
            background:#eaf1f8; color:#1f3b57; font-size:11.5px; font-weight:700;
            padding:2px 11px; border-radius:12px;
        }
        .templates-panel table { width:100%; border-collapse:collapse; }
        .templates-panel thead th {
            background:#1f3b57; color:#fff; text-align:left; font-size:12px;
            font-weight:600; letter-spacing:.3px; padding:10px 16px;
        }
        .templates-panel tbody td { padding:10px 16px; font-size:13px; border-bottom:1px solid #eef2f5; }
        .templates-panel td.actions-col { display:flex; align-items:center; }
        .templates-panel th.sno-col, .templates-panel td.sno-col { width:60px; text-align:center; color:#5a7897; }
        .templates-panel tbody tr:nth-child(even) { background:#fafcfe; }
        .templates-panel tbody tr:hover { background:#eef6ff; }
        .templates-panel tbody tr:last-child td { border-bottom:none; }
        .templates-panel .templates-empty { text-align:center; color:#8a94a3; font-style:italic; padding:22px !important; }

        .type-badge {
            display:inline-block; padding:3px 11px; border-radius:12px;
            font-size:10.5px; font-weight:700; letter-spacing:.4px; text-transform:uppercase;
        }
        .type-badge.import { background:#e3f0ff; color:#1c5ea8; }
        .type-badge.export { background:#fdeee0; color:#b5591a; }

        /* NOTE: intentionally NOT named .edit/.report - this app already has a
           global .edit class elsewhere (icon-sprite buttons with hidden text
           via text-indent) that silently clobbered our button's text. */
        .btn-mini {
            display:inline-block; padding:7px 18px; margin-right:10px; border-radius:16px;
            font-size:13px; font-weight:700; text-decoration:none; cursor:pointer;
            border:none; box-sizing:border-box; text-indent:0; overflow:visible;
            transition: transform .1s ease, box-shadow .1s ease, background .1s ease;
        }
        .btn-mini:hover { transform:translateY(-1px); box-shadow:0 2px 6px rgba(0,0,0,0.15); }
        .btn-mini.btn-edit { background:#c9720e; color:#fff; }
        .btn-mini.btn-edit:hover { background:#a75f0b; }
        .btn-mini.btn-report { background:#2e8b57; color:#fff; }
        .btn-mini.btn-report:hover { background:#256b44; }
        .btn-mini.btn-delete { background:#c0392b; color:#fff; margin-left:auto; margin-right:0; }
        .btn-mini.btn-delete:hover { background:#992d22; }

        .tabstrip { display:flex; gap:4px; padding:0 16px; margin-top:14px; border-bottom:2px solid #dde3e8; }
        .tab-btn { padding:10px 20px; cursor:pointer; font-weight:600; background:#1f3b57; color:#fff; border-radius:6px 6px 0 0; }
        .tab-btn:hover { background:#16283f; }
        .tab-btn.active { background:#16283f; color:#fff; border:1px solid #16283f; border-bottom:2px solid #16283f; margin-bottom:-2px; }
        .tab-panel { display:none; }
        .tab-panel.active { display:block; }

        .rs-section { margin:16px; padding:14px 16px; overflow:hidden; }
        .rs-section h4 { margin:-14px -16px 12px -16px; padding:11px 16px; background:#ccd9ec; color:#1f3b57; border-radius:6px 6px 0 0; cursor:pointer; user-select:none; }
        .rs-section h4 .section-toggle { display:inline-block; margin-right:8px; transition:transform .12s ease; }
        .rs-section.collapsed h4 { margin-bottom:-14px; border-radius:6px; }
        .rs-section.collapsed h4 .section-toggle { transform:rotate(-90deg); }
        .rs-section.collapsed > *:not(h4) { display:none; }
        .rs-section .rs-sub { font-size:12px; color:#8a94a3; margin:-6px 0 10px 0; }
        .rs-toolbar { margin:16px 16px 0 16px; font-size:12.5px; font-weight:600; }
        .rs-toolbar a { color:#3a6ea5; text-decoration:none; cursor:pointer; }
        .rs-toolbar a:hover { text-decoration:underline; }
        .rs-row { display:flex; align-items:center; gap:8px; background:#f8fafc; border:1px solid #dde3e8; border-radius:4px; padding:8px; margin-bottom:6px; }
        .rs-row select, .rs-row input[type=text] { padding:5px; border:1px solid #ccc; border-radius:4px; }
        .rs-row .rs-field { min-width:200px; }
        .rs-row .rs-op { min-width:150px; }
        .rs-row .rs-value { flex:1; }
        .rs-row .rs-remove { color:#c0392b; cursor:pointer; margin-left:auto; font-weight:bold; }
        .rs-row .dd-label { flex:1; min-width:220px; }
        .rs-row .dd-from, .rs-row .dd-to { min-width:170px; }
        .rs-row .dd-arrow { color:#8a94a3; font-weight:700; }
        .rs-add-btn { padding:7px 14px; border:1px dashed #1f3b57; background:#fff; color:#1f3b57; border-radius:4px; cursor:pointer; }
        #reportSettingsLocked { margin:16px; padding:24px; text-align:center; color:#8a94a3; font-style:italic; }
        .access-options label { display:flex; align-items:center; gap:8px; margin-bottom:8px; font-weight:normal; }
        .access-options { margin-bottom:10px; }
        #roleAssignBox { margin-top:10px; padding:10px; background:#f8fafc; border:1px solid #dde3e8; border-radius:4px; display:none; }
        #roleAssignBox textarea { width:100%; min-height:70px; padding:6px; border:1px solid #ccc; border-radius:4px; }
        #scheduleOptionsBox { margin-top:10px; padding:10px; background:#f8fafc; border:1px solid #dde3e8; border-radius:4px; display:none; }
        #scheduleOptionsBox input[type=text] { padding:5px; border:1px solid #ccc; border-radius:4px; }
        #lblReportSettingsStatus { margin-left:12px; font-size:12px; color:#1f3b57; }
        #templateSettingsLocked { margin:16px; padding:24px; text-align:center; color:#8a94a3; font-style:italic; }
        .user-access-checkbox-list { max-height:220px; overflow-y:auto; border:1px solid #dde3e8; border-radius:4px; padding:6px; }
        .header-access-row { display:flex; align-items:center; gap:8px; background:#f8fafc; border:1px solid #dde3e8; border-radius:4px; padding:8px 10px; margin-bottom:6px; }
        .header-access-row label { font-weight:normal; cursor:pointer; }
        #lblHeaderAccessStatus { margin-left:12px; font-size:12px; color:#1f3b57; }
    </style>

    <div class="topbar">
        <label>Type</label>
        <select id="ddlType">
            <option value="Import">Import</option>
            <option value="Export">Export</option>
        </select>
        <label>Template Name</label>
        <input type="text" id="txtTemplateName" placeholder="e.g. Import DSR - Standard" />
        <label id="lblPartyLabel">Importer Name</label>
        <input type="text" id="txtPartySearch" placeholder="Search importer..." style="width:220px;" />
        <button type="button" id="btnAddParty">Add</button>
        <select id="lstParties" multiple style="min-width:200px; height:60px;"></select>
        <button type="button" id="btnRemoveParty" title="Remove selected entries from the list">Remove</button>
        <button type="button" id="btnSave">Save Template</button>
        <button type="button" id="btnNewTemplate" title="Discard the form and start a new template">New Template</button>
        <button type="button" id="btnCancel" title="Close this window">Cancel</button>
        <span id="lblStatus"></span>
    </div>

    <div class="tabstrip">
        <div class="tab-btn active" id="tabBtnFields" data-tab="fields">Template Fields</div>
        <div class="tab-btn" id="tabBtnReport" data-tab="report">Report Settings</div>
        <div class="tab-btn" id="tabBtnTemplateSettings" data-tab="templateSettings">Template Settings</div>
    </div>

    <div id="tabPanelFields" class="tab-panel active">
        <div class="wrap">
            <!-- LEFT: field sources -->
            <div class="panel left">
                <h4>Schema Fields</h4>
                <select id="ddlTable"><option value="">-- choose table --</option></select>
                <div id="schemaFieldList"></div>

                <h4>Custom Field</h4>
                <div class="custom-field-form">
                    <input type="text" id="txtCustomFieldName" placeholder="Field name (internal)" />
                    <input type="text" id="txtCustomFieldLabel" placeholder="Display label" />
                    <select id="ddlCustomFieldType">
                        <option value="Textbox">Textbox</option>
                        <option value="Date">Date</option>
                        <option value="Dropdown">Dropdown</option>
                    </select>
                    <select id="ddlCustomFieldOperation" title="Optionally make this field computed from other fields already on the canvas">
                        <option value="">No calculation (plain field)</option>
                        <option value="Sum">Total / Sum of fields</option>
                        <option value="Concat">Concatenate fields</option>
                        <option value="GreaterThan">Greater Than (Yes/No)</option>
                        <option value="LessThan">Less Than (Yes/No)</option>
                    </select>
                    <select id="lstCustomFieldSources" multiple size="4" style="display:none;"
                        title="Select the fields already on the canvas to combine (2+ for Sum/Concatenate, exactly 2 for Greater/Less Than)"></select>
                    <button type="button" id="btnAddCustomField">+ Add to palette</button>
                </div>
                <div id="customFieldList"></div>
            </div>

            <!-- CENTER: template canvas -->
            <div class="panel canvas">
                <div class="canvas-total">
                    Total Fields: <span id="lblTotalFieldCount">0</span>
                    <span class="canvas-collapse-btns">
                        <a href="#" id="btnExpandAllHeaders">Expand All</a> | <a href="#" id="btnCollapseAllHeaders">Collapse All</a>
                    </span>
                </div>
                <div id="headerContainer"></div>
                <div class="add-header-btn" id="btnAddHeader">+ Add Header</div>
            </div>
        </div>
    </div>

    <div id="tabPanelReport" class="tab-panel">
        <div id="reportSettingsLocked">Save the template first (top "Save Template" button) to configure its report settings.</div>
        <div id="reportSettingsBody" style="display:none;">

            <div class="rs-toolbar">
                <a href="#" id="btnExpandAllSections">Expand All</a> | <a href="#" id="btnCollapseAllSections">Collapse All</a>
            </div>

            <div class="panel rs-section">
                <h4>Filters</h4>
                <div class="rs-sub">Rows must match every filter below.</div>
                <div id="filterList"></div>
                <div class="rs-add-btn" id="btnAddFilter">+ Add Filter</div>
            </div>

            <div class="panel rs-section">
                <h4>Group &amp; Sort</h4>
                <div class="rs-sub">Group By (in order)</div>
                <div id="groupList"></div>
                <div class="rs-add-btn" id="btnAddGroup">+ Add Group Field</div>
                <div class="rs-sub" style="margin-top:14px;">Sort By (in order)</div>
                <div id="sortList"></div>
                <div class="rs-add-btn" id="btnAddSort">+ Add Sort Field</div>
            </div>

            <div class="panel rs-section">
                <h4>Calculate &amp; Summarize</h4>
                <div class="rs-sub">Choose an aggregate for any field that needs a report total.</div>
                <div id="summaryList"></div>
            </div>

            <div class="panel rs-section">
                <h4>Date Comparison</h4>
                <div class="rs-sub">Pick two date fields already on the template - the report adds a new column showing the number of days between them. Add more rows to check several date pairs.</div>
                <div id="dateDiffList"></div>
                <div class="rs-add-btn" id="btnAddDateDiff">+ Add Date Comparison</div>
            </div>

            <div class="panel rs-section">
                <h4>Format &amp; Schedule</h4>
                <div class="rs-sub">Access &amp; Sharing - who can see this report</div>
                <div class="access-options">
                    <label><input type="radio" name="accessMode" value="OnlyMe" /> Only Me</label>
                    <label><input type="radio" name="accessMode" value="SpecificRole" /> A Specific Role</label>
                    <label><input type="radio" name="accessMode" value="Everyone" /> Everyone in my Organization</label>
                </div>
                <div id="roleAssignBox">
                    <label>Role</label>
                    <select id="ddlAccessRole" style="min-width:220px;"></select>
                    <input type="text" id="txtNewRoleName" placeholder="New role name" style="margin-left:10px;" />
                    <button type="button" id="btnCreateRole">+ Create Role</button>
                    <div style="margin-top:10px;">
                        <label>Members of this role (one username per line)</label>
                        <textarea id="txtRoleMembers"></textarea>
                        <button type="button" id="btnSaveRoleMembers" style="margin-top:6px;">Save Members</button>
                    </div>
                </div>
            </div>

            <div class="panel rs-section">
                <h4>Scheduled Generation</h4>
                <div class="access-options">
                    <label><input type="checkbox" id="chkScheduleEnabled" /> Generate this report on a schedule</label>
                </div>
                <div id="scheduleOptionsBox">
                    <label>Frequency</label>
                    <select id="ddlScheduleFrequency" style="min-width:160px;">
                        <option value="Daily">Daily</option>
                        <option value="Weekly">Weekly</option>
                        <option value="Monthly">Monthly</option>
                    </select>

                    <span id="scheduleDayOfWeekBox" style="margin-left:14px;">
                        <label>Day</label>
                        <select id="ddlScheduleDayOfWeek" style="min-width:130px;">
                            <option value="0">Sunday</option>
                            <option value="1">Monday</option>
                            <option value="2">Tuesday</option>
                            <option value="3">Wednesday</option>
                            <option value="4">Thursday</option>
                            <option value="5">Friday</option>
                            <option value="6">Saturday</option>
                        </select>
                    </span>

                    <span id="scheduleDayOfMonthBox" style="margin-left:14px;">
                        <label>Date</label>
                        <select id="ddlScheduleDayOfMonth" style="min-width:70px;"></select>
                    </span>

                    <span style="margin-left:14px;">
                        <label>Time</label>
                        <input type="time" id="txtScheduleTime" value="09:00" />
                    </span>

                    <div style="margin-top:10px;">
                        <label>Recipient Emails (comma separated)</label>
                        <input type="text" id="txtScheduleRecipients" style="width:100%;" placeholder="user1@example.com, user2@example.com" />
                    </div>
                    <div style="margin-top:10px;">
                        <button type="button" id="btnTestScheduleEmail">Send Test Email Now</button>
                        <span id="lblScheduleTestStatus" style="margin-left:10px; font-size:12px;"></span>
                        <div class="rs-sub" style="margin-top:6px;">Sends immediately using the Recipient Emails saved above - click Save Template first if you've just changed them.</div>
                    </div>
                </div>
            </div>

            <div class="rs-section" style="margin-top:0;">
                <span class="rs-sub" style="margin:0;">Saved together with the rest of the template - use the "Save Template" button at the top.</span>
                <span id="lblReportSettingsStatus"></span>
            </div>
        </div>
    </div>

    <div id="tabPanelTemplateSettings" class="tab-panel">
        <div id="templateSettingsLocked">Save the template first (top "Save Template" button) to configure its Template Settings.</div>
        <div id="templateSettingsBody" style="display:none;">
            <div class="panel rs-section">
                <h4>Header Access</h4>
                <div class="rs-sub">
                    Choose a header, then check which users may access it when entering custom field data. A header
                    left unchecked for a user is disabled (view-only) for them on the Edit Custom Data form. Users
                    never restricted for any header of this template keep full access to every header.
                </div>

                <label style="font-weight:600; color:#1f3b57; display:block; margin-bottom:4px;">Header Name</label>
                <select id="ddlAccessHeaderName" style="min-width:260px; padding:6px;">
                    <option value="">-- choose header --</option>
                </select>
                <div class="rs-sub" id="headerAccessEmpty" style="display:none; margin-top:6px;">This template has no headers yet.</div>

                <div id="headerUserAccessSection" style="display:none; margin-top:14px;">
                    <label style="font-weight:600; color:#1f3b57; display:block; margin-bottom:4px;">Users with access to this header</label>
                    <div id="headerUserAccessList" class="user-access-checkbox-list"></div>
                </div>
                <div class="rs-sub" id="headerAccessNoHeaderNotice" style="margin-top:6px;">Select a header above to manage which users can access it.</div>
            </div>

            <div class="rs-section" style="margin-top:0;">
                <span class="rs-sub" style="margin:0;">Saved together with the rest of the template - use the "Save Template" button at the top.</span>
                <span id="lblHeaderAccessStatus"></span>
            </div>
        </div>
    </div>

    <div class="panel templates-panel">
        <div class="panel-header">
            <h4>Created Templates</h4>
            <span class="tpl-count" id="tplCount">0</span>
        </div>
        <table>
            <thead>
                <tr><th class="sno-col">S.No</th><th>Template Name</th><th>Type</th><th>Actions</th></tr>
            </thead>
            <tbody id="templatesBody">
                <tr><td colspan="4" class="templates-empty">Loading...</td></tr>
            </tbody>
        </table>
    </div>

    <!-- template for a header block (client-side, not a server control) -->
    <script id="tmplHeader" type="text/x-jsrender-like">
        <div class="header-block" data-header-id="{id}" data-server-id="{serverId}">
            <div class="header-title-bar">
                <span class="header-toggle" title="Expand/Collapse this header">&#9660;</span>
                <input type="text" class="header-name" value="{name}" placeholder="Header name" />
                <span class="header-field-count">0 fields</span>
                <span class="remove-header">Remove header &#10005;</span>
            </div>
            <div class="dropzone"></div>
        </div>
    </script>

    <script id="tmplFieldRow" type="text/x-jsrender-like">
        <div class="field-row" data-field-key="{key}" data-server-id="{serverId}" data-source-type="{sourceType}" data-source-table="{sourceTable}" data-source-column="{sourceColumn}">
            <span class="handle">&#10303;</span>
            <input type="text" class="label-edit" value="{label}" />
            <select class="type-select">
                <option value="Textbox">Textbox</option>
                <option value="Date">Date</option>
                <option value="Dropdown">Dropdown</option>
            </select>
            <input type="text" class="dropdown-opts" placeholder="Option1,Option2,Option3" style="display:none;" />
            <label><input type="checkbox" class="required-flag" /> Req</label>
            <span class="remove-field">&#10005;</span>
        </div>
    </script>

    <script src="TemplateBuilder.js"></script>
</asp:Content>
