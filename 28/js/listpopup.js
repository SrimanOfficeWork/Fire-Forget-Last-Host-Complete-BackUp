
//-------------------------AUTO CENTER---------------------------------------------------
var win = null;
function NewWindow1(mypage, myname, w, h, scroll) {
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
    settings ='height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
    win = window.open(mypage, myname, settings);
    win.focus();

    return false;
}
//---------------------------------------------------------------------------------------
//Session Clear
//---------------------------------------------------------------------------------------
function SessionClear() {
    $.post("../Session_Clear.ashx", null, function () {

    });
}


//---------------------------------------------------------------------------------------
//Productmaster Tabcontainer
//---------------------------------------------------------------------------------------




//---------------------------------------------------------------------------------------
//refresh parent window
//---------------------------------------------------------------------------------------
function RefreshParent() {

    window.parent.location.href = window.parent.location.href;
}
//---------------------------------------------------------------------------------------

//adcode master new
//---------------------------------------------------------------------------------------


function opennewStatecode(val) {

  
    NewWindow1('../ListPopup/StateMaster_ListPopup.aspx?Name=' + val + '', 'List', '810', '470', 'yes');

//    var winPop = false;
//    if (winPop && !winPop.closed) {  //checks to see if window is open  
//        winPop.focus();
//    }
//    else {
//        winPop = window.open("../ListPopup/StateMaster_ListPopup.aspx", "winPop", "width=450,height=463,menubar=no,left=280,top=150,bottom=60,resizable=0,ScrollBars=1");
    //    }  

   
  

}

function opennewieccode() {

    NewWindow1('../ListPopup/IMP_EXP_Master_ListPopup.aspx', 'List', '810', '470', 'yes');
    
}

function opennewadcode5(val) {
    //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../modalfiles/adcodemasterNew - Normal Popup Window.htm', '', 'width=470px,height=550px,center=1,resize=0,scrolling=0')
    //adcodewindow2 = dhtmlmodal.open('ADcodeSearch', 'iframe', '../ListPopup/IMP_EXP_Master_ListPopup.aspx', '', 'width=470px,height=550px,center=1,resize=0,scrolling=0')

}

function opennewadcode4() {

    if (window.showModalDialog) {
        var retValue = showModalDialog("../ListPopup/StateMaster_ListPopup.aspx", "", "dialogWidth=450px, dialogHeight=463px, dialogLeft=280px, dialogTop=150px");


    }

}

//---------------------------------------------------------------------------------------

//Client master new
//---------------------------------------------------------------------------------------



function opennewstatecodeold() {
    //adcodewindow2 = dhtmlmodal.open('ADcode2', 'iframe', 'adcodemasterNew2.html', '', 'width=670px,height=250px,center=1,resize=0,scrolling=0')
    if (window.showModalDialog) {
        var retValue = showModalDialog("../ListPopup/StateMaster_ListPopup.aspx", "", "dialogWidth:450px; dialogHeight:463px; dialogLeft:280px; dialogTop:150px;");


    }
}
//---------------------------------------------------------------------------------------
//Consignee master new
//---------------------------------------------------------------------------------------


function opennewcountrycode() {

    NewWindow1('../ListPopup/CountryMaster_ListPopup.aspx', 'List', '810', '470', 'yes');




}
//---------------------------------------------------------------------------------------

//Product master new

//---------------------------------------------------------------------------------------

//        function OpenPopupRITC() {

//            window.open("../ListPopup/BCD_CTH_ListPopup.aspx", "List", "scrollbars=no,resizable=no,width=620,height=240");

//            return false;

//        }

function OpenPopupCountry(val) {

    NewWindow1('../ListPopup/CountryMaster_ListPopup.aspx?shipid=' + val + '', 'List', '810', '470', 'yes');
}

function OpenPopupDrawback(val,Unit) {

    NewWindow1('../ListPopup/Drawback_Master_ListPopup.aspx?Drawback=' + val + ' &Unit=' + Unit + '', 'List', '810', '470', 'yes');
}

function OpenPopupUnit(val) {

    NewWindow1('../ListPopup/Unit_ListPopup.aspx?unit=' + val + '', 'List', '810', '470', 'yes');
}

function OpenPopupUnit_Goods_Reg(val) {

    NewWindow1('../../ListPopup/Unit_ListPopup.aspx?unit=' + val + '', 'List', '810', '470', 'yes');
}

function OpenPopup_SpportingDocs(val,val1) {

    NewWindow1('../ListPopup/SUPPORTING_DOCS_TYPECODE_ListPopup.aspx?SUPDOC=' + val + ' &Jobtype=' + val1 + '', 'List', '810', '470', 'yes');
}

//---------------------------------------------------------------------------------------

//Supplier master new
//---------------------------------------------------------------------------------------



function OpenPopup() {

    NewWindow1('../ListPopup/CountryMaster_ListPopup.aspx', 'List', '810', '470', 'yes');



}

//---------------------------------------------------------------------------------------

//Custom House master new
//---------------------------------------------------------------------------------------



function OpenPopup_CustomHouse() {

    NewWindow1('../ListPopup/Customs_House_ListPopup.aspx', 'List', '810', '470', 'yes');



}
//---------------------------------------------------------------------------------------

function OpenPopupImporterDetails(val) {

    NewWindow1('../ListPopup/IMPORTER_Details_ListPopup.aspx?seller_id=' + val + '', 'List', '810', '470', 'yes');

}
function OpenPopupImporterDetails_New(val,val1) {

    NewWindow1('../ListPopup/IMPORTER_Details_ListPopup.aspx?seller_id=' + val + ' &NAME=' + val1 + '', 'List', '810', '470', 'yes');

}
function OpenPopupExporter_Master(val) {

    NewWindow1('../ListPopup/IMPORTER_Details_ListPopup.aspx?seller_id=' + val + '', 'List', '810', '470', 'yes');

}
//function OpenPopupImporter_Master_BranchSlno(val) {

//    NewWindow1('../ListPopup/IMPORTER_Details_ListPopup.aspx?seller_id=' + val + '', 'List', '810', '470', 'yes');

//}


function OpenPopupPortDetails(val) {

    NewWindow1('../ListPopup/Port_Details_ListPopup.aspx?Port_Ship=' + val + '', 'List', '810', '470', 'yes');

}
function OpenPopupPortDetails_CountrySearch(val) {

    NewWindow1('../ListPopup/Port_Details_Country_Search_ListPopup.aspx?Port_Ship=' + val + '', 'List', '810', '470', 'yes');

}
function OpenPopupCustom_House_Details() {

    NewWindow1('../ListPopup/Customs_House_ListPopup.aspx', 'List', '810', '470', 'yes');


}
function OpenPopupCustom_House_Details(val) {

    NewWindow1('../ListPopup/Customs_House_ListPopup.aspx?Trans_Port=' + val + '', 'List', '810', '470', 'yes');


}
//IMPORT PORT OF LICENSE AND EXPORT JOBBING
function OpenPopupCustom_House_Details_Port(val,val1) {

    NewWindow1('../ListPopup/Customs_House_ListPopup.aspx?Trans_Port=' + val + '&Port=' + val1 + '', 'List', '810', '470', 'yes');


}
//IMPORT PORT OF LICENSE AND EXPORT JOBBING

function OpenPopupCountryOrigin(val) {

    NewWindow1('../ListPopup/CountryMaster_ListPopup.aspx?shipid=' + val + '', 'List', '810', '470', 'yes');

}


function OpenPopup_Package_Details() {

    NewWindow1('../ListPopup/Package_Master_ListPopup.aspx', 'List', '810', '470', 'yes');

}

function OpenPopup_Airline_Details() {

    NewWindow1('../ListPopup/Airline_Master_ListPopup.aspx', 'List', '810', '470', 'yes');

}


function OpenPopupUnit(val) {

    NewWindow1('../ListPopup/Unit_ListPopup.aspx?unit=' + val + '', 'List', '810', '470', 'yes');

}
function OpenPopupSupplier(val) {

    NewWindow1('../ListPopup/Supplier_Details_ListPopup.aspx?Supplier=' + val + '', 'List', '810', '470', 'yes');

}
function OpenPopupNotn(val) {

    //NewWindow1('../ListPopup/NotnListPopup.aspx', 'List', '810', '470', 'yes');

    NewWindow1('../ListPopup/Notification_Custom_MasterListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');
 

}
function OpenPopupExchange(val) {
    NewWindow1('../ListPopup/Exchange_Details_ListPopup.aspx?Invoice=' + val + '', 'List', '810', '470', 'yes');
}

function OpenPopup_Exp_Thirdparty(val) {
    NewWindow1('../ListPopup/Imp_Exp_ThirdParty_Master_ListPopup.aspx?Invoice=' + val + '', 'List', '810', '470', 'yes');
} 

function OpenPopupConsignee(val) {
    NewWindow1('../ListPopup/Consignee_Master_ListPopup.aspx?Consignee=' + val + '', 'List', '810', '470', 'yes');

}
function OpenPopupBuyer(val) {
    NewWindow1('../ListPopup/buyer_Master_ListPopup.aspx?buyer=' + val + '', 'List', '810', '470', 'yes');

}





function OpenPopupAdcode(clientname, iecno, Type) {

    NewWindow1('../ListPopup/Adcode_Master_ListPopup.aspx?clientname=' + clientname + '&iecno=' + iecno + '&Type=' + Type + '', 'List', '810', '470', 'yes');
}


function OpenPopupCTH(val) {

    NewWindow1('../ListPopup/BCD_CTH_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');


}
function OpenPopup_Export_Ritc(val) {

    NewWindow1('../ListPopup/Export_RITC_Master_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');


}


function OpenPopup_Export_Product_Ritc(val, val2) {

    NewWindow1('../ListPopup/Export_RITC_Master_ListPopup.aspx?id=' + val + '&desc=' + val2 + '', 'List', '810', '470', 'yes');
}

Line: 384

function OpenPopupProduct_Export_Product_Master(val) {
    //    NewWindow1('../ListPopup/Export_ItemDesc_Search_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');
    NewWindow1('../ListPopup/Product_Export_Master_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');

}



function OpenPopupCETH(val) {

    NewWindow1('../ListPopup/BCD_CETH_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');


}
function OpenPopup_Notification_Excise(val) {
    NewWindow1('../ListPopup/Notification_Excise_Master_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');
}
function OpenPopup_Notification_Excise_IGST(val, val2) {
    NewWindow1('../ListPopup/Notification_Excise_Master_ListPopup_IGST.aspx?id=' + val + '&RITC=' + val2 + '', 'List', '810', '470', 'yes');
}
function OpenPopup_Notification_Excise_CTH(val, val2) {
    NewWindow1('../ListPopup/Notification_Excise_Master_ListPopup.aspx?id=' + val + '&RITC=' + val2 + '', 'List', '810', '470', 'yes');
}
//function opennew_Import_report(val) {
//    
//    NewWindow1('../Report/Import_ReportViewer.aspx?jobno=' + val + '', 'List', '810', '1024', 'yes');

//}

//function opennew_Export_report(val) {
//    NewWindow1('../Report/Export_ReportViewer.aspx?jobno=' + val + '', 'List', '810', '1024', 'yes');

//}
//function opennew_Export_report1(val1,val2,val3) {
//    NewWindow1('../Report/Export_ReportViewer.aspx?jobno=' + val1 + '&Annexure_Mode=' + val2 + '&STR_CODE=' + val3 + '', 'List', '810', '1024', 'yes');

//}
//function opennew_Export_Goods_Registration_report(val1,val2,val3) {
//    NewWindow1('../Report/Goods_ReportViewer.aspx?jobno=' + val1 + '&customhouse=' + val2 + '&transportmode=' + val3 + '', 'List', '810', '1024', 'yes');

//}

//EXPORT STR DETAILS POPUP
function Opennew_STR_Details(val) {
    NewWindow1('../ListPopup/STR_Details.aspx?RITCNO=' + val + '', 'List', '810', '470', 'yes');

}
//EXPORT JOBBING DETAILS POPUP
function OpenPopupExport_Port_House(val) {
    NewWindow1('../ListPopup/Customs_House_ListPopup.aspx', 'List', '810', '470', 'yes');


}

function OPen_ERoyalImpexMain_Popup() {
   // NewWindow1('E_royal_Impex_Main.aspx', 'List', '', '', 'yes');


}
function newPopup_Privacy(val) {
    NewWindow1(val, 'List', '810', '470', 'yes');

}
function newPopup_Disclaimer(val) {
    NewWindow1(val, 'List', '810', '470', 'yes');

}
//LICENSE MASTER
function OpenPopupLicense_Master(val) {
    NewWindow1('../ListPopup/License_Master_ListPopup.aspx?License_type=' + val + '', 'List', '810', '470', 'yes');


}

function OpenPopupProduct_Imp_Exp_Master(val) {
    NewWindow1('../ListPopup/Product_Imp_Exp_Master_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');


}

/*ram start*/
function OpenPopupPortDetails_display(val) {

    NewWindow1('../ListPopup/Port_Details_ListPopup.aspx?Port_Ship=' + val + '', 'List', '810', '470', 'yes');

}


function OpenPopupDeclaration(val) {

    NewWindow1('../Report/Import_Declaration.aspx?DL=' + val + '', 'List', '810', '1024', 'yes');
}

/*ram end*/

function OpenPopupCustomsDeclaration() {

    NewWindow1('../Report/Import_Customs_Declaration_Rpt_viewer.aspx', 'List', '810', '1024', 'yes');
}

function OpenPopup_Export_CESS_MASTER(val) {

    NewWindow1('../ListPopup/Export_CESS_Master_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');

}

function OpenPopup_Countrywise_Summary(val) {

    NewWindow1('../Report/Chart.aspx?Type=' + val + '', 'List', '810', '1024', 'yes');
}



function OpenPopupBLGeneration_ACD() {

    NewWindow1('../Report/Export_BL_Generation_ACD.aspx', 'List', '910', '1024', 'yes');
}



//----------------------Start Billing----------------------------//
function opennew_chargemaster(val) {

    NewWindow1('../ListPopup/ChargeMaster_ListPopup.aspx?ChargeName='+val+'', 'List', '810', '470', 'yes');

}

function OpenPopup_Charge_Master_New() {
    NewWindow1('../Billing/Charge_Master.aspx', 'List', '457', '393', 'yes');
}

function OpenPopup_Client_Master(val) {

    NewWindow1('../ListPopup/IMPORTER_Details_ListPopup.aspx?seller_id=' + val + '', 'List', '810', '470', 'yes');

}

//----------------------End Billing-----------------------------//



//************************************ REPORT CLIENT MASTER START *********************************//

function OpenPopupReportClient_Master(val) {

    NewWindow1('../ListPopup/Report_Client_Master_Details_ListPopup.aspx?seller_id=' + val + '', 'List', '810', '470', 'yes');

}

//************************************ REPORT CLIENT MASTER END *********************************//


function OpenPopupReportAgent_Vessel_Master(val) {

    NewWindow1('../ListPopup/Report_Agent_Vessel_Master_Details_ListPopup.aspx?seller_id=' + val + '', 'List', '810', '470', 'yes');

}


function OpenPopup_End_Use_Of_Itemd(val) {

    NewWindow1('../ListPopup/End_Use_Item_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');

}

function OpenPopup_Import_License_Master(val) {
    NewWindow1('../ListPopup/Import_License_Master_ListPopup.aspx?License_type=' + val + '', 'List', '810', '470', 'yes');  
}

function OpenPopup_RSP() {
    NewWindow1('../ListPopup/RSP_ListPopup.aspx', 'List', '810', '470', 'yes');
}


function OpenPopupConsigneeBranchslno(val, val1) {
    NewWindow1('../ListPopup/Consignee_Master_ListPopup.aspx?Consignee=' + val + '&Name=' + val1 + '', 'List', '810', '470', 'yes');

}

function OpenPopupProduct_Imp_Desc_Search_PartyWise(val) {
    NewWindow1('../ListPopup/Imp_ItemDesc_Search_JOB_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');
}



function OpenPopupLicenseSummaryReport() {

    NewWindow1('../BAS_Shipping/Imp_License_Summary_rpt.aspx', 'List', '810', '1024', 'yes');
}
function OpenPopupProduct_Imp_Exp_Master_Fairmax(val) {
    NewWindow1('../ListPopup/Product_Imp_Exp_Master_ListPopup_Fairmax.aspx?id=' + val + '', 'List', '810', '470', 'yes');
}

//************************************ EGM- MASTER Start *********************************//

function OpenPopu_EGM_Liner_Master(val) {

    NewWindow1('../ListPopup/EGM_Liner_Master_ListPopup.aspx', 'List', '810', '470', 'yes');

}

function OpenPopu_EGM_Vessel_Master(val) {

    NewWindow1('../ListPopup/EGM_Vessel_Master_ListPopup.aspx', 'List', '810', '470', 'yes');

}
//************************************ EGM- Master end *********************************//


function OpenJOB_Details_From_Other_Package(val) {

    NewWindow1('../ListPopup/JOB_Details_From_Other_Package_ListPopup.aspx?seller_id=' + val + '', 'List', '810', '470', 'yes');

}


function opennew_District_Statecode(val) {
    NewWindow1('../ListPopup/District_StateMaster_ListPopup.aspx?Name=' + val + '', 'List', '810', '470', 'yes');
}


function opennew_PTA_FTA_Agreement(val) {
    NewWindow1('../ListPopup/PTA_FTA_Agreement_Master_ListPopup.aspx?Name=' + val + '', 'List', '810', '470', 'yes');
}

function OpenPopup_Issuing_Party_Details(val) {
    NewWindow1('../ListPopup/IMPORTER_Details_ListPopup.aspx?seller_id=' + val + '', 'List', '810', '470', 'yes');
}
function OpenPopup_Beneficiary_Partyls() {
    var rb = document.getElementById("Rd_Imp_Exp");
    var radio = rb.getElementsByTagName("input");
    var Rd_value;
    for (var i = 0; i < radio.length; i++) {
        if (radio[i].checked) {
            Rd_value = radio[i].value
            break;
        }
    }
    if (Rd_value == 'I') {
        NewWindow1('../ListPopup/Supplier_Details_ListPopup.aspx?Supplier=' + "Beneficiary" + '', 'List', '810', '470', 'yes');
    }
    else {
        NewWindow1('../ListPopup/Consignee_Master_ListPopup.aspx?Consignee=' + "Beneficiary" + '', 'List', '810', '470', 'yes');
    }
}

function OpenPopup_Spporting_Docs(val) {
    NewWindow1('../ListPopup/Supporting_Docs_ListPopup.aspx?Imp_Exp=' + val + '', 'List', '920', '470', 'yes');
}

function OpenPopup_Imp_Exp_Ryal_Job(val) {

    if (document.getElementById("hdn_CompanyID").value == "861" || document.getElementById("hdn_CompanyID").value == "1317" || document.getElementById("hdn_CompanyID").value == "1339"  || document.getElementById("hdn_CompanyID").value == "880") {
        NewWindow1('../Ryal/ICode_Imp_Exp_Webservice_Data.aspx?Imp_Exp=' + val + '', 'List', '950', '470', 'yes');
    }
    else if(document.getElementById("hdn_CompanyID").value == "752"){
    NewWindow1('../Ryal/Imp_Exp_Webservice_Data.aspx?Imp_Exp=' + val + '', 'List', '950', '470', 'yes');
    }
else {
    
    NewWindow1('../API_Data/Imp_Exp_Webservice_Data.aspx?Imp_Exp=' + val + '', 'List', '950', '470', 'yes');
    }
}

function OpenPopupAIDC(val, country) {
    var aa = document.getElementById("txtCTH_No").value;

    NewWindow1('../ListPopup/AIDC_Master_ListPopup.aspx?RITC=' + aa + ' &Country_Name=' + country + '', 'List', '810', '470', 'yes');
}

function OpenPopup_Imp_Exp_I_Code_Job(val) {
    NewWindow1('../Ryal/ICode_Imp_Exp_Webservice_Data.aspx?Imp_Exp=' + val + '', 'List', '950', '470', 'yes');
}

function OpenPopup_AntiDumping_Notification(val) {
    NewWindow1('../ListPopup/AntiDumping_Master_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');
}


function OpenPopup_EsanchitTrack(val, val1) {

    NewWindow1('../ListPopup/ESanchitMailTrack.aspx?SUPDOC=' + val + ' &Jobtype=' + val1 + '', 'List', '810', '470', 'yes');
}

function OpenPopup_SVB_Details(val) {
    NewWindow1('../ListPopup/Svb_Relation_ListPopup.aspx?SUPPLIER_NAME=' + val + '', 'List', '810', '470', 'yes');
}

function openPopup_Transport_Masternew(val) {

    //ExchangeMasterwindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/Exchange_Master.aspx?EXCHANGE_ID=' + val + '', '', NewWindow('451', '340'))adcodewindow = dhtmlmodal.open('ExchangeMaster', 'iframe', '../eRoyalMasters/Transport_Master.aspx?TRANSPORTS_ID=' + val + '', '', NewWindow('451', '340'))
    NewWindow1('../ListPopup/Transport_Master_ListPopup.aspx?TRANSPORT_NAME=' + val + '', 'List', '810', '470', 'yes');
}

function openTransportMaster() {

    NewWindow1('../ListPopup/Transport_Master_ListPopup.aspx', 'List', '810', '470', 'yes');
}
function OpenAdCode() {

    var aa = document.getElementById("txtIECNO").value;
    var bb = document.getElementById("txtName").value;
    var cc = document.getElementById("txtBranchNO").value;

    NewWindow1('../eRoyalMasters/Adcode_Master.aspx?IEC=' + aa + '&Name=' + bb + '&brslo=' + cc + '', 'List', '457', '450', 'yes');
}


function OpenPopup_Job_Prefix_Suffix_Areawise(val) {
    NewWindow1('../ListPopup/Admin_Job_Prefix_Suffix_ListPopup.aspx?id=' + val + '', 'List', '810', '470', 'yes');
}


function OpenPopupSupplier_JOB_Edit(Supname, slno) {
    var doc = new DOMParser().parseFromString(Supname, "text/html");
    NewWindow1('../eRoyalMasters/Supplier_Master_JOB_Edit.aspx?Name=' + encodeURIComponent(doc.documentElement.textContent) + '&Slno=' + slno + '', 'List', '450', '390', 'yes');
}

function OpenPopupBuyer_JOB_Edit(Buyername, ddlbuyer) {
    if (ddlbuyer == 'No') {
        var doc = new DOMParser().parseFromString(Buyername, "text/html");
        NewWindow1('../eRoyalMasters/Buyer_Master_JOB_Edit.aspx?Name=' + encodeURIComponent(doc.documentElement.textContent) + '', 'List', '450', '300', 'yes');
    }
}


function OpenPopup_Consignee_JOB_Edit(Consigneename, slno) {
    var doc = new DOMParser().parseFromString(Consigneename, "text/html");
    NewWindow1('../eRoyalMasters/Consignee_Master_JOB_Edit.aspx?Name=' + encodeURIComponent(doc.documentElement.textContent) + '&Slno=' + slno + '', 'List', '450', '450', 'yes');
}

