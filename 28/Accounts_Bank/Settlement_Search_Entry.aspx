<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    CodeFile="Settlement_Search_Entry.aspx.cs" Inherits="Settlement_Search_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .cls_cls_center
        {
            line-height: 1.5em;
            border-left: #c8c8c8 solid thin;
            padding-left: 18px;
            text-align: center;
            padding-right: 18px;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div id="innerbox_MidMain" style="height: 105px;">
                <div id="tag_srcinner1">
                    <div id="newbu">
                        <input type="submit" value="Submit" class="new" onclick="OpenNewSettlementPage(); return false;" />
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Settlement Search Entry
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1200px; height: 70px; margin-top: 3px">
                    <div style="display: flex">
                        <div id="tag_label_transact_Src">
                            Organization
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txt_OrganizationCode" runat="server"
                                ClientIDMode="Static" CssClass="txtbox_none" style="width:300px"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                            <div runat="server" id="ST_Code">
                                <a href="#" style="margin-left:209px;" class="magnfy" onclick="openOrganizationName('ALL')">
                                </a>
                            </div>
                        </div>
                        <div style="margin-left: 232px;">
                            <div id="tag_label_transact_Src" style="margin-left: 10px;width:62px;">
                                Trans.No
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txttransNo" runat="server" Width="147px" CssClass="txtbox_none"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_label_transact_Src" style="margin-left: 70px;width:50px;">
                            Status
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList CssClass="txtbox_none" Width="150px" runat="server">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transact_Src" style="margin-left: 70px; width: 47px;">
                            Period
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <div id="txtcon-m_transaction_code" style="width: 170px;">
                                <asp:TextBox ID="txtPeriodDate" runat="server" ClientIDMode="Static" Width="78px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPeriodDate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender100" runat="server" TargetControlID="txtPeriodDate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                    </div>
                    <div style="display: flex; margin-top: 13px;">
                        <div id="tag_label_transact_Src" style="width: 58px; padding-right: 37px;">
                            Narration
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtNarration" runat="server" Width="300px"  CssClass="txtbox_none"></asp:TextBox>
                        </div>
                     <%--   <div id="tag_label_transact_Src" runat="server" visible="false" style="margin-left: 97px; width: 51px;">
                            Amount
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 57px;">
                            <asp:DropDownList ID="ddlAmount" CssClass="txtbox_none" Width="50px" Visible="false" runat="server">
                                <asp:ListItem Value="" Text="" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="&gt;=" Text="&gt;="></asp:ListItem>
                                <asp:ListItem Value="&lt;=" Text="&lt;="></asp:ListItem>
                                <asp:ListItem Value="=" Text="="></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtAmount" runat="server" Visible="false"  onkeypress="return notnDecimal(event)"
                                Width="100px" CssClass="txtbox_none"></asp:TextBox>
                        </div>--%>
                        <div id="tag_label_transact_Src" style="width: 50px; margin-left: 246px">
                            Location
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlLocation" Style="margin-left: 7px;" CssClass="txtbox_none"
                                Width="155" runat="server">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div style="margin-left: 100px; margin-top: -3px;">
                            <div id="small-butt-left">
                                <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                    tabindex="5"></a>
                            </div>
                            <div id="small-butt-rght">
                                <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Grid" style="height: 500px">
                <div class="pagination" id="Div_Pagination" runat="server" style="margin-bottom: 8px;">
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
                    <span class="selected">Page
                        <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
                        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                    </span><span class="disabled">
                        <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                    <span class="disabled">
                        <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                    </span>
                </div>
                <div runat="server" id="div_pagination1" visible="false">
                    <br />
                    <br />
                </div>
                <div id="Main_Grid_Container" runat="server">
                    <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                        CssClass="grid-view" ShowHeaderWhenEmpty="True" Width="100%"
                        OnRowCreated="gvdetails_RowCreated" 
                        OnRowDataBound="gvdetails_RowDataBound" DataKeyNames="S_PF,S_NO,S_SF"
                        PageSize="20" CellPadding="1" CellSpacing="1">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            CssClass="column_style_left" BorderWidth="1px" />
                        <HeaderStyle Font-Underline="false" ForeColor="Black" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="65px">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Width="65px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PAYEMENTNO" HeaderText="Payment No" HeaderStyle-Width="210">
                                <HeaderStyle Width="210px" />
                                <ItemStyle CssClass="cls_cls_center" Width="210" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ENTRYDATE" HeaderText="Entry Date" DataFormatString="{0:dd/MM/yyyy}"
                                HeaderStyle-Width="150">
                                <HeaderStyle Width="150px" />
                                <ItemStyle  CssClass="cls_cls_center" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="POSTINGDATE" HeaderText="Payment Date" DataFormatString="{0:dd/MM/yyyy}"
                                HeaderStyle-Width="150">
                                <HeaderStyle Width="150px" />
                                <ItemStyle CssClass="cls_cls_center" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AMOUNT" HeaderText="Amount" HeaderStyle-Width="100">
                                <HeaderStyle Width="100px" />
                                <ItemStyle CssClass="cls_cls_center" Width="100" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Description">
                               
                                <ItemTemplate>
                                    <asp:Label ID="lblNarration" runat="server" Text='<%# Bind("NARRATION") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="column_style_left" Width="300px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../js/Accounts/Acc_listpopup.js" type="text/javascript"></script>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <script type="text/javascript">
        function notnDecimal(evt) {
            var charcode = (evt.which) ? evt.which : event.keyCode;
            var inputValue = (evt.target) ? evt.target.value : '';

            if (charcode <= 27 || charcode == 8 || charcode == 9) {
                return true;
            }

            if (charcode == 46) {
                if (inputValue.indexOf('.') !== -1) {
                    return false;
                }
                return true
            }
            if (charcode >= 48 && charcode <= 57) {
                return true
            }
            return false;
        }

        function OpenNewSettlementPage() {
            var w = 1250;
            var h = 780;
            var LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            var TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
            settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=yes,resizable=no';
            window.open('../Accounts_Bank/SettlementEntry.aspx', 'Settlement', settings);
        }

        function OpenSettlementpage(s_pf, s_no, s_sf) {
            var w = 1250;
            var h = 780;
            var LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            var TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
            settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=yes,resizable=no';
            window.open('../Accounts_Bank/SettlementEntry.aspx?S_PF=' + encodeURIComponent(s_pf) + '&S_NO=' + encodeURIComponent(s_no) + 
            '&S_SF=' +encodeURIComponent(s_sf), 'Settlement', settings);
        }
        function RefreshSearchGrid() {
            __doPostBack('<%= btnSearch.UniqueID %>', '');
        }
    </script>
</asp:Content>
