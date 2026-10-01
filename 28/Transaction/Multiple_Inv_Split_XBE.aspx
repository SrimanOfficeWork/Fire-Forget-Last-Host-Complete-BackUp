<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Multiple_Inv_Split_XBE.aspx.cs"
    Inherits="Multiple_Inv_Split" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Split Multiple Invoice</title>
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
        .datagrid table
        {
            border-collapse: collapse;
            text-align: left;
            width: 100%;
        }
        .datagrid
        {
            font: normal 12px/150% Arial, Helvetica, sans-serif;
            background: #fff;
            overflow: hidden;
            border: 1px solid #8C8C8C;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
        }
        .datagrid table td, .datagrid table th
        {
            padding: 3px 10px;
        }
        .datagrid table thead th
        {
            background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );
            background: -moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');
            background-color: #8C8C8C;
            color: #FFFFFF;
            font-size: 15px;
            font-weight: bold;
            border-left: 1px solid gray;
        }
        .datagrid table thead th:first-child
        {
            border: none;
        }
        .datagrid table tbody td
        {
            /*color: #7D7D7D;*/
            border-left: 1px solid #DBDBDB;
            font-size: 12px;
            font-weight: normal;
        }
        .datagrid table tbody .alt td
        {
            background: #EBEBEB;
            color: #7D7D7D;
        }
        .datagrid table tbody td:first-child
        {
            border-left: none;
        }
        .datagrid table tbody tr:last-child td
        {
            border-bottom: none;
        }
        .datagrid table tfoot td div
        {
            border-top: 1px solid #8C8C8C;
            background: #EBEBEB;
        }
        .datagrid table tfoot td
        {
            padding: 0;
            font-size: 12px;
        }
        .datagrid table tfoot td div
        {
            padding: 2px;
        }
        .datagrid table tfoot td ul
        {
            margin: 0;
            padding: 0;
            list-style: none;
            text-align: right;
        }
        .datagrid table tfoot li
        {
            display: inline;
        }
        .datagrid table tfoot li a
        {
            text-decoration: none;
            display: inline-block;
            padding: 2px 8px;
            margin: 1px;
            color: #F5F5F5;
            border: 1px solid #8C8C8C;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );
            background: -moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');
            background-color: #8C8C8C;
        }
        .datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover
        {
            text-decoration: none;
            border-color: #7D7D7D;
            color: #F5F5F5;
            background: none;
            background-color: #8C8C8C;
        }
        div.dhtmlx_window_active, div.dhx_modal_cover_dv
        {
            position: fixed !important;
        }
        
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
            <div id="tag_transact_src_inner" style="width: 1100px;">
                <div id="tag_transac_lft_Inv_in1" style="width: 1060px; height: 40px; margin-top: 20px;">
                    <div id="tag_label_transaction_popup_gen" style="width: 105px; font-weight: bold;
                        color: Blue;">
                        Working Period</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 290px; font-weight: bold;">
                        <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none" AutoPostBack="True"
                            TabIndex="1" OnSelectedIndexChanged="ddlWorkingPeriod_SelectedIndexChanged">
                            <%-- <asp:ListItem Text="01-Apr-2015 - 31-Mar-2016" Value="01-Apr-2015 - 31-Mar-2016"></asp:ListItem>--%>
                            <asp:ListItem Text="01-Apr-2025 - 31-Mar-2026" Value="01-Apr-2025 - 31-Mar-2026"></asp:ListItem>
                              <asp:ListItem Text="01-Apr-2024 - 31-Mar-2025" Value="01-Apr-2024 - 31-Mar-2025"></asp:ListItem>
                           <asp:ListItem Text="01-Apr-2023 - 31-Mar-2024" Value="01-Apr-2023 - 31-Mar-2024"></asp:ListItem>
                           <%--  <asp:ListItem Text="01-Apr-2022 - 31-Mar-2023" Value="01-Apr-2022 - 31-Mar-2023"></asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 400px;">
                        <div id="tag_label_transact_Src" style="width: 125px; font-weight: bold; color: Blue;">
                            Warehouse Jobno
                        </div>
                        <asp:DropDownList ID="ddlWarehouse_JobNo" runat="server" Font-Size="12px" CssClass="txtbox_none" TabIndex="2"
                            Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_Inv_in1" style="width: 1060px; height: 25px;">
                    <div id="tag_label_transaction_popup_gen" style="width: 295px; font-weight: bold;
                        color: Blue;">
                    </div>
                    <div id="tag_label_transaction_popup_gen" style="width: 55px; font-weight: bold;
                        color: Green;">
                        Freight
                    </div>
                    <div id="tag_label_transaction_MIS_empty1">
                        <asp:CheckBox ID="chk_Freight" runat="server" TabIndex="3" onclick="chkMI(this);" /></div>
                    <div id="tag_label_transaction_popup_gen" style="width: 195px; font-weight: bold;
                        color: Green;">
                    </div>
                    <div id="tag_label_transaction_popup_gen" style="width: 75px; font-weight: bold;
                        color: Green;">
                        Insurance
                    </div>
                    <div id="tag_label_transaction_MIS_empty1">
                        <asp:CheckBox ID="chk_Insurance" runat="server" TabIndex="4" onclick="chkMI(this);" /></div>
                    <div id="tag_label_transaction_popup_gen" style="width: 195px; font-weight: bold;
                        color: Green;">
                    </div>
                    <div id="tag_label_transaction_popup_gen" style="width: 35px; font-weight: bold;
                        color: Green;">
                        Misc
                    </div>
                    <div id="tag_label_transaction_MIS_empty1">
                        <asp:CheckBox ID="chk_Misc" runat="server" TabIndex="5" onclick="chkMI(this);" /></div>
                    <div id="tag_label_transaction_popup_gen" style="width: 125px; font-weight: bold;
                        color: Blue;">
                    </div>
                    <div id="tag_label_transaction_popup_gen" style="width:25px; font-weight: bold;
                        color: Green;">
                        HSS
                    </div>
                    <div id="tag_label_transaction_MIS_empty1">
                        <asp:CheckBox ID="chk_HSS" runat="server" TabIndex="6" onclick="chkMI(this);" /></div>
                </div>
              
            <div id="pop_text_area_transac_popup_inn_container_export" style="height: 42px; width: 1140px;
               overflow: hidden;">
                <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: hidden; height: 1100px;
                    width: 1140px;">
                    <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                        CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                        HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_Details_RowCreated"
                        OnRowDataBound="gv_Details_RowDataBound" Style="overflow: auto;">
                        <Columns>
                            <asp:BoundField DataField="d" HeaderText="SlNo" HeaderStyle-Width="20px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                             <asp:BoundField DataField="b" HeaderText="Inv.No" HeaderStyle-Width="70px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="b" HeaderText="Terms"  HeaderStyle-Width="40px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="c" HeaderText="WH.Inv" HeaderStyle-Width="80px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="d" HeaderText="Inv.Value" HeaderStyle-Width="60px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="f" HeaderText="WH.FRT" HeaderStyle-Width="70px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Fre.Rate" HeaderStyle-Width="30px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Fre.Amt" HeaderStyle-Width="80px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="g" HeaderText="WH.Ins" HeaderStyle-Width="70px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Ins.Rate" HeaderStyle-Width="30px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Ins.Amt" HeaderStyle-Width="80px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="g" HeaderText="WH.Misc" HeaderStyle-Width="70px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                           <%-- <asp:BoundField DataField="g" HeaderText="Misc.Rate" HeaderStyle-Width="60px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="g" HeaderText="Misc.Amt" HeaderStyle-Width="80px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                          
                            <asp:BoundField DataField="g" HeaderText="WH.HSS" HeaderStyle-Width="40px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="HSS.Rate" HeaderStyle-Width="30px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="HSS.Amt" HeaderStyle-Width="80px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div id="pop_text_area_transac_popup_inn_container_export" style="height: 275px;
                width: 1140px; margin-top: -16px; overflow: hidden;">
                <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow-x: hidden; overflow-y: auto;
                    height: 252px; width: 1140px;">
                    <asp:GridView ID="gv_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                        ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                        AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                        OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                        ShowHeader="false" DataKeyNames="INVOICE_SLNO">
                        <RowStyle BorderWidth="0.1em" BorderColor="black" />
                        <Columns>
                           
                            <asp:BoundField DataField="INVOICE_SLNO"  HeaderStyle-Width="20px">
                                <ItemStyle CssClass="column_style_left_border_2_new" Width="20px" HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="INVOICE_NO"  HeaderStyle-Width="100px">
                                <ItemStyle CssClass="column_style_left_border_2_new" Width="70px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl_Inv_Terms" Text='<%# Bind("TERMS") %>' MaxLength="20" runat="server" TabIndex="7"
                                        Width="50px" Font-Size="12px" CssClass=" txtbox_trans_exp_drawback">
                                        <asp:ListItem>FOB</asp:ListItem>
                                        <asp:ListItem>CI</asp:ListItem>
                                        <asp:ListItem>CF</asp:ListItem>
                                        <asp:ListItem>CIF</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="25px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                          
                            <asp:BoundField DataField="WH_INVOICE_VALUE" HeaderStyle-Width="70px">
                                <ItemStyle CssClass="column_style_right_new" Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INVOICE_VALUE"  HeaderStyle-Width="70px">
                                <ItemStyle CssClass="column_style_right_new" Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="WH_FRT_AMT" HeaderStyle-Width="70px">
                                <ItemStyle CssClass="column_style_right_new" Width="70px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="WH_FRT_RATE" HeaderStyle-Width="50px">
                                <ItemStyle CssClass="column_style_right_new" Width="50px" />
                            </asp:BoundField>
                           
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Fri_Amt" Text='<%# Bind("MIS_FREIGHT_CHARGES") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="80px" runat="server" ForeColor="Red" Font-Bold="true" TabIndex="8"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="WH_INS_AMT"  HeaderStyle-Width="70px">
                                <ItemStyle CssClass="column_style_right_new" Width="70px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="WH_INS_RATE"  HeaderStyle-Width="50px">
                                <ItemStyle CssClass="column_style_right_new" Width="50px" />
                            </asp:BoundField>
                            
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ins_Amt" Text='<%# Bind("MIS_INSURANCE_CHARGES") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="80px" runat="server" Font-Bold="true" ForeColor="Green" TabIndex="9"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>

                            
                            <asp:BoundField DataField="WH_MISC_AMT"  HeaderStyle-Width="70px">
                                <ItemStyle CssClass="column_style_right_new" Width="70px" />
                            </asp:BoundField>
                          
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Misc_Amt" Text='<%# Bind("MIS_CHARGES") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="70px" runat="server" Font-Bold="true" ForeColor="Blue" TabIndex="10"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="70px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>

                             <asp:BoundField DataField="WH_HSS_AMT" HeaderStyle-Width="50px">
                                <ItemStyle CssClass="column_style_right_new" Width="50px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="WH_HSS_RATE"  HeaderStyle-Width="50px">
                                <ItemStyle CssClass="column_style_right_new" Width="50px" />
                            </asp:BoundField>
                           
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_HSS_Amt" Text='<%# Bind("MIS_HIGHSEASALE_CHARGES") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="70px" runat="server" Font-Bold="true" ForeColor="DeepPink" TabIndex="11"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="70px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <p id="pTotal" style="color: Red; font-size: large;">
                </div>
                <%-----------------------Test--------------------------------------------------------%>
            </div>
         
            <%-- --------------------Test Start----------------------------%>
            <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px; margin-left: 20px;
                margin-top: -14px;">
                <div id="innerbox_transac_bot_inn">
                  
                    <div id="editbu">
                        <asp:Button ID="btnupdate" runat="server" CssClass="autowidmovebut" Text="Convert to Update"
                            OnClick="btnupdate_Click" OnClientClick="return validate_Invoice();" TabIndex="12"
                            Width="200px" />
                    </div>
                    <div id="editbu">
                      
                    </div>
                </div>
            </div>
            <%-- --------------------Test End----------------------------%>
           
            <%-----------------------------------END----------------------------------------------------------------%>
            <script src="../activatables.js" type="text/javascript"></script>
       
            <asp:HiddenField ID="hdn_valid" runat="server" />
          
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  
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
