<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SW_Control_Details.aspx.cs"
    Inherits="SW_Control_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item | Transaction</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

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
               
                 <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:660px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                    Cont.Type Code           
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:DropDownList ID="ddlCont_type_code" runat="server" TabIndex="1" class="chosen-select-deselect" AutoPostBack="true"
                            Style="width: 215px; font-family: Arial,Helvetica,sans-serif;" data-placeholder="Choose Control Code"
                             OnSelectedIndexChanged="ddlCont_type_code_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                   
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                     Cont. Start Date
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Cont_Start_Date" runat="server"  MaxLength="11" 
                            TabIndex="3" CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>

                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Cont_Start_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_Cont_Start_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>

                    </div>
                </div>
                  <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:660px;">
                  <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Cont. Location                  
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:TextBox ID="txt_Cont_Location" runat="server"  MaxLength="17" TabIndex="4" Width="210px"
                            CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                    </div>
                   
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                          Cont. End Date
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Cont_End_Date" runat="server" TabIndex="5" MaxLength="11" 
                            CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                           <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_Cont_End_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_Cont_End_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:660px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                      Cont. Result Code
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:DropDownList ID="ddl_ResultCode" runat="server" TabIndex="6" class="chosen-select-deselect"
                            Style="width: 215px; font-family: Arial,Helvetica,sans-serif;" data-placeholder="Choose Result Code">
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_Cont_ResultCode" MaxLength="16" runat="server" TabIndex="6" CssClass="txtbox_none_Mid_transac_Supp_Name" 
                        Width="210px" Visible="false" placeholder="BE No | Inv.Sl.No | Item.Sl.No"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                      Cont. Result Text 
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Cont_Result_Text" MaxLength="4000" runat="server" TabIndex="7" CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
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

                        <div id="editbu" style="width:112px;">
                                
                                             </div>

                                             <div id="editbu">
                                              <div id="tag_label_transaction_popup_IGM_invoice_Supp_others"  style="width:61px;">
                                                Sr. No                   
                                              </div>
                       
                                             </div>

                                             <div id="editbu">
                                                  <div id="txtcon-m_transaction_item_maindet">
                                                 <asp:TextBox ID="txt_Sr_No" runat="server" CssClass="validate[required,custom[integer]] txtbox_none_Mid_transac_item_maindet"
                                                 ClientIDMode="Static"
                                                    TabIndex="8" MaxLength="4"></asp:TextBox>
                                                    </div>
                                             </div>

                </div>
                <div id="tag_transac_lft_Item_reimport_Grid_area" style=" overflow:auto; height:162px;">
                    <asp:GridView ID="gv_ReImport" runat="server" DataKeyNames="SW_CONTROL_ID" EmptyDataText="NO RECORD FOUND"
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
                            <asp:BoundField DataField="CONTROL_TYPE_CODE" HeaderText="Control Type Code" >
                                <ItemStyle CssClass="column_style_left5"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_LOCATION" HeaderText="Control Location" >
                                <ItemStyle CssClass="column_style_left5"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_START_DATE" HeaderText="Control Start Date">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_END_DATE" HeaderText="Control End Date">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_RESULT_CODE" HeaderText="Control Result Code">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_RESULT_TEXT" HeaderText="Control Result Text ">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SLNO" HeaderText="Sr. No ">
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
      <asp:HiddenField ID="hdn_Result_code_chk" runat="server" />

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

    
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>




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
     
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }

        </script>

        <script type="text/javascript">
            $(document).ready(function () {
                $('#btnUpdate,#btnSave').click(function () {
                    document.getElementById("hdn_Result_code_chk").value = '';
                    var Cont_type_code = document.getElementById("ddlCont_type_code").value;

                    if (Cont_type_code == 'DUC - Durable Container...') {
                        if (document.getElementById("txt_Cont_ResultCode").value == '') {
                            jAlert('Cont. Result Code - Mandatory', 'SW - CONTROL', function (r) { document.getElementById("txt_Cont_ResultCode").focus(); });
                            return false;

                        }
                    }

                    var ResultCode = document.getElementById("txt_Cont_ResultCode").value;
                    if (ResultCode != '' && ResultCode.toUpperCase() != 'NORE') {

                        var cnt = ResultCode.split('|').length - 1;
                        /* hide on 25-09-2024 by Chithra Sugg.by Bala sir
                        if (cnt != 4) {
                            $("#txt_Cont_ResultCode").focus();
                            document.getElementById("hdn_Result_code_chk").value = 'Invalid';
                            jAlert('Cont_ResultCode Should be - BE No || Inv.Sl.No || Item.Sl.No', 'SW - CONTROL', function (r) { document.getElementById("txt_Cont_ResultCode").focus(); });
                            return false;
                        }

                        var count = ResultCode.split('||').length - 1;
                        if (count != 2) {
                            $("#txt_Cont_ResultCode").focus();
                            document.getElementById("hdn_Result_code_chk").value = 'Invalid';
                            jAlert('Cont_ResultCode Should be - BE No || Inv.Sl.No || Item.Sl.No', 'SW - CONTROL', function (r) { document.getElementById("txt_Cont_ResultCode").focus(); });
                            return false;
                        }
                        */

                        if (cnt != 2) {
                            $("#txt_Cont_ResultCode").focus();
                            document.getElementById("hdn_Result_code_chk").value = 'Invalid';
                            jAlert('Cont_ResultCode Should be - BE No | Inv.Sl.No | Item.Sl.No', 'SW - CONTROL', function (r) { document.getElementById("txt_Cont_ResultCode").focus(); });
                            return false;
                        }

                        var count = ResultCode.split('|').length - 1;
                        if (count != 2) {
                            $("#txt_Cont_ResultCode").focus();
                            document.getElementById("hdn_Result_code_chk").value = 'Invalid';
                            jAlert('Cont_ResultCode Should be - BE No | Inv.Sl.No | Item.Sl.No', 'SW - CONTROL', function (r) { document.getElementById("txt_Cont_ResultCode").focus(); });
                            return false;
                        }
                    }
                });
            });
</script>

</body>
</html>
