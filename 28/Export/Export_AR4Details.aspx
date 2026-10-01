<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_AR4Details.aspx.cs"
    Inherits="Export_AR4Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Export AR4</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
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
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
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
         
               <div  id="page-1" style="height:530px; margin-top:15px"> 
                 
                        <div id="pop_text_area_transac_inn_container_left_export_annexure_other" style="height:530px; margin-top:15px">
                            <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                                <div id="tag_label_transaction_export_Item_otherdet">
                                    AR4 No
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtAR4No" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                        MaxLength="17"  TabIndex="1"></asp:TextBox>
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
                                   <span style="margin-left:12px;"> AR4 Date</span>
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtAR4Date" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                        TabIndex="2"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtAR4Date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAR4Date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                                <div id="tag_label_transaction_export_Item_otherdet">
                                    Commissionerate
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtCommissionRate" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                        MaxLength="20" TabIndex="3"></asp:TextBox>
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
                                    <span style="margin-left:12px;">Division</span>
                                    </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtDivision" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                        TabIndex="4" MaxLength="20"></asp:TextBox>
                                </div>
                            </div>



                            <div id="tag_transac_lft_trans_item_maindet_otherdet_new1">
                                <div id="tag_label_transaction_export_Item_otherdet">
                                    Range
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtRange" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                        MaxLength="20" TabIndex="5"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="magnify_area">
                                </div>

                            </div>
                              <%-- -------------------------------%>

                                  <div id="tag_transac_lft_trans_item_maindet_otherdet_new1" style="width:500px">
                                <div id="tag_label_transaction_export_Item_otherdet">
                                    <span style="margin-left:12px;">Item No </span>
                                    </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txtitem_No" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                       Onkeypress="return num5(event)" TabIndex="6" MaxLength="4"></asp:TextBox>
                                </div>
                                 
                            </div>


                           <%-- ---------------------------------------------------%>
                            <div id="tag_transac_exports_item_margs_nos_others_new1" style="width:780px;">
                                <div id="tag_label_transaction_annuxeairC">
                                    Remarks
                                </div>
                                <asp:TextBox ID="txtMarks_Numbers" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_transac_item_gen_decs"
                                    TabIndex="7" TextMode="MultiLine" onkeyDown="return checkTextAreaMaxLength(this,event,'200');"
                                    onpaste="return checkTextAreaMaxLength(this,event,'200');"></asp:TextBox>

                                    <%--<div id="tag_label_transaction_popup_IGM2_empty" style="width: 10px;">--%>
                        <asp:LinkButton ID="lnk_Delte2" Text="Delete All" Style="margin-left: 55px;"  ToolTip="Delete IRN to All items in this Invoice"
                            runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Do U Want to Delete - All the AR4 Details in this Invoice  ? ', 'AR4 - BULK DELETE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {         
              document.getElementById('btn_Bulk_Delete').click();          
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn_Bulk_Delete" runat="server" TabIndex="11" CssClass="dlete"
                            Style="display: none;" onclick="btn_Bulk_Delete_Click" />
                    <%--</div>--%>
                            </div>
                            
                            <div id="innerbox_MidMain_bot_transact_invoice">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="9" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" TabIndex="8"
                                        OnClientClick="return validate_Export_EXPORT_AR4_Details();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                        TabIndex="8" OnClientClick="return validate_Export_EXPORT_AR4_Details();" Visible="false" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="10" Visible="false" CssClass="dlete"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'EXPORT_AR4', function(r) {
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
                                        tabindex="11" id="btnCancel" />
                                </div>
                                <div id="editbu">
                                    &nbsp;&nbsp;&nbsp; <a href="../Submission/Export_Excel_Format/Export_AR4.xlsx" target="_new">
                                        <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"
                                            Height="30px" Width="30px" runat="server" />
                                    </a>
                                </div>
                                <div id="tag_label_transaction_annuxeairC" style="width: 80px; text-align: right">
                                    Upload File
                                </div>
                                <div id="txtcon-m_src_ItemMove">
                                    <asp:FileUpload ID="fileuploadExcel" runat="server" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btn_BulkAR4_Upload" runat="server" CssClass="autowidmovebut" Text="Upload"
                                        TabIndex="115" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                        Style="margin-left: 125px;" OnClick="btn_BulkAR4_Upload_Click" />
                                </div>
                            </div>
                            
                           <%-- <div id="tag_transac_export_lft_item_gen_Grid_area_new" style="margin-top:175px;overflow: scroll; width:690px; height:147px;">--%>
                          
                           <%--<div id="tag_transac_export_lft_item_gen_Grid_area_new"  style="overflow: hidden;margin-top:175px;" runat="server">--%>

                            <div id="tag_transac_export_lft_item_gen_Grid_area_new" style="margin-top:172px;overflow: hidden; height:147px;">
                          
                           <%--OnPageIndexChanging="gv_Item_PageIndexChanging"  AllowPaging="True"--%>
                                <asp:GridView ID="gv_Item" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                    CssClass="grid-view" HorizontalAlign="Left"
                                    DataKeyNames="AR4_ID" AllowSorting="True" BorderColor="#C8C8C8" ShowHeaderWhenEmpty="true"
                                    Width="150%" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                     OnRowCreated="gv_Item_RowCreated" 
                                    OnRowDataBound="gv_Item_RowDataBound" OnSelectedIndexChanged="gv_Item_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        BorderWidth="1px" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="25px" >
                                            <ItemTemplate >
                                               <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                   
                                            </ItemTemplate>
                                            <ItemStyle CssClass="column_style_left5"  Width="25px" />
                                        </asp:TemplateField>
                                                                          
                                    
                                        <asp:BoundField DataField="AR4_NO" HeaderText="AR4 No" HeaderStyle-Width="95px">
                                            <ItemStyle CssClass="column_style_left5"  Width="95px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AR4_DATE" HeaderText="AR4 Date" HeaderStyle-Width="55px">
                                            <ItemStyle CssClass="column_style_left5"  Width="55px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AR4_COMMISSION_RATE" HeaderText="Commissionerate" HeaderStyle-Width="85px"> 
                                            <ItemStyle CssClass="column_style_left"  Width="85px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AR4_DIVISION" HeaderText="Division" HeaderStyle-Width="125px">
                                            <ItemStyle CssClass="column_style_left"  Width="125px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AR4_RANGE" HeaderText="Range" HeaderStyle-Width="85px">
                                            <ItemStyle CssClass="column_style_left"   Width="85px"/>
                                        </asp:BoundField>
             
                                          <asp:BoundField DataField="AR4_REMARKS">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                          <asp:BoundField DataField="AR4_ITEM_NO" HeaderText="Item No" HeaderStyle-Width="45px">
                                            <ItemStyle CssClass="column_style_left"  Width="45px" />
                                        </asp:BoundField>
                                 
                                    </Columns>
                                   <%-- <PagerSettings FirstPageText="First" LastPageText="Last" 
                                        Mode="NextPreviousFirstLast" NextPageText="Next" Position="Top" 
                                        PreviousPageText="Previous" />--%>
                                         <PagerStyle CssClass="pager" />

                                </asp:GridView>
                            </div>
                        </div>
                  
              </div> 
            
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdn_inv_slno" runat="server" />
            <asp:HiddenField ID="hdn_item_slno" runat="server" />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:HiddenField ID="hdn_INV_NO" runat="server" />
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
                     <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>



    </form>
    <script src="../js/Export_Jscript/Export_AR4.js" type="text/javascript"></script>
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

     <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

            var totalRows = $("#<%=gv_Item.ClientID %> tr").length;
            var lastProductId = $("#<%=gv_Item.ClientID %> tr:last").children("td:first").html();


            if (totalRows > 2) {

                gridviewScroll();

            }
            else {

                if (lastProductId > 0) {
                    gridviewScroll();
                }
                else {
                    if (lastProductId > 0) {
                        gridviewScroll();
                    }
                    else {

                        document.getElementById('<%=gv_Item.ClientID %>').style.width = "87%";
                        document.getElementById('<%=gv_Item.ClientID %>').style.overflow = "87%";
                    }

                }
            }
        });

        function gridviewScroll() {

            gridView1 = $('#<%=gv_Item.ClientID %>').gridviewScroll({
                width: 698,
                height: 105,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 1,
                arrowsize: 30,
                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",
                headerrowcount: 1,
                railsize: 16,
                barsize: 15
            });
        }
    </script>

    
</body>
</html>
