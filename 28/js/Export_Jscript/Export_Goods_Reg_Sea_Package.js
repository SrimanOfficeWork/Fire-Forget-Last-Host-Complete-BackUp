$(function () {
    $("#txtPackageType").autocomplete({
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
                        jQuery('#txtPackageType').validationEngine('showPrompt', 'Incorrect Package Type', 'error', 'topRight', true);

                        //jAlert('Package Type is Incorrect', 'ANNEXURE_C_PACKAGE', function (r) { document.getElementById('txtPackageType').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtPackageType').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
function validate_Export_AnnexureC1_Sea_Package() {
    var txtGroup = document.getElementById("txtGroup").value;
    if (txtGroup.length <= 0) {
        jAlert('Group cannot be blank', 'GOODS_REG_SEA_PACKAGE', function (r) { document.getElementById("txtGroup").focus(); });

        return false;
    }
    var txtFrom = document.getElementById("txtFrom").value;
    if (txtFrom.length <= 0) {
        jAlert('From value cannot be blank', 'GOODS_REG_SEA_PACKAGE', function (r) { document.getElementById("txtFrom").focus(); });

        return false;
    }
    var txtTo = document.getElementById("txtTo").value;
    if (txtTo.length <= 0) {
        jAlert('To value cannot be blank', 'GOODS_REG_SEA_PACKAGE', function (r) { document.getElementById("txtTo").focus(); });

        return false;
    }
    var l = txtFrom;
    var h = txtTo;
    
    if (l > h) {

        jAlert('To value should be greater than from value', 'GOODS_REG_SEA_PACKAGE', function (r) { document.getElementById("txtTo").focus(); });

        return false;
    }
    var txtPackageType;
    txtPackageType = document.getElementById("txtPackageType").value;

    if (txtPackageType.length <= 0) {

        jAlert('Package Type cannot be blank', 'GOODS_REG_SEA_PACKAGE', function (r) { document.getElementById("txtPackageType").focus(); });

        return false;
    }


    else if (txtPackageType.length < 3) {
        jAlert('Package Type should be 3 characters', 'GOODS_REG_SEA_PACKAGE', function (r) { document.getElementById("txtPackageType").focus(); });

        return false;
    }

}