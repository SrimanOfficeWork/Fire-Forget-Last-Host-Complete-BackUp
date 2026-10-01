<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_Undertaking_Form.aspx.cs" 
    Inherits="Import_Undertaking_Form" %>

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
                        Import-Undertaking Report
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
                                            onselectedindexchanged="ddlJobno_SelectedIndexChanged" 
                                            >
                                        </asp:DropDownList>
                            
                           
                            </div>


                              <div id="tag_label_transact_Src">
                              
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
                    
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'UNDERTAKING FORM', function(r) {
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

                    </div>
                    <div id="Div5">
                       <asp:Button ID="btn_Report" CssClass="generate" runat="server" 
                         OnClientClick="open_jobno(); return false;"/>

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
 <TABLE ALIGN=BLEEDLEFT WIDTH=100% CELLSPACING=0 CELLPADDING=0 BORDER=0 >
<TR>
<TD WIDTH=2.423%></TD>
<TD WIDTH=1.088%></TD>
<TD WIDTH=1.530%></TD>
<TD WIDTH=0.060%></TD>
<TD WIDTH=0.765%></TD>
<TD WIDTH=1.275%></TD>
<TD WIDTH=2.806%></TD>
<TD WIDTH=0.315%></TD>
<TD WIDTH=0.706%></TD>
<TD WIDTH=1.173%></TD>
<TD WIDTH=0.051%></TD>
<TD WIDTH=7.185%></TD>
<TD WIDTH=3.129%></TD>
<TD WIDTH=1.445%></TD>
<TD WIDTH=0.536%></TD>
<TD WIDTH=0.383%></TD>
<TD WIDTH=1.403%></TD>
<TD WIDTH=1.726%></TD>
<TD WIDTH=0.570%></TD>
<TD WIDTH=0.842%></TD>
<TD WIDTH=0.179%></TD>
<TD WIDTH=0.553%></TD>
<TD WIDTH=1.369%></TD>
<TD WIDTH=0.119%></TD>
<TD WIDTH=1.020%></TD>
<TD WIDTH=0.765%></TD>
<TD WIDTH=0.842%></TD>
<TD WIDTH=0.434%></TD>
<TD WIDTH=2.389%></TD>
<TD WIDTH=0.485%></TD>
<TD WIDTH=1.207%></TD>
<TD WIDTH=4.847%></TD>
<TD WIDTH=0.255%></TD>
<TD WIDTH=3.316%></TD>
<TD WIDTH=0.765%></TD>
<TD WIDTH=0.799%></TD>
<TD WIDTH=1.624%></TD>
<TD WIDTH=0.578%></TD>
<TD WIDTH=0.060%></TD>
<TD WIDTH=0.986%></TD>
<TD WIDTH=0.034%></TD>
<TD WIDTH=0.757%></TD>
<TD WIDTH=0.264%></TD>
<TD WIDTH=1.020%></TD>
<TD WIDTH=0.340%></TD>
<TD WIDTH=1.318%></TD>
<TD WIDTH=3.189%></TD>
<TD WIDTH=0.255%></TD>
<TD WIDTH=0.765%></TD>
<TD WIDTH=11.479%></TD>
<TD WIDTH=0.383%></TD>
<TD WIDTH=3.699%></TD>
<TD WIDTH=0.383%></TD>
<TD WIDTH=6.122%></TD>
<TD WIDTH=3.316%></TD>
<TD WIDTH=0.383%></TD>
<TD WIDTH=1.020%></TD>
<TD WIDTH=3.061%></TD>
<TD WIDTH=4.081%></TD>
<TD WIDTH=1.020%></TD>
<TD WIDTH=1.054%></TD>
<TD WIDTH=0.986%></TD>
<TD WIDTH=0.264%></TD>
<TD WIDTH=0.060%></TD>
<TD WIDTH=0.306%></TD>
<TD WIDTH=0.391%></TD>
<TD WIDTH=0.731%></TD>
<TD WIDTH=0.289%></TD>
<TD WIDTH=0.383%></TD>
<TD WIDTH=0.638%></TD>
<TD WIDTH=0.009%></TD>
</TR>
</TABLE>



<table>
<tr>

<td width=30></td>
<td width=50></td>

<td style="font-family:Times New Roman" align="center">

   

    <asp:Label ID="Label1111" runat="server" Text="BRIHANMUMBAI MAHANAGARPALIKA" CssClass="lbl_text_newcss" Font-Bold="true" Font-Size="Large" align="center" Width="400px" ></asp:Label>

</td>


</tr>
<tr>
<td width=30></td>
<td width=50></td>

</tr>
<tr>
<td width=30></td>
<td width=50></td>
<td align="center">
<asp:Label ID="Label1" runat="server"  CssClass="lbl_text_newcss" Text="Undertaking to be given at time of registration of 'N' from on party's letter head" Font-Bold="true"></asp:Label>
</td>
<%--<td width=100></td>--%>
</tr>

<tr>    
<td ></td>
<td>
    

    
      
</td>
<td align="center">
<asp:Label ID="nooctrai" runat="server"  CssClass="lbl_text_newcss" Text="and/or with Rubber Stamp of the Company." Font-Bold="true"></asp:Label>

</td>
</tr>

<tr>
<td ></td>
<td>
   <asp:Label CssClass="lbl_text_newcss"  ID="Label3" runat="server"  Font-Bold="true"
        Width="40" Text="To:" 
        BorderStyle="None" ReadOnly="True" ></asp:Label>
</td>
</tr>

<tr>

<%--<td style="width:30px"></td>--%>
    
<td ></td>
<td>
    
   <asp:Label CssClass="lbl_text_newcss"  ID="Label31" runat="server" 
        Width="40" Text=" " 
        BorderStyle="None" ReadOnly="True" ></asp:Label>
    
      
</td>
<td >
<asp:Label ID="Label33" runat="server"  CssClass="lbl_text_newcss" Text="The Municipal Commissioner of Greater Mumbai"></asp:Label>

</td>
</tr>
<tr>
<td style="width=40"></td>
    
<td ></td>
<td>
   <asp:Label CssClass="lbl_text_newcss"  ID="txt_trans_commission" runat="server" Width="310" Text="Mahapalika Marg,"></asp:Label>

</td>
</tr>

<tr>
<td style="width=40"></td>
    
<td ></td>
<td>
    <asp:Label CssClass="lbl_text_newcss"  ID="TextBox1" runat="server" Width="310" Text="Mumbai-400 001."></asp:Label>

</td>
</tr>

<tr>
<td style="width=30" ></td>
    
<td ></td>
<td >
    <asp:Label CssClass="lbl_text_newcss"  ID="Label15" runat="server" Width="270"  ></asp:Label>
    <asp:Label CssClass="lbl_text_newcss"  ID="Label16" runat="server" Width="40" Text="SUB :" ></asp:Label>
    <asp:Label CssClass="lbl_text_newcss"  ID="Label17" runat="server" Width="250" Text="Exemption from payment of Octrai" ></asp:Label>
</td>
</tr>


<tr>
<td style="width=30" ></td> 
<td ></td>
<td >
    <asp:Label CssClass="lbl_text_newcss"  ID="Label18" runat="server" Width="310"  ></asp:Label>  
    <asp:Label CssClass="lbl_text_newcss"  ID="Label21" runat="server" Width="290" Text="under the provisions of Exemption" ></asp:Label>
</td>
</tr>


<tr>
<td style="width=30" ></td> 
<td ></td>
<td >
    <asp:Label CssClass="lbl_text_newcss"  ID="Label20" runat="server" Width="310"  ></asp:Label>  
    <asp:Label CssClass="lbl_text_newcss"  ID="Label36" runat="server" Width="290" Text="Octrai(immediate Exportation)" ></asp:Label>
</td>
</tr>

<tr>
<td style="width=30" ></td> 
<td ></td>
<td >
    <asp:Label CssClass="lbl_text_newcss"  ID="Label37" runat="server" Width="310"  ></asp:Label>  
    <asp:Label CssClass="lbl_text_newcss"  ID="Label40" runat="server" Width="290" Text="Rules 1965," ></asp:Label>
</td>
</tr>



<tr>
<td>
</td>
<td><asp:Label CssClass="lbl_text_newcss"  ID="txt_trans_sir" runat="server" 
        Width="40" Text="Sir," 
        BorderStyle="None" ReadOnly="True"></asp:Label></td></tr>

        <tr>
        <td colspan="2">
<td><asp:Label   ID="txt_trans_please" 
        runat="server" Width="60px" CssClass="lbl_text_newcss" 
        
        Text="I/We For"></asp:Label>
        <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_ImporterName1"   runat="server" Width="315px" MaxLength="40" ></asp:TextBox>

            <asp:Label CssClass="lbl_text_newcss"  ID="Label41" runat="server" Width="210" Text="residing at/carrying on business at " ></asp:Label>
            <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_ImporterAdd1"   runat="server" Width="185px" MaxLength="35" ></asp:TextBox>
        </td>
<td>
</td>
</tr>



<tr>
<td >
</td>
<td></td>
<td width="800px">
    <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_ImporterAdd2" runat="server" Width="255px" MaxLength="35"
        ClientIDMode="Static"></asp:TextBox>
<asp:TextBox CssClass="left_rht_bot_top"  ID="txt_ImporterAdd3" runat="server" Width="255" MaxLength="35"></asp:TextBox>
        <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_ImporterAdd4" MaxLength="35"
        runat="server" Width="255px"></asp:TextBox>
                     
</td>
<td></td>
</tr>

<tr>
<td >
</td>
<td></td>
<td width="800px">
    <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_ImporterAdd5" runat="server" Width="195px" MaxLength="35"
        ClientIDMode="Static"></asp:TextBox>
          <asp:Label CssClass="lbl_text_newcss"  ID="Label42" runat="server" Width="170" Text="having PAN No. IE Code No" ></asp:Label>
          <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_IEC_CodeNo" runat="server" Width="155px" MaxLength="10"
        ClientIDMode="Static"></asp:TextBox>
          <asp:Label CssClass="lbl_text_newcss"  ID="Label43" runat="server" Width="250" Text="do hereby agree and undertake as under:-" ></asp:Label>
</td>
<td></td>
</tr>

<tr><td style="height:20px"></td></tr>


<tr>
<td >
</td>
<td></td>
<td width="800px">
  <asp:Label CssClass="lbl_text_newcss"  ID="Label45" runat="server" Width="750" Text="WHEREAS I/We am/are importer of the consignment covered under Customs Import Bill of Entry/Customs Export" ></asp:Label>
</td>
<td></td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
<td><asp:Label   ID="Label52"  runat="server" Width="460px" CssClass="lbl_text_newcss"   Text="Shipping Bill/Air Consignment Note/Export Invoice/Railway forwarding Note No:"></asp:Label>

        <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_NoteNo"   runat="server" Width="115px" MaxLength="15" ></asp:TextBox>

            <asp:Label CssClass="lbl_text_newcss"  ID="Label53" runat="server" Width="40" Text="Date" ></asp:Label>
      <%--      <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_Note_Date"   runat="server" Width="85px"  ></asp:TextBox>--%>

                           <asp:TextBox ID="txt_Note_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="30" TabIndex="24"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender1"
                                        runat="server" TargetControlID="txt_Note_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Note_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>

        </td> </td>
<td>
</td>
</tr>


  <tr>
  <td colspan="2" style="height:20px">
    <td><asp:Label   ID="Label44"  runat="server" Width="690px" CssClass="lbl_text_newcss"   Text="requested the Municipal Commisioner of Greater to claim the exemption 
    from payment of octrai under the provisions of"></asp:Label>
        </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    <td><asp:Label   ID="Label46"  runat="server" Width="690px" CssClass="lbl_text_newcss"   Text="exemption of Octrai (Immediate Exportation) Rules, 1965. "></asp:Label>
   
        </td> </td>
<td>
</td>
</tr>


  <tr>
  <td colspan="2" style="height:40px">
    <td><asp:Label   ID="Label54"  runat="server" Width="690px" CssClass="lbl_text_newcss"   Text="AND WHEREAS the Municipal Commissioner of Greater Mumbai has agreed to grand the permission on giving "></asp:Label>
   
        </td> </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    <td><asp:Label   ID="Label55"  runat="server" Width="690px" CssClass="lbl_text_newcss"   Text="undertaking hereinafter appearing."></asp:Label>
   
        </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    <td align="center"><asp:Label   ID="Label56"  runat="server" Width="490px" CssClass="lbl_text_newcss"   Text="OR"></asp:Label> </td>
        </td> </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:40px">
    <td><asp:Label   ID="Label57"  runat="server" Width="30px" CssClass="lbl_text_newcss"   Text="I/We"></asp:Label>
   <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_CHAName"   runat="server" Width="315px"  MaxLength="40"></asp:TextBox>
            <asp:Label CssClass="lbl_text_newcss"  ID="Label58" runat="server" Width="230" Text="Agent or the Custom House Agent No." ></asp:Label>
            <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_CHANo"   runat="server" Width="185px"  MaxLength="15"></asp:TextBox>
        </td> </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    <td><asp:Label   ID="Label59"  runat="server" Width="140px" CssClass="lbl_text_newcss"   Text="carrying on business at"></asp:Label>
     <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_CHA_Add1"   runat="server" Width="215px" MaxLength="35" ></asp:TextBox> 
     <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_CHA_Add2"   runat="server" Width="205px"  MaxLength="35"></asp:TextBox>
      <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_CHA_Add3"   runat="server" Width="195px"  MaxLength="35"></asp:TextBox>
   
        </td> </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    
      <td><asp:TextBox CssClass="left_rht_bot_top"  ID="txt_CHA_Add4"   runat="server" Width="215px" MaxLength="35" ></asp:TextBox> 
     <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_CHA_Add5"   runat="server" Width="205px"  MaxLength="35"></asp:TextBox>
     <asp:Label   ID="Label62"  runat="server" Width="140px" CssClass="lbl_text_newcss"   Text="having."></asp:Label>
   
        </td> </td>
<td>
</td>
</tr>


  <tr>
  <td colspan="2" style="height:40px">
    <td><asp:Label   ID="Label63"  runat="server" Width="90px" CssClass="lbl_text_newcss"   Text="SHRI/M/s. For"></asp:Label>
   <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_ImporterName2"   runat="server" Width="315px"  MaxLength="40"></asp:TextBox>
            <asp:Label CssClass="lbl_text_newcss"  ID="Label64" runat="server" Width="350" Text="the Importer, requested the Municipal Commissioner to grant" ></asp:Label>
          
        </td> </td>
<td>
</td>
</tr>


  <tr>
  <td colspan="2" style="height:20px">
    <td><asp:Label   ID="Label65"  runat="server" Width="690px" CssClass="lbl_text_newcss"   Text="the permission to claim the exemption from the payment of Octrai, on the articles covered Customs Import Bill of Entry "></asp:Label>
   
        </td> </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    <td><asp:Label   ID="Label66"  runat="server" Width="330px" CssClass="lbl_text_newcss"   Text="Customs Export Shipping Bill/Air Consignment Note No"></asp:Label>
    <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_Consignment_NoteNo"   runat="server" Width="135px" MaxLength="15" ></asp:TextBox>
    <asp:Label   ID="Label67"  runat="server" Width="30px" CssClass="lbl_text_newcss"   Text="Date"></asp:Label>
  
                                    
                                     <asp:TextBox ID="txt_Consignment_NoteDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="30" TabIndex="24"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender3"
                                        runat="server" TargetControlID="txt_Consignment_NoteDate" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Consignment_NoteDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                    
                                    

   <asp:Label CssClass="lbl_text_newcss"  ID="Label68" runat="server" Width="150" Text="under the provisions of" ></asp:Label>
        </td> </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    <td><asp:Label   ID="Label69"  runat="server" Width="690px" CssClass="lbl_text_newcss"   Text="Exemption of Octrai(Immediate Exportation) Rules, 1965. "></asp:Label>   
        </td>
<td>
</td>
</tr>


  <tr>
  <td colspan="2" style="height:50px">
    <td align="center"><asp:Label   ID="Label70"  runat="server" Width="690px" CssClass="lbl_text_newcss"   Text=" UNDERTAKING " Font-Bold="true" Font-Size="Medium"></asp:Label>   
        </td> </td>
<td>
</td>
</tr>


  <tr>
  <td colspan="2" style="height:40px">
    <td><asp:Label   ID="Label71"  runat="server" Width="50px" CssClass="lbl_text_newcss"   Text="1. I/We"></asp:Label>
   <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_Importer_Undertaking"   runat="server" Width="315px"  MaxLength="40"></asp:TextBox>
   <asp:Label CssClass="lbl_text_newcss"  ID="Label72" runat="server" Width="330" Text="hereby agree and declare that the articles covered and" ></asp:Label>
            
        </td> </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    <td ><asp:Label   ID="Label73"  runat="server" Width="750px" CssClass="lbl_text_newcss"   Text=" import/export documents and declared in form 'N' are not imported for the purpose of Consumption, use or sale."></asp:Label>
   
        </td> </td>
<td>
</td>
</tr>


  <tr>
  <td colspan="2" style="height:40px">
    <td><asp:Label   ID="Label74"  runat="server" Width="690px" CssClass="lbl_text_newcss"   Text="2. I/We hereby undertake to abide the provision of the Exemption Rules."></asp:Label>
   
        </td> </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:40px">
    <td><asp:Label   ID="Label75"  runat="server" Width="710px" CssClass="lbl_text_newcss"   Text="3. I/We hereby agree and undertake that I/We shall tender the articles so exemption under 'N' Form at the place of export"></asp:Label>
   
         </td></td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    <td><asp:Label   ID="Label76"  runat="server" Width="690px" CssClass="lbl_text_newcss"   Text=" and preserve the certified copies there of for Submission to the Municipal offices as and when required for examination."></asp:Label>
   
        </td> </td>
<td>
</td>
</tr>


  <tr>
  <td colspan="2" style="height:40px">
    <td><asp:Label   ID="Label77"  runat="server" Width="710px" CssClass="lbl_text_newcss"   Text="4. I/We hereby further agree and undertake that I/We shall pay Octrai on thye articles so exempted under 'N' in case"></asp:Label>
   
        </td> </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    <td ><asp:Label   ID="Label78"  runat="server" Width="680px" CssClass="lbl_text_newcss"   Text=" I/We fail to observe the contents as mentioned in clause 3 here in above fourwith on demand by the Dy.Assessor &."></asp:Label>
   
         </td></td>
<td>
</td>
</tr>


  <tr>
  <td colspan="2" style="height:40px">
    <td><asp:Label   ID="Label79"  runat="server" Width="710px" CssClass="lbl_text_newcss"   Text="5. I/We hereby further agree and undertake that in the event of I/We failed to pay Octrai  so demanded by the Dy.Assessor"></asp:Label> </td>
   
     </td>   
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
    <td ><asp:Label   ID="Label80"  runat="server" Width="670px" CssClass="lbl_text_newcss"   Text=" and Collector(Octrai), the Municipal Commissioner Assessor and Collector(Octrai), Shall be at liberty to Dated this"></asp:Label>
   
        </td> </td>
<td>
</td>
</tr>

  <tr>
  <td colspan="2" style="height:50px">
  <td align="right"><asp:Label   ID="Label2"  runat="server" Width="310px" CssClass="lbl_text_newcss"   Text="For"></asp:Label> 
    <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_Importer_FOR"   runat="server" Width="315px"  MaxLength="40"></asp:TextBox></td></td>
       
<td style="width:50px">
</td>
</tr>

  <tr>
  <td colspan="2" style="height:50px">
  <td align="right"><asp:Label   ID="Label4"  runat="server" Width="310px" CssClass="lbl_text_newcss"   Text="Authorized Signatory" Font-Underline="true"></asp:Label> 
   
<td style="width:50px">
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
  <td align="right"><asp:Label   ID="Label5"  runat="server" Width="310px" CssClass="lbl_text_newcss"   Text="Agent/CHA/Importer/Export"></asp:Label> 
   
<td style="width:50px">
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
  <td><asp:Label   ID="Label6"  runat="server" Width="310px" CssClass="lbl_text_newcss"   Text="Witness" Font-Underline="true"></asp:Label> 
   
<td style="width:50px">
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
   <td><asp:Label   ID="Label7"  runat="server" Width="10px" CssClass="lbl_text_newcss"   Text="1." ></asp:Label> 
   <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_Witness1"   runat="server" Width="315px"  MaxLength="50"></asp:TextBox></td></td>
   
<td style="width:50px">
</td>
</tr>

  <tr>
  <td colspan="2" style="height:20px">
  <td><asp:Label   ID="Label8"  runat="server" Width="10px" CssClass="lbl_text_newcss"   Text="2." ></asp:Label> 
   <asp:TextBox CssClass="left_rht_bot_top"  ID="txt_Witness2"   runat="server" Width="315px"  MaxLength="50"></asp:TextBox></td></td>
   
<td style="width:50px">
</td>
</tr>

</table>

    </div>                      
                     </div>
                    </div>
                    <asp:HiddenField ID="hdn_freight_val" runat="server" ClientIDMode="Static"/>
                    <asp:HiddenField ID="hdn_sur_val" runat="server" ClientIDMode="Static"/>
                    <asp:HiddenField ID="hdn_land_val" runat="server" ClientIDMode="Static"/>
                    <asp:HiddenField ID="hdn_value_val" runat="server" ClientIDMode="Static"/>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <asp:HiddenField ID="hdn_val" runat="server" />
                    
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
//           function btnclick() {
////               document.getElementById("<%=btn.ClientID %>").click();
//               document.getElementById("<%=btn.ClientID %>").click();

//           }
//           window.onload = happycode;
//           function happycode() {

//               document.getElementById("JOB_NO").click();

//           }
////           function open_jobno() {

////           }
//           function ddl_cfs_change(val) {
//               
//               var ctrl = document.getElementById(val);

//               document.getElementById("txt_trans_cfs").value = ctrl.value;
//               document.getElementById("txt_trans_cfsname").value = ctrl.value;
//               document.getElementById("txt_trans_cfs1").value = ctrl.value;
//                   //document.getElementById("txt_MVT_CFSFINAL").value = ctrl.value;

//             

//           }
//           function validate() {

    </script>
      
       <script type="text/javascript">

           function open_jobno() {

               if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                   document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                   if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                       var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                       NewWindow1('../Report/Import_Undertaking_Form_Rpt_viewer.aspx?jobno=' + f + '', 'List', '810', '1024', 'yes');

                       //opennew_Import_report(f);
                       return false
                       alert(f);
                   }
               }

           }

       


           window.onload = happycode;
           window.onload = happycode1;
           function happycode() {

               document.getElementById("Transaction_Id").click();

           }

           function openurl(url) {
               var a = $('#<%= HiddenField1.ClientID %>').val();

               if (a.length == 0) {
                   window.location.href = url;

               }
               else {
                   Child_Parent_close_button1('General'); return false;
               }
           }
           $(function () {

               var dropDownList1 = $('#<%= ddlJobNo.ClientID %>');

               dropDownList1.change(function (e) {
                   var selectedValue = $(this).val();

                   if (selectedValue != '') {


                       document.getElementById('HiddenField1').value = selectedValue;
                       //alert(document.getElementById('HiddenField1').value);

                   }
               });



           });
//           function CallServerside_Importer1(src, dest) {
//               Loading_ShowImage();

//               // call server side method

//               PageMethods.Get_Import_Details(src, CallSuccess_Importer, CallFailed, dest);
//           }

//           function CallServerside_Importer(src, dest) {
//               Loading_ShowImage();

//               var ctrl = document.getElementById(src);

//               // call server side method

//               PageMethods.Get_Import_Details(ctrl.value, CallSuccess_Importer, CallFailed, dest);

//           }

        
      </script>
   
  </body>
    </html>
