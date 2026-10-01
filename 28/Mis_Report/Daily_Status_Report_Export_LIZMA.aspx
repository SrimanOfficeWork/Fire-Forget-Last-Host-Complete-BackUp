<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Daily_Status_Report_Export_LIZMA.aspx.cs"
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
    <style>
        #Main_Grid_Container
        {
            visibility: hidden;
            width: 100%;
        }
        
        #tag_srcinner1grid_table_Container
        {
            width: 100%;
            overflow: hidden;
            position: relative;
        }
        
        .grid-view
        {
            table-layout: fixed !important;
            border-collapse: collapse !important;
        }
        
        .grid-view th, .grid-view td
        {
            white-space: nowrap !important;
            overflow: hidden;
            text-overflow: ellipsis;
            padding: 4px;
            border: 1px solid #C8C8C8;
            box-sizing: border-box;
        }
        
        .GridViewScrollHeader th
        {
            background: #f3f3f3;
            font-weight: bold;
            text-align: left;
        }
        
        .GridViewScrollHeader, .GridViewScrollBody
        {
            overflow: hidden !important;
        }
        
        .GridViewScrollBody
        {
            overflow-y: auto !important;
            overflow-x: auto !important;
        }
        
        /* LOADER */
        
        .loader-bg
        {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: #000;
            opacity: 0.4;
            z-index: 9998;
        }
        
        .loader-content
        {
            position: fixed;
            top: 50%;
            left: 50%;
            width: 200px;
            height: 100px;
            margin-left: -100px;
            margin-top: -50px;
            background: #fff;
            border-radius: 5px;
            text-align: center;
            padding-top: 15px;
            z-index: 9999;
            font-family: Arial;
            font-size: 14px;
            font-weight: bold;
        }
        
        .loader-content img
        {
            width: 40px;
            height: 40px;
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
                            <asp:ListItem>   </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_Src_longlabel">
                        Transport Mode</div>
                    <div id="txtcon-m_transaction_mode">
                        <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="listtxt_transac_mode_new"
                            TabIndex="5">
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
                <div id="small-butt-left" style="margin-top: 6px;">
                    <%--  <a href="javascript:void(0);" class="srcbu" id="btnSearch" onserverclick="btnSearch_Click" runat="server"
                      onclientclick="return StartLoader();"
                         tabindex="10"></a>--%>
                    <asp:Button ID="btnSearch" runat="server" CssClass="srcbu" Text="Search" style="padding-right: 15px; padding-left: 15px;" OnClick="btnSearch_Click"
                        OnClientClick="return ShowLoader();" />
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
            <%--<div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" 
                      OnClientClick="Mail_open();" Width="46px"  />
               </div>  --%>
        </div>
        <div id="tag_srcinner1grid_table_Container" style="width: 99%; overflow: hidden;
            position: relative;">
            <div id="Main_Grid_Container" runat="server" style="width: 100%;">
                <asp:GridView runat="server" ID="GV_Details" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" OnPageIndexChanging="GV_Details_PageIndexChanging"
                    ShowHeaderWhenEmpty="true" Width="100%" OnRowDataBound="GV_Details_RowDataBound1"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="0" CellSpacing="0" OnRowCreated="GV_Details_RowCreated"
                    HorizontalAlign="Left" AllowSorting="true">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="SL NO" HeaderStyle-Width="20px">
                            <ItemStyle Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JOBNO" HeaderText="JobNo" HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left6" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JOBDATE" HeaderText="JobDate" HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left6" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="FileRefNo" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EXPORTER_NAME" HeaderText="ExporterName" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATE_OF_EXPORT" HeaderText="State Export" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONSIGNEE_NAME" HeaderText="ConsigneeName" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BUYER_NAME" HeaderText="BuyerName" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUSTOMS_HOUSE" HeaderText="CustomHouse" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PORT_DISCHARGE" HeaderText="Port Discharge" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="COUNTRY_DISCHARGE" HeaderText="Country Discharge" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PORT_FINAL_DEST" HeaderText="Port Destination" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="COUNTRY_FINAL_DEST" HeaderText="Country Destination" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TOTAL_PKGS" HeaderText="Total PKGS" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <%-- <asp:BoundField DataField="PORT_DISCHARGE" HeaderText="Port Discharge" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="GROSS_WEIGHT" HeaderText="Gross WGT" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NET_WEIGHT" HeaderText="Net WGT" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CTN" HeaderText="CTN" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ORDER_NO" HeaderText="ORDER No" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STYLE_NO" HeaderText="STYLE_No" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_NO" HeaderText="Invoice No" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_DATE" HeaderText="Invoice Date" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SB_NO" HeaderText="SB NO" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SB_DATE" HeaderText="SB Date" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SB_EXPIRY" HeaderText="SB Expiry" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NATURE_OF_CONTRACT" HeaderText="Nature of Contract" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_CURR" HeaderText="Inv Curr" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EX_RATE" HeaderText="ExRate" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_VALUE" HeaderText="Invoice value" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RITCNO" HeaderText="RITCNo" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Item Description" HeaderStyle-Width="600px">
                            <ItemStyle CssClass="column_style_left6" Width="600px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FOB_VALUE" HeaderText="FOB Value" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DRAWBACK_SLNO" HeaderText="DRAWBACK SlNo" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DRAWBACK_RATE" HeaderText="DRAWBACK Rate" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DRAWBACK_VALUE" HeaderText="DRAWBACK_VALUE" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STR_RATE" HeaderText="STR_Rate" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STR_AMOUNT" HeaderText="STR_Amount" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DOC_RECEIVED" HeaderText="DOC_Received" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REVISION_RECD_ON" HeaderText="Revised Recd On" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DC_SAMPLE" HeaderText="DC_Sample" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SAMPLE" HeaderText="Sample" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STUFFED_ON" HeaderText="Stuffed On" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONTAINER_NO" HeaderText="Container No" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LINER" HeaderText="Liner" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="E_SEAL" HeaderText="E_Seal" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STUFFING_REPORT_GIVEN_ON" HeaderText="Stuffing Report Given On"
                            HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EP_COPY_GIVEN_ON" HeaderText="EP Copy Given On" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REMARKS" HeaderText="Remarks" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left6" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:HiddenField ID="HiddenField1_Jobtype" runat="server" />
        </div>
    </div>
    <!-- LOADER -->
    <div id="loaderDiv" style="display: none;">
        <div class="loader-bg">
        </div>
        <div class="loader-content">
            <%--<img src="../images/loading.gif" alt="Loading" />--%>
            <img src="../images/Loading_img2.gif" alt="Loading.." />
            <br />
            <%--            <span>Please wait...</span>--%>
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
                win = window.open('../FlatFile/MIS_report_1.aspx?DailyStatusRpt_Export_LIZMA=Yes&Fromdate=' + Fromdate + '&ClientName=' + encodeURIComponent(ClientName) + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Job_type=' + Job_type + '&To_date=' + To_date + '&Type=' + Type + '', 'ndf');
                Loading_HideImage();
            }
            function Mail_open() {
                var Type = 'excel';
                var w = '700';
                var h = '800';
                LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                win = window.open('../Report/Mail_Send.aspx?DSR=Yes&Fromdate=' + Fromdate + '&ClientName=' + encodeURIComponent(ClientName) + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Job_type=' + Job_type + '&To_date=' + To_date + '&Type=' + Type + '', 'ndf', settings);
                win.focus();
                return false;
            }

        }

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

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
                // Empty grid &#8212; just reveal immediately, no scroll needed
                document.getElementById('<%=Main_Grid_Container.ClientID %>').style.visibility = 'visible';
            }

        });

        function gridviewScroll() {

            var containerWidth =
        $('#tag_srcinner1grid_table_Container').width();

            $('#<%=GV_Details.ClientID %>').gridviewScroll({
                width: containerWidth,
                height: 420,
                freezesize: 0,
                headerrowcount: 1,

                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",

                railsize: 16,
                barsize: 16,
                arrowsize: 16,

                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",

                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",

                IsInUpdatePanel: true
            });

            $('#<%=Main_Grid_Container.ClientID %>')
        .css('visibility', 'visible');
        }

        function StartLoader() {
            if (validate_Invoice()) {
                document.getElementById('loaderDiv').style.display = 'block';
                // Force browser render
                setTimeout(function () {
                    __doPostBack('<%= btnSearch.UniqueID %>', '');

                }, 100);
            }
            return false;
        }

        function HideLoader() {
            document.getElementById('loaderDiv').style.display = 'none';
        }
        window.onload = function () {
            HideLoader();
        };

    </script>
</asp:Content>
