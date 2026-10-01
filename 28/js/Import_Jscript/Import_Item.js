function validate_Item() {

    var Desc = document.getElementById("txtDescription").value;
    if (Desc.length <= 0) {
        jAlert('Description cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtDescription").focus(); });

        return false;
    }
    var ItemQty = document.getElementById("txtItemQty").value;
    if (ItemQty.length <= 0) {
        jAlert('Item Qty cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItemQty").focus(); });

        return false;
    }

    if (ItemQty.length > 0) {
        var isValidNumber = /^-?\d+(\.\d+)?$/.test(ItemQty);

        if (!isValidNumber) {
            jAlert('Invalid  ItemQty', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItemQty").focus(); });
            return false;
        }
    }

    var QtyCode = document.getElementById("txtQtyCode").value;
    if (QtyCode.length <= 0) {
        jAlert('QtyCode cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtQtyCode").focus(); });
        return false;
    }
    else if (QtyCode.length < 3) {
        jAlert('QtyCode should be 3 characters', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtQtyCode").focus(); });

        return false;
    }



    var Item_UnitPrice = document.getElementById("txtItem_UnitPrice").value;
    if (Item_UnitPrice.length <= 0) {
        jAlert('UnitPrice cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_UnitPrice").focus(); });
        return false;
    }

    if (Item_UnitPrice.length > 0) {
        var isValidNumber = /^-?\d+(\.\d+)?$/.test(Item_UnitPrice);

        if (!isValidNumber) {
            jAlert('Invalid UnitPrice', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_UnitPrice").focus(); });
            return false;
        }
    }


    var Item_UnitPriceCode = document.getElementById("txtItem_UnitPriceCode").value;
    if (Item_UnitPriceCode.length <= 0) {
        jAlert('UnitPrice Code cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_UnitPriceCode").focus(); });
        return false;

    }

    else if (Item_UnitPriceCode.length < 3) {
        jAlert('UnitPrice Code should be 3 characters', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_UnitPriceCode").focus(); });
        return false;
    }


    var Item_Amount = document.getElementById("txtItem_Amount").value;
    if (Item_Amount.length <= 0) {
        jAlert('Item Amount cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_Amount").focus(); });
        return false;
    }

    if (Item_Amount.length > 0) {
        var isValidNumber = /^-?\d+(\.\d+)?$/.test(Item_Amount);

        if (!isValidNumber) {
            jAlert('Invalid Item Amount', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_Amount").focus(); });
            return false;
        }
    }


    var Item_AmountCode = document.getElementById("txtItem_AmountCode").value;
    if (Item_AmountCode.length <= 0) {
        jAlert('Item Amount Code cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_AmountCode").focus(); });
        return false;

    }

    else if (Item_AmountCode.length < 3) {
        jAlert('Item Amount Code should be 3 characters', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_AmountCode").focus(); });
        return false;
    }




    var CTH_No = document.getElementById("txtCTH_No").value;
    if (CTH_No.length <= 0) {
        jAlert('Ritc No. cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtCTH_No").focus(); });

        return false;

    }


    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtCTH_No").value.length; i++) {
        temp = document.getElementById("txtCTH_No").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {

            document.getElementById("ItemMain").click();
            document.getElementById("txtCTH_No").focus();

            return false;
        }
    }



    if (CTH_No.length < 8) {
        jAlert('CTH No should be 8 digit numbers', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtCTH_No").focus(); });
        return false;
    }


    var Info_Uqc = document.getElementById("txt_Info_Uqc").value;
    if (Info_Uqc.length <= 0) {
        jAlert('Info_Uqc cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txt_Info_Uqc").focus(); });
        return false;
    }
    else if (Info_Uqc.length < 3) {
        jAlert('Info_Uqc should be 3 characters', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txt_Info_Uqc").focus(); });

        return false;
    }

    var Info_Msr = document.getElementById("txt_Info_Msr").value;
    if (Info_Msr.length <= 0) {
        jAlert('Info_Msr cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txt_Info_Msr").focus(); });
        return false;
    }

    if (Info_Msr.length > 0) {
        var isValidNumber = /^-?\d+(\.\d+)?$/.test(Info_Msr);

        if (!isValidNumber) {
            jAlert('Invalid Info MSR', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txt_Info_Msr").focus(); });
            return false;
        }
    }

    var igstLevySLno = document.getElementById("txt_IGST_LEVY_SLNO").value;
    var igstLevyNotificationNo = document.getElementById("txt_IGST_LEVY_NOTN").value;

    if (igstLevySLno == "") {
        jAlert('Levy Sl No Cannot be blank');
    }
    if (igstLevyNotificationNo == "") {
        jAlert('Levy Notn No Cannot be blank');
    }
    setTimeout(function () {
    }, 30000);

    //ITEM GENERAL

//    var digits = "0123456789";
//    var temp;
//    for (var i = 0; i < document.getElementById("txtCTH_Qty1").value.length; i++) {
//        temp = document.getElementById("txtCTH_Qty1").value.substring(i, i + 1);
//        if (digits.indexOf(temp) == -1) {
//            document.getElementById("General").click();
//            document.getElementById("txtCTH_Qty1").focus();

//            return false;
//        }
//    }


//    var digits = "0123456789";
//    var temp;
//    for (var i = 0; i < document.getElementById("txtCTH_Qty2").value.length; i++) {
//        temp = document.getElementById("txtCTH_Qty2").value.substring(i, i + 1);
//        if (digits.indexOf(temp) == -1) {
//            document.getElementById("General").click();
//            document.getElementById("txtCTH_Qty2").focus();

//            return false;
//        }
//    }


    var GeneralDesc = document.getElementById("txtGeneralDesc").value;
    if (GeneralDesc.length <= 0) {
        jAlert('General Description cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtGeneralDesc").focus(); });

        return false;

    }


    var Manufacturer = document.getElementById("txtManufacturer").value;
    if (Manufacturer.length <= 0) {
        jAlert('Manufacturer cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtManufacturer").focus(); });

        return false;

    }


    var Brand = document.getElementById("txtBrand").value;
    if (Brand.length <= 0) {
        jAlert('Brand cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtBrand").focus(); });

        return false;

    }


    var Model = document.getElementById("txtModel").value;
    if (Model.length <= 0) {
        jAlert('Model cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtModel").focus(); });

        return false;


    }



    var EndUse = document.getElementById("txtEndUse").value;
    if (EndUse.length <= 0) {
        jAlert('EndUse cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtEndUse").focus(); });

        return false;

    }


    var CountryOrigin = document.getElementById("txtCountryOrigin").value;
    if (CountryOrigin.length <= 0) {
        jAlert('Country Origin cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtCountryOrigin").focus(); });

        return false;

    }


    //item cth

    var cth = document.getElementById("txtCTHNO").value;
    if (cth.length <= 0) {
        jAlert('CTHNO cannot be blank', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtCTHNO").focus(); });

        return false;
    }

    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtCTHNO").value.length; i++) {
        temp = document.getElementById("txtCTHNO").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtCTHNO").focus();

            return false;
        }
    }

    if (cth.length < 8) {
        jAlert('CTHNO should be 8 digit numbers', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtCTHNO").focus(); });

        return false;
    }


    var ritc = document.getElementById("txtRITCNO").value;
    if (ritc.length <= 0) {
        jAlert('RITCNO cannot be blank', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtRITCNO").focus(); });

        return false;

    }

    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtRITCNO").value.length; i++) {
        temp = document.getElementById("txtRITCNO").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtRITCNO").focus();

            return false;
        }
    }

    if (ritc.length < 8) {
        jAlert('RITCNO should be 8 digit numbers', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtRITCNO").focus(); });

        return false;
    }

//    var digits = "0123456789";
//    var temp;
//    for (var i = 0; i < document.getElementById("txtBasicNotn").value.length; i++) {
//        temp = document.getElementById("txtBasicNotn").value.substring(i, i + 1);
//        if (digits.indexOf(temp) == -1) {
//            document.getElementById("CTH").click();
//            document.getElementById("txtBasicNotn").focus();

//            return false;
//        }
//    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtBasicRate").value.length; i++) {
        temp = document.getElementById("txtBasicRate").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtBasicRate").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtEdu_Cess_Rate").value.length; i++) {
        temp = document.getElementById("txtEdu_Cess_Rate").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtEdu_Cess_Rate").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtSec_Edu_Cess_Rate").value.length; i++) {
        temp = document.getElementById("txtSec_Edu_Cess_Rate").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtSec_Edu_Cess_Rate").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtNCD_RATE").value.length; i++) {
        temp = document.getElementById("txtNCD_RATE").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtNCD_RATE").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtAggregate_RATE").value.length; i++) {
        temp = document.getElementById("txtAggregate_RATE").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtAggregate_RATE").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtSafeguard_RATE").value.length; i++) {
        temp = document.getElementById("txtSafeguard_RATE").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtSafeguard_RATE").focus();

            return false;
        }
    }

    var V_txtTariff_NOTN = document.getElementById("txtTariff_NOTN").value;
    var V_txtTariff_SL = document.getElementById("txtTariff_SL").value;

    var V_txtTariff_Qty = document.getElementById("txtTariff_Qty").value;
    var V_txtTariff_Amount = document.getElementById("txtTariff_Amount").value;
    var V_txtTariff_Amount_unitCode = document.getElementById("txtTariff_Amount_unitCode").value;

    if (V_txtTariff_NOTN.length == 0 || V_txtTariff_SL.length == 0 || V_txtTariff_Qty.length == 0 || V_txtTariff_Amount.length == 0 || V_txtTariff_Amount_unitCode.length == 0) {

        if (V_txtTariff_NOTN.length != 0) {

            if (V_txtTariff_SL == '') {
                jAlert(' Check Ur Tariff Slno', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtTariff_SL").focus(); });
                return false;
            }
            else {
                if (V_txtTariff_Qty == '') {
                    jAlert(' Check Ur Tariff Qty', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtTariff_Qty").focus(); });
                    return false;
                }
                else if (V_txtTariff_Amount == '') {
                    jAlert(' Check Ur Tariff Amt', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtTariff_SL").focus(); });
                    return false;
                }
                else if (V_txtTariff_Amount_unitCode.length < 3) {
                    jAlert(' Check Ur Tariff Amt UnitCode', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtTariff_Amount_unitCode").focus(); });
                    return false;
                }
            }
        }
        else {
            document.getElementById("txtTariff_Qty").value = '';
            document.getElementById("txtTariff_Amount").value = '';
            document.getElementById("txtTariff_Amount_unitCode").value = '';
            document.getElementById("txtTariff_SL").value = '';
        } 
    }

    var AIDC_NOTN = document.getElementById("txt_AIDC_NOTN").value;
    if (AIDC_NOTN.length <= 0) {
        jAlert('AID Cess Notn. cannot be blank', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txt_AIDC_NOTN").focus(); });
        return false;
    }
    var AIDC_NOTN_slno = document.getElementById("txt_AIDC_NOTN_SLNO").value;
    if (AIDC_NOTN_slno.length <= 0) {
        jAlert('AID Cess Notn Slno. cannot be blank', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txt_AIDC_NOTN_SLNO").focus(); });
        return false;
    }

    /*
    var AIDC_NOTN_Rate = document.getElementById("txt_AIDC_RATE").value;
    if (AIDC_NOTN_Rate.length <= 0) {
        jAlert('AID Cess Notn Rate. cannot be blank', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txt_AIDC_RATE").focus(); });
        return false;
    }
    */
    //CETH 

    if (document.getElementById("txtCETH_No").value == "") {
        jAlert('CETH NO cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtCETH_No").focus(); });

        return false;
    }
    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtCETH_No").value.length; i++) {
        temp = document.getElementById("txtCETH_No").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            jAlert('Enter correct CETH NO', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtCETH_No").focus(); });

            return false;
        }
    }

    var CETH_No = document.getElementById("txtCETH_No").value;
    if (CETH_No.length < 8) {
        jAlert('CETH_No should be 8 digit numbers', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtCETH_No").focus(); });

        return false;
    }

    if (document.getElementById("chkMRP_Duty").checked == true) {
        var Type = document.getElementById("ddl_RSP_Applicable").value;

        if (Type == 'Y') {

                    if (document.getElementById("txtMRP_SL_NO").value == "") {
                        jAlert('MRP_Duty cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtMRP_SL_NO").focus(); });

                        return false;
                    }
                    if (document.getElementById("txtMRP_AMOUNT").value == "") {
                        jAlert('MRP Amount cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtMRP_AMOUNT").focus(); });

                        return false;
                    }
                    if (document.getElementById("txtMRP_ABT_RATE").value == "") {
                        jAlert('MRP Rate cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtMRP_ABT_RATE").focus(); });

                        return false;
                    }
        }

    }
    else {
        $('#form1').validationEngine('detach');

    }


    var CountryOrigin = document.getElementById("txtCountryOrigin").value;
    var BasicNotn = document.getElementById("txtBasicNotn").value;
    var BasicSLNO = document.getElementById("txtBasicSLNO").value;

    if (CountryOrigin == "UNITED STATES" && BasicNotn == "050/2017" && BasicSLNO == "250A") {
        alert('Notn.No : 050/2017 - 250A - Not valid for UNITED STATES Country');
    }

    //            var Des = document.getElementById("txt_CVD_Education_CESS_Rate").value;

    //            if (Des.length <= 0) {
    //                jAlert('Education cess cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txt_CVD_Education_CESS_Rate").focus(); });

    //                return false;
    //            }



    //            var Des2 = document.getElementById("txt_CVD_Sec_Edu_CESS_Rate").value;

    //            if (Des2.length <= 0) {
    //                jAlert('Sec education cess cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txt_CVD_Sec_Edu_CESS_Rate").focus(); });

    //                return false;
    //            }
    var ddlRSP_Duty_yn = document.getElementById("ddlRSP_Duty_yn").value;
    if (ddlRSP_Duty_yn == 'Y') {
        var txtRSP_Slno = document.getElementById("txtRSP_Slno").value;

        if (txtRSP_Slno.length <= 0) {
            jAlert('RSP Slno cannot be blank', 'PRODUCT', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txtRSP_Slno").focus(); });

            return false;
        }

        var txtRSP_Description = document.getElementById("txtRSP_Description").value;

        if (txtRSP_Description.length <= 0) {
            jAlert('RSP Description cannot be blank', 'PRODUCT', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txtRSP_Description").focus(); });

            return false;
        }
        var txtRSP_Qty = document.getElementById("txtRSP_Qty").value;

        if (txtRSP_Qty.length <= 0) {
            jAlert('RSP Qty cannot be blank', 'PRODUCT', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txtRSP_Qty").focus(); });

            return false;
        }
        var txtRSP_Amount = document.getElementById("txtRSP_Amount").value;

        if (txtRSP_Amount.length <= 0) {
            jAlert('RSP Amount cannot be blank', 'PRODUCT', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txtRSP_Amount").focus(); });

            return false;
        }
    }
}

//page

function tab_page1(val) {

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';

    document.getElementById("General").className = 'inactive';
    document.getElementById("CTH").className = 'inactive';
    document.getElementById("CETH").className = 'inactive';
    document.getElementById("Other_Duty").className = 'inactive';
    document.getElementById("RE_IMPORT").className = 'inactive';
    document.getElementById("LICENCE").className = 'inactive';
    document.getElementById("Declaration").className = 'inactive';
    document.getElementById("SINGLE_WINDOW").className = 'inactive';
    document.getElementById("SUP_DOCS").className = 'inactive';

    //document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'ItemMain';
}
function tab_page22(val) {

    Parent_tab_count('');
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    //document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';

    document.getElementById('hdn_Inner_tab_Menu').value = 'General';
}

function tab_page3(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    // document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'CTH';

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
    // document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'CETH';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
}

function tab_page11(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    // document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'Block';
    document.getElementById("page-12").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'IGST';

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
    //document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'Other_Duty';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
}
/*-------------------------------------------------------------*/
function tab_page8(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    // document.getElementById("page-8").style.display = 'Block';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
}
/*-------------------------------------------------------------*/


function tab_License(val) {

    Parent_tab_count('');

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'Block';
    //document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'LICENCE';

    document.getElementById("Trans_product_licence_iframe").src = "../Transaction/License_Details.aspx";
}
function tab_Reimport(val) {
    Parent_tab_count('');

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';

    document.getElementById("page-6").style.display = 'Block';
    document.getElementById("page-7").style.display = 'none';
    // document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    //    document.getElementById("page-12").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'RE_IMPORT';

    document.getElementById("Trans_product_reimport_iframe").src = "../Transaction/ReImport_Details.aspx";
}
function tab_SINGLE_WINDOW(val) {
    Parent_tab_count('');

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    // document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'Block';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'SINGLE_WINDOW';

    document.getElementById("Trans_product_Singlewindow_iframe").src = "../IMP_Single_Window/Item_SingleWindow_Entry_2016.aspx";
}
function tab_Declaration(val) {
    Parent_tab_count('');

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    // document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'Block';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';

    document.getElementById('hdn_Inner_tab_Menu').value = 'Declaration';

    document.getElementById("Trans_product_Declaration_iframe").src = "../IMP_Single_Window/Statement.aspx";
}

function tab_SUPPORTING_DOCS(val) {
    Parent_tab_count('');

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    // document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'Block';

    document.getElementById('hdn_Inner_tab_Menu').value = 'SUP_DOCS';

    document.getElementById("Trans_Supporting_Documents_iframe").src = "../IMP_Single_Window/SW_Supportingdoc.aspx";
}
//page


//textbox
function updateTextbox() {
    var txt1 = document.getElementById("txtDescription");
    var txt2 = document.getElementById("txtGeneralDesc");
    var txt3 = document.getElementById("txtRSP_Description");

    var comp_id = document.getElementById("hdn_Company_IDD");
    var generalDdescFlag = document.getElementById('hdn_GeneralDescSame');

    if (comp_id.value == '152') {
        //txt2.value = 'COMPONENTS FOR EARTH MOVING EQUIPMENT';

        txt2.value = txt2.value;
    }
    else {
//        if (txt2.value.length <= 0) {
//            txt2.value = txt1.value;
        //        }
        if (generalDdescFlag.value === 'E') {
            txt2.value = txt1.value;
        }
        else {
            if (txt2.value.length <= 0) {
                txt2.value = txt1.value;
            }
        }
    }
    txt3.value = txt1.value;
}
function copy_ItemQTy_Textbox() {
    var txt1 = document.getElementById("txtRSP_Qty");
    var txt2 = document.getElementById("txtItemQty");

    txt1.value = txt2.value;

}
//textbox

//tab change
//-----------------------------------START SCHEME LOAD--------------------------------------//

function GetScheme1() {
    Loading_ShowImage();


    var ddlCountries;
    ddlCountries = document.getElementById("ddlSchemeCode");
    ddlCountries.options.length == 0;

    PageMethods.Get_Scheme1(ddlCountries.value, onsuccess);
}

function GetScheme2() {
    Loading_ShowImage();


    var ddlCountries = document.getElementById("ddlSchemeCode");
    var ddlCountries1 = document.getElementById("ddlScheme_NOTN");

    ddlCountries.options.length == 0;

    PageMethods.Get_Scheme2(ddlCountries.value, ddlCountries1.value, onsuccess1);
}

function onsuccess(response) {
    try {
        var ddl = document.getElementById("ddlScheme_NOTN");
        var ddl1 = document.getElementById("ddlScheme_NOTN_SL");
        var count = ddl.options.length;
        var count1 = ddl1.options.length;

        while (ddl.options.length > 0) {
            ddl.options.remove(0);
        }
        while (ddl1.options.length > 0) {
            ddl1.options.remove(0);
        }
        $.each(response, function () {
            $("#ddlScheme_NOTN").append($("<option></option>").val(this['scheme_Notn']).html(this['scheme_Notn']));

        });

        GetScheme2();
    }
    catch (e) {
        //alert(e);
    }
    Loading_HideImage();

}
function onsuccess1(response) {
    try {
        var ddl = document.getElementById("ddlScheme_NOTN_SL");
        var count = ddl.options.length;

        while (ddl.options.length > 0) {
            ddl.options.remove(0);
        }
        $.each(response, function () {
            $("#ddlScheme_NOTN_SL").append($("<option></option>").val(this['scheme_Notn_Slno']).html(this['scheme_Notn_Slno']));
        });

    }
    catch (e) {
        //alert(e);
    }
    Loading_HideImage();

}
//-----------------------------------START SCHEME LOAD--------------------------------------//
    
function General_tab() {
    document.getElementById("General").click();
}
function CTH_tab() {
   
    document.getElementById("CTH").click();
}

function AntiDumping_tab() {

    document.getElementById("Other_Duty").click();
}

function validate() {

    var Desc = document.getElementById("txtDescription").value;
    if (Desc.length <= 0) {
        jAlert('Description cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtDescription").focus(); });

        return false;
    }



    var ItemQty = document.getElementById("txtItemQty").value;

    if (ItemQty.length <= 0) {
        jAlert('Item Qty cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItemQty").focus(); });

        return false;
    }



    var QtyCode = document.getElementById("txtQtyCode").value;
    if (QtyCode.length <= 0) {
        jAlert('QtyCode cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtQtyCode").focus(); });

        return false;

    }

    else if (QtyCode.length < 3) {
        jAlert('QtyCode should be 3 characters', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtQtyCode").focus(); });

        return false;
    }

    var Item_UnitPrice = document.getElementById("txtItem_UnitPrice").value;
    if (Item_UnitPrice.length <= 0) {
        jAlert('UnitPrice cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_UnitPrice").focus(); });

        return false;

    }

    var Item_UnitPriceCode = document.getElementById("txtItem_UnitPriceCode").value;
    if (Item_UnitPriceCode.length <= 0) {
        jAlert('UnitPrice Code cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_UnitPriceCode").focus(); });

        return false;

    }

    else if (Item_UnitPriceCode.length < 3) {
        jAlert('UnitPrice Code should be 3 characters', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_UnitPriceCode").focus(); });

        return false;
    }


    var Item_Amount = document.getElementById("txtItem_Amount").value;
    if (Item_Amount.length <= 0) {
        jAlert('Item Amount cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_Amount").focus(); });

        return false;

    }

    var Item_AmountCode = document.getElementById("txtItem_AmountCode").value;
    if (Item_AmountCode.length <= 0) {
        jAlert('Item Amount Code cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_AmountCode").focus(); });

        return false;

    }

    else if (Item_AmountCode.length < 3) {
        jAlert('Item Amount Code should be 3 characters', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtItem_AmountCode").focus(); });

        return false;
    }




    var CTH_No = document.getElementById("txtCTH_No").value;
    if (CTH_No.length <= 0) {
        jAlert('CTH_No cannot be blank', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtCTH_No").focus(); });

        return false;

    }


    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtCTH_No").value.length; i++) {
        temp = document.getElementById("txtCTH_No").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {

            document.getElementById("ItemMain").click();
            document.getElementById("txtCTH_No").focus();

            return false;
        }
    }



    if (CTH_No.length < 8) {
        jAlert('CTH No should be 8 digit numbers', 'PRODUCT', function (r) { document.getElementById("ItemMain").click(); document.getElementById("txtCTH_No").focus(); });

        return false;
    }


    //ITEM GENERAL

    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtCTH_Qty1").value.length; i++) {
        temp = document.getElementById("txtCTH_Qty1").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("General").click();
            document.getElementById("txtCTH_Qty1").focus();

            return false;
        }
    }


    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtCTH_Qty2").value.length; i++) {
        temp = document.getElementById("txtCTH_Qty2").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("General").click();
            document.getElementById("txtCTH_Qty2").focus();

            return false;
        }
    }


    var GeneralDesc = document.getElementById("txtGeneralDesc").value;
    if (GeneralDesc.length <= 0) {
        jAlert('General Description cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtGeneralDesc").focus(); });

        return false;

    }


    var Manufacturer = document.getElementById("txtManufacturer").value;
    if (Manufacturer.length <= 0) {
        jAlert('Manufacturer cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtManufacturer").focus(); });

        return false;

    }


    var Brand = document.getElementById("txtBrand").value;
    if (Brand.length <= 0) {
        jAlert('Brand cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtBrand").focus(); });

        return false;

    }


    var Model = document.getElementById("txtModel").value;
    if (Model.length <= 0) {
        jAlert('Model cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtModel").focus(); });

        return false;


    }



    var EndUse = document.getElementById("txtEndUse").value;
    if (EndUse.length <= 0) {
        jAlert('EndUse cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtEndUse").focus(); });

        return false;

    }


    var CountryOrigin = document.getElementById("txtCountryOrigin").value;
    if (CountryOrigin.length <= 0) {
        jAlert('Country Origin cannot be blank', 'PRODUCT', function (r) { document.getElementById("General").click(); document.getElementById("txtCountryOrigin").focus(); });

        return false;

    }


    //item cth

    var cth = document.getElementById("txtCTHNO").value;
    if (cth.length <= 0) {
        jAlert('CTHNO cannot be blank', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtCTHNO").focus(); });

        return false;
    }

    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtCTHNO").value.length; i++) {
        temp = document.getElementById("txtCTHNO").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtCTHNO").focus();

            return false;
        }
    }

    if (cth.length < 8) {
        jAlert('CTHNO should be 8 digit numbers', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtCTHNO").focus(); });

        return false;
    }


    var ritc = document.getElementById("txtRITCNO").value;
    if (ritc.length <= 0) {
        jAlert('RITCNO cannot be blank', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtRITCNO").focus(); });

        return false;

    }

    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtRITCNO").value.length; i++) {
        temp = document.getElementById("txtRITCNO").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtRITCNO").focus();

            return false;
        }
    }

    if (ritc.length < 8) {
        jAlert('RITCNO should be 8 digit numbers', 'PRODUCT', function (r) { document.getElementById("CTH").click(); document.getElementById("txtRITCNO").focus(); });

        return false;
    }

    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtBasicNotn").value.length; i++) {
        temp = document.getElementById("txtBasicNotn").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtBasicNotn").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtBasicRate").value.length; i++) {
        temp = document.getElementById("txtBasicRate").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtBasicRate").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtEdu_Cess_Rate").value.length; i++) {
        temp = document.getElementById("txtEdu_Cess_Rate").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtEdu_Cess_Rate").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtSec_Edu_Cess_Rate").value.length; i++) {
        temp = document.getElementById("txtSec_Edu_Cess_Rate").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtSec_Edu_Cess_Rate").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtNCD_RATE").value.length; i++) {
        temp = document.getElementById("txtNCD_RATE").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtNCD_RATE").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtAggregate_RATE").value.length; i++) {
        temp = document.getElementById("txtAggregate_RATE").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtAggregate_RATE").focus();

            return false;
        }
    }

    var digits = "0123456789.";
    var temp;
    for (var i = 0; i < document.getElementById("txtSafeguard_RATE").value.length; i++) {
        temp = document.getElementById("txtSafeguard_RATE").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            document.getElementById("CTH").click();
            document.getElementById("txtSafeguard_RATE").focus();

            return false;
        }
    }

    //CETH 

    if (document.getElementById("txtCETH_No").value == "") {
        jAlert('CETH NO cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtCETH_No").focus(); });

        return false;
    }
    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtCETH_No").value.length; i++) {
        temp = document.getElementById("txtCETH_No").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            jAlert('Enter correct CETH NO', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtCETH_No").focus(); });

            return false;
        }
    }

    var CETH_No = document.getElementById("txtCETH_No").value;
    if (CETH_No.length < 8) {
        jAlert('CETH_No should be 8 digit numbers', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtCETH_No").focus(); });

        return false;
    }


    if (document.getElementById("chkMRP_Duty").checked == true) {
   
        if (document.getElementById("txtMRP_SL_NO").value == "") {
            jAlert('MRP_Duty cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtMRP_SL_NO").focus(); });

            return false;
        }
        if (document.getElementById("txtMRP_AMOUNT").value == "") {
            jAlert('MRP Amount cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtMRP_AMOUNT").focus(); });

            return false;
        }
        if (document.getElementById("txtMRP_ABT_RATE").value == "") {
            jAlert('MRP Rate cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txtMRP_ABT_RATE").focus(); });

            return false;
        }

    }
    else {
        $('#form1').validationEngine('detach');

    }

    //            var Des = document.getElementById("txt_CVD_Education_CESS_Rate").value;

    //            if (Des.length <= 0) {
    //                jAlert('Education cess cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txt_CVD_Education_CESS_Rate").focus(); });

    //                return false;
    //            }



    //            var Des2 = document.getElementById("txt_CVD_Sec_Edu_CESS_Rate").value;

    //            if (Des2.length <= 0) {
    //                jAlert('Sec education cess cannot be blank', 'PRODUCT', function (r) { document.getElementById("CETH").click(); document.getElementById("txt_CVD_Sec_Edu_CESS_Rate").focus(); });

    //                return false;
    //            }
    var ddlRSP_Duty_yn = document.getElementById("ddlRSP_Duty_yn").value;
    if (ddlRSP_Duty_yn == 'Y') {
        var txtRSP_Slno = document.getElementById("txtRSP_Slno").value;

        if (txtRSP_Slno.length <= 0) {
            jAlert('RSP Slno cannot be blank', 'PRODUCT', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txtRSP_Slno").focus(); });

            return false;
        }

        var txtRSP_Description = document.getElementById("txtRSP_Description").value;

        if (txtRSP_Description.length <= 0) {
            jAlert('RSP Description cannot be blank', 'PRODUCT', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txtRSP_Description").focus(); });

            return false;
        }
        var txtRSP_Qty = document.getElementById("txtRSP_Qty").value;

        if (txtRSP_Qty.length <= 0) {
            jAlert('RSP Qty cannot be blank', 'PRODUCT', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txtRSP_Qty").focus(); });

            return false;
        }
        var txtRSP_Amount = document.getElementById("txtRSP_Amount").value;

        if (txtRSP_Amount.length <= 0) {
            jAlert('RSP Amount cannot be blank', 'PRODUCT', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txtRSP_Amount").focus(); });

            return false;
        }

    }

}
//validation

// textbox keyup,keyip,keypress
$(function () {
    $('#txtItemQty').keyup(function () {
        var f1 = $('#txtItemQty').val();

        $('#txtRSP_Qty').val(f1.toUpperCase());
    });

    $('#txtItemQty').keyup(function () {
        var f1 = $('#txtItemQty').val();

        $('#txtCTH_Qty').val(f1.toUpperCase());
    });

    $('#txtItemQty').change(function () {
        var f2 = $('#txtItemQty').val();

        $('#txtRSP_Qty').val(f2.toUpperCase());

    });
    $('#txtItemQty').focus(function () {
        var f3 = $('#txtItemQty').val();

        $('#txtRSP_Qty').val(f3.toUpperCase());

    });

    //    $('#txtQtyCode').keyup(function () {
    //        var f1 = $('#txtQtyCode').val();

    //        $('#txtItem_UnitPriceCode').val(f1.toUpperCase());
    //    });

    //    $('#txtQtyCode').change(function () {
    //        var f2 = $('#txtQtyCode').val();

    //        $('#txtItem_UnitPriceCode').val(f2.toUpperCase());

    //    });
    //    $('#txtQtyCode').focus(function () {
    //        var f3 = $('#txtQtyCode').val();

    //        $('#txtItem_UnitPriceCode').val(f3.toUpperCase());

    //    });
    $('#txtCTH_No').focus(function () {

        var f4 = $('#txtCTH_No').val();

        $('#txtRITCNO').val(f4);
        $('#txtCTHNO').val(f4);
        $('#txtCETH_No').val(f4);


    });


    $('#txtCTH_No').change(function () {
        var f4 = $('#txtCTH_No').val();

        $('#txtRITCNO').val(f4);
        $('#txtCTHNO').val(f4);
        $('#txtCETH_No').val(f4);

    });
    $('#txtCTH_No').keyup(function () {
        var f4 = $('#txtCTH_No').val();

        $('#txtRITCNO').val(f4);
        $('#txtCTHNO').val(f4);
        $('#txtCETH_No').val(f4);

    });


});

// textbox keyup,keyip,keypress

//click       
function k() {
    tab_page2('0');


}
$('#btnNew').click(function () {
    $('#form1').validationEngine('detach');
    
});
$('#btnDelete').click(function () {
    $('#form1').validationEngine('detach');
});



//$(function () {
//    $('#ddl_RSP_Applicable').change(function () {
//    alert('xx');
//     var val=$('#ddl_RSP_Applicable').val();
//     alert(val);

//        var txtMRP_SL_NO = $('#txtMRP_SL_NO');
//        var txtRSP_Abt_Rate = $('#hdn_RSP_ABT_RATE');
//        var txtMRP_AMOUNT = $('#txtMRP_AMOUNT');

//        if (val == 'D') {
//        alert('a');
//            txtMRP_SL_NO.attr('disabled', false);
//            txtMRP_AMOUNT.attr('disabled', false);
//            txtMRP_ABT_RATE.attr('disabled', false);
//        }
//        else {
//            alert('b');
//            txtMRP_SL_NO.attr('disabled', true);
//            txtMRP_AMOUNT.attr('disabled', true);
//            txtMRP_ABT_RATE.attr('disabled', true);
//        }
//    });
//});

function CallSuccessRSP(res, destCtrl) {
    var CETH_No = document.getElementById("txtCETH_No").value;
    if (res == '') {
        alert(CETH_No + ' -  ' + 'RSP Not Applicable for this RITC')
    }
    else {
    }
}
$(function () {

    $('#chkMRP_Duty').click(function (e) {

        var txtMRP_SL_NO = $('#txtMRP_SL_NO');
        var txtRSP_Abt_Rate = $('#hdn_RSP_ABT_RATE');
        var txtMRP_AMOUNT = $('#txtMRP_AMOUNT');
        var txtMRP_ABT_RATE = $('#txtMRP_ABT_RATE');
        var txtRSP_Notn_No = $('#txtRSP_Notn_No');
        var txtRSP_Notn_Slno = $('#txtRSP_Notn_Slno');
        var ddl_RSP_Applicable = $('#ddl_RSP_Applicable');

        if (this.checked) {
//            var CETH_No = document.getElementById("txtCETH_No").value;
//            PageMethods.Get_RSP_Rate(CETH_No, CallSuccessRSP, CallFailed);

            txtMRP_SL_NO.attr('disabled', false);
            txtMRP_AMOUNT.attr('disabled', false);
            txtMRP_ABT_RATE.attr('disabled', false);
            txtRSP_Notn_No.attr('disabled', false);
            txtRSP_Notn_Slno.attr('disabled', false);
            ddl_RSP_Applicable.attr('disabled', false);

            txtMRP_SL_NO.val('1');
            txtRSP_Notn_No.val('SALE');
//            CallServerside_RSPDetails('txtCTH_No', 'txtCTH_No');
            ddl_RSP_Applicable.val('S');
        }
        else {

            txtMRP_SL_NO.attr('disabled', true);
            txtMRP_AMOUNT.attr('disabled', true);
            txtMRP_ABT_RATE.attr('disabled', true);
            txtRSP_Notn_No.attr('disabled', true);
            txtRSP_Notn_Slno.attr('disabled', true);
            ddl_RSP_Applicable.attr('disabled', true);

            txtMRP_SL_NO.val('');
            txtMRP_AMOUNT.val('');
            txtMRP_ABT_RATE.val('');
            txtRSP_Notn_No.val('');
            txtRSP_Notn_Slno.val('');
            ddl_RSP_Applicable.val('N');
        }
    });

    $('#ddlSchemeCode').change(function (e) {
        var selectedValue = $(this).val();


        //                if (selectedValue != '') {
        //                    //activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7']);
        //                    document.getElementById("d").click();
        //                }
    });
    $('#ddlRSP_Duty_yn').change(function (e) {
        var selectedValue = $(this).val();


        if (selectedValue != 'Y') {

            document.getElementById("RSP_DETAILS").style.display = 'none';

        }
        else if (selectedValue != 'N') {
            document.getElementById("RSP_DETAILS").style.display = 'Block';

        }

    });
});

//click       

//autocomplete search and page method

$(function () {
    $("#txtEndUse").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/End_Use_Of_Item_List",

                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtEndUse').validationEngine('showPrompt', 'Incorrect Description', 'error', 'topRight', true);

                    }
                    else {
                        jQuery('#txtEndUse').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
        $("#txtDescription0").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Item_Desc_List",

                    data: "{ 'mail': '" + request.term + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            jQuery('#txtDescription').validationEngine('showPrompt', 'Incorrect Description', 'error', 'topRight', true);
                            
                        }
                        else {
                            jQuery('#txtDescription').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtCTH_No,#txtCTHNO,#txtRITCNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CTH_Master_CTHNO_List",

                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtCTH_No') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect RITC NO', 'error', 'topRight', true);
                            //jAlert('RITC NO is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtCTHNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CTH NO', 'error', 'topRight', true);

                            //jAlert('CTH NO is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtRITCNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect RITC NO', 'error', 'topRight', true);

                            //jAlert('RITC NO is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtCETH_No").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CETH_Master_List",

                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {


                        jQuery('#txtCETH_No').validationEngine('showPrompt', 'Incorrect CETH No', 'error', 'topRight', true);
                        //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById("txtStateName").focus(); });
                        // return false;
                    }
                    else {
                        jQuery('#txtCETH_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtCTH_Qty1_Code,#txtCTH_Qty2_Code,#txtBasicUnit,#txtNCD_UNIT,#txtSafeguard_UNIT,#txt_CVD_UNIT,#txt_Addl_GSI_UNIT,#txt_Addl_SHE11_UNIT,#txt_Addl_TTA_UNIT,#txt_Addl_Health_CESS_UNIT,#txt_CESS_UNIT,#txtTariff_Amount_unitCode,#txtOther_Duty_UNIT").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

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
                       
                        if (field == 'txtCTH_Qty1_Code') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CTH_Qty1 code', 'error', 'topRight', true);

                            //jAlert('CTH_Qty1_Code is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtCTH_Qty2_Code') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CTH_Qty2 code', 'error', 'topRight', true);

                            //jAlert('CTH_Qty2_Code is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }

                        if (field == 'txtBasicUnit') {

                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Basic Unit', 'error', 'topRight', true);

                            //jAlert('Basic Unit is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtNCD_UNIT') {

                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect NCD Unit', 'error', 'topRight', true);

                            //jAlert('NCD_UNIT is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtSafeguard_UNIT') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Safeguard Unit', 'error', 'topRight', true);

                            //jAlert('Safeguard_UNIT is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_CVD_UNIT') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CVD Unit', 'error', 'topRight', true);

                            //jAlert('CVD_UNIT is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }

                        if (field == 'txt_Addl_GSI_UNIT') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_GSI Unit', 'error', 'topRight', true);

                            //jAlert('Addl_GSI_UNIT is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Addl_SHE11_UNIT') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_SHE11 Unit', 'error', 'topRight', true);

                            //jAlert('Addl_SHE11_UNIT is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Addl_TTA_UNIT') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_TTA Unit', 'error', 'topRight', true);

                            //jAlert('Addl_TTA_UNIT is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Addl_Health_CESS_UNIT') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_Health_CESS Unit', 'error', 'topRight', true);

                            //jAlert('Addl_Health_CESS_UNIT is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }

                        if (field == 'txt_CESS_UNIT') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CESS Unit', 'error', 'topRight', true);

                            //jAlert('Cess Unit is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtTariff_Amount_unitCode') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Tariff Unit Code', 'error', 'topRight', true);

                        }
                       
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);

                        var result = data.d;

                        var stringsearch = "-", str = result;

                        for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                        if (i == 1) {
                           
                            if (field == 'txtunitcode') {
                                $('#txtunitcode').val(result);
                            }

                            if (field == 'txtCTH_Qty1_Code') {
                                $('#txtCTH_Qty1_Code').val(result);
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
    $("#txtQtyCode").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({

                //                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_List",
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_STD_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtQtyCode') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Qty Code', 'error', 'topRight', true);

                            //jAlert('Qty Code is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);

                        var result = data.d;

                        var stringsearch = "-", str = result;

                        for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                        if (i == 1) {
                            if (field == 'txtQtyCode') {
                                $('#txtQtyCode').val(result);
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
    $("#txtCountryOrigin").autocomplete({
        source: function (request, response) {
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


                        jQuery('#txtCountryOrigin').validationEngine('showPrompt', 'Incorrect Country Origin', 'error', 'topRight', true);
                        //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById("txtStateName").focus(); });
                        // return false;
                    }
                    else {
                        jQuery('#txtCountryOrigin').validationEngine('hidePrompt', '', 'error', 'topRight', true);

                        var result = data.d;
                        var stringsearch = "-", str = result;

                        for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                        if (i == 1) {
                            $('#txtCountryOrigin').val(result);
                        }
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
    $("#txtBasicNotn,#txtAddlDuty_NOTN,#txtEdu_Cess_NOTN,#txtSec_Edu_Cess_NOTN,#txtNCD_NOTN,#txtSAPTA_NOTN,#txt_CVD_Education_CESS_Rate,#txt_CVD_Sec_Edu_CESS_Rate,#txt_Social_Welfare_NOTN").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CTH_Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtBasicNotn') {

                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect BasicNotn', 'error', 'topRight', true);

                            //jAlert('BasicNotn is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            // return false;
                        }
                        if (field == 'txtAddlDuty_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AddlDuty_NOTN', 'error', 'topRight', true);

                            //jAlert('AddlDuty_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtEdu_Cess_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Edu_Cess_NOTN', 'error', 'topRight', true);

                            //jAlert('Edu_Cess_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtSec_Edu_Cess_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Sec_Edu_Cess_NOTN', 'error', 'topRight', true);

                            //jAlert('Sec_Edu_Cess_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtNCD_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect NCD_NOTN', 'error', 'topRight', true);

                            //jAlert('NCD_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtSAPTA_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect SAPTA_NOTN', 'error', 'topRight', true);

                            //jAlert('SAPTA_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_CVD_Education_CESS_Rate') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CVD_Education_CESS_NOTN', 'error', 'topRight', true);

                            //jAlert('SAPTA_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_CVD_Sec_Edu_CESS_Rate') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CVD_Sec_Education_CESS_NOTN', 'error', 'topRight', true);

                            //jAlert('SAPTA_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Social_Welfare_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Social Welfare Notn ', 'error', 'topRight', true);

                            //jAlert('SAPTA_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txtAggregate_NOTN,#txtSafeguard_NOTN").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            var Type = '';
            if (field == 'txtAggregate_NOTN') {
                Type ='A';
            }
            if (field == 'txtSafeguard_NOTN') {
                Type ='S';
            }

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CTH_Notification_Custom_Master_List_NotnTYPE",
                data: "{ 'mail': '" + request.term + "','Type': '" + Type + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtAggregate_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Aggregate_NOTN', 'error', 'topRight', true);
                        }
                        if (field == 'txtSafeguard_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Safeguard_NOTN', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//----------------------------------- Anti-Dumping Notn- Start--------------------------------------------

$(function () {
    $("#txt_AntiDumping_Notn").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
           
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Anti_Dumping_Notification_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_AntiDumping_Notn').validationEngine('showPrompt', 'Incorrect AntiDumping', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_AntiDumping_Notn').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//------------------------------------------------------------------------------------------------

$(function () {
    $("#txt_AntiDumping_Notn_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Anti_Dumping_Notn_SLNO_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_AntiDumping_Notn").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_AntiDumping_Notn_SL').validationEngine('showPrompt', 'Incorrect AntiDumping SLNO', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_AntiDumping_Notn_SL').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//------------------------------------------------------------------------------------------------

$(function () {
    $("#txtCTH_SL_No").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Anti_Dumping_CTH_SLNO_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_AntiDumping_Notn").value + '~' + document.getElementById("txt_AntiDumping_Notn_SL").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtCTH_SL_No').validationEngine('showPrompt', 'Incorrect CTH SLNO', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txtCTH_SL_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//------------------------------------------------------------------------------------------------

$(function () {
    $("#txtBasicSLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtBasicNotn").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtBasicSLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect BasicSLNO', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                    }
//                    var notn_no = $('#txtBasicNotn");
//                   
//                    if (request.term != '' && notn_no.val() != '') {
//                        
//                        CallServerside_Basic_Duty_Cth_Notn_Slno(field, 'txtBasicNotn");
//                       
//                    }
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
    $("#txtAddlDuty_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtAddlDuty_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtAddlDuty_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AddlDuty_NOTN_SL', 'error', 'topRight', true);

                            //jAlert('AddlDuty_NOTN_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txtAddlDuty_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtAddlDuty_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtAddlDuty_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AddlDuty_NOTN_SL', 'error', 'topRight', true);

                            //jAlert('AddlDuty_NOTN_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txtEdu_Cess_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtEdu_Cess_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtEdu_Cess_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Edu_Cess_NOTN_SL', 'error', 'topRight', true);

                            //jAlert('Edu_Cess_NOTN_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txtSec_Edu_Cess_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtSec_Edu_Cess_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtSec_Edu_Cess_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Sec_Edu_Cess_NOTN_SL', 'error', 'topRight', true);

                            //jAlert('Sec_Edu_Cess_NOTN_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txtNCD_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtNCD_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtNCD_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect NCD_SLNO', 'error', 'topRight', true);

                            //jAlert('NCD_SLNO is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txtNCD_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtNCD_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtNCD_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect NCD_SLNO', 'error', 'topRight', true);

                            //jAlert('NCD_SLNO is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txtAggregate_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List_Aggregate_TYPE",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtAggregate_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtAggregate_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Aggregate_NOTN_SL', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
$(function () {
    $("#txtSafeguard_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List_SafeGuard_TYPE",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtSafeguard_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtSafeguard_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Safeguard_SL', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
$(function () {
    $("#txtSAPTA_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtSAPTA_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtSAPTA_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect SAPTA_NOTN_SL', 'error', 'topRight', true);

                            //jAlert('SAPTA_NOTN_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txt_Social_Welfare_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_Social_Welfare_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_Social_Welfare_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Social Welfare Notn SL', 'error', 'topRight', true);

                            //jAlert('AddlDuty_NOTN_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
//    $("#txt_CVD_NOTN,#txt_Addl5_SIA_NOTN,#txt_Addl_GSI_NOTN,#txt_Addl_SHE11_NOTN,#txt_Addl_TTA_NOTN,#txt_Addl_Health_CESS_NOTN,#txt_CESS_NOTN").autocomplete({
    $("#txt_CVD_NOTN,#txt_Addl5_SIA_NOTN,#txt_Addl_Health_CESS_NOTN,#txt_CESS_NOTN,#txtinfra_cess_Notn").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CETH_Notification_Excise_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_CVD_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CVD_NOTN', 'error', 'topRight', true);

                            //jAlert('CVD_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Addl5_SIA_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl5_SIA_NOTN', 'error', 'topRight', true);

                            //jAlert('Addl5_SIA_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Addl_GSI_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_GSI_NOTN', 'error', 'topRight', true);

                            //jAlert('Addl_GSI_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Addl_SHE11_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_SHE11_NOTN', 'error', 'topRight', true);

                            // jAlert('Addl_SHE11_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Addl_TTA_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_TTA_NOTN', 'error', 'topRight', true);

                            //jAlert('Addl_TTA_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Addl_Health_CESS_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_Health_CESS_NOTN', 'error', 'topRight', true);

                            //jAlert('Addl_Health_CESS_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            // return false;
                        }
                        if (field == 'txt_CESS_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CESS_NOTN', 'error', 'topRight', true);

                            //jAlert('CESS_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtinfra_cess_Notn') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Infra NOTN', 'error', 'topRight', true);
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

//NOTIFICATION EXCISE MASTER

$(function () {
    $("#txt_CVD_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_CVD_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_CVD_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CVD_SLNO', 'error', 'topRight', true);

                            //jAlert('CVD_SLNO is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txt_Addl5_SIA_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_Addl5_SIA_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_Addl5_SIA_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl5_SIA_NOTN_SL', 'error', 'topRight', true);

                            //jAlert('Addl5_SIA_NOTN_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txt_Addl_GSI_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_Addl_GSI_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_Addl_GSI_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_GSI_SL', 'error', 'topRight', true);

                            //jAlert('Addl_GSI_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txt_Addl_SHE11_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_Addl_SHE11_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_Addl_SHE11_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_SHE11_SLNO', 'error', 'topRight', true);

                            //jAlert('Addl_SHE11_SLNO is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txt_Addl_TTA_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_Addl_TTA_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_Addl_TTA_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_TTA_SLNO', 'error', 'topRight', true);

                            //jAlert('Addl_TTA_SLNO is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txt_Addl_Health_CESS_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_Addl_Health_CESS_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_Addl_Health_CESS_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Addl_Health_CESS_SLNO', 'error', 'topRight', true);

                            //jAlert('Addl_Health_CESS_SLNO is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txt_CESS_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_CESS_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_CESS_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CESS_SLNO', 'error', 'topRight', true);
                           
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
    $("#txtinfra_cess_Notn_SLNO").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Excise_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtinfra_cess_Notn").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtinfra_cess_Notn_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Infra SLNO', 'error', 'topRight', true);
                        }

                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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



$(function () {
    $("#txtRSP_Notn_No").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            var aa = document.getElementById("txtCETH_No").value;
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/RSP_Notn_Rate_List1",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + aa + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtRSP_Notn_No') {
                            jQuery('#' + field).validationEngine('showPrompt', 'RSP Notn Not Applicable', 'error', 'topRight', true);
                        }
                    }
                    else {
                            jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

$(function () {
    $("#txtRSP_Notn_Slno").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            var aa = document.getElementById("txtCETH_No").value;

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/RSP_Notn_SlNo_Rate_List",
                //                data: "{ 'mail': '" + aa + "','notn_no': '" + document.getElementById("txtRSP_Notn_No").value + "' }",
                data: "{ 'mail': '" + request.term + "','RITC': '" + aa + "','notn_no': '" + document.getElementById("txtRSP_Notn_No").value + "' }",

                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtRSP_Notn_Slno') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect RSP NotnSlNo', 'error', 'topRight', true);
                        }

                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//NOTIFICATION EXCISE MASTER

$(document).ready(function () {
    $('#txtCountryOrigin').focus(function () {

        var data = $(this).val();
        I_country(data);

    });
    $('#txtCountryOrigin').change(function () {

        var data = $(this).val();
        I_country(data);

    });
    $('#txtCountryOrigin').keyup(function () {

        var data = $(this).val();
        I_country(data);

    });
    $('#txtCountryOrigin').keydown(function () {

        var data = $(this).val();
        I_country(data);

    });

});

function I_country(val) {

    var I_data = val;
    if (I_data.indexOf("-") != -1) {
        var s = I_data.split('-');
        var before = s[0];
        var after = s[1];
        $('#txtCountryOrigin').val(before);
    }
} 

function country(val, txt) {

    var data = val;

    if (data.indexOf("-") != -1) {
        var s = data.split('-');
        var before = s[0];
        var after = s[1];
        $('#txtCountryOrigin').val(before);
    }
    else {

    }
} 



// call server side method
//---------------------CTH_MASTER----------------------//
function CallServerside_Basic_Duty_Cth_Notn_No(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Basic_Duty, CallFailed, dest);

}
function CallServerside_Basic_Duty_Cth_Notn_Slno(src, dest) {

    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method
    var type = 'C';

    //PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Basic_Duty, CallFailed, dest);
    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO_with_Type(ctrl.value, ctrl1.value, type, CallSuccess_Basic_Duty, CallFailed, dest);

}

function Call_Rsp_Rate(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    //alert('l");
    if (ctrl.length = 8) {
        PageMethods.Get_RSP_Rate(ctrl.value, CallSuccess, CallFailed, dest);
    }
}
// set the destination textbox value with the ContactName
function CallSuccess(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var dest1 = document.getElementById("txtMRP_ABT_RATE");
    dest.value = res;
    dest1.value = res;
//    $('#lblCTH_Rate').html(res);
}

function Call_CTH_Rate(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    if (ctrl.length = 8) {
        PageMethods.Get_CTH_Rate(ctrl.value, CallSuccessCTHRate, CallFailed, dest);
    }
}
// set the destination textbox value with the ContactName
function CallSuccessCTHRate(res, destCtrl) {
    $('#lblCTH_Rate').html(res);
}


function Call_CTH_Rate_SplAmount(src) {

    var ctrl = document.getElementById(src);
    if (ctrl.length = 8) {
        PageMethods.Get_CTH_Rate_SlpAmt(ctrl.value, CallSuccessCTHRateSplAmt, CallFailed);
    }
}
// set the destination textbox value with the ContactName
function CallSuccessCTHRateSplAmt(res, destCtrl) {
    if (res.indexOf("~~") != -1 && res.indexOf("~~") != '') {

        var s = res.split('~~');

        var spl_amt = s[0];
        var spl_unit = s[1];
        var RITC = s[2];
        var comp_id = document.getElementById("hdn_Company_IDD").value;
       
        if (RITC.length = 8) {
            if (spl_amt != '-1.000000') {

                var CTH_Qty1 = document.getElementById("txtCTH_Qty1").value;

                if (CTH_Qty1 == '') {
                    alert('CTH Qty Applicable for this RITC : ' + RITC);
                    document.getElementById("page-1").style.display = 'none';
                    document.getElementById("page-2").style.display = 'Block';
                    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
                    $('#txtCTH_Qty1').focus();
                }
            }

            if (comp_id == '1' || comp_id == '1534') { // MID WORLD SEATRANS         
                if (RITC == '25151210'){
                    document.getElementById("txt_Social_Welfare_NOTN").value = '011/2018';
                    document.getElementById("txt_Social_Welfare_NOTN_SL").value = '1';
                    document.getElementById("txt_Social_Welfare_Rate").value = '0.00'

                    document.getElementById("txt_AIDC_NOTN").value = '011/2021';
                    document.getElementById("txt_AIDC_NOTN_SLNO").value = '17';
                    document.getElementById("txt_AIDC_RATE").value = '0.00';
                }
            }
            // Condition Added by pandiyan on 23-05-2025
            if (RITC.substring(0, 6) == '310590' || RITC.substring(0, 4) == '3406' || RITC == '63023100' || RITC.substring(0, 4) == '6401' || RITC.substring(0, 4) == '6402' || RITC.substring(0, 4) == '6403' || RITC.substring(0, 4) == '6404' || RITC.substring(0, 4) == '6405' || RITC.substring(0, 4) == '7117' || RITC.substring(0, 4) == '8702' || RITC.substring(0, 4) == '8704' || RITC == '87120010' || RITC.substring(0, 4) == '8903' || RITC.substring(0, 4) == '9401' || RITC.substring(0, 4) == '9403' || RITC.substring(0, 4) == '9404' || RITC.substring(0, 4) == '9405' || RITC == '95030091') {
                document.getElementById("txt_Social_Welfare_NOTN").value = '011/2018';
                document.getElementById("txt_Social_Welfare_NOTN_SL").value = '1';
                document.getElementById("txt_Social_Welfare_Rate").value = '0.00';
            }
            // Condition Added by pandiyan on 15-07-2025
            if (RITC.substring(0, 4) == '7208' || RITC.substring(0, 4) == '7209' || RITC.substring(0, 4) == '7210' || RITC.substring(0, 4) == '7211' || RITC.substring(0, 4) == '7212' || RITC.substring(0, 4) == '7225' || RITC.substring(0, 4) == '7226') {
                document.getElementById("txtSafeguard_NOTN").value = '001/2025';
                document.getElementById("txtSafeguard_SL").value = '';
                document.getElementById("txtSafeguard_RATE").value = '12';
            }
            document.getElementById("lbl_Restricted").innerHTML = s[3];
        }
    }
}

function Call_CETH_Rate(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    //alert('l");
    if (ctrl.length = 8) {
        PageMethods.Get_CETH_Rate(ctrl.value, CallSuccessCETHRate, CallFailed, dest);
    }
}
// set the destination textbox value with the ContactName
function CallSuccessCETHRate(res, destCtrl) {

    if (res.indexOf("~~") != -1 && res.indexOf("~~") != '') {
      
        var s = res.split('~~');

        var CETH = s[0];
        var CETH_Rate = s[1];
        var spl_amt = s[2];
        var spl_unit = s[3];
        var SIA_Rate = s[4];
        var CETH_Cess_Amts = s[5];
        var CETH_Cess_unit = s[6];
        var CETH_Flag = s[7];
        
         $('#lblCETH_Rate').html(CETH_Rate);


         var comp_id = document.getElementById("hdn_Company_IDD");
         //alert(CETH);
         if (comp_id.value == '1' || comp_id.value == '10' || comp_id.value == '2038') {

             if (CETH == '27101949' || CETH == '27101930') {
                 if (document.getElementById("txt_Exc_AIDC_RATE").value == '') {
                     document.getElementById("txt_Exc_AIDC_SPL").value = '4.00';
                     document.getElementById("txt_Exc_AIDC_SPL_UNIT").value = spl_unit;
                 }
                 if (document.getElementById("txt_CVD_NOTN").value == '') {
                     document.getElementById("txt_CVD_SPL").value = spl_amt;
                     document.getElementById("txt_CVD_UNIT").value = spl_unit;
                 }
                 if (document.getElementById("txtinfra_cess_Notn").value == '') {
                     document.getElementById("txtinfra_cess_SPL").value = CETH_Cess_Amts;
                     document.getElementById("txtinfra_cess_SPL_UNIT").value = spl_unit;
                 }

                 if (SIA_Rate != '-1.00') {
                     document.getElementById("txt_Addl_GSI_SPL").value = SIA_Rate;
                     document.getElementById("txt_Addl_GSI_UNIT").value = CETH_Cess_unit;
                 }
                 else {
                     document.getElementById("txt_Addl_GSI_SPL").value = '';
                     document.getElementById("txt_Addl_GSI_UNIT").value = '';
                 }
             }
             else {
                 if (document.getElementById("txt_Exc_AIDC_NOTN").value == '') {
                     document.getElementById("txt_Exc_AIDC_SPL").value = '';
                     document.getElementById("txt_Exc_AIDC_SPL_UNIT").value = '';
                 }
                 if (document.getElementById("txtinfra_cess_Notn").value == '') {
                     document.getElementById("txtinfra_cess_SPL").value = '';
                     document.getElementById("txtinfra_cess_SPL_UNIT").value = '';
                 }

             }
         }
    }
    else {
        $('#lblCETH_Rate').html(res);
       
        if (document.getElementById("txt_Exc_AIDC_NOTN").value == '') {
            document.getElementById("txt_Exc_AIDC_SPL").value = '';
            document.getElementById("txt_Exc_AIDC_SPL_UNIT").value = '';
        }
        if (document.getElementById("txtinfra_cess_Notn").value == '') {
            document.getElementById("txtinfra_cess_SPL").value = '';
            document.getElementById("txtinfra_cess_SPL_UNIT").value = '';
        }

    }
}

function CallServerside_Add_Duty_Cth_Notn(src, dest) {
    var ctrl = document.getElementById(src);

    var ctrl1 = document.getElementById(dest);
//    if (document.getElementById("txtAddlDuty_NOTN").value == '019/2006') {
//        document.getElementById("txtAddlDuty_NOTN_SL").value = '4';

//    }
    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Add_Duty, CallFailed, dest);


}
function CallServerside_Add_Duty_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method
//    if (document.getElementById("txtAddlDuty_NOTN").value == '019/2006') {
//        document.getElementById("txtAddlDuty_NOTN_SL").value = '4';

//    }
    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Add_Duty, CallFailed, dest);

}

function CallServerside_Social_Welfare_Notn(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Social_Welfare_Cth, CallFailed, dest);
}

function CallServerside_Social_Welfare_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method
    var type = 'SWS';

    //PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Social_Welfare_Cth, CallFailed, dest);
    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO_with_Type(ctrl.value, ctrl1.value, type, CallSuccess_Social_Welfare_Cth, CallFailed, dest);

}

function CallServerside_Edu_Cess_Cth_Notn(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Edu_Cess_Cth, CallFailed, dest);
 }
function CallServerside_Edu_Cess_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Edu_Cess_Cth, CallFailed, dest);

}
function CallServerside_Sec_Higher_Edu_Cth_Notn(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Sec_Higher_Edu_Cth, CallFailed, dest);

}
function CallServerside_Sec_Higher_Edu_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Sec_Higher_Edu_Cth, CallFailed, dest);

}
function CallServerside_NCD_Cth_Notn(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_NCD_Duty_Cth, CallFailed, dest);

}
function CallServerside_NCD_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_NCD_Duty_Cth, CallFailed, dest);

}
function CallServerside_Aggregate_Duty_Cth_Notn(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Aggregate_Duty_Cth, CallFailed, dest);


}
function CallServerside_Aggregate_Duty_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Aggregate_Duty_Cth, CallFailed, dest);

}
function CallServerside_SafeGuard_Duty_Cth_Notn(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_SafeGuard_Duty_Cth, CallFailed, dest);



}
function CallServerside_SafeGuard_Duty_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_SafeGuard_Duty_Cth, CallFailed, dest);

}
function CallServerside_SAPTA_NOTN_Cth_Notn(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_SAPTA_NOTN_Cth, CallFailed, dest);



}
function CallServerside_SAPTA_NOTN_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_SAPTA_NOTN_Cth, CallFailed, dest);

}
function CallServerside_RITC(src, dest) {
    var ctrl = document.getElementById(src);
    
        PageMethods.Get_RITC(ctrl.value, CallSuccess_RITC, CallFailed, dest);
    
}
function CallSuccess_RITC(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
   
    var data = res;

    document.getElementById("txtCTH_No").value = data;

}
//--------------------------------NOTN----------------------------------------------

// calling Basic_Duty_Cth

// set the destination textbox value with the ContactName
function CallSuccess_Basic_Duty(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;

    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {
    
        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];

        //document.getElementById("txtBasicNotn").value = before;
        //document.getElementById("txtBasicSLNO").value = after1;
        document.getElementById("txtBasicRate").value = after2;
        document.getElementById("txtBasicSPL").value = after3;
        document.getElementById("txtBasicUnit").value = after4;
    }
    else {

        //document.getElementById("txtBasicNotn").value = '';
        //document.getElementById("txtBasicSLNO").value = '';
        document.getElementById("txtBasicRate").value = '';
        document.getElementById("txtBasicSPL").value = '';
        document.getElementById("txtBasicUnit").value = '';
    }
}
// calling Basic_Duty_Cth
// calling Add_Duty_Cth

// set the destination textbox value with the ContactName
function CallSuccess_Add_Duty(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');
        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        //document.getElementById("txtAddlDuty_NOTN").value = before;
        //document.getElementById("txtAddlDuty_NOTN_SL").value = after1;
        document.getElementById("txtAddlDuty_Rate").value = after2;
    }
    else {
        //document.getElementById("txtAddlDuty_NOTN").value = '';
        //document.getElementById("txtAddlDuty_NOTN_SL").value = '';
        document.getElementById("txtAddlDuty_Rate").value = '';
//        if (document.getElementById("txtAddlDuty_NOTN").value == '019/2006') {
//            document.getElementById("txtAddlDuty_NOTN_SL").value = '4';
//        }
    }
}
// calling Add_Duty_Cth
// calling Edu_Cess_Cth

// set the destination textbox value with the ContactName
function CallSuccess_Social_Welfare_Cth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];


        //document.getElementById("txtEdu_Cess_NOTN").value = before;
        //document.getElementById("txtEdu_Cess_NOTN_SL").value = after1;
        document.getElementById("txt_Social_Welfare_Rate").value = after2;


    }
    else {
        //document.getElementById("txtEdu_Cess_NOTN").value = '';
        //document.getElementById("txtEdu_Cess_NOTN_SL").value = '';
        document.getElementById("txt_Social_Welfare_Rate").value = '10.00';

    }

}


// set the destination textbox value with the ContactName
function CallSuccess_Edu_Cess_Cth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];


        //document.getElementById("txtEdu_Cess_NOTN").value = before;
        //document.getElementById("txtEdu_Cess_NOTN_SL").value = after1;
        document.getElementById("txtEdu_Cess_Rate").value = after2;


    }
    else {
        //document.getElementById("txtEdu_Cess_NOTN").value = '';
        //document.getElementById("txtEdu_Cess_NOTN_SL").value = '';
        document.getElementById("txtEdu_Cess_Rate").value = '';

    }

}
// calling Edu_Cess_Cth
// calling Sec_Higher_Edu_Cth

// set the destination textbox value with the ContactName
function CallSuccess_Sec_Higher_Edu_Cth(res, destCtrl) {

    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        //document.getElementById("txtSec_Edu_Cess_NOTN").value = before;
        //document.getElementById("txtSec_Edu_Cess_NOTN_SL").value = after1;
        document.getElementById("txtSec_Edu_Cess_Rate").value = after2;


    }
    else {
        //document.getElementById("txtSec_Edu_Cess_NOTN").value = '';
        //document.getElementById("txtSec_Edu_Cess_NOTN_SL").value = '';
        document.getElementById("txtSec_Edu_Cess_Rate").value = '';

    }

}
// calling Sec_Higher_Edu_Cth

// calling NCD_Duty_Cth

// set the destination textbox value with the ContactName
function CallSuccess_NCD_Duty_Cth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];


        //document.getElementById("txtNCD_NOTN").value = before;
        //document.getElementById("txtNCD_SLNO").value = after1;
        document.getElementById("txtNCD_RATE").value = after2;
        document.getElementById("txtNCD_SPL").value = after3;
        document.getElementById("txtNCD_UNIT").value = after4;


    }
    else {
        //document.getElementById("txtNCD_NOTN").value = '';
        //document.getElementById("txtNCD_SLNO").value = '';
        document.getElementById("txtNCD_RATE").value = '';
        document.getElementById("txtNCD_SPL").value = '';
        document.getElementById("txtNCD_UNIT").value = '';

    }

}
// calling NCD_Duty_Cth

// calling Aggregate_Duty_Cth

// set the destination textbox value with the ContactName
function CallSuccess_Aggregate_Duty_Cth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];


        //document.getElementById("txtAggregate_NOTN").value = before;
        //document.getElementById("txtAggregate_NOTN_SL").value = after1;
        document.getElementById("txtAggregate_RATE").value = after2;


    }
    else {
        //document.getElementById("txtAggregate_NOTN").value = '';
        //document.getElementById("txtAggregate_NOTN_SL").value = '';
        document.getElementById("txtAggregate_RATE").value = '';

    }

}
// calling Aggregate_Duty_Cth

// calling SafeGuard_Duty_Cth

// set the destination textbox value with the ContactName
function CallSuccess_SafeGuard_Duty_Cth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];


        //document.getElementById("txtSafeguard_NOTN").value = before;
        //document.getElementById("txtSafeguard_SL").value = after1;
        document.getElementById("txtSafeguard_RATE").value = after2;
        document.getElementById("txtSafeguard_SPL").value = after3;
        document.getElementById("txtSafeguard_UNIT").value = after4;


    }
    else {
        //document.getElementById("txtSafeguard_NOTN").value = '';
        //document.getElementById("txtSafeguard_SL").value = '';
        document.getElementById("txtSafeguard_RATE").value = '';
        document.getElementById("txtSafeguard_SPL").value = '';
        document.getElementById("txtSafeguard_UNIT").value = '';

    }

}
// calling SAPTA_Cth

// set the destination textbox value with the ContactName
function CallSuccess_SAPTA_NOTN_Cth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];


        //document.getElementById("txtSAPTA_NOTN").value = before;
        //document.getElementById("txtSAPTA_NOTN_SL").value = after1;
        document.getElementById("txtSAPTA_RATE").value = after2;


    }
    else {
        //document.getElementById("txtSAPTA_NOTN").value = '';
        //document.getElementById("txtSAPTA_NOTN_SL").value = '';
        document.getElementById("txtSAPTA_RATE").value = '';

    }

}
// calling SafeGuard_Duty_Cth
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}
//---------------------CTH_MASTER----------------------//

//---------------------CETH_MASTER----------------------//
function CallServerside_CVD_Duty_Ceth_Notn_No(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_CVD_Duty_Ceth, CallFailed, dest);


}
function CallServerside_CVD_Duty_Ceth_Notn_SlNo(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_CVD_Duty_Ceth, CallFailed, dest);


}

function CallServerside_Add_Duty_Ceth_Notn_No(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Add_Duty_Ceth, CallFailed, dest);


}
function CallServerside_Add_Duty_Ceth_Notn_SlNo(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Add_Duty_Ceth, CallFailed, dest);


}
function CallServerside_Add_Duty_Excise_GSI_Ceth_Notn_No(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Add_Duty_Excise_GSI_Ceth, CallFailed, dest);

}
function CallServerside_Add_Duty_Excise_GSI_Ceth_Notn_SlNo(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Add_Duty_Excise_GSI_Ceth, CallFailed, dest);


}
function CallServerside_Spl_Excise_Duty_Ceth_Notn_No(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Spl_Excise_Duty_Ceth, CallFailed, dest);


}
function CallServerside_Spl_Excise_Duty_Ceth_Notn_SlNo(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Spl_Excise_Duty_Ceth, CallFailed, dest);


}
function CallServerside_Add_Duty_Excise_TTA_Ceth_Notn_No(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Add_Duty_Excise_TTA_Ceth, CallFailed, dest);

}
function CallServerside_Add_Duty_Excise_TTA_Ceth_Notn_SlNo(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Add_Duty_Excise_TTA_Ceth, CallFailed, dest);

}
function CallServerside_Health_Cess_Ceth_Notn_No(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Health_Cess_Ceth, CallFailed, dest);

}
function CallServerside_Health_Cess_Ceth_Notn_SlNo(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Health_Cess_Ceth, CallFailed, dest);

}
function CallServerside_Cess_Notn_Ceth_Notn_No(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);


    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_NO(ctrl.value, ctrl1.value, CallSuccess_Cess_Notn_Ceth, CallFailed, dest);

}
//-----------------------------------------------------
function CallServerside_infra_cess_Notn_SLNO(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);
    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_infra_cess_Notn, CallFailed, dest);
}


function CallSuccess_infra_cess_Notn(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');
        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        document.getElementById("txtinfra_cess_Notn_RATE").value = after2;
    }
    else {
        document.getElementById("txtinfra_cess_Notn_RATE").value = '';
    }
}

//--------------------------------- RSP Notn Slno ---------------------------------

function CallServerside_RSP_Notn_SLNO_Rate(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);
//    alert(ctrl);
//    alert(ctrl1);

    PageMethods.Get_RSP_Notn_SlNo_Rate(ctrl.value, CallSuccess_infra_cess_Notn, CallFailed, dest);
}

//-----------------------------------------------------


function CallServerside_Cess_Notn_Ceth_Notn_SlNo(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Excise_Master_CETH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Cess_Notn_Ceth, CallFailed, dest);
}


// call server side method

// calling CVD_Duty_Ceth

// set the destination textbox value with the ContactName
function CallSuccess_CVD_Duty_Ceth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];
        var after6 = s[6];
        var after7 = s[7];

        //document.getElementById("txt_CVD_NOTN").value = before;
        //document.getElementById("txt_CVD_SLNO").value = after1;
        document.getElementById("txt_CVD_RATE").value = after2;
        document.getElementById("txt_CVD_SPL").value = after3;
        document.getElementById("txt_CVD_UNIT").value = after4;
    }
    else {
        //document.getElementById("txt_CVD_NOTN").value = '';
        //document.getElementById("txt_CVD_SLNO").value = '';
        document.getElementById("txt_CVD_RATE").value = '';
        document.getElementById("txt_CVD_SPL").value = '';
        document.getElementById("txt_CVD_UNIT").value = '';

    }

}
// calling CVD_Duty_Ceth

// calling Add_Duty_Ceth

// set the destination textbox value with the ContactName
function CallSuccess_Add_Duty_Ceth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        //document.getElementById("txt_Addl5_SIA_NOTN").value = before;
        //document.getElementById("txt_Addl5_SIA_NOTN_SL").value = after1;
        document.getElementById("txt_Addl5_SIA_RATE").value = after2;

    }
    else {
        //document.getElementById("txt_Addl5_SIA_NOTN").value = '';
        //document.getElementById("txt_Addl5_SIA_NOTN_SL").value = '';
        document.getElementById("txt_Addl5_SIA_RATE").value = '';

    }
}
// calling Add_Duty_Ceth

// calling Add_Duty_Excise_GSI_Ceth

// set the destination textbox value with the ContactName
function CallSuccess_Add_Duty_Excise_GSI_Ceth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];
        var after7 = s[7];

     

        //document.getElementById("txt_Addl_GSI_NOTN").value = before;
        //document.getElementById("txt_Addl_GSI_SL").value = after1;
        document.getElementById("txt_Addl_GSI_RATE").value = after2;
        document.getElementById("txt_Addl_GSI_SPL").value = after3;
        document.getElementById("txt_Addl_GSI_UNIT").value = after4;


    }
    else {
        //document.getElementById("txt_Addl_GSI_NOTN").value = '';
        //document.getElementById("txt_Addl_GSI_SL").value = '';
        document.getElementById("txt_Addl_GSI_RATE").value = '';
        document.getElementById("txt_Addl_GSI_SPL").value = '';
        document.getElementById("txt_Addl_GSI_UNIT").value = '';

    }
}
// calling Add_Duty_Excise_GSI_Ceth
// calling Spl_Excise_Duty_Ceth

// set the destination textbox value with the ContactName
function CallSuccess_Spl_Excise_Duty_Ceth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];
        var after6 = s[6];


        //document.getElementById("txt_Addl_SHE11_NOTN").value = before;
        //document.getElementById("txt_Addl_SHE11_SLNO").value = after1;
        document.getElementById("txt_Addl_SHE11_RATE").value = after2;
        document.getElementById("txt_Addl_SHE11_SPL").value = after3;
        document.getElementById("txt_Addl_SHE11_UNIT").value = after4;


    }
    else {
        //document.getElementById("txt_Addl_SHE11_NOTN").value = '';
        //document.getElementById("txt_Addl_SHE11_SLNO").value = '';
        document.getElementById("txt_Addl_SHE11_RATE").value = '';
        document.getElementById("txt_Addl_SHE11_SPL").value = '';
        document.getElementById("txt_Addl_SHE11_UNIT").value = '';

    }
}
// calling Spl_Excise_Duty_Ceth
// calling Add_Duty_Excise_TTA_Ceth

// set the destination textbox value with the ContactName
function CallSuccess_Add_Duty_Excise_TTA_Ceth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];
        var after6 = s[6];

        //document.getElementById("txt_Addl_TTA_NOTN").value = before;
        //document.getElementById("txt_Addl_TTA_SLNO").value = after1;
        document.getElementById("txt_Addl_TTA_RATE").value = after2;
        document.getElementById("txt_Addl_TTA_SPL").value = after3;
        document.getElementById("txt_Addl_TTA_UNIT").value = after4;
    }
    else {
        //document.getElementById("txt_Addl_TTA_NOTN").value = '';
        //document.getElementById("txt_Addl_TTA_SLNO").value = '';
        document.getElementById("txt_Addl_TTA_RATE").value = '';
        document.getElementById("txt_Addl_TTA_SPL").value = '';
        document.getElementById("txt_Addl_TTA_UNIT").value = '';
    }
}
// calling Add_Duty_Excise_TTA_Ceth
// calling Health_Cess_Ceth

// set the destination textbox value with the ContactName
function CallSuccess_Health_Cess_Ceth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];
        var after6 = s[6];

        //document.getElementById("txt_Addl_Health_CESS_NOTN").value = before;
        //document.getElementById("txt_Addl_Health_CESS_SLNO").value = after1;
        document.getElementById("txt_Addl_Health_CESS_RATE").value = after2;
        document.getElementById("txt_Addl_Health_CESS_SPL").value = after3;
        document.getElementById("txt_Addl_Health_CESS_UNIT").value = after4;
    }
    else {
        //document.getElementById("txt_Addl_Health_CESS_NOTN").value = '';
        //document.getElementById("txt_Addl_Health_CESS_SLNO").value = '';
        document.getElementById("txt_Addl_Health_CESS_RATE").value = '';
        document.getElementById("txt_Addl_Health_CESS_SPL").value = '';
        document.getElementById("txt_Addl_Health_CESS_UNIT").value = '';

    }
}
// calling Health_Cess_Ceth

// calling Cess_Notn_Ceth

// set the destination textbox value with the ContactName
function CallSuccess_Cess_Notn_Ceth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];
        var after6 = s[6];

        //document.getElementById("txt_CESS_NOTN").value = before;
        //document.getElementById("txt_CESS_SLNO").value = after1;
        document.getElementById("txt_CESS_RATE").value = after2;
        document.getElementById("txt_CESS_SPL").value = after3;
        document.getElementById("txt_CESS_UNIT").value = after4;
    }
    else {
       // document.getElementById("txt_CESS_NOTN").value = '';
        //document.getElementById("txt_CESS_SLNO").value = '';
        document.getElementById("txt_CESS_RATE").value = '';
        document.getElementById("txt_CESS_SPL").value = '';
        document.getElementById("txt_CESS_UNIT").value = '';

    }
}
// calling Cess_Notn_Ceth

//---------------------CETH_MASTER----------------------//

function CallServerside_GetItemQty(src, dest) {
    ShowImage(src);
    var e;
    var ctrl = document.getElementById(src);
    // call server side method
    var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInvoice_SlNo, HiddenField1, txtItem_UnitPrice;
    hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
    txtItem_Amount = document.getElementById("txtItem_Amount").value;
    hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
    //ddlInvoice_SlNo = document.getElementById("ddlInvoice_SlNo").value;
    e = document.getElementById("ddlInvoice_SlNo");
    ddlInvoice_SlNo = e.options[e.selectedIndex].text;
    HiddenField1 = document.getElementById("HiddenField1").value;
    txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;
    PageMethods.Get_Item_Qty(ctrl.value, hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInvoice_SlNo, HiddenField1, txtItem_UnitPrice, CallSuccess_ItemQty, CallFailed, dest);
}


function CallSuccess_ItemQty(res, destCtrl) {
    HideImage('txtItemQty');
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    var BEType_Exbond = document.getElementById("hdn_Exbond_Val").value;
    
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        if (after2 != '') {

            if (BEType_Exbond != 'Ex-Bond') {
                document.getElementById("txtItem_Amount").value = before;
                document.getElementById("txtItem_UnitPrice").value = after1;
            }
            else {
                document.getElementById("txtItem_UnitPrice").disabled = true;
                document.getElementById("txtItem_Amount").disabled = true;

            }
        }
        //            else {
        //                jAlert('Enter Qty', 'PRODUCT', function (r) {

        //                    document.getElementById("txtItemQty").focus();
        //                });
        //                return false;
        //            }
        document.getElementById("txtItemQty").focus();

    }
    else {
        document.getElementById("txtItem_Amount").value = '';
        document.getElementById("txtItem_UnitPrice").value = '';
        document.getElementById("txtItemQty").focus();
    }
}
function CallServerside_GetItem_UnitPrice(src, dest) {
    ShowImage(src);
    var e;
    var ctrl = document.getElementById(src);
    // call server side method
    var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInvoice_SlNo, HiddenField1, txtItemQty;
    hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
    txtItem_Amount = document.getElementById("txtItem_Amount").value;
    hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
    //ddlInvoice_SlNo = document.getElementById("ddlInvoice_SlNo").value;
    e = document.getElementById("ddlInvoice_SlNo");
    ddlInvoice_SlNo = e.options[e.selectedIndex].text;
    HiddenField1 = document.getElementById("HiddenField1").value;
    txtItemQty = document.getElementById("txtItemQty").value;
    PageMethods.Get_Item_UnitPrice(ctrl.value, hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInvoice_SlNo, HiddenField1, txtItemQty, CallSuccess_ItemUnitprice, CallFailed, dest);

}
function CallSuccess_ItemUnitprice(res, destCtrl) {
    HideImage('txtItem_UnitPrice');
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];

        document.getElementById("txtItem_Amount").value = after1;
        if (before == '') {
            //                jAlert('Enter UnitPrice', 'PRODUCT', function (r) {

            //                    document.getElementById("txtItem_UnitPrice").focus();
            //                });
            //                return false;
        }
        else if (after2 == '') {
            jQuery('#txtItemQty').validationEngine('showPrompt', 'Enter Qty', 'error', 'topRight', true);

            //jAlert('Enter Qty', 'PRODUCT', function (r) {

            document.getElementById("txtItemQty").focus();
            //});
            //return false;

        }
        else if (after3 == '2') {
            var hdn_Grid_Count = document.getElementById("hdn_Grid_Count").value;

            if (hdn_Grid_Count != '') {

                jQuery('#txtItem_UnitPrice').validationEngine('showPrompt', 'Higher than invoice value', 'error', 'topRight', true);

                //jAlert('Higher than invoice value', 'PRODUCT', function (r) {

                document.getElementById("txtItem_UnitPrice").focus();
                //});
                // return false;

            }
        }
    }
}
function CallServerside_GetItem_amount(src, dest) {
    ShowImage('txtItem_Amount');
    var e;
    var ctrl = document.getElementById(src);
    // call server side method
    var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInvoice_SlNo, HiddenField1, txtItemQty;
    hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
    txtItem_Amount = document.getElementById("txtItem_Amount").value;
    hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
    //ddlInvoice_SlNo = document.getElementById("ddlInvoice_SlNo").value;
    e = document.getElementById("ddlInvoice_SlNo");
    ddlInvoice_SlNo = e.options[e.selectedIndex].text;
    HiddenField1 = document.getElementById("HiddenField1").value;
    txtItemQty = document.getElementById("txtItemQty").value;
    PageMethods.Get_Item_amount(ctrl.value, hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInvoice_SlNo, HiddenField1, txtItemQty, CallSuccess_Itemamount, CallFailed, dest);

}
function CallSuccess_Itemamount(res, destCtrl) {
    HideImage('txtItem_Amount');
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];

        document.getElementById("txtItem_Amount").value = after1;
        document.getElementById("txtItem_UnitPrice").value = before;
        if (before == '') {
            //                jAlert('Enter UnitPrice', 'PRODUCT', function (r) {

            //                    document.getElementById("txtItem_UnitPrice").focus();
            //                });
            //                return false;
        }
        else if (after2 == '') {
            jQuery('#txtItemQty').validationEngine('showPrompt', 'Enter Qty', 'error', 'topRight', true);

            //jAlert('Enter Qty', 'PRODUCT', function (r) {

            document.getElementById("txtItemQty").focus();
            //});
            //return false;

        }
        else if (after3 == '2') {
            var hdn_Grid_Count = document.getElementById("hdn_Grid_Count").value;

            if (hdn_Grid_Count != '') {

                jQuery('#txtItem_UnitPrice').validationEngine('showPrompt', 'Higher than invoice value', 'error', 'topRight', true);

                //jAlert('Higher than invoice value', 'PRODUCT', function (r) {

               // document.getElementById("txtItem_UnitPrice").focus();
                //});
                // return false;

            }
        }
    }
}
//autocomplete search and page method
//Anti Dumping
// call server side method
//---------------------Anti Dumping SLNo----------------------//
function CallServerside_AntiDumping(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method
   
    PageMethods.Get_AntiDumping(ctrl.value, ctrl1.value, CallSuccess_AntiDumping, CallFailed, dest);

}
// set the destination textbox value with the ContactName
function CallSuccess_AntiDumping(res, destCtrl) {
    
    var data = res;
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var NotnSlNo = s[3];
      
        document.getElementById("txtCTH_SL_No").value = before;
        document.getElementById("txtCTH_Supplier_SL").value = after1;
        document.getElementById("hdn_ADD_SLNO").value = NotnSlNo;
        //document.getElementById("txtCTH_Qty").value = after2;
    }
    else {

        document.getElementById("txtCTH_SL_No").value = "";
        document.getElementById("txtCTH_Supplier_SL").value = "";
        document.getElementById("hdn_ADD_SLNO").value = "";
        //document.getElementById("txtCTH_Qty").value = "";
    }
}


//---------------------Anti Dumping _CTH_SLNO----------------------//
function CallServerside_AntiDumping_CTH_SLNO(src, dest, CTH_slno) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    var CTH_slno1 = document.getElementById(CTH_slno);

    // call server side method
    
    PageMethods.Get_AntiDumping_CTH_SLno(ctrl.value, ctrl1.value, CTH_slno1.value, CallSuccess_AntiDumping_CTH_SLNO, CallFailed, dest);

}
// set the destination textbox value with the ContactName
function CallSuccess_AntiDumping_CTH_SLNO(res, destCtrl) {

    var data = res;
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var NotnSlNo = s[3];

        document.getElementById("txtCTH_SL_No").value = before;
        document.getElementById("txtCTH_Supplier_SL").value = after1;
        document.getElementById("hdn_ADD_SLNO").value = NotnSlNo;
        //document.getElementById("txtCTH_Qty").value = after2;
    }
    else {

        document.getElementById("txtCTH_SL_No").value = "";
        document.getElementById("txtCTH_Supplier_SL").value = "";
        document.getElementById("hdn_ADD_SLNO").value = "";
        //document.getElementById("txtCTH_Qty").value = "";
    }
}

//---------------------RSP MASTER----------------------//
function CallServerside_RSPDetails(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    PageMethods.Get_RSPDetails(ctrl.value ,CallSuccess_RSP, CallFailed, dest);

}
// set the destination textbox value with the ContactName
function CallSuccess_RSP(res, destCtrl) {
    
    var data = res;
    if (data != -1) {


        document.getElementById("hdn_RSP_ABT_RATE").value = data;
        $('#txtMRP_ABT_RATE').val(data);

    }
    else {

        document.getElementById("hdn_RSP_ABT_RATE").value = "";
        $('#txtMRP_ABT_RATE').val(data);

    }
}

//--------------------
function Edu_Cess_NOTN() {

    var Edu_Cess_NOTN = document.getElementById("txtEdu_Cess_NOTN");

    var Edu_Cess_NOTN_SL = document.getElementById("txtEdu_Cess_NOTN_SL").value;
    var Edu_Cess_Rate = document.getElementById("txtEdu_Cess_Rate").value;

    var Sec_Edu_Cess_NOTN = document.getElementById("txtSec_Edu_Cess_NOTN");
    var Sec_Edu_Cess_Rate = document.getElementById("txtSec_Edu_Cess_Rate");

    if (Edu_Cess_NOTN.value == "069/2004") {

        Sec_Edu_Cess_NOTN.value = "028/2007";
        //        Sec_Edu_Cess_Rate.value = "0.00";
        if (Edu_Cess_NOTN_SL != '') {
            document.getElementById("txtSec_Edu_Cess_NOTN_SL").value = Edu_Cess_NOTN_SL;
        }
        if (Edu_Cess_Rate != '') {
            document.getElementById("txtSec_Edu_Cess_Rate").value = Edu_Cess_Rate
        }
    }
    else if (Edu_Cess_NOTN.value == "054/2017") {

        Sec_Edu_Cess_NOTN.value = "055/2017";
        
        if (Edu_Cess_NOTN_SL != '') {
            document.getElementById("txtSec_Edu_Cess_NOTN_SL").value = Edu_Cess_NOTN_SL;
        }
        if (Edu_Cess_Rate != '') {
            document.getElementById("txtSec_Edu_Cess_Rate").value = Edu_Cess_Rate
        }
    }
    else {
        Sec_Edu_Cess_NOTN.value = "";
        Sec_Edu_Cess_Rate.value = "";
    }
}



$(function () {
    $("#txt_CVD_Education_CESS_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_CVD_Education_CESS_Rate").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_CVD_Education_CESS_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Edu_Cess_NOTN_SL', 'error', 'topRight', true);

                            //jAlert('Edu_Cess_NOTN_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txtCETH_Sec_Edu_Cess_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_CVD_Sec_Edu_CESS_Rate").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtCETH_Sec_Edu_Cess_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Sec_Edu_Cess_NOTN_SL', 'error', 'topRight', true);

                            //jAlert('Edu_Cess_NOTN_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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

//ram
function CallServerside_CETH_Edu_Cess_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_CETH_Edu_Cess_Cth, CallFailed, dest);

}
//ram
function CallSuccess_CETH_Edu_Cess_Cth(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;

    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        //document.getElementById("txtEdu_Cess_NOTN").value = before;
        //document.getElementById("txtEdu_Cess_NOTN_SL").value = after1;
        document.getElementById("txtCVD_Edu_Cess_Rate").value = after2;
    }
    else {
        //document.getElementById("txtEdu_Cess_NOTN").value = '';
        //document.getElementById("txtEdu_Cess_NOTN_SL").value = '';
        document.getElementById("txtCVD_Edu_Cess_Rate").value = '';
    }
}

//---------------------//

$(function () {
    $("#txtCustomsHouse,#txtCustomsHouse_2").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        //jQuery('#txtCustomsHouse').validationEngine('showPrompt', 'Incorrect Customs House', 'error', 'topRight', true);
                        if (field == 'txtCustomsHouse') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Customs House', 'error', 'topRight', true);
                        }
                        if (field == 'txtCustomsHouse_2') {
                                jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Customs House', 'error', 'topRight', true);
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



//----------------------//

//ram----------------S
function CallServerside_CETH_Sec_Higher_Edu_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_CETH_Sec_Higher_Edu_Cth, CallFailed, dest);
}
//ram---------------E


//Ram------S

function CallSuccess_CETH_Sec_Higher_Edu_Cth(res, destCtrl) {

    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;

    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        //document.getElementById("txtSec_Edu_Cess_NOTN").value = before;
        //document.getElementById("txtSec_Edu_Cess_NOTN_SL").value = after1;
        document.getElementById("txtCETH_Sec_Edu_Cess_Rate").value = after2;
    }
    else {
        //document.getElementById("txtSec_Edu_Cess_NOTN").value = '';
        //document.getElementById("txtSec_Edu_Cess_NOTN_SL").value = '';
        document.getElementById("txtCETH_Sec_Edu_Cess_Rate").value = '';

    }

}

//Ram------E

function Call_Rsp_Rate_New(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    //alert('l");
    if (ctrl.length = 8) {
        PageMethods.Get_RSP_Rate(ctrl.value, CallSuccessNew_RSP, CallFailed, dest);
    }
}
// set the destination textbox value with the ContactName
function CallSuccessNew_RSP(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //    var dest1 = document.getElementById("txtMRP_ABT_RATE");

    var BEType = document.getElementById("hdn_Exbond_Val").value;
   
    if (res != '') {
        if (BE_Type == 'Ex-Bond') {
            $('#lbl_MRP_Rate').html('MRP Applicable ' + res + '%');
        }
        else {
            $('#lbl_MRP_Rate').html('');
        }
    }
    else {
        $('#lbl_MRP_Rate').html('');
    }

    dest.value = res;
    dest1.value = res;
    //    $('#lblCTH_Rate').html(res);
}

function Call_SW_Agency_CTH_CODE(src) {
    var ctrl = document.getElementById(src);
    if (ctrl.length = 8) {
        PageMethods.Get_SW_CTH_CODE_MASTER(ctrl.value, CallSuccessNew_SW_CTH_CODE, CallFailed);
    }
}
// set the destination textbox value with the ContactName
function CallSuccessNew_SW_CTH_CODE(res) {
    if (res != '') {
        $('#lbl_RITC_SW_Code').html(res);
//        $('#txtCTH_No').focus();
    }
    else {
        $('#lbl_RITC_SW_Code').html('');
    }
}

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
            ddlLoadingOn.val('');

            txtSVB_RefNo.attr('disabled', false);
            txtSVBDate.attr('disabled', false);
            ddlLoadingOn.attr('disabled', false);
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

function OpenPopupCustom_House() {
    
    if (document.getElementById('hdfTransport_mode').value != '') {
        
       NewWindow1('../ListPopup/Customs_House_ListPopup.aspx?Trans_Port=' + s + '', 'List', '810', '470', 'yes');
        return false
    }
    else {
        var N = 'Item_SVB';
        //NewWindow1('../ListPopup/Customs_House_ListPopup.aspx', 'List', '810', '470', 'yes');
        NewWindow1('../ListPopup/Customs_House_ListPopup.aspx?Trans_Port=' + N + '', 'List', '810', '470', 'yes');
        return false
    }
}

//$(function () {
//    $('#txt_Accessory_status').keyup(function () {
//        var val = $('#txt_Accessory_status').val();
//        if (val == '0' || val == '1' || val == '2') {
//            
//        }
//        else {
//            alert('Accessory Status - Allow Only 0 / 1 / 2');
//        }
//    });
//});


function Call_AIDC_NotnSlNo(src, dest) {
    var ctrl = document.getElementById(src);

    var CTH_No = document.getElementById("txtCTH_No").value;
    var AIDC_Notn = document.getElementById("txt_AIDC_NOTN").value;
    var AIDC_Notn_Slno = document.getElementById("txt_AIDC_NOTN_SLNO").value;

    if (CTH_No.length == 8) {
        PageMethods.Get_AIDC_Master(AIDC_Notn_Slno, CTH_No, AIDC_Notn, CallSuccess_AIDC_Notn_Rate, CallFailed, dest);
    }
    else {
        document.getElementById("txt_AIDC_RATE").value = '';
    }
}

function Call_AIDC_Notnno(src, dest) {
    var ctrl = document.getElementById(src);

    var CTH_No = document.getElementById("txtCTH_No").value;
    var AIDC_Notn = document.getElementById("txt_AIDC_NOTN").value;
    var AIDC_Notn_Slno = document.getElementById("txt_AIDC_NOTN_SLNO").value;

    if (CTH_No.length == 8) {
        if (document.getElementById("txt_AIDC_NOTN").value == '') {
            document.getElementById("txt_AIDC_NOTN").value = '';
            document.getElementById("txt_AIDC_NOTN_SLNO").value = '';
            document.getElementById("txt_AIDC_RATE").value = '';
        }
    }
    else {
        document.getElementById("txt_AIDC_NOTN").value = '';
        document.getElementById("txt_AIDC_NOTN_SLNO").value = '';
        document.getElementById("txt_AIDC_RATE").value = '';
    }
}


function CallSuccess_AIDC_Notn_Rate(res, destCtrl) {
    var data = res;
    document.getElementById("txt_AIDC_RATE").value = res;
}

function Call_RSP_Abtt_Rate_NotnSlNo(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    var CETH_No = document.getElementById("txtCETH_No").value;
    var RSP_Notn = document.getElementById("txtRSP_Notn_No").value;
    var Notn_Slno = document.getElementById("txtRSP_Notn_Slno").value;

    if (CETH_No.length == 8) {
        PageMethods.Get_Abtt_Rate_from_RSP_MASTER(ctrl.value, CETH_No, RSP_Notn, CallSuccess_Invoice_Cur, CallFailed, dest);
    }
}

function CallSuccess_Invoice_Cur(res, destCtrl) {
    //    alert(res);
    var data = res;
    document.getElementById("txtMRP_ABT_RATE").value = res;
}



$(function () {
    $("#txt_Manufacturer_Country,#txt_Manu_Source_Country,#txt_manu_Transit_Country").autocomplete({
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
                        if (field == 'txt_Manufacturer_Country') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect  Country Name', 'error', 'topRight', true);

                            //jAlert('Supplier Country Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Manu_Source_Country') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect  Country Name', 'error', 'topRight', true);

                            //jAlert('Seller Country Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_manu_Transit_Country') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect  Country Name', 'error', 'topRight', true);

                            //jAlert('Broker Country Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                      
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);

                        var result = data.d;

                        var stringsearch = "-", str = result;

                        for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                        if (i == 1) {
                            if (field == 'txt_Manufacturer_Country') {
                                $('#txt_Manufacturer_Country').val(result);
                            }

                            if (field == 'txt_Manu_Source_Country') {
                                $('#txt_Manu_Source_Country').val(result);
                            }

                            if (field == 'txt_manu_Transit_Country') {
                                $('#txt_manu_Transit_Country').val(result);
                            }
                        }
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
    $('#txt_Manufacturer_Country').bind('keyup change focus focusout', function () {

        var data = $(this).val();
        country(data);
    });


    $('#txt_Manu_Source_Country').bind('keyup change focus focusout', function () {

        var data = $(this).val();
        country1(data);
    });


    $('#txt_manu_Transit_Country').bind('keyup change focus focusout', function () {

        var data = $(this).val();
        country2(data);
    });

});

function country(val) {

    var data = val;
    if (data.indexOf("-") != -1) {

        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txt_Manufacturer_Country').val(after);
    }
    else {
    }
}

function country1(val) {

    var data = val;
    if (data.indexOf("-") != -1) {

        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txt_Manu_Source_Country').val(after);
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
       
        $('#txt_manu_Transit_Country').val(after);
    }
    else {
    }
}

/***************************************/
$(function () {
    $("#txtTariff_NOTN").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notify_Cus_Tariff",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtTariff_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Tariff Notification', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

$(function () {
    $("#txtTariff_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notify_Cus_Tariff_Slno",
                data: "{ 'mail': '" + request.term + "' ,'Tariff_Slno':'" + document.getElementById('txtTariff_NOTN').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtTariff_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Tariff Notification Slno', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function Call_CTH_Tariff_NOTN(src, dest) {
    var txtTariff_NOTN = document.getElementById("txtTariff_NOTN").value;
    var txtTariff_SL = document.getElementById("txtTariff_SL").value;

    if (txtTariff_NOTN != '' || txtTariff_SL != '') {
        PageMethods.Get_CTH_Tariff_NOTN(txtTariff_NOTN, txtTariff_SL, CallSuccess_CTH_Tariff_NOTN, CallFailed, dest);
    }
    else if (txtTariff_NOTN == '' && txtTariff_SL == '') {
        document.getElementById("txtTariff_Amount").value = '';
        document.getElementById("txtTariff_Amount_unitCode").value = '';
    }
}
function CallSuccess_CTH_Tariff_NOTN(res, destCtrl) {
    var data = res;
    var data = res;
    if (data.indexOf("~~") != -1) {
        var s = data.split('~~');
        var before = s[0];
        var after1 = s[1];

        document.getElementById("txtTariff_Amount").value = before;
        document.getElementById("txtTariff_Amount_unitCode").value = after1;
    }
    else {
        document.getElementById("txtTariff_Amount").value = '';
        document.getElementById("txtTariff_Amount_unitCode").value = '';
    }

}

//-------------------------------------------


function Call_IGST_Levy_Notn_Type(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var IGST_LEVY = document.getElementById("txt_IGST_LEVY_EXCEPTION_NOTN").value;
    PageMethods.Get_IGST_NOTN_TYPE(ctrl.value, CallSuccess_IGST_Levy_Notn_Type, CallFailed, dest);
}

function CallSuccess_IGST_Levy_Notn_Type(res, destCtrl) {
    var data = res;
   
    if (res == 'G') {
        document.getElementById("ddl_LEVY_EXCEMPTION_NOTN_TYPE").value = 'G';
    }
    if (res == 'C') {
        document.getElementById("ddl_LEVY_EXCEMPTION_NOTN_TYPE").value = 'C';
    }
}

//-----------------------------------------------

//-------------------------------------------Added by pandiyan on 02/06/2025 --------------------


function Call_IGST_Levy_Ex_Cc_Notn_Type(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var IGST_LEVY = document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_NOTN").value;
    PageMethods.Get_IGST_LEVY_EXCEPTION_CC_TYPE(ctrl.value, CallSuccess_IGST_Levy_Ex_CC_Notn_Type, CallFailed, dest);
}

function CallSuccess_IGST_Levy_Ex_CC_Notn_Type(res, destCtrl) {
    var data = res;

    if (res == 'G') {
        document.getElementById("ddl_LEVY_EXCEPTION_CC_NOTN_TYPE").value = 'G';
    }
    if (res == 'C') {
        document.getElementById("ddl_LEVY_EXCEPTION_CC_NOTN_TYPE").value = 'C';
    }
}

//-----------------------------------------------End----------------



function Call_GST_CTH_CODE(src) {

    var ctrl = document.getElementById(src);
    var country = document.getElementById('txtCountryOrigin').value;
    if (ctrl.length = 8) {
        PageMethods.Get_GST_CTH_CODE(ctrl.value, country, CallSuccessGST_CTH_CODE, CallFailed);
    }
}
 
function CallSuccessGST_CTH_CODE(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;
   
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');
     
        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];
        var Aidc_result = s[8];
        var Levy1E_Notn = s[11];
        var Levy1E_Notn_Slno = s[12];
        var Levy1E_Rate = s[13];
        var CCR = s[14]; 
        var IGST_EXCMP = s[15];
        var Rest_CTH = s[16];

        document.getElementById("txt_IGST_LEVY_NOTN").value = before;
        document.getElementById("txt_IGST_LEVY_SLNO").value = after1;
        document.getElementById("txt_IGST_LEVY_RATE").value = after2;

        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_NOTN").value = after3;
        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SLNO").value = after4;
        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_RATE").value = after5;

        document.getElementById("txt_IGST_LEVY_EXCEPTION_NOTN").value = Levy1E_Notn;
        document.getElementById("txt_IGST_LEVY_EXCEPTION_SLNO").value = Levy1E_Notn_Slno;
        document.getElementById("txt_IGST_LEVY_EXCEPTION_RATE").value = Levy1E_Rate;
       
        
        if (Aidc_result != "") {
            document.getElementById("txt_AIDC_NOTN").value = s[8];
            document.getElementById("txt_AIDC_NOTN_SLNO").value = s[9];
            document.getElementById("txt_AIDC_RATE").value = s[10];
        }
        else {
            document.getElementById("txt_AIDC_NOTN").value = '';
            document.getElementById("txt_AIDC_NOTN_SLNO").value = '';
            document.getElementById("txt_AIDC_RATE").value = '';
        }

        document.getElementById("txt_CCR").value = CCR;
        document.getElementById("lbl_IGST_Default").innerHTML = IGST_EXCMP;
        document.getElementById("lbl_Restricted").innerHTML = Rest_CTH;

        //remove all Notn while change RITC..
        //--- CTH tab---
        document.getElementById("txtBasicNotn").value = '';
        document.getElementById("txtBasicSLNO").value = '';
        document.getElementById("txtBasicRate").value = '';
        document.getElementById("txtBasicSPL").value = '';
        document.getElementById("txtBasicUnit").value = '';

        document.getElementById("txt_Social_Welfare_NOTN").value = '';
        document.getElementById("txt_Social_Welfare_NOTN_SL").value = '';
        //document.getElementById("txt_Social_Welfare_Rate").value = '';

        document.getElementById("txtAggregate_NOTN").value = '';
        document.getElementById("txtAggregate_NOTN_SL").value = '';
        document.getElementById("txtAggregate_RATE").value = '';

        document.getElementById("txtSafeguard_NOTN").value = '';
        document.getElementById("txtSafeguard_SL").value = '';
        document.getElementById("txtSafeguard_RATE").value = '';
        document.getElementById("txtSafeguard_SPL").value = '';
        document.getElementById("txtSafeguard_UNIT").value = '';

        document.getElementById("txtSAPTA_NOTN").value = '';
        document.getElementById("txtSAPTA_NOTN_SL").value = '';
        document.getElementById("txtSAPTA_RATE").value = '';

        document.getElementById("txtTariff_NOTN").value = '';
        document.getElementById("txtTariff_SL").value = '';
        document.getElementById("txtTariff_Qty").value = '';
        document.getElementById("txtTariff_Amount").value = '';
        document.getElementById("txtTariff_Amount_unitCode").value = '';

        //--- CETH tab---

        document.getElementById("txt_CVD_NOTN").value = '';
        document.getElementById("txt_CVD_SLNO").value = '';
        document.getElementById("txt_CVD_RATE").value = '';
        document.getElementById("txt_CVD_SPL").value = '';
        document.getElementById("txt_CVD_UNIT").value = '';

        document.getElementById("txt_Addl_GSI_NOTN").value = '';
        document.getElementById("txt_Addl_GSI_RATE").value = '';
        document.getElementById("txt_Addl_GSI_SPL").value = '';
        document.getElementById("txt_Addl_GSI_UNIT").value = '';

        document.getElementById("txt_Addl_SHE11_NOTN").value = '';
        document.getElementById("txt_Addl_SHE11_RATE").value = '';
        document.getElementById("txt_Addl_SHE11_SPL").value = '';
        document.getElementById("txt_Addl_SHE11_UNIT").value = '';

        document.getElementById("txt_Addl_TTA_NOTN").value = '';
        document.getElementById("txt_Addl_TTA_RATE").value = '';
        document.getElementById("txt_Addl_TTA_SPL").value = '';
        document.getElementById("txt_Addl_TTA_UNIT").value = '';

        document.getElementById("txt_Addl_Health_CESS_NOTN").value = '';
        document.getElementById("txt_Addl_Health_CESS_SLNO").value = '';
        document.getElementById("txt_Addl_Health_CESS_RATE").value = '';
        document.getElementById("txt_Addl_Health_CESS_SPL").value = '';
        document.getElementById("txt_Addl_Health_CESS_UNIT").value = '';

        document.getElementById("txt_CESS_NOTN").value = '';
        document.getElementById("txt_CESS_SLNO").value = '';
        document.getElementById("txt_CESS_RATE").value = '';
        document.getElementById("txt_CESS_SPL").value = '';
        document.getElementById("txt_CESS_UNIT").value = '';

        document.getElementById("txtOther_Duty_Notn").value = '';
        document.getElementById("txtOther_Duty_SLNO").value = '';
        document.getElementById("txtOther_Duty_RATE").value = '';
        document.getElementById("txtOther_Duty_SPL").value = '';
        document.getElementById("txtOther_Duty_UNIT").value = '';

        document.getElementById("txtAddlDuty_NOTN").value = '';
        document.getElementById("txtAddlDuty_NOTN_SL").value = '';
        document.getElementById("txtAddlDuty_Rate").value = '';

        /* --08-05-2021
        document.getElementById("ddlAntiDumping_Notn").value = '';
        document.getElementById("ddlAntiDumping_Notn_SL").value = '';
        */

        document.getElementById("txt_AntiDumping_Notn").value = '';
        document.getElementById("txt_AntiDumping_Notn_SL").value = '';
        document.getElementById("txtCTH_SL_No").value = '';
        document.getElementById("txtCTH_Supplier_SL").value = '';

        //--- IGST tab---
        /* hide by Chithra on 24-09-2025 for IGST Implementation
        document.getElementById("txt_IGST_LEVY_EXCEPTION_NOTN").value = '';
        document.getElementById("txt_IGST_LEVY_EXCEPTION_SLNO").value = '';
        document.getElementById("txt_IGST_LEVY_EXCEPTION_RATE").value = '';
        */
        document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_NOTN").value = '';
        document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_SLNO").value = '';
        document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_RATE").value = '';
       
    }
    else {
       
        var s = data.split('~~');
        //alert(s[8]);
     
        var Levy1E_Notn = s[11];
        var Levy1E_Notn_Slno = s[12];
        var Levy1E_Rate = s[13];
        var CCR = s[14];
        var IGST_EXCMP = s[15];
        var Rest_CTH = s[16];
      
       
        document.getElementById("txt_IGST_LEVY_NOTN").value = '';
        document.getElementById("txt_IGST_LEVY_SLNO").value = '';
        document.getElementById("txt_IGST_LEVY_RATE").value = '';

        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_NOTN").value = '';
        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SLNO").value = '';
        document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_RATE").value = '';

        document.getElementById("txt_IGST_LEVY_EXCEPTION_NOTN").value = Levy1E_Notn;
        document.getElementById("txt_IGST_LEVY_EXCEPTION_SLNO").value = Levy1E_Notn_Slno;
        document.getElementById("txt_IGST_LEVY_EXCEPTION_RATE").value = Levy1E_Rate;

        document.getElementById("txt_CCR").value = CCR;
        document.getElementById("lbl_IGST_Default").innerHTML = IGST_EXCMP;
      
        if (s[8] != "") {
            document.getElementById("txt_AIDC_NOTN").value = s[8];
            document.getElementById("txt_AIDC_NOTN_SLNO").value = s[9];
            document.getElementById("txt_AIDC_RATE").value = s[10];
            document.getElementById("lbl_Restricted").innerHTML = Rest_CTH;
        }
        else {
            document.getElementById("txt_AIDC_NOTN").value = '';
            document.getElementById("txt_AIDC_NOTN_SLNO").value = '';
            document.getElementById("txt_AIDC_RATE").value = '';
            document.getElementById("lbl_Restricted").innerHTML = Rest_CTH;
        }
       

        //remove all Notn while change RITC..
        //--- CTH tab---
        document.getElementById("txtBasicNotn").value = '';
        document.getElementById("txtBasicSLNO").value = '';
        document.getElementById("txtBasicRate").value = '';
        document.getElementById("txtBasicSPL").value = '';
        document.getElementById("txtBasicUnit").value = '';

        document.getElementById("txt_Social_Welfare_NOTN").value = '';
        document.getElementById("txt_Social_Welfare_NOTN_SL").value = '';
        //document.getElementById("txt_Social_Welfare_Rate").value = '';

        document.getElementById("txtAggregate_NOTN").value = '';
        document.getElementById("txtAggregate_NOTN_SL").value = '';
        document.getElementById("txtAggregate_RATE").value = '';

        document.getElementById("txtSafeguard_NOTN").value = '';
        document.getElementById("txtSafeguard_SL").value = '';
        document.getElementById("txtSafeguard_RATE").value = '';
        document.getElementById("txtSafeguard_SPL").value = '';
        document.getElementById("txtSafeguard_UNIT").value = '';

        document.getElementById("txtSAPTA_NOTN").value = '';
        document.getElementById("txtSAPTA_NOTN_SL").value = '';
        document.getElementById("txtSAPTA_RATE").value = '';

        document.getElementById("txtTariff_NOTN").value = '';
        document.getElementById("txtTariff_SL").value = '';
        document.getElementById("txtTariff_Qty").value = '';
        document.getElementById("txtTariff_Amount").value = '';
        document.getElementById("txtTariff_Amount_unitCode").value = '';


        //--- CETH tab---

        document.getElementById("txt_CVD_NOTN").value = '';
        document.getElementById("txt_CVD_SLNO").value = '';
        document.getElementById("txt_CVD_RATE").value = '';
        document.getElementById("txt_CVD_SPL").value = '';
        document.getElementById("txt_CVD_UNIT").value = '';

        document.getElementById("txt_Addl_GSI_NOTN").value = '';
        document.getElementById("txt_Addl_GSI_RATE").value = '';
        document.getElementById("txt_Addl_GSI_SPL").value = '';
        document.getElementById("txt_Addl_GSI_UNIT").value = '';

        document.getElementById("txt_Addl_SHE11_NOTN").value = '';
        document.getElementById("txt_Addl_SHE11_RATE").value = '';
        document.getElementById("txt_Addl_SHE11_SPL").value = '';
        document.getElementById("txt_Addl_SHE11_UNIT").value = '';

        document.getElementById("txt_Addl_TTA_NOTN").value = '';
        document.getElementById("txt_Addl_TTA_RATE").value = '';
        document.getElementById("txt_Addl_TTA_SPL").value = '';
        document.getElementById("txt_Addl_TTA_UNIT").value = '';

        document.getElementById("txt_Addl_Health_CESS_NOTN").value = '';
        document.getElementById("txt_Addl_Health_CESS_SLNO").value = '';
        document.getElementById("txt_Addl_Health_CESS_RATE").value = '';
        document.getElementById("txt_Addl_Health_CESS_SPL").value = '';
        document.getElementById("txt_Addl_Health_CESS_UNIT").value = '';

        document.getElementById("txt_CESS_NOTN").value = '';
        document.getElementById("txt_CESS_SLNO").value = '';
        document.getElementById("txt_CESS_RATE").value = '';
        document.getElementById("txt_CESS_SPL").value = '';
        document.getElementById("txt_CESS_UNIT").value = '';

        document.getElementById("txtOther_Duty_Notn").value = '';
        document.getElementById("txtOther_Duty_SLNO").value = '';
        document.getElementById("txtOther_Duty_RATE").value = '';
        document.getElementById("txtOther_Duty_SPL").value = '';
        document.getElementById("txtOther_Duty_UNIT").value = '';

        document.getElementById("txtAddlDuty_NOTN").value = '';
        document.getElementById("txtAddlDuty_NOTN_SL").value = '';
        document.getElementById("txtAddlDuty_Rate").value = '';

        /*--08-05-2021
        document.getElementById("ddlAntiDumping_Notn").value = '';
        document.getElementById("ddlAntiDumping_Notn_SL").value = '';
        */

        document.getElementById("txt_AntiDumping_Notn").value = '';
        document.getElementById("txt_AntiDumping_Notn_SL").value = '';
        document.getElementById("txtCTH_SL_No").value = '';
        document.getElementById("txtCTH_Supplier_SL").value = '';

        //--- IGST tab---
          /* hide by Chithra on 24-09-2025 for IGST Implementation
        document.getElementById("txt_IGST_LEVY_EXCEPTION_NOTN").value = '';
        document.getElementById("txt_IGST_LEVY_EXCEPTION_SLNO").value = '';
        document.getElementById("txt_IGST_LEVY_EXCEPTION_RATE").value = '';
        */

        document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_NOTN").value = '';
        document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_SLNO").value = '';
        document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_RATE").value = '';

       
    }
}

//-------------------------------------------

function Call_CountryOrigin(src) {
    var ctrl = document.getElementById(src);
    PageMethods.Check_CountryName(ctrl.value, 'COUNTRY_OF_ORIGIN', CallSuccess_CountryOrigin, CallFailed);
}

function CallSuccess_CountryOrigin(res) {
    var data = res;
    $('#hdn_chk_country').val(data);
}

//-------------------------------------------

function Call_Transit_CountryCode(src) {
    var ctrl = document.getElementById(src);
    PageMethods.Check_CountryName(ctrl.value, 'TRANSIT_COUNTRY', CallSuccess_Transit_Country, CallFailed);
}

function CallSuccess_Transit_Country(res) {
    var data = res;
    $('#hdn_chk_Transit_country').val(data);
}

//-------------------------------------------

function Call_Source_CountryCode(src) {
    var ctrl = document.getElementById(src);
    PageMethods.Check_CountryName(ctrl.value, 'SOURCE_COUNTRY', CallSuccess_Source_Country, CallFailed);
}

function CallSuccess_Source_Country(res) {
    var data = res;
    $('#hdn_chk_Source_country').val(data);
}

//-------------------------------------------

function Call_Manu_CountryCode(src) {
    var ctrl = document.getElementById(src);
    PageMethods.Check_CountryName(ctrl.value, 'MANU_COUNTRY', CallSuccess_Manu_Country, CallFailed);
}

function CallSuccess_Manu_Country(res) {
    var data = res;
    $('#hdn_chk_Manu_country').val(data);
}

//-----------------------------------------------

$(document).ready(function () {

    $('#btnUpdate,#btnSave,#btn_save_new').click(function () {


        //--------------------------------------GENERAL Mandatory Conditions... ---START-----------------------------------------------

        var chk_country = document.getElementById("hdn_chk_country").value;
        if (chk_country == 'No') {
            jAlert('Invalid - Country of Origin ', 'ITEM', function (r) { document.getElementById("General").click(); document.getElementById("txtCountryOrigin").focus(); });
            return false;
        }


        var chk_Transitcountry = document.getElementById("hdn_chk_Transit_country").value;
        if (chk_Transitcountry == 'No') {
            jAlert('Invalid - Transit Country ', 'ITEM', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_manu_Transit_Country").focus(); });
            return false;
        }


        var chk_Sourcecountry = document.getElementById("hdn_chk_Source_country").value;
        if (chk_Sourcecountry == 'No') {
            jAlert('Invalid - Source Country ', 'ITEM', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Manu_Source_Country").focus(); });
            return false;
        }


        var chk_Manufcountry = document.getElementById("hdn_chk_Manu_country").value;
        if (chk_Manufcountry == 'No') {
            jAlert('Invalid - Manufacturer Country ', 'ITEM', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Manufacturer_Country").focus(); });
            return false;
        }

        var chk_Enduse = document.getElementById("hdn_txtEndUse").value;
        if (chk_Enduse == 'No') {
            jAlert('Invalid - EndUse Code ', 'ITEM', function (r) { document.getElementById("General").click(); document.getElementById("txtEndUse").focus(); });
            return false;
        }

        //--------------------------------------GENERAL Mandatory Conditions... ---START-----------------------------------------------



        //--------------------------------------ANTI DUMPING NOTN Details Mandatory Conditions... ---START-----------------------------------------------
        //var Anti_dump = document.getElementById("ddlAntiDumping_Notn").value;--08-05-2021

        var Anti_dump = document.getElementById("txt_AntiDumping_Notn").value;
        if (Anti_dump.length > 0) {


            //            var Anti_Notn_SL = document.getElementById("ddlAntiDumping_Notn_SL").value;
            var Anti_Notn_SL = document.getElementById("txt_AntiDumping_Notn_SL").value;
            var Anti_CTH_SL = document.getElementById("txtCTH_SL_No").value;
            var Anti_Supplier_SL = document.getElementById("txtCTH_Supplier_SL").value;


            if (Anti_Notn_SL.length <= 0) {
                jAlert('AntiDumping Notn SlNo cannot be blank', 'ANTI-DUMPING', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_AntiDumping_Notn_SL").focus(); });
                return false;
            }
            if (Anti_CTH_SL.length <= 0) {
                jAlert('AntiDumping CTH SlNo cannot be blank', 'ANTI-DUMPING', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txtCTH_SL_No").focus(); });
                return false;
            }
            if (Anti_Supplier_SL.length <= 0) {
                jAlert('AntiDumping Supplier SlNo cannot be blank', 'ANTI-DUMPING', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txtCTH_Supplier_SL").focus(); });
                return false;
            }

        }
        //--------------------------------------ANTI DUMPING NOTN Details Mandatory Conditions... ---START-----------------------------------------------

        //-------------------------------------- CHECK RITC Conditions... ---START-----------------------------------------------

        var RITCNO = document.getElementById("txtCTH_No").value;
        var CTHNO = document.getElementById("txtCTHNO").value;

        if (RITCNO != CTHNO) {
            jAlert('RITC Mismatch with CTH No', 'ITEM', function (r) { document.getElementById("CTH").click(); document.getElementById("txtCTHNO").focus(); });
            return false;
        }

        //-------------------------------------- CHECK RITC  Conditions... ---END-----------------------------------------------


        //-------------------------------------- NOTN Details Mandatory Conditions... ---START-----------------------------------------------

        var BasicNotn = document.getElementById("txtBasicNotn").value;
        var BasicSLNO = document.getElementById("txtBasicSLNO").value;

        var Social_Welfare_NOTN = document.getElementById("txt_Social_Welfare_NOTN").value;
        var Social_Welfare_NOTN_SL = document.getElementById("txt_Social_Welfare_NOTN_SL").value;

        var Aggregate_NOTN = document.getElementById("txtAggregate_NOTN").value;
        var Aggregate_NOTN_SL = document.getElementById("txtAggregate_NOTN_SL").value;

        var Safeguard_NOTN = document.getElementById("txtSafeguard_NOTN").value;
        var Safeguard_SL = document.getElementById("txtSafeguard_SL").value;

        var SAPTA_NOTN = document.getElementById("txtSAPTA_NOTN").value;
        var SAPTA_NOTN_SL = document.getElementById("txtSAPTA_NOTN_SL").value;

        var IGST_LEVY_COMPENSATION_CESS_NOTN = document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_NOTN").value;
        var IGST_LEVY_COMPENSATION_CESS_SLNO = document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SLNO").value;

        var IGST_LEVY_NOTN = document.getElementById("txt_IGST_LEVY_NOTN").value;
        var IGST_LEVY_SLNO = document.getElementById("txt_IGST_LEVY_SLNO").value;

        var IGST_LEVY_EXCEPTION_NOTN = document.getElementById("txt_IGST_LEVY_EXCEPTION_NOTN").value;
        var IGST_LEVY_EXCEPTION_SLNO = document.getElementById("txt_IGST_LEVY_EXCEPTION_SLNO").value;


        if (BasicNotn.length == 0 && BasicSLNO.length > 0) {
            jAlert('Invalid - BasicNotn Slno', 'ITEM', function (r) { document.getElementById("CTH").click(); document.getElementById("txtBasicSLNO").focus(); });
            return false;
        }

        if (Social_Welfare_NOTN.length == 0 && Social_Welfare_NOTN_SL.length > 0) {
            jAlert('Invalid - Social_Welfare Notn Slno', 'ITEM', function (r) { document.getElementById("CTH").click(); document.getElementById("txt_Social_Welfare_NOTN_SL").focus(); });
            return false;
        }

        if (Aggregate_NOTN.length == 0 && Aggregate_NOTN_SL.length > 0) {
            jAlert('Invalid - Aggregate NOTN Slno', 'ITEM', function (r) { document.getElementById("CTH").click(); document.getElementById("txtAggregate_NOTN_SL").focus(); });
            return false;
        }

        if (Safeguard_NOTN.length == 0 && Safeguard_SL.length > 0) {
            jAlert('Invalid - Safeguard NOTN Slno', 'ITEM', function (r) { document.getElementById("CTH").click(); document.getElementById("txtSafeguard_SL").focus(); });
            return false;
        }

        if (SAPTA_NOTN.length == 0 && SAPTA_NOTN_SL.length > 0) {
            jAlert('Invalid - SAPTA NOTN Slno', 'ITEM', function (r) { document.getElementById("CTH").click(); document.getElementById("txtSAPTA_NOTN_SL").focus(); });
            return false;
        }

        if (IGST_LEVY_NOTN.length == 0 && IGST_LEVY_SLNO.length > 0) {
            jAlert('Invalid - IGST Notn Slno', 'ITEM', function (r) { document.getElementById("IGST").click(); document.getElementById("txt_IGST_LEVY_SLNO").focus(); });
            return false;
        }

        if (IGST_LEVY_EXCEPTION_NOTN.length == 0 && IGST_LEVY_EXCEPTION_SLNO.length > 0) {
            jAlert('Invalid - IGST Notn Slno', 'ITEM', function (r) { document.getElementById("IGST").click(); document.getElementById("txt_IGST_LEVY_EXCEPTION_SLNO").focus(); });
            return false;
        }

        if (IGST_LEVY_COMPENSATION_CESS_NOTN.length == 0 && IGST_LEVY_COMPENSATION_CESS_SLNO.length > 0) {
            jAlert('Invalid - IGST Notn Slno', 'ITEM', function (r) { document.getElementById("IGST").click(); document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SLNO").focus(); });
            return false;
        }

        if (IGST_LEVY_COMPENSATION_CESS_NOTN.length > 0 && IGST_LEVY_COMPENSATION_CESS_SLNO.length == 0) {
            jAlert('IGST Levy Notn SlNo cannot be blank ', 'ITEM', function (r) { document.getElementById("IGST").click(); document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SLNO").focus(); });
            return false;
        }


        //-------------------------------------- NOTN Details Mandatory Conditions... ---END-----------------------------------------------


        //----------------- Accessory_status Validation for Common sugg.by Mohmed on 28-08-2023 by Chithra
        var Accessory_status = document.getElementById("txt_Accessory_status").value;
        if (Accessory_status.length > 0) {
            if (Accessory_status != '0' && Accessory_status != '1' && Accessory_status != '2') {
                jAlert('Invalid - Accessory Status', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Accessory_status").focus(); });
                return false;
            }
        }

        //-------------------------------------- Manufacturer Details Mandatory Conditions... ---START-----------------------------------------------

        if (document.getElementById("hdn_SW_codes").value.includes("FSSAI")) {

            var excise_flag = document.getElementById("txt_Cus_not_exe_Cen_flag").value;
            var Address1 = document.getElementById("txt_Manufacturer_Add1").value;
            var Address2 = document.getElementById("txt_Manufacturer_Add2").value;
            var City = document.getElementById("txt_Manufacturer_City").value;
            var Subdiv = document.getElementById("txt_Manu_Country_Subdiv").value;
            var Manufacturer_Country = document.getElementById("txt_Manufacturer_Country").value;
            var Source_Country = document.getElementById("txt_Manu_Source_Country").value;
            var Transit_Country = document.getElementById("txt_manu_Transit_Country").value;
            


            //            if (excise_flag.length > 0 || Manufacturer_Country.length > 0 || Source_Country.length > 0 || Transit_Country.length > 0 || Address1.length > 0 || Address2.length > 0 || City.length > 0 || Subdiv.length > 0) {

            //            if (excise_flag.length == 0) {
            //                jAlert('Excise Flag cannot be blank ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Cus_not_exe_Cen_flag").focus(); });
            //                return false;
            //            }

            if (Address1.length == 0) {
                document.getElementById("txt_Manufacturer_Add1").style.borderColor = "red";
            }
            if (Address2.length == 0) {
                document.getElementById("txt_Manufacturer_Add2").style.borderColor = "red";
            }
            if (City.length == 0) {
                document.getElementById("txt_Manufacturer_City").style.borderColor = "red";
            }
            if (Subdiv.length == 0) {
                document.getElementById("txt_Manu_Country_Subdiv").style.borderColor = "red";
            }
            if (Manufacturer_Country.length == 0) {
                document.getElementById("txt_Manufacturer_Country").style.borderColor = "red";
            }
            if (Source_Country.length == 0) {
                document.getElementById("txt_Manu_Source_Country").style.borderColor = "red";
            }
            if (Transit_Country.length == 0) {
                document.getElementById("txt_manu_Transit_Country").style.borderColor = "red";
            }
            if (Accessory_status.length == 0) {
                document.getElementById("txt_Accessory_status").style.borderColor = "red";
            }



            if (excise_flag.length > 0) {
                if (excise_flag != 'C') {
                    jAlert('Invalid - Excise Flag', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Cus_not_exe_Cen_flag").focus(); });
                    return false;
                }
            }

            if (Address1.length == 0) {
                //                document.getElementById("txt_Manufacturer_Add1").style.borderColor = "red";
                jAlert('Address1 cannot be blank ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Manufacturer_Add1").focus(); });
                return false;
            }
            else {
                document.getElementById("txt_Manufacturer_Add1").style.borderColor = "";
            }

            if (Address2.length == 0) {
                //                document.getElementById("txt_Manufacturer_Add2").style.borderColor = "red";
                jAlert('Address2 cannot be blank ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Manufacturer_Add2").focus(); });
                return false;

            }
            else {
                document.getElementById("txt_Manufacturer_Add2").style.borderColor = "";
            }

            if (City.length == 0) {
                jAlert('City cannot be blank ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Manufacturer_City").focus(); });
                return false;
            }
            else {
                document.getElementById("txt_Manufacturer_City").style.borderColor = "";
            }

            if (Subdiv.length == 0) {
                jAlert('Subdivision cannot be blank ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Manu_Country_Subdiv").focus(); });
                return false;
            }
            else {
                document.getElementById("txt_Manu_Country_Subdiv").style.borderColor = "";
            }

            if (Manufacturer_Country.length == 0) {
                jAlert('Manufacturer Country cannot be blank ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Manufacturer_Country").focus(); });
                return false;
            }
            else {
                document.getElementById("txt_Manufacturer_Country").style.borderColor = "";
            }

            if (Manufacturer_Country.length > 0) {
                if (Manufacturer_Country.length != 2) {
                    jAlert('Invalid Country Code ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Manufacturer_Country").focus(); });
                    return false;
                }
            }

            if (Source_Country.length == 0) {
                jAlert('Source Country cannot be blank ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Manu_Source_Country").focus(); });
                return false;
            }
            else {
                document.getElementById("txt_Manu_Source_Country").style.borderColor = "";
            }

            if (Source_Country.length > 0) {
                if (Source_Country.length != 2) {
                    jAlert('Invalid Country Code ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Manu_Source_Country").focus(); });
                    return false;
                }
            }

            if (Transit_Country.length == 0) {
                jAlert('Transit Country cannot be blank ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_manu_Transit_Country").focus(); });
                return false;
            }
            else {
                document.getElementById("txt_manu_Transit_Country").style.borderColor = "";
            }

            if (Transit_Country.length > 0) {
                if (Transit_Country.length != 2) {
                    jAlert('Invalid Country Code ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_manu_Transit_Country").focus(); });
                    return false;
                }
            }

            if (Accessory_status.length <= 0) {
                jAlert('Accessory Status cannot be blank ', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Accessory_status").focus(); });
                return false;
            }
            else {
                document.getElementById("txt_Accessory_status").style.borderColor = "";
            }

            if (excise_flag.length == 0) {
                document.getElementById("txt_Cus_not_exe_Cen_flag").value = 'C';
            }
            //            }--above if condition

            if (Accessory_status.length > 0) {
                if (Accessory_status != '0' && Accessory_status != '1' && Accessory_status != '2') {
                    jAlert('Invalid - Accessory Status', 'MANUFACTURER', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_Accessory_status").focus(); });
                    return false;
                }
            }
        }

        //-------------------------------------- Manufacturer Details Mandatory Conditions... ---END-----------------------------------------------
    });
});


function OtherDuty_tab_FTA() {

    jAlert('Transit Country cannot be blank ', 'ITEM - FTA', function (r) { document.getElementById("Other_Duty").click(); document.getElementById("txt_manu_Transit_Country").focus(); });
    return false;
}
//------------------------------------------------------------------
$(function () {
    $("#txt_AIDC_NOTN").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            var RITC = document.getElementById("txtCTH_No").value;
            var Flag = 'AIDC_NOTN_NO';
            var Row_N = 'AIDC_NOTN_NO';
            var val_A = '';
            var val_B = '';
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AIDC_Cess_Master",
                data: "{ 'mail': '" + request.term + "' ,'RITC':'" + RITC + "' ,'Flag':'" + Flag + "','Row_N':'" + Row_N + "','val_A':'" + val_A + "','val_B':'" + val_B + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_AIDC_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AIDC CessNotn', 'error', 'topRight', true);
                        }
                    }
                    else {

                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


$(function () {
    $("#txt_AIDC_NOTN_SLNO").autocomplete({ 
        source: function (request, response) {
            var field = $(this.element).attr('id');
            var RITC = document.getElementById("txtCTH_No").value;
            var Flag = 'AIDC_NOTN_SLNO';
            var Row_N = 'AIDC_NOTN_SLNO';
            var val_A = document.getElementById("txt_AIDC_NOTN").value;
            var val_B = ''; 
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AIDC_Cess_Master",
                data: "{ 'mail': '" + request.term + "' ,'RITC':'" + RITC + "' ,'Flag':'" + Flag + "','Row_N':'" + Row_N + "','val_A':'" + val_A + "','val_B':'" + val_B + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_AIDC_NOTN_SLNO') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AIDC CessNotn Slno', 'error', 'topRight', true);
                        }
                    }
                    else {

                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

$(function () {
    $("#txt_AIDC_RATE").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            var RITC = document.getElementById("txtCTH_No").value;
            var Flag = 'AIDC_NOTN_RATE';
            var Row_N = 'AIDC_NOTN_RATE';
            var val_A = document.getElementById("txt_AIDC_NOTN").value;
            var val_B = document.getElementById("txt_AIDC_NOTN_SLNO").value;
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AIDC_Cess_Master",
                data: "{ 'mail': '" + request.term + "' ,'RITC':'" + RITC + "' ,'Flag':'" + Flag + "','Row_N':'" + Row_N + "','val_A':'" + val_A + "','val_B':'" + val_B + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_AIDC_RATE') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AIDC CessNotn Slno', 'error', 'topRight', true);
                        }
                    }
                    else {

                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


function Call_AIDC_Master(src) {

    var ctrl = document.getElementById(src);
    if (ctrl.length = 8) {
        PageMethods.Get_AIDC_Notn(ctrl.value, CallSucces_AIDC, CallFailed);
    }
}
function CallSucces_AIDC(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;
    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

        var s = data.split('~~');
        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];

        document.getElementById("txt_AIDC_NOTN").value = before;
        document.getElementById("txt_AIDC_NOTN_SLNO").value = after1;
        document.getElementById("txt_AIDC_RATE").value = after2;
    }
    else {
        document.getElementById("txt_AIDC_NOTN").value = '';
        document.getElementById("txt_AIDC_NOTN_SLNO").value = '';
        document.getElementById("txt_AIDC_RATE").value = '';
    }
}


$(function () {
    $("#txtunitcode").autocomplete({
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

                        if (field == 'txtunitcode') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Miscellaneous Currency', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);

                        var result = data.d;

                        var stringsearch = "-", str = result;

                        for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                        if (i == 1) {

                            if (field == 'txtunitcode') {
                                $('#txtunitcode').val(result);
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

