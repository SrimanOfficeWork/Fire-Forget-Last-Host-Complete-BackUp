
//------------------------------------------------------------------------------------------------------------------
function CallServerside_txttax_amt(a, b, c, d, e) {
    var s1 = document.getElementById(a).value;
    var s2 = document.getElementById(b).value;
    var s3 = document.getElementById(c).value;
    var s4 = document.getElementById(d).value;
    var s5 = document.getElementById(e).value;

    var Tax1 = (s2 / 100).toFixed(4) * s1;
    var Tax2 = (s3 / 100).toFixed(4) * s1;
    var Tax3 = (s4 / 100).toFixed(4) * Tax1;
    var Tax4 = (s5 / 100).toFixed(4) * s1;

    document.getElementById("txt_tax_amt_1").value = (Tax1).toFixed(2);
    document.getElementById("txt_tax_amt_2").value = (Tax2).toFixed(2);
    document.getElementById("txt_tax_amt_3").value = (Tax3).toFixed(2);
    document.getElementById("txt_tax_amt_4").value = (Tax4).toFixed(2);

    var Total_tax = Tax1 + Tax2 + Tax3 + Tax4;

    document.getElementById("txt_total_tax_amt").value = (Total_tax).toFixed(2);
    document.getElementById("txt_total_amt_With_tax").value = (parseFloat(Total_tax, 10) + parseFloat(document.getElementById(a).value, 10)).toFixed(2);


}


//------------------------------------------------------------------------------------------------------------------
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}

//=======================================================================================================================





$(function () {
    $("#txtImportername_").autocomplete({
              

        source: function (request, response) {
            alert('TEST');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_Imp",
              //  data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtImportername').validationEngine('showPrompt', 'Incorrect Shipper Name', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txtImportername').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//===================================Import supplier name stat====================================================================================
$(function () {
    $("#txtsuppliername").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_Supplier_Master_List",
              //  data: "{ 'mail': '" + request.term + "' ,'Branch': '" + document.getElementById("Hd_branch").value + "'  }",
                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtsuppliername').validationEngine('showPrompt', 'Incorrect Supplier Name', 'error', 'topRight', true);

                        //jAlert('ConsigneeName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtConsigneeName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtsuppliername').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function CallServerside_Supplier(src, dest) {
    var ctrl = document.getElementById(src);
    var jobno = document.getElementById('Hdjobno');
    var Branch = document.getElementById('Hd_branch');

    PageMethods.Get_Supplier(ctrl.value, jobno.value, Branch.value, CallSuccess_suppliername, CallFailed, dest);
}

function CallSuccess_suppliername(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    document.getElementById("txtCon_Add1").value = res;
}
//===================================Import supplier name END====================================================================================

//===================================Import IMPORTER NAME START====================================================================================

$(function () {
    $("#txtImportername").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_Importer_Master_List",
                //  data: "{ 'mail': '" + request.term + "' ,'Branch': '" + document.getElementById("Hd_branch").value + "'  }",
                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtImportername').validationEngine('showPrompt', 'Incorrect Importer Name', 'error', 'topRight', true);

                        //jAlert('ConsigneeName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtConsigneeName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtImportername').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function CallServerside_Importer(src, dest) {
      
    var ctrl = document.getElementById(src);
    var jobno = document.getElementById('Hdjobno');
    var Branch = document.getElementById('hd_Brslno');
    
   
   PageMethods.Get_Importer(ctrl.value, jobno.value, Branch.value, CallSuccess_IMPORTER, CallFailed, dest);
}

function CallSuccess_IMPORTER(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    document.getElementById("txtShip_Add1").value = res;
}
//===================================Import IMPORTER NAME END====================================================================================
function CallServerside_Importer_other(src, dest) {

    var ctrl = document.getElementById(src);
    var mode = $("#ddlmode option:selected").text();
    var Branch = document.getElementById('Hd_branch');

    PageMethods.Get_Importer_other(ctrl.value, mode, Branch.value, CallSuccess_IMPORTER_other, CallFailed, dest);
}

function CallSuccess_IMPORTER_other(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    document.getElementById("txtInvoiceNo").value = res;
}

//===================================Import IMPORTER NAME Start====================================================================================

//===================================Import IMPORTER NAME End======================================================================================

//===================================Export Exporter name START====================================================================================
$(function () {
    $("#txtexporterName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_Exporter_Master_List",
                //  data: "{ 'mail': '" + request.term + "' ,'Branch': '" + document.getElementById("Hd_branch").value + "'  }",
                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtexporterName').validationEngine('showPrompt', 'Incorrect Exporter Name', 'error', 'topRight', true);

                        //jAlert('ConsigneeName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtConsigneeName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtexporterName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//===================================Export Exporter name END====================================================================================

//===================================Export Shipper name START====================================================================================
$(function () {
    $("#txtshippername").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_Exporter_Master_List",
                //  data: "{ 'mail': '" + request.term + "' ,'Branch': '" + document.getElementById("Hd_branch").value + "'  }",
                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtshippername').validationEngine('showPrompt', 'Incorrect Exporter Name', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txtshippername').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function CallServerside_Exporter_Add(src, dest) {
    var ctrl = document.getElementById(src);
   // var jobno = document.getElementById('Hdjobno');
    var Branch = document.getElementById('hd_EXP_Brslno');

    PageMethods.GetExporter(ctrl.value, Branch.value, CallSuccess_EXPORTER, CallFailed, dest);
}

function CallSuccess_EXPORTER(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    document.getElementById("txtShip_Add1").value = res;
}
//===================================Export Shipper name END====================================================================================

//===================================Export CONSIGNEE_NAME START====================================================================================


$(function () {
    $("#txtconsigneename").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_CONSIGNEE_NAME_MASTER_LIST",
                //  data: "{ 'mail': '" + request.term + "' ,'Branch': '" + document.getElementById("Hd_branch").value + "'  }",
                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtconsigneename').validationEngine('showPrompt', 'Incorrect Consignee Name', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txtconsigneename').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function CallServerside_Consignee_Add(src, dest) {
    var ctrl = document.getElementById(src);
    // var jobno = document.getElementById('Hdjobno');
    var Branch = document.getElementById('Hd_branch');

    PageMethods.GetConsignee(ctrl.value, Branch.value, CallSuccess_Consignee, CallFailed, dest);
}

function CallSuccess_Consignee(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    document.getElementById("txtCon_Add1").value = res;
}
//===================================Export CONSIGNEE_NAME END====================================================================================

//===================================Export Notify_party_1 END====================================================================================


$(function () {
    $("#txt_notify_party_1").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_Exporter_Master_List",
                //  data: "{ 'mail': '" + request.term + "' ,'Branch': '" + document.getElementById("Hd_branch").value + "'  }",
                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_notify_party_1').validationEngine('showPrompt', 'Incorrect Notify Party 1 Name', 'error', 'topRight', true);

                        //jAlert('ConsigneeName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtConsigneeName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_notify_party_1').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function CallServerside_notify_party_1_Add(src, dest) {
    var ctrl = document.getElementById(src);
    // var jobno = document.getElementById('Hdjobno');
    var Branch = document.getElementById('hd_EXP_br_sl_no');

    PageMethods.GetExporter(ctrl.value, Branch.value, CallSuccess_notify_party_1, CallFailed, dest);
}

function CallSuccess_notify_party_1(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    document.getElementById("txt_notify_party_1_add").value = res;
}

//===================================Export Notify_party_1 END====================================================================================
//===================================Import Notify_party_1 Start====================================================================================

function CallServerside_IMP_notify_party_1_Add(src, dest) {
   
    var ctrl = document.getElementById(src);
    var Branch = document.getElementById('hd_hss_br_sl_no');
    PageMethods.GetImporter(ctrl.value, Branch.value, CallSuccess_IMP_notify_party_1, CallFailed, dest);
}

function CallSuccess_IMP_notify_party_1(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    document.getElementById("txt_notify_party_1_add").value = res;
}
//===================================Import Notify_party_1 END====================================================================================
$(function () {
    $("#txt_IMP_notify_party_1").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_Importer_Master_List",
                //  data: "{ 'mail': '" + request.term + "' ,'Branch': '" + document.getElementById("Hd_branch").value + "'  }",
                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_IMP_notify_party_1').validationEngine('showPrompt', 'Incorrect Notify Party 1 Name', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_IMP_notify_party_1').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//===================================Import Importer name START====================================================================================
$(function () {
    $("#txtimportername_Other").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_Importer_Master_List",
                //  data: "{ 'mail': '" + request.term + "' ,'Branch': '" + document.getElementById("Hd_branch").value + "'  }",
                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtexporterName').validationEngine('showPrompt', 'Incorrect Exporter Name', 'error', 'topRight', true);

                        //jAlert('ConsigneeName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtConsigneeName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtexporterName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//===================================Import Importer name END====================================================================================
$(function () {
    $("#txtchargeWeightType").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtchargeWeightType').validationEngine('showPrompt', 'Incorrect Airline Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtchargeWeightType').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
