function validate_Export_AnnexureC1_Details() {
    //if (Page_ClientValidate()) // this will trigger validator
    //  {
    var txtExporterName;
    txtExporterName = document.getElementById("txtExporterName").value;

    if (txtExporterName.length <= 0) {
        jAlert('ExporterName  cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtExporterName").focus(); });

        return false;
    }
    var txtIECNo;
    txtIECNo = document.getElementById("txtIECNo").value;

    if (txtIECNo.length <= 0) {
        jAlert('IECNo cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtIECNo").focus(); });

        return false;
    }

    if (txtIECNo.length < 10) {
        jAlert('IECNo should be 10 digit', 'ANNEXUE_C1', function (r) { document.getElementById("txtIECNo").focus(); });

        return false;
    }
    var txtBranchSLNo;
    txtBranchSLNo = document.getElementById("txtBranchSLNo").value;

    if (txtBranchSLNo.length <= 0) {
        jAlert('Branch SLNo cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtBranchSLNo").focus(); });

        return false;
    }

    if (document.getElementById("txtExaminationDate").value <= 0) {
        jAlert('Examination Date cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtExaminationDate").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtExaminationDate").value)) {

    }
    else {
        jAlert('Examination Date is Invalid Date', 'ANNEXUE_C1', function (r) { document.getElementById("txtExaminationDate").focus(); });

        return false;
    }



    var txtExam_Officer;
    txtExam_Officer = document.getElementById("txtExam_Officer").value;

    if (txtExam_Officer.length <= 0) {
        jAlert('Exam Officer cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtExam_Officer").focus(); });

        return false;
    }

    var txtExam_Design;
    txtExam_Design = document.getElementById("txtExam_Design").value;

    if (txtExam_Design.length <= 0) {
        jAlert('Exam Designation cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtExam_Design").focus(); });

        return false;
    }

    var txtSuperv_Officer;
    txtSuperv_Officer = document.getElementById("txtSuperv_Officer").value;

    if (txtSuperv_Officer.length <= 0) {
        jAlert('Supervising Officer cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtSuperv_Officer").focus(); });

        return false;
    }
    var txtSuperv_Design;
    txtSuperv_Design = document.getElementById("txtSuperv_Design").value;

    if (txtSuperv_Design.length <= 0) {
        jAlert('Supervising Design cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtSuperv_Design").focus(); });

        return false;
    }
    var txtCommissionRate;
    txtCommissionRate = document.getElementById("txtCommissionRate").value;

    if (txtCommissionRate.length <= 0) {
        jAlert('Commission Rate cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtCommissionRate").focus(); });

        return false;
    }

    var txtDivision;
    txtDivision = document.getElementById("txtDivision").value;

    if (txtDivision.length <= 0) {
        jAlert('Division cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtDivision").focus(); });

        return false;
    }

    var txtRange;
    txtRange = document.getElementById("txtRange").value;

    if (txtRange.length <= 0) {
        jAlert('Range cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtRange").focus(); });

        return false;
    }
    //              if (document.getElementById("chkVerifiedOfficer').checked == false) {
    //                  jAlert('Select Verified Officer', 'ANNEXUE_C1', function (r) { document.getElementById("chkVerifiedOfficer").focus(); });


    //                  $('#form1').validationEngine('detach');
    //                  return false;
    //              }
    //              if (document.getElementById("chkSampleDrawn').checked == false) {
    //                  jAlert('Select Sample Drawn', 'ANNEXUE_C1', function (r) { document.getElementById("chkSampleDrawn").focus(); });


    //                  $('#form1').validationEngine('detach');
    //                  return false;
    //              }



    var txtSealNo;
    txtSealNo = document.getElementById("txtSealNo").value;

    if (txtSealNo.length <= 0) {
        jAlert('SealNo cannot be blank', 'ANNEXUE_C1', function (r) { document.getElementById("txtSealNo").focus(); });

        return false;
    }

}


$(function () {
    $("#txtExporterName").autocomplete({

        source: function (request, response) {
            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List",
                //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("txtIECNo").value + "'}",

                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('txtIECNo').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtExporterName').validationEngine('showPrompt', 'Incorrect ExporterName', 'error', 'topRight', true);

                        //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtExporterName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//$(function () {

//    $("#txtIECNo").autocomplete({

//        source: function (request, response) {
//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_IECCode_List",
//                data: "{ 'mail': '" + request.term + "' ,'IEC':''}",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {

//                    response(data.d);
//                    if (data.d == '') {
//                        jQuery('#txtIECNo').validationEngine('showPrompt', 'Incorrect IECNo', 'error', 'topRight', true);

//                        //jAlert('IECNo is Incorrect', 'ANNEXUE_C1', function (r) { document.getElementById("txtIECNo').focus(); });
//                        //return false;
//                    }
//                    else {
//                        jQuery('#txtIECNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
//                    }
//                },
//                error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    //alert(textStatus);
//                }
//            });
//        },
//        minLength: 1

//    });
//    return false;
//    scroll: true;

//});
$(function () {
    $("#txtBranchSLNo").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("txtIECNo").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtBranchSLNo').validationEngine('showPrompt', 'Incorrect Branch SLNo', 'error', 'topRight', true);

                        //jAlert('Branch SLNo is Incorrect', 'ANNEXUE_C1', function (r) { document.getElementById("txtBranchSLNo').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtBranchSLNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
// call server side method
//---------------------IMPORTER----------------------//
function CallServerside_Importer(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    PageMethods.GetImporter(ctrl.value, CallSuccess_Importer, CallFailed, dest);

}
// call server side method

// calling Importer

// set the destination textbox value with the ContactName
function CallSuccess_Importer(res, destCtrl) {
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

        document.getElementById("txtAddress1").value = before;
        document.getElementById("txtAddress2").value = after1;
        document.getElementById("txtAddress3").value = after2;
        if (after4 != '') {
            document.getElementById("txtAddress4").value = after3 + '--' + after4;
        }
        else {
            document.getElementById("txtAddress4").value = after3;
        }

        //document.getElementById("txtAddress5").value = after4;
      
        document.getElementById("txtIECNo").value = after5;
        document.getElementById("txtBranchSLNo").value = after6;



    }
    else {
        document.getElementById("txtAddress1").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
        //document.getElementById("txtAddress5").value = "";
        document.getElementById("txtIECNo").value = "";
        document.getElementById("txtBranchSLNo").value = "";
    }

}
// calling Importer
// alert message on some failure

function CallServerside_Importer_Branch(src, dest) {
    var ctrl = document.getElementById(src).value;
    var ctrl1 = document.getElementById(dest).value;
    // call server side method
    //alert('l');
    if (ctrl != '') {

        var ieccode;
        ieccode = document.getElementById("txtIECNo").value;


        if (ieccode.length < 10) {
            jQuery('#txtIECNo').validationEngine('showPrompt', 'IEC code  Should be 10 digit numbers', 'error', 'topRight', true);

            //jAlert('IEC code  Should be 10 digit numbers', 'ANNEXUE_C1', function (r) { document.getElementById("txtIECNo").focus(); });

            //return false;
        }

        else {
            jQuery('#txtIECNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);

            PageMethods.GetImporter_Branchwise(ctrl, ctrl1, CallSuccess_Importer_BranchWise, CallFailed, dest);

        }

    }
}
function CallSuccess_Importer_BranchWise(res, destCtrl) {
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

        document.getElementById("txtAddress1").value = before;
        document.getElementById("txtAddress2").value = after1;
        document.getElementById("txtAddress3").value = after2;
        if (after4 != '') {
            document.getElementById("txtAddress4").value = after3 + '--' + after4;
        }
        else {
            document.getElementById("txtAddress4").value = after3;
        }
    }
    else {

        document.getElementById("txtAddress").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
       

    }
}
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}

function OpenPopupExporter_Master(val) {

    if (val == 'Exporter') {

            OpenPopupImporterDetails(val);
            return false

        }

        else if (val == '') {
            OpenPopupImporterDetails(val);
            return false
        }

    }

    function OpenPopupExporter_Master_ANNEXURE_C1_NEW(val) {

        if (val == 'Exporter_AnnuxureC1_NEW') {

            OpenPopupImporterDetails(val);
            return false
        }

        else if (val == '') {
            OpenPopupImporterDetails(val);
            return false
        }
    }

    //---------------------IMPORTER----2---------------------//
    function CallServerside_Importer_2(src, dest) {
        var ctrl = document.getElementById(src);
        var ctrl_2 = document.getElementById(dest);
        // call server side method

        PageMethods.GetImporter_2(ctrl.value, ctrl_2.value, CallSuccess_Importer_2, CallFailed, dest);

    }
    function CallSuccess_Importer_2(res, destCtrl) {
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

           
            document.getElementById("txtAddress1").value = before;
            document.getElementById("txtAddress2").value = after1;
            document.getElementById("txtAddress3").value = after2;
            if (after4 != '') {
                document.getElementById("txtAddress4").value = after3 + '--' + after4;
            }
            else {
                document.getElementById("txtAddress4").value = after3;
            }
//            document.getElementById("txtAddress5").value = after4;
            document.getElementById("txtIECNo").value = after5;
            document.getElementById("txtBranchSLNo").value = after6;
//            document.getElementById("hdn_ImporterType").value = after7;



        }
        else {

            document.getElementById("txtAddress1").value = "";
            document.getElementById("txtAddress2").value = "";
            document.getElementById("txtAddress3").value = "";
            document.getElementById("txtAddress4").value = "";
//            document.getElementById("txtAddress5").value = "";
            document.getElementById("txtIECNo").value = "";
            document.getElementById("txtBranchNo").value = "";
//            document.getElementById("hdn_ImporterType").value = "";
        }
    }

    //======================IMPORTER----2--END===============================================