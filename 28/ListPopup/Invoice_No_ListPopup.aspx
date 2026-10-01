<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice_No_ListPopup.aspx.cs"
    Inherits="ListPopups_Invoice_No_ListPopup" %>   

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invoice No Listpopup</title>  
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>
    <style type="text/css">
        .hideGridColumn { display: none; }
        .print_btn:hover { background-position: left bottom; }
    </style>
    <script language="javascript" type="text/javascript">
        function GetRowValue(val) {
            alert(val);
            window.opener.document.getElementById("txtInvoiceNumber").value = val;
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

                <div id="innerbox_MidMain_Mid_country_pop" runat="server">
                    <div id="innerbox_MidMain_popup_country_master">

                        <div id="tag_label_country_pop">
                            Invoice No  
                        </div>
                        <div id="txtcon-l_src_popup">
                        </div>
                        <div id="txtcon_mid_size_popup">
                            <asp:TextBox ID="txtInvoice_Code" runat="server" CssClass="txtbox_none_mid_size_popup"
                                MaxLength="50"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src_popup">
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
                    <div id="tag_srcinner1grid_popup" runat="server">
                        <div id="allbu">
                            <input id="Submit1" type="submit" value="Submit" class="allgrid" runat="server"
                                   onserverclick="btnSearchAll_Click" /></div>
                        <div id="verslic">
                        </div>
                        <div id="mainmastop2container_rght_tag3">
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt">#</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('A')">A</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('B')">B</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('C')">C</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('D')">D</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('E')">E</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('F')">F</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('G')">G</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('H')">H</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('I')">I</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('J')">J</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('K')">K</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('L')">L</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('M')">M</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('N')">N</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('O')">O</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('P')">P</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Q')">Q</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('R')">R</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('S')">S</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('T')">T</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('U')">U</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('V')">V</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('W')">W</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('X')">X</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Y')">Y</a></div>
                            <div id="small-alph-icon-tag"><a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Z')">Z</a></div>
                        </div>
                    </div>
                    <div id="tag_srcinner1grid_innerpopup" runat="server">
                        <asp:GridView runat="server" ID="gvdetails" DataKeyNames="INVOICE_NO" EmptyDataText="NO RECORD FOUND"
                            AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                            OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="30"
                            AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True"
                            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" CellSpacing="0"
                            OnSelectedIndexChanged="gvdetails_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="S.NO">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="INVOICE_NO" HeaderText="Invoice No">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                    <div class="pagination" id="Div_Pagination" runat="server">
                        <div id="tag_label_transaction_popup_IGM_Container">
                            Page No.</div>
                        <div id="txtcon_l_Exchange">
                        </div>
                        <div id="txtcon-m_transaction_list1_fcl">
                            <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                                OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-r_Exchange">
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
            </div>
            <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btnSearch_Click" Style="display: none;" />
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>