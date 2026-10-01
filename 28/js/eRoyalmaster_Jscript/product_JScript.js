
// textbox keyup,keyip,keypress
$(function () {

    $('#txtCTHNO').bind('change keyup keydown focus', function () {

        var f4 = $('#txtCTHNO').val();

        $('#txtRITCNO').val(f4);
        $('#txtCTHNO').val(f4);
        $('#txtCETH_No').val(f4);

    });


});

// textbox keyup,keyip,keypress


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

$(function () {

    $('#chkMRP_Duty').click(function (e) {



        var txtMRP_SL_NO = $('#txtMRP_SL_NO');
        var txtRSP_Abt_Rate = $('#hdn_RSP_ABT_RATE');
        var txtMRP_AMOUNT = $('#txtMRP_AMOUNT');
        var txtMRP_ABT_RATE = $('#txtMRP_ABT_RATE');
        var txtRSP_Notn_No = $('#txtRSP_Notn_No');
        var txtRSP_Notn_Slno = $('#txtRSP_Notn_Slno');

        if (this.checked) {
            txtMRP_SL_NO.attr('disabled', false);
            txtMRP_AMOUNT.attr('disabled', false);
            txtMRP_ABT_RATE.attr('disabled', false);
            txtRSP_Notn_No.attr('disabled', false);
            txtRSP_Notn_Slno.attr('disabled', false);

            txtMRP_SL_NO.val('1');
            CallServerside_RSPDetails('txtCTH_No', 'txtCTH_No');

        }
        else {

            txtMRP_SL_NO.attr('disabled', true);
            txtMRP_AMOUNT.attr('disabled', true);
            txtMRP_ABT_RATE.attr('disabled', true);
            txtRSP_Notn_No.attr('disabled', true);
            txtRSP_Notn_Slno.attr('disabled', true);
            txtMRP_SL_NO.val('');
            txtMRP_AMOUNT.val('');
            txtMRP_ABT_RATE.val('');
            txtRSP_Notn_No.val('');
            txtRSP_Notn_Slno.val('');
        }
    });
});



//click       



//autocomplete search and page method





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
    $("#txtQtyCode,#txtunitcode,#txtCTH_Qty1_Code,#txtCTH_Qty2_Code,#txtBasicUnit,#txtNCD_UNIT,#txtSafeguard_UNIT,#txt_CVD_UNIT,#txt_Addl_GSI_UNIT,#txt_Addl_SHE11_UNIT,#txt_Addl_TTA_UNIT,#txt_Addl_Health_CESS_UNIT,#txt_CESS_UNIT,#txtTariff_Amount_unitCode").autocomplete({
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
                        if (field == 'txtQtyCode') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Qty Code', 'error', 'topRight', true);

                            //jAlert('Qty Code is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtunitcode') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Unit code', 'error', 'topRight', true);

                            //jAlert('Unit code is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
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
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Tariff_Amount Unit Code', 'error', 'topRight', true);

                            //jAlert('Tariff Amount unit Code is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txtCountryName").autocomplete({
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


                        jQuery('#txtCountryName').validationEngine('showPrompt', 'Incorrect Country Origin', 'error', 'topRight', true);
                        //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById("txtStateName").focus(); });
                        // return false;
                    }
                    else {
                        jQuery('#txtCountryName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtBasicNotn,#txtAddlDuty_NOTN,#txtEdu_Cess_NOTN,#txtSec_Edu_Cess_NOTN,#txtNCD_NOTN,#txtAggregate_NOTN,#txtSafeguard_NOTN,#txtSAPTA_NOTN,#txt_CVD_Edu_Cess_NOTN,#txt_CVD_Sec_Edu_Cess_NOTN").autocomplete({
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
                        if (field == 'txtAggregate_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Aggregate_NOTN', 'error', 'topRight', true);

                            //jAlert('Aggregate_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtSafeguard_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Safeguard_NOTN', 'error', 'topRight', true);

                            //jAlert('Safeguard_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtSAPTA_NOTN') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect SAPTA_NOTN', 'error', 'topRight', true);

                            //jAlert('SAPTA_NOTN is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_CVD_Edu_Cess_NOTN') {
                          
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CVD_Edu_Cess_NOTN', 'error', 'topRight', true);
                        }
                        if (field == 'txt_CVD_Sec_Edu_Cess_NOTN') {

                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CVD_Sec_Edu_Cess_NOTN', 'error', 'topRight', true);
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

//--------------------------------------------------------------S

$(function () {
    $("#txt_CVD_Edu_Cess_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_CVD_Edu_Cess_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_CVD_Edu_Cess_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CVD_Edu_Cess_NOTN_SL', 'error', 'topRight', true);
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
    $("#txt_CVD_Sec_Edu_Cess_NOTN_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
                data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txt_CVD_Sec_Edu_Cess_NOTN").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_CVD_Sec_Edu_Cess_NOTN_SL') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect CVD_Sec_Edu_Cess_NOTN_SL', 'error', 'topRight', true);

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

//--------------------------------------------------------------E


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
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
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

                            //jAlert('Aggregate_NOTN_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txtSafeguard_SL").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Notification_Custom_Master_List",
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

                            //jAlert('Safeguard_SL is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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
    $("#txt_CVD_NOTN,#txt_Addl5_SIA_NOTN,#txt_Addl_GSI_NOTN,#txt_Addl_SHE11_NOTN,#txt_Addl_TTA_NOTN,#txt_Addl_Health_CESS_NOTN,#txt_CESS_NOTN,#txtinfra_cess_Notn").autocomplete({
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

                            //jAlert('CESS_SLNO is Incorrect', 'PRODUCT', function (r) { document.getElementById(field).focus(); });
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

//NOTIFICATION EXCISE MASTER

$(document).ready(function () {
    $('#txtCountryName').bind('change keyup keydown focus', function () {

        var data = $(this).val();
        country(data);

    });
   
});

function country(val, txt) {

    var data = val;

    if (data.indexOf("-") != -1) {


        var s = data.split('-');

        var before = s[0];
        var after = s[1];



        $('#txtCountryName').val(before);







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

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_Basic_Duty, CallFailed, dest);

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
    //alert('l");
    if (ctrl.length = 8) {
        PageMethods.Get_CTH_Rate(ctrl.value, CallSuccessCTHRate, CallFailed, dest);
    }
}
// set the destination textbox value with the ContactName
function CallSuccessCTHRate(res, destCtrl) {

    $('#lblCTH_Rate').html(res);

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

    $('#lblCETH_Rate').html(res);

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

//--------------------------New updation ---------july-2014--------------------S

function CallServerside_CVD_Edu_Cess_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_CVD_Edu_Cess_Cth, CallFailed, dest);
}

function CallServerside_CVD_Sec_Higher_Edu_Cth_Notn_Slno(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);

    PageMethods.Get_Notn_Custom_Master_CTH_NOTN_SLNO(ctrl.value, ctrl1.value, CallSuccess_CVD_Sec_Higher_Edu_Cth, CallFailed, dest);

}

function CallSuccess_CVD_Sec_Higher_Edu_Cth(res, destCtrl) {

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
        document.getElementById("txt_CETH_Sec_Edu_Cess_Rate").value = after2;


    }
    else {
        //document.getElementById("txtSec_Edu_Cess_NOTN").value = '';
        //document.getElementById("txtSec_Edu_Cess_NOTN_SL").value = '';
        document.getElementById("txt_CETH_Sec_Edu_Cess_Rate").value = '';

    }

}

//--------------------------New updation ---------july-2014----------------------E


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



function CallSuccess_CVD_Edu_Cess_Cth(res, destCtrl) {
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
        document.getElementById("txt_CETH_Edu_Cess_Rate").value = after2;


    }
    else {
        //document.getElementById("txtEdu_Cess_NOTN").value = '';
        //document.getElementById("txtEdu_Cess_NOTN_SL").value = '';
        document.getElementById("txt_CETH_Edu_Cess_Rate").value = '';

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


//---------------------RSP MASTER----------------------//
function CallServerside_RSPDetails(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    PageMethods.Get_RSPDetails(ctrl.value, CallSuccess_RSP, CallFailed, dest);

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

/**************************** EXPORT PRODUCT MASTER****************/

function CallServerside_PRODUCT_DESC(src, dest) {
    var ctrl = document.getElementById(src);
    alert('cc');
    PageMethods.Get_PRODUCT_DESCRIPTION(ctrl.value, CallSuccess_Product_RITC, CallFailed, dest);

}

function CallSuccess_Product_RITC(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    var data = res;

    document.getElementById("txtProduct").value = data;

}

/**************************** EXPORT PRODUCT MASTER END****************/


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


function updateTextbox() {
    var txt1 = document.getElementById("txtDescription");
    var txt2 = document.getElementById("txtGenericDesc");
    if (txt2.value.length <= 0) {
        txt2.value = txt1.value;
    }
}
