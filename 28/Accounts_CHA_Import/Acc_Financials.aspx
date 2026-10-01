<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Financials.aspx.cs" Inherits="Accounts_CHA_Import_Acc_Financials" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_annx_CSea" style="width: 990px; height: 418px;">
                <ol id="toc">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page_AR();"
                        id="Id_AR" style="height: 20px"><span>AR Invoices</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page_AP();"
                        runat="server" id="Id_AP" style="height: 20px"><span>AP Invoices</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page_PR('I');"
                        runat="server" id="Id_PR" style="height: 20px" visible="True"><span>Payment Request</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 990px;
                        height: 390px; background-color: #FFFFFF; margin-top: -5px; margin-top: -35px;">
                        <div id="tag_transac_lft_IGM_Invoice_Grid_area" style="width: 970px; height: 320px;
                            margin-top: 20px;">
                            <asp:GridView ID="gv_details" runat="server" DataKeyNames="ID,BILL_INV_NO,JOBNO_PS,IMP_EXP"
                                EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                                CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True" PageSize="15" AllowPaging="True"
                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound">
                                <HeaderStyle CssClass="header" BackColor="#808080" Font-Bold="True" ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="BILL_INV_DATE" HeaderText="Date" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"  Width="50px" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Bill No" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkOrg" runat="server" Text='<%# Eval("BILL_INV_NO") %>'  OnClientClick='<%# "return open_GST_Sales_Entry_Ch(\"" + Eval("id") + "\", \"" + Eval("IMP_EXP") + "\", \"" + Eval("BILL_INV_NO") + "\");" %>'
                                             CommandName="SelectOrganization">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="column_style_left" Width="100px" Font-Size="12px" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="TYPE" HeaderText="Type" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left" Width="50px"  Font-Size="12px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CUS_NAME" HeaderText="Organization" HeaderStyle-Width="300px">
                                        <ItemStyle CssClass="column_style_left"  Width="300px" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CUR" HeaderText="Curr" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"  Width="50px"  Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GRAND_TOTAL" HeaderText="Amount" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"  Width="50px" Font-Size="12px" ForeColor="Green" Font-Bold="true" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" Height="16px" Width="25px" ToolTip="Invoice Report"
                                                ImageUrl="~/images/icons/ACC_PDF.png" runat="server" OnClientClick='<%# "return GST_Billing_Job_Rpt(\"" + Eval("id") + "\", \"" + Eval("IMP_EXP") + "\", \"" + Eval("BILL_INV_NO") + "\");" %>'>
                                            </asp:ImageButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="Balance_Outstanding" HeaderText="Balance" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"  Width="50px" Font-Size="12px" ForeColor="Green" Font-Bold="true" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                             
                        </div>
                          <asp:LinkButton ID="lnkOrg" runat="server" Text="New" OnClientClick="open_GST_Sales_Entry_N();" CommandName="SelectOrganization">
                               </asp:LinkButton>
                    </div>
                </div>
                <div class="content" id="page-2" style="display: none;">
                    <iframe name="trans_igm" scrolling="no" id="Id_AR_Iframe" style="width: 990px;height: 400px; margin-top: -45px; margin-left: -10px;"></iframe>
                </div>
                <div class="content" id="page-3" style="display: none;">
                    <iframe name="trans_Inv" scrolling="no" id="Id_PR_Iframe" style="width: 990px; height: 400px;margin-top: -45px; margin-left: -10px;"></iframe>
                </div>
                
                <%--<div class="content" id="page-4" style="display: none;">
                    <iframe name="trans_rpt" scrolling="no" id="Inv_Rpt_Iframe" style="width: 990px;
                        height: 450px; margin-top: -102px; margin-left: -10px;"></iframe>
                </div>
                <div class="content" id="page-5" style="display: none;">
                    <iframe name="trans" scrolling="no" id="No_Invoice_Id_Iframe" style="width: 990px;
                        height: 480px; margin-top: -35px; margin-left: -15px;"></iframe>
                </div>--%>

                <div style="display: none;">
                    <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />

                     <asp:HiddenField ID="Hdn_Jobno" runat="server" />
                     <asp:HiddenField ID="Hdn_Jobno_Ps" runat="server" />
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
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
    <script type="text/javascript">

        function GST_Billing_Job_Rpt(Job_Id, Imp_Exp, Bill_Inv_No) {
            if (Job_Id != '') {
                NewWindow1('../Accounts_Sales_Inv_Rpt/GST_Imp_Exp_rpt.aspx?Job_Id=' + Job_Id + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Inv_No, 'List', '870', '1024', 'yes');
            } else {
                jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
            }
        }
        
        function open_GST_Sales_Entry_Ch(Job_Id, Imp_Exp, Bill_Inv_No) {
            NewWindow1('../Accounts_Sales/GST_Sales_Entry.aspx?Page=' + Job_Id + '&IMP_EXP=' + Imp_Exp + '&Billinvno=' + Bill_Inv_No, '_blank', '1200', '585', 'yes');
        }
        function open_GST_Sales_Entry_N() {
            var J_no = document.getElementById("Hdn_Jobno").value;
            var Jobno_ps = document.getElementById("Hdn_Jobno_Ps").value;
            NewWindow1('../Accounts_Sales/GST_Sales_Entry.aspx?Page=' + 'Financials' + '&IMP_EXP=' + 'I' + '&Jobno=' + J_no + '&Jobno_ps=' + Jobno_ps, '_blank', '1200', '585', 'yes');
        }
    </script>
</body>
</html>
