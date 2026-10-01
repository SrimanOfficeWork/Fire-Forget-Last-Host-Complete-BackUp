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

                        //jAlert('Unit Of Measurement is Incorrect', 'ANNEXURE_C_SEA', function (r) { document.getElementById("txtUnit_Of_Measurement').focus(); });
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


$(function () {
    $("#txtUnit_Code").autocomplete({
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
                        if (field == 'txtUnit_Code') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Unit Code', 'error', 'topRight', true);

                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


function tab_page1() {

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';

}
function tab_page2() {

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';

    document.getElementById("annexureCSea_Iframe").src = "../Export/Annexure_C_Sea_Container.aspx";
}
function tab_page3() {


    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';

    document.getElementById("annexureCSea_Package_Iframe").src = "../Export/Annexure_C_Sea_Package.aspx";
}

function validate_Export_AnnexureC1_Sea_Details() {
    var txtFactory_Stuffed = document.getElementById("ddlFactory_Stuffed").value;
    if (txtFactory_Stuffed.length <= 0) {
        jAlert('Factory Stuffed cannot be blank', 'ANNEXURE_C_SEA', function (r) { document.getElementById("ddlFactory_Stuffed").focus(); });

        return false;
    }
    var txtSample_Accompanied = document.getElementById("ddlSample_Accompanied").value;
    if (txtSample_Accompanied.length <= 0) {
        jAlert('Sample Accompanied cannot be blank', 'ANNEXURE_C_SEA', function (r) { document.getElementById("ddlSample_Accompanied").focus(); });

        return false;
    }
    var ddlNatureOfCargo = document.getElementById("ddlNatureOfCargo").value;
    if (ddlNatureOfCargo.length <= 0) {
        jAlert('Nature Of Cargo cannot be blank', 'ANNEXURE_C_SEA', function (r) { document.getElementById("ddlNatureOfCargo").focus(); });

        return false;
    }
    var txtTotal_No_Packages = document.getElementById("txtTotal_No_Packages").value;
    if (txtTotal_No_Packages.length <= 0) {
        if (ddlNatureOfCargo != 'DB Dry Bulk' && ddlNatureOfCargo != 'LB Liquid and Bulk') {
            jAlert('Total No Packages cannot be blank', 'ANNEXURE_C_SEA', function (r) { document.getElementById("txtTotal_No_Packages").focus(); });
            return false;
        }
    }


    if (document.getElementById("txtGross_Weight").value == "") {
        jAlert('Gross weight cannot be blank', 'ANNEXURE_C_SEA', function (r) { document.getElementById("txtGross_Weight").focus(); });


        return false;
    }
    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtGross_Weight").value.length; i++) {
        temp1 = document.getElementById("txtGross_Weight").value.substring(i, i + 1);
        if (digits.indexOf(temp1) == -1) {
            jAlert('Gross weight Not valid', 'ANNEXURE_C_SEA', function (r) { document.getElementById("txtGross_Weight").focus(); });


            return false;
        }
    }

    var GrossWeightType;
    GrossWeightType = document.getElementById("txtUnit_Of_Measurement").value;

    if (GrossWeightType.length <= 0) {

        jAlert('GrossWeight Type cannot be blank', 'ANNEXURE_C_SEA', function (r) { document.getElementById("txtUnit_Of_Measurement").focus(); });

        return false;
    }


    else if (GrossWeightType.length < 3) {
        jAlert('GrossWeight Type should be 3 characters', 'ANNEXURE_C_SEA', function (r) { document.getElementById("txtUnit_Of_Measurement").focus(); });

        return false;
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtNet_Weight").value.length; i++) {
        temp1 = document.getElementById("txtNet_Weight").value.substring(i, i + 1);
        if (digits.indexOf(temp1) == -1) {
            jAlert('Net weight Not valid', 'ANNEXURE_C_SEA', function (r) { document.getElementById("txtNet_Weight").focus(); });




            return false;
        }
    }
    var tNetWeight;
    tNetWeight = document.getElementById("txtNet_Weight").value;

    if (tNetWeight.length <= 0) {
        jAlert('Net weight cannot be blank', 'ANNEXURE_C_SEA', function (r) { document.getElementById("txtNet_Weight").focus(); });

        return false;
    }


    var txtRotationDate = document.getElementById("txtRotationDate").value;

    if (txtRotationDate != "") {
        if (isDate(txtRotationDate)) {

        }
        else {
            jAlert('Rotation Date is Invalid Date', 'ANNEXURE_C_SEA', function (r) { document.getElementById("txtRotationDate").focus(); });

            return false;
        }
    }


}