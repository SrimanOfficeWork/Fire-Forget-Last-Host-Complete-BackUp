function tab_page1(val) {

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';

}

function tab_SWConstituent(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';


    document.getElementById("Trans_product_SWConstituent_iframe").src = "../IMP_Single_Window/SW_Constituent_Details.aspx";
    document.getElementById("page-6").style.display = 'none';
}
function tab_SWProduction(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
//    document.getElementById("page-6").style.display = 'none';

    document.getElementById("Trans_product_SWProduction_iframe").src = "../IMP_Single_Window/SW_Producton_Details.aspx";
    document.getElementById("page-6").style.display = 'none';
}

function tab_SW_Control(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'Block';
    document.getElementById("page-5").style.display = 'none';
////    document.getElementById("page-6").style.display = 'none';

    document.getElementById("Trans_product_SWControl_iframe").src = "../IMP_Single_Window/SW_Control_Details.aspx";
    document.getElementById("page-6").style.display = 'none';
}

function tab_SW_Statement(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'Block';
    document.getElementById("page-5").style.display = 'none';
////    document.getElementById("page-6").style.display = 'none';

    document.getElementById("Trans_product_SWControl_iframe").src = "../IMP_Single_Window/Statement.aspx";
}
function tab_SW_Sup_Doc(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'Block';
    document.getElementById("page-5").style.display = 'none';
////    document.getElementById("page-6").style.display = 'Block';

    document.getElementById("Trans_product_SWControl_iframe").src = "../IMP_Single_Window/SW_Supportingdoc.aspx";
}