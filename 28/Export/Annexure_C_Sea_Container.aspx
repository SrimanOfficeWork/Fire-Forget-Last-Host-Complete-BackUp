<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Annexure_C_Sea_Container.aspx.cs"
    Inherits="Export_Annexure_C_Sea_Container" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

</head>
<body id="bg2popup">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="annexure_c_Container_main">
                <div id="annexure_c_Sea_main_inner_">
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_date">
                            Container No
                        </div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txtContainerNo" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="11" TabIndex="1" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_annuxeairC" style="width: 150px">
                            Seal Type Indicator
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddl_SealType_Indicator" runat="server" CssClass="listtxt_transac_mode_new"
                                ClientIDMode="Static" TabIndex="6" Width="70px">
                                <asp:ListItem>BTSL</asp:ListItem>
                                <asp:ListItem>ESEAL</asp:ListItem>
                                <asp:ListItem>RFID</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                    </div>
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_date">
                            Size</div>
                        <div id="txtcon_m_anncair">
                            <div id="txtcon_m_anncair">
                                <asp:DropDownList ID="ddlSize" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                    TabIndex="2">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_date" style="width: 150px">
                            Seal Device ID
                        </div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_Seal_ID" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="35" TabIndex="7" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_date">
                            Type</div>
                        <div id="txtcon_m_anncair">
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                TabIndex="3">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_annuxeairC" style="width: 150px">
                            Movement Doc.Type</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_Movement_DocType" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="15" TabIndex="8" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_date">
                            Excise Seal No
                        </div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txtExcise_Seal_No" runat="server" CssClass="txtbox_annuxrec_air1"
                                MaxLength="35" TabIndex="4" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_annuxeairC" style="width: 150px">
                            Movement Doc.Number</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_Movement_DocNo" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="15" TabIndex="9" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_date">
                            Seal Date
                        </div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txtSealDate" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="10" TabIndex="5"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtSealDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSealDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_Date">
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_Date">
                        </div>
                        <div id="tag_label_transaction_annuxeairC" style="width: 110px">
                            Select Excel File
                        </div>
                        <div id="txtcon-m_src_ItemMove">
                            <asp:FileUpload ID="fileuploadExcel" runat="server" />
                        </div>
                    </div>
                    <div id="innerbox_transac_bot_inn" style="width: 420px">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="10" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                                OnClick="btnNew_Click" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="11"
                                OnClientClick="return validate_Export_AnnexureC1_Sea_Container();" />
                        </div>
                         <div id="editbu">
                            <asp:Button ID="btn_Save_New" runat="server" Text="Save & New" CssClass="autowidupdatebut"  OnClick="btn_save_new_Click" TabIndex="11"
                                OnClientClick="return validate_Export_AnnexureC1_Sea_Container();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                TabIndex="11" OnClientClick="return validate_Export_AnnexureC1_Sea_Container();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="12" Visible="false" CssClass="dlete"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'ANNEXURE_C_CONTAINER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="12" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1('Annexure_Sea_Id');return false;"
                                tabindex="13" id="btnCancel" /></div>
                    </div>
                    <div id="tag_label_transaction_annuxeairC" style="width: 100px; color: Blue;">
                        Download Excel
                    </div>
                    <div id="editbu">
                        <a href="../Submission/Export_Excel_Format/EXPORT_ANNEXURE_SEA_CONTAINER.xlsx" target="_new">
                            <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"
                                Height="30px" Width="30px" runat="server" />
                        </a>
                    </div>
                    <div id="tag_label_transaction_popup_mode_empty">
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btn_BulkContainer_Upload" runat="server" CssClass="autowidmovebut"
                            Text="Upload" TabIndex="115" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            OnClick="btn_BulkContainer_Upload_Click" />
                    </div>
                    <div id="annexure_c_grid_cont" style="overflow: auto; background-color: White;">
                        <asp:GridView ID="gv_details" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                            CssClass="grid-view" AllowPaging="True" HorizontalAlign="Left" PageSize="6" DataKeyNames="ANNEX_SEA_CON_ID"
                            AllowSorting="True" BorderColor="#C8C8C8" ShowHeaderWhenEmpty="true" Width="90%"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" OnPageIndexChanging="gv_details_PageIndexChanging"
                            OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound"
                            OnSelectedIndexChanged="gv_details_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="44px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="44px" />
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:CommandField>
                                <asp:BoundField DataField="ANNEX_SEA_CON_CONTAINERNO" HeaderText="Container No">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_CON_SIZE" HeaderText="Size">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_CON_TYPE" HeaderText="Type">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_CON_EXCISE_SEALNO" HeaderText="Excise Seal No">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_CON_SEAL_DATE" HeaderText="Seal Date">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_CON_SEALTYPE_INDICATOR" HeaderText="Seal Type">
                                <ItemStyle CssClass="column_style_left" />
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_CON_SEAL_DEVICEID" HeaderText="Seal DeviceID">
                                <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_CON_DOC_TYPE" HeaderText="Seal Doc.Type">
                                <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                   
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_CON_DOC_NUMBER" HeaderText="Seal Doc.Number">
                                <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                   
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                            <PagerStyle CssClass="pager" />
                        </asp:GridView>
                        <br />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdn_update" runat="server" />
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
                     <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>

    <asp:ModalPopupExtender ID="mp_yesorno" runat="server" PopupControlID="Panel2" TargetControlID="Button3"
    CancelControlID="btnclose1" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
    <asp:Button ID="Button6" runat="server" style = "display:none"/>

<asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" align="center" style ="display:none;width:300px;height:140px;margin-top:-70px;" BorderColor="Transparent">
    <asp:Button ID="btnclose1" runat="server" style = "display:none"/>
   
  
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px;height:130px;">
                <div id="innerbox_MidMain_top_adcode_Itemmove" style="width:300px;">
                   Container 
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="$find('mp_yesorno').hide();" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode_Itemmove1">
                   
                    <div id="pop_text_area_ItemMove">
                        <div id="tag_label_adcode">
                           </div>
                        <div id="txtcon-m_src_ItemMove" style="width:300px;">
                               
                               <asp:Label ID="lbl_Excel_msg" runat="server" Text="Container already exists!.. delete all pervious Containers?"></asp:Label>
                        </div>
                    </div>
                    
                 
                </div>
           </div>
            <div id="innerbox_MidMain_top_adcode_Itemmove" style="width:300px;height:40px;">
                <div id="innerbox_adcode_bot_inn_ItemMove" style="float:right;padding-right:2px;width: 180px;">
                  
                  
                <div id="editbu">
                    
                      <asp:Button ID="btn_Delete_All_Invoice_And_Upload" runat="server"   CausesValidation="false" OnClick="btn_Delete_All_Invoice_And_Upload_Click"
                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                  
                </div>
                <div id="editbu">
                 <asp:Button ID="Button5" runat="server" class="scancel" OnClientClick="$find('mp_yesorno').hide();return false;" CausesValidation="false" UseSubmitBehavior="false" />
                      
                      </div>
                                                             
                    
                     </div>
                </div>
           
            </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>

    </form>
    <script src="../js/Export_Jscript/Export_Annexure_C_Sea_Container.js" type="text/javascript"></script>
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
