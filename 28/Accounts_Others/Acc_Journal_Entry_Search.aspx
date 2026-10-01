<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="Acc_Journal_Entry_Search.aspx.cs" Inherits="Acc_Journal_Entry_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
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
            font-weight: bold; /*color:#5E4C4C;*/
            color: #3C3535;
        }
    </style>
    <script language="javascript" type="text/javascript">
        document.body.style.cursor = 'pointer';

        function ChangeRowColor(rowID, Value) {
            document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
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
    <div id="innerbox_MidMain" style="height: 135px;">
        <div id="tag_srcinner1">
            <div id="newbu">
                <input type="submit" value="Submit" class="new" tabindex="1" onclick="open_Journal_Entry(); return false" />
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                Journal Entry
            </div>
        </div>        
        <div id="tag_transact_src_inner" style="width: 1200px; overflow: hidden;">
            <div style="float: left; width: 930px;">
                <div style="clear: both; height: 35px;">
                    <div id="tag_label_transact_Src" style="width: 120px;">
                        Transaction No
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txt_Trans_No" runat="server" ClientIDMode="Static" Style="width: 100px;"
                            CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="5">
                        </asp:TextBox>
                    </div>
                    <div id="tag_label_transact_Src" style="width: 120px;">
                        G/Ledger No
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txt_Gledger_No" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code">
                        </asp:TextBox>
                    </div>
                </div>
                <div style="clear: both; height: 35px;">
                    <div id="tag_label_transact_Src" style="width: 120px;">
                        Posting From Date
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            MaxLength="10" TabIndex="6">
                        </asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                            Mask="99/99/9999" MaskType="Date">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>
                    <div id="tag_label_transact_Src" style="width: 120px;">
                        Posting To Date
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            MaxLength="10" TabIndex="7">
                        </asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                            Mask="99/99/9999" MaskType="Date">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>
                    <div id="tag_label_transact_Src" style="width: 80px;">
                        Month
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 130px;">
                        <asp:DropDownList ID="ddlmonth" runat="server" Width="120px" CssClass="txtbox_none"
                            Font-Size="12px" TabIndex="10">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght" style="float: right; width: 230px;">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                        onserverclick="btnSearch_Click" tabindex="12"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="13">
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="No Records's Found" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                DataKeyNames="JV_ID,JV_NO" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
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
                    <asp:BoundField DataField="JV_No" HeaderText="Trans. No" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="120px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="120px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JV_DATE" HeaderText="Trans. Date" DataFormatString="{0:dd/MM/yyyy}"
                        HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="90px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="POSTING_DATE" HeaderText="Posting Date" DataFormatString="{0:dd/MM/yyyy}"
                        HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="90px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NARRATION" HeaderText="Narration" HeaderStyle-Width="350px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="350px" Font-Size="11px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
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
    <%--javascript function for transno search --%>
    <script type="text/javascript">
        $(function () {
            $("#txt_Trans_No").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../Accounts_Auto_Search/Accounts_Auto_Search.asmx/ACC_GST_Journal_Entry_Trans_Search",
                        data: "{ 'mail': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {

                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txt_Trans_No').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_Trans_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
        });
    </script>

     <%--javascript function for GL ledger number Search --%> 
    <script type="text/javascript">
        $(function () {
            $("#txt_Gledger_No").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../Accounts_Auto_Search/Accounts_Auto_Search.asmx/ACC_GST_Journal_Entry_GeneralLedgerNumber_Search",
                        data: "{ 'mail': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {

                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txt_Gledger_No').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_Gledger_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
        });
    </script>
</asp:Content>
