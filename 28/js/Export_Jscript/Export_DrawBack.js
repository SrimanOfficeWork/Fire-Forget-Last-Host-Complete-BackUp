$(function () {
    $("#txtDrawback_SLNo").autocomplete({

        source: function (request, response) {
            var aa = document.getElementById("Hdn_RITC_4_digit").value;
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/DrawBack_Master_List_RITCNO",
                //                data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",                                                            
                data: "{ 'mail': '" + request.term + "','RITC_NO': '" + aa + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtDrawback_SLNo').validationEngine('showPrompt', 'Incorrect Drawback SLNo', 'error', 'topRight', true);

                        //jAlert('Drawback SLNo is Incorrect', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_SLNo').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtDrawback_SLNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtDrawback_Unit").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtDrawback_Unit').validationEngine('showPrompt', 'Incorrect Drawback Unit', 'error', 'topRight', true);

                        //jAlert('Drawback Unit is Incorrect', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_Unit').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtDrawback_Unit').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
function validate_Export_Drawback() {
    // if (Page_ClientValidate()) // this will trigger validator
    // {

    var txtDrawback_SLNo;
    txtDrawback_SLNo = document.getElementById("txtDrawback_SLNo").value;

    if (txtDrawback_SLNo.length <= 0) {
        jAlert('Drawback_SLNo cannot be blank', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_SLNo").focus(); });


        return false;
    }
    var txtDrawback_Qty;
    txtDrawback_Qty = document.getElementById("txtDrawback_Qty").value;

    if (txtDrawback_Qty.length <= 0) {
        jAlert('Qty cannot be blank', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_Qty").focus(); });

        return false;
    }

    var txtDrawback_Unit;
    txtDrawback_Unit = document.getElementById("txtDrawback_Unit").value;

    if (txtDrawback_Unit.length <= 0) {
        jAlert('Unit cannot be blank', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_Unit").focus(); });

        return false;
    }
    if (txtDrawback_Unit.length < 3) {
        jAlert('Unit Should be 3 characters', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_Unit").focus(); });

        return false;
    }
    var txtDrawback_Rate;
    txtDrawback_Rate = document.getElementById("txtDrawback_Rate").value;

    if (txtDrawback_Rate.length <= 0) {
        jAlert('Rate cannot be blank', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_Rate").focus(); });

        return false;
    }

    var txtDrawback_Desc;
    txtDrawback_Desc = document.getElementById("txtDrawback_Desc").value;

    if (txtDrawback_Desc.length <= 0) {
        jAlert('Description cannot be blank', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_Desc").focus(); });

        return false;
    }

}
// call server side method
//---------------------IMPORTER----------------------//
function CallServerside_Drawback(src, dest,Qty) {
    var ctrl = document.getElementById(src);
    // call server side method
    //    alert(dest);
    
    var Hdn_ROSL;
    Hdn_ROSL = document.getElementById("Hdn_ROSL").value;
    var comp_id = document.getElementById("hdn_companyID").value;
  
    PageMethods.Get_Drawback_Master(ctrl.value, dest, Qty, Hdn_ROSL, comp_id, CallSuccess_Drawback, CallFailed, dest);

}
// calling Drawback

// set the destination textbox value with the ContactName
function CallSuccess_Drawback(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];
        var after6 = s[6];
        var after7 = s[7];
        var after8 = s[8];
        var after9 = s[9];

        document.getElementById("txtDrawback_Unit").value = before;
        document.getElementById("txtDrawback_No_Of_Unit").value = after1;
        document.getElementById("txtDrawback_Rate").value = after2;
        document.getElementById("txtDrawback_Cap").value = after3;
        document.getElementById("txtDrawback_Desc").value = after4;
        document.getElementById("txtDrawback_Qty").value = after5;

        document.getElementById("txtstate_level_adv_Rate").value = after6;
        document.getElementById("txtstate_level_adv_Amt").value = after7;

        document.getElementById("txtCentral_level_adv_Rate").value = after8;
        document.getElementById("txtCentral_level_adv_Amt").value = after9;
    }
    else {

        document.getElementById("txtDrawback_Unit").value = "";
        document.getElementById("txtDrawback_No_Of_Unit").value = "";
        document.getElementById("txtDrawback_Rate").value = "";
        document.getElementById("txtDrawback_Cap").value = "";
        document.getElementById("txtDrawback_Desc").value = "";
        document.getElementById("txtDrawback_Qty").value = "";
        document.getElementById("txtstate_level_adv_Rate").value = "";
        document.getElementById("txtstate_level_adv_Amt").value = "";
        document.getElementById("txtCentral_level_adv_Rate").value = "";
        document.getElementById("txtCentral_level_adv_Amt").value = "";
    }
}
// calling Drawback
// alert message on some failure
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}