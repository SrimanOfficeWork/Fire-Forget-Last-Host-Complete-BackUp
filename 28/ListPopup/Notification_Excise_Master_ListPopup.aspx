<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notification_Excise_Master_ListPopup.aspx.cs"
    Inherits="ListPopup_Notification_Excise_Master_ListPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Notification Master Listpopup</title>
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">

        function GetRowValue_CVD(val, val1, val2, val3, val4) {


            window.opener.document.getElementById("txt_CVD_NOTN").value = val;
            window.opener.document.getElementById("txt_CVD_SLNO").value = val1;
            window.opener.document.getElementById("txt_CVD_RATE").value = val2;


            window.opener.document.getElementById("txt_CVD_SPL").value = val3;
            window.opener.document.getElementById("txt_CVD_UNIT").value = val4;
            window.close();

        }
        function GetRowValue_Addl_Duty(val, val1, val2) {


            window.opener.document.getElementById("txt_Addl5_SIA_NOTN").value = val;
            window.opener.document.getElementById("txt_Addl5_SIA_NOTN_SL").value = val1;
            window.opener.document.getElementById("txt_Addl5_SIA_RATE").value = val2;
            window.close();

        }
        function GetRowValue_Addl_Duty_GSI(val, val1, val2, val3, val4) {


            window.opener.document.getElementById("txt_Addl_GSI_NOTN").value = val;
            window.opener.document.getElementById("txt_Addl_GSI_SL").value = val1;
            window.opener.document.getElementById("txt_Addl_GSI_RATE").value = val2;


            window.opener.document.getElementById("txt_Addl_GSI_SPL").value = val3;
            window.opener.document.getElementById("txt_Addl_GSI_UNIT").value = val4;
            window.close();

        }
        function GetRowValue_Addl_She11_Notn(val, val1, val2, val3, val4) {


            window.opener.document.getElementById("txt_Addl_SHE11_NOTN").value = val;
            window.opener.document.getElementById("txt_Addl_SHE11_SLNO").value = val1;
            window.opener.document.getElementById("txt_Addl_SHE11_RATE").value = val2;


            window.opener.document.getElementById("txt_Addl_SHE11_SPL").value = val3;
            window.opener.document.getElementById("txt_Addl_SHE11_UNIT").value = val4;
            window.close();

        }
        function GetRowValue_Addl_TTA_Notn(val, val1, val2, val3, val4) {


            window.opener.document.getElementById("txt_Addl_TTA_NOTN").value = val;
            window.opener.document.getElementById("txt_Addl_TTA_SLNO").value = val1;
            window.opener.document.getElementById("txt_Addl_TTA_RATE").value = val2;
            window.opener.document.getElementById("txt_Addl_TTA_SPL").value = val3;
            window.opener.document.getElementById("txt_Addl_TTA_UNIT").value = val4;
            window.close();

        }
        function GetRowValue_Addl_Health_Cess(val, val1, val2, val3, val4) {


            window.opener.document.getElementById("txt_Addl_Health_CESS_NOTN").value = val;
            window.opener.document.getElementById("txt_Addl_Health_CESS_SLNO").value = val1;
            window.opener.document.getElementById("txt_Addl_Health_CESS_RATE").value = val2;
            window.opener.document.getElementById("txt_Addl_Health_CESS_SPL").value = val3;
            window.opener.document.getElementById("txt_Addl_Health_CESS_UNIT").value = val4;
            window.close();

        }
        function GetRowValue_Cess_Notn(val, val1, val2, val3, val4) {


            window.opener.document.getElementById("txt_CESS_NOTN").value = val;
            window.opener.document.getElementById("txt_CESS_SLNO").value = val1;
            window.opener.document.getElementById("txt_CESS_RATE").value = val2;
            window.opener.document.getElementById("txt_CESS_SPL").value = val3;
            window.opener.document.getElementById("txt_CESS_UNIT").value = val4;
            window.close();

        }
        function GetRowValue_Infra_Notn(val, val1, val2, val3, val4) {


            window.opener.document.getElementById("txtinfra_cess_Notn").value = val;
            window.opener.document.getElementById("txtinfra_cess_Notn_SLNO").value = val1;
            window.opener.document.getElementById("txtinfra_cess_Notn_RATE").value = val2;

            window.close();

        }

        // --------------------------
        function GetRowValue_LEVY_NOTN(val, val1, val2, val3, val4) {

            window.opener.document.getElementById("txt_IGST_LEVY_NOTN").value = val;
            window.opener.document.getElementById("txt_IGST_LEVY_SLNO").value = val1;
            window.opener.document.getElementById("txt_IGST_LEVY_RATE").value = val2;
            window.opener.document.getElementById("txt_IGST_LEVY_SPL_Amt").value = val3;
            window.opener.document.getElementById("txt_IGST_LEVY_UNIT").value = val4;
            window.close();

        }
        function GetRowValue_LEVY_EXC_NOTN(val, val1, val2, val3, val4) {

            window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_NOTN").value = val;
            window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_SLNO").value = val1;
            window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_RATE").value = val2;
            window.close();

        }
        function GetRowValue_LEVY_CP_CESS_NOTN(val, val1, val2, val3, val4) {

            window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_NOTN").value = val;
            window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SLNO").value = val1;
            window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_RATE").value = val2;
            window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SPL").value = val3;
            window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_UNIT").value = val4;
            window.close();

        }
        function GetRowValue_LEVY_EXC_CP_CESS_NOTN(val, val1, val2, val3, val4) {

            window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_NOTN").value = val;
            window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_SLNO").value = val1;
            window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_RATE").value = val2;
            window.close();

        }
    </script>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
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
                    Notification Excise Master
                </div>
                <div id="innerbox_MidMain_Mid_country_pop">
                    <div id="innerbox_MidMain_popup_country_master">
                    <div id="tag_label_country_pop" style="width: 55px">
                            RITC No
                        </div>
                        <div id="txtcon_mid_size_popup" style="width: 105px">
                            <asp:TextBox ID="txtRITCNo" runat="server" CssClass="txtbox_none_mid_size_popup"
                                Width="90px" MaxLength="8" class="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_country_pop"style="width: 55px; text-align:center;">
                            Notn No
                        </div>
                        <div id="txtcon-l_src_popup">
                        </div>
                        <div id="txtcon_mid_size_popup">
                            <asp:TextBox ID="txtNotnNo" runat="server" CssClass="txtbox_none_mid_size_popup"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src_popup">
                        </div>
                        <div id="tag_label_currency_pop_empty">
                        </div>
                        <div id="tag_label_country_pop"style="width: 35px">
                            Sr.No
                        </div>
                        <div id="txtcon-l_src_popup">
                        </div>
                        <div id="txtcon_mid_size_popup" style="width: 100px">
                            <asp:TextBox ID="txtNotnSrNo" runat="server" CssClass="txtbox_none_mid_size_popup" Width="95px"></asp:TextBox>
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
               
                <div id="tag_srcinner1grid_innerpopup">
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="NOTIFICATION_EXCISE_ID"
                        EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                        GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated" Width="100%"
                        ShowHeaderWhenEmpty="True" PageSize="10" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="CTH_NO" HeaderText="CTH">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_NOTN" HeaderText="Notn">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_NOTN_SL" HeaderText="Notn SNo">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_CETH" HeaderText="Tariff Heading">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_BCD_RATE" HeaderText="Rate">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_BCD_SPL" HeaderText="Amount">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_BCD_UNIT" HeaderText="Unit">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_CVD_RATE" HeaderText="CVD_Rate">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_CVD_SPL" HeaderText="CVD_Amount">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_CVD_UNIT" HeaderText="CVD_Unit">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
                <%--   </div>--%>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
