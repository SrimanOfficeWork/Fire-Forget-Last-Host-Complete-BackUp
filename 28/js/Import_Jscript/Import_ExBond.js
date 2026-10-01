$(function () {

    $('#chkDirect_Exbonding').click(function (e) {

        var hdn_Direct_Exbonding = $('#hdn_Direct_Exbonding');

        if (this.checked) {

            hdn_Direct_Exbonding.val('Y');

        }
        else {

            hdn_Direct_Exbonding.val('N');

        }
    });



});

$(function () {
    $("#txtExbond_Warehouse_Customs").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtExbond_Warehouse_Customs').validationEngine('showPrompt', 'Incorrect Warehouse Customs', 'error', 'topRight', true);

                        //jAlert('Warehouse Customs is Incorrect', 'EX-BOND', function (r) { document.getElementById("txtExbond_Warehouse_Customs").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtExbond_Warehouse_Customs').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtExbond_NoofPackages_Code").autocomplete({
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
                        jQuery('#txtExbond_NoofPackages_Code').validationEngine('showPrompt', 'Incorrect No of Package Code', 'error', 'topRight', true);

                        //jAlert('No of Packages Code is Incorrect', 'EX-BOND', function (r) { document.getElementById("txtExbond_NoofPackages_Code").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtExbond_NoofPackages_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtExbond_Gross_Weight_Code").autocomplete({
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
                        jQuery('#txtExbond_Gross_Weight_Code').validationEngine('showPrompt', 'Incorrect Gross Weight Code', 'error', 'topRight', true);

                        //jAlert('Gross Weight Code is Incorrect', 'EX-BOND', function (r) { document.getElementById("txtExbond_Gross_Weight_Code").focus(); });
                        // return false;
                    }
                    else {
                        jQuery('#txtExbond_Gross_Weight_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
function validate_Exbond(val) {

    var txtExbond_BENo = document.getElementById('txtExbond_BENo').value;
    var Hdn_BE_TYPE1 = document.getElementById('Hdn_BE_TYPE').value;
    if (txtExbond_BENo.length <= 0) {
        if (Hdn_BE_TYPE1 == 'Ex-Bond') {
            jAlert('IN-Bond-BE No cannot be blank', 'EXBOND', function (r) { document.getElementById("txtExbond_BENo").focus(); });
            return false;
        }
    }

    var txtExbond_BEDate = document.getElementById('txtExbond_BEDate').value;
    if (txtExbond_BEDate.length <= 0) {
        if (Hdn_BE_TYPE1 == 'Ex-Bond') {
            jAlert('IN-Bond-BE Date cannot be blank', 'EXBOND', function (r) { document.getElementById("txtExbond_BEDate").focus(); });
            return false;
        }
    }
    else {
        if (isDate(txtExbond_BEDate)) {

        }
        else {
            jAlert('IN-Bond-BE Date is Invalid Date', 'EXBOND', function (r) { document.getElementById("txtExbond_BEDate").focus(); });

            return false;
        }
    }
//    var txtExbond_BondNo = document.getElementById('txtExbond_BondNo').value;
//    if (txtExbond_BondNo.length <= 0) {
//        jAlert('Bond No cannot be blank', 'EXBOND', function (r) { document.getElementById("txtExbond_BondNo").focus(); });

//        return false;
//    }

//    var txtExbond_BondDate = document.getElementById('txtExbond_BondDate').value;
//    if (txtExbond_BondDate.length <= 0) {
//        jAlert('Bond Date cannot be blank', 'EXBOND', function (r) { document.getElementById("txtExbond_BondDate").focus(); });

//        return false;
//    }
//    else {
//        if (isDate(txtExbond_BondDate)) {

//        }
//        else {
//            jAlert('Bond Date is Invalid Date', 'EXBOND', function (r) { document.getElementById("txtExbond_BondDate").focus(); });

//            return false;
//        }
//    }
    var txtExbond_Warehouse_Customs = document.getElementById('txtExbond_Warehouse_Customs').value;
    if (txtExbond_Warehouse_Customs.length <= 0) {
        if (Hdn_BE_TYPE1 == 'Ex-Bond') {
            jAlert('Warehouse Customs cannot be blank', 'EXBOND', function (r) { document.getElementById("txtExbond_Warehouse_Customs").focus(); });

            return false;
        }
    }
    if (txtExbond_Warehouse_Customs.length < 6) {
        if (Hdn_BE_TYPE1 == 'Ex-Bond') {
            jAlert('Warehouse Customs should be 6 Characters', 'EXBOND', function (r) { document.getElementById("txtExbond_Warehouse_Customs").focus(); });

            return false;
        }
    }


    var txtExbond_Warehouse_Code = document.getElementById('txtExbond_Warehouse_Code').value;
    if (txtExbond_Warehouse_Code.length != 0) {

        if (txtExbond_Warehouse_Code.length > 8) {
            jAlert('Invalid Warehouse Code', 'EXBOND', function (r) { document.getElementById("txtExbond_Warehouse_Code").focus(); });
            return false;
        }
      
    }


    var txtExbond_NoofPackages = document.getElementById('txtExbond_NoofPackages').value;
    if (txtExbond_NoofPackages.length <= 0) {
        jAlert('No of Packages cannot be blank', 'EXBOND', function (r) { document.getElementById("txtExbond_NoofPackages").focus(); });

        return false;
    }
    var txtExbond_NoofPackages_Code = document.getElementById('txtExbond_NoofPackages_Code').value;
    if (txtExbond_NoofPackages_Code.length <= 0) {
        jAlert('No of Packages Code cannot be blank', 'EXBOND', function (r) { document.getElementById("txtExbond_NoofPackages_Code").focus(); });

        return false;
    }
    if (txtExbond_NoofPackages_Code.length < 3) {
        jAlert('No of Packages Code should be 3 Characters', 'EXBOND', function (r) { document.getElementById("txtExbond_NoofPackages_Code").focus(); });

        return false;
    }
    var txtExbond_Gross_Weight = document.getElementById('txtExbond_Gross_Weight').value;
    if (txtExbond_Gross_Weight.length <= 0) {
        jAlert('Gross Weight cannot be blank', 'EXBOND', function (r) { document.getElementById("txtExbond_Gross_Weight").focus(); });

        return false;
    }
    var txtExbond_Gross_Weight_Code = document.getElementById('txtExbond_Gross_Weight_Code').value;
    if (txtExbond_Gross_Weight_Code.length <= 0) {
        jAlert('Gross Weight Code cannot be blank', 'EXBOND', function (r) { document.getElementById("txtExbond_Gross_Weight_Code").focus(); });
        return false;
    }
    if (txtExbond_Gross_Weight_Code.length < 3) {
        jAlert('Gross Weight Code should be 3 Characters', 'EXBOND', function (r) { document.getElementById("txtExbond_Gross_Weight_Code").focus(); });
        return false;
    }

    if (val == 'save') {
        jAlert('Saved Successfully', 'EXBOND', function (r) { document.getElementById("btnSave").focus(); });
    }
    Get_Exbond_Value();

    //               if (document.getElementById("chkDirect_Exbonding").checked == false) {
    //              
    //                   jAlert('DirectExbonding cannot be blank', 'EXBOND', function (r) { document.getElementById("chkDirect_Exbonding").focus(); });

    //                   return false;
    //               }
}

function Get_Exbond_Value() {

    var v1 = document.getElementById('txtExbond_BENo').value;
    var v2 = document.getElementById('txtExbond_BEDate').value;
    var v3 = document.getElementById('txtExbond_BondNo').value;
    var v4 = document.getElementById('txtExbond_BondDate').value;
    var v5 = document.getElementById('txtExbond_Warehouse_Customs').value;
    var v6 = document.getElementById('txtExbond_Warehouse_Code').value;
    var v7 = document.getElementById('txtExbond_NoofPackages').value;
    var v8 = document.getElementById('txtExbond_NoofPackages_Code').value;
    var v9 = document.getElementById('txtExbond_Gross_Weight').value;
    var v10 = document.getElementById('txtExbond_Gross_Weight_Code').value;
    var v11 = document.getElementById('hdn_Direct_Exbonding').value;
    parent.Exbond_Details(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11);
}


$(function () {
    $("#txtExbond_Warehouse_Code").autocomplete({
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
                        if (field == 'txtExbond_Warehouse_Code') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Warehouse Code', 'error', 'topRight', true);
                        }
                        if (field == 'txtExbond_Warehouse_Code') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Warehouse Code', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#txtExbond_Warehouse_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
