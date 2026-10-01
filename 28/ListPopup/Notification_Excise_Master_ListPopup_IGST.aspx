<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notification_Excise_Master_ListPopup_IGST.aspx.cs"
    Inherits="ListPopup_Notification_Excise_Master_ListPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Notification Master Listpopup</title>
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        // --------------------------
        function GetRowValue_LEVY_NOTN(val, val1, val2, val3, val4) {

            window.opener.document.getElementById("txt_IGST_LEVY_NOTN").value = val;
            window.opener.document.getElementById("txt_IGST_LEVY_SLNO").value = val1;
            window.opener.document.getElementById("txt_IGST_LEVY_RATE").value = val2;
            window.opener.document.getElementById("txt_IGST_LEVY_SPL_Amt").value = val3;
            window.opener.document.getElementById("txt_IGST_LEVY_UNIT").value = val4;

            
            var COMPENSATION_CESS_NOTN = window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_NOTN").value;
            if (COMPENSATION_CESS_NOTN == '') {
            window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_NOTN").value = '001/2017';
            window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SLNO").value = '56';
            window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_RATE").value = '0.00';
            }
            
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

    </script>
    <script language="jscript" type="text/javascript">
        $(document).ready(function () {
            $('#txtRITCNo').change(function () {
                $('#hdn_status').val('Enterred');
            });
        });
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
                    IGST- Notification Excise Master
                </div>
                <div id="innerbox_MidMain_Mid_country_pop">
                    <div id="innerbox_MidMain_popup_country_master">
                        <div id="tag_label_country_pop" style="width: 60px">
                            RITC No
                        </div>
                        <div id="txtcon_mid_size_popup" style="width: 90px">
                            <asp:TextBox ID="txtRITCNo" runat="server" CssClass="txtbox_none_mid_size_popup"
                                Width="90px" MaxLength="8" class="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_item_maindet"
                                ClientIDMode="Static" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src_popup">
                        </div>
                        <div id="tag_label_country_pop" style="width: 50px">
                            Notn No
                        </div>
                        <div id="txtcon_mid_size_popup">
                            <asp:TextBox ID="txtNotnNo" runat="server" CssClass="txtbox_none_mid_size_popup"
                                TabIndex="2"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src_popup">
                        </div>
                        <div id="tag_label_currency_pop_empty">
                        </div>
                        <div id="tag_label_country_pop" style="width: 40px">
                            Sr No
                        </div>
                        <div id="txtcon_mid_size_popup">
                            <asp:TextBox ID="txtNotnSrNo" runat="server" CssClass="txtbox_none_mid_size_popup"
                                TabIndex="3"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src_popup">
                        </div>
                    </div>
                    <div id="tag_srcinner_rght2_country">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" runat="server" id="btnSearch" onserverclick="btnSearch_Click"
                                tabindex="4"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="#" class="cancelButt" onclick="window.close();" tabindex="5"></a>
                        </div>
                    </div>
                </div>
                <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 330px;
                    width: 800px;">
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="NOTIFICATION_EXCISE_ID"
                        EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                        PageSize="300" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                        Width="100%" ShowHeaderWhenEmpty="True" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="CTH_NO" HeaderText="CTH No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_NOTN" HeaderText="Notn">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_NOTN_SL" HeaderText="Notn SNo">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_BCD_RATE" HeaderText="Rate">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_CETH" HeaderText="Tariff Heading">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_BCD_SPL" HeaderText="Amount">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTIFICATION_EXCISE_BCD_UNIT" HeaderText="Unit">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LEVY_1DANDS" HeaderText="Default">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="hdn_RITC" runat="server" />
                    <asp:HiddenField ID="hdn_status" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
