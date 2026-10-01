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
            <div id="innerbox_MidMain_Transact_popup_new" style="height: 70px">
                <div id="tag_srcinner1_new">
                    <div id="Div1">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Other Jobs Entry</div>
                    <div id="popupwindow_closebut_right_new" style="height: 30px; width: 23px">
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                </div>
                <div id="tag_transaction_inner_new" style="margin-left: 10px">
                    <div id="txtcon-m_Exchange" style="width: 120px;">
                        <asp:RadioButtonList ID="Rd_Imp_Exp" runat="server" RepeatDirection="Horizontal"
                            TabIndex="1">
                            <asp:ListItem Text="Imp" Value="I" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="tag_label_transaction_Src_new" style="width: 50px; margin-top: 6px;">
                        Job No
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 250px;">
                        <asp:TextBox ID="txtjobNo_PR" runat="server" TabIndex="2" Width="75px" oninput="syncjobno()"
                            Height="20px" MaxLength="100" placeholder="PREFIX" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                        <asp:TextBox ID="txtjobNo" runat="server" TabIndex="3" Style="text-align: right;"
                            Width="70px" oninput="syncjobno()" placeholder="JOBNO" Height="20px" MaxLength="100"
                            CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                        <asp:TextBox ID="txtjobNo_SF" runat="server" TabIndex="5" Width="75px" oninput="syncjobno()"
                            Height="20px" MaxLength="100" placeholder="SUFFIX" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_Src_new" style="width: 180px; margin-left: 20px">
                        <asp:TextBox ID="txtjobps" runat="server" Font-Bold="true" Font-Size="12px" BackColor="#e7e6e6"
                            runat="server" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big" Width="157px" TabIndex="6"
                            Height="20px"></asp:TextBox>
                    </div>
                     <div id="tag_label_transaction_Src_new" style="width: 50px; margin-top: 6px;">
                        Mode
                    </div>
                       <div id="tag_label_transaction_Src_new" style="width: 220px;">
                        <asp:DropDownList ID="ddl_mode" runat="server" Width="65px" Height="22px"
                                    Font-Size="12px" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new_add_big" TabIndex="7"
                                    >
                                    <asp:ListItem text="Air" Value="A"></asp:ListItem>
                                    <asp:ListItem text="Sea" Value="S"></asp:ListItem>
                                    <asp:ListItem text="Land" Value="L"></asp:ListItem>
                                  
                                </asp:DropDownList>
                     </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');other_tab_page1();"
                        id="bill" style="height: 27px"><span>Bill to Party</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');other_charge_tab_page2();"
                        runat="server" id="Charge_Id" style="height: 27px; display: none;"><span>Charges</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="tag_srcinner1_annexurec_air_main_cont2">
                        <div id="annexure_c_main">
                            <div id="pop_text_area_transac_popup_inn_container_left_export">
                                <div id="tag_transac_lft_in1_export" style="height: 30px">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Bill Party Name</div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                        <asp:DropDownList ID="ddlBill_party" runat="server" class="chosen-select-deselect"
                                            Style="width: 350px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                            TabIndex="7" OnSelectedIndexChanged="ddlBill_party_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1_export" style="height: 35px; width: 505px;">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Branch SL No</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 130px">
                                        <asp:DropDownList ID="ddl_Branch" runat="server" class="chosen-select-deselect" Style="width: 120px;"
                                            data-placeholder="Choose a Branch No" TabIndex="8" AutoPostBack="true" OnSelectedIndexChanged="ddl_Branch_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1_export" style="width: 505px">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Address1
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                        <asp:TextBox ID="txtAddress" runat="server" ClientIDMode="Static" TabIndex="9" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1_export" style="width: 505px">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Address2
                                    </div>
                                    <div id="txtcon-m_transaction_Inv_No">
                                        <asp:TextBox ID="txtAddress2" runat="server" ClientIDMode="Static" TabIndex="10"
                                            CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1_export" style="width: 505px">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Address3
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                        <asp:TextBox ID="txtAddress3" runat="server" ClientIDMode="Static" TabIndex="11"
                                            CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1_export" style="width: 505px">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Pincode
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                        <asp:TextBox ID="tXtPincode" runat="server" MaxLength="35" ClientIDMode="Static"
                                            onkeypress="return phone(event)" TabIndex="12" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1_export" style="width: 505px">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        StateName
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="height: 30px; width: 285px;">
                                        <asp:XmlDataSource ID="XmlState_Name_Code" runat="server" DataFile="~/Accounts_XML_Data/State_Name_Code.xml"
                                        XPath="ListItems/ListItem"></asp:XmlDataSource>
                                    <asp:DropDownList ID="ddl_state_name" CssClass="listtxt_transac_item_gen_notn" Width="258px"
                                        DataSourceID="XmlState_Name_Code" DataTextField="text" DataValueField="value"
                                        TabIndex="13" ForeColor="Green" runat="server" BackColor="AntiqueWhite">
                                    </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1_export" style="height: 30px; width: 505px;">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        GSTN Number</div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 200px">
                                        <asp:TextBox ID="txt_GSTN_Num" runat="server" MaxLength="20" ClientIDMode="Static"
                                            TabIndex="14" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="innerbox_MidMain_bot_transact_invoice" style="margin-top: 55px">
                                    <div id="editbu">
                                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate1();"
                                            TabIndex="18" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                            TabIndex="19" OnClientClick="return validate();" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnDelete" runat="server" TabIndex="21" Visible="false" CssClass="dlete"
                                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Other Jobs', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                        <asp:Button ID="btn" runat="server" TabIndex="20" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Parent_close_button1();return false;"
                                            TabIndex="79" CausesValidation="false" UseSubmitBehavior="false" />
                                    </div>
                                    <div id="editbu">
                                    </div>
                                    <div id="editbu" style="width: 150px;">
                                        <asp:Button ID="btnAcc" CssClass="autowidmovebut" Width="140px" runat="server" OnClick="btnAccounts_Click"
                                            Text="Move To Accounts" />
                                    </div>
                                    <div id="editbu" style="width: 150px; display: none;">
                                        <%--<asp:Button ID="Button1" CssClass="autowidmovebut" Width="140px" runat="server" OnClick="btn_Accounts_Click" />--%>
                                    </div>
                                    <div id="editbu">
                                        <asp:Literal ID="lbl_Msg" runat="server"></asp:Literal>
                                    </div>
                                    <div id="editbu">
                                        <asp:Label ID="lbl_Acc_Msg" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2" style="display: none;">
                    <iframe name="trans_igm" scrolling="no" id="Charge_Id_Iframe" style="width: 990px;
                        height: 400px; margin-left: -10px;"></iframe>
                </div>
                <div style="display: none;">
                    <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />
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


        function syncjobno() {
            var job_PR = document.getElementById("txtjobNo_PR").value;
            var jobNo = document.getElementById("txtjobNo").value;
            var job_SF = document.getElementById("txtjobNo_SF").value;
            document.getElementById("txtjobps").value = job_PR + jobNo + job_SF;
        }

        window.onload = function () {
            document.getElementById('bill').click();
            syncjobno();
        };


      

    </script>
</body>
</html>
