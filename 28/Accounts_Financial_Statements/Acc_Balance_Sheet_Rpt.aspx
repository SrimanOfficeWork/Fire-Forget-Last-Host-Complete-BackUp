<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Balance_Sheet_Rpt.aspx.cs" Inherits="Acc_Balance_Sheet_Rpt" %>

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
            <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 1212px;
                height: 400px; background-color: #FFFFFF; margin-top: -2px;">
                <div id="tag_transac_lft_Inv_in1" style="height: 390px; width: 1092px;">
                    <div id="innerbox_MidMain" style="height: 35px; width: 1092px;">
                        <div id="tag_srcinner1">
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                                Balance Sheet </div>
                            <div id="verslic">
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px;">
                                <a href="#" id="btnex" runat="server" style="display: block; width: 50px; height: 30px;
                                    margin-top: -6px; background-image: url('../images/xls.jpg'); background-repeat: no-repeat;"
                                    onserverclick="btnexcel_Click" tabindex="7"></a>
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px;">
                                <a href="#" id="btnRdlc" runat="server" style="display: block; width: 50px; height: 30px;
                                    margin-top: -6px; background-image: url('../images/pdf.jpg'); background-repeat: no-repeat;"
                                    onserverclick="btnRdlc_Click" tabindex="7"></a>
                            </div>
                            <div id="verslic">
                            </div>
                            <div id="popupwindow_closebut_right">
                                <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
                            </div>
                        </div>
                        
                    </div>
                    <div id="innerbox_MidMain_Grid" style="height: 530px; margin-top: -13px; width: 1092px;">
                        <%-- <div id="Main_Grid_Container" runat="server">--%>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" BackColor="#F2F5F2"
                            EnableTheming="true" ExportContentDisposition="AlwaysAttachment" Height="530px"
                            ProcessingMode="Local" ShowBackButton="false" ShowDocumentMapButton="true" ShowExportControls="true"
                            ShowFindControls="False" ShowPageNavigationControls="true" ShowParameterPrompts="false"
                            ShowPrintButton="false" ShowRefreshButton="true" ShowReportBody="true" ShowToolBar="true"
                            ShowZoomControl="false" SizeToReportContent="false" ToolBarItemBorderColor="Black"
                            ToolBarItemBorderStyle="Solid" Width="100%">
                        </rsweb:ReportViewer>
                        <%--        </div>--%>
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
    <div style="display: none;">
        <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
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
</body>
</html>

