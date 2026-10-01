function CallServerside_Port_of_orgin(src, dest) {
    var ctrl = document.getElementById(src);
    if (ctrl.value != '') {
        PageMethods.Select_Error_Code(ctrl.value, CallSuccess_Error_Code, CallFailed, dest);
    }
    else {
        document.getElementById('txtErr_Desc').value = '';
    }
}
function CallSuccess_Error_Code(res, destCtrl) {
    
    document.getElementById('txtErr_Desc').value = res;
}

function CallFailed(res, destCtrl) {
}

//----------------------------------------------------------------------------------------------------------------------

$(function () {

    $("#txtError_code").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Amendment_Errocode_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtError_code') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Error Code', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#txtError_code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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