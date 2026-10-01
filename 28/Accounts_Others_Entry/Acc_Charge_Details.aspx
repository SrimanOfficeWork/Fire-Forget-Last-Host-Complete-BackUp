<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Charge_Details.aspx.cs"
    Inherits="Import_Acc_Charge_Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title></title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <style type="text/css">
        .hideGridColumn
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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 990px;
                height: 390px; background-color: #FFFFFF; margin-top: -5px;">
                <div id="tag_transac_lft_Inv_in1" style="height: 170px; width: 1000px;">
                    <div id="pop_text_area_transac_popup_inn_container_new" style="height: 155px; width: 675px;">
                        <div id="tag_transac_lft_Inv_in1" style="width: 670px; height: 35px; margin-top: 27px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 50px; margin-top: 5px;">
                                Inv.No :
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 150px; margin-top: 5px;">
                                <asp:Label ID="txtInvoice_No" runat="server" ForeColor="bLACK"></asp:Label>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 65px; margin-top: 5px;">
                                Order By
                            </div>
                            <div id="txtcon-m_transaction_Inv_No" style="width: 60px; margin-top: 5px;">
                                <asp:TextBox ID="TxtSi_no" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_Inv_No"
                                    onkeypress="return pin(event)" TabIndex="4" Width="25px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px; margin-top: 5px;">
                                From Quotation
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 60px; margin-top: 5px;">
                                <asp:CheckBox ID="From_Quotation" runat="server" TabIndex="4" Checked="true" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 670px; height: 34px;">
                            <div id="txtcon-m_transaction_Inv_No" style="width: 30px;">
                                <asp:CheckBox ID="chk" Checked="true" runat="server" Width="30px" TabIndex="5" />
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                                Charge Head
                            </div>
                            <div id="txtcon-m_transaction_Inv_No" style="width: 530px">
                                <asp:DropDownList ID="ddlcharge" runat="server" class="chosen-select-deselect" Style="width: 530px;"
                                    data-placeholder="Choose a Charge Name" TabIndex="6" AutoPostBack="True" OnSelectedIndexChanged="ddlcharge_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 670px; height: 36px;">
                            <div id="txtcon-m_transaction_Inv_No" style="width: 30px;">
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date" style="width: 90px; margin-top: 5px;">
                                Description
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 530px">
                                <asp:TextBox ID="TxtDescription" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_Inv_No"
                                    TabIndex="7" Width="530px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 670px; height: 20px;">
                           
                            <div id="tag_label_transaction_popup_Invoice_Date" style="width: 40px">
                                Cur
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 70px">
                                <asp:DropDownList ID="txtInvoiceCurrency" runat="server" Width="65px" Height="22px"
                                    Font-Size="12px" CssClass=" txtbox_trans_exp_drawback" TabIndex="9"
                                     onchange="Call__Inv_Currency_Excahnge_Rate();" onblur="Call__Inv_Currency_Excahnge_Rate();">
                                    <asp:ListItem Value="INR"></asp:ListItem>
                                    <asp:ListItem Value="USD"></asp:ListItem>
                                    <asp:ListItem Value="EUR"></asp:ListItem>
                                    <asp:ListItem Value="GBP"></asp:ListItem>
                                    <asp:ListItem Value="AUD"></asp:ListItem>
                                    <asp:ListItem Value="JPY"></asp:ListItem>
                                    <asp:ListItem Value="SGD"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width: 10px">
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date" style="width: 70px">
                                Cur Value
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 50px">
                                <asp:TextBox ID="txtCurrValue" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="10"
                                    Width="40px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width: 8px">
                            </div>
                             <div id="tag_label_transaction_popup_Invoice_Date" style="width: 35px">
                                Qty
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 55px">
                                <asp:TextBox ID="txtQty" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    onchange=" Amount();" onblur=" Amount();" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" oninput=" Amount();"
                                    TabIndex="10" Width="45px" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date" style="width: 70px; color: #008000;
                                display: none;">
                                Rate
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px; display: none;">
                                <asp:TextBox ID="txtRate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    onchange=" Amount();" onblur=" Amount();" TabIndex="11" ClientIDMode="Static"
                                    Width="100"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date" style="width: 70px; color: #008000;">
                                Unit Price
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 80px">
                                <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    onchange=" Amount();" onblur=" Amount();" onkeyup="Amount();extractNumber(this,2,false);Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" oninput=" Amount();"
                                    TabIndex="11" ClientIDMode="Static" Width="70px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width: 10px">
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date" style="width: 70px; display: none;">
                                Amount
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 100px; display: none;">
                                <asp:TextBox ID="txtAmt" runat="server" onkeyup="autotab(this);" onchange="Amount();"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="13" Width="90px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date" style="width: 60px; color: #008000;">
                                Amt INR
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px">
                                <asp:Label ID="txtAmtinr" runat="server" ForeColor="bLACK"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div id="pop_text_area_transac_popup_inn_container_rght_IGM" style="height: 150px;
                        width: 300px; margin-top: 25px;">
                        <div id="tag_transac_lft_Inv_in1" style="width: 290px; height: 32px; margin-top: 10px;">
                            <fieldset id="fld" style="width: 280px; height: 115px">
                                <legend style="border: white; border-collapse: collapse; width: 50px; text-align: center;
                                    height: 12px; margin-left: 60px;">GST </legend>
                                <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 27px">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; color: #0000FF;
                                        margin-left: 10px;">
                                        Tax Type
                                    </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 45px;">
                                        <asp:DropDownList ID="ddl_Tax" runat="server" Style="width: 35px;" data-placeholder=" "
                                            TabIndex="13">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="T" Value="T"></asp:ListItem>
                                            <asp:ListItem Text="N" Value="N"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 22px">
                                    <div id="tag_label_transaction_popup_Invoice_Date" style="width: 50px; color: #0000FF;
                                        margin-left: 10px;">
                                        IGST
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 50px">
                                        <asp:TextBox ID="txtGstRate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            TabIndex="13" Width="35px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 20px">
                                        %
                                    </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 120px">
                                        <asp:TextBox ID="txtGstAmt" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="14" Width="110px"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 22px">
                                    <div id="tag_label_transaction_popup_Invoice_Date" style="width: 50px; color: #0000FF;
                                        margin-left: 10px;">
                                        CGST
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 50px">
                                        <asp:TextBox ID="txtCgstRate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            TabIndex="15" Width="35px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px">
                                        %
                                    </div>
                                    <div id="txtcon_m_transaction_IGM_Wght_small" style="width: 120px">
                                        <asp:TextBox ID="txtCgstAmt" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="16" Width="115px"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 20px; margin-left: 10px;">
                                    <div id="tag_label_transaction_popup_IGM_Gen_Rght" style="width: 50px; color: #0000FF;">
                                        SGST
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 50px">
                                        <asp:TextBox ID="txtSgstRate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            TabIndex="17" Width="35px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 20px">
                                        %
                                    </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 120px">
                                        <asp:TextBox ID="txtSgstAmt" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="18" Width="115px"></asp:TextBox>
                                    </div>
                                </div>
                        </div>
                        </fieldset>
                    </div>
                </div>
                <div id="tag_transac_lft_Inv_in1" style="margin-top: -10px; width: 690px; height: 40px;">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="22" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                            OnClick="btnNew_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="19"
                            OnClientClick="return validate_Export_AnnexureC1_Air_Details();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="20" OnClientClick="return validate_Export_AnnexureC1_Air_Details();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="21" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Charge Details', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="20" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu" style="width: 110px">
                        <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Parent_close_button1();return false;"
                            TabIndex="79" CausesValidation="false" UseSubmitBehavior="false" /></div>
                    <div id="editbu">
                        <asp:Button ID="Button2" runat="server" TabIndex="20" Text="Convert Invoice" OnClientClick="
        jQuery('#form1').validationEngine('hideAll'); 
        var hiddenValue = document.getElementById('HiddenField_index').value; 
        var ImportJobNo = '<%= Connection.IMP_Jobno() %>'; 
        open_convert_inv_Imp(hiddenValue, ImportJobNo); 
        return false;"
                            Width="110px" Height="30px" Visible="False" />
                    </div>
                    <div id="editbu">
                        <asp:Label ID="lbl_Acc_Msg" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM" style="height: 30px;
                    width: 710px; margin-left: -1px; display: none;">
                    <asp:Label ID="Label1" runat="server" Text="Tax:" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label_Tax_Amt" runat="server" Width="73px" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Non-Tax:" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label_Non_Tax_Amt" runat="server" Width="63px" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Tot Amt :" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label_Tot_Amt" runat="server" Width="73px" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text="Taxable Amt :" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label_TA_Amt" runat="server" Width="73px" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label7" runat="server" Text="Grand Tot :" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label_GR_Amt" runat="server" Width="73px" ForeColor="Red"></asp:Label>
                </div>
                <div id="tag_transac_lft_IGM_Invoice_Grid_area" style="width: 975px; height: 185px;
                    margin-top: -8px;">
                    <asp:GridView ID="gv_details" runat="server" DataKeyNames="JOBNO,CHARGE_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="180%"
                        ShowHeaderWhenEmpty="True" PageSize="15" AllowPaging="True" AllowSorting="True"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                        OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound"
                        OnSelectedIndexChanged="gv_details_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="44px" HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="lblitemslno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="44px" />
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="CHARGE_ID" HeaderText="Charge id">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ORDER_BY" HeaderText="Ord.By">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="10px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHK_CHRG" HeaderText="Allow">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INV_NO" HeaderText="Invoice No">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHARGE_HEAD" HeaderText="Charge Head">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="520px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TAX_TYPE" HeaderText="Tax Type">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CURRENCY" HeaderText="Currency">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CURRENCY_VALUE" HeaderText="Cur Value">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BASIS" HeaderText="Basis">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QTY" HeaderText="Qty">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UNIT_PRICE" HeaderText="Unit Price">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AMOUNT_INR" HeaderText="Amount Inr">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IGST_RATE" HeaderText="Gst %">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IGST_AMOUNT" HeaderText="Amt">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CGST_RATE" HeaderText="Cgst %">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CGST_AMT" HeaderText="Amt">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SGST_RATE" HeaderText="Sgst %">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SGST_AMT" HeaderText=" Amt">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DESCRIPTION" HeaderText="Description">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="500px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <%-- </div>--%>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="display: none;">
        <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
        <asp:HiddenField ID="HiddenGstn" runat="server" />
        <asp:HiddenField ID="hdntotal" runat="server" />
        <asp:HiddenField ID="HiddenField_index" runat="server" />
        <asp:HiddenField ID="HiddenField_ImportJobNo" runat="server" />
        <asp:HiddenField ID="Hdn_amt_inr" runat="server" />
        <asp:HiddenField ID="hdn_TaxValue" runat="server" />
    </div>
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
                        <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/Accounts/Imp_Exp_Invoice_Tab.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }

        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }

        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }

        window.onload = function () {
           Amount();
        };
        function Amount() {

            var qty = parseFloat(document.getElementById("txtQty").value) || 0;
            var Cur = parseFloat(document.getElementById("txtCurrValue").value) || 0;
            var rate = parseFloat(document.getElementById("txtUnitPrice").value) || 0;
            document.getElementById('<%= txtAmtinr.ClientID %>').innerText = (qty * rate * Cur).toFixed(2);
            document.getElementById("Hdn_amt_inr").value = qty * rate * Cur;
            var Amtinr = parseFloat(document.getElementById('<%= txtAmtinr.ClientID %>').innerText) || 0;
            var Gst = parseFloat(document.getElementById("txtGstRate").value) || 0;
            var CGst = parseFloat(document.getElementById("txtCgstRate").value) || 0;
            var SGst = parseFloat(document.getElementById("txtSgstRate").value) || 0;
            var Gstn = '<%= Session["GSTN_OJ"]%>';
            var val = Gstn.slice(0, 2);
            var tax = document.getElementById("ddl_Tax").value;
            if ( tax === "T") {
                document.getElementById("txtGstAmt").value = (Amtinr * Gst / 100).toFixed(2);
          
                document.getElementById("txtCgstAmt").value = (Amtinr * CGst / 100).toFixed(2);
                document.getElementById("txtSgstAmt").value = (Amtinr * SGst / 100).toFixed(2);
            }

            if (tax === "N") {
                var Amt_nontax = parseFloat(document.getElementById('<%= txtAmtinr.ClientID %>').innerText);
                document.getElementById("txtGstAmt").value = "";
                document.getElementById("txtCgstAmt").value = "";
                document.getElementById("txtSgstAmt").value = "";
                document.getElementById("txtGstRate").value = "";
                document.getElementById("txtCgstRate").value = "";
                document.getElementById("txtSgstRate").value = "";
            }


        }

        function Call__Inv_Currency_Excahnge_Rate() {
            var ieccode = document.getElementById("txtInvoiceCurrency").value;

            var I_E = '<%= Session["IMP_EXP"]%>'; 

            if (ieccode.length == 3) {
             
                PageMethods.GetExchange_Rate_Invoice_Cur(ieccode, I_E, CallSuccess_Invoice_Cur);
            }

        }
        function CallSuccess_Invoice_Cur(res) {
            var data = res;
            document.getElementById("txtCurrValue").value = res;
            Amount();

        }
     


 
    </script>
</body>
</html>
