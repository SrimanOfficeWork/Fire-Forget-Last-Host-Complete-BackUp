<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receipt_Entry_Cash_Deposite.aspx.cs"
    Inherits="Accounts_Bank_Receipt_Entry_Cash_Deposite" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Billing" style="height: 225px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                        Bank Receipt To Cash Deposite
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                        <div id="txtcon-m_Exchange" style="width: 220px; margin-top: 5px;">
                        </div>
                        <div id="verslic">
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px; margin-top: 5px;">
                            Company Lic
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px; margin-top: 5px; color: Red;">
                            <asp:Literal ID="lbl_Job_Company_Lic" runat="server"></asp:Literal>
                        </div>
                        <div id="verslic">
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px; margin-top: 5px;">
                            Working Period
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 250px; margin-top: 5px; color: Red;">
                            <asp:Literal ID="lbl_Job_Wrk_Period" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px; height: 180px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 180px;">
                        <div id="tag_transact_lft_in1" style="width: 1150px; height: 90px;">
                            <div style="width: 1150px; height: 40px">
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 30px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Trans No.
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 200px;">
                                        <asp:TextBox ID="txt_BR_No_F" runat="server" TabIndex="1" ReadOnly="true" BackColor="#e7e6e6"
                                            Width="35px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                        <asp:TextBox ID="txt_BR_No_M" runat="server" TabIndex="2" ReadOnly="true" BackColor="#e7e6e6"
                                            Style="text-align: right;" Width="60px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                        <asp:TextBox ID="txt_BR_No_L" runat="server" TabIndex="3" ReadOnly="true" BackColor="#e7e6e6"
                                            Width="60px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 210px;">
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Entry Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 158px;">
                                        <asp:TextBox ID="txt_BR_Entry_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            BackColor="#e7e6e6" TabIndex="4" Enabled="false"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_BR_Entry_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_BR_Entry_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 85px;">
                                        Posting Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 120px;">
                                        <asp:TextBox ID="txt_Posting_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="5"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_Posting_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_Posting_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 35px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Bank A/C
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 500px;">
                                        <asp:DropDownList ID="ddl_Bank_From" class="validate[required]  chosen-select-deselect"
                                            Style="width: 390px;" data-placeholder="Choose a BankName" runat="server" TabIndex="6"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Narration
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 400px;">
                                        <asp:TextBox ID="txt_Narration" Width="435px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="7" runat="server" Height="25px"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_IGM_in1" style="width: 1150px; height: 30px">
                                    <div id="tag_label_transaction_popup_IGM" style="width: 90px;">
                                        Cr. to Org.
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 460px;">
                                        <asp:DropDownList ID="ddl_Cur" Style="width: 55px;" runat="server" TabIndex="8">
                                            <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp; Ex.Rate &nbsp;
                                        <asp:TextBox ID="txt_Ex_Rate" Width="60px" Text="1.00" Enabled="false" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="10" runat="server"></asp:TextBox>
                                        &nbsp; Cur. Amt &nbsp;
                                        <asp:TextBox ID="txt_Cur_Amt" Width="85px" CssClass="txtbox_none_Mid_transac_code"
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="9" runat="server"
                                            oninput="syncAmounts()"></asp:TextBox>
                                        &nbsp; INR. Amt
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 120px;">
                                        <asp:TextBox ID="txt_INR_Amt" Width="105px" CssClass="txtbox_none_Mid_transac_code"
                                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            TabIndex="10" runat="server" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 30px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Reference No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 130px;">
                                        <asp:TextBox ID="txt_Reference" Width="120px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="11" runat="server" Height="20px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Reference Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 115px">
                                        <asp:TextBox ID="txtReference_Date" runat="server" Width="100px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="12" Height="20px"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtReference_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtReference_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content" id="page-1" style="margin-top: -28px;">
                <div id="innerbox_MidMain_bot_transact" style="margin-top: 0px; width: 500px;">
                    <div id="innerbox_transac_bot_inn" style="width: 500px;">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" TabIndex="30" CssClass="new" OnClick="btnNew_Click"
                                OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                                UseSubmitBehavior="false" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" CommandName="s"
                                OnClientClick="return validate();" TabIndex="27" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                                OnClick="btnUpdate_Click" Visible="false" TabIndex="28" OnClientClick="return validation();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="29" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Receipt', function(r) {
                  var i = r + 'ok';
                  if(i == 'trueok')
                  {
                      document.getElementById('btn').click();
            
                  }
                  else {
                  }
                    });return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="53" CausesValidation="false" UseSubmitBehavior="false"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Trans_new" style="height: 377px; width: 1142px; margin-left: -16px;
                    margin-top: -5px; display: none;">
                </div>
            </div>
            </div> </div> </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HD_Ch_update_id" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hf_Bal" runat="server" />
            <asp:HiddenField ID="Hd_row_id" runat="server" />
            <asp:HiddenField ID="Hidden_iNR" runat="server" />
            <asp:HiddenField ID="Hidden_lblTotal" runat="server" />
            <asp:HiddenField ID="Hidden_ch_amt" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/Accounts/Acc_iframepopupwin.js"></script>
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
    <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });


        function close_button() {
            document.getElementById("General").click();
        }
        

    </script>
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


        function syncAmounts() {
            document.getElementById("Hidden_iNR").value = "";
            var curAmt = document.getElementById("txt_Cur_Amt").value;
            document.getElementById("txt_INR_Amt").value = curAmt;
            document.getElementById("Hidden_iNR").value = curAmt;
        }

    </script>
</body>
</html>
