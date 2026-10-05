<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_PDF_Reader_AI.aspx.cs"
    Inherits="Import_PDF_Reader_AI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import PDF Upload - AI </title>
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
    <%--<script src="../js/checkboxJScript.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_Item.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <%--<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"
        rel="stylesheet" />--%>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js" type="text/javascript"></script>--%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <script type="text/javascript">

        document.addEventListener("DOMContentLoaded", function () {
            var chk = document.getElementById('chk_Master');
            var hdn = document.getElementById('hdn_PDF_Master');

            if (chk && hdn) {
                hdn.value = chk.checked ? "S" : "M";
                chk.addEventListener("change", function () {
                    hdn.value = chk.checked ? "S" : "M";
                });
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Intercept DELETE button click with confirm
            $('[id*="btnDeleteSelected"]').click(function (e) {
                if (!confirm('Delete selected rows?')) {
                    e.preventDefault();
                    return false;
                }
                return true; // allow normal postback
            });
        });
    </script>
    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            height: 5em;
            line-height: 0em;
            text-align: left;
            max-width: 50px;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            height: 5em;
            line-height: 0em;
            text-align: left;
            max-width: 50px;
        }
    </style>
    <style type="text/css">
        .multiselect-container
        {
            max-height: 200px;
            overflow-y: auto;
            height: 250px;
        }
        .cth-error
        {
            position: absolute;
            background: #cc0000;
            color: white;
            font-size: 10px;
            padding: 2px 6px;
            border-radius: 3px;
            white-space: nowrap;
            z-index: 99999;
            pointer-events: none;
            margin-left: 65px;
        }
        /* Keep grid rows fixed height */.grid-view tr td
        {
            vertical-align: middle;
            padding: 1px 2px;
            white-space: nowrap;
        }
        /* Keep all grid textboxes same height */.grid-view input[type='text']
        {
            height: 22px !important;
            box-sizing: border-box;
        }
    </style>
    <style type="text/css">
        .txtbox_none_Mid_transac_item_other_rmarks_new1_LC
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            margin-top: 2px;
            width: 385px;
            max-width: 385px;
            height: 350px;
            max-height: 350px;
            border: #c0e4f2 solid thin;
            -moz-border-radius-topleft: 5px;
            -moz-border-radius-topright: 5px;
            -moz-border-radius-bottomleft: 5px;
            -moz-border-radius-bottomright: 5px;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -webkit-border-bottom-right-radius: 5px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            overflow: auto;
        }
    </style>
    <style type="text/css">
        .grid-view
        {
            display: block;
            max-height: 300px; /* adjust scroll area */
            overflow-y: auto;
            border-collapse: collapse;
            width: 100%;
        }
        
        .grid-view th
        {
            position: sticky;
            top: 0;
            background: maroon; /* solid orange */
            color: white; /* optional: white text for contrast */
            z-index: 10;
        }
        .ui-autocomplete
        {
            z-index: 9999 !important; /* HIGH priority for dropdown */
        }
    </style>
    <style type="text/css">
        .btn-filter
        {
            background-color: deepskyblue;
            border: 1px solid aqua;
        }
        
        .btn-filter:hover
        {
            background-color: steelblue;
            color: white;
        }
        .btn-filter1
        {
            background-color: lightseagreen;
            border: 1px solid aqua;
        }
        
        .btn-filter1:hover
        {
            background-color: steelblue;
            color: white;
        }
        
        .btn-filter2
        {
            background-color: #196666;
            border: 1px solid #196666;
            color: #196666;
        }
        
        .btn-filter2:hover
        {
            background-color: steelblue;
            color: white;
        }
    </style>
    <style type="text/css">
        .note-label
        {
            display: block;
            background-color: #fff3cd; /* soft yellow background */
            color: #856404; /* brownish text for readability */
            border: 1px solid #ffeeba; /* subtle border */
            padding: 10px 12px;
            border-radius: 6px; /* rounded corners */
            font-family: Segoe UI, Arial, sans-serif;
            font-size: 12px;
            font-weight: 513;
            height: 48px;
            margin-top: -7px;
            font-weight: bold;
        }
        
        .note-label::before
        {
            content: "&#9888; "; /* warning icon before text */
            font-size: 10px;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {

            var icegateid = document.getElementById("hdn_ICEGATE_ID_List").value;

            var Notn = icegateid.split(', ').map(String);

            if (icegateid != '') {
                $(".autocomplete").autocomplete({
                    source: Notn,
                    minLength: 0,
                    scroll: true
                }).focus(function () {
                    $(this).autocomplete("search", "");
                });
            }

        });

    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#btn_Refresh').click(function () {
                var jobno = document.getElementById("hdn_jobno").value;

                window.close();

                if (jobno != '') {
                    NewWindow1('../IMP_Single_Window/Imp_SupDocs_Bulk.aspx?JOBID=' + jobno + '', 'List', '1100', '1024', 'yes');
                }
                else {
                    alert('Select a Job');
                }
            });

        });
    </script>
    <style>
        .btnhide
        {
            visibility: hidden;
        }
    </style>
    <script src="../js/js_bootstrap/jquery.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap-multiselect.js" type="text/javascript"></script>

<script type="text/javascript">

    $(function () {
        $('[id*=ListBox_INVSlno]').multiselect({
            includeSelectAllOption: true
        });
    });

    $(function () {
        $('[id*=ListBox_ItemSlno]').multiselect({
            includeSelectAllOption: true,
            onChange: function (option, checked) {
                var val = $(option).val();
                if (!val || val.indexOf('~') === -1) return;

                var cth = val.split('~')[1];
                var $select = $('[id*=ListBox_ItemSlno]');

                $select.find('option').each(function () {
                    var v = $(this).val();
                    if (v && v.indexOf('~') !== -1 && v.split('~')[1] === cth) {
                        this.selected = checked;
                    }
                });

                $select.multiselect('refresh');
            }
        });
    });

</script>




    <script type="text/javascript">

        function Check_Click(objRef) {
            var row = objRef.parentNode.parentNode;

            var GridView = row.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                var headerCheckBox = inputList[0];
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                            row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }

    </script>
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
        function HideModalPopup_INV() {
            $find("MP_INV_DETAILS").hide();
            return false;
        }
        function HideModalPopup_U() {
            $find("MP_U").hide();
            return false;
        }
    </script>
    <script type="text/javascript">
        function RefreshParent() {
            try {
                if (window.parent && typeof window.parent.closeExistingPopup === 'function') {
                    window.parent.closeExistingPopup();
                } else if (window.parent && window.parent.adcodewindow && typeof window.parent.adcodewindow.hide === 'function') {
                    window.parent.adcodewindow.hide();
                } else {
                    window.parent.location.reload();
                }
            } catch (e) { }
            try {
                PageMethods.LogCloseButtonClick(function () { }, function () { });
            } catch (e) { }
        }
        
    </script>
    <script language="jscript" type="text/javascript">
        $(document).ready(function () {
            $('#btnPrevData').click(function () {
                $('#lbl_loading').html('<span style="color: orange; font-weight: bold;">&#9203; File is being processed... Please wait.</span>');
            });            

            try {
                var isReload = false;
                if (window.performance && performance.getEntriesByType && performance.getEntriesByType("navigation").length) {
                    isReload = performance.getEntriesByType("navigation")[0].type === "reload";
                } else if (window.performance && performance.navigation) {
                    isReload = performance.navigation.type === 1; // TYPE_RELOAD
                }
                if (isReload) {
                    PageMethods.LogPageRefreshAfterPreview();
                }
            } catch (e) { }
        });
    </script>
    <script type="text/javascript">
        function showChecklistPopup() {
            document.getElementById("popupOverlay").style.display = "block";
            document.getElementById("popupChecklist").style.display = "block";
        }

        function closePopup() {
            document.getElementById("popupOverlay").style.display = "none";
            document.getElementById("popupChecklist").style.display = "none";
        }
    </script>
</head>
<style type="text/css">
    /* &#9472;&#9472; Pager navigation &#8212; centered, clean &#9472;&#9472; */
    .pagerrow td
    {
        text-align: center !important;
        padding: 4px 0 !important;
    }
    .pagerrow td a, .pagerrow td span
    {
        display: inline-block !important;
        padding: 4px 12px !important;
        margin: 2px 4px !important;
        background: #4a6fa5 !important;
        color: #fff !important;
        border-radius: 4px !important;
        font-size: 11px !important;
        font-weight: bold !important;
        text-decoration: none !important;
        border: 1px solid #2d4e8a !important;
        cursor: pointer !important;
        white-space: nowrap !important;
    }
    .pagerrow td span
    {
        background: #1a3a6b !important;
        cursor: default !important;
    }
    .pagerrow td a:hover
    {
        background: #2d5a9e !important;
    }
    /* Prevent layout shift from Prev/Next buttons */
    #btnPrevPage, #btnNextPage
    {
        visibility: visible !important;
    }
    #btnPrevPage[disabled], #btnNextPage[disabled]
    {
        opacity: 0.35 !important;
        cursor: not-allowed !important;
    }
</style>
<style type="text/css">
    .pagerrow
    {
        display: none !important;
    }
    
    .nav-strip
    {
        display: flex;
        align-items: center;
        gap: 6px;
        flex-wrap: nowrap;
    }
    .nav-btn
    {
        background: #4a6fa5;
        color: #fff;
        border: 1px solid #2d4e8a;
        border-radius: 4px;
        padding: 4px 10px;
        font-size: 11px;
        font-weight: bold;
        cursor: pointer;
        height: 28px;
        white-space: nowrap;
    }
    .nav-btn:hover
    {
        background: #2d5a9e;
    }
    .nav-btn:disabled, input[type=submit].nav-btn:disabled
    {
        opacity: 0.35;
        cursor: not-allowed;
    }
    #lblPageInfo
    {
        font-weight: bold;
        font-size: 12px;
        color: navy;
        white-space: nowrap;
        min-width: 160px;
        text-align: center;
    }
    
    /* &#9472;&#9472; FIX #1: Prevent horizontal scroll / screen shift &#9472;&#9472; */
    body
    {
        overflow-x: hidden !important; /* never let the page shift right */
    }
    #tag_transac_lft_Item_maindet_Grid_area
    {
        overflow-x: auto; /* horizontal scroll stays INSIDE the grid div */
        overflow-y: auto;
        max-width: 100%;
    }
    .nav-strip
    {
        display: inline-flex;
        align-items: center;
        gap: 4px;
        background: #f0f4ff;
        border: 1px solid #c5cfe8;
        border-radius: 6px;
        padding: 4px 6px;
        margin-left: 10px;
    }
    .nav-btn
    {
        background: #ffffff;
        color: #1a3a6b;
        border: 1px solid #c5cfe8;
        border-radius: 4px;
        padding: 0 10px;
        font-size: 12px;
        font-weight: bold;
        cursor: pointer;
        height: 26px;
        white-space: nowrap;
        transition: background 0.15s, color 0.15s;
        line-height: 26px;
    }
    .nav-btn:hover
    {
        background: #4a6fa5;
        color: #ffffff;
        border-color: #2d4e8a;
    }
    .nav-btn:disabled, input[type=submit].nav-btn:disabled
    {
        opacity: 0.35;
        cursor: not-allowed;
        background: #e8ecf5;
        color: #7a8aaa;
    }
    #lblPageInfo
    {
        font-weight: bold;
        font-size: 12px;
        color: #1a3a6b;
        background: #dce6f7;
        border: 1px solid #b0c4e8;
        border-radius: 4px;
        padding: 0 10px;
        height: 26px;
        line-height: 26px;
        white-space: nowrap;
        min-width: 140px;
        text-align: center;
        display: inline-block;
    }
</style>
      <style type="text/css">
    .icon-wrapper.pdf-ai {
    width: 50px;
    height: 25px;
    padding: 0;
    margin: 0;
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;
}

.icon-wrapper.pdf-ai img {
    width: 36px;
    height: 85px;
    object-fit: contain;
    display: block;
    margin-top: -7px;
}
 </style>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <%--   <img src="<%= ResolveUrl("~/images/icons/AI_6.jpeg") %>" alt="PDF Reader Icon" />--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Billing" style="height: 30px; width: 1193px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 600px; margin-top: 6px;">
                     <div class="icon-wrapper pdf-ai">
                   <img src="../images/icons/OCR/gen_remove.png" alt="PDF AI" />
                     </div>
                        <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                            <div id="txtcon-m_Exchange" style="width: 250px;">
                                <asp:Label ID="Label1" runat="server" Text="IMPORT - PDF UPLOAD " Height="250px" Width="250px"
                                    Style="margin-top: -262px; font-size: larger; margin-left :56px ;"></asp:Label>
                            </div>
                        </div>
                         <div id="tag_transac_lft_in2" style="margin-top: -10px;">
                            <div id="txtcon-m_Exchange" style="width: 50px;">
                                <asp:ImageButton ID="ImageButton1" UseSubmitBehavior="false" runat="server" ImageUrl="~/images/icons/arrow.png"
                                    ToolTip="Refresh" Height="22px" Width="25px" OnClick="btn_Refresh_Click" Style="margin-top: -27px; margin-left :16px;" />
                            </div>
                              <div id="verslic" style="margin-top: -31px;">
                        </div>
                        </div>
                      
                        <div style="font-weight: bold; color: black; display: flex; align-items: center; gap: 5px;">
        <asp:Label ID="lbl_LiveExtractionTimer" style="color: black; font-weight: bold; margin-top: -16px; margin-left: 465px;"
            runat="server" ClientIDMode="Static"
            Text="" Font-Bold="true" ForeColor="DeepPink">
        </asp:Label>
    </div>

                       
                     
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <%-- Single flex row: Job No | Tr. Mode | Excel Button --%>
                    <div style="display: flex; align-items: center; gap: 10px; margin-left: 20px;">
                        <%-- Job No --%>
                        <div style="font-weight: bold; color: Blue; display: flex; align-items: center; gap: 5px;">
                            Job No
                            <asp:TextBox ID="txtjobPS" runat="server" Font-Bold="true" MaxLength="10" Font-Size="12px"
                                CssClass="txtbox_none_Mid_transac_code" Width="130px" ReadOnly="True" TabIndex="1"
                                Height="20px" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <%-- Tr. Mode --%>
                        <div style="font-weight: bold; color: Blue; display: flex; align-items: center; gap: 5px;">
                            Tr. Mode
                            <asp:DropDownList ID="ddlTransportMode" runat="server" Font-Bold="true" Font-Size="12px"
                                CssClass="txtbox_none_Mid_transac_code" Width="65px" TabIndex="2" Height="20px"
                                ClientIDMode="Static">
                                <%-- <asp:ListItem Text="-- Select --" Value="" />--%>
                                <asp:ListItem Text="Air" Value="Air" />
                                <asp:ListItem Text="Sea" Value="Sea" />
                                <asp:ListItem Text="Land" Value="Land" />
                            </asp:DropDownList>
                        </div>
                        <%-- Excel Download Button (stays in same row, no layout shift when visible/hidden) --%>
                        <div style="display: flex; align-items: center;">
                            <asp:ImageButton ID="ExcelDwnl" runat="server" ImageUrl="~/images/icons/New-Excel.png"
                                Height="35px" Width="53px" style="margin-top: -5px; margin-left: 12px;" Visible="false" OnClick="ExcelDwnl_Click" />
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new" style="margin-top: -5px;">
                        <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                </div>
            </div>
            <div id="tag_srcinner1" style="height: 40px; width: 1253px;">
                <div id="tag_label_transaction_Src" style="width: 60px; font-weight: bold;">
                    CLIENT
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 300px;">
                    <asp:DropDownList ID="ddl_ImporterName" runat="server" TabIndex="1" Width="250px"
                        Height="22px">
                    </asp:DropDownList>
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');openimpclientmasternew(); return false"
                        runat="server" id="href_Client_YN_New" style="font-weight: bold;">New</a>
                </div>
                <div id="tag_label_transact_Src" style="width: 130px; font-weight: bold;">
                    UPLOAD PDF FILE</div>
                <div id="txtcon-m_src" style="width: 350px;">
                    <input type="file" id="FilePDF" runat="server" multiple="multiple" style="color: Blue;
                        font-weight: bold;" />
                </div>
                <div id="txtcon-m_Exchange" style="width: 120px;">
                    <asp:Button ID="btnPrevData" Style="margin-top: -3px; margin-left: -28px" Text="PREVIEW"
                        Width="100px" CssClass="autowidmovebut" runat="server" UseSubmitBehavior="false"
                        OnClick="btnPrevData_Click" />
                </div>
                <div id="txtcon-m_src" style="width: 260px;">
                    <asp:Label ID="lbl_loading" runat="server" ForeColor="Blue" Style="margin-left: -24px;
                        margin-top: -12px;" Width="250px"></asp:Label>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans" style="width: 1235px; height: 2px; margin-left: -40px;">
            </div>
            <div id="tag_srcinner1" style="width: 1260px; height: 25px;">
                <div id="txt_container_Transact_Main_l" style="width: 184px;">
                    <div id="tag_label_transaction_Src" style="width: 106px; font-weight: bold;">
                        Importer Name
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 110px;">
                    <div id="tag_label_transaction_Src" style="width: 166px; font-weight: bold;">
                        Supplier Name
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 110px;">
                    <div id="tag_label_transaction_Src" style="width: 106px; font-weight: bold;">
                        Invoice No
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 110px;">
                    <div id="tag_label_transaction_Src" style="width: 136px; font-weight: bold;">
                        Invoice Date
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 110px;">
                    <div id="tag_label_transaction_Src" style="width: 110px; font-weight: bold;">
                        Invoice Value
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 75px;">
                    <div id="tag_label_transaction_Src" style="width: 65px; font-weight: bold;">
                        Ad Code
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 115px;">
                    <div id="tag_label_transaction_Src" style="width: 110px; font-weight: bold;">
                        Country Of Orgin
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 130px;">
                    <div id="tag_label_transaction_Src" style="width: 125px; font-weight: bold;">
                        Port Of Orgin
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 70px;">
                    <div id="tag_label_transaction_Src" style="width: 60px; font-weight: bold;">
                        Terms
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 70px;">
                    <div id="tag_label_transaction_Src" style="width: 60px; font-weight: bold;">
                        Currency
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 100px;">
                    <div id="tag_label_transaction_Src" style="width: 100px; font-weight: bold;">
                        Filing Status
                    </div>
                </div>
            </div>
            <div id="tag_srcinner1" style="height: 25px;">
                <div id="txtcon-m_transaction_Supp_code" style="width: 174px;">
                    <asp:TextBox ID="txtImporterName" Width="174px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="tag_srcinner1" style="width: 100px;">
                    <asp:TextBox ID="txtSupplier" Width="100px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="tag_srcinner1" style="width: 110px;">
                    <asp:TextBox ID="txtInvNo" Width="100px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 110px;">
                    <asp:TextBox ID="txtInvDate" Width="100px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 110px;">
                    <asp:TextBox ID="txtInvValue" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        Height="20px" Width="100px" TabIndex="1"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="height: 20px; width: 75px;">
                    <asp:DropDownList ID="ddlAdCode" runat="server" CssClass="listtxt_transac_src1" TabIndex="1"
                        Width="70px" Height="20px">
                    </asp:DropDownList>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="height: 20px; width: 115px;">
                    <asp:TextBox ID="txtCountryOfOrigin" runat="server" MaxLength="50" onkeyup="ChangeCase(this);"
                        Width="105px" Font-Size="12px" onblur="ChangeCase(this);updateTextbox();" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                        Height="20px" ClientIDMode="Static" TabIndex="1" onchange="updateTextbox()" onkeypress="return char(event); return isNaN(event.key); TextBoxes(this);"
                        onfocus="updateTextbox();" onkeydown="updateTextbox();"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="height: 20px; width: 130px;">
                    <asp:TextBox ID="txtPortOfOrigin" runat="server" MaxLength="50" onkeypress="return char(event),TextBoxes(this);"
                        onblur="ChangeCase(this);updateTextbox2();" onkeyup="ChangeCase(this);" onfocus="updateTextbox2();"
                        onkeydown="var data = val;Port_origin(this);" onchange="updateTextbox2();" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                        ClientIDMode="Static" TabIndex="1" Height="20px" Width="120px" Font-Size="12px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 70px;">
                    <asp:DropDownList ID="ddlTerms" CssClass="validate[required] listtxt_transac_FCL"
                        runat="server" TabIndex="1" Width="60px" Font-Size="12px" Height="20px">
                    </asp:DropDownList>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 70px;">
                    <asp:TextBox ID="txtCurrency" Width="60px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 100px;">
                    <asp:DropDownList ID="ddlFilingStatus" runat="server" CssClass="listtxt_transac_src1"
                        TabIndex="1" Height="20px" Width="90px">
                    </asp:DropDownList>
                </div>
            </div>
            <div id="tag_srcinner1" style="height: 115px;">
                <fieldset style="border: Black; border-style: double; margin-left: 0px; margin-top: 10px;
                    width: 1175px; height: 173px;">
                    <legend style="border: Black; border-collapse: collapse; width: 245px; font-weight: bold;
                        background-color: Scrollbar; color: Teal; height: 36px;">Item Wise / CTH Wise &nbsp
                        <asp:DropDownList ID="ddl_Select_ItemRITC" runat="server" CssClass="listtxt_transac_exp_item_yn"
                            TabIndex="1" Height="22px" Width="60px" OnSelectedIndexChanged="ddl_Select_ItemRITC_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem Text="ITEM" Value="0"></asp:ListItem>
                            <asp:ListItem Text="CTH" Value="1"></asp:ListItem>
                            <asp:ListItem Text="EMPTY CTH" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </legend><legend style="border: Black; border-collapse: collapse; width: 270px; font-weight: bold;
                        background-color: Scrollbar; color: Teal; height: 30px; margin-left: 885px; margin-top: -30px;">
                        &nbsp Bulk Update Field for All Records </legend><legend style="border: Black; border-collapse: collapse;
                            width: 195px; font-weight: bold; margin-left: 292px; margin-top: -34px; background-color: Scrollbar;
                            color: crimson; height: 34px;">
                            <asp:RadioButtonList ID="Rd_SInv_MInv" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="true" OnSelectedIndexChanged="Rd_SInv_MInv_SelectedIndexChanged"
                                Style="width: 177px; margin-left: 5px; margin-top: -2px; font-size: 12px;">
                                <asp:ListItem Text="Single INV" Value="S" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Multiple INV" Value="M"></asp:ListItem>
                            </asp:RadioButtonList>
                        </legend><legend style="border: Black; border-collapse: collapse; width: 66px; font-weight: bold;
                            margin-left: 515px; margin-top: -34px; background-color: Scrollbar; color: crimson;
                            height: 34px;">
                            <asp:CheckBox ID="chk_Master" runat="server" Text=" PDF" AutoPostBack="false" Style="margin-left: 5px;
                                margin-top: -2px; font-size: 12px;" />
                        </legend>
                    <div id="tag_srcinner1" style="height: 25px; width: 1170px; margin-top: 6px">
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 140px; font-weight: bold;">
                            Inv No
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px; font-weight: bold;">
                            Description
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 70px; font-weight: bold;">
                            QTY Code
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            Scheme Code
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px; font-weight: bold;">
                            Sche Notn
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px; font-weight: bold;">
                            Sche S.No
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px; font-weight: bold;">
                            CTH
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px; font-weight: bold;">
                            Basic Notn
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px; font-weight: bold;">
                            Basic S.No
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px; font-weight: bold;">
                            Basic Rate
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            Manufacturer
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 110px; font-weight: bold;">
                            End Use
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 100px; margin-top: 15px;
                            font-weight: bold;">
                            <asp:Button ID="btnAllItem" runat="server" Text="Load Item" Width="90px" UseSubmitBehavior="false"
                                Height="24px" ForeColor="White" OnClick="btnAll_Item_Click" Style="font-weight: bold;"
                                CssClass="btn-filter2" />
                        </div>
                    </div>
                    <div id="tag_srcinner1" style="height: 30px; width: 1170px;">
                        <div id="txtcon-m_transaction_item_maindet" style="width: 140px;">
                            <asp:ListBox ID="ListBox_INVSlno" SelectionMode="Multiple" Height="25px" Width="60px"
                                ViewStateMode="Enabled" runat="server" OnSelectedIndexChanged="ListBox_INVSlno_SelectedIndexChanged"
                                AutoPostBack="true"></asp:ListBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px;">
                            <asp:TextBox ID="txtDescription" runat="server" Width="65px" ClientIDMode="Static"
                                Height="30px" CssClass="listtxt_transac_Item_Schemecode" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 70px;">
                            <asp:TextBox ID="txt_QtyCode" runat="server" Width="65px" ClientIDMode="Static" Height="30px"
                                CssClass="listtxt_transac_Item_Schemecode" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                            <asp:DropDownList ID="ddlSchemeCode" runat="server" CssClass="listtxt_transac_Item_Schemecode"
                                TabIndex="1" OnSelectedIndexChanged="ddlSchemeCode_SelectedIndexChanged" AutoPostBack="true"
                                Height="30px" Width="70px">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px;">
                            <asp:DropDownList ID="ddlScheme_NOTN" runat="server" OnSelectedIndexChanged="ddlScheme_NOTN_SelectedIndexChanged"
                                AutoPostBack="true" CssClass="listtxt_transac_Item_Schemecode" TabIndex="1" Height="30px"
                                Width="65px">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px;">
                            <asp:DropDownList ID="ddlScheme_NOTN_SL" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                TabIndex="1" Height="30px" Width="65px">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px;">
                            <asp:TextBox ID="txtCTH" runat="server" MaxLength="8" Height="30px" Width="65px"
                                Font-Size="12px" oninput="validateNumericInput(this);" CssClass="txt-cth txtbox_none_Mid_transac_Supp_Name txt-cth"
                                onblur="extractNumber(this,2,false);" onkeypress="return isNumericKey(event);"
                                onkeyup="autotab(this);" ClientIDMode="Static" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px;">
                            <asp:TextBox ID="txtBasicNotn" Width="65px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                                oninput="validateNumericInput(this);" ClientIDMode="Static" TabIndex="1" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px;">
                            <asp:TextBox ID="txtBasicSLNO" Width="65px" Font-Size="12px" runat="server" MaxLength="10"
                                onkeypress="return NOTNSLNO(event)" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                TabIndex="1" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 80px;">
                            <asp:TextBox ID="txtBasicRate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                Width="65px" Font-Size="12px" oninput="validateNumericInput(this);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small"
                                ClientIDMode="Static" Height="30px" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                            <asp:TextBox ID="txtManufacturer" MaxLength="35" runat="server" Text="" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="1" ClientIDMode="Static" onkeypress="return numcharspl1(event)" Height="30px"
                                Width="65px" Font-Size="12px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 110px;">
                            <asp:TextBox ID="txtEnduseItem" runat="server" MaxLength="20" ClientIDMode="Static"
                                Text="" CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="1" onkeypress="return numcharspl1(event)"
                                Height="30px" Width="60px" Font-Size="12px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;
                            margin-top: 30px; font-weight: bold;">
                            <asp:Button ID="btnLoad" runat="server" Text="Apply Filter" Width="90px" UseSubmitBehavior="false"
                                Height="26px" ForeColor="White" OnClick="btnLoad_Click" Style="font-weight: bold;"
                                CssClass="btn-filter" />
                        </div>
                    </div>
                    <div id="tag_srcinner1" style="height: 25px; width: 1060px; margin-top: 10px">
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 140px; font-weight: bold;">
                            Item
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            Item Country
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            SWS Notn
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            SWS Sl.No
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            SWS Rate
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            AIDC Notn
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            AIDC SlNo
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            AIDC Rate
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            IGST Notn
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                            IGST Sl.No
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 110px; font-weight: bold;">
                            IGST Rate
                        </div>
                    </div>
                    <div id="tag_srcinner1" style="height: 30px; width: 1170px;">
                        <div id="txtcon-m_transaction_item_maindet" style="width: 140px;">
                            <asp:ListBox ID="ListBox_ItemSlno" SelectionMode="Multiple" Height="25px" Width="60px"
                                ViewStateMode="Enabled" runat="server"></asp:ListBox>
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 90px;">
                            <asp:TextBox ID="txtitemCountyof_orgin" Width="85px" Font-Size="12px" runat="server"
                                onkeypress="return char(event); return isNaN(event.key); TextBoxes(this);" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                                ClientIDMode="Static" TabIndex="1" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                            <asp:TextBox ID="txtSW_Noti" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                oninput="validateNumericInput(this);" CssClass="txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" Width="85px" Font-Size="12px" Height="30px" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                            <asp:TextBox ID="txtSW_Slno" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" Width="85px"
                                Font-Size="12px" TabIndex="1" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                            <asp:TextBox ID="txt_SW_Rate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                oninput="validateNumericInput(this);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                ClientIDMode="Static" TabIndex="1" Width="85px" Font-Size="12px" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                            <asp:TextBox ID="txt_AIDC_CessNoti" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                oninput="validateNumericInput(this);" CssClass="txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" Width="85px" Font-Size="12px" Height="30px" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                            <asp:TextBox ID="txt_AIDC_CessSlno" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="1"
                                Width="85px" Font-Size="12px" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                            <asp:TextBox ID="txt_AIDC_CessRate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                oninput="validateNumericInput(this);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                ClientIDMode="Static" TabIndex="1" Height="30px" Width="85px" Font-Size="12px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                            <asp:TextBox ID="txt_IGST_Noti" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                oninput="validateNumericInput(this);" CssClass="txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" Width="85px" Font-Size="12px" TabIndex="1" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                            <asp:TextBox ID="txt_IGST_SlNo" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" Width="85px"
                                Font-Size="12px" TabIndex="1" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 110px;">
                            <asp:TextBox ID="txt_IGST_Rate" Width="85px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                                oninput="validateNumericInput(this);" ClientIDMode="Static" TabIndex="1" Height="30px"
                                onblur="extractNumber(this,6,false);"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 100px; font-weight: bold;">
                            <asp:Button ID="btn_bulk_Update_All" runat="server" Text="Apply to All" UseSubmitBehavior="false"
                                Width="90px" Height="26px" ForeColor="White" OnClick="btn_bulk_Update_All_Click"
                                Style="font-weight: bold;" CssClass="btn-filter1" />
                        </div>
                    </div>
                </fieldset>
            </div>
            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 302px;
                width: 1170px; margin-top: 72px; margin-left: 13px;">
                <asp:GridView ID="gv_ItemPDF" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="true"
                    HorizontalAlign="Left" OnRowCreated="gv_ItemPDF_RowCreated" OnRowDataBound="gv_ItemPDF_RowDataBound"
                    ShowHeaderWhenEmpty="True" PageSize="100" OnPageIndexChanging="gv_ItemPDF_PageIndexChanging">
                    <PagerStyle CssClass="pagerrow" HorizontalAlign="Center" BackColor="#f0f4ff" />
                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="&#9664;&#9664; First"
                        PreviousPageText="&#9664; Prev" NextPageText="Next &#9654;" LastPageText="Last &#9654;&#9654;" />
                    <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                    <SelectedRowStyle Font-Bold="true" />
                    <HeaderStyle BorderWidth="1px" BorderColor="Gray" />
                    <Columns>
                        <asp:TemplateField HeaderText=" " HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="70px">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_Delete" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Inv Sl.No" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="70px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtInvSlNo" runat="server" Text='<%#Eval("InvoiceSlNo") %>' MaxLength="3"
                                    Enabled="false" Width="70px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Sl.No" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="70px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtItemSlNo" runat="server" Text='<%#Eval("ItemSlNo") %>' MaxLength="3"
                                    Enabled="false" Width="70px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Description *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="285px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtItemDesc" runat="server" Text='<%#Eval("ITEM_DESC") %>' TabIndex="1"
                                    ClientIDMode="Static" Width="285px" Height="25px" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Qty *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtItemQty" runat="server" Text='<%#Eval("Quantity") %>' MaxLength="10"
                                    Enabled="false" Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Unit Price *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtItemUnitPrice" runat="server" Text='<%#Eval("Rate") %>' Enabled="false"
                                    MaxLength="10" Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Amt *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtItemAmt" runat="server" Text='<%#Eval("Amount") %>' MaxLength="10"
                                    Enabled="false" Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item QTY Code *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQTYCode" runat="server" Text='<%#Eval("QTYCode") %>' MaxLength="3"
                                    ClientIDMode="Static" Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CTH *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="120px">
                            <ItemTemplate>
                                <div style="display: inline-flex; align-items: center; gap: 2px; white-space: nowrap;">
                                    <asp:TextBox ID="txt_CTH" runat="server" CssClass="txt-cth txtbox_none_Mid_transac_Supp_Name"
                                        Onkeypress="return num5(event)" Width="78px" Height="22px" MaxLength="8" TabIndex="1"
                                        Text='<%#Eval("HSCode") %>' Style="font-size: 11px;"></asp:TextBox>
                                    <button type="button" title="Load All CTH from Master" style="font-size: 10px; padding: 1px 3px;
                                        cursor: pointer; background: #17a2b8; color: white; border: none; border-radius: 3px;
                                        height: 22px; width: 20px; line-height: 1; flex-shrink: 0;" onclick="loadAllCTH(this); return false;">
                                        &#128269;</button>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Scheme Code *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="125px">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_SchemeCode" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                    DataTextField="SCHEME_CODE" DataValueField="SCHEME_CODE" TabIndex="1" Height="25px"
                                    Width="125px" AutoPostBack="true" OnSelectedIndexChanged="ddl_SchemeCode_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Scheme Notn" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="125px">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_Scheme_NOTN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                    TabIndex="1" Height="25px" Width="125px" AutoPostBack="true">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Scheme Sl.No" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_Scheme_NOTN_SL" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                    Width="100px" TabIndex="1" Height="25px" AutoPostBack="true">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Basic Notn" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtBasicNoti" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("Basic_Noti") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    onkeyup="autotab(this);"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Basic Sl.No" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtBasicSlno" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("Basic_Slno") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    onkeyup="autotab(this);"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Basic Rate" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Basic_Rate" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("Basic_Rate") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Info MSR" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox ID="txtinfoMSR" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Enabled="false" Text='<%#Eval("info_MSR") %>' ClientIDMode="Static" Height="25px"
                                    CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Info UQC" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox ID="txtinfo_UQC" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("info_UQC") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Manufacturer*" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Manufacturer" runat="server" MaxLength="35" TabIndex="1" Width="100px"
                                    Text='<%#Eval("MANUFACTURER") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Use*" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtEndUseOfItems" runat="server" MaxLength="20" TabIndex="1" Width="100px"
                                    Text='<%#Eval("END_USE_OF_ITEM") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Country*" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtitemCountyoforgin" runat="server" MaxLength="10" TabIndex="1"
                                    Width="100px" Text='<%#Eval("itemCountyof_orgin") %>' ClientIDMode="Static" Height="25px"
                                    CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SWS Notn" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_SW_Noti" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("SW_Noti") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SWS Sl.No" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_SW_Slno" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("SW_Slno") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SWS Rate" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSW_Rate" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("SW_Rate") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AIDC Notn *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_AIDCCessNoti" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("AIDC_CessNoti") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name txt-aidc-noti"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AIDC Sl.No *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_AIDCCessSlno" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("AIDC_CessSlno") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name txt-aidc-slno"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AIDC Rate *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_AIDCCessRate" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("AIDC_CessRate") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name txt-aidc-rate"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IGST Notn *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="105px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_IGSTNoti" runat="server" MaxLength="10" TabIndex="1" Width="105px"
                                    Text='<%#Eval("IGST_Noti") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name txt-igst-noti"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IGST Sl.No *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_IGSTSlNo" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("IGST_SlNo") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name txt-igst-slno"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IGST Rate *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_IGSTRate" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Text='<%#Eval("IGST_Rate") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name txt-igst-rate"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part No" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="100px" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Part_No" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                    Enabled="false" Text='<%#Eval("PartNo") %>' ClientIDMode="Static" Height="25px"
                                    CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="innerbox_MidMain_Trans" style="width: 1235px; height: 3px; margin-top: -33px;
                margin-left: -40px;">
            </div>
            <div id="tag_transac_lft_in2" style="margin-top: 7px;">
                <%-- Note label --%>
                <div id="txtcon-m_Exchange" style="width: 455px;">
                    <asp:Label ID="Label2" runat="server" Text="Note: If Some Item descriptions (shown in red) have special characters. Please remove or replace them before uploading to avoid errors."
                        CssClass="note-label" Style="display: none;"></asp:Label>
                </div>
                <%-- Delete button --%>
                <div id="txtcon-m_Exchange" style="width: 120px;">
                    <asp:Button ID="btnDeleteSelected" runat="server" Width="110px" Height="30px" Text="DELETE ROWS"
                        CssClass="autowidmovebut" OnClick="btnDeleteSelected_Click" Visible="false" />
                </div>
                <%-- Upload button --%>
                <div id="txtcon-m_Exchange" style="width: 100px;">
                    <asp:Button ID="btnupload" runat="server" Width="100px" Height="30px" Text="UPLOAD"
                        CssClass="autowidmovebut" OnClientClick="return validateBeforeUpload();" OnClick="btnupload_Click"
                        Visible="false" />
                </div>
                <%-- FIX #4: First / Prev / page-info / Next / Last &#8212; all in one strip --%>
                <div class="nav-strip" style="margin-left: 64px;">
                    <asp:Button ID="btnFirstPage" runat="server" Text="&#9664;&#9664; First" CssClass="nav-btn autowidmovebut"
                        Width="65px" Height="28px" OnClick="btnFirstPage_Click" Visible="false" UseSubmitBehavior="false"
                        CausesValidation="false" />
                    <asp:Button ID="btnPrevPage" runat="server" Text="&#9664; Prev" CssClass="nav-btn autowidmovebut"
                        Width="60px" Height="28px" OnClick="btnPrevPage_Click" Visible="false" UseSubmitBehavior="false"
                        CausesValidation="false" />
                    <asp:Label ID="lblPageInfo" runat="server" ForeColor="Navy" Visible="false" />
                    <asp:Button ID="btnNextPage" runat="server" Text="Next &#9654;" CssClass="nav-btn autowidmovebut"
                        Width="60px" Height="28px" OnClick="btnNextPage_Click" Visible="false" UseSubmitBehavior="false"
                        CausesValidation="false" />
                    <asp:Button ID="btnLastPage" runat="server" Text="Last &#9654;&#9654;" CssClass="nav-btn autowidmovebut"
                        Width="65px" Height="28px" OnClick="btnLastPage_Click" Visible="false" UseSubmitBehavior="false"
                        CausesValidation="false" />
                </div>
                <%-- Status message --%>
                <div id="txtcon-m_Exchange" style="width: 200px;">
                    <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                </div>
            </div>
            <div id="myModal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog" style="width: 300px;">
                    <!-- Small size -->
                    <div class="modal-content" style="background-color: deepskyblue; padding: 0px; height: 50px;
                        top: 60px; color: white; font-size: initial;">
                        <!-- Custom color and padding -->
                        <div class="modal-body">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="margin-top: -6px;">
                                &times;</button>
                            <p id="modalMessage" style="margin-top: -6px; margin-left: 40px;">
                                Message will appear here.</p>
                        </div>
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
            <asp:HiddenField ID="hd_TransportMode" runat="server" />
            <asp:HiddenField ID="hd_PortOfDischarge_Status" runat="server" />
            <asp:HiddenField ID="hd_PageCount" runat="server" />
            <asp:HiddenField ID="hd_Freight" runat="server" />
            <asp:HiddenField ID="hd_Insurance" runat="server" />
            <asp:HiddenField ID="hd_MiscCharge" runat="server" />
            <asp:HiddenField ID="hdn_PDF_Master" runat="server" Value="S" />
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
    <asp:ModalPopupExtender ID="MP_INV_DETAILS" runat="server" TargetControlID="HDU"
        PopupControlID="INVOICE_DETAILS" BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:Panel ID="INVOICE_DETAILS" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 93%; height: 260px;
            overflow: auto; margin-left: 40px; margin-top: -180px;">
            <asp:Label ID="lbl_Header" runat="server" Text="MULTIPLE INVOICE DETAILS" Style="font-weight: bold;
                font-size: large; color: Maroon; margin-left: 125px;"></asp:Label>
            <asp:Button ID="btn_hide" runat="server" CssClass="clsicon_new" OnClientClick="HideModalPopup_INV();"
                CausesValidation="false" UseSubmitBehavior="false" Style="margin-left: 80px;" />
            <asp:GridView ID="gd_TEMP_INV" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                Width="100%" Style="margin-top: 0px;" AutoGenerateColumns="False" BackColor="White"
                BorderColor="#C8C8C8" BorderStyle="none" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                CssClass="grid-view" AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True"
                OnRowCreated="gv_ItemPDF_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    BorderWidth="1px" />
                <SelectedRowStyle Font-Bold="true" />
                <HeaderStyle BorderWidth="1px" BorderColor="Gray" />
                <Columns>
                    <asp:TemplateField HeaderText="Inv Sl.No" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_Temp_InvSlNo" runat="server" Text='<%#Eval("INVOICE_SLNO") %>'
                                MaxLength="3" Enabled="false" Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice No *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_Temp_InvoiceNo" runat="server" Text='<%#Eval("InvoiceNo") %>'
                                MaxLength="20" Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice Date *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_Temp_InvoiceDate" runat="server" Text='<%#Eval("InvoiceDate") %>'
                                Width="100px" Height="25px" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Currency *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_Temp_Currency" runat="server" Text='<%#Eval("Currency") %>'
                                MaxLength="3" Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Terms *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_Temp_Terms" runat="server" Text='<%#Eval("Terms") %>' MaxLength="3"
                                Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btn_Inv_Save" runat="server" Width="100px" Style="margin-left: 200px;
                margin-top: 65px;" Height="30px" Text="Inv save" CssClass="autowidmovebut" Visible="false"
                OnClick="btn_Inv_Save_Click" />
        </div>
    </asp:Panel>
    <!-- Background Overlay -->
    <div id="popupOverlay" style="display: none; position: fixed; top: 0; left: 0; width: 100%;
        height: 100%; background-color: rgba(0, 0, 0, 0.4); z-index: 9998;">
    </div>
    <!-- Popup container -->
    <div id="popupChecklist" style="display: none; position: fixed; top: 30%; left: 50%;
        transform: translate(-50%, -30%); background-color: #ffffff; border: 3px solid #28a745;
        padding: 25px 30px; z-index: 9999; box-shadow: 0px 0px 20px rgba(0,0,0,0.2);
        border-radius: 12px; text-align: center; width: 420px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
        <!-- Logo -->
        <div style="margin-bottom: 15px;">
            <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/images/Company_Logo/IPAN.PNG"
                Height="40px" Width="60px" Style="margin-top: -5px;" />
        </div>
        <!-- Success Message -->
        <div style="font-size: 18px; font-weight: bold; color: #28a745; margin-bottom: 10px;">
            &#9989; Job Created Successfully!
        </div>
        <!-- Description -->
        <div style="font-size: 14px; color: #444; margin-bottom: 20px;">
            &#128203; Ensure that all data entries are validated against the checklist before
            proceeding with flat file submission.
        </div>
        <!-- OK Button -->
        <button type="button" onclick="document.getElementById('popupChecklist').style.display='none';"
            style="background-color: #28a745; color: white; border: none; border-radius: 6px;
            padding: 10px 20px; cursor: pointer; font-size: 14px;">
            OK, Got It
        </button>
    </div>
    </form>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/product_JScript.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_Item_GST.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            function buildRowSource(cthListDS) {
                return function (request, response) {
                    var term = request.term.toLowerCase();
                    var filtered = $.grep(cthListDS, function (item) {
                        return item.toLowerCase().indexOf(term) >= 0;
                    });
                    response(filtered);
                };
            }
            function buildSelectHandler() {
                return function (event, ui) {
                    var $el = $(this);
                    var selectedValue = ui.item.value;

                    // Remove focus handler temporarily
                    $el.off("focus.cthrow");

                    // Remove onkeypress restriction temporarily
                    var oldKeypress = $el.attr("onkeypress");
                    $el.removeAttr("onkeypress");

                    // Force set value — bypasses keypress filter
                    $el[0].value = selectedValue;
                    $el.val(selectedValue);

                    // Restore onkeypress
                    if (oldKeypress) {
                        $el.attr("onkeypress", oldKeypress);
                    }

                    $el.css("border", "");
                    $el.autocomplete("close");
                    $el.trigger("change");

                    // Re-attach focus handler for multi after short delay
                    var mode = $el.attr("data-cth-mode") || "empty";
                    if (mode === "multi") {
                        setTimeout(function () {
                            $el.on("focus.cthrow", function () {
                                var $btn = $(this).closest("div").find("button");
                                var isShowingAll = $btn.data("showing-all") || false;
                                if (!isShowingAll) {
                                    $(this).autocomplete("search", "");
                                }
                            });
                        }, 300);
                    }
                    return false;
                };
            }

            // ── Initialize per-row CTH autocomplete ──────────────────
            function initCTHAutocomplete($el) {
                var mode = $el.attr("data-cth-mode") || "empty";
                var cthListRaw = $el.attr("data-cth-list") || "[]";
                var cthListDS = [];
                try { cthListDS = JSON.parse(cthListRaw); } catch (e) { cthListDS = []; }

                if ($el.data("ui-autocomplete")) {
                    $el.autocomplete("destroy");
                }
                $el.off("focus.cthrow");

                if (mode === "single") {
                    // Pre-filled from C# — suggest only its 1 CTH, never master
                    $el.autocomplete({
                        source: buildRowSource(cthListDS),
                        minLength: 0,
                        select: buildSelectHandler()
                    });
                    // Show its 1 RITC on click — only when NOT in search mode
                    $el.on("focus.cthrow", function () {
                        var $btn = $(this).closest("div").find("button");
                        var isShowingAll = $btn.data("showing-all") || false;
                        if (!isShowingAll) {
                            $(this).autocomplete("search", "");
                        }
                    });

                } else if (mode === "multi") {
                    // Empty by default — suggest only its own list on focus/type
                    $el.autocomplete({
                        source: buildRowSource(cthListDS),
                        minLength: 0,
                        select: buildSelectHandler()
                    });
                    // Show own list on click — only when NOT in search mode
                    $el.on("focus.cthrow", function () {
                        var $btn = $(this).closest("div").find("button");
                        var isShowingAll = $btn.data("showing-all") || false;
                        if (!isShowingAll) {
                            $(this).autocomplete("search", "");
                        }
                    });

                } else {
                    // Empty mode — no autocomplete at all, wait for 🔍
                    if ($el.data("ui-autocomplete")) {
                        $el.autocomplete("destroy");
                    }
                }
            }

            // ── Master autocomplete ───────────────────────────────────
            function attachMasterAutocomplete($el) {
                if ($el.data("ui-autocomplete")) {
                    $el.autocomplete("destroy");
                }
                $el.off("focus.cthrow");

                $el.autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CTH_Master_CTHNO_List",
                            data: "{ 'mail': '" + request.term + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            async: true,
                            success: function (data) { response(data.d); },
                            error: function () { response([]); }
                        });
                    },
                    minLength: 0,
                    select: function (event, ui) {
                        var $el = $(this);
                        var selectedValue = ui.item.value;

                        var oldKeypress = $el.attr("onkeypress");
                        $el.removeAttr("onkeypress");

                        $el[0].value = selectedValue;
                        $el.val(selectedValue);

                        if (oldKeypress) {
                            $el.attr("onkeypress", oldKeypress);
                        }

                        $el.css("border", "");
                        $el.autocomplete("close");
                        $el.trigger("change");
                        return false;
                    }
                });
            }

            // ── Search button toggle ──────────────────────────────────
            window.loadAllCTH = function (btn) {
                var $btn = $(btn);
                var $textbox = $btn.closest("div").find(".txt-cth");
                var isShowingAll = $btn.data("showing-all") || false;

                if (!isShowingAll) {
                    // Switch TO master
                    attachMasterAutocomplete($textbox);
                    $textbox.val('');
                    $textbox.focus();
                    setTimeout(function () {
                        $textbox.autocomplete("search", "");
                    }, 100);
                    $btn.css("background", "#28a745")
                .attr("title", "Click to go back to row list")
                .text("✓");
                    $btn.data("showing-all", true);

                } else {
                    // Switch BACK to row's own list — manual ✓ click only
                    revertToRowList($btn, $textbox);
                }
            };

            // ── Revert — manual ✓ click only ─────────────────────────
            function revertToRowList($btn, $textbox) {
                $btn.css("background", "#17a2b8")
            .attr("title", "Load All CTH from Master")
            .text("🔍");
                $btn.data("showing-all", false);
                initCTHAutocomplete($textbox);
            }

            // ── Initialize all grid rows on page load ─────────────────
            $(".txt-cth").each(function () {
                if ($(this).attr("id") === "txtCTH") return; // skip header
                initCTHAutocomplete($(this));
            });

            // ── Header txtCTH — master behavior ──────────────────────
            $("#txtCTH").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CTH_Master_CTHNO_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) { response(data.d); },
                        error: function () { }
                    });
                },
                minLength: 1
            });

        });

        $(function () {
            $("#txtBasicNotn,#txtBasicNoti").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CTH_Notification_Custom_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txtBasicNotn') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Basic Notn', 'error', 'topRight', true);
                                }
                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });

        $(function () {
            $("#txtBasicSLNO,#txtBasicSlno").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                        data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtBasicNotn").value + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txtBasicSLNO') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Basic SLNO', 'error', 'topRight', true);

                                }

                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }


                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {

                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });

        $(function () {
            $("#txt_info_UQC,#txtinfo_UQC,#txtQTYCode,#txt_QtyCode").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_List",
                        data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtinfo_UQC').validationEngine('showPrompt', 'Incorrect Unit', 'error', 'topRight', true);

                            }
                            else {
                                jQuery('#txtinfo_UQC').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

        $(function () {
            $("#txtitemCountyof_orgin,#txtitemCountyoforgin,#txtCountryOfOrigin").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Country_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {


                                jQuery('#txtCountryOfOrigin').validationEngine('showPrompt', 'Incorrect Country Origin', 'error', 'topRight', true);
                                //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById("txtStateName").focus(); });
                                // return false;
                            }
                            else {
                                jQuery('#txtCountryOfOrigin').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
            $("#txtSW_Noti,#txt_SW_Noti").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    var Type = '';


                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CTH_Notification_Custom_Master_List_NotnTYPE",
                        data: "{ 'mail': '" + request.term + "','Type': '" + Type + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txtSW_Noti') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Social Welfare NOTN', 'error', 'topRight', true);
                                }

                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });

        $(function () {
            $("#txtSW_Slno,#txt_SW_Slno").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                        data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtSW_Noti").value + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txtSW_Slno') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Social Welfare Notn SL', 'error', 'topRight', true);


                                }
                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }

                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {

                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });



        $(function () {
            $("#txt_AIDC_CessNoti,#txt_AIDCCessNoti").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    var RITC = document.getElementById("txtCTH").value;
                    var Flag = 'AIDC_NOTN_NO';
                    var Row_N = 'AIDC_NOTN_NO';
                    var val_A = '';
                    var val_B = '';
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AIDC_Cess_Master",
                        data: "{ 'mail': '" + request.term + "' ,'RITC':'" + RITC + "' ,'Flag':'" + Flag + "','Row_N':'" + Row_N + "','val_A':'" + val_A + "','val_B':'" + val_B + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txt_AIDC_CessNoti') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AIDC Notn', 'error', 'topRight', true);
                                }
                            }
                            else {

                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });

        $(function () {
            $("#txt_AIDC_CessSlno,#txt_AIDCCessSlno").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    var RITC = document.getElementById("txtCTH").value;
                    var Flag = 'AIDC_NOTN_SLNO';
                    var Row_N = 'AIDC_NOTN_SLNO';
                    var val_A = '';
                    var val_B = '';
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AIDC_Cess_Master",
                        data: "{ 'mail': '" + request.term + "' ,'RITC':'" + RITC + "' ,'Flag':'" + Flag + "','Row_N':'" + Row_N + "','val_A':'" + val_A + "','val_B':'" + val_B + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txt_AIDC_CessSlno') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AIDC Slno', 'error', 'topRight', true);
                                }
                            }
                            else {

                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });

        $(function () {
            $("#txt_AIDC_CessRate,#txt_AIDCCessRate").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    var RITC = document.getElementById("txtCTH").value;
                    var Flag = 'AIDC_NOTN_RATE';
                    var Row_N = 'AIDC_NOTN_RATE';
                    var val_A = document.getElementById("txt_AIDC_CessNoti").value;
                    var val_B = document.getElementById("txt_AIDC_CessSlno").value;
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AIDC_Cess_Master",
                        data: "{ 'mail': '" + request.term + "' ,'RITC':'" + RITC + "' ,'Flag':'" + Flag + "','Row_N':'" + Row_N + "','val_A':'" + val_A + "','val_B':'" + val_B + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txt_AIDC_CessRate') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AIDC  Rate', 'error', 'topRight', true);
                                }
                            }
                            else {

                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });
        $(function () {
            $("#txtSupplier").autocomplete({

                source: function (request, response) {

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Supplier_Master_List",

                        data: JSON.stringify({ mail: request.term }),

                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",

                        success: function (data) {



                            var formatted = $.map(data.d, function (item) {

                                if (item.indexOf("--") !== -1) {
                                    var parts = item.split('--');

                                    return {
                                        label: parts[1],
                                        value: parts[1],
                                        id: parts[0]
                                    };
                                } else {
                                    return {
                                        label: item,
                                        value: item
                                    };
                                }
                            });

                            response(formatted);


                            if (formatted.length === 0) {
                                $('#txtSupplier').validationEngine(
                            'showPrompt', 'Invalid Supplier', 'error', 'topRight', true
                        );
                            } else {
                                $('#txtSupplier').validationEngine('hidePrompt');
                            }
                        },

                        error: function (xhr) {
                            console.log("Error:", xhr.responseText);
                        }
                    });
                },

                minLength: 1,


                select: function (event, ui) {
                    $('#txtSupplier').val(ui.item.value);
                    return false;
                }
            });
        });

        

    </script>
    <script type="text/javascript">
        $(function () {
            $("#txt_IGST_Noti,#txt_IGSTNoti").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CETH_Notification_Excise_Master_List_IGST_LEVY_NOTN",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                if (field == 'txt_IGST_Noti') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect LEVY NOTN No', 'error', 'topRight', true);
                                }
                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }

                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });

        $(function () {
            $("#txt_IGST_SlNo,#txt_IGSTSlNo").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List_IGST_SLNO_1E",
                        data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_IGST_Noti").value + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txt_IGST_SlNo') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect IGST LEVY SLNO', 'error', 'topRight', true);
                                }
                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }

                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });


        function CallServerside_Basic_Duty_Cth_Notn_Slno(src, dest) {
            var ctrl = document.getElementById(src);
            var ctrl1 = document.getElementById(dest);
            PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_txtBasicRate, CallFailed, dest);
        }
        function CallSuccess_txtBasicRate(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data != -1 && data != '') {
                var before = data;
                document.getElementById("txtBasicRate").value = before;
            }
            else {
                document.getElementById("txtBasicRate").value = '';
            }
        }


        function CallServerside_Social_Welfare_Notn_Slno(src, dest) {
            var ctrl = document.getElementById(src);
            var ctrl1 = document.getElementById(dest);
            var type = 'SWS';

            PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO_with_Type(ctrl.value, ctrl1.value, type, CallSuccess_Social_Welfare_Cth, CallFailed, dest);

        }
        function CallSuccess_Social_Welfare_Cth(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data != -1 && data != '') {
                var before = data;
                document.getElementById("txt_SW_Rate").value = before;
            }
            else {
                document.getElementById("txt_SW_Rate").value = '';
            }
        }


        function Call_AIDC_Master(src) {

            var ctrl = document.getElementById(src);
            if (ctrl.length = 8) {
                PageMethods.Get_AIDC_Notn(ctrl.value, CallSucces_AIDC, CallFailed);
            }
        }
        function CallSucces_AIDC(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data != -1 && data != '') {
                var before = data;

                document.getElementById("txt_AIDC_CessRate").value = before;
            }
            else {
                document.getElementById("txt_AIDC_CessRate").value = '';
            }

            function aa() {
                var notnSlnoValue = document.getElementById("txt_AIDC_CessSlno").value;

                if (notnSlnoValue !== "") {
                    document.getElementById("txt_AIDC_CessRate").value = "0.00";
                }
            }
        }


        function CallServerside_txt_IGST_LEVY_SLNO(src, dest) {
            var ctrl = document.getElementById(src);
            var ctrl1 = document.getElementById(dest);

            PageMethods.Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_1E(ctrl.value, ctrl1.value, CallSuccess_txt_IGST_LEVY_SLNO, CallFailed, dest);
        }
        function CallSuccess_txt_IGST_LEVY_SLNO(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data != -1 && data != '') {
                var before = data;
                document.getElementById("txt_IGST_Rate").value = before;
            }
            else {
                document.getElementById("txt_IGST_Rate").value = '';
            }
        }       
    </script>
    <script type="text/javascript">
        $(function () {
            $("#txtPortOfOrigin").autocomplete({

                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
                        data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hd_TransportMode').value + "'}",
                        //data: "{ 'mail': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txtPortOfOrigin') {

                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Origin', 'error', 'topRight', true);

                                }

                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {

                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });

        $(function () {
            $("#txtCurrency").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exchage_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txtCurrency') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect  Currency', 'error', 'topRight', true);
                                }

                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);

                                var result = data.d;

                                var stringsearch = "-", str = result;

                                for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                                if (i == 1) {
                                    if (field == 'txtCurrency') {
                                        $('#txtCurrency').val(result);
                                    }
                                }
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });


        $(function () {
            $("#txtAdcode").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    var RITC = document.getElementById("txtCTH").value;
                    var Flag = 'ADCODE_MASTER';
                    var Row_N = 'ADCODE_IEC_ADCODE';
                    var val_A = '';
                    var val_B = '';
                    $.ajax({
                        // url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_ImporterMaster_List",
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_ImporterMaster_List",
                        data: "{ 'mail': '" + request.term + "' ,'RITC':'" + RITC + "' ,'Flag':'" + Flag + "','Row_N':'" + Row_N + "','val_A':'" + val_A + "','val_B':'" + val_B + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txtAdcode') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect ADCODE', 'error', 'topRight', true);
                                }
                            }
                            else {

                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });

        $(function () {

            $('#txtDescription,#txtItemDesc').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Item_Desc_List",

                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtItemDesc').validationEngine('showPrompt', 'Incorrect Description', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txtItemDesc').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            //////alert(textStatus);
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
        function validateNumericInput(input) {
            // Remove any non-numeric characters from the input
            input.value = input.value.replace(/[^0-9]/g, '');
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtCTH").on("change", function () {
                var cthValue = $(this).val();

                if (cthValue.length === 0) {
                    return;
                }

                $.ajax({
                    type: "POST",
                    url: "Import_PDF_Reader_AI.aspx/GetAIDCDetails",
                    data: JSON.stringify({ ritcNo: cthValue }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var data = response.d;

                        if (data && data.AIDC_NOTN_NO) {
                            $("#txt_AIDC_CessNoti").val(data.AIDC_NOTN_NO);
                            $("#txt_AIDC_CessSlno").val(data.AIDC_NOTN_SLNO);
                            $("#txt_AIDC_CessRate").val(data.AIDC_NOTN_RATE);
                        } else {
                            // default values as per your C# code
                            $("#txt_AIDC_CessNoti").val("011/2021");
                            $("#txt_AIDC_CessSlno").val("17");
                            $("#txt_AIDC_CessRate").val("0.00");
                        }
                    },
                    error: function (xhr, status, error) {
                        console.log("Error AIDC: " + error);
                    }
                });

                // Call backend service to get IGST details
                $.ajax({
                    type: "POST",
                    url: "Import_PDF_Reader_AI.aspx/GetIGSTDetails",  // ✅ change to the page where WebMethod is written
                    data: JSON.stringify({ ritcNo: cthValue }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var data = response.d;

                        if (data && data.LEVY_1NOTIFICATION) {
                            $("#txt_IGST_Noti").val(data.LEVY_1NOTIFICATION);
                            $("#txt_IGST_SlNo").val(data.LEVY_1NOTIFICATION_SLNO);
                            $("#txt_IGST_Rate").val(data.LEVY_1NOTIFICATION_RATE);
                        } else {
                            $("#txt_IGST_Noti").val("");
                            $("#txt_IGST_SlNo").val("");
                            $("#txt_IGST_Rate").val("");
                        }
                    },
                    error: function (xhr, status, error) {
                        console.log("Error: " + error);
                    }
                });
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            // when any CTH textbox changes
            $(document).on("change", ".txt-cth", function () {
                var cthValue = $(this).val();
                var $row = $(this).closest("tr"); // get current row

                if (cthValue.length === 0) return;

                // --- AIDC AJAX ---
                $.ajax({
                    type: "POST",
                    url: "Import_PDF_Reader_AI.aspx/GetAIDCDetails",
                    data: JSON.stringify({ ritcNo: cthValue }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var data = response.d;
                        if (data && data.AIDC_NOTN_NO) {
                            $row.find(".txt-aidc-noti").val(data.AIDC_NOTN_NO);
                            $row.find(".txt-aidc-slno").val(data.AIDC_NOTN_SLNO);
                            $row.find(".txt-aidc-rate").val(data.AIDC_NOTN_RATE);
                        } else {
                            $row.find(".txt-aidc-noti").val("011/2021");
                            $row.find(".txt-aidc-slno").val("17");
                            $row.find(".txt-aidc-rate").val("0.00");
                        }
                    },
                    error: function (xhr, status, error) {
                        console.log("Error AIDC: " + error);
                    }
                });

                // --- IGST AJAX ---
                $.ajax({
                    type: "POST",
                    url: "Import_PDF_Reader_AI.aspx/GetIGSTDetails",
                    data: JSON.stringify({ ritcNo: cthValue }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var data = response.d;
                        if (data && data.LEVY_1NOTIFICATION) {
                            $row.find(".txt-igst-noti").val(data.LEVY_1NOTIFICATION);
                            $row.find(".txt-igst-slno").val(data.LEVY_1NOTIFICATION_SLNO);
                            $row.find(".txt-igst-rate").val(data.LEVY_1NOTIFICATION_RATE);
                        } else {
                            $row.find(".txt-igst-noti").val("");
                            $row.find(".txt-igst-slno").val("");
                            $row.find(".txt-igst-rate").val("");
                        }
                    },
                    error: function (xhr, status, error) {
                        console.log("Error IGST: " + error);
                    }
                });
            });
        });
    </script>
    <script type="text/javascript">
           $(document).ready(function () {   // <-- ADD THIS MISSING OPENING
               $(".txt-cth").each(function () {
                   var $el = $(this);
                   if ($el.attr("id") === "txtCTH") return; // skip header textbox
                   var val = $el.val();
                   if (val && val.length > 0) {
                       validateCTH($el);
                   }
               });

               // Validation function
               function validateCTH($element) {
                   var val = $element.val();
                   if (!val || val.length === 0) {
                       $element.css({ "border": "", "color": "" });
                       $element.data("cth-invalid", false);
                       return;
                   }
                   $.ajax({
                       url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CTH_Master_CTHNO_List",
                       data: "{ 'mail': '" + val + "' }",
                       dataType: "json",
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       success: function (data) {
                           if (data.d == null || data.d.length === 0) {
                               $element.css({ "border": "2px solid red", "color": "red", "font-weight": "bold" });
                               $element.data("cth-invalid", true);
                               showSinglePopup();
                           } else {
                               $element.css({ "border": "", "color": "", "font-weight": "" });
                               $element.data("cth-invalid", false);
                           }
                       },
                       error: function (xhr, status, error) {
                           console.error("Validation Error:", error);
                       }
                   });
               }

               // ── RITC/CTH ICEGATE re-check whenever value changes ──────
               $(document).on("change blur", ".txt-cth", function () {
                   var $el = $(this);
                   if ($el.attr("id") === "txtCTH") return; // skip header textbox
                   validateCTH($el);
               });

               // ✅ Prevent multiple popups
               var popupShown = false;
               function showSinglePopup() {
                   if (!popupShown) {
                       popupShown = true;
                       alert("RITC not found in ICEGATE — please correct the highlighted RITC before creating the job.");
                       setTimeout(function () { popupShown = false; }, 3000);
                   }
               }

           }); // <-- correct closing
    </script>
    <script type="text/javascript">
        $(function () {
            $("#txtEnduseItem,#txtEndUseOfItems").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/End_Use_Of_Item_List",

                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtEndUseOfItems').validationEngine('showPrompt', 'Incorrect EndUse Code', 'error', 'topRight', true);

                            }
                            else {
                                jQuery('#txtEnduseItem').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });

        function Item_desc(val) {

            var data = val;

            if (data == '') {
                $('#txtEnduseItem').val('');
            }
            if (data.indexOf("-") != -1) {

                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtEnduseItem').val(before);
            }
            else {

            }
        }

        $(document).ready(function () {
            $('#txtEnduseItem').focus(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtEnduseItem').change(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtEnduseItem').keyup(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtEnduseItem').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });
        
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            function getDescList() {
                var list = [];
                $("input[type='text'][id*='txtItemDesc']").each(function () {
                    var v = $(this).val().trim();
                    if (v && v.indexOf('?') === -1 && $.inArray(v, list) === -1) {
                        list.push(v);
                    }
                });
                return list;
            }

            function checkAndReplace($el) {
                var val = $el.val();
                var clean = val.replace(/[^\u0000-\u007F]/g, '?');
                if (clean !== val) $el.val(clean);

                if (clean.indexOf('?') !== -1) {
                    $el.css({ "background-color": "sandybrown", "color": "red", "font-weight": "bold" });
                } else {
                    // ✅ ? gone — clear red immediately
                    $el.css({ "background-color": "white", "color": "black", "font-weight": "normal" });
                }

                var any = false;
                $("input[type='text'][id*='txtItemDesc']").each(function () {
                    if ($(this).val().indexOf('?') !== -1) any = true;
                });
                $("#<%= Label2.ClientID %>").toggle(any);
            }

            // Page load
            $("input[type='text'][id*='txtItemDesc']").each(function () {
                checkAndReplace($(this));

                $(this).autocomplete({
                    source: getDescList,
                    minLength: 1,
                    select: function (e, ui) {
                        $(this).val(ui.item.value);
                        checkAndReplace($(this)); // ✅ recheck after select
                        return false;
                    }
                });
            });

            // ✅ Every single keystroke — check immediately
            $(document).on("keyup input", "input[type='text'][id*='txtItemDesc']", function () {
                checkAndReplace($(this));
            });

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            // Initialize DatePicker
            $("#txtInvDate").datepicker({
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "1900:2100",
                beforeShow: function (input, inst) {
                    setTimeout(function () {
                        $('.ui-datepicker').css('z-index', 9999);
                    }, 0);
                },
                onSelect: function () {
                    validateInvoiceDate($("#txtInvDate"));
                }
            });

            // Validate and clean up the date input
            function validateInvoiceDate($element) {
                var dateVal = $element.val().trim();

                // 🧹 Remove spaces around separators automatically
                dateVal = dateVal.replace(/\s*([\/\-.])\s*/g, '$1');
                $element.val(dateVal); // update cleaned value in input

                // ✅ Accept DD/MM/YYYY, DD-MM-YYYY, DD.MM.YYYY (with optional spaces)
                var datePattern = /^(0[1-9]|[12][0-9]|3[01])[\/\-.](0[1-9]|1[0-2])[\/\-.](19|20)\d\d$/;

                if (dateVal === "") {
                    $element.css("border", "");
                    window.datePopupShown = false;
                    return;
                }

                if (!datePattern.test(dateVal)) {
                    $element.css("border", "2px solid red");

                    if (!window.datePopupShown) {
                        alert("Invalid invoice date! Please enter in DD/MM/YYYY, DD-MM-YYYY, or DD.MM.YYYY format (e.g., 20/02/2025).");
                        window.datePopupShown = true;
                    }
                } else {
                    $element.css("border", "");
                    window.datePopupShown = false;
                }
            }
            // Validate on blur
            $("#txtInvDate").on("blur", function () {
                validateInvoiceDate($(this));
            });

            // Validate while typing
            $("#txtInvDate").on("input", function () {
                validateInvoiceDate($(this));
            });

            // Auto validate on page load
            validateInvoiceDate($("#txtInvDate"));

            // ── QTY Validation Function ──
            function validateQTY($el) {
                var val = $el.val().replace(/\s/g, '');
                if (val.length > 3) val = val.substring(0, 3);
                $el.val(val);
                $el.siblings('.qty-error').remove();
                $el.next('.qty-error').remove();

                if (val.length > 0 && val.length != 3) {
                    $el.css('border', '1px solid red');
                    $el.after('<span class="qty-error" style="color:red;font-size:11px;">QTY Code must be exactly 3 digits</span>');
                } else {
                    $el.css('border', '1px solid #ccc');
                    $el.siblings('.qty-error').remove();
                }
            }
            function validateCTH($el) {
                var val = $el.val().replace(/\s/g, '');
                if (val.length > 8) val = val.substring(0, 8);
                $el.val(val);

                // Remove previous error tooltip
                $el.siblings('.cth-error').remove();
                $el.next('.cth-error').remove();

                if (val.length > 0 && val.length != 8) {
                    $el.css({ 'border': '2px solid red', 'background-color': '#fff0f0' });
                    $el.attr('title', 'CTH must be exactly 8 digits (currently ' + val.length + ')');
                    // Small tooltip that floats — does NOT break row height
                    $el.after('<span class="cth-error">Must be 8 digits (' + val.length + ')</span>');
                } else {
                    $el.css({ 'border': '1px solid #ccc', 'background-color': '' });
                    $el.removeAttr('title');
                    $el.siblings('.cth-error').remove();
                }
            }

            // ADD THIS MISSING EVENT BINDING — was completely missing!
            $(document).on('keyup change input blur', '[id*="txt_CTH"]', function () {
                validateCTH($(this));
            });

            // ── Page Load - Existing Values Check ──
            $(document).ready(function () {
                $('[id*="txt_CTH"]').each(function () {
                    validateCTH($(this));
                });

                $('[id*="txtQTYCode"]').each(function () {
                    validateQTY($(this));
                });
            });
        });
    </script>
    <script type="text/javascript">
        $("form").on("keypress", function (e) {
            if (e.keyCode === 13) {
                e.preventDefault();
                return false;
            }
        });
    </script>
    <script type="text/javascript">
        var mandatoryFields =
        "#txtInvNo, #txtInvDate, #txtImporterName, #txtInvValue, " +
        "#txtSupplier, #txtCountryOfOrigin, #txtPortOfOrigin, #ddlTerms, #txtCurrency";

        function validateBeforeUpload() {
            var $firstEmpty = null;

            // Header fields check
            $(mandatoryFields).each(function () {
                var $el = $(this);
                var val = ($el.val() || "").trim();
                var isEmpty = val === "" || val === "--Select--" || val === "0";
                $el.css("border", isEmpty ? "2px solid red" : "1px solid #ccc");
                if (isEmpty && !$firstEmpty) $firstEmpty = $el;
            });

            // Gridview row fields check
            $("#gv_ItemPDF tr:not(:first-child)").each(function () {
                var $row = $(this);
                var rowFields = [
                $row.find("[id*='txtItemDesc']"),
                $row.find("[id*='txtQTYCode']"),
                $row.find("[id*='txt_CTH']"),
                $row.find("[id*='ddl_SchemeCode']"),
                $row.find("[id*='txtEndUseOfItems']"),
                $row.find("[id*='txtitemCountyoforgin']"),
                $row.find("[id*='txt_AIDCCessNoti']"),
                $row.find("[id*='txt_AIDCCessSlno']"),
                $row.find("[id*='txt_AIDCCessRate']"),
                $row.find("[id*='txt_IGSTNoti']"),
                $row.find("[id*='txt_IGSTSlNo']"),
                $row.find("[id*='txt_IGSTRate']"),
                $row.find("[id*='txt_Manufacturer']")
            ];
                $.each(rowFields, function (i, $el) {
                    if ($el.length === 0) return;
                    var val = ($el.val() || "").trim();
                    var isEmpty = val === "" || val === "--Select--";
                    $el.css("border", isEmpty ? "2px solid red" : "1px solid #ccc");
                    if (isEmpty && !$firstEmpty) $firstEmpty = $el;
                });
            });
            if ($firstEmpty !== null) {
                setTimeout(function () {
                    $firstEmpty[0].scrollIntoView({ behavior: "smooth", block: "center" });
                    $firstEmpty.focus();
                }, 100);
                return false;
            }
             // ── CTH ICEGATE validation check ──
           var hasInvalidCTH = false;
          $(".txt-cth").each(function () {
               if ($(this).data("cth-invalid") === true) hasInvalidCTH = true;
           });
           if (hasInvalidCTH) {
               alert("Invalid CTH (not in ICEGATE) detected — please correct highlighted fields before upload.");
             return false;
        }
            $('#lbl_loading').html('<span style="color: orange; font-weight: bold;">&#9203; Saving Proccessing. Please wait.</span>');
            return true;
        }
        $(document).on("keyup change input blur", mandatoryFields, function () {
            var empty = ($(this).val() || "").trim() === "" || $(this).val() === "--Select--";
            $(this).css("border", empty ? "2px solid red" : "1px solid #ccc");
        });

        // Gridview fields border clear
        $(document).on("keyup change input blur",
        "[id*='txtItemDesc'], [id*='txtQTYCode'], [id*='txt_CTH'], [id*='ddl_SchemeCode']," +
        "[id*='txtEndUseOfItems'], [id*='txtitemCountyoforgin']," +
        "[id*='txt_AIDCCessNoti'], [id*='txt_AIDCCessSlno'], [id*='txt_AIDCCessRate']," +
        "[id*='txt_IGSTNoti'], [id*='txt_IGSTSlNo'], [id*='txt_IGSTRate']," +
        "[id*='txt_Manufacturer']",
        function () {
            var empty = ($(this).val() || "").trim() === "" || $(this).val() === "--Select--";
            $(this).css("border", empty ? "2px solid red" : "1px solid #ccc");
        }
    );
        function revalidateCurrentPage() {
            $("#gv_ItemPDF tr:not(:first-child)").each(function () {
                var $row = $(this);
                var rowFields = [
            $row.find("[id*='txtItemDesc']"),
            $row.find("[id*='txtQTYCode']"),
            $row.find("[id*='txt_CTH']"),
            $row.find("[id*='ddl_SchemeCode']"),
            $row.find("[id*='txtEndUseOfItems']"),
            $row.find("[id*='txtitemCountyoforgin']"),
            $row.find("[id*='txt_AIDCCessNoti']"),
            $row.find("[id*='txt_AIDCCessSlno']"),
            $row.find("[id*='txt_AIDCCessRate']"),
            $row.find("[id*='txt_IGSTNoti']"),
            $row.find("[id*='txt_IGSTSlNo']"),
            $row.find("[id*='txt_IGSTRate']"),
            $row.find("[id*='txt_Manufacturer']")
        ];
                $.each(rowFields, function (i, $el) {
                    if ($el.length === 0) return;
                    var val = ($el.val() || "").trim();
                    var isEmpty = val === "" || val === "--Select--";
                    $el.css("border", isEmpty ? "2px solid red" : "");
                });
            });
        }
        $(window).on("load", function () {
            setTimeout(function () {
                revalidateCurrentPage();
            }, 8000);
        });


    </script>
    <script type="text/javascript">
        var extractionTimerInterval = null;
        var extractionSeconds = 0;

        function startExtractionTimer() {
            extractionSeconds = 0;
            var $t = $('#lbl_LiveExtractionTimer');
            $t.text('Start Time... 00:00');
            if (extractionTimerInterval) clearInterval(extractionTimerInterval);
            extractionTimerInterval = setInterval(function () {
                extractionSeconds++;
                var mm = Math.floor(extractionSeconds / 60);
                var ss = extractionSeconds % 60;
                $t.text('Start Time... ' + (mm < 10 ? '0' : '') + mm + ':' + (ss < 10 ? '0' : '') + ss);
            }, 1000);
        }

        $(document).ready(function () {
            $('#btnPrevData').click(function () {
                startExtractionTimer();
            });
        });
</script>
</body>
</html>
