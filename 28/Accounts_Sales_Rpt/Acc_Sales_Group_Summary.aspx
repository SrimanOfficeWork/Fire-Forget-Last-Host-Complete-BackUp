<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Sales_Group_Summary.aspx.cs" Inherits="Accounts_Sales_Rpt_Acc_Sales_Group_Summary" %>


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
        
        
        .radio-spacing input[type='radio']
        {
            margin-right: 10px;
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
            <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 1092px;
                height: 400px; background-color: #FFFFFF; margin-top: -2px;">
                <div id="tag_transac_lft_Inv_in1" style="height: 390px; width: 800px;">
                    <div id="innerbox_MidMain" style="height: 105px; width: 850px;">
                        <div id="tag_srcinner1">
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 190px;">
                                Group Summary
                            </div>
                            <div id="verslic">
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px;">
                                <a href="#" id="btnex" runat="server" style="display: block; width: 50px; height: 30px;
                                    margin-top: -6px; background-image: url('../images/xls.jpg'); background-repeat: no-repeat;"
                                    onserverclick="btnexcel_Click" tabindex="7"></a>
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px; display: none">
                                <a href="#" id="btnRdlc" runat="server" style="display: block; width: 50px; height: 30px;
                                    margin-top: -6px; background-image: url('../images/pdf.jpg'); background-repeat: no-repeat;"
                                    onserverclick="btnRdlc_Click" tabindex="7"></a>
                            </div>
                            <div id="verslic">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 65px; margin-top: 5px">
                                Branch
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 230px; margin-top: 4px; position: absolute;
                                margin-left: 345px;">
                                <asp:DropDownList ID="ddlgroup_Name" class="chosen-select-deselect" Style="width: 225px;"
                                    data-placeholder="Choose a Branch" runat="server" TabIndex="12">
                                </asp:DropDownList>
                            </div>
                            <div id="verslic" style="margin-left: 250px;">
                            </div>
                            
                            <div id="popupwindow_closebut_right">
                                <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
                            </div>
                        </div>
                        <div id="tag_transact_src_inner" style="width: 500px; height: 67px;">
                            
                               <div id="tag_label_transact_Src" style="width: 95px; margin-top: 10px">
                                        Group Name
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 150px; position: absolute; margin-top: 10px;
                                        margin-left: 78px">
                                        <asp:DropDownList ID="ddl_GroupName" runat="server" class="chosen-select-deselect"
                                            ClientIDMode="Static" data-placeholder="Choose Group Name" Style="width: 150px;"
                                            TabIndex="1">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 110px; margin-left: 142px; margin-top: 10px">
                                        Sub Group Name
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 150px; position: absolute; margin-top: 5px;
                                        margin-left: 348px">
                                        <asp:DropDownList ID="ddl_SubGroupName" runat="server" class="chosen-select-deselect"
                                            ClientIDMode="Static" data-placeholder="Choose Sub Group Name" Style="width: 150px;"
                                            TabIndex="1">
                                        </asp:DropDownList>
                                    </div>
                                <div id="tag_transact_srcinner_rght" style="margin-top: 0px; margin-left: -50px;margin-right: -191px;">
                                    <div id="small-butt-left">
                                        <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                                            onserverclick="btnSearch_Click" tabindex="5"></a>
                                    </div>
                                    <div id="small-butt-rght">
                                        <a href="#" onclick="parent.adcodewindow.hide();return false;" class="cancelButt">
                                        </a>
                                    </div>
                                </div>
                           
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Grid" style="height: 360px; margin-top: -13px; width: 850px;">
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" BackColor="#F2F5F2"
                            EnableTheming="true" ExportContentDisposition="AlwaysAttachment" Height="400px"
                            ProcessingMode="Local" ShowBackButton="false" ShowDocumentMapButton="true" ShowExportControls="true"
                            ShowFindControls="False" ShowPageNavigationControls="true" ShowParameterPrompts="false"
                            ShowPrintButton="false" ShowRefreshButton="true" ShowReportBody="true" ShowToolBar="true"
                            ShowZoomControl="false" SizeToReportContent="false" ToolBarItemBorderColor="Black"
                            ToolBarItemBorderStyle="Solid" Width="100%">
                        </rsweb:ReportViewer>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="display: none;">
        <asp:HiddenField ID="hdnparty" runat="server" />
        <asp:HiddenField ID="hdnjobno" runat="server" />
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
