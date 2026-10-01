function tab_page_A(val) {

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';

    document.getElementById("SW_info_type").className = 'active';
    document.getElementById("SW_Cont").className = 'inactive';
    document.getElementById("SW_Pro").className = 'inactive';
    document.getElementById("SW_Con").className = 'inactive';
    document.getElementById("SW_Smt").className = 'inactive';
}

function tab_SWConstituent_B(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("SWConstituent_iframe").src = "../eRoyalMasters/SW_Constituent_Master.aspx";
    document.getElementById("SW_info_type").className = 'inactive';
    document.getElementById("SW_Cont").className = 'active';
    document.getElementById("SW_Pro").className = 'inactive';
    document.getElementById("SW_Con").className = 'inactive';
    document.getElementById("SW_Smt").className = 'inactive';

}
function tab_SWProduction_C(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("SWProduction_iframe").src = "../eRoyalMasters/SW_Producton_Master.aspx";
    document.getElementById("SW_info_type").className = 'inactive';
    document.getElementById("SW_Cont").className = 'inactive';
    document.getElementById("SW_Pro").className = 'active';
    document.getElementById("SW_Con").className = 'inactive';
    document.getElementById("SW_Smt").className = 'inactive';
}

function tab_SW_Control_D(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'Block';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("SWControl_iframe").src = "../eRoyalMasters/SW_Control_Master.aspx";
    document.getElementById("SW_info_type").className = 'inactive';
    document.getElementById("SW_Cont").className = 'inactive';
    document.getElementById("SW_Pro").className = 'inactive';
    document.getElementById("SW_Con").className = 'active';
    document.getElementById("SW_Smt").className = 'inactive';
}

function tab_SW_Statement_E(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'Block';
    document.getElementById("Statement_iframe").src = "../eRoyalMasters/Statement_Master.aspx";

    document.getElementById("SW_info_type").className = 'inactive';
    document.getElementById("SW_Cont").className = 'inactive';
    document.getElementById("SW_Pro").className = 'inactive';
    document.getElementById("SW_Con").className = 'inactive';
    document.getElementById("SW_Smt").className = 'active';
}

