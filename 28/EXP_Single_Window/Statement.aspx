<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Statement.aspx.cs"
    Inherits="Statement" %>

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
            $("#txt_Statement_Type").bind('keyup', function (e) {
                $("#txt_Statement_Type").val(($("#txt_Statement_Type").val()).toUpperCase());

            });
            //Diana Added
            $('#txt_Statement_Code').keyup(function () {
                var data = $(this).val();
                var SplitData = data.split('-');
                console.log('SplitData', SplitData);
                $('#txt_Statement_Code').val(SplitData[0].toString());
            });
            $('#txt_Statement_Code').keydown(function () {
                var data = $(this).val();
                var SplitData = data.split('-');
                console.log('SplitData', SplitData);
                $('#txt_Statement_Code').val(SplitData[0].toString());
            });
            $('#txt_Statement_Code').keypress(function () {
                var data = $(this).val();
                var SplitData = data.split('-');
                console.log('SplitData', SplitData);
                $('#txt_Statement_Code').val(SplitData[0].toString());
            });
            $('#txt_Statement_Code').change(function () {
                var data = $(this).val();
                var SplitData = data.split('-');
                console.log('SplitData', SplitData);
                $('#txt_Statement_Code').val(SplitData[0].toString());
            });
            $('#txt_Statement_Code').keydown(function (e) {
                if (e.key === 'Tab') {
                    var data = $(this).val();
                    var SplitData = data.split('-');
                    console.log('SplitData', SplitData);
                    $('#txt_Statement_Code').val(SplitData[0].toString());
                }
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
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:660px; display:none">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                    Declaration Type          
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:30px;">
                        <asp:TextBox ID="txt_stmt_Declaration_Type"  MaxLength="1" Width="20px"  
                            runat="server"  CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="1"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:119px;" >
                       Declaration No.               
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_stmt_Declaration_No" MaxLength="7" Width="70px" 
                            TabIndex="2" runat="server" 
                          CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                             onblur="extractNumber(this,3,false);"
                             onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                             onkeypress="return blockNonNumbers(this, event, true, false);"
                        
                        ></asp:TextBox>
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                     <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" >
                       Declaration  Date              
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" >
                        <asp:TextBox ID="txt_stmt_Declaration_Date" runat="server" MaxLength="11" 
                            TabIndex="3" Width="100px"  CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>

                           <asp:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txt_stmt_Declaration_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txt_stmt_Declaration_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>

                </div>
                 <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:678px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                    Statement Type
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:70px;" >
                         <asp:TextBox ID="txt_Statement_Type" runat="server" Width="70px" 
                             ClientIDMode="Static" MaxLength="3" TabIndex="4" 
                             CssClass="txtbox_none_Mid_transac_Supp_Name"  onkeypress="return char(event);"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 104px;">
                         Statement Code 
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width:208px;">
                       <asp:TextBox ID="txt_Statement_Code" runat="server" MaxLength="7" 
                           Width="207px" TabIndex="5" AutoPostBack="true"
                            CssClass="txtbox_none_Mid_transac_Supp_Name" 
                            ontextchanged="txt_Statement_Code_TextChanged"  ></asp:TextBox>
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:50px;">
                         Sr. No
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width:80px;">
                      <asp:TextBox ID="txt_Sr_No" runat="server" CssClass="validate[required,custom[integer]] txtbox_none_Mid_transac_item_maindet"
                         ClientIDMode="Static" TabIndex="6" MaxLength="4"></asp:TextBox>
                    </div>
                   
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 660px; height: 55px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Statement Text
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 520px; height: 48px;">
                        <asp:TextBox ID="txt_Statement_Text" runat="server" MaxLength="60" TextMode="MultiLine"
                            ClientIDMode="Static" onkeypress="DisableSpecialKeyEvents(); return (event.keyCode!=13);"
                            onkeyDown="return checkTextAreaMaxLength(this,event,'4000'); return (event.keyCode!=13);"
                            onpaste="return checkTextAreaMaxLength(this,event,'4000');" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new3"
                            TabIndex="7" Width="520px" Height="48px"></asp:TextBox>
                    </div>
                </div>

                 <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>

            
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty_Re_import">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" TabIndex="10" 
                            OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="7"
                            OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="7" OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="8" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'SW Statement', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="8" OnClick="btnDelete_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                      <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('ItemMain');return false;"
                        tabindex="9" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button();"
                            tabindex="14" id="btnCancel" />--%></div>
                             <div id="tag_label_transaction_popup_IGM2_empty"></div>
                             <div id="div_AmendmentType" runat="server" style="margin-top:8px;">
                                <div id="tag_label_transaction_popup_gen" style="width: 135px; font-weight: bold;">
                                    Amendment Type
                                </div>
                                <div id="txtcon-m_transaction_item_maindet" style="width: 120px">
                                    <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="8" CssClass="listtxt_transac_mode_new"
                                        Width="120px">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="A">AMENDMENT</asp:ListItem>
                                        <asp:ListItem Value="S">SUPPLEMENT</asp:ListItem>
                                        <asp:ListItem Value="D">DELETE</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                </div>
                <div id="tag_transac_lft_Item_reimport_Grid_area" style=" overflow:auto; height:149px;">
                    <asp:GridView ID="gv_ReImport" runat="server" DataKeyNames="SW_ID  ,JOBNO" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%" 
                        ShowHeaderWhenEmpty="True" OnRowDataBound="gv_ReImport_RowDataBound"
                        OnSelectedIndexChanged="gv_ReImport_SelectedIndexChanged" PageSize="6" AllowPaging="False"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_ReImport_RowCreated">
                        <Columns>
                         <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="26px">
                                        <ItemTemplate>
                                        <asp:Label ID="lblitemslno"   runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  HorizontalAlign="Center"  Width="26px"  />
                           </asp:TemplateField>

                            <asp:BoundField DataField="STMT_TYPE" HeaderText="Stmt. Type." ControlStyle-Width="40px">
                                <ItemStyle CssClass="column_style_left5" Width="40px"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="STMT_CODE" HeaderText="Stmt Code" ControlStyle-Width="40px">
                                <ItemStyle CssClass="column_style_left5" Width="70px"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="STMT_TEXT" HeaderText="Statement Text" ControlStyle-Width="70px">
                                <ItemStyle CssClass="column_style_left5" Width="70px"/>
                            </asp:BoundField>
                           <asp:BoundField DataField="SLNO" HeaderText="Sr. No" ControlStyle-Width="45px">
                                <ItemStyle CssClass="column_style_left5" Width="45px"/>
                            </asp:BoundField>
                        </Columns>

                      

                    </asp:GridView>
                </div>
            </div>
            <asp:HiddenField ID="hdn_update_STMT" runat="server" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
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
    <script src="../js/Import_Jscript/IMP_Single_Window.js" type="text/javascript"></script>

</body>
</html>
