<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_Flat_File_Generation.aspx.cs"
    MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Transaction_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .custom-alert
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1000; /* Sit on top */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        .alert-content
        {
            background-color: #fefefe;
            margin: 15% auto; /* 15% from the top and centered */
            padding: 20px;
            border: 1px solid #888;
            width: 80%; /* Could be more or less, depending on screen size */
            border-radius: 8px;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            position: relative;
        }
        .close-button
        {
            color: #aaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }
        .close-button:hover, .close-button:focus
        {
            color: black;
            text-decoration: none;
            cursor: pointer;
        }
        .ok-button
        {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin-top: 15px;
            text-align: center;
        }
        .toast
        {
            visibility: hidden;
            min-width: 250px;
            background-color: #333;
            color: #fff;
            text-align: center;
            padding: 16px;
            border-radius: 8px;
            position: fixed;
            z-index: 9999;
            right: 20px;
            top: 20px;
            font-size: 15px;
            opacity: 0;
            transition: opacity 0.6s, top 0.6s;
        }
        .toast.show
        {
            visibility: visible;
            opacity: 1;
            top: 40px;
        }
        .msgBox
        {
            display: none;
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background: #444;
            color: white;
            padding: 20px;
            border-radius: 10px;
            font-size: 18px;
            box-shadow: 0px 4px 12px rgba(0,0,0,0.3);
        }
        ..assessContainer, .dutyContainer
        {
            position: relative;
            display: inline-block;
        }
        .valueBox
        {
            padding: 4px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-weight: bold;
            transition: 0.2s ease-in-out;
        }
        .greenShadow
        {
            border: 2px solid #28a745 !important;
            box-shadow: 0 0 6px rgba(40, 167, 69, 0.7);
        }
        .redShadow
        {
            border: 2px solid #dc3545 !important;
            box-shadow: 0 0 6px rgba(220, 53, 69, 0.7);
        }
        .smallMessage
        {
            position: absolute;
            left: 845px;
            top: 60px;
        }
        .smallMessageduty
        {
            position: absolute;
            left: 845px;
            top: 107px;
        }
        .msgGreen
        {
            color: #155724;
            background-color: #d4edda;
        }
        .msgRed
        {
            color: #721c24;
            background-color: #f8d7da;
        }
        .msgClose
        {
            margin-left: 6px;
            cursor: pointer;
            font-weight: bold;
        }
        .msgClose:hover
        {
            opacity: 0.6;
        }
        /* =========================================================
           Import Submission - SINGLE VERTICAL SCROLL VIEWPORT
           Starts at Importer and contains all controls through gv_Details.
           The legacy page uses many floated DIVs, so the inner content
           must establish a formatting context for its real height.
           ========================================================= */#tag_srcinner2
        {
            width: 950px !important;
            height: auto !important;
            max-height: none !important;
            overflow: visible !important;
            box-sizing: border-box;
            margin-top: 0 !important;
            padding-top: 0 !important;
        }
        /* Empty spacer div that used to sit above the toolbar row before it was moved
           inside the scroll area -- now it's the very first thing inside tag_srcinner2,
           right before that scroll area, and any height/margin the external stylesheet
           gives it (it's never had any content) just adds to the empty gap above the
           panel's visible content. Confirmed to appear only once in this file. */#tag_transac_lft_Checklist
        {
            height: 0 !important;
            min-height: 0 !important;
            margin: 0 !important;
            padding: 0 !important;
        }
        /* Top toolbar row (Imp. Submission / Job No / Validated File? / Generate / Cancel)
           was wrapping the Generate and Cancel buttons onto a second line -- the row's
           floated children needed more width than the container (styled by the external
           stylesheet, not visible here) was allowing. overflow: visible specifically so
           this wider child isn't clipped by whatever width the external CSS gives this
           parent. margin-top/padding-top added later to close the empty gap between the
           tab bar above this panel and this content -- same reasoning as the width fix:
           whatever spacing the external stylesheet gives this element by default, pulled
           back to zero here. This id is confirmed to appear only once in this file, so
           this rule can't affect any other, unrelated element the way tag_srcinner1's
           reused id would have. */#innerbox_MidMain_Grid
        {
            width: auto !important;
            max-width: none !important;
            overflow: visible !important;
            margin-top: 0 !important;
            padding-top: 0 !important;
        }
        #importSubmissionScrollArea
        {
            display: block !important;
            position: relative !important; /* Main panel in this legacy page is about 860px wide.
               Keep the scrollbar INSIDE that panel. */
            width: 850px !important;
            height: 420px !important;
            max-height: 420px !important;
            min-height: 420px !important;
            overflow-y: scroll !important;
            overflow-x: hidden !important;
            box-sizing: border-box !important;
            margin: 0 !important;
            padding: 0 14px 12px 0 !important;
            scrollbar-width: auto !important;
            scrollbar-gutter: stable !important;
        }
        /* Force a visible scrollbar on Chrome/Edge even if the old
           master-page CSS tries to hide native scrollbars. */#importSubmissionScrollArea::-webkit-scrollbar
        {
            width: 14px !important;
            height: 14px !important;
            display: block !important;
        }
        #importSubmissionScrollArea::-webkit-scrollbar-track
        {
            background: #e6e6e6 !important;
            border-left: 1px solid #b5b5b5 !important;
        }
        #importSubmissionScrollArea::-webkit-scrollbar-thumb
        {
            background: #888 !important;
            border: 2px solid #e6e6e6 !important;
            border-radius: 6px !important;
            min-height: 40px !important;
        }
        #importSubmissionScrollArea::-webkit-scrollbar-thumb:hover
        {
            background: #555 !important;
        }
        #pop_text_area_transac_popup_inn_container_left_IGM
        {
            display: flow-root !important;
            position: relative !important;
            width: 820px !important;
            max-width: 820px !important;
            height: auto !important;
            min-height: 0 !important;
            overflow: visible !important;
            box-sizing: border-box !important;
            margin: 0 !important;
            padding: 0 !important;
        }
        /* Make sure the legacy floated controls contribute to the
           scrollable content height. */#pop_text_area_transac_popup_inn_container_left_IGM::after
        {
            content: "" !important;
            display: table !important;
            clear: both !important;
        }
        /* Do not create a second scrollbar around the item grid. */#tag_transac_lft_Item_maindet_Grid_area
        {
            width: 820px !important;
            max-width: 820px !important;
            height: auto !important;
            max-height: none !important;
            overflow: visible !important;
            box-sizing: border-box !important;
            margin-left: 0 !important;
        }
        #tag_transac_lft_Item_maindet_Grid_area .grid-view
        {
            width: auto;
            max-width: 100%;
        }
        /* Keep the DSC section inside the same viewport. */#dscSigningFieldset
        {
            width: 800px !important;
            max-width: 800px !important;
            box-sizing: border-box !important;
        }
        /* Keep the widest existing legacy rows within the viewport. */#pop_text_area_transac_popup_inn_container_left_IGM > div[id="tag_transac_lft_IGM_in1"]
        {
            max-width: 820px;
            box-sizing: border-box;
        }
        /* Prevent the 1051px spacer from creating an oversized child. */#innerbox_MidMain_Trans
        {
            max-width: 100% !important;
            width: 100% !important;
            box-sizing: border-box !important;
            margin-left: 0 !important;
        }
    </style>
    <script type="text/javascript">

        function showCustomAlert1(title, message) {
            document.querySelector('#customAlert h2').innerText = title;
            document.querySelector('#customAlert p').innerText = message;
            document.getElementById('customAlert').style.display = 'block';
        }

        function showToast(msg) {
            var toast = document.getElementById("toast");
            toast.innerHTML = msg;
            toast.className = "toast show";
            setTimeout(function () {
                toast.className = toast.className.replace("show", "");
            }, 3000); // 3 seconds
        }

        function showMessage(msg) {
            var box = document.getElementById("msgBox");
            box.innerHTML = msg;
            box.style.display = "block";

            setTimeout(function () {
                box.style.display = "none";
            }, 3000);
        }


        function open_jobno() {

            if (document.getElementById('ddlJobNo').value != 'Select') {
                document.getElementById('HiddenField1').value = document.getElementById('ddlJobNo').value;
                if (document.getElementById('HiddenField1').value != '') {
                    var f = document.getElementById('HiddenField1').value;
                    opennew_Import_report(f);
                    return false
                    //alert(f);
                }
            }
        }

        window.onload = happycode;
        window.onload = happycode1;

        function happycode() {

            document.getElementById("Import_Id").className = 'smenuactive';
            document.getElementById("Transaction_Id").click();

        }
        function happycode1() {

            var qs = query.get('jobno');

            if (qs.length >= 0) {

                $('#<%= HiddenField1.ClientID %>').val(qs);
                CallServerside_Importer1(qs, $('#<%= txtCustomHouse.ClientID %>').val());
            }
        }
        function openurl(url) {
            var a = $('#<%= HiddenField1.ClientID %>').val();

            if (a.length == 0) {
                window.location.href = url;

            }
            else {
                Child_Parent_close_button1('General'); return false;
            }
        }
        function CallServerside_Importer1(src, dest) {
            Loading_ShowImage();

            // call server side method

            PageMethods.Get_Import_Details(src, CallSuccess_Importer, CallFailed, dest);

        }

        function Loading() {
            Loading_HideImage();
        }
    </script>
    <script type="text/javascript">
        function Child_Parent_close_button1_Trigger_AnotherPage1(val, pagename) {
            window.parent.close_button_Trigger_AnotherPage(val, pagename);
        }

        function close_button_Trigger_AnotherPage(val, pagename) {
            document.getElementById("hdn_source").value = pagename;
            document.getElementById(val).click();
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            // document.onkeydown = clickRadio;
            document.onkeypress = click_TABS;
            document.onkeyup = click_TABS;

            function click_TABS(e) {
                //if (window.event);
                if (window.event.ctrlKey)
                    var keyCode = window.event.keyCode;       // IE
                else
                    var keyCode = e.which;

                if (e.ctrlKey) {
                    if (keyCode == 39) {

                        document.getElementById("hdn_source").value = 'Tab_Submission';
                        document.getElementById('btnCancel').click();
                    }
                    if (keyCode == 37) {

                        document.getElementById("hdn_source").value = 'Tab_Submission_Prev';
                        document.getElementById('btnCancel').click();
                    }
                }
            }
        });
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            var icegateid = document.getElementById("hdn_ICEGATE_ID_List").value;
            //var Notn = icegateid.split(',').map(String);
            var Notn = icegateid.split(', ').map(String);

            if (icegateid != '') {
                $('#txt_icegate_Id').autocomplete({
                    source: Notn,
                    minLength: 0,
                    scroll: true
                }).focus(function () {
                    $(this).autocomplete("search", "");
                });
            }
        });
    </script>
    <script type="text/javascript">

        function HideModalPopup_Job() {
            $find("MP_U").hide();
            return true;
        }
    </script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div id="innerbox_MidMain_Grid">
                <div id="tag_srcinner2">
                    <div id="tag_transac_lft_Checklist">
                    </div>
                    <!-- START: Complete vertical scroll area from Importer through gv_Details -->
                    <div id="importSubmissionScrollArea">
                        <%-- Toolbar row (Imp. Submission / Job No / Validated File? / Generate / Cancel)
                             moved inside this scroll area, as its first item, after two earlier
                             attempts at widening the outer containers around it (tag_srcinner1 itself,
                             then innerbox_MidMain_Grid, then the master page's own "maincontent"
                             wrapper) all failed to actually fit Cancel within the visible panel.
                             Moving it here means it shares the exact same, already-proven 850px width
                             constraint as every other control in this panel, rather than depending on
                             an outer container whose real width this file has no visibility into.
                             Labels compacted to fit within 820px (the same width already used
                             repeatedly elsewhere in this scroll area -- see the embedded style block
                             above), with its own overflow-x: auto as a fallback in case that estimate
                             still runs slightly over: a small horizontal scroll on just this one row
                             rather than a clipped Cancel button.

                             Trade-off worth knowing: this toolbar no longer stays fixed at the top
                             while scrolling through Importer/Supplier/etc. below -- it now scrolls
                             out of view along with everything else in this same viewport, the same
                             as every other control here. If Job No or Generate needs to stay visible
                             while scrolling further down, that's a different, larger change than what
                             was asked for here. --%>
                        <div id="tag_srcinner1" style="margin-left: 0px; width: 820px;
                            position: sticky; top: 0; z-index: 10; background-color: #ffffff;
                            padding-bottom: 10px; box-shadow: 0 2px 3px -2px rgba(0,0,0,0.15);
                            margin-bottom: 18px;">
                            <div id="toolbarRow1" style="overflow: hidden; white-space: nowrap;">
                                <div id="mainmastop2container_rght_tag2_txt1" style="width: 90px;">
                                    Imp. Submission</div>
                                <div id="verslic" style="width: 8px;">
                                </div>
                                <div id="mainmastop2container_rght_tag2_txt1" style="width: 45px; color: Black;">
                                    Job No</div>
                                <div id="mainmastop2container_rght_tag2_txt1" style="width: 130px;">
                                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" Width="125px"
                                        TabIndex="1">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <span runat="server" id="F_Validate">
                                    <div id="verslic" style="width: 8px;">
                                    </div>
                                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 95px;">
                                        Validated File ?
                                    </div>
                                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                                        <asp:RadioButtonList ID="Rdhelp" runat="server" RepeatDirection="Horizontal" TabIndex="2">
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 55px;">
                                        <span id="lblQuickview" title="All" runat="server" onclick="Flat_File_Validation();return false;"
                                            tabindex="3 " style="color: Blue; text-decoration: underline; cursor: hand; font-size: smaller;">
                                            Quick View</span>
                                    </div>
                                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px;">
                                        <span id="Span1" title="All" runat="server" onclick="Flat_File_Validation_Spl_Char();return false;"
                                            style="color: Blue; text-decoration: underline; cursor: hand; font-size: smaller;">
                                            Spl. Char</span>
                                    </div>
                                </span>
                            </div>
                            <!-- Generate and Cancel together on their own row below, right-aligned --
                                 simpler than splitting them across two rows (no cross-row alignment
                                 to guess at), and this row alone -- just two buttons -- comfortably
                                 fits within 820px regardless of where it sits. -->
                            <div id="toolbarRow2" style="clear: both; white-space: nowrap; margin-top: 10px;
                                text-align: right; width: 820px; box-sizing: border-box;">
                                <div id="editbu" class="padding" style="display: inline-block; float: none;">
                                    <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClick="btnSearch_Click"
                                        TabIndex="54" />
                                </div>
                                <div id="editbu" class="padding" style="display: inline-block; float: none;">
                                    <%--<a href="#" class="cancelButt" onclick="openurl('../LoginPage/E_royal_Impex_Home.aspx');">
                                    </a>--%>
                                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                                </div>
                            </div>
                        </div>
                        <div style="clear: both; height: 1px;">
                        </div>
                        <div id="pop_text_area_transac_popup_inn_container_left_IGM" style="width: 900px;
                            height: auto;">
                            <div id="tag_transac_lft_IGM_in1" style="width: 320px;">
                                <div id="tag_label_transaction_popup_IGM" style="width: 70px;">
                                    Importer</div>
                                <div id="txtcon_m_transaction_IGM_Airnamenew">
                                    <asp:TextBox ID="txtImporterName" runat="server" MaxLength="50" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_IGM_in1" style="width: 250px;">
                                <div id="tag_label_transaction_popup_IGM">
                                    Filing Location
                                </div>
                                <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                                    <asp:TextBox ID="txtCustomHouse" runat="server" Width="80px" Font-Bold="true" MaxLength="40"
                                        ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_IGM_in1" style="width: 20px;">
                                <div id="assessMainBlock" runat="server" style="display: none">
                                    <div id="tag_label_transaction_popup_IGM" style="font-size: 15px; font-weight: bold;">
                                        Assesable Value
                                    </div>
                                    <%-- <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 0px;">
                              <asp:TextBox ID="txtTotalAssessableValue" style="width:110px;margin-left:-30px;" runat="server" CssClass="valueBox"></asp:TextBox>

                             </div>--%>
                                    <div id="tag_srcinner1" style="margin-left: 0px;">
                                        <asp:TextBox ID="txtTotalAssessableValue" Style="width: 110px; margin-left: 122px;
                                            margin-top: -25px;" runat="server" CssClass="valueBox">
                                    </asp:TextBox>
                                        <span id="msgWrapper" runat="server" style="display: none; margin-left: 5px;" class="smallMessage">
                                            <asp:Label ID="lblAssessMessage" runat="server"></asp:Label>
                                            <span class="msgClose"></span></span>
                                    </div>
                                </div>
                            </div>
                            <%-- <div id="tag_transac_lft_IGM_in1" style="width: 250px;">
                                 <asp:TextBox ID="txtTotalAssessableValue" runat="server" CssClass="valueBox"></asp:TextBox>
                               </div>--%>
                            <%--  <div id="tag_transac_lft_IGM_in1" style="width: 160px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 70px;" >
                               B.E Type </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                                     <asp:TextBox ID="txtBE_Type" runat="server" Font-Bold="true" Width="80px" MaxLength="35"
                                    CssClass="txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>--%>
                            <%--  <div id="tag_transac_lft_IGM_in1" style="width: 160px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 70px;" >
                              Assesable Value </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                                     <asp:TextBox ID="txtBE_Type" runat="server" Font-Bold="true" Width="80px" MaxLength="35"
                                    CssClass="txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        --%>
                            <%--   <div id="tag_transac_lft_IGM_in1" style="width: 160px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 70px;" >
                               Duty Value </div>
                            <div id="Div3" style="width: 80px;">
                                     <asp:TextBox ID="txtBE_Type" runat="server" Font-Bold="true" Width="80px" MaxLength="35"
                                    CssClass="txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>

                        --%>
                            <div id="tag_transac_lft_IGM_in1" style="width: 160px;">
                                <asp:Button ID="btn_Auto_Spl_Char" runat="server" Visible="false" Text="Auto Remove Spl. char(s)"
                                    OnClick="btn_Auto_Spl_Char_Click" />
                            </div>
                            <div id="tag_transac_lft_IGM_in1" style="width: 320px;">
                                <div id="tag_label_transaction_popup_IGM" style="width: 70px;">
                                    Supplier
                                </div>
                                <div id="txtcon_m_transaction_IGM_Airnamenew">
                                    <asp:TextBox ID="txtSupplier" runat="server" MaxLength="50" CssClass="txtbox_none_CheckList"
                                        ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_IGM_in1" style="width: 250px;">
                                <div id="tag_label_transaction_popup_IGM">
                                    No of Invoices</div>
                                <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                                    <asp:TextBox ID="txtNoofInvoices" runat="server" Width="80px" Font-Bold="true" MaxLength="35"
                                        ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_IGM_in1" style="width: 20px;">
                                <div id="dutyMainBlock" runat="server" style="display: none;">
                                    <div id="tag_label_transaction_popup_IGM" style="margin-top: 10px; font-size: 15px;
                                        color: #000000; font-weight: 600;">
                                        Duty Value
                                    </div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 0px;">
                                        <asp:TextBox ID="txtTotalDutyValue" Style="width: 110px; margin-left: -4px; margin-top: 10px;"
                                            runat="server" CssClass="valueBox"></asp:TextBox>
                                    </div>
                                    <span id="msgDutyWrapper" runat="server" style="display: none; margin-left: 5px;"
                                        class="smallMessageduty">
                                        <asp:Label ID="lblDutyMessage" runat="server"></asp:Label>
                                        <span class="msgClose"></span></span>
                                </div>
                            </div>
                            <%--  <div id="tag_transac_lft_IGM_in1" style="width: 160px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 70px;">
                                No of Items </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                                      <asp:TextBox ID="txtNoofItems" runat="server" MaxLength="35" Width="80px" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>--%>
                            <div id="tag_transac_lft_IGM_in1" style="width: 820px; margin-top: 0px;">
                                <div id="tag_transac_lft_IGM_in1" style="width: 160px; margin-left: 320px;">
                                    <div id="tag_label_transaction_popup_IGM" style="width: 70px;">
                                        B.E Type
                                    </div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                                        <asp:TextBox ID="txtBE_Type" runat="server" Font-Bold="true" Style="margin-left: 56px;"
                                            Width="80px" MaxLength="35" CssClass="txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_transac_lft_IGM_in1" style="width: 20px; margin-right: 50px;">
                                <div id="bondMainBlock" runat="server" style="display: none;">
                                    <div id="tag_label_transaction_popup_IGM" style="margin-top: 20px; font-size: 15px;
                                        color: #000000; font-weight: 600; margin-left: -250px;">
                                        Bond Value
                                    </div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 0px;">
                                        <%-- <asp:TextBox ID="txtTotalBondValue"  style="width:110px;margin-left:-130px;margin-top:20px;" runat="server" CssClass="valueBox"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtTotalBondValue" runat="server" TextMode="MultiLine" Style="width: 150px;
                                            height: 60px; margin-left: -130px; margin-top: 20px; overflow-y: scroll; resize: none;"
                                            CssClass="valueBox">
    </asp:TextBox>
                                    </div>
                                    <span id="msgBondWrapper" runat="server" style="display: none; margin-left: 38px;
                                        margin-top: 30px;" class="smallMessageduty">
                                        <asp:Label ID="lblbondMessage" runat="server"></asp:Label>
                                        <span class="msgClose"></span></span>
                                </div>
                            </div>
                            <div id="tag_transac_lft_IGM_in1" style="width: 820px; margin-top: 0px;">
                                <div id="tag_transac_lft_IGM_in1" style="width: 160px; margin-left: 319px;">
                                    <div id="tag_label_transaction_popup_IGM" style="width: 70px;">
                                        No of Items
                                    </div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                                        <asp:TextBox ID="txtNoofItems" runat="server" Style="margin-left: 56px;" MaxLength="35"
                                            Width="80px" Font-Bold="true" ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_transac_lft_IGM_in1" style="width: 820px; margin-top: 0px;">
                                <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 70px;">
                                    Flat file</div>
                                <div id="txtcon_m_transaction_IGM_Airnamenew" style="margin-top: 5px; width: 250px;">
                                    <asp:ImageButton ID="imgbtnFlatFile" runat="server" ImageUrl="~/images/flatfile.jpeg"
                                        Width="50px" Height="40px" OnClientClick="Print_open();Loading();" Visible="False" />
                                    &nbsp;&nbsp; &nbsp;&nbsp;
                                    <asp:Button ID="btnsend_Queue" runat="server" Width="105px" OnClick="btnsend_Queue_Click"
                                        Visible="false" />
                                </div>
                                <div id="txtcon_m_transaction_IGM_Airnamenew" style="margin-top: 5px; width: 250px;">
                                    <div id="small-butt-left" style="width: 107px;">
                                        <asp:Button ID="btnJson" runat="server" CssClass="autowidmovebut" OnClick="btnJson_Click"
                                            CausesValidation="false" UseSubmitBehavior="false" Text="Generate Json" TabIndex="26"
                                            Style="margin-left: -4px; margin-top: 3px; width: 100px;" />
                                    </div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew" style="margin-top: 5px; width: 53px;">
                                        <asp:ImageButton ID="ImagebtnJsonfile" runat="server" ImageUrl="~/images/icons/Json.jpg"
                                            Width="50px" Height="40px" Visible="False" OnClientClick="getjson(); return true;"
                                            OnClick="ImagebtnJsonfile_Click" />
                                    </div>
                                </div>
                                <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 80px;
                                    margin-top: 45px; font-weight: bold;">
                                    Icegate Id
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 150px; margin-top: 45px;">
                                    <asp:TextBox ID="txt_icegate_Id" runat="server" MaxLength="35" Width="145px" Font-Bold="true"
                                        ForeColor="Red" TabIndex="53" ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_code"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_IGM_in1" style="width: 830px; margin-top: 30px;">
                                <%--430px--%>
                                <span style="color: Red; margin-right: 150px;">
                                    <asp:Literal ID="lblsent_date" runat="server"></asp:Literal>
                                </span><span style="color: Red;">
                                    <asp:Literal ID="lbltablename" runat="server"></asp:Literal>
                                </span>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 444px; margin-left: -1px;">
                                <div id="tag_label_transact_Src" style="width: 104px;">
                                    Select a Json
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 340px; margin-left: -18px;">
                                    <asp:FileUpload ID="fileuploadExcel" runat="server" accept="Signed.json" onchange="document.getElementById('btn_upload').click();" />
                                    <asp:Button ID="btn_upload" Text="JSON UPLOAD" OnClick="JSON_IEC_GATE_UPLOAD" runat="server"
                                        OnClientClick="return validateFileName();" />
                                </div>
                            </div>
                            <%--Start of "New DSC - Signing". --%>
                            <div id="dsc_signing_spacer_row" style="clear: both; height: 15px; margin: 0; padding: 0;">
                            </div>
                            <fieldset id="dscSigningFieldset" style="width: 800px; margin-top: 10px; border: 1px solid #b05a00;
                                box-sizing: border-box; font-size: 12px;">
                                <legend style="color: #b05a00; font-size: 12px;">New DSC - Signing </legend>
                                <!-- File picker row: lets the operator sign any supported file type
                                     directly, rather than being limited to the JSON "Generate Json"
                                     produces. Kept as its own row, same layout pattern as the
                                     certificate row below it. -->
                                <div id="dscFileRow" style="display: flex !important; flex-direction: row; flex-wrap: nowrap;
                                    align-items: center; width: 100%; margin: 3px 0 0 0; padding: 0; float: none !important;
                                    box-sizing: border-box;">
                                    <div id="dscFileLabel" style="display: block; width: 130px; min-width: 130px;
                                        margin: 0; padding: 0; float: none !important; line-height: 26px; box-sizing: border-box;
                                        font-size: 12px;">
                                        <span style="color: #b05a00;">File to sign</span>
                                    </div>
                                    <div id="dscFileContainer" style="display: block; width: 340px; min-width: 340px;
                                        margin: 0; padding: 0; float: none !important; box-sizing: border-box;">
                                        <input type="file" id="dscFileSelect" accept=".be,.sb,.json,.pdf"
                                            style="width: 320px; font-size: 11px; box-sizing: border-box;" />
                                    </div>
                                </div>
                                <!-- Single aligned row: label + certificate + Sign & Upload -->
                                <div id="dscSigningRow" style="display: flex !important; flex-direction: row; flex-wrap: nowrap;
                                    align-items: center; width: 100%; margin: 3px 0 0 0; padding: 0; float: none !important;
                                    box-sizing: border-box;">
                                    <div id="dscSigningLabel" style="display: block; width: 130px; min-width: 130px;
                                        margin: 0; padding: 0; float: none !important; line-height: 26px; box-sizing: border-box;
                                        font-size: 12px;">
                                        <span style="color: #b05a00;">Signing certificate</span>
                                    </div>
                                    <div id="dscCertificateContainer" style="display: block; width: 340px; min-width: 340px;
                                        margin: 0; padding: 0; float: none !important; box-sizing: border-box;">
                                        <select id="dscCertSelect" class="txtbox_none_CheckList" style="width: 320px; height: 24px;
                                            margin: 0; padding: 1px 2px; box-sizing: border-box; font-size: 11px;">
                                            <option value="">--Select--</option>
                                        </select>
                                    </div>
                                    <!-- Kept in the DOM because the existing JavaScript references this control. -->
                                    <div id="dscRefreshContainer" style="display: none;">
                                        <input type="button" id="dscRefreshCertsButton" value="Refresh" class="autowidmovebut"
                                            style="width: 100px; font-size: 11px;" />
                                    </div>
                                    <div id="dscSignContainer" style="display: block; width: 107px; min-width: 107px;
                                        margin: 0; padding: 0; float: none !important; box-sizing: border-box;">
                                        <input type="button" id="dscSignAndUploadButton" value="Sign &amp; Upload" class="autowidmovebut"
                                            style="width: 100px; height: 26px; margin: 0; padding: 2px 6px; font-size: 11px;"
                                            disabled="disabled" />
                                    </div>
                                </div>
                                <!-- Status messages start directly below the certificate dropdown -->
                                <div id="dscStatusRow" style="display: flex !important; flex-direction: row; width: 100%;
                                    margin: 2px 0 0 0; padding: 0; float: none !important; box-sizing: border-box;">
                                    <div style="width: 130px; min-width: 130px; margin: 0; padding: 0;">
                                    </div>
                                    <div style="width: 640px; margin: 0; padding: 0; line-height: 13px;">
                                        <div id="dscCertStatus" style="font-size: 10px; color: #666; margin: 0; padding: 0;">
                                        </div>
                                        <div id="dscSignStatus" style="font-size: 10px; margin: 2px 0 0 0; padding: 0;">
                                        </div>
                                        <!-- Only shown for non-JSON signed results (.be/.sb/.pdf), which have
                                             no existing submit path on this page -- JSON results still flow
                                             through fileuploadExcel/btn_upload exactly as before, and never
                                             show this link. -->
                                        <div id="dscDownloadRow" style="display: none; margin: 2px 0 0 0; padding: 0;">
                                            <a id="dscDownloadLink" href="#" style="font-size: 10px;">Download signed file</a>
                                        </div>
                                    </div>
                                </div>
                                <input type="hidden" id="dscBaseUrl" value="<%= Dsc_AgentBaseUrl %>" />
                                <input type="hidden" id="dscInstallUrl" value="<%= Dsc_InstallUrl %>" />
                                <input type="hidden" id="dscToken" value="<%= Dsc_BearerToken %>" />
                            </fieldset>
                            <div id="dsc_signing_bottom_clear" style="clear: both; height: 10px; margin: 0; padding: 0;">
                            </div>
                            <asp:CheckBox ID="chkDummyFlatFile" runat="server" Style="margin-left: -185px;" Text="Dummy Job No"
                                AutoPostBack="true" OnCheckedChanged="chkDummyFlatFile_CheckedChanged" />
                            <asp:TextBox ID="txtDummyJobNo" runat="server" ReadOnly="true" placeholder="Dummy Job No will appear here"
                                CssClass="form-control" Style="margin-left: 0px; display: inline-block; width: 120px;" />
                            <asp:Label ID="lblDummyMsg" runat="server" Style="margin-left: -20px; font-size: 11px;
                                font-weight: normal; white-space: nowrap;"></asp:Label>
                            <%--   <div id="tag_transac_lft_in2" style="margin-top: 30px;">
               <div id="tag_label_transact_Src" style="width: 106px;margin-top:-20px; font-weight:bold;">
                        Upload PDF File</div>
              <div id="txtcon-m_src" style="width: 260px;margin-top:-20px;margin-left:110px;">
                            <asp:FileUpload ID="FilePDF" runat="server"  ForeColor="Blue" TabIndex="2"/>
                        </div>

                        <div id="txtcon-m_src" >
                            <asp:Button ID="Button1" Style="margin-top: -3px; margin-left: 50px" Text="Preview" TabIndex="2"
                                CssClass="autowidupdatebut" runat="server" UseSubmitBehavior="false" OnClick="btnPrevData_Click" />
                        </div>
                        
                        
                        <div id="txtcon-m_src" >
                        <asp:Label ID="lbl_loading" runat="server" ForeColor="Blue"></asp:Label>
                        </div>
                    </div>--%>
                            <%--<asp:TextBox ID="txtTotalAssessableValue" runat="server" CssClass="valueBox"></asp:TextBox>--%>
                            <%--      <asp:TextBox ID="txtTotalDutyValue" runat="server" CssClass="valueBox"></asp:TextBox>--%>
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            <div id="innerbox_MidMain_Trans" style="width: 1051px; height: 5px; margin-top: 25px;
                                margin-left: -25px;">
                            </div>
                            <div id="Div1" style="overflow-y: scroll; overflow-x: hidden; height: 198px; width: 950px;
                                margin-left: -26px;">
                                <div id="tag_transac_lft_Item_maindet_Grid_area" style="width: 100%;">
                                    <asp:GridView ID="gv_Details" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                        CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                                        OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            CssClass="column_style_right" BorderWidth="1px" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <!-- END: pop_text_area_transac_popup_inn_container_left_IGM -->
                    </div>
                    <!-- END: Complete vertical scroll area -->
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:FileUpload ID="fuPDF" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hd_branch" runat="server" />
    <asp:HiddenField ID="hdn_Jobno" runat="server" />
    <asp:HiddenField ID="hdn_source" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_CompanyID" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_ICEGATE_ID_List" runat="server" ClientIDMode="Static" />
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_Job();" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    <div id="msgBox" class="msgBox" style="text-align: center;">
        Your message here</div>
    <div id="customAlert" class="custom-alert" style="text-align: center;">
        <div class="alert-content">
            <h2 style="text-align: center; margin-bottom: 20px;">
                Alert Title</h2>
            <p>
            </p>
            <p>
            </p>
            <button class="ok-button" style="text-align: center">
                OK</button>
        </div>
    </div>
    <script type="text/javascript">
        var win = null;
        function Print_open() {
            //win = window.open('../FlatFile/Open_FileDownload.aspx?IJOBID=' + 'R' + '', 'ndf');
            // Loading_HideImage();

            var paramVal = $('#<%=ddlJobNo.ClientID %> OPTION:selected').val();
            win = window.open("../FlatFile/Open_FileDownload.aspx?IJOBID=" + paramVal + "&IMP_EXP=I");
        }
        $(function () {

            var dropDownList1 = $('#<%= ddlJobNo.ClientID %>');

            dropDownList1.change(function (e) {
                var selectedValue = $(this).val();

                if (selectedValue != '') {
                    document.getElementById('HiddenField1').value = selectedValue;
                }
            });
        });

        function CallServerside_Importer(src, dest) {
            Loading_ShowImage();
            var ctrl = document.getElementById(src);
            PageMethods.Get_Import_Details(ctrl.value, CallSuccess_Importer, CallFailed, dest);
        }

        function CallSuccess_Importer(res, destCtrl) {
            Loading_HideImage();

            var dest = document.getElementById(destCtrl);
            //dest.value = res;
            var data = res;
            if (data.indexOf("~~") != -1) {

                var s = data.split('~~');

                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];
                var after3 = s[3];
                var after4 = s[4];
                var after5 = s[5];
                var after6 = s[6];

                document.getElementById("txtCustomHouse").value = before;
                document.getElementById("txtImporterName").value = after1;
                document.getElementById("txtBE_Type").value = after2;
                document.getElementById("txtSupplier").value = after3;
                document.getElementById("txtNoofItems").value = after4;
                document.getElementById("txtNoofInvoices").value = after5;
                if (after6 != '') {
                    document.getElementById("txt_icegate_Id").value = after6;
                }

                var a = "";
                if (after5 == "")
                    a = 'add Invoice Details';
                if (after4 == "") {
                    a = a + ' and Item Details';
                }
                if (a != "") {
                    document.getElementById("lblmsg").innerHTML = "Please " + a;
                }
                else
                    document.getElementById("lblmsg").innerHTML = "";
            }
            else {

                document.getElementById("txtCustomHouse").value = "";
                document.getElementById("txtImporterName").value = "";
                document.getElementById("txtBE_Type").value = "";
                document.getElementById("txtSupplier").value = "";
                document.getElementById("txtNoofItems").value = "";
                document.getElementById("txtNoofInvoices").value = "";
                //document.getElementById("txt_IcegateId").value = "";

                document.getElementById("lblmsg").innerHTML = "";
            }
        }

        function CallFailed(res, destCtrl) {
        }
    
    </script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Flat_File_Validation() {
            var jobno = document.getElementById("<%=hdn_Jobno.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('IMP_Flatfile_Validation.aspx?Jobno=' + encodeURIComponent(jobno) + '', 'List', '1100', '1024', 'yes');
            }
        }
        function Flat_File_Validation_Spl_Char() {
            var jobno = document.getElementById("<%=hdn_Jobno.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('IMP_Flatfile_Validation_Spl_Char.aspx?Jobno=' + encodeURIComponent(jobno) + '', 'List', '1100', '1024', 'yes');
            }
        }
        function closeAssessMsg() {
            var msg = document.getElementById('<%= msgWrapper.ClientID %>');
            if (msg) msg.style.display = "none";
        }

        //         function closeDutyMsg() {
        //             var msg = document.getElementById('<%= msgDutyWrapper.ClientID %>');
        //             if (msg) msg.style.display = "none";
        //         }

        
    </script>
    <script type="text/javascript">

        function getjson() {

            var jobno = document.getElementById("<%= hdn_Jobno.ClientID %>").value;

            if (!jobno) { alert("Job number not found."); return false; }

            var Ip_Ep = "I";

            var url = "../FlatFile/MIS_report_1.aspx?Imp_Exp_Json=Yes" + "&Jobno=" + encodeURIComponent(jobno) + "&Imp_Exp=" + encodeURIComponent(Ip_Ep);
            window.open(url, "ndf");

            if (typeof Loading_HideImage === "function") { Loading_HideImage(); }

            return false;
        }
    </script>
    <script type="text/javascript">
        function validateFileName() {
            var input = document.getElementById('<%= fileuploadExcel.ClientID %>');
            var fileName = input.value.split('\\').pop();

            if (fileName == "") {
                alert("Please select a file");
                return false;
            }

            if (!fileName.endsWith("Signed.json")) {
                alert("Only Signed.json files allowed");
                return false;
            }

            return true;
        }
</script>
    <script type="text/javascript">
        (function () {
            var dscCertSelect = document.getElementById('dscCertSelect');
            var dscCertStatus = document.getElementById('dscCertStatus');
            var dscRefreshCertsButton = document.getElementById('dscRefreshCertsButton');
            var dscSignAndUploadButton = document.getElementById('dscSignAndUploadButton');
            var dscSignStatus = document.getElementById('dscSignStatus');
            var dscFileSelect = document.getElementById('dscFileSelect');
            var dscDownloadRow = document.getElementById('dscDownloadRow');
            var dscDownloadLink = document.getElementById('dscDownloadLink');

            // "Sign & Upload" must stay disabled until BOTH conditions are true: a file has
            // been picked in dscFileSelect, AND the operator has explicitly picked a specific
            // certificate (leaving it on "Auto" does not count -- consistent with the
            // earlier fix requiring the operator to consciously confirm which certificate
            // is used, rather than silently trusting a server-side default). Replaces the
            // earlier "Generate Json has run" condition -- this file picker lets the operator
            // sign any supported file directly, so it no longer depends on that button having
            // been clicked first.
            function dscUpdateSignButtonState() {
                var fileChosen = dscFileSelect.files.length > 0;
                var certChosen = dscCertSelect.value !== '';
                dscSignAndUploadButton.disabled = !(fileChosen && certChosen);

                if (!fileChosen && !certChosen) {
                    dscSignStatus.textContent = 'Choose a file above and select a certificate first.';
                } else if (!fileChosen) {
                    dscSignStatus.textContent = 'Choose a file to sign above.';
                } else if (!certChosen) {
                    dscSignStatus.textContent = 'Select a certificate above (not "Auto") to enable signing.';
                } else {
                    dscSignStatus.textContent = 'Ready to sign and upload.';
                }
            }

            function dscBaseUrl() { return document.getElementById('dscBaseUrl').value.trim(); }
            function dscToken() { return document.getElementById('dscToken').value.trim(); }
            function dscInstallUrl() { return document.getElementById('dscInstallUrl').value.trim(); }
            function dscJobNo() {
                var el = document.getElementById("<%= hdn_Jobno.ClientID %>");
                return el ? el.value : '';
            }
            function dscExtractCommonName(dn) {
                if (!dn) { return dn; }
                var match = /CN=([^,]+)/.exec(dn);
                return match ? match[1] : dn;
            }

            // Same certificate loading/filtering logic as SignFiles.aspx: 7-day expiry
            // grace period for display, and excluding only CONFIRMED Microsoft-software
            // provider certificates (real hardware DSC tokens are always branded with
            // their own vendor's provider name) -- never excluding an unknown/undetermined
            // provider, since that lookup is best-effort and can legitimately fail without
            // meaning anything is wrong.
            async function dscLoadCertificates() {
                dscCertSelect.innerHTML = '<option value="">--Select--</option>';
                dscCertStatus.textContent = 'Loading certificates...';
                try {
                    var response = await fetch(dscBaseUrl() + '/api/certificates', {
                        headers: { 'Authorization': 'Bearer ' + dscToken() }
                    });
                    if (!response.ok) {
                        dscCertStatus.textContent = 'Could not reach the Agent to list certificates (HTTP ' + response.status + ').';
                        return;
                    }
                    var data = await response.json();
                    var now = new Date();
                    var sevenDaysAgo = new Date();
                    sevenDaysAgo.setDate(sevenDaysAgo.getDate() - 7);

                    for (var i = 0; i < data.certificates.length; i++) {
                        var c = data.certificates[i];
                        var notAfter = new Date(c.notAfter);
                        if (notAfter < sevenDaysAgo) { continue; }
                        if (c.provider && c.provider.toLowerCase().indexOf('microsoft ') === 0) { continue; }

                        var option = document.createElement('option');
                        option.value = c.thumbprint;
                        var expiry = notAfter.toISOString().substring(0, 10);
                        var isExpired = notAfter < now;
                        var issuerName = dscExtractCommonName(c.issuer);
                        var providerLabel = c.provider ? c.provider : 'Unknown provider';
                        option.textContent = dscExtractCommonName(c.subject) + ' -- issued by ' + issuerName +
                            ' [' + providerLabel + '] (expires ' + expiry + ')' + (isExpired ? ' [EXPIRED]' : '');
                        dscCertSelect.appendChild(option);
                    }

                    var displayedCount = dscCertSelect.options.length - 1;
                    dscCertStatus.textContent = displayedCount === 0
                        ? 'No certificates found -- is the DSC token plugged in and unlocked?'
                        : displayedCount + ' certificate(s) available -- confirm the correct one is selected before signing.';
                } catch (err) {
                    dscCertStatus.textContent = 'Could not reach the Agent (' + err.message + '). Is Icegate Agent running?';
                }
                // Reloading certificates rebuilds the dropdown's options, which can reset
                // its selection back to "Auto" -- re-check the combined enable condition
                // regardless of how this call ended.
                dscUpdateSignButtonState();
            }

            // Health check -> protocol-launch attempt -> retry -> install-link fallback.
            // Previously missing from this page entirely -- dscLoadCertificates() was
            // called directly at page load with no attempt to relaunch an installed-but-
            // not-running Agent first, which is why the only failure behavior seen during
            // testing was the generic "Could not reach the Agent" message with no recovery
            // action. Matches SignFiles.aspx's ensureAgentAvailable() pattern exactly.
            async function dscEnsureAgentAvailable() {
                async function isAgentHealthy() {
                    try {
                        var response = await fetch(dscBaseUrl() + '/api/health', { cache: 'no-store' });
                        return response.ok;
                    } catch (err) {
                        return false;
                    }
                }

                if (await isAgentHealthy()) {
                    dscLoadCertificates();
                    return;
                }

                dscCertStatus.textContent = 'Icegate Agent is not responding -- attempting to reconnect...';

                // Not responding -- attempt to relaunch an already-installed-but-not-running
                // Agent via its icegate:// protocol handler. If the Agent has never been
                // installed at all, nothing is registered for this scheme and this does
                // nothing observable; there is no reliable cross-browser way to detect
                // "protocol not registered" from script, so this deliberately does not try
                // to distinguish that case up front -- the same timeout-then-retry below
                // correctly handles both outcomes either way.
                try {
                    window.location.href = 'icegate://launch';
                } catch (err) {
                    // Some browsers throw synchronously for an unrecognized scheme --
                    // ignored deliberately, since the retry below is what actually
                    // determines the outcome.
                }

                setTimeout(async function () {
                    if (await isAgentHealthy()) {
                        dscLoadCertificates();
                    } else {
                        dscCertSelect.innerHTML = '<option value="">--Select--</option>';
                        dscCertStatus.innerHTML =
                            'Icegate Agent is not running. <a href="' + dscInstallUrl() + '" target="_blank" rel="noopener">' +
                            'Click here to install it</a>, then reload this page.';
                        dscUpdateSignButtonState();
                    }
                }, 2000);
            }

            async function dscSignAndUpload() {
                var jobNo = dscJobNo();
                if (!jobNo) {
                    alert('Job number not found.');
                    return;
                }

                if (dscFileSelect.files.length === 0) {
                    dscSignStatus.textContent = 'Choose a file to sign above.';
                    return;
                }

                dscSignAndUploadButton.disabled = true;
                dscDownloadRow.style.display = 'none';
                var unsignedFile = dscFileSelect.files[0];
                var extensionMatch = /\.([a-z0-9]+)$/i.exec(unsignedFile.name);
                var extension = extensionMatch ? extensionMatch[1].toLowerCase() : '';

                try {
                    // Step 1: send the operator-picked file straight to the local Agent for
                    // signing -- same FormData shape SignFiles.aspx already uses successfully,
                    // and the same /api/sign endpoint, which already handles .be/.sb/.json/.pdf
                    // generically. No server round trip to fetch anything first, unlike the
                    // earlier "Generate Json" auto-fetch this replaces.
                    dscSignStatus.textContent = 'Signing via Icegate Agent...';
                    var formData = new FormData();
                    formData.append('files', unsignedFile, unsignedFile.name);
                    if (dscCertSelect.value) {
                        formData.append('certificateThumbprint', dscCertSelect.value);
                    }

                    var signResponse = await fetch(dscBaseUrl() + '/api/sign', {
                        method: 'POST',
                        headers: { 'Authorization': 'Bearer ' + dscToken() },
                        body: formData
                    });

                    if (!signResponse.ok) {
                        var signErrText = await signResponse.text();
                        dscSignStatus.textContent = 'Signing request failed: ' + signErrText;
                        return;
                    }

                    var signData = await signResponse.json();
                    var outcome = signData.results && signData.results[0];

                    if (!outcome || !outcome.success) {
                        dscSignStatus.textContent = 'Signing failed: ' + (outcome ? outcome.message : 'no result returned.');
                        return;
                    }
                    if (!outcome.signedFileBase64) {
                        dscSignStatus.textContent = 'Signing succeeded but the Agent did not return the signed file content -- ' +
                            'confirm Icegate Agent has been updated to include SignedFileBase64 in its /api/sign response.';
                        return;
                    }

                    // Step 2: decode the signed bytes -- shared by both branches below.
                    var byteChars = atob(outcome.signedFileBase64);
                    var byteNumbers = new Array(byteChars.length);
                    for (var j = 0; j < byteChars.length; j++) {
                        byteNumbers[j] = byteChars.charCodeAt(j);
                    }
                    var signedBytes = new Uint8Array(byteNumbers);
                    var signedFileName = unsignedFile.name.replace(/\.([a-z0-9]+)$/i, 'Signed.$1');

                    if (extension === 'json') {
                        // Step 3a (.json only): inject into the EXISTING fileuploadExcel control
                        // via the DataTransfer API -- the sanctioned way to hand a
                        // script-constructed File to a file input. This does not (and cannot)
                        // let script read arbitrary local files -- only place a file the script
                        // itself already holds into the input, as if the user had picked it
                        // themselves. Then trigger the EXISTING upload button -- same postback,
                        // same JSON_IEC_GATE_UPLOAD handler, unmodified. Only .json goes down
                        // this path: JSON_IEC_GATE_UPLOAD parses the content as JSON
                        // (JObject.Parse) to validate senderID, which would fail against a
                        // signed .be/.sb/.pdf file's binary or non-JSON content.
                        dscSignStatus.textContent = 'Signed. Uploading...';
                        var signedFile = new File([signedBytes], signedFileName, { type: 'application/json' });

                        var dataTransfer = new DataTransfer();
                        dataTransfer.items.add(signedFile);
                        var fileInput = document.getElementById('<%= fileuploadExcel.ClientID %>');
                        fileInput.files = dataTransfer.files;

                        document.getElementById('<%= btn_upload.ClientID %>').click();
                    } else {
                        // Step 3b (.be/.sb/.pdf): this page has no existing submit path for
                        // these types -- JSON_IEC_GATE_UPLOAD is JSON-specific, and there is no
                        // equivalent ICEGATE flat-file/PDF submission entry point here. Offer a
                        // direct download instead, matching SignFiles.aspx's own generic
                        // "sign, then let the operator download the result" behavior for these
                        // same file types.
                        var blob = new Blob([signedBytes]);
                        var downloadUrl = URL.createObjectURL(blob);
                        dscDownloadLink.href = downloadUrl;
                        dscDownloadLink.download = signedFileName;
                        dscDownloadRow.style.display = 'block';
                        dscSignStatus.textContent = 'Signed. This page has no automatic submit path for .' + extension +
                            ' files -- use the download link below.';
                    }
                } catch (err) {
                    dscSignStatus.textContent = 'Error: ' + err.message;
                } finally {
                    // Re-evaluates both conditions rather than unconditionally
                    // re-enabling -- normally still true after a sign attempt (nothing
                    // here resets them), but this keeps the button's state consistent
                    // with dscUpdateSignButtonState's own logic rather than a separate,
                    // parallel enable path that could drift out of sync with it.
                    dscUpdateSignButtonState();
                }
            }

            dscRefreshCertsButton.addEventListener('click', dscLoadCertificates);
            dscSignAndUploadButton.addEventListener('click', dscSignAndUpload);
            dscCertSelect.addEventListener('change', dscUpdateSignButtonState);
            dscFileSelect.addEventListener('change', dscUpdateSignButtonState);
            dscEnsureAgentAvailable();

            // "Sign & Upload" starts disabled -- there's nothing to sign until a file is
            // chosen AND a specific certificate is selected. Both conditions are checked
            // directly against current DOM state each time (dscFileSelect.files.length,
            // dscCertSelect.value), so no separate startup wiring is needed here the way the
            // earlier "Generate Json" postback-detection required -- picking a file or a
            // certificate fires its own "change" event above, which re-evaluates state
            // immediately either way.
            dscUpdateSignButtonState();
        })();
    </script>
</asp:Content>
