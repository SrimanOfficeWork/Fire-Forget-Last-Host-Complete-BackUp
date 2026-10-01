<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSR_Mail_Scheduler.aspx.cs"
    Inherits="DSR_Mail_Scheduler" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <style type="text/css">
        .preview-box
        {
            border: 1px solid #ccc;
            padding: 15px;
            background-color: #f9f9f9;
            height: 100%;
            min-height: 150px;
            overflow-y: auto;
        }
        
        .remove-btn
        {
            background-color: red;
            color: white;
            border: none;
            cursor: pointer;
            margin-top: -35px;
            margin-left: 115px;
        }
        .form-group
        {
            margin-bottom: 10px;
            display: flex;
            align-items: center;
            width: 218px;
        }
        .remove-btn:hover
        {
            background-color: darkred;
        }
        .editor-container
        {
            width: 513px;
            height: 244px; /* Maintain mail template height */
        }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Trans_new" style="height: 560px; width: 1090px;">
                <div id="tag_srcinner1_new">
                    <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 450px; margin-top: 5px;
                        color: #f7f3ef; font-size: 17px">
                        Mail Scheduler
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div class="content" id="page-1" style="height: 500px; padding-left: 4px;">
                    <div id="tag_transac_lft_IGM_in1" style="height: 272px; width: 1064px; margin-left: 10px">
                        <div id="tag_transac_lft_Inv_in1" style="width: 680px; height: 29px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Schedule Name
                            </div>
                            <div id="txtcon-m_src" style="width: 570px">
                                <asp:TextBox ID="txtScheduleName" runat="server" MaxLength="200" CssClass="validate[required] txtbox_none"
                                    TabIndex="1" Style="width: 560px;"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 680px; height: 29px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Notify To
                            </div>
                            <div id="txtcon-m_src" style="width: 570px">
                                <asp:DropDownList ID="ddlNotifyTo" runat="server" CssClass="chosen-select-deselect"
                                    TabIndex="2" Style="width: 565px;" onchange="Load_Client_mail();">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 680px; height: 29px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Report
                            </div>
                            <div id="txtcon-m_src" style="width: 570px">
                                <asp:DropDownList ID="ddlReport" runat="server" CssClass="chosen-select-deselect"
                                    TabIndex="3" Style="width: 565px;">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 680px; height: 29px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Subject
                            </div>
                            <div id="txtcon-m_src" style="width: 570px">
                                <asp:TextBox ID="txtSubject" runat="server" MaxLength="100" CssClass="validate[required] txtbox_none"
                                    TabIndex="4" Style="width: 560px;"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 680px; height: 29px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                From
                            </div>
                            <div id="txtcon-m_src" style="width: 570px">
                                <asp:TextBox ID="txtFrom" runat="server" MaxLength="1000" CssClass="validate[required] txtbox_none"
                                    TabIndex="5" Style="width: 560px;"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 680px; height: 29px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                To
                            </div>
                            <div id="txtcon-m_src" style="width: 570px">
                                <asp:TextBox ID="txtTo" runat="server" MaxLength="1000" CssClass="validate[required] txtbox_none"
                                    TabIndex="5" Style="width: 560px;"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 680px; height: 29px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Cc
                            </div>
                            <div id="txtcon-m_src" style="width: 570px">
                                <asp:TextBox ID="txtCc" runat="server" MaxLength="1000" CssClass="txtbox_none" TabIndex="6"
                                    Style="width: 560px;"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 680px; height: 29px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Bcc
                            </div>
                            <div id="txtcon-m_src" style="width: 570px">
                                <asp:TextBox ID="txtBcc" runat="server" MaxLength="1000" CssClass="txtbox_none" TabIndex="7"
                                    Style="width: 560px;"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 680px; height: 29px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Schedule
                            </div>
                            <div id="txtcon-m_src" style="width: 100px">
                                <asp:DropDownList ID="ddlSchedule" runat="server" Style="height: 20px; width: 80px"
                                    TabIndex="8" OnChange="toggleControls();">
                                    <asp:ListItem Text="Daily" Value="D"></asp:ListItem>
                                    <asp:ListItem Text="Weekly" Value="W"></asp:ListItem>
                                    <asp:ListItem Text="Monthly" Value="M"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 40px">
                                Status
                            </div>
                            <div id="txtcon-m_src" style="width: 215px; margin-top: -2px">
                                <asp:RadioButtonList ID="Rdstatus" runat="server" RepeatDirection="Horizontal" CssClass="radio-spacing"
                                    TabIndex="9">
                                    <asp:ListItem Text="Active" Value="A" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Inactive" Value="IA"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="area_transac_container_genral" style="height: 251px; width: 382px; margin-top: -230px">
                            <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 135px; margin-top: -10px;
                                font-size: large; width: 150px">
                                Message Preview
                            </div>
                            <div class="preview-box" id="previewBox" style="margin-top: 5px; height: 220px; width: 360px;
                                margin-top: -12px">
                                <p>
                                    No message yet</p>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Inv_in1" style="width: 1080px; height: 300px;">
                        <div id="tag_label_transaction_popup_IGM_invoice" 
                            style="width: 60px; margin-left: 11px;">
                            Mail Body
                        </div>
                        <div id="txtcon_mid_size" style="width: 960px; margin-left: 115px; margin-top: -15px;
                            height: 189px;">
                            <asp:TextBox ID="txt_Body" runat="server" Width="960px" Height="182px" TextMode="MultiLine"
                                TabIndex="10" onkeyup="UpdatePreview()" Columns="50" Rows="8"></asp:TextBox>
                            <asp:HtmlEditorExtender ID="html_editextend" TargetControlID="txt_Body" runat="server"
                                EnableSanitization="false">
                                <Toolbar>
                                    <asp:Redo />
                                    <asp:Undo />
                                    <asp:Bold />
                                    <asp:Italic />
                                    <asp:Underline />
                                    <asp:StrikeThrough />
                                    <asp:JustifyLeft />
                                    <asp:JustifyCenter />
                                    <asp:JustifyRight />
                                    <asp:JustifyFull />
                                    <asp:InsertOrderedList />
                                    <asp:InsertUnorderedList />
                                    <asp:RemoveFormat />
                                    <asp:BackgroundColorSelector />
                                    <asp:ForeColorSelector />
                                    <asp:FontNameSelector />
                                    <asp:FontSizeSelector />
                                    <asp:InsertHorizontalRule />
                                </Toolbar>
                            </asp:HtmlEditorExtender>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" runat="server" style="width: 360px;">
                            <div id="innerbox_transac_bot_inn" style="width: 360px; margin-left: 390px; margin-top: 10px">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                        OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                        TabIndex="100" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return ValidURL();"
                                        TabIndex="103" OnClick="btnSave_Click" CommandName="s" />
                                </div>
                                <div id="editbu">
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                        OnClientClick="return ValidURL();" TabIndex="101" />
                                </div>
                                <div id="editbu">
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="102" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job?', 'GENERAL', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          alert('');
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="104" OnClick="btnDelete_Click" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                        CssClass="dlete" Style="display: none;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="display: none;">
                    <asp:HiddenField ID="hdnMailBody" runat="server" />
                    <asp:HiddenField ID="HdnUpdate_id" runat="server" />
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
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
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true, search_contains: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "45%" }

        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }

        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });

    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#<%= ddlReport.ClientID %>").change(UpdatePreview);
            $("#<%= ddlNotifyTo.ClientID %>").change(UpdatePreview);
        });


        function UpdatePreview() {

            var scheduleName = document.getElementById('<%= txtScheduleName.ClientID %>').value;

            var reportDropdown = document.getElementById('<%= ddlReport.ClientID %>');
            var report = reportDropdown.options[reportDropdown.selectedIndex].text

            var notifyTo = $("#<%= ddlNotifyTo.ClientID %>").val();
            var subject = document.getElementById('<%= txtSubject.ClientID %>').value;
            var From = document.getElementById('<%= txtFrom.ClientID %>').value;
            var to = document.getElementById('<%= txtTo.ClientID %>').value;
            var cc = document.getElementById('<%= txtCc.ClientID %>').value;
            var bcc = document.getElementById('<%= txtBcc.ClientID %>').value;


            var scheduleDropdown = document.getElementById('<%= ddlSchedule.ClientID %>');
            var schedule = scheduleDropdown.options[scheduleDropdown.selectedIndex].text

            var Status = document.querySelector('input[name="Rdstatus"]:checked').parentNode.innerText;


            var mailTemplate = document.getElementById('<%= txt_Body.ClientID %>').value;


            var previewContent = '<strong>Schedule Name:</strong> <span style="color: #4CAF50;">' + scheduleName + '</span><br>';
            previewContent += '<strong>Report:</strong> <span style="color: #FF5722;">' + report + '</span><br>';
            previewContent += '<strong>Subject:</strong> <span style="color: #2196F3;">' + subject + '</span><br>';
            previewContent += '<strong>Notify To:</strong> <span style="color: #9C27B0;">' + notifyTo + '</span><br>';
            previewContent += '<strong>From:</strong> <span style="color:#006400;">' + From + '</span><br>'; // Dark Blue
            previewContent += '<strong>To:</strong> <span style="color: #00008B;">' + to + '</span><br>'; // Dark Blue
            previewContent += '<strong>Cc:</strong> <span style="color: #FF8C00;">' + cc + '</span><br>'; // Dark Orange
            previewContent += '<strong>Bcc:</strong> <span style="color: #607D8B;">' + bcc + '</span><br>'; // Dark Grayish Blue
            previewContent += '<strong>Schedule:</strong> <span style="color: #8BC34A;">' + schedule + '</span><br>';
            previewContent += '<strong>Status:</strong> <span style="color: #D32F2F;">' + Status + '</span><br>'; // Red

            document.getElementById('previewBox').innerHTML = previewContent;


        }

        window.onload = function () {
            setTimeout(function () {
                UpdatePreview();
            }, 500);


            document.getElementById('<%= ddlReport.ClientID %>').addEventListener('change', UpdatePreview);
            document.getElementById('<%= ddlNotifyTo.ClientID %>').addEventListener('change', UpdatePreview);
            document.getElementById('<%= txtScheduleName.ClientID %>').addEventListener('input', UpdatePreview);

            document.getElementById('<%= txtSubject.ClientID %>').addEventListener('input', UpdatePreview);
            document.getElementById('<%= txtFrom.ClientID %>').addEventListener('input', UpdatePreview);
            document.getElementById('<%= txtTo.ClientID %>').addEventListener('input', UpdatePreview);
            document.getElementById('<%= txtCc.ClientID %>').addEventListener('input', UpdatePreview);
            document.getElementById('<%= txtBcc.ClientID %>').addEventListener('input', UpdatePreview);

            document.getElementById('<%= ddlSchedule.ClientID %>').addEventListener('change', UpdatePreview);
            document.getElementById('<%= Rdstatus.ClientID %>').addEventListener('change', UpdatePreview);

        };



        function Load_Client_mail() {
            var client = document.querySelector('#<%= ddlNotifyTo.ClientID %>').value;
            PageMethods.Get_EmailId(client, CallSuccess_Mail_id);
        }
        function CallSuccess_Mail_id(res) {

            document.getElementById("txtTo").value = res;
            UpdatePreview();
        }

       
       
    </script>
</body>
</html>
