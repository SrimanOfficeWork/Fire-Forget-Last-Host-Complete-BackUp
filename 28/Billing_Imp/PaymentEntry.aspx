<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentEntry.aspx.cs" Inherits="PaymentEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Payments </title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 7.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 10em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
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
    <style type="text/css">
        input.underlined
        {
            border: solid 1px #000;
        }
    </style>

     <script language="javascript">
         function B_G_tab_page2() {

             document.getElementById('page-1').style.display = 'Block';
           
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'block';
             
         }
   </script>
     
    <script type="text/javascript">
        function Char_Inv(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
                return false;
            return true;
        }
    </script>

      <script type="text/javascript">
          $(function () {
              $("[id*=gv_Chg_Details] td").bind("click", function () {
                  var row = $(this).parent();
                  $("[id*=gv_Chg_Details] tr").each(function () {
                      if ($(this)[0] != row[0]) {
                          $("td", this).removeClass("selected_row");
                      }
                  });
                  $("td", row).each(function () {
                      if (!$(this).hasClass("selected_row")) {
                          $(this).addClass("selected_row");
                      } else {
                          $(this).removeClass("selected_row");
                      }
                  });
              });
          });
    </script>

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
            <div id="innerbox_MidMain" style="height: 95px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                        Payment-Entry
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;display:none">
                        <div id="txtcon-m_Exchange" style="width: 180px;">
                            <asp:RadioButtonList ID="Rd_Job_Type" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="true" OnSelectedIndexChanged="Rd_Job_Type_SelectedIndexChanged">
                                <asp:ListItem Text="Imp" Value="Imp" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Exp" Value="Exp"></asp:ListItem>
                                <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                  
                    <div id="tag_transac_lft_in2" style="display:none">
                        <span runat="server" id="WK" visible="false">
                            <div id="tag_label_transaction_popup_gen">
                                Working Period</div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlWorkingPeriod_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </span>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1100px">
                    <div id="tag_Exchange_inner_lft" style="width: 1100px">
                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div style="width: 1100px; height: 150px;">
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Vendor:
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 85px">
                                        <asp:DropDownList ID="ddlCustomer" CssClass="listtxt_transac_item_gen_notn" Width="162px"
                                            runat="server" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Branch:
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 85px">
                                        <asp:DropDownList ID="ddlbranch_No" CssClass="listtxt_transac_item_gen_notn" Width="162px"
                                            runat="server" TabIndex="2" AutoPostBack="true" OnSelectedIndexChanged="ddlbranch_No_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Payment No :
                                    </div>
                                    <div id="txtcon-m_Exchange">
                                        <asp:TextBox ID="txtPaymentNo" runat="server" MaxLength="50" TabIndex="3" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Payment Date :
                                    </div>
                                    <div id="txtcon-m_Exchange">
                                        <asp:TextBox ID="txtDate" runat="server"  MaxLength="10" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="4"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Mode of Payment :
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 85px">
                                        <asp:DropDownList ID="ddlModeofPay" CssClass="listtxt_transac_item_gen_notn" Width="162px"
                                            runat="server" TabIndex="5" AutoPostBack="true" OnSelectedIndexChanged="ddlModeofPay_SelectedIndexChanged">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                            <asp:ListItem Value="Net Banking">Net Banking</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Payment For:
                                    </div>
                                    <div id="txtcon-m_Exchange">
                                        <asp:RadioButtonList ID="RdPayFor" runat="server" RepeatDirection="Horizontal" TabIndex="6">
                                            <asp:ListItem Text="Bill" Value="Job" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="AdvPayment" Value="Advance"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content" id="page-1" style="margin-top: -28px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 450px; width: 1290px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"  id="Page_A" runat="server">
                        <span>General </span></a></li>
                        <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');"
                            id="Page_B" runat="server"  onserverclick="RDBillInvNo_CheckedChanged" ><span>Payment History</span></a></li>
                       <%-- <li ><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server" visible="false">
                        <span>Gen -3</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        <span> Gen -4 </span></a></li>--%>
                    </ol>
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 380px;
                            margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1150px; height: 200px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1000px">
                                    <div id="pop_text_area_transac_popup_inn_container_new" style="height: 150px;">
                                        <div id="pop_text_area_transac_popup_inn_container_left_new" style="width: 700px;">
                                            <fieldset id="fld" style="height: 110px; width: 170px">
                                                <legend style="border: Black; border-collapse: collapse; width: 170px; text-align: center;">
                                                    Received Amount Details </legend>
                                                <div id="tag_transac_lft_in1" style="height: 3px;">
                                                </div>
                                                <div id="DivCheque" runat="server" style="height: 65px; width: 500px">
                                                    <asp:Panel ID="PnlCheque" runat="server" Enabled="false">
                                                        <div id="txt_container_Transact_Main_l">
                                                            <div id="tag_label_transact_Src" style="width: 500px;">
                                                                Ref / Chq #:
                                                                <asp:TextBox ID="txtChqNo" runat="server" Width="80px" MaxLength="20" CssClass="txtbox_none_Mid_transac_code"
                                                                    TabIndex="13"></asp:TextBox>
                                                                Ref / Chq Date:
                                                                <asp:TextBox ID="txtChqDate" runat="server" Width="85px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                                    TabIndex="14"></asp:TextBox>
                                                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtChqDate"
                                                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                    Enabled="True">
                                                                </asp:MaskedEditExtender>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtChqDate"
                                                                    Format="dd/MM/yyyy" Enabled="True">
                                                                </asp:CalendarExtender>
                                                                Amount:
                                                                <asp:TextBox ID="txtChqAmt" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="15"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div id="txt_container_Transact_Main_l">
                                                            <div id="tag_label_transact_Src" style="width: 500px;">
                                                                Bank:
                                                                <asp:TextBox ID="txtChqBank" runat="server" Width="100px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"
                                                                    TabIndex="16"></asp:TextBox>
                                                                Branch:
                                                                <asp:TextBox ID="txtChqBranch" runat="server" Width="100px" MaxLength="200" CssClass="txtbox_none_Mid_transac_code"
                                                                    TabIndex="17"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <div id="pop_text_area_transac_popup_inn_container_left_new" style="display: none;">
                                            <fieldset id="fld">
                                                <legend style="border: Black; border-collapse: collapse; width: 50px; text-align: center;">
                                                    Cash </legend>
                                                <div id="tag_transac_lft_in1" style="height: 3px;">
                                                </div>
                                                <div id="DivCash" runat="server">
                                                    <asp:Panel ID="PnlCash" runat="server" Enabled="false">
                                                        <div id="txt_container_Transact_Main_l">
                                                            <div id="tag_label_transact_Src" style="width: 100px;">
                                                                Cash Amount:
                                                            </div>
                                                            <div id="txtcon-m_Exchange">
                                                                <asp:TextBox ID="txtCashAmt" runat="server" Width="100px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="7"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                </div>
                                            </fieldset>
                                            <fieldset id="fld">
                                                <legend style="border: Black; border-collapse: collapse; width: 100px; text-align: center;">
                                                    Net-Banking </legend>
                                                <div id="DivNetbank" runat="server" style="height: 35px; width: 200px">
                                                    <asp:Panel ID="PnlNetBank" runat="server" Enabled="false">
                                                        <div id="txt_container_Transact_Main_l">
                                                            <div id="tag_label_transact_Src" style="width: 500px;">
                                                                Bank:
                                                                <asp:TextBox ID="txtNetBank" runat="server" Width="100px" CssClass="txtbox_none_Mid_transac_code"
                                                                    MaxLength="100" TabIndex="8"></asp:TextBox>
                                                                Branch:
                                                                <asp:TextBox ID="txtNetBranch" runat="server" Width="100px" MaxLength="200" CssClass="txtbox_none_Mid_transac_code"
                                                                    TabIndex="9"></asp:TextBox>
                                                                Amount:
                                                                <asp:TextBox ID="txtNetAmt" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div id="txt_container_Transact_Main_l">
                                                            <div id="tag_label_transact_Src" style="width: 500px;">
                                                                Ref #:
                                                                <asp:TextBox ID="txtNetRefno" runat="server" Width="100px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"
                                                                    TabIndex="11"></asp:TextBox>
                                                                Ref Date:
                                                                <asp:TextBox ID="txtNetRefDt" runat="server" Width="100px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                                    TabIndex="12"></asp:TextBox>
                                                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtNetRefDt"
                                                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                    Enabled="True">
                                                                </asp:MaskedEditExtender>
                                                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtNetRefDt"
                                                                    Format="dd/MM/yyyy" Enabled="True">
                                                                </asp:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <%--               <div id="pop_text_area_transac_popup_inn_container_rght_new">
                                            <fieldset id="fld" style="height: 110px; width: 170px">
                                                <legend style="border: Black; border-collapse: collapse; width: 100px; text-align: center;">
                                                    Cheque </legend>
                                                <div id="tag_transac_lft_in1" style="height: 3px;">
                                                </div>
                                                <div id="DivCheque" runat="server" style="height:65px; width:200px">
                                                    <asp:Panel ID="PnlCheque" runat="server" Enabled="false">
                                                        

                                                           <div id="txt_container_Transact_Main_l">

                                                            <div id="tag_label_transact_Src" style="width: 500px;">
                                                                Chq #:
                                                           
                                                              <asp:TextBox ID="txtChqNo" runat="server" Width="80px" MaxLength="20" CssClass="txtbox_none_Mid_transac_code"
                                                                        TabIndex="13"></asp:TextBox>
                                                           
                                                                 Chq Date:
                                                          
                                                               <asp:TextBox ID="txtChqDate" runat="server" Width="85px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                                        TabIndex="14"></asp:TextBox>
                                                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtChqDate"
                                                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                        Enabled="True">
                                                                    </asp:MaskedEditExtender>
                                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtChqDate"
                                                                        Format="dd/MM/yyyy" Enabled="True">
                                                                    </asp:CalendarExtender>
                                                          
                                                               Amount:
                                                          
                                                                  <asp:TextBox ID="txtChqAmt" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                                        onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                                                        onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="15"></asp:TextBox>
                                                            </div>

                                                        </div>

                                                         <div id="txt_container_Transact_Main_l">

                                                            <div id="tag_label_transact_Src" style="width: 500px;">
                                                                Bank:
                                                           
                                                             <asp:TextBox ID="txtChqBank" runat="server" Width="100px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"
                                                                        TabIndex="16"></asp:TextBox>
                                                           
                                                                 Branch:
                                                          
                                                               <asp:TextBox ID="txtChqBranch" runat="server" Width="100px" MaxLength="200" CssClass="txtbox_none_Mid_transac_code"
                                                                        TabIndex="17"></asp:TextBox>
                                                           
                                                            </div>

                                                        </div>

                                                    </asp:Panel>
                                                </div>
                                            </fieldset>
                                        </div> --%>
                                    </div>
                                    <div id="pop_text_area_transac_popup_inn_container_rght_new">
                                        <div id="txt_container_Transact_Main_l">
                                            <div id="tag_label_transact_Src" style="width: 500px; margin-top: -130px">
                                                Narration:
                                                <asp:TextBox ID="txtCommNarration" runat="server" MaxLength="1000" TextMode="MultiLine"
                                                Style="width: 411px; height: 30px" TabIndex="18"></asp:TextBox>                                                
                                            </div>
<%--                                            <div id="tag_label_transact_Src" style="width: 500px; margin-top: -100px;">
                                                Bill Load:                                               
                                               <asp:RadioButtonList ID="RdBillLoad" runat="server" RepeatDirection="Horizontal" TabIndex="19">
                                                <asp:ListItem Text="Manual" Value="Manual" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Auto" Value="Auto"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>--%>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="display:none;">
                                            <div id="tag_label_transact_Src" style="width: 500px; margin-top: -50px">
                                                <div id="txtcon-m_Exchange"  style="margin-top: -50px">
                                                    Bills Load : 
                                                    <asp:RadioButtonList ID="RdBillsLoad" runat="server" RepeatDirection="Horizontal" TabIndex="19" >
                                                        <asp:ListItem Text="Manual" Value="Manual" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Auto" Value="Auto"></asp:ListItem>
                                                    </asp:RadioButtonList>  
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="width: 1100px; height: 3px; margin-top: 135px; margin-left:510px">
                                    <div id="txt_container_Transact_Main_l">
                                        <div id="tag_label_transact_Src" style="width: 700px; margin-top:-16px">
                                            
                                         
                                            <%--<asp:TextBox ID="txtCommNarration2" runat="server" MaxLength="1000" TextMode="MultiLine"
                                                Style="width: 411px; height: 30px" TabIndex="18"></asp:TextBox>--%>
                                        </div>
                                    </div>
                                </div> 

                                <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 230px;
                                    width: 1290px; margin-top: -20px; margin-left: -18px;">
                                    <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                        AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" 
                                        ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                                        AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                        OnRowDataBound="gv_Chg_Details_RowDataBound" OnRowDeleting="gv_Chg_Details_RowDeleting"
                                        Style="overflow-x: hidden; overflow-y: auto;" OnRowCreated="gvAll_RowCreated" OnRowCommand="gv_Chg_Details_RowCommand" >
                                        <RowStyle BorderWidth="0.1em" BorderColor="black" Height="50px" />
                                        <Columns>
                                        
                                            <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk_inv" runat="server" HeaderText="chkSelect" Width="30px" />
                                                    <input name="RDBillInvNo" type="radio" value='<%# Eval("Bill_inv_No") %>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Branch" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtUser_BranchName" CssClass="underlined" placeholder="Enter Branch"
                                                        runat="server" Height="20px" Width="80px" Font-Size="12px" ReadOnly="false" Text='<%# Bind("USER_BRANCHNAME") %>' ></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="190px" />
                                            </asp:TemplateField>
                                            

                                            <asp:TemplateField HeaderText="Bill No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                                <ItemTemplate>                                                                                                
                                               <%-- <asp:Label ID="lblBill_inv_No" runat="server" Text='<%# Eval("Bill_inv_No") %>' Visible = "false" />
                                                    <asp:DropDownList ID="ddlBill_inv_No" 
                                                        runat="server" Height="20px" Width="100px" Font-Size="12px" CssClass="chosen-select-deselect">
                                                    </asp:DropDownList>   --%>

                                                   <%-- <asp:TextBox ID="txtBill_inv_No" CssClass="underlined" placeholder="Enter Bill No"
                                                        runat="server" Height="20px" Width="100px" Font-Size="12px" ReadOnly="false"></asp:TextBox> --%>

                                                    <asp:TextBox ID="txtBill_inv_No" CssClass="underlined billinv" placeholder="Enter Bill No"  
                                                    runat="server" Height="20px" Width="140px" Font-Size="12px" Text='<%# Bind("BILL_INV_NO") %>' ClientIDMode="Static" AutoPostBack="false"  onfocusout="Bill_Details_Finder(this)" ></asp:TextBox>



                                                </ItemTemplate>
                                                <ItemStyle Width="140px" />
                                            </asp:TemplateField>



                                           <%-- <asp:BoundField DataField="Bill_inv_date" HeaderStyle-Font-Bold="true" DataFormatString="{0:dd/MM/yyyy}"
                                                HeaderText="Bill Date" HeaderStyle-Width="70px">
                                                <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px" Font-Size="11px" />
                                            </asp:BoundField>  --%> 
                                            
                                            <asp:TemplateField HeaderText="Bill Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBill_inv_date" CssClass="underlined" placeholder="" runat="server" ReadOnly="false"
                                                        Text='<%# Bind("Bill_inv_date") %>' Height="20px" Width="70px" Font-Size="12px" ></asp:TextBox>

                                                         <asp:MaskedEditExtender ID="MaskedEditExtender41" runat="server" TargetControlID="txtBill_inv_date"
                                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                        Enabled="True" >
                                                    </asp:MaskedEditExtender>
                                                    <asp:CalendarExtender ID="CalendarExtender42" runat="server" TargetControlID="txtBill_inv_date"
                                                        Format="dd/MM/yyyy" Enabled="True">
                                                    </asp:CalendarExtender>

                                                </ItemTemplate>
                                                <ItemStyle Width="70px" />
                                            </asp:TemplateField>                                             



                                           <%-- <asp:BoundField DataField="JobNo" HeaderStyle-Font-Bold="true" HeaderText="Job No"
                                                HeaderStyle-Width="50px">
                                                <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px" Font-Size="11px" />
                                            </asp:BoundField>    --%>

                                            <asp:TemplateField HeaderText="Voucher No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtJOBNO" CssClass="underlined" placeholder="" runat="server" ReadOnly="false" Text='<%# Bind("JOBNO") %>'
                                                        Height="20px" Width="70px" Font-Size="12px" ></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" />
                                            </asp:TemplateField>

                                           <%-- <asp:BoundField DataField="Imp_Exp" HeaderStyle-Font-Bold="true" HeaderText="I/E"
                                                HeaderStyle-Width="50px">
                                                <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px" Font-Size="11px" />
                                            </asp:BoundField> --%> 
                                            
                                           <asp:TemplateField HeaderText="I/E" HeaderStyle-Font-Bold="true" HeaderStyle-Width="25px">                                                <ItemTemplate >
                                                    <asp:TextBox ID="txtIMP_EXP" CssClass="underlined" placeholder="" runat="server" ReadOnly="false"
                                                    Text='<%# Bind("IMP_EXP") %>'
                                                        Height="20px" Width="25px" Font-Size="12px"  ></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="25px" />
                                            </asp:TemplateField>
                                             
                                             
<%--                                            <asp:BoundField DataField="Total_Amt_Tax" HeaderStyle-Font-Bold="true" HeaderText="Bill Amount"
                                                HeaderStyle-Width="70px">
                                                <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px" Font-Size="11px" />
                                            </asp:BoundField>
--%>
                                            <asp:TemplateField HeaderText="Bill Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBillAmt" CssClass="underlined" placeholder="" runat="server" ReadOnly="false"
                                                     Text='<%# Bind("TOTAL_AMT_TAX") %>'                                                    
                                                        Height="20px" Width="70px" Font-Size="12px" style="text-align:right;"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" />
                                            </asp:TemplateField>



<%--                                           <asp:BoundField DataField="ReceivedAmt" HeaderStyle-Font-Bold="true" HeaderText="Already Received"
                                                HeaderStyle-Width="70px">
                                                <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px" Font-Size="11px" />
                                            </asp:BoundField>--%>

                                            <asp:TemplateField HeaderText="Already Paid" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtReceivedAmt" CssClass="underlined" placeholder="" runat="server" ReadOnly="false"
                                                    Text='<%# Bind("ReceivedAmt") %>'
                                                        Height="20px" Width="70px" Font-Size="12px" style="text-align:right;"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" />
                                            </asp:TemplateField>  


                                            <asp:TemplateField HeaderText="Balance Due" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBalAmt" CssClass="underlined" runat="server" ReadOnly="false"
                                                        Text='<%# Bind("BalanceAmt") %>' Height="20px" Width="80px" Font-Size="12px" style="text-align:right;"  ></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                            <%--HeaderText="Current payable"--%>
                                            <asp:TemplateField HeaderText="Current Payable" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPayAmt" CssClass="underlined" placeholder="Enter Amt" runat="server"
                                                        onblur="extractNumber(this,2,false); " onkeyup="extractNumber(this,2,false);return Clear_Dot(this); "
                                                        onkeypress="return blockNonNumbers(this, event, true, false);  " Height="20px"
                                                        Width="80px" Font-Size="12px" style="text-align:right;" Text='<%# Bind("CurrentPayable") %>' ></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TDS #" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTDSNo" CssClass="underlined" placeholder="Enter TDS#" runat="server"
                                                        Height="20px" Width="70px" Font-Size="12px" Text='<%# Bind("TDS_No") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="190px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TDS Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px">
                                                <ItemTemplate>
                                                        <%-- CssClass="txtbox_none_Mid_transac_code"  --%>
                                                    <asp:TextBox ID="txtTDSDate" runat="server"  MaxLength="10" CssClass="underlined"
                                                        Height="20px" Width="80px" Font-Size="12px" placeholder="Enter TDS Date"></asp:TextBox>
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTDSDate"
                                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                        Enabled="True" >
                                                    </asp:MaskedEditExtender>
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTDSDate"
                                                        Format="dd/MM/yyyy" Enabled="True">
                                                    </asp:CalendarExtender>
                                                </ItemTemplate>
                                                <ItemStyle Width="190px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TDS %" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTDSPercent" CssClass="underlined" placeholder="Enter%" runat="server"
                                                        onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                                        onkeypress="return blockNonNumbers(this, event, true, false);" Height="20px"
                                                        Width="40px" Font-Size="12px" Text='<%# Bind("TDS_Percent") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="190px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TDS Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTDSAmt" CssClass="underlined" placeholder="Enter Amt" runat="server"
                                                        onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                                        onkeypress="return blockNonNumbers(this, event, true, false);" Height="20px"
                                                        Width="80px" Font-Size="12px" Text='<%# Bind("TDS_Amt") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="190px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBillRemarks" CssClass="underlined" placeholder="Enter Remarks"
                                                        runat="server" Height="20px" Width="100px" Font-Size="12px" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="190px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Write Off" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkWrite" runat="server" HeaderText="WriteOff" Width="30px" />
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Write OffAmt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtWriteOffAmt" CssClass="underlined" placeholder="Enter Write OffAmt"

                                                     onblur="extractNumber(this,2,false); " onkeyup="extractNumber(this,2,false);return Clear_Dot(this); "
                                                        onkeypress="return blockNonNumbers(this, event, true, false);"
                                                        runat="server" Height="20px" Width="60px" Font-Size="12px" Text='<%# Bind("WriteoffAmt") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="190px" />
                                            </asp:TemplateField>
                <%--//////////////////////////////////////////////////////////////////////////////--%>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgRemove" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                              CommandName="DeleteRow"    ImageUrl="../images/icons/delete-sign.png" Width="20px" />
                                                    <%--<img src="../js/delete-sign.png" />
                                                                <asp:LinkButton ID="Lkbremove" runat="server" Font-Size="Small" OnClientClick="return RemoveRow(this)">Remove</asp:LinkButton>--%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button ID="Button2" runat="server" Width="40px" CommandName="add" Font-Size="Small"
                                                        CssClass="coma" Visible="true" Text="Add" OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField DeleteImageUrl="../js/delete-sign.png" />
                <%--//////////////////////////////////////////////////////////////////////////////--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <%--------------------------------------Row End-----------------------------------------%>
                            </div>
                        </div>
                    </div>

                         <div  class="content"  id="page-7"  style="display:none;height:440px;" >
                        
                            <style type="text/css">
                                      input.underlined
                                        {
                                           border:solid 1px #000;
                                        }
                                        </style>
                             <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 305px;
                                 width: 1094px; margin-top: 10px; margin-left: -18px;">
                                 <asp:GridView runat="server" ID="gvPaymentdetails" EmptyDataText="NO RECORD FOUND"
                                     AutoGenerateColumns="true" CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="false"
                                     Width="100%"   OnRowDataBound="gvPaymentdetails_RowDataBound"
                                     CellPadding="1" CellSpacing="1" OnRowCreated="gvAll_RowCreated">
                                     <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                         CssClass="column_style_left" BorderWidth="1px" />
                                     <HeaderStyle Font-Underline="false" ForeColor="Black" />
                                     <Columns>
                                         <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                                             <ItemTemplate>
                                                 <%#Container.DataItemIndex+1 %>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                 </asp:GridView>



                             <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White" BorderStyle="None"
                                ForeColor="White" ></asp:TextBox>
                                 
                                  <p id="pTotal" style="color:Red; font-size:large;">
                            </div>
 
     <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 290px;">
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                    Total Bill Amt Received:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                   <asp:TextBox ID="txtTotBillAmt" runat="server"   BackColor="#F5F5F5" Width="120px" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="100" ReadOnly="true" ></asp:TextBox>
                                </div>
                            </div>
                           <div id="txt_container_Transact_Main_l"   style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 135px">
                                  Total TDS:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px">
                                    <asp:TextBox ID="txtTotTDSAmt" runat="server" BackColor="#F5F5F5" Width="100px" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No"   ReadOnly="true" ></asp:TextBox>
                                </div>
                            </div>
                              <div id="txt_container_Transact_Main_l" style="width: 280px">
                                <div id="tag_label_transact_Src" style="width: 155px">
                                 Total Received:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                    <asp:TextBox ID="txtFinalReceivedAmt" Width="100px"  runat="server"  ReadOnly="true"  
                                    CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                                     
                                </div>
                            </div>
                             <div id="txt_container_Transact_Main_l" style="width: 280px">
                                <div id="tag_label_transact_Src" style="width: 155px">
                                 Total WriteOff:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                    <asp:TextBox ID="txtTotWriteOff" Width="100px"  runat="server"   CssClass="txtbox_none_Mid_transac_Inv_No"  ReadOnly="true" ></asp:TextBox>
                                     
                                </div>
                            </div>
                        
                        </div>
                    </div>

                </div>
            </div>
            <%-- --------------------Test Start----------------------------%>
            <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            TabIndex="22" OnClick="btnNew_Click1" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate_PaymentEntry();"
                            TabIndex="20" OnClick="btnSave_Click" CommandName="s" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate_PaymentEntry();" TabIndex="21" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="23" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Payment?', 'Payments', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="123" OnClick="btnDelete_Click" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                            id="btnCancel" tabindex="20">
                    </div>
                    <div id="editbu" style="width: 10px;">
                    </div>
                    <div id="editbu" style="padding-top: 5px;">
                        <asp:Button ID="btnrpt" runat="server" TabIndex="125" Text="Get Bill" OnClientClick="return GST_Import_Billing_Job_Rpt('B');" />
                        <%--OnClientClick="return Import_Billing_Job_Rpt('B');"--%>
                    </div>
                </div>
            </div>
            <%-- --------------------Test End----------------------------%>
            </div>

             <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px; overflow: hidden;">
                         
                    </div>
                </div>
                <div class="content" id="page-3">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 350px;
                        width: 980px; overflow: hidden;">
                         page-3
                    </div>
                </div>
                <div class="content" id="page-4">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                       page-4
                    </div>
                </div>

            <script src="../activatables.js" type="text/javascript"></script>
                <script type="text/javascript">
                    activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="Hd_Other_Branch_no" runat="server" />
            <asp:HiddenField ID="Hd_row_id" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
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

    <script type="text/javascript">
        $(function () {
            $(".billinv").autocomplete({
                source: function (request, response) {

                      var TempRd_Job_Type = $('#<%= Rd_Job_Type.ClientID %> input:checked').val()
                      
                      var Tempddlbranch_No = document.getElementById("<%=ddlbranch_No.ClientID %>").value;
                      
                      var TempddlCustomer = document.getElementById("<%=ddlCustomer.ClientID %>").value;
                      

                      //alert(Tempddlbranch_No);
                      //alert(TempddlCustomer);


                        $.ajax({
                        url: "../Billing_Imp/PaymentEntry.aspx/LoadPendingJob_webmethod",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'mail': '" + request.term + "' ,'TempRd_Job_Type': '" + TempRd_Job_Type + "','Tempddlbranch_No': '" + Tempddlbranch_No + "','TempddlCustomer': '" + TempddlCustomer + "' }",
                        dataType: "json",                                                
//                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                if (field == 'txtBill_inv_No') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Shipment', 'error', 'topRight', true);
                                }
                            }
                            else {
                                //jQuery('#txtBill_inv_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
</script>
<script  type="text/javascript">
    function Bill_Details_Finder(lnk) 
    {
        //                alert('hi');
        var grid = document.getElementById("<%= gv_Chg_Details.ClientID%>");
        var funtxtBill_inv_no = $(".billinv")
        var row = lnk.parentNode.parentNode;
        var rowIndex = row.rowIndex - 1;
        var a = funtxtBill_inv_no[rowIndex].value;
                        //alert(a);   // BILL NO DISPLAY
        var b = '1';
        $('#Hd_row_id').val(rowIndex);
        //Cha_cus(a, b);
        
        Bill_Start(a, b);
    }  
    //    function Cha_cus(src, dest) 
    //    {
    //        //                alert('hi');
    //        PageMethods.Cust_Name(src, '', '', CallSuccess_Cusname, CallFaileda, dest);
    //    }
    function Bill_Start(src, dest) 
    {
        //alert('hi');
        //alert('Bill Number :' + src); // Bill Number Displayed 

        var TempRd_Job_Type = $('#<%= Rd_Job_Type.ClientID %> input:checked').val()

        var Tempddlbranch_No = document.getElementById("<%=ddlbranch_No.ClientID %>").value;

        var TempddlCustomer = document.getElementById("<%=ddlCustomer.ClientID %>").value;

        // alert(TempRd_Job_Type); //IMPORT OR EXPORT TYPE DISPLAY

        //PageMethods.Bill_Details_Pickup_webmethod(src, '', '', BillSuccess_Cusname, BillFaileda, dest); // WEB METHOD 
        PageMethods.Bill_Details_Pickup_webmethod(src, TempRd_Job_Type, Tempddlbranch_No,TempddlCustomer, BillSuccess_Cusname, BillFaileda, dest); // WEB METHOD 
    }

    function BillSuccess_Cusname(res, destCtrl) 
    {
        var data = res;
        //alert(data);            

        //var txtC = $("[id*=txtgCusName]")
        //var txtD = $("[id*=txtgDate]")

        
        var txtBill_inv_date = $("[id*=txtBill_inv_date]")
        var txtJOBNO = $("[id*=txtJOBNO]")
        var txtIMP_EXP = $("[id*=txtIMP_EXP]")
        var txtBillAmt = $("[id*=txtBillAmt]")
        var txtReceivedAmt = $("[id*=txtReceivedAmt]")
        var txtBalAmt      = $("[id*=txtBalAmt]")
        if (res != '') 
        {
            if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') 
            {
                var s = data.split('~~');
                //var name = s[0];
                //var date = s[1];

                
                var Bill_inv_date = s[1];
                var JOBNO = s[2];
                var IMP_EXP = s[3];
                var BillAmt = s[4];
                var ReceivedAmt = s[5];
                var BalAmt = s[6];
                //alert(BalAmt);
                //txtC[document.getElementById("Hd_row_id").value].value = name;
                //txtD[document.getElementById("Hd_row_id").value].value = date;

                txtBill_inv_date[document.getElementById("Hd_row_id").value].value = Bill_inv_date;
                txtJOBNO[document.getElementById("Hd_row_id").value].value = JOBNO;
                txtIMP_EXP[document.getElementById("Hd_row_id").value].value = IMP_EXP;
                txtBillAmt[document.getElementById("Hd_row_id").value].value = BillAmt;
                txtReceivedAmt[document.getElementById("Hd_row_id").value].value = ReceivedAmt;
                txtBalAmt[document.getElementById("Hd_row_id").value].value =      BalAmt;
            }
        }

        else {
            //txtC[document.getElementById("Hd_row_id").value].selectedIndex = 1;
        }
    }

    function BillFaileda(res, destCtrl) 
    {
    }

</script>
   
</body>
</html>
