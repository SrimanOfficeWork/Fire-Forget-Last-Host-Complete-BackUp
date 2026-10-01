<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Annexure_C_Sea_Package.aspx.cs"
    Inherits="Export_Annexure_C_Sea_Package" %>

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
<body id="bg2popup" style="overflow: hidden">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="annexure_c_main">
                <div id="annexure_c_Container_main">
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_annuxeairC">
                            Group</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txtGroup" runat="server" CssClass="txtbox_annuxrec_air1" ReadOnly="True"
                                MaxLength="10" TabIndex="1"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_annuxeairC">
                            From</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txtFrom" runat="server" CssClass="txtbox_annuxrec_air1" 
                                MaxLength="10" TabIndex="2" onkeypress="return num1(event)"></asp:TextBox>
                        </div>

                        <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                        <div id="tag_label_transaction_Src_new">
                            From Desc</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txtFrom_Desc" runat="server" CssClass="txtbox_annuxrec_air1" 
                                TabIndex="3" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>


                    </div>
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_annuxeairC">
                            To</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txtTo" runat="server" CssClass="txtbox_annuxrec_air1" AutoPostBack="True"
                                OnTextChanged="txtTo_TextChanged" MaxLength="10" TabIndex="4" onkeypress="return num1(event)"></asp:TextBox>
                        </div>


                          <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                        <div id="tag_label_transaction_Src_new">
                            To Desc</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txtTo_Desc" runat="server" CssClass="txtbox_annuxrec_air1" 
                                TabIndex="5" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>


                    </div>
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_annuxeairC">
                            Package Type
                        </div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txtPackageType" runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_annuxrec_air1"
                                ClientIDMode="Static" MaxLength="3" TabIndex="6" onkeypress="return char1(event)"
                                onblur="ChangeCase(this);"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="OpenPopupUnit('ANNEX_C_SEA_PACK'); return false" class="magnfy">
                            </a>
                        </div>
                    </div>
                    <div id="innerbox_MidMain_bot_transact_invoice_new">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="9" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                                OnClick="btnNew_Click" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="7"
                                OnClientClick="return validate_Export_AnnexureC1_Sea_Package();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                TabIndex="8" OnClientClick="return validate_Export_AnnexureC1_Sea_Package();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="10" Visible="false" CssClass="dlete"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'ANNEXURE_C_PACKAGE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="7" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1('Annexure_Sea_Id');return false;"
                                tabindex="8" id="btnCancel" /></div>
                    </div>
                    <div id="annexure_c_grid_pack" style="overflow:auto;background-color:White; width:800px;  ">
                        <asp:GridView ID="gv_details" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                            CssClass="grid-view" AllowPaging="True" HorizontalAlign="Left" PageSize="7"
                            DataKeyNames="ANNEX_SEA_PACK_ID" AllowSorting="True" BorderColor="#C8C8C8" ShowHeaderWhenEmpty="true"
                            Width="60%" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                            OnPageIndexChanging="gv_details_PageIndexChanging" OnRowCreated="gv_details_RowCreated"
                            OnRowDataBound="gv_details_RowDataBound" OnSelectedIndexChanged="gv_details_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:CommandField>
                                <asp:BoundField DataField="ANNEX_SEA_PACK_GROUP" HeaderText="Group">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_PACK_FROM" HeaderText="From">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_PACK_TO" HeaderText="To">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ANNEX_SEA_PACK_PACKAGETYPE" HeaderText="Package Type">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="ANNEX_SEA_PACK_FROMDESC" HeaderText="From Desc">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="ANNEX_SEA_PACK_TODESC" HeaderText="To Desc">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>

                            </Columns>
                              <PagerSettings FirstPageText="First" LastPageText="Last" 
                                        Mode="NextPreviousFirstLast" NextPageText="Next" Position="Top" 
                                        PreviousPageText="Previous" />
                                        <PagerStyle CssClass="pager"/>
                        </asp:GridView>
                        <asp:HiddenField ID="hdn_update" runat="server" />
                        <asp:HiddenField ID="hdnTotal_pkgs" runat="server" />
                        <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />

                         <asp:HiddenField ID="Hdringo_cargo" runat="server" />
                    </div>
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
    <script src="../js/Export_Jscript/Export_Annexure_C_Sea_Package.js" type="text/javascript"></script>
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
