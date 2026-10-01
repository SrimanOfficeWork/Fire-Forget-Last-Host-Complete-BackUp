<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Bill_To_Party.aspx.cs"
    Inherits="Export_Acc_Bill_To_Party" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
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
        .form-check
        {
            min-height: 1.5rem;
            margin-bottom: .125rem;
        }
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
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');charge_tab_page2();"
                        runat="server" id="Charge_Id" style="height: 20px"><span>Charges</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');Exp_Inv_tab_page3();"
                        runat="server" id="Inv_ID" style="height: 20px" visible="False"><span>Create Invoice</span></a></li>
                    <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');Exp_NoInv_tab_page5();"
                        runat="server" id="No_Invoice_Id" style="height: 20px" visible="False"><span>No of Invoice</span></a></li>
                    <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');charge_tab_page4();"
                        runat="server" id="Acc_Rpt" style="height: 20px"><span>Profit & Loss</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 990px;
                        height: 390px; background-color: #FFFFFF;">
                        <div id="tag_transac_lft_Inv_in1" style="height: 250px; width: 500px; margin-top: -15px;">
                            <div id="tag_transac_lft_Inv_in1" style="display: flex; align-items: center; gap: 5px;">
                                <div id="tag_label_transaction_popup_gen" style="width: 90px;">
                                    Shipment No</div>
                                <asp:TextBox ID="txtShipment_pf" runat="server" CssClass="form-control" Style="width: 30px;
                                    height: 10px;"></asp:TextBox>
                                <asp:TextBox ID="txtShipment_No" runat="server" CssClass="form-control" Style="width: 50px;
                                    height: 10px;"></asp:TextBox>
                                <asp:TextBox ID="txtShipment_sf" runat="server" CssClass="form-control" Style="width: 45px;
                                    height: 10px;"></asp:TextBox>
                                <div class="form-check form-switch">
                                    <input class="form-check-input" runat="server" type="checkbox" id="flexSwitchCheckDefault" />
                                    <asp:Label ID="Sin" runat="server" CssClass="form-check-label" Text="Single" />
                                </div>
                                <div class="form-check form-switch">
                                    <input class="form-check-input" runat="server" type="checkbox" id="flexSwitchCheckChecked" />
                                    <asp:Label ID="Mul" runat="server" CssClass="form-check-label" Text="Multiple" />
                                </div>
                            </div>
                            <div id="tag_transac_lft_Inv_in1" style="width: 455px; height: 34px;">
                                <asp:RadioButtonList ID="rblPartyType" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True" OnSelectedIndexChanged="rblPartyType_SelectedIndexChanged">
                                    <asp:ListItem Text="General" Value="GN" />
                                    <asp:ListItem Text="Single Party" Value="SN" />
                                    <asp:ListItem Text="Multiple Party" Value="ML" />
                                </asp:RadioButtonList>
                            </div>
                            <div id="tag_transac_lft_Inv_in1" style="width: 670px; height: 27px;">
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
                                    <%--<asp:DropDownList ID="ddl_state_name" runat="server" class="chosen-select-deselect"
                                        Style="width: 258px;" data-placeholder="Choose a State Name" TabIndex="6">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="01--JAMMU & KASHMIR" Value="01"></asp:ListItem>
                                        <asp:ListItem Text="02--HIMACHAL PRADESH" Value="02"></asp:ListItem>
                                        <asp:ListItem Text="03--PUNJAB" Value="03"></asp:ListItem>
                                        <asp:ListItem Text="04--CHANDIGARH" Value="04"></asp:ListItem>
                                        <asp:ListItem Text="05--UTTARAKHAND" Value="05"></asp:ListItem>
                                        <asp:ListItem Text="06--HARYANA" Value="06"></asp:ListItem>
                                        <asp:ListItem Text="07--DELHI" Value="07"></asp:ListItem>
                                        <asp:ListItem Text="08--RAJASTHAN" Value="08"></asp:ListItem>
                                        <asp:ListItem Text="09--UTTAR PRADESH" Value="09"></asp:ListItem>
                                        <asp:ListItem Text="10--BIHAR" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11--SIKKIM" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12--ARUNACHAL PRADESH" Value="12"></asp:ListItem>
                                        <asp:ListItem Text="13--NAGALAND" Value="13"></asp:ListItem>
                                        <asp:ListItem Text="14--MANIPUR" Value="14"></asp:ListItem>
                                        <asp:ListItem Text="15--MIZORAM" Value="15"></asp:ListItem>
                                        <asp:ListItem Text="16--TRIPURA" Value="16"></asp:ListItem>
                                        <asp:ListItem Text="17--MEGHALAYA" Value="17"></asp:ListItem>
                                        <asp:ListItem Text="18--ASSAM" Value="18"></asp:ListItem>
                                        <asp:ListItem Text="19--WEST BENGAL" Value="19"></asp:ListItem>
                                        <asp:ListItem Text="20--JHARKHAND" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="21--ORISSA" Value="21"></asp:ListItem>
                                        <asp:ListItem Text="22--CHATTISGARH" Value="22"></asp:ListItem>
                                        <asp:ListItem Text="23--MADHYA PRADESH" Value="23"></asp:ListItem>
                                        <asp:ListItem Text="24--GUJARAT" Value="24"></asp:ListItem>
                                        <asp:ListItem Text="25--DAMAN & DIU" Value="25"></asp:ListItem>
                                        <asp:ListItem Text="26--DADRA & NAGAR HAVELI" Value="26"></asp:ListItem>
                                        <asp:ListItem Text="27--MAHARASHTRA" Value="27"></asp:ListItem>
                                        <asp:ListItem Text="29--KARNATAKA" Value="29"></asp:ListItem>
                                        <asp:ListItem Text="30--GOA" Value="30"></asp:ListItem>
                                        <asp:ListItem Text="31--LAKSHADWEEP" Value="31"></asp:ListItem>
                                        <asp:ListItem Text="32--KERALA" Value="32"></asp:ListItem>
                                        <asp:ListItem Text="33--TAMILNADU" Value="33"></asp:ListItem>
                                        <asp:ListItem Text="33--TAMIL NADU" Value="33"></asp:ListItem>
                                        <asp:ListItem Text="34--PONDICHERRY" Value="34"></asp:ListItem>
                                        <asp:ListItem Text="35--ANDAMAN & NICOBAR" Value="35"></asp:ListItem>
                                        <asp:ListItem Text="36--TELANGANA" Value="36"></asp:ListItem>
                                        <asp:ListItem Text="37--ANDHRA PRADESH" Value="37"></asp:ListItem>
                                    </asp:DropDownList>--%>
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
                        <div id="tag_transac_lft_Inv_in1" style="margin-top: -1px; width: 600px; height: 40px;">
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
                        <div id="tag_transac_lft_Inv_in1" style="margin-top: 5px; width: 690px; height: 40px;">
                            <span style="color: Red;">Note :- Once Moved or Created Invoice, it Can't be Modified.</span>
                        </div>
                        <div id="Div1" style="width: 95px;display:none">
                                <asp:Button ID="Button1" runat="server" CssClass="updates" OnClick="btnload_Click"
                                    TabIndex="19" OnClientClick="return validate();" />
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
    <script type="text/javascript">
document.addEventListener('DOMContentLoaded', function () {
    const single = document.getElementById('flexSwitchCheckDefault');
    const multiple = document.getElementById('flexSwitchCheckChecked');

    single.addEventListener('change', function () {
        if (this.checked) {
            multiple.checked = false;
             LoadShipment('Single'); 
        }
    });

    multiple.addEventListener('change', function () {
        if (this.checked) {
            single.checked = false;
              LoadShipment('Multiple'); 
        }
    });
});



function LoadShipment(type) {
    var JOBNO_PS = '<%= Session["JOBNO_PS"] != null ? Session["JOBNO_PS"].ToString() : "" %>';
    var SHIPMENT_TYPE = type;
  
  if(document.getElementById('<%= txtShipment_No.ClientID %>').value== "")
  {
    PageMethods.LoadShipmentNo('LOAD_SHIPMENT_NO', JOBNO_PS, SHIPMENT_TYPE,
        function(result) {
            if (result && SHIPMENT_TYPE === 'Single') {
                document.getElementById('<%= txtShipment_pf.ClientID %>').value = result.prefix;
                document.getElementById('<%= txtShipment_No.ClientID %>').value = result.number;
                document.getElementById('<%= txtShipment_sf.ClientID %>').value = result.suffix;
               
            } else if (SHIPMENT_TYPE !== 'Single') {
                var queryStr = 'SHIPMENTTYPE=' + SHIPMENT_TYPE;
                NewWindow1('Acc_Shipment_No_Detail.aspx?' + queryStr, 'ShipmentPopup', 
                    '700','350','yes');
            }
        },
        function(error) {
            alert('Error: ' + error.get_message());
        }
    );
    }else{
       return confirm("Shipment No Already assigned");
    }
}

 
</script>
</body>
</html>
