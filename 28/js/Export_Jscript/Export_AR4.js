function validate_Export_EXPORT_AR4_Details() {
    //if (Page_ClientValidate()) // this will trigger validator
    //  {
    var txtAR4No;
    txtAR4No = document.getElementById("txtAR4No").value;

    if (txtAR4No.length <= 0) {
        jAlert('AR4 No  cannot be blank', 'EXPORT_AR4', function (r) { document.getElementById("txtAR4No").focus(); });

        return false;
    }


    if (document.getElementById("txtAR4Date").value <= 0) {
        jAlert('AR4 Date cannot be blank', 'EXPORT_AR4', function (r) { document.getElementById("txtAR4Date").focus(); });

        return false;
    }
    if (isDate(document.getElementById("txtAR4Date").value)) {

    }
    else {
        jAlert('AR4 Date is Invalid Date', 'EXPORT_AR4', function (r) { document.getElementById("txtAR4Date").focus(); });

        return false;
    }



    var txtCommissionRate;
    txtCommissionRate = document.getElementById("txtCommissionRate").value;

    if (txtCommissionRate.length <= 0) {
        jAlert('Commission Rate cannot be blank', 'EXPORT_AR4', function (r) { document.getElementById("txtCommissionRate").focus(); });

        return false;
    }

    var txtDivision;
    txtDivision = document.getElementById("txtDivision").value;

    if (txtDivision.length <= 0) {
        jAlert('Division cannot be blank', 'EXPORT_AR4', function (r) { document.getElementById("txtDivision").focus(); });

        return false;
    }

    var txtRange;
    txtRange = document.getElementById("txtRange").value;

    if (txtRange.length <= 0) {
        jAlert('Range cannot be blank', 'EXPORT_AR4', function (r) { document.getElementById("txtRange").focus(); });

        return false;
    }


}

     