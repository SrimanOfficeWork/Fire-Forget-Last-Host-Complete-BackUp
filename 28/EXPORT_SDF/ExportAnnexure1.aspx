<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportAnnexure1.aspx.cs"
    Inherits="ExportAnnexure1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export Annexure</title>
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
                        Export Annexure
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
                                </div>
                                <div id="txtcon-m_src">
                                    <asp:Button ID="btnSend" Text="Report" runat="server" OnClientClick="return open_jobno();" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transact_srcinner_rght" style="margin-right: 90px; margin-top: 25px;
                        width: 280px;">
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="17"
                                OnClientClick="return ValidationPage();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                Visible="false" TabIndex="18"  OnClientClick="return ValidationPage();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="19" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'Export Annexure', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="20" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            </div>
            <div id="innerbox_MidMain_Trans_new" style="width: 1050px">
                <ol id="toc_new" style="text-align: center; margin-top: -5px">
                    <asp:Label ID="Label1111" runat="server" Text="EXPORT VALUE DECLARATION" CssClass="lbl_text_newcss"
                        Font-Bold="true" Font-Size="Large" align="center"></asp:Label>
                </ol>
                <div class="content" id="page-1" style="overflow: scroll; height: 378px; width: 960px;
                    margin-top: 15px;">
                    <div>
                        <table width="100%">
                            <tr>
                                <td style="font-family: Times New Roman" align="center" colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Times New Roman:" align="center" colspan="4">
                                    <asp:Label ID="Label1" runat="server" Text="(See Rule 7 of Customs Valuation (Determination of Value of Export Goods) Rules, 2007)."
                                        CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Times New Roman" align="left">
                                    <asp:Label ID="Label2" runat="server" Text="Shipping Bill No" CssClass="lbl_text_newcss"
                                        Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_SBNo" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="2"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Date" CssClass="lbl_text_newcss" align="left"
                                        Width="30px"></asp:Label>
                                </td>
                                <td>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txt_SBDate" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            TabIndex="3"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
                                                TargetControlID="txt_SBDate" Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_SBDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txt_SBDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Times New Roman" align="left">
                                    <asp:Label ID="Label6" runat="server" Text="Invoice No" CssClass="lbl_text_newcss"
                                        Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInvNo" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="4"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Date" CssClass="lbl_text_newcss" align="center"
                                        Width="30px"></asp:Label>
                                </td>
                                <td>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtInvDate" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            TabIndex="5"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                TargetControlID="txt_SBDate" Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtInvDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txt_SBDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Nature of Transaction" CssClass="lbl_text_newcss"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddltrxnNature" runat="server" TabIndex="6">
                                    <asp:ListItem>Sale on Consignment Basis</asp:ListItem>
                                        <asp:ListItem>Sale</asp:ListItem>                                        
                                        <asp:ListItem>Gift</asp:ListItem>
                                        <asp:ListItem>Sample</asp:ListItem>
                                        <asp:ListItem>Otehrs</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Method of Valuation" CssClass="lbl_text_newcss"
                                        align="right"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlValuation" runat="server" TabIndex="7">
                                        <asp:ListItem>Rule3</asp:ListItem>
                                        <asp:ListItem>Rule4</asp:ListItem>
                                        <asp:ListItem>Rule5</asp:ListItem>
                                        <asp:ListItem>Rule6</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Whether Seller and Buyer are related"
                                        CssClass="lbl_text_newcss" align="right"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSelBuy" runat="server" TabIndex="8">
                                     <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                       
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="If yes, whether relationship has influenced the price"
                                        CssClass="lbl_text_newcss" align="right"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlInfluence" runat="server" TabIndex="9">
                                     <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Terms of Payment" CssClass="lbl_text_newcss"
                                        align="right"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTermofPay" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="100" TabIndex="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Terms of Delivery" CssClass="lbl_text_newcss"
                                        align="right"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTermDelivery" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="100" TabIndex="11"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label12" runat="server" Text="Previous Export of identical / similar goods, if any"
                                        CssClass="lbl_text_newcss" align="right"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Times New Roman">
                                    <asp:Label ID="Label13" runat="server" Text="Pre.Shipping.BillNo" CssClass="lbl_text_newcss"
                                        Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPreShipno" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="12"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Date" CssClass="lbl_text_newcss" align="center"
                                        Width="30px"></asp:Label>
                                </td>
                                <td>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtPreShipDt" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            TabIndex="13"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                                TargetControlID="txtPreShipDt" Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPreShipDt"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txtPreShipDt" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label15" runat="server" Text="Declaration" CssClass="lbl_text_newcss"
                                        align="right"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label16" runat="server" Text="I/We hereby declare that the information furnished above is true, complete and correct in every respect"
                                        CssClass="lbl_text_newcss" align="right"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label17" runat="server" Text="I/We also undertake to bring to the notice of proper officer any particulars which subsequently come to my/our knowledge which will have bearing on a valuation "
                                        CssClass="lbl_text_newcss" align="right"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Times New Roman">
                                    <asp:Label ID="Label18" runat="server" Text="Place" CssClass="lbl_text_newcss" Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPlace" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="50" TabIndex="14"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="Date" CssClass="lbl_text_newcss" align="center"
                                        Width="30px"></asp:Label>
                                </td>
                                <td>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtDeclDate" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                                            TabIndex="15"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                                TargetControlID="txtDeclDate" Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True">
                                            </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDeclDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator5"
                                            PopupPosition="Right">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red"
                                            Display="None" runat="server" ControlToValidate="txt_SBDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Times New Roman">
                                    <asp:Label ID="Label20" runat="server" Text="ExporterName" CssClass="lbl_text_newcss"
                                        Width="100px"></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtExporterName" runat="server" CssClass="left_rht_bot_top" Width="150px"
                                        MaxLength="200" TabIndex="16"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Times New Roman">
                                    <asp:Label ID="Label21" runat="server" Text="ExporterAddress" CssClass="lbl_text_newcss"
                                        Width="100px"></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtExporterAddress" runat="server" CssClass="left_rht_bot_top" Width="550px" TextMode="MultiLine" Height="40px"
                                        MaxLength="200" TabIndex="16"></asp:TextBox>
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
            //document.getElementById("btn_cancel").click();
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
                jAlert('Select Job', 'Export Annexure', function (r) { document.getElementById("ddljobno").focus(); });
                return false;
            }
             

            var Invno = document.getElementById("txtInvNo").value;
            if (Invno.length <= 0) {

                jAlert('Enter Invoice No', 'Export Annexure', function (r) { document.getElementById("txtInvNo").focus(); });
                return false;
            }

            var txtInvDate = document.getElementById("txtInvDate").value;
            if (txtInvDate != "") {
                if (isDate(txtInvDate)) {
                }
                else {
                    jAlert('Date is invalid', 'Export Annexure', function (r) { document.getElementById("txtInvDate").focus(); });
                    return false;
                }
            }
            else {
                jAlert('Enter Invoice Date', 'Export Annexure', function (r) { document.getElementById("txtInvDate").focus(); });
                return false;
            }

            var TermofPay = document.getElementById("txtTermofPay").value;
            if (TermofPay.length <= 0) {

                jAlert('Enter Term of Pay', 'Export Annexure', function (r) { document.getElementById("txtTermofPay").focus(); });
                return false;
            }

            var txtTermDel = document.getElementById("txtTermDelivery").value;
            if (txtTermDel.length <= 0) {

                jAlert('Enter Term Delivery', 'Export Annexure', function (r) { document.getElementById("txtTermDelivery").focus(); });
                return false;
            }


            
        }


    </script>
</body>
</html>
