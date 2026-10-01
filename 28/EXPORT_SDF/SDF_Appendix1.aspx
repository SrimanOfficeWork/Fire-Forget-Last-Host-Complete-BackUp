<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SDF_Appendix1.aspx.cs" 
    Inherits="SDF_Appendix1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
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

    <style >
 .print_btn{
	background:url('../images/print_Butt.png') no-repeat;
	width:101px;
	height: 30px;
	text-indent:-9999px;
	overflow:hidden;
	text-transform:uppercase;
	border:none;
	cursor:pointer;
}

.print_btn:hover{
	background-position:left bottom;
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
            font-family:Arial,Helvetica,sans-serif;
font-size:14px;
margin-top:1px;
margin-left:2px;
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
            border-style:none;
            border:0px;
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
                

                <div id="innerbox_MidMain_Transact_popup_new" style="height:95px;">
                <div id="tag_srcinner1_new">
                    <div id="Div1">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Export_APPENDIX I
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>
                <div id="tag_transact_src_inner" style="width:960px">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="tag_transac_exp_drawback" style="width:700px;margin-top:10px;">
                            <div id="tag_label_transact_Src">
                                Job No
                            </div>
                            
                            <div id="txtcon-m_transaction_Supp_code">
                                
                                  <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddlJobno_SelectedIndexChanged"  >                                           
                                        </asp:DropDownList>
                            </div>
                           
                              <div id="tag_label_transact_Src"></div>
                                                        
                            <div id="txtcon-m_src">                              

                <asp:Button ID="btnSend"  Text="Report"  runat="server" OnClientClick="return open_jobno();"  />
                              
                            </div>
                            
                        </div>
                    </div>
                   
                </div>
                  
                <div id="tag_transact_srcinner_rght" style="margin-right:90px;margin-top: 25px;
    width: 280px;">
                  <div id="editbu">
                                 <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="13"
                                    OnClientClick="return validate();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" Visible="false"
                                    TabIndex="13"  />
                            </div>
                    <div id="editbu">
                    
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'SDF APPENDIX I', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="11" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />

   
                       <div id="small-butt-rght">
                      <%--  <a href="#" class="cancelButt" onclick="openurl('../LoginPage/E_royal_Impex_Home.aspx');"></a>--%>

                     <%-- <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>--%>
                       
                    </div>
                  
                     <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>      
                    </div>
               
                </div>
            </div>
                </div>
              <div id="innerbox_MidMain_Trans_new"   >
                <ol id="toc_new">
                          </ol>
                         
                <div class="content" id="page-1" style="overflow:scroll;height:378px;width:960px;margin-top: 15px;">
                        
               <div>

<table>

<tr>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
</tr>

<tr>
<td colspan="10"></td>
<td style="font-family:Times New Roman" align="center">
        <asp:Label ID="Label1111" runat="server" Text="APPENDIX I" CssClass="lbl_text_newcss" Font-Bold="true" Font-Size="Large" align="center" Width="150px" ></asp:Label>
</td>
</tr>

<tr>
<td colspan="25"></td>
</tr>

<tr>
<td colspan="5"></td>
<td style="font-family:Times New Roman" align="center" colspan="10">
        <asp:Label ID="Label1" runat="server" Text="(Declaration under Foreign Exchange Management Act, 1999)" CssClass="lbl_text_newcss"   Width="360px" ></asp:Label>
</td>
</tr>
</table>
<table>
<tr>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
</tr>
<tr>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
</tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr><tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>

<td style="font-family:Times New Roman"  colspan="2" >
<asp:Label ID="Label2" runat="server" Text="Shipping Bill No" CssClass="lbl_text_newcss"  align="center" Width="100px" ></asp:Label>
</td>

<td colspan="5">
<asp:TextBox ID="txt_SBNo" runat="server"  CssClass="left_rht_bot_top" MaxLength="7" TabIndex="1"></asp:TextBox>
</td>

<td>
<asp:Label ID="Label3" runat="server" Text="Date" CssClass="lbl_text_newcss"  align="center" Width="60px" ></asp:Label>
</td>
    <td colspan="5">
        <div id="txtcon-m_transaction_code">
            <asp:TextBox ID="txt_SBDate" runat="server" CssClass="left_rht_bot_top" MaxLength="30"
                TabIndex="2"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
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
<td colspan="1"></td>

<td style="font-family:Times New Roman"  colspan="2" >
<asp:Label ID="Label29" runat="server" Text="Invoice No. " CssClass="lbl_text_newcss"  align="center" Width="100px" ></asp:Label>
</td>

<td colspan="5">
<asp:TextBox ID="txt_InvoiceNo" runat="server"  CssClass="left_rht_bot_top" MaxLength="7" TabIndex="1"></asp:TextBox>
</td>

<td>
<asp:Label ID="Label30" runat="server" Text="Date" CssClass="lbl_text_newcss"  align="center" Width="60px" ></asp:Label>
</td>
    <td colspan="5">
        <div id="txtcon-m_transaction_code">
            <asp:TextBox ID="txt_InvoiceDate" runat="server" CssClass="left_rht_bot_top"
                                    MaxLength="30" TabIndex="17"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender5"
                                        runat="server" TargetControlID="txt_InvoiceDate" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_InvoiceDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_InvoiceDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
        </div>
    </td>

</tr>

<tr>
<td colspan="1"></td>
<td style="font-family:Times New Roman"  colspan="2" >
<asp:Label ID="Label26" runat="server" Text="FOB Value :" CssClass="lbl_text_newcss"   Width="100px"></asp:Label>
</td>

<td colspan="5">
<asp:TextBox ID="txt_FOB" runat="server"  CssClass="left_rht_bot_top" Width="150px"  MaxLength="50" TabIndex="18"></asp:TextBox>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr>
<td colspan="1"></td>
<td colspan="1">
<asp:Label ID="Label4" runat="server" Text="I/We" CssClass="lbl_text_newcss"  align="center" Width="60px" ></asp:Label>
</td>

<td colspan="10">
<asp:TextBox ID="txt_NameOfExporter" runat="server" width="320px" CssClass="left_rht_bot_top" MaxLength="75" TabIndex="3"></asp:TextBox>
</td>

<td colspan="20">
<asp:Label ID="Label5" runat="server" Text="(name of the Exporter)do hereby declare that :-" CssClass="lbl_text_newcss"  align="center" Width="360px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="25">
<asp:Label ID="Label6" runat="server" Text="1.I/We am/are the seller/consignor of the goods in respect of which this declaration is made and that the particulars" CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>

<tr>
<td colspan="1"></td>
<td colspan="4">
<asp:Label ID="Label7" runat="server" Text="given in the Shipping Bill No" CssClass="lbl_text_newcss"  align="center" Width="170px" ></asp:Label>
</td>

<td colspan="6">
<asp:TextBox ID="txt_GivenSBNo" runat="server"  width="220px" CssClass="left_rht_bot_top" MaxLength="50" TabIndex="4"></asp:TextBox>
</td>

<td colspan="2">
<asp:Label ID="Label8" runat="server" Text="Dated" CssClass="lbl_text_newcss"  align="center" Width="60px" ></asp:Label>
</td>

<td colspan="6">
<%--<asp:TextBox ID="txt_GivenSBDate" runat="server" CssClass="left_rht_bot_top" TabIndex="5" ></asp:TextBox>--%>


 <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_GivenSBDate" runat="server" CssClass="left_rht_bot_top"
                                    MaxLength="10" TabIndex="5"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender3"
                                        runat="server" TargetControlID="txt_GivenSBDate" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_GivenSBDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_GivenSBDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                            </div>

</td>

<td colspan="2">
<asp:Label ID="Label9" runat="server" Text="are true and that :-" CssClass="lbl_text_newcss"  align="center" Width="160px" ></asp:Label>
</td>

</tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label10" runat="server" Text="*(A) The value as contracted with the buyer is the same as the full export value declared in the above shipping
bill or" CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label11" runat="server" Text="*(B) The full export value of the goods is not ascertainable at the time of export and that the value declared is
that which " CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label12" runat="server" Text="  I/We having regard to the prevailing market conditions, expect to receive on receive on the sale
of goods in the overseas market" CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="25">
<asp:Label ID="Label13" runat="server" Text="2.That I/We undertake that I/We will deliver to the bank named herein" CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:TextBox ID="txt_undertake1" runat="server" width="720px" CssClass="left_rht_bot_top" MaxLength="100" TabIndex="6"></asp:TextBox>
</td>
</tr>

<tr><td colspan="25"></td></tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:TextBox ID="txt_undertake2" runat="server" width="720px" CssClass="left_rht_bot_top" MaxLength="100" TabIndex="7"></asp:TextBox>
</td>
</tr>

</table>

<table>
<tr>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
<td width="25"></td>
</tr>
<tr>
<td colspan="3"></td>

<td style="font-family:Times New Roman"  colspan="4" >
<asp:Label ID="Label14" runat="server" Text="the foreign exchange representing the full export value of the goods on or before @" CssClass="lbl_text_newcss"  align="center" Width="490px" ></asp:Label>
</td>

<td colspan="7">
<asp:TextBox ID="txt_undertake3" runat="server"  CssClass="left_rht_bot_top" Width="250px" MaxLength="100" TabIndex="8"></asp:TextBox>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="3"></td>
<td style="font-family:Times New Roman"  colspan="10" >
<asp:Label ID="Label15" runat="server" Text="in the manner prescribed in Rule 9 of the Foreign Exchange Management Rules, 1999." CssClass="lbl_text_newcss"  align="center" Width="550px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td style="font-family:Times New Roman"  colspan="10" >
<asp:Label ID="Label16" runat="server" Text="3.That I/We am/are resident in India and I/We have a place of business in India" CssClass="lbl_text_newcss"  align="center" Width="550px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td style="font-family:Times New Roman"  colspan="10" >
<asp:Label ID="Label17" runat="server" Text="4.That I/We am/are not in the Caution list of the Reserve Bank of India" CssClass="lbl_text_newcss"  align="center" Width="550px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td></td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="3"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label18" runat="server" Text="Date" CssClass="lbl_text_newcss"  align="center" Width="40px" ></asp:Label>
</td>

<td colspan="1">
<%--<asp:TextBox ID="txt_Date" runat="server"  CssClass="left_rht_bot_top"></asp:TextBox>--%>


 <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Date" runat="server" CssClass="left_rht_bot_top"
                                    MaxLength="30" TabIndex="9"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender2"
                                        runat="server" TargetControlID="txt_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                            </div>
</td>
<td colspan="2"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label19" runat="server" Text="For" CssClass="lbl_text_newcss"   Width="20px" ></asp:Label>
</td>

<td colspan="1">
<asp:TextBox ID="txt_For" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="10"></asp:TextBox>
</td>

</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="3"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label20" runat="server" Text="Name of the Exporter" CssClass="lbl_text_newcss"  Width="130px" ></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txt_Exporter" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="11"></asp:TextBox>
</td>
</tr>


<tr>
<td colspan="3"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label21" runat="server" Text="Address" CssClass="lbl_text_newcss"  Width="100px" ></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txt_Address1" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="12"></asp:TextBox>
</td>

<td colspan="1"></td>
<td style="font-family:Times New Roman"  colspan="2" >
<asp:Label ID="Label27" runat="server" Text="Signature of the Exporter" CssClass="lbl_text_newcss"  Width="200px" ></asp:Label>
</td>

</tr>

<tr>
<td colspan="3"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label22" runat="server" Text="" CssClass="lbl_text_newcss"  Width="130px" ></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txt_Address2" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="13"></asp:TextBox>
</td>
</tr>

<tr>
<td colspan="3"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label23" runat="server" Text="" CssClass="lbl_text_newcss"  Width="130px" ></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txt_Address3" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="14"></asp:TextBox>
</td>
</tr>

<tr>
<td colspan="3"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label28" runat="server" Text="" CssClass="lbl_text_newcss"  Width="130px" ></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txt_Address4" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="15"></asp:TextBox>
</td>
</tr>


<tr>
<td colspan="4"></td>
<td colspan="15">
<asp:TextBox ID="txt_Remarks" runat="server"  CssClass="left_rht_bot_top" Width="650px"  MaxLength="450" TabIndex="19" ></asp:TextBox>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr><tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr><tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

    <asp:HiddenField ID="Hdn_ddlJobNo" runat="server" />
</table>

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

             <script >
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
   
  </body>
    </html>
