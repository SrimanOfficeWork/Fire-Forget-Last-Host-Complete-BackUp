
function G_tab_page_1() {
    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById('page-1').style.display = 'Block';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
    }
    else {
        happycode();
    }
}
function G_tab_page_2() {

    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'Block';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
    }
    else {
        happycode();
    }
}
function G_tab_page_3() {

    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'Block';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
    }
    else {
        happycode();
    }
}

function G_tab_page_4() {

    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'Block';
        document.getElementById('page-5').style.display = 'none';
    }
    else {
        happycode();
    }
}
function G_tab_page_5() {

    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'Block';
    }
    else {
        happycode();
    }
}

function B_G_tab_page1() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    
    document.getElementById("page-6").style.display = 'block';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'none';

    document.getElementById("Page_A").className = 'active';
    document.getElementById("Page_B").className = 'inactive';
    document.getElementById("Page_C").className = 'inactive';
    document.getElementById("Page_D").className = 'inactive';
    document.getElementById("Page_E").className = 'inactive';
    document.getElementById("Page_F").className = 'inactive';
    document.getElementById("Page_G").className = 'inactive';
    document.getElementById("Page_H").className = 'inactive';
    document.getElementById("Page_I").className = 'inactive';
}
function B_G_tab_page2() {

    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'block';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'none';

    document.getElementById("Page_A").className = 'inactive';
    document.getElementById("Page_B").className = 'active';
    document.getElementById("Page_C").className = 'inactive';
    document.getElementById("Page_D").className = 'inactive';
    document.getElementById("Page_E").className = 'inactive';
    document.getElementById("Page_F").className = 'inactive';
    document.getElementById("Page_G").className = 'inactive';
    document.getElementById("Page_H").className = 'inactive';
    document.getElementById("Page_I").className = 'inactive';
}
function B_G_tab_page3() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'block';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'none';

    document.getElementById("Page_A").className = 'inactive';
    document.getElementById("Page_B").className = 'inactive';
    document.getElementById("Page_C").className = 'active';
    document.getElementById("Page_D").className = 'inactive';
    document.getElementById("Page_D").className = 'inactive';
    document.getElementById("Page_E").className = 'inactive';
    document.getElementById("Page_F").className = 'inactive';
    document.getElementById("Page_G").className = 'inactive';
    document.getElementById("Page_H").className = 'inactive';
    document.getElementById("Page_I").className = 'inactive';
}
function B_G_tab_page4() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'block';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'none';

    document.getElementById("Page_A").className = 'inactive';
    document.getElementById("Page_B").className = 'inactive';
    document.getElementById("Page_C").className = 'inactive';
    document.getElementById("Page_D").className = 'active';
    document.getElementById("Page_E").className = 'inactive';
    document.getElementById("Page_F").className = 'inactive';
    document.getElementById("Page_G").className = 'inactive';
    document.getElementById("Page_H").className = 'inactive';
    document.getElementById("Page_I").className = 'inactive';
}
/*
function B_G_tab_page5() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'block';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';

    document.getElementById("Page_A").className = 'inactive';
    document.getElementById("Page_B").className = 'inactive';
    document.getElementById("Page_C").className = 'inactive';
    document.getElementById("Page_D").className = 'inactive';
    document.getElementById("Page_E").className = 'active';
    document.getElementById("Page_F").className = 'inactive';
    document.getElementById("Page_G").className = 'inactive';
    document.getElementById("Page_H").className = 'inactive';
}
*/
function B_G_tab_page5(Bill_Inv_No) {

    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'block';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'none';

    document.getElementById("Page_A").className = 'inactive';
    document.getElementById("Page_B").className = 'inactive';
    document.getElementById("Page_C").className = 'inactive';
    document.getElementById("Page_D").className = 'inactive';
    document.getElementById("Page_E").className = 'active';
    document.getElementById("Page_F").className = 'inactive';
    document.getElementById("Page_G").className = 'inactive';
    document.getElementById("Page_H").className = 'inactive';
    document.getElementById("Page_I").className = 'inactive';

    document.getElementById("Billing_Acc_Annexure_Grid_Iframe").src = "../Accounts_Sales/GST_Annexure_Gridview.aspx?Bill_Inv_No=" + encodeURIComponent(Bill_Inv_No);

}
function B_G_tab_page6() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'block';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'none';

    document.getElementById("Page_A").className = 'inactive';
    document.getElementById("Page_B").className = 'inactive';
    document.getElementById("Page_C").className = 'inactive';
    document.getElementById("Page_D").className = 'inactive';
    document.getElementById("Page_E").className = 'inactive';
    document.getElementById("Page_F").className = 'active';
    document.getElementById("Page_G").className = 'inactive';
    document.getElementById("Page_H").className = 'inactive';
    document.getElementById("Page_I").className = 'inactive';
}
function B_G_tab_page7() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'block';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'none';

    document.getElementById("Page_A").className = 'inactive';
    document.getElementById("Page_B").className = 'inactive';
    document.getElementById("Page_C").className = 'inactive';
    document.getElementById("Page_D").className = 'inactive';
    document.getElementById("Page_E").className = 'inactive';
    document.getElementById("Page_F").className = 'inactive';
    document.getElementById("Page_G").className = 'active';
    document.getElementById("Page_H").className = 'inactive';
    document.getElementById("Page_I").className = 'inactive';
}
function B_G_tab_page8() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'block';
    document.getElementById("page-14").style.display = 'none';

    document.getElementById("Page_A").className = 'inactive';
    document.getElementById("Page_B").className = 'inactive';
    document.getElementById("Page_C").className = 'inactive';
    document.getElementById("Page_D").className = 'inactive';
    document.getElementById("Page_E").className = 'inactive';
    document.getElementById("Page_F").className = 'inactive';
    document.getElementById("Page_G").className = 'inactive';
    document.getElementById("Page_H").className = 'active';
    document.getElementById("Page_I").className = 'inactive';
}
function B_G_tab_page9() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';

    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById("page-12").style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'block';

    document.getElementById("Page_A").className = 'inactive';
    document.getElementById("Page_B").className = 'inactive';
    document.getElementById("Page_C").className = 'inactive';
    document.getElementById("Page_D").className = 'inactive';
    document.getElementById("Page_E").className = 'inactive';
    document.getElementById("Page_F").className = 'inactive';
    document.getElementById("Page_G").className = 'inactive';
    document.getElementById("Page_H").className = 'inactive';
    document.getElementById("Page_I").className = 'active';
}
//--------------------Acc--Fin------------------------------------------------------
function tab_page_AR() {
    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
}
function tab_page_AP() {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("Id_AR_Iframe").src = "../Accounts_CHA_Import/Acc_AP_Invoice.aspx";
}
function tab_page_PR(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';
    document.getElementById("Id_PR_Iframe").src = "../Accounts_CHA_Import/Acc_Payment_Request.aspx?IMP_EXP=" + val;
}
//-----------------E--------------------------
function tab_page_E_AR() {
    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
}

function tab_page_E_AP() {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("Id_AR_Iframe").src = "../Accounts_CHA_Export/Acc_AP_Invoice.aspx";
}
function tab_page_E_PR() {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';
    //  document.getElementById("Id_PR_Iframe").src = "../Accounts_CHA_Import/Acc_Charge_Details.aspx";
}
//--------------------CHA--Export------------------------------------------------------
function tab_page1() {

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
}

function charge_tab_page2() {

    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("Charge_Id_Iframe").src = "../Accounts_CHA_Export/Acc_Charge_Details.aspx";
}

function Exp_Inv_tab_page3() {


    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("Inv_Id_Iframe").src = "../Accounts_CHA_Export/Acc_Invoice_Charge.aspx";
}
function charge_tab_page4() {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'Block';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("Inv_Rpt_Iframe").src = "../Accounts_General_Reports/Acc_Job_Revenue_Cost_Rpt.aspx";
}

function Exp_NoInv_tab_page5() {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'Block';
    document.getElementById("No_Invoice_Id_Iframe").src = "../Accounts_CHA_Export/Accounts_No_Invoice_Details.aspx";
}

function open_convert_inv(val, val1, val2) {

    NewWindow1('../Accounts_CHA_Export/Acc_Convert_Invoice.aspx?Charge=' + val + '&Charge_Type=' + val1 + '&Container_Type=' + val2 + '', 'List', '850', '330', 'yes');

}


//--------------------CHA--Import------------------------------------------------------
function Imp_charge_tab_page2() {


    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("Charge_Id_Iframe").src = "../Accounts_CHA_Import/Acc_Charge_Details.aspx";
}

function Imp_Inv_tab_page3() {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("Inv_Id_Iframe").src = "../Accounts_CHA_Import/Acc_Invoice_Charge.aspx";
}
function Imp_NoInv_tab_page5() {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'Block';
    document.getElementById("No_Invoice_Id_Iframe").src = "../Accounts_CHA_Import/Accounts_No_Invoice_Details.aspx";
}

function open_convert_inv_Imp(val, val1, val2) {

    NewWindow1('../Accounts_CHA_Import/Acc_Convert_Invoice.aspx?Charge=' + val + '&Charge_Type=' + val1 + '&Container_Type=' + val2 + '', 'List', '850', '330', 'yes');
}

function other_tab_page1() {

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
}
function other_charge_tab_page2() {

    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'Block';
        document.getElementById("Charge_Id_Iframe").src = "../Accounts_Others_Entry/Acc_Charge_Details.aspx";
    }
    else {
        happycode();
    }
}

//------------------------------------Credit Note------------------------------------------------------//
function Cr_page1() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById("page-6").style.display = 'block';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById('page-12').style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById('page-14').style.display = 'none';

    document.getElementById("Cr_Page_1").className = 'active';
    document.getElementById("Cr_Page_2").className = 'inactive';
    document.getElementById("Cr_Page_3").className = 'inactive';
    document.getElementById("Cr_Page_4").className = 'inactive';
    document.getElementById("Cr_Page_5").className = 'inactive';
    document.getElementById("Cr_Page_6").className = 'inactive';
    document.getElementById("Cr_Page_7").className = 'inactive';
    document.getElementById("Cr_Page_8").className = 'inactive';
    document.getElementById("Cr_Page_9").className = 'inactive';

}

function Cr_page2() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'block';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById('page-12').style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById('page-14').style.display = 'none';

    document.getElementById("Cr_Page_1").className = 'inactive';
    document.getElementById("Cr_Page_2").className = 'active';
    document.getElementById("Cr_Page_3").className = 'inactive';
    document.getElementById("Cr_Page_4").className = 'inactive';
    document.getElementById("Cr_Page_5").className = 'inactive';
    document.getElementById("Cr_Page_6").className = 'inactive';
    document.getElementById("Cr_Page_7").className = 'inactive';
    document.getElementById("Cr_Page_8").className = 'inactive';
    document.getElementById("Cr_Page_9").className = 'inactive';

}

function Cr_page3() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById('page-12').style.display = 'block';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById('page-14').style.display = 'none';

    document.getElementById("Cr_Page_1").className = 'inactive';
    document.getElementById("Cr_Page_2").className = 'inactive';
    document.getElementById("Cr_Page_3").className = 'active';
    document.getElementById("Cr_Page_4").className = 'inactive';
    document.getElementById("Cr_Page_5").className = 'inactive';
    document.getElementById("Cr_Page_6").className = 'inactive';
    document.getElementById("Cr_Page_7").className = 'inactive';
    document.getElementById("Cr_Page_8").className = 'inactive';
    document.getElementById("Cr_Page_9").className = 'inactive';

}

function Cr_page4() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'Block';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById('page-12').style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById('page-14').style.display = 'none';

    document.getElementById("Cr_Page_1").className = 'inactive';
    document.getElementById("Cr_Page_2").className = 'inactive';
    document.getElementById("Cr_Page_3").className = 'inactive';
    document.getElementById("Cr_Page_4").className = 'active';
    document.getElementById("Cr_Page_5").className = 'inactive';
    document.getElementById("Cr_Page_6").className = 'inactive';
    document.getElementById("Cr_Page_7").className = 'inactive';
    document.getElementById("Cr_Page_8").className = 'inactive';
    document.getElementById("Cr_Page_9").className = 'inactive';


}

function Cr_page5() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'Block';
    document.getElementById('page-12').style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById('page-14').style.display = 'none';

    document.getElementById("Cr_Page_1").className = 'inactive';
    document.getElementById("Cr_Page_2").className = 'inactive';
    document.getElementById("Cr_Page_3").className = 'inactive';
    document.getElementById("Cr_Page_4").className = 'inactive';
    document.getElementById("Cr_Page_5").className = 'active';
    document.getElementById("Cr_Page_6").className = 'inactive';
    document.getElementById("Cr_Page_7").className = 'inactive';
    document.getElementById("Cr_Page_8").className = 'inactive';
    document.getElementById("Cr_Page_9").className = 'inactive';

}


function Cr_page6() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById('page-12').style.display = 'none';
    document.getElementById("page-13").style.display = 'Block';
    document.getElementById('page-14').style.display = 'none';

    document.getElementById("Cr_Page_1").className = 'inactive';
    document.getElementById("Cr_Page_2").className = 'inactive';
    document.getElementById("Cr_Page_3").className = 'inactive';
    document.getElementById("Cr_Page_4").className = 'inactive';
    document.getElementById("Cr_Page_5").className = 'inactive';
    document.getElementById("Cr_Page_6").className = 'active';
    document.getElementById("Cr_Page_7").className = 'inactive';
    document.getElementById("Cr_Page_8").className = 'inactive';
    document.getElementById("Cr_Page_9").className = 'inactive';
}


function Cr_page7() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'Block';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById('page-12').style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'none';


    document.getElementById("Cr_Page_1").className = 'inactive';
    document.getElementById("Cr_Page_2").className = 'inactive';
    document.getElementById("Cr_Page_3").className = 'inactive';
    document.getElementById("Cr_Page_4").className = 'inactive';
    document.getElementById("Cr_Page_5").className = 'inactive';
    document.getElementById("Cr_Page_6").className = 'inactive';
    document.getElementById("Cr_Page_7").className = 'active';
    document.getElementById("Cr_Page_8").className = 'inactive';
    document.getElementById("Cr_Page_9").className = 'inactive';
}



function Cr_page8() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'Block';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById('page-12').style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'none';

    document.getElementById("Cr_Page_1").className = 'inactive';
    document.getElementById("Cr_Page_2").className = 'inactive';
    document.getElementById("Cr_Page_3").className = 'inactive';
    document.getElementById("Cr_Page_4").className = 'inactive';
    document.getElementById("Cr_Page_5").className = 'inactive';
    document.getElementById("Cr_Page_6").className = 'inactive';
    document.getElementById("Cr_Page_7").className = 'inactive';
    document.getElementById("Cr_Page_8").className = 'active';
    document.getElementById("Cr_Page_9").className = 'inactive';
}

function Cr_page9() {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("page-9").style.display = 'none';
    document.getElementById("page-10").style.display = 'none';
    document.getElementById("page-11").style.display = 'none';
    document.getElementById('page-12').style.display = 'none';
    document.getElementById("page-13").style.display = 'none';
    document.getElementById("page-14").style.display = 'Block';

    document.getElementById("Cr_Page_1").className = 'inactive';
    document.getElementById("Cr_Page_2").className = 'inactive';
    document.getElementById("Cr_Page_3").className = 'inactive';
    document.getElementById("Cr_Page_4").className = 'inactive';
    document.getElementById("Cr_Page_5").className = 'inactive';
    document.getElementById("Cr_Page_6").className = 'inactive';
    document.getElementById("Cr_Page_7").className = 'inactive';
    document.getElementById("Cr_Page_8").className = 'inactive';
    document.getElementById("Cr_Page_9").className = 'active';
}