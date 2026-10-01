function OpenPopupCustom_House(val) {


    if (document.getElementById('hdfTransport_mode').value != '') {
        var s = document.getElementById('hdfTransport_mode').value;
        OpenPopupCustom_House_Details_Port(s, val);

        return false
    }
}

$(function () {
    $("#txtWareHouse_Customs").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtWareHouse_Customs').validationEngine('showPrompt', 'Incorrect Warehouse Customs', 'error', 'topRight', true);

                        //jAlert('Bond Location is Incorrect', 'BOND', function (r) { document.getElementById("txtBondLocation").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtWareHouse_Customs').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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