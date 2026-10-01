<%@ Page Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="Acc_Bill_To_Party_Others_Search.aspx.cs" Inherits="Accounts_Others_Entry_Acc_Bill_To_Party_Others_Search" %>

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

        function ChangeRowColor(rowID, Value) {
            document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#txtJobno").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../Accounts_Auto_Search/Accounts_Auto_Search.asmx/Other_Jobno",
                        data: "{ 'mail': '" + request.term + "','Imp_Exp': '" + document.getElementById("<%=ddl_JobType.ClientID %>").value + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtJobno').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txtJobno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
    </script>
    <div id="innerbox_MidMain" style="height: 105px;">
        <div id="tag_srcinner1">
            <div id="tag_srcinner1">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="Open_Other_Entry(''); return false" />
                </div>
                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                    Others Jobs Entry</div>
            </div>
            <%-- --------------------------------------------Start---------------------------%>
            <div id="tag_transact_src_inner" style="width: 900px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        <div id="tag_label_transact_Src" style="width: 70px;">
                            Job Type
                        </div>
                        <div id="txtcon-m_src" style="width: 80px;">
                            <asp:DropDownList ID="ddl_JobType" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="75px">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Imp" Value="I"></asp:ListItem>
                                <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transact_Src" style="width: 70px;">
                            Job No
                        </div>
                        <div id="txtcon-m_src" style="width: 200px;">
                            <asp:TextBox ID="txtJobno" runat="server" CssClass="txtbox_none_Mid_transac_src"
                                ClientIDMode="Static" MaxLength="50" Width="180px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 100px;">
                            Party Name
                        </div>
                        <div id="txtcon-m_src" style="width: 350px; position: absolute; margin-left: 520px;">
                            <asp:DropDownList ID="ddlParty_Name" runat="server" class="chosen-select" Style="width: 350px;"
                                data-placeholder="Choose a Party Name" TabIndex="6">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transact_lft_in1" style="width: 885px;">
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
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 45px;">
                            Month</div>
                        <div id="txtcon-m_transaction_code" style="width: 140px;">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="135px" TabIndex="5">
                            </asp:DropDownList>
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
            <%-- --------------------------------------------End---------------------------%>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                DataKeyNames="BILL_ID" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_right" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="75px">
                        <ItemTemplate>
                            <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="JOBTYPE" HeaderText="Job Type" ControlStyle-Width="120px"
                        HeaderStyle-Width="120px">
                        <ItemStyle CssClass="column_style_left5" Width="120px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No" ControlStyle-Width="210px"
                        HeaderStyle-Width="210px">
                        <ItemStyle CssClass="column_style_left5" Width="210px" Font-Size="12px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BILL_PARTY_NAME" HeaderText="Bill Party Name" ControlStyle-Width="300px"
                        HeaderStyle-Width="300px">
                        <ItemStyle CssClass="column_style_left5" Width="300px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BRANCH_NO" HeaderText="Branch No" ControlStyle-Width="120px"
                        HeaderStyle-Width="120px">
                        <ItemStyle CssClass="column_style_left5" Width="120px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="STATENAME" HeaderText="State Name" ControlStyle-Width="150px"
                        HeaderStyle-Width="150px">
                        <ItemStyle CssClass="column_style_left5" Width="150px" Font-Size="12px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
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
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
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
