<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="PurchaseEntrySearch.aspx.cs" Inherits="Billing_Imp_PurchaseEntrySearch" %>

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
                <input type="submit" value="Submit" class="new" onclick="open_PurchaseEntry('New'); return false" />
            </div>
            <div id="verslic">
            </div>
            <div id="editbu">
                <a href="#" class="edit"></a>
            </div>
            <%--<div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                <asp:RadioButtonList ID="Rd_Job_Type" runat="server" RepeatDirection="Horizontal"
                    TabIndex="5">
                    <asp:ListItem Text="Imp" Value="Imp" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Exp" Value="Exp"></asp:ListItem>
                </asp:RadioButtonList>
            </div>--%>
            <%--<div id="verslic">
            </div>--%>
            <%--<div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                Exp-Payment Entry
            </div>--%>
            <%-- <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px; width:35px;">
                    <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Invoice Report"  ImageUrl="~/images/icons/Bill_pending.jpg" runat="server" OnClientClick="Inv_Bill();return false;"  />
                </div>--%>
             <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
                </div>
             <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;" >
                         <asp:Button ID="btnTds" runat="server" Text="TDS" ToolTip="TDS Data" Font-Size="XX-Small" OnClientClick="tds()" Height="28px" Width="35px" />
                      <%--<asp:ImageButton ID="btntally" runat="server"  ToolTip="Tally Data"  ImageUrl="~/images/icons/Tally.png"  Height="28px" Width="28px" OnClientClick="Tally()"  />--%>
                </div>
            <%--<div id="verslic">
            </div>--%>

            <div id="Div1">
                <a href="#" class="edit"></a>
            </div>


            <%--<div id="Div2" >           
                           <div id="editbu">
                                   <asp:Button ID="btnTempEntry" Text="Temp Entry" CssClass="autowidupdatebut"
                                 runat="server" UseSubmitBehavior="false" 
                                        />
                            </div>
            </div>--%>



        </div>
        <div id="tag_transact_src_inner" style="width: 1030px; height: 105px">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        <div id="txtcon-m_src" style="width: 100px;">
                           Search By
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txtsearch" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                        </div>
                        
                    <%--</div>--%>
                    <%--<div id="innerbox_transac_bot_inn" style="width: 950px;">--%>
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
                        
                    <%--</div>
                    <div id="innerbox_transac_bot_inn" style="">--%>
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
                        
                    </div>
                    <div id="innerbox_transac_bot_inn" style="width: 950px;">
                    <div id="txtcon-m_src" style="width: 100px;">
                    Month
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:DropDownList ID="ddlMonth" CssClass="txtbox_none" Width="150px" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div id="txtcon-m_src"  style="width: 100px; visibility:hidden;">
                    Classification
                    </div>
                    <div id="txtcon-m_transaction_code" CssClass="txtbox_none" style="width: 170px; visibility:hidden;">
                    <asp:DropDownList ID="ddl_Gst_type" runat="server">
                    <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_01">Imports exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_02">Imports  Nil rated</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_03">Imports taxable</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_04">interstate purchase exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_05">Interstate purchase from unregistered dealer - taxable</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_06">Interstate purchase from unregistered dealer - exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_07">Interstate purchase from unregistered dealer - Nil rated</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_08">Interstate purchase from unregistered dealer - services</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_09">Interstate purchase taxable</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_10">Interstate purchase Nil rated</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_11">Intrastate PURCHASE deemed exports - Exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_12"> Intrastate PURCHASE deemed exports - taxable</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_13">Intrastate PURCHASE deemed exports - Nil rated</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_14">PURCHASE deemed exports - exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_15">PURCHASE deemed exports - taxable</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_16">PURCHASE deemed exports - Nil rated</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_17">purchase exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_18">purchase From composition dealer</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_19">PURCHASE from Sez - exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_20">PURCHASE from Sez - LUT/BOND</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_21">PURCHASE from Sez - NIL RATED</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_22">PURCHASE from Sez - TAXABLE</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_23">PURCHASE from Sez (Without bill of entry) -exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_24">PURCHASE from Sez (Without bill of entry) -NIL RATED</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_25">PURCHASE from Sez (Without bill of entry)- TAXABLE</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_26">PURCHASE FROM UNREGISTERED DEALER -EXEMPT</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_27">PURCHASE FROM UNREGISTERED DEALER - NIL RATED</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_28">PURCHASE FROM UNREGISTERED DEALER - TAXABLE</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_29"> PURCHASE NIL RATED</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_30">PURCHASE TAXBLE </asp:ListItem>
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
               OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gvdetails_RowDataBound" DataKeyNames="VOUCHER_NO"
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
                    <%--<asp:BoundField DataField="Exp_ID" HeaderText="Exp No"  HeaderStyle-Width="90px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="90px" Font-Size="11px" />
                        </asp:BoundField>--%>

                    <asp:BoundField DataField="VOUCHER_NO" HeaderText="Voucher No" HeaderStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="280px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="280px" Font-Size="12px" />
                    </asp:BoundField>
                    <%--<asp:BoundField DataField="VOUCHER_DATE" HeaderText="Voucher Date" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="80px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" Font-Size="12px" />
                    </asp:BoundField>--%>
                    <asp:BoundField DataField="VENDOR_NAME" HeaderText="Vendor Name" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="300px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="300px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="VENDOR_BRANCH" HeaderText="Vendor Branch" DataFormatString="{0:dd/MM/yyyy}"
                        HeaderStyle-Width="130px" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="130px" Font-Size="12px" />
                    </asp:BoundField>
<%--                    <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" HeaderStyle-Width="420px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="420px" Font-Size="11px" />
                    </asp:BoundField>--%>

                    <asp:BoundField DataField="VENDOR_BILL" HeaderText="Vendor Bill" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="100px" Font-Size="11px" />
                    </asp:BoundField>

                    
                    <asp:BoundField DataField="BILL_AMOUNT" HeaderText="Bill Amount" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="100px" Font-Size="12px" />
                    </asp:BoundField>
                    <%--<asp:BoundField DataField="TotalExpAmt" HeaderText="Total Expenses" HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="90px" Font-Bold="true"
                            Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PAID_AMT" HeaderText="Paid Amt" HeaderStyle-Width="80px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="80px" Font-Bold="true"
                            Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DUE_AMT" HeaderText="Due Amt" HeaderStyle-Width="80px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="80px" Font-Bold="true"
                            Font-Size="11px" />
                    </asp:BoundField>--%>

                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="hdBill_invno" runat="server" />
    <%--  <asp:HiddenField ID="HDBranch" runat="server" />--%>
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


        var txtsearch = $('#<%= txtsearch.ClientID %>').val();


        var Fromdate = $('#<%= txtFdate.ClientID %>').val();
        var Todate = $('#<%= txtTodate.ClientID %>').val();
        var Month = $('#<%= ddlMonth.ClientID %>').val();
        var gsttype = $('#<%= ddl_Gst_type.ClientID %>').val();

        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND') {
            function EXcel() {
                var Type = 'excel';
                win = window.open('../FlatFile/MIS_report_1.aspx?GST_Purchase_Data=Yes&&txtsearch=' + txtsearch + '&&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '', 'ndf');

                Loading_HideImage();
            }

            function tds() {
                var Type = 'excel';
                win = window.open('../FlatFile/MIS_report_1.aspx?GST_Purchase_Tds_Data=Yes&&txtsearch=' + txtsearch + '&&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '&&gsttype='+gsttype+'', 'ndf');
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
