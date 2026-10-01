<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="OutstandingStatmentRpt.aspx.cs" Inherits="OutstandingStatmentRpt"
    EnableEventValidation="false" %>

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

        function ChangeRowColor(rowID, Value, Receiptno) {
            document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
            document.getElementById("<%=hdBill_invno.ClientID %>").value = Receiptno;
        }

    </script>
    <script type="text/javascript">
 function validate_RepPg() {

    //var ddltype = document.getElementById("ddltype").value;
    alert('hjh');
//    if (ddltype == "--Select--") {
//        jAlert('Select Customer', 'Report', function (r) {
//            document.getElementById("ddltype").focus();
//        });
//        return false;
//    }

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
    <div id="innerbox_MidMain" style="height: 100px;">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 170px; margin-top:3px;" >
                <asp:RadioButtonList ID="Rd_Job_Type" runat="server" RepeatDirection="Horizontal"
                    TabIndex="5"  AutoPostBack="true" OnSelectedIndexChanged="Rd_Job_Type_SelectedIndexChanged" >
                    <asp:ListItem Text="Imp" Value="Imp" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Exp" Value="Exp"></asp:ListItem>
                     <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 300px; margin-top:3px;">
                <asp:RadioButtonList ID="Rd_reportformat" runat="server" RepeatDirection="Horizontal"  
                    TabIndex="5">
                    <asp:ListItem Text="Summary" Value="Summary" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Detail" Value="Detail"></asp:ListItem>
                    <asp:ListItem Text="Cumulative" Value="Cumulative"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px;">
                <a href="#" id="btnex" runat="server" style="display: block; width: 50px; height: 30px; margin-top:-6px;
                    background-image: url('../images/xls.jpg'); background-repeat: no-repeat;" onserverclick="btnexcel_Click"
                    tabindex="7"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px;">
                <a href="#" id="btnRdlc" runat="server" style="display: block; width: 50px; height: 30px; margin-top: -6px;
                    background-image: url('../images/pdf.jpg'); background-repeat: no-repeat;" onserverclick="btnRdlc_Click"
                    tabindex="7"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                Outstanding Report
            </div>
        </div>
        <%-- --------------------------------------------Start---------------------------%>
        <div id="tag_transact_src_inner" style="width: 1030px;">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            Report Type:
                        </div>
                        <div id="txtcon-m_src" style="width: 100px;">
                            <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                AutoPostBack="true" Width="95px" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                <asp:ListItem Text="Customer Wise" Value="CustomerWise"></asp:ListItem>
                                <asp:ListItem Text="Job Wise" Value="JobWise"></asp:ListItem>
                                <asp:ListItem Text="Bill/Invoice" Value="BillInvWise"></asp:ListItem>
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txtsearch" runat="server" ClientIDMode="Static" Visible="false"
                                CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                        </div>
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            <asp:Label ID="lblsearch" runat="server"></asp:Label>
                        </div>
                        <div id="txtcon-m_src" style="width: 280px;">
                            <asp:DropDownList ID="ddlSearchValue" runat="server" CssClass="txtbox_none" Visible="false"
                                Font-Size="12px" Width="275px">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="validate_RepPg();"
                        onserverclick="btnSearch_Click" tabindex="5"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="#" id="btnCancel" runat="server" class="cancelButt" onserverclick="btnCancel_Click"
                        tabindex="6"></a>
                </div>
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server">

       

            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="true"
                CssClass="grid-view" ShowHeader="true"  ShowFooter="true"  ShowHeaderWhenEmpty="true" Width="100%"
                 OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_left" BorderWidth="1px" HorizontalAlign="Left" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />

                   <Columns>
            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                <ItemTemplate>
                     <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
             </asp:TemplateField>
     </Columns>

            </asp:GridView>
        </div>
        <%--  </div>--%>
    </div>
    <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
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
                //NewWindow1('../Billing_Imp_Rpt/GST_Bill_Import_Job_rpt.aspx?Jobno=' + encodeURIComponent(jobno) + '&Bill_Invo=' + Bill_Invo + '&Tax_Mode=' + Tax_Mode + '', 'List', '870', '1024', 'yes');
                NewWindow1('../Billing_Imp_Rpt/ExpPaymentReport.aspx?Jobno=' + encodeURIComponent(jobno) + '&Bill_Invo=' + Bill_Invo + '&Tax_Mode=' + Tax_Mode + '', 'List', '870', '1024', 'yes');
            }
            else {
                jAlert('Select one Receipt', 'Receipt', function (r) { document.getElementById("ddljobno").focus(); });
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
                    /*alert (lastProductId);*/
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
