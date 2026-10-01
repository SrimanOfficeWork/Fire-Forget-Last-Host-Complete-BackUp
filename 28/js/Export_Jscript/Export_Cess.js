$(function () {
    $("#txtSerial_No").autocomplete({

        source: function (request, response) {
            var aa = document.getElementById("Hdn_RITCNO").value;
            //            var aa = document.getElementById("txtSerial_No").value;
            //                        alert(aa);
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXP_CESS_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'cess_sl':'" + aa + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtSerial_No').validationEngine('showPrompt', 'Incorrect CESS SLNo', 'error', 'topRight', true);

                        //jAlert('Drawback SLNo is Incorrect', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_SLNo').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtSerial_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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



// call server side method
//---------------------EXPORTER CESS----------------------//
function CallServerside_Cess(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    PageMethods.Get_CESS_Details(ctrl.value, CallSuccess_CESS, CallFailed, dest);

}
// calling CESS

// set the destination textbox value with the ContactName
function CallSuccess_CESS(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    //    alert('i');
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];
        var after6 = s[6];

        //alert(before);

        document.getElementById("txtCess_Unit").value = before;
        document.getElementById("txtCess_Rate").value = after1;
        document.getElementById("txtTar_Value").value = after2;
        document.getElementById("txtCess_Value").value = after3;
        document.getElementById("txtCess_Flag").value = after4;
        document.getElementById("txtCess_Qty").value = after5;
        document.getElementById("txtTar_Unit").value = after6;


        if (after2 != '') {

            document.getElementById("txtCess_Value").disabled = true;
            document.getElementById("txtCess_Unit").disabled = true;

        }
        if (after3 != '') {

            document.getElementById("txtTar_Value").disabled = true;
            document.getElementById("txtTar_Unit").disabled = true;
        }

    }
    else {

        document.getElementById("txtCess_Unit").value = "";
        document.getElementById("txtCess_Rate").value = "";
        document.getElementById("txtTar_Value").value = "";
        document.getElementById("txtCess_Value").value = "";
        document.getElementById("txtCess_Flag").value = "";
        document.getElementById("txtCess_Qty").value = "";
        document.getElementById("txtTar_Unit").value = "";

    }
}

