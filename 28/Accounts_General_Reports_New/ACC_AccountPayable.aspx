<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ACC_AccountPayable.aspx.cs"
    Inherits="Accounts_General_Reports_New_ACC_AccountPayable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Accounts Payable</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        .radio-spacing input[type='radio']
        {
            margin-right: 10px;
        }
        .ad
        {
            width: 50px;
        }
        th a
        {
            text-decoration: none;
        }
        
        td.column_style_left1
        {
            line-height: 1.5em;
            border-left: #c8c8c8 solid thin;
            text-align: center;
            padding-right: 5px;
        }
        td.column_style_left1R
        {
            line-height: 1.5em;
            border-left: #c8c8c8 solid thin;
            text-align: right;
            padding-right: 5px;
        }
        .nowrap
        {
            white-space: nowrap;
        }
        
        .selected_row
        {
            background-color: white;
            font-weight: bold;
            color: #3C3535;
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
        
        select.listtxt_transac_item_gen_notn
        {
            background-color: #fff !important;
            color: #000;
        }
        
        input[type="checkbox"]
        {
            border-radius: 0 !important;
            outline: none;
        }
        
        .btn.btn-primary
        {
            padding: 4px 12px;
            font-size: 12px;
            min-width: auto;
        }
        
        .column_style_left5
        {
            margin-left: 35px;
            font-size: 11px;
        }
        
        #txtcon-m_src
        {
            overflow: visible !important;
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
        .account-payable-detail-scroll
        {
            height: 450px;
            overflow-y: auto;
            overflow-x: hidden;
            width: 100%;
            border: 1px solid #C8C8C8;
        }
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 1450px;
                height: 229px; background-color: #FFFFFF;">
                <div id="tag_transac_lft_Inv_in1" style="width: 1376px;">
                    <div id="innerbox_MidMain" style="height: 150px; width: 1450px;">
                        <div id="tag_srcinner1">
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 190px;">
                                Accounts Payable
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 120px;">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btnExportExcel" runat="server" Text="Export to Excel" OnClientClick="startDownload(); return false;"
                                            CssClass="btn btn-success" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnExportExcel" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div id="popupwindow_closebut_right">
                                <%--<input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />--%>
                            </div>
                        </div>
                        <table style="width: 100%; border: 1px solid #ccc; table-layout: fixed;">
                            <tr style="height: 25px;">
                                <td style="width: 100px;">
                                    <div id="tag_label_transact_Src">
                                        Basis</div>
                                </td>
                                <td style="width: 170px;">
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddl_DateBasis" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                            Width="150px" Height="24px">
                                            <asp:ListItem Text="Bill Date" Value="BillDate"></asp:ListItem>
                                            <asp:ListItem Text="Due Date" Value="DueDate"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="width: 90px;">
                                    <div id="tag_label_transact_Src">
                                        As On Date</div>
                                </td>
                                <td style="width: 140px;">
                                    <div id="txtcon-m_src">
                                        <asp:TextBox ID="txtAsOnDate" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtAsOnDate"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAsOnDate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>
                                </td>
                                <td style="width: 80px;">
                                    <div id="tag_label_transact_Src">
                                        Group By</div>
                                </td>
                                <td style="width: 170px;">
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddlGroupBy" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                            Width="150px" Height="24px">
                                            <asp:ListItem Text="None" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Party" Value="Party"></asp:ListItem>
                                            <asp:ListItem Text="Branch" Value="Branch"></asp:ListItem>
                                            <asp:ListItem Text="Invoice" Value="Invoice"></asp:ListItem>
                                            <asp:ListItem Text="Job" Value="Job"></asp:ListItem>
                                            <asp:ListItem Text="Location" Value="Location"></asp:ListItem>
                                            <asp:ListItem Text="Currency" Value="Currency"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 100px;">
                                    <div id="tag_label_transact_Src">
                                        Type</div>
                                </td>
                                <td style="width: 170px;">
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddlType" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                            Width="150px" Height="24px">
                                            <asp:ListItem Text="Summary" Value="Summary"></asp:ListItem>
                                            <asp:ListItem Text="Detail" Value="Detail"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="width: 90px;">
                                    <div id="tag_label_transact_Src">
                                        Location</div>
                                </td>
                                <td style="width: 140px;">
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                            Width="155px" Height="24px">
                                            <asp:ListItem Text="Chennai" Value="Chennai"></asp:ListItem>
                                            <asp:ListItem Text="Mumbai" Value="Mumbai"></asp:ListItem>
                                            <asp:ListItem Text="Delhi" Value="Delhi"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="width: 130px;">
                                    <div id="txtcon-m_src">
                                        <asp:CheckBox ID="chkINRValues" runat="server" Text="INR Values" Style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: 12px;" />
                                    </div>
                                </td>
                                <td style="width: 130px;">
                                    <div id="txtcon-m_src">
                                        <asp:CheckBox ID="chkTxnCurrValues" runat="server" Text="TXN Curr. Values" Style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: 12px;" />
                                    </div>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 100px;">
                                    <div id="tag_label_transact_Src">
                                        Basis</div>
                                </td>
                                <td style="width: 170px;">
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddlBasis" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                            Width="150px" Height="24px">
                                            <asp:ListItem Text="Organisation" Value="Organisation"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="width: 320px;">
                                    <div id="txtcon-m_src" style="position: absolute; left: 461px;">
                                        <asp:DropDownList ID="ddl_org_name" runat="server" Width="390px" CssClass="validate[required] chosen-select"
                                            Style="margin-top: -50px;" data-placeholder="Choose a Org. Name">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="width: 60px;">
                                </td>
                                <td style="width: 140px;">
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddlOptions" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                            Width="120px" Height="24px">
                                            <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td colspan="6">
                                    <div style="text-align: left; padding-top: 5px;">
                                        <asp:LinkButton ID="lnkClear" runat="server" CssClass="link-button" OnClientClick="return resetFields();">Clear</asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnGenerate" runat="server" Text="Generate" CssClass="btn btn-primary"
                                            OnClick="btnGenerate_Click" Style="padding: 4px 10px; width: 110px;" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="innerbox_MidMain_Grid" style="height: 460px; margin-top: -13px; width: 1450px;">
                        <div class="pagination" id="Div_Pagination" runat="server" style="margin-bottom: 8px;">
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Page No.</div>
                            <div id="txtcon-m_transaction_list1_fcl">
                                <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                                    OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <span class="disabled">
                                <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">First</asp:LinkButton></span>
                            <span class="disabled">
                                <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">Previous</asp:LinkButton></span>
                            <span class="selected">Page
                                <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
                                <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                            </span><span class="disabled">
                                <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                            <span class="disabled">
                                <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                            </span>
                        </div>
                        <div runat="server" id="div_pagination1" visible="false">
                            <br />
                            <br />
                        </div>
                        <div runat="server" id="pnlSummaryGrid">
                            <div class="account-payable-detail-scroll">
                                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="ORGANIZATION_NAME" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="200"
                                    ShowFooter="true" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                                    AllowSorting="true" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="1" CellSpacing="1" OnSorting="gvdetails_Sorting">
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        BorderWidth="1px" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ORGANIZATION_NAME" HeaderText="Organisation Name" SortExpression="ORGANIZATION_NAME">
                                            <ItemStyle CssClass="column_style_left" Width="320px" />
                                            <HeaderStyle Width="520px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OUTSTANDING" HeaderText="Outstanding">
                                            <ItemStyle CssClass="column_style_left1R" Width="130px" HorizontalAlign="Right" />
                                            <HeaderStyle Width="300px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ON_ACCOUNT" HeaderText="On Account">
                                            <ItemStyle CssClass="column_style_left1R" Width="70px" HorizontalAlign="Right" />
                                            <HeaderStyle Width="300px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NET_OUTSTANDING" HeaderText="Net Outstanding">
                                            <ItemStyle CssClass="column_style_left1R" Width="220px" HorizontalAlign="Right" />
                                            <HeaderStyle Width="300px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerSettings Visible="False" />
                                </asp:GridView>
                            </div>
                        </div>
                        <%------------------------------------------------------GRID FOR DETIALS---------------------------------------------------%>
                        <div runat="server" id="pnlDetailGrid" visible="false">
                            <div class="account-payable-detail-scroll">
                                <asp:GridView runat="server" ID="gvdetailsDetail" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                                    Width="100%" ShowHeaderWhenEmpty="True" PageSize="200" ShowFooter="true" AllowPaging="True"
                                    OnRowCreated="gvdetailsDetail_RowCreated" OnRowDataBound="gvdetailsDetail_RowDataBound"
                                    AllowSorting="true" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="1" CellSpacing="1" OnSorting="gvdetailsDetail_Sorting">
                                    <%--DataKeyNames=""--%>
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        BorderWidth="1px" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="Organization" HeaderText="Organization">
                                            <ItemStyle CssClass="column_style_left" Width="200px" />
                                            <HeaderStyle Width="250px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Trans. Date" HeaderText="Trans. Date">
                                            <ItemStyle CssClass="column_style_left1" Width="100px" />
                                            <HeaderStyle Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Transaction No" HeaderText="Transaction No">
                                            <ItemStyle CssClass="column_style_left1" Width="130px" />
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Vendor Inv No" HeaderText="Vendor Inv No">
                                            <ItemStyle CssClass="column_style_left1" Width="130px" />
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Vendor Inv Date" HeaderText="Vendor Inv Date">
                                            <ItemStyle CssClass="column_style_left1" Width="100px" />
                                            <HeaderStyle Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Bill Amount (INR)" HeaderText="Bill Amount (INR)">
                                            <ItemStyle CssClass="column_style_left1R" Width="130px" HorizontalAlign="Right" />
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Paid/Settled (INR)" HeaderText="Paid/Settled (INR)">
                                            <ItemStyle CssClass="column_style_left1R" Width="130px" HorizontalAlign="Right" />
                                            <HeaderStyle Width="160px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Outstanding (INR)" HeaderText="Outstanding (INR)">
                                            <ItemStyle CssClass="column_style_left1R" Width="130px" HorizontalAlign="Right" />
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Due Date" HeaderText="Due Date">
                                            <ItemStyle CssClass="column_style_left1" Width="100px" />
                                            <HeaderStyle Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OverDue Date" HeaderText="OverDue Days">
                                            <ItemStyle CssClass="column_style_left1" Width="100px" />
                                            <HeaderStyle Width="130px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ageing Days" HeaderText="Ageing Days">
                                            <ItemStyle CssClass="column_style_left1" Width="100px" />
                                            <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerSettings Visible="False" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="display: none;">
        <asp:HiddenField ID="hdnparty" runat="server" />
        <asp:HiddenField ID="hdnjobno" runat="server" />
        <iframe id="downloadFrame" style="display: none;"></iframe>
    </div>
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/Accounts/Imp_Exp_Invoice_Tab.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }

        }
        for (var selector in config) {
            var $select = $(selector).chosen(config[selector]);
            if (selector === '.chosen-select-deselect') {
                $select.on('change', function () {
                    var $container = $(this).next('.chosen-container');
                    $container.removeClass('chosen-with-drop');
                    $container.find('.chosen-drop').hide();
                });
            }
        }

        $(document).on('click', function (e) {
            if (!$(e.target).closest('.chosen-container').length) {
                $('.chosen-container').each(function () {
                    var $this = $(this);
                    if ($this.hasClass('chosen-with-drop')) {
                        $this.trigger('chosen:close');
                    }
                });
            }
        });
    </script>
    <script type="text/javascript">
        function startDownload() {

            document.getElementById("load").style.display = "block";

            var type = document.getElementById("<%= ddlType.ClientID %>").value;

            var txtAsOnDateValue =
            document.getElementById("<%= txtAsOnDate.ClientID %>").value;

            var organizationValue =
            document.getElementById("<%= ddl_org_name.ClientID %>").value;

            var dateBasisValue =
            document.getElementById("<%= ddl_DateBasis.ClientID %>").value;

            document.getElementById("downloadFrame").src =
            "ACC_AccountPayable.aspx?payable=1" +
            "&type=" + encodeURIComponent(type) +
            "&AsOnDate=" + encodeURIComponent(txtAsOnDateValue) +
            "&Organization=" + encodeURIComponent(organizationValue) +
            "&DateBasis=" + encodeURIComponent(dateBasisValue);

            setTimeout(function () {
                document.getElementById("load").style.display = "none";
            }, 2000);
        }
    </script>
    <script type="text/javascript">
        function resetFields() {
            document.getElementById('<%= ddl_DateBasis.ClientID %>').value = 'BillDate';

            // As On Date - Today (dd/MM/yyyy)
            var today = new Date();
            var day = today.getDate();
            var month = today.getMonth() + 1;
            var year = today.getFullYear();

            if (day < 10) {
                day = '0' + day;
            }

            if (month < 10) {
                month = '0' + month;
            }

            document.getElementById('<%= txtAsOnDate.ClientID %>').value =
                day + '/' + month + '/' + year;


            document.getElementById('<%= ddlGroupBy.ClientID %>').value = '';
            document.getElementById('<%= ddlType.ClientID %>').value = 'Summary';
            document.getElementById('<%= chkINRValues.ClientID %>').checked = true;

            document.getElementById('<%= ddlLocation.ClientID %>').selectedIndex = 0;
            $("#<%= ddl_org_name.ClientID %>").val("").trigger("chosen:updated");

            document.getElementById('<%= ddlBasis.ClientID %>').value = 'Organisation';
            document.getElementById('<%= ddlOptions.ClientID %>').value = 'ALL';


            $("#<%= gvdetails.ClientID %>").hide();
            $("#<%= gvdetailsDetail.ClientID %>").hide();


            return false;
        }
 
    </script>
</body>
</html>
