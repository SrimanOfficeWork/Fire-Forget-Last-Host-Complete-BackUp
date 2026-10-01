<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Multiple_Inv_Split_Export.aspx.cs"
    Inherits="Multiple_Inv_Split_Export" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Split Multiple Invoice - Export</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <script src="../Validation Files/jquery.validationEngine.js" type="text/javascript"></script>
    <script src="../Validation Files/languages/jquery.validationEngine-en.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

    <style type="text/css">
        .datagrid table { border-collapse: collapse; text-align: left; width: 100%; }
        .datagrid { font: normal 12px/150% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden;
            border: 1px solid #8C8C8C; border-radius: 3px; }
        .datagrid table td, .datagrid table th { padding: 3px 10px; }
        .datagrid table thead th {
            background-color: #FFF3CD !important;
            color: #333333 !important;
            font-size: 13px !important;
            font-weight: bold !important;
            text-decoration: none !important;
            border-left: 1px solid #E0C36B;
            padding: 4px 6px;
        }
        .datagrid table thead th a,
        .datagrid table thead th a:link,
        .datagrid table thead th a:visited {
            color: #333333 !important;
            text-decoration: none !important;
        }
        .datagrid table tbody td { border-left: 1px solid #DBDBDB; font-size: 12px; font-weight: normal; }
        .datagrid table tbody .alt td { background: #EBEBEB; color: #7D7D7D; }
        div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }
        #pop_text_area_transac_popup_inn_container_export thead th {
                background-color: #D9EDF7;
                color: #31708F;
                font-weight: bold;
                text-decoration: none;
                border-left: 1px solid #E0C36B;
            }

        /* ---- Hide the server-side helper columns (defined locally so it works
                even when ../gridmain.css does not load) ---- */
        .hideGridColumn { display: none !important; }

        /* ---- Keep header table and the GridView column widths in lock-step ---- */
        #pop_text_area_transac_popup_inn_container_export table,
        #gv_Details { table-layout: fixed; width: 760px; border-collapse: collapse; }
        #pop_text_area_transac_popup_inn_container_export table th { padding: 3px 4px; font-size: 12px; }
        #gv_Details td { padding: 3px 4px; font-size: 12px; overflow: hidden; white-space: nowrap; }

        /* explicit per-column widths shared by header row and data row (must total 760px of visible cols) */
        .col_slno  { width: 40px;  text-align:center; }
        .col_terms { width: 60px; }
        .col_invc  { width: 50px; }
        .col_invv  { width: 90px;  text-align:right; }
        .col_frtc  { width: 55px; }
        .col_frta  { width: 90px; }
        .col_insar { width: 60px; }
        .col_insc  { width: 55px; }
        .col_insr  { width: 70px; }
        .col_insa  { width: 90px; }

        
        .frt_ins_row { white-space: nowrap; margin-bottom: 5px; height: 24px; }
        .frt_ins_row > div { display: inline-block; vertical-align: middle; white-space: nowrap; }
        .frt_ins_row .lbl { font-weight: bold; }

       
        .fld_label  { width: 52px; }
        .fld_armode { width: 60px; }   
        .fld_amt    { width: 112px; }
        .fld_curlbl { width: 32px; text-align: right; padding-right: 4px; }
        .fld_cur    { width: 56px; }
        .fld_exlbl  { width: 42px; text-align: right; padding-right: 4px; }
        .fld_ex     { width: 66px; }
    </style>
</head>
        <body style="overflow: hidden;">
            <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
                LoadScriptsBeforeUI="false" EnablePageMethods="true">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
                <ContentTemplate>
                    <div class="loading" align="center" id="load" style="display: none;">
                        <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
                    </div>

                    <div id="tag_transact_src_inner" style="width: 760px;">
                        <div id="tag_transac_lft_Inv_in1" style="width: 760px; position: relative;">

                    <%-- ===================== Tot.FRT ===================== --%>
                    <div class="frt_ins_row">
                        <div class="lbl fld_label" id="lbl_TotFRT" runat="server">Tot.FRT</div>
                        <div class="fld_armode">
                            <asp:DropDownList ID="ddl_FRT_AMT_RATE" runat="server" BackColor="LightBlue" ClientIDMode="Static" Enabled="false" Width="56px">
                                <asp:ListItem>Amt</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fld_amt">
                            <asp:TextBox ID="txt_tot_Freight_Chrg" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" MaxLength="17" TabIndex="1" onblur="extractNumber(this,4,false);"
                                onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" Width="105px"></asp:TextBox>
                        </div>
                        <div class="fld_curlbl">Curr.</div>
                        <div class="fld_cur">
                            <asp:TextBox ID="txtFRT_Currency" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="2" onkeypress="return char1(event)" onblur="return ChangeCase(this); ValidateCurr(this,'Freight');"
                                Width="50px" onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>
                        </div>
                        <div class="fld_exlbl">Ex.Rt.</div>
                        <div class="fld_ex">
                            <asp:TextBox ID="txtFRT_ExRate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="3" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" Width="60px"></asp:TextBox>
                        </div>
                    </div>

                    <%-- ===================== Tot.INS (Amt/Rate) ===================== --%>
                    <div class="frt_ins_row">
                       <div class="lbl fld_label" id="lbl_TotINS" runat="server">Tot.INS</div>
                        <div class="fld_armode">
                            <asp:DropDownList ID="ddl_INS_AMT_RATE" runat="server" BackColor="LightBlue" ClientIDMode="Static" TabIndex="4" Width="56px">
                                <asp:ListItem>Amt</asp:ListItem>
                                <asp:ListItem>Rate</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fld_amt">
                            <asp:TextBox ID="txt_tot_Ins_Chrg" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" MaxLength="17" TabIndex="5" onblur="extractNumber(this,4,false);"
                                onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" Width="105px"></asp:TextBox>
                        </div>
                        <div class="fld_curlbl">Curr.</div>
                        <div class="fld_cur">
                            <asp:TextBox ID="txtIns_Currency" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="6" onkeypress="return char1(event)" onblur="return ChangeCase(this); ValidateCurr(this,'Insurance');"
                                Width="50px" onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>
                        </div>
                        <div class="fld_exlbl">Ex.Rt.</div>
                        <div class="fld_ex">
                            <asp:TextBox ID="txtINS_ExRate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="7" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" Width="60px"></asp:TextBox>
                        </div>
                    </div>

                    <%-- ===================== Tot.Inv (read-only, top-right) ===================== --%>
                   <div class="frt_ins_row" style="position: absolute; top: 0; left: 470px; width: 280px;">
                        <div class="lbl fld_label" style="width:75px;">Tot.Inv.Val</div>
                        <div class="fld_amt" style="width:120px;">
                            <asp:TextBox ID="txt_tot_inv_amt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" Enabled="false" MaxLength="17" Width="105px"
                                style="background-color:#e3f2fd; border:1px solid #999; color:#000;"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <%-- ===================== Static header bar (visual only) ===================== --%>
            <div id="pop_text_area_transac_popup_inn_container_export" style="height: 42px; width: 760px; margin-top: 4px; overflow: hidden;">
                <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: hidden; width: 760px;">
                    <table class="datagrid" style="width:100%;">
                        <thead>
                            <tr>
                                <th class="col_slno">SlNo</th>
                                <th class="col_terms">Terms</th>
                                <th class="col_invc">Inv.Cur</th>
                                <th class="col_invv">Inv.Value</th>
                                <th class="col_frtc">Frt.Curr</th>
                                <th class="col_frta">Frt.Amt</th>
                                <th class="col_insar">Ins.A/R</th>
                                <th class="col_insc">Ins.Cur</th>
                                <th class="col_insr">Ins.Rate</th>
                                <th class="col_insa">Ins.Amt</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>

            <%-- ===================== Detail grid (one row per invoice) ===================== --%>
            <div id="pop_text_area_transac_popup_inn_container_export" style="height: 230px; width: 760px; margin-top: -4px; overflow: hidden;">
                <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow-x: hidden; overflow-y: auto; height: 220px; width: 760px;">
                    <asp:GridView ID="gv_Details" runat="server" ClientIDMode="Static" AllowSorting="True" EmptyDataText="No Record Found"
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                        ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                        AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                        OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                        ShowHeader="false" DataKeyNames="INVOICE_SLNO">
                        <RowStyle BorderWidth="0.1em" BorderColor="black" />
                        <Columns>
                            <asp:BoundField DataField="INVOICE_SLNO" HeaderText="SlNo" HeaderStyle-Width="40px">
                                <ItemStyle CssClass="col_slno" />
                            </asp:BoundField>

                            <%-- TERMS - drives which Freight/Insurance fields are enabled below --%>
                            <asp:TemplateField HeaderText="Terms" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl_Inv_Terms" runat="server" SelectedValue='<%# Eval("TERMS") %>'
                                        Width="50px" Font-Size="12px" AutoPostBack="true" OnSelectedIndexChanged="ddl_Inv_Terms_SelectedIndexChanged">
                                        <asp:ListItem>FOB</asp:ListItem>
                                        <asp:ListItem>CI</asp:ListItem>
                                        <asp:ListItem>CF</asp:ListItem>
                                        <asp:ListItem>CIF</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle CssClass="col_terms" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Inv.Curr" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Invoice_Curr" runat="server" Text='<%# Bind("INVOICE_CURRENCY") %>' Width="40px" Font-Bold="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="col_invc" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="INVOICE_VALUE" HeaderText="Inv.Value" HeaderStyle-Width="80px">
                                <ItemStyle CssClass="col_invv" />
                            </asp:BoundField>

                            <%-- FREIGHT - enabled only for CIF / CF --%>
                            <asp:TemplateField HeaderText="Frt.Curr" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Freight_Curr" runat="server" Text='<%# Bind("FREIGHT_CURRENCY") %>' Width="40px" ForeColor="Red" Font-Bold="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="col_frtc" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Frt.Amt" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Frt_Amt" runat="server" Text='<%# Bind("FREIGHT_CHARGES") %>'
                                        Width="75px" ForeColor="Red" Font-Bold="true" onblur="extractNumber(this,2,false);"
                                        onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="col_frta" />
                            </asp:TemplateField>

                            <%-- INSURANCE - enabled only for CIF / CI --%>
                            <asp:TemplateField HeaderText="Ins.A/R" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl_Ins_A_R" runat="server"
                                        Width="50px" Font-Size="12px" ForeColor="Green" Font-Bold="true">
                                        <asp:ListItem>Amt</asp:ListItem>
                                        <asp:ListItem>Rate</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle CssClass="col_insar" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ins.Curr" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Insurance_Curr" runat="server" Text='<%# Bind("INSURANCE_CURRENCY") %>' Width="40px" ForeColor="Green" Font-Bold="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="col_insc" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ins.Rate" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ins_Rate" runat="server" Text='<%# Bind("INSURANCE_RATE") %>'
                                        Width="55px" ForeColor="Green" Font-Bold="true" onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="col_insr" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ins.Amt" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ins_Amt" runat="server" Text='<%# Bind("INSURANCE_CHARGES") %>'
                                        Width="75px" ForeColor="Green" Font-Bold="true" onblur="extractNumber(this,2,false);"
                                        onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="col_insa" />
                            </asp:TemplateField>

                            <%-- hidden helper columns needed server-side for the split calculation --%>
                            <asp:BoundField DataField="BRANCH_CODE" HeaderText="" HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EXCHANGE_RATE" HeaderText="" HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FREIGHT_EXRATE" HeaderText="" HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INSURANCE_EXRATE" HeaderText="" HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 30px; margin-left: 10px; margin-top: 6px;">
                <asp:Button ID="btnupdate" runat="server" CssClass="autowidmovebut" Text="Convert to Update"
                    OnClick="btnupdate_Click" OnClientClick="return validate_Invoice();" TabIndex="9" Width="200px" />
            </div>

            <asp:HiddenField ID="hdn_valid" runat="server" />
            <asp:HiddenField ID="hdn_FRT_Cur" runat="server" />
            <asp:HiddenField ID="hdn_FRT_Exrt" runat="server" />
            <asp:HiddenField ID="hdn_INS_Cur" runat="server" />
            <asp:HiddenField ID="hdn_INS_Exrt" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>

    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>

    <script type="text/javascript">
        window.onload = function () {
            try {
                window.resizeTo(800, 470);
                window.moveTo((screen.width - 800) / 2, (screen.height - 470) / 2);
            } catch (e) { }
        };
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function () { jQuery("#form1").validationEngine(); });

        function validate_Invoice() {
            document.getElementById("hdn_valid").value = "";

            var tot_Freight_Chrg = document.getElementById("txt_tot_Freight_Chrg").value;
            var FRT_Currency = document.getElementById("txtFRT_Currency").value;
            var FRT_ExRate = document.getElementById("txtFRT_ExRate").value;

            if (tot_Freight_Chrg != '') {
                if (FRT_Currency == '') { document.getElementById("hdn_FRT_Cur").value = "err_FRT_Curr"; document.getElementById("hdn_valid").value = "err"; }
                else { document.getElementById("hdn_FRT_Cur").value = ""; }
                if (FRT_ExRate == '') { document.getElementById("hdn_FRT_Exrt").value = "err_FRT_Exrate"; document.getElementById("hdn_valid").value = "err"; }
                else { document.getElementById("hdn_FRT_Exrt").value = ""; }
            }

            var tot_Ins_Chrg = document.getElementById("txt_tot_Ins_Chrg").value;
            var Ins_Currency = document.getElementById("txtIns_Currency").value;
            var INS_ExRate = document.getElementById("txtINS_ExRate").value;

            if (tot_Ins_Chrg != '') {
                if (Ins_Currency == '') { document.getElementById("hdn_INS_Cur").value = "err_Ins_Curr"; document.getElementById("hdn_valid").value = "err"; }
                else { document.getElementById("hdn_INS_Cur").value = ""; }
                if (INS_ExRate == '') { document.getElementById("hdn_INS_Exrt").value = "err_Ins_Exrate"; document.getElementById("hdn_valid").value = "err"; }
                else { document.getElementById("hdn_INS_Exrt").value = ""; }
            }

            if (document.getElementById("hdn_valid").value == "err") {
                $(document).ready(function () { jAlert('Please fill the Currency / Exchange rate for the amount you entered.', 'Multi Split'); });
                return false;
            }
            return true;
        }

        function ValidateCurr(ctrl, label) {
            var val = ctrl.value.trim().toUpperCase();
            if (val === '') return;

            var invCurr = '';
            var tbl = document.getElementById('gv_Details');
            if (tbl) {
                var rows = tbl.getElementsByTagName('tr');
                for (var i = 0; i < rows.length; i++) {
                    var cells = rows[i].getElementsByTagName('td');
                    if (cells.length > 2) {
                        invCurr = cells[2].innerText.trim().toUpperCase();
                        break;
                    }
                }
            }

            if (val !== 'INR' && val !== invCurr) {
                jAlert('Only Invoice Currency (' + invCurr + ') or INR is allowed for ' + label + ' Currency.', 'Multi Split');
                ctrl.value = '';
            }
        }
    </script>

    <script type="text/javascript">

        $(function () {
            $("#txtFRT_Currency,#txtIns_Currency").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exchage_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json", type: "POST", contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; }, async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txtFRT_Currency') { jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Freight Currency', 'error', 'bottomRight', true); }
                                if (field == 'txtIns_Currency') { jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Insurance Currency', 'error', 'topRight', true); }
                            } else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function () { }
                    });
                },
                minLength: 1
            });
            });
       
        function Call_Excahnge_Rate(src, dest) {
            var ctrl = document.getElementById(src);
            var ieccode = ctrl.value;
            if (ieccode.length == 3) {
                PageMethods.GetExchange_Rate(ctrl.value, CallSuccess, CallFailed, dest);
            }
        }
        function CallSuccess(res, destCtrl) {
            if (res != null && res.length != 0) {
                if (destCtrl == 'txtFRT_ExRate') { $('#txtFRT_ExRate').val(res); }
                if (destCtrl == 'txtINS_ExRate') { $('#txtINS_ExRate').val(res); }
            }
        }
        function CallFailed(error) { }
    </script>

</body>
</html>
