<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Imp_IEC_Settings.aspx.cs" Inherits="User_Imp_IEC_Settings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>User IEC Access Settings</title>
    
      <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>--%>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
   <%-- <script src="../js/Validation.js" type="text/javascript"></script>--%>
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->

    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });

        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
    </script>
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        /* ---- Importer tick-list : floating dropdown just under txtImporterName ---- */
        #divImpResults
        {
            position: absolute;
            width: 360px;
            border: 1px solid #6aa0e0;
            background: #fff;
            font-size: 11px;
            z-index: 99999;
            box-shadow: 0 3px 8px rgba(0,0,0,.28);
        }
        .imp-res-head
        {
            background: #eef4ff;
            border-bottom: 1px solid #6aa0e0;
            padding: 3px 5px;
            white-space: nowrap;
        }
        .imp-res-head label
        {
            font-weight: bold;
            margin-right: 8px;
        }
        .imp-res-head input
        {
            font-size: 11px;
            padding: 0 6px;
            margin-right: 4px;
            cursor: pointer;
            vertical-align: middle;
        }
        #lblImpResCount
        {
            color: #23527c;
            font-weight: bold;
            font-size: 10px;
        }
        #divImpResultsBody
        {
            max-height: 170px;
            overflow-y: auto;
        }
        .imp-res-row
        {
            display: block;
            padding: 3px 5px;
            border-bottom: 1px solid #eee;
            cursor: pointer;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }
        .imp-res-row:hover
        {
            background: #eaf3ff;
        }
        .imp-res-row input
        {
            vertical-align: middle;
            margin-right: 5px;
        }
        .imp-res-empty
        {
            padding: 6px;
            color: #c0392b;
            font-weight: bold;
        }
    </style>

</head>
<body style="overflow:hidden;">

    <form id="form1" runat="server">
      
      
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" EnablePageMethods="true"   LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="content" id="page-1" style="height:320px;">
            <div id="tag_transac_lft_comp_mas_in1" style="width: 920px">
                    <div id="tag_label_comp_master1" style="width: 40px">
                        Type
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 130px">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="listtxt-s" AutoPostBack="true"
                            TabIndex="4" ClientIDMode="Static" Width="100px" 
                            onselectedindexchanged="ddlType_SelectedIndexChanged" >
                            <asp:ListItem>Import</asp:ListItem>
                            <asp:ListItem>Export</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                
                    <div id="tag_label_comp_master1" style="width: 90px">
                        Select Branch
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:DropDownList ID="ddlGroupname" runat="server" CssClass="listtxt-s" AutoPostBack="true"
                            TabIndex="4" ClientIDMode="Static" Width="100px" OnSelectedIndexChanged="ddlGroupname_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:DropDownList ID="ddlLoad_Branch" runat="server" CssClass="listtxt-s" TabIndex="5"
                            ClientIDMode="Static" Width="125px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width:950px;"></div>
                <div id="tag_transac_lft_comp_mas_in1" style="width: 950px;">
                    <div id="tag_label_transaction_popup_gen" style="width: 100px;">
                      <asp:Label ID="lblClient_Name" runat="server" Text="Importer Name" ></asp:Label></div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 220px; position: relative;">
                        <asp:TextBox ID="txtImporterName" runat="server" MaxLength="50"
                            Font-Bold="true" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                           TabIndex="10" Width="220px" autocomplete="off"></asp:TextBox>
                        <div id="divImpResults" style="display: none;">
                            <div class="imp-res-head">
                                <label>
                                    <input type="checkbox" id="chkImpSelectAll" />
                                    Select All</label>
                                <input type="button" id="btnImpCloseResults" value="Close" />
                                <span id="lblImpResCount"></span>
                            </div>
                            <div id="divImpResultsBody">
                            </div>
                        </div>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                 
                    <div id="tag_label_transaction_popup_gen" style="width: 50px;">
                        IEC_No
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtIECNo" runat="server" MaxLength="10" ClientIDMode="Static" CssClass="validate[required,minSize[10]] txtbox_none_Mid_transac_code"
                            TabIndex="11" onkeypress="return pin(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_gen" style="width: 70px;">
                        Branch_No</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txtBranchNo" runat="server" MaxLength="3" CssClass="validate[required,custom[number]]  txtbox_none_Mid_transac_item_maindet"
                            ClientIDMode="Static" TabIndex="12" onkeypress="return pin(event)"></asp:TextBox>
                    </div>
                </div>
         <div id="tag_transac_lft_comp_mas_in1" style="width:950px;"></div>
                <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height: 190px; width: 630px;
                    overflow: auto;">
                    <asp:GridView ID="gvAll" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID"
                        CssClass="grid-view" EmptyDataText="NO RECORD FOUND" OnRowCreated="gvAll_RowCreated"
                        OnRowDataBound="gvAll_RowDataBound" PageSize="12" ShowFooter="True" ShowHeaderWhenEmpty="True"
                        Width="100%" onselectedindexchanged="gvAll_SelectedIndexChanged">
                        <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                        <Columns>
                         <%--<asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>--%>
                            <asp:BoundField DataField="RowNumber" HeaderText="S.No" ControlStyle-Width="40px" />
                            <asp:BoundField DataField="IEC_NAME" HeaderText="Importer Name" ControlStyle-Width="480px">
                                <ItemStyle CssClass="column_style_left5" Width="480px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IEC_NO" HeaderText="IEC No" ControlStyle-Width="150px">
                                <ItemStyle CssClass="column_style_left5" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BRANCH_NO" HeaderText="BranchNo" ControlStyle-Width="80px">
                                <ItemStyle CssClass="column_style_left5" Width="80px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                    
            <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="19"
                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="17"
                        OnClientClick="return validate_Company();" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" TabIndex="17" OnClientClick="return validate_Company();"
                        OnClick="btnUpdate_Click" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="18" Visible="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'USER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="18" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                        CssClass="dlete" Style="display: none;" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('Company_Page');return false;"
                        TabIndex="19" CausesValidation="false" UseSubmitBehavior="false" />
            </div>

                <asp:HiddenField ID="hdn_Company_ID" runat="server" />
                <asp:HiddenField ID="hdn_User_Creation_Id" runat="server" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdnSelectedImporters" runat="server" ClientIDMode="Static" />

                <script src="../activatables.js" type="text/javascript"></script>
               
               <%-- <script type="text/javascript">
                    activatables('page', ['page-1', 'page-2', 'page-3', 'page-4']);
                </script>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>


  <script type="text/javascript">

        // ================================================================
        //  Multi-select Importer  (written for jQuery 1.4 -> no .on / .prop)
        //  hidden field format : record1||record2||...   record = BRANCH--IEC--NAME
        // ================================================================
        var IMP_SEP = "||";
        var imp_searchTimer = null;

        function imp_getRecords() {
            var raw = $("#hdnSelectedImporters").val();
            return raw ? raw.split(IMP_SEP) : [];
        }

        function imp_setRecords(recs) {
            $("#hdnSelectedImporters").val(recs.join(IMP_SEP));
        }

        function imp_addRecord(val) {
            if (!val || val.indexOf("--") == -1) return;
            var recs = imp_getRecords();
            for (var i = 0; i < recs.length; i++) {
                if (recs[i] == val) { return; }   // already there
            }
            recs.push(val);
            imp_setRecords(recs);
            imp_syncMirrorBoxes();
        }

        function imp_removeRecord(val) {
            var recs = imp_getRecords();
            var out = [];
            for (var i = 0; i < recs.length; i++) {
                if (recs[i] && recs[i] != val) { out.push(recs[i]); }
            }
            imp_setRecords(out);
            imp_syncMirrorBoxes();
        }

        // keep IEC_No / Branch_No boxes filled (ValidationEngine needs them) from the first picked row
        function imp_syncMirrorBoxes() {
            var recs = imp_getRecords();
            if (recs.length > 0) {
                var s = recs[0].split("--");
                if (s.length >= 3) {
                    $('#txtBranchNo').val(s[0]);
                    $('#txtIECNo').val(s[1]);
                    try { jQuery('#txtIECNo').validationEngine('hidePrompt', '', 'error', 'topRight', true); } catch (ex) { }
                    try { jQuery('#txtBranchNo').validationEngine('hidePrompt', '', 'error', 'topRight', true); } catch (ex) { }
                }
            } else {
                $('#txtIECNo').val('');
                $('#txtBranchNo').val('');
            }
        }

        function imp_resultChkHandler() {
            var val = $(this).val();
            if (this.checked) { imp_addRecord(val); }
            else { imp_removeRecord(val); }
        }

        // show the floating list right under the textbox (it lives on <body> so nothing clips it)
        function imp_showResults() {
            var $t = $('#txtImporterName');
            var off = $t.offset();
            if (off) {
                $('#divImpResults').css({
                    top: Math.round(off.top + $t.outerHeight()) + 'px',
                    left: Math.round(off.left) + 'px'
                });
            }
            $('#divImpResults').show();
        }

        // ---- type a name -> show ALL matching rows as a tick list (same name, different branch/iec) ----
        function imp_searchImporters(term) {
            var url = '../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_IEC_NO_SLNO';
            $("#divImpResultsBody").html('<div class="imp-res-empty">Searching...</div>');
            $("#lblImpResCount").text('');
            imp_showResults();
            $.ajax({
                url: url,
                data: "{ 'mail': '" + term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('ddlType').value + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                async: true,
                success: function (data) { imp_renderResults(data.d); },
                error: function () {
                    $("#divImpResultsBody").html('<div class="imp-res-empty">Search failed. Try again.</div>');
                }
            });
        }

        function imp_renderResults(list) {
            var body = $("#divImpResultsBody");
            body.empty();
            var selAll = document.getElementById('chkImpSelectAll');
            if (selAll) selAll.checked = false;
            imp_showResults();

            if (!list || list.length == 0) {
                body.html('<div class="imp-res-empty">No Importer Found</div>');
                $("#lblImpResCount").text('');
                return;
            }

            var already = imp_getRecords();
            var shown = 0;
            for (var i = 0; i < list.length; i++) {
                var val = list[i];
                if (!val || val.indexOf("--") == -1) continue;
                var p = val.split("--");
                var branch = p[0], iec = p[1], name = p.slice(2).join("--");
                var isAdded = ($.inArray(val, already) != -1);

                var row = $('<label class="imp-res-row"></label>');
                var chk = $('<input type="checkbox" class="imp-res-chk" />');
                chk.val(val);
                chk[0].checked = isAdded;
                chk.click(imp_resultChkHandler);
                row.append(chk);
                row.append(document.createTextNode(
                    ' ' + name + '   |   IEC: ' + iec + '   |   Branch: ' + branch
                ));
                body.append(row);
                shown++;
            }
            $("#lblImpResCount").text(shown + ' found');
        }

        function imp_closeResults() {
            $("#divImpResults").hide();
            $("#divImpResultsBody").empty();
            var selAll = document.getElementById('chkImpSelectAll');
            if (selAll) selAll.checked = false;
            $('#txtImporterName').val('');
        }

        $(document).ready(function () {

            // move the floating list onto <body> so no parent container can clip it
            $('#divImpResults').appendTo(document.body);

            $('#txtImporterName').keyup(function (e) {
                var k = e.which || e.keyCode;
                if (k == 9 || k == 16 || k == 17 || k == 18) return; // tab / shift / ctrl / alt
                if (k == 27) { imp_closeResults(); return; }          // Esc closes
                var term = $.trim($(this).val());
                if (imp_searchTimer) { clearTimeout(imp_searchTimer); }
                if (term.length < 1) { $("#divImpResults").hide(); return; }
                imp_searchTimer = setTimeout(function () { imp_searchImporters(term); }, 300);
            });

            // click anywhere outside the box / list -> close it
            $(document).click(function (e) {
                var t = e.target;
                if (t.id == 'txtImporterName') return;
                if ($(t).closest('#divImpResults').length) return;
                $("#divImpResults").hide();
            });

            // Select All -> tick / untick every visible row (each tick updates the hidden field)
            $("#chkImpSelectAll").click(function () {
                var c = this.checked;
                $("#divImpResultsBody input.imp-res-chk").each(function () {
                    this.checked = c;
                    var val = $(this).val();
                    if (c) { imp_addRecord(val); } else { imp_removeRecord(val); }
                });
            });

            $("#btnImpCloseResults").click(function () { imp_closeResults(); return false; });
        });

</script>

 <script type="text/javascript">
     $(document).ready(function () {

         $('#txtImporterName').focus(function () {

             var data = $(this).val();
             Item_desc(data);

         });
         $('#txtImporterName').change(function () {

             var data = $(this).val();
             Item_desc(data);

         });
         $('#txtImporterName').keyup(function () {

             var data = $(this).val();
             Item_desc(data);

         });
         $('#txtImporterName').keydown(function () {

             var data = $(this).val();
             Item_desc(data);

         });

     });

     function Item_desc(val) {

         var data = val;
         if (data == '') {
             $('#txtImporterName').val('');
         }
         if (data.indexOf("--") != -1) {

             var s = data.split('--');

             var branch = s[0];
             var iecno = s[1];
             var imp_name = s[2];

             $('#txtImporterName').val(imp_name);
             $('#txtIECNo').val(iecno);
             $('#txtBranchNo').val(branch);
         }
         else {

         }
     }
  </script>
  <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>


</body>
</html>
