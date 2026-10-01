function validate() {

   
    var BondNo = document.getElementById("txtBondNo").value;
    if (BondNo.length <= 0) {
        jAlert('BondNo cannot be blank', 'BOND', function (r) { document.getElementById("txtBondNo").focus(); });

        return false;
    }

    var BondLOCATION = document.getElementById("txtBondLocation").value;
    if (BondLOCATION.length <= 0) {
        jAlert('Bond Location cannot be blank', 'BOND', function (r) { document.getElementById("txtBondLocation").focus(); });

        return false;
    }
    else if (BondLOCATION.length < 6) {

        jAlert('Bond Location Should be 6 digit', 'GENERAL', function (r) { document.getElementById("txtBondLocation").focus(); });
        return false;
    }

    var Customhouse_chk;
    Customhouse_chk = document.getElementById("hdn_Customhouse_chk").value;
  
    if (Customhouse_chk != "Yes") {
        document.getElementById('txtBondLocation').style.border = "1px solid Red";
        jAlert('Invalid Customs House Code', 'BOND', function (r) { document.getElementById("txtBondLocation").focus(); });
        return false;
    }
}

function OpenPopupCustom_House(val) {


    if (document.getElementById('hdfTransport_mode').value != '') {
        var s = document.getElementById('hdfTransport_mode').value;
        OpenPopupCustom_House_Details_Port(s, val);

        return false
    }
}
$(function () {
    $("#txtBondLocation").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List_NEW",
                //                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtBondLocation').validationEngine('showPrompt', 'Incorrect Bond Location', 'error', 'topRight', true);
                        document.getElementById("hdn_Customhouse_chk").value = 'No';
                        //jAlert('Bond Location is Incorrect', 'BOND', function (r) { document.getElementById("txtBondLocation").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtBondLocation').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        document.getElementById("hdn_Customhouse_chk").value = 'Yes';
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