function validate_Export_License() {


    var txtftrLICENSE_NO;
    txtftrLICENSE_NO = document.getElementById("txtLicenseNo").value;

    if (txtftrLICENSE_NO.length <= 0) {
        jAlert('LICENSE NO cannot be blank', 'LICENSE', function (r) { document.getElementById("txtLicenseNo").focus(); });

        return false;
    }

    var txtftrLicense_R_SlNo;
    txtftrLicense_R_SlNo = document.getElementById("txtRegn_Sl_No").value;

    if (txtftrLicense_R_SlNo.length <= 0) {
        jAlert('Regn_SlNo cannot be blank', 'LICENSE', function (r) { document.getElementById("txtRegn_Sl_No").focus(); });

        return false;
    }
    if (document.getElementById("txtDate").value <= 0) {
        jAlert('License Date cannot be blank', 'LICENSE', function (r) { document.getElementById("txtDate").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtDate").value)) {

    }
    else {
        jAlert('License Date is Invalid Date', 'LICENSE', function (r) { document.getElementById("txtDate").focus(); });

        return false;
    }
    jQuery('#form1').validationEngine('detach');
}
function validate_Export_License_Imp_Exp() {
    //if (Page_ClientValidate()) // this will trigger validator
    //{

    var txtExport_Item_SLNo;
    txtExport_Item_SLNo = document.getElementById("txtExport_Item_Sl_No").value;

    if (txtExport_Item_SLNo.length <= 0) {
        jAlert('Export_Item_SLNo cannot be blank', 'LICENSE', function (r) { document.getElementById("txtExport_Item_Sl_No").focus(); });

        return false;
    }


    var txtExport_Qty;
    txtExport_Qty = document.getElementById("txtExport_Qty").value;

    if (txtExport_Qty.length <= 0) {
        jAlert('Export_Qty cannot be blank', 'LICENSE', function (r) { document.getElementById("txtExport_Qty").focus(); });

        return false;
    }



    var txtftrLicense_Imp_Itemslno;
    txtftrLicense_Imp_Itemslno = document.getElementById("txtImport_Item_Sl_No").value;

    if (txtftrLicense_Imp_Itemslno.length <= 0) {
        jAlert('Import Itemslno cannot be blank', 'LICENSE', function (r) { document.getElementById("txtImport_Item_Sl_No").focus(); });

        return false;
    }
    var txtftrLicense_Imp_Qty;
    txtftrLicense_Imp_Qty = document.getElementById("txtImport_Qty").value;

    //if (txtftrLicense_Imp_Qty.length <= 0) {
     //   jAlert('Import_Qty cannot be blank', 'LICENSE', function (r) { document.getElementById("txtImport_Qty").focus(); });

      //  return false;
   // }
    var txtftrLicense_Imp_Unit;
    txtftrLicense_Imp_Unit = document.getElementById("txtImport_Unit").value;

   // if (txtftrLicense_Imp_Unit.length <= 0) {
     //   jAlert('Import_Unit cannot be blank', 'LICENSE', function (r) { document.getElementById("txtImport_Unit").focus(); });

     //   return false;
   // }
  //  if (txtftrLicense_Imp_Unit.length < 3) {
    //    jAlert('Import_Unit should be 3 characters', 'LICENSE', function (r) { document.getElementById("txtImport_Unit").focus(); });
      //  return false;
   // }
    var ddlftrLicense_Imp_Type;
    ddlftrLicense_Imp_Type = document.getElementById("ddlNM").value;

    if (ddlftrLicense_Imp_Type.length <= 0) {
        jAlert('Type cannot be blank', 'LICENSE', function (r) { document.getElementById("ddlNM").focus(); });

        return false;
    }


    //}

}
$(function () {
    $("#txtImport_Unit").autocomplete({
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
                        jQuery('#txtImport_Unit').validationEngine('showPrompt', 'Incorrect Import Unit Code', 'error', 'topRight', true);

                        //jAlert('Import Unit Code is Incorrect', 'LICENSE', function (r) { document.getElementById('txtImport_Unit').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtImport_Unit').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtLicenseNo").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/License_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'Type':'" + document.getElementById("hdn_License_Scheme").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtLicenseNo').validationEngine('showPrompt', 'Incorrect License No', 'error', 'topRight', true);

                      
                    }
                    else {
                        jQuery('#txtLicenseNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//---------------------IMPORTER----------------------//
function CallServerside_License(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method
    PageMethods.GetLicenseNo(ctrl.value, ctrl1.value, CallSuccess, CallFailed, dest);

}
// call server side method

// calling Importer

// set the destination textbox value with the ContactName
function CallSuccess(res, destCtrl) {
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

        //document.getElementById("txtLicenseNo").value = before;
        document.getElementById("txtDate").value = after1;
        document.getElementById("txtRegn_Sl_No").value = after2;
        document.getElementById("txtImport_Item_Sl_No").value = after3;
        document.getElementById("txtDescription").value = after4;
        document.getElementById("txtImport_Qty").value = after5;
        document.getElementById("txtImport_Unit").value = after6;
        document.getElementById("hdn_NM_type").value = after7;

        document.getElementById("hdn_Import_Slno").value = after3;
        document.getElementById("hdn_desc").value = after4;
        document.getElementById("hdn_Import_qty").value = after5;
        document.getElementById("hdn_Import_unit").value = after6;

        document.getElementById("hdn_license_istrue").value = "1";


    }
    else {
        //document.getElementById("txtLicenseNo").value = "";
        document.getElementById("txtDate").value = "";
        document.getElementById("txtRegn_Sl_No").value = "";
        document.getElementById("txtImport_Item_Sl_No").value = "";
        document.getElementById("txtDescription").value = "";
        document.getElementById("txtImport_Qty").value = "";
        document.getElementById("txtImport_Unit").value = "";
        document.getElementById("hdn_NM_type").value = "";

        document.getElementById("hdn_Import_Slno").value = "";
        document.getElementById("hdn_desc").value = "";
        document.getElementById("hdn_Import_qty").value = "";
        document.getElementById("hdn_Import_unit").value = "";

        document.getElementById("hdn_license_istrue").value = "";
    }

}
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}  