<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_DTA_Items.aspx.cs"
    Inherits="Export_DTA_Items" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Export_DTA_Items</title>
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

     <script type="text/javascript">
         function HideModalPopup() {
             $find("MPEU").hide();
             return false;
         }
         function Drawback_DEEC() {
             NewWindow1('../Export/Export_License_Details.aspx?Scheme=DEEC&License_Scheme=DEEC', 'List', '1010', '350', 'yes');
         }
         function Drawback_EPCG() {
             NewWindow1('../Export/Export_License_Details.aspx?Scheme=EPCG&License_Scheme=EPCG', 'List', '1010', '350', 'yes');
         }
         function Drawback_jobbing() {
             NewWindow1('../Export/Export_Jobbing.aspx', 'List', '810', '470', 'yes');
         }

       </script>

       
 <script type = "text/javascript">
     function Confirm() {

         var item_unit = document.getElementById("hdn_UnitCode").value;
         var dbk_unit = document.getElementById("txtDrawback_Unit").value;

         var item_qty = document.getElementById("hdn_item_qty").value;
         var dbk_qty = document.getElementById("txtDrawback_Qty").value;

         var x = '', y = '';
         // if (item_qty.includes(".000") || dbk_qty.includes(".00")) {
//         if (item_qty.indexOf(".000") != "-1" || dbk_qty.indexOf(".00") != "-1") {
//             var x = item_qty.split(".");
//             x = x[0];
//             item_qty = x;
//         }

//         //if (dbk_qty.includes(".000") || dbk_qty.includes(".00")) {
//         if (dbk_qty.indexOf(".000") != "-1" || dbk_qty.indexOf(".00") != "-1") {
//             y = dbk_qty.split(".");
//             y = y[0];
//             dbk_qty = y;
//         }

         if (item_unit == dbk_unit) {
//             if (item_qty != dbk_qty) {
             if (Number(item_qty) != Number(dbk_qty)) {
                 var answer = confirm("DBK Qty Not match With Item Qty, Do u want Save?")

                 if (answer == true) {
                     $('#hdn_Same_Diff').val('Same');
                 }
                 else {
                     $('#hdn_Same_Diff').val('Diff');
                 }
             }
             else {
                 $('#hdn_Same_Diff').val('Same');
             }
         }
         else {
             $('#hdn_Same_Diff').val('Same');
         }
     }
 </script>

 <script type="text/javascript">

     function Show_Mismatch_RITC() {
         alert('DBK Slno Not match with RITC No');
     }
 </script>

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
                        <div id="tag_label_transaction_exp_draw" style="width: 135px; font-weight: bold;">
                            DTA Item Applicable
                        </div>
                        <div id="txt_trans_exp_drawback" style="width: 35px;">
                          <asp:CheckBox ID="chk_DTA_Applicable" runat="server" TabIndex="58"></asp:CheckBox>
                        </div>
                        
                         <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           <div id="tag_label_transaction_exp_draw" style="width: 335px; font-weight: bold;">
                             <asp:Label ID="lbl_Inv_Status" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                            
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback"></div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw" style="width: 180px;">
                            Item Type
                        </div>
                        <div id="txt_trans_exp_drawback">
                           <asp:DropDownList ID="ddl_ItemType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                        Width="150px">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="Raw Material">Raw Material</asp:ListItem>
                                        <asp:ListItem Value="Manufactured Goods">Manufactured Goods</asp:ListItem>
                                        <asp:ListItem Value="Capital Goods- Others">Capital Goods- Others</asp:ListItem>
                                        <asp:ListItem Value="Consumables">Consumables</asp:ListItem>
                                        <asp:ListItem Value="By Product">By Product</asp:ListItem>
                                        <asp:ListItem Value="Waste/Scrap">Waste/Scrap</asp:ListItem>
                                        <asp:ListItem Value="Spares & Accessories">Spares & Accessories</asp:ListItem>
                                        <asp:ListItem Value="Remaking">Remaking</asp:ListItem>
                                        <asp:ListItem Value="Repair">Repair</asp:ListItem>
                                        <asp:ListItem Value="Packing Material">Packing Material</asp:ListItem>
                                        <asp:ListItem Value="Capital Goods- Building">Capital Goods- Building</asp:ListItem>
                                        <asp:ListItem Value="Capital Goods- Plant & Equipment">Capital Goods- Plant & Equipment</asp:ListItem>
                                        <asp:ListItem Value="Capital Goods- O & M">Capital Goods- O & M</asp:ListItem>
                                        <asp:ListItem Value="Traded Goods">Traded Goods</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>

                                        
                                    </asp:DropDownList>
                        </div>
                       
                         <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                             <div id="tag_label_transaction_exp_draw"  style="width: 180px;">
                           Amount of Rebate Claimed
                        </div>
                             <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_RebateClaimed_Amt"  runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                  onkeypress="return blockNonNumbers(this, event, true, false);"  Width="150px"
                                TabIndex="3" MaxLength="30"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw" style="width: 180px;">
                            IGST Notn No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_IGST_Notn"  runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" onblur="ChangeCase(this);" 
                                Width="150px" TabIndex="3" MaxLength="30"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_draw"  style="width: 180px;">
                           IGST Notn SlNo
                        </div>
                        <div id="txt_trans_exp_drawback_new">
                            <asp:TextBox ID="txt_IGST_NotnSl"  runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" onblur="ChangeCase(this);" Width="150px"
                                TabIndex="3" MaxLength="30"></asp:TextBox>
                        </div>
                    </div>
                   <%-- <div id="tag_transac_lft_trans_export_in1_Inv" style="width: 910px; margin-bottom: 0px;">
                         <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; font-weight:bold;">
                               Is GST Exempt?
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 105px;">
                                <asp:CheckBox ID="chk_GSTExempt_YN" runat="server" Checked="false" onclick="jQuery('#form1').validationEngine('hideAll')"
                                                TabIndex="38" />
                            </div>
                         </div>--%>

                         <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw"  style="width: 180px;">
                            Compensation Cess Notn No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_Compen_Cess_Notn"  runat="server" CssClass=" txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" onblur="ChangeCase(this);" 
                                Width="150px" TabIndex="3" MaxLength="30"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_draw"  style="width: 180px;">
                           Compensation Cess Notn SlNo
                        </div>
                        <div id="txt_trans_exp_drawback_new">
                            <asp:TextBox ID="txt_Compen_Cess_NotnSl"  runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" onblur="ChangeCase(this);"   Width="150px"
                                TabIndex="3" MaxLength="30"></asp:TextBox>
                        </div>
                    </div>

                      <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw"  style="width: 180px;">
                            Cess Rate
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_CessRate"  runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                  onkeypress="return blockNonNumbers(this, event, true, false);"
                                Width="150px" TabIndex="3" MaxLength="30"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_draw"  style="width: 180px;">
                           Cess Amount
                        </div>
                        <div id="txt_trans_exp_drawback_new">
                            <asp:TextBox ID="txt_CessAmount"  runat="server" CssClass=" txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                  onkeypress="return blockNonNumbers(this, event, true, false);"   Width="150px"
                                TabIndex="3" MaxLength="30"></asp:TextBox>
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
                   
                </div>
                <div id="innerbox_MidMain_bot_transact_invoice">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            Visible="false" OnClientClick="jQuery('#form1').validationEngine('hide');" TabIndex="10"
                            OnClick="btnNew_Click" /></div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="8" /></div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
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
                        <asp:Button ID="btn" runat="server" TabIndex="9" OnClick="btnDelete_Click" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" CssClass="dlete"
                            Style="display: none;" />
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

  

    <script src="../js/Export_Jscript/Export_DrawBack.js" type="text/javascript"></script>
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
