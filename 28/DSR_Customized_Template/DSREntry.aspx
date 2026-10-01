<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSREntry.aspx.cs" Inherits="DSREntry" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enter Custom Field Data</title>
    <style>
        * { box-sizing: border-box; }
        html, body { height: 100%; }
        body {
            font-family: Segoe UI, Arial, sans-serif;
            background: #f4f6f8;
            margin: 0;
            font-size: 13px;
            color: #333;
        }
        .entry-wrap { display: flex; flex-direction: column; height: 100vh; }

        .entry-header {
            background: #1f3b57;
            color: #fff;
            padding: 14px 20px;
            flex-shrink: 0;
        }
        .entry-header h3 { margin: 0; font-size: 16px; font-weight: 600; }
        .entry-header .job-badge {
            display: inline-block;
            margin-top: 4px;
            background: rgba(255,255,255,0.15);
            border-radius: 4px;
            padding: 2px 10px;
            font-size: 12px;
            letter-spacing: .3px;
        }

        .entry-body {
            flex: 1;
            overflow-y: auto;
            padding: 20px;
            /* 2 fields per row instead of one flat vertical list, so a template
               with many fields needs far less vertical scrolling. phTemplate
               (the PlaceHolder) renders no wrapper of its own, so its children -
               .entry-header-title and .field-group divs - land as direct grid
               items here; each header title spans both columns (see below) and
               each field-group takes one column, auto-flowing into the next row
               once both columns of the current row are filled. */
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            column-gap: 24px;
            align-content: start;
        }
        @media (max-width: 760px) {
            .entry-body { grid-template-columns: 1fr; }
        }

        .notice {
            background: #fdf3f3;
            border: 1px solid #f1c3c3;
            color: #a33;
            border-radius: 5px;
            padding: 12px 14px;
            font-size: 13px;
        }
        .notice.info { background: #eef6ff; border-color: #c3d9f1; color: #2b5a8a; }

        .entry-header-title {
            font-weight: 700;
            font-size: 12.5px;
            letter-spacing: .2px;
            color: #fff;
            background: #1f3b57;
            padding: 8px 14px;
            border-radius: 5px;
            margin: 18px 0 6px 0;
        }
        .entry-header-title:first-child { margin-top: 0; }
        .entry-header-title { grid-column: 1 / -1; }

        .field-group {
            display: flex;
            align-items: center;
            padding: 11px 4px;
            border-bottom: 1px solid #eef1f4;
        }
        .field-group:last-child { border-bottom: none; }
        .field-group:hover { background: #fafcfe; }
        .field-group .field-label {
            display: inline-block;
            width: 170px;
            flex: 0 0 170px;
            text-align: right;
            padding-right: 16px;
            font-weight: 600;
            color: #1f3b57;
            font-size: 12.5px;
            line-height: 1.3;
            white-space: normal;
            word-break: break-word;
        }
        .field-group .req { color: #c0392b; margin-left: 2px; }
        .field-group input[type=text],
        .field-group input[type=date],
        .field-group select {
            flex: 0 0 280px;
            width: 280px;
            padding: 8px 10px;
            border: 1px solid #cfd8e2;
            border-radius: 5px;
            font-size: 13px;
            font-family: inherit;
            background: #fff;
            transition: border-color .15s ease, box-shadow .15s ease;
        }
        .field-group select {
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            background-image: url("data:image/svg+xml;charset=UTF-8,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 12 8'%3e%3cpath fill='%231f3b57' d='M0 0l6 8 6-8z'/%3e%3c/svg%3e");
            background-repeat: no-repeat;
            background-position: right 10px center;
            background-size: 10px 7px;
            padding-right: 28px;
        }
        .field-group input:focus,
        .field-group select:focus {
            outline: none;
            border-color: #2e8b57;
            box-shadow: 0 0 0 3px rgba(46,139,87,0.15);
        }

        .entry-footer {
            flex-shrink: 0;
            padding: 14px 20px;
            background: #fff;
            border-top: 1px solid #e3e8ee;
            display: flex;
            align-items: center;
            gap: 10px;
        }
        .btn-submit, .btn-close {
            padding: 9px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 13px;
            font-weight: 600;
        }
        .btn-submit { background: #2e8b57; color: #fff; }
        .btn-submit:hover { background: #256b44; }
        .btn-close { background: #eef1f4; color: #444; }
        .btn-close:hover { background: #e2e6eb; }

        .result-msg { font-size: 12.5px; font-weight: 600; }
        .result-msg.success { color: #2e8b57; }
        .result-msg.error { color: #c0392b; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="entry-wrap">
        <div class="entry-header">
            <h3>Enter Custom Field Data</h3>
            <span class="job-badge"><asp:Label ID="lblHeader" runat="server" /></span>
        </div>

        <div class="entry-body">
            <!-- Only the template's custom (Manual) fields are rendered here -
                 schema fields already come live from SQL in TemplateReport.aspx. -->
            <asp:PlaceHolder ID="phTemplate" runat="server" />
        </div>

        <div class="entry-footer">
            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn-submit" OnClick="btnSubmit_Click" />
            <button type="button" class="btn-close" onclick="window.close(); return false;">Close</button>
            <asp:Label ID="lblResult" runat="server" CssClass="result-msg" />
        </div>
    </div>
    </form>
</body>
</html>
