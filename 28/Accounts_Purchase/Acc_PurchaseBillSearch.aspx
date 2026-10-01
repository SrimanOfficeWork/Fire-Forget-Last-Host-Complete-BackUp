<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="Acc_PurchaseBillSearch.aspx.cs" Inherits="Acc_PurchaseBillSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .txtbox_none_Mid_transac_Inv_No
        {
            color: #2C2C2C;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 11px;
            height: 17px;
            margin-top: 1px;
            width: 150px;
            text-transform: uppercase;
            border: #c8c8c8 solid thin;
            border-radius: 2px;
        }
        .ad
        {
            width: 50px;
        }
        
        th a
        {
            text-decoration: none;
        }
        .padding
        {
            padding-left: 10px;
            padding-top: 3px;
        }
        
        td
        {
            cursor: pointer;
        }
        .selected_row
        {
            background-color: white;
            font-weight: bold;
            color: #3C3535;
        }
        #tag_transact_src_inner
        {
            width: 780px;
            height: auto;
        }
        #tag_transact_src_inner #innerbox_transac_bot_inn
        {
            width: 760px;
            margin-bottom: 1px;
            line-height: 16px;
        }
        #tag_transact_src_inner #innerbox_transac_bot_inn > div:nth-child(1)
        {
            width: 85px !important;
            margin-left: 0 !important;
        }
        #tag_transact_src_inner #innerbox_transac_bot_inn > div:nth-child(2)
        {
            width: 210px !important;
        }
        #tag_transact_src_inner #innerbox_transac_bot_inn > div:nth-child(3)
        {
            width: 100px !important;
            margin-left: 90px !important;
        }
        #tag_transact_src_inner #innerbox_transac_bot_inn > div:nth-child(4)
        {
            width: 210px !important;
        }
        #tag_transact_src_inner .txtbox_none_Mid_transac_Inv_No
        {
            width: 239px !important;
            height: 19px !important;
            line-height: 22px;
            margin-top: 0px !important;
            box-sizing: border-box;
        }
        #tag_transact_src_inner select.txtbox_none_Mid_transac_Inv_No
        {
            width: 239px !important;
            height: 19px !important;
            line-height: 22px;
            padding: 0 2px;
            box-sizing: border-box;
            background-color: white;
        }
        #tag_transact_srcinner_rght
        {
            width: 100px !important;
            margin-left: -60px !important;
        }
        #tag_transact_src_inner #innerbox_transac_bot_inn, #tag_transact_src_inner #tag_label_transact_Src, #tag_transact_src_inner #txtcon-m_transaction_code
        {
            height: 23px !important;
        }
        #tag_transact_srcinner_rght
        {
            width: 100px !important;
            margin-left: -100px !important;
        }
        td.column_style_left51 {
          line-height: 1.5em;
          border-left: #c8c8c8 solid thin;          
          padding-left: 6px;
          padding-right: 6px;
        }
        
    </style>
    <div id="innerbox_MidMain" style="height: 185px;">
        <div id="tag_srcinner1">
            <div id="newbu">
                <input type="submit" value="Submit" class="new" onclick="open_PurchaseEntry_New('New'); return false" />
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                Purchase Entry
            </div>
            <div id="editbu" style="padding-top: 3px;">
                <asp:ImageButton ID="btntally" runat="server" ToolTip="Tally Data" ImageUrl="~/images/icons/Tally.png"
                    Height="28px" Width="28px" OnClientClick="Purchase_Tally()" Visible="false" />
            </div>
        </div>
        <div id="tag_transact_src_inner" style="width: 1000px; height: 249px">
            <div id="tag_Exchange_inner_lft">
                <div id="innerbox_transac_bot_inn" style="width: 950px;">
                    <div id="tag_label_transact_Src" style="width: 120px;">
                        Organisation
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txt_Organisation" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                    </div>
                    <div id="tag_label_transact_Src" style="width: 100px; margin-left: 49px;">
                        Vou. From Date
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txtFdate" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFdate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFdate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn" style="width: 950px;">
                    <div id="tag_label_transact_Src" style="width: 120px;">
                        Trans No
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txt_TransNo" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                    </div>
                    <div id="tag_label_transact_Src" style="width: 100px; margin-left: 49px;">
                        Vou. To Date
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txtTodate" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTodate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn" style="width: 950px;">
                    <div id="tag_label_transact_Src" style="width: 120px;">
                        Location
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:DropDownList ID="ddl_Location" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            <asp:ListItem Text="CHENNAI" Value="CHENNAI"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transact_Src" style="width: 100px; margin-left: 49px;">
                        Vendor Inv.No
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txt_Ven_Inv_No" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn" style="width: 950px;">
                    <div id="tag_label_transact_Src" style="width: 120px;">
                        Narration
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txt_Narration" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                    </div>
                    <div id="tag_label_transact_Src" style="width: 100px; margin-left: 49px;">
                        Status
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:DropDownList ID="ddl_Status" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            <asp:ListItem Text="Reverse" Value="Reverse"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn" style="width: 950px;">
                    <div id="tag_label_transact_Src" style="width: 120px;">
                        Dispute Status
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:DropDownList ID="ddl_disputeStatus" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            <asp:ListItem Text="Disputed" Value="Disputed"></asp:ListItem>
                            <asp:ListItem Text="Resolved" Value="Resolved"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transact_Src" style="width: 120px;">
                        Month
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:DropDownList ID="ddlMonth" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
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
    <div id="innerbox_MidMain_Grid" style="height: 500px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
            <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="false" EmptyDataText="NO RECORD FOUND"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                DataKeyNames="PC_ID" OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gvdetails_RowDataBound"
                CellPadding="0" CellSpacing="0">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="column_style_left" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="30px" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="24px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PC_No" HeaderText="Trans. No" HeaderStyle-Width="100px"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle Width="80px" HorizontalAlign="Left" Font-Size="11px" CssClass="column_style_left5" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PC_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date"
                        HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle Width="60px" HorizontalAlign="Center" Font-Size="11px" CssClass="column_style_left51" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PC_ORGANISATION" HeaderText="Organisation" HeaderStyle-Width="210px"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle Width="190px" HorizontalAlign="Left" Font-Size="11px" CssClass="column_style_left5" />
                    </asp:BoundField>
                    <asp:BoundField DataField="VENDOR_INVOICE_NO" HeaderText="Vendor Inv. No" HeaderStyle-Width="100px"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle Width="90px" HorizontalAlign="Left" Font-Size="11px" CssClass="column_style_left5" />
                    </asp:BoundField>
                    <asp:BoundField DataField="VENDOR_INVOICE_DATE" HeaderText="Vend Inv.Date" DataFormatString="{0:dd/MM/yyyy}"
                        HeaderStyle-Width="130px" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle Width="110px" HorizontalAlign="Center" Font-Size="11px" CssClass="column_style_left51" />
                    </asp:BoundField>                                       
                    <asp:BoundField DataField="NET_PAYABLE" HeaderText="Amount" DataFormatString="{0:N2}"
                        HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle Width="80px" HorizontalAlign="Right" Font-Size="11px" CssClass="column_style_left51" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NARRATION" HeaderText="Narration" HeaderStyle-Width="200px"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle Width="170px" Font-Size="11px" CssClass="column_style_left5" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#txt_Ven_Inv_No").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../Accounts_Auto_Search/Accounts_Auto_Search.asmx/ACC_GST_Billing_Purchase_Search",
                        data: "{ 'mail': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {

                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txt_Ven_Inv_No').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_Ven_Inv_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
    </script>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="hdBill_invno" runat="server" />
    <asp:HiddenField ID="HDBranch" runat="server" />
    <script language="javascript">
        function Inv_Bill() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            var Bill_Invo = document.getElementById("<%=hdBill_invno.ClientID %>").value;
            var Tax_Mode = 'B';

            if (jobno != '') {
                NewWindow1('../Billing_Imp_Rpt/ExpPaymentReport.aspx?Jobno=' + encodeURIComponent(jobno) + '&Bill_Invo=' + Bill_Invo + '&Tax_Mode=' + Tax_Mode + '', 'List', '870', '1024', 'yes');
            }
            else {
                jAlert('Select a Grid Job', 'Expenses', function (r) { document.getElementById("ddljobno").focus(); });
            }

        }
    </script>
    <script type="text/javascript">
        var win = null;

        var Fromdate = $('#<%= txtFdate.ClientID %>').val();
        var Todate = $('#<%= txtTodate.ClientID %>').val();
        var Month = $('#<%= ddlMonth.ClientID %>').val();

        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND') {
            function EXcel() {
                var Type = 'excel';
                // win = window.open('../FlatFile/MIS_report_1.aspx?GST_Purchase_Data=Yes&&txtsearch=' + txtsearch + '&&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '', 'ndf');

                Loading_HideImage();
            }

            function tds() {
                var Type = 'excel';
                // win = window.open('../FlatFile/MIS_report_1.aspx?GST_Purchase_Tds_Data=Yes&&txtsearch=' + txtsearch + '&&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '&&gsttype='+gsttype+'', 'ndf');
                Loading_HideImage();
            }
        }

    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
            var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

            if (totalRows > 2) {
                gridviewScroll();
            }
            else {

                if (lastProductId > 0) {
                    gridviewScroll();
                }
                else {
                    document.getElementById('<%=Main_Grid_Container.ClientID %>').style.overflow = "Auto";
                    document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "100%";
                    document.getElementById('<%=gvdetails.ClientID %>').style.width = "100%";
                }
            }

        });

        function gridviewScroll() {
            gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

                width: "99.9%",
                height: 520,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 0,
                arrowsize: 30,
                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",
                headerrowcount: 1,
                railsize: 16,
                barsize: 15,
                IsInUpdatePanel: true
            });
        }
    </script>
    <script type="text/javascript">
        var win = null;


        var txtVenBillno = $('#<%= txt_Ven_Inv_No.ClientID %>').val();
        var Vendor_name = $('#<%= txt_Ven_Inv_No.ClientID %>').val();
        var Fromdate = $('#<%= txtFdate.ClientID %>').val();
        var Todate = $('#<%= txtTodate.ClientID %>').val();
        var Month = $('#<%= ddlMonth.ClientID %>').val();
        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND') {

            function Purchase_Tally() {

                win = window.open('../Accounts_Data_Link/Ac_Data_Rpt_Link.aspx?Accounts_purchase_Tally_Data=Yes&VenBillno=' + txtVenBillno + '&Vendor_name=' + Vendor_name + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '', 'ndf');
                Loading_HideImage();
            }
        }

    </script>
      <script type="text/javascript">
          $(function () {
              $("#txt_Organisation").autocomplete({
                  source: function (request, response) {

                      $.ajax({
                          url: "../Accounts_Auto_Search/Accounts_Auto_Search.asmx/Purchase_Org_Name",
                          data: "{'mail':'" + request.term + "'}",                          
                          
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {

                              response(data.d);
                              if (data.d == '') {
                                  jQuery('#txtsearch').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                              }
                              else {
                                  jQuery('#txtsearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                              }
                          },
                          error: function (XMLHttpRequest, textStatus, errorThrown) {                              
                          }
                      });
                  },
                  minLength: 1

              });
              return false;
              scroll: true;
          });
    </script>
</asp:Content>
