<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Hsn_Sac_Listpopup.aspx.cs"
    Inherits="Acc_Hsn_Sac_Listpopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SAC List</title>
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>

    <script language="javascript">

        function GetRowValue(val, val1) {
            if (window.opener && !window.opener.closed) {
                var codeField = window.opener.document.getElementById("txt_HSN_SAC_Code");
                var descField = window.opener.document.getElementById("txt_GST_Category");
                if (codeField) codeField.value = val1;
                if (descField) descField.value = val;
            }
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

        a.small-alph-iconButt
        {
            background-color: #ffffff !important;
            border: 1px solid #d4a030 !important;
            color: #5a3a00 !important;
        }
        a.small-alph-iconButt:hover,
        a.small-alph-iconButt.active
        {
            background-color: #f5c97a !important;
            color: #5a3a00 !important;
        }

        .grid-view th,
        .grid-view .HeaderStyle,
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

        #tag_label_transaction_popup_IGM_Container
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
                    SAC List
                </div>

                <div id="innerbox_MidMain_Mid_country_pop">
                    <div id="innerbox_MidMain_popup_country_master">

                        <div id="tag_label_country_pop">
                            Code
                        </div>
                        <div id="txtcon-l_src_popup">
                        </div>
                        <div id="txtcon_mid_size_popup">
                            <asp:TextBox ID="txtCode" runat="server" CssClass="txtbox_none_mid_size_popup"
                                MaxLength="20"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src_popup">
                        </div>

                        <div id="tag_label_currency_pop_empty">
                        </div>

                        <div id="tag_label_country_pop">
                            Description
                        </div>
                        <div id="txtcon-l_src_popup">
                        </div>
                        <div id="txtcon_mid_size_popup">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="txtbox_none_mid_size_popup"
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

                <div id="innerbox_MidMain_Grid_currency_pop">

                    <div id="tag_srcinner1grid_popup">
                        <div id="allbu">
                            <input type="submit" value="Submit" class="allgrid" runat="server"
                                onserverclick="btnSearchAll_Click" /></div>
                        <div id="verslic">
                        </div>
                        <div id="mainmastop2container_rght_tag3">
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt">#</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('A')">A</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('B')">B</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('C')">C</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('D')">D</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('E')">E</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('F')">F</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('G')">G</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('H')">H</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('I')">I</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('J')">J</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('K')">K</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('L')">L</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('M')">M</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('N')">N</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('O')">O</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('P')">P</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Q')">Q</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('R')">R</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('S')">S</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('T')">T</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('U')">U</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('V')">V</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('W')">W</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('X')">X</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Y')">Y</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Z')">Z</a></div>
                        </div>
                    </div>

           
                    <div id="tag_srcinner1grid_innerpopup">
                        <asp:GridView runat="server" ID="gvdetails" DataKeyNames="CODE" EmptyDataText="NO RECORD FOUND"
                            AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                            OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="10"
                            AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"  AllowSorting="False"
                            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                            OnSelectedIndexChanged="gvdetails_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />

                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:CommandField>

                                <asp:BoundField DataField="CODE" HeaderText="Code" >
                                    <ItemStyle CssClass="column_style_left" Width="90px" />
                                    <HeaderStyle Width="90px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DESCRIPTION" HeaderText="Description">
                                    <ItemStyle CssClass="column_style_left" Width="300px" />
                                    <HeaderStyle Width="300px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="IGST_RATE" HeaderText="IGST Rate (%)"
                                    DataFormatString="{0:N2}">
                                    <ItemStyle CssClass="column_style_right" Width="110px" />
                                    <HeaderStyle Width="110px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="CGST_RATE" HeaderText="CGST Rate (%)"
                                    DataFormatString="{0:N2}">
                                    <ItemStyle CssClass="column_style_right" Width="110px" />
                                    <HeaderStyle Width="110px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="SGST_RATE" HeaderText="SGST Rate (%)"
                                    DataFormatString="{0:N2}">
                                    <ItemStyle CssClass="column_style_right" Width="110px" />
                                    <HeaderStyle Width="110px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="UTGST_RATE" HeaderText="UTGST Rate (%)"
                                    DataFormatString="{0:N2}">
                                    <ItemStyle CssClass="column_style_right" Width="110px" />
                                    <HeaderStyle Width="110px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="CESS_RATE" HeaderText="CESS Rate (%)"
                                    DataFormatString="{0:N2}">
                                    <ItemStyle CssClass="column_style_right" Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="KFC_RATE" HeaderText="KFC Rate (%)"
                                    DataFormatString="{0:N2}">
                                    <ItemStyle CssClass="column_style_right" Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="RCM_APPLICABLE" HeaderText="RCM Applicable">
                                    <ItemStyle CssClass="column_style_left" Width="100px" />
                                    <HeaderStyle Width="100px" />
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

    <script type="text/javascript" language="javascript">

        function timeoutCheck() {

            var UserID = '<%=Session["currentuser"]%>';
            var UserBranch = '<%=Session["currentbranch"]%>';
            var UserCompany = '<%=Session["currentcomp_name"]%>';
            var UserDataBase = '<%=Session["currentcomp_db"]%>';
            var UserWorking_Period = '<%=Session["WorkingPeriod"]%>';
            var UserLogin_Date = '<%=Session["LoginDate"]%>';
            if (UserID == '' || UserBranch == '' || UserCompany == '' || UserDataBase == '' || UserWorking_Period == '' || UserLogin_Date == '') {
                self.close();
            }
            else {
            }
        }

    </script>
</body>
</html>
