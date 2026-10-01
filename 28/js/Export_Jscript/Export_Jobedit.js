$(function () {
    $("#txt_E_jobno").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXP_Jobedit",
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
                        document.getElementById('txt_alt').value = 'Job already exists';
                    }
                    else {
                        document.getElementById('txt_alt').value = '';
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