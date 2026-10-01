<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="Accounts_Unbilled_Jobs_Search.aspx.cs" Inherits="Accounts_Unbilled_Jobs_Search" %>

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
        td.column_style_left5
        {
            line-height: 1.5em;
            border-left: #cdbdbd solid thin;
            text-align: left;
            padding-left: 3px;
            padding-right: 3px;
            overflow: hidden;
            text-overflow: ellipsis;
        }
        
        .nowrap
        {
            white-space: nowrap;
        }
        
        
        .selected_row
        {
            background-color: white;
            font-weight: bold; /*color:#5E4C4C;*/
            color: #3C3535;
        }
        
        
        .grid-view
        {
            table-layout: fixed;
            border-collapse: separate;
            border-spacing: 0;
        }
        
        .multi-dropdown
        {
            position: relative;
            width: 220px;
        }
        
        
        .dropdown-panel
        {
            position: absolute;
            background: #fff;
            border: 1px solid #999;
            width: 100%;
            display: none;
            z-index: 999;
            max-height: 200px;
            overflow-y: auto;
        }
        
        .dropdown-header
        {
            background: #ffcc00;
            padding: 5px;
            font-weight: bold;
        }
        
        .dropdown-footer
        {
            background: #eee;
            padding: 5px;
            text-align: center;
        }
        .column_style_left5
        {
            margin-left: 35px;
            font-size: 11px;
        }
        
        .grid-view tr.gridFooterRow td
        {
            position: sticky;
            bottom: 0;
            z-index: 90;
            background-color: inherit;
        }
        
        .grid-view th
        {
            position: sticky;
            top: 0;
            z-index: 100;
            background-color: inherit;
        }
        #gridPager
        {
            margin-top: 8px;
            padding: 6px 0;
            text-align: center;
            border-radius: 7px;
            background-color: inherit; /*#e6e5e5;*/
        }
        .grid-view th a
        {
            text-decoration: none;
            color: #000000;
            cursor: pointer;
        }
        .sort-icon
        {
            margin-left: 4px;
            font-size: 10px;
            font-weight: bold;
            vertical-align: middle;
            line-height: 1;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("[id*=gvUnbilledJobs] td").bind("click", function () {
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
   
  

    function toggleBranchDropdown() {
        var panel = document.getElementById("branchPanel");
        panel.style.display = panel.style.display === "block" ? "none" : "block";
    }

    // CLOSE DROPDOWN WHEN CLICK OUTSIDE
    document.addEventListener("click", function (event) {
        var dropdown = document.getElementById("branchDropdown");
        var panel = document.getElementById("branchPanel");

        if (!dropdown.contains(event.target)) {
            panel.style.display = "none";
        }
    });

    // UPDATE TEXTBOX VALUE
    function updateText() {
        var selectedText = [];
        var selectedValues = [];

        var items = document.querySelectorAll("#<%= chkBranch.ClientID %> input");

        items.forEach(function (chk) {
            if (chk.checked) {
                var label = chk.parentNode.textContent.trim();
                selectedText.push(label);
                selectedValues.push(chk.value);
            }
        });

        document.getElementById("<%= txtBranchDisplay.ClientID %>").value =
            selectedText.length ? selectedText.join(", ") : "";
        
        // store values (optional for backend)
        document.getElementById("<%= hdnBranchValues.ClientID %>").value =
           document.getElementById("<%= txtBranchDisplay.ClientID %>").value
    }

    // CHECK ALL
    function checkAll() {
        var items = document.querySelectorAll("#<%= chkBranch.ClientID %> input");
        items.forEach(x => x.checked = true);
        updateText();
    }

    // UNCHECK ALL
    function uncheckAll() {
        var items = document.querySelectorAll("#<%= chkBranch.ClientID %> input");
        items.forEach(x => x.checked = false);
        updateText();
    }

    // BIND CHANGE EVENT
    document.addEventListener("DOMContentLoaded", function () {

        var items = document.querySelectorAll("#<%= chkBranch.ClientID %> input");

        items.forEach(function (chk) {
            chk.addEventListener("change", function () {
                updateText();
            });
        });

        // load initial values
        updateText();
    });

    </script>
    <div id="innerbox_MidMain" style="height: 199px;">
        <div id="tag_srcinner1">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                    Unbilled Jobs
                </div>
                <div id="verslic">
                </div>
                <div style="padding: 5px;">
                    <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClientClick="exportToExcel(); return false;" />
                </div>
            </div>
        </div>
        <table style="width: 100%; border: 1px solid #ccc;">
            <!-- ROW 1 -->
            <tr style="height: 25px;">
                <td style="width: 100px;">
                    <div id="tag_label_transact_Src">
                        Branch</div>
                </td>
                <td style="width: 200px;">
                    <div id="txtcon-m_src">
                        <div class="multi-dropdown" id="branchDropdown">
                            <!-- TEXTBOX -->
                            <asp:TextBox ID="txtBranchDisplay" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                Text="Select" onclick="toggleBranchDropdown()" Width="170px" />
                            <!-- DROPDOWN PANEL -->
                            <div class="dropdown-panel" id="branchPanel">
                                <div class="dropdown-header">
                                    Select</div>
                                <!-- CHECKBOX LIST -->
                                <asp:CheckBoxList ID="chkBranch" runat="server" Width="180px">
                                </asp:CheckBoxList>
                                <!-- FOOTER -->
                                <div class="dropdown-footer">
                                    <a href="javascript:void(0)" onclick="checkAll()">Check All</a> | <a href="javascript:void(0)"
                                        onclick="uncheckAll()">UnCheck All</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
                <td>
                    <div id="tag_label_transact_Src">
                        As On Date</div>
                </td>
                <td>
                    <div id="txtcon-m_src">
                        <asp:TextBox ID="txtAsOnDate" runat="server" ClientIDMode="Static" MaxLength="10"
                            CssClass="txtbox_none_Mid_transac_code" Width="170px" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtAsOnDate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAsOnDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>
                </td>
            </tr>
            <!-- ROW 2 -->
            <tr style="height: 25px;">
                <td>
                    <div id="tag_label_transact_Src">
                        LOB</div>
                </td>
                <td>
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddlLOB" runat="server" CssClass="listtxt_transac_item_gen_notn"
                            Width="180px" Height="24px">
                            <asp:ListItem Text="All" Value=""></asp:ListItem>
                            <asp:ListItem Text="Import Air" Value="IA"></asp:ListItem>
                            <asp:ListItem Text="Import Sea" Value="IS"></asp:ListItem>
                            <asp:ListItem Text="Import Land" Value="IL"></asp:ListItem>
                            <asp:ListItem Text="Export Air" Value="EA"></asp:ListItem>
                            <asp:ListItem Text="Export Sea" Value="ES"></asp:ListItem>
                            <asp:ListItem Text="Export Land" Value="EL"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <div id="tag_label_transact_Src">
                        <asp:DropDownList ID="ddl_Shipper" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Shipper_SelectedIndexChanged"
                            Width="100px" Height="24px">
                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                            <asp:ListItem Text="Shipper" Value="Shipper"></asp:ListItem>
                            <asp:ListItem Text="Consignee" Value="Consignee"></asp:ListItem>
                            <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddl_Customer" runat="server" Width="350px">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <!-- ROW 3 -->
            <tr style="height: 25px;">
                <td>
                    <div id="tag_label_transact_Src">
                        Expense</div>
                </td>
                <td>
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddlExpense" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            Width="80px" Height="22px">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtExpense" runat="server" Width="80px" Text="0.00" />
                    </div>
                </td>
                <td>
                    <div id="tag_label_transact_Src">
                        Period</div>
                </td>
                <td>
                    <div id="txtcon-m_src">
                        <asp:TextBox ID="txtPeriod" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            Width="170px" />
                    </div>
                </td>
            </tr>
            <!-- ROW 4 -->
            <tr style="height: 25px;">
                <td>
                    <div id="tag_label_transact_Src">
                        Status</div>
                </td>
                <td>
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddlStatus" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            Width="180px" Height="24px" />
                    </div>
                </td>
                <td>
                    <div id="tag_label_transact_Src">
                        Stage Name</div>
                </td>
                <td>
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddlStage" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            Width="180px" Height="24px" />
                    </div>
                </td>
            </tr>
            <!-- ROW 5 -->
            <tr style="height: 25px;">
                <td>
                    <div id="tag_label_transact_Src">
                        Assigned To</div>
                </td>
                <td>
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddlAssign" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            Width="180px" Height="24px" />
                    </div>
                </td>
                <td>
                    <div id="tag_label_transact_Src">
                        Sales Person</div>
                </td>
                <td>
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddlSales" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            Width="180px" Height="24px" />
                    </div>
                </td>
            </tr>
            <!-- ROW 6 -->
            <tr style="height: 25px;">
                <td>
                    <div id="tag_label_transact_Src">
                        Job No</div>
                </td>
                <td>
                    <div id="txtcon-m_src">
                        <asp:TextBox ID="txtJobNo" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            Width="170px" />
                    </div>
                </td>
                <td>
                </td>
                <td>
                    <div id="txtcon-m_src" style="width: 430px;">
                        <asp:CheckBox ID="chkInclJobs" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            Text="Incl Jobs From" />
                        <asp:CheckBox ID="chkCompleted" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            Text="Incl Completed Jobs" />
                        <asp:CheckBox ID="chkClosed" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            Text="Excl Financially Closed Jobs" />
                    </div>
                </td>
            </tr>
            <!-- ROW 7 -->
            <tr style="height: 25px;">
                <td colspan="4">
                    <div style="text-align: right;">
                        <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click"
                            Style="margin-right: 121px; margin-top: -70px; height: 29px; width: 100px; color: darkgreen;
                            font-size: 17px; font-weight: bold;" />
                    </div>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <div id="gridPager">
    </div>
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: 10px; overflow: auto">
        <div id="Main_Grid_Container" runat="server" style="overflow: visible;">
            <asp:GridView runat="server" ID="gvUnbilledJobs" EmptyDataText="NO RECORD FOUND"
                AutoGenerateColumns="False" CssClass="grid-view" ShowHeaderWhenEmpty="True" Width="100%"
                OnRowDataBound="gvUnbilledJobs_RowDataBound" CellPadding="1" DataKeyNames="JOBNO_PS"
                OnRowCreated="gvUnbilledJobs_RowCreated" AllowSorting="True" ShowFooter="True"
                OnSorting="gvUnbilledJobs_Sorting">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_right" BorderWidth="1px" />
                <FooterStyle BackColor="#99FF99" BorderColor="Black" BorderStyle="Solid" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="48px">
                        <ItemTemplate>
                            <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="48px"></HeaderStyle>
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="27px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Module" HeaderText="Module" HeaderStyle-Width="100px"
                        HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JobType" HeaderText="JobType" HeaderStyle-Width="100px">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Center" Width="100px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Center" Width="308px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="270px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No" SortExpression="JOBNO_PS"
                        HeaderStyle-Width="100px">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Center" Width="110px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Right" Width="80px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Job Date" HeaderStyle-Width="128" HeaderStyle-HorizontalAlign="Center"
                        SortExpression="JOBDATE">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("JOBDATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Right" Width="128px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                        <FooterTemplate>
                            <asp:Label ID="lblJobDate" runat="server" ClientIDMode="Static" Text="Total Expense Amount" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Expense Amt" SortExpression="Expense_Amt">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Expense_Amt","{0:N2}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalExpense" runat="server" ClientIDMode="Static" Text="0.00" />
                        </FooterTemplate>
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Right" Width="100px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="123px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Mode" HeaderText="Mode">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Right" Width="100px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="52px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LoadPort" HeaderText="Load Port">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Right" Width="150px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DestinationPort" HeaderText="Destination Port">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Right" Width="150px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Shipper" HeaderText="Shipper">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Right" Width="200px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Consignee" HeaderText="Consignee">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Right" Width="200px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Location" HeaderText="Location">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Right" Width="200px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BRANCHCODE" HeaderText="Branch">
                        <HeaderStyle CssClass="nowrap" HorizontalAlign="Right" Width="200px" />
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="200px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <div id="loadingDiv" style="display: none; text-align: center; position: absolute;
                top: 0; margin-top: -250px; left: 0; width: 100%; height: 100%; z-index: 9999;
                background-color: rgba(0, 0, 0, 0.5); align-items: center; justify-content: center;
                pointer-events: none;">
                <div style="position: relative; z-index: 10000; display: flex; align-items: center;">
                    <img src="../images/Infinity.gif" alt="Loading" style="max-width: 100px; max-height: 100px;
                        margin-right: 10px;" />
                    <p style="color: white; font-size: 18px;">
                        Loading...</p>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var gvUnbilledJobsClientId = '<%= gvUnbilledJobs.ClientID %>';
    </script>
    <script src="../js/Accounts/UnbilledJobsPager.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/Accounts/UnbilledJobsExport.js"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="hdnBranchValues" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () {
            document.getElementById('<%=gvUnbilledJobs.ClientID %>').style.width = "100%";
        });

        function forceHideLoader() {
            var loader = document.getElementById("loadingDiv");
            if (loader) {
                loader.style.display = "none";
                loader.style.visibility = "hidden";
            }
        }

        // EXTRA: auto hide after download trigger
        setTimeout(function () {
            forceHideLoader();
        }, 2000);
    </script>
</asp:Content>
