<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiptEntry.aspx.cs" Inherits="ReceiptEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Bank Receipt Entry </title>
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
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.4/jquery-confirm.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.4/jquery-confirm.min.css" />
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
            <div id="" style="background-color: White; height: 270px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                        Bank Receipt Entry
                    </div>
                    <%-- <div id="verslic">
                    </div>--%>
                    <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                        <div id="txtcon-m_Exchange" style="width: 220px; margin-top: 5px;">
                        </div>
                        <%-- <div id="verslic">
                        </div>--%>
                        <div id="txtcon-m_Exchange" style="width: 100px; margin-top: 5px;">
                            Company Lic
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px; margin-top: 5px; color: Red;">
                            <asp:Literal ID="lbl_Job_Company_Lic" runat="server"></asp:Literal>
                        </div>
                        <%--<div id="verslic">
                        </div>--%>
                        <div id="txtcon-m_Exchange" style="width: 110px; margin-top: 5px;">
                            Working Period
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 250px; margin-top: 5px; color: Red;">
                            <asp:Literal ID="lbl_Job_Wrk_Period" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px; height: 110px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 100px;">
                        <div id="tag_transact_lft_in1" style="width: 1150px; height: 90px;">
                            <div style="width: 1150px; height: 30px; margin-top: -13px;">
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
                                    <div id="txtcon-m_Exchange" style="width: 260px;">
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
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Bank A/C
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 550px;">
                                        <asp:DropDownList ID="ddl_Bank_From" class="validate[required]  chosen-select-deselect"
                                          OnSelectedIndexChanged="ddl_Bank_From_SelectedIndexChanged" AutoPostBack="true"
                                            Style="width: 430px;" data-placeholder="Choose a BankName" runat="server" TabIndex="6">
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
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Organaization
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 550px;">
                                        <asp:DropDownList ID="ddlPartyname" class="chosen-select-deselect" Style="width: 430px;"
                                            data-placeholder="Choose a Partyname" AutoPostBack="true" OnSelectedIndexChanged="ddlPartyname_SelectedIndexChanged"
                                            runat="server" TabIndex="9">
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:DropDownList ID="ddlPartyBranch" class="chosen-select-deselect" Style="width: 75px;"
                                            data-placeholder="Br. No" runat="server" TabIndex="10">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 330px;">
                                        <asp:DropDownList ID="ddl_Issuer_Bank_info_Type" Style="width: 78px;" runat="server"
                                            TabIndex="11">
                                            <asp:ListItem Text="Cash" Value="CA"></asp:ListItem>
                                            <asp:ListItem Text="Cheque No." Value="CN"></asp:ListItem>
                                            <asp:ListItem Text="NEFT" Value="NT"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:TextBox ID="txt_Issuer_Bank_info_No" Width="225px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="12" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 35px;">
                                        Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 120px;">
                                        <asp:TextBox ID="txt_Issuer_Bank_info_Date" runat="server" Width="90px" MaxLength="10"
                                            CssClass="txtbox_none_Mid_transac_code" TabIndex="13"></asp:TextBox>
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
                                <%------------------------%>
                                <div id="txt_container_Transact_Main_l" style="width: 1250px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Cr. to Org.
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 165px;">
                                        <asp:DropDownList ID="ddl_Cur" Style="width: 75px;" runat="server" TabIndex="14">
                                            <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 60px;">
                                        Ex.Rate
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 80px;">
                                        <asp:TextBox ID="txt_Ex_Rate" Width="60px" Text="1.00" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="15" runat="server" BackColor="#B2B2B2"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                        <asp:TextBox ID="txt_Cur_Amt" Width="85px" CssClass="txtbox_none_Mid_transac_code"
                                            Text="0.00" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);Clear_Dot(this);Tds_Calculation();syncDrToOrgInr();"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="16"
                                            runat="server" oninput="syncAmounts()" onchange="Tds_Calculation()"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 36px;">
                                        INR.
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        <asp:TextBox ID="txt_INR_Amt" Width="95px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="17" runat="server" BackColor="#A8A8A8"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Adjustment For
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 135px;">
                                        <asp:DropDownList ID="ddl_Adjustment_for" Style="width: 130px;" runat="server" TabIndex="18">
                                            <asp:ListItem Text="Self" Value="Self"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <%------------------------%>
                                <div id="txt_container_Transact_Main_l" style="width: 1250px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        TDS Deducted
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 50px;">
                                        <asp:DropDownList ID="ddl_TDS_Deducted" Style="width: 47px;" runat="server" 
                                      TabIndex="20">
                                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 60px;">
                                        TDS Sec.</div>
                                    <div id="txtcon-m_Exchange" style="width: 55px;">
                                        <asp:DropDownList ID="ddlTDS_Section" Width="55px" TabIndex="21" runat="server" CssClass="listtxt_transac_mode_new">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="192B" Value="192B"></asp:ListItem>
                                            <asp:ListItem Text="194A" Value="194A"></asp:ListItem>
                                            <asp:ListItem Text="194B" Value="194B"></asp:ListItem>
                                            <asp:ListItem Text="194C" Value="194C"></asp:ListItem>
                                            <asp:ListItem Text="194D" Value="194D"></asp:ListItem>
                                            <asp:ListItem Text="194H" Value="194H"></asp:ListItem>
                                            <asp:ListItem Text="194I" Value="194I"></asp:ListItem>
                                            <asp:ListItem Text="194Ia" Value="194Ia"></asp:ListItem>
                                            <asp:ListItem Text="194Ib" Value="194Ib"></asp:ListItem>
                                            <asp:ListItem Text="194J" Value="194J"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 60px;">
                                        TDS Rate
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 80px;">
                                        <asp:TextBox ID="txt_TDS_Rate" runat="server" CssClass="txtbox_none" Width="50px"
                                            Height="15px" onkeyup="extractNumber(this,2,false); Clear_Dot(this);synctDS();"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="22"
                                            BackColor="#B1E6A3"></asp:TextBox>
                                        <span style="font-size: 12px;">% </span>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                    <asp:TextBox ID="txt_TDS_Deducted_Inr" Width="85px" CssClass="txtbox_none_Mid_transac_code"
                                            Text="0.00" onkeyup="extractNumber(this,2,false); Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" 
                                            TabIndex="23" runat="server" BackColor="#B2B2B2"></asp:TextBox>
                                        
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 36px;">
                                        INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txt_TDS_Deducted_Inr_II" Width="95px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="23" runat="server" BackColor="#B2B2B2"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Narration
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 390px;">
                                        <asp:TextBox ID="txt_Narration" Width="380px" CssClass="txtbox_none_Mid_transac_item_gen_decs_EXP"
                                            TextMode="MultiLine" Height="50px" TabIndex="40" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <%------------------------%>
                                <div id="txt_container_Transact_Main_l" style="width: 1170px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 190px;">
                                        Orgin Bank Charge / GST TDS
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 175px;">
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 30px;">
                                        INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                        <asp:TextBox ID="txt_Orgin_Bank_Charge_TDS_I" Width="85px" CssClass="txtbox_none_Mid_transac_code"
                                            onkeyup="extractNumber(this,2,false);Clear_Dot(this);syncOrgToInr();" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            onchange="Tds_Calculation();" onblur="Tds_Calculation();" TabIndex="31" runat="server"
                                            Text="0.00" BackColor="#EDEDED"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 36px;">
                                        INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txt_Orgin_Bank_Charge_TDS_II" Width="95px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="32" runat="server" BackColor="#B2B2B2"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 90px;">
                                    </div>
                                </div>
                                <%------------------------%>
                                <div id="txt_container_Transact_Main_l" style="width: 1170px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 190px;">
                                        Recd From Organization
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 175px;">
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 30px;">
                                        INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                        <asp:TextBox ID="txt_Rec_From_Org_I" Text="0.00" Width="85px" CssClass="txtbox_none_Mid_transac_code"
                                            onkeyup="extractNumber(this,2,false); Clear_Dot(this);syncRecFromOrg();" onkeypress="return blockNonNumbers(this, event, true, false);"
                                           TabIndex="33" runat="server"
                                            BackColor="#EDEDED"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 36px;">
                                        INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txt_Rec_From_Org_II" Width="95px" Text="0.00" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="34" runat="server" BackColor="#B2B2B2"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 90px;">
                                    </div>
                                </div>
                                <%-------------------------------------%>
                                <div id="txt_container_Transact_Main_l" style="width: 1170px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Bank Charges
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 275px;">
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 30px;">
                                        INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                        <asp:TextBox ID="txt_bank_Charge_I" Text="0.00" Width="85px" CssClass="txtbox_none_Mid_transac_code"
                                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            onchange="Tds_Calculation();" onblur="Tds_Calculation();" TabIndex="35" runat="server"
                                            BackColor="#B2B2B2"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 36px;">
                                        INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txt_bank_Charge_II" Text="0.00" Width="95px" CssClass="txtbox_none_Mid_transac_code"
                                            onkeyup="extractNumber(this,2,false); Clear_Dot(this);syncbankChargeOrg()" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            onchange="Tds_Calculation();" TabIndex="36" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        <%--Narration--%>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 390px;">
                                        <%-- <asp:TextBox ID="txt_Narration" Width="380px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="21" runat="server"></asp:TextBox>--%>
                                    </div>
                                </div>
                                <%-------------------------------%>
                                <div id="txt_container_Transact_Main_l" style="width: 1250px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Debit to Bank
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 50px;">
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 60px;">
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 85px;">
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 30px;">
                                        INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 80px;">
                                        <asp:TextBox ID="txt_Debit_to_bank_I" Enabled="false" Text="1.00" runat="server"
                                            CssClass="txtbox_none" Width="65px" Height="15px" onchange="Tds_Calculation();"
                                            onblur="Tds_Calculation();" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="37"
                                            BackColor="#B2B2B2"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                        <asp:TextBox ID="txt_Debit_to_bank_II" Width="85px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="38" runat="server" BackColor="#B2B2B2"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 36px;">
                                        INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                        <asp:TextBox ID="txtcredit_Bank" Width="95px" CssClass="txtbox_none_Mid_transac_code"
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false); Clear_Dot(this);syncDebitbankToInr();"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="39"
                                            Text="0.00" runat="server" BackColor="#81F7BE"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 90px;">
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 50px;">
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 10px;">
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 130px;">
                                        <asp:Button ID="btnsup" runat="server" TabIndex="25" OnClick="btn_Save_Update_Click" />
                                        &nbsp;
                                        <asp:Button ID="btn_JV_Delete" runat="server" TabIndex="40" Text="Delete" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job Entry?', 'Receipt Entry', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn3').click();
                                          }
                                          else {
                                          }
    
                                         });return false;" />
                                        <asp:Button ID="btn3" runat="server" TabIndex="98" OnClick="btn_JV_Delete_Click"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                    </div>
                                </div>
                                <%------------------------%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content" id="page-1" style="margin-top: -28px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 279px; width: 1142px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');" id="Page_A"
                            runat="server"><span>General </span></a></li>
                    </ol>
                    <div class="content" id="page-6">
                        <div id="innerbox_MidMain_Trans_new" style="height: 250px; width: 1142px; margin-left: -16px;
                            margin-top: -15px;">
                            <div id="tag_transact_src_inner" style="width: 1138px; height: 30px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1138px">
                                    <div id="tag_transact_lft_in1" style="width: 1138px; height: 35px;">
                                        <div id="txt_container_Transact_Main_l" style="width: 1150px; margin-top: -2px;">
                                            <div id="tag_label_transact_Src" style="width: 100px;">
                                                Bill From Date
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 110px;">
                                                <asp:TextBox ID="txtFromdate" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                    TabIndex="41"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromdate"
                                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                </asp:MaskedEditExtender>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromdate"
                                                    Format="dd/MM/yyyy">
                                                </asp:CalendarExtender>
                                            </div>
                                            <div id="tag_label_transact_Src" style="width: 60px;">
                                                To Date
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 110px;">
                                                <asp:TextBox ID="txtTodate" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                    TabIndex="42"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtTodate"
                                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                </asp:MaskedEditExtender>
                                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtTodate"
                                                    Format="dd/MM/yyyy">
                                                </asp:CalendarExtender>
                                            </div>
                                            <div id="tag_label_transact_Src" style="width: 60px;">
                                                Month
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 170px;">
                                                <asp:DropDownList ID="ddlMonth" CssClass="txtbox_none" Width="150px" TabIndex="43"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <div id="tag_label_transact_Src" style="width: 60px;">
                                                Branch
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 140px;">
                                                <asp:DropDownList ID="ddl_Exp_Branch" CssClass="listtxt_transac_item_gen_notn" Width="130px"
                                                    runat="server" TabIndex="44">
                                                </asp:DropDownList>
                                            </div>
                                            <div id="tag_label_transact_Src" style="width: 60px;">
                                                Bill No
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 160px;">
                                                <asp:DropDownList ID="ddl_Bill_No" data-placeholder="Choose a Bill No" CssClass="chosen-select-deselect"
                                                    Width="150px" runat="server" TabIndex="45">
                                                </asp:DropDownList>
                                            </div>
                                            <div id="tag_label_transact_Src" style="width: 60px; margin-top: -5px;">
                                                <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                                    tabindex="50"></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_transact_lft_in1" style="width: 1138px; height: 220px; overflow: auto;">
                                <asp:GridView ID="gvAll" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="WhiteSmoke" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                    OnRowCreated="gvAll_RowCreated" CellPadding="1" CellSpacing="1" CssClass="myGridStyle"
                                    DataKeyNames="BILL_ID" EmptyDataText="NO RECORD FOUND" PageSize="5000" ShowHeaderWhenEmpty="True"
                                    Width="190%" Font-Size="12px" OnRowDataBound="gvAll_RowDataBound">
                                    <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                    <HeaderStyle CssClass="header" BackColor="#808080" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllRows(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ischk" Checked='<%# bool.Parse(Eval("Chk").ToString()) %>' runat="server"
                                                    AutoPostBack="false" onclick="copyBillAmtToAdjustment(this);updateBalance(this);" />
                                            </ItemTemplate>
                                            <ItemStyle Width="44px" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SL.No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="5px">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                                <asp:Label ID="txt_BILLID" Width="10px" Text='<%# Bind("BILL_ID") %>' runat="server"
                                                    Visible="False"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="5px" HorizontalAlign="center" Font-Size="12px" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="location" HeaderStyle-Font-Bold="true" HeaderStyle-Width="180px"   Visible="False">
                                            <ItemTemplate>
                                                <asp:Literal ID="txt_location" Text='<%# Bind("Location") %>' runat="server"></asp:Literal>
                                            </ItemTemplate>
                                            <ItemStyle Width="180px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch" HeaderStyle-Font-Bold="true" HeaderStyle-Width="180px">
                                            <ItemTemplate>
                                                <asp:Literal ID="txt_Branch" Text='<%# Bind("Branch") %>' runat="server"></asp:Literal>
                                            </ItemTemplate>
                                            <ItemStyle Width="220px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bill No" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="txt_billno" runat="server" Text='<%# Eval("Bill_No") %>' OnClientClick='<%# "return open_GST_Sales_Entry_Ch(\"" + Eval("BILL_ID") + "\", \"" + Eval("BILL_ID") + "\", \"" + Eval("Bill_No") + "\");" %>'
                                                    CommandName="SelectOrganization">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="column_style_left" Width="100px" BackColor="#CCCCCC" Font-Size="12px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bill Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="140px">
                                            <ItemTemplate>
                                                <asp:Literal ID="txt_billDate" Text='<%# Bind("Bill_Date") %>' runat="server"></asp:Literal>
                                            </ItemTemplate>
                                            <ItemStyle Width="85px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bill Amt(INR)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_billAmt" Width="100px" Text='<%# Bind("Bill_Amt") %>' runat="server"
                                                    Font-Bold="true" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                                    Enabled="False" TabIndex="29" ForeColor="#FF1493"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Paid Amt(INR)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_PaidAmt" Width="100px" Text='<%# Bind("Paid_Amt") %>' runat="server"
                                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" TabIndex="29" Enabled="False"
                                                    Font-Bold="true" ForeColor="#228B22"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="O/S(INR)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_OS_Amt" Width="100px" Text='<%# Bind("Balance_Amt") %>' runat="server"
                                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" TabIndex="29" Enabled="False"
                                                    Font-Bold="true" ForeColor="#FF0000"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Adjustment Amt(INR)" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="120px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Adjustment_Amt" Width="115px" TabIndex="29" Text='<%# Bind("Adjustment_Amt") %>'
                                                    runat="server" onblur="autoCheckRow(this);updateBalance(this);calculateTotalAdjustment();"
                                                    onchange="autoCheckRow(this);updateBalance(this);calculateTotalAdjustment();"
                                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" oninput="autoCheckRow(this);updateBalance(this);calculateTotalAdjustment();"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="120px" HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Balance(INR)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="120px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Bal" Width="120px" Text='<%# Bind("Balance_Amt") %>' TabIndex="29"
                                                    runat="server" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                                    Font-Bold="true" ForeColor="#FF6347" Enabled="False"></asp:TextBox>
                                                <asp:HiddenField ID="hf_Bal" runat="server" Value='<%# Bind("Balance_Amt") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="120px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Write off Amt(INR)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Write_Amt" Width="100px" Text='<%# Bind("WRITE_OFF_AMT") %>'
                                                    runat="server" onchange="updateBalance(this);calculateTotalAdjustment();" onkeypress="updateBalance(this);calculateTotalAdjustment();"
                                                    onkeyup="extractNumber(this,3,false); Clear_Dot(this);updateBalance(this);calculateTotalAdjustment();"
                                                    TabIndex="29" ForeColor="Black"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Taxable Amt(INR)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Taxable_Amt" Width="100px" Text='<%# Bind("TAXABLE_AMT") %>'
                                                    runat="server" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                                    TabIndex="29" Enabled="False" ForeColor="#E0115F"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TDS Y/N" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="isch_tds" runat="server" Checked='<%# bool.Parse(Eval("TDS_Y_N").ToString()) %>'
                                                    AutoPostBack="false" onclick="Tds_Adjustment(this);ToggleTdsFields(this);" />
                                            </ItemTemplate>
                                            <ItemStyle Width="44px" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TDS %" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_TDS_Per" Width="50px" Text='<%# Bind("TDS_RATE") %>' runat="server"
                                                    onkeyup="extractNumber(this,3,false);Clear_Dot(this);calculateTdsAmount(this);"
                                                    oninput="calculateTdsAmount(this);"  TabIndex="29" Enabled="False"
                                                    ForeColor="#E0115F"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TDS Amt(INR)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_TDS_Amt" Width="100px" Text='<%# Bind("TDS_AMT") %>' runat="server"
                                                   onkeyup="extractNumber(this,3,false);Clear_Dot(this);calculateTdsPercent(this);"
                                                    oninput="calculateTdsPercent(this);" TabIndex="29" Enabled="False"
                                                    ForeColor="#E0115F"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rec. TDS Amt(INR)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_RecT_Amt" Width="100px" Text='<%# Bind("TDS_AMT") %>' runat="server"
                                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" Enabled="False"
                                                    TabIndex="29" ForeColor="Black"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cr. Inv. Bill Amt(INR)" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Cr_Note_Bill_Amt" Width="130px" Text='<%# Bind("CR_GRAND_TOTAL") %>'
                                                    runat="server" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                                    TabIndex="29" Enabled="False" ForeColor="#E0115F"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="130px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rec. Cr. Inv.Amt Amt(INR)" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="140px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Rec_Cr_Amt" Width="140px" Text='<%# Bind("REC_CR_GRAND_TOTAL") %>'
                                                    runat="server" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                                    TabIndex="29" Enabled="False" ForeColor="Black"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="140px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Remarks" Width="300px" Text='<%# Bind("REMARKS") %>' runat="server"
                                                    TabIndex="29" ForeColor="Black"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="300px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_bot_transact" style="margin-top: 0px; width: 500px;">
                    <div id="innerbox_transac_bot_inn" style="width: 500px;">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" TabIndex="57" CssClass="new" OnClick="btnNew_Click"
                                OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                                UseSubmitBehavior="false" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" CommandName="s"
                                OnClientClick="return validate();" TabIndex="55" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                                OnClick="btnUpdate_Click" Visible="false" TabIndex="56" OnClientClick="return validation();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="60" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Receipt', function(r) {
                  var i = r + 'ok';
                  if(i == 'trueok')
                  {
                      document.getElementById('btn').click();
            
                  }
                  else {
                  }
                    });return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="63" CausesValidation="false" UseSubmitBehavior="false"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                           <asp:Button ID="btnrpt" runat="server" Text="Print" Width="119px" Height="25px"  Style="margin-top:3px;" OnClientClick="return bankReceipts_Job_Rpt();" />
                       </div>
                    </div>
                </div>
                <div id="tag_label_transact_Src" style="width: 300px">
                    <asp:Label ID="lblTotalAdjustment" runat="server" Style="font-weight: bold; color: red;"></asp:Label>
                </div>
            </div>
            </div> </div> </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HD_Ch_update_id" runat="server" />
            <asp:HiddenField ID="hf_Bal" runat="server" />
            <asp:HiddenField ID="Hd_row_id" runat="server" />
            <asp:HiddenField ID="Hidden_iNR" runat="server" />
            <asp:HiddenField ID="Hidden_lblTotalAdjustment" runat="server" />
             <asp:HiddenField ID="hfBankGLCode" runat="server" />
            <%--lblTotalAdjustment--%>
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
    <%--<script src="../js/Validation.js" type="text/javascript"></script>--%>
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
        function open_GST_Sales_Entry_Ch(Job_Id, Imp_Exp, Bill_Inv_No) {
            NewWindow1('../Accounts_Sales/GST_Sales_Entry.aspx?Page=' + Job_Id + '&IMP_EXP=' + 'Bank_Rec' + '&Billinvno=' + Bill_Inv_No, '_blank', '1200', '585', 'yes');
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

        $('.chosen-container .chosen-results').css({
            'max-height': '180px',  // Set your desired height here
            'overflow-y': 'auto'
        });

        function synctDS() {
            var orgValue = document.getElementById('<%= txt_TDS_Deducted_Inr.ClientID %>').value;
            document.getElementById('<%= txt_TDS_Deducted_Inr_II.ClientID %>').value = orgValue;
        }

        function syncDrToOrgInr() {
            var dr = document.getElementById('<%= txt_Cur_Amt.ClientID %>').value;
            document.getElementById('<%= txt_INR_Amt.ClientID %>').value = dr;
        }

        function syncOrgToInr() {
            var orgValue = document.getElementById('<%= txt_Orgin_Bank_Charge_TDS_I.ClientID %>').value;
            document.getElementById('<%= txt_Orgin_Bank_Charge_TDS_II.ClientID %>').value = orgValue;
        }

        function syncRecFromOrg() {
            var rec = document.getElementById('<%= txt_Rec_From_Org_I.ClientID %>').value;
            document.getElementById('<%= txt_Rec_From_Org_II.ClientID %>').value = rec;
        }

        function syncbankChargeOrg() {
            var bankCharge = document.getElementById('<%= txt_bank_Charge_II.ClientID %>').value;
            document.getElementById('<%= txt_bank_Charge_I.ClientID %>').value = bankCharge;
        }
        function syncDebitbankToInr() {
            var BankValue = document.getElementById('<%= txtcredit_Bank.ClientID %>').value;
            document.getElementById('<%= txt_Debit_to_bank_II.ClientID %>').value = BankValue;
        }

        function syncAmounts() {
            document.getElementById("Hidden_iNR").value = "";
            var curAmt = document.getElementById("txt_Cur_Amt").value;


            var filteredAmt = curAmt.replace(/[^0-9.]/g, '');

            document.getElementById("txt_INR_Amt").value = filteredAmt;
            document.getElementById("Hidden_iNR").value = filteredAmt;
            document.getElementById("txtcredit_Bank").value = filteredAmt;
        }

        function updateBalance(el) {
            var row = el.closest("tr");
            if (!row) return;

            var billAmtBox = row.querySelector("[id*='txt_billAmt']");
            var paidAmtBox = row.querySelector("[id*='txt_PaidAmt']");
            var adjustmentBox = row.querySelector("[id*='txt_Adjustment_Amt']");
            var writeAmtBox = row.querySelector("[id*='txt_Write_Amt']");
            var tdsAmtBox = row.querySelector("[id*='txt_TDS_Amt']");
          

            var txtBal = row.querySelector("[id*='txt_Bal']");
            var hfBal = row.querySelector("[id*='hf_Bal']");
            var chkTds = row.querySelector("[id*='isch_tds']");

            if (!billAmtBox || !paidAmtBox || !adjustmentBox || !writeAmtBox ||
        !tdsAmtBox || !txtBal || !hfBal || !chkTds) {
                console.error("updateBalance: could not find one or more fields in this row");
                return;
            }

            var billAmt = parseFloat(billAmtBox.value) || 0;
            var paidAmt = parseFloat(paidAmtBox.value) || 0;
            var adjustment = parseFloat(adjustmentBox.value) || 0;
            var writeOff = parseFloat(writeAmtBox.value) || 0;
            var tds = parseFloat(tdsAmtBox.value) || 0;
          
            var balance = 0;

            if (!chkTds.disabled && chkTds.checked) {
                balance = billAmt - paidAmt - adjustment - writeOff - tds;
            } else {
                balance = billAmt - paidAmt - adjustment - writeOff ;
            }

            if (balance < 0) {
                adjustment = billAmt - paidAmt - writeOff - (chkTds.checked ? tds : 0) ;
                adjustmentBox.value = adjustment.toFixed(2);
                balance = 0;
            }

            txtBal.value = balance.toFixed(2);
            hfBal.value = balance.toFixed(2);
        }

       


        function calculateTotaltds(chkBox) {
            var totalBox = document.getElementById('<%= txt_TDS_Deducted_Inr.ClientID %>');
            var currentTotal = parseFloat(totalBox.value);
            var row = chkBox.closest("tr");
            var tds = row.querySelector("input[id*='txt_TDS_Amt']");
            var tdsValue = parseFloat(tds.value) || 0;
            if (chkBox.checked) {
                currentTotal += tdsValue;
            }
            else {
                currentTotal -= tdsValue;
            }
            totalBox.value = currentTotal.toFixed(2);
            Tds_Calculation();
        }



        function calculateTotalAdjustment() {
            var totalAdj = 0;

            var gridView = document.getElementById("<%= gvAll.ClientID %>");
            var rows = gridView.getElementsByTagName("tr");

            for (var i = 0; i < rows.length; i++) {

                var input = rows[i].querySelector("input[id*='txt_Adjustment_Amt']");
                if (input) {

                    totalAdj += parseFloat(input.value) || 0;
                }
            }

            document.getElementById("Hidden_lblTotalAdjustment").value = "";
            document.getElementById('<%= lblTotalAdjustment.ClientID %>').innerText = "Total Adjustment: " + totalAdj.toFixed(2);
            document.getElementById("Hidden_lblTotalAdjustment").value = totalAdj.toFixed(2);
        }

        window.onload = function () {
            calculateTotalAdjustment();
            syncOrgToInr();
            syncRecFromOrg();
            syncbankChargeOrg();
            syncDrToOrgInr();
            synctDS();
            syncDebitbankToInr();
        };



        function calculateTotalTdsFromGrid() {
            var totalTds = 0;
            var gridView = document.getElementById("<%= gvAll.ClientID %>");
            if (gridView) {
                var rows = gridView.getElementsByTagName("tr");
                for (var i = 0; i < rows.length; i++) {
                    var chk = rows[i].querySelector("[id*='isch_tds']");
                    var amt = rows[i].querySelector("[id*='txt_TDS_Amt']");
                    if (chk && amt && !chk.disabled && chk.checked) {
                        totalTds += parseFloat(amt.value) || 0;
                    }
                }
            }
            var dropdown = document.getElementById('<%= ddl_TDS_Deducted.ClientID %>');
            var TDS_Section = document.getElementById('<%= ddlTDS_Section.ClientID %>');
            var txtRate = document.getElementById("txt_TDS_Rate");
            var txtAmt = document.getElementById('<%= txt_TDS_Deducted_Inr.ClientID %>');
            var txtAmtII = document.getElementById('<%= txt_TDS_Deducted_Inr_II.ClientID %>');
            var txtCur = document.getElementById('<%= txt_Cur_Amt.ClientID %>');
            if (!dropdown || !txtRate || !txtAmt || !txtCur) return;
            var cre = parseFloat(txtCur.value) || 0;
            // push grid total into header amount field (now derived, not typed)
            txtAmt.value = totalTds.toFixed(2);
            if (txtAmtII) txtAmtII.value = totalTds.toFixed(2);
            txtAmt.disabled = true;
            if (totalTds > 0) {
                dropdown.value = "Y";
                if (TDS_Section) TDS_Section.disabled = false;
                txtRate.value = cre > 0 ? ((totalTds / cre) * 100).toFixed(2) : "0.00";
                txtRate.disabled = true;
            } else {
                dropdown.value = "N";
                if (TDS_Section) { TDS_Section.disabled = true; TDS_Section.value = ""; }
                txtRate.value = "";
                txtRate.disabled = true;
            }
            document.getElementById("txtcredit_Bank").value = (cre - totalTds).toFixed(2);
            document.getElementById("txt_Debit_to_bank_II").value = (cre - totalTds).toFixed(2);
        }

        // Kept so existing inline onclick/onchange/onblur references to Tds_Calculation() still work
        function Tds_Calculation() {
            calculateTotalTdsFromGrid();
        }


    </script>
    <script type="text/javascript">

        function copyBillAmtToAdjustment(chkBox) {
            try {
                var row = chkBox.parentNode.parentNode; // the <td> -> <tr>
                var gridView = document.getElementById("<%= gvAll.ClientID %>");
                var rows = gridView.getElementsByTagName("tr");
                // get the textbox controls inside this row
                var txtBal = row.querySelector("[id*='txt_Bal']");
                var txtAdj = row.querySelector("[id*='txt_Adjustment_Amt']");
              

                if (!txtBal || !txtAdj) return;

                var billVal = txtBal.value || "0.00";

                if (chkBox.checked) {
                    if (txtAdj.value == "" || txtAdj.value == "0.00") 
                    {
                        txtAdj.value = billVal;
                    }

                } else {
               
                    txtAdj.value = "0.00";
                }
              
                if (typeof calculateTotalAdjustment === "function") {
                    calculateTotalAdjustment();
                }
            }
            catch (ex) {
                console.error(ex);
            }
        }


        function Tds_Adjustment(chk1) {
            try {
                var row = chk1.closest("tr");  // FIXED

                var txtBal = row.querySelector("[id*='txt_OS_Amt']");
                var txtAdj = row.querySelector("[id*='txt_Adjustment_Amt']");
                var txttds = row.querySelector("[id*='txt_TDS_Amt']");
                var balance = row.querySelector("[id*='txt_Bal']");
                var Write_Amt = row.querySelector("[id*='txt_Write_Amt']");
                var bal = parseFloat(txtBal.value) || 0;
                var adj = parseFloat(txtAdj.value) || 0;
                var tds = parseFloat(txttds.value) || 0;
                var W_Amt = parseFloat(Write_Amt.value) || 0;

                var billVal = bal - adj - W_Amt;

                if (chk1.checked) {
                    balance.value = (billVal - tds).toFixed(2);
                } else {
                    balance.value = (bal - adj - W_Amt).toFixed(2);
                }
            }
            catch (ex) {
                console.error(ex);
            }
        }

         function SelectAllRows(headerChk) {
            var gridView = document.getElementById("<%= gvAll.ClientID %>");
            if (!gridView) return;

            var checkboxes = gridView.querySelectorAll("input[id*='_ischk']");

            checkboxes.forEach(function (cb) {
                if (cb.disabled) return;
                cb.checked = headerChk.checked;

                copyBillAmtToAdjustment(cb);
                updateBalance(cb);
            });
            calculateTotalAdjustment();
        }

        function ToggleTdsFields(chk) {
            var row = chk.closest("tr");
            var txtTdsPer = row.querySelector("[id*='txt_TDS_Per']");
            var txtTdsAmt = row.querySelector("[id*='txt_TDS_Amt']");
            var txtOS = row.querySelector("[id*='txt_OS_Amt']");
            var txtAdj = row.querySelector("[id*='txt_Adjustment_Amt']");
            var txtWrite = row.querySelector("[id*='txt_Write_Amt']");

            if (chk.checked) {
                var os = parseFloat(txtOS.value) || 0;
                var adj = parseFloat(txtAdj.value) || 0;
                var writeAmt = parseFloat(txtWrite.value) || 0;
                var remaining = os - adj - writeAmt;

                if (remaining <= 0) {
                    alert("Adjustment Amt + Write off Amt already settles the full outstanding balance. TDS cannot be applied on this bill.");
                    chk.checked = false;
                    return;                      // don't enable the fields at all
                }

                txtTdsPer.disabled = false;
                txtTdsAmt.disabled = false;
            } else {
                txtTdsPer.disabled = true;
                txtTdsAmt.disabled = true;
                txtTdsPer.value = "0.00";
                txtTdsAmt.value = "0.00";
            }

            updateBalance(chk);
            calculateTotalAdjustment();
        }

        function calculateTdsAmount(txtPer) {
            var row = txtPer.closest("tr");

            var txtTaxable = row.querySelector("[id*='txt_Taxable_Amt']");
            var txtTdsAmt = row.querySelector("[id*='txt_TDS_Amt']");
            var txtOS = row.querySelector("[id*='txt_OS_Amt']");
            var txtAdj = row.querySelector("[id*='txt_Adjustment_Amt']");
            var txtWrite = row.querySelector("[id*='txt_Write_Amt']");
            var chkTds = row.querySelector("[id*='isch_tds']");

            var taxable = parseFloat(txtTaxable.value) || 0;
            var rate = parseFloat(txtPer.value) || 0;

            var os = parseFloat(txtOS.value) || 0;
            var adj = parseFloat(txtAdj.value) || 0;
            var writeAmt = parseFloat(txtWrite.value) || 0;

            var maxAllowed = os - adj - writeAmt;

            var tdsAmt = taxable * rate / 100;

            // &#9989; CAP TDS
            if (tdsAmt > maxAllowed) {
                tdsAmt = maxAllowed > 0 ? maxAllowed : 0;
                rate = taxable > 0 ? (tdsAmt / taxable) * 100 : 0;

                txtPer.value = rate.toFixed(2);
            }

            txtTdsAmt.value = tdsAmt.toFixed(2);

            updateBalance(txtPer);   // must subtract TDS inside
            calculateTotalAdjustment();
           calculateTotalTdsFromGrid();
        }

        function calculateTdsPercent(txtAmt) {
    var row = txtAmt.closest("tr");

    var txtTaxable = row.querySelector("[id*='txt_Taxable_Amt']");
    var txtTdsPer = row.querySelector("[id*='txt_TDS_Per']");
    var txtOS = row.querySelector("[id*='txt_OS_Amt']");
    var txtAdj = row.querySelector("[id*='txt_Adjustment_Amt']");
    var txtWrite = row.querySelector("[id*='txt_Write_Amt']");
    var chkTds = row.querySelector("[id*='isch_tds']");

    var taxable = parseFloat(txtTaxable.value) || 0;
    var tdsAmt = parseFloat(txtAmt.value) || 0;

    var os = parseFloat(txtOS.value) || 0;
    var adj = parseFloat(txtAdj.value) || 0;
    var writeAmt = parseFloat(txtWrite.value) || 0;

    var maxAllowed = os - adj - writeAmt;

    // &#9989; CAP TDS
    if (tdsAmt > maxAllowed) {
        tdsAmt = maxAllowed > 0 ? maxAllowed : 0;
        txtAmt.value = tdsAmt.toFixed(2);
    }

    var rate = taxable > 0 ? (tdsAmt / taxable) * 100 : 0;
    txtTdsPer.value = rate.toFixed(2);

    updateBalance(txtAmt);   // must subtract TDS inside
    calculateTotalAdjustment();
   calculateTotalTdsFromGrid();  
}

function calculateTotalTdsFromGrid() {
    var totalTds = 0;
    var gridView = document.getElementById("<%= gvAll.ClientID %>");
    if (gridView) {
        var rows = gridView.getElementsByTagName("tr");
        for (var i = 0; i < rows.length; i++) {
            var chkRow = rows[i].querySelector("[id*='_ischk']");   // row-select checkbox
            var chkTds = rows[i].querySelector("[id*='isch_tds']"); // TDS Y/N checkbox
            var amt = rows[i].querySelector("[id*='txt_TDS_Amt']");
            if (chkRow && chkTds && amt && chkRow.checked && !chkTds.disabled && chkTds.checked) {
                totalTds += parseFloat(amt.value) || 0;
            }
        }
    }
    var dropdown = document.getElementById('<%= ddl_TDS_Deducted.ClientID %>');
    var TDS_Section = document.getElementById('<%= ddlTDS_Section.ClientID %>');
    var txtRate = document.getElementById('<%= txt_TDS_Rate.ClientID %>');
    var txtAmt = document.getElementById('<%= txt_TDS_Deducted_Inr.ClientID %>');
    var txtAmtII = document.getElementById('<%= txt_TDS_Deducted_Inr_II.ClientID %>');
    var txtCur = document.getElementById('<%= txt_Cur_Amt.ClientID %>');
    if (!dropdown || !txtRate || !txtAmt || !txtCur) return;
    var cre = parseFloat(txtCur.value) || 0;
    txtAmt.value = totalTds.toFixed(2);
    if (txtAmtII) txtAmtII.value = totalTds.toFixed(2);
    if (totalTds > 0) {
        dropdown.value = "Y";
        if (TDS_Section) TDS_Section.disabled = false;
        txtRate.value = cre > 0 ? ((totalTds / cre) * 100).toFixed(2) : "0.00";
    } else {
        dropdown.value = "N";
        if (TDS_Section) { TDS_Section.disabled = true; TDS_Section.value = ""; }
        txtRate.value = "";
    }
    document.getElementById("txtcredit_Bank").value = (cre - totalTds).toFixed(2);
    document.getElementById("txt_Debit_to_bank_II").value = (cre - totalTds).toFixed(2);
}

function Tds_Calculation() {
    calculateTotalTdsFromGrid();
}


let isUpdating = false;

function autoCheckRow(txtAdj) {
    if (isUpdating) return;

    var row = txtAdj.closest("tr");
    var chk = row.querySelector("[id*='ischk']");
    if (!chk) return;

    var adjVal = parseFloat(txtAdj.value) || 0;

    isUpdating = true;

    if (adjVal > 0 && !chk.checked) {
        chk.checked = true;
        updateBalance(chk);
    }
    else if (adjVal <= 0 && chk.checked) {
        chk.checked = false;
        updateBalance(chk);
    }

    isUpdating = false;
}

</script>
<script type="text/javascript">
    function bankReceipts_Job_Rpt() {
        var BR_F = document.getElementById('<%= txt_BR_No_F.ClientID %>').value.trim();
        var BR_M = document.getElementById('<%= txt_BR_No_M.ClientID %>').value.trim();
        var BR_L = document.getElementById('<%= txt_BR_No_L.ClientID %>').value.trim();

        NewWindow1('../Accounts_Bank_Report/Acc_BankReceipt_ReceiptEntry_Rpt.aspx?BR_P=' + encodeURIComponent(BR_F) + '&BR_NO=' + encodeURIComponent(BR_M) + '&BR_S=' + encodeURIComponent(BR_L), 'List', '870', '1024', 'yes');
        return false;
    } 
   </script>
</body>
</html>
