<%@ Page Language="C#" AutoEventWireup="true" CodeFile="e_Sugam_Report.aspx.cs"
    Inherits="e_Sugam_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import - Duty Intimation</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
            <div id="innerbox_MidMain_Transact_popup_new" >
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        e-Sugam Report
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>
                <div id="tag_transaction_inner_new">
                    <div id="tag_Exchange_lft_in1_new1" style="margin-top: 10px;">
                        <div id="tag_label_transaction_Src_new">
                            Job No
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1" 
                                TabIndex="1" onselectedindexchanged="ddlJobNo_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                     
                      <div id="txtcon-m_transaction_code">
                         <asp:Button ID="btnSearch" CssClass="generate" runat="server"  OnClientClick="open_jobno(); return false"/>
                         <%--<asp:Button ID="btnSearch" CssClass="generate" runat="server" Visible="false"
                              onclick="btnSearch_Click" />--%>
             
                        </div>
                     
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    
                        <div id="tag_label_transaction_popup_no_empty_new">
                        </div>
                       
                                            
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new" style="background-image:none">
                
                <div class="content" id="page-1" style="overflow:scroll;height:430px;width:960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:160px;" >
                         <div id="tag_transac_exp_drawback" style="width: 950px">
                        <div id="tag_label_transaction_exp_jobb">
                           Importer Name
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtImporter" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="2" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                     
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb" style="font-weight:bold">
                     Invoice Details
                    </div>
                      </div>

                      <div id="tag_transac_exp_drawback">
                    <div id="tag_label_transaction_exp_jobb">
                      Address
                    </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="3" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>

                        <div id="magnify_area"></div>

                        <div id="tag_label_transaction_exp_jobb">
                           Doucment Type
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                         <asp:TextBox ID="txt_DocumentType" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="16" CssClass="txtbox_none_Mid"></asp:TextBox>
                        </div>
                    </div>

                    

                    <div id="tag_transac_exp_drawback" style="width: 950px">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="4" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                      
                         <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                            Document No
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                          <asp:TextBox ID="txt_DocumentNo" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="17" CssClass="txtbox_none_Mid"></asp:TextBox>
                        </div>

                          <div id="tag_label_transaction_Src" style="width: 50px">
                            Date
                        </div>
                        <div id="txtcon-m_transaction_code">
                          <asp:TextBox ID="txt_Document_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="18" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                                 <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Document_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Document_Date"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>

                        </div>

                      </div>
                      <div id="tag_transac_exp_drawback" style="width: 950px">
                     <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAddress3" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="5" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>

                        <div id="magnify_area"></div>

                           <div id="tag_label_transaction_exp_jobb">
                             Quantity
                        </div>
                        <div id="txtcon-m_transaction_code">
                         <asp:TextBox ID="txt_Quantity" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="19" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                          Taxable Value(Rs.)
                        </div>
                        <div id="txtcon-m_transaction_code">
                         <asp:TextBox ID="txt_TotalValue" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="20" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                        </div>

                       
                    </div>
                   
                    <div id="tag_transac_exp_drawback" style="width: 950px">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="6"></asp:TextBox>
                        </div>

                          <div id="magnify_area">
                        </div>
                          <div id="tag_label_transaction_exp_jobb">
                         VAT/CST Value
                        </div>
                        <div id="txtcon-m_transaction_code">
                         <asp:TextBox ID="txt_VAT_CST" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="21" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                        </div>

                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                        Other Amount(Rs)
                        </div>
                        <div id="txtcon-m_transaction_code">
                         <asp:TextBox ID="txt_OtherAmount" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="22" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                        </div>
                        </div>
                      
                      <div id="tag_transac_exp_drawback" style="width: 950px">
                      <div id="tag_label_transaction_exp_jobb">
                          
                        </div>
                    
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAddress5" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="7" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                          <div id="tag_label_transaction_exp_jobb">
                          Total Invoice Value
                        </div>
                        <div id="txtcon-m_transaction_code">
                         <asp:TextBox ID="txt_TotalInvoice_Value" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="23" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                        </div>
                         <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                         Despatch Date
                        </div>
                        <div id="txtcon-m_transaction_code">
                         <asp:TextBox ID="txt_Despatch_Date" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="24" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>

                                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Despatch_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Despatch_Date"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                        </div>
                     
                    </div>


                     <div id="tag_transac_exp_drawback" style="width: 950px">
                        <div id="tag_label_transaction_exp_jobb">
                           Importer TIN No
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_Importer_PINNO" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="8" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>

                         <div id="tag_label_transaction_exp_jobb" style="width: 130px">
                       Nature of Transaction
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1" >
                         <asp:TextBox ID="txt_Nature_Transaction" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="25" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
   
                    </div>

                     <div id="tag_transac_exp_drawback" style="width: 950px">
                        <div id="tag_label_transaction_exp_jobb">
                         Supplier Name
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtSupplierName" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="9" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width: 130px">
                              Name of Commodity
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_Commodity" runat="server" MaxLength="35" ClientIDMode="Static" TextMode="MultiLine" Width="400px"
                                                TabIndex="25" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                                              
                    </div>




                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                          Address
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_Sup_Address1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="10" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                      <%--  <div id="tag_label_transaction_exp_jobb">
                            Ass. Value
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAss_Value" runat="server" MaxLength="35" ClientIDMode="Static" TextMode="MultiLine"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>--%>
                                              
                    </div>

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                             
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_Sup_Address2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_gen" style="font-weight:bold; width:200px">
                           Transporter's Detail
                        </div>
                <%--    <div id="Div6">
                         <asp:TextBox ID="txtDirect_InDirect" runat="server" MaxLength="35" ClientIDMode="Static" TextMode="MultiLine"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>--%>
                                              
                    </div>

                    
                     <div id="tag_transac_exp_drawback" style="width:950px;">
                        <div id="tag_label_transaction_exp_jobb">
                          
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_Sup_Address3" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="12" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>  

                         <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_popup_gen">
                          Transporter Name
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_TransporterName" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="26" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>  
                    </div>

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                          
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_Sup_Address4" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="13" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>      
                         <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_popup_gen">
                          Vehicle No.
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_VehicleNo" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="27" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>                 
                                              
                    </div>

                    <div id="tag_transac_exp_drawback" >
                        <div id="tag_label_transaction_exp_jobb">
                          Dispatch Goods
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_DispatchGoods" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="14" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>     
                        <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_popup_gen">
                         LR/GR No.
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_LG_GR" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="28" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>                  
                                              
                    </div>

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                          Supplier TIN No
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_Sup_TINNO" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="15" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>    
                          <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_popup_gen">
                        Probable Receipt of Date
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_ReceiptDate" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="29" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                                 <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_ReceiptDate"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_ReceiptDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                        </div>                      
                                              
                    </div>
                  
                    </div>
                    

 <!-- Buttons Place Here -->
                <div id="innerbox_MidMain_bot_transact_invoice" style="margin-top: 215px;">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"  OnClick="btnNew_Click"
                            OnClientClick="jQuery('#form1').validationEngine('hide');" TabIndex="35" Visible="false"  />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save"  OnClick="btnSave_Click" OnClientClick="return validate_Invoice();"
                            TabIndex="29" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates"  OnClick="btnUpdate_Click"
                            OnClientClick="return validate_Invoice();" TabIndex="30" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server"  TabIndex="31" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'e-Sugam Report', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="37" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnDelete_Click"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" 
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                       <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="win_hide();parent.adcodewindow.hide();return false;"
                        tabindex="32" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                        <%--<input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()"
                            tabindex="38" id="btnCancel" />--%></div>
                  
                </div>
                <!-- Buttons Place Here -->

                </div>
                <div class="content" id="page-2" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_export_invoice_Iframe">
                    </iframe>
                </div>
                <div class="content" id="page-3" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_export_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-4" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_igm_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-5" style="display:none;">
                  
                </div>
                <div class="content" id="page-6" style="display:none;">
                   
                </div>
                <div class="content" id="page-7" style="display:none;">
                   
                </div>
                <div class="content" id="page-8" style="display:none;">
                    
                </div>
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        body
        {
            font-size: 62.5%;
        }
    </style>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
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
        function close_button() {
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        
    </script>

     <script type="text/javascript">

         function open_jobno() {

             if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                     NewWindow1('../NIPPON/e_Sugam_ReportViewer.aspx?jobno=' + f + '', 'List', '885', '1024', 'yes');

                     //opennew_Import_report(f);
                     return false
                     //alert(f);
                 }
             }

         }
     </script>
</body>
</html>
