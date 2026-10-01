<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice_Details_HP_Invoice.aspx.cs"
    Inherits="Transaction_Invoice_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>IGM | Transaction</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        
        .hideGridColumn1
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        
         .grid-view tr.header
            {
                border: solid 1px Black;
                
            }            
    </style>

    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
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
                     document.getElementById("hdn_source").value = 'Tab_Invoice';
                     document.getElementById('btnCancel').click();
                 }

                 if (keyCode == 37) {
                     document.getElementById("hdn_source").value = 'Tab_Invoice_Prev';
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

                //alert(e.ctrlKey);
                if (e.ctrlKey) {
                    if (keyCode == 39) {
                        //document.getElementById("hdn_source").value = 'Tab_Invoice';

                        if (document.getElementById("hdn_Inner_tab_Menu").value == '') {
                            document.getElementById("hdn_Inner_tab_Menu").value = 'IMD';
                            cnt = cnt + 1;
                        }
                        else {
                            cnt = cnt + 1;
                        }

                        //alert(cnt + 'CNT');
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'IMD') {
                            if (cnt == 1) {
                                document.getElementById('MD').click();
                                cnt = cnt + 1;
                            }
                        }
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'MD') {
                            if (cnt == 1) {
                                document.getElementById('OC').click();
                                cnt = cnt + 1;
                            }
                        }
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'OC') {
                            if (cnt == 1) {
                                document.getElementById('SD').click();
                                cnt = cnt + 1;
                            }
                        }
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'SD') {
                            if (cnt == 1) {
                                document.getElementById('SVBD').click();
                                cnt = cnt + 1;
                            }
                        }
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'SVBD') {
                            if (cnt == 1) {
                                document.getElementById('OD').click();
                                cnt = cnt + 1;
                            }
                        }
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'OD') {
                            if (cnt == 1) {
                                document.getElementById('SWD').click();
                                cnt = cnt + 1;
                            }
                        }
                    }

                    if (keyCode == 37) {

                        cnt = cnt + 1;

                        if (document.getElementById("hdn_Inner_tab_Menu").value == '') {
                            document.getElementById("hdn_Inner_tab_Menu").value = 'IMD';
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'IMD') {
                            if (cnt == 1) {
                                document.getElementById("hdn_source").value = 'Tab_Invoice_Prev';
                                document.getElementById('btnCancel').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'SWD') {
                            if (cnt == 1) {
                                document.getElementById('OD').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'OD') {
                            if (cnt == 1) {
                                document.getElementById('SVBD').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'SVBD') {
                            if (cnt == 1) {
                                document.getElementById('SD').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'SD') {
                            if (cnt == 1) {
                                document.getElementById('OC').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'OC') {
                            if (cnt == 1) {
                                document.getElementById('MD').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'MD') {
                            if (cnt == 1) {
                                document.getElementById('IMD').click();
                                cnt = cnt + 1;
                            }
                        }
                    }
                }
            }
        });
    </script>


   <%-- <script type="text/javascript">

        $(document).ready(function () {
            alert('a');
            $('#chk_Supp_manuf').change(function () {
                if ($(this).prop('checked')) {
                    alert("You have elected to show your checkout history."); //checked
                }
                else {
                    alert("You have elected to turn off checkout history."); //not checked
                }
            });
        });
    </script>--%>

    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
   
</head>


<script type = "text/javascript">

    function MutExChkList(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
            else {
                chks[1].checked = true;
            }
        }
        var selectedValues = [];
        $("[id*=CHKF] input:checked").each(function () {
            selectedValues.push($(this).val());
        });

        var txtFreight_Rate = $('#txtFreight_Rate');
        var txtFreight_Charges = $('#txtFreight_Charges');


        if (selectedValues == 'Amt') {

            txtFreight_Rate.attr('disabled', true);
            txtFreight_Charges.attr('disabled', false);

            txtFreight_Rate.val('');

        }
        else if (selectedValues == 'Rate') {

            txtFreight_Rate.attr('disabled', false);
            txtFreight_Charges.attr('disabled', true);

            txtFreight_Charges.val('');
        }

        var txtInsurance_Charges = $('#txtInsurance_Charges');
        var txtInsurance_Rate = $('#txtInsurance_Rate');

        var selectedValues_I = [];
        $("[id*=CHKI] input:checked").each(function () {

            selectedValues_I.push($(this).val());

        });

        if (selectedValues_I == 'Amt') {

            txtInsurance_Rate.attr('disabled', true);
            txtInsurance_Charges.attr('disabled', false);
            txtInsurance_Rate.val('');

        }
        else if (selectedValues_I == 'Rate') {

            txtInsurance_Rate.attr('disabled', false);
            txtInsurance_Charges.attr('disabled', true);

            txtInsurance_Charges.val('');
        }
    }

    function chkMI(chk) {

        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");

        var txtMiscellaneous_Rate = $('#txtMiscellaneous_Rate');
        var txtMiscellaneous_Charges = $('#txtMiscellaneous_Charges');
        var txtHighSeaSale_Rate = $('#txtHighSeaSale_Rate');
        var txtHighSeaSale_Charges = $('#txtHighSeaSale_Charges');

        var txtMisc_Total_Charge = $('#txtMisc_Total_Charge');
        var txtHss_Total_Charge = $('#txtHss_Total_Charge');


        if (chk.checked) {

            document.getElementById("DivFreight").style.display = 'Block';
            document.getElementById("DivInsurance").style.display = 'Block';
            document.getElementById("DivMISC").style.display = 'Block';
            document.getElementById("DivHSS").style.display = 'Block';

            //---------------------------MISC----------------------------------------------------------
            var selectedItems_MISC = "";
            $("[id*=Chk_Misc] input:checked").each(function () {

                selectedItems_MISC += $(this).next().html() + "\r\n";
            });
            if (selectedItems_MISC != "") {
                document.getElementById("Div_MISC_txt").style.display = 'Block';
                txtMiscellaneous_Rate.attr('disabled', true);
                txtMiscellaneous_Charges.attr('disabled', true);

                txtMiscellaneous_Rate.val('0.00');
                txtMiscellaneous_Charges.val('');
            }
            else {
                document.getElementById("Div_MISC_txt").style.display = 'none';
                txtMiscellaneous_Rate.attr('disabled', true);
                txtMiscellaneous_Charges.attr('disabled', false);

                txtMisc_Total_Charge.val('');
            }
            //------------------------------------------------------------------------------------------
            //---------------------------HSS----------------------------------------------------------
            var selectedItems_Hss = "";
            $("[id*=CHKHSS] input:checked").each(function () {
                selectedItems_Hss += $(this).next().html() + "\r\n";
            });


            if (selectedItems_Hss != "") {
                document.getElementById("Div_Hss_txt").style.display = 'Block';

                txtHighSeaSale_Rate.attr('disabled', true);
                txtHighSeaSale_Charges.attr('disabled', true);

                txtHighSeaSale_Rate.val('0.00');
                txtHighSeaSale_Charges.val('');

            }
            else {
                document.getElementById("Div_Hss_txt").style.display = 'none';
                txtHighSeaSale_Rate.attr('disabled', false);
                txtHighSeaSale_Charges.attr('disabled', false);
                txtHss_Total_Charge.val('');
            }
            //------------------------------------------------------------------------------------------

            document.getElementById("Div_Total_Charge_lable").style.display = 'Block';
        }
        else {
            
            document.getElementById("DivFreight").style.display = 'none';
            document.getElementById("DivInsurance").style.display = 'none';

            document.getElementById("DivMISC").style.display = 'none';
            document.getElementById("DivHSS").style.display = 'none';

            document.getElementById("Div_MISC_txt").style.display = 'none';
            document.getElementById("Div_Hss_txt").style.display = 'none';

            document.getElementById("Div_Total_Charge_lable").style.display = 'none';

            txtMiscellaneous_Rate.attr('disabled', true);
            txtMiscellaneous_Charges.attr('disabled', false);
            txtMisc_Total_Charge.val('');

            txtHighSeaSale_Rate.attr('disabled', false);
            txtHighSeaSale_Charges.attr('disabled', false);
            txtHss_Total_Charge.val('');
        }
    }

    function Chk_Misc(chk) {
        
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");

        var txtMiscellaneous_Rate = $('#txtMiscellaneous_Rate');
        var txtMiscellaneous_Charges = $('#txtMiscellaneous_Charges');
        var txtMisc_Total_Charge = $('#txtMisc_Total_Charge');
        

        if (chk.checked) {
            document.getElementById("Div_MISC_txt").style.display = 'Block';

            txtMiscellaneous_Rate.attr('disabled', true);
            txtMiscellaneous_Charges.attr('disabled', true);

            txtMiscellaneous_Rate.val('0.00');
            txtMiscellaneous_Charges.val('');
        }
        else {
            document.getElementById("Div_MISC_txt").style.display = 'none';

            txtMiscellaneous_Rate.attr('disabled', false);
            txtMiscellaneous_Charges.attr('disabled', false);

            txtMisc_Total_Charge.val('');
        }
    }

    function Chk_Hss(chk) {

        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");

        var txtHighSeaSale_Rate = $('#txtHighSeaSale_Rate');
        var txtHighSeaSale_Charges = $('#txtHighSeaSale_Charges');

        var txtHss_Total_Charge = $('#txtHss_Total_Charge');

        if (chk.checked) {
            document.getElementById("Div_Hss_txt").style.display = 'Block';

            txtHighSeaSale_Rate.attr('disabled', true);
            txtHighSeaSale_Charges.attr('disabled', true);

            txtHighSeaSale_Rate.val('0.00');
            txtHighSeaSale_Charges.val('');
        }
        else {
            document.getElementById("Div_Hss_txt").style.display = 'none';

            txtHighSeaSale_Rate.attr('disabled', false);
            txtHighSeaSale_Charges.attr('disabled', false);

            txtHss_Total_Charge.val('');
        }
    }

</script>


<script type="text/javascript">
    $(document).ready(function () {
        $('#btnUpdate,#btnSave').click(function () {
            var supplier = document.getElementById("txtSupplierName").value;
            if (supplier == '') {

                document.getElementById("IMD").className = 'inactive';
                document.getElementById("SD").className = 'active';

                document.getElementById("page-1").style.display = 'none';
                document.getElementById("page-2").style.display = 'Block';
                $("#txtSupplierName").focus();
            }

          
        });
    });
</script>


<script type="text/javascript">
    $(document).ready(function () {

        $('#txtSupplierName').focus(function () {

            var data = $(this).val();
            Sup_name(data);

        });
        $('#txtSupplierName').change(function () {

            var data = $(this).val();
            Sup_name(data);

        });
        $('#txtSupplierName').keyup(function () {

            var data = $(this).val();
            Sup_name(data);

        });
        $('#txtSupplierName').keydown(function () {

            var data = $(this).val();
            Sup_name(data);
        });
        //---------------------------------------

        $('#txtSupplier_Branch_Slno').focus(function () {

            var data = $("#txtSupplierName").val();
            Sup_name(data);

        });
        $('#txtSupplier_Branch_Slno').change(function () {

            var data = $("#txtSupplierName").val();
            Sup_name(data);

        });
        $('#txtSupplier_Branch_Slno').keyup(function () {

            var data = $("#txtSupplierName").val();
            Sup_name(data);

        });
        $('#txtSupplier_Branch_Slno').keydown(function () {

            var data = $("#txtSupplierName").val();
            Sup_name(data);
        });
        //---------------------------------------

    });

    function Sup_name(val) {
        
        var data = val;
        if (data == '') {
            $('#txtSupplierName').val('');
            $('#hdn_Supplier_br_slno').val('');
        }
        if (data.indexOf("--") != -1) {
            var s = data.split('--');
            var before = s[0];
            var after = s[1];

            $('#txtSupplierName').val(after);
            $('#hdn_Supplier_br_slno').val(before);
        }
        else {
            if (data == 'ROCHESTER--WESTERN DIGITAL') {
                $('#hdn_Supplier_br_slno').val('');
                alert(val);
            }
        }
    }

    function Sup_name_txt() {

        var data = document.getElementById("txtSupplierName").value; ;

        if (data == '') {
            $('#txtSupplierName').val('');
            $('#hdn_Supplier_br_slno').val('');
        }
        if (data.indexOf("--") != -1) {
            var s = data.split('--');
            var before = s[0];
            var after = s[1];

            $('#txtSupplierName').val(after);
            $('#hdn_Supplier_br_slno').val(before);
        }
        else {
            $('#hdn_Supplier_br_slno').val('');
        }
    }


  </script>

<script type="text/javascript">
    function CI_Handling_Alert_Msg() {
        document.getElementById("IMD").className = 'inactive';
        document.getElementById("OC").className = 'active';

        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-7").style.display = 'Block';

       
        if (document.getElementById("txt_UnLoading_Charges").value == '') {
            $("#txt_UnLoading_Charges").focus();
        }
        if (document.getElementById("txt_Loading_Charges").value == '') {
            $("#txt_Loading_Charges").focus()
        }
        if (document.getElementById("txt_Handling_Charges").value == '') {
            $("#txt_Handling_Charges").focus();
        }
      
        alert('"CI" Terms - Other Charges Mandatory..');

    }


    function CI_Check_notbe_ZERO_Alert_Msg() {
        document.getElementById("IMD").className = 'inactive';
        document.getElementById("OC").className = 'active';

        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-7").style.display = 'Block';

        var handling = parseFloat(document.getElementById("txt_Handling_Charges").value);
        var Loading = parseFloat(document.getElementById("txt_Loading_Charges").value);
        var UnLoading = parseFloat(document.getElementById("txt_UnLoading_Charges").value);

        if (UnLoading ==  0) {
            $("#txt_UnLoading_Charges").focus();
        }
        if (Loading == 0) {
            $("#txt_Loading_Charges").focus();
        }
        if (handling == 0) {
            $("#txt_Handling_Charges").focus();
        }

        alert('"CI" Terms - Charges should be more than "0"..');

    }
</script>

<script type="text/javascript">
    function svb_update_Msg() {       
        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'none';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'Block';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';

        document.getElementById("IMD").className = 'inactive';
        document.getElementById("SVBD").className = 'active';

    }
</script>

<script type="text/javascript">

    $(document).ready(function () {
//        $('#txt_Handling_Charges').keyup(function () {
                    $('#txt_Handling_Charges,#txt_Loading_Charges,#txt_UnLoading_Charges').keyup(function () {
            var a_val = $('#txt_Handling_Charges').val();
            var b_val = $('#txt_Loading_Charges').val();
            var c_val = $('#txt_UnLoading_Charges').val();

            if (a_val == '') {
                a_val = '0.00';
            }
            if (b_val == '') {
                b_val = '0.00';
            }
            if (c_val == '') {
                c_val = '0.00';
            }
            var final = 0.00;
            final = Number(a_val) + Number(b_val) + Number(c_val);

            $('#txt_Total_Amount').val(final);
            $('#hdn_Total_Other_Charges').val(final);
        });
    });

</script>


<body bgcolor="#FFFFFF">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Trans_IGM_Invoice">
                <ol id="toc">
                    <%-- <a href="#" onclick="alert('is the form valid? '+jQuery('#formID1').validationEngine('validate'))">Evaluate form</a>--%>
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');" id="IMD">
                        <span>Main Details</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2('0');" id="MD">
                        <span>Freight & Misc</span></a></li>
                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');tab_page7('0');" id="OC">
                        <span>Other Charges</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3('0');" id="SD">
                        <span>Supplier Details</span></a></li>
                    <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4('0');" id="SVBD">
                        <span>SVB Details</span></a></li>
                    <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('0');" id="OD">
                        <span>Other Details</span></a></li>
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');tab_page6('0');" id="SWD">
                        <span>Third Party</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice" style="margin-top:-20px;">

                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1_chkbox_frame" style="width:750px">
                        <div id="tag_label_transaction_popup_gen" runat="server" style="width:180px">
                        Exbond Inv.Slno

                         <asp:TextBox ID="txt_InvoiceSlno" runat="server" CssClass="validate[required,custom[number] txtbox_none_Mid_transac_Supp_Name" Width="50px" TabIndex="1"></asp:TextBox> 
                        </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1_chkbox">
                                Single Freight & Insurance charge for all Invoice
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                                <asp:CheckBox ID="chkMisc" runat="server" TabIndex="25"  onclick = "chkMI(this);"/></div>


                                
                           <%-- <div id="tag_label_transaction_popup_IGM_invoice" style="width:170px;">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="color: #cc0000;font-weight:bold;">
                                Rate
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice"  style="color: #cc0000;font-weight:bold;">
                              Charge 
                            </div>--%>

                            <div id="tag_label_transaction_popup_IGM2_empty" style="width:100px">
                            </div>
                            <div id="editbu">
                           
                           <%-- <asp:Button ID="btn_Update_Exrate_All" runat="server" CausesValidation="false" UseSubmitBehavior="false" 
                        CssClass="autowidmovebut" Text="Ex.Rate Update All" Width="150px" 
                        OnClientClick="jQuery('#form1').validationEngine('hide');open_Bulk_Exrate_Update_Inv(); return false;" />--%>
                       
                        <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Ex.Rate Update- All Invoices"  ImageUrl="~/images/icons/index.jpg" runat="server" 
                        OnClientClick="jQuery('#form1').validationEngine('hide');open_Bulk_Exrate_Update_Inv(); return false;"  />
                        
                       </div>

                        </div>



                        <div id="tag_transac_lft_Inv_in1" style="width:710px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                 Invoice No
                            </div>
                            <div id="txtcon-m_transaction_Inv_No">
                                <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="16" 
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date" >
                                Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="2" onblur="validateDate()" ></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            
                            </div>

                            <%--------------------------------------------------------------------%>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width:50px;">
                            </div>

                            <div id="DivFreight" runat="server" style="display:none;">
                            
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width:62px;color: #cc0000;font-weight:bold;">
                                     Freight
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice"  style="width:158px;">

                                        <asp:CheckBoxList ID="CHKF" runat="server" RepeatDirection="Horizontal" CellPadding="3" CellSpacing="2">
                                         <asp:ListItem Text="(%) &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="Rate" onclick = "MutExChkList(this);"></asp:ListItem>
                                         <asp:ListItem Text="Amt" Value="Amt"  Selected="True" onclick = "MutExChkList(this);"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                           
                           </div>

                            <%--<div id="tag_label_transaction_popup_IGM2_empty">
                            </div>--%>

                              <%--------------------------------------------------------------------%>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width:710px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Terms</div>
                            <div id="txtcon-m_transaction_list1_fcl">
                                <asp:DropDownList ID="ddlTerms" CssClass="validate[required] listtxt_transac_FCL"
                                    runat="server" TabIndex="3">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_trans_Inv_empty">
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date">
                                Currency
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInvoiceCurrency" runat="server" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" TabIndex="4" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                    onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('InvoiceCurrency'); return false"
                                    class="magnfy"></a>
                            </div>
                            <%---------------------------------------------------------------------------------------------------------------------------%>
                              <div id="tag_label_transaction_popup_IGM2_empty" style="width:20px;">
                            </div>
                             <div id="DivInsurance" runat="server" style="display:none;">
                            
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width:60px;color: #cc0000;font-weight:bold;">
                                     Insurance
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice"  style="width:130px;">

                                        <asp:CheckBoxList ID="CHKI" runat="server" RepeatDirection="Horizontal" >
                                         <asp:ListItem Text="(%) &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"  onclick = "MutExChkList(this);" Value="Rate" ></asp:ListItem>
                                         <asp:ListItem Text="Amt" onclick = "MutExChkList(this);"  Selected="True" Value="Amt"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                             </div>
                             <div id="magnify_area"></div>
                             <%---------------------------------------------------------------------------------------------------------------------------%>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width:710px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Invoice Value
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInvoiceValue" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="17" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoic_empty_main_details">
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date">
                                Ex. Rate
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtExRate" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="6" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="magnify_area"></div>
                           <%-------------------------------------------------------------------------------------------------------------------------%>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width:20px;">
                            </div>
                             <div id="DivMISC" runat="server" style="display:none;">
                            
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width:60px;color: #cc0000;font-weight:bold;">
                                     MISC
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice"  style="width:130px;">
                                    <div id="magnify_area" style="width:65px;"></div>
                                        <asp:CheckBoxList ID="Chk_Misc" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Amt" Value="Amt"   onclick = "Chk_Misc(this);"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                             </div>
                             <%-- -----------------------------------------------------------------------------------------------------------------------%>

                        </div>


                        <div id="tag_transac_lft_Inv_in1" style="width: 710px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                <%--Invoice Value--%>
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <%--<asp:TextBox ID="txttest" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="17" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>--%>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoic_empty_main_details">
                            </div>
                            <div id="div_AmendmentType"  Visible="false" runat="server"  style="margin-top:5px">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 80px;
                                font-weight: bold;">
                                Amend Type
                            </div>
                            <div id="txtcon-m_transaction_code_BE_TYPE" style="width: 100px;">
                                <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                    Width="100px">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="A">AMENDMENT</asp:ListItem>
                                    <asp:ListItem Value="S">SUPPLEMENT</asp:ListItem>
                                    <asp:ListItem Value="D">DELETE</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             <div id="editbu" style="margin-top:-5px;">
                                            <asp:Button ID="btn_Amend_FF" Text="Flatfile" CssClass="autowidmovebut" runat="server"
                                                OnClientClick="Open_Amend_Flatfile(); return false" Width="60px" />
                                        </div>
                            </div>
                            <%--<div id="tag_label_transaction_popup_Invoice_Date">
                                Ex. Rate
                            </div>
                            <div id="txtcon-m_transaction_code">
                               <asp:TextBox ID="texttest2" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="6"></asp:TextBox>
                            </div>--%>
                            <div id="magnify_area" style="width: 22px;">
                            </div>
                            <%-- --------------------------------------------------------------%>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px;">
                            </div>
                            <div id="DivHSS" runat="server" style="display: none;">
                                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 60px; color: #cc0000;
                                    font-weight: bold;">
                                    HSS
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 130px;">
                                    <div id="magnify_area" style="width: 65px;">
                                    </div>
                                    <asp:CheckBoxList ID="CHKHSS" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="  Amt" onclick="Chk_Hss(this);" Value="Amt"></asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <%-- --------------------------------------------------------------%>
                        </div>

                       <%-- ShowFooter="false" --%>
                        <div id="as" style="overflow:hidden; width:708px; height:170px;" >
                            <asp:GridView ID="gv_Invoice" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                 
                               BackColor="White" BorderColor="#C8C8C8"  BorderStyle="none"

                                 OnPageIndexChanging="gv_Invoice_PageIndexChanging"
                                HorizontalAlign="Left" OnRowDataBound="gv_Invoice_RowDataBound" OnSelectedIndexChanged="gv_Invoice_SelectedIndexChanged"
                                 DataKeyNames="INVOICE_ID,INVOICE_SLNO" AllowSorting="True" CssClass="grid-view"
                                Width="99.6%" ShowHeaderWhenEmpty="true" 
                                BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">


                                   <AlternatingRowStyle   BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle  Font-Bold="true"  />
                                    

                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="S.No" >
                                        <ItemTemplate >
                                            <asp:Label ID="lblFullName" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="INVOICE_SLNO" HeaderText="InvSlNo">
                                        <HeaderStyle CssClass="hideGridColumn"  />
                                        <ItemStyle CssClass="hideGridColumn"   />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_NO" HeaderText="Inv No" >
                                        <ItemStyle CssClass="column_style_left"    />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_DATE" HeaderText="Inv Date"  >
                                        <ItemStyle CssClass="column_style_left5"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TERMS" HeaderText="Terms">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_VALUE" HeaderText="Inv Value" ItemStyle-HorizontalAlign="Right">
                                        <ItemStyle CssClass="column_style_right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="Currency">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_SINGLE_OR_MULITIPLE" HeaderText="Single / Multiple">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="Supplier Name">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_ADDRESS" HeaderText="Supplier Address">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_ADDRESS1" HeaderText="Supplier Address1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_ADDRESS2" HeaderText="Supplier Address2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_COUNTRY_NAME" HeaderText="Supplier Country Name">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_COUNTRY_CODE" HeaderText="Supplier Country Code">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_COUNTRY_PINCODE" HeaderText="Supplier Country Pincode">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_ADDRESS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_ADDRESS1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_ADDRESS2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_COUNTRY_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_COUNTRY_CODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLERCOUNTRY_PINCODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_ADDRESS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_ADDRESS1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_ADDRESS2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_COUNTRY_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_COUNTRY_CODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_COUNTRY_PINCODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_AGENCY_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_AGENCY_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_AGENCY_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_AGENCY_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_DISCOUNT_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_DISCOUNT_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_DISCOUNT_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_DISCOUNT_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_DISCOUNT_REASON">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_LOADING_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_LOADING_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_LOADING_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_LOADING_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_FREIGHT_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_FREIGHT_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_FREIGHT_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_FREIGHT_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_INSURANCE_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_INSURANCE_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_INSURANCE_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_INSURANCE_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_HIGHSEASALE_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_HIGHSEASALE_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_HIGHSEASALE_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_HIGHSEASALE_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_RELATION">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_REF_NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_CUSTOM_HOUSE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_LOADING_ON">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_ASSESABLE_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_DUTY_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_ASSESABLE_STATUS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_DUTY_STATUS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_PURCHASE_ORDER">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_PURCHASE_ORDER_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_CONTRACT_NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_CONTRACT_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_LOC_NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_LOC_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_NATURE_OF_TRANSACTION">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_TERMS_OF_PAYMENT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_CONDITIONS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_VALUATION_METHOD">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_REF_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkmodify" runat="server" CommandName="Select" PostBackUrl='<%#"~/Transaction/Item_Details.aspx?INVOICE_SLNO_ID="+Eval("INVOICE_SLNO") %>'
                                                OnClientClick="jQuery('#form1').validationEngine('hideAll');Product_Open_button();">Product</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:TemplateField>
                                        <asp:BoundField DataField="NON_STD_EFFECT_DT_IMP">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                        <asp:BoundField DataField="NON_STD_BANKNAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                        <asp:BoundField DataField="NON_STD_CERTIFICATE_NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                        <asp:BoundField DataField="NON_STD_CERTIFICATE_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="SAP_DELIEVERY_ID">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                        <asp:BoundField DataField="SHIP_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                        <asp:BoundField DataField="INVOICE_LEVEL">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                        <asp:BoundField DataField="COUNTRY_OF_DEPARTURE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="INVOICE_ID" HeaderText="">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>


                                         <asp:BoundField DataField="REVENUEDEPOSIT_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                        <asp:BoundField DataField="REVENUEDEPOSIT_ON">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="MI_FREIGHT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="MI_INSURANCE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="MI_MISC">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="MI_HSS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="TERMS_PLACE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="THIRDPARTY_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="THIRDPARTY_ADD1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="THIRDPARTY_ADD2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="THIRDPARTY_CITY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="T_PARTY_COUNTRY_SUB_DIV">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="T_PARTY_COUNTRY_CODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="T_PARTY_PIN">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="AUTHORIZED_ECONOMIC_OPERATOR_CODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="A_E_O_COUNTRY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="AUTHORIZED_ECONOMIC_OPERATOR">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="WHETHER_BUYER_SELLER_RELATED">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="A_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="B_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="C_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="D_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="E_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="F_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="G_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="H_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="I_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="J_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="K_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="L_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="M_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="N_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="TOTAL_OTHER_AMOUNT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="DOC_RECD_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="INV_MISC_T_F">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="INV_MISC_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="INV_MISC_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="INV_MISC_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="INV_MISC_TOTAL_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="INV_MISC_ADD_FRT_INS_YN">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="SUPPLIER_BRANCH_SLNO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="AMENDMENT_TYPE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                </Columns>
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" PreviousPageText="Previous" Position="Top" />
                                     <PagerStyle CssClass="pager" />

                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier">
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Supplier Name
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtSupplierName"  runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_IGM_Air_namenew"
                               Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);" ClientIDMode="Static" TabIndex="7"></asp:TextBox>
                                    
                            </div>
                            <div id="magnify_area">
                              <div id="dv_suppliername_popup" runat="server">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('Supplier'); return false"
                                    class="magnfy"></a>
                              </div>
                            </div>
                           <%-- <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier_JOB_Edit(document.getElementById('txtSupplierName').value,document.getElementById('txtSupplier_Branch_Slno').value); return false"
                                    class="magnfy"></a>
                            </div>--%>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                            <%--<asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');openSupplier_Masternew1(); return false" />--%>
                                    <%--<asp:ImageButton ID="btn_Masedit" Height="26px" Width="30px" ToolTip="Client Edit" ImageUrl="~/images/icons/jobedit_master.png" runat="server"
                    OnClientClick="jQuery('#form1').validationEngine('hideAll');Supplier_Masterupdate_N_JobSearch(document.getElementById('txtSupplierName').value,document.getElementById('txtSupplier_Branch_Slno').value,'Job'); return false"  />--%>
                    <asp:ImageButton ID="btn_Masedit" Height="26px" Width="30px" ToolTip="Supplier Edit" ImageUrl="~/images/icons/jobedit_master.png" runat="server"
                    OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier_JOB_Edit(document.getElementById('txtSupplierName').value,document.getElementById('txtSupplier_Branch_Slno').value,'Job'); return false"  />
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Branch Slno.
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtSupplier_Branch_Slno" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);" ClientIDMode="Static" TabIndex="8"></asp:TextBox>
                                    
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Supp. Address
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtSupplierAddress" runat="server" MaxLength="35" CssClass="validate[required] txtbox_none_Mid_transac_IGM_Air_namenew"
                                    Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);" ClientIDMode="Static" TabIndex="8"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSupplierAddress1" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                    Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);" MaxLength="35" ClientIDMode="Static" TabIndex="9"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtSupplierAddress2" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_IGM_Air_namenew"
                                  Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"  ClientIDMode="Static" TabIndex="10"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Pin Code
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtSuppliercountry_pincode" runat="server" MaxLength="10" TabIndex="12"
                                    CssClass="validate[custom[onlyNumberSp]] txtbox_none_Mid_transac_code" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Country Name
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtSupplierCountryName" runat="server" MaxLength="35" CssClass="validate[required] txtbox_none_Mid_transac_IGM_Air_namenew"
                                    ClientIDMode="Static" TabIndex="11"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry('Supplier'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <asp:LinkButton ID="lnk_supp" Text="Set this Supplier as Manufacturer in all Items in this Invoice"
                                runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Do U Want to Update - this Supplier as Manufacturer in all Items in this Invoice  ? ', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {         
              document.getElementById('btn_Update_Supplier').click();          
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn_Update_Supplier" runat="server" TabIndex="11" CssClass="dlete"
                                Style="display: none;" OnClick="btn_Update_Supplier_Click" />
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Broker Name
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtBrokerName" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_IGM_Air_namenew"
                                    ClientIDMode="Static" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <div id="dv_brokername_popup" runat="server">
                                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('Broker'); return false"
                                        class="magnfy"></a>
                                 </div>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                                <asp:Button ID="Button2" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');openSupplier_Masternew1(); return false" />
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Seller Name
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSellerName" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="19"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                               <div id="dv_sellername_popup" runat="server">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('Seller'); return false"
                                    class="magnfy"></a>
                                </div>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                                <asp:Button ID="Button1" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');openSupplier_Masternew1(); return false" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Broker Address
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtBrokerAddress" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_IGM_Air_namenew"
                                    ClientIDMode="Static" TabIndex="14"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Seller Address
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSellerAddress" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                    ClientIDMode="Static" TabIndex="20"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtBrokerAddress1" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_IGM_Air_namenew"
                                    ClientIDMode="Static" TabIndex="15"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSellerAddress1" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                    ClientIDMode="Static" TabIndex="21"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtBrokerAddress2" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_IGM_Air_namenew"
                                    ClientIDMode="Static" TabIndex="16"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSellerAddress2" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                    ClientIDMode="Static" TabIndex="22"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Country Name
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtBrokerCountryName" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="17"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry('Supplier'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp" style="width: 50px">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Country Name
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSellerCountryName" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="23"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry('Seller'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 50px">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Pin Code
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtbrokercountry_pincode" runat="server" MaxLength="10" CssClass="validate[custom[onlyNumberSp]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" TabIndex="18"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp" style="width: 53px">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Pin Code
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtSellercountry_pincode" runat="server" MaxLength="10" CssClass="validate[custom[onlyNumberSp]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" TabIndex="24"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%-- <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" ValidationGroup="draw" CssClass="save"
                        OnClick="btnSave_Click" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="dlete" OnClick="btnDelete_Click" />
                </div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />
                </div>
            </div>--%>
                </div>
                <div class="content" id="page-3">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_MISC" style="margin-top:-15px">
                        <%--<div id="tag_transac_lft_Trans_Invoice_Supp_in1_chkbox_frame">
                            <div id="pop_text_area_transac_MIS_InnTitle1_chkbox">
                                Multiple Invoice
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                                <asp:CheckBox ID="chkMisc" runat="server" TabIndex="25" /></div>
                        </div>--%>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                Currency</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                Exchange Rate</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                Rate</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                Charge</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="Div_Total_Charge_lable" runat="server" style="display: none;">
                                <div id="pop_text_area_transac_MIS_InnTitle1">
                                    Total Charge</div>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                MISC</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMiscellaneous_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="27" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Misc'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtMiscellaneous_Exch_Rate" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    Style="text-align: right;" ClientIDMode="Static" TabIndex="28"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtMiscellaneous_Rate" runat="server" MaxLength="8" Style="text-align: right;"
                                    onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);" Enabled="false"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" TabIndex="29"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtMiscellaneous_Charges" runat="server" MaxLength="17" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    TabIndex="30" Style="text-align: right;" onblur="extractNumber(this,2,false);"
                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="Div_MISC_txt" runat="server" style="display: none;">
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtMisc_Total_Charge" runat="server" MaxLength="17" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                        TabIndex="30" Style="text-align: right;" onblur="extractNumber(this,2,false);"
                                        Width="65px" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Inv MISC
                                <asp:CheckBox ID="chk_active_Inv_Misc" runat="server" /></div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_INV_MISC_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="31" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Freight_MISC'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_INV_MISC_Exch_Rate" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    Style="text-align: right;" ClientIDMode="Static" TabIndex="31"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 80px; visibility: hidden;">
                                <asp:CheckBox ID="chk_add_INV_MISC" runat="server" Text="Add Frt&Ins" />
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 80px;">
                                <asp:TextBox ID="txt_INV_MISC_Charges" runat="server" MaxLength="17" CssClass="validate[custom[number] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="31" Style="text-align: right;" onblur="extractNumber(this,2,false);"
                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="Div_Freight_Misc_txt" runat="server">
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_INV_MISC_Total_Charge" runat="server" MaxLength="17" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                        TabIndex="31" Style="text-align: right;" onblur="extractNumber(this,2,false);" Enabled="false" ReadOnly="true"
                                        Width="85px" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp" style="width: 80px;">
                                    <asp:Label ID="lbl_INV_MISC_Total_Charge_Currency" runat="server" Width="50px" ClientIDMode="Static"></asp:Label></div>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Agency</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtAgency_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="31" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Agency'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtAgency_Exch_Rate" runat="server" MaxLength="12" Style="text-align: right;"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    ClientIDMode="Static" TabIndex="32"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtAgency_Rate" MaxLength="12" runat="server"  onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" Style="text-align: right;"
                                    TabIndex="33"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtAgency_Charges" runat="server"  MaxLength="12"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" Style="text-align: right;"
                                    TabIndex="34" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Discount</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtDiscount_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="35" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Discount'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtDiscount_Exch_Rate" Style="text-align: right;" runat="server"
                                    MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    ClientIDMode="Static" TabIndex="36"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtDiscount_Rate" Style="text-align: right;" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    runat="server" MaxLength="7" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" Enabled="false"
                                    TabIndex="37"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtDiscount_Charges" Style="text-align: right;" runat="server" MaxLength="17"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" TabIndex="38"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_Dis_empty">
                                Discount Reason
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtDiscount_Reason" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="50" TabIndex="39"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Loading</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtLoading_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="40" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                    ></asp:TextBox>
                            </div>
                            <%--<div id="magnify_area" style="display:none">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Loading'); return false"
                                    class="magnfy"></a>
                            </div>--%>
                            <div id="magnify_area">
                                <%--<a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Loading'); return false"
                                    class="magnfy"></a>--%>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtLoading_ExchRate" Style="text-align: right;" runat="server" MaxLength="12"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    ClientIDMode="Static" TabIndex="41" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtLoading_Rate" runat="server" Style="text-align: right;" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="12" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                    TabIndex="42" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtLoading_Charges" runat="server" Style="text-align: right;" MaxLength="17"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" TabIndex="43"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" ></asp:TextBox>
                            </div>
                        </div>
                        <asp:Panel ID="pnl_Multi_Invoice" runat="server">
                            <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                    Freight</div>
                                <div id="txtcon-m_transaction_item_maindet">
                                    <asp:UpdatePanel ID="UpTxtExpiryDate" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtFreight_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                                ClientIDMode="Static" TabIndex="44" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="txtFreight_Currency_TextChanged" EventName="TextChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div id="magnify_area">
                                    <a href="#" onclick="OpenPopupExchange('Freight'); return false" class="magnfy">
                                    </a>
                                    <asp:LinkButton ID="ImageButton10" runat="server" CssClass="magnfy" Enabled="false"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange_Master_Frieght('Freight'); return false"></asp:LinkButton>
                                </div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtFreight_Exch_Rate" runat="server" MaxLength="12" Style="text-align: right;"
                                        CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                        onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        ClientIDMode="Static" TabIndex="45"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtFreight_Rate" Style="text-align: right;" runat="server" MaxLength="8"
                                        onblur="extractNumber(this,4,false);return Clear_Dot(this);" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                        TabIndex="46" CausesValidation="false" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                    %</div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtFreight_Charges" runat="server" MaxLength="17" Style="text-align: right;"
                                        Enabled="false" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                        onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="47"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_Totalfrieght" runat="server" visible="false" class="tag_transac_lft_Trans_Invoice_Supp_in1">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_Dis_empty">
                                    Total Freight Charge
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtTotal_Frieght" runat="server" MaxLength="17" CssClass="txtbox_none_Mid_transac_code"
                                        TabIndex="48" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                    Insurance</div>
                                <div id="txtcon-m_transaction_item_maindet">
                                    <asp:TextBox ID="txtInsurance_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                        ClientIDMode="Static" TabIndex="49" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                    <a href="#" onclick="OpenPopupExchange('Insurance'); return false" class="magnfy">
                                    </a>
                                    <asp:LinkButton ID="ImageButton11" runat="server" CssClass="magnfy" Enabled="false"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange_Master_Insurance('Insurance'); return false"></asp:LinkButton>
                                </div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtInsurance_Exch_Rate" runat="server" MaxLength="12" Style="text-align: right;"
                                        CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                        onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        ClientIDMode="Static" TabIndex="50"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtInsurance_Rate" runat="server" MaxLength="8" Style="text-align: right;"
                                        onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                        TabIndex="51"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                    %</div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtInsurance_Charges" runat="server" MaxLength="17" Style="text-align: right;"
                                        Enabled="false" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                        onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="52"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_TotalInsurance" runat="server" visible="false" class="tag_transac_lft_Trans_Invoice_Supp_in1">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_Dis_empty">
                                    Total Insurance Charge
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtTotal_Insurance" runat="server" MaxLength="17" CssClass="txtbox_none_Mid_transac_code"
                                        TabIndex="53" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                High Sea Sale
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtHighSeaSale_Currency" runat="server" MaxLength="3" Text="INR"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_maindet" TabIndex="54"
                                    onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="OpenPopupExchange('HighSeaSale'); return false" class="magnfy">
                                </a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtHighSeaSale_Exch_Rate" runat="server" MaxLength="12" Style="text-align: right;"
                                    Text="1.00" ClientIDMode="Static" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    TabIndex="55" onblur="extractNumber(this,4,false);return Clear_Dot(this);" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtHighSeaSale_Rate" runat="server" MaxLength="7" Style="text-align: right;"
                                    onblur="javascript:this.value=Comma(this.value); extractNumber(this,2,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" TabIndex="56"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtHighSeaSale_Charges" runat="server" MaxLength="17" Style="text-align: right;"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    TabIndex="57"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="Div_Hss_txt" runat="server" style="display: none;">
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtHss_Total_Charge" runat="server" MaxLength="17" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                        TabIndex="30" Style="text-align: right;" onblur="extractNumber(this,2,false);"
                                        Width="65px" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-----------------------------Revenue Deposit--------------------------------%>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Revenue Deposit
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtRevenue_Deposit" runat="server" MaxLength="5" Style="text-align: right;"
                                    ClientIDMode="Static" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="58" onblur="extractNumber(this,4,false);return Clear_Dot(this);" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                                On
                            </div>
                            <div id="txtcon-m_transaction_list1_LoadingOn">
                                <asp:DropDownList ID="ddlRevenueDeposit_On" CssClass="listtxt_transac_LoadingOn"
                                    runat="server" TabIndex="62">
                                    <%-- <asp:ListItem>Assessable</asp:ListItem>
                        <asp:ListItem>Duty</asp:ListItem>
                        <asp:ListItem>Both</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%-----------------------------Revenue Deposit--------------------------------%>
                    </div>
                    <%--  <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="save" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="updates" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="dlete" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" /></div>
            </div>--%>
                </div>
                <div class="content" id="page-4">
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_chkbox_frame">
                        <div id="tag_label_transaction_MIS_empty1">
                            <asp:CheckBox ID="chkSVB_Relation" runat="server" TabIndex="58"></asp:CheckBox></div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="pop_text_area_transac_MIS_InnTitle1_chkbox">
                            SVB Relation
                        </div>
                        <div id="magnify_area">
                        <div id="dv_SVBRelation_popup" runat="server">
                            <a href="#" class="magnfy" tabindex="21" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_SVB_Details(document.getElementById('txtSupplierName').value); return false">
                            </a>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            SVB Ref No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtSVB_RefNo" runat="server" MaxLength="20" 
                                 CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                Enabled="false" TabIndex="59"></asp:TextBox>
                        </div>
                        <%-- -------------------%>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Date</div>
                        <div id="txtcon-m_transaction_SVB_Date">
                            <%--txtcon-m_transaction_SVB_Date--%>
                            <asp:TextBox ID="txtSVBDate" runat="server" Width="95px" TabIndex="60" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Enabled="False"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtSVBDate"
                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtSVBDate"
                                Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                            </asp:CalendarExtender>
                            <%-- <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red" Display="None"
                            runat="server" ControlToValidate="txtDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                            --%>
                        </div>
                        <%-- -------------------%>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            SVB Custom House
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCustomsHouse" runat="server" TabIndex="61" CssClass="txtbox_none_Mid_transac_Supp_Name" onkeyup="ChangeCase(this);"
                                MaxLength="6"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width: 25px;">
                        </div>
                        <div id="magnify_area">
                            <a href="#" class="magnfy" onclick="OpenPopupCustom_House_Details('SVB'); return false">
                            </a>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Loading On
                        </div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlLoadingOn" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="62">
                                <%-- <asp:ListItem>Assessable</asp:ListItem>
                        <asp:ListItem>Duty</asp:ListItem>
                        <asp:ListItem>Both</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Assessable Rate
                        </div>
                        <div id="txtcon-m_transaction_SVB_Rate">
                            <asp:TextBox ID="txtAssesable_Rate" runat="server" onkeypress="return numdot1(event)"
                                 CssClass="validate[custom[number]] txtbox_none_Mid_transac_SVB_Rate"
                                Enabled="false" MaxLength="16" TabIndex="63"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_SVB_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Status</div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlAssesable_Status" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="64">
                                <%-- <asp:ListItem>P</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Duty Rate
                        </div>
                        <div id="txtcon-m_transaction_SVB_Rate">
                            <asp:TextBox ID="txtDuty_Rate" runat="server" onkeypress="return numdot1(event)"
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_SVB_Rate" Enabled="false"
                                MaxLength="16" TabIndex="65"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_SVB_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Status</div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlDuty_Status" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="66">
                                <%--  <asp:ListItem>P</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB"></div>
                        <asp:Button ID="btn_svb_update" runat="server" Text="SVB Update" 
                            onclick="btn_svb_update_Click" />
                    </div>
                    <%--  <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="save" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="updates" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="dlete" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" /></div>
            </div>--%>
                </div>
                <div class="content" id="page-5">
                    <%--<div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                    </div>--%>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Purchase Order No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtPurchaseOrderNo" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);" MaxLength="20" TabIndex="67"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Purchase Date
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtPurchaseDate" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                MaxLength="10" TabIndex="68"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender1"
                                    runat="server" TargetControlID="txtPurchaseDate" Mask="99/99/9999" MaskType="Date"
                                    ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True">
                                </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPurchaseDate"
                                Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                            </asp:CalendarExtender>
                            <%-- <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator2" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="None"
                        runat="server" ControlToValidate="txtPurchaseDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Contract No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtContractNo" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);" MaxLength="20" TabIndex="69"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Contract Date
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtContractDate" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                MaxLength="10" TabIndex="70"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender2"
                                    runat="server" TargetControlID="txtContractDate" Mask="99/99/9999" MaskType="Date"
                                    ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True">
                                </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtContractDate"
                                Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                            </asp:CalendarExtender>
                            <%--   <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator3" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" Display="None"
                        runat="server" ControlToValidate="txtContractDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            LC No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtLCNo" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);" MaxLength="20" TabIndex="71"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            LC Date
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtLCDate" CssClass="txtbox_none_Mid_transac_Supp_Name" runat="server"
                                TabIndex="72"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                    TargetControlID="txtLCDate" Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True"
                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True">
                                </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtLCDate"
                                Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                            </asp:CalendarExtender>
                            <%--<asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RegularExpressionValidator4" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ForeColor="Red" Display="None"
                        runat="server" ControlToValidate="txtLCDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Nature of Trans
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:DropDownList ID="ddlNatureOfTrans" CssClass="txtbox_none_Mid_transac_others_Name"
                                runat="server" Height="18px" TabIndex="73">
                               <%-- <asp:ListItem>S&nbsp; Sale</asp:ListItem>
                                <asp:ListItem>F&nbsp; Free Of Cost</asp:ListItem>
                                <asp:ListItem>C&nbsp; Consignment</asp:ListItem>
                                <asp:ListItem>G&nbsp; Gift</asp:ListItem>
                                <asp:ListItem>H&nbsp; Hire</asp:ListItem>
                                <asp:ListItem>M&nbsp; Sample</asp:ListItem>
                                <asp:ListItem>O&nbsp; Others</asp:ListItem>
                                <asp:ListItem>P&nbsp; Replacement </asp:ListItem>
                                <asp:ListItem>R&nbsp; Rent</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Nature of Payment
                        </div>
                        <div id="txtcon-m_transaction_Inv">
                            <asp:DropDownList ID="ddlNatureOfPayment" CssClass="txtbox_none_Mid_transac_InvNew"
                                runat="server" TabIndex="74">
                               <%-- <asp:ListItem>OTH Others</asp:ListItem>
                                <asp:ListItem>DP Document Presentation</asp:ListItem>
                                <asp:ListItem>FC Free Of Charge</asp:ListItem>
                                <asp:ListItem>LC Letter Of Credit</asp:ListItem>
                                <asp:ListItem>SD Site Draft</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>

                    </div>
                    
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others">
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1">
                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                                Conditions</div>
                            <div id="txtcon_l_90px">
                            </div>
                            <div id="tag_label_transaction_export_Item_otherdet_new2">
                                <asp:TextBox ID="txtConditions" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new3"
                                    onpaste="return checkTextAreaMaxLength(this,event,'1000');" runat="server" onkeyDown="return checkTextAreaMaxLength(this,event,'1000');"
                                    MaxLength="1000" TabIndex="75"></asp:TextBox>
                            </div>
                        </div>
                        <div id="lblMsg5" style="display: none;">
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Valuation Method
                        </div>
                        <div id="txtcon-m_transaction_Inv">
                            <asp:DropDownList ID="ddlValuationMethod" CssClass="txtbox_none_Mid_transac_InvNew"
                                runat="server" TabIndex="75">
                               <%-- <asp:ListItem>Rule 4 - Transaction Value </asp:ListItem>
                                <asp:ListItem>Rule 5 - Identical Goods</asp:ListItem>
                                <asp:ListItem>Rule 6 - Similar Goods</asp:ListItem>
                                <asp:ListItem>Rule 7 - Deductive Value</asp:ListItem>
                                <asp:ListItem>Rule 7A - Computed Value</asp:ListItem>
                                <asp:ListItem>Rule 8 - Residual Method</asp:ListItem>
                                <asp:ListItem>Rule 9 - SVB Related Goods</asp:ListItem>
                                <asp:ListItem>OTHERS - Others</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            SAP Delievery ID
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtSAP_Delievery_ID" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" MaxLength="20" TabIndex="75"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Ship Date
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtShip_Date" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                MaxLength="10" TabIndex="76"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender6"
                                    runat="server" TargetControlID="txtShip_Date" Mask="99/99/9999" MaskType="Date"
                                    ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True">
                                </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtShip_Date"
                                Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                            </asp:CalendarExtender>
                            <%-- <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator2" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="None"
                        runat="server" ControlToValidate="txtPurchaseDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Invoice Level
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtInvoice_Level" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" MaxLength="20" TabIndex="76"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Country Of Departure
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                          <asp:TextBox ID="txtCountry_Departure" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" MaxLength="20" TabIndex="77"></asp:TextBox>
                            <%-- <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator2" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="None"
                        runat="server" ControlToValidate="txtPurchaseDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            <asp:Label ID="lbl_DocRecd_Date" runat="server" Text="Doc.Recd.Date"></asp:Label>
                        </div>
                      <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_DocRecd_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="77"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt_DocRecd_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_DocRecd_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            
                            </div>
                    </div>


                    <%-- <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="save" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="updates" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="dlete" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" /></div>
            </div>--%>

                </div>      
                           
                 <div class="content" id="page-6">
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                       
                          <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Third Party Name
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ThirdPartyName" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);" MaxLength="70" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        <div id="dv_Thirdpartyname_popup" runat="server">
                         <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Exp_Thirdparty('Imp_ThirdParty'); return false"
                                    class="magnfy"></a>
                                </div>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                            Authorized Economic Operator Code
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Authrzd_Economic_Code" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" onpaste="return validatePaste(event);"
                                MaxLength="17" TabIndex="79"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Third Party Address1
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ThirdParty_Add1" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                MaxLength="70" onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                            Authorized Economic Operator Country
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Authrzd_Economic_Country" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" onpaste="return validatePaste(event);"
                                MaxLength="2" TabIndex="79"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                         <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Third Party Address2
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ThirdParty_Add2" CssClass="txtbox_none_Mid_transac_Supp_Name" onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                runat="server" MaxLength="50" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                            Authorized Economic Operator Role
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Authrzd_Economic_Role" CssClass="txtbox_none_Mid_transac_Supp_Name"
                               runat="server" MaxLength="3" TabIndex="79"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                         <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Third Party City
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ThirdParty_City" CssClass="txtbox_none_Mid_transac_Supp_Name" Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                runat="server" MaxLength="35" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                            Whether Buyer & Seller are Related Y/N
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Whether_Relater_Y_N" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                runat="server" MaxLength="1" TabIndex="79"></asp:TextBox>
                        </div>
                        <div id="txtcon-m_transaction_Inv">
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                         <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Country Sub Division
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Country_Division" CssClass="txtbox_none_Mid_transac_Supp_Name" Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                runat="server" MaxLength="35" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        </div>
                        <div id="txtcon-m_transaction_Inv">
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                         <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Country Code
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_CountryCode" CssClass="txtbox_none_Mid_transac_Supp_Name" runat="server"  
                                 TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        </div>
                        <div id="txtcon-m_transaction_Inv">
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Third Party Pin
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ThirdParty_Pin" CssClass="txtbox_none_Mid_transac_Supp_Name" Onkeypress="return num1(event)"
                                runat="server" MaxLength="10" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        </div>
                        <div id="txtcon-m_transaction_Inv">
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                         <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Terms Place
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_TermsPlace" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)"  onpaste="return validatePaste(event);" MaxLength="35" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        </div>
                        <div id="txtcon-m_transaction_Inv">
                        </div>
                    </div>
                </div>  

                    <div class="content" id="page-7">
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                Amount</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1" style="text-align: left">
                                Rate</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1" style="width: 90px">
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                Amount</div>
                            <div id="pop_text_area_transac_MIS_InnTitle1" style="text-align: left">
                                Rate</div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 200px">
                                A.Brokerage & Commission
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Brokerage" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_Brokerage_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 170px">
                                J.Cost of Warrenty Services
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Warrenty_Services" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_Warrenty_Services_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 200px">
                                B.Cost of Container
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Cost_Container" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_Cost_Container_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 170px">
                                K.Other Cost of Payment
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Other_Cost_Payment" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_Other_Cost_Payment_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 200px">
                                C.Cost of Packaging
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Cost_Packaging" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_Cost_Packaging_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 170px">
                                L.Other Charges & Payment
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Other_Charges_Payments" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_Other_Charges_Payments_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 200px">
                                D.Handling Charges
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Handling_Charges" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_Handling_Charges_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 170px">
                                M.Loading Charges
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Loading_Charges" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_Loading_Charges_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="txtcon-m_transaction_Inv">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 200px">
                                E.Cost of Goods and Services
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Goods_Services" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_Goods_Services_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 170px">
                                N.UnLoading Charges
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_UnLoading_Charges" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_UnLoading_Charges_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="txtcon-m_transaction_Inv">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 200px">
                                F.Documentation
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Documentation" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Documentation_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            </div>
                            <div id="txtcon-m_transaction_Inv">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 200px">
                                G.Country of Origin Certificate
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Country_Origin" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:TextBox ID="txt_Country_Origin_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            </div>
                            <div id="txtcon-m_transaction_Inv">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 200px">
                                H.Royalties and license fees
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Royalties_lic_fees" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Royalties_lic_fees_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            </div>
                            <div id="txtcon-m_transaction_Inv">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 200px">
                                I.Value of proceeds which accrue
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Value_of_Proceeds" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Value_of_Proceeds_Rate" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="13" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    Width="50px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="font-weight: bold">
                                TOTAL AMOUNT
                            </div>
                            <div id="txtcon-m_transaction_Inv">
                                <asp:TextBox ID="txt_Total_Amount" runat="server" ReadOnly="true" CssClass="txtbox_none_Mid_transac_code" ClientIDMode="Static"
                                    Font-Bold="true"></asp:TextBox>
                            </div>
                        </div>

                </div>  
           
            </div>
             

            <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_det_Inv_S_No" style="height:29px; margin-top:10px;">
            <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv. Sl No :
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                       <asp:DropDownList ID="ddlInv_SL_No" runat="server" CssClass="listtxt_transac_src1"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlInv_SL_No_SelectedIndexChanged">
                            </asp:DropDownList>
                      
                      </div>
                </div>
            </div>

            <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_det_INVOICE">
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_Topcap">
                    Current Invoice Details</div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv No
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceNo" runat="server" ClientIDMode="Static"></asp:Label></div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv Date
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv Value
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceValue" runat="server"></asp:Label></div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv Cur</div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceCurrency" runat="server"></asp:Label></div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv Term
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceTerms" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Prod Val
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblProductValue" runat="server"></asp:Label>
                    </div>
                </div>

                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        No Of Inv
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblTotal_No_Of_Invoices" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_bot_transact_invoice" style="width: 960px;">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="84"
                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');document.getElementById('hdn_button_click').value = '1';" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" Text="save"
                        OnClientClick="return validate_Invoice('btnSave');" TabIndex="81" />
                </div>
                 <div id="editbu">
                        <asp:Button ID="btn_save_new" Text="Save & New" CssClass="autowidupdatebut" TabIndex="81"
                            runat="server" OnClientClick="return validate_Invoice('btnSave');" OnClick="btn_save_new_Click" />
                    </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                        Visible="false" TabIndex="81" OnClientClick="return validate_Invoice('btnUpdate');" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="82" CausesValidation="false"
                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="82" CausesValidation="false" UseSubmitBehavior="false"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                        CssClass="dlete" Style="display: none;" />
                </div>
                <div id="editbu">
                 <%--<asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Parent_close_button1();return false;"
                        tabindex="83" CausesValidation="false"
                        UseSubmitBehavior="false" />--%>
                       <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1_Trigger_AnotherPage('General',document.getElementById('hdn_source').value);return false;"
                                    id="btnCancel" tabindex="83">  
                    </div>
                <div id="editbu">
                         <asp:Button ID="btngenexcel" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                      CssClass="autowidmovebut" Text="XL Upload" OnClientClick="jQuery('#form1').validationEngine('hide');open_IMP_Inv_Excel_Upload('New');return false;"  />

                </div>
                <div id="editbu">
                <%--    <asp:Button ID="btnGmm" runat="server" CausesValidation="false" UseSubmitBehavior="false" Visible="false"
                        CssClass="autowidmovebut" Text="Gmmco Upload" Width="95px" OnClientClick="jQuery('#form1').validationEngine('hide');return false;" />--%>
                </div>

                
                <div id="editbu">
                  
                 <asp:Button ID="btnCP_Upload" Width="5px" runat="server" CausesValidation="false" UseSubmitBehavior="false" Visible="false"
                 CssClass="autowidmovebut" Text="CP Upload" OnClientClick="jQuery('#form1').validationEngine('hide');open_IMP_CP_Excel_Upload('New');return false;"  />

                  <asp:Button ID="btn_Update_Product_Master_152" runat="server" CausesValidation="false" UseSubmitBehavior="false" Visible="false" 
                 CssClass="autowidmovebut" Text="Pro. Master" OnClientClick="jQuery('#form1').validationEngine('hide');open_Product_Imp_Master_152('New');return false;"  />

                </div>
                 
                <div id="editbu"  style="padding-left:10px;">
                   <a href="../Submission/Import_Excel_Format/IMPORT_v3.0.xlsm"  target="_new">
                    <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Macro Excel File"  Height="30px"  Width="30px" runat="server" /></a>
                </div>
                <div id=editbu  style="padding-left:3px;padding-right:3px"> 
                <a href="../Submission/Import_Excel_Format/IMPORT.xlsx"  target="_new">
                        <asp:Image ID="Image2" ImageUrl="~/images/icons/excel.png" ToolTip="Download Import Excel File"  Height="30px"  Width="30px" runat="server" />
                        </a>
                </div>
                <div id="editbu" >

                     <asp:Button ID="Button7" runat="server" CausesValidation="false" UseSubmitBehavior="false" 
                        CssClass="autowidmovebut" Text="Inv Copy" Width="60px" 
                        OnClientClick="jQuery('#form1').validationEngine('hide');open_Inv_Copy(); return false;" 
                        />
                    </div>

                     <div id="editbu" >                   

                     <asp:Button ID="btn_Indev_Nissan" runat="server" CausesValidation="false" UseSubmitBehavior="false" Visible="false"
                        CssClass="autowidmovebut" Text="Nissan Upload" Width="90px" 
                        OnClientClick="jQuery('#form1').validationEngine('hide');open_Indev_Nissan_Excel_Upload(); return false;" 
                        />
                    </div>

                    <div id="editbu" >                   

                     <asp:Button ID="Btn_Nippon_ExcelUpload" runat="server" CausesValidation="false" UseSubmitBehavior="false"  Visible="false"
                        CssClass="autowidmovebut" Text="Nippon Upload" Width="90px" 
                        OnClientClick="jQuery('#form1').validationEngine('hide');open_Excel_Upload_SVB(); return false;" 
                        />
                    </div>

                     <div id="editbu" style="width:45px;">                   
                     <%--<asp:Button ID="btn_Multiple" runat="server" CausesValidation="false" UseSubmitBehavior="false" 
                        CssClass="autowidmovebut" Text="Split" Width="50px" 
                        OnClientClick="jQuery('#form1').validationEngine('hide');open_Multiple_Inv(); return false;" />--%>

                        <asp:Button ID="btn_Multiple" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="autowidmovebut" Text="Split" Width="44px" OnClientClick="IMP_MultiSplit(); return false;" />
                        
                    </div>
                    <%-- <div id="editbu" style="width: 51px;">
                    <asp:Button ID="btn_XBE_Split" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="autowidmovebut" Text="XBE-Split" Width="50px" OnClientClick="IMP_MultiSplit_XBE(); return false;" />
                </div>--%>
                    <%--<div id="editbu" style="width:45px;">
                    <asp:Button ID="btnItemUpload" runat="server" Width="44px"  CausesValidation="false" UseSubmitBehavior="false" Visible="false"
                        CssClass="autowidmovebut" Text="PDF" OnClientClick="jQuery('#form1').validationEngine('hide');open_Imp_item_PDF('New');return false;" />
                </div>--%>
                  <div id="editbu" runat="server">
                    <asp:Button ID="btnInv_move" Text="Move" CssClass="autowidupdatebut" Width="50px"
                        runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_IMP_Prouduct_Invoice_Move('New'); return false;" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnInvoiceExcelDownload" runat="server" CausesValidation="false"
                        UseSubmitBehavior="false" CssClass="autowidmovebut" Text="Inv. Download" OnClientClick="Import_Excel_download(); return false" />
                </div>
                <%--<div id="editbu" style="width: 80px;">
                    <asp:Button ID="btnInvPdfUpload" runat="server" Width="80px" CausesValidation="false"
                        UseSubmitBehavior="false" Visible="false" CssClass="autowidmovebut" Text="PDF-READER"
                        OnClientClick="jQuery('#form1').validationEngine('hide');open_Imp_Inv_Item_Pdf_Reader('New');return false;" />
                </div>--%>
                <div id="editbu" style="width: 61px;">
                    <asp:Button ID="btn_XBE_Split" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="autowidmovebut" Text="XBE-Split" Width="60px" OnClientClick="IMP_MultiSplit_XBE(); return false;" />
                </div>
            </div>


                <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static"/>

                <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                <asp:HiddenField ID="hfdsupplier_countrycode" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hfdseller_countrycode" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hfdbroker_countrycode" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_currency" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Invoice_Currency_Exrate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_FOB_Freight_Rate" runat="server" ClientIDMode="Static" Value="20.0000" />
                <asp:HiddenField ID="hdn_FOB_Freight_Charge" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_FOB_Freight_Currency" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_FOB_Freight_ExRate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CI_Freight_Rate" runat="server" ClientIDMode="Static" Value="20.0000" />
                <asp:HiddenField ID="hdn_CI_Freight_Charge" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CI_Freight_Currency" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CI_Freight_ExRate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CF_Freight_Rate" runat="server" ClientIDMode="Static" Value="20.0000" />
                <asp:HiddenField ID="hdn_CF_Freight_Charge" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CF_Freight_Currency" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CF_Freight_ExRate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CIF_Freight_Rate" runat="server" ClientIDMode="Static" Value="20.0000" />
                <asp:HiddenField ID="hdn_CIF_Freight_Charge" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CIF_Freight_Currency" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CIF_Freight_ExRate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_FOB_Insurance_Rate" runat="server" ClientIDMode="Static"
                Value="1.1250" />
                <asp:HiddenField ID="hdn_FOB_Insurance_Charge" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_FOB_Insurance_Currency" runat="server" 
                ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_FOB_Insurance_ExRate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CI_Insurance_Rate" runat="server" ClientIDMode="Static"
                Value="1.1250" />
                <asp:HiddenField ID="hdn_CI_Insurance_Charge" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CI_Insurance_Currency" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CI_Insurance_ExRate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CF_Insurance_Rate" runat="server" ClientIDMode="Static"
                Value="1.1250" />
                <asp:HiddenField ID="hdn_CF_Insurance_Charge" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CF_Insurance_Currency" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CF_Insurance_ExRate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CIF_Insurance_Rate" runat="server" ClientIDMode="Static"
                Value="1.1250" />
                <asp:HiddenField ID="hdn_CIF_Insurance_Charge" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CIF_Insurance_Currency" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CIF_Insurance_ExRate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_update_Invoice_id" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Invoice_mode_singlr_or_multi" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_button_click" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_freight_value" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_insurance_value" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Freight_Rate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Insurance_Rate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Total_Freight_Value" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Total_Insurance_Value" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_INVOICE_SLNO" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_grid_count" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_grid_edit" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CustomsHouse_Name" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />

                <asp:HiddenField ID="hdn_non_std_effect_dt" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_non_std_bankname" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_non_std_cert_no" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_non_std_cert_dt" runat="server" ClientIDMode="Static" />
            
                <asp:HiddenField ID="HDsaveid" runat="server"  />
                <asp:HiddenField ID="HD_Imp_Name" runat="server" ClientIDMode="Static" />

                <asp:HiddenField ID="hdn_TOTAL_MULTIPLE_MISC_AMT" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_TOTAL_MULTIPLE_HSS_AMT" runat="server" ClientIDMode="Static" />

                <asp:HiddenField ID="hdn_Company_ID" runat="server" ClientIDMode="Static" />

                <asp:HiddenField ID="hdnCompany_ID" runat="server" ClientIDMode="Static" />

                <asp:HiddenField ID="hdn_BOND_NO" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_BOND_LOCATION" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_BOND_TYPE" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Total_Other_Charges" runat="server"  />
                <asp:HiddenField ID="hdn_check_CI_terms" runat="server"  />

                <asp:HiddenField ID="hdn_chk_Invalid_Cur" runat="server" />
                <asp:HiddenField ID="hdn_chk_curr" runat="server" />

                <asp:HiddenField ID="hdn_Invalid_FRT_Cur" runat="server" />
                <asp:HiddenField ID="hdn_Invalid_INS_Cur" runat="server" />
                <asp:HiddenField ID="hdn_Invalid_Disc_Cur" runat="server" />
                <asp:HiddenField ID="hdn_Invalid_Hss_Cur" runat="server" />

                <asp:HiddenField ID="hdn_load_Terms" runat="server" />
                <asp:HiddenField ID="hdn_Jobno" runat="server" />
                <asp:HiddenField ID="hdn_Branch" runat="server" />
                <asp:HiddenField ID="hdn_Direct_Exbond_YN" runat="server" />
                <asp:HiddenField ID="hdn_source" runat="server" />     
                <asp:HiddenField ID="hdn_chk_active_Inv_Misc" runat="server" />

                <asp:HiddenField ID="hdn_Supplier_br_slno" runat="server" />

                <asp:HiddenField ID="hdn_INV_MISC_Total_Charge" runat="server" />
                <asp:HiddenField ID="hdn_Customhouse_chk" runat="server" ClientIDMode="Static" />
                
                <asp:HiddenField ID="hdn_Assesable_Rate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Assesable_Status" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Duty_Rate" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Duty_Status" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_MultiBond_Select" runat="server" ClientIDMode="Static" />

                <asp:HiddenField ID="hdn_Inner_tab_Menu" runat="server"  ClientIDMode="Static"/>   
                <asp:HiddenField ID="hdn_BEType" runat="server"  ClientIDMode="Static"/>     
                <asp:HiddenField ID="hdn_Br_Slno" runat="server"  ClientIDMode="Static"/>     
                <asp:HiddenField ID="hdn_IEC_No" runat="server"  ClientIDMode="Static"/>     
                <asp:HiddenField ID="hdn_Cilent_InsuranceRate" runat="server"  ClientIDMode="Static"/>     
                <asp:HiddenField ID="hdn_LoadStatus" runat="server"  ClientIDMode="Static"/>     

            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>


     <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

       <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
             
             <tr>
                 <td style="padding-left: 125px; padding-top:10px;">
                     <asp:Button ID="Button6" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>

    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script src="../js/Import_Jscript/Import_Invoice.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
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
        // Select/Deselect checkboxes based on header checkbox
        function SelectheaderCheckboxes(headerchk, gv, button) {
            debugger
            var gvcheck = document.getElementById(gv);
            var i;
            //Condition to check header checkbox selected or not if that is true checked all checkboxes
            if (headerchk.checked) {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
                //document.getElementById(button).click();

            }
            //if condition fails uncheck all checkboxes in gridview
            else {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
        //function to check header checkbox based on child checkboxes condition
        function Selectchildcheckboxes(header, gv, button) {
            var ck = header;
            var count = 0;
            var gvcheck = document.getElementById(gv);
            var headerchk = document.getElementById(header);
            var rowcount = gvcheck.rows.length;
            //By using this for loop we will count how many checkboxes has checked
            for (i = 1; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                if (inputs[0].checked) {
                    //document.getElementById(button).click();
                    count++;
                }
            }
            //Condition to check all the checkboxes selected or not
            if (count == rowcount - 1) {
                headerchk.checked = true;

            }
            else {
                headerchk.checked = false;
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

        function validateLimit(obj, divID, maxchar) {

            objDiv = get_object(divID);

            if (this.id) obj = this;

            var remaningChar = maxchar - trimEnter(obj.value).length;

            if (objDiv.id) {
                objDiv.innerHTML = remaningChar + "";
            }
            if (remaningChar <= 0) {
                obj.value = obj.value.substring(maxchar, 0);
                if (objDiv.id) {
                    objDiv.innerHTML = "0 ";
                }
                return false;
            }
            else
            { return true; }
        }
        function get_object(id) {
            var object = null;
            if (document.layers) {
                object = document.layers[id];
            } else if (document.all) {
                object = document.all[id];
            } else if (document.getElementById) {
                object = document.getElementById(id);
            }
            return object;
        }

        function trimEnter(dataStr) {
            return dataStr.replace(/(\r\n|\r|\n)/g, "");
        }

    </script>
     <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

            var totalRows = $("#<%=gv_Invoice.ClientID %> tr").length;
            var lastProductId = $("#<%=gv_Invoice.ClientID %> tr:last").children("td:first").html();
          

            if (totalRows > 2) {

                gridviewScroll();
                
            }
            else {

                if (lastProductId > 0) {
                    gridviewScroll();
                }
                else {
                    /*alert (lastProductId);*/
                }
            }
        });

        function gridviewScroll() {
            gridView1 = $('#<%=gv_Invoice.ClientID %>').gridviewScroll({

                width: 710,
                height: 150,
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
         var win = null;

         var Jobno = $('#<%= hdn_Jobno.ClientID %>').val();
         var Branch_Common = $('#<%= hdn_Branch.ClientID %>').val();

         function Import_Excel_download() {
             var Type = 'excel';
             win = window.open('../FlatFile/MIS_report_1.aspx?Open_Import_Excel_Download_XLs=Yes&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '', 'ndf');
             Loading_HideImage();
         }

    </script>

  
     <script type="text/javascript">

         $(document).ready(function () {

             var INV_MISC_T_F = document.getElementById("hdn_chk_active_Inv_Misc").value;
             var txt_INV_MISC_Currency = $('#txt_INV_MISC_Currency');
             var txt_INV_MISC_Exch_Rate = $('#txt_INV_MISC_Exch_Rate');
             var chk_add_INV_MISC = $('#chk_add_INV_MISC');
             var txt_INV_MISC_Charges = $('#txt_INV_MISC_Charges');
             var txt_INV_MISC_Total_Charge = $('#txt_INV_MISC_Total_Charge');
             var hdn_INV_MISC_Total_Charge = $('#txt_INV_MISC_Total_Charge');

             txt_INV_MISC_Total_Charge.attr('disabled', true);

             if (INV_MISC_T_F != 'T') {

                 txt_INV_MISC_Currency.attr('disabled', true);
                 txt_INV_MISC_Exch_Rate.attr('disabled', true);
                 chk_add_INV_MISC.attr('disabled', true);
                 txt_INV_MISC_Charges.attr('disabled', true);
                 //txt_INV_MISC_Total_Charge.attr('disabled', true); --hide on 28-08-2020
                 //                 txtInsurance_Charges.attr('disabled', false);
             }
         });


         //-----------------------------------------------------------------------------------------------------------------

         $('#chk_active_Inv_Misc').click(function (e) {
             if (document.getElementById('chk_active_Inv_Misc').checked) {
                 var txt_INV_MISC_Currency = $('#txt_INV_MISC_Currency');
                 var txt_INV_MISC_Exch_Rate = $('#txt_INV_MISC_Exch_Rate');
                 var chk_add_INV_MISC = $('#chk_add_INV_MISC');
                 var txt_INV_MISC_Charges = $('#txt_INV_MISC_Charges');
                 var txt_INV_MISC_Total_Charge = $('#txt_INV_MISC_Total_Charge');
                 var hdn_INV_MISC_Total_Charge = $('#txt_INV_MISC_Total_Charge');

                 txt_INV_MISC_Currency.attr('disabled', false);
                 txt_INV_MISC_Exch_Rate.attr('disabled', false);
                 chk_add_INV_MISC.attr('disabled', false);
                 txt_INV_MISC_Charges.attr('disabled', false);
                 //txt_INV_MISC_Total_Charge.attr('disabled', false);--hide on 28-08-2020

                 $('#txt_INV_MISC_Currency').val($('#txtInvoiceCurrency').val());
                 $('#txt_INV_MISC_Exch_Rate').val($('#txtExRate').val());

                 $('lbl_INV_MISC_Total_Charge_Currency').val($('#txtMiscellaneous_Currency').val());
                 if (txt_INV_MISC_Total_Charge.val() != '') {
                     $("#lbl_INV_MISC_Total_Charge_Currency").show();
                 }
                 else {
                     $("#lbl_INV_MISC_Total_Charge_Currency").hide();
                 }

             }
             else {
                 var txt_INV_MISC_Currency = $('#txt_INV_MISC_Currency');
                 var txt_INV_MISC_Exch_Rate = $('#txt_INV_MISC_Exch_Rate');
                 var chk_add_INV_MISC = $('#chk_add_INV_MISC');
                 var txt_INV_MISC_Charges = $('#txt_INV_MISC_Charges');
                 var txt_INV_MISC_Total_Charge = $('#txt_INV_MISC_Total_Charge');
                 var hdn_INV_MISC_Total_Charge = $('#txt_INV_MISC_Total_Charge');

                 txt_INV_MISC_Currency.attr('disabled', true);
                 txt_INV_MISC_Exch_Rate.attr('disabled', true);
                 chk_add_INV_MISC.attr('disabled', true);
                 txt_INV_MISC_Charges.attr('disabled', true);
                 //                 txt_INV_MISC_Total_Charge.attr('disabled', true);hide on 28-08-2020


                 $("#lbl_INV_MISC_Total_Charge_Currency").hide();


                 $('#txt_INV_MISC_Charges').val('');
                 $('#txt_INV_MISC_Total_Charge').val('');
                 $('#lbl_INV_MISC_Total_Charge_Currency').val('');
             }
         });



         //------------------------Freight higher than standard rate - show alret msg as higher than rate----------------------------------

         $('#txtFreight_Charges').keyup(function () {

             var Transport_mode = $('#hdfTransport_mode').val();
             var txtFreight_Currency = $('#txtFreight_Currency').val();
             var txtFreight_Exch_Rate = $('#txtFreight_Exch_Rate').val();
             var txtFreight_Charges = $('#txtFreight_Charges').val();
             var txtInvoiceCurrency = $('#txtInvoiceCurrency').val();
             var txtExRate = $('#txtExRate').val();

             if (Transport_mode == 'Air') {
                 var txtFreight_Charges = $('#txtFreight_Charges').val();
                 var FRT_actual_amt = '0.00';
                 var Final_inv_val = Get_Invoice_Value();

                 FRT_actual_amt = Final_inv_val * 20 / 100;
                 if (txtInvoiceCurrency != txtFreight_Currency) {

                     txtFreight_Exch_Rate = currncy_convert(txtFreight_Currency, txtFreight_Exch_Rate);
                     txtExRate = currncy_convert(txtInvoiceCurrency, txtExRate);

                     txtFreight_Exch_Rate = txtExRate / txtFreight_Exch_Rate; // Convert Freight Ex.Rate
                     FRT_actual_amt = FRT_actual_amt * txtFreight_Exch_Rate;
                 }
                 //                 alert(txtFreight_Charges);
                 //                 alert(FRT_actual_amt);
                 FRT_actual_amt = parseFloat(FRT_actual_amt).toFixed(2);

                 //                 if (txtFreight_Charges > FRT_actual_amt) {
                 if (parseFloat(txtFreight_Charges) > parseFloat(FRT_actual_amt)) {
                     alert("Freight Amount is Greater than 20%  \n\n  Actual Freight Amount is  :  " + FRT_actual_amt);
                 }
             }
         });

         //------------------------Insurance higher than standard rate - show alret msg as higher than rate----------------------------------
         $('#txtInsurance_Charges').keyup(function () {
             var Transport_mode = $('#hdfTransport_mode').val();
             var txtInsurance_Currency = $('#txtInsurance_Currency').val();
             var txtInsurance_Exch_Rate = $('#txtInsurance_Exch_Rate').val();
             var txtInsurance_Charges = $('#txtInsurance_Charges').val();
             var txtInvoiceCurrency = $('#txtInvoiceCurrency').val();
             var txtExRate = $('#txtExRate').val();

             if (Transport_mode == 'Air') {
                 var txtInsurance_Charges = $('#txtInsurance_Charges').val();
                 var INS_actual_amt = '0.00';
                 var Final_inv_val = Get_Invoice_Value();

                 INS_actual_amt = Final_inv_val * 1.125 / 100;

                 if (txtInvoiceCurrency != txtInsurance_Currency) {

                     txtInsurance_Exch_Rate = currncy_convert(txtInsurance_Currency, txtInsurance_Exch_Rate);
                     txtExRate = currncy_convert(txtInvoiceCurrency, txtExRate);

                     txtInsurance_Exch_Rate = txtExRate / txtInsurance_Exch_Rate; // Convert Insurance Ex.Rate
                     INS_actual_amt = INS_actual_amt * txtInsurance_Exch_Rate;
                 }

                 INS_actual_amt = parseFloat(INS_actual_amt).toFixed(2);

                 //if (txtInsurance_Charges > INS_actual_amt) {
                 if (parseFloat(txtInsurance_Charges) > parseFloat(INS_actual_amt)) {
                     alert("Insurance Amount is Greater than 1.125%  \n\n  Actual Insurance Amount is  :  " + INS_actual_amt);
                 }
             }
         });

         //---------------------------------Miscellaneous_Charges--------------------------------------------------------------------------------
         $('#txtMiscellaneous_Exch_Rate,#txtMiscellaneous_Charges').keyup(function () {
             Get_INV_MISC_Value();
             Get_Freight_Value();
             Get_Insurance_Value();
         });

         $('#txtMiscellaneous_Exch_Rate,#txtMiscellaneous_Charges,#txt_INV_MISC_Charges').focus(function () {
             Get_INV_MISC_Value();
             Get_Freight_Value();
             Get_Insurance_Value();
         });

         //--------------------------------Loading Charges---Added by pandiyan on 17-06-2025----------------------------------
         $('#txtLoading_Charges,#txtLoading_ExchRate').keyup(function () {
             Get_Freight_Value();
             Get_Insurance_Value();
         });
         //---------------------------------Miscellaneous_Charges--------------------------------------------------------------------------------
         $('#txt_INV_MISC_Charges').keyup(function () {
             Get_INV_MISC_Value();
             Get_Freight_Value();
             Get_Insurance_Value();
         });

         //---------------------------------Freight Rate Calc--------------------------------------------------------------------------------
         $('#txtFreight_Exch_Rate,#txtFreight_Rate').keyup(function () {
             Get_Freight_Value();
         });

         //---------------------------------Insurance Rate Calc--------------------------------------------------------------------------------
         $('#txtInsurance_Exch_Rate,#txtInsurance_Rate').keyup(function () {
             Get_Insurance_Value();
         });

//         $('#txtInsurance_Exch_Rate,#txtInsurance_Rate').bind('keyup change focus', function () {
//             Get_Insurance_Value();
//         });

         //------------------------------Get Invoice Value - Function---------------------------------------------------------------------------------
         function Get_Invoice_Value() {

             var Final_inv_val = '0.00';

             var txtInvoiceValue = $('#txtInvoiceValue').val();
             var txtExRate = $('#txtExRate').val();
             var txtInvoiceCurrency = $('#txtInvoiceCurrency').val();

             var txtMiscellaneous_Currency = $('#txtMiscellaneous_Currency').val();
             var txtMiscellaneous_Exch_Rate = $('#txtMiscellaneous_Exch_Rate').val();
             var txtMiscellaneous_Charges = $('#txtMiscellaneous_Charges').val();


             //var INV_MISC_T_F = document.getElementById("chk_active_Inv_Misc").value;
             //var INV_MISC_T_F = document.getElementById("hdn_chk_active_Inv_Misc").value;
             var txt_INV_MISC_Currency = $('#txt_INV_MISC_Currency').val();
             var txt_INV_MISC_Exch_Rate = $('#txt_INV_MISC_Exch_Rate').val();
             var txt_INV_MISC_Charges = $('#txt_INV_MISC_Charges').val();
             var hdn_INV_MISC_Total_Charge = $('#txt_INV_MISC_Total_Charge');

             var txtLoading_Currency = $('#txtLoading_Currency').val();
             var txtLoading_ExchRate = $('#txtLoading_ExchRate').val();
             var txtLoading_Charges = $('#txtLoading_Charges').val();


             //---------------------------------- CI TERMS Only-----------------------------------------
             var Handling_Crg = $('#txt_Handling_Charges').val();
             var Loading_Crg = $('#txt_Loading_Charges').val();
             var UnLoading_Crg = $('#txt_UnLoading_Charges').val();
             var Terms = document.getElementById("ddlTerms").value;

             if (Handling_Crg == '') {
                 Handling_Crg = 0;
             }
             if (Loading_Crg == '') {
                 Loading_Crg = 0;
             }
             if (UnLoading_Crg == '') {
                 UnLoading_Crg = 0;
             }
             var CI_misc = '';
             if (Terms == 'CI') {
                 CI_misc = parseFloat(Handling_Crg) + parseFloat(Loading_Crg) + parseFloat(UnLoading_Crg);
             }
             else {
                 CI_misc = 0;
             }
             //---------------------------------- CI TERMS Only-----------------------------------------


             if (document.getElementById('chk_active_Inv_Misc').checked) {
                 var INV_MISC_T_F = 'T';
             }
             else {
                 var INV_MISC_T_F = 'F';
             }

             var final_MISC = '0.00';
             var MISC_INR = '0.00';
             var INV_MISC_INR = '0.00';
             var INV_MISC_calc = '0.00';
             var final_INV_MISC = '0.00';
             var Loading_INR = '0.00';
             var Loading_Final = '0.00';


             if (txtMiscellaneous_Charges == '') {
                 txtMiscellaneous_Charges = '0.00';
             }
             if (txt_INV_MISC_Charges == '') {
                 txt_INV_MISC_Charges = '0.00';
             }

             if (txtLoading_Charges == '') {
                 txtLoading_Charges = '0.00';
             }
             //---------------------- find MISC + INV_MISC ------------------------------------
             if (INV_MISC_T_F == 'T') {
                 if (txtMiscellaneous_Charges != '0.00') {
                     if (txtMiscellaneous_Currency == txt_INV_MISC_Currency) {
                         final_MISC = parseFloat(txtMiscellaneous_Charges) + parseFloat(txt_INV_MISC_Charges);
                     }
                     else {
                         txtMiscellaneous_Exch_Rate = currncy_convert(txtMiscellaneous_Currency, txtMiscellaneous_Exch_Rate);
                         txt_INV_MISC_Exch_Rate = currncy_convert(txt_INV_MISC_Currency, txt_INV_MISC_Exch_Rate);


                         MISC_INR = txtMiscellaneous_Charges * txtMiscellaneous_Exch_Rate;
                         INV_MISC_INR = txt_INV_MISC_Charges * txt_INV_MISC_Exch_Rate;


                         INV_MISC_calc = parseFloat(MISC_INR) + parseFloat(INV_MISC_INR);

                         final_MISC = INV_MISC_calc / txtMiscellaneous_Exch_Rate;

                     }
                 }
                 else {
                     //get same as Invoice Curr.Ex.Rate -so, no need to convert ex.Rate
                     final_MISC = txt_INV_MISC_Charges;
                 }
             }
             else {
                 final_MISC = txtMiscellaneous_Charges;
             }

             //---------------------- find INVOICE VALUE + MISC + INV_MISC ------------------------------------
             if (txtMiscellaneous_Charges != '0.00') {

                 if (txtInvoiceCurrency == txtMiscellaneous_Currency) {

                     Final_inv_val = parseFloat(txtInvoiceValue) + parseFloat(final_MISC) + parseFloat(CI_misc);

                 }
                 else {

                     txtExRate = currncy_convert(txtInvoiceCurrency, txtExRate);
                     txtMiscellaneous_Exch_Rate = currncy_convert(txtMiscellaneous_Currency, txtMiscellaneous_Exch_Rate);

                     INV_INR = txtInvoiceValue * txtExRate;
                     MISC_INR = final_MISC * txtMiscellaneous_Exch_Rate;

                     INV_MISC_calc = parseFloat(INV_INR) + parseFloat(MISC_INR);
                     Final_inv_val = INV_MISC_calc / txtExRate;
                     Final_inv_val = Final_inv_val + parseFloat(CI_misc);
                 }
             }
   
             else {
                 Final_inv_val = parseFloat(txtInvoiceValue) + parseFloat(final_MISC) + parseFloat(CI_misc);
             }
             //-----------------------Loading calc--------Added by pandiyan & chitra on 19-06-2025 for loading charges adding in the inv val --------
             if (txtLoading_Charges != '0.00' && txtLoading_Charges != '' && txtLoading_Charges != null) {
                 if (txtInvoiceCurrency == txtLoading_Currency) {
                     Final_inv_val = parseFloat(Final_inv_val) + parseFloat(txtLoading_Charges);
                 }
                 else {
                     txtExRate = currncy_convert(txtInvoiceCurrency, txtExRate);
                     txtLoading_ExchRate = currncy_convert(txtLoading_Currency, txtLoading_ExchRate);

                     INV_INR = Final_inv_val * txtExRate;
                     Loading_INR = txtLoading_Charges * txtLoading_ExchRate;

                     Loading_Final = parseFloat(INV_INR) + parseFloat(Loading_INR);
                     Final_inv_val = Loading_Final / txtExRate;
                 }
             }
             return Final_inv_val;
         }
         //-------------------------- Get Freight Rate ---------------------------

         function Get_Freight_Value() {

             var txtFreight_Rate = $('#txtFreight_Rate').val();

             if (parseFloat(txtFreight_Rate) > 0) {
                 var txtFreight_Currency = $('#txtFreight_Currency').val();
                 var txtFreight_Exch_Rate = $('#txtFreight_Exch_Rate').val();
                 var txtInvoiceCurrency = $('#txtInvoiceCurrency').val();
                 var txtExRate = $('#txtExRate').val();
                 var FRT_actual_amt = '0.00';

                 var Final_inv_val = Get_Invoice_Value(); //  alert(Get_Invoice_Value());
                                 //alert(Final_inv_val);
                 FRT_actual_amt = Final_inv_val * txtFreight_Rate / 100;

                 //if (txtInvoiceCurrency != txtFreight_Currency) {// this condition hide for convert to as per FRT. Ex.rate

                     txtFreight_Exch_Rate = currncy_convert(txtFreight_Currency, txtFreight_Exch_Rate);
                     txtExRate = currncy_convert(txtInvoiceCurrency, txtExRate);

                     txtFreight_Exch_Rate = txtExRate / txtFreight_Exch_Rate; // Convert Freight Ex.Rate
                     FRT_actual_amt = FRT_actual_amt * txtFreight_Exch_Rate;


//                 }
//                     else {                       
//                     txtFreight_Exch_Rate = currncy_convert(txtFreight_Currency, txtFreight_Exch_Rate);   //its for while change the FRT.Ex.Rate should calc for that value               
//                     FRT_actual_amt = FRT_actual_amt * txtFreight_Exch_Rate;
                     //                 }


                 $('#txtFreight_Charges').val(parseFloat(FRT_actual_amt).toFixed(2));
             }
         }

         //--------------------------- Get Insurance Calc-------------------------------------------------

         function Get_Insurance_Value() {
             var txtInsurance_Rate = $('#txtInsurance_Rate').val();

             if (parseFloat(txtInsurance_Rate) > 0) {
                 var txtInsurance_Currency = $('#txtInsurance_Currency').val();
                 var txtInsurance_Exch_Rate = $('#txtInsurance_Exch_Rate').val();
                 var txtInvoiceCurrency = $('#txtInvoiceCurrency').val();
                 var txtExRate = $('#txtExRate').val();
                 var INS_actual_amt = '0.00';

                 var Final_inv_val = Get_Invoice_Value(); //  alert(Get_Invoice_Value());
                
                 INS_actual_amt = Final_inv_val * txtInsurance_Rate / 100;

//                 if (txtInvoiceCurrency != txtInsurance_Currency) { // this condition hide for convert to as per INSU. Ex.rate

                     txtInsurance_Exch_Rate = currncy_convert(txtInsurance_Currency, txtInsurance_Exch_Rate);
                     txtExRate = currncy_convert(txtInvoiceCurrency, txtExRate);

                     txtInsurance_Exch_Rate = txtExRate / txtInsurance_Exch_Rate; // Convert Insurance Ex.Rate
                     INS_actual_amt = INS_actual_amt * txtInsurance_Exch_Rate;
                    // alert('ghgfhf');

//                 }
//                 else {
//                     txtInsurance_Exch_Rate = currncy_convert(txtInsurance_Currency, txtInsurance_Exch_Rate);//its for while change the INSU.Ex.Rate should calc for that value                 
//                     INS_actual_amt = INS_actual_amt * txtInsurance_Exch_Rate;
//                 }
                     

                 $('#txtInsurance_Charges').val(parseFloat(INS_actual_amt).toFixed(2));
             }
         }


         //--------------------------- Get INV_MISC Calc-------------------------------------------------

         function Get_INV_MISC_Value() {

             if (document.getElementById('chk_active_Inv_Misc').checked) {
                 var INV_MISC_T_F = 'T';
             }
             else {
                 var INV_MISC_T_F = 'F';
             }


             if (INV_MISC_T_F == 'T') {
                 var txtMiscellaneous_Currency = $('#txtMiscellaneous_Currency').val();
                 var txtMiscellaneous_Exch_Rate = $('#txtMiscellaneous_Exch_Rate').val();
                 var txtMiscellaneous_Charges = $('#txtMiscellaneous_Charges').val();

                 var txt_INV_MISC_Currency = $('#txt_INV_MISC_Currency').val();
                 var txt_INV_MISC_Exch_Rate = $('#txt_INV_MISC_Exch_Rate').val();
                 var txt_INV_MISC_Charges = $('#txt_INV_MISC_Charges').val();

                 var misc_currency1 = '';
                 misc_currency1 = $('#lbl_INV_MISC_Total_Charge_Currency').val();

                 //             alert(currncy_convert(txt_INV_MISC_Currency, txt_INV_MISC_Exch_Rate));
                 //             $('lbl_INV_MISC_Total_Charge_Currency').val('hhj');

                 //$('lbl_INV_MISC_Total_Charge_Currency').val($('#txtMiscellaneous_Currency').val());
                 if ($('#txt_INV_MISC_Total_Charge').val() != '') {
                     $("#lbl_INV_MISC_Total_Charge_Currency").show();
                     //                 alert($('#lbl_INV_MISC_Total_Charge_Currency').val());
                 }

                 var final_MISC = '0.00';
                 var MISC_INR = '0.00';
                 var INV_MISC_INR = '0.00';
                 var INV_MISC_calc = '0.00';
                 var final_INV_MISC = '0.00';

                 if (txtMiscellaneous_Charges == '') {
                     txtMiscellaneous_Charges = '0.00';
                 }
                 if (txt_INV_MISC_Charges == '') {
                     txt_INV_MISC_Charges = '0.00';
                 }

                 if (txtMiscellaneous_Currency == txt_INV_MISC_Currency) {
                     final_MISC = parseFloat(txtMiscellaneous_Charges) + parseFloat(txt_INV_MISC_Charges);
                 }
                 else {
                     txtMiscellaneous_Exch_Rate = currncy_convert(txtMiscellaneous_Currency, txtMiscellaneous_Exch_Rate);
                     txt_INV_MISC_Exch_Rate = currncy_convert(txt_INV_MISC_Currency, txt_INV_MISC_Exch_Rate);

                     MISC_INR = txtMiscellaneous_Charges * txtMiscellaneous_Exch_Rate;
                     INV_MISC_INR = txt_INV_MISC_Charges * txt_INV_MISC_Exch_Rate;

                     INV_MISC_calc = parseFloat(MISC_INR) + parseFloat(INV_MISC_INR);

                     final_MISC = INV_MISC_calc / txtMiscellaneous_Exch_Rate;

                 }

                 $('#hdn_INV_MISC_Total_Charge').val(parseFloat(final_MISC).toFixed(2));
                 $('#txt_INV_MISC_Total_Charge').val(parseFloat(final_MISC).toFixed(2));
             }
         }

         //-----------------------------Get Exchage Rate------------------------------------------------------------------------------------
         function currncy_convert(curr, exrate) {
             var result = 0.00;
             if (curr == 'JPY' || curr == 'KRW') {
                 result = parseFloat(exrate) / 100;
             }
             else {
                 result = exrate;
             }
             return result;
         }

         //-----------------------------------------------------------------------------------------------------------------
</script>



<script type="text/javascript">
    function IMP_MultiSplit() {
        NewWindow1('../Transaction/Multiple_Inv_Split.aspx', 'List', '1100', '424', 'yes');
    }

    function IMP_MultiSplit_XBE() {
        NewWindow1('../Transaction/Multiple_Inv_Split_XBE.aspx', 'List', '1150', '424', 'yes');
    }

    function Open_Amend_Flatfile() {
        var amd_type = document.getElementById("ddl_AmendmentType").value;
        var amd_page = 'INVOICE';
        var amd_Jobno = document.getElementById("hdn_Jobno").value;
        var amd_Invslno = document.getElementById("ddlInv_SL_No").value;
       // alert(amd_Invslno);

        NewWindow1('../Amendment/Import_Amendment.aspx?amd_type=' + amd_type + '&amd_page=' + amd_page + '&amd_Jobno=' + amd_Jobno + '&amd_Invslno=' + amd_Invslno, 'List', '950', '515', 'yes');
    }

    function MasUpdate() {
        alert('s');
    }
</script>
<script type="text/javascript">

    function validateDate() {
        var txtDate = document.getElementById('<%= txtDate.ClientID %>').value;
        if (txtDate != null) {
            var today = new Date();
            var parts = txtDate.split('/');
            var SelectDate = new Date(parts[2], parts[1] - 1, parts[0]);
            today.setHours(0, 0, 0, 0);
            if (SelectDate > today) {
                jAlert("Invoice date should not greater than current date!");
                document.getElementById('<%= txtDate.ClientID %>').focus();
                return false;
            }
        }
        return true;
    }
</script>


</body>
</html>
