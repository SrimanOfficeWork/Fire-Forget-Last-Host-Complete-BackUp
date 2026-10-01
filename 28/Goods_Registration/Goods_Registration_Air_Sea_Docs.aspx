<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods_Registration_Air_Sea_Docs.aspx.cs"
    Inherits="Goods_Registration_Air_Sea_Docs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Goods Registration- Documents</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <script src="../js/listpopup.js" type="text/javascript"></script>
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
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
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
            <div id="annexure_c_main">
                <div id="annexure_c_Container_main">
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_annuxeairC">
                            Document Sr. No.</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_Document_SrNo" runat="server" CssClass="txtbox_annuxrec_air1" 
                                MaxLength="10" TabIndex="1"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_annexure_sea_cont">
                        <div id="tag_label_transaction_annuxeairC">
                            Document Name</div>
                        <div id="txtcon_m_anncair">
                            <asp:TextBox ID="txt_DocumentName" runat="server" CssClass="txtbox_annuxrec_air1"
                                MaxLength="10" TabIndex="2" ></asp:TextBox>
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
                                OnClientClick="return Validation();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                TabIndex="6" OnClientClick="return Validation();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="7" Visible="false" CssClass="dlete"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'GOODS_REG_AIR_PACKAGE', function(r) {
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
                         <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('Air_Id');return false;"
                        tabindex="8" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                            <%--<input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()"
                                tabindex="8" id="btnCancel" />--%></div>
                    </div>
                    <div id="annexure_c_grid_pack">
                        <asp:GridView ID="gv_details" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                            CssClass="grid-view" AllowPaging="True" HorizontalAlign="Left" PageSize="12"
                            DataKeyNames="GOODS_DOCS_ID" AllowSorting="True" BorderColor="#C8C8C8" ShowHeaderWhenEmpty="true"
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
                                <asp:BoundField DataField="GOODS_DOCS_SERIAL_NO" HeaderText="Documnet Sl.No" HeaderStyle-Width="100px">
                                    <ItemStyle CssClass="column_style_left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GOODS_DOCS_NAME" HeaderText="Document Name">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                               
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="hdn_update" runat="server" />
                        <asp:HiddenField ID="hdnTotal_pkgs" runat="server" />
                        <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Export_Jscript/Export_Goods_Reg_Air_Package.js" type="text/javascript"></script>
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

     <script type="text/javascript">

         function Validation() {
           
             var txt_Document_SrNo = document.getElementById("txt_Document_SrNo").value;
             if (txt_Document_SrNo.length <= 0) {
                 jAlert('Document SrNo cannot be blank', 'GOODS_REG - DOCUMENTS', function (r) { document.getElementById("txt_Document_SrNo").focus(); });
                 return false;
             }

             var txt_DocumentName = document.getElementById("txt_DocumentName").value;
             if (txt_DocumentName.length <= 0) {
                 jAlert('Document Name cannot be blank', 'GOODS_REG - DOCUMENTS', function (r) { document.getElementById("txt_DocumentName").focus(); });
                 return false;
             }
         }

     </script>
</body>
</html>
