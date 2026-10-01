
$(function () {
    $("#txt_IGST_LEVY_NOTN").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CETH_Notification_Excise_Master_List_IGST_LEVY_NOTN",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        
                        if (field == 'txt_IGST_LEVY_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect LEVY NOTN No', 'error', 'topRight', true);
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
    $("#txt_IGST_LEVY_EXCEPTION_NOTN").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CETH_Notification_Excise_Master_List_LEVY_EXCEPTION_NOTN",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                       
                        if (field == 'txt_IGST_LEVY_EXCEPTION_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect LEVY EXCEMPTION NOTN No', 'error', 'topRight', true);
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
    $("#txt_IGST_LEVY_COMPENSATION_CESS_NOTN").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CETH_Notification_Excise_Master_List_IGST_CESS_NOTN",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_IGST_LEVY_COMPENSATION_CESS_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect LEVY COMPENSATION CESS NOTN', 'error', 'topRight', true);
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
    $("#txt_IGST_LEVY_EXCEPTION_CC_NOTN").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CETH_Notification_Excise_Master_List_IGST_CC_NOTN",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_IGST_LEVY_EXCEPTION_CC_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect IGST LEVY EXCEPTION CC NOTN', 'error', 'topRight', true);
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
//----------------30-june-2017---------------------------------

$(function () {
    $("#txt_IGST_LEVY_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List_IGST_SLNO_1E",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_IGST_LEVY_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_IGST_LEVY_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect IGST LEVY SLNO', 'error', 'topRight', true);
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
    $("#txt_IGST_LEVY_EXCEPTION_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List_IGST_SLNO_1L",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_IGST_LEVY_EXCEPTION_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_IGST_LEVY_EXCEPTION_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect IGST LEVY_EXCEMPTION SLNO', 'error', 'topRight', true);
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
    $("#txt_IGST_LEVY_COMPENSATION_CESS_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List_IGST_SLNO_2E",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_IGST_LEVY_COMPENSATION_CESS_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect IGST LEVY COMPENSATION CESS SLNO', 'error', 'topRight', true);
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
    $("#txt_IGST_LEVY_EXCEPTION_CC_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List_IGST_SLNO_2L",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_IGST_LEVY_EXCEPTION_CC_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect IGST LEVY LEVY_EXCEMPTION CC SLNO', 'error', 'topRight', true);
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
    $("#txt_IGST_LEVY_UNIT,#txt_IGST_LEVY_COMPENSATION_CESS_UNIT").autocomplete({
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
                       
                        if (field == 'txt_IGST_LEVY_UNIT') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect IGST LEVY UNIT Unit Code', 'error', 'topRight', true);
                        }
                        if (field == 'txt_IGST_LEVY_COMPENSATION_CESS_UNIT') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect IGST LEVY COMPENSATION CESS UNIT Code', 'error', 'topRight', true);
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

//-------------------1--------------------------------------------------------------
function CallServerside_txt_IGST_LEVY_SLNO(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_1E(ctrl.value, ctrl1.value, CallSuccess_txt_IGST_LEVY_SLNO, CallFailed, dest);
}
function CallSuccess_txt_IGST_LEVY_SLNO(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        document.getElementById("txt_IGST_LEVY_RATE").value = before;
        document.getElementById("txt_IGST_LEVY_SPL_Amt").value = after1;
        document.getElementById("txt_IGST_LEVY_UNIT").value = after2;
    }
    else {
        document.getElementById("txt_IGST_LEVY_RATE").value = '';
        document.getElementById("txt_IGST_LEVY_SPL_Amt").value = '';
        document.getElementById("txt_IGST_LEVY_UNIT").value = '';
    }
}
//------------2----------------------------------------------------------

function CallServerside_txt_IGST_LEVY_EXCEPTION_SLNO(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_1L(ctrl.value, ctrl1.value, CallSuccess_txt_IGST_LEVY_EXCEPTION_SLNO, CallFailed, dest);
}
function CallSuccess_txt_IGST_LEVY_EXCEPTION_SLNO(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        document.getElementById("txt_IGST_LEVY_EXCEPTION_RATE").value = before;
    }
    else {
        document.getElementById("txt_IGST_LEVY_EXCEPTION_RATE").value = '';
    }

}
//------------3----------------------------------------------------------

function CallServerside_txt_IGST_LEVY_COMPENSATION_CESS_SLNO(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_2E(ctrl.value, ctrl1.value, CallSuccess_txt_IGST_LEVY_COMPENSATION_CESS_SLNO, CallFailed, dest);
}
function CallSuccess_txt_IGST_LEVY_COMPENSATION_CESS_SLNO(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_RATE").value = before;
        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SPL").value = after1;
        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_UNIT").value = after2;
    }
    else {
        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_RATE").value = '';
        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SPL").value = '';
        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_UNIT").value = '';
    }
}
//------------4----------------------------------------------------------

function CallServerside_txt_IGST_LEVY_EXCEPTION_CC_SLNO(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_2L(ctrl.value, ctrl1.value, CallSuccess_txt_IGST_LEVY_EXCEPTION_CC_SLNO, CallFailed, dest);
}
function CallSuccess_txt_IGST_LEVY_EXCEPTION_CC_SLNO(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_RATE").value = before;
    }
    else {
        document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_RATE").value = '';
    }

}
//----------------------------------------------------------------------
// alert message on some failure
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}