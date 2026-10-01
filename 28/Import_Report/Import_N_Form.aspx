<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_N_Form.aspx.cs" 
    Inherits="Import_N_Form" %>

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
            <div id="innerbox_MidMain_Transact_popup_new" style="height: 95px;">
                <div id="tag_srcinner1_new">
                    <div id="Div1">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Import-NForm Report
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
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlJobno_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="TxtJOBNO" runat="server" Font-Bold="true" CssClass="left_rht_bot_top"
                                        Width="150px" Visible="false"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src">
                                </div>
                                <div id="txtcon-m_src">
                                    <asp:Button ID="btnSend" Text="ViewPage1" runat="server" OnClientClick="open_jobno();" />
                                    <asp:Button ID="btnSend22" Text="ViewPage2" runat="server" OnClientClick="open_jobno2();" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transact_srcinner_rght" style="margin-right: 90px; margin-top: 25px;
                        width: 280px;">
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="13"
                                OnClientClick="return validate();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                Visible="false" TabIndex="13" OnClientClick="return validate();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'NFORM MASTER', function(r) {
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
                        </div>
                    </div>
                </div>
            </div>
                
            <div id="innerbox_MidMain_Trans_new" style="height: 461px">
                <ol id="toc_new">
                </ol>
                <%-- <div class="content" id="page-1" style="overflow:scroll;height:878px;width:1260px;margin-top: 15px;">--%>
                <div class="content" id="page-1" style="overflow: scroll; height: 441px; width: 965px;
                    margin-top: 15px;">
                    <%--<div id="Main_Grid_Container" style="margin:0px    0px;border:0px;height:550px;width:910;overflow:auto;">--%>
                    <div>
                        <table align="BLEEDLEFT" width="100%" cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td width="2.423%">
                                </td>
                                <td width="1.088%">
                                </td>
                                <td width="1.530%">
                                </td>
                                <td width="0.060%">
                                </td>
                                <td width="0.765%">
                                </td>
                                <td width="1.275%">
                                </td>
                                <td width="2.806%">
                                </td>
                                <td width="0.315%">
                                </td>
                                <td width="0.706%">
                                </td>
                                <td width="1.173%">
                                </td>
                                <td width="0.051%">
                                </td>
                                <td width="7.185%">
                                </td>
                                <td width="3.129%">
                                </td>
                                <td width="1.445%">
                                </td>
                                <td width="0.536%">
                                </td>
                                <td width="0.383%">
                                </td>
                                <td width="1.403%">
                                </td>
                                <td width="1.726%">
                                </td>
                                <td width="0.570%">
                                </td>
                                <td width="0.842%">
                                </td>
                                <td width="0.179%">
                                </td>
                                <td width="0.553%">
                                </td>
                                <td width="1.369%">
                                </td>
                                <td width="0.119%">
                                </td>
                                <td width="1.020%">
                                </td>
                                <td width="0.765%">
                                </td>
                                <td width="0.842%">
                                </td>
                                <td width="0.434%">
                                </td>
                                <td width="2.389%">
                                </td>
                                <td width="0.485%">
                                </td>
                                <td width="1.207%">
                                </td>
                                <td width="4.847%">
                                </td>
                                <td width="0.255%">
                                </td>
                                <td width="3.316%">
                                </td>
                                <td width="0.765%">
                                </td>
                                <td width="0.799%">
                                </td>
                                <td width="1.624%">
                                </td>
                                <td width="0.578%">
                                </td>
                                <td width="0.060%">
                                </td>
                                <td width="0.986%">
                                </td>
                                <td width="0.034%">
                                </td>
                                <td width="0.757%">
                                </td>
                                <td width="0.264%">
                                </td>
                                <td width="1.020%">
                                </td>
                                <td width="0.340%">
                                </td>
                                <td width="1.318%">
                                </td>
                                <td width="3.189%">
                                </td>
                                <td width="0.255%">
                                </td>
                                <td width="0.765%">
                                </td>
                                <td width="11.479%">
                                </td>
                                <td width="0.383%">
                                </td>
                                <td width="3.699%">
                                </td>
                                <td width="0.383%">
                                </td>
                                <td width="6.122%">
                                </td>
                                <td width="3.316%">
                                </td>
                                <td width="0.383%">
                                </td>
                                <td width="1.020%">
                                </td>
                                <td width="3.061%">
                                </td>
                                <td width="4.081%">
                                </td>
                                <td width="1.020%">
                                </td>
                                <td width="1.054%">
                                </td>
                                <td width="0.986%">
                                </td>
                                <td width="0.264%">
                                </td>
                                <td width="0.060%">
                                </td>
                                <td width="0.306%">
                                </td>
                                <td width="0.391%">
                                </td>
                                <td width="0.731%">
                                </td>
                                <td width="0.289%">
                                </td>
                                <td width="0.383%">
                                </td>
                                <td width="0.638%">
                                </td>
                                <td width="0.009%">
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="30">
                                </td>
                                <td width="50">
                                </td>
                                <td style="font-family: Times New Roman" align="center">
                                    <%-- <asp:TextBox CssClass="left_rht_bot_top"  ID="TextBox13" runat="server"  Font-Bold="true" Font-Size="Large" 
         Text="FORM 'N'" BorderStyle="None" Width="200px"></asp:TextBox>--%>
                                    <asp:Label ID="Label1111" runat="server" Text="FORM 'N'" CssClass="lbl_text_newcss"
                                        Font-Bold="true" Font-Size="Large" align="center" Width="100px"></asp:Label>
                                </td>
                                <%--<td width=150 ></td>--%>
                                <%--<td width=150 colspan="2"></td>--%>
                            </tr>
                            <tr>
                                <td width="30">
                                </td>
                                <td width="50">
                                </td>
                                <%--<td width=100></td>--%>
                            </tr>
                            <tr>
                                <td width="30">
                                </td>
                                <td width="50">
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" CssClass="lbl_text_newcss" Text="Import-Export Free octrai"
                                        Font-Bold="true"></asp:Label>
                                </td>
                                <%--<td width=100></td>--%>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label3" runat="server" Font-Bold="true"
                                        Width="40" Text="To:" BorderStyle="None" ReadOnly="True"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="nooctrai" runat="server" CssClass="lbl_text_newcss" Text="No:"></asp:Label>
                                    <asp:TextBox ID="txt_octraiNo1" runat="server" CssClass="left_rht_bot_top"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <%--<td style="width:30px"></td>--%>
                                <td>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label31" runat="server" Width="40" Text=" "
                                        BorderStyle="None" ReadOnly="True"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label33" runat="server" CssClass="lbl_text_newcss" Text="Date:"></asp:Label>
                                    <asp:TextBox ID="txt_octrai_date" runat="server" CssClass="left_rht_bot_top"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width=30">
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_trans_commission" runat="server"
                                        Width="310" Text="The Dy. ASSESSOR & COLLECTOR (OCTROI)"></asp:TextBox>
                                    <%--<asp:Label ID="blank" runat="server" CssClass="lbl_text_newcss" Width="350px" Text=" "></asp:Label>
     <asp:Label ID="Label4" runat="server"  CssClass="lbl_text_newcss" Text="Date:"></asp:Label>
<asp:TextBox ID="TextBox1" runat="server" CssClass="left_rht_bot_top"></asp:TextBox>--%>
                                </td>
                                <%--<td align="right">
<asp:Label ID="Label31" runat="server"  CssClass="lbl_text_newcss" Text="No:"></asp:Label>
</td>
<td></td>--%>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_sir" runat="server" Width="40"
                                        Text="Sir," BorderStyle="None" ReadOnly="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="2" align="center">
                                    <asp:Label ID="txt_trans_please" runat="server" Width="590px" CssClass="lbl_text_newcss"
                                        Text="We have to request that the undermentioned Articles which have been imported by me per"></asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="TextField1" runat="server" Width="215px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td width="800px">
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="TextField2" runat="server" Width="215px"
                                        ClientIDMode="Static"></asp:TextBox>
                                    <asp:Label CssClass="lbl_text_newcss" ID="TextField31" runat="server" Text="from"
                                        Width="40px" BorderStyle="None" ReadOnly="True"></asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="TextField3" runat="server" Width="215"></asp:TextBox>
                                    <asp:Label ID="txt_trans_behalf" runat="server" CssClass="lbl_text_newcss" Width="90px"
                                        Text="and landed at"></asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="TextField4" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="2">
                                    <asp:Label CssClass="lbl_text_newcss" ID="TextBox2" runat="server" Width="350px"
                                        Text="for the purpose of immediate exportati from place of export"></asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="TextField5" runat="server" Width="230px"></asp:TextBox>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label2" runat="server" Width="20px" Text="per"></asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="TextField6" runat="server" Width="215px"></asp:TextBox>
                                    <%--<asp:Label CssClass="lbl_text_newcss"  ID="Label4" runat="server" 
        Width="270px" Text="and to be consigned to (name of consignee)"></asp:Label>
         <asp:TextBox CssClass="left_rht_bot_top"  ID="TextField7" 
        runat="server" Width="250px"></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="2">
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label28" runat="server" Width="290px" Text=" and to be consigned to(name of consignee)"></asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="TextField7" runat="server" Width="215px"></asp:TextBox>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label6" runat="server" Width="90px" Text="at (destination)"></asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="TextField8" runat="server" Width="200px"></asp:TextBox>
                                    <%--<asp:Label CssClass="lbl_text_newcss"  ID="Label7" runat="server" 
        Width="210px" Text="be exempted from the levy of octroi."></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="2">
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label7" runat="server" Width="210px" Text="be exempted from the levy of octroi."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td width="30">
                                </td>
                                <td width="50">
                                </td>
                                <td align="right">
                                </td>
                                <%--<td width=100></td>--%>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label4" runat="server" Font-Bold="true"
                                        Width="40" Text=" " BorderStyle="None" ReadOnly="True"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label35" runat="server" CssClass="lbl_text_newcss" Text="Percentage of Octrai:"
                                        Font-Bold="true"></asp:Label>
                                    <asp:TextBox ID="txtOctpercent" runat="server" CssClass="left_rht_bot_top" AutoPostBack="true"
                                        Width="50px" OnTextChanged="txtOctpercent_TextChanged"></asp:TextBox>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Labelper" runat="server" Font-Bold="true"
                                        Text="%"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                        </table>
                        <table>
                            <tr>
                                <td width="20">
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_marks1" runat="server" Width="140px"
                                        Text="Number and date of import document" Font-Bold="True" ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_pkg1" runat="server" Width="55px"
                                        Text="Number of Pkgs" Font-Bold="True" ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_desc1" runat="server" Width="147px"
                                        Text="Description of Packages" Font-Bold="True" ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_weight1" runat="server" Width="120px"
                                        Text="Description of Articles" Font-Bold="True" ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_mainfest1" runat="server" Width="130px"
                                        Text="Import Marks If Any" Font-Bold="True" ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_value1" runat="server" Width="80px"
                                        Text="Weight or Quantity as per Import" Font-Bold="True" ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_remarks1" runat="server" align="right"
                                        Width="150px" Text="Number of Packages escorted earlier" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20">
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label5" runat="server" Width="140px" Font-Bold="True"
                                        ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label8" runat="server" Width="45px" Font-Bold="True"
                                        ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label9" runat="server" Width="147px" Font-Bold="True"
                                        ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label10" runat="server" Width="120px" Font-Bold="True"
                                        ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label11" runat="server" Width="130px" Font-Bold="True"
                                        ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label12" runat="server" Width="60px" Font-Bold="True"
                                        ReadOnly="True"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label13" runat="server" Width="75px" Text="N Form No."
                                        Font-Bold="True"></asp:Label>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label14" runat="server" Width="75px" Text="No Pkg"
                                        Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="50">
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_No_DateofDoc" runat="server" Width="130px"
                                        Height="80" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_trans_pkgno" runat="server" Width="55px"
                                        Height="80" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_trans_descno" runat="server" Width="140px"
                                        Height="80" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_trans_desc_Articles" runat="server"
                                        Width="120" Height="80" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_trans_Import_Marks" runat="server"
                                        Width="130px" Height="80" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_WeightOrQTY" runat="server" Width="80px"
                                        Height="80" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_trans_NFormno" runat="server" Width="75px"
                                        Height="80" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="PkgNo" runat="server" Width="75px" Height="80"
                                        TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <%--<asp:Label CssClass="lbl_text_newcss"  ID="Label14" runat="server" 
        Width="75px" Text="No Pkg" Font-Bold="True"></asp:Label></td>--%>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label47" runat="server" Width="150px" Text="Number of Packages on which octroi has been paid"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label48" runat="server" Width="130px" Text="Number Of Pkgs To Be Escorted"
                                        Font-Bold="True" ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label49" runat="server" Width="130px" Text="Number and Date Of Export Document"
                                        Font-Bold="True" ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label50" runat="server" Width="130px" Text="Weight and value and rate for Octroi"
                                        Font-Bold="True" ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label51" runat="server" Width="130px" Text="Remarks"
                                        Font-Bold="True" ReadOnly="True"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td width="20">
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label60" runat="server" Width="75px" Text="No pkg"
                                        Font-Bold="True"></asp:Label>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label61" runat="server" Width="75px" Text="Imp Bill"
                                        Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_Octroi_Paid" runat="server" Width="75px"
                                        Height="130" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_Imp_Bill" runat="server" Width="75px"
                                        Height="130" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_Pkg_Escorted" runat="server" Width="120px"
                                        Height="130" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_No_DateExpDoc" runat="server" Width="120px"
                                        Height="130" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_ValueOfOctrai" runat="server" Width="120px"
                                        Height="130" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_Remarks" runat="server" Width="110px"
                                        Height="130" TextMode="MultiLine" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="1px">
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_consignee" runat="server" Width="400px"
                                        Text="Let the above articles be removed free of Octroi to the place of export"
                                        ReadOnly="True"></asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_PlaceOfExport" runat="server" BorderStyle="None"
                                        Width="170px"></asp:TextBox>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_add1" runat="server" Width="300px"
                                        Text="I/We do hereby declare that the contents of the"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="1px">
                                </td>
                                <td>
                                    <asp:Label ID="TextBox5" runat="server" Width="150px" CssClass="lbl_text_newcss">under supervision of Shri</asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_NameOfApplicant" runat="server"
                                        Width="410px"></asp:TextBox>
                                    <asp:Label ID="Label22" runat="server" Width="250px" Style="padding-left: 116px;"
                                        CssClass="lbl_text_newcss">Application are truly stated.</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_jurisd" runat="server" Width="300px"></asp:Label>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_asst" runat="server" Width="420px"
                                        Text="(Name and designation)"></asp:Label>
                                    <%-- <asp:LabelID="TextBox16" runat="server" Width="60"
        Text="For"></asp:Label>--%>
                                    For<asp:Label CssClass="lbl_text_newcss" Font-Bold="true" ID="Label25" runat="server"
                                        Width="150" Style="text-align: right;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label23" runat="server" Width="300px"></asp:Label>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label24" runat="server" Width="300px"></asp:Label>
                                    <%--<asp:Label CssClass="lbl_text_newcss"  ID="Label25" runat="server" 
        Width="390px"></asp:Label>--%>
                                    <asp:TextBox ID="txtimpadd1" runat="server" Width="320px" CssClass="left_rht_bot_top"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label29" runat="server" Width="300px">Signature of the Supervising inspector</asp:Label>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label30" runat="server" Width="300px"></asp:Label>
                                    <%--<asp:Label CssClass="lbl_text_newcss"  ID="Label31" runat="server" 
        Width="390px"></asp:Label>--%>
                                    <asp:TextBox ID="txtimpadd2" runat="server" Width="320px" CssClass="left_rht_bot_top"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label26" runat="server" Width="300px"></asp:Label>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label27" runat="server" Width="300px"></asp:Label>
                                    <%--<asp:Label CssClass="lbl_text_newcss"  ID="Label28" runat="server" 
        Width="390px"></asp:Label>--%>
                                    <asp:TextBox ID="txtimpadd3" runat="server" Width="320px" CssClass="left_rht_bot_top"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label32" runat="server" Width="60px">Date</asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txt_Datee" runat="server" Width="90px"></asp:TextBox>
                                    <asp:Label ID="Label39" runat="server" Width="200px"></asp:Label>
                                    <asp:TextBox CssClass="left_rht_bot_top" ID="txtAuthorisedSign" runat="server" Width="250px"></asp:TextBox>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label34" runat="server" Text="Authorised Signatory"
                                        Style="padding-left: 86px;" Width="220px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="txt_trans_wedo" runat="server" Width="450"
                                        Text="(N.B. Please turn over for the reverse side of the form)"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="lbl_text_newcss" ID="Label38" runat="server" Width="390px" Style="azimuth: right;
                                        padding-left: 110px;" Text="(Importer or his Agent or his duly constituted attorney)"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="1px">
                                </td>
                                <%--<td >  <asp:Label ID="Label18" runat="server" Width="150px" CssClass="lbl_text_newcss"
        >Escorting fee pa</asp:Label>--%>
                                <asp:TextBox CssClass="left_rht_bot_top" ID="txtEscortFees" runat="server" Visible="false"
                                    Width="410px"></asp:TextBox>
                                <asp:Label ID="Label19" runat="server" Width="250px" Style="padding-left: 116px;"
                                    CssClass="lbl_text_newcss">Date</asp:Label></td>
                            </tr>
                            <%--<tr>
<td>
</td>
<td><asp:Label CssClass="lbl_text_newcss"  ID="Label15" runat="server" 
        Width="300px"></asp:Label>
<asp:Label CssClass="lbl_text_newcss"  ID="Label16" runat="server" 
        Width="420px" Text="(Receipt No. and Date)"
       ></asp:Label>
        <asp:Label CssClass="lbl_text_newcss"  ID="Label17" runat="server" Width="790" style="text-align:right;"
        ></asp:Label>
        </td>
</tr>--%>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <%--<td colspan="1">
<asp:Label CssClass="lbl_text_newcss"  ID="Label20" runat="server" Text="Cashier's signature"
        Width="110px"></asp:Label>
</td>--%>
                            </tr>
                            <%--<tr>
<td colspan="1">
<asp:Label CssClass="lbl_text_newcss"  ID="Label21" runat="server" Text="Certified that within mentioned articles were conveyed under my supervision."
        Width="450px"></asp:Label>
</td>
</tr>--%>
                        </table>
                        <table>
                            <tr>
                                <td width="1px">
                                </td>
                                <asp:TextBox CssClass="left_rht_bot_top" ID="txt_DeliveredTo" runat="server" Visible="false"
                                    Width="250px"></asp:TextBox>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <caption>
                                    &gt;
                                </caption>
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
                    <asp:HiddenField ID="hdn_jobno" runat="server" />

                    
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
//           function open_jobno() {

//           }
           function ddl_cfs_change(val) {
               
               var ctrl = document.getElementById(val);

               document.getElementById("txt_trans_cfs").value = ctrl.value;
               document.getElementById("txt_trans_cfsname").value = ctrl.value;
               document.getElementById("txt_trans_cfs1").value = ctrl.value;
                   //document.getElementById("txt_MVT_CFSFINAL").value = ctrl.value;

             

           }
           function validate() {

    </script>
      
       <script type="text/javascript">

         

           function open_jobno() {

               if (document.getElementById("<%=hdn_jobno.ClientID %>").value != '') {

                   document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=hdn_jobno.ClientID %>").value;
                   if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                       var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                       NewWindow1('../Import_Report/Import_N_Form_Rpt_viewer.aspx?jobno=' + f + '&Type='+ 'Report1' + '', 'List', '810', '1024', 'yes');

                       return false
                       alert(f);
                   }
               }

           }

           function open_jobno2() {

               if (document.getElementById("<%=hdn_jobno.ClientID %>").value != 'Select') {

                   document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=hdn_jobno.ClientID %>").value;
                   if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                       var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                       NewWindow1('../Import_Report/Import_N_Form_Rpt_viewer.aspx?jobno=' + f + '&Type=' + 'Report2' + '', 'List', '810', '1024', 'yes');
//                       NewWindow1('../Import_Report/Import_N_Form_Rpt_viewer2.aspx', 'List', '810', '1024', 'yes');

                       //opennew_Import_report(f);
                       return false
                       alert(f);
                   }
               }

           }


//           function open_jobno2() {

//               if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

//                   document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
//                   if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

//                       var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
//                       NewWindow1('../Report/NForm_2_Page.aspx', 'List', '810', '1024', 'yes');

//                       //opennew_Import_report(f);
//                       return false
//                       alert(f);
//                   }
//               }

//           }
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

           // call server side method

           // calling Importer

           // set the destination textbox value with the ContactName
           function CallSuccess_Importer(res, destCtrl) {
               Loading_HideImage();

               var dest = document.getElementById(destCtrl);
               //dest.value = res;
               var data = res;
               if (data.indexOf("~~") != -1) {

                   var s = data.split('~~');

                   var before = s[0];
                   var after1 = s[1];
                   var after2 = s[2];
                   var after3 = s[3];
                   var after4 = s[4];
                   var after5 = s[5];

                   //                   document.getElementById("txtCustomHouse").value = before;
                   //                   document.getElementById("txtImporterName").value = after1;
                   //                   document.getElementById("txtDescription").value = after2;
                   //                   document.getElementById("txtNoofInvoices").value = after3;
                   //                   document.getElementById("txtNoofItems").value = after4;
                   //                   document.getElementById("txtBE_Type").value = after5;


               }
               else {

                   //                   document.getElementById("txtCustomHouse").value = "";
                   //                   document.getElementById("txtImporterName").value = "";
                   //                   document.getElementById("txtBE_Type").value = "";
                   //                   document.getElementById("txtSupplier").value = "";
                   //                   document.getElementById("txtNoofItems").value = "";
                   //                   document.getElementById("txtNoofInvoices").value = "";

               }
           }

           function CallFailed(res, destCtrl) {
               //alert(res.get_message());
           }
      </script>
   
  </body>
    </html>
