
$(function () {
    $("#txtPort_Of_Licenses").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",
//                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtPort_Of_Licenses').validationEngine('showPrompt', 'Incorrect Port Of License', 'error', 'topRight', true);

                        //jAlert('Port Of License is Incorrect', 'LICENSE', function (r) { document.getElementById("txtPort_Of_Licenses").focus(); });
                        // return false;
                    }
                    else {
                        jQuery('#txtPort_Of_Licenses').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtUnit").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

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
                        if (field == 'txtUnit') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Unit', 'error', 'topRight', true);

                            //jAlert('Gross Weight Type is Incorrect', 'IGM', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }

                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//    $("#txtImporterName,#txtSellerName").autocomplete({

    $("#txt_PartyName").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List1",
                data: "{ 'mail': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_PartyName') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Importer Name', 'error', 'topRight', true);

                            //jAlert('Importer Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
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
    $("#txtLicense_No").autocomplete({

        source: function (request, response) {

            $.ajax({

                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMPORT_LICENSE_REGN_NO",
                data: "{ 'mail': '" + request.term + "' ,'scheme':'" + document.getElementById("hdn_license_type").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtLicense_No').validationEngine('showPrompt', 'Invalid LicenseNo', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtLicense_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
            //                    }
        },
        minLength: 1

    });
    return false;
    scroll: true;
});

   