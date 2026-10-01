<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Other_Receipt_Entry.aspx.cs"
    Inherits="Accounts_Bank_Other_Receipt_Entry" %>

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
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
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
            <div id="innerbox_MidMain_Billing" style="height: 170px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                        Bank Receipt To Others
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
                <div id="tag_transact_src_inner" style="width: 1150px; height: 110px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 100px;">
                        <div id="tag_transact_lft_in1" style="width: 1150px; height: 90px;">
                            <div style="width: 1150px; height: 30px">
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 20px">
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
                                    <div id="txtcon-m_Exchange" style="width: 230px;">
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
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 30px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Bank A/C
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 520px;">
                                        <asp:DropDownList ID="ddl_Bank_From" class="validate[required]  chosen-select-deselect"
                                            Style="width: 390px;" data-placeholder="Choose a BankName" runat="server" TabIndex="6"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Issuer Bank
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 400px;">
                                        <asp:DropDownList ID="ddl_Issuer_Bank_Name" class="validate[required]  chosen-select-deselect"
                                            Style="width: 230px;" data-placeholder="Choose a BankName" runat="server" TabIndex="7">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Axis Bank Ltd." Value="Axis Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="Bandhan Bank Ltd." Value="Bandhan Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="Bank of Baroda" Value="Bank of Baroda"></asp:ListItem>
                                            <asp:ListItem Text="Bank of India" Value="Bank of India"></asp:ListItem>
                                            <asp:ListItem Text="Bank of Maharashtra" Value="Bank of Maharashtra"></asp:ListItem>
                                            <asp:ListItem Text="Canara Bank" Value="Canara Bank"></asp:ListItem>
                                            <asp:ListItem Text="City Union Bank Ltd." Value="City Union Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="CSB Bank Ltd." Value="CSB Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="DCB Bank Ltd." Value="DCB Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="Dhanlaxmi Bank Ltd." Value="Dhanlaxmi Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="Federal Bank Ltd." Value="Federal Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="HDFC Bank Ltd" Value="HDFC Bank Ltd"></asp:ListItem>
                                            <asp:ListItem Text="ICICI Bank Ltd." Value="ICICI Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="IDBI Bank Ltd." Value="IDBI Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="IDFC First Bank Ltd." Value="IDFC First Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="Indian Bank" Value="Indian Bank"></asp:ListItem>
                                            <asp:ListItem Text="Indian Overseas Bank" Value="Indian Overseas Bank"></asp:ListItem>
                                            <asp:ListItem Text="Induslnd Bank Ltd" Value="Induslnd Bank Ltd"></asp:ListItem>
                                            <asp:ListItem Text="Jammu & Kashmir Bank Ltd." Value="Jammu & Kashmir Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="Karnataka Bank Ltd." Value="Karnataka Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="Karur Vysya Bank Ltd." Value="Karur Vysya Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="Kotak Mahindra Bank Ltd" Value="Kotak Mahindra Bank Ltd"></asp:ListItem>
                                            <asp:ListItem Text="Nainital Bank Ltd." Value="Nainital Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="Punjab National Bank" Value="Punjab National Bank"></asp:ListItem>
                                            <asp:ListItem Text="RBL Bank Ltd." Value="RBL Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="South Indian Bank Ltd." Value="South Indian Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="State Bank of India" Value="State Bank of India"></asp:ListItem>
                                            <asp:ListItem Text="Tamilnad Mercantile Bank Ltd." Value="Tamilnad Mercantile Bank Ltd."></asp:ListItem>
                                            <asp:ListItem Text="UCO Bank" Value="UCO Bank"></asp:ListItem>
                                            <asp:ListItem Text="Union Bank of India" Value="Union Bank of India"></asp:ListItem>
                                            <asp:ListItem Text="YES Bank Ltd." Value="YES Bank Ltd."></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:TextBox ID="txt_Issuer_Bank_Accno" Width="140px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="8" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_IGM_in1" style="width: 1150px; height: 25px">
                                    <div id="tag_label_transaction_popup_IGM" style="width: 90px;">
                                        Cr. to Org.
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 460px;">
                                        <asp:DropDownList ID="ddl_Cur" Style="width: 55px;" runat="server" TabIndex="9">
                                            <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp; Ex.Rate &nbsp;
                                        <asp:TextBox ID="txt_Ex_Rate" Width="60px" Text="1.00" Enabled="false" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="10" runat="server"></asp:TextBox>
                                        &nbsp; Cur. Amt &nbsp;
                                        <asp:TextBox ID="txt_Cur_Amt" Width="85px" CssClass="txtbox_none_Mid_transac_code"
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="11"
                                            runat="server" oninput="syncAmounts()"></asp:TextBox>
                                        &nbsp; INR. Amt
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 120px;">
                                        <asp:TextBox ID="txt_INR_Amt" Width="105px" CssClass="txtbox_none_Mid_transac_code"
                                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            TabIndex="12" runat="server" Enabled="False"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 310px;">
                                        <asp:DropDownList ID="ddl_Issuer_Bank_info_Type" Style="width: 78px;" runat="server"
                                            TabIndex="13">
                                            <asp:ListItem Text="Cash" Value="CA"></asp:ListItem>
                                            <asp:ListItem Text="Cheque No." Value="CN"></asp:ListItem>
                                            <asp:ListItem Text="NEFT" Value="NT"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:TextBox ID="txt_Issuer_Bank_info_No" Width="200px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="14" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 35px;">
                                        Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 120px;">
                                        <asp:TextBox ID="txt_Issuer_Bank_info_Date" runat="server" Width="90px" MaxLength="10"
                                            CssClass="txtbox_none_Mid_transac_code" TabIndex="15"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Issuer_Bank_info_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Issuer_Bank_info_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 25px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Reference No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 130px;">
                                        <asp:TextBox ID="txt_Reference" Width="120px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="16" runat="server" Height="20px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Reference Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 115px">
                                        <asp:TextBox ID="txtReference_Date" runat="server" Width="100px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="17" Height="20px"></asp:TextBox>
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
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Narration
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 460px;">
                                        <asp:TextBox ID="txt_Narration" Width="435px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="18" runat="server" Height="20px"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 130px;">
                                        <asp:Button ID="btnsup" runat="server" TabIndex="19" OnClick="btn_Save_Update_Click" />
                                        &nbsp;
                                        <asp:Button ID="btn_JV_Delete" runat="server" TabIndex="19" Text="Delete" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job Entry?', 'Receipt Entry', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn3').click();
                                          }
                                          else {
                                          }
    
                                });return false;" />
                                        <asp:Button ID="btn3" runat="server" TabIndex="19" OnClick="btn_JV_Delete_Click"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content" id="page-1" style="margin-top: -28px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 357px; width: 1142px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');" id="Page_A"
                            runat="server"><span>General </span></a></li>
                    </ol>
                    <div class="content" id="page-6">
                        <div id="tag_Exchange_inner_lft" style="height: 380px; width: 1142px; margin-left: -16px;
                            margin-top: -15px;">
                            <div id="tag_transact_src_inner" style="width: 1138px; height: 75px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1138px">
                                    <div id="tag_transact_lft_in1" style="width: 1138px; height: 55px;">
                                        <div id="txt_container_Transact_Main_l" style="width: 1150px; margin-top: 5px; height: 35px;">
                                            <div id="tag_label_transact_Src" style="width: 70px;">
                                                Charge
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 460px;">
                                                <asp:DropDownList ID="ddlcharge" runat="server" class="chosen-select-deselect" Style="width: 450px;"
                                                    data-placeholder="Choose a Charge Name" TabIndex="21" AutoPostBack="True" OnSelectedIndexChanged="ddlcharge_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                             <div id="tag_label_transact_Src" style="width: 40px;">
                                                Tax
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 40px;">
                                                <asp:DropDownList ID="ddl_Tax" CssClass="listtxt_transac_item_gen_notn" Width="35px"
                                                    runat="server" TabIndex="22">
                                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="T" Value="T"></asp:ListItem>
                                                    <asp:ListItem Text="N" Value="N"></asp:ListItem>
                                                    <asp:ListItem Text="E" Value="E"></asp:ListItem>
                                                    <asp:ListItem Text="R" Value="R"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                             <div id="tag_label_transact_Src" style="width: 100px;">
                                                Sales Bill No
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 190px;">
                                                  <asp:DropDownList ID="ddl_Sales_Billno" runat="server"   
                                                      class="chosen-select-deselect" Style="width: 180px;"
                                                    data-placeholder="Choose a Sales Bill No." TabIndex="23" AutoPostBack="True" 
                                                      onselectedindexchanged="ddl_Sales_Billno_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                            </div>

                                            <div id="tag_label_transact_Src" style="width: 60px;">
                                                Amount
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 100px;">
                                                <asp:TextBox ID="txtAmt" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                                    onkeypress="return blockNonNumbers(this, event, true, false);" runat="server"
                                                    Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code" TabIndex="24"></asp:TextBox>
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 50px;">
                                                <asp:DropDownList ID="ddl_Amt_Type" CssClass="listtxt_transac_item_gen_notn" Width="45px"
                                                    runat="server" TabIndex="25">
                                                    <asp:ListItem Text="CR" Value="CR"></asp:ListItem>
                                                   <%-- <asp:ListItem Text="DR" Value="DR"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </div>
                                            
                                           
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 1150px; margin-top: -2px;">
                                            <div id="tag_label_transact_Src" style="width: 70px;">
                                                Narration
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 460px;">
                                                <asp:TextBox ID="txtNarration" runat="server" Width="445px" CssClass="txtbox_none_Mid_transac_code"
                                                    TabIndex="26" Height="20px"></asp:TextBox>
                                            </div>
                                            <div id="tag_label_transact_Src" style="width: 50px;">
                                                Branch
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 150px;">
                                                <asp:DropDownList ID="ddl_Exp_Branch" CssClass="listtxt_transac_item_gen_notn" Width="130px"
                                                    runat="server" TabIndex="27">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
                            <div id="tag_label_transact_Src" style="width: 300px">
                                <asp:Label ID="lblTotalAdjustment" runat="server" Style="font-weight: bold; color: red;"></asp:Label>
                            </div>
                            <div id="tag_transact_lft_in1" style="width: 1138px; height: 220px; overflow: auto;">
                                <asp:GridView ID="gvAll" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="WhiteSmoke" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                    OnRowCreated="gvAll_RowCreated" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                                    DataKeyNames="CHARGE_ID" EmptyDataText="NO RECORD FOUND" OnSelectedIndexChanged="gvAll_SelectedIndexChanged"
                                    PageSize="5000" ShowHeaderWhenEmpty="True" Width="100%" OnRowDataBound="gvAll_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        BorderWidth="1px" />
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
                                        <asp:BoundField DataField="CHARGE_ID" HeaderText="Charge Id">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CHARGE_NAME" HeaderText="Charge Name" HeaderStyle-Width="500px">
                                            <ItemStyle CssClass="column_style_left5" Width="500px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AMOUNT" HeaderText="Amount" HeaderStyle-Width="90px">
                                            <ItemStyle CssClass="column_style_left5" Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AMOUNT_TYPE" HeaderText="Cr/Dr" HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BRANCH" HeaderText="Branch" HeaderStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left5" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TAX" HeaderText="Tax" HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NARRATION" HeaderText="Narration" HeaderStyle-Width="400px">
                                            <ItemStyle CssClass="column_style_left5" Width="400px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SALES_BILL_INV_NO" HeaderText="Sales Bill No" HeaderStyle-Width="200px">
                                            <ItemStyle CssClass="column_style_left5" Width="200px" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
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
            <asp:HiddenField ID="HiddenField1_FLAG" runat="server" />
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


        function calculateTotal() {
            var totalAmount = 0;
            var gridView = document.getElementById("<%= gvAll.ClientID %>");
            var rows = gridView.getElementsByTagName("tr");
            for (var i = 1; i < rows.length; i++) {
                var amountCell = rows[i].cells[4];
                if (amountCell) {
                    var amountText = amountCell.innerText.trim();
                    var amountValue = parseFloat(amountText);
                    if (!isNaN(amountValue)) {
                        totalAmount += amountValue;
                    }
                } else {

                }
            }
            document.getElementById('<%= lblTotalAdjustment.ClientID %>').innerText = "Total Amount: " + totalAmount.toFixed(2);
            document.getElementById("Hidden_lblTotal").value = totalAmount.toFixed(2);
        }

        window.onload = function () {
            calculateTotal();
        };


    </script>
</body>
</html>
