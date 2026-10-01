<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IRN_Autiomation_General.aspx.cs"
    Inherits="IRN_Autiomation_General" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title></title>
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
        .hideGridColumn
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        
        
        #overlay
        {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5); /* Dark semi-transparent background */
            z-index: 9999; /* Ensure it's on top */
            display: flex;
            justify-content: center;
            align-items: center;
            display: none;
        }
        
        /* Loading Message Container */
        .loading-message
        {
            text-align: center;
            color: white;
        }
        
        /* Blurring Effect for the Entire Page */
        .blurred
        {
            filter: blur(5px); /* Apply blur effect */
            pointer-events: none; /* Disable interaction */
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
            <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 990px;
                height: 400px; background-color: #FFFFFF; margin-top: -2px;">
                <div id="tag_transac_lft_Inv_in1" style="height: 550px; width: 1000px;">
                    <div id="innerbox_MidMain" style="height: 80px;">
                        <div id="tag_srcinner1">
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                                IRN Automation
                            </div>
                            <div id="verslic">
                            </div>
                            <div id="popupwindow_closebut_right">
                                <%--  <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />--%>
                                <%--<input type="button" value="Submit" class="clsicon" onclick="
        var isSaved = document.getElementById('hdn_saved').value;
        var isGrid = document.getElementById('hdn_Grid').value;
        if (isSaved==='N' && isGrid==='Y') {
            var shouldSave = confirm('Details not saved. Would you like to save it?');
            if (shouldSave) {
                var saveBtn = document.getElementById('btnSave');
                if (saveBtn) {
                    saveBtn.click();
                }
                
                return false; 
            }
            else
                {
                 var dltfiles = document.getElementById('btn');
                if (dltfiles) {
                    dltfiles.click();
                }
                }
        }
        if (parent && parent.document.getElementById('btn_IRN_Retrive')) {
            parent.document.getElementById('btn_IRN_Retrive').click();
        }
        parent.adcodewindow.hide();
        return false;
    " />--%>
     


<input type="button" value="Submit" class="clsicon" onclick="
    var isSaved = document.getElementById('hdn_saved').value;
    var isGrid = document.getElementById('hdn_Grid').value;
    var jobno = document.getElementById('txt_Jobno') ? document.getElementById('txt_Jobno').value : '';

    if (isSaved === 'N' && isGrid === 'Y') {
        var shouldSave = confirm('Details not saved. Would you like to save it?');
        if (shouldSave) {
            var saveBtn = document.getElementById('btnSave');
            if (saveBtn) saveBtn.click();
            return false;
        } else {
            var dltfiles = document.getElementById('btn');
            if (dltfiles) dltfiles.click();
        }
    }

    // Call server to stop driver if running
    if (jobno !== '') {
        try {
            PageMethods.StopDriver(jobno,
                function () {
                    console.log('Driver stopped successfully.');
                },
                function (err) {
                    console.error('Failed to stop driver:', err);
                }
            );
        } catch (e) {
            console.error('StopDriver call error:', e);
        }
    }

    // Trigger parent button
    if (parent && parent.document.getElementById('btn_IRN_Retrive')) {
        parent.document.getElementById('btn_IRN_Retrive').click();
    }

    parent.adcodewindow.hide();
    return false;
" />

      </div>

                        </div>
                        <div id="tag_transact_src_inner" style="width: 1000px; height: 67px;">
                            <div id="tag_Exchange_inner_lft" style="width: 700px">
                                <div id="innerbox_transac_bot_inn" style="width: 700px;">
                                    <div id="DivSingleOption" runat="server" style="width: 700px">
                                        <div id="tag_label_transact_Src" style="width: 50px; margin-top: 3px;">
                                            Job No
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 110px;">
                                            <asp:TextBox ID="txt_Jobno" runat="server" MaxLength="16" Width="100px" TabIndex="1"
                                                Height="21px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transact_Src" style="width: 50px; margin-left: 10px; margin-top: 3px;">
                                            Client
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 270px;">
                                            <asp:TextBox ID="txtclient" runat="server" MaxLength="16" Width="255px" TabIndex="1"
                                                Height="21px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transact_Src" style="width: 100px; margin-top: 3px;">
                                            Icegate user Id
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 110px;">
                                            <asp:DropDownList ID="ddlIcegateId" runat="server" MaxLength="20" Width="100px" Height="22px"
                                                TabIndex="1" Font-Size="12px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_transact_srcinner_rght" style="margin-top: 1px; margin-right: 100px;">
                                <div id="tag_Exchange_inner_lft" style="width: 230px">
                                    <input type="file" id="fileInput" name="fileInput" multiple="multiple" />
                                </div>
                                <div id="tag_Exchange_inner_lft" style="width: 230px">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                                        Style="margin-top: -47px; margin-left: 216px;" />
                                </div>
                                <asp:Button ID="btnRefreshGrid" runat="server" Text="Refresh Grid" OnClick="btnRefreshGrid_Click" Style="display:none;" />

                            </div>
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Grid" style="height: 416px; margin-top: -13px; overflow-y: auto;">
                        <asp:GridView ID="gv_Details" runat="server" AllowSorting="false" EmptyDataText="No Record Found"
                            PageSize="2" AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8"
                            BorderStyle="none" ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                            CssClass="grid-view" AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True"
                            OnRowDataBound="gv_Details_RowDataBound" OnRowDeleting="gv_Details_RowDeleting"
                            ShowHeader="true" OnRowCreated="gv_Details_RowCreated" Height="415px" Width="980px">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="44px" HeaderText="S.No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblitemslno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="44px" />
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="Documents" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFileName" runat="server" Text='<%# Bind("DOC_FILE_NAME") %>'
                                            Style="width: 250px;" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IRN No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIRNno" runat="server" Text='<%# Bind("IRN") %>' Style="width: 200px;"
                                            ></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Doc Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlDocType" CssClass="chosen-select-deselect" runat="server"
                                            MaxLength="20" Width="280px" Height="22px" Font-Size="12px" DataTextField="DOC_CODE"
                                            onchange='Get_Doc_Type(this);' DataValueField="DOC_CODE" Style="position: absolute;"
                                            data-placeholder="Select Doc Type">
                                            <asp:ListItem></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlLevel" runat="server" MaxLength="20" Width="125px" Height="22px"
                                            Font-Size="12px">
                                            <asp:ListItem Text="" Value="" />
                                            <asp:ListItem Text="JOB" Value="JOB" />
                                            <asp:ListItem Text="INVOICE" Value="INVOICE" />
                                            <asp:ListItem Text="ITEM" Value="ITEM" />
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="200px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtJobno" runat="server" Text='<%# Bind("Jobno") %>' Style="width: 200px;"
                                            ></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" CssClass="hideGridColumn"/>
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px"  CssClass="hideGridColumn"/>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="User" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtUser" runat="server" Text='<%# Bind("User") %>' Style="width: 200px;"
                                            ></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" CssClass="hideGridColumn"/>
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px"  CssClass="hideGridColumn"/>
                                </asp:TemplateField>



                                <asp:CommandField ShowDeleteButton="True" ControlStyle-Font-Bold="true" DeleteText="Delete"
                                    ControlStyle-Font-Size="Small" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div id="innerbox_MidMain_bot_transact_invoice" style="width: 1000px; height: 32px;
                        margin-top: -16px;">
                        <div id="newbu" style="display: none">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="26" OnClick="btnNew_Click"
                                CausesValidation="false" UseSubmitBehavior="false" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                OnClick="btnSave_Click" TabIndex="25" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="28" CausesValidation="false"
                                Visible="false" UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job?', 'VAS Details', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="29" CausesValidation="false" UseSubmitBehavior="false"
                                CssClass="dlete" Style="display: none;" OnClick="btnDelete_Click" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                                tabindex="30" id="btn_cancel" />
                        </div>
                        <div id="editbu">
                           
                            <asp:Button ID="btnGenIRN" runat="server" CssClass="autowidmovebut" CausesValidation="false"
                                UseSubmitBehavior="false" Text="Generate IRN" Style="width: 100px" Visible="true"
                                OnClientClick="IRN_Generation(); return false;" />
                        </div>
                        <%-- <div id="loadingDiv" style="display: none; text-align: center; position: fixed; top: 0;
                            left: 0; width: 100%; height: 100%; z-index: 9999; background-color: rgba(0, 0, 0, 0.5);
                            align-items: center; justify-content: center; pointer-events: none;">
                            <div style="position: relative; z-index: 10000; display: flex; align-items: center;">
                                <img src="../images/Bean_Eater.gif" alt="Loading" style="max-width: 100px; max-height: 100px;
                                    margin-right: 10px;" />
                                <p style="color: white; font-size: 18px;">
                                    Generating IRN, please wait...</p>
                                <div id="progressBar" style="width: 0%; height: 24px; background-color: #4CAF50;
                                    color: white; text-align: center; line-height: 24px; border-radius: 5px;">
                                    0%
                                </div>
                                <p id="progressText" style="margin-top: 5px; font-weight: bold;">
                                </p>
                            </div>
                        </div>--%>
                        <div id="loadingDiv" style="display: none; position: fixed; top: 0; left: 0; width: 100%;
                            height: 100%; z-index: 9999; background-color: rgba(0, 0, 0, 0.5); align-items: center;
                            justify-content: center; pointer-events: none;">
                            <div style="position: relative; z-index: 10000; display: flex; flex-direction: column;
                                align-items: center;">
                                <div style="margin-bottom: 15px;">
                                    <img src="../images/Bean_Eater.gif" alt="Loading" style="width: 80px; height: 80px;" />
                                </div>
                                <p id="progressText" style="font-size: 14px; color: white; margin-bottom: 10px;">
                                    Generating IRN, please wait...
                                </p>
                            </div>
                            
                        </div>
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
   <asp:HiddenField ID="HDU" runat="server" />

<asp:ModalPopupExtender ID="MP_U" runat="server"
    TargetControlID="HDU"
    PopupControlID="MessageDivupdated_U"
    BackgroundCssClass="modalBackground"
    DropShadow="false" />

<asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left">
    <div style="width: 300px; height: 80px;">
        <table width="100%" style="padding-top: 10px;">
            <tr>
                <td align="center">
                    <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 125px; padding-top: 10px;">
                    <asp:Button ID="Button2" runat="server" Text="Ok"
                        OnClientClick="return HideModalPopup_U();"
                        CausesValidation="false" UseSubmitBehavior="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>


 <%--   <asp:ModalPopupExtender ID="MP_U" runat="server"
    TargetControlID="HDU"
    PopupControlID="MessageDivupdated_U"
    BackgroundCssClass="modalBackground"
    DropShadow="false" />

<asp:HiddenField ID="HDU" runat="server" />

<asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left" BorderColor="Transparent">
    <div style="width: 300px; height: 80px;">
        <table width="100%" style="padding-top: 10px;">
            <tr>
                <td align="center">
                    <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 125px; padding-top: 10px;">
                    <asp:Button ID="Button2" runat="server" Text="Ok"
                        OnClientClick="return HideModalPopup_U()" 
                        CausesValidation="false" UseSubmitBehavior="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>--%>

    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    <div style="display: none;">
        <asp:HiddenField ID="HiddenField_index" runat="server" />
        <asp:HiddenField ID="hfDdlClientValue" runat="server" />
        <asp:HiddenField ID="hfJobnoValue" runat="server" />
        <asp:HiddenField ID="hdn_saved" runat="server" />
        <asp:HiddenField ID="hdn_Grid" runat="server" />
        <asp:HiddenField ID="hfAlertMsg" runat="server" />
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
//        function hideLoadingMessage() {
//            console.log("Hiding loading message...");
//            document.getElementById('loadingDiv').style.display = 'none';
//            document.body.style.filter = 'none';
//            document.body.style.pointerEvents = 'auto';
//        }

 </script>
    <script type="text/javascript">
        function Get_Doc_Type(Doc_type) {
            var ddlDocType = Doc_type;
            var selectedDocType = ddlDocType.value;
            var row = ddlDocType.closest('tr');
            var ddlLevel = row.querySelector("select[id*='ddlLevel']");
            PageMethods.Get_Doc_type_level(selectedDocType, function (res) {
                CallSuccess_Doc_type_level(res, ddlLevel);
            });
        }

        function CallSuccess_Doc_type_level(res, ddlLevel) {
            ddlLevel.value = res;
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
                    __doPostBack('<%= btnRefreshGrid.UniqueID %>', '');
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
        function IRN_Generation() {
            var folderHasFiles = document.getElementById('<%= hdn_path_check.ClientID %>').value || "";
           
            if (folderHasFiles == 'true') {
                startAutomation();
            }
            else {
                alert("File does not exist");
            }
        }

        function startAutomation() {
            var gridData = [];

          
            $('#<%= gv_Details.ClientID %> tr').each(function () {
                var fileName = $(this).find("input[id*='txtFileName']").val() || "";
                var docType = $(this).find("select[id*='ddlDocType']").val() || "";
                var irnNo = $(this).find("input[id*='txtIRNno']").val() || "";
                var level = $(this).find("select[id*='ddlLevel']").val() || "";
                var Jobno = $('#<%= txt_Jobno.ClientID %>').val() || "";
                var User = '<%= Session["currentuser"].ToString() %>';

                if (fileName) {
                    gridData.push({ DOC_FILE_NAME: fileName.trim(),
                        IRN: irnNo.trim(),
                        DOC_TYPE: docType.trim(),
                        DOC_LEVEL: level.trim(),
                        Jobno: Jobno.trim(),
                        User : User.trim()
                    });
                }
            });

            var icegateIdText = $('#<%= ddlIcegateId.ClientID %> option:selected').text();
            var icegateIdValue = $('#<%= ddlIcegateId.ClientID %> option:selected').val();
            var Jobno = $('#<%= txt_Jobno.ClientID %>').val();
            var gridJson = JSON.stringify(gridData);
            var COMPANY_ID = '<%= Session["COMPANY_ID"].ToString() %>';
            var currentbranch = '<%= Session["currentbranch"].ToString() %>';
            var currentuser = '<%= Session["currentuser"].ToString() %>';
           

            if (icegateIdValue === "") {
                alert("Please select ICEGATE ID");
                return false;
            }

            showLoadingMessage();
            startPolling(Jobno);

            PageMethods.GenerateIRN(icegateIdText, icegateIdValue, Jobno, gridJson, COMPANY_ID, currentbranch, currentuser,
        function (result) {  
           
        },
        function (error) {    
            alert("Automation failed: " + error.get_message());
            hideLoadingMessage(Jobno);
        }
    );
        }

    </script>
</body>
</html>
