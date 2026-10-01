<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice_Details.aspx.cs"
    Inherits="Export_Invoice_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>IGM | Transaction</title>
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script type="text/javascript">
        function check_Currency() {

            document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'Block';

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'Block';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("INVOICE_ID").className = 'inactive';
            document.getElementById("FRIEGHT_ID").className = 'active';

        }
    </script>
    <%--  <script type="text/javascript">
         $(document).ready(function () {

             // document.onkeydown = clickRadio;
             document.onkeypress = click_TABS;
             document.onkeyup = click_TABS;

             function click_TABS(e) {
                 //if (window.event);
                 if (window.event.ctrlKey)
                     var keyCode = window.event.keyCode;       // IE
                 else
                     var keyCode = e.which;

                 if (e.ctrlKey) {
                     if (keyCode == 39) {

                         document.getElementById("hdn_source").value = 'Tab_Invoice';
                         document.getElementById('btnCancel').click();
                     }
                     if (keyCode == 37) {

                         document.getElementById("hdn_source").value = 'Tab_Invoice_Prev';
                         document.getElementById('btnCancel').click();
                     }
                 }
             }
         });
    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            // document.onkeydown = clickRadio;
            document.onkeypress = click_TABS;
            document.onkeyup = click_TABS;

            function click_TABS(e) {
                //if (window.event);
                if (window.event.ctrlKey)
                    var keyCode = window.event.keyCode;       // IE

                else
                    var keyCode = e.which;
                var cnt = 0;

                //alert(e.ctrlKey);
                if (e.ctrlKey) {
                    if (keyCode == 39) {
                        //document.getElementById("hdn_source").value = 'Tab_Invoice';

                        if (document.getElementById("hdn_Inner_tab_Menu").value == '') {
                            document.getElementById("hdn_Inner_tab_Menu").value = 'INVOICE_ID';
                            cnt = cnt + 1;
                        }
                        else {
                            cnt = cnt + 1;
                        }

                        //alert(cnt + 'CNT');
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'INVOICE_ID') {
                            if (cnt == 1) {
                                document.getElementById('FRIEGHT_ID').click();
                                cnt = cnt + 1;
                                //alert(cnt + 'IMD');
                            }
                        }
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'FRIEGHT_ID') {
                            if (cnt == 1) {
                                document.getElementById('Third_Party').click();
                                cnt = cnt + 1;
                            }
                        }

                    }

                    if (keyCode == 37) {

                        cnt = cnt + 1;

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'INVOICE_ID') {
                            if (cnt == 1) {
                                document.getElementById("hdn_source").value = 'Tab_Invoice_Prev';
                                document.getElementById('btnCancel').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'Third_Party') {
                            if (cnt == 1) {
                                document.getElementById('FRIEGHT_ID').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'FRIEGHT_ID') {
                            if (cnt == 1) {
                                document.getElementById('INVOICE_ID').click();
                                cnt = cnt + 1;
                            }
                        }

                    }
                }
            }
        });
    </script>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        
        
        .hideGridColumn1
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        
        .grid-view tr.header
        {
            border: solid 1px Black;
        }
    </style>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
</head>
<body bgcolor="#FFFFFF">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Trans_IGM_Invoice">
                <ol id="toc">
                    <li><a href="#page-1" id="INVOICE_ID" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');">
                        <span>Invoice Main Details</span></a></li>
                    <li><a href="#page-2" id="FRIEGHT_ID" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2('0');">
                        <span>Freight & Insurance Details</span></a></li>
                    <%--<li id="Third_Party"  runat="server"><a href="#page-4" onclick="tab_page4('0');">
                        <span>Third Party Details(SW)</span></a></li>--%>
                    <li><a href="#page-4" id="Third_Party" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4('0');">
                        <span>Third Party Details(SW)</span></a></li>
                    <li id="AR4_Details" visible="false" runat="server"><a href="#page-3" onclick="tab_page3('0');">
                        <span>AR4 Details</span></a></li>
                    <li id="DTA_Invoice" visible="false" runat="server"><a href="#page-5" onclick="tab_page5('0');">
                        <span>DTA Invoice</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_exp_popup_inn_container_left_invoice" style="width: 718px;">
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 715px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                GST Invoice No
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="1" MaxLength="16"></asp:TextBox>
                            </div>
                            <div id="magnify_area" style="width: 15px;">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 53px; padding-left: 60px;">
                                Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInvoiceDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="2"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtInvoiceDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtInvoiceDate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>                              
                            <div id="magnify_area" style="width: 32px;">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice">
                                Payment Method
                            </div>
                            <div id="txtcon-m_transaction_list1_fcl">
                                <asp:DropDownList ID="ddlPaymentMethod" CssClass="validate[required] listtxt_transac_FCL"
                                    runat="server" TabIndex="3">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>AP</asp:ListItem>
                                    <asp:ListItem>LC</asp:ListItem>
                                    <asp:ListItem>DP</asp:ListItem>
                                    <asp:ListItem>DA</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 715px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Invoice Value
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInvoiceValue" runat="server" MaxLength="12" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="4"></asp:TextBox>
                            </div>
                            <div id="magnify_area" style="width: 15px;">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 113px;">
                                Invoice Currency
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInvoiceCurrency" runat="server" ClientIDMode="Static" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                    onkeypress="return char1(event)" onblur="return ChangeCase(this);" MaxLength="3"
                                    TabIndex="5"></asp:TextBox>
                            </div>
                            <div id="magnify_area" style="width: 32px;">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('ExportInvoiceCurrency'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice">
                                Ex. Rate
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 90px">
                                <asp:TextBox ID="txtExchangeRate" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="6" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" Width="90px"></asp:TextBox>
                            </div>
                            <div id="magnify_area" style="width: 0px;">
                                <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Ex.Rate Update- All Invoices"
                                    ImageUrl="~/images/icons/index.jpg" runat="server" OnClientClick="jQuery('#form1').validationEngine('hide');open_Bulk_Export_Exrate_Update_Inv(); return false;" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 715px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Terms
                            </div>
                            <div id="txtcon-m_transaction_list1_fcl">
                                <asp:DropDownList ID="ddlTerms" runat="server" CssClass="validate[required] listtxt_transac_FCL"
                                    TabIndex="7"  onchange="mapDropdowns(this);">
                                    <asp:ListItem>FOB</asp:ListItem>
                                    <asp:ListItem>CIF</asp:ListItem>
                                    <asp:ListItem>CI</asp:ListItem>
                                    <asp:ListItem>CF</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice_large" style="width: 220px">
                                Whether Consignee and Buyer Same
                            </div>
                            <div id="txtcon-m_transaction_list1_fcl">
                                <asp:DropDownList ID="ddlBuyer" runat="server" CssClass="listtxt_transac_FCL" TabIndex="8">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="magnify_area" style="width: 35px;">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice">
                                Period Of Payment
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtPeriodOfPayment" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="9" MaxLength="3" onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 760px;" display:flex; align-items:center; gap:6px; flex-wrap:nowrap;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Buyer Name
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large" style="width: 149px;">
                                <asp:TextBox ID="txtBuyerName" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_IGM_Air_namenew"
                                    style="width: 149px;" MaxLength="40" TabIndex="10" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div id="magnify_area" style="width: 27px;">
                            <div id="dv_mas_buyer_popup" runat="server">
                                <a class="magnfy" href="#" runat="server" id="href_Buyer_YN" 
                                            style="width: 27px;" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupBuyer('BUYER'); return false">
                                </a>
                                 </div>
                            </div>
                            <div id="magnify_area" style="width: 29px;">
                                <asp:ImageButton ID="btn_BuyerMasedit" Height="26px" Width="27px" ToolTip="Buyer Edit" ClientIDMode="Static"
                                    ImageUrl="~/images/icons/jobedit_master.png" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopupBuyer_JOB_Edit(document.getElementById('txtBuyerName').value,document.getElementById('ddlBuyer').value,'Job'); return false" />
                                <%--<input type="image" runat="server" style="height: 20px; width: 20px;" id="btn_BuyerMasterEdit"
                                    src="~/images/icons/jobedit_master.png" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupBuyer_JOB_Edit(document.getElementById('txtBuyerName').value,'Job'); return false" />
                              --%>
                            </div>
                            <%--<div id="div_masedit" runat="server"  style="width: 25px;">
                             <asp:ImageButton ID="btn_BuyerMasedit" Height="26px" Width="30px" ToolTip="Buyer Edit" ClientIDMode="Static"
                                    ImageUrl="~/images/icons/jobedit_master.png" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopupBuyer_JOB_Edit(document.getElementById('txtBuyerName').value,'Job'); return false" />
                            </div>--%>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 89px;">
                                Contract No
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtContractNo" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    style="width: 89px;" MaxLength="30" TabIndex="11"></asp:TextBox>
                            </div>
                            <asp:Panel ID="pnl_ContractDate" runat="server" Visible="false">
                                <div id="tag_label_transaction_popup_export_invoice" style="margin-left: 8px; width: 89px;">
                                    Contract Date
                                </div>
                                <div id="txtcon-m_transaction_code" >
                                    <asp:TextBox ID="txtContractDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        style="width: 89px;" MaxLength="10"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtContractDate"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtContractDate"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </div>
                            </asp:Panel>
                        </div>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 715px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                            </div>
                            <div id="txtcon-m_transaction_exp_invoice_address">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    MaxLength="100" TabIndex="12" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_exp_invoice_address">
                                <asp:TextBox ID="txtAddress1" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    MaxLength="100" TabIndex="13" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_exp_invoice_address">
                                <asp:TextBox ID="txtAddress2" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    MaxLength="100" TabIndex="14" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 715px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                            </div>
                            <div id="txtcon-m_transaction_exp_invoice_address">
                                <asp:TextBox ID="txtAddress3" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    MaxLength="100" TabIndex="15" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_exp_invoice_address">
                                <asp:TextBox ID="txtAddress4" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    ReadOnly="true" MaxLength="100" TabIndex="16" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="div_AmendmentType" visible="false" runat="server">
                                <div id="tag_label_transaction_popup_gen" style="width: 135px; font-weight: bold;">
                                    Amendment Type
                                </div>
                                <div id="txtcon-m_transaction_item_maindet" style="width: 120px">
                                    <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                        Width="120px">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="A">AMENDMENT</asp:ListItem>
                                        <asp:ListItem Value="S">SUPPLEMENT</asp:ListItem>
                                        <asp:ListItem Value="D">DELETE</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Export_Invoice_Grid_area" style="overflow: hidden;
                            height: 141px;">
                            <asp:GridView ID="gv_Invoice" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                CssClass="grid-view" AllowSorting="True" OnPageIndexChanging="gv_Invoice_PageIndexChanging"
                                HorizontalAlign="Left" OnRowDataBound="gv_Invoice_RowDataBound" OnSelectedIndexChanged="gv_Invoice_SelectedIndexChanged"
                                DataKeyNames="INVOICE_ID" ShowHeaderWhenEmpty="true" Width="100%" BackColor="White"
                                BorderColor="#C8C8C8" BorderStyle="none" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                OnRowCreated="gvdetails_RowCreated">
                                <%--  <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />--%>
                                <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                <SelectedRowStyle Font-Bold="true" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFullName" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                            <itemstyle cssclass="column_style_left5" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="INVOICE_SLNO" HeaderText="S.No">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_NO" HeaderText="Invoice No" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="column_style_left5_new" Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_DATE" HeaderText="Invoice Date" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="column_style_left5_new" Width="70px" />
                                    </asp:BoundField>
                                    <%--  <asp:BoundField DataField="PAYMENT_METHOD" HeaderText="Payment Method" />
                            <asp:BoundField DataField="PERIOD_PAYMENT" HeaderText="Period Payment" />--%>
                                    <asp:BoundField DataField="INVOICE_VALUE" HeaderText="Invoice Value" HeaderStyle-Width="90px">
                                        <ItemStyle CssClass="column_style_right_new" Width="90px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="Currency" HeaderStyle-Width="70px">
                                        <ItemStyle CssClass="column_style_left5_new" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EXCHANGE_RATE" HeaderText="Exch-Rate" HeaderStyle-Width="70px">
                                        <ItemStyle CssClass="column_style_right_new" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CONTRACT_NO" HeaderText="Contract No">
                                        <ItemStyle CssClass="column_style_left5_new" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TERMS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BUYER">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BUYER_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BUYER_ADDRESS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BUYER_ADDRESS1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BUYER_ADDRESS2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BUYER_ADDRESS3">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BUYER_ADDRESS4">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="COMMISSION_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="COMMISSION_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="COMMISSION_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FOB_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FOB_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FOB_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PACKMISC_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PACKMISC_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PACKMISC_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_DEDUCTION_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_DEDUCTION_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_DEDUCTION_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FREIGHT_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FREIGHT_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FREIGHT_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INSURANCE_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INSURANCE_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INSURANCE_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="WHEATHER_UNIT_PRICE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PAYMENT_METHOD">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PERIOD_PAYMENT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FREIGHT_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INSURANCE_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkmodify" runat="server" CommandName="Select" PostBackUrl='<%#"~/Export/Item_Details.aspx?INVOICE_SLNO_ID="+Eval("INVOICE_SLNO") %>'
                                                OnClientClick="jQuery('#form1').validationEngine('hideAll');Product_Open_button_Export();">Item</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="column_style_left_new" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NON_STD_EFFECT_DT_EXP">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NON_STD_BANKNAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NON_STD_CERTIFICATE_NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NON_STD_CERTIFICATE_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_ID" HeaderText="">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TERMS_PLACE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="THIRDPARTY_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="THIRDPARTY_ADD1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="THIRDPARTY_ADD2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="THIRDPARTY_CITY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="T_PARTY_COUNTRY_SUB_DIV">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="T_PARTY_COUNTRY_CODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="T_PARTY_PIN">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AUTHORIZED_ECONOMIC_OPERATOR_CODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="A_E_O_COUNTRY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AUTHORIZED_ECONOMIC_OPERATOR">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DOC_RECD_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AMENDMENT_TYPE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CONTRACT_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NOTIFY_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NOTIFY_ADDRESS_1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NOTIFY_ADDRESS_2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NOTIFY_ADDRESS_3">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NOTIFY_ADDRESS_COUNTRY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle CssClass="pager" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_left_export_frieght">
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_trans_export_Supp">
                            </div>
                            <div id="pop_text_area_transac_export_InnTitle1">
                                Rate %
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Amount</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Currency</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_trans_export_Supp">
                                Commission</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtCommission_Rate" runat="server" MaxLength="8" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="this.value=Comma(this.value);extractNumber(this,5,false);return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,5,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    value="0.00" TabIndex="17"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtCommission_Charges" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="17"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtCommission_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                    TabIndex="18"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Commission'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_trans_export_Supp">
                                FOB Disc
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtFOBDisc_Rate" runat="server" MaxLength="8" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="this.value=Comma(this.value);extractNumber(this,5,false);return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,5,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    value="0.00" TabIndex="19"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtFOBDisc_Charges" runat="server" MaxLength="12" CssClass=" validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="20"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtFOBDisc_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                    TabIndex="21"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('FOBDisc'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_trans_export_Supp">
                                Pack &amp; MISC
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtPackMisc_Rate" runat="server" MaxLength="8" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="this.value=Comma(this.value);extractNumber(this,5,false);return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,5,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    value="0.00" TabIndex="22"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtPackMisc_Charges" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="23"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtPackMisc_Currency" runat="server" MaxLength="12" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                    TabIndex="24"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('PackMisc'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_trans_export_Supp">
                                Other Deductions
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtOtherDeductions_Rate" runat="server" MaxLength="8" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="this.value=Comma(this.value);extractNumber(this,5,false);return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,5,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    value="0.00" TabIndex="25"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtOtherDeductions_Charges" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="26"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtOtherDeductions_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                    TabIndex="27"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('OtherDeductions'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_trans_export_Supp">
                                Freight</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtFreight_Rate" runat="server" MaxLength="8" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="this.value=Comma(this.value);extractNumber(this,5,false);return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,5,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    value="0.00" Enabled="false" TabIndex="28"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtFreight_Charges" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" Enabled="false"
                                    TabIndex="29"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtFreight_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                    Enabled="false" TabIndex="30"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <%-- <a href="#" onclick="OpenPopupExchange('Export_Freight'); return false" class="magnfy" id="img_btn_Frieght">--%>
                                <asp:LinkButton ID="img_btn_Frieght" runat="server" CssClass="magnfy" Enabled="false"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange_Master_Frieght('Export_Freight'); return false"></asp:LinkButton>
                                </a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_trans_export_Supp">
                                Insurance</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInsurance_Rate" runat="server" MaxLength="8" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="this.value=Comma(this.value);extractNumber(this,5,false);return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,5,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    value="0.00" Enabled="false" TabIndex="31"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInsurance_Charges" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" Enabled="false"
                                    TabIndex="32"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInsurance_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                    Enabled="false" TabIndex="33"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <%--   <a href="#" onclick="OpenPopupExchange('Export_Insurance'); return false" class="magnfy" id="img_btn_Insurance">--%>
                                <asp:LinkButton ID="img_btn_Insurance" runat="server" CssClass="magnfy" Enabled="false"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange_Master_Insurance('Export_Insurance'); return false"></asp:LinkButton>
                                </a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_trans_export_supp_large">
                                Whether the Unit Price Includes
                            </div>
                            <div id="txtcon-m_transaction_list1_fcl">
                                <asp:DropDownList ID="ddlWhether" runat="server" CssClass="listtxt_transac_FCL" TabIndex="34">
                                    <asp:ListItem>N</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>I</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                <asp:Label ID="lbl_DocRecd_Date" runat="server" Text="Doc.Recd.Date"></asp:Label>
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_DocRecd_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="77"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt_DocRecd_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_DocRecd_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-3" style="display: none; height: 272px;">
                    <div id="pop_exp_item_licen_main_new1" style="height: 288px; margin-top: -30px;">
                        <iframe src="" name="trans_item_reimport" scrolling="no" id="Trans_product_reimport_iframe"
                            style="height: 530px;"></iframe>
                    </div>
                </div>
                <div class="content" id="page-5" style="display: none; height: 272px;">
                    <div id="pop_exp_item_licen_main_new1" style="height: 288px; margin-top: -30px;">
                        <iframe src="" name="trans_item_DTA_Invoice" scrolling="no" id="Trans_product_DTA_Invoice_iframe"
                            style="height: 530px; width: 700px;"></iframe>
                    </div>
                </div>
                <div class="content" id="page-4">
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Third Party Name
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ThirdPartyName" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                MaxLength="70" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <div id="dv_Thirdpartyname_popup" runat="server">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Exp_Thirdparty('Exp_ThirdParty'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                            Authorized Economic Operator Code
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Authrzd_Economic_Code" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onpaste="return validatePaste(event);" MaxLength="17" TabIndex="79"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Third Party Address1
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ThirdParty_Add1" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                MaxLength="70" onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                            Authorized Economic Operator Country
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Authrzd_Economic_Country" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onpaste="return validatePaste(event);" MaxLength="2" TabIndex="79"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Third Party Address2
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ThirdParty_Add2" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                runat="server" MaxLength="50" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                            Authorized Economic Operator Role
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Authrzd_Economic_Role" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                runat="server" MaxLength="3" TabIndex="79"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Third Party City
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ThirdParty_City" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                runat="server" MaxLength="35" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <asp:Panel ID="pnl_notifyName" runat="server" Visible="false">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                                Notify Name
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_thirdPartyNotifyName" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                    MaxLength="35"></asp:TextBox>
                            </div>
                        </asp:Panel>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Country Sub Division
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Country_Division" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                runat="server" MaxLength="35" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <asp:Panel ID="pnl_notifyAdd1" runat="server" Visible="false">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                                Notify Address 1
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_thirdpartyNotifyAddress1" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                    MaxLength="35"></asp:TextBox>
                            </div>
                        </asp:Panel>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Country Code
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_CountryCode" CssClass="txtbox_none_Mid_transac_Supp_Name" runat="server"
                                MaxLength="2" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <asp:Panel ID="pnl_notifyAdd2" runat="server" Visible="false">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                                Notify Address 2
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_thirdpartyNotifyAddress2" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                    MaxLength="35"></asp:TextBox>
                            </div>
                        </asp:Panel>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Third Party Pin
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ThirdParty_Pin" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Onkeypress="return num1(event)" runat="server" MaxLength="10" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <asp:Panel ID="pnl_notifyAdd3" runat="server" Visible="false">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                                Notify Address 3
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_thirdpartyNotifyAddress3" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                    MaxLength="35">
                                </asp:TextBox>
                            </div>
                        </asp:Panel>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Terms Place
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_TermsPlace" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                MaxLength="35" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <asp:Panel ID="pnl_notifyCountry" runat="server" Visible="false">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 240px">
                                Notify Country
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_thirdpartyNotifyCountry" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                                    MaxLength="35"></asp:TextBox>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            <%--<div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_det_Inv_S_No">
             <div id="innerbox_MidMain_Trans_Item_Main_top">
               <div id="tag_transac_lft_in1_item_top">
                 <div id="tag_label_transaction_popup_gen3">
                   Invoice Sl No
                 </div>
                  <div id="txtcon-m_transaction_list1">
                                    <asp:DropDownList ID="ddlInv_SL_No" runat="server" CssClass="listtxt_transac_src1"  
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlInv_SL_No_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
               </div>
             </div>
            </div>--%>
            <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_det_Inv_S_No" style="height: 29px;
                margin-top: 10px;">
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv. Sl No :
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:DropDownList ID="ddlInv_SL_No" runat="server" CssClass="listtxt_transac_src1"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlInv_SL_No_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_det_INVOICE">
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_Topcap">
                    Current Invoice Details</div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv No
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <%--   <asp:TextBox ID="lblInvoiceNo" runat="server" BorderStyle="None" TextMode="MultiLine" BackColor="Transparent"  Width="100px"></asp:TextBox>--%>
                        <asp:Label ID="lblInvoiceNo" runat="server" Style="text-transform: uppercase;"></asp:Label></div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv Date
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv Value
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceValue" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Currency
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceCurrency" runat="server"></asp:Label>
                    </div>
                </div>
                <%--  <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
            <div id="tag_label_transaction_popup_IGM_invoice_det1">
                Invo. Currency</div>
            <div id="tag_label_transaction_popup_IGM_invoice_det2">
                <asp:Label ID="lblInvoiceValue" runat="server"></asp:Label>
            </div>
        </div>--%>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Inv Terms
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceTerms" runat="server" Text="FOB"></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Prod val
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblProductValue" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                        Total No. Of Inv
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblTotal_No_Of_Invoices" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <!-- Buttons Place Here -->
            <div id="innerbox_MidMain_bot_transact_invoice" style="width: 950px">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                        OnClientClick="jQuery('#form1').validationEngine('hide');" TabIndex="79" OnClick="btnNew_Click" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate_Invoice();"
                        TabIndex="80" />
                </div>
                  <div id="editbu">
                    <asp:Button ID="btnSave_New" runat="server" Text="Save & New" CssClass="autowidupdatebut"
                        OnClick="btn_save_new_Click" OnClientClick="return validate_Invoice();" TabIndex="80" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                        OnClientClick="return validate_Invoice();" TabIndex="80" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="81" CausesValidation="false"
                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="81" CausesValidation="false" UseSubmitBehavior="false"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                        CssClass="dlete" Style="display: none;" />
                </div>
                <div id="editbu">
                    <%-- <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Parent_close_button1();return false;"
                        tabindex="82" CausesValidation="false"
                        UseSubmitBehavior="false"/>--%>
                    <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1_Trigger_AnotherPage('General',document.getElementById('hdn_source').value);return false;"
                        id="btnCancel" tabindex="55">
                </div>
                <div id="editbu">
                    <%--   <asp:Button ID="btnMoveup" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            CssClass="autowidmovebut" Text="Excel Upload" OnClientClick="jQuery('#form1').validationEngine('hide');return false;" />--%>
                    <asp:Button ID="btngenexcel" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="autowidmovebut" Text="Excel Upload" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXP_Inv_Excel_Upload('New');return false;" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btn_Indev_Excel" Visible="false" runat="server" CausesValidation="false"
                        UseSubmitBehavior="false" CssClass="autowidmovebut" Text="INDEV Excel" OnClientClick="jQuery('#form1').validationEngine('hide');return false;" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btn_Shahi_Upload_AddInv" runat="server" CausesValidation="false"
                        UseSubmitBehavior="false" Width="130px" Visible="false" CssClass="autowidmovebut"
                        Text="Shahi - Additional Inv" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXPORT_SAHI_Export_ExcelUpload_InvoicePage('YES');return false;" />
                </div>
                <%--<div id="editbu">
                        &nbsp;&nbsp;&nbsp; <a href="../Submission/Export_Excel_Format/EXPORT.xlsx" target="_new">
                            <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"
                                Height="30px" Width="30px" runat="server" />
                        </a>
                    </div>--%>
                <div id="editbu" style="padding-left:6px;">
                    &nbsp;&nbsp;&nbsp; <a href="../Submission/Export_Excel_Format/EXPORT_v3.0.xlsm" target="_new">
                        <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"
                            Height="30px" Width="30px" runat="server"/>
                    </a>
                </div>

                <div id=editbu style="padding-left:3px;padding-right:3px;">
                 <a href="../Submission/Export_Excel_Format/EXPORT.xlsx" target="_new">
                  <asp:Image ID="Image2" ImageUrl="~/images/icons/excel.png" ToolTip="Download Export Excel File"
                            Height="30px" Width="30px" runat="server" />
                 </a>
                </div>

                <div id="editbu">
                    <asp:Button ID="Button7" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="autowidmovebut" Text="Inv Copy" Width="70px" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXPORT_Inv_Copy(); return false;" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnInv_move" Text="Move" CssClass="autowidupdatebut" Width="50px"
                        runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXP_Prouduct_Invoice_Move('New'); return false;" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnInvoiceExcelDownload" runat="server" CausesValidation="false"
                        UseSubmitBehavior="false" CssClass="autowidmovebut" Text="Excel Download" OnClientClick="Export_Excel_download(); return false" />
                </div>

                 <div id="editbu" style="width:45px;">                                    
                        <asp:Button ID="btn_Multiple" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="autowidmovebut" Text="Split" Width="44px" OnClientClick="Exp_MultiSplit(); return false;" />                        
                    </div>
            </div>
            <!-- Buttons Place Here -->
            <%-- INDEV EXCEL FORMAT  --%>
            <asp:ModalPopupExtender ID="mp_Indev" runat="server" PopupControlID="Panel5" TargetControlID="btn_Indev_Excel"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel5" runat="server" CssClass="modalPopup" align="center" Style="display: none;
                width: 500px;" BorderColor="Transparent">
                <asp:Button ID="btnClose_indev" runat="server" Style="display: none" />
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 500px;">
                    <div id="innerbox_MidMain_top_adcode_Itemmove" style="width: 500px;">
                        Indev Excel Upload
                        <div id="popupwindow_closebut_right">
                            <input type="close" value="Submit" class="clsicon" onclick="$find('mp_Indev').hide();" />
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Mid_adcode_Itemmove1">
                        <div id="pop_text_area_ItemMove">
                            <div id="tag_label_adcode">
                                Select Excel File</div>
                            <div id="txtcon-m_src_ItemMove">
                                <asp:FileUpload ID="fileuploadExcel1" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_top_adcode_Itemmove" style="width: 500px; height: 40px;">
                    <div id="innerbox_adcode_bot_inn_ItemMove" style="padding-right: 225px;">
                        <div id="editbu">
                            <asp:Button ID="btnImport_Indev" runat="server" CssClass="autowidmovebut" OnClick="btnImport_Indev_Click"
                                Text="Upload" TabIndex="116" UseSubmitBehavior="false" /></div>
                    </div>
                </div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mp_yesorno" runat="server" PopupControlID="Panel2" TargetControlID="Button3"
                CancelControlID="btnclose1" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Button ID="Button3" runat="server" Style="display: none" />
            <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" align="center" Style="display: none;
                width: 300px; height: 140px; margin-top: -70px;" BorderColor="Transparent">
                <asp:Button ID="btnclose1" runat="server" Style="display: none" />
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 130px;">
                    <div id="innerbox_MidMain_top_adcode_Itemmove" style="width: 300px;">
                        INVOICE
                        <div id="popupwindow_closebut_right">
                            <input type="close" value="Submit" class="clsicon" onclick="$find('mp_yesorno').hide();" />
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Mid_adcode_Itemmove1">
                        <div id="pop_text_area_ItemMove">
                            <div id="tag_label_adcode">
                            </div>
                            <div id="txtcon-m_src_ItemMove" style="width: 300px;">
                                <asp:Label ID="lbl_Excel_msg" runat="server" Text="Invoice already exists!.. delete all pervious invoice?"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_top_adcode_Itemmove" style="width: 300px; height: 40px;">
                    <div id="innerbox_adcode_bot_inn_ItemMove" style="float: right; padding-right: 2px;
                        width: 180px;">
                        <div id="editbu">
                            <asp:Button ID="btn_Delete_All_Invoice_And_Upload" runat="server" CausesValidation="false"
                                OnClick="btn_Delete_All_Invoice_And_Upload_Click" UseSubmitBehavior="false" CssClass="dlete"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="Button5" runat="server" class="scancel" OnClientClick="$find('mp_yesorno').hide();return false;"
                                CausesValidation="false" UseSubmitBehavior="false" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdn_grid_edit" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_currency" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_inv_slno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_INVOICE_SLNO" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Invoice_Currency_Exrate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="hdn_Update_General" runat="server" />
            <asp:HiddenField ID="hdn_Consignee_Name" runat="server" />
            <asp:HiddenField ID="hdn_Consignee_Address1" runat="server" />
            <asp:HiddenField ID="hdn_Consignee_Address2" runat="server" />
            <asp:HiddenField ID="hdn_Consignee_Address3" runat="server" />
            <asp:HiddenField ID="hdn_Consignee_Address4" runat="server" />
            <asp:HiddenField ID="hdn_Consignee_Address5" runat="server" />
            <asp:HiddenField ID="hdn_Freight_Exrate" runat="server" />
            <asp:HiddenField ID="hdn_Insurance_Exrate" runat="server" />
            <asp:HiddenField ID="hdn_non_std_effect_dt" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_non_std_bankname" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_non_std_cert_no" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_non_std_cert_dt" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_chk_Invalid_Cur" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="HD_select" runat="server" />
            <asp:HiddenField ID="hdn_Branch" runat="server" />
            <asp:HiddenField ID="hdn_Jobno" runat="server" />
            <asp:HiddenField ID="hdn_currentPage" runat="server" />
            <asp:HiddenField ID="hdn_source" runat="server" />
            <asp:HiddenField ID="hdn_CompanyID" runat="server" />
            <asp:HiddenField ID="hdn_buyer_edit" runat="server" />
            <asp:HiddenField ID="hdn_Inner_tab_Menu" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_ddlBuyer" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Buyer_Add1" runat="server" ClientIDMode="Static" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5']);
    </script>
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="Button1" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/jquery.textchange.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Autotab.js" type="text/javascript"></script>
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
    <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

            var totalRows = $("#<%=gv_Invoice.ClientID %> tr").length;
            var lastProductId = $("#<%=gv_Invoice.ClientID %> tr:last").children("td:first").html();


            if (totalRows > 2) {

                gridviewScroll();

            }
            else {

                if (lastProductId > 0) {
                    gridviewScroll();
                }
                else {
                    /*alert (lastProductId);*/
                }
            }
        });

        function gridviewScroll() {
            gridView1 = $('#<%=gv_Invoice.ClientID %>').gridviewScroll({

                width: 710,
                height: 122,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 1,
                arrowsize: 30,
                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",
                headerrowcount: 1,
                railsize: 16,
                barsize: 15
            });
        }

    </script>
    <script type="text/javascript">
        var win = null;

        var Jobno = $('#<%= hdn_Jobno.ClientID %>').val();
        var Branch_Common = $('#<%= hdn_Branch.ClientID %>').val();

        function Export_Excel_download() {
            var Type = 'excel';
            win = window.open('../FlatFile/MIS_report_1.aspx?Open_Export_Excel_Download_XLs=Yes&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '', 'ndf');
            Loading_HideImage();
        }

    </script>
    <script type="text/javascript">        // Condtion Added by pandiyan on 17-09-2025 sugg by niyas for Terms Condition based enabled ddlWhether
        function mapDropdowns(ddlTerms) {
            var ddlWhether = document.getElementById("<%= ddlWhether.ClientID %>");
            var selected = ddlTerms.value;
           
            // Apply mapping rules
            if (selected == "FOB") {
                ddlWhether.value = "N";               
            }
            else if (selected == "CIF") {
                ddlWhether.value = "B";              
            }
            else if (selected == "CF") {
                ddlWhether.value = "F";
            }
            else if (selected == "CI") {
                ddlWhether.value = "I";
            }
        }
</script>
     <script type="text/javascript">
         function validateFreight() {
             var invoiceVal = parseFloat(document.getElementById("<%= txtInvoiceValue.ClientID %>").value) || 0;
        var freightVal = parseFloat(document.getElementById("<%= txtFreight_Charges.ClientID %>").value) || 0;
        var invoiceCur = document.getElementById("<%= txtInvoiceCurrency.ClientID %>").value.trim();
        var freightCur = document.getElementById("<%= txtFreight_Currency.ClientID %>").value.trim();
        var exchangeRate = parseFloat(document.getElementById("<%= txtExchangeRate.ClientID %>").value) || 1;

        // Case 1: Same currency
        if (invoiceCur == freightCur) {
            if (freightVal > invoiceVal) {
                alert("Freight amount cannot be higher than the Invoice Value!");
                document.getElementById("<%= txtFreight_Charges.ClientID %>").value = "";
                document.getElementById("<%= txtFreight_Charges.ClientID %>").focus();
                return;
            }
        }

        // Case 2: Freight currency = INR
        if (freightCur == "INR") {
            var invoiceInINR = Math.round(invoiceVal * exchangeRate); // 🔹 Rounded to nearest whole INR
           
            // Or use toFixed(2) if decimals needed
            if (freightVal > invoiceInINR) {
                alert("Freight (INR) cannot be higher than Invoice Value converted to INR!\nInvoice Value in INR: " + invoiceInINR);
                document.getElementById("<%= txtFreight_Charges.ClientID %>").value = "";
                document.getElementById("<%= txtFreight_Charges.ClientID %>").focus();
                return;
            }
        }
    }

    window.onload = function () {
        document.getElementById("<%= txtFreight_Charges.ClientID %>").onblur = validateFreight;
    }
</script>

<script type="text/javascript">
    function Exp_MultiSplit() {
        NewWindow1('../Export/Multiple_Inv_Split_Export.aspx', 'List', '1100', '424', 'yes');
        }
//    function Exp_MultiSplit() {
//        NewWindow1('../Export/Multiple_Inv_Split_Export.aspx?Jobno=' + encodeURIComponent(Jobno), 'List', '1100', '424', 'yes');
//    }
</script>


</body>
</html>
