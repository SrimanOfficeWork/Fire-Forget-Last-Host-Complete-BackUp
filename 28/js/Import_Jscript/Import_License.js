function OpenPopupImport_Port_House(val) {


    if (document.getElementById('hdfTransport_mode').value != '') {

        var s = document.getElementById('hdfTransport_mode').value;

        OpenPopupCustom_House_Details_Port(s, val);
        return false
    }
}
function validate_Import_License() {

    var txtRegistration_No = document.getElementById('txtRegistration_No').value;
    if (txtRegistration_No.length <= 0) {
        jAlert('Registration No cannot be blank', 'LICENSE', function (r) { document.getElementById("txtRegistration_No").focus(); });

        return false;
    }
    var txtRegistration_Date = document.getElementById('txtRegistration_Date').value;
    if (txtRegistration_Date.length <= 0) {
        jAlert('Registration Date cannot be blank', 'LICENSE', function (r) { document.getElementById("txtRegistration_Date").focus(); });

        return false;
    }
    else {
        if (isDate(txtRegistration_Date)) {

        }
        else {
            jAlert('Registration Date is Invalid Date', 'LICENSE', function (r) { document.getElementById("txtRegistration_Date").focus(); });

            return false;
        }
    }

    var txtLicense_ItemNo = document.getElementById('txtLicense_ItemNo').value;
    if (txtLicense_ItemNo.length <= 0) {
        jAlert('License ItemNo cannot be blank', 'LICENSE', function (r) { document.getElementById("txtLicense_ItemNo").focus(); });

        return false;
    }

    var txtPort_Of_Licenses = document.getElementById('txtPort_Of_Licenses').value;
    if (txtPort_Of_Licenses.length <= 0) {
        jAlert('Port Of License cannot be blank', 'LICENSE', function (r) { document.getElementById("txtPort_Of_Licenses").focus(); });

        return false;
    }
    if (txtPort_Of_Licenses.length < 6) {
        jAlert('Port Of License should be 6 Characters', 'LICENSE', function (r) { document.getElementById("txtPort_Of_Licenses").focus(); });

        return false;
    }

    var Customhouse_chk;
    Customhouse_chk = document.getElementById("hdn_Customhouse_chk").value;

    if (Customhouse_chk != "Yes") {
        document.getElementById('txtPort_Of_Licenses').style.border = "1px solid Red";
        jAlert('Invalid Customs House Code', 'LICENSE', function (r) { document.getElementById("txtPort_Of_Licenses").focus(); });
        return false;
    }

}

$(function () {
    $("#txtPort_Of_Licenses").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",
//                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtPort_Of_Licenses').validationEngine('showPrompt', 'Incorrect Port Of License', 'error', 'topRight', true);
                        document.getElementById("hdn_Customhouse_chk").value = 'No';
                        //jAlert('Port Of License is Incorrect', 'LICENSE', function (r) { document.getElementById("txtPort_Of_Licenses").focus(); });
                        // return false;
                    }
                    else {
                        jQuery('#txtPort_Of_Licenses').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        document.getElementById("hdn_Customhouse_chk").value = 'Yes';
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //////alert(textStatus);
                }
            });
        },
        minLength: 1

    });
    return false;
    scroll: true;
});


$(function () {
    $("#txt_LicenseCurrency").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exchage_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",
                //                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_LicenseCurrency').validationEngine('showPrompt', 'Incorrect Currency', 'error', 'topRight', true);

                        //jAlert('Port Of License is Incorrect', 'LICENSE', function (r) { document.getElementById("txtPort_Of_Licenses").focus(); });
                        // return false;
                    }
                    else {
                        jQuery('#txt_LicenseCurrency').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //////alert(textStatus);
                }
            });
        },
        minLength: 1

    });
    return false;
    scroll: true;
});


function Call__Inv_Currency_Excahnge_Rate(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ieccode = document.getElementById("txt_LicenseCurrency").value;
    if (ieccode.length == 3) {
        PageMethods.GetExchange_Rate_License_Cur(ctrl.value, CallSuccess_Invoice_Cur, CallFailed, dest);
//        Invoice_currency_ExRate();

    }

}

function CallSuccess_Invoice_Cur(res, destCtrl) {

    var data = res;
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');
        
        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];

        document.getElementById("txt_Exrate").value = before;
        document.getElementById("hdn_non_std_effect_dt").value = after1;
        document.getElementById("hdn_non_std_bankname").value = after2;
        document.getElementById("hdn_non_std_cert_no").value = after3;
        document.getElementById("hdn_non_std_cert_dt").value = after4;
        var dest = document.getElementById(destCtrl);
        dest.value = before;
        document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txt_Exrate").value;
    }
    else {
        var dest = document.getElementById(destCtrl);
        dest.value = data;
        if (dest.value.length > 0) {
            document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txt_Exrate").value;
            document.getElementById("txt_Exrate").value = before;
        }
        document.getElementById("hdn_non_std_effect_dt").value = "";
        document.getElementById("hdn_non_std_bankname").value = "";
        document.getElementById("hdn_non_std_cert_no").value = "";
        document.getElementById("hdn_non_std_cert_dt").value = "";

    }
}

function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}
   