<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SDF_Appendix3.aspx.cs" 
    Inherits="SDF_Appendix3" %>

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
                        Export_APPENDIX III
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
                                            onselectedindexchanged="ddlJobno_SelectedIndexChanged" >                                           
                                        </asp:DropDownList>
                            </div>
                           
                              <div id="tag_label_transact_Src"></div>
                                                        
                            <div id="txtcon-m_src">                               

                <asp:Button ID="btnSend"  Text="Report"  runat="server" OnClientClick="return open_jobno();" />
                              
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
                                    TabIndex="13" OnClientClick="return validate();" />
                            </div>
                    <div id="editbu">
                    
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'SDF APPENDIX-III', function(r) {
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
                        <%--<a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>--%>
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
        <asp:Label ID="Label1111" runat="server" Text="APPENDIX III" CssClass="lbl_text_newcss" Font-Bold="true" Font-Size="Large" align="center" Width="150px" ></asp:Label>
</td>
</tr>

<tr>
<td colspan="25"></td>
</tr>

<tr>
<td colspan="5"></td>
<td style="font-family:Times New Roman" align="center" colspan="10">
        <asp:Label ID="Label1" runat="server" Text="DRAWBACK/DEEC DECLARATION" CssClass="lbl_text_newcss"   Width="360px" ></asp:Label>
</td>
</tr>

<tr>
<td colspan="25"></td>
</tr>

<tr>
<td colspan="5"></td>
<td style="font-family:Times New Roman" align="center" colspan="10">
        <asp:Label ID="Label29" runat="server" Text="(To be filed for export of goods under claim for Drawback)" CssClass="lbl_text_newcss"   Width="360px" ></asp:Label>
</td>
<td colspan="4"></td>
<%--<td>
<asp:Button ID="c1_Next" Text= " >>>" runat="server" onclick="c1_Next_Click" />
</td>--%>
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
<tr><td colspan="25"></td></tr><tr>
<td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>

<td style="font-family:Times New Roman"  colspan="2" align="right" >
<asp:Label ID="Label2" runat="server" Text="Shipping Bill No" CssClass="lbl_text_newcss"   Width="100px" ></asp:Label>
</td>

<td colspan="3">
<asp:TextBox ID="txt_SBNo" runat="server"  CssClass="left_rht_bot_top"   Width="150px" MaxLength="7" TabIndex="1"></asp:TextBox>
</td>

<td>
<asp:Label ID="Label3" runat="server" Text="Date" CssClass="lbl_text_newcss"  align="center" Width="30px" ></asp:Label>
</td>

<td colspan="4">
<%--<asp:TextBox ID="txt_SBDate" runat="server" CssClass="left_rht_bot_top" ></asp:TextBox>--%>

<div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_SBDate" runat="server" CssClass="left_rht_bot_top"
                                    MaxLength="30" TabIndex="2"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender4"
                                        runat="server" TargetControlID="txt_SBDate" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_SBDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_SBDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                            </div>

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
<td colspan="1" align="right">
<asp:Label ID="Label4" runat="server" Text="I/We" CssClass="lbl_text_newcss"   Width="60px" ></asp:Label>
</td>

<td colspan="4">
<asp:TextBox ID="txt_NameOfExporter" runat="server" width="400px" CssClass="left_rht_bot_top" MaxLength="75" TabIndex="3"></asp:TextBox>
</td>

<td colspan="20">
<asp:Label ID="Label5" runat="server" Text="(Name of the Exporter) do hereby further declare as follows :" CssClass="lbl_text_newcss"  align="center" Width="360px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman">1.</td>
<td colspan="21">
<asp:Label ID="Label10" runat="server" Text="That the quality and specification of the goods as stated in this Shipping Bill are in accordance with the terms of the
" CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label31" runat="server" Text="exports contract entered into with the buyer/consignee in pursuance of the goods which are being exported." CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >2.</td>
<td colspan="25">
<asp:Label ID="Label7" runat="server" Text="That there is no change in the manufacturing formula and in the quantum per unit of the imported material or " CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label8" runat="server" Text="components, utilised in the manufacture of the export goods and that the materials or components which have been  " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label9" runat="server" Text="stated in the application under Rule 6 or Rule 7 to have been imported, continue to be so  " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label11" runat="server" Text="imported and are not been obtained from indegenous sources.  " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >3.</td>
<td colspan="25">
<asp:Label ID="Label12" runat="server" Text="*(A)   That the export goods have not been manufactured by availing rebate of duty paid on materials used in the " CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label33" runat="server" Text="manufacture or processing of such goods under Rule 18. The goods have not been manufactured in terms of" CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label6" runat="server" Text="Rule 19(2) of the Central Excise Rules 2002." CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="6"></td>
<td colspan="21">
<asp:Label ID="Label15" runat="server" Text="OR" CssClass="lbl_text_newcss"  align="center" Width="800px"  ></asp:Label>
</td>
</tr>


<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label34" runat="server" Text="*(B) That the export goods have been manufactured by availing the rebate of duty paid on materials used in the manufacture" CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label35" runat="server" Text="  or processing of such goods under Rule 1B. The goods have been manufactured in terms of Rule 19(2)of the Central Excise" CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label16" runat="server" Text="Rules 2002, But we are not claiming drawback on the basis of All Industry Rates, We are /shall be claiming drawback on the  " CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label13" runat="server" Text="basis of special brand rate in terms of Rule 6 of the customs and Central Excise Duties Drawback Rules 1995." CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label14" runat="server" Text="(*Strike out whichever is not applicable)" CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >4.</td>
<td colspan="25">
<asp:Label ID="Label17" runat="server" Text=" *(A)That the goods are not manufactured or exported in discharge of export obligation against an Advance License issued under " CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label18" runat="server" Text="the Duty Exemption Scheme (DEEC) in terms of the relevant Export and Import Policy of Foreign Trade Policy as the case may be.  " CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
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
<td colspan="6"></td>
<td colspan="21">
<asp:Label ID="Label24" runat="server" Text="OR" CssClass="lbl_text_newcss"  align="center" Width="800px"  ></asp:Label>
</td>
</tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr><tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr><tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman"></td>
<td colspan="21">
<asp:Label ID="Label25" runat="server" Text="*(B)That goods are manufactured and are being exported in discharge of export obligation under the Duty Exemption
" CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label26" runat="server" Text="Scheme (DEEC), in terms of notification no 31/97 dated, 1.4.97 or against Duty Free replenishment Certificate Licence, " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label30" runat="server" Text="in terms of Notification No. 48/2000-Cus dated 25.4.2000 or against Duty Free Replenishment Certificate Licence, in " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label32" runat="server" Text="Notification No. 46/2002-cus dated 22.4.2002 or against Duty Free Replenishment Certificate Licence issued in terms of" CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label56" runat="server" Text=" notification No 90/2004-Customs, dated the 10.9.2004 but I/We are claiming only the Central portion of the duty drawback specified in the Drawback Table." CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman"></td>
<td colspan="21">
<asp:Label ID="Label36" runat="server" Text="*(C)That the goods are manufactured and are being exported in dicharge of export obligation under the duty exemptions
" CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label37" runat="server" Text=" scheme (DEEC) but I/We are claiming Brand Rate of Drawback fixed under Rule 6 or 7 of the Customs and" CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label57" runat="server" Text="Central Excise Duty Drawback Rules 1995." CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label38" runat="server" Text="(* Strike out whichever is inapplicable) " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >5.</td>
<td colspan="25">
<asp:Label ID="Label39" runat="server" Text="That the goods are not manufactured or exported after avalling of The facility under the Duty Entitlerment Passbook " CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label40" runat="server" Text="Scheme(DEPB Scheme) as contained in para 7.14, read with para 7.17 of the Export and import Policy  " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label58" runat="server" Text="(April 1997-31&#8221;March 2002) or as contained in para 4.3 of the Export and Import Policy (April, 2002 -31&#8221;March 2007), " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label59" runat="server" Text="read with para 4.37 of the Hand Book of Procedures (Vol.1) issued under the provisions of the said policy " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label60" runat="server" Text="or manufactured or exported availing of the facility under the Duty Entitlement Pass Book Scheme as contained in " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label61" runat="server" Text="paragraph 4.3, of the Foreign Trade Policy 2004-2009, read with paragraph 4.37 of the Hand" CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label62" runat="server" Text="Book of Procedures (Vol.1) issued under the provisions of the said policy." CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >6.</td>
<td colspan="25">
<asp:Label ID="Label41" runat="server" Text="That the goods are not manufactured or exported by unit licenced as 100% Export oriented unit in terms of " CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label42" runat="server" Text="the relevant import and Export Policy or Foreign Trade Policy as the case may be. " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman
" >7.</td>
<td colspan="25">
<asp:Label ID="Label43" runat="server" Text="That the goods are not manufactured or exported by a unit situated In any free trade zone/Export Processing " CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label44" runat="server" Text="Zone or Special Economic Zone  " CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >8.</td>
<td colspan="25">
<asp:Label ID="Label45" runat="server" Text="*(A) That the goods are not manufactured partly of wholly in bond under Section 65 of the Customs Act 1962" CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="6"></td>
<td colspan="15">
<asp:Label ID="Label63" runat="server" Text="OR" CssClass="lbl_text_newcss"  align="center" Width="800px"  ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman"></td>
<td colspan="21">
<asp:Label ID="Label64" runat="server" Text="*(B) That the goods are manufactured partly or wholly in bond under section 65 of the customs Act. 1962.
" CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1"></td>
<td colspan="21">
<asp:Label ID="Label65" runat="server" Text="(* Strike out whichever is inapplicable) " CssClass="lbl_text_newcss"  align="center" Width="700px" ></asp:Label>
</td>
</tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>

<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >9.</td>
<td colspan="25">
<asp:Label ID="Label46" runat="server" Text="That the present market value of the goods is as follow" CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >10.</td>
<td colspan="25">
<asp:Label ID="Label47" runat="server" Text="That the export value of the goods covered by this Shipping Bill not Less than the total value of all imported  " CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>

<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label48" runat="server" Text="materials used in manufacture Of such goods." CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>

<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >11.</td>
<td colspan="25">
<asp:Label ID="Label49" runat="server" Text="That the market price of the goods being exported is not less than the Drawback amount being claimed." CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >12.</td>
<td colspan="25">
<asp:Label ID="Label50" runat="server" Text="That the drawback amount claimed is more that 1% of te fob value of the export Product, or the drawback amount " CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label51" runat="server" Text=" claimed is less than 1% of the fob Value nut more than Rs.500.00 against the Shipping Bill  " CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >13.</td>
<td colspan="25">
<asp:Label ID="Label52" runat="server" Text="I/We undertake to repatriate export proceeds within 6 months from date Of export and submit the necessary B.R.C.  " CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label53" runat="server" Text="to this effect of asstt.Commissioner (Drawback)in case the export proceeds are not realized within 6 months " CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label54" runat="server" Text="from the date of export I/We will either furnish extension as to the extension of time limit in this regard " CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label55" runat="server" Text="granted by the R.B.I. and Submit b.r.c. within such extended period or will pay back drawback Received" CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label66" runat="server" Text="against the exports effected under the cover of this shipping bill" CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>


<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>
<tr><td colspan="25"></td></tr>


<tr>
<td colspan="1"></td>
<td colspan="1" align="right" style=" font-size:medium; font-family:Times New Roman" >14.</td>
<td colspan="25">
<asp:Label ID="Label67" runat="server" Text="That the duties of Customs and Central Excise have been paid in respect of the containers, packing materials " CssClass="lbl_text_newcss"  align="center" Width="760px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label68" runat="server" Text="and materials unsed in the manufacture of the export goods on which drawback is being claimed and in respect  " CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label69" runat="server" Text="of such containers or materials no separate claim for rebate of duty under Rule 18 of the Central Excise" CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
</td>
</tr>
<tr><td colspan="25"></td></tr>
<tr>
<td colspan="2"></td>
<td colspan="21">
<asp:Label ID="Label70" runat="server" Text="Rules 2002 has been made or will be made to the Central Exise authorities." CssClass="lbl_text_newcss"  align="center" Width="800px" ></asp:Label>
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
<td colspan="6"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label19" runat="server" Text="For" CssClass="lbl_text_newcss"   Width="20px" ></asp:Label>
</td>

<td colspan="1">
<asp:TextBox ID="txt_For" runat="server"  CssClass="left_rht_bot_top" Width="370px" TabIndex="4"></asp:TextBox>
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
<asp:TextBox ID="txt_Exporter" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="5"></asp:TextBox>
</td>
</tr>


<tr>
<td colspan="3"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label21" runat="server" Text="Address" CssClass="lbl_text_newcss"  Width="100px" ></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txt_Address1" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="6"></asp:TextBox>
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
<asp:TextBox ID="txt_Address2" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="7"></asp:TextBox>
</td>
</tr>

<tr>
<td colspan="3"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label23" runat="server" Text="" CssClass="lbl_text_newcss"  Width="130px" ></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txt_Address3" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="8"></asp:TextBox>
</td>
</tr>

<tr>
<td colspan="3"></td>
<td style="font-family:Times New Roman"  colspan="1" >
<asp:Label ID="Label28" runat="server" Text="" CssClass="lbl_text_newcss"  Width="130px" ></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txt_Address4" runat="server"  CssClass="left_rht_bot_top" Width="270px" MaxLength="75" TabIndex="9"></asp:TextBox>
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
