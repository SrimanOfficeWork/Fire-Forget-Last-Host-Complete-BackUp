<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Exp_Multiple_Checklist.aspx.cs"
    Inherits="Imp_Exp_Multiple_Checklist" EnableSessionState="ReadOnly" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title></title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        
        .grid-view tr.selected-row td
        {
            background-color: #388e3c !important;
            color: #ffffff !important;
        }
        
        .toggle-label
        {
            cursor: pointer;
            padding: 10px;
            margin-bottom: 5px;
            width: 300px;
            text-align: center;
        }
        #overlay
        {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            z-index: 9999;
            display: flex;
            justify-content: center;
            align-items: center;
            display: none;
        }
        .loading-message
        {
            text-align: center;
            color: white;
        }
        .blurred
        {
            filter: blur(5px);
            pointer-events: none;
        }
        .toggle-div
        {
            height: auto !important;
            overflow: hidden;
            display: none;
            padding: 10px;
            margin-top: 5px;
        }
        #tag_transac_exp_drawback
        {
            height: auto !important;
        }
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden">
    <form id="Form1" runat="server" enctype="multipart/form-data">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div>
                <div id="innerbox_MidMain_Grid" style="height: 100px; margin-top: 0px;">
                    <div id="tag_srcinner1">
                        <div id="mainmastop2container_rght_tag2_txt1" style="width: 140px;">
                            Multiple Checklist</div>
                        <div id="verslic">
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width: 210px; margin-left: 5px; margin-top: 5px;">
                            <asp:RadioButtonList ID="Radio_Imp_Exp" runat="server" RepeatDirection="Horizontal"
                                onclick="loadimpexp()" CssClass="radio-spacing">
                                <asp:ListItem Text="Import" Value="I"></asp:ListItem>
                                <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div id="verslic">
                        </div>
                        <div id="tag_srcinner_rght_Single_line" style="width: 261px; margin-top: 1px; display: flex;">
                            <!-- SEARCH BUTTON -->
                            <div style="padding-top: 0px; width: 45px; text-align: center;">
                                <asp:ImageButton ID="btnSearch" runat="server" Height="26px" Width="30px" ToolTip="Search"
                                    ImageUrl="~/images/icons/search_IRN.png" OnClick="btnSearch_Click" OnClientClick="setPartyValue()" />
                                <div style="font-size: 11px; margin-top: 2px;">
                                    Search</div>
                            </div>
                            <!-- IRN GENERATE BUTTON -->
                            <div id="Div_IRN_btn_New" runat="server" style="width: 70px; height: 26px; padding-top: 0px;
                                text-align: center;">
                                <asp:ImageButton ID="btnBulk" runat="server" style="height: 31px; width: 30px; margin-top: -4px;" ToolTip="Download Checklist"
                                    ImageUrl="~/images/download_Icon.png" OnClientClick="open_jobno(); return false" />
                                <div style="font-size: 11px; margin-top: 2px;">
                                    Download</div>
                            </div>
                        </div>
                        <div id="popupwindow_closebut_right">
                            <input type="button" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
                        </div>
                    </div>
                    <div id="tag_Exchange_inner" style="width: 1038px; height: 55px; margin-top: 21px;">
                        <div id="tag_Adminsrc_inner_lft">
                            <div id="tag_transact_lft_in1" style="width: 1071px">
                                <div id="Hide_Party" runat="server">
                                    <div id="tag_label_transact_Src" style="width: 570px; margin-left: 9px; margin-top: 5px">
                                        Party Name
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 490px; position: absolute; margin-left: 91px;
                                        margin-top: 1px">
                                        <asp:DropDownList ID="ddlpartyname" runat="server" class="chosen-select-deselect"
                                            Style="width: 480px;" data-placeholder="Choose a Party Name" ClientIDMode="Static"    onchange="setPartyValue();" 
                                            TabIndex="1">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="tag_transact_lft_in1" style="width: 400px; height: 25px; margin-top: 1px;
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
                    </div>
                </div>
                <div id="innerbox_MidMain_Grid" style="margin-top: -18px; height: 473px;">
                    <div id="tag_transact_lft_in1" style="margin-top: -7px; width: 976px; margin-left: 6px;
                        height: 470px; overflow-y: auto; overflow-x: auto; display: block;">
                        <asp:GridView runat="server" ID="gvdetails" DataKeyNames="JOBNO_PS" AutoGenerateColumns="False"
                            BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                            Style="width: 959px; height: 65px; overflow-y: auto; overflow-x: auto;" ShowHeader="true"
                            ShowHeaderWhenEmpty="true" PageSize="23" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                            AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                            CellPadding="1" CellSpacing="1 ">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <HeaderStyle Font-Underline="false" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" onclick="event.stopPropagation(); CheckAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" onclick="event.stopPropagation(); OnRowCheck(this);" />
                                    </ItemTemplate>
                                    <ItemStyle Width="40px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="JOBNO" HeaderText="Job No">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No">
                                    <ItemStyle CssClass="column_style_left5" Width="160px" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JOBDATE" HeaderText="Job Date">
                                    <ItemStyle CssClass="column_style_left5" Width="85px" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TRANSPORT_MODE" HeaderText="Mode">
                                    <ItemStyle CssClass="column_style_left5" Width="36px" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PORT_ORIGIN" HeaderText="Loading Port">
                                    <ItemStyle CssClass="column_style_left5" Width="150px" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PORT_SHIPMENT" HeaderText="Destination Port">
                                    <ItemStyle CssClass="column_style_left5" Width="150px" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CUSTOMS_HOUSE" HeaderText="Customs House">
                                    <ItemStyle CssClass="column_style_left5" Width="96px" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FILE_REF_NO" HeaderText="File Ref No">
                                    <ItemStyle CssClass="column_style_left5" Width="150px" Font-Size="12px" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                    </div>
                </div>
                <!-- OVERLAY WITH PROGRESS -->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
                        <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    <div style="display: none;">
        <asp:HiddenField ID="hdn_imp_Exp" runat="server" />
         <asp:HiddenField ID="hdn_ddlval" runat="server" />
    </div>
    </form>
    <div id="downloadOverlay" style="display: none; position: fixed; top: 0; left: 0;
        width: 100%; height: 100%; background: rgba(0,0,0,0.65); z-index: 999999; justify-content: center;
        align-items: center; text-align: center;">
        <div>
            <img src="../images/Infinity.gif" alt="Loading..." style="width: 60px; height: 60px;" />
            <br />
            <br />
            <div id="progressText" style="font-size: 16px; font-weight: bold; color: #ffffff;
                margin-top: 8px;">
                Preparing download...
            </div>
            <div id="progressCount" style="font-size: 13px; color: #dddddd; margin-top: 8px;">
            </div>
        </div>
    </div>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>
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
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
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
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });
        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {
                return options.allrules.validate2fields.alertText;
            }
        }
    </script>
    <script type="text/javascript">
        function loadimpexp() {

            var selected = document.querySelector(
            "input[name='<%= Radio_Imp_Exp.UniqueID %>']:checked"
        );

            if (!selected) return;

            var selectedValue = selected.value;

            PageMethods.Get_party(selectedValue,
    function (res) {

        var ddlparty = document.querySelector("[id$='ddlpartyname']");

        ddlparty.options.length = 0;

        ddlparty.options.add(new Option("-- Select --", ""));

        for (var i = 0; i < res.length; i++) {
            ddlparty.options.add(new Option(res[i], res[i]));
        }
        $("#ddlpartyname").trigger("chosen:updated");
    },
    function (err) {

    });
        }


        function UpdateHeaderCheckbox() {
            var grid = document.getElementById('<%= gvdetails.ClientID %>');
            var inputs = grid.getElementsByTagName("input");

            var allChecked = true;
            var headerCheckbox = null;

            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type === "checkbox") {
                    if (inputs[i].id.indexOf("chkSelectAll") !== -1) {
                        headerCheckbox = inputs[i];
                    } else {
                        if (!inputs[i].checked) {
                            allChecked = false;
                        }
                    }
                }
            }

            if (headerCheckbox != null) {
                headerCheckbox.checked = allChecked;
            }
        }
        function ToggleRow(row) {

            var chk = row.querySelector("input[type='checkbox']");

            if (!chk) return;

            var grid = document.getElementById('<%= gvdetails.ClientID %>');
            var checkboxes = grid.querySelectorAll("input[type='checkbox']");

            var checkedCount = 0;

            // Count currently selected rows
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].id.indexOf("chkSelect") !== -1 && checkboxes[i].checked) {
                    checkedCount++;
                }
            }

            // If user is trying to CHECK a new row
            if (!chk.checked && checkedCount >= 40) {   // change 5 &#8594; 40 in production
                alert("You can select only up to 5 rows.");
                return;
            }

            // Toggle checkbox
            chk.checked = !chk.checked;

            UpdateRowColor(row, chk.checked);
            UpdateHeaderCheckbox();
        }

        function OnRowCheck(chk) {

            var grid = document.getElementById('<%= gvdetails.ClientID %>');
            var checkboxes = grid.querySelectorAll("input[type='checkbox']");

            var checkedCount = 0;

            for (var i = 0; i < checkboxes.length; i++) {
                // only count row checkboxes
                if (checkboxes[i].id.indexOf("chkSelect") !== -1) {
                    if (checkboxes[i].checked) {
                        checkedCount++;
                    }
                }
            }

            // &#128308; LIMIT CHECK (change 5 to 40 in production)
            if (checkedCount > 40) {
                alert("You can select only up to 40 rows.");

                chk.checked = false; // undo selection
                return;
            }

            var row = chk.closest("tr");
            UpdateRowColor(row, chk.checked);
            UpdateHeaderCheckbox();
        }
        function CheckAll(headerCheckbox) {

            var grid = document.getElementById('<%= gvdetails.ClientID %>');
            var checkboxes = grid.querySelectorAll("input[type='checkbox']");

            var checkedCount = 0;

            // count already selected
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].id.indexOf("chkSelect") !== -1 && checkboxes[i].checked) {
                    checkedCount++;
                }
            }

            for (var i = 0; i < checkboxes.length; i++) {

                var chk = checkboxes[i];

                if (chk.id.indexOf("chkSelect") !== -1) {

                    if (headerCheckbox.checked) {

                        if (checkedCount < 40) {
                            if (!chk.checked) {
                                chk.checked = true;
                                checkedCount++;
                            }
                        } else {
                            chk.checked = false;
                            chk.disabled = true;
                        }

                    } else {
                        chk.checked = false;
                        chk.disabled = false;
                    }

                    UpdateRowColor(chk.closest("tr"), chk.checked);
                }
            }
        }
        function UpdateHeaderCheckbox() {
            var grid = document.getElementById('<%= gvdetails.ClientID %>');
            var chks = grid.querySelectorAll("input[type='checkbox']");
            var header = null;
            var allChecked = true;

            chks.forEach(function (c) {
                if (c.id.indexOf("chkSelectAll") !== -1) {
                    header = c;
                } else {
                    if (!c.checked) {
                        allChecked = false;
                    }
                }
            });

            if (header) header.checked = allChecked;
        }
        function UpdateRowColor(row, isChecked) {
            if (isChecked) {
                row.classList.add("selected-row");
            } else {
                row.classList.remove("selected-row");
            }
        }
    </script>
    <script type="text/javascript">

        function open_jobno() {
            var selected = document.querySelector(
        "input[name='<%= Radio_Imp_Exp.UniqueID %>']:checked"
    );

            if (!selected) {
                alert("Please select Import or Export.");
                return false;
            }

            var jobtype = selected.value;
            var grid = document.getElementById("<%= gvdetails.ClientID %>");
            var checkboxes = grid.querySelectorAll("input[type='checkbox'][id*='chkSelect']");
            var jobList = [];

            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    var row = checkboxes[i].closest("tr");
                    var jobno = row.cells[1].innerText.trim();
                    jobList.push(jobno);
                }
            }

            if (jobList.length == 0) {
                alert("Please select at least one Job No");
                return false;
            }

            // Unique token to identify THIS download
            var downloadToken = "dl_" + new Date().getTime();
            var cookieName = "downloadReady_" + downloadToken;

            // Show overlay
            var overlay = document.getElementById("downloadOverlay");
            overlay.style.display = "flex";
            document.getElementById("progressText").innerText = "Downloading...";
            document.getElementById("progressCount").innerText = "Please wait...";

            // &#9733; Poll for cookie every 1 second
            // When server sets the cookie, we know ZIP is fully streamed
            var cookieInterval = setInterval(function () {
                if (document.cookie.indexOf(cookieName + "=1") !== -1) {
                    clearInterval(cookieInterval);

                    // Clear the cookie
                    document.cookie = cookieName + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";

                    // Show complete and hide overlay
                    document.getElementById("progressText").innerText = "Download Complete!";
                    document.getElementById("progressCount").innerText = "";
                    setTimeout(function () {
                        overlay.style.display = "none";
                    }, 1500);
                }
            }, 1000);

            // Build URL with downloadToken
            var reportPage = (jobtype == 'I')
        ? '../Report/Import_ReportViewer.aspx'
        : '../Report/Export_ReportViewer.aspx';

            var url = reportPage
        + '?joblist=' + encodeURIComponent(jobList.join(","))
        + '&multijob=true'
        + '&jobno=1'
        + '&jobtype=' + jobtype
        + '&downloadToken=' + downloadToken;

            var iframe = document.getElementById("downloadFrame");
            if (!iframe) {
                iframe = document.createElement("iframe");
                iframe.id = "downloadFrame";
                iframe.style.display = "none";
                document.body.appendChild(iframe);
            }

            iframe.src = url;

            // Safety net: force hide after 3 minutes
            setTimeout(function () {
                clearInterval(cookieInterval);
                overlay.style.display = "none";
            }, 180000);

            return false;
            loadimpexp();
        }
        function setPartyValue() {
            var ddl = document.getElementById("ddlpartyname");
            if (ddl) {
                document.getElementById("<%= hdn_ddlval.ClientID %>").value = ddl.value;
               }
        }

       
</script>
</body>
</html>
