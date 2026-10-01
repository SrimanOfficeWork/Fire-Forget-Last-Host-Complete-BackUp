function tab_page1() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
}
function tab_page2() {
    document.getElementById('page-1').style.display = 'none';
    document.getElementById('page-2').style.display = 'Block';
    document.getElementById("Export_Branch_to_Branch").src = "../Job_Duplicate/Exp_Branch_to_Branch.aspx";
}

//----------------------------------------------------------------------------------------------------------------------------------------------------

function OpenPopupPort_Master(val) {

    if (document.getElementById('hdfTransport_mode').value != '') {

        OpenPopupPortDetails(val);
        return false
    }
}

function Port_origin(val) {

    $("#txtPortOrigin").keyup(function () {
        $("#txtPortShipment").val($(this).val())
    });
}

$(function () {
    $("#txtPortOrigin,#txtPortShipment").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Port_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtPortOrigin') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Origin', 'error', 'topRight', true);
                        }
                        if (field == 'txtPortShipment') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Shipment', 'error', 'topRight', true);
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

//********************************************* IMPORTER BRANCHWISE SERIAL NO SEARCH BACKUP BEFORE STD TYPE START *******************************





function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}

//-----------------------------------START SCHEME LAOD--------------------------------------//
