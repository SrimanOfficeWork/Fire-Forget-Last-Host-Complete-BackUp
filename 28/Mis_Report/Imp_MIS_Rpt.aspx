<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="Imp_MIS_Rpt.aspx.cs" Inherits="Mis_Report_Imp_MIS_Rpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="print">
        @page
        {
            size: auto;
            margin: 0mm;
        }

        @media print
        {
            h1, h2, h3 { color: black; }
            #navigation { display: none; }
        }

        @media screen
        {
            /*****   Styles for screen  ******/
        }
    </style>

    <div id="innerbox_MidMain" style="height: 128px;">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 420px;">
                Import-MIS Reports &nbsp;&nbsp;--&nbsp;&nbsp; Report Category &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlrptype" runat="server" AutoPostBack="true" CssClass="listtxt_transac_mode_new"
                    Width="100px" TabIndex="1" OnSelectedIndexChanged="ddlrptype_SelectedIndexChanged">
                    <asp:ListItem Text="Importer"></asp:ListItem>
                    <asp:ListItem Text="BE Type"></asp:ListItem>
                    <asp:ListItem Text="Mode"></asp:ListItem>
                    <asp:ListItem Text="Port"></asp:ListItem>
                    <asp:ListItem Text="Country"></asp:ListItem>
                    <asp:ListItem Text="User"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div id="tag_transact_src_inner" style="width: 1200px;">
            <div id="tag_transaction_inner_new" style="margin-left: 20px; width: 1190px;">

                <%-- Row-1 --%>
                <div id="tag_Exchange_lft_in1_new1" style="width: 1180px;">
                    <div id="tag_label_transaction_date">
                        Importer Name
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                        <asp:TextBox ID="txtimpname" runat="server" MaxLength="100" onblur="ChangeCase(this);"
                            ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                            Onkeypress="return numcharspl1(event)" TabIndex="5"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_no_empty">
                    </div>
                    <div id="tag_label_transaction_Src">
                        Branch
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                        <asp:DropDownList ID="ddlbranch" runat="server" ClientIDMode="Static" CssClass="listtxt_transac_src1"
                            Width="190px" TabIndex="6" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_mode_empty">
                    </div>
                    <div id="tag_label_transaction_Src_new">
                        Mode
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 100px;">
                        <asp:DropDownList ID="ddltr_mode" runat="server" CssClass="listtxt_transac_mode_new"
                            Width="100px" TabIndex="4" AutoPostBack="True"
                            OnSelectedIndexChanged="ddltr_mode_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_no_empty">
                    </div>
                    <div id="tag_label_transaction_Src" style="width: 100px;">
                        CusHouse Code
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                        <asp:DropDownList ID="ddltr_cushouse" runat="server" ClientIDMode="Static" CssClass="listtxt_transac_src1"
                            Width="190px" TabIndex="6" AutoPostBack="True"
                            OnSelectedIndexChanged="ddltr_cushouse_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>

                <%-- Row-2 --%>
                <div id="tag_label_transaction_popup_IGM2_empty_gen">
                </div>

                <%-- Row-3 --%>
                <div id="tag_Exchange_lft_in1_new1">
                    <div id="tag_label_transaction_date">
                        Port
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                        <asp:TextBox ID="txtport" runat="server" MaxLength="10" ClientIDMode="Static"
                            CssClass="txtbox_none_Mid_transac_pop_gen_srcic" TabIndex="7"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_no_empty">
                    </div>
                    <div id="tag_label_transaction_Src_new">
                        BE Type
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                        <asp:DropDownList ID="txtBEtype" runat="server" AutoPostBack="true"
                            CssClass="listtxt_transac_mode_new" Width="190px" TabIndex="9">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Ex-Bond</asp:ListItem>
                            <asp:ListItem>Home</asp:ListItem>
                            <asp:ListItem>Warehouse</asp:ListItem>
                            <asp:ListItem>SEZ FTA-Z</asp:ListItem>
                            <asp:ListItem>Destruction</asp:ListItem>
                            <asp:ListItem>Movement of Goods</asp:ListItem>
                            <asp:ListItem>Stock Item</asp:ListItem>
                            <asp:ListItem>SEZ DTA-M</asp:ListItem>
                            <asp:ListItem>Jobbing</asp:ListItem>
                            <asp:ListItem>SEZ DTA-T</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_mode_empty"></div>
                    <div id="tag_label_transaction_Src_new">
                        User ID
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:DropDownList ID="ddl_UserID" runat="server" AutoPostBack="true" CssClass="listtxt_transac_mode_new"
                            Width="100px" TabIndex="9"
                            OnSelectedIndexChanged="ddl_UserID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>

                <div id="tag_label_transaction_popup_IGM2_empty_gen">
                </div>

                <%-- Row-4 --%>
                <div id="tag_Exchange_lft_in1_new1" style="width: 750px;">
                    <div id="tag_label_transaction_date">
                        Country
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic">
                        <asp:TextBox ID="txtcountry" runat="server" MaxLength="10" ClientIDMode="Static"
                            CssClass="txtbox_none_Mid_transac_pop_gen_srcic" TabIndex="8"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_no_empty"></div>
                    <div id="tag_label_transaction_Src_new">
                        From Date
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtJobDate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="2"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                            PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_Src_new" style="width: 60px;">
                        To Date
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                            PopupButtonID="txttodate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>
                </div>

                <div id="tag_label_transaction_Src_longlabel" style="padding-top: -10px;">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" onserverclick="btnSearch_Click" runat="server"
                            tabindex="10"></a>
                    </div>
                </div>
                <div id="txtcon-m_transaction_mode" style="padding-top: -10px;">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="11"></a>
                </div>

            </div>
        </div>
    </div>

    <div id="innerbox_MidMain_Grid" style="height: 580px;">
        <div id="tag_srcinner1grid">
            <div id="txtcon-m_transaction_code" style="margin-top: 08px;">
                <asp:ImageButton ID="btnprint" runat="server" ImageUrl="~/images/print.jpg" Height="28px"
                    Width="28px" OnClientClick="PrintGridData()" />
                <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                    Width="28px" OnClientClick="EXcel()" />
                <asp:ImageButton ID="btnpdf" runat="server" ImageUrl="~/images/pdf.jpg" Height="28px"
                    Width="28px" OnClientClick="Pdf()" />
            </div>
            <%--<div id="txtcon-m_transaction_code" style="margin-top: 10px; width: 350px;">
                <asp:Button ID="btnSend" CssClass="send_btn" Text="Send" runat="server" CausesValidation="false"
                    UseSubmitBehavior="false" OnClientClick="Mail_open();" />
            </div>--%>
            <div id="tag_srcinner1grid_table_Container" style="width: 1300px; height: 330px;">
                <div id="Main_Grid_Container" style="
                    width: 1300px;" runat="server">
                    <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="True"
                        Width="100%" CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true"
                        OnRowDataBound="gvdetails_RowDataBound" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" HeaderStyle-BackColor="AliceBlue"
                        HeaderStyle-Font-Size="12px" HeaderStyle-CssClass="grid-header">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            CssClass="column_style_right" BorderWidth="1px" />
                        <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    </asp:GridView>
                </div>
            </div>
        </div>

        <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
        <style type="text/css">
            .ui-autocomplete-loading
            {
                background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
            }
        </style>

        <script type="text/javascript">
            function PrintGridData() {
                var prtGrid = document.getElementById('<%=gvdetails.ClientID %>');
                var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
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

    <%-- <script type="text/javascript">
            var win = null;
            var Jobdate = $('#<%= txtJobDate.ClientID %>').val();
            var Imp_name = $('#<%= txtimpname.ClientID %>').val();
            var Tr_mode = $('#<%= ddltr_mode.ClientID %>').val();
            var Branch = $('#<%= ddlbranch.ClientID %>').val();
            var BE_type = $('#<%= txtBEtype.ClientID %>').val();
            var Report_cat = $('#<%= ddlrptype.ClientID %>').val();
            var Port = $('#<%= txtport.ClientID %>').val();
            var Todate = $('#<%= txttodate.ClientID %>').val();
            var Country = $('#<%= txtcountry.ClientID %>').val();
            var UsedID = $('#<%= ddl_UserID.ClientID %>').val();
            if (UsedID.length == 0)
                UsedID = '';
            var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
            var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
            var CustHouse = $('#<%= ddltr_cushouse.ClientID %>').val();

            if (lastProductId != 'NO RECORD FOUND') {
//                function EXcel() {
//                    var Type = 'excel';
//                    win = window.open('../FlatFile/MIS_report_1.aspx?MIS_rpt=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&BE_type=' + BE_type + '&Report_cat=' + Report_cat + '&Port=' + Port + '&Type=' + Type + '&Todate=' + Todate + ' &Country=' + Country + ' &UserID=' + UsedID + '&CustHouse=' + CustHouse + '', 'ndf');
//                    Loading_HideImage();
//                }

//                function Pdf() {
//                    var Type = 'Pdf';
//                    win = window.open('../FlatFile/MIS_report_1.aspx?MIS_rpt=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&BE_type=' + BE_type + '&Report_cat=' + Report_cat + '&Port=' + Port + '&Type=' + Type + '&Todate=' + Todate + ' &Country=' + Country + ' &UserID=' + UsedID + '&CustHouse=' + CustHouse + '', 'ndf');
//                    Loading_HideImage();
                //                }
                function EXcel() {
                    var Type = 'excel';
                    win = window.open('../FlatFile/MIS_report_1.aspx?MIS_rpt=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&BE_type=' + BE_type + '&Report_cat=' + Report_cat + '&Port=' + Port + '&Type=' + Type + '&Todate=' + Todate + '&Country=' + Country + '&UserID=' + UsedID + '&CustHouse=' + CustHouse, 'ndf');
                    Loading_HideImage();
                }

                function Pdf() {
                    var Type = 'Pdf';
                    win = window.open('../FlatFile/MIS_report_1.aspx?MIS_rpt=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&BE_type=' + BE_type + '&Report_cat=' + Report_cat + '&Port=' + Port + '&Type=' + Type + '&Todate=' + Todate + '&Country=' + Country + '&UserID=' + UsedID + '&CustHouse=' + CustHouse, 'ndf');
                    Loading_HideImage();
                }

                function Mail_open() {
                    var Type = 'excel';
                    var w = '700';
                    var h = '800';
                    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                    settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                    win = window.open('../Report/Mail_Send.aspx?IMP_MIS_Rpt_1=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&BE_type=' + BE_type + '&Report_cat=' + Report_cat + '&Port=' + Port + '&Type=' + Type + '&Todate=' + Todate + ' &Country=' + Country + ' &UserID=' + UsedID + '&CustHouse=' + CustHouse + '', 'ndf', settings);
                    win.focus();
                    return false;
                }
            }--%>

            <script type="text/javascript">
                var win = null;

                function EXcel() { openMISReport('excel'); }
                function Pdf() { openMISReport('Pdf'); }

                function openMISReport(Type) {
                    var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
                    if (lastProductId == 'NO RECORD FOUND' || lastProductId == null) {
                        return false;
                    }

                    var Jobdate = $('#<%= txtJobDate.ClientID %>').val();
                    var Imp_name = $('#<%= txtimpname.ClientID %>').val();
                    var Tr_mode = $('#<%= ddltr_mode.ClientID %>').val();
//                    var Branch = $('#<%= ddlbranch.ClientID %>').val();
                    var Branch = '<%= SELECT_BRANCH %>';
                    var BE_type = $('#<%= txtBEtype.ClientID %>').val();
                    var Report_cat = $('#<%= ddlrptype.ClientID %>').val();
                    var Port = $('#<%= txtport.ClientID %>').val();
                    var Todate = $('#<%= txttodate.ClientID %>').val();
                    var Country = $('#<%= txtcountry.ClientID %>').val();
                    var UsedID = $('#<%= ddl_UserID.ClientID %>').val() || '';
                    var CustHouse = $('#<%= ddltr_cushouse.ClientID %>').val();

                    win = window.open('../FlatFile/MIS_report_1.aspx?MIS_rpt=Yes&Jobdate=' + Jobdate +
                    '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch +
                    '&BE_type=' + BE_type + '&Report_cat=' + Report_cat + '&Port=' + Port +
                    '&Type=' + Type + '&Todate=' + Todate + '&Country=' + Country +
                    '&UserID=' + UsedID + '&CustHouse=' + CustHouse, 'ndf');
                    Loading_HideImage();
                    return false;
                }

                function Mail_open() {
                    var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
                    if (lastProductId == 'NO RECORD FOUND' || lastProductId == null) {
                        return false;
                    }

                    var Type = 'excel';
                    var Jobdate = $('#<%= txtJobDate.ClientID %>').val();
                    var Imp_name = $('#<%= txtimpname.ClientID %>').val();
                    var Tr_mode = $('#<%= ddltr_mode.ClientID %>').val();
                    var Branch = $('#<%= ddlbranch.ClientID %>').val();
                    var BE_type = $('#<%= txtBEtype.ClientID %>').val();
                    var Report_cat = $('#<%= ddlrptype.ClientID %>').val();
                    var Port = $('#<%= txtport.ClientID %>').val();
                    var Todate = $('#<%= txttodate.ClientID %>').val();
                    var Country = $('#<%= txtcountry.ClientID %>').val();
                    var UsedID = $('#<%= ddl_UserID.ClientID %>').val() || '';
                    var CustHouse = $('#<%= ddltr_cushouse.ClientID %>').val();

                    var w = 700, h = 800;
                    var LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                    var TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                    var settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition +
                       ',left=' + LeftPosition + ',scrollbars=1,resizable';

                    win = window.open('../Report/Mail_Send.aspx?IMP_MIS_Rpt_1=Yes&Jobdate=' + Jobdate +
                    '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch +
                    '&BE_type=' + BE_type + '&Report_cat=' + Report_cat + '&Port=' + Port +
                    '&Type=' + Type + '&Todate=' + Todate + '&Country=' + Country +
                    '&UserID=' + UsedID + '&CustHouse=' + CustHouse, 'ndf', settings);
                    win.focus();
                    return false;
                }
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
                var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

                if (totalRows > 2) {
                    gridviewScroll();
                } else {
                    if (lastProductId > 0) {
                        gridviewScroll();
                    }
                }
            });

            function gridviewScroll() {
                gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({
                    width: 1050,
                    height: 420,
                    railcolor: "#F0F0F0",
                    barcolor: "#CDCDCD",
                    barhovercolor: "#606060",
                    bgcolor: "#F0F0F0",
                    freezesize: 1,
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
    </div>
</asp:Content>
