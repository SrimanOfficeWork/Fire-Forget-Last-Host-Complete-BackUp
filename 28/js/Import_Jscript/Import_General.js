

//-----------------------------------START IMPORT GENERAL PAGE VALIDATION--------------------------------------//

//function validate() {

//    var CompanyID = document.getElementById("hdn_CompanyID").value;
////    alert(CompanyID);

//    var txtJobDate = document.getElementById("txtJobDate").value;
//    if (txtJobDate != "") {
//        if (isDate(txtJobDate)) {
//        }
//        else {
//            jAlert('Job Date is Invalid Date', 'GENERAL', function (r) { document.getElementById("txtJobDate").focus(); });
//            return false;
//        }
//    }
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

//    var Customhouse_chk;
//    Customhouse_chk = document.getElementById("hdn_Customhouse_chk").value;

//    if (Customhouse_chk != "Yes") {
//        jAlert('Invalid Customs House Code', 'GENERAL', function (r) { document.getElementById("txtCustomsHouse").focus(); });
//        return false;
//    }
//  

//    var IMPORTER_NAME;
//    IMPORTER_NAME = document.getElementById("txtImporterName").value;

//    if (IMPORTER_NAME.length <= 0) {

//        jAlert('Importer Name Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtImporterName").focus(); });
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
//    var AD_CODE;
//    AD_CODE = document.getElementById("txt_ADCode").value;
//    ddlBEType = document.getElementById("ddlBEType").value;
//   
//    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '293' && CompanyID != '4') {
//        if (AD_CODE.length <= 0) {

//            jAlert('AD Code cannot be blank', 'GENERAL', function (r) { document.getElementById("txt_ADCode").focus(); });
//            return false;
//        }
//        
//        if (ddlBEType == 'SEZ FTA-Z' || ddlBEType == 'SEZ DTA-T' || ddlBEType == 'SEZ DTA-M' || ddlBEType == "Jobbing" || ddlBEType == "Repair & Return" || ddlBEType == "Exhibition" || ddlBEType == "Destruction" || ddlBEType == "Movement of Goods" || ddlBEType == "Stock Item") {
//            if ((AD_CODE == 'NFEI') || (AD_CODE.length > 6)) {
//                //true
//            }
//            else {
//                jAlert('Invalid AD Code for SEZ', 'GENERAL', function (r) { document.getElementById("txt_ADCode").focus(); });
//                return false;
//            }
//        }
//        else {
//            if (AD_CODE.length < 7) {
//                jAlert('AD Code - should be 7 digit', 'GENERAL', function (r) { document.getElementById("txt_ADCode").focus(); });
//                return false;
//            }
//        }
//    }

//    var warehouse_code
//    warehouse_code = document.getElementById("txtWarehouseCode").value;
//    ddlBEType = document.getElementById("ddlBEType").value;

//    if (ddlBEType == 'SEZ FTA-Z' || ddlBEType == 'SEZ DTA-M' || ddlBEType == 'Warehouse') {
//        if (warehouse_code.length <= 0) {

//            jAlert('Warehouse Code cannot be blank', 'GENERAL', function (r) { document.getElementById("txtWarehouseCode").focus(); });
//            return false;
//        }
//    }

//    var BRANCH_NO;
//    BRANCH_NO = document.getElementById("txtBranchNo").value;

//    if (BRANCH_NO.length <= 0) {
//        jAlert('Branch Slno Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtBranchNo").focus(); });
//        return false;
//    }

//    var ADDRESS1;
//    ADDRESS1 = document.getElementById("txtAddress1").value;

//    if (ADDRESS1.length <= 0) {
//        jAlert('Address Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtAddress1").focus(); });
//        return false;
//    }
//    var COUNTRY_ORIGIN;
//    COUNTRY_ORIGIN = document.getElementById("txtCountryName").value;

//    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' && CompanyID != '5' && CompanyID != '747') {
//        if (COUNTRY_ORIGIN.length <= 0) {

//            jAlert('Country Origin cannot be blank', 'GENERAL', function (r) { document.getElementById("txtCountryName").focus(); });
//            return false;
//        }
//    }

//    var COUNTRY_SHIPMENT;
//    COUNTRY_SHIPMENT = document.getElementById("txtCountryShipment").value;

//    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' && CompanyID != '5' && CompanyID != '747') {
//        if (COUNTRY_SHIPMENT.length <= 0) {

//            jAlert('Country_Shipment cannot be blank', 'GENERAL', function (r) { document.getElementById("txtCountryShipment").focus(); });
//            return false;
//        }
//    }


//    var COUNTRY_ORIGIN_chk;
//    COUNTRY_ORIGIN_chk = document.getElementById("Hdcountryoforgin_chk").value;
//    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' && CompanyID != '5' && CompanyID != '747') {
//        if (COUNTRY_ORIGIN_chk != "Yes") {
//                  //  alert('a');
//            jAlert('Invalid Country of Orgin', 'GENERAL', function (r) { document.getElementById("txtCountryName").focus(); });
//            return false;
//        }
//    }

//    var COUNTRY_SHIPMENT_chk;
//    COUNTRY_SHIPMENT_chk = document.getElementById("Hdcountryofshipment_chk").value;
//    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' && CompanyID != '5' && CompanyID != '747') {
//        if (COUNTRY_SHIPMENT_chk != "Yes") {
//            //        alert('b');
//            jAlert('Invalid Country of Shipment', 'GENERAL', function (r) { document.getElementById("txtCountryShipment").focus(); });
//            return false;
//        }
//    }


//    var PORT_ORIGIN;
//    PORT_ORIGIN = document.getElementById("txtPortOrigin").value;

//    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' && CompanyID != '5' && CompanyID != '747') {
//        if (PORT_ORIGIN.length <= 0) {
//            jAlert('Port Origin cannot be blank', 'GENERAL', function (r) { document.getElementById("txtPortOrigin").focus(); });
//            return false;
//        }
//    }


//    var PORT_ORIGIN_chk;
//    PORT_ORIGIN_chk = document.getElementById("Hdportoforgin_Chk").value;
//    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' && CompanyID != '5' && CompanyID != '10' && CompanyID != '480' && CompanyID != '747') {
//        if (PORT_ORIGIN_chk != "Yes") {
//             
//            jAlert('Invalid port of Orgin', 'GENERAL', function (r) { document.getElementById("txtPortOrigin").focus(); });
//            return false;
//        }
//    }


//    var PORT_SHIPMENT_chk;
//    PORT_SHIPMENT_chk = document.getElementById("Hdportofshipment_chk").value;
//    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' && CompanyID != '5' && CompanyID != '10' && CompanyID != '480' && CompanyID != '747') {
//        if (PORT_SHIPMENT_chk != "Yes") {
//             
//            jAlert('Invalid port of Shipment', 'GENERAL', function (r) { document.getElementById("txtPortShipment").focus(); });
//            return false;
//        }
//    }

//    var PORT_SHIPMENT;
//    PORT_SHIPMENT = document.getElementById("txtPortShipment").value;
//    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' && CompanyID != '5' && CompanyID != '747') {
//        if (PORT_SHIPMENT.length <= 0) {
//            jAlert('Port_Shipment cannot be blank', 'GENERAL', function (r) { document.getElementById("txtPortShipment").focus(); });
//            return false;
//        }
//    }

//    
//    //-----------------SANCO - Country Code & Port code Validation---- Sea & Land --------------------------
//    if (document.getElementById('hdfTransport_mode').value != 'Air') {
//        var COUNTRY_PORT_ORIGIN_chk;
//        COUNTRY_PORT_ORIGIN_chk = document.getElementById("hdn_CountryCD_PortOrigin_chk").value;
//        if (CompanyID == '10' || CompanyID == '480' || CompanyID == '747') {
//            if (COUNTRY_PORT_ORIGIN_chk != "Yes") {
//                jAlert('Invalid port of Origin', 'GENERAL', function (r) { document.getElementById("txtPortOrigin").focus(); });
//                return false;
//            }
//        }
//        var COUNTRY_PORT_SHIPMENT_chk;
//        COUNTRY_PORT_SHIPMENT_chk = document.getElementById("hdn_CountryCD_PortofShipment_chk").value;
//        if (CompanyID == '10' || CompanyID == '480' || CompanyID == '747') {
//            if (COUNTRY_PORT_SHIPMENT_chk != "Yes") {
//                jAlert('Invalid port of Shipment', 'GENERAL', function (r) { document.getElementById("txtPortShipment").focus(); });
//                return false;
//            }
//        }
//    }
//    //-------------------------------------------------------------------------------------------------------



//     var ddlCommercial_Tax_yn;
//    ddlCommercial_Tax_yn = document.getElementById("ddlCommercial_Tax_yn").value;

//    if (ddlCommercial_Tax_yn == 'Y') {
//        var COMMERCIAL_TAX_STATECODE;
//        COMMERCIAL_TAX_STATECODE = document.getElementById("txtCommercial_StateCode").value;

//        if (COMMERCIAL_TAX_STATECODE.length <= 0) {
//            jAlert('Commercial Tax State Code cannot be blank', 'GENERAL', function (r) { document.getElementById("txtCommercial_StateCode").focus(); });

//            return false;
//        }
//        if (COMMERCIAL_TAX_STATECODE.length < 2) {
//            jAlert('Commercial Tax State Code should be 2 Characters', 'GENERAL', function (r) { document.getElementById("COMtxtCommercial_StateCodeMERCIAL_TAX_STATECODE").focus(); });

//            return false;
//        }

//        /* var txtCommercial_Taxtype;
//        txtCommercial_Taxtype = document.getElementById("txtCommercial_Taxtype").value;

//        if (txtCommercial_Taxtype <= 0) {
//        jAlert('Commercial Tax Type cannot be blank', 'GENERAL', function (r) { document.getElementById("txtCommercial_Taxtype").focus(); });

//        return false;
//        }*/

//        var txtCommercial_RegistrationNo;
//        txtCommercial_RegistrationNo = document.getElementById("txtCommercial_RegistrationNo").value;

//        if (txtCommercial_RegistrationNo <= 0) {
//            jAlert('Registration No cannot be blank', 'GENERAL', function (r) { document.getElementById("txtCommercial_RegistrationNo").focus(); });
//            return false;
//        }


//        var ddl_Commercial_Type;
//        ddl_Commercial_Type = document.getElementById("ddl_Commercial_Type").value;

//        if (ddl_Commercial_Type == 'G' || ddl_Commercial_Type == 'O' || ddl_Commercial_Type == 'D') {
//            if (txtCommercial_RegistrationNo.length != 15) {
//                jAlert('GSTN Registration No - should be 15 digit', 'GENERAL', function (r) { document.getElementById("txtCommercial_RegistrationNo").focus(); });
//                return false;
//            }
//        }

//        if (ddl_Commercial_Type == 'I') {
//            if (txtCommercial_RegistrationNo.length != 10) {
//                jAlert('PAN Registration No - should be 10 digit', 'GENERAL', function (r) { document.getElementById("txtCommercial_RegistrationNo").focus(); });
//                return false;
//            }
//        }


//        var StateName_chk;
//        StateName_chk = document.getElementById("hdn_StateName_chk").value;
//            if (StateName_chk != "Yes") {
//               
//                jAlert('Invalid State Name', 'GENERAL', function (r) { document.getElementById("txtCommercial_StateName").focus(); });
//                return false;
//            }
//       
//    }
//    

//    


//    if (document.getElementById("chkFirstCheck").checked == true) {
//        
//        FirstCheckDesc = document.getElementById("txtFirstCheckDesc").value;

//        if (FirstCheckDesc.length <= 0) {

//            jAlert('First Check Description cannot be blank', 'GENERAL', function (r) { document.getElementById("txtFirstCheckDesc").focus(); });

//            return false;
//        }
//    }


//    if (document.getElementById("chkSection48").checked == true) {

//        Section48Desc = document.getElementById("txtSection48Desc").value;

//        if (Section48Desc.length <= 0) {

//            jAlert('Section 48 Description cannot be blank', 'GENERAL', function (r) { document.getElementById("txtSection48Desc").focus(); });

//            return false;
//        }
//    }


//    var Payment_method;
//    Payment_method = document.getElementById("txt_Payment_Method").value;
// 
//    if (Payment_method == '') {
//        jAlert('Payment Method cannot be blank', 'GENERAL', function (r) { document.getElementById("txt_Payment_Method").focus(); });
//        return false;
//    }
//    if (Payment_method != 'T' && Payment_method != 'D') {
//        jAlert('Invalid Payment Method', 'GENERAL', function (r) { document.getElementById("txt_Payment_Method").focus(); });
//        return false;
//    }

//    if (document.getElementById("chkHighSeaSale").checked == true) {
//        var SellerName;
//        SellerName = document.getElementById("txtSellerName").value;

//        if (SellerName.length <= 0) {

//            jAlert('SellerName Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtSellerName").focus(); });

//            return false;
//        }
//        var HighSeaSaleIECNo;
//        HighSeaSaleIECNo = document.getElementById("txtHighSeaSaleIECNo").value;

//        if (HighSeaSaleIECNo.length <= 0) {
//            jAlert('HighSeaSaleIECNo Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtHighSeaSaleIECNo").focus(); });

//            return false;
//        }
//        var highsea;
//        highsea = document.getElementById("txtHighSeaSaleIECNo").value;
//        if (highsea.length < 10) {
//            jAlert('Seller IEC no must be 10 digit', 'GENERAL', function (r) { document.getElementById("txtHighSeaSaleIECNo").focus(); });

//            return false;
//        }
//        var BranchSLNo;
//        BranchSLNo = document.getElementById("txtBranchSLNo").value;
//        if (BranchSLNo < 0) {
//            jAlert('Seller branch no cannot be blank', 'GENERAL', function (r) { document.getElementById("txtBranchSLNo").focus(); });

//            return false;
//        }
//        var HighSeaSaleAddress;
//        HighSeaSaleAddress = document.getElementById("txtHighSeaSaleAddress").value;

//        if (HighSeaSaleAddress <= 0) {
//            jAlert('Seller address1 cannot be blank', 'GENERAL', function (r) { document.getElementById("txtHighSeaSaleAddress").focus(); });

//            return false;
//        }

//        var PrecedingLevel;
//        PrecedingLevel = document.getElementById("txt_PrecedingLevel").value;

//        if (PrecedingLevel != 0 && PrecedingLevel != 1) {
//            jAlert('Invalid Preceding Level', 'GENERAL', function (r) { document.getElementById("txt_PrecedingLevel").focus(); });

//            return false;
//        }
//        if (PrecedingLevel == '') {
//            jAlert('Preceding Level cannot be blank', 'GENERAL', function (r) { document.getElementById("txt_PrecedingLevel").focus(); });

//            return false;
//        }

//    }

//    if (document.getElementById("chkHighSeaSale").checked == false) {

//        $('#form1').validationEngine('detach');
//    }

//}


//modified By Benjamin 18042026


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



function validate() {

    var CompanyID = document.getElementById("hdn_CompanyID").value;

    // ── Job Date — format check only, NOT flag driven ─────────────
    var txtJobDate = document.getElementById("txtJobDate").value;
    if (txtJobDate != "") {
        if (isDate(txtJobDate)) {
        }
        else {
            jAlert('Job Date is Invalid Date', 'GENERAL',
                function (r) { document.getElementById("txtJobDate").focus(); });
            return false;
        }
    }

    // ── Customs House — NOT flag driven ───────────────────────────
    var CUSTOMS_HOUSE = document.getElementById("txtCustomsHouse").value;
    if (CUSTOMS_HOUSE.length <= 0) {
        jAlert('Custom House Field cannot be blank', 'GENERAL',
            function (r) { document.getElementById("txtCustomsHouse").focus(); });
        return false;
    }
    else if (CUSTOMS_HOUSE.length < 6) {
        jAlert('Custom House Should be 6 digit', 'GENERAL',
            function (r) { document.getElementById("txtCustomsHouse").focus(); });
        return false;
    }

    var Customhouse_chk = document.getElementById("hdn_Customhouse_chk").value;
    if (Customhouse_chk != "Yes") {
        jAlert('Invalid Customs House Code', 'GENERAL',
            function (r) { document.getElementById("txtCustomsHouse").focus(); });
        return false;
    }

    // ── Importer Name — driven by master setting ──────────────────
    if (mand_ImporterName == "Y") {
        var IMPORTER_NAME = document.getElementById("txtImporterName").value;
        if (IMPORTER_NAME.trim().length <= 0) {
            showMandatoryTooltip("txtImporterName", function () {
                jAlert('Importer Name Field cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtImporterName").focus(); });
            });
            return false;
        }
    }

    // ── IEC No — driven by master setting ─────────────────────────
    if (mand_IECNo == "Y") {
        var IEC_NO = document.getElementById("txtIECNo").value;
        if (IEC_NO.trim().length <= 0) {
            showMandatoryTooltip("txtIECNo", function () {
                jAlert('IEC No Field cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtIECNo").focus(); });
            });
            return false;
        }
        if (IEC_NO.length < 10) {
            showMandatoryTooltip("txtIECNo", function () {
                jAlert('IEC No Should be 10 digit', 'GENERAL',
                    function (r) { document.getElementById("txtIECNo").focus(); });
            });
            return false;
        }
    }

    // ── AD Code — driven by master setting ────────────────────────
    var ddlBEType = document.getElementById("ddlBEType").value;

    if (CompanyID != '499' && CompanyID != '526' &&
        CompanyID != '293' && CompanyID != '4') {

        if (mand_ADCode == "Y") {
            var AD_CODE = document.getElementById("txt_ADCode").value;
            if (AD_CODE.trim().length <= 0) {
                showMandatoryTooltip("txt_ADCode", function () {
                    jAlert('AD Code cannot be blank', 'GENERAL',
                        function (r) { document.getElementById("txt_ADCode").focus(); });
                });
                return false;
            }

            if (ddlBEType == 'SEZ FTA-Z' || ddlBEType == 'SEZ DTA-T' ||
                ddlBEType == 'SEZ DTA-M' || ddlBEType == "Jobbing" ||
                ddlBEType == "Repair & Return" || ddlBEType == "Exhibition" ||
                ddlBEType == "Destruction" || ddlBEType == "Movement of Goods" ||
                ddlBEType == "Stock Item") {
                if (!((AD_CODE == 'NFEI') || (AD_CODE.length > 6))) {
                    // ✅ Validity check — no tooltip, jAlert only
                    jAlert('Invalid AD Code for SEZ', 'GENERAL',
                        function (r) { document.getElementById("txt_ADCode").focus(); });
                    return false;
                }
            }
            else {
                if (AD_CODE.length < 7) {
                    showMandatoryTooltip("txt_ADCode", function () {
                        jAlert('AD Code should be 7 digit', 'GENERAL',
                            function (r) { document.getElementById("txt_ADCode").focus(); });
                    });
                    return false;
                }
            }
        }
    }

    // ── Warehouse Code — NOT flag driven ──────────────────────────
    var warehouse_code = document.getElementById("txtWarehouseCode").value;
    if (ddlBEType == 'SEZ FTA-Z' || ddlBEType == 'SEZ DTA-M' ||
        ddlBEType == 'Warehouse') {
        if (warehouse_code.length <= 0) {
            jAlert('Warehouse Code cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txtWarehouseCode").focus(); });
            return false;
        }
    }

    // ── Branch No — driven by master setting ──────────────────────
    if (mand_BranchNo == "Y") {
        var BRANCH_NO = document.getElementById("txtBranchNo").value;
        if (BRANCH_NO.trim().length <= 0) {
            showMandatoryTooltip("txtBranchNo", function () {
                jAlert('Branch Slno Field cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtBranchNo").focus(); });
            });
            return false;
        }
    }

    // ── Address — driven by master setting ────────────────────────
    if (mand_Address == "Y") {
        var ADDRESS1 = document.getElementById("txtAddress1").value;
        if (ADDRESS1.trim().length <= 0) {
            showMandatoryTooltip("txtAddress1", function () {
                jAlert('Address Field cannot be blank', 'GENERAL',
                    function (r) { document.getElementById("txtAddress1").focus(); });
            });
            return false;
        }
    }

    // ── Country Origin — driven by master setting ─────────────────
    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' &&
        CompanyID != '5' && CompanyID != '747') {
        if (mand_CountryOrigin == "Y") {
            var COUNTRY_ORIGIN = document.getElementById("txtCountryName").value;
            if (COUNTRY_ORIGIN.trim().length <= 0) {
                showMandatoryTooltip("txtCountryName", function () {
                    jAlert('Country Origin cannot be blank', 'GENERAL',
                        function (r) { document.getElementById("txtCountryName").focus(); });
                });
                return false;
            }
        }
    }

    // ── Country Shipment — driven by master setting ───────────────
    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' &&
        CompanyID != '5' && CompanyID != '747') {
        if (mand_CountryShip == "Y") {
            var COUNTRY_SHIPMENT = document.getElementById("txtCountryShipment").value;
            if (COUNTRY_SHIPMENT.trim().length <= 0) {
                showMandatoryTooltip("txtCountryShipment", function () {
                    jAlert('Country Shipment cannot be blank', 'GENERAL',
                        function (r) { document.getElementById("txtCountryShipment").focus(); });
                });
                return false;
            }
        }
    }

    // ── Country Origin validity check — NOT flag driven ───────────
    var COUNTRY_ORIGIN_chk = document.getElementById("Hdcountryoforgin_chk").value;
    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' &&
        CompanyID != '5' && CompanyID != '747') {
        if (mand_CountryOrigin == "Y" && COUNTRY_ORIGIN_chk != "Yes") {
            jAlert('Invalid Country of Origin', 'GENERAL',
                function (r) { document.getElementById("txtCountryName").focus(); });
            return false;
        }
    }

    // ── Country Shipment validity check — NOT flag driven ─────────
    var COUNTRY_SHIPMENT_chk = document.getElementById("Hdcountryofshipment_chk").value;
    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' &&
        CompanyID != '5' && CompanyID != '747') {
        if (mand_CountryShip == "Y" && COUNTRY_SHIPMENT_chk != "Yes") {
            jAlert('Invalid Country of Shipment', 'GENERAL',
                function (r) { document.getElementById("txtCountryShipment").focus(); });
            return false;
        }
    }

    // ── Port Origin — driven by master setting ────────────────────
    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' &&
        CompanyID != '5' && CompanyID != '747') {
        if (mand_PortOrigin == "Y") {
            var PORT_ORIGIN = document.getElementById("txtPortOrigin").value;
            if (PORT_ORIGIN.trim().length <= 0) {
                showMandatoryTooltip("txtPortOrigin", function () {
                    jAlert('Port Origin cannot be blank', 'GENERAL',
                        function (r) { document.getElementById("txtPortOrigin").focus(); });
                });
                return false;
            }
        }
    }

    // ── Port Origin validity check — NOT flag driven ──────────────
    var PORT_ORIGIN_chk = document.getElementById("Hdportoforgin_Chk").value;
    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' &&
        CompanyID != '5' && CompanyID != '10' && CompanyID != '480' &&
        CompanyID != '747') {
        if (mand_PortOrigin == "Y" && PORT_ORIGIN_chk != "Yes") {
            jAlert('Invalid Port of Origin', 'GENERAL',
                function (r) { document.getElementById("txtPortOrigin").focus(); });
            return false;
        }
    }

    // ── Port Shipment — driven by master setting ──────────────────
    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' &&
        CompanyID != '5' && CompanyID != '747') {
        if (mand_PortShipment == "Y") {
            var PORT_SHIPMENT = document.getElementById("txtPortShipment").value;
            if (PORT_SHIPMENT.trim().length <= 0) {
                showMandatoryTooltip("txtPortShipment", function () {
                    jAlert('Port Shipment cannot be blank', 'GENERAL',
                        function (r) { document.getElementById("txtPortShipment").focus(); });
                });
                return false;
            }
        }
    }

    // ── Port Shipment validity check — NOT flag driven ────────────
    var PORT_SHIPMENT_chk = document.getElementById("Hdportofshipment_chk").value;
    if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4' &&
        CompanyID != '5' && CompanyID != '10' && CompanyID != '480' &&
        CompanyID != '747') {
        if (mand_PortShipment == "Y" && PORT_SHIPMENT_chk != "Yes") {
            jAlert('Invalid Port of Shipment', 'GENERAL',
                function (r) { document.getElementById("txtPortShipment").focus(); });
            return false;
        }
    }

    // ── SANCO Port validation — NOT flag driven ───────────────────
    if (document.getElementById('hdfTransport_mode').value != 'Air') {
        var COUNTRY_PORT_ORIGIN_chk =
            document.getElementById("hdn_CountryCD_PortOrigin_chk").value;
        if (CompanyID == '10' || CompanyID == '480' || CompanyID == '747') {
            if (COUNTRY_PORT_ORIGIN_chk != "Yes") {
                jAlert('Invalid port of Origin', 'GENERAL',
                    function (r) { document.getElementById("txtPortOrigin").focus(); });
                return false;
            }
        }
        var COUNTRY_PORT_SHIPMENT_chk =
            document.getElementById("hdn_CountryCD_PortofShipment_chk").value;
        if (CompanyID == '10' || CompanyID == '480' || CompanyID == '747') {
            if (COUNTRY_PORT_SHIPMENT_chk != "Yes") {
                jAlert('Invalid port of Shipment', 'GENERAL',
                    function (r) { document.getElementById("txtPortShipment").focus(); });
                return false;
            }
        }
    }

    // ── Commercial Tax ────────────────────────────────────────────
    var ddlCommercial_Tax_yn = document.getElementById("ddlCommercial_Tax_yn").value;
    if (ddlCommercial_Tax_yn == 'Y') {

        // ── State Code — driven by master setting ─────────────────
        if (mand_StateCode == "Y") {
            var COMMERCIAL_TAX_STATECODE =
                document.getElementById("txtCommercial_StateCode").value;
            if (COMMERCIAL_TAX_STATECODE.trim().length <= 0) {
                showMandatoryTooltip("txtCommercial_StateCode", function () {
                    jAlert('Commercial Tax State Code cannot be blank', 'GENERAL',
                        function (r) {
                            document.getElementById("txtCommercial_StateCode").focus();
                        });
                });
                return false;
            }
            if (COMMERCIAL_TAX_STATECODE.length < 2) {
                showMandatoryTooltip("txtCommercial_StateCode", function () {
                    jAlert('Commercial Tax State Code should be 2 Characters', 'GENERAL',
                        function (r) {
                            document.getElementById("txtCommercial_StateCode").focus();
                        });
                });
                return false;
            }
        }

        // ── Registration No — driven by master setting ────────────
        if (mand_RegNo == "Y") {
            var txtCommercial_RegistrationNo =
                document.getElementById("txtCommercial_RegistrationNo").value;
            if (txtCommercial_RegistrationNo.trim() == "") {
                showMandatoryTooltip("txtCommercial_RegistrationNo", function () {
                    jAlert('Registration No cannot be blank', 'GENERAL',
                        function (r) {
                            document.getElementById("txtCommercial_RegistrationNo").focus();
                        });
                });
                return false;
            }

            var ddl_Commercial_Type =
                document.getElementById("ddl_Commercial_Type").value;
            if (ddl_Commercial_Type == 'G' || ddl_Commercial_Type == 'O' ||
                ddl_Commercial_Type == 'D') {
                if (txtCommercial_RegistrationNo.length != 15) {
                    // ✅ Length check — no tooltip, jAlert only
                    jAlert('GSTN Registration No should be 15 digit', 'GENERAL',
                        function (r) {
                            document.getElementById("txtCommercial_RegistrationNo").focus();
                        });
                    return false;
                }
            }
            if (ddl_Commercial_Type == 'I') {
                if (txtCommercial_RegistrationNo.length != 10) {
                    // ✅ Length check — no tooltip, jAlert only
                    jAlert('PAN Registration No should be 10 digit', 'GENERAL',
                        function (r) {
                            document.getElementById("txtCommercial_RegistrationNo").focus();
                        });
                    return false;
                }
            }
        }

        // ── State Name — driven by master setting ─────────────────
        if (mand_StateName == "Y") {
            var StateName_chk = document.getElementById("hdn_StateName_chk").value;
            if (StateName_chk != "Yes") {
                showMandatoryTooltip("txtCommercial_StateName", function () {
                    jAlert('Invalid State Name', 'GENERAL',
                        function (r) {
                            document.getElementById("txtCommercial_StateName").focus();
                        });
                });
                return false;
            }
        }
    }

    // ── First Check — NOT flag driven ─────────────────────────────
    if (document.getElementById("chkFirstCheck").checked == true) {
        var FirstCheckDesc = document.getElementById("txtFirstCheckDesc").value;
        if (FirstCheckDesc.length <= 0) {
            jAlert('First Check Description cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txtFirstCheckDesc").focus(); });
            return false;
        }
    }

    // ── Section 48 — NOT flag driven ──────────────────────────────
    if (document.getElementById("chkSection48").checked == true) {
        var Section48Desc = document.getElementById("txtSection48Desc").value;
        if (Section48Desc.length <= 0) {
            jAlert('Section 48 Description cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txtSection48Desc").focus(); });
            return false;
        }
    }

    // ── Payment Method — NOT flag driven ──────────────────────────
    var Payment_method = document.getElementById("txt_Payment_Method").value;
    if (Payment_method == '') {
        jAlert('Payment Method cannot be blank', 'GENERAL',
            function (r) { document.getElementById("txt_Payment_Method").focus(); });
        return false;
    }
    if (Payment_method != 'T' && Payment_method != 'D') {
        jAlert('Invalid Payment Method', 'GENERAL',
            function (r) { document.getElementById("txt_Payment_Method").focus(); });
        return false;
    }

    // ── High Sea Sale — NOT flag driven ───────────────────────────
    if (document.getElementById("chkHighSeaSale").checked == true) {
        var SellerName = document.getElementById("txtSellerName").value;
        if (SellerName.length <= 0) {
            jAlert('Seller Name Field cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txtSellerName").focus(); });
            return false;
        }
        var HighSeaSaleIECNo = document.getElementById("txtHighSeaSaleIECNo").value;
        if (HighSeaSaleIECNo.length <= 0) {
            jAlert('High Sea Sale IEC No Field cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txtHighSeaSaleIECNo").focus(); });
            return false;
        }
        if (HighSeaSaleIECNo.length < 10) {
            jAlert('Seller IEC No must be 10 digit', 'GENERAL',
                function (r) { document.getElementById("txtHighSeaSaleIECNo").focus(); });
            return false;
        }
        var BranchSLNo = document.getElementById("txtBranchSLNo").value;
        if (BranchSLNo < 0) {
            jAlert('Seller Branch No cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txtBranchSLNo").focus(); });
            return false;
        }
        var HighSeaSaleAddress = document.getElementById("txtHighSeaSaleAddress").value;
        if (HighSeaSaleAddress <= 0) {
            jAlert('Seller Address cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txtHighSeaSaleAddress").focus(); });
            return false;
        }
        var PrecedingLevel = document.getElementById("txt_PrecedingLevel").value;
        if (PrecedingLevel == '') {
            jAlert('Preceding Level cannot be blank', 'GENERAL',
                function (r) { document.getElementById("txt_PrecedingLevel").focus(); });
            return false;
        }
        if (PrecedingLevel != 0 && PrecedingLevel != 1) {
            jAlert('Invalid Preceding Level', 'GENERAL',
                function (r) { document.getElementById("txt_PrecedingLevel").focus(); });
            return false;
        }
    }

    if (document.getElementById("chkHighSeaSale").checked == false) {
        $('#form1').validationEngine('detach');
    }

    // ── All checks passed ─────────────────────────────────────────
    return true;
}























//-----------------------------------END IMPORT GENERAL PAGE VALIDATION--------------------------------------//

//function close_button() {
//    //document.getElementById("btnCancel").click();
//    document.getElementById("General").click();
//}

window.onload = happycode;
function happycode() {
    document.getElementById("General").click();
}

$('#btnNew').click(function () {
    $('#form1').validationEngine('detach');
});
$('#btnDelete').click(function () {
    $('#form1').validationEngine('detach');
});
function updateTextbox() {
    var txt1 = document.getElementById('txtCountryName');
    var txt2 = document.getElementById('txtCountryShipment');

    if (txt2.value == '') {
        txt2.value = txt1.value;
    }
}

function updateTextbox2() {

    document.getElementById('txtPortShipment').value = document.getElementById('txtPortOrigin').value;

}
function updateTextbox3() {

    document.getElementById('txtPortOrigin').value = document.getElementById('txtPortShipment').value;

}
function Change_Commercial_Taxtype() {

    var txtCommercial_Taxtype = document.getElementById('txtCommercial_Taxtype').value;
    if (txtCommercial_Taxtype == 'V') {
        document.getElementById('div_Commercial_TaxTypecode').innerHTML = 'VAT';

    }
    else if (txtCommercial_Taxtype == 'C') {
        document.getElementById('div_Commercial_TaxTypecode').innerHTML = 'CST';

    }
    else if (txtCommercial_Taxtype == 'S') {
        document.getElementById('div_Commercial_TaxTypecode').innerHTML = 'ST';

    }
    else if (txtCommercial_Taxtype == 'E') {
        document.getElementById('div_Commercial_TaxTypecode').innerHTML = 'EXCISE';

    }

}
function Import_session(val, val1, val2, val3) {
    $.ajax({
        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Import_session",
        data: "{ 'mail': '" + val + "','mail1': '" + val1 + "','mail2': '" + val2 + "','mail3': '" + val3 + "'}",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8"

    });
}
function tab_page1() {
    
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    document.getElementById('page-3').style.display = 'none';
    document.getElementById('page-4').style.display = 'none';
    document.getElementById('page-11').style.display = 'none';
    document.getElementById('page-13').style.display = 'none';

    if (document.getElementById('hdsaveandclose').value == 'Yes') {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'Block';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';

        document.getElementById('page-11').style.display = 'none';
        document.getElementById("Trans_igm_Iframe").src = "../Transaction/IGM_Details.aspx";
        document.getElementById("hdsaveandclose").value = 'No';

        document.getElementById('page-13').style.display = 'none';
		document.getElementById('page-14').style.display = 'none';
    }
    

}
function tab_page2() {


   
    if (document.getElementById('hdn_Jobno').value != '') {
       
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'Block';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-13').style.display = 'none';
        document.getElementById('page-14').style.display = 'none';
        document.getElementById("Trans_igm_Iframe").src = "../Transaction/IGM_Details.aspx";
        
    }
    else {
        happycode();
    }
}
function tab_page3() {

    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'Block';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-13').style.display = 'none';

        document.getElementById("Trans_igm_Invoice_Iframe").src = "../Transaction/Invoice_Details_HP_Invoice.aspx";
		document.getElementById('page-14').style.display = 'none';
        //document.getElementById("Trans_igm_Invoice_Iframe").src = "../Transaction/Invoice_Details_HP_Invoice_Online.aspx";

//      document.getElementById("Trans_igm_Invoice_Iframe").src = "../Transaction/Invoice_Details.aspx";
    }
    else {

        happycode();

    }
}
function tab_page4() {

    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'Block';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-13').style.display = 'none';
		document.getElementById('page-14').style.display = 'none';
        document.getElementById("Trans_igm_item_Iframe").src = "../Transaction/Item_Details.aspx";
      
    }
    else {

        happycode();

    }
}

function tab_page5_New() {

    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'Block';
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-13').style.display = 'none';

                document.getElementById("Trans_igm_CHKLIST_Iframe").src = "../Transaction/Import_CheckList_JOB.aspx";
//        document.getElementById("Trans_igm_CHKLIST_Iframe").src = "../Transaction/Item_Details.aspx";
		document.getElementById('page-14').style.display = 'none';
    }
    else {

        happycode();

    }
}
/*
function tab_page5(url, val) {

    if (document.getElementById('hdn_Jobno').value != '') {


        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'Block';
        document.getElementById('page-5').style.display = 'Block';
        document.getElementById("Trans_igm_item_Iframe").src = url + val;
    }
    else {

        happycode();

    }
}
*/

function tab_page5(url, val) {

    if (document.getElementById('hdn_Jobno').value != '') {

        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'Block';
        document.getElementById('page-5').style.display = 'Block';
        //alert('&jonops='+ document.getElementById('txtjobPS').value );
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-13').style.display = 'none';
        document.getElementById("Trans_igm_item_Iframe").src = url + val + '&jobnops=' + document.getElementById('txtjobps').value;
		 document.getElementById('page-14').style.display = 'none';
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
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-13').style.display = 'none';
        document.getElementById("Trans_igm_item_Iframe").src = url + val + url1 + val1 + type;
		 document.getElementById('page-14').style.display = 'none';
    }
    else {

        happycode();

    }
}


function tab_page9() {



    if (document.getElementById('hdn_Jobno').value != '') {

        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'Block';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-13').style.display = 'none';
        document.getElementById("Trans_igm_Iframe").src = "../Transaction/Billing_Others_Details.aspx";
		 document.getElementById('page-14').style.display = 'none';
    }
    else {
        happycode();
    }
}

function tab_page10() {

    if (document.getElementById('hdn_Jobno').value != '') {

        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'Block';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-13').style.display = 'none';
        document.getElementById("Trans_igm_Iframe").src = "../Job_History/Imp_Job_Logs.aspx";
		document.getElementById('page-14').style.display = 'none';
    }
    else {
        happycode();
    }
}

function ch_tab_Imp_page11() {

    if (document.getElementById('hdn_Jobno').value != '') {

        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-11').style.display = 'Block';
        document.getElementById('page-13').style.display = 'none';
		document.getElementById('page-14').style.display = 'none';


        document.getElementById("Iframe1_Imp").src = "../Accounts_CHA_Import/Acc_Bill_To_Party.aspx";

    }
    else {
        happycode();
    }
}


function ch_tab_Imp_page_sun() {

    if (document.getElementById('hdn_Jobno').value != '') {

        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-11').style.display = 'Block';
        document.getElementById('page-13').style.display = 'none';
        document.getElementById('page-14').style.display = 'none';


        document.getElementById("Iframe1_Imp").src = "../Accounts_CHA_Import_old/Acc_Bill_To_Party.aspx";

    }
    else {
        happycode();
    }
}


function tab_page12() {

    if (document.getElementById('hdn_Jobno').value != '') {

        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-12').style.display = 'Block';
		document.getElementById('page-14').style.display = 'none';


        document.getElementById("Imp_SDF_OtherScrn").src = "../Transaction/SDF_Others_Details.aspx";

    }
    else {
        happycode();
    }
}
function ch_tab_Fin_page13() {

    if (document.getElementById('hdn_Jobno').value != '') {

        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-13').style.display = 'Block';
		document.getElementById('page-14').style.display = 'none';
        document.getElementById("Iframe1_Fin").src = "../Accounts_CHA_Import/Acc_Financials.aspx";

    }
    else {
        happycode();
    }
}

function tab_page14() {
    if (document.getElementById('hdn_Jobno').value != '') {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-11').style.display = 'none';
        document.getElementById('page-12').style.display = 'none';
        document.getElementById('page-13').style.display = 'none';
        document.getElementById('page-14').style.display = 'Block';

        document.getElementById("Iframe1_NewTab").src = "../Accounts_CHA_Import/Acc_Imp_Entity.aspx";
    } else {
        happycode();
    }
}

//           function close_modelpopup() {
//               $find("mp1").hide();
//           }

//************************* DON'T DELETE - ITS FOR EXBOND DETAILS UPDATE ********************** 

//function Exbond_Details(val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11) {

//    document.getElementById("hdn_Exbond_BENo").value = val1;
//    document.getElementById("hdn_Exbond_BEDate").value = val2;
//    document.getElementById("hdn_Exbond_BondNo").value = val3;
//    document.getElementById("hdn_Exbond_BondDate").value = val4;
//    document.getElementById("hdn_Exbond_Warehouse_Customs").value = val5;
//    document.getElementById("hdn_Exbond_Warehouse_Code").value = val6;
//    document.getElementById("hdn_Exbond_NoofPackages").value = val7;
//    document.getElementById("hdn_Exbond_NoofPackages_Code").value = val8;
//    document.getElementById("hdn_Exbond_Gross_Weight").value = val9;
//    document.getElementById("hdn_Exbond_Gross_Weight_Code").value = val10;
//    document.getElementById("hdn_Direct_Exbonding").value = val11;
//}

//***********************************************************************************************



function OpenPopupCustom_House() {


    if (document.getElementById('hdfTransport_mode').value != '') {

        var s = document.getElementById('hdfTransport_mode').value;

        OpenPopupCustom_House_Details(s);

        return false
    }
}
function OpenPopupCustom_House3() {


    if (document.getElementById('hdfTransport_mode').value != '') {
        var s = document.getElementById('hdfTransport_mode').value;

        OpenPopupCustom_House_Details_Port(s, '23');

        return false
    }
}
function OpenPopupPort_Master(val) {

    if (document.getElementById('hdfTransport_mode').value != '') {

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
function OpenPopupImporter_Master(val) {
   
    if (document.getElementById('hdfTransport_mode').value != '') {

        if (val == 'seller') {

            if (document.getElementById('chkHighSeaSale').checked == true) {

                OpenPopupImporterDetails(val);
                return false
            }
        }
        else if (val == 'IMPORTER_DETAILS') {
            OpenPopupImporterDetails(val);
            return false
        }
        else if (val == 'IMPORTER_DETAILS_Billing_Others') {
            OpenPopupImporterDetails(val);
            return false
        }

        else if (val == '') {
            OpenPopupImporterDetails(val);
            return false
        }
    }
}

function OpenPopupImporter_Master_BranchSlno(val1) {

    if (document.getElementById('hdfTransport_mode').value != '') {

        var val = document.getElementById('txtIECNo').value;
        val = val.replace(/\s+$/g, '');
        if (val != '' && val.length == 10) {

            OpenPopupImporterDetails_New(val1, val);
        }

    }
}
function OpenPopupImporter_Master_HighSea_BranchSlno(val1) {

    if (document.getElementById('hdfTransport_mode').value != '') {

        var val = document.getElementById('txtHighSeaSaleIECNo').value;

        val = val.replace(/\s+$/g, '');
        if (val != '') {

            OpenPopupImporterDetails_New(val1, val);
        }

    }
}
function OpenPopupCountry_Master(val) {

    if (document.getElementById('hdfTransport_mode').value != '') {

        OpenPopupCountryOrigin(val);
        return false
    }
}
function tab(val) {

    document.getElementById('page-1').style.display = 'none';
    document.getElementById('mainiframecontainer').style.display = 'Block';
    //document.getElementById('innerbox_MidMain_Transact_popup').style.display = 'none';


}
function tab1(val) {

    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('mainiframecontainer').style.display = 'none';
    //document.getElementById('innerbox_MidMain_Transact_popup').style.display = 'Block';

}


$(function () {

    $('#chkSection46').click(function (e) {

        var txtSection46Desc = $('#txtSection46Desc');
        var chksec46 = $('#chksec46');


        if (this.checked) {
            txtSection46Desc.attr('disabled', false);
            chksec46.val('Y');



            //chksec46.text = 'Y';


        }
        else {

            txtSection46Desc.attr('disabled', true);
            chksec46.val('N');
            txtSection46Desc.val("");
        }
    });


});

$(function () {

    $('#chkFirstCheck').click(function (e) {

        var txtFirstCheckDesc = $('#txtFirstCheckDesc');
        var chkFirCheck = $('#chkFirCheck');


        if (this.checked) {
            txtFirstCheckDesc.attr('disabled', false);
            chkFirCheck.val('Y');

        }
        else {
            txtFirstCheckDesc.attr('disabled', true);
            chkFirCheck.val('N');
            txtFirstCheckDesc.val("");
        }
    });




});

$(function () {

    $('#chkGreenChannel').click(function (e) {

        var txtGreenChannelDesc = $('#txtGreenChannelDesc');
        var chkGrnChannel = $('#chkGrnChannel');


        if (this.checked) {
            txtGreenChannelDesc.attr('disabled', false);
            chkGrnChannel.val('Y');

        }
        else {
            txtGreenChannelDesc.attr('disabled', true);
            chkGrnChannel.val('N');
            txtGreenChannelDesc.val("");

        }
    });




});

$(function () {

    $('#chkKachha').click(function (e) {

        var txtKachhaDesc = $('#txtKachhaDesc');
        var chkKach = $('#chkKach');


        if (this.checked) {
            txtKachhaDesc.attr('disabled', false);
            chkKach.val('Y');

        }
        else {
            txtKachhaDesc.attr('disabled', true);
            chkKach.val('N');
            txtKachhaDesc.val("");

        }
    });




});


$(function () {

    $('#chkSection48').click(function (e) {

        var txtSection48Desc = $('#txtSection48Desc');
        var chkSec48 = $('#chkSec48');


        if (this.checked) {
            txtSection48Desc.attr('disabled', false);
            chkSec48.val('Y');
            txtSection48Desc.val("LATE SUBMISSION");
        }
        else {
            txtSection48Desc.attr('disabled', true);
            chkSec48.val('N');
            txtSection48Desc.val("");

        }
    });
});

$(function () {

    $('#chkProvisional').click(function (e) {

        var txtProvisionalDesc = $('#txtProvisionalDesc');
        var chkProv = $('#chkProv');


        if (this.checked) {
            txtProvisionalDesc.attr('disabled', false);
            chkProv.val('Y');
            txtProvisionalDesc.val("PROVISIONAL ASSESSMENT - IMPORTER REQUEST");
        }
        else {
            txtProvisionalDesc.attr('disabled', true);
            chkProv.val('N');
            txtProvisionalDesc.val("");

        }
    });
});



$(function () {
    $('#ddlBEType').change(function (e) {

        if (this.value == 'Warehouse' || this.value == 'SEZ FTA-Z' || this.value == 'SEZ DTA-T' || this.value == 'SEZ DTA-M' || this.value == 'Jobbing' || this.value == 'Repair & Return' || this.value == 'Exhibition' || this.value == 'Destruction' || this.value == 'Movement of Goods') {
            document.getElementById("txtWarehouseCode").disabled = false;
        }
        else if (document.getElementById('hdn_CompanyID').value == '1') {
            if (this.value == 'SEZ FTA-Z' || this.value == 'SEZ DTA-T' || this.value == 'SEZ DTA-M' || this.value == 'Jobbing' || this.value == 'Repair & Return' || this.value == 'Exhibition' || this.value == 'Destruction' || this.value == 'Movement of Goods') {
                document.getElementById("txtWarehouseCode").disabled = false;
            }
            else {
                document.getElementById("txtWarehouseCode").disabled = true;
                document.getElementById('txtWarehouseCode').value = '';
            }
        }
        else {
            if (document.getElementById('hdn_CompanyID').value != '1019' && document.getElementById('hdn_CompanyID').value != '10') {
                document.getElementById("txtWarehouseCode").disabled = true;
                document.getElementById('txtWarehouseCode').value = '';
            }
        }
    });
});


$(function () {

    $('#chkHighSeaSale').click(function (e) {

        var txtSellerName = $('#txtSellerName');
        var txtHighSeaSaleIECNo = $('#txtHighSeaSaleIECNo');
        var txtBranchSLNo = $('#txtBranchSLNo');
        var txtHighSeaSaleAddress = $('#txtHighSeaSaleAddress');
        var txtHighSeaSaleAddress1 = $('#txtHighSeaSaleAddress1');
        var txtHighSeaSaleAddress2 = $('#txtHighSeaSaleAddress2');
        var txtHighSeaSaleAddress3 = $('#txtHighSeaSaleAddress3');
        var txtHighSeaSaleAddress4 = $('#txtHighSeaSaleAddress4');
        var txt_PrecedingLevel = $('#txt_PrecedingLevel');
        var txtHSS_AdCode = $('#txtHSS_AdCode');


        var chkHghSeaSale = $('#chkHghSeaSale');
        

        if (this.checked) {
            txtSellerName.attr('disabled', false);
            txtHighSeaSaleIECNo.attr('disabled', false);
            txtBranchSLNo.attr('disabled', false);
            txtHighSeaSaleAddress.attr('disabled', false);
            txtHighSeaSaleAddress1.attr('disabled', false);
            txtHighSeaSaleAddress2.attr('disabled', false);
            txtHighSeaSaleAddress3.attr('disabled', false);
            txtHighSeaSaleAddress4.attr('disabled', false);
            txt_PrecedingLevel.attr('disabled', false);
            txtHSS_AdCode.attr('disabled', false);

            // imgbtnseller.attr('disabled', false);
            chkHghSeaSale.val('Y');

        }
        else {
            txtSellerName.val("");
            txtHighSeaSaleIECNo.val("");
            txtBranchSLNo.val("");
            txtHighSeaSaleAddress.val("");
            txtHighSeaSaleAddress1.val("");
            txtHighSeaSaleAddress2.val("");
            txtHighSeaSaleAddress3.val("");
            txtHighSeaSaleAddress4.val("");
            txt_PrecedingLevel.val("");
            txtHSS_AdCode.val("");


            txtSellerName.attr('disabled', true);
            txtHighSeaSaleIECNo.attr('disabled', true);
            txtBranchSLNo.attr('disabled', true);
            txtHighSeaSaleAddress.attr('disabled', true);
            txtHighSeaSaleAddress1.attr('disabled', true);
            txtHighSeaSaleAddress2.attr('disabled', true);
            txtHighSeaSaleAddress3.attr('disabled', true);
            txtHighSeaSaleAddress4.attr('disabled', true);
            txt_PrecedingLevel.attr('disabled', true);
            txtHSS_AdCode.attr('disabled', true);

            //imgbtnseller.attr('disabled', true);
            chkHghSeaSale.val('N');

        }
    });

});

function clear() {

    var txtCustomsHouse = $('#txtCustomsHouse');

    var txtImporterName = $('#txtImporterName');
    var txtAddress1 = $('#txtAddress1');
    var txtAddress2 = $('#txtAddress2');
    var txtAddress3 = $('#txtAddress3');
    var txtBranchNo = $('#txtBranchNo');
    var txtIECNo = $('#txtIECNo');
    var txtAddress4 = $('#txtAddress4');
    var txtAddress5 = $('#txtAddress5');
    var txtCountryName = $('#txtCountryName');
    var txtPortOrigin = $('#txtPortOrigin');
    var txtPortShipment = $('#txtPortShipment');
    var txtCountryShipment = $('#txtCountryShipment');
    var txtWarehouseName = $('#txtWarehouseName');
    var txtWarehouseCode = $('#txtWarehouseCode');
    var ddlFilingStatus = $('#ddlFilingStatus');
    var txtRemarks = $('#txtRemarks');

    var txtSection46Desc = $('#txtSection46Desc');
    var txtFirstCheckDesc = $('#txtFirstCheckDesc');
    var txtGreenChannelDesc = $('#txtGreenChannelDesc');
    var txtKachhaDesc = $('#txtKachhaDesc');
    var txtSection48Desc = $('#txtSection48Desc');
    var txtSellerName = $('#txtSellerName');
    var txtHighSeaSaleIECNo = $('#txtHighSeaSaleIECNo');
    var txtBranchSLNo = $('#txtBranchSLNo');
    var txtHighSeaSaleAddress = $('#txtHighSeaSaleAddress');
    var txtHighSeaSaleAddress2 = $('#txtHighSeaSaleAddress2');
    var txtHighSeaSaleAddress4 = $('#txtHighSeaSaleAddress4');
    var txtHighSeaSaleAddress1 = $('#txtHighSeaSaleAddress1');
    var txtHighSeaSaleAddress3 = $('#txtHighSeaSaleAddress3');
    var txtHSS_AdCode = $('#txtHSS_AdCode');


    txtImporterName.val("");
    txtCustomsHouse.val("");
    txtAddress1.val("");
    txtAddress2.val("");
    txtAddress3.val("");
    txtAddress4.val("");
    txtAddress5.val("");
    txtBranchNo.val("");
    txtIECNo.val("");
    txtCountryName.val("");
    txtPortOrigin.val("");
    txtPortShipment.val("");
    txtCountryShipment.val("");
    txtWarehouseName.val("");
    txtWarehouseCode.val("");
    txtRemarks.val("");

    txtSection46Desc.val("");
    txtFirstCheckDesc.val("");
    txtGreenChannelDesc.val("");
    txtKachhaDesc.val("");
    txtSection48Desc.val("");
    txtSellerName.val("");
    txtHighSeaSaleIECNo.val("");
    txtBranchSLNo.val("");
    txtHighSeaSaleAddress.val("");
    txtHighSeaSaleAddress1.val("");
    txtHighSeaSaleAddress2.val("");
    txtHighSeaSaleAddress3.val("");
    txtHighSeaSaleAddress4.val("");
    txtHSS_AdCode.val("");


}

function disabled_true() {

    var txtCustomsHouse = $('#txtCustomsHouse');

    var txtImporterName = $('#txtImporterName');
    var txtAddress1 = $('#txtAddress1');
    var txtAddress2 = $('#txtAddress2');
    var txtAddress3 = $('#txtAddress3');
    var txtBranchNo = $('#txtBranchNo');
    var txtIECNo = $('#txtIECNo');
    var txtAddress4 = $('#txtAddress4');
    var txtAddress5 = $('#txtAddress5');
    var txtCountryName = $('#txtCountryName');
    var txtPortOrigin = $('#txtPortOrigin');
    var txtPortShipment = $('#txtPortShipment');
    var txtCountryShipment = $('#txtCountryShipment');
    var txtWarehouseName = $('#txtWarehouseName');
    var txtWarehouseCode = $('#txtWarehouseCode');
    var ddlFilingStatus = $('#ddlFilingStatus');
    var txtRemarks = $('#txtRemarks');

    var txtSection46Desc = $('#txtSection46Desc');
    var txtFirstCheckDesc = $('#txtFirstCheckDesc');
    var txtGreenChannelDesc = $('#txtGreenChannelDesc');
    var txtKachhaDesc = $('#txtKachhaDesc');
    var txtSection48Desc = $('#txtSection48Desc');
    var txtSellerName = $('#txtSellerName');
    var txtHighSeaSaleIECNo = $('#txtHighSeaSaleIECNo');
    var txtBranchSLNo = $('#txtBranchSLNo');
    var txtHighSeaSaleAddress = $('#txtHighSeaSaleAddress');
    var txtHighSeaSaleAddress2 = $('#txtHighSeaSaleAddress2');
    var txtHighSeaSaleAddress4 = $('#txtHighSeaSaleAddress4');
    var txtHighSeaSaleAddress1 = $('#txtHighSeaSaleAddress1');
    var txtHighSeaSaleAddress3 = $('#txtHighSeaSaleAddress3');
    var txtHSS_AdCode = $('#txtHSS_AdCode');


    var chkSection46 = $('#chkSection46');

    var chkFirstCheck = $('#chkFirstCheck');

    var chkGreenChannel = $('#chkGreenChannel');

    var chkKachha = $('#chkKachha');

    var chkSection48 = $('#chkSection48');

    var chkHighSeaSale = $('#chkHighSeaSale');




    clear();
    txtImporterName.attr('disabled', true);
    txtCustomsHouse.attr('disabled', true);
    txtAddress1.attr('disabled', true);
    txtAddress2.attr('disabled', true);
    txtAddress3.attr('disabled', true);
    txtAddress4.attr('disabled', true);
    txtAddress5.attr('disabled', true);
    txtBranchNo.attr('disabled', true);
    txtIECNo.attr('disabled', true);
    txtCountryName.attr('disabled', true);
    txtPortOrigin.attr('disabled', true);
    txtPortShipment.attr('disabled', true);
    txtCountryShipment.attr('disabled', true);
    txtWarehouseName.attr('disabled', true);
    txtWarehouseCode.attr('disabled', true);
    txtRemarks.attr('disabled', true);

    //Imgbtn_Importer.attr('disabled', true);
    ddlFilingStatus.attr('disabled', true);
    // Imgbtn_Importer.attr('disabled', true);
    //imgbtn_Port_Origin.attr('disabled', true);
    //imgbtn_Port_Shipment.attr('disabled', true);
    //Imgbtn_CountryShipment.attr('disabled', true);
    chkSection46.attr('disabled', true);
    chkFirstCheck.attr('disabled', true);
    chkGreenChannel.attr('disabled', true);
    chkKachha.attr('disabled', true);
    chkSection48.attr('disabled', true);
    chkHighSeaSale.attr('disabled', true);
    //imgCustomHouse.attr('disabled', true);
    // imgbtnseller.attr('disabled', true);

    txtSection46Desc.attr('disabled', true);
    txtFirstCheckDesc.attr('disabled', true);
    txtGreenChannelDesc.attr('disabled', true);
    txtSection48Desc.attr('disabled', true);
    txtSellerName.attr('disabled', true);
    txtHighSeaSaleIECNo.attr('disabled', true);
    txtBranchSLNo.attr('disabled', true);
    txtHighSeaSaleAddress.attr('disabled', true);
    txtHighSeaSaleAddress1.attr('disabled', true);
    txtHighSeaSaleAddress2.attr('disabled', true);
    txtHighSeaSaleAddress3.attr('disabled', true);
    txtHighSeaSaleAddress4.attr('disabled', true);
    txtHSS_AdCode.attr('disabled', true);

}

$(function () {

    var dropDownList1 = $('#ddlBEType');

    dropDownList1.change(function (e) {
        var selectedValue = $(this).val();

        if (selectedValue != '') {

            if (selectedValue == 'Home') {
                document.getElementById('tag').style.display = 'none';
                document.getElementById('lnkbtn_Exbond').style.display = 'none';
                ExBond_textBoxClear();
            }
            else if (selectedValue == 'Warehouse') {
                document.getElementById('tag').style.display = 'none';
                document.getElementById('lnkbtn_Exbond').style.display = 'none';
                ExBond_textBoxClear();

            }
            else if (selectedValue == 'Ex-Bond') {
                document.getElementById('tag').style.display = 'none';
                document.getElementById('lnkbtn_Exbond').style.display = 'none';

            }
        }


    });
});

//********************************* DON'T DELETE - ITS FOR EXBOND DETAILS UPDATE********************

//function ExBond_textBoxClear() {
//    document.getElementById("hdn_Exbond_BENo").value = '';
//    document.getElementById("hdn_Exbond_BEDate").value = '';
//    document.getElementById("hdn_Exbond_BondNo").value = '';
//    document.getElementById("hdn_Exbond_BondDate").value = '';
//    document.getElementById("hdn_Exbond_Warehouse_Customs").value = '';
//    document.getElementById("hdn_Exbond_Warehouse_Code").value = '';
//    document.getElementById("hdn_Exbond_NoofPackages").value = '';
//    document.getElementById("hdn_Exbond_NoofPackages_Code").value = '';
//    document.getElementById("hdn_Exbond_Gross_Weight").value = '';
//    document.getElementById("hdn_Exbond_Gross_Weight_Code").value = '';
//    document.getElementById("hdn_Direct_Exbonding").value = '';
//}

//***********************************************************************************************

/*$(function () {

    var ddlCommercial_Tax_yn = $('#ddlCommercial_Tax_yn');

    ddlCommercial_Tax_yn.change(function (e) {
        var selectedValue = $(this).val();
       
        if (selectedValue != '') {

            if (selectedValue == 'Y') {
                document.getElementById('div_CommercialTax').style.display = 'block';


            }
            else if (selectedValue == 'N') {
                document.getElementById('div_CommercialTax').style.display = 'none';
                document.getElementById('txtCommercial_StateCode').value = '';
                document.getElementById('txtCommercial_Taxtype').value = '';
                document.getElementById('txtCommercial_RegistrationNo').value = '';
            }

        }
        jQuery('#form1').validationEngine('hideAll');


    });



});
*/


$(function () {

    var dropDownList1 = $('#ddlTransportMode');

    dropDownList1.change(function (e) {

        var e = document.getElementById("ddlTransportMode");
        var selectedValue = e.options[e.selectedIndex].text;


        var txtCustomsHouse = $('#txtCustomsHouse');

        var txtImporterName = $('#txtImporterName');
        var txtAddress1 = $('#txtAddress1');
        var txtAddress2 = $('#txtAddress2');
        var txtAddress3 = $('#txtAddress3');
        var txtBranchNo = $('#txtBranchNo');
        var txtIECNo = $('#txtIECNo');
        var txtAddress4 = $('#txtAddress4');
        var txtAddress5 = $('#txtAddress5');
        var txtCountryName = $('#txtCountryName');
        var txtPortOrigin = $('#txtPortOrigin');
        var txtPortShipment = $('#txtPortShipment');
        var txtCountryShipment = $('#txtCountryShipment');
        var txtWarehouseName = $('#txtWarehouseName');
        var txtWarehouseCode = $('#txtWarehouseCode');
        var ddlFilingStatus = $('#ddlFilingStatus');
        var txtRemarks = $('#txtRemarks');

        var txtSection46Desc = $('#txtSection46Desc');
        var txtFirstCheckDesc = $('#txtFirstCheckDesc');
        var txtGreenChannelDesc = $('#txtGreenChannelDesc');
        var txtKachhaDesc = $('#txtKachhaDesc');
        var txtSection48Desc = $('#txtSection48Desc');
        var txtSellerName = $('#txtSellerName');
        var txtHighSeaSaleIECNo = $('#txtHighSeaSaleIECNo');
        var txtBranchSLNo = $('#txtBranchSLNo');
        var txtHighSeaSaleAddress = $('#txtHighSeaSaleAddress');
        var txtHighSeaSaleAddress2 = $('#txtHighSeaSaleAddress2');
        var txtHighSeaSaleAddress4 = $('#txtHighSeaSaleAddress4');
        var txtHighSeaSaleAddress1 = $('#txtHighSeaSaleAddress1');
        var txtHighSeaSaleAddress3 = $('#txtHighSeaSaleAddress3');
        var txtHSS_AdCode = $('#txtHSS_AdCode');


        var chkSection46 = $('#chkSection46');

        var chkFirstCheck = $('#chkFirstCheck');

        var chkGreenChannel = $('#chkGreenChannel');

        var chkKachha = $('#chkKachha');

        var chkSection48 = $('#chkSection48');

        var chkHighSeaSale = $('#chkHighSeaSale');

        if (selectedValue == 'Select') {
            document.getElementById('hdfTransport_mode').value = '';
            selectedValue = '';
        }

        if (selectedValue != '') {
          
            var PortOrigin = document.getElementById('txtPortOrigin').value;
            var PortShipment = document.getElementById('txtPortShipment').value
            var values = PortOrigin.split("-");
            var values1 = PortShipment.split("-");            
            if (values[1].length == 5 && values1[1].length == 5 && selectedValue == 'Sea' || values[1].length == 5 && values1[1].length == 5 && selectedValue == 'Land') {
                
            }
            else {
              
                document.getElementById('txtPortOrigin').value = '';
                document.getElementById('txtPortShipment').value = '';
            }
            document.getElementById('hdfTransport_mode').value = selectedValue;

            document.getElementById('txtCustomsHouse').value = '';

            $.ajax({

                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/SessionCreate_Transport_Mode_Port",
                data: "{ 'mail': '" + selectedValue + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8"

            });




            txtImporterName.attr('disabled', false);
            txtCustomsHouse.attr('disabled', false);
            txtAddress1.attr('disabled', false);
            txtAddress2.attr('disabled', false);
            txtAddress3.attr('disabled', false);
            txtAddress4.attr('disabled', false);
            txtAddress5.attr('disabled', false);
            txtBranchNo.attr('disabled', false);
            txtIECNo.attr('disabled', false);
            txtCountryName.attr('disabled', false);
            txtPortOrigin.attr('disabled', false);
            txtPortShipment.attr('disabled', false);
            txtCountryShipment.attr('disabled', false);

            txtWarehouseName.attr('disabled', false);
            txtWarehouseCode.attr('disabled', false);
            txtRemarks.attr('disabled', false);



            //Imgbtn_Importer.attr('disabled', false);
            ddlFilingStatus.attr('disabled', false);
            //Imgbtn_Importer.attr('disabled', false);
            //imgbtn_Port_Origin.attr('disabled', false);
            // imgbtn_Port_Shipment.attr('disabled', false);
            //Imgbtn_CountryShipment.attr('disabled', false);
            chkSection46.attr('disabled', false);
            chkFirstCheck.attr('disabled', false);
            chkGreenChannel.attr('disabled', false);
            chkKachha.attr('disabled', false);
            chkSection48.attr('disabled', false);
            chkHighSeaSale.attr('disabled', false);
            ///imgCustomHouse.attr('disabled', false);
            // imgbtn_Countryname.attr('disabled', false);
            //imgbtnseller.attr('disabled', false);
            //document.getElementById('btnNew').disabled = false;
            //document.getElementById('btnSave').disabled = false;

            //document.getElementById('btnDelete').disabled = false;
            // document.getElementById('btnUpdate').disabled = false;

            //Opensession(selectedValue);


            var btnNew = $('#btnNew');
            var btnsave = $('#btnSave');
            var btnDelete = $('#btnDelete');
            var btnUpdate = $('#btnUpdate');
            btnNew.attr('disabled', false);
            btnsave.attr('disabled', false);
            btnDelete.attr('disabled', false);
            btnUpdate.attr('disabled', false);

        }
        else {


            disabled_true();
            var btn_New = $('#btnNew');
            var btn_save = $('#btnSave');
            var btn_Delete = $('#btnDelete');
            var btn_Update = $('#btnUpdate');
            btn_New.attr('disabled', true);
            btn_save.attr('disabled', true);
            btn_Delete.attr('disabled', true);
            btn_Update.attr('disabled', true);
            //document.getElementById('btnNew').disabled = true;
            //document.getElementById('btnSave').disabled = true;

            //document.getElementById('btnDelete').disabled = true;
            //document.getElementById('btnUpdate').disabled = true;
            //alert('Transport_Mode Cannot be empty');


            // alert('Transport_Mode Cannot be empty');
            jAlert('Transport_Mode Cannot be empty', 'GENERAL', function (r) { document.getElementById("ddlTransportMode").focus(); });

        }
    });
});

$(function () {
    $('#txtCountryName').focus(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txtCountryName').change(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txtCountryName').keyup(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txtCountryName').keydown(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txtCountryName').click(function () {

        var data = $(this).val();
        country(data);

    });
    $('#txtCountryShipment').focus(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryShipment').change(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryShipment').keyup(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryShipment').keydown(function () {

        var data = $(this).val();
        country_shipment(data);

    });
    $('#txtCountryShipment').click(function () {

        var data = $(this).val();
        country_shipment(data);

    });
});

function country(val) {

    var data = val;
   
    if (data == '') {
        $('#txtCountryShipment').val('');
    }
    //$('#hdn_Autosearch').val(data);

    if (data.indexOf("-") != -1) {

        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txtCountryShipment').val(before);
        $('#txtCountryName').val(before);

    }
    else {
    }
}
function country_shipment(val) {
    var data = val;
    if (data == '') {
        $('#txtCountryShipment').val('');
    }

    if (data.indexOf("-") != -1) {

        var s = data.split('-');
        var before = s[0];
        var after = s[1];

        $('#txtCountryShipment').val(before);
       
    }
    else {

    }
}

function Port_origin(val) {

    var data = val;
    if (data == '') {
        $('#txtPortOrigin').val('');
    }
    else {
        $('#txtPortOrigin').val(val);
        $('#txtPortShipment').val(val);
    }

}

function Port_Shipment(val) {

    var data = val;
    if (data == '') {
        $('#txtPortShipment').val('');
    }
    else {
        $('#txtPortShipment').val(val);
    }
}

$(function () {
    $('#txtPortOrigin').focus(function () {

        var data = $(this).val();
        Port_origin(data);

    });
    $('#txtPortOrigin').change(function () {

        var data = $(this).val();
        Port_origin(data);

    });
    $('#txtPortOrigin').keyup(function () {

        var data = $(this).val();
        Port_origin(data);

    });
    $('#txtPortOrigin').keydown(function () {

        var data = $(this).val();
        Port_origin(data);

    });
    $('#txtPortOrigin').click(function () {

        var data = $(this).val();
        Port_origin(data);

    });
    $('#txtPortShipment').focus(function () {

        var data = $(this).val();
        Port_Shipment(data);

    });
    $('#txtPortShipment').change(function () {

        var data = $(this).val();
        Port_Shipment(data);

    });
    $('#txtPortShipment').keyup(function () {

        var data = $(this).val();
        Port_Shipment(data);

    });
    $('#txtPortShipment').keydown(function () {

        var data = $(this).val();
        Port_Shipment(data);

    });
    $('#txtPortShipment').click(function () {

        var data = $(this).val();
        Port_Shipment(data);

    });
});



$(function () {
    $("#txtCustomsHouse").autocomplete({

        source: function (request, response) {
            //document.getElementById('txtPortOrigin').value = '';
            //document.getElementById('txtPortShipment').value = '';
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List_NEW",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtCustomsHouse').validationEngine('showPrompt', 'Incorrect Customs House', 'error', 'topRight', true);

                        //jAlert('Customs House is Incorrect', 'GENERAL', function (r) { document.getElementById("txtCustomsHouse").focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtCustomsHouse').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


// State Mater//

$(function () {
    $("#txtCommercial_StateName").autocomplete({
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
                        jQuery('#txtCommercial_StateName').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);

                        //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                        //return false;
                    }
                    else {
                        jQuery('#txtCommercial_StateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


// AD code Mater//

$(function () {
    $("#txt_ADCode").autocomplete({
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
                        jQuery('#txt_ADCode').validationEngine('showPrompt', 'Incorrect ADCode', 'error', 'topRight', true);

                    }
                    else {
                        jQuery('#txt_ADCode').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

$(function () {

    $('#txtCommercial_StateName').bind('focus keyup keypress change keydown', function () {

        var data = $(this).val();
        commercial_state(data);

    });
});

function commercial_state(val) {

    var data = val;
    if (data == '') {
        $('#txtCommercial_StateCode').val('');
    }
    //$('#hdn_Autosearch').val(data);

   
    if (data.indexOf("-") != -1) {

        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txtCommercial_StateCode').val(after);
        $('#txtCommercial_StateName').val(before);

    }
    else {
      
    }
}




//End State Master//

//************************************ HIGH SEA SALE SEARCH BACKUP BY LCD START **********************************************
//

//$(function () {
////    $("#txtImporterName,#txtSellerName").autocomplete({

//    $("#txtSellerName").autocomplete({

//        source: function (request, response) {
//            var field = $(this.element).attr('id');

//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List",
//                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "'}",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {

//                    response(data.d);



//                    if (data.d == '') {
//                        if (field == 'txtImporterName') {
//                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Importer Name', 'error', 'topRight', true);

//                            //jAlert('Importer Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
//                            //return false;
//                        }
//                        if (field == 'txtSellerName') {
//                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Seller Name', 'error', 'topRight', true);

//                            //jAlert('Seller Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
//                            //return false;
//                        }
//                    }
//                    else {
//                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//************************************ HIGH SEA SALE SEARCH BACKUP BY LCD END **********************************************

$(function () {
    //    $("#txtImporterName,#txtSellerName").autocomplete({

    $("#txtSellerName").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');

            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD",
                //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "'}",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",

                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);



                    if (data.d == '') {
                        if (field == 'txtImporterName') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Importer Name', 'error', 'topRight', true);

                            //jAlert('Importer Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtSellerName') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Seller Name', 'error', 'topRight', true);

                            //jAlert('Seller Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
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
   
    $("#txtCountryName,#txtCountryShipment").autocomplete({

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
                        if (field == 'txtCountryName') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);

                            //jAlert('Country Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtCountryShipment') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Shipment', 'error', 'topRight', true);

                            //jAlert('Country Shipment is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                    }
                    else {
                        jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    $("#txtPortOrigin,#txtPortShipment").autocomplete({
        
        source: function (request, response) {
            var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('ddlTransportMode').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtPortOrigin') {
                          
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Origin', 'error', 'topRight', true);

                        }
                        if (field == 'txtPortShipment') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Shipment', 'error', 'topRight', true);

                            //jAlert('Port Shipment is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
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

//********************************************* IMPORTER BRANCHWISE SERIAL NO SEARCH BACKUP BEFORE STD TYPE START *******************************


//$(function () {
//    $("#txtBranchNo").autocomplete({

//        source: function (request, response) {
//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List",
//                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('txtIECNo').value + "'}",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {
//                    response(data.d);
//                    if (data.d == '') {
//                        jQuery('#txtBranchNo').validationEngine('showPrompt', 'Incorrect Branch No', 'error', 'topRight', true);

//                        //jAlert('Branch No is Incorrect', 'GENERAL', function (r) { document.getElementById('txtBranchNo').focus(); });
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

//********************************************* IMPORTER BRANCHWISE SERIAL NO SEARCH BACKUP BEFORE STD TYPE END *******************************


$(function () {
    $("#txtBranchNo").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List_STD_TYPE",
                //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('txtIECNo').value + "'}",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('txtIECNo').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",

                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtBranchNo').validationEngine('showPrompt', 'Incorrect Branch No', 'error', 'topRight', true);

                        //jAlert('Branch No is Incorrect', 'GENERAL', function (r) { document.getElementById('txtBranchNo').focus(); });
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

//************************************ HIGH SEA SALE BRANCH SERIAL NUMBER SEARCH BACKUP BY LCD START **********************************************


//$(function () {
//    $("#txtBranchSLNo").autocomplete({

//        source: function (request, response) {
//            $.ajax({
//                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List",
//                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('txtHighSeaSaleIECNo').value + "'}",
//                dataType: "json",
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                dataFilter: function (data) { return data; },
//                async: true,
//                success: function (data) {
//                    response(data.d);
//                    if (data.d == '') {
//                        jQuery('#txtBranchSLNo').validationEngine('showPrompt', 'Incorrect Branch SlNo', 'error', 'topRight', true);

//                        // jAlert('Branch SlNo is Incorrect', 'GENERAL', function (r) { document.getElementById('txtBranchSLNo').focus(); });
//                        // return false;

//                    }
//                    else {
//                        jQuery('#txtBranchSLNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

//************************************ HIGH SEA SALE BRANCH SERIAL NUMBER SEARCH BACKUP BY LCD END **********************************************

$(function () {
    $("#txtBranchSLNo").autocomplete({

        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List_STD_TYPE",
                //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('txtHighSeaSaleIECNo').value + "'}",
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('txtHighSeaSaleIECNo').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtBranchSLNo').validationEngine('showPrompt', 'Incorrect Branch SlNo', 'error', 'topRight', true);

                        // jAlert('Branch SlNo is Incorrect', 'GENERAL', function (r) { document.getElementById('txtBranchSLNo').focus(); });
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


// call server side method
//---------------------IMPORTER----------------------//
function CallServerside_Importer(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    PageMethods.GetImporter(ctrl.value, CallSuccess_Importer, CallFailed, dest);

}
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
        var CusHous = document.getElementById('txtCustomsHouse').value;      
        var selectedValue = document.getElementById('ddlTransportMode').value;        
        var PortOrigin = document.getElementById('txtPortOrigin').value;
        var PortShipment = document.getElementById('txtPortShipment').value;
        var values = PortOrigin.split("-");
        var values1 = PortShipment.split("-");
        
        if (values[1].length == 5 && values1[1].length == 5 && selectedValue == 'Sea' && CusHous.length == 6 || values[1].length == 5 && values1[1].length == 5 && selectedValue == 'Land' && CusHous.length == 6 || values[1].length == 3 && values1[1].length == 3 && selectedValue == 'Air' && CusHous.length == 6) {    
        }
        else {
           
            document.getElementById('txtPortOrigin').value = '';
            document.getElementById('txtPortShipment').value = '';
        }
        document.getElementById("hdn_CustomsHouse_Name").value = before;


        if (s[0] != document.getElementById("txtCustomsHouse").value) { // if Cushouse Code is wrong s[0] return same Cushouse Code & txtCustomsHouse is same, means invalid Code
            document.getElementById("hdn_Customhouse_chk").value = 'Yes';
        }
        else {
            document.getElementById("hdn_Customhouse_chk").value = 'No';
        }
    }
    else {
       
        document.getElementById("hdn_CustomsHouse_Name").value = '';
    }
}
function CallServerside_Importer_Branch(src, dest, Adcode, Jobno) {
    var ctrl = document.getElementById(src).value;
    var ctrl1 = document.getElementById(dest).value;
    // call server side method
    //alert('l');
//    alert(dest);
    if (ctrl != '') {

        var ieccode;
        ieccode = document.getElementById("txtIECNo").value;
        txtImporterName = document.getElementById("txtImporterName").value;

        if (txtImporterName.length <= 0) {
            jQuery('#txtImporterName').validationEngine('showPrompt', 'ImporterName Field cannot be blank', 'error', 'topRight', true);

            //jAlert('ImporterName Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtImporterName").focus(); });

            //return false;
        }

        else {

            if (ieccode.length < 10) {
                jQuery('#txtIECNo').validationEngine('showPrompt', 'IEC code  Should be 10 digit numbers', 'error', 'topRight', true);

                //jAlert('IEC code  Should be 10 digit numbers', 'GENERAL', function (r) { document.getElementById("txtIECNo").focus(); });

                //return false;
            }

            else {
                jQuery('#txtIECNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);

                PageMethods.GetImporter_Branchwise(ctrl, ctrl1, Adcode, Jobno, CallSuccess_Importer_BranchWise, CallFailed, dest);

            }
        }
    }
}

//---------------------IMPORTER----------------------//
//---------------------SELLER------------------------//

function CallServerside_Seller(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method

    PageMethods.GetImporter(ctrl.value, CallSuccess_seller, CallFailed, dest);

}

function CallServerside_Seller_STD(src, dest,Adcode,Jobno) {
    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);
    // call server side method

    PageMethods.GetImporter_2(ctrl.value, ctrl_2.value,Adcode,Jobno,'Highseasale', CallSuccess_seller, CallFailed, dest);

}

// Load Country of orgin --start
function CallServerside_Country_of_orgin(src, dest) {

    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);

    PageMethods.Ser_Country_of_orgin(ctrl.value, ctrl_2.value, CallSuccess_Countryoforgin, CallFailed, dest);
    CallServerside_Country_of_Shipment(src, dest);
}
function CallSuccess_Countryoforgin(res, destCtrl) {
    var CompanyID = document.getElementById("hdn_CompanyID").value;
//        alert(CompanyID);
            if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4') {
            if (res == "Yes") {
                document.getElementById('txtCountryName').style.border = "1px solid #c8c8c8";
                document.getElementById('Hdcountryoforgin_chk').value = res;
            }
            else {
                document.getElementById('txtCountryName').style.border = "1px solid Red";
                document.getElementById('Hdcountryoforgin_chk').value = res;
            }
        }

}
function CallServerside_Country_of_Shipment(src, dest) {

    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);

    PageMethods.Ser_Country_of_orgin(ctrl.value, ctrl_2.value, CallSuccess_Countryofshipment, CallFailed, dest);
}
function CallSuccess_Countryofshipment(res, destCtrl) {
        var CompanyID = document.getElementById("hdn_CompanyID").value;
        //        alert(CompanyID);
        if (CompanyID != '499' && CompanyID != '526' && CompanyID != '4') {
            if (res == "Yes") {
                document.getElementById('txtCountryShipment').style.border = "1px solid #c8c8c8";
                document.getElementById('Hdcountryofshipment_chk').value = res;
            }
            else {
                document.getElementById('txtCountryShipment').style.border = "1px solid Red";
                document.getElementById('Hdcountryofshipment_chk').value = res;
            }
        }
}
// Load Country of orgin --end

// Load port of orgin --start
function CallServerside_Port_of_orgin(src, dest) {
   
    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);

    //alert(ctrl);
   // alert(ctrl_2);
    PageMethods.Ser_Port_of_orgin(ctrl.value, ctrl_2.value, CallSuccess_Portoforgin, CallFailed, dest);
    CallServerside_Port_of_Shipment(src, dest);
}
function CallSuccess_Portoforgin(res, destCtrl) {

    if (res == "Yes") {
        document.getElementById('txtPortOrigin').style.border = "1px solid #c8c8c8";
        document.getElementById('Hdportoforgin_Chk').value = res;
    }
    else {
        document.getElementById('txtPortOrigin').style.border = "1px solid Red";
        document.getElementById('Hdportoforgin_Chk').value = res;
    }

}
function CallServerside_Port_of_Shipment(src, dest) {

    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);

    PageMethods.Ser_Port_of_orgin(ctrl.value, ctrl_2.value, CallSuccess_Portofshipment, CallFailed, dest);

}
function CallSuccess_Portofshipment(res, destCtrl) {

    if (res == "Yes") {
        document.getElementById('txtPortShipment').style.border = "1px solid #c8c8c8";
        document.getElementById('Hdportofshipment_chk').value = res;
    }
    else {
        document.getElementById('txtPortShipment').style.border = "1px solid Red";
        document.getElementById('Hdportofshipment_chk').value = res;
    }

}


//-----------------SANCO - Country Code & Port code Validation------------------------------
function CallServerside_Port_Country_Origin(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);

    PageMethods.Chk_CountryCode_PortCode(ctrl.value, ctrl_2.value, CallSuccess_Port_Country_Origin, CallFailed, dest);
}
function CallSuccess_Port_Country_Origin(res, destCtrl) {
    if (res == "Yes") {
//        alert(res);
        document.getElementById('txtPortOrigin').style.border = "1px solid #c8c8c8";
        document.getElementById('hdn_CountryCD_PortOrigin_chk').value = res;
    }
    else {
        document.getElementById('txtPortOrigin').style.border = "1px solid Red";
        document.getElementById('hdn_CountryCD_PortOrigin_chk').value = res;
    }
}

function CallServerside_Port_Country_Shipment(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);

    PageMethods.Chk_CountryCode_PortCode(ctrl.value, ctrl_2.value, CallSuccess_Port_Country_shipment, CallFailed, dest);
}
function CallSuccess_Port_Country_shipment(res, destCtrl) {
    if (res == "Yes") {
        document.getElementById('txtPortShipment').style.border = "1px solid #c8c8c8";
        document.getElementById('hdn_CountryCD_PortofShipment_chk').value = res;
    }
    else {
        document.getElementById('txtPortShipment').style.border = "1px solid Red";
        document.getElementById('hdn_CountryCD_PortofShipment_chk').value = res;
    }
}
//-----------------SANCO - Country Code & Port code Validation------------------------------
// Load port of orgin --end









function CallServerside_BranchSeller(src, dest, Adcode, Jobno) {
    var ctrl = document.getElementById(src).value;
    var ctrl1 = document.getElementById(dest).value;
    // call server side method
    //alert('l');
    if (ctrl != '') {

        var ieccode;
        ieccode = document.getElementById("txtHighSeaSaleIECNo").value;
        txtSellerName = document.getElementById("txtSellerName").value;

        if (txtImporterName.length <= 0) {
            jQuery('#txtSellerName').validationEngine('showPrompt', 'Seller Name cannot be blank', 'error', 'topRight', true);

            //jAlert('Seller Name Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtSellerName").focus(); });
            //return false;
        }

        else {

            if (ieccode.length < 10) {
                jQuery('#txtHighSeaSaleIECNo').validationEngine('showPrompt', 'IEC code  Should be 10 digit numbers', 'error', 'topRight', true);

                //jAlert('IEC code  Should be 10 digit numbers', 'GENERAL', function (r) { document.getElementById("txtHighSeaSaleIECNo").focus(); });

                //return false;
            }

            else {
                jQuery('#txtIECNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);

                //                PageMethods.GetImporter_Branchwise(ctrl, ctrl1, CallSuccess_seller_BranchWise, CallFailed, dest);
                PageMethods.GetImporter_HIGHSEA_SALE_Branchwise(ctrl, ctrl1, Adcode, Jobno, CallSuccess_seller_BranchWise, CallFailed, dest);

                
            }
        }
    }

    //$(document).ready(function(){{jAlert('IEC', 'Adcode', function (r) {});}});
}

//---------------------SELLER end------------------------//

//---------------------ADCODE------------------------//

function CallServerside_Adcode(src, dest) {
    var ctrl = document.getElementById(src);
    // call server side method
    var ctrl1 = document.getElementById("txtIECNo").value;
    PageMethods.Get_Adcode(ctrl.value, ctrl1, CallSuccess_Adcode, CallFailed, dest);

}

//Importer Branch
function CallSuccess_Adcode(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after1 = s[1];

        document.getElementById("txt_ADCode").value = before;
    }
    else {
        document.getElementById("txtAdcode").value = "";
        //document.getElementById("txtBankAccount").value = "";
    }

}

//--------------------- ADCODE END ------------------------//

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
        var after7 = s[7];

        document.getElementById("txtAddress1").value = before;
        document.getElementById("txtAddress2").value = after1;
        document.getElementById("txtAddress3").value = after2;
        document.getElementById("txtAddress4").value = after3;
        document.getElementById("txtAddress5").value = after4;
        document.getElementById("txtIECNo").value = after5;
        document.getElementById("txtBranchNo").value = after6;
        document.getElementById("hdn_ImporterType").value = after7;

    }
    else {

        document.getElementById("txtAddress1").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
        document.getElementById("txtAddress5").value = "";
        document.getElementById("txtIECNo").value = "";
        document.getElementById("txtBranchNo").value = "";
        document.getElementById("hdn_ImporterType").value = "";
    }
}
// calling Importer

// calling seller

function CallSuccess_seller(res, destCtrl) {
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
        var Hss_Adcode = s[11];
      

        document.getElementById("txtHighSeaSaleAddress").value = before;
        document.getElementById("txtHighSeaSaleAddress1").value = after1;
        document.getElementById("txtHighSeaSaleAddress2").value = after2;
        document.getElementById("txtHighSeaSaleAddress3").value = after3;
        document.getElementById("txtHighSeaSaleAddress4").value = after4;
        document.getElementById("txtHighSeaSaleIECNo").value = after5;
        document.getElementById("txtBranchSLNo").value = after6;
        document.getElementById("txtHSS_AdCode").value = Hss_Adcode;

    }
    else {
        document.getElementById("txtHighSeaSaleAddress").value = "";
        document.getElementById("txtHighSeaSaleAddress1").value = "";
        document.getElementById("txtHighSeaSaleAddress2").value = "";
        document.getElementById("txtHighSeaSaleAddress3").value = "";
        document.getElementById("txtHighSeaSaleAddress4").value = "";
        document.getElementById("txtHighSeaSaleIECNo").value = "";
        document.getElementById("txtBranchSLNo").value = "";
        document.getElementById("txtHSS_AdCode").value = "";
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

        document.getElementById("txtAddress1").value = before;
        document.getElementById("txtAddress2").value = after1;
        document.getElementById("txtAddress3").value = after2;
        document.getElementById("txtAddress4").value = after3;
        document.getElementById("txtAddress5").value = after4;
        //document.getElementById("txtIECNo").value = after5;
        //document.getElementById("txtBranchNo").value = after6;
        document.getElementById("hdn_ImporterType").value = after7;
        document.getElementById("hd_Brslno").value = after6;

        document.getElementById("txtCommercial_StateName").value = after8;
        document.getElementById("txtCommercial_StateCode").value = after9;
        document.getElementById("txtCommercial_RegistrationNo").value = after10;
        document.getElementById("ddl_Commercial_Type").value = after11;
        document.getElementById("txt_ADCode").value = after12;

    }
    else {

        document.getElementById("txtAddress1").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
        document.getElementById("txtAddress5").value = "";
        //document.getElementById("txtIECNo").value = "";
        //document.getElementById("txtBranchNo").value = "";
        document.getElementById("hdn_ImporterType").value = "";

        document.getElementById("txtCommercial_StateName").value = '';
        document.getElementById("txtCommercial_StateCode").value = '';
        document.getElementById("txtCommercial_RegistrationNo").value = '';
        document.getElementById("ddl_Commercial_Type").value = '';
        document.getElementById("txt_ADCode").value = '';
    }
}
// calling Importer

// calling seller

function CallSuccess_seller_BranchWise(res, destCtrl) {
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
        var Hss_Adcode = s[8];
       
        document.getElementById("txtHighSeaSaleAddress").value = before;
        document.getElementById("txtHighSeaSaleAddress1").value = after1;
        document.getElementById("txtHighSeaSaleAddress2").value = after2;
        document.getElementById("txtHighSeaSaleAddress3").value = after3;
        document.getElementById("txtHighSeaSaleAddress4").value = after4;
        //document.getElementById("txtHighSeaSaleIECNo").value = after5;
        //document.getElementById("txtBranchSLNo").value = after6;
        document.getElementById("txtHSS_AdCode").value = Hss_Adcode;
    }
    else {
        document.getElementById("txtHighSeaSaleAddress").value = "";
        document.getElementById("txtHighSeaSaleAddress1").value = "";
        document.getElementById("txtHighSeaSaleAddress2").value = "";
        document.getElementById("txtHighSeaSaleAddress3").value = "";
        document.getElementById("txtHighSeaSaleAddress4").value = "";
        //document.getElementById("txtHighSeaSaleIECNo").value = "";
        //document.getElementById("txtBranchSLNo").value = "";
        document.getElementById("txtHSS_AdCode").value = "";
    }
}
// calling seller
// Importer Branch

//Importer Branch
// alert message on some failure
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}

//-----------------------------------START SCHEME LAOD--------------------------------------//

function GetScheme1() {

    var ddlCountries;
    ddlCountries = document.getElementById("ddlSchemeCode");
    ddlCountries.options.length == 0;

    PageMethods.Get_Scheme1(ddlCountries.value, onsuccess);
}

function GetScheme2() {

    var ddlCountries = document.getElementById("ddlSchemeCode");
    var ddlCountries1 = document.getElementById("ddlScheme_NOTN");

    ddlCountries.options.length == 0;

    PageMethods.Get_Scheme2(ddlCountries.value, ddlCountries1.value, onsuccess1);
}

function onsuccess(response) {
    try {
        var ddl = document.getElementById("ddlScheme_NOTN");
        var count = ddl.options.length;

        while (ddl.options.length > 0) {
            ddl.options.remove(0);
        }
        $.each(response, function () {
            $("#ddlScheme_NOTN").append($("<option></option>").val(this['scheme_Notn']).html(this['scheme_Notn']));
        });
        GetScheme2();
    }
    catch (e) {
        //alert(e);
    }
}
function onsuccess1(response) {
    try {
        var ddl = document.getElementById("ddlScheme_NOTN_SL");
        var count = ddl.options.length;

        while (ddl.options.length > 0) {
            ddl.options.remove(0);
        }
        $.each(response, function () {
            $("#ddlScheme_NOTN_SL").append($("<option></option>").val(this['scheme_Notn']).html(this['scheme_Notn']));
        });

    }
    catch (e) {
        //alert(e);
    }
}
//-----------------------------------START SCHEME LAOD--------------------------------------//

//------------------Import Importer Auto Search Branch Sl No-------------------------------//

//-------------------------------------auto search--start-----------------------------------------------------------------------
$(function () {
    $("#txtImporterName").autocomplete({

        source: function (request, response) {
            var field = $(this.element).attr('id');
            var CompanyID = document.getElementById("hdn_CompanyID").value;
           
            var call_url = '';
            if (CompanyID == '1' || CompanyID == '2145') {
                call_url = '../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD_Location';
            }
            else {
                call_url = '../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD';
            }
            $.ajax({
                //                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD",
               
                url: call_url,
                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "' ,'JobType':'" + 'Import' + "'}",

                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {

                    response(data.d);



                    if (data.d == '') {
                        if (field == 'txtImporterName') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Importer Name', 'error', 'topRight', true);

                            //jAlert('Importer Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                            //return false;
                        }
                        if (field == 'txtSellerName') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Seller Name', 'error', 'topRight', true);

                            //jAlert('Seller Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
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
//-------------------------------------auto search--end-------------------------------------------------------------------------



//---------------------IMPORTER----2---------------------//
function CallServerside_Importer_2(src, dest,Adcode,Jobno) {
    var ctrl = document.getElementById(src);
    var ctrl_2 = document.getElementById(dest);
    // call server side method
    PageMethods.GetImporter_2(ctrl.value, ctrl_2.value,Adcode,Jobno,'Importer', CallSuccess_Importer_2, CallFailed, dest);

}
function CallSuccess_Importer_2(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    var importerName = document.getElementById('txtImporterName').value;
    var ddlBEType = document.getElementById("ddlBEType").value;
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
        var commercialYN = s[10];
        var Imp_ADCode = s[11];

        var after12 = s[12];
        var after13 = s[13];
        var after14 = s[14];
        var after15 = s[15];
        var after16 = s[16];
        var after17 = s[17];
        var after18 = s[18];
        var after19 = s[19];
        var after20 = s[20];
             
        document.getElementById("txtAddress1").value = before;
        document.getElementById("txtAddress2").value = after1;
        document.getElementById("txtAddress3").value = after2;
        document.getElementById("txtAddress4").value = after3;
        document.getElementById("txtAddress5").value = after4;
        document.getElementById("txtIECNo").value = after5;
        document.getElementById("txtBranchNo").value = after6;
       
        if (ddlBEType == 'Home') {
            document.getElementById("txtWarehouseCode").value = "";
        }
        else {
            document.getElementById("txtWarehouseCode").value = after19;
        }
        if (after20 != '') {
            document.getElementById("txt_Payment_Method").value = after20;
        }
        else {
            document.getElementById("txt_Payment_Method").value = "T";
        }

        if (ddlBEType == 'SEZ FTA-Z' || ddlBEType == 'SEZ DTA-T' || ddlBEType == 'SEZ DTA-M') {
            document.getElementById("ddlType").value = after7;
        }
        else {
            document.getElementById("hdn_ImporterType").value = after7;
        }

        document.getElementById("hdn_TIN_NO").value = after8;
        document.getElementById("hdn_StateName").value = after3;
        /* document.getElementById("hdn_commercialType").value = 'V';
        document.getElementById("hdn_StateCode").value = after9;*/


        /* document.getElementById("txtCommercial_RegistrationNo").value = after8;
        document.getElementById("txtCommercial_StateName").value = after3; 
        document.getElementById("txtCommercial_Taxtype").value = 'V';*/
        document.getElementById("txtCommercial_StateCode").value = after9;
        document.getElementById("txt_ADCode").value = Imp_ADCode;

        if (after12 == 'Y') {

            $("#txtCommercial_StateName").removeAttr("disabled");
            $("#txtCommercial_StateCode").removeAttr("disabled");
            $("#ddl_Commercial_Type").removeAttr("disabled");
            $("#txtCommercial_RegistrationNo").removeAttr("disabled");

            $("#ddlCommercial_Tax_yn").val(after12);
            document.getElementById("txtCommercial_StateName").value = after13;
            document.getElementById("txtCommercial_StateCode").value = after14;
            document.getElementById("ddl_Commercial_Type").value = after16;
            document.getElementById("txtCommercial_RegistrationNo").value = after15;

            //------- this Method for StateName Validation while create the New job..
            PageMethods.Set_State_Name_Validation(after13, CallSuccess_State_Name_Validation, CallFailed);
            //------------------------------------------------

            document.getElementById('ST_Code').style.visibility = 'visible';
        }
        else {
            $("#ddlCommercial_Tax_yn").val('N');

            $("#txtCommercial_StateName").val('');
            $("#txtCommercial_StateCode").val('');
            $("#ddl_Commercial_Type").val('');
            $("#txtCommercial_RegistrationNo").val('');

            $("#txtCommercial_StateName").attr("disabled", "disabled");
            $("#txtCommercial_StateCode").attr("disabled", "disabled");
            $("#ddl_Commercial_Type").attr("disabled", "disabled");
            $("#txtCommercial_RegistrationNo").attr("disabled", "disabled");
            document.getElementById('ST_Code').style.visibility = 'hidden';
        }

        var CompanyID = document.getElementById("hdn_CompanyID").value;
        if (CompanyID == '151' || CompanyID == '125') {
            if (after5 == '0288008111') {
                document.getElementById("txt_Payment_Method").value = 'D';
            }
            else {
                document.getElementById("txt_Payment_Method").value = 'T';
            }
        }
        if (CompanyID == '164') {
            if (after5 == '0488029422') {
                document.getElementById("txt_Payment_Method").value = 'D';
            }
            else {
                document.getElementById("txt_Payment_Method").value = 'T';
            }
        }
        if (CompanyID == '616') {
            if (after5 == '0398070385') {
                document.getElementById("txt_Payment_Method").value = 'D';
            }
            else {
                document.getElementById("txt_Payment_Method").value = 'T';
            }
        }

        if (importerName == 'SCHAEFFLER INDIA LIMITED' && CompanyID == '2145') {
            txt_Payment_Method.value = 'D';
        }
    }
    else {

        document.getElementById("txtAddress1").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
        document.getElementById("txtAddress5").value = "";
        document.getElementById("txtIECNo").value = "";
        document.getElementById("txtBranchNo").value = "";
        document.getElementById("hdn_ImporterType").value = "";
        document.getElementById("hdn_TIN_NO").value = "";
        document.getElementById("hdn_StateName").value = "";
        document.getElementById("txtCommercial_RegistrationNo").value = "";
        document.getElementById("txtCommercial_StateName").value = "";
        document.getElementById("ddl_Commercial_Type").value = "";
        document.getElementById("txtCommercial_StateCode").value = "";
        document.getElementById("txt_ADCode").value = "";
        document.getElementById("ddlCommercial_Tax_yn").value = "N";
        document.getElementById("txtCommercial_StateName").value = "";
        document.getElementById("txtCommercial_StateCode").value = "";
        document.getElementById("txtCommercial_RegistrationNo").value = "";
        document.getElementById("ddl_Commercial_Type").value = "";

        $("#txtCommercial_StateName").attr("disabled", "disabled");
        $("#txtCommercial_StateCode").attr("disabled", "disabled");
        $("#ddl_Commercial_Type").attr("disabled", "disabled");
        $("#txtCommercial_RegistrationNo").attr("disabled", "disabled");
        document.getElementById('ST_Code').style.visibility = 'hidden';

        document.getElementById("ddl_GSTN_Type").value = "";
        document.getElementById("txt_GSTN_ID").value = "";
        document.getElementById("txtWarehouseCode").value = "";

    }
}

//======================IMPORTER----2--END===============================================

$(function () {
    $("#txtWarehouseCode").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Warehouse_code_Master_List",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txtWarehouseCode') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Warehouse Code', 'error', 'topRight', true);
                        }
                        if (field == 'txtWarehouseCode') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Warehouse Code', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#txtWarehouseCode').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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



function CallServerside_Importer_BillingOthers(src, dest) {
    var ctrl = document.getElementById(src);
    var ctrl1 = document.getElementById(dest);
    // call server side method
  
    PageMethods.GetImporter_Billing_Others(ctrl.value,ctrl1.value, CallSuccess_Importer_BillingOthers, CallFailed, dest);

}

function CallSuccess_Importer_BillingOthers(res, destCtrl) {
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

        document.getElementById("txt_Name").value = before;
        document.getElementById("txtAddress1").value = after1;
        document.getElementById("txtAddress2").value = after2;
        document.getElementById("txtAddress3").value = after3;
        document.getElementById("txtAddress4").value = after4;
       
    }
    else {
        document.getElementById("txt_Name").value = "";
        document.getElementById("txtAddress1").value = "";
        document.getElementById("txtAddress2").value = "";
        document.getElementById("txtAddress3").value = "";
        document.getElementById("txtAddress4").value = "";
       
    }
}


// Load State name --start
function CallServerside_State_Name_Validation(src) {
    var ctrl = document.getElementById(src);
  
    PageMethods.Set_State_Name_Validation(ctrl.value, CallSuccess_State_Name_Validation, CallFailed);
}
function CallSuccess_State_Name_Validation(res) {
  
    if (res == "Yes") {
        document.getElementById('txtCommercial_StateName').style.border = "1px solid #c8c8c8";
        document.getElementById('hdn_StateName_chk').value = res;
    }
    else {
        document.getElementById('txtCommercial_StateName').style.border = "1px solid Red";
        document.getElementById('hdn_StateName_chk').value = res;
    }
}
// Load State name --end


function CallServerside_Importer_ChkBind(src) {
    var ctrl = document.getElementById(src);
    // call server side method
    PageMethods.GetImporter_ChkBind(ctrl.value, 'Importer', CallSuccess_Importer_ChkBind, CallFailed);

}

function CallSuccess_Importer_ChkBind(res, destCtrl) {
    var dest = document.getElementById(destCtrl);
    var data = res;
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');

        var before = s[0];
        var after = s[1];

        document.getElementById("txtBranchNo").value = after;
        document.getElementById("txtIECNo").value = before;
    }
    else {
        document.getElementById("txtBranchNo").value = "";
        document.getElementById("txtIECNo").value = "";
    }
}
