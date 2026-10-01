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
    document.getElementById("Trans_product_SWConstituent_iframe").src = "../EXP_Single_Window/SW_Constituent_Details.aspx";
    document.getElementById("page-6").style.display = 'none';
}
function tab_SWProduction(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("Trans_product_SWProduction_iframe").src = "../EXP_Single_Window/SW_Producton_Details.aspx";
    document.getElementById("page-6").style.display = 'none';
}

function tab_SW_Control(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'Block';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("Trans_product_SWControl_iframe").src = "../EXP_Single_Window/SW_Control_Details.aspx";
    document.getElementById("page-6").style.display = 'none';
}

function tab_SW_Statement(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'Block';
    document.getElementById("Trans_product_Statement_iframe").src = "../EXP_Single_Window/Statement.aspx";
    document.getElementById("page-6").style.display = 'none';
}
function tab_SW_Sup_Doc(val) {
    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'Block';
    document.getElementById("Trans_product_Sup_doc_iframe").src = "../EXP_Single_Window/Supportingdoc.aspx";
}


$(document).ready(function () {

    $('#btnUpdate,#btnSave').click(function () {
        var UniqDocNo = document.getElementById("txt_Uniq_Doc_No").value;
        if (UniqDocNo.length < 16) 
        {
            jAlert('IRN Should be 16 Digit', 'IRN NUMBER', function (r) { document.getElementById("SupDoc").click(); document.getElementById("txt_Uniq_Doc_No").focus(); });
            return false;
        }

    });
});