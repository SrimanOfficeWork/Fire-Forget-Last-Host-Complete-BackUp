<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SB_BE_Tracking_Auto_Captcha.aspx.cs"
    Inherits="SB_BE_Tracking_Auto_Captcha" %>

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
        #innerbox_MidMain_Grid
        {
            height: auto !important;
            overflow-x: auto;
            overflow-y: visible;
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
            <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 1100px;
                height: 550px; background-color: #FFFFFF; margin-top: -2px;">
                <div id="tag_transac_lft_Inv_in1" style="height: 550px; width: 1100px;">
                    <div id="innerbox_MidMain" style="height: 90px; width: 1095px;">
                        <div id="tag_srcinner1">
                            <div id="tag_Sbstatus" runat="server" style="width: 200px; display: none">
                                <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                                    SB Status Tracking
                                </div>
                            </div>
                            <div id="tag_BEstatus" runat="server" style="width: 200px; display: none">
                                <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                                    BE Status Tracking
                                </div>
                            </div>
                            <div id="verslic">
                            </div>
                            <div id="popupwindow_closebut_right">
                                <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                            </div>
                        </div>
                        <div id="tag_transact_src_inner" style="width: 1000px; height: 52px;">
                            <div id="tag_Exchange_inner_lft" style="width: 1050px">
                                <div id="innerbox_transac_bot_inn" style="width: 1050px; margin-top: 0px;">
                                    <div id="DivSingleOption" runat="server" style="width: 1050px">
                                        <div id="tag_label_transact_Src" style="width: 50px; margin-top: 3px;">
                                            Job No
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 150px;">
                                            <asp:TextBox ID="txt_Jobno" runat="server" MaxLength="16" Width="130px" TabIndex="1"
                                                Height="21px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transact_Src" style="width: 50px; margin-left: 10px; margin-top: 3px;">
                                            <asp:Label ID="lblSB_BE_no" runat="server" />
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 150px;">
                                            <asp:TextBox ID="txtSB_BE_No" runat="server" MaxLength="16" Width="130px" TabIndex="1"
                                                Height="21px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transact_Src" style="width: 60px; margin-top: 3px;">
                                            <asp:Label ID="lblSB_BE_dt" runat="server" />
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 150px; height: 22px;">
                                            <asp:TextBox ID="txtSB_BE_Dt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                                MaxLength="10" TabIndex="3" Width="130px" Height="21px"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtSB_BE_Dt"
                                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                            </cc1:MaskedEditExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSB_BE_Dt"
                                                Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                        </div>
                                        <div id="tag_label_transact_Src" style="width: 62px; margin-left: 10px; margin-top: 3px;">
                                            Location
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 190px;">
                                            <asp:TextBox ID="txtloc" runat="server" MaxLength="16" Width="130px" TabIndex="1"
                                                Height="21px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                        </div>
                                        <div id="editbu">
                                            <asp:Button ID="btnSBTRack" runat="server" CssClass="autowidmovebut" CausesValidation="false"
                                                UseSubmitBehavior="false" Text="Track Status" Style="width: 130px; margin-top: -1px;"
                                                Visible="true" OnClientClick="Track_status(); return false;" />
                                        </div>
                                        <div id="editbu">
                                            <asp:Button ID="btnBindGrid" runat="server" Text="Bind Grid" OnClick="btnBindGrid_Click"
                                                Style="display: none;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="Main_Grid_Container" style="overflow: hidden; height: 510px; margin-top: -20px;">
                        <asp:GridView ID="gvdetails" runat="server" AllowSorting="True" ShowHeader="True"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                            ShowFooter="false" CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                            AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                            OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gvdetails_RowDataBound" Style="overflow: auto;"
                            Height="141px">
                            <RowStyle BorderWidth="0.1em" BorderColor="black" />
                            <PagerStyle ForeColor="Black" CssClass="pager" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Headings" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <asp:Label ID="txt_Headings" runat="server" Font-Bold="true" Text='<%# Eval("Headings") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="1100px" HorizontalAlign="Left"
                                        Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Values" HeaderStyle-Font-Bold="true" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_Values" runat="server" ReadOnly="true" Width="180px" Text='<%# Eval("Values") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="190px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Headings" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <asp:Label ID="txt_Headings1" runat="server" Font-Bold="true" Text='<%# Eval("Headings1") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="1100px" HorizontalAlign="Left"
                                        Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Values" HeaderStyle-Font-Bold="true" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_Values1" runat="server" ReadOnly="true" Width="180px" Text='<%# Eval("Values1") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="190px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Headings" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <asp:Label ID="txt_Headings2" runat="server" Font-Bold="true" Text='<%# Eval("Headings2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="1100px" HorizontalAlign="Left"
                                        Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Values" HeaderStyle-Font-Bold="true" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_Values2" runat="server" ReadOnly="true" Width="180px" Text='<%# Eval("Values2") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="190px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                     <div id="loadingDiv" style="display: none; position: fixed; top: 0; left: 0; width: 100%;
                            height: 100%; z-index: 9999; background-color: rgba(0, 0, 0, 0.5); align-items: center;
                            justify-content: center; pointer-events: none;">
                            <div style="position: relative; z-index: 10000; display: flex; flex-direction: column;
                                align-items: center;">
                                <div style="margin-bottom: 15px;">
                                    <img src="../images/tracking_status.gif" alt="Loading" style="width: 80px; height: 80px;" />
                                </div>
                                <p id="progressText" style="font-size: 14px; color: white; margin-bottom: 10px;">
                                   Tracking Status, please wait...
                                </p>
                            </div>
                            
                        </div>
                </div>
            </div>
            <%-- </div>--%>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
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
        <asp:HiddenField ID="HiddenField_index" runat="server" />
        <asp:HiddenField ID="hfDdlClientValue" runat="server" />
        <asp:HiddenField ID="hfJobnoValue" runat="server" />
        <asp:HiddenField ID="hdn_saved" runat="server" />
        <asp:HiddenField ID="hdn_Grid" runat="server" />
        <asp:HiddenField ID="hdnGridData" runat="server" />
         <asp:HiddenField ID="hdn_path_check" runat="server" />
        
    </div>
    </form>
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
        function showLoadingMessage() {
            console.log("Showing loading message...");
            document.getElementById('loadingDiv').style.display = 'flex';
            document.body.style.pointerEvents = 'none';
        }
        function hideLoadingMessage() {
            console.log("Hiding loading message...");
            document.getElementById('loadingDiv').style.display = 'none';
            document.body.style.filter = 'none';
            document.body.style.pointerEvents = 'auto';
        }



        function toggleVisibility(divId) {

            var selectedDiv = document.getElementById(divId);


            if (selectedDiv.style.display === 'none' || selectedDiv.style.display === '') {
                selectedDiv.style.display = 'block';
            } else {
                selectedDiv.style.display = 'none';
            }
        }
      
    </script>
   <script type="text/javascript">
function startPolling(jobno) {
    document.getElementById('loadingDiv').style.display = 'flex';

    let pollingStarted = false;
    let interval;
    let overlayCheck;
    let pollingAlive = true;
    let lastMessage = "";
    let sameMessageCount = 0;

    // 1. Watchdog to detect overlay unexpectedly disappearing
    overlayCheck = setInterval(function () {
        let loadingVisible = document.getElementById('loadingDiv').style.display !== 'none';

        if (!loadingVisible && pollingAlive) {
            clearInterval(overlayCheck);
            clearInterval(interval);
            pollingAlive = false;

            console.warn("Overlay disappeared unexpectedly. Stopping driver.");
            PageMethods.StopDriver(jobno,
                function () {
                    console.log("Driver stopped due to unexpected overlay hide.");
                },
                function (err) {
                    console.error("Failed to stop driver via fallback:", err);
                }
            );
        }
    }, 3000);

    // 2. Watchdog timeout (no first response within 10 sec)
    const watchdogTimeout = setTimeout(function () {
        if (!pollingStarted) {
            clearInterval(interval);
            clearInterval(overlayCheck);
            hideLoadingMessage();
            showConfirmAfterHide("No response from server. Please try again.");
        }
    }, 10000);

    // 3. Start polling for progress
    interval = setInterval(function () {
        PageMethods.GetAutomationProgress(jobno, function (data) {
            if (!pollingStarted) {
                pollingStarted = true;
                clearTimeout(watchdogTimeout);
            }

            // Update progress text
            const progressTextEl = document.getElementById('progressText');
            if (progressTextEl) {
                progressTextEl.innerText = data.Message || "";
            }

            // Check for same message repeating
            if (data.Message === lastMessage) {
                sameMessageCount++;
            } else {
                sameMessageCount = 0;
                lastMessage = data.Message;
            }

            if (sameMessageCount >= 40) { // ~60 seconds of same message
                console.warn("Same message repeating too long, assuming stuck process.");
                clearInterval(interval);
                clearInterval(overlayCheck);
                pollingAlive = false;
                hideLoadingMessage();
                showConfirmAfterHide("No progress detected. Process may have stopped unexpectedly.");

                PageMethods.StopDriver(jobno,
                    function () {
                        console.log("Driver forcefully stopped after stuck progress.");
                    },
                    function (err) {
                        console.error("Error stopping driver:", err);
                    }
                );
                return;
            }

            // Handle "Connection Lost..."
            if (data.Message === "Connection Lost...") {
                clearInterval(interval);
                clearInterval(overlayCheck);
                pollingAlive = false;
                hideLoadingMessage();
                showConfirmAfterHide("Background process disconnected unexpectedly.");
                return;
            }

            // Handle success (100%)
            if (data.Percent >= 100) {
                clearInterval(interval);
                clearInterval(overlayCheck);
                pollingAlive = false;

                setTimeout(function () {
                    __doPostBack('<%= btnBindGrid.UniqueID %>', '');
                    showConfirmAfterHide(data.Message);
                }, 1000);
            }
        }, function (err) {
            console.error("Polling error:", err);
            clearInterval(interval);
            clearInterval(overlayCheck);
            pollingAlive = false;
            hideLoadingMessage();
            showConfirmAfterHide("Error polling progress.");
        });
    }, 1500);
}
</script>
    <script type="text/javascript">
        function getQueryStringValue(name) {
            name = name.replace(/[\[\]]/g, "\\$&"); var regex = new RegExp("[?&]" + name + "=([^&#]*)");
            var results = regex.exec(window.location.search);
            return results === null ? null : decodeURIComponent(results[1].replace(/\+/g, " ")); 
         }
        function Track_status() {
           
            var gridData = [];
            var currentUser = '<%= Session["currentuser"].ToString() %>';
            var SB_BE_No = $('#<%= txtSB_BE_No.ClientID %>').val() || "";
            var Jobno = $('#<%= txt_Jobno.ClientID %>').val() || "";

            if (!SB_BE_No || !Jobno) {
                alert("Please fill SB/BE No and Job No.");
                return;
            }

            $('#<%= gvdetails.ClientID %> tr').each(function () {
                if ($(this).find("th").length > 0) return; // skip header row

                var cells = $(this).find("td");
                if (cells.length > 0) {
                    gridData.push({
                        Headings: $(cells[0]).text().trim(),
                        Values: $(cells[1]).text().trim(),
                        Headings1: $(cells[2]).text().trim(),
                        Values1: $(cells[3]).text().trim(),
                        Headings2: $(cells[4]).text().trim(),
                        Values2: $(cells[5]).text().trim(),
                        Jobno: Jobno.trim(),
                        User: currentUser.trim()
                    });
                }
            });
           
            var SB_BE_Dt = $('#<%= txtSB_BE_Dt.ClientID %>').val() || "";
            var loc = $('#<%= txtloc.ClientID %>').val() || "";
            var COMPANY_ID = '<%= Session["COMPANY_ID"].ToString() %>';
            var currentbranch = '<%= Session["currentbranch"].ToString() %>';
            var currentuser = '<%= Session["currentuser"].ToString() %>';
            var TYPE = getQueryStringValue("STATUS");

            if (Jobno !== "" && SB_BE_No !== "" && SB_BE_Dt !== "" && loc !== "") {
               
                showLoadingMessage();
                startPolling(Jobno);
                var gridJson = JSON.stringify(gridData);
               
                PageMethods.TrackBE_SB(
            gridJson, TYPE, SB_BE_No, SB_BE_Dt, loc, Jobno, COMPANY_ID, currentbranch, currentuser,
            function (result) {
                console.log("TrackBE_SB success:", result);
            },
            function (error) {
                alert("Automation failed: " + error.get_message());
            }
        );
            } else {
                alert("Please fill in all required fields before generating.");
            }
        }


    </script>
</body>
</html>
