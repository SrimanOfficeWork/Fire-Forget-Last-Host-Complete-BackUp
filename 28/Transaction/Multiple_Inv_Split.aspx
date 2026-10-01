<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Multiple_Inv_Split.aspx.cs"
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
                <%-- <div id="innerbox_MidMain" style="height:63px; width:950px;">--%>
                <%--<div id="tag_srcinner1" style="height:63px; width:950px;">--%>
                <div id="tag_transac_lft_Inv_in1" style="width: 1060px;">
                    <div id="txt_container_Transact_Main_l" style="width: 450px;">
                        <div id="tag_label_transact_Src" style="width: 55px; font-weight: bold">
                            Tot.FRT
                        </div>
                        <div id="tag_label_transact_Src" style="width: 58px;">
                            <asp:DropDownList ID="ddl_FRT_AMT_RATE" runat="server" BackColor="LightBlue" TabIndex="1">
                                <asp:ListItem>Amt</asp:ListItem>
                                <asp:ListItem>Rate</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px;">
                            <asp:TextBox ID="txt_tot_Freight_Chrg" runat="server" CssClass="txtbox_none_Mid_transac_code" ClientIDMode="Static"
                                MaxLength="17" TabIndex="2" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_Date" style="width: 30px;">
                            Curr.
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 55px;">
                            <asp:TextBox ID="txtFRT_Currency" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="3" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                Width="50px" onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_Date" style="width: 40px;">
                            Ex.Rt.
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 65px;">
                            <asp:TextBox ID="txtFRT_ExRate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="4" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" Width="60px"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                           <%-- <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Split_FRT_Currency'); return false"
                                tabindex="4" class="magnfy"></a>--%>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 430px;">
                        <div id="tag_label_transact_Src" style="width: 60px; font-weight: bold">
                            Tot.MISC
                        </div>
                        <div id="tag_label_transact_Src" style="width: 58px;">
                            <asp:DropDownList ID="ddl_MISC_AMT_RATE" runat="server" BackColor="LightBlue" TabIndex="10">
                                <asp:ListItem>Amt</asp:ListItem>
                                <%--<asp:ListItem>Rate</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px;">
                            <asp:TextBox ID="txt_tot_MISC_Chrg" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="17" TabIndex="11" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_Date" style="width: 30px;">
                            Curr.
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 55px;">
                            <asp:TextBox ID="txtMisc_Currency" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="12" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                Width="50px" onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_Date" style="width: 40px;">
                            Ex.Rt.
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 65px;">
                            <asp:TextBox ID="txtMisc_ExRate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="13" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" Width="60px"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <%--<a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Split_MISC_Currency'); return false"
                                tabindex="13" class="magnfy"></a>--%>
                        </div>
                    </div>
                    <%--<div id="verslic">
                    </div>--%>
                    <%--<div id="txt_container_Transact_Main_l" style="width: 100px;">
                    </div>--%>
                    <%--<div id="txt_container_Transact_Main_l" style="width: 160px;">
                        <div id="tag_label_transact_Src" style="width: 50px; font-weight: bold">
                            Tot. Inv
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px;">
                            <asp:TextBox ID="txt_tot_inv_amt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                Enabled="false" MaxLength="17" TabIndex="5" onblur="extractNumber(this,2,false);"
                                onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                        </div>
                    </div>--%>
                    <div id="popupwindow_closebut_right_new">
                        <%--<input type="close" value="Submit" class="clsicon_new" onclick="win_hide();RefreshParent();parent.adcodewindow.hide();return false;" />--%>
                          <%--<input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="63">--%>
                    </div>
                </div>
                <div id="tag_transac_lft_Inv_in1" style="width: 876px;">
                    <div id="txt_container_Transact_Main_l" style="width: 450px;">
                        <div id="tag_label_transact_Src" style="width: 55px; font-weight: bold">
                            Tot.INS
                        </div>
                        <div id="tag_label_transact_Src" style="width: 58px;">
                            <asp:DropDownList ID="ddl_INS_AMT_RATE" runat="server" BackColor="LightBlue" TabIndex="5">
                                <asp:ListItem>Amt</asp:ListItem>
                                <asp:ListItem>Rate</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px;">
                            <asp:TextBox ID="txt_tot_Ins_Chrg" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="17" TabIndex="6" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_Date" style="width: 30px;">
                            Curr.
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 55px;">
                            <%--<asp:TextBox ID="txtIns_Currency" runat="server" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="7" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                Width="50px" onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>--%>
                                <asp:TextBox ID="txtIns_Currency" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="7" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                Width="50px" onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_Date" style="width: 40px;">
                            Ex.Rt.
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 65px;">
                            <asp:TextBox ID="txtINS_ExRate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="8" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" Width="60px"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <%--<a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Split_INS_Currency'); return false"
                                tabindex="9" class="magnfy"></a>--%>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 420px;">
                        <div id="tag_label_transact_Src" style="width: 60px; font-weight: bold">
                            Tot.HSS
                        </div>
                        <div id="tag_label_transact_Src" style="width: 58px;">
                            <asp:DropDownList ID="ddl_HSS_AMT_RATE" runat="server" BackColor="LightBlue" TabIndex="14">
                                <asp:ListItem>Amt</asp:ListItem>
                                <asp:ListItem>Rate</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px;">
                            <asp:TextBox ID="txt_tot_HSS_Chrg" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="17" TabIndex="15" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_Date" style="width: 30px;">
                            Curr.
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 55px;">
                            <asp:TextBox ID="txtHSS_Currency" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="16" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                                Width="50px" onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_Date" style="width: 40px;">
                            Ex.Rt.
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 65px;">
                            <asp:TextBox ID="txtHSS_ExRate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="17" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" Width="60px"></asp:TextBox>
                        </div>
                        <%--<div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Split_HSS_Currency'); return false"
                                tabindex="17" class="magnfy"></a>
                        </div>--%>
                        
                    </div>
                     
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 160px;">
                        <div id="tag_label_transact_Src" style="width: 50px; font-weight: bold">
                            Tot. Inv
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px;">
                            <asp:TextBox ID="txt_tot_inv_amt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                Enabled="false" MaxLength="17" TabIndex="5" onblur="extractNumber(this,2,false);"
                                onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                        </div>
                    </div>
                <%--</div>--%>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <%--<div id="innerbox_MidMain_Trans" style="width: 950px; height: 5px; margin-top: -12px;">
             </div>--%>
            <%--<div class="content" id="page-1" style="margin-left:-30px; margin-top:-15px; width:1110px;">
                <div id="open_item" runat="server">
                <div class="content" id="page-6" >--%>
            <div id="pop_text_area_transac_popup_inn_container_export" style="height: 42px; width: 1100px;
                margin-top: -16px; overflow: hidden;">
                <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: hidden; height: 1100px;
                    width: 1100px;">
                    <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                        CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                        HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_Details_RowCreated"
                        OnRowDataBound="gv_Details_RowDataBound" Style="overflow: auto;">
                        <Columns>
                            <asp:BoundField DataField="d" HeaderText="SlNo" HeaderStyle-Width="30px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="b" HeaderText="Terms" HeaderStyle-Width="40px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="c" HeaderText="Inv.Cur" HeaderStyle-Width="30px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="d" HeaderText="Inv.Value" HeaderStyle-Width="60px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="d" HeaderText="Fre.A/R" HeaderStyle-Width="40px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="f" HeaderText="Curr" HeaderStyle-Width="30px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Fre.Rate" HeaderStyle-Width="50px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Fre.Amt" HeaderStyle-Width="80px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Ins.A/R" HeaderStyle-Width="40px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Ins.Cur" HeaderStyle-Width="30px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Ins.Rate" HeaderStyle-Width="50px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Ins.Amt" HeaderStyle-Width="80px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Misc.A/R" HeaderStyle-Width="40px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Curr" HeaderStyle-Width="40px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Misc.Rate" HeaderStyle-Width="60px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Misc.Amt" HeaderStyle-Width="80px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="" HeaderStyle-Width="0px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="" HeaderStyle-Width="0px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="" HeaderStyle-Width="0px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="" HeaderStyle-Width="0px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>

                             <asp:BoundField DataField="g" HeaderText="HSS.A/R" HeaderStyle-Width="40px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="Curr" HeaderStyle-Width="40px" HeaderStyle-Font-Bold="True">
                                <ItemStyle CssClass="column_style_left_border_2_new" />
                            </asp:BoundField>
                            <asp:BoundField DataField="g" HeaderText="HSS.Rate" HeaderStyle-Width="60px" HeaderStyle-Font-Bold="True">
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
                width: 1100px; margin-top: -16px; overflow: hidden;">
                <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow-x: hidden; overflow-y: auto;
                    height: 252px; width: 1100px;">
                    <asp:GridView ID="gv_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                        ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                        AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                        OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                        ShowHeader="false" DataKeyNames="INVOICE_SLNO">
                        <RowStyle BorderWidth="0.1em" BorderColor="black" />
                        <Columns>
                            <%-- <asp:BoundField DataField="INVOICE_NO" HeaderText="Sno" HeaderStyle-Width="80px">
                                    <ItemStyle CssClass="column_style_left_border_2_new"  Width="80px" />
                                 </asp:BoundField>--%>
                            <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Sno" HeaderStyle-Width="50px">
                                <ItemStyle CssClass="column_style_left_border_2_new" Width="50px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl_Inv_Terms" Text='<%# Bind("TERMS") %>' MaxLength="20" runat="server"
                                        Width="50px" Font-Size="12px" CssClass=" txtbox_trans_exp_drawback">
                                        <asp:ListItem>FOB</asp:ListItem>
                                        <asp:ListItem>CI</asp:ListItem>
                                        <asp:ListItem>CF</asp:ListItem>
                                        <asp:ListItem>CIF</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="25px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_Inv_Cur" Text='<%# Bind("INVOICE_CURRENCY") %>' MaxLength="20"
                                                runat="server" Width="50px" Font-Size="12px" CssClass=" txtbox_trans_exp_drawback">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>AED</asp:ListItem>
                                                <asp:ListItem>AUD</asp:ListItem>
                                                <asp:ListItem>BHD</asp:ListItem>
                                                <asp:ListItem>CAD</asp:ListItem>
                                                <asp:ListItem>CHF</asp:ListItem>
                                                <asp:ListItem>CNY</asp:ListItem>
                                                <asp:ListItem>DKK</asp:ListItem>
                                                <asp:ListItem>EUR</asp:ListItem>
                                                <asp:ListItem>GBP</asp:ListItem>
                                                <asp:ListItem>HKD</asp:ListItem>
                                                <asp:ListItem>INR</asp:ListItem>
                                                <asp:ListItem>JPY</asp:ListItem>
                                                <asp:ListItem>KES</asp:ListItem>
                                                <asp:ListItem>KWD</asp:ListItem>
                                                <asp:ListItem>NOK</asp:ListItem>
                                                <asp:ListItem>NZD</asp:ListItem>
                                                <asp:ListItem>QAR</asp:ListItem>
                                                <asp:ListItem>SAR</asp:ListItem>
                                                <asp:ListItem>SEK</asp:ListItem>
                                                <asp:ListItem>SGD</asp:ListItem>
                                                <asp:ListItem>USD</asp:ListItem>
                                                <asp:ListItem>ZAR</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" CssClass="column_style_left_border_2_new" />
                                    </asp:TemplateField>--%>
                            <%-- <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="Sno" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle CssClass="column_style_left_border_2_new" Width="40px" HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Inv.Curr" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Invoice_Curr" Text='<%# Bind("INVOICE_CURRENCY") %>' Width="30px"
                                        runat="server"  Font-Bold="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="INVOICE_VALUE" HeaderText="Unit" HeaderStyle-Width="80px">
                                <ItemStyle CssClass="column_style_right_new" Width="80px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl_Fri_A_R" Text='<%# Bind("MI_FREIGHT") %>' MaxLength="20"
                                        runat="server" ForeColor="Red" Font-Bold="true" Width="50px" Font-Size="12px"
                                        CssClass=" txtbox_trans_exp_drawback">
                                        <asp:ListItem>Amt</asp:ListItem>
                                        <asp:ListItem>Rate</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="40px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Frt.Curr" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Freight_Curr" Text='<%# Bind("MIS_FREIGHT_CURRENCY") %>' Width="30px"
                                        runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Fri_Rate" Text='<%# Bind("MIS_FREIGHT_RATE") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="50px" runat="server" ForeColor="Red" Font-Bold="true"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Fri_Amt" Text='<%# Bind("MIS_FREIGHT_CHARGES") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="80px" runat="server" ForeColor="Red" Font-Bold="true"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl_Ins_A_M" Text='<%# Bind("MI_INSURANCE") %>' MaxLength="20"
                                        runat="server" ForeColor="Green" Font-Bold="true" Width="50px" Font-Size="12px"
                                        CssClass=" txtbox_trans_exp_drawback">
                                        <asp:ListItem>Amt</asp:ListItem>
                                        <asp:ListItem>Rate</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="40px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Curr" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Insurnce_Curr" Text='<%# Bind("MIS_INSURANCE_CURRENCY") %>' Width="30px"
                                        runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ins_Rate" Text='<%# Bind("MIS_INSURANCE_RATE") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="50px" runat="server" ForeColor="Green" Font-Bold="true"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ins_Amt" Text='<%# Bind("MIS_INSURANCE_CHARGES") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="80px" runat="server" Font-Bold="true" ForeColor="Green"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl_Misc_A_M" Text='<%# Bind("MI_MISC") %>' MaxLength="20"
                                        runat="server" ForeColor="Blue" Font-Bold="true" Width="50px" Font-Size="12px"
                                        CssClass=" txtbox_trans_exp_drawback">
                                        <asp:ListItem>Amt</asp:ListItem>
                                        <asp:ListItem>Rate</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="40px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Curr" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                    <asp:Label ID="lbl_MISC_Curr" Text='<%# Bind("MIS_CURRENCY") %>' Width="30px"
                                        runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Misc_Rate" Text='<%# Bind("MIS_RATE") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="50px" runat="server" ForeColor="Blue" Font-Bold="true"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Misc_Amt" Text='<%# Bind("MIS_CHARGES") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="70px" runat="server" Font-Bold="true" ForeColor="Blue"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="70px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="INV_MISC_CHARGES" HeaderText="Unit" HeaderStyle-Width="0px"
                                HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INV_MISC_CURRENCY" HeaderText="Unit" HeaderStyle-Width="0px"
                                HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INV_MISC_EXRATE" HeaderText="Unit" HeaderStyle-Width="0px"
                                HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INVOICE_EXRATE" HeaderText="Unit" HeaderStyle-Width="0px"
                                HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MIS_FREIGHT_EXRATE" HeaderText="Unit" HeaderStyle-Width="0px"
                                HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MIS_INSURANCE_EXRATE" HeaderText="Unit" HeaderStyle-Width="0px"
                                HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MIS_EXRATE" HeaderText="Unit" HeaderStyle-Width="0px"
                                HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="MIS_HIGHSEASALE_EXRATE" HeaderText="Unit" HeaderStyle-Width="0px"
                                HeaderStyle-CssClass="hideGridColumn">
                                <ItemStyle CssClass="hideGridColumn" Width="0px" />
                            </asp:BoundField>

                            <%--<asp:BoundField DataField="D_AMOUNT" HeaderText="Unit" HeaderStyle-Width="0px"  HeaderStyle-CssClass="hideGridColumn" >
                                        <ItemStyle CssClass="hideGridColumn"  Width="0px" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="M_AMOUNT" HeaderText="Unit" HeaderStyle-Width="0px"  HeaderStyle-CssClass="hideGridColumn" >
                                        <ItemStyle CssClass="hideGridColumn"  Width="0px" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="N_AMOUNT" HeaderText="Unit" HeaderStyle-Width="0px"  HeaderStyle-CssClass="hideGridColumn" >
                                        <ItemStyle CssClass="hideGridColumn"  Width="0px" />
                                    </asp:BoundField>--%>

                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl_HSS_A_M" Text='<%# Bind("MI_HSS") %>' MaxLength="20"
                                        runat="server" ForeColor="DeepPink" Font-Bold="true" Width="60px" Font-Size="12px"
                                        CssClass=" txtbox_trans_exp_drawback">
                                        <asp:ListItem>Amt</asp:ListItem>
                                        <asp:ListItem>Rate</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="40px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Misc.Curr" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_HSS_Curr" Text='<%# Bind("MIS_HIGHSEASALE_CURRENCY") %>' Width="30px"
                                        runat="server" ForeColor="DeepPink" Font-Bold="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_HSS_Rate" Text='<%# Bind("MIS_HIGHSEASALE_RATE") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="50px" runat="server" ForeColor="DeepPink" Font-Bold="true"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_HSS_Amt" Text='<%# Bind("MIS_HIGHSEASALE_CHARGES") %>' onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        Width="70px" runat="server" Font-Bold="true" ForeColor="DeepPink"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="70px" CssClass="column_style_left_border_2_new" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <p id="pTotal" style="color: Red; font-size: large;">
                </div>
                <%-----------------------Test--------------------------------------------------------%>
            </div>
            <%-- </div> 29-09
                </div>
                 </div>--%>
            <%-- --------------------Test Start----------------------------%>
            <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px; margin-left: 20px;
                margin-top: -14px;">
                <div id="innerbox_transac_bot_inn">
                    <%-- <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="61" onclick="btnNew_Click1" />
                        </div>--%>
                    <div id="editbu">
                        <%--<asp:Button ID="btncopy" runat="server" CausesValidation="false" UseSubmitBehavior="false" 
                            TabIndex="18" CssClass="autowidmovebut" Text="Convert to Update" OnClientClick="validate_Invoice(); return false;"  OnClick="btnupdate_Click"
                            Width="200px" />--%>
                           <%-- <asp:Button ID="btncopy"  runat="server" CssClass="autowidmovebut" Text="Convert to Update" 
                        OnClientClick="return validate_Invoice();" TabIndex="18"  Width="200px"/>--%>

                        <%--<asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnupdate_Click"
                        Visible="false" TabIndex="81" />--%>

                        <asp:Button ID="btnupdate"  runat="server" CssClass="autowidmovebut" Text="Convert to Update"  OnClick="btnupdate_Click"
                        OnClientClick="return validate_Invoice();" TabIndex="18"  Width="200px"/>
                    </div>
                    <div id="editbu">
                        <%-- <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="63">--%>
                    </div>
                </div>
            </div>
            <%-- --------------------Test End----------------------------%>
            <%--</div> 29-09
                 </div>--%>
            <%-----------------------------------END----------------------------------------------------------------%>
            <script src="../activatables.js" type="text/javascript"></script>
            <%--<script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>--%>

            <asp:HiddenField ID="hdn_valid" runat="server" />
            <asp:HiddenField ID="hdn_FRT_Cur" runat="server" />
            <asp:HiddenField ID="hdn_FRT_Exrt" runat="server" />
            <asp:HiddenField ID="hdn_INS_Cur" runat="server" />
            <asp:HiddenField ID="hdn_INS_Exrt" runat="server" />
            <asp:HiddenField ID="hdn_MISC_Cur" runat="server" />
            <asp:HiddenField ID="hdn_MISC_Exrt" runat="server" />
            <asp:HiddenField ID="hdn_HSS_Cur" runat="server" />
            <asp:HiddenField ID="hdn_HSS_Exrt" runat="server" />
            <asp:HiddenField ID="HD_TransportMode" runat="server" />
            <asp:HiddenField ID="HD_Inv_ExRate" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>
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
    <script type="text/javascript">
        $(function () {
            $("#txtFRT_Currency,#txtIns_Currency,#txtMisc_Currency,#txtHSS_Currency").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exchage_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txtFRT_Currency') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Freight Currency', 'error', 'bottomRight', true);
                                }
                                if (field == 'txtIns_Currency') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Insurance Currency', 'error', 'topRight', true);
                                }
                                if (field == 'txtMisc_Currency') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Miscellaneous Currency', 'error', 'bottomRight', true);
                                }
                                if (field == 'txtHSS_Currency') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect HSS Currency', 'error', 'topRight', true);
                                }
                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                /*
                                var result = data.d;
                                var stringsearch = "-", str = result;
                                for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                                if (i == 1) {
                                if (field == 'txtFRT_Currency') {
                                $('#txtFRT_Currency').val(result);
                                }

                                if (field == 'txtAgency_Currency') {
                                $('#txtAgency_Currency').val(result);
                                }

                                if (field == 'txtMisc_Currency') {
                                $('#txtMisc_Currency').val(result);
                                }

                                if (field == 'txtHSS_Currency') {
                                $('#txtHSS_Currency').val(result);
                                }

                                }
                                */
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            //////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });



        function Call_Excahnge_Rate(src, dest) {
            var ctrl = document.getElementById(src);
            // call server side method
            //alert('l');
            var ieccode = document.getElementById(src).value;
            if (ieccode.length == 3) {
                PageMethods.GetExchange_Rate(ctrl.value, CallSuccess, CallFailed, dest);

            }
        }


        function CallSuccess(res, destCtrl) {
            //var dest = document.getElementById(destCtrl);
            //dest.value = res;
            //document.getElementById("hdn_Invoice_Currency_Exrate").value = document.getElementById("txtExRate").value;

            var data = res;
            //                    alert(destCtrl);
            if (data.length == 0) {
                //                        if (destCtrl == 'txtFRT_ExRate') {
                //                            $('#txtFRT_ExRate').val(data);
                //                        }
            }
            else {
                if (destCtrl == 'txtFRT_ExRate') {
                    $('#txtFRT_ExRate').val(data);
                }
                if (destCtrl == 'txtINS_ExRate') {
                    $('#txtINS_ExRate').val(data);
                }
                if (destCtrl == 'txtMisc_ExRate') {
                    $('#txtMisc_ExRate').val(data);
                }
                if (destCtrl == 'txtHSS_ExRate') {
                    $('#txtHSS_ExRate').val(data);
                }
            }
        }

    </script>


    
<script type="text/javascript">

    function validate_Invoice() {

        var tot_Freight_Chrg = document.getElementById("txt_tot_Freight_Chrg").value;
        var FRT_Currency = document.getElementById("txtFRT_Currency").value;
        var FRT_ExRate = document.getElementById("txtFRT_ExRate").value;

        document.getElementById("hdn_valid").value = "";
        
        if (tot_Freight_Chrg != '') {
            if (FRT_Currency == '') {
                document.getElementById("hdn_FRT_Cur").value = "err_FRT_Curr";
                document.getElementById("hdn_valid").value = "err";
//                document.getElementById('txtFRT_Currency').style.border = "1px solid Red";
            }
            else {
//                document.getElementById('txtFRT_Currency').style.border = "1px solid #c8c8c8";
                document.getElementById("hdn_FRT_Cur").value = "";
            }
            if (FRT_ExRate == '') {
                document.getElementById("hdn_FRT_Exrt").value = "err_FRT_Exrate";
                document.getElementById("hdn_valid").value = "err";
            }
            else {
//                document.getElementById('txtFRT_ExRate').style.border = "1px solid #c8c8c8";
                document.getElementById("hdn_FRT_Exrt").value = "";
            }
            if (FRT_Currency != '' && FRT_ExRate != '') {
                
            }
        }

        var tot_Ins_Chrg = document.getElementById("txt_tot_Ins_Chrg").value;
        var Ins_Currency = document.getElementById("txtIns_Currency").value;
        var INS_ExRate = document.getElementById("txtINS_ExRate").value;

        if (tot_Ins_Chrg != '') {
            if (Ins_Currency == '') {
                document.getElementById("hdn_INS_Cur").value = "err_Ins_Curr";
                document.getElementById("hdn_valid").value = "err";
            }
            else {
                document.getElementById("hdn_INS_Cur").value = "";
            }
            if (INS_ExRate == '') {
                document.getElementById("hdn_INS_Exrt").value = "err_Ins_Exrate";
                document.getElementById("hdn_valid").value = "err";
            }
            else {
                document.getElementById("hdn_INS_Exrt").value = "";
            }
        }

        var tot_MISC_Chrg = document.getElementById("txt_tot_MISC_Chrg").value;
        var Misc_Currency = document.getElementById("txtMisc_Currency").value;
        var Misc_ExRate = document.getElementById("txtMisc_ExRate").value;

        if (tot_MISC_Chrg != '') {
            if (Misc_Currency == '') {
                document.getElementById("hdn_MISC_Cur").value = "err_MISC_Curr";
                document.getElementById("hdn_valid").value = "err";
            }
            else {
                document.getElementById("hdn_MISC_Cur").value = "";
            }
            if (Misc_ExRate == '') {
                document.getElementById("hdn_MISC_Exrt").value = "err_MISC_Exrate";
                document.getElementById("hdn_valid").value = "err";
            }
            else {
                document.getElementById("hdn_MISC_Exrt").value = "";
            }
        }

        var tot_HSS_Chrg = document.getElementById("txt_tot_HSS_Chrg").value;
        var HSS_Currency = document.getElementById("txtHSS_Currency").value;
        var HSS_ExRate = document.getElementById("txtHSS_ExRate").value;

        if (tot_HSS_Chrg != '') {
            if (HSS_Currency == '') {
                document.getElementById("hdn_HSS_Cur").value = "err_HSS_Curr";
                document.getElementById("hdn_valid").value = "err";
            }
            else {
                document.getElementById("hdn_HSS_Cur").value = "";
            }
            if (HSS_ExRate == '') {
                document.getElementById("hdn_HSS_Exrt").value = "err_HSS_Exrate";
                document.getElementById("hdn_valid").value = "err";
            }
            else {
                document.getElementById("hdn_HSS_Exrt").value = "";
            }
        }

    }

   
</script>

<script type="text/javascript">    // Added by pandiyan on 01-07-2026

    function validate_Invoice() {

        // -------- Existing Currency/ExRate validations --------
        var tot_Freight_Chrg = document.getElementById("txt_tot_Freight_Chrg").value;
        var FRT_Currency = document.getElementById("txtFRT_Currency").value;
        var FRT_ExRate = document.getElementById("txtFRT_ExRate").value;

        document.getElementById("hdn_valid").value = "";

        if (tot_Freight_Chrg != '') {
            if (FRT_Currency == '') {
                document.getElementById("hdn_FRT_Cur").value = "err_FRT_Curr";
                document.getElementById("hdn_valid").value = "err";
            } else {
                document.getElementById("hdn_FRT_Cur").value = "";
            }
            if (FRT_ExRate == '') {
                document.getElementById("hdn_FRT_Exrt").value = "err_FRT_Exrate";
                document.getElementById("hdn_valid").value = "err";
            } else {
                document.getElementById("hdn_FRT_Exrt").value = "";
            }
        }

        var tot_Ins_Chrg = document.getElementById("txt_tot_Ins_Chrg").value;
        var Ins_Currency = document.getElementById("txtIns_Currency").value;
        var INS_ExRate = document.getElementById("txtINS_ExRate").value;

        if (tot_Ins_Chrg != '') {
            if (Ins_Currency == '') {
                document.getElementById("hdn_INS_Cur").value = "err_Ins_Curr";
                document.getElementById("hdn_valid").value = "err";
            } else {
                document.getElementById("hdn_INS_Cur").value = "";
            }
            if (INS_ExRate == '') {
                document.getElementById("hdn_INS_Exrt").value = "err_Ins_Exrate";
                document.getElementById("hdn_valid").value = "err";
            } else {
                document.getElementById("hdn_INS_Exrt").value = "";
            }
        }

        var tot_MISC_Chrg = document.getElementById("txt_tot_MISC_Chrg").value;
        var Misc_Currency = document.getElementById("txtMisc_Currency").value;
        var Misc_ExRate = document.getElementById("txtMisc_ExRate").value;

        if (tot_MISC_Chrg != '') {
            if (Misc_Currency == '') {
                document.getElementById("hdn_MISC_Cur").value = "err_MISC_Curr";
                document.getElementById("hdn_valid").value = "err";
            } else {
                document.getElementById("hdn_MISC_Cur").value = "";
            }
            if (Misc_ExRate == '') {
                document.getElementById("hdn_MISC_Exrt").value = "err_MISC_Exrate";
                document.getElementById("hdn_valid").value = "err";
            } else {
                document.getElementById("hdn_MISC_Exrt").value = "";
            }
        }

        var tot_HSS_Chrg = document.getElementById("txt_tot_HSS_Chrg").value;
        var HSS_Currency = document.getElementById("txtHSS_Currency").value;
        var HSS_ExRate = document.getElementById("txtHSS_ExRate").value;

        if (tot_HSS_Chrg != '') {
            if (HSS_Currency == '') {
                document.getElementById("hdn_HSS_Cur").value = "err_HSS_Curr";
                document.getElementById("hdn_valid").value = "err";
            } else {
                document.getElementById("hdn_HSS_Cur").value = "";
            }
            if (HSS_ExRate == '') {
                document.getElementById("hdn_HSS_Exrt").value = "err_HSS_Exrate";
                document.getElementById("hdn_valid").value = "err";
            } else {
                document.getElementById("hdn_HSS_Exrt").value = "";
            }
        }

        // -------- Stop here if existing validations failed --------
        if (document.getElementById("hdn_valid").value == "err") {
            return false;
        }

        // -------- AIR Freight 20% Validation (all converted to INR) --------
        var transportMode = document.getElementById('<%= HD_TransportMode.ClientID %>').value;

        if (transportMode.toUpperCase() == 'AIR') {

            // Freight &#8594; INR
            var freightAmt = parseFloat(document.getElementById("txt_tot_Freight_Chrg").value) || 0;
            var freightExRtRaw = parseFloat(document.getElementById("txtFRT_ExRate").value) || 0;
            var freightExRt = (freightExRtRaw > 0) ? freightExRtRaw : 1;
            var freightINR = freightAmt * freightExRt;

            // MISC &#8594; INR
            var miscAmt = parseFloat(document.getElementById('<%= txt_tot_MISC_Chrg.ClientID %>').value) || 0;
            var miscExRtRaw = parseFloat(document.getElementById("txtMisc_ExRate").value) || 0;
            var miscExRt = (miscExRtRaw > 0) ? miscExRtRaw : 1;
            var miscINR = miscAmt * miscExRt;

            var invExRtRaw = parseFloat(document.getElementById('<%= HD_Inv_ExRate.ClientID %>').value) || 0;
            var invExRt = (invExRtRaw > 0) ? invExRtRaw : 1;

            var totalInvINR = 0;
            var grid = document.getElementById('<%= gv_Details.ClientID %>');
            if (grid) {
                var rows = grid.getElementsByTagName('tr');
                for (var i = 0; i < rows.length; i++) {
                    var cells = rows[i].getElementsByTagName('td');
                    if (cells.length > 3) {
                        var slno = (cells[0].innerText || cells[0].textContent || '').trim();
                        if (!isNaN(parseInt(slno))) {
                            // cell[3] = INVOICE_VALUE, use HD_Inv_ExRate for exrate
                            var invVal = parseFloat((cells[3].innerText || cells[3].textContent || '0').replace(/,/g, '')) || 0;
                            totalInvINR += invVal * invExRt;
                        }
                    }
                }
            }

            // Base = Total Invoice INR + MISC INR
            var baseINR = totalInvINR + miscINR;
            var maxFreight = baseINR * 0.20;

            if (freightINR > maxFreight) {
                jAlert(
                    'Freight amount in INR (' + freightINR.toFixed(2) + ') exceeds 20% of ' +
                    '(Total Invoice + MISC) in INR.\n' +
                    'Total Invoice INR : ' + totalInvINR.toFixed(2) + '\n' +
                    'MISC INR          : ' + miscINR.toFixed(2) + '\n' +
                    'Max Freight Allowed : ' + maxFreight.toFixed(2),
                    'AIR Freight Validation',
                    function (r) {
                        document.getElementById("txt_tot_Freight_Chrg").focus();
                    }
                );
                return false;  // stops postback
            }
        }
        // -------- All validations passed --------
        return true;
    }

</script>

</body>
</html>
