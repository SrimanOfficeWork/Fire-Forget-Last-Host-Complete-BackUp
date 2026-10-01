<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods_Registration_Sea_Package.aspx.cs"
    Inherits="Export_Annexure_C_Sea_Package" %>

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
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="txtbox_annuxrec_air1" ReadOnly="True"
                            MaxLength="10" TabIndex="2" onkeypress="return num1(event)"></asp:TextBox>
                    </div>

                    <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                    <div id="tag_label_transaction_Src_new">
                        From Desc</div>
                    <div id="txtcon_m_anncair">
                        <asp:TextBox ID="txtFrom_Desc" runat="server" CssClass="txtbox_annuxrec_air1" 
                                MaxLength="50" TabIndex="10" onkeypress="return charnum2(event)"></asp:TextBox>
                    </div>

                </div>
                <div id="tag_annexure_sea_cont">
                    <div id="tag_label_transaction_annuxeairC">
                        To</div>
                    <div id="txtcon_m_anncair">
                        <asp:TextBox ID="txtTo" runat="server" CssClass="txtbox_annuxrec_air1" AutoPostBack="True"
                            OnTextChanged="txtTo_TextChanged" MaxLength="10" TabIndex="3" onkeypress="return num1(event)"></asp:TextBox>
                    </div>

                    <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                    <div id="tag_label_transaction_Src_new">
                        To Desc</div>
                    <div id="txtcon_m_anncair">
                       <asp:TextBox ID="txtTo_Desc" runat="server" CssClass="txtbox_annuxrec_air1" 
                                MaxLength="50" TabIndex="11" onkeypress="return charnum2(event)"></asp:TextBox>
                    </div>

                </div>
                <div id="tag_annexure_sea_cont">
                    <div id="tag_label_transaction_annuxeairC">
                        Package Type
                    </div>
                    <div id="txtcon_m_anncair">
                        <asp:TextBox ID="txtPackageType" runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_annuxrec_air1"
                            ClientIDMode="Static" MaxLength="3" TabIndex="4" onkeypress="return char1(event)"
                            onblur="ChangeCase(this);"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <%--<a href="#" onclick="OpenPopupUnit_Goods_Reg('ANNEX_C_SEA_PACK'); return false" class="magnfy">
                        </a>--%>
                        <a href="#" onclick="OpenPopupUnit('ANNEX_C_SEA_PACK'); return false" class="magnfy">
                            </a>
                    </div>
                </div>
                <div id="innerbox_MidMain_bot_transact_invoice_new">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="5" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                            OnClick="btnNew_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="6"
                            OnClientClick="return validate_Export_AnnexureC1_Sea_Package();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="6" OnClientClick="return validate_Export_AnnexureC1_Sea_Package();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="7" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'GOODS_REG_SEA_PACKAGE', function(r) {
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
                    <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('Sea_Id');return false;"
                        tabindex="8" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()"
                            tabindex="8" id="btnCancel" />--%></div>
                </div>
                <div id="annexure_c_grid_pack">
                    <asp:GridView ID="gv_details" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                        CssClass="grid-view" AllowPaging="True" HorizontalAlign="Left" PageSize="12"
                        DataKeyNames="GOODS_PACK_ID" AllowSorting="True" BorderColor="#C8C8C8" ShowHeaderWhenEmpty="true"
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
                            <asp:BoundField DataField="GOODS_PACK_GROUP" HeaderText="Group">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GOODS_PACK_FROM" HeaderText="From">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GOODS_PACK_TO" HeaderText="To">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GOODS_PACK_PACKAGETYPE" HeaderText="Package Type">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>

                             <asp:BoundField DataField="GOODS_PACK_FROM_DESC" HeaderText="From Desc">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GOODS_PACK_TO_DESC" HeaderText="To Desc">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hdn_update" runat="server" />
                    <asp:HiddenField ID="hdnTotal_pkgs" runat="server" />
                    <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Export_Jscript/Export_Goods_Reg_Sea_Package.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
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
