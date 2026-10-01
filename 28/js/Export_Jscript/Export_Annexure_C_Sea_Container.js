$(function () {
    $("#txtUnit_Of_Measurement").autocomplete({
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
                        jQuery('#txtUnit_Of_Measurement').validationEngine('showPrompt', 'Incorrect Unit Of Measurement', 'error', 'topRight', true);

                        //jAlert('Unit Of Measurement is Incorrect', 'ANNEXURE_C_CONTAINER', function (r) { document.getElementById('txtUnit_Of_Measurement').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtUnit_Of_Measurement').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function validate_Export_AnnexureC1_Sea_Container() {
    var txtContainerNo = document.getElementById("txtContainerNo").value;
    if (txtContainerNo.length <= 0) {
        jAlert('Container No cannot be blank', 'ANNEXURE_C_CONTAINER', function (r) { document.getElementById("txtContainerNo").focus(); });

        return false;
    }
    var ddlSize = document.getElementById("ddlSize").value;
    if (ddlSize.length <= 0) {
        jAlert('Size cannot be blank', 'ANNEXURE_C_CONTAINER', function (r) { document.getElementById("ddlSize").focus(); });

        return false;
    }
    var ddlType = document.getElementById("ddlType").value;
    if (ddlType.length <= 0) {
        jAlert('Type cannot be blank', 'ANNEXURE_C_CONTAINER', function (r) { document.getElementById("ddlType").focus(); });

        return false;
    }

//    var txtExcise_Seal_No = document.getElementById("txtExcise_Seal_No").value;
//    if (txtExcise_Seal_No.length <= 0) {
//        jAlert('Excise Seal No cannot be blank', 'ANNEXURE_C_CONTAINER', function (r) { document.getElementById("txtExcise_Seal_No").focus(); });

//        return false;
//    }

    var txtSealDate = document.getElementById("txtSealDate").value;

    if (txtSealDate != "") {
        if (isDate(txtSealDate)) {

        }
        else {
            jAlert('Seal Date is Invalid Date', 'ANNEXURE_C_CONTAINER', function (r) { document.getElementById("txtSealDate").focus(); });

            return false;
        }
    }
//    else {
//        jAlert('Seal Date cannot be empty', 'ANNEXURE_C_CONTAINER', function (r) { document.getElementById("txtSealDate").focus(); });


//        return false;
//    }


}