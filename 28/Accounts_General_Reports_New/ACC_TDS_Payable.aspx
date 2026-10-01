<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ACC_TDS_Payable.aspx.cs"
    Inherits="ACC_TDS_Payable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>TDS Payable</title>
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
            text-align: right;
            padding-right: 5px; /*! padding-right:18px; */
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
        .grid-view
        {
            border-collapse: collapse;
        }
        .grid-view td, .grid-view th
        {
            border: 1px solid #C8C8C8;
        }
        td.column_style_left
        {
            line-height: 1.5em;
            border-left: #c8c8c8 solid thin;
            text-align: left;
            padding-left: 5px;
        }
        td.column_style_right
        {
            line-height: 1.5em;
            border-left: #c8c8c8 solid thin;
            text-align: right;
            padding-right: 5px;
        }
        th.column_style_header
        {
            text-align: center;
            vertical-align: middle;
        }
        .grid-scroll-wrapper
        {
            height: 400px; /* set whatever fits your layout */
            overflow-y: auto;
            overflow-x: hidden; /* kills horizontal scroll */
            width: 100%;
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
                <%--<div id="tag_transac_lft_Inv_in1" style="width: 1450px;">--%>
                <div id="innerbox_MidMain" style="height: 150px; width: 1450px;">
                    <div id="tag_srcinner1">
                        <div id="mainmastop2container_rght_tag2_txt1" style="width: 190px;">
                            TDS Payable
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
                        </div>
                    </div>
                    <table style="width: 100%; border: 1px solid #ccc; table-layout: fixed;">
                        <tr style="height: 25px;">
                            <td style="width: 100px;">
                                <div id="tag_label_transact_Src">
                                    Location</div>
                            </td>
                            <td style="width: 170px;">
                                <div id="txtcon-m_src">
                                    <asp:DropDownList ID="ddlLocation" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                        Width="155px" Height="24px">
                                        <asp:ListItem Text="Chennai" Value="Chennai"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="width: 90px;">
                                <div id="tag_label_transact_Src">
                                    From Date</div>
                            </td>
                            <td style="width: 140px;">
                                <div id="txtcon-m_src">
                                    <asp:TextBox ID="txtFromDate" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromDate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </td>
                            <td style="width: 80px;">
                                <div id="tag_label_transact_Src">
                                    Section Code</div>
                            </td>
                            <td style="width: 170px;">                                
                                <div id="txtcon-m_src">
                                    <asp:DropDownList ID="ddlSectionCode" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                        Width="150px" Height="24px">
                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                        <asp:ListItem Text="192B" Value="192B"></asp:ListItem>
                                        <asp:ListItem Text="194A" Value="194A"></asp:ListItem>
                                        <asp:ListItem Text="194B" Value="194B"></asp:ListItem>
                                        <asp:ListItem Text="194C" Value="194C"></asp:ListItem>
                                        <asp:ListItem Text="194D" Value="194D"></asp:ListItem>
                                        <asp:ListItem Text="194H" Value="194H"></asp:ListItem>
                                        <asp:ListItem Text="194I" Value="194I"></asp:ListItem>
                                        <asp:ListItem Text="194Ia" Value="194Ia"></asp:ListItem>
                                        <asp:ListItem Text="194J" Value="194J"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <%----------------------------row 2-------------------%>
                        <tr style="height: 25px;">
                            <td style="width: 100px;">
                                <div id="tag_label_transact_Src">
                                    Type</div>
                            </td>
                            <td style="width: 155px;">
                                <div id="txtcon-m_src">
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                        Width="155px" Height="24px">
                                        <asp:ListItem Text="Summary" Value="Summary"></asp:ListItem>
                                        <asp:ListItem Text="Detail" Value="Detail"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="width: 90px;">
                                <div id="tag_label_transact_Src">
                                    To Date</div>
                            </td>
                            <td style="width: 140px;">
                                <div id="txtcon-m_src">
                                    <asp:TextBox ID="txtToDate" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtToDate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </td>
                            <td style="width: 60px;">
                                <div id="tag_label_transact_Src">
                                    Status</div>
                            </td>
                            <td style="width: 155px;">
                                <div id="txtcon-m_src">
                                    <asp:DropDownList ID="ddlOptions" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                        Width="155px" Height="24px">
                                        <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                        <asp:ListItem Text="Un-Paid" Value="Unpaid"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <%----------------------------row 3-------------------%>
                        <tr style="height: 25px;">
                            <td style="width: 100px;">
                                <div id="tag_label_transact_Src">
                                    Org Type</div>
                            </td>
                            <td style="width: 155px;">
                                <div id="txtcon-m_src">
                                    <asp:DropDownList ID="ddlBasis" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                        Width="150px" Height="24px">
                                        <asp:ListItem Text="ALL" Value=" "></asp:ListItem>
                                        <asp:ListItem Text="Organisation" Value="Og"></asp:ListItem>
                                        <asp:ListItem Text="Non-Organisation" Value="NOg"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="width: 320px; margin-top: 2px;">
                                <div id="txtcon-m_src" style="position: absolute; left: 535px;">
                                    <asp:DropDownList ID="ddl_org_name" runat="server" Width="340px" CssClass="validate[required] chosen-select"
                                        Style="margin-top: 2px;" data-placeholder="Choose a Org. Name">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <%----------------------------row 4-------------------%>
                        <tr style="height: 25px;">
                            <td colspan="6">
                                <div style="text-align: left; padding-top: 5px;">
                                    <asp:LinkButton ID="lnkClear" runat="server" CssClass="link-button" OnClientClick="return resetFields();">Clear</asp:LinkButton>
                                    &nbsp;|&nbsp; &nbsp;
                                    <asp:Button ID="btnGenerate" runat="server" Text="Generate" CssClass="btn btn-primary"
                                        OnClick="btnGenerate_Click" Style="padding: 4px 10px; width: 110px;" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="innerbox_MidMain_Grid" style="margin-top: -13px; width: 1450px;">
                    <div id="wrapSummary" runat="server" class="grid-scroll-wrapper">
                        <asp:GridView runat="server" ID="gvSummary" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                            BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvSummary_RowCreated"
                            Width="100%" ShowHeaderWhenEmpty="True" ShowFooter="true" AllowPaging="true"
                            OnRowDataBound="gvSummary_RowDataBound" AllowSorting="true" BorderColor="#C8C8C8"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="0" 
                            onsorting="gvSummary_Sorting">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:CommandField>
                                <asp:BoundField DataField="OrganizationDeducteeName" HeaderText="Organization / Deductee Name" SortExpression="OrganizationDeducteeName">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeducteeTAN" HeaderText="Deductee TAN">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeducteePAN" HeaderText="Deductee PAN">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TaxableAmountINR" HeaderText="Taxable Amount (INR)">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_right" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TDSCode" HeaderText="TDS Code">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TDSSectionCode" HeaderText="TDS Section Code">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TDSPercent" HeaderText="TDS %">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_right" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TDSAmountINR" HeaderText="TDS Amount (INR)">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_right" Width="120px" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                    </div>
                    <%------------------------------------------------------GRID FOR DETIALS---------------------------------------------------%>
                    <div id="wrapDetails" runat="server" class="grid-scroll-wrapper">
                        <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                            BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                            Width="100%" ShowHeaderWhenEmpty="True" ShowFooter="true" AllowPaging="true"
                            OnRowDataBound="gvdetails_RowDataBound" AllowSorting="true" BorderColor="#C8C8C8"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="0" 
                            onsorting="gvdetails_Sorting">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:CommandField>
                                <asp:BoundField DataField="EntryDate" HeaderText="Entry Date">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_center" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrganizationDeducteeName" HeaderText="Organization / Deductee Name" SortExpression="OrganizationDeducteeName">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrgType" HeaderText="Org Type">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_center" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TRANS_NO" HeaderText="Transaction No">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeducteeTAN" HeaderText="Deductee TAN">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeducteePAN" HeaderText="Deductee PAN">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VENDOR_REF_NO" HeaderText="Vendor Ref No.">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VENDOR_REF_DATE" HeaderText="Vendor Ref Date">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_center" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VendorBillAmount" HeaderText="Vendor Bill Amount (INR)">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_right" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TAXABLE_AMOUNT" HeaderText="Taxable Amount (INR)">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_right" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NON_TAXABLE_EXEMPT_AMOUNT" HeaderText="Non Taxable / Exempt Amount (INR)">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_right" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GST_AMOUNT" HeaderText="GST Amount (INR)">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_right" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TDSSectionCode" HeaderText="TDS Section Code">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_left" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TDSPercent" HeaderText="TDS %">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_right" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TDSAmount" HeaderText="TDS Amount (INR)">
                                    <HeaderStyle CssClass="column_style_header" />
                                    <ItemStyle CssClass="column_style_right" Width="120px" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                    </div>
                </div>
                <%--</div>--%>
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
            document.getElementById("downloadFrame").src = "ACC_TDS_Payable.aspx?Payable=1&type=" + encodeURIComponent(type);

            // stop loader after download starts
            setTimeout(function () {
                document.getElementById("load").style.display = "none";
            }, 2000);
        }
    </script>
    <script type="text/javascript">
        function resetFields() {

            document.getElementById("<%= ddlLocation.ClientID %>").selectedIndex = 0;
            document.getElementById("<%= ddlType.ClientID %>").selectedIndex = 0;
            document.getElementById("<%= ddlSectionCode.ClientID %>").selectedIndex = 0;
            document.getElementById("<%= ddlOptions.ClientID %>").selectedIndex = 0;
            document.getElementById("<%= ddlBasis.ClientID %>").selectedIndex = 0;

            var today = new Date();
            var firstDay = new Date(today.getFullYear(), today.getMonth(), 1);
            var lastDay = new Date(today.getFullYear(), today.getMonth() + 1, 0);

            function formatDate(dt) {
                var day = ("0" + dt.getDate()).slice(-2);
                var month = ("0" + (dt.getMonth() + 1)).slice(-2);
                var year = dt.getFullYear();
                return day + "/" + month + "/" + year;
            }

            document.getElementById("<%= txtFromDate.ClientID %>").value = formatDate(firstDay);
            document.getElementById("<%= txtToDate.ClientID %>").value = formatDate(lastDay);

            $("#<%= ddl_org_name.ClientID %>").val("").trigger("chosen:updated");

            $("#<%= gvSummary.ClientID %>").hide();
            $("#<%= gvdetails.ClientID %>").hide();

            return false;   // Prevent postback
        }

    </script>
</body>
</html>
