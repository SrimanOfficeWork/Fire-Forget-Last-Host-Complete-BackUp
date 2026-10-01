//$(function () {
//    $("#txtState").autocomplete({
//        source: function (request, response) {
//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_Name_List",
//                data: "{ 'mail': '" + request.term + "' }",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {
//                    response(data.d);
//                    if (data.d == '') {
//                        jQuery('#txtState').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);

//                        //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
//                        //return false;
//                    }
//                    else {
//                        jQuery('#txtState').validationEngine('hidePrompt', '', 'error', 'topRight', true);
//                    }
//                },
//                error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    ////alert(textStatus);
//                }
//            });
//        },
//        minLength: 1

//    });
//    return false;
//    scroll: true;
//});

//$(function () {
//    $("#txtCountryName,#txtCountryBranchName").autocomplete({
//        source: function (request, response) {
//            var field = $(this.element).attr('id');

//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Country_Master_List",
//                data: "{ 'mail': '" + request.term + "' }",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {
//                    response(data.d);
//                    if (data.d == '') {

//                        if (field == 'txtCountryName' || field == 'txtCountryBranchName') {
//                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Shipment', 'error', 'topRight', true);
//                        }
//                    }
//                    else {
//                        //jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
//                    }
//                },
//                error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    ////alert(textStatus);
//                }
//            });
//        },
//        minLength: 1

//    });
//    return false;
//    scroll: true;
//});

$(function () {
    $("#txtCountryName").autocomplete({
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

                        if (field == 'txtCountryName') {
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



//$(function () {
//    $("#txtCountryBranchName").autocomplete({
//        source: function (request, response) {
//            var field = $(this.element).attr('id');

//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Country_Master_List",
//                data: "{ 'mail': '" + request.term + "' }",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {
//                    response(data.d);
//                    if (data.d == '') {

//                        if (field == 'txtCountryBranchName') {
//                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Shipment', 'error', 'topRight', true);
//                        }
//                    }
//                    else {
//                        //jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
//                    }
//                },
//                error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    ////alert(textStatus);
//                }
//            });
//        },
//        minLength: 1

//    });
//    return false;
//    scroll: true;
//});

$(function () {
    $("[id*=txtCountryBranchName]").autocomplete({
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

                        if (field == '[id*=txtCountryBranchName]') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Shipment', 'error', 'topRight', true);
                        }
                    }
                    else {
                        //jQuery('[id*=txtCountryBranchName]').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("[id*=txtState]").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_Name_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('[id*=txtState]').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);

                        //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('[id*=txtState]').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
