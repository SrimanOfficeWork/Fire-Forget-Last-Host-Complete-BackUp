

$(function () {
    $("#txt_Statement_Type").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_SingleWindow",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);

                    if (data.d == '') {
                        jQuery('#txt_Statement_Type').validationEngine('showPrompt', 'Incorrect Statement Type', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_Statement_Type').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//----------------------------------------

$(function () {
    $("#txt_Info_Uqc").autocomplete({
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
                        
                        if (field == 'txt_Info_Uqc') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Single Window Unit Code', 'error', 'topRight', true);

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

//----------------------------------------


$(function () {
    $("#txt_Statement_Code").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_SingleWindow_statement_Code_Text",
                data: "{ 'mail': '" + request.term + "' ,'Stmt_Type':'" + document.getElementById('txt_Statement_Type').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);

                    if (data.d == '') {
                        jQuery('#txt_Statement_Code').validationEngine('showPrompt', 'Incorrect Statement Type', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_Statement_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//------------------------
function CallServerside_Stmttext(src, dest) {
    var ctrl = document.getElementById(src);
    var ctr2 = document.getElementById('txt_Statement_Type');

    PageMethods.GetSingleWindow_statement_bind(ctrl.value, ctr2.value, CallSuccess_statement_text, CallFailed, dest);
   // PageMethods.GetImporter_Branchwise(ctrl, ctrl1, CallSuccess_Importer_BranchWise, CallFailed, dest);

}
function CallSuccess_statement_text(res, destCtrl) {
    /*var dest = document.getElementById(destCtrl);*/
    var data = res;
    
    document.getElementById("txt_Statement_Text").value = data;
}

function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}

//------------------------------------------------------------------------------------------------

$(function () {
    $("#txt_Info_Qualifier").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_SingleWindow_Qualifier",
                data: "{ 'mail': '" + request.term + "' ,'Info_type':'" + document.getElementById('txt_info_type').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);

                    if (data.d == '') {
                        jQuery('#txt_Info_Qualifier').validationEngine('showPrompt', 'Incorrect Info Qualifier', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_Info_Qualifier').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//---------------------------------------------
$(function () {
    $("#txt_Info_code").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_SingleWindow_Info_Code",
                data: "{ 'mail': '" + request.term + "' ,'Info_QFR':'" + document.getElementById('txt_Info_Qualifier').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);

                    if (data.d == '') {
                        jQuery('#txt_Info_code').validationEngine('showPrompt', 'Incorrect Info Code', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_Info_code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//------------------------
function CallServerside_txt_Info_code(src, dest) {

    var ctrl = document.getElementById(src);
 
    PageMethods.GetSingleWindow_infotext_bind(ctrl.value, CallSuccess_info_text, CallFailed, dest);
}
function CallSuccess_info_text(res, destCtrl) {
    var data = res;

    document.getElementById("txt_Info_Text").value = data;
}

function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}

$(document).ready(function () {

    $('#btnUpdate,#btnSave,#btn_save_new').click(function () {
        var ImageRefNo = document.getElementById("txt_Image_RefNO").value;
        if (ImageRefNo.length < 16) {

            jAlert('IRN Should be 16 Digit', 'IRN NUMBER', function (r) { document.getElementById("SUP_DOCS").click(); document.getElementById("txt_Image_RefNO").focus(); });
            return false;
        }


    });
});



   