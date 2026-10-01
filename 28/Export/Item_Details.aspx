<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Item_Details.aspx.cs" Inherits="Export_Item_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Item | Transaction</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />

 
    <script type="text/javascript">

        // &#9989; SetRITCPolicy &#8212; shows label with correct color
        function SetRITCPolicy(val2) {
            var policyLabel = document.getElementById("lblRITCPolicy");

            if (policyLabel) {
                if (!val2 || val2.trim() === '' || val2 === 'null' || val2 === 'No Policy') {
                    policyLabel.innerText = 'Not Available';
                    policyLabel.style.color = '#ffffff';
                    policyLabel.style.backgroundColor = '#808080';
                    policyLabel.style.border = '1px solid #808080';
                }
                else if (val2 === 'Restricted') {
                    policyLabel.innerText = 'Restricted';
                    policyLabel.style.color = '#ffffff';
                    policyLabel.style.backgroundColor = '#FF8C00';
                    policyLabel.style.border = '1px solid #FF8C00';
                }
                else if (val2 === 'Free') {
                    policyLabel.innerText = 'Free';
                    policyLabel.style.color = '#ffffff';
                    policyLabel.style.backgroundColor = '#007700';
                    policyLabel.style.border = '1px solid #007700';
                }
                else if (val2 === 'Prohibited') {
                    policyLabel.innerText = 'Prohibited';
                    policyLabel.style.color = '#ffffff';
                    policyLabel.style.backgroundColor = '#cc0000';
                    policyLabel.style.border = '1px solid #cc0000';
                }
                else {
                    policyLabel.innerText = val2;
                    policyLabel.style.color = '#333';
                    policyLabel.style.backgroundColor = '#f5f5f5';
                    policyLabel.style.border = '1px solid #ccc';
                }

                // &#9989; Show label permanently
                policyLabel.style.display = 'inline-block';
            }
        }

        // &#9989; Restore policy after every postback
        function RestoreRITCPolicy() {
            $.ajax({
                type: "POST",
                url: "Item_Details.aspx/GetSavedRITCPolicy",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d && response.d !== '') {
                        SetRITCPolicy(response.d); // &#9989; Restore label
                    }
                },
                error: function (err) {
                    // silent fail
                }
            });
        }

        // &#9989; pageLoad fires after EVERY postback including UpdatePanel
        // This is more reliable than $(document).ready for ASP.NET
        function pageLoad() {
            RestoreRITCPolicy();
        }

</script>

    <script type="text/javascript">
        function checkTextAreaMaxLength_CompanyWise(textBox, e) {
            var aa = document.getElementById("hdn_companyID").value;
            //                        alert(aa);
            if (aa == '203') {
                length = '500';
            }
            else if (aa == '268') {
                length = '200';
            }
            else if (aa == '285') {
                length = '200';
            }
            else if (aa == '441') {
                length = '500';
            }
            else if (aa == '477') {
                length = '500';
            }
            else if (aa == '495') {
                length = '500';
            }
            else if (aa == '538') {
                length = '500';
            }
            else if (aa == '539') {
                length = '500';
            }
            else if (aa == '747') {
                length = '500';
            }
            else if (aa == '1088') {
                length = '500';
            }
            else if (aa == '1135') {
                length = '500';
            }
            else if (aa == '2188') {
                length = '500';
            }
            else if (aa == '2145') {
                length = '500';
            }
            else {
                length = '120';
            }

            var paste = (event.clipboardData || window.clipboardData).getData('text');
            var regex = /^[\x00-\x7F]+$/;
            if (!regex.test(paste)) {
                event.preventDefault();
                alert('Check the Spl Character');
            }

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;
            //             alert(length);
            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                    {
                        e.returnValue = false;
                        return false;
                    }
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
    </script>

    <script type="text/javascript">

        function cal_dbk_avail() {
            $.ajax({
                type: "POST",
                url: "Item_Details.aspx/Check_DBK_Avail_js",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d == "OK") {
                        alert("OK")
                    } else {
                        var reslt = msg.d;

                        //                                                alert(msg.d);
                        //                        $('#hdn_DWBK_QTY').val(reslt);
                        $('#hdn_dbk_Qty').val(reslt);
                        //                                                                        alert(reslt);
                    }
                }
            });
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

    <script type="text/javascript">
        window.onload = function () {

            var scroll = document.getElementById("hdn_grid_scroll_retain").value;
            // alert(scroll);

            if (scroll == 'true') {
                var strCook = document.cookie;
                // alert(strCook);
                if (strCook.indexOf("!~") != 0) {
                    var intS = strCook.indexOf("!~");
                    var intE = strCook.indexOf("~!");
                    var strPos = strCook.substring(intS + 2, intE);
                    document.getElementById("tag_transac_export_lft_item_gen_Grid_area_new1").scrollTop = strPos;
                }
            }
        }
        function SetDivPosition() {
            var intY = document.getElementById("tag_transac_export_lft_item_gen_Grid_area_new1").scrollTop;
            document.cookie = "yPos=!~" + intY + "~!";
        }

    </script>

    <style type="text/css">
        /*------ Its for Gridview Header row Freeze by Chithra on 31-08-2023*/
        .header
        {
            font-weight: bold;
            position: absolute;
            background-color: White;
            width: 690px;
        }
    </style>

    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        
        
        .hideGridColumn
        {
            display: none;
        }
        .hideGridColumn1
        {
            display: none;
        }
        
        .grid-view tr.header
        {
            border: solid 1px Black;
        }
        
        .tag_transac_export_lft_item_gen_Grid_area_new_header
        {
            width: 695px;
            height: 140px;
            float: left;
            margin-bottom: 20px;
            background-color: #ffffff;
            overflow: scroll;
            border: solid #c8c8c8 thin;
        }
    </style>

    <style type="text/css">
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }
        
        #tag_transac_lft_in1_export2
        {
            width: 505px;
            height: 25px;
            margin: auto;
        }
        
        #tag_label_transaction_export_popup_Item_maindet2
        {
            float: left;
            width: 105px;
            height: 15px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            line-height: 20px;
            text-align: left;
            color: #232323;
        }
        
        #tag_label_transaction_Src_new2
        {
            float: left;
            width: 75px;
            height: 15px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            line-height: 20px;
            text-align: left;
            color: #232323;
        }
    </style>

    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script type="text/javascript">
        function DisableSpecialKeyEvents() {

            var nav = window.Event ? true : false;
            document.onkeydown = Keypress_Event;
            function Keypress_Event() {
                if (event.keyCode == 13)
                { return false; }
            }
        }

    </script>

    <script type="text/javascript">

        function HideModalPopup_Job() {

            $find("MP_JOB").hide();
            return false;
        }

        function HideModalPopup_U() {
            $('#txtItem_UnitPrice').focus();
            $find("MP_U").hide();
            return false;
        }

        function HideModalPopup_DBK() {
            $find("MPU_DBK").hide();
            return false;
        }
    </script>

    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>

    <script type="text/javascript">

        function HideModalPopup() {
            $find("MPEU").hide();
            return false;
        }

        function Drawback() {
            // Parent_tab_count('');
            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'Block';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("page-5").style.display = 'none';
            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'none';
            document.getElementById("page-8").style.display = 'none';

            document.getElementById("page-9").style.display = 'none';
            document.getElementById("page-10").style.display = 'none';

            document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
            var Qty = document.getElementById("txtItemQty").value;
            document.getElementById("pop_text_area_transac_item_drawback_iframe").src = "../Export/Export_Drawback.aspx?Qty=" + Qty + "";
            document.getElementById("Export_Item").style.display = 'Block';

            document.getElementById("ITEM_ID").className = 'inactive';
            document.getElementById("DBK").className = ' active';
        }
        function EPCG() {

            //Parent_tab_count('');

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("page-5").style.display = 'Block';
            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'none';
            document.getElementById("page-8").style.display = 'none';
            document.getElementById("page-9").style.display = 'none';
            document.getElementById("page-10").style.display = 'none';

            document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
            document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx?Scheme=EPCG &License_Scheme=EPCG";
            document.getElementById("Export_Item").style.display = 'none';

            document.getElementById("ITEM_ID").className = 'inactive';
            document.getElementById("Scheme_EPCG").className = ' active';

        }

        function DFIA() {

            //Parent_tab_count('');

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("page-5").style.display = 'Block';
            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'none';
            document.getElementById("page-8").style.display = 'none';
            document.getElementById("page-9").style.display = 'none';
            document.getElementById("page-10").style.display = 'none';

            document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
            document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx?Scheme=DFIA&License_Scheme=DFIA";
            document.getElementById("Export_Item").style.display = 'none';

            document.getElementById("ITEM_ID").className = 'inactive';
            document.getElementById("Scheme_DFIA").className = ' active';

        }

        function DEEC() {

            // Parent_tab_count('');
            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("page-5").style.display = 'Block';
            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'none';
            document.getElementById("page-8").style.display = 'none';
            document.getElementById("page-9").style.display = 'none';
            document.getElementById("page-10").style.display = 'none';

            document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
            document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx?Scheme=DEEC&License_Scheme=DEEC";
            document.getElementById("Export_Item").style.display = 'none';

            document.getElementById("ITEM_ID").className = 'inactive';
            document.getElementById("Scheme_DEEC").className = ' active';
        }
        function Jobbing() {
            // Parent_tab_count('');

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'Block';
            document.getElementById("page-5").style.display = 'none';
            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'none';
            document.getElementById("page-8").style.display = 'none';

            document.getElementById("page-9").style.display = 'none';
            document.getElementById("page-10").style.display = 'none';
            document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
            document.getElementById("pop_text_area_transac_item_Jobbing_iframe").src = "../Export/Export_Jobbing.aspx";
            document.getElementById("Export_Item").style.display = 'Block';

            document.getElementById("ITEM_ID").className = 'inactive';
            document.getElementById("Scheme_Jobbing").className = ' active';

        }
            
    </script>

    <script type="text/javascript">
        function CheckCharCounter(textBox, maxLength) {

            var charCount = maxLength - textBox.value.length;

            $('#lblcnt').val(textBox.value.length);
            if (charCount >= 0) {
                document.getElementById("txtDescription").style.color = "black";
                $('#lblcnt').attr('style', 'width:20px;border-style: none;background-color:white;color:black');
            }
            else {
                document.getElementById("txtDescription").style.color = "red";
                $('#lblcnt').attr('style', 'width:20px;border-style: none;background-color:white;color:red');
            }
        }
    </script>

</head>
<body id="bg2popup" topmargin="0">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="Is_Inv" runat="server" style="display: none; color: Black;">
                * Item Not Avaiabale,Add Invocie First.</div>
            <div id="open_item" runat="server">
                <div id="innerbox_MidMain_Trans_Item_Main_new1" style="margin-top: 1px; height: 400px;">
                    <ol id="toc">
                        <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');"
                            id="ITEM_ID"><span>Item Main Details</span></a></li>
                        <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2('0');"
                            id="OTHER_DETAILS_ID"><span>Other Details</span></a></li>
                        <li><a href="#page-11" onclick="jQuery('#form1').validationEngine('hideAll');tab_page11('0');"
                            id="SW_Manufacture"><span>SW - Manufacturer</span></a></li>
                        <li><a href="#page-12" onclick="jQuery('#form1').validationEngine('hideAll');tab_page12('0');"
                            id="RE_EXPORT" runat="server" visible="false"><span>Re-Export</span></a></li>
                        <%-- <li  style=" height:15px;"><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll'); tab_Reimport('0');"
                        id="RE_IMPORT" runat="server" visible="false"><span>Re-Import</span></a></li>--%>
                        <li id="drawback" visible="false" runat="server"><a href="#page-3" onclick="tab_page3('0');"
                            id="DBK"><span>DBK</span></a></li>
                        <li id="jobbing" visible="false" runat="server"><a href="#page-4" onclick="tab_page4('0');"
                            id="Scheme_Jobbing"><span>Jobbings</span></a></li>
                        <li id="EPCG" visible="false" runat="server"><a href="#page-5" onclick="tab_page5('0');"
                            id="Scheme_EPCG" target="trans_igm"><span id="spanepcg">EPCG</span></a></li>
                        <li id="DEEC" visible="false" runat="server"><a href="#page-6" onclick="tab_page6('0');"
                            id="Scheme_DEEC" target="trans_igm"><span id="spandeec">DEEC</span></a></li>
                        <li id="DFIA" visible="false" runat="server"><a href="#page-7" onclick="tab_page7('0');"
                            id="Scheme_DFIA" target="trans_igm"><span id="spandfia">DFIA</span></a></li>
                        <li id="Cess" visible="false" runat="server"><a href="#page-8" target="trans_igm"
                            onclick="jQuery('#form1').validationEngine('hideAll');tab_page8('0');"><span>Cess</span></a></li>
                        <li id="Quota" visible="false" runat="server"><a href="#page-9" target="trans_igm"
                            onclick="jQuery('#form1').validationEngine('hideAll');tab_page9('0');"><span>Quota</span></a></li>
                        <li runat="server"><a href="#page-10" target="trans_igm" id="EXP_SW" onclick="jQuery('#form1').validationEngine('hideAll');tab_page10('0');">
                            <span>Single Window </span></a></li>
                        <%--<li id="SW_Manufacture"  runat="server"><a href="#page-11" target="trans_igm"
                        onclick="jQuery('#form1').validationEngine('hideAll');tab_page11('0');"><span>SW - Manufacturer </span></a></li>--%>
                        <%-- <li><a href="#page-11" onclick="jQuery('#form1').validationEngine('hideAll');tab_page11('0');"
                        id="SW_Manufacture"><span>SW - Manufacturer</span></a></li>--%>
                        <%--<li style=" height:15px;"><a href="#page-13" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SUPPORTING_DOCS('0');"
                        id="SUP_DOCS" runat="server" ><span> Sup Doc
                        </span></a></li>--%>
                        <li id="SupDoc" runat="server"><a href="#page-13" target="trans_igm" onclick="jQuery('#form1').validationEngine('hideAll');tab_page13('0');">
                            <span>Sup Docs</span></a></li>
                        <li id="DTA" visible="false" runat="server"><a href="#page-14" target="trans_igm"
                            onclick="jQuery('#form1').validationEngine('hideAll');tab_page14('0');"><span>DTA Item</span></a></li>
                    </ol>
                    <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="margin-top: -20px;">
                        <div class="content" id="page-1" style="height: 840px;">
                            <div id="pop_exp_item_licen_main_new1" style="margin-top: -7px; height: 326px;">
                                <div id="tag_transac_exports_item_margs_nos_others_new1" style="width: 640px; height: 49px;">
                                    <div id="tag_label_transaction_iten_new1_nos_othres" style="margin-left: -7px;">
                                        Description
                                    </div>
                                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="120" CssClass="validate[required] txtbox_none_Mid_transac_item_gen_decs_EXP"
                                        TabIndex="1" TextMode="MultiLine" onkeypress="DisableSpecialKeyEvents(); checkTextAreaMaxLength_CompanyWise(this,event);"
                                        onkeyDown="return (event.keyCode!=13);CheckCharCounter(this, 120);" onpaste="return checkTextAreaMaxLength_CompanyWise(this,event);"
                                        onkeyup="CheckCharCounter(this, 120)" onfocus="CheckCharCounter(this, 120)" onblur="CheckCharCounter(this, 120);"
                                        Style="width: 537px; margin-left: -23px;"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupProduct_Export_Product_Master('EXP_GET_PRODUCT');check(); return false"
                                        class="magnfy" style="margin-left: -30px;"></a>
                                    <asp:TextBox ID="lblcnt" BorderStyle="None" BackColor="White" Width="20px" Enabled="false"
                                        runat="server"></asp:TextBox>
                                </div>
                                <div id="tag_transac_lft_trans_item_new1_maintag1" style="width: 730px; margin-top: -2px;">
                                    <div id="tag_label_transaction_popup_Item_maindet" style="margin-left: -7px;">
                                        RITC No.
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                            ForeColor="Red" ControlToValidate="txtRITCNo" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:TextBox ID="txtRITCNo" runat="server" Style="margin-left: -24px;" CssClass="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_item_maindet"
                                            ClientIDMode="Static" Onkeypress="return num5(event)" MaxLength="8" TabIndex="2"></asp:TextBox>
                                    </div>
                                 <%--   <div id="magnify_area">
                                        <a href="#" style="margin-left: -26px;" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Export_Ritc('Export_RITCNO'); return false"
                                            class="magnfy"></a>
                                    </div>--%>
                                      
                                          <div id="magnify_area" style="position: relative; display: inline-block;">
                                        <a href="#" style="margin-left: -26px;" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Export_Ritc('Export_RITCNO'); return false"
                                            class="magnfy"></a>
                                        <asp:Label ID="lblRITCPolicy" runat="server" ClientIDMode="Static" Text="" Style="font-weight: bold;
                                            font-size: 12px; padding: 2px 8px; border-radius: 4px; width: 73px; margin-left: 15px;
                                            margin-top: -20px; display: none; text-align: center; position: absolute; top: 20px;
                                            left: 0px; z-index: 999; white-space: nowrap;">
                                        </asp:Label>

                                    </div>
                                    <div id="tag_label_transaction_popup_Item_maindet" style="margin-left: 70px;">
                                         <div id="tag_label_transaction_popup_Item_maindet" style="margin-left: 30px;">
                                            Item Qty
                                        </div>
                                    </div>

                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:TextBox ID="txtItemQty" MaxLength="12" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                            onblur="extractNumber(this,3,false);remove_zero_after_decimal_point(this.value,'txtItemQty');"
                                            onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            TabIndex="3"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="txtcon-m_transaction_item_CTH_small">
                                        <asp:TextBox ID="txtQtyCode" MaxLength="3" runat="server" CssClass="validate[required,custom[onlyLetterSp]] txtbox_none_Mid_transac_item_CTH_small"
                                            ClientIDMode="Static" onblur="ChangeCase(this);" onkeypress="return cha(event)"
                                            TabIndex="4"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('EXPORT_ITEM_QTY'); return false"
                                            class="magnfy"></a>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_export_popup_Item_maindet">
                                        Item Unit Price
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:TextBox ID="txtItem_UnitPrice" runat="server" MaxLength="12" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                            onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtItem_UnitPrice');"
                                            onkeyup="extractNumber(this,5,false);return Clear_Dot(this);" Style="margin-left: -8px;" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            TabIndex="5"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_trans_item_new1_maintag1" style="width: 700px;">
                                    <div id="tag_label_transaction_popup_Item_maindet" style="margin-left: -6px;">
                                        Per
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:TextBox ID="txtPer" runat="server" MaxLength="12" Text="1" Style="margin-left: -26px;" CssClass="validate[required] txtbox_none_Mid_transac_item_maindet"
                                            Onkeypress="return num5(event)" TabIndex="6"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <div id="tag_label_transaction_popup_Item_maindet"  style="margin-left: -23px;">
                                        <div id="tag_label_transaction_popup_Item_maindet" style="margin-left: 30px;">
                                          Item Amount
                                         </div>
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:TextBox ID="txtItem_Amount" MaxLength="12" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                            onblur="extractNumber(this,5,false);" style="margin-left:27px;"  onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="7"></asp:TextBox>
                                    </div>
                                    <%-- <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>--%>
                                    <div id="tag_transac_lft_in1_export" runat="server" style="width: 305px; margin-right: -10px;
                                        display: none;">
                                        <div id="tag_label_transaction_export_popup_Item_maindet" style="width: 85px;">
                                            PMV Calc.in
                                        </div>
                                        <div id="tag_label_transaction_export_popup_Item_maindet" style="width: 79px; font-size: small;"
                                            runat="server">
                                            <asp:DropDownList ID="ddl_PMV_method" runat="server" Width="75px" CssClass="txtbox_none_Mid_transac_exp_itemnew"
                                                TabIndex="8">
                                                <%--<asp:ListItem Value="Unit">PerUnit</asp:ListItem>--%>
                                                <asp:ListItem Value="Rate">Rate</asp:ListItem>
                                                <asp:ListItem Value="Amt">Amt</asp:ListItem>
                                                <asp:ListItem Value="PerUnit">PerUnit</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width: 59px;">
                                            <asp:TextBox ID="txtPMV_Rate" MaxLength="10" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                                                onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);"
                                                Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="8"></asp:TextBox>
                                        </div>
                                        <%--<div id="tag_label_transaction_Src_new" runat="server">
                                       <asp:TextBox ID="txtPMVValue" MaxLength="12" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                                           onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);"
                                           onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="8"></asp:TextBox>
                                   </div>--%>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_trans_item_new1_maintag1" style="width: 700px;">
                                    <div id="tag_label_transaction_popup_Item_maindet" style="margin-left: -8px;">
                                        Scheme
                                    </div>
                                    <div id="txtcon-m_transaction_export_itemnew_gen" style="width: 300px;">
                                        <asp:DropDownList ID="ddlSchemeCode" Style="margin-left: -23px;" runat="server" CssClass="txtbox_none_Mid_transac_exp_itemnew"
                                            OnSelectedIndexChanged="ddlSchemeCode_SelectedIndexChanged" AutoPostBack="false"
                                            Width="300px" TabIndex="7">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="txtcon-l_src">
                                    </div>
                                    <%--  <div id="tag_label_adcode" style="width:60px">
                               Part No</div>
                                 
                            <div id="txtcon-m_src" style="width:105px">
                                <asp:TextBox ID="txtPARTNo" runat="server" MaxLength="50" 
                                    CssClass="txtbox_none_Mid_transac_item_maindet" Width="150px"
                                    TabIndex="8" onkeypress="return pin(event)" AutoPostBack="true" 
                                     ></asp:TextBox>
                            </div>--%>
                                    <div id="tag_transac_lft_in1_export2" runat="server" style="width: 305px; margin-right: -10px;
                                        display: none;">
                                        <div id="tag_label_transaction_export_popup_Item_maindet2" style="width: 85px;">
                                            PMV PerUnit
                                        </div>
                                        <div id="tag_label_transaction_export_popup_Item_maindet2" style="width: 79px; font-size: small;"
                                            runat="server">
                                            <asp:TextBox ID="txt_PMV_PerUnit" MaxLength="10" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                                                onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);"
                                                Width="75px" onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="9"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="tag_label_transaction_Src_new" runat="server">
                                            <asp:TextBox ID="txtPMVValue" MaxLength="12" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                                                onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);"
                                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="9"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_trans_item_new1_maintag1" style="width: 700px;">
                                    <div id="tag_label_transaction_popup_Item_maindet" style="margin-left: -8px;">
                                        STR Y/N
                                    </div>
                                    <div id="txtcon-m_transaction_list1_yn">
                                        <asp:DropDownList ID="ddl_STR_YN" Style="margin-left: -23px;" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                            TabIndex="24">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="div_STR_YN" runat="server" style="display: none;">
                                        <div id="tag_label_transaction_popup_Item_maindet" style="width: 70px">
                                            <div id="tag_label_transaction_popup_Item_maindet" style="margin-left:-25px;">
                                            STR Code
                                            </div>
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet">
                                            <asp:TextBox ID="txtSTRCode" style="margin-left:-30px;" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                                ClientIDMode="Static" MaxLength="4" onkeypress="return pin(event)" TabIndex="25"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" style="margin-left:-30px;" onclick="jQuery('#form1').validationEngine('hideAll');opennew_STR_DETAILS(); return false"
                                                class="magnfy"></a>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                    </div>
                                    <div id="tag_label_transaction_export_Item_otherdet" style="margin-left: -26px;">
                                        Reward Y/N
                                    </div>
                                    <div id="txtcon-m_transaction_list1_yn">
                                        <asp:DropDownList ID="ddlRewardPoints" Style="margin-left: -42px;" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                            TabIndex="26">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_export_popup_Item_maindet" style="margin-left: -40px;">
                                        Cess
                                    </div>
                                    <div id="txtcon-m_transaction_list1_yn">
                                        <asp:DropDownList ID="ddl_Cess_YN"  Style="margin-left: -60px;" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                            TabIndex="26">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_export_popup_Item_maindet" style="margin-left: -60px;">
                                        RODTEP(Y/N)
                                    </div>
                                    <div id="txtcon-m_transaction_list1_yn" style="width:45px;">
                                        <asp:DropDownList ID="ddl_Rodtep_YN" runat="server" style="margin-left:-10px;" CssClass="listtxt_transac_exp_item_yn"
                                            TabIndex="26">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="editbu" style="display:inline-block;vertical-align:middle;margin-left:4px;">
                                            <button type="button"
                                                    id="btnRODTEP_Info"
                                                    title="RODTEP Info"
                                                    disabled="disabled"
                                                    onclick="jQuery('#form1').validationEngine('hide'); openRODTEPInfo(); return false;"
                                                    style="width:22px;height:22px;padding:0;border:1px solid #1a6632;
                                                           border-radius:3px;background:#1e8449;color:#fff;
                                                           font-size:13px;font-weight:bold;cursor:pointer;
                                                           line-height:22px;text-align:center;vertical-align:middle;
                                                           opacity:0.4;">
                                                &#8377;
                                            </button>
                                        </div>
                                        <div id="div_RODTEP_Overlay"
                                             style="display:none;
                                                    position:fixed; top:0; left:0;
                                                    width:100vw; height:100vh;
                                                    background:rgba(0,0,0,0.55);
                                                    z-index:9000;
                                                    align-items:center;
                                                    justify-content:center;">

                                            <div id="div_RODTEP_Popup"
                                                 style="width:480px;
                                                        background:#fff;
                                                        border:2px solid #1a5276;
                                                        border-radius:4px;
                                                        box-shadow:0 8px 24px rgba(0,0,0,0.4);">

                                                <iframe id="iframe_RODTEP_Info"
                                                        src=""
                                                        width="480"
                                                        height="310"
                                                        frameborder="0"
                                                        scrolling="no"
                                                        style="display:block; border-radius:2px;">
                                                </iframe>
                                            </div>
                                        </div>

                                </div>
                                <div id="tag_transac_export_lft_item_gen_Grid_area_new_header" style="height: 0px;">
                                    <asp:GridView ID="gv_Header" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                        CssClass="grid-view" HorizontalAlign="Left" DataKeyNames="ITEM_ID,ITEM_SLNO"
                                        AllowSorting="True" BorderColor="#C8C8C8" ShowHeaderWhenEmpty="true" Width="100%"
                                        BorderStyle="none" BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gv_Header_RowCreated"
                                        OnRowDataBound="gv_Header_RowDataBound">
                                        <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                        <SelectedRowStyle Font-Bold="true" />
                                        <Columns>
                                            <asp:BoundField DataField="a" HeaderText="S.No" HeaderStyle-Width="46px">
                                                <ItemStyle CssClass="column_style_left_border_2_new" Width="260px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="a" HeaderText="Description" HeaderStyle-Width="260px">
                                                <ItemStyle CssClass="column_style_left_border_2_new" Width="260px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="a" HeaderText="RITC No" HeaderStyle-Width="60px">
                                                <ItemStyle CssClass="column_style_left_border_4_new" Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="a" HeaderText="Quantity" HeaderStyle-Width="65px">
                                                <ItemStyle CssClass="column_style_left1_new" Width="65px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="a" HeaderText="Unit" HeaderStyle-Width="28px">
                                                <ItemStyle CssClass="column_style_left_border_3_new" Width="28px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="a" HeaderText="Unit Price" HeaderStyle-Width="80px">
                                                <ItemStyle CssClass="column_style_left1_new" Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="a" HeaderText="Amount" HeaderStyle-Width="85px">
                                                <ItemStyle CssClass="column_style_right_new" Width="65px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="a" HeaderText="Scheme" HeaderStyle-Width="50px">
                                                <ItemStyle CssClass="column_style_left_border_4_new" Width="50px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div id="tag_transac_export_lft_item_gen_Grid_area_new1" onscroll="SetDivPosition()"
                                    style="overflow: auto; height: 167px; margin-top: 5px;">
                                    <asp:GridView ID="gv_Item" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                        CssClass="grid-view" HorizontalAlign="Left" DataKeyNames="ITEM_ID,ITEM_SLNO"
                                        AllowSorting="True" BorderColor="#C8C8C8" ShowHeaderWhenEmpty="true" Width="100%"
                                        BorderStyle="none" BorderWidth="1px" CellPadding="1" CellSpacing="1" ShowHeader="false"
                                        OnRowCreated="gv_Item_RowCreated" OnRowDataBound="gv_Item_RowDataBound" OnSelectedIndexChanged="gv_Item_SelectedIndexChanged">
                                        <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                        <SelectedRowStyle Font-Bold="true" />
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True">
                                                <HeaderStyle CssClass="hideGridColumn" />
                                                <ItemStyle CssClass="hideGridColumn" />
                                            </asp:CommandField>
                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="46px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblitemslno" runat="server" CssClass="column_style_left_border_4_new"
                                                        Width="16px" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="46px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ITEM_ID" HeaderText="S.NO">
                                                <HeaderStyle CssClass="hideGridColumn" />
                                                <ItemStyle CssClass="hideGridColumn" />
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="Description" HeaderStyle-Width="260px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" Width="260px" />
                                        </asp:BoundField>--%>
                                            <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Description" HeaderStyle-Width="260px">
                                                <ItemStyle CssClass="column_style_left_border_2_new" Width="260px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RITCNO" HeaderText="RITC No" HeaderStyle-Width="60px">
                                                <ItemStyle CssClass="column_style_left_border_4_new" Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ITEM_QTY" HeaderText="Quantity" HeaderStyle-Width="65px">
                                                <ItemStyle CssClass="column_style_left1_new" Width="65px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ITEM_QTY_CODE" HeaderText="Unit" HeaderStyle-Width="28px">
                                                <ItemStyle CssClass="column_style_left_border_3_new" Width="28px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ITEM_UNIT_PRICE" HeaderText="Unit Price" HeaderStyle-Width="80px">
                                                <ItemStyle CssClass="column_style_left1_new" Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ITEM_AMOUNT" HeaderText="Amount" HeaderStyle-Width="65px">
                                                <ItemStyle CssClass="column_style_right_new" Width="65px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SUB_SCHEME_CODE" HeaderText="Scheme" HeaderStyle-Width="50px">
                                                <ItemStyle CssClass="column_style_left_border_4_new" Width="50px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="content" id="page-2" style="display: none;">
                            <div id="pop_exp_item_licen_main_new1">
                                <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="height: 45px;
                                    width: 800px;">
                                    <div id="tag_label_transaction_popup_Item_maindet">
                                        Accessory Desc</div>
                                    <div id="txtcon-m_transaction_Supp_code" style="width: 400px; height: 85px;">
                                        <asp:TextBox ID="txtAccessoryDesc" runat="server" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1"
                                            Height="38px" Width="400px" MaxLength="500" TextMode="MultiLine" onkeyDown="return (event.keyCode!=13);return checkTextAreaMaxLength(this,event,'500');"
                                            onpaste="return checkTextAreaMaxLength(this,event,'500');" TabIndex="10"></asp:TextBox>
                                    </div>
                                    <div id="div_AmendmentType" visible="false" runat="server">
                                        <div id="tag_label_transaction_popup_Item_maindet" style="width: 80px; font-weight: bold;">
                                            AmendType
                                        </div>
                                        <div id="tag_label_transaction_popup_Item_maindet" style="width: 120px">
                                            <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="10" CssClass="listtxt_transac_mode_new"
                                                Width="120px">
                                                <asp:ListItem Value=""></asp:ListItem>
                                                <asp:ListItem Value="A">AMENDMENT</asp:ListItem>
                                                <asp:ListItem Value="S">SUPPLEMENT</asp:ListItem>
                                                <asp:ListItem Value="D">DELETE</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div id="frame_export_item_otherdet_new1" style="display: none;">
                                    <div id="tag_label_transaction_export_Item_otherdet_frmlabel_new1">
                                        AR4 Details</div>
                                    <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                                        <div id="tag_label_transaction_export_Item_otherdet">
                                            AR4 No
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtAR4No" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                MaxLength="17" onkeypress="return charnum2(event)" TabIndex="11"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                                        <div id="tag_label_transaction_export_Item_otherdet">
                                            AR4 Date
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtAR4Date" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                TabIndex="12"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtAR4Date"
                                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True">
                                            </cc1:MaskedEditExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAR4Date"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                                        <div id="tag_label_transaction_export_Item_otherdet">
                                            Commission Rate
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtCommissionRate" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                MaxLength="20"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                                        <div id="tag_label_transaction_export_Item_otherdet">
                                            Division</div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtDivision" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                TabIndex="14" MaxLength="20"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                                        <div id="tag_label_transaction_export_Item_otherdet">
                                            Range
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtRange" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                MaxLength="20" TabIndex="15"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new3">
                                        <div id="tag_label_transaction_export_Item_otherdet_new1">
                                            Remarks</div>
                                        <div id="max_txtarea1">
                                            <div id="txtcon-Mid_Maxtxt1">
                                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="txtbox_none_Maxtxt_Export_Item"
                                                    MaxLength="200" onkeyDown="return checkTextAreaMaxLength(this,event,'200');"
                                                    onpaste="return checkTextAreaMaxLength(this,event,'200');" TabIndex="16"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="height: 20px;
                                    margin-top: 5px; width: 700px;">
                                    <div id="tag_label_transaction_popup_Item_maindet">
                                        EndUse of Item</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtEnduseItem" runat="server" MaxLength="20" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            ClientIDMode="Static" TabIndex="17"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_End_Use_Of_Itemd('Exp_End_Use'); return false"
                                            class="magnfy"></a>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_gen" style="width: 140px">
                                        IGST Payment Status</div>
                                    <div id="txtcon-m_transaction_Supp_code" style="width: 80px">
                                        <asp:DropDownList ID="ddl_IGST_Payment" runat="server" CssClass="listtxt_transac_mode_new"
                                            TabIndex="17">
                                            <asp:ListItem>NA</asp:ListItem>
                                            <asp:ListItem>LUT</asp:ListItem>
                                            <asp:ListItem>P</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btn_IGST_Updt_all" Text="IGST Update All" Width="120px" runat="server"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXP_ExRate_Update_TaxableValue(); return false;" />
                                    </div>
                                </div>
                                <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="height: 20px;
                                    margin-top: 5px; width: 700px;">
                                    <div id="tag_label_transaction_popup_Item_maindet">
                                        Taxable Value</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txt_TaxableValue" runat="server" MaxLength="19" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            ClientIDMode="Static" TabIndex="17" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <%--<div id="tag_label_transaction_popup_IGM2_empty">
                                </div>--%>
                                    <div id="tag_label_transaction_popup_gen" style="width: 70px">
                                        IGST Rate</div>
                                    <div id="txtcon-m_transaction_code" style="width: 130px">
                                        <asp:TextBox ID="txt_IGST_Rate" runat="server" MaxLength="19" CssClass="txtbox_none_Mid_transac_code"
                                            ClientIDMode="Static" TabIndex="17" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" Width="125px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_gen" style="width: 90px">
                                        IGST Amount</div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <%--<asp:TextBox ID="txt_IGST_Amt" runat="server" MaxLength="19" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        ClientIDMode="Static" TabIndex="17" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>--%>
                                        <%--<asp:TextBox ID="txt_IGST_Amt" runat="server" MaxLength="19" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        ClientIDMode="Static" TabIndex="17" ></asp:TextBox>--%>
                                        <asp:TextBox ID="txt_IGST_Amt" runat="server" MaxLength="19" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                            ClientIDMode="Static" TabIndex="17" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="height: 20px;
                                    margin-top: 5px; width: 700px;">
                                    <div id="tag_label_transaction_popup_Item_maindet">
                                        Info MSR</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txt_InfoMSR" runat="server" MaxLength="19" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            ClientIDMode="Static" TabIndex="17" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <%--<div id="tag_label_transaction_popup_IGM2_empty">
                                </div>--%>
                                    <div id="tag_label_transaction_popup_gen" style="width: 70px">
                                        Info UQC</div>
                                    <div id="txtcon-m_transaction_Supp_code" style="width: 130px">
                                        <asp:TextBox ID="txt_InfoUQC" runat="server" MaxLength="19" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            ClientIDMode="Static" TabIndex="17" Width="125px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_gen" style="width: 90px">
                                        Under PTA/FTA</div>
                                    <div id="txtcon-m_transaction_Supp_code" style="width: 141px">
                                        <asp:TextBox ID="txt_PTA_FTA" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            ClientIDMode="Static" TabIndex="17"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');opennew_PTA_FTA_Agreement('Export_PTA_FTA'); return false"
                                            class="magnfy"></a>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="height: 20px;
                                    margin-top: 5px; width: 700px;">
                                    <div id="tag_label_transaction_popup_Item_maindet">
                                        State Of Origin</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txt_StateOrigin" runat="server" MaxLength="100" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            ClientIDMode="Static" TabIndex="17"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');opennew_District_Statecode('Export_SW_District'); return false"
                                            class="magnfy"></a>
                                    </div>
                                    <%--<div id="tag_label_transaction_popup_IGM2_empty">
                                </div>--%>
                                    <div id="tag_label_transaction_popup_gen" style="width: 70px">
                                        District
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code" style="width: 130px">
                                        <asp:TextBox ID="txt_DistrictOrigin" runat="server" MaxLength="100" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            ClientIDMode="Static" TabIndex="17" Width="125px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_gen" style="width: 90px">
                                        GST Cess Amt</div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_GSTCessAmt" runat="server" MaxLength="20" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            ClientIDMode="Static" TabIndex="17" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="frame2_export_item_otherdet_new1" style="width: 685px; height: 150px;">
                                    <div id="tag_label_transaction_export_Item_otherdet_frmlabel_new1">
                                        Third Party Details
                                    </div>
                                    <div id="tag_transac_lft_trans_item_new1_maintag1">
                                        <div id="tag_label_transaction_popup_Item_maindet">
                                            Exporter Name
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtExporterName" runat="server" MaxLength="40" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                ClientIDMode="Static" TabIndex="17"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('Exporter_item'); return false">
                                            </a>
                                        </div>
                                        <div id="tag_label_transaction_popup_mode_empty">
                                        </div>
                                        <div id="tag_label_transaction_popup_Item_maindet" style="width: 70px">
                                            IEC Code
                                        </div>
                                        <div id="txtcon-m_transaction_code">
                                            <asp:TextBox ID="txtIECCode" runat="server" CssClass="validate[minSize[10]] txtbox_none_Mid_transac_code"
                                                ClientIDMode="Static" MaxLength="10" onkeypress="return pin(event)" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_mode_empty">
                                        </div>
                                        <div id="tag_label_transaction_date" style="width: 80px">
                                            Branch SlNo
                                        </div>
                                        <div id="txtcon-m_transaction_code" style="width: 50px">
                                            <asp:TextBox ID="txtBranchSLNo" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                                Width="50px" ClientIDMode="Static" onkeypress="return pin(event)" MaxLength="3"
                                                TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master_BranchSlno('Export_Item_Branch'); return false"
                                                class="magnfy"></a>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_new1_maintag1">
                                        <div id="tag_label_transaction_popup_Item_maindet">
                                            Address</div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                ClientIDMode="Static" MaxLength="35" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                ClientIDMode="Static" MaxLength="35" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                ClientIDMode="Static" MaxLength="35" TabIndex="18"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_new1_maintag1">
                                        <div id="tag_label_transaction_popup_Item_maindet">
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtAddress3" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                ClientIDMode="Static" MaxLength="6" onkeypress="return pin(event)" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txtAddress4" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                ClientIDMode="Static" MaxLength="35" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_new1_maintag1">
                                        <div id="tag_label_transaction_popup_Item_maindet">
                                            GSTN Type
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:DropDownList ID="ddl_GSTN_Type" runat="server" CssClass="listtxt_transac_src1"
                                                ClientIDMode="Static" TabIndex="18" Width="150px">
                                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="G/GSN  -GSTIN of Normal Persons Individual IEC" Value="GSN"></asp:ListItem>
                                                <asp:ListItem Text="O/GSG GSTIN of Govt.Entities" Value="GSG"></asp:ListItem>
                                                <asp:ListItem Text="D/GSD - GSTIN of Diplomats" Value="GSD"></asp:ListItem>
                                                <asp:ListItem Text="I/PAN PAN Number (AAAPL1234C)" Value="PAN"></asp:ListItem>
                                                <asp:ListItem Text="T/TAN TAN Number (AAAP12345C)" Value="TAN"></asp:ListItem>
                                                <asp:ListItem Text="P/PSP -Passport Number( Max 9 Characters-AN)" Value="PSP"></asp:ListItem>
                                                <asp:ListItem Text="A/ADH Aadhaar Number( 12 Numeric)" Value="ADH"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div id="tag_label_transaction_popup_Item_maindet" style="text-align: center; width: 33px;">
                                            ID
                                        </div>
                                        <div id="txtcon-m_transaction_Supp_code">
                                            <asp:TextBox ID="txt_GSTN_ID" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                                ClientIDMode="Static" MaxLength="20" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="content" id="page-12" style="display: none;">
                            <div id="pop_exp_item_licen_main_new1">
                                <iframe name="trans_igm" scrolling="no" id="Re_Export" width="700px" height="350px">
                                </iframe>
                            </div>
                        </div>
                        <div class="content" id="page-8" style="display: none;">
                            <div id="pop_exp_item_licen_main_new1">
                                <iframe name="trans_igm" scrolling="no" id="pop_text_area_transac_item_cess_iframe"
                                    width="700px" height="350px"></iframe>
                            </div>
                        </div>
                        <div class="content" id="page-9" style="display: none;">
                            <div id="pop_exp_item_licen_main_new1">
                                <iframe name="trans_igm" scrolling="no" id="txt_area_quto_details" width="700px"
                                    height="350px"></iframe>
                            </div>
                        </div>
                        <div class="content" id="page-3" style="display: none;">
                            <div id="pop_exp_item_licen_main_new1">
                                <iframe name="trans_igm" scrolling="no" id="pop_text_area_transac_item_drawback_iframe">
                                </iframe>
                            </div>
                        </div>
                        <div class="content" id="page-4" style="display: none;">
                            <div id="pop_exp_item_licen_main_new1">
                                <iframe name="trans_igm" scrolling="no" id="pop_text_area_transac_item_Jobbing_iframe">
                                </iframe>
                            </div>
                        </div>
                        <div class="content" id="page-5" style="display: none;">
                            <iframe name="trans_igm" scrolling="no" id="pop_text_area_transac_item_licence_iframe_new1">
                            </iframe>
                        </div>
                        <div class="content" id="page-6" style="display: none;">
                        </div>
                        <div class="content" id="page-7" style="display: none;">
                        </div>
                        <div class="content" id="page-10" style="display: none;">
                            <div id="pop_exp_item_licen_main_new1" style="height: 350px;">
                                <iframe name="trans_igm" scrolling="no" id="Export_Single_Window" width="700px" height="370px"
                                    style="margin-top: -20px;"></iframe>
                            </div>
                        </div>
                        <div class="content" id="page-13" style="display: none;">
                            <div id="pop_exp_item_licen_main_new1">
                                <iframe name="trans_igm" scrolling="no" id="Export_SW_Supdocs" width="720px" height="350px"
                                    style="margin-top: -5px;"></iframe>
                            </div>
                        </div>
                        <div class="content" id="page-14" style="display: none;">
                            <div id="pop_exp_item_licen_main_new1">
                                <iframe name="trans_igm" scrolling="no" id="DTA_Sez" width="720px" height="350px"
                                    style="margin-top: -5px;"></iframe>
                            </div>
                        </div>
                        <div class="content" id="page-11" style="width: 690px; height: 300px; display: none;">
                            <div id="pop_exp_item_licen_main_new1">
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="height: 40px; width: 683px;
                                    margin-top: 20px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Item Manufacturer/Producer Code Type
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Manufacturer_producer" runat="server" onkeyup="autotab(this);"
                                            MaxLength="1" TabIndex="119" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Item Manufacturer/Producer/ Grower Code
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Manu_produ_grower_code" runat="server" onkeyup="autotab(this);"
                                            TabIndex="121" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" onpaste="return validatePaste(event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Address 1
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Manufacturer_Add1" onkeyup="autotab(this);" ClientIDMode="Static"
                                            onpaste="return validatePaste(event);" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            MaxLength="70" TabIndex="122"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Address 2
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Manufacturer_Add2" runat="server" onkeyup="autotab(this);" MaxLength="50"
                                            onpaste="return validatePaste(event);" TabIndex="123" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        City
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Manufacturer_City" onkeyup="autotab(this);" MaxLength="35" TabIndex="124"
                                            onpaste="return validatePaste(event);" ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Country Subdivision
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Manu_Country_Subdiv" runat="server" onkeyup="autotab(this);"
                                            onpaste="return validatePaste(event);" MaxLength="35" TabIndex="125" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Pincode
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Manufacturer_pincode" onkeyup="autotab(this);" MaxLength="10"
                                            Onkeypress="return num1(event)" TabIndex="126" ClientIDMode="Static" runat="server"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Manufacturer Country
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Manufacturer_Country" runat="server" MaxLength="2" TabIndex="127"
                                            Onkeypress="return char1(event)" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Source State
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Manu_Source_State" MaxLength="2" TabIndex="128" ClientIDMode="Static"
                                            Onkeypress="return char1(event)" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Transit Country
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_manu_Transit_Country" runat="server" MaxLength="2" TabIndex="129"
                                            Onkeypress="return char1(event)" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Accessory Status (0 / 1 / 2)
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Accessory_status" onkeyup="autotab(this);" MaxLength="1" TabIndex="130"
                                            ClientIDMode="Static" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                            onkeypress="return pin(event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 583px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 580px; font-weight: bold;">
                                        (0-No Accessories,1-Accessories Along with this Item,2- Accessories as Separate
                                        Item)
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 583px;">
                                </div>
                                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        HAWB_No
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_HAWB_No" runat="server" MaxLength="15" TabIndex="131" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_adcode" style="width: 60px; margin-left: 35px">
                                        Part No</div>
                                    <div id="txtcon-m_src" style="width: 105px">
                                        <asp:TextBox ID="txtPARTNo" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_item_maindet"
                                            Width="150px" TabIndex="133" onkeypress="return pin(event)" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label">
                                        Total Package
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_Total_Pkgs" runat="server" MaxLength="8" TabIndex="132" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="Export_Item" style="display: block;">
                        <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_det_Inv_S_No" style="height: 65px">
                            <div id="innerbox_MidMain_Trans_Item_Main_top">
                                <div id="tag_transac_lft_in1_item_top">
                                    <div id="tag_label_transaction_popup_gen3">
                                        Invoice Sr. No.
                                    </div>
                                    <div id="txtcon-m_transaction_list1">
                                        <asp:DropDownList ID="ddlInv_SL_No" runat="server" CssClass="listtxt_transac_src1"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlInv_SL_No_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1_item_top">
                                    <div id="tag_label_transaction_popup_gen3">
                                        Item Sr.No
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                        <asp:DropDownList ID="ddl_ItemSlno" runat="server" CssClass="listtxt_transac_src1"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_ItemSlno_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1_item_top">
                                    <div id="tag_label_transaction_popup_gen3" style="width: 120px;">
                                        Current Item SlNo
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice_det2" style="width: 60px;">
                                        <asp:Label ID="lbl_Item_Slno" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_det">
                            <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_Topcap">
                                Current Invoice Details</div>
                            <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                                <div id="tag_label_transaction_popup_IGM_invoice_det1" style="width: 58px;">
                                    Inv No &nbsp;&nbsp;&nbsp;&nbsp;:
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                    <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                                <div id="tag_label_transaction_popup_IGM_invoice_det1" style="width: 58px;">
                                    Inv Value :
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                    <asp:Label ID="lblInvoiceValue" runat="server"></asp:Label></div>
                            </div>
                            <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                                <div id="tag_label_transaction_popup_IGM_invoice_det1" style="width: 58px;">
                                    Prod Val &nbsp;:
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                    <asp:Label ID="lblProductValue" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                                <div id="tag_label_transaction_popup_IGM_invoice_det1" style="width: 58px;">
                                    Tot Items :
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                    <asp:Label ID="lblTotal_No_Of_Items" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_bot_transact_invoice" style="margin-top: 5px; width: 950px;">

                 <%--   <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                            TabIndex="135" />
                    </div>--%>

                    <div id="newbu">
    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" 
        CausesValidation="false" UseSubmitBehavior="false" 
        OnClientClick="jQuery('#form1').validationEngine('hide'); document.getElementById('hdnIsNewClick').value='Y';"
        TabIndex="135" />
           </div>



                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" ValidationGroup="a"
                            OnClientClick="return validate_Export_Item('Save');" TabIndex="134" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave_New" Text="Save & New" runat="server" CssClass="autowidupdatebut"
                            OnClick="btn_save_new_Click" OnClientClick="return validate_Export_Item('Save');"
                            TabIndex="134" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="Confirm();return validate_Export_Item('Update');" TabIndex="134" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="135" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'ITEM', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="135" OnClick="btnDelete_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <%--<asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Parent_close_button1();return false;"
                        TabIndex="136" CausesValidation="false" UseSubmitBehavior="false" />--%>
                        <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1_Trigger_AnotherPage('General',document.getElementById('hdn_source').value);return false;"
                            id="btnCancel" tabindex="136">
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnItem_move" Text="Move" CssClass="autowidupdatebut" Width="50px"
                            runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXP_Prouduct_Item_Move('New'); return false;" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUp" Text="Up" CssClass="autowidmovebut" Width="40px" runat="server"
                            UseSubmitBehavior="false" OnClick="btnUp_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDown" Text="Down" CssClass="autowidmovebut" Width="50px" runat="server"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            OnClick="btnDown_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnitemCopy" Text="Item Copy" CssClass="autowidupdatebut" Width="70px"
                            runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_Export_Item_Copy(document.getElementById('hdinvslno').value); return false;" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnupdateProduct" Text="Update Master" CssClass="autowidupdatebut"
                            runat="server" UseSubmitBehavior="false" Width="100px" OnClientClick="jQuery('#form1').validationEngine('hideAll');Go_Product();return false;" />
                        <%--OnClick="btnupdateProduct_Click"--%>
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btn_product_updation" Text="Bulk Product" CssClass="autowidupdatebut"
                            Width="85px" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXP_Prouduct_Master('New'); return false;" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btn_bulk_License" Text="Bulk License" CssClass="autowidupdatebut"
                            Width="90px" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_Export_Bulk_License_Excel_Upload();return false;" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btn_bulk_SW_STMT" Text="Bulk Statement" CssClass="autowidupdatebut"
                            Width="100px" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXPORT_SW_Stmt_Bulk();return false;" />
                    </div>
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9', 'page-10', 'page-11', 'page-12', 'page-13', 'page-14']);
            </script>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Item_Edit" runat="server" />
            <asp:HiddenField ID="hdn_ITEM_AOUNT" runat="server" />
            <asp:HiddenField ID="hdn_Scheme" runat="server" />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="hdn_Invoice_Exrate" runat="server" />
            <asp:HiddenField ID="hdn_Check_Item_Update" runat="server" />
            <asp:HiddenField ID="hdn_Update_Item" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Count" runat="server" />
            <asp:HiddenField ID="hdn_Grid_RowCount" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hditem_id" runat="server" />
            <asp:HiddenField ID="hditem_sl_no" runat="server" />
            <asp:HiddenField ID="hdn_Company_IDD" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="HDsaveid" runat="server" />
            <asp:HiddenField ID="hdn_companyID" runat="server" />
            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_dbk_Qty" runat="server" />
            <asp:HiddenField ID="hdn_dbk_unit" runat="server" />
            <asp:HiddenField ID="hdn_DWBK_QTY" runat="server" />
            <asp:HiddenField ID="hdn_Same_Diff" runat="server" />
            <asp:HiddenField ID="hdn_FOB_Disc_Rate" runat="server" />
            <asp:HiddenField ID="hdn_FOB_Disc_Charges" runat="server" />
            <asp:HiddenField ID="hdn_InvoiceValue" runat="server" />
            <asp:HiddenField ID="hdn_Item_Total" runat="server" />
            <asp:HiddenField ID="hdn_Inv_Total" runat="server" />
            <asp:HiddenField ID="hdn_UnitCode" runat="server" />
            <asp:HiddenField ID="Hdn_RITC_4_digit" runat="server" />
            <asp:HiddenField ID="Hdn_ROSL" runat="server" />
            <asp:HiddenField ID="hdn_currentPage" runat="server" />
            <asp:HiddenField ID="hdn_source" runat="server" />
            <asp:HiddenField ID="hdn_PMV_Rate" runat="server" />
            <asp:HiddenField ID="hdn_PMVValue" runat="server" />
            <asp:HiddenField ID="hdn_PMV_PER_UNIT" runat="server" />
            <asp:HiddenField ID="hdn_Invoice_Currency" runat="server" />
            <asp:HiddenField ID="hdn_Chk_District" runat="server" />
            <asp:HiddenField ID="hdn_Chk_State" runat="server" />
            <asp:HiddenField ID="hdn_Chk_InfoUQC" runat="server" />
            <asp:HiddenField ID="hdn_Taxable_igst_Decimal" runat="server" />
            <asp:HiddenField ID="hdn_JOBNO" runat="server" />
            <asp:HiddenField ID="hdn_branch" runat="server" />
            <asp:HiddenField ID="hdn_grid_scroll_retain" runat="server" />
            <asp:HiddenField ID="hdn_Last_Itemslno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Item_Main_Menu" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Inner_tab_Menu" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_ExporterName" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_EXPORT_SBTYPE" runat="server" />
            <asp:HiddenField ID="hdnRITCPolicy" runat="server" ClientIDMode="Static" Value="" />
            <asp:HiddenField ID="hdnIsNewClick" runat="server" ClientIDMode="Static" Value="" />

        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="Button1" runat="server" Text="Ok" OnClientClick="return HideModalPopup_Job()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    <%-- ---------------------------------------------------------ModelpopUp---Toatal amount------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MPEU" runat="server" TargetControlID="HDF" PopupControlID="MessageDivupdated"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDF" runat="server" />
    <asp:Panel ID="MessageDivupdated" runat="server" DefaultButton="btnYes" align="center"
        Style="padding-left: 0px; width: 280px; height: 205px; margin-top: -150px; display: none;"
        BorderColor="Transparent">
        <%-- DefaultButton="btnYes" Not working --%>
        <%-- <asp:Panel ID="MessageDivupdated" runat="server"  DefaultButton="btnYes" align="center" style="padding-left:0px;width: 280px; height:205px;" 
    BorderColor="Transparent">--%>
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 310px; height: 205px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label2" runat="server" Text="Saved Successfully."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label1" runat="server" Text="Add Next Item. Yes / No"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 100px; padding-top: 10px;">
                        <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnNo" runat="server" Text="No" OnClientClick="return HideModalPopup()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        ---------------------------------------------------
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        Total Invoice Amount:
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="ltInv_amt" Width="70px" ReadOnly="true" runat="server" ForeColor="Black"
                            BackColor="#F2F2F2" Style="text-align: right; border-bottom: 1px solid white;
                            border-left: 0px solid white; border-right: 0px solid white; border-top: 0px solid white;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Total Item Amount:
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtitem_amt" Width="70px" ReadOnly="true" runat="server" ForeColor="Black"
                            BackColor="#F2F2F2" Style="text-align: right; border-bottom: 1px solid black;
                            border-left: 0px solid white; border-right: 0px solid white; border-top: 0px solid white;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Balance Invoice Amount:
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbal" Width="70px" runat="server" ReadOnly="true" ForeColor="Black"
                            BackColor="#F2F2F2" Style="text-align: right; border-bottom: 1px solid black;
                            border-left: 0px solid white; border-right: 0px solid white; border-top: 0px solid white;"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------ModelpopUp---2-----Item Not Save-------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup" align="center"
        Style="padding-left: 0px; width: 280px; height: 105px; display: none; margin-top: -150px;"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 310px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblnotsave" runat="server"></asp:Label><%-- Text="Item Not Saved."--%>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label4" runat="server" Text="Product is Higher than Invoice Value."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 130px; padding-top: 10px;">
                        <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------ModelpopUp---Drawback------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MPU_DBK" runat="server" TargetControlID="HDF_dbk" PopupControlID="Panel1"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDF_dbk" runat="server" />
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="padding-left: 0px;
        width: 680px; height: 355px; margin-top: -150px;" BorderColor="Transparent">
        <%--<div id="pop_text_area_transac_inn_container_left_export_drawback" style="height:255px">--%>
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 680px; height: 355px;">
            <div id="tag_transac_exp_drawback" style="text-align: center; width: 500px; font-weight: bold;
                margin-top: 10px;">
                <div id="tag_label_transaction_exp_draw" style="text-align: center; width: 500px;
                    height: 30px;">
                    Drawback Details
                </div>
            </div>
            <div id="tag_transac_exp_drawback">
                <div id="tag_label_transaction_exp_draw" style="margin-left: 20px;">
                    Drawback SL No
                </div>
                <div id="txt_trans_exp_drawback">
                    <asp:TextBox ID="txtDrawback_SLNo" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                        ClientIDMode="Static" onkeypress="return charnum2(event)" MaxLength="15" TabIndex="1"></asp:TextBox>
                </div>
                <div id="txt_trans_exp_drawback">
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupDrawback('EXPORT_DrawbackNo',document.getElementById('hdn_UnitCode').value); return false"
                        class="magnfy"></a>
                </div>
            </div>
            <div id="tag_transac_exp_drawback">
                <div id="tag_label_transaction_exp_draw" style="margin-left: 20px;">
                    Drawback Qty
                </div>
                <div id="txt_trans_exp_drawback">
                    <asp:TextBox ID="txtDrawback_Qty" runat="server" CssClass="validate[required,custom[number]] txtbox_trans_exp_drawback"
                        onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="2" MaxLength="12"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_exp_draw2_new1" style="width: 115px;">
                    Drawback Unit
                </div>
                <div id="txt_trans_exp_drawback_new">
                    <asp:TextBox ID="txtDrawback_Unit" runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                        ClientIDMode="Static" onblur="ChangeCase(this);" onkeypress="return cha(event)"
                        TabIndex="3" MaxLength="3"></asp:TextBox>
                </div>
                <div id="txtcon-m_transaction_item_maindet">
                    No Of Unit
                </div>
                <div id="txt_trans_exp_drawback" style="width: 65px;">
                    <asp:TextBox ID="txtDrawback_No_Of_Unit" Width="50px" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                        ClientIDMode="Static" TabIndex="4" MaxLength="4"></asp:TextBox>
                </div>
            </div>
            <div id="tag_transac_exp_drawback">
                <div id="tag_label_transaction_exp_draw" style="margin-left: 20px;">
                    Drawback Rate
                </div>
                <div id="txt_trans_exp_drawback">
                    <asp:TextBox ID="txtDrawback_Rate" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                        ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="5" MaxLength="12"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_exp_draw2_new1" style="width: 115px;">
                    Drawback Cap
                </div>
                <div id="txt_trans_exp_drawback">
                    <asp:TextBox ID="txtDrawback_Cap" runat="server" CssClass="txtbox_trans_exp_drawback"
                        ClientIDMode="Static" MaxLength="12" onkeypress="return charnum2(event)" TabIndex="6"></asp:TextBox>
                </div>
            </div>
            <span id="ROSL" runat="server" visible="false">
                <div id="tag_transac_exp_drawback" style="margin-left: 20px;">
                    <div id="tag_label_transaction_exp_draw">
                        State lev. Adv. Rate
                    </div>
                    <div id="txt_trans_exp_drawback">
                        <asp:TextBox ID="txtstate_level_adv_Rate" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                            ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="7" MaxLength="12"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_exp_draw2_new1" style="width: 115px;">
                        State lev. Adv. Amt
                    </div>
                    <div id="txt_trans_exp_drawback">
                        <asp:TextBox ID="txtstate_level_adv_Amt" runat="server" CssClass="txtbox_trans_exp_drawback"
                            ClientIDMode="Static" MaxLength="12" onkeypress="return charnum2(event)" TabIndex="8"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_exp_drawback">
                    <div id="tag_label_transaction_exp_draw" style="margin-left: 20px;">
                        Central lev. Adv.Rate
                    </div>
                    <div id="txt_trans_exp_drawback">
                        <asp:TextBox ID="txtCentral_level_adv_Rate" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                            ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="9" MaxLength="12"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_exp_draw2_new1" style="width: 115px;">
                        Central lev.Adv.Amt
                    </div>
                    <div id="txt_trans_exp_drawback">
                        <asp:TextBox ID="txtCentral_level_adv_Amt" runat="server" CssClass="txtbox_trans_exp_drawback"
                            ClientIDMode="Static" MaxLength="12" onkeypress="return charnum2(event)" TabIndex="10"></asp:TextBox>
                    </div>
                </div>
            </span>
            <div id="tag_transac_exp_drawback_multi">
                <div id="tag_label_transaction_exp_draw" style="margin-left: 20px;">
                    Drawback Desc
                </div>
                <div id="txt_trans_exp_drawback_multitxt">
                    <asp:TextBox ID="txtDrawback_Desc" runat="server" TextMode="MultiLine" CssClass="validate[required] txtbox_trans_exp_drawback_multiline"
                        MaxLength="300" ClientIDMode="Static" onkeyDown="return checkTextAreaMaxLength(this,event,'300');"
                        Height="100px" Width="458px" onpaste="return checkTextAreaMaxLength(this,event,'300');"
                        TabIndex="11"></asp:TextBox>
                </div>
            </div>
            <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <asp:Button ID="btnNew_dbk" runat="server" CssClass="new" CausesValidation="false"
                        UseSubmitBehavior="false" Visible="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                        TabIndex="12" OnClick="btnNew_Click" /></div>
                <div id="editbu">
                    <asp:Button ID="btnSave_dbk" runat="server" CssClass="save" OnClientClick="Confirm();return validate_Export_Drawback();"
                        TabIndex="12" OnClick="btnSave_dbk_Click" /></div>
                <div id="editbu">
                    <%--<input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1('ITEM_ID');return false;"
                        tabindex="10" id="btnCancel_dbk" /></div>--%>
                    <asp:Button ID="btnCancel_dbk" runat="server" Text="Close" class="scancel" OnClientClick="return  HideModalPopup_DBK()"
                        CausesValidation="false" UseSubmitBehavior="false" TabIndex="13" />
                </div>
            </div>
        </div>
    </asp:Panel>
    </form>
    <script src="../js/Export_Jscript/Export_Item.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/jquery.textchange.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Autotab.js" type="text/javascript"></script>
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
    </script>
    <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_DrawBack.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

            var totalRows = $("#<%=gv_Item.ClientID %> tr").length;
            var lastProductId = $("#<%=gv_Item.ClientID %> tr:last").children("td:first").html();


            if (totalRows > 2) {

                // gridviewScroll();

            }
            else {

                if (lastProductId > 0) {
                    //gridviewScroll();
                }
                else {
                    if (lastProductId > 0) {
                        //gridviewScroll();
                    }
                    else {

                        document.getElementById('<%=gv_Item.ClientID %>').style.width = "100%";
                        document.getElementById('<%=gv_Item.ClientID %>').style.overflow = "100%";
                    }

                }
            }
        });

        function gridviewScroll() {
            gridView1 = $('#<%=gv_Item.ClientID %>').gridviewScroll({

                width: 694,
                height: 160,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 1,
                arrowsize: 30,
                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",
                headerrowcount: 1,
                railsize: 16,
                barsize: 15

            });
        }

    </script>
    <script type="text/javascript">
        function tab_page1(val) {
            document.getElementById("ITEM_ID").click();
            // gridviewScroll_2();
            document.getElementById("page-1").style.display = 'Block';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("page-5").style.display = 'none';
            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'none';
            document.getElementById("page-8").style.display = 'none';
            document.getElementById("page-9").style.display = 'none';

            document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
            document.getElementById("Export_Item").style.display = 'Block';
            document.getElementById("OTHER_DETAILS_ID").className = 'inactive';
            document.getElementById("drawback").className = 'inactive';
            document.getElementById("jobbing").className = 'inactive';
            document.getElementById("EPCG").className = 'inactive';
            document.getElementById("DEEC").className = 'inactive';
            document.getElementById("DFIA").className = 'inactive';
            document.getElementById("Cess").className = 'inactive';
            document.getElementById("Quota").className = 'inactive';
        }

        function gridviewScroll_2() {
            gridView1 = $('#<%=gv_Item.ClientID %>').gridviewScroll({

                width: 694,
                height: 183,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 1,
                arrowsize: 30,
                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",
                headerrowcount: 1,
                railsize: 16,
                barsize: 15

            });

            $.ajax({
                type: "POST",
                url: "Item_Details.aspx/Check_DBK_Avail_js",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d == "OK") {
                        alert("OK")
                    } else {
                        var reslt = msg.d;
                        //                        alert(msg.d);
                        //                        $('#hdn_DWBK_QTY').val(reslt);
                        //                        alert(reslt);

                        $('#hdn_dbk_Qty').val(reslt);
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
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
    </script>
    <script language="jscript" type="text/javascript">
        $(document).ready(function () {
            var ddl = $('#ddl_IGST_Payment').val();
            var companyID = $('#hdn_companyID').val();

            var Exrate = $('#hdn_Invoice_Exrate').val();
            var ItemQty = $('#txtItemQty').val();
            var UnitPrice = $('#txtItem_UnitPrice').val();
            var hdn_Taxable_igst_Decimal = $('#hdn_Taxable_igst_Decimal').val();

            var TaxableValue = '';

            //-------------------- Exrate - Conversion ---------------------
            var Inv_Currency = $('#hdn_Invoice_Currency').val();
            if (Inv_Currency == 'JPY' || Inv_Currency == 'KRW') {
                Exrate = parseFloat(Exrate) / 100;
            }
            //--------------------------------------------------------------

            var Tax_enable = '0';
            if (companyID == '496' || companyID == '170' || companyID == '276' || companyID == '655' || companyID == '1088' || companyID == '2228' || companyID == '2865') {
                Tax_enable = '1';
            }
            else if (companyID == '2262') {
                if (document.getElementById("hdn_ExporterName").value == 'MYLAN LABORATORIES LIMITED') {
                    Tax_enable = '1';
                }
            }

            if (ddl == 'P') {

                document.getElementById("txt_TaxableValue").disabled = false;
                document.getElementById("txt_IGST_Amt").disabled = false;
                document.getElementById("txt_IGST_Rate").disabled = false;

            }
            else if (ddl == 'LUT') {

                if (Tax_enable == '1') {
                    document.getElementById("txt_TaxableValue").disabled = false;
                    document.getElementById("txt_IGST_Amt").disabled = true;
                    document.getElementById("txt_IGST_Rate").disabled = true;

                    $('#txt_IGST_Amt').val('');
                    $('#txt_IGST_Rate').val('');
                }
                else {

                    document.getElementById("txt_TaxableValue").disabled = true;
                    document.getElementById("txt_IGST_Amt").disabled = true;
                    document.getElementById("txt_IGST_Rate").disabled = true;

                    $('#txt_TaxableValue').val('');
                    $('#txt_IGST_Amt').val('');
                    $('#txt_IGST_Rate').val('');
                }
            }
            else {

                document.getElementById("txt_TaxableValue").disabled = true;
                document.getElementById("txt_IGST_Amt").disabled = true;
                document.getElementById("txt_IGST_Rate").disabled = true;

                $('#txt_TaxableValue').val('');
                $('#txt_IGST_Amt').val('');
                $('#txt_IGST_Rate').val('');
            }

            $('#ddl_IGST_Payment,#txtItem_UnitPrice,#txtItemQty,#txtItem_Amount,#txtPer').change(function () {
                var ddl = $('#ddl_IGST_Payment').val();
                var ItemQty = $('#txtItemQty').val();
                var UnitPrice = $('#txtItem_UnitPrice').val();

                var Total_InvVal = $('#hdn_InvoiceValue').val();
                var DISC_Rate = $('#hdn_FOB_Disc_Rate').val();
                var DISC_Amt = $('#hdn_FOB_Disc_Charges').val();
                var RatePer = $('#txtPer').val();
                var hdn_Taxable_igst_Decimal = $('#hdn_Taxable_igst_Decimal').val();


                if (ddl == 'P') {

                    document.getElementById("txt_TaxableValue").disabled = false;
                    document.getElementById("txt_IGST_Amt").disabled = false;
                    document.getElementById("txt_IGST_Rate").disabled = false;

                    DISC_Amt = DISC_Amt * Exrate;
                    Total_InvVal = Total_InvVal * Exrate;

                    var ind_inv = (ItemQty * UnitPrice * Exrate) / RatePer; // individual Invoice value
                    var ind_disc_amt = (DISC_Amt * ind_inv) / Total_InvVal; // individual Disc amount for particular item.
                    
                    var calc_IndVal = ItemQty * UnitPrice;   //(ItemQty * UnitPrice - Round off as same as Invoice value(2 digit))
                    var calc_IndVal2 = calc_IndVal.toFixed(2);
                    var calc_ex = calc_IndVal2 * Exrate;
                    var calc = calc_ex / RatePer;


                    calc = calc - ind_disc_amt;

                    if (hdn_Taxable_igst_Decimal == 'E') {
                        TaxableValue = calc.toFixed(2);
                    }
                    else {
                        //TaxableValue = decimal_convert_to_Int(parseFloat(calc), 0);
                        TaxableValue = decimal_round(parseFloat(calc), 0);
                    }

                    $('#txt_TaxableValue').val(TaxableValue);
                    var IGST_Rate = $('#txt_IGST_Rate').val();
                    if (IGST_Rate != '') {

                        var IGST_Amt = TaxableValue * IGST_Rate / 100;

                        if (hdn_Taxable_igst_Decimal == 'E') {
                            IGST_Amt = IGST_Amt.toFixed(2);
                        }
                        else {
                            // IGST_Amt = decimal_convert_to_Int(parseFloat(IGST_Amt), 0);
                            IGST_Amt = decimal_round(parseFloat(IGST_Amt), 0);
                        }
                        $('#txt_IGST_Amt').val(IGST_Amt);

                    }

                }
                else if (ddl == 'LUT') {

                    if (Tax_enable == '1') {
                        document.getElementById("txt_TaxableValue").disabled = false;
                        document.getElementById("txt_IGST_Amt").disabled = true;
                        document.getElementById("txt_IGST_Rate").disabled = true;

                        DISC_Amt = DISC_Amt * Exrate;
                        Total_InvVal = Total_InvVal * Exrate;

                        var ind_inv = (ItemQty * UnitPrice * Exrate) / RatePer; // individual Invoice value
                        var ind_disc_amt = (DISC_Amt * ind_inv) / Total_InvVal; // individual Disc amount for particular item.

                        var calc_ex = Exrate * ItemQty * UnitPrice;
                        var calc = calc_ex / RatePer; // divide by Rate per for Seamanlog
                        calc = calc - ind_disc_amt;
                        TaxableValue = calc.toFixed(2);
                        $('#txt_TaxableValue').val(TaxableValue);


                        $('#txt_IGST_Amt').val('');
                        $('#txt_IGST_Rate').val('');
                    }
                    else {

                        document.getElementById("txt_TaxableValue").disabled = true;
                        document.getElementById("txt_IGST_Amt").disabled = true;
                        document.getElementById("txt_IGST_Rate").disabled = true;

                        $('#txt_TaxableValue').val('');
                        $('#txt_IGST_Amt').val('');
                        $('#txt_IGST_Rate').val('');
                    }
                }
                else {

                    document.getElementById("txt_TaxableValue").disabled = true;
                    document.getElementById("txt_IGST_Amt").disabled = true;
                    document.getElementById("txt_IGST_Rate").disabled = true;

                    $('#txt_TaxableValue').val('');
                    $('#txt_IGST_Amt').val('');
                    $('#txt_IGST_Rate').val('');
                }

            });

            //   -----------------------------------------------------hide on 05-11-2022 for IGST Amt Round off issue-------------------------------------   

            $('#txt_IGST_Rate').keyup(function () {

                var TaxableValue1 = $('#txt_TaxableValue').val();
                var IGST_Rate = $('#txt_IGST_Rate').val();

                var IGST_Amt = TaxableValue1 * IGST_Rate / 100;

                if (hdn_Taxable_igst_Decimal == 'E') {

                    IGST_Amt_result = IGST_Amt.toFixed(2);
                }
                else {
                    //IGST_Amt_result = decimal_convert_to_Int(parseFloat(IGST_Amt), 0);
                    IGST_Amt_result = decimal_round(parseFloat(IGST_Amt), 0);
                }
                $('#txt_IGST_Amt').val(IGST_Amt_result);

            });

            //-----------------------------------------------------------------------------------------
            $('#txt_TaxableValue').keyup(function () {
                var TaxableValue1 = $('#txt_TaxableValue').val();
                var IGST_Rate = $('#txt_IGST_Rate').val();

                var IGST_Amt = TaxableValue1 * IGST_Rate / 100;

                if (hdn_Taxable_igst_Decimal == 'E') {
                    IGST_Amt_result = IGST_Amt.toFixed(2);
                }
                else {
                    //                    IGST_Amt_result = decimal_convert_to_Int(IGST_Amt, 0);
                    IGST_Amt_result = decimal_round(parseFloat(IGST_Amt), 0);

                }
                $('#txt_IGST_Amt').val(IGST_Amt_result);
            });

            function roundToTwo(num) {
                return +(Math.round(num + "e+2") + "e-2");
            }
        });

        function decimal_round(num, decimalPlaces) {

            var n = num.toString().includes(".");
            if (n == true) {
                var a = num.toString().split(".");
                if (a[1].length >= 1) {
                    var x = a[1].substring(0, 1);

                    if (a[1].substring(0, 1) > 5) {
                        result = parseInt(a[0]) + 1;
                    }
                    else {
                        result = parseInt(a[0]);
                    }
                }
            }
            else {
                result = num;
            }
            return (result);
        }

        //-------- Newly done by Chithra on 27-12-2021 Sugg.By Bala sir for Seagull
        function decimal_convert_to_Int(num, decimalPlaces) {

            var n = num.toString().includes(".");
            if (n == true) {
                var a = num.toString().split(".");
                result = parseInt(a[0]);
            }
            else {
                result = num;
            }
            return (result);
        }      
    </script>
    <script type="text/javascript">
        function Go_Product() {

            var a = $("#ddlRewardPoints option:selected").text();
            var b = $("#ddl_STR_YN option:selected").text();
            var Compid = document.getElementById("<%=hdn_companyID.ClientID%>").value


            PageMethods.Save_Product(document.getElementById("<%=txtDescription.ClientID%>").value, document.getElementById("<%=txtRITCNo.ClientID%>").value, a, b, document.getElementById("<%=txtSTRCode.ClientID%>").value, OnSuccess);

            if (Compid == '1' || Compid == '10' || Compid == '517') {
                PageMethods.Save_Product_PDF_Master(document.getElementById("<%=hdn_JOBNO.ClientID%>").value, document.getElementById("<%=hdinvslno.ClientID%>").value, document.getElementById("<%=ddl_ItemSlno.ClientID%>").value, document.getElementById("<%=hdn_branch.ClientID%>").value, OnSuccess);
            }
        }
        function OnSuccess(response, userContext, methodName) {
            jAlert(response, 'Product', function (r) { });
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            /*
            var ddl, Inv_no;
            ddl = document.getElementById("ddlInv_SL_No");
            Inv_no = ddl.options[ddl.selectedIndex].text;
            //----------------------GST--s------------------------------------------
            $('#txtDescription').focus(function () {

            Load_Inv_Item_Val(Inv_no, '1');
            });
            $('#txtDescription').change(function () {
            Load_Inv_Item_Val(Inv_no, '1');
            });
            $('#txtDescription').keyup(function () {

            Load_Inv_Item_Val(Inv_no, '1');
            });
            $('#txtDescription').keydown(function () {

            Load_Inv_Item_Val(Inv_no, '1');
            });
            //--------------------------------------------------
            $('#txtRITCNo').focus(function () {

            Load_Inv_Item_Val(Inv_no, '1');
            });
            $('#txtRITCNo').change(function () {
            Load_Inv_Item_Val(Inv_no, '1');
            });
            $('#txtRITCNo').keyup(function () {

            Load_Inv_Item_Val(Inv_no, '1');
            });
            $('#txtRITCNo').keydown(function () {

            Load_Inv_Item_Val(Inv_no, '1');
            });
            //--------------------------------------------------
            */

            $('#txtItemQty').keyup(function () {

                var e;
                var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, txtItem_UnitPrice, lblInvoiceValue
              , hdn_Invoice_Exrate;

                hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
                txtItem_Amount = document.getElementById("txtItem_Amount").value;
                hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
                e = document.getElementById("ddlInv_SL_No");
                ddlInv_SL_No = e.options[e.selectedIndex].text;
                HiddenField1 = document.getElementById("HiddenField1").value;
                txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;
                lblInvoiceValue = document.getElementById("lblInvoiceValue").innerHTML;
                hdn_Invoice_Exrate = document.getElementById("hdn_Invoice_Exrate").value;
                var txtItemQty = document.getElementById("txtItemQty").value;

                var txtPMV_Rate = document.getElementById("txtPMV_Rate").value;
                var ddl_PMV_method = document.getElementById("ddl_PMV_method").value;
                var Total_InvVal = $('#hdn_InvoiceValue').val();
                var DISC_Rate = $('#hdn_FOB_Disc_Rate').val();
                var DISC_Amt = $('#hdn_FOB_Disc_Charges').val();
                var RatePer = $('#txtPer').val();


                var txt_PMV_PerUnit = document.getElementById("txt_PMV_PerUnit").value;
                var companyID = $('#hdn_companyID').val();

                //-------------------- Exrate - Conversion ---------------------
                var Inv_Currency = $('#hdn_Invoice_Currency').val();
                if (Inv_Currency == 'JPY' || Inv_Currency == 'KRW') {
                    hdn_Invoice_Exrate = parseFloat(hdn_Invoice_Exrate) / 100;
                }
                //--------------------------------------------------------------

                DISC_Amt = DISC_Amt * hdn_Invoice_Exrate;
                Total_InvVal = Total_InvVal * hdn_Invoice_Exrate;

                if (hdn_ITEM_AOUNT == "") {
                    TOTAL = 0;
                }
                else {
                    TOTAL = hdn_ITEM_AOUNT;
                }

                var Sum_Inv_Amt = 0, Sum_Item_Amt = 0, Unit_Price = 0, Amount = 0;

                Sum_Inv_Amt = document.getElementById("hdn_Inv_Total").value;
                Sum_Item_Amt = document.getElementById("hdn_Item_Total").value;

                //----------------New Val------05-----------------
                var regex = /(?:\d*\.\d{1,2}|\d+)$/;
                if (regex.test(txtItemQty)) {
                    if (parseFloat(txtItemQty) > 0) {
                        Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                    }
                    else {
                        txtItemQty = '0';
                    }
                } else {
                    txtItemQty = '0';
                }
                //------------------------------------------


                if (hdn_Item_Edit == 'U') {

                    if (txtItemQty == '' || txtItemQty == '0') {
                        Unit_Price = '0';
                    }
                    else {
                        Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                    }


                    if (companyID == '1' || companyID == '10' || companyID == '2226') {//Rosemount - Checked with final print on 29-01-2024 sugg.by Bala sir
                        Amount = (parseFloat(txtItemQty) * parseFloat(Unit_Price)).toFixed(2);
                    }
                    else {
                        Amount = (parseFloat(txtItemQty) * parseFloat(Unit_Price)).toFixed(5);
                    }

                    // this line hide by Chithra on 14-01-2020 for PMV Rate impelmentation
                    // PMV_Amount = ((((parseFloat(txtItemQty) * parseFloat(Unit_Price) * parseFloat(hdn_Invoice_Exrate)) * 110) / 100)).toFixed(2); 


                    var ind_inv = (txtItemQty * Unit_Price * hdn_Invoice_Exrate) / RatePer; // individual Invoice value
                    var ind_disc_amt = (DISC_Amt * ind_inv) / Total_InvVal; // individual Disc amount for particular item.

                    var calc_IndVal = txtItemQty * Unit_Price;   //(ItemQty * UnitPrice - Round off as same as Invoice value(2 digit))
                    var calc_IndVal2 = calc_IndVal.toFixed(2);
                    var calc_ex = calc_IndVal2 * hdn_Invoice_Exrate;
                    var calc = calc_ex / RatePer;

                    calc = calc - ind_disc_amt;
                    var PMV_Amount = 0;
                    PMV_Amount = calc.toFixed(2);
                    //            PMV_Amount = roundToTwo(calc);

                    if (txtPMV_Rate != '') {
                        PMV_Amount = (parseFloat(PMV_Amount) * parseFloat(txtPMV_Rate) / 100).toFixed(2);
                    }
                    else {
                        PMV_Amount = (parseFloat(PMV_Amount) * 110 / 100).toFixed(2);
                    }

                    var PMV_Perunit = 0;
                    if (ddl_PMV_method == 'Rate') {
                        PMV_Perunit = (parseFloat(PMV_Amount) / parseFloat(txtItemQty)).toFixed(2);
                    }
                    else {
                        PMV_Perunit = txt_PMV_PerUnit;
                    }

                    if (txtItemQty != '0') {
                        document.getElementById("txtItem_Amount").value = Amount;
                        document.getElementById("txtItem_UnitPrice").value = Unit_Price;
                        document.getElementById("txtPMVValue").value = PMV_Amount;
                        document.getElementById("hdn_PMVValue").value = PMV_Amount;

                        document.getElementById("txt_PMV_PerUnit").value = PMV_Perunit;
                        document.getElementById("hdn_PMV_PER_UNIT").value = PMV_Perunit;

                    }
                    //----------------New Val------05-----------------
                    else {
                        document.getElementById("txtItem_Amount").value = '';
                        document.getElementById("txtItem_UnitPrice").value = '';
                        document.getElementById("txtItemQty").focus();
                        document.getElementById("txtPMVValue").value = '';
                        document.getElementById("hdn_PMVValue").value = '';
                        document.getElementById("txt_PMV_PerUnit").value = '';
                        document.getElementById("hdn_PMV_PER_UNIT").value = '';
                    }

                    if (txtItemQty == '') {
                        document.getElementById("txtItem_Amount").value = '';
                        document.getElementById("txtItem_UnitPrice").value = '';
                        document.getElementById("txtItemQty").focus();
                        document.getElementById("txtPMVValue").value = '';
                        document.getElementById("hdn_PMVValue").value = '';
                        document.getElementById("txt_PMV_PerUnit").value = '';
                        document.getElementById("hdn_PMV_PER_UNIT").value = '';
                    }

                } //-----------
                else {


                    if (txtItemQty == '' || txtItemQty == '0') {
                        Unit_Price = '0';
                    }
                    else {
                        Unit_Price = ((parseFloat(Sum_Inv_Amt) - parseFloat(Sum_Item_Amt)) / parseFloat(txtItemQty)).toFixed(5);
                    }


                    if (companyID == '1' || companyID == '10' || companyID == '2226') {//Rosemount - Checked with final print on 29-01-2024 sugg.by Bala sir
                        Amount = (parseFloat(txtItemQty) * parseFloat(Unit_Price)).toFixed(2);
                    }
                    else {
                        Amount = (parseFloat(txtItemQty) * parseFloat(Unit_Price)).toFixed(5);
                    }



                    //  PMV_Amount = ((((parseFloat(txtItemQty) * parseFloat(Unit_Price) * parseFloat(hdn_Invoice_Exrate)) * 110) / 100)).toFixed(2);

                    var ind_inv = (txtItemQty * Unit_Price * hdn_Invoice_Exrate) / RatePer; // individual Invoice value
                    var ind_disc_amt = (DISC_Amt * ind_inv) / Total_InvVal; // individual Disc amount for particular item.

                    var calc_IndVal = txtItemQty * Unit_Price;   //(ItemQty * UnitPrice - Round off as same as Invoice value(2 digit))
                    var calc_IndVal2 = calc_IndVal.toFixed(2);
                    var calc_ex = calc_IndVal2 * hdn_Invoice_Exrate;
                    var calc = calc_ex / RatePer;

                    calc = calc - ind_disc_amt;
                    var PMV_Amount = 0;
                    PMV_Amount = calc.toFixed(2);
                    //            PMV_Amount = roundToTwo(calc);

                    if (txtPMV_Rate != '') {
                        PMV_Amount = (parseFloat(PMV_Amount) * parseFloat(txtPMV_Rate) / 100).toFixed(2);
                    }
                    else {
                        PMV_Amount = (parseFloat(PMV_Amount) * 110 / 100).toFixed(2);
                    }

                    var PMV_Perunit = 0;
                    if (ddl_PMV_method == 'Rate') {
                        PMV_Perunit = (parseFloat(PMV_Amount) / parseFloat(txtItemQty)).toFixed(2);
                    }
                    else {
                        PMV_Perunit = txt_PMV_PerUnit;
                    }


                    if (txtItemQty != '0') {
                        document.getElementById("txtItem_Amount").value = Amount;
                        document.getElementById("txtItem_UnitPrice").value = Unit_Price;
                        document.getElementById("txtPMVValue").value = PMV_Amount;
                        document.getElementById("hdn_PMVValue").value = PMV_Amount;
                        document.getElementById("txt_PMV_PerUnit").value = PMV_Perunit;
                        document.getElementById("hdn_PMV_PER_UNIT").value = PMV_Perunit;
                    }
                    //----------------New Val------05-----------------
                    else {
                        document.getElementById("txtItem_Amount").value = '';
                        document.getElementById("txtItem_UnitPrice").value = '';
                        document.getElementById("txtItemQty").focus();
                        document.getElementById("txtPMVValue").value = '';
                        document.getElementById("hdn_PMVValue").value = '';
                        document.getElementById("txt_PMV_PerUnit").value = '';
                        document.getElementById("hdn_PMV_PER_UNIT").value = '';

                    }
                    if (txtItemQty == '') {
                        document.getElementById("txtItem_Amount").value = '';
                        document.getElementById("txtItem_UnitPrice").value = '';
                        document.getElementById("txtItemQty").focus();
                        document.getElementById("txtPMVValue").value = '';
                        document.getElementById("hdn_PMVValue").value = '';
                        document.getElementById("txt_PMV_PerUnit").value = '';
                        document.getElementById("hdn_PMV_PER_UNIT").value = '';

                    }

                } //-----------else--E

            });
            //-----------------------------------

            $('#txtItem_UnitPrice').keyup(function () {

                var e;
                // call server side method
                var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, txtItemQty, hdn_Invoice_Exrate, lblInvoiceValue;
                hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
                txtItem_Amount = document.getElementById("txtItem_Amount").value;
                hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
                //ddlInv_SL_No = document.getElementById("ddlInv_SL_No").value;
                e = document.getElementById("ddlInv_SL_No");
                ddlInv_SL_No = e.options[e.selectedIndex].text;
                HiddenField1 = document.getElementById("HiddenField1").value;
                txtItemQty = document.getElementById("txtItemQty").value;
                hdn_Invoice_Exrate = document.getElementById("hdn_Invoice_Exrate").value;
                lblInvoiceValue = document.getElementById("lblInvoiceValue").innerHTML;
                var ddl_PMV_method = document.getElementById("ddl_PMV_method").value;

                var txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;

                var txtPMV_Rate = document.getElementById("txtPMV_Rate").value;
                var Total_InvVal = $('#hdn_InvoiceValue').val();
                var DISC_Rate = $('#hdn_FOB_Disc_Rate').val();
                var DISC_Amt = $('#hdn_FOB_Disc_Charges').val();
                var RatePer = $('#txtPer').val();

                var txt_PMV_PerUnit = document.getElementById("txt_PMV_PerUnit").value;
                var companyID = $('#hdn_companyID').val();

                //-------------------- Exrate - Conversion ---------------------
                var Inv_Currency = $('#hdn_Invoice_Currency').val();
                if (Inv_Currency == 'JPY' || Inv_Currency == 'KRW') {
                    hdn_Invoice_Exrate = parseFloat(hdn_Invoice_Exrate) / 100;
                }
                //--------------------------------------------------------------

                DISC_Amt = DISC_Amt * hdn_Invoice_Exrate;
                Total_InvVal = Total_InvVal * hdn_Invoice_Exrate;

                var Item_Amt = 0, PMV_Value = 0;

                //----------------New Val------05-----------------
                var regex = /(?:\d*\.\d{1,2}|\d+)$/;
                if (regex.test(txtItemQty)) {
                    if (parseFloat(txtItemQty) > 0) {
                        //Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                    }
                    else {
                        txtItemQty = '0';
                    }
                } else {
                    txtItemQty = '0';
                }

                //------------------------------------------
                if (regex.test(txtItem_UnitPrice)) {
                    if (parseFloat(txtItem_UnitPrice) > 0) {
                        //Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                    }
                    else {
                        txtItem_UnitPrice = '0';
                    }
                } else {
                    txtItem_UnitPrice = '0';
                }
                //------------------------------------------


                if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".") {
                    if (companyID == '1' || companyID == '10' || companyID == '2226') {//Rosemount - Checked with final print on 29-01-2024 sugg.by Bala sir
                        Item_Amt = (parseFloat(txtItemQty) * parseFloat(txtItem_UnitPrice)).toFixed(2);
                    }
                    else {
                        Item_Amt = (parseFloat(txtItemQty) * parseFloat(txtItem_UnitPrice)).toFixed(5);
                    }
                }

                if (hdn_Invoice_Exrate != "") {

                    // this line hide by Chithra on 14-01-2020 for PMV Rate impelmentation
                    //   PMV_Value = ((parseFloat(txtItemQty) * parseFloat(txtItem_UnitPrice) * (parseFloat(hdn_Invoice_Exrate) * 110)) / 100.00).toFixed(2);

                    var ind_inv = (txtItemQty * txtItem_UnitPrice * hdn_Invoice_Exrate) / RatePer; // individual Invoice value
                    var ind_disc_amt = (DISC_Amt * ind_inv) / Total_InvVal; // individual Disc amount for particular item.

                    var calc_IndVal = txtItemQty * txtItem_UnitPrice;   //(ItemQty * UnitPrice - Round off as same as Invoice value(2 digit))
                    var calc_IndVal2 = calc_IndVal.toFixed(2);
                    var calc_ex = calc_IndVal2 * hdn_Invoice_Exrate;
                    var calc = calc_ex / RatePer;

                    calc = calc - ind_disc_amt;
                    var PMV_Amount = 0;
                    PMV_Amount = calc.toFixed(2);
                    //            PMV_Amount = roundToTwo(calc);

                    if (txtPMV_Rate != '') {
                        PMV_Amount = (parseFloat(PMV_Amount) * parseFloat(txtPMV_Rate) / 100).toFixed(2);
                    }
                    else {
                        PMV_Amount = (parseFloat(PMV_Amount) * 110 / 100).toFixed(2);
                    }

                    var PMV_Perunit = 0;
                    if (ddl_PMV_method == 'Rate') {
                        PMV_Perunit = (parseFloat(PMV_Amount) / parseFloat(txtItemQty)).toFixed(2);
                    }
                    else {
                        PMV_Perunit = txt_PMV_PerUnit;
                    }

                    document.getElementById("txt_PMV_PerUnit").value = PMV_Perunit;
                }

                /*

                if (txtItemQty != "" && txtItemQty != ".") {

                if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".") {
                Item_Amt = (parseFloat(txtItemQty) * parseFloat(txtItem_UnitPrice)).toFixed(5);
                }

                if (hdn_Invoice_Exrate != "") {
                PMV_Value = ((parseFloat(txtItemQty) * parseFloat(txtItem_UnitPrice) * (parseFloat(hdn_Invoice_Exrate) * 110)) / 100.00).toFixed(2);
                }
                }

                // PageMethods.Get_Item_UnitPrice(txtItem_UnitPrice, hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, lblInvoiceValue, txtItemQty, hdn_Invoice_Exrate, CallSuccess_ItemUnitprice, CallFailed, '1');
                */

                document.getElementById("txtItem_Amount").value = Item_Amt;
                document.getElementById("txtPMVValue").value = PMV_Amount;
                document.getElementById("hdn_PMVValue").value = PMV_Amount;
                document.getElementById("hdn_PMV_PER_UNIT").value = PMV_Perunit;

            });
            //-----------txtItem_Amount------------------------
            $('#txtItem_Amount').keyup(function () {

                var e;
                var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, txtItemQty, hdn_Invoice_Exrate, lblInvoiceValue, txtPer;
                hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
                txtItem_Amount = document.getElementById("txtItem_Amount").value;
                hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
                e = document.getElementById("ddlInv_SL_No");
                ddlInv_SL_No = e.options[e.selectedIndex].text;
                HiddenField1 = document.getElementById("HiddenField1").value;
                txtItemQty = document.getElementById("txtItemQty").value;

                txtPer = document.getElementById("txtPer").value;

                hdn_Invoice_Exrate = document.getElementById("hdn_Invoice_Exrate").value;
                lblInvoiceValue = document.getElementById("lblInvoiceValue").innerHTML;

                var txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;
                var txt_PMV_PerUnit = document.getElementById("txt_PMV_PerUnit").value;
                var ddl_PMV_method = document.getElementById("ddl_PMV_method").value;

                var txtPMV_Rate = document.getElementById("txtPMV_Rate").value;
                var Total_InvVal = $('#hdn_InvoiceValue').val();
                var DISC_Rate = $('#hdn_FOB_Disc_Rate').val();
                var DISC_Amt = $('#hdn_FOB_Disc_Charges').val();
                var RatePer = $('#txtPer').val();
                var companyID = $('#hdn_companyID').val();

                //-------------------- Exrate - Conversion ---------------------
                var Inv_Currency = $('#hdn_Invoice_Currency').val();
                if (Inv_Currency == 'JPY' || Inv_Currency == 'KRW') {
                    hdn_Invoice_Exrate = parseFloat(hdn_Invoice_Exrate) / 100;
                }
                //--------------------------------------------------------------

                DISC_Amt = DISC_Amt * hdn_Invoice_Exrate;
                Total_InvVal = Total_InvVal * hdn_Invoice_Exrate;

                var Amt = 0, PMV_Val = 0;


                if (txtItemQty != "" && txtItem_Amount != "" && txtItemQty != "." && txtItem_Amount != ".") {
                    //-----------------*****----------------------------------------------------------------------------
                    if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".") {

                        if (txtItemQty == '' || txtItemQty == '0') {
                            Amt = '0';
                        }
                        else {
                            Amt = txtItem_Amount / txtItemQty;
                        }


                        if (txtPer != "") {
                            Amt = (Amt * txtPer).toFixed(5);
                        }
                    }
                    //-----------------PMV_Val----------------------------------------------------------------------------
                    if (hdn_Invoice_Exrate != "") {

                        // this line hide by Chithra on 14-01-2020 for PMV Rate impelmentation
                        // PMV_Val = ((parseFloat(txtItemQty) * parseFloat(Amt) * (parseFloat(hdn_Invoice_Exrate) * 110)) / 100.00).toFixed(2);

                        var ind_inv = (txtItemQty * Amt * hdn_Invoice_Exrate) / RatePer; // individual Invoice value
                        var ind_disc_amt = (DISC_Amt * ind_inv) / Total_InvVal; // individual Disc amount for particular item.

                        var calc_IndVal = txtItemQty * Amt;   //(ItemQty * UnitPrice - Round off as same as Invoice value(2 digit))
                        var calc_IndVal2 = calc_IndVal.toFixed(2);
                        var calc_ex = calc_IndVal2 * hdn_Invoice_Exrate;
                        var calc = calc_ex / RatePer;

                        calc = calc - ind_disc_amt;
                        var PMV_Amount = 0;
                        PMV_Amount = calc.toFixed(2);
                        //            PMV_Amount = roundToTwo(calc);

                        if (txtPMV_Rate != '') {
                            PMV_Amount = (parseFloat(PMV_Amount) * parseFloat(txtPMV_Rate) / 100).toFixed(2);
                        }
                        else {
                            PMV_Amount = (parseFloat(PMV_Amount) * 110 / 100).toFixed(2);
                        }

                        var PMV_Perunit = 0;
                        if (ddl_PMV_method == 'Rate') {
                            PMV_Perunit = (parseFloat(PMV_Amount) / parseFloat(txtItemQty)).toFixed(2);
                        }
                        else {
                            PMV_Perunit = txt_PMV_PerUnit;
                        }

                    }

                } //-----------------*****----------------------------------------------------------------------------
                // PageMethods.Get_Item_amount_New(txtItem_UnitPrice, hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, lblInvoiceValue, txtItemQty, hdn_Invoice_Exrate, txtPer, Amt, PMV_Val, CallSuccess_Itemamount, CallFailed, '1');
                // PageMethods.Get_Item_amount_New(txtItem_UnitPrice, hdn_Item_Edit, txtItem_Amount, ddlInv_SL_No, HiddenField1, txtItemQty, Amt, PMV_Val, CallSuccess_Itemamount_new, CallFailed, '1');

                document.getElementById("txtItem_Amount").value = txtItem_Amount;
                document.getElementById("txtPMVValue").value = PMV_Amount;
                document.getElementById("txtItem_UnitPrice").value = Amt;

                document.getElementById("hdn_PMVValue").value = PMV_Amount;
                document.getElementById("txt_PMV_PerUnit").value = PMV_Perunit;
                document.getElementById("hdn_PMV_PER_UNIT").value = PMV_Perunit;
            });
            //-----------------------------------




            //-----------txtItem_Amount------------------------
            $('#txtPMV_Rate').keyup(function () {

                var e;
                var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, txtItemQty, hdn_Invoice_Exrate, lblInvoiceValue, txtPer;
                hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
                txtItem_Amount = document.getElementById("txtItem_Amount").value;
                hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
                e = document.getElementById("ddlInv_SL_No");
                ddlInv_SL_No = e.options[e.selectedIndex].text;
                HiddenField1 = document.getElementById("HiddenField1").value;
                txtItemQty = document.getElementById("txtItemQty").value;

                txtPer = document.getElementById("txtPer").value;

                hdn_Invoice_Exrate = document.getElementById("hdn_Invoice_Exrate").value;
                lblInvoiceValue = document.getElementById("lblInvoiceValue").innerHTML;

                var txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;
                var txt_PMV_PerUnit = document.getElementById("txt_PMV_PerUnit").value;
                var ddl_PMV_method = document.getElementById("ddl_PMV_method").value;

                var txtPMV_Rate = document.getElementById("txtPMV_Rate").value;
                var Total_InvVal = $('#hdn_InvoiceValue').val();
                var DISC_Rate = $('#hdn_FOB_Disc_Rate').val();
                var DISC_Amt = $('#hdn_FOB_Disc_Charges').val();
                var RatePer = $('#txtPer').val();
                var companyID = $('#hdn_companyID').val();

                //-------------------- Exrate - Conversion ---------------------
                var Inv_Currency = $('#hdn_Invoice_Currency').val();
                if (Inv_Currency == 'JPY' || Inv_Currency == 'KRW') {
                    hdn_Invoice_Exrate = parseFloat(hdn_Invoice_Exrate) / 100;
                }
                //--------------------------------------------------------------

                DISC_Amt = DISC_Amt * hdn_Invoice_Exrate;
                Total_InvVal = Total_InvVal * hdn_Invoice_Exrate;

                var Amt = 0, PMV_Val = 0;


                if (txtItemQty != "" && txtItem_Amount != "" && txtItemQty != "." && txtItem_Amount != ".") {
                    //-----------------*****----------------------------------------------------------------------------
                    if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".") {

                        if (txtItemQty == '' || txtItemQty == '0') {
                            Amt = '0';
                        }
                        else {
                            Amt = txtItem_Amount / txtItemQty;
                        }


                        if (txtPer != "") {
                            if (companyID == '1' || companyID == '10' || companyID == '2226') {//Rosemount - Checked with final print on 29-01-2024 sugg.by Bala sir
                                Amt = (Amt * txtPer).toFixed(2);
                            }
                            else {
                                Amt = (Amt * txtPer).toFixed(5);
                            }
                        }
                    }
                    //-----------------PMV_Val----------------------------------------------------------------------------
                    if (hdn_Invoice_Exrate != "") {

                        // this line hide by Chithra on 14-01-2020 for PMV Rate impelmentation
                        // PMV_Val = ((parseFloat(txtItemQty) * parseFloat(Amt) * (parseFloat(hdn_Invoice_Exrate) * 110)) / 100.00).toFixed(2);

                        var ind_inv = (txtItemQty * Amt * hdn_Invoice_Exrate) / RatePer; // individual Invoice value
                        var ind_disc_amt = (DISC_Amt * ind_inv) / Total_InvVal; // individual Disc amount for particular item.

                        var calc_IndVal = txtItemQty * Amt;   //(ItemQty * UnitPrice - Round off as same as Invoice value(2 digit))
                        var calc_IndVal2 = calc_IndVal.toFixed(2);
                        var calc_ex = calc_IndVal2 * hdn_Invoice_Exrate;
                        var calc = calc_ex / RatePer;

                        calc = calc - ind_disc_amt;
                        var PMV_Amount = 0;
                        PMV_Amount = calc.toFixed(2);
                        //            PMV_Amount = roundToTwo(calc);

                        if (txtPMV_Rate != '') {
                            PMV_Amount = (parseFloat(PMV_Amount) * parseFloat(txtPMV_Rate) / 100).toFixed(2);
                        }
                        else {
                            PMV_Amount = (parseFloat(PMV_Amount) * 110 / 100).toFixed(2);
                        }

                        var PMV_Perunit = 0;
                        if (ddl_PMV_method == 'Rate') {
                            PMV_Perunit = (parseFloat(PMV_Amount) / parseFloat(txtItemQty)).toFixed(2);
                        }
                        else {
                            PMV_Perunit = txt_PMV_PerUnit;
                        }
                    }

                } //-----------------*****----------------------------------------------------------------------------

                document.getElementById("txtPMVValue").value = PMV_Amount;
                document.getElementById("hdn_PMVValue").value = PMV_Amount;
                document.getElementById("txt_PMV_PerUnit").value = PMV_Perunit;
                document.getElementById("hdn_PMV_PER_UNIT").value = PMV_Perunit;
            });
            //-----------------------------------




            //-----------txt_PMV_PerUnit------------------------
            $('#txt_PMV_PerUnit').keyup(function () {

                var e;
                // call server side method
                var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, txtItemQty, hdn_Invoice_Exrate, lblInvoiceValue;
                hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
                txtItem_Amount = document.getElementById("txtItem_Amount").value;
                hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
                e = document.getElementById("ddlInv_SL_No");
                ddlInv_SL_No = e.options[e.selectedIndex].text;
                HiddenField1 = document.getElementById("HiddenField1").value;
                txtItemQty = document.getElementById("txtItemQty").value;
                hdn_Invoice_Exrate = document.getElementById("hdn_Invoice_Exrate").value;
                lblInvoiceValue = document.getElementById("lblInvoiceValue").innerHTML;
                var ddl_PMV_method = document.getElementById("ddl_PMV_method").value;

                var txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;

                var txtPMV_Rate = document.getElementById("txtPMV_Rate").value;
                var Total_InvVal = $('#hdn_InvoiceValue').val();
                var DISC_Rate = $('#hdn_FOB_Disc_Rate').val();
                var DISC_Amt = $('#hdn_FOB_Disc_Charges').val();
                var RatePer = $('#txtPer').val();

                var txt_PMV_PerUnit = document.getElementById("txt_PMV_PerUnit").value;

                //-------------------- Exrate - Conversion ---------------------
                var Inv_Currency = $('#hdn_Invoice_Currency').val();
                if (Inv_Currency == 'JPY' || Inv_Currency == 'KRW') {
                    hdn_Invoice_Exrate = parseFloat(hdn_Invoice_Exrate) / 100;
                }
                //--------------------------------------------------------------

                DISC_Amt = DISC_Amt * hdn_Invoice_Exrate;
                Total_InvVal = Total_InvVal * hdn_Invoice_Exrate;

                var Item_Amt = 0, PMV_Value = 0;

                //----------------New Val------05-----------------
                var regex = /(?:\d*\.\d{1,2}|\d+)$/;
                if (regex.test(txtItemQty)) {
                    if (parseFloat(txtItemQty) > 0) {
                        //Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                    }
                    else {
                        txtItemQty = '0';
                    }
                } else {
                    txtItemQty = '0';
                }

                //------------------------------------------
                if (regex.test(txt_PMV_PerUnit)) {
                    if (parseFloat(txt_PMV_PerUnit) > 0) {
                        //Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                    }
                    else {
                        txt_PMV_PerUnit = '0';
                    }
                } else {
                    txt_PMV_PerUnit = '0';
                }
                //------------------------------------------


                if (txt_PMV_PerUnit != "" && txt_PMV_PerUnit != ".") {
                    Item_Amt = (parseFloat(txtItemQty) * parseFloat(txt_PMV_PerUnit)).toFixed(5);
                }

                if (hdn_Invoice_Exrate != "") {

                    // this line hide by Chithra on 14-01-2020 for PMV Rate impelmentation
                    //   PMV_Value = ((parseFloat(txtItemQty) * parseFloat(txtItem_UnitPrice) * (parseFloat(hdn_Invoice_Exrate) * 110)) / 100.00).toFixed(2);

                    //--hide on 06-07-2020 sugg.by Mari-Agility & Bala sir.(Ex.Rate should not add)
                    // var ind_inv = (txtItemQty * txt_PMV_PerUnit * hdn_Invoice_Exrate) / RatePer; // individual Invoice value

                    var ind_inv = (txtItemQty * txt_PMV_PerUnit) / RatePer; // individual Invoice value

                    /*
                    var ind_disc_amt = (DISC_Amt * ind_inv) / Total_InvVal; // individual Disc amount for particular item.
              
                    var calc_IndVal = txtItemQty * txt_PMV_PerUnit;   //(ItemQty * UnitPrice - Round off as same as Invoice value(2 digit))
                    var calc_IndVal2 = calc_IndVal.toFixed(2);
                    var calc_ex = calc_IndVal2 * hdn_Invoice_Exrate;
                    var calc = calc_ex / RatePer;

                    calc = calc - ind_disc_amt;
                    */
                    var PMV_Amount = 0;
                    PMV_Amount = ind_inv.toFixed(2);

                    document.getElementById("txtPMVValue").value = PMV_Amount;
                    document.getElementById("hdn_PMVValue").value = PMV_Amount;
                    document.getElementById("hdn_PMV_PER_UNIT").value = txt_PMV_PerUnit;

                }

            });
            //-----------------------------------


            //-----------txt_PMV_PerUnit------------------------
            /*
            $('#txtPMVValue').keyup(function () {
      
            var txtItemQty = document.getElementById("txtItemQty").value;
            var txt_PMV_PerUnit = document.getElementById("txt_PMV_PerUnit").value;
            var ddl_PMV_method = document.getElementById("ddl_PMV_method").value;
            var txtPMV_Rate = document.getElementById("txtPMV_Rate").value;
            var txtPMVValue = document.getElementById("txtPMVValue").value;
            var RatePer = $('#txtPer').val();

            if (txtItemQty != "" && txtItem_Amount != "" && txtItemQty != "." && txtItem_Amount != ".") {

            var PMV_Perunit = 0;
            var PMV_Amount = 0;

            if (txt_PMV_PerUnit != "" && txt_PMV_PerUnit != "" && txt_PMV_PerUnit != "." && txt_PMV_PerUnit != ".") {
            if (ddl_PMV_method != 'Rate') {
            PMV_Perunit = (parseFloat(txtPMVValue) / parseFloat(txtItemQty) / RatePer).toFixed(2);
            }
            else {
            PMV_Perunit = txt_PMV_PerUnit;
            }

            document.getElementById("txt_PMV_PerUnit").value = PMV_Perunit;
            document.getElementById("hdn_PMV_PER_UNIT").value = PMV_Perunit;
            }
            }
           
            });
            */
            //-----------------------------------

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var ddl, Inv_no;
            ddl = document.getElementById("ddlInv_SL_No");
            Inv_no = ddl.options[ddl.selectedIndex].text;
            Load_Inv_Item_Val(Inv_no, '1');
        });
    </script>
    <script type="text/javascript">

        function Item_Qty(txtItemQty
                    , hdn_Item_Edit
                    , txtItem_Amount
                    , hdn_ITEM_AOUNT
                    , ddlInv_SL_No
                    , Item_Id
                    , txtItem_UnitPrice
                    , lblInvoiceValue
                    , hdn_Invoice_Exrate, dest) {

            PageMethods.Get_Item_Qty(txtItemQty, hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, Item_Id, txtItem_UnitPrice, lblInvoiceValue, hdn_Invoice_Exrate, CallSuccess_ItemQty, CallFailed, dest);

        }
        //-------------------------------------------------------------------
        function Load_Inv_Item_Val(Inv_no, dest) {
            PageMethods.Get_Inv_Item_Tot_Val(Inv_no, CallSuccess_Inv_Item_Tot, CallFailed, dest);
        }

        function CallSuccess_Inv_Item_Tot(res, destCtrl) {
            var data = res;
            if (data.indexOf("~~") != -1) {

                var s = data.split('~~');
                var before = s[0];
                var after1 = s[1];

                if (before != '') {
                    document.getElementById("hdn_Inv_Total").value = before;
                }
                if (after1 != '') {
                    document.getElementById("hdn_Item_Total").value = after1;
                }
            }
            else {

                document.getElementById("hdn_Inv_Total").value = '';
                document.getElementById("hdn_Item_Total").value = '';
            }
        }


        function CallSuccess_ItemQty(res, destCtrl) {
            HideImage('txtItemQty');
            var dest = document.getElementById(destCtrl);

            var data = res;
            if (data.indexOf("~~") != -1) {

                var s = data.split('~~');
                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];
                var after3 = s[3];

                if (after2 != '') {
                    document.getElementById("txtItem_Amount").value = before;
                    document.getElementById("txtItem_UnitPrice").value = after1;
                    document.getElementById("txtPMVValue").value = after3
                }
                else {

                }
                document.getElementById("txtItemQty").focus();
                if (after2 == '') {
                    document.getElementById("txtItem_Amount").value = '';
                    document.getElementById("txtItem_UnitPrice").value = '';
                    document.getElementById("txtItemQty").focus();
                    document.getElementById("txtPMVValue").value = '';
                }
            }
            else {

                document.getElementById("txtItem_Amount").value = '';
                document.getElementById("txtItem_UnitPrice").value = '';
                document.getElementById("txtPMVValue").value = '';
                document.getElementById("txtItemQty").focus();

            }
        }
        //--------------txtItem_UnitPrice-------------------
        /*
        function CallSuccess_ItemUnitprice(res, destCtrl) {
        HideImage('txtItem_UnitPrice');

        var dest = document.getElementById(destCtrl);
        
        var data = res;
        if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];

        document.getElementById("txtItem_Amount").value = after1;
        document.getElementById("txtPMVValue").value = after4;
        if (before == '') {

        }
        else if (after2 == '') {
        jQuery('#txtItemQty').validationEngine('showPrompt', 'Enter Qty', 'error', 'topRight', true);
        document.getElementById("txtItemQty").focus();
        }
        else if (after3 == '2') {
        var hdn_Grid_Count = document.getElementById("hdn_Grid_Count").value;

        if (hdn_Grid_Count != '') {
        jQuery('#txtItem_UnitPrice').validationEngine('showPrompt', 'Higher than invoice value', 'error', 'topRight', true);
        document.getElementById("txtItem_UnitPrice").focus();
        }
        }
        }
        }
        */
        //--------------txtItem_UnitPrice-----e--------------
        /*
        function CallSuccess_Itemamount(res, destCtrl) {
        HideImage('txtItem_Amount');
        var dest = document.getElementById(destCtrl);
        var data = res;
        if (data.indexOf("~~") != -1) {

        var s = data.split('~~');
        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];

        document.getElementById("txtItem_Amount").value = after1;
        document.getElementById("txtPMVValue").value = after4;
        document.getElementById("txtItem_UnitPrice").value = before;
        if (before == '') {
        }
        else if (after2 == '') {
        jQuery('#txtItemQty').validationEngine('showPrompt', 'Enter Qty', 'error', 'topRight', true);
        document.getElementById("txtItemQty").focus();
        }
        else if (after3 == '2') {
        var hdn_Grid_Count = document.getElementById("hdn_Grid_Count").value;

        if (hdn_Grid_Count != '') {
        jQuery('#txtItem_UnitPrice').validationEngine('showPrompt', 'Higher than invoice value', 'error', 'topRight', true);
        }
        }
        }
        }
        */

        /*
        function CallSuccess_Itemamount_new(res, destCtrl) {
         
        var dest = document.getElementById(destCtrl);
        var data = res;

        if (data.indexOf("~~") != -1) {

        var s = data.split('~~');
        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];

        document.getElementById("txtItem_Amount").value = after1;
        document.getElementById("txtPMVValue").value = after4;
        document.getElementById("txtItem_UnitPrice").value = before;

              
        if (before == '') {
        }
        else if (after2 == '') {
        jQuery('#txtItemQty').validationEngine('showPrompt', 'Enter Qty', 'error', 'topRight', true);
        document.getElementById("txtItemQty").focus();
        }
        else if (after3 == '2') 
        {
        var hdn_Grid_Count = document.getElementById("hdn_Grid_Count").value;
        if (hdn_Grid_Count != '') {
        jQuery('#txtItem_UnitPrice').validationEngine('showPrompt', 'Higher than invoice value', 'error', 'topRight', true);
        }
        }
            
        }
        }
        */
        //--------------txtItem_Amount-----e--------------
        function CallFailed(res, destCtrl) {
        }
    </script>
    <%--<script type="text/javascript">
        $(document).ready(function () {

            // document.onkeydown = clickRadio;
            document.onkeypress = click_TABS;
            document.onkeyup = click_TABS;

            function click_TABS(e) {
                //if (window.event);
                if (window.event.ctrlKey)
                    var keyCode = window.event.keyCode;       // IE

                else
                    var keyCode = e.which;

                if (e.ctrlKey) {
                    if (keyCode == 39) {

                        document.getElementById("hdn_source").value = 'Tab_Item';
                        document.getElementById('btnCancel').click();
                    }
                    if (keyCode == 37) {

                        document.getElementById("hdn_source").value = 'Tab_Item_Prev';
                        document.getElementById('btnCancel').click();
                    }
                }
            }
        });
    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            // document.onkeydown = clickRadio;
            document.onkeypress = click_TABS;
            document.onkeyup = click_TABS;

            function click_TABS(e) {
                //if (window.event);
                if (window.event.ctrlKey)
                    var keyCode = window.event.keyCode;       // IE

                else
                    var keyCode = e.which;
                var cnt = 0;
                // alert(keyCode);
                //                  alert(e.ctrlKey);
                if (e.ctrlKey) {
                    if (keyCode == 39) {
                        //document.getElementById("hdn_source").value = 'Tab_Item';
                        //document.getElementById('btnCancel').click();

                        if (document.getElementById("hdn_Inner_tab_Menu").value == '') {
                            document.getElementById("hdn_Inner_tab_Menu").value = 'ITEM_ID';
                            cnt = cnt + 1;
                        }
                        else {
                            cnt = cnt + 1;
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'ITEM_ID') {
                            if (cnt == 1) {
                                document.getElementById('OTHER_DETAILS_ID').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'OTHER_DETAILS_ID') {
                            if (cnt == 1) {
                                document.getElementById('SW_Manufacture').click();
                                cnt = cnt + 1;
                            }
                        }
                    }

                    if (keyCode == 37) {

                        cnt = cnt + 1;

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'ITEM_ID') {
                            if (cnt == 1) {
                                document.getElementById("hdn_source").value = 'Tab_Item_Prev';
                                document.getElementById('btnCancel').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'SW_Manufacture') {
                            if (cnt == 1) {
                                document.getElementById('OTHER_DETAILS_ID').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'OTHER_DETAILS_ID') {

                            if (cnt == 1) {
                                document.getElementById('ITEM_ID').click();
                                document.getElementById("hdn_Inner_tab_Menu").value = 'ITEM_ID';
                                cnt = cnt + 1;
                            }
                        }
                    }
                }
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            var ddl_pmvmethod = document.getElementById("ddl_PMV_method").value;

            if (ddl_pmvmethod == 'Rate') {
                $('#txtPMVValue').attr('disabled', true);
                $('#txtPMV_Rate').attr('disabled', false);
                $('#txt_PMV_PerUnit').attr('disabled', true);
                $('#txt_PMV_PerUnit').val('');

                if ($('#txtPMV_Rate').val() == '') {
                    $('#txtPMV_Rate').attr('placeholder', '110');
                }
            }
            if (ddl_pmvmethod == 'Amt') {
                $('#txtPMV_Rate').attr('disabled', true);
                $('#txtPMVValue').attr('disabled', false);
                $('#txt_PMV_PerUnit').attr('disabled', true);
                $('#txtPMV_Rate').val('');
                $('#txtPMV_Rate').attr('placeholder', '');
            }
            if (ddl_pmvmethod == 'Unit' || ddl_pmvmethod == 'PerUnit') {
                $('#txtPMV_Rate').attr('disabled', true);
                $('#txtPMVValue').attr('disabled', true);
                $('#txt_PMV_PerUnit').attr('disabled', false);
                $('#txtPMV_Rate').val('');
                $('#txtPMV_Rate').attr('placeholder', '');
            }

            $('#ddl_PMV_method').change(function () {
                var ddl_pmvmethod = document.getElementById("ddl_PMV_method").value;
                if (ddl_pmvmethod == 'Rate') {
                    $('#txtPMVValue').attr('disabled', true);
                    $('#txtPMV_Rate').attr('disabled', false);
                    $('#txt_PMV_PerUnit').attr('disabled', true);
                    $('#txtPMV_Rate').focus();
                    $('#txt_PMV_PerUnit').val('');
                    if ($('#txtPMV_Rate').val() == '') {
                        $('#txtPMV_Rate').attr('placeholder', '110');
                    }
                }
                if (ddl_pmvmethod == 'Amt') {
                    $('#txtPMV_Rate').attr('disabled', true);
                    $('#txtPMVValue').attr('disabled', false);
                    $('#txt_PMV_PerUnit').attr('disabled', true);
                    $('#txtPMVValue').focus();
                    $('#txtPMV_Rate').val('');
                    $('#txt_PMV_PerUnit').val('');
                    $('#txtPMV_Rate').attr('placeholder', '');
                }
                if (ddl_pmvmethod == 'Unit' || ddl_pmvmethod == 'PerUnit') {
                    $('#txtPMV_Rate').attr('disabled', true);
                    $('#txtPMVValue').attr('disabled', true);
                    $('#txt_PMV_PerUnit').attr('disabled', false);
                    $('#txt_PMV_PerUnit').focus();
                    $('#txtPMV_Rate').val('');
                    $('#txtPMVValue').val('');
                    $('#txt_PMV_PerUnit').val('');
                    $('#txtPMV_Rate').attr('placeholder', '');
                }
            });
        });
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

                if (scheme1 == "60-DRAWBACK AND ROSL" || scheme1 == "60-DRAWBACK AND ROSCTL" || scheme1 == "61-EPCG, DRAWBACK AND ROSL" || scheme1 == "61-EPCG, DRAWBACK AND ROSCTL" || scheme1 == "62-DRAWBACK AND SPL AA" || scheme1 == "63-EPCG,DRAWBACK AND SPL AA" || scheme1 == "64-DRAWBACK, SPL AA ( 4.04A) AND ROSCTL" || scheme1 == "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSCTL") {
                    $('#ddl_Rodtep_YN').val('NA');
                }
                else if (document.getElementById("hdn_EXPORT_SBTYPE").value == "SEZ" && scheme1 == "03-ADVANCE LICENSE") {
                    $('#ddl_Rodtep_YN').val('N');
                }
                else {
                }
            });
        });
        $('#txtItemQty, #txtQtyCode, #txt_InfoUQC').bind('keyup change focus', function () {
            var _itemQty = document.getElementById('txtItemQty').value;
            var _qtyCode = document.getElementById('txtQtyCode').value;
            var _infoUqc = document.getElementById('txt_InfoUQC').value;

            if (_itemQty == null || _itemQty == '' || _itemQty == undefined) {
                document.getElementById('txt_InfoMSR').value = '';
                return false;
            }

            if (_qtyCode == 'KGS' && _infoUqc == 'MTS') {
                var result = _itemQty / 1000;
                document.getElementById('txt_InfoMSR').value = result;
                return false;
            }

            if (_qtyCode == 'MTS' && _infoUqc == 'KGS') {
                var result = _itemQty * 1000;
                document.getElementById('txt_InfoMSR').value = result;
                return false;
            }
        })
    </script>
     <script type="text/javascript">         // Added by pandiyan for Rodtep process on 21-05-2026
         function openRODTEPInfo() {

             /* Gather values from current item form */
             var qty = document.getElementById('txt_InfoMSR').value;
             var unit = document.getElementById('txt_InfoUQC').value;
             var ritc = document.getElementById('txtRITCNo').value;
             var schem = document.getElementById('ddlSchemeCode').value;
             var desc = document.getElementById('<%=txtDescription.ClientID%>').value;
             var code = schem.split('-')[0];
             /* Hidden field values */
             var jobno = document.getElementById('<%=hdn_JOBNO.ClientID%>').value;
             var invSlno = document.getElementById('hdinvslno').value;
             var itemSlno = document.getElementById('<%=ddl_ItemSlno.ClientID%>').value;
             var itemId = document.getElementById('<%=hditem_id.ClientID%>').value;

             /* Build iframe URL */
             var url = '../Export/Export_RODTEP_Info.aspx'
                + '?JobNo=' + encodeURIComponent(jobno)
                + '&InvSlno=' + encodeURIComponent(invSlno)
                + '&ItemSlno=' + encodeURIComponent(itemSlno)
                + '&ItemID=' + encodeURIComponent(itemId)
                + '&ritc=' + encodeURIComponent(ritc)
                + '&code=' + encodeURIComponent(code)
                + '&Qty=' + encodeURIComponent(qty)
                + '&Unit=' + encodeURIComponent(unit)
                + '&t=' + new Date().getTime();

             document.getElementById('iframe_RODTEP_Info').src = url;
             document.getElementById('div_RODTEP_Overlay').style.display = 'block';
         }

         function onRODTEPSaved(claim, amount) {
             var rodtepDdl = document.getElementById('<%=ddl_Rodtep_YN.ClientID%>');
             if (rodtepDdl) {
                 rodtepDdl.value = (claim === 'Y') ? 'Y' : 'N';
             }
             closeRODTEPPopup();
         }

         function closeRODTEPPopup() {
             document.getElementById('div_RODTEP_Overlay').style.display = 'none';
             document.getElementById('iframe_RODTEP_Info').src = '';
         }

         window.addEventListener('load', function () {
             var overlay = document.getElementById('div_RODTEP_Overlay');
             if (overlay) {
                 overlay.addEventListener('click', function (e) {
                     if (e.target === this) { closeRODTEPPopup(); }
                 });
             }


             var rodDdl = document.getElementById('<%=ddl_Rodtep_YN.ClientID%>');
             if (rodDdl) {
                 checkRODTEP(rodDdl.value);

                 rodDdl.addEventListener('change', function () {
                     checkRODTEP(this.value);
                 });
             }
         });


</script>
<script type="text/javascript">    // Added by pandiyan for Rodtep process on 21-05-2026
    function checkRODTEP(val) {
        var btn = document.getElementById('btnRODTEP_Info');
        if (!btn) return;
        btn.disabled = (val !== 'Y');
        btn.style.opacity = (val === 'Y') ? '1' : '0.4';
        btn.style.cursor = (val === 'Y') ? 'pointer' : 'not-allowed';
    }
</script>
</body>
</html>
