function tab_page1(val) {
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';

    document.getElementById("FRIEGHT_ID").className = 'inactive';
    document.getElementById('hdn_Inner_tab_Menu').value = 'INVOICE_ID';

}
function tab_page2(val) {
    Parent_tab_count('');
    
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'FRIEGHT_ID';

}
function tab_page3(val) {
    Parent_tab_count('');
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';

    var INV_NO = document.getElementById("txtInvoiceNo").value;
    var INV_SLNO = document.getElementById("hdn_inv_slno").value;

    

//    document.getElementById("Trans_product_reimport_iframe").src = "../Export/Export_AR4Details.aspx?INV_NO=" + INV_NO + "&INV_SLNO=" + INV_SLNO + "";
    document.getElementById("Trans_product_reimport_iframe").src = '../Export/Export_AR4Details.aspx?INV_NO=' + encodeURIComponent(INV_NO) + '&INV_SLNO=' + INV_SLNO + '';

    document.getElementById("page-3").style.display = 'Block';
    document.getElementById("page-4").style.display = 'none';
}
function tab_page4(val) {
    Parent_tab_count('');
  
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'Block';

    document.getElementById('hdn_Inner_tab_Menu').value = 'Third_Party';
}


function tab_page5(val) {
    Parent_tab_count('');
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';

    var INV_NO = document.getElementById("txtInvoiceNo").value;
    var INV_SLNO = document.getElementById("hdn_inv_slno").value;

    document.getElementById("Trans_product_DTA_Invoice_iframe").src = '../Export_DTA_SEZ/Export_DTA_Invoice.aspx?INV_NO=' + encodeURIComponent(INV_NO) + '&INV_SLNO=' + INV_SLNO + '';
   
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'Block';

}




$('#txtInsurance_Rate,#txtInsurance_Currency').bind('keyup change focus', function () {

    var ddlTerms = document.getElementById("ddlTerms").value;
    var invoice_val = document.getElementById("txtInvoiceValue").value;
    var ins_rate = document.getElementById("txtInsurance_Rate").value;
    var ins_curr = document.getElementById("txtInsurance_Currency").value;
    var inv_Exrate = document.getElementById("txtExchangeRate").value;

    if (ddlTerms == 'CIF' || ddlTerms == 'CI') {

        if (document.getElementById("txtInvoiceValue").value >= 0) {
            if (document.getElementById("txtInsurance_Rate").value > 0) {
                var ins_charges = invoice_val * ins_rate / 100;
                if (ins_curr == 'INR') {
                    ins_charges = ins_charges * inv_Exrate;
                }
                var result = roundNumber(ins_charges, 2);
                document.getElementById("txtInsurance_Charges").value = result;

                return false;
            }
            else {
               // document.getElementById("txtInsurance_Charges").value = '0.00';
            }
        }
    }
});

$('#txtFreight_Rate, #txtFreight_Currency').bind('keyup change focus', function () {

    var ddlTerms = document.getElementById('ddlTerms').value;
    var _companyId = document.getElementById('hdn_CompanyID').value;
    if (_companyId != "3267") {
        return false;
    }
    var _invoiceValue = document.getElementById('txtInvoiceValue').value;
    var _freightRate = document.getElementById('txtFreight_Rate').value;
    var _freightCurrency = document.getElementById('txtFreight_Currency').value;
    var _exchangeRate = document.getElementById('txtExchangeRate').value;

    if (ddlTerms == "CIF" || ddlTerms == "CF") {
        if (_invoiceValue >= 0) {
            if (_freightRate > 0) {
                var FreightCharges = _invoiceValue * _freightRate / 100;

                if (_freightCurrency == "INR") {
                    FreightCharges = FreightCharges * _exchangeRate
                }
                var result = roundNumber(FreightCharges, 2);
                document.getElementById('txtFreight_Charges').value = result;
                return false;
            }
        }
    }
})

$('#txtCommission_Rate').bind('keyup change focus', function () {

    var invoice_val = document.getElementById("txtInvoiceValue").value;
    var ins_rate = document.getElementById("txtCommission_Rate").value;
    var com_charges = document.getElementById("txtCommission_Charges").value;

    if (document.getElementById("txtInvoiceValue").value >= 0) {
        if (document.getElementById("txtCommission_Rate").value > 0) {
            var ins_charges = invoice_val * ins_rate / 100;
            var result = roundNumber(ins_charges, 2);
            document.getElementById("txtCommission_Charges").value = result;

            return false;
        }
        else {
            if (com_charges == 0) {
                document.getElementById("txtCommission_Charges").value = '';
            }
        }
    }
});

$('#txtFOBDisc_Rate').bind('keyup change focus', function () {

    var invoice_val = document.getElementById("txtInvoiceValue").value;
    var disc_rate = document.getElementById("txtFOBDisc_Rate").value;
    var disc_charge = document.getElementById("txtFOBDisc_Charges").value;

    if (invoice_val >= 0) {
        if (disc_rate > 0) {
            var disc_charges = invoice_val * disc_rate / 100;
            var result = roundNumber(disc_charges, 2);
            document.getElementById("txtFOBDisc_Charges").value = result;

            return false;
        }
        else {
            if (disc_charge == 0) {
                document.getElementById("txtFOBDisc_Charges").value = '';
            }
        }
    }
});

function validate_Invoice() {

    /* hide on 26-02-2022 by Chithra for Invoice No: 0E2021000487 not accepting - will check later
    if (document.getElementById("txtInvoiceNo").value <= 0) {
    jAlert('Invoice no cannot be blank', 'INVOICE', function (r) {
    document.getElementById("INVOICE_ID").click();
    document.getElementById("txtInvoiceNo").focus();
    });
    return false;

    }
    */

    var Invno = document.getElementById("txtInvoiceNo").value;
    if (Invno.length < 1) {
        jAlert('Invoice no cannot be blank', 'INVOICE', function (r) {
            document.getElementById("INVOICE_ID").click();
            document.getElementById("txtInvoiceNo").focus();
        });
        return false;
    }
    
    if (document.getElementById("txtInvoiceDate").value <= 0) {
    jAlert('Invoice date cannot be blank', 'INVOICE', function (r) {
    document.getElementById("INVOICE_ID").click();
    document.getElementById("txtInvoiceDate").focus();
    });
    return false;
    }
   

    if (isDate(document.getElementById("txtInvoiceDate").value)) {

    }
    else {
        jAlert('Invoice Date is Invalid Date', 'INVOICE', function (r) {
            document.getElementById("INVOICE_ID").click();
            document.getElementById("txtInvoiceDate").focus();
        });

        return false;
    }

    var Invoicevalue = document.getElementById("txtInvoiceValue").value;
    if (Invoicevalue.length <= 0) {
        jAlert('Invoice value cannot be blank', 'INVOICE', function (r) {
            document.getElementById("INVOICE_ID").click();
            document.getElementById("txtInvoiceValue").focus();
        });

        return false;
    }

    if (document.getElementById("txtInvoiceCurrency").value <= 0) {
        jAlert('Invoice currency cannot be blank', 'INVOICE', function (r) {
            document.getElementById("INVOICE_ID").click();
            document.getElementById("txtInvoiceCurrency").focus();
        });

        return false;
    }

    var InvoiceCurrency = document.getElementById("txtInvoiceCurrency").value;
    if (InvoiceCurrency.length < 3) {
        jAlert('Invoice currency should be 3 characters', 'INVOICE', function (r) {
            document.getElementById("INVOICE_ID").click();
            document.getElementById("txtInvoiceCurrency").focus();
        });

        return false;
    }
    if (document.getElementById("txtBuyerName").value <= 0) {
        jAlert('Buyer Name cannot be blank', 'INVOICE', function (r) {
            document.getElementById("INVOICE_ID").click();
            document.getElementById("txtBuyerName").focus();
        });

        return false;
    }
    if (document.getElementById("txtBuyerName").value == 'SAME AS CONSIGNEE') {

    }
    else {
        if (document.getElementById("txtAddress").value <= 0) {
            jAlert('Address cannot be blank', 'INVOICE', function (r) {
                document.getElementById("INVOICE_ID").click();
                document.getElementById("txtAddress").focus();
            });

            return false;
        }
    }
    //page-2


    var ddlTerms = document.getElementById("ddlTerms").value;

    if (ddlTerms == '') {
        jAlert('select Invoice Terms', 'INVOICE', function (r) {
            document.getElementById("INVOICE_ID").click();
            document.getElementById("ddlTerms").focus();
        });

        return false;

    }
    if (ddlTerms == 'FOB') {
        if (document.getElementById("ddlWhether").value == "B" || document.getElementById("ddlWhether").value == "F" || document.getElementById("ddlWhether").value == "I") {
            jAlert('Select None(N)', 'Whether the Unit Price Includes Wrong', function (r) {
                document.getElementById("FRIEGHT_ID").click();
                document.getElementById("ddlWhether").focus();
            });

            return false;
        }
    }


    if (ddlTerms == 'CIF') {

    /* HIDE BY CHITHRA ON 22-05-2018 FOR LIZMA- BALA SIR TOLD DISABLE THE FREIGHT RATE 
        if (document.getElementById("txtFreight_Rate").value <= 0) {
            if (document.getElementById("txtFreight_Charges").value <= 0) {
                jAlert('Freight Rate cannot be blank', 'INVOICE', function (r) {
                    document.getElementById("FRIEGHT_ID").click();
                    document.getElementById("txtFreight_Rate").focus();
                });

                return false;
            }
        }
        */

        if (document.getElementById("txtFreight_Charges").value <= 0) {
                jAlert('Freight Charges cannot be blank', 'INVOICE', function (r) {
                    document.getElementById("FRIEGHT_ID").click();
                    document.getElementById("txtFreight_Charges").focus();
                });

                return false;
            }
     
       
        if (document.getElementById("txtFreight_Currency").value <= 0) {
            jAlert('Freight Currency cannot be blank', 'INVOICE', function (r) {
                document.getElementById("FRIEGHT_ID").click();
                document.getElementById("txtFreight_Currency").focus();
            });

            return false;
        }
        if (document.getElementById("txtInsurance_Rate").value <= 0) {
            if (document.getElementById("txtInsurance_Charges").value <= 0) {
                jAlert('Insurance Rate cannot be blank', 'INVOICE', function (r) {
                    document.getElementById("FRIEGHT_ID").click();
                    document.getElementById("txtInsurance_Rate").focus();
                });

                return false;
            }

        }
        if (document.getElementById("txtInsurance_Currency").value <= 0) {
            jAlert('Insurance Currency cannot be blank', 'INVOICE', function (r) {
                document.getElementById("FRIEGHT_ID").click();
                document.getElementById("txtInsurance_Currency").focus();
            });

            return false;
        }
        if (document.getElementById("ddlWhether").value == "F" || document.getElementById("ddlWhether").value == "I") {
            jAlert('Select None(N) or Both (B)', 'Whether the Unit Price Includes Wrong ', function (r) {
                document.getElementById("FRIEGHT_ID").click();
                document.getElementById("ddlWhether").focus();
            });

            return false;
        }
    }

    if (ddlTerms == 'CF') {

    /*  HIDE BY CHITHRA ON 22-05-2018 -FOR LIZMA - BALA SIR TOLD DISABLE THE FREIGHT RATE
        if (document.getElementById("txtFreight_Rate").value <= 0) {
            if (document.getElementById("txtFreight_Charges").value <= 0) {
                jAlert('Freight Rate cannot be blank', 'INVOICE', function (r) {
                    document.getElementById("FRIEGHT_ID").click();
                    document.getElementById("txtFreight_Rate").focus();
                });

                return false;
            }
        }
     */
        

        if (document.getElementById("txtFreight_Charges").value <= 0) {
            jAlert('Freight Charges cannot be blank', 'INVOICE', function (r) {
                document.getElementById("FRIEGHT_ID").click();
                document.getElementById("txtFreight_Charges").focus();
            });

            return false;
        }

        if (document.getElementById("txtFreight_Currency").value <= 0) {
            jAlert('Freight Currency cannot be blank', 'INVOICE', function (r) {
                document.getElementById("FRIEGHT_ID").click();
                document.getElementById("txtFreight_Currency").focus();
            });

            return false;
        }
        if (document.getElementById("ddlWhether").value == "B" || document.getElementById("ddlWhether").value == "I") {
            jAlert('Select None(N) or Frieght (F)', 'Whether the Unit Price Includes Wrong', function (r) {
                document.getElementById("FRIEGHT_ID").click();
                document.getElementById("ddlWhether").focus();
            });

            return false;
        }
    }

    if (ddlTerms == 'CI') {

        if (document.getElementById("txtInsurance_Rate").value <= 0) {
            if (document.getElementById("txtInsurance_Charges").value <= 0) {
                jAlert('Insurance Rate cannot be blank', 'INVOICE', function (r) {
                    document.getElementById("FRIEGHT_ID").click();
                    document.getElementById("txtInsurance_Rate").focus();
                });

                return false;
            }

        }
        if (document.getElementById("txtInsurance_Currency").value <= 0) {
            jAlert('Insurance Currency cannot be blank', 'INVOICE', function (r) {
                document.getElementById("FRIEGHT_ID").click();
                document.getElementById("txtInsurance_Currency").focus();
            });

            return false;
        }
        if (document.getElementById("ddlWhether").value == "B" || document.getElementById("ddlWhether").value == "F") {
            jAlert('Select None(N) or Insurance (I)', 'Whether the Unit Price Includes Wrong', function (r) {
                document.getElementById("FRIEGHT_ID").click();
                document.getElementById("ddlWhether").focus();
            });

            return false;
        }
    }
}
$(function () {

    var textbox = $('#txtFreight_Rate');
    var ResultTextbox = $('#txtFreight_Charges');
    var PriceTextbox = $('#txtInvoiceValue');
    var txtInsurance_Charges = $('#txtInsurance_Charges');
    var txtInsurance_Rate = $('#txtInsurance_Rate');
    var txtFreight_Charges = $('# txtFreight_Charges');
    var txtFreight_Currency = $('# txtFreight_Currency');

    var txtFreight_Rate = $('#txtFreight_Rate');
    var ddlTerms = $('#ddlTerms');
    var ddlTerm = ddlTerms.val();

    var txtInsurance_Charges = $('#txtInsurance_Charges');
    var txtInsurance_Currency = $('#txtInsurance_Currency');

    var txtInsurance_Rate = $('#txtInsurance_Rate');


    $('#txtInvoiceValue').keyup(function () {

        $('#lblInvoiceValue').text($(this).val());
    });
    $('#txtInvoiceCurrency').keyup(function () {
        $('#lblInvoiceCurrency').text($(this).val().toUpperCase());
    });
    $('#ddlTerms').change(function () {
        $('#lblInvoiceTerms').text($(this).val());
    });
    $('#txtInvoiceNo').keyup(function () {
        $('#lblInvoiceNo').text($(this).val());
    });
    $('#txtInvoiceDate').keyup(function () {
        $('#lblInvoiceDate').text($(this).val());
    });


    $('#txtInvoiceDate').change(function () {
        $('#lblInvoiceDate').text($(this).val());
    });
});

function clear() {

    var txtFreight_Charges = $('#txtFreight_Charges');
    var txtFreight_Currency = $('#txtFreight_Currency');

    var txtFreight_Rate = $('#txtFreight_Rate');

    var txtInsurance_Charges = $('#txtInsurance_Charges');
    var txtInsurance_Currency = $('#txtInsurance_Currency');

    var txtInsurance_Rate = $('#txtInsurance_Rate');
    txtFreight_Charges.val("");
    txtFreight_Currency.val("");

    txtFreight_Rate.val("");
    txtInsurance_Charges.val("");
    txtInsurance_Currency.val("");

    txtInsurance_Rate.val("");
}

function disabled_true() {

    var txtFreight_Charges = $('#txtFreight_Charges');
    var txtFreight_Currency = $('#txtFreight_Currency');

    var txtFreight_Rate = $('#txtFreight_Rate');

    var txtInsurance_Charges = $('#txtInsurance_Charges');
    var txtInsurance_Currency = $('#txtInsurance_Currency');

    var txtInsurance_Rate = $('#txtInsurance_Rate');
    var _companyId = document.getElementById('hdn_CompanyID').value;
    clear();
    txtFreight_Charges.attr('disabled', false);
    txtFreight_Currency.attr('disabled', false);

    //txtFreight_Rate.attr('disabled', true);
    if (_companyId == "3267") {
        txtFreight_Rate.attr('disabled', false);
    }
    else {

        txtFreight_Rate.attr('disabled', true);
    }

    txtInsurance_Charges.attr('disabled', false);

    txtInsurance_Currency.attr('disabled', false);


    txtInsurance_Rate.attr('disabled', false);
}



$(function () {


    var dropDownList1 = $('#ddlTerms');
    var txtFreight_Charges = $('#txtFreight_Charges');
    var txtFreight_Currency = $('#txtFreight_Currency');

    var txtFreight_Rate = $('#txtFreight_Rate');
    var ImageButton10 = $('#img_btn_Frieght');
    var ImageButton11 = $('#img_btn_Insurance');



    var txtInsurance_Charges = $('#txtInsurance_Charges');
    var txtInsurance_Currency = $('#txtInsurance_Currency');
    var txtInsurance_Rate = $('#txtInsurance_Rate');
    var txtCommission_Currency = $('#txtCommission_Currency');
    var txtFOBDisc_Currency = $('#txtFOBDisc_Currency');
    var txtPackMisc_Currency = $('#txtPackMisc_Currency');
    var txtOtherDeductions_Currency = $('#txtOtherDeductions_Currency');
    var _companyId = document.getElementById('hdn_CompanyID').value;
    dropDownList1.change(function (e) {
        var selectedValue = $(this).val();
        jQuery('#form1').validationEngine('detach');
        var hdn_currency = document.getElementById("txtInvoiceCurrency").value;

        if (selectedValue == '') {

            disabled_true();

            jAlert('Terms Cannot be empty', 'INVOICE', function (r) {
                document.getElementById("INVOICE_ID").click();
                document.getElementById("ddlTerms").focus();
            });

        }
        else if (selectedValue == 'FOB') {

            clear();
            ImageButton10.attr('disabled', false);
            ImageButton11.attr('disabled', false);

            txtFreight_Charges.attr('disabled', true);
            txtFreight_Currency.attr('disabled', true);

            txtFreight_Rate.attr('disabled', true);

            txtInsurance_Charges.attr('disabled', true);

            txtInsurance_Currency.attr('disabled', true);

            txtInsurance_Rate.attr('disabled', true);
            txtFreight_Charges.val("");
            txtInsurance_Charges.val("");
            txtInsurance_Rate.val("");

            if (hdn_currency != '') {

                txtFreight_Currency.val('');
                txtInsurance_Currency.val('');

            }
        }
        else if (selectedValue == 'CI') {

            clear();
            ImageButton10.attr('disabled', true);
            ImageButton11.attr('disabled', false);
            txtFreight_Charges.attr('disabled', true);
            txtFreight_Currency.attr('disabled', true);

            txtFreight_Rate.attr('disabled', true);

            txtInsurance_Charges.attr('disabled', false);

            txtInsurance_Currency.attr('disabled', false);


            txtInsurance_Rate.attr('disabled', false);
            txtFreight_Charges.val("");
            txtInsurance_Charges.val("");
            txtInsurance_Rate.val("");
            if (hdn_currency != '') {

                txtFreight_Currency.val('');
                txtInsurance_Currency.val(hdn_currency);

            }
        }
        else if (selectedValue == 'CF') {
            clear();
            ImageButton10.attr('disabled', false);
            ImageButton11.attr('disabled', true);
            txtFreight_Charges.attr('disabled', false);
            txtFreight_Currency.attr('disabled', false);
            if (_companyId == "3267") {
                txtFreight_Rate.attr('disabled', false);
            }
            else {

                txtFreight_Rate.attr('disabled', true);
            }

            txtInsurance_Charges.attr('disabled', true);

            txtInsurance_Currency.attr('disabled', true);

            txtInsurance_Rate.attr('disabled', true);
            txtFreight_Charges.val("");
            txtInsurance_Charges.val("");
            txtInsurance_Rate.val("");
            if (hdn_currency != '') {

                txtFreight_Currency.val(hdn_currency);
                txtInsurance_Currency.val('');

            }
        }
        else if (selectedValue == 'CIF') {

            ImageButton10.attr('disabled', false);
            ImageButton11.attr('disabled', false);
            disabled_true();
            txtFreight_Charges.val("");
            txtInsurance_Charges.val("");
            txtInsurance_Rate.val("");
            txtFreight_Currency.val(hdn_currency);
            txtInsurance_Currency.val(hdn_currency);
        }
        else {

            ImageButton10.attr('disabled', true);
            ImageButton11.attr('disabled', true);
            disabled_true();

        }
        document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExchangeRate").value;
        document.getElementById("hdn_Freight_Exrate").value = document.getElementById("txtExchangeRate").value;
        document.getElementById("hdn_Insurance_Exrate").value = document.getElementById("txtExchangeRate").value;
    });



});

$(function () {

    var ddlBuyer = $('#ddlBuyer');

    ddlBuyer.change(function (e) {
        var selectedValue = $(this).val();

        if (selectedValue == 'Yes') {
            $('#txtBuyerName').attr('readonly', true);
            document.getElementById("txtBuyerName").value = 'SAME AS CONSIGNEE';
            document.getElementById("txtAddress").value = '';
            document.getElementById("txtAddress1").value = '';
            document.getElementById("txtAddress2").value = '';
            document.getElementById("txtAddress3").value = '';
            document.getElementById("txtAddress4").value = '';
            document.getElementById("href_Buyer_YN").style.display = 'none';
            //document.getElementById("href_Buyer_YN_New").style.display = 'none';
            document.getElementById("btn_BuyerMasedit").style.display = 'none';

            //                    document.getElementById("txtBuyerName").value = document.getElementById("hdn_Consignee_Name").value;
            //                    document.getElementById("txtAddress").value = document.getElementById("hdn_Consignee_Address1").value;
            //                    document.getElementById("txtAddress1").value = document.getElementById("hdn_Consignee_Address2").value;
            //                    document.getElementById("txtAddress2").value = document.getElementById("hdn_Consignee_Address3").value;
            //                    document.getElementById("txtAddress3").value = document.getElementById("hdn_Consignee_Address4").value;
            //                    document.getElementById("txtAddress4").value = document.getElementById("hdn_Consignee_Address5").value;
        }
        else if (selectedValue == 'No') {
            $('#txtBuyerName').attr('readonly', false);
            document.getElementById("txtBuyerName").value = '';
            document.getElementById("txtAddress").value = '';
            document.getElementById("txtAddress1").value = '';
            document.getElementById("txtAddress2").value = '';
            document.getElementById("txtAddress3").value = '';
            document.getElementById("txtAddress4").value = '';
            document.getElementById("href_Buyer_YN").style.display = 'block';
            document.getElementById("hdn_ddlBuyer").value = 'No';
            document.getElementById("btn_BuyerMasedit").style.display = 'block';
            
            var byer_edt = document.getElementById("hdn_buyer_edit").value;
            if (byer_edt == 'E') {
                $('#txtAddress').attr('readonly', false);
                $('#txtAddress1').attr('readonly', false);
                $('#txtAddress2').attr('readonly', false);
                $('#txtAddress3').attr('readonly', false);
                $('#txtAddress4').attr('readonly', false);
            }
        }
    });
});

function OpenPopupExchange_Master_Frieght(val) {
    var Values1 = $('#ddlTerms').val();

    if (Values1 == 'CIF') {
        OpenPopupExchange(val);
        return false;
    }
    else if (Values1 == 'CF') {
        OpenPopupExchange(val);
        return false;
    }
    else if (Values1 == '') {
    }

    jQuery('#form1').validationEngine('detach');

}
function OpenPopupExchange_Master_Insurance(val) {

    var Values1 = $('#ddlTerms').val();

    if (Values1 == 'CIF') {
        OpenPopupExchange(val);
        return false;
    }
    else if (Values1 == 'CI') {
        OpenPopupExchange(val);
        return false;
    }
    else if (Values1 == '') {
    }
    jQuery('#form1').validationEngine('detach');
}

$(function () {
    $('#txtInvoiceCurrency,#txtCommission_Currency,#txtFOBDisc_Currency,#txtPackMisc_Currency,#txtOtherDeductions_Currency,#txtFreight_Currency,#txtInsurance_Currency').autocomplete({
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
                        if (field == 'txtInvoiceCurrency') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Invoice Currency', 'error', 'topRight', true);

                            //jAlert('Invoice Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtCommission_Currency') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Commission Currency', 'error', 'topRight', true);

                            //jAlert('Commission Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtFOBDisc_Currency') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect FOBDisc Currency', 'error', 'topRight', true);

                            //jAlert('FOBDisc Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtPackMisc_Currency') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect PackMisc Currency', 'error', 'topRight', true);

                            //jAlert('PackMisc Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtOtherDeductions_Currency') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Other Deductions Currency', 'error', 'topRight', true);

                            //jAlert('Other Deductions Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtFreight_Currency') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Freight Currency', 'error', 'topRight', true);

                            //jAlert('Freight Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtInsurance_Currency') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Insurance Currency', 'error', 'topRight', true);

                            //jAlert('Insurance Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;

                        }
                    }
                    else {

                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);

                        var result = data.d;

                        var stringsearch = "-", str = result;

                        for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                        if (i == 1) {
                            if (field == 'txtInvoiceCurrency') {
                                $('#txtInvoiceCurrency').val(result);
                            }

                            if (field == 'txtFreight_Currency') {
                                $('#txtFreight_Currency').val(result);
                            }

                            if (field == 'txtInsurance_Currency') {
                                $('#txtInsurance_Currency').val(result);
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


function CallServerside_Consignee(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    if (ctrl.value != 'SAME AS CONSIGNEE') {
        
        //PageMethods.Get_ConsigneeName(ctrl.value, CallSuccess_consignee, CallFailed, dest);
        PageMethods.Get_BuyerName(ctrl.value, CallSuccess_consignee, CallFailed, dest);
    }
}
function CallSuccess_consignee(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];

        document.getElementById("txtBuyerName").value = before;
        document.getElementById("txtAddress").value = after1;
        document.getElementById("txtAddress1").value = after2;
        document.getElementById("txtAddress2").value = after3;
        document.getElementById("txtAddress3").value = after4;
        document.getElementById("txtAddress4").value = after5;


    }
    else {
        //document.getElementById("txtBuyerName").value = "";
        document.getElementById("txtAddress").value = "";
        document.getElementById("txtAddress1").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
    }

}


function CallServerside_Get_DuplicateInvoice_No(src, dest) {
    var ctrl = document.getElementById(src);
    var destl = document.getElementById(dest);
    PageMethods.Get_Duplicate_InvoiceNo(ctrl.value, dest, CallSuccess_Exp_DuplicateInvoice_No, CallFailed, dest);
}

function CallSuccess_Exp_DuplicateInvoice_No(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {
        var s = data.split('~~');
        var jobno = s[0];

        alert('Invoice No Already Exists! - JobNumber : ' + jobno);
    }
    else {
//        alert('b'); 
    }
}

function CallServerside_GetThirdParty(src, dest) {
    var ctrl = document.getElementById(src);
    PageMethods.Get_Exp_ThirdParty(ctrl.value, CallSuccess_Exp_ThirdParty, CallFailed, dest);
}
function CallSuccess_Exp_ThirdParty(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];
        var after6 = s[6];
        var after7 = s[7];
        var after8 = s[8];
        var after9 = s[9];
        var after10 = s[10];

        document.getElementById("txt_ThirdPartyName").value = before;
        document.getElementById("txt_ThirdParty_Add1").value = after1;
        document.getElementById("txt_ThirdParty_Add2").value = after2;
        document.getElementById("txt_ThirdParty_City").value = after3;
        document.getElementById("txt_Country_Division").value = after4;
        document.getElementById("txt_CountryCode").value = after5;
        document.getElementById("txt_ThirdParty_Pin").value = after6;
        document.getElementById("txt_TermsPlace").value = after7;
        document.getElementById("txt_Authrzd_Economic_Code").value = after8;
        document.getElementById("txt_Authrzd_Economic_Country").value = after9;
        document.getElementById("txt_Authrzd_Economic_Role").value = after10;


    }
    else {
//        document.getElementById("txt_ThirdPartyName").value = '';
        document.getElementById("txt_ThirdParty_Add1").value = '';
        document.getElementById("txt_ThirdParty_Add2").value = '';
        document.getElementById("txt_ThirdParty_City").value = '';
        document.getElementById("txt_Country_Division").value = '';
        document.getElementById("txt_CountryCode").value = '';
        document.getElementById("txt_ThirdParty_Pin").value = '';
        document.getElementById("txt_TermsPlace").value = '';
        document.getElementById("txt_Authrzd_Economic_Code").value = '';
        document.getElementById("txt_Authrzd_Economic_Country").value = '';
        document.getElementById("txt_Authrzd_Economic_Role").value = '';
    }

}

function Call__Inv_Currency_Excahnge_Rate(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    //alert('l');
    var ieccode = document.getElementById("txtInvoiceCurrency").value;
    if (ieccode.length == 3) {
        PageMethods.GetExchange_Rate_Invoice_Cur(ctrl.value, CallSuccess_Invoice_Cur, CallFailed, dest);
        Invoice_currency_ExRate();

    }

}
function Call_Excahnge_Rate(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    //alert('l');
    var ieccode = document.getElementById(src).value;
    if (ieccode.length == 3) {
        PageMethods.GetExchange_Rate(ctrl.value, CallSuccess, CallFailed, dest);

    }

}

// set the destination textbox value with the ContactName
function CallSuccess_Invoice_Cur(res, destCtrl) {

    var data = res;

    if (data.length == 0) {
        $('#hdn_chk_Invalid_Cur').val('No');
    }
    else {
        $('#hdn_chk_Invalid_Cur').val('Yes');
    }

    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];

        document.getElementById("hdn_non_std_effect_dt").value = after1;
        document.getElementById("hdn_non_std_bankname").value = after2;
        document.getElementById("hdn_non_std_cert_no").value = after3;
        document.getElementById("hdn_non_std_cert_dt").value = after4;
        
        var dest = document.getElementById(destCtrl);
        dest.value = before;
        document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExchangeRate").value;

//                    document.getElementById("hdn_Freight_Exrate").value = document.getElementById("txtExchangeRate").value;
//                    document.getElementById("hdn_Insurance_Exrate").value = document.getElementById("txtExchangeRate").value;

        if (document.getElementById("txtFreight_Currency").value == document.getElementById("txtInvoiceCurrency").value) {
            document.getElementById("hdn_Freight_Exrate").value = document.getElementById("txtExchangeRate").value;
        }
        if (document.getElementById("txtInsurance_Currency").value == document.getElementById("txtInvoiceCurrency").value) {
            document.getElementById("hdn_Insurance_Exrate").value = document.getElementById("txtExchangeRate").value;
        }
    }
    else {
        var dest = document.getElementById(destCtrl);
        dest.value = data;
      
        if (dest.value.length > 0) {
            document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExchangeRate").value;
//            document.getElementById("hdn_Freight_Exrate").value = document.getElementById("txtExchangeRate").value;
            //            document.getElementById("hdn_Insurance_Exrate").value = document.getElementById("txtExchangeRate").value;

            if (document.getElementById("txtFreight_Currency").value == document.getElementById("txtInvoiceCurrency").value) {
                document.getElementById("hdn_Freight_Exrate").value = document.getElementById("txtExchangeRate").value;
            }
            if (document.getElementById("txtInsurance_Currency").value == document.getElementById("txtInvoiceCurrency").value) {
                document.getElementById("hdn_Insurance_Exrate").value = document.getElementById("txtExchangeRate").value;
            }
        }
        document.getElementById("hdn_non_std_effect_dt").value = "";
        document.getElementById("hdn_non_std_bankname").value = "";
        document.getElementById("hdn_non_std_cert_no").value = "";
        document.getElementById("hdn_non_std_cert_dt").value = "";

    }

}


function CallSuccess(res, destCtrl) {

    var data = res;
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];

//        document.getElementById("hdn_non_std_effect_dt").value = after1;
//        document.getElementById("hdn_non_std_bankname").value = after2;
//        document.getElementById("hdn_non_std_cert_no").value = after3;
//        document.getElementById("hdn_non_std_cert_dt").value = after4;

        var dest = document.getElementById(destCtrl);
        dest.value = before;
        document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExchangeRate").value;
        document.getElementById("hdn_Freight_Exrate").value = document.getElementById("txtExchangeRate").value;
        document.getElementById("hdn_Insurance_Exrate").value = document.getElementById("txtExchangeRate").value;
    }
    else {
        var dest = document.getElementById(destCtrl);
        dest.value = data;
        if (dest.value.length > 0) {
            document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExchangeRate").value;
            document.getElementById("hdn_Freight_Exrate").value = document.getElementById("txtExchangeRate").value;
            document.getElementById("hdn_Insurance_Exrate").value = document.getElementById("txtExchangeRate").value;
        }
//        document.getElementById("hdn_non_std_effect_dt").value = "";
//        document.getElementById("hdn_non_std_bankname").value = "";
//        document.getElementById("hdn_non_std_cert_no").value = "";
//        document.getElementById("hdn_non_std_cert_dt").value = "";

    }

}

function Call_Freight_Excahnge_Rate(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    //alert('l');
    var ieccode = document.getElementById("txtFreight_Currency").value;
    var Inv_Curr = document.getElementById("txtInvoiceCurrency").value;
    var Inv_Exrate = document.getElementById("txtExchangeRate").value;

    if (ieccode.length == 3) {
        PageMethods.GetExchange_Rate(ctrl.value, Inv_Curr, Inv_Exrate, CallSuccess_Freight_Exrate, CallFailed, dest);
    }
}

function Call_Insurance_Excahnge_Rate(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    //alert('l');
    var ieccode = document.getElementById("txtInsurance_Currency").value;
    var Inv_Curr = document.getElementById("txtInvoiceCurrency").value;
    var Inv_Exrate = document.getElementById("txtExchangeRate").value;

    if (ieccode.length == 3) {
        PageMethods.GetExchange_Rate(ctrl.value, Inv_Curr, Inv_Exrate, CallSuccess_Freight_Exrate, CallFailed, dest);

    }

}
function CallSuccess_Freight_Exrate(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    dest.value = res;

}
// alert message on some failure
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}


//*******************************************************
//$('#txtInvoiceCurrency').keydown(function () {

//    var ddlTerms = $('#ddlTerms');
//    var terms = ddlTerms.val();
//    var txtInvoiceValue = $('#txtInvoiceValue');
//    var txtInvoiceCurrency = $('#txtInvoiceCurrency');

//    var txtExRate = $('#txtExchangeRate');

//    var txtCommission_Currency = $('#txtCommission_Currency');
//    var txtFOBDisc_Currency = $('#txtFOBDisc_Currency');

//    var txtPackMisc_Currency = $('#txtPackMisc_Currency');
//    var txtOtherDeductions_Currency = $('#txtOtherDeductions_Currency');
//    var txtFreight_Currency = $('#txtFreight_Currency');
//    var txtFreight_Rate = $('#txtFreight_Rate');

//    var txtInsurance_Currency = $('#txtInsurance_Currency');
//    var txtInsurance_Rate = $('#txtInsurance_Rate');

//    var hdn_grid_edit = $('#hdn_grid_edit');

//    var currency = document.getElementById("txtInvoiceCurrency").value;

//    var grid_edit = hdn_grid_edit.val();

//    //    alert(currency.length);

//    if (currency.length == 3) {

//        if (grid_edit == '0') {
//            txtCommission_Currency.val(currency);
//            txtFOBDisc_Currency.val(currency);
//            txtPackMisc_Currency.val(currency);
//            txtOtherDeductions_Currency.val(currency);
//        }

//        if (terms == 'FOB') {
//            txtFreight_Rate.val('');

//            txtInsurance_Rate.val('');
//            txtFreight_Currency.val('');

//            txtInsurance_Currency.val('');
//        }
//        else if (terms == 'CIF') {

//            if (grid_edit == '0') {
//                txtFreight_Currency.val(currency);
//                txtInsurance_Currency.val(currency);
//            }
//        }
//        else if (terms == 'CI') {

//            if (grid_edit == '0') {
//                txtInsurance_Currency.val(currency);
//            }
//            txtFreight_Rate.val('');
//            txtFreight_Currency.val('');
//        }
//        else if (terms == 'CF') {
//            txtInsurance_Rate.val('');

//            txtInsurance_Currency.val('');
//            if (grid_edit == '0') {
//                txtFreight_Currency.val(currency);
//            }
//        }
//    }
//});
//*******************************************************

$('#txtInvoiceCurrency').focusout(function () {

    var ddlTerms = $('#ddlTerms');
    var terms = ddlTerms.val();
    var txtInvoiceValue = $('#txtInvoiceValue');
    var txtInvoiceCurrency = $('#txtInvoiceCurrency');

    var txtExRate = $('#txtExchangeRate');

    var txtCommission_Currency = $('#txtCommission_Currency');
    var txtFOBDisc_Currency = $('#txtFOBDisc_Currency');

    var txtPackMisc_Currency = $('#txtPackMisc_Currency');
    var txtOtherDeductions_Currency = $('#txtOtherDeductions_Currency');
    var txtFreight_Currency = $('#txtFreight_Currency');
    var txtFreight_Rate = $('#txtFreight_Rate');

    var txtInsurance_Currency = $('#txtInsurance_Currency');
    var txtInsurance_Rate = $('#txtInsurance_Rate');

    var hdn_grid_edit = $('#hdn_grid_edit');

    var currency = document.getElementById("txtInvoiceCurrency").value;

    var grid_edit = hdn_grid_edit.val();

    //    alert(currency.length);

    if (currency.length == 3) {

        if (grid_edit == '0') {
            txtCommission_Currency.val(currency);
            txtFOBDisc_Currency.val(currency);
            txtPackMisc_Currency.val(currency);
            txtOtherDeductions_Currency.val(currency);
        }

        if (terms == 'FOB') {
            txtFreight_Rate.val('');
            txtInsurance_Rate.val('');
            txtFreight_Currency.val('');
            txtInsurance_Currency.val('');
        }
        else if (terms == 'CIF') {

            if (grid_edit == '0') {
                if ($('#txtFreight_Charges').val() == '') {
                    txtFreight_Currency.val(currency);
                }
                if ($('#txtInsurance_Charges').val() == '') {
                    txtInsurance_Currency.val(currency);
                }
            }
        }
        else if (terms == 'CI') {

            if (grid_edit == '0') {
                if ($('#txtInsurance_Charges').val() == '') {
                    txtInsurance_Currency.val(currency);
                }
            }
            txtFreight_Rate.val('');
            txtFreight_Currency.val('');
        }
        else if (terms == 'CF') {
            txtInsurance_Rate.val('');
            txtInsurance_Currency.val('');

            if (grid_edit == '0') {
                if ($('#txtFreight_Charges').val() == '') {
                    txtFreight_Currency.val(currency);
                }
            }
        }
    }
});

$(function () {
    $('#txtBuyerName').autocomplete({
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
                    var value1 = $('#txtBuyerName').val();
                    if (value1 != 'SAME AS CONSIGNEE') {
                        if (data.d == '') {
                            jQuery('#txtBuyerName').validationEngine('showPrompt', 'Incorrect Buyer Name', 'error', 'topRight', true);

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


$(function () {
    $('#txt_ThirdPartyName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exp_ThirdParty_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_ThirdPartyName').validationEngine('showPrompt', 'Incorrect ThirdParty Name', 'error', 'topRight', true);

                        //jAlert('Buyer Name is Incorrect', 'INVOICE', function (r) { document.getElementById("txtBuyerName').focus(); });
                        //return false;
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
    $("#txt_CountryCode").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');

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
                        if (field == 'txt_CountryCode') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Code', 'error', 'topRight', true);

                            //jAlert('Country Discharge is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $('#txt_CountryCode').focus(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txt_CountryCode').change(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txt_CountryCode').keyup(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txt_CountryCode').keydown(function () {

        var data = $(this).val();
        country(data);

    });
});

function country(val) {

    var data = val;
    if (data == '') {
        $('#txt_CountryCode').val('');
    }
    //$('#hdn_Autosearch').val(data);

    if (data.indexOf("-") != -1) {


        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txt_CountryCode').val(after);
      
    }
    else {

    }
}



$(document).ready(function () {

    $('#btnUpdate,#btnSave').click(function () {

        var ExchangeRate = document.getElementById("txtExchangeRate").value;
        var Terms = document.getElementById("ddlTerms").value;
        var chk_Invalid_Cur = document.getElementById("hdn_chk_Invalid_Cur").value;

        if (chk_Invalid_Cur == 'No') {
            jAlert('Invalid - Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("INVOICE_ID").click(); document.getElementById("txtInvoiceCurrency").focus(); });
            return false;
        }

       
        if (ExchangeRate.length == 0) {
            jAlert('Exchange Rate cannot be blank', 'INVOICE DETAILS', function (r) { document.getElementById("INVOICE_ID").click(); document.getElementById("txtExchangeRate").focus(); });
            return false;
        }

        if (Terms.length == 0) {
            jAlert('Terms cannot be blank', 'INVOICE DETAILS', function (r) { document.getElementById("INVOICE_ID").click(); document.getElementById("ddlTerms").focus(); });
            return false;
        }

        if (Terms.length > 0) {
            if (Terms != 'FOB' && Terms != 'CI' && Terms != 'CF' && Terms != 'CIF') {
                jAlert('Invalid - Terms', 'INVOICE DETAILS', function (r) { document.getElementById("INVOICE_ID").click(); document.getElementById("ddlTerms").focus(); });
                return false;
            }
        }

    });

});



$(function () {
    $("#txtAddress3").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');

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
                        if (field == 'txtAddress3') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);

                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $('#txtAddress3').focus(function () {

        var data = $(this).val();
        Buyer_country(data);

    });
    $('#txtAddress3').change(function () {

        var data = $(this).val();
        Buyer_country(data);

    });
    $('#txtAddress3').keyup(function () {

        var data = $(this).val();
        Buyer_country(data);

    });
    $('#txtAddress3').keydown(function () {

        var data = $(this).val();
        Buyer_country(data);

    });
});


function Buyer_country(val) {

    var data = val;
    if (data == '') {
        $('#txtAddress3').val('');
    }

    if (data.indexOf("-") != -1) {
        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txtAddress3').val(before);

    }
    else {

    }
}
       