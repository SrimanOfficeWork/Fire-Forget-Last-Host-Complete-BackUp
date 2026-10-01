<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EDocket.aspx.cs" Inherits="EDocket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export Docket</title>
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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style>
        .print_btn
        {
            background: url('../images/print_Butt.png') no-repeat;
            width: 101px;
            height: 30px;
            text-indent: -9999px;
            overflow: hidden;
            text-transform: uppercase;
            border: none;
            cursor: pointer;
        }
        
        .print_btn:hover
        {
            background-position: left bottom;
        }
    </style>
    <style>
 .send_btn{
	
	background:url('images/but_mid.png') repeat-x;
	/*min-width:80px;*/
	width:80px;
	height: 28px;
	text-indent:inherit;
	overflow:hidden;
	border: #999999 solid thin;
 -moz-border-radius-topleft: 6px;
 -moz-border-radius-topright: 6px;
 -moz-border-radius-bottomleft: 6px;
 -moz-border-radius-bottomright: 6px;
  -webkit-border-top-left-radius: 6px;
 -webkit-border-top-right-radius: 6px;
 -webkit-border-bottom-left-radius: 6px;
 -webkit-border-bottom-right-radius: 6px;
	border-top-left-radius: 6px;
	border-top-right-radius: 6px;
	border-bottom-left-radius: 6px;
	border-bottom-right-radius: 6px;
	cursor:pointer;
	font-family:Arial, Helvetica, sans-serif;
	font-size:12px;
	font-weight:bold;
	color:#000000;
	text-shadow:2px 2px #ffffff;
	margin-top:2px
}

.send_btn:hover{
	background-position:left bottom;
	
	.generatelcd{
	
	width:101px;
	height: 30px;
	text-indent:-9999px;
	overflow:hidden;
	text-transform:uppercase;
	border:none;
	cursor:pointer;
}
}
 </style>
    <style type="text/css">
        .left_rht_bot_top
        {
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            margin-top: 1px;
            margin-left: 2px;
            border: #c8c8c8 solid thin;
            -moz-border-radius-topleft: 5px;
            -moz-border-radius-topright: 5px;
            -moz-border-radius-bottomleft: 5px;
            -moz-border-radius-bottomright: 5px;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -webkit-border-bottom-right-radius: 5px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
        }
        .lbl_text_newcss
        {
            color: #232323;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 13px;
            height: 15px;
            line-height: 20px;
            border-style: none;
            border: 0px;
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
            <div id="innerbox_MidMain_Transact_popup_new" style="height: 95px;">
                <div id="tag_srcinner1_new">
                    <div id="Div1">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Export Docket
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 960px">
                    <div id="tag_Exchange_inner_lft">
                        <div id="tag_transact_lft_in1">
                            <div id="tag_transac_exp_drawback" style="width: 700px; margin-top: 10px;">
                                <div id="tag_label_transact_Src">
                                    Job No
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                        TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="ddlJobno_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                               
                                 <div id="tag_label_transact_Src">
                                    File Ref#:
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                     <asp:TextBox ID="txtFileRefNo" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="20" TabIndex="2"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src">
                                </div>

                                <div id="txtcon-m_src">
                                   <%-- <asp:Button ID="btnSend" Text="Report" runat="server" OnClientClick="return open_jobno();" />--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transact_srcinner_rght" style="margin-right: 90px; margin-top: 25px;
                        width: 300px;">
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="49"
                                OnClientClick="return ValidationPage();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                Visible="false" TabIndex="50"  OnClientClick="return ValidationPage();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="51" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'Export Annexure', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="52" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>

                        <div id="editbu">
                          <asp:Button ID="btnSend" Text="Report" runat="server" OnClientClick="return open_jobno();" />
                        </div>
                    </div>
                </div>
            </div>
            </div>
            <div id="innerbox_MidMain_Trans_new">
                <ol id="toc_new" style="text-align: center; margin-top: -5px">
                    <asp:Label ID="Label34" runat="server" Text="EXPORT DOCKET" CssClass="lbl_text_newcss"
                        Font-Bold="true" Font-Size="Large" align="center"></asp:Label>
                </ol>
                <div class="content" id="page-1" style="overflow: scroll; height: 398px; width: 1000px;
                    margin-top: 15px;">
                    <div>
                        <table width="100%">
                            <tr>
                                <td style="width:160px;">
                                    <asp:Label ID="Label2" runat="server" Text="Type of SB" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td style="width:170px">
                                    <asp:TextBox ID="txt_SBTtype" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="20" TabIndex="2"></asp:TextBox>
                                </td>
                                 <td>
                                    <asp:Label ID="Label1" runat="server" Text="Exporter" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtExporter" runat="server" CssClass="left_rht_bot_top" Width="300px"
                                        MaxLength="200" TabIndex="3"></asp:TextBox>
                                </td>
                               
                                <td>
                                 <asp:Label ID="Label3" runat="server" Text="Air/Sea" CssClass="lbl_text_newcss" align="left"></asp:Label>
                                 </td> <td>
                                    <asp:DropDownList ID="ddlAirSea" runat="server" TabIndex="4">
                                        <asp:ListItem>Air</asp:ListItem>
                                        <asp:ListItem>Sea</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                               <%-- <td>
                                    <asp:Label ID="Label1" runat="server" Text="Exporter" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExporter" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="4"></asp:TextBox>
                                </td>--%>
                                <%--<td>
                                    <asp:Label ID="Label4" runat="server" Text="Consignee" CssClass="lbl_text_newcss"
                                        align="left"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcnee" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="100" TabIndex="5"></asp:TextBox>
                                </td>--%>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="S.line/Agent" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLineAgent" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="6"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Consignee" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="txtcnee" runat="server" CssClass="left_rht_bot_top" Width="300px"
                                        MaxLength="50" TabIndex="7"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                               <td>
                                    <asp:Label ID="Label42" runat="server" Text="Commission" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="txtCommission" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="7"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label_Forwarder" runat="server" Text="Forwarder" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="txt_Forwarder" runat="server" CssClass="left_rht_bot_top" Width="300px"
                                        MaxLength="50" TabIndex="7"></asp:TextBox>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="S.Bill No" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSBillno" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="8"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label35" runat="server" Text="Date" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td  style="width:30px">
                                   <%-- <div id="Div8">--%>
                                        <asp:TextBox ID="txtSbillDt1" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            Width="150px" TabIndex="9"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender8"
                                                runat="server" TargetControlID="txtSbillDt1" Mask="99/99/9999" MaskType="Date"
                                                ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtSbillDt1"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator8" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txtSbillDt1" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="S Bill Date"></asp:RegularExpressionValidator>--%>
                                   <%-- </div>--%>
                                   
                                </td>
                                <td style="width:50px">
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Text="Volume" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td colspan="3" >
                                    <asp:TextBox ID="txtVolume" runat="server" CssClass="left_rht_bot_top" Width="120px"
                                        MaxLength="30" TabIndex="10"></asp:TextBox>
                                
                                   <asp:Label ID="Label38" runat="server" Text="POD" CssClass="lbl_text_newcss"></asp:Label> &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                
                                    <asp:TextBox ID="txtPOD" runat="server" CssClass="left_rht_bot_top" Width="120px"
                                        MaxLength="30" TabIndex="11"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label36" runat="server" Text="TotNoOfPacks" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotNoOfPacks" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="12"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label37" runat="server" Text="Units" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotaUnits" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="13"></asp:TextBox>
                                </td>
                                <td>
                                   &nbsp;&nbsp;&nbsp; <asp:Label ID="Label8" runat="server" Text="Net.Weight" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNetWeight" runat="server" CssClass="left_rht_bot_top" Width="120px"
                                        MaxLength="50" TabIndex="14"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Gross.Wt" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="left_rht_bot_top" Width="120px"
                                        MaxLength="50" TabIndex="15"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Invoice No" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="20" TabIndex="16"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="Invoice Dt" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtInvoiceDt" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            Width="150px" TabIndex="17"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender4"
                                                runat="server" TargetControlID="txtInvoiceDt" Mask="99/99/9999" MaskType="Date"
                                                ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtInvoiceDt"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txtInvoiceDt" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text="Terms of.Inv" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlInvTerm" runat="server" TabIndex="18">
                                        <asp:ListItem>FOB</asp:ListItem>
                                        <asp:ListItem>CIF</asp:ListItem>
                                        <asp:ListItem>CI</asp:ListItem>
                                        <asp:ListItem>CF</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Inv.value" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInvValue" runat="server" CssClass="left_rht_bot_top" Width="120px"
                                        MaxLength="20" TabIndex="19" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Containing" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContain" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="100" TabIndex="20"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="FOB Rs" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInvRs" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="20"
                                        TabIndex="21"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label17" runat="server" Text="Drawback" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDBK" runat="server" CssClass="left_rht_bot_top" Width="120px"
                                        onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="20"
                                        TabIndex="22"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text="Exc.Rate" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExcRate" runat="server" CssClass="left_rht_bot_top" Width="120px"
                                        onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                        TabIndex="23"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="Goods Arrived" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGoods" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="20" TabIndex="24"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text="Carting Dt" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <div id="Div2">
                                        <asp:TextBox ID="txtCartingDt" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            Width="150px" TabIndex="25"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender1"
                                                runat="server" TargetControlID="txtCartingDt" Mask="99/99/9999" MaskType="Date"
                                                ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCartingDt"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txtCartingDt" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                                <td style="width:90px;">
                                   &nbsp; <asp:Label ID="Label21" runat="server" Text="Cust.Clear.Dt" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <div id="Div3">
                                        <asp:TextBox ID="txtCustClearedDt" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            Width="120px" TabIndex="26"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender2"
                                                runat="server" TargetControlID="txtCustClearedDt" Mask="99/99/9999" MaskType="Date"
                                                ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCustClearedDt"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txtCustClearedDt" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Text="CFS" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCFS" runat="server" CssClass="left_rht_bot_top" Width="120px"
                                        MaxLength="10" TabIndex="27"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Text="Date" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <div id="Div4">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            Width="150px" TabIndex="28"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender3"
                                                runat="server" TargetControlID="txtDate" Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txtDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Text="Office Co-ordinator" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtOfficeCoordinator" runat="server" CssClass="left_rht_bot_top"
                                        Width="150px" MaxLength="100" TabIndex="29"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:160px;">
                                    <asp:Label ID="Label23" runat="server" Text="CFS Clerk Name" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCFSClerk" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="30"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Text="Name of CFS" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCFSName" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="31"></asp:TextBox>
                                </td>
                                <td>
                                   &nbsp;&nbsp;&nbsp; <asp:Label ID="Label27" runat="server" Text="S.bill no" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtShipBillno" runat="server" CssClass="left_rht_bot_top" Width="120px"
                                        MaxLength="20" TabIndex="32"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label28" runat="server" Text="Date" CssClass="lbl_text_newcss" align="left"
                                        Width="30px"></asp:Label>
                                </td>
                                <td>
                                    <%--<div id="Div5">--%>
                                        <asp:TextBox ID="txtShipDt" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            Width="150px" TabIndex="33"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender5"
                                                runat="server" TargetControlID="txtShipDt" Mask="99/99/9999" MaskType="Date"
                                                ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtShipDt"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txtShipDt" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    <%--</div>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label29" runat="server" Text="Truck Nos" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtTruckNos" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="34"></asp:TextBox>
                                </td>
                                <td>
                                   &nbsp;&nbsp;&nbsp; <asp:Label ID="Label30" runat="server" Text="No. of tyres" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtNoOftyres" runat="server" CssClass="left_rht_bot_top" Width="120px"
                                        MaxLength="50" TabIndex="35"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label31" runat="server" Text="Transport Co" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTransportCom" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="36"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label32" runat="server" Text="Carting Dt" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <div id="Div6">
                                        <asp:TextBox ID="txtTransCartingDt" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            Width="150px" TabIndex="37"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender6"
                                                runat="server" TargetControlID="txtTransCartingDt" Mask="99/99/9999" MaskType="Date"
                                                ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtTransCartingDt"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txtTransCartingDt" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                                <td>
                                   &nbsp;&nbsp;&nbsp; <asp:Label ID="Label33" runat="server" Text="LEO dt" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <div id="Div7">
                                        <asp:TextBox ID="txtLEOdt" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            Width="120px" TabIndex="38"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender7"
                                                runat="server" TargetControlID="txtLEOdt" Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtLEOdt"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txtLEOdt" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                            </tr>

                              <tr>
                                <td>
                                    <asp:Label ID="Label39" runat="server" Text="Non Receipt.Exp" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td colspan="7">
                                    <asp:TextBox ID="txtNonRecExp1" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="39"></asp:TextBox>
                                        <asp:TextBox ID="txtNonRecExp2" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="40"></asp:TextBox>
                                        <asp:TextBox ID="txtNonRecExp3" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="41"></asp:TextBox>
                                        <asp:TextBox ID="txtNonRecExp4" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="42"></asp:TextBox>
                                        <asp:TextBox ID="txtNonRecExp5" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="43"></asp:TextBox>                                 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label40" runat="server" Text="Receipt.Exp" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td colspan="7">
                                    <asp:TextBox ID="txtRecExp1" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="44"></asp:TextBox>
                                        <asp:TextBox ID="txtRecExp2" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="45"></asp:TextBox>
                                        <asp:TextBox ID="txtRecExp3" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="46"></asp:TextBox>
                                        <asp:TextBox ID="txtRecExp4" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="47"></asp:TextBox>
                                        <asp:TextBox ID="txtRecExp5" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="48"></asp:TextBox>                                 
                                </td>
                            </tr>

                        </table>
                        <asp:HiddenField ID="Hdn_ddlJobNo" runat="server" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <%--<script src="../js/Sea_Script/Sea_Vessel.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        body
        {
            font-size: 62.5%;
        }
        .style1
        {
            height: 14px;
        }
    </style>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {

            document.getElementById("General").click();
        }
    </script>
    <script type="text/javascript">
        function btnclick() {
            //               document.getElementById("<%=btn.ClientID %>").click();
            document.getElementById("<%=btn.ClientID %>").click();

        }
        window.onload = happycode;
        function happycode() {

            document.getElementById("JOB_NO").click();

        }
        //  

    </script>
    <script type="text/javascript">

       

           window.onload = happycode;
           window.onload = happycode1;
           function happycode() {

               document.getElementById("Transaction_Id").click();

           }

          });

           function CallServerside_Importer1(src, dest) {
               Loading_ShowImage();

               // call server side method

               PageMethods.Get_Import_Details(src, CallSuccess_Importer, CallFailed, dest);
           }

           function CallServerside_Importer(src, dest) {
               Loading_ShowImage();

               var ctrl = document.getElementById(src);

               // call server side method

               PageMethods.Get_Import_Details(ctrl.value, CallSuccess_Importer, CallFailed, dest);

           }

         
    </script>
    <script>
        var win = null;

        function Print_open() {
            var w = '810';
            var h = '1024';
            LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
            settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
            win = window.open('../Print.aspx', 'ndf', settings);
            win.focus();

            return false;
            //window.open('../Default.aspx', 'ndf')

        }
    </script>
    <script type="text/javascript">
        function open_jobno() {

            if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                    var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                    NewWindow1('../EXPORT_SDF/SDF_Appendix_I_ReportViewer.aspx?jobno=' + f + '', 'List', '810', '1024', 'yes');

                    //opennew_Import_report(f);
                    return false
                    alert(f);
                }
            }
        }
    </script>
    <script type="text/javascript">

        function ValidationPage() {

            var ddljob = document.getElementById("ddlJobNo").value;
            if (ddljob.length <= 0) {
                jAlert('Select Job', 'Export Docket', function (r) { document.getElementById("ddljobno").focus(); });
                return false;
            }

            var SBType = document.getElementById("txt_SBTtype").value;
            if (SBType.length <= 0) {
                jAlert('Enter SB type', 'Export Docket', function (r) { document.getElementById("txt_SBTtype").focus(); });
                return false;
            }

            var Exporter = document.getElementById("txtExporter").value;
            if (Exporter.length <= 0) {
                jAlert('Enter Exporter', 'Export Docket', function (r) { document.getElementById("txtExporter").focus(); });
                return false;
            }

            var cnee = document.getElementById("txtcnee").value;
            if (cnee.length <= 0) {
                jAlert('Enter Cnee', 'Export Docket', function (r) { document.getElementById("txtcnee").focus(); });
                return false;
            }

            var SbillNo = document.getElementById("txtSBillno").value;
            if (SbillNo.length <= 0) {
                jAlert('Enter S-BillNo', 'Export Docket', function (r) { document.getElementById("txtSBillno").focus(); });
                return false;
            }

            var Invno = document.getElementById("txtInvoiceNo").value;
            if (Invno.length <= 0) {
                jAlert('Enter Invoice No', 'Export Docket', function (r) { document.getElementById("txtInvoiceNo").focus(); });
                return false;
            }
            var txtInvDate = document.getElementById("txtInvoiceDt").value;
            if (txtInvDate != "") {
                if (isDate(txtInvDate)) {
                }
                else {
                    jAlert('Date is invalid', 'Export Docket', function (r) { document.getElementById("txtInvoiceDt").focus(); });
                    return false;
                }
            }
            else {
                jAlert('Enter Invoice Date', 'Export Docket', function (r) { document.getElementById("txtInvoiceDt").focus(); });
                return false;
            }



        }


    </script>
</body>
</html>
