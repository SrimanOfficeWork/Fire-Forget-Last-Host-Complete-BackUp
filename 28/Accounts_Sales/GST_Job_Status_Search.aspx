<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="GST_Job_Status_Search.aspx.cs" Inherits="GST_Job_Status_Search" %>

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

        function ChangeRowColor(rowID, Value, Bill_invno, IMP_EXP) {
            document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
            document.getElementById("<%=hdBill_invno.ClientID %>").value = Bill_invno;
            document.getElementById("<%=hd_Imp_Exp.ClientID %>").value = IMP_EXP;
        }
    </script>
<%--    <script type="text/javascript">
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
    </script>--%>

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
    
    <div id="innerbox_MidMain" style="height: 110px;">
        <div id="tag_srcinner1">
            <div id="tag_srcinner1">
               <%-- <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_GST_Sales_Entry_N('New'); return false" />
                </div>
                <div id="verslic">
                </div>--%>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                    Job Status
                </div>
              
                <div id="editbu" style="padding-top: 3px; display: none;">
                    <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                        Width="28px" OnClientClick="EXcel()" />
                </div>
               
                <div id="verslic">
                </div>
                <div id="editbu" style="padding-top: 8px;">
                    <span id="Yet_To_Bill" runat="server" style="color: Orange; cursor: hand; font-size: smaller;">
                        Yet to Bill (<span style="color: Red; font-weight: bold;">
                            <asp:Literal ID="lblcnt" runat="server"></asp:Literal></span>) </span>
                </div>
                <div id="verslic">
                </div>
                <div id="editbu" style="padding-top: 8px;">
                    <span id="lblYC_Count" runat="server" style="color: Red; cursor: hand; font-size: smaller;">
                        Yet To Close Count (<span style="color: Red; font-weight: bold;">
                            <asp:Literal ID="lblYCcnt" runat="server"></asp:Literal></span>) </span>
                </div>
                <div id="verslic">
                </div>
                <div id="editbu" style="padding-top: 8px;">
                    <span id="Billed_Count" runat="server" style="color: Green; cursor: hand; font-size: smaller;">
                        Billed Count (<span style="color: Red; font-weight: bold;">
                            <asp:Literal ID="lblBcnt" runat="server"></asp:Literal></span>) </span>
                </div>
               </div>
            <%----------------------------------------------Start---------------------------%>
            <div id="tag_transact_src_inner" style="width: 1030px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 1050px;">
                           <div id="tag_label_transact_Src" style="width: 80px;">
                                Job Status
                            </div>
                            <div id="txtcon-m_src" style="width: 160px;">
                                <asp:DropDownList ID="ddljob_Status" runat="server" CssClass="txtbox_none"  TabIndex="4" Font-Size="12px" Width="150px">
                                    <asp:ListItem Text="Yet to Bill Jobs" Value="YB"></asp:ListItem>
                                    <asp:ListItem Text="Yet to Close Jobs" Value="YC"></asp:ListItem>
                                    <asp:ListItem Text="Billed jobs" Value="B"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Imp/Exp
                            </div>
                            <div id="txtcon-m_src" style="width: 80px;">
                                <asp:DropDownList ID="ddl_Type" runat="server" CssClass="txtbox_none"  TabIndex="7"  Font-Size="12px" Width="75px">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Imp" Value="I"></asp:ListItem>
                                    <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 100px;">
                                Customer Name
                            </div>
                            <div id="txtcon-m_src" style="width: 320px;">
                                <asp:DropDownList ID="ddlCus_name" runat="server" CssClass="txtbox_none"  TabIndex="10" Font-Size="12px" Width="315px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" style="width: 80px;">
                                From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="12"></asp:TextBox>
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
                                    MaxLength="10" TabIndex="13"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                            <div id="tag_label_transaction_Src_longlabel" style="width: 45px;">
                                Month</div>
                            <div id="txtcon-m_transaction_code" style="width: 140px;">
                                <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                    Width="135px" TabIndex="15">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <%-- -------------------------------------------------------------------------------%>
                        </div>
                        <%------------------------------------------------------%>
                    </div>
                </div>
                <div id="tag_transact_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                            onserverclick="btnSearch_Click" tabindex="16"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="17"></a>
                    </div>
                </div>
            </div>
            <%-- --------------------------------------------End---------------------------%>
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
                OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" DataKeyNames="IMP_EXP,JOBNO_PS"
                CellSpacing="1" OnRowCreated="gvdetails_RowCreated">

                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                     <ItemTemplate>
                        <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="right" Width="45px" />
                    </asp:TemplateField>

                      <asp:BoundField DataField="IMP_EXP" HeaderText="Imp / Exp" HeaderStyle-Width="80px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="60px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No" HeaderStyle-Width="130px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="120px" Font-Size="11px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="BILL_INV_NO" HeaderText="Sales Bill. No" HeaderStyle-Width="130px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="120px" Font-Size="11px" />
                    </asp:BoundField>
                  
                    <asp:BoundField DataField="PARTY_NAME" HeaderText="Bill Party Name" HeaderStyle-Width="430px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="430px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GRAND_TOTAL" HeaderText="Grand Total" HeaderStyle-Width="200px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="200px" Font-Size="11px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <div id="loadingDiv" style="display: none; text-align: center; position: absolute; top: 0; margin-top:-250px;
                            left: 0; width: 100%; height: 100%; z-index: 9999; background-color: rgba(0, 0, 0, 0.5);
                            align-items: center; justify-content: center; pointer-events: none;">
                            <div style="position: relative; z-index: 10000; display: flex; align-items: center;">
                                <img src="../images/Infinity.gif" alt="Loading" style="max-width: 100px; max-height: 100px;
                                    margin-right: 10px;" />
                                <p style="color: white; font-size: 18px;">
                                   Loading...</p>
                            </div>
                        </div>
        </div>
    </div>
    <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="hdBill_invno" runat="server" />
    <asp:HiddenField ID="hd_Imp_Exp" runat="server" />
    <asp:HiddenField ID="HDBranch" runat="server" />
    <script language="javascript">
        function Inv_Bill() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            var Bill_Invo = document.getElementById("<%=hdBill_invno.ClientID %>").value;
            var Imp_Exp = document.getElementById("<%=hd_Imp_Exp.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../Accounts_Sales_Inv_Rpt/GST_Imp_Exp_rpt.aspx?Job_Id=' + jobno + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Invo + '', 'List', '870', '1024', 'yes');
            }
            else {
                jAlert('Select a Grid Job', 'Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
            }

        }
    </script>
    <iframe id="hiddenFrame" name="hiddenFrame" style="display: none;"></iframe>
    <script type="text/javascript">
        function Inv_Bill_Grid(jobno, Imp_Exp, Bill_Invo) {

           document.getElementById('loadingDiv').style.display = 'flex';
            document.body.style.pointerEvents = 'none';
            var url = '../Accounts_Sales_Inv_Rpt/GST_Imp_Exp_rpt.aspx?Job_Id=' + jobno + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Invo + '&click=1';
            document.getElementById('hiddenFrame').src = url;
        }


        window.addEventListener('message', function (event) {
            if (event.data === 'hideLoadingDiv') {
                document.getElementById('loadingDiv').style.display = 'none';
                document.body.style.filter = 'none';
                document.body.style.pointerEvents = 'auto';
            }
        });

    </script>
    <script type="text/javascript">
        var win = null;

        var Ip_Ep = $('#<%= ddl_Type.ClientID %>').val();

        var Imp_name = $('#<%= ddlCus_name.ClientID %>').val();
        var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
        var Todate = $('#<%= txttodate.ClientID %>').val();
        var Month = $('#<%= ddlmonth.ClientID %>').val();

        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND') {
            function EXcel() {
                var Type = 'excel';
                // win = window.open('../FlatFile/MIS_report_1.aspx?GST_EXP_Tally_Data=Yes&ddlSearch_Cat=' + ddlSearch_Cat + '&txtsearch=' + txtsearch + '&Exp_name=' + Exp_name + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '', 'ndf');
                Loading_HideImage();
            }

            function Tally() {
                var Type = 'T';
                //win = window.open('../Accounts_Data_Link/Ac_Data_Rpt_Link.aspx?Accounts_Tally_Data=Yes&ddlSearch_Cat=' + ddlSearch_Cat + '&txtsearch=' + txtsearch + '&Imp_name=' + Imp_name + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '&Type=' + Type + '&Imp_Exp=' + Ip_Ep + '', 'ndf');
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
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
</asp:Content>
