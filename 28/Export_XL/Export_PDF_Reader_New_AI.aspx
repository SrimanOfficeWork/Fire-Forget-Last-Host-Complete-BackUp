<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_PDF_Reader_New_AI.aspx.cs" Inherits="Export_PDF_Reader_New_AI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export PDF Upload - AI </title>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <script src="../js/Export_Jscript/Export_Item.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
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
        function Confirm() {

            var scheme = $('#ddlSchemeCode').val();
            var aa = '';
            var a0 = '';

            //        if (scheme.includes('-')) {
            //            aa = scheme.split('-');
            //            a0 = aa[0];

            //        }

            if (scheme.indexOf("-") != "-1") {
                aa = scheme.split('-');
                a0 = aa[0];

            }

            if (a0 == '19' || a0 == '41' || a0 == '43' || a0 == '44' || a0 == '47' || a0 == '48' || a0 == '49' || a0 == '60' || a0 == '61' || a0 == '62' || a0 == '63' || a0 == '64' || a0 == '65' || a0 == '71' || a0 == '73' || a0 == '74' || a0 == '79' || a0 == '80' || a0 == '81') {

                var item_unit = document.getElementById("txtQtyCode").value;
                var dbk_unit = document.getElementById("hdn_dbk_unit").value;

                var item_qty = document.getElementById("txtItemQty").value;
                //            var dbk_qty = $('#hdn_DWBK_QTY').val();
                //                alert($('#hdn_DWBK_QTY').val());

                var dbk_qty = $('#hdn_dbk_Qty').val();


                if (dbk_qty != '') {

                    //                var x = '', y = '';
                    // if (item_qty.includes(".000") || dbk_qty.includes(".00")) {
                    //                if (item_qty.indexOf(".000") != "-1" || dbk_qty.indexOf(".00") != "-1") {
                    //                    var x = item_qty.split(".");
                    //                    x = x[0];
                    //                    item_qty = x;
                    //                }

                    //                //if (dbk_qty.includes(".000") || dbk_qty.includes(".00")) {
                    //                if (dbk_qty.indexOf(".000") != "-1" || dbk_qty.indexOf(".00") != "-1") {
                    //                    y = dbk_qty.split(".");
                    //                    y = y[0];
                    //                    dbk_qty = y;
                    //                }


                    if (item_unit == dbk_unit) {
                        //                    if (item_qty != dbk_qty) {
                        if (Number(item_qty) != Number(dbk_qty)) {
                            var answer = confirm("Item Qty Not match With DBK Qty, Do u want Save?")

                            if (answer == true) {
                                $('#hdn_Same_Diff').val('Same');
                            }

                            else {
                                $('#hdn_Same_Diff').val('Diff');
                            }
                        }
                        else {
                            $('#hdn_Same_Diff').val('Same');
                        }
                    }
                    else {
                        $('#hdn_Same_Diff').val('Same');
                    }
                }
                else {
                    $('#hdn_Same_Diff').val('Same');
                }
            }
            else {
                $('#hdn_Same_Diff').val('Same');
            }
        }
    
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
      .grid-view {
         display: block;
         max-height: 300px;   /* adjust scroll area */
         overflow-y: auto;
         border-collapse: collapse;
         width: 100%;
       }

      .grid-view th {
        position: sticky;
        top: 0;
        background: maroon;   /* solid orange */
        color: white;         /* optional: white text for contrast */
        z-index: 10;
    }
    .ui-autocomplete {
    z-index: 9999 !important;  /* HIGH priority for dropdown */
    }
    </style>

        <style type="text/css">
        .btn-filter {
            background-color:deepskyblue;   
            border: 1px solid aqua;   
        }

        .btn-filter:hover {
            background-color: steelblue;  
            color: white;               
        }
         .btn-filter1 {
            background-color:lightseagreen;   
            border: 1px solid aqua;   
        }

        .btn-filter1:hover {
            background-color: steelblue ;  
            color: white;              
        }
    </style>

    <style type="text/css">
    .note-label {
        display: block;
        background-color: #fff3cd;  /* soft yellow background */
        color: #856404;             /* brownish text for readability */
        border: 1px solid #ffeeba;  /* subtle border */
        padding: 10px 12px;
        border-radius: 6px;         /* rounded corners */
        font-family: Segoe UI, Arial, sans-serif;
        font-size: 12px;
        font-weight: 513;
        height: 48px;
        margin-top: -7px;
        font-weight: bold;
    }

    .note-label::before {
        content: "&#9888; ";  /* warning icon before text */
        font-size: 10px;
    }
</style>
    <style type="text/css">
        .error-border
        {
            border: 2px solid red !important;
        }
        .error-msg
        {
            color: red;
            font-size: 11px;
            display: block;
            margin-top: 3px;
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

                includeSelectAllOption: true
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
                            }
                            else {
                                jQuery('#txtConsigneeName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


        $(function () {
            $("#txt_PTA_FTA,#txtUnderPTA").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/PTA_FTA_Master_Name_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                            }
                            else {
                                jQuery('#txtUnderPTA').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
            $("#txt_Drawback_SLNo,#txtDrawback_SLNo").autocomplete({

                source: function (request, response) {
                    var aa = '';

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/DrawBack_Master_List_RITCNO",
                        data: "{ 'mail': '" + request.term + "','RITC_NO': '" + aa + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtDrawback_SLNo').validationEngine('showPrompt', 'Incorrect Drawback SLNo', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txtDrawback_SLNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
            $("#txt_DBK_Unit,#txtDBK_Unit,#txtQtyCode,#txt_QtyCode").autocomplete({

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
                                jQuery('#txt_DBK_Unit').validationEngine('showPrompt', 'Incorrect Unit', 'error', 'topRight', true);

                            }
                            else {
                                jQuery('#txt_DBK_Unit').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
        function CallServerside_Drawback(src) {
            var ctrl = document.getElementById(src);
            PageMethods.Get_Drawback_Master(ctrl.value, CallSuccess_Drawback, CallFailed);
        }

        function CallSuccess_Drawback(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data.indexOf("~~") != -1) {

                var s = data.split('~~');

                var before = s[0];
                document.getElementById("txt_DBK_Unit").value = before;
            }
            else {
                document.getElementById("txt_DBK_Unit").value = "";
            }
        }
    </script>
    <%-- <script language="jscript" type="text/javascript">
        $(document).ready(function () {
            $('#btnPrevData').click(function () {
                document.getElementById("lbl_loading").innerHTML = "File Loading...";
            });
        });   
    </script>--%>
    <script language="jscript" type="text/javascript">
        $(document).ready(function () {
            $('#btnPrevData').click(function () {
                $('#lbl_loading').html('<span style="color: orange; font-weight: bold;">&#9203; File is being processed... Please wait.</span>');
            });
        });

        //        $(document).ready(function () {
        //            $('#btnupload').click(function () {
        //                return true;
        //                $('#lbl_loading').html('<span style="color: orange; font-weight: bold;">&#9203; Saving processed... Please wait.</span>');
        //            });
        //        });
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

        //Freeze Header

</script>
</head>
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
                        <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                            <div id="txtcon-m_Exchange" style="width: 250px;">
                                <asp:Label ID="Label1" runat="server" Text="EXPORT - PDF UPLOAD " Height="25px" Width="250px"
                                    Style="margin-top: -3px; font-size: larger;"></asp:Label>
                            </div>
                        </div>
                        <div id="verslic" style="margin-top: -5px;">
                        </div>
                        <div id="tag_transac_lft_in2" style="margin-top: -10px;">
                            <div id="txtcon-m_Exchange" style="width: 50px;">
                                <asp:ImageButton ID="ImageButton1" UseSubmitBehavior="false" runat="server" ImageUrl="~/images/icons/Refresh.png"
                                    ToolTip="Refresh" Height="25px" Width="35px" OnClick="btn_Refresh_Click" Style="margin-top: -5px;" />
                            </div>
                        </div>
                        <div id="verslic" style="margin-top: -5px;">
                        </div>
                        <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                            <div id="txtcon-m_Exchange" style="width: 35px; margin-left: 30px;">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/icons/G.JPG"
                                    Height="25px" Width="35px" Style="margin-top: -5px;" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                            <div id="txtcon-m_Exchange" style="width: 35px;">
                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/icons/E.JPG"
                                    Height="25px" Width="35px" Style="margin-top: -5px;" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                            <div id="txtcon-m_Exchange" style="width: 35px;">
                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/icons/N.JPG"
                                    Height="25px" Width="35px" Style="margin-top: -5px;" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                            <div id="txtcon-m_Exchange" style="width: 35px;">
                                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/images/icons/Mid.JPG"
                                    Height="5px" Width="20px" Style="margin-top: 5px; margin-left: 5px" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                            <div id="txtcon-m_Exchange" style="width: 35px;">
                                <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/icons/A.JPG"
                                    Height="25px" Width="35px" Style="margin-top: -5px;" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                            <div id="txtcon-m_Exchange" style="width: 35px;">
                                <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/images/icons/I.JPG"
                                    Height="25px" Width="35px" Style="margin-top: -5px;" />
                            </div>
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_label_transaction_Src_new" style="width: 250px; margin-left: 20px; font-weight: bold;
                        color: Blue;">
                        Job No
                        <asp:TextBox ID="txtjobPS" runat="server" Font-Bold="true" MaxLength="10" Font-Size="12px"
                            CssClass="txtbox_none_Mid_transac_code" Width="130px" ReadOnly="True" TabIndex="1"
                            Height="20px" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 220px;">
                        <div id="txtcon-m_Exchange" style="width: 160px; margin-left: 40px;">
                            <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/images/icons/OCR_Excel.JPG"
                                Height="52px" Width="100px" OnClick="ImageButton8_Click" Visible="false" />
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
                    <asp:DropDownList ID="ddl_ExporterName" runat="server" TabIndex="1" Width="250px"
                        Height="22px" ClientIDMode="Static">
                    </asp:DropDownList>
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');openexpclientmasternew(); return false"
                        runat="server" id="href_Client_YN_New" style="font-weight: bold;">New</a>
                </div>
                <div id="tag_label_transact_Src" style="width: 130px; font-weight: bold;">
                    UPLOAD PDF FILE</div>
                <div id="txtcon-m_src" style="width: 350px;">
                    <input type="file" id="File1" runat="server" multiple="multiple" style="color: Blue;
                        font-weight: bold;" />
                </div>
                <div id="txtcon-m_Exchange" style="width: 120px;">
                    <asp:Button ID="btnPrevData" Style="margin-top: -3px; margin-left: 5px" Text="PREVIEW"
                        Width="100px" CssClass="autowidmovebut" runat="server" UseSubmitBehavior="false"
                        OnClick="btnPrevData_Click" />
                </div>
                <div id="txtcon-m_src" style="width: 260px;">
                    <asp:Label ID="lbl_loading" runat="server" ForeColor="Blue" Width="250px"></asp:Label>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans" style="width: 1235px; height: 2px; margin-left: -40px;">
            </div>
            <div id="tag_srcinner1" style="width: 1260px; height: 25px;">
                <div id="txt_container_Transact_Main_l" style="width: 208px;">
                    <div id="tag_label_transaction_Src" style="width: 106px; font-weight: bold;">
                        Exporter Name
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 205px;">
                    <div id="tag_label_transaction_Src" style="width: 166px; font-weight: bold;">
                        Consignee Name
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 220px;">
                    <div id="tag_label_transaction_Src" style="width: 106px; font-weight: bold;">
                        Buyer Name
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 220px;">
                    <div id="tag_label_transaction_Src" style="width: 136px; font-weight: bold;">
                        Notify Party Name
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 110px;">
                    <div id="tag_label_transaction_Src" style="width: 110px; font-weight: bold;">
                        Ad Code
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 200px;">
                    <div id="tag_label_transaction_Src" style="width: 200px; font-weight: bold;">
                        Accessory Desc
                    </div>
                </div>
            </div>
            <div id="tag_srcinner1" style="height: 35px;">
                <div id="txtcon-m_transaction_Supp_code" style="width: 203px;">
                    <asp:TextBox ID="txtExporterName" Width="190px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 205px;">
                    <asp:TextBox ID="txtConsigneeName" Width="190px" Font-Size="12px" runat="server"
                        CssClass="validate txtbox_none_Mid_transac_Supp_Name" 
                        ClientIDMode="Static" TabIndex="1"
                        Height="20px" ontextchanged="txtConsigneeName_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 225px;">
                    <asp:TextBox ID="txtBuyer" Width="210px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 220px;">
                    <asp:TextBox ID="txtNotifyParty" Width="210px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 110px;">
                    <asp:DropDownList ID="ddlAdCode" runat="server" CssClass="listtxt_transac_src1" TabIndex="1"
                        Width="100px" Height="20px">
                    </asp:DropDownList>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="height: 20px; width: 200px;">
                    <asp:TextBox ID="txtAccessoryDesc" runat="server" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1"
                        Height="20px" Width="210px" MaxLength="500" TextMode="MultiLine" onkeyDown="return (event.keyCode!=13);return checkTextAreaMaxLength(this,event,'500');"
                        onpaste="return checkTextAreaMaxLength(this,event,'500');" TabIndex="1"></asp:TextBox>
                </div>
            </div>
            <div id="tag_srcinner1" style="height: 25px;">
                <div id="txt_container_Transact_Main_l" style="width: 170px;">
                    <div id="tag_label_transaction_Src" style="width: 106px; font-weight: bold;">
                        Invoice No
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 115px;">
                    <div id="tag_label_transaction_Src" style="width: 166px; font-weight: bold;">
                        Invoice Date
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 115px;">
                    <div id="tag_label_transaction_Src" style="width: 106px; font-weight: bold;">
                        Terms
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 115px;">
                    <div id="tag_label_transaction_Src" style="width: 100px; font-weight: bold;">
                        Currency
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 195px;">
                    <div id="tag_label_transaction_Src" style="width: 216px; font-weight: bold;">
                        Country Of Discharge
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 130px;">
                    <div id="tag_label_transaction_Src" style="width: 116px; font-weight: bold;">
                        Port Of Discharge
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 145px;">
                    <div id="tag_label_transaction_Src" style="width: 130px; font-weight: bold;">
                        Type Of Exporter
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 210px;">
                    <div id="tag_label_transaction_Src" style="width: 166px; font-weight: bold;">
                        <asp:Label ID="lbl_Third_Party_Details" runat="server" Text="Third Party Details"
                            Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
            <div id="tag_srcinner1" style="height: 20px;">
                <div id="txtcon-m_transaction_Supp_code" style="width: 170px;">
                    <asp:TextBox ID="txtInvoiceNo" Width="160px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 115px;">
                    <asp:TextBox ID="txtInvoiceDate" Width="100px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                  <div id="txtcon-m_transaction_Supp_code" style="width: 100px;">
                     <asp:DropDownList ID="ddlTerms" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                    runat="server" TabIndex="1" Width="60px" Font-Size="12px" Height="20px">
                                </asp:DropDownList>  
                </div>

                <div id="txtcon-m_transaction_Supp_code" style="width: 115px;">
                    <asp:TextBox ID="txtCurrency" Width="100px" Font-Size="12px" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 195px;">
                    <asp:TextBox ID="txtCountry" Width="180px" Font-Size="12px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 130px;">
                    <asp:TextBox ID="txtPort" Width="120px" Font-Size="12px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" TabIndex="1" Height="20px"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 145px;">
                    <asp:DropDownList ID="ddlType_Exp" runat="server" CssClass="listtxt_transac_src1"
                        TabIndex="1" Width="130px" Height="20px">
                        <asp:ListItem Text="Manufacturer - ( F )" Value="F"></asp:ListItem>
                        <asp:ListItem Text="Merchant - ( R )" Value="R"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 210px;">
                    <asp:TextBox ID="txt_Third_Party_Details" Width="190px" Font-Size="12px" runat="server"
                        CssClass="validate txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static" TabIndex="1"
                        Height="20px" Visible="false"></asp:TextBox>
                </div>
            </div>
            <div id="tag_srcinner1" style="height: 115px;">
                <fieldset style="border: Black; border-style: double; margin-left: 0px; margin-top: 5px;
                    width: 1175px; height: 112px;">
                    <legend style="border: Black; border-collapse: collapse; width: 331px; font-weight: bold;
                        background-color: Scrollbar; color: Teal; height: 34px;">
                        <asp:DropDownList ID="ddl_Select_ItemRITC" runat="server" CssClass="listtxt_transac_exp_item_yn"
                            TabIndex="1" Height="22px" Width="60px" OnSelectedIndexChanged="ddl_Select_ItemRITC_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem Text="ITEM" Value="0"></asp:ListItem>
                            <asp:ListItem Text="RITC" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp Bulk Update Field for All Records </legend><legend style="border: Black; border-collapse: collapse;
                            width: 195px; font-weight: bold; margin-left: 361px; margin-top: -34px; background-color: Scrollbar;
                            color: crimson; height: 34px;">
                            <asp:RadioButtonList ID="Rd_SInv_MInv" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="true" OnSelectedIndexChanged="Rd_SInv_MInv_SelectedIndexChanged"
                                Style="width: 177px; margin-left: 5px; margin-top: -2px; font-size: 12px;">
                                <asp:ListItem Text="Single INV" Value="S" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Multiple INV" Value="M"></asp:ListItem>
                            </asp:RadioButtonList>
                        </legend>
                    <div id="tag_srcinner1" style="height: 35px; width: 1170px; margin-top: 4px">
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 25px; font-weight: bold;">
                            Inv
                        </div>
                        <div id="tag_srcinner1" style="width: 143px; font-weight: bold;">
                            <asp:ListBox ID="ListBox_INVSlno" Height="25px" Width="60px" ViewStateMode="Enabled"
                                runat="server" AutoPostBack="true" SelectionMode="Multiple" OnSelectedIndexChanged="ListBox_INVSlno_SelectedIndexChanged">
                            </asp:ListBox>
                        </div>
                         <div id="tag_label_transaction_popup_trans_cth_label" style="width: 50px; font-weight: bold;">
                           Desc
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 64px; font-weight: bold;">
                            QTY Code
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 104px; font-weight: bold;">
                            Scheme Code
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 70px; font-weight: bold;">
                            RITC NO
                        </div>
                        <%--<div id="tag_label_transaction_popup_trans_cth_label" style="width: 50px; font-weight: bold;">
                            STR
                        </div>--%>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 55px; font-weight: bold;">
                            Reward
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 63px; font-weight: bold;">
                            RODTEP
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 55px; font-weight: bold;">
                            Cess
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 70px; font-weight: bold;">
                            EndUse
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 104px; font-weight: bold;">
                            Under PTA/FTA
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 120px; font-weight: bold;">
                            IGST Pay Sts & %
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 70px; font-weight: bold;">
                            Dbk Slno
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 64px; font-weight: bold;">
                            Dbk Unit
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;
                            font-weight: bold;">
                            <asp:Button ID="btnLoad" runat="server" Text="Apply Filter" Width="90px" UseSubmitBehavior="false"
                                Height="26px" ForeColor="White" OnClick="btnLoad_Click" Style="font-weight: bold;" CssClass="btn-filter" /></div>
                    </div>
                    <div id="tag_srcinner1" style="height: 43px; width: 1170px;">
                        <div id="txtcon-m_transaction_item_maindet" style="width: 35px; font-weight: bold;">
                            Item
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 140px;">
                            <asp:ListBox ID="ListBox_ItemSlno" SelectionMode="Multiple" Height="25px" Width="60px"
                                ViewStateMode="Enabled" runat="server"></asp:ListBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 66px;">
                            <asp:TextBox ID="txtDescription" Width="55px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                                ClientIDMode="Static" TabIndex="1" Height="30px"></asp:TextBox>
                        </div>
                         <div id="tag_label_transaction_popup_trans_cth_label" style="width: 55px;">
                             <asp:TextBox ID="txt_QtyCode" Width="45px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                                ClientIDMode="Static" TabIndex="1" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 102px;">
                            <asp:DropDownList ID="ddlSchemeCode" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                TabIndex="1" Height="30px" Width="90px">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 70px;">
                            <asp:TextBox ID="txtRITCNo" Width="60px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                                ClientIDMode="Static" TabIndex="1" Height="30px"></asp:TextBox>
                        </div>
                       <%-- <div id="tag_label_transaction_popup_trans_cth_label" style="width: 55px;">
                            <asp:DropDownList ID="ddl_STR_YN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                TabIndex="1" Height="30px" Width="45px">
                                <asp:ListItem Value="N">No</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 53px;">
                            <asp:DropDownList ID="ddlRewardPoints" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                TabIndex="1" Height="30px" Width="45px">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 65px;">
                            <asp:DropDownList ID="ddl_Rodtep_YN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                Width="55px" TabIndex="1" Height="30px">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 55px;">
                            <asp:DropDownList ID="ddl_Cess_YN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                Width="45px" TabIndex="1" Height="30px">
                                <asp:ListItem Value="N">No</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 70px;">
                            <asp:TextBox ID="txtEnduseItem" runat="server" onkeyup="autotab(this);" TabIndex="1"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="15" Width="60px" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 102px;">
                            <asp:TextBox ID="txt_PTA_FTA" runat="server" onkeyup="autotab(this);" TabIndex="1"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="15" Width="90px" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 120px;">
                            <asp:DropDownList ID="ddl_IGST_Payment" runat="server" CssClass="listtxt_transac_mode_new"
                                Width="55px" TabIndex="1" Height="30px" AutoPostBack="true" OnSelectedIndexChanged="ddl_IGST_Payment_SelectedIndexChanged">
                                <asp:ListItem>NA</asp:ListItem>
                                <asp:ListItem>LUT</asp:ListItem>
                                <asp:ListItem>P</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txt_IGST_Rate" runat="server" MaxLength="19" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="1" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" Width="50px" Height="30px"
                                Enabled="false"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 70px;">
                            <asp:TextBox ID="txt_Drawback_SLNo" runat="server" CssClass="txtbox_trans_exp_drawback"
                                ClientIDMode="Static" onkeypress="return charnum2(event)" MaxLength="15" TabIndex="1"
                                Width="63px" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width: 64px;">
                            <asp:TextBox ID="txt_DBK_Unit" runat="server" MaxLength="19" CssClass="autocomplete txtbox_none_Mid_transac_code"
                                TabIndex="1" Width="60px" Height="30px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;
                            font-weight: bold;">
                            <asp:Button ID="btn_bulk_Update_All" runat="server" Text="Apply to All" UseSubmitBehavior="false"
                                Width="90px" Height="30px" ForeColor="White" OnClick="btn_bulk_Update_All_Click" CssClass="btn-filter1"
                                Style="font-weight: bold;" />
                        </div>
                    </div>
                </fieldset>
            </div>
            <div class="content" id="page-1" style="margin-left: -20px; margin-bottom: 10px;">
                <div id="open_item" runat="server">
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 300px;
                            width: 966px; margin-top: -15px;">
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 300px;
                                width: 1170px;">
                                <asp:GridView ID="gv_ItemPDF" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" OnRowCreated="gv_ItemPDF_RowCreated" OnRowDataBound="gv_ItemPDF_RowDataBound"
                                    ShowHeaderWhenEmpty="True">
                                    <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle Font-Bold="true" />
                                    <HeaderStyle BorderWidth="1px" BorderColor="Gray" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Inv Sl.No" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtInvSlNo" runat="server" Text='<%#Eval("INVOICE_SLNO") %>' MaxLength="3"
                                                    Enabled="false" Width="70px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Sl.No" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtItemSlNo" runat="server" Text='<%#Eval("ITEM_SLNO") %>' MaxLength="3"
                                                    Enabled="false" Width="70px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Description *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="332px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtItemDesc" runat="server" Text='<%#Eval("ITEM_DESC") %>' TabIndex="1" ClientIDMode="Static"
                                                    Width="332px" Height="25px" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px" Visible="false">
                                            <ItemTemplate>
                                             <a href="#" style="width:28px;height:20px;" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupProduct_Export_Product_Master('EXP_GET_PRODUCT');check(); return false"
                                    class="magnfy"></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Qty *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtItemQty" runat="server" Text='<%#Eval("ITEM_QTY") %>' MaxLength="10"
                                                    Enabled="false" Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name" onblur="validateDecimalValue(this);"></asp:TextBox>
                                                    <span class="error-msg" style="display:none;"></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Qty Code *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQtyCode" runat="server" Text='<%#Eval("ITEM_QTY_CODE") %>' MaxLength="3" ClientIDMode="Static"
                                                     Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Unit Price *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtItemUnitPrice" runat="server" Text='<%#Eval("ITEM_UNITPRICE") %>'
                                                    Enabled="false" MaxLength="10" Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name" onblur="validateDecimalValue(this);"></asp:TextBox>
                                                    <span class="error-msg" style="display:none;"></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Amt *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtItemAmt" runat="server" Text='<%#Eval("ITEM_AMOUNT") %>' MaxLength="10"
                                                    Enabled="false" Width="100px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name" onblur="validateDecimalValue(this);"></asp:TextBox>
                                                    <span class="error-msg" style="display:none;"></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme Code *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="160px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_SchemeCode" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                                    TabIndex="1" Height="25px" Width="160px" DataTextField="SCHEME_CODE" DataValueField="SCHEME_CODE">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <%--  <asp:TemplateField HeaderText="RITC No *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_RITCNo" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                                    Onkeypress="return num5(event)" Width="100px" Height="25px"
                                                    MaxLength="8" TabIndex="1" Text='<%#Eval("RITCNO") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                         <asp:TemplateField HeaderText="RITC *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="120px">
                                            <ItemTemplate>
                                                <div style="display: inline-flex; align-items: center; gap: 2px; white-space: nowrap;">
                                                    <asp:TextBox ID="txt_RITCNo" runat="server" CssClass="txt-cth txtbox_none_Mid_transac_item_maindet"
                                                        Onkeypress="return num5(event)" Width="78px" Height="22px" MaxLength="8" TabIndex="1"
                                                        Text='<%#Eval("RITCNO") %>' Style="font-size: 11px;"></asp:TextBox>
                                                    <button type="button" title="Load All CTH from Master" style="font-size: 10px; padding: 1px 3px;
                                                        cursor: pointer; background: #17a2b8; color: white; border: none; border-radius: 3px;
                                                        height: 22px; width: 20px; line-height: 1; flex-shrink: 0;" onclick="loadAllCTH(this); return false;">
                                                        &#128269;</button>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="STR (Y/N) *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_STRYN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                                    TabIndex="1" Height="25px" Width="100px" SelectedValue='<%# Eval("STR_YES_NO") %>'>
                                                     <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reward Points (Y/N) *" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_Reward_Points" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                                    TabIndex="1" Height="25px" Width="130px" SelectedValue='<%# Eval("REWARD_YES_NO") %>'>
                                                      <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RODTEP (Y/N) *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_RodtepYN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                                    Width="100px" TabIndex="1" Height="25px" SelectedValue='<%# Eval("RODTEP") %>'>
                                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cess Details (Y/N) *" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="120px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_CessYN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                                    Width="120px" TabIndex="1" Height="25px" SelectedValue='<%# Eval("CESS_YN") %>'>
                                                       <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Use Of Items *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="120px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtEndUseOfItems" runat="server" MaxLength="10" TabIndex="1" Width="120px"
                                                    Text='<%#Eval("END_USE_OF_ITEM") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                    onkeyup="autotab(this);"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Under PTA/FTA *" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="200px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtUnderPTA" runat="server" MaxLength="10" TabIndex="1" Width="200px"
                                                    Text='<%#Eval("UNDER_PTA_FTA") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IGST Payment Status *" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_IGSTPayment" runat="server" CssClass="listtxt_transac_mode_new"
                                                    AutoPostBack="true" Width="130px" TabIndex="1" Height="25px" SelectedValue='<%# Eval("IGST_PAYMENT") %>'
                                                    OnSelectedIndexChanged="ddl_IGSTPayment_SelectedIndexChanged">
                                                     <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>LUT</asp:ListItem>
                                                    <asp:ListItem>P</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IGST Rate%" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_IGSTRate" runat="server" MaxLength="10" TabIndex="16" Width="100px"
                                                    Text='<%#Eval("IGST_RATE") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dbk Slno" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtDrawback_SLNo" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                                    Text='<%#Eval("DBK_SL_NO") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dbk Unit" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtDBK_Unit" runat="server" MaxLength="10" TabIndex="1" Width="100px"
                                                    Text='<%#Eval("DBK_UNIT") %>' ClientIDMode="Static" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans" style="width: 1235px; height: 3px; margin-top: -35px;
                margin-left: -40px;">
            </div>
            <div id="tag_transac_lft_in2" style="margin-top: 10px;">
                <div id="txtcon-m_Exchange" style="width: 545px;">
                <asp:Label ID="Label2" runat="server" 
        Text="Note: If Some Item descriptions (shown in red) have special characters. Please remove or replace them before uploading to avoid errors." 
        CssClass="note-label" Style="display:none;"></asp:Label>
                </div>
                <div id="txtcon-m_Exchange" style="width: 100px;">               
                    <asp:Button ID="btnupload" runat="server" Width="100px" Height="30px" Text="UPLOAD"
                        CssClass="autowidmovebut" OnClick="btnupload_Click" Visible="false" />
                </div>
                <div id="txtcon-m_Exchange" style="width: 200px;">
                    <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
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
            <asp:HiddenField ID="hdn_companyID" runat="server" />
            <asp:HiddenField ID="hd_TransportMode" runat="server" />
            <asp:HiddenField ID="hd_PageCount" runat="server" />
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
                CausesValidation="false" UseSubmitBehavior="false" Style="margin-left: 100px;" />
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
                            <asp:TextBox ID="txt_Temp_Currency" runat="server" Text='<%#Eval("Currency") %>' ClientIDMode="Static"
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
            <asp:Button ID="btn_Inv_Save" runat="server" Width="100px" Style="margin-left: 200px;margin-top: 100px;"
             Height="30px" Text="Inv save" CssClass="autowidmovebut" Visible="false" UseSubmitBehavior="true"
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
        <!-- Logo or icon -->
        <div style="margin-bottom: 15px;">
            <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/images/Company_Logo/IPAN.PNG"
                Height="40px" Width="60px" Style="margin-top: -5px;" />
        </div>
        <!-- Main message -->
        <div style="font-size: 18px; font-weight: bold; color: #28a745; margin-bottom: 10px;">
            &#9989; Job Created Successfully!
        <!-- Checklist reminder -->
        <div style="font-size: 14px; color: #444;">
            📋 Ensure that all data entries are validated against the checklist before proceeding with flat file submission.
        </div>
        <!-- Button -->
        <br />
        <button onclick="closePopup()" style="margin-top: 15px; padding: 8px 18px; background-color: #28a745;
            color: white; border: none; border-radius: 6px; cursor: pointer; font-size: 14px;">
            OK, Got It
        </button>
    </div>
    </div>

    </form>
    <%--<script src="../js/Export_Jscript/Export_Item.js" type="text/javascript"></script>--%>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
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


        //        $(function () {
        //            $('#txtRITCNo,#txt_RITCNo').autocomplete({
        //                source: function (request, response) {
        //                    $.ajax({
        //                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXPORT_RITC_MASTER_List",

        //                        data: "{ 'mail': '" + request.term + "' }",
        //                        dataType: "json",
        //                        type: "POST",
        //                        contentType: "application/json; charset=utf-8",
        //                        dataFilter: function (data) { return data; },
        //                        async: true,
        //                        success: function (data) {
        //                            response(data.d);
        //                            if (data.d == '') {
        //                                jQuery('#txtRITCNo').validationEngine('showPrompt', 'Incorrect RITCNo', 'error', 'topRight', true);

        //                                //jAlert('RITCNo is Incorrect', 'ITEM', function (r) { document.getElementById("txtRITCNo').focus(); });
        //                                //return false;
        //                            }
        //                            else {
        //                                jQuery('#txtRITCNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
        //                            }
        //                        },
        //                        error: function (XMLHttpRequest, textStatus, errorThrown) {
        //                          
        //                        }
        //                    });
        //                },
        //                minLength: 1

        //            });
        //            return false;
        //            scroll: true;
        //        });

        $(document).ready(function () {

            // ── Initialize CTH autocomplete for ALL txt-cth textboxes ──────
            function initCTHAutocomplete($el) {
                var mode = $el.attr("data-cth-mode") || "empty";
                var cthListRaw = $el.attr("data-cth-list") || "[]";
                var cthListDS = [];

                try { cthListDS = JSON.parse(cthListRaw); } catch (e) { cthListDS = []; }

                if ($el.data("ui-autocomplete")) {
                    $el.autocomplete("destroy");
                }

                if (mode === "single") {
                    $el.autocomplete({
                        source: function (request, response) {
                            var term = request.term.toLowerCase();
                            var filtered = $.grep(cthListDS, function (item) {
                                return item.toLowerCase().indexOf(term) >= 0;
                            });
                            response(filtered);
                        },
                        minLength: 0,
                        select: function (event, ui) {
                            $(this).css("border", "");
                            $(this).trigger("change");
                        }
                    });

                } else if (mode === "multi") {
                    $el.autocomplete({
                        source: function (request, response) {
                            var term = request.term.toLowerCase();
                            var filtered = $.grep(cthListDS, function (item) {
                                return item.toLowerCase().indexOf(term) >= 0;
                            });
                            response(filtered);
                        },
                        minLength: 0,
                        select: function (event, ui) {
                            $(this).css("border", "");
                            $(this).trigger("change");
                        }
                    });

                } else {
                    // Empty: load all from master — NO button highlight on load
//                    attachMasterAutocomplete($el);
                }
            }


            // ── Master autocomplete (full list from web service) ───────────
            function attachMasterAutocomplete($el) {
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
                            success: function (data) {
                                response(data.d);
                            },
                            error: function () { response([]); }
                        });
                    },
                    minLength: 1,
                    select: function (event, ui) {
                        $(this).css("border", "");
                        $(this).trigger("change"); // trigger AIDC/IGST load
                    }
                });
            }

            window.loadAllCTH = function (btn) {
                var $btn = $(btn);
                var $textbox = $btn.closest("div").find(".txt-cth");
                var isShowingAll = $btn.data("showing-all") || false;

                if (!isShowingAll) {
                    // Switch to master list
                    if ($textbox.data("ui-autocomplete")) {
                        $textbox.autocomplete("destroy");
                    }
                    attachMasterAutocomplete($textbox);
                    $textbox.val('');
                    $textbox.focus();
                    setTimeout(function () {
                        $textbox.autocomplete("search", "");
                    }, 100);
                    $btn.css("background", "#28a745").attr("title", "Showing ALL CTH - Click to go back").text("✓");
                    $btn.data("showing-all", true);

                } else {
                    // Switch back to row's DS list
                    if ($textbox.data("ui-autocomplete")) {
                        $textbox.autocomplete("destroy");
                    }
                    initCTHAutocomplete($textbox);
                    $btn.css("background", "#17a2b8").attr("title", "Load All CTH from Master").text("🔍");
                    $btn.data("showing-all", false);
                }
            };

            // ── Initialize all grid rows on page load ──────────────────────
            $(".txt-cth").each(function () {
                if ($(this).attr("id") === "txtRITCNo") return; // skip header textbox
                initCTHAutocomplete($(this));
            });

            // ── Also handle main header txtCTH (existing behavior) ─────────
            $("#txtRITCNo").autocomplete({
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

        if ($('#hdn_companyID').val() != '517') {
            $(document).ready(function () {
                $('#<%= gv_ItemPDF.ClientID %> tr').each(function () {
                    var ddl = $(this).find('.listtxt_transac_mode_new').val();
                    var txtBox = $(this).find('[id$="txt_IGSTRate"]');
                    if (ddl == 'LUT' || ddl == 'NA') {
                        txtBox.prop('disabled', true); // Enable TextBox
                        txtBox.val(''); // Clear the value
                    } else {
                        txtBox.prop('disabled', false); // Disable TextBox                   
                    }
                });
            });
        }
    
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#ddlSchemeCode').bind('focus keyup keypress change keydown', function () {
                var scheme1 = $('option:selected', $(this)).text();

                if ($('#hdn_companyID').val() == '517' || $('#hdn_companyID').val() == '10') {
                    if (scheme1 == "60-DRAWBACK AND ROSCTL") {
                        $('#ddl_Rodtep_YN').val('N');
                    }
                    else if (scheme1 == "00-FREE SHIPPING BILL" || scheme1 == "19-DRAWBACK (DBK)") {
                        $('#ddl_Rodtep_YN').val('Y');
                    }
                }


                //             if ($('#hdn_companyID').val() == '1572' || $('#hdn_companyID').val() == '758' || $('#hdn_companyID').val() == '10') {
                if (scheme1 == "60-DRAWBACK AND ROSL" || scheme1 == "60-DRAWBACK AND ROSCTL" || scheme1 == "61-EPCG, DRAWBACK AND ROSL" || scheme1 == "61-EPCG, DRAWBACK AND ROSCTL" || scheme1 == "62-DRAWBACK AND SPL AA" || scheme1 == "63-EPCG,DRAWBACK AND SPL AA" || scheme1 == "64-DRAWBACK, SPL AA ( 4.04A) AND ROSCTL" || scheme1 == "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSCTL") {
                    $('#ddl_Rodtep_YN').val('NA');
                }
                //             }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#txtCountry").autocomplete({
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


                                jQuery('#txtCountry').validationEngine('showPrompt', 'Incorrect Country Origin', 'error', 'topRight', true);

                            }
                            else {
                                jQuery('#txtCountry').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
            $("#txtPort").autocomplete({

                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
                        data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdfTransport_mode").value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {

                            if (data.d == '') {
                                if (field == 'txtPort') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Discharge', 'error', 'topRight', true);

                                }

                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                            response(data.d);
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
            $('#txtCurrency,#txt_Temp_Currency').autocomplete({
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
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Invoice Currency', 'error', 'topRight', true);

                                    //jAlert('Invoice Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                    //return false;
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
            $("#txt_Third_Party_Details").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD",
                        data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {

                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txt_Third_Party_Details').validationEngine('showPrompt', 'Incorrect Third Party Name', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_Third_Party_Details').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exp_Item_Desc_List",

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

                                //jAlert('Branch SLNo is Incorrect', 'ITEM', function (r) { document.getElementById("txtBranchSLNo').focus(); });
                                // return false;
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
    $(document).ready(function () {
        function checkSpecialChars() {
            var hasSpecial = false;
            $("input[type='text'][id*='txtItemDesc']").each(function () {
                var val = $(this).val();
                var regex = /[^\u0000-\u007F]/; // non-ASCII chars

                if (regex.test(val)) {
                    $(this).css({
                        "background-color": "sandybrown",
                        "color": "red",
                        "font-weight": "bold"
                    });
                    $(this).attr("title", "Special characters detected. Please change.");
                    hasSpecial = true;
                } else {
                    $(this).css({
                        "background-color": "white",
                        "color": "black",
                        "font-weight": "normal"
                    });
                    $(this).removeAttr("title");
                }
            });

            // Show or hide warning label
            if (hasSpecial) {
                $("#<%= Label2.ClientID %>").show();
            } else {
                $("#<%= Label2.ClientID %>").hide();
            }
        }

        // Initial check
        checkSpecialChars();

        // Re-check on typing
        $("input[type='text'][id*='txtItemDesc']").on("input", function () {
            checkSpecialChars();
        });
    });
</script>

<script type="text/javascript">
    function validateDecimalValue(txt) {
        var value = txt.value.trim();
        // ✅ Accepts whole numbers, and decimals (up to 4 places)
        var regex = /^\d+(\.\d+)?$/;
        var errorMsg = txt.parentNode.querySelector('.error-msg');

        if (value !== "" && !regex.test(value)) {
            // Invalid → Highlight red
            txt.classList.add('error-border');
            if (errorMsg) {
                errorMsg.textContent = "Invalid number format";
                errorMsg.style.display = "block";
            }

            // Show popup once
            if (!txt.dataset.alerted) {
                alert("Please check the qty or rate or amt — invalid decimal value!");
                txt.dataset.alerted = "true";
            }
        } else {
            // Valid → Remove red border
            txt.classList.remove('error-border');
            if (errorMsg) errorMsg.style.display = "none";
            txt.dataset.alerted = "";
        }
    }

    // ✅ Run this automatically when grid is bound
    window.addEventListener('load', function () {
        var allTxtBoxes = document.querySelectorAll('input[id*="txtItemUnitPrice"]');
        allTxtBoxes.forEach(function (txt) {
            validateDecimalValue(txt);
        });
    });
    // ✅ Run this automatically when grid is bound
    window.addEventListener('load', function () {
        var allTxtBoxes = document.querySelectorAll('input[id*="txtItemQty"]');
        allTxtBoxes.forEach(function (txt) {
            validateDecimalValue(txt);
        });
    });
    // ✅ Run this automatically when grid is bound
    window.addEventListener('load', function () {
        var allTxtBoxes = document.querySelectorAll('input[id*="txtItemAmt"]');
        allTxtBoxes.forEach(function (txt) {
            validateDecimalValue(txt);
        });
    });
</script>
 <script type="text/javascript">
     $(document).ready(function () {

         // Initialize DatePicker
         $("#txtInvoiceDate").datepicker({
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
                 validateInvoiceDate($("#txtInvoiceDate"));
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
         $("#txtInvoiceDate").on("blur", function () {
             validateInvoiceDate($(this));
         });

         // Validate while typing
         $("#txtInvoiceDate").on("input", function () {
             validateInvoiceDate($(this));
         });

         // Auto validate on page load
         validateInvoiceDate($("#txtInvoiceDate"));


     });
</script>
<script type="text/javascript">
    $(document).ready(function () {

        function validateField($el, maxLen, errClass, label) {
            var val = $el.val().replace(/\s/g, '');
            if (val.length > maxLen) { val = val.substring(0, maxLen); $el.val(val); }
            $el.siblings('.' + errClass).remove();

            if (val.length > 0 && val.length != maxLen) {
                // ── Invalid length — show red border ──
                $el.css({ 'border': '2px solid red', 'background-color': '#fff0f0' });
                $el.attr('title', label + ' must be exactly ' + maxLen + '. Currently: ' + val.length);
            } else {
                // ── Valid length — clear border, also clear invalid-ritc class ──
                $el.css({ 'border': '1px solid #ccc', 'background-color': '' });
                $el.removeAttr('title');
                $el.removeClass('invalid-ritc'); // ← THIS IS THE FIX
            }
        }

        // ── Event Binding ────
        $(document).on('keyup change input blur', '[id*="txtQtyCode"]', function () {
            validateField($(this), 3, 'qty-error', 'QTY Code');
        });

        $(document).on('keyup change input blur', '[id*="txt_RITCNo"]', function () {
            if ($(this).attr('id') === 'txtRITCNo') return;
            validateField($(this), 8, 'ritc-error', 'RITC No');
        });

        // ── Page Load ────
        $('[id*="txtQtyCode"]').each(function () {
            validateField($(this), 3, 'qty-error', 'QTY Code');
        });

        $('[id*="txt_RITCNo"]').each(function () {
            if ($(this).attr('id') === 'txtRITCNo') return;
            validateField($(this), 8, 'ritc-error', 'RITC No');
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
$(document).ready(function () {

    let popupShown = false;

    function showSinglePopup() {
        if (!popupShown) {
            popupShown = true;
            alert("Invalid CTH detected — please check highlighted fields.");
            setTimeout(function () {
                popupShown = false;
            }, 5000);
        }
    }
    function markInvalid($el) {
        $el.css("border", "2px solid red");
        $el.addClass("invalid-ritc");
    }
    function clearInvalid($el) {
        $el.css("border", "");
        $el.removeClass("invalid-ritc");
    }
    function validateRITC($el) {

        var val = $el.val().trim();
        if (val === "") {
            clearInvalid($el);
            return true;
        }
        var isValid = true;
        $.ajax({
            url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXPORT_RITC_MASTER_List",
            data: "{ 'mail': '" + val + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            async: false,  
            success: function (data) {
                if (!data.d || data.d.length === 0) {
                    markInvalid($el);
                    isValid = false;
                } else {
                    clearInvalid($el);
                }
            },
            error: function () {
                markInvalid($el);
                isValid = false;
            }
        });

        return isValid;
    }
    // autocomplete attach
    $("#txtRITCNo, #txt_RITCNo, .txt_RITCNo").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXPORT_RITC_MASTER_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response(data.d);
                }
            });
        },
        minLength: 1,
        select: function () {
            clearInvalid($(this));
        },
        change: function (event, ui) {
            if ($(this).val().trim() === "") {
                clearInvalid($(this));
                return;
            }
            if (!ui.item) {
                markInvalid($(this));
                showSinglePopup();
            } else {
                clearInvalid($(this));
            }
        }
    });

    // validate loaded values
    $("#txtRITCNo, #txt_RITCNo, .txt_RITCNo").each(function () {
        validateRITC($(this));
    });
    $("[id*=btnupload]").click(function (e) {

        let allValid = true;

        $("#txtRITCNo, #txt_RITCNo, .txt_RITCNo").each(function () {
            if (!validateRITC($(this))) {
                allValid = false;
            }
        });

        if (!allValid) {
            showSinglePopup();
            e.preventDefault();
            return false;  
        }
        return true;
    });
});
</script>
<%--//VALIDATION--%>
  <script type="text/javascript">
      var exportFields = [
    "txtInvoiceNo", "txtInvoiceDate", "txtConsigneeName", "txtExporterName",
    "ddlTerms", "txtCurrency", "txtCountry", "txtPort",
    "txtItemDesc", "txtItemQty", "txtQtyCode", "txtItemUnitPrice",
    "txtItemAmt", "ddl_SchemeCode", "txt_RITCNo", "ddl_STRYN",
    "ddl_Reward_Points", "ddl_RodtepYN", "ddl_CessYN",
    "txtEndUseOfItems", "txtUnderPTA", "ddl_IGSTPayment"
];
      function setBorder($el, isEmpty) {
          $el.css("border", isEmpty ? "2px solid red" : "1px solid #ccc");
      }
      function isEmpty($el) {
          var v = ($el.val() || "").trim();
          return v === "" || v === "--Select--" || v === "0";
      }

      $(document).on("click", '[id*="btnupload"]', function (e) {
          var $first = null;

          $.each(exportFields, function (i, name) {
              var $el = $('[id*="' + name + '"]');
              if (!$el.length) return;
              var empty = isEmpty($el);
              setBorder($el, empty);
              if (empty && !$first) $first = $el;
          });

          if ($first) {
              e.preventDefault();
              e.stopPropagation();
              setTimeout(function () {
                  $first[0].scrollIntoView({ behavior: "smooth", block: "center" });
                  $first.focus();
              }, 100);
              return false;
          }
          $('#lbl_loading').html('<span style="color:orange;font-weight:bold;">&#9203; Saving Processed... Please wait.</span>');
          return true;
      });
      $(document).on("keyup change input blur", "input, select", function () {
          var $el = $(this);
          var id = $el.attr("id") || "";
          var isTracked = exportFields.some(function (name) { return id.indexOf(name) !== -1; });
          if (isTracked) setBorder($el, isEmpty($el));
      });
          var RITC_Gobal = <%= HSCodeJson %>;
 
         function Bind_RITC_Autocomplete()
          {

    $('#<%= gv_ItemPDF.ClientID %> .txt_RITCNo').autocomplete({
        source: RITC_Gobal,
        minLength: 0
    }).focus(function () {
        $(this).autocomplete("search", "");
    });
   }
</script>
</body>
</html>