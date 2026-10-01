function validate_Export_Jobbing() {
    // if (Page_ClientValidate()) // this will trigger validator
    // {

    var txtNotification_No;
    txtNotification_No = document.getElementById("txtNotification_No").value;

    if (txtNotification_No.length <= 0) {
        jAlert('Notn.No cannot be blank', 'JOBBING', function (r) { document.getElementById("txtNotification_No").focus(); });

        return false;
    }

    if (txtNotification_No.length < 6) {
        jAlert('Notn.No should be 6 characters', 'JOBBING', function (r) { document.getElementById("txtNotification_No").focus(); });

        return false;
    }
    var txtBE_No;
    txtBE_No = document.getElementById("txtBE_No").value;

    if (txtBE_No.length <= 0) {
        jAlert('BE No cannot be blank', 'JOBBING', function (r) { document.getElementById("txtBE_No").focus(); });

        return false;
    }

    if (document.getElementById("txtBE_Date").value <= 0) {
        jAlert('BE date cannot be blank', 'JOBBING', function (r) { document.getElementById("txtBE_Date").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtBE_Date").value)) {

    }
    else {
        jAlert('BE Date is Invalid Date', 'JOBBING', function (r) { document.getElementById("txtBE_Date").focus(); });

        return false;
    }


    var txtBE_Invoice_SLNo;
    txtBE_Invoice_SLNo = document.getElementById("txtBE_Invoice_SLNo").value;

    if (txtBE_Invoice_SLNo.length <= 0) {
        jAlert('Invoice SLNo cannot be blank', 'JOBBING', function (r) { document.getElementById("txtBE_Invoice_SLNo").focus(); });

        return false;
    }

    var txtBE_Invoice_No;
    txtBE_Invoice_No = document.getElementById("txtBE_Invoice_No").value;

    if (txtBE_Invoice_No.length <= 0) {
        jAlert('Invoice No cannot be blank', 'JOBBING', function (r) { document.getElementById("txtBE_Invoice_No").focus(); });

        return false;
    }
    var txtBE_Item_No;
    txtBE_Item_No = document.getElementById("txtBE_Item_No").value;

    if (txtBE_Item_No.length <= 0) {
        jAlert('Item No cannot be blank', 'JOBBING', function (r) { document.getElementById("txtBE_Item_No").focus(); });

        return false;
    }
    var txtBE_PortCode;
    txtBE_PortCode = document.getElementById("txtBE_PortCode").value;

    if (txtBE_PortCode.length <= 0) {
        jAlert('PortCode cannot be blank', 'JOBBING', function (r) { document.getElementById("txtBE_PortCode").focus(); });

        return false;
    }
//    if (txtBE_PortCode.length < 6) {
//        jAlert('PortCode should be 6 characters', 'JOBBING', function (r) { document.getElementById("txtBE_PortCode").focus(); });

//        return false;
//    }
    var txtQty;
    txtQty = document.getElementById("txtQty").value;

    if (txtQty.length <= 0) {
        jAlert('Qty cannot be blank', 'JOBBING', function (r) { document.getElementById("txtQty").focus(); });

        return false;
    }
    var txtUnit;
    txtUnit = document.getElementById("txtUnit").value;

    if (txtUnit.length <= 0) {
        jAlert('Unit cannot be blank', 'JOBBING', function (r) { document.getElementById("txtUnit").focus(); });

        return false;
    }
    if (txtUnit.length < 3) {
        jAlert('Unit should be 3 characters', 'JOBBING', function (r) { document.getElementById("txtUnit").focus(); });

        return false;
    }

}

//  }
function OpenPopupCustom_House(val) {


    if (document.getElementById("hdfTransport_mode").value != '') {
        var s = document.getElementById("hdfTransport_mode").value;
        OpenPopupCustom_House_Details_Port(s, val);

        return false
    }
}
$(function () {
    $("#txtBE_PortCode").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdfTransport_mode").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtBE_PortCode').validationEngine('showPrompt', 'Incorrect BE PortCode', 'error', 'topRight', true);

                        //jAlert('BE PortCode is Incorrect', 'JOBBING', function (r) { document.getElementById("txtBE_PortCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtBE_PortCode').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtUnit").autocomplete({
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
                        jQuery('#txtUnit').validationEngine('showPrompt', 'Incorrect Unit Code', 'error', 'topRight', true);

                        //jAlert('Unit Code is Incorrect', 'JOBBING', function (r) { document.getElementById("txtUnit').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtUnit').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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