function validate() {
    var txtCertificateNo = document.getElementById("txtCertificateNo").value;
    if (txtCertificateNo.length <= 0) {
        jAlert('Certificate No cannot be blank', 'CERTIFICATE', function (r) { document.getElementById("txtCertificateNo").focus(); });

        return false;
    }

    var txtCertificateDate = document.getElementById("<%=txtCertificateDate.ClientID%>").value;
    if (txtCertificateDate.length <= 0) {
        if (document.getElementById("hdn_CompanyID").value != 'eri00747' && document.getElementById("hdn_CompanyID").value != 'eri00004' && document.getElementById("hdn_CompanyID").value != 'eri00010' && document.getElementById("hdn_CompanyID").value != 'eri00005') {
            jAlert('Certificate Date cannot be blank', 'CERTIFICATE', function (r) { document.getElementById("txtCertificateDate").focus(); });
            return false;
        }
    }
    else {
        if (isDate(txtCertificateDate)) {

        }
        else {
            jAlert('Certificate Date is Invalid Date', 'CERTIFICATE', function (r) { document.getElementById("txtCertificateDate").focus(); });
            return false;
        }
    }
}