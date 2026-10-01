$(function () {
    $("#txt_GST_Category").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Accounts_Auto_Search.asmx/HSN_SAC_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_GST_Category').validationEngine('showPrompt', 'Incorrect HSN/SAC Category', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_GST_Category').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function CallServerside_HSN_SAC_Category(src) {
    var ctrl = document.getElementById(src);
    PageMethods.Set_HSN_SAC_Category(ctrl.value, CallSuccess_HSN_SAC_Category, CallFailed);
}

function CallSuccess_HSN_SAC_Category(res) {
    if (res == "Yes") {
        document.getElementById('txt_GST_Category').style.border = "1px solid #c8c8c8";
        document.getElementById('hdn_HSN_SAC_chk').value = res;
    }
    else {
        document.getElementById('txt_GST_Category').style.border = "1px solid Red";
        document.getElementById('hdn_HSN_SAC_chk').value = res;
    }
}


function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}




$(function () {
    $("#txt_R2_Income, #txt_R2_Expense, #txt_R3_Income, #txt_R3_Expense").autocomplete({
        source: function (request, response) {
            var sourceField = this.element.attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Accounts_Auto_Search.asmx/GL_Ledger_Income_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#' + sourceField).validationEngine('showPrompt', 'Incorrect GL Ledger', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#' + sourceField).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        },
        minLength: 1
    });
});

function CallServerside_GL_Ledger_Income(src) {
    var ctrl = document.getElementById(src);
    PageMethods.Set_GL_Ledger_Income(ctrl.value, function (res) { CallSuccess_GL_Ledger_Income(res, src); }, CallFailed);
}

function CallSuccess_GL_Ledger_Income(res, fieldId) {
    if (res == "Yes") {
        document.getElementById(fieldId).style.border = "1px solid #c8c8c8";
        document.getElementById('hdn_GL_Income_chk').value = res;
    }
    else {
        document.getElementById(fieldId).style.border = "1px solid Red";
        document.getElementById('hdn_GL_Income_chk').value = res;
    }
}