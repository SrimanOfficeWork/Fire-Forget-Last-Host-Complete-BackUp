<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_PDF_Reader_New.aspx.cs" Inherits="Export_PDF_Reader_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
     <title>Export PDF New</title>
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
    
  
 <script language="jscript" type="text/javascript">
     $(document).ready(function () {
         // Show "File Loading..." immediately when Upload & Extract is clicked
         $('#btnPrevData').click(function () {
             document.getElementById("lbl_loading").innerHTML = "File Loading...";
         });

         // FIX 3: Show popup alert if job was uploaded successfully (set by server in lbl_loading)
         var statusLbl = document.getElementById("lbl_loading");
         if (statusLbl && statusLbl.innerHTML.indexOf("Job Uploaded Successfully") !== -1) {
             jAlert("✔ Job has been created successfully!", "Export PDF Upload", function () {
                 // Optionally clear the label after dismissing
                 document.getElementById("lbl_loading").innerHTML = "";
             });
         }
     });

     // Also hook into ASP.NET UpdatePanel partial-postback end (if UpdatePanel is used)
     if (typeof Sys !== "undefined" && Sys.WebForms && Sys.WebForms.PageRequestManager) {
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
             var statusLbl = document.getElementById("lbl_loading");
             if (statusLbl && statusLbl.innerHTML.indexOf("Job Uploaded Successfully") !== -1) {
                 jAlert("✔ Job has been created successfully!", "Export PDF Upload", function () {
                     document.getElementById("lbl_loading").innerHTML = "";
                 });
             }
         });
     }
    </script>


<style type="text/css">
    * { box-sizing: border-box; }
    html, body { margin:0; padding:0; height:100%; }
    body { overflow:hidden !important; background:transparent; }
    .export-reader-page {
        width:96%; max-width:1100px; height:calc(100vh - 18px); min-height:560px;
        margin:8px auto 10px; font-family:'Segoe UI',Tahoma,Geneva,Verdana,sans-serif;
        display:flex; flex-direction:column; gap:10px;
    }
    .export-reader-card {
        background:#fff; border:1px solid #dfe5ee; border-radius:15px;
        box-shadow:0 5px 22px rgba(0,0,0,.10); overflow:hidden;
    }
    .export-reader-main { flex:0 0 auto; }
    .export-reader-header {
        position:relative; min-height:58px; padding:9px 52px 9px 18px;
        display:flex; align-items:center; color:#fff;
        background:linear-gradient(135deg,#2e7d32,#66bb6a);
        box-shadow:0 4px 15px rgba(46,125,50,.30);
    }
    .export-reader-title { display:flex; align-items:center; gap:10px; }
    .export-reader-icon {
        width:34px; height:34px; border-radius:9px; background:rgba(255,255,255,.17);
        display:flex; align-items:center; justify-content:center; font-size:18px;
    }
    .export-reader-heading { font-size:15px; font-weight:700; letter-spacing:.4px; }
    .export-reader-subtitle { margin-top:2px; font-size:11px; opacity:.88; }
    .export-close-wrap { position:absolute; inset:0; pointer-events:none; }
    .export-close-btn {
        position:absolute !important; right:10px !important; top:50% !important;
        transform:translateY(-50%) !important; width:26px !important; height:26px !important;
        min-width:26px !important; padding:0 !important; margin:0 !important;
        border-radius:50% !important; background:rgba(255,255,255,.18) !important;
        color:#fff !important; border:1px solid rgba(255,255,255,.65) !important;
        font-family:Arial,sans-serif !important; font-size:17px !important;
        font-weight:400 !important; line-height:23px !important; text-align:center !important;
        cursor:pointer !important; box-shadow:none !important; pointer-events:auto !important;
        text-decoration:none !important;
    }
    .export-close-btn:hover { background:#e53935 !important; border-color:#e53935 !important; }
    .export-section { padding:12px 16px; }
    .export-section-title {
        display:flex; align-items:center; gap:8px; margin-bottom:10px;
        color:#2e7d32; font-size:13px; font-weight:600;
    }
    .export-step {
        width:23px; height:23px; border-radius:50%; background:#43a047; color:#fff;
        display:inline-flex; align-items:center; justify-content:center; font-size:11px; font-weight:700;
    }
    .export-fields { display:grid; grid-template-columns:repeat(2,minmax(0,1fr)); gap:10px 18px; }
    .export-field { display:grid; grid-template-columns:105px minmax(0,1fr); align-items:center; gap:10px; min-width:0; }
    .export-field label { color:#45515c; font-size:12px; font-weight:600; white-space:nowrap; }
    .export-input, .export-select {
        width:100% !important; height:32px !important; padding:5px 9px !important;
        border:1px solid #d7dce7 !important; border-radius:7px !important;
        background:#fff !important; color:#333 !important; font-size:12px !important;
        box-sizing:border-box !important; outline:none;
    }
    .export-input:focus, .export-select:focus {
        border-color:#66bb6a !important; box-shadow:0 0 0 3px rgba(102,187,106,.15) !important;
    }
    /* Compact Export Details fields */
    #txtjobPS.export-job { width:130px !important; }
    #txtConsigneeName.export-input, #txtBuyer.export-input { width:260px !important; }
    .export-job { background:#f7faf7 !important; font-weight:600 !important; }
    .export-upload-row {
        display:grid; grid-template-columns:minmax(0,1fr) 146px 82px 96px; align-items:center; gap:12px;
        padding:10px 10px; border:1px dashed #b9d8bf; border-radius:9px; background:#fbfdfb;
    }
    .export-file {
        width:100% !important; height:38px !important; min-height:38px !important;
        padding:4px !important; font-size:12px !important; border:1px solid #cfe0d2 !important;
        border-radius:6px !important; background:#fff !important; color:#2d7d3d !important;
        box-sizing:border-box !important; outline:none !important;
    }
    .export-file:focus {
        border-color:#3ca653 !important;
        box-shadow:0 0 0 2px rgba(60,166,83,.14) !important;
        outline:none !important;
    }
    .export-file::file-selector-button {
        height:30px !important; margin:3px 8px 3px 3px !important; padding:3px 10px !important;
        border:1px solid #3ca653 !important; border-radius:5px !important;
        background:#edf8ef !important; color:#2d7d3d !important; font-weight:600 !important;
        cursor:pointer !important;
    }
    .export-file::file-selector-button:hover { background:#dff2e2 !important; }
    .export-upload-btn {
        width:146px !important; min-width:146px !important; height:38px !important;
        padding:0 12px !important; border:0 !important; border-radius:6px !important;
        background:#3ca653 !important; color:#fff !important; font-size:12px !important;
        font-weight:700 !important; cursor:pointer !important; box-shadow:0 3px 9px rgba(46,125,50,.20) !important;
        white-space:nowrap;
    }
    .export-upload-btn:hover { background:#318b45 !important; }
    .export-count {
        width:108px !important; min-width:108px !important; height:38px !important;
        display:flex !important; flex-direction:column !important; align-items:center !important;
        justify-content:center !important; box-sizing:border-box !important; border-radius:7px !important;
        background:#edf8ef !important; color:#2d7d3d !important; text-align:center !important;
        font-weight:700 !important;
    }
    .export-count-title { display:block; font-size:10px; font-weight:500; color:#666 !important; line-height:12px; }
    .export-count-value { display:block; font-size:14px; font-weight:700; color:#2d7d3d !important; line-height:18px; }
    @media (max-width:850px) {
        .export-upload-row { grid-template-columns:minmax(0,1fr) 146px; }
        .export-count { grid-column:2; }
    }
    .export-status { margin-top:6px; color:#2d7d3d !important; font-size:11px; }
    .export-grid-card { flex:1 1 auto; min-height:0; display:flex; flex-direction:column; }
    .export-grid-title { padding:11px 16px 9px; }
    .export-grid-wrap {
        flex:0 0 250px;
        height:250px;
        min-height:250px;
        max-height:250px;
        overflow-y:auto;
        overflow-x:auto;
        border-top:1px solid #e7ebef;
        background:#fff;
        box-sizing:border-box;
        scrollbar-width:thin;
    }

    /* Keep the extracted-items header visible while scrolling many rows */
    #gv_ItemPDF th {
        position:sticky !important;
        top:0 !important;
        z-index:5 !important;
    }

    /* Prevent the GridView itself from forcing the modal taller */
    #gv_ItemPDF {
        width:100% !important;
        min-width:760px;
    }
    #gv_ItemPDF { width:100% !important; min-width:760px; border-collapse:collapse !important; font-size:12px;
    }
    #gv_ItemPDF th {
        position:sticky; top:0; z-index:2; padding:8px 9px !important;
        background:#3f7f45 !important; color:#fff !important; border:1px solid #4d8c53 !important;
        font-weight:600 !important; white-space:nowrap;
    }
    #gv_ItemPDF td { padding:7px 9px !important; border:1px solid #e2e7e2 !important; white-space:nowrap; }
    #gv_ItemPDF tr:nth-child(even) td { background:#fafcfb; }
    #gv_ItemPDF tr:hover td { background:#eef7ef; }
    .export-actions {
        display:flex; align-items:center; gap:12px; min-height:48px; padding:8px 16px;
        border-top:1px solid #e7ebef; background:#fff;
    }
    .export-save-btn {
        min-width:100px !important; height:32px !important; border:0 !important; border-radius:6px !important;
        background:#2e7d32 !important; color:#fff !important; font-weight:600 !important;
    }
    .export-message { font-size:12px; }
    @media (max-width:850px) {
        .export-reader-page { width:98%; }
        .export-fields { grid-template-columns:1fr; }
    }
</style>


<style id="export-upload-layout-final">
/* Fix: native FileUpload has a browser min-width and was pushing the
   Upload & Extract / Item Count controls outside the upload row. */
.export-upload-row {
    display: grid !important;
    grid-template-columns: minmax(0, 1fr) 146px 108px !important;
    align-items: center !important;
    gap: 12px !important;
    width: 100% !important;
    min-width: 0 !important;
    overflow: visible !important;
}

.export-upload-row > * {
    min-width: 0 !important;
}

.export-file {
    display: block !important;
    width: 100% !important;
    min-width: 0 !important;
    max-width: 100% !important;
    height: 38px !important;
    box-sizing: border-box !important;
    overflow: hidden !important;
    padding: 3px !important;
    border: 1px solid #cfe0d2 !important;
    border-radius: 6px !important;
    background: #fff !important;
    color: #2d7d3d !important;
    font-size: 12px !important;
}

.export-file::file-selector-button {
    height: 30px !important;
    margin: 1px 8px 1px 1px !important;
    padding: 3px 10px !important;
    border: 1px solid #3ca653 !important;
    border-radius: 5px !important;
    background: #edf8ef !important;
    color: #2d7d3d !important;
    font-weight: 600 !important;
    cursor: pointer !important;
}

.export-upload-btn {
    display: block !important;
    width: 146px !important;
    min-width: 146px !important;
    max-width: 146px !important;
    height: 38px !important;
    box-sizing: border-box !important;
    margin: 0 !important;
    padding: 0 12px !important;
    background: #3ca653 !important;
    border: 1px solid #3ca653 !important;
    border-radius: 6px !important;
    color: #fff !important;
    font-size: 12px !important;
    font-weight: 700 !important;
    white-space: nowrap !important;
    cursor: pointer !important;
}

.export-count {
    display: flex !important;
    width: 108px !important;
    min-width: 108px !important;
    max-width: 108px !important;
    height: 38px !important;
    box-sizing: border-box !important;
    align-items: center !important;
    justify-content: center !important;
    margin: 0 !important;
    border-radius: 7px !important;
    background: #edf8ef !important;
    color: #2d7d3d !important;
}

/* Prevent the status label from creating an extra visual row */
.export-status {
    clear: both !important;
    min-height: 0 !important;
    margin: 4px 0 0 !important;
}
</style>



<style id="export-clear-button-fix">
/* Clear button beside Upload & Extract */
.export-clear-btn {
    width:82px !important;
    min-width:82px !important;
    height:38px !important;
    padding:0 10px !important;
    border:1px solid #3ca653 !important;
    border-radius:6px !important;
    background:#fff !important;
    color:#2d7d3d !important;
    font-size:12px !important;
    font-weight:700 !important;
    cursor:pointer !important;
    box-sizing:border-box !important;
}
.export-clear-btn:hover {
    background:#edf8ef !important;
    border-color:#2e7d32 !important;
}
@media (max-width:850px) {
    .export-upload-row {
        grid-template-columns:minmax(0,1fr) 146px 82px !important;
    }
    .export-count {
        grid-column:3 !important;
    }
}
</style>

<style id="live-upload-button-fix">
/* LIVE FIX: keep the final Upload action inside the visible Section 3 card */
.export-reader-page {
    height: auto !important;
    min-height: 0 !important;
    overflow: visible !important;
}

.export-reader-main {
    flex: 0 0 auto !important;
}

.export-grid-card {
    flex: 0 0 auto !important;
    min-height: 0 !important;
    overflow: hidden !important;
}

.export-grid-wrap {
    flex: 0 0 auto !important;
    height: 150px !important;
    min-height: 150px !important;
    max-height: 150px !important;
    overflow: auto !important;
}

.export-actions {
    display: flex !important;
    visibility: visible !important;
    position: relative !important;
    z-index: 20 !important;
    min-height: 52px !important;
    height: 52px !important;
    align-items: center !important;
    justify-content: flex-end !important;
    padding: 8px 16px !important;
    background: #fff !important;
    border-top: 1px solid #e7ebef !important;
}

.export-save-btn {
    display: inline-block !important;
    visibility: visible !important;
    opacity: 1 !important;
    position: relative !important;
    z-index: 21 !important;
    width: 100px !important;
    min-width: 100px !important;
    height: 32px !important;
    background: #2e7d32 !important;
    color: #fff !important;
    border: 0 !important;
    border-radius: 6px !important;
    font-weight: 600 !important;
    cursor: pointer !important;
}

/* Section 2 is Preview, not final Upload */
.export-upload-btn {
    width: 146px !important;
    min-width: 146px !important;
}
</style>


<style id="final-upload-button-style">
/* Final Upload button: visible, centered and consistent with Export theme */
.export-reader-page {
    max-height: calc(100vh - 24px) !important;
    overflow: hidden !important;
}
.export-grid-card {
    overflow: hidden !important;
}
.export-grid-wrap {
    height: 120px !important;
    min-height: 120px !important;
    max-height: 120px !important;
    overflow: auto !important;
}
.export-actions {
    display: flex !important;
    align-items: center !important;
    justify-content: center !important;
    height: 50px !important;
    min-height: 50px !important;
    padding: 8px 16px !important;
    background: #fff !important;
    border-top: 1px solid #e7ebef !important;
    visibility: visible !important;
    opacity: 1 !important;
}
.export-save-btn {
    display: inline-block !important;
    visibility: visible !important;
    opacity: 1 !important;
    width: 100px !important;
    min-width: 100px !important;
    height: 32px !important;
    padding: 0 16px !important;
    margin: 0 auto !important;
    background: linear-gradient(135deg, #2e7d32, #4caf50) !important;
    color: #fff !important;
    border: 0 !important;
    border-radius: 7px !important;
    box-shadow: 0 3px 9px rgba(46,125,50,.25) !important;
    font-size: 12px !important;
    font-weight: 700 !important;
    cursor: pointer !important;
}
.export-save-btn:hover {
    background: #2e7d32 !important;
    box-shadow: 0 4px 12px rgba(46,125,50,.35) !important;
}
</style>

<style id="export-final-ui-fixes">
/* ===== FINAL EXPORT UI FIXES ===== */

/* Remove legacy blue line-item row styling */
#gv_ItemPDF,
#gv_ItemPDF tbody,
#gv_ItemPDF tbody tr,
#gv_ItemPDF tbody td {
    background: #fff !important;
}

#gv_ItemPDF tbody tr:nth-child(even) td,
#gv_ItemPDF tbody tr:nth-child(odd) td {
    background: #fff !important;
    color: #222 !important;
}

#gv_ItemPDF tbody tr:hover td {
    background: #f1f8f2 !important;
}

/* Keep the Export green table header */
#gv_ItemPDF thead th,
#gv_ItemPDF th {
    background: #3f7f45 !important;
    color: #fff !important;
}

/* Visible item count */
.export-count {
    width: 108px !important;
    min-width: 108px !important;
    height: 38px !important;
    padding: 3px 6px !important;
}

.export-count-value {
    display: block !important;
    margin-top: 1px !important;
    font-size: 14px !important;
    line-height: 16px !important;
    font-weight: 700 !important;
    color: #2d7d3d !important;
}

/* Selected PDF display */
.export-file-wrap {
    min-width: 0 !important;
    width: 100% !important;
}

.export-file {
    display: block !important;
}

.export-selected-files {
    display: flex !important;
    flex-wrap: wrap !important;
    gap: 6px !important;
    margin-top: 6px !important;
    min-height: 0 !important;
}

.export-selected-files:empty {
    display: none !important;
}

.export-pdf-chip {
    display: inline-flex !important;
    align-items: center !important;
    gap: 7px !important;
    max-width: 100% !important;
    min-height: 28px !important;
    padding: 4px 7px 4px 9px !important;
    border: 1px solid #b9d8bf !important;
    border-radius: 6px !important;
    background: #f2faf3 !important;
    color: #2d7d3d !important;
    font-size: 11px !important;
    box-sizing: border-box !important;
}

.export-pdf-chip-name {
    overflow: hidden !important;
    text-overflow: ellipsis !important;
    white-space: nowrap !important;
    max-width: 260px !important;
}

.export-pdf-chip-remove {
    width: 18px !important;
    height: 18px !important;
    min-width: 18px !important;
    padding: 0 !important;
    border: 0 !important;
    border-radius: 50% !important;
    background: #d9eadb !important;
    color: #2d7d3d !important;
    font-size: 13px !important;
    line-height: 18px !important;
    text-align: center !important;
    cursor: pointer !important;
}

.export-pdf-chip-remove:hover {
    background: #e53935 !important;
    color: #fff !important;
}

/* Don't let the chip make the upload row overflow */
.export-upload-row {
    min-width: 0 !important;
}

@media (max-width:850px) {
    .export-pdf-chip-name {
        max-width: 180px !important;
    }
}
</style>


<style id="export-upload-row-final-fix">
/* Final upload row layout: compact Browse field + actions on the same row */
.export-upload-row {
    display:grid !important;
    grid-template-columns: minmax(0, 58%) 146px 82px 96px !important;
    align-items:center !important;
    justify-content:start !important;
    gap:12px !important;
    width:100% !important;
    min-width:0 !important;
    box-sizing:border-box !important;
}
.export-upload-row .export-file-wrap {
    width:100% !important;
    min-width:0 !important;
    max-width:none !important;
}
.export-upload-row .export-file {
    width:100% !important;
    min-width:0 !important;
    max-width:none !important;
}
.export-upload-row .export-upload-btn {
    grid-column:2 !important;
}
.export-upload-row .export-clear-btn {
    grid-column:3 !important;
}
.export-upload-row .export-count {
    grid-column:4 !important;
    width:96px !important;
    min-width:96px !important;
    max-width:96px !important;
    height:38px !important;
    margin:0 !important;
}
@media (max-width:850px) {
    .export-upload-row {
        grid-template-columns:minmax(0,1fr) 146px 82px !important;
    }
    .export-upload-row .export-count {
        grid-column:3 !important;
    }
}
</style>

<style id="export-upload-overflow-fix">
/* Selecting a PDF adds the file chip and makes the page taller; the earlier
   fixed max-height + overflow:hidden then clipped the Upload button. Let the
   page scroll instead of clipping, and keep the header/actions intact. */
/* Popup iframe has a fixed height. Fit the page to it: top card takes its natural
   height (chip / status message included), the items card takes the rest, only
   the grid rows scroll, and the Upload button stays pinned at the bottom. */
html, body { height:100% !important; }
body { overflow:hidden !important; }
.export-reader-page {
    height:calc(100vh - 16px) !important;
    max-height:none !important;
    min-height:0 !important;
    overflow:hidden !important;
    margin:8px auto !important;
    display:flex !important;
    flex-direction:column !important;
}
.export-reader-main { flex:0 0 auto !important; }
.export-grid-card {
    flex:1 1 auto !important;
    min-height:0 !important;
    display:flex !important;
    flex-direction:column !important;
    overflow:hidden !important;
}
.export-grid-title { flex:0 0 auto; padding:8px 16px 6px !important; }
.export-grid-wrap {
    flex:1 1 auto !important;
    height:auto !important;
    min-height:0 !important;
    max-height:none !important;
    overflow:auto !important;
}
.export-actions {
    flex:0 0 auto !important;
    height:46px !important;
    min-height:46px !important;
    padding:6px 16px !important;
}
.export-section { padding:8px 16px !important; }
.export-selected-files { margin-top:4px !important; }
.export-status { margin:2px 0 0 !important; }

.export-file.export-file-error { border-color:#d32f2f !important; box-shadow:0 0 0 2px rgba(211,47,47,.15) !important; }
.export-status span { color:inherit; }
#popup_container.export-red-alert { border-color:#d32f2f !important; }
#popup_container.export-red-alert #popup_title { background:#d32f2f !important; color:#fff !important; border-color:#d32f2f !important; }
#popup_container.export-red-alert #popup_message { color:#d32f2f !important; font-weight:700 !important; }

/* Busy overlay shown while Upload & Extract is posting back */
.export-busy-overlay {
    display:none; position:fixed; inset:0; z-index:99999;
    background:rgba(255,255,255,.72); align-items:center; justify-content:center;
}
.export-busy-overlay.show { display:flex; }
.export-busy-box {
    min-width:260px; padding:22px 30px; text-align:center; background:#fff;
    border:1px solid #cfe0d2; border-radius:12px; box-shadow:0 8px 28px rgba(0,0,0,.18);
    font-family:'Segoe UI',Tahoma,Geneva,Verdana,sans-serif;
}
.export-busy-spinner {
    width:34px; height:34px; margin:0 auto 10px; border:4px solid #d9eadb;
    border-top-color:#2e7d32; border-radius:50%; animation:exportSpin .8s linear infinite;
}
.export-busy-text { color:#2e7d32; font-size:14px; font-weight:700; }
.export-busy-sub { margin-top:4px; color:#666; font-size:11px; }
@keyframes exportSpin { to { transform:rotate(360deg); } }
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
            <div id="exportBusyOverlay" class="export-busy-overlay" role="status" aria-live="polite">
                <div class="export-busy-box">
                    <div class="export-busy-spinner"></div>
                    <div class="export-busy-text">File Loading...</div>
                    <div class="export-busy-sub">Extracting items from the PDF, please wait.</div>
                </div>
            </div>
            <div class="export-reader-page">
                <div class="export-reader-card export-reader-main">
                    <div class="export-reader-header">
                        <div class="export-reader-title">
                            <span class="export-reader-icon">&#128196;</span>
                            <div>
                                <div class="export-reader-heading">PDF Export Workspace</div>
                                <div class="export-reader-subtitle">Upload, extract and review invoice details before saving</div>
                            </div>
                        </div>
                        <div class="export-close-wrap">
                            <asp:Button ID="btnClose" runat="server" Text="&#10005;" ToolTip="Close"
                                CssClass="export-close-btn" OnClientClick="RefreshParent(); return false;"
                                CausesValidation="false" UseSubmitBehavior="false" />
                        </div>
                    </div>

                    <div class="export-section">
                        <div class="export-section-title"><span class="export-step">1</span><span>Export Details</span></div>
                        <div class="export-fields">
                            <div class="export-field">
                                <label for="ddl_ExporterName">Exporter Name</label>
                                <asp:DropDownList ID="ddl_ExporterName" runat="server" TabIndex="1" CssClass="export-select"></asp:DropDownList>
                            </div>
                            <div class="export-field">
                                <label for="txtjobPS">Job No</label>
                                <asp:TextBox ID="txtjobPS" runat="server" Font-Bold="true" MaxLength="10" Font-Size="12px"
                                    CssClass="export-input export-job" Width="130px" ReadOnly="True" TabIndex="1" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="export-field">
                                <label for="txtConsigneeName">Consignee</label>
                                <asp:TextBox ID="txtConsigneeName" Font-Size="12px" runat="server"
                                    CssClass="validate export-input" ClientIDMode="Static" TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="export-field">
                                <label for="txtBuyer">Buyer</label>
                                <asp:TextBox ID="txtBuyer" Font-Size="12px" runat="server" CssClass="validate export-input"
                                    ClientIDMode="Static" TabIndex="1"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="export-section" style="padding-top:0;">
                        <div class="export-section-title"><span class="export-step">2</span><span>Upload PDF &amp; Extract Items</span></div>
                        <div class="export-upload-row">
                            <div class="export-file-wrap">
                                <asp:FileUpload ID="FilePDF" runat="server" ToolTip="Select PDF file" ForeColor="#2d7d3d"
                                    TabIndex="2" CssClass="export-file" />
                            </div>
                            <asp:Button ID="btnPrevData" Text="Upload &amp; Extract" TabIndex="2"
                                CssClass="export-upload-btn" runat="server" UseSubmitBehavior="false" OnClick="btnPrevData_Click" ToolTip="Preview and Extract PDF Items" />
                            <button type="button" id="btnClearExport" class="export-clear-btn" onclick="clearExportReader()" title="Clear all fields">Clear</button>
                            <div class="export-count" aria-live="polite">
                                <span class="export-count-title">ITEM COUNT</span>
                                <span class="export-count-value" id="exportItemCount">0</span>
                            </div>
                        </div>
                        <%-- FIX 1: Selected file chip now lives BELOW the grid row so it never breaks the button layout --%>
                        <div id="exportSelectedFiles" class="export-selected-files" aria-live="polite" style="margin-top:6px;"></div>
                        <div class="export-status"><asp:Label ID="lbl_loading" runat="server"></asp:Label></div>
                    </div>
                </div>

                <div class="export-reader-card export-grid-card">
                    <div class="export-section-title export-grid-title">
                        <span class="export-step">3</span><span>Extracted Item Details</span>
                    </div>
                    <div class="export-grid-wrap">
                        <asp:GridView ID="gv_ItemPDF" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                            BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                            HorizontalAlign="Left" OnRowCreated="gv_ItemPDF_RowCreated" OnRowDataBound="gv_ItemPDF_RowDataBound"
                            ShowHeaderWhenEmpty="True">
                            <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                            <SelectedRowStyle Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item Slno" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ITEM_DESC" HeaderText="Item Description" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="450px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="450px" Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ITEM_QTY" HeaderText="Item Qty" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ITEM_QTY_CODE" HeaderText="Qty Code" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="60px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="60px" Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ITEM_UNITPRICE" HeaderText="Item Unit Price" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ITEM_AMOUNT" HeaderText="Item Amt" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="export-actions">
                        <asp:Button ID="btnupload" runat="server" Width="100px" Height="32px" Text="Upload"
                            CssClass="export-save-btn" TabIndex="4" OnClick="btnupload_Click" />
                        <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                    </div>
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

           
        </ContentTemplate>
    </asp:UpdatePanel>

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
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();

        });

        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            document.getElementById("General").click();
        }
        
    </script>
    
    <script type="text/javascript">
        function RefreshParent() {
            window.parent.location.reload();
        }
        
    </script>
   

    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtConsigneeName').focus(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txtConsigneeName').focusout(function () {

                var data1 = $(this).val();
                Item_desc1(data1);


            });
            $('#txtConsigneeName').change(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txtConsigneeName').keyup(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txtConsigneeName').click(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });

            $('#txtConsigneeName').keydown(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
        });

        function Item_desc1(val) {
            $('#lbl_consignee_cnt').val('44r');
            var data1 = val;
            if (data1 == '') {
                $('#txtConsigneeName').val('');
            }
            if (data1.indexOf("--") != -1) {

                var s = data1.split('--');
                var before = s[0];
                var after = s[1];

                $('#txtConsigneeName').val(after);

                $('#hdn_Consignee').val(after);
                $('#hdn_Consignee_brSlNo').val(before);
            }
            else {
                $('#hdn_Consignee_brSlNo').val('');

            }

            if ($('#hdn_CompanyID').val() == '624') {
                var len = $('#txtConsigneeName').val();
                document.getElementById('lbl_consignee_cnt').innerHTML = len.length;
            }
        }
    </script>

    <script type="text/javascript">


        $(function () {
            $("#txtConsigneeName").autocomplete({

                source: function (request, response) {
                 
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Consignee_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtConsigneeName').validationEngine('showPrompt', 'Incorrect Consignee Name', 'error', 'topRight', true);

                                //jAlert('ConsigneeName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtConsigneeName").focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtConsigneeName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });



        $(function () {
            $('#txtBuyer').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Buyer_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            var value1 = $('#txtBuyer').val();
                            if (value1 != 'SAME AS CONSIGNEE') {
                                if (data.d == '') {
                                    jQuery('#txtBuyer').validationEngine('showPrompt', 'Incorrect Buyer Name', 'error', 'topRight', true);

                                    //jAlert('Buyer Name is Incorrect', 'INVOICE', function (r) { document.getElementById("txtBuyerName').focus(); });
                                    //return false;
                                }
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            //alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });



    </script>




<script type="text/javascript">
function clearExportReader() {
    // Clear Export Details fields
    var exporter = document.getElementById('ddl_ExporterName');
    if (exporter) {
        exporter.selectedIndex = 0;
    }

    var consignee = document.getElementById('txtConsigneeName');
    if (consignee) consignee.value = '';

    var buyer = document.getElementById('txtBuyer');
    if (buyer) buyer.value = '';

    // Clear selected PDF
    var fileInput = document.getElementById('FilePDF');
    if (fileInput) {
        try {
            fileInput.value = '';
        } catch (e) {}
    }

    var selectedFiles = document.getElementById('exportSelectedFiles');
    if (selectedFiles) selectedFiles.innerHTML = '';

    // Clear extracted item display
    var table = document.getElementById('gv_ItemPDF');
    if (table) {
        var rows = table.getElementsByTagName('tr');

        // Keep the header row and remove all data/empty rows.
        var headerRow = null;
        for (var i = 0; i < rows.length; i++) {
            if (rows[i].getElementsByTagName('th').length > 0) {
                headerRow = rows[i];
                break;
            }
        }

        for (var j = rows.length - 1; j >= 0; j--) {
            if (rows[j] !== headerRow && rows[j].parentNode) {
                rows[j].parentNode.removeChild(rows[j]);
            }
        }
    }

    var count = document.getElementById('exportItemCount');
    if (count) count.innerHTML = '0';

    // Clear status/error text shown below the extraction area.
    var status = document.querySelector('.export-status');
    if (status) status.innerHTML = '';

    var msg = document.getElementById('lblmsg');
    if (msg) msg.innerHTML = '';

    // FIX 2: Clear the "File Loading..." / status label so it doesn't linger after Clear
    var lbl = document.getElementById('lbl_loading');
    if (lbl) { lbl.innerHTML = ''; lbl.style.color = ''; }
    if (fileInput) fileInput.classList.remove('export-file-error');

    // Put focus back on Browse for the next PDF.
    if (fileInput) fileInput.focus();
}
</script>

<script type="text/javascript">
(function () {
    function updateExportItemCount() {
        var count = 0;
        var table = document.getElementById('gv_ItemPDF');

        if (table) {
            var rows = table.getElementsByTagName('tr');
            for (var i = 0; i < rows.length; i++) {
                var cells = rows[i].getElementsByTagName('td');
                if (cells.length > 0) {
                    var rowText = (rows[i].innerText || '').replace(/\s+/g, ' ').trim();
                    if (rowText && rowText.toLowerCase() !== 'no record found') {
                        count++;
                    }
                }
            }
        }

        var countElement = document.getElementById('exportItemCount');
        if (countElement) {
            countElement.innerHTML = count;
        }
    }

    function clearSelectedExportPdf() {
        var fileInput = document.getElementById('FilePDF');
        var list = document.getElementById('exportSelectedFiles');

        if (fileInput) {
            try {
                fileInput.value = '';
            } catch (e) {
                var replacement = fileInput.cloneNode(true);
                fileInput.parentNode.replaceChild(replacement, fileInput);
                bindExportFileInput(replacement);
            }
        }

        if (list) {
            list.innerHTML = '';
        }
    }

    function showSelectedExportPdf(input) {
        var list = document.getElementById('exportSelectedFiles');
        if (!list || !input || !input.files || input.files.length === 0) {
            if (list) list.innerHTML = '';
            return;
        }

        /* FilePDF is a single-file ASP.NET FileUpload, so a new Browse
           selection replaces the previous PDF rather than accumulating files. */
        var file = input.files[0];

        list.innerHTML = '';

        var chip = document.createElement('div');
        chip.className = 'export-pdf-chip';

        var name = document.createElement('span');
        name.className = 'export-pdf-chip-name';
        name.title = file.name;
        name.innerHTML = file.name;

        var remove = document.createElement('button');
        remove.type = 'button';
        remove.className = 'export-pdf-chip-remove';
        remove.title = 'Remove PDF';
        remove.setAttribute('aria-label', 'Remove PDF');
        remove.innerHTML = '&times;';
        remove.onclick = function () {
            clearSelectedExportPdf();
        };

        chip.appendChild(name);
        chip.appendChild(remove);
        list.appendChild(chip);
    }

    function bindExportFileInput(input) {
        if (!input) return;
        input.addEventListener('change', function () {
            showSelectedExportPdf(input);
        });
    }

    function initializeExportPdfReader() {
        var input = document.getElementById('FilePDF');
        bindExportFileInput(input);
        updateExportItemCount();
    }

    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', initializeExportPdfReader);
    } else {
        initializeExportPdfReader();
    }

    /* Update after ASP.NET UpdatePanel partial postbacks too. */
    if (window.Sys && Sys.WebForms && Sys.WebForms.PageRequestManager) {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            initializeExportPdfReader();
        });
    }
})();
</script>

<script type="text/javascript">
(function () {
    /* Show a visible busy state while Upload & Extract posts back. Bound on the
       capture phase so it runs before the button's own postback, and looked up
       fresh each time so it still works after Clear / re-selecting a PDF. */
    document.addEventListener('click', function (e) {
        var t = e.target;
        if (!t || t.id !== 'btnPrevData') return;

        var fileInput = document.getElementById('FilePDF');
        if (!fileInput || !fileInput.files || fileInput.files.length === 0) {
            /* No PDF chosen: block the postback and show a red prompt. */
            e.preventDefault();
            e.stopPropagation();
            var warn = document.getElementById('lbl_loading');
            if (warn) {
                warn.style.color = '#d32f2f';
                warn.style.fontWeight = '600';
                warn.innerHTML = '&#9888; Please upload a PDF file.';
            }
            fileInput.classList.add('export-file-error');

            /* Popup alert in red (jAlert from jquery.alerts, same as the rest of the app). */
            var msg = '&#9888; Please upload a PDF file.';
            if (typeof jAlert === 'function') {
                jAlert(msg, 'Export PDF Upload', function () { fileInput.focus(); });
                var box = document.getElementById('popup_container');
                if (box) box.className = (box.className + ' export-red-alert').trim();
            } else {
                alert('Please upload a PDF file.');
            }
            return false;
        }

        var overlay = document.getElementById('exportBusyOverlay');
        if (overlay) overlay.className = 'export-busy-overlay show';

        var lbl = document.getElementById('lbl_loading');
        if (lbl) { lbl.style.color = ''; lbl.innerHTML = 'File Loading...'; }
    }, true);

    /* Clear the red state once a PDF is chosen or the form is cleared. */
    document.addEventListener('change', function (e) {
        if (e.target && e.target.id === 'FilePDF') {
            e.target.classList.remove('export-file-error');
            var l = document.getElementById('lbl_loading');
            if (l) { l.style.color = ''; l.innerHTML = ''; }
        }
    }, true);

    /* Never leave the overlay up when the page is restored from cache. */
    window.addEventListener('pageshow', function () {
        var overlay = document.getElementById('exportBusyOverlay');
        if (overlay) overlay.className = 'export-busy-overlay';
    });
})();
</script>

</body>
</html>
