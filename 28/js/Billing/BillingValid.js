$(function () {
    $("#txtExp_Name").autocomplete({
     
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
                        jQuery('#txtExp_Name').validationEngine('showPrompt', 'Incorrect Client Name', 'error', 'topRight', true);

                        //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtExp_Name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function CallServerside_BL_Exp_Name(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

//    alert('cc');

    PageMethods.DropDown_BL_EXP_Name(ctrl.value, CallFailed, dest);
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



// expenses page validation
function validate_Exp() {

    var ddlbrn = document.getElementById("ddlbranch_No").value;
    if (ddlbrn.length <= 0) {
        jAlert('Select Branch', 'Expenses', function (r) { document.getElementById("ddlbranch_No").focus(); });
        return false;
    }
    if (ddlbrn == "--Select--") {
        jAlert('Select Branch', 'Expenses', function (r) {
            document.getElementById("ddlbranch_No").focus();
        });
        return false;
    }

    var ddljob = document.getElementById("ddljobno").value;
    if (ddljob.length <= 0) {
        jAlert('Select Job', 'Expenses', function (r) { document.getElementById("ddljobno").focus(); });
        return false;
    }
    if (ddljob == "--Select--") {
        jAlert('Select Job', 'Expenses', function (r) {
            document.getElementById("ddljobno").focus();
        });
        return false;
    }
    var ExpVouno = document.getElementById("txtExpVoucherNo").value;
    if (ExpVouno.length <= 0) {

        jAlert('Enter Voucher No', 'Expenses', function (r) { document.getElementById("txtExpVoucherNo").focus(); });
        return false;
    }


    var txtDate = document.getElementById("txtDate").value;
    if (txtDate != "") {
        if (isDate(txtDate)) {
        }
        else {
            jAlert('Date is invalid', 'Expenses', function (r) { document.getElementById("txtDate").focus(); });
            return false;
        }
    }
    else {
        jAlert('Enter Date', 'Expenses', function (r) { document.getElementById("txtDate").focus(); });
        return false;
    }

}

// Receipt entry page validation
function validate_Rec() {

    var ddlcust = document.getElementById("ddlCustomer").value;

    if (ddlcust == "--Select--") {
        jAlert('Select Customer', 'Receipt-Entry', function (r) {
            document.getElementById("ddlCustomer").focus();
        });
        return false;
    }

    if (ddlcust.length <= 0) {
        jAlert('Select Customer', 'Receipt-Entry', function (r) {
            document.getElementById("ddlCustomer").focus();
        });
        return false;
    }

    var ddlBrn = document.getElementById("ddlbranch_No").value;
    if (ddlBrn.length <= 0) {
        jAlert('Select Branch', 'Receipt-Entry', function (r) {
            document.getElementById("ddlbranch_No").focus();
        });
        return false;
    }


    var RecVouno = document.getElementById("txtReceiptNo").value;
    if (RecVouno.length <= 0) {

        jAlert('Enter Receipt No', 'Receipt-Entry', function (r) {
            document.getElementById("txtReceiptNo").focus();
        });
        return false;
    }


    var txtDate = document.getElementById("txtDate").value;
    if (txtDate != "") {
        if (isDate(txtDate)) { } else {
            jAlert('Receipt Date is invalid', 'Receipt-Entry', function (r) {
                document.getElementById("txtDate").focus();
            });
            return false;
        }
    } else {
        jAlert('Enter Receipt Date', 'Receipt-Entry', function (r) {
            document.getElementById("txtDate").focus();
        });
        return false;
    }


    var ddlpaymode = document.getElementById("ddlModeofPay").value;
    if (ddlpaymode == '--Select--') {
        jAlert('Select Mode of Payment', 'Receipt-Entry', function (r) {
            document.getElementById("ddlModeofPay").focus();
        });
        return false;
    } else if (ddlpaymode == 'Cash') {

        //var txtChqAmt = document.getElementById("txtChqAmt").value;
        //document.getElementById("txtCashAmt") = txtChqAmt;
        //var cashamt = document.getElementById("txtCashAmt").value;
        var cashamt = document.getElementById("txtChqAmt").value;
        if (cashamt.length <= 0) {
            jAlert('Enter cash Amount', 'Receipt-Entry', function (r) {
                document.getElementById("txtChqAmt").focus();
            });
            return false;
        }
    } else if (ddlpaymode == 'Cheque') {
        var chqno = document.getElementById("txtChqNo").value;
        var chqdate = document.getElementById("txtChqDate").value;
        var chqamt = document.getElementById("txtChqAmt").value;

        if (chqno.length <= 0) {
            jAlert('Enter Cheque number', 'Receipt-Entry', function (r) {
                document.getElementById("txtChqNo").focus();
            });
            return false;
        }
        if (chqdate != "") {
            if (isDate(chqdate)) { } else {
                jAlert('Cheque Date is invalid', 'Receipt-Entry', function (r) {
                    document.getElementById("txtChqDate").focus();
                });
                return false;
            }
        } else {
            jAlert('Enter Cheque Date', 'Receipt-Entry', function (r) {
                document.getElementById("txtChqDate").focus();
            });
            return false;
        }



        if (chqamt.length <= 0) {
            jAlert('Enter Cheque Amount', 'Receipt-Entry', function (r) {
                document.getElementById("txtChqAmt").focus();
            });
            return false;
        }
    } else if (ddlpaymode == 'Net Banking') {
        var NetAmt = document.getElementById("txtChqAmt").value;

        if (NetAmt.length <= 0) {
            jAlert('Enter Net Amount', 'Receipt-Entry', function (r) {
                document.getElementById("txtChqAmt").focus();
            });
            return false;
        }
    }
}


// validation for all reports (Os sts, Profit Sts, receipt rpt, sales rpt)
function validate_Rep() {

    var ddltype = document.getElementById("ddltype").value;
    alert('hjh');
//    if (ddltype == "--Select--") {
//        jAlert('Select Customer', 'Report', function (r) {
//            document.getElementById("ddltype").focus();
//        });
//        return false;
//    }


}


function validate_PrevCrDr() {

    var ddlcust = document.getElementById("ddlCustomerName").value;
    if (ddlcust.length <= 0) {
        jAlert('Select Customer', 'Credit/Debit', function (r) { document.getElementById("ddlCustomerName").focus(); });
        return false;
    }
    if (ddlcust == "--Select--") {
        jAlert('Select Customer', 'Credit/Debit', function (r) {
            document.getElementById("ddlCustomerName").focus();
        });
        return false;
    }



    var txtDate = document.getElementById("txtDate").value;
    if (txtDate != "") {
        if (isDate(txtDate)) {
        }
        else {
            jAlert('Date is invalid', 'Credit/Debit', function (r) { document.getElementById("txtDate").focus(); });
            return false;
        }
    }
    else {
        jAlert('Enter Date', 'Credit/Debit', function (r) { document.getElementById("txtDate").focus(); });
        return false;
    }


    var cr = document.getElementById("txtCredit").value;
    if (cr.length <= 0) {

        jAlert('Enter Credit Amount', 'Credit/Debit', function (r) {
            document.getElementById("txtCredit").focus();
        });
        return false;
    }

    var dr = document.getElementById("txtDebit").value;
    if (dr.length <= 0) {

        jAlert('Enter Credit Amount', 'Credit/Debit', function (r) {
            document.getElementById("txtDebit").focus();
        });
        return false;
    }


}

function validate_PaymentEntry() {

    var ddlcust = document.getElementById("ddlCustomer").value;

    if (ddlcust == "--Select--") {
        jAlert('Select Customer', 'Payment-Entry', function (r) {
            document.getElementById("ddlCustomer").focus();
        });
        return false;
    }

    if (ddlcust.length <= 0) {
        jAlert('Select Customer', 'Payment-Entry', function (r) {
            document.getElementById("ddlCustomer").focus();
        });
        return false;
    }

    var ddlBrn = document.getElementById("ddlbranch_No").value;
    if (ddlBrn.length <= 0) {
        jAlert('Select Branch', 'Payment-Entry', function (r) {
            document.getElementById("ddlbranch_No").focus();
        });
        return false;
    }


    var RecVouno = document.getElementById("txtPaymentNo").value;
    if (RecVouno.length <= 0) {

        jAlert('Enter Payment No', 'Payment-Entry', function (r) {
            document.getElementById("txtPaymentNo").focus();
        });
        return false;
    }


    var txtDate = document.getElementById("txtDate").value;
    if (txtDate != "") {
        if (isDate(txtDate)) { } else {
            jAlert('Payment Date is invalid', 'Payment-Entry', function (r) {
                document.getElementById("txtDate").focus();
            });
            return false;
        }
    } else {
        jAlert('Enter Payment Date', 'Payment-Entry', function (r) {
            document.getElementById("txtDate").focus();
        });
        return false;
    }


    var ddlpaymode = document.getElementById("ddlModeofPay").value;
    if (ddlpaymode == '--Select--') {
        jAlert('Select Mode of Payment', 'Payment-Entry', function (r) {
            document.getElementById("ddlModeofPay").focus();
        });
        return false;
    } else if (ddlpaymode == 'Cash') {

        //var txtChqAmt = document.getElementById("txtChqAmt").value;
        //document.getElementById("txtCashAmt") = txtChqAmt;
        //var cashamt = document.getElementById("txtCashAmt").value;
        var cashamt = document.getElementById("txtChqAmt").value;
        if (cashamt.length <= 0) {
            jAlert('Enter cash Amount', 'Payment-Entry', function (r) {
                document.getElementById("txtChqAmt").focus();
            });
            return false;
        }
    } else if (ddlpaymode == 'Cheque') {
        var chqno = document.getElementById("txtChqNo").value;
        var chqdate = document.getElementById("txtChqDate").value;
        var chqamt = document.getElementById("txtChqAmt").value;

        if (chqno.length <= 0) {
            jAlert('Enter Cheque number', 'Payment-Entry', function (r) {
                document.getElementById("txtChqNo").focus();
            });
            return false;
        }
        if (chqdate != "") {
            if (isDate(chqdate)) { } else {
                jAlert('Cheque Date is invalid', 'Payment-Entry', function (r) {
                    document.getElementById("txtChqDate").focus();
                });
                return false;
            }
        } else {
            jAlert('Enter Cheque Date', 'Payment-Entry', function (r) {
                document.getElementById("txtChqDate").focus();
            });
            return false;
        }



        if (chqamt.length <= 0) {
            jAlert('Enter Cheque Amount', 'Payment-Entry', function (r) {
                document.getElementById("txtChqAmt").focus();
            });
            return false;
        }
    } else if (ddlpaymode == 'Net Banking') {
        var NetAmt = document.getElementById("txtChqAmt").value;

        if (NetAmt.length <= 0) {
            jAlert('Enter Net Amount', 'Payment-Entry', function (r) {
                document.getElementById("txtChqAmt").focus();
            });
            return false;
        }
    }
}


function validate_JournalEntry() {

    var RecVoutype = document.getElementById("txtVoucherType").value;
    if (RecVoutype.length <= 0) {

        jAlert('Enter Voucher Type', 'Journal-Entry', function (r) {
            document.getElementById("txtVoucherType").focus();
        });
        return false;
    }
    var RecVouno = document.getElementById("txtVoucherNo").value;
    if (RecVouno.length <= 0) {

        jAlert('Enter Voucher No', 'Journal-Entry', function (r) {
            document.getElementById("txtVoucherNo").focus();
        });
        return false;
    }



    var txtDate = document.getElementById("txtVoucherDate").value;
    if (txtDate != "") {
        if (isDate(txtDate)) { } else {
            jAlert('Voucher Date is invalid', 'Journal-Entry', function (r) {
                document.getElementById("txtVoucherDate").focus();
            });
            return false;
        }
    } else {
        jAlert('Enter Voucher Date', 'Journal-Entry', function (r) {
            document.getElementById("txtVoucherDate").focus();
        });
        return false;
    }


}


function validate_ContraVoucherEntry() {



    var RecVouno = document.getElementById("txtVoucherNo").value;
    if (RecVouno.length <= 0) {

        jAlert('Enter Voucher No', 'ContraVoucher', function (r) {
            document.getElementById("txtVoucherNo").focus();
        });
        return false;
    }



    var txtDate = document.getElementById("txtVoucherDate").value;
    if (txtDate != "") {
        if (isDate(txtDate)) { } else {
            jAlert('Voucher Date is invalid', 'ContraVoucher', function (r) {
                document.getElementById("txtVoucherDate").focus();
            });
            return false;
        }
    } else {
        jAlert('Enter Voucher Date', 'ContraVoucher', function (r) {
            document.getElementById("txtVoucherDate").focus();
        });
        return false;
    }


}