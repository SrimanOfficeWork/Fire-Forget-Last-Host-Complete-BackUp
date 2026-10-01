<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_GL_ListPopup_Orgainzation.aspx.cs" Inherits="Acc_GL_ListPopup_Orgainzation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Organization General Popup</title>

    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>
     <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }

        #innerbox_MidMain_top_currency
        {
            background-color: #f5c97a !important;
            color: #5a3a00 !important;
            border-bottom: 1px solid #d4a030 !important;
            font-weight: bold;
        }
        a.srcbu
        {
            background-color: #f5c97a !important;
            border: 1px solid #d4a030 !important;
            color: #5a3a00 !important;
        }
        a.cancelButt
        {
            background-color: #f5c97a !important;
            border: 1px solid #d4a030 !important;
            color: #5a3a00 !important;
        }
        .grid-view th,
        table.grid-view tr th
        {
            background-color: #f5c97a !important;
            color: #5a3a00 !important;
            border-color: #d4a030 !important;
        }
        .AlternatingRowStyle,
        table.grid-view tr.AlternatingRowStyle
        {
            background-color: #fdf3e0 !important;
        }
        .pagination
        {
            background-color: #f5c97a !important;
            border-top: 1px solid #d4a030 !important;
        }
        .pagination span.selected
        {
            background-color: #ffffff !important;
            border: 1px solid #d4a030 !important;
            color: #5a3a00 !important;
        }
        .pagination a
        {
            color: #5a3a00 !important;
        }
        #innerbox_MidMain_popup_currency
        {
            background-color: #ffffff !important;
        }
        body
        {
            background-color: #fffaf0 !important;
        }
    </style>
    <script type="text/javascript">
        function BindRowValueIn_txtCust_GL(val,val1) {
            window.opener.document.getElementById('txtCust_GL').value = val;
            window.opener.document.getElementById('hdnAC_Code').value = val1;
            window.close();
        }

        function BindRowValue_VendorGL(val,val1) {
            window.opener.document.getElementById('txtVendorGL').value = val;
            window.opener.document.getElementById('HdnAV_Code').value = val1;
            window.close();
        }
    </script>
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
                    Accounts Client Master
                </div>

                <div id="innerbox_MidMain_Mid_country_pop">
                    <div id="innerbox_MidMain_popup_country_master">

                        <div id="tag_label_country_pop">
                            Type
                        </div>
                        <div id="txtcon-l_src_popup">
                        </div>
                        <div id="txtcon_mid_size_popup">
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="txtbox_none_mid_size_popup">
                                <asp:ListItem Text="ASSETS" Value="ASSETS" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="LIABILITIES" Value="LIABILITIES"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-r_src_popup">
                        </div>

                        <div id="tag_label_currency_pop_empty">
                        </div>

                        <div id="tag_label_country_pop">
                            Code
                        </div>
                        <div id="txtcon-l_src_popup">
                        </div>
                        <div id="txtcon_mid_size_popup">
                            <asp:TextBox ID="txtCode_1" runat="server" CssClass="txtbox_none_mid_size_popup"
                                MaxLength="20"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src_popup">
                        </div>

                        <div id="tag_label_country_pop">
                            Name
                        </div>
                        <div id="txtcon-l_src_popup">
                        </div>
                        <div id="txtcon_mid_size_popup">
                            <asp:TextBox ID="txtName_1" runat="server" CssClass="txtbox_none_mid_size_popup"
                                MaxLength="100"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src_popup">
                        </div>

                    </div>

                    <div id="tag_srcinner_rght2_country">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" runat="server" id="btnSearch"
                                onserverclick="btnSearch_Click" onclick="page_Loading();"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="#" class="cancelButt" onclick="window.close();"></a>
                        </div>
                    </div>

                </div>
               <%-- OnSelectedIndexChanged="gvdetails_SelectedIndexChanged"--%>
                <div id="innerbox_MidMain_Grid_currency_pop">
                    <div id="tag_srcinner1grid_popup">
                        <div id="allbu">
                            <input id="Submit1" type="submit" value="Submit" class="allgrid" runat="server"
                                onserverclick="btnSearchAll_Click" /></div>
                        <div id="verslic">
                        </div>
                    </div>
                    
                    <div id="tag_srcinner1grid_innerpopup">
                        <asp:GridView runat="server" ID="gvdetails" DataKeyNames="ID" EmptyDataText="NO RECORD FOUND"
                            AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                            OnRowCreated="gvdetails_RowCreated" Width="100%" 
                            ShowHeaderWhenEmpty="True" PageSize="10"
                            AllowPaging="True"  AllowSorting="False"
                            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" 
                            CellPadding="1" CellSpacing="1" onrowdatabound="gvdetails_RowDataBound" 
                            onselectedindexchanged="gvdetails_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                                
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:CommandField>

                                <asp:BoundField DataField="NAME" HeaderText="Name">
                                    <ItemStyle CssClass="column_style_left" Width="320px" />
                                    <HeaderStyle Width="320px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="CODE" HeaderText="Code">
                                    <ItemStyle CssClass="column_style_left" Width="130px" />
                                    <HeaderStyle Width="130px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="TYPE" HeaderText="Type">
                                    <ItemStyle CssClass="column_style_left" Width="70px" />
                                    <HeaderStyle Width="70px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="GROUP" HeaderText="Group">
                                    <ItemStyle CssClass="column_style_left" Width="220px" />
                                    <HeaderStyle Width="220px" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                    </div>
                </div>

                <div class="pagination" id="Div_Pagination" runat="server">
                    <div id="tag_label_transaction_popup_IGM_Container">
                        Page No.</div>

                    <div id="txtcon-m_transaction_list1_fcl">
                        <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                            OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <span class="disabled">
                        <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>
                    <span class="disabled">
                        <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
                    <span class="selected">Record
                        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                        -
                        <asp:Label ID="lblTotalPages" runat="server"></asp:Label></span> <span class="disabled">
                            <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                    <span class="disabled">
                        <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                    </span>
                </div>

            </div>

            <asp:HiddenField ID="hdn" runat="server" />
            <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btnSearch_Click" style="display: none;" />
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />

        </ContentTemplate>
    </asp:UpdatePanel>

    </form>
    
</body>
</html>
