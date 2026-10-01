//test General job edit - [txt_jobno]

$(function () {
    $('#txt_jobno,#txt_Branch').keyup(function (e) {
        var txtVal = $(this).val().toUpperCase();

        var Chbranch = $("#Chbranch").is(':checked')
        var chyear = $("#chyear").is(':checked')

        if (Chbranch == true && chyear == true) {

            if ($('#txt_Branch').val() != "" && $('#txt_jobno').val() != "") {

                $('#txtpreview').val($('#txt_Branch').val() + ' / ' + $('#txt_jobno').val() + ' / ' + $('#txtyear').val());
            }
            else if ($('#txt_Branch').val() == "" && $('#txt_jobno').val() == "") {
                $('#txtpreview').val($('#txtyear').val());
            }

            else if ($('#txt_Branch').val() == "" && $('#txt_jobno').val() != "") {

                $('#txtpreview').val($('#txt_jobno').val() + ' / ' + $('#txtyear').val());
            }
            else if ($('#txt_Branch').val() != "" && $('#txt_jobno').val() == "") {
                $('#txtpreview').val($('#txt_Branch').val() + ' / ' + $('#txtyear').val());
            }


        }

        else if (Chbranch == true && chyear == false) {

            if ($('#txt_Branch').val() == "" && $('#txt_jobno').val() == "") {

                $('#txtpreview').val("");
            }
            else if ($('#txt_Branch').val() == "" && $('#txt_jobno').val() != "") {

                $('#txtpreview').val($('#txt_jobno').val());
            }
            else if ($('#txt_Branch').val() != "" && $('#txt_jobno').val() != "") {

                $('#txtpreview').val($('#txt_Branch').val() + ' / ' + $('#txt_jobno').val());
            }
            else if ($('#txt_Branch').val() != "" && $('#txt_jobno').val() == "") {

                $('#txtpreview').val($('#txt_Branch').val());
            }


        }
        else if (Chbranch == false && chyear == true) {

            if ($('#txt_jobno').val() == "") {

                $('#txtpreview').val($('#txtyear').val());
            }
            else if ($('#txt_jobno').val() != "") {

                $('#txtpreview').val($('#txt_jobno').val() + ' / ' + $('#txtyear').val());
            }
        }

        else if (Chbranch == false && chyear == false) {

            $('#txtpreview').val($('#txt_jobno').val());
        }


    });

});
//test General job edit - [txt_jobno]

//Jobchk

$(function () {
    $("#txt_jobno").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_Jobedit",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) {
                    return data;
                },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        document.getElementById('txtid').value = 'Job already exists';
                    }
                    else {
                          document.getElementById('txtid').value = '';
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //alert('ram');
                }
            });
        },
        minLength: 1

    });
    return false;
    scroll: true;

});


