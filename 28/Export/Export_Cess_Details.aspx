<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Cess_Details.aspx.cs" Inherits="Export_Export_Cess_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cess Details</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
     <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />

     <script src="../js/Export_Jscript/Export_Item.js" type="text/javascript"></script>

 

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
        
        .hideGridColumn1
        {
            display: none;
        }
    </style>

    <script type="text/javascript">

        function check_Values() {
            var tariff_val_l = document.getElementById("txtTar_Value").value;
            var cess_val_l = document.getElementById("txtCess_Value").value;

            var tariff_val = tariff_val_l.trim();
            var cess_val = cess_val_l.trim();

//            alert(cess_val.length);
            txtCess_Value.disabled = false;
            txtCess_Unit.disabled = false;
            txtTar_Value.disabled = false;
            txtTar_Unit.disabled = false;

            if (tariff_val != '' ) {

                txtCess_Value.disabled = true;
                txtCess_Unit.disabled = true;
                txtTar_Value.disabled = false;
                txtTar_Unit.disabled = false;

            }
           
            else if (cess_val != '') {

                txtTar_Value.disabled = true;
                txtTar_Unit.disabled = true;
                txtCess_Value.disabled = false;
                txtCess_Unit.disabled = false;

            }
            else {

              txtTar_Value.disabled = false;
              txtTar_Unit.disabled = false;
              txtCess_Value.disabled = false;
              txtCess_Unit.disabled = false;
              }
          
        }
    
    </script>


    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
          
                         
                    <div id="innerbox_MidMain_Trans_export_annexure_Main" style="margin-top:-5px;" >

                        <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                            <div id="tag_label_transaction_export_Item_otherdet">
                                Serial No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width: 120px">
                                <asp:TextBox ID="txtSerial_No" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                    ClientIDMode="Static" MaxLength="17" onkeypress="return Num_Dot_Spl(event);"
                                    TabIndex="5" Width="120px"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Export_CESS_MASTER('Export_CESS');"
                                    onfocus="check_Values();"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>




                        <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                            <div id="tag_label_transaction_export_Item_otherdet">
                                Cess Value
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtCess_Value" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="6"></asp:TextBox>
                            </div>
                        </div>


                        <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                            <div id="tag_label_transaction_export_Item_otherdet">
                                Cess Unit
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtCess_Unit" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    onkeypress="return char2(event)" MaxLength="3" TabIndex="7"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                            <div id="tag_label_transaction_export_Item_otherdet">
                                Cess Flag</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtCess_Flag" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="8" MaxLength="3"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                            <div id="tag_label_transaction_export_Item_otherdet">
                                Cess Rate
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtCess_Rate" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                            <div id="tag_label_transaction_export_Item_otherdet">
                                Cess Qty</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <%-- <asp:TextBox ID="txtCess_Qty" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                      onkeypress="return blockNonNumbers(this, event, true, false);"  TabIndex="10" MaxLength="15"></asp:TextBox>--%>
                                <asp:TextBox ID="txtCess_Qty" MaxLength="15" runat="server" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_Supp_Name"
                                    onblur="extractNumber(this,3,false);remove_zero_after_decimal_point(this.value,'txtCess_Qty');"
                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    TabIndex="10"></asp:TextBox>
                            </div>
                        </div>

                        <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                            <div id="tag_label_transaction_export_Item_otherdet">
                                Tar Value
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtTar_Value" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="8"
                                    TabIndex="11"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                            <div id="tag_label_transaction_export_Item_otherdet">
                                Tar Unit</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtTar_Unit" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    onkeypress="return char2(event)" TabIndex="12" MaxLength="3"></asp:TextBox>
                            </div>
                        </div>

                            <div id="innerbox_MidMain_bot_transact_invoice" style="background-color:White; margin-top:9px;"">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="15" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" TabIndex="13"
                                         />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                        TabIndex="14"  />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="16" Visible="false" CssClass="dlete"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Cess Details', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="17" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                        CssClass="dlete" Style="display: none;" />
                                </div>
                                <div id="editbu">
                                    <input type="submit" value="Submit" class="scancel" onclick="parent.parent.adcodewindow.hide()"
                                        tabindex="10" id="btnCancel" />
                                </div>
                            </div>
                        <div id="tag_transac_export_lft_item_gen_Grid_area_new1" style="height: 160px; margin-top: 10px;">
                            <asp:GridView ID="gv_Item" runat="server" DataKeyNames="CESS_ID" EmptyDataText="NO RECORD FOUND"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="150%"
                                ShowHeaderWhenEmpty="True" PageSize="12" AllowPaging="True" OnRowDataBound="gv_Item_RowDataBound"
                                OnPageIndexChanging="gv_Item_PageIndexChanging" OnSelectedIndexChanged="gv_Item_SelectedIndexChanged"
                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" OnRowCreated="gv_Item_RowCreated">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="46px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemslno" runat="server" CssClass="column_style_right" Width="16px"
                                                Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="46px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CESS_SLNO" HeaderText="Cess SlNo">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CESS_VALUE" HeaderText="Cess Value">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CESS_UNIT" HeaderText="Cess Unit">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CESS_FLAG" HeaderText="Cess Flag">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CESS_RATE" HeaderText="Cess Rate">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CESS_ITEM_QTY" HeaderText="Cess Item Qty">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CESS_TARIFF_VALUE" HeaderText="Cess Tarrif Value">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CESS_TARIFF_UNIT" HeaderText="Cess Tarrif Unit">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                      </div>
                   
               
            </div>
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdn_inv_slno" runat="server" />
            <asp:HiddenField ID="hdn_item_slno" runat="server" />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="Hdn_RITCNO" runat="server" />


        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1']);
    </script>
    </form>

    <script src="../js/Export_Jscript/Export_Cess.js" type="text/javascript"></script>
   


    <script src="../js/Export_Jscript/Export_Goods_Reg_AR4.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Autotab.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    

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

     <script type="text/javascript">
         function pin(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 27 && (charCode < 48 || charCode > 57))
                 return false;
             return true;
         }

         function Num_Dot_Spl(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 32 && (charCode < 65 || charCode > 91) && (charCode < 97 || charCode > 122) && (charCode < 48 || charCode > 57) && (charCode < 40 || charCode > 41) && (charCode < 93 || charCode > 93) && (charCode < 46 || charCode > 46))
                 return false;
             return true;
         }

         function check_char(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                 return false;
             return true;
         }

         </script>
            <script src="../js/Import_Jscript/Import_IGM.js" type="text/javascript"></script>
           <script src="../js/Import_Jscript/Import_IGM.js" type="text/javascript"></script>
</body>
</html>
