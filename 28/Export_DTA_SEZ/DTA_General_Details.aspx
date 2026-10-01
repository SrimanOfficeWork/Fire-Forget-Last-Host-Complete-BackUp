<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DTA_General_Details.aspx.cs" Inherits="DTA_General_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ETP Master | Updation</title>
<%--       <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />--%>

    <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />

    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
            <div id="innerbox_MidMain_Trans_IGM"  style="height:415px;">
                <ol id="toc">
                    <li style="height:20px"><a href="#page-1" onclick="tab_page1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="GENERAL"><span>DTA General </span></a></li>
                    <%--<li style="height:20px"><a href="#page-2" onclick="tab_page2('0'); jQuery('#form1').validationEngine('hideAll')"
                         id="ITEM" runat="server"><span>Item View</span></a></li>--%>
                        
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_exp_popup_inn_container_left_invoice" style="width:920px; height:350px;">
                    <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 450px; font-family:Verdana; font-size:small; font-weight:bold;">
                    SEZ Unit Details
                    </div>
                    <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 470px;  font-family:Verdana; font-size:small; font-weight:bold;">
                    DTA Unit Details
                    </div>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px;">
                                Sez Unit Code <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                                 <asp:TextBox ID="txt_SezUnitCode" runat="server" MaxLength="20" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="1"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px; ">
                              Sez Unit Name <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_SezUnitName" runat="server" MaxLength="70" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="2"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" >
                            </div>
                             
                             <div id="tag_label_transaction_popup_IGM_invoice" style="width: 105px;">
                               DTA Unit GSTIN <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                                 <asp:TextBox ID="txt_DTA_Unit_GSTIN" runat="server" MaxLength="50" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px; ">
                              DTA Unit PAN 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_DTA_Unit_PAN" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="10"></asp:TextBox>
                            </div>
                          
                            
                        </div>
                        <%---------------------------------------Row 2------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                         <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px;">
                                Sez Unit Addr. <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                                <asp:TextBox ID="txt_SezUnitAddress" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="3" MaxLength="300" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px; height: 15px;">
                                Sez City <span style="color: Red;">* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_SezCity" runat="server" MaxLength="70" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="4"></asp:TextBox>
                            </div>
                            
                             <div id="tag_label_transaction_popup_IGM2_empty" >
                            </div>
                             
                             <div id="tag_label_transaction_popup_IGM_invoice" style="width: 105px;">
                               DTA Unit Name 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                                 <asp:TextBox ID="txt_DTA_UnitName" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="11"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px; ">
                              DTA Unit Addr. 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_DTA_UnitAddress" runat="server" MaxLength="300" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="12"></asp:TextBox>
                            </div>
                        </div>
                        <%---------------------------------------Row 3------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                                Sez State <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                                <asp:TextBox ID="txt_SezState" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="5" MaxLength="70"></asp:TextBox>
                            </div>

                             <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                                Sez PinCode <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_SezPinCode" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="6" MaxLength="20"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>
                             <div id="tag_label_transaction_popup_IGM_invoice" style="width: 105px;">
                               DTA Unit City 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                                 <asp:TextBox ID="txt_DTA_UnitCity" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px; ">
                              DTA Unit State 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_DTA_UnitState" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="14"></asp:TextBox>
                            </div>
                        </div>
                         <%---------------------------------------Row 3-II-----------------------------------------%>
                        
                        <%---------------------------------------Row 4------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                                IEC Code <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                                <asp:TextBox ID="txt_IEC_Code" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="7" MaxLength="20"></asp:TextBox>
                            </div>

                             <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                                Sez GSTIN <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_SezGSTIN" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="8" MaxLength="20"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 105px;">
                               DTA Unit Pincode 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                                 <asp:TextBox ID="txt_DTA_UnitPincode" runat="server" MaxLength="20" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="15"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px; ">
                              DTA Unit IEC 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:TextBox ID="txt_DTA_UnitIEC" runat="server" MaxLength="20" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="16"></asp:TextBox>
                            </div>
                        </div>
                         <%---------------------------------------Row 5------------------------------------------%>
                         <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px;">
                               IGST Declaration 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                              <asp:DropDownList ID="ddl_Declaration_of_IGST" runat="server" Width="100px" CssClass="listtxt_transac_FCL" TabIndex="17">
                              <asp:ListItem></asp:ListItem>
                              <asp:ListItem>LUT - Supply under Bond/LUT</asp:ListItem>
                              <asp:ListItem>PAY - Supply under Payment of IGST</asp:ListItem>

                              </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                              LUT Number
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                               <asp:TextBox ID="txt_LUT_Number" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="18" MaxLength="30"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 105px;">
                                 LUT Date
                            </div>
                             <div id="txtcon-m_transaction_code" style="width: 100px;">
                                 <asp:TextBox ID="txt_LUT_Date" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                     TabIndex="19" MaxLength="20"></asp:TextBox>
                                 <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_LUT_Date"
                                     Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                     MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                 </asp:MaskedEditExtender>
                                 <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_LUT_Date"
                                     Format="dd/MM/yyyy">
                                 </asp:CalendarExtender>
                             </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 120px;">
                               Types of DTA Unit 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 53px;">
                              <asp:DropDownList ID="ddl_DTA_Unit_Type" runat="server" Width="100px" CssClass="listtxt_transac_FCL" TabIndex="20">
                              <asp:ListItem>R - Merchant Exporter</asp:ListItem>
                              <asp:ListItem>F - Mfg. Exporter</asp:ListItem>
                              <asp:ListItem>S - Service Provider</asp:ListItem>

                              </asp:DropDownList>
                            </div>
                        </div>

                        <%---------------------------------------Row 6------------------------------------------%>
                         <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                         <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; font-weight:bold;">
                               ARE Applicable?
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 95px;">
                                <asp:CheckBox ID="chk_ARE_YN" runat="server" Checked="false" onclick="jQuery('#form1').validationEngine('hideAll')"
                                                TabIndex="21" />
                            </div>
                             <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                             Addl Remarks
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 540px;">
                               <asp:TextBox ID="txt_AddlRemarks" Width="540px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr" TextMode="MultiLine"
                                    TabIndex="22" MaxLength="300"></asp:TextBox>
                            </div>
                         </div>

                          <%---------------------------------------Row 7------------------------------------------%>
                         <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px;">
                               ARE Number
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                              <asp:TextBox ID="txt_ARE_Number" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="23" MaxLength="30"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                              ARE Date
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                               <asp:TextBox ID="txt_ARE_Date" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="24" MaxLength="20"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_ARE_Date"
                                     Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                     MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                 </asp:MaskedEditExtender>
                                 <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_ARE_Date"
                                     Format="dd/MM/yyyy">
                                 </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 105px;">
                                 Range
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 100px;">
                                 <asp:TextBox ID="txt_ARE_Range" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="25" MaxLength="20"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 120px;">
                               Division 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 53px;">
                              <asp:TextBox ID="txt_ARE_Division" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="26" MaxLength="20"></asp:TextBox>
                            </div>
                        </div>

                        <%---------------------------------------Row 8------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px;">
                               Address
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                              <asp:TextBox ID="txt_ARE_Address" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="27" MaxLength="300"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_export_invoice" style="width: 100px;">
                               Commissionerate 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                               <asp:TextBox ID="txt_ARE_Commissionerate" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="28" MaxLength="20"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 105px;">
                                ARE Duty Amt 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 100px;">
                                 <asp:TextBox ID="txt_ARE_DutyAmount" Width="100px" runat="server" CssClass="txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="29" MaxLength="30"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>

                        <%---------------------------------------Row 9------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px; margin-top:5px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 600px;">
                                Are you availing facility of CENVAT Credit under CENVAT Credit Rules, 2001?
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                                <asp:RadioButtonList ID="RDL_Cenvat" runat="server" RepeatDirection="Horizontal" TabIndex="30">
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <%---------------------------------------Row 8------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 600px;">
                               Are you availing facility under Notification 41/2001 - Central Excise (N.T) Dated 26th June, 2001?
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           <div id="txtcon-m_transaction_code" style="width: 110px;">
                              <asp:RadioButtonList ID="RDL_CentralExcise_41" runat="server"  RepeatDirection="Horizontal" TabIndex="30" >
                              <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                              </asp:RadioButtonList>
                            </div>
                        </div>

                        <%---------------------------------------Row 8------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 600px;">
                               Are you availing facility under Notification 43/2001 - Central Excise (N.T) Dated 26th June, 2001? 
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px;">
                              <asp:RadioButtonList ID="RDL_CentralExcise_43" runat="server"  RepeatDirection="Horizontal" TabIndex="30" >
                               <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                              </asp:RadioButtonList>
                            </div>
                        </div>

                        <%---------------------------------------Row 9------------------------------------------%>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                        
                        </div>
                          <%---------------------------------------Row 10------------------------------------------%>
                        <div id="innerbox_MidMain_bot_transact" style="margin-top: 0px">
                            <div id="innerbox_transac_bot_inn" style="width: 900px;">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" TabIndex="37" Visible="false" 
                                        CssClass="new" OnClick="btnNew_Click"
                                        OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                                        UseSubmitBehavior="false" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" ValidationGroup="dt"
                                        OnClientClick="return validation();" TabIndex="35" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                                        OnClick="btnUpdate_Click" Visible="false" TabIndex="36" 
                                        OnClientClick="return validation();" />
                                </div>

                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="38" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'EXPORT DTA ITEM', function(r) {
                                          var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn').click();
                                          }
                                          else {
                                          }
                                         });return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="27" CausesValidation="false" UseSubmitBehavior="false"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                                        CssClass="dlete" Style="display: none;" />
                                </div>
                                 <div id="editbu" style="width:120px"></div>
                                <div id="editbu" style="width: 120px">
                                    <asp:Button ID="btnNewChkList" Text="CheckList" CssClass="autowidmovebut" runat="server"
                                        OnClientClick="open_jobnoNew(); return false" Width="80px" />
                                </div>
                                <div id="editbu" style="width:150px">
                                   <asp:Button ID="btn_Json" Visible="false" runat="server" Width="120px" CausesValidation="false" UseSubmitBehavior="false" 
                                   CssClass="autowidmovebut" Text="Generate Json" 
                                    onclick="btn_Json_Click" /> 
                                </div>
                                 <div id="txtcon_m_transaction_IGM_Airnamenew" style="margin-top: 5px; width: 70px;">
                                <asp:ImageButton ID="imgbtnFlatFile" runat="server" ImageUrl="~/images/icons/Json.jpg"
                                   TabIndex="41" Width="38px" Height="28px" OnClientClick="Print_open();Loading();" />
                            </div>
                                <div id="editbu" style="width:350px">
                                <div id="txtcon-m_transaction_code" style="width:400px;margin-top:15px;">
                                   <span style=" font-weight:bold; color:Green; "> <asp:Literal ID="lblmsg" runat="server"></asp:Literal></span>
                                   </div>
                                 </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
           <asp:HiddenField ID="HDupdate_id" runat="server" />
           <asp:HiddenField ID="hdn_Jobno" runat="server" />

               
            </a>
                  
                </span>
                  
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1']);
    </script>


    </form>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>

    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Autotab.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>

    <script src="../js/Export_Jscript/Export_ETP.js" type="text/javascript"></script> 
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

     <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        var win = null;

        function Print_open() {
            win = window.open('../FlatFile/Open_FileDownload.aspx?Query=' + 'DTA_SEZ_Json' + '', 'ndf');
            Loading_HideImage();
        }
        

        
    </script>

      <script type="text/javascript">
          function open_jobnoNew() {

              var f = document.getElementById("<%=hdn_Jobno.ClientID %>").value;
           
              NewWindow1('../Export_DTA_SEZ/Export_DTA_ReportViewerNew.aspx?jobno=' + f + '', 'List', '810', '1024', 'yes');
              return false;

          }
  </script>
 
</body>
</html>
