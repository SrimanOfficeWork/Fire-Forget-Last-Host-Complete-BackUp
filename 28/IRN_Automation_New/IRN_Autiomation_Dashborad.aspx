<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IRN_Autiomation_Dashborad.aspx.cs"
    MasterPageFile="../Import_MasterPage/eRoyalMasters.master" Inherits="IRN_Autiomation_Dashborad" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script src="../js/Billing/Charge.js" type="text/javascript"></script>--%>
    <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .space
        {
            padding-left: 20%;
            height: 15px;
            width: 12px;
            vertical-align: middle;
        }
        
        .space_2
        {
            padding-left: 20%;
            height: 16px;
            width: 14px;
            vertical-align: middle;
        }
        .statusColumn
        {
            border-right: 1px solid #ccc !important;
            border-left: 1px solid #ccc !important;
        }
        .gridHover td
        {
            background-color: #FFF4C2 !important; /* light yellow highlight */
            font-weight: bold;
        }
          /* ===== Info (i) Button Style ===== */
        .btn-info-guide
        {
            display: inline-block;
            width: 18px;
            height: 18px;
            line-height: 18px;
            text-align: center;
            border-radius: 50%;
            background-color: #1a6dcc;
            color: #ffffff !important;
            font-size: 11px;
            font-weight: bold;
            font-style: italic;
            font-family: Georgia, serif;
            text-decoration: none !important;
            cursor: pointer;
            margin-left: 6px;
            vertical-align: middle;
            border: 1px solid #1455a4;
            box-shadow: 0 1px 3px rgba(0,0,0,0.25);
            transition: background-color 0.2s ease;
        }
        .btn-info-guide:hover
        {
            background-color: #0a3d8f !important;
            color: #ffffff !important;
            text-decoration: none !important;
        }
        /* ===== Info (i) Button &#8212; Top toolbar (beside Generate IRN) ===== */
        .btn-info-guide-top
        {
            display: inline-block;
            width: 26px;
            height: 26px;
            line-height: 26px;
            text-align: center;
            border-radius: 50%;
            background-color: #1a6dcc;
            color: #ffffff !important;
            font-size: 13px;
            font-weight: bold;
            font-style: italic;
            font-family: Georgia, serif;
            text-decoration: none !important;
            cursor: pointer;
            border: 1px solid #1455a4;
            box-shadow: 0 1px 3px rgba(0,0,0,0.25);
        }
        .btn-info-guide-top:hover
        {
            background-color: #0a3d8f !important;
            color: #ffffff !important;
            text-decoration: none !important;
        }
    </style>
    <div>
        <div id="innerbox_MidMain_Grid" style="height: 100px;">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 220px;">
                    IRN Automation Dashboard</div>
                <div id="tag_srcinner_rght_Single_line" style="width: 340px; margin-top: 1px; display: flex;">
                    <!-- SEARCH BUTTON -->
                    <div style="padding-top: 0px; width: 45px; text-align: center;">
                        <asp:ImageButton ID="btnSearch" runat="server" Height="26px" Width="30px" ToolTip="Search"
                            ImageUrl="~/images/icons/search_IRN.png" OnClientClick="page_Loading();" OnClick="btnSearch_Click" />
                        <div style="font-size: 11px; margin-top: 2px;">
                            Search</div>
                    </div>
                    <!-- CANCEL BUTTON -->
                    <div style="padding-top: 0px; width: 45px; text-align: center;">
                        <asp:ImageButton ID="btnCancel" runat="server" Height="26px" Width="30px" ToolTip="Cancel / Back"
                            ImageUrl="~/images/icons/cancel_IRN.png" PostBackUrl="~/LoginPage/E_royal_Impex_Main.aspx" />
                        <div style="font-size: 11px; margin-top: 2px;">
                            Cancel</div>
                    </div>
                    <!-- DELETE BUTTON -->
                    <div style="padding-top: 0px; width: 45px; text-align: center;">
                        <asp:ImageButton ID="btnDelete" runat="server" Height="26px" Width="30px" ToolTip="Delete"
                            ImageUrl="~/images/icons/delete_IRN.png" OnClientClick="return AskDelete();"
                            OnClick="btnDelete_Click" />
                        <div style="font-size: 11px; margin-top: 2px;">
                            Delete</div>
                        <!-- Hidden LinkButton -->
                        <asp:LinkButton ID="lnkDoDelete" runat="server" OnClick="btnDelete_Click" Style="display: none;">Delete</asp:LinkButton>
                    </div>
                    <!-- IRN GENERATE BUTTON -->
                    <div id="Div_IRN_btn_New" runat="server" style="width: 70px; height: 26px; display: none;
                        padding-top: 0px; text-align: center;">
                        <asp:ImageButton ID="btnBulk" runat="server" Height="26px" Width="30px" ToolTip="Generate IRN"
                            ImageUrl="~/images/icons/irn.png" OnClientClick="return CallBulk();" />
                        <div style="font-size: 11px; margin-top: 2px;">
                            Generate IRN</div>
                    </div>
                     <!-- USER GUIDE INFO BUTTON (beside Generate IRN) -->
                    <div style="padding-top: 0px; width: 45px; text-align: center;">
                        <div style="width: 30px; height: 26px; margin: 0 auto; margin-left:18px; display: flex; align-items: center; justify-content: center;">
                            <a href="javascript:void(0)"
                                class="btn-info-guide-top"
                                onclick="ShowUserGuide();"
                                title="View IRN User Guide">i</a>
                        </div>
                        <div style="font-size: 11px; margin-top: 2px; width:70px">
                            User Guide</div>
                    </div>
                </div>
            </div>
            <div id="tag_Exchange_inner" style="width: 1038px; height: 75px; margin-top: 21px;">
                <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_transact_lft_in1" style="width: 1071px">
                        <div id="txt_container_Transact_Main_l" style="width: 270px">
                            <div id="tag_label_transact_Src" style="width: 55px">
                                &nbsp; Job No</div>
                            <div id="txtcon-m_transaction_code" style="width: 220px; position: absolute; margin-left: 60px;
                                margin-top: -3px;">
                                <asp:DropDownList ID="ddlJobno" runat="server" class="chosen-select-deselect" Style="width: 200px;"
                                    data-placeholder="Choose a JobNo" TabIndex="1" onchange="load_IMP_EXP();">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width: 180px">
                            <div id="tag_label_transact_Src" style="width: 70px">
                                &nbsp; Job Type</div>
                            <div id="txtcon-m_Exchange" style="width: 100px">
                                <asp:DropDownList ID="ddljobtype" runat="server" MaxLength="20" Width="100px" Height="22px"
                                    Font-Size="12px">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Import" Value="I"></asp:ListItem>
                                    <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width: 190px">
                            <div id="tag_label_transact_Src" style="width: 80px">
                                &nbsp; IRN Status</div>
                            <div id="txtcon-m_Exchange" style="width: 100px">
                                <asp:DropDownList ID="ddlstatus" runat="server" MaxLength="20" Width="100px" Height="22px"
                                    Font-Size="12px">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="In Progress" Value="In Progress..."></asp:ListItem>
                                    <asp:ListItem Text="Success" Value="Success."></asp:ListItem>
                                    <asp:ListItem Text="Failed" Value="Failed."></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 400px; height: 25px; margin-top: 4px;
                            margin-left: 9px">
                            <div id="tag_label_transact_Src" style="width: 70px; margin-top: 3px">
                                From Date</div>
                            <div id="txtcon-m_transaction_code" style="width: 110px">
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
                            <div id="tag_label_transact_Src" style="width: 60px; margin-top: 3px">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px">
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
                        </div>
                    </div>
                </div>
                <%--  <div id="tag_srcinner_rght_Single_line" style="width: 261px;">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu icon-btn icon-searchIRN" id="btnSearch" runat="server" title="Search"
                            onclick="page_Loading();" onserverclick="btnSearch_Click" tabindex="10"></a>
                        <br />
                        <br />
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Main.aspx" CssClass="btn-cancel-text" tabindex="11" target="_top">
                        </a>
                    </div>
                    <div id="editbu">
                        <div id="Divdel">
                            <asp:Button ID="btnDelete" runat="server" CssClass="dlete icon-btn icon-delete" UseSubmitBehavior="false"
                                title="Delete" OnClientClick="return AskDelete();" />
                            <asp:LinkButton ID="lnkDoDelete" runat="server" OnClick="btnDelete_Click" Style="display: none;">Delete</asp:LinkButton>
                        </div>
                    </div>
                    <div id="Div_IRN_btn_New" runat="server" style="width: 120px; height: 26px; display: none;">
                        <div id="Div_IRN_btn_new">
                            <asp:Button ID="btnBulk" runat="server" title="Generate IRN" CssClass="icon-btn icon-irn"
                                Text="" OnClientClick="return CallBulk();" />
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
        <div id="innerbox_MidMain_Grid">
            <div class="pagination" id="Div_Pagination" runat="server" style="margin-top: -6px;">
                <div id="tag_label_transaction_popup_IGM_Container">
                    Page No.</div>
                <div id="txtcon-m_transaction_list1_fcl">
                    <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                        OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <span class="disabled">
                    <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>
                <span class="disabled">
                    <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
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
            <div id="tag_transact_lft_in1" style="margin-top: 12px; width: 1035px; margin-left: 6px;">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="SL_NO,JOBNO,CLIENT_NAME,Guidid,JobType"
                    AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true"
                    PageSize="23" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True"
                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="CheckAll(this)" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="JOBNO" HeaderText="Job No">
                            <ItemStyle CssClass="statusColumn" Width="90px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GENERATED_ON" HeaderText="Generated on" DataFormatString="{0:DD/MM/YYYY}">
                            <ItemStyle CssClass="statusColumn" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name">
                            <ItemStyle CssClass="column_style_left5" Width="150px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JobType" HeaderText="Job Type">
                            <ItemStyle CssClass="statusColumn" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IRN_STATUS" HeaderText="IRN Status">
                            <ItemStyle CssClass="statusColumn" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Guidid" HeaderText="Guid Id">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <a href="javascript:void(0)" onclick="OpenBulkWindow('<%# Eval("JOBNO") %>', '<%# Eval("JobType") %>', '<%# Eval("Guidid") %>');"
                                    style="color: purple !important; font-weight: bold;">View </a>
                            </ItemTemplate>
                            <ItemStyle Width="90px" Font-Size="12px" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }

        }

        function CheckAll(headerCheckBox) {
            var grid = document.getElementById('<%= gvdetails.ClientID %>');
            var inputs = grid.getElementsByTagName("input");

            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox" && inputs[i].id.indexOf("chkSelect") >= 0) {
                    inputs[i].checked = headerCheckBox.checked;
                }
            }
        }

        function AskDelete() {

            jQuery('#form1').validationEngine('hideAll');

            jConfirm('Delete this Job?', 'IRN Details', function (r) {
                if (r === true) {
                    document.getElementById('<%= lnkDoDelete.ClientID %>').click();
                }
            });

            return false; // prevent default postback
        }
        function OpenBulkWindow(jobno, jobType, guidid) {
            w = '1150';
            h = '680';
            var jobno = '0';
            var Jobtype = jobType;
            var guidid = guidid;
            LeftPosition = (screen.width) ? (screen.width - w) / 3 : 0;
            TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
            settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
            adcodewindow = dhtmlmodal.open('IRN Automation', 'iframe', '../IRN_Automation_New/IRN_Autiomation_General.aspx?JOBID=' + jobno + '&Jobtype=' + Jobtype + '&guidid=' + guidid + '', '', settings)
        }
        function CallBulk() {
            var ddl = document.getElementById('<%= ddlJobno.ClientID %>');
            var jobnoText = ddl.options[ddl.selectedIndex].text;
            var splitValues = jobnoText.split("-");
            var jobno = splitValues[0].trim();
            var GuidId = '';
            var jobType = document.getElementById('<%= ddljobtype.ClientID %>').value;
            OpenBulkWindow(jobno, jobType, GuidId);
            return false;
        }

        function load_IMP_EXP() {

            var ddl = document.getElementById('<%= ddlJobno.ClientID %>');
            var jobnoText = ddl.options[ddl.selectedIndex].text;

            var splitValues = jobnoText.split("-");
            var cleanValue = splitValues[1].trim();

            document.getElementById('<%= ddljobtype.ClientID %>').value = cleanValue;
        }
        // ===================================================
        // NEW FUNCTION: Opens the IRN Automation User Guide
        // PDF in a new browser tab.
        //
        // >> IMPORTANT: Update the path below to match the
        //    actual location of the PDF on your web server.
        //    Example paths:
        //      '../Docs/IRN_Automation_UserGuide.pdf'
        //      '../Downloads/IRN_Automation_1_3_1.pdf'
        //      '/Content/Manuals/IRN_Automation_1_3_1.pdf'
        // ===================================================
        function ShowUserGuide() {
            var pdfPath = '../IRN_Automation_New/Docs/IRN_Automation.pdf'; // <-- UPDATE THIS PATH
            window.open(pdfPath, '_blank');
        }

    </script>
</asp:Content>
