<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Job_Prefix_Suffix_ListPopup.aspx.cs"
    Inherits="Product_Imp_Exp_Master_ListPopup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>JOB PREFIX SUFFIX MASTER - Listpopup</title>
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
    <script src="../js/Validation.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_currency">
                <div id="innerbox_MidMain_top_currency">
                    JOB PREFIX SUFFIX MASTER
                </div>
                <div id="innerbox_MidMain_Mid_country_pop">
                    <div id="innerbox_MidMain_popup_country_master">
                        <div id="tag_label_country_pop" style="width: 50px;">
                            Type
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                            <asp:DropDownList ID="ddl_Type" runat="server" Width="100px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Import</asp:ListItem>
                                <asp:ListItem>Export</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_currency_pop_empty">
                        </div>
                        <div id="tag_label_country_pop" style="width: 80px;">
                            Branch Code
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 150px;">
                            <asp:DropDownList ID="ddl_Branch" runat="server" Width="150px">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_currency_pop_empty">
                        </div>
                    </div>
                    <div id="tag_srcinner_rght2_country">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" runat="server" id="btnSearch" onserverclick="btnSearch_Click">
                            </a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="#" class="cancelButt" onclick="window.close();"></a>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Grid_currency_pop">
                    <div id="tag_srcinner1grid_innerpopup" style="height: 320px; overflow: scroll;">
                        <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                            BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                            Width="120%" ShowHeaderWhenEmpty="True" OnRowDataBound="gvdetails_RowDataBound"
                            AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                            CellPadding="1" CellSpacing="1">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:BoundField DataField="JobType" HeaderText="JobType">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JOB_PREFIX" HeaderText="PREFIX">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JOB_SUFFIX" HeaderText="SUFFIX">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JOBNO" HeaderText="JOBNO">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BRANCH_CODE" HeaderText="BRANCH CODE">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TR_MODE" HeaderText="TR MODE">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GROUP_NAME" HeaderText="GROUP NAME">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DATE_TIME" HeaderText="DATE_TIME">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
