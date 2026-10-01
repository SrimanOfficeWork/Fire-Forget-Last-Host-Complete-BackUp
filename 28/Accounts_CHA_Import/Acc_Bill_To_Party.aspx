<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Bill_To_Party.aspx.cs"
    Inherits="Import_Acc_Bill_To_Party" %>

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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();"
                        id="bill" style="height: 20px"><span>Bill to Party</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');Imp_charge_tab_page2();"
                        runat="server" id="Charge_Id" style="height: 20px"><span>Charges</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');Imp_Inv_tab_page3();"
                        runat="server" id="Inv_ID" style="height: 20px" visible="False"><span>Create Invoice</span></a></li>
                    <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');Imp_NoInv_tab_page5();"
                        runat="server" id="No_Invoice_Id" style="height: 20px" visible="False"><span>No of Invoice</span></a></li>
                    <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');charge_tab_page4();"
                        runat="server" id="Acc_Rpt" style="height: 20px"><span>Profit & Loss</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 990px;
                        height: 420px; background-color: #FFFFFF; margin-top: -15px;">
                        <div id="tag_transac_lft_Inv_in1" style="height: 250px; width: 500px;">
                            <div id="tag_transac_lft_Inv_in1" style="width: 670px; height: 34px;">
                                <asp:RadioButtonList ID="rblPartyType" runat="server" 
                                    RepeatDirection="Horizontal" AutoPostBack="True" 
                                    onselectedindexchanged="rblPartyType_SelectedIndexChanged">
                                    <asp:ListItem Text="General" Value="GN" />
                                    <asp:ListItem Text="Single Party" Value="SN" />
                                    <asp:ListItem Text="Multiple Party" Value="ML" />
                                </asp:RadioButtonList>
                            </div>
                            <div id="tag_transac_lft_Inv_in1" style="width: 670px; height: 34px;">
                                <div id="tag_label_transaction_popup_gen" style="width: 90px">
                                    Party Name
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 530px">
                                    <asp:DropDownList ID="ddlBill_party" runat="server" class="chosen-select-deselect"
                                        Style="width: 350px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                        TabIndex="1" OnSelectedIndexChanged="ddlBill_party_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Inv_in1" style="width: 670px; height: 34px;">
                                <div id="tag_label_transaction_popup_gen" style="width: 90px">
                                    Branch SL No
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 530px">
                                    <asp:DropDownList ID="ddl_Branch" runat="server" class="chosen-select-deselect" Style="width: 120px;"
                                        data-placeholder="Choose a Branch No" TabIndex="2" AutoPostBack="true" OnSelectedIndexChanged="ddl_Branch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Inv_in1" style="width: 670px;">
                                <div id="tag_label_transaction_popup_gen" style="width: 90px">
                                    Address1
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 530px">
                                    <asp:TextBox ID="txtAddress" runat="server" ClientIDMode="Static" TabIndex="3" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Inv_in1" style="width: 670px;">
                                <div id="tag_label_transaction_popup_gen" style="width: 90px">
                                    Address2
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 530px">
                                    <asp:TextBox ID="txtAddress2" runat="server" ClientIDMode="Static" TabIndex="4" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Inv_in1" style="width: 670px;">
                                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                                    Address3
                                </div>
                                <div id="txtcon-m_transaction_Inv_No" style="width: 530px">
                                    <asp:TextBox ID="txtAddress3" runat="server" ClientIDMode="Static" TabIndex="5" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Inv_in1" style="width: 670px;">
                                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                                    Pincode
                                </div>
                                <div id="txtcon-m_transaction_Inv_No" style="width: 530px">
                                    <asp:TextBox ID="tXtPincode" runat="server" MaxLength="35" ClientIDMode="Static"
                                        onkeypress="return phone(event)" TabIndex="5" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Inv_in1" style="width: 670px; height: 34px;">
                                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                                    StateName
                                </div>
                                <div id="txtcon-m_transaction_Inv_No" style="width: 530px">
                                    <asp:XmlDataSource ID="XmlState_Name_Code" runat="server" DataFile="~/Accounts_XML_Data/State_Name_Code.xml"
                                        XPath="ListItems/ListItem"></asp:XmlDataSource>
                                    <asp:DropDownList ID="ddl_state_name" CssClass="listtxt_transac_item_gen_notn" Width="258px"
                                        DataSourceID="XmlState_Name_Code" DataTextField="text" DataValueField="value"
                                        TabIndex="6" ForeColor="Green" runat="server" BackColor="AntiqueWhite">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Inv_in1" style="width: 670px;">
                                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                                    GSTN Number
                                </div>
                                <div id="txtcon-m_transaction_Inv_No" style="width: 530px">
                                    <asp:TextBox ID="txt_GSTN_Num" runat="server" MaxLength="20" ClientIDMode="Static"
                                        TabIndex="7" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div id="pop_text_area_transac_popup_inn_container_rght_IGM" style="height: 260px;
                            width: 300px;">
                            <div id="tag_transac_lft_Inv_in1" style="width: 350px; height: 32px;">
                                <fieldset id="fld" style="width: 340px; height: 225px">
                                    <legend style="border: white; border-collapse: collapse; width: 60px; text-align: center;
                                        height: 12px; margin-left: 60px;">GST Bill </legend>
                                    <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 10px">
                                    </div>
                                    <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 27px">
                                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; color: #0000FF;
                                            margin-left: 10px;">
                                            Tot.Inv count
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 45px;">
                                            <asp:Literal ID="lbl_Inv_Cnt" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 27px">
                                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; color: #0000FF;
                                            margin-left: 10px;">
                                            Invoice No
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 45px;">
                                            <asp:DropDownList ID="ddl_Invno" runat="server" Style="width: 150px;" CssClass="listtxt_transac_src1"
                                                TabIndex="13" AutoPostBack="true" OnSelectedIndexChanged="ddl_Invno_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 27px">
                                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; color: #0000FF;
                                            margin-left: 10px;">
                                            Non-Tax Amount
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 45px;">
                                            <asp:Literal ID="lbl_Non_Tax_Amt" Text="0" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 27px">
                                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; color: #0000FF;
                                            margin-left: 10px;">
                                            Taxabel Amount
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 45px;">
                                            <asp:Literal ID="lbl_taxable_Amt" Text="0" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 27px">
                                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; color: #0000FF;
                                            margin-left: 10px;">
                                            Tax Amount
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 45px;">
                                            <asp:Literal ID="lbl_Tax_Amt" Text="0" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 27px">
                                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; color: #0000FF;
                                            margin-left: 10px;">
                                            Grand Total
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 45px;">
                                            <asp:Literal ID="lbl_Grand_total" Text="0" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 27px">
                                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; color: #0000FF;
                                            margin-left: 10px;">
                                            Report
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 45px;">
                                            <asp:ImageButton ID="btnInv_Rpt" Height="26px" Width="30px" Visible="false" ToolTip="Invoice Report"
                                                ImageUrl="~/images/icons/Bill_pending.jpg" runat="server" OnClientClick="Inv_Bill();return false;" />
                                        </div>
                                    </div>
                                </fieldset>
                                <fieldset id="fld" style="width: 340px; height: 55px">
                                    <legend style="border: white; border-collapse: collapse; width: 100px; text-align: center;
                                        height: 12px; margin-left: 60px;">Job Status </legend>
                                    <div id="tag_transac_lft_Inv_in1" style="width: 270px; height: 10px">
                                    </div>
                                    <div id="tag_transac_lft_Inv_in1" style="width: 340px; height: 27px">
                                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px; color: #0000FF;
                                            margin-left: 10px;">
                                            Sales Bill Job
                                        </div>
                                        <div id="txtcon-m_transaction_Inv_No" style="width: 135px;">
                                            <asp:RadioButtonList ID="Rd_Job_Status" runat="server" RepeatDirection="Horizontal"
                                                TabIndex="91" ForeColor="Purple" AutoPostBack="true" OnSelectedIndexChanged="Rd_Job_Status_SelectedIndexChanged">
                                                <asp:ListItem Text="Open" Value="P" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="margin-top: 4px; width: 600px; height: 40px;">
                            <div id="editbu">
                                <asp:Button ID="btnSave" runat="server" CssClass="save" TabIndex="52" OnClick="btnSave_Click"
                                    CommandName="s" />
                            </div>
                            <div id="editbu" style="width: 95px;">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                    TabIndex="19" OnClientClick="return validate();" />
                            </div>
                            <div id="editbu" style="width: 150px;">
                                <asp:Button ID="btnAcc" CssClass="autowidmovebut" Width="140px" runat="server" OnClick="btnAccounts_Click" />
                            </div>
                            <div id="editbu" style="width: 200px;">
                                <asp:Label ID="lbl_Msg" runat="server" ForeColor="Green"></asp:Label>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="margin-top: -10px; width: 690px; height: 40px;">
                            <span style="color: Red;">Note :- Once Moved or Created Invoice, it Can't be Modified.</span>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2" style="display: none;">
                    <iframe name="trans_igm" scrolling="no" id="Charge_Id_Iframe" style="width: 990px;
                        height: 400px; margin-top: -45px; margin-left: -10px;"></iframe>
                </div>
                <div class="content" id="page-3" style="display: none;">
                    <iframe name="trans_Inv" scrolling="no" id="Inv_Id_Iframe" style="width: 990px; height: 400px;
                        margin-top: -45px; margin-left: -10px;"></iframe>
                </div>
                <div class="content" id="page-4" style="display: none;">
                    <iframe name="trans_rpt" scrolling="no" id="Inv_Rpt_Iframe" style="width: 990px;
                        height: 450px; margin-top: -102px; margin-left: -10px;"></iframe>
                </div>
                <div class="content" id="page-5" style="display: none;">
                    <iframe name="trans" scrolling="no" id="No_Invoice_Id_Iframe" style="width: 990px;
                        height: 480px; margin-top: -35px; margin-left: -15px;"></iframe>
                </div>
                <div style="display: none;">
                    <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5']);
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
        function Inv_Bill() {
            var jobno = '';
            var Bill_Invo = $('#<%= ddl_Invno.ClientID %>').val();
            var Imp_Exp = '';

            if (Bill_Invo != '') {
                NewWindow1('../Accounts_Sales_Inv_Rpt/GST_Imp_Exp_rpt.aspx?Job_Id=' + jobno + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Invo + '', 'List', '870', '1024', 'yes');
            }
            else {
                jAlert('Select Ur Invoice No', 'Bill Invoice', function (r) { document.getElementById("ddl_Invno").focus(); });
            }

        }
    </script>
</body>
</html>
