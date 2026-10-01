<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_SB_Entry.aspx.cs" Inherits="Export_General" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
            <div id="innerbox_MidMain_Transact_popup_new">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Transaction 
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="parent.adcodewindow.hide();return false;" />
                    </div>
               
                </div>
                <div id="tag_transaction_inner_new">
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new">
                            Job No
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtJobNo" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                MaxLength="10" ReadOnly="True" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_date">
                            Job Date
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtJobDate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                MaxLength="10" TabIndex="2"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        
                        <div id="tag_label_transaction_Src_longlabel">
                            Transport Mode</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="listtxt_transac_mode_new"
                                TabIndex="3">
                            </asp:DropDownList>
                        </div>
                       
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        
                        
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                     
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new">
                            SB Type</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlSBType" runat="server" CssClass="listtxt_transac_src1" 
                                TabIndex="4">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_date">
                            Custom House</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtCustomsHouse" runat="server" ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                onkeyup="ChangeCase(this);" onfocus="ChangeCase(this);" onblur="ChangeCase(this);"
                                onkeypress="return pin1(event)" MaxLength="50" TabIndex="5"></asp:TextBox>
                            <asp:HiddenField ID="hdn_CustomsHouse_Name" runat="server" ClientIDMode="Static" />
                        </div>
                      
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        
                        <div id="tag_label_transaction_popup_no_empty_new">
                        </div>
                     
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();"
                        id="General"><span>SB Entry</span></a></li>
                  
                </ol>
<div class="content" id="page-1">
                    <div id="area_transac_container_genral">
                     <div id="pop_text_area_transac_popup_inn_container_new">
                     <div id="tag_transac_lft_Trans_Invoice_transac_other_duty"></div>
                     <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                         <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                       Shipping Bill No.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:TextBox ID="txtSB_no" runat="server" 
                            CssClass="validate[required] txtbox_annuxrec_air1" MaxLength="7" TabIndex="6" 
                            ></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        FOB Value
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">

                     <asp:TextBox ID="txtFOB_Value" runat="server" 
                            CssClass="txtbox_annuxrec_air1" MaxLength="8" 
                            onblur="extractNumber(this,2,false);" 
                            onkeypress="return blockNonNumbers(this, event, true, false);" 
                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" TabIndex="7"></asp:TextBox>

                       
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Shipping Bill Date
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:TextBox ID="txtSB_Date" runat="server" MaxLength="10" CssClass="validate[required] txtbox_annuxrec_air1"
                            TabIndex="8" 
                            ></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtSB_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSB_Date"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                     DrawBack Value
                      
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                      
                       <asp:TextBox ID="txtDrawBack_Value" runat="server" CssClass="txtbox_annuxrec_air1" 
                            MaxLength="8" onblur="extractNumber(this,2,false);" 
                            onkeypress="return blockNonNumbers(this, event, true, false);" 
                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" TabIndex="9"></asp:TextBox>

                    </div>
                </div>
                
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                      PMV Value
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                       
                        <asp:TextBox ID="txtPMV_Value" runat="server" CssClass="txtbox_annuxrec_air1"
                            TabIndex="10" MaxLength="8" onblur="extractNumber(this,2,false);" 
                            onkeypress="return blockNonNumbers(this, event, true, false);" 
                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"></asp:TextBox>

                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                  
                 
                </div>
                   <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" >
                <span id="Exp_Amt" runat="server" visible="false">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                     Expense Amt
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                       
                        <asp:TextBox ID="txt_Expense_Amt" runat="server" MaxLength="20" CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                                   onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtItem_UnitPrice');return Clear_Dot(this);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                     TabIndex="12"></asp:TextBox>

                    </div>
                    </span>

                </div>

              <div id="tag_transac_lft_Trans_Invoice_transac_other_duty"></div>
                        <div id="innerbox_MidMain_bot_transact">
                            <div id="innerbox_transac_bot_inn">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="14" CausesValidation="false" Visible="false"
                                        UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                                        OnClick="btnNew_Click" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="11"
                                        OnClientClick="return validate_Export_AnnexureC1_Sea_Details();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                        TabIndex="12" 
                                        OnClientClick="return validate_Export_AnnexureC1_Sea_Details();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="17" CssClass="dlete"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'SB_ENTRY', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="17" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                        CssClass="dlete" />
                                </div>
                                <div id="editbu">
                                    <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                                        tabindex="18" id="btnCancel" /></div>
                            </div>
                        </div>
                        </div>
                         </div>
                    </div>

                <%--<div class="content" id="page-1">
                    <div id="area_transac_container_genral">
                        <asp:Panel ID="Panel1" runat="server">
                            <div id="pop_text_area_transac_popup_inn_container_export">
                                <div id="pop_text_area_transac_popup_inn_container_left_export">
                                   
                                   
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                            Ship No
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1">
                                            <asp:TextBox ID="txtAddress" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                         Ship Date
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1">
                                            <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="12" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                        PMV Value
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1">
                                            <asp:TextBox ID="txtAddress3" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                        FOB Value
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1">
                                            <asp:TextBox ID="txtAddress4" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="14" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1_export">
                                        <div id="tag_label_transaction_popup_gen_export">
                                        DrawBack Value
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1">
                                            <asp:TextBox ID="txtAddress5" runat="server" MaxLength="6" ClientIDMode="Static"
                                                TabIndex="15" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                        </div>
                                    </div>
                                   
                                  
                                 
                                   
                                   
                                   
                                </div>
                                <div id="pop_text_area_transac_popup_inn_container_rght_new_export">
                                    
                                
                                 
                                </div>
                            </div>
                            <div id="innerbox_MidMain_bot_transact" runat="server">
                                <div id="innerbox_transac_bot_inn">
                                    <div id="newbu">
                                        <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="34"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll')" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate1();"
                                            TabIndex="35" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                            TabIndex="35" OnClientClick="return validate1();" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnDelete" runat="server" TabIndex="36" CausesValidation="false"
                                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job?', 'GENERAL', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                        <asp:Button ID="btn" runat="server" TabIndex="36" OnClick="btnDelete_Click" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                          
                                    </div>
                                    <div id="editbu">
                                        <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                                            tabindex="37" id="btn_cancel" /></div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>--%>
             
              
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_SB_ID" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>

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
                     <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
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
</body>
</html>
