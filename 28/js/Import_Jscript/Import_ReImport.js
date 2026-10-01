function validate_Import_Reimport() {

    var txtSB_No = document.getElementById('txtSB_No').value;
    if (txtSB_No.length <= 0) {
        jAlert('SB No cannot be blank', 'RE-IMPORT', function (r) { document.getElementById("txtSB_No").focus(); });

        return false;
    }
    var txtSB_Date = document.getElementById('txtSB_Date').value;
    if (txtSB_Date.length <= 0) {
        jAlert('SB Date cannot be blank', 'RE-IMPORT', function (r) { document.getElementById("txtSB_Date").focus(); });

        return false;
    }
    else {
        if (isDate(txtSB_Date)) {

        }
        else {
            jAlert('SB Date is Invalid Date', 'RE-IMPORT', function (r) { document.getElementById("txtSB_Date").focus(); });

            return false;
        }
    }

    var txtSB_InvoiceNo = document.getElementById('txtSB_InvoiceNo').value;

    if (txtSB_InvoiceNo.length <= 0) {
        jAlert('SB Invoice SlNo cannot be blank', 'RE-IMPORT', function (r) { document.getElementById("txtSB_InvoiceNo").focus(); });

        return false;
    }
    var txtSB_Invoice_ItemNo = document.getElementById('txtSB_Invoice_ItemNo').value;
    if (txtSB_Invoice_ItemNo.length <= 0) {
        jAlert('SB Invoice ItemNo cannot be blank', 'RE-IMPORT', function (r) { document.getElementById("txtSB_Invoice_ItemNo").focus(); });

        return false;
    }
    var txtPort_Export = document.getElementById('txtPort_Export').value;
    if (txtPort_Export.length <= 0) {
        jAlert('Port of Export cannot be blank', 'RE-IMPORT', function (r) { document.getElementById("txtPort_Export").focus(); });

        return false;
    }

    if (txtPort_Export.length < 6) {
        jAlert('Port Of License should be 6 Characters', 'RE-IMPORT', function (r) { document.getElementById("txtPort_Export").focus(); });

        return false;
    }

    var Customhouse_chk;
    Customhouse_chk = document.getElementById("hdn_Customhouse_chk").value;

    if (Customhouse_chk != "Yes") {
        document.getElementById('txtPort_Export').style.border = "1px solid Red";
        jAlert('Invalid Customs House Code', 'RE-IMPORT', function (r) { document.getElementById("txtPort_Export").focus(); });
        return false;
    }


    var txtNOTN_No = document.getElementById('txtNOTN_No').value;

    if (txtNOTN_No.length <= 0) {
        jAlert('NOTN_No cannot be blank', 'RE-IMPORT', function (r) { document.getElementById("txtNOTN_No").focus(); });

        return false;
    }
    var txtNOTN_SL_No = document.getElementById('txtNOTN_SL_No').value;

    if (txtNOTN_SL_No.length <= 0) {
        jAlert('NOTN_SL_No cannot be blank', 'RE-IMPORT', function (r) { document.getElementById("txtNOTN_SL_No").focus(); });

        return false;
    }


}


$(function () {
    $("#txtPort_Export").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
//                                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + '' + "'}",

                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtPort_Export').validationEngine('showPrompt', 'Incorrect Port Of Export', 'error', 'topRight', true);
                        document.getElementById("hdn_Customhouse_chk").value = 'No';
                        //jAlert('Port Of Export is Incorrect', 'RE-IMPORT', function (r) { document.getElementById("txtPort_Export").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtPort_Export').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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