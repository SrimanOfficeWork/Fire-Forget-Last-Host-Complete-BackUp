<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SW_Constituent_Details.aspx.cs"
    Inherits="SW_Constituent_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item | Transaction</title>
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
    $(document).ready(function () {
        $("#txt_Active_Ingredient_Y_N").bind('keyup', function (e) {
            $("#txt_Active_Ingredient_Y_N").val(($("#txt_Active_Ingredient_Y_N").val()).toUpperCase());
        });
    });
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
            <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier" style="margin-top:20px;">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Cons. Sr. No. 
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:TextBox ID="txt_Constituent_Sr_No" runat="server" MaxLength="7" CssClass="validate[required,custom[integer]] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="1" onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Cons. Ele. Name
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                         <asp:TextBox ID="txt_Constituent_Ele_Name" runat="server"   CssClass="txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="2" MaxLength="256" ></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Cons. Ele. Code
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:TextBox ID="txt_Cons_Ele_Code" runat="server"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"  TabIndex="3" MaxLength="17"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                       Cons. Percentage
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Cons_Percentage" runat="server"  
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                             onblur="extractNumber(this,3,false);"
                             onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                             onkeypress="return blockNonNumbers(this, event, true, false);"
                             TabIndex="4" MaxLength="9" ></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                         Cons. Yield %   </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:TextBox ID="txt_Cons_Yield_Percentage" runat="server"  
                             CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                             onblur="extractNumber(this,3,false);"
                             onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                             onkeypress="return blockNonNumbers(this, event, true, false);"
                             TabIndex="5" MaxLength="9"></asp:TextBox>
                    </div>
                   
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Act. Ingredient (Y/N) 
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                         <asp:TextBox ID="txt_Active_Ingredient_Y_N" runat="server"   CssClass="txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="6" MaxLength="1"  onkeypress="return char1(event);"></asp:TextBox>
                    </div>
                </div>

                 <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>

             
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty_Re_import">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="12"
                            OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="12" OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="13" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'SW Constituent', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="13" OnClick="btnDelete_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                      <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('ItemMain');return false;"
                        tabindex="14" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button();"
                            tabindex="14" id="btnCancel" />--%></div>
                </div>
                <div id="tag_transac_lft_Item_reimport_Grid_area" style=" overflow:auto; height:139px;">
                    <asp:GridView ID="gv_ReImport" runat="server" DataKeyNames="SW_CONST_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="180%" 
                        ShowHeaderWhenEmpty="True" OnRowDataBound="gv_ReImport_RowDataBound" OnPageIndexChanging="gv_ReImport_PageIndexChanging"
                        OnSelectedIndexChanged="gv_ReImport_SelectedIndexChanged" PageSize="5" AllowPaging="True"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_ReImport_RowCreated">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="CONSTITUENT_SRNO" HeaderText="Cons.Sr.No." ControlStyle-Width="45px">
                                <ItemStyle CssClass="column_style_left5" Width="45px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONSTITUENT_ELEMENT_NAME" HeaderText="Cons.Element Name" >
                                <ItemStyle CssClass="column_style_left5"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONSTITUENT_ELEMENT_CODE" HeaderText="Cons.Element Code">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONSTITUENT_PERCENTAGE" HeaderText="Cons. Percentage">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONSTITUENT_YIELD_PERCENTAGE" HeaderText="Cons. Yield %">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ACTIVE_INGREDIENT" HeaderText=" Act.Ingredient (Y/N) ">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                          
                        </Columns>

                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                     <PagerStyle CssClass="pager" />

                    </asp:GridView>
                </div>
            </div>
            <asp:HiddenField ID="hdn_update_Reimport" runat="server" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />

             <asp:HiddenField ID="hdn_Normal_Bulk" runat="server" />

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
                     <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>


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
</body>
</html>
