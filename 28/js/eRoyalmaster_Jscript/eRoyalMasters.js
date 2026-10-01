
//-----------------------------------------------Client Master--------------------------------------------------
$(function () {
    $("#txtimpexpname").autocomplete({ 

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Exp_Name",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtimpexpname').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtimpexpname').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//------------------------------------Consignee Master---------------------------
$(function () {
    $("#txtimpexpname_2").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/consignee_name",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtimpexpname_2').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtimpexpname_2').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//---------------------------------------------------------Supplier Master-------------------------------------
$(function () {
    $("#txtsup_name").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/SUP_NAME",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtsup_name').validationEngine('showPrompt', 'Invalid Supplier Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtsup_name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//---------------------------------------------------------Buyer Master-------------------------------------
$(function () {
    $("#txtby_name").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Buyer_name",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtby_name').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtby_name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//---------------------------------------------------------ADCode Master-------------------------------------
$(function () {
    $("#txtadCode_name").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/ADCODE_IEC_NAME",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtadCode_name').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtadCode_name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//---------------------------------------------------------License Master-------------------------------------
$(function () {
    $("#txtLicense_No").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/LICENSE_NO",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtLicense_No').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtLicense_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//-------------------------
$(function () {
    $("#txtLicense_desc").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/LICENSE_ITEM_DESCRIPTION",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtLicense_desc').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtLicense_desc').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//-------------------------------------product Master--------------------------------------

$(function () {
    $("#txtProduct").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/PRODUCT_DESCRIPTION",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtProduct').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtProduct').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//-------------------------

$(function () {
    $("#txtCTHNo").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/PRODUCT_CTH",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtCTHNo').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtCTHNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//-------------------------
$(function () {
    $("#txtCETHNo").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/PRODUCT_CETH",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtCETHNo').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtCETHNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//-------------------------
$(function () {
    $("#txtRITCNo").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/PRODUCT_RITC",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtRITCNo').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtRITCNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//-----------------------------------------------ROSL Master--------------------------------------------------
$(function () {
    $("#txtROSLNoSearch").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/ROSL_Sl_No",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtROSLNoSearch').validationEngine('showPrompt', 'Invalid ROSL No', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtROSLNoSearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//---------------------ROSL UNITCODE-------------------------------------------------------//////////

$(function () {
    $('#txtROSLUnit').autocomplete({
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
                        jQuery('#txtROSLUnit').validationEngine('showPrompt', 'Incorrect Qty Code', 'error', 'topRight', true);

                        //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtROSLUnit').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//---------------------------------------------------------IMPORT THIRD PARTY MASTER------------------------------------------
$(function () {
    $("#txt_Thirdparty_name").autocomplete({

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
                        jQuery('#txt_Thirdparty_name').validationEngine('showPrompt', 'Invalid ThirdParty Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txt_Thirdparty_name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//---------------------------------------------------------EXPORT THIRD PARTY MASTER-------------------------------------
$(function () {
    $("#txt_Exp_ThirdParty_name").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exp_ThirdParty_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_Exp_ThirdParty_name').validationEngine('showPrompt', 'Invalid ThirdParty Name', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txt_Exp_ThirdParty_name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//-----------------------------------------------RODTEP Master--------------------------------------------------
$(function () {
    $("#txtRODTEPTARSearch").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/RODTEP_TARIFF",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtRODTEPTARSearch').validationEngine('showPrompt', 'Invalid RODTEP TARIFF', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtRODTEPTARSearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//-----------------------------------------------------------------------------------------------
//-----------------------RODTEP MASTER DESCRIPTION--------------------///////
$(function () {
    $("#txtDesCSearch").autocomplete({

        source: function (request, response) {

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/RODTEP_DESC",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtDesCSearch').validationEngine('showPrompt', 'Invalid RODTEP DESCRIPTION', 'error', 'topRight', true);
                    }

                    else {
                        jQuery('#txtDesCSearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
