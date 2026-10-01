$(document).ready(function () {
   
    var iframeCKEditor = $("#cke_CKEditor1").find("iframe");
    $("#rdoCreateTemplate").prop("checked", true);
    $('#divGenerateTemplate').hide();
    $("#btnSave").show();
    $("#btnUpdate").hide();
    $("#btnClear").show();
    $("#btnDelete").hide();
    //$("#ddlJobNo").prop('disabled', true);

    $("#aViewVariable").click(function () {
        setVisibility('divVariables', 'inline');
    });

    $("#btnClear").click(function () {
        $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML = "";
    });

    $("#btnnew").click(function () {
        document.getElementById("txtTemplateName").value = "";
        $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML = "";
    });
    //----------------------------------------------------------------------------
//    $.ajax({
//        type: "POST",
//        url: "EXP_MyEditor.aspx/Load_Jobno",
//        data: "",
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
//        },
//        success: function (result) {
//            var select = $("#ddlJobNo");
//            select.children().remove();
//            $(result.d).each(function (index, item) {
//                select.append($("<option>").val(item.TemplateId).text(item.TemplateName));
//            });
//        }
//    });
    //----------------------------------------------------------------------------

    $.ajax({
   
        type: "POST",
        url: "EXP_MyEditor.aspx/GetTableVariables",
        data: '',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            var tableVariableHTML = '';
            tableVariableHTML = tableVariableHTML + '<ul>';
            $.each(result.d, function (index, tableVariable) {
                tableVariableHTML = tableVariableHTML + "";
                tableVariableHTML = tableVariableHTML + "<li><a>" + tableVariable.TableName + "</a><ul>";
                $.each(tableVariable.ColumnNames, function (index, column) {
                    tableVariableHTML = tableVariableHTML + "<li><a href='#'>" + column.ColumnName + "</a></li>";
                });
                tableVariableHTML = tableVariableHTML + "</ul></li>";
            });
            tableVariableHTML = tableVariableHTML + "</ul>";
            $('#divVariables').html($('#divVariables').html() + tableVariableHTML);


            $('.tree li').each(function () {
                if ($(this).children('ul').length > 0) {
                    $(this).addClass('parent');
                }
            });

            $('.tree li.parent > a').click(function () {
                $(this).parent().toggleClass('active');
                $(this).parent().children('ul').slideToggle('fast');
            });

            $('#all').click(function () {
                $('.tree li').each(function () {
                    $(this).toggleClass('active');
                    $(this).children('ul').slideToggle('fast');
                });
                return false;
            });

            $('#btnVariableClose').click(function () {
                setVisibility('divVariables', 'none');
                return false;
            });

            $('.tree li').each(function () {
                $(this).toggleClass('active');
                $(this).children('ul').slideToggle('fast');
            });

            setVariableAction();
        }

    });

    function htmlEncode(value) {
        return $('<div/>').text(value).html();
    }

    function htmlDecode(value) {
        return $('<div/>').html(value).text();
    }
    $('input:radio').change(function () {
        if (this.id == 'rdoCreateTemplate') {
            $("#divCreateTemplate").show();
            $("#divGenerateTemplate").hide();
            $("#btnSave").show();
            $("#btnUpdate").hide();
            $("#btnClear").show();
            $("#btnDelete").hide();
           // $("#ddlJobNo").prop('disabled', true);
           // $("#ddlJobNo").val('0');
            $("#btnnew").show();

            $("#divVar").show();
        }
        else if (this.id == 'rdoGenerateTemplate') {
            $("#divGenerateTemplate").show();
            $("#divCreateTemplate").hide();

            $("#btnSave").hide();
            $("#btnClear").show();
           // $("#ddlJobNo").prop('disabled', true);
           // $("#ddlJobNo").val('0');

            PopulateTemplates();
            $("#btnDelete").hide();
            $("#btnUpdate").hide();
            $("#btnnew").hide();
            $("#btnGenerateTemplate").hide();
            $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML = "";

            $("#divVar").hide();
        }
        else if (this.id == 'rdoReportTemplate') {
            $("#divGenerateTemplate").show();
            $("#divCreateTemplate").hide();

            $("#btnSave").hide();
            $("#btnClear").hide();
           // $("#ddlJobNo").prop('disabled', false);

            PopulateTemplates();
            $("#btnDelete").hide();
            $("#btnUpdate").hide();
            $("#btnnew").hide();
            $("#btnGenerateTemplate").show();
            $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML = "";
            $("#divVar").hide();
        }
    });

    PopulateTemplates = function () {
        //var dataValue = "{ name: 'person'}";
        $.ajax({
       
            type: "POST",
            url: "EXP_MyEditor.aspx/LoadTemplates",
            data: "",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                var select = $("#ddlTemplateNames");
                select.children().remove();
                $(result.d).each(function (index, item) {
                    select.append($("<option>").val(item.TemplateId).text(item.TemplateName));
                });
            }
        });
    }

    $("#ddlTemplateNames").change(function () {
        //alert($("input[name=templatePage]:checked").val());
        if ($("#ddlTemplateNames option:selected").val() != 0 && $("input[name=templatePage]:checked").val() != 'reporttetemplate') {
            $("#btnUpdate").show();
            $("#btnDelete").show();
            $("#divVar").show();
        }
        else {
            $("#btnUpdate").hide();
            $("#btnDelete").hide();
            $("#divVar").hide();
        }

        var requestData = {
            templateId: $("#ddlTemplateNames option:selected").val()
        };
        $.ajax({
            type: "POST",
            url: "EXP_MyEditor.aspx/LoadTemplateSource",
            data: JSON.stringify(requestData),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                var ss = htmlDecode(result.d);
                $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML = htmlDecode(result.d);
            }
        });
    });

    $("#btnGenerateTemplate").click(function () {


        if ($("#ddlTemplateNames option:selected").val() != '0') 
        {
            if ($("#ddlJobNo option:selected").val() != '--Select--') 
            {
                var dataValue = "{ name: " + $("#ddlJobNo option:selected").val() + " , Tempname: " + $("#ddlTemplateNames option:selected").val() + "  }";
                $.ajax({
                    type: "POST",
                    url: "EXP_MyEditor.aspx/GenerateTemplate",
                    data: dataValue,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML = htmlDecode(result["d"].HTMLSource);
                    }
                });

            }
            else 
            {
                alert('Select JobNo !');
            }

        }
        else {
            alert('Select Ur Template !');
        }
    });


    //    var doc = new jsPDF();
    //    var specialElementHandlers = {
    //        '#editor': function (element, renderer) {
    //            return true;
    //        }
    //    };


    $('#btnPdf').click(function () {

        //        //alert($("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML);
        //        doc.fromHTML("<div id='content'>" + $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML + "</div>", 15, 15, {
        //            'width': 170,
        //            'elementHandlers': specialElementHandlers
        //        });
        //        doc.save('sample-file.pdf');

        if ($("input[name=templatePage]:checked").val() == 'reporttetemplate' || $("input[name=templatePage]:checked").val() == 'generatetemplate') {

            if ($("#ddlTemplateNames option:selected").val() != '0') {
                DownloadPDF();
            }
            else {
                alert('Select Ur Template !');
            }
        }
        else {
            DownloadPDF();
        }

    });

    $("#btnSave").click(function () {
        var templateHtmlSource = $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML
        templateHtmlSource = htmlEncode(templateHtmlSource);
        var requestData = {
            templateName: $('#txtTemplateName').val(),
            templateHtmlSource: templateHtmlSource
        };
        $.ajax({
            type: "POST",
            url: "EXP_MyEditor.aspx/SaveTemplate",
            data: JSON.stringify(requestData),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                if (result.d == '1') {
                    alert("Template Saved Successfully.");
                }
                else if (result.d == '2') {
                    alert("Not Saved already exists !");
                }
                else {
                    alert("Not Saved ! Enter Ur Temp. Name. !");
                }

            }
        });
    });

    $("#btnUpdate").click(function () {
        var templateHtmlSource = $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML
        templateHtmlSource = htmlEncode(templateHtmlSource);
        var requestData = {
            templateId: $("#ddlTemplateNames option:selected").val(),
            templateHtmlSource: templateHtmlSource
        };
        $.ajax({
            type: "POST",
            url: "EXP_MyEditor.aspx/UpdateTemplate",
            data: JSON.stringify(requestData),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                alert(result.d);
            }
        });
    });

    $("#btnDelete").click(function () {
        var requestData = {
            templateId: $("#ddlTemplateNames option:selected").val()
        };
        $.ajax({
            type: "POST",
            url: "EXP_MyEditor.aspx/DeleteTemplate",
            data: JSON.stringify(requestData),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                alert("Template Deleted Successfully.");
                PopulateTemplates();

                $("#btnSave").hide();
                $("#btnUpdate").hide();
                $("#btnClear").show();
                $("#btnDelete").hide();
               // $("#ddlJobNo").prop('disabled', true);
                $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML = "";
            }
        });
    });

});

function replaceSelectionWithHtml(html) {
    var range, html;
    var win = $("#cke_CKEditor1").find("iframe")[0].contentWindow.window,
        doc = $("#cke_CKEditor1").find("iframe")[0].contentWindow.document;
    if (win.getSelection && win.getSelection().getRangeAt) {
        range = win.getSelection().getRangeAt(0);
        range.deleteContents();
        var div = document.createElement("div");
        div.innerHTML = html;
        var frag = document.createDocumentFragment(), child;
        while ((child = div.firstChild)) {
            frag.appendChild(child);
        }
        range.insertNode(frag);
    } else if (doc.selection && doc.selection.createRange) {
        range = doc.selection.createRange();
        range.pasteHTML(html);
    }
}
function setVisibility(id, visibility) {
    document.getElementById(id).style.display = visibility;
}
function setVariableAction() {
    var list = document.getElementById('divVariables').getElementsByTagName('a');
//    document.getElementById('btnVariableClose').addEventListener("click", function () {
//        setVisibility('divVariables', 'none');
//    });
    for (var i = 0; i < list.length; i++) {
        if (list[i].tagName == 'A' && list[i].href!='') {
            list[i].addEventListener("click", function () {
                replaceSelectionWithHtml("<span>{" + this.innerHTML + "}</span>");
            });
        }
    }
    //setVisibility('divVariables', 'inline');
}

function DownloadPDF() {
     

    var pdf = new jsPDF('p', 'pt', 'letter');
    // source can be HTML-formatted string, or a reference
    // to an actual DOM element from which the text will be scraped.
    source = $("#cke_CKEditor1").find("iframe")[0].contentWindow.document.body.innerHTML;
//    alert(source);
//    source = source.replace("style='float:right;height:50%;width:100%;'", "style='height:100%;width:100%;'");
    // we support special element handlers. Register them with jQuery-style 
    // ID selector for either ID or node name. ("#iAmID", "div", "span" etc.)
    // There is no support for any other type of selectors 
    // (class, of compound) at this time.
    specialElementHandlers = {
        // element with id of "bypass" - jQuery style selector
        '#bypassme': function (element, renderer) {
            // true = "handled elsewhere, bypass text extraction"
            return true
        }
    };
    margins = {
        top: 80,
        bottom: 60,
        left: 30,        
        width: 900
    };
    // all coords and widths are in jsPDF instance's declared units
    // 'inches' in this case
    pdf.fromHTML(
    source, // HTML string or DOM elem ref.
    margins.left, // x coord
    margins.top, { // y coord
        'width': margins.width, // max width of content on PDF
        'elementHandlers': specialElementHandlers
    },

    function (dispose) {
        // dispose: object with X, Y of the last line add to the PDF 
        //          this allow the insertion of new lines after html

        pdf.save($("#ddlTemplateNames option:selected").text() + '.pdf');
    }, margins);
}