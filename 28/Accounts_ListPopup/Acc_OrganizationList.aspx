<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_OrganizationList.aspx.cs"
    Inherits="Accounts_Others_Acc_OrganizationList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Organization Names</title>
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script>
        function bindClientName(val) {
            var elOrg = window.opener.document.getElementById("txtOrgnaizationName");
            if (elOrg) {
                elOrg.value = val;
             }

            var elName = window.opener.document.getElementById('txtName');
            if (elName) {
                elName.value = val;
             }
            // window.opener.selectOrganization(val);

            try {
                if (window.opener && typeof window.opener.selectOrganization === 'function') {
                    window.opener.selectOrganization(val);
                }
            } catch (e) {
                console.error('selectOrganization failed:', e);
            }
            window.close();
        }
        function bindOrganizationName(val) {
            window.opener.document.getElementById('txt_OrganizationCode').value = val;
            window.close();
        }
    </script>
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
        
        .grid-view th, table.grid-view tr th
        {
            background-color: #f5c97a !important;
            color: #5a3a00 !important;
            border-color: #d4a030 !important;
        }
        .AlternatingRowStyle, table.grid-view tr.AlternatingRowStyle
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
                    Organization List
                </div>
                <div id="innerbox_MidMain_Mid_country_pop">
                    <div id="innerbox_MidMain_popup_country_master">
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
                            <a href="#" class="srcbu" runat="server" id="btnSearch" onserverclick="btnSearch_Click"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="#" class="cancelButt" onclick="window.close();"></a>
                        </div>
                    </div>
                </div>
                <div id="tag_srcinner1grid_popup">
                    <div id="allbu">
                        <input id="Submit1" type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click" /></div>
                    <div id="verslic">
                    </div>
                </div>
                <div id="tag_srcinner1grid_innerpopup">
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                        OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="10"
                        AllowPaging="True" AllowSorting="False" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowDataBound="gvdetails_RowDataBound"
                        OnSelectedIndexChanged="gvdetails_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="IMP_EXP_NAME" HeaderText="Name">
                                <ItemStyle CssClass="column_style_left" Width="320px" />
                                <HeaderStyle Width="320px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
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
            <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btnSearch_Click" Style="display: none;" />
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
