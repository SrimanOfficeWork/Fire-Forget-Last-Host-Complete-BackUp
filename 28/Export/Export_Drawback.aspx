<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Drawback.aspx.cs"
    Inherits="Export_Export_Drawback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Annexure C1 | Transaction</title>
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
                        <div id="tag_label_transaction_exp_draw">
                            Drawback SL No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtDrawback_SLNo" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                ClientIDMode="Static" onkeypress="return charnum2(event)" MaxLength="15" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupDrawback('EXPORT_DrawbackNo',document.getElementById('hdn_UnitCode').value); return false"
                                class="magnfy"></a>
                        </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="div_AmendmentType" visible="false"  runat="server">
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
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw">
                            Drawback Qty
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtDrawback_Qty" runat="server" CssClass="validate[required,custom[number]] txtbox_trans_exp_drawback"
                                onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="2" MaxLength="12"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_draw2_new1" style="width:115px;">
                            Drawback Unit
                        </div>
                        <div id="txt_trans_exp_drawback_new">
                            <asp:TextBox ID="txtDrawback_Unit"  runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" onblur="ChangeCase(this);" onkeypress="return cha(event)"
                                TabIndex="3" MaxLength="3"></asp:TextBox>
                        </div>
                        <div id="txtcon-m_transaction_item_maindet">
                            No Of Unit
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtDrawback_No_Of_Unit" Width="50px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_item_maindet"
                              onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);"  ClientIDMode="Static" TabIndex="4" MaxLength="4"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw">
                            Drawback Rate
                        </div>
                        <div id="txt_trans_exp_drawback">
                        <asp:TextBox ID="txtDrawback_Rate" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="5" MaxLength="12"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_draw2_new1" style="width:115px;">
                            Drawback Cap
                        </div>
                        <div id="txt_trans_exp_drawback" >
                            <asp:TextBox ID="txtDrawback_Cap" runat="server" CssClass="txtbox_trans_exp_drawback" 
                                onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);"  ClientIDMode="Static" MaxLength="12" TabIndex="6"></asp:TextBox>
                        </div>
                    </div>

                    <span id="ROSL" runat="server" visible="false">
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw">
                           State lev. Adv. Rate
                        </div>
                        <div id="txt_trans_exp_drawback">
                        <asp:TextBox ID="txtstate_level_adv_Rate" runat="server" CssClass="txtbox_trans_exp_drawback"
                                ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="6" MaxLength="12"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_draw2_new1" style="width:115px;">
                             State lev. Adv. Amt
                        </div>
                        <div id="txt_trans_exp_drawback"  >
                            <asp:TextBox ID="txtstate_level_adv_Amt" runat="server" CssClass="txtbox_trans_exp_drawback"
                            ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);"
                                 MaxLength="12" TabIndex="6"></asp:TextBox>
                        </div>
                    </div>

                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_draw">
                          Central lev. Adv.Rate
                        </div>
                        <div id="txt_trans_exp_drawback">
                        <asp:TextBox ID="txtCentral_level_adv_Rate" runat="server" CssClass="txtbox_trans_exp_drawback"
                                ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="6" MaxLength="12"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_exp_draw2_new1" style="width:115px;">
                             Central lev. Adv.Amt
                        </div>
                        <div id="txt_trans_exp_drawback"  >
                            <asp:TextBox ID="txtCentral_level_adv_Amt" runat="server" CssClass="txtbox_trans_exp_drawback"
                            ClientIDMode="Static" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);"
                                 MaxLength="12" TabIndex="6"></asp:TextBox>
                        </div>
                    </div>
                    </span>
                    <div id="tag_transac_exp_drawback_multi">
                        <div id="tag_label_transaction_exp_draw">
                            Drawback Desc
                        </div>
                        <div id="txt_trans_exp_drawback_multitxt">
                            <asp:TextBox ID="txtDrawback_Desc" runat="server" TextMode="MultiLine" CssClass="txtbox_trans_exp_drawback_multiline"
                                MaxLength="300" ClientIDMode="Static" onkeyDown="return checkTextAreaMaxLength(this,event,'300');" Height="100px" Width="458px"
                                onpaste="return checkTextAreaMaxLength(this,event,'300');" TabIndex="7"></asp:TextBox>
                        </div>
                    </div>
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
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'DRAWBACK', function(r) {
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
 
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:HiddenField ID="HDN_GET_DBKSLNO_PRODUCT" runat="server" />
    <asp:HiddenField ID="HDN_GET_DESCRIPTION_PRODUCT" runat="server" />
    <asp:HiddenField ID="Hdn_RITC_4_digit" runat="server" />
    <asp:HiddenField ID="hdn_UnitCode" runat="server" />
    <asp:HiddenField ID="Hdn_ROSL" runat="server" />
    <asp:HiddenField ID="hdn_item_qty" runat="server" />
    <asp:HiddenField ID="hdn_Same_Diff" runat="server" />
    <asp:HiddenField ID="hdn_companyID" runat="server" />
    <asp:HiddenField ID="hdn_Draw_ID" runat="server" />


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
