<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_PDFReader.aspx.cs" Inherits="Import_Pdf_Reader_Import_PDFReader" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import PDF New</title>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    
  
 <script  language="jscript" type="text/javascript">
     $(document).ready(function () {
         $('#btnPrevData').click(function () {
             document.getElementById("lbl_loading").innerHTML = "File Loading...";
         });
     });
   
    </script>

<style type="text/css">
        * { box-sizing: border-box; }
        html, body { margin:0; padding:0; width:100%; height:100%; }
        body { font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:13px; background:#f0f2f8; color:#333; overflow:hidden; }
        form#form1 { width:100%; height:100%; }
        #UpdatePanel1 { display:block; width:100%; height:100%; }
        .pdf-reader-page { width:98%; height:100%; margin:0 auto; padding:10px 0; display:flex; flex-direction:column; min-height:0; }
        .reader-card { width:100%; background:#fff; border:1px solid #e8eaf6; border-radius:14px; box-shadow:0 4px 18px rgba(0,0,0,.07); overflow:hidden; margin-bottom:10px; flex:0 0 auto; }
        .reader-header { position:relative; min-height:52px; padding:0 18px; display:flex; align-items:center; gap:12px; color:#fff; background:linear-gradient(135deg,#3949ab,#5e35b1); }
        .reader-header-icon { width:34px; height:34px; border-radius:9px; display:flex; align-items:center; justify-content:center; background:rgba(255,255,255,.16); font-size:18px; }
        .reader-header-title { font-size:15px; font-weight:600; }
        .reader-header-subtitle { font-size:11px; opacity:.82; margin-top:2px; }
        .reader-close { position:absolute; right:0; top:0; width:100%; height:100%; pointer-events:none; }
        .reader-close .btn-close-x {
            position:absolute; right:10px; top:50%; transform:translateY(-50%);
            width:26px; height:26px;
            background:rgba(255,255,255,0.18); color:#fff;
            border:1px solid rgba(255,255,255,0.4); border-radius:50%;
            font-size:12px; font-weight:bold; cursor:pointer;
            line-height:1; padding:0; transition:background .2s ease;
            pointer-events:auto;
        }
        .reader-close .btn-close-x:hover { background:#e53935; border-color:#e53935; }
        .reader-section { padding:14px 16px; }
        .section-title { display:flex; align-items:center; gap:8px; margin-bottom:12px; font-size:13px; font-weight:600; color:#3949ab; }
        .section-title .step { width:23px; height:23px; border-radius:50%; display:inline-flex; align-items:center; justify-content:center; color:#fff; background:#3949ab; font-size:11px; }
        .reader-fields { display:grid; grid-template-columns:repeat(3,minmax(0,1fr)); gap:12px 18px; }
        .reader-field label { display:block; margin-bottom:5px; font-weight:600; color:#555; font-size:12px; }
        .reader-input, .reader-select { width:100%; height:32px; padding:5px 9px; border:1px solid #d7dbe7; border-radius:6px; background:#fff; font-size:12px; outline:none; }
        .reader-input:focus, .reader-select:focus { border-color:#5e35b1; box-shadow:0 0 0 2px rgba(94,53,177,.10); }
        .reader-job { background:#f7f7fc; font-weight:600; }
        .reader-upload-row { display:grid; grid-template-columns:1fr auto auto; align-items:center; gap:12px; padding:12px; border:1px dashed #c8cce0; border-radius:9px; background:#fafaff; }
        .reader-file { width:100%; min-height:32px; padding:5px; border:1px solid #d7dbe7; border-radius:6px; background:#fff; color:#333; }
        .reader-upload-btn { min-width:95px; height:32px; border:0; border-radius:6px; background:#3949ab; color:#fff; font-weight:600; cursor:pointer; padding:0 16px; }
        .reader-upload-btn:hover { background:#303f9f; }
        .reader-count { min-width:105px; padding:6px 12px; border-radius:7px; background:#eef0ff; color:#3949ab; text-align:center; font-weight:700; }
        .reader-status { color:#3949ab; font-size:12px; }
        .reader-grid-card { flex:1 1 auto; min-height:0; display:flex; flex-direction:column; }
        .reader-grid { flex:1 1 auto; min-height:0; overflow:auto; border-top:1px solid #eceff5; }
        .reader-grid .grid-view { width:100%; background:#fff; border:0; font-size:12px; }
        .reader-grid .grid-view th { position:sticky; top:0; z-index:2; padding:9px 8px; background:#4a4f78 !important; color:#fff !important; border:1px solid #5b6088; font-weight:600; white-space:nowrap; }
        .reader-grid .grid-view td { padding:7px 8px; border:1px solid #e1e4ec; white-space:nowrap; }
        .reader-grid .grid-view tr:nth-child(even) td { background:#fafbfe; }
        .reader-grid .grid-view tr:hover td { background:#f1f3fb; }
        .reader-actions { display:flex; align-items:center; gap:12px; padding:10px 16px; border-top:1px solid #eceff5; background:#fff; }
        .reader-save { min-width:90px; height:32px; border:0; border-radius:6px; background:#2e7d32; color:#fff; font-weight:600; }
        .reader-message { font-size:12px; }
        @media (max-width:850px) { .reader-fields { grid-template-columns:repeat(2,minmax(0,1fr)); } .reader-upload-row { grid-template-columns:1fr auto; } .reader-count { grid-column:2; } }
    </style>


<style id="import-blue-theme">
/* Import Feature Tools - exact blue family */
.reader-header {
    background: linear-gradient(90deg, #278ee2 0%, #3aa0e8 100%) !important;
}
.reader-header-icon {
    background: rgba(255,255,255,.18) !important;
}
.section-title .step {
    background: #278ee2 !important;
}
.section-title {
    color: #1f5fa8 !important;
}
.reader-upload-btn {
    background: #278ee2 !important;
}
.reader-upload-btn:hover {
    background: #1976d2 !important;
}
.reader-count {
    background: #e8f3ff !important;
    color: #1f5fa8 !important;
}
.reader-upload-row {
    border-color: #b9d8f2 !important;
    background: #f7fbff !important;
}
.reader-grid .grid-view th {
    background: #278ee2 !important;
    border-color: #3a9ae5 !important;
}
.reader-close .btn-close-x {
    background: rgba(255,255,255,.18) !important;
    border-color: rgba(255,255,255,.70) !important;
    color: #fff !important;
}
.reader-close .btn-close-x:hover {
    background: #dc3545 !important;
    border-color: #dc3545 !important;
}
</style>


<style id="import-ui-final-fixes">
/* Final Import PDF Reader UI fixes */
.reader-input:focus,
.reader-select:focus {
    border-color: #278ee2 !important;
    box-shadow: 0 0 0 2px rgba(39, 142, 226, 0.16) !important;
    outline: none !important;
}

/* File upload: keep the selected-file text in the Import blue theme */
.reader-file {
    color: #1f5fa8 !important;
    border-color: #c9dced !important;
    background: #fff !important;
    outline: none !important;
}

.reader-file:focus {
    border-color: #278ee2 !important;
    box-shadow: 0 0 0 2px rgba(39, 142, 226, 0.14) !important;
    outline: none !important;
}

/* Native browser file button */
.reader-file::file-selector-button {
    margin-right: 8px;
    padding: 4px 10px;
    border: 1px solid #278ee2;
    border-radius: 5px;
    background: #eaf5ff;
    color: #1f5fa8;
    font-weight: 600;
    cursor: pointer;
}

.reader-file::file-selector-button:hover {
    background: #d8edff;
}

/* Keep status text blue instead of browser/default black */
.reader-status,
.reader-status span {
    color: #1f5fa8 !important;
}
</style>

<style id="import-clear-busy-styles">
.reader-upload-row { grid-template-columns:minmax(0,1fr) auto auto auto !important; }
.reader-clear-btn { min-width:82px; height:32px; padding:0 14px; border:1px solid #278ee2; border-radius:6px; background:#fff; color:#1f5fa8; font-weight:700; font-size:12px; cursor:pointer; }
.reader-clear-btn:hover { background:#eaf5ff; }
.reader-file.reader-file-error { border-color:#d32f2f !important; box-shadow:0 0 0 2px rgba(211,47,47,.15) !important; }
#popup_container.import-red-alert { border-color:#d32f2f !important; }
#popup_container.import-red-alert #popup_title { background:#d32f2f !important; color:#fff !important; border-color:#d32f2f !important; }
#popup_container.import-red-alert #popup_message { color:#d32f2f !important; font-weight:700 !important; }
.import-busy-overlay { display:none; position:fixed; inset:0; z-index:99999; background:rgba(255,255,255,.72); align-items:center; justify-content:center; }
.import-busy-overlay.show { display:flex; }
.import-busy-box { min-width:260px; padding:22px 30px; text-align:center; background:#fff; border:1px solid #c9dced; border-radius:12px; box-shadow:0 8px 28px rgba(0,0,0,.18); }
.import-busy-spinner { width:34px; height:34px; margin:0 auto 10px; border:4px solid #d8edff; border-top-color:#278ee2; border-radius:50%; animation:importSpin .8s linear infinite; }
.import-busy-text { color:#1f5fa8; font-size:14px; font-weight:700; }
.import-busy-sub { margin-top:4px; color:#666; font-size:11px; }
@keyframes importSpin { to { transform:rotate(360deg); } }
@media (max-width:850px) { .reader-upload-row { grid-template-columns:minmax(0,1fr) auto auto !important; } }
</style>

<style id="import-fit-popup-fix">
/* The popup iframe has a fixed height. Make the page fit it: compact the
   Import Details form (label beside input), let the items card take the
   remaining height and scroll only its rows, and keep the action row visible. */
.pdf-reader-page {
    height:calc(100vh - 16px) !important;
    margin:8px auto !important;
    padding:0 !important;
    overflow:hidden !important;
}
.reader-card { margin-bottom:8px !important; }
.reader-header { min-height:48px !important; flex:0 0 auto; }
.reader-section { padding:8px 16px !important; }
.section-title { margin-bottom:8px !important; }
.reader-fields { gap:8px 18px !important; }
.reader-field { display:grid; grid-template-columns:105px minmax(0,1fr); align-items:center; gap:8px; min-width:0; }
.reader-field label { margin:0 !important; white-space:nowrap; }
.reader-field:empty { display:none; }
.reader-upload-row { padding:8px 10px !important; }
.reader-status { min-height:0; }
.reader-grid-card { flex:1 1 auto !important; min-height:0 !important; margin-bottom:0 !important; }
.reader-grid { flex:1 1 auto !important; min-height:60px !important; overflow:auto !important; }
.reader-actions { flex:0 0 auto !important; min-height:0; padding:6px 16px !important; }
</style>

</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />

                </div>
            <div id="importBusyOverlay" class="import-busy-overlay" role="status" aria-live="polite">
                <div class="import-busy-box">
                    <div class="import-busy-spinner"></div>
                    <div class="import-busy-text">File Loading...</div>
                    <div class="import-busy-sub">Extracting items from the PDF, please wait.</div>
                </div>
            </div>
            <div class="pdf-reader-page">
                <div class="reader-card">
                    <div class="reader-header">
                        <div class="reader-header-icon">&#128196;</div>
                        <div><div class="reader-header-title">PDF Import Workspace</div>
                        <div class="reader-header-subtitle">Upload, extract and review invoice details before saving</div></div>
                        <div class="reader-close"><asp:Button ID="btnClose" runat="server" Text="&#10005;" CssClass="btn-close-x"  ToolTip="Close" OnClientClick="RefreshParent(); return false;" CausesValidation="false" UseSubmitBehavior="false" /></div>
                    </div>
                    <div class="reader-section">
                        <div class="section-title"><span class="step">1</span> Import Details</div>
                        <div class="reader-fields">
                            <div class="reader-field"><label for="ddl_ImporterName">Importer Name</label><asp:DropDownList ID="ddl_ImporterName" runat="server" TabIndex="1" CssClass="reader-select"></asp:DropDownList></div>
                            <div class="reader-field"><label for="txtjobPS">Job No</label><asp:TextBox ID="txtjobPS" runat="server" MaxLength="10" ReadOnly="True" TabIndex="1" ClientIDMode="Static" CssClass="reader-input reader-job"></asp:TextBox></div>
                            <div class="reader-field"></div>
                            <div class="reader-field"><label for="txtSupplier">Supplier Name</label><asp:TextBox ID="txtSupplier" CssClass="reader-input" runat="server"></asp:TextBox></div>
                            <div class="reader-field"><label for="txtInvNo">Invoice No</label><asp:TextBox ID="txtInvNo" CssClass="reader-input" runat="server"></asp:TextBox></div>
                            <div class="reader-field"><label for="txtInvDate">Invoice Date</label><asp:TextBox ID="txtInvDate" CssClass="reader-input" runat="server"></asp:TextBox></div>
                            <div class="reader-field"><label for="txtCountryOfOrigin">Country Of Origin</label><asp:TextBox ID="txtCountryOfOrigin" CssClass="reader-input" runat="server"></asp:TextBox></div>
                            <div class="reader-field"><label for="txtPortOfOrigin">Port Of Discharge</label><asp:TextBox ID="txtPortOfOrigin" CssClass="reader-input" runat="server"></asp:TextBox></div>
                            <div class="reader-field"><label for="txtQTYCode">Qty Code</label><asp:TextBox ID="txtQTYCode" CssClass="reader-input" runat="server"></asp:TextBox></div>
                            <div class="reader-field"><label for="txtCurrency">Currency</label><asp:TextBox ID="txtCurrency" CssClass="reader-input" runat="server"></asp:TextBox></div>
                            <div class="reader-field"><label for="txtTerms">Terms</label><asp:TextBox ID="txtTerms" CssClass="reader-input" runat="server"></asp:TextBox></div>
                            <div class="reader-field"><label for="txtInvValue">Invoice Value</label><asp:TextBox ID="txtInvValue" CssClass="reader-input" runat="server"></asp:TextBox></div>
                        </div>
                    </div>
                    <div class="reader-section" style="padding-top:0;">
                        <div class="section-title"><span class="step">2</span> Upload PDF &amp; Extract Items</div>
                        <div class="reader-upload-row">
                            <asp:FileUpload ID="FilePDF" runat="server"  ToolTip="Selected files.." ForeColor="Blue" TabIndex="2" CssClass="reader-file" />
                            <asp:Button ID="btnPrevData" Text="Upload &amp; Extract" TabIndex="2" CssClass="reader-upload-btn" runat="server" ToolTip="Upload PDF & Extract Items" OnClick="btnPrevData_Click" />
                            <button type="button" id="btnClearImport" class="reader-clear-btn" onclick="clearImportReader()" title="Clear all fields">Clear</button>
                            <div class="reader-count"><span style="display:block;font-size:10px;font-weight:500;color:#666;">ITEM COUNT</span><asp:Label ID="lblCount" runat="server" Font-Bold="true" ClientIDMode="Static" TabIndex="1" Height="21px" CssClass="validate"></asp:Label></div>
                        </div>
                        <div class="reader-status" style="margin-top:7px;"><asp:Label ID="lbl_loading" runat="server" ForeColor="Blue"></asp:Label></div>
                    </div>
                </div>
                <div class="reader-card reader-grid-card">
                    <div class="reader-section" style="padding:12px 16px 9px;"><div class="section-title" style="margin-bottom:0;"><span class="step">3</span> Extracted Item Details</div></div>
                    <div class="reader-grid">
                        <asp:GridView ID="gv_ItemPDF" runat="server" AllowSorting="True" EmptyDataText="No Record Found" AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false" HorizontalAlign="Left" OnRowCreated="gv_ItemPDF_RowCreated" OnRowDataBound="gv_ItemPDF_RowDataBound" ShowHeaderWhenEmpty="True">
                            <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" /><SelectedRowStyle Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="ItemSlNo" HeaderText="Item Slno" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px"><ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" /></asp:BoundField>
                                <asp:BoundField DataField="ItemDesc" HeaderText="Item Description" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="350px"><ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="350px" Font-Size="11px" /></asp:BoundField>
                                <asp:BoundField DataField="Quantity" HeaderText="Item Qty" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px"><ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" /></asp:BoundField>
                                <asp:BoundField DataField="Rate" HeaderText="Item Unit Price" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="130px"><ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" /></asp:BoundField>
                                <asp:BoundField DataField="Amount" HeaderText="Item Amt" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="130px"><ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" /></asp:BoundField>
                                <asp:BoundField DataField="PartNo" HeaderText="Part No" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px"><ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" /></asp:BoundField>
                                <asp:BoundField DataField="PONumber" HeaderText="PO Number" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px"><ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" /></asp:BoundField>
                                <asp:BoundField DataField="NetWeight" HeaderText="Net Weight" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px"><ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" /></asp:BoundField>
                                <asp:BoundField DataField="HSCode" HeaderText="HS Code" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px"><ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" /></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="reader-actions"><asp:Button ID="btnupload" runat="server" Width="100px" Height="32px" Text="Save" Visible="false" CssClass="reader-save" TabIndex="4" OnClick="btnupload_Click" /><asp:Literal ID="lblmsg" runat="server"></asp:Literal></div>
                </div>
            </div>

<%-----------------------------------END----------------------------------------------------------------%>
            
            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_alert" runat="server" />
            <asp:HiddenField ID="hdprefix" runat="server" />
                    <asp:HiddenField ID="hdsuffix" runat="server" />
                    <asp:HiddenField ID="hdn_JOBNO" runat="server" />
                    <asp:HiddenField ID="hdn_JOBNO_PS" runat="server" />
                    <asp:HiddenField ID="hdn_missed_Desc" runat="server" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" />
                    <asp:HiddenField ID="hdn_JOBNO_digit" runat="server" />
                    <asp:HiddenField ID="hd_Brslno" runat="server" />
                    <asp:HiddenField ID="hd_Supplier" runat="server" />
                    <asp:HiddenField ID="hd_InvNo" runat="server" />
                    <asp:HiddenField ID="hd_InvDate" runat="server" />
                    <asp:HiddenField ID="hd_Currency" runat="server" />
                    <asp:HiddenField ID="hd_Terms" runat="server" />
                    <asp:HiddenField ID="hd_InvValue" runat="server" />
                    <asp:HiddenField ID="hd_ItemSlNo" runat="server" />
                    <asp:HiddenField ID="hd_ItemDesc" runat="server" />
                    <asp:HiddenField ID="hd_Quantity" runat="server" />
                    <asp:HiddenField ID="hd_Rate" runat="server" />
                    <asp:HiddenField ID="hd_Amount" runat="server" />
                    <asp:HiddenField ID="hd_IPartNo" runat="server" />
                    <asp:HiddenField ID="hd_PONumber" runat="server" />
                    <asp:HiddenField ID="hd_NetWeight" runat="server" />
                    <asp:HiddenField ID="hd_HSCode" runat="server" />
                    <asp:HiddenField ID="hd_CustomsHouse" runat="server" />
                    <asp:HiddenField ID="hd_ImporterName" runat="server" />
                    <asp:HiddenField ID="hd_ImporterAdd1" runat="server" />
                    <asp:HiddenField ID="hd_ImporterAdd2" runat="server" />
                    <asp:HiddenField ID="hd_ImporterAdd3" runat="server" />
                    <asp:HiddenField ID="hd_ImporterAdd4" runat="server" />

           
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text="Delete Ur Previous Invoice for this Job ?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 100px; padding-top: 10px;">
                        <asp:Button ID="btnyes" runat="server" Text="Yes" CausesValidation="false" UseSubmitBehavior="false" />
                        <asp:Button ID="btnNo" runat="server" Text="No" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="return HideModalPopup_U()" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    </form>

     <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>

         <script type="text/javascript">
             function RefreshParent() {
                 // Close the popup itself; reloading window.parent reloaded the whole app shell.
                 try {
                     if (window.parent && typeof window.parent.closeExistingPopup === 'function') {
                         window.parent.closeExistingPopup();
                     } else if (window.parent && window.parent.adcodewindow && typeof window.parent.adcodewindow.hide === 'function') {
                         window.parent.adcodewindow.hide();
                     } else {
                         window.parent.location.reload();
                     }
                 } catch (e) { }
             }

             function clearImportReader() {
                 var ids = ['txtSupplier', 'txtInvNo', 'txtInvDate', 'txtCountryOfOrigin', 'txtPortOfOrigin',
                            'txtQTYCode', 'txtCurrency', 'txtTerms', 'txtInvValue'];
                 for (var i = 0; i < ids.length; i++) {
                     var el = document.getElementById(ids[i]);
                     if (el) el.value = '';
                 }

                 var fileInput = document.getElementById('FilePDF');
                 if (fileInput) {
                     try { fileInput.value = ''; } catch (e) { }
                     fileInput.classList.remove('reader-file-error');
                 }

                 // Remove data rows, keep the header row.
                 var table = document.getElementById('gv_ItemPDF');
                 if (table) {
                     var rows = table.getElementsByTagName('tr');
                     for (var j = rows.length - 1; j >= 0; j--) {
                         if (rows[j].getElementsByTagName('th').length === 0 && rows[j].parentNode) {
                             rows[j].parentNode.removeChild(rows[j]);
                         }
                     }
                 }

                 var count = document.getElementById('lblCount');
                 if (count) count.innerHTML = '0';

                 var lbl = document.getElementById('lbl_loading');
                 if (lbl) { lbl.innerHTML = ''; lbl.style.color = ''; }
                 var msg = document.getElementById('lblmsg');
                 if (msg) msg.innerHTML = '';

                 // Save only makes sense for a freshly extracted file.
                 var save = document.getElementById('btnupload');
                 if (save) save.style.display = 'none';

                 if (fileInput) fileInput.focus();
             }

             (function () {
                 // Capture phase: runs before the button's own postback.
                 document.addEventListener('click', function (e) {
                     var t = e.target;
                     if (!t || t.id !== 'btnPrevData') return;

                     var fileInput = document.getElementById('FilePDF');
                     if (!fileInput || !fileInput.files || fileInput.files.length === 0) {
                         e.preventDefault();
                         e.stopPropagation();
                         var warn = document.getElementById('lbl_loading');
                         if (warn) {
                             warn.style.color = '#d32f2f';
                             warn.style.fontWeight = '600';
                             warn.innerHTML = '&#9888; Please upload a PDF file.';
                         }
                         if (fileInput) fileInput.classList.add('reader-file-error');
                         if (typeof jAlert === 'function') {
                             jAlert('&#9888; Please upload a PDF file.', 'Import PDF Upload', function () { if (fileInput) fileInput.focus(); });
                             var box = document.getElementById('popup_container');
                             if (box) box.className = (box.className + ' import-red-alert').trim();
                         } else {
                             alert('Please upload a PDF file.');
                         }
                         return false;
                     }

                     var overlay = document.getElementById('importBusyOverlay');
                     if (overlay) overlay.className = 'import-busy-overlay show';
                     var lbl = document.getElementById('lbl_loading');
                     if (lbl) { lbl.style.color = ''; lbl.innerHTML = 'File Loading...'; }
                 }, true);

                 document.addEventListener('change', function (e) {
                     if (e.target && e.target.id === 'FilePDF') {
                         e.target.classList.remove('reader-file-error');
                         var l = document.getElementById('lbl_loading');
                         if (l) { l.style.color = ''; l.innerHTML = ''; }
                     }
                 }, true);

                 window.addEventListener('pageshow', function () {
                     var overlay = document.getElementById('importBusyOverlay');
                     if (overlay) overlay.className = 'import-busy-overlay';
                 });
             })();
    </script>
</body>
</html>