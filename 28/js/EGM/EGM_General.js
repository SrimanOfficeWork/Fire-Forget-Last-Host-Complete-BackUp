
$(function () {
    $('#txt_Unit').autocomplete({
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
                        jQuery('#txt_Unit').validationEngine('showPrompt', 'Incorrect Qty Code', 'error', 'topRight', true);

                        //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_Unit').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//------------------------------------------//

$(function () {
    $("#txt_Destination_Port").autocomplete({

        source: function (request, response) {
           var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdfTransport_mode").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    if (data.d == '') {
                        if (field == 'txt_Port_of_Origin') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Discharge', 'error', 'topRight', true);

                            //jAlert('Port Discharge is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Destination_Port') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Discharge', 'error', 'topRight', true);

                            //jAlert('Port Discharge is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                    }
                    response(data.d);
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
    $("#txt_GatewayPort,#txt_Port_of_Origin,").autocomplete({

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
                        jQuery('#txt_GatewayPort').validationEngine('showPrompt', 'Incorrect CustomHouse Location', 'error', 'topRight', true);

                        //jAlert('Bond Location is Incorrect', 'BOND', function (r) { document.getElementById("txtBondLocation").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_GatewayPort').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $('#txt_LinerName').autocomplete({
        source: function (request, response) {
            var liner = "Liner";
            $.ajax({

                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EGM_Liner_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + liner + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_LinerName').validationEngine('showPrompt', 'Incorrect Liner', 'error', 'topRight', true);

                        //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_LinerName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//------------------------------------------//

$(function () {
    $('#txt_Vessel_Name').autocomplete({
        source: function (request, response) {
            var Vessel = "Vessel";
           
            $.ajax({

                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EGM_Vessel_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + Vessel + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_Vessel_Name').validationEngine('showPrompt', 'Incorrect Vessel', 'error', 'topRight', true);

                        //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_Vessel_Name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//------------------------------------------//

$(function () {
    $('#txt_JobNo').autocomplete({
        source: function (request, response) {
            $.ajax({

                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXPORT_JOBNO_SEARCH",
                //                data: "{ 'mail': '" + request.term + "' }",
                data: "{ 'mail': '" + request.term + "' ,'Branch':'" + document.getElementById('hd_Branch').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_JobNo').validationEngine('showPrompt', 'Incorrect JobNo', 'error', 'topRight', true);

                        //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_JobNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//------------------------------------------//

$(function () {
    $('#txt_SBNo').autocomplete({
        source: function (request, response) {

            $.ajax({

                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXPORT_SB_NO_SEARCH",
                //                data: "{ 'mail': '" + request.term + "' }",
                data: "{ 'mail': '" + request.term + "' ,'Branch':'" + document.getElementById('hd_Branch').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_SBNo').validationEngine('showPrompt', 'Incorrect SBNo', 'error', 'topRight', true);

                        //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_SBNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//-------------------------------------------------------------------------------------------------------------------------------------

function CallServerside_jobno_EGM(src, dest) {
    var ctrl = document.getElementById(src).value;
    var ctrl1 = document.getElementById(dest).value;

    PageMethods.Get_EGM_JobNo(ctrl, ctrl1, CallSuccess_EGM, CallFailed, dest);
}

function CallServerside_SB_No_EGM(src, dest) {
    var ctrl = document.getElementById(src).value;
    var ctrl1 = document.getElementById(dest).value;

    PageMethods.Get_SB_JobNo(ctrl, ctrl1, CallSuccess_EGM, CallFailed, dest);
}

//Importer Branch
function CallSuccess_EGM(res, destCtrl) {
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
        var after21 = s[21];
        var after22 = s[22];
        var after23 = s[23];
        var after24 = s[24];
        var after25 = s[25];
        var after26 = s[26];

//                alert(after17);

        document.getElementById("txt_JobNo").value = before;
        document.getElementById("txt_Job_Date").value = after1;
        document.getElementById("txt_Exporter_Name").value = after2;
        document.getElementById("txt_ExporterAddress1").value = after3;
        document.getElementById("txt_ExporterAddress2").value = after4;
        document.getElementById("txt_ExporterAddress3").value = after5;
        document.getElementById("txt_ExporterAddress4").value = after6;
        document.getElementById("txt_GatewayPort").value = after8;

        //        document.getElementById("txt_Port_of_Origin").value = after9;
        document.getElementById("txt_Port_of_Origin").value = after8;

        document.getElementById("txt_Destination_Port").value = after10;
        document.getElementById("txtConsignee").value = after11;
        document.getElementById("txtConsignee_Address1").value = after12;
        document.getElementById("txtConsignee_Address2").value = after13;
        document.getElementById("txtConsignee_Address3").value = after14;
        document.getElementById("txtConsignee_Address4").value = after15;
        document.getElementById("txt_SBNo").value = after16;
        document.getElementById("txt_SBDate").value = after17;
        document.getElementById("ddl_Nature_of_Cargo").value = after18;
        document.getElementById("txt_No_of_Packages").value = after19;
        document.getElementById("txt_Quantity").value = after20;
        document.getElementById("txt_Unit").value = after21;
//        document.getElementById("txt_RotationNo").value = after22;
        //        document.getElementById("txt_RotationDate").value = after23;

        document.getElementById("txt_IECNO").value = after24;
        document.getElementById("txt_BRSLNO").value = after25;
        document.getElementById("txt_Description").value = after26;


    }
    else {
        document.getElementById("txt_JobNo").value = "";
        document.getElementById("txt_Job_Date").value = "";
        document.getElementById("txt_Exporter_Name").value = "";
        document.getElementById("txt_ExporterAddress1").value = "";
        document.getElementById("txt_ExporterAddress2").value = "";
        document.getElementById("txt_ExporterAddress3").value = "";
        document.getElementById("txt_ExporterAddress4").value = "";
        document.getElementById("txt_GatewayPort").value = "";

        document.getElementById("txt_Port_of_Origin").value = "";
        document.getElementById("txt_Destination_Port").value = "";
        document.getElementById("txtConsignee").value = "";
        document.getElementById("txtConsignee_Address1").value = "";
        document.getElementById("txtConsignee_Address2").value = "";
        document.getElementById("txtConsignee_Address3").value = "";
        document.getElementById("txtConsignee_Address4").value = "";
        document.getElementById("txt_SBNo").value = "";
        document.getElementById("txt_SBDate").value = "";
        document.getElementById("ddl_Nature_of_Cargo").value = "";
        document.getElementById("txt_No_of_Packages").value = "";
        document.getElementById("txt_Quantity").value = "";
        document.getElementById("txt_Unit").value = "";
//        document.getElementById("txt_RotationNo").value = "";
        //        document.getElementById("txt_RotationDate").value = "";
        document.getElementById("txt_IECNO").value = "";
        document.getElementById("txt_BRSLNO").value = "";
        document.getElementById("txt_Description").value = "";
    }
}

function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}


function CallServerside_Get_Duplicate_Rotation_No(src, dest) {
    var ctrl = document.getElementById(src);
    var destl = document.getElementById(dest);
    PageMethods.Get_Duplicate_RotationNo(ctrl.value, dest, CallSuccess_Exp_DuplicateRotation_No, CallFailed, dest);
}

function CallSuccess_Exp_DuplicateRotation_No(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {
        var s = data.split('~~');
        var jobno = s[0];

        //        alert('Rotation No Already Exists! - JobNumber : ' + jobno);
        alert('Rotation No Already Exists!');
    }
    else {
    }
}

//----------------------------------------------------------------------------------------------------------------------------
function CallServerside_Vessel_IMo_code(src, dest) {
    var ctrl = document.getElementById(src).value;
    var ctrl1 = document.getElementById(dest).value;

    PageMethods.Get_Vessel_IMo_code(ctrl, ctrl1, CallSuccess_Vessel_IMo_code, CallFailed, dest);
}

function CallSuccess_Vessel_IMo_code(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;

    document.getElementById("txt_IMO_No").value = data;
}


//----------------------------------------------------------------------------------------------------------------------------
function CallServerside_Liner_code(src, dest) {
    var ctrl = document.getElementById(src).value;
    var ctrl1 = document.getElementById(dest).value;

    PageMethods.Get_Liner_emailID(ctrl, ctrl1, CallSuccess_Liner_emailID, CallFailed, dest);
}

function CallSuccess_Liner_emailID(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;

    document.getElementById("txt_eMailID").value = data;
}


//----------------------------------------------------------------------------------------------------------------------------

$(document).ready(function () {

    $('#btnUpdate,#btnSave').click(function () {

        var RotationNo = document.getElementById("txt_RotationNo").value;
        var RotationDate = document.getElementById("txt_RotationDate").value;
        var Voyage_No = document.getElementById("txt_Voyage_No").value;

        var JobNo = document.getElementById("txt_JobNo").value;
        var Job_Date = document.getElementById("txt_Job_Date").value;
        var SBNo = document.getElementById("txt_SBNo").value;
        var SBDate = document.getElementById("txt_SBDate").value;
        var Grosswgt = document.getElementById("txt_Quantity").value;
        var GatewayPort = document.getElementById("txt_GatewayPort").value;
        var Nature_of_Cargo = document.getElementById("ddl_Nature_of_Cargo").value;
        var Port_of_Origin = document.getElementById("txt_Port_of_Origin").value;
        var Packages = document.getElementById("txt_No_of_Packages").value;
        var Unit = document.getElementById("txt_Unit").value;

        if (RotationNo.length <= 0) {
            jAlert('RotationNo cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_RotationNo").focus(); });
            return false;
        }
        if (RotationDate.length <= 0) {
            jAlert('Rotation Date cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_RotationDate").focus(); });
            return false;
        }
        if (Voyage_No.length <= 0) {
            jAlert('Voyage_No cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_Voyage_No").focus(); });
            return false;
        }

        
        if (JobNo.length <= 0) {
            jAlert('JobNo cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_JobNo").focus(); });
            return false;
        }
        if (Job_Date.length <= 0) {
            jAlert('Job_Date cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_Job_Date").focus(); });
            return false;
        }
        if (SBNo.length <= 0) {
            jAlert('SB No cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("SBNo").focus(); });
            return false;
        }
        if (SBDate.length <= 0) {
            jAlert('SB Date cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_SBDate").focus(); });
            return false;
        }
        if (Grosswgt.length <= 0) {
            jAlert('Gross Wgt cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_Quantity").focus(); });
            return false;
        }
        if (GatewayPort.length <= 0) {
            jAlert('Gateway Port cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_GatewayPort").focus(); });
            return false;
        }
        if (Nature_of_Cargo.length <= 0) {
            jAlert('Nature_of_Cargo cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("ddl_Nature_of_Cargo").focus(); });
            return false;
        }
        if (Port_of_Origin.length <= 0) {
            jAlert('Port_of_Origin cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_Port_of_Origin").focus(); });
            return false;
        }
        if (Packages.length <= 0) {
            jAlert('No_of_Packages cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_No_of_Packages").focus(); });
            return false;
        }
        if (Unit.length <= 0) {
            jAlert('Unit cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_Unit").focus(); });
            return false;
        }

        var Exporter_Name = document.getElementById("txt_Exporter_Name").value;
        var Consignee = document.getElementById("txtConsignee").value;
        var ExporterAddress1 = document.getElementById("txt_ExporterAddress1").value;
        var Consignee_Address1 = document.getElementById("txtConsignee_Address1").value;


        if (Exporter_Name.length <= 0) {
            jAlert('Exporter_Name cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_Exporter_Name").focus(); });
            return false;
        }
        if (Consignee.length <= 0) {
            jAlert('Consignee cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txtConsignee").focus(); });
            return false;
        }
        if (ExporterAddress1.length <= 0) {
            jAlert('No_of_Packages cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txt_ExporterAddress1").focus(); });
            return false;
        }
        if (Consignee_Address1.length <= 0) {
            jAlert('Consignee_Address1 cannot be blank', 'EGM', function (r) { document.getElementById("IMD").click(); document.getElementById("txtConsignee_Address1").focus(); });
            return false;
        }
        
    });
});


//-------------------------------------------vessel-------------------------------
$(function () {

    $('#txt_VesselName').autocomplete({
        source: function (request, response) {
            var Vessel = "Vessel";

            $.ajax({

                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EGM_Vessel_Job_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + Vessel + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_Vessel_Name').validationEngine('showPrompt', 'Incorrect Vessel', 'error', 'topRight', true);

                        //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_Vessel_Name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//----------------------------------------------------------------------------------------------------

$(function () {

    $('#txt_Liner_Name').autocomplete({
        source: function (request, response) {
            var liner = "Liner";
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EGM_Liner_Job_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + liner + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_LinerName').validationEngine('showPrompt', 'Incorrect Liner', 'error', 'topRight', true);

                        //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_LinerName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   $(function () {

$('#txt_Rotation_No').autocomplete({
    source: function (request, response) {
 
            var rotation = "Rotation";
         

            $.ajax({


                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EGM_Rotation_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + rotation + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_Rotation_No').validationEngine('showPrompt', 'Incorrect Rotation', 'error', 'topRight', true);

                        //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_Rotation_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  $(function () {
      $('#txt_SB_No').autocomplete({
        source: function (request, response) {
      
            var Sb = "Sb";
         
            $.ajax({

                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EGM_Sbno_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + Sb + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_SB_No').validationEngine('showPrompt', 'Incorrect Sb', 'error', 'topRight', true);

                        //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_SB_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

 //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
     $(function () {
         $('#txt_Container_No').autocomplete({
             source: function (request, response) {
              
                 var Container = "Container";
                
                 $.ajax({

                     url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EGM_Container_Master_List",
                     data: "{ 'mail': '" + request.term + "' ,'IEC':'" + Container + "'}",
                     dataType: "json",
                     type: "POST",
                     contentType: "application/json; charset=utf-8",
                     dataFilter: function (data) { return data; },
                     async: true,
                     success: function (data) {
                         response(data.d);
                         if (data.d == '') {
                             jQuery('#txt_Container_No').validationEngine('showPrompt', 'Incorrect Container', 'error', 'topRight', true);

                             //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                             //return false;
                         }
                         else {
                             jQuery('#txt_Container_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
     $(function () {
         $('#txt_Jobno').autocomplete({
             source: function (request, response) {

                 var Job = "Job";

                 $.ajax({

                     url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EGM_Jobno_Master_List",
                     data: "{ 'mail': '" + request.term + "' ,'IEC':'" + Job + "'}",
                     dataType: "json",
                     type: "POST",
                     contentType: "application/json; charset=utf-8",
                     dataFilter: function (data) { return data; },
                     async: true,
                     success: function (data) {
                         response(data.d);
                         if (data.d == '') {
                             jQuery('#txt_Jobno').validationEngine('showPrompt', 'Incorrect Job', 'error', 'topRight', true);

                             //jAlert('Qty Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtQtyCode').focus(); });
                             //return false;
                         }
                         else {
                             jQuery('#txt_Jobno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
