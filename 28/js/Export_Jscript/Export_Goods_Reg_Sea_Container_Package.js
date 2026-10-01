
$(function () {
    $("#txt_PckgUQC").autocomplete({
        source: function (request, response) {
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
                        jQuery('#txt_PckgUQC').validationEngine('showPrompt', 'Incorrect Unit Of Measurement', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_PckgUQC').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function validate_Export_AnnexureC1_Sea_Container_Package() {

    var txt_Eqmnt_SerialNo = document.getElementById("txt_Eqmnt_SerialNo").value;
    if (txt_Eqmnt_SerialNo.length <= 0) {
        jAlert('Eqmnt SerialNo cannot be blank', 'GOODS_REG CONTAINER PACKAGE', function (r) { document.getElementById("txt_Eqmnt_SerialNo").focus(); });
        return false;
        document.getElementById("txt_Eqmnt_SerialNo").style.borderColor = "red";
    }

    var txt_Eqmnt_ID = document.getElementById("txt_Eqmnt_ID").value;
    if (txt_Eqmnt_ID.length <= 0) {
        jAlert('Eqmnt ID cannot be blank', 'GOODS_REG_SEA_CONTAINER', function (r) { document.getElementById("txt_Eqmnt_ID").focus(); });
        return false;
    }

    var txt_Eqmnt_Loc = document.getElementById("txt_Eqmnt_Loc").value;
    if (txt_Eqmnt_Loc.length <= 0) {
        jAlert('Eqmnt Loc cannot be blank', 'GOODS_REG_SEA_CONTAINER', function (r) { document.getElementById("txt_Eqmnt_Loc").focus(); });
        return false;
    }

    var txt_PckgFrom = document.getElementById("txt_PckgFrom").value;
    if (txt_PckgFrom.length <= 0) {
        jAlert('Pckg From cannot be blank', 'GOODS_REG_SEA_CONTAINER', function (r) { document.getElementById("txt_PckgFrom").focus(); });
        return false;
    }

    var txt_PckgTo = document.getElementById("txt_PckgTo").value;
    if (txt_PckgTo.length <= 0) {
        jAlert('Pckg To cannot be blank', 'GOODS_REG_SEA_CONTAINER', function (r) { document.getElementById("txt_PckgTo").focus(); });
        return false;
    }

    var txt_PckgCount = document.getElementById("txt_PckgCount").value;
    if (txt_PckgCount.length <= 0) {
        jAlert('Pckg Count cannot be blank', 'GOODS_REG_SEA_CONTAINER', function (r) { document.getElementById("txt_PckgCount").focus(); });
        return false;
    }

    var txt_PckgUQC = document.getElementById("txt_PckgUQC").value;
    if (txt_PckgUQC.length <= 0) {
        jAlert('Pckg UQC cannot be blank', 'GOODS_REG_SEA_CONTAINER', function (r) { document.getElementById("txt_PckgUQC").focus(); });
        return false;
    }

}