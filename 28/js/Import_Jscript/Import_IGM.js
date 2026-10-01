function tab_page1(val) {

    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';

    document.getElementById("trans_IGM_details_Main_Cont_iframe").src = "../Transaction/IGM_Main.aspx";

}
function tab_page2(val) {

    document.getElementById('page-1').style.display = 'none';
    document.getElementById('page-2').style.display = 'Block';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';

    document.getElementById("trans_IGM_Container_Main_Cont_iframe").src = "../Transaction/Container_Details.aspx";

}
function tab_page3(val) {

    document.getElementById('page-1').style.display = 'none';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'Block';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById("trans_IGM_bond_Main_Cont_iframe").src = "../Transaction/Bond_Details.aspx";

}
function tab_page4(val) {

    document.getElementById('page-1').style.display = 'none';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'Block';
    document.getElementById("trans_IGM_certificate_Main_Cont_iframe").src = "../Transaction/Certificate_Details.aspx";

}
function OpenPopup_Airline_Details_new() {
    if (document.getElementById('hdn_Transport_Mode').value == 'Air') {
        OpenPopup_Airline_Details();
        return false;
    }
}

function Call_Client_Name(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    //alert('l');
    var ieccode = document.getElementById("txtIec_Code").value;
    if (ieccode.length == 10) {
        PageMethods.GetClient_Name(ctrl.value, CallSuccess, CallFailed, dest);
    }
}

// set the destination textbox value with the ContactName
function CallSuccess(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    dest.value = res;
}
// alert message on some failure
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}


//$(function () {
//    //            alert($('.txtMAWBMBLNo').val());
//    $('#txtMAWBMBLNo').keyup(function () {
//        $('#txtMarksNos').val($(this).val());
//    });
//    $('#txtMAWBMBLNo').blur(function () {
//        $('#txtMarksNos').val($(this).val());
//    });

//    $('#txtHAWBHBLNo').keyup(function () {
//        $('#txtMarksNos').val($(this).val());
//    });
//    $('#txtHAWBHBLNo').blur(function () {
//        $('#txtMarksNos').val($(this).val());
//    });


//});


    $(function () {
        $('#txtMAWBMBLNo').keyup(function (e) {
            if ($('#hdn_Transport_Mode').val() == "Air") {
            var txtVal = $(this).val();

            //$('#txtSecond').val(txtVal);
            $('#txtMarksNos').val($('#txtMAWBMBLNo').val() + ' / ' + $('#txtHAWBHBLNo').val());
            }
        });

        $('#txtHAWBHBLNo').keyup(function (e) {
            if ($('#hdn_Transport_Mode').val() == "Air") {
            var txtVal = $(this).val();
            //$('#txtFirst').val(txtVal);
            $('#txtMarksNos').val($('#txtMAWBMBLNo').val() + ' / ' + $('#txtHAWBHBLNo').val());
            }
        });
    });

    //test Ram
    $(function () {
        $('#txtDUTY_UNIT').keyup(function (e) {
            var txtVal = $(this).val().toUpperCase();
            $('#txtunit').val(txtVal);

        });

    });




//function validation() {

//    var txtFlightVesselDate = document.getElementById("txtFlightVesselDate").value;
//    var txtIGMDate = document.getElementById("txtIGMDate").value;
//    var txtIGMNo = document.getElementById("txtIGMNo").value;
//    var hdn_filling_status = document.getElementById("hdn_filling_status").value;
//    var hdn_Transport_Mode = document.getElementById("hdn_Transport_Mode").value;
//    var hdn_BEType = document.getElementById("hdn_BEType").value;
//    var txtMarksNos = document.getElementById("txtMarksNos").value;


//    if (hdn_Transport_Mode != "") {
//        //////////-------------------------------------AIR-------------------------/////////////////
//        if (hdn_Transport_Mode == "Air") {

//            if (hdn_filling_status != "") {

//                if (hdn_filling_status == "Normal") {

//                    if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' && hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' && hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {
//                        /////////txtIGMNo
//                        if (txtIGMNo == "") {
//                            jAlert('IGMNo cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMNo").focus(); });
//                            return false;
//                        }

//                        /////////txtFlightVesselDate
//                        if (txtFlightVesselDate != "") {
//                            if (isDate(txtFlightVesselDate)) {

//                            }
//                            else {
//                                jAlert('FlightVesselDate is Invalid Date', 'IGM', function (r) { document.getElementById("txtFlightVesselDate").focus(); });
//                                return false;
//                            }
//                        }
//                        else {
//                            jAlert('FlightVesselDate cannot be empty', 'IGM', function (r) { document.getElementById("txtFlightVesselDate").focus(); });
//                            return false;
//                        }
//                        /////////IGM Date
//                        if (txtIGMDate != "") {
//                            if (isDate(txtIGMDate)) {

//                            }
//                            else {
//                                jAlert('IGM Date is Invalid Date', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });
//                                return false;
//                            }
//                        }
//                        else {
//                            jAlert('IGM Date cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });
//                            return false;
//                        }
//                    } //end if (hdn_BEType == 'SEZ DTA-M')
//                }
//                else if (hdn_filling_status == "Advanced") {
//                    if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' && hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' && hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {
//                        /////////txtIGMNo
//                        if (txtIGMNo == "") {
//                            jAlert('IGM No cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMNo").focus(); });
//                            return false;
//                        }


//                        /////////IGM Date
//                        if (txtIGMDate != "") {
//                            if (isDate(txtIGMDate)) {

//                            }
//                            else {
//                                jAlert('IGM Date is Invalid Date', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });
//                                return false;
//                            }
//                        }
//                        else {
//                            jAlert('IGM Date cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });
//                            return false;
//                        }
//                    } //end if (hdn_BEType == 'SEZ DTA-M')

//                }
//            }
//        }
//        //////////-------------------------------------SEA-------------------------/////////////////

//        else if (hdn_Transport_Mode == "Sea") {

//            if (hdn_filling_status != "") {
//                if (hdn_filling_status == "Normal") {
//                    if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' && hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' && hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {
//                        /////////txtIGMNo
//                        if (txtIGMNo == "") {
//                            jAlert('IGM No cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMNo").focus(); });
//                            return false;

//                        }

//                        /////////txtFlightVesselDate
//                        if (txtFlightVesselDate != "") {
//                            if (isDate(txtFlightVesselDate)) {

//                            }
//                            else {
//                                jAlert('Flight/Vessel Date is Invalid Date', 'IGM', function (r) { document.getElementById("txtFlightVesselDate").focus(); });
//                                return false;
//                            }
//                        }
//                        else {
//                            jAlert('Flight/Vessel Date cannot be empty', 'IGM', function (r) { document.getElementById("txtFlightVesselDate").focus(); });
//                            return false;
//                        }
//                        /////////IGM Date
//                        if (txtIGMDate != "") {
//                            if (isDate(txtIGMDate)) {

//                            }
//                            else {
//                                jAlert('IGM Date is Invalid Date', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });
//                                return false;
//                            }
//                        }
//                        else {
//                            jAlert('IGM Date cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });
//                            return false;
//                        }
//                    } //end if (hdn_BEType == 'SEZ DTA-M')
//                }
//                else if (hdn_filling_status == "Prior") {

//                    if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' && hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' && hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {
//                        /////////txtIGMNo
//                        if (txtIGMNo == "") {
//                            jAlert('IGM No cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMNo").focus(); });
//                            return false;
//                        }

//                        /////////IGM Date
//                        if (txtIGMDate != "") {
//                            if (isDate(txtIGMDate)) {

//                            }
//                            else {
//                                jAlert('IGM Date is Invalid Date', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });
//                                return false;
//                            }
//                        }
//                        else {
//                            jAlert('IGM Date cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });
//                            return false;
//                        }
//                    } //end if (hdn_BEType == 'SEZ DTA-M')
//                }
//            }
//        }



//        //////////-------------------------------------Land-------------------------/////////////////

//        else if (hdn_Transport_Mode == "Land") {

//            if (hdn_filling_status != "") {
//                if (hdn_filling_status == "Normal") {
//                    if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' && hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' && hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {
//                        /////////txtIGMNo
//                        if (txtIGMNo == "") {
//                            jAlert('IGM No cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMNo").focus(); });
//                            return false;

//                        }

//                        /////////txtFlightVesselDate
//                        if (txtFlightVesselDate != "") {
//                            if (isDate(txtFlightVesselDate)) {

//                            }
//                            else {
//                                jAlert('Flight/Vessel Date is Invalid Date', 'IGM', function (r) { document.getElementById("txtFlightVesselDate").focus(); });
//                                return false;
//                            }
//                        }
//                        else {
//                            jAlert('Flight/Vessel Date cannot be empty', 'IGM', function (r) { document.getElementById("txtFlightVesselDate").focus(); });
//                            return false;
//                        }
//                        /////////IGM Date
//                        if (txtIGMDate != "") {
//                            if (isDate(txtIGMDate)) {

//                            }
//                            else {
//                                jAlert('IGM Date is Invalid Date', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });
//                                return false;
//                            }
//                        }
//                        else {
//                            jAlert('IGM Date cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });
//                            return false;
//                        }
//                    } //end if (hdn_BEType == 'SEZ DTA-M')
//                }
//                else if (hdn_filling_status == "Prior") {
//                    /////////txtIGMNo
//                    //                    if (txtIGMNo == "") {
//                    //                        jAlert('IGM No cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMNo").focus(); });
//                    //                        return false;
//                    //                    }


//                    //                    /////////IGM Date
//                    //                    if (txtIGMDate != "") {
//                    //                        if (isDate(txtIGMDate)) {

//                    //                        }
//                    //                        else {
//                    //                            jAlert('IGM Date is Invalid Date', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });

//                    //                            return false;
//                    //                        }
//                    //                    }
//                    //                    else {
//                    //                        jAlert('IGM Date cannot be empty', 'IGM', function (r) { document.getElementById("txtIGMDate").focus(); });

//                    //                        return false;
//                    //                    }
//                }
//                if (hdn_Transport_Mode == "Land") {

//                    //                    if (document.getElementById("hdn_CompanyID").value != 'eri00747' && document.getElementById("hdn_CompanyID").value != 'eri00542' && document.getElementById("hdn_CompanyID").value != 'eri00829' && document.getElementById("hdn_CompanyID").value != 'eri00001' && document.getElementById("hdn_CompanyID").value != 'eri00010' && document.getElementById("hdn_CompanyID").value != 'eri00005') {
//                    //                        var hd_CUSTOMHOUSE_CODE = document.getElementById("hd_CUSTOMHOUSE_CODE").value;
//                    //                        if (hd_CUSTOMHOUSE_CODE.substr(5, 1) == '6') {
//                    //                            if (document.getElementById("txtGateway_Igm_No").value == "") {
//                    //                                jAlert('IGM_GATEWAY_IGM_NO cannot be empty', 'IGM', function (r) { document.getElementById("txtGateway_Igm_No").focus(); });
//                    //                                return false;
//                    //                            }
//                    //                        }
//                    //                        if (document.getElementById("txtGateway_Igm_Date").value == "") {
//                    //                            if (isDate(document.getElementById("txtGateway_Igm_Date").value)) {

//                    //                            }
//                    //                            else {
//                    //                                    jAlert('IGM_GATEWAY_IGM_DATE is Invalid Date', 'IGM', function (r) { document.getElementById("txtGateway_Igm_Date").focus(); });
//                    //                                    return false;
//                    //                            }
//                    //                        }


//                    if ((document.getElementById("hdn_CompanyID").value == 'eri02118' || document.getElementById("hdn_CompanyID").value == 'eri02373') && (hdn_filling_status == "Advanced" || hdn_filling_status == "Prior")) {//Reqrd.By Mohmed on 29-02-2024
//                        //Gateway Port code - Not Mandatory.
//                    }
//                    else {
//                        if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' && hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' && hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {
//                            var hd_CUSTOMHOUSE_CODE = document.getElementById("hd_CUSTOMHOUSE_CODE").value;
//                            if (document.getElementById("txtGateway_Port_Code").value == "") {
//                                if (hd_CUSTOMHOUSE_CODE.substr(5, 1) != 'B') {
//                                    jAlert('Gateway_Port_Code cannot be empty', 'IGM', function (r) { document.getElementById("txtGateway_Port_Code").focus(); });
//                                    return false;
//                                }
//                            }
//                        }
//                    }
//                    //  } 
//                }
//            }
//        }
//    }

//    //------------------------ MAWB Validation---------------------------------

//    if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' && hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' && hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {
//        var MAWBMBLNo = document.getElementById("txtMAWBMBLNo").value;
//        if (document.getElementById("hdn_CompanyID").value != 'eri00727' && document.getElementById("hdn_CompanyID").value != 'eri00747' && document.getElementById("hdn_CompanyID").value != 'eri00004' && document.getElementById("hdn_CompanyID").value != 'eri00005') {

//            if (MAWBMBLNo.length <= 0) {
//                jAlert('MAWB/MBL NO cannot be blank', 'IGM', function (r) { document.getElementById("txtMAWBMBLNo").focus(); });
//                return false;
//            }
//        }

//        if (containsSpecialChars(MAWBMBLNo)) {
//            jAlert('MAWB/MBL No - Contains Special Character', 'IGM', function (r) { document.getElementById("txtMAWBMBLNo").focus(); });
//            return false;
//        }
//        //-----------------------------------------------------------------------


//        var txtMAWBMBLDate = document.getElementById("txtMAWBMBLDate").value;
//        if (txtMAWBMBLDate != "") {
//            if (isDate(txtMAWBMBLDate)) {

//                if (document.getElementById("hdn_CompanyID").value == 'eri00010' || document.getElementById("hdn_CompanyID").value == 'eri00247') {
//                    var ss = txtMAWBMBLDate.split('/');
//                    var Mbldt = new Date(ss[2] + '-' + ss[1] + '-' + ss[0]).toISOString().slice(0, 10);  //Mbldate  
//                    var todayDate = new Date().toISOString().slice(0, 10); //today Date

//                    if (Mbldt > todayDate) {
//                        jAlert('MAWB/MBL Date is greater than Today Date', 'IGM', function (r) { document.getElementById("txtMAWBMBLDate").focus(); });
//                        return false;
//                    }
//                }

//            }
//            else {
//                jAlert('MAWB/MBL date Date is Invalid Date', 'IGM', function (r) { document.getElementById("txtMAWBMBLDate").focus(); });
//                return false;
//            }
//        }
//        else {
//            if (document.getElementById("hdn_CompanyID").value != 'eri00727' && document.getElementById("hdn_CompanyID").value != 'eri00747' && document.getElementById("hdn_CompanyID").value != 'eri00004' && document.getElementById("hdn_CompanyID").value != 'eri00005') {
//                jAlert('MAWB/MBL date Date cannot be empty', 'IGM', function (r) { document.getElementById("txtMAWBMBLDate").focus(); });
//                return false;
//            }
//        }
//    } //end if (hdn_BEType == 'SEZ DTA-M')


//    var txtHAWBHBLDate = document.getElementById("txtHAWBHBLDate").value;
//    if (txtHAWBHBLDate != "") {
//        if (isDate(txtHAWBHBLDate)) {

//        }
//        else {
//            jAlert('HAWB/HBL date is Invalid Date', 'IGM', function (r) { document.getElementById("txtHAWBHBLDate").focus(); });

//            return false;
//        }
//    }
//    //           package

//    if (document.getElementById("txtPackages").value == "") {
//        jAlert('Package cannot be blank', 'IGM', function (r) { document.getElementById("txtPackages").focus(); });


//        return false;
//    }
//    var digits = "0123456789.";
//    var temp;
//    for (var i = 0; i < document.getElementById("txtPackages").value.length; i++) {
//        temp = document.getElementById("txtPackages").value.substring(i, i + 1);
//        if (digits.indexOf(temp) == -1) {
//            jAlert('package Not valid', 'IGM', function (r) { document.getElementById("txtPackages").focus(); });
//            return false;
//        }
//    }


//    if (document.getElementById("txtPackageType").value == "") {
//        jAlert('PackageType cannot be blank', 'IGM', function (r) { document.getElementById("txtPackageType").focus(); });
//        return false;
//    }

//    var PackageType;
//    PackageType = document.getElementById("txtPackageType").value;

//    if (PackageType.length <= 0) {

//        jAlert('Package Type cannot be blank', 'IGM', function (r) { document.getElementById("txtPackageType").focus(); });
//        return false;
//    }


//    else if (PackageType.length < 3) {
//        jAlert('Package Type should be 3 characters', 'IGM', function (r) { document.getElementById("txtPackageType").focus(); });
//        return false;
//    }

//    //           gross weight

//    if (document.getElementById("txtGrossWeight").value == "") {
//        jAlert('Gross weight cannot be blank', 'IGM', function (r) { document.getElementById("txtGrossWeight").focus(); });
//        return false;
//    }
//    var digits = "0123456789.";
//    var temp;
//    for (var i = 0; i < document.getElementById("txtGrossWeight").value.length; i++) {
//        temp1 = document.getElementById("txtGrossWeight").value.substring(i, i + 1);
//        if (digits.indexOf(temp1) == -1) {
//            jAlert('Gross weight Not valid', 'IGM', function (r) { document.getElementById("txtGrossWeight").focus(); });
//            return false;
//        }
//    }

//    var GrossWeightType;
//    GrossWeightType = document.getElementById("txtGrossWeightType").value;

//    if (GrossWeightType.length <= 0) {

//        jAlert('GrossWeight Type cannot be blank', 'IGM', function (r) { document.getElementById("txtGrossWeightType").focus(); });
//        return false;
//    }


//    else if (GrossWeightType.length < 3) {
//        jAlert('GrossWeight Type should be 3 characters', 'IGM', function (r) { document.getElementById("txtGrossWeightType").focus(); });

//        return false;
//    }

//    var digits = "0123456789.";
//    var temp;
//    for (var i = 0; i < document.getElementById("txtNetWeight").value.length; i++) {
//        temp1 = document.getElementById("txtNetWeight").value.substring(i, i + 1);
//        if (digits.indexOf(temp1) == -1) {
//            jAlert('Net weight Not valid', 'IGM', function (r) { document.getElementById("txtNetWeight").focus(); });
//            return false;
//        }
//    }




//    //            var tNetWeight;
//    //            tNetWeight = document.getElementById("txtNetWeight").value;

//    //            if (tNetWeight.length <= 0) {
//    //               
//    //                return true;
//    //            }


//    //            
//    //            else if (tNetWeight.length = 1) {

//    //                var GrossWeight3;
//    //                GrossWeight3 = document.getElementById("txtNetWeightType").value;
//    //                if (GrossWeight3.length <= 0) {
//    // jAlert('NetWeight Type cannot be blank', 'IGM', function (r) { document.getElementById("txtNetWeightType").focus(); });


//    //                    return false;
//    //                    }
//    //                   
//    //                   else if (GrossWeight3.length < 3) {
//    //jAlert('NetWeight Type should be 3 characters', 'IGM', function (r) { document.getElementById("txtNetWeightType").focus(); });


//    //                        return false;
//    //                    }
//    //               

//    //            }


//    //            //
//    //            


////                var MarksNos = document.getElementById("txtMarksNos").value;
////                if (MarksNos.length <= 0) {
////    jAlert('Marks and nos cannot be blank', 'IGM', function (r) { document.getElementById("txtMarksNos").focus(); });
////                    return false;
////                }


//    if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' && hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' && hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {
//        if (txtMarksNos == "") {
//            jAlert('Marks and Nos cannot be blank', 'IGM', function (r) { document.getElementById("txtMarksNos").focus(); });
//            return false;
//        }
//    }

    //}



    function showMandatoryTooltip(elementId, callback) {
        // ✅ Remove existing tooltip
        var existing = document.getElementById('mand_tooltip_temp');
        if (existing) existing.parentNode.removeChild(existing);

        var el = document.getElementById(elementId);
        if (!el) { callback(); return; }

        var tip = document.createElement('div');
        tip.id = 'mand_tooltip_temp';
        tip.className = 'mand-tooltip';
        tip.innerHTML = '* Mandatory';

        var rect = el.getBoundingClientRect();
        var scrollTop = window.pageYOffset
                     || document.documentElement.scrollTop;
        var scrollLeft = window.pageXOffset
                     || document.documentElement.scrollLeft;
        var tipWidth = 80;

        tip.style.position = 'absolute';
        tip.style.top = (rect.top + scrollTop - 22) + 'px';
        tip.style.left = (rect.right + scrollLeft - tipWidth) + 'px';

        document.body.appendChild(tip);

        // ✅ Show tooltip FIRST — then jAlert after 1 second
        var autoRemove = setTimeout(function () {
            var t = document.getElementById('mand_tooltip_temp');
            if (t) t.parentNode.removeChild(t);
            document.removeEventListener('click', removeTip);
        }, 8000);

        function removeTip() {
            var t = document.getElementById('mand_tooltip_temp');
            if (t) t.parentNode.removeChild(t);
            clearTimeout(autoRemove);
            document.removeEventListener('click', removeTip);
        }

        setTimeout(function () {
            document.addEventListener('click', removeTip);
        }, 100);

        // ✅ Show jAlert after 1 second so tooltip is visible first
        setTimeout(function () {
            callback();
        }, 1000);
    }

    function validation() {

        var txtFlightVesselDate = document.getElementById("txtFlightVesselDate").value;
        var txtIGMDate = document.getElementById("txtIGMDate").value;
        var txtIGMNo = document.getElementById("txtIGMNo").value;
        var hdn_filling_status = document.getElementById("hdn_filling_status").value;
        var hdn_Transport_Mode = document.getElementById("hdn_Transport_Mode").value;
        var hdn_BEType = document.getElementById("hdn_BEType").value;
        var txtMarksNos = document.getElementById("txtMarksNos").value;

        if (hdn_Transport_Mode != "") {

            // ════════════════════════════════════════════════════════
            //  AIR
            // ════════════════════════════════════════════════════════
            if (hdn_Transport_Mode == "Air") {
                if (hdn_filling_status != "") {

                    if (hdn_filling_status == "Normal") {
                        if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' &&
                        hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' &&
                        hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {

                            // ── IGM No ────────────────────────────────────────
                            if (mand_IGMNo == "Y") {
                                if (document.getElementById("txtIGMNo").value.trim() == "") {
                                    showMandatoryTooltip("txtIGMNo", function () {
                                        jAlert('IGM No cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtIGMNo").focus();
                                        });
                                    });
                                    return false;
                                }
                            }

                            // ── Flight Vessel Date — OWN flag ─────────────────
                            if (mand_FlightVesselDate == "Y") {
                                if (txtFlightVesselDate == "") {
                                    showMandatoryTooltip("txtFlightVesselDate", function () {
                                        jAlert('Flight/Vessel Date cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtFlightVesselDate").focus();
                                        });
                                    });
                                    return false;
                                }
                            }
                            // ✅ Format check — always run if value entered
                            if (txtFlightVesselDate != "") {
                                if (!isDate(txtFlightVesselDate)) {
                                    jAlert('Flight/Vessel Date is Invalid Date', 'IGM', function (r) {
                                        document.getElementById("txtFlightVesselDate").focus();
                                    });
                                    return false;
                                }
                            }

                            // ── IGM Date — OWN flag ───────────────────────────
                            if (mand_IGMDate == "Y") {
                                if (txtIGMDate == "") {
                                    showMandatoryTooltip("txtIGMDate", function () {
                                        jAlert('IGM Date cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtIGMDate").focus();
                                        });
                                    });
                                    return false;
                                }
                            }
                            // ✅ Format check — always run if value entered
                            if (txtIGMDate != "") {
                                if (!isDate(txtIGMDate)) {
                                    jAlert('IGM Date is Invalid Date', 'IGM', function (r) {
                                        document.getElementById("txtIGMDate").focus();
                                    });
                                    return false;
                                }
                            }
                        }
                    }

                    else if (hdn_filling_status == "Advanced") {
                        if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' &&
                        hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' &&
                        hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {

                            // ── IGM No ────────────────────────────────────────
                            if (mand_IGMNo == "Y") {
                                if (document.getElementById("txtIGMNo").value.trim() == "") {
                                    showMandatoryTooltip("txtIGMNo", function () {
                                        jAlert('IGM No cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtIGMNo").focus();
                                        });
                                    });
                                    return false;
                                }
                            }

                            // ── IGM Date — OWN flag ───────────────────────────
                            if (mand_IGMDate == "Y") {
                                if (txtIGMDate == "") {
                                    showMandatoryTooltip("txtIGMDate", function () {
                                        jAlert('IGM Date cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtIGMDate").focus();
                                        });
                                    });
                                    return false;
                                }
                            }
                            // ✅ Format check — always run if value entered
                            if (txtIGMDate != "") {
                                if (!isDate(txtIGMDate)) {
                                    jAlert('IGM Date is Invalid Date', 'IGM', function (r) {
                                        document.getElementById("txtIGMDate").focus();
                                    });
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            // ════════════════════════════════════════════════════════
            //  SEA
            // ════════════════════════════════════════════════════════
            else if (hdn_Transport_Mode == "Sea") {
                if (hdn_filling_status != "") {

                    if (hdn_filling_status == "Normal") {
                        if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' &&
                        hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' &&
                        hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {

                            // ── IGM No ────────────────────────────────────────
                            if (mand_IGMNo == "Y") {
                                if (document.getElementById("txtIGMNo").value.trim() == "") {
                                    showMandatoryTooltip("txtIGMNo", function () {
                                        jAlert('IGM No cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtIGMNo").focus();
                                        });
                                    });
                                    return false;
                                }
                            }

                            // ── Flight/Vessel Date — OWN flag ─────────────────
                            if (mand_FlightVesselDate == "Y") {
                                if (txtFlightVesselDate == "") {
                                    showMandatoryTooltip("txtFlightVesselDate", function () {
                                        jAlert('Flight/Vessel Date cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtFlightVesselDate").focus();
                                        });
                                    });
                                    return false;
                                }
                            }
                            // ✅ Format check — always run if value entered
                            if (txtFlightVesselDate != "") {
                                if (!isDate(txtFlightVesselDate)) {
                                    jAlert('Flight/Vessel Date is Invalid Date', 'IGM', function (r) {
                                        document.getElementById("txtFlightVesselDate").focus();
                                    });
                                    return false;
                                }
                            }

                            // ── IGM Date — OWN flag ───────────────────────────
                            if (mand_IGMDate == "Y") {
                                if (txtIGMDate == "") {
                                    showMandatoryTooltip("txtIGMDate", function () {
                                        jAlert('IGM Date cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtIGMDate").focus();
                                        });
                                    });
                                    return false;
                                }
                            }
                            // ✅ Format check — always run if value entered
                            if (txtIGMDate != "") {
                                if (!isDate(txtIGMDate)) {
                                    jAlert('IGM Date is Invalid Date', 'IGM', function (r) {
                                        document.getElementById("txtIGMDate").focus();
                                    });
                                    return false;
                                }
                            }
                        }
                    }

                    else if (hdn_filling_status == "Prior") {
                        if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' &&
                        hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' &&
                        hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {

                            // ── IGM No ────────────────────────────────────────
                            if (mand_IGMNo == "Y") {
                                if (document.getElementById("txtIGMNo").value.trim() == "") {
                                    showMandatoryTooltip("txtIGMNo", function () {
                                        jAlert('IGM No cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtIGMNo").focus();
                                        });
                                    });
                                    return false;
                                }
                            }

                            // ── IGM Date — OWN flag ───────────────────────────
                            if (mand_IGMDate == "Y") {
                                if (txtIGMDate == "") {
                                    showMandatoryTooltip("txtIGMDate", function () {
                                        jAlert('IGM Date cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtIGMDate").focus();
                                        });
                                    });
                                    return false;
                                }
                            }
                            // ✅ Format check — always run if value entered
                            if (txtIGMDate != "") {
                                if (!isDate(txtIGMDate)) {
                                    jAlert('IGM Date is Invalid Date', 'IGM', function (r) {
                                        document.getElementById("txtIGMDate").focus();
                                    });
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            // ════════════════════════════════════════════════════════
            //  LAND
            // ════════════════════════════════════════════════════════
            else if (hdn_Transport_Mode == "Land") {
                if (hdn_filling_status != "") {

                    if (hdn_filling_status == "Normal") {
                        if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' &&
                        hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' &&
                        hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {

                            // ── IGM No ────────────────────────────────────────
                            if (mand_IGMNo == "Y") {
                                if (document.getElementById("txtIGMNo").value.trim() == "") {
                                    showMandatoryTooltip("txtIGMNo", function () {
                                        jAlert('IGM No cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtIGMNo").focus();
                                        });
                                    });
                                    return false;
                                }
                            }

                            // ── Flight/Vessel Date — OWN flag ─────────────────
                            if (mand_FlightVesselDate == "Y") {
                                if (txtFlightVesselDate == "") {
                                    showMandatoryTooltip("txtFlightVesselDate", function () {
                                        jAlert('Flight/Vessel Date cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtFlightVesselDate").focus();
                                        });
                                    });
                                    return false;
                                }
                            }
                            // ✅ Format check — always run if value entered
                            if (txtFlightVesselDate != "") {
                                if (!isDate(txtFlightVesselDate)) {
                                    jAlert('Flight/Vessel Date is Invalid Date', 'IGM', function (r) {
                                        document.getElementById("txtFlightVesselDate").focus();
                                    });
                                    return false;
                                }
                            }

                            // ── IGM Date — OWN flag ───────────────────────────
                            if (mand_IGMDate == "Y") {
                                if (txtIGMDate == "") {
                                    showMandatoryTooltip("txtIGMDate", function () {
                                        jAlert('IGM Date cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtIGMDate").focus();
                                        });
                                    });
                                    return false;
                                }
                            }
                            // ✅ Format check — always run if value entered
                            if (txtIGMDate != "") {
                                if (!isDate(txtIGMDate)) {
                                    jAlert('IGM Date is Invalid Date', 'IGM', function (r) {
                                        document.getElementById("txtIGMDate").focus();
                                    });
                                    return false;
                                }
                            }
                        }
                    }

                    // ── Gateway Port Code — NOT flag driven ───────────────
                    if (hdn_Transport_Mode == "Land") {
                        if ((document.getElementById("hdn_CompanyID").value == 'eri02118' ||
                         document.getElementById("hdn_CompanyID").value == 'eri02373') &&
                        (hdn_filling_status == "Advanced" || hdn_filling_status == "Prior")) {
                            // Not mandatory for these companies
                        } else {
                            if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' &&
                            hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' &&
                            hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {
                                var hd_CUSTOMHOUSE_CODE =
                                document.getElementById("hd_CUSTOMHOUSE_CODE").value;
                                if (document.getElementById("txtGateway_Port_Code").value == "") {
                                    if (hd_CUSTOMHOUSE_CODE.substr(5, 1) != 'B') {
                                        jAlert('Gateway_Port_Code cannot be empty', 'IGM', function (r) {
                                            document.getElementById("txtGateway_Port_Code").focus();
                                        });
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        //  MAWB/MBL No — driven by master setting
        // ════════════════════════════════════════════════════════════
        if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' &&
        hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' &&
        hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {

            if (mand_MAWBMBLNo == "Y") {
                var MAWBMBLNo = document.getElementById("txtMAWBMBLNo").value;
                if (document.getElementById("hdn_CompanyID").value != 'eri00727' &&
                document.getElementById("hdn_CompanyID").value != 'eri00747' &&
                document.getElementById("hdn_CompanyID").value != 'eri00004' &&
                document.getElementById("hdn_CompanyID").value != 'eri00005') {
                    if (MAWBMBLNo.trim() == "") {
                        showMandatoryTooltip("txtMAWBMBLNo", function () {
                            jAlert('MAWB/MBL NO cannot be blank', 'IGM', function (r) {
                                document.getElementById("txtMAWBMBLNo").focus();
                            });
                        });
                        return false;
                    }
                }
                if (containsSpecialChars(MAWBMBLNo)) {
                    jAlert('MAWB/MBL No - Contains Special Character', 'IGM', function (r) {
                        document.getElementById("txtMAWBMBLNo").focus();
                    });
                    return false;
                }
            }

            // ════════════════════════════════════════════════════════
            //  MAWB/MBL Date — driven by master setting
            // ════════════════════════════════════════════════════════
            if (mand_MAWBMBLDate == "Y") {
                var txtMAWBMBLDate = document.getElementById("txtMAWBMBLDate").value;
                if (txtMAWBMBLDate != "") {
                    if (isDate(txtMAWBMBLDate)) {
                        if (document.getElementById("hdn_CompanyID").value == 'eri000100' ||
                        document.getElementById("hdn_CompanyID").value == 'eri00247') {
                            var ss = txtMAWBMBLDate.split('/');
                            var Mbldt = new Date(ss[2] + '-' + ss[1] + '-' + ss[0])
                                        .toISOString().slice(0, 10);
                            var today = new Date().toISOString().slice(0, 10);
                            if (Mbldt > today) {
                                showMandatoryTooltip("txtMAWBMBLDate", function () {
                                    jAlert('MAWB/MBL Date is greater than Today Date', 'IGM',
                                    function (r) {
                                        document.getElementById("txtMAWBMBLDate").focus();
                                    });
                                });
                                return false;
                            }
                        }
                    } else {
                        showMandatoryTooltip("txtMAWBMBLDate", function () {
                            jAlert('MAWB/MBL Date is Invalid Date', 'IGM', function (r) {
                                document.getElementById("txtMAWBMBLDate").focus();
                            });
                        });
                        return false;
                    }
                } else {
                    if (document.getElementById("hdn_CompanyID").value != 'eri00727' &&
                    document.getElementById("hdn_CompanyID").value != 'eri00747' &&
                    document.getElementById("hdn_CompanyID").value != 'eri00004' &&
                    document.getElementById("hdn_CompanyID").value != 'eri00005') {
                        showMandatoryTooltip("txtMAWBMBLDate", function () {
                            jAlert('MAWB/MBL Date cannot be empty', 'IGM', function (r) {
                                document.getElementById("txtMAWBMBLDate").focus();
                            });
                        });
                        return false;
                    }
                }
            }
        }

        // ── HAWB/HBL Date — format check only, NOT flag driven ───────
        var txtHAWBHBLDate = document.getElementById("txtHAWBHBLDate").value;
        if (txtHAWBHBLDate != "") {
            if (!isDate(txtHAWBHBLDate)) {
                jAlert('HAWB/HBL date is Invalid Date', 'IGM', function (r) {
                    document.getElementById("txtHAWBHBLDate").focus();
                });
                return false;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Packages — driven by master setting
        // ════════════════════════════════════════════════════════════
        if (mand_Packages == "Y") {
            var pkgRaw = document.getElementById("txtPackages").value.trim();

            if (pkgRaw === "") {
                showMandatoryTooltip("txtPackages", function () {
                    jAlert('Package cannot be blank', 'IGM', function (r) {
                        document.getElementById("txtPackages").focus();
                    });
                });
                return false;
            }
            if (!/^[0-9]+$/.test(pkgRaw)) {
                jAlert('Package must contain digits only (no decimals)', 'IGM', function (r) {
                    document.getElementById("txtPackages").focus();
                });
                return false;
            }
            if (parseInt(pkgRaw, 10) <= 0) {
                jAlert('Package must be greater than zero', 'IGM', function (r) {
                    document.getElementById("txtPackages").focus();
                });
                return false;
            }
            document.getElementById("txtPackages").value = parseInt(pkgRaw, 10).toString();
        }

        // ════════════════════════════════════════════════════════════
        //  Package Type — driven by master setting
        // ════════════════════════════════════════════════════════════
        if (mand_PackageType == "Y") {
            var pkgType = document.getElementById("txtPackageType").value.trim();

            if (pkgType.length <= 0) {
                showMandatoryTooltip("txtPackageType", function () {
                    jAlert('Package Type cannot be blank', 'IGM', function (r) {
                        document.getElementById("txtPackageType").focus();
                    });
                });
                return false;
            }
            if (!/^[a-zA-Z]+$/.test(pkgType)) {
                jAlert('Package Type must contain letters only', 'IGM', function (r) {
                    document.getElementById("txtPackageType").focus();
                });
                return false;
            }
            if (pkgType.length < 3) {
                showMandatoryTooltip("txtPackageType", function () {
                    jAlert('Package Type should be minimum 3 characters', 'IGM', function (r) {
                        document.getElementById("txtPackageType").focus();
                    });
                });
                return false;
            }
            document.getElementById("txtPackageType").value = pkgType.toUpperCase();
        }

        // ════════════════════════════════════════════════════════════
        //  Gross Weight — driven by master setting
        // ════════════════════════════════════════════════════════════
        if (mand_GrossWeight == "Y") {
            if (document.getElementById("txtGrossWeight").value.trim() == "") {
                showMandatoryTooltip("txtGrossWeight", function () {
                    jAlert('Gross Weight cannot be blank', 'IGM', function (r) {
                        document.getElementById("txtGrossWeight").focus();
                    });
                });
                return false;
            }
            var digits = "0123456789.";
            for (var i = 0; i < document.getElementById("txtGrossWeight").value.length; i++) {
                var temp1 = document.getElementById("txtGrossWeight").value.substring(i, i + 1);
                if (digits.indexOf(temp1) == -1) {
                    jAlert('Gross Weight Not valid', 'IGM', function (r) {
                        document.getElementById("txtGrossWeight").focus();
                    });
                    return false;
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Gross Weight Type — driven by master setting
        // ════════════════════════════════════════════════════════════
        if (mand_GrossWeightType == "Y") {
            var GrossWeightType = document.getElementById("txtGrossWeightType").value;
            if (GrossWeightType.trim().length <= 0) {
                showMandatoryTooltip("txtGrossWeightType", function () {
                    jAlert('GrossWeight Type cannot be blank', 'IGM', function (r) {
                        document.getElementById("txtGrossWeightType").focus();
                    });
                });
                return false;
            } else if (GrossWeightType.length < 3) {
                showMandatoryTooltip("txtGrossWeightType", function () {
                    jAlert('GrossWeight Type should be 3 characters', 'IGM', function (r) {
                        document.getElementById("txtGrossWeightType").focus();
                    });
                });
                return false;
            }
        }

        // ── Net Weight — format check only, NOT flag driven ──────────
        var digits = "0123456789.";
        for (var i = 0; i < document.getElementById("txtNetWeight").value.length; i++) {
            var temp1 = document.getElementById("txtNetWeight").value.substring(i, i + 1);
            if (digits.indexOf(temp1) == -1) {
                jAlert('Net Weight Not valid', 'IGM', function (r) {
                    document.getElementById("txtNetWeight").focus();
                });
                return false;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  Marks and Nos — driven by master setting
        // ════════════════════════════════════════════════════════════
        if (mand_MarksNos == "Y") {
            if (hdn_BEType != 'SEZ DTA-M' && hdn_BEType != 'Jobbing' &&
            hdn_BEType != 'Repair & Return' && hdn_BEType != 'Exhibition' &&
            hdn_BEType != 'Destruction' && hdn_BEType != 'Movement of Goods') {
                if (document.getElementById("txtMarksNos").value.trim() == "") {
                    showMandatoryTooltip("txtMarksNos", function () {
                        jAlert('Marks and Nos cannot be blank', 'IGM', function (r) {
                            document.getElementById("txtMarksNos").focus();
                        });
                    });
                    return false;
                }
            }
        }

        return true;
    }






     
$(function () {
    $("#txtPackageType").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Package_Master_List",
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

                        //jAlert('Package Type is Incorrect', 'IGM', function (r) { document.getElementById('txtPackageType').focus(); });
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


$(function () {
    $("#txtGrossWeightType,#txtNetWeightType,#txtDUTY_UNIT").autocomplete({
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
                        if (field == 'txtGrossWeightType') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Gross Weight Type', 'error', 'topRight', true);

                            //jAlert('Gross Weight Type is Incorrect', 'IGM', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtNetWeightType') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Net Weight Type', 'error', 'topRight', true);

                            //jAlert('Net Weight Type is Incorrect', 'IGM', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtAirlineName").autocomplete({

        source: function (request, response) {
            
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AirLine_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtAirlineName').validationEngine('showPrompt', 'Incorrect Airline Name', 'error', 'topRight', true);

                        //jAlert('Airline Name is Incorrect', 'IGM', function (r) { document.getElementById('txtAirlineName').focus(); });
                        //return false;

                    }
                   
                    else {
                        jQuery('#txtAirlineName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//------------------------------------------//


$(function () {
    $("#txtGateway_Port_Code").autocomplete({

        source: function (request, response) {
           
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List_NEW",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtGateway_Port_Code').validationEngine('showPrompt', 'Incorrect Port Code', 'error', 'topRight', true);

                        //jAlert('Customs House is Incorrect', 'GENERAL', function (r) { document.getElementById("txtCustomsHouse").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtGateway_Port_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//------------------------------------------//





$(function () {

    $('#txtAirlineName').bind('focus keyup keypress change keydown', function () {

        var data = $(this).val();
        country(data);
        
    });
    
});

function country(val) {

    var data = val;
    if (data == '') {
        $('#txtAirlineCode').val('');
    }
    //$('#hdn_Autosearch').val(data);

    if (data.indexOf("-") != -1) {


        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txtAirlineCode').val(after);
        $('#txtAirlineName').val(before);




    }
    else {

    }
}

function Call_AirLine_Code(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    //alert('l');
    PageMethods.GetAirLine_Code(ctrl.value, CallSuccess, CallFailed, dest);

}
// set the destination textbox value with the ContactName
function CallSuccess(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    dest.value = res;
    if (document.getElementById("txtAirlineName").value == '') {
        jQuery('#txtAirlineName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
    }
}
// alert message on some failure
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}

/*
// This script for Elaiyaraja
function MAWB_VALIDATION() {
    var hdn_Transport_Mode = document.getElementById("hdn_Transport_Mode").value;
    var hdn_filling_status = document.getElementById("hdn_filling_status").value;
   
    if ((hdn_Transport_Mode) == "Air") {
        if (hdn_filling_status != "Advanced") {
            if (document.getElementById("txtMAWBMBLNo").value.length != 11) {
                alert("MAWB No must be 11 digits, No need blank space and any Special Characters");
                document.getElementById('txtMAWBMBLNo').focus();

                //jAlert('MAWB No must be 11 digits', 'IGM', function (r) { document.getElementById('txtMAWBMBLNo').focus(); });
                //txtMAWBMBLNo
            }
            else {
                var mawbNo = document.getElementById("txtMAWBMBLNo").value;
                var m2 = mawbNo.substr(3, 7);
                var m3 = mawbNo.substr(10);
                var IATAChecker = m2 % 7;
                if (m3 != IATAChecker) {
                    alert("MAWB No  is  Invalid");
                    document.getElementById('txtMAWBMBLNo').focus();

                    //jAlert('MAWB No  is  Invalid', 'IGM', function (r) { document.getElementById('txtMAWBMBLNo').focus(); });
                }
            }
        }
    }
}

// End script for Elaiyaraja

*/
// Condition Added by pandiyan on 25-07-2025 sugg by bala --Start
function MAWB_VALIDATION() {
    var hdn_Transport_Mode = document.getElementById("hdn_Transport_Mode").value;
    var hdn_filling_status = document.getElementById("hdn_filling_status").value;
    var mawbInput = document.getElementById("txtMAWBMBLNo").value.toUpperCase();

    if (hdn_Transport_Mode === "Air" && (hdn_filling_status == "Normal" || hdn_filling_status == "Prior")) {

        // Allow "NOMAWB" as a valid override
        if (mawbInput == "NOMAWB" && hdn_filling_status == "Prior") {
            return; // Valid special case
        }

        // Validate length and characters
        if (mawbInput.length != 11) {
            alert("MAWB No must be exactly 11 digits, without spaces or special characters.");
            setTimeout(function () {
                document.getElementById('txtMAWBMBLNo').focus();
            }, 10);
            return;
        }

        // IATA check digit validation
        var m2 = mawbInput.substr(3, 7); // serial number
        var m3 = parseInt(mawbInput.substr(10)); // check digit
        var IATAChecker = parseInt(m2) % 7;

        if (parseInt(m3) !== IATAChecker) {
            alert("MAWB No  is  Invalid");
            setTimeout(function () {
                document.getElementById('txtMAWBMBLNo').focus();
            }, 10);
        }
    }
}
 //---End

//-------- Specila Character check - Chithra on 22-08-2023
function containsSpecialChars(str) {
    // Define a regular expression to match special characters
    var specialCharsRegex = /[!@#$%^&*() _+\-=\[\]{};':"\\|,.<>\/?]+/;
    return specialCharsRegex.test(str);
}
//-----------------end-------------------------------------