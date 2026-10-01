function tab_page1(val) {

    document.getElementById('hdn_Inner_tab_Menu').value = 'ITEM_ID';
    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';

    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';


    document.getElementById("EXP_SW").className = 'inactive';
    document.getElementById("SW_Manufacture").className = 'inactive';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
    document.getElementById("Export_Item").style.display = 'Block';
    document.getElementById("OTHER_DETAILS_ID").className = 'inactive';
    document.getElementById("drawback").className = 'inactive';
    document.getElementById("jobbing").className = 'inactive';
    document.getElementById("EPCG").className = 'inactive';
    document.getElementById("DEEC").className = 'inactive';
    document.getElementById("DFIA").className = 'inactive';
    document.getElementById("Cess").className = 'inactive';
    document.getElementById("Quota").className = 'inactive';
    document.getElementById("SupDoc").className = 'inactive';

   
}

function tab_page2(val) {
    Parent_tab_count('');
    document.getElementById('hdn_Inner_tab_Menu').value = 'OTHER_DETAILS_ID';

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';

    
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
    document.getElementById("Export_Item").style.display = 'Block';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("EXP_SW").className = 'inactive';

   
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
    document.getElementById("page-8").style.display = 'none';


    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    var Qty = document.getElementById("txtItemQty").value;
    document.getElementById("pop_text_area_transac_item_drawback_iframe").src = "../Export/Export_Drawback.aspx?Qty=" + Qty + "";
    document.getElementById("Export_Item").style.display = 'Block';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("EXP_SW").className = 'inactive';

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
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    document.getElementById("pop_text_area_transac_item_Jobbing_iframe").src = "../Export/Export_Jobbing.aspx";
    document.getElementById("Export_Item").style.display = 'Block';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("EXP_SW").className = 'inactive';

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
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    //document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx?Scheme=" + hdn_Scheme.value + "&License_Scheme=EPCG";
    document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx?Scheme=" + document.getElementById("hdn_Scheme").value + "&License_Scheme=EPCG";
    document.getElementById("Export_Item").style.display = 'none';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("EXP_SW").className = 'inactive';
}
function tab_page6(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'Block';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';

    //document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx?Scheme=" + hdn_Scheme.value + "&License_Scheme=DEEC";
    document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx?Scheme=" + document.getElementById("hdn_Scheme").value + "&License_Scheme=DEEC";

    document.getElementById("Export_Item").style.display = 'none';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("EXP_SW").className = 'inactive';
}


function tab_page7(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'Block';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    //document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx?Scheme=" + hdn_Scheme.value + "&License_Scheme=EPCG";
    document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx?Scheme=" + document.getElementById("hdn_Scheme").value + "&License_Scheme=DFIA";
    document.getElementById("Export_Item").style.display = 'none';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("EXP_SW").className = 'inactive';
}


function tab_page8(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'Block';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    document.getElementById("pop_text_area_transac_item_cess_iframe").src = "../Export/Export_Cess_Details.aspx";
    document.getElementById("Export_Item").style.display = 'Block';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("EXP_SW").className = 'inactive';
}

function tab_page9(val) {
    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'Block';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    document.getElementById("txt_area_quto_details").src = "../Export/Export_Quota_Details.aspx";
    document.getElementById("Export_Item").style.display = 'Block';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("EXP_SW").className = 'inactive';
}

function tab_page10(val) {

    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'Block';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';


    document.getElementById("EXP_SW").className = 'active';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("ITEM_ID").className = 'inactive';
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    document.getElementById("Export_Single_Window").src = "../EXP_Single_Window/Item_SingleWindow_Entry_2016.aspx";
    document.getElementById("Export_Item").style.display = 'Block';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("OTHER_DETAILS_ID").className = 'inactive';
    document.getElementById("drawback").className = 'inactive';
    document.getElementById("jobbing").className = 'inactive';
    document.getElementById("EPCG").className = 'inactive';
    document.getElementById("DEEC").className = 'inactive';
    document.getElementById("DFIA").className = 'inactive';
    document.getElementById("Cess").className = 'inactive';
    document.getElementById("Quota").className = 'inactive';
    document.getElementById("SupDoc").className = 'inactive';
}

function tab_page11(val) {

    Parent_tab_count('');
    document.getElementById('hdn_Inner_tab_Menu').value = 'SW_Manufacture';

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'Block';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
   

    document.getElementById("SW_Manufacture").className = 'active';
    document.getElementById("EXP_SW").className = 'inactive';
    document.getElementById("ITEM_ID").className = 'inactive';
    document.getElementById("OTHER_DETAILS_ID").className = 'inactive';
    document.getElementById("drawback").className = 'inactive';
    document.getElementById("jobbing").className = 'inactive';
    document.getElementById("EPCG").className = 'inactive';
    document.getElementById("DEEC").className = 'inactive';
    document.getElementById("DFIA").className = 'inactive';
    document.getElementById("Cess").className = 'inactive';
    document.getElementById("Quota").className = 'inactive';
    document.getElementById("EXP_SW").className = 'inactive';
    document.getElementById("SW_Manufacture").className = 'active';
    document.getElementById("SupDoc").className = 'inactive';

    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';
    document.getElementById("Export_Item").style.display = 'Block';

   }

function tab_page12(val) {

    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'Block';
    document.getElementById("page-13").style.display = 'none';


    document.getElementById("EXP_SW").className = 'active';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("ITEM_ID").className = 'inactive';
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    document.getElementById("Re_Export").src = "../Export/ReExport_Details.aspx";
    document.getElementById("Export_Item").style.display = 'Block';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("OTHER_DETAILS_ID").className = 'inactive';
    document.getElementById("drawback").className = 'inactive';
    document.getElementById("jobbing").className = 'inactive';
    document.getElementById("EPCG").className = 'inactive';
    document.getElementById("DEEC").className = 'inactive';
    document.getElementById("DFIA").className = 'inactive';
    document.getElementById("Cess").className = 'inactive';
    document.getElementById("Quota").className = 'inactive';
    document.getElementById("SupDoc").className = 'inactive';
}

function tab_page13(val) {

    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'Block';
    
    document.getElementById("EXP_SW").className = 'active';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("ITEM_ID").className = 'inactive';
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
    //    document.getElementById("Export_Single_Window").src = "../EXP_Single_Window/Item_SingleWindow_Entry_2016.aspx";
    document.getElementById("Export_SW_Supdocs").src = "../EXP_Single_Window/Supportingdoc.aspx";
    document.getElementById("Export_Item").style.display = 'inactive';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("OTHER_DETAILS_ID").className = 'inactive';
    document.getElementById("drawback").className = 'inactive';
    document.getElementById("jobbing").className = 'inactive';
    document.getElementById("EPCG").className = 'inactive';
    document.getElementById("DEEC").className = 'inactive';
    document.getElementById("DFIA").className = 'inactive';
    document.getElementById("Cess").className = 'inactive';
    document.getElementById("Quota").className = 'inactive';
    document.getElementById("SupDoc").className = 'Block';
    
}


function tab_page14(val) {

    Parent_tab_count('');

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'Block';


    document.getElementById("EXP_SW").className = 'inactive';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("ITEM_ID").className = 'inactive';
    document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';

    document.getElementById("DTA_Sez").src = "../Export_DTA_SEZ/Export_DTA_Items.aspx";
    document.getElementById("Export_Item").style.display = 'inactive';
    document.getElementById("SW_Manufacture").className = 'inactive';
    document.getElementById("OTHER_DETAILS_ID").className = 'inactive';
    document.getElementById("drawback").className = 'inactive';
    document.getElementById("jobbing").className = 'inactive';
    document.getElementById("EPCG").className = 'inactive';
    document.getElementById("DEEC").className = 'inactive';
    document.getElementById("DFIA").className = 'inactive';
    document.getElementById("Cess").className = 'inactive';
    document.getElementById("Quota").className = 'inactive';
    document.getElementById("SupDoc").className = 'inactive';
    document.getElementById("DTA").className = 'active';


}



$(function () {
    $('#spanepcg').click(function () {

        var t = $(this).text();
        //alert(t);
        document.getElementById("hdn_Scheme").value = t;
        //hdn_Scheme.val(t);
    });

    $('#spandeec').click(function () {

        var t = $(this).text();
        //            alert(t);
        //            hdn_Scheme.val(t);
        document.getElementById("hdn_Scheme").value = t;

    });


    $('#spandfia').click(function () {

        var t = $(this).text();
        //                alert(t);
        //                hdn_Scheme.val(t);
        document.getElementById("hdn_Scheme").value = t;

    });

    //--------------------------- BIND UQC FOR RITC ----------------
    $('#txtRITCNo').bind('keyup keypress change keydown ', function () {

        var t = document.getElementById("txtRITCNo").value;
        document.getElementById("txtSTRCode").value = t.substring(0, 2);
        PageMethods.Get_RITC_Info_Uqc(document.getElementById("txtRITCNo").value, OnSuccess_Info_Uqc);
    });

    function OnSuccess_Info_Uqc(response, userContext, methodName) {

        //Ringo Cargo
        if (document.getElementById("hdn_companyID").value == "10" || document.getElementById("hdn_companyID").value == "1572") {
            if (document.getElementById("txtRITCNo").value.length == 8) {
                $('#txtQtyCode').val(response);
                
            }
        }

        $('#txt_InfoUQC').val(response);
        if (document.getElementById("txtQtyCode").value == document.getElementById("txt_InfoUQC").value) {
            $('#txt_InfoMSR').val(document.getElementById("txtItemQty").value);
            $('#hdn_Chk_InfoUQC').val('valid');
        }
        else {
            //$('#txt_InfoMSR').val('');
        }
    }

    //------------------------------BIND INFO MSR AS ITEM QTY-FOR same QtyCode & InfoUQC------------------

    $('#txtQtyCode,#txtItemQty').bind('keyup keypress change keydown', function () {
        if (document.getElementById("txtQtyCode").value == document.getElementById("txt_InfoUQC").value) {
            $('#txt_InfoMSR').val(document.getElementById("txtItemQty").value);
        }
    });



    //--------------------------- CHECK MISMATCHED RITC----------------
    $('#txt_InfoUQC').bind('keyup keypress change keydown focus', function () {
        PageMethods.Get_RITC_Info_Uqc(document.getElementById("txtRITCNo").value, OnSuccess_Info_Uqc_check);
    });

    function OnSuccess_Info_Uqc_check(response) {
        if (response != $('#txt_InfoUQC').val()) {
            $('#hdn_Chk_InfoUQC').val('');
        }
        else {
            $('#hdn_Chk_InfoUQC').val('valid');
        }
    }

    //--------------------------- CHECK MISMATCHED STATE----------------
    $('#txt_StateOrigin').bind('keyup keypress change keydown', function () {
        PageMethods.Get_StateCode_Name_Mismatch(document.getElementById("txt_StateOrigin").value, OnSuccess_state_check);
    });

    function OnSuccess_state_check(response) {
        if (response != $('#txt_StateOrigin').val()) {
            $('#hdn_Chk_State').val('');
        }
        else {
            $('#hdn_Chk_State').val('valid');
        }
    }

    //--------------------------- CHECK MISMATCHED DISTRICT----------------
    $('#txt_DistrictOrigin').bind('keyup keypress change keydown', function () {

        PageMethods.Get_DistrictName(document.getElementById("txt_DistrictOrigin").value, document.getElementById("txt_StateOrigin").value, OnSuccess_Dsitrict_check);
    });

    function OnSuccess_Dsitrict_check(response) {

        if (response.toUpperCase() != $('#txt_DistrictOrigin').val().toUpperCase()) {
            $('#hdn_Chk_District').val('');
        }
        else {
            $('#hdn_Chk_District').val('valid');
        }
    }
    //---------------------------- DISTRICT - END---------------------------


});




//        function tab_page6(val) {

//            document.getElementById("page-1").style.display = 'none';
//            document.getElementById("page-2").style.display = 'none';
//            document.getElementById("page-3").style.display = 'none';
//            document.getElementById("page-4").style.display = 'none';
//            document.getElementById("page-5").style.display = 'Block';
//            document.getElementById("page-6").style.display = 'none';
//            document.getElementById("page-7").style.display = 'none';
//            document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';

//            document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx";


//        }

//        function tab_page7(val) {

//            document.getElementById("page-1").style.display = 'none';
//            document.getElementById("page-2").style.display = 'none';
//            document.getElementById("page-3").style.display = 'none';
//            document.getElementById("page-4").style.display = 'none';
//            document.getElementById("page-5").style.display = 'Block';
//            document.getElementById("page-6").style.display = 'none';
//            document.getElementById("page-7").style.display = 'none';
//            document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';

//            document.getElementById("pop_text_area_transac_item_licence_iframe_new1").src = "../Export/Export_License_Details.aspx";


//        }
//                $('#txtInvoiceValue').change(function () {

//                    var hdn_Invoice_Exrate = $('#txtFreight_Rate");

//                    var txtInvoiceValue = $('#lblInvoiceValue');
//                    var txtItemQty = $('#txtItemQty');
//                    var Result = $('#txtPMVValue');

//                    var txtExRate = $('#hdn_Invoice_Exrate');
//                    var Exrate = txtExRate.val();
//                    var Result1, Result2;
//                    Result1 = ((parseFloat(txtInvoiceValue.text()) * 110) * parseFloat(Exrate.val())) / parseFloat(txtItemQty.val());
//                    Result.val(Result1);
//                  

//                });

function validate_Export_Item(Save_Update) {
    //if (Page_ClientValidate()) // this will trigger validator
    //{

    //------------------------ While Item Copy - Item slno mismatch issue by Chithra on 25-09-2023----------------------------
    if (Save_Update == 'Update') {
        var ddl_ItemSlno1;
        ddl_ItemSlno1 = document.getElementById("ddl_ItemSlno").value;

        var lbl_Item_Slno1;
        lbl_Item_Slno1 = document.getElementById("lbl_Item_Slno").innerText;

        if (ddl_ItemSlno1 != lbl_Item_Slno1) {

            jAlert('Select Item in Grid', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtDescription").focus(); });
            return false;
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------



    var txtDescription;
    txtDescription = document.getElementById("txtDescription").value;

    if (txtDescription.length <= 0) {
        jAlert('Description cannot be blank', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtDescription").focus(); });

        return false;
    }
    var txtRITCNo;
    txtRITCNo = document.getElementById("txtRITCNo").value;

    if (txtRITCNo.length <= 0) {
        jAlert('RITC No cannot be blank', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtRITCNo").focus(); });

        return false;
    }
    var highseaIEC_NO;
    highseaIEC_NO = document.getElementById("txtRITCNo").value;
    if (highseaIEC_NO.length < 8) {
        jAlert('RITCNo Should be 8 digit', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtRITCNo").focus(); });

        return false;
    }
    var txtItemQty;
    txtItemQty = document.getElementById("txtItemQty").value;

    if (txtItemQty.length <= 0) {
        jAlert('ItemQty cannot be blank', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtItemQty").focus(); });

        return false;
    }
    var txtQtyCode;
    txtQtyCode = document.getElementById("txtQtyCode").value;

    if (txtQtyCode.length <= 0) {
        jAlert('QtyCode cannot be blank', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtQtyCode").focus(); });

        return false;
    }
    //    if (txtQtyCode.length < 3) {
    //        jAlert('QtyCode Should be 3 characters', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtQtyCode").focus(); });

    //        return false;
    //    }
    var txtItem_UnitPrice;
    txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;

    if (txtItem_UnitPrice.length <= 0) {
        jAlert('UnitPrice cannot be blank', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtItem_UnitPrice").focus(); });

        return false;
    }
    var txtPer;
    txtPer = document.getElementById("txtPer").value;

    if (txtPer.length <= 0) {
        jAlert('Per cannot be blank', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtPer").focus(); });

        return false;
    }
    var txtItem_Amount;
    txtItem_Amount = document.getElementById("txtItem_Amount").value;

    if (txtItem_Amount.length <= 0) {
        jAlert('Item_Amount cannot be blank', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtItem_Amount").focus(); });

        return false;
    }


    //------------------------------------------- END USE OF ITEM -----------------------------------------------
    var EnduseItem = document.getElementById("txtEnduseItem").value;

    if (EnduseItem == '') {
        document.getElementById("ITEM_ID").className = 'inactive';
        document.getElementById("OTHER_DETAILS_ID").className = 'active';

        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'Block';
        //                          $("#txtEnduseItem").focus();
        jAlert('EndUse of Item - Should not be Empty', 'ITEM - SW', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txtEnduseItem").focus(); });
        return false;
    }

    //-------------------------PMV.Per Unit------------------------------------------------
    var PMV_method = document.getElementById("ddl_PMV_method").value;

    if (PMV_method == 'PerUnit') {
        if (document.getElementById("txt_PMV_PerUnit").value == '') {
            jAlert('PMV.Per Unit - Should not be Empty', 'ITEM - PMV', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txt_PMV_PerUnit").focus(); });
            return false;
        }
    }

    //-------------------------IGST------------------------------------------------
    var IGST_Payment = document.getElementById("ddl_IGST_Payment").value;
    if (IGST_Payment == 'NA' || IGST_Payment == 'LUT') {
        document.getElementById("ITEM_ID").className = 'active';
        document.getElementById("OTHER_DETAILS_ID").className = 'inactive';

        document.getElementById("page-1").style.display = 'Block';
        document.getElementById("page-2").style.display = 'none';
    }

    if (IGST_Payment == 'P') {
        if (document.getElementById("txt_TaxableValue").value == '') {
            document.getElementById("ITEM_ID").className = 'inactive';
            document.getElementById("OTHER_DETAILS_ID").className = 'active';

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'Block';
            $("#txt_TaxableValue").focus();
        }
        if (document.getElementById("txt_IGST_Amt").value == '') {
            document.getElementById("ITEM_ID").className = 'inactive';
            document.getElementById("OTHER_DETAILS_ID").className = 'active';

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'Block';
            $("#txt_IGST_Rate").focus();
        }
    }

    //------------------------------------------- Third Party - GSTN -----------------------------------------------

    var ExpName = document.getElementById("txtExporterName").value;
    var GSTN_TYPE = document.getElementById("ddl_GSTN_Type").value;
    var GSTNID = document.getElementById("txt_GSTN_ID").value;

    if (ExpName.length != 0) {

        if (GSTNID.length == 0) {
            jAlert('Third Party - GSTN ID Should not be Empty', 'THIRD PARTY DETAILS', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txt_GSTN_ID").focus(); });
            return false;
        }
        if (GSTN_TYPE.length == 0) {
            jAlert('Third Party - GSTN Type Should not be Empty', 'THIRD PARTY DETAILS', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("ddl_GSTN_Type").focus(); });
            return false;
        }
    }

    //------------------------------------------- EXPORT SINGLE WINDOW VALIDATION -----------------------------------------------
    if (document.getElementById("txt_InfoMSR").value == '') {
        jAlert('Info MSR - Should not be Empty', 'ITEM - SW', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txt_InfoMSR").focus(); });
        return false;
    }

    if (document.getElementById("txt_InfoUQC").value == '') {
        jAlert('Info UQC - Should not be Empty', 'ITEM - SW', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txt_InfoUQC").focus(); });
        return false;
    }

    if (document.getElementById("txt_StateOrigin").value == '') {
        jAlert('State of Origin - Should not be Empty', 'ITEM - SW', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txt_StateOrigin").focus(); });
        return false;
    }

    if (document.getElementById("txt_DistrictOrigin").value == '') {
        jAlert('District of Origin - Should not be Empty', 'ITEM - SW', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txt_DistrictOrigin").focus(); });
        return false;
    }
    //-----------------------------------------------------------------------------------------------------------------------------------

    if (document.getElementById("hdn_Chk_InfoUQC").value == '') {
        jAlert('Invalid - INFO UQC', 'ITEM - SW', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txt_InfoUQC").focus(); });
        return false;
    }

    if (document.getElementById("hdn_Chk_State").value == '') {
        jAlert('Invalid - State Of Origin', 'ITEM - SW', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txt_StateOrigin").focus(); });
        return false;
    }

    if (document.getElementById("hdn_Chk_District").value == '') {
        jAlert('Invalid - District Of Origin', 'ITEM - SW', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txt_DistrictOrigin").focus(); });
        return false;
    }

    //-----------------------------------------------------------------------------------------------------------------------------------


    var txtSTRCode;
    txtSTRCode = document.getElementById("txtSTRCode").value;
    ddl_STR_YN = document.getElementById("ddl_STR_YN").value;
    if (ddl_STR_YN == 'Yes') {
        if (txtSTRCode.length <= 0) {
            jAlert('STR Code cannot be blank', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("txtSTRCode").focus(); });

            return false;
        }
    }
    var txtAR4Date = document.getElementById("txtAR4Date").value;
    if (txtAR4Date != "") {
        if (isDate(txtAR4Date)) {

        }
        else {
            jAlert('AR4Date is Invalid Date', 'ITEM', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txtAR4Date").focus(); });

            return false;
        }
    }


    var SchemeCode = '', ddl_Rodtep = '';
    SchemeCode = document.getElementById("ddlSchemeCode").value;
    ddl_Rodtep = document.getElementById("ddl_Rodtep_YN").value;
   
    if (SchemeCode == '99-NFEI' || SchemeCode == '98-FREE SHIPPING BILL INVOLVING INDIAN CURRENCY') {
        if (ddl_Rodtep=='Y') {
            jAlert('Invalid RODTEP - check Scheme Code', 'ITEM', function (r) { document.getElementById("ITEM_ID").click(); document.getElementById("ddl_Rodtep_YN").focus(); });

            return false;
        }
    }

    var txtIECCode;
    txtIECCode = document.getElementById("txtIECCode").value;

    if (txtIECCode != "") {
        if (txtIECCode.length < 10) {
            jAlert('IEC Code Should be 10 digit', 'ITEM', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txtIECCode").focus(); });

            return false;
        }
        var txtBranchSLNo;
        txtBranchSLNo = document.getElementById("txtBranchSLNo").value;

        if (txtBranchSLNo.length <= 0) {
            jAlert('BranchSLNo cannot be blank', 'ITEM', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txtBranchSLNo").focus(); });

            return false;
        }
        var txtAddress;
        txtAddress = document.getElementById("txtAddress").value;

        if (txtAddress.length <= 0) {
            jAlert('Address cannot be blank', 'ITEM', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txtAddress").focus(); });

            return false;
        }
        var txtAddress4;
        txtAddress4 = document.getElementById("txtAddress4").value;
        if (txtAddress3 != "") {
            if (txtAddress3.length < 6) {
                jAlert('Pincode Should be 6 digit', 'ITEM', function (r) { document.getElementById("OTHER_DETAILS_ID").click(); document.getElementById("txtAddress4").focus(); });

                return false;
            }
        }
    }
}


function opennew_STR_DETAILS() {
    var txtSTRCode = document.getElementById("txtRITCNo").value;
    var RITCNO = txtSTRCode.substring(0, 2);
    //alert(RITCNO);
    if (RITCNO != '') {
        if (RITCNO.length == 2) {

            Opennew_STR_Details(RITCNO);
            return false
        }
    }
}

function OpenPopupImporter_Master(val) {


    if (val == 'EXPORT_ITEM_IECNO') {


        OpenPopupImporterDetails(val);
        return false

    }

    else if (val == '') {
        OpenPopupImporterDetails(val);
        return false
    }

}

function OpenPopupExporter_Master_BranchSlno(val1) {


    var val = document.getElementById("txtIECCode").value;
    val = val.replace(/\s+$/g, '');
    if (val != '' && val.length == 10) {

        OpenPopupImporterDetails_New(val, val1);
    }


}
$(function () {

    var ddl_STR_YN = $('#ddl_STR_YN');

    ddl_STR_YN.change(function (e) {
        var selectedValue = $(this).val();
        if (selectedValue == 'Yes') {

            document.getElementById("div_STR_YN").style.display = 'Block';
        }
        else if (selectedValue == 'No') {

            document.getElementById("div_STR_YN").style.display = 'none';
        }
    });
});

$(function () {
    $('#txtExporterName').autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("txtIECCode").value + "'}",
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
    $('#txtBranchSLNo').autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("txtIECCode").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtBranchSLNo').validationEngine('showPrompt', 'Incorrect Branch SLNo', 'error', 'topRight', true);

                        //jAlert('Branch SLNo is Incorrect', 'ITEM', function (r) { document.getElementById("txtBranchSLNo').focus(); });
                        // return false;
                    }
                    else {
                        jQuery('#txtBranchSLNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

            $('#txtDescription').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exp_Item_Desc_List",

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

                                //jAlert('Branch SLNo is Incorrect', 'ITEM', function (r) { document.getElementById("txtBranchSLNo').focus(); });
                                // return false;
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
    $('#txtIECCode').autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_IECCode_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':''}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtIECCode').validationEngine('showPrompt', 'Incorrect IEC Code', 'error', 'topRight', true);

                        //jAlert('IEC Code is Incorrect', 'ITEM', function (r) { document.getElementById("txtIECCode').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtIECCode').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//$(function () {
//    $('#txtRITCNo').autocomplete({
//        source: function (request, response) {
//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXPORT_RITC_MASTER_List",

//                data: "{ 'mail': '" + request.term + "' }",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {
//                    response(data.d);
//                    if (data.d == '') {
//                        jQuery('#txtRITCNo').validationEngine('showPrompt', 'Incorrect RITCNo', 'error', 'topRight', true);

//                        //jAlert('RITCNo is Incorrect', 'ITEM', function (r) { document.getElementById("txtRITCNo').focus(); });
//                        //return false;
//                    }
//                    else {
//                        jQuery('#txtRITCNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
//                    }
//                },
//                error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    //////alert(textStatus);
//                }
//            });
//        },
//        minLength: 1

//    });
//    return false;
//    scroll: true;
//});



// ✅ SAFEST — Only fetch on autocomplete select
// Remove blur entirely to avoid ALL conflicts

$(function () {
    $('#txtRITCNo').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXPORT_RITC_MASTER_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtRITCNo').validationEngine('showPrompt',
                            'Incorrect RITCNo', 'error', 'topRight', true);
                    } else {
                        jQuery('#txtRITCNo').validationEngine('hidePrompt',
                            '', 'error', 'topRight', true);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        },
        minLength: 1,

        // ✅ Only on dropdown select — NO blur event
        select: function (event, ui) {
            $('#txtRITCNo').val(ui.item.value);
            FetchAndShowRITCPolicy(ui.item.value);
            return false;
        }
    });

    return false;
    scroll: true;
});


function FetchAndShowRITCPolicy(ritcCode) {
    if (!ritcCode || ritcCode.trim().length < 8) return;

    $.ajax({
        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GetRITCPolicyByCode",
        data: "{ 'ritcCode': '" + ritcCode.trim() + "' }",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataFilter: function (data) { return data; },
        async: true,
        success: function (data) {
            var policy = (data.d && data.d !== '') ? data.d : 'No Policy';
            SetRITCPolicy(policy);
        },
        error: function () {
            SetRITCPolicy('No Policy');
        }
    });
}


$(function () {
    $("#txtEnduseItem").autocomplete({
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
                        jQuery('#txtEnduseItem').validationEngine('showPrompt', 'Incorrect EndUse Code', 'error', 'topRight', true);

                    }
                    else {
                        jQuery('#txtEnduseItem').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


//      $(document).ready(function () {

//          $('#txtEnduseItem').focus(function () {
//              
//              var data = $(this).val();
//              Enduse_Code(data);

//          });
//          $('#txtEnduseItem').change(function () {
//              
//              var data = $(this).val();
//              Enduse_Code(data);

//          });
//          $('#txtEnduseItem').keyup(function () {
//              
//              var data = $(this).val();
//              Enduse_Code(data);

//          });
//          $('#txtEnduseItem').keydown(function () {
//              
//              var data = $(this).val();
//              Enduse_Code(data);

//          });

//      });

//      function Enduse_Code(val) {

//          var data = val;
//          if (data == '') {
//              $('#txtEnduseItem').val('');
//          }
//          if (data.indexOf("--") != -1) {

//              var s = data.split('--');
//              var before = s[0];
//              var after = s[1];
//              $('#txtEnduseItem').val(before);
//          }
//          else {

//          }
//      }

$(function () {
    $('#txtQtyCode').autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                //url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_List",
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
                            jQuery('#txtQtyCode').validationEngine('showPrompt', 'Incorrect Qty Code', 'error', 'topRight', true);
                        }

                    }
                    else {
                        jQuery('#txtQtyCode').validationEngine('hidePrompt', '', 'error', 'topRight', true);


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
    $('#txt_InfoUQC').autocomplete({
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
                        if (field == 'txt_InfoUQC') {
                            jQuery('#txt_InfoUQC').validationEngine('showPrompt', 'Incorrect Info UQC', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#txt_InfoUQC').validationEngine('hidePrompt', '', 'error', 'topRight', true);


                        var result = data.d;

                        var stringsearch = "-", str = result;

                        for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                        if (i == 1) {
                            if (field == 'txt_InfoUQC') {
                                $('#txt_InfoUQC').val(result);
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

// call server side method
// call server side method
function CallServerside_RITC(src, dest) {
    var ctrl = document.getElementById(src);
   
        PageMethods.Get_RITC(ctrl.value, CallSuccess_RITCNO, CallFailed, dest);
  
}
function CallSuccess_RITCNO(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

    var data = res;

    document.getElementById("txtRITCNo").value = data;

}

//--------------------- call STR_Code From RITC ----------------------//
function CallServerside_RITC_STR(src, dest) {
    var ctrl = document.getElementById(src);  
    PageMethods.Get_STR_Code(ctrl.value, CallSuccess_RITC_STRCODE, CallFailed, dest);  
}
function CallSuccess_RITC_STRCODE(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;

    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');
       
        var before = s[0];
        var after1 = s[1];
        
        document.getElementById("txtSTRCode").value = before;
        document.getElementById("ddl_Rodtep_YN").value = after1;
    }
}

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
        var after9 = s[9];
        var after10 = s[10];
       
        document.getElementById("txtAddress").value = before;
        document.getElementById("txtAddress1").value = after1;
        document.getElementById("txtAddress2").value = after2;
        document.getElementById("txtAddress3").value = after3;
        document.getElementById("txtAddress4").value = after4;
        document.getElementById("txtIECCode").value = after5;
        document.getElementById("txtBranchSLNo").value = after6;

        document.getElementById("ddl_GSTN_Type").value = after9;
        document.getElementById("txt_GSTN_ID").value = after10;

    }
    else {
        document.getElementById("txtAddress").value = "";
        document.getElementById("txtAddress1").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
        document.getElementById("txtIECCode").value = "";
        document.getElementById("txtBranchSLNo").value = "";
        document.getElementById("ddl_GSTN_Type").value = "";
        document.getElementById("txt_GSTN_ID").value = "";
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

        document.getElementById("txtAddress").value = before;
        document.getElementById("txtAddress1").value = after1;
        document.getElementById("txtAddress2").value = after2;
        document.getElementById("txtAddress3").value = after3;
        document.getElementById("txtAddress4").value = after4;
        //document.getElementById("txtIECCode").value = after5;
        //document.getElementById("txtBranchSLNo").value = after6;



    }
    else {
        document.getElementById("txtAddress").value = "";
        document.getElementById("txtAddress1").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
        //document.getElementById("txtIECCode").value = "";
        //document.getElementById("txtBranchSLNo").value = "";
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
        ieccode = document.getElementById("txtIECCode").value;

        if (ieccode.length < 10) {
            jQuery('#txtIECCode').validationEngine('showPrompt', 'IEC code  Should be 10 digit numbers', 'error', 'topRight', true);

            //jAlert('IEC code  Should be 10 digit numbers', 'ITEM', function (r) { document.getElementById("txtIECCode").focus(); });

            // return false;
        }

        else {
            jQuery('#txtIECCode').validationEngine('hidePrompt', '', 'error', 'topRight', true);

            PageMethods.GetImporter_Branchwise(ctrl, ctrl1, CallSuccess_Importer_BranchWise, CallFailed, dest);

        }
    }

}

function CallServerside_GetItemQty(src, dest) {
    ShowImage(src);
    var e;
    var ctrl = document.getElementById(src);
    // call server side method
    var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, txtItem_UnitPrice, lblInvoiceValue, hdn_Invoice_Exrate;
    hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
    txtItem_Amount = document.getElementById("txtItem_Amount").value;
    hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
    e = document.getElementById("ddlInv_SL_No");
    ddlInv_SL_No = e.options[e.selectedIndex].text;
    HiddenField1 = document.getElementById("HiddenField1").value;
    txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;
    lblInvoiceValue = document.getElementById("lblInvoiceValue").innerHTML;
    hdn_Invoice_Exrate = document.getElementById("hdn_Invoice_Exrate").value;

    PageMethods.Get_Item_Qty(ctrl.value, hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, txtItem_UnitPrice, lblInvoiceValue, hdn_Invoice_Exrate, CallSuccess_ItemQty, CallFailed, dest);

}
function CallSuccess_ItemQty(res, destCtrl) {
    HideImage('txtItemQty');

    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];

        if (after2 != '') {
            document.getElementById("txtItem_Amount").value = before;
            document.getElementById("txtItem_UnitPrice").value = after1;
            document.getElementById("txtPMVValue").value = after3
        }
        else {
            //                     jAlert('Enter Qty', 'ITEM', function (r) {

            //                         document.getElementById("txtItemQty").focus();
            //                     });

        }
        document.getElementById("txtItemQty").focus();
        if (after2 == '') {
            document.getElementById("txtItem_Amount").value = '';
            document.getElementById("txtItem_UnitPrice").value = '';
            document.getElementById("txtItemQty").focus();
            document.getElementById("txtPMVValue").value = '';
        }
    }
    else {

        document.getElementById("txtItem_Amount").value = '';
        document.getElementById("txtItem_UnitPrice").value = '';
        document.getElementById("txtPMVValue").value = '';

        document.getElementById("txtItemQty").focus();

    }
}
function CallServerside_GetItem_UnitPrice(src, dest) {
    ShowImage(src);
    var e;
    var ctrl = document.getElementById(src);
    // call server side method
    var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, txtItemQty, hdn_Invoice_Exrate, lblInvoiceValue;
    hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
    txtItem_Amount = document.getElementById("txtItem_Amount").value;
    hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
    //ddlInv_SL_No = document.getElementById("ddlInv_SL_No").value;
    e = document.getElementById("ddlInv_SL_No");
    ddlInv_SL_No = e.options[e.selectedIndex].text;
    HiddenField1 = document.getElementById("HiddenField1").value;
    txtItemQty = document.getElementById("txtItemQty").value;
    hdn_Invoice_Exrate = document.getElementById("hdn_Invoice_Exrate").value;
    lblInvoiceValue = document.getElementById("lblInvoiceValue").innerHTML;
    PageMethods.Get_Item_UnitPrice(ctrl.value, hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, lblInvoiceValue, txtItemQty, hdn_Invoice_Exrate, CallSuccess_ItemUnitprice, CallFailed, dest);

}
function CallServerside_GetItem_amount(src, dest) {
    ShowImage('txtItem_Amount');
    var e;
    var ctrl = document.getElementById(src);
    // call server side method
    var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, txtItemQty, hdn_Invoice_Exrate, lblInvoiceValue, txtPer;
    hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
    txtItem_Amount = document.getElementById("txtItem_Amount").value;
    hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
    //ddlInv_SL_No = document.getElementById("ddlInv_SL_No").value;
    e = document.getElementById("ddlInv_SL_No");
    ddlInv_SL_No = e.options[e.selectedIndex].text;
    HiddenField1 = document.getElementById("HiddenField1").value;
    txtItemQty = document.getElementById("txtItemQty").value;

    txtPer = document.getElementById("txtPer").value;

    hdn_Invoice_Exrate = document.getElementById("hdn_Invoice_Exrate").value;
    lblInvoiceValue = document.getElementById("lblInvoiceValue").innerHTML;
    PageMethods.Get_Item_amount(ctrl.value, hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, lblInvoiceValue, txtItemQty, hdn_Invoice_Exrate, txtPer, CallSuccess_Itemamount, CallFailed, dest);

}

//-------------Item Per Calculation on 25Sep2015--------------//

//function CallServerside_GetPer_amount(src, dest) {
//    ShowImage('txtItem_Amount');
//    var e;
//    var ctrl = document.getElementById(src);
//    // call server side method
//    var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, txtPer, hdn_Invoice_Exrate, lblInvoiceValue;
//    hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
//    txtItem_Amount = document.getElementById("txtItem_Amount").value;
//    hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
//    //ddlInv_SL_No = document.getElementById("ddlInv_SL_No").value;
//    e = document.getElementById("ddlInv_SL_No");
//    ddlInv_SL_No = e.options[e.selectedIndex].text;
//    HiddenField1 = document.getElementById("HiddenField1").value;
//    txtPer = document.getElementById("txtPer").value;
//    hdn_Invoice_Exrate = document.getElementById("hdn_Invoice_Exrate").value;
//    lblInvoiceValue = document.getElementById("lblInvoiceValue").innerHTML;
//    PageMethods.Get_Per_amount(ctrl.value, hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInv_SL_No, HiddenField1, lblInvoiceValue, txtPer, hdn_Invoice_Exrate, CallSuccess_Itemamount, CallFailed, dest);

//}

//-------------Item Per Calculation on 25Sep2015--------------//

function GetPer_Item_amount() {

    var item_unit = document.getElementById("txtItem_UnitPrice").value;
    var item_qty = document.getElementById("txtItemQty").value;

    var item_amt = document.getElementById("txtItem_Amount").value;
    var item_per = document.getElementById("txtPer").value;
    var companyID = $('#hdn_companyID').val();

    var Result, Result1;

  

    if (item_unit != '' || item_qty != '') {

        if (item_unit == '' || item_qty == '') {
            Result = '0';
        }
        else {
            Result = (parseFloat(item_unit) * parseFloat(item_qty));
            // Result = Math.round(Result).toFixed(2);
            Result = Result.toFixed(5);
            // document.getElementById("item_amt").value = Result;
        }
    }


    if (Result != '') {
        if (item_per != '') {

            if (Result == undefined) {
                Result1 = '0';
            }
            else {
                Result1 = (parseFloat(Result) / parseInt(item_per));
            }

            if (companyID == '1' || companyID == '10' || companyID == '2226') {//Rosemount - Checked with final print on 29-01-2024 sugg.by Bala sir
                Result1 = Result1.toFixed(2);
            }
            else {
                Result1 = Result1.toFixed(5);
            }
            document.getElementById("txtItem_Amount").value = Result1;
           
        }
    }
}
//-------------Item Per Calculation on 25Sep2015--------------//




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
        var after4 = s[4];

        document.getElementById("txtItem_Amount").value = after1;
        document.getElementById("txtPMVValue").value = after4;
        if (before == '') {
            //                     jAlert('Enter UnitPrice', 'ITEM', function (r) {

            //                         document.getElementById("txtItem_UnitPrice").focus();
            //                     });

        }
        else if (after2 == '') {
            jQuery('#txtItemQty').validationEngine('showPrompt', 'Enter Qty', 'error', 'topRight', true);

            //jAlert('Enter Qty', 'ITEM', function (r) {

            document.getElementById("txtItemQty").focus();
            // });

        }
        else if (after3 == '2') {
            var hdn_Grid_Count = document.getElementById("hdn_Grid_Count").value;

            if (hdn_Grid_Count != '') {
                jQuery('#txtItem_UnitPrice').validationEngine('showPrompt', 'Higher than invoice value', 'error', 'topRight', true);

                //jAlert('Higher than invoice value', 'ITEM', function (r) {

                document.getElementById("txtItem_UnitPrice").focus();
                //});
            }
        }
    }
}


function CallSuccess_Itemamount(res, destCtrl) {
    HideImage('txtItem_Amount');

    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;alert(data);
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];

        document.getElementById("txtItem_Amount").value = after1;
        document.getElementById("txtPMVValue").value = after4;
        document.getElementById("txtItem_UnitPrice").value = before;
        if (before == '') {
            //                     jAlert('Enter UnitPrice', 'ITEM', function (r) {

            //                         document.getElementById("txtItem_UnitPrice").focus();
            //                     });

        }
        else if (after2 == '') {
            jQuery('#txtItemQty').validationEngine('showPrompt', 'Enter Qty', 'error', 'topRight', true);

            //jAlert('Enter Qty', 'ITEM', function (r) {

            document.getElementById("txtItemQty").focus();
            // });

        }
        else if (after3 == '2') {
            var hdn_Grid_Count = document.getElementById("hdn_Grid_Count").value;

            if (hdn_Grid_Count != '') {
                jQuery('#txtItem_UnitPrice').validationEngine('showPrompt', 'Higher than invoice value', 'error', 'topRight', true);

                //jAlert('Higher than invoice value', 'ITEM', function (r) {

                //document.getElementById("txtItem_UnitPrice").focus();
                //});
            }
        }
    }
}
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}




//***************** GET ITEM DETAILS DESCRIPTION LOAD WITH CORRESPONDING DETAILS FROM PRODUCT MASTER**********************

function CallServerside_RITC_DESC_PRODUCT(src, dest) {
    var ctrl = document.getElementById(src);
    //    alert(b);
    PageMethods.Get_Desc_RITC_PRODUCTMASTER(ctrl.value, CallSuccess_RITC_DESC, CallFailed, dest);

}

function CallSuccess_RITC_DESC(res, destCtrl) {
    var dest = document.getElementById(destCtrl);

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

        //        document.getElementById("txtRITCNo").value = before;
        document.getElementById("txtRITCNo").value = before;
        document.getElementById("ddlRewardPoints").value = after2;
        document.getElementById("ddl_STR_YN").value = after3;
        document.getElementById("STR_CODE").value = after4;
        document.getElementById("txtDrawback_SLNo").value = after5;
        document.getElementById("ddlSchemeCode").value = after6;
        //        document.getElementById("ddlSchemeCode").value = "19-DRAWBACK (DBK)";
        //        getElementById('div_STR_YN').style.display = 'none';

    }
}

$(function () {

    var ddlSchemeCode = $('#ddlSchemeCode');

    ddlSchemeCode.change(function (e) {
        var selectedValue = $(this).val();

        if (selectedValue == '99-NFEI') {
            document.getElementById("ddl_STR_YN").value = "No";
            document.getElementById("ddlRewardPoints").value = "No";

            document.getElementById("div_STR_YN").style.display = 'none';
        }
        else {
//            document.getElementById("div_STR_YN").style.display = 'none';
        }
    });
});


$(function () {
    $("#txt_Manu_Source_State").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_Name_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_Manu_Source_State').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);

                        //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_Manu_Source_State').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


$('#txt_Manu_Source_State').bind('keyup change focus focusout', function () {

    var data = $(this).val();
    state1(data);
});


function state1(val) {

    var data = val;
    if (data.indexOf("-") != -1) {

        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txt_Manu_Source_State').val(after);
    }
    else {
    }
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
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Supplier Country Name', 'error', 'topRight', true);

                            //jAlert('Supplier Country Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txt_Manu_Source_Country') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Seller Country Name', 'error', 'topRight', true);

                            //jAlert('Seller Country Name is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtBrokerCountryName') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Broker Country Name', 'error', 'topRight', true);

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
    $('#txt_Manufacturer_Country').bind('keyup change focus focusout', function () {

        var data = $(this).val();
        country(data);
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


$(function () {
    $("#txt_StateOrigin").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/District_State_Master_Name_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_StateOrigin').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);

                        //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_StateOrigin').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txt_DistrictOrigin").autocomplete({
        source: function (request, response) {
            var state = document.getElementById("txt_StateOrigin").value;
            var statecode = '';
            var n = state.toString().includes("-");
            if (n == true) {
                var a = state.toString().split("-");
                statecode = a[0];
            }
            else {
                statecode = state;
            }

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/District_Names_StateWise_List",
                //                data: "{ 'mail': '" + request.term + "' }",
                data: "{ 'mail': '" + request.term + "' ,'Statecode':'" + statecode + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_DistrictOrigin').validationEngine('showPrompt', 'Incorrect District Name', 'error', 'topRight', true);

                        //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_DistrictOrigin').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txt_PTA_FTA").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/PTA_FTA_Master_Name_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_PTA_FTA').validationEngine('showPrompt', 'Incorrect Agreement Name', 'error', 'topRight', true);

                        //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txt_PTA_FTA').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//----------------------- BIND DISTRICT NAMES BASED ON STATE CODES----START------------------

$(document).ready(function () {
    BindControls();
});

function BindControls() {

    var state = document.getElementById("txt_StateOrigin").value;
    var statecode = '';
    var n = state.toString().includes("-");
    if (n == true) {
        var a = state.toString().split("-");
        statecode = a[0];
    }
    else {
        statecode = state;
    }
    return statecode;
}

$('#txt_StateOrigin').bind(' keyup keypress change keydown blur', function () {
    var statecode = BindControls();
    PageMethods.Get_District_names_for_StateCode(statecode, OnSuccess_district_nameList);
});

function OnSuccess_district_nameList(response, userContext, methodName) {
    var Notn = response.split(', ');
    //alert(Notn);
    $('#txt_DistrictOrigin').autocomplete({
        source: Notn,
        minLength: 0,
        scroll: true
    }).focus(function () {
        $(this).autocomplete("search", "");
    });
}

//----------------------- BIND DISTRICT NAMES BASED ON STATE CODES---- END ------------------


