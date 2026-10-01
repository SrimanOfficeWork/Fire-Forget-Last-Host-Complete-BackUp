<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods_Registration_Sea_ContainerPackage.aspx.cs"
    Inherits="Goods_Registration_Sea_ContainerPackage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Annexure C1 | Transaction</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Goods_Reg_Sea_Container_Package.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="annexure_c_Container_main" style="width:850px;">
                <div id="annexure_c_Sea_main_inner_" style="width:850px;">
                    
                    <div id="tag_annexure_sea_cont" style="width:850px;">
                        <div id="tag_label_transaction_annuxeairC">
                            Eqmnt Serial no</div>
                        <div id="txtcon_m_anncair">
                            <div id="txtcon_m_anncair">
                                <asp:TextBox ID="txt_Eqmnt_SerialNo" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="3" TabIndex="1" onkeypress="return charnum2(event)"></asp:TextBox>
                            </div>
                        </div>
                         <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_date" style="width: 150px">
                            Pckg From
                        </div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_PckgFrom" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="5" TabIndex="5" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                        
                    </div>
                    <div id="tag_annexure_sea_cont" style="width:850px;">
                        <div id="tag_label_transaction_annuxeairC">
                            Eqmnt Type
                        </div>
                        <div id="txtcon_m_anncair">
                            <asp:DropDownList ID="ddl_Eqmnt_Type" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                TabIndex="2">
                                <asp:ListItem Value="BB">BB</asp:ListItem>
                                <asp:ListItem Value="CN">CN</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_annuxeairC" style="width: 150px">
                            Pckg To</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_PckgTo" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="5" TabIndex="6" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                         <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        
                    </div>
                    <div id="tag_annexure_sea_cont" style="width:850px;">
                        <div id="tag_label_transaction_annuxeairC">
                            Eqmnt ID
                        </div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_Eqmnt_ID" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="8" TabIndex="3" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_annuxeairC" style="width: 150px">
                            Pckg Count</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_PckgCount" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="8" TabIndex="7" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                         <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                       
                    </div>
                    <div id="tag_annexure_sea_cont" style="width:850px;">
                        <div id="tag_label_transaction_annuxeairC">
                            Eqmnt Loc
                        </div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_Eqmnt_Loc" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="10" TabIndex="4" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_annuxeairC" style="width: 150px">
                            Pckg UQC</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_PckgUQC" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                MaxLength="3" TabIndex="8" onkeypress="return charnum2(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="10" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                                OnClick="btnNew_Click" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="11"
                                OnClientClick="return validate_Export_AnnexureC1_Sea_Container_Package();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                TabIndex="11" OnClientClick="return validate_Export_AnnexureC1_Sea_Container_Package();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="12" Visible="false" CssClass="dlete"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'GOODS_REG_SEA_CONTAINER', function(r) {
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
                        <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('Sea_Id');return false;"
                        tabindex="13" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                           <%-- <input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()"
                                tabindex="9" id="btnCancel" />--%></div>
                    </div>
                    <div id="annexure_c_grid_cont" style="width:850px;">
                        <asp:GridView ID="gv_details" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                            CssClass="grid-view" AllowPaging="True" HorizontalAlign="Left" PageSize="12"
                            DataKeyNames="GOODS_SEA_CON_ID" AllowSorting="True" BorderColor="#C8C8C8" ShowHeaderWhenEmpty="true"
                            Width="100%" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                            OnPageIndexChanging="gv_details_PageIndexChanging" OnRowCreated="gv_details_RowCreated"
                            OnRowDataBound="gv_details_RowDataBound" OnSelectedIndexChanged="gv_details_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:CommandField>
                                <asp:BoundField DataField="GOODS_SEA_CON_EQMT_SERIAL_NO" HeaderText="Eqmt.Serial No">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GOODS_SEA_CON_EQMT_TYPE" HeaderText="Size">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GOODS_SEA_CON_EQMT_ID" HeaderText="Type">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GOODS_SEA_CON_EQMT_LOC" HeaderText="Excise Seal No">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GOODS_SEA_CON_PCKG_FROM" HeaderText="Seal Date">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GOODS_SEA_CON_PCKG_TO" HeaderText="Seal Type Indicator">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GOODS_SEA_CON_PCKG_COUNT" HeaderText="Seal Device ID">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GOODS_SEA_CON_PCKG_UQC" HeaderText="Seal Doc.Type">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdn_update" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Export_Jscript/Export_Goods_Reg_Sea_Container.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
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
