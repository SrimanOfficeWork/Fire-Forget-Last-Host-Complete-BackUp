

function tab_page1() {

    document.getElementById("page-1").style.display = 'Block';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("Trans_export_Goods_Reg_Air_Iframe").src = "../Goods_Registration/Goods_Registration_Air.aspx";


}
function tab_page2() {



    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'Block';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';

    document.getElementById("Trans_export_invoice_Iframe").src = "../Goods_Registration/Goods_Registration_Sea.aspx";


}
function tab_page3() {




    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'Block';
    document.getElementById("page-4").style.display = 'none';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    document.getElementById("Trans_export_item_Iframe").src = "../Goods_Registration/Goods_Registration_EOU_Details.aspx";


}
function tab_page4() {




    document.getElementById("page-1").style.display = 'none';
    document.getElementById("page-2").style.display = 'none';
    document.getElementById("page-3").style.display = 'none';
    document.getElementById("page-4").style.display = 'Block';
    document.getElementById("page-5").style.display = 'none';
    document.getElementById("page-6").style.display = 'none';
    document.getElementById("page-7").style.display = 'none';
    document.getElementById("page-8").style.display = 'none';
    //document.getElementById("Trans_igm_item_Iframe").src = "../Goods_Registration/Goods_Registration_AR4Details.aspx";
    document.getElementById("Trans_igm_item_Iframe").src = "../Export/Export_AR4Details.aspx";



}

function tab_page5(url, val) {

    
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'Block';
        document.getElementById('page-5').style.display = 'Block';
        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'none';
        document.getElementById("page-8").style.display = 'none';
        //document.getElementById("Trans_igm_item_Iframe").src = url + val;
        document.getElementById("Trans_igm_item_Iframe").src = url + val + '&jobnops=' + document.getElementById('txt_Job_ps').value;
   
}