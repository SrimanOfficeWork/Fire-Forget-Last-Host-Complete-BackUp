var win = null;
function NewWindow(w, h) {
    LeftPosition = (screen.width) ? Math.max(0, (screen.width - w) / 2) : 0;
    TopPosition = (screen.height) ? Math.max(0, (screen.height - h) / 2) : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //win = window.open(mypage, myname, settings);
    //win = dhtmlmodal.open(mypage, 'iframe', myname, '', settings)

    return settings;
}

//adcode master search
function opennewadcode1(val) {
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../modalfiles/adcodemasterNew - Normal Popup Window.htm', '', 'width=470px,height=550px,center=1,resize=0,scrolling=0')
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx?ADCODE_ID=' + val + '', '', 'width=457px, height=485px,margin-left=420px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx?ADCODE_ID=' + val + '', '', NewWindow('457', '450'))

}
function opennewadcodenew() {
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../modalfiles/adcodemasterNew - Normal Popup Window.htm', '', 'width=470px,height=550px,center=1,resize=0,scrolling=0')
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx', '', 'width=457px, height=485px,margin-left=420px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx', '', NewWindow('457', '450'))

}

function opennewadcodenew_Export() {
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx', '', 'width=455px, height=450px,margin-left=420px,resize=0, scrolling=0')

    w = '457';
    h = '450';
    LeftPosition = (screen.width) ? (screen.width - w) / 3 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx', '', settings)

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Annexure_C_Air.aspx', '', NewWindow('955', '400'))

}
//client master
function opennewclientnew() {
  
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master.aspx', '', NewWindow('750', '567'))
}

function opennewclientupdate(val, name) {
    var doc = new DOMParser().parseFromString(name, "text/html");
   
    //    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master.aspx?IMP_EXP_ID=' + val + '&Name=' + name + '', '', NewWindow('750', '357'))
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master.aspx?IMP_EXP_ID=' + val + '&Name=' + doc.documentElement.textContent + '', '', NewWindow('750', '567'))
}

function openclient_Masternew() {
    w = '750';
    h = '1020';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 8 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master.aspx', '', settings)

}

function opennewclientnew_N(val) {
    w = '979';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master_N.aspx?Page=' + val + '', '', settings)
}

function opennewclientupdate_N(val, name) {
    w = '979';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    var doc = new DOMParser().parseFromString(name, "text/html");
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master_N.aspx?IMP_EXP_ID=' + val + '&Name=' + doc.documentElement.textContent + '', '', settings)
}

function opennewclientnew_N_JobSearch(val) {
    w = '979';
    h = '550';
    LeftPosition = (screen.width) ? (screen.width - w) / 80 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master_N.aspx?Page=' + val + '', '', settings)
}

function opennewclientupdate_N_JobSearch(val, name, IEC , type) {
    w = '979';
    h = '550';
    LeftPosition = (screen.width) ? (screen.width - w) / 80 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    var doc = new DOMParser().parseFromString(name, "text/html");
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master_N.aspx?IMP_EXP_ID=' + val + '&Name=' + doc.documentElement.textContent + '&IEC=' + IEC + '&type=' + type + '', '', settings)
}


//product master
function Product_Master() {
    adcodewindow = window.open("../eRoyalMasters/Product_Import_Master.aspx", "mywindow1", "modal=1,status=1,resizable=0,width=875,height=530,top=150,menubar=0,left=200,top=40,bottom=160,ScrollBars=0");
}

function openproductnew() {
    // productMasterwindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_Import_Master.aspx', '', 'width=700px,height=685px,margin-left=270px,resize=0,scrolling=0')
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_Import_Master.aspx', '', NewWindow('700', '555'))
}

function Product_Master_update(val) {

    //mywindow1 = window.open("../eRoyalMasters/Product_Import_Master.aspx?PRODUCT_IMPORT_ID=" + val + "", "mywindow1", "modal=1,status=1,resizable=0,width=875,height=530,top=150,menubar=0,left=200,top=40,bottom=160,ScrollBars=0");
    //productMasterwindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_Import_Master.aspx?PRODUCT_IMPORT_ID=' + val + '', '', 'width=700px,height=685px,margin-left=270px,resize=0,scrolling=0')
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_Import_Master.aspx?PRODUCT_IMPORT_ID=' + val + '', '', NewWindow('700', '555'))
}

//consignee master


function opennewconsigneenew() {

    //ConsigneeMasterwindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Consignee_Master.aspx', '', 'width=455px, height=450px,margin-left=420px, resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Consignee_Master.aspx', '', NewWindow('450', '409'))

}

function ConsigneeMaster_update(val) {
    //ConsigneeMasterwindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Consignee_Master.aspx?CONSIGNEE_ID=' + val + '', '', 'width=455px, height=450px,margin-left=420px, resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Consignee_Master.aspx?CONSIGNEE_ID=' + val + '', '', NewWindow('450', '409'))
}

function opennewconsigneenew_Export() {
    w = '450';
    h = '399';
    LeftPosition = (screen.width) ? (screen.width - w) / 3 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Consignee_Master.aspx', '', settings)
}


function Consignee_Masterupdate_N_JobSearch(name, Slno, type) {
    w = '450';
    h = '399';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    var doc = new DOMParser().parseFromString(name, "text/html");
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Consignee_Master.aspx?Name=' + doc.documentElement.textContent + '&Slno=' + Slno + '&type=' + type + '', '', settings)
}

//BUYER Master
function opennewbuyernew() {

    //ConsigneeMasterwindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Consignee_Master.aspx', '', 'width=455px, height=450px,margin-left=420px, resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Buyer_Master.aspx', '', NewWindow('450', '319'))

}

function BuyerMaster_update(val) {
    //ConsigneeMasterwindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Consignee_Master.aspx?CONSIGNEE_ID=' + val + '', '', 'width=455px, height=450px,margin-left=420px, resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Buyer_Master.aspx?BUYER_ID=' + val + '', '', NewWindow('450', '319'))

}
function opennewconsigneenew_Export_Buyer() {
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx', '', 'width=455px, height=450px,margin-left=420px,resize=0, scrolling=0')
    w = '450';
    h = '319';
    LeftPosition = (screen.width) ? (screen.width - w) / 4 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Buyer_Master.aspx', '', settings)
}

function Buyer_Masterupdate_N_JobSearch(name, type) {
    w = '450';
    h = '319';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    var doc = new DOMParser().parseFromString(name, "text/html");
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Buyer_Master.aspx?Name=' + doc.documentElement.textContent + '&type=' + type + '', '', settings)
}


//Exchange Master


function opennewExchangenew() {

    

     //ExchangeMasterwindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/Exchange_Master.aspx', '', NewWindow('451', '340'))
    adcodewindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../ERoyal_Admin_Master/Exchange_Master.aspx', '', NewWindow('451', '340'))  


}
function Exchange_Master_update(val) {

    //ExchangeMasterwindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/Exchange_Master.aspx?EXCHANGE_ID=' + val + '', '', NewWindow('451', '340'))
    adcodewindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../ERoyal_Admin_Master/Exchange_Master.aspx?EXCHANGE_ID=' + val + '', '', NewWindow('451', '340'))  

}

//Supplier Master




function openSupplier_Masternew() {
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx', '', 'width=455px, height=450px,margin-left=420px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx', '', NewWindow('450', '370'))

}


function openSupplier_Masternew1() {
   
    w = '450';
    h = '370';
    LeftPosition = (screen.width) ? (screen.width - w) / 4 : 0;
    TopPosition = (screen.height) ? (screen.height - h) /200: 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx', '', settings)

}


function Supplier_Master_update(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx?SUP_ID=' + val + '', '', 'width=455px, height=450px,margin-left=420px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx?SUP_ID=' + val + '', '', NewWindow('450', '370'))
}

function Supplier_Masterupdate_N_JobSearch( name, Slno, type) {
    w = '450';
    h = '370';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    var doc = new DOMParser().parseFromString(name, "text/html");
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Suppliermaster.aspx?Name=' + doc.documentElement.textContent + '&Slno=' + Slno + '&type=' + type + '', '', settings)
}
//-------------------------------------------Transaction-----------------------------------------------------------------------//

//--------------General_Details-------------------------//
function openGeneral_Search_New(val) {
   
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    // h = '545';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx?Page='+ val +'', '', settings)
   
}
function General_Details_Update(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx?JOBID=' + val + '', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    //h = '545';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx?JOBID=' + val + '', '', settings)


}

//--------------General_Details-------------------------//


//------------------------------------Transaction - Export-------------------------------------------------//

//--------------General_Details-------------------------//

function Export_General__New(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/General.aspx?Page=' + val + '', '', settings)

} 
function Export_General_Update(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx?JOBID=' + val + '', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/General.aspx?JOBID=' + val + '', '', settings)


}
function Export_SB_Entry_Update(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx?JOBID=' + val + '', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_SB_Entry.aspx?JOBID=' + val + '', '', settings)


}

//--------- Export Annexure_C_Air --------------//
//--------- Export Goods Registration --------------//

function Export_Goods_General_New(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', 'Goods_General.aspx?Page=' + val + '', '', settings)

}
function Export_Goods_General_Update(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx?JOBID=' + val + '', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', 'Goods_General.aspx?JOBID=' + val + '', '', settings)
}
//--------- Export Goods Registration --------------//



function Annexure_C_AirNew() {
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx', '', 'width=455px, height=450px,margin-left=420px,resize=0, scrolling=0')

    w = '820';
    h = '355';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Annexure_C_Air.aspx', '', settings)

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Annexure_C_Air.aspx', '', NewWindow('955', '400'))

}

//--------- Export Annexure_C_Sea --------------//

function Annexure_C_SeaNew() {
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx', '', 'width=455px, height=450px,margin-left=420px,resize=0, scrolling=0')

    w = '757';
    h = '392';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Annexure_C_Sea.aspx', '', settings)

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Annexure_C_Air.aspx', '', NewWindow('955', '400'))

}
function open_Exbond_Details(val) {

    w = '920';
    h = '490';
    LeftPosition = (screen.width) ? (screen.width - w) / 12 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 30 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('adcode', 'iframe', '../Transaction/WareHouse_Move_Exbond.aspx?EXBND_JOBID=' + val + '', '', settings)

}
//function opennew_Import_report1(val) {
//   
//    w = '710';
//    h = '578';
//    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
//    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
//    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=1';
//    adcodewindow = dhtmlmodal.open('import_checklist', 'iframe', '../../Report/Import/Import_ReportViewer.aspx?jobno=' + val + '', '', settings)

//}
//function opennew_Export_report1(val) {
//   
//    w = '710';
//    h = '578';
//    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
//    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
//    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=1';
//    adcodewindow = dhtmlmodal.open('import_checklist', 'iframe', '../../Report/Export/Export_ReportViewer.aspx?jobno=' + val + '', '', settings)

//}

//-------------------------------------------Company Master-----------------------------------------------------------------------//

//--------------Company_Details-------------------------//
function Company_Details_New(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Admin/Company_Master.aspx?Page=' + val + '', '', settings)

}
function Company_Details_Update(val,val1) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx?JOBID=' + val + '', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Admin/Company_Master.aspx?COMPANY_ID=' + val + '&COMPANY_LICENSE=' + val1 + '', '', settings)


}
//---------------------------USER DETAILS------------------------------------//
function User_Details_New(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/User_Master.aspx?Page=' + val + '', '', settings)

}
function User_Details_Update(val,val1) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx?JOBID=' + val + '', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '1120';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/User_Master.aspx?COMPANY_ID=' + val + '&USER_CREATION_ID=' + val1 + '', '', settings)


}
//---------------------------BE_ENTRY DETAILS------------------------------------//
function BE_Entry_Details(val, val1) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx?JOBID=' + val + '', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/BE_Entry_General.aspx?JOBID=' + val + '&JOBNO=' + val1 + '', '', settings)


}
function openmailsetting(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Read_Mail/Mail_Setting.aspx', '', NewWindow('457', '393'))

}

function openmailsettingupdate(val) {
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../Read_Mail/Mail_Setting.aspx?MAIL_SETTING_ID=' + val + '', '', NewWindow('457', '393'))

}

function open_currencyconverter(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/Currency_Converter.aspx', '', NewWindow('457', '200'))

}

function open_defaultsettings(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/Default_Settings.aspx', '', NewWindow('457', '200'))

}

function open_Warehouse_Exbond_Details(val) {

    w = '920';
    h = '490';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('adcode', 'iframe', '../Transaction/WareHouse_Move_Exbond.aspx?EXBND_JOBID=' + val + '', '', settings)


}

function open_GATT_Details() {

    w = '1024';
    h = '800';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 65 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('adcode', 'iframe', '../Transaction/GATT_form.aspx', '', settings)

}

//--------------Internal mail-------------------------//
function openInternal_mail() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Internal_Mail/Inbox_search.aspx', '', settings)

}
function opencomposemsg() {
    //compose = dhtmlmodal.open('ADcode', 'iframe', '../Internal_Mail/Mail_Compose.aspx', '', NewWindow('457', '393'))
    w = '700';
    h = '500';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('adcode', 'iframe', '../Internal_Mail/Mail_Compose.aspx', '', settings)

}
function opencomposemsg_update(val) {

    
    //compose = dhtmlmodal.open('ADcode', 'iframe', '../Internal_Mail/Mail_Compose.aspx', '', NewWindow('457', '393'))
//    w = '700';
//    h = '490';
//    LeftPosition = (screen.width) ? (screen.width - w) / 8 : 0;
//    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
//    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
//    compose = dhtmlmodal.open('adcode', 'iframe', '../Internal_Mail/Mail_Compose.aspx?inbox_id=' + val + '', '', settings)

}
//LICENSE MASTER SEARCH

function opennewlicense(val) {
       adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/License_Master.aspx?LICENSE_ID=' + val + '', '', NewWindow('457', '393'))

}
function opennewlicensenew() {
     adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/License_Master.aspx', '', NewWindow('457', '393'))

}
function openchangepassword() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/Change_Password.aspx', '', NewWindow('457', '240'))

}
//--------------GSP & CERTIFICATE ORIGIN-------------------------//
function open_GSP() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_GSP_Front_Details.aspx', '', settings)

}
function open_Certificate_origin() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_GSP_certificateorigin.aspx', '', settings)

}

function open_Invoice() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_Invoice_Report_Details.aspx', '', settings)

}


function open_delivery_chellan() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Delivery_Challen_Details.aspx', '', settings)

}

function open_duty_intimation() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Duty_Intimation.aspx', '', settings)

}
//--------------GSP & CERTIFICATE ORIGIN-------------------------//
//Non standard Master


function opennew_nonstandardcur_master() {



    //ExchangeMasterwindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/Exchange_Master.aspx', '', NewWindow('451', '340'))
    adcodewindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/Non_standard_currecy_master.aspx', '', NewWindow('451', '340'))


}
function Nonstandardcur_master_update(val) {

    //ExchangeMasterwindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/Exchange_Master.aspx?EXCHANGE_ID=' + val + '', '', NewWindow('451', '340'))
    adcodewindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/Non_standard_currecy_master.aspx?NON_STD_ID=' + val + '', '', NewWindow('451', '340'))

}

function open_Import_Nform_New() {

    w = '990';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Import_Report/Import_N_Form.aspx?Page=' + 'New' + '', '', settings)

}

function open_Import_Nform_Update(val) {

    w = '1000';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Import_Report/Import_N_Form.aspx?Page=' + val + '', '', settings)
}



function open_Branch_Selection(val) {
    // Bootstrap "modal-dialog-centered" style popup: fixed overlay + flexbox centering
    // (#pmBranchOverlay / #pmBranchFrame, defined in E_royal_Impex_Main_01.aspx), instead
    // of the old dhtmlmodal/dhtmlwindow popup. Only that page calls this function.
    var overlay = document.getElementById('pmBranchOverlay')
    var frame = document.getElementById('pmBranchFrame')
    if (overlay && frame) {
        frame.src = '../Users/Change_Branch.aspx'
        overlay.classList.add('open')
    }
}

function open_ManualBE_Rpt_2() {

    w = '1000';
    h = '590';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Import_ManualBE.aspx', '', settings)

}

function DBBackuandrestore() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/DB_Backup_Restore.aspx', '', NewWindow('457', '240'))
}

function DBBackup_Client() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Admin/DB_Backup_Client.aspx', '', NewWindow('457', '240'))
}

function Open_Import_KKForm() {

    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Import_KKForm.aspx', '', settings)

}

function open_SDF_Rpt_1(val) {

    w = '1000';
    h = '590';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', val, '', settings)

}


function Open_SDF_Export_Declaration() {

    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../EXPORT_SDF/Export_Value_Declaration.aspx', '', settings)

}

function Open_Export_PackingList() {

    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_PackingList.aspx', '', settings)

}

function OpenSVB_Relation_New() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Svb_Relation_Master.aspx', '', NewWindow('550', '410'))
}
function OpenSVB_Relation(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Svb_Relation_Master.aspx?SVB_ID=' + val + '', '', NewWindow('550', '410'))
}

function open_Import_DutyCalculator() {

    w = '570';
    h = '460';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('adcode', 'iframe', '../Transaction/Import_DutyCalculator.aspx', '', settings)

}

function OpenPopupTransshipPermit_New() {

    w = '990';
    h = '565';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Transhipment_PermitForm.aspx', '', settings)

}

function open_Import_Undertaking() {

    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Import_Undertaking_Form.aspx', '', settings)

}

function open_BL_Generation() {

    w = '1000';
    h = '590';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Export/Export_BL_Generation.aspx', '', settings)

}

function open_ShippingBill_DBK_Duty() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_ShippingBill_DBK_DutyFree.aspx', '', settings)

}

function open_TB_ShippingBill() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Import_TB_ShippingBill.aspx', '', settings)

}

//Dynamic Report --- S

function open_Dynamic_Report_new() {
    adcodewindow = dhtmlmodal.open('Dynamic Report', 'iframe', '../DSR_Template/Dynamic_Report_Design.aspx', '', NewWindow('1000', '582'))
}

function open_Dynamic_Report_Update(val) {
    adcodewindow = dhtmlmodal.open('Dynamic Report', 'iframe', '../DSR_Template/Dynamic_Report_Design.aspx?T_ID=' + val + '', '', NewWindow('1000', '582'))
}

//End Dynamic Report ---


//--------------BL EXPORT Multiple Search-----start--------------------//
function open_BL_Con_Search_New(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../BL_Generation/Export_BL_Consolidate.aspx?Page=' + val + '', '', settings)

}

function open_BL_Con_Search_Update(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../BL_Generation/Export_BL_Consolidate.aspx?Page=' + val + '', '', settings)

}


function open_BL_Container_New(val) {

    var Save_container, Exp_Name, R_ID;
    Save_container = document.getElementById("HD_Showcon").value;
    Exp_Name = document.getElementById("HDEXP_Name").value;
    R_ID = document.getElementById("HDR_ID").value;


    if (Save_container == 'SAVED') {
        adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../BL_Generation/Export_Multiple_BL_Generation_Container.aspx?Exp_Name=' + Exp_Name + ' &R_ID=' + R_ID + '', '', 'width=962, height=500px,margin-left=10px,margin-top=20px,resize=0, scrolling=0')

    }
    else {

        jAlert('Save Report', 'Container Details');
    }


}

function Export_Multiple_BL_Job_Status(val) {

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../BL_Generation/Export_Multiple_Pending_Jobs.aspx', '', 'width=959, height=525px,margin-left=13px,margin-top=18px,resize=0, scrolling=0')
}
function Export_Multiple_BL_Job_Status_Menu(val) {

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../BL_Generation/Export_Multiple_Pending_Jobs.aspx', '', 'width=959, height=525px,margin-left=150px,margin-top=18px,resize=0, scrolling=0')
}


function Export_Multiple_BL_rpt(val) {

    var Job_Id = document.getElementById("HDupdate_id").value;

    if (Job_Id != '') {

        var Exp_Name = document.getElementById("ddlExp_name").value;
        var Tr_mode = document.getElementById("ddltr_mode").value;
        var Ref_Id = document.getElementById("txtId").value;
        var Job_Id = document.getElementById("HDupdate_id").value;

        adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Report/Export_BL_Consolidate_rpt.aspx?Exp_Name=' + Exp_Name + '&Tr_mode=' + Tr_mode + '&Ref_Id=' + Ref_Id + '&Job_Id=' + Job_Id + '', '', 'width=959, height=525px,margin-left=13px,margin-top=18px,resize=0, scrolling=0')
    }
    else {
        jAlert('Save Report after Generate', 'Add Annexure', function (r) { document.getElementById("ddlExp_name").focus(); });
    }
}
function Export_Multiple_BL_rpt_NewWindow(val) {

    var Job_Id = document.getElementById("HDupdate_id").value;

    if (Job_Id != '') {

        var Exp_Name = document.getElementById("ddlExp_name").value;
        var Tr_mode = document.getElementById("ddltr_mode").value;
        var Ref_Id = document.getElementById("txtId").value;
        var Job_Id = document.getElementById("HDupdate_id").value;

        NewWindow1('../Report/Export_BL_Consolidate_rpt.aspx?Exp_Name=' + Exp_Name + '&Tr_mode=' + Tr_mode + '&Ref_Id=' + Ref_Id + '&Job_Id=' + Job_Id + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Add Annexure', function (r) { document.getElementById("ddlExp_name").focus(); });
    }
} //--------------BL EXPORT Multiple Search-----End--------------------//


//--------------EXPORT BL GENERATION GENERAL Search-----start--------------------//
function open_BL_Normal_Search_New(val) {

    w = '1000';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../BL_Generation/Export_BL_Generation.aspx?Page=' + val + '', '', settings)
}

function open_BL_Normal_Search_Update(val) {

    w = '1000';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../BL_Generation/Export_BL_Generation.aspx?Page=' + val + '', '', settings)

}


function Export_BL_Job_Status(val) {

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../BL_Generation/EXP_BL_Job_Status.aspx', '', 'width=959, height=525px,margin-left=13px,margin-top=18px,resize=0, scrolling=0')
   
}

function Export_BL_Job_Status_Menu(val) {

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../BL_Generation/EXP_BL_Job_Status.aspx', '', 'width=959, height=525px,margin-left=150px,margin-top=18px,resize=0, scrolling=0')

}

//--------------EXPORT BL GENERATION GENERAL Search-----End--------------------//



//-------------EXPORT BL ANNEXURE GENERAL SEARCH---START-----------------------//

function Open_Annnexure_New(val, name) {

    w = '784';
    h = '575';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../BL_Generation/Export_BL_Generation_Annexure.aspx?Page=' + val + '&Name=' + name + '', '', settings)
    //           var jobno = document.getElementById("<%=hdn_JOBNO1.ClientID %>").value;
    //           alert(jobno);
}

function open_BL_Annexure_Search_Update(val, name) {

    w = '785';
    h = '575';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../BL_Generation/Export_BL_Generation_Annexure.aspx?Page=' + val + '&Name=' + name + '', '', settings)
    //    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Export/Export_BL_Generation.aspx', '', '', settings)
    //        alert(val+','+name);
}


//-------------EXPORT BL ANNEXURE GENERAL SEARCH---END------------------------//


//--------------EXPORT CERTIFICATE OF ORIGIN NORMAL Search-----start--------------------//
function open_COO_Normal_Search_New(val) {

    w = '1000';
    h = '590';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Export/Export_GSP_certificateorigin.aspx?Page=' + val + '', '', settings)
    //    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Export/Export_BL_Generation.aspx', '', '', settings)

}

function open_COO_Normal_Search_Update(val) {

    w = '1000';
    h = '590';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Export/Export_GSP_certificateorigin.aspx?Page=' + val + '', '', settings)

}


//--------------EXPORT CERTIFICATE OF ORIGIN NORMAL Search-----End--------------------//

//--------------EXPORT GSP SEARCH -----start--------------------//
function open_GSP_Normal_Search_New(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Export/Export_GSP_Front_Details.aspx?Page=' + val + '', '', settings)
    //    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Export/Export_BL_Generation.aspx', '', '', settings)

}

function open_GSP_Normal_Search_Update(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Export/Export_GSP_Front_Details.aspx?Page=' + val + '', '', settings)

}

//--------------EXPORT GSP Search-----End--------------------//



//------------Start Billing---------------//

function opennew_chargemaster_edit(val) {
    
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../modalfiles/adcodemasterNew - Normal Popup Window.htm', '', 'width=470px,height=550px,center=1,resize=0,scrolling=0')
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx?ADCODE_ID=' + val + '', '', 'width=457px, height=485px,margin-left=420px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Billing/Charge_Master.aspx?CHARGE_ID=' + val + '', '', NewWindow('457', '393'))

}

function opennew_chargemaster() {
   
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../modalfiles/adcodemasterNew - Normal Popup Window.htm', '', 'width=470px,height=550px,center=1,resize=0,scrolling=0')
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx', '', 'width=457px, height=485px,margin-left=420px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Billing/Charge_Master.aspx', '', NewWindow('457', '393'))

}


function opennew_quotemaster_edit(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../modalfiles/adcodemasterNew - Normal Popup Window.htm', '', 'width=470px,height=550px,center=1,resize=0,scrolling=0')
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx?ADCODE_ID=' + val + '', '', 'width=457px, height=485px,margin-left=420px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Billing/Quotation_Master.aspx?QUOTE_ID=' + val + '', '', NewWindow('457', '393'))

}

function opennew_quotemaster() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../modalfiles/adcodemasterNew - Normal Popup Window.htm', '', 'width=470px,height=550px,center=1,resize=0,scrolling=0')
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx', '', 'width=457px, height=485px,margin-left=420px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Billing/Quotation_Master.aspx', '', NewWindow('457', '393'))

}

function open_Quotation_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing/Quotation_Master_New.aspx', '', settings)
}

function open_Quotation_Search_Update(val, val2, val3, Val4) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Quotation', 'iframe', '../Billing/Quotation_Master_New.aspx?Page=' + val + '&Client_Name=' + val2 + '&Sh_Type=' + val3 + '&Branch_No=' + Val4 + '', '', settings)
}


function open_Expense_Entry() {

    w = '1000';
    h = '590';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    //    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing/Expense_Entry.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing/Expense_Entry.aspx', '', settings)

}

function open_Invoice_New(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing/Invoice.aspx', '', settings)
}


function open_Exp_Inv_Job_Search_New(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing_Exp/Exp_Invoice_Job.aspx', '', settings)
}

/* GST*/

function open_GST_Exp_Inv_Job_Search_New(val) {

    w = '1200';
    h = '640';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing_Exp/GST_Exp_Invoice_Job.aspx', '', settings)
}

function open_Inv_Job_Search_Update(val, val2) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing_Exp/Exp_Invoice_Job.aspx?Page=' + val + '&Billinvno=' + val2 + '', '', settings)

}

function open_GST_EXP_Inv_Job_Search_Update(val, val2) {

    w = '1200';
    h = '660';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing_Exp/GST_Exp_Invoice_Job.aspx?Page=' + val + '&Billinvno=' + val2 + '', '', settings)
}

function Export_Billing_Job_Rpt(val) {

    var Job_Id = document.getElementById("HD_Bill_Jobno").value;

    if (Job_Id != '') {
        NewWindow1('../Billing_Exp_Rpt/Bill_Export_Job_rpt.aspx?Bill_Invo=' + Job_Id + '&Tax_Mode=' + val + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlExp_name").focus(); });
    }

}


/*Import Billing invoice Start*/
function open_Imp_Inv_Job_Search_New(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/Imp_Invoice_Job.aspx', '', settings)
}

function open_Imp_Inv_Job_Search_Update(val, val2) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/Imp_Invoice_Job.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}


function open_GST_Imp_Inv_Job_Search_Update(val, val2) {

    w = '1203';
    h = '660';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/GST_Imp_Invoice_Job.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}

function Import_Billing_Job_Rpt(val) {

    var Job_Id = document.getElementById("HD_Bill_Jobno").value;

    if (Job_Id != '') {
        NewWindow1('../Billing_Imp_Rpt/Bill_Import_Job_rpt.aspx?Bill_Invo=' + Job_Id + '&Tax_Mode=' + val + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlExp_name").focus(); });
    }
}

//function GST_Import_Billing_Job_Rpt(val) {

//    var Job_Id = document.getElementById("HD_Bill_Jobno").value;

//    if (Job_Id != '') {
//        NewWindow1('../Billing_Imp_Rpt/GST_Bill_Import_Job_rpt.aspx?Bill_Invo=' + Job_Id + '&Tax_Mode=' + val + '', 'List', '870', '1024', 'yes');
//    }
//    else {
//        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlExp_name").focus(); });
//    }
//}
function GST_Import_Billing_Job_Rpt(val) {

    var Job_Id = document.getElementById("HD_Bill_Jobno").value;
    var Demo_Model_Code = document.getElementById("HD_Demo_Model").value;

    if (Job_Id != '') {
        //NewWindow1('../Billing_Imp_Rpt/GST_Bill_Import_Job_rpt.aspx?Bill_Invo=' + Job_Id + '&Tax_Mode=' + val + '', 'List', '870', '1024', 'yes');
        NewWindow1('../Billing_Imp_Rpt/GST_Bill_Import_Job_rpt.aspx?Bill_Invo=' + Job_Id + '&Tax_Mode=' + val + '&Demo_Model_Code=' + Demo_Model_Code + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlExp_name").focus(); });
    }
}

/* IGST */


function open_GST_Imp_Inv_Job_Search(val) {

    w = '1203';
    h = '660';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/GST_Imp_Invoice_Job.aspx', '', settings)
}

/*Import Billing invoice End*/


//------------End Billing---------------//


//------------Start Mapping Master--------------//

function Mapping_Master() {
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx', '', 'width=455px, height=450px,margin-left=420px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Admin/Mapping_Master.aspx', '', NewWindow('450', '170'))

}

function Mapping_Master_Edit(val) {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Suppliermaster.aspx?SUP_ID=' + val + '', '', 'width=455px, height=450px,margin-left=420px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Admin/Mapping_Master.aspx?MAPPING_ID=' + val + '', '', NewWindow('450', '170'))

}

//------------End Mapping Master--------------//


function open_defaultsettings_Client(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/Default_Client_Settings.aspx', '', NewWindow('457', '200'))

}



function open_Report_client_Masternew(val) {
    w = '750';
    h = '507';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Report_Client_Master.aspx?TYPE=' + val + '', '', 'width=750px, height=480px,margin-left=80px,resize=0,scrolling=0')

}


function open_Report_Agent_Vessel_Masternew(val) {
    w = '750';
    h = '507';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Report_Agent_Vessel_Master.aspx?TYPE=' + val + '', '', 'width=750px, height=480px,margin-left=100px,resize=0,scrolling=0')

}

function open_Report_Ocean_Vessel_Masternew(val) {
    w = '457';
    h = '393';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Report_Ocean_Vessel_Master.aspx?TYPE=' + val + '', '', 'width=457px, height=393px,margin-left=240px,resize=0,scrolling=0')

}


// EXPORT Product master

function open_EXPORT_ProductNew() {
    // productMasterwindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_Import_Master.aspx', '', 'width=700px,height=685px,margin-left=270px,resize=0,scrolling=0')
    //    productMasterwindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Export_Product_Master.aspx', '', 'width=450px,height=390px,margin-left=300px,margin-top=0px,resize=0,scrolling=0')

    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Export_Product_Master.aspx', '', NewWindow('450', '350'))

}

function Product_Export_Master_update(val) {
    //mywindow1 = window.open("../eRoyalMasters/Product_Import_Master.aspx?PRODUCT_IMPORT_ID=" + val + "", "mywindow1", "modal=1,status=1,resizable=0,width=875,height=530,top=150,menubar=0,left=200,top=40,bottom=160,ScrollBars=0");

    //productMasterwindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_Import_Master.aspx?PRODUCT_IMPORT_ID=' + val + '', '', 'width=700px,height=685px,margin-left=270px,resize=0,scrolling=0')
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Export_Product_Master.aspx?PRODUCT_EXPORT_ID=' + val + '', '', NewWindow('450', '350'))
}

//********************Start Combined Jobs**************************//

function open_EXP_Con_Search_New(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Combined_EXP_Jobs/Export_Job_Consolidate.aspx?Page=' + val + '', '', settings)
}

function open_EXP_Con_Search_Update(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Combined_EXP_Jobs/Export_Job_Consolidate.aspx?Page=' + val + '', '', settings)

}

//********************End Combined Jobs**************************//


//********************Start Docket Entry**********************//

function Docket_General_New(val) {

    w = '990';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Docket_Entry/Docket_General.aspx?Page=' + val + '', '', settings)
}
/// <reference path="../Docket/Docket_General.aspx" />

function Docket_Search_Update(val, val2) {

    w = '990';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Docket_Entry/Docket_General.aspx?Page=' + val + '&Billinvno=' + val2 + '', '', settings)
    //      adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Admin/Company_Master.aspx?COMPANY_ID=' + val + '&COMPANY_LICENSE=' + val1 + '', '', settings)
}

//**********************End Docket Entry**********************//


function contactdetails() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/Contact_Details.aspx', '', NewWindow('457', '240'))

}
function Error_Code() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/IMP_Error_Code.aspx', '', NewWindow('700', '240'))

}

function open_Billing_company_Masternew(val) {
    w = '750';
    h = '507';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../Billing/Billing_Company_Master.aspx', '', 'width=750px, height=480px,margin-left=300px,resize=0,scrolling=0')

}

function Charge_Order_by(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing/Charge_Order_by.aspx', '', settings)
}


function open_Import_Despatch() {

    w = '990';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Despatch/Imp_Despatch.aspx', '', settings)

}

function open_Inv_Copy() {
    w = '900';
    h = '370';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Invoice Copy', 'iframe', '../Transaction/Imp_Inv_Copy.aspx', '', settings)
}
function open_Item_Copy(val) {
    w = '900';
    h = '370';

    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Item Copy', 'iframe', '../Transaction/Imp_Item_Copy.aspx?Inv_slno=' + val + '', '', settings)
}

function open_Indev_Nissan_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', 'width=500px, height=210px,margin-left=220px,margin-top=90px,resize=0,scrolling=0')
}


function Open_Import_LTR_Format() {

    w = '990';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../BOXCO_Rpt/LTR_DOC.aspx', '', settings)

}

function open_Excel_Upload_SVB() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload_SVB.aspx', '', 'width=500px, height=150px,margin-left=220px,margin-top=90px,resize=0,scrolling=0')
}


function open_Export_Bulk_License_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Export/Export_Bulk_LicenseUpoad.aspx', '', 'width=500px, height=150px,margin-left=220px,margin-top=90px,resize=0,scrolling=0')
}


function open_Indev_Excel_Upload_Thailand() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../eRoyalMasters/INV_XL_upload_Thailand.aspx', '', 'width=500px, height=150px,margin-left=420px,margin-top=90px,resize=0,scrolling=0')
}


function openproductnew_INDEV() {
    // productMasterwindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_Import_Master.aspx', '', 'width=700px,height=685px,margin-left=270px,resize=0,scrolling=0')
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Indev_Product_Import_Master.aspx', '', NewWindow('700', '520'))

}

function Product_Master_update_INDEV(val) {

    //mywindow1 = window.open("../eRoyalMasters/Product_Import_Master.aspx?PRODUCT_IMPORT_ID=" + val + "", "mywindow1", "modal=1,status=1,resizable=0,width=875,height=530,top=150,menubar=0,left=200,top=40,bottom=160,ScrollBars=0");
    //productMasterwindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_Import_Master.aspx?PRODUCT_IMPORT_ID=' + val + '', '', 'width=700px,height=685px,margin-left=270px,resize=0,scrolling=0')
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Indev_Product_Import_Master.aspx?PRODUCT_IMPORT_ID=' + val + '', '', NewWindow('700', '522'))
}

function open_e_Sugam_Report() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../NIPPON/e_Sugam_Report.aspx', '', settings)

}

function open_DGFT_Mnaufacturer_Report(val) {

    NewWindow1('../NIPPON/DGFT_Manufacturing_ReportViewer.aspx?Value=' + val + '', 'List', '810', '1024', 'yes');
}



function open_Export_Despatch_Search_New(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Despatch/Export_Despatch.aspx?Page=' + val + '', '', settings)

}

function open_Export_Despatch_Search_Update(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Despatch/Export_Despatch.aspx?Page=' + val + '', '', settings)

}


function open_Imp_DSR_State_I_New(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('DSR Stage I', 'iframe', '../INDEV/DSR_Stage_I.aspx', '', settings)
}

function open_Imp_DSR_State_II_New(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('DSR Stage II', 'iframe', '../INDEV/DSR_Stage_II.aspx', '', settings)
}
function open_Imp_DSR_Stage_III_New(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('DSR Stage III', 'iframe', '../INDEV/DSR_Stage_III.aspx', '', settings)
}
function open_Imp_DSR_Stage_IV_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR Stage IV', 'iframe', '../INDEV/DSR_Stage_IV.aspx', '', settings)
}
function open_Imp_DSR_Stage_V_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR Stage V', 'iframe', '../INDEV/DSR_Stage_V.aspx', '', settings)
}

function open_IMP_Single_Window_Copy(val) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Single Window Copy', 'iframe', '../IMP_Single_Window/Imp_Item_Single_Window_Copy.aspx?Inv_slno=' + val + '', '', settings)
}

function open_IMP_Single_Window_Bulk_Entry(val, val2, val3) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('Single Window Copy', 'iframe', '../IMP_Single_Window/Item_SingleWindow_Entry_2016.aspx?Inv_slno=' + val2 + '&Item_slno=' + val + '&RITC_No=' + val3 + '', '', settings)
    adcodewindow = dhtmlmodal.open('Single Window Copy', 'iframe', '../IMP_Single_Window/Item_SingleWindow_Entry_2016.aspx?Inv_slno=' + '' + '&Item_slno=' + '' + '&RITC_No=' + val3 + '', '', settings)
}

function open_AD_Code_Bulk_Entry(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('AD Code IEC', 'iframe', '../eRoyalMasters/Client_Master_Bulk_Entry.aspx', '', settings)
}

function open_EXP_Prouduct_Master(val) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export Product Master Updation', 'iframe', '../Export/Export_Product_Master_Bulk.aspx', '', settings)
}


function opennew_Import_licensenew() {
    // adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Import_License_Master.aspx', '', NewWindow('757', '420'))
    w = '1200';
    h = '600';
    LeftPosition = (screen.width - w) / 2;
    TopPosition = ((screen.height - h) / 2) - 85;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('License', 'iframe', '../eRoyalMasters/Import_License_Master.aspx', '', settings)
}
function opennew_Import_license(val) {
    // adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Import_License_Master.aspx', '', NewWindow('757', '420'))
    w = '1200';
    h = '600';
    LeftPosition = (screen.width - w) / 2;
    TopPosition = ((screen.height - h) / 2) - 85;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('License', 'iframe', '../eRoyalMasters/Import_License_Master.aspx?LICENSE_ID=' + val, '', settings)
}

function open_SQL_Query_Execution(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('SQL', 'iframe', '../Admin/SQL_Execute.aspx', '', settings)
}

function open_EXP_Inv_Excel_Upload(val) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Export_XL/Export_INV_Gen_Excel.aspx', '', settings)
}

function open_Export_Bulk_License_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Export/Export_Bulk_LicenseUpoad.aspx', '', 'width=500px, height=150px,margin-left=220px,margin-top=90px,resize=0,scrolling=0')
}

function open_Exp_Job_Clearance_Search_Update(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Job Clearance', 'iframe', '../Paramount/Exp_Job_Clearance.aspx?Page=' + val + '', '', settings)
}
function open_Exp_Job_Clearnce_Search_New(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Clearance', 'iframe', '../Paramount/Exp_Job_Clearance.aspx', '', settings)
}

function open_paramount_job_clearance_HistoryNew(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../ParaMount/Job_Clearance_History.aspx?Page=' + val + '', '', settings)
}

function open_paramount_job_clearance_History_Update(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Job History', 'iframe', '../ParaMount/Job_Clearance_History.aspx?Page=' + val + '', '', settings)
}


function open_IMP_Inv_Excel_Upload(val) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Import_XL/Import_INV_Gen_Excel.aspx', '', settings)
}

function open_Letter_Temp(Val) {

    w = '990';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    if (Val == 'I') {
        adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../LetterTemplate/MyEditor.aspx', '', settings)
    }
    else {
        adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../LetterTemplate/EXP_MyEditor.aspx', '', settings)
    }

}


function open_EXP_Prouduct_Item_Move(val) {
    w = '400';
    h = '150';
    LeftPosition = (screen.width) ? (screen.width - w) / 4 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 30 : 0;

    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export Product Master Updation', 'iframe', '../Export/Export_Item_Move.aspx', '', settings)
}


function open_Bill_Pending(Val) {
    w = '825';
    h = '490';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/Pending_Invoice_ListPopup.aspx?Page=' + Val + '', '', settings)
}

function open_Bill_Pending_Export(Val) {
    w = '825';
    h = '490';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Exp/Exp_Pending_Invoice_ListPopup.aspx?Page=' + Val + '', '', settings)
}

function open_IMP_Prouduct_Item_Move(val) {
    w = '400';
    h = '150';
    LeftPosition = (screen.width) ? (screen.width - w) / 4 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 30 : 0;

    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export Product Master Updation', 'iframe', '../Transaction/Import_Item_Move.aspx', '', settings)
}

function open_AWB_Search_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('AWB', 'iframe', '../Air_WayBill/EXP_Air_WayBill.aspx', '', settings)
}
function open_AWB_Search_Update(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('AWB', 'iframe', '../Air_WayBill/EXP_Air_WayBill.aspx?Page=' + val + '', '', settings)
}

function open_Import_Despatch_Search_Update(val1, val2) {
    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Despatch', 'iframe', '../Despatch/Imp_Despatch.aspx?Page=' + val1 + '&Jobno=' + val2 + '', '', settings)
}
function open_Import_Despatch_Search_New(val) {
    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Despatch', 'iframe', '../Despatch/Imp_Despatch.aspx?Page=' + val + '', '', settings)
}

function open_Change_Mode(val) {
    w = '940';
    h = '470';
    LeftPosition = (screen.width) ? (screen.width - w) / 30 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 8 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Branch Change', 'iframe', '../Job_Duplicate/Imp_Branch_to_Branch.aspx?Jobno=' + val + '', '', settings)
}
function open_Exp_Change_Mode(val) {
    w = '940';
    h = '470';
    LeftPosition = (screen.width) ? (screen.width - w) / 30 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 8 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Branch Change', 'iframe', '../Job_Duplicate/Exp_Branch_to_Branch.aspx?Jobno=' + val + '', '', settings)
}

function opennew_PortMaster_UsrWise() {
    adcodewindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/Port_Master_UserWise.aspx', '', NewWindow('451', '280'))
}
function Port_Mster_UsrWise_update(val) {
    adcodewindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/Port_Master_UserWise.aspx?PORT_ID=' + val + '', '', NewWindow('451', '280'))
}

function open_Live_Chat(val) {
    w = '751';
    h = '325';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 30 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Live Chat', 'iframe', '../Internal_Mail/Live_Query.aspx', '', settings)
}
function open_Billing_Inv_Copy(val) {
    w = '450';
    h = '250';

    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 10 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Item Copy', 'iframe', '../Billing_Imp/Bill_Inv_Copy.aspx', '', settings)
}

function open_Billing_EXP_Inv_Copy(val) {
    w = '450';
    h = '250';

    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 10 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Item Copy', 'iframe', '../Billing_Exp/Bill_Inv_Copy.aspx', '', settings)
}

function e_VGM_Request_Job_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../ODEX/e_VGM_Request_Job.aspx', '', settings)
}

function e_VGM_Request_Job_Update(val, val2) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../ODEX/e_VGM_Request_Job.aspx?Page=' + escape(val) + '&jobno=' + val2 + '', '', settings)
}

function open_JobWise_Excel_Upload(val) {
    w = '938';
    h = '495';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Import_XL/Import_JoBWise_Excel.aspx', '', settings)
}

function open_EXPORT_JobWise_Excel_Upload(val) {
    w = '938';
    h = '495';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Export_XL/Export_JoBWise_Gen_Excel.aspx', '', settings)
}

function open_Imp_Item_Lic_Copy(val) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Item Copy', 'iframe', '../Transaction/Imp_Item_Lic_Copy.aspx?Inv_slno=' + val + '', '', settings)
}

function open_Multiple_Inv() {
    w = '990';
    h = '470';
    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -15 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Split Multiple Invoice', 'iframe', '../Transaction/Multiple_Inv_Split.aspx', '', settings)
}

function GST_Export_Billing_Job_Rpt(val) {

    var Job_Id = document.getElementById("HD_Bill_Jobno").value;

    if (Job_Id != '') {
        NewWindow1('../Billing_Exp_Rpt/GST_Bill_Export_Job_rpt.aspx?Bill_Invo=' + Job_Id + '&Tax_Mode=' + val + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlExp_name").focus(); });
    }

}

function opennew_GST_chargemaster_edit(val) {

    adcodewindow = dhtmlmodal.open('Charge Master', 'iframe', '../GST_Billing_Master/Charge_Master.aspx?CHARGE_ID=' + val + '', '', NewWindow('500', '500'))
}
function opennew_GST_chargemaster() {
    adcodewindow = dhtmlmodal.open('Charge Master', 'iframe', '../GST_Billing_Master/Charge_Master.aspx', '', NewWindow('500', '500'))
}

function open_EXPORT_Inv_Copy() {
    w = '900';
    h = '370';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Invoice Copy', 'iframe', '../Export/Exp_Inv_Copy.aspx', '', settings)
}

function opennew_WareHouse_Master_UsrWise() {
    adcodewindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/WareHouse_Master_UserWise.aspx', '', NewWindow('451', '310'))
}
function WareHouse_Mster_UsrWise_update(val) {
    adcodewindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/WareHouse_Master_UserWise.aspx?WH_ID=' + val + '', '', NewWindow('451', '310'))
}

//  EXP THIRDPARTY MASTER
function opennew_ThirdPartyMaster() {

    //adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Exp_ThirdParty_Master.aspx', '', NewWindow('450', '369'))
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Exp_ThirdParty_Master.aspx', '', NewWindow('500', '370'))

}
function ThirdPartyMaster_update(val) {

    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Exp_ThirdParty_Master.aspx?THIRDPARTY_ID=' + val + '', '', NewWindow('450', '369'))

}

//  IMP THIRDPARTY MASTER
function opennew_IMPORT_ThirdPartyMaster() {

    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Imp_ThirdParty_Master.aspx', '', NewWindow('450', '399'))

}
function IMPORT_ThirdPartyMaster_update(val) {

    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Imp_ThirdParty_Master.aspx?THIRDPARTY_ID=' + val + '', '', NewWindow('450', '399'))

}

function open_GST_Quotation_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../GST_Billing_Master/Quotation_Master_Entry.aspx', '', settings)
}


function open_GST_Quotation_Search_Update(val, val2, val3, val4, val5) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Quotation', 'iframe', '../GST_Billing_Master/Quotation_Master_Entry.aspx?Page=' + val + '&Client_Name=' + val2 + '&Branch_No=' + val3 + '&Ref_ID=' + val4 + '&Ship_Type=' + val5 + '', '', settings)
}



function open_Imp_Job_Clearnce_Search_New(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Clearance', 'iframe', '../Paramount/Imp_Job_Clearance.aspx', '', settings)
}



function open_Imp_Job_Clearance_Search_Update(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Job Clearance', 'iframe', '../Paramount/Imp_Job_Clearance.aspx?Page=' + val + '', '', settings)
}

function open_GST_Imp_Inv_no_Edit(val) {

    w = '670';
    h = '280';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/GST_Imp_Invoice_No_Edit.aspx', '', settings)
}


//--------------COVERING LETTER Search-----start--------------------//
function open_CoveringLetter_Search_New(val) {

    w = '784';
    h = '575';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing/Covering_Letter.aspx?Page=' + val + '', '', settings)
    //    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Billing/Covering_Letter.aspx', '', settings)
}

function open_CoveringLetter_Search_Update(val) {

    w = '784';
    h = '575';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing/Covering_Letter.aspx?Page=' + val + '', '', settings)

}
//--------------COVERING LETTER Search-----END--------------------//

function open_GST_Exp_Inv_no_Edit(val) {
    w = '670';
    h = '280';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Exp/GST_Exp_Invoice_No_Edit.aspx', '', settings)
}

function open_GST_Bill_Pending_Export(Val) {
    w = '825';
    h = '490';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Exp/Exp_Pending_Invoice_ListPopup.aspx?Page=' + Val + '', '', settings)
}

function open_IMP_CP_Excel_Upload(val) {
    w = '950';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 170 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Import CP Excel Upload', 'iframe', '../Import_XL/Import_CP_Excel.aspx', '', settings)
}

function open_Bill_Con_Search_New(val) {
    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing_Imp_Exp_GST_Rpt/Bill_Consolidate.aspx?Page=' + val + '', '', settings)
}
function open_Bill_Con_Search_Update(val, val2) {
    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing_Imp_Exp_GST_Rpt/Bill_Consolidate.aspx?Page=' + val + '&Type=' + val2 + '', '', settings)
}

function open_Bill_Con_Rpt(val) {
    var Job_Id = document.getElementById("HDupdate_id").value;
    var TYPE_IMP_EXP = document.getElementById("Hd_IMP_EXP").value;

    if (Job_Id != '') {
        NewWindow1('../Billing_Imp_Exp_GST_Rpt/GST_Bill_Consolidate_rpt.aspx?Bill_Invo=' + Job_Id + '&TYPE_IMP_EXP=' + TYPE_IMP_EXP + '&INV_ANX=' + val + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
    }
}

function open_GST_Bill_Pending_Import(Val) {
    w = '825';
    h = '490';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/Imp_Pending_Invoice_ListPopup.aspx?Page=' + Val + '', '', settings)
}

function open_GST_Imp_Exp_Inv_Job_Search_Update(val, val2, val3) {
    //escape(val) 
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp_Exp_GST_Rpt/GST_Imp_Exp_Invoice_Job.aspx?Page=' + val + '&IMP_EXP=' + val2 + '&Billinvno=' + escape(val3) + '', '', settings)
}

function open_GST_Imp_Exp_Inv_Job_Search(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp_Exp_GST_Rpt/GST_Imp_Exp_Invoice_Job.aspx', '', settings)
}

function GST_Imp_Exp_Billing_Job_Rpt(val) {

    var Job_Id = document.getElementById("HDupdate_id").value;
    var Bill_Invo = document.getElementById("HdtxtInvoiceNo_id").value;

    if (Job_Id != '') {
        NewWindow1('../Billing_Imp_Exp_GST_Rpt/GST_Bill_Imp_Exp_Job_rpt.aspx?Job_Id=' + Job_Id + '&Bill_Invo=' + Bill_Invo + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlExp_name").focus(); });
    }
}

function open_EXPORT_SW_Stmt_Bulk() {
    w = '900';
    h = '370';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Invoice Copy', 'iframe', '../Export/Exp_SW_STMT_Bulk_Copy.aspx', '', settings)
}

function DSR_Imp_Job_Search(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR/DSR_Imp_Job.aspx', '', settings)
}

function Open_DSR_Imp_Job_Search_Update(val, val2) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR/DSR_Imp_Job.aspx?Page=' + escape(val) + '&Jobno=' + val2 + '', '', settings)
}

function open_Export_Item_Copy(val) {
    w = '900';
    h = '370';

    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Item Copy', 'iframe', '../Export/Exp_Item_Copy.aspx?Inv_slno=' + val + '', '', settings)
}
function open_WareHouse(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('WareHouse', 'iframe', '../WareHouse/WareHouse.aspx', '', settings)
}

//-----------------------------Jayanthi-------------------------------------//
function open_ExpensesPaymentEntrySearch(val) {

    w = '1100';
    h = '630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/ExpensesPaymentEntry.aspx', '', settings)
}



function open_ExpensesPaymentEntrySearch_Update(val, val2) {

    w = '1100';
    h = '630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/GST_Imp_Invoice_Job.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/ExpensesPaymentEntry.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}

//function open_ReceiptEntrySearch(val) {

//    w = '1100';
//    h = '650';
//    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
//    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
//    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

//    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/ReceiptEntry.aspx', '', settings)
//}
//function open_ReceiptUpd(val, val2) {

//    w = '1100';
//    h = '630';
//    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
//    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
//    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
//    //adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/GST_Imp_Invoice_Job.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
//    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/ReceiptEntry.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
//}

function open_ReceiptEntrySearch(val) {

    w = '1290'//'1100';
    h = '650';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/ReceiptEntry.aspx', '', settings)
}
function open_ReceiptUpd(val, val2) {

    w = '1290'; //'1100';
    h = '650'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/GST_Imp_Invoice_Job.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/ReceiptEntry.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}


function open_PrevCrDr(val) {

    w = '1100';
    h = '650';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/PreviousCrDrEntry.aspx', '', settings)
}

function open_PrevCrDrUpd(val, val2) {

    w = '1100';
    h = '650';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/PreviousCrDrEntry.aspx?Page=' + escape(val) + '&CrDrID=' + val2 + '', '', settings)
}

function open_DSRDynamic() {
    adcodewindow = dhtmlmodal.open('Dynamic Report', 'iframe', '../DSR_Template/DSRDynamicTmp.aspx', '', NewWindow('1000', '582'))

}

function open_DSRDynamicUPD(val) {
    adcodewindow = dhtmlmodal.open('Dynamic Report', 'iframe', '../DSR_Template/DSRDynamicTmp.aspx?T_ID=' + val + '', '', NewWindow('1000', '582'))


}

//-----------------------------Jayanthi-------------------------------------//


function open_IMP_Supporting_doc_Copy(val) {
    w = '938';
    h = '385';
    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Supporting Doc. Copy', 'iframe', '../IMP_Single_Window/Imp_Supporting_Doc_Copy.aspx?Inv_slno=' + val + '', '', settings)
}

function open_Imp_Expense_Amt_New(val) {
    var Job_no;

    var Job_no = document.getElementById("Hdjobno").value;
    adcodewindow = dhtmlmodal.open('Expense', 'iframe', '../Billing_Imp/Expense_Entry.aspx?Job_no=' + Job_no + ' &Type=' + val + '', '', 'width=962, height=500px,margin-left=70px,margin-top=20px,resize=0, scrolling=0')
}

function open_Consolidated_Packing_List(val) {

    w = '1000';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Packing List', 'iframe', '../BL_Generation/Consolidated_Packing_List_Entry.aspx?Page=' + val + '', '', settings)
}
function open_Consolidated_Packing_List_Rpt(val) {

    var Job_Id = document.getElementById("HDupdate_id").value;
    if (Job_Id != '') {
        NewWindow1('../BL_Generation/Consolidated_Packing_List_Rpt.aspx?Job_Id=' + Job_Id + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Consolidated Packing List Report', function (r) { document.getElementById("ddlExp_name").focus(); });
    }
}

function open_EGM_Search_New(val) {

    w = '1000';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../EGM/EGM_MainPage.aspx?Page=' + val + '', '', settings)
}

function open_EGM_Search_Update(val) {

    w = '1000';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../EGM/EGM_MainPage.aspx?Page=' + val + '', '', settings)

}

function open_EGM_Liner_Vessel_Master(val) {
    w = '250';
    h = '407';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../EGM/EGM_Liner_Vessel_Master.aspx?TYPE=' + val + '', '', 'width=450px, height=407px,margin-left=200px,resize=0,scrolling=0')

}

function open_EGM_Consolidate_Search_New(val) {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../EGM/EGM_Consolidate.aspx?Page=' + val + '', '', settings)
}



function open_EGM_Consolidate_Search_Update(val, val1) {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../EGM/EGM_Consolidate.aspx?Page=' + val + '&egm_id=' + val1 + '', '', settings)
}

function open_CoveringLetter_Search_New_Pegasus(val) {

    w = '784';
    h = '575';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing/Covering_Letter_Pegasus.aspx?Page=' + val + '', '', settings)
    //    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Billing/Covering_Letter.aspx', '', settings)
}

function open_CoveringLetter_Search_Update_Pegasus(val) {

    w = '784';
    h = '575';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing/Covering_Letter_Pegasus.aspx?Page=' + val + '', '', settings)

}
function open_EXP_Docket(val) {

    w = '1000';
    h = '590';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', val, '', settings)

}

function open_Export_AnnexCVR(val) {

    w = '1000';
    h = '590';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', val, '', settings)

}

function open_All_Client_DB_Backup() {
    w = '990';
    h = '400';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Client DB Backup', 'iframe', '../Admin/All_Clients_DB_Backup.aspx', '', settings)
}

function open_Imp_item_PDF(val) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Invoice from PDF', 'iframe', '../Import_XL/ImportInvPDF.aspx', '', settings)
}

function open_EGM_Liner_Master(val) {
    w = '250';
    h = '407';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../EGM/EGM_Liner_Master.aspx?TYPE=' + val + '', '', 'width=450px, height=407px,margin-left=250px,resize=0,scrolling=0')
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../EGM/EGM_Liner_Master.aspx?TYPE=' + val + '', '', 'width=450px, height=407px,margin-left=250px,resize=0,scrolling=0')
}

function open_EGM_Vessel_Master(val) {
    w = '250';
    h = '407';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 6 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../EGM/EGM_Liner_Master.aspx?TYPE=' + val + '', '', 'width=450px, height=407px,margin-left=250px,resize=0,scrolling=0')
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../EGM/EGM_Vessel_Master.aspx?TYPE=' + val + '', '', 'width=450px, height=407px,margin-left=250px,resize=0,scrolling=0')
}

function open_CoveringLetter_Search_New_Vaishnavi(val) {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing/Covering_Letter_Vaishnavi.aspx?Page=' + val + '', '', settings)
    //    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Billing/Covering_Letter.aspx', '', settings)
}


function open_CoveringLetter_Search_Update_Vaishnavi(val, val1) {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';


    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Billing/Covering_Letter_Vaishnavi.aspx?Page=' + val + '&Type=' + val1 + '', '', settings)

}

function open_GST_Checklist_error(Val) {
    w = '875';
    h = '360';
    LeftPosition = (screen.width) ? (screen.width - w) / 12 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Report/Import_CheckList_Errors.aspx?Page=' + Val + '', '', settings)
}

function open_EXPORT_JobWise_XML_Upload(val) {
    w = '300';
    h = '150';
    LeftPosition = (screen.width) ? (screen.width - w) / 4 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 30 : 0;

    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Export Product Master Updation', 'iframe', '../Export_XML/Export_XML_Jobwise.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('Export Product Master Updation', 'iframe', '../Export_XML/Export_XML_Jobwise.aspx', '', 'width=400px, height=150px,margin-left=220px,margin-top=190px,resize=0,scrolling=0')

    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Export/Export_Bulk_LicenseUpoad.aspx', '', 'width=500px, height=150px,margin-left=220px,margin-top=90px,resize=0,scrolling=0')
}

function open_Imp_DeliveryChallan_Search_New(val) {
    w = '1000';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Despatch', 'iframe', '../Import_Report/Imp_DeliveryChallan.aspx?Page=' + val + '', '', settings)
}

function open_Imp_DeliveryChallan_Search_Update(val1, val2) {
    w = '1000';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Despatch', 'iframe', '../Import_Report/Imp_DeliveryChallan.aspx?Page=' + val1 + '&Jobno=' + val2 + '', '', settings)
}

//------------Start RTS ELOGIX Mapping Master--------------//

function RTS_EL_Mapping_Master() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Admin/RTS_EL_Mapping_Master.aspx', '', NewWindow('650', '400'))

}

function RTS_EL_Mapping_Master_Edit(val) {

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Admin/RTS_EL_Mapping_Master.aspx?MTID=' + val + '', '', NewWindow('650', '400'))

}

//------------End RTS ELOGIX  Mapping Master--------------//

function open_Import_Clearance_ICC_Search_Update(val1, val2) {
    w = '800';
    h = '480';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Despatch', 'iframe', '../International_Cargo/Imp_ClearanceRpt_ICC.aspx?Page=' + val1 + '&Jobno=' + val2 + '', '', settings)
}
function open_Import_Clearance_ICC_Search_New(val) {
    w = '800';
    h = '480';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Despatch', 'iframe', '../International_Cargo/Imp_ClearanceRpt_ICC.aspx?Page=' + val + '', '', settings)
}

function open_ADC_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADC', 'iframe', '../ADC/ADC_Entry.aspx', '', settings)
}

function open_ADC_Update(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADC', 'iframe', '../ADC/ADC_Entry.aspx?Page=' + val + '', '', settings)
}


function Export_Annex_EOU_Open() {

    var w = '800';
    var h = '800';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
    settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
    NewWindow1('../Report/Export_Annexure_EOU_Report.aspx', 'List', settings);
    return false;
}

function open_Imp_Classic_DSR_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Classic DSR', 'iframe', '../International_Cargo/Imp_Classic_DSR_Entry.aspx', '', settings)
}

function open_Imp_Classic_DSR_Update(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Classic DSR', 'iframe', '../International_Cargo/Imp_Classic_DSR_Entry.aspx?Page=' + val + '', '', settings)
}

function open_EXPORT_SAHI_Export_ExcelUpload(val) {
    w = '938';
    h = '495';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Export_XL/Export_SAHI_ExcelUpload.aspx', '', settings)
}


function open_EXPORT_SAHI_Export_ExcelUpload_InvoicePage(val) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Export_XL/Export_SAHI_ExcelUpload.aspx?IsAdditionalInv=' + val + '', '', settings)
}



function open_EXPORT_JobWise_XML_Upload_RELIANCE(val) {
    w = '300';
    h = '150';
    LeftPosition = (screen.width) ? (screen.width - w) / 4 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 30 : 0;

    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export Product Master Updation', 'iframe', '../Export_XML/Export_XML_Jobwise_VELJI_Reliance.aspx', '', 'width=400px, height=150px,margin-left=220px,margin-top=190px,resize=0,scrolling=0')
}


function open_Imp_BondMaster_new() {

    //ConsigneeMasterwindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Consignee_Master.aspx', '', 'width=455px, height=450px,margin-left=420px, resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Import_Bond_Master.aspx', '', NewWindow('450', '500'))

}

function open_Imp_BondMaster_update(val) {
    //ConsigneeMasterwindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Consignee_Master.aspx?CONSIGNEE_ID=' + val + '', '', 'width=455px, height=450px,margin-left=420px, resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Import_Bond_Master.aspx?BOND_ID=' + val + '', '', NewWindow('450', '459'))

}

function open_Single_Window_Notes(val) {
    w = '938';
    h = '385';
    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Singlw Window Notes', 'iframe', '../Transaction/Single_window_Notes.aspx', '', settings)
}

function open_EXP_ExRate_Update_TaxableValue() {
    w = '538';
    h = '325';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export Product Master Updation', 'iframe', '../Export/Export_Exrate_Update_TaxableVal_Bulk.aspx', '', 'width=490px, height=300px,margin-left=220px,margin-top=20px,resize=0,scrolling=0')
}


//-------------------Start DSR_Customized_Column_Page_Creation Implemented on 11Jan2019----------------------//

function DSR_Imp_Cover(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR/Cus_DSR_Imp_Wrapper.aspx', '', settings)
}

function DSR_Cus_Imp_Job_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR/Cus_DSR_Imp_Job.aspx', '', settings)
}

function Open_CUS_DSR_Imp_Job_Search_Update(val, val2) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR/Cus_DSR_Imp_Job.aspx?Page=' + escape(val) + '&Jobno=' + val2 + '', '', settings)
}

function open_Cus_DSR_Select_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR/Cus_DSR_Select.aspx', '', settings)
}

function open_Cus_DSR_Select_update(val, val2) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR/Cus_DSR_Select.aspx?Page=' + val + '&Report_Name=' + val2 + '', '', settings)
}

//-------------------End DSR_Customized_Column_Page_Creation Implemented on 11Jan2019----------------------//

function open_Import_Bulk_License_Master_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../eRoyalMasters/Import_Bulk_License_Master_Upoad.aspx', '', 'width=500px, height=150px,margin-left=420px,margin-top=150px,resize=0,scrolling=0')
}


function open_EGM_Bulk_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('EGM Excel Upload', 'iframe', '../EGM/EGM_Bulk_LicenseUpoad.aspx', '', 'width=500px, height=150px,margin-left=250px,margin-top=90px,resize=0,scrolling=0')
}

function open_Update_Query(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Query Updation', 'iframe', '../Admin/Query_Updation.aspx', '', settings)
}

function open_EXP_Prouduct_Invoice_Move(val) {
    w = '600';
    h = '150';
    LeftPosition = (screen.width) ? (screen.width - w) / 4 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 30 : 0;

    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export Invoice Move', 'iframe', '../Export/Export_Invoice_Move.aspx', '', settings)
}

function open_IMP_Prouduct_Invoice_Move(val) {
    w = '600';
    h = '150';
    LeftPosition = (screen.width) ? (screen.width - w) / 4 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 30 : 0;

    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Import Invoice Move', 'iframe', '../Transaction/Import_Invoice_Move.aspx', '', settings)
}
function open_Export_PackingList_Search(val) {
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Packing List', 'iframe', '../Export/Export_PackingList.aspx', '', settings)
}
function open_Export_PackingList_Search_Update(val, val2) {
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Packing List', 'iframe', '../Export/Export_PackingList.aspx?Page=' + escape(val) + '&Jobno=' + val2 + '', '', settings)
}

function open_Imp_Branch_Change(val) {
    w = '940';
    h = '470';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Branch Change', 'iframe', '../Job_Duplicate/Imp_Branch_to_Branch.aspx?Jobno=' + val + '', '', settings)
}

//---------------------------------Start Customized DSR--------------------------------------------------
function DSR_Cus_Exp_Job_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR_EXP/Cus_DSR_Exp_Job.aspx', '', settings)
}
function Open_CUS_DSR_Exp_Job_Search_Update(val, val2) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR_EXP/Cus_DSR_Exp_Job.aspx?Page=' + escape(val) + '&Jobno=' + val2 + '', '', settings)
}
function DSR_Exp_Cover(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR_EXP/Cus_DSR_Exp_Wrapper.aspx', '', settings)
}

function open_Cus_DSR_EXP_Select_update(val, val2) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR_EXP/Cus_DSR_Exp_Select.aspx?Page=' + val + '&Report_Name=' + val2 + '', '', settings)
}

function open_Cus_DSR_EXP_Select_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR_EXP/Cus_DSR_Exp_Select.aspx', '', settings)
}

//---------------------------------End Customized DSR--------------------------------------------------


function open_Auto_Q() {
    w = '950';
    h = '370';
    LeftPosition = (screen.width) ? (screen.width - w) / 26 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 10 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Auto Ins', 'iframe', '../Admin/E_Royal_Installation.aspx', '', settings)
}

//----------------Start Jobwise License View developed by Aarthy------------------------//
function open_license_Invoice_Itemwise_details_update_bulk() {

    w = '900';
    h = '370';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('License view', 'iframe', '../Transaction/IMP_License_Invoicewise_update.aspx', '', settings)

}
//----------------End Jobwise License View developed by Aarthy------------------------//

function open_Product_Imp_Master_152(val) {
    w = '950';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 170 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Imp Product Master', 'iframe', '../eRoyalMasters/Imp_Product_Master_152.aspx', '', settings)
}

function open_Exp_Branch_Change(val) {
    w = '940';
    h = '470';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Branch Change', 'iframe', '../Job_Duplicate/Exp_Branch_to_Branch.aspx?Jobno=' + val + '', '', settings)
}

function open_Auto_Wrk_New(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Admin', 'iframe', '../Admin/E_Royal_Wrk_Creation.aspx', '', settings)
}

function open_Auto_Wrk_Update(val, val1) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Admin', 'iframe', '../Admin/E_Royal_Wrk_Creation.aspx?Page=' + val + '&D_Name=' + val1 + '', '', settings)
}

function Open_Exp_Sup_Doc_XL_Upload() {

    NewWindow1('../EXP_Single_Window/Export_Supporting_Doc_Excel_Upload.aspx', 'List', '600', '300', 'yes');
}

function open_Invoice_Itemwise() {
    w = '900';
    h = '370';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export Product Master Updation', 'iframe', '../FlatFile/Open_Ewaybill_Invoice_Itemwise.aspx', '', settings)
}


function open_GST_Billing_paramount_New(val) {
    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Paramount/GST_Imp_Exp_Invoice_Job.aspx', '', settings)
}
function open_GST_Billing_paramount_Update(val, val2, val3) {
    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Paramount/GST_Imp_Exp_Invoice_Job.aspx?Page=' + val + '&IMP_EXP=' + val2 + '&Billinvno=' + escape(val3) + '', '', settings)
}
//function GST_Billing_Job_Rpt() {
//    var Job_Id = document.getElementById("HDupdate_id").value;
//    var Imp_Exp = document.getElementById("HDupdate_IMP_EXP_id").value;
//    var Bill_Inv_No = document.getElementById("txtInvoiceNo").value;

//    if (Job_Id != '') {
//        NewWindow1('../Billing_Paramount/GST_Imp_Exp_rpt.aspx?Job_Id=' + Job_Id + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Inv_No + '', 'List', '870', '1024', 'yes');
//    }
//    else {
//        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
//    }
//}

function GST_Billing_Combined_Job_Rpt() {
    var Job_Id = document.getElementById("HDupdate_id").value;
    var Imp_Exp = document.getElementById("HDupdate_IMP_EXP_id").value;
    var Bill_Inv_No = document.getElementById("txtInvoiceNo").value;

    if (Job_Id != '') {
        NewWindow1('../Billing_Combined_Rpt/GST_Bill_Combined_Job_rpt.aspx?Job_Id=' + Job_Id + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Inv_No + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
    }
}



function open_Bulk_Exrate_Update_Inv() {
    w = '420';
    h = '340';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Split Multiple Invoice', 'iframe', '../Transaction/Bulk_INV_ExRate_UpdateAll.aspx', '', settings)
}

function Open_ReImport_Excel_Upload() {

    NewWindow1('../Transaction/ReImport_Excel_Upload.aspx', 'List', '600', '300', 'yes');
}

function open_Imp_Exp_Billing_Others() {
    var Job_no = document.getElementById("hd_Jobs").value;
    var Imp_Exp = document.getElementById("hd_Imp_Exp").value;
    adcodewindow = dhtmlmodal.open('Expense', 'iframe', '../Billing_Paramount/Imp_Exp_Billing_Others.aspx?Job_no=' + Job_no + ' &Type=' + Imp_Exp + '', '', 'width=962, height=500px,margin-left=70px,margin-top=20px,resize=0, scrolling=0')
}

function Open_Sup_Doc_New() {
    adcodewindow = dhtmlmodal.open('Supporting Document', 'iframe', '../eRoyalMasters/Sup_Doc_Master.aspx', '', NewWindow('850', '420'));
}
function open_Sup_Doc_Update(val, val2) {
    w = '850';
    h = '420';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Supporting Document', 'iframe', '../eRoyalMasters/Sup_Doc_Master.aspx?ID=' + escape(val) + '&IMP_EXP=' + val2 + '', '', settings)
}


function open_Dynamic_Report_new_GroupNew() {
    adcodewindow = dhtmlmodal.open('Dynamic Report', 'iframe', '../DSR_Template/Dynamic_Report_Design_GroupNew.aspx', '', NewWindow('1000', '582'))
}

function open_Dynamic_Report_Update_GroupNew(val) {
    adcodewindow = dhtmlmodal.open('Dynamic Report', 'iframe', '../DSR_Template/Dynamic_Report_Design_GroupNew.aspx?T_ID=' + val + '', '', NewWindow('1000', '582'))
}



function open_Import_dynamic_Repot() {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../DSR_Template/Import_Dynamicreport.aspx', '', settings)
}

function open_ImportSummary_Repot() {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Summary_Rpt/ImportSummary.aspx', '', settings)
}

function open_ImportSummary_RepotTwo() {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Summary_Rpt/ImportSummaryTwo.aspx', '', settings)
}

function open_Exp_Summary_Report() {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Summary_Rpt/ExportSummary.aspx', '', settings)
} 
function open_Export_dynamic_Repot() {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../DSR_Template/Export_Dynamicreport.aspx', '', settings)
}


function OPEN_IMP_SUPPDOC_Excel_Upload(val) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Import_XL/Import_SuppDoc_Excel.aspx', '', settings)
}

function open_Ammendment_Repot() {

    w = '950';
    h = '515';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Amendment/Import_Amendment.aspx', '', settings)
}

function open_Bulk_Export_Exrate_Update_Inv() {
    w = '420';
    h = '340';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Split Multiple Invoice', 'iframe', '../Export/Bulk_INV_ExRate_UpdateAll.aspx', '', settings)
}

function opennew_Expense_chargemaster() {
    adcodewindow = dhtmlmodal.open('Expense Charge Master', 'iframe', '../GST_Billing_Master/Expense_Charge_Master.aspx', '', NewWindow('457', '480'))
}
function opennew_Expense_chargemaster_edit(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Expense_Charge_Master.aspx?CHARGE_ID=' + val + '', '', NewWindow('457', '480'))
}

function opennew_Vendormaster(val) {
    w = '1100'; //'1305';
    h = '585';  //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../GST_Billing_Master/Vendor_Master.aspx', '', settings)
}
function open_VendorMaster_Search_Update(val, val2) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Vendor', 'iframe', '../GST_Billing_Master/Vendor_Master.aspx?Page=' + escape(val) + '&PageVendorcode=' + val2 + '', '', settings)
}

function open_PurchaseUpd(val2) {

    w = '1305';
    h = '630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/GST_Imp_Invoice_Job.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/PurchaseEntry.aspx?voucherno=' + val2 + '', '', settings)
}
function open_PurchaseEntry(val) {

    w = '1305';
    h = '630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/PurchaseEntry.aspx', '', settings)
}

function open_purchaseentrysettings(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/Purchaseentrysetting.aspx', '', NewWindow('457', '200'))

}

function open_delivery_chellan_Carchit() {
    w = '990';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Delivery_Challen_Details_CARCHIT.aspx', '', settings)

}

function open_PaymentntrySearch(val) {

    w = '1290'//'1100';
    h = '650';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/PaymentEntry.aspx', '', settings)
}

function open_PaymentUpd(val, val2) {

    w = '1290'; //'1100';
    h = '650'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/GST_Imp_Invoice_Job.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/PaymentEntry.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}

function open_JournalentrySearch(val) {

    w = '1290'//'1100';
    h = '650';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/JournalEntry.aspx', '', settings)
}

function open_JournalUpd(val, val2) {

    w = '1290'; //'1100';
    h = '650'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/GST_Imp_Invoice_Job.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/JournalEntry.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}

function opennew_Bank_Masternew() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Bank_Master.aspx', '', NewWindow('757', '360'))
}

function opennew_Bank_Master(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Bank_Master.aspx?BANK_ID=' + val + '', '', NewWindow('757', '360'))
} function open_ContraVoucherentrySearch(val) {

    w = '1290'//'1100';
    h = '650';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/ContraVoucherEntry.aspx', '', settings)
}

function open_ContraVoucherUpd(val, val2) {

    w = '1290'; //'1100';
    h = '650'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/GST_Imp_Invoice_Job.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/ContraVoucherEntry.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}

function open_CreditEntry(val) {

    w = '1000';
    h = '630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/Creditnote.aspx', '', settings)
}

function open_DebitEntry(val) {

    w = '1000';
    h = '630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/Debitnote.aspx', '', settings)
}

function open_delivery_note() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Delivery_Challen_Details_KSQUARE.aspx', '', settings)

}

function open_DSR_Excel_Upload(val) {
    w = '938';
    h = '205';

    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DSR Excel Upload', 'iframe', '../DSR/Imp_DSR_Excel.aspx', '', settings)
}


function open_Import_Licensesettings(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/Imp_License_Settings.aspx', '', NewWindow('457', '400'))

}

function GST_Import_Billing_Job_Rpt_Credit_Note(val) {

    var Job_Id = document.getElementById("HD_Bill_Jobno").value;

    if (Job_Id != '') {
        NewWindow1('../Billing_Imp_Rpt_Credit_Note/GST_Bill_Import_Job_rpt_Credit_Note.aspx?Bill_Invo=' + Job_Id + '&Tax_Mode=' + val + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlExp_name").focus(); });
    }
}

function open_GST_Imp_Credit_Note_New(val) {
    w = '1150';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Credit Note', 'iframe', '../Billing_Imp_Credit_Note/Credit_Note.aspx', '', settings)
}

function open_GST_Imp_Credit_Note_Update(val, val2) {
    w = '1150';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Credit Note', 'iframe', '../Billing_Imp_Credit_Note/Credit_Note.aspx?Billinvno=' + escape(val) + '&Page=' + escape(val2) + '', '', settings)
}

function open_GST_Exp_Credit_Note_New(val) {
    w = '1150';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Credit Note', 'iframe', '../Billing_Exp_Credit_Note/Exp_Credit_Note.aspx', '', settings)
}

function open_GST_Exp_Credit_Note_Update(val, val2) {
    w = '1150';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Credit Note', 'iframe', '../Billing_Exp_Credit_Note/Exp_Credit_Note.aspx?Billinvno=' + escape(val) + '&Page=' + escape(val2) + '', '', settings)
}
function GST_Export_Billing_Job_Rpt_Credit_Note(val) {
    var Job_Id = document.getElementById("HD_Bill_Jobno").value;
    if (Job_Id != '') {
        NewWindow1('../Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_Credit_Note.aspx?Bill_Invo=' + Job_Id + '&Tax_Mode=' + val + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlExp_name").focus(); });
    }
}

function Amendment_Error_Code() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/Amendment_IMP_Error_Code.aspx', '', NewWindow('700', '240'))

}

function open_Imp_Exp_Expense_Amt_New(val) {
    var Job_no;

    var Job_no = document.getElementById("Hdjobno").value;
    var I_E = document.getElementById("Hd_I_E").value;
    adcodewindow = dhtmlmodal.open('Expense', 'iframe', '../Billing_Imp/Expense_Entry.aspx?Job_no=' + Job_no + ' &Type=' + I_E + '', '', 'width=962, height=500px,margin-left=70px,margin-top=20px,resize=0, scrolling=0')
}


function open_Import_CustomsDuty_Repot() {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Import_Report/Import_CustomsDuty_Rpt_FAIRMACS.aspx', '', settings)
}


function open_Import_Bulk_Product_Master_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../eRoyalMasters/Import_Bulk_Product_Master_Upoad.aspx', '', 'width=500px, height=150px,margin-left=420px,margin-top=150px,resize=0,scrolling=0')
}

function open_Export_Ammendment_Repot() {

    w = '950';
    h = '515';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Amendment/Export_Amendment.aspx', '', settings)
}




function open_delivery_chellan_Vintage() {

    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', 'width=872, height=735px,margin-left=200px,resize=0, scrolling=0')
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/General.aspx', '', NewWindow('455', '450'))  

    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Delivery_Challen_Details_vintage.aspx', '', settings)

}

// staff master
function opennew_Staff_Masternew() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Staff_Master.aspx', '', NewWindow('765', '440'))
}

function opennew_Staff_Master(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Staff_Master.aspx?STAFF_ID=' + val + '', '', NewWindow('765', '440'))
}


function open_GST_Pending_Bill(Val) {
    w = '925';
    h = '550';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Paramount/Pending_Invoice_ListPopup.aspx?Page=' + Val + '', '', settings)
}

function open_GST_Inv_no_Edit(val) {

    w = '670';
    h = '280';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Paramount/GST_Invoice_No_Edit.aspx', '', settings)
}

function opennew_Staff_Master_Debit_cr_entry_New() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Staff_Master_prvscr_debit_entry.aspx', '', NewWindow('550', '350'))
}

function opennew_Staff_Master_Debit_cr_entry(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Staff_Master_prvscr_debit_entry.aspx?STAFF_PR_CR_ID=' + val + '', '', NewWindow('550', '350'))
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Staff_Master_prvscr_debit_entry.aspx?STAFF_ID=' + val + '', '', NewWindow('550', '350'))
}

// STAFF SUSPENSE ENTRY
function opennew_Staff_Suspense_entry_New() {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Staff_Suspense_entry.aspx', '', NewWindow('550', '350'))
}

function opennew_Staff_Suspense_entry(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Staff_Suspense_entry.aspx?ID=' + val + '', '', NewWindow('550', '350'))
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../GST_Billing_Master/Staff_Master_prvscr_debit_entry.aspx?ID=' + val + '', '', NewWindow('550', '350'))
}
function open_Import_BMW_Repot() {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Import_Report/Import_BMW_Rpt_SANCO.aspx', '', settings)
}

function open_ExpEntrySearch_Update(val, val2) {

    w = '1100';
    h = '630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/ExpPaymentEntryCombinedNew.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}

function open_Party_Master_New(val) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../GST_Billing_Master/Party_Master.aspx', '', settings)
}

function open_GST_Add_New_Party(val) {
    w = '470';
    h = '240';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../GST_Billing_Master/NewParty.aspx', '', settings)
}
function open_Party_Master_Cr_Limit_New(val) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../GST_Billing_Master/Party_Credit_Limit.aspx', '', settings)
}

function open_Party_Master_Cr_Limit_Update(val) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../GST_Billing_Master/Party_Credit_Limit.aspx?Page=' + escape(val) + '', '', settings)
}
function open_Party_Master_Update(val) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../GST_Billing_Master/Party_Master.aspx?Page=' + escape(val) + '', '', settings)
}


function open_DebitNoteUpd(val2) {

    w = '1305';
    h = '630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/DebitNoteEntry.aspx?voucherno=' + val2 + '', '', settings)
}
function open_DebitNoteEntry(val) {

    w = '1305';
    h = '630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp/DebitNoteEntry.aspx', '', settings)
}

function open_DebitNotesettings(val) {
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/DebitNoteSetting.aspx', '', NewWindow('457', '200'))

}


function open_IGM_ExcelNew() {
    w = '600';
    h = '300';
    LeftPosition = (screen.width) ? (screen.width - w) / 52 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Igm Excel Upload', 'iframe', '../Transaction/IGM_Excel_Upload.aspx', '', 'width=500px, height=150px,margin-left=150px,margin-top=150px,resize=0,scrolling=0')
}
function open_GST_Tra_Inv_Job_Search(val) {

    w = '1203' //'1290'//'1100';
    h = '650';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Transport/GST_Transport_Inv_Job.aspx', '', settings)
}
function open_GST_Tra_Inv_Job_Search_Update(val, val2) {

    w = '1203';
    h = '650';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Transport/GST_Transport_Inv_Job.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}

function DO_Entry_Search(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DO_ENTRY', 'iframe', '../Paramount/DO_Entry.aspx', '', settings)
}

function Open_DO_Entry_Search_Update(val, val2) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DO_ENTRY', 'iframe', '../Paramount/DO_Entry.aspx?Page=' + escape(val) + '&Jobno=' + val2 + '', '', settings)
}
function CFS_Entry_Search(val) {
    w = '1100';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('CFS_ENTRY', 'iframe', '../Paramount/CFS_Entry.aspx', '', settings)
}

function Open_CFS_Entry_Search_Update(val, val2) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('CFS_ENTRY', 'iframe', '../Paramount/CFS_Entry.aspx?Page=' + escape(val) + '&Jobno=' + val2 + '', '', settings)
}
function AAI_Entry_Search(val) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('AAI_ENTRY', 'iframe', '../Paramount/AAI_Entry.aspx', '', settings)
}

function Open_AAI_Entry_Search_Update(val, val2) {
    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('AAI_ENTRY', 'iframe', '../Paramount/AAI_Entry.aspx?Page=' + escape(val) + '&Jobno=' + val2 + '', '', settings)
}

function open_Exp_Voucher_creation_Search_New(val) {
    w = '1000';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Despatch', 'iframe', '../Export_Report/Voucher_Creation.aspx?Page=' + val + '', '', settings)
}
function open_Exp_Voucher_creation_Search_Update(val1, val2) {
    w = '1000';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Despatch', 'iframe', '../Export_Report/Voucher_Creation.aspx?Page=' + val1 + '&Jobno=' + val2 + '', '', settings)
}
function GST_Transport_Inv_Job_Rpt(val) {
    var Job_Id = document.getElementById("hd_BILL_INV_NO").value;
    if (Job_Id != '') {
        NewWindow1('../Billing_Transport_Rpt/GST_Transport_Inv_Job_rpt.aspx?Bill_Invo=' + Job_Id + '&Tax_Mode=' + val + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Transport Bill', function (r) { document.getElementById("ddlExp_name").focus(); });
    }
}


function open_Exp_UPload_PDF(val) {
    w = '1100';
    h = '585';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Export_PDFReader/Export_PDF_Reader.aspx', '', settings)
}


function open_Exp_UPload_PDF_New(val) {
    w = '1100';
    h = '585';

    LeftPosition = (screen.width - w) / 2;
    TopPosition = (screen.height - h) / 10;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Export_PDFReader/Export_PDF_Reader_New.aspx', '', settings)
}


function open_exp_pdf_master_new() {
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Export_PDF_Settings_Master.aspx', '', NewWindow('700', '655'))
}


function open_Exp_UPload_PDF1(val) {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Query Updation', 'iframe', '../Admin/Query_Updation.aspx', '', settings)
}



function open_exp_pdf_master_Update(val) {

    //mywindow1 = window.open("../eRoyalMasters/Product_Import_Master.aspx?PRODUCT_IMPORT_ID=" + val + "", "mywindow1", "modal=1,status=1,resizable=0,width=875,height=530,top=150,menubar=0,left=200,top=40,bottom=160,ScrollBars=0");
    //productMasterwindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_Import_Master.aspx?PRODUCT_IMPORT_ID=' + val + '', '', 'width=700px,height=685px,margin-left=270px,resize=0,scrolling=0')
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Export_PDF_Settings_Master.aspx?ID=' + val + '', '', NewWindow('700', '655'))
}

function open_Imp_Voucher_creation_Search_New(val) {
    w = '1000';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Despatch', 'iframe', '../Import_Report/Voucher_Creation.aspx?Page=' + val + '', '', settings)
}
function open_Imp_Voucher_creation_Search_Update(val1, val2) {
    w = '1000';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Despatch', 'iframe', '../Import_Report/Voucher_Creation.aspx?Page=' + val1 + '&Jobno=' + val2 + '', '', settings)
}


function open_Imp_Inv_Item_Pdf_Reader(val) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Invoice from PDF', 'iframe', '../Import_Pdf_Reader/Imp_Inv_Item_Pdf_Reader.aspx', '', settings)
}

function openproduct_Pdf_Reader() {

    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_PDF_Reader_Import_Master.aspx', '', NewWindow('700', '580'))
}

function Product_Master_update_Pdf_Reader(val) {

    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Product_PDF_Reader_Import_Master.aspx?PRODUCT_IMPORT_ID=' + val + '', '', NewWindow('700', '580'))
}

function open_Pdf_Reader_Import_Bulk_Product_Master_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../eRoyalMasters/Import_Bulk_Pdf_ReaderProduct_Master_Upoad.aspx', '', 'width=500px, height=150px,margin-left=420px,margin-top=150px,resize=0,scrolling=0')
}


function open_Export_License_Master_Bulk_Delete() {
    w = '800';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../eRoyalMasters/Export_License_Master_Bulk_Delete.aspx', '', 'width=990px, height=520px,margin-left=220px,margin-top=50px,resize=0,scrolling=0')
}

function open_Export_Bulk_License_Master_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../eRoyalMasters/Export_License_Master_Bulk_Upoad.aspx', '', 'width=500px, height=150px,margin-left=420px,margin-top=150px,resize=0,scrolling=0')
}

function open_EXPORT_SignedSB_Upload(val) {
    w = '938';
    h = '495';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Flatfile_Reader/Export_SignedSB_Job.aspx', '', settings)
}
function open_IMPORT_SignedBE_Upload(val) {
    w = '900';
    h = '450';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Flatfile_Reader/Import_SignedBE_Job.aspx', '', settings)
}

function Open_Exchage_Rate_Excel_XL_Upload() {

    NewWindow1('../ERoyal_Admin_Master/Exchage_Rate_Excel_Upload.aspx', 'List', '550', '250', 'yes');
}

function Open_Ex_Rate() {

    w = '950';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;

    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Ex-Rate', 'iframe', '../Admin/Exchange_Details_ListPopup_XL.aspx', '', settings)
}

function open_SW_Control_SEC65_XBE_Excel_Upload(val) {
    NewWindow1('../Import_XL/XBE_SEC65_SW_CONTROL_Excel.aspx', 'List', '600', '300', 'yes');
}
function Open_CFS_CLEARNCE_TRANSPORTER_LINER(val) {

    adcodewindow = dhtmlmodal.open('Paramount', 'iframe', '../Paramount/CFS_Clearnce_Trans_Liner_Master.aspx', '', NewWindow('457', '393'))
}

function open_User_Wise_Report_New() {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Users/User_Wise_Report_New.aspx', '', settings)
}
function open_Export_Invoice_Cum_Packing_List_New(val) {

    w = '1203';
    h = '625';  //OLD 585
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Self_Exporter/Export_Invoice_Cum_Packing_List_Details.aspx', '', settings)
}
function open_Export_Invoice_Cum_Packing_List_Rpt(val) {
    var Job_Id = document.getElementById("hd_BILL_INV_NO").value;
    if (Job_Id != '') {
        NewWindow1('../Self_Exporter_Rpt/Export_Invoice_Cum_Packing_List_rpt.aspx?Bill_Invo=' + Job_Id + '&Tax_Mode=' + val + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Self Exporter Invoice cum Packing List', function (r) { document.getElementById("ddlExp_name").focus(); });
    }
}
function open_Export_Invoice_Cum_Packing_List_Search_Update(val, val2) {

    w = '1203';
    h = '625';  //OLD 585
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('BL', 'iframe', '../Self_Exporter/Export_Invoice_Cum_Packing_List_Details.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}

function open_Exp_Sup_doc_Del(val) {
    w = '400';
    h = '150';
    LeftPosition = (screen.width) ? (screen.width - w) / 4 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 30 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export Sup. Docs Delete', 'iframe', '../EXP_Single_Window/Exp_Sup_Doc_delete.aspx', '', settings)
}
function openTransport_Updated(val) {
    adcodewindow = dhtmlmodal.open('Transport', 'iframe', '../eRoyalMasters/Transport_Master.aspx?TRANS_ID=' + val + '', '', NewWindow('450', '370'))
}
function openTransport_Masternew() {
    adcodewindow = dhtmlmodal.open('Transport', 'iframe', '../eRoyalMasters/Transport_Master.aspx', '', NewWindow('450', '370'))
}
function Open_SW_Bulk_Excel_Upload(val) {
    w = '938';
    h = '385';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Import_XL/Import_SW_Bulk_Excel.aspx', '', settings)
}
function open_delivery_chellan_Sudharsan() {
    w = '990';
    h = '545';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Transaction/Delivery_Challen_Details_Sudharsan.aspx', '', settings)

}
function open_SupDoc_Master_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../eRoyalMasters/Sup_Doc_Master_Exl.aspx', '', 'width=500px, height=150px,margin-left=420px,margin-top=150px,resize=0,scrolling=0')
}

function open_Exp_UPload_PDF_New_AI(val) {
    w = '1200';
    h = '685';

    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Export_PDFReader/Export_PDF_Reader_New_AI.aspx', '', settings)
}

function open_Export_Bulk_Product_Setting_Master_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../eRoyalMasters/Export_Bulk_Product_Setting_Master_Upload.aspx', '', 'width=500px, height=150px,margin-left=420px,margin-top=150px,resize=0,scrolling=0')
}

function Imp_PDF_Setting_Master() {
    adcodewindow = window.open("../eRoyalMasters/Import_PDF_Settings_Master.aspx", "mywindow1", "modal=1,status=1,resizable=0,width=875,height=530,top=150,menubar=0,left=200,top=40,bottom=160,ScrollBars=0");
}

function Imp_PDF_Setting_new() {
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Import_PDF_Settings_Master.aspx', '', NewWindow('760', '625'))
}

function Imp_PDF_Setting_update(val) {
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Import_PDF_Settings_Master.aspx?ID=' + val + '', '', NewWindow('760', '625'))
}

function open_Import_Bulk_Product_Setting_Master_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../eRoyalMasters/Import_Bulk_Product_Setting_Master_Upload.aspx', '', 'width=500px, height=150px,margin-left=420px,margin-top=150px,resize=0,scrolling=0')
}

function open_Imp_UPload_PDF_New(val) {
    w = '1100';
    h = '585';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Import General Excel Upload', 'iframe', '../Import_Pdf_Reader/Import_PDFReader.aspx', '', settings)
}

function open_Imp_UPload_PDF(val) {
    w = '1100';
    h = '585';

    LeftPosition = (screen.width - w) / 2;
    TopPosition = (screen.height - h) / 10;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Import General Excel Upload', 'iframe', '../Import_Pdf_Reader/Import_PDFReader.aspx', '', settings)
}



function open_Imp_Manual_UPload_PDF(val) {
    w = '1100';
    h = '585';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Import General Excel Upload', 'iframe', '../Import_Pdf_Reader/Import_PDF_Reader_Manual.aspx', '', settings)
}


function openexpclientmasternew() {
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Exp_PDF_Client_Master.aspx', '', NewWindow('450', '369'))
}
function openexpclientmaster(val) {
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Exp_PDF_Client_Master.aspx?EXP_CLIENT_ID=' + val + '', '', NewWindow('450', '369'))

}
function openexpclientmasterAddNew() {
    w = '450';
    h = '369';
    settings = 'width=' + w + ',height=' + h + ',top=50px,left=350px,resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Exp_PDF_Client_Master.aspx', '', settings)
}
function open_Exp_Excel_Reader(val) {
    w = '1200';
    h = '685';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Export_XL/Export_Excel_Reader.aspx', '', settings)
}

function OpenPopup_AutoMail_New() {
    w = '1100';
    h = '570';

    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('AutoMail', 'iframe', '../DSR_Auto_Mail_Scheduler/DSR_Mail_Scheduler.aspx', '', settings)
}

function OpenPopup_AutoMail_Update(val) {
    w = '1100';
    h = '570';

    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('AutoMail', 'iframe', '../DSR_Auto_Mail_Scheduler/DSR_Mail_Scheduler.aspx?SCHEDULER_ID=' + val + '', '', settings)
}

function Import_CaterPillar_Master_New() {
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Import_CaterPillar_Master.aspx', '', NewWindow('760', '625'))
}

function Import_CaterPillar_Master_Update(val) {
    adcodewindow = dhtmlmodal.open('ProductMaster', 'iframe', '../eRoyalMasters/Import_CaterPillar_Master.aspx?ID=' + val + '', '', NewWindow('760', '625'))
}

function open_Import_CaterPiller_Bulk_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../eRoyalMasters/Import_CaterPillar_Bulk_Master_Upload.aspx', '', 'width=500px, height=150px,margin-left=420px,margin-top=150px,resize=0,scrolling=0')
}

function open_Imp_UPload_PDF_AI(val) {
    w = '1200';
    h = '685';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Import_Pdf_Reader/Import_PDF_Reader_AI.aspx', '', settings)
}
function open_IRN_Automation_New_EXP(jobno, party) {
    w = '1005';
    h = '545';
    var encodedParty = encodeURIComponent(party);
    LeftPosition = (screen.width) ? (screen.width - w) / 3 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('IRN Automation', 'iframe', '../IRN_Automation/IRN_Autiomation_General.aspx?JOBID=' + jobno + '&party=' + encodedParty + '', '', settings)
}
function open_IRN_Automation_New_IMP(jobno, party) {
    w = '1005';
    h = '545';
    var encodedParty = encodeURIComponent(party);
    LeftPosition = (screen.width) ? (screen.width - w) / 8 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('IRN Automation', 'iframe', '../IRN_Automation/IRN_Autiomation_General.aspx?JOBID=' + jobno + '&party=' + encodedParty + '', '', settings)
}
function open_Icegate_login_setting(val) {
    adcodewindow = dhtmlmodal.open('icegate_Login', 'iframe', '../IRN_Automation/IRN_Ice_Gate_Login_Settings.aspx', '', NewWindow('445', '240'))

}

function open_Icegate_login_setting_update(val) {
    adcodewindow = dhtmlmodal.open('icegate_Login', 'iframe', '../IRN_Automation/IRN_Ice_Gate_Login_Settings.aspx?ICEGATE_SETTING_ID=' + val + '', '', NewWindow('445', '240'))

}
function open_GST_Imp_Credit_Note_Inv_no_Edit(val) {

    w = '670';
    h = '280';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Billing_Imp_Credit_Note/Gst_Imp_Credit_Note_Invoice_No_Edit.aspx', '', settings)
}
function open_SEZ_Warehouse_SEZ_Exbond_Details(val) {

    w = '920';
    h = '490';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('adcode', 'iframe', '../Transaction/Sez_WareHouse_Move_Sez_Exbond.aspx?EXBND_JOBID=' + val + '', '', settings)

}
function open_Exp_XML_JSON_Reader(val) {
    w = '1200';
    h = '685';

    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Export General Excel Upload', 'iframe', '../Export_PDFReader/Export_XML_JSON_Reader.aspx', '', settings)
}
function open_ErrorLogs_Report() {

    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Admin/Application_ErrorLogs_Report.aspx', '', settings)
}
function Advertisement() {
    adcodewindow = dhtmlmodal.open('eRoyal Ads', 'iframe', '../Admin/eRoyal_UploadAds.aspx', '', NewWindow('620', '320'))
}
function open_Checklist_Reader(val) {
    w = '1200';
    h = '685';

    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Import General Checklist Upload', 'iframe', '../Import_Pdf_Reader/Import_Checklist_Reader_AI.aspx', '', settings)
}
function open_IRN_Automation_EXP_NEW(jobno, party) {
    w = '1005';
    h = '545';
    var encodedParty = encodeURIComponent(party);
    var Jobtype = 'Export';
    LeftPosition = (screen.width) ? (screen.width - w) / 3 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('IRN Automation', 'iframe', '../IRN_Automation_New/IRN_Autiomation_General.aspx?JOBID=' + jobno + '&party=' + encodedParty + '&Jobtype=' + Jobtype + '', '', settings)
}
function open_IRN_Automation_IMP_NEW(jobno, party) {
    w = '1005';
    h = '545';
    var encodedParty = encodeURIComponent(party);
    var Jobtype = 'Import';
    LeftPosition = (screen.width) ? (screen.width - w) / 8 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('IRN Automation', 'iframe', '../IRN_Automation_New/IRN_Autiomation_General.aspx?JOBID=' + jobno + '&party=' + encodedParty + '&Jobtype=' + Jobtype + '', '', settings)
}
function open_Imp_Excel_Reader(val) {
    w = '1200';
    h = '685';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Import General Excel Upload', 'iframe', '../Import_Pdf_Reader/Import_Excel_Reader.aspx', '', settings)
}

function open_Import_Bulk_License_Excel_Upload() {
    w = '500';
    h = '120';
    LeftPosition = (screen.width) ? (screen.width - w) / 22 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 200 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    //    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/INV_XL_upload.aspx', '', settings)
    adcodewindow = dhtmlmodal.open('Nissan Excel Upload', 'iframe', '../Transaction/Import_Bulk_License.aspx', '', 'width=500px, height=350px,margin-left=220px,margin-top=20px,resize=0,scrolling=0')
}
function openimpclientmasternew() {
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../OCR_Dashboard_report/IMP_PDF_Client_Master.aspx', '', NewWindow('450', '369'))
}
function openimpclientmaster(val) {
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../OCR_Dashboard_report/IMP_PDF_Client_Master.aspx?IMP_CLIENT_ID=' + val + '', '', NewWindow('450', '369'))

}
function open_exp_default_master_new_update(val) {
    adcodewindow = dhtmlmodal.open('Exp_Annexure_Master', 'iframe', '../eRoyalMasters/Annexure_Default_Master_Search_Update.aspx?ANNEX_ID=' + val + '', '', NewWindow('950', '550'))
}
function open_exp_default_master_new() {
    adcodewindow = dhtmlmodal.open('Exp_Annexure_Master', 'iframe', '../eRoyalMasters/Annexure_Default_Master_Search_Update.aspx', '', NewWindow('950', '550'))
}

function open_file_upload() {

    w = '1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('File Updation', 'iframe', '../DeployFiles/DeployFiles.aspx', '', settings)
}

function open_Multiple_job() {

    w = '990';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Imp_Exp_Multiple_Checklist/Imp_Exp_Multiple_Checklist.aspx', '', settings)
}


function openAistatuscheck(val) {
    w = '1200';
    h = '700';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../AI_Extraction_Queue/AI_Extraction_Queue_Status.aspx?Job_type=' + val + '', '', settings)
}


function open_PDF_Import_Report() {
    w = '1200';
    h = '700';

    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0,scrolling=0';
    adcodewindow = dhtmlmodal.open('PDF Import Report', 'iframe', '../OCR_Dashboard_Report/PDF_Import_Report.aspx', '', settings)
}

function open_PDF_Export_Report() {

    w = '1200';
    h = '700';

    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0,scrolling=0';
    adcodewindow = dhtmlmodal.open('PDF Export Report', 'iframe', '../OCR_Dashboard_Report/PDF_Export_Report.aspx', '', settings)
}

function open_Ocr_Ai_Dashboard(Val) {

    // Export/Import General_Search's own OCR toolbar icon calls this same shared
    // function, but those pages always load inside E_royal_Impex_Main.aspx's
    // #mainiframecontainer now - a box smaller than the full browser window, not
    // a standalone top-level window. The dhtmlmodal.open() below still centers
    // itself using screen.width/height (the physical monitor), so inside that
    // clipped iframe box it renders off to the side/bottom, outside the visible
    // area - looking like the popup never opened. The premium shell's own
    // "AI DASHBOARD" menu item opens this exact same
    // ../OCR_Dashboard/Ocr_Ai_Dashboard.aspx via its openGenericModal() overlay
    // instead (a real top-document overlay, not clipped by the iframe), so route
    // there first when it's available, keeping every entry point to this page
    // showing the identical popup. Falls through to the old dhtmlmodal popup
    // below for any older, non-premium master page that never defines
    // window.top.openGenericModal.
    if (window.top && window.top.openGenericModal) {
        window.top.openGenericModal('../OCR_Dashboard/Ocr_Ai_Dashboard.aspx?Job_type=' + Val + '', 1300, 695);
        return;
    }

    closeExistingPopup();

    w = '1300';
    h = '695';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=1';
    adcodewindow = dhtmlmodal.open('OCR_Dashboard', 'iframe', '../OCR_Dashboard/Ocr_Ai_Dashboard.aspx?Job_type=' + Val + '', '', settings)
}

function open_Template_Creation(val) {
    // Thin wrapper so openOCRTool()'s "Template Creation" card (OCR_Dashboard/
    // Ocr_Ai_Dashboard.aspx) can route through openInTop() like every other card
    // there, instead of calling window.open() directly - openInTop() is what
    // actually closes the AI Dashboard popup (openGenericModal or the older
    // dhtmlmodal toolbar-icon path) once the tool opens; called directly, the
    // dashboard was left open behind the new tab. No popup of our own to create
    // here (it's an external site opened in a new browser tab, not a dhtmlmodal
    // window), so this doesn't touch the global `adcodewindow`.
    window.open("https://docparser.docr.online/", "_blank");
}

function Import_Bulk_Excel_Upload(val) {
    w = '938';
    h = '495';

    LeftPosition = (screen.width) ? (screen.width - w) / 100 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / -25 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Complete Job Details Import', 'iframe', '../Import_XL/Import_Job_Bulk_Excel.aspx', '', settings)
}

function open_Ocr_Dashboard(val) {

    closeExistingPopup();

    w = '1300';
    h = '800';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Ocr Dashboard page', 'iframe', '../OCR_Dashboard_report/OCR_Dashboard.aspx', '', settings);

    setTimeout(function () {
        if (typeof myJQ.fn.daterangepicker === "function") {
            myJQ('#<%= txtDateRange.ClientID %>').daterangepicker();
        }
    }, 500);
}

function closeExistingPopup() {
    try {
        // .hide() (not .close()) is the modal-aware close - dhtmlmodal.open() (modalfiles/
        // modal.js) OVERWRITES t.hide to call dhtmlmodal.close(this), which closes the window
        // AND decrements veilstack/hides #interVeil, the darkened backdrop behind every
        // dhtmlmodal popup. t.close is still the original dhtmlwindow.js method underneath -
        // it closes the window box itself but never touches the veil at all. Calling .close()
        // here (despite checking for .hide as the "is this a real modal window" test just
        // above) closed the popup but left the backdrop blur on screen permanently, since
        // nothing else was left to call closeveil() for it.
        if (typeof adcodewindow !== 'undefined' && adcodewindow && typeof adcodewindow.hide === 'function') {
            adcodewindow.hide();
        }
    } catch (e) { }
}
function opennewclientnew_New(val) {
    w = '1266';
    h = '588';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master_New.aspx?Page=' + val + '', '', settings)
}

function opennewclientupdate_New(val, name,Std) {
    w = '1266';
    h = '588';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    var doc = new DOMParser().parseFromString(name, "text/html");
    adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master_New.aspx?IMP_EXP_IECNO=' + val + '&Name=' + doc.documentElement.textContent + '&STD_NON=' + Std + '', '', settings)
   // adcodewindow = dhtmlmodal.open('ClientMaster', 'iframe', '../eRoyalMasters/Client_Master_New.aspx?IMP_EXP_IECNO=' + val + '', '', settings)
}

function ColumbEditMaster() {
    adcodewindow = dhtmlmodal.open('eRoyal Ads', 'iframe', '../Transaction/ColumnsEditMaster.aspx', '', NewWindow('900', '500'))
}