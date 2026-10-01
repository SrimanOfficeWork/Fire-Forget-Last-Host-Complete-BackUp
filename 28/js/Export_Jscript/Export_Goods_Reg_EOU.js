function validate_Export_GOODS_REG_EOU_Details() {
    //if (Page_ClientValidate()) // this will trigger validator
    //  {


    if (document.getElementById("txtExaminationDate").value <= 0) {
        jAlert('Examination Date cannot be blank', 'GOODS_REG_EOU', function (r) { document.getElementById("txtExaminationDate").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtExaminationDate").value)) {

    }
    else {
        jAlert('Examination Date is Invalid Date', 'GOODS_REG_EOU', function (r) { document.getElementById("txtExaminationDate").focus(); });

        return false;
    }



    var txtExam_Officer;
    txtExam_Officer = document.getElementById("txtExam_Officer").value;

    if (txtExam_Officer.length <= 0) {
        jAlert('Exam Officer cannot be blank', 'GOODS_REG_EOU', function (r) { document.getElementById("txtExam_Officer").focus(); });

        return false;
    }

    var txtExam_Design;
    txtExam_Design = document.getElementById("txtExam_Design").value;

    if (txtExam_Design.length <= 0) {
        jAlert('Exam Designation cannot be blank', 'GOODS_REG_EOU', function (r) { document.getElementById("txtExam_Design").focus(); });

        return false;
    }

    var txtSuperv_Officer;
    txtSuperv_Officer = document.getElementById("txtSuperv_Officer").value;

    if (txtSuperv_Officer.length <= 0) {
        jAlert('Supervising Officer cannot be blank', 'GOODS_REG_EOU', function (r) { document.getElementById("txtSuperv_Officer").focus(); });

        return false;
    }
    var txtSuperv_Design;
    txtSuperv_Design = document.getElementById("txtSuperv_Design").value;

    if (txtSuperv_Design.length <= 0) {
        jAlert('Supervising Design cannot be blank', 'GOODS_REG_EOU', function (r) { document.getElementById("txtSuperv_Design").focus(); });

        return false;
    }
    var txtCommissionRate;
    txtCommissionRate = document.getElementById("txtCommissionRate").value;

    if (txtCommissionRate.length <= 0) {
        jAlert('Commission Rate cannot be blank', 'GOODS_REG_EOU', function (r) { document.getElementById("txtCommissionRate").focus(); });

        return false;
    }

    var txtDivision;
    txtDivision = document.getElementById("txtDivision").value;

    if (txtDivision.length <= 0) {
        jAlert('Division cannot be blank', 'GOODS_REG_EOU', function (r) { document.getElementById("txtDivision").focus(); });

        return false;
    }

    var txtRange;
    txtRange = document.getElementById("txtRange").value;

    if (txtRange.length <= 0) {
        jAlert('Range cannot be blank', 'GOODS_REG_EOU', function (r) { document.getElementById("txtRange").focus(); });

        return false;
    }
    //              if (document.getElementById("chkVerifiedOfficer').checked == false) {
    //                  jAlert('Select Verified Officer', 'ANNEXUE_C1', function (r) { document.getElementById("chkVerifiedOfficer").focus(); });


    //                  $('#form1').validationEngine('detach');
    //                  return false;
    //              }
    //              if (document.getElementById("chkSampleDrawn').checked == false) {
    //                  jAlert('Select Sample Drawn', 'ANNEXUE_C1', function (r) { document.getElementById("chkSampleDrawn").focus(); });


    //                  $('#form1').validationEngine('detach');
    //                  return false;
    //              }



    var txtSealNo;
    txtSealNo = document.getElementById("txtSealNo").value;

    if (txtSealNo.length <= 0) {
        jAlert('SealNo cannot be blank', 'GOODS_REG_EOU', function (r) { document.getElementById("txtSealNo").focus(); });

        return false;
    }






}

//}
         