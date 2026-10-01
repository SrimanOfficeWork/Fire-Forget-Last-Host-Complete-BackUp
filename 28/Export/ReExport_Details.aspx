<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReExport_Details.aspx.cs"
    Inherits="ReExport_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Re-Export </title>
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
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>


     <script type="text/javascript">
         function HideModalPopup_U() {

             $find("MP_U").hide();
             return false;
         }
</script>

<script type="text/javascript">

    function validatePaste(event) {
        var paste = (event.clipboardData || window.clipboardData).getData('text');
        var regex = /^[\x00-\x7F]+$/;
        if (!regex.test(paste)) {
            event.preventDefault();
            alert('Check the Spl Character');
        }
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
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        SB. No
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:95px;">
                        <asp:TextBox ID="txtSB_No" runat="server" MaxLength="7" CssClass="txtbox_none_Mid_transac_Supp_Name" Width="95px" Enabled="false"
                            TabIndex="1" onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        SB. Date
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                        <asp:TextBox ID="txtSB_Date" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" Width="95px" Enabled="false"
                            TabIndex="2" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtSB_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSB_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>

                       <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                  <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" >
                       Serial No
                   </div>
                   <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:95px;">
                         <asp:TextBox ID="txtSerial_No" runat="server" MaxLength="4" CssClass="validate[required]  txtbox_none_Mid_transac_Supp_Name" width="95px"
                            TabIndex="11" onkeypress="return num1(event)"></asp:TextBox>
                   </div>
                </div>
              
                  <%-- ------------------------------------------%>

                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                       BE Site
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:95px;">
                          <asp:TextBox ID="txtBE_Site" runat="server" MaxLength="6" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                            TabIndex="12" ></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                         BE No.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                        <asp:TextBox ID="txtBE_No" runat="server" MaxLength="7" CssClass="validate[required]  txtbox_none_Mid_transac_Supp_Name" width="95px"
                            TabIndex="13" onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                      <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                         BE Date
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                      <asp:TextBox ID="txtBE_Date" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                            TabIndex="14" onkeypress="return num1(event)"></asp:TextBox>

                             <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtBE_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBE_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>

                    </div>

                </div>

                  <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                       BE Invoice No
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:95px;">
                          <asp:TextBox ID="txt_BE_Inv_no" runat="server" MaxLength="5" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                            TabIndex="15" onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                         BE Item
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                      <asp:TextBox ID="txtBE_Item" runat="server" MaxLength="4" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                            TabIndex="16" onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                      <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                         Manual BE
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                        <asp:RadioButtonList ID="Rd_Manual_BE" runat="server" RepeatDirection="Horizontal" Font-Size="12px" TabIndex="17">
                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                </div>

                  <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                      BE Quantity Utilised
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:95px;">
                          <asp:TextBox ID="txtBE_Qty_Utilised" runat="server" MaxLength="20" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_Supp_Name"
                           width="95px"     onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                           onkeypress="return blockNonNumbers(this, event, true, false);"   TabIndex="20" ></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                         BE Item desc.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                        <asp:TextBox ID="txtBE_Item_Desc" runat="server" MaxLength="120" 
                        CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                        onkeypress="DisableSpecialKeyEvents(); checkTextAreaMaxLength_CompanyWise(this,event);"
                        onkeyDown="return (event.keyCode!=13);" onpaste="return validatePaste(event);"
                            TabIndex="21" ></asp:TextBox>
                            
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                      <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                          BE Qty
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                     <asp:TextBox ID="txtBE_Qty" runat="server" MaxLength="20" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                     onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                     onkeypress="return blockNonNumbers(this, event, true, false);"  
                     TabIndex="22" ></asp:TextBox>
                    </div>

                </div>
                  <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                       BE UQC
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:95px;">
                       <asp:TextBox ID="txtBE_UQC" runat="server" MaxLength="3" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                            TabIndex="23" ></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        BE Ass. Value (Rs)
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                       <asp:TextBox ID="txt_Ass_Value" runat="server" MaxLength="20" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                        onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);"  
                            TabIndex="24" ></asp:TextBox>
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                      <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                         BE Duty Paid
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                      <asp:TextBox ID="txt_Duty_paid" runat="server" MaxLength="16" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                       onblur="extractNumber(this,16,false);" onkeyup="extractNumber(this,16,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" 
                            TabIndex="25" ></asp:TextBox>
                    </div>

                </div>
                  <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                      Duty Payment Dt.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:95px;">
                        <asp:TextBox ID="txt_BE_Duty_payment_Date" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                            TabIndex="26" onkeypress="return num1(event)"></asp:TextBox>

                         <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_BE_Duty_payment_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_BE_Duty_payment_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                         BE Oth. Ident. Par.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                         <asp:TextBox ID="txt_BE_Oth_Ident_Parameter" runat="server" MaxLength="250" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                            TabIndex="27" ></asp:TextBox>
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                      <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        BE Ass. Value Claim
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                         <asp:TextBox ID="txt_BE_Ass_Value_Claim" runat="server" MaxLength="20" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" width="95px"
                         onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                         onkeypress="return blockNonNumbers(this, event, true, false);" 
                            TabIndex="28" ></asp:TextBox>
                    </div>

                </div>

                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                      BE Item Used
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:95px;">
                        <asp:RadioButtonList ID="Rd_BE_Item_Used" runat="server" RepeatDirection="Horizontal" Font-Size="12px" TabIndex="29">
                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                     Commisioner Perm.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                       <asp:RadioButtonList ID="Rd_Commisioner_Perm_Y_N" runat="server" RepeatDirection="Horizontal" Font-Size="12px" TabIndex="30">
                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                      <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                       Input Credit
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                        <asp:RadioButtonList ID="Rd_Input_Credit_Y_N" runat="server" RepeatDirection="Horizontal" Font-Size="12px" TabIndex="31">
                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Personal used
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:95px;">
                        <asp:RadioButtonList ID="Rd_Personal_used_Y_N" runat="server" RepeatDirection="Horizontal" Font-Size="12px" TabIndex="32">
                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                         Modvat availed
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                       <asp:RadioButtonList ID="Rd_Modvat_availed_Y_N" runat="server" RepeatDirection="Horizontal"
                                Font-Size="12px" TabIndex="33">
                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                            </asp:RadioButtonList>
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                      <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Modvat Repaid 
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:95px;">
                         <asp:RadioButtonList ID="Rd_Modvat_Repaid_Y_N" runat="server" RepeatDirection="Horizontal" Font-Size="12px" TabIndex="34">
                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                </div>
                
                
                
                
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty_Re_import">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" TabIndex="38"
                            OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="35"
                          />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="35" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="36" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'RE-EXPORT', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="36" OnClick="btnDelete_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                      <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('ItemMain');return false;"
                        tabindex="37" CausesValidation="false"
                        UseSubmitBehavior="false"/>
                       </div>

                <div id="editbu">
                        &nbsp;&nbsp;&nbsp; <a href="../Submission/Export_Excel_Format/EXPORT_ITEM_RE_EXPORT.xlsm" target="_new">
                            <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"
                                Height="30px" Width="30px" runat="server" />
                        </a>
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btngenexcel" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            CssClass="autowidmovebut" Text="Excel Upload" OnClientClick="jQuery('#form1').validationEngine('hide');open_EXP_Item_ReExport_Excel_Upload();return false;" />
                    </div>

                </div>
                <div id="tag_transac_lft_Item_reimport_Grid_area" style=" overflow:auto; height:80px;">
                    <asp:GridView ID="gv_ReExport" runat="server" DataKeyNames="RE_EXPORT_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%" 
                        ShowHeaderWhenEmpty="True" OnRowDataBound="gv_ReImport_RowDataBound" 
                        OnSelectedIndexChanged="gv_ReExport_SelectedIndexChanged"  AllowPaging="False"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_ReImport_RowCreated">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="44px">
                                        <ItemTemplate>
                                        <asp:Label ID="lblitemslno"   runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  HorizontalAlign="right"   Width="44px"  />
                             </asp:TemplateField>
                           <%-- <asp:BoundField DataField="SB_NO" HeaderText="SB No" ControlStyle-Width="45px">
                                <ItemStyle CssClass="column_style_left5" Width="45px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SB_DATE" HeaderText="SB Date" ControlStyle-Width="40px">
                                <ItemStyle CssClass="column_style_left5" Width="40px" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="SLNO" HeaderText="Sl.No">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_NO" HeaderText="BE No">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_DATE" HeaderText="BE Date">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                             <asp:BoundField DataField="BE_QTY_UTILISED" HeaderText="Qty Utilized" >
                                <ItemStyle CssClass="column_style_left5"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_OTH_IDENTIFIABLE_PARAMETER" HeaderText="BE Other Id" >
                                <ItemStyle CssClass="column_style_left5"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_ASS_VALUE_CLAIM" HeaderText="Ass Value" >
                                <ItemStyle CssClass="column_style_left5"  />
                            </asp:BoundField>
                         
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:HiddenField ID="hdn_update_ReExport" runat="server" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

 
       <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
             
             <tr>
                 <td style="padding-left: 125px; padding-top:10px;">
                     <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
  
    </form>
    <script src="../js/Import_Jscript/Import_ReImport.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script>


        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function OpenPopupImport_Port_House(val) {


            if (document.getElementById('hdfTransport_mode').value != '') {

                var s = document.getElementById('hdfTransport_mode').value;

                OpenPopupCustom_House_Details_Port(s, val);
                return false
            }
        }
   
    </script>

       <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>

     <script type="text/javascript">
         $(document).ready(function () {
             /* gridviewScroll();*/

             var totalRows = $("#<%=gv_ReExport.ClientID %> tr").length;
             var lastProductId = $("#<%=gv_ReExport.ClientID %> tr:last").children("td:first").html();


             if (totalRows > 2) {

                 gridviewScroll();

             }
             else {

                 if (lastProductId > 0) {
                     gridviewScroll();
                 }
                 else {
                     if (lastProductId > 0) {
                         gridviewScroll();
                     }
                     else {

                         document.getElementById('<%=gv_ReExport.ClientID %>').style.width = "100%";
                         document.getElementById('<%=gv_ReExport.ClientID %>').style.overflow = "100%";
                     }

                 }
             }
         });

         function gridviewScroll() {
             gridView1 = $('#<%=gv_ReExport.ClientID %>').gridviewScroll({

                 width: 694,
                 height: 160,
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

         function open_EXP_Item_ReExport_Excel_Upload(jobno, jobType) {

             NewWindow1('../Export_XL/Export_Item_ReExport_Excel.aspx?JOBID=' + jobno, 'List', '938', '385', 'yes');
         }

	</script>

</body>
</html>
