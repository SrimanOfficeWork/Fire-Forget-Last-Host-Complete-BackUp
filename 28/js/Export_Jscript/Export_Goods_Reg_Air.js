function tab_page1() {

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';


}
function tab_page2() {

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';

    document.getElementById("annexureCSea_Package_Iframe").src = "../Goods_Registration/Goods_Registration_Air_Package.aspx";
}
function validate_Export_Goods_Reg_Air_Details() {
    var txtSBNo = document.getElementById("txtSBNo").value;
    if (txtSBNo.length <= 0) {
        jAlert('SB No cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtSBNo").focus(); });

        return false;
    }
    var txtSBDate = document.getElementById("txtSBDate").value;


    if (txtSBDate <= 0) {
        jAlert('SB Date cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtSBDate").focus(); });

        return false;
    }
    if (isDate(txtSBDate)) {

    }
    else {
        jAlert('SB Date is Invalid Date', 'GOODS_REG_AIR', function (r) { document.getElementById("txtSBDate").focus(); });

        return false;
    }



    var ddl_SealType = document.getElementById("ddl_SealType").value;
    if (ddl_SealType.length <= 0) {
        jAlert('Seal Type cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("ddl_SealType").focus(); });

        return false;
    }
    var ddlNatureOfCargo = document.getElementById("ddlNatureOfCargo").value;
    if (ddlNatureOfCargo.length <= 0) {
        jAlert('Nature Of Cargo cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("ddlNatureOfCargo").focus(); });

        return false;
    }



    if (document.getElementById("txtGross_Weight").value == "") {
        jAlert('Gross weight cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtGross_Weight").focus(); });


        return false;
    }
    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtGross_Weight").value.length; i++) {
        temp1 = document.getElementById("txtGross_Weight").value.substring(i, i + 1);
        if (digits.indexOf(temp1) == -1) {
            jAlert('Gross weight Not valid', 'GOODS_REG_AIR', function (r) { document.getElementById("txtGross_Weight").focus(); });


            return false;
        }
    }



    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtNet_Weight").value.length; i++) {
        temp1 = document.getElementById("txtNet_Weight").value.substring(i, i + 1);
        if (digits.indexOf(temp1) == -1) {
            jAlert('Net weight Not valid', 'GOODS_REG_AIR', function (r) { document.getElementById("txtNet_Weight").focus(); });




            return false;
        }
    }
    var tNetWeight;
    tNetWeight = document.getElementById("txtNet_Weight").value;

    if (tNetWeight.length <= 0) {
        jAlert('Net weight cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtNet_Weight").focus(); });

        return false;
    }
    var txtUnit_Of_Measurement = document.getElementById("txtUnit_Of_Measurement").value;
    if (txtUnit_Of_Measurement.length <= 0) {
        jAlert('Unit Code cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtUnit_Of_Measurement").focus(); });

        return false;
    }
    else if (txtUnit_Of_Measurement.length < 3) {
        jAlert('Unit Code should be 3 characters', 'GOODS_REG_AIR', function (r) { document.getElementById("txtUnit_Of_Measurement").focus(); });

        return false;
    }
    var txtTotal_No_Packages = document.getElementById("txtTotal_No_Packages").value;
    if (txtTotal_No_Packages.length <= 0) {
        jAlert('Total No Packages cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtTotal_No_Packages").focus(); });

        return false;
    }

    var txtMawb_No = document.getElementById("txtMawb_No").value;
    if (txtMawb_No.length <= 0) {
        jAlert('MAWB NO cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtMawb_No").focus(); });

        return false;
    }
    var txtMAWB_Date = document.getElementById("txtMAWB_Date").value;


    if (txtMAWB_Date <= 0) {
        jAlert('MAWB Date cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtMAWB_Date").focus(); });

        return false;
    }
    if (isDate(txtMAWB_Date)) {

    }
    else {
        jAlert('MAWB Date is Invalid Date', 'GOODS_REG_AIR', function (r) { document.getElementById("txtMAWB_Date").focus(); });

        return false;
    }

    var txtHawb_No = document.getElementById("txtHawb_No").value;
    if (txtHawb_No.length <= 0) {
        jAlert('HAWB NO cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtHawb_No").focus(); });

        return false;
    }
    var txtHAWB_Date = document.getElementById("txtHAWB_Date").value;


    if (txtHAWB_Date <= 0) {
        jAlert('HAWB Date cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtHAWB_Date").focus(); });

        return false;
    }
    if (isDate(txtHAWB_Date)) {

    }
    else {
        jAlert('HAWB Date is Invalid Date', 'GOODS_REG_AIR', function (r) { document.getElementById("txtHAWB_Date").focus(); });

        return false;
    }
    var txtMarks_Numbers = document.getElementById("txtMarks_Numbers").value;
    if (txtMarks_Numbers.length <= 0) {
        jAlert('Marks_Numbers cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtMarks_Numbers").focus(); });

        return false;
    }


}


$(function () {
    $("#txtUnit_Of_Measurement").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Package_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtUnit_Of_Measurement').validationEngine('showPrompt', 'Incorrect Unit', 'error', 'topRight', true);

                        //jAlert('Package Type is Incorrect', 'ANNEXURE_C_AIR', function (r) { document.getElementById("txtPackageType').focus(); });
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
    $("#txt_GatewayPort").autocomplete({

        source: function (request, response) {

            //            alert(document.getElementById("hdnTransport_mode").value);
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdnTransport_mode").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_GatewayPort').validationEngine('showPrompt', 'Incorrect CustomsHouse', 'error', 'topRight', true);

                        //jAlert('CustomsHouse is Incorrect', 'GENERAL', function (r) { document.getElementById("txtCustomsHouse").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_GatewayPort').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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