
//-----------------------------------START ADCODE MASTER PAGE VALIDATION--------------------------------------//

function validate_Adcode() {
    var ieccode;
    ieccode = document.getElementById("txtIec_Code").value;

    if (ieccode.length <= 0) {

        jAlert('IEC code Field cannot be blank', 'ADCODE MASTER', function (r) { document.getElementById("txtIec_Code").focus(); });

        return false;
    }


    else if (ieccode.length < 10) {
        jAlert('IEC code  Should be 10 digit numbers', 'ADCODE MASTER', function (r) { document.getElementById("txtIec_Code").focus(); });

        return false;
    }


    var iecname;
    iecname = document.getElementById("txtIec_Name").value;

    if (iecname.length <= 0) {
        jAlert('IEC Name  cannot be blank', 'ADCODE MASTER', function (r) { document.getElementById("txtIec_Name").focus(); });

        return false;
    }


    var adcode;
    adcode = document.getElementById("txtAdcode").value;
    ImportAdcode = document.getElementById("txtImportAdcode").value;

    if (adcode.length <= 0 && ImportAdcode.length <= 0) {

        jAlert('Adcode cannot be blank', 'ADCODE MASTER', function (r) { document.getElementById("txtAdcode").focus(); });
        return false;

    }
    var pincode;
    pincode = document.getElementById("txtPincode").value;
    if (pincode != "") {
        if (pincode.length < 6) {

            jAlert('Pin code should be 6 numbers', 'ADCODE MASTER', function (r) { document.getElementById("txtPincode").focus(); });

            return false;
        }
    }
}
//-----------------------------------  END ADCODE MASTER PAGE VALIDATION--------------------------------------//

//                                        ***************************************                                     //




//-----------------------------------START CLIENT MASTER PAGE VALIDATION--------------------------------------//
function validate_Client() {


    if (document.getElementById("txtIECNO").value.length <= 0) {

        jAlert('IEC code cannot be blank', 'CLIENT MASTER', function (r) { document.getElementById("txtIECNO").focus(); });

        return false;
    }
    //    var digits = "0123456789";
    //    var temp;
    //    for (var i = 0; i < document.getElementById("txtIECNO").value.length; i++) {
    //        temp = document.getElementById("txtIECNO").value.substring(i, i + 1);
    //        if (digits.indexOf(temp) == -1) {


    //            document.getElementById("txtIECNO").focus();

    //            return false;
    //        }
    //    }
    var mno;
    mno = document.getElementById("txtIECNO").value;

    if (mno.length < 10) {

        jAlert('IEC code should be 10 Characters', 'CLIENT MASTER', function (r) { document.getElementById("txtIECNO").focus(); });


        return false;
    }


    if (document.getElementById("txtBranchNO").value.length <= 0) {

        jAlert('BranchNo cannot be blank', 'CLIENT MASTER', function (r) { document.getElementById("txtBranchNO").focus(); });

        return false;
    }
    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtBranchNO").value.length; i++) {
        temp = document.getElementById("txtBranchNO").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {

            document.getElementById("txtBranchNO").focus();

            return false;
        }
    }

    if (document.getElementById("txtName").value.length <= 0) {

        jAlert('Name cannot be blank', 'CLIENT MASTER', function (r) { document.getElementById("txtName").focus(); });

        return false;
    }               



    if (document.getElementById("txtAdd1").value.length <= 0) {

        jAlert('Address1 cannot be blank', 'CLIENT MASTER', function (r) { document.getElementById("txtAdd1").focus(); });


        return false;
    }

    //    if (document.getElementById("txtPincode").value.length <= 0) {

    //        alert("PinCode cannot be blank");

    //        document.getElementById("txtPincode").focus();

    //        return false;
    //    }
    var j = document.getElementById("txtPincode").value;
    if (j != "") {
        if (j.length < 6) {

            jAlert('Pincode should be 6 digit numbers', 'CLIENT MASTER', function (r) { document.getElementById("txtPincode").focus(); });

            return false;
        }
    }

    //            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
    //    var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
    var emailPat = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    var emailid = document.getElementById("txtEmail").value;
    var matchArray = emailid.match(emailPat);
    if (document.getElementById("txtEmail").value != "") {
        if (matchArray == null) {

            jAlert('Email id not valid', 'CLIENT MASTER', function (r) { document.getElementById("txtEmail").focus(); });
            return false;
        }
    }

    var ddlCommercialStateName = document.getElementById('ddlCommercial_StateName').value;
    if (ddlCommercialStateName == '') {
        jAlert('Select Commercial State', 'CLIENT MASTER', function (r) { document.getElementById('ddlCommercial_StateName').focus(); });
        return false;
    }

    if ($("#ddlCommercial_Tax_yn option:selected").text() == 'Y') {

        if (document.getElementById("txtCommercial_StateCode").value.length <= 0) {

            jAlert('Commercial State Code cannot be blank', 'CLIENT MASTER', function (r) { document.getElementById("txtCommercial_StateCode").focus(); });
            return false;
        }
        if (document.getElementById("txtCommercial_RegistrationNo").value.length <= 0) {

            jAlert('Commercial Reg. No cannot be blank', 'CLIENT MASTER', function (r) { document.getElementById("txtCommercial_RegistrationNo").focus(); });
            return false;
        }
        if (document.getElementById("ddl_EXP_GSTN_Type").value.length <= 0) {
            jAlert('Commercial Type cannot be blank', 'CLIENT MASTER', function (r) { document.getElementById("ddl_EXP_GSTN_Type").focus(); });
            return false;
        }

        var StateName_chk;
        StateName_chk = document.getElementById("hdn_StateName_chk").value;
        if (StateName_chk != "Yes") {

            jAlert('Invalid State Name', 'CLIENT MASTER', function (r) { document.getElementById("txtStateName").focus(); });
            return false;
        }


        var Commercial_StateName;
        Commercial_StateName = document.getElementById("hdn_Commercial_StateName_chk").value;
        if (Commercial_StateName != "Yes") {

            jAlert('Invalid Commercial State Name', 'CLIENT MASTER', function (r) { document.getElementById("txtCommercial_StateName").focus(); });
            return false;
        }

    }
    return true;
}
//-----------------------------------END CLIENT MASTER PAGE VALIDATION----------------------------------------//


//                                        ***************************************                                     //



//-----------------------------------START CONSIGNEE MASTER PAGE VALIDATION----------------------------------------//

function validate_Consignee() {
    if (document.getElementById("txtName").value.length <= 0) {

        jAlert('Name cannot be blank', 'CONSIGNEE MASTER', function (r) { document.getElementById("txtName").focus(); });

        return false;
    }

    if (document.getElementById("txtAdd1").value.length <= 0) {

        jAlert('Address1 cannot be blank', 'CONSIGNEE MASTER', function (r) { document.getElementById("txtAdd1").focus(); });

        return false;
    }

    if (document.getElementById("txtCountryName").value.length <= 0) {

        jAlert('Country Name cannot be blank', 'CONSIGNEE MASTER', function (r) { document.getElementById("txtCountryName").focus(); });

        return false;
    }

    if (document.getElementById("txtCountryCode").value.length <= 0) {

        jAlert('Country Code cannot be blank', 'CONSIGNEE MASTER', function (r) { document.getElementById("txtCountryCode").focus(); });

        return false;
    }



    ////    if (document.getElementById("txtPincode").value.length <= 0) {
    ////        alert("Pincode cannot be blank");
    ////        document.getElementById("txtPincode").focus();

    ////        return false;
    ////    }



    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtPincode").value.length; i++) {
        temp = document.getElementById("txtPincode").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {

            document.getElementById("txtPincode").focus();
            return false;
        }
    }


}
//-----------------------------------END CONSIGNEE MASTER PAGE VALIDATION----------------------------------------//

//                                        ***************************************                                     //
//-----------------------------------START BUYER MASTER PAGE VALIDATION----------------------------------------//

function validate_Buyer() {
    if (document.getElementById("txtName").value.length <= 0) {

        jAlert('Name cannot be blank', 'BUYER MASTER', function (r) { document.getElementById("txtName").focus(); });

        return false;
    }

    if (document.getElementById("txtAdd1").value.length <= 0) {

        jAlert('Address1 cannot be blank', 'BUYER MASTER', function (r) { document.getElementById("txtAdd1").focus(); });

        return false;
    }




    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtPincode").value.length; i++) {
        temp = document.getElementById("txtPincode").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {

            document.getElementById("txtPincode").focus();
            return false;
        }
    }


}
//-----------------------------------END BUYER MASTER PAGE VALIDATION----------------------------------------//

//                                        ***************************************                                     //


//-----------------------------------START EXCHANGE MASTER PAGE VALIDATION----------------------------------------//


function validate_Exchange() {

    if (document.getElementById("txtExchange_Date_From").value.length <= 0) {
        jAlert('From date cannot be blank', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_Date_From").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtExchange_Date_From").value)) {

    }
    else {
        jAlert('From Date is Invalid Date', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_Date_From").focus(); });

        return false;
    }

    if (document.getElementById("txtExchange_Date_To").value.length <= 0) {
        jAlert('To date cannot be blank', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_Date_To").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtExchange_Date_To").value)) {

    }
    else {
        jAlert('To Date is Invalid Date', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_Date_To").focus(); });

        return false;
    }
    if (document.getElementById("txtExchange_NONT_NO").value.length <= 0) {
        jAlert('Notification number cannot be blank', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_NONT_NO").focus(); });

        return false;
    }

    if (document.getElementById("txtExchange_NONT_Date").value.length <= 0) {
        jAlert('Notification date cannot be blank', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_NONT_Date").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtExchange_NONT_Date").value)) {

    }
    else {
        jAlert('Notification Date is Invalid Date', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_NONT_Date").focus(); });

        return false;
    }

    if (document.getElementById("txtExchange_Cur_Code").value.length <= 0) {
        jAlert('Currency code cannot be blank', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_Cur_Code").focus(); });

        return false;
    }

    if (document.getElementById("txtExchange_Name").value.length <= 0) {
        jAlert('Currency name cannot be blank', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_Name").focus(); });

        return false;
    }

    if (document.getElementById("txtExchange_Per_Unit").value.length <= 0) {
        jAlert('per unit cannot be blank', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_Per_Unit").focus(); });

        return false;
    }

    if (document.getElementById("txtExchange_Rate_Import").value.length <= 0) {
        jAlert('Import exchange rate cannot be blank', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_Rate_Import").focus(); });

        return false;
    }

    if (document.getElementById("txtExchange_Rate_Export").value.length <= 0) {
        jAlert('Export exchange rate cannot be blank', 'EXCHANGE MASTER', function (r) { document.getElementById("txtExchange_Rate_Export").focus(); });

        return false;
    }

}
//-----------------------------------END EXCHANGE MASTER PAGE VALIDATION----------------------------------------//
//-----------------------------------START NON STD CURRENCY MASTER PAGE VALIDATION----------------------------------------//


function validate_NON_CURRENCY_MASTER() {

    if (document.getElementById("txtEx_Effect_dt_Imp").value.length <= 0) {
        jAlert('Import Effective date cannot be blank', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_Effect_dt_Imp").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtEx_Effect_dt_Imp").value)) {

    }
    else {
        jAlert('Import Effective Date is Invalid Date', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_Effect_dt_Imp").focus(); });

        return false;
    }

    if (document.getElementById("txtEx_Effect_dt_Exp").value.length <= 0) {
        jAlert('Export Effective date cannot be blank', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_Effect_dt_Exp").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtEx_Effect_dt_Exp").value)) {

    }
    else {
        jAlert('Export Effective Date is Invalid Date', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_Effect_dt_Exp").focus(); });

        return false;
    }


    if (document.getElementById("txtEx_Cur_Code").value.length <= 0) {
        jAlert('Currency code cannot be blank', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_Cur_Code").focus(); });

        return false;
    }

    if (document.getElementById("txtEx_name").value.length <= 0) {
        jAlert('Currency name cannot be blank', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_name").focus(); });

        return false;
    }
    if (document.getElementById("txtEx_Rt_Imp").value.length <= 0) {
        jAlert('Import exchange rate cannot be blank', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_Rt_Imp").focus(); });

        return false;
    }

    if (document.getElementById("txtEx_Rt_Exp").value.length <= 0) {
        jAlert('Export exchange rate cannot be blank', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_Rt_Exp").focus(); });

        return false;
    }
    if (document.getElementById("txtEx_BankName").value.length <= 0) {
        jAlert('Bank Name cannot be blank', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_BankName").focus(); });

        return false;
    }
    if (document.getElementById("txtEx_Certificate_no").value.length <= 0) {
        jAlert('Certificate No. cannot be blank', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_Certificate_no").focus(); });

        return false;
    }

    if (document.getElementById("txtEx_Certificate_Date").value.length <= 0) {
        jAlert('Certificate date cannot be blank', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_Certificate_Date").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtEx_Certificate_Date").value)) {

    }
    else {
        jAlert('Certificate Date is Invalid Date', 'NON CURRENCY MASTER', function (r) { document.getElementById("txtEx_Certificate_Date").focus(); });

        return false;
    }




}
//-----------------------------------END NON STD CURRENCY MASTER PAGE VALIDATION----------------------------------------//


//                                        ***************************************                                     //


//-----------------------------------START PRODUCT MASTER PAGE VALIDATION----------------------------------------//

function validate_Product() {

    var Description;
    Description = document.getElementById("txtDescription").value;

    if (Description.length <= 0) {

        jAlert('Product cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab1_Basic').click(); document.getElementById("txtDescription").focus(); });


        return false;
    }

    //                 var MaterialCode;
    //                 MaterialCode = document.getElementById("txtMaterialCode").value;

    //                 if (MaterialCode.length <= 0) {
    //                     jAlert('MaterialCode cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab1_Basic').click(); document.getElementById("txtMaterialCode").focus(); });
    //                                       
    //                     return false;
    //                 }




    if (document.getElementById("txtCTHNO").value.length <= 0) {
        jAlert('CTH NO cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab1_Basic').click(); document.getElementById("txtCTHNO").focus(); });


        return false;
    }
    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtCTHNO").value.length; i++) {
        temp = document.getElementById("txtCTHNO").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            jAlert('Please enter correct CTH NO', 'PRODUCT MASTER', function (r) { document.getElementById('Tab1_Basic').click(); document.getElementById("txtCTHNO").focus(); });

            return false;
        }
    }
    var mno;
    mno = document.getElementById("txtCTHNO").value;

    if (mno.length < 8) {
        jAlert('CTH NO should be 8 digit numbers', 'PRODUCT MASTER', function (r) { document.getElementById('Tab1_Basic').click(); document.getElementById("txtCTHNO").focus(); });

        return false;
    }


    if (document.getElementById("txtRITCNO").value.length <= 0) {
        jAlert('RITC NO cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab1_Basic').click(); document.getElementById("txtRITCNO").focus(); });

        return false;
    }
    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtRITCNO").value.length; i++) {
        temp = document.getElementById("txtRITCNO").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            jAlert('Enter correct RITC NO', 'PRODUCT MASTER', function (r) { document.getElementById('Tab1_Basic').click(); document.getElementById("txtRITCNO").focus(); });
            return false;
        }
    }
    var mno1;
    mno1 = document.getElementById("txtRITCNO").value;

    if (mno1.length < 8) {
        jAlert('RITC NO should be 8 digit numbers', 'PRODUCT MASTER', function (r) { document.getElementById('Tab1_Basic').click(); document.getElementById("txtRITCNO").focus(); });

        return false;
    }



    //                    <!-- 2nd Page-->


    if (document.getElementById("txtCETH_No").value.length <= 0) {
        jAlert('CETH NO cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab2_CETH').click(); document.getElementById("txtCETH_No").focus(); });

        return false;
    }
    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtCETH_No").value.length; i++) {
        temp = document.getElementById("txtCETH_No").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            jAlert('Enter correct CETH NO', 'PRODUCT MASTER', function (r) { document.getElementById('Tab2_CETH').click(); document.getElementById("txtCETH_No").focus(); });

            return false;
        }
    }
    var CETH_No;
    CETH_No = document.getElementById("txtCETH_No").value;

    if (CETH_No.length < 8) {
        jAlert('CETH No should be 8 digit numbers', 'PRODUCT MASTER', function (r) { document.getElementById('Tab2_CETH').click(); document.getElementById("txtCETH_No").focus(); });

        return false;
    }


    if (document.getElementById("chkMRP_Duty").checked == true) {
        if (document.getElementById("txtMRP_SL_NO").value.length <= 0) {
            jAlert('List cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab2_CETH').click(); document.getElementById("txtMRP_SL_NO").focus(); });

            return false;
        }
        if (document.getElementById("txtMRP_AMOUNT").value.length <= 0) {
            jAlert('MRP cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab2_CETH').click(); document.getElementById("txtMRP_AMOUNT").focus(); });

            return false;
        }
        if (document.getElementById("txtMRP_ABT_RATE").value.length <= 0) {
            jAlert('RATE cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab2_CETH').click(); document.getElementById("txtMRP_ABT_RATE").focus(); });

            return false;
        }

    }
    else {
        $('#form1').validationEngine('detach');
    }
    //                 var Des;
    //                 Des = document.getElementById("txt_CVD_Education_CESS_Rate").value;

    //                 if (Des.length <= 0) {
    //                     jAlert('Education cess cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab2_CETH').click(); document.getElementById("txt_CVD_Education_CESS_Rate").focus(); });

    //                     return false;
    //                 }



    //                 var Des2;
    //                 Des2 = document.getElementById("txt_CVD_Sec_Edu_CESS_Rate").value;

    //                 if (Des2.length <= 0) {
    //                     jAlert('Sec education cess cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab2_CETH').click(); document.getElementById("txt_CVD_Sec_Edu_CESS_Rate").focus(); });

    //                     return false;
    //                 }

    //******************************************************** DISABLE MANDATORY FIELDS FOR JM EXIM PUNJAB ******************************

    //                 var genDes;
    //                 genDes = document.getElementById("txtGenericDesc").value;

    //                 if (genDes.length <= 0) {
    //                     jAlert('General description cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab3_Genearal').click(); document.getElementById("txtGenericDesc").focus(); });

    //                     return false;
    //                 }



    //                 var Manu = document.getElementById("txtManufacturer").value;

    //                 if (Manu.length <= 0) {
    //                     jAlert('Manufacturer name cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab3_Genearal').click(); document.getElementById("txtManufacturer").focus(); });

    //                     return false;
    //                 }


    //                 var brand;
    //                 brand = document.getElementById("txtBrand").value;

    //                 if (brand.length <= 0) {
    //                     jAlert('Brand name cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab3_Genearal').click(); document.getElementById("txtBrand").focus(); });

    //                     return false;
    //                 }



    //                 var model;
    //                 model = document.getElementById("txtModel").value;

    //                 if (model.length <= 0) {
    //                     jAlert('Model name cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab3_Genearal').click(); document.getElementById("txtModel").focus(); });

    //                     return false;
    //                 }



    //                 var EndUse;
    //                 EndUse = document.getElementById("txtEndUse").value;

    //                 if (EndUse.length <= 0) {
    //                     jAlert('End use cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab3_Genearal').click(); document.getElementById("txtEndUse").focus(); });

    //                     return false;
    //                 }

    //                 var country;
    //                 country = document.getElementById("txtCountryName").value;

    //                 if (country.length <= 0) {
    //                     jAlert('Country Name cannot be blank', 'PRODUCT MASTER', function (r) { document.getElementById('Tab3_Genearal').click(); document.getElementById("txtCountryName").focus(); });

    //                     return false;
    //                 }


}

//-----------------------------------END PRODUCT MASTER PAGE VALIDATION----------------------------------------//

//                                        ***************************************                                     //


//-----------------------------------START PRODUCT MASTER TAB VISIBLE/HIDE VALIDATION----------------------------------------//
function ProductMaster_close_button() {
    //For main tap open and sub tab close
    if (document.getElementById("hdn_tab_count").value == '0') {
        parent.productMasterwindow.hide();
    }
    else {
        document.getElementById("hdn_tab_count").value = '0';
        activatables('page', ['page1']);

        tab1('');
        //document.getElementById(val).click();
    }

}

function tab1(val) {


    document.getElementById('page1').style.display = 'Block';
    document.getElementById('page2').style.display = 'none';
    document.getElementById('page3').style.display = 'none';
    document.getElementById('page4').style.display = 'none';

    document.getElementById("Tab2_CETH").className = 'inactive';
    document.getElementById("Tab3_Genearal").className = 'inactive';

}
function tab_CETH(val) {

    Parent_tab_count('');

    document.getElementById('page1').style.display = 'none';
    document.getElementById('page2').style.display = 'Block';
    document.getElementById('page3').style.display = 'none';
    document.getElementById('page4').style.display = 'none';

}
function tab_General(val) {

    Parent_tab_count('');

    document.getElementById('page1').style.display = 'none';
    document.getElementById('page2').style.display = 'none';
    document.getElementById('page3').style.display = 'Block';
    document.getElementById('page4').style.display = 'none';

}
function tab_IGST(val) {

    Parent_tab_count('');

    document.getElementById('page1').style.display = 'none';
    document.getElementById('page2').style.display = 'none';
    document.getElementById('page3').style.display = 'none';
    document.getElementById('page4').style.display = 'Block';

}


//-----------------------------------END PRODUCT MASTER TAB VISIBLE/HIDE VALIDATION----------------------------------------//

//                                        ***************************************                                     //


//-----------------------------------START SUPPLIER MASTER VALIDATION----------------------------------------//


function validate_Supplier() {
    if (document.getElementById("txtName").value.length <= 0) {
        jAlert('Name cannot be blank', 'SUPPLIER MASTER', function (r) { document.getElementById("txtName").focus(); });

        return false;
    }

    if (document.getElementById("txtAdd1").value.length <= 0) {
        jAlert('Address1 cannot be blank', 'SUPPLIER MASTER', function (r) { document.getElementById("txtAdd1").focus(); });

        return false;
    }

    if (document.getElementById("txtCountryName").value.length <= 0) {
        jAlert('Country name cannot be blank', 'SUPPLIER MASTER', function (r) { document.getElementById("txtCountryName").focus(); });

        return false;
    }

    if (document.getElementById("txtCountryCode").value.length <= 0) {
        jAlert('Country code cannot be blank', 'SUPPLIER MASTER', function (r) { document.getElementById("txtCountryCode").focus(); });

        return false;
    }



    if (document.getElementById("txtPincode").value != "") {

        if (document.getElementById("txtPincode").value.length < 6) {
            jAlert('Pin Code should be 6 digit numbers', 'SUPPLIER MASTER', function (r) { document.getElementById("txtPincode").focus(); });

            return false;
        }
    }



    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtPincode").value.length; i++) {
        temp = document.getElementById("txtPincode").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {
            jAlert('Not a valid number', 'SUPPLIER MASTER', function (r) { document.getElementById("txtPincode").focus(); });

            return false;
        }
    }


}

//-----------------------------------END SUPPLIER MASTER VALIDATION----------------------------------------//

//                                        ***************************************                                     //

//-----------------------------------START LICENSE MASTER PAGE VALIDATION----------------------------------------//

function validate_License() {
    if (document.getElementById("txtLicense_No").value.length <= 0) {

        jAlert('License No. cannot be blank', 'LICENSE MASTER', function (r) { document.getElementById("txtLicense_No").focus(); });

        return false;
    }

    if (document.getElementById("txtLicense_date").value.length <= 0) {

        jAlert('License date cannot be blank', 'LICENSE MASTER', function (r) { document.getElementById("txtLicense_date").focus(); });

        return false;
    }
    //        if (document.getElementById("txtReg_No").value.length <= 0) {

    //            jAlert('Reg.No. cannot be blank', 'LICENSE MASTER', function (r) { document.getElementById("txtReg_No").focus(); });

    //            return false;
    //        } 
    //        if (document.getElementById("txtReg_date").value.length <= 0) {

    //            jAlert('Reg.date cannot be blank', 'LICENSE MASTER', function (r) { document.getElementById("txtReg_date").focus(); });

    //            return false;
    //        } 
    if (document.getElementById("ddlLicense_type").value.length <= 0) {

        jAlert('Type cannot be blank', 'LICENSE MASTER', function (r) { document.getElementById("ddlLicense_type").focus(); });

        return false;
    }
    if (document.getElementById("txtItem_Slno").value.length <= 0) {

        jAlert('Item Slno cannot be blank', 'LICENSE MASTER', function (r) { document.getElementById("txtItem_Slno").focus(); });

        return false;
    }
    //if (document.getElementById("txtDescription").value.length <= 0) {

    //     jAlert('Description cannot be blank', 'LICENSE MASTER', function (r) { document.getElementById("txtDescription").focus(); });

    //    return false;
    // } 
    //        if (document.getElementById("txtQty").value.length <= 0) {

    //            jAlert('Qty cannot be blank', 'LICENSE MASTER', function (r) { document.getElementById("txtQty").focus(); });

    //            return false;
    //        }

    if (document.getElementById("txtUnit").value.length <= 0) {
        if (document.getElementById("ddlLicense_type").value != "EPCG") {
            jAlert('Unit cannot be blank', 'LICENSE MASTER', function (r) { document.getElementById("txtUnit").focus(); });
            return false;
        }
    }

    if (document.getElementById("ddlNM_type").value.length <= 0) {

        jAlert('N/M type cannot be blank', 'LICENSE MASTER', function (r) { document.getElementById("ddlNM_type").focus(); });
        return false;
    }



}
//-----------------------------------END LICENSE MASTER PAGE VALIDATION----------------------------------------//

//                                        ***************************************                                     //

//-----------------------------------START BANK MASTER PAGE VALIDATION----------------------------------------//

function validate_BANK() {
    if (document.getElementById("txtBankName").value.length <= 0) {

        jAlert('Bank Name cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txtBankName").focus(); });

        return false;
    }

    if (document.getElementById("txtxBranchName").value.length <= 0) {

        jAlert('Branch Name cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txtxBranchName").focus(); });

        return false;
    }

    if (document.getElementById("txt_AcNo").value.length <= 0) {

        jAlert('Account No cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txt_AcNo").focus(); });

        return false;
    }
    if (document.getElementById("txtISCFCode").value.length <= 0) {

        jAlert('IFSC Code cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txtISCFCode").focus(); });

        return false;
    }

    if (document.getElementById("txtAdd1").value.length <= 0) {

        jAlert('Address 1 cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txtAdd1").focus(); });

        return false;
    }
    if (document.getElementById("txtAdd2").value.length <= 0) {

        jAlert('Address 1 cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txtAdd2").focus(); });

        return false;
    }
    if (document.getElementById("txtCity").value.length <= 0) {

        jAlert('City cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txtCity").focus(); });

        return false;
    }
    if (document.getElementById("txtStateName").value.length <= 0) {

        jAlert('State cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txtStateName").focus(); });

        return false;
    }
    if (document.getElementById("txtContactPerson").value.length <= 0) {

        jAlert('State cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txtContactPerson").focus(); });

        return false;
    }
    if (document.getElementById("txtContact_No").value.length <= 0) {

        jAlert('State cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txtContact_No").focus(); });

        return false;
    }
    var digits = "0123456789";
    var temp;
    for (var i = 0; i < document.getElementById("txtContact_No").value.length; i++) {
        temp = document.getElementById("txtContact_No").value.substring(i, i + 1);
        if (digits.indexOf(temp) == -1) {

            document.getElementById("txtAdd3").focus();
            return false;
        }
    }
    if (document.getElementById("txtEmailID").value.length <= 0) {

        jAlert('Email ID cannot be blank', 'BANK MASTER', function (r) { document.getElementById("txtEmailID").focus(); });

        return false;
    }

    var emailPat = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    var emailid = document.getElementById("txtEmailID").value;
    var matchArray = emailid.match(emailPat);
    if (document.getElementById("txtEmailID").value != "") {
        if (matchArray == null) {

            jAlert('Email id not valid', 'BANK MASTER', function (r) { document.getElementById("txtEmailID").focus(); });
            return false;
        }
    }




}
//-----------------------------------END BANK MASTER PAGE VALIDATION----------------------------------------//



// Load State name --start


function CallServerside_State_Name_Validation_clientMaster(src) {
    var ctrl = document.getElementById(src);

    PageMethods.Set_State_Name_Validation(ctrl.value, CallSuccess_State_Name_Validation, CallFailed);
}

function CallSuccess_State_Name_Validation(res) {

    if (res == "Yes") {
        document.getElementById('txtStateName').style.border = "1px solid #c8c8c8";
        document.getElementById('hdn_StateName_chk').value = res;
    }
    else {
        document.getElementById('txtStateName').style.border = "1px solid Red";
        document.getElementById('hdn_StateName_chk').value = res;

    }
}


function CallServerside_Commercial_State_Name_Validation_clientMaster(src) {
    var ctrl = document.getElementById(src);

    PageMethods.Set_State_Name_Validation(ctrl.value, CallSuccess_Commercial_State_Name_Validation, CallFailed);
}

function CallSuccess_Commercial_State_Name_Validation(res) {

    if (res == "Yes") {
        document.getElementById('txtCommercial_StateName').style.border = "1px solid #c8c8c8";
        document.getElementById('hdn_Commercial_StateName_chk').value = res; ;
    }
    else {
        document.getElementById('txtCommercial_StateName').style.border = "1px solid Red";
        document.getElementById('hdn_Commercial_StateName_chk').value = res;
    }
}
// Load State name --end
function validateBankPayableDetail() {
    var BankName = document.getElementById('ddlbankName').value;
    if (BankName == "") {
        jAlert('Select Bank Name', 'PAYABLE DETAILS', function (r) {
            document.getElementById("ddlbankName").focus();
        });
        return false;
    }


    var AcNo = document.getElementById('txtAcNo').value;

    if (AcNo.length <= 0) {
        jAlert('Enter A/C No', 'PAYABLE DETAILS', function (r) {
            document.getElementById('txtAcNo').focus();
        });
        return false;
    }

    var txtIFSC_code = document.getElementById('txtIFSC_code').value;
    
    if (txtIFSC_code.length <= 0) {
        jAlert('Enter IFSC Code', 'PAYABLE DETAILS', function (r) {
            document.getElementById('txtIFSC_code').focus();
        });
        return false;
    }

    var StateName = document.getElementById('ddl_state').value;
 
    if (StateName.length <= 0) {
        jAlert('Select State Name', 'PAYABLE DETAILS', function (r) {
            document.getElementById('ddl_state').focus();
        });
        return false;
    }
    return true;

}

function BankReceivable_Validation() {
    var ddl_RecevbankName = document.getElementById('ddl_RecevbankName').value;
    if (ddl_RecevbankName == "") {
        jAlert('Select Bank Name', 'RECEIVABLE DETAILS', function (r) {
            document.getElementById('ddl_RecevbankName').focus();
        });
        return false;
    }

    var txt_RecevAcNo = document.getElementById('txt_RecevAcNo').value;
    if (txt_RecevAcNo.length <= 0) {
        jAlert('Enter A/C No', 'RECEIVABLE DETAILS', function (r) {
            document.getElementById('txt_RecevAcNo').focus();
        });
        return false;
    }
    var txt_RecevIFSC_code = document.getElementById('txt_RecevIFSC_code').value;
    if (txt_RecevIFSC_code.length <= 0) {
        jAlert('Enter IFSC Code', 'RECEIVABLE DETAILS', function (r) {
            document.getElementById('txt_RecevIFSC_code').focus();
        });
        return false;
    }

    var ddl_ReceiveState = document.getElementById('ddl_Recev_state').value;
    if (ddl_ReceiveState == '') {
        jAlert('Select The State', 'RECEIVABLE DETAILS', function (r) {
            document.getElementById('ddl_Recev_state').focus();
        });
        return false;
    }


    return true;
}