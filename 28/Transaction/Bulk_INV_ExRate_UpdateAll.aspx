<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bulk_INV_ExRate_UpdateAll.aspx.cs" Inherits="Bulk_INV_ExRate_UpdateAll" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Bill Invoice</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
  
     <style type="text/css">
         .datagrid table { border-collapse: collapse; text-align: left; width: 100%; } .datagrid {font: normal 12px/100% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden; border: 1px solid #8C8C8C; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; }.datagrid table td, .datagrid table th { padding: 3px 10px; }.datagrid table thead th {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; color:#FFFFFF; font-size: 15px; font-weight: bold; border-left: 1px solid gray; } .datagrid table thead th:first-child { border: none; }.datagrid table tbody td { /*color: #7D7D7D;*/ border-left: 1px solid #DBDBDB;font-size: 12px;font-weight: normal; }.datagrid table tbody .alt td { background: #EBEBEB; color: #7D7D7D; }.datagrid table tbody td:first-child { border-left: none; }.datagrid table tbody tr:last-child td { border-bottom: none; }.datagrid table tfoot td div { border-top: 1px solid #8C8C8C;background: #EBEBEB;} .datagrid table tfoot td { padding: 0; font-size: 12px } .datagrid table tfoot td div{ padding: 2px; }.datagrid table tfoot td ul { margin: 0; padding:0; list-style: none; text-align: right; }.datagrid table tfoot  li { display: inline; }.datagrid table tfoot li a { text-decoration: none; display: inline-block;  padding: 2px 8px; margin: 1px;color: #F5F5F5;border: 1px solid #8C8C8C;-webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; }.datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover { text-decoration: none;border-color: #7D7D7D; color: #F5F5F5; background: none; background-color:#8C8C8C;}div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }
    
     /*td:nth-of-type(1) {display: none;}*/
     </style>
    
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="tag_srcinner1" style="width: 400px;">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                    Ex.Rate Update - All Invoices</div>
                <div id="verslic">
                </div>
                <div id="popupwindow_closebut_right_new">
                    <%--<input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent(); return false;" />--%>
                      <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />

                        <%--<input type="close" value="Submit" class="clsicon_new" onclick="parent.adcodewindow.hide();RefreshParent();return false;"
                                id="btnCancel" tabindex="63">--%>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div class="content" id="page-1" style="margin-left: -20px; margin-top: -15px; width: 410px;">
                <div id="open_item" runat="server">
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 42px; width: 390px;
                            margin-top: -16px; overflow: hidden;">
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: hidden; height: 100px;
                                width: 388px;">
                                <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                    CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_Details_RowCreated"
                                    OnRowDataBound="gv_Details_RowDataBound" Style="overflow: auto;">
                                    <Columns>
                                        <asp:BoundField DataField="d" HeaderText="S. No" HeaderStyle-Width="44px" HeaderStyle-Font-Bold="true">
                                            <ItemStyle CssClass="column_style_left_border_2_new" Width="44px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="b" HeaderText="Currency" HeaderStyle-Width="150px" HeaderStyle-Font-Bold="true">
                                            <ItemStyle CssClass="column_style_left_border_2_new" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="Job Ex.Rate" HeaderStyle-Width="150px" HeaderStyle-Font-Bold="true">
                                            <ItemStyle CssClass="column_style_left_border_2_new" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="c" HeaderText="New Ex.Rate" HeaderStyle-Width="150px" HeaderStyle-Font-Bold="true">
                                            <ItemStyle CssClass="column_style_left_border_2_new" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 215px;
                            width: 390px; margin-top: -16px; overflow: hidden;">
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow-x: hidden; overflow-y: auto;
                                height: 212px; width: 388px;">
                                <asp:GridView ID="gv_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                    ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                                    AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                    OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                                    ShowHeader="false">
                                    <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                    <Columns>
                                  
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="44px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="44px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="INVOICE_CURRENCY" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="INVOICE_EXRATE" HeaderStyle-Width="100px" FooterStyle-HorizontalAlign="Center">
                                            <ItemStyle CssClass="column_style_left" Width="100px" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Ex.Rate">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_ExRate" runat="server" CssClass=" txtbox_trans_exp_drawback" MaxLength="7"
                                                    Text='<%# Bind("NEW_EXRATE") %>' Width="100px"  ForeColor="Blue" Font-Bold="true"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <p id="pTotal" style="color: Red; font-size: large;">
                                    <%--CssClass=" txtbox_trans_exp_drawback"--%>
                            </div>
                            <%-----------------------Test--------------------------------------------------------%>
                        </div>
                    </div>
                    <%-- --------------------Test Start----------------------------%>
                    <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px; margin-left: 20px;
                        margin-top: -14px;">
                        <div id="innerbox_transac_bot_inn" style="margin-left:35px">
                            <div id="editbu">
                                <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                    OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                    TabIndex="55" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" TabIndex="81" OnClientClick="return validate_Invoice('btnUpdate');"
                                    OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                    </div>
                    <%-- --------------------Test End----------------------------%>
                </div>
            </div>
              
                <%-----------------------------------END----------------------------------------------------------------%>
          
           </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  
   <script  src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>

    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
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
        function close_button() {
            document.getElementById("General").click();
        }
        
    </script>
   
    
</body>
</html>
