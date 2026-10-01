function CallServerside_Importer(src, dest) {
    var ctrl = document.getElementById(src);

    PageMethods.GetImporter(ctrl.value, CallSuccess_Importer, CallFailed, dest);

}
function CallSuccess_Importer(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    var data = res;
    document.getElementById("txtimpname").value = data;
}

function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}

$(function () {
    $("#txtimpname").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/mis_importerName",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtimpname').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtimpname').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

/*-----------------------------------Branch---start-----------------------------------------------------*/

function CallServerside_Branch(src, dest) {
    var ctrl = document.getElementById(src);

    PageMethods.GetImporter(ctrl.value, CallSuccess_branch, CallFailed, dest);

}
function CallSuccess_branch(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    var data = res;
    document.getElementById("txtbranch").value = data;
}


$(function () {
    $("#txtbranch").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/mis_brach",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtbranch').validationEngine('showPrompt', 'Invalid Branch Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtbranch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

/*-----------------------------------Branch---End-------------------------------------------------------*/

/*-----------------------------------BE-Type--start-----------------------------------------------------*/
/*function CallServerside_Branch(src, dest) {
    var ctrl = document.getElementById(src);

    PageMethods.GetImporter(ctrl.value, CallSuccess_branch, CallFailed, dest);

}
function CallSuccess_branch(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    var data = res;
    document.getElementById("txtBEtype").value = data;
}


$(function () {
    $("#txtBEtype").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/mis_BE_type",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtBEtype').validationEngine('showPrompt', 'Invalid BE Type Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtBEtype').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

});*/
/*-----------------------------------BE-Type--End-------------------------------------------------------*/

/*-----------------------------------Port--start--------------------------------------------------------*/
function CallServerside_Port(src, dest) {
    var ctrl = document.getElementById(src);

    PageMethods.GetImporter(ctrl.value, CallSuccess_Port, CallFailed, dest);

}
function CallSuccess_Port(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    var data = res;
    document.getElementById("txtport").value = data;
}


$(function () {
    $("#txtport").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/mis_port",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtport').validationEngine('showPrompt', 'Invalid Port Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtport').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
/*-----------------------------------Port--End----------------------------------------------------------*/
/*-----------------------------------Country--start--------------------------------------------------------*/
function CallServerside_Country(src, dest) {
    var ctrl = document.getElementById(src);

    PageMethods.GetImporter(ctrl.value, CallSuccess_country, CallFailed, dest);

}
function CallSuccess_country(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    var data = res;
    document.getElementById("txtcountry").value = data;
}


$(function () {
    $("#txtcountry").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/mis_Country",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtcountry').validationEngine('showPrompt', 'Invalid Country Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtcountry').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
/*-----------------------------------Country--End----------------------------------------------------------*/

/*-------------------------------Export-----------------------------------------------------------------*/

$(function () {
    $("#txtExpname").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXP_Name",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtExpname').validationEngine('showPrompt', 'Invalid Exporter Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtExpname').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

/*-------------------------------Export-----------------------------------------------------------------*/

$(function () {
    $("#txt_BL_Expname").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/BL_EXP_Name",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtExpname').validationEngine('showPrompt', 'Invalid Exporter Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtExpname').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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