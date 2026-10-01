$(function () {
    $("#txtCurrency").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            var aa = document.getElementById("Hdn_Module").value;
//            alert(aa);
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exchage_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'exrate':'" + aa + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtCurrency') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Currency', 'error', 'topRight', true);

                            //jAlert('Invoice Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            // return false;
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


$(function () {
    $("#txtClient_Name").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Quote",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtClient_Name').validationEngine('showPrompt', 'Incorrect Client Name', 'error', 'topRight', true);

                        //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtClient_Name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtCharge_name").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/BL_QUOTATION_ChargeName",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);

                    if (data.d == '') {
                        jQuery('#txtCharge_name').validationEngine('showPrompt', 'Incorrect Client Name', 'error', 'topRight', true);

                        //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtCharge_name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//***************************** Quotation Master Client Name Search Start**************************************

$(function () {
    $("#txt_ClientName").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/BL_QUOTATION_ClientName",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_ClientName').validationEngine('showPrompt', 'Incorrect Client Name', 'error', 'topRight', true);

                        //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_ClientName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//***************************** Quotation Master Client Name Search End **************************************



function CallServerside_BL_Charge_Name(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

        PageMethods.DropDown_BL_Charger_Name_Quote(ctrl.value, CallFailed, dest);

}


function Call_Excahnge_Rate_Quote(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
   
    PageMethods.GetExchange_Rate_Quote(ctrl.value, CallSuccess, CallFailed, dest);

}

function CallServerside_BL_ClientName_Quote(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    PageMethods.DropDown_BL_Quote_Client_Name(ctrl.value, CallFailed, dest);

}

// set the destination textbox value with the ContactName
function CallSuccess(res, destCtrl) {

    var data = res;
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
        document.getElementById("hdn_non_std_effect_dt").value = "";
        document.getElementById("hdn_non_std_bankname").value = "";
        document.getElementById("hdn_non_std_cert_no").value = "";
        document.getElementById("hdn_non_std_cert_dt").value = "";

    }

}
