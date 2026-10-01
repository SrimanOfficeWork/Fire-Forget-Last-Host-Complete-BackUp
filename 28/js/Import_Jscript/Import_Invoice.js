function tab_page1(val) {

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';


    document.getElementById("MD").className = 'inactive';
    document.getElementById("SD").className = 'inactive';
    document.getElementById("SVBD").className = 'inactive';
    document.getElementById("OD").className = 'inactive';
    document.getElementById("SWD").className = 'inactive';
    document.getElementById("OC").className = 'inactive';

    document.getElementById('hdn_Inner_tab_Menu').value = 'IMD';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
}
function tab_page2(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'MD';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
} 
function OpenPopupCustom_House() {


    if (document.getElementById('hdfTransport_mode').value != '') {

        var s = document.getElementById('hdfTransport_mode').value;

        OpenPopupCustom_House_Details(s);

        return false
    }
}
function tab_page3(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'SD';  

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
}
function tab_page4(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'Block';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'SVBD';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
}
function tab_page5(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'Block';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'OD';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
}

function tab_page6(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'Block';
    document.getElementById("page-7").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'SWD';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
}

function tab_page7(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'Block';

    document.getElementById('hdn_Inner_tab_Menu').value = 'OC';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
}

function Misc_tab() {
    document.getElementById("IMD").click();

}
function validate_Invoice(button_id) {

    document.getElementById("IMD").click();

    if (document.getElementById("txtInvoiceNo").value <= 0) {
        jAlert('Invoice no cannot be blank', 'INVOICE', function (r) {
            document.getElementById("IMD").click();
            document.getElementById("txtInvoiceNo").focus();
        });


        return false;
    }


    if (document.getElementById("txtDate").value <= 0) {
        jAlert('Invoice date cannot be blank', 'INVOICE', function (r) {
            document.getElementById("IMD").click();
            document.getElementById("txtDate").focus();
        });

        return false;
    }
    if (isDate(document.getElementById("txtDate").value)) {

    }
    else {
        jAlert('Invoice date is Invalid Date', 'INVOICE', function (r) {
            document.getElementById("IMD").click();
            document.getElementById("txtDate").focus();
        });

        return false;
    }

    var ddlTerms = document.getElementById("ddlTerms").value;

    if (ddlTerms == '') {
        jAlert('select Invoice Terms', 'INVOICE', function (r) {
            document.getElementById("IMD").click();
            document.getElementById("ddlTerms").focus();
        });
        return false;
    }

    var BEType = document.getElementById('hdn_BEType').value;

    if (BEType == 'SEZ DTA-M') {//"SEZ DTA-M"
        /* -- hide on 04-07-2024
        if (document.getElementById("txtInvoiceCurrency").value != 'INR') {
            jAlert('Invoice Currency Should be INR for SEZ - M', 'INVOICE', function (r) {
                document.getElementById("IMD").click();
                document.getElementById("txtInvoiceCurrency").focus();
            });
            return false;
        }
        */

        if (ddlTerms != 'CIF') {
            jAlert('Terms Should be CIF for SEZ - M', 'INVOICE', function (r) {
                document.getElementById("IMD").click();
                document.getElementById("ddlTerms").focus();
            });
            return false;
        }
    }

    if (document.getElementById("txtInvoiceCurrency").value <= 0) {
        jAlert('Invoice currency cannot be blank', 'INVOICE', function (r) {
            document.getElementById("IMD").click();
            document.getElementById("txtInvoiceCurrency").focus();
        });

        return false;
    }

    var InvoiceCurrency = document.getElementById("txtInvoiceCurrency").value;
    if (InvoiceCurrency.length < 3) {
        jAlert('Invoice currency should be 3 characters', 'INVOICE', function (r) {
            document.getElementById("IMD").click();
            document.getElementById("txtInvoiceCurrency").focus();
        });

        return false;
    }

    var Invoicevalue = document.getElementById("txtInvoiceValue").value;
    if (Invoicevalue.length <= 0) {
        jAlert('Invoice value cannot be blank', 'INVOICE', function (r) {
            document.getElementById("IMD").click();
            document.getElementById("txtInvoiceValue").focus();
        });

        return false;
    }
    //page-2

    if (document.getElementById("txtSupplierName").value <= 0) {
        jAlert('SupplierName cannot be blank', 'INVOICE', function (r) {
            document.getElementById("SD").click();
            document.getElementById("txtSupplierName").focus();
        });

        return false;
    }


    //            if (document.getElementById("txtSupplierAddress").value <= 0) {

    //                jAlert('Supplier Address cannot be blank', 'INVOICE', function (r) {
    //                    document.getElementById("SD").click();
    //                    document.getElementById("txtSupplierAddress").focus();
    //                });

    //                return false;
    //            }

    //            if (document.getElementById("txtSupplierCountryName").value <= 0) {

    //                jAlert('Supplier CountryName cannot be blank', 'INVOICE', function (r) {
    //                    document.getElementById("SD").click();
    //                    document.getElementById("txtSupplierCountryName").focus();
    //                });

    //                return false;
    //            }


    //page-4

    if (document.getElementById("chkSVB_Relation").checked == true) {
        if (document.getElementById("txtSVB_RefNo").value == "") {
            jAlert('SVB_RefNo cannot be blank', 'INVOICE', function (r) {
                document.getElementById("SVBD").click();
                document.getElementById("txtSVB_RefNo").focus();
            });

            return false;
        }
        if (document.getElementById("txtSVBDate").value != "") {
            //                     alert("SVBDate cannot be blank");
            //                    document.getElementById("SVBD").click();
            //                    document.getElementById("txtSVBDate").focus();
            //                    returnfalse;
            //                }
            if (isDate(document.getElementById("txtSVBDate").value)) {

            }
            else {
                jAlert('SVBDate is Invalid Date', 'INVOICE', function (r) {
                    document.getElementById("SVBD").click();
                    document.getElementById("txtSVBDate").focus();
                });


                return false;
            }
        }


        var CustomsHouse = document.getElementById("txtCustomsHouse").value;
        if (CustomsHouse.length <= 0) {
            
            jAlert('SVB Customs Location cannot be blank', 'INVOICE', function (r) { document.getElementById("SVBD").click(); document.getElementById("txtCustomsHouse").focus(); });
            return false;
            document.getElementById('txtCustomsHouse').style.border = "1px solid Red";
        }
        else if (CustomsHouse.length < 6) {

            jAlert('SVB Customs Location Should be 6 digit', 'SVB', function (r) { document.getElementById("SVBD").click(); document.getElementById("txtCustomsHouse").focus(); });
            return false;
            document.getElementById('txtCustomsHouse').style.border = "1px solid Red";
        }

        var Customhouse_chk;
        Customhouse_chk = document.getElementById("hdn_Customhouse_chk").value;

        if (Customhouse_chk != "Yes") {
            document.getElementById('txtCustomsHouse').style.border = "1px solid Red";
            jAlert('Invalid Customs House Code', 'SVB', function (r) { document.getElementById("SVBD").click(); document.getElementById("txtCustomsHouse").focus(); });
            return false;
        }


        var ddlLoadingOn = document.getElementById("ddlLoadingOn").value;

        if (ddlLoadingOn == "") {
            jAlert('Select Loading On', 'INVOICE', function (r) {
                document.getElementById("SVBD").click();
                document.getElementById("ddlLoadingOn").focus();
            });

            return false;

        }
        if (ddlLoadingOn == "Assessable") {

            if (document.getElementById("txtAssesable_Rate").value == "") {
                jAlert('Assessable Rate cannot be blank', 'INVOICE', function (r) {
                    document.getElementById("SVBD").click();
                    document.getElementById("txtAssesable_Rate").focus();
                });

                return false;
            }

            if (document.getElementById("ddlAssesable_Status").value == 0) {
                jAlert('Select Assesable Status', 'INVOICE', function (r) {
                    document.getElementById("SVBD").click();
                    document.getElementById("ddlAssesable_Status").focus();
                });

                return false;
            }

        }

        if (ddlLoadingOn == "Duty") {

            if (document.getElementById("txtDuty_Rate").value == "") {
                jAlert('Duty_Rate cannot be blank', 'INVOICE', function (r) {
                    document.getElementById("SVBD").click();
                    document.getElementById("txtDuty_Rate").focus();
                });

                return false;
            }

            if (document.getElementById("ddlDuty_Status").value == 0) {
                jAlert('Select Duty_Status', 'INVOICE', function (r) {
                    document.getElementById("SVBD").click();
                    document.getElementById("ddlDuty_Status").focus();
                });

                return false;
            }

        }


        if (ddlLoadingOn == "Both") {


            if (document.getElementById("txtAssesable_Rate").value == "") {
                jAlert('Assessable Rate cannot be blank', 'INVOICE', function (r) {
                    document.getElementById("SVBD").click();
                    document.getElementById("txtAssesable_Rate").focus();
                });

                return false;
            }

            if (document.getElementById("ddlAssesable_Status").value == 0) {
                jAlert('Select Assesable Status', 'INVOICE', function (r) {
                    document.getElementById("SVBD").click();
                    document.getElementById("ddlAssesable_Status").focus();
                });

                return false;
            }

            if (document.getElementById("txtDuty_Rate").value == "") {
                jAlert('Duty_Rate cannot be blank', 'INVOICE', function (r) {
                    document.getElementById("SVBD").click();
                    document.getElementById("txtDuty_Rate").focus();
                });

                return false;
            }

            if (document.getElementById("ddlDuty_Status").value == 0) {
                jAlert('Select Duty_Status', 'INVOICE', function (r) {
                    document.getElementById("SVBD").click();
                    document.getElementById("ddlDuty_Status").focus();
                });

                return false;
            }

        }
    }

    if (document.getElementById("txtPurchaseDate").value != "") {

        if (isDate(document.getElementById("txtPurchaseDate").value)) {

        }
        else {
            jAlert('Purchase Date is Invalid Date', 'INVOICE', function (r) {
                document.getElementById("OD").click();
                document.getElementById("txtPurchaseDate").focus();
            });

            return false;
        }
    }
    if (document.getElementById("txtContractDate").value != "") {

        if (isDate(document.getElementById("txtContractDate").value)) {

        }
        else {
            jAlert('Contract Date is Invalid Date', 'INVOICE', function (r) {
                document.getElementById("OD").click();
                document.getElementById("txtContractDate").focus();
            });

            return false;
        }
    }
    if (document.getElementById("txtLCDate").value != "") {

        if (isDate(document.getElementById("txtLCDate").value)) {

        }
        else {
            jAlert('LC Date is Invalid Date', 'INVOICE', function (r) {
                document.getElementById("OD").click();
                document.getElementById("txtLCDate").focus();
            });

            return false;
        }
    }


    //**************************************************************** NEW VALIDATION BY CHITHRA -- START ***********************************************************


    var ExchangeRate = document.getElementById("txtExRate").value;
    var Terms = document.getElementById("ddlTerms").value;
    var Previous_Terms = document.getElementById("hdn_load_Terms").value;
    var hdnCompanyID = document.getElementById("hdnCompany_ID").value;
   
    PageMethods.GetExchange_Rate_Invoice_Cur(document.getElementById("txtInvoiceCurrency").value, CallSuccess_Invoice_Cur, CallFailed, document.getElementById("txtExRate").value);

   
    var chk_Invalid_Cur = document.getElementById("hdn_chk_Invalid_Cur").value;
    var chk_Invalid_FRTCur = document.getElementById("hdn_Invalid_FRT_Cur").value;
    var chk_Invalid_INSCur = document.getElementById("hdn_Invalid_INS_Cur").value;
    var chk_curr = document.getElementById("hdn_chk_curr").value;
    var chk_Invalid_Disc_Cur = document.getElementById("hdn_Invalid_Disc_Cur").value;
    var chk_Invalid_Hss_Cur = document.getElementById("hdn_Invalid_Hss_Cur").value;
    
    var InvoiceCurrency = document.getElementById("txtInvoiceCurrency").value;
    var Miscellaneous_Currency = document.getElementById("txtMiscellaneous_Currency").value;
    var Agency_Currency = document.getElementById("txtAgency_Currency").value;
    var Discount_Currency = document.getElementById("txtDiscount_Currency").value;
    var Freight_Currency = document.getElementById("txtFreight_Currency").value;
    var Insurance_Currency = document.getElementById("txtInsurance_Currency").value;

   

    var Misc_Charges = document.getElementById("txtMiscellaneous_Charges").value;
    var Misc_Exch_Rate = document.getElementById("txtMiscellaneous_Exch_Rate").value;
    if (Misc_Exch_Rate.length == 0)
        Misc_Exch_Rate = 0;
    var mISCexRate = parseFloat(Misc_Exch_Rate)

    

    var Discount_Charges = document.getElementById("txtDiscount_Charges").value;
    var Discount_Exch_Rate = document.getElementById("txtDiscount_Exch_Rate").value;
    if (Discount_Exch_Rate.length == 0)
        Discount_Exch_Rate = 0;
    var DiscexRate = parseFloat(Discount_Exch_Rate)

    

    if (chk_Invalid_Cur == '') {
        jAlert('Invalid - Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("IMD").click(); document.getElementById("txtInvoiceCurrency").focus(); });
        return false;
    }

    if (ExchangeRate.length == 0) {
        jAlert('Exchange Rate cannot be blank', 'INVOICE DETAILS', function (r) { document.getElementById("IMD").click(); document.getElementById("txtExRate").focus(); });
        return false;
    }

    if (Terms.length == 0) {
        jAlert('Terms cannot be blank', 'INVOICE DETAILS', function (r) { document.getElementById("IMD").click(); document.getElementById("ddlTerms").focus(); });
        return false;
    }

    if (Terms.length > 0) {
        if (Terms != 'FOB' && Terms != 'CI' && Terms != 'CF' && Terms != 'CIF') {
            jAlert('Invalid - Terms', 'INVOICE DETAILS', function (r) { document.getElementById("IMD").click(); document.getElementById("ddlTerms").focus(); });
            return false;
        }
    }



    if (Terms == 'CI') {

        var Handling_Charges = document.getElementById("txt_Handling_Charges").value;
        if (Handling_Charges.length == 0)
            Handling_Charges = 0;
        var handling = parseFloat(Handling_Charges)

        var Loading_Charges = document.getElementById("txt_Loading_Charges").value;
        if (Loading_Charges.length == 0)
            Loading_Charges = 0;
        var Loading = parseFloat(Loading_Charges)

        var UnLoading_Charges = document.getElementById("txt_UnLoading_Charges").value;
        if (UnLoading_Charges.length == 0)
            UnLoading_Charges = 0;
        var UnLoading = parseFloat(UnLoading_Charges)


        if (handling == 0) {
            if (document.getElementById("txt_Handling_Charges").value == '') {
                jAlert('"CI" Terms - Charges cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("OC").click(); document.getElementById("txt_Handling_Charges").focus(); });
                return false;
            }
            else {
                jAlert('Should be more than "0".. ', 'Handling Charges', function (r) { document.getElementById("OC").click(); document.getElementById("txt_Handling_Charges").focus(); });
                return false;
            }
        }
        if (Loading == 0) {
            if (document.getElementById("txt_Loading_Charges").value == '') {
                jAlert('"CI" Terms - Charges cannot be blank ', 'Loading Charges', function (r) { document.getElementById("OC").click(); document.getElementById("txt_Loading_Charges").focus(); });
                return false;
            }
            else {
                jAlert('Should be more than "0".. ', 'Loading Charges', function (r) { document.getElementById("OC").click(); document.getElementById("txt_Loading_Charges").focus(); });
                return false;
            }
        }
        if (UnLoading == 0) {
            if (document.getElementById("txt_UnLoading_Charges").value == '') {
                jAlert('"CI" Terms - Charges cannot be blank ', 'UnLoading Charges', function (r) { document.getElementById("OC").click(); document.getElementById("txt_UnLoading_Charges").focus(); });
                return false;
            }
            else {
                jAlert('Should be more than "0"..', 'UnLoading Charges', function (r) { document.getElementById("OC").click(); document.getElementById("txt_UnLoading_Charges").focus(); });
                return false;
            }
        }
    }

   

    if (Miscellaneous_Currency.length == 0) {
        jAlert('Miscellaneous Currency cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtMiscellaneous_Currency").focus(); });
        return false;
    }
    if (Miscellaneous_Currency.length > 0) {
        if (Miscellaneous_Currency.length != 3) {
            jAlert('Invalid Miscellaneous Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtMiscellaneous_Currency").focus(); });
            return false;
        }
    }
    if (Misc_Charges.length != 0) {
        if (mISCexRate == '0') {
            jAlert('MISC ExRate Mandatory ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtMiscellaneous_Exch_Rate").focus(); });
            return false;
        }
    }

    if (Miscellaneous_Currency.length == 3) {
        // PageMethods.GetExchange_Rate(Miscellaneous_Currency, CallSuccess, CallFailed, '');
        //if (this.id == 'btnUpdate') {
        if (button_id == 'btnUpdate') {
            if (chk_curr == '') {
                jAlert('Invalid - MISC Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtMiscellaneous_Currency").focus(); });
                return false;
            }
        }
    }


    if (Discount_Currency.length == 0) {
        jAlert('(Discount Currency cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtDiscount_Currency").focus(); });
        return false;
    }
    if (Discount_Currency.length > 0) {
        if (Discount_Currency.length != 3) {
            jAlert('Invalid Discount Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtDiscount_Currency").focus(); });
            return false;
        }
    }
    if (Discount_Charges.length != 0) {

        if (DiscexRate == '0') {
            jAlert('Discount ExRate Mandatory ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtDiscount_Exch_Rate").focus(); });
            return false;
        }

        if (Discount_Currency.length == 3) {
            //PageMethods.GetExchange_Rate(Discount_Currency, CallSuccess, CallFailed, '');
            //            if (this.id == 'btnUpdate') {
            if (button_id == 'btnUpdate') {
                if (chk_Invalid_Disc_Cur == '') {
                    jAlert('Invalid - Discount Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtDiscount_Currency").focus(); });
                    return false;
                }
            }
        }
    }

    if (Terms == 'CI') {

        var Freight_Charges = document.getElementById("txtFreight_Charges").value;
        var Freight_Exch_Rate = document.getElementById("txtFreight_Exch_Rate").value;
        var Freight_Rate = document.getElementById("txtFreight_Rate").value;

        if (Freight_Currency.length == 0) {
            jAlert('Freight Currency cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Currency").focus(); });
            return false;
        }
        if (Freight_Currency.length > 0) {
            if (Freight_Currency.length != 3) {
                jAlert('Invalid Freight Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Currency").focus(); });
                return false;
            }
        }

        if (Freight_Exch_Rate.length == 0)
            Freight_Exch_Rate = 0;
        var frtexRate = parseFloat(Freight_Exch_Rate)

        if (Freight_Rate.length == 0)
            Freight_Rate = 0;
        var frt_rate = parseFloat(Freight_Rate)

        if (Freight_Charges.length == 0)
            Freight_Charges = 0;
        var frt_amt = parseFloat(Freight_Charges)

        if (document.getElementById("chkMisc").checked == false) {
            if (hdnCompanyID != '125' && hdnCompanyID != '151' && hdnCompanyID != '152') {
                if (frt_amt == '0' && frt_rate == '0') {
                    jAlert('Freight   Rate / Charges cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Rate").focus(); });
                    return false;
                }
            }
        }

        if (frt_amt != 0 || frt_rate != 0) {
            if (frtexRate == '0') {
                jAlert('Freight ExRate Mandatory ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Exch_Rate").focus(); });
                return false;
            }
        }

        if (Freight_Currency.length == 3) {
            PageMethods.GetExchange_Rate(document.getElementById("txtFreight_Currency").value, CallSuccess, CallFailed, 'txtFreight_Exch_Rate');

            //if (this.id == 'btnUpdate') {
            if (button_id == 'btnUpdate') {
                if (Previous_Terms != 'CF') {
                    if (chk_Invalid_FRTCur == '') {
                        jAlert('Invalid - Freight Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Currency").focus(); });
                        return false;
                    }
                }
            }
        }
    }

    if (Terms == 'CF') {

        var Insurance_Charges = document.getElementById("txtInsurance_Charges").value;
        var Insurance_Exch_Rate = document.getElementById("txtInsurance_Exch_Rate").value;
        var Insurance_Rate = document.getElementById("txtInsurance_Rate").value;


        if (Insurance_Currency.length == 0) {
            jAlert('Insurance Currency cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Currency").focus(); });
            return false;
        }
        if (Insurance_Currency.length > 0) {
            if (Insurance_Currency.length != 3) {
                jAlert('Invalid Insurance Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Currency").focus(); });
                return false;
            }
        }
        if (Insurance_Charges.length != 0) {
            if (Insurance_Exch_Rate.length == 0 || Insurance_Exch_Rate == '0.00') {
                jAlert('Insurance ExRate Mandatory ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Exch_Rate").focus(); });
                return false;
            }
        }

        if (Insurance_Exch_Rate.length == 0)
            Insurance_Exch_Rate = 0;
        var Ins_exRate = parseFloat(Insurance_Exch_Rate)

        if (Insurance_Rate.length == 0)
            Insurance_Rate = 0;
        var Ins_rate = parseFloat(Insurance_Rate)

        if (Insurance_Charges.length == 0)
            Insurance_Charges = 0;
        var Ins_amt = parseFloat(Insurance_Charges)

        if (document.getElementById("chkMisc").checked == false) {
            if (hdnCompanyID != '125' && hdnCompanyID != '151' && hdnCompanyID != '152') {
                if (Ins_amt == '0' && Ins_rate == '0') {
                    jAlert('Insurance   Rate / Charges cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Rate").focus(); });
                    return false;
                }
            }
        }


        if (Ins_amt != 0 || Ins_rate != 0) {

            if (Ins_exRate == '0') {
                jAlert('Insurance ExRate Mandatory  ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Exch_Rate").focus(); });
                return false;
            }
        }
      
        if (Insurance_Currency.length == 3) {
            PageMethods.GetExchange_Rate(document.getElementById("txtInsurance_Currency").value, CallSuccess, CallFailed, 'txtInsurance_Exch_Rate');
            // PageMethods.GetExchange_Rate(Insurance_Currency, CallSuccess, CallFailed, '');
            // if (this.id == 'btnUpdate') {
            if (button_id == 'btnUpdate') {
                if (Previous_Terms != 'CI') {
                    if (chk_Invalid_INSCur == '') {
                        jAlert('Invalid - Insurance Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Currency").focus(); });
                        return false;
                    }
                }
            }
        }
    }

    if (Terms == 'FOB') {
        var Freight_Charges = document.getElementById("txtFreight_Charges").value;
        var Freight_Exch_Rate = document.getElementById("txtFreight_Exch_Rate").value;
        var Freight_Rate = document.getElementById("txtFreight_Rate").value;

        if (Freight_Currency.length == 0) {
            jAlert('Freight Currency cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Currency").focus(); });
            return false;
        }
        if (Freight_Currency.length > 0) {
            if (Freight_Currency.length != 3) {
                jAlert('Invalid Freight Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Currency").focus(); });
                return false;
            }
        }
       
        if (Freight_Exch_Rate.length == 0)
            Freight_Exch_Rate = 0;
        var frtexRate = parseFloat(Freight_Exch_Rate)

        if (Freight_Rate.length == 0)
            Freight_Rate = 0;
        var frt_rate = parseFloat(Freight_Rate)

        if (Freight_Charges.length == 0)
            Freight_Charges = 0;
        var frt_amt = parseFloat(Freight_Charges)


        if (document.getElementById("chkMisc").checked == false) {
            if (hdnCompanyID != '125' && hdnCompanyID != '151' && hdnCompanyID != '152') {
                if (frt_amt == '0' && frt_rate == '0') {
                    jAlert('Freight   Rate / Charges cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Rate").focus(); });
                    return false;
                }
            }
        }

        if (frt_amt != 0 || frt_rate != 0) {
            if (frtexRate == '0') {
                jAlert('Freight ExRate Mandatory', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Exch_Rate").focus(); });
                return false;
            }
        }

        if (Freight_Currency.length == 3) {
            PageMethods.GetExchange_Rate(document.getElementById("txtFreight_Currency").value, CallSuccess, CallFailed, 'txtFreight_Exch_Rate');
            //            if (this.id == 'btnUpdate') {
            if (button_id == 'btnUpdate') {
                if (Previous_Terms != 'CF' && Previous_Terms != 'CI') {
                    if (chk_Invalid_FRTCur == '') {
                        jAlert('Invalid - Freight Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Currency").focus(); });
                        return false;
                    }
                }
            }
        }
   

       
        var Insurance_Charges = document.getElementById("txtInsurance_Charges").value;
        var Insurance_Exch_Rate = document.getElementById("txtInsurance_Exch_Rate").value;
        var Insurance_Rate = document.getElementById("txtInsurance_Rate").value;



        if (Insurance_Currency.length == 0) {
            jAlert('Insurance Currency cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Currency").focus(); });
            return false;
        }
        if (Insurance_Currency.length > 0) {
            if (Insurance_Currency.length != 3) {
                jAlert('Invalid Insurance Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Currency").focus(); });
                return false;
            }
        }
        if (Insurance_Charges.length != 0) {
            if (Insurance_Exch_Rate.length == 0 || Insurance_Exch_Rate == '0.00') {
                jAlert('Insurance ExRate Mandatory ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Exch_Rate").focus(); });
                return false;
            }
        }

        if (Insurance_Exch_Rate.length == 0)
            Insurance_Exch_Rate = 0;
        var Ins_exRate = parseFloat(Insurance_Exch_Rate)

        if (Insurance_Rate.length == 0)
            Insurance_Rate = 0;
        var Ins_rate = parseFloat(Insurance_Rate)

        if (Insurance_Charges.length == 0)
            Insurance_Charges = 0;
        var Ins_amt = parseFloat(Insurance_Charges)


        if (document.getElementById("chkMisc").checked == false) {
            if (hdnCompanyID != '125' && hdnCompanyID != '151' && hdnCompanyID != '152') {
                if (Ins_amt == '0' && Ins_rate == '0') {
                    jAlert('Insurance   Rate / Charges cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Rate").focus(); });
                    return false;
                }
            }
        }


        if (Ins_amt != 0 || Ins_rate != 0) {

            if (Ins_exRate == '0') {
                jAlert('Insurance ExRate Mandatory ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Exch_Rate").focus(); });
                return false;
            }
        }

        if (Insurance_Currency.length == 3) {
            PageMethods.GetExchange_Rate(document.getElementById("txtInsurance_Currency").value, CallSuccess, CallFailed, 'txtInsurance_Exch_Rate');
            //if (this.id == 'btnUpdate') {
            if (button_id == 'btnUpdate') {
                if (Previous_Terms != 'CF' && Previous_Terms != 'CI') {
                    if (chk_Invalid_INSCur == '') {
                        jAlert('Invalid - Insurance Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Currency").focus(); });
                        return false;
                    }
                }
            }
        }
    }

    var HighSeaSale_Currency = document.getElementById("txtHighSeaSale_Currency").value;
    var HighSeaSale_Charges = document.getElementById("txtHighSeaSale_Charges").value;
    var HighSeaSale_Exch_Rate = document.getElementById("txtHighSeaSale_Exch_Rate").value;
    if (HighSeaSale_Exch_Rate.length == 0)
        HighSeaSale_Exch_Rate = 0;
    var hss_exRate = parseFloat(HighSeaSale_Exch_Rate)

    if (HighSeaSale_Charges.length != 0) {
        if (HighSeaSale_Currency.length == 0) {
            jAlert('HighSeaSale Currency cannot be blank ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtHighSeaSale_Currency").focus(); });
            return false;
        }
        if (HighSeaSale_Currency.length > 0) {
            if (HighSeaSale_Currency.length != 3) {
                jAlert('Invalid HighSeaSale Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtHighSeaSale_Currency").focus(); });
                return false;
            }
        }
        if (hss_exRate == '0') {
            jAlert('HighSeaSale ExRate Mandatory ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtHighSeaSale_Exch_Rate").focus(); });
            return false;
        }
    }

    var AEC_Code = document.getElementById("txt_Authrzd_Economic_Code").value;
    if (AEC_Code != '') {
        var AEC_Country = document.getElementById("txt_Authrzd_Economic_Country").value;
        var AEC_Role = document.getElementById("txt_Authrzd_Economic_Role").value;

        if (AEC_Country == '') {
            jAlert('Authorized Economic Country - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("SWD").click(); document.getElementById("txt_Authrzd_Economic_Country").focus(); });
            return false;
        }

        if (AEC_Role == '') {
            jAlert('Authorized Economic Role - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("SWD").click(); document.getElementById("txt_Authrzd_Economic_Role").focus(); });
            return false;
        }
    }


    var ThirdPartyName = document.getElementById("txt_ThirdPartyName").value;
    if (ThirdPartyName != '') {
        var ThirdParty_Add1 = document.getElementById("txt_ThirdParty_Add1").value;
        var ThirdParty_Add2 = document.getElementById("txt_ThirdParty_Add2").value;
        var ThirdParty_City = document.getElementById("txt_ThirdParty_City").value;
        var Country_Division = document.getElementById("txt_Country_Division").value;
        var CountryCode = document.getElementById("txt_CountryCode").value;

        if (ThirdParty_Add1 == '') {
            jAlert('ThirdParty Address1 - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("SWD").click(); document.getElementById("txt_ThirdParty_Add1").focus(); });
            return false;
        }

        if (ThirdParty_Add2 == '') {
            jAlert('ThirdParty Address2 - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("SWD").click(); document.getElementById("txt_ThirdParty_Add2").focus(); });
            return false;
        }

        if (ThirdParty_City == '') {
            jAlert('ThirdParty City - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("SWD").click(); document.getElementById("txt_ThirdParty_City").focus(); });
            return false;
        }

        if (Country_Division == '') {
            jAlert('ThirdParty Division - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("SWD").click(); document.getElementById("txt_Country_Division").focus(); });
            return false;
        }

        if (CountryCode == '') {
            jAlert('ThirdParty CountryCode - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("SWD").click(); document.getElementById("txt_CountryCode").focus(); });
            return false;
        }

    }

    var INV_MISC_Currency = document.getElementById("txt_INV_MISC_Currency").value;
    var INV_MISC_Exch_Rate = document.getElementById("txt_INV_MISC_Exch_Rate").value;
    var INV_MISC_Charges = document.getElementById("txt_INV_MISC_Charges").value;
    var INV_MISC_Total_Charge = document.getElementById("txt_INV_MISC_Total_Charge").value;

    if (document.getElementById('chk_active_Inv_Misc').checked) {
        if (INV_MISC_Currency == '') {
            jAlert('INV_MISC Currency - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("MD").click(); document.getElementById("txt_INV_MISC_Currency").focus(); });
            return false;
        }
        if (INV_MISC_Exch_Rate == '') {
            jAlert('INV_MISC Ex.Rate - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("MD").click(); document.getElementById("txt_INV_MISC_Exch_Rate").focus(); });
            return false;
        }
        if (INV_MISC_Charges == '') {
            jAlert('INV_MISC_Charges - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("MD").click(); document.getElementById("txt_INV_MISC_Charges").focus(); });
            return false;
        }
        if (INV_MISC_Total_Charge == '') {
            jAlert('INV MISC Total_Charges - Mandatory ', 'THIRD PARTY', function (r) { document.getElementById("MD").click(); document.getElementById("txt_INV_MISC_Total_Charge").focus(); });
            return false;
        }
    }
  

    //**************************************************************** NEW VALIDATION BY CHITHRA -- END ***********************************************************


    document.getElementById("hdn_button_click").value = '1';
    document.getElementById("hdn_freight_value").value = document.getElementById("txtFreight_Charges").value;
    document.getElementById("hdn_insurance_value").value = document.getElementById("txtInsurance_Charges").value;
    update_value();
}

$(function () {


    $('#txtInvoiceValue').keyup(function () {

        $('#lblInvoiceValue').text($(this).val());
    });
   
    $('#ddlTerms').change(function () {
        $('#lblInvoiceTerms').text($(this).val());
    });
    $('#txtInvoiceNo').keyup(function () {
        $('#lblInvoiceNo').text($(this).val());
    });
    $('#txtDate').keyup(function () {
        $('#lblInvoiceDate').text($(this).val());
    });

    $('#txtDate').change(function () {
        $('#lblInvoiceDate').text($(this).val());
    });

   

});
$(function () {

    var dropDownList1 = $('#ddlTerms');
    var txtFreight_Charges = $('#txtFreight_Charges');
    var txtFreight_Currency = $('#txtFreight_Currency');
    var txtFreight_Exch_Rate = $('#txtFreight_Exch_Rate');
    var txtFreight_Rate = $('#txtFreight_Rate');
    var ImageButton10 = $('#ImageButton10');
    var ImageButton11 = $('#ImageButton11');


    var txtInsurance_Charges = $('#txtInsurance_Charges');
    var txtInsurance_Currency = $('#txtInsurance_Currency');
    var txtInsurance_Exch_Rate = $('#txtInsurance_Exch_Rate');
    var txtInsurance_Rate = $('#txtInsurance_Rate');

    if (txtInsurance_Charges == '') {
        var insuranceRate = $.trim($("#hdn_Cilent_InsuranceRate").val());

        if (insuranceRate != '') {
            $("#txtInsurance_Rate").val(insuranceRate);
        } else {
            $("#txtInsurance_Rate").val('1.1250');
        }
    }

    var txtMiscellaneous_Charges = $('#txtMiscellaneous_Charges');
    var txtMiscellaneous_Currency = $('#txtMiscellaneous_Currency');
    var txtMiscellaneous_Exch_Rate = $('#txtMiscellaneous_Exch_Rate');
    var txtMiscellaneous_Rate = $('#txtMiscellaneous_Rate');

    var txt_Handling_Charges = $('#txt_Handling_Charges');
    var txt_Loading_Charges = $('#txt_Loading_Charges');
    var txt_UnLoading_Charges = $('#txt_UnLoading_Charges');
    var txt_Brokerage = $('#txt_Brokerage');


    $('#txtFreight_Rate').bind('hastext', function () {

        //                txtFreight_Rate.val('');
        //                txtFreight_Charges.val('');
        //                txtFreight_Charges.attr('disabled', true);

    });

    $('#txtFreight_Rate').bind('notext', function () {
        //alert('l');
        //                txtFreight_Rate.val('');
        //                txtFreight_Charges.val('');
        //                txtFreight_Charges.attr('disabled', false);

    });

});
$(function () {
    var textbox = $("#txtFreight_Rate");
    var ResultTextbox = $("#txtFreight_Charges");

    var ddlTerms = $('#ddlTerms');
    var ddlTerm = ddlTerms.val();
    var ImageButton10 = $('#ImageButton10');
    var ImageButton11 = $('#ImageButton11');

    var chkMisc = $('#chkMisc');

    var hdn_currency = document.getElementById("txtInvoiceCurrency").value;
    var hdn_grid_count = $('#hdn_grid_count');
    var hdn_grid_edit = $('#hdn_grid_edit');

    var hdn_INVOICE_SLNO = $('#hdn_INVOICE_SLNO');
    var hdn_Freight_Rate = $('#hdn_Freight_Rate');
    var hdn_Insurance_Rate = $('#hdn_Insurance_Rate');
    var slno = hdn_INVOICE_SLNO.val();
    var hdn_Invoice_Currency_Exrate = document.getElementById("hdn_Invoice_Currency_Exrate").value;
    var txtExRate = $('#txtExRate');
    var hdn_Total_Freight_Value = $('#hdn_Total_Freight_Value');
    var hdn_Total_Insurance_Value = $('#hdn_Total_Insurance_Value');
    var hdn_Invoice_mode_singlr_or_multi = $('#hdn_Invoice_mode_singlr_or_multi');
    var SINGLE_MULTIPLE = hdn_Invoice_mode_singlr_or_multi.val();

    var txtDiscount_Currency = $('#txtDiscount_Currency');
    var txtDiscount_Exch_Rate = $('#txtDiscount_Exch_Rate');
    var txtMiscellaneous_Currency = $('#txtMiscellaneous_Currency');
    var txtMiscellaneous_Exch_Rate = $('#txtMiscellaneous_Exch_Rate');
    var txtAgency_Currency = $('#txtAgency_Currency');
    var txtAgency_Exch_Rate = $('#txtAgency_Exch_Rate');
    var txtDiscount_Currency = $('#txtDiscount_Currency');
    var txtDiscount_Exch_Rate = $('#txtDiscount_Exch_Rate');
    var dropDownList1 = $('#ddlTerms');
    var txtFreight_Charges = $('#txtFreight_Charges');
    var txtFreight_Currency = $('#txtFreight_Currency');
    var txtFreight_Exch_Rate = $('#txtFreight_Exch_Rate');
    var txtInvoiceValue = $('#txtInvoiceValue');
    var txtFreight_Rate = $('#txtFreight_Rate');
    var txtTotal_Frieght = $('#txtTotal_Frieght');
    var txtTotal_Insurance = $('#txtTotal_Insurance');
    var ImageButton10 = $('#ImageButton10');
    var ImageButton11 = $('#ImageButton11');


    var txtInsurance_Charges = $('#txtInsurance_Charges');
    var txtInsurance_Currency = $('#txtInsurance_Currency');
    var txtInsurance_Exch_Rate = $('#txtInsurance_Exch_Rate');
    var txtInsurance_Rate = $('#txtInsurance_Rate');


    var txtMiscellaneous_Charges = $('#txtMiscellaneous_Charges');
    var txtMiscellaneous_Currency = $('#txtMiscellaneous_Currency');
    var txtMiscellaneous_Exch_Rate = $('#txtMiscellaneous_Exch_Rate');
    var txtMiscellaneous_Rate = $('#txtMiscellaneous_Rate');


    var txt_Handling_Charges = $('#txt_Handling_Charges');
    var txt_Loading_Charges = $('#txt_Loading_Charges');
    var txt_UnLoading_Charges = $('#txt_UnLoading_Charges');
    var txt_Brokerage = $('#txt_Brokerage');


    var hdn_FOB_Freight_Rate = $('#hdn_FOB_Freight_Rate');
    var hdn_FOB_Freight_Charge = $('#hdn_FOB_Freight_Charge');
    var hdn_FOB_Freight_Currency = $('#hdn_FOB_Freight_Currency');
    var hdn_FOB_Freight_ExRate = $('#hdn_FOB_Freight_ExRate');

    var hdn_FOB_Insurance_Rate = $('#hdn_FOB_Insurance_Rate');
    var hdn_FOB_Insurance_Charge = $('#hdn_FOB_Insurance_Charge');
    var hdn_FOB_Insurance_Currency = $('#hdn_FOB_Insurance_Currency');
    var hdn_FOB_Insurance_ExRate = $('#hdn_FOB_Insurance_ExRate');

    var hdn_CI_Freight_Rate = $('#hdn_CI_Freight_Rate');
    var hdn_CI_Freight_Charge = $('#hdn_CI_Freight_Charge');
    var hdn_CI_Freight_Currency = $('#hdn_CI_Freight_Currency');
    var hdn_CI_Freight_ExRate = $('#hdn_CI_Freight_ExRate');

    var hdn_CI_Insurance_Rate = $('#hdn_CI_Insurance_Rate');
    var hdn_CI_Insurance_Charge = $('#hdn_CI_Insurance_Charge');
    var hdn_CI_Insurance_Currency = $('#hdn_CI_Insurance_Currency');
    var hdn_CI_Insurance_ExRate = $('#hdn_CI_Insurance_ExRate');

    var hdn_CF_Freight_Rate = $('#hdn_CF_Freight_Rate');
    var hdn_CF_Freight_Charge = $('#hdn_CF_Freight_Charge');
    var hdn_CF_Freight_Currency = $('#hdn_CF_Freight_Currency');
    var hdn_CF_Freight_ExRate = $('#hdn_CF_Freight_ExRate');

    var hdn_CF_Insurance_Rate = $('#hdn_CF_Insurance_Rate');
    var hdn_CF_Insurance_Charge = $('#hdn_CF_Insurance_Charge');
    var hdn_CF_Insurance_Currency = $('#hdn_CF_Insurance_Currency');
    var hdn_CF_Insurance_ExRate = $('#hdn_CF_Insurance_ExRate');

    var hdn_CIF_Freight_Rate = $('#hdn_CIF_Freight_Rate');
    var hdn_CIF_Freight_Charge = $('#hdn_CIF_Freight_Charge');
    var hdn_CIF_Freight_Currency = $('#hdn_CIF_Freight_Currency');
    var hdn_CIF_Freight_ExRate = $('#hdn_CIF_Freight_ExRate');

    var hdn_CIF_Insurance_Rate = $('#hdn_CIF_Insurance_Rate');
    var hdn_CIF_Insurance_Charge = $('#hdn_CIF_Insurance_Charge');
    var hdn_CIF_Insurance_Currency = $('#hdn_CIF_Insurance_Currency');
    var hdn_CIF_Insurance_ExRate = $('#hdn_CIF_Insurance_ExRate');

    var txt_INV_MISC_Currency = $('#txt_INV_MISC_Currency');
    var txt_INV_MISC_Exch_Rate = $('#txt_INV_MISC_Exch_Rate');

    function update_value() {
        // to avoid textbox clear when using jquery//

        $('#hdn_Freight_Rate').val($('#txtFreight_Rate').val());
        $('#hdn_Insurance_Rate').val($('#txtInsurance_Rate').val());
        $('#hdn_FOB_Freight_Currency').val($('#txtFreight_Currency').val());
        $('#hdn_FOB_Insurance_Currency').val($('#txtInsurance_Currency').val());
        $('#hdn_FOB_Freight_ExRate').val($('#txtFreight_Exch_Rate').val());
        $('#hdn_FOB_Insurance_ExRate').val($('#txtInsurance_Exch_Rate').val());

    }
    $('#txtFreight_Currency').keyup, focus(function () {
        update_value();

    });

    function Iframe_Product_Details(val) {

        window.parent.document.getElementById("ifrm").src = val;
    }


    function clear() {


        var txtFreight_Charges = $('#txtFreight_Charges');
        var txtFreight_Currency = $('#txtFreight_Currency');
        var txtFreight_Exch_Rate = $('#txtFreight_Exch_Rate');
        var txtFreight_Rate = $('#txtFreight_Rate');


        var txtInsurance_Charges = $('#txtInsurance_Charges');
        var txtInsurance_Currency = $('#txtInsurance_Currency');
        var txtInsurance_Exch_Rate = $('#txtInsurance_Exch_Rate');
        var txtInsurance_Rate = $('#txtInsurance_Rate');

        txtFreight_Charges.val("");
        txtFreight_Currency.val("");
        txtFreight_Exch_Rate.val("");
        txtFreight_Rate.val("");
        txtInsurance_Charges.val("");
        txtInsurance_Currency.val("");
        txtInsurance_Exch_Rate.val("");
        txtInsurance_Rate.val("");

    }

    function disabled_true() {

        var txtFreight_Charges = $('#txtFreight_Charges');
        var txtFreight_Currency = $('#txtFreight_Currency');
        var txtFreight_Exch_Rate = $('#txtFreight_Exch_Rate');
        var txtFreight_Rate = $('#txtFreight_Rate');



        var txtInsurance_Charges = $('#txtInsurance_Charges');
        var txtInsurance_Currency = $('#txtInsurance_Currency');
        var txtInsurance_Exch_Rate = $('#txtInsurance_Exch_Rate');
        var txtInsurance_Rate = $('#txtInsurance_Rate');
        clear();
        txtFreight_Charges.attr('disabled', true);
        txtFreight_Currency.attr('disabled', true);
        txtFreight_Exch_Rate.attr('disabled', true);
        txtFreight_Rate.attr('disabled', true);
        txtInsurance_Charges.attr('disabled', true);

        txtInsurance_Currency.attr('disabled', true);

        txtInsurance_Exch_Rate.attr('disabled', true);

        txtInsurance_Rate.attr('disabled', true);
    }


    $('#txtTotal_Frieght').keyup(function () {
        hdn_Total_Freight_Value.val(txtTotal_Frieght.val());
    });

    $('#txtTotal_Insurance').keyup(function () {
        hdn_Total_Insurance_Value.val(txtTotal_Insurance.val());
    });

    function Invoice_currency_ExRate() {
        var currency = document.getElementById("txtInvoiceCurrency").value;

        var hdn_Company_ID = document.getElementById("hdn_Company_ID").value;

        //        var grid_edit = document.getElementById("hdn_grid_edit").value;
        //        alert(grid_edit);
        if (hdn_grid_edit.val() == '0' || hdn_grid_edit.val() == '') {

            txtAgency_Currency.val(currency);
            txtAgency_Exch_Rate.val(txtExRate.val());

            txtDiscount_Currency.val(currency);
            txtDiscount_Exch_Rate.val(txtExRate.val());

            txt_INV_MISC_Currency.val(currency);
            txt_INV_MISC_Exch_Rate.val(txtExRate.val());

            /* txtFreight_Currency.val(currency);
            txtFreight_Exch_Rate.val(txtExRate.val());

            txtInsurance_Currency.val(currency);
            txtInsurance_Exch_Rate.val(txtExRate.val());
            
            txtMiscellaneous_Currency.val(currency);
            txtMiscellaneous_Exch_Rate.val(txtExRate.val()); */


            if (document.getElementById("hdnCompany_ID").value == '247') {
                txtFreight_Currency.val('INR');
                txtFreight_Exch_Rate.val('1.00');

                txtInsurance_Currency.val('INR');
                txtInsurance_Exch_Rate.val('1.00');

                txtMiscellaneous_Currency.val(currency);
                txtMiscellaneous_Exch_Rate.val(txtExRate.val());
            }
            else if (document.getElementById("hdnCompany_ID").value == '381') {

                txtFreight_Currency.val('INR');
                txtFreight_Exch_Rate.val('1.00');

                txtInsurance_Currency.val('INR');
                txtInsurance_Exch_Rate.val('1.00');

                txtMiscellaneous_Currency.val('INR');
                txtMiscellaneous_Exch_Rate.val('1.00');
            }
            else {

                txtFreight_Currency.val(currency);
                txtFreight_Exch_Rate.val(txtExRate.val());

                txtInsurance_Currency.val(currency);
                txtInsurance_Exch_Rate.val(txtExRate.val());

                txtMiscellaneous_Currency.val(currency);
                txtMiscellaneous_Exch_Rate.val(txtExRate.val());
            }


            hdn_Invoice_Currency_Exrate = txtExRate.val();

            //hdn_FOB_Freight_Rate.val(txtFreight_Rate.val());
            //hdn_FOB_Freight_Charge.val(txtFreight_Charges.val());

            hdn_FOB_Freight_Currency.val(txtFreight_Currency.val());
            hdn_FOB_Freight_ExRate.val(txtFreight_Exch_Rate.val());


            //hdn_FOB_Insurance_Rate.val(txtInsurance_Rate.val());
            //hdn_FOB_Insurance_Charge.val(txtInsurance_Charges.val());
            hdn_FOB_Insurance_Currency.val(txtInsurance_Currency.val());
            hdn_FOB_Insurance_ExRate.val(txtInsurance_Exch_Rate.val());

            //hdn_CI_Freight_Rate.val(txtFreight_Rate.val());
            //hdn_CI_Freight_Charge.val(txtFreight_Charges.val());
            hdn_CI_Freight_Currency.val(txtFreight_Currency.val());
            hdn_CI_Freight_ExRate.val(txtFreight_Exch_Rate.val());

            //hdn_CF_Insurance_Rate.val(txtInsurance_Rate.val());
            //hdn_CF_Insurance_Charge.val(txtInsurance_Charges.val());
            hdn_CF_Insurance_Currency.val(txtInsurance_Currency.val());
            hdn_CF_Insurance_ExRate.val(txtInsurance_Exch_Rate.val());

        }

        var selectedValue = dropDownList1.val();
        if (selectedValue == 'FOB') {

        }
        else if (selectedValue == 'CI') {
            txtInsurance_Rate.val('');
            txtInsurance_Currency.val('');
            txtInsurance_Charges.val('');
            txtInsurance_Exch_Rate.val('');
        }
        else if (selectedValue == 'CF') {
            txtFreight_Rate.val('');
            txtFreight_Charges.val('');
            txtFreight_Currency.val('');
            txtFreight_Exch_Rate.val('');
        } else if (selectedValue == 'CIF') {
            disabled_true();

        }
        update_value();
    }


    $('#txtInvoiceCurrency').bind('keyup change keydown focus', function () {
        $('#lblInvoiceCurrency').text($(this).val().toUpperCase());
        $('#txt_INV_MISC_Currency').text($(this).val().toUpperCase());
        Invoice_currency_ExRate();
    });
    $('#txtExRate').bind('keyup change keydown focus', function () {

        Invoice_currency_ExRate();
    });
    //------------change----------------------------------//
    $('#txtMiscellaneous_Rate').bind('blur change keyup keydown focus', function () {
        mis_rate();
    });
    $('#txtAgency_Rate').bind('blur change keyup keydown focus', function () {
        agency_rate();
    });
    $('#txtDiscount_Rate').bind('blur change keyup keydown focus', function () {
        discount_rate();
    });
    $('#txtLoading_Rate').bind('blur change keyup keydown focus', function () {
        loading_rate();
    });
    $('#txtHighSeaSale_Rate').bind('blur change keyup keydown focus', function () {
        hss_rate();
    });
    //------------change----------------------------------//


    function mis_rate() {
        var Mis_Rate = document.getElementById("txtMiscellaneous_Rate").value;
        var inv_val = txtInvoiceValue.val();
        if (Mis_Rate != '' && Mis_Rate != '0' && Mis_Rate != '0.00' && Mis_Rate != '0.0000') {
            if (inv_val != '') {

                var Result1;
                Result1 = (parseFloat(Mis_Rate) / 100) * parseInt(txtInvoiceValue.val(), 10);
                document.getElementById("txtMiscellaneous_Charges").value = Result1;

            }
        }
    }

    function agency_rate() {
        var Mis_Rate = document.getElementById("txtAgency_Rate").value;

        var inv_val = txtInvoiceValue.val();
        if (Mis_Rate != '' && Mis_Rate != '0' && Mis_Rate != '0.00' && Mis_Rate != '0.0000') {
            if (inv_val != '') {

                var Result1;
                Result1 = (parseFloat(Mis_Rate) / 100) * parseInt(txtInvoiceValue.val(), 10);
                document.getElementById("txtAgency_Charges").value = Result1;

            }
        }
    }

    function discount_rate() {
        var Mis_Rate = document.getElementById("txtDiscount_Rate").value;

        var inv_val = txtInvoiceValue.val();
        if (Mis_Rate != '' && Mis_Rate != '0' && Mis_Rate != '0.00' && Mis_Rate != '0.0000') {
            if (inv_val != '') {

                var Result1;
                Result1 = (parseFloat(Mis_Rate) / 100) * parseInt(txtInvoiceValue.val(), 10);
                document.getElementById("txtDiscount_Charges").value = Result1;

            }
        }
    }

    function loading_rate() {
        var Mis_Rate = document.getElementById("txtLoading_Rate").value;

        var inv_val = txtInvoiceValue.val();
        if (Mis_Rate != '' && Mis_Rate != '0' && Mis_Rate != '0.00' && Mis_Rate != '0.0000') {
            if (inv_val != '') {

                var Result1;
                Result1 = (parseFloat(Mis_Rate) / 100) * parseInt(txtInvoiceValue.val(), 10);
                document.getElementById("txtLoading_Charges").value = Result1;

            }
        }
    }


    function hss_rate() {
        var Mis_Rate = document.getElementById("txtHighSeaSale_Rate").value;

        var Inv_ExRate = document.getElementById("txtExRate").value;
        var Inv_Cur = document.getElementById("txtInvoiceCurrency").value;

        var inv_val = txtInvoiceValue.val();
        if (Mis_Rate != '' && Mis_Rate != '0' && Mis_Rate != '0.00' && Mis_Rate != '0.0000') {
            if (inv_val != '') {

                var Result1;

                if (Inv_Cur != 'JPY') {

                    //                Result1 = (parseFloat(Mis_Rate) / 100) * parseInt(txtInvoiceValue.val(), 10);
                    Result1 = (Math.round(parseFloat(txtInvoiceValue.val()) * parseFloat(Inv_ExRate) * parseFloat(Mis_Rate), 2)) / 100;

                    document.getElementById("txtHighSeaSale_Charges").value = Result1;
                }
                else {
                    var Ex_jpy;
                    Ex_jpy = parseFloat(Inv_ExRate) / 100
                    Result1 = (Math.round(parseFloat(txtInvoiceValue.val()) * parseFloat(Ex_jpy) * parseFloat(Mis_Rate), 2)) / 100;

                    document.getElementById("txtHighSeaSale_Charges").value = Result1;
                }

            }
        }
    }
    $([txtInvoiceValue[0]]).change(function () {

        hdn_Invoice_Currency_Exrate = txtExRate.val();

        var currency = document.getElementById("txtInvoiceCurrency").value;
        //var grid_edit = document.getElementById("hdn_grid_edit").value;

        //var grid_edit = hdn_grid_edit.val();

        if (hdn_grid_edit.val() == '0' || hdn_grid_edit.val() == '') {



            txtAgency_Currency.val(currency);
            txtAgency_Exch_Rate.val(txtExRate.val());

            txtDiscount_Currency.val(currency);
            txtDiscount_Exch_Rate.val(txtExRate.val());

            txt_INV_MISC_Currency.val(currency);
            txt_INV_MISC_Exch_Rate.val(txtExRate.val());

            /* txtFreight_Currency.val(currency);
            txtFreight_Exch_Rate.val(txtExRate.val());

            txtInsurance_Currency.val(currency);
            txtInsurance_Exch_Rate.val(txtExRate.val()); 
            
            txtMiscellaneous_Currency.val(currency);
            txtMiscellaneous_Exch_Rate.val(txtExRate.val());*/

            if (document.getElementById("hdnCompany_ID").value == '247') {
                txtFreight_Currency.val('INR');
                txtFreight_Exch_Rate.val('1.00');

                txtInsurance_Currency.val('INR');
                txtInsurance_Exch_Rate.val('1.00');

                txtMiscellaneous_Currency.val(currency);
                txtMiscellaneous_Exch_Rate.val(txtExRate.val());
            }
            else if (document.getElementById("hdnCompany_ID").value == '381') {

                txtFreight_Currency.val('INR');
                txtFreight_Exch_Rate.val('1.00');

                txtInsurance_Currency.val('INR');
                txtInsurance_Exch_Rate.val('1.00');

                txtMiscellaneous_Currency.val('INR');
                txtMiscellaneous_Exch_Rate.val('1.00');
            }
            else {
                txtFreight_Currency.val(currency);
                txtFreight_Exch_Rate.val(txtExRate.val());

                txtInsurance_Currency.val(currency);
                txtInsurance_Exch_Rate.val(txtExRate.val());

                txtMiscellaneous_Currency.val(currency);
                txtMiscellaneous_Exch_Rate.val(txtExRate.val());
            }
        }

        slno = hdn_INVOICE_SLNO.val();
        SINGLE_MULTIPLE = hdn_Invoice_mode_singlr_or_multi.val();

        if (document.getElementById("chkMisc").checked == true) {

            if (slno == '') {
                var grid_count = hdn_grid_count.val();

                if (grid_count == '0') {
                    textbox.val('20.0000');
                    //txtInsurance_Rate.val('1.1250');//hide on 07-11-2025 by Chithra
                   
                    var insuranceRate = $.trim($("#hdn_Cilent_InsuranceRate").val());
                   
                    if (insuranceRate != '') {
                        $("#txtInsurance_Rate").val(insuranceRate);
                    } else {
                        $("#txtInsurance_Rate").val('1.1250');
                    }

                    var Result1, Result2;
                    //Result1 = (parseFloat(textbox.val()) / 100) * parseInt(txtInvoiceValue.val(), 10);
                    Result1 = parseFloat(txtInvoiceValue.val()) * (parseFloat(textbox.val()) / 100);
                    ResultTextbox.val(roundNumber(Result1, 2));
                    //Result2 = (parseFloat(txtInsurance_Rate.val()) / 100) * parseInt(txtInvoiceValue.val(), 10);
                    Result2 = parseFloat(txtInvoiceValue.val()) * (parseFloat(txtInsurance_Rate.val()) / 100);

                    txtInsurance_Charges.val(roundNumber(Result2, 2));

                }
                else {

                }
            }
            else if (slno == '1') {
                if (SINGLE_MULTIPLE == 'M') {
                    textbox.val('20.0000');
                    //txtInsurance_Rate.val('1.1250');//hide on 07-11-2025 by Chithra
                   
                    var insuranceRate = $.trim($("#hdn_Cilent_InsuranceRate").val());
                   
                    if (insuranceRate != '') {
                        $("#txtInsurance_Rate").val(insuranceRate);
                    } else {
                        $("#txtInsurance_Rate").val('1.1250');
                    }
                    var Result1, Result2;
                    //Result1 = (parseFloat(textbox.val()) / 100) * parseInt(txtInvoiceValue.val(), 10);
                    Result1 = parseFloat(txtInvoiceValue.val()) * (parseFloat(textbox.val()) / 100);

                    //ResultTextbox.val(Result1);
                    //Result2 = (parseFloat(txtInsurance_Rate.val()) / 100) * parseInt(txtInvoiceValue.val(), 10);
                    Result2 = parseFloat(txtInvoiceValue.val()) * (parseFloat(txtInsurance_Rate.val()) / 100);

                    //txtInsurance_Charges.val(Result2);
                    txtTotal_Frieght.val(roundNumber(Result1, 4));
                    txtTotal_Insurance.val(roundNumber(Result2, 4));
                }
            }
        }
        else {

            var Result1, Result2;

            if (ResultTextbox.val() == '') {
                textbox.val('20.0000');
                // Result1 = parseFloat(txtInvoiceValue.val()) * (parseFloat(textbox.val()) / 100);

                if (document.getElementById("hdnCompany_ID").value == '247') {

                    var ff = parseFloat(txtInvoiceValue.val() * textbox.val() / 100);
                    Result1 = parseFloat(ff * document.getElementById("txtExRate").value);
                }
                else {
                    Result1 = parseFloat(txtInvoiceValue.val()) * (parseFloat(textbox.val()) / 100);
                }


                ResultTextbox.val(roundNumber(Result1, 2));
            }

            if (txtInsurance_Charges.val() == '') {
                //txtInsurance_Rate.val('1.1250');//hide on 07-11-2025 by Chithra

                var insuranceRate = $.trim($("#hdn_Cilent_InsuranceRate").val());

                if (insuranceRate != '') {
                    $("#txtInsurance_Rate").val(insuranceRate);
                } else {
                    $("#txtInsurance_Rate").val('1.1250');
                }

                if (document.getElementById("hdnCompany_ID").value == '247') {

                    var gg = parseFloat(txtInvoiceValue.val() * txtInsurance_Rate.val() / 100);
                    Result2 = parseFloat(gg * document.getElementById("txtExRate").value);
                }
                else {
                    Result2 = parseFloat(txtInvoiceValue.val()) * (parseFloat(txtInsurance_Rate.val()) / 100);
                }

                // txtInsurance_Charges.val(roundNumber(Result2, 2));
            }
        }

        get_value();
        var selectedValue = dropDownList1.val();
        if (selectedValue == 'FOB') {

        }
        else if (selectedValue == 'CI') {
            txtInsurance_Rate.val('');
            txtInsurance_Currency.val('');
            txtInsurance_Charges.val('');
            txtInsurance_Exch_Rate.val('');
        }
        else if (selectedValue == 'CF') {
            txtFreight_Rate.val('');
            txtFreight_Charges.val('');
            txtFreight_Currency.val('');
            txtFreight_Exch_Rate.val('');
        } else if (selectedValue == 'CIF') {
            disabled_true();

        }

        $('#lblInvoiceValue').text($(this).val());
        var inv = txtInvoiceValue.val();
        if (inv == '') {
            txtFreight_Charges.val('');
            txtInsurance_Charges.val('');
        }
        update_value();
    });

    $('#txtFreight_Charges').bind('keyup change focus', function () {

        get_value();
        var freight_charge = txtFreight_Charges.val();

        if (freight_charge != '' || freight_charge == '0' || freight_charge == '0.00' || freight_charge == 'NAN') {
            txtFreight_Rate.val('0.00');
        }
        else {
            txtFreight_Rate.val('20.0000');

        }
        hdn_Total_Freight_Value.val(txtTotal_Frieght.val());
        hdn_Total_Insurance_Value.val(txtTotal_Insurance.val());
    });

    $('#txtInsurance_Charges').bind('keyup change focus', function () {

        get_value();
        var insurance_charge = txtInsurance_Charges.val();

        if (insurance_charge != '' || insurance_charge == '0' || insurance_charge == '0.00' || insurance_charge == 'NAN') {
            txtInsurance_Rate.val('0.00');
        }
        else {
            txtInsurance_Rate.val('1.1250');

        }
        hdn_Total_Freight_Value.val(txtTotal_Frieght.val());
        hdn_Total_Insurance_Value.val(txtTotal_Insurance.val());
    });

    $('#txtTotal_Frieght').bind('keyup change focus', function () {

        get_value();

        var freight_charge = txtTotal_Frieght.val();

        if (freight_charge != '' || freight_charge == '0' || freight_charge == '0.00') {
            txtFreight_Rate.val('0.00');
        }
        else {
            txtFreight_Rate.val('20.0000');

        }
        hdn_Total_Freight_Value.val(txtTotal_Frieght.val());
        hdn_Total_Insurance_Value.val(txtTotal_Insurance.val());
    });
    $('#txtTotal_Insurance').bind('keyup change focus', function () {

        get_value();
        var insurance_charge = txtTotal_Insurance.val();

        if (insurance_charge != '' || insurance_charge == '0' || insurance_charge == '0.00') {
            txtInsurance_Rate.val('0.00');
        }
        else {
            txtInsurance_Rate.val('1.1250');

        }
        hdn_Total_Freight_Value.val(txtTotal_Frieght.val());
        hdn_Total_Insurance_Value.val(txtTotal_Insurance.val());
    });


    function get_value() {

        hdn_FOB_Freight_Rate.val(txtFreight_Rate.val());
        hdn_FOB_Freight_Charge.val(txtFreight_Charges.val());
        hdn_FOB_Freight_Currency.val(txtFreight_Currency.val());
        hdn_FOB_Freight_ExRate.val(txtFreight_Exch_Rate.val());

        hdn_FOB_Insurance_Rate.val(txtInsurance_Rate.val());
        hdn_FOB_Insurance_Charge.val(txtInsurance_Charges.val());
        hdn_FOB_Insurance_Currency.val(txtInsurance_Currency.val());
        hdn_FOB_Insurance_ExRate.val(txtInsurance_Exch_Rate.val());

        hdn_CI_Freight_Rate.val(txtFreight_Rate.val());
        hdn_CI_Freight_Charge.val(txtFreight_Charges.val());
        hdn_CI_Freight_Currency.val(txtFreight_Currency.val());
        hdn_CI_Freight_ExRate.val(txtFreight_Exch_Rate.val());

        hdn_CF_Insurance_Rate.val(txtInsurance_Rate.val());
        hdn_CF_Insurance_Charge.val(txtInsurance_Charges.val());
        hdn_CF_Insurance_Currency.val(txtInsurance_Currency.val());
        hdn_CF_Insurance_ExRate.val(txtInsurance_Exch_Rate.val());
    }


    /* txtFreight_Rate - below method not use - its implmntd in Invoice_Details_HP_Invoice.aspx on 11-03-2021 by Chithra (problem in Agility .sugg.by Mohemd) */
    $([txtFreight_Rate[0]]).bind('keyup change focus', function () {

        hdn_Invoice_Currency_Exrate = txtExRate.val();

        var freight_val = txtFreight_Rate.val();
        var invoice_val = txtInvoiceValue.val();
        var freight_cur = txtFreight_Currency.val().toUpperCase();

        var misc_val = txtMiscellaneous_Charges.val();
        //                alert(misc_val);
        var misc_cur = txtMiscellaneous_Currency.val();
        //        alert(misc_cur);

        var Handling_Crg = txt_Handling_Charges.val();
        var Loading_Crg = txt_Loading_Charges.val();
        var UnLoading_Crg = txt_UnLoading_Charges.val();
        var txt_Brokerage_Crg = txt_Brokerage.val();

        var Terms = document.getElementById("ddlTerms").value;

        if (Handling_Crg == '') {
            Handling_Crg = 0;
        }
        if (Loading_Crg == '') {
            Loading_Crg = 0;
        }
        if (UnLoading_Crg == '') {
            UnLoading_Crg = 0;
        }
        if (txt_Brokerage_Crg == '') {
            txt_Brokerage_Crg = 0;
        }
        var CI_misc = '';
        if (Terms == 'CI') {
            CI_misc = parseFloat(Handling_Crg) + parseFloat(Loading_Crg) + parseFloat(UnLoading_Crg) + parseFloat(txt_Brokerage_Crg);
        }
        else {
            CI_misc = 0;
        }

        var hdn_Freight_Rate = $('#hdn_Freight_Rate');


        var Result1, Result2;
        if (freight_val == '' || freight_val == '0.00' || freight_val == '0' || freight_val == '0.0000') {

            if (document.getElementById("chkMisc").checked == true) {

                //alert('ram');

                /*
                var selectedValues = [];
                $("[id*=CHKF] input:checked").each(function () {
                selectedValues.push($(this).val());
                });

                if (selectedValues == 'Amt') {

                txtFreight_Charges.val('');
                }
                else if (selectedValues == 'Rate') {
                    
                txtFreight_Rate.val('');
                }
                */
            }
            else {
                txtFreight_Rate.val('');
                ImageButton10.attr('disabled', false);
                //ImageButton11.attr('disabled', false);

                txtFreight_Charges.attr('disabled', false);
                hdn_Freight_Rate.val('');
            }
        }
        else {
            if (freight_val != '' && invoice_val != '') {

                ImageButton10.attr('disabled', true);

                txtFreight_Charges.attr('disabled', true);

                slno = hdn_INVOICE_SLNO.val();
                if (document.getElementById("chkMisc").checked == true) {

                    if (slno == '') {

                    }
                    else if (slno == '1') {


                    }
                    //--------------START-------------------------------
                    /*
                    var selectedValues_F = [];
                    $("[id*=CHKF] input:checked").each(function () {

                    selectedValues_F.push($(this).val());

                    });

                    alert(selectedValues_F);
                    if (selectedValues_F == 'Rate') {

                    txtFreight_Charges.attr('disabled', true);
                    }
                    */
                    //--------------END-------------------------------

                }
                else {

                    if (freight_cur == 'INR' && hdn_currency != '') {
                        //var f = parseFloat(txtInvoiceValue.val()  * freight_val / 100);

                        if (document.getElementById("hdnCompany_ID").value == '293' || document.getElementById("hdnCompany_ID").value == '1051' || document.getElementById("hdnCompany_ID").value == '10' || document.getElementById("hdnCompany_ID").value == '4') {

                            var f = '';
                            var inv_misc = '';

                            if (misc_val != '') {
                                if (hdn_currency == misc_cur) {
                                    inv_misc = parseFloat(txtInvoiceValue.val()) + parseFloat(txtMiscellaneous_Charges.val()) + parseFloat(CI_misc);
                                }
                                else {
                                    var misc2 = parseFloat(txtMiscellaneous_Charges.val() / document.getElementById("txtExRate").value);
                                    misc2 = misc2 + CI_misc;

                                    inv_misc = parseFloat(txtInvoiceValue.val()) + roundNumber(misc2, 2);
                                    // inv_misc = parseFloat(txtInvoiceValue.val()) + misc2;
                                }
                            }
                            else {
                                inv_misc = parseFloat(txtInvoiceValue.val()) + parseFloat(CI_misc);
                            }

                            f = (inv_misc * freight_val / 100);
                            Result1 = parseFloat(f * hdn_Invoice_Currency_Exrate);
                            //                            txtFreight_Charges.val(roundNumber(Result1, 2));
                        }
                        else { //without misc calc- old calculation
                            var f = parseFloat(txtInvoiceValue.val() * freight_val / 100);
                            Result1 = parseFloat(f * hdn_Invoice_Currency_Exrate);
                            // txtFreight_Charges.val(roundNumber(Result1, 2));
                        }

                    }
                    else {// else Invoice Currecy <>'INR'

                        if (document.getElementById("hdnCompany_ID").value == '247') {
                            var vv = parseFloat(txtInvoiceValue.val() * txtFreight_Rate.val() / 100);
                            //Result1 = parseFloat(txtInvoiceValue.val() * vv);
                            Result1 = parseFloat(vv * document.getElementById("txtExRate").value);
                            txtFreight_Charges.val(roundNumber(Result1, 2));
                        }
                        else {
                            if (document.getElementById("hdnCompany_ID").value == '293' || document.getElementById("hdnCompany_ID").value == '1051' || document.getElementById("hdnCompany_ID").value == '10' || document.getElementById("hdnCompany_ID").value == '4') {

                                var v = parseFloat(txtFreight_Rate.val() / 100);
                                var inv_misc = '';

                                if (misc_val != '') {
                                    if (hdn_currency == misc_cur) {
                                        inv_misc = parseFloat(txtInvoiceValue.val()) + parseFloat(txtMiscellaneous_Charges.val()) + parseFloat(CI_misc);
                                    }
                                    else {
                                        var misc2 = parseFloat(txtMiscellaneous_Charges.val() / document.getElementById("txtExRate").value);
                                        misc2 = misc2 + CI_misc;

                                        //inv_misc = parseFloat(txtInvoiceValue.val()) + roundNumber(misc2, 2);
                                        inv_misc = parseFloat(txtInvoiceValue.val()) + parseFloat(misc2, 2);

                                    }
                                }
                                else {
                                    inv_misc = parseFloat(txtInvoiceValue.val()) + parseFloat(CI_misc);
                                    //                                        alert(inv_misc);
                                }

                                Result1 = parseFloat(inv_misc * txtFreight_Rate.val() / 100);
                            }
                            else {  //without misc calc- old calculation
                                var v = parseFloat(txtFreight_Rate.val() / 100);
                                Result1 = parseFloat(txtInvoiceValue.val() * v);
                            }
                        }
                        //txtFreight_Charges.val(roundNumber(Result1, 2));// Result hide by chithra for 1 paise diff--call c# method
                    }
                    update_value();
                }

                //Result1 = (parseFloat(textbox.val()) / 100) * parseInt(PriceTextbox.val(), 10);
                //Result2 = (parseFloat(txtInsurance_Rate.val()) / 100) * parseInt(PriceTextbox.val(), 10);
                hdn_FOB_Freight_Rate.val(txtFreight_Rate.val());
                hdn_FOB_Freight_Charge.val(txtFreight_Charges.val());
                hdn_CI_Freight_Rate.val(txtFreight_Rate.val());
                hdn_CI_Freight_Charge.val(txtFreight_Charges.val());
            }
        }
    });




    $([txtInsurance_Rate[0]]).bind('keyup change focus', function () {

        hdn_Invoice_Currency_Exrate = txtExRate.val();

        var hdn_Insurance_Rate = $('#hdn_Insurance_Rate');

        var insurance_val = txtInsurance_Rate.val();
        var invoice_val = txtInvoiceValue.val();
        var insurance_cur = txtInsurance_Currency.val().toUpperCase();

        var misc_val = txtMiscellaneous_Charges.val();
        var misc_cur = txtMiscellaneous_Currency.val();

        var Handling_Crg = txt_Handling_Charges.val();
        var Loading_Crg = txt_Loading_Charges.val();
        var UnLoading_Crg = txt_UnLoading_Charges.val();
        var Brokerage_Crg = txt_Brokerage.val();

        var Terms = document.getElementById("ddlTerms").value;

        if (Handling_Crg == '') {
            Handling_Crg = 0;
        }
        if (Loading_Crg == '') {
            Loading_Crg = 0;
        }
        if (UnLoading_Crg == '') {
            UnLoading_Crg = 0;
        }
        if (Brokerage_Crg == '') {
            Brokerage_Crg = 0;
        }
        var CI_misc = '';
        if (Terms == 'CI' || Terms == 'FOB') {
            CI_misc = parseFloat(Handling_Crg) + parseFloat(Loading_Crg) + parseFloat(UnLoading_Crg) + parseFloat(Brokerage_Crg);
        }
        else {
            CI_misc = 0;
        }


        var Result1, Result2;
        if (insurance_val == '' || insurance_val == '0.00' || insurance_val == '0' || insurance_val == '0.0000') {

            if (document.getElementById("chkMisc").checked == true) {

            }
            else {
                txtInsurance_Rate.val('');
                ImageButton11.attr('disabled', false);
                //ImageButton11.attr('disabled', false);
                txtInsurance_Charges.attr('disabled', false);
                hdn_Insurance_Rate.val('');
            }

        }
        else {
            ImageButton11.attr('disabled', true);

            txtInsurance_Charges.attr('disabled', true);

            if (insurance_val != '' && invoice_val != '') {

                slno = hdn_INVOICE_SLNO.val();
                if (document.getElementById("chkMisc").checked == true) {

                    if (slno == '') {

                    }
                    else if (slno == '1') {

                    }

                }
                else {
                    if (insurance_cur == 'INR' && hdn_currency != '') {
                        //                        var ins = parseFloat(txtInvoiceValue.val() * insurance_val / 100);
                        //                        Result1 = parseFloat(ins * hdn_Invoice_Currency_Exrate);
                        //                        txtInsurance_Charges.val(roundNumber(Result1, 2));
                        if (document.getElementById("hdnCompany_ID").value == '293' || document.getElementById("hdnCompany_ID").value == '1051' || document.getElementById("hdnCompany_ID").value == '10' || document.getElementById("hdnCompany_ID").value == '4') {

                            var f = '';
                            var inv_misc = '';


                            if (misc_val != '') {
                                if (hdn_currency == misc_cur) {
                                    inv_misc = parseFloat(txtInvoiceValue.val()) + parseFloat(txtMiscellaneous_Charges.val()) + parseFloat(CI_misc);
                                }
                                else {
                                    var misc2 = parseFloat(txtMiscellaneous_Charges.val() / document.getElementById("txtExRate").value);
                                    misc2 = misc2 + CI_misc;
                                    //                                   inv_misc = parseFloat(txtInvoiceValue.val()) + roundNumber(misc2, 2);
                                    inv_misc = parseFloat(txtInvoiceValue.val()) + misc2;
                                }
                            }
                            else {
                                inv_misc = parseFloat(txtInvoiceValue.val()) + parseFloat(CI_misc);
                            }


                            f = (inv_misc * insurance_val / 100);
                            Result1 = parseFloat(f * hdn_Invoice_Currency_Exrate);
                            // txtInsurance_Charges.val(roundNumber(Result1, 2));
                        }
                        else {  //without misc calc- old calculation
                            var ins = parseFloat(txtInvoiceValue.val() * insurance_val / 100);
                            Result1 = parseFloat(ins * hdn_Invoice_Currency_Exrate);
                            // txtInsurance_Charges.val(roundNumber(Result1, 2));

                        }

                    }
                    else {

                        if (document.getElementById("hdnCompany_ID").value == '247') {

                            var RR = parseFloat(txtInvoiceValue.val() * txtInsurance_Rate.val() / 100);
                            Result1 = parseFloat(RR * document.getElementById("txtExRate").value);
                            txtInsurance_Charges.val(parseFloat(roundNumber(Result1, 2)));
                        }
                        else {
                            if (document.getElementById("hdnCompany_ID").value == '293' || document.getElementById("hdnCompany_ID").value == '1051' || document.getElementById("hdnCompany_ID").value == '10' || document.getElementById("hdnCompany_ID").value == '4') {

                                if (misc_val != '') {
                                    if (hdn_currency == misc_cur) {
                                        inv_misc = parseFloat(txtInvoiceValue.val()) + parseFloat(txtMiscellaneous_Charges.val()) + parseFloat(CI_misc);
                                    }
                                    else {
                                        var misc2 = parseFloat(txtMiscellaneous_Charges.val() / document.getElementById("txtExRate").value);
                                        misc2 = misc2 + CI_misc;

                                        //inv_misc = parseFloat(txtInvoiceValue.val()) + roundNumber(misc2, 2);
                                        inv_misc = parseFloat(txtInvoiceValue.val()) + parseFloat(misc2, 2);
                                    }
                                }
                                else {
                                    inv_misc = parseFloat(txtInvoiceValue.val()) + parseFloat(CI_misc);
                                }

                                Result1 = parseFloat(inv_misc * txtInsurance_Rate.val() / 100);
                            }
                            else {  //without misc calc- old calculation
                                var ins1 = parseFloat(txtInsurance_Rate.val() / 100);
                                Result1 = parseFloat(txtInvoiceValue.val() * ins1);
                            }
                        }

                        // txtInsurance_Charges.val(parseFloat(roundNumber(Result1, 2)));// Result hide by chithra for 1 paise diff--call c# method

                    }
                    update_value()
                }

                //Result1 = (parseFloat(textbox.val()) / 100) * parseInt(PriceTextbox.val(), 10);
                //Result2 = (parseFloat(txtInsurance_Rate.val()) / 100) * parseInt(PriceTextbox.val(), 10);

                hdn_FOB_Insurance_Rate.val(txtInsurance_Rate.val());
                hdn_FOB_Insurance_Charge.val(txtInsurance_Charges.val());
                hdn_CF_Insurance_Rate.val(txtInsurance_Rate.val());
                hdn_CF_Insurance_Charge.val(txtInsurance_Charges.val());
            }
        }
    });



    function dropdown_change() {

        var selectedValue = dropDownList1.val();
        jQuery('#form1').validationEngine('detach');
        hdn_Invoice_Currency_Exrate = txtExRate.val();

        SINGLE_MULTIPLE = hdn_Invoice_mode_singlr_or_multi.val();
        slno = hdn_INVOICE_SLNO.val();
        var grid_count = hdn_grid_count.val();
        txtTotal_Frieght.val(hdn_Total_Freight_Value.val());
        txtTotal_Insurance.val(hdn_Total_Insurance_Value.val());
        var ttl_freight = txtTotal_Frieght.val();
        var ttl_insurance = txtTotal_Insurance.val();
        var inv = txtInvoiceValue.val();

        if (ttl_freight == '' || ttl_freight == '0') {
            if (inv != '') {
                textbox.val('20.0000');
                //txtInsurance_Rate.val('1.1250');
               
                var insuranceRate = $.trim($("#hdn_Cilent_InsuranceRate").val());

                if (insuranceRate != '') {
                    $("#txtInsurance_Rate").val(insuranceRate);
                } else {
                    $("#txtInsurance_Rate").val('1.1250');
                }
                var Result1, Result2;

                Result1 = (parseFloat(textbox.val()) / 100) * parseInt(txtInvoiceValue.val(), 10);
                //ResultTextbox.val(Result1);
                Result2 = (parseFloat(txtInsurance_Rate.val()) / 100) * parseInt(txtInvoiceValue.val(), 10);
                //txtInsurance_Charges.val(Result2);
                txtTotal_Frieght.val(Result1);
                hdn_Total_Freight_Value.val(txtTotal_Frieght.val());
            }
        }
        if (ttl_insurance == '' || ttl_insurance == '0') {
            if (inv != '') {
                textbox.val('20.0000');
                //txtInsurance_Rate.val('1.1250');
             
                var insuranceRate = $.trim($("#hdn_Cilent_InsuranceRate").val());

                if (insuranceRate != '') {
                    $("#txtInsurance_Rate").val(insuranceRate);
                } else {
                    $("#txtInsurance_Rate").val('1.1250');
                }
                var Result1, Result2;
                Result1 = (parseFloat(textbox.val()) / 100) * parseInt(txtInvoiceValue.val(), 10);
                //ResultTextbox.val(Result1);
                Result2 = (parseFloat(txtInsurance_Rate.val()) / 100) * parseInt(txtInvoiceValue.val(), 10);
                //txtInsurance_Charges.val(Result2);
                txtTotal_Insurance.val(Result2);
                hdn_Total_Insurance_Value.val(txtTotal_Insurance.val());
            }
        }
        if (selectedValue == '') {


            disabled_true();

            jAlert('Terms Cannot be Empty', 'INVOICE', function (r) {
                document.getElementById("IMD").click();
                document.getElementById("ddlTerms").focus();
            });

        }
        else if (selectedValue == 'FOB') {

            txtFreight_Rate.val(hdn_FOB_Freight_Rate.val());
            txtFreight_Charges.val(hdn_FOB_Freight_Charge.val());
            txtFreight_Currency.val(hdn_FOB_Freight_Currency.val());
            txtFreight_Exch_Rate.val(hdn_FOB_Freight_ExRate.val());

            txtInsurance_Rate.val(hdn_FOB_Insurance_Rate.val());
            txtInsurance_Charges.val(hdn_FOB_Insurance_Charge.val());
            txtInsurance_Currency.val(hdn_FOB_Insurance_Currency.val());
            txtInsurance_Exch_Rate.val(hdn_FOB_Insurance_ExRate.val());

            if (document.getElementById("chkMisc").checked == true) {

                document.getElementById("DivFreight").style.display = 'block';
                document.getElementById("DivInsurance").style.display = 'block';

                if (slno == '') {

                    txtFreight_Charges.attr('disabled', false);
                    txtFreight_Currency.attr('disabled', false);
                    txtFreight_Exch_Rate.attr('disabled', false);
                    //txtFreight_Rate.attr('disabled', true);

                    txtInsurance_Charges.attr('disabled', false);

                    txtInsurance_Currency.attr('disabled', false);

                    txtInsurance_Exch_Rate.attr('disabled', false);

                    //txtInsurance_Rate.attr('disabled', true);

                    //--------------------Sriram -----------------Start----------------------------------------------------------------------
                    var selectedValues_F = [];
                    $("[id*=CHKF] input:checked").each(function () {
                        selectedValues_F.push($(this).val());
                    });

                    if (selectedValues_F == 'Amt') {
                        txtFreight_Charges.attr('disabled', false);
                        txtFreight_Rate.attr('disabled', true);

                    }
                    else if (selectedValues_F == 'Rate') {
                        txtFreight_Charges.attr('disabled', true);
                        txtFreight_Rate.attr('disabled', false);
                    }

                    var selectedValues_I = [];
                    $("[id*=CHKI] input:checked").each(function () {

                        selectedValues_I.push($(this).val());

                    });

                    if (selectedValues_I == 'Amt') {
                        txtInsurance_Charges.attr('disabled', false);
                        txtInsurance_Rate.attr('disabled', true);

                    }
                    else if (selectedValues_I == 'Rate') {

                        txtInsurance_Charges.attr('disabled', true);
                        txtInsurance_Rate.attr('disabled', false);
                    }

                    //-------------------sriram ---End--------------------------------------------------------
                    document.getElementById("tag_Totalfrieght").style.display = 'block';
                    document.getElementById("tag_TotalInsurance").style.display = 'block';

                }
                else if (slno == '1') {
                    if (SINGLE_MULTIPLE == 'M') {

                        txtFreight_Rate.val('0.00');
                        txtInsurance_Rate.val('0.00');



                        if (grid_count == '1') {

                            txtFreight_Charges.attr('disabled', false);
                            txtInsurance_Charges.attr('disabled', false);

                        }
                        else {

                            txtFreight_Charges.attr('disabled', true);
                            txtFreight_Currency.attr('disabled', false);
                            txtFreight_Exch_Rate.attr('disabled', false);
                            txtFreight_Rate.attr('disabled', true);

                            txtInsurance_Charges.attr('disabled', true);

                            txtInsurance_Currency.attr('disabled', false);

                            txtInsurance_Exch_Rate.attr('disabled', false);

                            txtInsurance_Rate.attr('disabled', true);
                        }
                        document.getElementById("tag_Totalfrieght").style.display = 'block';
                        document.getElementById("tag_TotalInsurance").style.display = 'block';
                    }
                    if (SINGLE_MULTIPLE == 'S') {

                        ImageButton10.attr('disabled', false);
                        ImageButton11.attr('disabled', false);

                        txtFreight_Charges.attr('disabled', false);
                        txtFreight_Currency.attr('disabled', false);
                        txtFreight_Exch_Rate.attr('disabled', false);
                        txtFreight_Rate.attr('disabled', true);

                        txtInsurance_Charges.attr('disabled', false);

                        txtInsurance_Currency.attr('disabled', false);

                        txtInsurance_Exch_Rate.attr('disabled', false);

                        txtInsurance_Rate.attr('disabled', true);
                        document.getElementById("tag_Totalfrieght").style.display = 'none';
                        document.getElementById("tag_TotalInsurance").style.display = 'none';
                    }

                }


            }
            else {


                txtFreight_Charges.attr('disabled', true);
                txtFreight_Currency.attr('disabled', false);
                txtFreight_Exch_Rate.attr('disabled', false);
                txtFreight_Rate.attr('disabled', false);

                txtInsurance_Charges.attr('disabled', true);

                txtInsurance_Currency.attr('disabled', false);

                txtInsurance_Exch_Rate.attr('disabled', false);

                txtInsurance_Rate.attr('disabled', false);
                document.getElementById("tag_Totalfrieght").style.display = 'none';
                document.getElementById("tag_TotalInsurance").style.display = 'none';
            }

        }
        else if (selectedValue == 'CI') {

            txtFreight_Rate.val(hdn_CI_Freight_Rate.val());
            txtFreight_Charges.val(hdn_CI_Freight_Charge.val());
            txtFreight_Currency.val(hdn_CI_Freight_Currency.val());
            txtFreight_Exch_Rate.val(hdn_CI_Freight_ExRate.val());

            txtInsurance_Rate.val('');
            txtInsurance_Currency.val('');
            txtInsurance_Charges.val('');
            txtInsurance_Exch_Rate.val('');
            if (document.getElementById("chkMisc").checked == true) {

                document.getElementById("DivFreight").style.display = 'block';
                document.getElementById("DivInsurance").style.display = 'none';

                if (slno == '') {

                    txtFreight_Charges.attr('disabled', false);

                    // txtInsurance_Charges.attr('disabled', true);

                    txtFreight_Currency.attr('disabled', false);
                    txtFreight_Exch_Rate.attr('disabled', false);
                    txtFreight_Rate.attr('disabled', true);

                    txtInsurance_Charges.attr('disabled', true);

                    txtInsurance_Currency.attr('disabled', true);

                    txtInsurance_Exch_Rate.attr('disabled', true);

                    // txtInsurance_Rate.attr('disabled', true);


                    //------------Sriram--------------Start------------------------------------
                    var selectedValues_F = [];
                    $("[id*=CHKF] input:checked").each(function () {
                        selectedValues_F.push($(this).val());
                    });

                    if (selectedValues_F == 'Amt') {
                        txtFreight_Charges.attr('disabled', false);
                        txtFreight_Rate.attr('disabled', true);

                    }
                    else if (selectedValues_F == 'Rate') {
                        txtFreight_Charges.attr('disabled', true);
                        txtFreight_Rate.attr('disabled', false);
                    }

                    txtInsurance_Charges.attr('disabled', true);
                    txtInsurance_Rate.attr('disabled', true);


                    //------------Sriram--------------End---------------------------------------
                    document.getElementById("tag_Totalfrieght").style.display = 'Block';
                    document.getElementById("tag_TotalInsurance").style.display = 'none';
                }
                else if (slno == '1') {
                    if (SINGLE_MULTIPLE == 'M') {

                        txtFreight_Rate.val('0.00');
                        //txtInsurance_Rate.val('0.00');
                        if (grid_count == '1') {
                            txtFreight_Charges.attr('disabled', false);

                            txtInsurance_Charges.attr('disabled', true);

                        }
                        else {

                            txtFreight_Charges.attr('disabled', true);
                            txtFreight_Currency.attr('disabled', false);
                            txtFreight_Exch_Rate.attr('disabled', false);
                            txtFreight_Rate.attr('disabled', true);

                            txtInsurance_Charges.attr('disabled', true);

                            txtInsurance_Currency.attr('disabled', true);

                            txtInsurance_Exch_Rate.attr('disabled', true);

                            txtInsurance_Rate.attr('disabled', true);

                        }
                        document.getElementById("tag_Totalfrieght").style.display = 'Block';
                        document.getElementById("tag_TotalInsurance").style.display = 'none';
                    }
                    if (SINGLE_MULTIPLE == 'S') {

                        //clear();
                        ImageButton10.attr('disabled', true);
                        ImageButton11.attr('disabled', true);
                        txtFreight_Charges.attr('disabled', false);
                        txtFreight_Currency.attr('disabled', false);
                        txtFreight_Exch_Rate.attr('disabled', false);
                        txtFreight_Rate.attr('disabled', true);

                        txtInsurance_Charges.attr('disabled', true);

                        txtInsurance_Currency.attr('disabled', true);

                        txtInsurance_Exch_Rate.attr('disabled', true);

                        txtInsurance_Rate.attr('disabled', true);
                        document.getElementById("tag_Totalfrieght").style.display = 'none';
                        document.getElementById("tag_TotalInsurance").style.display = 'none';
                    }

                }

            }
            else {


                txtFreight_Charges.attr('disabled', true);
                txtFreight_Currency.attr('disabled', false);
                txtFreight_Exch_Rate.attr('disabled', false);
                txtFreight_Rate.attr('disabled', false);

                txtInsurance_Charges.attr('disabled', true);

                txtInsurance_Currency.attr('disabled', true);

                txtInsurance_Exch_Rate.attr('disabled', true);

                txtInsurance_Rate.attr('disabled', true);


                document.getElementById("tag_Totalfrieght").style.display = 'none';
                document.getElementById("tag_TotalInsurance").style.display = 'none';

            }


        }
        else if (selectedValue == 'CF') {
            txtInsurance_Rate.val(hdn_CF_Insurance_Rate.val());
            txtInsurance_Charges.val(hdn_CF_Insurance_Charge.val());
            txtInsurance_Currency.val(hdn_CF_Insurance_Currency.val());
            txtInsurance_Exch_Rate.val(hdn_CF_Insurance_ExRate.val());

            txtFreight_Rate.val('');
            txtFreight_Charges.val('');
            txtFreight_Currency.val('');
            txtFreight_Exch_Rate.val('');
            if (document.getElementById("chkMisc").checked == true) {

                document.getElementById("DivFreight").style.display = 'none';
                document.getElementById("DivInsurance").style.display = 'block';

                if (slno == '') {

                    txtFreight_Currency.attr('disabled', true);
                    txtFreight_Exch_Rate.attr('disabled', true);
                    // txtFreight_Rate.attr('disabled', true);
                    // txtFreight_Charges.attr('disabled', true);

                    txtInsurance_Currency.attr('disabled', false);
                    txtInsurance_Charges.attr('disabled', false);

                    txtInsurance_Exch_Rate.attr('disabled', false);

                    txtInsurance_Rate.attr('disabled', true);

                    //------------Sriram--------------Start------------------------------------
                    var selectedValues_I = [];
                    $("[id*=CHKI] input:checked").each(function () {

                        selectedValues_I.push($(this).val());

                    });

                    if (selectedValues_I == 'Amt') {
                        txtInsurance_Charges.attr('disabled', false);
                        txtInsurance_Rate.attr('disabled', true);

                    }
                    else if (selectedValues_I == 'Rate') {

                        txtInsurance_Charges.attr('disabled', true);
                        txtInsurance_Rate.attr('disabled', false);
                    }

                    txtFreight_Rate.attr('disabled', true);
                    txtFreight_Charges.attr('disabled', true);
                    //------------Sriram--------------End---------------------------------------



                    document.getElementById("tag_Totalfrieght").style.display = 'none';
                    document.getElementById("tag_TotalInsurance").style.display = 'Block';

                }
                else if (slno == '1') {
                    if (SINGLE_MULTIPLE == 'M') {
                        //txtFreight_Rate.val('0.00');
                        txtInsurance_Rate.val('0.00');

                        if (grid_count == '1') {
                            txtFreight_Charges.attr('disabled', true);

                            txtInsurance_Charges.attr('disabled', false);

                        }
                        else {
                            txtFreight_Currency.attr('disabled', true);
                            txtFreight_Exch_Rate.attr('disabled', true);
                            txtFreight_Rate.attr('disabled', true);
                            txtFreight_Charges.attr('disabled', true);

                            txtInsurance_Currency.attr('disabled', false);
                            txtInsurance_Charges.attr('disabled', true);

                            txtInsurance_Exch_Rate.attr('disabled', false);

                            txtInsurance_Rate.attr('disabled', true);
                        }
                        document.getElementById("tag_Totalfrieght").style.display = 'none';
                        document.getElementById("tag_TotalInsurance").style.display = 'Block';

                    }
                    if (SINGLE_MULTIPLE == 'S') {
                        //clear();
                        ImageButton10.attr('disabled', true);
                        ImageButton11.attr('disabled', true);
                        txtFreight_Charges.attr('disabled', true);
                        txtFreight_Currency.attr('disabled', true);
                        txtFreight_Exch_Rate.attr('disabled', true);
                        txtFreight_Rate.attr('disabled', true);
                        txtFreight_Charges.attr('disabled', true);
                        txtInsurance_Charges.attr('disabled', false);

                        txtInsurance_Currency.attr('disabled', false);

                        txtInsurance_Exch_Rate.attr('disabled', false);

                        txtInsurance_Rate.attr('disabled', true);
                        document.getElementById("tag_Totalfrieght").style.display = 'none';
                        document.getElementById("tag_TotalInsurance").style.display = 'none';
                    }
                }
            }
            else {

                //clear();
                ImageButton10.attr('disabled', true);
                ImageButton11.attr('disabled', false);
                txtFreight_Charges.attr('disabled', true);
                txtFreight_Currency.attr('disabled', true);
                txtFreight_Exch_Rate.attr('disabled', true);
                txtFreight_Rate.attr('disabled', true);

                //txtInsurance_Charges.attr('disabled', false);

                txtInsurance_Currency.attr('disabled', false);

                txtInsurance_Exch_Rate.attr('disabled', false);

                txtInsurance_Rate.attr('disabled', false);


                document.getElementById("tag_Totalfrieght").style.display = 'none';
                document.getElementById("tag_TotalInsurance").style.display = 'none';
            }

            //txtFreight_Rate.val(hdn_CF_Freight_Rate);
            //txtFreight_Charges.val(hdn_CF_Freight_Charge);
        }

        else if (selectedValue == 'CIF') {

            document.getElementById("DivFreight").style.display = 'none';
            document.getElementById("DivInsurance").style.display = 'none';
            //---------------Sriram-------------Start-----------------
            txtFreight_Rate.attr('disabled', true);
            txtFreight_Charges.attr('disabled', true);
            txtInsurance_Charges.attr('disabled', true);
            txtInsurance_Rate.attr('disabled', true);
            //---------------Sriram-------------End-----------------

            ImageButton10.attr('disabled', true);
            ImageButton11.attr('disabled', true);
            disabled_true();
            document.getElementById("tag_Totalfrieght").style.display = 'none';
            document.getElementById("tag_TotalInsurance").style.display = 'none';
        }
    }
    $(dropDownList1).change(function () {

        dropdown_change();

    });

    $(function () {

        $('#chkMisc').click(function (e) {
            jQuery('#form1').validationEngine('detach');
            var txtFreight_Rate = $('#txtFreight_Rate');
            var txtInsurance_Rate = $('#txtInsurance_Rate');

            slno = hdn_INVOICE_SLNO.val();
            SINGLE_MULTIPLE = hdn_Invoice_mode_singlr_or_multi.val();

            if (this.checked) {

                //txtFreight_Rate.val('');
                //txtInsurance_Rate.val('');

                var Values = $('#ddlTerms').val();
                if (Values == '') {
                    txtFreight_Rate.attr('disabled', true);
                    txtInsurance_Rate.attr('disabled', true);

                    jAlert('Terms Cannot be Empty', 'INVOICE', function (r) {
                        document.getElementById("IMD").click();
                        document.getElementById("ddlTerms").focus();
                    });
                }
                if (Values == 'FOB') {

                    var selectedValues = [];
                    $("[id*=CHKF] input:checked").each(function () {

                        selectedValues.push($(this).val());

                    });
                    if (selectedValues == 'Amt') {


                        txtFreight_Rate.attr('disabled', true);
                        txtInsurance_Rate.attr('disabled', true);

                        txtFreight_Charges.attr('disabled', false);
                        txtInsurance_Charges.attr('disabled', false);

                        document.getElementById("tag_Totalfrieght").style.display = 'block';
                        document.getElementById("tag_TotalInsurance").style.display = 'block';
                    }
                    eles
                    {

                        txtFreight_Rate.attr('disabled', false);
                        txtInsurance_Rate.attr('disabled', false);

                        txtFreight_Charges.attr('disabled', true);
                        txtInsurance_Charges.attr('disabled', true);

                        //                        document.getElementById("tag_Totalfrieght").style.display = 'block';
                        //                        document.getElementById("tag_TotalInsurance").style.display = 'block';
                    }

                    if (slno == '1') {
                        if (SINGLE_MULTIPLE == 'M') {

                            txtFreight_Charges.attr('disabled', true);
                            txtInsurance_Charges.attr('disabled', true);

                            document.getElementById("tag_Totalfrieght").style.display = 'block';
                            document.getElementById("tag_TotalInsurance").style.display = 'block';
                        }
                    }
                }
                if (Values == 'CI') {
                    txtFreight_Rate.attr('disabled', true);
                    txtInsurance_Rate.attr('disabled', true);
                    txtFreight_Charges.attr('disabled', false);
                    txtInsurance_Charges.attr('disabled', true);
                    document.getElementById("tag_Totalfrieght").style.display = 'none';
                    document.getElementById("tag_TotalInsurance").style.display = 'block';
                    if (slno == '1') {
                        if (SINGLE_MULTIPLE == 'M') {

                            txtFreight_Charges.attr('disabled', true);

                            document.getElementById("tag_Totalfrieght").style.display = 'block';
                            document.getElementById("tag_TotalInsurance").style.display = 'none';
                        }
                    }
                }
                if (Values == 'CF') {
                    txtFreight_Rate.attr('disabled', true);
                    txtInsurance_Rate.attr('disabled', true);
                    txtFreight_Charges.attr('disabled', true);
                    txtInsurance_Charges.attr('disabled', false);
                    document.getElementById("tag_Totalfrieght").style.display = 'block';
                    document.getElementById("tag_TotalInsurance").style.display = 'none';
                    if (slno == '1') {
                        if (SINGLE_MULTIPLE == 'M') {
                            txtInsurance_Charges.attr('disabled', true);

                            document.getElementById("tag_Totalfrieght").style.display = 'none';
                            document.getElementById("tag_TotalInsurance").style.display = 'block';
                        }
                    }
                }
                if (Values == 'CIF') {
                    txtFreight_Rate.attr('disabled', true);
                    txtInsurance_Rate.attr('disabled', true);
                    document.getElementById("tag_Totalfrieght").style.display = 'none';
                    document.getElementById("tag_TotalInsurance").style.display = 'none';
                }

            }
            else {
                var F_r = txtFreight_Rate.val();
                var I_r = txtInsurance_Rate.val();

                if (F_r == '0.00') {
                    txtFreight_Rate.val('20.0000');

                }
                if (I_r == '0.00') {
                    txtInsurance_Rate.val('1.1250');
                }


                var Values = $('#ddlTerms').val();
                if (Values == 'FOB') {

                    txtFreight_Rate.attr('disabled', false);
                    txtInsurance_Rate.attr('disabled', false);
                    txtFreight_Charges.attr('disabled', true);
                    txtInsurance_Charges.attr('disabled', true);

                }
                if (Values == 'CI') {
                    txtFreight_Rate.attr('disabled', false);
                    txtInsurance_Rate.attr('disabled', true);
                    txtFreight_Charges.attr('disabled', true);
                    txtInsurance_Charges.attr('disabled', true);
                }
                if (Values == 'CF') {
                    txtFreight_Rate.attr('disabled', true);
                    txtInsurance_Rate.attr('disabled', false);
                    txtFreight_Charges.attr('disabled', true);
                    txtInsurance_Charges.attr('disabled', true);
                }
                if (Values == 'CIF') {
                    txtFreight_Rate.attr('disabled', true);
                    txtInsurance_Rate.attr('disabled', true);
                    document.getElementById("tag_Totalfrieght").style.display = 'none';
                    document.getElementById("tag_TotalInsurance").style.display = 'none';
                }
                //txtFreight_Rate.attr('disabled', true);
                //txtInsurance_Rate.attr('disabled', true);
                document.getElementById("tag_Totalfrieght").style.display = 'none';
                document.getElementById("tag_TotalInsurance").style.display = 'none';
            }
        });
    });

    $(function () {

        $('#ddlLoadingOn').change(function (e) {
            var selectedValue = $(this).val();

            var txtSVB_RefNo = $('#txtSVB_RefNo');
            var txtSVBDate = $('#txtSVBDate');
            var ddlLoadingOn = $('#ddlLoadingOn');
            var txtAssesable_Rate = $('#txtAssesable_Rate');
            var ddlAssesable_Status = $('#ddlAssesable_Status');
            var txtDuty_Rate = $('#txtDuty_Rate');
            var ddlDuty_Status = $('#ddlDuty_Status');
            var ddlSVB_CustomHouse = $('#txtCustomsHouse');

            jQuery('#form1').validationEngine('detach');
            if (selectedValue == '') {

                txtAssesable_Rate.val('');
                ddlAssesable_Status.val('');
                txtDuty_Rate.val('');
                ddlDuty_Status.val('');

                ddlAssesable_Status.attr('disabled', true);
                txtAssesable_Rate.attr('disabled', true);
                txtDuty_Rate.attr('disabled', true);
                ddlDuty_Status.attr('disabled', true);

                //                    alert('Terms Cannot be empty');

            }
            else if (selectedValue == 'Assessable') {

                txtDuty_Rate.val('');

                ddlDuty_Status.val('');

                ddlAssesable_Status.attr('disabled', false);
                txtAssesable_Rate.attr('disabled', false);
                txtDuty_Rate.attr('disabled', true);
                ddlDuty_Status.attr('disabled', true);


            }
            else if (selectedValue == 'Duty') {

                txtAssesable_Rate.val('');
                ddlAssesable_Status.val('');

                ddlAssesable_Status.attr('disabled', true);
                txtAssesable_Rate.attr('disabled', true);
                txtDuty_Rate.attr('disabled', false);
                ddlDuty_Status.attr('disabled', false);


            }
            else if (selectedValue == 'Both') {

                ddlAssesable_Status.attr('disabled', false);
                txtAssesable_Rate.attr('disabled', false);
                txtDuty_Rate.attr('disabled', false);
                ddlDuty_Status.attr('disabled', false);


            }
        });
    });




    $(function () {

        $('#chkSVB_Relation').click(function (e) {
            jQuery('#form1').validationEngine('detach');
            var txtSVB_RefNo = $('#txtSVB_RefNo');
            var txtSVBDate = $('#txtSVBDate');
            var ddlLoadingOn = $('#ddlLoadingOn');
            var txtAssesable_Rate = $('#txtAssesable_Rate');
            var ddlAssesable_Status = $('#ddlAssesable_Status');
            var txtDuty_Rate = $('#txtDuty_Rate');
            var ddlDuty_Status = $('#ddlDuty_Status');
            var ddlSVB_CustomHouse = $('#txtCustomsHouse');



            if (this.checked) {
                txtSVB_RefNo.val('');
                txtSVBDate.val('');
                //                        txtAssesable_Rate.val('');
                //                        txtDuty_Rate.val('');
                ddlLoadingOn.val('');
                //                        ddlAssesable_Status.val('');
                //                        ddlDuty_Status.val('');

                txtSVB_RefNo.attr('disabled', false);
                txtSVBDate.attr('disabled', false);
                //                        txtAssesable_Rate.attr('disabled', false);
                //                        txtDuty_Rate.attr('disabled', false);
                ddlLoadingOn.attr('disabled', false);
                //                        ddlAssesable_Status.attr('disabled', false);
                //                        ddlDuty_Status.attr('disabled', false);
                ddlSVB_CustomHouse.attr('disabled', false);



                ddlLoadingOn.change(function (e) {
                    var selectedValue = $(this).val();
                    jQuery('#form1').validationEngine('detach');
                    if (selectedValue == '') {

                        txtAssesable_Rate.val('');
                        ddlAssesable_Status.val('');
                        txtDuty_Rate.val('');
                        ddlDuty_Status.val('');

                        ddlAssesable_Status.attr('disabled', true);
                        txtAssesable_Rate.attr('disabled', true);
                        txtDuty_Rate.attr('disabled', true);
                        ddlDuty_Status.attr('disabled', true);

                        //                    alert('Terms Cannot be empty');

                    }
                    else if (selectedValue == 'Assessable') {

                        txtDuty_Rate.val('');

                        ddlDuty_Status.val('');

                        ddlAssesable_Status.attr('disabled', false);
                        txtAssesable_Rate.attr('disabled', false);
                        txtDuty_Rate.attr('disabled', true);
                        ddlDuty_Status.attr('disabled', true);


                    }
                    else if (selectedValue == 'Duty') {

                        txtAssesable_Rate.val('');
                        ddlAssesable_Status.val('');

                        ddlAssesable_Status.attr('disabled', true);
                        txtAssesable_Rate.attr('disabled', true);
                        txtDuty_Rate.attr('disabled', false);
                        ddlDuty_Status.attr('disabled', false);


                    }
                    else if (selectedValue == 'Both') {

                        ddlAssesable_Status.attr('disabled', false);
                        txtAssesable_Rate.attr('disabled', false);
                        txtDuty_Rate.attr('disabled', false);
                        ddlDuty_Status.attr('disabled', false);


                    }
                });

            }
            else {

                txtSVB_RefNo.val('');
                txtSVBDate.val('');
                txtAssesable_Rate.val('');
                txtDuty_Rate.val('');
                ddlLoadingOn.val('');
                ddlAssesable_Status.val('');
                ddlDuty_Status.val('');

                ddlSVB_CustomHouse.val('');

                txtSVB_RefNo.attr('disabled', true);
                txtSVBDate.attr('disabled', true);
                txtAssesable_Rate.attr('disabled', true);
                txtDuty_Rate.attr('disabled', true);
                ddlLoadingOn.attr('disabled', true);
                ddlAssesable_Status.attr('disabled', true);
                ddlDuty_Status.attr('disabled', true);
                ddlSVB_CustomHouse.attr('disabled', true);
            }
        });

    });

    function OpenPopupExchange_Master_Frieght(val) {


        var Values1 = $('#ddlTerms').val();

        if (Values1 == 'FOB') {
            OpenPopupExchange(val);
            return false;
        }
        else if (Values1 == 'CI') {
            OpenPopupExchange(val);
            return false;
        }
        else if (Values1 == '') {
        }

        jQuery('#form1').validationEngine('detach');

    }
    function OpenPopupExchange_Master_Insurance(val) {

        var Values1 = $('#ddlTerms').val();

        if (Values1 == 'FOB') {
            OpenPopupExchange(val);
            return false;
        }
        else if (Values1 == 'CF') {
            OpenPopupExchange(val);
            return false;
        }
        else if (Values1 == '') {
        }
        jQuery('#form1').validationEngine('detach');
    }
});

        $(function () {
            $("#txtInvoiceCurrency,#txtMiscellaneous_Currency,#txtAgency_Currency,#txtDiscount_Currency,#txtLoading_Currency,#txtFreight_Currency,#txtInsurance_Currency,#txtHighSeaSale_Currency,#txt_INV_MISC_Currency").autocomplete({
                        source: function (request, response) {
                            var field = $(this.element).attr('id');

                            $.ajax({
                                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exchage_Master_List",
                                data: "{ 'mail': '" + request.term + "' }",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                async: true,
                                success: function (data) {
                                    response(data.d);
                                    if (data.d == '') {
                                        if (field == 'txtInvoiceCurrency') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Invoice Currency', 'error', 'topRight', true);

                                            //jAlert('Invoice Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            // return false;
                                        }
                                        if (field == 'txtMiscellaneous_Currency') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Miscellaneous Currency', 'error', 'topRight', true);

                                            //jAlert('Miscellaneous Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txtAgency_Currency') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Agency Currency', 'error', 'topRight', true);

                                            //jAlert('Agency Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txtDiscount_Currency') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Discount Currency', 'error', 'topRight', true);

                                            //jAlert('Discount Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txtLoading_Currency') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Loading Currency', 'error', 'topRight', true);

                                            //jAlert('Loading Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txtFreight_Currency') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Freight Currency', 'error', 'topRight', true);

                                            //jAlert('Freight Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txtInsurance_Currency') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Insurance Currency', 'error', 'topRight', true);

                                            //jAlert('Insurance Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            // return false;
                                        }
                                        if (field == 'txtHighSeaSale_Currency') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect HighSeaSale Currency', 'error', 'topRight', true);

                                            //jAlert('HighSeaSale Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txt_INV_MISC_Currency') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect INVt_MISC Currency', 'error', 'topRight', true);
                                        }
                                    }
                                    else {
                                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);

                                        var result = data.d;

                                        var stringsearch = "-", str = result;

                                        for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                                        if (i == 1) {
                                            if (field == 'txtInvoiceCurrency') {
                                                $('#txtInvoiceCurrency').val(result);
                                            }

                                            if (field == 'txtAgency_Currency') {
                                                $('#txtAgency_Currency').val(result);
                                            }

                                            if (field == 'txtDiscount_Currency') {
                                                $('#txtDiscount_Currency').val(result);
                                            }

                                            if (field == 'txtMiscellaneous_Currency') {
                                                $('#txtMiscellaneous_Currency').val(result);
                                            }

                                            if (field == 'txtFreight_Currency') {
                                                $('#txtFreight_Currency').val(result);
                                            }

                                            if (field == 'txtInsurance_Currency') {
                                                $('#txtInsurance_Currency').val(result);
                                            }

                                            if (field == 'txtHighSeaSale_Currency') {
                                                $('#txtHighSeaSale_Currency').val(result);
                                            }

                                            if (field == 'txt_INV_MISC_Currency') {
                                                $('#txt_INV_MISC_Currency').val(result);
                                            }
                                        }
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
                    $("#txtSupplierCountryName,#txtSellerCountryName,#txtBrokerCountryName,#txt_CountryCode").autocomplete({
                        source: function (request, response) {
                            var field = $(this.element).attr('id');

                            $.ajax({
                                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Country_Master_List",
                                data: "{ 'mail': '" + request.term + "' }",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                async: true,
                                success: function (data) {
                                    response(data.d);
                                    if (data.d == '') {
                                        if (field == 'txtSupplierCountryName') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Supplier Country Name', 'error', 'topRight', true);

                                            //jAlert('Supplier Country Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txtSellerCountryName') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Seller Country Name', 'error', 'topRight', true);

                                            //jAlert('Seller Country Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txtBrokerCountryName') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Broker Country Name', 'error', 'topRight', true);

                                            //jAlert('Broker Country Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txt_CountryCode') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);

                                            //jAlert('Broker Country Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                    }
                                    else {
                                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
                    $('#txtSupplierCountryName').bind('keyup change focus', function () {

                        var data = $(this).val();
                        country(data);
                    });


                    $('#txtSellerCountryName').bind('keyup change focus', function () {

                        var data = $(this).val();
                        country1(data);
                    });


                    $('#txtBrokerCountryName').bind('keyup change focus', function () {

                        var data = $(this).val();
                        country2(data);
                    });

                    $('#txt_CountryCode').bind('keyup change focus focusout', function () {

                        var data = $(this).val();
                        country2(data);
                    });


                });

                function country(val, txt) {

                    var data = val;

                    if (data.indexOf("-") != -1) {


                        var s = data.split('-');

                        var before = s[0];
                        var after = s[1];

                        $('#txtSupplierCountryName').val(before);
                    }
                    else {

                    }
                }
                function country1(val, txt) {

                    var data = val;

                    if (data.indexOf("-") != -1) {


                        var s = data.split('-');

                        var before = s[0];
                        var after = s[1];

                        $('#txtSellerCountryName').val(before);

                    }
                    else {

                    }
                }
                function country2(val) {

                    var data = val;

                    if (data.indexOf("-") != -1) {


                        var s = data.split('-');

                        var before = s[0];
                        var after = s[1];

                        $('#txtBrokerCountryName').val(before);

                    }
                    else {

                    }
                }

                function country2(val) {

                    var data = val;

                    if (data.indexOf("-") != -1) {


                        var s = data.split('-');

                        var before = s[0];
                        var after = s[1];

                        $('#txt_CountryCode').val(after);
                        //                        $('#hdn_CountryCode').val(after);

                    }
                    else {

                    }
                }

                $(function () {
                    $("#txtCustomsHouse").autocomplete({

                        source: function (request, response) {
                            $.ajax({
                                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
//                                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                                data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",

                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                async: true,
                                success: function (data) {
                                    response(data.d);
                                    if (data.d == '') {
                                        jQuery('#txtCustomsHouse').validationEngine('showPrompt', 'Incorrect CustomHouse Location', 'error', 'topRight', true);
                                        document.getElementById("hdn_Customhouse_chk").value = 'No';
                                        //jAlert('Bond Location is Incorrect', 'BOND', function (r) { document.getElementById("txtBondLocation").focus(); });
                                        //return false;
                                    }
                                    else {
                                        jQuery('#txtCustomsHouse').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                        document.getElementById("hdn_Customhouse_chk").value = 'Yes';
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
                    $("#txtSupplierName,#txtSellerName,#txtBrokerName,#txt_SupplierName_Gmmco,#txt_SupplierName_CP,#txt_SupplierName_Gen").autocomplete({
                        source: function (request, response) {
                            var field = $(this.element).attr('id');

                            $.ajax({
                                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Supplier_Master_List",
                                data: "{ 'mail': '" + request.term + "' }",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                async: true,
                                success: function (data) {
                                    response(data.d);
                                    if (data.d == '') {
                                        if (field == 'txtSupplierName') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Supplier Name', 'error', 'topRight', true);

                                            //jAlert('Supplier Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txtSellerName') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Seller Name', 'error', 'topRight', true);

                                            //jAlert('Seller Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txtBrokerName') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Broker Name', 'error', 'topRight', true);

                                            //jAlert('Broker Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txt_SupplierName_Gmmco') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Supplier Name', 'error', 'topRight', true);

                                            //jAlert('Broker Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txt_SupplierName_CP') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Supplier Name', 'error', 'topRight', true);

                                            //jAlert('Broker Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                            //return false;
                                        }
                                        if (field == 'txt_SupplierName_Gen') {
                                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Supplier Name', 'error', 'topRight', true);
                                        }
                                        
                                    }
                                    else {
                                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


                function Call__Inv_Currency_Excahnge_Rate(src, dest) {
                    var ctrl = document.getElementById(src);
                    // call server side method
                    //alert('l');
                    var ieccode = document.getElementById("txtInvoiceCurrency").value;
                    if (ieccode.length == 3) {
                        PageMethods.GetExchange_Rate_Invoice_Cur(ctrl.value, CallSuccess_Invoice_Cur, CallFailed, dest);
                        Invoice_currency_ExRate();

                    }

                }
                function Call_Excahnge_Rate(src, dest) {
                    var ctrl = document.getElementById(src);
                    // call server side method
                    //alert('l');
                    var ieccode = document.getElementById(src).value;
                    if (ieccode.length == 3) {
                        PageMethods.GetExchange_Rate(ctrl.value, CallSuccess, CallFailed, dest);
                        
                    }
                }

                // set the destination textbox value with the ContactName
                function CallSuccess_Invoice_Cur(res, destCtrl) {
                    //var dest = document.getElementById(destCtrl);
                    //dest.value = res;
                    //document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExRate").value;
                  
                    var data = res;

                    if (data.length == 0) {
                        $('#hdn_chk_Invalid_Cur').val('');
                    }
                    else {
                        $('#hdn_chk_Invalid_Cur').val('Yes');
                    }

                    if (data.indexOf("~~") != -1) {


                        var s = data.split('~~');

                        var before = s[0];
                        var after1 = s[1];
                        var after2 = s[2];
                        var after3 = s[3];
                        var after4 = s[4];

                        document.getElementById("hdn_non_std_effect_dt").value = after1;
                        document.getElementById("hdn_non_std_bankname").value = after2;
                        document.getElementById("hdn_non_std_cert_no").value = after3;
                        document.getElementById("hdn_non_std_cert_dt").value = after4;
                        var dest = document.getElementById(destCtrl);
                        dest.value = before;
                        document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExRate").value;                
                    }
                    else {
                        var dest = document.getElementById(destCtrl);
                        dest.value = data;
                        if (dest.value.length > 0) {
                            document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExRate").value;
                          
                        }
                        document.getElementById("hdn_non_std_effect_dt").value = "";
                        document.getElementById("hdn_non_std_bankname").value = "";
                        document.getElementById("hdn_non_std_cert_no").value = "";
                        document.getElementById("hdn_non_std_cert_dt").value = "";
                       
                    }
                }

                function CallSuccess(res, destCtrl) {
                    //var dest = document.getElementById(destCtrl);
                    //dest.value = res;
                    //document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExRate").value;

                    var data = res;
                // alert(data);
                    if (data.length == 0) {
                        if (destCtrl == 'txtMiscellaneous_Exch_Rate') {
                            $('#hdn_chk_curr').val('');
                            jAlert('Invalid - MISC Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtMiscellaneous_Currency").focus(); });
                            return false;
                        }
                        else if (destCtrl == 'txtDiscount_Exch_Rate') {
                            $('#hdn_Invalid_Disc_Cur').val('');
                            jAlert('Invalid - Discount Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtDiscount_Currency").focus(); });
                            return false;
                        }
                        else if (destCtrl == 'txtHighSeaSale_Exch_Rate') {
                            $('#hdn_Invalid_Hss_Cur').val('');
                            jAlert('Invalid - HSS Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtHighSeaSale_Currency").focus(); });
                            return false;
                        }
                        else if (destCtrl == 'txtFreight_Exch_Rate') {
                        $('#hdn_Invalid_FRT_Cur').val('');
                        jAlert('Invalid - Freight Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Currency").focus(); });
                        return false;
                        }
                        else if (destCtrl == 'txtInsurance_Exch_Rate') {
                            //alert(destCtrl);
                            $('#hdn_Invalid_INS_Cur').val('');
                            jAlert('Invalid - Insurance Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtInsurance_Currency").focus(); });
                            return false;
                        }
                        else {
                        }
                    }
                    else {
                        if (destCtrl == 'txtMiscellaneous_Exch_Rate') {
                            $('#hdn_chk_curr').val('Yes');
                        }
                        else if (destCtrl == 'txtDiscount_Exch_Rate') {
                            $('#hdn_Invalid_Disc_Cur').val('Yes');
                        }
                        else if (destCtrl == 'txtHighSeaSale_Exch_Rate') {
                            $('#hdn_Invalid_Hss_Cur').val('Yes');
                        }
                        else if (destCtrl == 'txtFreight_Exch_Rate') {
                        $('#hdn_Invalid_FRT_Cur').val(data);
                        document.getElementById("hdn_Invalid_FRT_Cur").value = data;
                        }
                        else if (destCtrl == 'txtInsurance_Exch_Rate') {
                            $('#hdn_Invalid_INS_Cur').val(data);
                            document.getElementById("hdn_Invalid_INS_Cur").value = data;
                        }
                        else {
                        }
                    }

                    if (data.indexOf("~~") != -1) {


                        var s = data.split('~~');

                        var before = s[0];
                        var after1 = s[1];
                        var after2 = s[2];
                        var after3 = s[3];
                        var after4 = s[4];

//                        document.getElementById("hdn_non_std_effect_dt").value = after1;
//                        document.getElementById("hdn_non_std_bankname").value = after2;
//                        document.getElementById("hdn_non_std_cert_no").value = after3;
//                        document.getElementById("hdn_non_std_cert_dt").value = after4;
                        var dest = document.getElementById(destCtrl);
                        dest.value = before;
                        document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExRate").value;


                    }
                    else {
                        var dest = document.getElementById(destCtrl);
                        dest.value = data;
                        if (dest.value.length > 0) {
                            document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExRate").value;

                        }
//                        document.getElementById("hdn_non_std_effect_dt").value = "";
//                        document.getElementById("hdn_non_std_bankname").value = "";
//                        document.getElementById("hdn_non_std_cert_no").value = "";
//                        document.getElementById("hdn_non_std_cert_dt").value = "";

                    }

                }

                // alert message on some failure
                function CallFailed(res, destCtrl) {
                    //alert(res.get_message());
                }

//-------------------------------------------------------ram----------------------------------------------------------------------------------------------------------------------

                // SUPPLIER
                function Call_Supplier(src, dest) {
                    var ctrl = document.getElementById(src);
                    // call server side method

                    PageMethods.GetSupplier(ctrl.value, document.getElementById("HD_Imp_Name").value, document.getElementById("hdn_Supplier_br_slno").value, CallSuccess_supplier, CallFailed, dest);

                }

                // set the destination textbox value with the ContactName
                function CallSuccess_supplier(res, destCtrl) {
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
                        var after10 = s[10];
                        var after11 = s[11];
                        var after12 = s[12];
                        var after13 = s[13];
                        var after14 = s[14];
                        var after15 = s[15];
                        var after16 = s[16];
                        var after17 = s[17];
                        var after18 = s[18];
                        var after19 = s[19];
                        var after20 = s[20];
                        
                        var txtSVB_RefNo = $('#txtSVB_RefNo');
                        var txtSVBDate = $('#txtSVBDate');
                        var ddlLoadingOn = $('#ddlLoadingOn');
                        var txtAssesable_Rate = $('#txtAssesable_Rate');
                        var ddlAssesable_Status = $('#ddlAssesable_Status');
                        var txtDuty_Rate = $('#txtDuty_Rate');
                        var ddlDuty_Status = $('#ddlDuty_Status');
                        var ddlSVB_CustomHouse = $('#txtCustomsHouse');
                        var txtBondNo = $('#txtBondNo');
                        var txtBondLocation = $('#txtBondLocation');
                        var ddlBondType = $('#ddlBondType');


                        document.getElementById("txtSupplier_Branch_Slno").value = after1;
                        document.getElementById("txtSupplierAddress").value = after2;
                        document.getElementById("txtSupplierAddress1").value = after3;
                        document.getElementById("txtSupplierAddress2").value =after4;
                        document.getElementById("txtSupplierCountryName").value = after5;
                        document.getElementById("hfdsupplier_countrycode").value = after6;
                        document.getElementById("txtSuppliercountry_pincode").value = after7;


                        if (after8 == 'Y') {
                            var chk = document.getElementById("chkSVB_Relation");
                            chk.checked = true;
                            txtSVB_RefNo.attr('disabled', false);
                            txtSVBDate.attr('disabled', false);
                            ddlLoadingOn.attr('disabled', false);
                            ddlSVB_CustomHouse.attr('disabled', false);


                            var a = document.getElementById("ddlLoadingOn");
                            var aa = after11;

                            for (i = 0; i < a.length; i++) {
                                if (a.options[i].value == aa) {
                                    a.selectedIndex = i;
                                }
                            }

                            document.getElementById("txtSVB_RefNo").value = after9;
                            document.getElementById("txtCustomsHouse").value = after10;

                            document.getElementById("txtSVBDate").value = after16;
                           
                            if (after20.substr(0, 1) == 'Y' || after20.substr(0, 1) == 'N') {
                                document.getElementById("txt_Whether_Relater_Y_N").value = after20.substr(0, 1);
                            } else {
                            document.getElementById("txt_Whether_Relater_Y_N").value = '';
                            }
                            
                            if (after11 == 'Assessable') {

                                txtAssesable_Rate.attr('disabled', false)
                                document.getElementById("txtAssesable_Rate").value = after12;

                                ddlAssesable_Status.attr('disabled', false)

                                var AS = document.getElementById("ddlAssesable_Status");
                                var AS_Val = after14;

                                for (j = 0; j < AS.length; j++) {
                                    if (AS.options[j].value == AS_Val) {
                                        AS.selectedIndex = j;
                                    }
                                }

                            }
                            else if (after11 == 'Duty') {
                                txtDuty_Rate.attr('disabled', false)
                                document.getElementById("txtDuty_Rate").value = after13;

                                ddlDuty_Status.attr('disabled', false)


                                var ds = document.getElementById("ddlDuty_Status");
                                var ds_Val = after15;

                                for (k = 0; k < ds.length; k++) {
                                    if (ds.options[k].value == ds_Val) {
                                        ds.selectedIndex = k;
                                    }
                                }


                            }
                            else if (after11 == 'Both') {
                                txtAssesable_Rate.attr('disabled', false)
                                ddlAssesable_Status.attr('disabled', false)
                                txtDuty_Rate.attr('disabled', false)
                                ddlDuty_Status.attr('disabled', false)

                                document.getElementById("txtAssesable_Rate").value = after12;
                                document.getElementById("txtDuty_Rate").value = after13;

                                //-------------------------------------------------------------------

                                var AS_2 = document.getElementById("ddlAssesable_Status");
                                var AS_Val_2 = after14;

                                for (l = 0; l < AS_2.length; l++) {
                                    if (AS_2.options[l].value == AS_Val_2) {
                                        AS_2.selectedIndex = l;
                                    }
                                }

                                //-------------------------------------------------------------------

                                var ds_2 = document.getElementById("ddlDuty_Status");
                                var ds_Val_2 = after15;

                                for (M = 0; M < ds_2.length; M++) {
                                    if (ds_2.options[M].value == ds_Val_2) {
                                        ds_2.selectedIndex = M;
                                    }
                                }
                                //--------------------------------------------------------------
                            }
                            if (after14 == 'Provisional' || after15 == 'Provisional') {
                            
                                $('#hdn_BOND_NO').val(after17);
                                $('#hdn_BOND_LOCATION').val(after18);
                                $('#hdn_BOND_TYPE').val(after19);
                            }
                            else {
                            
                                document.getElementById("hdn_BOND_NO").value = "";
                                document.getElementById("hdn_BOND_LOCATION").value = "";
                                document.getElementById("hdn_BOND_TYPE").value = "";
                            }
                        }
                        else {

                            var chk_f = document.getElementById("chkSVB_Relation");
                            chk_f.checked = false;

                            $('#form1').validationEngine('hideAll');

                            document.getElementById("txtSVB_RefNo").value = "";
                            document.getElementById("txtSVBDate").value = "";

                            document.getElementById("txtCustomsHouse").value = "";
                            document.getElementById("ddlLoadingOn").value = "";

                            document.getElementById("txtAssesable_Rate").value = "";
                            document.getElementById("txtDuty_Rate").value = "";
                            document.getElementById("ddlAssesable_Status").value = "";
                            document.getElementById("ddlDuty_Status").value = "";
                            document.getElementById("txt_Whether_Relater_Y_N").value = "";

                            var txtCustomsHouse_2 = $('#txtCustomsHouse');
                            var ddlLoadingOn_2 = $('#ddlLoadingOn');

                            var txtAssesable_Rate_2 = $('#txtAssesable_Rate');
                            var txtDuty_Rate_2 = $('#txtDuty_Rate');
                            var ddlAssesable_Status_2 = $('#ddlAssesable_Status');
                            var ddlDuty_Status_2 = $('#ddlDuty_Status');
                           
                            
                            txtSVB_RefNo.attr('disabled', true);
                            txtSVBDate.attr('disabled', true);

                            txtCustomsHouse_2.attr('disabled', true);
                            ddlLoadingOn_2.attr('disabled', true);
                            txtAssesable_Rate_2.attr('disabled', true);
                            txtDuty_Rate_2.attr('disabled', true);
                            ddlAssesable_Status_2.attr('disabled', true);
                            ddlDuty_Status_2.attr('disabled', true);
                        }
                    }
                    else {

                        document.getElementById("txtSupplierAddress").value = "";
                        document.getElementById("txtSupplierAddress1").value = "";
                        document.getElementById("txtSupplierAddress2").value = "";
                        document.getElementById("txtSupplierCountryName").value = "";
                        document.getElementById("hfdsupplier_countrycode").value = "";
                        document.getElementById("txtSuppliercountry_pincode").value = "";
                    }
                }
                // End Supplier

                // SELLER
                function Call_Seller(src, dest) {
                    var ctrl = document.getElementById(src);
                    // call server side method
                    //alert('l');

                    PageMethods.GetSeller(ctrl.value, CallSuccess_Seller, CallFailed, dest);


                }

                // set the destination textbox value with the ContactName
                function CallSuccess_Seller(res, destCtrl) {
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


                        document.getElementById("txtSellerAddress").value = after1;
                        document.getElementById("txtSellerAddress1").value = after2;
                        document.getElementById("txtSellerAddress2").value = after3;
                        document.getElementById("txtSellerCountryName").value = after4;
                        document.getElementById("hfdseller_countrycode").value = after5;
                        document.getElementById("txtSellercountry_pincode").value = after6;



                    }
                    else {
                        document.getElementById("txtSellerAddress").value = "";
                        document.getElementById("txtSellerAddress1").value = "";
                        document.getElementById("txtSellerAddress2").value = "";
                        document.getElementById("txtSellerCountryName").value = "";
                        document.getElementById("hfdSeller_countrycode").value = "";
                        document.getElementById("txtSellercountry_pincode").value = "";

                    }
                }
                // BROKER
                function Call_Broker(src, dest) {
                    var ctrl = document.getElementById(src);
                    // call server side method
                    //alert('l');

                    PageMethods.GetBroker(ctrl.value, CallSuccess_Broker, CallFailed, dest);


                }

                // set the destination textbox value with the ContactName
                function CallSuccess_Broker(res, destCtrl) {
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

                        document.getElementById("txtBrokerAddress").value = after1;
                        document.getElementById("txtBrokerAddress1").value = after2;
                        document.getElementById("txtBrokerAddress2").value = after3;
                        document.getElementById("txtBrokerCountryName").value = after4;
                        document.getElementById("hfdbroker_countrycode").value = after5;
                        document.getElementById("txtbrokercountry_pincode").value = after6;
                    }
                    else {
                        document.getElementById("txtBrokerAddress").value = "";
                        document.getElementById("txtBrokerAddress1").value = "";
                        document.getElementById("txtBrokerAddress2").value = "";
                        document.getElementById("txtBrokerCountryName").value = "";
                        document.getElementById("hfdbroker_countrycode").value = "";
                        document.getElementById("txtbrokercountry_pincode").value = "";

                    }
                }


                // ----------------------------Insurance_Currency---start-----------------------------------------------------------------

                function Call_Insurance_Currency(src, inv_currency, inv_value, insurance_charge, dest, misc_cur, misc_value, Terms, Handling_Charges, Loading_Charges, UnLoading_Charges, Type, txt_Exrate, INV_MISC_Charges) {
                   
                    //---------------------to Check INV_MISC is Check/Not ----------------------------
                    var ctrl = document.getElementById(src);
                    var chk_active_INV_misc_YN = '';
                    var mycheckbox1 = document.getElementById('chk_active_Inv_Misc');
                    if (mycheckbox1.checked) {
                        chk_active_INV_misc_YN = 'T';
                    }
                    else {
                        chk_active_INV_misc_YN = 'N';
                    }
                    //----------------------------------------------------------------------------------
                   var txt_INV_MISC_Currency= document.getElementById("txt_INV_MISC_Currency").value;
                    // call server side method
                   PageMethods.GetInsurance_Currency_value(ctrl.value, document.getElementById(inv_currency).value, document.getElementById(inv_value).value, document.getElementById(insurance_charge).value, document.getElementById("txtInsurance_Exch_Rate").value, document.getElementById("txtInsurance_Rate").value, document.getElementById(misc_value).value, document.getElementById(misc_cur).value, document.getElementById(Terms).value, document.getElementById(Handling_Charges).value, document.getElementById(Loading_Charges).value, document.getElementById(UnLoading_Charges).value, Type, document.getElementById(txt_Exrate).value, document.getElementById(INV_MISC_Charges).value, chk_active_INV_misc_YN, txt_INV_MISC_Currency, document.getElementById("txtMiscellaneous_Exch_Rate").value, CallSuccess_Insurance_Currency, CallFailed, dest);
                }



                // ----------------------------Freight_Currency---start----------------------------------------------------------------- 
                function Call_Freight_Currency(src, inv_currency, inv_value, freight_charge, dest, misc_cur, misc_value, Terms, Handling_Charges, Loading_Charges, UnLoading_Charges, Type, txt_Exrate, INV_MISC_Charges) {
                    var ctrl = document.getElementById(src);

                   
                    //---------------------to Check INV_MISC is Check/Not ----------------------------
                    var ctrl = document.getElementById(src);
                    var chk_active_INV_misc_YN = '';
                    var mycheckbox1 = document.getElementById('chk_active_Inv_Misc');
                    if (mycheckbox1.checked) {
                        chk_active_INV_misc_YN = 'T';
                    }
                    else {
                        chk_active_INV_misc_YN = 'N';
                    }
                    //----------------------------------------------------------------------------------
                    var txt_INV_MISC_Currency = document.getElementById("txt_INV_MISC_Currency").value;
                    // call server side method
                    PageMethods.GetFreight_Currency_value(ctrl.value, document.getElementById(inv_currency).value, document.getElementById(inv_value).value, document.getElementById(freight_charge).value, document.getElementById("txtFreight_Exch_Rate").value, document.getElementById("txtFreight_Rate").value, document.getElementById(misc_value).value, document.getElementById(misc_cur).value, document.getElementById(Terms).value, document.getElementById(Handling_Charges).value, document.getElementById(Loading_Charges).value, document.getElementById(UnLoading_Charges).value, Type, document.getElementById(txt_Exrate).value, document.getElementById(INV_MISC_Charges).value, chk_active_INV_misc_YN, txt_INV_MISC_Currency, document.getElementById("txtMiscellaneous_Exch_Rate").value, CallSuccess_Freight_Currency, CallFailed, dest);
                }


                // set the destination textbox value with the ContactName
                function CallSuccess_Insurance_Currency(res, destCtrl) {
                    
                    var dest = document.getElementById(destCtrl);
                    //dest.value = res;
                    var data = res;

                    if (data.length == 0) {
                        $('#hdn_Invalid_INS_Cur').val('');
                    }
                    else {
                        $('#hdn_Invalid_INS_Cur').val('Yes');
                    }

                    if (data.indexOf("~~") != -1) {

                        var s = data.split('~~');
                        var before = s[0];
                        var after1 = s[1];
                        var after2 = s[2];
                        var Type = s[3];
                        var IsvalidCur = s[4];

                        if (IsvalidCur.length == 0) {
                            $('#hdn_Invalid_INS_Cur').val('');
                        }
                        else {
                            $('#hdn_Invalid_INS_Cur').val('Yes');
                        }
                    
                        if ($('#chkMisc').attr('checked')) {

                            document.getElementById("txtInsurance_Charges").value = before;
                            document.getElementById("hdn_currency").value = after1;
                            document.getElementById("txtInsurance_Exch_Rate").value = after2;
                            // document.getElementById("txtInsurance_Rate").value = document.getElementById("hdn_Insurance_Rate").value;
                            document.getElementById("txtInsurance_Rate").value = document.getElementById("txtInsurance_Rate").value;
                        }
                        else {
                                                    
                            if (parseFloat(document.getElementById("txtInsurance_Rate").value) > 0) {
                                document.getElementById("txtInsurance_Charges").value = before;
                                document.getElementById("hdn_currency").value = after1;
                                if (Type == 'EX_RATE') {
                                    document.getElementById("txtInsurance_Exch_Rate").value = after2;
                                   
                                }
                                document.getElementById("txtInsurance_Rate").value = document.getElementById("txtInsurance_Rate").value;
                            }
                            else {
                                if (Type == 'EX_RATE') {
                                    document.getElementById("txtInsurance_Exch_Rate").value = after2;
                                }
                            }
                        }
                        get_value();

                        var freight_charge = document.getElementById("txtFreight_Charges").value;
                        if (freight_charge != '' || freight_charge == '0' || freight_charge == '0.00' || freight_charge == 'NAN') {
                            document.getElementById("txtFreight_Rate").value = '0.00';
                        }
                        else {
                            document.getElementById("txtFreight_Rate").value = '20.0000';

                        }
                    }
                    else {
                        //document.getElementById("txtBrokerAddress").value = "";
                        // document.getElementById("txtBrokerAddress1").value = "";

                    }
                }
                // set the destination textbox value with the ContactName
                function CallSuccess_Freight_Currency(res, destCtrl) {
                    var dest = document.getElementById(destCtrl);
                    //dest.value = res;
                    var data = res;
                   
//                    if (data.length == 0) {
//                        $('#hdn_Invalid_FRT_Cur').val('');
//                    }
//                    else {
//                        $('#hdn_Invalid_FRT_Cur').val('Yes');
//                    }
//                   
                    if (data.indexOf("~~") != -1) {

                        var s = data.split('~~');
                        var before = s[0];
                        var after1 = s[1];
                        var after2 = s[2];
                        var Type = s[3];
                        var Isvalidcurr = s[4];
                        
                        if (Isvalidcurr.length == 0) {
                            $('#hdn_Invalid_FRT_Cur').val('');
                            jAlert('Invalid - Freight Currency ', 'INVOICE DETAILS', function (r) { document.getElementById("MD").click(); document.getElementById("txtFreight_Currency").focus(); });
                            return false;
                        }
                        else {
                            $('#hdn_Invalid_FRT_Cur').val('Yes');
                        }
                   

                        if ($('#chkMisc').attr('checked')) {
                            document.getElementById("txtFreight_Charges").value = before;
                            document.getElementById("hdn_currency").value = after1;
                            document.getElementById("txtFreight_Exch_Rate").value = after2;

                            /* 
                            //                              document.getElementById("txtFreight_Rate").value = document.getElementById("hdn_Freight_Rate").value;
                            //                              document.getElementById("txtInsurance_Rate").value = document.getElementById("hdn_Insurance_Rate").value;
                            */
                            document.getElementById("txtFreight_Rate").value = document.getElementById("txtFreight_Rate").value;
                            document.getElementById("txtInsurance_Rate").value = document.getElementById("txtInsurance_Rate").value;

                        }
                        else {
                            if (parseFloat(document.getElementById("txtFreight_Rate").value) > 0) {
                                document.getElementById("txtFreight_Charges").value = before;
                                document.getElementById("hdn_currency").value = after1;
                              
                                if (Type == 'EX_RATE') {
                                    document.getElementById("txtFreight_Exch_Rate").value = after2;
                                   
                                }

                                if (document.getElementById("txtFreight_Rate").value == '') {
                                    document.getElementById("txtFreight_Rate").value = '20.00';
                                }
                                else {
                                    document.getElementById("txtFreight_Rate").value = document.getElementById("txtFreight_Rate").value;
                                }
                            }
                            else {
                                if (Type == 'EX_RATE') {
                                    document.getElementById("txtFreight_Exch_Rate").value = after2;
                                }
                            }
//                            if (after2.length == 0) {
//                                $('#hdn_Invalid_FRT_Cur').val('');
//                            }
//                            else {
//                                $('#hdn_Invalid_FRT_Cur').val('Yes');
//                            }
                        }

                        get_value();

                    }
                    else {
                    }
                }

                function CallServerside_GetThirdParty(src, dest) {
                    var ctrl = document.getElementById(src);
                    PageMethods.Get_Imp_ThirdParty(ctrl.value, CallSuccess_Exp_ThirdParty, CallFailed, dest);
                }
                function CallSuccess_Exp_ThirdParty(res, destCtrl) {
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
                        var after10 = s[10];
                        var after11 = s[11];

                        document.getElementById("txt_ThirdPartyName").value = before;
                        document.getElementById("txt_ThirdParty_Add1").value = after1;
                        document.getElementById("txt_ThirdParty_Add2").value = after2;
                        document.getElementById("txt_ThirdParty_City").value = after3;
                        document.getElementById("txt_Country_Division").value = after4;
                        document.getElementById("txt_CountryCode").value = after5;
                        document.getElementById("txt_ThirdParty_Pin").value = after6;
                        document.getElementById("txt_TermsPlace").value = after7;
                        document.getElementById("txt_Authrzd_Economic_Code").value = '';
                        document.getElementById("txt_Authrzd_Economic_Country").value = '';
                        document.getElementById("txt_Authrzd_Economic_Role").value = '';
                        if (after11 != '') {
                            document.getElementById("txt_Whether_Relater_Y_N").value = after11;
                        }

                    }
                    else {
                        //        document.getElementById("txt_ThirdPartyName").value = '';
                        document.getElementById("txt_ThirdParty_Add1").value = '';
                        document.getElementById("txt_ThirdParty_Add2").value = '';
                        document.getElementById("txt_ThirdParty_City").value = '';
                        document.getElementById("txt_Country_Division").value = '';
                        document.getElementById("txt_CountryCode").value = '';
                        document.getElementById("txt_ThirdParty_Pin").value = '';
                        document.getElementById("txt_TermsPlace").value = '';
                        document.getElementById("txt_Authrzd_Economic_Code").value = '';
                        document.getElementById("txt_Authrzd_Economic_Country").value = '';
                        document.getElementById("txt_Authrzd_Economic_Role").value = '';
                        //document.getElementById("txt_Whether_Relater_Y_N").value = '';
                    }
                }


                $(function () {
                    $('#txt_ThirdPartyName').autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_ThirdParty_List",
                                data: "{ 'mail': '" + request.term + "' }",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                async: true,
                                success: function (data) {
                                    response(data.d);
                                    if (data.d == '') {
                                        jQuery('#txt_ThirdPartyName').validationEngine('showPrompt', 'Incorrect ThirdParty Name', 'error', 'topRight', true);

                                        //jAlert('Buyer Name is Incorrect', 'INVOICE', function (r) { document.getElementById("txtBuyerName').focus(); });
                                        //return false;
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

                $(document).ready(function () {
                    document.getElementById("hdn_LoadStatus").value = '';
                    $('#btnUpdate,#btnSave').click(function () {
                        //alert(this.id);
                        document.getElementById("hdn_LoadStatus").value = 'btnClick'
                    });


                });

                function CallServerside_Get_DuplicateInvoice_No(src, dest) {
                    var ctrl = document.getElementById(src);
                    var destl = document.getElementById(dest);
                    PageMethods.Get_Duplicate_InvoiceNo(ctrl.value, dest, CallSuccess_Imp_DuplicateInvoice_No, CallFailed, dest);
                }

                function CallSuccess_Imp_DuplicateInvoice_No(res, destCtrl) {
                    var dest = document.getElementById(destCtrl);
                    //dest.value = res;
                    var data = res;
                    if (data.indexOf("~~") != -1) {
                        var s = data.split('~~');
                        var jobno = s[0];

                        alert('Invoice No Already Exists! - JobNumber : ' + jobno);
                    }
                    else {
                        //        alert('b'); 
                    }
                }
