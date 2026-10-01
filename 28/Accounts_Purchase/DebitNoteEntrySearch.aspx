<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="DebitNoteEntrySearch.aspx.cs" Inherits="DebitNoteEntrySearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>
    <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .padding
        {
            padding-left: 10px;
            padding-top: 3px;
        }
    </style>
    <style type="text/css">
        td
        {
            cursor: pointer;
        }
        .selected_row
        {
            background-color: white;
            font-weight: bold; /*color:#5E4C4C;*/
            color: #3C3535;
        }
    </style>
    
    <div id="innerbox_MidMain" style="height: 105px;">
        <div id="tag_srcinner1">
            <div id="newbu">
                <input type="submit" value="Submit" class="new" onclick="open_DebitNote_N('New'); return false" />
            </div>
            <div id="verslic"></div>
             <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                DebitNote Entry
            </div>
        </div>
        <div id="tag_transact_src_inner" style="width: 1030px; height: 105px">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        <div id="txtcon-m_src" style="width: 100px;">
                           DebitNote No
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txt_Debit_No" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                        </div>

                         <div id="txtcon-m_src" style="width: 100px;">
                          Vendor Name
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 425px;">
                          <asp:DropDownList ID="ddlCus_name" runat="server" CssClass="txtbox_none"  Font-Size="12px" Width="420px"  >
                          </asp:DropDownList>
                        </div>
                        
                        
                        
                    </div>
                    <div id="innerbox_transac_bot_inn" style="width: 950px;">
                    <div id="txtcon-m_src" style="width: 100px;">
                           From Date
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txtFdate" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                        </div>
                   
                        <div id="txtcon-m_src" style="width: 100px;">
                           To Date
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txtTodate" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                        </div>
                    <div id="txtcon-m_src" style="width: 100px;">
                    Month
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:DropDownList ID="ddlMonth" CssClass="txtbox_none" Width="150px" runat="server">
                        </asp:DropDownList>
                    </div>
                    </div>
                    
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="5"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                </div>
            </div>
        </div>
    </div>
    
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
               OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gvdetails_RowDataBound" DataKeyNames="D_ID"
                CellPadding="1" CellSpacing="1" >
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_left" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                        <ItemTemplate>
                            <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="45px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="DEBITNOTE_NO" HeaderText="Debitnote No" HeaderStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px" Font-Size="12px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="DEBITNOTE_DATE" HeaderText="Debitnote Date"  HeaderStyle-Width="90px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="90px" Font-Size="12px" />
                    </asp:BoundField>
                   
                    <asp:BoundField DataField="VENDOR_NAME" HeaderText="Vendor Name" HeaderStyle-Width="250px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="250px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AMT_IN_INR" HeaderText="Bill Amount" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="100px" Font-Size="12px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

<%--<script type="text/javascript">
    $(function () {
        $("#txt_Vou_No").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Voucher_No_Search",
                    data: "{ 'mail': '" + request.term + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            jQuery('#txt_Vou_No').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                        }
                        else {
                            jQuery('#txt_Vou_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
 </script>--%>


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
                freezesize: 2,
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
</asp:Content>
