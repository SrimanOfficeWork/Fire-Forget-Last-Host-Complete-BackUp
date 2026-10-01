
//function close_button() {
//    //document.getElementById("btn_cancel").click();
//    document.getElementById("General").click();
//}
window.onload = happycode;
function happycode() {
    document.getElementById("General").click();
}
function Export_session() {
    
    var val, val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13, val14, val15, val16,val17;
   val= document.getElementById("ddlTransportMode").value;
   val1 = document.getElementById("txtJobNo").value;
   val2 = document.getElementById("txtJobDate").value;
   val3 = document.getElementById("txtConsigneeName").value;
   val4 = document.getElementById("txtConsigneeAddress").value;
   val5 = document.getElementById("txtConsigneeAddress1").value;
   val6 = document.getElementById("txtConsigneeAddress2").value;
   val7 = document.getElementById("txtConsigneeAddress3").value;
   val8 = document.getElementById("txtConsigneeAddress4").value;
   val9 = document.getElementById("txtExporterName").value;
   val10 = document.getElementById("txtIECNo").value;
   val11 = document.getElementById("txtBranchNo").value;
   val12 = document.getElementById("txtAddress").value;
   val13 = document.getElementById("txtAddress2").value;
   val14 = document.getElementById("txtAddress3").value;
   val15 = document.getElementById("txtAddress4").value;
   val16 = document.getElementById("txtAddress5").value;
   val17 = val + '~~' + val1 + '~~' + val2 + '~~' + val3 + '~~' + val4 + '~~' + val5 + '~~' + val6 + '~~' + val7 + '~~' + val8 + '~~' + val9 + '~~' + val10 + '~~' + val11 + '~~' + val12 + '~~' + val13 + '~~' + val14 + '~~' + val15 + '~~' + val16;
   $.ajax({
       url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Export_session1",
       data: "{ 'mail': '" + val17 + "'}",
       dataType: "json",
       type: "POST",
       contentType: "application/json; charset=utf-8"

   });
   
//    $.ajax({
//        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Export_session",
//        data: "{ 'mail': '" + val + "','mail1': '" + val1 + "','mail2': '" + val2 + "','mail3': '" + val3 + "','mail14': '" + val4 + "','mail5': '" + val5 + "','mail6': '" + val6 + "','mail7': '" + val7 + "','mail8': '" + val8 + "','mail9': '" + val9 + "','mail10': '" + val10 + "','mail11': '" + val11 + "','mail12': '" + val12 + "','mail13': '" + val13 + "','mail14': '" + val14 + "','mail15': '" + val15 + "','mail16': '" + val16 + "'}",
//        dataType: "json",
//        type: "POST",
//        contentType: "application/json; charset=utf-8"

//    });
}
function tab_page1() {

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'none';
    document.getElementById("page-15").style.display = 'none';

    if (document.getElementById('hdsaveandclose').value == 'Yes') {

        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'Block';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'none';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';

        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'none';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';
         document.getElementById("page-16").style.display = 'none';
//        document.getElementById("SEZ_Transshipment").className = 'inactive';
        document.getElementById("Trans_export_invoice_Iframe").src = "../Export/Invoice_Details.aspx";
        document.getElementById("hdsaveandclose").value = 'No';
        
    }
    document.getElementById("SEZ_Transshipment").className = 'inactive';
    document.getElementById("JobLogs1").className = 'inactive';
    document.getElementById("DTA_SEZ").className = 'inactive';
    document.getElementById('AccExpEntity').className = 'inactive';
}
function tab_page2() {

    if (document.getElementById("hdn_Jobno").value != '') {
        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'Block';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'none';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';
        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'none';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';
        document.getElementById("page-16").style.display = 'none';
        document.getElementById("Trans_export_invoice_Iframe").src = "../Export/Invoice_Details.aspx";
        document.getElementById("SEZ_Transshipment").className = 'inactive';
        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'inactive';
        document.getElementById('AccExpEntity').className = 'inactive';
    }
    else {
        happycode();
    }
}

function tab_page3() {

    if (document.getElementById("hdn_Jobno").value != '') {
        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'none';
        document.getElementById("page-3").style.display = 'Block';
        document.getElementById("page-4").style.display = 'none';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';
        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'none';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';
        document.getElementById("page-16").style.display = 'none';
        // document.getElementById("Trans_export_item_Iframe").src = "../Export/Item_Details.aspx";//hide on 25-09-2023 by Chithra

        document.getElementById("Trans_export_item_Iframe").src = "../Export/Item_Details.aspx?PageLoad=" + "New" + "";
        document.getElementById("SEZ_Transshipment").className = 'inactive';
        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'inactive';
        document.getElementById('AccExpEntity').className = 'inactive';
    }
    else {

            happycode();
    }
}
function tab_page4() {

    if (document.getElementById("hdn_Jobno").value != '') {

        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'none';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'Block';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';
        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'none';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';
        document.getElementById("page-16").style.display = 'none';
        document.getElementById("Trans_igm_item_Iframe").src = "../Export/Annexure_C1Details.aspx";
        document.getElementById("SEZ_Transshipment").className = 'inactive';
        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'inactive';
        document.getElementById('AccExpEntity').className = 'inactive';
    }
    else {
        happycode();
    }
}
function tab_page5(url, val) {

    if (document.getElementById('hdn_Jobno').value != '') {


        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'Block';
        document.getElementById('page-5').style.display = 'Block';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';
        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'none';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';
        document.getElementById("page-16").style.display = 'none';
        //document.getElementById("Trans_igm_item_Iframe").src = url + val;
        document.getElementById("Trans_igm_item_Iframe").src = url + val + '&jobnops=' + document.getElementById('txtjobPS').value;
        document.getElementById("SEZ_Transshipment").className = 'inactive';
        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'inactive';
        document.getElementById('AccExpEntity').className = 'inactive';

    }
    else {

        happycode();
    }
}
function tab_page6(url, val, url1, val1, type) {

    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'Block';
        document.getElementById('page-5').style.display = 'Block';

        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';
        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'none';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';
        document.getElementById("page-16").style.display = 'none';
        document.getElementById("Trans_igm_item_Iframe").src = url + val + url1 + val1 + type;
        document.getElementById("SEZ_Transshipment").className = 'inactive';
        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'inactive';
        document.getElementById('AccExpEntity').className = 'inactive';
    }
    else {
        happycode();
    }
}
function tab_page10() {

    if (document.getElementById("hdn_Jobno").value != '') {
        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'none';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'none';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'Block';
        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'none';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';
        document.getElementById("page-16").style.display = 'none';

        document.getElementById("Trans_igm_Bill_Others_Iframe").src = "../Export/Exp_Billing_Others_Details.aspx";
        document.getElementById("SEZ_Transshipment").className = 'inactive';

        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'inactive';
        document.getElementById('AccExpEntity').className = 'inactive';
    }
    else {
        happycode();
    }
}
function tab_page11() {

    if (document.getElementById("hdn_Jobno").value != '') {
        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'none';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'none';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';
        document.getElementById("page-11").style.display = 'Block';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'none';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';
        document.getElementById("page-16").style.display = 'none';
        document.getElementById("Sez_Trans_Iframe").src = "../Export_ETP/ETP_Master_Details.aspx";

        document.getElementById("General").className = 'inactive';
        document.getElementById("INVOICE").className = 'inactive';
        document.getElementById("ITEM").className = 'inactive';
        document.getElementById("Annuxure").className = 'inactive';
        document.getElementById("Checklist").className = 'inactive';
        document.getElementById("Submission").className = 'inactive';
        document.getElementById("Jobhistry").className = 'inactive';
        document.getElementById("SEZ_Transshipment").className = 'active';
        document.getElementById("charge_acc").className = 'inactive';
        document.getElementById("finance_acc").className = 'inactive';
        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'inactive';
        document.getElementById('AccExpEntity').className = 'inactive';
    }
    else {
        happycode();
    }
}


function tab_page12() {

    if (document.getElementById("hdn_Jobno").value != '') {

        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'none';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'none';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';
        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'Block';
        document.getElementById("page-13").style.display = 'none';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';
        document.getElementById("page-16").style.display = 'none';
        document.getElementById("Sez_DTA_Iframe").src = "../Export_DTA_SEZ/DTA_General_Details.aspx";

        document.getElementById("General").className = 'inactive';
        document.getElementById("INVOICE").className = 'inactive';
        document.getElementById("ITEM").className = 'inactive';
        document.getElementById("Annuxure").className = 'inactive';
        document.getElementById("Checklist").className = 'inactive';
        document.getElementById("Submission").className = 'inactive';
        document.getElementById("Jobhistry").className = 'inactive';
        document.getElementById("SEZ_Transshipment").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'active';
        document.getElementById("charge_acc").className = 'inactive';
        document.getElementById("finance_acc").className = 'inactive';
        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById('AccExpEntity').className = 'inactive';

    }
    else {
        happycode();
    }
}



function tab_page_sun() {

    if (document.getElementById("hdn_Jobno").value != '') {
        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'none';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'none';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';
        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'Block';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';

        document.getElementById("Iframe_Charge").src = "../Accounts_CHA_Export_old/Acc_Bill_To_Party.aspx";

        document.getElementById("General").className = 'inactive';
        document.getElementById("INVOICE").className = 'inactive';
        document.getElementById("ITEM").className = 'inactive';
        document.getElementById("Annuxure").className = 'inactive';
        document.getElementById("Checklist").className = 'inactive';
        document.getElementById("Submission").className = 'inactive';
        document.getElementById("Jobhistry").className = 'inactive';
        document.getElementById("SEZ_Transshipment").className = 'inactive';
        document.getElementById("charge_acc").className = 'active';
        document.getElementById("finance_acc").className = 'inactive';
        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'inactive';
    }
    else {
        happycode();
    }
}
    function tab_page13() {

    if (document.getElementById("hdn_Jobno").value != '') {
        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'none';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'none';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';
        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'Block';
        document.getElementById("page-14").style.display = 'none';
        document.getElementById("page-15").style.display = 'none';
        document.getElementById("page-16").style.display = 'none';
        document.getElementById("Iframe_Charge").src = "../Accounts_CHA_Export/Acc_Bill_To_Party.aspx";

        document.getElementById("General").className = 'inactive';
        document.getElementById("INVOICE").className = 'inactive';
        document.getElementById("ITEM").className = 'inactive';
        document.getElementById("Annuxure").className = 'inactive';
        document.getElementById("Checklist").className = 'inactive';
        document.getElementById("Submission").className = 'inactive';
        document.getElementById("Jobhistry").className = 'inactive';
        document.getElementById("SEZ_Transshipment").className = 'inactive';
        document.getElementById("charge_acc").className = 'active';
        document.getElementById("finance_acc").className = 'inactive';
        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'inactive';
        document.getElementById('AccExpEntity').className = 'inactive';
    }
    else {
        happycode();
    }
}
function tab_page14() {

    if (document.getElementById("hdn_Jobno").value != '') {
        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'none';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'none';
        document.getElementById("page-5").style.display = 'none';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        document.getElementById("page-10").style.display = 'none';
        document.getElementById("page-11").style.display = 'none';
        document.getElementById("page-12").style.display = 'none';
        document.getElementById("page-13").style.display = 'none';
        document.getElementById("page-14").style.display = 'Block';
        document.getElementById("Iframe_finance").src = "../Accounts_CHA_Export/Acc_Financials.aspx";
        document.getElementById("page-15").style.display = 'none';
        document.getElementById("page-16").style.display = 'none';
        document.getElementById("General").className = 'inactive';
        document.getElementById("INVOICE").className = 'inactive';
        document.getElementById("ITEM").className = 'inactive';
        document.getElementById("Annuxure").className = 'inactive';
        document.getElementById("Checklist").className = 'inactive';
        document.getElementById("Submission").className = 'inactive';
        document.getElementById("Jobhistry").className = 'inactive';
        document.getElementById("SEZ_Transshipment").className = 'inactive';
        document.getElementById("charge_acc").className = 'inactive';
        document.getElementById("finance_acc").className = 'active';
        document.getElementById("JobLogs1").className = 'inactive';
        document.getElementById("DTA_SEZ").className = 'inactive';
        document.getElementById('AccExpEntity').className = 'inactive';
    }
    else {
        happycode();
    }
}

    function tab_page15() {

        if (document.getElementById("hdn_Jobno").value != '') {
            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("page-5").style.display = 'none';
            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'none';
            document.getElementById("page-8").style.display = 'none';
            document.getElementById("page-10").style.display = 'none';
            document.getElementById("page-11").style.display = 'none';
            document.getElementById("page-12").style.display = 'none';
            document.getElementById("page-13").style.display = 'none';
            document.getElementById("page-14").style.display = 'none';
            document.getElementById("page-15").style.display = 'Block';
            document.getElementById("page-16").style.display = 'none';
            document.getElementById("Exp_jobLogs_iframe").src =
            "../Job_History/Exp_Job_Logs.aspx?jobno=" +
                        document.getElementById("hdn_Jobno").value;
           
            document.getElementById("JobLogs1").className = 'active';
            document.getElementById("General").className = 'inactive';
            document.getElementById("INVOICE").className = 'inactive';
            document.getElementById("ITEM").className = 'inactive';
            document.getElementById("Annuxure").className = 'inactive';
            document.getElementById("Checklist").className = 'inactive';
            document.getElementById("Submission").className = 'inactive';
            document.getElementById("Jobhistry").className = 'inactive';
            document.getElementById("SEZ_Transshipment").className = 'inactive';
            document.getElementById("charge_acc").className = 'inactive';
            document.getElementById("finance_acc").className = 'inactive';
            document.getElementById("DTA_SEZ").className = 'inactive';
            document.getElementById('AccExpEntity').className = 'inactive';
        }
        else {
            happycode();
        }
    }

 function tab_page16() {

        if (document.getElementById("hdn_Jobno").value != '') {
            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("page-5").style.display = 'none';
            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'none';
            document.getElementById("page-8").style.display = 'none';
            document.getElementById("page-10").style.display = 'none';
            document.getElementById("page-11").style.display = 'none';
            document.getElementById("page-12").style.display = 'none';
            document.getElementById("page-13").style.display = 'none';
            document.getElementById("page-14").style.display = 'none';
            document.getElementById("page-15").style.display = 'none';
            document.getElementById("page-16").style.display = 'Block';

            document.getElementById("Iframe_Exp_entity").src = "../Accounts_CHA_Export/Acc_Exp_Entity.aspx";
            document.getElementById("JobLogs1").className = 'inactive';
            document.getElementById("General").className = 'inactive';
            document.getElementById("INVOICE").className = 'inactive';
            document.getElementById("ITEM").className = 'inactive';
            document.getElementById("Annuxure").className = 'inactive';
            document.getElementById("Checklist").className = 'inactive';
            document.getElementById("Submission").className = 'inactive';
            document.getElementById("Jobhistry").className = 'inactive';
            document.getElementById("SEZ_Transshipment").className = 'inactive';
            document.getElementById("charge_acc").className = 'inactive';
            document.getElementById("finance_acc").className = 'inactive';
            document.getElementById("DTA_SEZ").className = 'inactive';
            document.getElementById('AccExpEntity').className = 'active';
        }
        else {
            happycode();
        }
    }


//function validate1() {
//    var ddlNFEI_val;
//    ddlNFEI_val = document.getElementById("ddlNFEI").value;

//    var txtJobDate = document.getElementById("txtJobDate").value;
//    if (txtJobDate != "") {
//        if (isDate(txtJobDate)) {

//        }
//        else {
//            jAlert('JobDate is Invalid Date', 'GENERAL', function (r) { document.getElementById("txtJobDate").focus(); });
//            return false;
//        }
//    }
//    else {
//        jAlert('JobDate cannot be blank', 'GENERAL', function (r) { document.getElementById("txtJobDate").focus(); });
//        return false;
//    }
//    //------------------------------
//    var CUSTOMS_HOUSE;
//    CUSTOMS_HOUSE = document.getElementById("txtCustomsHouse").value;

//    if (CUSTOMS_HOUSE.length <= 0) {

//        jAlert('Custom_House Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtCustomsHouse").focus(); });
//        return false;
//    }
//    else if (CUSTOMS_HOUSE.length < 6) {

//        jAlert('Custom_House Should be 6 digit', 'GENERAL', function (r) { document.getElementById("txtCustomsHouse").focus(); });
//        return false;
//    }

//    var txthdn_Customhouse_chk;
//    txthdn_Customhouse_chk = document.getElementById("hdn_Customhouse_chk").value;
//   
//    if (txthdn_Customhouse_chk != "Yes") {
//        document.getElementById('txtCustomsHouse').style.border = "1px solid Red";
//        jAlert('Invalid Customs House', 'GENERAL', function (r) { document.getElementById("txtCustomsHouse").focus(); });
//        return false;
//    }
//    //-------------------------------
//    var PORT_OF_LOADING;
//    PORT_OF_LOADING = document.getElementById("txt_PortOfLoading").value;
//    var ddlSBType;
//    ddlSBType = document.getElementById("ddlSBType").value;

//    if (ddlSBType == 'SEZ') {
//       
//        if (PORT_OF_LOADING.length <= 0) {

//            jAlert('Port Of Loading Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txt_PortOfLoading").focus(); });
//            return false;
//        }

//        else if (PORT_OF_LOADING.length < 6) {

//            jAlert('Port Of Loading Should be 6 digit', 'GENERAL', function (r) { document.getElementById("txt_PortOfLoading").focus(); });
//            return false;
//        }


//        var txthdn_PortOfLoading_chk;
//        txthdn_PortOfLoading_chk = document.getElementById("hdn_PortOfLoading_chk").value;

//        if (txthdn_PortOfLoading_chk != "Yes") {
//            document.getElementById('txt_PortOfLoading').style.border = "1px solid Red";
//            jAlert('Invalid Port Of Loading', 'GENERAL', function (r) { document.getElementById("txt_PortOfLoading").focus(); });
//            return false;
//        }

//    }
//   
//    //-------------------------
//    var ExporterName;
//    ExporterName = document.getElementById("txtExporterName").value;

//    if (ExporterName.length <= 0) {

//        jAlert('Exporter Name Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
//        return false;
//    }
//    var IEC_NO;
//    IEC_NO = document.getElementById("txtIECNo").value;

//    if (IEC_NO.length <= 0) {
//        jAlert('IECNo Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtIECNo").focus(); });
//        return false;
//    }
//    var highseaIEC_NO;
//    highseaIEC_NO = document.getElementById("txtIECNo").value;
//    if (highseaIEC_NO.length < 10) {
//        jAlert('IEC no Should be 10 digit', 'GENERAL', function (r) { document.getElementById("txtIECNo").focus(); });
//        return false;
//    }

//    var BRANCH_NO;
//    BRANCH_NO = document.getElementById("txtBranchNo").value;

//    if (BRANCH_NO.length <= 0) {

//        jAlert('Branch Slno Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtBranchNo").focus(); });
//        return false;
//    }
//    var ADDRESS1;
//    ADDRESS1 = document.getElementById("txtAddress").value;

//    if (ADDRESS1.length <= 0) {

//        jAlert('Address Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtAddress").focus(); });
//        return false;
//    }


//    var COUNTRY_ORIGIN;
//    COUNTRY_ORIGIN = document.getElementById("txtCountryDischarge").value;

//    var CompanyID = document.getElementById("hdn_Comp_License").value;
//    if (CompanyID != 'eri00532') {
//        if (COUNTRY_ORIGIN.length <= 0) {

//            jAlert('Country Discharge cannot be blank', 'GENERAL', function (r) { document.getElementById("txtCountryDischarge").focus(); });
//            return false;
//        }
//    }
//    var PORT_ORIGIN;
//    PORT_ORIGIN = document.getElementById("txtPortDischarge").value;

//    if (PORT_ORIGIN.length <= 0) {
//        jAlert('Port Discharge cannot be blank', 'GENERAL', function (r) { document.getElementById("txtPortDischarge").focus(); });
//        return false;
//    }

//    COUNTRY_ORIGIN_chk = document.getElementById("hdnCountryDischarge_chk").value;
//    if (CompanyID != 'eri00532') {
//        if (COUNTRY_ORIGIN_chk != "Yes") {
//            document.getElementById('txtCountryDischarge').style.border = "1px solid Red";
//            jAlert('Invalid Country Discharge', 'GENERAL', function (r) { document.getElementById("txtCountryDischarge").focus(); });
//            return false;
//        }
//    }


//    var PORT_ORIGIN_chk;
//    PORT_ORIGIN_chk = document.getElementById("hdnPortDischarge_chk").value;

//    if (PORT_ORIGIN_chk != "Yes") {
//        document.getElementById('txtPortDischarge').style.border = "1px solid Red";
//        jAlert('Invalid Port Discharge', 'GENERAL', function (r) { document.getElementById("txtPortDischarge").focus(); });
//        return false;
//    }


//    var txtCountryFinalDestination;
//    txtCountryFinalDestination = document.getElementById("txtCountryFinalDestination").value;

//    if (txtCountryFinalDestination.length <= 0) {

//        jAlert('Country FinalDestination cannot be blank', 'GENERAL', function (r) { document.getElementById("txtCountryFinalDestination").focus(); });
//        return false;
//    }
//    var txtPortFinalDestination;
//    txtPortFinalDestination = document.getElementById("txtPortFinalDestination").value;

//    if (txtPortFinalDestination.length <= 0) {

//        jAlert('Port FinalDestination cannot be blank', 'GENERAL', function (r) { document.getElementById("txtPortFinalDestination").focus(); });
//        return false;
//    }


//    var txtCountryFinalDestination_chk;
//    txtCountryFinalDestination_chk = document.getElementById("hdnCountryFinalDestination_chk").value;

//    if (txtCountryFinalDestination_chk != "Yes") {
//        document.getElementById('txtCountryFinalDestination').style.border = "1px solid Red";
//        jAlert('Invalid Country FinalDestination', 'GENERAL', function (r) { document.getElementById("txtCountryFinalDestination").focus(); });
//        return false;
//    }
//    var txtPortFinalDestination_chk;
//    txtPortFinalDestination_chk = document.getElementById("hdnPortFinalDestination_chk").value;

//    if (txtPortFinalDestination_chk != "Yes") {
//        document.getElementById('txtPortFinalDestination').style.border = "1px solid Red";
//        jAlert('Invalid Port FinalDestination', 'GENERAL', function (r) { document.getElementById("txtPortFinalDestination").focus(); });
//        return false;
//    }




//    var txtStateExport;
//    txtStateExport = document.getElementById("txtStateExport").value;

//    if (txtStateExport.length <= 0) {
//        jAlert('State Export cannot be blank', 'GENERAL', function (r) { document.getElementById("txtStateExport").focus(); });
//        return false;
//    }

//    var State_of_export_chk = document.getElementById("hdn_State_of_export_chk").value;
//    if (CompanyID != 'eri00532') {
//        if (State_of_export_chk != "Yes") {
//            document.getElementById('txtStateExport').style.border = "1px solid Red";
//            jAlert('Invalid State of Export', 'GENERAL', function (r) { document.getElementById("txtStateExport").focus(); });
//            return false;
//        }
//    }

//    var txtAdcode;
//    txtAdcode = document.getElementById("txtAdcode").value;
//   // ddlSBType = document.getElementById("ddlSBType").value;

//    if ((ddlSBType != '98-Scheme') && (ddlNFEI_val == 'No')) {
//        if (txtAdcode.length <= 0) {
//            jAlert('AD Code cannot be blank', 'GENERAL', function (r) { document.getElementById("txtAdcode").focus(); });

//            return false;
//        }
//    }
//    
//    if (txtAdcode.length > 0) {
//        if (ddlSBType == 'SEZ') {
//            if ((txtAdcode == 'NFEI') || (txtAdcode.length > 6)) {
//                //true
//            }
//            else {
//                jAlert('Invalid AD Code for SEZ', 'GENERAL', function (r) { document.getElementById("txtAdcode").focus(); });
//                return false;
//            }
//        }
//        else {
//            if (txtAdcode.length < 7) {
//                jAlert('AD Code Should be 7 digit', 'GENERAL', function (r) { document.getElementById("txtAdcode").focus(); });
//                return false;
//            }
//        }
//    }
//                
//    var txtConsigneeName;
//    txtConsigneeName = document.getElementById("txtConsigneeName").value;

//    if (txtConsigneeName.length <= 0) {

//        jAlert('Consignee Name cannot be blank', 'GENERAL', function (r) { document.getElementById("txtConsigneeName").focus(); });

//        return false;
//    }
//    var txtConsigneeAddress;
//    txtConsigneeAddress = document.getElementById("txtConsigneeAddress").value;

//    if (txtConsigneeAddress.length <= 0) {

//        jAlert('Consignee Address cannot be blank', 'GENERAL', function (r) { document.getElementById("txtConsigneeAddress").focus(); });
//        return false;
//    }

//    var txtConsigneeAddress4;
//    txtConsigneeAddress4 = document.getElementById("txtConsigneeAddress4").value;

//    if (txtConsigneeAddress4.length <= 0) {

//        jAlert('Consignee Country cannot be blank', 'GENERAL', function (r) { document.getElementById("txtConsigneeAddress4").focus(); });
//        return false;
//    }

//    var txt_GSTN_ID;
//    txt_GSTN_ID = document.getElementById("txt_GSTN_ID").value;

//    if (txt_GSTN_ID.length <= 0) {
//        jAlert('GSTN ID cannot be blank', 'GENERAL', function (r) { document.getElementById("txt_GSTN_ID").focus(); });
//        return false;
//    }

//    var ddl_GSTN_Type;
//    ddl_GSTN_Type = document.getElementById("ddl_GSTN_Type").value;

//    if (ddl_GSTN_Type.length <= 0) {
//        jAlert('GSTN Type cannot be blank', 'GENERAL', function (r) { document.getElementById("ddl_GSTN_Type").focus(); });
//        return false;
//    }


//    var ddlNFEI;
//    ddlNFEI = document.getElementById("ddlNFEI").value;

//    if (ddlNFEI.length <= 0) {
//        jAlert('NFEI cannot be blank', 'GENERAL', function (r) { document.getElementById("ddlNFEI").focus(); });

//        return false;
//    }

//    if (ddlNFEI == 'Yes') {
//        var ddlType;
//        ddlType = document.getElementById("ddlType").value;
//        if (ddlType.length <= 0) {
//            jAlert('NFEI Type cannot be blank', 'GENERAL', function (r) { document.getElementById("ddlType").focus(); });

//            return false;
//        }

//        if (CompanyID != 'eri00542' && ddlType != '09-DTA SB') {
//            var txtRBIWaiverNo;
//            txtRBIWaiverNo = document.getElementById("txtRBIWaiverNo").value;

//            if (txtRBIWaiverNo.length <= 0) {
//                jAlert('RBI Waiver No cannot be blank', 'GENERAL', function (r) { document.getElementById("txtRBIWaiverNo").focus(); });

//                return false;
//            }
//            var txtRBIWaiverDate = document.getElementById("txtRBIWaiverDate").value;
//            if (txtRBIWaiverDate != "") {
//                if (isDate(txtRBIWaiverDate)) {

//                }
//                else {
//                    jAlert('RBI Waiver Date is Invalid Date', 'GENERAL', function (r) { document.getElementById("txtRBIWaiverDate").focus(); });

//                    return false;
//                }
//            }
//            else {
//                jAlert('RBIWaiverDate cannot be blank', 'GENERAL', function (r) { document.getElementById("txtRBIWaiverDate").focus(); });

//                return false;

//            }
//        }
//    }
//    else {
//        $('#form1').validationEngine('detach');


//    }

//}


//Modified By Benjamin  18042026


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

function validate1() {
    var ddlNFEI_val;
    ddlNFEI_val = document.getElementById("ddlNFEI").value;

    // ── Job Date — NOT flag driven ────────────────────────────────
    var txtJobDate = document.getElementById("txtJobDate").value;
    if (txtJobDate != "") {
        if (isDate(txtJobDate)) {
        }
        else {
            jAlert('JobDate is Invalid Date', 'GENERAL',
                function (r) { document.getElementById("txtJobDate").focus(); });
            return false;
        }
    }
    else {
        jAlert('JobDate cannot be blank', 'GENERAL',
            function (r) { document.getElementById("txtJobDate").focus(); });
        return false;
    }

    // ── Customs House — NOT flag driven ───────────────────────────
    var CUSTOMS_HOUSE = document.getElementById("txtCustomsHouse").value;
    if (CUSTOMS_HOUSE.length <= 0) {
        jAlert('Custom_House Field cannot be blank', 'GENERAL',
            function (r) { document.getElementById("txtCustomsHouse").focus(); });
        return false;
    }
    else if (CUSTOMS_HOUSE.length < 6) {
        jAlert('Custom_House Should be 6 digit', 'GENERAL',
            function (r) { document.getElementById("txtCustomsHouse").focus(); });
        return false;
    }

    var txthdn_Customhouse_chk = document.getElementById("hdn_Customhouse_chk").value;
    if (txthdn_Customhouse_chk != "Yes") {
        document.getElementById('txtCustomsHouse').style.border = "1px solid Red";
        jAlert('Invalid Customs House', 'GENERAL',
            function (r) { document.getElementById("txtCustomsHouse").focus(); });
        return false;
    }

    // ── Port of Loading — NOT flag driven ─────────────────────────
    var PORT_OF_LOADING = document.getElementById("txt_PortOfLoading").value;
    var ddlSBType = document.getElementById("ddlSBType").value;

    if (ddlSBType == 'SEZ') {
        if (PORT_OF_LOADING.length <= 0) {
            jAlert('Port Of Loading Field cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txt_PortOfLoading").focus(); });
            return false;
        }
        else if (PORT_OF_LOADING.length < 6) {
            jAlert('Port Of Loading Should be 6 digit', 'GENERAL',
                function (r) { document.getElementById("txt_PortOfLoading").focus(); });
            return false;
        }
        var txthdn_PortOfLoading_chk =
            document.getElementById("hdn_PortOfLoading_chk").value;
        if (txthdn_PortOfLoading_chk != "Yes") {
            document.getElementById('txt_PortOfLoading').style.border = "1px solid Red";
            jAlert('Invalid Port Of Loading', 'GENERAL',
                function (r) { document.getElementById("txt_PortOfLoading").focus(); });
            return false;
        }
    }

    var CompanyID = document.getElementById("hdn_Comp_License").value;

    // ── Exporter Name — driven by master setting ──────────────────
    if (mand_ExporterName == "Y") {
        if (document.getElementById("txtExporterName").value.trim() == "") {
            showMandatoryTooltip("txtExporterName", function () {
                jAlert('Exporter Name Field cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtExporterName").focus(); });
            });
            return false;
        }
    }

    // ── IEC No — driven by master setting ─────────────────────────
    if (mand_IECNo == "Y") {
        var IEC_NO = document.getElementById("txtIECNo").value;
        if (IEC_NO.trim().length <= 0) {
            showMandatoryTooltip("txtIECNo", function () {
                jAlert('IECNo Field cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtIECNo").focus(); });
            });
            return false;
        }
        if (IEC_NO.length < 10) {
            showMandatoryTooltip("txtIECNo", function () {
                jAlert('IEC No Should be minimum 10 digits', 'GENERAL',
                    function (r) { document.getElementById("txtIECNo").focus(); });
            });
            return false;
        }
    }

    // ── Branch SL No — driven by master setting ───────────────────
    if (mand_BranchSLNo == "Y") {
        if (document.getElementById("txtBranchNo").value.trim().length <= 0) {
            showMandatoryTooltip("txtBranchNo", function () {
                jAlert('Branch Slno Field cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtBranchNo").focus(); });
            });
            return false;
        }
    }

    // ── Address — driven by master setting ────────────────────────
    if (mand_Address == "Y") {
        if (document.getElementById("txtAddress").value.trim().length <= 0) {
            showMandatoryTooltip("txtAddress", function () {
                jAlert('Address Field cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtAddress").focus(); });
            });
            return false;
        }
    }

    // ── Country Discharge — driven by master setting ──────────────
    if (mand_CountryDischarge == "Y") {
        if (CompanyID != 'eri00532') {
            if (document.getElementById("txtCountryDischarge").value.trim().length <= 0) {
                showMandatoryTooltip("txtCountryDischarge", function () {
                    jAlert('Country Discharge cannot be blank', 'GENERAL',
                        function (r) { document.getElementById("txtCountryDischarge").focus(); });
                });
                return false;
            }
            var COUNTRY_ORIGIN_chk =
                document.getElementById("hdnCountryDischarge_chk").value;
            if (COUNTRY_ORIGIN_chk != "Yes") {
                document.getElementById('txtCountryDischarge').style.border = "1px solid Red";
                jAlert('Invalid Country Discharge', 'GENERAL',
                    function (r) { document.getElementById("txtCountryDischarge").focus(); });
                return false;
            }
        }
    }

    // ── Port Discharge — driven by master setting ─────────────────
    if (mand_PortDischarge == "Y") {
        if (document.getElementById("txtPortDischarge").value.trim().length <= 0) {
            showMandatoryTooltip("txtPortDischarge", function () {
                jAlert('Port Discharge cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtPortDischarge").focus(); });
            });
            return false;
        }
        var PORT_ORIGIN_chk =
            document.getElementById("hdnPortDischarge_chk").value;
        if (PORT_ORIGIN_chk != "Yes") {
            document.getElementById('txtPortDischarge').style.border = "1px solid Red";
            jAlert('Invalid Port Discharge', 'GENERAL',
                function (r) { document.getElementById("txtPortDischarge").focus(); });
            return false;
        }
    }

    // ── Country Final Destination — driven by master setting ──────
    if (mand_CountryFinalDest == "Y") {
        if (document.getElementById("txtCountryFinalDestination").value.trim().length <= 0) {
            showMandatoryTooltip("txtCountryFinalDestination", function () {
                jAlert('Country FinalDestination cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtCountryFinalDestination").focus(); });
            });
            return false;
        }
        var txtCountryFinalDestination_chk =
            document.getElementById("hdnCountryFinalDestination_chk").value;
        if (txtCountryFinalDestination_chk != "Yes") {
            document.getElementById('txtCountryFinalDestination').style.border = "1px solid Red";
            jAlert('Invalid Country FinalDestination', 'GENERAL',
                function (r) { document.getElementById("txtCountryFinalDestination").focus(); });
            return false;
        }
    }

    // ── Port Final Destination — driven by master setting ─────────
    if (mand_PortFinalDest == "Y") {
        if (document.getElementById("txtPortFinalDestination").value.trim().length <= 0) {
            showMandatoryTooltip("txtPortFinalDestination", function () {
                jAlert('Port FinalDestination cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtPortFinalDestination").focus(); });
            });
            return false;
        }
        var txtPortFinalDestination_chk =
            document.getElementById("hdnPortFinalDestination_chk").value;
        if (txtPortFinalDestination_chk != "Yes") {
            document.getElementById('txtPortFinalDestination').style.border = "1px solid Red";
            jAlert('Invalid Port FinalDestination', 'GENERAL',
                function (r) { document.getElementById("txtPortFinalDestination").focus(); });
            return false;
        }
    }

    // ── State of Export — driven by master setting ────────────────
    if (mand_StateOfExport == "Y") {
        if (document.getElementById("txtStateExport").value.trim().length <= 0) {
            showMandatoryTooltip("txtStateExport", function () {
                jAlert('State Export cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtStateExport").focus(); });
            });
            return false;
        }
        var State_of_export_chk =
            document.getElementById("hdn_State_of_export_chk").value;
        if (CompanyID != 'eri00532') {
            if (State_of_export_chk != "Yes") {
                document.getElementById('txtStateExport').style.border = "1px solid Red";
                jAlert('Invalid State of Export', 'GENERAL',
                    function (r) { document.getElementById("txtStateExport").focus(); });
                return false;
            }
        }
    }

    // ── AD Code — driven by master setting ────────────────────────
    if (mand_ADCode == "Y") {
        var txtAdcode = document.getElementById("txtAdcode").value;
        if ((ddlSBType != '98-Scheme') && (ddlNFEI_val == 'No')) {
            if (txtAdcode.trim().length <= 0) {
                jAlert('AD Code cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtAdcode").focus(); });
                return false;
            }
        }
        if (txtAdcode.length > 0) {
            if (ddlSBType == 'SEZ') {
                if ((txtAdcode == 'NFEI') || (txtAdcode.length > 6)) {
                    // valid
                }
                else {
                    jAlert('Invalid AD Code for SEZ', 'GENERAL',
                        function (r) { document.getElementById("txtAdcode").focus(); });
                    return false;
                }
            }
            else {
                if (txtAdcode.length < 7) {
                    jAlert('AD Code Should be 7 digit', 'GENERAL',
                        function (r) { document.getElementById("txtAdcode").focus(); });
                    return false;
                }
            }
        }
    }

    // ── Consignee Name — driven by master setting ─────────────────
    if (mand_ConsigneeName == "Y") {
        if (document.getElementById("txtConsigneeName").value.trim().length <= 0) {
            showMandatoryTooltip("txtConsigneeName", function () {
                jAlert('Consignee Name cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtConsigneeName").focus(); });
            });
            return false;
        }
    }

    // ── Consignee Address — driven by master setting ──────────────
    if (mand_ConsigneeAddress == "Y") {
        if (document.getElementById("txtConsigneeAddress").value.trim().length <= 0) {
            showMandatoryTooltip("txtConsigneeAddress", function () {
                jAlert('Consignee Address cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtConsigneeAddress").focus(); });
            });
            return false;
        }
    }

    // ── Consignee Country — driven by master setting ──────────────
    if (mand_ConsigneeCountry == "Y") {
        if (document.getElementById("txtConsigneeAddress4").value.trim().length <= 0) {
            jAlert('Consignee Country cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txtConsigneeAddress4").focus(); });
            return false;
        }
    }

    // ── GSTN ID — driven by master setting ───────────────────────
    if (mand_GstnId == "Y") {
        if (document.getElementById("txt_GSTN_ID").value.trim().length <= 0) {
            jAlert('GSTN ID cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txt_GSTN_ID").focus(); });
            return false;
        }
    }

    // ── GSTN Type — driven by master setting ─────────────────────
    if (mand_GstnType == "Y") {
        if (document.getElementById("ddl_GSTN_Type").value.trim().length <= 0) {
            jAlert('GSTN Type cannot be blank', 'GENERAL',
                function (r) { document.getElementById("ddl_GSTN_Type").focus(); });
            return false;
        }
    }

    // ── NFEI — NOT flag driven ────────────────────────────────────
    var ddlNFEI = document.getElementById("ddlNFEI").value;
    if (ddlNFEI.length <= 0) {
        jAlert('NFEI cannot be blank', 'GENERAL',
            function (r) { document.getElementById("ddlNFEI").focus(); });
        return false;
    }

    if (ddlNFEI == 'Yes') {
        var ddlType = document.getElementById("ddlType").value;
        if (ddlType.length <= 0) {
            jAlert('NFEI Type cannot be blank', 'GENERAL',
                function (r) { document.getElementById("ddlType").focus(); });
            return false;
        }
        if (CompanyID != 'eri00542' && ddlType != '09-DTA SB') {
            var txtRBIWaiverNo = document.getElementById("txtRBIWaiverNo").value;
            if (txtRBIWaiverNo.length <= 0) {
                jAlert('RBI Waiver No cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtRBIWaiverNo").focus(); });
                return false;
            }
            var txtRBIWaiverDate = document.getElementById("txtRBIWaiverDate").value;
            if (txtRBIWaiverDate != "") {
                if (isDate(txtRBIWaiverDate)) {
                }
                else {
                    jAlert('RBI Waiver Date is Invalid Date', 'GENERAL',
                        function (r) { document.getElementById("txtRBIWaiverDate").focus(); });
                    return false;
                }
            }
            else {
                jAlert('RBIWaiverDate cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtRBIWaiverDate").focus(); });
                return false;
            }
        }
    }
    else {
        $('#form1').validationEngine('detach');
    }
}




function OpenAdcode() {

}
function ddlNFEI_Disable() {
    
    var dropDownList1 = $('#ddlNFEI');
    var ddlType = $('#ddlType');
    var txtRBIWaiverNo = $('#txtRBIWaiverNo');
    var txtRBIWaiverDate = $('#txtRBIWaiverDate');
    var lblType = $('#lblType');


    var selectedValue = dropDownList1.val();

    if (selectedValue != '') {

        if (selectedValue == 'Yes') {
            ddlType.attr('disabled', false);
            txtRBIWaiverNo.attr('disabled', false);
            txtRBIWaiverDate.attr('disabled', false);
            lblType.attr('disabled', false);


        }
        else if (selectedValue == 'No') {

            ddlType.attr('disabled', true);
            txtRBIWaiverNo.attr('disabled', true);
            txtRBIWaiverDate.attr('disabled', true);
            lblType.attr('disabled', true);

        }

    }

}

function clear() {

    var txtCustomsHouse = $('#txtCustomsHouse');

    var txtExporterName = $('#txtExporterName');
    var txtAddress = $('#txtAddress');
    var txtAddress2 = $('#txtAddress2');
    var txtAddress3 = $('#txtAddress3');
    var txtAddress4 = $('#txtAddress4');
    var txtAddress5 = $('#txtAddress5');
    var txtBranchNo = $('#txtBranchNo');
    var txtIECNo = $('#txtIECNo');
    var txtAdcode = $('#txtAdcode');
    var txtBankAccount = $('#txtBankAccount');
    var txtDrawbackAccount = $('#txtDrawbackAccount');
    var txtConsigneeName = $('#txtConsigneeName');
    var txtConsigneeAddress = $('#txtConsigneeAddress');
    var txtConsigneeAddress1 = $('#txtConsigneeAddress1');
    var txtConsigneeAddress2 = $('#txtConsigneeAddress2');
    var txtConsigneeAddress3 = $('#txtConsigneeAddress3');
    var txtConsigneeAddress4 = $('#txtConsigneeAddress4');
    var txtCountryDischarge = $('#txtCountryDischarge');

    var txtPortDischarge = $('#txtPortDischarge');
    var txtCountryFinalDestination = $('#txtCountryFinalDestination');
    var txtPortFinalDestination = $('#txtPortFinalDestination');
    var txtStateExport = $('#txtStateExport');
    var ddlNFEI = $('#ddlNFEI');
    var ddlType = $('#ddlType');
    var txtRBIWaiverNo = $('#txtRBIWaiverNo');
    var txtRBIWaiverDate = $('#txtRBIWaiverDate');
    var txtMarksNos = $('#txtMarksNos');


    txtCustomsHouse.val("");

    txtExporterName.val("");
    txtAddress.val("");
    txtAddress2.val("");
    txtAddress3.val("");
    txtAddress4.val("");
    txtAddress5.val("");
    txtBranchNo.val("");
    txtIECNo.val("");
    txtAdcode.val("");
    txtBankAccount.val("");
    txtDrawbackAccount.val("");
    txtConsigneeName.val("");
    txtConsigneeAddress.val("");
    txtConsigneeAddress1.val("");
    txtConsigneeAddress2.val("");
    txtConsigneeAddress3.val("");
    txtConsigneeAddress4.val("");
    txtCountryDischarge.val("");

    txtPortDischarge.val("");
    txtCountryFinalDestination.val("");
    txtPortFinalDestination.val("");
    txtStateExport.val("");
    txtRBIWaiverNo.val("");
    txtRBIWaiverDate.val("");
    txtMarksNos.val("");

}

function disabled_true() {

    var txtCustomsHouse = $('#txtCustomsHouse');

    var txtExporterName = $('#txtExporterName');
    var txtAddress = $('#txtAddress');
    var txtAddress2 = $('#txtAddress2');
    var txtAddress3 = $('#txtAddress3');
    var txtAddress4 = $('#txtAddress4');
    var txtAddress5 = $('#txtAddress5');
    var txtBranchNo = $('#txtBranchNo');
    var txtIECNo = $('#txtIECNo');
    var txtAdcode = $('#txtAdcode');
    var txtBankAccount = $('#txtBankAccount');
    var txtDrawbackAccount = $('#txtDrawbackAccount');
    var txtConsigneeName = $('#txtConsigneeName');
    var txtConsigneeAddress = $('#txtConsigneeAddress');
    var txtConsigneeAddress1 = $('#txtConsigneeAddress1');
    var txtConsigneeAddress2 = $('#txtConsigneeAddress2');
    var txtConsigneeAddress3 = $('#txtConsigneeAddress3');
    var txtConsigneeAddress4 = $('#txtConsigneeAddress4');
    var txtCountryDischarge = $('#txtCountryDischarge');

    var txtPortDischarge = $('#txtPortDischarge');
    var txtCountryFinalDestination = $('#txtCountryFinalDestination');
    var txtPortFinalDestination = $('#txtPortFinalDestination');
    var txtStateExport = $('#txtStateExport');
    var ddlNFEI = $('#ddlNFEI');
    var ddlType = $('#ddlType');
    var txtRBIWaiverNo = $('#txtRBIWaiverNo');
    var txtRBIWaiverDate = $('#txtRBIWaiverDate');
    var txtMarksNos = $('#txtMarksNos');

    var Button1 = $('#btn_Annexure');

    clear();

    txtCustomsHouse.attr('disabled', true);

    txtExporterName.attr('disabled', true);
    txtAddress.attr('disabled', true);
    txtAddress2.attr('disabled', true);
    txtAddress3.attr('disabled', true);
    txtAddress4.attr('disabled', true);
    txtAddress5.attr('disabled', true);
    txtBranchNo.attr('disabled', true);
    txtIECNo.attr('disabled', true);
    txtAdcode.attr('disabled', true);
    txtBankAccount.attr('disabled', true);
    txtDrawbackAccount.attr('disabled', true);
    txtConsigneeName.attr('disabled', true);
    txtConsigneeAddress.attr('disabled', true);
    txtConsigneeAddress1.attr('disabled', true);
    txtConsigneeAddress2.attr('disabled', true);
    txtConsigneeAddress3.attr('disabled', true);
    txtConsigneeAddress4.attr('disabled', true);
    txtCountryDischarge.attr('disabled', true);

    txtPortDischarge.attr('disabled', true);
    txtCountryFinalDestination.attr('disabled', true);
    txtPortFinalDestination.attr('disabled', true);
    txtStateExport.attr('disabled', true);
    ddlNFEI.attr('disabled', true);
    ddlNFEI_Disable();
}



$(function () {

    var ddl_sbType1 = $('#ddlSBType');

    ddl_sbType1.change(function (e) {
        var selectedValue1 = $(this).val();
       
        if (selectedValue1 == 'SEZ') {
            $("#txt_PortOfLoading").attr("disabled", false);

        }
        else {
            $("#txt_PortOfLoading").val('');
            $("#txt_PortOfLoading").attr("disabled", true);
        }
    });

    var dropDownList1 = $('#ddlTransportMode');

    dropDownList1.change(function (e) {
        var selectedValue = $(this).val();
        //alert(selectedValue);

        var txtCustomsHouse = $('#txtCustomsHouse');

        var txtExporterName = $('#txtExporterName');
        var txtAddress = $('#txtAddress');
        var txtAddress2 = $('#txtAddress2');
        var txtAddress3 = $('#txtAddress3');
        var txtAddress4 = $('#txtAddress4');
        var txtAddress5 = $('#txtAddress5');
        var txtBranchNo = $('#txtBranchNo');
        var txtIECNo = $('#txtIECNo');
        var txtAdcode = $('#txtAdcode');
        var txtBankAccount = $('#txtBankAccount');
        var txtDrawbackAccount = $('#txtDrawbackAccount');
        var txtConsigneeName = $('#txtConsigneeName');
        var txtConsigneeAddress = $('#txtConsigneeAddress');
        var txtConsigneeAddress1 = $('#txtConsigneeAddress1');
        var txtConsigneeAddress2 = $('#txtConsigneeAddress2');
        var txtConsigneeAddress3 = $('#txtConsigneeAddress3');
        var txtConsigneeAddress4 = $('#txtConsigneeAddress4');
        var txtCountryDischarge = $('#txtCountryDischarge');

        var txtPortDischarge = $('#txtPortDischarge');
        var txtCountryFinalDestination = $('#txtCountryFinalDestination');
        var txtPortFinalDestination = $('#txtPortFinalDestination');
        var txtStateExport = $('#txtStateExport');
        var ddlNFEI = $('#ddlNFEI');
        var ddlType = $('#ddlType');
        var txtRBIWaiverNo = $('#txtRBIWaiverNo');
        var txtRBIWaiverDate = $('#txtRBIWaiverDate');
        var txtMarksNos = $('#txtMarksNos');
        var Button1 = $('#btn_Annexure');


        if (selectedValue == 'Select') {
            document.getElementById("hdfTransport_mode").value = '';
            selectedValue = '';
        }

        if (selectedValue != '') {
            document.getElementById("txtPortDischarge").value = '';
            document.getElementById("txtPortFinalDestination").value = '';
            document.getElementById("hdfTransport_mode").value = selectedValue;
            $.ajax({
                url: "../AutoComplete_Pages/EmployeeList.asmx/f",
                data: "{ 'mail': '" + selectedValue + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8"

            });
            //KeepSessionAlive(selectedValue);
            txtCustomsHouse.attr('disabled', false);

            txtExporterName.attr('disabled', false);
            txtAddress.attr('disabled', false);
            txtAddress2.attr('disabled', false);
            txtAddress3.attr('disabled', false);
            txtAddress4.attr('disabled', false);
            txtAddress5.attr('disabled', false);
            txtBranchNo.attr('disabled', false);
            txtIECNo.attr('disabled', false);
            txtAdcode.attr('disabled', false);
            txtBankAccount.attr('disabled', false);
            txtDrawbackAccount.attr('disabled', false);
            txtConsigneeName.attr('disabled', false);
            txtConsigneeAddress.attr('disabled', false);
            txtConsigneeAddress1.attr('disabled', false);
            txtConsigneeAddress2.attr('disabled', false);
            txtConsigneeAddress3.attr('disabled', false);
            txtConsigneeAddress4.attr('disabled', false);
            txtCountryDischarge.attr('disabled', false);

            txtPortDischarge.attr('disabled', false);
            txtCountryFinalDestination.attr('disabled', false);
            txtPortFinalDestination.attr('disabled', false);
            txtStateExport.attr('disabled', false);
            ddlNFEI.attr('disabled', false);

            if (document.getElementById().value != '') {
                Button1.attr('disabled', false);
            }
            else {
                Button1.attr('disabled', true);
            }


            var btnNew = $('#btnNew');
            var btnsave = $('#btnSave');
            var btnDelete = $('#btnDelete');
            var btnUpdate = $('#btnUpdate');
            btnNew.attr('disabled', false);
            btnsave.attr('disabled', false);
            btnDelete.attr('disabled', false);
            btnUpdate.attr('disabled', false);
            ddlNFEI_Disable();

        }
        else {

            ddlNFEI_Disable();
            disabled_true();
            var btnNew = $('#btnNew');
            var btnSave = $('#btnSave');
            var btnDelete = $('#btnDelete');
            var btnUpdate = $('#btnUpdate');
            btnNew.attr('disabled', true);
            btnSave.attr('disabled', true);
            btnDelete.attr('disabled', true);
            btnUpdate.attr('disabled', true);

            jAlert('Transport_Mode Cannot be empty', 'GENERAL', function (r) { document.getElementById("ddlTransportMode").focus(); });
        }

    });
});



$(function () {

    var dropDownList1 = $('#ddlNFEI');
    var ddlType = $('#ddlType');
    var txtRBIWaiverNo = $('#txtRBIWaiverNo');
    var txtRBIWaiverDate = $('#txtRBIWaiverDate');
    var lblType = $('#lblType');
    dropDownList1.change(function (e) {

        var selectedValue = $(this).val();

        if (selectedValue != '') {

            if (selectedValue == 'Yes') {
                ddlType.attr('disabled', false);
                txtRBIWaiverNo.attr('disabled', false);
                txtRBIWaiverDate.attr('disabled', false);
                lblType.attr('disabled', false);


            }
            else if (selectedValue == 'No') {

                ddlType.attr('disabled', true);
                txtRBIWaiverNo.attr('disabled', true);
                txtRBIWaiverDate.attr('disabled', true);
                lblType.attr('disabled', true);
                // ddlType.val('');
                $('#ddlType option:eq(0)').attr('selected', 'selected');

                txtRBIWaiverNo.val("");

                txtRBIWaiverDate.val("");
                lblType.text("");
                $('#form1').validationEngine('hideAll');

            }

        }

    });

    ddlType.change(function (e) {
        var Type = $(this).val();

        if (Type != '') {

            if (Type == '01') {

                lblType.text('Free Trade Sample');
            }
            else if (Type == '02') {

                lblType.text('Diplomatic Goods');

            }
            else if (Type == '03') {

                lblType.text('Warranty Replacement');

            }
            else if (Type == '04') {

                lblType.text('Currency Chest');

            }
            else if (Type == '05') {

                lblType.text('Tourist Goods');

            }
            else if (Type == '06') {

                lblType.text('Defence Goods');

            }
            else if (Type == '07') {

                lblType.text('Gift Parcel');

            }
            else if (Type == '08') {

                lblType.text('Others');

            }
            else if (Type == '09') {

                lblType.text('Repair and Return');

            }
            else if (Type == '10') {

                lblType.text('Re Export');

            }
        }

        var selectedValue = $('#ddlNFEI').val();

        if (selectedValue != '') {

            if (selectedValue == 'Yes') {
                ddlType.attr('disabled', false);
                txtRBIWaiverNo.attr('disabled', false);
                txtRBIWaiverDate.attr('disabled', false);
                lblType.attr('disabled', false);


            }
            else if (selectedValue == 'No') {

                ddlType.attr('disabled', true);
                txtRBIWaiverNo.attr('disabled', true);
                txtRBIWaiverDate.attr('disabled', true);
                lblType.attr('disabled', true);
                // ddlType.val('');
                $('#ddlType option:eq(0)').attr('selected', 'selected');

                txtRBIWaiverNo.val("");

                txtRBIWaiverDate.val("");
                lblType.text("");
                $('#form1').validationEngine('hideAll');

            }

        }
    });

});

function OpenPopupCustom_House() {


    if (document.getElementById("hdfTransport_mode").value != '') {
        var s = document.getElementById("hdfTransport_mode").value;

        OpenPopupCustom_House_Details(s);
        return false
    }
}
function OpenPopupPort_Master(val) {

    if (document.getElementById("hdfTransport_mode").value != '') {

        OpenPopupPortDetails(val);
        return false
    }
}
function OpenPopupPort_CountrySearch_Master(val) {

    if (document.getElementById("hdfTransport_mode").value != '') {

        OpenPopupPortDetails_CountrySearch(val);
        return false
    }
}
function OpenPopupExporter_Master(val) {

    if (document.getElementById("hdfTransport_mode").value != '') {

        if (val == 'Exporter') {


            OpenPopupImporterDetails(val);
            return false

        }

        else if (val == '') {
            OpenPopupImporterDetails(val);
            return false
        }
    }
}
function OpenPopupExporter_Master_BranchSlno(val1) {

    if (document.getElementById("hdfTransport_mode").value != '') {

        var val = document.getElementById("txtIECNo").value;
        val = val.replace(/\s+$/g, '');
        if (val != '') {

            OpenPopupImporterDetails_New(val1, val);
        }

    }
}

function OpenPopupCountry_Master(val) {

    if (document.getElementById("hdfTransport_mode").value != '') {

        OpenPopupCountryOrigin(val);
        return false
    }
}

function Open_Annexure_C() {

    if (document.getElementById("hdfTransport_mode").value != '') {
        var hdfTransport_mode = document.getElementById("hdfTransport_mode").value;
        var hdn_Edit_TransportMode = document.getElementById("hdn_Edit_TransportMode").value;

        if (hdn_Edit_TransportMode != '') {

            if (hdn_Edit_TransportMode == 'Air') {

                Annexure_C_AirNew();
                return false
            }
            if (hdn_Edit_TransportMode == 'Sea') {
                Annexure_C_SeaNew();
                return false
            }
            if (hdn_Edit_TransportMode == 'Land') {
                Annexure_C_SeaNew();
                return false
            }
        }
        else {
            if (hdfTransport_mode == 'Air') {
                Annexure_C_AirNew();
                return false
            }
            if (hdfTransport_mode == 'Sea') {
                Annexure_C_SeaNew();
                return false
            }
            if (hdfTransport_mode == 'Land') {
                Annexure_C_SeaNew();
                return false
            }
        }

    }
}

$(function () {
    $('#txtCountryDischarge').focus(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txtCountryDischarge').change(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txtCountryDischarge').keyup(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txtCountryDischarge').keydown(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txtCountryFinalDestination').focus(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryFinalDestination').change(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryFinalDestination').keyup(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryFinalDestination').keydown(function () {

        var data = $(this).val();
        country_shipment(data);

    });

    $('#txtConsigneeAddress4').focus(function () {

        var data = $(this).val();
        consignee_country(data);

    });
    $('#txtConsigneeAddress4').change(function () {

        var data = $(this).val();
        consignee_country(data);

    });
    $('#txtConsigneeAddress4').keyup(function () {

        var data = $(this).val();
        consignee_country(data);

    });
    $('#txtConsigneeAddress4').keydown(function () {

        var data = $(this).val();
        consignee_country(data);

    });
});

function country(val) {

    var data = val;
    if (data == '') {
        $('#txtCountryFinalDestination').val('');
    }
    //$('#hdn_Autosearch').val(data);

    if (data.indexOf("-") != -1) {

        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txtCountryFinalDestination').val(before);
        $('#txtCountryDischarge').val(before);

    }
    else {

    }
}
function country_shipment(val) {

    var data = val;
    if (data == '') {
        $('#txtCountryFinalDestination').val('');
    }
    //$('#hdn_Autosearch').val(data);

    if (data.indexOf("-") != -1) {


        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txtCountryFinalDestination').val(before);

    }
    else {

    }
}

function consignee_country(val) {

    var data = val;
    if (data == '') {
        $('#txtConsigneeAddress4').val('');
    }
   
    if (data.indexOf("-") != -1) {
        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txtConsigneeAddress4').val(before);
      
    }
    else {

    }
}



$(function () {

    var CompanyID = document.getElementById("hdn_Comp_License").value;
    if (CompanyID == 'eri00010' || CompanyID == 'eri00810') {

        $('#txtPortDischarge').focus(function () {

            var data = $(this).val();
            Port_origin(data);

        });
        $('#txtPortDischarge').change(function () {

            var data = $(this).val();
            Port_origin(data);

        });
        $('#txtPortDischarge').keyup(function () {

            var data = $(this).val();
            Port_origin(data);

        });
        $('#txtPortDischarge').keydown(function () {

            var data = $(this).val();
            Port_origin(data);

        });
    }
});

function Port_origin(val) {

    var data = val;
    if (data == '') {
        //$('#txtCountryCode').val('');
    }
   
    $('#txtPortDischarge').val(val);
    $('#txtPortFinalDestination').val(val);

}
$(function () {
    $("#txtStateExport").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtStateExport').validationEngine('showPrompt', 'Incorrect State Export', 'error', 'topRight', true);

                        //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtStateExport').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtAdcode").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Adcode_Master_List",
                data: "{ 'mail': '" + request.term + "','IECCODE': '" + document.getElementById("txtIECNo").value + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtAdcode').validationEngine('showPrompt', 'Incorrect ADCode', 'error', 'topRight', true);

                        //jAlert('Adcode is Incorrect', 'GENERAL', function (r) { document.getElementById("txtAdcode").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtAdcode').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtConsigneeName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Consignee_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtConsigneeName').validationEngine('showPrompt', 'Incorrect Consignee Name', 'error', 'topRight', true);

                        //jAlert('ConsigneeName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtConsigneeName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtConsigneeName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtCustomsHouse").autocomplete({

        source: function (request, response) {
            document.getElementById("txtPortDischarge").value = '';
            document.getElementById("txtPortFinalDestination").value = '';
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdfTransport_mode").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtCustomsHouse').validationEngine('showPrompt', 'Incorrect CustomsHouse', 'error', 'topRight', true);
                        document.getElementById("hdn_Customhouse_chk").value = 'No';
                        //jAlert('CustomsHouse is Incorrect', 'GENERAL', function (r) { document.getElementById("txtCustomsHouse").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtCustomsHouse').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        document.getElementById("hdn_Customhouse_chk").value = 'Yes';
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

//************************************* EXPORTER NAME SEARCH BACKUP START LCD *****************************

//$(function () {
//    $("#txtExporterName").autocomplete({

//        source: function (request, response) {
//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List",
//                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("hdfTransport_mode").value + "'}",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {

//                    response(data.d);
//                    if (data.d == '') {
//                        jQuery('#txtExporterName').validationEngine('showPrompt', 'Incorrect ExporterName', 'error', 'topRight', true);

//                        //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
//                        //return false;
//                    }
//                    else {
//                        jQuery('#txtExporterName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
//                    }
//                },
//                error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    ////alert(textStatus);
//                }
//            });
//        },
//        minLength: 1

//    });
//    return false;
//    scroll: true;

//});

//************************************* EXPORTER NAME SEARCH BACKUP END *****************************

$(function () {
    $("#txtExporterName").autocomplete({

        source: function (request, response) {

            var CompanyID = document.getElementById("hdn_CompanyID").value;

            var call_url = '';
            if (CompanyID == '1' || CompanyID == '2145') {
                call_url = '../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD_Location';
            }
            else {
                call_url = '../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD';
            }

            $.ajax({
                //url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD",
               
                url: call_url,
                //data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "' ,'JobType':'" + 'Export' + "'}",

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


//************************************* CONSIGNEE NAME SEARCH BACKUP END *****************************

$(function () {
    $("#txtConsigneeName").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Consignee_Master_List_Branch_slno_STD",
                //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("hdfTransport_mode").value + "'}",
                //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                data: "{ 'mail': '" + request.term +  "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtConsigneeName').validationEngine('showPrompt', 'Incorrect Consignee Name', 'error', 'topRight', true);

                        //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtConsigneeName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
//---------------------IMPORTER----2---------------------//
//function CallServerside_Importer_2(src, dest) {
//    var ctrl = document.getElementById(src);
//    var ctrl_2 = document.getElementById(dest);
//    // call server side method

//    PageMethods.GetImporter_2(ctrl.value, ctrl_2.value, CallSuccess_Importer_2, CallFailed, dest);

//}
//function CallSuccess_Importer_2(res, destCtrl) {
//    var dest = document.getElementById(destCtrl);
//    //dest.value = res;
//    var data = res;
//    if (data.indexOf("~~") != -1) {


//        var s = data.split('~~');

//        var before = s[0];
//        var after1 = s[1];
//        var after2 = s[2];
//        var after3 = s[3];
//        var after4 = s[4];
//        var after5 = s[5];
//        var after6 = s[6];
////        var after7 = s[7];

////        alert(after7);

//        document.getElementById("txtAddress1").value = before;
//        document.getElementById("txtAddress2").value = after1;
//        document.getElementById("txtAddress3").value = after2;
//        document.getElementById("txtAddress4").value = after3;
//        document.getElementById("txtAddress5").value = after4;
//        document.getElementById("txtIECNo").value = after5;
//        document.getElementById("txtBranchNo").value = after6;
//        document.getElementById("txtAdcode").value = after7;

//    }
//    else {

//        document.getElementById("txtAddress1").value = "";
//        document.getElementById("txtAddress2").value = "";
//        document.getElementById("txtAddress3").value = "";
//        document.getElementById("txtAddress4").value = "";
//        document.getElementById("txtAddress5").value = "";
//        document.getElementById("txtIECNo").value = "";
//        document.getElementById("txtBranchNo").value = "";
//        document.getElementById("txtAdcode").value = "";
//    }
//}

//======================IMPORTER----2--END===============================================


$(function () {
    $("#txtCountryDischarge,#txtCountryFinalDestination,#txtConsigneeAddress4").autocomplete({

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
                        if (field == 'txtCountryDischarge') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Discharge', 'error', 'topRight', true);

                            //jAlert('Country Discharge is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtCountryFinalDestination') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Final Destination', 'error', 'topRight', true);

                        }
                        if (field == 'txtConsigneeAddress4') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);

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

//$(function () {
//    $("#txtPortDischarge,#txtPortFinalDestination").autocomplete({

//        source: function (request, response) {
//            var field = $(this.element).attr('id');
//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
//                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdfTransport_mode").value + "'}",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {

//                    if (data.d == '') {
//                        if (field == 'txtPortDischarge') {
//                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Discharge', 'error', 'topRight', true);

//                            //jAlert('Port Discharge is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
//                            //return false;
//                        }
//                        if (field == 'txtPortFinalDestination') {
//                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Final Destination', 'error', 'topRight', true);

//                            //jAlert('Port Final Destination is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
//                            //return false;
//                        }
//                    }
//                    else {
//                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
//                    }
//                    response(data.d);
//                },
//                error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    ////alert(textStatus);
//                }
//            });
//        },
//        minLength: 1

//    });
//    return false;
//    scroll: true;
//});
$(function () { //Modified by shanthini on 31-07-2026
    $("#txtPortDischarge,#txtPortFinalDestination").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdfTransport_mode").value + "' ,'CountryCode':'" + document.getElementById("txtCountryDischarge").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    if (data.d == '') {
                        if (field == 'txtPortDischarge') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Discharge', 'error', 'topRight', true);
                        }
                        if (field == 'txtPortFinalDestination') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Final Destination', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                    }
                    response(data.d);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        },
        select: function (event, ui) {
            var trMode = document.getElementById("hdfTransport_mode").value;
            var fieldId = $(this).attr('id');
            var selectedVal = ui.item.value;   

            if (fieldId == 'txtPortDischarge') {
                $('#txtPortFinalDestination').val(selectedVal);
                document.getElementById('hdnPortFinalDestination_chk').value = 'Yes';

                if (trMode == "Sea" || trMode == "Land") {
                    if (selectedVal.indexOf("-") != -1) {
                        var parts = selectedVal.split('-');
                        var portCode = parts[1];
                        if (portCode.length >= 2) {
                            var countryCode2Letter = portCode.substring(0, 2);
                            PageMethods.GetCountryNameByCode(countryCode2Letter, function (countryName) {
                                if (countryName != '') {
                                    $('#txtCountryDischarge').val(countryName);
                                    $('#txtCountryFinalDestination').val(countryName);
                                    document.getElementById('hdnCountryDischarge_chk').value = 'Yes';
                                    document.getElementById('hdnCountryFinalDestination_chk').value = 'Yes';
                                }
                            }, function (err) { });
                        }
                    }
                }
            }
        },
        minLength: 1
    });
    return false;
    scroll: true;
});
//******************************************** EXPORTER BRANCH SL NO SEARCH BACKUP BY LCD START ********************************


//$(function () {
//    $("#txtBranchNo").autocomplete({

//        source: function (request, response) {
//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List",
//                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("txtIECNo").value + "'}",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {
//                    response(data.d);
//                    if (data.d == '') {
//                        jQuery('#txtBranchNo').validationEngine('showPrompt', 'Incorrect BranchNo', 'error', 'topRight', true);

//                        //jAlert('BranchNo is Incorrect', 'GENERAL', function (r) { document.getElementById("txtBranchNo').focus(); });
//                        //return false;
//                    }
//                    else {
//                        jQuery('#txtBranchNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
//                    }
//                },
//                error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    ////alert(textStatus);
//                }
//            });
//        },
//        minLength: 1

//    });
//    return false;
//    scroll: true;
//});

//******************************************** EXPORTER BRANCH SL NO SEARCH BACKUP BY LCD END********************************

$(function () {
    $("#txtBranchNo").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List_STD_TYPE",
                //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("txtIECNo").value + "'}",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('txtIECNo').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtBranchNo').validationEngine('showPrompt', 'Incorrect BranchNo', 'error', 'topRight', true);

                        //jAlert('BranchNo is Incorrect', 'GENERAL', function (r) { document.getElementById("txtBranchNo').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtBranchNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtBranchSLNo").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("txtHighSeaSaleIECNo").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtBranchSLNo').validationEngine('showPrompt', 'Incorrect Branch SLNo', 'error', 'topRight', true);

                        //jAlert('Branch SLNo is Incorrect', 'GENERAL', function (r) { document.getElementById("txtBranchSLNo').focus(); });
                        //return false;
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

//******************************************* CONSIGNEE BRANCH SLNO AUTOCOMPLETE BY LCD *******************************

$(function () {
    $("#txtConsignee_BranchSlNo").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Consignee_Master_Branch_List",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("txtConsigneeName").value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtConsignee_BranchSlNo').validationEngine('showPrompt', 'Incorrect BranchNo', 'error', 'topRight', true);

                        //jAlert('BranchNo is Incorrect', 'GENERAL', function (r) { document.getElementById("txtBranchNo').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtConsignee_BranchSlNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

// call server side method
//---------------------IMPORTER----------------------//
function CallServerside_Custom_House_Name(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    PageMethods.GetCustom_House_Name(ctrl.value, CallSuccess_Custom_House_Name, CallFailed, dest);

}
function CallSuccess_Custom_House_Name(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        document.getElementById("hdn_CustomsHouse_Name").value = before;


//        if (s[0] != document.getElementById("txtCustomsHouse").value) { // if Cushouse Code is wrong s[0] return same Cushouse Code & txtCustomsHouse is same, means invalid Code
//            document.getElementById("hdn_Customhouse_chk").value = 'Yes';
//        }
//        else {
//            document.getElementById("hdn_Customhouse_chk").value = 'No';
//        }

    }
    else {
        document.getElementById("hdn_CustomsHouse_Name").value = '';

    }
}
//-------------Port Of Loading for SEZ-----------------------

function CallServerside_PortOfLoading(src, dest) {
    var ctrl = document.getElementById(src);
    PageMethods.GetCustom_House_Name(ctrl.value, CallSuccess_PortOfLoading, CallFailed, dest);

}
function CallSuccess_PortOfLoading(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        document.getElementById("hdn_PortOfLoading").value = before;

    }
    else {
        document.getElementById("hdn_PortOfLoading").value = '';
    }
}

//----------------------------


function CallServerside_Importer(src, dest) {
    var ctrl = document.getElementById(src);

    // call server side method

    PageMethods.GetImporter(ctrl.value, CallSuccess_Importer, CallFailed, dest);

}

function CallServerside_Adcode(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById("txtIECNo").value;
    
    var e = document.getElementById("ddlNFEI");
    var strUser = e.options[e.selectedIndex].text;
    if (strUser == "No") {
        PageMethods.Get_Adcode(ctrl.value, ctrl1, CallSuccess_Adcode, CallFailed, dest);
    }
}

function CallServerside_Consignee(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl2 = document.getElementById(dest);

    var BranchSlNo = document.getElementById("hdn_Consignee_brSlNo").value;
    // call server side method
//    alert(ctrl2.value);
    PageMethods.Get_ConsigneeName(ctrl.value, ctrl2.value, CallSuccess_consignee, CallFailed, dest);
}
function CallServerside_Importer_Branch(src, dest,Adcode, JOBNO) {
    var ctrl = document.getElementById(src).value;
    var ctrl1 = document.getElementById(dest).value;
    // call server side method
//    alert('l');
    if (ctrl != '') {

        var ieccode, txtImporterName;
        ieccode = document.getElementById("txtIECNo").value;
        txtImporterName = document.getElementById("txtExporterName").value;

        if (txtImporterName.length <= 0) {
            jQuery('#txtExporterName').validationEngine('showPrompt', 'ExporterName Field cannot be blank', 'error', 'topRight', true);

            //jAlert('ExporterName Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });

            //return false;


        }

        else {

            if (ieccode.length < 10) {
                jQuery('#txtIECNo').validationEngine('showPrompt', 'IEC code  Should be 10 digit numbers', 'error', 'topRight', true);

                //jAlert('IEC code  Should be 10 digit numbers', 'GENERAL', function (r) { document.getElementById("txtIECNo").focus(); });

                //return false;
            }

            else {
//                jQuery('#txtIECNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);

                PageMethods.GetImporter_Branchwise(ctrl, ctrl1, Adcode, JOBNO, CallSuccess_Importer_BranchWise, CallFailed, dest);

            }

        }
    }
}
//---------------------IMPORTER----------------------//
//---------------------SELLER------------------------//


// call server side method
function CallServerside_Importer_STD(src, dest, Adcode,JOBNO) {
    var ctrl = document.getElementById(src);
    var ctrl2 = document.getElementById(dest);
    // call server side method

    PageMethods.GetImporter_2(ctrl.value, ctrl2.value, Adcode,JOBNO, CallSuccess_Importer, CallFailed, dest);
}
// calling Importer

// set the destination textbox value with the ContactName
function CallSuccess_Importer(res, destCtrl,code) {
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
       
        document.getElementById("txtAddress").value = before;
        document.getElementById("txtAddress2").value = after1;
        document.getElementById("txtAddress3").value = after2;
        document.getElementById("txtAddress4").value = after3;
        document.getElementById("txtAddress5").value = after4;
        document.getElementById("txtIECNo").value = after5;
        document.getElementById("txtBranchNo").value = after6;
        document.getElementById("txtAdcode").value = after7;
        document.getElementById("txtBankAccount").value = after8;
        document.getElementById("txtDrawbackAccount").value = after9;
        document.getElementById("ddlType_Exp").value = after10;
        document.getElementById("txtStateExport").value = after3;

        if (document.getElementById("txtMarksNos").value == '') {
            document.getElementById("txtMarksNos").value = after11;
        }
        document.getElementById("ddl_GSTN_Type").value = after12;
        document.getElementById("txt_GSTN_ID").value = after13;
        document.getElementById("txt_IFSCCode").value = after14;

        var ddlSBType
        ddlSBType = document.getElementById("ddlSBType").value;
        if (ddlSBType == 'SEZ') {
            document.getElementById("ddl_Impexp_Type").value = after15;
        }
        else {
            document.getElementById("hdn_ExporterType").value = after15;// Condition Added by pandiyan on 07-06-2025
        }
       
    }
    else {

        document.getElementById("txtAddress").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
        document.getElementById("txtAddress5").value = "";
        document.getElementById("txtIECNo").value = "";
        document.getElementById("txtBranchNo").value = "";
        document.getElementById("txtAdcode").value = "";
        document.getElementById("txtBankAccount").value = "";
        document.getElementById("txtDrawbackAccount").value = "";
        document.getElementById("ddlType_Exp").value = "";
        document.getElementById("txtMarksNos").value = "";
        document.getElementById("ddl_GSTN_Type").value = "";
        document.getElementById("txt_GSTN_ID").value = "";
        document.getElementById("txtStateExport").value = "";
        document.getElementById("txt_IFSCCode").value = "";
        document.getElementById("ddl_Impexp_Type").value = "";
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
        var after9 = s[9];
        var after10 = s[10];
        var after11 = s[11];
        var after12 = s[12];
        var after13 = s[13];
        var after14 = s[14];

        document.getElementById("txtAddress").value = before;
        document.getElementById("txtAddress2").value = after1;
        document.getElementById("txtAddress3").value = after2;
        document.getElementById("txtAddress4").value = after3;
        document.getElementById("txtAddress5").value = after4;
        //document.getElementById("txtIECNo").value = after5;
        //document.getElementById("txtBranchNo").value = after6;
        document.getElementById("txtAdcode").value = after7;
        document.getElementById("txtBankAccount").value = after8;
        document.getElementById("txtDrawbackAccount").value = after9;

        document.getElementById("ddlType_Exp").value = after10;

        if (document.getElementById("txtMarksNos").value == '') {
            document.getElementById("txtMarksNos").value = after11;
        }
        document.getElementById("ddl_GSTN_Type").value = after12;
        document.getElementById("txt_GSTN_ID").value = after13;
        document.getElementById("txt_IFSCCode").value = after14;
    }
    else {

        document.getElementById("txtAddress").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
        document.getElementById("txtAddress5").value = "";
        //document.getElementById("txtIECNo").value = "";
        //document.getElementById("txtBranchNo").value = "";
        document.getElementById("txtAdcode").value = "";
        document.getElementById("txtBankAccount").value = "";
        document.getElementById("txtDrawbackAccount").value = "";

        document.getElementById("ddlType_Exp").value = "";
        document.getElementById("txtMarksNos").value = "";
        document.getElementById("ddl_GSTN_Type").value = "";
        document.getElementById("txt_GSTN_ID").value = "";
        document.getElementById("txt_IFSCCode").value = "";
    }
}
// calling Importer


//Importer Branch
function CallSuccess_Adcode(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {


        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];


        document.getElementById("txtAdcode").value = before;
        document.getElementById("txtBankAccount").value = after1;

    }
    else {
        //document.getElementById("txtAdcode").value = "";

        //document.getElementById("txtBankAccount").value = "";
    }

}
function CallSuccess_consignee(res, destCtrl) {
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


        document.getElementById("txtConsigneeName").value = before;
        document.getElementById("txtConsigneeAddress").value = after1;
        document.getElementById("txtConsigneeAddress1").value = after2;
        document.getElementById("txtConsigneeAddress2").value = after3;
        document.getElementById("txtConsigneeAddress3").value = after4;
        document.getElementById("txtConsigneeAddress4").value = after5;
        document.getElementById("txtConsignee_BranchSlNo").value = after6;


        var CompanyID = document.getElementById("hdn_Comp_License").value;
        if (CompanyID == 'eri00010' || CompanyID == 'eri01159' || CompanyID == 'eri01160') {
            if (document.getElementById("txtCountryDischarge").value == '') {
                document.getElementById("txtCountryDischarge").value = after5;
                document.getElementById("txtCountryDischarge").focus();
            }

            if (document.getElementById("txtCountryFinalDestination").value == '') {
                document.getElementById("txtCountryFinalDestination").value = after5;
            }
        }
    }
    else {
        //document.getElementById("txtConsigneeName").value = "";
        document.getElementById("txtConsigneeAddress").value = "";
        document.getElementById("txtConsigneeAddress1").value = "";
        document.getElementById("txtConsigneeAddress2").value = "";
        document.getElementById("txtConsigneeAddress3").value = "";
        document.getElementById("txtConsigneeAddress4").value = "";
        document.getElementById("txtConsignee_BranchSlNo").value = "";
    }

}
// alert message on some failure



// Load CountryDischarge --start
function CallServerside_CountryDischarge(src, dest) {

    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);

    PageMethods.Ser_CountryDischarge(ctrl.value, ctrl_2.value, CallSuccess_CountryDischarge, CallFailed, dest);
}
function CallSuccess_CountryDischarge(res, destCtrl) {

    if (res == "Yes") {
        document.getElementById('txtCountryDischarge').style.border = "1px solid #c8c8c8";
        document.getElementById('hdnCountryDischarge_chk').value = res;
    }
    else {
        document.getElementById('txtCountryDischarge').style.border = "1px solid Red";
        document.getElementById('hdnCountryDischarge_chk').value = res;
    }

}

function CallServerside_PortDischarge(src, dest) {

    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);

    // PageMethods.Ser_CountryDischarge(ctrl.value, ctrl_2.value, CallSuccess_PortDischarge, CallFailed, dest);
    PageMethods.Ser_CountryFinalDestination(ctrl.value, ctrl_2.value, CallSuccess_PortDischarge, CallFailed, dest);
    
}
function CallSuccess_PortDischarge(res, destCtrl) {

    if (res == "Yes") {
        document.getElementById('txtPortDischarge').style.border = "1px solid #c8c8c8";
        document.getElementById('hdnPortDischarge_chk').value = res;
    }
    else {
        document.getElementById('txtPortDischarge').style.border = "1px solid Red";
        document.getElementById('hdnPortDischarge_chk').value = res;
    }

}
// Load CountryDischarge --end

// Load CountryFinalDestination --start
function CallServerside_CountryFinalDestination(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);

    PageMethods.Ser_CountryDischarge(ctrl.value, ctrl_2.value, CallSuccess_CountryFinalDestination, CallFailed, dest);
}
function CallSuccess_CountryFinalDestination(res, destCtrl) {

    if (res == "Yes") {
        document.getElementById('txtCountryFinalDestination').style.border = "1px solid #c8c8c8";
        document.getElementById('hdnCountryFinalDestination_chk').value = res;
    }
    else {
        document.getElementById('txtCountryFinalDestination').style.border = "1px solid Red";
        document.getElementById('hdnCountryFinalDestination_chk').value = res;
    }
}
function CallServerside_PortFinalDestination(src, dest) {

    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);

    PageMethods.Ser_CountryFinalDestination(ctrl.value, ctrl_2.value, CallSuccess_PortFinalDestination, CallFailed, dest);
}
function CallSuccess_PortFinalDestination(res, destCtrl) {

    if (res == "Yes") {
        document.getElementById('txtPortFinalDestination').style.border = "1px solid #c8c8c8";
        document.getElementById('hdnPortFinalDestination_chk').value = res;
    }
    else {
        document.getElementById('txtPortFinalDestination').style.border = "1px solid Red";
        document.getElementById('hdnPortFinalDestination_chk').value = res;
    }

}
// Load CountryFinalDestination --end


// Load State_of_Export --start
function CallServerside_State_of_Export(src) {
    var ctrl = document.getElementById(src);

    PageMethods.Set_State_of_Export(ctrl.value, CallSuccess_State_of_Export, CallFailed);
}
function CallSuccess_State_of_Export(res) {

    if (res == "Yes") {
        document.getElementById('txtStateExport').style.border = "1px solid #c8c8c8";
        document.getElementById('hdn_State_of_export_chk').value = res;
    }
    else {
        document.getElementById('txtStateExport').style.border = "1px solid Red";
        document.getElementById('hdn_State_of_export_chk').value = res;
    }
}
// Load State_of_Export --end

function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}


$(function () {
    $("#txt_PortOfLoading").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",
                //                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_PortOfLoading').validationEngine('showPrompt', 'Incorrect Port Of License', 'error', 'topRight', true);
                        document.getElementById("hdn_PortOfLoading_chk").value = 'No';
                    }
                    else {
                        jQuery('#txt_PortOfLoading').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        document.getElementById("hdn_PortOfLoading_chk").value = 'Yes';
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

