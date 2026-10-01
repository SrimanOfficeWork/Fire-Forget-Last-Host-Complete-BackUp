
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}
$(function () {
    $("#txtImportername").autocomplete({ 
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Importer_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtImportername').validationEngine('showPrompt', 'Incorrect Importer Name', 'error', 'topRight', true);
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
$(function () {
    $("#txt_Cus_name").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Importer_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_Cus_name').validationEngine('showPrompt', 'Incorrect Customer Name', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_Cus_name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Supplier_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtsuppliername').validationEngine('showPrompt', 'Incorrect Supplier Name', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txtsuppliername').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//===================================Import Notify_party_1 END====================================================================================
$(function () {
    $("#txt_IMP_notify_party_1").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Importer_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
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
                }
            });
        },
        minLength: 1

    });
    return false;
    scroll: true;
});
//------------------------------------------------------------------------------------------------------------------------
function CallServerside_Importer(src, dest) {

    var ctrl = document.getElementById(src);
    var jobno = document.getElementById('Hdjobno');
    var Branch = document.getElementById('hd_Brslno');


    PageMethods.Get_Importer(ctrl.value, jobno.value, Branch.value, CallSuccess_IMPORTER, CallFailed, dest);
}

function CallSuccess_IMPORTER(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');
        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];


        document.getElementById("txtShip_Add1").value = before;
        document.getElementById("txt_GSTN_Id").value = after1;
        document.getElementById("ddl_state_name").value = after2;

    }
    else {
        document.getElementById("txtShip_Add1").value = '';
        document.getElementById("txt_GSTN_Id").value = '';
        document.getElementById("ddl_state_name").value = '';

    }

}

//----------------------------------------------
function CallServerside_Supplier(src, dest) {
    var ctrl = document.getElementById(src);
    var jobno = document.getElementById('Hdjobno');

    PageMethods.Get_Supplier(ctrl.value, jobno.value, CallSuccess_suppliername, CallFailed, dest);
}

function CallSuccess_suppliername(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    document.getElementById("txtCon_Add1").value = res;
}
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
//===================================Import Importer name START====================================================================================
$(function () {
    $("#txtimportername_Other").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Importer_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtimportername_Other').validationEngine('showPrompt', 'Incorrect Exporter Name', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txtimportername_Other').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//===================================Import IMPORTER NAME END====================================================================================
function CallServerside_Importer_other(src, dest) {

    var ctrl = document.getElementById(src);
    PageMethods.Get_Importer_other(ctrl.value, '', '', CallSuccess_IMPORTER_other, CallFailed, dest);
}

function CallSuccess_IMPORTER_other(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    document.getElementById("txtInvoiceNo").value = res;
}

//===================================Import IMPORTER NAME Start====================================================================================

//===================================Import Inv No check Start====================================================================================
function CallServerside_IMP_INVCHK(src, dest) {

    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById('HdtxtInvoiceNo_id');
    PageMethods.Get_Importer_Inv_Chk(ctrl.value, ctrl_2.value, '', CallSuccess_IMPORTER_Inv_Chk, CallFailed, dest);
}

function CallSuccess_IMPORTER_Inv_Chk(res, destCtrl) {
    if (res == "Yes") {
        document.getElementById('txtInvoiceNo').style.border = "1px solid #c8c8c8";
    }
    else {
        document.getElementById('txtInvoiceNo').style.border = "2px solid Red";
    }

}

//===================================Import Inv No check End====================================================================================

//===================================Export Inv No check Start====================================================================================
function CallServerside_EXP_INVCHK(src, dest) {

    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById('HdtxtInvoiceNo_id');
    PageMethods.Get_Exporter_Inv_Chk(ctrl.value, ctrl_2.value, '', CallSuccess_EXPORTER_Inv_Chk, CallFailed, dest);
}

function CallSuccess_EXPORTER_Inv_Chk(res, destCtrl) {
    if (res == "Yes") {
        document.getElementById('txtInvoiceNo').style.border = "1px solid #c8c8c8";
    }
    else {
        document.getElementById('txtInvoiceNo').style.border = "2px solid Red";
    }

}

//===================================Export Inv No check End====================================================================================

//===================================Export Exporter name START====================================================================================
$(function () {
    $("#txtexporterName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_GST_Exporter_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtexporterName').validationEngine('showPrompt', 'Incorrect Exporter Name', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txtexporterName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//===================================Export Exporter name END====================================================================================
//===================================Export Shipper name START====================================================================================
$(function () {
    $("#txtshippername").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_GST_Exporter_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
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
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');
        var before = s[0];
        var after1 = s[1];

        document.getElementById("txtShip_Add1").value = before;
        document.getElementById("txt_GSTN_Id").value = after1;
    }
    else {
        document.getElementById("txtShip_Add1").value = '';
        document.getElementById("txt_GSTN_Id").value = '';
    }

}
//===================================Export Shipper name END====================================================================================
//===================================Export CONSIGNEE_NAME START====================================================================================


$(function () {
    $("#txtconsigneename").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_GST_CONSIGNEE_NAME_MASTER_LIST",
                data: "{ 'mail': '" + request.term + "' }",
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
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_GST_Exporter_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_notify_party_1').validationEngine('showPrompt', 'Incorrect Notify Party 1 Name', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_notify_party_1').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//===================================Import Importer name END====================================================================================
$(function () {
    $("#txtchargeWeightType,#txt_Gross_Wgt_Type,#txt_Net_Wgt_Type").autocomplete({

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

$(function () {

    $("#txtCountryShipment").autocomplete({
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

                        if (field == 'txtCountryShipment') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Shipment', 'error', 'topRight', true);
                        }
                    }
                    else {
                        //jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtPortShipment").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');
            var Mode = $('select#ddl_tr_mode option:selected').val();
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + Mode + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {

                        if (field == 'txtPortShipment') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Shipment', 'error', 'topRight', true);
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
    
    $('#txtCountryShipment').focus(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryShipment').change(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryShipment').keyup(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryShipment').keydown(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryShipment').click(function () {

        var data = $(this).val();
        country_shipment(data);

    });
});


function country_shipment(val) {
    var data = val;
    if (data == '') {
        $('#txtCountryShipment').val('');
    }

    if (data.indexOf("-") != -1) {

        var s = data.split('-');
        var before = s[0];
        var after = s[1];

        $('#txtCountryShipment').val(before);

    }
    else {

    }
}

//------------------------------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------------------------
$(function () {
    $("#txtCountryDischarge").autocomplete({

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
                        if (field == 'txtCountryDischarge') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Discharge', 'error', 'topRight', true);
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
    $("#txtPortDischarge").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');
            var Mode = $('select#ddl_tr_mode option:selected').val()
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + Mode + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    if (data.d == '') {
                        if (field == 'txtPortDischarge') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Discharge', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                    }
                    response(data.d);
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
//----------------------------------------------------------------------------
$(function () {
    $('#txtCountryDischarge').focus(function () {
        var data = $(this).val();
        country(data);
    });
    $('#txtCountryDischarge').change(function () {
        var data = $(this).val();
        country(data);
    });
    $('#txtCountryDischarge').keyup(function () {
        var data = $(this).val();
        country(data);
    });
    $('#txtCountryDischarge').keydown(function () {
        var data = $(this).val();
        country(data);
    });
});

function country(val) {

    var data = val;
    if (data.indexOf("-") != -1) {
        var s = data.split('-');
        var before = s[0];
        var after = s[1];
        $('#txtCountryDischarge').val(before);
    }

}
//----------------------------------------------------------------------------------------------
function CallServerside_Customer(src, dest) {

    var ctrl = document.getElementById(src);
    var jobno = '';
    var Branch = document.getElementById('hd_Brslno');


    PageMethods.Get_Cus_det(ctrl.value, jobno, Branch.value, CallSuccess_Cus, CallFailed, dest);
}

function CallSuccess_Cus(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');
        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];


        document.getElementById("txt_Party_Add").value = before;
        document.getElementById("txt_GSTN_Id").value = after1;
        document.getElementById("ddl_state_name").value = after2;

    }
    else {
        document.getElementById("txt_Party_Add").value = '';
        document.getElementById("txt_GSTN_Id").value = '';
        document.getElementById("ddl_state_name").value = '';

    }

}
