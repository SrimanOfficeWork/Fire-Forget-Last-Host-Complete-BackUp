<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_DTA_Invoice.aspx.cs"
    Inherits="Export_DTA_Invoice1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Export_DTA_Invoice</title>
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
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .hideGridColumn
        {
            display: none;
        }
    </style>
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
 
       <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
   <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>

   
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
            <div id="innerbox_MidMain_Trans_export_annexure_Main">
                <div id="pop_text_area_transac_inn_container_left_export_drawback" style="height:255px">
                    <div id="tag_transac_exp_drawback">
                    </div>

                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw" style="width: 155px; font-weight: bold;">
                            DTA Invoice Applicable
                        </div>
                        <div id="txt_trans_exp_drawback">
                          <asp:CheckBox ID="chk_DTA_Applicable" runat="server" TabIndex="1"></asp:CheckBox>
                        </div>
                        
                         <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           
                    </div>
                    <div id="tag_transac_exp_drawback"></div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw" style="width: 180px;">
                            Nature Of Supply
                        </div>
                        <div id="txt_trans_exp_drawback">
                           <asp:DropDownList ID="ddl_NatureOfSupply" runat="server" TabIndex="2" CssClass="listtxt_transac_mode_new"
                                        Width="150px">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="Supply under LUT">Supply under LUT</asp:ListItem>
                                        <asp:ListItem Value="Supply after payment of IGST">Supply after payment of IGST</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                    </asp:DropDownList>
                        </div>
                       
                         <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                             <div id="tag_label_transaction_exp_draw"  style="width: 180px;">
                           Nature of Transaction
                        </div>
                             <div id="txt_trans_exp_drawback">
                            <asp:DropDownList ID="ddl_Nature_OfTransaction" runat="server" TabIndex="3" CssClass="listtxt_transac_mode_new"
                                        Width="150px">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="Sale">Sale</asp:ListItem>
                                        <asp:ListItem Value="Consignment">Consignment</asp:ListItem>
                                        <asp:ListItem Value="Hire">Hire</asp:ListItem>
                                        <asp:ListItem Value="Free of Cost">Free of Cost</asp:ListItem>
                                        <asp:ListItem Value="Rent">Rent</asp:ListItem>
                                        <asp:ListItem Value="Replacement">Replacement</asp:ListItem>
                                        <asp:ListItem Value="Gift">Gift</asp:ListItem>
                                        <asp:ListItem Value="Sample">Sample</asp:ListItem>
                                        <asp:ListItem Value="Sub-Contracting">Sub-Contracting</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                       
                                    </asp:DropDownList>
                        </div>
                    </div>

                      <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw" style="width: 180px;">
                            Duty Amount as per ARE
                        </div>
                          <div id="txt_trans_exp_drawback">
                              <asp:TextBox ID="txt_DutyAmt_ARE" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                  ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                  onkeypress="return blockNonNumbers(this, event, true, false);" Width="150px"
                                  TabIndex="4" MaxLength="30"></asp:TextBox>
                          </div>
                          <div id="tag_label_transaction_popup_IGM2_empty">
                          </div>
                       
                    </div>
                    <div id="tag_transac_exp_drawback">
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw" style="width: 170px; font-weight: bold;">
                            DTA Invoice Value
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                            <asp:Label ID="lbl1" runat="server" Text=":"></asp:Label>
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:Label ID="lbl_DTA_InvoiceValue" runat="server" Font-Bold="true"></asp:Label>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_draw" style="width: 170px; font-weight: bold;">
                            DTA Invoice Value(INR)
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                            <asp:Label ID="Label1" runat="server" Text=":"></asp:Label>
                        </div>
                        <div id="txt_trans_exp_drawback_new">
                            <asp:Label ID="lbl_DTA_InvoiceValue_INR" runat="server" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw" style="width: 170px; font-weight: bold;">
                            IGST Amount in (INR)
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                            <asp:Label ID="Label2" runat="server" Text=":"></asp:Label>
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:Label ID="lbl_DTA_IGST_AMT_INR" runat="server" Font-Bold="true"></asp:Label>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_draw" style="width: 170px; font-weight: bold;">
                            Cess Amount in (INR)
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                            <asp:Label ID="Label3" runat="server" Text=":"></asp:Label>
                        </div>
                        <div id="txt_trans_exp_drawback_new">
                            <asp:Label ID="lbl_DTA_CESS_AMT_INR" runat="server" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback"></div>
                   
                </div>
                <div id="innerbox_MidMain_bot_transact_invoice">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            Visible="false" OnClientClick="jQuery('#form1').validationEngine('hide');" TabIndex="10"
                            OnClick="btnNew_Click" /></div>
                    <div id="editbu">
                         <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="Confirm();return validate_Export_Drawback();" OnClick="btnSave_Click" 
                          TabIndex="8" /></div>
                    <div id="editbu">

                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates"  OnClientClick="Confirm();return validate_Export_Drawback();" OnClick="btnUpdate_Click"
                            TabIndex="8" /></div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="9" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'EXPORT DTA ITEM', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="9"  OnClick="btnDelete_Click" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1('ITEM_ID');return false;"
                            tabindex="10" id="btnCancel" /></div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

       <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
     <asp:HiddenField ID="HDupdate_id" runat="server" />
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

   


</body>
</html>
