
var values = '';

$('#ddlFilingStatus').change(function () {
    //    alert($('#ddlFilingStatus').val());

    if (document.getElementById('hdn_Jobno').value != '') {

        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'Block';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';

        document.getElementById("General").className = 'inactive';
        document.getElementById("IGM").className = 'active';

        var values = $('#ddlFilingStatus').val();
        document.getElementById("Trans_igm_Iframe").src = '../Transaction/IGM_Details.aspx?jobno=' + values;
    }
    else {
        happycode();
    }
});
