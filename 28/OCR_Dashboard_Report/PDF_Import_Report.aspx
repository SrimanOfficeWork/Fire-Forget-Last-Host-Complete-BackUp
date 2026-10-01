<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PDF_Import_Report.aspx.cs"
    Inherits="PDF_Import_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>PDF Import Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        *
        {
            box-sizing: border-box;
        }
        html, body
        {
            height: 100%;
            margin: 0;
        }
        body
        {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 13px;
            background: #f0f2f8;
            color: #333;
            display: flex;
            flex-direction: column;
        }
        form#form1
        {
            display: flex;
            flex-direction: column;
            flex: 1 1 auto;
            min-height: 0;
        }
        .container-sm
        {
            width: 98%;
            margin: 0 auto 10px;
            background: #fff;
            border: 1px solid #e8eaf6;
            border-radius: 16px;
            box-shadow: 0 4px 20px rgba(0,0,0,0.08);
            overflow: hidden;
            flex: 0 0 auto;
        }
        .grid-container
        {
            flex: 1 1 auto;
            min-height: 120px;
            display: flex;
            flex-direction: column;
        }
        .row
        {
            width: 100%;
            clear: both;
        }
        .col-sm-1, .col-sm-2, .col-sm-3
        {
            float: left;
            min-height: 1px;
        }
        .col-sm-1
        {
            width: 8%;
        }
        .col-sm-2
        {
            width: 16%;
        }
        .col-sm-3
        {
            width: 24%;
        }
        .mt-3
        {
            margin-top: 10px;
        }
        .mb-1
        {
            margin-bottom: 5px;
        }
        .ms-2
        {
            margin-left: 5px;
        }
        .ms-3
        {
            margin-left: 8px;
        }
        .ms-4
        {
            margin-left: 10px;
        }
        .ms-5
        {
            margin-left: 13px;
        }
        .ms-6
        {
            margin-left: 28px;
        }
        .p-1
        {
            padding: 5px;
        }
        .mt-4
        {
            margin-top: 13px;
        }
        .mt-5
        {
            margin-top: 16px;
        }
        .mt-6
        {
            margin-top: 19px;
        }
        .mt-2
        {
            margin-top: 6px;
        }
        .row:after
        {
            content: "";
            display: block;
            clear: both;
        }
        .text-white
        {
            color: #fff;
        }
        .rounded
        {
            border-radius: 4px;
        }

        /* ── Report header — mirrors the OCR AI Dashboard's "import" section gradient ── */
        .report-header
        {
            background: linear-gradient(135deg,#1976d2,#42a5f5);
            box-shadow: 0 4px 15px rgba(25,118,210,0.35);
            padding: 12px 44px 12px 18px;
            position: relative;
            display: flex;
            align-items: center;
        }
        .report-header .report-icon
        {
            width: 28px;
            height: 28px;
            border-radius: 8px;
            background: rgba(255,255,255,0.2);
            display: inline-flex;
            align-items: center;
            justify-content: center;
            font-size: 14px;
            margin-right: 10px;
            flex: 0 0 auto;
        }
        .report-header small
        {
            color: #fff;
            font-size: 14px;
            font-weight: 700;
            letter-spacing: 0.6px;
            text-transform: uppercase;
        }

        /* ── Filter bar ── */
        .filter-bar
        {
            background: #fafbff;
            padding: 14px 16px 6px;
        }

        .form-select-sm, .form-control-sm
        {
            height: 30px;
            font-size: 12px;
            border: 1.5px solid #e3e8f5;
            border-radius: 8px;
            padding: 0 8px;
            background: #fff;
            transition: border-color .2s ease, box-shadow .2s ease;
        }
        .form-select-sm:focus, .form-control-sm:focus
        {
            outline: none;
            border-color: #42a5f5;
            box-shadow: 0 0 0 3px rgba(66,165,245,0.18);
        }
        label
        {
            color: #37474f;
            font-weight: 600;
            font-size: 12px;
        }

        /* ── Modern action buttons ── */
        .btn
        {
            display: inline-block;
            padding: 6px 16px;
            font-size: 12px;
            font-weight: 600;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            text-decoration: none;
            transition: transform .15s ease, box-shadow .15s ease, background .2s ease;
            letter-spacing: 0.3px;
        }
        .btn-primary
        {
            background: linear-gradient(135deg,#1976d2,#42a5f5);
            color: #fff;
            box-shadow: 0 3px 10px rgba(25,118,210,0.30);
        }
        .btn-primary:hover
        {
            transform: translateY(-1px);
            box-shadow: 0 6px 16px rgba(25,118,210,0.40);
        }
        #btnClear
        {
            background: #fff;
            color: #455a64;
            border: 1.5px solid #dbe1ea;
            box-shadow: none;
        }
        #btnClear:hover
        {
            background: #eef1f6;
            transform: translateY(-1px);
        }

        .table
        {
            width: 100%;
            border-collapse: collapse;
        }
        .table th, .table td
        {
            border: 1px solid #eceff5;
            padding: 6px 8px;
        }
        .table th
        {
            background: linear-gradient(135deg,#1976d2,#42a5f5);
            color: #fff;
            font-weight: 700;
            letter-spacing: 0.4px;
            text-transform: uppercase;
            font-size: 11px;
        }
        .table-striped tr:nth-child(even)
        {
            background-color: #f7f9fd;
        }
        .table-hover tr:hover
        {
            background-color: #eaf3fd;
        }
        .table-responsive
        {
            overflow-y: auto;
            flex: 1 1 auto;
            min-height: 0;
        }
        .gridview-compact th
        {
            position: sticky;
            top: 0;
            z-index: 10;
        }
        .text-center
        {
            text-align: center;
        }
        .text-danger
        {
            color: #e53935;
        }
        .fw-bold
        {
            font-weight: bold;
        }
        .clearfix
        {
            clear: both;
        }
        .excel-icon
        {
            display: block;
            width: 60px;
            height: 40px;
            background-image: url('<%= ResolveUrl("~/images/icons/OCR_Excel.JPG") %>');
            background-repeat: no-repeat;
            background-size: contain;
        }
        a span
        {
            font-size: 14px;
            font-weight: bold;
            color: #107c41;
            vertical-align: middle;
        }
        a img
        {
            vertical-align: middle;
            border-radius: 6px;
            transition: transform .15s ease;
        }
        a img:hover
        {
            transform: scale(1.05);
        }

        /* ── Close button ── */
        .btn-close-x
        {
            position: absolute;
            right: 10px;
            top: 50%;
            transform: translateY(-50%);
            width: 26px;
            height: 26px;
            background: rgba(255,255,255,0.18);
            color: #fff;
            border: 1px solid rgba(255,255,255,0.4);
            border-radius: 50%;
            font-size: 12px;
            font-weight: bold;
            cursor: pointer;
            line-height: 1;
            padding: 0;
            transition: background .2s ease;
        }
        .btn-close-x:hover
        {
            background: #e53935;
            border-color: #e53935;
        }
    </style>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>
    <div class="container-sm shadow-sm p-0">
        <!-- Header -->
        <div class="report-header">
            <span class="report-icon">&#128229;</span>
            <small>Import PDF Daily Report</small>
            <!-- Close button — same behavior as Export page -->
            <input type="button" id="btnCloseX" value="&#10005;" class="btn-close-x" onclick="parent.adcodewindow.hide(); return false;"
                title="Close" />
        </div>
        <script type="text/javascript">
            // This page is opened two different ways: the OCR menu's Import -> "Report" item
            // uses openGenericModal() (E_royal_Impex_Main.aspx), whose wrapper card already draws
            // its own close "x" (.pm-robot-img-close -> closeGenericModal()); the AI Dashboard's
            // "Report" tool instead uses the older dhtmlmodal via open_PDF_Import_Report()
            // (js/iframepopupwin.js), which has no such outer chrome, so this page's own
            // #btnCloseX button (parent.adcodewindow.hide()) is the only close control there.
            // Opened via openGenericModal, both showed at once - a redundant (and non-functional,
            // since adcodewindow is never set on that path) second close icon. window.frameElement.id
            // reliably tells them apart: openGenericModal's iframe has id="pmGenericModalFrame"
            // (E_royal_Impex_Main.aspx); dhtmlwindow.js's iframe only ever gets a `name`, never an `id`.
            if (window.frameElement && window.frameElement.id === 'pmGenericModalFrame') {
                document.getElementById('btnCloseX').style.display = 'none';
            }
        </script>
        <!-- Row 1 -->
        <div class="row g-3 filter-bar">
            <div class="col-sm-3 d-flex align-items-center">
                <label for="ddlCutomerName" class="form-select-sm me-2 mb-0 mt-2">
                    Import Name</label>
                <asp:DropDownList ID="ddlCutomerName" runat="server" CssClass="form-select form-select-sm ms-3 mt-2"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlCutomerName_SelectedIndexChanged"
                    Style="width: 150px;">
                </asp:DropDownList>
            </div>
            <div class="col-sm-3 d-flex align-items-center mt-2">
                <label for="ddlSelect_Branch" class="form-control-sm me-2 mb-0 mt-2">
                    Branch</label>
                <asp:DropDownList ID="ddlSelect_Branch" runat="server" CssClass="form-select form-select-sm ms-5"
                    Style="width: 155px;" ClientIDMode="Static">
                </asp:DropDownList>
            </div>
            <div class="col-sm-3 d-flex align-items-center">
                <label id="lblClientName" for="DropDownList1" class="form-select-sm me-2 mb-0 mt-2"
                    runat="server" visible="false">
                    Client Name</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select form-select-sm mt-2 ms-3"
                    AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    Visible="false" Style="width: 150px;">
                </asp:DropDownList>
            </div>
            <div id="divTransportMode" class="col-sm-3 d-flex align-items-center" style="display: none;">
                <label for="ddlTransportMode" class="form-select-sm me-2 mb-0 mt-2">
                    Transport Mode</label>
                <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="form-select form-select-sm"
                    Style="width: 150px;">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Air</asp:ListItem>
                    <asp:ListItem>Sea</asp:ListItem>
                    <asp:ListItem>Land</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <!-- Row 2 -->
        <div class="row g-3 filter-bar" style="padding-top: 0; padding-bottom: 14px;">
            <div class="col-sm-3 d-flex">
                <label for="txtFrom_Date" class="form-select-sm me-1 mb-0 mt-3">
                    From Date</label>
                <asp:TextBox ID="txtFrom_Date" runat="server" CssClass="form-select form-select-sm ms-6 mt-5"
                    Style="width: 150px;" MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom_Date"
                    Mask="99/99/9999" MaskType="Date" />
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFrom_Date"
                    Format="dd/MM/yyyy" />
            </div>
            <div class="col-sm-3 d-flex">
                <label for="txtTo_Date" class="form-select-sm me-1 mb-0 mt-3 ms-0">
                    To Date</label>
                <asp:TextBox ID="txtTo_Date" runat="server" CssClass="form-select form-select-sm ms-4 mt-5"
                    Style="width: 150px;" MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtTo_Date"
                    Mask="99/99/9999" MaskType="Date" />
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo_Date"
                    Format="dd/MM/yyyy" />
            </div>
            <div class="col-sm-1">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary ms-2 mt-6"
                    OnClick="btnSearch_Click" />
            </div>
            <div class="col-sm-1">
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn ms-0 mt-6"
                    OnClick="btnClear_Click" />
            </div>
            <div class="col-sm-1 mt-4 mb-0">
                <a href="Excel" id="A1" runat="server" onserverclick="btnExportExcel_Click" tabindex="7"
                    visible="true" style="width: 50px; height: 5px; text-decoration: none;">
                    <img src='<%= ResolveUrl("~/images/icons/OCR_Excel.JPG") %>' alt="Excel" style="width: 80px;
                        height: 50px;" border="0" onerror="this.outerHTML='<span>EXCEL</span>';" />
                </a>
            </div>
            <div class="col-sm-2 mt-6">
                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
    <!-- Grid -->
    <div class="container-sm grid-container shadow-sm p-0">
        <div class="table-responsive" style="overflow-y: auto; border-top: 1px solid #eceff5;
            position: relative;">
            <asp:GridView runat="server" ID="GV_Details" CssClass="table table-sm table-bordered table-hover table-striped align-middle gridview-compact"
                AutoGenerateColumns="false" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                OnRowDataBound="GV_Details_RowDataBound1" OnRowCreated="GV_Details_RowCreated">
                <HeaderStyle CssClass="sticky-top text-white" Height="34px" />
                <Columns>
                    <asp:BoundField DataField="JOB_NO" HeaderText="JOB No" HeaderStyle-CssClass="small-header"
                        ItemStyle-CssClass="small-cell text-nowrap text-truncate" />
                    <asp:BoundField DataField="IMPORTER_NAME" HeaderText="Importer Name" HeaderStyle-CssClass="small-header"
                        ItemStyle-CssClass="small-cell text-nowrap text-truncate" />
                    <asp:BoundField DataField="UPLOAD_COUNT" HeaderText="Upload Count" HeaderStyle-CssClass="small-header"
                        ItemStyle-CssClass="small-cell text-nowrap text-truncate w-15" />
                    <asp:BoundField DataField="PAGE_COUNT" HeaderText="Page Count" HeaderStyle-CssClass="small-header"
                        ItemStyle-CssClass="small-cell text-nowrap text-truncate" />
                    <asp:BoundField DataField="PDF_USER_ID" HeaderText="User" HeaderStyle-CssClass="small-header"
                        ItemStyle-CssClass="small-cell text-nowrap text-truncate w-15" />
                    <asp:BoundField DataField="DATE_TIME" HeaderText="Date Time" HeaderStyle-CssClass="small-header"
                        ItemStyle-CssClass="small-cell text-nowrap text-truncate w-15" />
                    <asp:BoundField DataField="STATUS" HeaderText="Status" HeaderStyle-CssClass="small-header"
                        ItemStyle-CssClass="small-cell text-nowrap text-truncate w-15" />
                    <asp:BoundField DataField="VENDOR" HeaderText="Vendor" HeaderStyle-CssClass="small-header"
                        ItemStyle-CssClass="small-cell text-nowrap text-truncate w-15" />
                </Columns>
                <EmptyDataTemplate>
                    <div class="text-center text-danger fw-bold p-3">
                        No records found.</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <script type="text/javascript">
        document.getElementById("divTransportMode").style.display = "none";
    </script>
    <script type="text/javascript">
        function syncGridWidths() {
            var header = document.getElementById("GV_Header");
            var body = document.getElementById("GV_Details");
            if (!header || !body) return;
            var headerCells = header.getElementsByTagName("th");
            var bodyRows = body.getElementsByTagName("tr");
            if (bodyRows.length === 0) return;
            var bodyCells = bodyRows[0].getElementsByTagName("td");
            for (var i = 0; i < headerCells.length && i < bodyCells.length; i++) {
                var maxW = Math.max(headerCells[i].offsetWidth, bodyCells[i].offsetWidth);
                headerCells[i].style.width = maxW + "px";
                bodyCells[i].style.width = maxW + "px";
            }
        }
        function lockHorizontalScroll() {
            var bodyDiv = document.getElementById("bodyDiv");
            if (!bodyDiv) return;
            if (bodyDiv.addEventListener) {
                bodyDiv.addEventListener('scroll', function () { this.scrollLeft = 0; }, false);
            } else if (bodyDiv.attachEvent) {
                bodyDiv.attachEvent('onscroll', function () { bodyDiv.scrollLeft = 0; });
            }
        }
        window.onload = function () { syncGridWidths(); lockHorizontalScroll(); };
        window.onresize = syncGridWidths;
    </script>
    </form>
</body>
</html>
