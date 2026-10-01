<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exp_Billing_Others_Details.aspx.cs" Inherits="Exp_Billing_Others_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ADCode Master | Updation</title>
<%--       <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />--%>

    <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />

    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
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
            <div id="innerbox_MidMain_Trans_IGM">
                <div class="content" id="page-1">
                    <div id="trans_IGM_details_Main_Cont1">


                         <div id="pop_text_area_transac_popup_inn_container_IGM" style="height: 240px; margin-left: 0px;
                            width: 930px; margin-top: 15px;">
                            <div id="pop_text_area_transac_popup_inn_container_left_IGM" style="height: 240px;width: 920px;">


                            <div id="tag_transac_lft_IGM_in1" style="width:800px;">
                                <div id="tag_label_transaction_popup_IGM">
                                   GST Bill No
                                </div>
                               <div id="txtcon_m_transaction_IGM_Airnamenew"  style="width: 300px;">
                                  <span style="color:Green"> <asp:Literal ID="lbl_Invno" runat="server"></asp:Literal> </span>
                               </div>
                               </div>



                            <div id="tag_transac_lft_IGM_in1" style="width:800px;">
                                    <div id="tag_label_transaction_popup_IGM">
                                        Special Job Type</div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew"  style="width: 130px;" >
                                        <asp:DropDownList ID="ddl_Jobtype" runat="server" TabIndex="3">
                                            <asp:ListItem Value="CAPITAL GOODS" Text="CAPITAL GOODS" ></asp:ListItem>
                                            <asp:ListItem Value="USED CAPITAL"  Text="USED CAPITAL" ></asp:ListItem>
                                            <asp:ListItem Value="RE-IMPORT"  Text="RE-IMPORT" ></asp:ListItem>
                                            <asp:ListItem Value="OTHERS"  Text="OTHERS" ></asp:ListItem>
                                            <asp:ListItem Value="SEZ ZONE"  Text="SEZ ZONE" ></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM" style="width: 50px;">
                                        CBM
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 115px;">
                                        <asp:TextBox ID="txtCBM" runat="server" CssClass="txtbox_none_Mid_transac_code" MaxLength="20"
                                            TabIndex="4"></asp:TextBox>
                                    </div>

                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM" style="width: 70px;">
                                        FCL/LCL
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 100px;">
                                       <asp:DropDownList ID="ddl_FCL" runat="server" Width="100px" TabIndex="5">
                                       <asp:ListItem Text="FCL" Value="FCL"></asp:ListItem>
                                       <asp:ListItem  Text="LCL" Value="LCL"></asp:ListItem>
                                       </asp:DropDownList>
                                    </div>
                                </div>

                                 <div id="tag_transac_lft_IGM_in1" style="width:800px;">
                                    <div id="tag_label_transaction_popup_IGM">
                                        Voyage</div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew"  style="width: 130px;" >
                                        <asp:TextBox ID="txt_Voyage" runat="server" CssClass="txtbox_none_Mid_transac_code" MaxLength="20" TabIndex="6"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM" style="width: 50px;">
                                        Vessel
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 115px;">
                                        <asp:TextBox ID="txt_Vessel" runat="server" CssClass="txtbox_none_Mid_transac_code" MaxLength="20" TabIndex="7"></asp:TextBox>
                                    </div>
                                    
                                </div>
                               
                                <div id="tag_transac_lft_IGM_in1" style="width: 900px;">
                                    <div id="tag_label_transaction_popup_IGM">
                                        MBL Number</div>
                                    <div id="txtcon-m_transaction_code" style="width: 130px;">
                                        <asp:TextBox ID="txtMBLNo" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="10" onkeypress="return charnum2(event)"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label2_transaction_popup_IGM">
                                        MBL Date</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtMBLDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="10" TabIndex="13"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtMBLDate"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtMBLDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                </div>
                                <div id="tag_transac_lft_IGM_in1" style="width: 900px;">
                                    <div id="tag_label_transaction_popup_IGM">
                                        HBL Number</div>
                                    <div id="txtcon-m_transaction_code" style="width: 130px;">
                                        <asp:TextBox ID="txtHBLNo" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="14" onkeypress="return charnum2(event)"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label2_transaction_popup_IGM">
                                        HBL Date</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtHBLDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="10" TabIndex="16"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtHBLDate"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtHBLDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                </div>
                               
                                <div id="tag_transac_lft_IGM_in1" style="width: 900px;">
                                    <div id="tag_label_transaction_popup_IGM">
                                        Accout Head</div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 610px;">
                                        <asp:TextBox ID="txt_Acc_Head" runat="server" Width="600px" MaxLength="100" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                                            TabIndex="17"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_IGM_in1" style="width: 800px;">
                                    <div id="tag_label_transaction_popup_IGM">
                                        Cleared Date</div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 120px;">
                                        <asp:TextBox ID="txt_Cleared_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="18"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Cleared_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Cleared_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM" style="width: 90px;">
                                        Created Date
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 120px;">
                                        <asp:TextBox ID="txt_Created_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="19"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txt_Created_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_Created_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM" style="width: 120px;">
                                        Amendment Date
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 120px;">
                                        <asp:TextBox ID="txt_Amendment_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="20"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txt_Amendment_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txt_Amendment_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_IGM_in1" style="width: 800px;">
                                    <div id="tag_label_transaction_popup_IGM">
                                        Empty Handover Dt</div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 120px;">
                                        <asp:TextBox ID="txt_Empty_Handover_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="21"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt_Cleared_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_Empty_Handover_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM" style="width: 90px;">
                                        SB Date
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 120px;">
                                        <asp:TextBox ID="txt_SB_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="22"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_SB_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_SB_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                </div>

                                 <div id="tag_transac_lft_IGM_in1" style="width:800px;">
                                    <div id="tag_label_transaction_popup_IGM">
                                        Sales Person</div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew"  style="width: 120px;" >
                                    <asp:TextBox ID="txt_SalesPerson" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="19"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM" style="width: 90px;">
                                        Doc User
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width:120px;">
                                        <div id="txtcon-m_transaction_code_BE_TYPE" style="width: 142px;">
                                            <asp:DropDownList ID="ddl_DocUser" runat="server" CssClass="listtxt_transac_mode_new"
                                                Width="110px" TabIndex="20">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                      <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    
                                </div>
                               
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="margin-top: 10px">
                            <div id="innerbox_transac_bot_inn" style="width: 503px;">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" TabIndex="29" CssClass="new" OnClick="btnNew_Click"
                                        OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                                        UseSubmitBehavior="false" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" ValidationGroup="dt"
                                        OnClientClick="return validation();" TabIndex="26" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                                        OnClick="btnUpdate_Click" Visible="false" TabIndex="26" OnClientClick="return validation();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="27" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'BILLING - OTHERS', function(r) {
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
                                <div id="editbu">
                                    <input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()"
                                        tabindex="28" id="btnCancel" />
                                </div>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
           
           
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1']);
    </script>


     <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

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
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>



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
   
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });

    </script>

 
</body>
</html>
