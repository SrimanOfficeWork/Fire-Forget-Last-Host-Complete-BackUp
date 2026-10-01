<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="ExpensesPaymentEntrySearch.aspx.cs" Inherits="ExpensesPaymentEntrySearch" %>

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
    <script language="javascript" type="text/javascript">

        document.body.style.cursor = 'pointer';
        var oldColor = '';
        var jobno;

        function ChangeRowColor(rowID, Value, Bill_invno) {
            document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
            document.getElementById("<%=hdBill_invno.ClientID %>").value = Bill_invno;
        }

    </script>
    <script type="text/javascript">
        function MutExChkList(chk) {
            if (chk.checked == true) {
                document.getElementById("<%=ddltype.ClientID %>").disabled = false;
                document.getElementById("<%=txtsearch.ClientID %>").disabled = false;
            }
            else {
                document.getElementById("<%=ddltype.ClientID %>").disabled = true;
                document.getElementById("<%=txtsearch.ClientID %>").disabled = true;
                document.getElementById("<%=txtsearch.ClientID %>").value = '';
                document.getElementById("<%=ddltype.ClientID %>").value = '0';

            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id*=gvdetails] td").bind("click", function () {
                var row = $(this).parent();
                $("[id*=gvdetails] tr").each(function () {
                    if ($(this)[0] != row[0]) {
                        $("td", this).removeClass("selected_row");
                    }
                });
                $("td", row).each(function () {
                    if (!$(this).hasClass("selected_row")) {
                        $(this).addClass("selected_row");
                    } else {
                        $(this).removeClass("selected_row");
                    }
                });
            });
        });
    </script>
    <%--<script type="text/javascript">
    $(function () {
        $("#txtsearch").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Billing_IMPORTER_MASTER_SEARCH",
                    data: "{ 'mail': '" + request.term + "','Branch': '" + '' + "' ,'Aflags': '" + document.getElementById("<%=ddltype.ClientID %>").value + "','Chk': '" + document.getElementById("<%=chkqs.ClientID %>").checked + "' }",
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
 </script>--%>
    <div id="innerbox_MidMain" style="height: 105px;">
        <div id="tag_srcinner1">
            <div id="newbu">
                <input type="submit" value="Submit" class="new" onclick="open_ExpensesPaymentEntrySearch('New'); return false" />
            </div>
            <div id="verslic">
            </div>
            <div id="editbu">
                <a href="#" class="edit"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                <asp:RadioButtonList ID="Rd_Job_Type" runat="server" RepeatDirection="Horizontal"
                    TabIndex="5">
                    <asp:ListItem Text="Imp" Value="Imp" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Exp" Value="Exp"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                Exp-Payment Entry
            </div>
            <%-- <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px; width:35px;">
                    <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Invoice Report"  ImageUrl="~/images/icons/Bill_pending.jpg" runat="server" OnClientClick="Inv_Bill();return false;"  />
                </div>--%>
            <%-- <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;display:none;">
                      <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
                </div>--%>
            <%-- <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btntally" runat="server"  ToolTip="Tally Data"  ImageUrl="~/images/icons/Tally.png"  Height="28px" Width="28px" OnClientClick="Tally()"  />
                </div>--%>
            <div id="verslic">
            </div>

            <div id="Div1">
                <a href="#" class="edit"></a>
            </div>


            <div id="Div2" >           
                           <div id="editbu">
                                   <asp:Button ID="btnTempEntry" Text="Temp Entry" CssClass="autowidupdatebut"
                                 runat="server" UseSubmitBehavior="false" 
                                       OnClientClick="open_TempEntrySearch('New'); return false" 
                                       onclick="btnTempEntry_Click"  Visible="false" />
                            </div>
            </div>



        </div>
        <div id="tag_transact_src_inner" style="width: 1030px; height: 105px">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        <div id="txtcon-m_src" style="width: 100px;">
                            <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                AutoPostBack="true" Width="95px" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="File Ref No" Value="FRN"></asp:ListItem>
                                <asp:ListItem Text="Job No" Value="JobNo"></asp:ListItem>
                                <asp:ListItem Text="Exp No" Value="ExpNo"></asp:ListItem>
                                <asp:ListItem Text="Exp VoucherNo" Value="ExpVoucherNo"></asp:ListItem>
                                <asp:ListItem Text="Customer Name" Value="CustomerName"></asp:ListItem>
                                <asp:ListItem Text="Date Wise" Value="Datewise"></asp:ListItem>
                                <asp:ListItem Text="Month Wise" Value="Monthwise"></asp:ListItem>
                                <asp:ListItem Text="Select Customer" Value="SelectCustomer"></asp:ListItem>
                                <asp:ListItem Text="Select Job" Value="SelectJob"></asp:ListItem>
                                <asp:ListItem Text="All Expenses" Value="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txtsearch" runat="server" ClientIDMode="Static" Visible="false"
                                CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                        </div>
                        <div id="tag_label_transact_Src" style="width: 100px;">
                            <asp:Label ID="lblsearch" runat="server"></asp:Label>
                        </div>
                        <div id="txtcon-m_src" style="width: 280px;">
                            <asp:DropDownList ID="ddlSearchValue" runat="server" CssClass="txtbox_none" Visible="false"
                                Font-Size="12px" Width="275px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transact_lft_in1" style="width: 885px;">
                        <div id="DivDatewise" runat="server" visible="false">
                            <div id="tag_label_transact_Src" style="width: 65px;">
                                From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="3"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 62px;">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="4"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                        onserverclick="btnSearch_Click" tabindex="5"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                </div>
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain" style="height: 28px; margin-top: -13px; display: none;">
        <div id="tag_srcinner1grid" style="height: 28px;">
            <div id="mainmastop2container_rght_tag2_txt1" style="margin-top: 08px; width: 100px;">
                <asp:Literal ID="ltl" Text="Inv Count:" runat="server"></asp:Literal>
                <span style="color: Red;">
                    <asp:Literal ID="lbljobcnt" runat="server"></asp:Literal>
                </span>
            </div>
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="margin-top: 08px; width: 150px;">
                <asp:Literal ID="ltl1" Text="Pending Count:" runat="server"></asp:Literal>
                <span style="color: Red;">
                    <asp:Literal ID="lblpending_cnt" runat="server"></asp:Literal>
                </span>
            </div>
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="margin-top: 08px; width: 170px;">
                <asp:Literal ID="ltl2" Text="Completed  Count:" runat="server"></asp:Literal>
                <span style="color: Red;">
                    <asp:Literal ID="lblCompleted_cnt" runat="server"></asp:Literal>
                </span>
            </div>
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="margin-top: 08px; width: 170px;">
                <asp:Literal ID="ltl3" Text="Cancelled Count:" runat="server"></asp:Literal>
                <span style="color: Red;">
                    <asp:Literal ID="lblCancelled_cnt" runat="server"></asp:Literal>
                </span>
            </div>
            <div id="verslic">
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                DataKeyNames="Exp_ID,Exp_VoucherNo,Job_ID,Job_no" OnRowDataBound="gvdetails_RowDataBound"
                CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
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

                    <asp:BoundField DataField="FILE_REF_NO" HeaderText="File Ref No" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="80px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" Font-Size="12px" />
                    </asp:BoundField>





                    <asp:BoundField DataField="Job_no" HeaderText="Job No" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="80px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Exp_VoucherNo" HeaderText="Exp.Voucher No" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="110px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Exp_Date" HeaderText="Expenses Date" DataFormatString="{0:dd/MM/yyyy}"
                        HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="90px" Font-Size="12px" />
                    </asp:BoundField>
<%--                    <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" HeaderStyle-Width="420px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="420px" Font-Size="11px" />
                    </asp:BoundField>--%>

                    <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" HeaderStyle-Width="250px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="250px" Font-Size="11px" />
                    </asp:BoundField>

                    
                    <asp:BoundField DataField="Imp_Exp" HeaderText="Imp / Exp" HeaderStyle-Width="60px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="60px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TotalExpAmt" HeaderText="Total Expenses" HeaderStyle-Width="90px">
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
                    </asp:BoundField>

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
    <%--<script type="text/javascript">
        var win = null;

        var ddlSearch_Cat = $('#<%= ddltype.ClientID %>').val();
        var txtsearch = $('#<%= txtsearch.ClientID %>').val();

        var Imp_name = $('#<%= ddlImp_name.ClientID %>').val();
        var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
        var Todate = $('#<%= txttodate.ClientID %>').val();
        var Month = $('#<%= ddlmonth.ClientID %>').val();

        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND') {
            function EXcel() {
                var Type = 'excel';
                Loading_HideImage();
            }

            function Tally() {
                var Type = 'Tally';
                win = window.open('../FlatFile/MIS_report_1.aspx?GST_IMP_Tally_Data=Yes&ddlSearch_Cat=' + ddlSearch_Cat + '&txtsearch=' + txtsearch + '&Imp_name=' + Imp_name + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '', 'ndf');
                Loading_HideImage();
            }
        }

    </script>--%>
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
