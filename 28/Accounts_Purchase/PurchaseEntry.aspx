<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurchaseEntry.aspx.cs" Inherits="PurchaseEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Purchase Entry</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
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
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style type="text/css">
        .CalendarStyle
        {
            background-color: Crimson;
            color: White;
            border: solid 2px DarkRed;
        }
        .ajax__calendar_header
        {
            background-color: #FBB117;
            color: black;
        }
        .ajax__calendar_footer
        {
            background-color: #FBB117;
            color: black;
        }
    </style>
    <style type="text/css">
        .FixedHeader
        {
            position: absolute;
            font-weight: bold;
        }
        
        .hideGridColumn
        {
            display: none;
        }
        
        .hideGridColumn1
        {
            display: none;
        }
    </style>
    <style>
        div.fileinputs
        {
            position: relative;
        }
        
        div.fakefile
        {
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 1;
        }
        
        input.file
        {
            position: relative;
            text-align: right;
            -moz-opacity: 0;
            filter: alpha(opacity: 0);
            opacity: 0;
            z-index: 2;
        }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="loading" align="center" id="load" style="display: none;">
        <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
    </div>
    <div id="innerbox_MidMain_Billing" style="height: 185px;">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                Purchase Entry
            </div>
            <div id="verslic">
            </div>
            <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                <div id="txtcon-m_Exchange" style="width: 220px; margin-top: 5px;">
                    <asp:RadioButtonList ID="Rd_Royal_Other" Font-Bold="true" ForeColor="Blue" runat="server"
                        RepeatDirection="Horizontal" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="Rd_Royal_Other_SelectedIndexChanged">
                        <asp:ListItem Text="eRoyal Jobs" Value="R" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Other Jobs" Value="O"></asp:ListItem>
                    </asp:RadioButtonList>
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
                <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" />
            </div>
        </div>

        <div id="tag_transact_src_inner" style="width: 1200px; height: 100px;">
            <div id="tag_Exchange_inner_lft" style="width: 1200px; height: 90px;">
                <div id="tag_transact_lft_in1" style="width: 1200px; height: 80px;">
                    <div style="width: 1200px; height: 30px">

                    <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 20px; margin-left: -5px;">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Trans No.
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 200px;">
                                        <%-- <asp:TextBox ID="txtVoucherno" Width="140px" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                         TabIndex="5" runat="server"></asp:TextBox>--%>

                                         <asp:TextBox ID="txt_PB_No_F" runat="server" TabIndex="3" ReadOnly="true" BackColor="#e7e6e6"
                                            Width="35px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                         <asp:TextBox ID="txtVoucherno" runat="server" TabIndex="4" ReadOnly="true" BackColor="#e7e6e6"
                                            Style="text-align: right;" Width="60px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                         <asp:TextBox ID="txt_PB_No_L" runat="server" TabIndex="5" ReadOnly="true" BackColor="#e7e6e6"
                                            Width="60px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>

                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 70px;">
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 75px;">
                                        Entry Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 130px;">
                                        <asp:TextBox ID="txtVoucherdate" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                        TabIndex="6" Width="100px" runat="server"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtVoucherdate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtVoucherdate"
                                        PopupButtonID="txtVoucherdate" Enabled="true" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 85px;">
                                        Posting Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 120px;">
                                        <asp:TextBox ID="txt_Posting_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="7"></asp:TextBox>
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
                        
                        <div id="txt_container_Transact_Main_l" style="width: 1200px; margin-left: -5px;">
                            <div id="tag_label_transact_Src" style="width: 90px;">
                                Organization
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 360px;">
                                <asp:DropDownList ID="ddlVendorname" class="validate[required]  chosen-select-deselect"
                                    Style="width: 350px;" data-placeholder="Choose a Vendorname" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlVendorname_SelectedIndexChanged" runat="server" TabIndex="8">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 75px;">
                                Branch
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 315px">
                                <asp:DropDownList ID="ddlVendorBranch" class="validate[required]  chosen-select-deselect"
                                    Style="width: 310px;" data-placeholder="Choose a Branch No" AutoPostBack="true"
                                    runat="server" TabIndex="10" OnSelectedIndexChanged="ddlVendorBranch_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 65px;">
                                 Narration
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 275px">
                              <asp:TextBox ID="txtNarration" CssClass=" txtbox_none_Mid_transac_code" Width="270px"
                                    TabIndex="12" runat="server"></asp:TextBox>
                            </div>
                            
                           
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width: 1200px; margin-left: -5px; height: 20px">
                           
                            <div id="tag_label_transact_Src" style="width: 90px;">
                                Vendor Inv No.
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 190px;">
                                <asp:TextBox ID="txtVendorbillno" Width="140px" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="15" runat="server"></asp:TextBox>
                                <span id="txtVendorbillno_Err" style="color: red; font-size: 12px; display: none;">Username
                                    already exists!</span>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 67px;">
                                Date
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 105px;">
                                <asp:TextBox ID="txtBilldate" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    Width="88px" onfocusout="isDate()" TabIndex="16" runat="server"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtBilldate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBilldate"
                                    PopupButtonID="txtBilldate" Enabled="true" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 75px;">
                                Inv Amount
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 100px;">
                                <asp:TextBox ID="txtbillamount" Width="80px" ForeColor="Blue" Font-Bold="true" runat="server"
                                    Style="text-align: right;" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" autocomplete="off"
                                    TabIndex="18" MaxLength="50"></asp:TextBox>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 35px;">
                            Cur.
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 65px;">
                             <asp:TextBox ID="txtBill_Cur" Style="border: 0px none;" ForeColor="Green" Font-Bold="true"
                                    Width="50px" runat="server" ClientIDMode="Static" TabIndex="20" onkeypress="return char1(event)"
                                    Text="INR" Enabled="false" MaxLength="3" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"></asp:TextBox>
                            </div>

                              <div id="tag_label_transact_Src" style="width: 40px;">
                             Exch.
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 72px;">
                            <asp:TextBox ID="txtExrate" runat="server" Style="border: 0px none;" ForeColor="Green"
                                    Font-Bold="true" onfocusout="tap()" Text="1" Width="60px" TabIndex="22" Enabled="false"
                                    MaxLength="50" CssClass="validate[required] txtbox_none_Mid_transac_code"></asp:TextBox>
                            </div>
                               <div id="tag_label_transact_Src" style="width: 85px;">
                             INR. Amount
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 95px;">
                              <asp:TextBox ID="txtTotalamtininr" runat="server" Width="75px" ForeColor="Red" Font-Bold="true"
                               Style="border: 0px none;" MaxLength="50" TabIndex="25"></asp:TextBox>
                            </div>
                             <div id="tag_label_transact_Src" style="width: 75px;">
                              Due Date
                            </div>
                              <div id="txtcon-m_Exchange" style="width: 82px;">
                              <asp:TextBox ID="txtDuedate" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    Width="80px" onfocusout="isDate()" TabIndex="26" runat="server"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtDuedate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDuedate"
                                    PopupButtonID="txtDuedate" Enabled="true" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                           
                        </div>

                        <div id="txt_container_Transact_Main_l" style="width: 1150px; margin-left: -5px;
                            height: 20px">
                            <div id="tag_label_transact_Src" style="width: 90px;">
                                 Vendor State
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 190px;">
                              <asp:TextBox ID="txtVendorstate" Width="140px"  CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;
                               font-size: 12px;" ForeColor="Green" Font-Bold="true" Enabled="false" TabIndex="27"
                               runat="server"></asp:TextBox>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 67px;">
                                    GSTN No.
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 105px;">
                                   <asp:TextBox ID="txtGstn" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;
                                    font-size: 12px;" ForeColor="Green" Font-Bold="true" Enabled="false" Width="95px"
                                    TabIndex="28" runat="server"></asp:TextBox>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 75px;">
                               GSTN Type
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 100px;">
                                <asp:TextBox ID="txtGstntype" Width="80px" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    ForeColor="Green" Font-Bold="true" Enabled="false" TabIndex="29" runat="server"></asp:TextBox>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 85px;">
                            Country
                            </div>
                             <div id="txtcon-m_Exchange" style="width: 140px">
                                <asp:TextBox ID="txtCountry" Width="120px" CssClass="txtbox_none_Mid_transac_code"
                                    Style="border: 0px none;" ForeColor="Green" Font-Bold="true" Enabled="false"
                                    TabIndex="30" runat="server"></asp:TextBox>
                            </div>

                            <div id="txtcon-m_Exchange" style="width: 200px;">
                             <%-- <asp:Button ID="btn_Save_Update" CssClass="autowidmovebut" Width="80px" TabIndex="28"
                                    runat="server" OnClick="btn_Save_Update_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btn_Pu_Delete" runat="server" Text="Delete" CssClass="autowidmovebut"
                                    Visible="false" Width="50px" TabIndex="29" OnClick="btn_Pu_Delete_Click" />--%>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width: 1150px; margin-left: -5px;">
                            <div id="tag_label_transact_Src" style="width: 100px; font-weight: bold; margin-top: -5px;" >
                                   <asp:RadioButtonList ID="Rd_Reg_Sez" width="100px" runat="server" RepeatDirection="Horizontal"
                                       TabIndex="31" ForeColor="Green">
                                       <asp:ListItem Text="Reg" Value="R" Selected="True"></asp:ListItem>
                                       <asp:ListItem Text="Sez" Value="S"></asp:ListItem>
                                       </asp:RadioButtonList>
                            </div>
                            <div id="verslic" style="height:17px;"></div>
                            <div id="txtcon-m_Exchange" style="width: 145px">
                                <asp:RadioButtonList ID="Rd_Debit_Credit" runat="server" RepeatDirection="Horizontal"
                                    TabIndex="32" ForeColor="Blue" Font-Bold="true">
                                    <asp:ListItem Text="Debit" Value="D" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Credit" Value="C"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div id="verslic" style="height:17px;"></div>
                            <div id="tag_label_transact_Src" style="width: 140px;">
                                  <asp:RadioButtonList ID="Rd_Bill_Type" runat="server" RepeatDirection="Horizontal" TabIndex="33">
                                    <asp:ListItem Text="Local" Value="L" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div id="verslic" style="height:17px;width: 35px;"></div>

                            <div id="txtcon-m_Exchange" style="width: 390px">
                             <asp:DropDownList ID="ddl_Under_name" class="chosen-select-deselect" Style="width: 260px;"
                                    data-placeholder="Choose a Branch No" runat="server" TabIndex="34">
                                </asp:DropDownList>
                            </div>
                         
                            <div id="txtcon-m_Exchange" style="width: 160px; margin-top: -10px;">
                                <asp:Button ID="btn_Save_Update" CssClass="autowidmovebut" Width="80px" TabIndex="35"
                                    runat="server" OnClick="btn_Save_Update_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btn_Pu_Delete" runat="server" Text="Delete" CssClass="autowidmovebut"
                                    Visible="false" Width="50px" TabIndex="37" OnClick="btn_Pu_Delete_Click" />
                            </div>
                           
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- -------------------------------------Tab--------------------------------------------------------%>
    <div class="content" id="page-1" style="margin-top: -30px;">
        <div id="innerbox_MidMain_Trans_new" style="height: 417px; width: 1298px; margin-left: -16px;
            margin-top: -25px;">
            <div id="pop_text_area_transac_popup_inn_container_export" style="height: 150px;
                margin-top: 30px;">
                <div id="tag_transact_src_inner" style="width: 1200px">
                    <div id="tag_Exchange_inner_lft" style="width: 1200px">
                        <%-- --------------------S----------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1200px; height: 35px;">
                            <div id="txt_container_Transact_Main_l" style="width: 95px;">
                                <div id="tag_label_transact_Src" style="width: 35px;">
                                    Slno:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 60px;">
                                    <asp:DropDownList ID="ddlslno" CssClass="listtxt_transac_mode_new" Style="width: 50px;"
                                        runat="server" TabIndex="50">
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 300px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                    Branch
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 235px;">
                                    <asp:DropDownList ID="ddlgroup_Name" class="chosen-select-deselect" Style="width: 235px;
                                        font-size: 12px;" data-placeholder="Choose a Jobno" AutoPostBack="true" runat="server"
                                        TabIndex="51" OnSelectedIndexChanged="ddlgroup_Name_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                <div id="txtcon-m_Exchange" style="width: 110px">
                                    <asp:RadioButtonList ID="Rd_IMP_EXP" runat="server" RepeatDirection="Horizontal"
                                        ForeColor="Blue" Font-Bold="true" AutoPostBack="true" TabIndex="52" OnSelectedIndexChanged="Rd_IMP_EXP_SelectedIndexChanged">
                                        <asp:ListItem Text="Imp" Value="I" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div id="magnify_area" style="width:10px;"></div>
                                <div id="tag_label_transact_Src" style="width:90px;">
                                    Jobno
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 330px;">
                                    <asp:DropDownList ID="ddljobno" class="chosen-select-deselect" Style="width: 155px;
                                        font-size: 12px;" data-placeholder="Choose a Jobno" AutoPostBack="true" runat="server"
                                        TabIndex="53" OnSelectedIndexChanged="ddljobno_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txt_Other_Jobno" runat="server" Width="160px" ForeColor="Blue" MaxLength="20"
                                        CssClass="txtbox_none_Mid_transac_code" ClientIDMode="Static" TabIndex="55"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 170px;">
                                <div id="tag_label_transact_Src" style="width: 70px">
                                    Job Date
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 90px;">
                                    <asp:TextBox ID="txt_JobDate" runat="server" Width="80px" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                        TabIndex="56"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_JobDate"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_JobDate"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <%-- --------------------R2----------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1200px; height: 30px;">
                            <div id="txt_container_Transact_Main_l" style="width: 1160px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                    Cus. Name
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 415px;">
                                    <asp:DropDownList ID="ddl_Cus_Name" class="validate[required]  chosen-select-deselect"
                                        Style="width: 410px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                        runat="server" TabIndex="58">
                                    </asp:DropDownList>
                                </div>
                                 <div id="magnify_area" style="width:10px;"></div>
                              
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                    Charge Head
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 335px;">
                                    <asp:DropDownList ID="ddl_Charge_head" class="chosen-select-deselect" Style="width: 325px;"
                                        data-placeholder="Choose a Charge Name" runat="server" TabIndex="59" onchange="Charge_head();">
                                    </asp:DropDownList>
                                </div>

                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Tax Rate
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px;">
                                   <asp:DropDownList ID="ddl_Tax_Rate" CssClass="listtxt_transac_mode_new" Style="width: 85px;"
                                        runat="server" TabIndex="60">
                                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%-- --------------------R3----------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1200px">
                            <div id="txt_container_Transact_Main_l" style="width: 190px;">
                                <div id="tag_label_transact_Src" style="width: 90px; color:Green;">
                                     Dr / Cr Amount
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 70px;">
                                      <asp:TextBox ID="txt_Debit_Credit_Amt" Width="80px" Font-Bold="true" ForeColor="Blue"
                                        TabIndex="62" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" autocomplete="off"
                                        CssClass="txtbox_none_Mid_transac_code" runat="server"></asp:TextBox>


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 580px;">
                                <div id="tag_label_transact_Src" style="width: 80px; font-size:12px; color: Green;">
                                 CGST Amt
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                         <asp:TextBox ID="txt_CGST_Amt" runat="server" Width="60px" ForeColor="Red" Font-Bold="true" CssClass="txtbox_none_Mid_transac_code"
                                        Style="border: 0px none;" MaxLength="50" TabIndex="63"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 90px; font-size:12px; color: Green;">
                                   SGST Amt
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                    <asp:TextBox ID="txt_SGST_Amt" runat="server" Width="60px" ForeColor="Red" Font-Bold="true" CssClass="txtbox_none_Mid_transac_code"
                                        Style="border: 0px none;" MaxLength="50" TabIndex="64"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 90px; font-size:12px; color:Orange;">
                                     IGST Amt
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                        <asp:TextBox ID="txt_IGST_Amt" runat="server" Width="60px" ForeColor="Red" Font-Bold="true" CssClass="txtbox_none_Mid_transac_code"
                                        Style="border: 0px none;" MaxLength="50" TabIndex="65"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- --------------------R3--2--------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1200px; height:30px;" >
                            <div id="txt_container_Transact_Main_l" style="width: 190px;">
                                <div id="tag_label_transact_Src" style="width: 90px; color:Green;">
                                   TDS
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 70px;">
                                     <asp:DropDownList ID="ddl_TDS" Style="width: 60px;" runat="server" TabIndex="70"  Onchange="Charge_head();">
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 580px;">
                                <div id="tag_label_transact_Src" style="width: 80px; font-size:12px; color: Blue;">
                                    TDS Rate %
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                      <asp:TextBox ID="txt_Tds_Rate" Width="60px" CssClass="txtbox_none_Mid_transac_code"
                                        TabIndex="72" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" autocomplete="off"
                                        runat="server" ></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                  TDS Amt
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                     <asp:TextBox ID="txt_Tds_Amt" runat="server" Width="60px" ForeColor="Red" Font-Bold="true" CssClass="txtbox_none_Mid_transac_code"
                                        Style="border: 0px none;" MaxLength="50" TabIndex="73"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                      Balance Amt
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px;">
                                 <asp:TextBox ID="txt_D_C_bal_Amt" runat="server" Width="80px" ForeColor="Green" Font-Bold="true" CssClass="txtbox_none_Mid_transac_code"
                                        Style="border: 0px none;" MaxLength="50" TabIndex="75"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- --------------------R4----------------------------%>
                        
                        <%-- --------------------R5----------------------------%>
                        <%-- --------------------R6----------------------------%>
                        <div id="innerbox_MidMain_bot_transact" style="margin-top: 0px">
                            <div id="innerbox_transac_bot_inn" style="width: 500px;">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" TabIndex="84" CssClass="new" OnClick="btnNew_Click"
                                        OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                                        UseSubmitBehavior="false" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" CommandName="s"
                                        OnClientClick="return validate();" TabIndex="81" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                                        OnClick="btnUpdate_Click" Visible="false" TabIndex="82" OnClientClick="return validation();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="83" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Purchase', function(r) {
                  var i = r + 'ok';
                  if(i == 'trueok')
                  {
                      document.getElementById('btn').click();
            
                  }
                  else {
                  }
                    });return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="83" CausesValidation="false" UseSubmitBehavior="false"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                                        CssClass="dlete" Style="display: none;" />
                                </div>
                                <div id="editbu">
                                    <%-- <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1_Trigger_AnotherPage('General',document.getElementById('hdn_source').value);return false;"
                                        id="btnCancel" tabindex="55">--%>
                                </div>
                            </div>
                        </div>
                        <%-- --------------------E----------------------------%>
                    </div>
                </div>
            </div>
            <div id="pop_text_area_transac_popup_inn_container_IGM_gateway_grid" style="margin-top: 0px;
                margin-left: 3px; width: 1200px;">
                <div id="pop_text_area_transac_popup_inn_container_IGM_Container2_grid_gateway" runat="server"
                    style="overflow: auto; height: 225px; width: 1190px;margin-top: 10px;">
                    <asp:GridView ID="gv_Ch" runat="server" DataKeyNames="PC_ID,VOUCHER_NO,JOBNO_PS,GROUP_ID"
                        EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                        CssClass="grid-view" Width="120%" ShowHeaderWhenEmpty="True" PageSize="6" AllowPaging="True"
                        OnRowDataBound="gv_Ch_RowDataBound" OnSelectedIndexChanged="gv_Ch_SelectedIndexChanged"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_Ch_RowCreated" OnPageIndexChanging="gv_Ch_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="SLNO" HeaderText="S.No" ControlStyle-Width="30px">
                                <ItemStyle CssClass="column_style_left" Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMP_EXP" HeaderText="Imp/Exp" ControlStyle-Width="20px">
                                <ItemStyle CssClass="column_style_left" Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="JOBNO" HeaderText="Jobno" ControlStyle-Width="60px">
                                <ItemStyle CssClass="column_style_left" Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="JOB_DATE" HeaderText="Jobdate" ControlStyle-Width="40px">
                                <ItemStyle CssClass="column_style_left" Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer Name" ControlStyle-Width="350px">
                                <ItemStyle CssClass="column_style_left"  Width="350px" Font-Size="12px" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHARGE_NAME" HeaderText="Charge Head" ControlStyle-Width="300px">
                                <ItemStyle CssClass="column_style_left" Width="300px" Font-Size="12px"  HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TDS_DEDUCTION" HeaderText="Tds Deduction" ControlStyle-Width="100px">
                                <ItemStyle CssClass="column_style_left" Width="100px" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TAX_RATE" HeaderText="Tax Rate" ControlStyle-Width="50px">
                                <ItemStyle CssClass="column_style_left" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CR_DE_AMT" HeaderText="Dr / Cr Amount" ControlStyle-Width="100px">
                                <ItemStyle CssClass="column_style_left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CGST_AMT" HeaderText="CGST Amt" ControlStyle-Width="50px">
                                <ItemStyle CssClass="column_style_left" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SGST_AMT" HeaderText="SGST Amt" ControlStyle-Width="50px">
                                <ItemStyle CssClass="column_style_left" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IGST_AMT" HeaderText="IGST Amt" ControlStyle-Width="50px">
                                <ItemStyle CssClass="column_style_left" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TDS_RATE" HeaderText="TDS Rate" ControlStyle-Width="50px">
                                <ItemStyle CssClass="column_style_left" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TDS_AMOUNT" HeaderText="TDS Amt" ControlStyle-Width="50px">
                                <ItemStyle CssClass="column_style_left" Width="50px" />
                            </asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            NO RECORD FOUND
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        </div>
    </div>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-6', 'page-7', 'page-8']);
    </script>
    <asp:HiddenField ID="HDupdate_id" runat="server" />
    <asp:HiddenField ID="HD_Ch_update_id" runat="server" />
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
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
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtbillamount').focus(function () {
                var data = $(this).val();
                Inr_Amt(data);
            });
            $('#txtbillamount').change(function () {
                var data = $(this).val();
                Inr_Amt(data);
            });
            $('#txtbillamount').keyup(function () {
                var data = $(this).val();
                Inr_Amt(data);
            });
            $('#txtbillamount').keydown(function () {
                var data = $(this).val();
                Inr_Amt(data);
            });
            $('#txtbillamount').keypress(function () {
                var data = $(this).val();
                Inr_Amt(data);
            });
        });

        function Inr_Amt(val) {
            txtExrate = document.getElementById("txtExrate").value;
            if (val != '') {
                document.getElementById("txtTotalamtininr").value = (parseFloat(val) * parseFloat(txtExrate)).toFixed(2);
            }
            else {
                document.getElementById("txtTotalamtininr").value = '0';
            }
        }
    </script>
    <%-----------------------GST-----------------------------------------%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txt_Debit_Credit_Amt,#ddl_Tax_Rate').focus(function () {
                var data = $(this).val();
                Tax_Amt(data);
                TDS_Amt(data)
            });
            $('#txt_Debit_Credit_Amt,#ddl_Tax_Rate').change(function () {
                var data = $(this).val();
                Tax_Amt(data);
                TDS_Amt(data)
            });
            $('#txt_Debit_Credit_Amt,#ddl_Tax_Rate').keyup(function () {
                var data = $(this).val();
                Tax_Amt(data);
                TDS_Amt(data)
            });
            $('#txt_Debit_Credit_Amt,#ddl_Tax_Rate').keydown(function () {
                var data = $(this).val();
                Tax_Amt(data);
                TDS_Amt(data)
            });
            $('#txt_Debit_Credit_Amt,#ddl_Tax_Rate').keypress(function () {
                var data = $(this).val();
                Tax_Amt(data);
                TDS_Amt(data)
            });
        });

        function Tax_Amt(val) {
            var ddl = document.getElementById('ddl_Tax_Rate');
            var Tax_Rate = ddl.options[ddl.selectedIndex].value;

            var Local_Other = $('input:radio[name=Rd_Bill_Type]:checked').val();
            var Cr_Dr_Amt = document.getElementById("txt_Debit_Credit_Amt").value;

            if (Cr_Dr_Amt == '') {
                Cr_Dr_Amt = '0';
            }

            if (val != '') {
                if (Local_Other == 'L') {

                    var T_Rate = (Tax_Rate / 2.0)
                    document.getElementById("txt_CGST_Amt").value = (parseFloat(Cr_Dr_Amt) * T_Rate / 100.00).toFixed(2);
                    document.getElementById("txt_SGST_Amt").value = (parseFloat(Cr_Dr_Amt) * T_Rate / 100.00).toFixed(2);
                    document.getElementById("txt_IGST_Amt").value = '';
                }
                else if (Local_Other == 'O') {
                    document.getElementById("txt_CGST_Amt").value = '';
                    document.getElementById("txt_SGST_Amt").value = '';
                    document.getElementById("txt_IGST_Amt").value = (parseFloat(Cr_Dr_Amt) * Tax_Rate / 100.00).toFixed(2);
                }
            }
            else {
                document.getElementById("txt_CGST_Amt").value = '';
                document.getElementById("txt_SGST_Amt").value = '';
                document.getElementById("txt_IGST_Amt").value = '';
            }
        }
    </script>
    <%------------------TDS----------------------------------------------%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txt_Tds_Rate').focus(function () {
                var data = $(this).val();
                TDS_Amt(data);
            });
            $('#txt_Tds_Rate').change(function () {
                var data = $(this).val();
              
                TDS_Amt(data);
            });
            $('#txt_Tds_Rate').keyup(function () {
                var data = $(this).val();
                TDS_Amt(data);
            });
            $('#txt_Tds_Rate').keydown(function () {
                var data = $(this).val();
                TDS_Amt(data);
            });
            $('#txt_Tds_Rate').keypress(function () {
                var data = $(this).val();
               
                TDS_Amt(data);
            });
        });

        function TDS_Amt(val) {
          
            var CD_Amt = document.getElementById("txt_Debit_Credit_Amt").value;
            var Tds_Val = document.getElementById("txt_Tds_Rate").value;
            if (val != '') {

                if (CD_Amt != '') {
                    //(parseFloat(CD_Amt) * Tds_Val / 100.00).toFixed(2)
                    document.getElementById("txt_Tds_Amt").value = Math.round(parseFloat(CD_Amt) * Tds_Val / 100.00);
                }
                else {
                    document.getElementById("txt_Tds_Amt").value = '';
                }
            }
            else {
                document.getElementById("txt_Tds_Amt").value = '';
            }
        }
    </script>
    <%-------------------------------------------------------------------%>
    <script type="text/javascript">
        $(function () {
            $("#txtVendorbillno").autocomplete({
                source: function (request, response) {
                    var txtVendorbillno = $('#<%= txtVendorbillno.ClientID %>').val();
                    $.ajax({
                        url: "../PurchaseEntry.aspx/CheckUsername",
                        data: "{ 'mail': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtVendorbillno').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txtVendorbillno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#txtVendorbillno").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../Accounts_Auto_Search/Accounts_Auto_Search.asmx/Vendor_Bill_No",
                        data: "{ 'mail': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtVendorbillno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                            else {

                                jQuery('#txtVendorbillno').validationEngine('showPrompt', 'Already Exists !', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });

        function Charge_head() {

            var TDS = document.getElementById("ddl_TDS").value;
            if (TDS == 'N') {
                document.getElementById("txt_Tds_Rate").value = "";
                document.getElementById("txt_Tds_Amt").value = "";
            } else {
                var charge = document.getElementById("ddl_Charge_head").value;
                var parts = charge.split("~");
                PageMethods.Get_Tds_Rate(parts[1], parts[0], CallSuccess_Invoice_Cur);
            }
        }
        function CallSuccess_Invoice_Cur(res) {
            var data = res;
            document.getElementById("txt_Tds_Rate").value = res;
            TDS_Amt(document.getElementById("ddl_Tax_Rate").value);

        }
        
    </script>
</body>
</html>
