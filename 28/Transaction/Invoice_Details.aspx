<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice_Details.aspx.cs"
    Inherits="Transaction_Invoice_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>IGM | Transaction</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
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
    </style>
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
                    <%-- <a href="#" onclick="alert('is the form valid? '+jQuery('#formID1').validationEngine('validate'))">Evaluate form</a>--%>
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');" id="IMD">
                        <span>Main Details</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2('0');" id="MD">
                        <span>Freight & Misc</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3('0');" id="SD">
                        <span>Supplier Details</span></a></li>
                    <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4('0');" id="SVBD">
                        <span>SVB Details</span></a></li>
                    <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('0');" id="OD">
                        <span>Other Details</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice">
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1_chkbox_frame">
                            <div id="pop_text_area_transac_MIS_InnTitle1_chkbox">
                                Single Freight & Insurance charge for all Invoice
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                                <asp:CheckBox ID="chkMisc" runat="server" TabIndex="25" /></div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Invoice No
                            </div>
                            <div id="txtcon-m_transaction_Inv_No">
                                <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date">
                                Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="2"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <%-- <asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator1" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" Display="None"
                            runat="server" ControlToValidate="txtDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                --%>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Terms</div>
                            <div id="txtcon-m_transaction_list1_fcl">
                                <asp:DropDownList ID="ddlTerms" CssClass="validate[required] listtxt_transac_FCL"
                                    runat="server" TabIndex="3">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_trans_Inv_empty">
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date">
                                Currency
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInvoiceCurrency" runat="server" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" TabIndex="4" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                    onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('InvoiceCurrency'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Invoice Value
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtInvoiceValue" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                    MaxLength="17" TabIndex="5" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoic_empty_main_details">
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date">
                                Ex. Rate
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtExRate" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="6"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_Invoice_Grid_area">
                            <asp:GridView ID="gv_Invoice" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                CssClass="grid-view" AllowPaging="True" OnPageIndexChanging="gv_Invoice_PageIndexChanging"
                                HorizontalAlign="Left" OnRowDataBound="gv_Invoice_RowDataBound" OnSelectedIndexChanged="gv_Invoice_SelectedIndexChanged"
                                PageSize="7" DataKeyNames="INVOICE_ID" AllowSorting="True" BorderColor="#C8C8C8"
                                Width="100%" ShowHeaderWhenEmpty="true" ShowFooter="false" BorderStyle="Solid"
                                BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="S.NO">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFullName" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="INVOICE_SLNO" HeaderText="S.NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_NO" HeaderText="INV NO">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_DATE" HeaderText="INV DATE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TERMS" HeaderText="TERMS">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_VALUE" HeaderText="INV VALUE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="CURRENCY">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_SINGLE_OR_MULITIPLE" HeaderText="SINGLE/MULTIPLE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="Supplier Name">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_ADDRESS" HeaderText="SUPPLIER ADDRESS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_ADDRESS1" HeaderText="SUPPLIER ADDRESS1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_ADDRESS2" HeaderText="SUPPLIER ADDRESS2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_COUNTRY_NAME" HeaderText="SUPPLIER COUNTRY NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_COUNTRY_CODE" HeaderText="SUPPLIER COUNTRY Code">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SUPPLIER_COUNTRY_PINCODE" HeaderText="SUPPLIER COUNTRY Pincode">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_ADDRESS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_ADDRESS1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_ADDRESS2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_COUNTRY_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLER_COUNTRY_CODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELLERCOUNTRY_PINCODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_ADDRESS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_ADDRESS1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_ADDRESS2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_COUNTRY_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_COUNTRY_CODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BROKER_COUNTRY_PINCODE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_AGENCY_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_AGENCY_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_AGENCY_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_AGENCY_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_DISCOUNT_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_DISCOUNT_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_DISCOUNT_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_DISCOUNT_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_DISCOUNT_REASON">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_LOADING_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_LOADING_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_LOADING_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_LOADING_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_FREIGHT_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_FREIGHT_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_FREIGHT_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_FREIGHT_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_INSURANCE_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_INSURANCE_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_INSURANCE_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_INSURANCE_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_HIGHSEASALE_CHARGES">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_HIGHSEASALE_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_HIGHSEASALE_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MIS_HIGHSEASALE_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_RELATION">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_REF_NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_CUSTOM_HOUSE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_LOADING_ON">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_ASSESABLE_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_DUTY_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_ASSESABLE_STATUS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_DUTY_STATUS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_PURCHASE_ORDER">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_PURCHASE_ORDER_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_CONTRACT_NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_CONTRACT_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_LOC_NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_LOC_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_NATURE_OF_TRANSACTION">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_TERMS_OF_PAYMENT">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_CONDITIONS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTHER_VALUATION_METHOD">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SVB_REF_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_EXRATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkmodify" runat="server" CommandName="Select" PostBackUrl='<%#"~/Transaction/Item_Details.aspx?INVOICE_SLNO_ID="+Eval("INVOICE_SLNO") %>'
                                                OnClientClick="jQuery('#form1').validationEngine('hideAll');Product_Open_button();">Product</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:TemplateField>
                                        <asp:BoundField DataField="NON_STD_EFFECT_DT_IMP">
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
                                </Columns>
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" PreviousPageText="Previous" Position="Top" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier">
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Supplier Name
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSupplierName" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="7"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('Supplier'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp">
                             <asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server"  OnClientClick="jQuery('#form1').validationEngine('hideAll');openSupplier_Masternew1(); return false" />
                                 
                               <%-- <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');openSupplier_Masternew1();return false"
                                    style="cursor: pointer;">New</a>--%>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Seller Name
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSellerName" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="19"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('Seller'); return false"
                                    class="magnfy"></a>
                            </div>
                             <asp:Button ID="Button1" CssClass="autowidnewbut" Text="New" runat="server"  OnClientClick="jQuery('#form1').validationEngine('hideAll');openSupplier_Masternew1(); return false" />
                              
                           <%-- <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');openSupplier_Masternew1();return false"
                                style="cursor: pointer;">New</a>--%>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Supp. Address
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSupplierAddress" runat="server" MaxLength="35" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="8"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Seller Address
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSellerAddress" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="20"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSupplierAddress1" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    MaxLength="35" ClientIDMode="Static" TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSellerAddress1" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="21"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSupplierAddress2" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="10"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSellerAddress2" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="22"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Country Name
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSupplierCountryName" runat="server" MaxLength="35" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="11"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry('Supplier'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Inv_Supp">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Country Name
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtSellerCountryName" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="23"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry('Seller'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Pin Code
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtSuppliercountry_pincode" runat="server" MaxLength="10" Width="75px"
                                    onkeyup="autotab(this);" TabIndex="12" CssClass="validate[custom[onlyNumberSp]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoic_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Pin Code
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtSellercountry_pincode" runat="server" MaxLength="10" CssClass="validate[custom[onlyNumberSp]] txtbox_none_Mid_transac_code"
                                    onkeyup="autotab(this);" Width="75px" ClientIDMode="Static" TabIndex="24"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Broker Name
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtBrokerName" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('Broker'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                             <asp:Button ID="Button2" CssClass="autowidnewbut" Text="New" runat="server"  OnClientClick="jQuery('#form1').validationEngine('hideAll');openSupplier_Masternew1(); return false" />
                              
                               <%-- <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');openSupplier_Masternew1();return false"
                                    style="cursor: pointer;">New</a>--%>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Broker Address
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtBrokerAddress" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="14"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtBrokerAddress1" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="15"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtBrokerAddress2" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="16"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Country Name
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtBrokerCountryName" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" TabIndex="17"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry('Broker'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Pin Code
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtbrokercountry_pincode" runat="server" MaxLength="10" CssClass="validate[custom[onlyNumberSp]] txtbox_none_Mid_transac_code"
                                    onkeyup="autotab(this);" ClientIDMode="Static" TabIndex="18"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                    </div>
                    <%-- <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" ValidationGroup="draw" CssClass="save"
                        OnClick="btnSave_Click" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="dlete" OnClick="btnDelete_Click" />
                </div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />
                </div>
            </div>--%>
                </div>
                <div class="content" id="page-3">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_MISC">
                        <%--<div id="tag_transac_lft_Trans_Invoice_Supp_in1_chkbox_frame">
                            <div id="pop_text_area_transac_MIS_InnTitle1_chkbox">
                                Multiple Invoice
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                                <asp:CheckBox ID="chkMisc" runat="server" TabIndex="25" /></div>
                        </div>--%>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                Currency</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                Exchange Rate</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                Rate</div>
                            <div id="tag_label_transaction_MIS_empty1">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="pop_text_area_transac_MIS_InnTitle1">
                                Charge</div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                MISC</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMiscellaneous_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="27" onkeypress="return char1(event)" onkeyup="autotab(this);"
                                    onblur="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Misc'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtMiscellaneous_Exch_Rate" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    Style="text-align: right;" ClientIDMode="Static" TabIndex="28"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtMiscellaneous_Rate" runat="server" MaxLength="8" Style="text-align: right;"
                                    onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" TabIndex="29"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtMiscellaneous_Charges" runat="server" MaxLength="17" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    TabIndex="30" Style="text-align: right;" onblur="extractNumber(this,2,false);"
                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" 
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Agency</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtAgency_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="31" onkeypress="return char1(event)" onkeyup="autotab(this);"
                                    onblur="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Agency'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtAgency_Exch_Rate" runat="server" MaxLength="12" Style="text-align: right;"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    ClientIDMode="Static" TabIndex="32"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtAgency_Rate" MaxLength="12" runat="server" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" Style="text-align: right;"
                                    TabIndex="33"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtAgency_Charges" runat="server" MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    Style="text-align: right;" TabIndex="34" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Discount</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtDiscount_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="35" onkeyup="autotab(this);" onkeypress="return char1(event)"
                                    onblur="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Discount'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtDiscount_Exch_Rate" Style="text-align: right;" runat="server"
                                    MaxLength="12" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    ClientIDMode="Static" TabIndex="36"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtDiscount_Rate" Style="text-align: right;" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    runat="server" MaxLength="7" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    TabIndex="37"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtDiscount_Charges" Style="text-align: right;" runat="server" MaxLength="17"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" TabIndex="38"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_Dis_empty">
                                Discount Reason
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtDiscount_Reason" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="50" TabIndex="39"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Loading</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtLoading_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="40" onkeyup="autotab(this);" onkeypress="return char1(event)"
                                    onblur="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Loading'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtLoading_ExchRate" Style="text-align: right;" runat="server" MaxLength="12"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    ClientIDMode="Static" TabIndex="41"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtLoading_Rate" runat="server" Style="text-align: right;" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="12" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                    TabIndex="42"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtLoading_Charges" runat="server" Style="text-align: right;" MaxLength="17"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" TabIndex="43"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Panel ID="pnl_Multi_Invoice" runat="server">
                            <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                    Freight</div>
                                <div id="txtcon-m_transaction_item_maindet">
                                    <asp:UpdatePanel ID="UpTxtExpiryDate" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtFreight_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                                ClientIDMode="Static" TabIndex="44" onkeyup="autotab(this);" onkeypress="return char1(event)"
                                                onblur="return ChangeCase(this);"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="txtFreight_Currency_TextChanged" EventName="TextChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div id="magnify_area">
                                    <%-- <a href="#" onclick="OpenPopupExchange('Freight'); return false" class="magnfy"></a>--%>
                                    <asp:LinkButton ID="ImageButton10" runat="server" CssClass="magnfy" Enabled="false"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange_Master_Frieght('Freight'); return false"></asp:LinkButton>
                                </div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtFreight_Exch_Rate" runat="server" MaxLength="12" Style="text-align: right;"
                                         CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                        onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                        onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        ClientIDMode="Static" TabIndex="45"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtFreight_Rate" Style="text-align: right;" runat="server" MaxLength="8"
                                        onblur="extractNumber(this,4,false);return Clear_Dot(this);"
                                        onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" TabIndex="46"
                                        CausesValidation="false" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                    %</div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtFreight_Charges" runat="server" MaxLength="17" Style="text-align: right;"
                                        Enabled="false" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                        onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="47"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_Totalfrieght" runat="server" visible="false" class="tag_transac_lft_Trans_Invoice_Supp_in1">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_Dis_empty">
                                    Total Freight Charge
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtTotal_Frieght" runat="server" MaxLength="17" CssClass="txtbox_none_Mid_transac_code"
                                        TabIndex="48" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                    Insurance</div>
                                <div id="txtcon-m_transaction_item_maindet">
                                    <asp:TextBox ID="txtInsurance_Currency" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                        ClientIDMode="Static" TabIndex="49" onkeyup="autotab(this);" onkeypress="return char1(event)"
                                        onblur="return ChangeCase(this);"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                    <%-- <a href="#" onclick="OpenPopupExchange('Insurance'); return false" class="magnfy"></a>--%>
                                    <asp:LinkButton ID="ImageButton11" runat="server" CssClass="magnfy" Enabled="false"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange_Master_Insurance('Insurance'); return false"></asp:LinkButton>
                                </div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtInsurance_Exch_Rate" runat="server" MaxLength="12" 
                                        Style="text-align: right;" 
                                        CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" onblur="javascript:this.value=Comma(this.value); extractNumber(this,4,false);return Clear_Dot(this);"
                                        onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        ClientIDMode="Static" TabIndex="50"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtInsurance_Rate" runat="server" MaxLength="8" Style="text-align: right;"
                                        onblur="extractNumber(this,4,false);return Clear_Dot(this);"
                                        onkeyup="extractNumber(this,4,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" TabIndex="51"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                    %</div>
                                <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtInsurance_Charges" runat="server" MaxLength="17" Style="text-align: right;"
                                        Enabled="false" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                        onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="52"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_TotalInsurance" runat="server" visible="false" class="tag_transac_lft_Trans_Invoice_Supp_in1">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_Dis_empty">
                                    Total Insurance Charge
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtTotal_Insurance" runat="server" MaxLength="17" CssClass="txtbox_none_Mid_transac_code"
                                        TabIndex="53" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                High Sea Sale
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtHighSeaSale_Currency" runat="server" MaxLength="3" onkeyup="autotab(this);"
                                    Text="INR" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="54" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="OpenPopupExchange('HighSeaSale'); return false" class="magnfy">
                                </a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty1">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtHighSeaSale_Exch_Rate" runat="server" MaxLength="12" Style="text-align: right;"
                                    Text="1.00" ClientIDMode="Static" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    TabIndex="55" onblur="extractNumber(this,4,false);return Clear_Dot(this);" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtHighSeaSale_Rate" runat="server" MaxLength="7" Style="text-align: right;"
                                    onblur="javascript:this.value=Comma(this.value); extractNumber(this,2,false);return Clear_Dot(this);"
                                    value="0.00" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" 
                                    TabIndex="56"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM_Trans_invoice_empty2">
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtHighSeaSale_Charges" runat="server" MaxLength="17" Style="text-align: right;"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                    TabIndex="57"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%--  <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="save" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="updates" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="dlete" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" /></div>
            </div>--%>
                </div>
                <div class="content" id="page-4">
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_chkbox_frame">
                        <div id="tag_label_transaction_MIS_empty1">
                            <asp:CheckBox ID="chkSVB_Relation" runat="server" TabIndex="58"></asp:CheckBox></div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="pop_text_area_transac_MIS_InnTitle1_chkbox">
                            SVB Relation
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            SVB Ref No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtSVB_RefNo" runat="server" MaxLength="20" onkeypress="return numchar(event)"
                                onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                Enabled="false" TabIndex="59"></asp:TextBox>
                        </div>
                        <%-- -------------------%>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Date</div>
                        <div id="txtcon-m_transaction_SVB_Date">
                            <%--txtcon-m_transaction_SVB_Date--%>
                            <asp:TextBox ID="txtSVBDate" runat="server" Width="95px" TabIndex="60" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Enabled="False"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtSVBDate"
                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtSVBDate"
                                Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                            </asp:CalendarExtender>
                            <%-- <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red" Display="None"
                            runat="server" ControlToValidate="txtDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                            --%>
                        </div>
                        <%-- -------------------%>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            SVB Custom House
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                        <%-- <asp:TextBox ID="txtSVB_CustomHouse" runat="server" TabIndex="61" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                ></asp:TextBox>--%>
                                  <asp:TextBox ID="txtCustomsHouse" runat="server" TabIndex="61" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                ></asp:TextBox>
                                
                        </div>
                        <div id="magnify_area">
                            <a href="#" class="magnfy" onclick="OpenPopupCustom_House(); return false"></a>
                            <%--<asp:DropDownList ID="ddlSVB_CustomHouse" CssClass="listtxt_transac_SVB" runat="server"
                                Enabled="false" TabIndex="61">
                            </asp:DropDownList>--%>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Loading On
                        </div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlLoadingOn" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="62">
                                <%-- <asp:ListItem>Assessable</asp:ListItem>
                        <asp:ListItem>Duty</asp:ListItem>
                        <asp:ListItem>Both</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Assessable Rate
                        </div>
                        <div id="txtcon-m_transaction_SVB_Rate">
                            <asp:TextBox ID="txtAssesable_Rate" runat="server" onkeypress="return numdot1(event)"
                                onkeyup="autotab(this);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_SVB_Rate"
                                Enabled="false" MaxLength="6" TabIndex="63"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_SVB_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Status</div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlAssesable_Status" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="64">
                                <%-- <asp:ListItem>P</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Duty Rate
                        </div>
                        <div id="txtcon-m_transaction_SVB_Rate">
                            <asp:TextBox ID="txtDuty_Rate" runat="server" onkeypress="return numdot1(event)"
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_SVB_Rate" Enabled="false"
                                MaxLength="6" TabIndex="65"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_SVB_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Status</div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlDuty_Status" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="66">
                                <%--  <asp:ListItem>P</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%--  <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="save" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="updates" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="dlete" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" /></div>
            </div>--%>
                </div>
                <div class="content" id="page-5">
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_tag1">
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_tag1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Purchase Order No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtPurchaseOrderNo" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" MaxLength="20" TabIndex="67"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            Purchase Date
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtPurchaseDate" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                MaxLength="10" TabIndex="68"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender1"
                                    runat="server" TargetControlID="txtPurchaseDate" Mask="99/99/9999" MaskType="Date"
                                    ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True">
                                </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPurchaseDate"
                                Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                            </asp:CalendarExtender>
                            <%-- <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator2" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="None"
                        runat="server" ControlToValidate="txtPurchaseDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_tag1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Contract No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtContractNo" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" MaxLength="20" TabIndex="69"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            Contract Date
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtContractDate" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                MaxLength="10" TabIndex="70"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender2"
                                    runat="server" TargetControlID="txtContractDate" Mask="99/99/9999" MaskType="Date"
                                    ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True">
                                </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtContractDate"
                                Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                            </asp:CalendarExtender>
                            <%--   <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator3" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" Display="None"
                        runat="server" ControlToValidate="txtContractDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_tag1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            LC No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtLCNo" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" MaxLength="20" TabIndex="71"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                            LC Date
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtLCDate" CssClass="txtbox_none_Mid_transac_Supp_Name" runat="server"
                                TabIndex="72"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                    TargetControlID="txtLCDate" Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True"
                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True">
                                </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtLCDate"
                                Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                            </asp:CalendarExtender>
                            <%--<asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RegularExpressionValidator4" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ForeColor="Red" Display="None"
                        runat="server" ControlToValidate="txtLCDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_tag1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Nature of Trans
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:DropDownList ID="ddlNatureOfTrans" CssClass="txtbox_none_Mid_transac_others_Name"
                                runat="server" Height="18px" TabIndex="73">
                                <asp:ListItem>S  Sale</asp:ListItem>
                                <asp:ListItem>F  Free Of Cost</asp:ListItem>
                                <asp:ListItem>C  Consignment</asp:ListItem>
                                <asp:ListItem>G  Gift</asp:ListItem>
                                <asp:ListItem>H  Hire</asp:ListItem>
                                <asp:ListItem>M  Sample</asp:ListItem>
                                <asp:ListItem>O  Others</asp:ListItem>
                                <asp:ListItem>P  Replacement </asp:ListItem>
                                <asp:ListItem>R  Rent</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_tag1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Nature of Payment
                        </div>
                        <div id="txtcon-m_transaction_Inv">
                            <asp:DropDownList ID="ddlNatureOfPayment" CssClass="txtbox_none_Mid_transac_InvNew"
                                runat="server" TabIndex="74">
                                <asp:ListItem>OTH  Others</asp:ListItem>
                                <asp:ListItem>DP  Document Presentation</asp:ListItem>
                                <asp:ListItem>FC  Free Of Charge</asp:ListItem>
                                <asp:ListItem>LC  Letter Of Credit</asp:ListItem>
                                <asp:ListItem>SD  Site Draft</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_Invoice">
                        <div id="tag_transac_rght_in1_margs_nos_others">
                            <div id="tag_label_transaction_popup_IGM_Others_Cond">
                                Conditions</div>
                            <div id="txtcon_l_90px">
                            </div>
                            <div id="txtcon-m_90px_trans_Inv_con">
                                <asp:TextBox ID="txtConditions" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_Inv_con"
                                    onpaste="return checkTextAreaMaxLength(this,event,'1000');" runat="server" onkeyDown="return checkTextAreaMaxLength(this,event,'1000');"
                                    MaxLength="1000" TabIndex="75"></asp:TextBox>
                            </div>
                        </div>
                        <div id="lblMsg5" style="display: none;">
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_tag1">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            Valuation Method
                        </div>
                        <div id="txtcon-m_transaction_Inv">
                            <asp:DropDownList ID="ddlValuationMethod" CssClass="txtbox_none_Mid_transac_InvNew"
                                runat="server" TabIndex="76">
                                <asp:ListItem>Rule 4 - Transaction Value </asp:ListItem>
                                <asp:ListItem>Rule 5 - Identical Goods</asp:ListItem>
                                <asp:ListItem>Rule 6 - Similar Goods</asp:ListItem>
                                <asp:ListItem>Rule 7 - Deductive Value</asp:ListItem>
                                <asp:ListItem>Rule 7A - Computed Value</asp:ListItem>
                                <asp:ListItem>Rule 8 - Residual Method</asp:ListItem>
                                <asp:ListItem>OTHERS - Others</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%-- <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="save" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="updates" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="dlete" /></div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" /></div>
            </div>--%>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_det_INVOICE">
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_Topcap">
                    Current Invoice Details</div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1">
                        Invoice No
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceNo" runat="server" ClientIDMode="Static"></asp:Label></div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1">
                        Invoice Date
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1">
                        Invoice Value
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceValue" runat="server"></asp:Label></div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1">
                        Invoice Cur</div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceCurrency" runat="server"></asp:Label></div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1">
                        Invoice Terms
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblInvoiceTerms" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1">
                        Product value
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblProductValue" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="80"
                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');document.getElementById('hdn_button_click').value = '1';" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" Text="save"
                        OnClientClick="return validate_Invoice();" TabIndex="77" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                        Visible="false" TabIndex="77" OnClientClick="return validate_Invoice();" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="78" CausesValidation="false"
                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="78" CausesValidation="false" UseSubmitBehavior="false"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                        CssClass="dlete" Style="display: none;" />
                </div>
                <div id="editbu">
                 <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Parent_close_button1();return false;"
                        tabindex="79" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                 <%--   <input type="submit" value="Submit" class="scancel" onclick="Parent_close_button();"
                        tabindex="79" id="btnCancel" />--%>
                    <%--<input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>

                <div 
                     id="editbu">
                 <asp:Button ID="btnMoveup" runat="server"  CausesValidation="false" UseSubmitBehavior="false"
               CssClass="autowidmovebut" Text="Excel Upload"  OnClientClick="jQuery('#form1').validationEngine('hide');return false;" 
                         />
                
            </div>
                <div id="div4">
                                   
                         <a href="../Submission/Import_Excel_Format/IMPORT.XLSX" target="_new">Download Excel File Format
                                </a>
                </div>

            </div>

                    <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnMoveup"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" style = "display:none;width:500px;" BorderColor="Transparent">
   
    <asp:Button ID="btnClose" runat="server" style = "display:none"/>
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:500px;">
                <div id="innerbox_MidMain_top_adcode_Itemmove" style="width:500px;">
                    Excel Upload Details
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="$find('mp1').hide();" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode_Itemmove1">
                   
                    <div id="pop_text_area_ItemMove">
                        <div id="tag_label_adcode">
                            Select Excel File</div>
                        <div id="txtcon-m_src_ItemMove">
                        <asp:FileUpload ID="fileuploadExcel" runat="server"  />

<%--                           <asp:DropDownList ID="ddlItemFrom" runat="server" CssClass="listtxt_transac_mode_new"
                                >
                            </asp:DropDownList>--%>
                        </div>
                    </div>
                    
                 
                </div>
            </div>
            <div id="innerbox_MidMain_top_adcode_Itemmove" style="width:500px;height:40px;">
                <div id="innerbox_adcode_bot_inn_ItemMove" style="padding-right:225px;">
                  
                    <div id="editbu">
                    
                      
                     <asp:Button ID="btnImport" runat="server" OnClick="btnImport_Click"
                     CssClass="autowidmovebut" Text="Upload" TabIndex="115" UseSubmitBehavior="false" CausesValidation="false"
                      OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                     
          
                      </div>
                                                             
                    
                     </div>
                </div>
           
            </asp:Panel>

               <asp:ModalPopupExtender ID="mp_yesorno" runat="server" PopupControlID="Panel2" TargetControlID="Button3"
    CancelControlID="btnclose1" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
    <asp:Button ID="Button3" runat="server" style = "display:none"/>

<asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" align="center" style ="display:none;width:300px;height:140px;margin-top:-70px;" BorderColor="Transparent">
    <asp:Button ID="btnclose1" runat="server" style = "display:none"/>
   
  
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px;height:130px;">
                <div id="innerbox_MidMain_top_adcode_Itemmove" style="width:300px;">
                    INVOICE
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="$find('mp_yesorno').hide();" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode_Itemmove1">
                   
                    <div id="pop_text_area_ItemMove">
                        <div id="tag_label_adcode">
                           </div>
                        <div id="txtcon-m_src_ItemMove" style="width:300px;">
                               
                               <asp:Label ID="lbl_Excel_msg" runat="server" Text="Invoice already exists!.. delete all pervious invoice?"></asp:Label>
                        </div>
                    </div>
                    
                 
                </div>
           </div>
            <div id="innerbox_MidMain_top_adcode_Itemmove" style="width:300px;height:40px;">
                <div id="innerbox_adcode_bot_inn_ItemMove" style="float:right;padding-right:2px;width: 180px;">
                  
                  
                <div id="editbu">
                    
                      <asp:Button ID="btn_Delete_All_Invoice_And_Upload" runat="server"   CausesValidation="false" OnClick="btn_Delete_All_Invoice_And_Upload_Click"
                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                  
                </div>
                <div id="editbu">
                 <asp:Button ID="Button5" runat="server" class="scancel" OnClientClick="$find('mp_yesorno').hide();return false;"
                         CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                      
                      </div>
                                                             
                    
                     </div>
                </div>
           
            </asp:Panel>

            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static"/>

            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hfdsupplier_countrycode" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hfdseller_countrycode" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hfdbroker_countrycode" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_currency" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Invoice_Currency_Exrate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_FOB_Freight_Rate" runat="server" ClientIDMode="Static" Value="20.0000" />
            <asp:HiddenField ID="hdn_FOB_Freight_Charge" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_FOB_Freight_Currency" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_FOB_Freight_ExRate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CI_Freight_Rate" runat="server" ClientIDMode="Static" Value="20.0000" />
            <asp:HiddenField ID="hdn_CI_Freight_Charge" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CI_Freight_Currency" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CI_Freight_ExRate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CF_Freight_Rate" runat="server" ClientIDMode="Static" Value="20.0000" />
            <asp:HiddenField ID="hdn_CF_Freight_Charge" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CF_Freight_Currency" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CF_Freight_ExRate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CIF_Freight_Rate" runat="server" ClientIDMode="Static" Value="20.0000" />
            <asp:HiddenField ID="hdn_CIF_Freight_Charge" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CIF_Freight_Currency" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CIF_Freight_ExRate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_FOB_Insurance_Rate" runat="server" ClientIDMode="Static"
                Value="1.1250" />
            <asp:HiddenField ID="hdn_FOB_Insurance_Charge" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_FOB_Insurance_Currency" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_FOB_Insurance_ExRate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CI_Insurance_Rate" runat="server" ClientIDMode="Static"
                Value="1.1250" />
            <asp:HiddenField ID="hdn_CI_Insurance_Charge" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CI_Insurance_Currency" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CI_Insurance_ExRate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CF_Insurance_Rate" runat="server" ClientIDMode="Static"
                Value="1.1250" />
            <asp:HiddenField ID="hdn_CF_Insurance_Charge" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CF_Insurance_Currency" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CF_Insurance_ExRate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CIF_Insurance_Rate" runat="server" ClientIDMode="Static"
                Value="1.1250" />
            <asp:HiddenField ID="hdn_CIF_Insurance_Charge" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CIF_Insurance_Currency" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CIF_Insurance_ExRate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_update_Invoice_id" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Invoice_mode_singlr_or_multi" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_button_click" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_freight_value" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_insurance_value" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Freight_Rate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Insurance_Rate" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Total_Freight_Value" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Total_Insurance_Value" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_INVOICE_SLNO" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_grid_count" runat="server" ClientIDMode="Static"/>
               <asp:HiddenField ID="hdn_grid_edit" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_CustomsHouse_Name" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />

            <asp:HiddenField ID="hdn_non_std_effect_dt" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_non_std_bankname" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_non_std_cert_no" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_non_std_cert_dt" runat="server" ClientIDMode="Static" />

            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script src="../js/Import_Jscript/Import_Invoice.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/jquery.textchange.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
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

        function validateLimit(obj, divID, maxchar) {

            objDiv = get_object(divID);

            if (this.id) obj = this;

            var remaningChar = maxchar - trimEnter(obj.value).length;

            if (objDiv.id) {
                objDiv.innerHTML = remaningChar + "";
            }
            if (remaningChar <= 0) {
                obj.value = obj.value.substring(maxchar, 0);
                if (objDiv.id) {
                    objDiv.innerHTML = "0 ";
                }
                return false;
            }
            else
            { return true; }
        }
        function get_object(id) {
            var object = null;
            if (document.layers) {
                object = document.layers[id];
            } else if (document.all) {
                object = document.all[id];
            } else if (document.getElementById) {
                object = document.getElementById(id);
            }
            return object;
        }

        function trimEnter(dataStr) {
            return dataStr.replace(/(\r\n|\r|\n)/g, "");
        }

    </script>
</body>
</html>
