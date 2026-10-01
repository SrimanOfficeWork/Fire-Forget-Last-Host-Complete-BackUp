$(function () {
    $("#txt_PortLoading,#txt_Portdischarge,#txt_Place_Receipt").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdfTransport_mode1").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    if (data.d == '') {
                        if (field == 'txt_PortLoading') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Loading', 'error', 'topRight', true);

                            //jAlert('Port Discharge is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Portdischarge') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Final Destination', 'error', 'topRight', true);

                            //jAlert('Port Final Destination is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        
                        if (field == 'txt_Place_Receipt') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Port', 'error', 'topRight', true);

                            //jAlert('Port Final Destination is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
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

//********************* CERTIFICATE OF ORIGIN ****************************************

$(function () {
    $("#txtPre_Carriageby,#txtPlace_Precarier,#txtPort_Of_Discharge,#txtPort_Of_Loading,#txtImporting_Country").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Port_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdfTransport_mode1").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    if (data.d == '') {
                        if (field == 'txtPre_Carriageby') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Loading', 'error', 'topRight', true);

                            //jAlert('Port Discharge is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtPlace_Precarier') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Final Destination', 'error', 'topRight', true);

                            //jAlert('Port Final Destination is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtPort_Of_Discharge') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Port', 'error', 'topRight', true);

                            //jAlert('Port Final Destination is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtPort_Of_Loading') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Port', 'error', 'topRight', true);

                            //jAlert('Port Final Destination is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtImporting_Country') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Port', 'error', 'topRight', true);

                            //jAlert('Port Final Destination is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
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


//***************************  AUTO SEARCH COUNTRY NAME **********************************

$(function () {
    $("#txtCountry,#txtFinal_Destination,#txt_Place_Delivery").autocomplete({

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
                        if (field == 'txtCountry') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Discharge', 'error', 'topRight', true);

                            //jAlert('Country Discharge is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtFinal_Destination') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Final Destination', 'error', 'topRight', true);

                            //jAlert('Country Final Destination is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Place_Delivery') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Final Destination', 'error', 'topRight', true);

                            //jAlert('Country Final Destination is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
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

//************************************** BL GENERATION EXPORTER SEARCH *******************************************

$(function () {
    $("#txtExporter,#txtConsignee,#txtNotify").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Report_Exporter_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("hdn_CLIENT_TYPE").value +  "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);
                    if (document.getElementById("hdn_CLIENT_TYPE").value == 'Exporter') {
                        if (data.d == '') {
                            jQuery('#txtExporter').validationEngine('showPrompt', 'Incorrect ExporterName', 'error', 'topRight', true);

                            //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                            //return false;
                        }
                            else {
                                jQuery('#txtExporter').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                               }
                    }
                        else if (document.getElementById("hdn_CLIENT_TYPE").value == 'Consignee') {
                        
                        if (data.d == '') {
                            jQuery('#txtConsignee').validationEngine('showPrompt', 'Incorrect Consignee', 'error', 'topRight', true);

                            //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                            //return false;
                        }
                                 else {
                                     jQuery('#txtConsignee').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                }
                           }
                           else if (document.getElementById("hdn_CLIENT_TYPE").value == 'Notify') {

                               if (data.d == '') {
                                   jQuery('#txtNotify').validationEngine('showPrompt', 'Incorrect Notify', 'error', 'topRight', true);

                                   //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                                   //return false;
                               }
                               else {
                                   jQuery('#txtNotify').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


/* *************************** REPORT EXPORTER NAME SEARCH *************************/

/* *********************** CURRENCY SEARCH **********************************************/

$(function () {
    $('#txt_Currency').autocomplete({
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
                        if (field == 'txt_Currency') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect  Currency', 'error', 'topRight', true);

                            //jAlert('Invoice Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
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

/* *********************** CURRENCY SEARCH **********************************************/



/* ------------ BL GENERATION OCEAN VESSEL AUTO SEARCH START ------------------- */

$(function () {
    $("#txt_OceanVessel").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Report_OceanVessel_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("hdn_CLIENT_TYPE").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);
                     if (data.d == '') {
                         jQuery('#txt_OceanVessel').validationEngine('showPrompt', 'Incorrect Ocean Vessel', 'error', 'topRight', true);

                            //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                            //return false;
                        }
                        else {
                            jQuery('#txt_OceanVessel').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

/* ------------ BL GENERATION OCEAN VESSEL AUTO SEARCH END ------------------- */



/* *************************** REPORT NOTIFY NAME SEARCH *************************/

function CallServerside_Report_NotifyName(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Report_Notify_Details(ctrl.value, ctrl_2.value, CallSuccess_Notify, CallFailed, dest);

}
// calling CESS

// set the destination textbox value with the ContactName
function CallSuccess_Notify(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
   
    //dest.value = res;
    var data = res;
    //    alert('i');
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
                var after5 = s[5];
        //        var after6 = s[6];

        //alert(after4);

        document.getElementById("txtNotify_Add1").value = before;
        document.getElementById("txtNotify_Add2").value = after1;
        document.getElementById("txtNotify_Add3").value = after2;
        document.getElementById("txtNotify_Add4").value = after3;
        document.getElementById("txtNotify_Add5").value = after4 + ' ' + after5;

    }
    else {

        document.getElementById("txtNotify_Add1").value = "";
        document.getElementById("txtNotify_Add2").value = "";
        document.getElementById("txtNotify_Add3").value = "";
        document.getElementById("txtNotify_Add4").value = "";
        document.getElementById("txtNotify_Add5").value = "";

    }
}

//---------------------EXPORTER NAME SEARCH CLIENT TYPE & BRANCH SL NO----2---------------------//

function CallServerside_Consignee_2(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Report_Consignee_Details(ctrl.value, ctrl_2.value, CallSuccess_Consignee, CallFailed, dest);

}
// set the destination textbox value with the ContactName
function CallSuccess_Consignee(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    //    alert('i');
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
//        var after5 = s[5];
//        var after6 = s[6];

        //alert(before);

        document.getElementById("txtConsignee_Add1").value = before;
        document.getElementById("txtConsignee_Add2").value = after1;
        document.getElementById("txtConsignee_Add3").value = after2;
        document.getElementById("txtConsignee_Add4").value = after3 + ' ' + after4;
//        document.getElementById("txtAddress5").value = after4;

    }
    else {

        document.getElementById("txtConsignee_Add1").value = "";
        document.getElementById("txtConsignee_Add2").value = "";
        document.getElementById("txtConsignee_Add3").value = "";
        document.getElementById("txtConsignee_Add4").value = "";
//        document.getElementById("txtAddress5").value = "";

    }
}

//======================IMPORTER----2--END===============================================

//---------------------CONSIGNEE NAME SEARCH CLIENT TYPE & BRANCH SL NO----2---------------------//

function CallServerside_Exporter_2(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Report_Client_Details(ctrl.value, ctrl_2.value, CallSuccess_Exporter_2, CallFailed, dest);

}
function CallSuccess_Exporter_2(res, destCtrl) {
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

       // alert(after5);

        document.getElementById("txtAddress1").value = before;
        document.getElementById("txtAddress2").value = after1;
        document.getElementById("txtAddress3").value = after2;
        document.getElementById("txtAddress4").value = after3;
        document.getElementById("txtAddress5").value = after4 +' '+ after5;
//        if (after4 != '') {
//            document.getElementById("txtAddress4").value = after3 + '--' + after4;
//        }
//        else {
//            document.getElementById("txtAddress4").value = after3;
//        }
        //            document.getElementById("txtAddress5").value = after4;


    }
    else {

        document.getElementById("txtAddress1").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
        document.getElementById("txtAddress5").value = "";

    }
}



//====================== CONSIGNEE NAME ----2--END===============================================

function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}



function DB_NUmber(src, dest) {
    PageMethods.Get_DB_NUmber('DB_no', CallSuccess_DB_No, CallFailed, dest);
}
function CallSuccess_DB_No(res, destCtrl) {

    if (res != '') {
        document.getElementById("txt_DBNo").value = res;
    }
    else {
        document.getElementById("txt_DBNo").value = "";
    }
}