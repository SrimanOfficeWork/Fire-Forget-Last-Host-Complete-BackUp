$(function () {
    $('#txtRITCNo').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXPORT_RITC_SEARCH_ALL",
                data: "{ 'mail': '" + request.term + "' ,'code':'" + document.getElementById("txtDesc").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtRITCNo').validationEngine('showPrompt', 'Incorrect RITCNo', 'error', 'topRight', true);

                        //jAlert('RITCNo is Incorrect', 'ITEM', function (r) { document.getElementById("txtRITCNo').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtRITCNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function CallServerside_RITC(src, dest) {
    var ctrl = document.getElementById(src);
//    alert(b);
    PageMethods.GetRITC_code_desc(ctrl.value, CallSuccess_RITCNO, CallFailed, dest);

}
function CallSuccess_RITCNO(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    var data = res;

    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];

//        document.getElementById("txtRITCNo").value = before;
        document.getElementById("txtDesc").value = after1;

    }
}

//***************** GET ITEM DETAILS DESCRIPTION LOAD WITH CORRESPONDING DETAILS FROM PRODUCT MASTER**********************

function CallServerside_RITC_DESC_PRODUCT(src, dest) {
    var ctrl = document.getElementById(src);
    //    alert(b);
    PageMethods.Get_Desc_RITC_PRODUCTMASTER(ctrl.value, CallSuccess_RITC_DESC, CallFailed, dest);

}

function CallSuccess_RITC_DESC(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    var data = res;

    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];

        //        document.getElementById("txtRITCNo").value = before;
        document.getElementById("txtRITCNo").value = after1;

    }
}

function opennew_STR_DETAILS() {
    var txtSTRCode = document.getElementById("txtRITCNo").value;
    var RITCNO = txtSTRCode.substring(0, 2);
    //alert(RITCNO);
    if (RITCNO != '') {
        if (RITCNO.length == 2) {

            Opennew_STR_Details(RITCNO);
            return false
        }
    }
}