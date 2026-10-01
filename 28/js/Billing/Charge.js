$(function () {
    $("#txtCharge_Code").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/BL_ChargeCode_Search",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);

                    if (data.d == '') {
                        jQuery('#txtCharge_Code').validationEngine('showPrompt', 'Incorrect Charge Code', 'error', 'topRight', true);

                        //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtCharge_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtCharge_name").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/BL_EXPENSE_Entry_EXPName",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);

                    if (data.d == '') {
                        jQuery('#txtCharge_name').validationEngine('showPrompt', 'Incorrect Cherge Name', 'error', 'topRight', true);

                        //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtCharge_name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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




function CallServerside_BL_ChargeCode(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    PageMethods.DropDown_BL_Charge_Code(ctrl.value, CallFailed, dest);
//    alert('cc');
}



function CallSuccess_Billing_ExpName(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    //    alert(data);
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        //        var after1 = s[1];
        //        var after2 = s[2];
        //        var after3 = s[3];
        //        var after4 = s[4];
        //        var after5 = s[5];
        //        var after6 = s[6];

        //alert(before);

        document.getElementById("txtExp_Name").value = before;
        //        document.getElementById("txtCess_Rate").value = after1;
        //        document.getElementById("txtTar_Value").value = after2;
        //        document.getElementById("txtCess_Value").value = after3;
        //        document.getElementById("txtCess_Flag").value = after4;
        //        document.getElementById("txtCess_Qty").value = after5;
        //        document.getElementById("txtTar_Unit").value = after6;



    }
    else {

        document.getElementById("txtExp_Name").value = "";
        //        document.getElementById("txtCess_Rate").value = "";
        //        document.getElementById("txtTar_Value").value = "";
        //        document.getElementById("txtCess_Value").value = "";
        //        document.getElementById("txtCess_Flag").value = "";
        //        document.getElementById("txtCess_Qty").value = "";
        //        document.getElementById("txtTar_Unit").value = "";

    }
}