<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Daily_Status_Report.aspx.cs"
    Inherits="DSR" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>
    <script src="../GridScroll_js/jquery.gridviewScroll.min.js"></script>
    <style>
        #Main_Grid_Container
        {
            visibility: hidden;
        }
        
        .grid-view
        {
            table-layout: fixed !important;
            border-collapse: collapse !important;
        }
        
        .grid-view th, .grid-view td
        {
            white-space: nowrap;
            padding: 4px;
        }
        #tag_srcinner1grid_table_Container
        {
            padding-right: 5px;
        }
    </style>
    <div id="innerbox_MidMain">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Daily Status Report
            </div>
        </div>
        <div id="tag_transact_src_inner" style="width: 805px;">
            <div id="tag_Exchange_inner_lft">
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transact_Src">
                        Client Name
                    </div>
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddlCutomerName" runat="server" CssClass="txtbox_none" Width="200px"
                            Font-Names="TimesNewRomen" OnSelectedIndexChanged="ddlCutomerName_SelectedIndexChanged"
                            AutoPostBack="True">
                            <asp:ListItem>All</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_Src_longlabel">
                        Transport Mode</div>
                    <div id="txtcon-m_transaction_mode">
                        <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="listtxt_transac_mode_new"
                            TabIndex="5">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Air</asp:ListItem>
                            <asp:ListItem>Sea</asp:ListItem>
                            <asp:ListItem>Land</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_Src_new">
                        Branch
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:DropDownList ID="ddlSelect_Branch" runat="server" CssClass="txtbox_none" ClientIDMode="Static">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transact_lft_in1" style="width: 700px;">
                    <div id="tag_label_transaction_date">
                        From Date</div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtFrom_Date" runat="server" Width="120px" CssClass="txtbox_none_Mid_transac_code"
                            MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom_Date"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFrom_Date"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_date">
                        To Date</div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtTo_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            Width="120px" MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtTo_Date"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo_Date"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <%--   <div id="tag_label_transaction_Src_new">
                                Branch
                            </div>
                            
                            <div id="tag_label_transact_Src">
                           <asp:DropDownList ID="ddlSelect_Branch" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static">      
                           </asp:DropDownList>
                            </div>--%>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" onserverclick="btnSearch_Click" runat="server"
                        onclientclick="return validate_Invoice();" tabindex="10"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                </div>
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1grid">
            <div id="txtcon-m_transaction_code" style="margin-top: 08px; width: 70px;">
                <asp:ImageButton ID="btnprint" runat="server" ImageUrl="~/images/print.jpg" Height="28px"
                    Width="28px" OnClientClick="PrintGridData()" />
                <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                    Width="28px" OnClientClick="EXcel()" />
            </div>
            <div id="txtcon-m_transaction_code" style="margin-top: 10px; width: 350px;">
                <asp:Button ID="btnSend" CssClass="send_btn" Text="Send" runat="server" OnClientClick="Mail_open();" />
            </div>
        </div>
        <div id="tag_srcinner1grid_table_Container" style="width: 99%; overflow: hidden;
            position: relative;">
            <div id="Main_Grid_Container" runat="server" style="width: 100%;">
                <asp:GridView runat="server" ID="GV_Details" EmptyDataText="NO RECORD FOUND" Width="3000px"
                    AutoGenerateColumns="false" CssClass="grid-view" ShowHeader="true" OnPageIndexChanging="GV_Details_PageIndexChanging"
                    ShowHeaderWhenEmpty="true" OnRowDataBound="GV_Details_RowDataBound1" BorderStyle="Solid"
                    BorderWidth="1px" CellPadding="0" CellSpacing="0" OnRowCreated="GV_Details_RowCreated"
                    HorizontalAlign="Left" AllowSorting="true">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="jobno" HeaderText="Job No" HeaderStyle-Width="50px">
                            <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JobDate" HeaderText="Job Date" HeaderStyle-Width="100px">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Importer" HeaderText="Importer Name" HeaderStyle-Width="350px">
                            <ItemStyle CssClass="column_style_left6" Width="350px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MAWB" HeaderText="MAWB No" HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left6" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MBL Date" HeaderText="MBL Date" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HAWB" HeaderText="HAWB No" HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left6" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HBL Date" HeaderText="HBL Date" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BENo" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BEDate" HeaderText="BEDate" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="InvoiceNo" HeaderText="InvoiceNo" HeaderStyle-Width="160px">
                            <ItemStyle CssClass="column_style_left6" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INV Date" HeaderText="INV Date" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_VALUE" HeaderText="INVOICE VALUE" HeaderStyle-Width="160px"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="column_style_left1_new" Width="140px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="INVOICE_CURRENCY" HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left6" Width="70px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_EXRATE" HeaderText="INVOICE_EXRATE" HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left6" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Product Description" HeaderText="Product Description"
                            HeaderStyle-Width="530px">
                            <ItemStyle CssClass="column_style_left6" Width="530px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left6" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Unit" HeaderText="Unit" HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left6" Width="50px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left1_new" Width="100px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CTH no" HeaderText="CTH no" HeaderStyle-Width="130px">
                            <ItemStyle CssClass="column_style_left6" Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CIF Value" HeaderText="CIF Value" HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left1_new" Width="150px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total Assasable Value" HeaderText="Total Assasable Value"
                            HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left1_new" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CVD" HeaderText="CVD" HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left1_new" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total Duty" HeaderText="Total Duty" HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left1_new" Width="150px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total SAD Duty" HeaderText="Total SAD Duty" HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left1_new" Width="150px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PL" HeaderText="PL" HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left6" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BU" HeaderText="BU" HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left6" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Debit Value" HeaderText="Debit Value" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left1_new" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Qty" HeaderText="Qty" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:HiddenField ID="HiddenField1_Jobtype" runat="server" />
        </div>
    </div>
    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=GV_Details.ClientID %>');
            var lastProductId = $("#<%=GV_Details.ClientID %> ").html;
            if (lastProductId != 'NO RECORD FOUND') {
                prtGrid.border = 1;

                var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
                prtwin.moveTo(0, 0);
                prtwin.resizeTo(screen.width, screen.height - 100);
                prtwin.document.write(prtGrid.outerHTML);
                prtwin.document.close();
                prtwin.focus();
                prtwin.print();
                prtwin.close();


            }
        }
    </script>
    <script type="text/javascript">
        var win = null;

        var Fromdate = $('#<%= txtFrom_Date.ClientID %>').val();
        var ClientName = $('#<%= ddlCutomerName.ClientID %>').val();
        var Tr_mode = $('#<%= ddlTransportMode.ClientID %>').val();
        var Branch = $('#<%= ddlSelect_Branch.ClientID %>').val();
        var Job_type = $('#<%= HiddenField1_Jobtype.ClientID %>').val();

        //      alert(Job_type);
        var To_date = $('#<%= txtTo_Date.ClientID %>').val();



        var totalRows = $("#<%=GV_Details.ClientID %> tr").length;
        var lastProductId = $("#<%=GV_Details.ClientID %> tr:last").children("td:first").html();


        if (lastProductId != 'NO RECORD FOUND') {
            function EXcel() {
                var Type = 'excel';
                win = window.open('../FlatFile/MIS_report_1.aspx?DailyStatusRpt=Yes&Fromdate=' + Fromdate + '&ClientName=' + encodeURIComponent(ClientName) + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Job_type=' + Job_type + '&To_date=' + To_date + '&Type=' + Type + '', 'ndf');
                Loading_HideImage();
            }
            function Mail_open() {
                var Type = 'excel';
                var w = '700';
                var h = '800';
                LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                //              win = window.open('../Report/Mail_Send.aspx?DSR=Yes&Fromdate=' + Fromdate + '&ClientName=' + ClientName + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Job_type=' + Job_type + '&To_date=' + To_date + '&Type=' + Type + '', 'ndf', settings);
                win = window.open('../Report/Mail_Send.aspx?DSR=Yes&Fromdate=' + Fromdate + '&ClientName=' + encodeURIComponent(ClientName) + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Job_type=' + Job_type + '&To_date=' + To_date + '&Type=' + Type + '', 'ndf', settings);
                win.focus();
                return false;
            }

        }

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var totalRows = $("#<%=GV_Details.ClientID %> tr").length;
            var lastProductId = $("#<%=GV_Details.ClientID %> tr:last").children("td:first").html();

            if (lastProductId == null) { }

            // REMOVE gridviewScroll() from both if/else branches
            if (totalRows <= 2 && !(lastProductId > 0)) {
                document.getElementById('<%=Main_Grid_Container.ClientID %>').style.height = "59px";
                // Show immediately for empty state
                document.getElementById('<%=Main_Grid_Container.ClientID %>').style.visibility = 'visible';
            }
        });
        Sys.Application.add_load(function () {
            var totalRows = $("#<%=GV_Details.ClientID %> tr").length;
            var lastProductId = $("#<%=GV_Details.ClientID %> tr:last").children("td:first").html();

            if (totalRows > 2 || lastProductId > 0) {
                setTimeout(function () {
                    gridviewScroll();
                }, 400);
            } else {
                // Empty grid — just reveal immediately, no scroll needed
                document.getElementById('<%=Main_Grid_Container.ClientID %>').style.visibility = 'visible';
            }

        });

        function gridviewScroll() {
            var containerWidth = document.getElementById('tag_srcinner1grid_table_Container').clientWidth - 20;
            gridView1 = $('#<%=GV_Details.ClientID %>').gridviewScroll({

                width: containerWidth,
                height: 420,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                railsize: 16,
                barsize: 17,
                arrowsize: 30,
                freezesize: 0,
                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",
                headerrowcount: 1,
                IsInUpdatePanel: true
            });
            document.getElementById('<%=Main_Grid_Container.ClientID %>').style.visibility = 'visible';

            $('.GridViewScrollHeader th').each(function (i) {
                var width = $('.GridViewScrollBody td:nth-child(' + (i + 1) + ')').outerWidth();
                $(this).css('width', width);
            });
        }

    </script>
</asp:Content>
