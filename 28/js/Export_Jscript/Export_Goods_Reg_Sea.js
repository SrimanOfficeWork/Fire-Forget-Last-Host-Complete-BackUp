

function tab_page1() {

    document.getElementById("page-1").style.display = "block";
    document.getElementById("page-2").style.display = "none";
    document.getElementById("page-3").style.display = "none";
    document.getElementById("page-4").style.display = "none";
    document.getElementById("page-5").style.display = "none";

}
function tab_page2() {

    document.getElementById("page-1").style.display = "none";
    document.getElementById("page-2").style.display = "block";
    document.getElementById("page-3").style.display = "none";
    document.getElementById("page-4").style.display = "none";
    document.getElementById("page-5").style.display = "none";

    document.getElementById("annexureCSea_Container_Iframe").src = "../Goods_Registration/Goods_Registration_Sea_Container.aspx";
}
function tab_page3() {


    document.getElementById("page-1").style.display = "none";
    document.getElementById("page-2").style.display = "none";
    document.getElementById("page-3").style.display = "block";
    document.getElementById("page-4").style.display = "none";
    document.getElementById("page-5").style.display = "none";

    document.getElementById("annexureCSea_Package_Iframe").src = "../Goods_Registration/Goods_Registration_Sea_Package.aspx";
}

function tab_page4() {

    document.getElementById("page-1").style.display = "none";
    document.getElementById("page-2").style.display = "none";
    document.getElementById("page-3").style.display = "none";
    document.getElementById("page-4").style.display = "block";
    document.getElementById("page-5").style.display = "none";

    document.getElementById("annexureCSea_Container_Package_Iframe").src = "../Goods_Registration/Goods_Registration_Sea_ContainerPackage.aspx";
}

function tab_page5() {

    document.getElementById("page-1").style.display = "none";
    document.getElementById("page-2").style.display = "none";
    document.getElementById("page-3").style.display = "none";
    document.getElementById("page-4").style.display = "none";
    document.getElementById("page-5").style.display = "block";

    document.getElementById("annexureCSea_Documents_Iframe").src = "../Goods_Registration/Goods_Registration_Air_Sea_Docs.aspx";
}

function validate_Export_AnnexureC1_Sea_Details() {

    var txtSBNo = document.getElementById("txtSBNo").value;
    if (txtSBNo.length <= 0) {
        jAlert('SB No cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("txtSBNo").focus(); });

        return false;
    }
    var txtSBDate = document.getElementById("txtSBDate").value;


    if (txtSBDate <= 0) {
        jAlert('SB Date cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("txtSBDate").focus(); });

        return false;
    }
    if (isDate(txtSBDate)) {

    }
    else {
        jAlert('SB Date is Invalid Date', 'GOODS_REG_SEA', function (r) { document.getElementById("txtSBDate").focus(); });

        return false;
    }

    var ddl_SealType = document.getElementById("ddl_SealType").value;
    if (ddl_SealType.length <= 0) {
        jAlert('Seal Type cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("ddl_SealType").focus(); });

        return false;
    }
    var ddlNatureOfCargo = document.getElementById("ddlNatureOfCargo").value;
    if (ddlNatureOfCargo.length <= 0) {
        jAlert('Nature Of Cargo cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("ddlNatureOfCargo").focus(); });

        return false;
    }
    //        var txtMarks_Numbers = document.getElementById("txtMarks_Numbers").value;
    //        if (txtMarks_Numbers.length <= 0) {
    //            jAlert('Marks_Numbers cannot be blank', 'GOODS_REG_AIR', function (r) { document.getElementById("txtMarks_Numbers").focus(); });

    //            return false;
    //        }
    var txtTotal_No_Packages = document.getElementById("txtTotal_No_Packages").value;
    if (txtTotal_No_Packages.length <= 0) {
        jAlert('Total No Packages cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("txtTotal_No_Packages").focus(); });

        return false;
    }

    if (ddlNatureOfCargo == "C Containerized" && ddlNatureOfCargo == "CP Containerized")
    {
     jAlert('No of container cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("txtNo_Of_Containers").focus(); });

        return false;
    }
    if (ddlNatureOfCargo == "P Packaged" && ddlNatureOfCargo == "CP Containerized")
     {
         jAlert('No of loose packet cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("txtNo_Of_Loose_Packets").focus(); });

        return false;
    }

    if (document.getElementById("txtGross_Weight").value == "") {
        jAlert('Gross weight cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("txtGross_Weight").focus(); });


        return false;
    }
    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtGross_Weight").value.length; i++) {
        temp1 = document.getElementById("txtGross_Weight").value.substring(i, i + 1);
        if (digits.indexOf(temp1) == -1) {
            jAlert('Gross weight Not valid', 'GOODS_REG_SEA', function (r) { document.getElementById("txtGross_Weight").focus(); });


            return false;
        }
    }

    var GrossWeightType;
    GrossWeightType = document.getElementById("txtUnit_Of_Measurement").value;

    if (GrossWeightType.length <= 0) {
        jAlert('Unit Type cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("txtUnit_Of_Measurement").focus(); });
        return false;
    }


    else if (GrossWeightType.length < 3) {
        jAlert('Unit Type should be 3 characters', 'GOODS_REG_SEA', function (r) { document.getElementById("txtUnit_Of_Measurement").focus(); });
        return false;
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtNet_Weight").value.length; i++) {
        temp1 = document.getElementById("txtNet_Weight").value.substring(i, i + 1);
        if (digits.indexOf(temp1) == -1) {
            jAlert('Net weight Not valid', 'GOODS_REG_SEA', function (r) { document.getElementById("txtNet_Weight").focus(); });
            return false;
        }
    }
    var tNetWeight;
    tNetWeight = document.getElementById("txtNet_Weight").value;

    if (tNetWeight.length <= 0) {
        jAlert('Net weight cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("txtNet_Weight").focus(); });
        return false;
    }


    var txtRotationDate = document.getElementById("txtRotationDate").value;
    if (txtRotationDate != "") {
        if (isDate(txtRotationDate)) {
        }
        else {
            jAlert('Rotation Date is Invalid Date', 'GOODS_REG_SEA', function (r) { document.getElementById("txtRotationDate").focus(); });
            return false;
        }
    }

    var txt_GatewayPort = document.getElementById("txt_GatewayPort").value;
    if (txt_GatewayPort.length <= 0) {
        jAlert('Gateway Port cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("txt_GatewayPort").focus(); });
        return false;
    }

    var txt_WareHouseCode = document.getElementById("txt_WareHouseCode").value;
    if (txt_WareHouseCode.length <= 0) {
        jAlert('WareHouse Code cannot be blank', 'GOODS_REG_SEA', function (r) { document.getElementById("txt_WareHouseCode").focus(); });
        return false;
    }


}

$(function () {

    var dropDownList1 = $('#ddlNatureOfCargo');

    dropDownList1.change(function (e) {
        var selectedValue = $(this).val();

        if (selectedValue != '') {


            document.getElementById("totalpackage_p").style.display = "block";
          
            if (selectedValue == "C Containerized") {

                document.getElementById("package_p").style.display = "block"; //enabled on 14-07-2020
                //document.getElementById("Package_Id").style.display = "none";
                document.getElementById("Container_Id").style.display = "block";//enabled on 14-07-2020
                document.getElementById("container_c").style.display = "block";


            }
            else if (selectedValue == "P Packaged") {
                document.getElementById("container_c").style.display = "block"; //enabled on 14-07-2020
                document.getElementById("Container_Id").style.display = "block"; //enabled on 14-07-2020
                //document.getElementById("Package_Id").style.display = "block";
                document.getElementById("package_p").style.display = "block";


            }
            else if (selectedValue == "CP Containerized") {
                document.getElementById("package_p").style.display = "block";
                document.getElementById("container_c").style.display = "block";
                //document.getElementById("Package_Id").style.display = "block";
                //document.getElementById("Container_Id").style.display = "block";

            }
            else if (selectedValue == "LB Liquid and Bulk" || selectedValue == "DB Dry Bulk") {
                document.getElementById("package_p").style.display = "none";
                document.getElementById("container_c").style.display = "none";
                document.getElementById("totalpackage_p").style.display = "none";
                //document.getElementById("Package_Id").style.style.display = "none";
                //document.getElementById("Container_Id").style.style.display = "none";
            }
        }


    });
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
    $("#txt_WareHouseCode").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Warehouse_code_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_WareHouseCode') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Warehouse Code', 'error', 'topRight', true);
                        }
                        if (field == 'txt_WareHouseCode') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Warehouse Code', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#txt_WareHouseCode').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

