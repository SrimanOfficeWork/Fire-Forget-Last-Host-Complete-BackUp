<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods_General.aspx.cs" Inherits="Export_General" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection"
        type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
            <div id="innerbox_MidMain_Transact_popup_new">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Goods Registration
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transaction_inner_new">
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new">
                            Job No
                        </div>
                        <div id="txtcon-m_transaction_code" style="width:150px;">
                            <asp:TextBox ID="txtJobNo" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code" Width="0px" BorderColor="White"
                                MaxLength="10" ReadOnly="True" TabIndex="1"></asp:TextBox>
                                <asp:TextBox ID="txt_Job_ps" runat="server" CssClass="txtbox_none_Mid_transac_code"  Font-Size="12px" Width="135px"
                                MaxLength="10" ReadOnly="True" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_date">
                            Job Date
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtJobDate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                MaxLength="10" TabIndex="2"></asp:TextBox>
                            <%-- <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>--%>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel">
                            Transport Mode</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlTransportMode" runat="server" Enabled="false" CssClass="listtxt_transac_mode_new"
                                TabIndex="3">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new">
                            SB Type</div>
                        <div id="txtcon-m_transaction_code"  style="width:150px;">
                            <asp:DropDownList ID="ddlSBType" runat="server" CssClass="listtxt_transac_src1" TabIndex="5"
                                Enabled="false">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_date">
                            Custom House</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtCustomsHouse" runat="server" ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                onkeyup="ChangeCase(this);" onfocus="ChangeCase(this);" onblur="ChangeCase(this);"
                                onkeypress="return pin1(event)" MaxLength="50" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area" runat="server">
                            <%-- <a href="#" class="magnfy" onclick="OpenPopupCustom_House(''); return false" tabindex="6"></a>--%>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_popup_no_empty_new">
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();"
                        id="Air_Page" style="display: none;" runat="server"><span>Air</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                        id="Sea_Page" style="display: none;" runat="server"><span>Sea</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3();"
                        id="EOU"><span>EOU</span></a></li>
                    <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4();"
                        id="AR4"><span>AR4 Details</span></a></li>
                   <%--<li><a href="#page-5" target="maineroyal" onclick="tab('0');"><span>Docket</span></a></li>--%>
                    <%--<li><a href="#page-6" target="maineroyal" onclick="tab('0');"><span>Tracking</span></a></li>--%>
                    <li><a href="#page-5"  onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../Report/Goods_CheckList.aspx?jobno=',document.getElementById('txtJobNo').value);" id="Checklist"><span>Checklist</span></a></li>
                    <li><a href="#page-6"  onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../FlatFile/Goods_Reg_FlatFile_Generation.aspx?jobno=',document.getElementById('txtJobNo').value);" id="Submission"><span>Submission</span></a></li>
                    <%--<li><a href="#page-8" target="maineroyal" onclick="tab('0');"><span>Job History</span></a></li>--%>
                </ol>
                <div class="content" id="page-1">
                <%-- --removed src="#" - for page loading multiple times --%>
                    <%--<iframe src="#" name="trans_igm" scrolling="no" id="Trans_export_Goods_Reg_Air_Iframe" runat="server"></iframe>   --%>
                    <iframe  src="#" name="trans_igm" scrolling="no" id="Trans_export_Goods_Reg_Air_Iframe" runat="server"></iframe>   
                </div>
                <div class="content" id="page-2">
                    <iframe  src="#" name="trans_igm" scrolling="no" id="Trans_export_invoice_Iframe"
                        runat="server"></iframe>
                </div>
                <div class="content" id="page-3">
                    <iframe  src="#" name="trans_igm" scrolling="no" id="Trans_export_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-4">
                    <iframe  src="#" name="trans_igm" scrolling="no" id="Trans_igm_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-5">
                   
                </div>
                <div class="content" id="page-6">
                   
                </div>
                <div class="content" id="page-7">
                    
                </div>
                <div class="content" id="page-8">
                    
                </div>
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Export_Jscript/Export_Goods_Reg_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
       
    
        function close_button() {
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
       //window.onload = happycode;

        function happycode() {

            if (document.getElementById("hdn_Edit_TransportMode").value = 'Air') {

                document.getElementById("Air_Page").click();
            }
            else {

                document.getElementById("Sea_Page").click();

            }
        }
    </script>
</body>
</html>
