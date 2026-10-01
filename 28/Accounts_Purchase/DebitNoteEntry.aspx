<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DebitNoteEntry.aspx.cs"    Inherits="DebitNoteEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>DebitNote Entry</title>
    
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
        div.fileinputs {
            position: relative;
        }

        div.fakefile {
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 1;
        }

        input.file {
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
            
            <div id="innerbox_MidMain_Billing" style="height: 160px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 125px;">
                        DebitNote Entry
                    </div>
                  <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                   
                        <div id="txtcon-m_Exchange" style="width: 220px; margin-top: 5px;">
                            <asp:RadioButtonList ID="Rd_Royal_Other" Font-Bold="true" ForeColor="Blue" runat="server"
                                RepeatDirection="Horizontal" TabIndex="10"  AutoPostBack="true"
                                onselectedindexchanged="Rd_Royal_Other_SelectedIndexChanged">
                                <asp:ListItem Text="eRoyal Jobs" Value="R" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Other Jobs" Value="O"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div id="verslic"></div>
                    <div id="txtcon-m_Exchange" style="width: 100px; margin-top:5px;">
                    Company Lic
                    </div>
                        <div id="txtcon-m_Exchange" style="width: 100px;margin-top:5px; color:Red;">
                           
                            <asp:Literal ID="lbl_Job_Company_Lic" runat="server"></asp:Literal>
                        </div>
                        <div id="verslic"></div>
                        <div id="txtcon-m_Exchange" style="width: 110px; margin-top:5px;">
                        Working Period
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 250px;margin-top:5px; color:Red;">
                        <asp:Literal ID="lbl_Job_Wrk_Period" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1200px; height: 100px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1200px; height: 90px;">
                        <div id="tag_transact_lft_in1" style="width: 1200px; height: 80px;">
                            <div style="width: 1200px; height: 30px">

                            <div id="txt_container_Transact_Main_l" style="width: 1200px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        DebitNote No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 130px;">
                                        <asp:TextBox ID="txtDebitNote_no" Width="110px" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            TabIndex="6" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 60px;">
                                        Date
                                    </div>
                                <div id="txtcon-m_Exchange" style="width: 120px;">
                                    <asp:TextBox ID="txtDebitNote_Date" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                        TabIndex="8" Width="100px" runat="server"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDebitNote_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDebitNote_Date"
                                        PopupButtonID="txtDebitNote_Date" Enabled="true" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>


                                 <div id="tag_label_transact_Src" style="width: 85px;">
                                        Purchase No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 200px">
                                        <asp:DropDownList ID="ddl_Purchase_No" class="validate[required]  chosen-select-deselect"
                                            Style="width: 190px;" data-placeholder="Choose a Purchase No" AutoPostBack="true"
                                            runat="server" TabIndex="12" 
                                            onselectedindexchanged="ddl_Purchase_No_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                    </div>

                                 
                                    <div id="txtcon-m_Exchange" style="width: 210px;">
                                          <asp:RadioButtonList ID="Rd_Bill_Type" runat="server" RepeatDirection="Horizontal" TabIndex="9" Enabled="false">
                                            <asp:ListItem Text="Local State" Value="L" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Other State" Value="O"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                      <div id="tag_label_transact_Src" style="width: 85px;">
                                       Under Name
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 210px; color:Maroon;">
                                        <asp:Literal ID="lbl_under_name" runat="server"></asp:Literal>
                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="width: 1200px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Vendor Name
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 360px; font-size:12px;">
                                      <%--  <asp:DropDownList ID="ddlVendorname" class="validate[required]  chosen-select-deselect"
                                            Style="width: 355px;" data-placeholder="Choose a Vendorname" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlVendorname_SelectedIndexChanged" runat="server" TabIndex="10">
                                        </asp:DropDownList>--%>
                                        <asp:Literal ID="lbl_Ven_Name" runat="server"></asp:Literal>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 85px;">
                                        Branch
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 200px;font-size:12px;">
                                      <%--  <asp:DropDownList ID="ddlVendorBranch" class="validate[required]  chosen-select-deselect"
                                            Style="width: 190px;" data-placeholder="Choose a Branch No" AutoPostBack="true"
                                            runat="server" TabIndex="12" OnSelectedIndexChanged="ddlVendorBranch_SelectedIndexChanged">
                                        </asp:DropDownList>--%>
                                        <asp:Literal ID="lbl_Ven_Branch" runat="server"></asp:Literal>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Vendor State
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px">
                                        <asp:TextBox ID="txtVendorstate" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                            ForeColor="Green" Font-Bold="true" Enabled="false" TabIndex="12" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        GSTN No.
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px">
                                        <asp:TextBox ID="txtGstn" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                            ForeColor="Green" Font-Bold="true" Enabled="false" Width="140px" TabIndex="13"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 1450px">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        GSTN Type
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px">
                                        <asp:TextBox ID="txtGstntype" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                            ForeColor="Green" Font-Bold="true" Enabled="false" TabIndex="14" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Country
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 140px">
                                        <asp:TextBox ID="txtCountry" Width="130px" CssClass="txtbox_none_Mid_transac_code"
                                            Style="border: 0px none;" ForeColor="Green" Font-Bold="true" Enabled="false"
                                            TabIndex="16" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 145px;">
                                        <asp:RadioButtonList ID="Rd_Debit_Credit" runat="server" RepeatDirection="Horizontal"
                                            TabIndex="15" ForeColor="Blue" Font-Bold="true" Enabled="false">
                                            <asp:ListItem Text="Debit" Value="D" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Credit" Value="C"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 60px;">
                                        Narration
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 460px">
                                        <asp:TextBox ID="txtNarration" CssClass=" txtbox_none_Mid_transac_code" Width="450px"
                                            TabIndex="17" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 1200px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Vendor Bill No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <%--<asp:TextBox ID="txtVendorbillno" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            TabIndex="18" runat="server"></asp:TextBox>--%>
                                        <asp:Literal ID="lbl_Ven_billno" runat="server"></asp:Literal>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Bill Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                         <asp:Literal ID="lbl_Ven_bill_Date" runat="server"></asp:Literal>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 85px;">
                                        Bill Amount
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 90px;">
                                        <asp:TextBox ID="txtbillamount" Width="80px" ForeColor="Blue" Font-Bold="true" runat="server"
                                            Style="text-align: right;" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" autocomplete="off"
                                            TabIndex="20" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Currency
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 60px;">
                                        <asp:TextBox ID="txtBill_Cur" Style="border: 0px none;" ForeColor="Green" Font-Bold="true"
                                            Width="50px" runat="server" ClientIDMode="Static" TabIndex="22" onkeypress="return char1(event)"
                                            Text="INR" Enabled="false" MaxLength="3" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 60px;">
                                        Ex Rate
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 60px;">
                                        <asp:TextBox ID="txtExrate" runat="server" Style="border: 0px none;" ForeColor="Green"
                                            Font-Bold="true" onfocusout="tap()" Text="1" Width="50px" TabIndex="23" Enabled="false"
                                            MaxLength="50" CssClass="validate[required] txtbox_none_Mid_transac_code"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Total Amt In INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 120px;">
                                        <asp:TextBox ID="txtTotalamtininr" runat="server" Width="100px" ForeColor="Green"
                                            Font-Bold="true" Style="border: 0px none;" MaxLength="50" TabIndex="24"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 70px; margin-top: -10px;">
                                        <asp:Button ID="btn_Save_Update" CssClass="autowidmovebut" Width="65px" TabIndex="30"
                                            runat="server" OnClick="btn_Save_Update_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            
            
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -30px;">
            <div id="innerbox_MidMain_Trans_new" style="height:417px; width:1298px; margin-left:-16px; margin-top:-25px;">
            
            <div id="pop_text_area_transac_popup_inn_container_export" style="height:150px;margin-top:30px;">
             <div id="tag_transact_src_inner" style="width: 1200px">

             <div id="tag_Exchange_inner_lft" style="width: 1200px">
             <%-- --------------------S----------------------------%>
              <div id="tag_transact_lft_in1" style="width: 1200px; height:35px;">

                 <div id="txt_container_Transact_Main_l" style="width: 95px;">
                     <div id="tag_label_transact_Src" style="width: 35px;">
                         Slno:
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 60px;">
                         <asp:DropDownList ID="ddlslno" CssClass="listtxt_transac_mode_new" Style="width: 50px;"
                              runat="server" TabIndex="32" Enabled="false">
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
                 <div id="txt_container_Transact_Main_l" style="width: 120px">
                     <div id="txtcon-m_Exchange" style="width: 110px">
                         <asp:RadioButtonList ID="Rd_IMP_EXP" runat="server" RepeatDirection="Horizontal"
                             ForeColor="Blue" Font-Bold="true"  TabIndex="34"   AutoPostBack="true"  
                              OnSelectedIndexChanged="Rd_IMP_EXP_SelectedIndexChanged"   >
                             <asp:ListItem Text="Imp" Value="I" Selected="True"></asp:ListItem>
                             <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                         </asp:RadioButtonList>
                     </div>
                 </div>
                              
                 <div id="txt_container_Transact_Main_l" style="width: 380px;">
                     <div id="tag_label_transact_Src" style="width: 50px">
                         Jobno
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 170px;">
                         <asp:DropDownList ID="ddljobno" class="chosen-select-deselect" Style="width: 170px;font-size:12px;" visible="false"
                       AutoPostBack="true" 
                      OnSelectedIndexChanged="ddljobno_SelectedIndexChanged"  data-placeholder="Choose a Jobno" runat="server" TabIndex="35" >
                         </asp:DropDownList>
                     </div>
                         <div id="txtcon-m_Exchange" style="width: 140px;">
                        <asp:TextBox ID="txt_Other_Jobno" runat="server" Width="140px" ForeColor="Blue"  MaxLength="20" CssClass="txtbox_none_Mid_transac_code"
                           ClientIDMode="Static" TabIndex="35"></asp:TextBox>
                            </div>
                 </div>

                 <div id="txt_container_Transact_Main_l" style="width: 170px;">
                     <div id="tag_label_transact_Src" style="width: 70px">
                         Job Date
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 90px;">
                          <asp:TextBox ID="txt_JobDate" runat="server" width="80px" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="37" Enabled="false"></asp:TextBox>
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

                 <div id="txt_container_Transact_Main_l" style="width: 420px;">
                     <div id="tag_label_transact_Src" style="width: 120px;">
                         Customer Name
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 275px; font-size:12px;">
                        <%-- <asp:DropDownList ID="ddl_Cus_Name" class="validate[required]  chosen-select-deselect"
                             Style="width: 350px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                             runat="server" TabIndex="38">
                         </asp:DropDownList>--%>
                         <asp:Literal ID="lbl_Cus_Name" runat="server"></asp:Literal>
                     </div>
                 </div>
                 </div>
                 <%-- --------------------R2----------------------------%>          
                 <div id="tag_transact_lft_in1" style="width: 1200px; height: 35px;">
                 <div id="txt_container_Transact_Main_l" style="width: 460px;">
                     <div id="tag_label_transact_Src" style="width: 100px;">
                         Charge Head
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 350px;">
                         <asp:DropDownList ID="ddl_Charge_head" class="chosen-select-deselect" Style="width: 345px;"
                             data-placeholder="Choose a Charge Name" runat="server" TabIndex="39">
                         </asp:DropDownList>
                     </div>
                 </div>
                  <div id="txt_container_Transact_Main_l" style="width: 150px;">
                     <div id="tag_label_transact_Src" style="width: 70px">
                         Tax Rate
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 70px;">
                         <asp:DropDownList ID="ddl_Tax_Rate" CssClass="listtxt_transac_mode_new" Style="width: 65px;"
                              runat="server" TabIndex="40" >
                             <asp:ListItem Text="" Value="0"></asp:ListItem>
                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                            <asp:ListItem Text="18" Value="18"></asp:ListItem>
                         </asp:DropDownList>
                     </div>
                 </div>

                 <div id="txt_container_Transact_Main_l" style="width: 550px;">
                     <div id="tag_label_transact_Src" style="width: 120px; color:Blue; font-weight:bold;">
                         Debit / Credit Amt
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 90px;">
                         <asp:TextBox ID="txt_Debit_Credit_Amt" Width="80px" Font-Bold="true" ForeColor="Blue" TabIndex="42"
                         onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                         autocomplete="off" CssClass="txtbox_none_Mid_transac_code" runat="server"></asp:TextBox>
                     </div>
                     <div id="tag_label_transact_Src" style="width: 85px;">
                         TDS Rate %
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 70px;">
                            <asp:TextBox ID="txt_Tds_Rate" Width="60px" CssClass="txtbox_none_Mid_transac_code" TabIndex="43"
                             onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                             autocomplete="off" runat="server"></asp:TextBox>
                     </div>
                     <div id="tag_label_transact_Src" style="width: 100px;">
                        Balance Amt
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 85px;">
                          <asp:TextBox ID="txt_D_C_bal_Amt"  runat="server" Width="80px" ForeColor="Green" Font-Bold="true" style="border: 0px none;"  
                            MaxLength="50" TabIndex="45"  ></asp:TextBox>
                     </div>
                 </div>
                 </div>
                  <%-- --------------------R3----------------------------%> 
                    <div id="tag_transact_lft_in1" style="width: 1200px; height: 35px;">
                 <div id="txt_container_Transact_Main_l" style="width: 380px;">
                     <div id="tag_label_transact_Src" style="width: 100px;">
                         
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 360px;">
                         
                     </div>
                 </div>
                  <div id="txt_container_Transact_Main_l" style="width: 170px;">
                     <div id="tag_label_transact_Src" style="width: 70px; color:Green; font-weight:bold;">
                         CGST Amt
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 90px;">
                        <asp:TextBox ID="txt_CGST_Amt"  runat="server" Width="85px" ForeColor="Red" Font-Bold="true" style="border: 0px none;" 
                        MaxLength="50" TabIndex="46"  ></asp:TextBox>

                     </div>
                 </div>

                 <div id="txt_container_Transact_Main_l" style="width: 620px;">
                     <div id="tag_label_transact_Src" style="width: 120px;color:Green; font-weight:bold;">
                         SGST Amt
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 100px;">
                              <asp:TextBox ID="txt_SGST_Amt"  runat="server" Width="90px" ForeColor="Red" Font-Bold="true" style="border: 0px none;" 
                                MaxLength="50" TabIndex="47"  ></asp:TextBox>
                     </div>
                     <div id="tag_label_transact_Src" style="width: 90px;color:Green; font-weight:bold;">
                        IGST Amt
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 90px;">
                        <asp:TextBox ID="txt_IGST_Amt"  runat="server" Width="70px" ForeColor="Red" Font-Bold="true"
                            style="border: 0px none;"   MaxLength="50" TabIndex="48"  ></asp:TextBox>
                                         
                     </div>
                        <div id="tag_label_transact_Src" style="width: 100px;color:Green; font-weight:bold;">
                        TDS Amt
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 110px;">
                          <asp:TextBox ID="txt_Tds_Amt"  runat="server" Width="100px" ForeColor="Red" Font-Bold="true" style="border: 0px none;"  
                            MaxLength="50" TabIndex="50"  ></asp:TextBox>
                     </div>


                 </div>
                 </div>
                  <%-- --------------------R4----------------------------%> 
                  <div id="tag_transact_lft_in1" style="width: 1200px; height: 10px;">
                 <div id="txt_container_Transact_Main_l" style="width: 570px;">
                     <div id="tag_label_transact_Src" style="width: 100px;">
                         
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 460px;">
                         
                     </div>
                 </div>
                  <div id="txt_container_Transact_Main_l" style="width: 200px;">
                     <div id="tag_label_transact_Src" style="width: 80px">
                         
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 110px;">
                         
                     </div>
                 </div>

                 <div id="txt_container_Transact_Main_l" style="width: 500px;">
                     <div id="tag_label_transact_Src" style="width: 120px;">
                        
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 130px;">
                          <%--<asp:TextBox ID="txt_Tds_Rate" Width="100px" CssClass="txtbox_none_Mid_transac_code" runat="server"></asp:TextBox>--%>
                     </div>
                     <div id="tag_label_transact_Src" style="width: 100px;">
                        
                     </div>
                     <div id="txtcon-m_Exchange" style="width: 120px;">
                 <%--    <asp:TextBox ID="txt_Tds_Amt"  runat="server" Width="100px" ForeColor="Green" Font-Bold="true" style="border: 0px none;"
                        MaxLength="50" TabIndex="24"  ></asp:TextBox>--%>
                     </div>
                 </div>
                 </div>
                   <%-- --------------------R5----------------------------%> 
                 <div id="innerbox_MidMain_bot_transact" style="margin-top: 0px">
                            <div id="innerbox_transac_bot_inn" style="width: 500px;">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" TabIndex="54" CssClass="new" OnClick="btnNew_Click"
                                        OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                                        UseSubmitBehavior="false" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" CommandName="s" Visible="false"
                                        OnClientClick="return validate();" TabIndex="51" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                                        OnClick="btnUpdate_Click" Visible="false" TabIndex="52" OnClientClick="return validation();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="53" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'DebitNote Entry', function(r) {
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
                                   <%-- <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1_Trigger_AnotherPage('General',document.getElementById('hdn_source').value);return false;"
                                        id="btnCancel" tabindex="55">--%>
                                </div>
                                
                            </div>
                            
                        </div>
                <%-- --------------------E----------------------------%>   
                </div>
                        </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_IGM_gateway_grid" style="margin-top:0px; margin-left:3px;width:1200px;">
                            <div id="pop_text_area_transac_popup_inn_container_IGM_Container2_grid_gateway" runat="server"  style=" overflow:auto; height:232px;width:1190px;">

                                <asp:GridView ID="gv_Ch" runat="server" 
                                    DataKeyNames="DC_ID,DEBITNOTE_NO,JOBNO,JOBNO_PS" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="120%"
                                    ShowHeaderWhenEmpty="True" PageSize="8" AllowPaging="True" OnRowDataBound="gv_Ch_RowDataBound"
                                    OnSelectedIndexChanged="gv_Ch_SelectedIndexChanged"
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="1" CellSpacing="1" OnRowCreated="gv_Ch_RowCreated" 
                                    onpageindexchanging="gv_Ch_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        BorderWidth="1px" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>

                                        <asp:BoundField DataField="SLNO" HeaderText="S.No" ControlStyle-Width="50px">
                                           <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IMP_EXP" HeaderText="Imp/Exp" ControlStyle-Width="50px">
                                           <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="JOBNO_PS" HeaderText="Jobno" ControlStyle-Width="50px">
                                           <ItemStyle CssClass="column_style_left5" Width="50px" HorizontalAlign="Left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="JOB_DATE" HeaderText="Jobdate"  ControlStyle-Width="50px">
                                           <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer Name" ControlStyle-Width="250px">
                                           <ItemStyle CssClass="column_style_left5" Width="250px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CHARGE_NAME" HeaderText="Charge Head" ControlStyle-Width="250px">
                                           <ItemStyle CssClass="column_style_left5" Width="250px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TAX_RATE" HeaderText="Tax Rate" ControlStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CR_DE_AMT" HeaderText="Debit / Credit Amt" ControlStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" Width="100px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="CGST_AMT" HeaderText="CGST Amt" ControlStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="SGST_AMT" HeaderText="SGST Amt" ControlStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="IGST_AMT" HeaderText="IGST Amt" ControlStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TDS_RATE" HeaderText="TDS Rate" ControlStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="TDS_AMOUNT" HeaderText="TDS Amt" ControlStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" Width="50px" />
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

            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HD_Ch_update_id" runat="server" />
      <asp:HiddenField ID="HDn_SIno" runat="server" />
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

    <script type="text/javascript">

        function open_jobno() {

            if (document.getElementById("<%=txtDebitNote_no.ClientID %>").value != '') {
                var f = document.getElementById("<%=txtDebitNote_no.ClientID %>").value;
               // NewWindow1('../Billing_Imp_Rpt/Purchase_Entry_Report.aspx?voucherno=' + f + '', 'List', '870', '1024', 'yes');
                return false
            }

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
                        document.getElementById("txt_Tds_Amt").value = (parseFloat(CD_Amt) * Tds_Val / 100.00).toFixed(2);
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
</body>
</html>
