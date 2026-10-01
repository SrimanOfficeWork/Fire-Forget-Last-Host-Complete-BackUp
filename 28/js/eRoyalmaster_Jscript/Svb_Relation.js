$(function () {

    $('#chkSVB_Relation').click(function (e) {
        jQuery('#form1').validationEngine('detach');
        var txtSVB_RefNo = $('#txtSVB_RefNo');
        var txtSVBDate = $('#txtSVBDate');
        var ddlLoadingOn = $('#ddlLoadingOn');
        var txtAssesable_Rate = $('#txtAssesable_Rate');
        var ddlAssesable_Status = $('#ddlAssesable_Status');
        var txtDuty_Rate = $('#txtDuty_Rate');
        var ddlDuty_Status = $('#ddlDuty_Status');
        var ddlSVB_CustomHouse = $('#txtCustomsHouse');

        if (this.checked) {
            txtSVB_RefNo.val('');
            txtSVBDate.val('');
            //                        txtAssesable_Rate.val('');
            //                        txtDuty_Rate.val('');
            ddlLoadingOn.val('');
            //                        ddlAssesable_Status.val('');
            //                        ddlDuty_Status.val('');

            txtSVB_RefNo.attr('disabled', false);
            txtSVBDate.attr('disabled', false);
            //                        txtAssesable_Rate.attr('disabled', false);
            //                        txtDuty_Rate.attr('disabled', false);
            ddlLoadingOn.attr('disabled', false);
            //                        ddlAssesable_Status.attr('disabled', false);
            //                        ddlDuty_Status.attr('disabled', false);
            ddlSVB_CustomHouse.attr('disabled', false);



            ddlLoadingOn.change(function (e) {
                var selectedValue = $(this).val();
                jQuery('#form1').validationEngine('detach');
                if (selectedValue == '') {

                    txtAssesable_Rate.val('');
                    ddlAssesable_Status.val('');
                    txtDuty_Rate.val('');
                    ddlDuty_Status.val('');

                    ddlAssesable_Status.attr('disabled', true);
                    txtAssesable_Rate.attr('disabled', true);
                    txtDuty_Rate.attr('disabled', true);
                    ddlDuty_Status.attr('disabled', true);

                    //                    alert('Terms Cannot be empty');

                }
                else if (selectedValue == 'Assessable') {

                    txtDuty_Rate.val('');

                    ddlDuty_Status.val('');

                    ddlAssesable_Status.attr('disabled', false);
                    txtAssesable_Rate.attr('disabled', false);
                    txtDuty_Rate.attr('disabled', true);
                    ddlDuty_Status.attr('disabled', true);


                }
                else if (selectedValue == 'Duty') {

                    txtAssesable_Rate.val('');
                    ddlAssesable_Status.val('');

                    ddlAssesable_Status.attr('disabled', true);
                    txtAssesable_Rate.attr('disabled', true);
                    txtDuty_Rate.attr('disabled', false);
                    ddlDuty_Status.attr('disabled', false);


                }
                else if (selectedValue == 'Both') {

                    ddlAssesable_Status.attr('disabled', false);
                    txtAssesable_Rate.attr('disabled', false);
                    txtDuty_Rate.attr('disabled', false);
                    ddlDuty_Status.attr('disabled', false);


                }
            });
        }
        else {

            txtSVB_RefNo.val('');
            txtSVBDate.val('');
            txtAssesable_Rate.val('');
            txtDuty_Rate.val('');
            ddlLoadingOn.val('');
            ddlAssesable_Status.val('');
            ddlDuty_Status.val('');

            txtSVB_RefNo.attr('disabled', true);
            txtSVBDate.attr('disabled', true);
            txtAssesable_Rate.attr('disabled', true);
            txtDuty_Rate.attr('disabled', true);
            ddlLoadingOn.attr('disabled', true);
            ddlAssesable_Status.attr('disabled', true);
            ddlDuty_Status.attr('disabled', true);
            ddlSVB_CustomHouse.attr('disabled', true);
        }
    });

});

$(function () {

    $('#ddlLoadingOn').change(function (e) {
        var selectedValue = $(this).val();

        var txtSVB_RefNo = $('#txtSVB_RefNo');
        var txtSVBDate = $('#txtSVBDate');
        var ddlLoadingOn = $('#ddlLoadingOn');
        var txtAssesable_Rate = $('#txtAssesable_Rate');
        var ddlAssesable_Status = $('#ddlAssesable_Status');
        var txtDuty_Rate = $('#txtDuty_Rate');
        var ddlDuty_Status = $('#ddlDuty_Status');
        var ddlSVB_CustomHouse = $('#txtCustomsHouse');

        jQuery('#form1').validationEngine('detach');
        if (selectedValue == '') {

            txtAssesable_Rate.val('');
            ddlAssesable_Status.val('');
            txtDuty_Rate.val('');
            ddlDuty_Status.val('');

            ddlAssesable_Status.attr('disabled', true);
            txtAssesable_Rate.attr('disabled', true);
            txtDuty_Rate.attr('disabled', true);
            ddlDuty_Status.attr('disabled', true);

            //                    alert('Terms Cannot be empty');

        }
        else if (selectedValue == 'Assessable') {

            txtDuty_Rate.val('');

            ddlDuty_Status.val('');

            ddlAssesable_Status.attr('disabled', false);
            txtAssesable_Rate.attr('disabled', false);
            txtDuty_Rate.attr('disabled', true);
            ddlDuty_Status.attr('disabled', true);


        }
        else if (selectedValue == 'Duty') {

            txtAssesable_Rate.val('');
            ddlAssesable_Status.val('');

            ddlAssesable_Status.attr('disabled', true);
            txtAssesable_Rate.attr('disabled', true);
            txtDuty_Rate.attr('disabled', false);
            ddlDuty_Status.attr('disabled', false);
        }
        else if (selectedValue == 'Both') {

            ddlAssesable_Status.attr('disabled', false);
            txtAssesable_Rate.attr('disabled', false);
            txtDuty_Rate.attr('disabled', false);
            ddlDuty_Status.attr('disabled', false);
        }
    });

    $(function () {
        var ass_status = '';
        var Duty_Status = '';
        ass_status = $('#ddlAssesable_Status').val();
        Duty_Status = $('#ddlDuty_Status').val();

        $('#ddlAssesable_Status').change(function () {
            ass_status = $('#ddlAssesable_Status').val();

            if (ass_status == 'Provisional' || Duty_Status == 'Provisional') {
                $("#txtBond_No").removeAttr("disabled");
                $("#txtBondLocation").removeAttr("disabled");
                $("#ddlBondType").removeAttr("disabled");
            }
            else {
                $("#txtBond_No").attr("disabled", "disabled");
                $("#txtBondLocation").attr("disabled", "disabled");
                $("#ddlBondType").attr("disabled", "disabled");

            }
        });

        $('#ddlDuty_Status').change(function () {
            Duty_Status = $('#ddlDuty_Status').val();
            
            if (ass_status == 'Provisional' || Duty_Status == 'Provisional') {
                $("#txtBond_No").removeAttr("disabled");
                $("#txtBondLocation").removeAttr("disabled");
                $("#ddlBondType").removeAttr("disabled");
            }
            else {
                $("#txtBond_No").attr("disabled", "disabled");
                $("#txtBondLocation").attr("disabled", "disabled");
                $("#ddlBondType").attr("disabled", "disabled");
            }
        });
    });
});
